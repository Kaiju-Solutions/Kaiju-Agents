using System.Diagnostics.CodeAnalysis;
using KaijuSolutions.Agents.Actuators;
using KaijuSolutions.Agents.Movement;
using KaijuSolutions.Agents.Sensors;
using UnityEngine;

namespace KaijuSolutions.Agents
{
    /// <summary>
    /// Base class to inherit for easy interaction with all <see cref="KaijuSolutions.Agents.KaijuAgent"/>s in the scene.
    /// Simply override the methods you need to use callbacks without needing to worry about binding.
    /// If you override either <see href="https://docs.unity3d.com/ScriptReference/MonoBehaviour.OnEnable.html">OnEnable</see> or <see href="https://docs.unity3d.com/ScriptReference/MonoBehaviour.OnDisable.html">OnDisable</see>, you must call their respective base methods for binding and cleanup.
    /// </summary>
    [DefaultExecutionOrder(int.MinValue + 4)]
#if UNITY_EDITOR
    [SelectionBase]
    [Icon("Packages/ca.kaijusolutions.agents/Editor/Icon.png")]
    [HelpURL("https://agents.kaijusolutions.ca/manual/controller.html")]
#endif
    public abstract class KaijuGlobalController : KaijuBehaviour
    {
        /// <summary>
        /// This function is called when the object becomes enabled and active.
        /// </summary>
        protected virtual void OnEnable()
        {
            // Bind all base methods to overload.
            OnPreSetPositionGlobal += OnAllPreSetPosition;
            OnSetPositionGlobal += OnAllSetPosition;
            OnPreSetOrientationGlobal += OnAllPreSetOrientation;
            OnSetOrientationGlobal += OnAllSetOrientation;
            OnPreSetScaleGlobal += OnAllPreSetScale;
            OnSetScaleGlobal += OnAllSetScale;
            
            // Bind to all <see cref="KaijuSolutions.Agents.KaijuAgent"/> events to overload.
            KaijuAgent.OnMoveSpeedGlobal += OnAgentMoveSpeed;
            KaijuAgent.OnMoveAccelerationGlobal += OnAgentMoveAcceleration;
            KaijuAgent.OnLookSpeedGlobal += OnAgentLookSpeed;
            KaijuAgent.OnAutoRotateGlobal += OnAgentAutoRotate;
            KaijuAgent.OnLookTargetGlobal += OnAgentLookTarget;
            KaijuAgent.OnMoveGlobal += OnAgentMove;
            KaijuAgent.OnEnabledGlobal += OnAgentEnabled;
            KaijuAgent.OnDisabledGlobal += OnAgentDisabled;
            KaijuAgent.OnDestroyedGlobal += OnAgentDestroyed;
            KaijuAgent.OnAutomaticSenseGlobal += OnAgentAutomaticSense;
            
            // Bind all movement callbacks to overload.
            KaijuMovement.OnStartedGlobal += OnMovementStarted;
            KaijuMovement.OnStoppedGlobal += OnMovementStopped;
            KaijuMovement.OnPerformedGlobal += OnMovementPerformed;
            
            // Bind all <see cref="KaijuSolutions.Agents.Sensors.KaijuSensor"/> events to overload.
            KaijuSensor.OnSenseGlobal += OnSensorSense;
            KaijuSensor.OnEnabledGlobal += OnSensorEnabled;
            KaijuSensor.OnDisabledGlobal += OnSensorDisabled;
            
            // Bind all <see cref="KaijuSolutions.Agents.Actuators.KaijuActuator"/> events to overload.
            KaijuActuator.OnStartedGlobal += OnActuatorStarted;
            KaijuActuator.OnExecutingGlobal += OnActuatorExecuting;
            KaijuActuator.OnDoneGlobal += OnActuatorDone;
            KaijuActuator.OnInterruptedGlobal += OnActuatorInterrupted;
            KaijuActuator.OnFailedGlobal += OnActuatorFailed;
            KaijuActuator.OnEnabledGlobal += OnActuatorEnabled;
            KaijuActuator.OnDisabledGlobal += OnActuatorDisabled;
        }
        
