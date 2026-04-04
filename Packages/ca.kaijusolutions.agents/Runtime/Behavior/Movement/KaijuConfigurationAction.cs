#if COM_UNITY_BEHAVIOR
using System;
using KaijuSolutions.Agents.Movement;
using Unity.Behavior;
using Unity.Properties;
using UnityEngine;

namespace KaijuSolutions.Agents.Behavior.Movement
{
    /// <summary>
    /// Action to set the movement configuration of a <see cref="KaijuAgentGraphAction.agent"/>.
    /// </summary>
    [Serializable]
    [GeneratePropertyBag]
    [NodeDescription(
        name: "Configuration",
        story: "Set [agent] to [configuration].",
        description: "Set the movement configuration of an agent. If the agent is not assigned, it will try to find an agent variable. If none are found, it will try to find an agent attached to any other component and create a variable from it.",
        category: "Kaiju Agents/Movement/Configuration",
        id: "9e202450dff3a82616371d1145413768",
        icon: "Packages/ca.kaijusolutions.agents/Editor/Icon.png")
    ]
    public class KaijuConfigurationAction : KaijuAgentGraphAction
    {
        /// <summary>
        /// The movement configuration to set.
        /// </summary>
        [Tooltip("Move movement configuration to set.")]
        [SerializeReference]
        public BlackboardVariable<KaijuMovementConfiguration> configuration;
        
        /// <summary>
        /// OnStart is called when the node starts running.
        /// </summary>
        /// <returns>The status of the node.</returns>
        protected override Status OnStart()
        {
            // Nothing to do if no agent or target.
            if (base.OnStart() != Status.Success || configuration == null)
            {
                return Status.Failure;
            }
            
            agent.Value.configuration = configuration.Value;
            return Status.Success;
        }
        
        /// <summary>
        /// Get a description of the object.
        /// </summary>
        /// <returns>A description of the object.</returns>
        public override string ToString()
        {
            return $"Kaiju Configuration Action - Agent: {(agent.Value ? agent.Value : "None")} - Configuration: {(configuration.Value ? configuration.Value : "None")}";
        }
    }
}
#endif