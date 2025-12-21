using System.Diagnostics.CodeAnalysis;
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
            // Start the previous position as the current position.
            if (Target.HasValue)
            {
                Previous = Target.Value;
                Future = Target.Value;
            }
            else
            {
                Previous = Vector2.zero;
                Future = Vector2.zero;
            }
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
            
            Future = target + targetVelocity * ((target - position).magnitude / (speed + targetSpeed));
            
            // Seek ahead of the target.
            Vector2 move = base.Calculate(position, velocity, speed, Future, delta);
            
            // Update the previous position.
            Previous = target;
            return move;
        }
        
        /// <summary>
        /// Allow for visualizing with <see href="https://docs.unity3d.com/ScriptReference/Gizmos.html">gizmos</see>.
        /// </summary>
        public override void Visualize()
        {
            if (!Agent)
            {
                return;
            }
            
            Vector3? t = Target3;
            if (!t.HasValue)
            {
                return;
            }
            
            Gizmos.color = Visuals;
            Gizmos.DrawLine(Agent.transform.position, t.Value);
            Gizmos.DrawLine(Agent.transform.position, Future3);
            Gizmos.DrawLine(t.Value, Future3);
        }

        /// <summary>
        /// Get a description of the object.
        /// </summary>
        /// <returns>A description of the object.</returns>
        public override string ToString()
        {
            Vector2? t = Target;
            return $"Kaiju Pursue Movement - Agent: {(Agent ? Agent.name : "None")} - Target: {(t.HasValue ? t.Value.ToString() : "None")} - Distance: {Distance} - Current Distance: {CurrentDistance} - Previous: {Previous} - Weight: {Weight} - {(Done() ? "Done" : "Executing")}";
        }
    }
}