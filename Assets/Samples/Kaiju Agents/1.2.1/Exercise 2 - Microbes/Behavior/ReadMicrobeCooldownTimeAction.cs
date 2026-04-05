#if COM_UNITY_BEHAVIOR
using System;
using KaijuSolutions.Agents.Exercises.Microbes;
using Unity.Behavior;
using Unity.Properties;
using UnityEngine;

namespace KaijuSolutions.Agents.Behavior.Exercises.Microbes
{
    /// <summary>
    /// Read the <see cref="Microbe.Cooldown"/> of <see cref="ReadMicrobeAction.microbe"/>.
    /// </summary>
    [Serializable]
    [GeneratePropertyBag]
    [NodeDescription(
        name: "Get Cooldown Time",
        story: "Get the [cooldownTime] of [microbe].",
        description: "Get the cooldown time of a microbe. If the microbe is not assigned, will try to find a variable of one or one attached to one.",
        category: "Kaiju Agents/Microbes",
        id: "9e202450dff3a82616371d1145413785",
        icon: "Packages/ca.kaijusolutions.agents/Editor/Icon.png")
    ]
    public class ReadMicrobeCooldownTimeAction : ReadMicrobeAction
    {
        /// <summary>
        /// The cooldown time of the <see cref="ReadMicrobeAction.microbe"/>.
        /// </summary>
        [Tooltip("The cooldown time of the microbe.")]
        [SerializeReference]
        public BlackboardVariable<float> cooldownTime;
        
        /// <summary>
        /// If this has been validly assigned.
        /// </summary>
        /// <returns>If this has been validly assigned.</returns>
        protected override bool Assigned()
        {
            return cooldownTime != null;
        }
        
        /// <summary>
        /// Read the needed value.
        /// </summary>
        protected override void ReadValue()
        {
            cooldownTime.Value = microbe.Value.Cooldown;
        }
        
        /// <summary>
        /// Get a description of the object.
        /// </summary>
        /// <returns>A description of the object.</returns>
        public override string ToString()
        {
            return $"Read Microbe Cooldown Time Action - Microbe: {(microbe.Value ? microbe.Value : "None")} - Cooldown Time: {cooldownTime.Value}";
        }
    }
}
#endif