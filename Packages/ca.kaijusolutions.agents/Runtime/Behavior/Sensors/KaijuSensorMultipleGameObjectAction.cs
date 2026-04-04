#if COM_UNITY_BEHAVIOR
using System;
using System.Collections.Generic;
using KaijuSolutions.Agents.Extensions;
using KaijuSolutions.Agents.Sensors;
using Unity.Properties;
using UnityEngine;

namespace KaijuSolutions.Agents.Behavior.Sensors
{
    /// <summary>
    /// Action to sense with a sensor which could have multiple readings of <see href="https://docs.unity3d.com/Manual/class-GameObject.html">GameObject</see>s.
    /// </summary>
    [Serializable]
    [GeneratePropertyBag]
    public abstract class KaijuSensorMultipleGameObjectAction<T> : KaijuSensorMultipleAction<T, GameObject> where T : KaijuSensor
    {
        /// <summary>
        /// Get the ideal candidate once found.
        /// </summary>
        /// <param name="candidates">The candidates to choose from.</param>
        protected override void GetIdeal(IEnumerable<GameObject> candidates)
        {
            // Nothing do actually return if no variable is assigned.
            if (observed != null)
            {
                observed.Value = nearest.Value ? sensor.Value.Agent.Nearest(candidates, out float _) : sensor.Value.Agent.Farthest(candidates, out float _);
            }
        }
        
        /// <summary>
        /// Get a description of the object.
        /// </summary>
        /// <returns>A description of the object.</returns>
        public override string ToString()
        {
            return $"Kaiju Sensor Multiple GameObject Action - Sensor: {(sensor.Value ? sensor.Value : "None")} - Sensor Type: {typeof(T).Name} - Observed: {(observed.Value ? observed.Value : "None")} - {(nearest.Value ? "Nearest" : "Farthest")}";
        }
    }
}
#endif