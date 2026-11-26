using System;
using System.Collections.Generic;
using Unity.Entities;
using UnityEngine;

namespace KaijuSolutions.Agents.Graphs
{
    public readonly struct GraphLocation
    {
        public readonly KaijuGraph Graph;
        public readonly UnityEngine.Hash128 Node;
        public readonly GraphOp Operation;
        public readonly string Service;
        internal GraphLocation(KaijuGraph graph, GraphStep step)
        { Graph = graph; Node = step.Id; Operation = step.Op; Service = step.Key; }
    }
    /// <summary>One instance per active invocation. Implement Cancel to release owned resources.</summary>
    public interface IGraphAction
    {
        GraphResult Begin(GraphContext context);
        GraphResult Tick(GraphContext context, float delta);
        void Cancel(GraphContext context);
    }

    public sealed class GraphServices
    {
        public readonly Dictionary<string, Func<IGraphAction>> Actions = new();
        public readonly Dictionary<string, Func<IReadOnlyGraphContext, bool>> Predicates = new();
        public readonly Dictionary<string, Func<IReadOnlyGraphContext, float>> Scorers = new();
        public readonly Dictionary<string, Action<GraphContext>> Events = new();
        public readonly Dictionary<string, Func<IGraphAction>> Policies = new();
        public void RegisterAction(string key, Action<GraphContext> callback)
        {
            var action = new ImmediateAction(callback ?? throw new ArgumentNullException(nameof(callback)));
            Actions.Add(key, () => action);
        }
        private sealed class ImmediateAction : IGraphAction
        {
            private readonly Action<GraphContext> callback;
            internal ImmediateAction(Action<GraphContext> callback) => this.callback = callback;
            public GraphResult Begin(GraphContext context) { callback(context); return GraphResult.Succeeded; }
            public GraphResult Tick(GraphContext context, float delta) => GraphResult.Succeeded;
            public void Cancel(GraphContext context) { }
        }
    }

    public interface IReadOnlyGraphContext
    {
        World World { get; }
        Entity Entity { get; }
        GraphValue Get(string key);
    }

    public sealed class GraphContext : IReadOnlyGraphContext
    {
        private readonly KaijuGraph graph;
        private readonly GraphValue[] values;
        private bool closed;
        public GraphExecution Execution { get; }
        public Entity Entity => Execution.Entity;
        public World World => Execution.World;
        internal GraphContext(GraphExecution execution, KaijuGraph graph)
        {
            Execution = execution;
            this.graph = graph;
            values = graph.Variables.Count == 0 ? Array.Empty<GraphValue>() : new GraphValue[graph.Variables.Count];
            for (int i = 0; i < values.Length; i++) values[i] = graph.Variables[i].Default;
        }
        private GraphContext(GraphContext parent) { Execution = parent.Execution; graph = parent.graph; values = parent.values; }
        internal GraphContext OpenAction() => new GraphContext(this);
        internal void CloseAction() => closed = true;
        public bool IsActive => !closed && Execution.Result == GraphResult.Running;
        public void Signal(string name) { if (IsActive) Execution.Signal(name); }
        public GraphValue Get(string key) => graph.TrySlot(key, out int index) ? values[index] : throw new KeyNotFoundException(key);
        public bool TrySet(string key, GraphValue value)
        {
            if (!IsActive || !graph.TrySlot(key, out int index) || values[index].Type != value.Type) return false;
            values[index] = value;
            return true;
        }
        public void Set(string key, GraphValue value)
        {
            if (!TrySet(key, value)) throw new ArgumentException($"Inactive context or incompatible variable '{key}'");
        }
    }

