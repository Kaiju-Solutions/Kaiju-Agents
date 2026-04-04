#if COM_UNITY_BEHAVIOR
using System;
using Unity.Behavior;
using Unity.Properties;
using UnityEngine;

namespace KaijuSolutions.Agents.Behavior.Movement
{
    /// <summary>
    /// Action to have a <see cref="KaijuAgentGraphAction.agent"/> look at a target.
    /// </summary>
    [Serializable]
    [GeneratePropertyBag]
    [NodeDescription(
        name: "Look At",
        story: "Have [agent] look at [target].",
        description: "Have an agent look at a target. If the agent is not assigned, it will try to find an agent variable. If none are found, it will try to find an agent attached to any other component and create a variable from it.",
        category: "Kaiju Agents/Movement/Look",
        id: "9e202450dff3a82616371d1145413762",
        icon: "Packages/ca.kaijusolutions.agents/Editor/Icon.png")
    ]
    public class KaijuLookAction : KaijuAgentGraphAction
    {
        /// <summary>
        /// The target for the <see cref="KaijuAgentGraphAction.agent"/> to look at.
        /// </summary>
        [Tooltip("The target to look at.")]
        [SerializeReference]
        public BlackboardVariable<Transform> target;
        
        /// <summary>
        /// OnStart is called when the node starts running.
        /// </summary>
        /// <returns>The status of the node.</returns>
        protected override Status OnStart()
        {
            // Nothing to do if no agent or target.
            if (base.OnStart() != Status.Success || target == null || !target.Value)
            {
                return Status.Failure;
            }
            
            agent.Value.LookTransform = target.Value;
            return Status.Success;
        }
        
        /// <summary>
        /// Get a description of the object.
        /// </summary>
        /// <returns>A description of the object.</returns>
        public override string ToString()
        {
            return $"Kaiju Look Action - Agent: {(agent.Value ? agent.Value : "None")} - Target: {(target.Value ? target.Value : "None")}";
        }
    }
}
#endif