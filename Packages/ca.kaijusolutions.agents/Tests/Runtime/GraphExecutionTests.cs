using System;
using System.Collections.Generic;
using KaijuSolutions.Agents.Graphs;
using NUnit.Framework;
using Unity.Entities;
using UnityEngine;

namespace KaijuSolutions.Agents.Tests
{
    public sealed class GraphExecutionTests
    {
        private readonly List<KaijuGraph> assets = new();
        private World world;
        private Entity entity;
        private KaijuGraphSystem system;

        [SetUp]
        public void SetUp()
        {
            world = new World("Graph test");
            system = world.GetOrCreateSystemManaged<KaijuGraphSystem>();
            entity = world.EntityManager.CreateEntity();
        }

        [TearDown]
        public void TearDown()
        {
            world.Dispose();
            foreach (var asset in assets) UnityEngine.Object.DestroyImmediate(asset);
            assets.Clear();
        }

        private KaijuGraph Create(GraphFamily family, GraphStep[] steps, params GraphVariable[] variables)
        {
            var graph = KaijuGraph.Create(family, 0, variables, steps);
            assets.Add(graph);
            GraphValidation.Validate(graph);
            return graph;
        }

        private KaijuGraph Wrap(GraphFamily family, GraphStep leaf)
        {
            var fact = new GraphFact { Key = "done", Value = true };
            var variable = new GraphVariable { Name = "done", Default = GraphValue.From(false) };
            switch (family)
            {
                case GraphFamily.Htn:
                    return Create(family, new[] { new GraphStep { Op = GraphOp.Htn, Children = new[] { 1 } },
                        new GraphStep { Op = GraphOp.Method, Children = new[] { 2 } }, leaf });
                case GraphFamily.Goap:
                    leaf.Effects = new[] { fact };
                    return Create(family, new[] { new GraphStep { Op = GraphOp.Goap, Effects = new[] { fact }, Children = new[] { 1 } }, leaf }, variable);
                default:
                    var op = family == GraphFamily.Utility ? GraphOp.Utility : family == GraphFamily.StateMachine ? GraphOp.State : GraphOp.Sequence;
                    return Create(family, new[] { new GraphStep { Op = op, Children = new[] { 1 } }, leaf });
            }
        }

        private sealed class Probe : IGraphAction
        {
            public int Began, Ticked, Cancelled;
            public GraphResult Outcome = GraphResult.Running;
            public GraphResult Begin(GraphContext context) { Began++; return Outcome; }
            public GraphResult Tick(GraphContext context, float delta) { Ticked++; return Outcome; }
            public void Cancel(GraphContext context) => Cancelled++;
        }

        [Test]
        public void EveryFamilyExecutesEveryOtherFamily()
        {
            foreach (GraphFamily caller in Enum.GetValues(typeof(GraphFamily)))
                foreach (GraphFamily callee in Enum.GetValues(typeof(GraphFamily)))
                {
                    var target = Wrap(callee, new GraphStep { Op = GraphOp.Action, Key = "probe" });
                    var graph = Wrap(caller, new GraphStep { Op = GraphOp.Call, Graph = target });
                    var probe = new Probe { Outcome = GraphResult.Succeeded };
                    var services = new GraphServices();
                    services.Actions.Add("probe", () => probe);
                    var execution = system.Start(entity, graph, services);
                    for (int i = 0; i < 6; i++) system.Update();
                    Assert.AreEqual(GraphResult.Succeeded, execution.Result, $"{caller} calling {callee}");
                    Assert.AreEqual(1, probe.Began);
                }
        }

