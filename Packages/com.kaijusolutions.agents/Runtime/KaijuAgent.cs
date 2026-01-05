using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using KaijuSolutions.Agents.Actuators;
using KaijuSolutions.Agents.Extensions;
using KaijuSolutions.Agents.Movement;
using KaijuSolutions.Agents.Sensors;
using UnityEngine;
using UnityEngine.AI;
#if UNITY_EDITOR
using UnityEditor;
#endif
namespace KaijuSolutions.Agents
{
    /// <summary>
    /// Base <see cref="KaijuAgent"/> class.
    /// </summary>
    [DisallowMultipleComponent]
    [DefaultExecutionOrder(int.MinValue + 2)]
#if UNITY_EDITOR
    [SelectionBase]
    [Icon("Packages/com.kaijusolutions.agents/Editor/Icon.png")]
    [HelpURL("https://agents.kaijusolutions.ca")]
#endif
    public abstract class KaijuAgent : KaijuBehaviour
    {
        /// <summary>
        /// Movement speed changed callback.
        /// </summary>
        public event KaijuAction OnMoveSpeed;
        
        /// <summary>
        /// Global movement speed changed callback.
        /// </summary>
        public static event KaijuAgentAction OnMoveSpeedGlobal;
        
        /// <summary>
        /// Movement acceleration changed callback.
        /// </summary>
        public event KaijuAction OnMoveAcceleration;
        
        /// <summary>
        /// Global movement acceleration changed callback.
        /// </summary>
        public static event KaijuAgentAction OnMoveAccelerationGlobal;
        
        /// <summary>
        /// Look speed changed callback.
        /// </summary>
        public event KaijuAction OnLookSpeed;
        
        /// <summary>
        /// Global look speed changed callback.
        /// </summary>
        public static event KaijuAgentAction OnLookSpeedGlobal;
        
        /// <summary>
        /// Autorotation changed callback.
        /// </summary>
        public event KaijuAction OnAutoRotate;
        
        /// <summary>
        /// Global autorotation speed changed callback.
        /// </summary>
        public static event KaijuAgentAction OnAutoRotateGlobal;
        
        /// <summary>
        /// Callback for when the look target has been set.
        /// </summary>
        public event KaijuAction OnLookTarget;
        
        /// <summary>
        /// Global callback for when the look target has been set.
        /// </summary>
        public static event KaijuAgentAction OnLookTargetGlobal;
        
        /// <summary>
        /// Callback for when this <see cref="KaijuAgent"/> has moved.
        /// </summary>
        public event KaijuAction OnMove;
        
        /// <summary>
        /// Global callback for when this <see cref="KaijuAgent"/> has moved.
        /// </summary>
        public static event KaijuAgentAction OnMoveGlobal;
        
        /// <summary>
        /// Callback for when this has finishing becoming enabled.
        /// </summary>
        public event KaijuAction OnEnabled;
        
        /// <summary>
        /// Global callback for when this has finishing becoming enabled.
        /// </summary>
        public static event KaijuAgentAction OnEnabledGlobal;
        
        /// <summary>
        /// Callback for when this has finishing becoming disabled.
        /// </summary>
        public event KaijuAction OnDisabled;
        
        /// <summary>
        /// Global callback for when this has finishing becoming disabled.
        /// </summary>
        public static event KaijuAgentAction OnDisabledGlobal;
        
        /// <summary>
        /// Callback for when this has finishing becoming destroyed.
        /// </summary>
        public event KaijuAction OnDestroyed;
        
        /// <summary>
        /// Global callback for when this has finishing becoming destroyed.
        /// </summary>
        public static event KaijuAgentAction OnDestroyedGlobal;
        
        /// <summary>
        /// Callback for when a <see cref="KaijuMovement"/> has started.
        /// </summary>
        public event KaijuMovementAction OnMovementStarted;
        
        /// <summary>
        /// Callback for when a <see cref="KaijuMovement"/> has stopped.
        /// </summary>
        public event KaijuMovementAction OnMovementStopped;
        
        /// <summary>
        /// Callback for when a <see cref="KaijuMovement"/> has been performed.
        /// </summary>
        public event KaijuMovementAction OnMovementPerformed;
        
        /// <summary>
        /// Callback for when all automatic <see cref="KaijuSensor"/>s have finished being executed.
        /// </summary>
        public event KaijuAction OnAutomaticSense;
        
        /// <summary>
        /// Global callback for when all automatic <see cref="KaijuSensor"/>s have finished being executed.
        /// </summary>
        public static event KaijuAgentAction OnAutomaticSenseGlobal;
        
        /// <summary>
        /// Callback for when a <see cref="KaijuSensor"/> has been run.
        /// </summary>
        public event KaijuSensorAction OnSense;
        
        /// <summary>
        /// Callback for when a <see cref="KaijuSensor"/> has been enabled.
        /// </summary>
        public event KaijuSensorAction OnSensorEnabled;
        
        /// <summary>
        /// Callback for when a <see cref="KaijuSensor"/> has been disabled.
        /// </summary>
        public event KaijuSensorAction OnSensorDisabled;
        
        /// <summary>
        /// Callback for when an <see cref="KaijuActuator"/> has been enabled.
        /// </summary>
        public event KaijuActuatorAction OnActuatorEnabled;
        
        /// <summary>
        /// Callback for when an <see cref="KaijuActuator"/> has been disabled.
        /// </summary>
        public event KaijuActuatorAction OnActuatorDisabled;
        
        /// <summary>
        /// Callback for when an <see cref="KaijuActuator"/> has started to execute.
        /// </summary>
        public event KaijuActuatorAction OnActuatorStarted;
        
        /// <summary>
        /// Callback for when an <see cref="KaijuActuator"/> is continuing to execute.
        /// </summary>
        public event KaijuActuatorAction OnActuatorExecuting;
        
        /// <summary>
        /// Callback for when an <see cref="KaijuActuator"/> has successfully fully completed its action.
        /// </summary>
        public event KaijuActuatorAction OnActuatorDone;
        
        /// <summary>
        /// Callback for when an <see cref="KaijuActuator"/> has been interrupted during its execution, cancelling the execution.
        /// </summary>
        public event KaijuActuatorAction OnActuatorInterrupted;
        
        /// <summary>
        /// Callback for when an <see cref="KaijuActuator"/> has failed its execution.
        /// </summary>
        public event KaijuActuatorAction OnActuatorFailed;
        
        /// <summary>
        /// If this <see cref="KaijuAgent"/> should move with the physics system.
        /// </summary>
        public virtual bool PhysicsAgent => false;
        
        /// <summary>
        /// The maximum move speed of the <see cref="KaijuAgent"/> in units per second.
        /// </summary>
        public float MoveSpeed
        {
            get => moveSpeed;
            set
            {
                moveSpeed = Mathf.Max(value, 0);
                OnMoveSpeed?.Invoke();
                OnMoveSpeedGlobal?.Invoke(this);
            }
        }
        
        /// <summary>
        /// The maximum move speed of the <see cref="KaijuAgent"/> in units per second. Note that modifying this at runtime via the inspector will not trigger the callback.
        /// </summary>
#if UNITY_EDITOR
        [Header("Movement")]
        [Tooltip("The maximum move speed of the agent in units per second. Note that modifying this at runtime via the inspector will not trigger the callback.")]
#endif
        [Min(0)]
        [SerializeField]
        private float moveSpeed = 10f;
        
        /// <summary>
        /// The maximum move acceleration of the <see cref="KaijuAgent"/> in units per second. Setting to zero yields instant acceleration.
        /// </summary>
        public float MoveAcceleration
        {
            get => moveAcceleration;
            set
            {
                moveAcceleration = Mathf.Max(value, 0);
                OnMoveAcceleration?.Invoke();
                OnMoveAccelerationGlobal?.Invoke(this);
            }
        }
        
        /// <summary>
        /// The maximum move acceleration of the <see cref="KaijuAgent"/> in units per second. Setting to zero yields instant acceleration. Note that modifying this at runtime via the inspector will not trigger the callback.
        /// </summary>
#if UNITY_EDITOR
        [Tooltip("The maximum move acceleration of the agent in units per second. Setting to zero yields instant acceleration. Note that modifying this at runtime via the inspector will not trigger the callback.")]
#endif
        [Min(0)]
        [SerializeField]
        private float moveAcceleration;
        
        /// <summary>
        /// The look speed of the <see cref="KaijuAgent"/> in degrees per second.
        /// </summary>
        public float LookSpeed
        {
            get => lookSpeed;
            set
            {
                lookSpeed = Mathf.Max(value, 0);
                OnLookSpeed?.Invoke();
                OnLookSpeedGlobal?.Invoke(this);
            }
        }
        
        /// <summary>
        /// The look speed of the <see cref="KaijuAgent"/> in degrees per second. Note that modifying this at runtime via the inspector will not trigger the callback.
        /// </summary>
#if UNITY_EDITOR
        [Header("Looking")]
        [Tooltip("The look speed of the agent in degrees per second. Note that modifying this at runtime via the inspector will not trigger the callback.")]
#endif
        [Min(0)]
        [SerializeField]
        private float lookSpeed;
        
        /// <summary>
        /// If the <see cref="KaijuAgent"/> should automatically rotate towards where it is moving when no look target is set.
        /// </summary>
        public bool AutoRotate
        {
            get => autoRotate;
            set
            {
                autoRotate = value;
                OnAutoRotate?.Invoke();
                OnAutoRotateGlobal?.Invoke(this);
            }
        }
        
        /// <summary>
        /// If the <see cref="KaijuAgent"/> should automatically rotate towards where it is moving when no look target is set. Note that modifying this at runtime via the inspector will not trigger the callback.
        /// </summary>
#if UNITY_EDITOR
        [Tooltip("If the agent should automatically rotate towards where it is moving when no look target is set. Note that modifying this at runtime via the inspector will not trigger the callback.")]
#endif
        [SerializeField]
        private bool autoRotate = true;
        
        /// <summary>
        /// All <see cref="KaijuSensor"/>s attached to this <see cref="KaijuAgent"/>.
        /// </summary>
        public IReadOnlyCollection<KaijuSensor> Sensors => _sensors;
        
        /// <summary>
        /// The number of <see cref="KaijuSensor"/>s attached to this <see cref="KaijuAgent"/>.
        /// </summary>
        public int SensorsCount => _sensors.Count;
        
        /// <summary>
        /// All <see cref="KaijuSensor"/>s attached to this <see cref="KaijuAgent"/>.
        /// </summary>
        private readonly HashSet<KaijuSensor> _sensors = new();
        
        /// <summary>
        /// Register a <see cref="KaijuSensor"/>. There is no point in manually calling this.
        /// </summary>
        /// <param name="sensor">The <see cref="KaijuSensor"/> to register.</param>
        public void RegisterSensor(KaijuSensor sensor)
        {
            if (_sensors.Add(sensor))
            {
                OnSensorEnabled?.Invoke(sensor);
            }
        }
        
        /// <summary>
        /// Unregister a <see cref="KaijuSensor"/>. There is no point in manually calling this.
        /// </summary>
        /// <param name="sensor">The <see cref="KaijuSensor"/> to unregister.</param>
        public void UnregisterSensor(KaijuSensor sensor)
        {
            if (_sensors.Remove(sensor))
            {
                OnSensorDisabled?.Invoke(sensor);
            }
        }
        
