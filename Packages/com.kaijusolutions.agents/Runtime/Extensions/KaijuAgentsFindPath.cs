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
        /// <returns>The number of points along the found path.</returns>
        public static int FindPath(this Vector2 start, Vector2 goal, ref Vector2[] path, int mask = NavMesh.AllAreas) => start.Expand().FindPath(goal.Expand(), ref path, mask);
        
        /// <summary>
        /// Find a path from the starting to the end position.
        /// </summary>
        /// <param name="start">The starting position.</param>
        /// <param name="goal">The goal position.</param>
        /// <param name="path">The path to update.</param>
        /// <param name="filter">The area filter to consider for pathfinding.</param>
        /// <returns>The number of points along the found path.</returns>
        public static int FindPath(this Vector2 start, Vector2 goal, ref Vector2[] path, NavMeshQueryFilter filter) => start.Expand().FindPath(goal.Expand(), ref path, filter.areaMask);
        
        /// <summary>
        /// Find a path from the starting to the end position.
        /// </summary>
        /// <param name="start">The starting position.</param>
        /// <param name="goal">The goal position.</param>
        /// <param name="path">The path to update.</param>
        /// <param name="mask">The area mask to consider for pathfinding.</param>
        /// <returns>The number of points along the found path.</returns>
        public static int FindPath(this Vector2 start, Vector2 goal, List<Vector2> path, int mask = NavMesh.AllAreas) => start.Expand().FindPath(goal.Expand(), path, mask);
        
        /// <summary>
        /// Find a path from the starting to the end position.
        /// </summary>
        /// <param name="start">The starting position.</param>
        /// <param name="goal">The goal position.</param>
        /// <param name="path">The path to update.</param>
        /// <param name="filter">The area filter to consider for pathfinding.</param>
        /// <returns>The number of points along the found path.</returns>
        public static int FindPath(this Vector2 start, Vector2 goal, List<Vector2> path, NavMeshQueryFilter filter) => start.Expand().FindPath(goal.Expand(), path, filter.areaMask);

        /// <summary>
        /// Find a path from the starting to the end position.
        /// </summary>
        /// <param name="start">The starting position.</param>
        /// <param name="goal">The goal position.</param>
        /// <param name="path">The path to update.</param>
        /// <param name="mask">The area mask to consider for pathfinding.</param>
        /// <returns>The number of points along the found path.</returns>
        public static int FindPath(this Vector2 start, Vector2 goal, ref Vector3[] path, int mask = NavMesh.AllAreas) => start.Expand().FindPath(goal.Expand(), ref path, mask);
        
        /// <summary>
        /// Find a path from the starting to the end position.
        /// </summary>
        /// <param name="start">The starting position.</param>
        /// <param name="goal">The goal position.</param>
        /// <param name="path">The path to update.</param>
        /// <param name="filter">The area filter to consider for pathfinding.</param>
        /// <returns>The number of points along the found path.</returns>
        public static int FindPath(this Vector2 start, Vector2 goal, ref Vector3[] path, NavMeshQueryFilter filter) => start.Expand().FindPath(goal.Expand(), ref path, filter.areaMask);
        
        /// <summary>
        /// Find a path from the starting to the end position.
        /// </summary>
        /// <param name="start">The starting position.</param>
        /// <param name="goal">The goal position.</param>
        /// <param name="path">The path to update.</param>
        /// <param name="mask">The area mask to consider for pathfinding.</param>
        /// <returns>The number of points along the found path.</returns>
        public static int FindPath(this Vector2 start, Vector2 goal, List<Vector3> path, int mask = NavMesh.AllAreas) => start.Expand().FindPath(goal.Expand(), path, mask);
        
        /// <summary>
        /// Find a path from the starting to the end position.
        /// </summary>
        /// <param name="start">The starting position.</param>
        /// <param name="goal">The goal position.</param>
        /// <param name="path">The path to update.</param>
        /// <param name="filter">The area filter to consider for pathfinding.</param>
        /// <returns>The number of points along the found path.</returns>
        public static int FindPath(this Vector2 start, Vector2 goal, List<Vector3> path, NavMeshQueryFilter filter) => start.Expand().FindPath(goal.Expand(), path, filter.areaMask);

        /// <summary>
        /// Find a path from the starting to the end position.
        /// </summary>
        /// <param name="start">The starting position.</param>
        /// <param name="goal">The goal position.</param>
        /// <param name="path">The path to update.</param>
        /// <param name="mask">The area mask to consider for pathfinding.</param>
        /// <returns>The number of points along the found path.</returns>
        public static int FindPath(this Vector2 start, Vector3 goal, ref Vector2[] path, int mask = NavMesh.AllAreas) => start.Expand().FindPath(goal, ref path, mask);
        
        /// <summary>
        /// Find a path from the starting to the end position.
        /// </summary>
        /// <param name="start">The starting position.</param>
        /// <param name="goal">The goal position.</param>
        /// <param name="path">The path to update.</param>
        /// <param name="filter">The area filter to consider for pathfinding.</param>
        /// <returns>The number of points along the found path.</returns>
        public static int FindPath(this Vector2 start, Vector3 goal, ref Vector2[] path, NavMeshQueryFilter filter) => start.Expand().FindPath(goal, ref path, filter.areaMask);
        
        /// <summary>
        /// Find a path from the starting to the end position.
        /// </summary>
        /// <param name="start">The starting position.</param>
        /// <param name="goal">The goal position.</param>
        /// <param name="path">The path to update.</param>
        /// <param name="mask">The area mask to consider for pathfinding.</param>
        /// <returns>The number of points along the found path.</returns>
        public static int FindPath(this Vector2 start, Vector3 goal, List<Vector2> path, int mask = NavMesh.AllAreas) => start.Expand().FindPath(goal, path, mask);
        
        /// <summary>
        /// Find a path from the starting to the end position.
        /// </summary>
        /// <param name="start">The starting position.</param>
        /// <param name="goal">The goal position.</param>
        /// <param name="path">The path to update.</param>
        /// <param name="filter">The area filter to consider for pathfinding.</param>
        /// <returns>The number of points along the found path.</returns>
        public static int FindPath(this Vector2 start, Vector3 goal, List<Vector2> path, NavMeshQueryFilter filter) => start.Expand().FindPath(goal, path, filter.areaMask);

        /// <summary>
        /// Find a path from the starting to the end position.
        /// </summary>
        /// <param name="start">The starting position.</param>
        /// <param name="goal">The goal position.</param>
        /// <param name="path">The path to update.</param>
        /// <param name="mask">The area mask to consider for pathfinding.</param>
        /// <returns>The number of points along the found path.</returns>
        public static int FindPath(this Vector2 start, Vector3 goal, ref Vector3[] path, int mask = NavMesh.AllAreas) => start.Expand().FindPath(goal, ref path, mask);
        
        /// <summary>
        /// Find a path from the starting to the end position.
        /// </summary>
        /// <param name="start">The starting position.</param>
        /// <param name="goal">The goal position.</param>
        /// <param name="path">The path to update.</param>
        /// <param name="filter">The area filter to consider for pathfinding.</param>
        /// <returns>The number of points along the found path.</returns>
        public static int FindPath(this Vector2 start, Vector3 goal, ref Vector3[] path, NavMeshQueryFilter filter) => start.Expand().FindPath(goal, ref path, filter.areaMask);
        
        /// <summary>
        /// Find a path from the starting to the end position.
        /// </summary>
        /// <param name="start">The starting position.</param>
        /// <param name="goal">The goal position.</param>
        /// <param name="path">The path to update.</param>
        /// <param name="mask">The area mask to consider for pathfinding.</param>
        /// <returns>The number of points along the found path.</returns>
        public static int FindPath(this Vector2 start, Vector3 goal, List<Vector3> path, int mask = NavMesh.AllAreas) => start.Expand().FindPath(goal, path, mask);
        
        /// <summary>
        /// Find a path from the starting to the end position.
        /// </summary>
        /// <param name="start">The starting position.</param>
        /// <param name="goal">The goal position.</param>
        /// <param name="path">The path to update.</param>
        /// <param name="filter">The area filter to consider for pathfinding.</param>
        /// <returns>The number of points along the found path.</returns>
        public static int FindPath(this Vector2 start, Vector3 goal, List<Vector3> path, NavMeshQueryFilter filter) => start.Expand().FindPath(goal, path, filter.areaMask);

        /// <summary>
        /// Find a path from the starting to the end position.
        /// </summary>
        /// <param name="start">The starting position.</param>
        /// <param name="goal">The goal position.</param>
        /// <param name="path">The path to update.</param>
        /// <param name="mask">The area mask to consider for pathfinding.</param>
        /// <returns>The number of points along the found path.</returns>
        public static int FindPath(this Vector3 start, Vector2 goal, ref Vector2[] path, int mask = NavMesh.AllAreas) => start.FindPath(goal.Expand(), ref path, mask);
        
        /// <summary>
        /// Find a path from the starting to the end position.
        /// </summary>
        /// <param name="start">The starting position.</param>
        /// <param name="goal">The goal position.</param>
        /// <param name="path">The path to update.</param>
        /// <param name="filter">The area filter to consider for pathfinding.</param>
        /// <returns>The number of points along the found path.</returns>
        public static int FindPath(this Vector3 start, Vector2 goal, ref Vector2[] path, NavMeshQueryFilter filter) => start.FindPath(goal.Expand(), ref path, filter.areaMask);
        
        /// <summary>
        /// Find a path from the starting to the end position.
        /// </summary>
        /// <param name="start">The starting position.</param>
        /// <param name="goal">The goal position.</param>
        /// <param name="path">The path to update.</param>
        /// <param name="mask">The area mask to consider for pathfinding.</param>
        /// <returns>The number of points along the found path.</returns>
        public static int FindPath(this Vector3 start, Vector2 goal, List<Vector2> path, int mask = NavMesh.AllAreas) => start.FindPath(goal.Expand(), path, mask);
        
        /// <summary>
        /// Find a path from the starting to the end position.
        /// </summary>
        /// <param name="start">The starting position.</param>
        /// <param name="goal">The goal position.</param>
        /// <param name="path">The path to update.</param>
        /// <param name="filter">The area filter to consider for pathfinding.</param>
        /// <returns>The number of points along the found path.</returns>
        public static int FindPath(this Vector3 start, Vector2 goal, List<Vector2> path, NavMeshQueryFilter filter) => start.FindPath(goal.Expand(), path, filter.areaMask);
        
        /// <summary>
        /// Find a path from the starting to the end position.
        /// </summary>
        /// <param name="start">The starting position.</param>
        /// <param name="goal">The goal position.</param>
        /// <param name="path">The path to update.</param>
        /// <param name="mask">The area mask to consider for pathfinding.</param>
        /// <returns>The number of points along the found path.</returns>
        public static int FindPath(this Vector3 start, Vector3 goal, ref Vector2[] path, int mask = NavMesh.AllAreas)
        {
            // Get the path in all dimensions.
            int count = start.FindPath(goal, ref _points, mask);
            
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
        /// <returns>The number of points along the found path.</returns>
        public static int FindPath(this Vector3 start, Vector3 goal, ref Vector2[] path, NavMeshQueryFilter filter) => start.FindPath(goal, ref path, filter.areaMask);
        
        /// <summary>
        /// Find a path from the starting to the end position.
        /// </summary>
        /// <param name="start">The starting position.</param>
        /// <param name="goal">The goal position.</param>
        /// <param name="path">The path to update.</param>
        /// <param name="mask">The area mask to consider for pathfinding.</param>
        /// <returns>The number of points along the found path.</returns>
        public static int FindPath(this Vector3 start, Vector3 goal, List<Vector2> path, int mask = NavMesh.AllAreas)
        {
            // Use the cached array.
            path.Clear();
            int count = start.FindPath(goal, ref _points, mask);
            
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
        /// <returns>The number of points along the found path.</returns>
        public static int FindPath(this Vector3 start, Vector3 goal, List<Vector2> path, NavMeshQueryFilter filter) => start.FindPath(goal, path, filter.areaMask);
        
        /// <summary>
        /// Find a path from the starting to the end position.
        /// </summary>
        /// <param name="start">The starting position.</param>
        /// <param name="goal">The goal position.</param>
        /// <param name="path">The path to update.</param>
        /// <param name="mask">The area mask to consider for pathfinding.</param>
        /// <returns>The number of points along the found path.</returns>
        public static int FindPath(this Vector3 start, Vector3 goal, ref Vector3[] path, int mask = NavMesh.AllAreas)
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
            
            // Both the method, and a direct path, require at least two points.
            if (path.Length < 2)
            {
                Array.Resize(ref path, 2);
            }
            
            // Get the closest point on the navigable areas.
            if (NavMesh.SamplePosition(start, out NavMeshHit startHit, float.MaxValue, mask) && NavMesh.SamplePosition(goal, out NavMeshHit goalHit, float.MaxValue, mask) && NavMesh.CalculatePath(startHit.position, goalHit.position, mask, Path))
            {
                // The non-alloc method is used, but there is no way of knowing what size we truly need. Hence, if the array is filled, we don't know if it just fit or ran out of size, so double and repeat.
                while (true)
                {
                    int size = Path.GetCornersNonAlloc(path);
                    if (size >= path.Length)
                    {
                        Array.Resize(ref path, path.Length * 2);
                        continue;
                    }
                    
                    Path.ClearCorners();
                    return size;
                }
            }
            
            // If failed, likely for there being no navigation meshes, just get the start and goal points.
            path[0] = start;
            path[1] = goal;
            return 2;
        }
        
        /// <summary>
        /// Find a path from the starting to the end position.
        /// </summary>
        /// <param name="start">The starting position.</param>
        /// <param name="goal">The goal position.</param>
        /// <param name="path">The path to update.</param>
        /// <param name="filter">The area filter to consider for pathfinding.</param>
        /// <returns>The number of points along the found path.</returns>
        public static int FindPath(this Vector3 start, Vector3 goal, ref Vector3[] path, NavMeshQueryFilter filter) => start.FindPath(goal, ref path, filter.areaMask);
        
        /// <summary>
        /// Find a path from the starting to the end position.
        /// </summary>
        /// <param name="start">The starting position.</param>
        /// <param name="goal">The goal position.</param>
        /// <param name="path">The path to update.</param>
        /// <param name="mask">The area mask to consider for pathfinding.</param>
        /// <returns>The number of points along the found path.</returns>
        public static int FindPath(this Vector3 start, Vector3 goal, List<Vector3> path, int mask = NavMesh.AllAreas)
        {
            // Use the cached array.
            path.Clear();
            int count = start.FindPath(goal, ref _points, mask);
            
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
        /// <returns>The number of points along the found path.</returns>
        public static int FindPath(this Vector3 start, Vector3 goal, List<Vector3> path, NavMeshQueryFilter filter) => start.FindPath(goal, path, filter.areaMask);
    }
}