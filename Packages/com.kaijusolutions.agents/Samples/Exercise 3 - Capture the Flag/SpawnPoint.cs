using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using UnityEngine;
using Random = UnityEngine.Random;

namespace KaijuSolutions.Agents.Exercises.CTF
{
    [RequireComponent(typeof(Collider))]
    [DefaultExecutionOrder(int.MinValue)]
    [AddComponentMenu("Kaiju Solutions/Agents/Exercises/Capture the Flag/Spawn Point", 32)]
    public class SpawnPoint : KaijuBehaviour
    {
        /// <summary>
        /// Get a random point to spawn at, prioritizing open points first.
        /// </summary>
        /// <param name="teamOne">If this is for team one.</param>
        /// <returns>The point to spawn at or NULL if there is none.</returns>
        public static SpawnPoint RandomSpawn(bool teamOne) => teamOne ? RandomSpawn(OpenOneCache, OccupiedOneCache) : RandomSpawn(OpenTwoCache, OccupiedTwoCache);
        
        /// <summary>
        /// Get a random point to spawn at, prioritizing open points first.
        /// </summary>
        /// <param name="open">The open points.</param>
        /// <param name="occupied">The occupied fallback points.</param>
        /// <returns>The point to spawn at or NULL if there is none.</returns>
        private static SpawnPoint RandomSpawn([NotNull] HashSet<SpawnPoint> open, [NotNull] HashSet<SpawnPoint> occupied) => open.Count > 0 ? RandomSpawn(open) : occupied.Count > 0 ? RandomSpawn(occupied) : null;
        
        /// <summary>
        /// Get a random point from a cache.
        /// </summary>
        /// <param name="cache">The cache to get a point from.</param>
        /// <returns>The point to spawn at.</returns>
        private static SpawnPoint RandomSpawn([NotNull] HashSet<SpawnPoint> cache)
        {
            _randomHelper.Clear();
            foreach (SpawnPoint point in cache)
            {
                _randomHelper.Add(point);
            }

            SpawnPoint value = _randomHelper[Random.Range(0, _randomHelper.Count)];
            _randomHelper.Clear();
            return value;
        }
        
        private readonly static List<SpawnPoint> _randomHelper = new();
        
        /// <summary>
        /// All spawn points for team one which are currently not occupied by an agent.
        /// </summary>
        private static readonly HashSet<SpawnPoint> OpenOneCache = new();
        
        /// <summary>
        /// All spawn points for team two which are currently not occupied by an agent.
        /// </summary>
        private static readonly HashSet<SpawnPoint> OpenTwoCache = new();
        
        /// <summary>
        /// All spawn points for team one which are currently occupied by an agent.
        /// </summary>
        private static readonly HashSet<SpawnPoint> OccupiedOneCache = new();
        
        /// <summary>
        /// All spawn points for team two which are currently occupied by an agent.
        /// </summary>
        private static readonly HashSet<SpawnPoint> OccupiedTwoCache = new();
        
