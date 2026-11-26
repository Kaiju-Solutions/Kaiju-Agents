using System;
using System.Collections.Generic;
using KaijuSolutions.Agents.Movement;
using Unity.AI.Navigation.LowLevel;
using UnityEngine;
using UnityEngine.AI;
#if UNITY_EDITOR
using UnityEditor;
#endif
namespace KaijuSolutions.Agents.Extensions
{
    public enum KaijuSurfacePathStatus { UnmappedStart, UnmappedGoal, Invalid, Partial, Complete }

    /// <summary>
    /// Extension methods for finding a path.
    /// </summary>
    public static class KaijuAgentsFindPath
    {
#if UNITY_EDITOR
        /// <summary>
        /// Handle manually resetting the domain.
        /// </summary>
        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.SubsystemRegistration)]
        private static void InitOnPlayMode()
        {
            Domain();
            EditorApplication.playModeStateChanged -= Domain;
            EditorApplication.playModeStateChanged += Domain;
        }
        
        /// <summary>
        /// Handle manually resetting the domain.
        /// </summary>
        /// <param name="state">The current editor state change.</param>
        private static void Domain(PlayModeStateChange state)
        {
            if (state != PlayModeStateChange.ExitingPlayMode)
            {
                return;
            }
            
            EditorApplication.playModeStateChanged -= Domain;
            Domain();
        }
        
        /// <summary>
        /// Handle manually resetting the domain.
        /// </summary>
        private static void Domain()
        {
            ReleaseWorld();
            Path.ClearCorners();
            ResizeCache();
        }
