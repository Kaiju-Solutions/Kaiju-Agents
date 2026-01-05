using System.Diagnostics.CodeAnalysis;
using KaijuSolutions.Agents.Actuators;
using KaijuSolutions.Agents.Movement;
using KaijuSolutions.Agents.Sensors;
using UnityEngine;

namespace KaijuSolutions.Agents
{
    /// <summary>
    /// Base class to inherit for easy interaction with a <see cref="KaijuAgent"/>.
    /// Simply override the methods you need to use callbacks without needing to worry about binding.
    /// If you override either <see href="https://docs.unity3d.com/ScriptReference/MonoBehaviour.OnEnable.html">OnEnable</see> or <see href="https://docs.unity3d.com/ScriptReference/MonoBehaviour.OnDisable.html">OnDisable</see>, you must call their respective base methods for binding and cleanup.
    /// </summary>
    [DefaultExecutionOrder(int.MinValue + 5)]
    [RequireComponent(typeof(KaijuAgent))]
#if UNITY_EDITOR
    [SelectionBase]
    [Icon("Packages/com.kaijusolutions.agents/Editor/Icon.png")]
    [HelpURL("https://agents.kaijusolutions.ca")]
#endif
    public abstract class KaijuController : KaijuBehaviour
    {
        /// <summary>
        /// The <see cref="KaijuAgent"/> this is listening to.
        /// </summary>
        public KaijuAgent Agent => agent;
        
        /// <summary>
        /// The <see cref="KaijuAgent"/> this is listening to.
        /// </summary>
#if UNITY_EDITOR
        [HideInInspector]
        [Tooltip("The agent this is listening to.")]
#endif
        [SerializeField]
        private KaijuAgent agent;
        
        /// <summary>
        /// Editor-only function that Unity calls when the script is loaded or a value changes in the Inspector.
        /// </summary>
        protected virtual void OnValidate()
        {
            if (agent == null || agent.transform != transform)
            {
                agent = GetComponent<KaijuAgent>();
            }
        }
        
        /// <summary>
        /// This function is called when the object becomes enabled and active.
        /// </summary>
        protected virtual void OnEnable()
        {
            if (agent == null)
            {
                agent = GetComponent<KaijuAgent>();
                if (agent == null)
                {
                    Debug.LogError("Kaiju Agent Controller - No agent on this GameObject.", this);
                    return;
                }
            }
            
            // Bind all base methods to overload. Given this is the same object, bind both this and the <see cref="KaijuAgent"/>.
            OnPreSetPosition += OnAgentPreSetPosition;
            OnSetPosition += OnAgentSetPosition;
            OnPreSetOrientation += OnAgentPreSetOrientation;
            OnSetOrientation += OnAgentSetOrientation;
            OnPreSetScale += OnAgentPreSetScale;
            OnSetScale += OnAgentSetScale;
            agent.OnPreSetPosition += OnAgentPreSetPosition;
            agent.OnSetPosition += OnAgentSetPosition;
            agent.OnPreSetOrientation += OnAgentPreSetOrientation;
            agent.OnSetOrientation += OnAgentSetOrientation;
            agent.OnPreSetScale += OnAgentPreSetScale;
            agent.OnSetScale += OnAgentSetScale;
            
            // Bind to all <see cref="KaijuAgent"/> events to overload.
            agent.OnMoveSpeed += OnMoveSpeed;
            agent.OnMoveAcceleration += OnMoveAcceleration;
            agent.OnLookSpeed += OnLookSpeed;
            agent.OnAutoRotate += OnAutoRotate;
            agent.OnLookTarget += OnLookTarget;
            agent.OnMove += OnMove;
            agent.OnEnabled += OnEnabled;
            agent.OnDisabled += OnDisabled;
            agent.OnDestroyed += OnDestroyed;
            agent.OnMovementStarted += OnMovementStarted;
            agent.OnMovementStopped += OnMovementStopped;
            agent.OnMovementPerformed += OnMovementPerformed;
            agent.OnAutomaticSense += OnAutomaticSense;
            agent.OnSense += OnSense;
            agent.OnSensorEnabled += OnSensorEnabled;
            agent.OnSensorDisabled += OnSensorDisabled;
            agent.OnActuatorEnabled += OnActuatorEnabled;
            agent.OnActuatorDisabled += OnActuatorDisabled;
            agent.OnActuatorStarted += OnActuatorStarted;
            agent.OnActuatorExecuting += OnActuatorExecuting;
            agent.OnActuatorDone += OnActuatorDone;
            agent.OnActuatorInterrupted += OnActuatorInterrupted;
            agent.OnActuatorFailed += OnActuatorFailed;
            
            // Manually run the enabled call.
            OnEnabled();
        }
        
