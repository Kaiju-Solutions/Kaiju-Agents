using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif
namespace KaijuSolutions.Agents.Movement
{
    /// <summary>
    /// Obstacle avoidance steering behaviour.
    /// </summary>
    public class KaijuObstacleAvoidanceMovement : KaijuMovement
    {
        /// <summary>
        /// The distance from a wall the agent should maintain.
        /// </summary>
        public float Avoidance
        {
            get => _avoidance;
            set => _avoidance = Mathf.Max(value, float.Epsilon);
        }
        
        /// <summary>
        /// The distance from a wall the agent should maintain.
        /// </summary>
        private float _avoidance;
        
        /// <summary>
        /// The distance for rays.
        /// </summary>
        public float Distance
        {
            get => _distance;
            set => _distance = Mathf.Max(value, float.Epsilon);
        }
        
        /// <summary>
        /// The distance for rays.
        /// </summary>
        private float _distance;
        
        /// <summary>
        /// The distance of the side rays. Zero or less will use the <see cref="Distance"/>.
        /// </summary>
        public float SideDistance
        {
            get => _sideDistance > 0 ? _sideDistance : _distance;
            set => _sideDistance = value;
        }
        
        /// <summary>
        /// The distance of the side rays. Zero or less will use the <see cref="Distance"/>.
        /// </summary>
        private float _sideDistance;
        
        /// <summary>
        /// The angle for rays.
        /// </summary>
        public float Angle;
        
        /// <summary>
        /// The height offset for the rays.
        /// </summary>
        public float Height;
        
        /// <summary>
        /// The horizontal shift for the side rays.
        /// </summary>
        public float Horizontal;
        
        /// <summary>
        /// The mask for what layers should the rays hit.
        /// </summary>
        public LayerMask? Mask;
        
        /// <summary>
        /// The points hit by the rays.
        /// </summary>
        public IReadOnlyList<RaycastHit> Hits => _hits;
        
        /// <summary>
        /// The points hit by the rays.
        /// </summary>
        private readonly List<RaycastHit> _hits = new(3);
        
        /// <summary>
        /// Get an obstacle avoidance movement.
        /// </summary>
        /// <param name="agent">The agent this is assigned to.</param>
        /// <param name="avoidance">The distance from a wall the agent should maintain.</param>
        /// <param name="distance">The distance for rays.</param>
        /// <param name="sideDistance">The distance of the side rays. Zero or less will use the <see cref="Distance"/>.</param>
        /// <param name="angle">The angle for side rays.</param>
        /// <param name="height">The height offset for the rays.</param>
        /// <param name="horizontal">The horizontal shift for the side rays.</param>
        /// <param name="mask">The mask for what layers should the rays hit.</param>
        /// <param name="weight">The weight of this movement.</param>
        /// <returns>Get an obstacle avoidance movement for the agent.</returns>
        public static KaijuObstacleAvoidanceMovement Get([NotNull] KaijuAgent agent, float avoidance = 2, float distance = 5, float sideDistance = 0, float angle = 15, float height = 1, float horizontal = 0, LayerMask? mask = null, float weight = 1)
        {
            KaijuObstacleAvoidanceMovement movement = KaijuMovementManager.Get<KaijuObstacleAvoidanceMovement>();
            if (movement == null)
            {
                return new(agent, avoidance, distance, sideDistance, angle, height, horizontal, mask, weight);
            }
            
            movement.Initialize(agent, avoidance, distance, sideDistance, angle, height, horizontal, mask, weight);
            return movement;
        }
        
        /// <summary>
        /// Create an obstacle avoidance movement.
        /// </summary>
        /// <param name="agent">The agent this is assigned to.</param>
        /// <param name="avoidance">The distance from a wall the agent should maintain.</param>
        /// <param name="distance">The distance for rays.</param>
        /// <param name="sideDistance">The distance of the side rays. Zero or less will use the <see cref="Distance"/>.</param>
        /// <param name="angle">The angle for side rays.</param>
        /// <param name="height">The height offset for the rays.</param>
        /// <param name="horizontal">The horizontal shift for the side rays.</param>
        /// <param name="mask">The mask for what layers should the rays hit.</param>
        /// <param name="weight">The weight of this movement.</param>
        public KaijuObstacleAvoidanceMovement([NotNull] KaijuAgent agent, float avoidance = 2, float distance = 5, float sideDistance = 0,float angle = 15, float height = 1, float horizontal = 0, LayerMask? mask = null, float weight = 1) : base(agent, weight)
        {
            Initialize(agent, avoidance, distance, sideDistance, angle, height, horizontal, mask, weight);
        }
        