        /// <summary>
        /// All <see cref="KaijuActuator"/>s attached to this <see cref="KaijuAgent"/>.
        /// </summary>
        public IReadOnlyCollection<KaijuActuator> Actuators => _actuators;
        
        /// <summary>
        /// The number of <see cref="KaijuActuator"/>s attached to this <see cref="KaijuAgent"/>.
        /// </summary>
        public int ActuatorsCount => _actuators.Count;
        
        /// <summary>
        /// All <see cref="KaijuActuator"/>s attached to this <see cref="KaijuAgent"/>.
        /// </summary>
        private readonly HashSet<KaijuActuator> _actuators = new();
        
        /// <summary>
        /// Register an <see cref="KaijuActuator"/>. There is no point in manually calling this.
        /// </summary>
        /// <param name="actuator">The <see cref="KaijuActuator"/>s to register.</param>
        public void RegisterActuator(KaijuActuator actuator)
        {
            if (_actuators.Add(actuator))
            {
                OnActuatorEnabled?.Invoke(actuator);
            }
        }
        
        /// <summary>
        /// Unregister an <see cref="KaijuActuator"/>. There is no point in manually calling this.
        /// </summary>
        /// <param name="actuator">The <see cref="KaijuSensor"/> to unregister.</param>
        public void UnregisterActuator(KaijuActuator actuator)
        {
            if (_actuators.Remove(actuator))
            {
                OnActuatorDisabled?.Invoke(actuator);
            }
        }
        
        /// <summary>
        /// Identifiers for this <see cref="KaijuAgent"/>.
        /// </summary>
        public IReadOnlyList<uint> Identifiers => identifiers;
        
        /// <summary>
        /// The default movement values for this <see cref="KaijuAgent"/>.
        /// </summary>
#if UNITY_EDITOR
        [Header("Configuration")]
        [Tooltip("The default movement values for this agent.")]
#endif
        [SerializeField]
        public KaijuMovementConfiguration configuration;
        
        /// <summary>
        /// Identifiers for this <see cref="KaijuAgent"/>. Note that modifying this at runtime via the inspector will not trigger the callback.
        /// </summary>
#if UNITY_EDITOR
        [Tooltip("Identifiers for this agent. Note that modifying this at runtime via the inspector will not trigger the callback.")]
#endif
        [SerializeField]
        private List<uint> identifiers = new();
        
        /// <summary>
        /// The manual control vector for the <see cref="KaijuAgent"/>'s movement, with steering values ranging from negative one to positive one on each axis. This is multiplied by the <see cref="MoveSpeed"/>.
        /// </summary>
        public Vector2 Control
        {
            get => _control;
            set => _control = value.normalized;
        }
        
        /// <summary>
        /// The manual control vector for the <see cref="KaijuAgent"/>'s movement, with steering values ranging from negative one to positive one on each axis. This is multiplied by the <see cref="MoveSpeed"/>.
        /// </summary>
        public Vector3 Control3
        {
            get => _control.Expand();
            set => Control = value.Flatten();
        }
        
        /// <summary>
        /// The manual control vector for the <see cref="KaijuAgent"/>'s movement, with steering values ranging from negative one to positive one on each axis. This is multiplied by the <see cref="MoveSpeed"/>.
        /// </summary>
        private Vector2 _control = Vector2.zero;
        
        /// <summary>
        /// The current velocity of the <see cref="KaijuAgent"/>.
        /// </summary>
        public Vector2 Velocity { get; private set; }
        
        /// <summary>
        /// The current velocity of the <see cref="KaijuAgent"/>.
        /// </summary>
        public Vector3 Velocity3 => Velocity.Expand();
        
        /// <summary>
        /// Get the forward direction of this <see cref="KaijuAgent"/> along the X and Z axes based on how its moving. If moving, this is the direction of its velocity. Otherwise, it is the same as <see cref="KaijuBehaviour.Forward3"/>.
        /// </summary>
        public Vector2 MoveForward => Velocity == Vector2.zero ? Forward : Velocity;
        
        /// <summary>
        /// Get the forward direction of this <see cref="KaijuAgent"/> based on how its moving. If moving, this is the direction of its velocity. Otherwise, it is the same as <see cref="KaijuBehaviour.Forward3"/>.
        /// </summary>
        public Vector3 MoveForward3 => Velocity == Vector2.zero ? Forward3 : Velocity3;
        
        /// <summary>
        /// All movements the <see cref="KaijuAgent"/> is currently performing.
        /// </summary>
        private readonly List<KaijuMovement> _movements = new();
        
        /// <summary>
        /// All movements the <see cref="KaijuAgent"/> is currently performing.
        /// </summary>
        public IReadOnlyList<KaijuMovement> Movements => _movements.AsReadOnly();
        
        /// <summary>
        /// The total number movements the <see cref="KaijuAgent"/> is currently performing.
        /// </summary>
        public int MovementsCount => _movements.Count;
        
        /// <summary>
        /// If there are any movements occuring.
        /// </summary>
        public bool Moving => isActiveAndEnabled && MovementsCount > 0;
        
        /// <summary>
        /// The manual spin control, ranging from negative one to positive one. Negative values mean a left spin and positive values mean a right spin, multiplied by the <see cref="LookSpeed"/>.
        /// </summary>
        private float? _spin;
        
        /// <summary>
        /// The angle to look at relative to the global forward direction.
        /// </summary>
        private float? _lookAngle;
        
        /// <summary>
        /// The vector to look at.
        /// </summary>
        private Vector2? _lookVector;
        
        /// <summary>
        /// The vector to look at.
        /// </summary>
        private Vector3? _lookVector3;
        
        /// <summary>
        /// The <see href="https://docs.unity3d.com/Manual/class-transform.html">transform</see> to look at.
        /// </summary>
        private Transform _lookTransform;
        
        /// <summary>
        /// The manual spin control, ranging from negative one to positive one. Negative values mean a left spin and positive values mean a right spin, multiplied by the <see cref="LookSpeed"/>.
        /// </summary>
        public float? Spin
        {
            get => _spin;
            set
            {
                _spin = value.HasValue ? Mathf.Clamp(value.Value, -1, 1) : null;
                _lookAngle = null;
                _lookVector = null;
                _lookVector3 = null;
                _lookTransform = null;
                _wasLooking = false;
                OnLookTarget?.Invoke();
                OnLookTargetGlobal?.Invoke(this);
            }
        }
        
        /// <summary>
        /// The angle to look at relative to the global forward direction.
        /// </summary>
        public float? LookAngle
        {
            get
            {
                if (_lookAngle.HasValue)
                {
                    return _lookAngle;
                }
                
                if (_spin.HasValue)
                {
                    return Orientation + _spin * LookSpeed;
                }
                
                Vector2? v = LookVector;
                if (!v.HasValue)
                {
                    return null;
                }
                
                Vector2 d = v.Value - Position;
                return Mathf.Atan2(d.x, d.y) * Mathf.Rad2Deg;
            }
            set
            {
                _lookAngle = value;
                _spin = null;
                _lookVector = null;
                _lookVector3 = null;
                _lookTransform = null;
                _wasLooking = false;
                OnLookTarget?.Invoke();
                OnLookTargetGlobal?.Invoke(this);
            }
        }
        
        /// <summary>
        /// The vector to look at.
        /// </summary>
        public Vector2? LookVector
        {
            get
            {
                if (!_lookTransform)
                {
                    if (_lookVector3.HasValue)
                    {
                        return new(_lookVector3.Value.x, _lookVector3.Value.z);
                    }
                    
                    if (_lookVector.HasValue)
                    {
                        return _lookVector;
                    }

                    float angle;
                    if (_lookAngle.HasValue)
                    {
                        angle = _lookAngle.Value * Mathf.Deg2Rad;
                    }
                    else if (_spin.HasValue)
                    {
                        float spin = lookSpeed > 0 ? Mathf.Min(lookSpeed, 179) : 179;
                        angle = (Orientation + _spin.Value * spin) * Mathf.Deg2Rad;
                    }
                    else
                    {
                        return null;
                    }
                    
                    return Position + new Vector2(Mathf.Sin(angle), Mathf.Cos(angle)) * float.MaxValue;
                }
                
                Vector3 p = _lookTransform.position;
                return new(p.x, p.z);
            }
            set
            {
                _lookVector = value;
                _spin = null;
                _lookAngle = null;
                _lookVector3 = null;
                _lookTransform = null;
                _wasLooking = false;
                OnLookTarget?.Invoke();
                OnLookTargetGlobal?.Invoke(this);
            }
        }
        
        /// <summary>
        /// The vector to look at.
        /// </summary>
        public Vector3? LookVector3
        {
            get
            {
                if (_lookTransform)
                {
                    return _lookTransform.position;
                }
                
                if (_lookVector.HasValue)
                {
                    return new(_lookVector.Value.x, Y, _lookVector.Value.y);
                }
                
                if (_lookVector3.HasValue)
                {
                    return _lookVector3;
                }
                
                float angle;
                if (_lookAngle.HasValue)
                {
                    angle = _lookAngle.Value * Mathf.Deg2Rad;
                }
                else if (_spin.HasValue)
                {
                    float spin = lookSpeed > 0 ? Mathf.Min(lookSpeed, 179) : 179;
                    angle = (Orientation + _spin.Value * spin) * Mathf.Deg2Rad;
                }
                else
                {
                    return null;
                }
                
                Vector3 p = Position3;
                return p + new Vector3(Mathf.Sin(angle), 0, Mathf.Cos(angle));
            }
            set
            {
                _lookVector3 = value;
                _spin = null;
                _lookAngle = null;
                _lookVector = null;
                _lookTransform = null;
                _wasLooking = false;
                OnLookTarget?.Invoke();
                OnLookTargetGlobal?.Invoke(this);
            }
        }
        
        /// <summary>
        /// The <see href="https://docs.unity3d.com/Manual/class-transform.html">transform</see> to look at.
        /// </summary>
        public Transform LookTransform
        {
            get => _lookTransform;
            set
            {
                _lookTransform = value;
                _spin = null;
                _lookAngle = null;
                _lookVector = null;
                _lookVector3 = null;
                _wasLooking = false;
                OnLookTarget?.Invoke();
                OnLookTargetGlobal?.Invoke(this);
            }
        }
        
        /// <summary>
        /// The <see href="https://docs.unity3d.com/Manual/class-GameObject.html">GameObject</see> to look at.
        /// </summary>
        public GameObject LookGameObject
        {
            get => _lookTransform ? _lookTransform.gameObject : null;
            set => LookTransform = value.transform;
        }
        
        /// <summary>
        /// The <see href="https://docs.unity3d.com/Manual/Components.html">component</see> to look at.
        /// </summary>
        public Component LookComponent
        {
            set => LookTransform = value.transform;
        }
        
        /// <summary>
        /// The <see cref="KaijuAgent"/> to move in relation to.
        /// </summary>
        public KaijuAgent TargetAgent
        {
            get => _lookTransform ? _lookTransform.GetComponent<KaijuAgent>() : null;
            set => TargetComponent = value;
        }
        
        /// <summary>
        /// The <see href="https://docs.unity3d.com/Manual/Components.html">component</see> to look at.
        /// </summary>
        public Component TargetComponent
        {
            set
            {
                _lookTransform = value.transform;
                _lookVector = null;
                _lookVector3 = null;
                OnLookTarget?.Invoke();
                OnLookTargetGlobal?.Invoke(this);
            }
        }
        
