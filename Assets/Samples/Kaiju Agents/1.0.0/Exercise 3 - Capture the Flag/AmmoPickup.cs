using System.Collections.Generic;
using UnityEngine;

namespace KaijuSolutions.Agents.Exercises.CTF
{
    /// <summary>
    /// <see cref="Pickup"/> to restore ammo.
    /// </summary>
    [HelpURL("https://agents.kaijusolutions.ca/manual/capture-the-flag.html#ammo-pickup")]
    [AddComponentMenu("Kaiju Solutions/Agents/Exercises/Capture the Flag/Ammo Pickup", 33)]
    public class AmmoPickup : NumberPickup
    {
        /// <summary>
        /// Get all active ammo pickups.
        /// </summary>
        public static IReadOnlyCollection<AmmoPickup> All => Cache;
        
        /// <summary>
        /// Cache currently active items.
        /// </summary>
        private static readonly HashSet<AmmoPickup> Cache = new();
        
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