        /// <summary>
        /// This function is called when the behaviour becomes disabled.
        /// </summary>
        protected virtual void OnDisable()
        {
            // Unbind all base methods to overload.
            OnPreSetPositionGlobal -= OnAllPreSetPosition;
            OnSetPositionGlobal -= OnAllSetPosition;
            OnPreSetOrientationGlobal -= OnAllPreSetOrientation;
            OnSetOrientationGlobal -= OnAllSetOrientation;
            OnPreSetScaleGlobal -= OnAllPreSetScale;
            OnSetScaleGlobal -= OnAllSetScale;
            
            // Unbind to all <see cref="KaijuSolutions.Agents.KaijuAgent"/> events to overload.
            KaijuAgent.OnMoveSpeedGlobal -= OnAgentMoveSpeed;
            KaijuAgent.OnMoveAccelerationGlobal -= OnAgentMoveAcceleration;
            KaijuAgent.OnLookSpeedGlobal -= OnAgentLookSpeed;
            KaijuAgent.OnAutoRotateGlobal -= OnAgentAutoRotate;
            KaijuAgent.OnLookTargetGlobal -= OnAgentLookTarget;
            KaijuAgent.OnMoveGlobal -= OnAgentMove;
            KaijuAgent.OnEnabledGlobal -= OnAgentEnabled;
            KaijuAgent.OnDisabledGlobal -= OnAgentDisabled;
            KaijuAgent.OnDestroyedGlobal -= OnAgentDestroyed;
            KaijuAgent.OnAutomaticSenseGlobal -= OnAgentAutomaticSense;
            
            // Unbind all movement callbacks to overload.
            KaijuMovement.OnStartedGlobal -= OnMovementStarted;
            KaijuMovement.OnStoppedGlobal -= OnMovementStopped;
            KaijuMovement.OnPerformedGlobal -= OnMovementPerformed;
            
            // Unbind all <see cref="KaijuSolutions.Agents.Sensors.KaijuSensor"/> events to overload.
            KaijuSensor.OnSenseGlobal -= OnSensorSense;
            KaijuSensor.OnEnabledGlobal -= OnSensorEnabled;
            KaijuSensor.OnDisabledGlobal -= OnSensorDisabled;
            
            // Unbind all <see cref="KaijuSolutions.Agents.Actuators.KaijuActuator"/> events to overload.
            KaijuActuator.OnStartedGlobal -= OnActuatorStarted;
            KaijuActuator.OnExecutingGlobal -= OnActuatorExecuting;
            KaijuActuator.OnDoneGlobal -= OnActuatorDone;
            KaijuActuator.OnInterruptedGlobal -= OnActuatorInterrupted;
            KaijuActuator.OnFailedGlobal -= OnActuatorFailed;
            KaijuActuator.OnEnabledGlobal -= OnActuatorEnabled;
            KaijuActuator.OnDisabledGlobal -= OnActuatorDisabled;
        }
        
        /// <summary>
        /// Global callback for before a <see cref="KaijuSolutions.Agents.KaijuBehaviour"/>'s position has been set.
        /// </summary>
        /// <param name="behaviour">The <see cref="KaijuSolutions.Agents.KaijuBehaviour"/>.</param>
        protected virtual void OnAllPreSetPosition(KaijuBehaviour behaviour) { }
        
        /// <summary>
        /// Global callback for when the <see cref="KaijuSolutions.Agents.KaijuBehaviour"/>'s position has been set.
        /// </summary>
        /// <param name="behaviour">The <see cref="KaijuSolutions.Agents.KaijuBehaviour"/>.</param>
        protected virtual void OnAllSetPosition(KaijuBehaviour behaviour) { }
        
        /// <summary>
        /// Global callback for before the <see cref="KaijuSolutions.Agents.KaijuBehaviour"/>'s orientation has been set.
        /// </summary>
        /// <param name="behaviour">The <see cref="KaijuSolutions.Agents.KaijuBehaviour"/>.</param>
        protected virtual void OnAllPreSetOrientation(KaijuBehaviour behaviour) { }
        