    public sealed class GraphExecution
    {
        public World World { get; }
        public Entity Entity { get; }
        public GraphServices Services { get; }
        internal KaijuGraphSystem System { get; }
        public GraphContext Context { get; }
        public GraphResult Result { get; private set; } = GraphResult.Running;
        public ulong TickNumber { get; private set; }
        public event Action<ulong, KaijuGraph, UnityEngine.Hash128, GraphResult> Trace;
        public event Action<GraphExecution> TickFinished;
        public event Action<ulong, KaijuGraph, UnityEngine.Hash128, string, float> Decision;
        internal bool TracingDecisions => Decision != null;
        internal void Explain(KaijuGraph graph, GraphStep step, string reason, float value) =>
            Decision?.Invoke(TickNumber, graph, step.Id, reason, value);
        public void GetActiveNodes(List<UnityEngine.Hash128> destination)
        {
            destination.Clear();
            root?.GetActiveNodes(destination);
        }
        public void GetCallStack(List<GraphLocation> destination)
        {
            destination.Clear();
            root?.GetCallStack(destination);
        }
        private HashSet<string> pendingSignals = new();
        private HashSet<string> signals = new();
        private GraphFrame root;
        private bool advancing;
        private bool cancelling;

        internal GraphExecution(World world, Entity entity, KaijuGraph graph, GraphServices services,
            IReadOnlyDictionary<string, GraphValue> inputs)
        {
            World = world;
            System = world.GetExistingSystemManaged<KaijuGraphSystem>();
            Entity = entity;
            Services = services ?? new GraphServices();
            if (services == null) GraphEntityServices.Register(Services);
            Context = new GraphContext(this, graph);
            if (inputs != null)
                foreach (var pair in inputs)
                {
                    if (!graph.TrySlot(pair.Key, out int index) || graph.Variables[index].Access is not (GraphAccess.Input or GraphAccess.InOut))
                        throw new ArgumentException($"Undeclared input {pair.Key}");
                    Context.Set(pair.Key, pair.Value);
                }
            root = new GraphFrame(graph, graph.Entry, Context, null);
        }

        public void Signal(string name) { if (Result == GraphResult.Running) pendingSignals.Add(name); }
        internal bool Signalled(string name) => signals.Contains(name);
        internal void Record(KaijuGraph graph, GraphStep step, GraphResult result) => Trace?.Invoke(TickNumber, graph, step.Id, result);
        public void Cancel()
        {
            if (Result != GraphResult.Running) return;
            cancelling = true;
            if (!advancing) FinishCancellation();
        }
        private void FinishCancellation()
        {
            Result = GraphResult.Cancelled;
            StopRoot();
        }
        private void StopRoot()
        {
            try { root?.Stop(); }
            catch (Exception e) { Debug.LogException(e); }
            finally { root = null; }
        }
        internal void Advance(float delta)
        {
            if (Result != GraphResult.Running) return;
            advancing = true;
            (signals, pendingSignals) = (pendingSignals, signals);
            TickNumber++;
            try { Result = root.Tick(delta); }
            catch (Exception e) { Result = GraphResult.Failed; StopRoot(); Debug.LogException(e); }
            finally
            {
                advancing = false;
                signals.Clear();
                if (cancelling) FinishCancellation();
                if (Result != GraphResult.Running) root = null;
                TickFinished?.Invoke(this);
            }
        }
    }

    internal sealed class GraphFrame
    {
        internal KaijuGraph Graph { get; private set; }
        private GraphContext context;
        private readonly GraphFrame parent;
        private readonly int depth;
        private int index;
        private GraphStep Step => Graph.Steps[index];
        private GraphFrame child;
        private GraphFrame reusableChild;
        private IGraphAction action;
        private GraphContext actionContext;
        private bool entered;
        private float elapsed;
        private float nextEvaluation;
        private int cursor;
        private int selected = -1;
        private GraphUtilityLayout? utilityLayout;
        private GraphResult childResult;
        private GraphPlan planner;
        private bool explainedPlan;
        private int retries;

        internal GraphFrame(KaijuGraph graph, int index, GraphContext context, GraphFrame parent)
        {
            this.parent = parent;
            depth = (parent?.depth ?? 0) + 1;
            if (depth > 128) throw new InvalidOperationException("Graph nesting exceeds 128 frames");
            Reset(graph, index, context);
        }

        private void Reset(KaijuGraph graph, int next, GraphContext local)
        {
            Graph = graph;
            index = next;
            context = local;
            cursor = retries = 0;
            elapsed = nextEvaluation = 0;
            selected = -1;
            utilityLayout = null;
            explainedPlan = false;
            childResult = GraphResult.Running;
        }

