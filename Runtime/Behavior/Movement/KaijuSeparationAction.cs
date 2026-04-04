#if COM_UNITY_BEHAVIOR
using System;
using System.Linq;
using KaijuSolutions.Agents.Movement;
using Unity.Behavior;
using Unity.Properties;
using UnityEngine;

namespace KaijuSolutions.Agents.Behavior.Movement
{
    /// <summary>
    /// Separation movement action for a <see cref="KaijuAgentGraphAction.agent"/>.
    /// </summary>
    [Serializable]
    [GeneratePropertyBag]
    [NodeDescription(
        name: "Separation",
        story: "Have [agent] [separate] from other agents using [configuration].",
        description: "Have an agent separate from other agents. This will report a success once the agent has separated from all other agents. Note that a success does not stop this movement. If the agent is not assigned, it will try to find an agent variable. If none are found, it will try to find an agent attached to any other component and create a variable from it. If no configuration is passed, it will use the one assigned to the agent, which itself will fallback to default values if none is assigned.",
        category: "Kaiju Agents/Movement",
        id: "9e202450dff3a82616371d1145413743",
        icon: "Packages/ca.kaijusolutions.agents/Editor/Icon.png")
    ]
    public class KaijuSeparationAction : KaijuMovementAction<KaijuSeparationMovement>
    {
        /// <summary>
        /// The movement reference.
        /// </summary>
        [Tooltip("Optionally assign to keep a reference to this movement if it is needed for later.")]
        [SerializeReference]
        public BlackboardVariable<KaijuMovementReference> separate;
        
        /// <summary>
        /// Get the movement instance to configure.
        /// </summary>
        /// <returns>The movement reference variable.</returns>
        protected override BlackboardVariable<KaijuMovementReference> GetMovementReference()
        {
            return separate;
        }
        
        /// <summary>
        /// Create the movement.
        /// </summary>
        /// <returns>The movement that was created.</returns>
        protected override KaijuSeparationMovement CreateMovement()
        {
            return configuration.Value ? agent.Value.Separation(configuration.Value.SeparationDistance, configuration.Value.SeparationCoefficient, configuration.Value.Identifiers.ToArray(), configuration.Value.Weight, configuration.Value.clear) : agent.Value.Separation();
        }
        
        /// <summary>
        /// OnUpdate is called each frame while the node is running.
        /// </summary>
        /// <returns>The status of the node.</returns>
        protected override Status OnUpdate()
        {
            // If we are separating, indicate we are still running.
            return base.OnUpdate() == Status.Failure ? Status.Failure : Movement.Interacting.Count > 1 ? Status.Running : Status.Success;
        }
    }
}
#endif