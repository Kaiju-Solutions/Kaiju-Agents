using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif
namespace KaijuSolutions.Agents.Movement
{
    /// <summary>
    /// Separation steering behaviour.
    /// </summary>
    public class KaijuSeparationMovement : KaijuMovement
    {
        /// <summary>
        /// The distance to avoid other agents from.
        /// </summary>
        public float Distance
        {
            get => _distance;
            set => _distance = Mathf.Max(value, float.Epsilon);
        }
        
        /// <summary>
        /// The distance to avoid other agents from.
        /// </summary>
        private float _distance = float.MaxValue;
        
        /// <summary>
        /// The coefficient to use for inverse square law separation. Zero will use linear separation.
        /// </summary>
        public float Coefficient
        {
            get => _coefficient;
            set => _coefficient = Mathf.Max(value, 0);
        }
        
        /// <summary>
        /// The coefficient to use for inverse square law separation. Zero will use linear separation.
        /// </summary>
        private float _coefficient = float.MaxValue;
        
        /// <summary>
        /// What types of agents to avoid.
        /// </summary>
        public readonly HashSet<uint> Identifiers = new();
        
        /// <summary>
        /// The agents currently being separated from.
        /// </summary>
        public IReadOnlyCollection<KaijuAgent> Separating => _separating;
        
        /// <summary>
        /// The agents currently being separated from.
        /// </summary>
        private readonly HashSet<KaijuAgent> _separating = new();
        
        /// <summary>
        /// Clear all identifiers of agents to separate from.
        /// </summary>
        public void ClearIdentifiers()
        {
            Identifiers.Clear();
        }
        
        /// <summary>
        /// Set the identifier of agents to separate from.
        /// </summary>
        /// <param name="identifier">The identifier to set.</param>
        public void SetIdentifier(uint identifier)
        {
            ClearIdentifiers();
            AddIdentifier(identifier);
        }
        
        /// <summary>
        /// Set the identifier of agents to separate from.
        /// </summary>
        /// <param name="identifiers">The identifiers to set.</param>
        public void SetIdentifiers([NotNull] IEnumerable<uint> identifiers)
        {
            ClearIdentifiers();
            AddIdentifiers(identifiers);
        }
        
        /// <summary>
        /// Add an identifier for agents to separate from.
        /// </summary>
        /// <param name="identifier">The identifier to add.</param>
        /// <returns>If the identifier was added.</returns>
        public bool AddIdentifier(uint identifier)
        {
            return Identifiers.Add(identifier);
        }
        
        /// <summary>
        /// Add identifiers for agents to separate from.
        /// </summary>
        /// <param name="identifiers">The identifiers to add.</param>
        /// <returns>If any of the identifiers were added.</returns>
        public bool AddIdentifiers([NotNull] IEnumerable<uint> identifiers)
        {
            bool added = false;
            
            foreach (uint identifier in identifiers)
            {
                if (AddIdentifier(identifier))
                {
                    added = true;
                }
            }
            
            return added;
        }
        
        /// <summary>
        /// Remove an identifier for agents to separate from.
        /// </summary>
        /// <param name="identifier">The identifier to remove.</param>
        /// <returns>If the identifier was removed.</returns>
        public bool RemoveIdentifier(uint identifier)
        {
            return Identifiers.Remove(identifier);
        }
        
        /// <summary>
        /// Remove identifiers for agents to separate from.
        /// </summary>
        /// <param name="identifiers">The identifiers to remove.</param>
        /// <returns>If any of the identifiers were removed.</returns>
        public bool RemoveIdentifiers([NotNull] IEnumerable<uint> identifiers)
        {
            bool removed = false;
            
            foreach (uint identifier in identifiers)
            {
                if (RemoveIdentifier(identifier))
                {
                    removed = true;
                }
            }
            
            return removed;
        }
        
        /// <summary>
        /// If movement was actually performed.
        /// </summary>
        public override bool Performed => _performed;
        
        /// <summary>
        /// If any avoidance we performed this update.
        /// </summary>
        private bool _performed;
        