        /// <summary>
        /// If the <see cref="KaijuAgent"/> is currently looking at something.
        /// </summary>
        public bool Looking => LookVector.HasValue;
        
        /// <summary>
        /// Check if we were looking in the last frame, and if we now do not have a look target in the current frame, it indicates that the target was destroyed externally.
        /// </summary>
        private bool _wasLooking;
        
        /// <summary>
        /// Get the distance from the <see cref="KaijuAgent"/> to the target which is being looked at.
        /// </summary>
        public float LookDistance => LookVector3?.Distance(transform) ?? 0;
        
        /// <summary>
        /// The total weight of all movements.
        /// </summary>
        public float MovementWeights
        {
            get
            {
                float weight = 0;
                foreach (KaijuMovement movement in _movements)
                {
                    weight += movement.Weight;
                }
                
                return weight;
            }
        }
        
        /// <summary>
        /// Get the radius of an <see cref="KaijuAgent"/>.
        /// </summary>
        /// <returns>The radius of the <see cref="KaijuAgent"/>.</returns>
        public abstract float GetRadius();
        
        /// <summary>
        /// Initialize the <see cref="KaijuAgent"/>. There is no point in manually calling this.
        /// </summary>
        public virtual void Setup()
        {
            if (!transform.parent)
            {
                return;
            }
            
            transform.parent = null;
            Debug.LogWarning("Kaiju Agents - Agents must not be child objects.", this);

        }
        
        /// <summary>
        /// Calculate the velocity for the next update. There is no point in manually calling this.
        /// <param name="delta">The time step.</param>
        /// </summary>
        public void CalculateVelocity(float delta)
        {
            // Start with any manual steering.
            Vector2 velocity = _control * moveSpeed;
            Vector2 position = Position;
            
            // Go through all assigned movements.
            for (int i = 0; i < _movements.Count; i++)
            {
                // If the movement is done, remove it to the cache.
                if (_movements[i].Done())
                {
                    _movements[i].Stopped();
                    OnMovementStopped?.Invoke(_movements[i]);
                    _movements[i].Return();
                    _movements.RemoveAt(i--);
                    continue;
                }
                
                // Weight the movement.
                velocity += _movements[i].Move(position, delta) * _movements[i].Weight;
                _movements[i].Performed();
                OnMovementPerformed?.Invoke(_movements[i]);
            }
            
            // Clamp the movement velocity.
            if (velocity.sqrMagnitude > moveSpeed * moveSpeed)
            {
                velocity = velocity.normalized * moveSpeed;
            }
            
            // Set the updated velocity.
            Velocity = moveAcceleration > 0 ? Vector2.Lerp(Velocity, velocity, moveAcceleration * delta) : velocity;
            
            // Invoke callbacks if there has been movement.
            if (Velocity == Vector2.zero)
            {
                return;
            }
            
            OnMove?.Invoke();
            OnMoveGlobal?.Invoke(this);
        }
        
        /// <summary>
        /// This function is called when the object becomes enabled and active.
        /// </summary>
        protected virtual void OnEnable()
        {
            Setup();
            KaijuAgentsManager.Register(this);
            OnEnabled?.Invoke();
            OnEnabledGlobal?.Invoke(this);
        }
        
        /// <summary>
        /// This function is called when the behaviour becomes disabled.
        /// </summary>
        protected virtual void OnDisable()
        {
            Stop();
            StopLooking();
            ClearIdentifiers();
            Velocity = Vector2.zero;
            KaijuAgentsManager.Unregister(this);
            OnDisabled?.Invoke();
            OnDisabledGlobal?.Invoke(this);
        }
        
        /// <summary>
        /// Destroying the attached Behaviour will result in the game or Scene receiving OnDestroy.
        /// </summary>
        private void OnDestroy()
        {
            // Unregister without caching.
            KaijuAgentsManager.Unregister(this, false);
            OnDestroyed?.Invoke();
            OnDestroyedGlobal?.Invoke(this);
        }
        
        /// <summary>
        /// Spawn this <see cref="KaijuAgent"/> if it is not currently spawned. There is no point in manually calling this.
        /// </summary>
        public void Spawn()
        {
            gameObject.SetActive(true);
            enabled = true;
        }
        
        /// <summary>
        /// Despawn this <see cref="KaijuAgent"/>.
        /// </summary>
        public void Despawn()
        {
            enabled = false;
            gameObject.SetActive(false);
        }
        
        /// <summary>
        /// Clear all identifiers.
        /// </summary>
        public void ClearIdentifiers()
        {
            foreach (uint identifier in identifiers)
            {
                KaijuAgentsManager.RemoveIdentifier(this, identifier);
            }
            
            identifiers.Clear();
        }
        
        /// <summary>
        /// If this <see cref="KaijuAgent"/> has an identifier.
        /// </summary>
        /// <param name="identifier">The identifier to check.</param>
        /// <returns>If this <see cref="KaijuAgent"/> has the identifier.</returns>
        public bool HasIdentifier(uint identifier)
        {
            foreach (uint i in identifiers)
            {
                if (i == identifier)
                {
                    return true;
                }
            }
            
            return false;
        }
        
        /// <summary>
        /// If this <see cref="KaijuAgent"/> has any one of a set of identifiers.
        /// </summary>
        /// <param name="collection">The identifiers to check.</param>
        /// <returns>If this <see cref="KaijuAgent"/> has any one of a set of identifiers.</returns>
        public bool HasAnyIdentifier(IEnumerable<uint> collection)
        {
            foreach (uint identifier in collection)
            {
                if (HasIdentifier(identifier))
                {
                    return true;
                }
            }
            
            return false;
        }
        
        /// <summary>
        /// Add an identifier to this <see cref="KaijuAgent"/>.
        /// </summary>
        /// <param name="identifier">The identifier to set.</param>
        /// <returns>If the identifier was added.</returns>
        public bool AddIdentifier(uint identifier)
        {
            if (HasIdentifier(identifier))
            {
                return false;
            }
            
            identifiers.Add(identifier);
            KaijuAgentsManager.AddIdentifier(this, identifier);
            return true;
        }
        
        /// <summary>
        /// Add identifiers to this <see cref="KaijuAgent"/>.
        /// </summary>
        /// <param name="collection">The identifiers to add.</param>
        /// <returns>If any of the identifiers were added.</returns>
        public bool AddIdentifiers(IEnumerable<uint> collection)
        {
            bool added = false;
            foreach (uint identifier in collection)
            {
                if (AddIdentifier(identifier))
                {
                    added = true;
                }
            }
            
            return added;
        }
        
        /// <summary>
        /// Remove an identifier from this <see cref="KaijuAgent"/>.
        /// </summary>
        /// <param name="identifier">The identifier to remove.</param>
        /// <returns>If the identifier was removed.</returns>
        public bool RemoveIdentifier(uint identifier)
        {
            if (!HasIdentifier(identifier))
            {
                return false;
            }
            
            identifiers.Remove(identifier);
            KaijuAgentsManager.RemoveIdentifier(this, identifier);
            return true;
        }
        
        /// <summary>
        /// Remove identifiers from this <see cref="KaijuAgent"/>.
        /// </summary>
        /// <param name="collection">The identifiers to remove.</param>
        /// <returns>If any of the identifiers were removed.</returns>
        public bool RemoveIdentifiers(IEnumerable<uint> collection)
        {
            bool removed = false;
            foreach (uint identifier in collection)
            {
                if (RemoveIdentifier(identifier))
                {
                    removed = true;
                }
            }
            
            return removed;
        }
        
        /// <summary>
        /// Set an identifier to this <see cref="KaijuAgent"/>.
        /// </summary>
        /// <param name="identifier">The identifier to set.</param>
        public void SetIdentifier(uint identifier)
        {
            ClearIdentifiers();
            AddIdentifier(identifier);
        }
        
        /// <summary>
        /// If this <see cref="KaijuAgent"/> has any one of a set of identifiers.
        /// </summary>
        /// <param name="collection">The identifiers to check.</param>
        /// <returns>If this <see cref="KaijuAgent"/> has any one of a set of identifiers.</returns>
        public void SetIdentifiers(IEnumerable<uint> collection)
        {
            ClearIdentifiers();
            AddIdentifiers(collection);
        }
        
        /// <summary>
        /// Stop all movement, including manual steering.
        /// </summary>
        public void Stop()
        {
            _control = Vector2.zero;
            
            foreach (KaijuMovement movement in _movements)
            {
                movement.Stopped();
                OnMovementStopped?.Invoke(movement);
                movement.Return();
            }
            
            _movements.Clear();
        }
        
        /// <summary>
        /// Stop a movement of this <see cref="KaijuAgent"/>.
        /// </summary>
        /// <param name="movement">The movement to stop.</param>
        /// <returns>True if this movement has been stopped, otherwise this movement was not a part of this <see cref="KaijuAgent"/> and was not stopped.</returns>
        public bool Stop(KaijuMovement movement)
        {
            for (int i = 0; i < _movements.Count; i++)
            {
                if (_movements[i] != movement)
                {
                    continue;
                }
                
                _movements[i].Stopped();
                OnMovementStopped?.Invoke(_movements[i]);
                _movements[i].Return();
                _movements.RemoveAt(i);
                return true;
            }
            
            return false;
        }
        
        /// <summary>
        /// Stop all instances of a movement type. This checks for exact matches, not inherited classes.
        /// </summary>
        /// <typeparam name="T">The type of movement to stop.</typeparam>
        /// <returns>True if any instances were stopped.</returns>
        public bool Stop<T>() where T : KaijuMovement
        {
            Type t = typeof(T);
            bool removed = false;
            
            for (int i = 0; i < _movements.Count; i++)
            {
                if (_movements[i].GetType() != t)
                {
                    continue;
                }
                
                _movements[i].Stopped();
                OnMovementStopped?.Invoke(_movements[i]);
                _movements[i].Return();
                _movements.RemoveAt(i--);
                removed = true;
            }
            
            return removed;
        }
        
        /// <summary>
        /// Stop a movement by the given index.
        /// </summary>
        /// <param name="index">The index to stop.</param>
        /// <returns>If the movement was stopped, with a failure indicating the index was out of bounds.</returns>
        public bool Stop(int index)
        {
            if (index < 0 || index >= MovementsCount)
            {
                return false;
            }
            
            _movements[index].Stopped();
            OnMovementStopped?.Invoke(_movements[index]);
            _movements[index].Return();
            _movements.RemoveAt(index);
            return true;
        }

        /// <summary>
        /// Stop existing target movements in relation to a vector.
        /// </summary>
        /// <param name="v">The vector to stop moving in relation to.</param>
        /// <returns>The number of target movements which were stopped.</returns>
        public int Stop(Vector2 v)
        {
            int removed = 0;
            
            for (int i = 0; i < _movements.Count; i++)
            {
                if (_movements[i] is not KaijuTargetMovement target)
                {
                    continue;
                }
                
                Vector2 t = target.Target;
                if (v != t)
                {
                    continue;
                }
                
                _movements[i].Stopped();
                OnMovementStopped?.Invoke(_movements[i]);
                _movements[i].Return();
                _movements.RemoveAt(i--);
                removed++;
            }
            
            return removed;
        }
        
