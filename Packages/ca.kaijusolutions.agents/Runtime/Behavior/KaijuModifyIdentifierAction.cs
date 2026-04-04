#if COM_UNITY_BEHAVIOR
using System;
using Unity.Behavior;
using Unity.Properties;
using UnityEngine;

namespace KaijuSolutions.Agents.Behavior
{
    /// <summary>
    /// Base class to modify an identifier on a <see cref="KaijuAgentGraphAction.agent"/>.
    /// </summary>
    [Serializable]
    [GeneratePropertyBag]
    public abstract class KaijuModifyIdentifierAction : KaijuIdentifierAction
    {
        /// <summary>
        /// The identifier value.
        /// </summary>
        [Tooltip("The identifier.")]
        [SerializeReference]
        public BlackboardVariable<int> identifier;
        
        /// <summary>
        /// OnStart is called when the node starts running.
        /// </summary>
        /// <returns>The status of the node.</returns>
        protected override Status OnStart()
        {
            return identifier == null ? Status.Failure : base.OnStart();
        }
        
        /// <summary>
        /// Handle the identifiers action.
        /// </summary>
        /// <returns>The result of the action.</returns>
        protected override bool HandleAction()
        {
            return HandleAction((uint)identifier.Value);
        }
        
        /// <summary>
        /// Handle the identifiers action.
        /// </summary>
        /// <param name="unsigned">The value cast to unsigned. This is needed as the blackboard variables do not support unsigned integers.</param>
        /// <returns>The result of the action.</returns>
        protected abstract bool HandleAction(uint unsigned);
    }
}
#endif