using System;
using System.Collections.Generic;
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif
namespace KaijuSolutions.Agents.Exercises.CTF
{
    /// <summary>
    /// <see cref="Pickup"/> to restore <see cref="Trooper.Health"/>.
    /// </summary>
    [HelpURL("https://agents.kaijusolutions.ca/manual/capture-the-flag.html#health-pickup")]
    [AddComponentMenu("Kaiju Solutions/Agents/Exercises/Capture the Flag/Health Pickup", 34)]
    public class HealthPickup : NumberPickup
    {
        /// <summary>
        /// Get all active health pickups.
        /// </summary>
        public static IReadOnlyCollection<HealthPickup> All
        {
            get
            {
#if UNITY_EDITOR
                if (!Application.isPlaying)
                {
                    return Array.Empty<HealthPickup>();
                }
#endif
                return Cache;
            }
        }
        
        /// <summary>
        /// Cache currently active items.
        /// </summary>
        private static readonly HashSet<HealthPickup> Cache = new();
#if UNITY_EDITOR
        /// <summary>
        /// Handle manually resetting the domain.
        /// </summary>
        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.SubsystemRegistration)]
        private static void InitOnPlayMode()
        {
            Domain();
            EditorApplication.playModeStateChanged -= Domain;
            EditorApplication.playModeStateChanged += Domain;
        }
        
        /// <summary>
        /// Handle manually resetting the domain.
        /// </summary>
        /// <param name="state">The current editor state change.</param>
        private static void Domain(PlayModeStateChange state)
        {
            if (state != PlayModeStateChange.ExitingPlayMode)
            {
                return;
            }
            
            EditorApplication.playModeStateChanged -= Domain;
            Domain();
        }
        
        /// <summary>
        /// Handle manually resetting the domain.
        /// </summary>
        private static void Domain()
        {
            Cache.Clear();
        }
#endif
        /// <summary>
        /// Additional behaviour for when the active state of this has changed.
        /// </summary>
        /// <param name="active">If this is currently active or not.</param>
        protected override void OnSetActive(bool active)
        {
            if (active)
            {
                Cache.Add(this);
            }
            else
            {
                Cache.Remove(this);
            }
        }
        
        /// <summary>
        /// Destroying the attached Behaviour will result in the game or Scene receiving OnDestroy.
        /// </summary>
        private void OnDestroy()
        {
            Cache.Remove(this);
        }
    }
}