        [Test]
        public void ParentInterruptionReleasesPolicyBeforeNewStateEnters()
        {
            var policy = new Probe();
            var services = new GraphServices();
            services.Policies.Add("fly", () => policy);
            services.Events.Add("land", _ => Assert.AreEqual(1, policy.Cancelled));
            var tree = Wrap(GraphFamily.BehaviorTree, new GraphStep { Op = GraphOp.Policy, Key = "fly" });
            var nested = Wrap(GraphFamily.StateMachine, new GraphStep { Op = GraphOp.Call, Graph = tree });
            var graph = Create(GraphFamily.StateMachine, new[]
            {
                new GraphStep { Op = GraphOp.State, Children = new[] { 1 }, Transitions = new[] { new GraphTransition { Target = 2,
                    Guard = new GraphGuard { Kind = GraphGuard.Test.Signal, Key = "abort" } } } },
                new GraphStep { Op = GraphOp.Call, Graph = nested },
                new GraphStep { Op = GraphOp.State, EnterAction = "land", Children = new[] { 3 } },
                new GraphStep { Op = GraphOp.Succeed }
            });
            var run = system.Start(entity, graph, services);
            system.Update();
            Assert.AreEqual(1, policy.Began);
            run.Signal("abort");
            system.Update();
            system.Update();
            Assert.AreEqual(GraphResult.Succeeded, run.Result);
            Assert.AreEqual(1, policy.Cancelled);
        }

        [Test]
        public void PlannerExploresExpensiveAlternativesWithoutInvokingThem()
        {
            var goal = new[] { new GraphFact { Key = "open", Value = true } };
            var graph = Create(GraphFamily.Goap, new[]
            {
                new GraphStep { Op = GraphOp.Goap, Effects = goal, Children = new[] { 1, 2 } },
                new GraphStep { Op = GraphOp.Action, Key = "expensive", Cost = 10, Effects = goal },
                new GraphStep { Op = GraphOp.Succeed, Cost = 1, Effects = goal }
            }, new GraphVariable { Name = "open" });
            var probe = new Probe();
            var services = new GraphServices();
            services.Actions.Add("expensive", () => probe);
            var run = system.Start(entity, graph, services);
            system.Update();
            Assert.AreEqual(GraphResult.Succeeded, run.Result);
            Assert.IsTrue(run.Context.Get("open").Boolean);
            Assert.AreEqual(0, probe.Began);
        }

        [Test]
        public void PooledOrDestroyedOwnerCannotControlNextExecution()
        {
            var graph = Wrap(GraphFamily.BehaviorTree, new GraphStep { Op = GraphOp.Action, Key = "watch" });
            var probe = new Probe();
            var services = new GraphServices();
            services.Actions.Add("watch", () => probe);
            var old = system.Start(entity, graph, services);
            system.Update();
            var fresh = system.Start(entity, graph, services);
            old.Cancel();
            Assert.AreEqual(GraphResult.Cancelled, old.Result);
            system.Update();
            Assert.AreEqual(GraphResult.Running, fresh.Result);
            world.EntityManager.DestroyEntity(entity);
            system.Update();
            Assert.AreEqual(GraphResult.Cancelled, fresh.Result);
            Assert.AreEqual(2, probe.Cancelled);
        }

        [Test]
        public void SuccessfulCallCopiesTypedOutputsAndInterruptionClosesActionContext()
        {
            var local = new GraphVariable { Name = "child", Access = GraphAccess.InOut, Default = GraphValue.From(0) };
            var target = Create(GraphFamily.BehaviorTree, new[] { new GraphStep { Op = GraphOp.Action, Key = "increment" } }, local);
            var parent = new GraphVariable { Name = "count", Access = GraphAccess.Input, Default = GraphValue.From(0) };
            var graph = Create(GraphFamily.StateMachine, new[]
            {
                new GraphStep { Op = GraphOp.State, Children = new[] { 1 } },
                new GraphStep { Op = GraphOp.Call, Graph = target, Bindings = new[] { new GraphBinding { Parent = "count", Child = "child" } } }
            }, parent);
            GraphContext captured = null;
            var services = new GraphServices();
            services.Actions.Add("increment", () => new Callback(context =>
            {
                captured = context;
                context.Set("child", GraphValue.From(context.Get("child").Integer + 1));
                return GraphResult.Succeeded;
            }));
            var run = system.Start(entity, graph, services, new Dictionary<string, GraphValue> { { "count", GraphValue.From(2) } });
            system.Update();
            Assert.AreEqual(3, run.Context.Get("count").Integer);
            Assert.IsFalse(captured.TrySet("child", GraphValue.From(100)));
            Assert.AreEqual(GraphResult.Succeeded, run.Result);
        }

