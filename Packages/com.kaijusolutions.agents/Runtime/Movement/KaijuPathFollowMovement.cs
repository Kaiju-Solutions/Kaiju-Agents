using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using KaijuSolutions.Agents.Extensions;
using UnityEngine;
using UnityEngine.AI;
#if UNITY_EDITOR
using UnityEditor;
#endif
namespace KaijuSolutions.Agents.Movement
{
    /// <summary>
    /// Path following steering behaviour.
    /// </summary>
    public class KaijuPathFollowMovement : KaijuMovement
    {
        /// <summary>
        /// The position to move in relation to.
        /// </summary>
        public Vector2 Target
        {
            get => _transform ? _transform.position.Flatten() : _vector3?.Flatten() ?? (Agent ? Agent.transform.position.Flatten() : Vector2.zero);
            set
            {
                _transform = null;
                Vector3 expanded = value.Expand();
                _vector3 = expanded;
                Previous3 = expanded;
                CalculatePath();
            }
        }
        
        /// <summary>
        /// The position to move in relation to.
        /// </summary>
        public Vector3 Target3
        {
            get => _transform ? _transform.position : _vector3 ?? (Agent ? Agent.transform.position : Vector2.zero);
            set
            {
                _transform = null;
                _vector3 = value;
                Previous3 = value;
                CalculatePath();
            }
        }
        
        /// <summary>
        /// The <see href="https://docs.unity3d.com/Manual/class-Transform.html">transform</see> to move in relation to.
        /// </summary>
        public Transform TargetTransform
        {
            get => _transform;
            set
            {
                _transform = value;
                _vector3 = null;
                Previous3 = value.position;
                CalculatePath();
            }
        }
        
        /// <summary>
        /// The <see href="https://docs.unity3d.com/Manual/class-GameObject.html">GameObject</see> to move in relation to.
        /// </summary>
        public GameObject TargetGameObject
        {
            get => _transform.gameObject;
            set => TargetTransform = value.transform;
        }
        
        /// <summary>
        /// The <see cref="KaijuAgent"/> to move in relation to.
        /// </summary>
        public KaijuAgent TargetAgent
        {
            get => _transform ? _transform.GetComponent<KaijuAgent>() : null;
            set => TargetTransform = value.transform;
        }
        
        /// <summary>
        /// The component to move in relation to.
        /// </summary>
        public Component TargetComponent
        {
            set => TargetTransform = value.transform;
        }
        
        /// <summary>
        /// The internal <see href="https://docs.unity3d.com/Manual/class-Transform.html">transform</see> value.
        /// </summary>
        private Transform _transform;
        
        /// <summary>
        /// The internal vector value.
        /// </summary>
        private Vector3? _vector3;
        
        /// <summary>
        /// The path of points to follow.
        /// </summary>
        public IReadOnlyList<Vector3> Path => _path;
        
        /// <summary>
        /// The path of points to follow.
        /// </summary>
        private readonly List<Vector3> _path = new();
        
        /// <summary>
        /// The structure to get the navigation information from.
        /// </summary>
        private readonly NavMeshPath _navMeshPath = new();
        
        /// <summary>
        /// The distance at which we can consider this behaviour done.
        /// </summary>
        public float Distance
        {
            get => _distance;
            set => _distance = Mathf.Max(0, value);
        }
        
        /// <summary>
        /// The current distance between the <see cref="KaijuAgent"/> and the target.
        /// </summary>
        public float CurrentDistance => Done() ? 0 : Target.Distance(Agent.Position);
        
        /// <summary>
        /// The current distance between the <see cref="KaijuAgent"/> and the target across all axes.
        /// </summary>
        public float CurrentDistance3 => Done() ? 0 : Target3.Distance3(Agent.Position3);
        
        /// <summary>
        /// The total distance from the <see cref="KaijuAgent"/> along the <see cref="Path"/> to the <see cref="Target"/> along the X and Z axes.
        /// </summary>
        public float PathDistance
        {
            get
            {
                if (Done())
                {
                    return 0;
                }
                
                float distance = 0;
                if (_path.Count > 0)
                {
                    distance += Agent.Position.Distance(_path[0].Flatten());

                    for (int i = 0; i < _path.Count - 1; i++)
                    {
                        distance += _path[i].Flatten().Distance(_path[i + 1].Flatten());
                    }
                }
                
                return distance + Target.Distance(_path[^1].Flatten());
            }
        }
        
