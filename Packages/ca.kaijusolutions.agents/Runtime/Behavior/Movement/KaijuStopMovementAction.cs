#if COM_UNITY_BEHAVIOR
using System;
using Unity.Behavior;
using Unity.Properties;
using UnityEngine;
using Action = Unity.Behavior.Action;

namespace KaijuSolutions.Agents.Behavior.Movement
{
    /// <summary>
    /// Action to stop a movement.
    /// </summary>
    [Serializable]
    [GeneratePropertyBag]
    [NodeDescription(
        name: "Stop Movement",
        story: "Stop [movement].",
        description: "Stop a movement. This will report a failure if the agent is the given movement is not currently running.",
        category: "Kaiju Agents/Movement/Stop",
        id: "9e202450dff3a82616371d1145413760",
        icon: "Packages/ca.kaijusolutions.agents/Editor/Icon.png")
    ]
    public class KaijuStopMovementAction : Action
    {
        /// <summary>
        /// The movement reference.
        /// </summary>
        [Tooltip("The movement to stop.")]
        [SerializeReference]
        public BlackboardVariable<KaijuMovementReference> movement;
        
        /// <summary>
        /// OnStart is called when the node starts running.
        /// </summary>
        /// <returns>The status of the node.</returns>
        protected override Status OnStart()
        {
            return movement != null && movement.Value && movement.Value.Stop() ? Status.Success : Status.Failure;
        }
        
        /// <summary>
        /// Get a description of the object.
        /// </summary>
        /// <returns>A description of the object.</returns>
        public override string ToString()
        {
            return $"Kaiju Stop Movement Action - Movement: {(movement.Value ? movement.Value : "None")}";
        }
    }
}
#endif