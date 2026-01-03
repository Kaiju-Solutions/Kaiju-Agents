using System.Diagnostics.CodeAnalysis;
using KaijuSolutions.Agents.Extensions;
using UnityEngine;

namespace KaijuSolutions.Agents.Movement
{
    /// <summary>
    /// Flee steering behaviour.
    /// </summary>
    public class KaijuFleeMovement : KaijuLeavingMovement
    {
        /// <summary>
        /// Get a <see cref="KaijuFleeMovement"/>.
        /// </summary>
        /// <param name="agent">The <see cref="KaijuAgent"/> this will be assigned to.</param>
        /// <param name="target">The target.</param>
        /// <param name="distance">At what distance from the target should the flee be considered successful.</param>
        /// <param name="weight">The weight of this <see cref="KaijuMovement"/>.</param>
        /// <returns>Get a <see cref="KaijuWanderMovement"/> for the <see cref="KaijuAgent"/>.</returns>
        public static KaijuFleeMovement Get([NotNull] KaijuAgent agent, Vector2 target, float distance = DefaultDistance, float weight = DefaultWeight)
        {
            KaijuFleeMovement movement = KaijuMovementManager.Get<KaijuFleeMovement>();
            if (movement == null)
            {
                return new(agent, target, distance, weight);
            }
            
            movement.Initialize(agent, target, distance, weight);
            return movement;
        }
        
        /// <summary>
        /// Get a <see cref="KaijuFleeMovement"/>.
        /// </summary>
        /// <param name="agent">The <see cref="KaijuAgent"/> this will be assigned to.</param>
        /// <param name="target">The target.</param>
        /// <param name="distance">At what distance from the target should the flee be considered successful.</param>
        /// <param name="weight">The weight of this <see cref="KaijuMovement"/>.</param>
        /// <returns>Get a <see cref="KaijuFleeMovement"/> for the <see cref="KaijuAgent"/>.</returns>
        public static KaijuFleeMovement Get([NotNull] KaijuAgent agent, Vector3 target, float distance = DefaultDistance, float weight = DefaultWeight)
        {
            KaijuFleeMovement movement = KaijuMovementManager.Get<KaijuFleeMovement>();
            if (movement == null)
            {
                return new(agent, target, distance, weight);
            }
            
            movement.Initialize(agent, target, distance, weight);
            return movement;
        }
        
        /// <summary>
        /// Get a <see cref="KaijuFleeMovement"/>.
        /// </summary>
        /// <param name="agent">The <see cref="KaijuAgent"/> this will be assigned to.</param>
        /// <param name="target">The target.</param>
        /// <param name="distance">At what distance from the target should the flee be considered successful.</param>
        /// <param name="weight">The weight of this <see cref="KaijuMovement"/>.</param>
        /// <returns>Get a <see cref="KaijuFleeMovement"/> for the <see cref="KaijuAgent"/>.</returns>
        public static KaijuFleeMovement Get([NotNull] KaijuAgent agent, [NotNull] GameObject target, float distance = DefaultDistance, float weight = DefaultWeight)
        {
            KaijuFleeMovement movement = KaijuMovementManager.Get<KaijuFleeMovement>();
            if (movement == null)
            {
                return new(agent, target, distance, weight);
            }
            
            movement.Initialize(agent, target, distance, weight);
            return movement;
        }
        
        /// <summary>
        /// Get a <see cref="KaijuFleeMovement"/>.
        /// </summary>
        /// <param name="agent">The <see cref="KaijuAgent"/> this will be assigned to.</param>
        /// <param name="target">The target.</param>
        /// <param name="distance">At what distance from the target should the flee be considered successful.</param>
        /// <param name="weight">The weight of this <see cref="KaijuMovement"/>.</param>
        /// <returns>Get a <see cref="KaijuFleeMovement"/> for the <see cref="KaijuAgent"/>.</returns>
        public static KaijuFleeMovement Get([NotNull] KaijuAgent agent, [NotNull] Component target, float distance = DefaultDistance, float weight = DefaultWeight)
        {
            KaijuFleeMovement movement = KaijuMovementManager.Get<KaijuFleeMovement>();
            if (movement == null)
            {
                return new(agent, target, distance, weight);
            }
            
            movement.Initialize(agent, target, distance, weight);
            return movement;
        }
        
        /// <summary>
        /// Create a <see cref="KaijuFleeMovement"/>.
        /// </summary>
        /// <param name="agent">The <see cref="KaijuAgent"/> this is assigned to.</param>
        /// <param name="target">The position to flee from.</param>
        /// <param name="distance">The distance from the target to consider this movement done.</param>
        /// <param name="weight">The weight of this <see cref="KaijuMovement"/>.</param>
        public KaijuFleeMovement([NotNull] KaijuAgent agent, Vector2 target, float distance = DefaultDistance, float weight = DefaultWeight) : base(agent, target, distance, weight) { }
        
        /// <summary>
        /// Create a <see cref="KaijuFleeMovement"/>.
        /// </summary>
        /// <param name="agent">The <see cref="KaijuAgent"/> this is assigned to.</param>
        /// <param name="target">The position to flee from.</param>
        /// <param name="distance">The distance from the target to consider this movement done.</param>
        /// <param name="weight">The weight of this <see cref="KaijuMovement"/>.</param>
        public KaijuFleeMovement([NotNull] KaijuAgent agent, Vector3 target, float distance = DefaultDistance, float weight = DefaultWeight) : base(agent, target, distance, weight) { }
        
        /// <summary>
        /// Create a <see cref="KaijuFleeMovement"/>.
        /// </summary>
        /// <param name="agent">The <see cref="KaijuAgent"/> this is assigned to.</param>
        /// <param name="target">The <see href="https://docs.unity3d.com/Manual/class-GameObject.html">GameObject</see> to flee from.</param>
        /// <param name="distance">The distance from the target to consider this movement done.</param>
        /// <param name="weight">The weight of this <see cref="KaijuMovement"/>.</param>
        public KaijuFleeMovement([NotNull] KaijuAgent agent, [NotNull] GameObject target, float distance = DefaultDistance, float weight = DefaultWeight) : base(agent, target, distance, weight) { }
        
        /// <summary>
        /// Create a <see cref="KaijuFleeMovement"/>.
        /// </summary>
        /// <param name="agent">The <see cref="KaijuAgent"/> this is assigned to.</param>
        /// <param name="target">The <see href="https://docs.unity3d.com/Manual/Components.html">component</see> to flee from.</param>
        /// <param name="distance">The distance from the target to consider this movement done.</param>
        /// <param name="weight">The weight of this <see cref="KaijuMovement"/>.</param>
        public KaijuFleeMovement([NotNull] KaijuAgent agent, [NotNull] Component target, float distance = DefaultDistance, float weight = DefaultWeight) : base(agent, target, distance, weight) { }
        
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
            return position.Flee(target, speed);
        }
#if UNITY_EDITOR
        /// <summary>
        /// Get the color for visualizations.
        /// </summary>
        /// <returns>The color for visualizations</returns>
        protected override Color EditorVisualizationColor() => KaijuMovementManager.EditorFleeColor;
#endif
        /// <summary>
        /// Get a description of the object.
        /// </summary>
        /// <returns>A description of the object.</returns>
        public override string ToString()
        {
            return $"Kaiju Flee Movement - Agent: {(Agent ? Agent.name : "None")} - Target: {Target.ToString()} - Distance: {Distance} - Current Distance: {CurrentDistance} - Weight: {Weight} - {(Done() ? "Done" : "Executing")}";
        }
    }
}