#if COM_UNITY_BEHAVIOR
using System;
using KaijuSolutions.Agents.Movement;
using Unity.Behavior;
using Unity.Properties;

namespace KaijuSolutions.Agents.Behavior.Movement
{
    /// <summary>
    /// Action to stop all path following movements of a <see cref="KaijuAgentGraphAction.agent"/>.
    /// </summary>
    [Serializable]
    [GeneratePropertyBag]
    [NodeDescription(
        name: "Stop Path Follows",
        story: "Stop all path following movements on [agent].",
        description: "Stop all path following movements on an agent. This will report a failure if the agent is not currently following any paths. This will report a failure if the agent is not currently moving. If the agent is not assigned, it will try to find an agent variable. If none are found, it will try to find an agent attached to any other component and create a variable from it.",
        category: "Kaiju Agents/Movement/Stop",
        id: "9e202450dff3a82616371d1145413759",
        icon: "Packages/ca.kaijusolutions.agents/Editor/Icon.png")
    ]
    public class KaijuStopPathFollowAction : KaijuStopTypeAction<KaijuPathFollowMovement>
    {
        /// <summary>
        /// Get a description of the object.
        /// </summary>
        /// <returns>A description of the object.</returns>
        public override string ToString()
        {
            return "Kaiju Stop Path Follow Action";
        }
    }
}
#endif