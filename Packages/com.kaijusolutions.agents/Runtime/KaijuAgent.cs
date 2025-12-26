using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using KaijuSolutions.Agents.Movement;
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif
namespace KaijuSolutions.Agents
{
    /// <summary>
    /// Base Kaiju Agent class.
    /// </summary>
    [DisallowMultipleComponent]
#if UNITY_EDITOR
    [SelectionBase]
    [Icon("Packages/com.kaijusolutions.agents/Editor/Icon.png")]
    [HelpURL("https://agents.kaijusolutions.ca/manual/getting-started.html")]
#endif
    public abstract class KaijuAgent : MonoBehaviour
    {
        /// <summary>
        /// Movement speed changed callback.
        /// </summary>
        public static event AgentAction OnMoveSpeed;
        
        /// <summary>
        /// Movement acceleration changed callback.
        /// </summary>
        public static event AgentAction OnMoveAcceleration;
        
        /// <summary>
        /// Look speed changed callback.
        /// </summary>
        public static event AgentAction OnLookSpeed;
        
        /// <summary>
        /// Autorotation changed callback.
        /// </summary>
        public static event AgentAction OnAutoRotate;
        
        /// <summary>
        /// Callback for when the look target has been set.
        /// </summary>
        public static event AgentAction OnLookTarget;
        
        /// <summary>
        /// Callback for when the position has been explicitly set.
        /// </summary>
        public static event AgentAction OnSetPosition;
        
        /// <summary>
        /// Callback for when the orientation has been explicitly set.
        /// </summary>
        public static event AgentAction OnSetOrientation;
        
        /// <summary>
        /// Callback for when this agent has calculated movement.
        /// </summary>
        public static event AgentAction OnMove;
        
        /// <summary>
        /// Callback for when this has finishing becoming enabled.
        /// </summary>
        public static event AgentAction OnEnabled;
        
        /// <summary>
        /// Callback for when this has finishing becoming disabled.
        /// </summary>
        public static event AgentAction OnDisabled;
        
        /// <summary>
        /// Callback for when this has finishing becoming destroyed.
        /// </summary>
        public static event AgentAction OnDestroyed;
        
        /// <summary>
        /// Callback for when a movement has started.
        /// </summary>
        public static event AgentMovementAction OnMovementStarted;
        
        /// <summary>
        /// Callback for when a movement has stopped.
        /// </summary>
        public static event AgentMovementAction OnMovementStopped;
        
        /// <summary>
        /// Callback for when a movement has ben performed.
        /// </summary>
        public static event AgentMovementAction OnMovementPerformed;
        
        /// <summary>
        /// If this agent should move with the physics system.
        /// </summary>
        public virtual bool PhysicsAgent => false;
        
        /// <summary>
        /// The maximum move speed of the agent in units per second.
        /// </summary>
        public float MoveSpeed
        {
            get => moveSpeed;
            set
            {
                moveSpeed = Mathf.Max(value, 0);
                ChangedMoveSpeed();
                OnMoveSpeed?.Invoke(this);
            }
        }
        
        /// <summary>
        /// The maximum move speed of the agent in units per second. Note that modifying this at runtime via the inspector will not trigger the callback.
        /// </summary>
#if UNITY_EDITOR
        [Tooltip("The maximum move speed of the agent in units per second. Note that modifying this at runtime via the inspector will not trigger the callback.")]
#endif
        [Min(0)]
        [SerializeField]
        private float moveSpeed = 10f;
        
        /// <summary>
        /// Callback when the movement speed has changed.
        /// </summary>
        protected virtual void ChangedMoveSpeed() { }
        
        /// <summary>
        /// The maximum move acceleration of the agent in units per second. Setting to zero yields instant acceleration.
        /// </summary>
        public float MoveAcceleration
        {
            get => moveAcceleration;
            set
            {
                moveAcceleration = Mathf.Max(value, 0);
                ChangedMoveAcceleration();
                OnMoveAcceleration?.Invoke(this);
            }
        }
        
        /// <summary>
        /// The maximum move acceleration of the agent in units per second. Setting to zero yields instant acceleration. Note that modifying this at runtime via the inspector will not trigger the callback.
        /// </summary>
#if UNITY_EDITOR
        [Tooltip("The maximum move acceleration of the agent in units per second. Setting to zero yields instant acceleration. Note that modifying this at runtime via the inspector will not trigger the callback.")]
#endif
        [Min(0)]
        [SerializeField]
        private float moveAcceleration;
        
        /// <summary>
        /// Callback when the movement acceleration has changed.
        /// </summary>
        protected virtual void ChangedMoveAcceleration() { }
        
        /// <summary>
        /// The maximum look speed of the agent in degrees per second.
        /// </summary>
        public float LookSpeed
        {
            get => lookSpeed;
            set
            {
                lookSpeed = Mathf.Max(value, 0);
                ChangedLookSpeed();
                OnLookSpeed?.Invoke(this);
            }
        }
        
        /// <summary>
        /// The maximum look speed of the agent in degrees per second. Note that modifying this at runtime via the inspector will not trigger the callback.
        /// </summary>
#if UNITY_EDITOR
        [Tooltip("The maximum look speed of the agent in degrees per second. Note that modifying this at runtime via the inspector will not trigger the callback.")]
#endif
        [Min(0)]
        [SerializeField]
        private float lookSpeed;
        
        /// <summary>
        /// Callback when the look speed has changed.
        /// </summary>
        protected virtual void ChangedLookSpeed() { }
        
        /// <summary>
        /// If the agent should automatically rotate towards where it is moving when no look target is set.
        /// </summary>
        public bool AutoRotate
        {
            get => autoRotate;
            set
            {
                autoRotate = value;
                ChangedAutoRotate();
                OnAutoRotate?.Invoke(this);
            }
        }
        
        /// <summary>
        /// If the agent should automatically rotate towards where it is moving when no look target is set. Note that modifying this at runtime via the inspector will not trigger the callback.
        /// </summary>
#if UNITY_EDITOR
        [Tooltip("If the agent should automatically rotate towards where it is moving when no look target is set. Note that modifying this at runtime via the inspector will not trigger the callback.")]
#endif
        [SerializeField]
        private bool autoRotate = true;
        
        /// <summary>
        /// Callback when the autorotate has changed.
        /// </summary>
        protected virtual void ChangedAutoRotate() { }
        
        /// <summary>
        /// Identifiers for this agent.
        /// </summary>
        public IReadOnlyList<uint> Identifiers => identifiers;
        
        /// <summary>
        /// Identifiers for this agent. Note that modifying this at runtime via the inspector will not trigger the callback.
        /// </summary>
#if UNITY_EDITOR
        [Tooltip("Identifiers for this agent. Note that modifying this at runtime via the inspector will not trigger the callback.")]
#endif
        [SerializeField]
        private List<uint> identifiers = new();
        