        /// <summary>
        /// The total distance from the <see cref="KaijuAgent"/> along the <see cref="Path"/> to the <see cref="Target3"/> along all three axes.
        /// </summary>
        public float PathDistance3
        {
            get
            {
                if (Done())
                {
                    return 0;
                }
                
                float distance = 0;
                if (_path.Count > 0)
                {
                    distance += Agent.Position3.Distance3(_path[0]);

                    for (int i = 0; i < _path.Count - 1; i++)
                    {
                        distance += _path[i].Distance3(_path[i + 1]);
                    }
                }
                
                return distance + Target3.Distance3(_path[^1]);
            }
        }
        
        /// <summary>
        /// The distance at which we can consider this behaviour done.
        /// </summary>
        private float _distance;
        
        /// <summary>
        /// The distance to automatically recalculate the path from, with NULL not performing recalculations automatically.
        /// </summary>
        public float? AutoCalculateDistance
        {
            get => _autoCalculateDistance;
            set => _autoCalculateDistance = value.HasValue ? Mathf.Max(value.Value, 0) : null;
        }
        
        /// <summary>
        /// The distance to automatically recalculate the path from, with NULL not performing recalculations automatically.
        /// </summary>
        private float? _autoCalculateDistance;
        
        /// <summary>
        /// The previous position of the target.
        /// </summary>
        public Vector2 Previous
        {
            get => Previous3.Flatten();
            set => Previous3 = value.Expand();
        }
        
        /// <summary>
        /// The previous position of the target.
        /// </summary>
        public Vector3 Previous3;
        
        /// <summary>
        /// A bitfield mask specifying which navigation mesh areas can be used for the path.
        /// </summary>
        public int? Mask
        {
            get => _mask;
            set
            {
                _mask = value;
                _filter = null;
            }
        }
        
        /// <summary>
        /// A bitfield mask specifying which navigation mesh areas can be used for the path.
        /// </summary>
        private int? _mask;
        
        /// <summary>
        /// Filter for the navigation calculations.
        /// </summary>
        public NavMeshQueryFilter? Filter
        {
            get => _filter;
            set
            {
                _filter = value;
                _mask = null;
            }
        }
        
        /// <summary>
        /// Filter for the navigation calculations.
        /// </summary>
        private NavMeshQueryFilter? _filter;
        
        /// <summary>
        /// Get a path following movement.
        /// </summary>
        /// <param name="agent">The agent this is assigned to.</param>
        /// <param name="target">The position to pathfind to.</param>
        /// <param name="mask">A bitfield mask specifying which navigation mesh areas can be used for the path.</param>
        /// <param name="distance">The distance from the target to consider this movement done.</param>
        /// <param name="autoCalculateDistance">The distance to automatically recalculate the path from, with NULL not performing recalculations automatically.</param>
        /// <param name="weight">The weight of this movement.</param>
        public static KaijuPathFollowMovement Get([NotNull] KaijuAgent agent, Vector2 target, int mask = NavMesh.AllAreas, float distance = 0.1f, float? autoCalculateDistance = null, float weight = 1)
        {
            KaijuPathFollowMovement movement = KaijuMovementManager.Get<KaijuPathFollowMovement>();
            if (movement == null)
            {
                return new(agent, target, mask, distance, autoCalculateDistance, weight);
            }
            
            movement.Initialize(agent, target, distance, mask, autoCalculateDistance, weight);
            return movement;
        }
        
        /// <summary>
        /// Get a path following movement.
        /// </summary>
        /// <param name="agent">The agent this is assigned to.</param>
        /// <param name="target">The position to pathfind to.</param>
        /// <param name="mask">A bitfield mask specifying which navigation mesh areas can be used for the path.</param>
        /// <param name="distance">The distance from the target to consider this movement done.</param>
        /// <param name="autoCalculateDistance">The distance to automatically recalculate the path from, with NULL not performing recalculations automatically.</param>
        /// <param name="weight">The weight of this movement.</param>
        public static KaijuPathFollowMovement Get([NotNull] KaijuAgent agent, Vector3 target, int mask = NavMesh.AllAreas, float distance = 0.1f, float? autoCalculateDistance = null, float weight = 1)
        {
            KaijuPathFollowMovement movement = KaijuMovementManager.Get<KaijuPathFollowMovement>();
            if (movement == null)
            {
                return new(agent, target, mask, distance, autoCalculateDistance, weight);
            }
            
            movement.Initialize(agent, target, distance, mask, autoCalculateDistance, weight);
            return movement;
        }
        