        /// <summary>
        /// Stop existing target movements in relation to a vector.
        /// </summary>
        /// <param name="v">The vector to stop moving in relation to.</param>
        /// <returns>The number of target movements which were stopped.</returns>
        public int Stop(Vector3 v)
        {
            return Stop(v.Flatten());
        }
        
        /// <summary>
        /// Stop existing target movements in relation to a <see href="https://docs.unity3d.com/Manual/class-GameObject.html">GameObject</see>.
        /// </summary>
        /// <param name="go">The <see href="https://docs.unity3d.com/Manual/class-GameObject.html">GameObject</see> to stop moving in relation to.</param>
        /// <returns>The number of target movements which were stopped.</returns>
        public int Stop([NotNull] GameObject go)
        {
            int removed = 0;
            
            for (int i = 0; i < _movements.Count; i++)
            {
                if (_movements[i] is KaijuTargetMovement target && target.TargetGameObject != go)
                {
                    continue;
                }
                
                _movements[i].Stopped();
                OnMovementStopped?.Invoke(_movements[i]);
                _movements[i].Return();
                _movements.RemoveAt(i--);
                removed++;
            }
            
            return removed;
        }
        
        /// <summary>
        /// Stop an existing target movement in relation to a <see href="https://docs.unity3d.com/Manual/Components.html">component</see>.
        /// </summary>
        /// <param name="c">The <see href="https://docs.unity3d.com/Manual/Components.html">component</see> to stop moving in relation to.</param>
        /// <returns>The number of target movements which were stopped.</returns>
        public int Stop([NotNull] Component c)
        {
            return Stop(c.gameObject);
        }
        
        /// <summary>
        /// Stop explicitly looking at a target.
        /// </summary>
        public void StopLooking()
        {
            _spin = null;
            _lookAngle = null;
            _lookTransform = null;
            _lookVector = null;
            _lookVector3 = null;
            OnLookTarget?.Invoke();
            OnLookTargetGlobal?.Invoke(this);
        }
        
        /// <summary>
        /// Seek to a target.
        /// </summary>
        /// <param name="target">The target.</param>
        /// <param name="distance">At what distance from the target should the seek be considered successful.</param>
        /// <param name="weight">The weight of this movement.</param>
        /// <param name="clear">If this should clear all other current movement and become the only one the <see cref="KaijuAgent"/> is performing.</param>
        /// <returns>The seek movement to the target.</returns>
        public KaijuSeekMovement Seek(Vector2 target, float? distance = null, float? weight = null, bool? clear = null)
        {
            if (clear ?? (!configuration || configuration.clear))
            {
                Stop();
            }

            float d = distance ?? (configuration ? configuration.ApproachingDistance : KaijuApproachingMovement.DefaultDistance);
            KaijuSeekMovement movement = KaijuSeekMovement.Get(this, target, d, weight ?? (configuration ? configuration.Weight : KaijuMovement.DefaultWeight));
            _movements.Add(movement);
            movement.Started();
            OnMovementStarted?.Invoke(movement);
            return movement;
        }
        
        /// <summary>
        /// Seek to a target.
        /// </summary>
        /// <param name="target">The target.</param>
        /// <param name="distance">At what distance from the target should the seek be considered successful.</param>
        /// <param name="weight">The weight of this movement.</param>
        /// <param name="clear">If this should clear all other current movement and become the only one the <see cref="KaijuAgent"/> is performing.</param>
        /// <returns>The seek movement to the target.</returns>
        public KaijuSeekMovement Seek(Vector3 target, float? distance = null, float? weight = null, bool? clear = null)
        {
            if (clear ?? (!configuration || configuration.clear))
            {
                Stop();
            }
            
            float d = distance ?? (configuration ? configuration.ApproachingDistance : KaijuApproachingMovement.DefaultDistance);
            KaijuSeekMovement movement = KaijuSeekMovement.Get(this, target, d, weight ?? (configuration ? configuration.Weight : KaijuMovement.DefaultWeight));
            _movements.Add(movement);
            movement.Started();
            OnMovementStarted?.Invoke(movement);
            return movement;
        }
        
        /// <summary>
        /// Seek to a target.
        /// </summary>
        /// <param name="target">The target.</param>
        /// <param name="distance">At what distance from the target should the seek be considered successful.</param>
        /// <param name="weight">The weight of this movement.</param>
        /// <param name="clear">If this should clear all other current movement and become the only one the <see cref="KaijuAgent"/> is performing.</param>
        /// <returns>The seek movement to the target.</returns>
        public KaijuSeekMovement Seek([NotNull] GameObject target, float? distance = null, float? weight = null, bool? clear = null)
        {
            if (clear ?? (!configuration || configuration.clear))
            {
                Stop();
            }
            
            float d = distance ?? (configuration ? configuration.ApproachingDistance : KaijuApproachingMovement.DefaultDistance);
            KaijuSeekMovement movement = KaijuSeekMovement.Get(this, target, d, weight ?? (configuration ? configuration.Weight : KaijuMovement.DefaultWeight));
            _movements.Add(movement);
            movement.Started();
            OnMovementStarted?.Invoke(movement);
            return movement;
        }
        
        /// <summary>
        /// Seek to a target.
        /// </summary>
        /// <param name="target">The target.</param>
        /// <param name="distance">At what distance from the target should the seek be considered successful.</param>
        /// <param name="weight">The weight of this movement.</param>
        /// <param name="clear">If this should clear all other current movement and become the only one the <see cref="KaijuAgent"/> is performing.</param>
        /// <returns>The seek movement to the target.</returns>
        public KaijuSeekMovement Seek([NotNull] Component target, float? distance = null, float? weight = null, bool? clear = null)
        {
            if (clear ?? (!configuration || configuration.clear))
            {
                Stop();
            }
            
            float d = distance ?? (configuration ? configuration.ApproachingDistance : KaijuApproachingMovement.DefaultDistance);
            KaijuSeekMovement movement = KaijuSeekMovement.Get(this, target, d, weight ?? (configuration ? configuration.Weight : KaijuMovement.DefaultWeight));
            _movements.Add(movement);
            movement.Started();
            OnMovementStarted?.Invoke(movement);
            return movement;
        }
        
        /// <summary>
        /// Pursue to a target.
        /// </summary>
        /// <param name="target">The target.</param>
        /// <param name="distance">At what distance from the target should the pursue be considered successful.</param>
        /// <param name="weight">The weight of this movement.</param>
        /// <param name="clear">If this should clear all other current movement and become the only one the <see cref="KaijuAgent"/> is performing.</param>
        /// <returns>The pursue movement to the target.</returns>
        public KaijuPursueMovement Pursue(Vector2 target, float? distance = null, float? weight = null, bool? clear = null)
        {
            if (clear ?? (!configuration || configuration.clear))
            {
                Stop();
            }
            
            float d = distance ?? (configuration ? configuration.ApproachingDistance : KaijuApproachingMovement.DefaultDistance);
            KaijuPursueMovement movement = KaijuPursueMovement.Get(this, target, d, weight ?? (configuration ? configuration.Weight : KaijuMovement.DefaultWeight));
            _movements.Add(movement);
            movement.Started();
            OnMovementStarted?.Invoke(movement);
            return movement;
        }
        
        /// <summary>
        /// Pursue to a target.
        /// </summary>
        /// <param name="target">The target.</param>
        /// <param name="distance">At what distance from the target should the pursue be considered successful.</param>
        /// <param name="weight">The weight of this movement.</param>
        /// <param name="clear">If this should clear all other current movement and become the only one the <see cref="KaijuAgent"/> is performing.</param>
        /// <returns>The pursue movement to the target.</returns>
        public KaijuPursueMovement Pursue(Vector3 target, float? distance = null, float? weight = null, bool? clear = null)
        {
            if (clear ?? (!configuration || configuration.clear))
            {
                Stop();
            }
            
            float d = distance ?? (configuration ? configuration.ApproachingDistance : KaijuApproachingMovement.DefaultDistance);
            KaijuPursueMovement movement = KaijuPursueMovement.Get(this, target, d, weight ?? (configuration ? configuration.Weight : KaijuMovement.DefaultWeight));
            _movements.Add(movement);
            movement.Started();
            OnMovementStarted?.Invoke(movement);
            return movement;
        }
        
        /// <summary>
        /// Pursue to a target.
        /// </summary>
        /// <param name="target">The target.</param>
        /// <param name="distance">At what distance from the target should the pursue be considered successful.</param>
        /// <param name="weight">The weight of this movement.</param>
        /// <param name="clear">If this should clear all other current movement and become the only one the <see cref="KaijuAgent"/> is performing.</param>
        /// <returns>The pursue movement to the target.</returns>
        public KaijuPursueMovement Pursue([NotNull] GameObject target, float? distance = null, float? weight = null, bool? clear = null)
        {
            if (clear ?? (!configuration || configuration.clear))
            {
                Stop();
            }
            
            float d = distance ?? (configuration ? configuration.ApproachingDistance : KaijuApproachingMovement.DefaultDistance);
            KaijuPursueMovement movement = KaijuPursueMovement.Get(this, target, d, weight ?? (configuration ? configuration.Weight : KaijuMovement.DefaultWeight));
            _movements.Add(movement);
            movement.Started();
            OnMovementStarted?.Invoke(movement);
            return movement;
        }
        
        /// <summary>
        /// Pursue to a target.
        /// </summary>
        /// <param name="target">The target.</param>
        /// <param name="distance">At what distance from the target should the pursue be considered successful.</param>
        /// <param name="weight">The weight of this movement.</param>
        /// <param name="clear">If this should clear all other current movement and become the only one the <see cref="KaijuAgent"/> is performing.</param>
        /// <returns>The pursue movement to the target.</returns>
        public KaijuPursueMovement Pursue([NotNull] Component target, float? distance = null, float? weight = null, bool? clear = null)
        {
            if (clear ?? (!configuration || configuration.clear))
            {
                Stop();
            }
            
            float d = distance ?? (configuration ? configuration.ApproachingDistance : KaijuApproachingMovement.DefaultDistance);
            KaijuPursueMovement movement = KaijuPursueMovement.Get(this, target, d, weight ?? (configuration ? configuration.Weight : KaijuMovement.DefaultWeight));
            _movements.Add(movement);
            movement.Started();
            OnMovementStarted?.Invoke(movement);
            return movement;
        }
        
        /// <summary>
        /// Flee from a target.
        /// </summary>
        /// <param name="target">The target.</param>
        /// <param name="distance">At what distance from the target should the flee be considered successful.</param>
        /// <param name="weight">The weight of this movement.</param>
        /// <param name="clear">If this should clear all other current movement and become the only one the <see cref="KaijuAgent"/> is performing.</param>
        /// <returns>The flee movement to the target.</returns>
        public KaijuFleeMovement Flee(Vector2 target, float? distance = null, float? weight = null, bool? clear = null)
        {
            if (clear ?? (!configuration || configuration.clear))
            {
                Stop();
            }
            
            float d = distance ?? (configuration ? configuration.LeavingDistance : KaijuLeavingMovement.DefaultDistance);
            KaijuFleeMovement movement = KaijuFleeMovement.Get(this, target, d, weight ?? (configuration ? configuration.Weight : KaijuMovement.DefaultWeight));
            _movements.Add(movement);
            movement.Started();
            OnMovementStarted?.Invoke(movement);
            return movement;
        }
        
