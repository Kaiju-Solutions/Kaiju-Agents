#if COM_UNITY_BEHAVIOR
using System;
using Unity.Behavior;
using Unity.Properties;
using UnityEngine;

namespace KaijuSolutions.Agents.Behavior.Exercises.CTF
{
    /// <summary>
    /// Read a <see cref="ReadTrooperAction.trooper"/>'s ammo.
    /// </summary>
    [Serializable]
    [GeneratePropertyBag]
    [NodeDescription(
        name: "Get Trooper Ammo",
        story: "Get the [ammo] of [trooper].",
        description: "Get the ammo of a trooper. If the trooper is not assigned, will try to find a variable of one or one attached to one.",
        category: "Kaiju Agents/Capture the Flag",
        id: "9e202450dff3a82616371d1145413791",
        icon: "Packages/ca.kaijusolutions.agents/Editor/Icon.png")
    ]
    public class ReadTrooperAmmoAction : ReadTrooperAction
    {
        /// <summary>
        /// The ammo of the <see cref="ReadTrooperAction.trooper"/>.
        /// </summary>
        [Tooltip("The ammo of the trooper.")]
        [SerializeReference]
        public BlackboardVariable<int> ammo;
        
        /// <summary>
        /// If this has been validly assigned.
        /// </summary>
        /// <returns>If this has been validly assigned.</returns>
        protected override bool Assigned()
        {
            return ammo != null;
        }
        
        /// <summary>
        /// Read the needed value.
        /// </summary>
        protected override void ReadValue()
        {
            ammo.Value = trooper.Value.Ammo;
        }
    }
}
#endif