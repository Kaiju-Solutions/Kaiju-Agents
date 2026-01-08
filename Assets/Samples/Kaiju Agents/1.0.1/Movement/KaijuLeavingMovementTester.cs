using KaijuSolutions.Agents.Movement;
using UnityEngine;

namespace KaijuSolutions.Agents.Samples.Movement
{
    /// <summary>
    /// Simple tester for <see cref="Agents.Movement.KaijuLeavingMovement"/>s.
    /// </summary>
    [DefaultExecutionOrder(int.MaxValue)]
#if UNITY_EDITOR
    [Icon("Packages/com.kaijusolutions.agents/Editor/Icon.png")]
    [HelpURL("https://agents.kaijusolutions.ca/manual/sample-movement.html")]
#endif
    public abstract class KaijuLeavingMovementTester : KaijuMovementTester
    {
        /// <summary>
        /// The distance at which we can consider this behaviour done.
        /// </summary>
        public float Distance
        {
            get => distance;
            set => distance = Mathf.Max(0, value);
        }
        
        /// <summary>
        /// The distance at which we can consider this behaviour done.
        /// </summary>
#if UNITY_EDITOR
        [Tooltip("The distance at which we can consider this behaviour done.")]
#endif
        [Min(float.Epsilon)]
        [SerializeField]
        private float distance = KaijuLeavingMovement.DefaultDistance;
        
        /// <summary>
        /// Get a description of the object.
        /// </summary>
        /// <returns>A description of the object.</returns>
        public override string ToString()
        {
            return $"Kaiju Leaving Movement Tester {name}";
        }
    }
}