#if COM_UNITY_BEHAVIOR
using System;
using Unity.Behavior;
using Unity.Properties;
using UnityEngine;

namespace KaijuSolutions.Agents.Behavior.Movement
{
    /// <summary>
    /// Action to set the move speed of a <see cref="KaijuAgentGraphAction.agent"/>.
    /// </summary>
    [Serializable]
    [GeneratePropertyBag]
    [NodeDescription(
        name: "Move Speed",
        story: "Set [agent]'s move speed to [moveSpeed].",
        description: "Set the move speed of an agent. If the agent is not assigned, it will try to find an agent variable. If none are found, it will try to find an agent attached to any other component and create a variable from it.",
        category: "Kaiju Agents/Movement/Configuration",
        id: "9e202450dff3a82616371d1145413765",
        icon: "Packages/ca.kaijusolutions.agents/Editor/Icon.png")
    ]
    public class KaijuMoveSpeedAction : KaijuAgentGraphAction
    {
        /// <summary>
        /// The speed to move at.
        /// </summary>
        [Tooltip("The move speed to set.")]
        [SerializeReference]
        public BlackboardVariable<float> moveSpeed;
        
        /// <summary>
        /// OnStart is called when the node starts running.
        /// </summary>
        /// <returns>The status of the node.</returns>
        protected override Status OnStart()
        {
            // Nothing to do if no agent or target.
            if (base.OnStart() != Status.Success || moveSpeed == null)
            {
                return Status.Failure;
            }
            
            agent.Value.MoveSpeed = moveSpeed.Value;
            return Status.Success;
        }
    }
}
#endif