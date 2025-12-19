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
            if (gameObject.AssignComponent(ref character))
            {
                character.center = new(0, 1, 0);
            }
        }
        
        /// <summary>
        /// Get a description of the object.
        /// </summary>
        /// <returns>A description of the object.</returns>
        public override string ToString()
        {
            return "Kaiju Character Agent";
        }
    }
}