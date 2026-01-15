using System.Diagnostics.CodeAnalysis;
using UnityEngine;

namespace KaijuSolutions.Agents.Exercises.CTF
{
    /// <summary>
    /// <see cref="Pickup"/> class which will restore some numeric value before going on cooldown.
    /// </summary>
    [HelpURL("https://agents.kaijusolutions.ca/manual/capture-the-flag.html")]
    public abstract class NumberPickup : Pickup
    {
        /// <summary>
        /// If this pickup is currently on a cooldown.
        /// </summary>
        public bool OnCooldown => Cooldown > 0;
        
        /// <summary>
        /// The current cooldown time left in seconds on this pickup.
        /// </summary>
        public float Cooldown { get; private set; }
        
        /// <summary>
        /// This function is called when the object becomes enabled and active.
        /// </summary>
        protected override void OnEnable()
        {
            base.OnEnable();
            
            // Start with no cooldown.
            Cooldown = 0;
            SetActive();
        }
        
        /// <summary>
        /// This function is called when the behaviour becomes disabled.
        /// </summary>
        private void OnDisable()
        {
            Cooldown = 0;
            SetActive();
        }

        /// <summary>
        /// What to do when interacted with.
        /// </summary>
        /// <param name="trooper">The <see cref="Trooper"/> interracting with this.</param>
        /// <returns>If the interaction was successful or not.</returns>
        public override bool Interact([NotNull] Trooper trooper)
        {
            // Can't interact if cooling down.
            if (OnCooldown)
            {
                return false;
            }
            
            // Put this on cooldown if it was interacted with.
            Cooldown = CaptureTheFlagManager.Cooldown;
            SetActive();
            return true;
        }
        
        /// <summary>
        /// Set the state of all colliders and meshes depending on if this is enabled.
        /// </summary>
        private void SetActive()
        {
            bool active = !OnCooldown;
            
            foreach (Collider c in Colliders)
            {
                c.enabled = active;
            }
            
            foreach (MeshRenderer r in Renderers)
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