        /// <summary>
        /// Callback when identifiers have been updated.
        /// </summary>
        protected virtual void ChangedIdentifiers() { }
        
        /// <summary>
        /// The current velocity of the agent.
        /// </summary>
        public Vector2 Velocity { get; private set; }
        
        /// <summary>
        /// The current velocity of the agent.
        /// </summary>
        public Vector3 Velocity3 => new(Velocity.x, 0, Velocity.y);
        
        /// <summary>
        /// Get the forward direction of this agent.
        /// </summary>
        public Vector3 Forward => Velocity == Vector2.zero ? transform.forward : Velocity3;
        
        /// <summary>
        /// All movements the agent is currently performing.
        /// </summary>
        private readonly List<KaijuMovement> _movements = new();
        
        /// <summary>
        /// All movements the agent is currently performing.
        /// </summary>
        public IReadOnlyList<KaijuMovement> Movements => _movements.AsReadOnly();
        
        /// <summary>
        /// The total number movements the agent is currently performing.
        /// </summary>
        public int MovementsCount => _movements.Count;
        
        /// <summary>
        /// If there are any movements occuring.
        /// </summary>
        public bool Moving => isActiveAndEnabled && MovementsCount > 0;
        
        /// <summary>
        /// The vector to look at.
        /// </summary>
        private Vector2? _lookVector;
        
        /// <summary>
        /// The vector to look at.
        /// </summary>
        private Vector3? _lookVector3;
        
        /// <summary>
        /// The <see href="https://docs.unity3d.com/Manual/class-Transform.html">transform</see> to look at.
        /// </summary>
        private Transform _lookTransform;
        
        /// <summary>
        /// The vector to look at.
        /// </summary>
        public Vector2? LookVector
        {
            get
            {
                if (!_lookTransform)
                {
                    return _lookVector3.HasValue ? new(_lookVector3.Value.x, _lookVector3.Value.z) : _lookVector;
                }
                
                Vector3 p = _lookTransform.position;
                return new(p.x, p.z);
            }
            set
            {
                _lookVector = value;
                _lookVector3 = null;
                _lookTransform = null;
                OnLookTarget?.Invoke(this);
            }
        }
        
        /// <summary>
        /// The vector to look at.
        /// </summary>
        public Vector3? LookVector3
        {
            get => _lookTransform ? _lookTransform.position : _lookVector.HasValue ? new(_lookVector.Value.x, transform.position.y, _lookVector.Value.y) : _lookVector3;
            set
            {
                _lookVector3 = value;
                _lookVector = null;
                _lookTransform = null;
                OnLookTarget?.Invoke(this);
            }
        }
        
        /// <summary>
        /// The <see href="https://docs.unity3d.com/Manual/class-Transform.html">transform</see> to look at.
        /// </summary>
        public Transform LookTransform
        {
            get => _lookTransform;
            set
            {
                _lookTransform = value;
                _lookVector = null;
                _lookVector3 = null;
                OnLookTarget?.Invoke(this);
            }
        }
        
        /// <summary>
        /// The <see href="https://docs.unity3d.com/Manual/class-GameObject.html">GameObject</see> to look at.
        /// </summary>
        public GameObject LookGameObject
        {
            get => _lookTransform ? _lookTransform.gameObject : null;
            set
            {
                _lookTransform = value.transform;
                _lookVector = null;
                _lookVector3 = null;
                OnLookTarget?.Invoke(this);
            }
        }
        
        /// <summary>
        /// The agent to move in relation to.
        /// </summary>
        public KaijuAgent TargetAgent
        {
            get => _lookTransform ? _lookTransform.GetComponent<KaijuAgent>() : null;
            set => TargetComponent = value;
        }
        
        /// <summary>
        /// The component to look at.
        /// </summary>
        public Component TargetComponent
        {
            set
            {
                _lookTransform = value.transform;
                _lookVector = null;
                _lookVector3 = null;
                OnLookTarget?.Invoke(this);
            }
        }
        
        /// <summary>
        /// If the agent is currently looking at something.
        /// </summary>
        public bool Looking => LookVector.HasValue;
        
        /// <summary>
        /// Get the distance from the agent to the target which is being looked at.
        /// </summary>
        public float LookDistance
        {
            get
            {
                Vector3? v = LookVector3;
                if (!v.HasValue)
                {
                    return 0;
                }
                
                return Vector3.Distance(v.Value, transform.position);
            }
        }
        
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
        /// The position vector along the main XZ axis.
        /// </summary>
        public Vector2 Position
        {
            get
            {
                Vector3 p = transform.position;
                return new(p.x, p.z);
            }
            set
            {
                PreSetTransform();
                transform.position = new(value.x, 0, value.y);
                PostSetTransform();
                OnSetPosition?.Invoke(this);
            }
        }
        
        /// <summary>
        /// The position vector along all three axes.
        /// </summary>
        public Vector3 Position3
        {
            get => transform.position;
            set
            {
                PreSetTransform();
                transform.position = value;
                PostSetTransform();
                OnSetPosition?.Invoke(this);
            }
        }
        
        /// <summary>
        /// Callback before updating the transform.
        /// </summary>
        protected virtual void PreSetTransform() { }
        
        /// <summary>
        /// Callback after updating the transform.
        /// </summary>
        protected virtual void PostSetTransform() { }
        
        /// <summary>
        /// The angle the agent is rotated along the main Y axis.
        /// </summary>
        public float Orientation
        {
            get => transform.localEulerAngles.y;
            set
            {
                transform.localEulerAngles = new(0, value, 0);
                OnSetOrientation?.Invoke(this);
            }
        }
        
        /// <summary>
        /// Initialize the agent.
        /// </summary>
        public virtual void Setup() { }
        
        /// <summary>
        /// Calculate the velocity for the next update.
        /// <param name="delta">The time step.</param>
        /// </summary>
        public void CalculateVelocity(float delta)
        {
            // Start with no motion this frame.
            Vector2 velocity = Vector2.zero;
            Vector2 position = Position;
            
            // Go through all assigned movements.
            for (int i = 0; i < _movements.Count; i++)
            {
                // If the movement is done, remove it to the cache.
                if (_movements[i].Done())
                {
                    OnMovementStopped?.Invoke(this, _movements[i]);
                    _movements[i].Return();
                    _movements.RemoveAt(i--);
                    continue;
                }
                
                // Weight the movement.
                velocity += _movements[i].Move(position, delta) * _movements[i].Weight;
                OnMovementPerformed?.Invoke(this, _movements[i]);
            }
            
            // Clamp the movement velocity.
            if (velocity.sqrMagnitude > moveSpeed * moveSpeed)
            {
                velocity = velocity.normalized * moveSpeed;
            }
            
            // Set the updated velocity.
            Velocity = moveAcceleration > 0 ? Vector2.Lerp(Velocity, velocity, moveAcceleration * delta) : velocity;
            OnMove?.Invoke(this);
        }
        
