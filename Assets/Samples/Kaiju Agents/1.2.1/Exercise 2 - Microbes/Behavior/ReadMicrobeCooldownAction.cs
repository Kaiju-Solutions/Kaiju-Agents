#if COM_UNITY_BEHAVIOR
using System;
using KaijuSolutions.Agents.Exercises.Microbes;
using Unity.Behavior;
using Unity.Properties;
using UnityEngine;

namespace KaijuSolutions.Agents.Behavior.Exercises.Microbes
{
    /// <summary>
    /// Read if <see cref="ReadMicrobeAction.microbe"/> is <see cref="Microbe.OnCooldown"/>.
    /// </summary>
    [Serializable]
    [GeneratePropertyBag]
    [NodeDescription(
        name: "Get On Cooldown",
        story: "Get if [microbe] is [onCooldown].",
        description: "Get if a microbe is on cooldown. If the microbe is not assigned, will try to find a variable of one or one attached to one.",
        category: "Kaiju Agents/Microbes",
        id: "9e202450dff3a82616371d1145413786",
        icon: "Packages/ca.kaijusolutions.agents/Editor/Icon.png")
    ]
    public class ReadMicrobeCooldownAction : ReadMicrobeAction
    {
        /// <summary>
        /// If the <see cref="ReadMicrobeAction.microbe"/> is on cooldown.
        /// </summary>
        [Tooltip("If the microbe is on cooldown.")]
        [SerializeReference]
        public BlackboardVariable<bool> onCooldown;
        
        /// <summary>
        /// If this has been validly assigned.
        /// </summary>
        /// <returns>If this has been validly assigned.</returns>
        protected override bool Assigned()
        {
            return onCooldown != null;
        }
        
        /// <summary>
        /// Read the needed value.
        /// </summary>
        protected override void ReadValue()
        {
            onCooldown.Value = microbe.Value.OnCooldown;
        }
    }
}
#endif