#if COM_UNITY_BEHAVIOR
using System;
using Unity.Behavior;
using Unity.Properties;
using UnityEngine;

namespace KaijuSolutions.Agents.Behavior.Movement
{
    /// <summary>
    /// Action to set the move acceleration of a <see cref="KaijuAgentGraphAction.agent"/>.
    /// </summary>
    [Serializable]
    [GeneratePropertyBag]
    [NodeDescription(
        name: "Move Acceleration",
        story: "Set [agent]'s move acceleration to [moveAcceleration].",
        description: "Set the move acceleration of an agent. If the agent is not assigned, it will try to find an agent variable. If none are found, it will try to find an agent attached to any other component and create a variable from it.",
        category: "Kaiju Agents/Movement/Configuration",
        id: "9e202450dff3a82616371d1145413766",
        icon: "Packages/ca.kaijusolutions.agents/Editor/Icon.png")
    ]
    public class KaijuMoveAccelerationAction : KaijuAgentGraphAction
    {
        /// <summary>
        /// The acceleration to move at.
        /// </summary>
        [Tooltip("The move acceleration to set.")]
        [SerializeReference]
        public BlackboardVariable<float> moveAcceleration;
        
        /// <summary>
        /// OnStart is called when the node starts running.
        /// </summary>
        /// <returns>The status of the node.</returns>
        protected override Status OnStart()
        {
            // Nothing to do if no agent or target.
            if (base.OnStart() != Status.Success || moveAcceleration == null)
            {
                return Status.Failure;
            }
            
            agent.Value.MoveAcceleration = moveAcceleration.Value;
            return Status.Success;
        }
    }
}
#endif