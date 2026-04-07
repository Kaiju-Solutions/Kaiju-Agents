#if COM_UNITY_ML_AGENTS
using KaijuSolutions.Agents.Actuators;
using Unity.MLAgents.Actuators;
using UnityEngine;

namespace KaijuSolutions.Agents.Learning
{
    /// <summary>
    /// Use <see cref="KaijuSolutions.Agents.Actuators.KaijuAttackActuator"/>s with <see href="https://docs.unity3d.com/Packages/com.unity.ml-agents@latest">ML-Agents</see>.
    /// </summary>
    [RequireComponent(typeof(KaijuAttackActuator))]
#if UNITY_EDITOR
    [AddComponentMenu("Kaiju Solutions/Agents/ML-Agents/Actuators/Kaiju Learning Attack Actuator", 5)]
    [Icon("Packages/ca.kaijusolutions.agents/Editor/Icon.png")]
    [HelpURL("https://agents.kaijusolutions.ca/manual/ml-agents.html")]
#endif
    public class KaijuLearningAttackActuator : KaijuLearningActuatorBase
    {
        /// <summary>
        /// The <see cref="KaijuSolutions.Agents.Actuators.KaijuActuator"/>. Do not modify the properties of this sensor at runtime.
        /// </summary>
#if UNITY_EDITOR
        [Tooltip("The actuator. Do not modify the properties of this sensor at runtime.")]
#endif
        [SerializeField]
        private KaijuAttackActuator actuator;
        
        /// <summary>
        /// The value to pass for the heuristic methods.
        /// </summary>
        private int _heuristic;
#if UNITY_EDITOR
        /// <summary>
        /// Editor-only function that Unity calls when the script is loaded or a value changes in the Inspector.
        /// </summary>
        private void OnValidate()
        {
            if (actuator == null || actuator.gameObject != gameObject)
            {
                actuator = GetComponent<KaijuAttackActuator>();
            }
        }
#endif
        /// <summary>
        /// Start is called on the frame when a script is enabled just before any of the Update methods are called the first time. This function can be a coroutine.
        /// </summary>
        private void Start()
        {
            _heuristic = 0;
            actuator.OnStarted += OnStarted;
            actuator.OnInterrupted += OnInterrupted;
        }
        
        /// <summary>
        /// Called when a GameObject or component is about to be destroyed.
        /// </summary>
        private void OnDestroy()
        {
            if (!actuator)
            {
                return;
            }
            
            actuator.OnStarted -= OnStarted;
            actuator.OnInterrupted -= OnInterrupted;
        }

        /// <summary>
        /// Callback for when the <see cref="actuator"/> has started to execute.
        /// </summary>
        private void OnStarted()
        {
            _heuristic = 1;
        }
        
        /// <summary>
        /// Callback for when the <see cref="actuator"/> has been interrupted during its execution, cancelling the execution.
        /// </summary>
        private void OnInterrupted()
        {
            _heuristic = 2;
        }
        
        /// <summary>
        /// The specification of the possible actions for this actuator component. This must produce the same results as the corresponding IActuator's ActionSpec.
        /// </summary>
        public override ActionSpec ActionSpec => ActionSpec.MakeDiscrete(3);
        
        /// <summary>
        /// Method called in order to allow object to execute actions based on the <see cref="actionBuffers"/> contents. The structure of the contents in the <see cref="actionBuffers"/> are defined by the action spec.
        /// </summary>
        /// <param name="actionBuffers">The data structure containing the action buffers for this object.</param>
        public override void OnActionReceived(ActionBuffers actionBuffers)
        {
            switch (actionBuffers.DiscreteActions[0])
            {
                case < 1:
                    return;
                case 1:
                    actuator.Begin();
                    return;
                default:
                    actuator.End();
                    return;
            }
        }
        
        /// <summary>
        /// Implement to modify the masks for discrete actions. When using discrete actions, the agent will not perform the masked action.
        /// </summary>
        /// <param name="actionMask"> The action mask for the agent.</param>
        public override void WriteDiscreteActionMask(IDiscreteActionMask actionMask)
        {
            // Can call to run if not running and not on cooldown, and call to stop only when running.
            bool running = actuator.IsRunning;
            actionMask.SetActionEnabled(0, 0, true);
            actionMask.SetActionEnabled(0, 1, !running && !actuator.OnCooldown);
            actionMask.SetActionEnabled(0, 2, running);
        }
        
        /// <summary>
        /// Method called on objects which are expected to fill out the <see cref="actionBuffersOut"/> data structure. Object that implement this interface should be careful to be consistent in the placement of their actions in the <see cref="actionBuffersOut"/> data structure.
        /// </summary>
        /// <param name="actionBuffersOut">The action buffers data structure to be filled by the object implementing this interface.</param>
        public override void Heuristic(in ActionBuffers actionBuffersOut)
        {
            actionBuffersOut.DiscreteActions.Array[0] = _heuristic;
            _heuristic = 0;
        }
    }
}
#endif