using System.Diagnostics.CodeAnalysis;
using UnityEngine;

namespace KaijuSolutions.Agents.Movement
{
    /// <summary>
    /// Base movement class for moving in relation to a single target.
    /// </summary>
    public abstract class KaijuTargetMovement : KaijuMovement
    {
        /// <summary>
        /// The position to move in relation to.
        /// </summary>
        public Vector2? Target
        {
            get
            {
                if (!_transform)
                {
                    return _vector;
                }
                
                Vector3 p = _transform.position;
                return new(p.x, p.z);
            }
            set
            {
                _transform = null;
                _vector = value;
            }
        }
        
        /// <summary>
        /// The position to move in relation to.
        /// </summary>
        public Vector3? Target3
        {
            get => _transform ? _transform.position : _vector.HasValue ? new(_vector.Value.x, 0, _vector.Value.y) : null;
            set
            {
                _transform = null;
                _vector = value.HasValue ? new(value.Value.x, value.Value.z) : null;
            }
        }
        
        /// <summary>
        /// The <see href="https://docs.unity3d.com/Manual/class-Transform.html">transform</see> to move in relation to.
        /// </summary>
        public Transform TargetTransform
        {
            get => _transform;
            set
            {
                _transform = value;
                _vector = null;
            }
        }
        
        /// <summary>
        /// The <see href="https://docs.unity3d.com/Manual/class-GameObject.html">GameObject</see> to move in relation to.
        /// </summary>
        public GameObject TargetGameObject
        {
            get => _transform.gameObject;
            set
            {
                _transform = value.transform;
                _vector = null;
            }
        }
        
        /// <summary>
        /// The <see cref="KaijuAgent"/> to move in relation to.
        /// </summary>
        public KaijuAgent TargetAgent
        {
            get
            {
                Transform tr = TargetTransform;
                return tr ? tr.GetComponent<KaijuAgent>() : null;
            }
            set => TargetComponent = value;
        }
        
        /// <summary>
        /// The component to move in relation to.
        /// </summary>
        public Component TargetComponent
        {
            set
            {
                _transform = value.transform;
                _vector = null;
            }
        }
        
        /// <summary>
        /// The distance at which we can consider this behaviour done.
        /// </summary>
        public float Distance
        {
            get => _distance;
            set => _distance = Mathf.Max(0, value);
        }
        
        /// <summary>
        /// The current distance between the <see cref="KaijuAgent"/> and the target.
        /// </summary>
        public float CurrentDistance
        {
            get
            {
                Vector2? t = Target;
                return t.HasValue ? Vector2.Distance(t.Value, AgentPosition) : 0;
            }
        }
        
        /// <summary>
        /// The internal <see href="https://docs.unity3d.com/Manual/class-Transform.html">transform</see> value.
        /// </summary>
        private Transform _transform;
        
        /// <summary>
        /// The internal vector value.
        /// </summary>
        private Vector2? _vector;
        
        /// <summary>
        /// The distance at which we can consider this behaviour done.
        /// </summary>
        private float _distance;
        
        /// <summary>
        /// Create the target movement for a Vector2.
        /// </summary>
        /// <param name="agent">The agent this is assigned to.</param>
        /// <param name="target">The vector to move in relation to.</param>
        /// <param name="distance">The distance to consider this move done.</param>
        protected KaijuTargetMovement(KaijuAgent agent, Vector2 target, float distance) : base(agent)
        {
            Target = target;
            Distance = distance;
        }
        
        /// <summary>
        /// Create the target movement for a Vector3.
        /// </summary>
        /// <param name="agent">The agent this is assigned to.</param>
        /// <param name="target">The vector to move in relation to.</param>
        /// <param name="distance">The distance to consider this move done.</param>
        protected KaijuTargetMovement(KaijuAgent agent, Vector3 target, float distance) : base(agent)
        {
            Target3 = target;
            Distance = distance;
        }
        
        /// <summary>
        /// Create the target movement for a <see href="https://docs.unity3d.com/Manual/class-Transform.html">transform</see>.
        /// </summary>
        /// <param name="agent">The agent this is assigned to.</param>
        /// <param name="target">The <see href="https://docs.unity3d.com/Manual/class-Transform.html">transform</see> to move in relation to.</param>
        /// <param name="distance">The distance to consider this move done.</param>
        protected KaijuTargetMovement(KaijuAgent agent, Transform target, float distance) : base(agent)
        {
            TargetTransform = target;
            Distance = distance;
        }
        
        /// <summary>
        /// Create the target movement for a <see href="https://docs.unity3d.com/Manual/class-GameObject.html">GameObject</see>.
        /// </summary>
        /// <param name="agent">The agent this is assigned to.</param>
        /// <param name="target">The <see href="https://docs.unity3d.com/Manual/class-GameObject.html">GameObject</see> to move in relation to.</param>
        /// <param name="distance">The distance to consider this move done.</param>
        protected KaijuTargetMovement(KaijuAgent agent, GameObject target, float distance) : base(agent)
        {
            TargetGameObject = target;
            Distance = distance;
        }
        
        /// <summary>
        /// Create the target movement for a component.
        /// </summary>
        /// <param name="agent">The agent this is assigned to.</param>
        /// <param name="target">The component to move in relation to.</param>
        /// <param name="distance">The distance to consider this move done.</param>
        protected KaijuTargetMovement(KaijuAgent agent, Component target, float distance) : base(agent)
        {
            TargetComponent = target;
            Distance = distance;
        }
        
