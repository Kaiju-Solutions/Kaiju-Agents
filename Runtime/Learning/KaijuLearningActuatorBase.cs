#if COM_UNITY_ML_AGENTS
using Unity.MLAgents.Actuators;
using UnityEngine;

namespace KaijuSolutions.Agents.Learning
{
    /// <summary>
    /// Base class for integrating all actuators with <see href="https://docs.unity3d.com/Packages/com.unity.ml-agents@latest">ML-Agents</see>.
    /// </summary>
#if UNITY_EDITOR
    [Icon("Packages/ca.kaijusolutions.agents/Editor/Icon.png")]
    [HelpURL("https://agents.kaijusolutions.ca/manual/ml-agents.html")]
#endif
    public abstract class KaijuLearningActuatorBase : ActuatorComponent, IActuator
    {
        /// <summary>
        /// Method called in order to allow object to execute actions based on the <see cref="actionBuffers"/> contents. The structure of the contents in the <see cref="actionBuffers"/> are defined by the action spec.
        /// </summary>
        /// <param name="actionBuffers">The data structure containing the action buffers for this object.</param>
        public abstract void OnActionReceived(ActionBuffers actionBuffers);
        
        /// <summary>
        /// Implement to modify the masks for discrete actions. When using discrete actions, the agent will not perform the masked action.
        /// </summary>
        /// <param name="actionMask"> The action mask for the agent.</param>
        public abstract void WriteDiscreteActionMask(IDiscreteActionMask actionMask);
        
        /// <summary>
        /// Method called on objects which are expected to fill out the <see cref="actionBuffersOut"/> data structure. Object that implement this interface should be careful to be consistent in the placement of their actions in the <see cref="actionBuffersOut"/> data structure.
        /// </summary>
        /// <param name="actionBuffersOut">The action buffers data structure to be filled by the object implementing this interface.</param>
        public abstract void Heuristic(in ActionBuffers actionBuffersOut);
        
        /// <summary>
        /// Resets the internal state of the actuator. This is called at the end of an Agent's episode. Most implementations can leave this empty.
        /// </summary>
        public virtual void ResetData() { }
        
        /// <summary>
        /// Create a collection IActuators. This is called by the agent during initialization.
        /// </summary>
        /// <returns>A collection IActuators</returns>
        public override IActuator[] CreateActuators() => new IActuator[] { this };
        
        /// <summary>
        /// Gets the name of this IActuator which will be used to sort it.
        /// </summary>
        public string Name
        {
            get
            {
                // Get the parents depth to add to the ordering for consistency.
                int parents = 0;
                Transform parent = transform.parent;
                while (parent != null)
                {
                    parents++;
                    parent = parent.parent;
                }
                
                // Write the classes' full name, the depth of this being the parents, where it sits relative to other components, how many children this has, and as long as its not the root (given the agent name may be dynamic at runtime), add the name of the object.
                return $"{GetType().FullName} {parents} {transform.GetSiblingIndex()} {transform.childCount} {(parents > 0 ? $" {name}" : string.Empty)}";
            }
        }
    }
}
#endif