using System.Diagnostics.CodeAnalysis;
using KaijuSolutions.Agents.Extension;
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif
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
        public Vector2 Target
        {
            get => _transform ? _transform.position.Flatten() : _vector ?? (Agent ? Agent.transform.position : Vector2.zero);
            set
            {
                _transform = null;
                _vector = value;
            }
        }
        
        /// <summary>
        /// The position to move in relation to.
        /// </summary>
        public Vector3 Target3
        {
            get => _transform ? _transform.position : _vector.HasValue ? new(_vector.Value.x, 0, _vector.Value.y) : Agent ? Agent.transform.position : Vector3.zero;
            set
            {
                _transform = null;
                _vector = value.Flatten();
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
            get => _transform ? _transform.GetComponent<KaijuAgent>() : null;
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
        public float CurrentDistance => Vector2.Distance(Target, Agent.Position);
        
        /// <summary>
        /// The current distance between the <see cref="KaijuAgent"/> and the target across all axes.
        /// </summary>
        public float CurrentDistance3 => Vector3.Distance(Target3, Agent.Position3);
        
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
        /// <param name="weight">The weight of this movement.</param>
        protected KaijuTargetMovement([NotNull] KaijuAgent agent, Vector2 target, float distance, float weight = 1) : base(agent, weight)
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
        /// <param name="weight">The weight of this movement.</param>
        protected KaijuTargetMovement([NotNull] KaijuAgent agent, Vector3 target, float distance, float weight = 1) : base(agent, weight)
        {
            Target3 = target;
            Distance = distance;
        }
        
        /// <summary>
        /// Create the target movement for a <see href="https://docs.unity3d.com/Manual/class-GameObject.html">GameObject</see>.
        /// </summary>
        /// <param name="agent">The agent this is assigned to.</param>
        /// <param name="target">The <see href="https://docs.unity3d.com/Manual/class-GameObject.html">GameObject</see> to move in relation to.</param>
        /// <param name="distance">The distance to consider this move done.</param>
        /// <param name="weight">The weight of this movement.</param>
        protected KaijuTargetMovement([NotNull] KaijuAgent agent, [NotNull] GameObject target, float distance, float weight = 1) : base(agent, weight)
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
        /// <param name="weight">The weight of this movement.</param>
        protected KaijuTargetMovement([NotNull] KaijuAgent agent, [NotNull] Component target, float distance, float weight = 1) : base(agent, weight)
        {
            TargetComponent = target;
            Distance = distance;
        }
        
        /// <summary>
        /// Initialize the movement.
        /// </summary>
        /// <param name="agent">The agent this is assigned to.</param>
        /// <param name="target">The vector to move in relation to.</param>
        /// <param name="distance">The distance to consider this move done.</param>
        /// <param name="weight">The weight of this movement.</param>
        public void Initialize([NotNull] KaijuAgent agent, Vector2 target, float distance, float weight = 1)
        {
            Target = target;
            Distance = distance;
            Initialize(agent, weight);
        }
        
        /// <summary>
        /// Initialize the movement.
        /// </summary>
        /// <param name="agent">The agent this is assigned to.</param>
        /// <param name="target">The vector to move in relation to.</param>
        /// <param name="distance">The distance to consider this move done.</param>
        /// <param name="weight">The weight of this movement.</param>
        public void Initialize([NotNull] KaijuAgent agent, Vector3 target, float distance, float weight = 1)
        {
            Target3 = target;
            Distance = distance;
            Initialize(agent, weight);
        }
        
        /// <summary>
        /// Initialize the movement.
        /// </summary>
        /// <param name="agent">The agent this is assigned to.</param>
        /// <param name="target">The <see href="https://docs.unity3d.com/Manual/class-GameObject.html">GameObject</see> to move in relation to.</param>
        /// <param name="distance">The distance to consider this move done.</param>
        /// <param name="weight">The weight of this movement.</param>
        public void Initialize([NotNull] KaijuAgent agent, [NotNull] GameObject target, float distance, float weight = 1)
        {
            TargetGameObject = target;
            Distance = distance;
            Initialize(agent, weight);
        }
        
        /// <summary>
        /// Initialize the movement.
        /// </summary>
        /// <param name="agent">The agent this is assigned to.</param>
        /// <param name="target">The component to move in relation to.</param>
        /// <param name="distance">The distance to consider this move done.</param>
        /// <param name="weight">The weight of this movement.</param>
        public void Initialize([NotNull] KaijuAgent agent, [NotNull] Component target, float distance, float weight = 1)
        {
            TargetComponent = target;
            Distance = distance;
            Initialize(agent, weight);
        }
        
        /// <summary>
        /// Perform any needed reset operations.
        /// </summary>
        protected override void Reset()
        {
            base.Reset();
            _vector = null;
            _transform = null;
            _distance = 0;
        }
        
        /// <summary>
        /// Get the movement.
        /// </summary>
        /// <param name="position">The position of the <see cref="KaijuMovement.Agent"/>.</param>
        /// <param name="delta">The time step.</param>
        /// <returns>The calculated movement.</returns>
        public override Vector2 Move(Vector2 position, float delta)
        {
            return Agent ? Calculate(position, Agent.MoveSpeed, Target, delta) : Vector2.zero;
        }
        
        /// <summary>
        /// Determine if the movement is done or not.
        /// </summary>
        /// <returns>If the movement is done or not.</returns>
        public override bool Done()
        {
            return base.Done() || (!_transform && _vector == null);
        }
        
        /// <summary>
        /// Calculate the movement.
        /// </summary>
        /// <param name="position">The agent's current position.</param>
        /// <param name="speed">The agent's maximum movement speed.</param>
        /// <param name="target">The position to move in relation to.</param>
        /// <param name="delta">The time step.</param>
        /// <returns>The calculated movement.</returns>
        protected abstract Vector2 Calculate(Vector2 position, float speed, Vector2 target, float delta);
#if UNITY_EDITOR
        /// <summary>
        /// Render the visualization of the movement.
        /// <param name="position">The position of the <see cref="KaijuMovement.Agent"/>.</param>
        /// </summary>
        protected override void EditorRenderVisualizations(Vector3 position)
        {
            Vector3 t = Target3;
            Handles.DrawLine(position, t);
            RenderDistance(t);
        }
        
        /// <summary>
        /// Render the distance visualization.
        /// </summary>
        /// <param name="target">The target position.</param>
        protected void RenderDistance(Vector3 target)
        {
            // If there is a completion distance, render it.
            if (Distance is > 0 and < float.MaxValue)
            {
                Handles.DrawWireDisc(target, Vector3.up, Distance, 0);
            }
        }
#endif
        /// <summary>
        /// Get a description of the object.
        /// </summary>
        /// <returns>A description of the object.</returns>
        public override string ToString()
        {
            return $"Kaiju Target Movement - Agent: {(Agent ? Agent.name : "None")} - Target: {Target.ToString()} - Distance: {Distance} - Current Distance: {CurrentDistance} - Weight: {Weight} - {(Done() ? "Done" : "Executing")}";
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
        public static implicit operator Vector2([NotNull] KaijuTargetMovement t) => t.Target;
        
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
        public static implicit operator Vector3([NotNull] KaijuTargetMovement t) => t.Target3;
        
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
    }
}