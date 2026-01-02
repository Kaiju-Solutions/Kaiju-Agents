using UnityEngine;

namespace KaijuSolutions.Agents.Actuators
{
    /// <summary>
    /// Base actuator class.
    /// </summary>
    [DefaultExecutionOrder(int.MinValue + 1)]
#if UNITY_EDITOR
    [Icon("Packages/com.kaijusolutions.agents/Editor/Icon.png")]
    [HelpURL("https://agents.kaijusolutions.ca/manual/getting-started.html")]
#endif
    public abstract class KaijuActuator : KaijuBehaviour
    {
        /// <summary>
        /// Callback for when this has started to execute.
        /// </summary>
        public event KaijuAction OnStarted;
        
        /// <summary>
        /// Global callback for when this has started to execute.
        /// </summary>
        public static event KaijuActuatorAction OnStartedGlobal;
        
        /// <summary>
        /// Callback for when this is continuing to execute.
        /// </summary>
        public event KaijuAction OnExecuting;
        
        /// <summary>
        /// Global callback for when this is continuing to execute.
        /// </summary>
        public static event KaijuActuatorAction OnExecutingGlobal;
        
        /// <summary>
        /// Callback for when this has successfully fully completed its action.
        /// </summary>
        public event KaijuAction OnDone;
        
        /// <summary>
        /// Global callback for when this has successfully fully completed its action.
        /// </summary>
        public static event KaijuActuatorAction OnDoneGlobal;
        
        /// <summary>
        /// Callback for when this has been interrupted during its execution, cancelling the execution.
        /// </summary>
        public event KaijuAction OnInterrupted;
        
        /// <summary>
        /// Global callback for when this has been interrupted during its execution, cancelling the execution.
        /// </summary>
        public static event KaijuActuatorAction OnInterruptedGlobal;
        
        /// <summary>
        /// Callback for when this has failed its execution.
        /// </summary>
        public event KaijuAction OnFailed;
        
        /// <summary>
        /// Global callback when this has failed its execution.
        /// </summary>
        public static event KaijuActuatorAction OnFailedGlobal;
        
        /// <summary>
        /// Callback for when this has finishing becoming enabled.
        /// </summary>
        public event KaijuAction OnEnabled;
        
        /// <summary>
        /// Global callback for when this has finishing becoming enabled.
        /// </summary>
        public static event KaijuActuatorAction OnEnabledGlobal;
        
        /// <summary>
        /// Callback for when this has finishing becoming disabled.
        /// </summary>
        public event KaijuAction OnDisabled;
        
        /// <summary>
        /// Global callback for when this has finishing becoming disabled.
        /// </summary>
        public static event KaijuActuatorAction OnDisabledGlobal;
        
        /// <summary>
        /// The agent this actuator is assigned to.
        /// </summary>
        public KaijuAgent Agent { get; private set; }
        
        /// <summary>
        /// If this actuator should run.
        /// </summary>
        private bool _shouldRun;
        
        /// <summary>
        /// If the actuator is currently running.
        /// </summary>
        private bool _isRunning;
        
        /// <summary>
        /// The last state of the actuator.
        /// </summary>
        private KaijuActuatorState _state = KaijuActuatorState.Done;
        
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
            
            _shouldRun = false;
            _isRunning = false;
            _state = KaijuActuatorState.Done;
            Cleanup();
            Agent.RegisterActuator(this);
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
                Agent.UnregisterActuator(this);
            }
            
            _shouldRun = false;
            _isRunning = false;
            _state = KaijuActuatorState.Done;
            Cleanup();
            OnDisabled?.Invoke();
            OnDisabledGlobal?.Invoke(this);
        }
        
        /// <summary>
        /// If the actuator should act in its next execution step.
        /// </summary>
        public void Begin()
        {
            _shouldRun = true;
        }
        
        /// <summary>
        /// End the execution of this actuator.
        /// </summary>
        public void End()
        {
            // If we should not be running, there is nothing to do.
            if (!_shouldRun)
            {
                // This should never happen, but to be safe, ensure this is not flagged.
                _isRunning = false;
                return;
            }
            
            // Stop running.
            _shouldRun = false;
            
            // If this was started but did not yet finish, indicate we have interrupted its execution.
            if (!_isRunning)
            {
                return;
            }
            
            _isRunning = false;
            Agent?.ActuatorInterrupted(this);
            OnInterrupted?.Invoke();
            OnInterruptedGlobal?.Invoke(this);
            _state = KaijuActuatorState.Done;
        }
        
        /// <summary>
        /// Run this actuator if it should be. There is no point in manually calling this.
        /// </summary>
        public void Handle()
        {
            // If we should not be running, there is nothing to do.
            if (!_shouldRun)
            {
                // If this was stopped externally while it was still executing, send events for why it is done.
                if (!_isRunning)
                {
                    return ;
                }
                
                _isRunning = false;
                switch (_state)
                {
                    case KaijuActuatorState.Done:
                    default:
                        Agent?.ActuatorDone(this);
                        OnDone?.Invoke();
                        OnDoneGlobal?.Invoke(this);
                        return;
                    case KaijuActuatorState.Executing:
                        Agent?.ActuatorInterrupted(this);
                        OnInterrupted?.Invoke();
                        OnInterruptedGlobal?.Invoke(this);
                        return;
                    case KaijuActuatorState.Failed:
                        Agent?.ActuatorFailed(this);
                        OnFailed?.Invoke();
                        OnFailedGlobal?.Invoke(this);
                        return;
                }
            }
            
            // If this is the first step for it, indicate so.
            if (!_isRunning)
            {
                _isRunning = true;
                Agent?.ActuatorStarted(this);
                OnStarted?.Invoke();
                OnStartedGlobal?.Invoke(this);
            }
            
            // Run the actuator.
            _state = Run();
            
            // Nothing else to do if still executing.
            if (_state == KaijuActuatorState.Executing)
            {
                Agent?.ActuatorExecuting(this);
                OnExecuting?.Invoke();
                OnExecutingGlobal?.Invoke(this);
                return;
            }
            
            // Otherwise, this has finished, so stop for the next update.
            _shouldRun = false;
            _isRunning = false;
            
            // Handle if it was done or failed.
            if (_state == KaijuActuatorState.Done)
            {
                Agent?.ActuatorDone(this);
                OnDone?.Invoke();
                OnDoneGlobal?.Invoke(this);
            }
            else
            {
                Agent?.ActuatorFailed(this);
                OnFailed?.Invoke();
                OnFailedGlobal?.Invoke(this);
            }
        }
        
        /// <summary>
        /// Run the actuator.
        /// </summary>
        /// <returns>The state of the actuator's progress.</returns>
        protected abstract KaijuActuatorState Run();
        
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
    }
    
    /// <summary>
    /// The result of running an actuator.
    /// </summary>
    public enum KaijuActuatorState
    {
        /// <summary>
        /// If an actuator is still executing. 
        /// </summary>
        Executing = 0,
        
        /// <summary>
        /// If an actuator has finished running.
        /// </summary>
        Done = 1,
        
        /// <summary>
        /// If an actuator has failed.
        /// </summary>
        Failed = 2
    }
}