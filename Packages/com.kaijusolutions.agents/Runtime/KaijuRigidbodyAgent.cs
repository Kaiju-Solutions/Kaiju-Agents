using System.Diagnostics.CodeAnalysis;
using UnityEngine;

namespace KaijuSolutions.Agents
{
    /// <summary>
    /// Kaiju Agent which moves via a <see href="https://docs.unity3d.com/Manual/rigidbody-physics-section.html">rigidbody</see>.
    /// </summary>
#if UNITY_EDITOR
    [SelectionBase]
    [DisallowMultipleComponent]
    [AddComponentMenu("Kaiju Solutions/Agents/Kaiju Rigidbody Agent", 1)]
    [Icon("Packages/com.kaijusolutions.agents/Editor/Icon.png")]
    [HelpURL("https://agents.kaijusolutions.ca/manual/getting-started.html")]
#endif
    [RequireComponent(typeof(Rigidbody))]
    public sealed class KaijuRigidbodyAgent : KaijuAgent
    {
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
#if UNITY_EDITOR
        /// <summary>
        /// Editor-only function that Unity calls when the script is loaded or a value changes in the Inspector.
        /// </summary>
        private void OnValidate()
        {
            Setup();
        }
#endif
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
        /// Frame-rate independent MonoBehaviour.FixedUpdate message for physics calculations.
        /// </summary>
        private void FixedUpdate()
        {
            CalculateVelocity(Time.deltaTime);
            body.linearVelocity = new(Velocity.x, body.linearVelocity.y, Velocity.y);
        }
        
        /// <summary>
        /// Get a description of the object.
        /// </summary>
        /// <returns>A description of the object.</returns>
        public override string ToString()
        {
            return $"Kaiju Rigidbody Agent {name} - {(isActiveAndEnabled ? "Active" : "Inactive")} - Velocity: {Velocity} - Max Speed: {Speed}";
        }
        
        /// <summary>
        /// Implicit conversion to get the <see href="https://docs.unity3d.com/Manual/rigidbody-physics-section.html">rigidbody</see>.
        /// </summary>
        /// <param name="a">The agent.</param>
        /// <returns>The <see href="https://docs.unity3d.com/Manual/rigidbody-physics-section.html">rigidbody</see> of the agent.</returns>
        public static implicit operator Rigidbody([NotNull] KaijuRigidbodyAgent a) => a.body;
    }
}