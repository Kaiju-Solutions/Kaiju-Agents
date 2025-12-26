using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using UnityEngine;

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
        /// What types of agents to avoid.
        /// </summary>
        public readonly HashSet<uint> Identifiers = new();
        
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
        /// All agents near this agent.
        /// </summary>
        public IReadOnlyCollection<KaijuAgent> Near => _near;
        
        /// <summary>
        /// All agents near this agent.
        /// </summary>
        private readonly HashSet<KaijuAgent> _near = new();
        
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
        /// <param name="identifiers">What types of agents to avoid.</param>
        /// <param name="weight">The weight of this movement.</param>
        /// <returns>Get a separation movement for the agent.</returns>
        public static KaijuSeparationMovement Get([NotNull] KaijuAgent agent, float distance = float.MaxValue, IEnumerable<uint> identifiers = null, float weight = 1)
        {
            KaijuSeparationMovement movement = KaijuMovementManager.Get<KaijuSeparationMovement>();
            if (movement == null)
            {
                return new(agent, distance, identifiers, weight);
            }
            
            movement.Initialize(agent, distance, identifiers, weight);
            return movement;
        }
        
        /// <summary>
        /// Create a separation movement.
        /// </summary>
        /// <param name="agent">The agent this is assigned to.</param>
        /// <param name="distance">The distance to avoid other agents from.</param>
        /// <param name="identifiers">What types of agents to avoid.</param>
        /// <param name="weight">The weight of this movement.</param>
        public KaijuSeparationMovement(KaijuAgent agent, float distance = float.MaxValue, IEnumerable<uint> identifiers = null, float weight = 1) : base(agent, weight)
        {
            Initialize(agent, distance, identifiers, weight);
        }
        
        /// <summary>
        /// Initialize the movement.
        /// </summary>
        /// <param name="agent">The agent this is assigned to.</param>
        /// <param name="distance">The distance to avoid other agents from.</param>
        /// <param name="identifiers">What types of agents to avoid.</param>
        /// <param name="weight">The weight of this movement.</param>
        private void Initialize(KaijuAgent agent, float distance = float.MaxValue, IEnumerable<uint> identifiers = null, float weight = 1)
        {
            base.Initialize(agent, weight);
            Distance = distance;
            _near.Clear();
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
            _performed = false;
            // TODO - Implement.
            return Vector2.zero;
        }
    }
}