        /// <summary>
        /// Global callback for when the <see cref="KaijuSolutions.Agents.KaijuBehaviour"/>'s orientation has been set.
        /// </summary>
        /// <param name="behaviour">The <see cref="KaijuSolutions.Agents.KaijuBehaviour"/>.</param>
        protected virtual void OnAllSetOrientation(KaijuBehaviour behaviour) { }
        
        /// <summary>
        /// Global callback for before the <see cref="KaijuSolutions.Agents.KaijuBehaviour"/>'s scale has been set.
        /// </summary>
        /// <param name="behaviour">The <see cref="KaijuSolutions.Agents.KaijuBehaviour"/>.</param>
        protected virtual void OnAllPreSetScale(KaijuBehaviour behaviour) { }
        
        /// <summary>
        /// Global callback for when the <see cref="KaijuSolutions.Agents.KaijuBehaviour"/>'s scale has been set.
        /// </summary>
        /// <param name="behaviour">The <see cref="KaijuSolutions.Agents.KaijuBehaviour"/>.</param>
        protected virtual void OnAllSetScale(KaijuBehaviour behaviour) { }
        
        /// <summary>
        /// Global movement speed changed callback for an <see cref="KaijuSolutions.Agents.KaijuAgent"/>
        /// </summary>
        /// <param name="agent">The <see cref="KaijuSolutions.Agents.KaijuAgent"/>.</param>
        protected virtual void OnAgentMoveSpeed(KaijuAgent agent) { }
        
        /// <summary>
        /// Global movement acceleration changed callback for an <see cref="KaijuSolutions.Agents.KaijuAgent"/>
        /// </summary>
        /// <param name="agent">The <see cref="KaijuSolutions.Agents.KaijuAgent"/>.</param>
        protected virtual void OnAgentMoveAcceleration(KaijuAgent agent) { }
        
        /// <summary>
        /// Global look speed changed callback for an <see cref="KaijuSolutions.Agents.KaijuAgent"/>
        /// </summary>
        /// <param name="agent">The <see cref="KaijuSolutions.Agents.KaijuAgent"/>.</param>
        protected virtual void OnAgentLookSpeed(KaijuAgent agent) { }
        
        /// <summary>
        /// Global autorotation changed callback for an <see cref="KaijuSolutions.Agents.KaijuAgent"/>
        /// </summary>
        /// <param name="agent">The <see cref="KaijuSolutions.Agents.KaijuAgent"/>.</param>
        protected virtual void OnAgentAutoRotate(KaijuAgent agent) { }
        
        /// <summary>
        /// Global callback for when the look target has been set for an <see cref="KaijuSolutions.Agents.KaijuAgent"/>.
        /// </summary>
        /// <param name="agent">The <see cref="KaijuSolutions.Agents.KaijuAgent"/>.</param>
        protected virtual void OnAgentLookTarget(KaijuAgent agent) { }
        
        /// <summary>
        /// Global callback for when an <see cref="KaijuSolutions.Agents.KaijuAgent"/> has moved.
        /// </summary>
        /// <param name="agent">The <see cref="KaijuSolutions.Agents.KaijuAgent"/>.</param>
        protected virtual void OnAgentMove(KaijuAgent agent) { }
        
        /// <summary>
        /// Global callback for when the a <see cref="KaijuSolutions.Agents.KaijuAgent"/> has finishing becoming enabled.
        /// </summary>
        /// <param name="agent">The <see cref="KaijuSolutions.Agents.KaijuAgent"/>.</param>
        protected virtual void OnAgentEnabled(KaijuAgent agent) { }
        
        /// <summary>
        /// Global callback for when a <see cref="KaijuSolutions.Agents.KaijuAgent"/> has finishing becoming disabled.
        /// </summary>
        /// <param name="agent">The <see cref="KaijuSolutions.Agents.KaijuAgent"/>.</param>
        protected virtual void OnAgentDisabled(KaijuAgent agent) { }
        