        /// <summary>
        /// Get a path following movement.
        /// </summary>
        /// <param name="agent">The agent this is assigned to.</param>
        /// <param name="target">The position to pathfind to.</param>
        /// <param name="mask">A bitfield mask specifying which navigation mesh areas can be used for the path.</param>
        /// <param name="distance">The distance from the target to consider this movement done.</param>
        /// <param name="autoCalculateDistance">The distance to automatically recalculate the path from, with NULL not performing recalculations automatically.</param>
        /// <param name="weight">The weight of this movement.</param>
        public static KaijuPathFollowMovement Get([NotNull] KaijuAgent agent, Component target, int mask = NavMesh.AllAreas, float distance = 0.1f, float? autoCalculateDistance = null, float weight = 1)
        {
            KaijuPathFollowMovement movement = KaijuMovementManager.Get<KaijuPathFollowMovement>();
            if (movement == null)
            {
                return new(agent, target, mask, distance, autoCalculateDistance, weight);
            }
            
            movement.Initialize(agent, target, distance, mask, autoCalculateDistance, weight);
            return movement;
        }
        
        /// <summary>
        /// Get a path following movement.
        /// </summary>
        /// <param name="agent">The agent this is assigned to.</param>
        /// <param name="target">The position to pathfind to.</param>
        /// <param name="mask">A bitfield mask specifying which navigation mesh areas can be used for the path.</param>
        /// <param name="distance">The distance from the target to consider this movement done.</param>
        /// <param name="autoCalculateDistance">The distance to automatically recalculate the path from, with NULL not performing recalculations automatically.</param>
        /// <param name="weight">The weight of this movement.</param>
        public static KaijuPathFollowMovement Get([NotNull] KaijuAgent agent, GameObject target, int mask = NavMesh.AllAreas, float distance = 0.1f, float? autoCalculateDistance = null, float weight = 1)
        {
            KaijuPathFollowMovement movement = KaijuMovementManager.Get<KaijuPathFollowMovement>();
            if (movement == null)
            {
                return new(agent, target, mask, distance, autoCalculateDistance, weight);
            }
            
            movement.Initialize(agent, target, distance, mask, autoCalculateDistance, weight);
            return movement;
        }
        
        /// <summary>
        /// Get a path following movement.
        /// </summary>
        /// <param name="agent">The agent this is assigned to.</param>
        /// <param name="target">The position to pathfind to.</param>
        /// <param name="filter">Filter for the navigation calculations.</param>
        /// <param name="distance">The distance from the target to consider this movement done.</param>
        /// <param name="autoCalculateDistance">The distance to automatically recalculate the path from, with NULL not performing recalculations automatically.</param>
        /// <param name="weight">The weight of this movement.</param>
        public static KaijuPathFollowMovement Get([NotNull] KaijuAgent agent, Vector2 target, NavMeshQueryFilter filter, float distance = 0.1f, float? autoCalculateDistance = null, float weight = 1)
        {
            KaijuPathFollowMovement movement = KaijuMovementManager.Get<KaijuPathFollowMovement>();
            if (movement == null)
            {
                return new(agent, target, filter, distance, autoCalculateDistance, weight);
            }
            
            movement.Initialize(agent, target, distance, filter, autoCalculateDistance, weight);
            return movement;
        }
        
