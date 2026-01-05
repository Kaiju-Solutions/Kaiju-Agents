using System.Collections.Generic;
using UnityEngine;

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
        public static IReadOnlyCollection<HealthPickup> All => Cache;
        
        /// <summary>
        /// Cache currently active items.
        /// </summary>
        private static readonly HashSet<HealthPickup> Cache = new();
        
        /// <summary>
        /// Handle manually resetting the domain.
        /// </summary>
        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.SubsystemRegistration)]
        private static void InitOnPlayMode()
        {
            Cache.Clear();
        }
        
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
    }
}