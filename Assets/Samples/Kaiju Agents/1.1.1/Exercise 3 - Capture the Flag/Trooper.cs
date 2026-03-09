using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using KaijuSolutions.Agents.Actuators;
using KaijuSolutions.Agents.Extensions;
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif
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
    [HelpURL("https://agents.kaijusolutions.ca/manual/capture-the-flag.html#trooper")]
    public class Trooper : KaijuController
    {
        /// <summary>
        /// Callback for hitting another trooper.
        /// </summary>
        public event TrooperAction OnHitTrooper;
        
        /// <summary>
        /// Callback for getting hit by another trooper.
        /// </summary>
        public event TrooperAction OnHitByTrooper;
        
        /// <summary>
        /// Global callback for one agent hitting another.
        /// </summary>
        public static MultiTrooperAction OnTrooperHitGlobal;
        
        /// <summary>
        /// Callback for eliminated another trooper.
        /// </summary>
        public event TrooperAction OnEliminatedTrooper;
        
        /// <summary>
        /// Callback for getting eliminated by another trooper.
        /// </summary>
        public event TrooperAction OnEliminatedByTrooper;
        
        /// <summary>
        /// Global callback for one trooper eliminating another.
        /// </summary>
        public static event MultiTrooperAction OnTrooperEliminatedGlobal;
        
        /// <summary>
        /// Callback for when this agent dropped the <see cref="Flag"/>.
        /// </summary>
        public event FlagAction OnFlagDropped;
        
        /// <summary>
        /// Global callback for when this agent dropped the <see cref="Flag"/>.
        /// </summary>
        public event TrooperFlagAction OnFlagDroppedGlobal;
        
        /// <summary>
        /// Callback for when this agent picking up the <see cref="Flag"/>.
        /// </summary>
        public event FlagAction OnFlagPickedUp;
        
        /// <summary>
        /// Global callback for when this agent picking up the <see cref="Flag"/>.
        /// </summary>
        public event TrooperFlagAction OnFlagPickedUpGlobal;
        
        /// <summary>
        /// Callback for when this agent returned the <see cref="Flag"/>.
        /// </summary>
        public event FlagAction OnFlagReturned;
        
        /// <summary>
        /// Global callback for when this agent returned the <see cref="Flag"/>.
        /// </summary>
        public event TrooperFlagAction OnFlagReturnedGlobal;
        
        /// <summary>
        /// Callback for when this agent captured the <see cref="Flag"/>.
        /// </summary>
        public event FlagAction OnFlagCaptured;
        
        /// <summary>
        /// Global callback for when this agent captured the <see cref="Flag"/>.
        /// </summary>
        public event TrooperFlagAction OnFlagCapturedGlobal;
        
        /// <summary>
        /// Callback for picking up a <see cref="HealthPickup"/>.
        /// </summary>
        public event HealthAction OnHealth;
        
        /// <summary>
        /// Global callback for picking up a <see cref="HealthPickup"/>.
        /// </summary>
        public event TrooperHealthAction OnHealthGlobal;
        
        /// <summary>
        /// Callback for picking up a <see cref="AmmoPickup"/>.
        /// </summary>
        public event AmmoAction OnAmmo;
        
        /// <summary>
        /// Global callback for picking up a <see cref="AmmoPickup"/>.
        /// </summary>
        public event TrooperAmmoAction OnAmmoGlobal;
        
        /// <summary>
        /// All troopers currently active.
        /// </summary>
        public static IReadOnlyCollection<Trooper> All
        {
            get
            {
#if UNITY_EDITOR
                if (!Application.isPlaying)
                {
                    return Array.Empty<Trooper>();
                }
#endif
                return Active;
            }
        }

        /// <summary>
        /// All active troopers.
        /// </summary>
        private static readonly HashSet<Trooper> Active = new();
        
        /// <summary>
        /// All troopers currently active for team one.
        /// </summary>
        public static IReadOnlyCollection<Trooper> AllOne
        {
            get
            {
#if UNITY_EDITOR
                if (!Application.isPlaying)
                {
                    return Array.Empty<Trooper>();
                }
#endif
                return ActiveOne;
            }
        }

        /// <summary>
        /// The active troopers for team one.
        /// </summary>
        private static readonly HashSet<Trooper> ActiveOne = new();
        
        /// <summary>
        /// All troopers currently active for team two.
        /// </summary>
        public static IReadOnlyCollection<Trooper> AllTwo
        {
            get
            {
#if UNITY_EDITOR
                if (!Application.isPlaying)
                {
                    return Array.Empty<Trooper>();
                }
#endif
                return ActiveTwo;
            }
        }
        
        /// <summary>
        /// The active troopers for team two.
        /// </summary>
        private static readonly HashSet<Trooper> ActiveTwo = new();
#if UNITY_EDITOR
        /// <summary>
        /// Handle manually resetting the domain.
        /// </summary>
        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.SubsystemRegistration)]
        private static void InitOnPlayMode()
        {
            Domain();
            EditorApplication.playModeStateChanged -= Domain;
            EditorApplication.playModeStateChanged += Domain;
        }
        
        /// <summary>
        /// Handle manually resetting the domain.
        /// </summary>
        /// <param name="state">The current editor state change.</param>
        private static void Domain(PlayModeStateChange state)
        {
            if (state != PlayModeStateChange.ExitingPlayMode)
            {
                return;
            }
            
            EditorApplication.playModeStateChanged -= Domain;
            Domain();
        }
        
        /// <summary>
        /// Handle manually resetting the domain.
        /// </summary>
        private static void Domain()
        {
            Active.Clear();
            ActiveOne.Clear();
            ActiveTwo.Clear();
        }
