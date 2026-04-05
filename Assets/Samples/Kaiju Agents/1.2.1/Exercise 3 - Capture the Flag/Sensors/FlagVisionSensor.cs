using System.Collections.Generic;
using KaijuSolutions.Agents.Sensors;
using UnityEngine;

namespace KaijuSolutions.Agents.Exercises.CTF
{
    /// <summary>
    /// Sensor for <see cref="Flag"/>s.
    /// </summary>
    [HelpURL("https://agents.kaijusolutions.ca/manual/capture-the-flag.html#flag-vision-sensor")]
    [AddComponentMenu("Kaiju Solutions/Agents/Exercises/Capture the Flag/Flag Vision Sensor", 32)]
    public class FlagVisionSensor : KaijuVisionSensor<Flag>
    {
        /// <summary>
        /// If there are no explicitly defined observable objects, define how to query for default observables.
        /// </summary>
        /// <returns>Both <see cref="Flag"/>s.</returns>
        protected override IEnumerable<Flag> DefaultObservables()
        {
            return Flag.Flags;
        }
        
        /// <summary>
        /// Get a description of the object.
        /// </summary>
        /// <returns>A description of the object.</returns>
        public override string ToString()
        {
            return $"{name} - Flag Vision Sensor - Agent: {(Agent ? Agent : "None")} - Distance: {Distance} - Angle: {Angle} - Line-of-Sight: {(lineOfSight ? "Yes" : "No")} - Radius: {Radius}";
        }
    }
}