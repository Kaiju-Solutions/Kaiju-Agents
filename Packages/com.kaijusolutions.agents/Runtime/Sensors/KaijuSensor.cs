using UnityEngine;

namespace KaijuSolutions.Agents.Sensors
{
    /// <summary>
    /// Base sensor class.
    /// </summary>
#if UNITY_EDITOR
    [Icon("Packages/com.kaijusolutions.agents/Editor/Icon.png")]
    [HelpURL("https://agents.kaijusolutions.ca/manual/getting-started.html")]
#endif
    public abstract class KaijuSensor : MonoBehaviour
    {
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
        }
        
        /// <summary>
        /// Run the sensor.
        /// </summary>
        public abstract void Sense();
    }
}