        /// <summary>
        /// This function is called when the object becomes enabled and active.
        /// </summary>
        private void OnEnable()
        {
            KaijuAgentsManager.Register(this);
            OnEnabled?.Invoke(this);
        }
        
        /// <summary>
        /// This function is called when the behaviour becomes disabled.
        /// </summary>
        private void OnDisable()
        {
            Stop();
            StopLooking();
            ClearIdentifiers();
            Velocity = Vector2.zero;
            KaijuAgentsManager.Unregister(this);
            OnDisabled?.Invoke(this);
        }
        
        /// <summary>
        /// Destroying the attached Behaviour will result in the game or Scene receiving OnDestroy.
        /// </summary>
        private void OnDestroy()
        {
            // Unregister without caching.
            KaijuAgentsManager.Unregister(this, false);
            OnDestroyed?.Invoke(this);
        }
        
        /// <summary>
        /// Start is called on the frame when a script is enabled just before any of the Update methods are called the first time. This function can be a coroutine.
        /// </summary>
        private void Start()
        {
            Setup();
        }
        
        /// <summary>
        /// Spawn this agent if it is not currently spawned.
        /// </summary>
        public void Spawn()
        {
            gameObject.SetActive(true);
            enabled = true;
        }
        
        /// <summary>
        /// Despawn this agent.
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
        /// If this agent has an identifier.
        /// </summary>
        /// <param name="identifier">The identifier to check.</param>
        /// <returns>If this agent has the identifier.</returns>
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
        /// If this agent has any one of a set of identifiers.
        /// </summary>
        /// <param name="collection">The identifiers to check.</param>
        /// <returns>If this agent has any one of a set of identifiers.</returns>
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
        /// Add an identifier to this agent.
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
        /// Add identifiers to this agent.
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
        /// Remove an identifier from this agent.
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
        /// Remove identifiers from this agent.
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
        /// Set an identifier to this agent.
        /// </summary>
        /// <param name="identifier">The identifier to set.</param>
        public void SetIdentifier(uint identifier)
        {
            ClearIdentifiers();
            AddIdentifier(identifier);
        }
        
        /// <summary>
        /// If this agent has any one of a set of identifiers.
        /// </summary>
        /// <param name="collection">The identifiers to check.</param>
        /// <returns>If this agent has any one of a set of identifiers.</returns>
        public void SetIdentifiers(IEnumerable<uint> collection)
        {
            ClearIdentifiers();
            AddIdentifiers(collection);
        }
        
        /// <summary>
        /// Get the distance to a target.
        /// </summary>
        /// <param name="target">The target.</param>
        /// <returns>The distance to the target.</returns>
        public float Distance(Vector2 target)
        {
            Vector3 a = transform.position;
            return Vector2.Distance(new(a.x, a.z), target);
        }
        
        /// <summary>
        /// Get the distance to a target.
        /// </summary>
        /// <param name="target">The target.</param>
        /// <returns>The distance to the target.</returns>
        public float Distance(Vector3 target)
        {
            return Distance(new Vector2(target.x, target.z));
        }
        
        /// <summary>
        /// Get the distance to a target.
        /// </summary>
        /// <param name="target">The target.</param>
        /// <returns>The distance to the target.</returns>
        public float Distance([NotNull] GameObject target)
        {
            return Distance(target.transform.position);
        }
        
        /// <summary>
        /// Get the distance to a target.
        /// </summary>
        /// <param name="target">The target.</param>
        /// <returns>The distance to the target.</returns>
        public float Distance([NotNull] Component target)
        {
            return Distance(target.transform.position);
        }
        
        /// <summary>
        /// Get the distance to a target.
        /// </summary>
        /// <param name="target">The target.</param>
        /// <returns>The distance to the target.</returns>
        public float Distance([NotNull] KaijuAgent target)
        {
            return Distance(target.transform.position);
        }
        
        /// <summary>
        /// Get the distance to a target.
        /// </summary>
        /// <param name="target">The target.</param>
        /// <returns>The distance to the target.</returns>
        public float Distance3(Vector3 target)
        {
            Vector3 a = transform.position;
            return Vector3.Distance(a, target);
        }
        
        /// <summary>
        /// Get the distance to a target.
        /// </summary>
        /// <param name="target">The target.</param>
        /// <returns>The distance to the target.</returns>
        public float Distance3([NotNull] GameObject target)
        {
            return Distance3(target.transform.position);
        }
        
        /// <summary>
        /// Get the distance to a target.
        /// </summary>
        /// <param name="target">The target.</param>
        /// <returns>The distance to the target.</returns>
        public float Distance3([NotNull] Component target)
        {
            return Distance3(target.transform.position);
        }
        
        /// <summary>
        /// Get the distance to a target.
        /// </summary>
        /// <param name="target">The target.</param>
        /// <returns>The distance to the target.</returns>
        public float Distance3([NotNull] KaijuAgent target)
        {
            return Distance3(target.transform.position);
        }
        
        /// <summary>
        /// Get the direction to a target.
        /// </summary>
        /// <param name="target">The target.</param>
        /// <returns>The direction to a target.</returns>
        public Vector2 Direction(Vector2 target)
        {
            Vector3 a = transform.position;
            return target - new Vector2(a.x, a.z);
        }
        
        /// <summary>
        /// Get the direction to a target.
        /// </summary>
        /// <param name="target">The target.</param>
        /// <returns>The direction to a target.</returns>
        public Vector2 Direction(Vector3 target)
        {
            return Direction(new Vector2(target.x, target.z));
        }
        
        /// <summary>
        /// Get the direction to a target.
        /// </summary>
        /// <param name="target">The target.</param>
        /// <returns>The direction to a target.</returns>
        public Vector2 Direction([NotNull] GameObject target)
        {
            return Direction(target.transform.position);
        }
        
        /// <summary>
        /// Get the direction to a target.
        /// </summary>
        /// <param name="target">The target.</param>
        /// <returns>The direction to a target.</returns>
        public Vector2 Direction([NotNull] Component target)
        {
            return Direction(target.transform.position);
        }
        
        /// <summary>
        /// Get the direction to a target.
        /// </summary>
        /// <param name="target">The target.</param>
        /// <returns>The direction to a target.</returns>
        public Vector2 Direction([NotNull] KaijuAgent target)
        {
            return Direction(target.transform.position);
        }
        
