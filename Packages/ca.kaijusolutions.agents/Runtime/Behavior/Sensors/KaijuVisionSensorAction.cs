#if COM_UNITY_BEHAVIOR
using System;
using KaijuSolutions.Agents.Sensors;
using Unity.Properties;
using UnityEngine;

namespace KaijuSolutions.Agents.Behavior.Sensors
{
    /// <summary>
    /// Action to sense with a <see cref="KaijuVisionSensor{T}"/> which could have multiple readings of components.
    /// </summary>
    /// <typeparam name="T">The type of <see cref="KaijuVisionSensor{T}"/></typeparam>
    /// <typeparam name="T0">The type of component this is for.</typeparam>
    [Serializable]
    [GeneratePropertyBag]
    public abstract class KaijuVisionSensorAction<T, T0> : KaijuSensorMultipleComponentAction<T, T0> where T : KaijuVisionSensor<T0> where T0 : Component
    {
        /// <summary>
        /// OnUpdate is called each frame while the node is running.
        /// </summary>
        /// <returns>The status of the node.</returns>
        protected override Status HandleSensor()
        {
            // Keep running if we have not yet hit anything.
            if (sensor.Value.ObservedCount < 1)
            {
                return Status.Running;
            }
            
            // Cache the observation and indicate this has been successful.
            GetIdeal(sensor.Value.Observed);
            return Status.Success;
        }
    }
}
#endif