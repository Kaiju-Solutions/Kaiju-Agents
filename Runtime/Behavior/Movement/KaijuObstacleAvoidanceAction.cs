#if COM_UNITY_BEHAVIOR
using System;
using KaijuSolutions.Agents.Movement;
using Unity.Behavior;
using Unity.Properties;
using UnityEngine;

namespace KaijuSolutions.Agents.Behavior.Movement
{
    /// <summary>
    /// Obstacle avoidance movement action for a <see cref="KaijuAgentGraphAction.agent"/>.
    /// </summary>
    [Serializable]
    [GeneratePropertyBag]
    [NodeDescription(
        name: "Obstacle Avoidance",
        story: "Have [agent] [avoidObstacles] using [configuration].",
        description: "Have an agent avoid obstacles. This will report a success once all whiskers stop detecting obstacles. Note that a success does not stop this movement. If the agent is not assigned, it will try to find an agent variable. If none are found, it will try to find an agent attached to any other component and create a variable from it. If no configuration is passed, it will use the one assigned to the agent, which itself will fallback to default values if none is assigned.",
        category: "Kaiju Agents/Movement",
        id: "9e202450dff3a82616371d1145413744",
        icon: "Packages/ca.kaijusolutions.agents/Editor/Icon.png")
    ]
    public class KaijuObstacleAvoidanceAction : KaijuMovementAction<KaijuObstacleAvoidanceMovement>
    {
        /// <summary>
        /// The movement reference.
        /// </summary>
        [Tooltip("Optionally assign to keep a reference to this movement if it is needed for later.")]
        [SerializeReference]
        public BlackboardVariable<KaijuMovementReference> avoidObstacles;
        
        /// <summary>
        /// Get the movement instance to configure.
        /// </summary>
        /// <returns>The movement reference variable.</returns>
        protected override BlackboardVariable<KaijuMovementReference> GetMovementReference()
        {
            return avoidObstacles;
        }
        
        /// <summary>
        /// Create the movement.
        /// </summary>
        /// <returns>The movement that was created.</returns>
        protected override KaijuObstacleAvoidanceMovement CreateMovement()
        {
            return configuration.Value ? agent.Value.ObstacleAvoidance(configuration.Value.Avoidance, configuration.Value.AvoidanceDistance, configuration.Value.AvoidanceSideDistance, configuration.Value.avoidanceAngle, configuration.Value.avoidanceHeight, configuration.Value.avoidanceHorizontal, configuration.Value.Weight, configuration.Value.clear) : agent.Value.ObstacleAvoidance();
        }
        
        /// <summary>
        /// OnUpdate is called each frame while the node is running.
        /// </summary>
        /// <returns>The status of the node.</returns>
        protected override Status OnUpdate()
        {
            // If we are getting hits, indicate we are still running.
            return base.OnUpdate() == Status.Failure ? Status.Failure : Movement.Hits.Count > 1 ? Status.Running : Status.Success;
        }
        
        /// <summary>
        /// Get a description of the object.
        /// </summary>
        /// <returns>A description of the object.</returns>
        public override string ToString()
        {
            return $"Kaiju Obstacle Avoidance Action - Agent: {(agent.Value ? agent.Value : "None")} - Configuration: {(configuration.Value ? configuration.Value : "None")} - Movement: {(Movement ? Movement : "None")}";
        }
    }
}
#endif