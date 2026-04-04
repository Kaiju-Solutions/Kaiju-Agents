#if COM_UNITY_BEHAVIOR
using System;
using KaijuSolutions.Agents.Sensors;
using Unity.Behavior;
using Unity.Properties;
using UnityEngine;
using Action = Unity.Behavior.Action;

namespace KaijuSolutions.Agents.Behavior.Sensors
{
    /// <summary>
    /// Action to end a sensor.
    /// </summary>
    [Serializable]
    [GeneratePropertyBag]
    public abstract class KaijuSensorAction<T, T0> : Action where T : KaijuSensor where T0 : UnityEngine.Object
    {
        /// <summary>
        /// The original sensor automatic setting.
        /// </summary>
        private bool _original;
        
        /// <summary>
        /// The sensor this is for.
        /// </summary>
        [Tooltip("The sensor to read from. If it is not assigned, will try to find the first sensor of this type on of the first agent variable found.")]
        [SerializeReference]
        public BlackboardVariable<T> sensor;
        
        /// <summary>
        /// Where to set the observed value to.
        /// </summary>
        [Tooltip("The detected instance.")]
        [SerializeReference]
        public BlackboardVariable<T0> observed;
        
        /// <summary>
        /// OnStart is called when the node starts running.
        /// </summary>
        /// <returns>The status of the node.</returns>
        protected override Status OnStart()
        {
            if (!ValidSensor())
            {
                return Status.Failure;
            }
            
            // We need to run the sensor automatically with this, but cache the original value so we can later restore it.
            _original = sensor.Value.automatic;
            sensor.Value.automatic = true;
            return Status.Running;
        }
        
        /// <summary>
        /// OnUpdate is called each frame while the node is running.
        /// </summary>
        /// <returns>The status of the node.</returns>
        protected override Status OnUpdate()
        {
            return ValidSensor() ? HandleSensor() : Status.Failure;
        }
        
        /// <summary>
        /// OnEnd is called when the node has stopped running.
        /// </summary>
        protected override void OnEnd()
        {
            // Restore the original value.
            if (sensor != null && sensor.Value != null)
            {
                sensor.Value.automatic = _original;
            }
        }
        
        /// <summary>
        /// See if this sensor is valid or not.
        /// </summary>
        /// <returns>If the sensor is valid or not.</returns>
        protected bool ValidSensor()
        {
            sensor ??= new();
            
            // If there is no sensor, try and get one from an agent.
            if (!sensor.Value)
            {
                BlackboardVariable<KaijuAgent> agent = KaijuAgentGraphAction.EnsureAgent(GameObject);
                if (agent == null || !agent.Value)
                {
                    return false;
                }
                
                sensor.Value = agent.Value.GetSensor<T>();
            }
            
            // The sensor and agent must be active.
            return sensor.Value && sensor.Value.Agent;
        }
        
        /// <summary>
        /// Read from the sensor.
        /// </summary>
        /// <returns>The result of reading from the sensor.</returns>
        protected abstract Status HandleSensor();
        
        /// <summary>
        /// Get a description of the object.
        /// </summary>
        /// <returns>A description of the object.</returns>
        public override string ToString()
        {
            return $"Kaiju Sensor Action - Sensor: {(sensor.Value ? sensor.Value : "None")} - Sensor Type: {typeof(T).Name} - Observed: {(observed.Value ? observed.Value : "None")} - Observed Type: {typeof(T0).Name}";
        }
    }
}
#endif