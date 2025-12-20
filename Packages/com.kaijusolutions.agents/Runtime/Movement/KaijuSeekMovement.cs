using UnityEngine;

namespace KaijuSolutions.Agents.Movement
{
    /// <summary>
    /// Seek steering behaviour.
    /// </summary>
    public class KaijuSeekMovement : KaijuApproachingMovement
    {
        /// <summary>
        /// Create a seek movement.
        /// </summary>
        /// <param name="agent">The agent this is assigned to.</param>
        /// <param name="target">The position to seek to.</param>
        /// <param name="distance">The distance from the target to consider this movement done.</param>
        public KaijuSeekMovement(KaijuAgent agent, Vector2 target, float distance = 0) : base(agent, target, distance) { }
        
        /// <summary>
        /// Create a seek movement.
        /// </summary>
        /// <param name="agent">The agent this is assigned to.</param>
        /// <param name="target">The position to seek to.</param>
        /// <param name="distance">The distance from the target to consider this movement done.</param>
        public KaijuSeekMovement(KaijuAgent agent, Vector3 target, float distance = 0) : base(agent, target, distance) { }
        
        /// <summary>
        /// Create a seek movement.
        /// </summary>
        /// <param name="agent">The agent this is assigned to.</param>
        /// <param name="target">The <see href="https://docs.unity3d.com/Manual/class-Transform.html">transform</see> to seek to.</param>
        /// <param name="distance">The distance from the target to consider this movement done.</param>
        public KaijuSeekMovement(KaijuAgent agent, Transform target, float distance = 0) : base(agent, target, distance) { }
        
        /// <summary>
        /// Create a seek movement.
        /// </summary>
        /// <param name="agent">The agent this is assigned to.</param>
        /// <param name="target">The <see href="https://docs.unity3d.com/Manual/class-GameObject.html">GameObject</see> to seek to.</param>
        /// <param name="distance">The distance from the target to consider this movement done.</param>
        public KaijuSeekMovement(KaijuAgent agent, GameObject target, float distance = 0) : base(agent, target, distance) { }
        
        /// <summary>
        /// Create a seek movement.
        /// </summary>
        /// <param name="agent">The agent this is assigned to.</param>
        /// <param name="target">The component to seek to.</param>
        /// <param name="distance">The distance from the target to consider this movement done.</param>
        public KaijuSeekMovement(KaijuAgent agent, Component target, float distance = 0) : base(agent, target, distance) { }
        
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
            return (target - position).normalized * speed - velocity;
        }
        
        /// <summary>
        /// Get a description of the object.
        /// </summary>
        /// <returns>A description of the object.</returns>
        public override string ToString()
        {
            Vector2? t = Target;
            return $"Kaiju Seek Movement - Agent: {(Agent ? Agent.name : "None")} - Target: {(t.HasValue ? t.Value.ToString() : "None")} - Distance: {Distance} - Current Distance: {CurrentDistance} - {(Done() ? "Done" : "Executing")}";
        }
    }
}