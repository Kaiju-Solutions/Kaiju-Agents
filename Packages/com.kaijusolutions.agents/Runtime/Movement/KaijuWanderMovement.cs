using System.Diagnostics.CodeAnalysis;
using KaijuSolutions.Agents.Extensions;
using UnityEngine;
using Random = UnityEngine.Random;
#if UNITY_EDITOR
using UnityEditor;
#endif
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
        public Vector3 Center3 => Center.Expand();
        
        /// <summary>
        /// The target calculated along the circle.
        /// </summary>
        public Vector2 Target  { get; private set; }
        
        /// <summary>
        /// The target calculated along the circle.
        /// </summary>
        public Vector3 Target3 =>  Target.Expand();
        
        /// <summary>
        /// Get a <see cref="KaijuWanderMovement"/>.
        /// </summary>
        /// <param name="agent">The <see cref="KaijuAgent"/> this will be assigned to.</param>
        /// <param name="distance">How far out to generate the wander circle.</param>
        /// <param name="radius">The radius of the wander circle.</param>
        /// <param name="weight">The weight of this <see cref="KaijuMovement"/>.</param>
        /// <returns>Get a <see cref="KaijuWanderMovement"/> for the <see cref="KaijuAgent"/>.</returns>
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
        /// <param name="agent">The <see cref="KaijuAgent"/> this is assigned to.</param>
        /// <param name="distance">How far out to generate the wander circle.</param>
        /// <param name="radius">The radius of the wander circle.</param>
        /// <param name="weight">The weight of this <see cref="KaijuMovement"/>.</param>
        public KaijuWanderMovement([NotNull] KaijuAgent agent, float distance = 5, float radius = 1, float weight = 1) : base(agent, weight)
        {
            Configure(agent, distance, radius);
        }
        
        /// <summary>
        /// Configure the initial distance and radius.
        /// <param name="agent">The <see cref="KaijuAgent"/> this is assigned to.</param>
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
        }
        
        /// <summary>
        /// Perform any needed reset operations.
        /// </summary>
        protected override void Reset()
        {
            base.Reset();
            Center = Vector2.zero;
            Target = Vector2.zero;
        }
        
        /// <summary>
        /// Get the <see cref="KaijuMovement"/>.
        /// </summary>
        /// <param name="position">The position of the <see cref="KaijuMovement.Agent"/>.</param>
        /// <param name="delta">The time step.</param>
        /// <returns>The calculated move vector.</returns>
        public override Vector2 Move(Vector2 position, float delta)
        {
            // Get the center of the circle.
            Center = Agent.Velocity.normalized * _distance + position;
            
            // Get a random angle in Radians (0 to 2PI).
            float angle = Random.Range(0f, Mathf.PI * 2);
            
            // Calculate x and y offsets.
            Target = Center + new Vector2(Mathf.Cos(angle) * _radius, Mathf.Sin(angle) * _radius);
            
            // Perform a seek towards the random target.
            return position.Seek(Target, Agent.MoveSpeed);
        }
#if UNITY_EDITOR
        /// <summary>
        /// Get the color for visualizations.
        /// </summary>
        /// <returns>The color for visualizations</returns>
        protected override Color EditorVisualizationColor() => KaijuMovementManager.EditorWanderColor;
        
        /// <summary>
        /// Render the visualization of the <see cref="KaijuMovement"/>.
        /// <param name="position">The position of the <see cref="KaijuMovement.Agent"/>.</param>
        /// </summary>
        protected override void EditorRenderVisualizations(Vector3 position)
        {
            // Cache rendering positions.
            Vector3 a = Agent;
            Vector3 c = Center3;
            Vector3 t = Target3;
            
            // Don't draw points that are equal to each other.
            if (a != c)
            {
                Handles.DrawLine(a, c);
            }
            
            if (a != t)
            {
                Handles.DrawLine(a, t);
            }
            
            if (c != t)
            {
                Handles.DrawLine(c, t);
            }
            
            // Draw the circle itself.
            if (_radius > 0)
            {
                Handles.DrawWireDisc(c, Vector3.up, _radius, 0);
            }
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