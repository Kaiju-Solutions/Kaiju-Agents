#if COM_UNITY_BEHAVIOR
using System;
using Unity.Behavior;
using Unity.Properties;
using UnityEngine;

namespace KaijuSolutions.Agents.Behavior.Movement
{
    /// <summary>
    /// Action to teleport a <see cref="KaijuAgentGraphAction.agent"/>.
    /// </summary>
    [Serializable]
    [GeneratePropertyBag]
    [NodeDescription(
        name: "Teleport",
        story: "Teleport an [agent] to a [target].",
        description: "Teleport an agent to a target. If the agent is not assigned, it will try to find an agent variable. If none are found, it will try to find an agent attached to any other component and create a variable from it.",
        category: "Kaiju Agents/Movement",
        id: "9e202450dff3a82616371d1145413761",
        icon: "Packages/ca.kaijusolutions.agents/Editor/Icon.png")
    ]
    public class KaijuTeleportAction : KaijuAgentGraphAction
    {
        /// <summary>
        /// The target for the <see cref="KaijuAgentGraphAction.agent"/> to teleport to.
        /// </summary>
        [Tooltip("The target to teleport to.")]
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
            
            agent.Value.Position3 = target.Value.position;
            return Status.Success;
        }
    }
}
#endif