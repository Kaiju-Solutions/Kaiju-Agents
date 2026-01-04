using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using KaijuSolutions.Agents.Actuators;
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
    [AddComponentMenu("Kaiju Solutions/Agents/Exercises/Capture the Flag/Trooper", 25)]
    public class Trooper : KaijuController
    {
        // TODO - Event definitions.
        
        /// <summary>
        /// All troopers currently active for team one.
        /// </summary>
        public static IReadOnlyCollection<Trooper> AllOne => ActiveOne;
        
        /// <summary>
        /// The active troopers for team one.
        /// </summary>
        private static readonly HashSet<Trooper> ActiveOne = new();
        
        /// <summary>
        /// All troopers currently active for team two.
        /// </summary>
        public static IReadOnlyCollection<Trooper> AllTwo => ActiveTwo;
        
        /// <summary>
        /// The active troopers for team two.
        /// </summary>
        private static readonly HashSet<Trooper> ActiveTwo = new();
        
        /// <summary>
        /// Cache the trooper type which is needed from cached agents.
        /// </summary>
        private static readonly Type[] Types = { typeof(Trooper) };
        
        /// <summary>
        /// Handle manually resetting the domain.
        /// </summary>
        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.SubsystemRegistration)]
        private static void InitOnPlayMode()
        {
            ActiveOne.Clear();
            ActiveTwo.Clear();
        }
        
        /// <summary>
        /// The current health of this trooper.
        /// </summary>
        public int Health { get; private set; }
        
        /// <summary>
        /// What team this trooper is on.
        /// </summary>
        public bool TeamOne { get; private set; } = true;
        
        /// <summary>
        /// The <see cref="BlasterActuator"/> of the trooper.
        /// </summary>
        private BlasterActuator _blaster;
        
        /// <summary>
        /// The ammo for this <see cref="Trooper"/>'s <see cref="BlasterActuator"/>.
        /// </summary>
        public int Ammo
        {
            get => _blaster != null ? _blaster.Ammo : 0;
            private set
            {
                if (_blaster != null)
                {
                    _blaster.Ammo = value;
                }
            }
        }
        
        /// <summary>
        /// If the <see cref="BlasterActuator"/> has any ammo.
        /// </summary>
        public bool HasAmmo => _blaster != null && _blaster.Ammo > 0;
        
        /// <summary>
        /// If the <see cref="BlasterActuator"/> has any ammo is is not <see cref="KaijuAttackActuator.OnCooldown"/>.
        /// </summary>
        public bool CanAttack => HasAmmo && !_blaster.OnCooldown;
        
        /// <summary>
        /// Spawn a trooper.
        /// </summary>
        /// <param name="trooperPrefab">The trooper prefab to spawn.</param>
        /// <param name="spawnPoint">The <see cref="SpawnPoint"/> to spawn the trooper at.</param>
        public static void Spawn([NotNull] KaijuAgent trooperPrefab, [NotNull] SpawnPoint spawnPoint)
        {
            // Get team values.
            uint team;
            Color color;
            if (spawnPoint.TeamOne)
            {
                team = 1;
                color = CaptureTheFlagManager.ColorOne;
            }
            else
            {
                team = 2;
                color = CaptureTheFlagManager.ColorTwo;
            }
            
            // Spawn the agent.
            Transform t = spawnPoint.transform;
            KaijuAgent agent = KaijuAgents.Spawn(KaijuAgentType.Rigidbody, t.position, t.rotation, true, trooperPrefab, $"Trooper {team}", color, Color.black, Types);
            if (!agent.TryGetComponent(out Trooper trooper))
            {
                trooper = agent.gameObject.AddComponent<Trooper>();
            }
            
            // Assign to the correct team.
            agent.SetIdentifier(team);
            trooper.TeamOne = spawnPoint.TeamOne;
            if (trooper.TeamOne)
            {
                ActiveTwo.Remove(trooper);
                ActiveOne.Add(trooper);
            }
            else
            {
                ActiveOne.Remove(trooper);
                ActiveTwo.Add(trooper);
            }
            
            // Set trooper health and ammo to max.
            trooper.Health = CaptureTheFlagManager.Health;
            trooper.Ammo = CaptureTheFlagManager.Ammo;
        }
        
        /// <summary>
        /// Take damage from another trooper.
        /// </summary>
        /// <param name="attacker">The trooper that dealt the damage.</param>
        public void TakeDamage([NotNull] Trooper attacker)
        {
            Health -= CaptureTheFlagManager.Damage;
            
            if (Health > 0)
            {
                // TODO - Hit events.
                return;
            }
            
            // TODO - Killed events.
        }
        
        /// <summary>
        /// Fire the <see cref="BlasterActuator"/>.
        /// </summary>
        public void Attack()
        {
            if (_blaster != null)
            {
                _blaster.Begin();
            }
        }
        
        /// <summary>
        /// This function is called when the object becomes enabled and active.
        /// </summary>
        protected override void OnEnable()
        {
            base.OnEnable();
            Health = CaptureTheFlagManager.Health;
            Ammo = CaptureTheFlagManager.Ammo;
            
            // Assign to the correct team.
            if (TeamOne)
            {
                ActiveTwo.Remove(this);
                ActiveOne.Add(this);
            }
            else
            {
                ActiveOne.Remove(this);
                ActiveTwo.Add(this);
            }
        }
        
        /// <summary>
        /// This function is called when the behaviour becomes disabled.
        /// </summary>
        protected override void OnDisable()
        {
            base.OnDisable();
            
            // Remove from any active pools.
            ActiveOne.Remove(this);
            ActiveTwo.Remove(this);
            
            // Reset values.
            Health = 0;
            Ammo = 0;
        }
        
        /// <summary>
        /// Callback for when an <see cref="KaijuActuator"/> has been enabled.
        /// </summary>
        /// <param name="actuator">The <see cref="KaijuActuator"/>.</param>
        protected override void OnActuatorEnabled(KaijuActuator actuator)
        {
            // Get the blaster.
            if (actuator is BlasterActuator blaster)
            {
                _blaster = blaster;
            }
        }
        
        /// <summary>
        /// When a GameObject collides with another GameObject, Unity calls OnTriggerEnter. This function can be a coroutine.
        /// </summary>
        /// <param name="other">The other Collider involved in this collision.</param>
        private void OnTriggerEnter(Collider other)
        {
            HandleContacts(other.transform);
            
        }
        
        /// <summary>
        /// OnTriggerStay is called once per physics update for every Collider other that is touching the trigger. This function can be a coroutine.
        /// </summary>
        /// <param name="other">The other Collider involved in this collision.</param>
        private void OnTriggerStay(Collider other)
        {
            HandleContacts(other.transform);
        }
        
        /// <summary>
        /// Handle all contacts to see what we have contacted with.
        /// </summary>
        /// <param name="other">The other object interacted with.</param>
        private void HandleContacts(Transform other)
        {
            if (!other.TryGetComponent(out Pickup pickup))
            {
                return;
            }
            
            // Handle if it is a health or ammo pickup.
            if (pickup is NumberPickup number)
            {
                // If we can't interact with it, there is nothing to do.
                if (number.OnCooldown)
                {
                    return;
                }

                int value = number.Value;
                
                // Handle it as the proper type.
                if (number is HealthPickup health)
                {
                    // No point in using it if we already have the maximum health.
                    int max = CaptureTheFlagManager.Health;
                    if (Health >= max)
                    {
                        return;
                    }
                    
                    health.Interact();
                    Health = Mathf.Max(Health + value, max);
                    // TODO - Events.
                }
                else
                {
                    // No point in using it if we already have the maximum ammo.
                    int max = CaptureTheFlagManager.Ammo;
                    if (Ammo >= max)
                    {
                        return;
                    }
                    
                    number.Interact();
                    Ammo = Mathf.Max(Ammo + value, max);
                    // TODO - Events.
                }
                
                return;
            }
            
            // TODO - Flag pickup.
        }
    }
}