        /// <summary>
        /// Get a path following movement.
        /// </summary>
        /// <param name="agent">The agent this is assigned to.</param>
        /// <param name="target">The position to pathfind to.</param>
        /// <param name="filter">Filter for the navigation calculations.</param>
        /// <param name="distance">The distance from the target to consider this movement done.</param>
        /// <param name="autoCalculateDistance">The distance to automatically recalculate the path from, with NULL not performing recalculations automatically.</param>
        /// <param name="weight">The weight of this movement.</param>
        public static KaijuPathFollowMovement Get([NotNull] KaijuAgent agent, Vector3 target, NavMeshQueryFilter filter, float distance = 0.1f, float? autoCalculateDistance = null, float weight = 1)
        {
            KaijuPathFollowMovement movement = KaijuMovementManager.Get<KaijuPathFollowMovement>();
            if (movement == null)
            {
                return new(agent, target, filter, distance, autoCalculateDistance, weight);
            }
            
            movement.Initialize(agent, target, distance, filter, autoCalculateDistance, weight);
            return movement;
        }
        
        /// <summary>
        /// Get a path following movement.
        /// </summary>
        /// <param name="agent">The agent this is assigned to.</param>
        /// <param name="target">The position to pathfind to.</param>
        /// <param name="filter">Filter for the navigation calculations.</param>
        /// <param name="distance">The distance from the target to consider this movement done.</param>
        /// <param name="autoCalculateDistance">The distance to automatically recalculate the path from, with NULL not performing recalculations automatically.</param>
        /// <param name="weight">The weight of this movement.</param>
        public static KaijuPathFollowMovement Get([NotNull] KaijuAgent agent, Component target, NavMeshQueryFilter filter, float distance = 0.1f, float? autoCalculateDistance = null, float weight = 1)
        {
            KaijuPathFollowMovement movement = KaijuMovementManager.Get<KaijuPathFollowMovement>();
            if (movement == null)
            {
                return new(agent, target, filter, distance, autoCalculateDistance, weight);
            }
            
            movement.Initialize(agent, target, distance, filter, autoCalculateDistance, weight);
            return movement;
        }
        
        /// <summary>
        /// Get a path following movement.
        /// </summary>
        /// <param name="agent">The agent this is assigned to.</param>
        /// <param name="target">The position to pathfind to.</param>
        /// <param name="filter">Filter for the navigation calculations.</param>
        /// <param name="distance">The distance from the target to consider this movement done.</param>
        /// <param name="autoCalculateDistance">The distance to automatically recalculate the path from, with NULL not performing recalculations automatically.</param>
        /// <param name="weight">The weight of this movement.</param>
        public static KaijuPathFollowMovement Get([NotNull] KaijuAgent agent, GameObject target, NavMeshQueryFilter filter, float distance = 0.1f, float? autoCalculateDistance = null, float weight = 1)
        {
            KaijuPathFollowMovement movement = KaijuMovementManager.Get<KaijuPathFollowMovement>();
            if (movement == null)
            {
                return new(agent, target, filter, distance, autoCalculateDistance, weight);
            }
            
            movement.Initialize(agent, target, distance, filter, autoCalculateDistance, weight);
            return movement;
        }
        
        /// <summary>
        /// Create a path following movement.
        /// </summary>
        /// <param name="agent">The agent this is assigned to.</param>
        /// <param name="target">The position to pathfind to.</param>
        /// <param name="mask">A bitfield mask specifying which navigation mesh areas can be used for the path.</param>
        /// <param name="distance">The distance from the target to consider this movement done.</param>
        /// <param name="autoCalculateDistance">The distance to automatically recalculate the path from, with NULL not performing recalculations automatically.</param>
        /// <param name="weight">The weight of this movement.</param>
        public KaijuPathFollowMovement([NotNull] KaijuAgent agent, Vector2 target, int mask = NavMesh.AllAreas, float distance = 0.1f, float? autoCalculateDistance = null, float weight = 1) : base(agent, weight)
        {
            Initialize(agent, target, distance, mask, autoCalculateDistance, weight);
        }

        /// <summary>
        /// Create a path following movement.
        /// </summary>
        /// <param name="agent">The agent this is assigned to.</param>
        /// <param name="target">The position to pathfind to.</param>
        /// <param name="mask">A bitfield mask specifying which navigation mesh areas can be used for the path.</param>
        /// <param name="distance">The distance from the target to consider this movement done.</param>
        /// <param name="autoCalculateDistance">The distance to automatically recalculate the path from, with NULL not performing recalculations automatically.</param>
        /// <param name="weight">The weight of this movement.</param>
        public KaijuPathFollowMovement([NotNull] KaijuAgent agent, Vector3 target, int mask = NavMesh.AllAreas, float distance = 0.1f, float? autoCalculateDistance = null, float weight = 1) : base(agent, weight)
        {
            Initialize(agent, target, distance, mask, autoCalculateDistance, weight);
        }