#endif
        /// <summary>
        /// The current health of this trooper.
        /// </summary>
        public int Health { get; private set; }
        
        /// <summary>
        /// What team this trooper is on.
        /// </summary>
        public bool TeamOne { get; private set; } = true;
        
        /// <summary>
        /// Get the location of this trooper's own base.
        /// </summary>
        public Vector2 OwnBase => Flag.Base(TeamOne);
        
        /// <summary>
        /// Get the location of this trooper's  own base.
        /// </summary>
        public Vector3 OwnBase3 => Flag.Base3(TeamOne);
        
        /// <summary>
        /// Get the location of the other team's base.
        /// </summary>
        public Vector2 EnemyBase => Flag.Base(!TeamOne);
        
        /// <summary>
        /// Get the location of the other team's base.
        /// </summary>
        public Vector3 EnemyBase3 => Flag.Base3(!TeamOne);
        
        /// <summary>
        /// The <see cref="BlasterActuator"/> of the trooper.
        /// </summary>
        private BlasterActuator _blaster;
        
        /// <summary>
        /// The flag being carried.
        /// </summary>
        private Flag _flag;
        
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
        /// If the <see cref="BlasterActuator"/> has any ammo and is not <see cref="KaijuAttackActuator.OnCooldown"/>.
        /// </summary>
        public bool CanAttack => HasAmmo && !_blaster.OnCooldown;
        
        /// <summary>
        /// Where to store the flag when picking it up.
        /// </summary>
        [field: Tooltip("Where to store the flag when picking it up.")]
        [field: SerializeField]
        public Transform FlagPosition { get; private set; }
        
        /// <summary>
        /// Spawn a trooper.
        /// </summary>
        /// <param name="trooperPrefab">The trooper prefab to spawn.</param>
        /// <param name="spawnPoint">The <see cref="SpawnPoint"/> to spawn the trooper at.</param>
        /// <returns>The spawned trooper.</returns>
        public static Trooper Spawn([NotNull] KaijuAgent trooperPrefab, [NotNull] SpawnPoint spawnPoint)
        {
#if UNITY_EDITOR
            if (!Application.isPlaying)
            {
                return null;
            }
#endif
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
            string[] components = { "Trooper" };
            KaijuAgent agent = KaijuAgents.Spawn(KaijuAgentType.Rigidbody, t.position, t.rotation, true, trooperPrefab, $"Trooper {team}", color, Color.black, components);
            if (!agent.TryGetComponent(out Trooper trooper))
            {
                trooper = agent.gameObject.AddComponent<Trooper>();
            }
            
            // Assign to the correct team.
            agent.SetIdentifier(team);
            trooper.TeamOne = spawnPoint.TeamOne;
            Active.Add(trooper);
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
            return trooper;
        }
        
        /// <summary>
        /// Take damage from another trooper.
        /// </summary>
        /// <param name="attacker">The trooper that dealt the damage.</param>
        public void TakeDamage([NotNull] Trooper attacker)
        {
            // Lower the health.
            Health -= CaptureTheFlagManager.Damage;
            
            // If still alive, send hit callbacks.
            if (Health > 0)
            {
                attacker.OnHitTrooper?.Invoke(this);
                OnHitByTrooper?.Invoke(attacker);
                OnTrooperEliminatedGlobal?.Invoke(attacker, this);
                return;
            }
            
            // Otherwise, eliminate this trooper and invoke eliminated callbacks.
            Agent.Despawn();
            attacker.OnEliminatedTrooper?.Invoke(this);
            OnEliminatedByTrooper?.Invoke(attacker);
            OnTrooperEliminatedGlobal?.Invoke(attacker, this);
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
        /// Cancel trying to fire the <see cref="BlasterActuator"/>.
        /// </summary>
        public void StopAttacking()
        {
            if (_blaster != null)
            {
                _blaster.End();
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
            Active.Add(this);
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
            Active.Remove(this);
            ActiveOne.Remove(this);
            ActiveTwo.Remove(this);
            
            // Reset values.
            Health = 0;
            Ammo = 0;
            
            // Drop the flag if this trooper is carrying it.
            if (_flag == null)
            {
                return;
            }
            
            _flag.Drop();
            OnFlagDropped?.Invoke(_flag);
            OnFlagDroppedGlobal?.Invoke(this, _flag);
            _flag = null;
        }
        
        /// <summary>
        /// Destroying the attached Behaviour will result in the game or Scene receiving OnDestroy.
        /// </summary>
        private void OnDestroy()
        {
            Active.Remove(this);
            ActiveOne.Remove(this);
            ActiveTwo.Remove(this);
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
                
                // Handle it as the proper type.
                if (number is HealthPickup health)
                {
                    // No point in using it if we already have the maximum health.
                    int max = CaptureTheFlagManager.Health;
                    if (Health >= max)
                    {
                        return;
                    }
                    
                    health.Interact(this);
                    Health = max;
                    OnHealth?.Invoke(health);
                    OnHealthGlobal?.Invoke(this, health);
                }
                else if (number is AmmoPickup ammo)
                {
                    // No point in using it if we already have the maximum ammo.
                    int max = CaptureTheFlagManager.Ammo;
                    if (Ammo >= max)
                    {
                        return;
                    }
                    
                    ammo.Interact(this);
                    Ammo = max;
                    OnAmmo?.Invoke(ammo);
                    OnAmmoGlobal?.Invoke(this, ammo);
                }
                
                return;
            }
            
            // The last option is this being a flag.
            if (pickup is not Flag flag || !flag.Interact(this))
            {
                return;
            }
            
            if (TeamOne == flag.TeamOne)
            {
                OnFlagReturned?.Invoke(_flag);
                OnFlagReturnedGlobal?.Invoke(this, _flag);
                return;
            }
            
            _flag = flag;
            OnFlagPickedUp?.Invoke(_flag);
            OnFlagPickedUpGlobal?.Invoke(this, _flag);
        }
        
        /// <summary>
        /// Frame-rate independent MonoBehaviour.FixedUpdate message for physics calculations.
        /// </summary>
        private void FixedUpdate()
        {
            // Try to capture the flag.
            if (_flag == null || Position.Distance(OwnBase) > CaptureTheFlagManager.CaptureDistance)
            {
                return;
            }
            
            _flag.Return();
            OnFlagCaptured?.Invoke(_flag);
            OnFlagCapturedGlobal?.Invoke(this, _flag);
            _flag = null;
        }
    }
}