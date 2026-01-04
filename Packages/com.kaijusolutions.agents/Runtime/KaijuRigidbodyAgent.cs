using System.Diagnostics.CodeAnalysis;
using UnityEngine;

namespace KaijuSolutions.Agents
{
    /// <summary>
    /// <see cref="KaijuAgent"/> which moves via a <see href="https://docs.unity3d.com/Manual/rigidbody-physics-section.html">rigidbody</see>.
    /// </summary>
    [DisallowMultipleComponent]
    [DefaultExecutionOrder(int.MinValue + 2)]
#if UNITY_EDITOR
    [SelectionBase]
    [AddComponentMenu("Kaiju Solutions/Agents/Kaiju Rigidbody Agent", 1)]
    [Icon("Packages/com.kaijusolutions.agents/Editor/Icon.png")]
    [HelpURL("https://agents.kaijusolutions.ca/manual/getting-started.html")]
#endif
    [RequireComponent(typeof(Rigidbody))]
    public sealed class KaijuRigidbodyAgent : KaijuRadiusAgent
    {
        /// <summary>
        /// If this <see cref="KaijuAgent"/> should move with the physics system.
        /// </summary>
        public override bool PhysicsAgent => true;
        
        /// <summary>
        /// The <see href="https://docs.unity3d.com/Manual/rigidbody-physics-section.html">rigidbody</see> which controls the <see cref="KaijuAgent"/>'s movement.
        /// </summary>
#if UNITY_EDITOR
        [Tooltip("The rigidbody which controls the agent's movement.")]
        [HideInInspector]
#endif
        [SerializeField]
        private Rigidbody body;
        
        /// <summary>
        /// The <see href="https://docs.unity3d.com/Manual/rigidbody-physics-section.html">rigidbody</see> which controls the <see cref="KaijuAgent"/>'s movement.
        /// </summary>
        public Rigidbody Body => body;
        
        /// <summary>
        /// This function is called when the behaviour becomes disabled.
        /// </summary>
        protected override void OnDisable()
        {
            if (body)
            {
                body.linearVelocity = Vector3.zero;
                body.angularVelocity = Vector3.zero;
            }
            
            base.OnDisable();
        }
        
        /// <summary>
        /// Initialize the <see cref="KaijuAgent"/>. There is no point in manually calling this.
        /// </summary>
        public override void Setup()
        {
            base.Setup();
            gameObject.AssignComponent(ref body);
            body.centerOfMass = Vector3.zero;
            body.constraints = body.constraints | RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ;
            body.linearDamping = 0;
            body.angularDamping = 0;
            body.interpolation = RigidbodyInterpolation.Interpolate;
            body.isKinematic = false;
            body.linearVelocity = Vector3.zero;
            body.angularVelocity = Vector3.zero;
        }
        
        /// <summary>
        /// Perform <see cref="KaijuAgent"/> movement. There is no point in manually calling this.
        /// </summary>
        /// <param name="delta">The time step.</param>
        public override void Move(float delta)
        {
            body.linearVelocity = new(Velocity.x, body.linearVelocity.y, Velocity.y);
            
            // Ensure the agent is not spinning outside of our own looking.
            body.angularVelocity = Vector3.zero;
        }
        
        /// <summary>
        /// Get a description of the object.
        /// </summary>
        /// <returns>A description of the object.</returns>
        public override string ToString()
        {
            return $"Kaiju Rigidbody Agent {name} - {(isActiveAndEnabled ? "Active" : "Inactive")} - Velocity: {Velocity} - Move Speed: {MoveSpeed} - Move Acceleration: {MoveAcceleration} - Look Speed: {LookSpeed}";
        }
        
        /// <summary>
        /// Implicit conversion to get the <see href="https://docs.unity3d.com/Manual/rigidbody-physics-section.html">rigidbody</see>.
        /// </summary>
        /// <param name="a">The <see cref="KaijuAgent"/>.</param>
        /// <returns>The <see href="https://docs.unity3d.com/Manual/rigidbody-physics-section.html">rigidbody</see> of the <see cref="KaijuAgent"/>.</returns>
        public static implicit operator Rigidbody([NotNull] KaijuRigidbodyAgent a) => a.body;
        
        /// <summary>
        /// Implicit conversion from a <see href="https://docs.unity3d.com/Manual/class-GameObject.html">GameObject</see>.
        /// </summary>
        /// <param name="o">The <see href="https://docs.unity3d.com/Manual/class-GameObject.html">GameObject</see>.</param>
        /// <returns>The <see cref="KaijuAgent"/> attached to the <see href="https://docs.unity3d.com/Manual/class-GameObject.html">GameObject</see> if there was one.</returns>
        public static implicit operator KaijuRigidbodyAgent([NotNull] GameObject o) => o.GetComponent<KaijuRigidbodyAgent>();
        
        /// <summary>
        /// Implicit conversion from a <see href="https://docs.unity3d.com/Manual/class-transform.html">transform</see>.
        /// </summary>
        /// <param name="t">The <see href="https://docs.unity3d.com/Manual/class-transform.html">transform</see>.</param>
        /// <returns>The <see cref="KaijuAgent"/> attached to the <see href="https://docs.unity3d.com/Manual/class-transform.html">transform</see> if there was one.</returns>
        public static implicit operator KaijuRigidbodyAgent([NotNull] Transform t) => t.GetComponent<KaijuRigidbodyAgent>();
    }
}