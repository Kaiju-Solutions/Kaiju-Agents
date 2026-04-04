using System;
using System.Diagnostics.CodeAnalysis;
using UnityEngine;

namespace KaijuSolutions.Agents
{
    /// <summary>
    /// Helper to allow for matching and comparing objects.
    /// </summary>
    [Serializable]
    public class KaijuAgentsMatcher
    {
        /// <summary>
        /// The string the match against.
        /// </summary>
        public string Match
        {
            get => match;
            set => match = value ?? string.Empty;
        }
        
        /// <summary>
        /// The string the match against.
        /// </summary>
#if UNITY_EDITOR
        [Tooltip("The string the match against.")]
#endif
        [SerializeField]
        private string match;
        
        /// <summary>
        /// The mode for how to compare the <see cref="match"/> value.
        /// </summary>
#if UNITY_EDITOR
        [Tooltip("The mode for how to compare the match value.\n" +
                 "Equal - Must be equal.\n" +
                 "Not Equal - Must be not equal.\n" +
                 "Contains - The \"match\" must be contained within the value being compared against.\n" +
                 "Contained - The \"match\" must contain value being compared against.\n" +
                 "Starts With - The value being compared against must start with the \"match\".\n" +
                 "Started With - The \"match\" must start with the value being compared against.\n" +
                 "Ends With - The value being compared against must end with the \"match\".\n" +
                 "Ended With - The \"match\" must end with the value being compared against.\n")]
#endif
        public KaijuAgentsMatcherMode mode;
        
        /// <summary>
        /// Create a matcher.
        /// </summary>
        /// <param name="match">The string to match against.</param>
        /// <param name="mode">The mode for how to compare the <see cref="match"/>.</param>
        public KaijuAgentsMatcher(string match = "", KaijuAgentsMatcherMode mode = KaijuAgentsMatcherMode.Equal)
        {
            this.match = match;
            this.mode = mode;
        }
        
        /// <summary>
        /// Get if this is a match.
        /// </summary>
        /// <param name="value">The value to match against.</param>
        /// <returns>If the value matches the <see cref="match"/> parameter given the <see cref="mode"/>.</returns>
        public bool Matched([NotNull] string value)
        {
            switch (mode)
            {
                case KaijuAgentsMatcherMode.Equal:
                default:
                    return match == value;
                case KaijuAgentsMatcherMode.NotEqual:
                    return match != value;
                case KaijuAgentsMatcherMode.Contains:
                    return value.Contains(match);
                case KaijuAgentsMatcherMode.Contained:
                    return match.Contains(value);
                case KaijuAgentsMatcherMode.StartsWith:
                    return value.StartsWith(match);
                case KaijuAgentsMatcherMode.StartedWith:
                    return match.StartsWith(value);
                case KaijuAgentsMatcherMode.EndsWith:
                    return value.EndsWith(match);
                case KaijuAgentsMatcherMode.EndedWith:
                    return match.EndsWith(value);
            }
        }
        
        /// <summary>
        /// Get a description of the object.
        /// </summary>
        /// <returns>A description of the object.</returns>
        public override string ToString()
        {
            return $"Kaiju Agents Matcher - Match: {match} - Mode: {mode}";
        }
        
        /// <summary>
        /// Implicit conversion to a string from the <see cref="Match"/>.
        /// </summary>
        /// <param name="m">The matcher.</param>
        /// <returns>The string from the <see cref="Match"/>.</returns>
        public static implicit operator string([NotNull] KaijuAgentsMatcher m) => m.match;
        
        /// <summary>
        /// Implicit conversion to a <see cref="KaijuAgentsMatcherMode"/> from the <see cref="mode"/>.
        /// </summary>
        /// <param name="m">The matcher.</param>
        /// <returns>The <see cref="KaijuAgentsMatcherMode"/> from the <see cref="mode"/>.</returns>
        public static implicit operator KaijuAgentsMatcherMode([NotNull] KaijuAgentsMatcher m) => m.mode;
        
        /// <summary>
        /// Implicit conversion to a nullable <see cref="KaijuAgentsMatcherMode"/> from the <see cref="mode"/>.
        /// </summary>
        /// <param name="m">The matcher.</param>
        /// <returns>The <see cref="KaijuAgentsMatcherMode"/> from the <see cref="mode"/>.</returns>
        public static implicit operator KaijuAgentsMatcherMode?([NotNull] KaijuAgentsMatcher m) => m.mode;
        
        /// <summary>
        /// How for matchers to compare.
        /// </summary>
        public enum KaijuAgentsMatcherMode
        {
            /// <summary>
            /// Must be equal.
            /// </summary>
            Equal = 0,
            
            /// <summary>
            /// Must be not equal.
            /// </summary>
            NotEqual = 1,
            
            /// <summary>
            /// The <see cref="KaijuAgentsMatcher.match"/> must be contained within the value being compared against.
            /// </summary>
            Contains = 2,
            
            /// <summary>
            /// The <see cref="KaijuAgentsMatcher.match"/> must contain value being compared against.
            /// </summary>
            Contained = 3,
            
            /// <summary>
            /// The value being compared against must start with the <see cref="KaijuAgentsMatcher.match"/>.
            /// </summary>
            StartsWith = 4,
            
            /// <summary>
            /// The <see cref="KaijuAgentsMatcher.match"/> must start with the value being compared against.
            /// </summary>
            StartedWith = 5,
            
            /// <summary>
            /// The value being compared against must end with the <see cref="KaijuAgentsMatcher.match"/>.
            /// </summary>
            EndsWith = 6,
            
            /// <summary>
            /// The <see cref="KaijuAgentsMatcher.match"/> must start with the value being compared against.
            /// </summary>
            EndedWith = 7
        }
    }
}