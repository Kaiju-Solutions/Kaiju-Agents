#if COM_UNITY_BEHAVIOR
using System;
using Unity.Behavior;
using Unity.Properties;
using UnityEngine;

namespace KaijuSolutions.Agents.Behavior.Exercises.CTF
{
    /// <summary>
    /// Read a <see cref="ReadTrooperAction.trooper"/>'s team.
    /// </summary>
    [Serializable]
    [GeneratePropertyBag]
    [NodeDescription(
        name: "Get Trooper Team",
        story: "Get the [team] of [trooper].",
        description: "Get the team of a trooper. True means team one, false means team two. If the trooper is not assigned, will try to find a variable of one or one attached to one.",
        category: "Kaiju Agents/Capture the Flag",
        id: "9e202450dff3a82616371d1145413792",
        icon: "Packages/ca.kaijusolutions.agents/Editor/Icon.png")
    ]
    public class ReadTrooperTeamAction : ReadTrooperAction
    {
        /// <summary>
        /// The team of the <see cref="ReadTrooperAction.trooper"/>. True means team one, false means team two.
        /// </summary>
        [Tooltip("The team of the trooper. True means team one, false means team two.")]
        [SerializeReference]
        public BlackboardVariable<bool> team;
        
        /// <summary>
        /// If this has been validly assigned.
        /// </summary>
        /// <returns>If this has been validly assigned.</returns>
        protected override bool Assigned()
        {
            return team != null;
        }
        
        /// <summary>
        /// Read the needed value.
        /// </summary>
        protected override void ReadValue()
        {
            team.Value = trooper.Value.TeamOne;
        }
    }
}
#endif