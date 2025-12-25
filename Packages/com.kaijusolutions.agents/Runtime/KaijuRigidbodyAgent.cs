using System.Diagnostics.CodeAnalysis;
using UnityEngine;

namespace KaijuSolutions.Agents
{
    /// <summary>
    /// Kaiju Agent which moves via a <see href="https://docs.unity3d.com/Manual/rigidbody-physics-section.html">rigidbody</see>.
    /// </summary>
    [DisallowMultipleComponent]
#if UNITY_EDITOR
    [SelectionBase]
    [AddComponentMenu("Kaiju Solutions/Agents/Kaiju Rigidbody Agent", 1)]
    [Icon("Packages/com.kaijusolutions.agents/Editor/Icon.png")]
    [HelpURL("https://agents.kaijusolutions.ca/manual/getting-started.html")]
#endif
    [RequireComponent(typeof(Rigidbody))]
    public sealed class KaijuRigidbodyAgent : KaijuAgent
    {
        /// <summary>
        /// If this agent should move with the physics system.
        /// </summary>
        public override bool PhysicsAgent => true;
        
        /// <summary>
        /// The <see href="https://docs.unity3d.com/Manual/rigidbody-physics-section.html">rigidbody</see> which controls the agent's movement.
        /// </summary>
#if UNITY_EDITOR
        [Tooltip("The rigidbody which controls the agent's movement.")]
#endif
        [SerializeField]
        private Rigidbody body;
        
        /// <summary>
        /// The <see href="https://docs.unity3d.com/Manual/rigidbody-physics-section.html">rigidbody</see> which controls the agent's movement.
        /// </summary>
        public Rigidbody Body => body;
        
        /// <summary>
        /// Initialize the agent.
        /// </summary>
        public override void Setup()
        {
            gameObject.AssignComponent(ref body);
            body.centerOfMass = Vector3.zero;
            body.constraints = body.constraints | RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ;
            body.linearDamping = 0;
            body.angularDamping = 0;
            body.interpolation = RigidbodyInterpolation.Interpolate;
            body.isKinematic = false;
        }
        
        /// <summary>
        /// Perform agent movement.
        /// </summary>
        /// <param name="delta">The time step.</param>
        public override void Move(float delta)
        {
            body.linearVelocity = new(Velocity.x, body.linearVelocity.y, Velocity.y);
        }
        
        /// <summary>
        /// Get a description of the object.
        /// </summary>
        /// <returns>A description of the object.</returns>
        public override string ToString()
        {
            return $"Kaiju Rigidbody Agent {name} - {(isActiveAndEnabled ? "Active" : "Inactive")} - Velocity: {Velocity} - Max Speed: {MoveSpeed}";
        }
        
        /// <summary>
        /// Implicit conversion to get the <see href="https://docs.unity3d.com/Manual/rigidbody-physics-section.html">rigidbody</see>.
        /// </summary>
        /// <param name="a">The agent.</param>
        /// <returns>The <see href="https://docs.unity3d.com/Manual/rigidbody-physics-section.html">rigidbody</see> of the agent.</returns>
        public static implicit operator Rigidbody([NotNull] KaijuRigidbodyAgent a) => a.body;
    }
}