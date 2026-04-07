using UnityEngine;

namespace KaijuSolutions.Agents.Utility
{
    /// <summary>
    /// A constant <see cref="KaijuSolutions.Agents.Utility.KaijuUtilityConsideration"/> value.
    /// </summary>
#if UNITY_EDITOR
    [Icon("Packages/ca.kaijusolutions.agents/Editor/Icon.png")]
    [HelpURL("https://agents.kaijusolutions.ca/manual/utility-ai.html")]
    [CreateAssetMenu(menuName = "Kaiju Solutions/Agents/Utility/Constant", fileName = "Constant", order = 0)]
#endif
    public class KaijuUtilityConstantConsideration : KaijuUtilityConsideration
    {
        /// <summary>
        /// The utility score of this consideration.
        /// </summary>
        public float Utility
        {
            get => utility;
            set => utility = Mathf.Clamp01(value);
        }
        
        /// <summary>
        /// The utility score of this consideration.
        /// </summary>
#if UNITY_EDITOR
        [Tooltip("The utility score of this consideration.")]
        [Range(0f, 1f)]
#endif
        [SerializeField]
        private float utility = 1;
        
        /// <summary>
        /// Get the utility score of this action.
        /// </summary>
        /// <param name="brain">The <see cref="KaijuSolutions.Agents.Utility.KaijuUtilityBrain"/> this is calculating the utility for.</param>
        /// <returns>The utility score of this action.</returns>
        public override float Evaluate(KaijuUtilityBrain brain)
        {
            return utility;
        }
        
        /// <summary>
        /// Get a description of the object.
        /// </summary>
        /// <returns>A description of the object.</returns>
        public override string ToString()
        {
            return $"{name} - Kaiju Utility Constant Consideration - Utility: {utility}";
        }
    }
}