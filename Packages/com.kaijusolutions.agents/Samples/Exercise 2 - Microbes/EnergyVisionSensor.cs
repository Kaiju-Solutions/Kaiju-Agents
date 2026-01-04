using System.Collections.Generic;
using KaijuSolutions.Agents.Sensors;

namespace KaijuSolutions.Agents.Exercises.Microbes
{
    /// <summary>
    /// Sensor to detect <see cref="EnergyPickup"/>s
    /// </summary>
    public class EnergyVisionSensor : KaijuVisionSensor<EnergyPickup>
    {
        /// <summary>
        /// If there are no explicitly defined observable objects, define how to query for default observables.
        /// </summary>
        /// <returns>All active <see cref="EnergyPickup"/>s from <see cref="EnergyPickup.All"/>.</returns>
        protected override IEnumerable<EnergyPickup> DefaultObservables()
        {
            return EnergyPickup.All;
        }
    }
}