        /// <summary>
        /// Flee from a target.
        /// </summary>
        /// <param name="target">The target.</param>
        /// <param name="distance">At what distance from the target should the flee be considered successful.</param>
        /// <param name="weight">The weight of this movement.</param>
        /// <param name="clear">If this should clear all other current movement and become the only one the <see cref="KaijuAgent"/> is performing.</param>
        /// <returns>The flee movement to the target.</returns>
        public KaijuFleeMovement Flee(Vector3 target, float? distance = null, float? weight = null, bool? clear = null)
        {
            if (clear ?? (!configuration || configuration.clear))
            {
                Stop();
            }
            
            float d = distance ?? (configuration ? configuration.LeavingDistance : KaijuLeavingMovement.DefaultDistance);
            KaijuFleeMovement movement = KaijuFleeMovement.Get(this, target, d, weight ?? (configuration ? configuration.Weight : KaijuMovement.DefaultWeight));
            _movements.Add(movement);
            movement.Started();
            OnMovementStarted?.Invoke(movement);
            return movement;
        }
        
        /// <summary>
        /// Flee from a target.
        /// </summary>
        /// <param name="target">The target.</param>
        /// <param name="distance">At what distance from the target should the flee be considered successful.</param>
        /// <param name="weight">The weight of this movement.</param>
        /// <param name="clear">If this should clear all other current movement and become the only one the <see cref="KaijuAgent"/> is performing.</param>
        /// <returns>The flee movement to the target.</returns>
        public KaijuFleeMovement Flee([NotNull] GameObject target, float? distance = null, float? weight = null, bool? clear = null)
        {
            if (clear ?? (!configuration || configuration.clear))
            {
                Stop();
            }
            
            float d = distance ?? (configuration ? configuration.LeavingDistance : KaijuLeavingMovement.DefaultDistance);
            KaijuFleeMovement movement = KaijuFleeMovement.Get(this, target, d, weight ?? (configuration ? configuration.Weight : KaijuMovement.DefaultWeight));
            _movements.Add(movement);
            movement.Started();
            OnMovementStarted?.Invoke(movement);
            return movement;
        }
        
        /// <summary>
        /// Flee from a target.
        /// </summary>
        /// <param name="target">The target.</param>
        /// <param name="distance">At what distance from the target should the flee be considered successful.</param>
        /// <param name="weight">The weight of this movement.</param>
        /// <param name="clear">If this should clear all other current movement and become the only one the <see cref="KaijuAgent"/> is performing.</param>
        /// <returns>The flee movement to the target.</returns>
        public KaijuFleeMovement Flee([NotNull] Component target, float? distance = null, float? weight = null, bool? clear = null)
        {
            if (clear ?? (!configuration || configuration.clear))
            {
                Stop();
            }
            
            float d = distance ?? (configuration ? configuration.LeavingDistance : KaijuLeavingMovement.DefaultDistance);
            KaijuFleeMovement movement = KaijuFleeMovement.Get(this, target, d, weight ?? (configuration ? configuration.Weight : KaijuMovement.DefaultWeight));
            _movements.Add(movement);
            movement.Started();
            OnMovementStarted?.Invoke(movement);
            return movement;
        }
        
        /// <summary>
        /// Evade from a target.
        /// </summary>
        /// <param name="target">The target.</param>
        /// <param name="distance">At what distance from the target should the evade be considered successful.</param>
        /// <param name="weight">The weight of this movement.</param>
        /// <param name="clear">If this should clear all other current movement and become the only one the <see cref="KaijuAgent"/> is performing.</param>
        /// <returns>The pursue movement to the target.</returns>
        public KaijuEvadeMovement Evade(Vector2 target, float? distance = null, float? weight = null, bool? clear = null)
        {
            if (clear ?? (!configuration || configuration.clear))
            {
                Stop();
            }
            
            float d = distance ?? (configuration ? configuration.LeavingDistance : KaijuLeavingMovement.DefaultDistance);
            KaijuEvadeMovement movement = KaijuEvadeMovement.Get(this, target, d, weight ?? (configuration ? configuration.Weight : KaijuMovement.DefaultWeight));
            _movements.Add(movement);
            movement.Started();
            OnMovementStarted?.Invoke(movement);
            return movement;
        }
        
        /// <summary>
        /// Evade from a target.
        /// </summary>
        /// <param name="target">The target.</param>
        /// <param name="distance">At what distance from the target should the evade be considered successful.</param>
        /// <param name="weight">The weight of this movement.</param>
        /// <param name="clear">If this should clear all other current movement and become the only one the <see cref="KaijuAgent"/> is performing.</param>
        /// <returns>The evade movement to the target.</returns>
        public KaijuEvadeMovement Evade(Vector3 target, float? distance = null, float? weight = null, bool? clear = null)
        {
            if (clear ?? (!configuration || configuration.clear))
            {
                Stop();
            }
            
            float d = distance ?? (configuration ? configuration.LeavingDistance : KaijuLeavingMovement.DefaultDistance);
            KaijuEvadeMovement movement = KaijuEvadeMovement.Get(this, target, d, weight ?? (configuration ? configuration.Weight : KaijuMovement.DefaultWeight));
            _movements.Add(movement);
            movement.Started();
            OnMovementStarted?.Invoke(movement);
            return movement;
        }
        
        /// <summary>
        /// Evade from a target.
        /// </summary>
        /// <param name="target">The target.</param>
        /// <param name="distance">At what distance from the target should the evade be considered successful.</param>
        /// <param name="weight">The weight of this movement.</param>
        /// <param name="clear">If this should clear all other current movement and become the only one the <see cref="KaijuAgent"/> is performing.</param>
        /// <returns>The evade movement to the target.</returns>
        public KaijuEvadeMovement Evade([NotNull] GameObject target, float? distance = null, float? weight = null, bool? clear = null)
        {
            if (clear ?? (!configuration || configuration.clear))
            {
                Stop();
            }
            
            float d = distance ?? (configuration ? configuration.LeavingDistance : KaijuLeavingMovement.DefaultDistance);
            KaijuEvadeMovement movement = KaijuEvadeMovement.Get(this, target, d, weight ?? (configuration ? configuration.Weight : KaijuMovement.DefaultWeight));
            _movements.Add(movement);
            movement.Started();
            OnMovementStarted?.Invoke(movement);
            return movement;
        }
        
        /// <summary>
        /// Evade from a target.
        /// </summary>
        /// <param name="target">The target.</param>
        /// <param name="distance">At what distance from the target should the evade be considered successful.</param>
        /// <param name="weight">The weight of this movement.</param>
        /// <param name="clear">If this should clear all other current movement and become the only one the <see cref="KaijuAgent"/> is performing.</param>
        /// <returns>The evade movement to the target.</returns>
        public KaijuEvadeMovement Evade([NotNull] Component target, float? distance = null, float? weight = null, bool? clear = null)
        {
            if (clear ?? (!configuration || configuration.clear))
            {
                Stop();
            }
            
            float d = distance ?? (configuration ? configuration.LeavingDistance : KaijuLeavingMovement.DefaultDistance);
            KaijuEvadeMovement movement = KaijuEvadeMovement.Get(this, target, d, weight ?? (configuration ? configuration.Weight : KaijuMovement.DefaultWeight));
            _movements.Add(movement);
            movement.Started();
            OnMovementStarted?.Invoke(movement);
            return movement;
        }
        
        /// <summary>
        /// Wander.
        /// </summary>
        /// <param name="distance">How far out to generate the wander circle.</param>
        /// <param name="radius">The radius of the wander circle.</param>
        /// <param name="weight">The weight of this movement.</param>
        /// <param name="clear">If this should clear all other current movement and become the only one the <see cref="KaijuAgent"/> is performing.</param>
        /// <returns>The wander movement.</returns>
        public KaijuWanderMovement Wander(float? distance = null, float? radius = null, float? weight = null, bool? clear = null)
        {
            if (clear ?? (!configuration || configuration.clear))
            {
                Stop();
            }
            
            float d = distance ?? (configuration ? configuration.WanderDistance : KaijuWanderMovement.DefaultDistance);
            float r = radius ?? (configuration ? configuration.WanderRadius : KaijuWanderMovement.DefaultRadius);
            KaijuWanderMovement movement = KaijuWanderMovement.Get(this, d, r, weight ?? (configuration ? configuration.Weight : KaijuMovement.DefaultWeight));
            _movements.Add(movement);
            movement.Started();
            OnMovementStarted?.Invoke(movement);
            return movement;
        }
        
        /// <summary>
        /// Separate from other <see cref="KaijuAgent"/>s.
        /// </summary>
        /// <param name="distance">The distance to avoid other <see cref="KaijuAgent"/>s from.</param>
        /// <param name="coefficient">The coefficient to use for inverse square law separation. Zero will use linear separation.</param>
        /// <param name="collection">What types of <see cref="KaijuAgent"/>s to avoid.</param>
        /// <param name="weight">The weight of this movement.</param>
        /// <param name="clear">If this should clear all other current movement and become the only one the <see cref="KaijuAgent"/> is performing.</param>
        public KaijuSeparationMovement Separation(float? distance = null, float? coefficient = null, ICollection<uint> collection = null, float? weight = null, bool? clear = null)
        {
            if (clear ?? (!configuration || configuration.clear))
            {
                Stop();
            }
            
            float d = distance ?? (configuration ? configuration.SeparationDistance : KaijuSeparationMovement.DefaultDistance);
            float c = coefficient ?? (configuration ? configuration.SeparationCoefficient : KaijuSeparationMovement.DefaultCoefficient);
            KaijuSeparationMovement movement = KaijuSeparationMovement.Get(this, d, c, collection, weight ?? (configuration ? configuration.Weight : KaijuMovement.DefaultWeight));
            _movements.Add(movement);
            movement.Started();
            OnMovementStarted?.Invoke(movement);
            return movement;
        }
        
        /// <summary>
        /// Avoid obstacles.
        /// </summary>
        /// <param name="avoidance">The distance from a wall the <see cref="KaijuAgent"/> should maintain.</param>
        /// <param name="distance">The distance for rays.</param>
        /// <param name="sideDistance">The distance of the side rays. Zero or less will use the <see cref="KaijuObstacleAvoidanceMovement.Distance"/>.</param>
        /// <param name="angle">The angle for side rays.</param>
        /// <param name="height">The height offset for the rays.</param>
        /// <param name="horizontal">The horizontal shift for the side rays.</param>
        /// <param name="weight">The weight of this movement.</param>
        /// <param name="clear">If this should clear all other current movement and become the only one the <see cref="KaijuAgent"/> is performing.</param>
        public KaijuObstacleAvoidanceMovement ObstacleAvoidance(float? avoidance = null, float? distance = null, float? sideDistance = null, float? angle = null, float? height = null, float? horizontal = null, float? weight = null, bool? clear = null)
        {
            if (clear ?? (!configuration || configuration.clear))
            {
                Stop();
            }
            
            float av = avoidance ?? (configuration ? configuration.Avoidance : KaijuObstacleAvoidanceMovement.DefaultAvoidance);
            float d = distance ?? (configuration ? configuration.AvoidanceDistance : KaijuObstacleAvoidanceMovement.DefaultDistance);
            float s = sideDistance ?? (configuration ? configuration.AvoidanceSideDistance : KaijuObstacleAvoidanceMovement.DefaultSideDistance);
            float an = angle ?? (configuration ? configuration.avoidanceAngle : KaijuObstacleAvoidanceMovement.DefaultAngle);
            float he = height ?? (configuration ? configuration.avoidanceHeight : KaijuObstacleAvoidanceMovement.DefaultHeight);
            float ho = horizontal ?? (configuration ? configuration.avoidanceHorizontal : KaijuObstacleAvoidanceMovement.DefaultHorizontal);
            KaijuObstacleAvoidanceMovement movement = KaijuObstacleAvoidanceMovement.Get(this, av, d, s, an, he, ho, weight ?? (configuration ? configuration.Weight : KaijuMovement.DefaultWeight));
            _movements.Add(movement);
            movement.Started();
            OnMovementStarted?.Invoke(movement);
            return movement;
        }
        
