#if COM_UNITY_BEHAVIOR
using System;
using KaijuSolutions.Agents.Exercises.Microbes;
using Unity.Behavior;
using Unity.Properties;
using UnityEngine;

namespace KaijuSolutions.Agents.Behavior.Exercises.Microbes
{
    /// <summary>
    /// Action to sense a mate with a <see cref="MicrobeVisionSensor"/> which could have multiple readings of <see cref="Microbe"/>s.
    /// </summary>
    [Serializable]
    [GeneratePropertyBag]
    [NodeDescription(
        name: "Mate Vision Sense",
        story: "See [observed] mate with microbes [sensor].",
        description: "Sense for any microbe to mate with using a microbes vision sensor. The minimum cooldown time on the microbe to consider can be specified. If the sensor is not assigned, will try to find the first sensor of this type on of the first agent variable found.",
        category: "Kaiju Agents/Microbes",
        id: "9e202450dff3a82616371d1145413782",
        icon: "Packages/ca.kaijusolutions.agents/Editor/Icon.png")
    ]
    public class MateVisionSensorAction : FilterMicrobeVisionSensorAction
    {
        /// <summary>
        /// The minimum <see cref="Microbe.Cooldown"/> to accept.
        /// </summary>
        [SerializeReference]
        public BlackboardVariable<float> cooldown = new(float.MaxValue);
        
        /// <summary>
        /// How to filter for <see cref="Microbe"/>s.
        /// </summary>
        /// <param name="microbe">The <see cref="Microbe"/> being checked.</param>
        /// <returns>If this passed the filter or not.</returns>
        protected override bool FilterCondition(Microbe microbe)
        {
            return Current.Compatible(microbe) && (cooldown == null || microbe.Cooldown <= cooldown.Value);
        }
        
        /// <summary>
        /// Get a description of the object.
        /// </summary>
        /// <returns>A description of the object.</returns>
        public override string ToString()
        {
            return $"Mate Vision Sensor Action - Sensor: {(sensor.Value ? sensor.Value : "None")} - Observed: {(observed.Value ? observed.Value : "None")} - {(nearest.Value ? "Nearest" : "Farthest")}";
        }
    }
}
#endif