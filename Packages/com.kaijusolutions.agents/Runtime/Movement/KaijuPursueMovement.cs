using System.Diagnostics.CodeAnalysis;
using KaijuSolutions.Agents.Extensions;
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif
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
        /// The previous position of the target.
        /// </summary>
        public Vector3 Previous3 => new(Previous.x, 0, Previous.y);
        
        /// <summary>
        /// The predicted future target.
        /// </summary>
        public Vector2 Future { get; private set; }
        
        /// <summary>
        /// The predicted future target.
        /// </summary>
        public Vector3 Future3 => new(Future.x, 0, Future.y);
#if UNITY_EDITOR
        /// <summary>
        /// Points to render.
        /// </summary>
        private  Vector3[] _rendering = new Vector3[6];
#endif
        /// <summary>
        /// Get a pursue movement.
        /// </summary>
        /// <param name="agent">The <see cref="KaijuAgent"/> this will be assigned to.</param>
        /// <param name="target">The target.</param>
        /// <param name="distance">At what distance from the target should the pursue be considered successful.</param>
        /// <param name="weight">The weight of this movement.</param>
        /// <returns>Get a pursue movement for the agent.</returns>
        public new static KaijuPursueMovement Get([NotNull] KaijuAgent agent, Vector2 target, float distance = 0.1f, float weight = 1)
        {
            KaijuPursueMovement movement = KaijuMovementManager.Get<KaijuPursueMovement>();
            if (movement == null)
            {
                return new(agent, target, distance, weight);
            }
            
            movement.Initialize(agent, target, distance, weight);
            return movement;
        }
        
        /// <summary>
        /// Get a pursue movement.
        /// </summary>
        /// <param name="agent">The <see cref="KaijuAgent"/> this will be assigned to.</param>
        /// <param name="target">The target.</param>
        /// <param name="distance">At what distance from the target should the pursue be considered successful.</param>
        /// <param name="weight">The weight of this movement.</param>
        /// <returns>Get a pursue movement for the agent.</returns>
        public new static KaijuPursueMovement Get([NotNull] KaijuAgent agent, Vector3 target, float distance = 0.1f, float weight = 1)
        {
            KaijuPursueMovement movement = KaijuMovementManager.Get<KaijuPursueMovement>();
            if (movement == null)
            {
                return new(agent, target, distance, weight);
            }
            
            movement.Initialize(agent, target, distance, weight);
            return movement;
        }
        
        /// <summary>
        /// Get a pursue movement.
        /// </summary>
        /// <param name="agent">The <see cref="KaijuAgent"/> this will be assigned to.</param>
        /// <param name="target">The target.</param>
        /// <param name="distance">At what distance from the target should the pursue be considered successful.</param>
        /// <param name="weight">The weight of this movement.</param>
        /// <returns>Get a pursue movement for the agent.</returns>
        public new static KaijuPursueMovement Get([NotNull] KaijuAgent agent, [NotNull] GameObject target, float distance = 0.1f, float weight = 1)
        {
            KaijuPursueMovement movement = KaijuMovementManager.Get<KaijuPursueMovement>();
            if (movement == null)
            {
                return new(agent, target, distance, weight);
            }
            
            movement.Initialize(agent, target, distance, weight);
            return movement;
        }
        
        /// <summary>
        /// Get a pursue movement.
        /// </summary>
        /// <param name="agent">The <see cref="KaijuAgent"/> this will be assigned to.</param>
        /// <param name="target">The target.</param>
        /// <param name="distance">At what distance from the target should the pursue be considered successful.</param>
        /// <param name="weight">The weight of this movement.</param>
        /// <returns>Get a pursue movement for the agent.</returns>
        public new static KaijuPursueMovement Get([NotNull] KaijuAgent agent, [NotNull] Component target, float distance = 0.1f, float weight = 1)
        {
            KaijuPursueMovement movement = KaijuMovementManager.Get<KaijuPursueMovement>();
            if (movement == null)
            {
                return new(agent, target, distance, weight);
            }
            
            movement.Initialize(agent, target, distance, weight);
            return movement;
        }
        
        /// <summary>
        /// Create a pursue movement.
        /// </summary>
        /// <param name="agent">The agent this is assigned to.</param>
        /// <param name="target">The position to pursue to.</param>
        /// <param name="distance">The distance from the target to consider this movement done.</param>
        /// <param name="weight">The weight of this movement.</param>
        public KaijuPursueMovement([NotNull] KaijuAgent agent, Vector2 target, float distance = 0.1f, float weight = 1) : base(agent, target, distance, weight) { }
        
        /// <summary>
        /// Create a pursue movement.
        /// </summary>
        /// <param name="agent">The agent this is assigned to.</param>
        /// <param name="target">The position to pursue to.</param>
        /// <param name="distance">The distance from the target to consider this movement done.</param>
        /// <param name="weight">The weight of this movement.</param>
        public KaijuPursueMovement([NotNull] KaijuAgent agent, Vector3 target, float distance = 0.1f, float weight = 1) : base(agent, target, distance, weight) { }

        /// <summary>
        /// Create a pursue movement.
        /// </summary>
        /// <param name="agent">The agent this is assigned to.</param>
        /// <param name="target">The GameObject to pursue to.</param>
        /// <param name="distance">The distance from the target to consider this movement done.</param>
        /// <param name="weight">The weight of this movement.</param>
        public KaijuPursueMovement([NotNull] KaijuAgent agent, [NotNull] GameObject target, float distance = 0.1f, float weight = 1) : base(agent, target, distance, weight) { }

        /// <summary>
        /// Create a pursue movement.
        /// </summary>
        /// <param name="agent">The agent this is assigned to.</param>
        /// <param name="target">The component to pursue to.</param>
        /// <param name="distance">The distance from the target to consider this movement done.</param>
        /// <param name="weight">The weight of this movement.</param>
        public KaijuPursueMovement([NotNull] KaijuAgent agent, [NotNull] Component target, float distance = 0.1f, float weight = 1) : base(agent, target, distance, weight) { }
        
        /// <summary>
        /// Handle any additional setup.
        /// </summary>
        protected override void Setup()
        {
            // Start the previous and future position as the current position.
            Previous = Target;
            Future = Target;
        }
        
        /// <summary>
        /// Perform any needed reset operations.
        /// </summary>
        protected override void Reset()
        {
            base.Reset();
            Previous = Vector2.zero;
            Future = Vector2.zero;
        }
        
        /// <summary>
        /// Calculate the movement.
        /// </summary>
        /// <param name="position">The agent's current position.</param>
        /// <param name="speed">The agent's maximum movement speed.</param>
        /// <param name="target">The position to move in relation to.</param>
        /// <param name="delta">The time step.</param>
        /// <returns>The calculated movement.</returns>
        protected override Vector2 Calculate(Vector2 position, float speed, Vector2 target, float delta)
        {
            // Calculate target values.
            Vector2 targetVelocity = target.Velocity(Previous, delta);
            float targetSpeed = target.Speed(Previous, delta);
            
            // Predict where the target will be.
            Future = target + targetVelocity * ((target - position).magnitude / (speed + targetSpeed));
            
            // Seek ahead of the target.
            Vector2 move = base.Calculate(position, speed, Future, delta);
            
            // Update the previous position.
            Previous = target;
            return move;
        }
