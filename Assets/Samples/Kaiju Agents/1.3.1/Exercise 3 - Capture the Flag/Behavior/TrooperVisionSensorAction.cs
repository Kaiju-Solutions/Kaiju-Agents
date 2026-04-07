#if COM_UNITY_BEHAVIOR
using System;
using KaijuSolutions.Agents.Behavior.Sensors;
using KaijuSolutions.Agents.Exercises.CTF;
using Unity.Behavior;
using Unity.Properties;

namespace KaijuSolutions.Agents.Behavior.Exercises.CTF
{
    /// <summary>
    /// Action to sense with a <see cref="TrooperVisionSensor"/> which could have multiple readings of <see cref="Trooper"/>s.
    /// </summary>
    [Serializable]
    [GeneratePropertyBag]
    [NodeDescription(
        name: "Troopers Vision Sense",
        story: "See [observed] with troopers [sensor].",
        description: "Sense for any troopers using a trooper vision sensor. If the sensor is not assigned, will try to find the first sensor of this type on of the first agent variable found.",
        category: "Kaiju Agents/Capture the Flag",
        id: "9e202450dff3a82616371d1145413776",
        icon: "Packages/ca.kaijusolutions.agents/Editor/Icon.png")
    ]
    public class TrooperVisionSensorAction : KaijuVisionSensorAction<TrooperVisionSensor, Trooper>
    {
        /// <summary>
        /// Get a description of the object.
        /// </summary>
        /// <returns>A description of the object.</returns>
        public override string ToString()
        {
            return $"Trooper Vision Sensor Action - Sensor: {(sensor.Value ? sensor.Value : "None")} - Observed: {(observed.Value ? observed.Value : "None")} - {(nearest.Value ? "Nearest" : "Farthest")}";
        }
    }
}
#endif