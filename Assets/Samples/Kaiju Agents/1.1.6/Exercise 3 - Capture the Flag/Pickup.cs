using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using UnityEngine;

namespace KaijuSolutions.Agents.Exercises.CTF
{
    /// <summary>
    /// Base pickup class for <see cref="Trooper"/>s to pickup.
    /// </summary>
    [DefaultExecutionOrder(int.MinValue)]
    [DisallowMultipleComponent]
    [RequireComponent(typeof(Collider))]
    [HelpURL("https://agents.kaijusolutions.ca/manual/capture-the-flag.html")]
    public abstract class Pickup : KaijuBehaviour
    {
        /// <summary>
        /// What to do when interacted with.
        /// </summary>
        /// <param name="trooper">The <see cref="Trooper"/> interracting with this.</param>
        /// <returns>If the interaction was successful or not.</returns>
        public abstract bool Interact([NotNull] Trooper trooper);
        
        /// <summary>
        /// All colliders attached to this.
        /// </summary>
        protected IReadOnlyList<Collider> Colliders => _colliders;
        
        /// <summary>
        /// All colliders attached to this.
        /// </summary>
        private Collider[] _colliders;
        
        /// <summary>
        /// All renderers attached to this.
        /// </summary>
        protected IReadOnlyList<MeshRenderer> Renderers => _renderers;
        
        /// <summary>
        /// All renderers attached to this.
        /// </summary>
        private MeshRenderer[] _renderers;
        
        /// <summary>
        /// This function is called when the object becomes enabled and active.
        /// </summary>
        protected virtual void OnEnable()
        {
            // Gather all renderers.
            _renderers ??= GetComponentsInChildren<MeshRenderer>();
            
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
        protected virtual void OnValidate()
        {
            foreach (Collider c in GetComponentsInChildren<Collider>())
            {
                c.isTrigger = true;
            }
        }
    }
}