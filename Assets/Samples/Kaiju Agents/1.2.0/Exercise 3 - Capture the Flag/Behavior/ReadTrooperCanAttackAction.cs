#if COM_UNITY_BEHAVIOR
using System;
using Unity.Behavior;
using Unity.Properties;
using UnityEngine;

namespace KaijuSolutions.Agents.Behavior.Exercises.CTF
{
    /// <summary>
    /// Read if a <see cref="ReadTrooperAction.trooper"/> can attack.
    /// </summary>
    [Serializable]
    [GeneratePropertyBag]
    [NodeDescription(
        name: "Get Trooper Has Ammo",
        story: "Get if a [trooper] [canAttack]",
        description: "Get if a trooper can attack. If the trooper is not assigned, will try to find a variable of one or one attached to one.",
        category: "Kaiju Agents/Capture the Flag",
        id: "9e202450dff3a82616371d1145413794",
        icon: "Packages/ca.kaijusolutions.agents/Editor/Icon.png")
    ]
    public class ReadTrooperCanAttackAction : ReadTrooperAction
    {
        /// <summary>
        /// If the <see cref="ReadTrooperAction.trooper"/> can attack.
        /// </summary>
        [Tooltip("If the trooper can attack.")]
        [SerializeReference]
        public BlackboardVariable<bool> canAttack;
        
        /// <summary>
        /// If this has been validly assigned.
        /// </summary>
        /// <returns>If this has been validly assigned.</returns>
        protected override bool Assigned()
        {
            return canAttack != null;
        }
        
        /// <summary>
        /// Read the needed value.
        /// </summary>
        protected override void ReadValue()
        {
            canAttack.Value = trooper.Value.CanAttack;
        }
    }
}
#endif