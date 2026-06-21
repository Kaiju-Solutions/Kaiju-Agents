#if COM_UNITY_BEHAVIOR
using System;
using Unity.Behavior;
using Unity.Properties;
using UnityEngine;

namespace KaijuSolutions.Agents.Behavior.Exercises.CTF
{
    /// <summary>
    /// Read if a <see cref="ReadFlagAction.flag"/> is being carried.
    /// </summary>
    [Serializable]
    [GeneratePropertyBag]
    [NodeDescription(
        name: "Get Flag Carrying",
        story: "Get if [flag] is being [carried].",
        description: "Get if a flag is being carried. If the flag is not assigned, will try to find a variable of one or one attached to one.",
        category: "Kaiju Agents/Capture the Flag",
        id: "9e202450dff3a82616371d1145413789",
        icon: "Packages/ca.kaijusolutions.agents/Editor/Icon.png")
    ]
    public class ReadFlagCarriedAction : ReadFlagAction
    {
        /// <summary>
        /// If the <see cref="ReadFlagAction.flag"/> is being carried.
        /// </summary>
        [Tooltip("If the flag is being carried.")]
        [SerializeReference]
        public BlackboardVariable<bool> carried;
        
        /// <summary>
        /// If this has been validly assigned.
        /// </summary>
        /// <returns>If this has been validly assigned.</returns>
        protected override bool Assigned()
        {
            return carried != null;
        }
        
        /// <summary>
        /// Read the needed value.
        /// </summary>
        protected override void ReadValue()
        {
            carried.Value = flag.Value.Parent != null;
        }
        
        /// <summary>
        /// Get a description of the object.
        /// </summary>
        /// <returns>A description of the object.</returns>
        public override string ToString()
        {
            return $"Read Flag Carried Action - Flag: {(flag.Value ? flag.Value : "None")} - Carried: {(carried.Value ? carried.Value : "None")}";
        }
    }
}
#endif