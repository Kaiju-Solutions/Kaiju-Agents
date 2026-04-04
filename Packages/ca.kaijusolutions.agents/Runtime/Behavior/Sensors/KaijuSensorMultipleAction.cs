#if COM_UNITY_BEHAVIOR
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using KaijuSolutions.Agents.Sensors;
using Unity.Behavior;
using Unity.Properties;
using UnityEngine;

namespace KaijuSolutions.Agents.Behavior.Sensors
{
    /// <summary>
    /// Action to sense with a sensor which could have multiple readings.
    /// </summary>
    [Serializable]
    [GeneratePropertyBag]
    public abstract class KaijuSensorMultipleAction<T, T0> : KaijuSensorAction<T, T0> where T : KaijuSensor where T0 : UnityEngine.Object
    {
        /// <summary>
        /// If we want to sort by nearest or furthest.
        /// </summary>
        [Tooltip("If we want to sort by nearest or furthest.")]
        [SerializeReference]
        public BlackboardVariable<bool> nearest = new(true);
        
        /// <summary>
        /// Get the ideal candidate once found.
        /// </summary>
        /// <param name="candidates">The candidates to choose from.</param>
        protected abstract void GetIdeal([NotNull] IEnumerable<T0> candidates);
        
        /// <summary>
        /// Get a description of the object.
        /// </summary>
        /// <returns>A description of the object.</returns>
        public override string ToString()
        {
            return $"Kaiju Sensor Multiple Action - Sensor: {(sensor.Value ? sensor.Value : "None")} - Sensor Type: {typeof(T).Name} - Observed: {(observed.Value ? observed.Value : "None")} - Observed Type: {typeof(T0).Name} - {(nearest.Value ? "Nearest" : "Farthest")}";
        }
    }
}
#endif