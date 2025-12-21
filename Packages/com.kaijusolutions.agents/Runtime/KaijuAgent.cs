using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using KaijuSolutions.Agents.Movement;
using UnityEngine;

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
        /// The maximum speed of the agent.
        /// </summary>
        public float Speed
        {
            get => speed;
            set => speed = Mathf.Max(value, 0);
        }
        
        /// <summary>
        /// The maximum speed of the agent.
        /// </summary>
#if UNITY_EDITOR
        [Tooltip("The maximum speed of the agents.")]
#endif
        [Min(0)]
        [SerializeField]
        private float speed = 10;
        
        /// <summary>
        /// The current velocity of the agent.
        /// </summary>
        public Vector2 Velocity { get; private set; }
        
        /// <summary>
        /// The current velocity of the agent.
        /// </summary>
        public Vector3 Velocity3 => new Vector3(Velocity.x, 0, Velocity.y);
        
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
                
                Vector2? t = target.Target;
                if (!t.HasValue || v != t)
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
            Visualize();
        }
        
        /// <summary>
        /// Allow for visualizing with <see href="https://docs.unity3d.com/ScriptReference/Gizmos.html">gizmos</see>.
        /// </summary>
        private void Visualize()
        {
            //Gizmos.matrix = transform.localToWorldMatrix;
            
            foreach (KaijuMovement movement in _movements)
            {
                if (!movement.Done())
                {
                    movement.Visualize();
                }
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