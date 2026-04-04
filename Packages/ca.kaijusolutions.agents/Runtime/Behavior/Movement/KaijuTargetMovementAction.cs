#if COM_UNITY_BEHAVIOR
using System;
using KaijuSolutions.Agents.Movement;
using Unity.Behavior;
using Unity.Properties;
using UnityEngine;

namespace KaijuSolutions.Agents.Behavior.Movement
{
    /// <summary>
    /// Class for movement actions which move in relation to a given target.
    /// </summary>
    /// <typeparam name="T">The type of movement this is for.</typeparam>
    [Serializable]
    [GeneratePropertyBag]
    public abstract class KaijuTargetMovementAction<T> : KaijuMovementAction<T> where T : KaijuMovement
    {
        /// <summary>
        /// The target for the <see cref="KaijuAgentGraphAction.agent"/> to move in relation to.
        /// </summary>
        [Tooltip("The target to move in relation to.")]
        [SerializeReference]
        public BlackboardVariable<Transform> target;
        
        /// <summary>
        /// OnStart is called when the node starts running.
        /// </summary>
        /// <returns>The status of the node.</returns>
        protected override Status OnStart()
        {
            return target == null || !target.Value ? Status.Failure : base.OnStart();
        }
        
        /// <summary>
        /// OnUpdate is called each frame while the node is running.
        /// </summary>
        /// <returns>The status of the node.</returns>
        protected override Status OnUpdate()
        {
            // If the target has been destroyed, assume this has failed.
            return target == null || target.Value == null ? Status.Failure : base.OnUpdate();
        }
    }
}
#endif