using System.Diagnostics.CodeAnalysis;
using UnityEngine;

namespace KaijuSolutions.Agents.Movement
{
    /// <summary>
    /// Flee steering behaviour.
    /// </summary>
    public class KaijuFleeMovement : KaijuLeavingMovement
    {
        /// <summary>
        /// Get a flee movement.
        /// </summary>
        /// <param name="agent">The <see cref="KaijuAgent"/> this will be assigned to.</param>
        /// <param name="target">The target.</param>
        /// <param name="distance">At what distance from the target should the flee be considered successful.</param>
        /// <param name="weight">The weight of this movement.</param>
        /// <returns>Get a seek movement for the agent.</returns>
        public static KaijuFleeMovement Get([NotNull] KaijuAgent agent, Vector2 target, float distance = float.MaxValue, float weight = 1)
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
        /// Get a flee movement.
        /// </summary>
        /// <param name="agent">The <see cref="KaijuAgent"/> this will be assigned to.</param>
        /// <param name="target">The target.</param>
        /// <param name="distance">At what distance from the target should the flee be considered successful.</param>
        /// <param name="weight">The weight of this movement.</param>
        /// <returns>Get a seek movement for the agent.</returns>
        public static KaijuFleeMovement Get([NotNull] KaijuAgent agent, Vector3 target, float distance = float.MaxValue, float weight = 1)
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
        /// Get a flee movement.
        /// </summary>
        /// <param name="agent">The <see cref="KaijuAgent"/> this will be assigned to.</param>
        /// <param name="target">The target.</param>
        /// <param name="distance">At what distance from the target should the flee be considered successful.</param>
        /// <param name="weight">The weight of this movement.</param>
        /// <returns>Get a seek movement for the agent.</returns>
        public static KaijuFleeMovement Get([NotNull] KaijuAgent agent, [NotNull] GameObject target, float distance = float.MaxValue, float weight = 1)
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
        /// Get a flee movement.
        /// </summary>
        /// <param name="agent">The <see cref="KaijuAgent"/> this will be assigned to.</param>
        /// <param name="target">The target.</param>
        /// <param name="distance">At what distance from the target should the flee be considered successful.</param>
        /// <param name="weight">The weight of this movement.</param>
        /// <returns>Get a seek movement for the agent.</returns>
        public static KaijuFleeMovement Get([NotNull] KaijuAgent agent, [NotNull] Component target, float distance = float.MaxValue, float weight = 1)
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
        /// Create a flee movement.
        /// </summary>
        /// <param name="agent">The agent this is assigned to.</param>
        /// <param name="target">The position to flee from.</param>
        /// <param name="distance">The distance from the target to consider this movement done.</param>
        /// <param name="weight">The weight of this movement.</param>
        public KaijuFleeMovement([NotNull] KaijuAgent agent, Vector2 target, float distance = float.MaxValue, float weight = 1) : base(agent, target, distance, weight) { }
        
        /// <summary>
        /// Create a flee movement.
        /// </summary>
        /// <param name="agent">The agent this is assigned to.</param>
        /// <param name="target">The position to flee from.</param>
        /// <param name="distance">The distance from the target to consider this movement done.</param>
        /// <param name="weight">The weight of this movement.</param>
        public KaijuFleeMovement([NotNull] KaijuAgent agent, Vector3 target, float distance = float.MaxValue, float weight = 1) : base(agent, target, distance, weight) { }
        
        /// <summary>
        /// Create a flee movement.
        /// </summary>
        /// <param name="agent">The agent this is assigned to.</param>
        /// <param name="target">The <see href="https://docs.unity3d.com/Manual/class-GameObject.html">GameObject</see> to flee from.</param>
        /// <param name="distance">The distance from the target to consider this movement done.</param>
        /// <param name="weight">The weight of this movement.</param>
        public KaijuFleeMovement([NotNull] KaijuAgent agent, [NotNull] GameObject target, float distance = float.MaxValue, float weight = 1) : base(agent, target, distance, weight) { }
        
        /// <summary>
        /// Create a flee movement.
        /// </summary>
        /// <param name="agent">The agent this is assigned to.</param>
        /// <param name="target">The component to flee from.</param>
        /// <param name="distance">The distance from the target to consider this movement done.</param>
        /// <param name="weight">The weight of this movement.</param>
        public KaijuFleeMovement([NotNull] KaijuAgent agent, [NotNull] Component target, float distance = float.MaxValue, float weight = 1) : base(agent, target, distance, weight) { }

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
            return (position - target).normalized * speed - velocity;
        }
#if UNITY_EDITOR
        /// <summary>
        /// Get the color for visualizations.
        /// </summary>
        /// <returns>The color for visualizations</returns>
        protected override Color VisualizationColor()
        {
            return KaijuMovementManager.FleeColor;
        }
        
        /// <summary>
        /// Render the visualization of the movement.
        /// </summary>
        /// <param name="text">If text elements should be visualized or not.</param>
        protected override void RenderVisualizations(bool text = true)
        {
            RenderTargetVisualization("Flee", text);
        }
#endif
        /// <summary>
        /// Get a description of the object.
        /// </summary>
        /// <returns>A description of the object.</returns>
        public override string ToString()
        {
            Vector2? t = Target;
            return $"Kaiju Flee Movement - Agent: {(Agent ? Agent.name : "None")} - Target: {(t.HasValue ? t.Value.ToString() : "None")} - Distance: {Distance} - Current Distance: {CurrentDistance} - Weight: {Weight} - {(Done() ? "Done" : "Executing")}";
        }
    }
}