        /// <summary>
        /// Path following.
        /// </summary>
        /// <param name="target">The position to pathfind to.</param>
        /// <param name="areaMask">A bitfield mask specifying which navigation mesh areas can be used for the path.</param>
        /// <param name="distance">The distance from the target to consider this movement done.</param>
        /// <param name="autoCalculateDistance">The distance to automatically recalculate the path from, with NULL not performing recalculations automatically.</param>
        /// <param name="collisionMask">The collision mask for string-pulling line-of-sight checks.</param>
        /// <param name="triggers">How line-of-sight checks should handle triggers.</param>
        /// <param name="weight">The weight of this movement.</param>
        /// <param name="clear">If this should clear all other current movement and become the only one the <see cref="KaijuAgent"/> is performing.</param>
        public KaijuPathFollowMovement PathFollow(Vector2 target, int areaMask = NavMesh.AllAreas, float? distance = null, float? autoCalculateDistance = 1, int collisionMask = KaijuMovementConfiguration.DefaultMask, QueryTriggerInteraction triggers = QueryTriggerInteraction.UseGlobal, float? weight = null, bool? clear = null)
        {
            if (clear ?? (!configuration || configuration.clear))
            {
                Stop();
            }
            
            float d = distance ?? (configuration ? configuration.ApproachingDistance : KaijuApproachingMovement.DefaultDistance);
            KaijuPathFollowMovement movement = KaijuPathFollowMovement.Get(this, target, areaMask, d, autoCalculateDistance, collisionMask, triggers, weight ?? (configuration ? configuration.Weight : KaijuMovement.DefaultWeight));
            _movements.Add(movement);
            movement.Started();
            OnMovementStarted?.Invoke(movement);
            return movement;
        }
        
        /// <summary>
        /// Path following.
        /// </summary>
        /// <param name="target">The position to pathfind to.</param>
        /// <param name="areaMask">A bitfield mask specifying which navigation mesh areas can be used for the path.</param>
        /// <param name="distance">The distance from the target to consider this movement done.</param>
        /// <param name="autoCalculateDistance">The distance to automatically recalculate the path from, with NULL not performing recalculations automatically.</param>
        /// <param name="collisionMask">The collision mask for string-pulling line-of-sight checks.</param>
        /// <param name="triggers">How line-of-sight checks should handle triggers.</param>
        /// <param name="weight">The weight of this movement.</param>
        /// <param name="clear">If this should clear all other current movement and become the only one the <see cref="KaijuAgent"/> is performing.</param>
        public KaijuPathFollowMovement PathFollow(Vector3 target, int areaMask = NavMesh.AllAreas, float? distance = null, float? autoCalculateDistance = 1, int collisionMask = KaijuMovementConfiguration.DefaultMask, QueryTriggerInteraction triggers = QueryTriggerInteraction.UseGlobal, float? weight = null, bool? clear = null)
        {
            if (clear ?? (!configuration || configuration.clear))
            {
                Stop();
            }
            
            float d = distance ?? (configuration ? configuration.ApproachingDistance : KaijuApproachingMovement.DefaultDistance);
            KaijuPathFollowMovement movement = KaijuPathFollowMovement.Get(this, target, areaMask, d, autoCalculateDistance, collisionMask, triggers, weight ?? (configuration ? configuration.Weight : KaijuMovement.DefaultWeight));
            _movements.Add(movement);
            movement.Started();
            OnMovementStarted?.Invoke(movement);
            return movement;
        }
        
        /// <summary>
        /// Path following.
        /// </summary>
        /// <param name="target">The position to pathfind to.</param>
        /// <param name="areaMask">A bitfield mask specifying which navigation mesh areas can be used for the path.</param>
        /// <param name="distance">The distance from the target to consider this movement done.</param>
        /// <param name="autoCalculateDistance">The distance to automatically recalculate the path from, with NULL not performing recalculations automatically.</param>
        /// <param name="collisionMask">The collision mask for string-pulling line-of-sight checks.</param>
        /// <param name="triggers">How line-of-sight checks should handle triggers.</param>
        /// <param name="weight">The weight of this movement.</param>
        /// <param name="clear">If this should clear all other current movement and become the only one the <see cref="KaijuAgent"/> is performing.</param>
        public KaijuPathFollowMovement PathFollow(Component target, int areaMask = NavMesh.AllAreas, float? distance = null, float? autoCalculateDistance = 1, int collisionMask = KaijuMovementConfiguration.DefaultMask, QueryTriggerInteraction triggers = QueryTriggerInteraction.UseGlobal, float? weight = null, bool? clear = null)
        {
            if (clear ?? (!configuration || configuration.clear))
            {
                Stop();
            }
            
            float d = distance ?? (configuration ? configuration.ApproachingDistance : KaijuApproachingMovement.DefaultDistance);
            KaijuPathFollowMovement movement = KaijuPathFollowMovement.Get(this, target, areaMask, d, autoCalculateDistance, collisionMask, triggers, weight ?? (configuration ? configuration.Weight : KaijuMovement.DefaultWeight));
            _movements.Add(movement);
            movement.Started();
            OnMovementStarted?.Invoke(movement);
            return movement;
        }
        
        /// <summary>
        /// Path following.
        /// </summary>
        /// <param name="target">The position to pathfind to.</param>
        /// <param name="areaMask">A bitfield mask specifying which navigation mesh areas can be used for the path.</param>
        /// <param name="distance">The distance from the target to consider this movement done.</param>
        /// <param name="autoCalculateDistance">The distance to automatically recalculate the path from, with NULL not performing recalculations automatically.</param>
        /// <param name="collisionMask">The collision mask for string-pulling line-of-sight checks.</param>
        /// <param name="triggers">How line-of-sight checks should handle triggers.</param>
        /// <param name="weight">The weight of this movement.</param>
        /// <param name="clear">If this should clear all other current movement and become the only one the <see cref="KaijuAgent"/> is performing.</param>
        public KaijuPathFollowMovement PathFollow(GameObject target, int areaMask = NavMesh.AllAreas, float? distance = null, float? autoCalculateDistance = 1, int collisionMask = KaijuMovementConfiguration.DefaultMask, QueryTriggerInteraction triggers = QueryTriggerInteraction.UseGlobal, float? weight = null, bool? clear = null)
        {
            if (clear ?? (!configuration || configuration.clear))
            {
                Stop();
            }
            
            float d = distance ?? (configuration ? configuration.ApproachingDistance : KaijuApproachingMovement.DefaultDistance);
            KaijuPathFollowMovement movement = KaijuPathFollowMovement.Get(this, target, areaMask, d, autoCalculateDistance, collisionMask, triggers, weight ?? (configuration ? configuration.Weight : KaijuMovement.DefaultWeight));
            _movements.Add(movement);
            movement.Started();
            OnMovementStarted?.Invoke(movement);
            return movement;
        }
        
        /// <summary>
        /// Path following.
        /// </summary>
        /// <param name="target">The position to pathfind to.</param>
        /// <param name="filter">Filter for the navigation calculations.</param>
        /// <param name="distance">The distance from the target to consider this movement done.</param>
        /// <param name="autoCalculateDistance">The distance to automatically recalculate the path from, with NULL not performing recalculations automatically.</param>
        /// <param name="collisionMask">The collision mask for string-pulling line-of-sight checks.</param>
        /// <param name="triggers">How line-of-sight checks should handle triggers.</param>
        /// <param name="weight">The weight of this movement.</param>
        /// <param name="clear">If this should clear all other current movement and become the only one the <see cref="KaijuAgent"/> is performing.</param>
        public KaijuPathFollowMovement PathFollow(Vector2 target, NavMeshQueryFilter filter, float? distance = null, float? autoCalculateDistance = 1, int collisionMask = KaijuMovementConfiguration.DefaultMask, QueryTriggerInteraction triggers = QueryTriggerInteraction.UseGlobal, float? weight = null, bool? clear = null)
        {
            if (clear ?? (!configuration || configuration.clear))
            {
                Stop();
            }
            
            float d = distance ?? (configuration ? configuration.ApproachingDistance : KaijuApproachingMovement.DefaultDistance);
            KaijuPathFollowMovement movement = KaijuPathFollowMovement.Get(this, target, filter, d, autoCalculateDistance, collisionMask, triggers, weight ?? (configuration ? configuration.Weight : KaijuMovement.DefaultWeight));
            _movements.Add(movement);
            movement.Started();
            OnMovementStarted?.Invoke(movement);
            return movement;
        }
        
        /// <summary>
        /// Path following.
        /// </summary>
        /// <param name="target">The position to pathfind to.</param>
        /// <param name="filter">Filter for the navigation calculations.</param>
        /// <param name="distance">The distance from the target to consider this movement done.</param>
        /// <param name="autoCalculateDistance">The distance to automatically recalculate the path from, with NULL not performing recalculations automatically.</param>
        /// <param name="collisionMask">The collision mask for string-pulling line-of-sight checks.</param>
        /// <param name="triggers">How line-of-sight checks should handle triggers.</param>
        /// <param name="weight">The weight of this movement.</param>
        /// <param name="clear">If this should clear all other current movement and become the only one the <see cref="KaijuAgent"/> is performing.</param>
        public KaijuPathFollowMovement PathFollow(Vector3 target, NavMeshQueryFilter filter, float? distance = null, float? autoCalculateDistance = 1, int collisionMask = KaijuMovementConfiguration.DefaultMask, QueryTriggerInteraction triggers = QueryTriggerInteraction.UseGlobal, float? weight = null, bool? clear = null)
        {
            if (clear ?? (!configuration || configuration.clear))
            {
                Stop();
            }
            
            float d = distance ?? (configuration ? configuration.ApproachingDistance : KaijuApproachingMovement.DefaultDistance);
            KaijuPathFollowMovement movement = KaijuPathFollowMovement.Get(this, target, filter, d, autoCalculateDistance, collisionMask, triggers, weight ?? (configuration ? configuration.Weight : KaijuMovement.DefaultWeight));
            _movements.Add(movement);
            movement.Started();
            OnMovementStarted?.Invoke(movement);
            return movement;
        }
        
