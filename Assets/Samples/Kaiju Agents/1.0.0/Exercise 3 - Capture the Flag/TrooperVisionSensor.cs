using System.Collections.Generic;
using KaijuSolutions.Agents.Sensors;
using UnityEngine;

namespace KaijuSolutions.Agents.Exercises.CTF
{
    /// <summary>
    /// Sensor to get all <see cref="Trooper"/>s.
    /// </summary>
    [AddComponentMenu("Kaiju Solutions/Agents/Exercises/Capture the Flag/Trooper Vision Sensor", 27)]
    [HelpURL("https://agents.kaijusolutions.ca/manual/capture-the-flag.html#trooper-vision-sensor")]
    public class TrooperVisionSensor : KaijuVisionSensor<Trooper>
    {
        /// <summary>
        /// The <see cref="Trooper"/> this is attached to.
        /// </summary>
        protected Trooper Attached;
        
        /// <summary>
        /// This function is called when the object becomes enabled and active.
        /// </summary>
        protected override void OnEnable()
        {
            base.OnEnable();
            
            if (Agent == null)
            {
                return;
            }
            
            Attached = Agent.GetComponent<Trooper>();
            if (Attached == null)
            {
                Debug.LogError($"Trooper Vision Sensor - No trooper component attached to the agent \"{Agent.name}\".", this);
            }
        }
        
        /// <summary>
        /// If there are no explicitly defined observable objects, define how to query for default observables.
        /// </summary>
        /// <returns>All active <see cref="Trooper"/>s.</returns>
        protected override IEnumerable<Trooper> DefaultObservables()
        {
            return Trooper.All;
        }
    }
}