using System.Diagnostics.CodeAnalysis;
using KaijuSolutions.Agents.Movement;
using UnityEngine;

namespace KaijuSolutions.Agents.Samples.Movement
{
    /// <summary>
    /// Simple tester for <see cref="Agents.Movement.KaijuObstacleAvoidanceMovement"/>s.
    /// </summary>
    [DefaultExecutionOrder(int.MaxValue)]
#if UNITY_EDITOR
    [AddComponentMenu("Kaiju Solutions/Agents/Samples/Movement/Kaiju Obstacle Avoidance Movement Tester", 12)]
    [Icon("Packages/com.kaijusolutions.agents/Editor/Icon.png")]
    [HelpURL("https://agents.kaijusolutions.ca/manual/sample-movement.html")]
#endif
    public class KaijuObstacleAvoidanceMovementTester : KaijuMovementTester
    {
        /// <summary>
        /// The distance from a wall the <see cref="KaijuAgent"/> should maintain.
        /// </summary>
        public float Avoidance
        {
            get => avoidance;
            set => avoidance = Mathf.Max(value, float.Epsilon);
        }
        
        /// <summary>
        /// The distance from a wall the <see cref="KaijuAgent"/> should maintain.
        /// </summary>
#if UNITY_EDITOR
        [Tooltip("The distance from a wall the agent should maintain.")]
#endif
        [Min(float.Epsilon)]
        [SerializeField]
        private float avoidance = KaijuObstacleAvoidanceMovement.DefaultAvoidance;
        
        /// <summary>
        /// The distance for rays.
        /// </summary>
        public float Distance
        {
            get => distance;
            set => distance = Mathf.Max(value, float.Epsilon);
        }
        
        /// <summary>
        /// The distance for rays.
        /// </summary>
#if UNITY_EDITOR
        [Tooltip("The distance for rays.")]
#endif
        [Min(float.Epsilon)]
        [SerializeField]
        private float distance = KaijuObstacleAvoidanceMovement.DefaultDistance;
        
        /// <summary>
        /// The distance of the side rays. Zero or less will use the <see cref="Distance"/>.
        /// </summary>
        public float SideDistance
        {
            get => sideDistance > 0 ? sideDistance : distance;
            set => sideDistance = value;
        }
        
        /// <summary>
        /// The distance of the side rays. Zero or less will use the <see cref="Distance"/>.
        /// </summary>
#if UNITY_EDITOR
        [Tooltip("The distance of the side rays. Zero or less will use the distance.")]
#endif
        [Min(0)]
        [SerializeField]
        private float sideDistance = KaijuObstacleAvoidanceMovement.DefaultSideDistance;
        
        /// <summary>
        /// The angle for rays.
        /// </summary>
#if UNITY_EDITOR
        [Tooltip("The angle for the rays.")]
#endif
        public float angle = KaijuObstacleAvoidanceMovement.DefaultAngle;
        
        /// <summary>
        /// The height offset for the rays.
        /// </summary>
#if UNITY_EDITOR
        [Tooltip("The height offset for the rays.")]
#endif
        public float height = KaijuObstacleAvoidanceMovement.DefaultHeight;
        
        /// <summary>
        /// The horizontal shift for the side rays.
        /// </summary>
#if UNITY_EDITOR
        [Tooltip("The horizontal shift for the side rays.")]
#endif
        public float horizontal = KaijuObstacleAvoidanceMovement.DefaultHorizontal;
        
        /// <summary>
        /// Assign this <see cref="Agents.Movement.KaijuMovement"/> to the one of the <see cref="Agents"/>.
        /// </summary>
        /// <param name="agent">The <see cref="KaijuAgent"/>.</param>
        /// <returns>The <see cref="Agents.Movement.KaijuMovement"/>.</returns>
        protected override KaijuMovement Assign([NotNull] KaijuAgent agent)
        {
            return agent.ObstacleAvoidance(avoidance, distance, SideDistance, angle, height, horizontal, Weight, clear);
        }
        
        /// <summary>
        /// Get a description of the object.
        /// </summary>
        /// <returns>A description of the object.</returns>
        public override string ToString()
        {
            return $"Kaiju Obstacle Avoidance Movement Tester {name}";
        }
    }
}