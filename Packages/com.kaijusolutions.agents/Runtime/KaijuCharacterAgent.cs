using System.Diagnostics.CodeAnalysis;
using UnityEngine;

namespace KaijuSolutions.Agents
{
    /// <summary>
    /// Kaiju Agent which moves via a <see href="https://docs.unity3d.com/Manual/character-control-section.html">chracter controller</see>.
    /// </summary>
    [DisallowMultipleComponent]
#if UNITY_EDITOR
    [SelectionBase]
    [AddComponentMenu("Kaiju Solutions/Agents/Kaiju Character Agent", 2)]
    [Icon("Packages/com.kaijusolutions.agents/Editor/Icon.png")]
    [HelpURL("https://agents.kaijusolutions.ca/manual/getting-started.html")]
#endif
    [RequireComponent(typeof(CharacterController))]
    public sealed class KaijuCharacterAgent : KaijuAgent
    {
        /// <summary>
        /// The <see href="https://docs.unity3d.com/Manual/character-control-section.html">chracter controller</see> which controls the agent's movement.
        /// </summary>
#if UNITY_EDITOR
        [Tooltip("The character controller which controls the agent's movement.")]
#endif
        [SerializeField]
        private CharacterController character;
        
        private float _velocityY;
        
        /// <summary>
        /// The <see href="https://docs.unity3d.com/Manual/character-control-section.html">chracter controller</see> which controls the agent's movement.
        /// </summary>
        public CharacterController Character => character;
        
        /// <summary>
        /// Initialize the agent.
        /// </summary>
        public override void Setup()
        {
            gameObject.AssignComponent(ref character);
        }
        
        /// <summary>
        /// Perform agent movement.
        /// </summary>
        /// <param name="delta">The time step.</param>
        public override void Move(float delta)
        {
            // When on the ground, keep a minimal velocity to stay grounded, and add it when in the air.
            float gravity = Physics.gravity.y * delta;
            if (Character.isGrounded)
            {
                _velocityY = gravity;
            }
            else
            {
                _velocityY += gravity;
            }
            
            CalculateVelocity(delta);
            Vector2 scaled = Velocity * delta;
            Character.Move(new(scaled.x, _velocityY, scaled.y));
        }
        
        /// <summary>
        /// Get a description of the object.
        /// </summary>
        /// <returns>A description of the object.</returns>
        public override string ToString()
        {
            return $"Kaiju Character Agent {name} - {(isActiveAndEnabled ? "Active" : "Inactive")} - Velocity: {Velocity} - Max Speed: {Speed}";
        }
        
        /// <summary>
        /// Implicit conversion to get the <see href="https://docs.unity3d.com/Manual/character-control-section.html">chracter controller</see>.
        /// </summary>
        /// <param name="a">The agent.</param>
        /// <returns>The <see href="https://docs.unity3d.com/Manual/character-control-section.html">chracter controller</see> of the agent.</returns>
        public static implicit operator CharacterController([NotNull] KaijuCharacterAgent a) => a.character;
    }
}