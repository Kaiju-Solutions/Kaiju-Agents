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
        public KaijuPursueMovement(KaijuAgent agent, Vector2 target, float distance = 0) : base(agent, target, distance)
        {
            Previous = target;
        }

        /// <summary>
        /// Create a pursue movement.
        /// </summary>
        /// <param name="agent">The agent this is assigned to.</param>
        /// <param name="target">The position to pursue to.</param>
        /// <param name="distance">The distance from the target to consider this movement done.</param>
        public KaijuPursueMovement(KaijuAgent agent, Vector3 target, float distance = 0) : base(agent, target, distance)
        {
            Previous = new(target.x, target.z);
        }

        /// <summary>
        /// Create a pursue movement.
        /// </summary>
        /// <param name="agent">The agent this is assigned to.</param>
        /// <param name="target">The transform to pursue to.</param>
        /// <param name="distance">The distance from the target to consider this movement done.</param>
        public KaijuPursueMovement(KaijuAgent agent, Transform target, float distance = 0) : base(agent, target, distance)
        {
            if (!target)
            {
                Previous = Vector2.zero;
                return;
            }
            
            Vector3 p = target.position;
            Previous = new(p.x, p.z);
        }

        /// <summary>
        /// Create a pursue movement.
        /// </summary>
        /// <param name="agent">The agent this is assigned to.</param>
        /// <param name="target">The GameObject to pursue to.</param>
        /// <param name="distance">The distance from the target to consider this movement done.</param>
        public KaijuPursueMovement(KaijuAgent agent, GameObject target, float distance = 0) : base(agent, target, distance)
        {
            if (!target)
            {
                Previous = Vector2.zero;
                return;
            }
            
            Vector3 p = target.transform.position;
            Previous = new(p.x, p.z);
        }

        /// <summary>
        /// Create a pursue movement.
        /// </summary>
        /// <param name="agent">The agent this is assigned to.</param>
        /// <param name="target">The component to pursue to.</param>
        /// <param name="distance">The distance from the target to consider this movement done.</param>
        public KaijuPursueMovement(KaijuAgent agent, Component target, float distance = 0) : base(agent, target, distance)
        {
            if (!target)
            {
                Previous = Vector2.zero;
                return;
            }
            
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
            return $"Kaiju Pursue Movement - Agent: {(Agent ? Agent.name : "None")} - Target: {(t.HasValue ? t.ToString() : "None")} - Distance: {Distance} - Current Distance: {CurrentDistance} - Previous: {Previous} - {(Done() ? "Done" : "Executing")}";
        }
    }
}