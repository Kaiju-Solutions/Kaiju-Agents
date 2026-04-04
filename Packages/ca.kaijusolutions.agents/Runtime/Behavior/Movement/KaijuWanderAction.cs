#if COM_UNITY_BEHAVIOR
using System;
using KaijuSolutions.Agents.Movement;
using Unity.Behavior;
using Unity.Properties;
using UnityEngine;

namespace KaijuSolutions.Agents.Behavior.Movement
{
    /// <summary>
    /// Wander movement action for a <see cref="KaijuAgentGraphAction.agent"/>.
    /// </summary>
    [Serializable]
    [GeneratePropertyBag]
    [NodeDescription(
        name: "Wander",
        story: "Have [agent] [wander] using [configuration].",
        description: "Have an agent wander. If the agent is not assigned, it will try to find an agent variable. If none are found, it will try to find an agent attached to any other component and create a variable from it. If no configuration is passed, it will use the one assigned to the agent, which itself will fallback to default values if none is assigned.",
        category: "Kaiju Agents/Movement",
        id: "9e202450dff3a82616371d1145413742",
        icon: "Packages/ca.kaijusolutions.agents/Editor/Icon.png")
    ]
    public class KaijuWanderAction : KaijuMovementAction<KaijuWanderMovement>
    {
        /// <summary>
        /// The movement reference.
        /// </summary>
        [Tooltip("Optionally assign to keep a reference to this movement if it is needed for later.")]
        [SerializeReference]
        public BlackboardVariable<KaijuMovementReference> wander;
        
        /// <summary>
        /// Get the movement instance to configure.
        /// </summary>
        /// <returns>The movement reference variable.</returns>
        protected override BlackboardVariable<KaijuMovementReference> GetMovementReference()
        {
            return wander;
        }
        
        /// <summary>
        /// Create the movement.
        /// </summary>
        /// <returns>The movement that was created.</returns>
        protected override KaijuWanderMovement CreateMovement()
        {
            return configuration.Value ? agent.Value.Wander(configuration.Value.WanderDistance, configuration.Value.WanderRadius,  configuration.Value.Weight, configuration.Value.clear) : agent.Value.Wander();
        }
        
        /// <summary>
        /// OnStart is called when the node starts running.
        /// </summary>
        /// <returns>The status of the node.</returns>
        protected override Status OnStart()
        {
            // Wander movements simply fire-and-forget.
            return base.OnStart() != Status.Failure ? Status.Success : Status.Failure;
        }
        
        /// <summary>
        /// Get a description of the object.
        /// </summary>
        /// <returns>A description of the object.</returns>
        public override string ToString()
        {
            return $"Kaiju Wander Action - Agent: {(agent.Value ? agent.Value : "None")} - Configuration: {(configuration.Value ? configuration.Value : "None")} - Movement: {(Movement ? Movement : "None")}";
        }
    }
}
#endif