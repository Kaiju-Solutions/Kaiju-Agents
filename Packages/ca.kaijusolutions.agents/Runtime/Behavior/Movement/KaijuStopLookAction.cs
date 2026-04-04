#if COM_UNITY_BEHAVIOR
using System;
using Unity.Behavior;
using Unity.Properties;

namespace KaijuSolutions.Agents.Behavior.Movement
{
    /// <summary>
    /// Action to stop a <see cref="KaijuAgentGraphAction.agent"/> from explicitly looking at a target.
    /// </summary>
    [Serializable]
    [GeneratePropertyBag]
    [NodeDescription(
        name: "Stop Looking",
        story: "Have [agent] stop explicitly looking.",
        description: "Have an agent stop looking at an explicit target. This will report a failure if the agent is not currently looking at an explicit target. If the agent is not assigned, it will try to find an agent variable. If none are found, it will try to find an agent attached to any other component and create a variable from it.",
        category: "Kaiju Agents/Movement/Look",
        id: "9e202450dff3a82616371d1145413763",
        icon: "Packages/ca.kaijusolutions.agents/Editor/Icon.png")
    ]
    public class KaijuStopLookAction : KaijuAgentGraphAction
    {
        /// <summary>
        /// OnStart is called when the node starts running.
        /// </summary>
        /// <returns>The status of the node.</returns>
        protected override Status OnStart()
        {
            // Nothing to do if no agent or target.
            if (base.OnStart() != Status.Success || !agent.Value.Looking)
            {
                return Status.Failure;
            }
            
            agent.Value.StopLooking();
            return Status.Success;
        }
    }
}
#endif