using System.Diagnostics.CodeAnalysis;
using KaijuSolutions.Agents.Movement;
using UnityEngine;

namespace KaijuSolutions.Agents.Samples.Movement
{
    /// <summary>
    /// Simple tester for <see cref="Agents.Movement.KaijuWanderMovement"/>s.
    /// </summary>
    [DefaultExecutionOrder(int.MaxValue)]
#if UNITY_EDITOR
    [AddComponentMenu("Kaiju Solutions/Agents/Samples/Movement/Kaiju Wander Movement Tester", 11)]
    [Icon("Packages/com.kaijusolutions.agents/Editor/Icon.png")]
    [HelpURL("https://agents.kaijusolutions.ca/manual/sample-movement.html")]
#endif
    public class KaijuWanderMovementTester : KaijuMovementTester
    {
        /// <summary>
        /// How far out to generate the wander circle.
        /// </summary>
        public float Distance
        {
            get => distance;
            set => distance = Mathf.Max(value, 0);
        }
        
        /// <summary>
        /// How far out to generate the wander circle.
        /// </summary>
#if UNITY_EDITOR
        [Tooltip("How far out to generate the wander circle.")]
#endif
        [Min(0)]
        [SerializeField]
        private float distance = KaijuWanderMovement.DefaultDistance;
        
        /// <summary>
        /// The radius of the wander circle.
        /// </summary>
#if UNITY_EDITOR
        [Tooltip("The radius of the wander circle.")]
#endif
        public float Radius
        {
            get => radius;
            set => radius = Mathf.Max(value, 0);
        }
        
        /// <summary>
        /// The radius of the wander circle.
        /// </summary>
        [Min(0)]
        [SerializeField]
        private float radius = KaijuWanderMovement.DefaultRadius;
        
        /// <summary>
        /// Assign this <see cref="Agents.Movement.KaijuMovement"/> to the one of the <see cref="Agents"/>.
        /// </summary>
        /// <param name="agent">The <see cref="KaijuAgent"/>.</param>
        /// <returns>The <see cref="Agents.Movement.KaijuMovement"/>.</returns>
        protected override KaijuMovement Assign([NotNull] KaijuAgent agent)
        {
            return agent.Wander(distance, radius, Weight, clear);
        }
        
        /// <summary>
        /// Get a description of the object.
        /// </summary>
        /// <returns>A description of the object.</returns>
        public override string ToString()
        {
            return $"Kaiju Wander Movement Tester {name}";
        }
    }
}