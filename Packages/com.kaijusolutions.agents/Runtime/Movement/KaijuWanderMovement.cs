using System;
using System.Diagnostics.CodeAnalysis;
using UnityEditor;
using UnityEngine;
using Random = UnityEngine.Random;

namespace KaijuSolutions.Agents.Movement
{
    /// <summary>
    /// Wander steering behaviour.
    /// </summary>
    public class KaijuWanderMovement : KaijuMovement
    {
        /// <summary>
        /// How far out to generate the wander circle.
        /// </summary>
        public float Distance
        {
            get => _distance;
            set => _distance = Mathf.Max(value, 0);
        }
        
        /// <summary>
        /// How far out to generate the wander circle.
        /// </summary>
        private float _distance;
        
        /// <summary>
        /// The radius of the wander circle.
        /// </summary>
        public float Radius
        {
            get => _radius;
            set => _radius = Mathf.Max(value, 0);
        }
        
        /// <summary>
        /// The radius of the wander circle.
        /// </summary>
        private float _radius;
        
        /// <summary>
        /// The center point of the circle.
        /// </summary>
        public Vector2 Center { get; private set; }
        
        /// <summary>
        /// The center point of the circle.
        /// </summary>
        public Vector3 Center3 => new(Center.x, 0, Center.y);
        
        /// <summary>
        /// The target calculated along the circle.
        /// </summary>
        public Vector2 Target  { get; private set; }
        
        /// <summary>
        /// The target calculated along the circle.
        /// </summary>
        public Vector3 Target3 =>  new(Target.x, 0, Target.y);
#if UNITY_EDITOR
        /// <summary>
        /// Points to render.
        /// </summary>
        private readonly Vector3[] _rendering = new Vector3[6];
        
        /// <summary>
        /// The rendering index point.
        /// </summary>
        private int _index;
#endif
        /// <summary>
        /// Get a wander movement.
        /// </summary>
        /// <param name="agent">The <see cref="KaijuAgent"/> this will be assigned to.</param>
        /// <param name="distance">How far out to generate the wander circle.</param>
        /// <param name="radius">The radius of the wander circle.</param>
        /// <param name="weight">The weight of this movement.</param>
        /// <returns>Get a seek movement for the agent.</returns>
        public static KaijuWanderMovement Get([NotNull] KaijuAgent agent, float distance = 5, float radius = 1, float weight = 1)
        {
            KaijuWanderMovement movement = KaijuMovementManager.Get<KaijuWanderMovement>();
            if (movement == null)
            {
                return new(agent, distance, radius, weight);
            }
            
            movement.Initialize(agent, weight);
            movement.Configure(agent, distance, radius);
            return movement;
        }
        
        /// <summary>
        /// Create a wonder movement.
        /// </summary>
        /// <param name="agent">The agent this is assigned to.</param>
        /// <param name="distance">How far out to generate the wander circle.</param>
        /// <param name="radius">The radius of the wander circle.</param>
        /// <param name="weight">The weight of this movement.</param>
        public KaijuWanderMovement([NotNull] KaijuAgent agent, float distance = 5, float radius = 1, float weight = 1) : base(agent, weight)
        {
            Configure(agent, distance, radius);
        }
        
        /// <summary>
        /// Configure the initial distance and radius.
        /// <param name="agent">The agent this is assigned to.</param>
        /// <param name="distance">How far out to generate the wander circle.</param>
        /// <param name="radius">The radius of the wander circle.</param>
        /// </summary>
        private void Configure([NotNull] KaijuAgent agent, float distance = 5, float radius = 1)
        {
            if (distance <= 0 && radius <= 0)
            {
                radius = 1;
                Debug.LogWarning("Kaiju Wander Movement - Distance and radius both zero; setting radius to one so movement occurs.", agent);
            }
            
            Distance = distance;
            Radius = radius;
        }
        
        /// <summary>
        /// Handle any additional setup.
        /// </summary>
        protected override void Setup()
        {
            Vector2 a = Agent;
            Center = a;
            Target = a;
#if UNITY_EDITOR
            _index = 0;
#endif
        }
        
        /// <summary>
        /// Perform any needed reset operations.
        /// </summary>
        protected override void Reset()
        {
            base.Reset();
            Center = Vector2.zero;
            Target = Vector2.zero;
#if UNITY_EDITOR
            _index = 0;
#endif
        }
        
        /// <summary>
        /// Get the movement.
        /// </summary>
        /// <param name="delta">The time step.</param>
        /// <returns>The calculated movement.</returns>
        public override Vector2 Move(float delta)
        {
            Vector2 position = Agent;
            
            // Get the center of the circle.
            Center = Agent.Velocity.normalized * _distance + position;
            
            // Get a random angle in Radians (0 to 2PI).
            float angle = Random.Range(0f, Mathf.PI * 2);
            
            // Calculate x and y offsets.
            Target = Center + new Vector2(Mathf.Cos(angle) * _radius, Mathf.Sin(angle) * _radius);
            
            // Perform a seek towards the random target.
            return (Target - position).normalized * Agent.MoveSpeed - Agent.Velocity;
        }
#if UNITY_EDITOR
        /// <summary>
        /// Get the color for visualizations.
        /// </summary>
        /// <returns>The color for visualizations</returns>
        protected override Color VisualizationColor() => KaijuMovementManager.WanderColor;
        
        /// <summary>
        /// Render the visualization of the movement.
        /// </summary>
        /// <param name="text">If text elements should be visualized or not.</param>
        protected override void RenderVisualizations(bool text = true)
        {
            // Cache rendering positions.
            Vector3 a = Agent;
            Vector3 c = Center3;
            Vector3 t = Target3;
            
            // Reset the index.
            _index = 0;
            
            // Don't draw points that are equal to each other.
            if (a != c)
            {
                Insert(a, c);
            }
            
            if (a != t)
            {
                Insert(a, t);
            }
            
            if (c != t)
            {
                Insert(c, t);
            }
            
            // Draw the points.
            Gizmos.DrawLineList(new ArraySegment<Vector3>(_rendering, 0, _index));
            
            // Draw the circle itself.
            Color color = VisualizationColor();
            if (_radius > 0)
            {
                Handles.color = color;
                Handles.DrawWireDisc(c, Vector3.up, _radius, 0);
            }
            
            // Add the label.
            if (text)
            {
                KaijuAgentsManager.Label(t, "Wander", color);
            }
        }
        
        /// <summary>
        /// Insert a line into the rendering array.
        /// </summary>
        /// <param name="a">The first point.</param>
        /// <param name="b">The second point.</param>
        private void Insert(Vector3 a, Vector3 b)
        {
            Insert(a);
            Insert(b);
        }
        
        /// <summary>
        /// Insert a point into the rendering array.
        /// </summary>
        /// <param name="point">The point to insert.</param>
        private void Insert(Vector3 point)
        {
            _rendering[_index++] = point;
        }
#endif
        /// <summary>
        /// Get a description of the object.
        /// </summary>
        /// <returns>A description of the object.</returns>
        public override string ToString()
        {
            return $"Kaiju Wander Movement - Agent: {(Agent ? Agent.name : "None")} - Distance: {Distance} - Radius: {Radius} - Weight: {Weight} - {(Done() ? "Done" : "Executing")}";
        }
    }
}