using System.Diagnostics.CodeAnalysis;
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif
namespace KaijuSolutions.Agents.Movement
{
    /// <summary>
    /// Evade steering behaviour.
    /// </summary>
    public class KaijuEvadeMovement : KaijuFleeMovement
    {
        /// <summary>
        /// The previous position of the target.
        /// </summary>
        public Vector2 Previous;
        
        /// <summary>
        /// The previous position of the target.
        /// </summary>
        public Vector3 Previous3 => new(Previous.x, 0, Previous.y);
        
        /// <summary>
        /// The predicted future target.
        /// </summary>
        public Vector2 Future { get; private set; }
        
        /// <summary>
        /// The predicted future target.
        /// </summary>
        public Vector3 Future3 => new(Future.x, 0, Future.y);
        
        /// <summary>
        /// Get an evade movement.
        /// </summary>
        /// <param name="agent">The <see cref="KaijuAgent"/> this will be assigned to.</param>
        /// <param name="target">The target.</param>
        /// <param name="distance">At what distance from the target should the evade be considered successful.</param>
        /// <param name="weight">The weight of this movement.</param>
        /// <returns>Get a seek movement for the agent.</returns>
        public new static KaijuEvadeMovement Get([NotNull] KaijuAgent agent, Vector2 target, float distance = float.MaxValue, float weight = 1)
        {
            KaijuEvadeMovement movement = KaijuMovementManager.Get<KaijuEvadeMovement>();
            if (movement == null)
            {
                return new(agent, target, distance, weight);
            }
            
            movement.Initialize(agent, target, distance, weight);
            return movement;
        }
        
        /// <summary>
        /// Get an evade movement.
        /// </summary>
        /// <param name="agent">The <see cref="KaijuAgent"/> this will be assigned to.</param>
        /// <param name="target">The target.</param>
        /// <param name="distance">At what distance from the target should the evade be considered successful.</param>
        /// <param name="weight">The weight of this movement.</param>
        /// <returns>Get a seek movement for the agent.</returns>
        public new static KaijuEvadeMovement Get([NotNull] KaijuAgent agent, Vector3 target, float distance = float.MaxValue, float weight = 1)
        {
            KaijuEvadeMovement movement = KaijuMovementManager.Get<KaijuEvadeMovement>();
            if (movement == null)
            {
                return new(agent, target, distance, weight);
            }
            
            movement.Initialize(agent, target, distance, weight);
            return movement;
        }
        
        /// <summary>
        /// Get an evade movement.
        /// </summary>
        /// <param name="agent">The <see cref="KaijuAgent"/> this will be assigned to.</param>
        /// <param name="target">The target.</param>
        /// <param name="distance">At what distance from the target should the evade be considered successful.</param>
        /// <param name="weight">The weight of this movement.</param>
        /// <returns>Get a seek movement for the agent.</returns>
        public new static KaijuEvadeMovement Get([NotNull] KaijuAgent agent, [NotNull] GameObject target, float distance = float.MaxValue, float weight = 1)
        {
            KaijuEvadeMovement movement = KaijuMovementManager.Get<KaijuEvadeMovement>();
            if (movement == null)
            {
                return new(agent, target, distance, weight);
            }
            
            movement.Initialize(agent, target, distance, weight);
            return movement;
        }
        
        /// <summary>
        /// Get an evade movement.
        /// </summary>
        /// <param name="agent">The <see cref="KaijuAgent"/> this will be assigned to.</param>
        /// <param name="target">The target.</param>
        /// <param name="distance">At what distance from the target should the evade be considered successful.</param>
        /// <param name="weight">The weight of this movement.</param>
        /// <returns>Get a seek movement for the agent.</returns>
        public new static KaijuEvadeMovement Get([NotNull] KaijuAgent agent, [NotNull] Component target, float distance = float.MaxValue, float weight = 1)
        {
            KaijuEvadeMovement movement = KaijuMovementManager.Get<KaijuEvadeMovement>();
            if (movement == null)
            {
                return new(agent, target, distance, weight);
            }
            
            movement.Initialize(agent, target, distance, weight);
            return movement;
        }
        
        /// <summary>
        /// Create an evade movement.
        /// </summary>
        /// <param name="agent">The agent this is assigned to.</param>
        /// <param name="target">The position to evade from.</param>
        /// <param name="distance">The distance from the target to consider this movement done.</param>
        /// <param name="weight">The weight of this movement.</param>
        public KaijuEvadeMovement([NotNull] KaijuAgent agent, Vector2 target, float distance = float.MaxValue, float weight = 1) : base(agent, target, distance, weight) { }
        