        /// <summary>
        /// Handle manually resetting the domain.
        /// </summary>
        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.SubsystemRegistration)]
        private static void InitOnPlayMode()
        {
            OpenOneCache.Clear();
            OpenTwoCache.Clear();
            OccupiedOneCache.Clear();
            OccupiedTwoCache.Clear();
            _randomHelper.Clear();
            _randomHelper.Capacity = 0;
        }

        /// <summary>
        /// If this is for team one.
        /// </summary>
        [field: Tooltip("If this is for team one.")]
        [field: SerializeField]
        public bool TeamOne { get; private set; } = true;
        
        /// <summary>
        /// If this is currently occupied by any <see cref="Trooper"/>s.
        /// </summary>
        public bool Occupied => _within.Count > 0;
        
        /// <summary>
        /// Keep track of how many <see cref="Trooper"/>s are in this.
        /// </summary>
        private readonly HashSet<Trooper> _within = new();
        
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
            if (_colliders == null)
            {
                _colliders = GetComponentsInChildren<Collider>();
                foreach (Collider c in _colliders)
                {
                    c.isTrigger = true;
                }
            }
            
            // When first starting, wipe any past collisions.
            _within.Clear();
            
            if (TeamOne)
            {
                OpenTwoCache.Remove(this);
                OpenOneCache.Add(this);
            }
            else
            {
                OpenOneCache.Remove(this);
                OpenTwoCache.Add(this);
            }
            
            OccupiedOneCache.Remove(this);
            OccupiedTwoCache.Remove(this);
        }
        
        /// <summary>
        /// This function is called when the behaviour becomes disabled.
        /// </summary>
        private void OnDisable()
        {
            // Clear everything when disabling.
            _within.Clear();
            OpenOneCache.Remove(this);
            OpenTwoCache.Remove(this);
            OccupiedOneCache.Remove(this);
            OccupiedTwoCache.Remove(this);
        }

        private void OnValidate()
        {
            if (!Application.isPlaying)
            {
                foreach (Collider c in GetComponentsInChildren<Collider>())
                {
                    c.isTrigger = true;
                }
                
                return;
            }
            
            // See what team this is for.
            if (TeamOne)
            {
                // Remove the opposite team.
                OpenTwoCache.Remove(this);
                OccupiedTwoCache.Remove(this);
                
                // Add to the correct cache.
                if (Occupied)
                {
                    OpenOneCache.Remove(this);
                    OccupiedOneCache.Add(this);
                }
                else
                {
                    OccupiedOneCache.Remove(this);
                    OpenOneCache.Add(this);
                }
            }
            else
            {
                // Remove the opposite team.
                OpenOneCache.Remove(this);
                OccupiedOneCache.Remove(this);
                
                // Add to the correct cache.
                if (Occupied)
                {
                    OpenTwoCache.Remove(this);
                    OccupiedTwoCache.Add(this);
                }
                else
                {
                    OccupiedTwoCache.Remove(this);
                    OpenTwoCache.Add(this);
                }
            }
        }
        
        /// <summary>
        /// When a GameObject collides with another GameObject, Unity calls OnTriggerEnter. This function can be a coroutine.
        /// </summary>
        /// <param name="other">The other Collider involved in this collision.</param>
        private void OnTriggerEnter(Collider other)
        {
            HandleContacts(other.transform, true);
            
        }
        
        /// <summary>
        /// OnTriggerStay is called once per physics update for every Collider other that is touching the trigger. This function can be a coroutine.
        /// </summary>
        /// <param name="other">The other Collider involved in this collision.</param>
        private void OnTriggerStay(Collider other)
        {
            HandleContacts(other.transform, true);
        }
        
        /// <summary>
        /// OnTriggerExit is called when the Collider other has stopped touching the trigger. This function can be a coroutine.
        /// </summary>
        /// <param name="other">The other Collider involved in this collision.</param>
        private void OnTriggerExit(Collider other)
        {
            HandleContacts(other.transform, false);
        }
        
        /// <summary>
        /// Handle all contacts to see what we have contacted with.
        /// </summary>
        /// <param name="other">The other object interacted with.</param>
        /// <param name="within">If this was a within event or an exiting event.</param>
        private void HandleContacts(Transform other, bool within)
        {
            if (!other.TryGetComponent(out Trooper trooper))
            {
                return;
            }
            
            // Update contact information related to this trooper.
            if (within)
            {
                _within.Add(trooper);
            }
            else
            {
                _within.Remove(trooper);
            }
            
            // See what team this is for.
            if (TeamOne)
            {
                // Add to the correct cache.
                if (Occupied)
                {
                    OpenOneCache.Remove(this);
                    OccupiedOneCache.Add(this);
                }
                else
                {
                    OccupiedOneCache.Remove(this);
                    OpenOneCache.Add(this);
                }
            }
            else
            {
                // Add to the correct cache.
                if (Occupied)
                {
                    OpenTwoCache.Remove(this);
                    OccupiedTwoCache.Add(this);
                }
                else
                {
                    OccupiedTwoCache.Remove(this);
                    OpenTwoCache.Add(this);
                }
            }
        }
    }
}