        /// <summary>
        /// Get the direction to a target.
        /// </summary>
        /// <param name="target">The target.</param>
        /// <returns>The direction to a target.</returns>
        public Vector3 Direction3(Vector3 target)
        {
            return target - transform.position;
        }
        
        /// <summary>
        /// Get the direction to a target.
        /// </summary>
        /// <param name="target">The target.</param>
        /// <returns>The direction to a target.</returns>
        public Vector3 Direction3([NotNull] GameObject target)
        {
            return Direction3(target.transform.position);
        }
        
        /// <summary>
        /// Get the direction to a target.
        /// </summary>
        /// <param name="target">The target.</param>
        /// <returns>The direction to a target.</returns>
        public Vector3 Direction3([NotNull] Component target)
        {
            return Direction3(target.transform.position);
        }
        
        /// <summary>
        /// Get the direction to a target.
        /// </summary>
        /// <param name="target">The target.</param>
        /// <returns>The direction to a target.</returns>
        public Vector3 Direction3([NotNull] KaijuAgent target)
        {
            return Direction3(target.transform.position);
        }
        
        /// <summary>
        /// Get all agents within a distance to this agent.
        /// </summary>
        /// <param name="distance">The distance to detect agents within.</param>
        /// <param name="identifier">The identifier of the agents to get being within a distance to this agent.</param>
        /// <returns>All agents within a distance to this agent.</returns>
        public HashSet<KaijuAgent> Within(float distance, uint identifier)
        {
            return KaijuAgentsManager.Within(this, distance, identifier);
        }
        
        /// <summary>
        /// Get all agents within a distance this agent.
        /// </summary>
        /// <param name="distance">The distance to detect agents within.</param>
        /// <param name="collection">The identifiers of the agents to get being within a distance this agent.</param>
        /// <returns>All agents with a distance to this agent.</returns>
        public HashSet<KaijuAgent> Within(float distance, IEnumerable<uint> collection = null)
        {
            return KaijuAgentsManager.Within(this, distance, collection);
        }
        
        /// <summary>
        /// Get all agents within a distance to this agent. The agents are added to the within parameter. It is up to you to clear this prior, as otherwise this will add entries.
        /// </summary>
        /// <param name="distance">The distance to detect agents within.</param>
        /// <param name="within">The agents close to this agent.</param>
        /// <param name="identifier">The identifier of the agents to get being within a distance to this agent.</param>
        /// <returns>The number of agents found.</returns>
        public int Within(float distance, [NotNull] ICollection<KaijuAgent> within, uint identifier)
        {
            return KaijuAgentsManager.Within(this, distance, within, identifier);
        }
        
        /// <summary>
        /// Get all agents within a distance this agent. The agents are added to the within parameter. It is up to you to clear this prior, as otherwise this will add entries.
        /// </summary>
        /// <param name="distance">The distance to detect agents within.</param>
        /// <param name="within">The agents close to this agent.</param>
        /// <param name="collection">The identifiers of the agents to get being within a distance to this agent.</param>
        /// <returns>The number of agents found.</returns>
        public int Within(float distance, [NotNull] ICollection<KaijuAgent> within, IEnumerable<uint> collection = null)
        {
            return KaijuAgentsManager.Within(this, distance, within, collection);
        }
        
        /// <summary>
        /// Get all agents beyond a distance to this agent.
        /// </summary>
        /// <param name="distance">The distance to detect agents beyond.</param>
        /// <param name="identifier">The identifier of the agents to get being beyond a distance to this agent.</param>
        /// <returns>All agents beyond a distance to this agent.</returns>
        public HashSet<KaijuAgent> Beyond(float distance, uint identifier)
        {
            return KaijuAgentsManager.Beyond(this, distance, identifier);
        }
        
        /// <summary>
        /// Get all agents beyond a distance this agent.
        /// </summary>
        /// <param name="distance">The distance to detect agents beyond.</param>
        /// <param name="collection">The identifiers of the agents to get being beyond a distance to this agent.</param>
        /// <returns>All beyond a distance to this agent.</returns>
        public HashSet<KaijuAgent> Beyond(float distance, IEnumerable<uint> collection = null)
        {
            return KaijuAgentsManager.Beyond(this, distance, collection);
        }
        
        /// <summary>
        /// Get all agents beyond a distance to this agent. The agents are added to the beyond parameter. It is up to you to clear this prior, as otherwise this will add entries.
        /// </summary>
        /// <param name="distance">The distance to detect agents beyond.</param>
        /// <param name="beyond">The agents close to this agent.</param>
        /// <param name="identifier">The identifier of the agents to get being beyond a distance to this agent.</param>
        /// <returns>The number of agents found.</returns>
        public int Beyond(float distance, [NotNull] ICollection<KaijuAgent> beyond, uint identifier)
        {
            return KaijuAgentsManager.Beyond(this, distance, beyond, identifier);
        }
        
        /// <summary>
        /// Get all agents beyond a distance this agent. The agents are added to the beyond parameter. It is up to you to clear this prior, as otherwise this will add entries.
        /// </summary>
        /// <param name="distance">The distance to detect agents beyond.</param>
        /// <param name="beyond">The agents close to this agent.</param>
        /// <param name="collection">The identifiers of the agents to get being beyond a distance to this agent.</param>
        /// <returns>The number of agents found.</returns>
        public int Beyond(float distance, [NotNull] ICollection<KaijuAgent> beyond, IEnumerable<uint> collection = null)
        {
            return KaijuAgentsManager.Beyond(this, distance, beyond, collection);
        }
        
        /// <summary>
        /// Get all agents beyond a distance to this agent.
        /// </summary>
        /// <param name="distanceA">One of the distances.</param>
        /// <param name="distanceB">One of the distances.</param>
        /// <param name="identifier">The identifier of the agents to get being between the distances to this agent.</param>
        /// <returns>All agents between the distances to this agent.</returns>
        public HashSet<KaijuAgent> Between(float distanceA, float distanceB, uint identifier)
        {
            return KaijuAgentsManager.Between(this, distanceA, distanceB, identifier);
        }
        
        /// <summary>
        /// Get all agents beyond a distance to this agent.
        /// </summary>
        /// <param name="distanceA">One of the distances.</param>
        /// <param name="distanceB">One of the distances.</param>
        /// <param name="collection">The identifiers of the agents to get being between the distances to this agent.</param>
        /// <returns>All agents between the distances to this agent.</returns>
        public HashSet<KaijuAgent> Between(float distanceA, float distanceB, IEnumerable<uint> collection = null)
        {
            return KaijuAgentsManager.Between(this, distanceA, distanceA, collection);
        }
        
