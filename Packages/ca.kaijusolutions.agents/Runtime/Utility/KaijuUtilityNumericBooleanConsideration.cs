#if UNITY_EDITOR
using UnityEngine;
#endif
namespace KaijuSolutions.Agents.Utility
{
    /// <summary>
    /// Base <see cref="KaijuSolutions.Agents.Utility.KaijuUtilityConsideration"/> for comparing numeric values as booleans.
    /// </summary>
#if UNITY_EDITOR
    [Icon("Packages/ca.kaijusolutions.agents/Editor/Icon.png")]
    [HelpURL("https://agents.kaijusolutions.ca/manual/utility-ai.html")]
#endif
    public abstract class KaijuUtilityNumericBooleanConsideration : KaijuUtilityKeyConsideration
    {
        /// <summary>
        /// If this should evaluate to true when greater than the <see cref="KaijuSolutions.Agents.Utility.KaijuUtilityKeyConsideration.Key"/>.
        /// </summary>
#if UNITY_EDITOR
        [Tooltip("If this should evaluate to true when greater than the brain's key.")]
#endif
        public bool greater;
        
        /// <summary>
        /// Get the utility for this consideration from [0, 1].
        /// </summary>
        /// <param name="brain">The <see cref="KaijuSolutions.Agents.Utility.KaijuUtilityBrain"/> this is considering for.</param>
        /// <returns>The utility score for this consideration from [0, 1].</returns>
        public override float Evaluate(KaijuUtilityBrain brain)
        {
            return BooleanEvaluate(brain) ? 1f : 0f;
        }
        
        /// <summary>
        /// Get a boolean utility for this consideration.
        /// </summary>
        /// <param name="brain">The <see cref="KaijuSolutions.Agents.Utility.KaijuUtilityBrain"/> this is considering for.</param>
        /// <returns>The boolean utility for this consideration.</returns>
        protected abstract bool BooleanEvaluate(KaijuUtilityBrain brain);
        
        /// <summary>
        /// Get a description of the object.
        /// </summary>
        /// <returns>A description of the object.</returns>
        public override string ToString()
        {
            return $"{name} - Kaiju Utility Numeric Boolean Consideration - Key: {Key} - {(greater ? "Greater" : "Lesser")}";
        }
    }
}