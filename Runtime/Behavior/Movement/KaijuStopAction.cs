#if COM_UNITY_BEHAVIOR
using System;
using Unity.Behavior;
using Unity.Properties;

namespace KaijuSolutions.Agents.Behavior.Movement
{
    /// <summary>
    /// Action to stop all movements of a <see cref="KaijuAgentGraphAction.agent"/>.
    /// </summary>
    [Serializable]
    [GeneratePropertyBag]
    [NodeDescription(
        name: "Stop All",
        story: "Stop all movements on [agent].",
        description: "Stop all movements on an agent. This will report a failure if the agent is not currently moving. If the agent is not assigned, it will try to find an agent variable. If none are found, it will try to find an agent attached to any other component and create a variable from it.",
        category: "Kaiju Agents/Movement/Stop",
        id: "9e202450dff3a82616371d1145413751",
        icon: "Packages/ca.kaijusolutions.agents/Editor/Icon.png")
    ]
    public class KaijuStopAction : KaijuAgentGraphAction
    {
        /// <summary>
        /// OnStart is called when the node starts running.
        /// </summary>
        /// <returns>The status of the node.</returns>
        protected override Status OnStart()
        {
            // Stop all movements if we have an agent that is moving.
            if (base.OnStart() != Status.Success || !agent.Value.Moving)
            {
                return Status.Failure;
            }
            
            agent.Value.Stop();
            return Status.Success;
        }
        
        /// <summary>
        /// Get a description of the object.
        /// </summary>
        /// <returns>A description of the object.</returns>
        public override string ToString()
        {
            return "Kaiju Stop Action";
        }
    }
}
#endif