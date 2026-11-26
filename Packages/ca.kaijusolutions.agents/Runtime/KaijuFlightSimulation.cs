using Unity.Burst;
using Unity.Entities;
using Unity.Collections;
using Unity.Mathematics;
using Unity.Transforms;

namespace KaijuSolutions.Agents
{
    /// <summary>Flight steering in world XYZ coordinates, measured in units per second.</summary>
    public struct KaijuFlightSteering : IComponentData
    {
        public float3 DesiredVelocity;
        public float3 Velocity;
        public float MaxSpeed;
        public float Acceleration;

        internal void Integrate(float3 target, float delta)
        {
            if (math.lengthsq(target) > MaxSpeed * MaxSpeed)
                target = math.normalizesafe(target) * MaxSpeed;
            Velocity = Acceleration > 0
                ? math.lerp(Velocity, target, math.saturate(Acceleration * delta))
                : target;
        }
    }

    /// <summary>A weighted velocity or world-space target. An entity target uses its LocalTransform.</summary>
    public struct KaijuFlightInput : IBufferElementData
    {
        public KaijuSteeringMode Mode;
        public Entity Target;
        public float3 Value;
        public float Weight;
    }

    /// <summary>Spherical range sensor. Reads target transforms before movement each fixed step.</summary>
    public struct KaijuSphericalRangeSensor : IComponentData
    {
        public Entity Target;
        public float Radius;
        public bool Detected;
    }

    [BurstCompile]
    internal partial struct KaijuSphericalRangeJob : IJobEntity
    {
        [ReadOnly] public ComponentLookup<LocalTransform> Transforms;

        private void Execute(ref KaijuSphericalRangeSensor sensor, in LocalTransform transform)
        {
            sensor.Detected = sensor.Radius >= 0 && Transforms.TryGetComponent(sensor.Target, out var target) &&
                math.distancesq(target.Position, transform.Position) <= sensor.Radius * sensor.Radius;
        }
    }

    [BurstCompile]
    internal partial struct KaijuFlightVelocityJob : IJobEntity
    {
        public float Delta;
        [ReadOnly] public BufferLookup<KaijuFlightInput> Movements;
        [ReadOnly] public ComponentLookup<LocalTransform> Transforms;

        private void Execute(Entity entity, ref KaijuFlightSteering steering)
        {
            float3 desired = steering.DesiredVelocity;
            if (Movements.TryGetBuffer(entity, out var inputs) && Transforms.TryGetComponent(entity, out var pose))
            {
                foreach (var input in inputs)
                {
                    float3 value = input.Value;
                    if (input.Mode != KaijuSteeringMode.Velocity)
                    {
                        if (input.Target != Entity.Null)
                        {
                            if (!Transforms.TryGetComponent(input.Target, out var target)) continue;
                            value = target.Position;
                        }
                        value = math.normalizesafe(value - pose.Position) * steering.MaxSpeed;
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
    internal partial struct KaijuFlightTranslationJob : IJobEntity
    {
        public float Delta;
        private void Execute(ref LocalTransform transform, in KaijuFlightSteering steering)
        {
            transform.Position += steering.Velocity * Delta;
        }
    }

}
