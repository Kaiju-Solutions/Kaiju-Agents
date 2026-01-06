using System.Collections.Generic;
using UnityEngine;

namespace KaijuSolutions.Agents.Exercises.CTF
{
    /// <summary>
    /// Sensor to get all enemy <see cref="Trooper"/>s.
    /// </summary>
    [AddComponentMenu("Kaiju Solutions/Agents/Exercises/Capture the Flag/Trooper Enemy Vision Sensor", 28)]
    [HelpURL("https://agents.kaijusolutions.ca/manual/capture-the-flag.html#trooper-enemy-vision-sensor")]
    public class TrooperEnemyVisionSensor : TrooperVisionSensor
    {
        /// <summary>
        /// If there are no explicitly defined observable objects, define how to query for default observables.
        /// </summary>
        /// <returns>All active <see cref="Trooper"/>s on the other team.</returns>
        protected override IEnumerable<Trooper> DefaultObservables()
        {
            return Attached == null ? base.DefaultObservables() : Attached.TeamOne ? Trooper.AllTwo : Trooper.AllOne;
        }
    }
}