        private sealed class Callback : IGraphAction
        {
            private readonly Func<GraphContext, GraphResult> callback;
            internal Callback(Func<GraphContext, GraphResult> callback) => this.callback = callback;
            public GraphResult Begin(GraphContext context) => callback(context);
            public GraphResult Tick(GraphContext context, float delta) => GraphResult.Running;
            public void Cancel(GraphContext context) { }
        }

        [Test]
        public void UtilityMarginPreventsThrashingAndClosesPreemptedContext()
        {
            GraphContext former = null;
            var services = new GraphServices();
            services.Actions.Add("watch", () => new Callback(c => { former = c; return GraphResult.Running; }));
            var graph = Create(GraphFamily.Utility, new[]
            {
                new GraphStep { Op = GraphOp.Utility, Children = new[] { 1, 2 }, SwitchMargin = 0.2f },
                new GraphStep { Op = GraphOp.Action, Key = "watch", BaseScore = 0.5f },
                new GraphStep { Op = GraphOp.Succeed, Cost = 0, Score = new GraphScore { Operation = ScoreOperation.Curve,
                    Key = "risk", Curve = AnimationCurve.Linear(0, 0, 1, 1) } }
            }, new GraphVariable { Name = "risk", Default = GraphValue.From(0f) });
            var run = system.Start(entity, graph, services);
            system.Update();
            run.Context.Set("risk", GraphValue.From(0.6f));
            system.Update();
            Assert.IsTrue(former.IsActive);
            run.Context.Set("risk", GraphValue.From(0.8f));
            system.Update();
            Assert.AreEqual(GraphResult.Succeeded, run.Result);
            Assert.IsFalse(former.TrySet("risk", GraphValue.From(0f)));
        }

        [Test]
        public void PlannerBacktracksAcrossMethodsWithTypedEffects()
        {
            var needed = new[] { new GraphFact { Key = "floor", TypedValue = GraphValue.From(2) } };
            var graph = Create(GraphFamily.Htn, new[]
            {
                new GraphStep { Op = GraphOp.Htn, Children = new[] { 1, 2 } },
                new GraphStep { Op = GraphOp.Method, Children = new[] { 3 } },
                new GraphStep { Op = GraphOp.Method, Children = new[] { 4, 3 } },
                new GraphStep { Op = GraphOp.Succeed, Preconditions = needed },
                new GraphStep { Op = GraphOp.Succeed, Effects = needed }
            }, new GraphVariable { Name = "floor", Default = GraphValue.From(1) });
            var run = system.Start(entity, graph);
            system.Update();
            system.Update();
            Assert.AreEqual(GraphResult.Succeeded, run.Result);
            Assert.AreEqual(2, run.Context.Get("floor").Integer);
        }

        [Test]
        public void ReactiveSelectorInterruptsFallbackWhenPriorityGuardChanges()
        {
            var probe = new Probe();
            var services = new GraphServices();
            services.Actions.Add("idle", () => probe);
            var graph = Create(GraphFamily.BehaviorTree, new[]
            {
                new GraphStep { Op = GraphOp.Selector, Reactive = true, Children = new[] { 1, 4 } },
                new GraphStep { Op = GraphOp.Sequence, Children = new[] { 2, 3 } },
                new GraphStep { Op = GraphOp.Condition, Guard = new GraphGuard { Kind = GraphGuard.Test.Fact, Key = "found" } },
                new GraphStep { Op = GraphOp.Succeed }, new GraphStep { Op = GraphOp.Action, Key = "idle" }
            }, new GraphVariable { Name = "found" });
            var run = system.Start(entity, graph, services);
            system.Update();
            system.Update();
            Assert.AreEqual(1, probe.Began);
            run.Context.Set("found", GraphValue.From(true));
            system.Update();
            Assert.AreEqual(1, probe.Cancelled);
            Assert.AreEqual(GraphResult.Succeeded, run.Result);
        }

        [Test]
        public void ProspectivePlanChecksLiveFactsBeforeEachStep()
        {
            var needed = new[] { new GraphFact { Key = "ready", Value = true } };
            var goal = new[] { new GraphFact { Key = "done", Value = true } };
            var graph = Create(GraphFamily.Goap, new[]
            {
                new GraphStep { Op = GraphOp.Goap, Retries = 1, Effects = goal, Children = new[] { 1, 2 } },
                new GraphStep { Op = GraphOp.Succeed, Effects = needed },
                new GraphStep { Op = GraphOp.Succeed, Preconditions = needed, Effects = goal }
            }, new GraphVariable { Name = "ready" }, new GraphVariable { Name = "done" });
            var run = system.Start(entity, graph);
            system.Update();
            run.Context.Set("ready", GraphValue.From(false));
            system.Update();
            Assert.IsFalse(run.Context.Get("done").Boolean);
            system.Update();
            system.Update();
            Assert.AreEqual(GraphResult.Succeeded, run.Result);
        }

