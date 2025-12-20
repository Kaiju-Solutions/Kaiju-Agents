using System.Diagnostics.CodeAnalysis;
using UnityEngine;

namespace KaijuSolutions.Agents.Movement
{
    /// <summary>
    /// Pursue steering behaviour.
    /// </summary>
    public class KaijuPursueMovement : KaijuSeekMovement
    {
        /// <summary>
        /// The previous position of the target.
        /// </summary>
        public Vector2 Previous;
        
        /// <summary>
        /// Create a pursue movement.
        /// </summary>
        /// <param name="agent">The agent this is assigned to.</param>
        /// <param name="target">The position to pursue to.</param>
        /// <param name="distance">The distance from the target to consider this movement done.</param>
        /// <param name="weight">The weight of this movement.</param>
        public KaijuPursueMovement([NotNull] KaijuAgent agent, Vector2 target, float distance = 0, float weight = 1) : base(agent, target, distance, weight) { }
        
        /// <summary>
        /// Create a pursue movement.
        /// </summary>
        /// <param name="agent">The agent this is assigned to.</param>
        /// <param name="target">The position to pursue to.</param>
        /// <param name="distance">The distance from the target to consider this movement done.</param>
        /// <param name="weight">The weight of this movement.</param>
        public KaijuPursueMovement([NotNull] KaijuAgent agent, Vector3 target, float distance = 0, float weight = 1) : base(agent, target, distance, weight) { }

        /// <summary>
        /// Create a pursue movement.
        /// </summary>
        /// <param name="agent">The agent this is assigned to.</param>
        /// <param name="target">The GameObject to pursue to.</param>
        /// <param name="distance">The distance from the target to consider this movement done.</param>
        /// <param name="weight">The weight of this movement.</param>
        public KaijuPursueMovement([NotNull] KaijuAgent agent, [NotNull] GameObject target, float distance = 0, float weight = 1) : base(agent, target, distance, weight) { }

        /// <summary>
        /// Create a pursue movement.
        /// </summary>
        /// <param name="agent">The agent this is assigned to.</param>
        /// <param name="target">The component to pursue to.</param>
        /// <param name="distance">The distance from the target to consider this movement done.</param>
        /// <param name="weight">The weight of this movement.</param>
        public KaijuPursueMovement([NotNull] KaijuAgent agent, [NotNull] Component target, float distance = 0, float weight = 1) : base(agent, target, distance, weight) { }
        
        /// <summary>
        /// Handle any additional setup.
        /// </summary>
        protected override void Setup()
        {
            // Start the previous position as the current position.
            Previous = Target ?? Vector2.zero;
        }
        
        /// <summary>
        /// Perform any needed reset operations.
        /// </summary>
        protected override void Reset()
        {
            base.Reset();
            Previous = Vector2.zero;
        }
        
        /// <summary>
        /// Calculate the movement.
        /// </summary>
        /// <param name="position">The agent's current position.</param>
        /// <param name="velocity">The agent's current velocity.</param>
        /// <param name="speed">The agent's maximum movement speed.</param>
        /// <param name="target">The position to move in relation to.</param>
        /// <returns>The calculated movement.</returns>
        protected override Vector2 Calculate(Vector2 position, Vector2 velocity, float speed, Vector2 target)
        {
            // Calculate target values.
            VelocityAndSpeed(target, Previous, out Vector2 targetVelocity, out float targetSpeed);
            
            // Seek ahead of the target.
            Vector2 move = base.Calculate(position, velocity, speed, target + targetVelocity * ((target - position).magnitude / (speed + targetSpeed)));
            
            // Update the previous position.
            Previous = position;
            return move;
        }
        
        /// <summary>
        /// Get a description of the object.
        /// </summary>
        /// <returns>A description of the object.</returns>
        public override string ToString()
        {
            Vector2? t = Target;
            return $"Kaiju Pursue Movement - Agent: {(Agent ? Agent.name : "None")} - Target: {(t.HasValue ? t.Value.ToString() : "None")} - Distance: {Distance} - Current Distance: {CurrentDistance} - Previous: {Previous} - Weight: {Weight} - {(Done() ? "Done" : "Executing")}";
        }
    }
}