        /// <summary>
        /// Get all agents beyond a distance and within another distance to this agent. The agents are added to the between parameter. It is up to you to clear this prior, as otherwise this will add entries.
        /// </summary>
        /// <param name="distanceA">One of the distances.</param>
        /// <param name="distanceB">One of the distances.</param>
        /// <param name="between">The agents close to this agent.</param>
        /// <param name="identifier">The identifier of the agents to get being between the distances to this agent.</param>
        /// <returns>The number of agents found.</returns>
        public int Between(float distanceA, float distanceB, [NotNull] ICollection<KaijuAgent> between, uint identifier)
        {
            return KaijuAgentsManager.Between(this, distanceA, distanceB, between, identifier);
        }
        
        /// <summary>
        /// Get all agents beyond a distance and within another distance to this agent. The agents are added to the between parameter. It is up to you to clear this prior, as otherwise this will add entries.
        /// </summary>
        /// <param name="distanceA">One of the distances.</param>
        /// <param name="distanceB">One of the distances.</param>
        /// <param name="between">The agents close to this agent.</param>
        /// <param name="collection">The identifiers of the agents to get being between the distances to this agent.</param>
        /// <returns>The number of agents found.</returns>
        public int Between(float distanceA, float distanceB,  [NotNull] ICollection<KaijuAgent> between, IEnumerable<uint> collection = null)
        {
            return KaijuAgentsManager.Between(this, distanceA, distanceA, between, collection);
        }
        
        /// <summary>
        /// Get the nearest agent to a given agent.
        /// </summary>
        /// <param name="distance">The distance the nearest agent is found to be.</param>
        /// <param name="identifier">The identifier to limit the search to.</param>
        /// <returns>The nearest agent or NULL if none are found.</returns>
        public KaijuAgent Nearest(out float distance, uint identifier)
        {
            return KaijuAgentsManager.Nearest(this, out distance, identifier);
        }
        
        /// <summary>
        /// Get the nearest agent to this agent.
        /// </summary>
        /// <param name="distance">The distance the nearest agent is found to be.</param>
        /// <param name="collection">Any identifiers to limit the search to.</param>
        /// <returns>The nearest agent or NULL if none are found.</returns>
        public KaijuAgent Nearest(out float distance, IEnumerable<uint> collection = null)
        {
            return KaijuAgentsManager.Nearest(this, out distance, collection);
        }
        
        /// <summary>
        /// Get the farthest agent to a given agent.
        /// </summary>
        /// <param name="distance">The distance the farthest agent is found to be.</param>
        /// <param name="identifier">The identifier to limit the search to.</param>
        /// <returns>The farthest agent or NULL if none are found.</returns>
        public KaijuAgent Farthest(out float distance, uint identifier)
        {
            return KaijuAgentsManager.Farthest(this, out distance, identifier);
        }
        
        /// <summary>
        /// Get the farthest agent to this agent.
        /// </summary>
        /// <param name="distance">The distance the farthest agent is found to be.</param>
        /// <param name="collection">Any identifiers to limit the search to.</param>
        /// <returns>The farthest agent or NULL if none are found.</returns>
        public KaijuAgent Farthest(out float distance, IEnumerable<uint> collection = null)
        {
            return KaijuAgentsManager.Farthest(this, out distance, collection);
        }
        
        /// <summary>
        /// Stop all movement.
        /// </summary>
        public void Stop()
        {
            foreach (KaijuMovement movement in _movements)
            {
                OnMovementStopped?.Invoke(this, movement);
                movement.Return();
            }
            
            _movements.Clear();
        }
        
        /// <summary>
        /// Stop a movement of this agent.
        /// </summary>
        /// <param name="movement">The movement to stop.</param>
        /// <returns>True if this movement has been stopped, otherwise this movement was not a part of this agent and was not stopped.</returns>
        public bool Stop(KaijuMovement movement)
        {
            for (int i = 0; i < _movements.Count; i++)
            {
                if (_movements[i] != movement)
                {
                    continue;
                }
                
                OnMovementStopped?.Invoke(this, _movements[i]);
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
                
                OnMovementStopped?.Invoke(this, _movements[i]);
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
            
            OnMovementStopped?.Invoke(this, _movements[index]);
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
                
                OnMovementStopped?.Invoke(this, _movements[i]);
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
            return Stop(new Vector2(v.x, v.z));
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
                
                OnMovementStopped?.Invoke(this, _movements[i]);
                _movements[i].Return();
                _movements.RemoveAt(i--);
                removed++;
            }
            
            return removed;
        }
        
        /// <summary>
        /// Stop an existing target movement in relation to a component.
        /// </summary>
        /// <param name="c">The component to stop moving in relation to.</param>
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
            _lookTransform = null;
            _lookVector = null;
            _lookVector3 = null;
            OnLookTarget?.Invoke(this);
        }
        
        /// <summary>
        /// Seek to a target.
        /// </summary>
        /// <param name="target">The target.</param>
        /// <param name="distance">At what distance from the target should the seek be considered successful.</param>
        /// <param name="weight">The weight of this movement.</param>
        /// <param name="clear">If this should clear all other current movement and become the only one the agent is performing.</param>
        /// <returns>The seek movement to the target.</returns>
        public KaijuSeekMovement Seek(Vector2 target, float distance = 0.1f, float weight = 1, bool clear = true)
        {
            if (clear)
            {
                Stop();
            }
            
            KaijuSeekMovement movement = KaijuSeekMovement.Get(this, target, distance, weight);
            _movements.Add(movement);
            OnMovementStarted?.Invoke(this, movement);
            return movement;
        }
        
        /// <summary>
        /// Seek to a target.
        /// </summary>
        /// <param name="target">The target.</param>
        /// <param name="distance">At what distance from the target should the seek be considered successful.</param>
        /// <param name="weight">The weight of this movement.</param>
        /// <param name="clear">If this should clear all other current movement and become the only one the agent is performing.</param>
        /// <returns>The seek movement to the target.</returns>
        public KaijuSeekMovement Seek(Vector3 target, float distance = 0.1f, float weight = 1, bool clear = true)
        {
            if (clear)
            {
                Stop();
            }
            
            KaijuSeekMovement movement = KaijuSeekMovement.Get(this, target, distance, weight);
            _movements.Add(movement);
            OnMovementStarted?.Invoke(this, movement);
            return movement;
        }
        
        /// <summary>
        /// Seek to a target.
        /// </summary>
        /// <param name="target">The target.</param>
        /// <param name="distance">At what distance from the target should the seek be considered successful.</param>
        /// <param name="weight">The weight of this movement.</param>
        /// <param name="clear">If this should clear all other current movement and become the only one the agent is performing.</param>
        /// <returns>The seek movement to the target.</returns>
        public KaijuSeekMovement Seek([NotNull] GameObject target, float distance = 0.1f, float weight = 1, bool clear = true)
        {
            if (clear)
            {
                Stop();
            }
            
            KaijuSeekMovement movement = KaijuSeekMovement.Get(this, target, distance, weight);
            _movements.Add(movement);
            OnMovementStarted?.Invoke(this, movement);
            return movement;
        }
        
