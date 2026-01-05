using System.Diagnostics.CodeAnalysis;
using KaijuSolutions.Agents.Extensions;
using KaijuSolutions.Agents.Movement;
using UnityEngine;

namespace KaijuSolutions.Agents.Actuators
{
    /// <summary>
    /// Base <see cref="KaijuActuator"/> for attacking other objects. This will perform a raycast in the direction of its forward.
    /// </summary>
    [DefaultExecutionOrder(int.MinValue + 1)]
#if UNITY_EDITOR
    [Icon("Packages/com.kaijusolutions.agents/Editor/Icon.png")]
    [HelpURL("https://agents.kaijusolutions.ca")]
#endif
    public abstract class KaijuAttackActuator: KaijuActuator
    {
        /// <summary>
        /// The time it takes to charge the attack in seconds before it is performed.
        /// </summary>
        public float Charge
        {
            get => charge;
            set => charge = Mathf.Max(value, 0);
        }
        
        /// <summary>
        /// The time it takes to charge the attack in seconds before it is performed.
        /// </summary>
#if UNITY_EDITOR
        [Header("Configuration")]
        [Tooltip("The time it takes to charge the attack in seconds before it is performed.")]
#endif
        [Min(0)]
        [SerializeField]
        private float charge;
        
        /// <summary>
        /// If this <see cref="KaijuAttackActuator"/> is currently cooling down.
        /// </summary>
        public bool OnCooldown => _cooling > 0;
        
        /// <summary>
        /// The time it takes to cooldown after the attack in seconds before it can be performed again.
        /// </summary>
        public float Cooldown
        {
            get => cooldown;
            set => cooldown = Mathf.Max(value, 0);
        }
        
        /// <summary>
        /// The time it takes to cooldown after the attack in seconds before it can be performed again.
        /// </summary>
#if UNITY_EDITOR
        [Tooltip("The time it takes to cooldown after the attack in seconds before it can be performed again.")]
#endif
        [Min(0)]
        [SerializeField]
        private float cooldown;
        
        /// <summary>
        /// The range of the attack.
        /// </summary>
        public float Range
        {
            get => range;
            set => range = Mathf.Max(value, float.Epsilon);
        }
        
        /// <summary>
        /// The range of the attack.
        /// </summary>
#if UNITY_EDITOR
        [Tooltip("The range of the attack.")]
#endif
        [Min(float.Epsilon)]
        [SerializeField]
        private float range = float.MaxValue;

        /// <summary>
        /// The layers to use for ray casting.
        /// </summary>
#if UNITY_EDITOR
        [Tooltip("The layers to use for ray casting.")]
#endif
        public LayerMask mask = KaijuMovementConfiguration.DefaultMask;
        
        /// <summary>
        /// How string-pulling should consider triggers.
        /// </summary>
#if UNITY_EDITOR
        [Tooltip("How string-pulling should consider triggers.")]
#endif
        public QueryTriggerInteraction triggers = QueryTriggerInteraction.UseGlobal;
        
        /// <summary>
        /// Often, a child collider may be hit. This will continue to perform the <see cref="HandleHit"/> method against all parent objects to handle this case.
        /// </summary>
#if UNITY_EDITOR
        [Tooltip("Often, a child collider may be hit. This will continue to perform the handle hit method against all parent objects to handle this case.")]
#endif
        public bool checkParents = true;
        
        /// <summary>
        /// The <see href="https://docs.unity3d.com/ScriptReference/LineRenderer.html">line renderer</see> for visualizing the attacks.
        /// </summary>
#if UNITY_EDITOR
        [Header("Visualizations")]
        [Tooltip("The line renderer for visualizing the attacks.")]
#endif
        [SerializeField]
        protected LineRenderer lineRenderer;
        
        /// <summary>
        /// How long the <see cref="lineRenderer"/> should be visible in seconds.
        /// </summary>
        public float Visible
        {
            get => visible;
            set => visible = Mathf.Max(value, float.Epsilon);
        }
        
