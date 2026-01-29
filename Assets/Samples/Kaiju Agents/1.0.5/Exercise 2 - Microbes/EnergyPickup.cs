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
    [HelpURL("https://agents.kaijusolutions.ca/manual/microbes.html#energy-pickup")]
    [AddComponentMenu("Kaiju Solutions/Agents/Exercises/Microbes/Energy Pickup", 22)]
    public class EnergyPickup : KaijuBehaviour
    {
        /// <summary>
        /// All energies currently in the world.
        /// </summary>
        public static IReadOnlyCollection<EnergyPickup> All => Active;
        
        /// <summary>
        /// The active energy elements.
        /// </summary>
        private static readonly HashSet<EnergyPickup> Active = new();
        
        /// <summary>
        /// The disabled energy elements.
        /// </summary>
        private static readonly HashSet<EnergyPickup> Unactive = new();
        
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
        /// Spawn an energy.
        /// </summary>
        /// <param name="energyPrefab">The prefab to spawn.</param>
        /// <param name="value">The energy value to set.</param>
        /// <param name="position">The position to spawn the energy pickup at.</param>
        public static void Spawn([NotNull] EnergyPickup energyPrefab, Vector2 position)
        {
            // If there are none cached, we need to spawn a new one.
            EnergyPickup spawned;
            if (Unactive.Count < 1)
            {
                spawned = Instantiate(energyPrefab);
                spawned.name = "Energy";
                spawned.Position = position;
                return;
            }
            
            // Otherwise, get a cached one.
            spawned = Unactive.First();
            Unactive.Remove(spawned);
            spawned.Position = position;
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
        /// Destroying the attached Behaviour will result in the game or Scene receiving OnDestroy.
        /// </summary>
        private void OnDestroy()
        {
            // Ensure no garbage remaining.
            Active.Remove(this);
            Unactive.Remove(this);
        }
    }
}