        /// <summary>
        /// Create a path following movement.
        /// </summary>
        /// <param name="agent">The agent this is assigned to.</param>
        /// <param name="target">The <see href="https://docs.unity3d.com/Manual/class-GameObject.html">GameObject</see> to pathfind to.</param>
        /// <param name="mask">A bitfield mask specifying which navigation mesh areas can be used for the path.</param>
        /// <param name="distance">The distance from the target to consider this movement done.</param>
        /// <param name="autoCalculateDistance">The distance to automatically recalculate the path from, with NULL not performing recalculations automatically.</param>
        /// <param name="weight">The weight of this movement.</param>
        public KaijuPathFollowMovement([NotNull] KaijuAgent agent, [NotNull] GameObject target, int mask = NavMesh.AllAreas, float distance = 0.1f, float? autoCalculateDistance = null, float weight = 1) : base(agent, weight)
        {
            Initialize(agent, target, distance, mask, autoCalculateDistance, weight);
        }

        /// <summary>
        /// Create a path following movement.
        /// </summary>
        /// <param name="agent">The agent this is assigned to.</param>
        /// <param name="target">The component to pathfind to.</param>
        /// <param name="mask">A bitfield mask specifying which navigation mesh areas can be used for the path.</param>
        /// <param name="distance">The distance from the target to consider this movement done.</param>
        /// <param name="autoCalculateDistance">The distance to automatically recalculate the path from, with NULL not performing recalculations automatically.</param>
        /// <param name="weight">The weight of this movement.</param>
        public KaijuPathFollowMovement([NotNull] KaijuAgent agent, [NotNull] Component target, int mask = NavMesh.AllAreas, float distance = 0.1f, float? autoCalculateDistance = null, float weight = 1) : base(agent, weight)
        {
            Initialize(agent, target, distance, mask, autoCalculateDistance, weight);
        }
        
        /// <summary>
        /// Create a path following movement.
        /// </summary>
        /// <param name="agent">The agent this is assigned to.</param>
        /// <param name="target">The position to pathfind to.</param>
        /// <param name="filter">Filter for the navigation calculations.</param>
        /// <param name="distance">The distance from the target to consider this movement done.</param>
        /// <param name="autoCalculateDistance">The distance to automatically recalculate the path from, with NULL not performing recalculations automatically.</param>
        /// <param name="weight">The weight of this movement.</param>
        public KaijuPathFollowMovement([NotNull] KaijuAgent agent, Vector2 target, NavMeshQueryFilter filter, float distance = 0.1f, float? autoCalculateDistance = null, float weight = 1) : base(agent, weight)
        {
            Initialize(agent, target, distance, filter, autoCalculateDistance, weight);
        }
        
        /// <summary>
        /// Create a path following movement.
        /// </summary>
        /// <param name="agent">The agent this is assigned to.</param>
        /// <param name="target">The position to pathfind to.</param>
        /// <param name="filter">Filter for the navigation calculations.</param>
        /// <param name="distance">The distance from the target to consider this movement done.</param>
        /// <param name="autoCalculateDistance">The distance to automatically recalculate the path from, with NULL not performing recalculations automatically.</param>
        /// <param name="weight">The weight of this movement.</param>
        public KaijuPathFollowMovement([NotNull] KaijuAgent agent, Vector3 target, NavMeshQueryFilter filter, float distance = 0.1f, float? autoCalculateDistance = null, float weight = 1) : base(agent, weight)
        {
            Initialize(agent, target, distance, filter, autoCalculateDistance, weight);
        }
        
