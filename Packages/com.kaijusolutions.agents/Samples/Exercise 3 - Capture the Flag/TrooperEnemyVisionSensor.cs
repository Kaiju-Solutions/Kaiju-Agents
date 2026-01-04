using System.Collections.Generic;

namespace KaijuSolutions.Agents.Exercises.CTF
{
    /// <summary>
    /// Sensor to get all enemy <see cref="Trooper"/>s.
    /// </summary>
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