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
        }
#endif
        /// <summary>
        /// The path object.
        /// </summary>
        private static readonly NavMeshPath Path = new();
        
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
            
            // Get the closest point on the navigable areas.
            if (NavMesh.SamplePosition(goal, out NavMeshHit hit, float.MaxValue, mask) && NavMesh.CalculatePath(start, hit.position, mask, Path))
            {
                // If no possible path, just have a direction connection.
                Array.Resize(ref path, 20);
                path = Path.corners;
                Path.ClearCorners();
                return path.Length;
            }
            
            // If no possible path, just have a direction connection.
            if (path.Length < 2)
            {
                Array.Resize(ref path, 2);
            }
            
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
        public static int FindPath(this Vector3 start, Vector3 goal, IList<Vector3> path, int mask = NavMesh.AllAreas)
        {
            path.Clear();
            Vector3[] points = new Vector3[1];
            int count = start.FindPath(goal, ref points, mask);
            for (int i = 0; i < count; i++)
            {
                path.Add(points[i]);
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
        public static int FindPath(this Vector3 start, Vector3 goal, IList<Vector3> path, NavMeshQueryFilter filter) => start.FindPath(goal, path, filter.areaMask);
    }
}