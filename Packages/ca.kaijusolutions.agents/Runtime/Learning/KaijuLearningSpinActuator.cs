#if COM_UNITY_ML_AGENTS
using Unity.MLAgents.Actuators;
using UnityEngine;

namespace KaijuSolutions.Agents.Learning
{
    /// <summary>
    /// Actuator for controlling the rotation of an <see cref="KaijuSolutions.Agents.KaijuAgent"/> for <see href="https://docs.unity3d.com/Packages/com.unity.ml-agents@latest">ML-Agents</see>.
    /// </summary>
    [DisallowMultipleComponent]
#if UNITY_EDITOR
    [AddComponentMenu("Kaiju Solutions/Agents/ML-Agents/Actuators/Kaiju Learning Spin Actuator", 7)]
    [Icon("Packages/ca.kaijusolutions.agents/Editor/Icon.png")]
    [HelpURL("https://agents.kaijusolutions.ca/manual/ml-agents.html")]
#endif
    public class KaijuLearningSpinActuator : KaijuLearningAgentActuator
    {
        /// <summary>
        /// The specification of the possible actions for this actuator component. This must produce the same results as the corresponding IActuator's ActionSpec.
        /// </summary>
        public override ActionSpec ActionSpec => ActionSpec.MakeContinuous(1);
        
        /// <summary>
        /// Method called in order to allow object to execute actions based on the <see cref="actionBuffers"/> contents. The structure of the contents in the <see cref="actionBuffers"/> are defined by the action spec.
        /// </summary>
        /// <param name="actionBuffers">The data structure containing the action buffers for this object.</param>
        public override void OnActionReceived(ActionBuffers actionBuffers)
        {
            Agent.Spin = actionBuffers.ContinuousActions[0];
        }
        
        /// <summary>
        /// Implement to modify the masks for discrete actions. When using discrete actions, the agent will not perform the masked action.
        /// </summary>
        /// <param name="actionMask"> The action mask for the agent.</param>
        public override void WriteDiscreteActionMask(IDiscreteActionMask actionMask) { }
        
        /// <summary>
        /// Method called on objects which are expected to fill out the <see cref="actionBuffersOut"/> data structure. Object that implement this interface should be careful to be consistent in the placement of their actions in the <see cref="actionBuffersOut"/> data structure.
        /// </summary>
        /// <param name="actionBuffersOut">The action buffers data structure to be filled by the object implementing this interface.</param>
        public override void Heuristic(in ActionBuffers actionBuffersOut)
        {
            actionBuffersOut.ContinuousActions.Array[0] = Agent.Spin ?? 0f;
        }
    }
}
#endif