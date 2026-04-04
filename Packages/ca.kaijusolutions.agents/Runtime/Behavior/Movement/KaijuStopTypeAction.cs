#if COM_UNITY_BEHAVIOR
using System;
using KaijuSolutions.Agents.Movement;
using Unity.Properties;

namespace KaijuSolutions.Agents.Behavior.Movement
{
    /// <summary>
    /// Action to stop all movements of a <see cref="KaijuAgentGraphAction.agent"/>.
    /// </summary>
    [Serializable]
    [GeneratePropertyBag]
    public class KaijuStopTypeAction<T> : KaijuAgentGraphAction where T : KaijuMovement
    {
        /// <summary>
        /// OnStart is called when the node starts running.
        /// </summary>
        /// <returns>The status of the node.</returns>
        protected override Status OnStart()
        {
            // Stop all movements of a type.
            return base.OnStart() == Status.Success && agent.Value.Stop<T>() ? Status.Success : Status.Failure;
        }
        
        /// <summary>
        /// Get a description of the object.
        /// </summary>
        /// <returns>A description of the object.</returns>
        public override string ToString()
        {
            return $"Kaiju Stop Type Action - Type: {typeof(T).Name}";
        }
    }
}
#endif