        /// <summary>
        /// This function is called when the behaviour becomes disabled.
        /// </summary>
        protected virtual void OnDisable()
        {
            // Unbind the local methods.
            OnPreSetPosition -= OnAgentPreSetPosition;
            OnSetPosition -= OnAgentSetPosition;
            OnPreSetOrientation -= OnAgentPreSetOrientation;
            OnSetOrientation -= OnAgentSetOrientation;
            OnPreSetScale -= OnAgentPreSetScale;
            OnSetScale -= OnAgentSetScale;
            
            if (agent == null)
            {
                return;
            }
            
            // Unbind all base methods to overload.
            agent.OnPreSetPosition -= OnAgentPreSetPosition;
            agent.OnSetPosition -= OnAgentSetPosition;
            agent.OnPreSetOrientation -= OnAgentPreSetOrientation;
            agent.OnSetOrientation -= OnAgentSetOrientation;
            agent.OnPreSetScale -= OnAgentPreSetScale;
            agent.OnSetScale -= OnAgentSetScale;
            
            // Bind to all <see cref="KaijuAgent"/> events to overload.
            agent.OnMoveSpeed -= OnMoveSpeed;
            agent.OnMoveAcceleration -= OnMoveAcceleration;
            agent.OnLookSpeed -= OnLookSpeed;
            agent.OnAutoRotate -= OnAutoRotate;
            agent.OnLookTarget -= OnLookTarget;
            agent.OnMove -= OnMove;
            agent.OnEnabled -= OnEnabled;
            agent.OnDisabled -= OnDisabled;
            agent.OnDestroyed -= OnDestroyed;
            agent.OnMovementStarted -= OnMovementStarted;
            agent.OnMovementStopped -= OnMovementStopped;
            agent.OnMovementPerformed -= OnMovementPerformed;
            agent.OnAutomaticSense -= OnAutomaticSense;
            agent.OnSense -= OnSense;
            agent.OnSensorEnabled -= OnSensorEnabled;
            agent.OnSensorDisabled -= OnSensorDisabled;
            agent.OnActuatorEnabled -= OnActuatorEnabled;
            agent.OnActuatorDisabled -= OnActuatorDisabled;
            agent.OnActuatorStarted -= OnActuatorStarted;
            agent.OnActuatorExecuting -= OnActuatorExecuting;
            agent.OnActuatorDone -= OnActuatorDone;
            agent.OnActuatorInterrupted -= OnActuatorInterrupted;
            agent.OnActuatorFailed -= OnActuatorFailed;
        }
        
        /// <summary>
        /// Callback for before the <see cref="Agent"/>'s position has been set.
        /// </summary>
        protected virtual void OnAgentPreSetPosition() { }
        
        /// <summary>
        /// Callback for when the <see cref="Agent"/>'s position has been set.
        /// </summary>
        protected virtual void OnAgentSetPosition() { }
        
        /// <summary>
        /// Callback for before the <see cref="Agent"/>'s orientation has been set.
        /// </summary>
        protected virtual void OnAgentPreSetOrientation() { }
        
        /// <summary>
        /// Callback for when the <see cref="Agent"/>'s orientation has been set.
        /// </summary>
        protected virtual void OnAgentSetOrientation() { }
        
