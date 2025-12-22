using System;
using System.Diagnostics.CodeAnalysis;
using UnityEngine;

namespace KaijuSolutions.Agents
{
    /// <summary>
    /// Kaiju Agent which moves via a <see href="https://docs.unity3d.com/Manual/character-control-section.html">chracter controller</see>.
    /// </summary>
#if UNITY_EDITOR
    [SelectionBase]
    [DisallowMultipleComponent]
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
            gameObject.AssignComponent(ref character);
        }
        
        /// <summary>
        /// Update is called every frame, if the MonoBehaviour is enabled.
        /// </summary>
        private void Update()
        {
            // When on the ground, keep a minimal velocity to stay grounded, and add it when in the air.
            float delta = Time.deltaTime;
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