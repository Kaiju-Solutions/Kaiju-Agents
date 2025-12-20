using System.Diagnostics.CodeAnalysis;
using UnityEngine;

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
        /// Create an evade movement.
        /// </summary>
        /// <param name="agent">The agent this is assigned to.</param>
        /// <param name="target">The position to evade from.</param>
        /// <param name="distance">The distance from the target to consider this movement done.</param>
        /// <param name="weight">The weight of this movement.</param>
        public KaijuEvadeMovement([NotNull] KaijuAgent agent, Vector2 target, float distance = 0, float weight = 1) : base(agent, target, distance, weight)
        {
            Previous = target;
        }
        
        /// <summary>
        /// Create an evade movement.
        /// </summary>
        /// <param name="agent">The agent this is assigned to.</param>
        /// <param name="target">The position to evade from.</param>
        /// <param name="distance">The distance from the target to consider this movement done.</param>
        /// <param name="weight">The weight of this movement.</param>
        public KaijuEvadeMovement([NotNull] KaijuAgent agent, Vector3 target, float distance = 0, float weight = 1) : base(agent, target, distance, weight)
        {
            Previous = new(target.x, target.z);
        }
        
        /// <summary>
        /// Create an evade movement.
        /// </summary>
        /// <param name="agent">The agent this is assigned to.</param>
        /// <param name="target">The <see href="https://docs.unity3d.com/Manual/class-GameObject.html">GameObject</see> to evade from.</param>
        /// <param name="distance">The distance from the target to consider this movement done.</param>
        /// <param name="weight">The weight of this movement.</param>
        public KaijuEvadeMovement([NotNull] KaijuAgent agent, [NotNull] GameObject target, float distance = 0, float weight = 1) : base(agent, target, distance, weight)
        {
            Vector3 p = target.transform.position;
            Previous = new(p.x, p.z);
        }
        
        /// <summary>
        /// Create an evade movement.
        /// </summary>
        /// <param name="agent">The agent this is assigned to.</param>
        /// <param name="target">The component to evade from.</param>
        /// <param name="distance">The distance from the target to consider this movement done.</param>
        /// <param name="weight">The weight of this movement.</param>
        public KaijuEvadeMovement([NotNull] KaijuAgent agent, [NotNull] Component target, float distance = 0, float weight = 1) : base(agent, target, distance, weight)
        {
            Vector3 p = target.transform.position;
            Previous = new(p.x, p.z);
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
            
            // Flee predicting the target.
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
            return $"Kaiju Evade Movement - Agent: {(Agent ? Agent.name : "None")} - Target: {(t.HasValue ? t.Value.ToString() : "None")} - Distance: {Distance} - Current Distance: {CurrentDistance} - Previous: {Previous} - {(Done() ? "Done" : "Executing")}";
        }
    }
}