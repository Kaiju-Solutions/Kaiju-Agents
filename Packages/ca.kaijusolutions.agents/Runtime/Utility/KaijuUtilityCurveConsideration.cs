using System.Diagnostics.CodeAnalysis;
#if UNITY_EDITOR
using UnityEngine;
#endif
namespace KaijuSolutions.Agents.Utility
{
    /// <summary>
    /// Allow for visualizing a curve.
    /// </summary>
#if UNITY_EDITOR
    [Icon("Packages/ca.kaijusolutions.agents/Editor/Icon.png")]
    [HelpURL("https://agents.kaijusolutions.ca/manual/utility-ai.html")]
    [CreateAssetMenu(menuName = "Kaiju Solutions/Agents/Utility/Curve", fileName = "Curve", order = 4)]
#endif
    public class KaijuUtilityCurveConsideration : KaijuUtilityKeyConsideration
    {
        /// <summary>
        /// The curve for the utility function.
        /// </summary>
#if UNITY_EDITOR
        [Tooltip("The curve for the utility function.")]
#endif
        public AnimationCurve curve;
        
        /// <summary>
        /// Get the utility for this consideration from [0, 1].
        /// </summary>
        /// <param name="brain">The <see cref="KaijuSolutions.Agents.Utility.KaijuUtilityBrain"/> this is considering for.</param>
        /// <returns>The utility score for this consideration from [0, 1].</returns>
        public override float Evaluate([NotNull] KaijuUtilityBrain brain)
        {
            return Mathf.Clamp01(curve.Evaluate(brain.Get<float>(Key)));
        }
#if UNITY_EDITOR
        /// <summary>
        /// Reset to default values.
        /// </summary>
        private void Reset()
        {
            curve = new(new Keyframe(0f, 1f), new Keyframe(1f, 0f));
        }
#endif
        /// <summary>
        /// Get a description of the object.
        /// </summary>
        /// <returns>A description of the object.</returns>
        public override string ToString()
        {
            return $"{name} - Kaiju Utility Curve Consideration - Key: {Key}";
        }
    }
}