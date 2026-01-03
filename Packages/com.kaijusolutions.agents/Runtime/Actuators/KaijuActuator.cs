using System.Diagnostics.CodeAnalysis;
using UnityEngine;

namespace KaijuSolutions.Agents.Actuators
{
    /// <summary>
    /// Base <see cref="KaijuActuator"/> class.
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
        /// The <see cref="KaijuAgent"/> this <see cref="KaijuActuator"/> is assigned to.
        /// </summary>
        public KaijuAgent Agent { get; private set; }
        
        /// <summary>
        /// If this <see cref="KaijuActuator"/> should run.
        /// </summary>
        private bool _shouldRun;
        
        /// <summary>
        /// If the <see cref="KaijuActuator"/> is currently running.
        /// </summary>
        public bool IsRunning { get; private set; }
        
        /// <summary>
        /// The last state of the <see cref="KaijuActuator"/>.
        /// </summary>
        public KaijuActuatorState State { get; private set; } = KaijuActuatorState.Done;
        
        /// <summary>
        /// This function is called when the object becomes enabled and active.
        /// </summary>
        protected virtual void OnEnable()
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
            IsRunning = false;
            State = KaijuActuatorState.Done;
            Cleanup();
            Agent.RegisterActuator(this);
            OnEnabled?.Invoke();
            OnEnabledGlobal?.Invoke(this);
        }
        
        /// <summary>
        /// This function is called when the behaviour becomes disabled.
        /// </summary>
        protected virtual void OnDisable()
        {
            if (Agent != null)
            {
                Agent.UnregisterActuator(this);
            }
            
            _shouldRun = false;
            IsRunning = false;
            State = KaijuActuatorState.Done;
            Cleanup();
            OnDisabled?.Invoke();
            OnDisabledGlobal?.Invoke(this);
        }
        
        /// <summary>
        /// If the <see cref="KaijuActuator"/> should act in its next execution step.
        /// </summary>
        public void Begin()
        {
            _shouldRun = true;
        }
        
        /// <summary>
        /// End the execution of this <see cref="KaijuActuator"/>.
        /// </summary>
        public void End()
        {
            // If we should not be running, there is nothing to do.
            if (!_shouldRun)
            {
                // This should never happen, but to be safe, ensure this is not flagged.
                IsRunning = false;
                return;
            }
            
            // Stop running.
            _shouldRun = false;
            
            // If this was started but did not yet finish, indicate we have interrupted its execution.
            if (!IsRunning)
            {
                return;
            }
            
            IsRunning = false;
            Agent?.ActuatorInterrupted(this);
            OnInterrupted?.Invoke();
            OnInterruptedGlobal?.Invoke(this);
            State = KaijuActuatorState.Done;
        }
        
        /// <summary>
        /// Run this <see cref="KaijuActuator"/> if it should be. There is no point in manually calling this.
        /// </summary>
        public void Handle()
        {
            // If we should not be running, there is nothing to do.
            if (!_shouldRun)
            {
                // If this was stopped externally while it was still executing, send events for why it is done.
                if (!IsRunning)
                {
                    return ;
                }
                
                IsRunning = false;
                switch (State)
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
            if (!IsRunning)
            {
                IsRunning = true;
                Agent?.ActuatorStarted(this);
                OnStarted?.Invoke();
                OnStartedGlobal?.Invoke(this);
            }
            
            // Run this.
            State = Run();
            
            // Nothing else to do if still executing.
            if (State == KaijuActuatorState.Executing)
            {
                Agent?.ActuatorExecuting(this);
                OnExecuting?.Invoke();
                OnExecutingGlobal?.Invoke(this);
                return;
            }
            
            // Otherwise, this has finished, so stop for the next update.
            _shouldRun = false;
            IsRunning = false;
            
            // Handle if it was done or failed.
            if (State == KaijuActuatorState.Done)
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
        /// Run the <see cref="KaijuActuator"/>.
        /// </summary>
        /// <returns>The state of the <see cref="KaijuActuator"/>'s progress.</returns>
        protected abstract KaijuActuatorState Run();
        
        /// <summary>
        /// Perform any needed resetting of the <see cref="KaijuActuator"/>.
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
            return $"Kaiju Actuator {name} - Agent: {(Agent ? Agent.name : "None")}";
        }
        
        /// <summary>
        /// Implicit conversion from a <see href="https://docs.unity3d.com/Manual/class-GameObject.html">GameObject</see>.
        /// </summary>
        /// <param name="o">The <see href="https://docs.unity3d.com/Manual/class-GameObject.html">GameObject</see>.</param>
        /// <returns>The <see cref="KaijuActuator"/> attached to the <see href="https://docs.unity3d.com/Manual/class-GameObject.html">GameObject</see> if there was one.</returns>
        public static implicit operator KaijuActuator([NotNull] GameObject o) => o.GetComponent<KaijuActuator>();
        
        /// <summary>
        /// Implicit conversion from a <see href="https://docs.unity3d.com/Manual/class-transform.html">transform</see>.
        /// </summary>
        /// <param name="t">The <see href="https://docs.unity3d.com/Manual/class-transform.html">transform</see>.</param>
        /// <returns>The <see cref="KaijuActuator"/> attached to the <see href="https://docs.unity3d.com/Manual/class-transform.html">transform</see> if there was one.</returns>
        public static implicit operator KaijuActuator([NotNull] Transform t) => t.GetComponent<KaijuActuator>();
        
        /// <summary>
        /// Implicit conversion to a <see cref="KaijuAgent"/>.
        /// </summary>
        /// <param name="a">The <see cref="KaijuActuator"/>.</param>
        /// <returns>The <see cref="KaijuAgent"/> attached to the <see cref="KaijuActuator"/> if there was one.</returns>
        public static implicit operator KaijuAgent([NotNull] KaijuActuator a) => a.Agent;
    }
    
    /// <summary>
    /// The result of running an <see cref="KaijuActuator"/>.
    /// </summary>
    public enum KaijuActuatorState
    {
        /// <summary>
        /// If an <see cref="KaijuActuator"/> is still executing. 
        /// </summary>
        Executing = 0,
        
        /// <summary>
        /// If an <see cref="KaijuActuator"/> has finished running.
        /// </summary>
        Done = 1,
        
        /// <summary>
        /// If an <see cref="KaijuActuator"/> has failed.
        /// </summary>
        Failed = 2
    }
}