        /// <summary>
        /// Create a path following movement.
        /// </summary>
        /// <param name="agent">The agent this is assigned to.</param>
        /// <param name="target">The <see href="https://docs.unity3d.com/Manual/class-GameObject.html">GameObject</see> to pathfind to.</param>
        /// <param name="filter">Filter for the navigation calculations.</param>
        /// <param name="distance">The distance from the target to consider this movement done.</param>
        /// <param name="autoCalculateDistance">The distance to automatically recalculate the path from, with NULL not performing recalculations automatically.</param>
        /// <param name="weight">The weight of this movement.</param>
        public KaijuPathFollowMovement([NotNull] KaijuAgent agent, [NotNull] GameObject target, NavMeshQueryFilter filter, float distance = 0.1f, float? autoCalculateDistance = null, float weight = 1) : base(agent, weight)
        {
            Initialize(agent, target, distance, filter, autoCalculateDistance, weight);
        }
        
        /// <summary>
        /// Create a path following movement.
        /// </summary>
        /// <param name="agent">The agent this is assigned to.</param>
        /// <param name="target">The component to pathfind to.</param>
        /// <param name="filter">Filter for the navigation calculations.</param>
        /// <param name="distance">The distance from the target to consider this movement done.</param>
        /// <param name="autoCalculateDistance">The distance to automatically recalculate the path from, with NULL not performing recalculations automatically.</param>
        /// <param name="weight">The weight of this movement.</param>
        public KaijuPathFollowMovement([NotNull] KaijuAgent agent, [NotNull] Component target, NavMeshQueryFilter filter, float distance = 0.1f, float? autoCalculateDistance = null, float weight = 1) : base(agent, weight)
        {
            Initialize(agent, target, distance, filter, autoCalculateDistance, weight);
        }
        
        /// <summary>
        /// Initialize the movement.
        /// </summary>
        /// <param name="agent">The agent this is assigned to.</param>
        /// <param name="target">The component to move in relation to.</param>
        /// <param name="distance">The distance to consider this move done.</param>
        /// <param name="mask">A bitfield mask specifying which navigation mesh areas can be used for the path.</param>
        /// <param name="autoCalculateDistance">The distance to automatically recalculate the path from, with NULL not performing recalculations automatically.</param>
        /// <param name="weight">The weight of this movement.</param>
        public void Initialize([NotNull] KaijuAgent agent, Vector2 target, float distance, int mask = NavMesh.AllAreas, float? autoCalculateDistance = null, float weight = 1)
        {
            AutoCalculateDistance = autoCalculateDistance;
            Distance = distance;
            Mask = mask;
            Initialize(agent, weight);
            Target = target;
        }
        
        /// <summary>
        /// Initialize the movement.
        /// </summary>
        /// <param name="agent">The agent this is assigned to.</param>
        /// <param name="target">The component to move in relation to.</param>
        /// <param name="distance">The distance to consider this move done.</param>
        /// <param name="mask">A bitfield mask specifying which navigation mesh areas can be used for the path.</param>
        /// <param name="autoCalculateDistance">The distance to automatically recalculate the path from, with NULL not performing recalculations automatically.</param>
        /// <param name="weight">The weight of this movement.</param>
        public void Initialize([NotNull] KaijuAgent agent, Vector3 target, float distance, int mask = NavMesh.AllAreas, float? autoCalculateDistance = null, float weight = 1)
        {
            AutoCalculateDistance = autoCalculateDistance;
            Distance = distance;
            Mask = mask;
            Initialize(agent, weight);
            Target3 = target;
        }
        
        /// <summary>
        /// Initialize the movement.
        /// </summary>
        /// <param name="agent">The agent this is assigned to.</param>
        /// <param name="target">The component to move in relation to.</param>
        /// <param name="distance">The distance to consider this move done.</param>
        /// <param name="mask">A bitfield mask specifying which navigation mesh areas can be used for the path.</param>
        /// <param name="autoCalculateDistance">The distance to automatically recalculate the path from, with NULL not performing recalculations automatically.</param>
        /// <param name="weight">The weight of this movement.</param>
        public void Initialize([NotNull] KaijuAgent agent, [NotNull] Component target, float distance, int mask = NavMesh.AllAreas, float? autoCalculateDistance = null, float weight = 1)
        {
            AutoCalculateDistance = autoCalculateDistance;
            Distance = distance;
            Mask = mask;
            Initialize(agent, weight);
            TargetComponent = target;
        }
        
