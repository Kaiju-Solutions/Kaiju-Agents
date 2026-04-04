#if COM_UNITY_BEHAVIOR
using System;
using KaijuSolutions.Agents.Sensors;
using Unity.Behavior;
using Unity.Properties;

namespace KaijuSolutions.Agents.Behavior.Sensors
{
    /// <summary>
    /// Action to sense with an agents vision sensor which could have multiple readings of agents.
    /// </summary>
    [Serializable]
    [GeneratePropertyBag]
    [NodeDescription(
        name: "Agents Vision Sense",
        story: "See [observed] with agents [sensor].",
        description: "Sense for any transform using an agents vision sensor. If the sensor is not assigned, will try to find the first sensor of this type on of the first agent variable found.",
        category: "Kaiju Agents/Sensors",
        id: "9e202450dff3a82616371d1145413750",
        icon: "Packages/ca.kaijusolutions.agents/Editor/Icon.png")
    ]
    public class KaijuAgentsVisionSensorAction : KaijuVisionSensorAction<KaijuAgentsVisionSensor, KaijuAgent> { }
}
#endif