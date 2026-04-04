#if COM_UNITY_BEHAVIOR
using System;
using Unity.Behavior;
using Unity.Properties;

namespace KaijuSolutions.Agents.Behavior
{
    /// <summary>
    /// Action to set the identifier of a <see cref="KaijuAgentGraphAction.agent"/>.
    /// </summary>
    [Serializable]
    [GeneratePropertyBag]
    [NodeDescription(
        name: "Set Identifier",
        story: "Set [agent]'s identifier to [identifier].",
        description: "Set the identifier of an agent. This will fail if the agent already had this as its only identifier. If the agent is not assigned, it will try to find an agent variable. If none are found, it will try to find an agent attached to any other component and create a variable from it.",
        category: "Kaiju Agents/Identifiers",
        id: "9e202450dff3a82616371d1145413770",
        icon: "Packages/ca.kaijusolutions.agents/Editor/Icon.png")
    ]
    public class KaijuSetIdentifierAction : KaijuModifyIdentifierAction
    {
        /// <summary>
        /// Handle the identifiers action.
        /// </summary>
        /// <param name="unsigned">The value cast to unsigned. This is needed as the blackboard variables do not support unsigned integers.</param>
        /// <returns>The result of the action.</returns>
        protected override bool HandleAction(uint unsigned)
        {
            // Fail if this is already the only identifier.
            int count = agent.Value.Identifiers.Count;
            if (count == 1 && agent.Value.HasIdentifier(unsigned))
            {
                return false;
            }
            
            agent.Value.SetIdentifier(unsigned);
            return true;
        }
        
        /// <summary>
        /// Get a description of the object.
        /// </summary>
        /// <returns>A description of the object.</returns>
        public override string ToString()
        {
            return $"Kaiju Set Identifier Action - Agent: {(agent.Value ? agent.Value : "None")} - Identifier: {identifier.Value}";
        }
    }
}
#endif