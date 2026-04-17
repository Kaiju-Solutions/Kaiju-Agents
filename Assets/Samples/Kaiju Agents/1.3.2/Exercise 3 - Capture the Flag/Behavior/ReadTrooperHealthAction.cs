#if COM_UNITY_BEHAVIOR
using System;
using Unity.Behavior;
using Unity.Properties;
using UnityEngine;

namespace KaijuSolutions.Agents.Behavior.Exercises.CTF
{
    /// <summary>
    /// Read a <see cref="ReadTrooperAction.trooper"/>'s health.
    /// </summary>
    [Serializable]
    [GeneratePropertyBag]
    [NodeDescription(
        name: "Get Trooper Health",
        story: "Get the [health] of [trooper].",
        description: "Get the health of a trooper. If the trooper is not assigned, will try to find a variable of one or one attached to one.",
        category: "Kaiju Agents/Capture the Flag",
        id: "9e202450dff3a82616371d1145413790",
        icon: "Packages/ca.kaijusolutions.agents/Editor/Icon.png")
    ]
    public class ReadTrooperHealthAction : ReadTrooperAction
    {
        /// <summary>
        /// The health of the <see cref="ReadTrooperAction.trooper"/>.
        /// </summary>
        [Tooltip("The health of the trooper.")]
        [SerializeReference]
        public BlackboardVariable<int> health;
        
        /// <summary>
        /// If this has been validly assigned.
        /// </summary>
        /// <returns>If this has been validly assigned.</returns>
        protected override bool Assigned()
        {
            return health != null;
        }
        
        /// <summary>
        /// Read the needed value.
        /// </summary>
        protected override void ReadValue()
        {
            health.Value = trooper.Value.Health;
        }
        
        /// <summary>
        /// Get a description of the object.
        /// </summary>
        /// <returns>A description of the object.</returns>
        public override string ToString()
        {
            return $"Read Trooper Health Action - Trooper: {(trooper.Value ? trooper.Value : "None")} - Health: {health.Value}";
        }
    }
}
#endif