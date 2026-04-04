#if COM_UNITY_BEHAVIOR
using System;
using KaijuSolutions.Agents.Movement;
using Unity.Behavior;
using Unity.Properties;
using UnityEngine;

namespace KaijuSolutions.Agents.Behavior.Movement
{
    /// <summary>
    /// Seek movement action for a <see cref="KaijuAgentGraphAction.agent"/>.
    /// </summary>
    [Serializable]
    [GeneratePropertyBag]
    [NodeDescription(
        name: "Seek",
        story: "[agent] [seek] to [target] using [configuration].",
        description: "Have an agent seek to a target. If the agent is not assigned, it will try to find an agent variable. If none are found, it will try to find an agent attached to any other component and create a variable from it. If no configuration is passed, it will use the one assigned to the agent, which itself will fallback to default values if none is assigned.",
        category: "Kaiju Agents/Movement",
        id: "9e202450dff3a82616371d1145413738",
        icon: "Packages/ca.kaijusolutions.agents/Editor/Icon.png")
    ]
    public class KaijuSeekAction : KaijuTargetMovementAction<KaijuSeekMovement>
    {
        /// <summary>
        /// The movement reference.
        /// </summary>
        [Tooltip("Optionally assign to keep a reference to this movement if it is needed for later.")]
        [SerializeReference]
        public BlackboardVariable<KaijuMovementReference> seek;
        
        /// <summary>
        /// Get the movement instance to configure.
        /// </summary>
        /// <returns>The movement reference variable.</returns>
        protected override BlackboardVariable<KaijuMovementReference> GetMovementReference()
        {
            return seek;
        }
        
        /// <summary>
        /// Create the movement.
        /// </summary>
        /// <returns>The movement that was created.</returns>
        protected override KaijuSeekMovement CreateMovement()
        {
            return target.Value == null ? null : configuration.Value ? agent.Value.Seek(target.Value, configuration.Value.ApproachingDistance, configuration.Value.Weight,  configuration.Value.clear) : agent.Value.Seek(target.Value);
        }
        
        /// <summary>
        /// Get a description of the object.
        /// </summary>
        /// <returns>A description of the object.</returns>
        public override string ToString()
        {
            return $"Kaiju Seek Action - Agent: {(agent.Value ? agent.Value : "None")} - Configuration: {(configuration.Value ? configuration.Value : "None")} - Movement: {(Movement ? Movement : "None")}";
        }
    }
}
#endif