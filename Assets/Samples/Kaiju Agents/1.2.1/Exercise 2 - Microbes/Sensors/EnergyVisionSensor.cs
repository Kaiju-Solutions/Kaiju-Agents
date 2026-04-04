using System.Collections.Generic;
using KaijuSolutions.Agents.Sensors;
using UnityEngine;

namespace KaijuSolutions.Agents.Exercises.Microbes
{
    /// <summary>
    /// Sensor to detect <see cref="EnergyPickup"/>s
    /// </summary>
    [HelpURL("https://agents.kaijusolutions.ca/manual/microbes.html#energy-vision-sensor")]
    [AddComponentMenu("Kaiju Solutions/Agents/Exercises/Microbes/Energy Vision Sensor", 21)]
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
        
        /// <summary>
        /// Get a description of the object.
        /// </summary>
        /// <returns>A description of the object.</returns>
        public override string ToString()
        {
            return $"Energy Vision Sensor {name} - Agent: {(Agent ? Agent.name : "None")} - Distance: {Distance} - Angle: {Angle} - Line-of-Sight: {(lineOfSight ? "Yes" : "No")} - Radius: {Radius}";
        }
    }
}