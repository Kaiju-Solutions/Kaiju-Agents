#if COM_UNITY_BEHAVIOR
using System;
using Unity.Behavior;
using Unity.Properties;

namespace KaijuSolutions.Agents.Behavior
{
    /// <summary>
    /// Action to clear the identifiers of a <see cref="KaijuAgentGraphAction.agent"/>.
    /// </summary>
    [Serializable]
    [GeneratePropertyBag]
    [NodeDescription(
        name: "Clear Identifiers",
        story: "Clear identifiers on [agent].",
        description: "Clear the identifiers of an agent. This will fail if there were no identifiers on the agent to clear. If the agent is not assigned, it will try to find an agent variable. If none are found, it will try to find an agent attached to any other component and create a variable from it.",
        category: "Kaiju Agents/Identifiers",
        id: "9e202450dff3a82616371d1145413769",
        icon: "Packages/ca.kaijusolutions.agents/Editor/Icon.png")
    ]
    public class KaijuClearIdentifiersAction : KaijuIdentifierAction
    {
        /// <summary>
        /// Handle the identifiers action.
        /// </summary>
        /// <returns>The result of the action.</returns>
        protected override bool HandleAction()
        {
            int count = agent.Value.Identifiers.Count;
            agent.Value.ClearIdentifiers();
            return count > 0;
        }
        
        /// <summary>
        /// Get a description of the object.
        /// </summary>
        /// <returns>A description of the object.</returns>
        public override string ToString()
        {
            return $"Kaiju Clear Identifiers Action - Agent: {(agent.Value ? agent.Value : "None")}";
        }
    }
}
#endif