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
        public float Speed { get; private set; }
        
        /// <summary>
        /// The current velocity of the agent.
        /// </summary>
        public Vector2 Velocity { get; private set; }
        
        /// <summary>
        /// All movements the agent is currently performing.
        /// </summary>
        public readonly List<KaijuMovement> Movements = new();
        
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
        /// Handle moving the agent.
        /// </summary>
        private Vector2 Move()
        {
            // Start with no motion this frame.
            Vector2 velocity = Vector2.zero;
            
            // At first there is no weight.
            float weight = 0;
            
            // Go through all assigned movements.
            for (int i = 0; i < Movements.Count; i++)
            {
                // If the movement is done, remove it to the cache.
                if (Movements[i].Done())
                {
                    Movements[i].Return();
                    Movements.RemoveAt(i--);
                    continue;
                }
                
                // Otherwise, add up its weighting.
                weight += Movements[i].Weight;
                
                // Otherwise, calculate the movement.
                velocity += Movements[i].Move();
            }
            
            // Go through all remaining movements again to perform them.
            foreach (KaijuMovement movement in Movements)
            {
                // Weight the movement.
                velocity += movement.Move() * (movement.Weight / weight);
            }
            
            return velocity;
        }
        
        /// <summary>
        /// Stop all movement.
        /// </summary>
        public void Stop()
        {
            foreach (KaijuMovement movement in Movements)
            {
                movement.Return();
            }
            
            Movements.Clear();
        }
        
        /// <summary>
        /// Stop an existing movement in relation to a <see href="https://docs.unity3d.com/Manual/class-GameObject.html">component</see>.
        /// </summary>
        /// <param name="go">The <see href="https://docs.unity3d.com/Manual/class-GameObject.html">GameObject</see> to stop moving in relation to.</param>
        public void StopFor([NotNull] GameObject go)
        {
            // TODO.
        }
        
        /// <summary>
        /// Stop an existing movement in relation to a component.
        /// </summary>
        /// <param name="c">The component to stop moving in relation to.</param>
        public void StopFor([NotNull] Component c)
        {
            // TODO.
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
            Movements.Add(movement);
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
            Movements.Add(movement);
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
            else
            {
                // Only have one movement towards each target object.
                StopFor(target);
            }
            
            KaijuSeekMovement movement = KaijuSeekMovement.Get(this, target, distance, weight);
            Movements.Add(movement);
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
            else
            {
                // Only have one movement towards each target object.
                StopFor(target);
            }
            
            KaijuSeekMovement movement = KaijuSeekMovement.Get(this, target, distance, weight);
            Movements.Add(movement);
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
            Movements.Add(movement);
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
            Movements.Add(movement);
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
            else
            {
                // Only have one movement towards each target object.
                StopFor(target);
            }
            
            KaijuPursueMovement movement = KaijuPursueMovement.Get(this, target, distance, weight);
            Movements.Add(movement);
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
            else
            {
                // Only have one movement towards each target object.
                StopFor(target);
            }
            
            KaijuPursueMovement movement = KaijuPursueMovement.Get(this, target, distance, weight);
            Movements.Add(movement);
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
            Movements.Add(movement);
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
            Movements.Add(movement);
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
            else
            {
                // Only have one movement towards each target object.
                StopFor(target);
            }
            
            KaijuFleeMovement movement = KaijuFleeMovement.Get(this, target, distance, weight);
            Movements.Add(movement);
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
            else
            {
                // Only have one movement towards each target object.
                StopFor(target);
            }
            
            KaijuFleeMovement movement = KaijuFleeMovement.Get(this, target, distance, weight);
            Movements.Add(movement);
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
            Movements.Add(movement);
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
            Movements.Add(movement);
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
            else
            {
                // Only have one movement towards each target object.
                StopFor(target);
            }
            
            KaijuEvadeMovement movement = KaijuEvadeMovement.Get(this, target, distance, weight);
            Movements.Add(movement);
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
            else
            {
                // Only have one movement towards each target object.
                StopFor(target);
            }
            
            KaijuEvadeMovement movement = KaijuEvadeMovement.Get(this, target, distance, weight);
            Movements.Add(movement);
            return movement;
        }
        
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
        public static implicit operator Vector3([NotNull] KaijuAgent a) => a.Position;
        
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