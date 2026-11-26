using Unity.Burst;
using Unity.Entities;
using Unity.Collections;
using Unity.Mathematics;
using Unity.Transforms;

namespace KaijuSolutions.Agents
{
    /// <summary>Planar steering in world XZ coordinates, measured in units per second.</summary>
    public struct KaijuSteering : IComponentData
    {
        public float2 DesiredVelocity;
        public float2 Velocity;
        public float MaxSpeed;
        public float Acceleration;

        internal void Integrate(float2 target, float delta)
        {
            if (math.lengthsq(target) > MaxSpeed * MaxSpeed)
                target = math.normalizesafe(target) * MaxSpeed;
            Velocity = Acceleration > 0
                ? math.lerp(Velocity, target, math.saturate(Acceleration * delta))
                : target;
        }
    }

    public enum KaijuSteeringMode : byte
    {
        Velocity,
        Seek,
        Flee
    }

    /// <summary>A weighted velocity or ground-plane target. An entity target uses its LocalTransform.</summary>
    public struct KaijuMovementInput : IBufferElementData
    {
        public KaijuSteeringMode Mode;
        public Entity Target;
        public float2 Value;
        public float Weight;
    }

    /// <summary>Ground-plane range sensor. Reads target transforms before movement each fixed step.</summary>
    public struct KaijuRangeSensor : IComponentData
    {
        public Entity Target;
        public float Radius;
        public bool Detected;
    }

    [BurstCompile]
    internal partial struct KaijuRangeJob : IJobEntity
    {
        [ReadOnly] public ComponentLookup<LocalTransform> Transforms;

        private void Execute(ref KaijuRangeSensor sensor, in LocalTransform transform)
        {
            sensor.Detected = sensor.Radius >= 0 && Transforms.TryGetComponent(sensor.Target, out var target) &&
                math.distancesq(target.Position.xz, transform.Position.xz) <= sensor.Radius * sensor.Radius;
        }
    }

    /// <summary>A candidate action score. Highest score wins, with ties resolved by buffer order.</summary>
    public struct KaijuUtilityScore : IBufferElementData
    {
        public float Value;
    }

    public struct KaijuDecision : IComponentData
    {
        /// <summary>Index of the selected score, or -1 when no action is available.</summary>
        public int Selected;
    }

    [BurstCompile]
    internal partial struct KaijuDecisionJob : IJobEntity
    {
        private void Execute(ref KaijuDecision decision, in DynamicBuffer<KaijuUtilityScore> scores)
        {
            decision.Selected = -1;
            float best = float.MinValue;
            for (int i = 0; i < scores.Length; i++)
            {
                float score = scores[i].Value;
                if (score <= best) continue;
                decision.Selected = i;
                best = score;
            }
        }
    }

    internal struct KaijuAgentBridge : IComponentData
    {
        public UnityObjectRef<KaijuAgent> Agent;
    }

    [BurstCompile]
    internal partial struct KaijuVelocityJob : IJobEntity
    {
        public float Delta;
        [ReadOnly] public BufferLookup<KaijuMovementInput> Movements;
        [ReadOnly] public ComponentLookup<LocalTransform> Transforms;

        private void Execute(Entity entity, ref KaijuSteering steering)
        {
            float2 desired = steering.DesiredVelocity;
            if (Movements.TryGetBuffer(entity, out var inputs) && Transforms.TryGetComponent(entity, out var pose))
            {
                foreach (var input in inputs)
                {
                    float2 value = input.Value;
                    if (input.Mode != KaijuSteeringMode.Velocity)
                    {
                        if (input.Target != Entity.Null)
                        {
                            if (!Transforms.TryGetComponent(input.Target, out var target)) continue;
                            value = target.Position.xz;
                        }
                        value = math.normalizesafe(value - pose.Position.xz) * steering.MaxSpeed;
                        if (input.Mode == KaijuSteeringMode.Flee) value = -value;
                    }
                    desired += value * input.Weight;
                }
            }
            steering.Integrate(desired, Delta);
        }
    }

    [BurstCompile]
    [WithNone(typeof(KaijuAgentBridge))]
    internal partial struct KaijuTranslationJob : IJobEntity
    {
        public float Delta;
        private void Execute(ref LocalTransform transform, in KaijuSteering steering)
        {
            transform.Position.xz += steering.Velocity * Delta;
        }
    }

    [WorldSystemFilter(WorldSystemFilterFlags.LocalSimulation)]
    [UpdateInGroup(typeof(FixedStepSimulationSystemGroup))]
    public partial class KaijuFixedSimulationSystem : SystemBase
    {
        private EntityQuery _planar;
        private EntityQuery _planarSensors;
        private EntityQuery _flight;
        private EntityQuery _sphericalSensors;
        private EntityQuery _bridges;

        protected override void OnCreate()
        {
            _planar = GetEntityQuery(ComponentType.ReadOnly<KaijuSteering>());
            _planarSensors = GetEntityQuery(ComponentType.ReadOnly<KaijuRangeSensor>());
            _flight = GetEntityQuery(ComponentType.ReadOnly<KaijuFlightSteering>());
            _sphericalSensors = GetEntityQuery(ComponentType.ReadOnly<KaijuSphericalRangeSensor>());
            _bridges = GetEntityQuery(ComponentType.ReadOnly<KaijuAgentBridge>());
        }

