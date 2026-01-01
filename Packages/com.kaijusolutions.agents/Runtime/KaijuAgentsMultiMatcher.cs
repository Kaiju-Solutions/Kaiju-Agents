using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
#if UNITY_EDITOR
using UnityEngine;
#endif
namespace KaijuSolutions.Agents
{
    /// <summary>
    /// Helper to match multiple <see cref="KaijuAgentsMatcher"/> instances together which all must succeed.
    /// </summary>
    [Serializable]
    public class KaijuAgentsMultiMatcher
    {
        /// <summary>
        /// <see cref="KaijuAgentsMatcher"/> instances to compare where they all must pass their condition.
        /// </summary>
        public List<KaijuAgentsMatcher> Matchers
        {
            get => matchers;
            set
            {
                if (value == null)
                {
                    matchers.Clear();
                    return;
                }
                
                matchers = value;
            }
        }
        
        /// <summary>
        /// <see cref="KaijuAgentsMatcher"/> instances to compare where they all must pass their condition.
        /// </summary>
#if UNITY_EDITOR
        [Header("Filtering")]
        [Tooltip("Matcher instances to compare.")]
#endif
        [SerializeField]
        private List<KaijuAgentsMatcher> matchers;
        
        /// <summary>
        /// Get if this is a match.
        /// </summary>
        /// <param name="value">The value to match against.</param>
        /// <returns>If the value matches all the <see cref="matchers"/> to see if they all pass.</returns>
        public bool Matched([NotNull] string value)
        {
            // Check single matchers first.
            foreach (KaijuAgentsMatcher matcher in matchers)
            {
                if (!matcher.Matched(value))
                {
                    return false;
                }
            }
            
            return true;
        }
    }
}