#if COM_UNITY_ML_AGENTS
using UnityEngine;

namespace KaijuSolutions.Agents.Learning
{
    /// <summary>
    /// Sensor for getting information from an <see cref="KaijuAgent"/> for <see href="https://docs.unity3d.com/Packages/com.unity.ml-agents@latest">ML-Agents</see>.
    /// </summary>
    [RequireComponent(typeof(KaijuAgent))]
#if UNITY_EDITOR
    [Icon("Packages/ca.kaijusolutions.agents/Editor/Icon.png")]
    [HelpURL("https://agents.kaijusolutions.ca/manual/ml-agents.html")]
#endif
    public abstract class KaijuLearningAgentSensor : KaijuLearningSensor
    {
        /// <summary>
        /// The <see cref="KaijuAgent"/>.
        /// </summary>
#if UNITY_EDITOR
        [field: Tooltip("The agent.")]
        [field: HideInInspector]
#endif
        [field: SerializeField]
        protected KaijuAgent Agent { get; private set; }
#if UNITY_EDITOR
        /// <summary>
        /// Editor-only function that Unity calls when the script is loaded or a value changes in the Inspector.
        /// </summary>
        private void OnValidate()
        {
            if (Agent == null || Agent.gameObject != gameObject)
            {
                Agent = GetComponent<KaijuAgent>();
            }
        }
#endif
    }
}
#endif