        /// <summary>
        /// Path following.
        /// </summary>
        /// <param name="target">The position to pathfind to.</param>
        /// <param name="filter">Filter for the navigation calculations.</param>
        /// <param name="distance">The distance from the target to consider this movement done.</param>
        /// <param name="autoCalculateDistance">The distance to automatically recalculate the path from, with NULL not performing recalculations automatically.</param>
        /// <param name="collisionMask">The collision mask for string-pulling line-of-sight checks.</param>
        /// <param name="triggers">How line-of-sight checks should handle triggers.</param>
        /// <param name="weight">The weight of this movement.</param>
        /// <param name="clear">If this should clear all other current movement and become the only one the <see cref="KaijuAgent"/> is performing.</param>
        public KaijuPathFollowMovement PathFollow(Component target, NavMeshQueryFilter filter, float? distance = null, float? autoCalculateDistance = 1, int collisionMask = KaijuMovementConfiguration.DefaultMask, QueryTriggerInteraction triggers = QueryTriggerInteraction.UseGlobal, float? weight = null, bool? clear = null)
        {
            if (clear ?? (!configuration || configuration.clear))
            {
                Stop();
            }
            
            float d = distance ?? (configuration ? configuration.ApproachingDistance : KaijuApproachingMovement.DefaultDistance);
            KaijuPathFollowMovement movement = KaijuPathFollowMovement.Get(this, target, filter, d, autoCalculateDistance, collisionMask, triggers, weight ?? (configuration ? configuration.Weight : KaijuMovement.DefaultWeight));
            _movements.Add(movement);
            movement.Started();
            OnMovementStarted?.Invoke(movement);
            return movement;
        }
        
        /// <summary>
        /// Path following.
        /// </summary>
        /// <param name="target">The position to pathfind to.</param>
        /// <param name="filter">Filter for the navigation calculations.</param>
        /// <param name="distance">The distance from the target to consider this movement done.</param>
        /// <param name="autoCalculateDistance">The distance to automatically recalculate the path from, with NULL not performing recalculations automatically.</param>
        /// <param name="collisionMask">The collision mask for string-pulling line-of-sight checks.</param>
        /// <param name="triggers">How line-of-sight checks should handle triggers.</param>
        /// <param name="weight">The weight of this movement.</param>
        /// <param name="clear">If this should clear all other current movement and become the only one the <see cref="KaijuAgent"/> is performing.</param>
        public KaijuPathFollowMovement PathFollow(GameObject target, NavMeshQueryFilter filter, float? distance = null, float? autoCalculateDistance = 1, int collisionMask = KaijuMovementConfiguration.DefaultMask, QueryTriggerInteraction triggers = QueryTriggerInteraction.UseGlobal, float? weight = null, bool? clear = null)
        {
            if (clear ?? (!configuration || configuration.clear))
            {
                Stop();
            }
            
            float d = distance ?? (configuration ? configuration.ApproachingDistance : KaijuApproachingMovement.DefaultDistance);
            KaijuPathFollowMovement movement = KaijuPathFollowMovement.Get(this, target, filter, d, autoCalculateDistance, collisionMask, triggers, weight ?? (configuration ? configuration.Weight : KaijuMovement.DefaultWeight));
            _movements.Add(movement);
            movement.Started();
            OnMovementStarted?.Invoke(movement);
            return movement;
        }
#if UNITY_EDITOR
        /// <summary>
        /// Editor-only function that Unity calls when the script is loaded or a value changes in the Inspector.
        /// </summary>
        protected virtual void OnValidate()
        {
            // Validate all identifiers when playing.
            if (Application.isPlaying)
            {
                KaijuAgentsManager.EditorValidateIdentifiers(this);
            }
            
            Setup();
        }
        
        /// <summary>
        /// Visualize this <see cref="KaijuAgent"/> in the editor. There is no point in manually calling this.
        /// </summary>
        /// <param name="text">If the text for this <see cref="KaijuAgent"/> should be visualized.</param>
        public void EditorVisualize(bool text)
        {
            Vector3 p = transform.position;
            
            // If the <see cref="KaijuAgent"/> is moving or has an explicit looking target, it has some visuals of its own.
            bool moving = Velocity != Vector2.zero;
            Vector3? v = LookVector3;
            if (moving || v.HasValue)
            {
                Handles.color = KaijuAgentsManager.EditorAgentColor;
            }
            
            // Draw the movement vector.
            if (moving)
            {
                Handles.DrawLine(p, p + Velocity3.normalized);
            }
            
            if (text)
            {
                KaijuAgentsManager.EditorLabel(p, name, KaijuAgentsManager.EditorAgentColor);
            }
            
            // Show where the <see cref="KaijuAgent"/> is looking.
            if (v.HasValue)
            {
                Handles.DrawLine(p, v.Value);
            }
            
            // Visualize all movements.
            foreach (KaijuMovement movement in _movements)
            {
                movement.EditorVisualize(p);
            }
            
            // Visualize all <see cref="KaijuSensor"/>s.
            foreach (KaijuSensor sensor in _sensors)
            {
                sensor.EditorVisualize(p);
            }
            
            // Visualize all <see cref="KaijuActuator"/>s.
            foreach (KaijuActuator actuator in _actuators)
            {
                actuator.EditorVisualize(p);
            }
        }
#endif
        /// <summary>
        /// Perform <see cref="KaijuAgent"/> movement. There is no point in manually calling this.
        /// </summary>
        /// <param name="delta">The time step.</param>
        public abstract void Move(float delta);
        
        /// <summary>
        /// Get a <see cref="KaijuSensor"/> of a given type.
        /// </summary>
        /// <param name="ignore">The optional set of <see cref="KaijuSensor"/>s to ignore from this search, meaning only a <see cref="KaijuSensor"/> not in this set can be returned.</param>
        /// <param name="automatic">If you also want to allow the return of automatic <see cref="KaijuSensor"/>s, which are automatically run in <see cref="SenseAutomatic"/>.</param>
        /// <typeparam name="T">The type of <see cref="KaijuSensor"/>.</typeparam>
        /// <returns>The first <see cref="KaijuSensor"/> found of the given type or NULL if there are none found.</returns>
        public T GetSensor<T>(ISet<T> ignore = null, bool automatic = true) where T : KaijuSensor
        {
            // Use an explicit type to only run exact matches.
            Type type = typeof(T);
            
            foreach (KaijuSensor sensor in _sensors)
            {
                if ((automatic || !sensor.automatic) && sensor.GetType() == type && sensor is T cast && (ignore == null || !ignore.Contains(cast)))
                {
                    return cast;
                }
            }
            
            return null;
        }
        
        /// <summary>
        /// Get all <see cref="KaijuSensor"/> of a given type.
        /// </summary>
        /// <param name="automatic">If you also want to allow the return of automatic <see cref="KaijuSensor"/>s, which are automatically run in <see cref="SenseAutomatic"/>.</param>
        /// <typeparam name="T">The type of <see cref="KaijuSensor"/>.</typeparam>
        /// <returns>The set of <see cref="KaijuSensor"/>s found.</returns>
        public HashSet<T> GetSensors<T>(bool automatic = true) where T : KaijuSensor
        {
            HashSet<T> sensors = new();
            GetSensors(sensors, automatic);
            return sensors;
        }
        
        /// <summary>
        /// Get all <see cref="KaijuSensor"/> of a given type.
        /// </summary>
        /// <param name="sensors">The set of <see cref="KaijuSensor"/>s to add the found <see cref="KaijuSensor"/>s to. If you wish to have this cleared, you must manually do so before.</param>
        /// <param name="automatic">If you also want to allow the return of automatic <see cref="KaijuSensor"/>s, which are automatically run in <see cref="SenseAutomatic"/>.</param>
        /// <typeparam name="T">The type of <see cref="KaijuSensor"/>.</typeparam>
        /// <returns>The number of <see cref="KaijuSensor"/>s added to the set.</returns>
        public int GetSensors<T>([NotNull] ISet<T> sensors, bool automatic = true) where T : KaijuSensor
        {
            // Use an explicit type to only run exact matches.
            Type type = typeof(T);
            int count = 0;
            
            foreach (KaijuSensor sensor in _sensors)
            {
                if ((automatic || !sensor.automatic) && sensor.GetType() == type && sensor is T cast && sensors.Add(cast))
                {
                    count++;
                }
            }
            
            return count;
        }
        
        /// <summary>
        /// Get a <see cref="KaijuActuator"/> of a given type.
        /// </summary>
        /// <param name="ignore">The optional set of <see cref="KaijuActuator"/>s to ignore from this search, meaning only a <see cref="KaijuActuator"/> not in this set can be returned.</param>
        /// <typeparam name="T">The type of <see cref="KaijuActuator"/>.</typeparam>
        /// <returns>The first <see cref="KaijuActuator"/> found of the given type or NULL if there are none found.</returns>
        public T GetActuator<T>(ISet<T> ignore = null) where T : KaijuActuator
        {
            // Use an explicit type to only run exact matches.
            Type type = typeof(T);
            
            foreach (KaijuActuator actuator in _actuators)
            {
                if (actuator.GetType() == type && actuator is T cast && (ignore == null || !ignore.Contains(cast)))
                {
                    return cast;
                }
            }
            
            return null;
        }
        
        /// <summary>
        /// Get all <see cref="KaijuActuator"/> of a given type.
        /// </summary>
        /// <typeparam name="T">The type of <see cref="KaijuActuator"/>.</typeparam>
        /// <returns>The set of <see cref="KaijuActuator"/>s found.</returns>
        public HashSet<T> GetActuators<T>() where T : KaijuActuator
        {
            HashSet<T> actuators = new();
            GetActuators(actuators);
            return actuators;
        }
        
        /// <summary>
        /// Get all <see cref="KaijuActuator"/> of a given type.
        /// </summary>
        /// <param name="actuators">The set of <see cref="KaijuActuator"/>s to add the found <see cref="KaijuActuator"/>s to. If you wish to have this cleared, you must manually do so before.</param>
        /// <typeparam name="T">The type of <see cref="KaijuActuator"/>.</typeparam>
        /// <returns>The number of <see cref="KaijuActuator"/>s added to the set.</returns>
        public int GetActuators<T>([NotNull] ISet<T> actuators) where T : KaijuActuator
        {
            // Use an explicit type to only run exact matches.
            Type type = typeof(T);
            int count = 0;
            
            foreach (KaijuActuator actuator in _actuators)
            {
                if (actuator.GetType() == type && actuator is T cast && actuators.Add(cast))
                {
                    count++;
                }
            }
            
            return count;
        }
        
        /// <summary>
        /// Manually run all <see cref="KaijuSensor"/>s of a type attached to this <see cref="KaijuAgent"/>.
        /// </summary>
        /// <param name="sensors">The optional set of <see cref="KaijuSensor"/>s to add the executed <see cref="KaijuSensor"/>s to. If you wish to have this cleared, you must manually do so before.</param>
        /// <param name="automatic">If you also want to run automatic <see cref="KaijuSensor"/>s, which are automatically run in <see cref="SenseAutomatic"/>.</param>
        /// <typeparam name="T">The type of <see cref="KaijuSensor"/>.</typeparam>
        /// <returns>The number of <see cref="KaijuSensor"/>s which were run.</returns>
        public int Sense<T>(ICollection<T> sensors = null, bool automatic = false) where T : KaijuSensor
        {
            // Use an explicit type to only run exact matches.
            Type type = typeof(T);
            int count = 0;
            
            foreach (KaijuSensor sensor in _sensors)
            {
                if ((!automatic && sensor.automatic) || sensor.GetType() != type || sensor is not T cast)
                {
                    continue;
                }
                
                cast.Sense();
                sensors?.Add(cast);
                count++;
            }
            
            return count;
        }
        