#endif
        private static NavWorld? _world;

        private static NavWorld GetWorld()
        {
            if (!_world.HasValue)
            {
                _world = NavWorld.GetDefaultWorld();
                Application.quitting += ReleaseWorld;
#if UNITY_EDITOR
                AssemblyReloadEvents.beforeAssemblyReload += ReleaseWorld;
#endif
            }

            return _world.Value;
        }

        private static void ReleaseWorld()
        {
            _world?.Dispose();
            _world = null;
            Application.quitting -= ReleaseWorld;
#if UNITY_EDITOR
            AssemblyReloadEvents.beforeAssemblyReload -= ReleaseWorld;
#endif
        }

        internal static bool TrySurfaceGoal(Vector3 goal, NavMeshQueryFilter filter, float radius, out Vector3 surfaceGoal)
        {
            var world = GetWorld();
            surfaceGoal = default;
            if (!world.IsValid() || radius <= 0) return false;
            var location = world.MapLocation(goal, Vector3.one * radius, filter.agentTypeID, filter.areaMask);
            surfaceGoal = location.position;
            return !location.node.IsNull() && (goal - surfaceGoal).sqrMagnitude <= radius * radius;
        }

        /// <summary>Map both endpoints and compute a strict surface path. Only Complete returns true.
        /// Reuse the path and corner buffer on the main thread. Partial routes expose their available corners.</summary>
        public static bool TryFindSurfacePath(this Vector3 start, Vector3 goal, NavMeshQueryFilter filter,
            float snapDistance, NavMeshPath path, ref Vector3[] corners, out int count,
            out KaijuSurfacePathStatus status, out Vector3 mappedGoal) =>
            TryFindSurfacePath(start, goal, filter, snapDistance, path, ref corners, out count, out status, out mappedGoal, null);

        internal static bool TryFindSurfacePath(this Vector3 start, Vector3 goal, NavMeshQueryFilter filter,
            float snapDistance, NavMeshPath path, ref Vector3[] corners, out int count,
            out KaijuSurfacePathStatus status, out Vector3 mappedGoal, NavMeshAgent agent)
        {
            count = 0;
            mappedGoal = default;
            path.ClearCorners();
            status = KaijuSurfacePathStatus.UnmappedStart;
            if (!TrySurfaceGoal(start, filter, snapDistance, out var mappedStart)) return false;
            status = KaijuSurfacePathStatus.UnmappedGoal;
            if (!TrySurfaceGoal(goal, filter, snapDistance, out mappedGoal)) return false;
            status = KaijuSurfacePathStatus.Invalid;
            if (agent && (!agent.isOnNavMesh || agent.agentTypeID != filter.agentTypeID)) return false;
            bool found = agent ? agent.CalculatePath(mappedGoal, path) : NavMesh.CalculatePath(mappedStart, mappedGoal, filter, path);
            if (!found || path.status == NavMeshPathStatus.PathInvalid) return false;
            if (corners == null || corners.Length == 0) corners = new Vector3[8];
            while ((count = path.GetCornersNonAlloc(corners)) >= corners.Length)
                Array.Resize(ref corners, checked(corners.Length * 2));
            status = path.status == NavMeshPathStatus.PathComplete ? KaijuSurfacePathStatus.Complete : KaijuSurfacePathStatus.Partial;
            return status == KaijuSurfacePathStatus.Complete;
        }

        // Most callers start on or near the mesh. Bound the common spatial query and
        // retain the wide nearest-point search for distant or missing surfaces.
        private static bool Project(NavWorld world, Vector3 point, int mask, NavMeshQueryFilter? filter,
                                    out Vector3 projected, out NavNode node)
        {
            NavLocation location = world.MapLocation(point, Vector3.one, filter?.agentTypeID ?? 0, mask);
            if (!location.node.IsNull() && (location.position - point).sqrMagnitude <= 1f)
            {
                projected = location.position;
                node = location.node;
                return true;
            }

            node = default;
            NavMeshHit hit;
            bool found = filter.HasValue
                ? NavMesh.SamplePosition(point, out hit, float.MaxValue, filter.Value)
                : NavMesh.SamplePosition(point, out hit, float.MaxValue, mask);
            projected = hit.position;
            return found;
        }

        /// <summary>
        /// What size to initially allocate for getting paths.
        /// </summary>
        public const int InitialCacheSize = 100;
        
        /// <summary>
        /// The path object.
        /// </summary>
        private static readonly NavMeshPath Path = new();
        
        /// <summary>
        /// The cached points array for getting paths.
        /// </summary>
        private static Vector3[] _points = new Vector3[InitialCacheSize];
        
        /// <summary>
        /// Resize the points cache.
        /// </summary>
        /// <param name="size">The size to set.</param>
        public static void ResizeCache(int size = InitialCacheSize)
        {
            _points = new Vector3[Mathf.Max(size, 0)];
        }
        
        /// <summary>
        /// Find a path from the starting to the end position.
        /// </summary>
        /// <param name="start">The starting position.</param>
        /// <param name="goal">The goal position.</param>
        /// <param name="path">The path to update.</param>
        /// <param name="mask">The area mask to consider for pathfinding.</param>
        /// <param name="radius">The radius for path string-pulling checks. Setting to NULL means no string pulling.</param>
        /// <param name="sightMask">The optional layer mask for path string-pulling checks.</param>
        /// <param name="triggers">How the path string-pulling checks should handle hitting triggers.</param>
        /// <returns>The number of points along the found path.</returns>
        public static int FindPath(this Vector2 start, Vector2 goal, ref Vector2[] path, int mask = NavMesh.AllAreas, float? radius = null, int sightMask = KaijuMovementConfiguration.DefaultMask, QueryTriggerInteraction triggers = QueryTriggerInteraction.UseGlobal) => start.Expand().FindPath(goal.Expand(), ref path, mask, radius, sightMask, triggers);
        
        /// <summary>
        /// Find a path from the starting to the end position.
        /// </summary>
        /// <param name="start">The starting position.</param>
        /// <param name="goal">The goal position.</param>
        /// <param name="path">The path to update.</param>
        /// <param name="filter">The area filter to consider for pathfinding.</param>
        /// <param name="radius">The radius for path string-pulling checks. Setting to NULL means no string pulling.</param>
        /// <param name="sightMask">The optional layer mask for path string-pulling checks.</param>
        /// <param name="triggers">How the path string-pulling checks should handle hitting triggers.</param>
        /// <returns>The number of points along the found path.</returns>
        public static int FindPath(this Vector2 start, Vector2 goal, ref Vector2[] path, NavMeshQueryFilter filter, float? radius = null, int sightMask = KaijuMovementConfiguration.DefaultMask, QueryTriggerInteraction triggers = QueryTriggerInteraction.UseGlobal) => start.Expand().FindPath(goal.Expand(), ref path, filter, radius, sightMask, triggers);
        
        /// <summary>
        /// Find a path from the starting to the end position.
        /// </summary>
        /// <param name="start">The starting position.</param>
        /// <param name="goal">The goal position.</param>
        /// <param name="path">The path to update.</param>
        /// <param name="mask">The area mask to consider for pathfinding.</param>
        /// <param name="radius">The radius for path string-pulling checks. Setting to NULL means no string pulling.</param>
        /// <param name="sightMask">The optional layer mask for path string-pulling checks.</param>
        /// <param name="triggers">How the path string-pulling checks should handle hitting triggers.</param>
        /// <returns>The number of points along the found path.</returns>
        public static int FindPath(this Vector2 start, Vector2 goal, List<Vector2> path, int mask = NavMesh.AllAreas, float? radius = null, int sightMask = KaijuMovementConfiguration.DefaultMask, QueryTriggerInteraction triggers = QueryTriggerInteraction.UseGlobal) => start.Expand().FindPath(goal.Expand(), path, mask, radius, sightMask, triggers);
        
        /// <summary>
        /// Find a path from the starting to the end position.
        /// </summary>
        /// <param name="start">The starting position.</param>
        /// <param name="goal">The goal position.</param>
        /// <param name="path">The path to update.</param>
        /// <param name="filter">The area filter to consider for pathfinding.</param>
        /// <param name="radius">The radius for path string-pulling checks. Setting to NULL means no string pulling.</param>
        /// <param name="sightMask">The optional layer mask for path string-pulling checks.</param>
        /// <param name="triggers">How the path string-pulling checks should handle hitting triggers.</param>
        /// <returns>The number of points along the found path.</returns>
        public static int FindPath(this Vector2 start, Vector2 goal, List<Vector2> path, NavMeshQueryFilter filter, float? radius = null, int sightMask = KaijuMovementConfiguration.DefaultMask, QueryTriggerInteraction triggers = QueryTriggerInteraction.UseGlobal) => start.Expand().FindPath(goal.Expand(), path, filter, radius, sightMask, triggers);

        /// <summary>
        /// Find a path from the starting to the end position.
        /// </summary>
        /// <param name="start">The starting position.</param>
        /// <param name="goal">The goal position.</param>
        /// <param name="path">The path to update.</param>
        /// <param name="mask">The area mask to consider for pathfinding.</param>
        /// <param name="radius">The radius for path string-pulling checks. Setting to NULL means no string pulling.</param>
        /// <param name="sightMask">The optional layer mask for path string-pulling checks.</param>
        /// <param name="triggers">How the path string-pulling checks should handle hitting triggers.</param>
        /// <returns>The number of points along the found path.</returns>
        public static int FindPath(this Vector2 start, Vector2 goal, ref Vector3[] path, int mask = NavMesh.AllAreas, float? radius = null, int sightMask = KaijuMovementConfiguration.DefaultMask, QueryTriggerInteraction triggers = QueryTriggerInteraction.UseGlobal) => start.Expand().FindPath(goal.Expand(), ref path, mask, radius, sightMask, triggers);
        
        /// <summary>
        /// Find a path from the starting to the end position.
        /// </summary>
        /// <param name="start">The starting position.</param>
        /// <param name="goal">The goal position.</param>
        /// <param name="path">The path to update.</param>
        /// <param name="filter">The area filter to consider for pathfinding.</param>
        /// <param name="radius">The radius for path string-pulling checks. Setting to NULL means no string pulling.</param>
        /// <param name="sightMask">The optional layer mask for path string-pulling checks.</param>
        /// <param name="triggers">How the path string-pulling checks should handle hitting triggers.</param>
        /// <returns>The number of points along the found path.</returns>
        public static int FindPath(this Vector2 start, Vector2 goal, ref Vector3[] path, NavMeshQueryFilter filter, float? radius = null, int sightMask = KaijuMovementConfiguration.DefaultMask, QueryTriggerInteraction triggers = QueryTriggerInteraction.UseGlobal) => start.Expand().FindPath(goal.Expand(), ref path, filter, radius, sightMask, triggers);
        
        /// <summary>
        /// Find a path from the starting to the end position.
        /// </summary>
        /// <param name="start">The starting position.</param>
        /// <param name="goal">The goal position.</param>
        /// <param name="path">The path to update.</param>
        /// <param name="mask">The area mask to consider for pathfinding.</param>
        /// <param name="radius">The radius for path string-pulling checks. Setting to NULL means no string pulling.</param>
        /// <param name="sightMask">The optional layer mask for path string-pulling checks.</param>
        /// <param name="triggers">How the path string-pulling checks should handle hitting triggers.</param>
        /// <returns>The number of points along the found path.</returns>
        public static int FindPath(this Vector2 start, Vector2 goal, List<Vector3> path, int mask = NavMesh.AllAreas, float? radius = null, int sightMask = KaijuMovementConfiguration.DefaultMask, QueryTriggerInteraction triggers = QueryTriggerInteraction.UseGlobal) => start.Expand().FindPath(goal.Expand(), path, mask, radius, sightMask, triggers);
        
        /// <summary>
        /// Find a path from the starting to the end position.
        /// </summary>
        /// <param name="start">The starting position.</param>
        /// <param name="goal">The goal position.</param>
        /// <param name="path">The path to update.</param>
        /// <param name="filter">The area filter to consider for pathfinding.</param>
        /// <param name="radius">The radius for path string-pulling checks. Setting to NULL means no string pulling.</param>
        /// <param name="sightMask">The optional layer mask for path string-pulling checks.</param>
        /// <param name="triggers">How the path string-pulling checks should handle hitting triggers.</param>
        /// <returns>The number of points along the found path.</returns>
        public static int FindPath(this Vector2 start, Vector2 goal, List<Vector3> path, NavMeshQueryFilter filter, float? radius = null, int sightMask = KaijuMovementConfiguration.DefaultMask, QueryTriggerInteraction triggers = QueryTriggerInteraction.UseGlobal) => start.Expand().FindPath(goal.Expand(), path, filter, radius, sightMask, triggers);

        /// <summary>
        /// Find a path from the starting to the end position.
        /// </summary>
        /// <param name="start">The starting position.</param>
        /// <param name="goal">The goal position.</param>
        /// <param name="path">The path to update.</param>
        /// <param name="mask">The area mask to consider for pathfinding.</param>
        /// <param name="radius">The radius for path string-pulling checks. Setting to NULL means no string pulling.</param>
        /// <param name="sightMask">The optional layer mask for path string-pulling checks.</param>
        /// <param name="triggers">How the path string-pulling checks should handle hitting triggers.</param>
        /// <returns>The number of points along the found path.</returns>
        public static int FindPath(this Vector2 start, Vector3 goal, ref Vector2[] path, int mask = NavMesh.AllAreas, float? radius = null, int sightMask = KaijuMovementConfiguration.DefaultMask, QueryTriggerInteraction triggers = QueryTriggerInteraction.UseGlobal) => start.Expand().FindPath(goal, ref path, mask, radius, sightMask, triggers);
        
        /// <summary>
        /// Find a path from the starting to the end position.
        /// </summary>
        /// <param name="start">The starting position.</param>
        /// <param name="goal">The goal position.</param>
        /// <param name="path">The path to update.</param>
        /// <param name="filter">The area filter to consider for pathfinding.</param>
        /// <param name="radius">The radius for path string-pulling checks. Setting to NULL means no string pulling.</param>
        /// <param name="sightMask">The optional layer mask for path string-pulling checks.</param>
        /// <param name="triggers">How the path string-pulling checks should handle hitting triggers.</param>
        /// <returns>The number of points along the found path.</returns>
        public static int FindPath(this Vector2 start, Vector3 goal, ref Vector2[] path, NavMeshQueryFilter filter, float? radius = null, int sightMask = KaijuMovementConfiguration.DefaultMask, QueryTriggerInteraction triggers = QueryTriggerInteraction.UseGlobal) => start.Expand().FindPath(goal, ref path, filter, radius, sightMask, triggers);
        
        /// <summary>
        /// Find a path from the starting to the end position.
        /// </summary>
        /// <param name="start">The starting position.</param>
        /// <param name="goal">The goal position.</param>
        /// <param name="path">The path to update.</param>
        /// <param name="mask">The area mask to consider for pathfinding.</param>
        /// <param name="radius">The radius for path string-pulling checks. Setting to NULL means no string pulling.</param>
        /// <param name="sightMask">The optional layer mask for path string-pulling checks.</param>
        /// <param name="triggers">How the path string-pulling checks should handle hitting triggers.</param>
        /// <returns>The number of points along the found path.</returns>
        public static int FindPath(this Vector2 start, Vector3 goal, List<Vector2> path, int mask = NavMesh.AllAreas, float? radius = null, int sightMask = KaijuMovementConfiguration.DefaultMask, QueryTriggerInteraction triggers = QueryTriggerInteraction.UseGlobal) => start.Expand().FindPath(goal, path, mask, radius, sightMask, triggers);
        
        /// <summary>
        /// Find a path from the starting to the end position.
        /// </summary>
        /// <param name="start">The starting position.</param>
        /// <param name="goal">The goal position.</param>
        /// <param name="path">The path to update.</param>
        /// <param name="filter">The area filter to consider for pathfinding.</param>
        /// <param name="radius">The radius for path string-pulling checks. Setting to NULL means no string pulling.</param>
        /// <param name="sightMask">The optional layer mask for path string-pulling checks.</param>
        /// <param name="triggers">How the path string-pulling checks should handle hitting triggers.</param>
        /// <returns>The number of points along the found path.</returns>
        public static int FindPath(this Vector2 start, Vector3 goal, List<Vector2> path, NavMeshQueryFilter filter, float? radius = null, int sightMask = KaijuMovementConfiguration.DefaultMask, QueryTriggerInteraction triggers = QueryTriggerInteraction.UseGlobal) => start.Expand().FindPath(goal, path, filter, radius, sightMask, triggers);

        /// <summary>
        /// Find a path from the starting to the end position.
        /// </summary>
        /// <param name="start">The starting position.</param>
        /// <param name="goal">The goal position.</param>
        /// <param name="path">The path to update.</param>
        /// <param name="mask">The area mask to consider for pathfinding.</param>
        /// <param name="radius">The radius for path string-pulling checks. Setting to NULL means no string pulling.</param>
        /// <param name="sightMask">The optional layer mask for path string-pulling checks.</param>
        /// <param name="triggers">How the path string-pulling checks should handle hitting triggers.</param>
        /// <returns>The number of points along the found path.</returns>
        public static int FindPath(this Vector2 start, Vector3 goal, ref Vector3[] path, int mask = NavMesh.AllAreas, float? radius = null, int sightMask = KaijuMovementConfiguration.DefaultMask, QueryTriggerInteraction triggers = QueryTriggerInteraction.UseGlobal) => start.Expand().FindPath(goal, ref path, mask, radius, sightMask, triggers);
        
        /// <summary>
        /// Find a path from the starting to the end position.
        /// </summary>
        /// <param name="start">The starting position.</param>
        /// <param name="goal">The goal position.</param>
        /// <param name="path">The path to update.</param>
        /// <param name="filter">The area filter to consider for pathfinding.</param>
        /// <param name="radius">The radius for path string-pulling checks. Setting to NULL means no string pulling.</param>
        /// <param name="sightMask">The optional layer mask for path string-pulling checks.</param>
        /// <param name="triggers">How the path string-pulling checks should handle hitting triggers.</param>
        /// <returns>The number of points along the found path.</returns>
        public static int FindPath(this Vector2 start, Vector3 goal, ref Vector3[] path, NavMeshQueryFilter filter, float? radius = null, int sightMask = KaijuMovementConfiguration.DefaultMask, QueryTriggerInteraction triggers = QueryTriggerInteraction.UseGlobal) => start.Expand().FindPath(goal, ref path, filter, radius, sightMask, triggers);
        
        /// <summary>
        /// Find a path from the starting to the end position.
        /// </summary>
        /// <param name="start">The starting position.</param>
        /// <param name="goal">The goal position.</param>
        /// <param name="path">The path to update.</param>
        /// <param name="mask">The area mask to consider for pathfinding.</param>
        /// <param name="radius">The radius for path string-pulling checks. Setting to NULL means no string pulling.</param>
        /// <param name="sightMask">The optional layer mask for path string-pulling checks.</param>
        /// <param name="triggers">How the path string-pulling checks should handle hitting triggers.</param>
        /// <returns>The number of points along the found path.</returns>
        public static int FindPath(this Vector2 start, Vector3 goal, List<Vector3> path, int mask = NavMesh.AllAreas, float? radius = null, int sightMask = KaijuMovementConfiguration.DefaultMask, QueryTriggerInteraction triggers = QueryTriggerInteraction.UseGlobal) => start.Expand().FindPath(goal, path, mask, radius, sightMask, triggers);
        
        /// <summary>
        /// Find a path from the starting to the end position.
        /// </summary>
        /// <param name="start">The starting position.</param>
        /// <param name="goal">The goal position.</param>
        /// <param name="path">The path to update.</param>
        /// <param name="filter">The area filter to consider for pathfinding.</param>
        /// <param name="radius">The radius for path string-pulling checks. Setting to NULL means no string pulling.</param>
        /// <param name="sightMask">The optional layer mask for path string-pulling checks.</param>
        /// <param name="triggers">How the path string-pulling checks should handle hitting triggers.</param>
        /// <returns>The number of points along the found path.</returns>
        public static int FindPath(this Vector2 start, Vector3 goal, List<Vector3> path, NavMeshQueryFilter filter, float? radius = null, int sightMask = KaijuMovementConfiguration.DefaultMask, QueryTriggerInteraction triggers = QueryTriggerInteraction.UseGlobal) => start.Expand().FindPath(goal, path, filter, radius, sightMask, triggers);

        /// <summary>
        /// Find a path from the starting to the end position.
        /// </summary>
        /// <param name="start">The starting position.</param>
        /// <param name="goal">The goal position.</param>
        /// <param name="path">The path to update.</param>
        /// <param name="mask">The area mask to consider for pathfinding.</param>
        /// <param name="radius">The radius for path string-pulling checks. Setting to NULL means no string pulling.</param>
        /// <param name="sightMask">The optional layer mask for path string-pulling checks.</param>
        /// <param name="triggers">How the path string-pulling checks should handle hitting triggers.</param>
        /// <returns>The number of points along the found path.</returns>
        public static int FindPath(this Vector3 start, Vector2 goal, ref Vector2[] path, int mask = NavMesh.AllAreas, float? radius = null, int sightMask = KaijuMovementConfiguration.DefaultMask, QueryTriggerInteraction triggers = QueryTriggerInteraction.UseGlobal) => start.FindPath(goal.Expand(), ref path, mask, radius, sightMask, triggers);
        
        /// <summary>
        /// Find a path from the starting to the end position.
        /// </summary>
        /// <param name="start">The starting position.</param>
        /// <param name="goal">The goal position.</param>
        /// <param name="path">The path to update.</param>
        /// <param name="filter">The area filter to consider for pathfinding.</param>
        /// <param name="radius">The radius for path string-pulling checks. Setting to NULL means no string pulling.</param>
        /// <param name="sightMask">The optional layer mask for path string-pulling checks.</param>
        /// <param name="triggers">How the path string-pulling checks should handle hitting triggers.</param>
        /// <returns>The number of points along the found path.</returns>
        public static int FindPath(this Vector3 start, Vector2 goal, ref Vector2[] path, NavMeshQueryFilter filter, float? radius = null, int sightMask = KaijuMovementConfiguration.DefaultMask, QueryTriggerInteraction triggers = QueryTriggerInteraction.UseGlobal) => start.FindPath(goal.Expand(), ref path, filter, radius, sightMask, triggers);
        
        /// <summary>
        /// Find a path from the starting to the end position.
        /// </summary>
        /// <param name="start">The starting position.</param>
        /// <param name="goal">The goal position.</param>
        /// <param name="path">The path to update.</param>
        /// <param name="mask">The area mask to consider for pathfinding.</param>
        /// <param name="radius">The radius for path string-pulling checks. Setting to NULL means no string pulling.</param>
        /// <param name="sightMask">The optional layer mask for path string-pulling checks.</param>
        /// <param name="triggers">How the path string-pulling checks should handle hitting triggers.</param>
        /// <returns>The number of points along the found path.</returns>
        public static int FindPath(this Vector3 start, Vector2 goal, List<Vector2> path, int mask = NavMesh.AllAreas, float? radius = null, int sightMask = KaijuMovementConfiguration.DefaultMask, QueryTriggerInteraction triggers = QueryTriggerInteraction.UseGlobal) => start.FindPath(goal.Expand(), path, mask, radius, sightMask, triggers);
        
        /// <summary>
        /// Find a path from the starting to the end position.
        /// </summary>
        /// <param name="start">The starting position.</param>
        /// <param name="goal">The goal position.</param>
        /// <param name="path">The path to update.</param>
        /// <param name="filter">The area filter to consider for pathfinding.</param>
        /// <param name="radius">The radius for path string-pulling checks. Setting to NULL means no string pulling.</param>
        /// <param name="sightMask">The optional layer mask for path string-pulling checks.</param>
        /// <param name="triggers">How the path string-pulling checks should handle hitting triggers.</param>
        /// <returns>The number of points along the found path.</returns>
        public static int FindPath(this Vector3 start, Vector2 goal, List<Vector2> path, NavMeshQueryFilter filter, float? radius = null, int sightMask = KaijuMovementConfiguration.DefaultMask, QueryTriggerInteraction triggers = QueryTriggerInteraction.UseGlobal) => start.FindPath(goal.Expand(), path, filter, radius, sightMask, triggers);
        
        /// <summary>
        /// Find a path from the starting to the end position.
        /// </summary>
        /// <param name="start">The starting position.</param>
        /// <param name="goal">The goal position.</param>
        /// <param name="path">The path to update.</param>
        /// <param name="mask">The area mask to consider for pathfinding.</param>
        /// <param name="radius">The radius for path string-pulling checks. Setting to NULL means no string pulling.</param>
        /// <param name="sightMask">The optional layer mask for path string-pulling checks.</param>
        /// <param name="triggers">How the path string-pulling checks should handle hitting triggers.</param>
        /// <returns>The number of points along the found path.</returns>
        public static int FindPath(this Vector3 start, Vector3 goal, ref Vector2[] path, int mask = NavMesh.AllAreas, float? radius = null, int sightMask = KaijuMovementConfiguration.DefaultMask, QueryTriggerInteraction triggers = QueryTriggerInteraction.UseGlobal) => FindPath(start, goal, ref path, mask, null, radius, sightMask, triggers);

        private static int FindPath(Vector3 start, Vector3 goal, ref Vector2[] path, int mask, NavMeshQueryFilter? filter, float? radius, int sightMask, QueryTriggerInteraction triggers)
        {
            // Get the path in all dimensions.
            int count = FindPath(start, goal, ref _points, mask, filter, radius, sightMask, triggers);
            
            // Ensure we have the size.
            if (path.Length < count)
            {
                Array.Resize(ref path, count);
            }
            
            // Flatten the path.
            for (int i = 0; i < count; i++)
            {
                path[i] = _points[i].Flatten();
            }
            
            return count;
        }
        
        /// <summary>
        /// Find a path from the starting to the end position.
        /// </summary>
        /// <param name="start">The starting position.</param>
        /// <param name="goal">The goal position.</param>
        /// <param name="path">The path to update.</param>
        /// <param name="filter">The area filter to consider for pathfinding.</param>
        /// <param name="radius">The radius for path string-pulling checks. Setting to NULL means no string pulling.</param>
        /// <param name="sightMask">The optional layer mask for path string-pulling checks.</param>
        /// <param name="triggers">How the path string-pulling checks should handle hitting triggers.</param>
        /// <returns>The number of points along the found path.</returns>
        public static int FindPath(this Vector3 start, Vector3 goal, ref Vector2[] path, NavMeshQueryFilter filter, float? radius = null, int sightMask = KaijuMovementConfiguration.DefaultMask, QueryTriggerInteraction triggers = QueryTriggerInteraction.UseGlobal) => FindPath(start, goal, ref path, filter.areaMask, filter, radius, sightMask, triggers);
        
        /// <summary>
        /// Find a path from the starting to the end position.
        /// </summary>
        /// <param name="start">The starting position.</param>
        /// <param name="goal">The goal position.</param>
        /// <param name="path">The path to update.</param>
        /// <param name="mask">The area mask to consider for pathfinding.</param>
        /// <param name="radius">The radius for path string-pulling checks. Setting to NULL means no string pulling.</param>
        /// <param name="sightMask">The optional layer mask for path string-pulling checks.</param>
        /// <param name="triggers">How the path string-pulling checks should handle hitting triggers.</param>
        /// <returns>The number of points along the found path.</returns>
        public static int FindPath(this Vector3 start, Vector3 goal, List<Vector2> path, int mask = NavMesh.AllAreas, float? radius = null, int sightMask = KaijuMovementConfiguration.DefaultMask, QueryTriggerInteraction triggers = QueryTriggerInteraction.UseGlobal) => FindPath(start, goal, path, mask, null, radius, sightMask, triggers);

        private static int FindPath(Vector3 start, Vector3 goal, List<Vector2> path, int mask, NavMeshQueryFilter? filter, float? radius, int sightMask, QueryTriggerInteraction triggers)
        {
            // Use the cached array.
            path.Clear();
            int count = FindPath(start, goal, ref _points, mask, filter, radius, sightMask, triggers);
            
            // To reduce allocations as much as possible due to resizing, resize only once here if needed.
            if (path.Capacity < count)
            {
                path.Capacity = count;
            }
            
            for (int i = 0; i < count; i++)
            {
                path.Add(_points[i].Flatten());
            }
            
            return count;
        }
        
        /// <summary>
        /// Find a path from the starting to the end position.
        /// </summary>
        /// <param name="start">The starting position.</param>
        /// <param name="goal">The goal position.</param>
        /// <param name="path">The path to update.</param>
        /// <param name="filter">The area filter to consider for pathfinding.</param>
        /// <param name="radius">The radius for path string-pulling checks. Setting to NULL means no string pulling.</param>
        /// <param name="sightMask">The optional layer mask for path string-pulling checks.</param>
        /// <param name="triggers">How the path string-pulling checks should handle hitting triggers.</param>
        /// <returns>The number of points along the found path.</returns>
        public static int FindPath(this Vector3 start, Vector3 goal, List<Vector2> path, NavMeshQueryFilter filter, float? radius = null, int sightMask = KaijuMovementConfiguration.DefaultMask, QueryTriggerInteraction triggers = QueryTriggerInteraction.UseGlobal) => FindPath(start, goal, path, filter.areaMask, filter, radius, sightMask, triggers);
        
        /// <summary>
        /// Find a path from the starting to the end position.
        /// </summary>
        /// <param name="start">The starting position.</param>
        /// <param name="goal">The goal position.</param>
        /// <param name="path">The path to update.</param>
        /// <param name="mask">The area mask to consider for pathfinding.</param>
        /// <param name="radius">The radius for path string-pulling checks. Setting to NULL means no string pulling.</param>
        /// <param name="sightMask">The optional layer mask for path string-pulling checks.</param>
        /// <param name="triggers">How the path string-pulling checks should handle hitting triggers.</param>
        /// <returns>The number of points along the found path.</returns>
        public static int FindPath(this Vector3 start, Vector3 goal, ref Vector3[] path, int mask = NavMesh.AllAreas, float? radius = null, int sightMask = KaijuMovementConfiguration.DefaultMask, QueryTriggerInteraction triggers = QueryTriggerInteraction.UseGlobal) => FindPath(start, goal, ref path, mask, null, radius, sightMask, triggers);

        private static int FindPath(Vector3 start, Vector3 goal, ref Vector3[] path, int mask, NavMeshQueryFilter? filter, float? radius, int sightMask, QueryTriggerInteraction triggers)
        {
            // Nothing to do if these are the same points.
            if (start == goal)
            {
                if (path.Length < 1)
                {
                    Array.Resize(ref path, 1);
                }
                
                path[0] = start;
                return 1;
            }
            
            // All other methods below, require at least two points.
            if (path.Length < 2)
            {
                Array.Resize(ref path, 2);
            }
            
            // If we have a direction line of sight to the goal, just move there instead of finding a larger path.
            if (radius.HasValue)
            {
                Vector3 offset = new(0, radius.Value, 0);
                if ((start + offset).HasSight(goal + offset, out RaycastHit _, radius.Value, sightMask, triggers))
                {
                    path[0] = start;
                    path[1] = goal;
                    return 2;
                }
            }
            
            NavWorld world = GetWorld();
            if (!world.IsValid() || !Project(world, start, mask, filter, out Vector3 from, out NavNode startNode) ||
                !Project(world, goal, mask, filter, out Vector3 to, out NavNode goalNode))
            {
                path[0] = start;
                path[1] = goal;
                return 2;
            }

            int size;
            if (!startNode.IsNull() && startNode == goalNode)
            {
                // NavMesh polygons are convex. A route within one polygon requires no path search.
                path[0] = from;
                size = 1;
                if (from != to)
                    path[size++] = to;
            }
            else
            {
                bool found = filter.HasValue
                    ? NavMesh.CalculatePath(from, to, filter.Value, Path)
                    : NavMesh.CalculatePath(from, to, mask, Path);
                if (!found)
                {
                    path[0] = start;
                    path[1] = goal;
                    return 2;
                }

                while ((size = Path.GetCornersNonAlloc(path)) >= path.Length)
                    Array.Resize(ref path, path.Length * 2);
                Path.ClearCorners();
            }

            // If the start is different, insert it at the start.
            if (start != from)
            {
                // String pull first to remove any points we can skip.
                if (radius.HasValue)
                {
                    Vector3 offset = new(0, radius.Value, 0);
                    Vector3 startOffset = start + offset;
                    int skipped = 0;
                    for (int i = 1; i < size; i++)
                    {
                        if (!startOffset.HasSight(path[i] + offset, out RaycastHit _, radius.Value, sightMask, triggers))
                        {
                            break;
                        }
                        
                        skipped++;
                    }
                    
                    // If any were skipped, shuffle the path points down to skip them as such.
                    if (skipped > 0)
                    {
                        for (int i = skipped; i < size; i++)
                        {
                            path[i - skipped] = path[i];
                        }
                        
                        // Update the count.
                        size -= skipped;
                    }
                }
                
                if (path.Length < ++size)
                {
                    Array.Resize(ref path, size);
                }
                
                // Shuffle everything one to the right.
                for (int i = size - 1; i > 0; i--)
                {
                    path[i] = path[i - 1];
                }
                
                // Insert the starting point.
                path[0] = start;
            }
            
            // Do the same with the goal, inserting at the end.
            if (goal != to)
            {
                // Try to string pull again.
                if (radius.HasValue)
                {
                    Vector3 offset = new(0, radius.Value, 0);
                    Vector3 goalOffset = goal + offset;
                    for (int i = size - 2; i > 0; i--)
                    {
                        if (!goalOffset.HasSight(path[i] + offset, out RaycastHit _, radius.Value, sightMask, triggers))
                        {
                            break;
                        }
                        
                        // Unlike the forward pulling where we need to shuffle, here we can just remove points by the size.
                        size--;
                    }
                }
                
                if (path.Length < ++size)
                {
                    Array.Resize(ref path, size);
                }
                
                path[size - 1] = goal;
            }
            
            return size;
        }
        
        /// <summary>
        /// Find a path from the starting to the end position.
        /// </summary>
        /// <param name="start">The starting position.</param>
        /// <param name="goal">The goal position.</param>
        /// <param name="path">The path to update.</param>
        /// <param name="filter">The area filter to consider for pathfinding.</param>
        /// <param name="radius">The radius for path string-pulling checks. Setting to NULL means no string pulling.</param>
        /// <param name="sightMask">The optional layer mask for path string-pulling checks.</param>
        /// <param name="triggers">How the path string-pulling checks should handle hitting triggers.</param>
        /// <returns>The number of points along the found path.</returns>
        public static int FindPath(this Vector3 start, Vector3 goal, ref Vector3[] path, NavMeshQueryFilter filter, float? radius = null, int sightMask = KaijuMovementConfiguration.DefaultMask, QueryTriggerInteraction triggers = QueryTriggerInteraction.UseGlobal) => FindPath(start, goal, ref path, filter.areaMask, filter, radius, sightMask, triggers);
        
        /// <summary>
        /// Find a path from the starting to the end position.
        /// </summary>
        /// <param name="start">The starting position.</param>
        /// <param name="goal">The goal position.</param>
        /// <param name="path">The path to update.</param>
        /// <param name="mask">The area mask to consider for pathfinding.</param>
        /// <param name="radius">The radius for path string-pulling checks. Setting to NULL means no string pulling.</param>
        /// <param name="sightMask">The optional layer mask for path string-pulling checks.</param>
        /// <param name="triggers">How the path string-pulling checks should handle hitting triggers.</param>
        /// <returns>The number of points along the found path.</returns>
        public static int FindPath(this Vector3 start, Vector3 goal, List<Vector3> path, int mask = NavMesh.AllAreas, float? radius = null, int sightMask = KaijuMovementConfiguration.DefaultMask, QueryTriggerInteraction triggers = QueryTriggerInteraction.UseGlobal) => FindPath(start, goal, path, mask, null, radius, sightMask, triggers);

        private static int FindPath(Vector3 start, Vector3 goal, List<Vector3> path, int mask, NavMeshQueryFilter? filter, float? radius, int sightMask, QueryTriggerInteraction triggers)
        {
            // Use the cached array.
            path.Clear();
            int count = FindPath(start, goal, ref _points, mask, filter, radius, sightMask, triggers);
            
            // To reduce allocations as much as possible due to resizing, resize only once here if needed.
            if (path.Capacity < count)
            {
                path.Capacity = count;
            }
            
            for (int i = 0; i < count; i++)
            {
                path.Add(_points[i]);
            }
            
            return count;
        }
        
        /// <summary>
        /// Find a path from the starting to the end position.
        /// </summary>
        /// <param name="start">The starting position.</param>
        /// <param name="goal">The goal position.</param>
        /// <param name="path">The path to update.</param>
        /// <param name="filter">The area filter to consider for pathfinding.</param>
        /// <param name="radius">The radius for path string-pulling checks. Setting to NULL means no string pulling.</param>
        /// <param name="sightMask">The optional layer mask for path string-pulling checks.</param>
        /// <param name="triggers">How the path string-pulling checks should handle hitting triggers.</param>
        /// <returns>The number of points along the found path.</returns>
        public static int FindPath(this Vector3 start, Vector3 goal, List<Vector3> path, NavMeshQueryFilter filter, float? radius = null, int sightMask = KaijuMovementConfiguration.DefaultMask, QueryTriggerInteraction triggers = QueryTriggerInteraction.UseGlobal) => FindPath(start, goal, path, filter.areaMask, filter, radius, sightMask, triggers);
    }
}