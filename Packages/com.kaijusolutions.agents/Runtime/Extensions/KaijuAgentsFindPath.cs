using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace KaijuSolutions.Agents.Extensions
{
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
            Path.ClearCorners();
            ResizeCache();
        }
#endif
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
        public static int FindPath(this Vector2 start, Vector2 goal, ref Vector2[] path, int mask = NavMesh.AllAreas, float? radius = null, int sightMask = -5, QueryTriggerInteraction triggers = QueryTriggerInteraction.UseGlobal) => start.Expand().FindPath(goal.Expand(), ref path, mask, radius, sightMask, triggers);
        
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
        public static int FindPath(this Vector2 start, Vector2 goal, ref Vector2[] path, NavMeshQueryFilter filter, float? radius = null, int sightMask = -5, QueryTriggerInteraction triggers = QueryTriggerInteraction.UseGlobal) => start.Expand().FindPath(goal.Expand(), ref path, filter.areaMask, radius, sightMask, triggers);
        
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
        public static int FindPath(this Vector2 start, Vector2 goal, List<Vector2> path, int mask = NavMesh.AllAreas, float? radius = null, int sightMask = -5, QueryTriggerInteraction triggers = QueryTriggerInteraction.UseGlobal) => start.Expand().FindPath(goal.Expand(), path, mask, radius, sightMask, triggers);
        
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
        public static int FindPath(this Vector2 start, Vector2 goal, List<Vector2> path, NavMeshQueryFilter filter, float? radius = null, int sightMask = -5, QueryTriggerInteraction triggers = QueryTriggerInteraction.UseGlobal) => start.Expand().FindPath(goal.Expand(), path, filter.areaMask, radius, sightMask, triggers);

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
        public static int FindPath(this Vector2 start, Vector2 goal, ref Vector3[] path, int mask = NavMesh.AllAreas, float? radius = null, int sightMask = -5, QueryTriggerInteraction triggers = QueryTriggerInteraction.UseGlobal) => start.Expand().FindPath(goal.Expand(), ref path, mask, radius, sightMask, triggers);
        
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
        public static int FindPath(this Vector2 start, Vector2 goal, ref Vector3[] path, NavMeshQueryFilter filter, float? radius = null, int sightMask = -5, QueryTriggerInteraction triggers = QueryTriggerInteraction.UseGlobal) => start.Expand().FindPath(goal.Expand(), ref path, filter.areaMask, radius, sightMask, triggers);
        
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
        public static int FindPath(this Vector2 start, Vector2 goal, List<Vector3> path, int mask = NavMesh.AllAreas, float? radius = null, int sightMask = -5, QueryTriggerInteraction triggers = QueryTriggerInteraction.UseGlobal) => start.Expand().FindPath(goal.Expand(), path, mask, radius, sightMask, triggers);
        
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
        public static int FindPath(this Vector2 start, Vector2 goal, List<Vector3> path, NavMeshQueryFilter filter, float? radius = null, int sightMask = -5, QueryTriggerInteraction triggers = QueryTriggerInteraction.UseGlobal) => start.Expand().FindPath(goal.Expand(), path, filter.areaMask, radius, sightMask, triggers);

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
        public static int FindPath(this Vector2 start, Vector3 goal, ref Vector2[] path, int mask = NavMesh.AllAreas, float? radius = null, int sightMask = -5, QueryTriggerInteraction triggers = QueryTriggerInteraction.UseGlobal) => start.Expand().FindPath(goal, ref path, mask, radius, sightMask, triggers);
        
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
        public static int FindPath(this Vector2 start, Vector3 goal, ref Vector2[] path, NavMeshQueryFilter filter, float? radius = null, int sightMask = -5, QueryTriggerInteraction triggers = QueryTriggerInteraction.UseGlobal) => start.Expand().FindPath(goal, ref path, filter.areaMask, radius, sightMask, triggers);
        
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
        public static int FindPath(this Vector2 start, Vector3 goal, List<Vector2> path, int mask = NavMesh.AllAreas, float? radius = null, int sightMask = -5, QueryTriggerInteraction triggers = QueryTriggerInteraction.UseGlobal) => start.Expand().FindPath(goal, path, mask, radius, sightMask, triggers);
        
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
        public static int FindPath(this Vector2 start, Vector3 goal, List<Vector2> path, NavMeshQueryFilter filter, float? radius = null, int sightMask = -5, QueryTriggerInteraction triggers = QueryTriggerInteraction.UseGlobal) => start.Expand().FindPath(goal, path, filter.areaMask, radius, sightMask, triggers);

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
        public static int FindPath(this Vector2 start, Vector3 goal, ref Vector3[] path, int mask = NavMesh.AllAreas, float? radius = null, int sightMask = -5, QueryTriggerInteraction triggers = QueryTriggerInteraction.UseGlobal) => start.Expand().FindPath(goal, ref path, mask, radius, sightMask, triggers);
        
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
        public static int FindPath(this Vector2 start, Vector3 goal, ref Vector3[] path, NavMeshQueryFilter filter, float? radius = null, int sightMask = -5, QueryTriggerInteraction triggers = QueryTriggerInteraction.UseGlobal) => start.Expand().FindPath(goal, ref path, filter.areaMask, radius, sightMask, triggers);
        
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
        public static int FindPath(this Vector2 start, Vector3 goal, List<Vector3> path, int mask = NavMesh.AllAreas, float? radius = null, int sightMask = -5, QueryTriggerInteraction triggers = QueryTriggerInteraction.UseGlobal) => start.Expand().FindPath(goal, path, mask, radius, sightMask, triggers);
        
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
        public static int FindPath(this Vector2 start, Vector3 goal, List<Vector3> path, NavMeshQueryFilter filter, float? radius = null, int sightMask = -5, QueryTriggerInteraction triggers = QueryTriggerInteraction.UseGlobal) => start.Expand().FindPath(goal, path, filter.areaMask, radius, sightMask, triggers);

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
        public static int FindPath(this Vector3 start, Vector2 goal, ref Vector2[] path, int mask = NavMesh.AllAreas, float? radius = null, int sightMask = -5, QueryTriggerInteraction triggers = QueryTriggerInteraction.UseGlobal) => start.FindPath(goal.Expand(), ref path, mask, radius, sightMask, triggers);
        
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
        public static int FindPath(this Vector3 start, Vector2 goal, ref Vector2[] path, NavMeshQueryFilter filter, float? radius = null, int sightMask = -5, QueryTriggerInteraction triggers = QueryTriggerInteraction.UseGlobal) => start.FindPath(goal.Expand(), ref path, filter.areaMask, radius, sightMask, triggers);
        
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
        public static int FindPath(this Vector3 start, Vector2 goal, List<Vector2> path, int mask = NavMesh.AllAreas, float? radius = null, int sightMask = -5, QueryTriggerInteraction triggers = QueryTriggerInteraction.UseGlobal) => start.FindPath(goal.Expand(), path, mask, radius, sightMask, triggers);
        
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
        public static int FindPath(this Vector3 start, Vector2 goal, List<Vector2> path, NavMeshQueryFilter filter, float? radius = null, int sightMask = -5, QueryTriggerInteraction triggers = QueryTriggerInteraction.UseGlobal) => start.FindPath(goal.Expand(), path, filter.areaMask, radius, sightMask, triggers);
        
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
        public static int FindPath(this Vector3 start, Vector3 goal, ref Vector2[] path, int mask = NavMesh.AllAreas, float? radius = null, int sightMask = -5, QueryTriggerInteraction triggers = QueryTriggerInteraction.UseGlobal)
        {
            // Get the path in all dimensions.
            int count = start.FindPath(goal, ref _points, mask, radius, sightMask, triggers);
            
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
        public static int FindPath(this Vector3 start, Vector3 goal, ref Vector2[] path, NavMeshQueryFilter filter, float? radius = null, int sightMask = -5, QueryTriggerInteraction triggers = QueryTriggerInteraction.UseGlobal) => start.FindPath(goal, ref path, filter.areaMask, radius, sightMask, triggers);
        
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
        public static int FindPath(this Vector3 start, Vector3 goal, List<Vector2> path, int mask = NavMesh.AllAreas, float? radius = null, int sightMask = -5, QueryTriggerInteraction triggers = QueryTriggerInteraction.UseGlobal)
        {
            // Use the cached array.
            path.Clear();
            int count = start.FindPath(goal, ref _points, mask, radius, sightMask, triggers);
            
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
        public static int FindPath(this Vector3 start, Vector3 goal, List<Vector2> path, NavMeshQueryFilter filter, float? radius = null, int sightMask = -5, QueryTriggerInteraction triggers = QueryTriggerInteraction.UseGlobal) => start.FindPath(goal, path, filter.areaMask, radius, sightMask, triggers);
        
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
        public static int FindPath(this Vector3 start, Vector3 goal, ref Vector3[] path, int mask = NavMesh.AllAreas, float? radius = null, int sightMask = -5, QueryTriggerInteraction triggers = QueryTriggerInteraction.UseGlobal)
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
            
            // Both the method, and a direct path in the case of a failure, require at least two points.
            if (path.Length < 2)
            {
                Array.Resize(ref path, 2);
            }
            
            // Get the closest point on the navigable areas. If failed, likely for there being no navigation meshes, just get the start and goal points.
            if (!NavMesh.SamplePosition(start, out NavMeshHit startHit, float.MaxValue, mask) || !NavMesh.SamplePosition(goal, out NavMeshHit goalHit, float.MaxValue, mask) || !NavMesh.CalculatePath(startHit.position, goalHit.position, mask, Path))
            {
                path[0] = start;
                path[1] = goal;
                return 2;
            }
            
            // The non-alloc method is used, but there is no way of knowing what size we truly need. Hence, if the array is filled, we don't know if it just fit or ran out of size, so double and repeat.
            int size;
            while (true)
            {
                size = Path.GetCornersNonAlloc(path);
                if (size >= path.Length)
                {
                    Array.Resize(ref path, path.Length * 2);
                    continue;
                }
                
                Path.ClearCorners();
                break;
            }
            
            // If the start is different, insert it at the start.
            if (start != startHit.position)
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
            if (goal != goalHit.position)
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
        public static int FindPath(this Vector3 start, Vector3 goal, ref Vector3[] path, NavMeshQueryFilter filter, float? radius = null, int sightMask = -5, QueryTriggerInteraction triggers = QueryTriggerInteraction.UseGlobal) => start.FindPath(goal, ref path, filter.areaMask, radius, sightMask, triggers);
        
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
        public static int FindPath(this Vector3 start, Vector3 goal, List<Vector3> path, int mask = NavMesh.AllAreas, float? radius = null, int sightMask = -5, QueryTriggerInteraction triggers = QueryTriggerInteraction.UseGlobal)
        {
            // Use the cached array.
            path.Clear();
            int count = start.FindPath(goal, ref _points, mask, radius, sightMask, triggers);
            
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
        public static int FindPath(this Vector3 start, Vector3 goal, List<Vector3> path, NavMeshQueryFilter filter, float? radius = null, int sightMask = -5, QueryTriggerInteraction triggers = QueryTriggerInteraction.UseGlobal) => start.FindPath(goal, path, filter.areaMask, radius, sightMask, triggers);
    }
}