using System.Collections.Generic;
using KaijuSolutions.Agents.Sensors;
using UnityEngine;

namespace KaijuSolutions.Agents.Exercises.CTF
{
    /// <summary>
    /// Sensor for <see cref="AmmoPickup"/>s.
    /// </summary>
    [HelpURL("https://agents.kaijusolutions.ca/manual/capture-the-flag.html#ammo-vision-sensor")]
    [AddComponentMenu("Kaiju Solutions/Agents/Exercises/Capture the Flag/Ammo Vision Sensor", 30)]
    public class AmmoVisionSensor : KaijuVisionSensor<AmmoPickup>
    {
        /// <summary>
        /// If there are no explicitly defined observable objects, define how to query for default observables.
        /// </summary>
        /// <returns>All active <see cref="AmmoPickup"/>s.</returns>
        protected override IEnumerable<AmmoPickup> DefaultObservables()
        {
            return AmmoPickup.All;
        }
        
        /// <summary>
        /// Get a description of the object.
        /// </summary>
        /// <returns>A description of the object.</returns>
        public override string ToString()
        {
            return $"{name} - Ammo Vision Sensor - Agent: {(Agent ? Agent : "None")} - Distance: {Distance} - Angle: {Angle} - Line-of-Sight: {(lineOfSight ? "Yes" : "No")} - Radius: {Radius}";
        }
    }
}