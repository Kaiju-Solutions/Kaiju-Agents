using UnityEngine;

namespace KaijuSolutions.Agents.Movement
{
    /// <summary>
    /// Allow for defining <see cref="KaijuMovement"/> settings for <see cref="KaijuAgent"/>s to use as default values.
    /// </summary>
#if UNITY_EDITOR
    [CreateAssetMenu(fileName = "Kaiju Movement Configuration", menuName = "Kaiju Solutions/Agents/Kaiju Movement Configuration", order = 0)]
    [Icon("Packages/com.kaijusolutions.agents/Editor/Icon.png")]
    [HelpURL("https://agents.kaijusolutions.ca")]
#endif
    public class KaijuMovementConfiguration : ScriptableObject
    {
        /// <summary>
        /// The default collision layer mask.
        /// </summary>
        public const int DefaultMask = -5;
        
        /// <summary>
        /// The default weight of all <see cref="KaijuMovement"/>s.
        /// </summary>
        public float Weight
        {
            get => weight;
            set => weight = Mathf.Max(value, 0);
        }
        
        /// <summary>
        /// The default weight of all <see cref="KaijuMovement"/>s.
        /// </summary>
#if UNITY_EDITOR
        [Header("General")]
        [Tooltip("The default weight of all movements.")]
#endif
        [Min(0)]
        [SerializeField]
        private float weight = KaijuMovement.DefaultWeight;
        
        /// <summary>
        /// The default behaviour for if new <see cref="KaijuMovement"/>s should clear all other current <see cref="KaijuMovement"/>s and become the only one the <see cref="KaijuAgent"/> is performing.
        /// </summary>
#if UNITY_EDITOR
        [Tooltip("The default behaviour for if new movements should clear all other current movements and become the only one the agent is performing.")]
#endif
        [SerializeField]
        public bool clear = true;
        
        /// <summary>
        /// The default distance at which we can consider <see cref="KaijuSeekMovement"/>, <see cref="KaijuPursueMovement"/>, and <see cref="KaijuPathFollowMovement"/> behaviours done.
        /// </summary>
        public float ApproachingDistance
        {
            get => approachingDistance;
            set => approachingDistance = Mathf.Max(value, 0);
        }
        
        /// <summary>
        /// The default distance at which we can consider <see cref="KaijuSeekMovement"/>, <see cref="KaijuPursueMovement"/>, and <see cref="KaijuPathFollowMovement"/> behaviours done.
        /// </summary>
#if UNITY_EDITOR
        [Header("Approaching")]
        [Tooltip("The default distance at which we can consider seek, pursue, and path following behaviours done.")]
#endif
        [Min(0)]
        [SerializeField]
        private float approachingDistance = KaijuApproachingMovement.DefaultDistance;
        
        /// <summary>
        /// The default distance at which we can consider <see cref="KaijuFleeMovement"/> and <see cref="KaijuEvadeMovement"/> behaviours done.
        /// </summary>
        public float LeavingDistance
        {
            get => leavingDistance;
            set => leavingDistance = Mathf.Max(value, float.Epsilon);
        }
        
        /// <summary>
        /// The default distance from the target at which we can consider <see cref="KaijuFleeMovement"/> and <see cref="KaijuEvadeMovement"/> behaviours done.
        /// </summary>
#if UNITY_EDITOR
        [Header("Leaving")]
        [Tooltip("The default distance at which we can consider flee and evade behaviours done.")]
#endif
        [Min(float.Epsilon)]
        [SerializeField]
        private float leavingDistance = KaijuLeavingMovement.DefaultDistance;
        
        /// <summary>
        /// How far out to generate the <see cref="KaijuWanderMovement"/> circles by default.
        /// </summary>
        public float WanderDistance
        {
            get => wanderDistance;
            set => wanderDistance = Mathf.Max(value, 0);
        }
        
        /// <summary>
        /// How far out to generate the <see cref="KaijuWanderMovement"/> circles by default.
        /// </summary>
#if UNITY_EDITOR
        [Header("Wander")]
        [Tooltip("How far out to generate the wander circles by default.")]
#endif
        [Min(0)]
        [SerializeField]
        private float wanderDistance = KaijuWanderMovement.DefaultDistance;
        
        /// <summary>
        /// The radius of the <see cref="KaijuWanderMovement"/> circles by default.
        /// </summary>
        public float WanderRadius
        {
            get => wanderRadius;
            set => wanderRadius = Mathf.Max(value, 0);
        }
        
        /// <summary>
        /// The radius of the <see cref="KaijuWanderMovement"/> circles by default.
        /// </summary>
#if UNITY_EDITOR
        [Tooltip("The radius of the wander circles by default.")]
#endif
        [Min(0)]
        [SerializeField]
        private float wanderRadius = KaijuWanderMovement.DefaultRadius;
        
        /// <summary>
        /// The default distance to interact with other <see cref="KaijuAgent"/>s from.
        /// </summary>
        public float SeparationDistance
        {
            get => separationDistance;
            set => separationDistance = Mathf.Max(value, float.Epsilon);
        }
        
        /// <summary>
        /// The default distance to interact with other <see cref="KaijuAgent"/>s from.
        /// </summary>
#if UNITY_EDITOR
        [Header("Separation")]
        [Tooltip("The default distance to interact with other agents from.")]
#endif
        [Min(float.Epsilon)]
        [SerializeField]
        private float separationDistance = KaijuSeparationMovement.DefaultDistance;
        
