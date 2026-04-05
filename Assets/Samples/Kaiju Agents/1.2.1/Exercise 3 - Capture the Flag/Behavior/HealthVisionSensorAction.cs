#if COM_UNITY_BEHAVIOR
using System;
using KaijuSolutions.Agents.Behavior.Sensors;
using KaijuSolutions.Agents.Exercises.CTF;
using Unity.Behavior;
using Unity.Properties;

namespace KaijuSolutions.Agents.Behavior.Exercises.CTF
{
    /// <summary>
    /// Action to sense with a <see cref="HealthVisionSensor"/> which could have multiple readings of <see cref="HealthPickup"/>s.
    /// </summary>
    [Serializable]
    [GeneratePropertyBag]
    [NodeDescription(
        name: "Health Vision Sense",
        story: "See [observed] with health [sensor].",
        description: "Sense for any health pickups using a health vision sensor. If the sensor is not assigned, will try to find the first sensor of this type on of the first agent variable found.",
        category: "Kaiju Agents/Capture the Flag",
        id: "9e202450dff3a82616371d1145413778",
        icon: "Packages/ca.kaijusolutions.agents/Editor/Icon.png")
    ]
    public class HealthVisionSensorAction : KaijuVisionSensorAction<HealthVisionSensor, HealthPickup>
    {
        
        /// <summary>
        /// Get a description of the object.
        /// </summary>
        /// <returns>A description of the object.</returns>
        public override string ToString()
        {
            return $"Flag Vision Sensor Action - Sensor: {(sensor.Value ? sensor.Value : "None")} - Observed: {(observed.Value ? observed.Value : "None")} - {(nearest.Value ? "Nearest" : "Farthest")}";
        }
    }
}
#endif