#if COM_UNITY_BEHAVIOR
using System;
using KaijuSolutions.Agents.Sensors;
using Unity.Behavior;
using Unity.Properties;
using UnityEngine;

namespace KaijuSolutions.Agents.Behavior.Sensors
{
    /// <summary>
    /// Action to sense with an everything vision sensor which could have multiple readings of <see href="https://docs.unity3d.com/Manual/class-transform.html">transform</see>s.
    /// </summary>
    [Serializable]
    [GeneratePropertyBag]
    [NodeDescription(
        name: "Everything Vision Sense",
        story: "See [observed] with everything [sensor].",
        description:
        "Sense for any transform using an everything vision sensor. If the sensor is not assigned, will try to find the first sensor of this type on of the first agent variable found.",
        category: "Kaiju Agents/Sensors",
        id: "9e202450dff3a82616371d1145413749",
        icon: "Packages/ca.kaijusolutions.agents/Editor/Icon.png")
    ]
    public class KaijuEverythingVisionSensorAction : KaijuVisionSensorAction<KaijuEverythingVisionSensor, Transform>
    {
        /// <summary>
        /// Get a description of the object.
        /// </summary>
        /// <returns>A description of the object.</returns>
        public override string ToString()
        {
            return $"Kaiju Everything Vision Sensor Action - Sensor: {(sensor.Value ? sensor.Value : "None")} - Observed: {(observed.Value ? observed.Value : "None")} - {(nearest.Value ? "Nearest" : "Farthest")}";
        }
    }
}
#endif