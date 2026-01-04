using UnityEngine;

namespace KaijuSolutions.Agents.Exercises.Microbes
{
    /// <summary>
    /// Basic controller for you to get started with.
    /// </summary>
    [RequireComponent(typeof(Microbe))]
    [AddComponentMenu("Kaiju Solutions/Agents/Exercises/Microbes/Microbe Controller", 18)]
    public class MicrobeController : KaijuController
    {
        /// <summary>
        /// The <see cref="Microbe"/> this is controlling.
        /// </summary>
        [Tooltip("The microbe this is controlling.")]
        [HideInInspector]
        [SerializeField]
        private Microbe microbe;
        
        /// <summary>
        /// Called after the <see cref="microbe"/> has mated.
        /// </summary>
        private void OnMate() { }
        
        /// <summary>
        /// Called after the <see cref="microbe"/> has eaten.
        /// </summary>
        private void OnEat() { }
        
        /// <summary>
        /// Editor-only function that Unity calls when the script is loaded or a value changes in the Inspector.
        /// </summary>
        protected override void OnValidate()
        {
            base.OnValidate();
            if (microbe == null || microbe.transform != transform)
            {
                microbe = GetComponent<Microbe>();
            }
        }
        
        /// <summary>
        /// This function is called when the object becomes enabled and active.
        /// </summary>
        protected override void OnEnable()
        {
            if (microbe == null)
            {
                microbe = GetComponent<Microbe>();
                if (microbe == null)
                {
                    Debug.LogError("Microbe Controller - No microbe on this GameObject.", this);
                }
            }
            
            if (microbe != null)
            {
                microbe.OnMate += OnMate;
                microbe.OnEat += OnEat;
            }
            
            base.OnEnable();
        }
        
        /// <summary>
        /// This function is called when the behaviour becomes disabled.
        /// </summary>
        protected override void OnDisable()
        {
            base.OnDisable();
            
            if (microbe == null)
            {
                return;
            }
            
            microbe.OnMate -= OnMate;
            microbe.OnEat -= OnEat;
        }
    }
}