        /// <summary>
        /// Execute all automatically-running <see cref="KaijuSensor"/>s. There is no point in manually calling this.
        /// </summary>
        public void SenseAutomatic()
        {
            foreach (KaijuSensor sensor in _sensors)
            {
                if (sensor.automatic)
                {
                    sensor.Sense();
                }
            }
            
            OnAutomaticSense?.Invoke();
            OnAutomaticSenseGlobal?.Invoke(this);
        }
        
        /// <summary>
        /// Called by a <see cref="KaijuSensor"/> when it has been run. There is no point in manually calling this.
        /// </summary>
        /// <param name="sensor">The <see cref="KaijuSensor"/> which has been run.</param>
        public void SensorRun([NotNull] KaijuSensor sensor)
        {
            OnSense?.Invoke(sensor);
        }
        
        /// <summary>
        /// Execute all <see cref="KaijuActuator"/>s. There is no point in manually calling this.
        /// </summary>
        public void Act()
        {
            foreach (KaijuActuator actuator in _actuators)
            {
                actuator.Handle();
            }
        }
        
        /// <summary>
        /// Allow for <see cref="KaijuActuator"/>s to trigger that they have started. There is no point in manually calling this.
        /// </summary>
        /// <param name="actuator">The <see cref="KaijuActuator"/>.</param>
        public void ActuatorStarted(KaijuActuator actuator)
        {
            OnActuatorStarted?.Invoke(actuator);
        }
        
        /// <summary>
        /// Allow for <see cref="KaijuActuator"/>s to trigger that they are executing. There is no point in manually calling this.
        /// </summary>
        /// <param name="actuator">The <see cref="KaijuActuator"/>.</param>
        public void ActuatorExecuting(KaijuActuator actuator)
        {
            OnActuatorExecuting?.Invoke(actuator);
        }
        
        /// <summary>
        /// Allow for <see cref="KaijuActuator"/>s to trigger that they are done. There is no point in manually calling this.
        /// </summary>
        /// <param name="actuator">The <see cref="KaijuActuator"/>.</param>
        public void ActuatorDone(KaijuActuator actuator)
        {
            OnActuatorDone?.Invoke(actuator);
        }
        
        /// <summary>
        /// Allow for <see cref="KaijuActuator"/>s to trigger that they were interrupted. There is no point in manually calling this.
        /// </summary>
        /// <param name="actuator">The <see cref="KaijuActuator"/>.</param>
        public void ActuatorInterrupted(KaijuActuator actuator)
        {
            OnActuatorInterrupted?.Invoke(actuator);
        }
        
        /// <summary>
        /// Allow for <see cref="KaijuActuator"/>s to trigger that they failed. There is no point in manually calling this.
        /// </summary>
        /// <param name="actuator">The <see cref="KaijuActuator"/>.</param>
        public void ActuatorFailed(KaijuActuator actuator)
        {
            OnActuatorFailed?.Invoke(actuator);
        }
        
        /// <summary>
        /// Handle look actions. There is no point in manually calling this.
        /// </summary>
        /// <param name="delta">The time step.</param>
        public void Look(float delta)
        {
            // See if there is an explicit target.
            Vector3? v = LookVector3;
            Transform t = transform;
            
            // If not, see if we are moving towards anything.
            Vector3 target;
            if (!v.HasValue)
            {
                // If we were looking but now are not, indicate this has changed.
                if (_wasLooking)
                {
                    _wasLooking = false;
                    OnLookTarget?.Invoke();
                    OnLookTargetGlobal?.Invoke(this);
                }
                
                // If we don't want to automatically look or there is no movement, stop.
                if (!AutoRotate || Velocity == Vector2.zero)
                {
                    return;
                }
                
                target = t.position + Velocity3.normalized;
            }
            else
            {
                // Indicate we have a look target.
                _wasLooking = true;
                
                // The rotation is only along the Y axis.
                target = new(v.Value.x, t.position.y, v.Value.z);
            }
            
            // If the look target is our current location, there is nothing to do.
            if (target == t.position)
            {
                return;
            }
            
            // Get the rotation.
            Vector3 rotation = Vector3.RotateTowards(t.forward, target - t.position, (lookSpeed > 0 ? lookSpeed * Mathf.Deg2Rad : Mathf.Infinity) * delta, 0.0f);
            if (rotation != Vector3.zero && !float.IsNaN(rotation.x) && !float.IsNaN(rotation.y) && !float.IsNaN(rotation.z))
            {
                t.rotation = Quaternion.LookRotation(rotation);
            }
        }
        
        /// <summary>
        /// Get a description of the object.
        /// </summary>
        /// <returns>A description of the object.</returns>
        public override string ToString()
        {
            return $"Kaiju Agent {name} - {(isActiveAndEnabled ? "Active" : "Inactive")} - Velocity: {Velocity} - Move Speed: {MoveSpeed} - Move Acceleration: {MoveAcceleration} - Look Speed: {LookSpeed}";
        }
        
        /// <summary>
        /// Implicit conversion from a <see href="https://docs.unity3d.com/Manual/class-GameObject.html">GameObject</see>.
        /// </summary>
        /// <param name="o">The <see href="https://docs.unity3d.com/Manual/class-GameObject.html">GameObject</see>.</param>
        /// <returns>The <see cref="KaijuAgent"/> attached to the <see href="https://docs.unity3d.com/Manual/class-GameObject.html">GameObject</see> if there was one.</returns>
        public static implicit operator KaijuAgent([NotNull] GameObject o) => o.GetComponent<KaijuAgent>();
        
        /// <summary>
        /// Implicit conversion from a <see href="https://docs.unity3d.com/Manual/class-transform.html">transform</see>.
        /// </summary>
        /// <param name="t">The <see href="https://docs.unity3d.com/Manual/class-transform.html">transform</see>.</param>
        /// <returns>The <see cref="KaijuAgent"/> attached to the <see href="https://docs.unity3d.com/Manual/class-transform.html">transform</see> if there was one.</returns>
        public static implicit operator KaijuAgent([NotNull] Transform t) => t.GetComponent<KaijuAgent>();
        
        /// <summary>
        /// Implicit conversion to a <see cref="KaijuController"/>.
        /// </summary>
        /// <param name="a">The <see cref="KaijuAgent"/>.</param>
        /// <returns>The <see cref="KaijuController"/> attached to the <see cref="KaijuAgent"/> if there was one.</returns>
        public static implicit operator KaijuController([NotNull] KaijuAgent a) => a.GetComponent<KaijuController>();
        
        /// <summary>
        /// Implicit conversion to a <see cref="KaijuGlobalController"/>.
        /// </summary>
        /// <param name="a">The <see cref="KaijuAgent"/>.</param>
        /// <returns>The <see cref="KaijuGlobalController"/> attached to the <see cref="KaijuAgent"/> if there was one.</returns>
        public static implicit operator KaijuGlobalController([NotNull] KaijuAgent a) => a.GetComponent<KaijuGlobalController>();
        
        /// <summary>
        /// Implicit conversion to a short integer based on the number of <see cref="Movements"/>.
        /// </summary>
        /// <param name="a">The <see cref="KaijuAgent"/>.</param>
        /// <returns>The number of <see cref="Movements"/>.</returns>
        public static implicit operator short([NotNull] KaijuAgent a) => (short)a._movements.Count;
        
        /// <summary>
        /// Implicit conversion to a nullable short integer based on the number of <see cref="Movements"/>.
        /// </summary>
        /// <param name="a">The <see cref="KaijuAgent"/>.</param>
        /// <returns>The number of <see cref="Movements"/>.</returns>
        public static implicit operator short?([NotNull] KaijuAgent a) => (short?)a._movements.Count;
        
        /// <summary>
        /// Implicit conversion to an unsigned short integer based on the number of <see cref="Movements"/>.
        /// </summary>
        /// <param name="a">The <see cref="KaijuAgent"/>.</param>
        /// <returns>The number of <see cref="Movements"/>.</returns>
        public static implicit operator ushort([NotNull] KaijuAgent a) => (ushort)a._movements.Count;
        
        /// <summary>
        /// Implicit conversion to a nullable unsigned short integer based on the number of <see cref="Movements"/>.
        /// </summary>
        /// <param name="a">The <see cref="KaijuAgent"/>.</param>
        /// <returns>The number of <see cref="Movements"/>.</returns>
        public static implicit operator ushort?([NotNull] KaijuAgent a) => (ushort?)a._movements.Count;
        
        /// <summary>
        /// Implicit conversion to an integer based on the number of <see cref="Movements"/>.
        /// </summary>
        /// <param name="a">The <see cref="KaijuAgent"/>.</param>
        /// <returns>The number of <see cref="Movements"/>.</returns>
        public static implicit operator int([NotNull] KaijuAgent a) => a._movements.Count;
        
        /// <summary>
        /// Implicit conversion to a nullable integer based on the number of <see cref="Movements"/>.
        /// </summary>
        /// <param name="a">The <see cref="KaijuAgent"/>.</param>
        /// <returns>The number of <see cref="Movements"/>.</returns>
        public static implicit operator int?([NotNull] KaijuAgent a) => a._movements.Count;
        
        /// <summary>
        /// Implicit conversion to an unsigned integer based on the number of <see cref="Movements"/>.
        /// </summary>
        /// <param name="a">The <see cref="KaijuAgent"/>.</param>
        /// <returns>The number of <see cref="Movements"/>.</returns>
        public static implicit operator uint([NotNull] KaijuAgent a) => (uint)a._movements.Count;
        
        /// <summary>
        /// Implicit conversion to a nullable unsigned integer based on the number of <see cref="Movements"/>.
        /// </summary>
        /// <param name="a">The <see cref="KaijuAgent"/>.</param>
        /// <returns>The number of <see cref="Movements"/>.</returns>
        public static implicit operator uint?([NotNull] KaijuAgent a) => (uint?)a._movements.Count;
        
        /// <summary>
        /// Implicit conversion to a long integer based on the number of <see cref="Movements"/>.
        /// </summary>
        /// <param name="a">The <see cref="KaijuAgent"/>.</param>
        /// <returns>The number of <see cref="Movements"/>.</returns>
        public static implicit operator long([NotNull] KaijuAgent a) => a._movements.Count;
        
        /// <summary>
        /// Implicit conversion to a nullable long integer based on the number of <see cref="Movements"/>.
        /// </summary>
        /// <param name="a">The <see cref="KaijuAgent"/>.</param>
        /// <returns>The number of <see cref="Movements"/>.</returns>
        public static implicit operator long?([NotNull] KaijuAgent a) => a._movements.Count;
        
        /// <summary>
        /// Implicit conversion to an unsigned long integer based on the number of <see cref="Movements"/>.
        /// </summary>
        /// <param name="a">The <see cref="KaijuAgent"/>.</param>
        /// <returns>The number of <see cref="Movements"/>.</returns>
        public static implicit operator ulong([NotNull] KaijuAgent a) => (ulong)a._movements.Count;
        
        /// <summary>
        /// Implicit conversion to a nullable unsigned long integer based on the number of <see cref="Movements"/>.
        /// </summary>
        /// <param name="a">The <see cref="KaijuAgent"/>.</param>
        /// <returns>The number of <see cref="Movements"/>.</returns>
        public static implicit operator ulong?([NotNull] KaijuAgent a) => (ulong?)a._movements.Count;
    }
}