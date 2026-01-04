using System;
using UnityEngine;

namespace KaijuSolutions.Agents.Exercises.CTF
{
    /// <summary>
    /// <see cref="Pickup"/> class which will restore some numeric value before going on cooldown.
    /// </summary>
    [RequireComponent(typeof(MeshFilter))]
    public abstract class NumberPickup : Pickup
    {
        /// <summary>
        /// The value to restore with this pickup.
        /// </summary>
        [field: Tooltip("The value to restore with this pickup.")]
        [field: Min(1)]
        [field: SerializeField]
        public int Value { get; private set; } = 100;
        
        /// <summary>
        /// How long in seconds this will be <see cref="OnCooldown"/> before it can be used again.
        /// </summary>
        [Tooltip("How long in seconds this will be on cooldown before it can be used again.")]
        [Min(float.Epsilon)]
        [SerializeField]
        private float cooldown = 10;
        
        /// <summary>
        /// If this pickup is currently on a cooldown.
        /// </summary>
        public bool OnCooldown => Cooldown > 0;
        
        /// <summary>
        /// The current cooldown time left in seconds on this pickup.
        /// </summary>
        public float Cooldown { get; private set; }
        
        /// <summary>
        /// All colliders attached to this which will be disabled when on cooldown.
        /// </summary>
        private Collider[] _colliders;
        
        /// <summary>
        /// All renderers attached to this which will be hidden when on cooldown.
        /// </summary>
        private MeshRenderer[] _renderers;
        
        /// <summary>
        /// This function is called when the object becomes enabled and active.
        /// </summary>
        private void OnEnable()
        {
            // Ensure we have components.
            _colliders ??= GetComponentsInChildren<Collider>();
            _renderers ??= GetComponentsInChildren<MeshRenderer>();
            
            // Start with no cooldown.
            Cooldown = 0;
            SetActive();
        }
        
        /// <summary>
        /// This function is called when the behaviour becomes disabled.
        /// </summary>
        private void OnDisable()
        {
            Cooldown = cooldown;
            SetActive();
        }

        /// <summary>
        /// What to do when interacted with.
        /// </summary>
        /// <returns>If the interaction was successful or not.</returns>
        public override bool Interact()
        {
            // Can't interact if cooling down.
            if (OnCooldown)
            {
                return false;
            }
            
            // Put this on cooldown if it was interacted with.
            Cooldown = cooldown;
            SetActive();
            return true;
        }
        
        /// <summary>
        /// Set the state of all colliders and meshes depending on if this is enabled.
        /// </summary>
        private void SetActive()
        {
            bool active = OnCooldown;
            
            foreach (Collider c in _colliders)
            {
                c.enabled = active;
            }
            
            foreach (MeshRenderer r in _renderers)
            {
                r.enabled = active;
            }
            
            OnSetActive(active);
        }
        
        /// <summary>
        /// Additional behaviour for when the active state of this has changed.
        /// </summary>
        /// <param name="active">If this is currently active or not.</param>
        protected abstract void OnSetActive(bool active);
        
        /// <summary>
        /// Frame-rate independent MonoBehaviour.FixedUpdate message for physics calculations.
        /// </summary>
        private void FixedUpdate()
        {
            // Tick down the cooldown if needed.
            if (!OnCooldown)
            {
                return;
            }
            
            Cooldown -= Time.deltaTime;
            
            // If the cooldown is done, enable this pickup again.
            if (Cooldown > 0)
            {
                return;
            }
            
            Cooldown = 0;
            SetActive();
        }
    }
}