        /// <summary>
        /// The default distance to interact with other <see cref="KaijuAgent"/>s from.
        /// </summary>
        public float SeparationCoefficient
        {
            get => separationCoefficient;
            set => separationCoefficient = Mathf.Max(value, 0);
        }
        
        /// <summary>
        /// The default coefficient to use for inverse square law separation. Zero will use linear separation.
        /// </summary>
#if UNITY_EDITOR
        [Tooltip("The default coefficient to use for inverse square law separation. Zero will use linear separation.")]
#endif
        [Min(0)]
        [SerializeField]
        private float separationCoefficient = KaijuSeparationMovement.DefaultCoefficient;
        
        /// <summary>
        /// The default distance from a wall the <see cref="KaijuAgent"/> should maintain.
        /// </summary>
        public float Avoidance
        {
            get => avoidance;
            set => avoidance = Mathf.Max(value, float.Epsilon);
        }
        
        /// <summary>
        /// The default distance from a wall the <see cref="KaijuAgent"/> should maintain.
        /// </summary>
#if UNITY_EDITOR
        [Header("Obstacle Avoidance")]
        [Tooltip("The default distance from a wall the agent should maintain.")]
#endif
        [Min(float.Epsilon)]
        [SerializeField]
        private float avoidance = KaijuObstacleAvoidanceMovement.DefaultAvoidance;
        
        /// <summary>
        /// The default distance for rays.
        /// </summary>
        public float AvoidanceDistance
        {
            get => avoidanceDistance;
            set => avoidanceDistance = Mathf.Max(value, float.Epsilon);
        }
        
        /// <summary>
        /// The default distance for rays.
        /// </summary>
#if UNITY_EDITOR
        [Tooltip("The default distance for rays.")]
#endif
        [Min(float.Epsilon)]
        [SerializeField]
        private float avoidanceDistance = KaijuObstacleAvoidanceMovement.DefaultDistance;
        
        /// <summary>
        /// The default distance of the side rays. Zero or less will use the <see cref="AvoidanceDistance"/>.
        /// </summary>
        public float AvoidanceSideDistance
        {
            get => avoidanceSideDistance > 0 ? avoidanceSideDistance : avoidanceDistance;
            set => avoidanceSideDistance = value;
        }
        
        /// <summary>
        /// The default distance of the side rays. Zero or less will use the <see cref="AvoidanceDistance"/>.
        /// </summary>
#if UNITY_EDITOR
        [Tooltip("The default distance of the side rays. Zero or less will use the distance.")]
#endif
        [Min(0)]
        [SerializeField]
        private float avoidanceSideDistance = KaijuObstacleAvoidanceMovement.DefaultSideDistance;
        
        /// <summary>
        /// The default angle for rays.
        /// </summary>
#if UNITY_EDITOR
        [Tooltip("The default angle for the rays.")]
#endif
        public float avoidanceAngle = KaijuObstacleAvoidanceMovement.DefaultAngle;
        
        /// <summary>
        /// The default height offset for the rays.
        /// </summary>
#if UNITY_EDITOR
        [Tooltip("The default height offset for the rays.")]
#endif
        public float avoidanceHeight = KaijuObstacleAvoidanceMovement.DefaultHeight;
        
        /// <summary>
        /// The default horizontal shift for the side rays.
        /// </summary>
#if UNITY_EDITOR
        [Tooltip("The default horizontal shift for the side rays.")]
#endif
        public float avoidanceHorizontal = KaijuObstacleAvoidanceMovement.DefaultHorizontal;
        
        /// <summary>
        /// The default bitfield mask specifying which navigation mesh areas can be used for the path.
        /// </summary>
#if UNITY_EDITOR
        [Header("Path Finding")]
        [Tooltip("The default bitfield mask specifying which navigation mesh areas can be used for the path.")]
#endif
        public int areaMask = KaijuPathFollowMovement.DefaultMask;
        
        /// <summary>
        /// The default layers to use for <see cref="KaijuPathFollowMovement"/> string-pulling and <see cref="KaijuObstacleAvoidanceMovement"/>.
        /// </summary>
#if UNITY_EDITOR
        [Tooltip("The default layers to use for path following string-pulling and obstacle avoidance.")]
#endif
        public LayerMask collisionMask = KaijuMovementConfiguration.DefaultMask;
        
        /// <summary>
        /// How string-pulling should consider triggers by default.
        /// </summary>
#if UNITY_EDITOR
        [Tooltip("How string-pulling should consider triggers by default.")]
#endif
        public QueryTriggerInteraction collisionTriggers = QueryTriggerInteraction.UseGlobal;
        
        /// <summary>
        /// The default distance to automatically recalculate the path from.
        /// </summary>
        public float PathAutoCalculateDistance
        {
            get => pathAutoCalculateDistance;
            set => pathAutoCalculateDistance = Mathf.Max(value, 0);
        }
        
        /// <summary>
        /// The default distance to automatically recalculate the path from.
        /// </summary>
#if UNITY_EDITOR
        [Tooltip("The default distance to automatically recalculate the path from.")]
#endif
        [Min(0)]
        [SerializeField]
        private float pathAutoCalculateDistance = KaijuPathFollowMovement.DefaultAutoCalculateDistance;
    }
}