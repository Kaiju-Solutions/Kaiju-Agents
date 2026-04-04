#if COM_UNITY_BEHAVIOR
using System;
using KaijuSolutions.Agents.Exercises.Microbes;
using Unity.Behavior;
using Unity.Properties;
using UnityEngine;

namespace KaijuSolutions.Agents.Behavior.Exercises.Microbes
{
    /// <summary>
    /// Read the <see cref="Microbe.Energy"/> of <see cref="ReadMicrobeAction.microbe"/>.
    /// </summary>
    [Serializable]
    [GeneratePropertyBag]
    [NodeDescription(
        name: "Get Energy",
        story: "Get the [energy] of [microbe].",
        description: "Get the energy of a microbe. If the microbe is not assigned, will try to find a variable of one or one attached to one.",
        category: "Kaiju Agents/Microbes",
        id: "9e202450dff3a82616371d1145413784",
        icon: "Packages/ca.kaijusolutions.agents/Editor/Icon.png")
    ]
    public class ReadMicrobeEnergyAction : ReadMicrobeAction
    {
        /// <summary>
        /// The energy of the <see cref="ReadMicrobeAction.microbe"/>.
        /// </summary>
        [Tooltip("The energy of the microbe.")]
        [SerializeReference]
        public BlackboardVariable<float> energy;
        
        /// <summary>
        /// If this has been validly assigned.
        /// </summary>
        /// <returns>If this has been validly assigned.</returns>
        protected override bool Assigned()
        {
            return energy != null;
        }
        
        /// <summary>
        /// Read the needed value.
        /// </summary>
        protected override void ReadValue()
        {
            energy.Value = microbe.Value.Energy;
        }
    }
}
#endif