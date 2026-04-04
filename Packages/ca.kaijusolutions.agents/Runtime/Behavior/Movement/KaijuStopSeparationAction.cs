#if COM_UNITY_BEHAVIOR
using System;
using KaijuSolutions.Agents.Movement;
using Unity.Behavior;
using Unity.Properties;

namespace KaijuSolutions.Agents.Behavior.Movement
{
    /// <summary>
    /// Action to stop all separation movements of a <see cref="KaijuAgentGraphAction.agent"/>.
    /// </summary>
    [Serializable]
    [GeneratePropertyBag]
    [NodeDescription(
        name: "Stop Separations",
        story: "Stop all separation movements on [agent].",
        description: "Stop all separation movements on an agent. This will report a failure if the agent is not currently separating. This will report a failure if the agent is not currently moving. If the agent is not assigned, it will try to find an agent variable. If none are found, it will try to find an agent attached to any other component and create a variable from it.",
        category: "Kaiju Agents/Movement/Stop",
        id: "9e202450dff3a82616371d1145413757",
        icon: "Packages/ca.kaijusolutions.agents/Editor/Icon.png")
    ]
    public class KaijuStopSeparationAction : KaijuStopTypeAction<KaijuSeparationMovement> { }
}
#endif