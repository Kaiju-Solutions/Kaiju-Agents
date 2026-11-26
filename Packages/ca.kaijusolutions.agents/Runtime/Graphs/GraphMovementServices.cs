using KaijuSolutions.Agents.Movement;
using UnityEngine;

namespace KaijuSolutions.Agents.Graphs
{
    /// <summary>Built-in movement tasks read the target Vector and radius Number from the current graph.</summary>
    public static class GraphMovementServices
    {
        public static void Register(GraphServices services, KaijuAgent agent)
        {
            services.Actions.Add("seek", () => new Move(agent, false));
            services.Actions.Add("follow-route", () => new Move(agent, true));
            services.Predicates.Add("arrived", context => Arrived(agent, context));
            services.Predicates.Add("detected", GraphEntityServices.Detected);
        }

        private static bool Arrived(KaijuAgent agent, IReadOnlyGraphContext context)
        {
            var offset = context.Get("target").Vector - agent.transform.position;
            if (!agent.FreeFlight && agent is not KaijuNavigationAgent) offset.y = 0;
            float radius = context.Get("radius").Number;
            return radius >= 0 && offset.sqrMagnitude <= radius * radius;
        }

        private sealed class Move : IGraphAction
        {
            private readonly KaijuAgent agent;
            private readonly bool surface;
            private KaijuMovement movement;
            internal Move(KaijuAgent agent, bool surface) { this.agent = agent; this.surface = surface; }

            public GraphResult Begin(GraphContext context)
            {
                if (Arrived(agent, context)) return GraphResult.Succeeded;
                var target = context.Get("target").Vector;
                float radius = context.Get("radius").Number;
                if (surface && agent is not KaijuNavigationAgent || radius < 0) return GraphResult.Failed;
                movement = surface ? agent.PathFollow(target, distance: radius, clear: false) : agent.Seek(target, distance: radius, clear: false);
                return movement == null ? GraphResult.Failed : GraphResult.Running;
            }

            public GraphResult Tick(GraphContext context, float delta)
            {
                if (agent && Arrived(agent, context)) { Cancel(context); return GraphResult.Succeeded; }
                if (!agent || movement is KaijuPathFollowMovement path && !path.HasCompleteSurfaceRoute)
                {
                    Cancel(context);
                    return GraphResult.Failed;
                }
                return GraphResult.Running;
            }

            public void Cancel(GraphContext context)
            {
                if (agent && movement != null) agent.Stop(movement);
                movement = null;
            }
        }
    }
}
