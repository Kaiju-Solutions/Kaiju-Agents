#if COM_UNITY_BEHAVIOR
using System;
using KaijuSolutions.Agents.Movement;
using Unity.Behavior;
using Unity.Properties;
using UnityEngine;

namespace KaijuSolutions.Agents.Behavior.Movement
{
    /// <summary>
    /// Flee movement action for a <see cref="KaijuAgentGraphAction.agent"/>.
    /// </summary>
    [Serializable]
    [GeneratePropertyBag]
    [NodeDescription(
        name: "Flee",
        story: "[agent] [flee] from [target] using [configuration].",
        description: "Have an agent flee from a target. If the agent is not assigned, it will try to find an agent variable. If none are found, it will try to find an agent attached to any other component and create a variable from it. If no configuration is passed, it will use the one assigned to the agent, which itself will fallback to default values if none is assigned.",
        category: "Kaiju Agents/Movement",
        id: "9e202450dff3a82616371d1145413739",
        icon: "Packages/ca.kaijusolutions.agents/Editor/Icon.png")
    ]
    public class KaijuFleeAction : KaijuTargetMovementAction<KaijuFleeMovement>
    {
        /// <summary>
        /// The movement reference.
        /// </summary>
        [Tooltip("Optionally assign to keep a reference to this movement if it is needed for later.")]
        [SerializeReference]
        public BlackboardVariable<KaijuMovementReference> flee;
        
        /// <summary>
        /// Get the movement instance to configure.
        /// </summary>
        /// <returns>The movement reference variable.</returns>
        protected override BlackboardVariable<KaijuMovementReference> GetMovementReference()
        {
            return flee;
        }
        
        /// <summary>
        /// Create the movement.
        /// </summary>
        /// <returns>The movement that was created.</returns>
        protected override KaijuFleeMovement CreateMovement()
        {
            return target.Value == null ? null : configuration.Value ? agent.Value.Flee(target.Value, configuration.Value.ApproachingDistance, configuration.Value.Weight,  configuration.Value.clear) : agent.Value.Flee(target.Value);
        }
    }
}
#endif