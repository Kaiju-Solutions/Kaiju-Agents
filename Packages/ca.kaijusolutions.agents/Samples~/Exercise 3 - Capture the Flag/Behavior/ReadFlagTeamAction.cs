#if COM_UNITY_BEHAVIOR
using System;
using Unity.Behavior;
using Unity.Properties;
using UnityEngine;

namespace KaijuSolutions.Agents.Behavior.Exercises.CTF
{
    /// <summary>
    /// Read the team of a <see cref="ReadFlagAction.flag"/>.
    /// </summary>
    [Serializable]
    [GeneratePropertyBag]
    [NodeDescription(
        name: "Get Flag Team",
        story: "Get [flag]'s [team].",
        description: "Get a flag's team. True means team one, false means team two. If the flag is not assigned, will try to find a variable of one or one attached to one.",
        category: "Kaiju Agents/Capture the Flag",
        id: "9e202450dff3a82616371d1145413788",
        icon: "Packages/ca.kaijusolutions.agents/Editor/Icon.png")
    ]
    public class ReadFlagTeamAction : ReadFlagAction
    {
        /// <summary>
        /// The team <see cref="ReadFlagAction.flag"/> is for. True means team one, false means team two.
        /// </summary>
        [Tooltip("The team flag is for. True means team one, false means team two.")]
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
            team.Value = flag.Value.TeamOne;
        }
        
        /// <summary>
        /// Get a description of the object.
        /// </summary>
        /// <returns>A description of the object.</returns>
        public override string ToString()
        {
            return $"Read Flag Team Action - Flag: {(flag.Value ? flag.Value : "None")} - {(team.Value ? "Team One" : "Team Two")}";
        }
    }
}
#endif