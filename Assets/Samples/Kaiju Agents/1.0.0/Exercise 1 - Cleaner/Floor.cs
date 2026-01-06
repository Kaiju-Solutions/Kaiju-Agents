using UnityEngine;
using Random = UnityEngine.Random;

namespace KaijuSolutions.Agents.Exercises.Cleaner
{
    /// <summary>
    /// Floor tile which will get dirty over time, given the chance every second of <see cref="Chance"/>.
    /// You should have a <see cref="KaijuSolutions.Agents.Sensors.KaijuSensor"/> which detects these and can determine which are clean and which are dirty via the <see cref="Dirty"/> parameter.
    /// From there, you will want to move the agent towards a dirty tile if it sensed one.
    /// Once close enough to the dirty floor tile, you will need to create a <see cref="KaijuSolutions.Agents.Actuators.KaijuActuator"/> which can call the <see cref="Clean"/> method.
    /// </summary>
    [HelpURL("https://agents.kaijusolutions.ca/manual/cleaner.html#floor")]
    [AddComponentMenu("Kaiju Solutions/Agents/Exercises/Cleaner/Floor", 17)]
    [RequireComponent(typeof(MeshRenderer))]
    public class Floor : KaijuBehaviour
    {
        /// <summary>
        /// The material to display when this floor tile is clean.
        /// </summary>
        [Tooltip("The material to display when this floor tile is clean.")]
        [SerializeField]
        private Material cleanMaterial;
        
        /// <summary>
        /// The material to display when this floor tile is dirty.
        /// </summary>
        [Tooltip("The material to display when this floor tile is dirty.")]
        [SerializeField]
        private Material dirtyMaterial;
        
        /// <summary>
        /// If this floor tile is dirty.
        /// </summary>
        public bool Dirty { get; private set; }
        
        /// <summary>
        /// The chance that every second this floor tile could become dirty. Note that as this is randomly calculated every fraction of a second, a value of one does not actually guarantee the tile will become dirty every second.
        /// </summary>
        [field: Tooltip("The chance that every second this floor tile could become dirty. Note that as this is randomly calculated every fraction of a second, a value of one does not actually guarantee the tile will become dirty every second.")]
        [field: Min(float.Epsilon)]
        [field: SerializeField]
        public float Chance { get; private set; } = 0.01f;
        
        /// <summary>
        /// The visuals renderer.
        /// </summary>
        [Tooltip("The visuals renderer.")]
        [HideInInspector]
        [SerializeField]
        private MeshRenderer mr;
        
        /// <summary>
        /// This function is called when the object becomes enabled and active.
        /// </summary>
        private void OnEnable()
        {
            this.AssignComponent(ref mr);
            mr.material = cleanMaterial;
        }
        
        /// <summary>
        /// Editor-only function that Unity calls when the script is loaded or a value changes in the Inspector.
        /// </summary>
        private void OnValidate()
        {
            this.AssignComponent(ref mr);
        }
        
        /// <summary>
        /// Clean this floor tile. Your actuator will want to call this once you are close enough to this tile.
        /// </summary>
        public void Clean()
        {
            Dirty = false;
            mr.material = cleanMaterial;
        }
        
        /// <summary>
        /// Frame-rate independent MonoBehaviour.FixedUpdate message for physics calculations.
        /// </summary>
        private void FixedUpdate()
        {
            // See if this should randomly become dirty.
            if (Random.value > Chance * Time.deltaTime)
            {
                return;
            }
            
            Dirty = true;
            mr.material = dirtyMaterial;
        }
    }
}