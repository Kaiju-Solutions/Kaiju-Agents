using System.Diagnostics.CodeAnalysis;
using UnityEditor;
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
        /// <returns>Get a seek movement for the agent.</returns>
        public new static KaijuPursueMovement Get([NotNull] KaijuAgent agent, Vector2 target, float distance = 0, float weight = 1)
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
        /// <returns>Get a seek movement for the agent.</returns>
        public new static KaijuPursueMovement Get([NotNull] KaijuAgent agent, Vector3 target, float distance = 0, float weight = 1)
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
        /// <returns>Get a seek movement for the agent.</returns>
        public new static KaijuPursueMovement Get([NotNull] KaijuAgent agent, [NotNull] GameObject target, float distance = 0, float weight = 1)
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
        /// <returns>Get a seek movement for the agent.</returns>
        public new static KaijuPursueMovement Get([NotNull] KaijuAgent agent, [NotNull] Component target, float distance = 0, float weight = 1)
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
        public KaijuPursueMovement([NotNull] KaijuAgent agent, Vector2 target, float distance = 0, float weight = 1) : base(agent, target, distance, weight) { }
        
        /// <summary>
        /// Create a pursue movement.
        /// </summary>
        /// <param name="agent">The agent this is assigned to.</param>
        /// <param name="target">The position to pursue to.</param>
        /// <param name="distance">The distance from the target to consider this movement done.</param>
        /// <param name="weight">The weight of this movement.</param>
        public KaijuPursueMovement([NotNull] KaijuAgent agent, Vector3 target, float distance = 0, float weight = 1) : base(agent, target, distance, weight) { }

        /// <summary>
        /// Create a pursue movement.
        /// </summary>
        /// <param name="agent">The agent this is assigned to.</param>
        /// <param name="target">The GameObject to pursue to.</param>
        /// <param name="distance">The distance from the target to consider this movement done.</param>
        /// <param name="weight">The weight of this movement.</param>
        public KaijuPursueMovement([NotNull] KaijuAgent agent, [NotNull] GameObject target, float distance = 0, float weight = 1) : base(agent, target, distance, weight) { }

        /// <summary>
        /// Create a pursue movement.
        /// </summary>
        /// <param name="agent">The agent this is assigned to.</param>
        /// <param name="target">The component to pursue to.</param>
        /// <param name="distance">The distance from the target to consider this movement done.</param>
        /// <param name="weight">The weight of this movement.</param>
        public KaijuPursueMovement([NotNull] KaijuAgent agent, [NotNull] Component target, float distance = 0, float weight = 1) : base(agent, target, distance, weight) { }
        
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
        /// <param name="velocity">The agent's current velocity.</param>
        /// <param name="speed">The agent's maximum movement speed.</param>
        /// <param name="target">The position to move in relation to.</param>
        /// <param name="delta">The time step.</param>
        /// <returns>The calculated movement.</returns>
        protected override Vector2 Calculate(Vector2 position, Vector2 velocity, float speed, Vector2 target, float delta)
        {
            // Calculate target values.
            Vector2 targetVelocity = Velocity(target, Previous, delta);
            float targetSpeed = Speed(target, Previous, delta);
            
            // Predict where the target will be.
            Future = target + targetVelocity * ((target - position).magnitude / (speed + targetSpeed));
            
            // Seek ahead of the target.
            Vector2 move = base.Calculate(position, velocity, speed, Future, delta);
            
            // Update the previous position.
            Previous = target;
            return move;
        }
#if UNITY_EDITOR
        /// <summary>
        /// Get the color for visualizations.
        /// </summary>
        /// <returns>The color for visualizations</returns>
        protected override Color VisualizationColor()
        {
            return KaijuMovementManager.PursueColor;
        }
        
        /// <summary>
        /// Render the visualization of the movement.
        /// </summary>
        /// <param name="text">If text elements should be visualized or not.</param>
        protected override void RenderVisualizations(bool text = true)
        {
            Vector3 t = Target3;
            Vector3 a = Agent;
            Vector3 f = Future3;
            
            // Only one line to draw if equal.
            bool still = t == f;
            if (still)
            {
                Handles.DrawLine(a, t);
            }
            else
            {
                // Agent to target.
                _rendering[0] = a;
                _rendering[1] = t;
                // Agent to forecast.
                _rendering[2] = a;
                _rendering[3] = f;
                // Target to forecast.
                _rendering[4] = t;
                _rendering[5] = f;
                Handles.DrawLines(_rendering);
            }
            
            RenderDistance(t);
            RenderTargetVisualizationText("Pursue", t, text);
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