        /// <summary>
        /// Global callback for when a <see cref="KaijuSolutions.Agents.KaijuAgent"/> has finishing becoming destroyed.
        /// </summary>
        /// <param name="agent">The <see cref="KaijuSolutions.Agents.KaijuAgent"/>.</param>
        protected virtual void OnAgentDestroyed(KaijuAgent agent) { }
        
        /// <summary>
        /// Global callback for when all automatic <see cref="KaijuSolutions.Agents.Sensors.KaijuSensor"/>s have finished being executed for a <see cref="KaijuSolutions.Agents.KaijuAgent"/>.
        /// </summary>
        /// <param name="agent">The <see cref="KaijuSolutions.Agents.KaijuAgent"/>.</param>
        protected virtual void OnAgentAutomaticSense(KaijuAgent agent) { }
        
        /// <summary>
        /// Global callback for a <see cref="KaijuSolutions.Agents.Movement.KaijuMovement"/> starting.
        /// </summary>
        /// <param name="movement">The <see cref="KaijuSolutions.Agents.Movement.KaijuMovement"/>.</param>
        protected virtual void OnMovementStarted(KaijuMovement movement) { }
        
        /// <summary>
        /// Global callback for a <see cref="KaijuSolutions.Agents.Movement.KaijuMovement"/> stopping.
        /// </summary>
        /// <param name="movement">The <see cref="KaijuSolutions.Agents.Movement.KaijuMovement"/>.</param>
        protected virtual void OnMovementStopped(KaijuMovement movement) { }
        
        /// <summary>
        /// Global callback for a <see cref="KaijuSolutions.Agents.Movement.KaijuMovement"/> being performed.
        /// </summary>
        /// <param name="movement">The <see cref="KaijuSolutions.Agents.Movement.KaijuMovement"/>.</param>
        protected virtual void OnMovementPerformed(KaijuMovement movement) { }
        
        /// <summary>
        /// Global callback for when a <see cref="KaijuSolutions.Agents.Sensors.KaijuSensor"/> has been run.
        /// </summary>
        /// <param name="sensor">The <see cref="KaijuSolutions.Agents.Sensors.KaijuSensor"/>.</param>
        protected virtual void OnSensorSense(KaijuSensor sensor) { }
        
        /// <summary>
        /// Global callback for when a <see cref="KaijuSolutions.Agents.Sensors.KaijuSensor"/> has been enabled.
        /// </summary>
        /// <param name="sensor">The <see cref="KaijuSolutions.Agents.Sensors.KaijuSensor"/>.</param>
        protected virtual void OnSensorEnabled(KaijuSensor sensor) { }
        
        /// <summary>
        /// Global callback for when a <see cref="KaijuSolutions.Agents.Sensors.KaijuSensor"/> has been disabled.
        /// </summary>
        /// <param name="sensor">The <see cref="KaijuSolutions.Agents.Sensors.KaijuSensor"/>.</param>
        protected virtual void OnSensorDisabled(KaijuSensor sensor) { }
        
        /// <summary>
        /// Global callback for when a <see cref="KaijuSolutions.Agents.Actuators.KaijuActuator"/> has started to execute.
        /// </summary>
        /// <param name="actuator">The <see cref="KaijuSolutions.Agents.Actuators.KaijuActuator"/>.</param>
        protected virtual void OnActuatorStarted(KaijuActuator actuator) { }
        
        /// <summary>
        /// Global callback for when a <see cref="KaijuSolutions.Agents.Actuators.KaijuActuator"/> is continuing to execute.
        /// </summary>
        /// <param name="actuator">The <see cref="KaijuSolutions.Agents.Actuators.KaijuActuator"/>.</param>
        protected virtual void OnActuatorExecuting(KaijuActuator actuator) { }
        
        /// <summary>
        /// Global callback for when a <see cref="KaijuSolutions.Agents.Actuators.KaijuActuator"/> has successfully fully completed its action.
        /// </summary>
        /// <param name="actuator">The <see cref="KaijuSolutions.Agents.Actuators.KaijuActuator"/>.</param>
        protected virtual void OnActuatorDone(KaijuActuator actuator) { }
        
