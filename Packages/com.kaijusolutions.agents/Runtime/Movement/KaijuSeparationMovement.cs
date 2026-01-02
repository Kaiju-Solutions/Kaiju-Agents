using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using KaijuSolutions.Agents.Extensions;
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif
namespace KaijuSolutions.Agents.Movement
{
    /// <summary>
    /// Separation steering behaviour.
    /// </summary>
    public class KaijuSeparationMovement : KaijuAreaMovement
    {
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
        /// The <see cref="KaijuAgent"/>s currently detected this movement is moving in relation to.
        /// </summary>
        public IReadOnlyCollection<KaijuAgent> Interacting => _interacting;
        
        /// <summary>
        /// The <see cref="KaijuAgent"/>s currently detected this movement is moving in relation to.
        /// </summary>
        private readonly HashSet<KaijuAgent> _interacting = new();
        
        /// <summary>
        /// Get a separation movement.
        /// </summary>
        /// <param name="agent">The <see cref="KaijuAgent"/> this is assigned to.</param>
        /// <param name="distance">The distance to avoid other <see cref="KaijuAgent"/>s from.</param>
        /// <param name="coefficient">The coefficient to use for inverse square law separation. Zero will use linear separation.</param>
        /// <param name="identifiers">What types of <see cref="KaijuAgent"/>s to avoid.</param>
        /// <param name="weight">The weight of this <see cref="KaijuMovement"/>.</param>
        /// <returns>Get a separation movement for the <see cref="KaijuAgent"/>.</returns>
        public static KaijuSeparationMovement Get([NotNull] KaijuAgent agent, float distance = 10, float coefficient = 0, ICollection<uint> identifiers = null, float weight = 1)
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
        /// <param name="agent">The <see cref="KaijuAgent"/> this is assigned to.</param>
        /// <param name="distance">The distance to avoid other <see cref="KaijuAgent"/>s from.</param>
        /// <param name="coefficient">The coefficient to use for inverse square law separation. Zero will use linear separation.</param>
        /// <param name="identifiers">What types of <see cref="KaijuAgent"/>s to avoid.</param>
        /// <param name="weight">The weight of this <see cref="KaijuMovement"/>.</param>
        public KaijuSeparationMovement([NotNull] KaijuAgent agent, float distance = 10, float coefficient = 0, ICollection<uint> identifiers = null, float weight = 1) : base(agent, distance, identifiers, weight)
        {
            Initialize(agent, distance, coefficient, identifiers, weight);
        }
        
        /// <summary>
        /// Initialize the movement <see cref="KaijuMovement"/>.
        /// </summary>
        /// <param name="agent">The <see cref="KaijuAgent"/> this is assigned to.</param>
        /// <param name="distance">The distance to avoid other <see cref="KaijuAgent"/>s from.</param>
        /// <param name="coefficient">The coefficient to use for inverse square law separation. Zero will use linear separation.</param>
        /// <param name="identifiers">What types of <see cref="KaijuAgent"/>s to avoid.</param>
        /// <param name="weight">The weight of this <see cref="KaijuMovement"/>.</param>
        private void Initialize([NotNull] KaijuAgent agent, float distance = 10, float coefficient = 0, ICollection<uint> identifiers = null, float weight = 1)
        {
            Initialize(agent, distance, identifiers, weight);
            Coefficient = coefficient;
        }
        
        /// <summary>
        /// Perform any needed reset operations.
        /// </summary>
        protected override void Reset()
        {
            base.Reset();
            _coefficient = 0;
            _interacting.Clear();
        }
        
        /// <summary>
        /// Get the <see cref="KaijuMovement"/>.
        /// </summary>
        /// <param name="position">The position of the <see cref="KaijuMovement.Agent"/>.</param>
        /// <param name="delta">The time step.</param>
        /// <returns>The calculated move vector.</returns>
        public override Vector2 Move(Vector2 position, float delta)
        {
            Vector2 movement = Vector2.zero;
            _interacting.Clear();
            
            // Compare with all other <see cref="KaijuAgent"/>s.
            foreach (KaijuAgent agent in KaijuAgentsManager.Agents)
            {
                // Ignore ourselves.
                if (agent == Agent)
                {
                    continue;
                }
                
                // Get the direction to the target <see cref="KaijuAgent"/> from the current <see cref="KaijuAgent"/>'s position.
                Vector2 direction = agent.Direction(position);
                
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
                _interacting.Add(agent);
            }
            
            return movement;
        }
#if UNITY_EDITOR
        /// <summary>
        /// Get the color for visualizations.
        /// </summary>
        /// <returns>The color for visualizations</returns>
        protected override Color EditorVisualizationColor() => KaijuMovementManager.EditorSeparationColor;
        
        /// <summary>
        /// Render the visualization of the <see cref="KaijuMovement"/>.
        /// <param name="position">The position of the <see cref="KaijuMovement.Agent"/>.</param>
        /// </summary>
        protected override void EditorRenderVisualizations(Vector3 position)
        {
            Handles.DrawWireDisc(position, Vector3.up, Distance, 0);
            foreach (KaijuAgent agent in _interacting)
            {
                Vector3 b = agent;
                Handles.DrawLine(position, b);
            }
        }
#endif
        /// <summary>
        /// Get a description of the object.
        /// </summary>
        /// <returns>A description of the object.</returns>
        public override string ToString()
        {
            return $"Kaiju Separation Movement - Agent: {(Agent ? Agent.name : "None")} - Distance: {Distance} - Coefficient: {Coefficient} - Weight: {Weight} - {(Done() ? "Done" : "Executing")}";
        }
    }
}