        /// <summary>
        /// Create an evade movement.
        /// </summary>
        /// <param name="agent">The agent this is assigned to.</param>
        /// <param name="target">The position to evade from.</param>
        /// <param name="distance">The distance from the target to consider this movement done.</param>
        /// <param name="weight">The weight of this movement.</param>
        public KaijuEvadeMovement([NotNull] KaijuAgent agent, Vector3 target, float distance = float.MaxValue, float weight = 1) : base(agent, target, distance, weight) { }
        
        /// <summary>
        /// Create an evade movement.
        /// </summary>
        /// <param name="agent">The agent this is assigned to.</param>
        /// <param name="target">The <see href="https://docs.unity3d.com/Manual/class-GameObject.html">GameObject</see> to evade from.</param>
        /// <param name="distance">The distance from the target to consider this movement done.</param>
        /// <param name="weight">The weight of this movement.</param>
        public KaijuEvadeMovement([NotNull] KaijuAgent agent, [NotNull] GameObject target, float distance = float.MaxValue, float weight = 1) : base(agent, target, distance, weight) { }
        
        /// <summary>
        /// Create an evade movement.
        /// </summary>
        /// <param name="agent">The agent this is assigned to.</param>
        /// <param name="target">The component to evade from.</param>
        /// <param name="distance">The distance from the target to consider this movement done.</param>
        /// <param name="weight">The weight of this movement.</param>
        public KaijuEvadeMovement([NotNull] KaijuAgent agent, [NotNull] Component target, float distance = float.MaxValue, float weight = 1) : base(agent, target, distance, weight) { }
        
        /// <summary>
        /// Handle any additional setup.
        /// </summary>
        protected override void Setup()
        {
            // Start the previous and future position as the current position.
            Previous = Target;
            Future = Target;
        }
        
        /// <summary>
        /// Perform any needed reset operations.
        /// </summary>
        protected override void Reset()
        {
            base.Reset();
            Previous = Vector2.zero;
            Future = Vector2.zero;
        }
        
        /// <summary>
        /// Calculate the movement.
        /// </summary>
        /// <param name="position">The agent's current position.</param>
        /// <param name="velocity">The agent's current velocity.</param>
        /// <param name="speed">The agent's maximum movement speed.</param>
        /// <param name="target">The position to move in relation to.</param>
        /// <param name="delta">The time step.</param>
        /// <returns>The calculated movement.</returns>
        protected override Vector2 Calculate(Vector2 position, Vector2 velocity, float speed, Vector2 target, float delta)
        {
            // Calculate target values.
            Vector2 targetVelocity = Velocity(target, Previous, delta);
            float targetSpeed = Speed(target, Previous, delta);
            
            // Predict where the target will be.
            Future = target + targetVelocity * ((target - position).magnitude / (speed + targetSpeed));
            
            // Flee predicting the target.
            Vector2 move = base.Calculate(position, velocity, speed, Future, delta);
            
            // Update the previous position.
            Previous = target;
            return move;
        }
#if UNITY_EDITOR
        /// <summary>
        /// Get the color for visualizations.
        /// </summary>
        /// <returns>The color for visualizations</returns>
        protected override Color VisualizationColor()
        {
            return KaijuMovementManager.EvadeColor;
        }
        
        /// <summary>
        /// Render the visualization of the movement.
        /// </summary>
        /// <param name="text">If text elements should be visualized or not.</param>
        protected override void RenderVisualizations(bool text = true)
        {
            Vector3 t = Target3;
            Vector3 a = Agent;
            Vector3 f = Future3;
            
            // Only one line to draw if equal.
            bool still = t == f;
            if (still)
            {
                Gizmos.DrawLine(a, t);
            }
            else
            {
                Gizmos.DrawLineList(new[]
                {
                    // Agent to target.
                    a,
                    t,
                    // Agent to forecast.
                    a,
                    f,
                    // Target to forecast.
                    t,
                    f
                });
            }
            
            RenderTargetVisualizationText("Evade", a, t,text);
        }
#endif
        /// <summary>
        /// Get a description of the object.
        /// </summary>
        /// <returns>A description of the object.</returns>
        public override string ToString()
        {
            Vector2? t = Target;
            return $"Kaiju Evade Movement - Agent: {(Agent ? Agent.name : "None")} - Target: {t.Value.ToString()} - Distance: {Distance} - Current Distance: {CurrentDistance} - Previous: {Previous} - Weight: {Weight} - {(Done() ? "Done" : "Executing")}";
        }
    }
}