        private void OpenChild(KaijuGraph graph, int next, GraphContext local)
        {
            if (reusableChild == null) reusableChild = new GraphFrame(graph, next, local, this);
            else reusableChild.Reset(graph, next, local);
            child = reusableChild;
        }

        private void CloseChild(bool cancel)
        {
            var closing = child;
            if (closing == null) return;
            child = null;
            try { if (cancel) closing.Stop(); }
            finally { closing.context = null; closing.Graph = null; }
        }

        private void Notify(string key)
        {
            if (!string.IsNullOrEmpty(key)) context.Execution.Services.Events[key](context);
        }

        internal void GetActiveNodes(List<UnityEngine.Hash128> destination)
        {
            if (entered) destination.Add(Step.Id);
            child?.GetActiveNodes(destination);
        }
        internal void GetCallStack(List<GraphLocation> destination)
        {
            if (entered) destination.Add(new GraphLocation(Graph, Step));
            child?.GetCallStack(destination);
        }

        internal void Stop()
        {
            try { CloseChild(true); }
            finally
            {
                try { ReleaseAction(true); }
                finally { Exit(GraphResult.Cancelled); }
            }
        }

        private void ReleaseAction(bool cancel)
        {
            var pending = action;
            action = null;
            try { if (cancel) pending?.Cancel(actionContext); }
            finally { actionContext?.CloseAction(); actionContext = null; }
        }

        private void Exit(GraphResult result)
        {
            if (!entered) return;
            planner?.Dispose();
            planner = null;
            entered = false;
            try { Notify(Step.ExitAction); }
            finally { context.Execution.Record(Graph, Step, result); }
        }

        internal GraphResult Tick(float delta)
        {
            bool first = !entered;
            if (!entered)
            {
                entered = true;
                context.Execution.Record(Graph, Step, GraphResult.Running);
                Notify(Step.EnterAction);
            }
            if (!first || Step.Op is not (GraphOp.Action or GraphOp.Policy)) elapsed += delta;
            var result = Evaluate(delta);
            if (result != GraphResult.Running) Exit(result);
            return result;
        }

        private bool Check(GraphGuard guard) => GraphRules.Check(guard, context, childResult);
        private GraphResult Run(int next, float delta)
        {
            if (child == null) OpenChild(Graph, next, context);
            var result = child.Tick(delta);
            if (result != GraphResult.Running) CloseChild(false);
            return result;
        }

        private GraphResult Evaluate(float delta)
        {
            var step = Step;
            switch (step.Op)
            {
                case GraphOp.Succeed: return GraphResult.Succeeded;
                case GraphOp.Fail: return GraphResult.Failed;
                case GraphOp.Condition: return Check(step.Guard) ? GraphResult.Succeeded : GraphResult.Failed;
                case GraphOp.Wait: return elapsed >= step.Duration ? GraphResult.Succeeded : GraphResult.Running;
                case GraphOp.Action:
                case GraphOp.Policy:
                    if (step.Op == GraphOp.Policy && (step.Guard != null && Check(step.Guard) ||
                        action != null && step.Duration > 0 && elapsed >= step.Duration))
                    {
                        ReleaseAction(true);
                        return GraphResult.Succeeded;
                    }
                    if (step.Timeout > 0 && elapsed >= step.Timeout)
                    {
                        ReleaseAction(true);
                        return GraphResult.TimedOut;
                    }
                    GraphResult result;
                    if (action == null)
                    {
                        var registry = step.Op == GraphOp.Policy ? context.Execution.Services.Policies : context.Execution.Services.Actions;
                        if (!registry.TryGetValue(step.Key, out var factory)) return GraphResult.Failed;
                        action = factory();
                        actionContext = context.OpenAction();
                        result = action.Begin(actionContext);
                    }
                    else result = action.Tick(actionContext, delta);
                    if (result != GraphResult.Running) ReleaseAction(false);
                    return result;
                case GraphOp.Call: return Call(delta);
                case GraphOp.State:
                    foreach (var transition in step.Transitions)
                    {
                        if (!Check(transition.Guard)) continue;
                        context.Execution.Explain(Graph, step, "transition", transition.Target);
                        CloseChild(true);
                        Exit(GraphResult.Succeeded);
                        index = transition.Target;
                        elapsed = 0;
                        childResult = GraphResult.Running;
                        return GraphResult.Running;
                    }
                    if (step.Children.Length > 0 && childResult == GraphResult.Running)
                        childResult = Run(step.Children[0], delta);
                    if (step.Children.Length != 0 && childResult == GraphResult.Running) return GraphResult.Running;
                    return step.Completion switch
                    {
                        StateCompletion.Succeed => GraphResult.Succeeded, StateCompletion.Fail => GraphResult.Failed,
                        StateCompletion.Automatic when step.Transitions.Length == 0 && step.Children.Length > 0 => childResult,
                        _ => GraphResult.Running
                    };
                case GraphOp.Timeout:
                    if (elapsed > step.Timeout) { CloseChild(true); return GraphResult.TimedOut; }
                    return Run(step.Children[0], delta);
                case GraphOp.Retry:
                    var attempted = Run(step.Children[0], delta);
                    if (attempted != GraphResult.Failed || cursor >= step.Retries) return attempted;
                    cursor++;
                    return GraphResult.Running;
                case GraphOp.Repeat:
                    var repeated = Run(step.Children[0], delta);
                    if (repeated != GraphResult.Succeeded) return repeated;
                    cursor++;
                    return step.Retries == 0 || cursor < step.Retries ? GraphResult.Running : GraphResult.Succeeded;
                case GraphOp.Invert:
                    var inverted = Run(step.Children[0], delta);
                    return inverted == GraphResult.Failed ? GraphResult.Succeeded :
                        inverted == GraphResult.Succeeded ? GraphResult.Failed : inverted;
                case GraphOp.Sequence:
                case GraphOp.Method:
                case GraphOp.Selector:
                    return Composite(delta);
                case GraphOp.Utility: return Utility(delta);
                case GraphOp.Goap:
                case GraphOp.Htn: return Plan(delta);
                default: throw new InvalidOperationException($"Unknown graph operation {step.Op}");
            }
        }

