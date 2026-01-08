using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using UnityEngine;

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
        
        /// <summary>
        /// Get a description of the object.
        /// </summary>
        /// <returns>A description of the object.</returns>
        public override string ToString()
        {
            return $"Kaiju Agents Multi-Matcher - Matchers: {Matchers.Count}";
        }
        
        /// <summary>
        /// Implicit conversion to a string.
        /// </summary>
        /// <param name="m">The matcher.</param>
        /// <returns>The string from the <see cref="ToString"/> method.</returns>
        public static implicit operator string([NotNull] KaijuAgentsMultiMatcher m) => m.ToString();
        
        /// <summary>
        /// Implicit conversion to a short integer based on the number of <see cref="Matchers"/>.
        /// </summary>
        /// <param name="m">The matcher.</param>
        /// <returns>The number of <see cref="Matchers"/>.</returns>
        public static implicit operator short([NotNull] KaijuAgentsMultiMatcher m) => (short)m.matchers.Count;
        
        /// <summary>
        /// Implicit conversion to a nullable short integer based on the number of <see cref="Matchers"/>.
        /// </summary>
        /// <param name="m">The matcher.</param>
        /// <returns>The number of <see cref="Matchers"/>.</returns>
        public static implicit operator short?([NotNull] KaijuAgentsMultiMatcher m) => (short?)m.matchers.Count;
        
        /// <summary>
        /// Implicit conversion to an unsigned short integer based on the number of <see cref="Matchers"/>.
        /// </summary>
        /// <param name="m">The matcher.</param>
        /// <returns>The number of <see cref="Matchers"/>.</returns>
        public static implicit operator ushort([NotNull] KaijuAgentsMultiMatcher m) => (ushort)m.matchers.Count;
        
        /// <summary>
        /// Implicit conversion to a nullable unsigned short integer based on the number of <see cref="Matchers"/>.
        /// </summary>
        /// <param name="m">The matcher.</param>
        /// <returns>The number of <see cref="Matchers"/>.</returns>
        public static implicit operator ushort?([NotNull] KaijuAgentsMultiMatcher m) => (ushort?)m.matchers.Count;
        
        /// <summary>
        /// Implicit conversion to an integer based on the number of <see cref="Matchers"/>.
        /// </summary>
        /// <param name="m">The matcher.</param>
        /// <returns>The number of <see cref="Matchers"/>.</returns>
        public static implicit operator int([NotNull] KaijuAgentsMultiMatcher m) => m.matchers.Count;
        
        /// <summary>
        /// Implicit conversion to a nullable integer based on the number of <see cref="Matchers"/>.
        /// </summary>
        /// <param name="m">The matcher.</param>
        /// <returns>The number of <see cref="Matchers"/>.</returns>
        public static implicit operator int?([NotNull] KaijuAgentsMultiMatcher m) => m.matchers.Count;
        
        /// <summary>
        /// Implicit conversion to an unsigned integer based on the number of <see cref="Matchers"/>.
        /// </summary>
        /// <param name="m">The matcher.</param>
        /// <returns>The number of <see cref="Matchers"/>.</returns>
        public static implicit operator uint([NotNull] KaijuAgentsMultiMatcher m) => (uint)m.matchers.Count;
        
        /// <summary>
        /// Implicit conversion to a nullable unsigned integer based on the number of <see cref="Matchers"/>.
        /// </summary>
        /// <param name="m">The matcher.</param>
        /// <returns>The number of <see cref="Matchers"/>.</returns>
        public static implicit operator uint?([NotNull] KaijuAgentsMultiMatcher m) => (uint?)m.matchers.Count;
        
        /// <summary>
        /// Implicit conversion to a long integer based on the number of <see cref="Matchers"/>.
        /// </summary>
        /// <param name="m">The matcher.</param>
        /// <returns>The number of <see cref="Matchers"/>.</returns>
        public static implicit operator long([NotNull] KaijuAgentsMultiMatcher m) => m.matchers.Count;
        
        /// <summary>
        /// Implicit conversion to a nullable long integer based on the number of <see cref="Matchers"/>.
        /// </summary>
        /// <param name="m">The matcher.</param>
        /// <returns>The number of <see cref="Matchers"/>.</returns>
        public static implicit operator long?([NotNull] KaijuAgentsMultiMatcher m) => m.matchers.Count;
        
        /// <summary>
        /// Implicit conversion to an unsigned long integer based on the number of <see cref="Matchers"/>.
        /// </summary>
        /// <param name="m">The matcher.</param>
        /// <returns>The number of <see cref="Matchers"/>.</returns>
        public static implicit operator ulong([NotNull] KaijuAgentsMultiMatcher m) => (ulong)m.matchers.Count;
        
        /// <summary>
        /// Implicit conversion to a nullable unsigned long integer based on the number of <see cref="Matchers"/>.
        /// </summary>
        /// <param name="m">The matcher.</param>
        /// <returns>The number of <see cref="Matchers"/>.</returns>
        public static implicit operator ulong?([NotNull] KaijuAgentsMultiMatcher m) => (ulong?)m.matchers.Count;
    }
}