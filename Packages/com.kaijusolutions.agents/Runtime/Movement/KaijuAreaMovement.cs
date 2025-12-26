using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif
namespace KaijuSolutions.Agents.Movement
{
    /// <summary>
    /// Movement which looks for handling other agents in a given area.
    /// </summary>
    public abstract class KaijuAreaMovement : KaijuMovement
    {
        /// <summary>
        /// The distance to interact with other agents from.
        /// </summary>
        public float Distance
        {
            get => _distance;
            set => _distance = Mathf.Max(value, float.Epsilon);
        }
        
        /// <summary>
        /// The distance to interact with other agents from.
        /// </summary>
        private float _distance = float.MaxValue;
        
        /// <summary>
        /// What types of agents to avoid.
        /// </summary>
        public readonly HashSet<uint> Identifiers = new();
        
        /// <summary>
        /// Clear all identifiers of agents to interact with.
        /// </summary>
        public void ClearIdentifiers()
        {
            Identifiers.Clear();
        }
        
        /// <summary>
        /// Set the identifier of agents to interact with.
        /// </summary>
        /// <param name="identifier">The identifier to set.</param>
        public void SetIdentifier(uint identifier)
        {
            ClearIdentifiers();
            AddIdentifier(identifier);
        }
        
        /// <summary>
        /// Set the identifier of agents to interact with.
        /// </summary>
        /// <param name="identifiers">The identifiers to set.</param>
        public void SetIdentifiers([NotNull] ICollection<uint> identifiers)
        {
            ClearIdentifiers();
            AddIdentifiers(identifiers);
        }
        
        /// <summary>
        /// Add an identifier for agents to interact with.
        /// </summary>
        /// <param name="identifier">The identifier to add.</param>
        /// <returns>If the identifier was added.</returns>
        public bool AddIdentifier(uint identifier)
        {
            return Identifiers.Add(identifier);
        }
        
        /// <summary>
        /// Add identifiers for agents to interact with.
        /// </summary>
        /// <param name="identifiers">The identifiers to add.</param>
        /// <returns>If any of the identifiers were added.</returns>
        public bool AddIdentifiers([NotNull] ICollection<uint> identifiers)
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
        /// Remove an identifier for agents to interact with.
        /// </summary>
        /// <param name="identifier">The identifier to remove.</param>
        /// <returns>If the identifier was removed.</returns>
        public bool RemoveIdentifier(uint identifier)
        {
            return Identifiers.Remove(identifier);
        }
        
        /// <summary>
        /// Remove identifiers for agents to interact with.
        /// </summary>
        /// <param name="identifiers">The identifiers to remove.</param>
        /// <returns>If any of the identifiers were removed.</returns>
        public bool RemoveIdentifiers([NotNull] ICollection<uint> identifiers)
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
        /// Get an area movement.
        /// </summary>
        /// <param name="agent">The agent this is assigned to.</param>
        /// <param name="distance">The distance to avoid other agents from.</param>
        /// <param name="identifiers">What types of agents to avoid.</param>
        /// <param name="weight">The weight of this movement.</param>
        /// <returns>Get an area movement for the agent.</returns>
        public KaijuAreaMovement(KaijuAgent agent, float distance = 10, ICollection<uint> identifiers = null, float weight = 1) : base(agent, weight)
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
        protected void Initialize(KaijuAgent agent, float distance = 10, ICollection<uint> identifiers = null, float weight = 1)
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
#if UNITY_EDITOR
        /// <summary>
        /// Render the visualization of the movement.
        /// </summary>
        protected override void RenderVisualizations()
        {
            Handles.DrawWireDisc(Agent, Vector3.up, Distance, 0);
        }
#endif
        /// <summary>
        /// Get a description of the object.
        /// </summary>
        /// <returns>A description of the object.</returns>
        public override string ToString()
        {
            return $"Kaiju Area Movement - Agent: {(Agent ? Agent.name : "None")} - Distance: {Distance} - Weight: {Weight} - {(Done() ? "Done" : "Executing")}";
        }
    }
}