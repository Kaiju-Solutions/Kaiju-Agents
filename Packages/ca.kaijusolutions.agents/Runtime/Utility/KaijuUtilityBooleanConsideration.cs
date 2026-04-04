using System.Diagnostics.CodeAnalysis;
#if UNITY_EDITOR
using UnityEngine;
#endif
namespace KaijuSolutions.Agents.Utility
{
    /// <summary>
    /// <see cref="KaijuUtilityConsideration"/> which acts as a boolean, returning one or zero depending on its evaluation.
    /// </summary>
#if UNITY_EDITOR
    [Icon("Packages/ca.kaijusolutions.agents/Editor/Icon.png")]
    [HelpURL("https://agents.kaijusolutions.ca/manual/utility-ai.html")]
    [CreateAssetMenu(menuName = "Kaiju Solutions/Agents/Utility/Boolean", fileName = "Boolean", order = 1)]
#endif
    public class KaijuUtilityBooleanConsideration : KaijuUtilityKeyConsideration
    {
        /// <summary>
        /// If the result should be inverted, meaning a true value in the <see cref="KaijuUtilityKeyConsideration.Key"/> will return a zero instead of a one and vice versa.
        /// </summary>
#if UNITY_EDITOR
        [Tooltip("If the result should be inverted, meaning a true value in the key will return a zero instead of a one and vice versa.")]
#endif
        public bool invert;
        
        /// <summary>
        /// Get the utility for this consideration from [0, 1].
        /// </summary>
        /// <param name="brain">The <see cref="KaijuUtilityBrain"/> this is considering for.</param>
        /// <returns>The utility score for this consideration from [0, 1].</returns>
        public override float Evaluate([NotNull] KaijuUtilityBrain brain)
        {
            return brain.Get<bool>(Key) ? invert ? 0f : 1f : invert ? 1f : 0f;
        }
        
        /// <summary>
        /// Get a description of the object.
        /// </summary>
        /// <returns>A description of the object.</returns>
        public override string ToString()
        {
            return $"{name} - Kaiju Utility Boolean Consideration - Key: {Key}{(invert ? " - Invert" : string.Empty)}";
        }
    }
}