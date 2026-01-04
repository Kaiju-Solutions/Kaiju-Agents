using UnityEngine;

namespace KaijuSolutions.Agents.Exercises.CTF
{
    /// <summary>
    /// Troopers who aim to capture the enemy flag and defend their own.
    /// They have a <see cref="Health"/> value and have a blaster to battle the other team with.
    /// Walking into either the flag, a <see cref="HealthPickup"/> or an <see cref="AmmoPickup"/> will automatically interact with them.
    /// </summary>
    [RequireComponent(typeof(Collider))]
    [RequireComponent(typeof(Rigidbody))]
    [RequireComponent(typeof(KaijuRigidbodyAgent))]
    [AddComponentMenu("Kaiju Solutions/Agents/Exercises/Capture the Flag/Trooper", 23)]
    public class Trooper : KaijuController
    {
        /// <summary>
        /// The current health of this trooper.
        /// </summary>
        public int Health { get; private set; }
    }
}