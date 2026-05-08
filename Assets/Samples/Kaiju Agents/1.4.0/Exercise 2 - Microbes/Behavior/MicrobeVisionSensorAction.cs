#if COM_UNITY_BEHAVIOR
using System;
using KaijuSolutions.Agents.Behavior.Sensors;
using KaijuSolutions.Agents.Exercises.Microbes;
using Unity.Behavior;
using Unity.Properties;

namespace KaijuSolutions.Agents.Behavior.Exercises.Microbes
{
    /// <summary>
    /// Action to sense with a <see cref="MicrobeVisionSensor"/> which could have multiple readings of <see cref="Microbe"/>s.
    /// </summary>
    [Serializable]
    [GeneratePropertyBag]
    [NodeDescription(
        name: "Microbes Vision Sense",
        story: "See [observed] with microbes [sensor].",
        description: "Sense for any microbe using a microbes vision sensor. If the sensor is not assigned, will try to find the first sensor of this type on of the first agent variable found.",
        category: "Kaiju Agents/Microbes",
        id: "9e202450dff3a82616371d1145413774",
        icon: "Packages/ca.kaijusolutions.agents/Editor/Icon.png")
    ]
    public class MicrobeVisionSensorAction : KaijuVisionSensorAction<MicrobeVisionSensor, Microbe>
    {
        /// <summary>
        /// Get a description of the object.
        /// </summary>
        /// <returns>A description of the object.</returns>
        public override string ToString()
        {
            return $"Microbe Vision Sensor Action - Sensor: {(sensor.Value ? sensor.Value : "None")} - Observed: {(observed.Value ? observed.Value : "None")} - {(nearest.Value ? "Nearest" : "Farthest")}";
        }
    }
}
#endif