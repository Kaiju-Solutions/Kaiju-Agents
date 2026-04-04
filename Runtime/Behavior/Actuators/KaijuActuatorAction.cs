#if COM_UNITY_BEHAVIOR
using System;
using System.Collections.Generic;
using System.Linq;
using KaijuSolutions.Agents.Actuators;
using Unity.Behavior;
using Unity.Properties;
using UnityEngine;
using Action = Unity.Behavior.Action;

namespace KaijuSolutions.Agents.Behavior.Actuators
{
    /// <summary>
    /// Base class for actuator actions.
    /// </summary>
    [Serializable]
    [GeneratePropertyBag]
    public abstract class KaijuActuatorAction : Action
    {
        /// <summary>
        /// The actuator this is for.
        /// </summary>
        [Tooltip("The actuator. If not assigned, will try to find the first actuator of the first agent variable found.")]
        [SerializeReference]
        public BlackboardVariable<KaijuActuator> actuator;
        
        /// <summary>
        /// OnStart is called when the node starts running.
        /// </summary>
        /// <returns>The status of the node.</returns>
        protected override Status OnStart()
        {
            return ValidActuator() ? Status.Success : Status.Failure;
        }
        
        /// <summary>
        /// OnUpdate is called each frame while the node is running.
        /// </summary>
        /// <returns>The status of the node.</returns>
        protected override Status OnUpdate()
        {
            return ValidActuator() ? Status.Success : Status.Failure;
        }
        
        /// <summary>
        /// See if this actuator is valid or not.
        /// </summary>
        /// <returns>If the actuator is valid or not.</returns>
        protected bool ValidActuator()
        {
            actuator ??= new();
            
            // If there is no actuator, try and get one from an agent.
            if (!actuator.Value)
            {
                BlackboardVariable<KaijuAgent> agent = KaijuAgentGraphAction.EnsureAgent(GameObject);
                if (agent == null || !agent.Value)
                {
                    return false;
                }
                
                // Get all actuators.
                IReadOnlyCollection<KaijuActuator> actuators = agent.Value.Actuators;
                if (actuators.Count < 1)
                {
                    return false;
                }
                
                // Assign the first actuator.
                actuator.Value = actuators.First();
            }
            
            // The actuator and agent must be active.
            return actuator.Value && actuator.Value.Agent;
        }
        
        /// <summary>
        /// Get a description of the object.
        /// </summary>
        /// <returns>A description of the object.</returns>
        public override string ToString()
        {
            return $"Kaiju Actuator Action - Actuator: {(actuator.Value ? actuator.Value : "None")}";
        }
    }
}
#endif