        /// <summary>
        /// Get a separation movement.
        /// </summary>
        /// <param name="agent">The agent this is assigned to.</param>
        /// <param name="distance">The distance to avoid other agents from.</param>
        /// <param name="coefficient">The coefficient to use for inverse square law separation. Zero will use linear separation.</param>
        /// <param name="identifiers">What types of agents to avoid.</param>
        /// <param name="weight">The weight of this movement.</param>
        /// <returns>Get a separation movement for the agent.</returns>
        public static KaijuSeparationMovement Get([NotNull] KaijuAgent agent, float distance = 10, float coefficient = 0, IEnumerable<uint> identifiers = null, float weight = 1)
        {
            KaijuSeparationMovement movement = KaijuMovementManager.Get<KaijuSeparationMovement>();
            if (movement == null)
            {
                return new(agent, distance, coefficient, identifiers, weight);
            }
            
            movement.Initialize(agent, distance, coefficient, identifiers, weight);
            return movement;
        }
        
        /// <summary>
        /// Create a separation movement.
        /// </summary>
        /// <param name="agent">The agent this is assigned to.</param>
        /// <param name="distance">The distance to avoid other agents from.</param>
        /// <param name="coefficient">The coefficient to use for inverse square law separation. Zero will use linear separation.</param>
        /// <param name="identifiers">What types of agents to avoid.</param>
        /// <param name="weight">The weight of this movement.</param>
        public KaijuSeparationMovement(KaijuAgent agent, float distance = 10, float coefficient = 0, IEnumerable<uint> identifiers = null, float weight = 1) : base(agent, weight)
        {
            Initialize(agent, distance, coefficient, identifiers, weight);
        }
        
        /// <summary>
        /// Initialize the movement.
        /// </summary>
        /// <param name="agent">The agent this is assigned to.</param>
        /// <param name="distance">The distance to avoid other agents from.</param>
        /// <param name="coefficient">The coefficient to use for inverse square law separation. Zero will use linear separation.</param>
        /// <param name="identifiers">What types of agents to avoid.</param>
        /// <param name="weight">The weight of this movement.</param>
        private void Initialize(KaijuAgent agent, float distance = 10, float coefficient = 0, IEnumerable<uint> identifiers = null, float weight = 1)
        {
            base.Initialize(agent, weight);
            Distance = distance;
            Coefficient = coefficient;
            Identifiers.Clear();
            if (identifiers == null)
            {
                return;
            }
            
            foreach (uint identifier in identifiers)
            {
                Identifiers.Add(identifier);
            }
        }
        
        /// <summary>
        /// Perform any needed reset operations.
        /// </summary>
        protected override void Reset()
        {
            base.Reset();
            _distance = float.MaxValue;
            _coefficient = 0;
            Identifiers.Clear();
        }
        
        /// <summary>
        /// Get the movement.
        /// </summary>
        /// <param name="position">The position of the <see cref="KaijuMovement.Agent"/>.</param>
        /// <param name="velocity">The velocity of the <see cref="KaijuMovement.Agent"/>.</param>
        /// <param name="delta">The time step.</param>
        /// <returns>The calculated movement.</returns>
        public override Vector2 Move(Vector2 position, Vector2 velocity, float delta)
        {
            // Start with indicating no movement has been performed.
            _performed = false;
            Vector2 movement = Vector2.zero;
            _separating.Clear();
            
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
                
                // Calculate the strength.
                float strength = Coefficient > 0
                    // Inverse square law separation.
                    ? Coefficient / (distance * distance)
                    // Linear separation.
                    : Agent.MoveSpeed * (Distance - distance) / Distance;
                
                // Add the movement, and indicate there has been a separation performed.
                movement -= direction.normalized * Mathf.Min(strength, Agent.MoveSpeed);
                _performed = true;
                _separating.Add(agent);
            }
            
            return movement;
        }
#if UNITY_EDITOR
        /// <summary>
        /// Get the color for visualizations.
        /// </summary>
        /// <returns>The color for visualizations</returns>
        protected override Color VisualizationColor() => Color.violet; // TODO - Make a setting.
        
        /// <summary>
        /// Render the visualization of the movement.
        /// </summary>
        protected override void RenderVisualizations()
        {
            Vector3 a = Agent;
            Handles.DrawWireDisc(a, Vector3.up, Distance, 0);
            foreach (KaijuAgent agent in _separating)
            {
                Vector3 b = agent;
                Handles.DrawLine(a, b);
            }
        }
#endif
    }
}