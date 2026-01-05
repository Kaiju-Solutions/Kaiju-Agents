using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using KaijuSolutions.Agents.Extensions;
using UnityEngine;
using Random = UnityEngine.Random;

namespace KaijuSolutions.Agents.Exercises.Microbes
{
    /// <summary>
    /// Microbes which can mate with and eat each other.
    /// </summary>
    [RequireComponent(typeof(Collider))]
    [RequireComponent(typeof(Rigidbody))]
    [RequireComponent(typeof(KaijuRigidbodyAgent))]
    [HelpURL("https://agents.kaijusolutions.ca/manual/microbes.html#microbe")]
    [AddComponentMenu("Kaiju Solutions/Agents/Exercises/Microbes/Microbe", 19)]
    public class Microbe : KaijuController
    {
        /// <summary>
        /// Callback for this microbe eating.
        /// </summary>
        public event MicrobeAction OnEat;
        
        /// <summary>
        /// Callback for this microbe being eaten.
        /// </summary>
        public event MicrobeAction OnEaten;
        
        /// <summary>
        /// Global callback for this microbe eating.
        /// </summary>
        public event MultiMicrobeAction OnEatGlobal;
        
        /// <summary>
        /// Callback for this microbe mating.
        /// </summary>
        public event MicrobeAction OnMate;
        
        /// <summary>
        /// Global callback for this microbe mating.
        /// </summary>
        public event MultiMicrobeAction OnMateGlobal;
        
        /// <summary>
        /// All microbes currently in the world.
        /// </summary>
        public static IReadOnlyCollection<Microbe> All => Active;
        
        /// <summary>
        /// The active microbes.
        /// </summary>
        private static readonly HashSet<Microbe> Active = new();
        
        /// <summary>
        /// Cache the microbe type which is needed from cached agents.
        /// </summary>
        private static readonly Type[] Types = { typeof(Microbe) };
        