        /// <summary>
        /// Seek to a target.
        /// </summary>
        /// <param name="target">The target.</param>
        /// <param name="distance">At what distance from the target should the seek be considered successful.</param>
        /// <param name="weight">The weight of this movement.</param>
        /// <param name="clear">If this should clear all other current movement and become the only one the agent is performing.</param>
        /// <returns>The seek movement to the target.</returns>
        public KaijuSeekMovement Seek([NotNull] Component target, float distance = 0.1f, float weight = 1, bool clear = true)
        {
            if (clear)
            {
                Stop();
            }
            
            KaijuSeekMovement movement = KaijuSeekMovement.Get(this, target, distance, weight);
            _movements.Add(movement);
            OnMovementStarted?.Invoke(this, movement);
            return movement;
        }
        
        /// <summary>
        /// Pursue to a target.
        /// </summary>
        /// <param name="target">The target.</param>
        /// <param name="distance">At what distance from the target should the pursue be considered successful.</param>
        /// <param name="weight">The weight of this movement.</param>
        /// <param name="clear">If this should clear all other current movement and become the only one the agent is performing.</param>
        /// <returns>The pursue movement to the target.</returns>
        public KaijuPursueMovement Pursue(Vector2 target, float distance = 0.1f, float weight = 1, bool clear = true)
        {
            if (clear)
            {
                Stop();
            }
            
            KaijuPursueMovement movement = KaijuPursueMovement.Get(this, target, distance, weight);
            _movements.Add(movement);
            OnMovementStarted?.Invoke(this, movement);
            return movement;
        }
        
        /// <summary>
        /// Pursue to a target.
        /// </summary>
        /// <param name="target">The target.</param>
        /// <param name="distance">At what distance from the target should the pursue be considered successful.</param>
        /// <param name="weight">The weight of this movement.</param>
        /// <param name="clear">If this should clear all other current movement and become the only one the agent is performing.</param>
        /// <returns>The pursue movement to the target.</returns>
        public KaijuPursueMovement Pursue(Vector3 target, float distance = 0.1f, float weight = 1, bool clear = true)
        {
            if (clear)
            {
                Stop();
            }
            
            KaijuPursueMovement movement = KaijuPursueMovement.Get(this, target, distance, weight);
            _movements.Add(movement);
            OnMovementStarted?.Invoke(this, movement);
            return movement;
        }
        
        /// <summary>
        /// Pursue to a target.
        /// </summary>
        /// <param name="target">The target.</param>
        /// <param name="distance">At what distance from the target should the pursue be considered successful.</param>
        /// <param name="weight">The weight of this movement.</param>
        /// <param name="clear">If this should clear all other current movement and become the only one the agent is performing.</param>
        /// <returns>The pursue movement to the target.</returns>
        public KaijuPursueMovement Pursue([NotNull] GameObject target, float distance = 0.1f, float weight = 1, bool clear = true)
        {
            if (clear)
            {
                Stop();
            }
            
            KaijuPursueMovement movement = KaijuPursueMovement.Get(this, target, distance, weight);
            _movements.Add(movement);
            OnMovementStarted?.Invoke(this, movement);
            return movement;
        }
        
        /// <summary>
        /// Pursue to a target.
        /// </summary>
        /// <param name="target">The target.</param>
        /// <param name="distance">At what distance from the target should the pursue be considered successful.</param>
        /// <param name="weight">The weight of this movement.</param>
        /// <param name="clear">If this should clear all other current movement and become the only one the agent is performing.</param>
        /// <returns>The pursue movement to the target.</returns>
        public KaijuPursueMovement Pursue([NotNull] Component target, float distance = 0.1f, float weight = 1, bool clear = true)
        {
            if (clear)
            {
                Stop();
            }
            
            KaijuPursueMovement movement = KaijuPursueMovement.Get(this, target, distance, weight);
            _movements.Add(movement);
            OnMovementStarted?.Invoke(this, movement);
            return movement;
        }
        
        /// <summary>
        /// Flee from a target.
        /// </summary>
        /// <param name="target">The target.</param>
        /// <param name="distance">At what distance from the target should the flee be considered successful.</param>
        /// <param name="weight">The weight of this movement.</param>
        /// <param name="clear">If this should clear all other current movement and become the only one the agent is performing.</param>
        /// <returns>The flee movement to the target.</returns>
        public KaijuFleeMovement Flee(Vector2 target, float distance = 20, float weight = 1, bool clear = true)
        {
            if (clear)
            {
                Stop();
            }
            
            KaijuFleeMovement movement = KaijuFleeMovement.Get(this, target, distance, weight);
            _movements.Add(movement);
            OnMovementStarted?.Invoke(this, movement);
            return movement;
        }
        
        /// <summary>
        /// Flee from a target.
        /// </summary>
        /// <param name="target">The target.</param>
        /// <param name="distance">At what distance from the target should the flee be considered successful.</param>
        /// <param name="weight">The weight of this movement.</param>
        /// <param name="clear">If this should clear all other current movement and become the only one the agent is performing.</param>
        /// <returns>The flee movement to the target.</returns>
        public KaijuFleeMovement Flee(Vector3 target, float distance = 20, float weight = 1, bool clear = true)
        {
            if (clear)
            {
                Stop();
            }
            
            KaijuFleeMovement movement = KaijuFleeMovement.Get(this, target, distance, weight);
            _movements.Add(movement);
            OnMovementStarted?.Invoke(this, movement);
            return movement;
        }
        
        /// <summary>
        /// Flee from a target.
        /// </summary>
        /// <param name="target">The target.</param>
        /// <param name="distance">At what distance from the target should the flee be considered successful.</param>
        /// <param name="weight">The weight of this movement.</param>
        /// <param name="clear">If this should clear all other current movement and become the only one the agent is performing.</param>
        /// <returns>The flee movement to the target.</returns>
        public KaijuFleeMovement Flee([NotNull] GameObject target, float distance = 20, float weight = 1, bool clear = true)
        {
            if (clear)
            {
                Stop();
            }
            
            KaijuFleeMovement movement = KaijuFleeMovement.Get(this, target, distance, weight);
            _movements.Add(movement);
            OnMovementStarted?.Invoke(this, movement);
            return movement;
        }
        