        [TestCase(false, GraphResult.Succeeded)]
        [TestCase(true, GraphResult.TimedOut)]
        public void PolicyLeaseLastsItsConfiguredSimulationDuration(bool timeout, GraphResult expected)
        {
            world.SetTime(new Unity.Core.TimeData(0, 0.1f));
            var policy = new Probe();
            var services = new GraphServices();
            services.Policies.Add("drive", () => policy);
            var graph = Create(GraphFamily.BehaviorTree, new[] { new GraphStep { Op = GraphOp.Policy, Key = "drive",
                Duration = timeout ? 0 : 0.2f, Timeout = timeout ? 0.2f : 0 } });
            var run = system.Start(entity, graph, services);
            system.Update();
            system.Update();
            Assert.AreEqual(GraphResult.Running, run.Result);
            system.Update();
            Assert.AreEqual(expected, run.Result);
            Assert.AreEqual(1, policy.Cancelled);
        }

        [Test]
        public void PolicyStopsOnNamedSignalAndNeverReceivesAnotherTick()
        {
            var probe = new Probe();
            var services = new GraphServices();
            services.Policies.Add("drive", () => probe);
            var graph = Create(GraphFamily.BehaviorTree, new[] { new GraphStep { Op = GraphOp.Policy, Key = "drive",
                Guard = new GraphGuard { Kind = GraphGuard.Test.Signal, Key = "arrived" } } });
            var run = system.Start(entity, graph, services);
            system.Update();
            run.Signal("arrived");
            system.Update();
            system.Update();
            Assert.AreEqual(GraphResult.Succeeded, run.Result);
            Assert.AreEqual(0, probe.Ticked);
            Assert.AreEqual(1, probe.Cancelled);
        }

        [Test]
        public void ManyPlannersShareBudgetAndCancelledFrontiersReleaseCleanly()
        {
            system.PlannerExpansionsPerTick = 1;
            var graph = Wrap(GraphFamily.Goap, new GraphStep { Op = GraphOp.Succeed });
            var runs = new GraphExecution[8];
            for (int i = 0; i < runs.Length; i++) runs[i] = system.Start(world.EntityManager.CreateEntity(), graph);
            system.Update();
            foreach (var run in runs) Assert.AreEqual(GraphResult.Running, run.Result);
            runs[2].Cancel();
            for (int i = 0; i < 24; i++) system.Update();
            for (int i = 0; i < runs.Length; i++)
                Assert.AreEqual(i == 2 ? GraphResult.Cancelled : GraphResult.Succeeded, runs[i].Result);
        }

        [Test]
        public void CodeBuiltGraphsValidateAndOwnTheirInstructionData()
        {
            var child = Create(GraphFamily.BehaviorTree, new[] { new GraphStep { Op = GraphOp.Succeed } },
                new GraphVariable { Name = "goal", Access = GraphAccess.Input, Default = GraphValue.From(2) });
            Assert.Throws<FormatException>(() => KaijuGraph.Create(GraphFamily.BehaviorTree, 0, null,
                new[] { new GraphStep { Op = GraphOp.Call, Graph = child } }));
            Assert.Throws<FormatException>(() => KaijuGraph.Create(GraphFamily.BehaviorTree, 0, null,
                new[] { new GraphStep { Op = GraphOp.Sequence, Children = new[] { 0 } } }));
            var steps = new[] { new GraphStep { Op = GraphOp.Succeed } };
            var frozen = Create(GraphFamily.BehaviorTree, steps);
            steps[0].Op = GraphOp.Fail;
            frozen.InspectStep(0).Op = GraphOp.Fail;
            var run = system.Start(entity, frozen);
            system.Update();
            Assert.AreEqual(GraphResult.Succeeded, run.Result);
        }
    }
}
