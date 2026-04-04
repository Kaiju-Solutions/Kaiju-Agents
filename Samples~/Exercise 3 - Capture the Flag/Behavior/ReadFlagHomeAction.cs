#if COM_UNITY_BEHAVIOR
using System;
using KaijuSolutions.Agents.Exercises.CTF;
using Unity.Behavior;
using Unity.Properties;
using UnityEngine;

namespace KaijuSolutions.Agents.Behavior.Exercises.CTF
{
    /// <summary>
    /// Read the home position of a <see cref="ReadFlagAction.flag"/>.
    /// </summary>
    [Serializable]
    [GeneratePropertyBag]
    [NodeDescription(
        name: "Get Flag Home Position",
        story: "Get [flag]'s [home] position.",
        description: "Get a flag's home position. If the flag is not assigned, will try to find a variable of one or one attached to one.",
        category: "Kaiju Agents/Capture the Flag",
        id: "9e202450dff3a82616371d1145413787",
        icon: "Packages/ca.kaijusolutions.agents/Editor/Icon.png")
    ]
    public class ReadFlagHomeAction : ReadFlagAction
    {
        /// <summary>
        /// The home position of the <see cref="ReadFlagAction.flag"/>.
        /// </summary>
        [Tooltip("The home position of the flag.")]
        [SerializeReference]
        public BlackboardVariable<Vector3> home;
        
        /// <summary>
        /// If this has been validly assigned.
        /// </summary>
        /// <returns>If this has been validly assigned.</returns>
        protected override bool Assigned()
        {
            return home != null;
        }
        
        /// <summary>
        /// Read the needed value.
        /// </summary>
        protected override void ReadValue()
        {
            home.Value = Flag.Base3(flag.Value.TeamOne);
        }
    }
}
#endif