        /// <summary>
        /// Callback for before the <see cref="Agent"/>'s scale has been set.
        /// </summary>
        protected virtual void OnAgentPreSetScale() { }
        
        /// <summary>
        /// Callback for when the <see cref="Agent"/>'s scale has been set.
        /// </summary>
        protected virtual void OnAgentSetScale() { }
        
        /// <summary>
        /// Movement speed changed callback for the <see cref="Agent"/>.
        /// </summary>
        protected virtual void OnMoveSpeed() { }
        
        /// <summary>
        /// Movement acceleration changed callback for the <see cref="Agent"/>.
        /// </summary>
        protected virtual void OnMoveAcceleration() { }
        
        /// <summary>
        /// Look speed changed callback for the <see cref="Agent"/>.
        /// </summary>
        protected virtual void OnLookSpeed() { }
        
        /// <summary>
        /// Autorotation changed callback for the <see cref="Agent"/>.
        /// </summary>
        protected virtual void OnAutoRotate() { }
        
        /// <summary>
        /// Callback for when the look target has been set for the <see cref="Agent"/>.
        /// </summary>
        protected virtual void OnLookTarget() { }
        
        /// <summary>
        /// Callback for when the <see cref="Agent"/> has moved.
        /// </summary>
        protected virtual void OnMove() { }
        
        /// <summary>
        /// Callback for when the <see cref="Agent"/> has finishing becoming enabled.
        /// </summary>
        protected virtual void OnEnabled() { }
        
        /// <summary>
        /// Callback for when the <see cref="Agent"/> has finishing becoming disabled.
        /// </summary>
        protected virtual void OnDisabled() { }
        
        /// <summary>
        /// Callback for when the <see cref="Agent"/> has finishing becoming destroyed.
        /// </summary>
        protected virtual void OnDestroyed() { }
        
        /// <summary>
        /// Callback for when a <see cref="KaijuMovement"/> has started.
        /// </summary>
        /// <param name="movement">The <see cref="KaijuMovement"/>.</param>
        protected virtual void OnMovementStarted(KaijuMovement movement) { }
        
        /// <summary>
        /// Callback for when a <see cref="KaijuMovement"/> has stopped.
        /// </summary>
        /// <param name="movement">The <see cref="KaijuMovement"/>.</param>
        protected virtual void OnMovementStopped(KaijuMovement movement) { }
        
        /// <summary>
        /// Callback for when a <see cref="KaijuMovement"/> has been performed.
        /// </summary>
        /// <param name="movement">The <see cref="KaijuMovement"/>.</param>
        protected virtual void OnMovementPerformed(KaijuMovement movement) { }
        
        /// <summary>
        /// Callback for when all automatic <see cref="KaijuSensor"/>s have finished being executed.
        /// </summary>
        protected virtual void OnAutomaticSense() { }
        
        /// <summary>
        /// Callback for when a <see cref="KaijuSensor"/> has been run.
        /// </summary>
        /// <param name="sensor">The <see cref="KaijuSensor"/>.</param>
        protected virtual void OnSense(KaijuSensor sensor) { }
        
        /// <summary>
        /// Callback for when a <see cref="KaijuSensor"/> has been enabled.
        /// </summary>
        /// <param name="sensor">The <see cref="KaijuSensor"/>.</param>
        protected virtual void OnSensorEnabled(KaijuSensor sensor) { }
        
        /// <summary>
        /// Callback for when a <see cref="KaijuSensor"/> has been disabled.
        /// </summary>
        /// <param name="sensor">The <see cref="KaijuSensor"/>.</param>
        protected virtual void OnSensorDisabled(KaijuSensor sensor) { }
        
        /// <summary>
        /// Callback for when an <see cref="KaijuActuator"/> has been enabled.
        /// </summary>
        /// <param name="actuator">The <see cref="KaijuActuator"/>.</param>
        protected virtual void OnActuatorEnabled(KaijuActuator actuator) { }
        