        /// <summary>
        /// Get the movement.
        /// </summary>
        /// <returns>The calculated movement.</returns>
        public override Vector2 Move()
        {
            Vector2? t = Target;
            return Agent && t.HasValue ? Calculate(AgentPosition, Agent.Velocity, Agent.Speed, t.Value) : Vector2.zero;
        }
        
        /// <summary>
        /// Calculate the movement.
        /// </summary>
        /// <param name="position">The agent's current position.</param>
        /// <param name="velocity">The agent's current velocity.</param>
        /// <param name="speed">The agent's maximum movement speed.</param>
        /// <param name="target">The position to move in relation to.</param>
        /// <returns>The calculated movement.</returns>
        protected abstract Vector2 Calculate(Vector2 position, Vector2 velocity, float speed, Vector2 target);
        
        /// <summary>
        /// Get a description of the object.
        /// </summary>
        /// <returns>A description of the object.</returns>
        public override string ToString()
        {
            Vector2? t = Target;
            return $"Kaiju Target Movement - Agent: {(Agent ? Agent.name : "None")} - Target: {(t.HasValue ? t.Value.ToString() : "None")} - Distance: {Distance} - Current Distance: {CurrentDistance} - {(Done() ? "Done" : "Executing")}";
        }
        
        /// <summary>
        /// Implicit conversion to a nullable Vector2 from the target.
        /// </summary>
        /// <param name="t">The target movement.</param>
        /// <returns>The target.</returns>
        public static implicit operator Vector2?([NotNull] KaijuTargetMovement t) => t.Target;
        
        /// <summary>
        /// Implicit conversion to a Vector2 from the target.
        /// </summary>
        /// <param name="t">The target movement.</param>
        /// <returns>The target.</returns>
        public static implicit operator Vector2([NotNull] KaijuTargetMovement t) => t.Target ?? Vector2.zero;
        
        /// <summary>
        /// Implicit conversion to a nullable Vector3 from the target.
        /// </summary>
        /// <param name="t">The target movement.</param>
        /// <returns>The target.</returns>
        public static implicit operator Vector3?([NotNull] KaijuTargetMovement t) => t.Target3;
        
        /// <summary>
        /// Implicit conversion to a Vector3 from the target.
        /// </summary>
        /// <param name="t">The target movement.</param>
        /// <returns>The target.</returns>
        public static implicit operator Vector3([NotNull] KaijuTargetMovement t) => t.Target3 ?? Vector3.zero;
        
        /// <summary>
        /// Implicit conversion to a <see href="https://docs.unity3d.com/Manual/class-Transform.html">transform</see> from the target.
        /// </summary>
        /// <param name="t">The target movement.</param>
        /// <returns>The target <see href="https://docs.unity3d.com/Manual/class-Transform.html">transform</see>.</returns>
        public static implicit operator Transform([NotNull] KaijuTargetMovement t) => t.TargetTransform;
        
        /// <summary>
        /// Implicit conversion to a <see href="https://docs.unity3d.com/Manual/class-GameObject.html">GameObject</see> from the target.
        /// </summary>
        /// <param name="t">The target movement.</param>
        /// <returns>The target <see href="https://docs.unity3d.com/Manual/class-GameObject.html">GameObject</see>.</returns>
        public static implicit operator GameObject([NotNull] KaijuTargetMovement t) => t.TargetGameObject;

        /// <summary>
        /// Implicit conversion to a <see cref="KaijuAgent"/> from the target.
        /// </summary>
        /// <param name="t">The target movement.</param>
        /// <returns>The target <see cref="KaijuAgent"/> from the target.</returns>
        public static implicit operator KaijuAgent([NotNull] KaijuTargetMovement t) => t.TargetAgent;
        
        /// <summary>
        /// Implicit conversion to a Boolean based on if this is done or not.
        /// </summary>
        /// <param name="t">The target movement.</param>
        /// <returns>If this is done or not.</returns>
        public static implicit operator bool([NotNull] KaijuTargetMovement t) => t.Done();
        
        /// <summary>
        /// Implicit conversion to a float from the <see cref="CurrentDistance"/>.
        /// </summary>
        /// <param name="t">The target movement.</param>
        /// <returns>The <see cref="CurrentDistance"/>.</returns>
        public static implicit operator float([NotNull] KaijuTargetMovement t) => t.CurrentDistance;
        
        /// <summary>
        /// Implicit conversion to a nullable float from the <see cref="CurrentDistance"/>.
        /// </summary>
        /// <param name="t">The target movement.</param>
        /// <returns>The <see cref="CurrentDistance"/>.</returns>
        public static implicit operator float?([NotNull] KaijuTargetMovement t) => t.CurrentDistance;
        
        /// <summary>
        /// Implicit conversion to a double from the <see cref="CurrentDistance"/>.
        /// </summary>
        /// <param name="t">The target movement.</param>
        /// <returns>The <see cref="CurrentDistance"/>.</returns>
        public static implicit operator double([NotNull] KaijuTargetMovement t) => t.CurrentDistance;
        
        /// <summary>
        /// Implicit conversion to a nullable double from the <see cref="CurrentDistance"/>.
        /// </summary>
        /// <param name="t">The target movement.</param>
        /// <returns>The <see cref="CurrentDistance"/>.</returns>
        public static implicit operator double?([NotNull] KaijuTargetMovement t) => t.CurrentDistance;
    }
}