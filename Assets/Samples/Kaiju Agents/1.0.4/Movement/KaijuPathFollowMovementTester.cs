using System.Diagnostics.CodeAnalysis;
using KaijuSolutions.Agents.Movement;
using UnityEngine;

namespace KaijuSolutions.Agents.Samples.Movement
{
    /// <summary>
    /// Simple tester for <see cref="Agents.Movement.KaijuPathFollowMovement"/>s.
    /// </summary>
    [DefaultExecutionOrder(int.MaxValue)]
#if UNITY_EDITOR
    [AddComponentMenu("Kaiju Solutions/Agents/Samples/Movement/Kaiju Path Follow Movement Tester", 14)]
    [Icon("Packages/com.kaijusolutions.agents/Editor/Icon.png")]
    [HelpURL("https://agents.kaijusolutions.ca/manual/sample-movement.html")]
#endif
    public class KaijuPathFollowMovementTester : KaijuMovementTester
    {
        /// <summary>
        /// The distance at which we can consider this behaviour done.
        /// </summary>
        public float Distance
        {
            get => distance;
            set => distance = Mathf.Max(value, float.Epsilon);
        }
        
        /// <summary>
        /// The distance at which we can consider this behaviour done.
        /// </summary>
#if UNITY_EDITOR
        [Tooltip("The distance at which we can consider this behaviour done.")]
#endif
        [Min(float.Epsilon)]
        [SerializeField]
        private float distance = KaijuApproachingMovement.DefaultDistance;
        
        /// <summary>
        /// A bitfield mask specifying which navigation mesh areas can be used for the path.
        /// </summary>
#if UNITY_EDITOR
        [Tooltip("A bitfield mask specifying which navigation mesh areas can be used for the path.")]
#endif
        public LayerMask mask = KaijuPathFollowMovement.DefaultMask;
        
        /// <summary>
        /// The distance to automatically recalculate the path from.
        /// </summary>
        public float AutoCalculateDistance
        {
            get => autoCalculateDistance;
            set => autoCalculateDistance = Mathf.Max(value, 0);
        }
        
        /// <summary>
        /// The distance to automatically recalculate the path from.
        /// </summary>
#if UNITY_EDITOR
        [Tooltip("The distance to automatically recalculate the path from.")]
#endif
        [Min(0)]
        [SerializeField]
        private float autoCalculateDistance = KaijuPathFollowMovement.DefaultAutoCalculateDistance;
        
        /// <summary>
        /// The collision mask for string-pulling line-of-sight checks.
        /// </summary>
        public int collisionMask = KaijuMovementConfiguration.DefaultMask;
        
        /// <summary>
        /// How line-of-sight checks should handle triggers.
        /// </summary>
        public QueryTriggerInteraction triggers = QueryTriggerInteraction.UseGlobal;
        
        /// <summary>
        /// Assign this <see cref="Agents.Movement.KaijuMovement"/> to the one of the <see cref="Agents"/>.
        /// </summary>
        /// <param name="agent">The <see cref="KaijuAgent"/>.</param>
        /// <returns>The <see cref="Agents.Movement.KaijuMovement"/>.</returns>
        protected override KaijuMovement Assign([NotNull] KaijuAgent agent)
        {
            return agent.PathFollow(transform, mask, distance, autoCalculateDistance, collisionMask, triggers, Weight, clear);
        }
        
        /// <summary>
        /// Get a description of the object.
        /// </summary>
        /// <returns>A description of the object.</returns>
        public override string ToString()
        {
            return $"Kaiju Path Follow Movement Tester {name}";
        }
    }
}