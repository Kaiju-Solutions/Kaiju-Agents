#if COM_UNITY_BEHAVIOR
using System;
using Unity.Behavior;
using Unity.Properties;

namespace KaijuSolutions.Agents.Behavior
{
    /// <summary>
    /// Action to see if a <see cref="KaijuAgentGraphAction.agent"/> has an identifier.
    /// </summary>
    [Serializable]
    [GeneratePropertyBag]
    [NodeDescription(
        name: "Has Identifier",
        story: "[agent] has identifier [identifier].",
        description: "See if an agent has an identifier. If the agent is not assigned, it will try to find an agent variable. If none are found, it will try to find an agent attached to any other component and create a variable from it.",
        category: "Kaiju Agents/Identifiers",
        id: "9e202450dff3a82616371d1145413773",
        icon: "Packages/ca.kaijusolutions.agents/Editor/Icon.png")
    ]
    public class KaijuHasIdentifierAction : KaijuModifyIdentifierAction
    {
        /// <summary>
        /// Handle the identifiers action.
        /// </summary>
        /// <param name="unsigned">The value cast to unsigned. This is needed as the blackboard variables do not support unsigned integers.</param>
        /// <returns>The result of the action.</returns>
        protected override bool HandleAction(uint unsigned)
        {
            return agent.Value.HasIdentifier(unsigned);
        }
    }
}
#endif