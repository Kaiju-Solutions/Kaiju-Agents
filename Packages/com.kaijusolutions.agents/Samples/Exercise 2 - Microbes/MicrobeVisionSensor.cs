using System.Collections.Generic;
using KaijuSolutions.Agents.Sensors;
using UnityEngine;

namespace KaijuSolutions.Agents.Exercises.Microbes
{
    /// <summary>
    /// Sensor to detect <see cref="Microbe"/>s
    /// </summary>
    [HelpURL("https://agents.kaijusolutions.ca/manual/microbes.html#microbe-vision-sensor")]
    [AddComponentMenu("Kaiju Solutions/Agents/Exercises/Microbes/Microbe Vision Sensor", 20)]
    public class MicrobeVisionSensor : KaijuVisionSensor<Microbe>
    {
        /// <summary>
        /// If there are no explicitly defined observable objects, define how to query for default observables.
        /// </summary>
        /// <returns>All active <see cref="Microbe"/>s from <see cref="Microbe.All"/>.</returns>
        protected override IEnumerable<Microbe> DefaultObservables()
        {
            return Microbe.All;
        }
    }
}