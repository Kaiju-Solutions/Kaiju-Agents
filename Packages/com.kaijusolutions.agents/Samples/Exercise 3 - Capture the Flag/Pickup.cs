using UnityEngine;

namespace KaijuSolutions.Agents.Exercises.CTF
{
    /// <summary>
    /// Base pickup class for <see cref="Trooper"/>s to pickup.
    /// </summary>
    [DefaultExecutionOrder(int.MinValue)]
    [DisallowMultipleComponent]
    [RequireComponent(typeof(Collider))]
    public abstract class Pickup : KaijuBehaviour
    {
        /// <summary>
        /// What to do when interacted with.
        /// </summary>
        /// <returns>If the interaction was successful or not.</returns>
        public abstract bool Interact();
        
        /// <summary>
        /// All colliders attached to this.
        /// </summary>
        private Collider[] _colliders;
        
        /// <summary>
        /// This function is called when the object becomes enabled and active.
        /// </summary>
        private void OnEnable()
        {
            // Ensure all colliders are triggers.
            if (_colliders != null)
            {
                return;
            }
            
            _colliders = GetComponentsInChildren<Collider>();
            foreach (Collider c in _colliders)
            {
                c.isTrigger = true;
            }
        }
        
        /// <summary>
        /// Editor-only function that Unity calls when the script is loaded or a value changes in the Inspector.
        /// </summary>
        private void OnValidate()
        {
            foreach (Collider c in GetComponentsInChildren<Collider>())
            {
                c.isTrigger = true;
            }
        }
    }
}