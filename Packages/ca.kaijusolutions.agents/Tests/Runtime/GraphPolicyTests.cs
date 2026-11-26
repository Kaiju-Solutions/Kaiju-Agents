#if COM_UNITY_ML_AGENTS
using KaijuSolutions.Agents.Graphs;
using KaijuSolutions.Agents.Learning;
using NUnit.Framework;
using Unity.Entities;
using Unity.InferenceEngine;
using Unity.MLAgents;
using Unity.MLAgents.Actuators;
using Unity.MLAgents.Policies;
using Unity.MLAgents.Sensors;
using UnityEngine;

namespace KaijuSolutions.Agents.Tests
{
    public sealed class GraphInferenceProbe : Agent
    {
        public int Accepted;
        public float Output;
        public override void CollectObservations(VectorSensor sensor) => sensor.AddObservation(0.625f);
        public override void OnActionReceived(ActionBuffers actions)
        {
            if (!GetComponent<KaijuGraphPolicy>().AcceptActions) return;
            Accepted++;
            Output = actions.ContinuousActions[0];
        }
    }

    public sealed class GraphPolicyTests
    {
        private sealed class Pickup : IGraphAction
        {
            public int Count;
            public GraphResult Begin(GraphContext context) { Count++; return GraphResult.Succeeded; }
            public GraphResult Tick(GraphContext context, float delta) => GraphResult.Succeeded;
            public void Cancel(GraphContext context) { }
        }
        [Test]
        public void InferenceConsumesObservationsAndCancellationReleasesPendingActions()
        {
            var model = Resources.Load<ModelAsset>("KaijuDecisions/IdentityPolicy");
            if (!model)
            {
                if (System.Environment.GetEnvironmentVariable("KAIJU_REQUIRE_SAMPLES") == "1")
                    Assert.Fail("Visual Decisions sample policy is missing.");
                Assert.Ignore("Requires the Visual Decisions sample.");
            }
            var academy = Academy.Instance;
            bool automatic = academy.AutomaticSteppingEnabled;
            var go = new GameObject("Graph inference probe");
            go.SetActive(false);
            using var world = new World("Graph inference");
            var graph = KaijuGraph.Create(GraphFamily.BehaviorTree, 0, null, new[] { new GraphStep { Op = GraphOp.Policy, Key = "policy" } });
            try
            {
                academy.AutomaticSteppingEnabled = false;
                var parameters = go.AddComponent<BehaviorParameters>();
                parameters.BehaviorName = "Graph identity";
                parameters.BrainParameters.VectorObservationSize = 1;
                parameters.BrainParameters.ActionSpec = ActionSpec.MakeContinuous(1);
                parameters.BehaviorType = BehaviorType.InferenceOnly;
                parameters.Model = model;
                parameters.InferenceDevice = InferenceDevice.Burst;
                var probe = go.AddComponent<GraphInferenceProbe>();
                var policy = go.AddComponent<KaijuGraphPolicy>();
                go.SetActive(true);
                academy.EnvironmentStep();
                var services = new GraphServices();
                policy.Register(services);
                var system = world.GetOrCreateSystemManaged<KaijuGraphSystem>();
                var run = system.Start(world.EntityManager.CreateEntity(), graph, services);
                system.Update();
                academy.EnvironmentStep();
                Assert.Greater(probe.Accepted, 0);
                Assert.That(probe.Output, Is.EqualTo(0.625f).Within(1e-5f));
                system.Update();
                int accepted = probe.Accepted;
                run.Cancel();
                academy.EnvironmentStep();
                Assert.AreEqual(accepted, probe.Accepted);
                Assert.IsFalse(policy.AcceptActions);
                var rescue = Resources.Load<KaijuGraph>("KaijuDecisions/Rescue");
                Assert.IsNotNull(rescue, "The Visual Decisions sample must contain the authored rescue graph");
                var pickup = new Pickup();
                services.Actions.Add("rescue.pick-up", () => pickup);
                var mission = system.Start(run.Entity, rescue, services);
                var families = new System.Collections.Generic.HashSet<GraphFamily>();
                var messages = new System.Collections.Generic.List<string>();
                mission.Trace += (tick, asset, id, result) =>
                {
                    messages.Add($"{tick} {asset.name} {id} {result}");
                    Assert.IsTrue(id.isValid);
                    families.Add(asset.Family);
                };
                for (int i = 1; i <= 30 && mission.Result == GraphResult.Running; i++)
                {
                    world.SetTime(new Unity.Core.TimeData(i * 0.02, 0.02f));
                    system.Update();
                    academy.EnvironmentStep();
                }
                Assert.AreEqual(GraphResult.Succeeded, mission.Result, string.Join("\n", messages));
                Assert.AreEqual(5, families.Count);
                Assert.AreEqual(1, pickup.Count);
                Assert.IsFalse(policy.AcceptActions);
            }
            finally
            {
                Object.DestroyImmediate(go);
                Object.DestroyImmediate(graph);
                academy.AutomaticSteppingEnabled = automatic;
            }
        }
    }
}
#endif
