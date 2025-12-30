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
    public abstract class KaijuSensor : KaijuBehaviour
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
        public bool automatic = true;
        
        /// <summary>
        /// The agent this sensor is assigned to.
        /// </summary>
        public KaijuAgent Agent { get; private set; }
        
        /// <summary>
        /// This function is called when the object becomes enabled and active.
        /// </summary>
        private void OnEnable()
        {
            if (Agent == null)
            {
                Agent = GetComponentInParent<KaijuAgent>(true);
                if (Agent == null)
                {
                    Debug.LogError("Kaiju Sensor - No agent found for sensor.", this);
                    enabled = false;
                    return;
                }
            }
            
            Reset();
            Agent.RegisterSensor(this);
            OnEnabled?.Invoke();
            OnEnabledGlobal?.Invoke(this);
        }
        
        /// <summary>
        /// This function is called when the behaviour becomes disabled.
        /// </summary>
        private void OnDisable()
        {
            if (Agent != null)
            {
                Agent.UnregisterSensor(this);
            }
            
            Reset();
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
            Agent.SensorRun(this);
        }
        
        /// <summary>
        /// Run the sensor.
        /// </summary>
        protected abstract void Run();
        
        /// <summary>
        /// Perform any needed resetting of the sensor.
        /// </summary>
        protected virtual void Reset() { }
#if UNITY_EDITOR
        /// <summary>
        /// Allow for visualizing in the editor.
        /// <param name="position">The position of the <see cref="Agent"/>.</param>
        /// </summary>
        public virtual void Visualize(Vector3 position) { }
#endif
    }
}