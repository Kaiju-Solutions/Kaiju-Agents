using System.Diagnostics.CodeAnalysis;
using KaijuSolutions.Agents.Actuators;
using KaijuSolutions.Agents.Movement;
using KaijuSolutions.Agents.Sensors;
using UnityEngine;

namespace KaijuSolutions.Agents
{
    /// <summary>
    /// Base class to inherit for easy interaction with all <see cref="KaijuAgent"/>s in the scene.
    /// Simply override the methods you need to use callbacks without needing to worry about binding.
    /// If you override either <see href="https://docs.unity3d.com/ScriptReference/MonoBehaviour.OnEnable.html">OnEnable</see> or <see href="https://docs.unity3d.com/ScriptReference/MonoBehaviour.OnDisable.html">OnDisable</see>, you must call their respective base methods for binding and cleanup.
    /// </summary>
    [DefaultExecutionOrder(int.MinValue + 4)]
    [RequireComponent(typeof(KaijuAgent))]
#if UNITY_EDITOR
    [SelectionBase]
    [Icon("Packages/com.kaijusolutions.agents/Editor/Icon.png")]
    [HelpURL("https://agents.kaijusolutions.ca/manual/getting-started.html")]
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
            
            // Bind to all agent events to overload.
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
        }
        
        /// <summary>
        /// Global callback for before a <see cref="KaijuBehaviour"/>'s position has been set.
        /// </summary>
        /// <param name="behaviour">The behaviour.</param>
        protected virtual void OnAllPreSetPosition(KaijuBehaviour behaviour) { }
        
        /// <summary>
        /// Global callback for when the <see cref="KaijuBehaviour"/>'s position has been set.
        /// </summary>
        /// <param name="behaviour">The behaviour.</param>
        protected virtual void OnAllSetPosition(KaijuBehaviour behaviour) { }
        
        /// <summary>
        /// Global callback for before the <see cref="KaijuBehaviour"/>'s orientation has been set.
        /// </summary>
        /// <param name="behaviour">The behaviour.</param>
        protected virtual void OnAllPreSetOrientation(KaijuBehaviour behaviour) { }
        
        /// <summary>
        /// Global callback for when the <see cref="KaijuBehaviour"/>'s orientation has been set.
        /// </summary>
        /// <param name="behaviour">The behaviour.</param>
        protected virtual void OnAllSetOrientation(KaijuBehaviour behaviour) { }
        
        /// <summary>
        /// Global callback for before the <see cref="KaijuBehaviour"/>'s scale has been set.
        /// </summary>
        /// <param name="behaviour">The behaviour.</param>
        protected virtual void OnAllPreSetScale(KaijuBehaviour behaviour) { }
        
        /// <summary>
        /// Global callback for when the <see cref="KaijuBehaviour"/>'s scale has been set.
        /// </summary>
        /// <param name="behaviour">The behaviour.</param>
        protected virtual void OnAllSetScale(KaijuBehaviour behaviour) { }
        
        /// <summary>
        /// Global movement speed changed callback for an <see cref="KaijuAgent"/>
        /// </summary>
        /// <param name="agent">The agent.</param>
        protected virtual void OnAgentMoveSpeed(KaijuAgent agent) { }
        
        /// <summary>
        /// Global movement acceleration changed callback for an <see cref="KaijuAgent"/>
        /// </summary>
        /// <param name="agent">The agent.</param>
        protected virtual void OnAgentMoveAcceleration(KaijuAgent agent) { }
        
        /// <summary>
        /// Global look speed changed callback for an <see cref="KaijuAgent"/>
        /// </summary>
        /// <param name="agent">The agent.</param>
        protected virtual void OnAgentLookSpeed(KaijuAgent agent) { }
        
        /// <summary>
        /// Global autorotation changed callback for an <see cref="KaijuAgent"/>
        /// </summary>
        /// <param name="agent">The agent.</param>
        protected virtual void OnAgentAutoRotate(KaijuAgent agent) { }
        
        /// <summary>
        /// Global callback for when the look target has been set for an <see cref="KaijuAgent"/>.
        /// </summary>
        /// <param name="agent">The agent.</param>
        protected virtual void OnAgentLookTarget(KaijuAgent agent) { }
        
        /// <summary>
        /// Global callback for when an <see cref="KaijuAgent"/> has moved.
        /// </summary>
        /// <param name="agent">The agent.</param>
        protected virtual void OnAgentMove(KaijuAgent agent) { }
        
        /// <summary>
        /// Global callback for when the a <see cref="KaijuAgent"/> has finishing becoming enabled.
        /// </summary>
        /// <param name="agent">The agent.</param>
        protected virtual void OnAgentEnabled(KaijuAgent agent) { }
        
        /// <summary>
        /// Global callback for when a <see cref="KaijuAgent"/> has finishing becoming disabled.
        /// </summary>
        /// <param name="agent">The agent.</param>
        protected virtual void OnAgentDisabled(KaijuAgent agent) { }
        
        /// <summary>
        /// Global callback for when a <see cref="KaijuAgent"/> has finishing becoming destroyed.
        /// </summary>
        /// <param name="agent">The agent.</param>
        protected virtual void OnAgentDestroyed(KaijuAgent agent) { }
        
        /// <summary>
        /// Global callback for when all automatic sensors have finished being executed for a <see cref="KaijuAgent"/>.
        /// </summary>
        /// <param name="agent">The agent.</param>
        protected virtual void OnAgentAutomaticSense(KaijuAgent agent) { }
        
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
            
            // Bind to all agent events to overload.
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
        }
        
        /// <summary>
        /// Get a description of the object.
        /// </summary>
        /// <returns>A description of the object.</returns>
        public override string ToString()
        {
            return $"Kaiju Agent Global Controller {name}";
        }
        
        /// <summary>
        /// Implicit conversion from a <see href="https://docs.unity3d.com/Manual/class-GameObject.html">GameObject</see>.
        /// </summary>
        /// <param name="o">The <see href="https://docs.unity3d.com/Manual/class-GameObject.html">GameObject</see>.</param>
        /// <returns>The controller attached to the <see href="https://docs.unity3d.com/Manual/class-GameObject.html">GameObject</see> if there was one.</returns>
        public static implicit operator KaijuGlobalController([NotNull] GameObject o) => o.GetComponent<KaijuGlobalController>();
        
        /// <summary>
        /// Implicit conversion from a <see href="https://docs.unity3d.com/Manual/class-Transform.html">transform</see>.
        /// </summary>
        /// <param name="t">The <see href="https://docs.unity3d.com/Manual/class-Transform.html">transform</see>.</param>
        /// <returns>The controller attached to the <see href="https://docs.unity3d.com/Manual/class-Transform.html">transform</see> if there was one.</returns>
        public static implicit operator KaijuGlobalController([NotNull] Transform t) => t.GetComponent<KaijuGlobalController>();
        
        /// <summary>
        /// Implicit conversion from a <see cref="KaijuAgent"/>.
        /// </summary>
        /// <param name="a">The <see cref="KaijuAgent"/>.</param>
        /// <returns>The controller attached to the <see cref="KaijuAgent"/> if there was one.</returns>
        public static implicit operator KaijuGlobalController([NotNull] KaijuAgent a) => a.GetComponent<KaijuGlobalController>();
        
        /// <summary>
        /// Implicit conversion to a <see cref="KaijuAgent"/>.
        /// </summary>
        /// <param name="c">The controller.</param>
        /// <returns>The <see cref="KaijuAgent"/> attached to the controller if there was one.</returns>
        public static implicit operator KaijuGlobalController([NotNull] KaijuController c) => c.GetComponent<KaijuAgent>();
    }
}