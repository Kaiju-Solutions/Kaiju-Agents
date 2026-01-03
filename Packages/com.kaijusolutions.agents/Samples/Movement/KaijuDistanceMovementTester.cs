using UnityEngine;

namespace KaijuSolutions.Agents.Samples.Movement
{
    /// <summary>
    /// Simple tester for <see cref="Agents.Movement.KaijuApproachingMovement"/>s.
    /// </summary>
    [DefaultExecutionOrder(int.MaxValue)]
#if UNITY_EDITOR
    [Icon("Packages/com.kaijusolutions.agents/Editor/Icon.png")]
    [HelpURL("https://agents.kaijusolutions.ca/manual/getting-started.html")]
#endif
    public abstract class KaijuApproachingMovementTester : KaijuMovementTester
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
        private float distance = 0.1f;
    }
}