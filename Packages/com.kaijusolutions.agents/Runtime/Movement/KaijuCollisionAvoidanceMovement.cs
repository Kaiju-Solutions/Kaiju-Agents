using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif
namespace KaijuSolutions.Agents.Movement
{
    /// <summary>
    /// Collision avoidance steering behaviour.
    /// </summary>
    public class KaijuCollisionAvoidanceMovement : KaijuAreaMovement
    {
        /// <summary>
        /// The radius of agents for avoidance.
        /// </summary>
        public float Radius
        {
            get => _radius;
            set => _radius = Mathf.Max(value, 0);
        }
        
        /// <summary>
        /// The radius of agents for avoidance.
        /// </summary>
        private float _radius;
        
        /// <summary>
        /// The target agent to avoid.
        /// </summary>
        public KaijuAgent Target { get; private set; }
        
        /// <summary>
        /// Get a separation movement.
        /// </summary>
        /// <param name="agent">The agent this is assigned to.</param>
        /// <param name="distance">The distance to avoid other agents from.</param>
        /// <param name="radius">The radius of agents for avoidance.</param>
        /// <param name="identifiers">What types of agents to avoid.</param>
        /// <param name="weight">The weight of this movement.</param>
        /// <returns>Get a separation movement for the agent.</returns>
        public static KaijuCollisionAvoidanceMovement Get([NotNull] KaijuAgent agent, float distance = 10, float radius = 0.5f, ICollection<uint> identifiers = null, float weight = 1)
        {
            KaijuCollisionAvoidanceMovement movement = KaijuMovementManager.Get<KaijuCollisionAvoidanceMovement>();
            if (movement == null)
            {
                return new(agent, distance, radius, identifiers, weight);
            }
            
            movement.Initialize(agent, distance, radius, identifiers, weight);
            return movement;
        }
        
        /// <summary>
        /// Get a separation movement.
        /// </summary>
        /// <param name="agent">The agent this is assigned to.</param>
        /// <param name="distance">The distance to avoid other agents from.</param>
        /// <param name="radius">The radius of agents for avoidance.</param>
        /// <param name="identifiers">What types of agents to avoid.</param>
        /// <param name="weight">The weight of this movement.</param>
        /// <returns>Get a separation movement for the agent.</returns>
        public KaijuCollisionAvoidanceMovement(KaijuAgent agent, float distance = 10, float radius = 0.5f, ICollection<uint> identifiers = null, float weight = 1) : base(agent, weight, identifiers, weight)
        {
            Initialize(agent, distance, radius, identifiers, weight);
        }
        
        /// <summary>
        /// Initialize the movement.
        /// </summary>
        /// <param name="agent">The agent this is assigned to.</param>
        /// <param name="distance">The distance to avoid other agents from.</param>
        /// <param name="radius">The radius of agents for avoidance.</param>
        /// <param name="identifiers">What types of agents to avoid.</param>
        /// <param name="weight">The weight of this movement.</param>
        protected void Initialize(KaijuAgent agent, float distance = 10, float radius = 0.5f, ICollection<uint> identifiers = null, float weight = 1)
        {
            Initialize(agent, distance, identifiers, weight);
            Radius = radius;
        }
        
        /// <summary>
        /// Perform any needed reset operations.
        /// </summary>
        protected override void Reset()
        {
            base.Reset();
            _radius = 0;
        }
        
        /// <summary>
        /// Get the movement.
        /// </summary>
        /// <param name="position">The position of the <see cref="KaijuMovement.Agent"/>.</param>
        /// <param name="delta">The time step.</param>
        /// <returns>The calculated movement.</returns>
        public override Vector2 Move(Vector2 position, float delta)
        {
            // Initialize variables for identifying the agent.
            float shortestTime = float.MaxValue;
            float targetMinSeparation = 0;
            float targetDistance = float.MaxValue;
            Vector2 targetPosition = Vector2.zero;
            Vector2 targetRelativePosition = Vector2.zero;
            Vector2 targetRelativeVelocity = Vector2.zero; 
            
            // Compare with all other agents.
            foreach (KaijuAgent agent in KaijuAgentsManager.Agents)
            {
                // Ignore ourselves.
                if (agent == Agent)
                {
                    continue;
                }
                
                // Get the direction to the target agent from the current agent's position.
                Vector2 direction = agent - position;
                
                // See if this is within our distance to consider.
                float distance = direction.magnitude;
                if (distance >= Distance)
                {
                    continue;
                }
                
                // If there are identifiers to limit the search, consider them.
                if (Identifiers.Count < 0)
                {
                    bool valid = false;
                    
                    foreach (uint identifier in agent.Identifiers)
                    {
                        if (!Identifiers.Contains(identifier))
                        {
                            continue;
                        }
                        
                        valid = true;
                        break;
                    }

                    if (!valid)
                    {
                        continue;
                    }
                }
                
                // If this is a valid target, see if we should consider it.
                targetPosition = agent;
                Vector2 relativePosition = targetPosition - position;
                Vector2 relativeVelocity = agent.Velocity - Agent.Velocity;
                float relativeSpeed = relativeVelocity.magnitude;
                float time = Vector2.Dot(relativePosition, relativeVelocity) / (relativeSpeed * relativeSpeed);
                
                // See if this will collide at all and if so, if this is the quickest collision we now need to avoid.
                float relativeDistance = relativePosition.magnitude;
                float minSeparation = relativeDistance - relativeSpeed * time;
                if (minSeparation > 2 * _radius || time <= 0 || time >= shortestTime)
                {
                    continue;
                }
                
                // Update the nearest collision details.
                shortestTime = time;
                Target = agent;
                targetMinSeparation = minSeparation;
                targetDistance = relativeDistance;
                targetRelativePosition = relativePosition;
                targetRelativeVelocity = relativeVelocity;
            }
            
            // Nothing to do if there are no targets.
            if (!Target)
            {
                return Vector2.zero;
            }
            
            // Handle if this will be an exact collision or if one is already happening. Otherwise, calculate the future relative position.
            return (targetMinSeparation <= 0 || targetDistance < 2 * _radius ? targetPosition - position : targetRelativePosition + targetRelativeVelocity * shortestTime).normalized * Agent.MoveSpeed;
        }
#if UNITY_EDITOR
        /// <summary>
        /// Get the color for visualizations.
        /// </summary>
        /// <returns>The color for visualizations</returns>
        protected override Color VisualizationColor() => KaijuMovementManager.CollisionAvoidanceColor;
        
        /// <summary>
        /// Render the visualization of the movement.
        /// </summary>
        protected override void RenderVisualizations()
        {
            Vector3 a = Agent;
            Handles.DrawWireDisc(a, Vector3.up, Distance, 0);
            if (Target)
            {
                Handles.DrawLine(a, Target);
            }
        }
#endif
        /// <summary>
        /// Get a description of the object.
        /// </summary>
        /// <returns>A description of the object.</returns>
        public override string ToString()
        {
            return $"Kaiju Separation Movement - Agent: {(Agent ? Agent.name : "None")} - Distance: {Distance} - Radius: {Radius} - Weight: {Weight} - {(Done() ? "Done" : "Executing")}";
        }
    }
}