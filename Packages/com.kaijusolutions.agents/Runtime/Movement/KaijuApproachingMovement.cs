using System.Diagnostics.CodeAnalysis;
using UnityEngine;

namespace KaijuSolutions.Agents.Movement
{
    /// <summary>
    /// Base movement class for moving towards a single target.
    /// </summary>
    public abstract class KaijuApproachingMovement : KaijuTargetMovement
    {
        /// <summary>
        /// Create an approach movement for a Vector2.
        /// </summary>
        /// <param name="agent">The agent this is assigned to.</param>
        /// <param name="target">The vector to move towards.</param>
        /// <param name="distance">The distance to consider this move done.</param>
        /// <param name="weight">The weight of this movement.</param>
        public KaijuApproachingMovement([NotNull] KaijuAgent agent, Vector2 target, float distance = 0, float weight = 1) : base(agent, target, distance, weight) { }
        
        /// <summary>
        /// Create an approach movement for a Vector3.
        /// </summary>
        /// <param name="agent">The agent this is assigned to.</param>
        /// <param name="target">The vector to move towards.</param>
        /// <param name="distance">The distance to consider this move done.</param>
        /// <param name="weight">The weight of this movement.</param>
        public KaijuApproachingMovement([NotNull] KaijuAgent agent, Vector3 target, float distance = 0, float weight = 1) : base(agent, target, distance, weight) { }
        
        /// <summary>
        /// Create an approach movement for a <see href="https://docs.unity3d.com/Manual/class-GameObject.html">GameObject</see>.
        /// </summary>
        /// <param name="agent">The agent this is assigned to.</param>
        /// <param name="target">The <see href="https://docs.unity3d.com/Manual/class-GameObject.html">GameObject</see> to move towards.</param>
        /// <param name="distance">The distance to consider this move done.</param>
        /// <param name="weight">The weight of this movement.</param>
        public KaijuApproachingMovement([NotNull] KaijuAgent agent, [NotNull] GameObject target, float distance = 0, float weight = 1) : base(agent, target, distance, weight) { }
        
        /// <summary>
        /// Create an approach movement for a component.
        /// </summary>
        /// <param name="agent">The agent this is assigned to.</param>
        /// <param name="target">The component to move towards.</param>
        /// <param name="distance">The distance to consider this move done.</param>
        /// <param name="weight">The weight of this movement.</param>
        public KaijuApproachingMovement([NotNull] KaijuAgent agent, [NotNull] Component target, float distance = 0, float weight = 1) : base(agent, target, distance, weight) { }
        
        /// <summary>
        /// Determine if the movement is done or not.
        /// </summary>
        /// <returns>If the movement is done or not.</returns>
        public override bool Done()
        {
            return base.Done() || CurrentDistance <= Distance;
        }
        
        /// <summary>
        /// Get a description of the object.
        /// </summary>
        /// <returns>A description of the object.</returns>
        public override string ToString()
        {
            Vector2? t = Target;
            return $"Kaiju Approaching Movement - Agent: {(Agent ? Agent.name : "None")} - Target: {(t.HasValue ? t.Value.ToString() : "None")} - Distance: {Distance} - Current Distance: {CurrentDistance} - {(Done() ? "Done" : "Executing")}";
        }
    }
}