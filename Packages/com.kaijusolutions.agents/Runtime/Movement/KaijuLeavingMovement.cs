using UnityEngine;

namespace KaijuSolutions.Agents.Movement
{
    /// <summary>
    /// Base movement class for moving away from a single target.
    /// </summary>
    public abstract class KaijuLeavingMovement : KaijuTargetMovement
    {
        /// <summary>
        /// Create a leaving movement for a Vector2.
        /// </summary>
        /// <param name="agent">The agent this is assigned to.</param>
        /// <param name="target">The vector to move away from.</param>
        /// <param name="distance">The distance to consider this move done.</param>
        public KaijuLeavingMovement(KaijuAgent agent, Vector2 target, float distance = 0) : base(agent, target, distance) { }
        
        /// <summary>
        /// Create a leaving movement for a Vector3.
        /// </summary>
        /// <param name="agent">The agent this is assigned to.</param>
        /// <param name="target">The vector to move away from.</param>
        /// <param name="distance">The distance to consider this move done.</param>
        public KaijuLeavingMovement(KaijuAgent agent, Vector3 target, float distance = 0) : base(agent, target, distance) { }
        
        /// <summary>
        /// Create a leaving movement for a <see href="https://docs.unity3d.com/Manual/class-Transform.html">transform</see>.
        /// </summary>
        /// <param name="agent">The agent this is assigned to.</param>
        /// <param name="target">The <see href="https://docs.unity3d.com/Manual/class-Transform.html">transform</see> to move away from.</param>
        /// <param name="distance">The distance to consider this move done.</param>
        public KaijuLeavingMovement(KaijuAgent agent, Transform target, float distance = 0) : base(agent, target, distance) { }
        
        /// <summary>
        /// Create a leaving movement for a <see href="https://docs.unity3d.com/Manual/class-GameObject.html">GameObject</see>.
        /// </summary>
        /// <param name="agent">The agent this is assigned to.</param>
        /// <param name="target">The <see href="https://docs.unity3d.com/Manual/class-GameObject.html">GameObject</see> to move away from.</param>
        /// <param name="distance">The distance to consider this move done.</param>
        public KaijuLeavingMovement(KaijuAgent agent, GameObject target, float distance = 0) : base(agent, target, distance) { }
        
        /// <summary>
        /// Create a leaving movement for a component.
        /// </summary>
        /// <param name="agent">The agent this is assigned to.</param>
        /// <param name="target">The component to move away from.</param>
        /// <param name="distance">The distance to consider this move done.</param>
        public KaijuLeavingMovement(KaijuAgent agent, Component target, float distance = 0) : base(agent, target, distance) { }
        
        /// <summary>
        /// Determine if the movement is done or not.
        /// </summary>
        /// <returns>If the movement is done or not.</returns>
        public override bool Done()
        {
            return base.Done() || CurrentDistance >= Distance;
        }
        
        /// <summary>
        /// Get a description of the object.
        /// </summary>
        /// <returns>A description of the object.</returns>
        public override string ToString()
        {
            Vector2? t = Target;
            return $"Kaiju Leaving Movement - Agent: {(Agent ? Agent.name : "None")} - Target: {(t.HasValue ? t.Value.ToString() : "None")} - Distance: {Distance} - Current Distance: {CurrentDistance} - {(Done() ? "Done" : "Executing")}";
        }
    }
}