        /// <summary>
        /// How long the <see cref="lineRenderer"/> should be visible in seconds.
        /// </summary>
#if UNITY_EDITOR
        [Tooltip("How long the line renderer should be visible in seconds.")]
#endif
        [Min(float.Epsilon)]
        [SerializeField]
        private float visible = 1;
        
        /// <summary>
        /// The time which has elapsed during charging.
        /// </summary>
        private float _charging;
        
        /// <summary>
        /// The time left for a previous cooldown.
        /// </summary>
        private float _cooling;
        
        /// <summary>
        /// The time left for the line renderer to be visible.
        /// </summary>
        private float _lineTimer;
        
        /// <summary>
        /// The last object which was hit. Note if currently charging an attack, this will still be the previously hit target.
        /// </summary>
        public Transform LastTarget { get; private set; }
        
        /// <summary>
        /// The last point which was hit. Note if currently charging an attack, this will still be the previously hit target.
        /// </summary>
        public Vector3? LastPoint { get; private set; }
        
        /// <summary>
        /// Run the <see cref="KaijuActuator"/>.
        /// </summary>
        /// <returns>The state of the <see cref="KaijuActuator"/>'s progress.</returns>
        protected override KaijuActuatorState Run()
        {
            // We cannot use this if the preconditions are not met.
            if (!PreConditions())
            {
                return KaijuActuatorState.Failed;
            }
            
            // Wait for the cooling down to happen, which happens outside of this method.
            if (_cooling > 0)
            {
                return KaijuActuatorState.Executing;
            }
            
            // Ensure the charge time has passed.
            if (_charging < charge)
            {
                _charging += Time.deltaTime;
                return KaijuActuatorState.Executing;
            }
            
            // Reset the charge time for the future.
            _charging = 0;
            
            // Set the cooling down for future uses.
            _cooling = cooldown;
            
            // If nothing is hit, report it is a failure. Otherwise, determine if it was a valid hit based on the method handling.
            Transform t = transform;
            Vector3 p = t.position;
            KaijuActuatorState state;
            if (!t.Raycast(out RaycastHit hit, range, mask, triggers))
            {
                LastPoint = p + t.forward * range;
                LastTarget = null;
                state = KaijuActuatorState.Failed;
            }
            else
            {
                LastPoint = hit.point;
                LastTarget = hit.transform;
                state = HandleHit(hit, LastTarget) ? KaijuActuatorState.Done : KaijuActuatorState.Failed;
                
                // If it failed on this, check parents.
                if (state == KaijuActuatorState.Failed && checkParents)
                {
                    Transform parent = LastTarget.parent;
                    while (parent)
                    {
                        state = HandleHit(hit, parent) ? KaijuActuatorState.Done : KaijuActuatorState.Failed;
                        if (state == KaijuActuatorState.Done)
                        {
                            break;
                        }
                        
                        parent = parent.parent;
                    }
                }
            }
            
            // Set the visuals if there are any.
            if (lineRenderer)
            {
                lineRenderer.positionCount = 2;
                lineRenderer.SetPosition(0, p);
                lineRenderer.SetPosition(1, LastPoint.Value);
                lineRenderer.enabled = true;
                _lineTimer = visible;
            }
            
            PostActions(state == KaijuActuatorState.Done);
            return state;
        }
        
        /// <summary>
        /// Update is called every frame, if the MonoBehaviour is enabled.
        /// </summary>
        private void Update()
        {
            // If the visualization is active, see if it should finish.
            if (!lineRenderer || !lineRenderer.enabled)
            {
                return;
            }
            
            _lineTimer -= Time.deltaTime;
            if (_lineTimer <= 0)
            {
                lineRenderer.enabled = false;
            }
        }
        
        /// <summary>
        /// Frame-rate independent MonoBehaviour.FixedUpdate message for physics calculations.
        /// </summary>
        private void FixedUpdate()
        {
            // Cool down between uses.
            if (_cooling > 0)
            {
                _cooling -= Time.deltaTime;
            }
        }
        