        /// <summary>
        /// Handle manually resetting the domain.
        /// </summary>
        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.SubsystemRegistration)]
        private static void InitOnPlayMode()
        {
            Active.Clear();
        }
        
        /// <summary>
        /// The current energy of this microbe.
        /// This will <see cref="Decay"/> every second, and this microbe needs energy to stay alive.
        /// Walk into <see cref="EnergyPickup"/> pickups to restore this.
        /// Microbes with higher energy levels than other microbes can eat them.
        /// </summary>
        public float Energy
        {
            get => _energy;
            set => _energy = Mathf.Max(value, 0);
        }
        
        /// <summary>
        /// The current energy of this microbe.
        /// This will <see cref="Decay"/> every second, and this microbe needs energy to stay alive.
        /// Walk into <see cref="EnergyPickup"/> pickups to restore this.
        /// Microbes with higher energy levels than other microbes can eat them.
        /// </summary>
        private float _energy;
        
        /// <summary>
        /// How much <see cref="Energy"/> this microbe loses per second.
        /// </summary>
        public float Decay
        {
            get => decay;
            set => decay = Mathf.Max(value, 0);
        }
        
        /// <summary>
        /// The current energy of this microbe.
        /// Walk into <see cref="Energy"/> pickups to restore this.
        /// Microbes with higher energy levels than other microbes can eat them.
        /// </summary>
        [Tooltip("How much energy this microbe loses per second.")]
        [Min(0)]
        [SerializeField]
        private float decay = 5;
        
        /// <summary>
        /// If this microbe is currently on a cooldown for mating.
        /// </summary>
        public bool OnCooldown => Cooldown > 0;
        
        /// <summary>
        /// The time in seconds the microbe needs to wait before it can <see cref="Mate"/> again.
        /// </summary>
        public float Cooldown { get; private set; }
        
        /// <summary>
        /// See if this microbe is compatible to mate with another microbe.
        /// Note this does not check if either microbe is still on <see cref="Cooldown"/> for mating.
        /// For that, check <see cref="OnCooldown"/>.
        /// </summary>
        /// <param name="other">The other microbe.</param>
        /// <returns>If this microbe is compatible to mate with another microbe.</returns>
        public bool Compatible([NotNull] Microbe other) => this != other && SameIdentifier(other);
        
        /// <summary>
        /// See if this microbe could eat another microbe.
        /// Note this does not check if this has enough <see cref="Energy"/> to eat the other microbe, being more <see cref="Energy"/> than the other microbe has.
        /// </summary>
        /// <param name="other">The other microbe.</param>
        /// <returns>If this microbe could eat another microbe.</returns>
        public bool Eatable([NotNull] Microbe other) => this != other && !SameIdentifier(other);
        
        /// <summary>
        /// See if this has the same identifier as another microbe.
        /// </summary>
        /// <param name="other">The other microbe.</param>
        /// <returns>If this has the same identifier as another microbe.</returns>
        private bool SameIdentifier([NotNull] Microbe other) => Agent.HasAnyIdentifier(other.Agent.Identifiers);
        
        /// <summary>
        /// Mate with another microbe.
        /// </summary>
        /// <param name="other">The other microbe to mate with.</param>
        private void Mate([NotNull] Microbe other)
        {
            // Need to be compatible and both not on cooldown.
            if (!Compatible(other) || OnCooldown || other.OnCooldown)
            {
                return;
            }
            
            // Spawn with an energy level between the two microbes and directly between the microbes.
            Spawn(MicrobeManager.MicrobePrefab, (_energy + other._energy) / 2, (Position + other.Position) / 2, Agent.Identifiers[0]);
            other.Cooldown = Cooldown = MicrobeManager.Cooldown;
            
            // Run callbacks.
            OnMate?.Invoke(other);
            other.OnMate?.Invoke(this);
            OnMateGlobal?.Invoke(this, other);
        }
        
        /// <summary>
        /// Eat another microbe.
        /// </summary>
        /// <param name="other">The other microbe to eat.</param>
        /// <returns>If the other microbe was eaten.</returns>
        private bool Eat([NotNull] Microbe other)
        {
            // Cannot eat potential mates and need to have more energy than them.
            if (!Eatable(other) || _energy <= other._energy)
            {
                return false;
            }
            
            // Take all of their energy.
            _energy += other._energy;
            
            // Despawn the other agent.
            other.Agent.Despawn();
            
            // Run callbacks.
            OnEat?.Invoke(other);
            other.OnEaten?.Invoke(this);
            OnEatGlobal?.Invoke(this, other);
            return true;
        }
        
        /// <summary>
        /// Spawn a microbe.
        /// </summary>
        /// <param name="microbePrefab">The prefab to spawn.</param>
        /// <param name="energy">The energy level to spawn with.</param>
        /// <param name="position">The position to spawn the microbe at.</param>
        /// <param name="identifier">The microbe identifier type.</param>
        public static void Spawn(KaijuAgent microbePrefab, float energy, Vector2 position, uint identifier)
        {
            // Spawn the agent.
            KaijuAgent agent = KaijuAgents.Spawn(KaijuAgentType.Rigidbody, position.Expand(), Quaternion.Euler(new(0, Random.Range(0f, 360f), 0)), true, microbePrefab, $"Microbe {identifier}", MicrobeManager.GetColor(identifier), Color.black, Types);
            if (!agent.TryGetComponent(out Microbe microbe))
            {
                microbe = agent.gameObject.AddComponent<Microbe>();
            }
            
            // Set the identifier.
            agent.SetIdentifier(identifier);
            
            // Set the microbe's initial energy.
            microbe.Energy = energy;
        }
        
        /// <summary>
        /// This function is called when the object becomes enabled and active.
        /// </summary>
        protected override void OnEnable()
        {
            base.OnEnable();
            Active.Add(this);
        }
        
        /// <summary>
        /// This function is called when the behaviour becomes disabled.
        /// </summary>
        protected override void OnDisable()
        {
            _energy = 0;
            Cooldown = 0;
            Active.Remove(this);
            base.OnDisable();
        }
        
        /// <summary>
        /// Frame-rate independent MonoBehaviour.FixedUpdate message for physics calculations.
        /// </summary>
        private void FixedUpdate()
        {
            float delta = Time.deltaTime;
            
            // Every tick, see if we are out of energy and if so remove this microbe.
            Energy -= Decay * delta;
            if (_energy <= 0)
            {
                Agent.Despawn();
                return;
            }
            
            if (!OnCooldown)
            {
                return;
            }
            
            Cooldown -= Time.deltaTime;
            if (Cooldown < 0)
            {
                Cooldown = 0;
            }
        }
        
        /// <summary>
        /// OnCollisionEnter is called when this collider/rigidbody has begun touching another rigidbody/collider. This function can be a coroutine.
        /// </summary>
        /// <param name="other">The collision data associated with this collision.</param>
        private void OnCollisionEnter(Collision other)
        {
            HandleContacts(other.transform);
        }
        
        /// <summary>
        /// OnCollisionStay is called once per frame for every Collider or Rigidbody that touches another Collider or Rigidbody. This function can be a coroutine.
        /// </summary>
        /// <param name="other">The Collision data associated with this collision.</param>
        private void OnCollisionStay(Collision other)
        {
            HandleContacts(other.transform);
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
            // If it was a microbe, try to eat it or mate with it.
            if (other.TryGetComponent(out Microbe microbe))
            {
                if (Eat(microbe))
                {
                    return;
                }
                
                Mate(microbe);
                return;
            }
            
            // Otherwise, see if it is an energy pickup and if so gather its energy.
            if (!other.TryGetComponent(out EnergyPickup pickup))
            {
                return;
            }
            
            _energy += MicrobeManager.Energy;
            pickup.gameObject.SetActive(false);
        }
    }
}