        /// <summary>
        /// Flee from a target.
        /// </summary>
        /// <param name="target">The target.</param>
        /// <param name="distance">At what distance from the target should the flee be considered successful.</param>
        /// <param name="weight">The weight of this movement.</param>
        /// <param name="clear">If this should clear all other current movement and become the only one the agent is performing.</param>
        /// <returns>The flee movement to the target.</returns>
        public KaijuFleeMovement Flee([NotNull] Component target, float distance = 20, float weight = 1, bool clear = true)
        {
            if (clear)
            {
                Stop();
            }
            
            KaijuFleeMovement movement = KaijuFleeMovement.Get(this, target, distance, weight);
            _movements.Add(movement);
            OnMovementStarted?.Invoke(this, movement);
            return movement;
        }
        
        /// <summary>
        /// Evade from a target.
        /// </summary>
        /// <param name="target">The target.</param>
        /// <param name="distance">At what distance from the target should the evade be considered successful.</param>
        /// <param name="weight">The weight of this movement.</param>
        /// <param name="clear">If this should clear all other current movement and become the only one the agent is performing.</param>
        /// <returns>The pursue movement to the target.</returns>
        public KaijuEvadeMovement Evade(Vector2 target, float distance = 20, float weight = 1, bool clear = true)
        {
            if (clear)
            {
                Stop();
            }
            
            KaijuEvadeMovement movement = KaijuEvadeMovement.Get(this, target, distance, weight);
            _movements.Add(movement);
            OnMovementStarted?.Invoke(this, movement);
            return movement;
        }
        
        /// <summary>
        /// Evade from a target.
        /// </summary>
        /// <param name="target">The target.</param>
        /// <param name="distance">At what distance from the target should the evade be considered successful.</param>
        /// <param name="weight">The weight of this movement.</param>
        /// <param name="clear">If this should clear all other current movement and become the only one the agent is performing.</param>
        /// <returns>The evade movement to the target.</returns>
        public KaijuEvadeMovement Evade(Vector3 target, float distance = 20, float weight = 1, bool clear = true)
        {
            if (clear)
            {
                Stop();
            }
            
            KaijuEvadeMovement movement = KaijuEvadeMovement.Get(this, target, distance, weight);
            _movements.Add(movement);
            OnMovementStarted?.Invoke(this, movement);
            return movement;
        }
        
        /// <summary>
        /// Evade from a target.
        /// </summary>
        /// <param name="target">The target.</param>
        /// <param name="distance">At what distance from the target should the evade be considered successful.</param>
        /// <param name="weight">The weight of this movement.</param>
        /// <param name="clear">If this should clear all other current movement and become the only one the agent is performing.</param>
        /// <returns>The evade movement to the target.</returns>
        public KaijuEvadeMovement Evade([NotNull] GameObject target, float distance = 20, float weight = 1, bool clear = true)
        {
            if (clear)
            {
                Stop();
            }
            
            KaijuEvadeMovement movement = KaijuEvadeMovement.Get(this, target, distance, weight);
            _movements.Add(movement);
            OnMovementStarted?.Invoke(this, movement);
            return movement;
        }
        
        /// <summary>
        /// Evade from a target.
        /// </summary>
        /// <param name="target">The target.</param>
        /// <param name="distance">At what distance from the target should the evade be considered successful.</param>
        /// <param name="weight">The weight of this movement.</param>
        /// <param name="clear">If this should clear all other current movement and become the only one the agent is performing.</param>
        /// <returns>The evade movement to the target.</returns>
        public KaijuEvadeMovement Evade([NotNull] Component target, float distance = 20, float weight = 1, bool clear = true)
        {
            if (clear)
            {
                Stop();
            }
            
            KaijuEvadeMovement movement = KaijuEvadeMovement.Get(this, target, distance, weight);
            _movements.Add(movement);
            OnMovementStarted?.Invoke(this, movement);
            return movement;
        }
        
        /// <summary>
        /// Wander.
        /// </summary>
        /// <param name="distance">How far out to generate the wander circle.</param>
        /// <param name="radius">The radius of the wander circle.</param>
        /// <param name="weight">The weight of this movement.</param>
        /// <param name="clear">If this should clear all other current movement and become the only one the agent is performing.</param>
        /// <returns>The wander movement.</returns>
        public KaijuWanderMovement Wander(float distance = 5, float radius = 1, float weight = 1, bool clear = true)
        {
            if (clear)
            {
                Stop();
            }
            
            KaijuWanderMovement movement = KaijuWanderMovement.Get(this, distance, radius, weight);
            _movements.Add(movement);
            OnMovementStarted?.Invoke(this, movement);
            return movement;
        }
        
        /// <summary>
        /// Separate from other agents.
        /// </summary>
        /// <param name="distance">The distance to avoid other agents from.</param>
        /// <param name="coefficient">The coefficient to use for inverse square law separation. Zero will use linear separation.</param>
        /// <param name="collection">What types of agents to avoid.</param>
        /// <param name="weight">The weight of this movement.</param>
        /// <param name="clear">If this should clear all other current movement and become the only one the agent is performing.</param>
        public KaijuSeparationMovement Separation(float distance = 10, float coefficient = 0, ICollection<uint> collection = null, float weight = 1, bool clear = true)
        {
            if (clear)
            {
                Stop();
            }
            
            KaijuSeparationMovement movement = KaijuSeparationMovement.Get(this, distance, coefficient, collection, weight);
            _movements.Add(movement);
            OnMovementStarted?.Invoke(this, movement);
            return movement;
        }
        
        /// <summary>
        /// Avoid obstacles.
        /// </summary>
        /// <param name="avoidance">The distance from a wall the agent should maintain.</param>
        /// <param name="distance">The distance for rays.</param>
        /// <param name="sideDistance">The distance of the side rays. Zero or less will use the <see cref="KaijuObstacleAvoidanceMovement.Distance"/>.</param>
        /// <param name="angle">The angle for side rays.</param>
        /// <param name="height">The height offset for the rays.</param>
        /// <param name="horizontal">The horizontal shift for the side rays.</param>
        /// <param name="mask">The mask for what layers should the rays hit.</param>
        /// <param name="weight">The weight of this movement.</param>
        /// <param name="clear">If this should clear all other current movement and become the only one the agent is performing.</param>
        public KaijuObstacleAvoidanceMovement ObstacleAvoidance(float avoidance = 2, float distance = 5, float sideDistance = 0, float angle = 15, float height = 1, float horizontal = 0, LayerMask? mask = null, float weight = 1, bool clear = true)
        {
            if (clear)
            {
                Stop();
            }
            
            KaijuObstacleAvoidanceMovement movement = KaijuObstacleAvoidanceMovement.Get(this, avoidance, distance, sideDistance, angle, height, horizontal, mask, weight);
            _movements.Add(movement);
            OnMovementStarted?.Invoke(this, movement);
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
                KaijuAgentsManager.ValidateIdentifiers(this);
            }
            
