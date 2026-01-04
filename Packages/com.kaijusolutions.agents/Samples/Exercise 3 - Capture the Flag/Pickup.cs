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
    }
}