        /// <summary>
        /// Initialize the movement.
        /// </summary>
        /// <param name="agent">The agent this is assigned to.</param>
        /// <param name="target">The component to move in relation to.</param>
        /// <param name="distance">The distance to consider this move done.</param>
        /// <param name="mask">A bitfield mask specifying which navigation mesh areas can be used for the path.</param>
        /// <param name="autoCalculateDistance">The distance to automatically recalculate the path from, with NULL not performing recalculations automatically.</param>
        /// <param name="weight">The weight of this movement.</param>
        public void Initialize([NotNull] KaijuAgent agent, [NotNull] GameObject target, float distance, int mask = NavMesh.AllAreas, float? autoCalculateDistance = null, float weight = 1)
        {
            AutoCalculateDistance = autoCalculateDistance;
            Distance = distance;
            Mask = mask;
            Initialize(agent, weight);
            TargetGameObject = target;
        }
        
        /// <summary>
        /// Initialize the movement.
        /// </summary>
        /// <param name="agent">The agent this is assigned to.</param>
        /// <param name="target">The component to move in relation to.</param>
        /// <param name="distance">The distance to consider this move done.</param>
        /// <param name="filter">Filter for the navigation calculations.</param>
        /// <param name="autoCalculateDistance">The distance to automatically recalculate the path from, with NULL not performing recalculations automatically.</param>
        /// <param name="weight">The weight of this movement.</param>
        public void Initialize([NotNull] KaijuAgent agent, Vector2 target, float distance, NavMeshQueryFilter filter, float? autoCalculateDistance = null, float weight = 1)
        {
            AutoCalculateDistance = autoCalculateDistance;
            Distance = distance;
            Filter = filter;
            Initialize(agent, weight);
            Target = target;
        }
        
        /// <summary>
        /// Initialize the movement.
        /// </summary>
        /// <param name="agent">The agent this is assigned to.</param>
        /// <param name="target">The component to move in relation to.</param>
        /// <param name="distance">The distance to consider this move done.</param>
        /// <param name="filter">Filter for the navigation calculations.</param>
        /// <param name="autoCalculateDistance">The distance to automatically recalculate the path from, with NULL not performing recalculations automatically.</param>
        /// <param name="weight">The weight of this movement.</param>
        public void Initialize([NotNull] KaijuAgent agent, Vector3 target, float distance, NavMeshQueryFilter filter, float? autoCalculateDistance = null, float weight = 1)
        {
            AutoCalculateDistance = autoCalculateDistance;
            Distance = distance;
            Filter = filter;
            Initialize(agent, weight);
            Target3 = target;
        }
        
        /// <summary>
        /// Initialize the movement.
        /// </summary>
        /// <param name="agent">The agent this is assigned to.</param>
        /// <param name="target">The component to move in relation to.</param>
        /// <param name="distance">The distance to consider this move done.</param>
        /// <param name="filter">Filter for the navigation calculations.</param>
        /// <param name="autoCalculateDistance">The distance to automatically recalculate the path from, with NULL not performing recalculations automatically.</param>
        /// <param name="weight">The weight of this movement.</param>
        public void Initialize([NotNull] KaijuAgent agent, [NotNull] Component target, float distance, NavMeshQueryFilter filter, float? autoCalculateDistance = null, float weight = 1)
        {
            AutoCalculateDistance = autoCalculateDistance;
            Distance = distance;
            Filter = filter;
            Initialize(agent, weight);
            TargetComponent = target;
        }
        
        /// <summary>
        /// Initialize the movement.
        /// </summary>
        /// <param name="agent">The agent this is assigned to.</param>
        /// <param name="target">The component to move in relation to.</param>
        /// <param name="distance">The distance to consider this move done.</param>
        /// <param name="filter">Filter for the navigation calculations.</param>
        /// <param name="autoCalculateDistance">The distance to automatically recalculate the path from, with NULL not performing recalculations automatically.</param>
        /// <param name="weight">The weight of this movement.</param>
        public void Initialize([NotNull] KaijuAgent agent, [NotNull] GameObject target, float distance, NavMeshQueryFilter filter, float? autoCalculateDistance = null, float weight = 1)
        {
            AutoCalculateDistance = autoCalculateDistance;
            Distance = distance;
            Filter = filter;
            Initialize(agent, weight);
            TargetGameObject = target;
        }
        
