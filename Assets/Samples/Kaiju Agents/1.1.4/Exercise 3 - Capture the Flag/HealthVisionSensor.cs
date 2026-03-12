using System.Collections.Generic;
using KaijuSolutions.Agents.Sensors;
using UnityEngine;

namespace KaijuSolutions.Agents.Exercises.CTF
{
    /// <summary>
    /// Sensor for <see cref="HealthPickup"/>s.
    /// </summary>
    [HelpURL("https://agents.kaijusolutions.ca/manual/capture-the-flag.html#health-vision-sensor")]
    [AddComponentMenu("Kaiju Solutions/Agents/Exercises/Capture the Flag/Health Vision Sensor", 31)]
    public class HealthVisionSensor : KaijuVisionSensor<HealthPickup>
    {
        /// <summary>
        /// If there are no explicitly defined observable objects, define how to query for default observables.
        /// </summary>
        /// <returns>All active <see cref="HealthPickup"/>s.</returns>
        protected override IEnumerable<HealthPickup> DefaultObservables()
        {
            return HealthPickup.All;
        }
    }
}