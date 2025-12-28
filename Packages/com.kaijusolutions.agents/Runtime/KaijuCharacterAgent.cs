using System.Diagnostics.CodeAnalysis;
using UnityEngine;

namespace KaijuSolutions.Agents
{
    /// <summary>
    /// Kaiju Agent which moves via a <see href="https://docs.unity3d.com/Manual/character-control-section.html">chracter controller</see>.
    /// </summary>
    [DisallowMultipleComponent]
    [DefaultExecutionOrder(int.MinValue + 2)]
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
        [HideInInspector]
#endif
        [SerializeField]
        private CharacterController character;
        
        /// <summary>
        /// The cached gravity of the agent.
        /// </summary>
        private float _velocityY;
        
        /// <summary>
        /// The <see href="https://docs.unity3d.com/Manual/character-control-section.html">chracter controller</see> which controls the agent's movement.
        /// </summary>
        public CharacterController Character => character;
        
        /// <summary>
        /// Callback before updating the transform.
        /// </summary>
        protected override void PreSetTransform()
        {
            // The character controller needs to be disabled to set the position.
            if (character)
            {
                character.enabled = false;
            }
        }
        
        /// <summary>
        /// Callback after updating the transform.
        /// </summary>
        protected override void PostSetTransform()
        {
            // Enable the character controller after the position has been set.
            if (character)
            {
                character.enabled = true;
            }
        }
        
        /// <summary>
        /// This function is called when the behaviour becomes disabled.
        /// </summary>
        protected override void OnDisable()
        {
            _velocityY = 0;
            base.OnDisable();
        }
        
        /// <summary>
        /// Initialize the agent.
        /// </summary>
        public override void Setup()
        {
            base.Setup();
            _velocityY = 0;
            gameObject.AssignComponent(ref character);
            character.enabled = true;
        }
        
        /// <summary>
        /// Get the radius of an agent.
        /// </summary>
        /// <returns>The radius of the agent.</returns>
        public override float GetRadius()
        {
            return character ? character.radius : 0;
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
            
            Vector2 scaled = Velocity * delta;
            Character.Move(new(scaled.x, _velocityY, scaled.y));
        }
        
        /// <summary>
        /// Get a description of the object.
        /// </summary>
        /// <returns>A description of the object.</returns>
        public override string ToString()
        {
            return $"Kaiju Character Agent {name} - {(isActiveAndEnabled ? "Active" : "Inactive")} - Velocity: {Velocity} - Move Speed: {MoveSpeed} - Move Acceleration: {MoveAcceleration} - Look Speed: {LookSpeed}";
        }
        
        /// <summary>
        /// Implicit conversion to get the <see href="https://docs.unity3d.com/Manual/character-control-section.html">chracter controller</see>.
        /// </summary>
        /// <param name="a">The agent.</param>
        /// <returns>The <see href="https://docs.unity3d.com/Manual/character-control-section.html">chracter controller</see> of the agent.</returns>
        public static implicit operator CharacterController([NotNull] KaijuCharacterAgent a) => a.character;
    }
}