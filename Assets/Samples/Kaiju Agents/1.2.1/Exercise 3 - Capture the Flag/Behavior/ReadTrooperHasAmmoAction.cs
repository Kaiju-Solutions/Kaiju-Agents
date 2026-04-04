#if COM_UNITY_BEHAVIOR
using System;
using Unity.Behavior;
using Unity.Properties;
using UnityEngine;

namespace KaijuSolutions.Agents.Behavior.Exercises.CTF
{
    /// <summary>
    /// Read if a <see cref="ReadTrooperAction.trooper"/> has ammo.
    /// </summary>
    [Serializable]
    [GeneratePropertyBag]
    [NodeDescription(
        name: "Get Trooper Has Ammo",
        story: "Get if a [trooper] [hasAmmo]",
        description: "Get if a trooper has ammo. If the trooper is not assigned, will try to find a variable of one or one attached to one.",
        category: "Kaiju Agents/Capture the Flag",
        id: "9e202450dff3a82616371d1145413793",
        icon: "Packages/ca.kaijusolutions.agents/Editor/Icon.png")
    ]
    public class ReadTrooperHasAmmoAction : ReadTrooperAction
    {
        /// <summary>
        /// If the <see cref="ReadTrooperAction.trooper"/> has ammo.
        /// </summary>
        [Tooltip("If the trooper has ammo.")]
        [SerializeReference]
        public BlackboardVariable<bool> hasAmmo;
        
        /// <summary>
        /// If this has been validly assigned.
        /// </summary>
        /// <returns>If this has been validly assigned.</returns>
        protected override bool Assigned()
        {
            return hasAmmo != null;
        }
        
        /// <summary>
        /// Read the needed value.
        /// </summary>
        protected override void ReadValue()
        {
            hasAmmo.Value = trooper.Value.HasAmmo;
        }
    }
}
#endif