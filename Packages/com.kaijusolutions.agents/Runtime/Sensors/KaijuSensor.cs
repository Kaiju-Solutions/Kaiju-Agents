using System.Diagnostics.CodeAnalysis;
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
        public static event KaijuSensorAction OnSenseGlobal;
        
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
            
            Cleanup();
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
            
            Cleanup();
            OnDisabled?.Invoke();
            OnDisabledGlobal?.Invoke(this);
        }
        
        /// <summary>
        /// Run the sensor. There is no point in manually calling this.
        /// </summary>
        public void Sense()
        {
            Run();
            Agent?.SensorRun(this);
            OnSense?.Invoke();
            OnSenseGlobal?.Invoke(this);
        }
        
        /// <summary>
        /// Run the sensor.
        /// </summary>
        protected abstract void Run();
        
        /// <summary>
        /// Perform any needed resetting of the sensor.
        /// </summary>
        protected virtual void Cleanup() { }
#if UNITY_EDITOR
        /// <summary>
        /// Allow for visualizing in the editor.
        /// <param name="position">The position of the <see cref="Agent"/>.</param>
        /// </summary>
        public virtual void EditorVisualize(Vector3 position) { }
#endif
        /// <summary>
        /// Get a description of the object.
        /// </summary>
        /// <returns>A description of the object.</returns>
        public override string ToString()
        {
            return $"Kaiju Sensor {name} - Agent: {(Agent ? Agent.name : "None")}";
        }
        
        /// <summary>
        /// Implicit conversion from a <see href="https://docs.unity3d.com/Manual/class-GameObject.html">GameObject</see>.
        /// </summary>
        /// <param name="o">The <see href="https://docs.unity3d.com/Manual/class-GameObject.html">GameObject</see>.</param>
        /// <returns>The sensor attached to the <see href="https://docs.unity3d.com/Manual/class-GameObject.html">GameObject</see> if there was one.</returns>
        public static implicit operator KaijuSensor([NotNull] GameObject o) => o.GetComponent<KaijuSensor>();
        
        /// <summary>
        /// Implicit conversion from a <see href="https://docs.unity3d.com/Manual/class-Transform.html">transform</see>.
        /// </summary>
        /// <param name="t">The <see href="https://docs.unity3d.com/Manual/class-Transform.html">transform</see>.</param>
        /// <returns>The sensor attached to the <see href="https://docs.unity3d.com/Manual/class-Transform.html">transform</see> if there was one.</returns>
        public static implicit operator KaijuSensor([NotNull] Transform t) => t.GetComponent<KaijuSensor>();
        
        /// <summary>
        /// Implicit conversion to a <see cref="KaijuAgent"/>.
        /// </summary>
        /// <param name="s">The sensor.</param>
        /// <returns>The <see cref="KaijuAgent"/> attached to the sensor if there was one.</returns>
        public static implicit operator KaijuAgent([NotNull] KaijuSensor s) => s.Agent;
    }
}