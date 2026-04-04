#if COM_UNITY_BEHAVIOR
using System;
using Unity.Properties;

namespace KaijuSolutions.Agents.Behavior
{
    /// <summary>
    /// Base class to modify identifiers on a <see cref="KaijuAgentGraphAction.agent"/>.
    /// </summary>
    [Serializable]
    [GeneratePropertyBag]
    public abstract class KaijuIdentifierAction : KaijuAgentGraphAction
    {
        /// <summary>
        /// OnStart is called when the node starts running.
        /// </summary>
        /// <returns>The status of the node.</returns>
        protected override Status OnStart()
        {
            return base.OnStart() == Status.Success && HandleAction() ? Status.Success : Status.Failure;
        }
        
        /// <summary>
        /// Handle the identifiers action.
        /// </summary>
        /// <returns>If this was successful.</returns>
        protected abstract bool HandleAction();
        
        /// <summary>
        /// Get a description of the object.
        /// </summary>
        /// <returns>A description of the object.</returns>
        public override string ToString()
        {
            return $"Kaiju Identifier Action - Agent: {(agent.Value ? agent.Value : "None")}";
        }
    }
}
#endif