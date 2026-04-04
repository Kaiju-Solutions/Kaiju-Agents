#if UNITY_EDITOR
using UnityEngine;
#endif
namespace KaijuSolutions.Agents.Utility
{
    /// <summary>
    /// Allow for converting a float value to a Boolean decision.
    /// </summary>
#if UNITY_EDITOR
    [Icon("Packages/ca.kaijusolutions.agents/Editor/Icon.png")]
    [HelpURL("https://agents.kaijusolutions.ca/manual/utility-ai.html")]
    [CreateAssetMenu(menuName = "Kaiju Solutions/Agents/Utility/Float Boolean", fileName = "Float Boolean", order = 3)]
#endif
    public class KaijuUtilityFloatBooleanConsideration : KaijuUtilityNumericBooleanConsideration
    {
        /// <summary>
        /// The value to compare against and get a Boolean result.
        /// </summary>
#if UNITY_EDITOR
        [Tooltip("The value to compare against and get a Boolean result.")]
#endif
        public float value;
        
        /// <summary>
        /// Get a boolean utility for this consideration.
        /// </summary>
        /// <param name="brain">The <see cref="KaijuUtilityBrain"/> this is considering for.</param>
        /// <returns>The boolean utility for this consideration.</returns>
        protected override bool BooleanEvaluate(KaijuUtilityBrain brain)
        {
            return greater ? brain.Get<float>(Key) >= value : brain.Get<float>(Key) <= value;
        }
        
        /// <summary>
        /// Get a description of the object.
        /// </summary>
        /// <returns>A description of the object.</returns>
        public override string ToString()
        {
            return $"{name} - Kaiju Utility Float Boolean Consideration - Key: {Key} - Value: {value} - {(greater ? "Greater" : "Lesser")}";
        }
    }
}