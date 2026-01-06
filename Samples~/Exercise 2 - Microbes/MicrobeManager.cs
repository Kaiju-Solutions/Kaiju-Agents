using UnityEngine;
using Random = UnityEngine.Random;

namespace KaijuSolutions.Agents.Exercises.Microbes
{
    /// <summary>
    /// Manager for spawning <see cref="Microbe"/>s and <see cref="Energy"/> components.
    /// </summary>
    [DisallowMultipleComponent]
    [HelpURL("https://agents.kaijusolutions.ca/manual/microbes.html#microbe-manager")]
    [AddComponentMenu("Kaiju Solutions/Agents/Exercises/Microbes/Microbe Manager", 23)]
    public class MicrobeManager : KaijuBehaviour
    {
        /// <summary>
        /// The singleton manager instance.
        /// </summary>
        private static MicrobeManager _instance;
        
        /// <summary>
        /// The singleton manager instance.
        /// </summary>
        public static MicrobeManager Instance
        {
            get
            {
                if (_instance != null)
                {
                    return _instance;
                }
                
                MicrobeManager manager = FindAnyObjectByType<MicrobeManager>();
                return manager != null ? manager : new GameObject("Microbe Manager") { isStatic = true }.AddComponent<MicrobeManager>();
            }
        }
        
        /// <summary>
        /// Handle manually resetting the domain.
        /// </summary>
        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.SubsystemRegistration)]
        private static void InitOnPlayMode()
        {
            _instance = null;
        }
        
        /// <summary>
        /// The prefab for the <see cref="Microbe"/>s.
        /// </summary>
        public static KaijuAgent MicrobePrefab => Instance.microbePrefab;
        
        /// <summary>
        /// The prefab for the <see cref="Microbe"/>s.
        /// </summary>
        [Header("Prefabs")]
        [Tooltip("The prefab for the microbes.")]
        [SerializeField]
        private KaijuAgent microbePrefab;
        
        /// <summary>
        /// The prefab for the <see cref="EnergyPickup"/>s.
        /// </summary>
        [Tooltip("The prefab for the energy pickups.")]
        [SerializeField]
        private EnergyPickup energyPrefab;
        
        /// <summary>
        /// The <see cref="Microbe.Energy"/> level to spawn new <see cref="Microbe"/>s at.
        /// </summary>
        public static float Energy => Instance.energy;
        
        /// <summary>
        /// The <see cref="Microbe.Energy"/> level to spawn new <see cref="Microbe"/>s at.
        /// </summary>
        [Header("Configuration")]
        [Tooltip("The energy level to spawn new microbes at.")]
        [Min(float.Epsilon)]
        [SerializeField]
        private float energy = 100;
        
        /// <summary>
        /// The time in seconds <see cref="Microbe"/>s need to wait before they can <see cref="Microbe.Mate"/> again.
        /// </summary>
        public static float Cooldown => Instance.cooldown;
        
        /// <summary>
        /// The time in seconds <see cref="Microbe"/>s need to wait before they can <see cref="Microbe.Mate"/> again.
        /// </summary>
        [Tooltip("The time in seconds microbes need to wait before they can mate again.")]
        [Min(float.Epsilon)]
        [SerializeField]
        private float cooldown = 5;
        
        /// <summary>
        /// The starting number of <see cref="Microbe"/>s per <see cref="species"/>.
        /// </summary>
        [Header("Initialization")]
        [Tooltip("The starting number of microbes per species.")]
        [Min(1)]
        [SerializeField]
        private int startingMicrobes = 5;
        
        /// <summary>
        /// The starting number of <see cref="EnergyPickup"/> pickups.
        /// </summary>
        [Tooltip("The starting number of energy pickups.")]
        [Min(0)]
        [SerializeField]
        private int startingEnergy = 10;
        
        /// <summary>
        /// How many seconds between <see cref="EnergyPickup"/> spawns.
        /// </summary>
        [Header("Spawning")]
        [Tooltip("How many seconds between energy pickup spawns.")]
        [Min(0)]
        [SerializeField]
        private float energyRate = 1;
        
        /// <summary>
        /// The range in each axis to spawn within.
        /// </summary>
        [Tooltip("The range in each axis to spawn within.")]
        [SerializeField]
        private Vector2 spawning = new(-45, 45);
        
        /// <summary>
        /// The elapsed time for the energy spawning.
        /// </summary>
        private float _elapsed;
        
        /// <summary>
        /// Get the color for a species.
        /// </summary>
        /// <param name="identifier">The species identifier.</param>
        /// <returns>The identifier for the species.</returns>
        public static Color GetColor(uint identifier) => Instance.species[identifier % _instance.species.Length];

        /// <summary>
        /// The colors for the different species of <see cref="Microbe"/>s. The species <see cref="KaijuAgent.Identifiers"/> will be set based on this index.
        /// </summary>
        [Tooltip("The colors for the different species of microbes. The species identifier will be set based on this index.")]
        [SerializeField]
        private Color[] species = {
            Color.red,
            Color.green,
            Color.blue,
            Color.yellow
        };
        
        /// <summary>
        /// This function is called when the object becomes enabled and active.
        /// </summary>
        private void OnEnable()
        {
            // Nothing to do if this is already the singleton.
            if (_instance == this)
            {
                return;
            }
			
            // If there is a singleton but this is not it, destroy this.
            if (_instance != null && _instance != this)
            {
                Destroy(gameObject);
                return;
            }
			
            // Otherwise, set this as the singleton.
            _instance = this;
            
            // Spawn initial values.
            for (int i = 0; i < startingEnergy; i++)
            {
                SpawnEnergy();
            }
            
            for (int i = 0; i < species.Length; i++)
            {
                for (int j = 0; j < startingMicrobes; j++)
                {
                    SpawnMicrobe();
                }
            }
        }
        
        /// <summary>
        /// This function is called when the behaviour becomes disabled.
        /// </summary>
        private void OnDisable()
        {
            if (_instance == this)
            {
                _instance = null;
            }
        }
        
        /// <summary>
        /// Get a random spawn position.
        /// </summary>
        private Vector2 RandomPosition => new Vector2(Random.Range(spawning.x, spawning.y), Random.Range(spawning.x, spawning.y));
        
        /// <summary>
        /// Spawn a <see cref="Microbe"/>.
        /// </summary>
        private void SpawnMicrobe()
        {
            Microbe.Spawn(microbePrefab, energy, RandomPosition, (uint)Random.Range(0, species.Length));
        }
        
        /// <summary>
        /// Spawn a <see cref="EnergyPickup"/> pickup.
        /// </summary>
        private void SpawnEnergy()
        {
            EnergyPickup.Spawn(energyPrefab, RandomPosition);
        }
        
        /// <summary>
        /// Editor-only function that Unity calls when the script is loaded or a value changes in the Inspector.
        /// </summary>
        private void OnValidate()
        {
            if (spawning.x > spawning.y)
            {
                (spawning.x, spawning.y) = (spawning.y, spawning.x);
            }
            
            if (microbePrefab != null && microbePrefab.TryGetComponent(out Microbe _))
            {
                return;
            }
            
            Debug.LogError($"Prefab \"{microbePrefab.name}\" does not have a \"Microbe\" component attached to it.");
            microbePrefab = null;
        }
        
        /// <summary>
        /// Frame-rate independent MonoBehaviour.FixedUpdate message for physics calculations.
        /// </summary>
        private void FixedUpdate()
        {
            _elapsed += Time.deltaTime;
            if (_elapsed < energyRate)
            {
                return;
            }
            
            _elapsed = 0;
            SpawnEnergy();
        }
    }
}