        /// <summary>
        /// Global callback for when a <see cref="KaijuSolutions.Agents.Actuators.KaijuActuator"/> has been interrupted during its execution, cancelling the execution.
        /// </summary>
        /// <param name="actuator">The <see cref="KaijuSolutions.Agents.Actuators.KaijuActuator"/>.</param>
        protected virtual void OnActuatorInterrupted(KaijuActuator actuator) { }
        
        /// <summary>
        /// Global callback for when a <see cref="KaijuSolutions.Agents.Actuators.KaijuActuator"/> has failed its execution.
        /// </summary>
        /// <param name="actuator">The <see cref="KaijuSolutions.Agents.Actuators.KaijuActuator"/>.</param>
        protected virtual void OnActuatorFailed(KaijuActuator actuator) { }
        
        /// <summary>
        /// Global callback for when a <see cref="KaijuSolutions.Agents.Actuators.KaijuActuator"/> has finishing becoming enabled.
        /// </summary>
        /// <param name="actuator">The <see cref="KaijuSolutions.Agents.Actuators.KaijuActuator"/>.</param>
        protected virtual void OnActuatorEnabled(KaijuActuator actuator) { }
        
        /// <summary>
        /// Global callback for when a <see cref="KaijuSolutions.Agents.Actuators.KaijuActuator"/> has finishing becoming disabled.
        /// </summary>
        /// <param name="actuator">The <see cref="KaijuSolutions.Agents.Actuators.KaijuActuator"/>.</param>
        protected virtual void OnActuatorDisabled(KaijuActuator actuator) { }
        
        /// <summary>
        /// Get a description of the object.
        /// </summary>
        /// <returns>A description of the object.</returns>
        public override string ToString()
        {
            return $"{name} - Kaiju Agent Global Controller";
        }
        
        /// <summary>
        /// Implicit conversion from a <see href="https://docs.unity3d.com/Manual/class-GameObject.html">GameObject</see>.
        /// </summary>
        /// <param name="o">The <see href="https://docs.unity3d.com/Manual/class-GameObject.html">GameObject</see>.</param>
        /// <returns>The global controller attached to the <see href="https://docs.unity3d.com/Manual/class-GameObject.html">GameObject</see> if there was one.</returns>
        public static implicit operator KaijuGlobalController([NotNull] GameObject o) => o.GetComponent<KaijuGlobalController>();
        
        /// <summary>
        /// Implicit conversion from a <see href="https://docs.unity3d.com/Manual/class-transform.html">transform</see>.
        /// </summary>
        /// <param name="t">The <see href="https://docs.unity3d.com/Manual/class-transform.html">transform</see>.</param>
        /// <returns>The global controller attached to the <see href="https://docs.unity3d.com/Manual/class-transform.html">transform</see> if there was one.</returns>
        public static implicit operator KaijuGlobalController([NotNull] Transform t) => t.GetComponent<KaijuGlobalController>();
        
        /// <summary>
        /// Implicit conversion from a <see cref="KaijuSolutions.Agents.KaijuAgent"/>.
        /// </summary>
        /// <param name="a">The <see cref="KaijuSolutions.Agents.KaijuAgent"/>.</param>
        /// <returns>The global controller attached to the <see cref="KaijuSolutions.Agents.KaijuAgent"/> if there was one.</returns>
        public static implicit operator KaijuGlobalController([NotNull] KaijuAgent a) => a.GetComponent<KaijuGlobalController>();
        
        /// <summary>
        /// Implicit conversion to a <see cref="KaijuSolutions.Agents.KaijuAgent"/>.
        /// </summary>
        /// <param name="c">The <see cref="KaijuSolutions.Agents.KaijuGlobalController"/>.</param>
        /// <returns>The <see cref="KaijuSolutions.Agents.KaijuAgent"/> attached to The <see cref="KaijuSolutions.Agents.KaijuGlobalController"/> if there was one.</returns>
        public static implicit operator KaijuAgent([NotNull] KaijuGlobalController c) => c.GetComponent<KaijuAgent>();
    }
}