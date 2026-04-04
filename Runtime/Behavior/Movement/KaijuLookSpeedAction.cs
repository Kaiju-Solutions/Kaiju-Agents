#if COM_UNITY_BEHAVIOR
using System;
using Unity.Behavior;
using Unity.Properties;
using UnityEngine;

namespace KaijuSolutions.Agents.Behavior.Movement
{
    /// <summary>
    /// Action to set the look speed of a <see cref="KaijuAgentGraphAction.agent"/>.
    /// </summary>
    [Serializable]
    [GeneratePropertyBag]
    [NodeDescription(
        name: "Look Speed",
        story: "Set [agent]'s look speed to [lookSpeed].",
        description: "Set the look speed of an agent. If the agent is not assigned, it will try to find an agent variable. If none are found, it will try to find an agent attached to any other component and create a variable from it.",
        category: "Kaiju Agents/Movement/Configuration",
        id: "9e202450dff3a82616371d1145413767",
        icon: "Packages/ca.kaijusolutions.agents/Editor/Icon.png")
    ]
    public class KaijuLookSpeedAction : KaijuAgentGraphAction
    {
        /// <summary>
        /// The speed to look at.
        /// </summary>
        [Tooltip("The look speed to set.")]
        [SerializeReference]
        public BlackboardVariable<float> lookSpeed;
        
        /// <summary>
        /// OnStart is called when the node starts running.
        /// </summary>
        /// <returns>The status of the node.</returns>
        protected override Status OnStart()
        {
            // Nothing to do if no agent or target.
            if (base.OnStart() != Status.Success || lookSpeed == null)
            {
                return Status.Failure;
            }
            
            agent.Value.LookSpeed = lookSpeed.Value;
            return Status.Success;
        }
        
        /// <summary>
        /// Get a description of the object.
        /// </summary>
        /// <returns>A description of the object.</returns>
        public override string ToString()
        {
            return $"Kaiju Look Speed Action - Agent: {(agent.Value ? agent.Value : "None")} - Speed: {lookSpeed.Value}";
        }
    }
}
#endif