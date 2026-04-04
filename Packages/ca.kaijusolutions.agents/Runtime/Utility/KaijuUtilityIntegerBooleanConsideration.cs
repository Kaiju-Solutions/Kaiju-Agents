#if UNITY_EDITOR
using UnityEngine;
#endif
namespace KaijuSolutions.Agents.Utility
{
    /// <summary>
    /// Allow for converting an integer value to a Boolean decision.
    /// </summary>
#if UNITY_EDITOR
    [Icon("Packages/ca.kaijusolutions.agents/Editor/Icon.png")]
    [HelpURL("https://agents.kaijusolutions.ca/manual/utility-ai.html")]
    [CreateAssetMenu(menuName = "Kaiju Solutions/Agents/Utility/Integer Boolean", fileName = "Integer Boolean", order = 2)]
#endif
    public class KaijuUtilityIntegerBooleanConsideration : KaijuUtilityNumericBooleanConsideration
    {
        /// <summary>
        /// The value to compare against and get a Boolean result.
        /// </summary>
#if UNITY_EDITOR
        [Tooltip("The value to compare against and get a Boolean result.")]
#endif
        public int value;
        
        /// <summary>
        /// Get a boolean utility for this consideration.
        /// </summary>
        /// <param name="brain">The <see cref="KaijuUtilityBrain"/> this is considering for.</param>
        /// <returns>The boolean utility for this consideration.</returns>
        protected override bool BooleanEvaluate(KaijuUtilityBrain brain)
        {
            return greater ? brain.Get<int>(Key) >= value : brain.Get<int>(Key) <= value;
        }
        
        /// <summary>
        /// Get a description of the object.
        /// </summary>
        /// <returns>A description of the object.</returns>
        public override string ToString()
        {
            return $"{name} - Kaiju Utility Integer Boolean Consideration - Key: {Key} - Value: {value} - {(greater ? "Greater" : "Lesser")}";
        }
    }
}