        /// <summary>
        /// Calculate the path to the target.
        /// </summary>
        public void CalculatePath()
        {
            // Clear the old path.
            _path.Clear();
            
            // Nothing to do if no agent of target.
            if (!Agent || (!_vector3.HasValue && !_transform))
            {
                return;
            }
            
            // Update that the position has been accounted for.
            Previous3 = Target3;
            
            // Calculate the new path. If it fails, it means the point is off of the navigation mesh.
            int mask = _filter?.areaMask ?? _mask ?? NavMesh.AllAreas;
            if (!NavMesh.SamplePosition(Previous3, out NavMeshHit hit, float.MaxValue, mask) || !NavMesh.CalculatePath(Agent.Position3, hit.position, mask, _navMeshPath))
            {
                return;
            }
            
            // Copy the path.
            Vector3[] points = new Vector3[_navMeshPath.corners.Length];
            _navMeshPath.GetCornersNonAlloc(points);
            for (int index = 0; index < points.Length; index++)
            {
                _path.Add(_navMeshPath.corners[index]);
            }
            
            // Clear the now no-longer-used navigation path.
            _navMeshPath.ClearCorners();
        }
        
        /// <summary>
        /// Perform any needed reset operations.
        /// </summary>
        protected override void Reset()
        {
            base.Reset();
            _path.Clear();
            _autoCalculateDistance = null;
            Previous3 = Vector3.zero;
            _mask = null;
            _filter = null;
        }

        /// <summary>
        /// Determine if the movement is done or not.
        /// </summary>
        /// <returns>If the movement is done or not.</returns>
        public override bool Done()
        {
            return base.Done() || (!_transform && _vector3 == null);
        }
        
        /// <summary>
        /// Get the movement.
        /// </summary>
        /// <param name="position">The position of the <see cref="KaijuMovement.Agent"/>.</param>
        /// <param name="delta">The time step.</param>
        /// <returns>The calculated movement.</returns>
        public override Vector2 Move(Vector2 position, float delta)
        {
            // Recalculate the path if we should.
            if (_autoCalculateDistance.HasValue && (_autoCalculateDistance.Value <= 0 || Target3.Beyond3(Previous3, _autoCalculateDistance.Value)))
            {
                CalculatePath();
            }
            
            // Unity's pathfinding calculates along all three axes, so use that to determine if a point has been reached.
            Vector3 positions3 = Agent.Position3;
            
            // Remove reached positions.
            for (int i = 0; i < _path.Count; i++)
            {
                // If this position has been reached, remove it.
                if (!positions3.Within3(_path[i], _distance))
                {
                    // Otherwise, seek towards the next position in the path.
                    return position.Seek(_path[i], Agent.MoveSpeed);
                }
                
                _path.RemoveAt(i--);
            }
            
            // Lastly, seek towards the final target.
            return position.Seek(Target, Agent.MoveSpeed);
        }
#if UNITY_EDITOR
        /// <summary>
        /// Get the color for visualizations.
        /// </summary>
        /// <returns>The color for visualizations</returns>
        protected override Color EditorVisualizationColor() => KaijuMovementManager.EditorPathFollowColor;
        
        /// <summary>
        /// Render the visualization of the movement.
        /// <param name="position">The position of the <see cref="KaijuMovement.Agent"/>.</param>
        /// </summary>
        protected override void EditorRenderVisualizations(Vector3 position)
        {
            // If no path, render straight to the target.
            if (_path.Count < 1)
            {
                Handles.DrawLine(position, Previous3);
            }
            else
            {
                // Otherwise, render the entire path.
                Handles.DrawLine(position, _path[0]);
                for (int i = 0; i < _path.Count - 1; i++)
                {
                    Handles.DrawLine(_path[i], _path[i + 1]);
                }
                
                Handles.DrawLine(_path[^1], Previous3);
            }
            
            // Show the offset from the actual target to the current position.
            Vector3 t = Target3;
            if (t != Previous3)
            {
                Handles.DrawLine(Previous3, t);
            }
            
            // Draw the auto calculate distance.
            if (_autoCalculateDistance.HasValue)
            {
                Handles.DrawWireDisc(Previous3, Vector3.up, _autoCalculateDistance.Value, 0);
            }
        }
#endif
    }
}