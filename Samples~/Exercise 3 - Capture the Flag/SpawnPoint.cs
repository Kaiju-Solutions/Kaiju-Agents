using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif
namespace KaijuSolutions.Agents.Exercises.CTF
{
    /// <summary>
    /// Points which <see cref="Trooper"/>s can spawn at.
    /// </summary>
    [RequireComponent(typeof(Collider))]
    [DefaultExecutionOrder(int.MinValue)]
    [AddComponentMenu("Kaiju Solutions/Agents/Exercises/Capture the Flag/Spawn Point", 36)]
    [HelpURL("https://agents.kaijusolutions.ca/manual/capture-the-flag.html#spawn-point")]
    public class SpawnPoint : KaijuBehaviour, IComparable<SpawnPoint>
    {
        /// <summary>
        /// Get the next point to spawn at, prioritizing open points first.
        /// </summary>
        /// <param name="teamOne">If this is for team one.</param>
        /// <returns>The point to spawn at or NULL if there is none.</returns>
        public static SpawnPoint NextSpawnPoint(bool teamOne)
        {
            
#if UNITY_EDITOR
            if (!Application.isPlaying)
            {
                return null;
            }
#endif
            return teamOne ? NextSpawnPoint(OpenOneCache, OccupiedOneCache) : NextSpawnPoint(OpenTwoCache, OccupiedTwoCache);
        }
        
        /// <summary>
        /// Get the next point to spawn at, prioritizing open points first.
        /// </summary>
        /// <param name="open">The open points.</param>
        /// <param name="occupied">The occupied fallback points.</param>
        /// <returns>The point to spawn at or NULL if there is none.</returns>
        private static SpawnPoint NextSpawnPoint([NotNull] SortedSet<SpawnPoint> open, [NotNull] SortedSet<SpawnPoint> occupied) => open.Count > 0 ? NextSpawnPoint(open) : occupied.Count > 0 ? NextSpawnPoint(occupied) : null;
        
        /// <summary>
        /// Get the next point from a cache.
        /// </summary>
        /// <param name="cache">The cache to get a point from.</param>
        /// <returns>The point to spawn at.</returns>
        private static SpawnPoint NextSpawnPoint([NotNull] SortedSet<SpawnPoint> cache)
        {
            return cache.First();
        }
        
        /// <summary>
        /// All spawn points for team one which are currently not occupied by an agent.
        /// </summary>
        private static readonly SortedSet<SpawnPoint> OpenOneCache = new();
        
        /// <summary>
        /// All spawn points for team two which are currently not occupied by an agent.
        /// </summary>
        private static readonly SortedSet<SpawnPoint> OpenTwoCache = new();
        
        /// <summary>
        /// All spawn points for team one which are currently occupied by an agent.
        /// </summary>
        private static readonly SortedSet<SpawnPoint> OccupiedOneCache = new();
        
        /// <summary>
        /// All spawn points for team two which are currently occupied by an agent.
        /// </summary>
        private static readonly SortedSet<SpawnPoint> OccupiedTwoCache = new();
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
            OpenOneCache.Clear();
            OpenTwoCache.Clear();
            OccupiedOneCache.Clear();
            OccupiedTwoCache.Clear();
        }
#endif
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
        
        /// <summary>
        /// Manually occupy this on a spawn as physics collisions won't pick it up right away.
        /// </summary>
        /// <param name="trooper"></param>
        public void SpawnOccupy(Trooper trooper)
        {
            _within.Add(trooper);
            OpenOneCache.Remove(this);
            OpenTwoCache.Remove(this);
            
            if (TeamOne)
            {
                OccupiedOneCache.Add(this);
            }
            else
            {
                OccupiedTwoCache.Add(this);
            }
        }
        
        /// <summary>
        /// Compare to another instance for sorting.
        /// </summary>
        /// <param name="other">The other instance.</param>
        /// <returns>Less than one if this instance should be first, greater than one if the other instance should be first, or zero if these are the same instance.</returns>
        public int CompareTo(SpawnPoint other)
        {
            // Handle NULL values.
            if (this == null)
            {
                return other == null ? 0 : 1;
            }
            
            if (other == null)
            {
                return -1;
            }
            
            // Get positions to compare.
            Vector3 pA = Position3;
            Vector3 pB = other.Position3;
            
            // Handle based on the X position.
            int order = ComparePositions(pA.x, pB.x);
            if (order != 0)
            {
                return order;
            }
            
            // Then try Z.
            order = ComparePositions(pA.z, pB.z);
            if (order != 0)
            {
                return order;
            }
            
            // Lastly Y.
            order = ComparePositions(pA.y, pB.y);
            if (order != 0)
            {
                return order;
            }
            
            // If perfectly in the same position, check enabled states.
            if (!isActiveAndEnabled)
            {
                if (other.isActiveAndEnabled)
                {
                    return 1;
                }
            }
            else if (!other.isActiveAndEnabled)
            {
                return -1;
            }
            
            // Then, try by names. If still the same, check their instance IDs.
            order = string.Compare(name, other.name, StringComparison.Ordinal);
            return order != 0 ? order : GetInstanceID().CompareTo(other.GetInstanceID());
        }
        
        /// <summary>
        /// Compare first by absolute value, then positive before negative.
        /// </summary>
        /// <param name="a">The first value.</param>
        /// <param name="b">The second value.</param>
        /// <returns>Less than one if the first instance should be first, greater than y if the second instance should be first, or zero if these are the same instance.</returns>
        private static int ComparePositions(float a, float b)
        {
            float aA = Mathf.Abs(a);
            float bA = Mathf.Abs(b);
            return aA < bA ? -1 : bA < aA ? 1 : a < b ? -1 : b < a ? 1 : 0;
        }
        
        /// <summary>
        /// Destroying the attached Behaviour will result in the game or Scene receiving OnDestroy.
        /// </summary>
        private void OnDestroy()
        {
            OpenOneCache.Remove(this);
            OpenTwoCache.Remove(this);
            OccupiedOneCache.Remove(this);
            OccupiedTwoCache.Remove(this);
        }
    }
}