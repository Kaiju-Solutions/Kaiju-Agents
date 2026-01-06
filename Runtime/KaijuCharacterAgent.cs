using System.Diagnostics.CodeAnalysis;
using UnityEngine;

namespace KaijuSolutions.Agents
{
    /// <summary>
    /// <see cref="KaijuAgent"/> which moves via a <see href="https://docs.unity3d.com/Manual/character-control-section.html">chracter controller</see>.
    /// </summary>
    [DisallowMultipleComponent]
    [DefaultExecutionOrder(int.MinValue + 2)]
#if UNITY_EDITOR
    [SelectionBase]
    [AddComponentMenu("Kaiju Solutions/Agents/Kaiju Character Agent", 2)]
    [Icon("Packages/com.kaijusolutions.agents/Editor/Icon.png")]
    [HelpURL("https://agents.kaijusolutions.ca/manual/agents.html")]
#endif
    [RequireComponent(typeof(CharacterController))]
    public sealed class KaijuCharacterAgent : KaijuAgent
    {
        /// <summary>
        /// The <see href="https://docs.unity3d.com/Manual/character-control-section.html">chracter controller</see> which controls the <see cref="KaijuAgent"/>'s movement.
        /// </summary>
#if UNITY_EDITOR
        [Tooltip("The character controller which controls the agent's movement.")]
        [HideInInspector]
#endif
        [SerializeField]
        private CharacterController character;
        
        /// <summary>
        /// If gravity should be applied to the <see cref="KaijuAgent"/>.
        /// </summary>
#if UNITY_EDITOR
        [Tooltip("If gravity should be applied to the agent.")]
#endif
        public bool gravity;
        
        /// <summary>
        /// The cached gravity of the <see cref="KaijuAgent"/>.
        /// </summary>
        private float _velocityY;
        
        /// <summary>
        /// The <see href="https://docs.unity3d.com/Manual/character-control-section.html">chracter controller</see> which controls the <see cref="KaijuAgent"/>'s movement.
        /// </summary>
        public CharacterController Character => character;
        
        /// <summary>
        /// Callback before updating the position.
        /// </summary>
        private void PreSetPosition()
        {
            // This needs to be disabled to set the position.
            if (character)
            {
                character.enabled = false;
            }
        }
        
        /// <summary>
        /// Callback after updating the position.
        /// </summary>
        private void PostSetPosition()
        {
            // Enable after the position has been set.
            if (character)
            {
                character.enabled = true;
            }
        }
        
        /// <summary>
        /// This function is called when the object becomes enabled and active.
        /// </summary>
        protected override void OnEnable()
        {
            OnPreSetPosition += PreSetPosition;
            OnSetPosition += PostSetPosition;
            base.OnEnable();
        }

        /// <summary>
        /// This function is called when the behaviour becomes disabled.
        /// </summary>
        protected override void OnDisable()
        {
            OnPreSetPosition -= PreSetPosition;
            OnSetPosition -= PostSetPosition;
            _velocityY = 0;
            base.OnDisable();
        }
        
        /// <summary>
        /// Initialize the <see cref="KaijuAgent"/>. There is no point in manually calling this.
        /// </summary>
        public override void Setup()
        {
            base.Setup();
            _velocityY = 0;
            gameObject.AssignComponent(ref character);
            character.enabled = true;
        }
        
        /// <summary>
        /// Get the radius of an <see cref="KaijuAgent"/>.
        /// </summary>
        /// <returns>The radius of the <see cref="KaijuAgent"/>.</returns>
        public override float GetRadius()
        {
            return character ? character.radius : 0;
        }
        
        /// <summary>
        /// Perform <see cref="KaijuAgent"/> movement. There is no point in manually calling this.
        /// </summary>
        /// <param name="delta">The time step.</param>
        public override void Move(float delta)
        {
            // Handle gravity if it is enabled.
            if (gravity)
            {
                // When on the ground, keep a minimal velocity to stay grounded, and add it when in the air.
                float g = Physics.gravity.y * delta;
                if (Character.isGrounded)
                {
                    _velocityY = g;
                }
                else
                {
                    _velocityY += g;
                }
            }
            else
            {
                _velocityY = 0;
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
        /// <param name="a">The agent</param>
        /// <returns>The <see href="https://docs.unity3d.com/Manual/character-control-section.html">chracter controller</see> of the agent.</returns>
        public static implicit operator CharacterController([NotNull] KaijuCharacterAgent a) => a.character;
        
        /// <summary>
        /// Implicit conversion from a <see href="https://docs.unity3d.com/Manual/class-GameObject.html">GameObject</see>.
        /// </summary>
        /// <param name="o">The <see href="https://docs.unity3d.com/Manual/class-GameObject.html">GameObject</see>.</param>
        /// <returns>The agent attached to the <see href="https://docs.unity3d.com/Manual/class-GameObject.html">GameObject</see> if there was one.</returns>
        public static implicit operator KaijuCharacterAgent([NotNull] GameObject o) => o.GetComponent<KaijuCharacterAgent>();
        
        /// <summary>
        /// Implicit conversion from a <see href="https://docs.unity3d.com/Manual/class-transform.html">transform</see>.
        /// </summary>
        /// <param name="t">The <see href="https://docs.unity3d.com/Manual/class-transform.html">transform</see>.</param>
        /// <returns>The agent attached to the <see href="https://docs.unity3d.com/Manual/class-transform.html">transform</see> if there was one.</returns>
        public static implicit operator KaijuCharacterAgent([NotNull] Transform t) => t.GetComponent<KaijuCharacterAgent>();
    }
}