        protected override void OnUpdate()
        {
            bool defaultWorld = World == World.DefaultGameObjectInjectionWorld;
            if (defaultWorld) KaijuAgentsManager.HandlePending(EntityManager);
            float delta = SystemAPI.Time.DeltaTime;
            using var links = _bridges.ToComponentDataArray<KaijuAgentBridge>(Allocator.Temp);
            foreach (var link in links)
            {
                var agent = link.Agent.Value;
                if (agent && agent.isActiveAndEnabled && agent.PhysicsAgent) agent.Move(delta);
            }
            if (links.Length > 0)
            {
                if (defaultWorld) KaijuAgentsManager.BeginSensing();
                try
                {
                    foreach (var link in links)
                    {
                        var agent = link.Agent.Value;
                        if (agent && agent.isActiveAndEnabled) agent.SenseAutomatic();
                    }
                }
                finally { if (defaultWorld) KaijuAgentsManager.EndSensing(); }
            }
            foreach (var link in links)
            {
                var agent = link.Agent.Value;
                if (agent && agent.isActiveAndEnabled) agent.Act(delta);
            }
            foreach (var link in links)
            {
                var agent = link.Agent.Value;
                if (!agent || !agent.isActiveAndEnabled) continue;
                agent.WriteSteering(EntityManager, delta);
            }
            var transforms = SystemAPI.GetComponentLookup<LocalTransform>(true);
            var start = Dependency;
            var reads = start;
            if (!_planarSensors.IsEmptyIgnoreFilter)
                reads = new KaijuRangeJob { Transforms = transforms }.ScheduleParallel(start);
            bool hasGroundAgents = !_planar.IsEmptyIgnoreFilter;
            if (hasGroundAgents)
            {
                var ground = new KaijuVelocityJob
                {
                    Delta = delta,
                    Movements = SystemAPI.GetBufferLookup<KaijuMovementInput>(true),
                    Transforms = transforms
                }.ScheduleParallel(start);
                reads = Unity.Jobs.JobHandle.CombineDependencies(reads, ground);
            }
            if (!_sphericalSensors.IsEmptyIgnoreFilter)
            {
                var sensors = new KaijuSphericalRangeJob { Transforms = transforms }.ScheduleParallel(start);
                reads = Unity.Jobs.JobHandle.CombineDependencies(reads, sensors);
            }
            if (!_flight.IsEmptyIgnoreFilter)
            {
                var flight = new KaijuFlightVelocityJob
                {
                    Delta = delta,
                    Transforms = transforms,
                    Movements = SystemAPI.GetBufferLookup<KaijuFlightInput>(true)
                }.ScheduleParallel(start);
                reads = Unity.Jobs.JobHandle.CombineDependencies(reads, flight);
                reads = new KaijuFlightTranslationJob { Delta = delta }.ScheduleParallel(reads);
            }
            Dependency = reads;
            if (hasGroundAgents) Dependency = new KaijuTranslationJob { Delta = delta }.ScheduleParallel(Dependency);
            if (links.Length == 0) return;
            CompleteDependency();
            foreach (var link in links)
            {
                var agent = link.Agent.Value;
                if (!agent || !agent.isActiveAndEnabled || !EntityManager.Exists(agent.SimulationEntity)) continue;
                if (agent.FreeFlight)
                    agent.ApplyFlightVelocity(EntityManager.GetComponentData<KaijuFlightSteering>(agent.SimulationEntity).Velocity);
                else
                    agent.ApplyVelocity(EntityManager.GetComponentData<KaijuSteering>(agent.SimulationEntity).Velocity);
            }

        }
    }

    [WorldSystemFilter(WorldSystemFilterFlags.LocalSimulation)]
    [UpdateInGroup(typeof(FixedStepSimulationSystemGroup))]
    [UpdateAfter(typeof(KaijuFixedSimulationSystem))]
    public partial class KaijuDecisionSystem : SystemBase
    {
        protected override void OnCreate() => RequireForUpdate<KaijuDecision>();
        protected override void OnUpdate() => Dependency = new KaijuDecisionJob().ScheduleParallel(Dependency);

    }

    [WorldSystemFilter(WorldSystemFilterFlags.LocalSimulation)]
    [UpdateInGroup(typeof(SimulationSystemGroup))]
    [UpdateAfter(typeof(FixedStepSimulationSystemGroup))]
    public partial class KaijuFrameSimulationSystem : SystemBase
    {
        internal KaijuAgentRegistry Registry { get; set; }
        private EntityQuery _bridges;

        protected override void OnCreate()
        {
            _bridges = GetEntityQuery(ComponentType.ReadOnly<KaijuAgentBridge>());
        }

        protected override void OnUpdate()
        {
            if (World != World.DefaultGameObjectInjectionWorld) return;
            KaijuAgentsManager.HandlePending(EntityManager);
            using var links = _bridges.ToComponentDataArray<KaijuAgentBridge>(Allocator.Temp);
            float delta = SystemAPI.Time.DeltaTime;
            foreach (var link in links)
            {
                var agent = link.Agent.Value;
                if (agent && agent.isActiveAndEnabled && !agent.PhysicsAgent) agent.Move(delta);
            }
            foreach (var link in links)
            {
                var agent = link.Agent.Value;
                if (agent && agent.isActiveAndEnabled) agent.Look(delta);
            }
        }
    }
}
