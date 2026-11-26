#if COM_UNITY_ML_AGENTS
using Unity.MLAgents.Actuators;
using UnityEngine;

namespace KaijuSolutions.Agents.Learning
{
    /// <summary>
    /// Controls a Kaiju agent with continuous ML-Agents actions for X and Z. Enable Include Climb to append a Y action for flight.
    /// </summary>
    [DisallowMultipleComponent]
#if UNITY_EDITOR
    [AddComponentMenu("Kaiju Solutions/Agents/ML-Agents/Actuators/Kaiju Learning Control Actuator", 6)]
    [Icon("Packages/ca.kaijusolutions.agents/Editor/Icon.png")]
    [HelpURL("https://agents.kaijusolutions.ca/manual/ml-agents.html")]
#endif
    public class KaijuLearningControlActuator : KaijuLearningAgentActuator
    {
        /// <summary>
        /// The specification of the possible actions for this actuator component. This must produce the same results as the corresponding IActuator's ActionSpec.
        /// </summary>
        public override ActionSpec ActionSpec => ActionSpec.MakeContinuous(includeClimb ? 3 : 2);

        [Tooltip("Append a climb action after the horizontal X and Z actions.")]
        [SerializeField] private bool includeClimb;
        
        /// <summary>
        /// Method called in order to allow object to execute actions based on the <see cref="actionBuffers"/> contents. The structure of the contents in the <see cref="actionBuffers"/> are defined by the action spec.
        /// </summary>
        /// <param name="actionBuffers">The data structure containing the action buffers for this object.</param>
        public override void OnActionReceived(ActionBuffers actionBuffers)
        {
            var actions = actionBuffers.ContinuousActions;
            if (includeClimb) Agent.Control3 = new Vector3(actions[0], actions[2], actions[1]);
            else Agent.Control = new Vector2(actions[0], actions[1]);
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
            actionBuffersOut.ContinuousActions.Clear();
        }
    }
}
#endif
