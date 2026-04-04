using UnityEngine;

namespace KaijuSolutions.Agents.Utility
{
    /// <summary>
    /// <see cref="KaijuUtilityConsideration"/> which reads a certain key from the <see cref="KaijuUtilityBrain"/>'s blackboard.
    /// </summary>
#if UNITY_EDITOR
    [Icon("Packages/ca.kaijusolutions.agents/Editor/Icon.png")]
    [HelpURL("https://agents.kaijusolutions.ca/manual/utility-ai.html")]
#endif
    public abstract class KaijuUtilityKeyConsideration : KaijuUtilityConsideration
    {
        /// <summary>
        /// What key to use from the <see cref="KaijuUtilityBrain"/>'s blackboard.
        /// </summary>
        public string Key
        {
            get => key;
            set => key = value ?? string.Empty;
        }
        
        /// <summary>
        /// What key to use from the <see cref="KaijuUtilityBrain"/>'s blackboard.
        /// </summary>
        [Tooltip("What key to use from the brain's blackboard.")]
        [SerializeField]
        private string key = string.Empty;
    }
}