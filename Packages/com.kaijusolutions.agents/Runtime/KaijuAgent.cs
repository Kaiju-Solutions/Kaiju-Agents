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
#if UNITY_EDITOR
    [SelectionBase]
    [DisallowMultipleComponent]
    [Icon("Packages/com.kaijusolutions.agents/Editor/Icon.png")]
    [HelpURL("https://agents.kaijusolutions.ca/manual/getting-started.html")]
#endif
    public abstract class KaijuAgent : MonoBehaviour
    {
        /// <summary>
        /// The maximum move speed of the agent.
        /// </summary>
        public float Speed
        {
            get => speed;
            set => speed = Mathf.Max(value, 0);
        }
        
        /// <summary>
        /// The maximum move speed of the agent.
        /// </summary>
#if UNITY_EDITOR
        [Tooltip("The maximum move speed of the agents.")]
#endif
        [Min(0)]
        [SerializeField]
        private float speed = 10f;
        
        /// <summary>
        /// The maximum look speed of the agent.
        /// </summary>
        public float LookSpeed
        {
            get => lookSpeed;
            set => lookSpeed = Mathf.Max(value, 0);
        }
        
        /// <summary>
        /// The maximum look speed of the agent.
        /// </summary>
#if UNITY_EDITOR
        [Tooltip("The maximum look speed of the agents.")]
#endif
        [Min(0)]
        [SerializeField]
        private float lookSpeed;

        /// <summary>
        /// If the agent should automatically rotate towards where it is moving when no look target is set.
        /// </summary>
#if UNITY_EDITOR
        [field:
            Tooltip("If the agent should automatically rotate towards where it is moving when no look target is set.")]
#endif
        [field: SerializeField]
        public bool AutoRotate { get; private set; } = true;
        
        /// <summary>
        /// The current velocity of the agent.
        /// </summary>
        public Vector2 Velocity { get; private set; }
        
        /// <summary>
        /// The current velocity of the agent.
        /// </summary>
        public Vector3 Velocity3 => new(Velocity.x, 0, Velocity.y);
        
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
        /// Get the position vector along the main XZ axis.
        /// </summary>
        public Vector2 Position
        {
            get
            {
                Vector3 p = transform.position;
                return new(p.x, p.z);
            }
        }
        
        /// <summary>
        /// Get the position vector along all three axes.
        /// </summary>
        public Vector3 Position3 => transform.position;
        
        /// <summary>
        /// Get the angle the agent is rotated along the main Y axis.
        /// </summary>
        public float Orientation => transform.localEulerAngles.y;
        
        /// <summary>
        /// Initialize the agent.
        /// </summary>
        public virtual void Setup() { }
        
        /// <summary>
        /// Calculate the velocity for the next update.
        /// <param name="delta">The time step.</param>
        /// </summary>
        protected void CalculateVelocity(float delta)
        {
            // Start with no motion this frame.
            Vector2 velocity = Vector2.zero;
            
            // At first there is no weight.
            float weight = 0;
            
            // Go through all assigned movements.
            for (int i = 0; i < _movements.Count; i++)
            {
                // If the movement is done, remove it to the cache.
                if (_movements[i].Done())
                {
                    _movements[i].Return();
                    _movements.RemoveAt(i--);
                    continue;
                }
                
                // Otherwise, add up its weighting.
                weight += _movements[i].Weight;
            }
            
            // Go through all remaining movements again to perform them.
            foreach (KaijuMovement movement in _movements)
            {
                // Weight the movement.
                velocity += movement.Move(delta) * (movement.Weight / weight);
            }
            
            Velocity += velocity;
        }
        
        /// <summary>
        /// LateUpdate is called every frame, if the Behaviour is enabled.
        /// </summary>
        private void LateUpdate()
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
            Vector3 rotation = Vector3.RotateTowards(t.forward, target - t.position, (lookSpeed > 0 ? lookSpeed : Mathf.Infinity) * Time.deltaTime, 0.0f);
            if (rotation != Vector3.zero && !float.IsNaN(rotation.x) && !float.IsNaN(rotation.y) && !float.IsNaN(rotation.z))
            {
                t.rotation = Quaternion.LookRotation(rotation);
            }
        }
        
        /// <summary>
        /// Stop all movement.
        /// </summary>
        public void Stop()
        {
            foreach (KaijuMovement movement in _movements)
            {
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
                
                _movements[i].Return();
                _movements.RemoveAt(i);
                return true;
            }
            
            return false;
        }
        
        /// <summary>
        /// Stop a movement by the given index.
        /// </summary>
        /// <param name="index">The index to stop.</param>
        /// <returns>If the movement was stopped, with a failure incdicating the index was out of bounds.</returns>
        public bool Stop(int index)
        {
            if (index < 0 || index >= MovementsCount)
            {
                return false;
            }
            
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
        /// Seek to a target.
        /// </summary>
        /// <param name="target">The target.</param>
        /// <param name="distance">At what distance from the target should the seek be considered successful.</param>
        /// <param name="weight">The weight of this movement.</param>
        /// <param name="clear">If this should clear all other current movement and become the only one the agent is performing.</param>
        /// <returns>The seek movement to the target.</returns>
        public KaijuSeekMovement Seek(Vector2 target, float distance = 0, float weight = 1, bool clear = true)
        {
            if (clear)
            {
                Stop();
            }
            
            KaijuSeekMovement movement = KaijuSeekMovement.Get(this, target, distance, weight);
            _movements.Add(movement);
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
        public KaijuSeekMovement Seek(Vector3 target, float distance = 0, float weight = 1, bool clear = true)
        {
            if (clear)
            {
                Stop();
            }
            
            KaijuSeekMovement movement = KaijuSeekMovement.Get(this, target, distance, weight);
            _movements.Add(movement);
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
        public KaijuSeekMovement Seek([NotNull] GameObject target, float distance = 0, float weight = 1, bool clear = true)
        {
            if (clear)
            {
                Stop();
            }
            
            KaijuSeekMovement movement = KaijuSeekMovement.Get(this, target, distance, weight);
            _movements.Add(movement);
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
        public KaijuSeekMovement Seek([NotNull] Component target, float distance = 0, float weight = 1, bool clear = true)
        {
            if (clear)
            {
                Stop();
            }
            
            KaijuSeekMovement movement = KaijuSeekMovement.Get(this, target, distance, weight);
            _movements.Add(movement);
            return movement;
        }
        
        /// <summary>
        /// Pursue to a target.
        /// </summary>
        /// <param name="target">The target.</param>
        /// <param name="distance">At what distance from the target should the pursue be considered successful.</param>
        /// <param name="weight">The weight of this movement.</param>
        /// <param name="clear">If this should clear all other current movement and become the only one the agent is performing.</param>
        /// <returns>The seek movement to the target.</returns>
        public KaijuPursueMovement Pursue(Vector2 target, float distance = 0, float weight = 1, bool clear = true)
        {
            if (clear)
            {
                Stop();
            }
            
            KaijuPursueMovement movement = KaijuPursueMovement.Get(this, target, distance, weight);
            _movements.Add(movement);
            return movement;
        }
        
        /// <summary>
        /// Pursue to a target.
        /// </summary>
        /// <param name="target">The target.</param>
        /// <param name="distance">At what distance from the target should the pursue be considered successful.</param>
        /// <param name="weight">The weight of this movement.</param>
        /// <param name="clear">If this should clear all other current movement and become the only one the agent is performing.</param>
        /// <returns>The seek movement to the target.</returns>
        public KaijuPursueMovement Pursue(Vector3 target, float distance = 0, float weight = 1, bool clear = true)
        {
            if (clear)
            {
                Stop();
            }
            
            KaijuPursueMovement movement = KaijuPursueMovement.Get(this, target, distance, weight);
            _movements.Add(movement);
            return movement;
        }
        
        /// <summary>
        /// Pursue to a target.
        /// </summary>
        /// <param name="target">The target.</param>
        /// <param name="distance">At what distance from the target should the pursue be considered successful.</param>
        /// <param name="weight">The weight of this movement.</param>
        /// <param name="clear">If this should clear all other current movement and become the only one the agent is performing.</param>
        /// <returns>The seek movement to the target.</returns>
        public KaijuPursueMovement Pursue([NotNull] GameObject target, float distance = 0, float weight = 1, bool clear = true)
        {
            if (clear)
            {
                Stop();
            }
            
            KaijuPursueMovement movement = KaijuPursueMovement.Get(this, target, distance, weight);
            _movements.Add(movement);
            return movement;
        }
        
        /// <summary>
        /// Pursue to a target.
        /// </summary>
        /// <param name="target">The target.</param>
        /// <param name="distance">At what distance from the target should the pursue be considered successful.</param>
        /// <param name="weight">The weight of this movement.</param>
        /// <param name="clear">If this should clear all other current movement and become the only one the agent is performing.</param>
        /// <returns>The seek movement to the target.</returns>
        public KaijuPursueMovement Pursue([NotNull] Component target, float distance = 0, float weight = 1, bool clear = true)
        {
            if (clear)
            {
                Stop();
            }
            
            KaijuPursueMovement movement = KaijuPursueMovement.Get(this, target, distance, weight);
            _movements.Add(movement);
            return movement;
        }
        
        /// <summary>
        /// Flee from a target.
        /// </summary>
        /// <param name="target">The target.</param>
        /// <param name="distance">At what distance from the target should the flee be considered successful.</param>
        /// <param name="weight">The weight of this movement.</param>
        /// <param name="clear">If this should clear all other current movement and become the only one the agent is performing.</param>
        /// <returns>The seek movement to the target.</returns>
        public KaijuFleeMovement Flee(Vector2 target, float distance = float.MaxValue, float weight = 1, bool clear = true)
        {
            if (clear)
            {
                Stop();
            }
            
            KaijuFleeMovement movement = KaijuFleeMovement.Get(this, target, distance, weight);
            _movements.Add(movement);
            return movement;
        }
        
        /// <summary>
        /// Flee from a target.
        /// </summary>
        /// <param name="target">The target.</param>
        /// <param name="distance">At what distance from the target should the flee be considered successful.</param>
        /// <param name="weight">The weight of this movement.</param>
        /// <param name="clear">If this should clear all other current movement and become the only one the agent is performing.</param>
        /// <returns>The seek movement to the target.</returns>
        public KaijuFleeMovement Flee(Vector3 target, float distance = float.MaxValue, float weight = 1, bool clear = true)
        {
            if (clear)
            {
                Stop();
            }
            
            KaijuFleeMovement movement = KaijuFleeMovement.Get(this, target, distance, weight);
            _movements.Add(movement);
            return movement;
        }
        
        /// <summary>
        /// Flee from a target.
        /// </summary>
        /// <param name="target">The target.</param>
        /// <param name="distance">At what distance from the target should the flee be considered successful.</param>
        /// <param name="weight">The weight of this movement.</param>
        /// <param name="clear">If this should clear all other current movement and become the only one the agent is performing.</param>
        /// <returns>The seek movement to the target.</returns>
        public KaijuFleeMovement Flee([NotNull] GameObject target, float distance = float.MaxValue, float weight = 1, bool clear = true)
        {
            if (clear)
            {
                Stop();
            }
            
            KaijuFleeMovement movement = KaijuFleeMovement.Get(this, target, distance, weight);
            _movements.Add(movement);
            return movement;
        }
        
        /// <summary>
        /// Flee from a target.
        /// </summary>
        /// <param name="target">The target.</param>
        /// <param name="distance">At what distance from the target should the flee be considered successful.</param>
        /// <param name="weight">The weight of this movement.</param>
        /// <param name="clear">If this should clear all other current movement and become the only one the agent is performing.</param>
        /// <returns>The seek movement to the target.</returns>
        public KaijuFleeMovement Flee([NotNull] Component target, float distance = float.MaxValue, float weight = 1, bool clear = true)
        {
            if (clear)
            {
                Stop();
            }
            
            KaijuFleeMovement movement = KaijuFleeMovement.Get(this, target, distance, weight);
            _movements.Add(movement);
            return movement;
        }
        
        /// <summary>
        /// Evade from a target.
        /// </summary>
        /// <param name="target">The target.</param>
        /// <param name="distance">At what distance from the target should the evade be considered successful.</param>
        /// <param name="weight">The weight of this movement.</param>
        /// <param name="clear">If this should clear all other current movement and become the only one the agent is performing.</param>
        /// <returns>The seek movement to the target.</returns>
        public KaijuEvadeMovement Evade(Vector2 target, float distance = float.MaxValue, float weight = 1, bool clear = true)
        {
            if (clear)
            {
                Stop();
            }
            
            KaijuEvadeMovement movement = KaijuEvadeMovement.Get(this, target, distance, weight);
            _movements.Add(movement);
            return movement;
        }
        
        /// <summary>
        /// Evade from a target.
        /// </summary>
        /// <param name="target">The target.</param>
        /// <param name="distance">At what distance from the target should the evade be considered successful.</param>
        /// <param name="weight">The weight of this movement.</param>
        /// <param name="clear">If this should clear all other current movement and become the only one the agent is performing.</param>
        /// <returns>The seek movement to the target.</returns>
        public KaijuEvadeMovement Evade(Vector3 target, float distance = float.MaxValue, float weight = 1, bool clear = true)
        {
            if (clear)
            {
                Stop();
            }
            
            KaijuEvadeMovement movement = KaijuEvadeMovement.Get(this, target, distance, weight);
            _movements.Add(movement);
            return movement;
        }
        
        /// <summary>
        /// Evade from a target.
        /// </summary>
        /// <param name="target">The target.</param>
        /// <param name="distance">At what distance from the target should the evade be considered successful.</param>
        /// <param name="weight">The weight of this movement.</param>
        /// <param name="clear">If this should clear all other current movement and become the only one the agent is performing.</param>
        /// <returns>The seek movement to the target.</returns>
        public KaijuEvadeMovement Evade([NotNull] GameObject target, float distance = float.MaxValue, float weight = 1, bool clear = true)
        {
            if (clear)
            {
                Stop();
            }
            
            KaijuEvadeMovement movement = KaijuEvadeMovement.Get(this, target, distance, weight);
            _movements.Add(movement);
            return movement;
        }
        
        /// <summary>
        /// Evade from a target.
        /// </summary>
        /// <param name="target">The target.</param>
        /// <param name="distance">At what distance from the target should the evade be considered successful.</param>
        /// <param name="weight">The weight of this movement.</param>
        /// <param name="clear">If this should clear all other current movement and become the only one the agent is performing.</param>
        /// <returns>The seek movement to the target.</returns>
        public KaijuEvadeMovement Evade([NotNull] Component target, float distance = float.MaxValue, float weight = 1, bool clear = true)
        {
            if (clear)
            {
                Stop();
            }
            
            KaijuEvadeMovement movement = KaijuEvadeMovement.Get(this, target, distance, weight);
            _movements.Add(movement);
            return movement;
        }
#if UNITY_EDITOR
        /// <summary>
        /// Implement OnDrawGizmos if you want to draw gizmos that are also pickable and always drawn.
        /// </summary>
        private void OnDrawGizmos()
        {
            // See if this should be rendered.
            bool selected = Selection.activeTransform == transform;
            if (!selected && !KaijuMovementManager.GizmosAll)
            {
                return;
            }
            
            KaijuMovementManager.GizmosTextMode mode = KaijuMovementManager.GizmosText;
            bool text = mode is KaijuMovementManager.GizmosTextMode.All || (mode is KaijuMovementManager.GizmosTextMode.Selected && selected);
            
            Vector3 p = transform.position;
            
            // If the agent is moving or has an explicit looking target, it has some visuals of its own.
            bool moving = Velocity != Vector2.zero;
            Vector3? v = LookVector3;
            if (moving || v.HasValue)
            {
                // TODO - Make a setting.
                Gizmos.color = Color.white;
            }
            
            // Draw the movement vector.
            if (moving)
            {
                Gizmos.DrawLine(p, p + Velocity3.normalized);
            }
            
            // Show where the agent is looking.
            if (v.HasValue)
            {
                Gizmos.DrawLine(p, v.Value);
                
                if (text)
                {
                    Handles.Label((v.Value + p) / 2f, $"{LookDistance:F2}");
                }
            }
            
            // Visualize all movements.
            foreach (KaijuMovement movement in _movements)
            {
                movement.Visualize(text);
            }
        }
#endif
        /// <summary>
        /// Get a description of the object.
        /// </summary>
        /// <returns>A description of the object.</returns>
        public override string ToString()
        {
            return $"Kaiju Agent {name} - {(isActiveAndEnabled ? "Active" : "Inactive")} - Velocity: {Velocity} - Max Speed: {Speed}";
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