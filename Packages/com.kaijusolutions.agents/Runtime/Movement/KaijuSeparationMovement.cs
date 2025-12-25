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
        /// If any avoidance we performed this update.
        /// </summary>
        private bool _performed;
        
        /// <summary>
        /// If movement was actually performed.
        /// </summary>
        public override bool Performed => _performed;
        
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