            Setup();
        }
        
        /// <summary>
        /// Visualize this agent.
        /// </summary>
        /// <param name="text">If the text for this agent should be visualized.</param>
        public void Visualize(bool text)
        {
            Vector3 p = transform.position;
            
            // If the agent is moving or has an explicit looking target, it has some visuals of its own.
            bool moving = Velocity != Vector2.zero;
            Vector3? v = LookVector3;
            if (moving || v.HasValue)
            {
                Handles.color = KaijuAgentsManager.AgentColor;
            }
            
            // Draw the movement vector.
            if (moving)
            {
                Handles.DrawLine(p, p + Velocity3.normalized);
            }
            
            if (text)
            {
                KaijuAgentsManager.Label(p, name, KaijuAgentsManager.AgentColor);
            }
            
            // Show where the agent is looking.
            if (v.HasValue)
            {
                Handles.DrawLine(p, v.Value);
            }
            
            // Visualize all movements.
            foreach (KaijuMovement movement in _movements)
            {
                movement.Visualize();
            }
        }
#endif
        /// <summary>
        /// Perform agent movement.
        /// </summary>
        /// <param name="delta">The time step.</param>
        public abstract void Move(float delta);
        
        /// <summary>
        /// Handle look actions.
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
                // If we don't want to automatically look or there is no movement, stop.
                if (!AutoRotate || Velocity == Vector2.zero)
                {
                    return;
                }
                
                target = t.position + Velocity3.normalized;
            }
            else
            {
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
        /// Implicit conversion to a float from the <see cref="Orientation"/>.
        /// </summary>
        /// <param name="a">The agent.</param>
        /// <returns>The agent's <see cref="Orientation"/>.</returns>
        public static implicit operator float([NotNull] KaijuAgent a) => a.Orientation;
        
        /// <summary>
        /// Implicit conversion to a nullable float from the <see cref="Orientation"/>.
        /// </summary>
        /// <param name="a">The agent.</param>
        /// <returns>The agent's <see cref="Orientation"/>.</returns>
        public static implicit operator float?([NotNull] KaijuAgent a) => a.Orientation;
        
        /// <summary>
        /// Implicit conversion to a double from the <see cref="Orientation"/>.
        /// </summary>
        /// <param name="a">The agent.</param>
        /// <returns>The agent's <see cref="Orientation"/>.</returns>
        public static implicit operator double([NotNull] KaijuAgent a) => a.Orientation;
        
        /// <summary>
        /// Implicit conversion to a nullable double from the <see cref="Orientation"/>.
        /// </summary>
        /// <param name="a">The agent.</param>
        /// <returns>The agent's <see cref="Orientation"/>.</returns>
        public static implicit operator double?([NotNull] KaijuAgent a) => a.Orientation;
        
        /// <summary>
        /// Implicit conversion to a Vector2 from the <see cref="Position"/>.
        /// </summary>
        /// <param name="a">The agent.</param>
        /// <returns>The agent's <see cref="Position"/>.</returns>
        public static implicit operator Vector2([NotNull] KaijuAgent a) => a.Position;
        
        /// <summary>
        /// Implicit conversion to a nullable Vector2 from the <see cref="Position"/>.
        /// </summary>
        /// <param name="a">The agent.</param>
        /// <returns>The agent's <see cref="Position"/>.</returns>
        public static implicit operator Vector2?([NotNull] KaijuAgent a) => a.Position;
        
        /// <summary>
        /// Implicit conversion to a Vector2 from the <see cref="Position"/>.
        /// </summary>
        /// <param name="a">The agent.</param>
        /// <returns>The agent's <see cref="Position"/>.</returns>
        public static implicit operator Vector3([NotNull] KaijuAgent a) => a.Position3;
        
        /// <summary>
        /// Implicit conversion to a nullable Vector3 from the <see cref="Position3"/>.
        /// </summary>
        /// <param name="a">The agent.</param>
        /// <returns>The agent's <see cref="Position3"/>.</returns>
        public static implicit operator Vector3?([NotNull] KaijuAgent a) => a.Position3;
        
        /// <summary>
        /// Implicit conversion to a <see href="https://docs.unity3d.com/Manual/class-GameObject.html">GameObject</see>.
        /// </summary>
        /// <param name="a">The agent.</param>
        /// <returns>The <see href="https://docs.unity3d.com/Manual/class-GameObject.html">GameObject</see> of the agent.</returns>
        public static implicit operator GameObject([NotNull] KaijuAgent a) => a.gameObject;
        
        /// <summary>
        /// Implicit conversion from a <see href="https://docs.unity3d.com/Manual/class-GameObject.html">GameObject</see>.
        /// </summary>
        /// <param name="o">The <see href="https://docs.unity3d.com/Manual/class-GameObject.html">GameObject</see>.</param>
        /// <returns>The agent attached to the <see href="https://docs.unity3d.com/Manual/class-GameObject.html">GameObject</see> if there was one.</returns>
        public static implicit operator KaijuAgent([NotNull] GameObject o) => o.GetComponent<KaijuAgent>();
        
        /// <summary>
        /// Implicit conversion to a <see href="https://docs.unity3d.com/Manual/class-Transform.html">transform</see>.
        /// </summary>
        /// <param name="a">The agent.</param>
        /// <returns>The <see href="https://docs.unity3d.com/Manual/class-Transform.html">transform</see> of the agent.</returns>
        public static implicit operator Transform([NotNull] KaijuAgent a) => a.transform;
        
        /// <summary>
        /// Implicit conversion from a <see href="https://docs.unity3d.com/Manual/class-Transform.html">transform</see>.
        /// </summary>
        /// <param name="t">The <see href="https://docs.unity3d.com/Manual/class-Transform.html">transform</see>.</param>
        /// <returns>The agent attached to the <see href="https://docs.unity3d.com/Manual/class-Transform.html">transform</see> if there was one.</returns>
        public static implicit operator KaijuAgent([NotNull] Transform t) => t.GetComponent<KaijuAgent>();
        
        /// <summary>
        /// Implicit conversion to a Boolean if the agent is active.
        /// </summary>
        /// <param name="a">The agent.</param>
        /// <returns>If the agent is active.</returns>
        public static implicit operator bool(KaijuAgent a) => a != null && a.isActiveAndEnabled;
        
        /// <summary>
        /// Implicit conversion to a nullable Boolean if the agent is active.
        /// </summary>
        /// <param name="a">The agent.</param>
        /// <returns>If the agent is active.</returns>
        public static implicit operator bool?(KaijuAgent a) =>  a != null && a.isActiveAndEnabled;
        
        /// <summary>
        /// Implicit conversion to a string.
        /// </summary>
        /// <param name="a">The agent.</param>
        /// <returns>The string from the <see cref="ToString"/> method.</returns>
        public static implicit operator string([NotNull] KaijuAgent a) => a.ToString();
    }
}