        /// <summary>
        /// Callback for when an <see cref="KaijuActuator"/> has been disabled.
        /// </summary>
        /// <param name="actuator">The <see cref="KaijuActuator"/>.</param>
        protected virtual void OnActuatorDisabled(KaijuActuator actuator) { }
        
        /// <summary>
        /// Callback for when an <see cref="KaijuActuator"/> has started to execute.
        /// </summary>
        /// <param name="actuator">The <see cref="KaijuActuator"/>.</param>
        protected virtual void OnActuatorStarted(KaijuActuator actuator) { }
        
        /// <summary>
        /// Callback for when an <see cref="KaijuActuator"/> is continuing to execute.
        /// </summary>
        /// <param name="actuator">The <see cref="KaijuActuator"/>.</param>
        protected virtual void OnActuatorExecuting(KaijuActuator actuator) { }
        
        /// <summary>
        /// Callback for when an <see cref="KaijuActuator"/> has successfully fully completed its action.
        /// </summary>
        /// <param name="actuator">The <see cref="KaijuActuator"/>.</param>
        protected virtual void OnActuatorDone(KaijuActuator actuator) { }
        
        /// <summary>
        /// Callback for when an <see cref="KaijuActuator"/> has been interrupted during its execution, cancelling the execution.
        /// </summary>
        /// <param name="actuator">The <see cref="KaijuActuator"/>.</param>
        protected virtual void OnActuatorInterrupted(KaijuActuator actuator) { }
        
        /// <summary>
        /// Callback for when an <see cref="KaijuActuator"/> has failed its execution.
        /// </summary>
        /// <param name="actuator">The <see cref="KaijuActuator"/>.</param>
        protected virtual void OnActuatorFailed(KaijuActuator actuator) { }
        
        /// <summary>
        /// Get a description of the object.
        /// </summary>
        /// <returns>A description of the object.</returns>
        public override string ToString()
        {
            return $"Kaiju Agent Controller {name}";
        }
        
        /// <summary>
        /// Implicit conversion from a <see href="https://docs.unity3d.com/Manual/class-GameObject.html">GameObject</see>.
        /// </summary>
        /// <param name="o">The <see href="https://docs.unity3d.com/Manual/class-GameObject.html">GameObject</see>.</param>
        /// <returns>The <see cref="KaijuController"/> attached to the <see href="https://docs.unity3d.com/Manual/class-GameObject.html">GameObject</see> if there was one.</returns>
        public static implicit operator KaijuController([NotNull] GameObject o) => o.GetComponent<KaijuController>();
        
        /// <summary>
        /// Implicit conversion from a <see href="https://docs.unity3d.com/Manual/class-transform.html">transform</see>.
        /// </summary>
        /// <param name="t">The <see href="https://docs.unity3d.com/Manual/class-transform.html">transform</see>.</param>
        /// <returns>The <see cref="KaijuController"/> attached to the <see href="https://docs.unity3d.com/Manual/class-transform.html">transform</see> if there was one.</returns>
        public static implicit operator KaijuController([NotNull] Transform t) => t.GetComponent<KaijuController>();
        
        /// <summary>
        /// Implicit conversion from a <see cref="KaijuAgent"/>.
        /// </summary>
        /// <param name="a">The <see cref="KaijuAgent"/>.</param>
        /// <returns>The <see cref="KaijuController"/> attached to the <see cref="KaijuAgent"/> if there was one.</returns>
        public static implicit operator KaijuController([NotNull] KaijuAgent a) => a.GetComponent<KaijuController>();
        
        /// <summary>
        /// Implicit conversion to a <see cref="KaijuAgent"/>.
        /// </summary>
        /// <param name="c">The <see cref="KaijuController"/>.</param>
        /// <returns>The <see cref="KaijuAgent"/> attached to The <see cref="KaijuController"/> if there was one.</returns>
        public static implicit operator KaijuAgent([NotNull] KaijuController c) => c.agent;
    }
}