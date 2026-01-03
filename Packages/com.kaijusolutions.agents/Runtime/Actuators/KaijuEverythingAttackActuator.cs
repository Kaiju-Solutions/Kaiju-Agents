using System.Collections.Generic;
using UnityEngine;

namespace KaijuSolutions.Agents.Actuators
{
    /// <summary>
    /// <see cref="KaijuAttackActuator"/> based on <see href="https://docs.unity3d.com/Manual/class-Transform.html">transforms</see>, allowing it to attack anything. You can optionally filter objects by name to limit what is returned.
    /// As <see href="https://docs.unity3d.com/Manual/class-Transform.html">transforms</see> are directly returned by hits in the underlying class, this is actually quite efficient than compared to making a custom version to get a specific component type.
    /// </summary>
    [DefaultExecutionOrder(int.MinValue + 1)]
#if UNITY_EDITOR
    [AddComponentMenu("Kaiju Solutions/Agents/Actuators/Kaiju Everything Vision Sensor", 7)]
    [Icon("Packages/com.kaijusolutions.agents/Editor/Icon.png")]
    [HelpURL("https://agents.kaijusolutions.ca/manual/getting-started.html")]
#endif
    public class KaijuEverythingAttackActuator : KaijuAttackActuator
    {
        /// <summary>
        /// If objects hit by this should be disabled. Otherwise, they will be destroyed.
        /// </summary>
#if UNITY_EDITOR
        [Tooltip("If objects hit by this should be disabled. Otherwise, they will be destroyed.")]
#endif
        [SerializeField]
        private bool disableHits;
        
        /// <summary>
        /// What to match names of the objects to provide extra filtering.
        /// </summary>
        public List<KaijuAgentsMultiMatcher> Matcher
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
        /// What to match names of the objects to provide extra filtering, with only one collection needing to pass.
        /// </summary>
#if UNITY_EDITOR
        [Tooltip("What to match names of the objects to provide extra filtering, with only one collection needing to pass.")]
#endif
        [SerializeField]
        private List<KaijuAgentsMultiMatcher> matchers;
        
        /// <summary>
        /// See if any of the matchers match.
        /// </summary>
        /// <param name="x">The name of an object to compare with.</param>
        /// <returns>If any of the matchers match.</returns>
        private bool Matched(string x)
        {
            foreach (KaijuAgentsMultiMatcher matcher in matchers)
            {
                if (matcher.Matched(x))
                {
                    return true;
                }
            }
            
            return matchers.Count < 1;
        }
        
        /// <summary>
        /// Handle the hit logic.
        /// </summary>
        /// <param name="hit">The hit details.</param>
        /// <returns>If the attack was a success or not.</returns>
        protected override bool HandleHit(RaycastHit hit)
        {
            if (!Matched(hit.transform.name))
            {
                return false;
            }
            
            // Disable or destroy the target based on the setting.
            if (disableHits)
            {
                transform.gameObject.SetActive(false);
            }
            else
            {
                Destroy(transform.gameObject);
            }
            
            return true;
        }
    }
}