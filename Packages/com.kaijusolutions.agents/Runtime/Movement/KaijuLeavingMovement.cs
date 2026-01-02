using System.Diagnostics.CodeAnalysis;
using KaijuSolutions.Agents.Extensions;
using UnityEngine;

namespace KaijuSolutions.Agents.Movement
{
    /// <summary>
    /// Base movement class for moving away from a single target.
    /// </summary>
    public abstract class KaijuLeavingMovement : KaijuTargetMovement
    {
        /// <summary>
        /// Create a leaving movement for a <see href="https://docs.unity3d.com/ScriptReference/Vector2.html">Vector2</see>.
        /// </summary>
        /// <param name="agent">The <see cref="KaijuAgent"/> this is assigned to.</param>
        /// <param name="target">The vector to move away from.</param>
        /// <param name="distance">The distance to consider this move done.</param>
        /// <param name="weight">The weight of this <see cref="KaijuMovement"/>.</param>
        public KaijuLeavingMovement([NotNull] KaijuAgent agent, Vector2 target, float distance = 20, float weight = 1) : base(agent, target, distance, weight) { }
        
        /// <summary>
        /// Create a leaving movement for a <see href="https://docs.unity3d.com/ScriptReference/Vector3.html">Vector3</see>.
        /// </summary>
        /// <param name="agent">The <see cref="KaijuAgent"/> this is assigned to.</param>
        /// <param name="target">The vector to move away from.</param>
        /// <param name="distance">The distance to consider this move done.</param>
        /// <param name="weight">The weight of this <see cref="KaijuMovement"/>.</param>
        public KaijuLeavingMovement([NotNull] KaijuAgent agent, Vector3 target, float distance = 20, float weight = 1) : base(agent, target, distance, weight) { }
        
        /// <summary>
        /// Create a leaving movement for a <see href="https://docs.unity3d.com/Manual/class-GameObject.html">GameObject</see>.
        /// </summary>
        /// <param name="agent">The <see cref="KaijuAgent"/> this is assigned to.</param>
        /// <param name="target">The <see href="https://docs.unity3d.com/Manual/class-GameObject.html">GameObject</see> to move away from.</param>
        /// <param name="distance">The distance to consider this move done.</param>
        /// <param name="weight">The weight of this <see cref="KaijuMovement"/>.</param>
        public KaijuLeavingMovement([NotNull] KaijuAgent agent, [NotNull] GameObject target, float distance = 20, float weight = 1) : base(agent, target, distance, weight) { }
        
        /// <summary>
        /// Create a leaving movement for a <see href="https://docs.unity3d.com/Manual/Components.html">component</see>.
        /// </summary>
        /// <param name="agent">The <see cref="KaijuAgent"/> this is assigned to.</param>
        /// <param name="target">The <see href="https://docs.unity3d.com/Manual/Components.html">component</see> to move away from.</param>
        /// <param name="distance">The distance to consider this move done.</param>
        /// <param name="weight">The weight of this <see cref="KaijuMovement"/>.</param>
        public KaijuLeavingMovement([NotNull] KaijuAgent agent, [NotNull] Component target, float distance = 20, float weight = 1) : base(agent, target, distance, weight) { }
        
        /// <summary>
        /// Determine if the <see cref="KaijuMovement"/> is done or not.
        /// </summary>
        /// <returns>If the <see cref="KaijuMovement"/> is done or not.</returns>
        public override bool Done()
        {
            return base.Done() || Agent.Position.Beyond(Target, Distance);
        }
        
        /// <summary>
        /// Get a description of the object.
        /// </summary>
        /// <returns>A description of the object.</returns>
        public override string ToString()
        {
            return $"Kaiju Leaving Movement - Agent: {(Agent ? Agent.name : "None")} - Target: {Target.ToString()} - Distance: {Distance} - Current Distance: {CurrentDistance} - Weight: {Weight} - {(Done() ? "Done" : "Executing")}";
        }
    }
}