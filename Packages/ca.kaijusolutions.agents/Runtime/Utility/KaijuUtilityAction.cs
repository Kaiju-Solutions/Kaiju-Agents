using System.Diagnostics.CodeAnalysis;
using UnityEngine;

namespace KaijuSolutions.Agents.Utility
{
    /// <summary>
    /// Base class for actions to perform.
    /// </summary>
#if UNITY_EDITOR
    [Icon("Packages/ca.kaijusolutions.agents/Editor/Icon.png")]
    [HelpURL("https://agents.kaijusolutions.ca/manual/utility-ai.html")]
#endif
    public abstract class KaijuUtilityAction : ScriptableObject
    {
        /// <summary>
        /// The <see cref="KaijuUtilityConsideration"/> for evaluating this action.
        /// </summary>
#if UNITY_EDITOR
        [field: Tooltip("The consideration for evaluating this action.")]
#endif
        [field: SerializeField]
        public KaijuUtilityConsideration Consideration { get; private set; }
        
        /// <summary>
        /// Get the utility score of this action.
        /// </summary>
        /// <param name="brain">The <see cref="KaijuUtilityBrain"/> this is calculating the utility for.</param>
        /// <returns>The utility score of this action.</returns>
        public float Utility([NotNull] KaijuUtilityBrain brain) => Consideration ? Consideration.Evaluate(brain) : 0;
        
        /// <summary>
        /// Called when this action is run for the first time.
        /// </summary>
        /// <param name="brain">The <see cref="KaijuUtilityBrain"/> this is for.</param>
        public virtual void Enter([NotNull] KaijuUtilityBrain brain) { }
        
        /// <summary>
        /// Called every instance this action is running.
        /// </summary>
        /// <param name="brain">The <see cref="KaijuUtilityBrain"/> this is for.</param>
        public virtual void Execute([NotNull] KaijuUtilityBrain brain) { }
        
        /// <summary>
        /// Called when this action is stopping its execution.
        /// </summary>
        /// <param name="brain">The <see cref="KaijuUtilityBrain"/> this is for.</param>
        public virtual void Exit([NotNull] KaijuUtilityBrain brain) { }
    }
}