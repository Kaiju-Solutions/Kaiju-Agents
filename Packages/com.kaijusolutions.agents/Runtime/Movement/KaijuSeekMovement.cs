using System.Diagnostics.CodeAnalysis;
using KaijuSolutions.Agents.Extensions;
using UnityEngine;

namespace KaijuSolutions.Agents.Movement
{
    /// <summary>
    /// Seek steering behaviour.
    /// </summary>
    public class KaijuSeekMovement : KaijuApproachingMovement
    {
        /// <summary>
        /// Get a <see cref="KaijuSeekMovement"/>.
        /// </summary>
        /// <param name="agent">The <see cref="KaijuAgent"/> this will be assigned to.</param>
        /// <param name="target">The target.</param>
        /// <param name="distance">At what distance from the target should the seek be considered successful.</param>
        /// <param name="weight">The weight of this <see cref="KaijuMovement"/>.</param>
        /// <returns>Get a <see cref="KaijuSeekMovement"/> for the <see cref="KaijuAgent"/>.</returns>
        public static KaijuSeekMovement Get([NotNull] KaijuAgent agent, Vector2 target, float distance = 0.1f, float weight = 1)
        {
            KaijuSeekMovement movement = KaijuMovementManager.Get<KaijuSeekMovement>();
            if (movement == null)
            {
                return new(agent, target, distance, weight);
            }
            
            movement.Initialize(agent, target, distance, weight);
            return movement;
        }
        
        /// <summary>
        /// Get a <see cref="KaijuSeekMovement"/>.
        /// </summary>
        /// <param name="agent">The <see cref="KaijuAgent"/> this will be assigned to.</param>
        /// <param name="target">The target.</param>
        /// <param name="distance">At what distance from the target should the seek be considered successful.</param>
        /// <param name="weight">The weight of this <see cref="KaijuMovement"/>.</param>
        /// <returns>Get a <see cref="KaijuSeekMovement"/> for the <see cref="KaijuAgent"/>.</returns>
        public static KaijuSeekMovement Get([NotNull] KaijuAgent agent, Vector3 target, float distance = 0.1f, float weight = 1)
        {
            KaijuSeekMovement movement = KaijuMovementManager.Get<KaijuSeekMovement>();
            if (movement == null)
            {
                return new(agent, target, distance, weight);
            }
            
            movement.Initialize(agent, target, distance, weight);
            return movement;
        }
        
        /// <summary>
        /// Get a <see cref="KaijuSeekMovement"/>.
        /// </summary>
        /// <param name="agent">The <see cref="KaijuAgent"/> this will be assigned to.</param>
        /// <param name="target">The target.</param>
        /// <param name="distance">At what distance from the target should the seek be considered successful.</param>
        /// <param name="weight">The weight of this <see cref="KaijuMovement"/>.</param>
        /// <returns>Get a <see cref="KaijuSeekMovement"/> for the <see cref="KaijuAgent"/>.</returns>
        public static KaijuSeekMovement Get([NotNull] KaijuAgent agent, [NotNull] GameObject target, float distance = 0.1f, float weight = 1)
        {
            KaijuSeekMovement movement = KaijuMovementManager.Get<KaijuSeekMovement>();
            if (movement == null)
            {
                return new(agent, target, distance, weight);
            }
            
            movement.Initialize(agent, target, distance, weight);
            return movement;
        }
        
        /// <summary>
        /// Get a <see cref="KaijuSeekMovement"/>.
        /// </summary>
        /// <param name="agent">The <see cref="KaijuAgent"/> this will be assigned to.</param>
        /// <param name="target">The target.</param>
        /// <param name="distance">At what distance from the target should the seek be considered successful.</param>
        /// <param name="weight">The weight of this <see cref="KaijuMovement"/>.</param>
        /// <returns>Get a <see cref="KaijuSeekMovement"/> for the <see cref="KaijuAgent"/>.</returns>
        public static KaijuSeekMovement Get([NotNull] KaijuAgent agent, [NotNull] Component target, float distance = 0.1f, float weight = 1)
        {
            KaijuSeekMovement movement = KaijuMovementManager.Get<KaijuSeekMovement>();
            if (movement == null)
            {
                return new(agent, target, distance, weight);
            }
            
            movement.Initialize(agent, target, distance, weight);
            return movement;
        }
        
