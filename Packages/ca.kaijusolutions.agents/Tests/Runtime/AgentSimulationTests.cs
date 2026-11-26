using System.Collections;
using KaijuSolutions.Agents.Actuators;
using NUnit.Framework;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;
using UnityEngine;
using UnityEngine.TestTools;

namespace KaijuSolutions.Agents.Tests
{
    public class AgentSimulationTests
    {
        [UnityTest]
        public IEnumerator BridgeMovesAndCanBePooledWithoutAManager()
        {
            var go = new GameObject("Test Agent");
            try
            {
                var agent = go.AddComponent<KaijuTransformAgent>();
                agent.Control = Vector2.right;
                agent.MoveSpeed = 4;
                yield return new WaitForSeconds(0.15f);
                var entities = World.DefaultGameObjectInjectionWorld.EntityManager;
                Assert.That(entities.Exists(agent.SimulationEntity));
                Assert.That(go.transform.position.x, Is.GreaterThan(0));
                Assert.That(Object.FindAnyObjectByType<KaijuAgentsManager>(), Is.Null);
                var first = agent.SimulationEntity;
                go.SetActive(false);
                yield return null;
                yield return null;
                Assert.That(entities.Exists(first), Is.False);
                go.SetActive(true);
                yield return null;
                yield return null;
                Assert.That(entities.Exists(agent.SimulationEntity));
            }
            finally { Object.Destroy(go); }
        }

        [UnityTest]
        public IEnumerator EntityRequestRunsGameObjectActuator()
        {
            var go = new GameObject("Actuator Agent");
            try
            {
                var agent = go.AddComponent<KaijuTransformAgent>();
                var actuator = go.AddComponent<TestActuator>();
                yield return new WaitForSeconds(0.1f);
                var entities = World.DefaultGameObjectInjectionWorld.EntityManager;
                var state = entities.GetComponentData<KaijuActuation>(actuator.SimulationEntity);
                Assert.That(state.Agent, Is.EqualTo(agent.SimulationEntity));
                state.Requested = true;
                entities.SetComponentData(actuator.SimulationEntity, state);
                yield return new WaitForSeconds(0.1f);
                Assert.That(actuator.Executions, Is.EqualTo(1));
                Assert.That(entities.GetComponentData<KaijuActuation>(actuator.SimulationEntity).Requested, Is.False);
            }
            finally { Object.Destroy(go); }
        }

        [UnityTest]
        public IEnumerator EntityTargetDrivesSensingAndSeek()
        {
            var entities = World.DefaultGameObjectInjectionWorld.EntityManager;
            var target = entities.CreateEntity(typeof(LocalTransform));
            var agent = entities.CreateEntity(typeof(LocalTransform), typeof(KaijuSteering), typeof(KaijuRangeSensor), typeof(KaijuMovementInput), typeof(KaijuDecision), typeof(KaijuUtilityScore));
            try
            {
                entities.SetComponentData(agent, LocalTransform.Identity);
                entities.SetComponentData(target, LocalTransform.FromPosition(new float3(4, 0, 0)));
                entities.SetComponentData(agent, new KaijuSteering { MaxSpeed = 2 });
                entities.SetComponentData(agent, new KaijuRangeSensor { Target = target, Radius = 5 });
                var scores = entities.GetBuffer<KaijuUtilityScore>(agent);
                scores.Add(new KaijuUtilityScore { Value = 1 });
                scores.Add(new KaijuUtilityScore { Value = 5 });
                scores.Add(new KaijuUtilityScore { Value = 5 });
                entities.GetBuffer<KaijuMovementInput>(agent).Add(new KaijuMovementInput
                    { Target = target, Weight = 1, Mode = KaijuSteeringMode.Seek });
                yield return new WaitForSeconds(0.15f);
                Assert.That(entities.GetComponentData<KaijuDecision>(agent).Selected, Is.EqualTo(1));
                Assert.That(entities.GetComponentData<KaijuRangeSensor>(agent).Detected);
                Assert.That(entities.GetComponentData<KaijuSteering>(agent).Velocity.x, Is.EqualTo(2).Within(0.001));
                entities.DestroyEntity(target);
                yield return new WaitForSeconds(0.15f);
                Assert.That(entities.GetComponentData<KaijuRangeSensor>(agent).Detected, Is.False);
                Assert.That(entities.GetComponentData<KaijuSteering>(agent).Velocity.x, Is.Zero);
            }
            finally
            {
                entities.DestroyEntity(agent);
                if (entities.Exists(target)) entities.DestroyEntity(target);
            }
        }

        [UnityTest]
        public IEnumerator EntityOnlyAgentClampsSpeedAndMovesInXZ()
        {
            var entities = World.DefaultGameObjectInjectionWorld.EntityManager;
            var agent = entities.CreateEntity(typeof(KaijuSteering), typeof(LocalTransform));
            try
            {
                entities.SetComponentData(agent, LocalTransform.Identity);
                entities.SetComponentData(agent, new KaijuSteering { DesiredVelocity = new float2(0, 12), MaxSpeed = 3 });
                yield return new WaitForSeconds(0.15f);
                Assert.That(entities.GetComponentData<KaijuSteering>(agent).Velocity.y, Is.EqualTo(3).Within(0.001));
                Assert.That(entities.GetComponentData<LocalTransform>(agent).Position.z, Is.GreaterThan(0));
            }
            finally { entities.DestroyEntity(agent); }
        }
    }

    public sealed class TestActuator : KaijuActuator
    {
        public int Executions { get; private set; }

        protected override KaijuActuatorState Run()
        {
            Executions++;
            return KaijuActuatorState.Done;
        }
    }
}
