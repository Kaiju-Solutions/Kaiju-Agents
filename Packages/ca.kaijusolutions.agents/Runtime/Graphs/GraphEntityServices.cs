using Unity.Mathematics;
using Unity.Transforms;

namespace KaijuSolutions.Agents.Graphs
{
    /// <summary>Registers entity-only steering and sensing on the current world. The target is a world-space Vector.</summary>
    public static class GraphEntityServices
    {
        public static void Register(GraphServices services)
        {
            services.Actions.Add("seek", () => new Seek());
            services.Predicates.Add("arrived", context => Offset(context, out var offset) && Within(context, offset));
            services.Predicates.Add("detected", Detected);
        }

        internal static bool Detected(IReadOnlyGraphContext context)
        {
            var entities = context.World.EntityManager;
            var entity = context.Entity;
            return entities.HasComponent<KaijuSphericalRangeSensor>(entity) && entities.GetComponentData<KaijuSphericalRangeSensor>(entity).Detected ||
                entities.HasComponent<KaijuRangeSensor>(entity) && entities.GetComponentData<KaijuRangeSensor>(entity).Detected;
        }

        private static bool Offset(IReadOnlyGraphContext context, out float3 offset)
        {
            offset = default;
            var entities = context.World.EntityManager;
            var entity = context.Entity;
            if (!entities.HasComponent<LocalTransform>(entity)) return false;
            var target = context.Get("target");
            if (target.Type != GraphType.Vector) return false;
            offset = (float3)target.Vector - entities.GetComponentData<LocalTransform>(entity).Position;
            if (entities.HasComponent<KaijuFlightSteering>(entity)) return true;
            offset.y = 0;
            return entities.HasComponent<KaijuSteering>(entity);
        }

        private static bool Within(IReadOnlyGraphContext context, float3 offset)
        {
            var radius = context.Get("radius");
            return radius.Type == GraphType.Number && radius.Number >= 0 && math.lengthsq(offset) <= radius.Number * radius.Number;
        }

        private sealed class Seek : IGraphAction
        {
            public GraphResult Begin(GraphContext context) => Tick(context, 0);
            public GraphResult Tick(GraphContext context, float delta)
            {
                if (!Offset(context, out var offset)) return GraphResult.Failed;
                var radius = context.Get("radius");
                if (radius.Type != GraphType.Number || radius.Number < 0) return GraphResult.Failed;
                if (Within(context, offset)) { Cancel(context); return GraphResult.Succeeded; }
                Steer(context, math.normalizesafe(offset));
                return GraphResult.Running;
            }

            public void Cancel(GraphContext context) => Steer(context, float3.zero);

            private static void Steer(GraphContext context, float3 direction)
            {
                var entities = context.World.EntityManager;
                var entity = context.Entity;
                if (!entities.Exists(entity)) return;
                if (entities.HasComponent<KaijuFlightSteering>(entity))
                {
                    var flight = entities.GetComponentData<KaijuFlightSteering>(entity);
                    flight.DesiredVelocity = direction * flight.MaxSpeed;
                    entities.SetComponentData(entity, flight);
                }
                else if (entities.HasComponent<KaijuSteering>(entity))
                {
                    var ground = entities.GetComponentData<KaijuSteering>(entity);
                    ground.DesiredVelocity = direction.xz * ground.MaxSpeed;
                    entities.SetComponentData(entity, ground);
                }
            }
        }
    }
}