        /// <summary>
        /// Create a <see cref="KaijuSeekMovement"/>.
        /// </summary>
        /// <param name="agent">The <see cref="KaijuAgent"/> this is assigned to.</param>
        /// <param name="target">The position to seek to.</param>
        /// <param name="distance">The distance from the target to consider this movement done.</param>
        /// <param name="weight">The weight of this <see cref="KaijuMovement"/>.</param>
        public KaijuSeekMovement([NotNull] KaijuAgent agent, Vector2 target, float distance = 0.1f, float weight = 1) : base(agent, target, distance, weight) { }
        
        /// <summary>
        /// Create a <see cref="KaijuSeekMovement"/>.
        /// </summary>
        /// <param name="agent">The <see cref="KaijuAgent"/> this is assigned to.</param>
        /// <param name="target">The position to seek to.</param>
        /// <param name="distance">The distance from the target to consider this movement done.</param>
        /// <param name="weight">The weight of this <see cref="KaijuMovement"/>.</param>
        public KaijuSeekMovement([NotNull] KaijuAgent agent, Vector3 target, float distance = 0.1f, float weight = 1) : base(agent, target, distance, weight) { }
        
        /// <summary>
        /// Create a <see cref="KaijuSeekMovement"/>.
        /// </summary>
        /// <param name="agent">The <see cref="KaijuAgent"/> this is assigned to.</param>
        /// <param name="target">The <see href="https://docs.unity3d.com/Manual/class-GameObject.html">GameObject</see> to seek to.</param>
        /// <param name="distance">The distance from the target to consider this movement done.</param>
        /// <param name="weight">The weight of this <see cref="KaijuMovement"/>.</param>
        public KaijuSeekMovement([NotNull] KaijuAgent agent, [NotNull] GameObject target, float distance = 0.1f, float weight = 1) : base(agent, target, distance, weight) { }
        
        /// <summary>
        /// Create a <see cref="KaijuSeekMovement"/>.
        /// </summary>
        /// <param name="agent">The <see cref="KaijuAgent"/> this is assigned to.</param>
        /// <param name="target">The <see href="https://docs.unity3d.com/Manual/Components.html">component</see> to seek to.</param>
        /// <param name="distance">The distance from the target to consider this movement done.</param>
        /// <param name="weight">The weight of this <see cref="KaijuMovement"/>.</param>
        public KaijuSeekMovement([NotNull] KaijuAgent agent, [NotNull] Component target, float distance = 0.1f, float weight = 1) : base(agent, target, distance, weight) { }
        
        /// <summary>
        /// Calculate the movement.
        /// </summary>
        /// <param name="position">The <see cref="KaijuAgent"/>'s current position.</param>
        /// <param name="speed">The <see cref="KaijuAgent"/>'s maximum movement speed.</param>
        /// <param name="target">The position to move in relation to.</param>
        /// <param name="delta">The time step.</param>
        /// <returns>The calculated move vector.</returns>
        protected override Vector2 Calculate(Vector2 position, float speed, Vector2 target, float delta)
        {
            return position.Seek(target, speed);
        }
#if UNITY_EDITOR
        /// <summary>
        /// Get the color for visualizations.
        /// </summary>
        /// <returns>The color for visualizations</returns>
        protected override Color EditorVisualizationColor() =>  KaijuMovementManager.EditorSeekColor;
#endif
        /// <summary>
        /// Get a description of the object.
        /// </summary>
        /// <returns>A description of the object.</returns>
        public override string ToString()
        {
            return $"Kaiju Seek Movement - Agent: {(Agent ? Agent.name : "None")} - Target: {Target.ToString()} - Distance: {Distance} - Current Distance: {CurrentDistance} - Weight: {Weight} - {(Done() ? "Done" : "Executing")}";
        }
    }
}