        /// <summary>
        /// Any conditions which must be passed to begin running the actuator. This does not need to account for the <see cref="Charge"/> or <see cref="Cooldown"/>.
        /// </summary>
        /// <returns>If the conditions to run this were passed.</returns>
        protected virtual bool PreConditions() => true;
        
        /// <summary>
        /// Any final actions to perform after the actuator has performed.
        /// </summary>
        /// <param name="success">If it succeeded or not.</param>
        protected virtual void PostActions(bool success) { }
        
        /// <summary>
        /// Handle the hit logic.
        /// </summary>
        /// <param name="hit">The hit details.</param>
        /// <param name="t">The transform currently being checked. This may not be the same as the one in the hit parameter in the case of checking parents.</param>
        /// <returns>If the attack was a success or not.</returns>
        protected abstract bool HandleHit(RaycastHit hit, [NotNull] Transform t);
        
        /// <summary>
        /// Perform any needed resetting of the <see cref="KaijuActuator"/>.
        /// </summary>
        protected override void Cleanup()
        {
            _charging = 0;
            _cooling = 0;
            LastPoint = null;
            LastTarget = null;
            
            if (lineRenderer)
            {
                lineRenderer.enabled = false;
            }
        }
        
        /// <summary>
        /// This function is called when the object becomes enabled and active.
        /// </summary>
        protected override void OnEnable()
        {
            base.OnEnable();
            OnInterrupted += ResetCharging;
            
            // Start with the visualizations disabled.
            if (lineRenderer)
            {
                lineRenderer.enabled = false;
            }
        }
        
        /// <summary>
        /// This function is called when the behaviour becomes disabled.
        /// </summary>
        protected override void OnDisable()
        {
            OnInterrupted -= ResetCharging;
            base.OnDisable();
        }
        
        /// <summary>
        /// If attacking is interrupted before the attack is done, reset the charging timer. 
        /// </summary>
        private void ResetCharging()
        {
            _charging = 0;
        }
        
        /// <summary>
        /// Get a description of the object.
        /// </summary>
        /// <returns>A description of the object.</returns>
        public override string ToString()
        {
            return $"Kaiju Attack Actuator {name} - Agent: {(Agent ? Agent.name : "None")}";
        }
        
        /// <summary>
        /// Implicit conversion from a <see href="https://docs.unity3d.com/Manual/class-GameObject.html">GameObject</see>.
        /// </summary>
        /// <param name="o">The <see href="https://docs.unity3d.com/Manual/class-GameObject.html">GameObject</see>.</param>
        /// <returns>The <see cref="KaijuAttackActuator"/> attached to the <see href="https://docs.unity3d.com/Manual/class-GameObject.html">GameObject</see> if there was one.</returns>
        public static implicit operator KaijuAttackActuator([NotNull] GameObject o) => o.GetComponent<KaijuAttackActuator>();
        
        /// <summary>
        /// Implicit conversion from a <see href="https://docs.unity3d.com/Manual/class-transform.html">transform</see>.
        /// </summary>
        /// <param name="t">The <see href="https://docs.unity3d.com/Manual/class-transform.html">transform</see>.</param>
        /// <returns>The <see cref="KaijuAttackActuator"/> attached to the <see href="https://docs.unity3d.com/Manual/class-transform.html">transform</see> if there was one.</returns>
        public static implicit operator KaijuAttackActuator([NotNull] Transform t) => t.GetComponent<KaijuAttackActuator>();
        
        /// <summary>
        /// Implicit conversion to a <see cref="KaijuAgent"/>.
        /// </summary>
        /// <param name="s">The <see cref="KaijuAttackActuator"/>.</param>
        /// <returns>The <see cref="KaijuAgent"/> attached to the <see cref="KaijuAttackActuator"/> if there was one.</returns>
        public static implicit operator KaijuAgent([NotNull] KaijuAttackActuator s) => s.Agent;
    }
}