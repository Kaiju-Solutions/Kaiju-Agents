using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using UnityEngine;

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
            Vector2 movement = Vector2.zero;
            Interacting.Clear();
            
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
                
                // TODO.
            }
            
            return movement;
        }
    }
}