        /// <summary>
        /// Initialize the movement.
        /// </summary>
        /// <param name="agent">The agent this is assigned to.</param>
        /// <param name="avoidance">The distance from a wall the agent should maintain.</param>
        /// <param name="distance">The distance for rays.</param>
        /// <param name="sideDistance">The distance of the side rays. Zero or less will use the <see cref="Distance"/>.</param>
        /// <param name="angle">The angle for side rays.</param>
        /// <param name="height">The height offset for the rays.</param>
        /// <param name="horizontal">The horizontal shift for the side rays.</param>
        /// <param name="mask">The mask for what layers should the rays hit.</param>
        /// <param name="weight">The weight of this movement.</param>
        protected void Initialize([NotNull] KaijuAgent agent, float avoidance = 2, float distance = 5, float sideDistance = 0,float angle = 15, float height = 1, float horizontal = 0, LayerMask? mask = null, float weight = 1)
        {
            base.Initialize(agent, weight);
            Avoidance = avoidance;
            Distance = distance;
            SideDistance = sideDistance;
            Angle = angle;
            Height = height;
            Horizontal = horizontal;
            Mask = mask;
        }
        
        /// <summary>
        /// Perform any needed reset operations.
        /// </summary>
        protected override void Reset()
        {
            base.Reset();
            _avoidance = 0;
            _distance = 0;
            _sideDistance = 0;
            Angle = 0;
            Height = 0;
            Horizontal = 0;
            Mask = null;
            _hits.Clear();
        }
        
        /// <summary>
        /// Get the movement.
        /// </summary>
        /// <param name="position">The position of the <see cref="KaijuMovement.Agent"/>.</param>
        /// <param name="delta">The time step.</param>
        /// <returns>The calculated movement.</returns>
        public override Vector2 Move(Vector2 position, float delta)
        {
            _hits.Clear();
            
            // Get the starting ray position.
            Vector3 start = Agent.Position3 + new Vector3(0, Height, 0);
            Vector3 velocity = Agent.Velocity3;
            
            // Cast the central ray.
            Raycast(start, velocity, Distance);
            
            // Cast side rays as long as they are different from the main ray.
            if (Angle != 0 || Horizontal != 0)
            {
                // Get how far to cast the side rays.
                float side = SideDistance;
                // TODO - Fire each of the side raycasts.
                //  These must be offset along the agent's local X axis by the "Horizontal" value.
                //  As there are two side rays, one ray is offset by "Horizontal" positive and the other negative.
                //  The rays must also have their corresponding "Angle" offset applied.
                //  These are applied relatively to the above "velocity" variable which is the agent's direction, offsetting along the horizontal axis.
                //  Again, one has the positive value of "Angle" and the other has the negative value.
            }
            
            // Process all hits.
            Vector2 movement = Vector2.zero;
            foreach (RaycastHit hit in _hits)
            {
                // Calculate from the wall where to move.
                Vector3 v = hit.point + hit.normal * Avoidance;
                
                // Perform a seek.
                movement += (new Vector2(v.x, v.z) - position).normalized * Agent.MoveSpeed;
            }
            
            return movement;
        }
#if UNITY_EDITOR
        /// <summary>
        /// Get the color for visualizations.
        /// </summary>
        /// <returns>The color for visualizations</returns>
        protected override Color VisualizationColor() => KaijuMovementManager.SeparationColor;
        
        /// <summary>
        /// Render the visualization of the movement.
        /// </summary>
        protected override void RenderVisualizations()
        {
            // TODO - Visualize the rays.
        }
#endif
        /// <summary>
        /// Perform a raycast.
        /// </summary>
        /// <param name="start">The starting position of the ray.</param>
        /// <param name="direction">The direction of the ray.</param>
        /// <param name="distance">The distance of the ray.</param>
        private void Raycast(Vector3 start, Vector3 direction, float distance)
        {
            if (Mask.HasValue ? Physics.Raycast(start, direction, out RaycastHit hit, distance, Mask.Value) : Physics.Raycast(start, direction, out hit, distance))
            {
                _hits.Add(hit);
            }
        }
    }
}