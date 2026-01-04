using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using UnityEngine;

namespace KaijuSolutions.Agents.Exercises.Microbes
{
    /// <summary>
    /// Simple energy element which can spawn in the world which <see cref="Microbe"/>s can walk into to pick up.
    /// </summary>
    [RequireComponent(typeof(Collider))]
    public class Energy : KaijuBehaviour
    {
        /// <summary>
        /// All energies currently in the world.
        /// </summary>
        public static IReadOnlyCollection<Energy> All => Active;
        
        /// <summary>
        /// The active energy elements.
        /// </summary>
        private static readonly HashSet<Energy> Active = new();
        
        /// <summary>
        /// The disabled energy elements.
        /// </summary>
        private static readonly HashSet<Energy> Unactive = new();
        
        /// <summary>
        /// Handle manually resetting the domain.
        /// </summary>
        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.SubsystemRegistration)]
        private static void InitOnPlayMode()
        {
            Active.Clear();
            Unactive.Clear();
        }
        
        /// <summary>
        /// How much energy this will restore to a <see cref="Microbe"/>.
        /// </summary>
        public float Value
        {
            get => energy;
            set => energy = Mathf.Max(value, float.Epsilon);
        }
        
        /// <summary>
        /// How much energy this will restore to a <see cref="Microbe"/>.
        /// </summary>
        [Tooltip("How much energy this will restore to a microbe.")]
        [Min(float.Epsilon)]
        [SerializeField]
        private float energy = 10;
        
        /// <summary>
        /// Spawn an energy.
        /// </summary>
        /// <param name="energyPrefab">The prefab to spawn.</param>
        /// <param name="value">The energy value to set.</param>
        /// <param name="position">The position to spawn the energy pickup at.</param>
        public static void Spawn([NotNull] Energy energyPrefab, float value, Vector2 position)
        {
            // If there are none cached, we need to spawn a new one.
            Energy spawned;
            if (Unactive.Count < 1)
            {
                spawned = Instantiate(energyPrefab);
                spawned.name = "Energy";
                spawned.Position = position;
                spawned.Value = value;
                return;
            }
            
            // Otherwise, get a cached one.
            spawned = Unactive.First();
            Unactive.Remove(spawned);
            spawned.Position = position;
            spawned.Value = value;
            spawned.OnValidate();
            spawned.enabled = true;
            spawned.gameObject.SetActive(true);
        }
        
        /// <summary>
        /// This function is called when the object becomes enabled and active.
        /// </summary>
        private void OnEnable()
        {
            Unactive.Remove(this);
            Active.Add(this);
        }
        
        /// <summary>
        /// This function is called when the behaviour becomes disabled.
        /// </summary>
        private void OnDisable()
        {
            Active.Remove(this);
            Unactive.Add(this);
        }
        
        /// <summary>
        /// Editor-only function that Unity calls when the script is loaded or a value changes in the Inspector.
        /// </summary>
        private void OnValidate()
        {
            // Ensure all colliders are triggers.
            foreach (Collider c in GetComponentsInChildren<Collider>())
            {
                c.isTrigger = true;
            }
        }
    }
}