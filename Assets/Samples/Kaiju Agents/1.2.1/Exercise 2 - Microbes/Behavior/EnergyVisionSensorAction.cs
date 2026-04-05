#if COM_UNITY_BEHAVIOR
using System;
using KaijuSolutions.Agents.Behavior.Sensors;
using KaijuSolutions.Agents.Exercises.Microbes;
using Unity.Behavior;
using Unity.Properties;

namespace KaijuSolutions.Agents.Behavior.Exercises.Microbes
{
    /// <summary>
    /// Action to sense with an <see cref="EnergyVisionSensor"/> which could have multiple readings of <see cref="EnergyPickup"/>s.
    /// </summary>
    [Serializable]
    [GeneratePropertyBag]
    [NodeDescription(
        name: "Energy Vision Sense",
        story: "See [observed] with energy [sensor].",
        description: "Sense for any energy pickups using an energy vision sensor. If the sensor is not assigned, will try to find the first sensor of this type on of the first agent variable found.",
        category: "Kaiju Agents/Microbes",
        id: "9e202450dff3a82616371d1145413775",
        icon: "Packages/ca.kaijusolutions.agents/Editor/Icon.png")
    ]
    public class EnergyVisionSensorAction : KaijuVisionSensorAction<EnergyVisionSensor, EnergyPickup>
    {
        /// <summary>
        /// Get a description of the object.
        /// </summary>
        /// <returns>A description of the object.</returns>
        public override string ToString()
        {
            return $"Energy Vision Sensor Action - Sensor: {(sensor.Value ? sensor.Value : "None")} - Observed: {(observed.Value ? observed.Value : "None")} - {(nearest.Value ? "Nearest" : "Farthest")}";
        }
    }
}
#endif