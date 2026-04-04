#if COM_UNITY_BEHAVIOR
using System;
using Unity.Behavior;
using Unity.Properties;

namespace KaijuSolutions.Agents.Behavior
{
    /// <summary>
    /// Action to add an identifier to a <see cref="KaijuAgentGraphAction.agent"/>.
    /// </summary>
    [Serializable]
    [GeneratePropertyBag]
    [NodeDescription(
        name: "Add Identifier",
        story: "Add [identifier] to [agent]'s identifiers.",
        description: "Add an identifier to an agent. This will fail if the agent already has this as an identifier. If the agent is not assigned, it will try to find an agent variable. If none are found, it will try to find an agent attached to any other component and create a variable from it.",
        category: "Kaiju Agents/Identifiers",
        id: "9e202450dff3a82616371d1145413771",
        icon: "Packages/ca.kaijusolutions.agents/Editor/Icon.png")
    ]
    public class KaijuAddIdentifierAction : KaijuModifyIdentifierAction
    {
        /// <summary>
        /// Handle the identifiers action.
        /// </summary>
        /// <param name="unsigned">The value cast to unsigned. This is needed as the blackboard variables do not support unsigned integers.</param>
        /// <returns>The result of the action.</returns>
        protected override bool HandleAction(uint unsigned)
        {
            return agent.Value.AddIdentifier(unsigned);
        }
        
        /// <summary>
        /// Get a description of the object.
        /// </summary>
        /// <returns>A description of the object.</returns>
        public override string ToString()
        {
            return $"Kaiju Add Identifier Action - Agent: {(agent.Value ? agent.Value : "None")} - Identifier: {identifier.Value}";
        }
    }
}
#endif