#if UNITY_EDITOR
        /// <summary>
        /// Get the color for visualizations.
        /// </summary>
        /// <returns>The color for visualizations</returns>
        protected override Color EditorVisualizationColor() => KaijuMovementManager.EditorPursueColor;
        
        /// <summary>
        /// Render the visualization of the movement.
        /// <param name="position">The position of the <see cref="KaijuMovement.Agent"/>.</param>
        /// </summary>
        protected override void EditorRenderVisualizations(Vector3 position)
        {
            Vector3 t = Target3;
            Vector3 f = Future3;
            
            // Only one line to draw if equal.
            bool still = t == f;
            if (still)
            {
                Handles.DrawLine(position, t);
            }
            else
            {
                // Agent to target.
                _rendering[0] = position;
                _rendering[1] = t;
                // Agent to forecast.
                _rendering[2] = position;
                _rendering[3] = f;
                // Target to forecast.
                _rendering[4] = t;
                _rendering[5] = f;
                Handles.DrawLines(_rendering);
            }
            
            RenderDistance(t);
        }
#endif
        /// <summary>
        /// Get a description of the object.
        /// </summary>
        /// <returns>A description of the object.</returns>
        public override string ToString()
        {
            return $"Kaiju Pursue Movement - Agent: {(Agent ? Agent.name : "None")} - Target: {Target.ToString()} - Distance: {Distance} - Current Distance: {CurrentDistance} - Previous: {Previous} - Weight: {Weight} - {(Done() ? "Done" : "Executing")}";
        }
    }
}