        private GraphResult Composite(float delta)
        {
            bool selector = Step.Op == GraphOp.Selector;
            var advance = selector ? GraphResult.Failed : GraphResult.Succeeded;
            if (Step.Reactive && child != null)
                for (int i = 0; i < cursor; i++)
                {
                    int prior = Step.Children[i];
                    var outcome = Probe(prior);
                    if (selector ? outcome != GraphResult.Failed : outcome == GraphResult.Failed)
                    {
                        CloseChild(true);
                        if (!selector || outcome == GraphResult.Succeeded) return outcome;
                        cursor = i;
                        break;
                    }
                }
            if (cursor == Step.Children.Length) return advance;
            var result = Run(Step.Children[cursor], delta);
            if (result != advance) return result;
            cursor++;
            return cursor == Step.Children.Length ? advance : GraphResult.Running;
        }

        // Test a higher-priority branch without starting its gameplay actions. Running means it is eligible to execute.
        private GraphResult Probe(int index)
        {
            var step = Graph.Steps[index];
            switch (step.Op)
            {
                case GraphOp.Condition: return Check(step.Guard) ? GraphResult.Succeeded : GraphResult.Failed;
                case GraphOp.Fail: return GraphResult.Failed;
                case GraphOp.Succeed: return GraphResult.Succeeded;
                case GraphOp.Invert:
                    var childStatus = Probe(step.Children[0]);
                    return childStatus == GraphResult.Succeeded ? GraphResult.Failed :
                        childStatus == GraphResult.Failed ? GraphResult.Succeeded : childStatus;
                case GraphOp.Sequence:
                case GraphOp.Selector:
                    var advance = step.Op == GraphOp.Sequence ? GraphResult.Succeeded : GraphResult.Failed;
                    foreach (var next in step.Children)
                    {
                        var value = Probe(next);
                        if (value != advance) return value;
                    }
                    return advance;
                default: return GraphResult.Running;
            }
        }

        private GraphResult Call(float delta)
        {
            var target = Step.Graph;
            if (!target) return GraphResult.Failed;
            if (child == null)
            {
                for (var ancestor = this; ancestor != null; ancestor = ancestor.parent)
                    if (ancestor.Graph == target) throw new InvalidOperationException($"Recursive graph call to {target.name}");
                var local = new GraphContext(context.Execution, target);
                Bind(local, true);
                OpenChild(target, target.Entry, local);
            }
            var result = child.Tick(delta);
            if (result == GraphResult.Succeeded) Bind(child.context, false);
            if (result != GraphResult.Running) CloseChild(false);
            return result;
        }

