using System.Collections.Generic;
using UnityEngine;

namespace KaijuSolutions.Agents.Movement
{
    /// <summary>
    /// Collision avoidance steering behaviour.
    /// </summary>
    public class KaijuCollisionAvoidanceMovement : KaijuAreaMovement
    {
        /// <summary>
        /// Get a separation movement.
        /// </summary>
        /// <param name="agent">The agent this is assigned to.</param>
        /// <param name="distance">The distance to avoid other agents from.</param>
        /// <param name="identifiers">What types of agents to avoid.</param>
        /// <param name="weight">The weight of this movement.</param>
        /// <returns>Get a separation movement for the agent.</returns>
        public KaijuCollisionAvoidanceMovement(KaijuAgent agent, float distance = 10, ICollection<uint> identifiers = null, float weight = 1) : base(agent, weight, identifiers, weight)
        {
            Initialize(agent, distance, identifiers, weight);
        }
        
        /// <summary>
        /// Get the movement.
        /// </summary>
        /// <param name="position">The position of the <see cref="KaijuMovement.Agent"/>.</param>
        /// <param name="delta">The time step.</param>
        /// <returns>The calculated movement.</returns>
        public override Vector2 Move(Vector2 position, float delta)
        {
            // TODO.
            return Vector2.zero;
        }
    }
}