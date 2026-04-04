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
    /// Action to sense with a sensor which could have multiple readings of components.
    /// </summary>
    [Serializable]
    [GeneratePropertyBag]
    public abstract class KaijuSensorMultipleComponentAction<T, T0> : KaijuSensorMultipleAction<T, T0> where T : KaijuSensor where T0 : Component
    {
        /// <summary>
        /// Get the ideal candidate once found.
        /// </summary>
        /// <param name="candidates">The candidates to choose from.</param>
        protected override void GetIdeal(IEnumerable<T0> candidates)
        {
            // Nothing do actually return if no variable is assigned.
            if (observed != null)
            {
                observed.Value = nearest.Value ? sensor.Value.Agent.Nearest(candidates, out float _) : sensor.Value.Agent.Farthest(candidates, out float _);
            }
        }
    }
}
#endif