        private void Bind(GraphContext local, bool input)
        {
            foreach (var binding in Step.Bindings)
            {
                if (!Step.Graph.TrySlot(binding.Child, out int index)) throw new ArgumentException($"Unknown child variable {binding.Child}");
                var access = Step.Graph.Variables[index].Access;
                if (access != GraphAccess.InOut && access != (input ? GraphAccess.Input : GraphAccess.Output)) continue;
                if (input) local.Set(binding.Child, context.Get(binding.Parent));
                else context.Set(binding.Parent, local.Get(binding.Child));
            }
        }

        private GraphResult Utility(float delta)
        {
            if (selected < 0 || elapsed >= nextEvaluation)
            {
                nextEvaluation = elapsed + Step.Duration;
                var system = context.Execution.System;
                var layout = utilityLayout ??= system.Selector(Graph, index);
                int best = layout.Winner;
                if (!layout.Constant || context.Execution.TracingDecisions)
                {
                    var scores = system.ScoreBuffer(Step.Children.Length);
                    for (int i = 0; i < scores.Length; i++)
                    {
                        int choice = Step.Children[i];
                        scores[i] = Score(choice);
                        context.Execution.Explain(Graph, Graph.Steps[choice], "score", scores[i]);
                    }
                    best = GraphUtilityKernel.Choose(scores, selected, Step.SwitchMargin);
                }
                if (best < 0) { CloseChild(true); return GraphResult.Failed; }
                if (best != selected) { CloseChild(true); selected = best; }
            }
            return Run(Step.Children[selected], delta);
        }

        private float Score(int choice)
        {
            var candidate = Graph.Steps[choice];
            if (!Check(candidate.Eligibility)) return float.NegativeInfinity;
            float score = candidate.BaseScore + (candidate.Score?.Evaluate(context) ?? 0);
            if (!string.IsNullOrEmpty(candidate.Scorer)) score += context.Execution.Services.Scorers[candidate.Scorer](context);
            foreach (var item in candidate.Considerations)
                score += item.Weight * item.Response.Evaluate(context.Get(item.Input).Number);
            return score;
        }

        private GraphResult Plan(float delta)
        {
            planner ??= new GraphPlan(Graph, index, context);
            var status = context.Execution.System.Search(planner);
            if (context.Execution.TracingDecisions && !explainedPlan)
            {
                context.Execution.Explain(Graph, Step, planner.Reason, planner.Expansions);
                if (status == GraphResult.Succeeded)
                {
                    if (planner.Methods != null)
                        foreach (var method in planner.Methods) context.Execution.Explain(Graph, Graph.Steps[method], "method selected", method);
                    for (int i = 0; i < planner.Steps.Count; i++) context.Execution.Explain(Graph, Graph.Steps[planner.Steps[i]], "plan step", i);
                }
                else if (status == GraphResult.Failed)
                    foreach (var goal in Step.Effects)
                        if (!context.Get(goal.Key).Matches(goal.Expected)) context.Execution.Explain(Graph, Step, "unmet goal " + goal.Key, 0);
                explainedPlan = status != GraphResult.Running;
            }
            if (status != GraphResult.Succeeded) return status;
            if (cursor >= planner.Steps.Count) return GraphResult.Succeeded;
            int next = planner.Steps[cursor];
            var task = Graph.Steps[next];
            var result = GraphRules.Match(task.Preconditions, context) ? Run(next, delta) : GraphResult.Failed;
            if (result == GraphResult.Succeeded)
            {
                foreach (var effect in task.Effects) context.Set(effect.Key, effect.Expected);
                cursor++;
                return cursor == planner.Steps.Count ? GraphResult.Succeeded : GraphResult.Running;
            }
            if (result == GraphResult.Running) return result;
            CloseChild(true);
            if (retries++ >= Step.Retries) return result;
            planner.Dispose();
            planner = null;
            explainedPlan = false;
            cursor = 0;
            return GraphResult.Running;
        }
    }
}
