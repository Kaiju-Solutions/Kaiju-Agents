#if COM_UNITY_BEHAVIOR
using System;
using KaijuSolutions.Agents.Exercises.Microbes;
using Unity.Behavior;
using Unity.Properties;
using UnityEngine;

namespace KaijuSolutions.Agents.Behavior.Exercises.Microbes
{
    /// <summary>
    /// Action to sense potential food with a <see cref="MicrobeVisionSensor"/> which could have multiple readings of <see cref="Microbe"/>s.
    /// </summary>
    [Serializable]
    [GeneratePropertyBag]
    [NodeDescription(
        name: "Food Vision Sense",
        story: "See [observed] to eat with microbes [sensor].",
        description: "Sense for any microbe to eat with using a microbes vision sensor. The maximum energy level on the microbe to consider can be specified. If the sensor is not assigned, will try to find the first sensor of this type on of the first agent variable found.",
        category: "Kaiju Agents/Microbes",
        id: "9e202450dff3a82616371d1145413783",
        icon: "Packages/ca.kaijusolutions.agents/Editor/Icon.png")
    ]
    public class FoodVisionSensorAction : FilterMicrobeVisionSensorAction
    {
        /// <summary>
        /// The maximum <see cref="Microbe.Energy"/> to accept.
        /// </summary>
        [SerializeReference]
        [Tooltip("The maximum energy to accept.")]
        public BlackboardVariable<float> energy = new(0);
        
        /// <summary>
        /// How to filter for <see cref="Microbe"/>s.
        /// </summary>
        /// <param name="microbe">The <see cref="Microbe"/> being checked.</param>
        /// <returns>If this passed the filter or not.</returns>
        protected override bool FilterCondition(Microbe microbe)
        {
            return Current.Compatible(microbe) && (energy == null || microbe.Energy >= energy.Value);
        }
    }
}
#endif