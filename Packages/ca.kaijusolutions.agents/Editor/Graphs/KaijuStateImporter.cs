using System;
using System.Collections.Generic;
using System.Linq;
using KaijuSolutions.Agents.Graphs;
using Unity.GraphToolkit.Editor;
using UnityEditor;
using UnityEditor.AssetImporters;

namespace KaijuSolutions.Agents.Editor.Graphs
{
    [Serializable, StateMachine(Extension, StateMachineOptions.SupportsSubgraphs)]
    internal class KaijuStateMachine : StateMachine
    {
        public const string Extension = "kaijufsm";
        [MenuItem("Assets/Create/Kaiju Agents/State Machine")]
        private static void Create() => StateMachineDatabase.PromptInProjectBrowserToCreateNewAsset<KaijuStateMachine>();
    }

    [Serializable, State("Kaiju")]
    internal class BehaviorState : State
    {
        protected override void OnDefineOptions(IOptionDefinitionContext context)
        {
            context.AddOption<bool>("Initial").Build();
            context.AddOption<int>("Priority").WithTooltip("Higher-priority destinations are tested first").Build();
            context.AddOption<StateCompletion>("Completion").Build();
            context.AddOption<KaijuGraph>("Behavior").Build();
            context.AddOption<string>("Bindings").Build();
            context.AddOption<string>("On enter").Build();
            context.AddOption<string>("On exit").Build();
        }
    }

    [Serializable, Condition("Signal received")] internal class SignalCondition : Condition<string> { }
    [Serializable, Condition("Child result")] internal class ResultCondition : Condition<GraphResult> { }
    [Serializable, Condition("C# predicate")] internal class PredicateCondition : Condition<string> { }

    [ScriptedImporter(3, KaijuStateMachine.Extension)]
    internal sealed class KaijuStateImporter : ScriptedImporter
    {
        private static T Option<T>(IState state, string name)
        {
            var option = state.GetOptionByName(name);
            return option != null && option.TryGetValue<T>(out var value) ? value : default;
        }

        private static GraphGuard Condition(ICondition condition)
        {
            switch (condition)
            {
                case IGroupCondition group:
                    return new GraphGuard { Kind = group.Operation == GroupConditionOperation.And ? GraphGuard.Test.All : GraphGuard.Test.Any,
                        Terms = group.Get().Select(Condition).ToArray() };
                case SignalCondition signal: return new GraphGuard { Kind = GraphGuard.Test.Signal, Key = signal.Value };
                case ResultCondition result: return new GraphGuard { Kind = GraphGuard.Test.Result, Result = result.Value };
                case PredicateCondition predicate: return new GraphGuard { Kind = GraphGuard.Test.Predicate, Key = predicate.Value };
                case IVariableCondition variable:
                    var operand = variable.Value switch
                    {
                        bool b => GraphValue.From(b), int i => GraphValue.From(i), float f => GraphValue.From(f),
                        string text => GraphValue.From(text), UnityEngine.Vector3 v => GraphValue.From(v),
                        _ => throw new FormatException("Unsupported state variable comparison")
                    };
                    return new GraphGuard { Kind = GraphGuard.Test.Compare, Key = variable.Variable.Name, Operand = operand,
                        Comparison = (GraphGuard.Relation)Enum.Parse(typeof(GraphGuard.Relation), variable.Comparison.ToString()) };
                default: throw new FormatException($"Unsupported transition condition {condition.GetType().Name}");
            }
        }

        private static string[] GatherDependenciesFromSourceFile(string path) => GraphDependencies.Gather(path);

        public override void OnImportAsset(AssetImportContext ctx)
        {
            try
            {
                var source = StateMachineDatabase.LoadStateMachineForImporter<KaijuStateMachine>(ctx.assetPath);
                if (!source.GetStates().Any()) return;
                var graph = Compile(ctx, source, new HashSet<StateMachine>(), new Dictionary<StateMachine, KaijuGraph>());
                ctx.SetMainObject(graph);
            }
            catch (Exception e) { ctx.LogImportError(e.Message); }
        }

        private static KaijuGraph Compile(AssetImportContext ctx, StateMachine source, HashSet<StateMachine> ancestors, Dictionary<StateMachine, KaijuGraph> compiled)
        {
            if (compiled.TryGetValue(source, out var existing)) return existing;
            if (!ancestors.Add(source)) throw new FormatException("Recursive state machine");
            var states = source.GetStates().ToArray();
            int initial = states.Length == 1 ? 0 : Array.FindIndex(states, s => Option<bool>(s, "Initial"));
            if (initial < 0 || states.Count(s => Option<bool>(s, "Initial")) > 1)
                throw new FormatException("Select one initial state in the Graph Inspector");
            var steps = states.Select(s => new GraphStep { Id = s.ID, Label = s.Title, Op = GraphOp.State }).ToList();
            for (int i = 0; i < states.Length; i++)
            {
                var state = states[i];
                var step = steps[i];
                step.Completion = Option<StateCompletion>(state, "Completion");
                step.EnterAction = Option<string>(state, "On enter");
                step.ExitAction = Option<string>(state, "On exit");
                step.Transitions = state.GetOutgoingTransitions().OrderByDescending(t => Option<int>(t.ToState, "Priority")).SelectMany(t => t.GetRules().Where(r => r.Enabled)
                    .Select(r => new GraphTransition { Target = Array.IndexOf(states, t.ToState), Guard = Condition(r.RootCondition) })).ToArray();
                var behavior = Option<KaijuGraph>(state, "Behavior");
                KaijuGraphImporter.Dependency(ctx, behavior);
                if (state is ISubgraphState nested && nested.GetSubgraphAsStateMachine() is StateMachine machine)
                    behavior = Compile(ctx, machine, ancestors, compiled);
                if (!behavior) continue;
                step.Children = new[] { steps.Count };
                steps.Add(new GraphStep { Op = GraphOp.Call, Label = "Run behavior", Graph = behavior, Id = UnityEngine.Hash128.Compute(state.ID + "/behavior"),
                    Bindings = KaijuGraphImporter.Bindings(Option<string>(state, "Bindings")) });
            }
            var graph = KaijuGraph.Create(GraphFamily.StateMachine, initial, KaijuGraphImporter.Variables(source.GetVariables()), steps.ToArray(), source.ID);
            ctx.AddObjectToAsset(ancestors.Count == 1 ? "Runtime" : source.ID.ToString(), graph);
            ancestors.Remove(source);
            compiled.Add(source, graph);
            return graph;
        }
    }
}
