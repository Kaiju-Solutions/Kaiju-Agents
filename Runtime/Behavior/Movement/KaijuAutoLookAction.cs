#if COM_UNITY_BEHAVIOR
using System;
using Unity.Behavior;
using Unity.Properties;
using UnityEngine;

namespace KaijuSolutions.Agents.Behavior.Movement
{
    /// <summary>
    /// Action to set if a <see cref="KaijuAgentGraphAction.agent"/> should automatically look where it is moving if there is no explicitly set target ot look at.
    /// </summary>
    [Serializable]
    [GeneratePropertyBag]
    [NodeDescription(
        name: "Auto Look",
        story: "Set [agent]'s automatic looking to [auto].",
        description: "Set if an agent should automatically look where it is moving if there is no explicitly set target to look at. If the agent is not assigned, it will try to find an agent variable. If none are found, it will try to find an agent attached to any other component and create a variable from it.",
        category: "Kaiju Agents/Movement/Look",
        id: "9e202450dff3a82616371d1145413764",
        icon: "Packages/ca.kaijusolutions.agents/Editor/Icon.png")
    ]
    public class KaijuAutoLookAction : KaijuAgentGraphAction
    {
        /// <summary>
        /// If the <see cref="KaijuAgentGraphAction.agent"/> should look at a target or not.
        /// </summary>
        [Tooltip("If the agent should automatically look where it is moving if there is no explicitly set target to look at.")]
        [SerializeReference]
        public BlackboardVariable<bool> auto;
        
        /// <summary>
        /// OnStart is called when the node starts running.
        /// </summary>
        /// <returns>The status of the node.</returns>
        protected override Status OnStart()
        {
            // Nothing to do if no agent or target.
            if (base.OnStart() != Status.Success || !agent.Value.Looking || auto == null)
            {
                return Status.Failure;
            }

            agent.Value.AutoRotate = auto.Value;
            return Status.Success;
        }
        
        /// <summary>
        /// Get a description of the object.
        /// </summary>
        /// <returns>A description of the object.</returns>
        public override string ToString()
        {
            return $"Kaiju Auto Look Action - Agent: {(agent.Value ? agent.Value : "None")} - {(auto.Value ? string.Empty : "Not ")}Automatically Looking";
        }
    }
}
#endif