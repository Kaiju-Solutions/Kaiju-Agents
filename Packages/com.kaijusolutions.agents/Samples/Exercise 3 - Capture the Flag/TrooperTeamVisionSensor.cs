using System.Collections.Generic;

namespace KaijuSolutions.Agents.Exercises.CTF
{
    /// <summary>
    /// Sensor to get all friendly <see cref="Trooper"/>s.
    /// </summary>
    public class TrooperTeamVisionSensor : TrooperVisionSensor
    {
        /// <summary>
        /// If there are no explicitly defined observable objects, define how to query for default observables.
        /// </summary>
        /// <returns>All active <see cref="Trooper"/>s on the same team.</returns>
        protected override IEnumerable<Trooper> DefaultObservables()
        {
            return Attached == null ? base.DefaultObservables() : Attached.TeamOne ? Trooper.AllOne : Trooper.AllTwo;
        }
    }
}