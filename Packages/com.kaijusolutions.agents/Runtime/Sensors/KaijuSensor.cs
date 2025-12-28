using UnityEngine;

namespace KaijuSolutions.Agents.Sensors
{
    /// <summary>
    /// Base sensor class.
    /// </summary>
    [DefaultExecutionOrder(int.MinValue)]
#if UNITY_EDITOR
    [Icon("Packages/com.kaijusolutions.agents/Editor/Icon.png")]
    [HelpURL("https://agents.kaijusolutions.ca/manual/getting-started.html")]
#endif
    public abstract class KaijuSensor : MonoBehaviour
    {
        /// <summary>
        /// Callback for when this sensor has been run.
        /// </summary>
        public event KaijuAction OnSense;
        
        /// <summary>
        /// Global callback for when this sensor has been run.
        /// </summary>
        public event KaijuSensorAction OnSenseGlobal;
        
        /// <summary>
        /// Callback for when this has finishing becoming enabled.
        /// </summary>
        public event KaijuAction OnEnabled;
        
        /// <summary>
        /// Global callback for when this has finishing becoming enabled.
        /// </summary>
        public static event KaijuSensorAction OnEnabledGlobal;
        
        /// <summary>
        /// Callback for when this has finishing becoming disabled.
        /// </summary>
        public event KaijuAction OnDisabled;
        
        /// <summary>
        /// Global callback for when this has finishing becoming disabled.
        /// </summary>
        public static event KaijuSensorAction OnDisabledGlobal;
        
        /// <summary>
        /// If this sensor should be run automatically.
        /// </summary>
#if UNITY_EDITOR
        [Tooltip("If this sensor should be run automatically.")]
#endif
        public bool automatic;
        
        /// <summary>
        /// The agent this sensor is assigned to.
        /// </summary>
        private KaijuAgent _agent;
        
        /// <summary>
        /// This function is called when the object becomes enabled and active.
        /// </summary>
        private void OnEnable()
        {
            if (_agent == null)
            {
                _agent = GetComponentInParent<KaijuAgent>(true);
                if (_agent == null)
                {
                    Debug.LogError("Kaiju Sensor - No agent found for sensor.", this);
                    enabled = false;
                    return;
                }
            }
            
            _agent.RegisterSensor(this);
            OnEnabled?.Invoke();
            OnEnabledGlobal?.Invoke(this);
        }
        
        /// <summary>
        /// This function is called when the behaviour becomes disabled.
        /// </summary>
        private void OnDisable()
        {
            if (_agent != null)
            {
                _agent.UnregisterSensor(this);
            }
            
            OnDisabled?.Invoke();
            OnDisabledGlobal?.Invoke(this);
        }
        
        /// <summary>
        /// Run the sensor.
        /// </summary>
        public void Sense()
        {
            Run();
            OnSense?.Invoke();
            OnSenseGlobal?.Invoke(this);
            _agent.SensorRun(this);
        }
        
        /// <summary>
        /// Run the sensor.
        /// </summary>
        protected abstract void Run();
    }
}