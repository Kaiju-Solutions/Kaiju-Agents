using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using UnityEngine;

namespace KaijuSolutions.Agents.Extension
{
    /// <summary>
    /// Extension methods for sorting objects by their distance to a given position along the X and Z axes. All three-dimensional vectors will be flattened via methods in <see cref="KaijuAgentsFlatten"/>.
    /// </summary>
    public static class KaijuAgentsSortDistance
    {
        /// <summary>
        /// The sorter for distance.
        /// </summary>
        private static readonly KaijuAgentsDistanceSorter Sorter = new(Vector2.zero);
        
        /// <summary>
        /// Sort targets from a position.
        /// </summary>
        /// <param name="position">The position to sort in relation to.</param>
        /// <param name="targets">The targets to sort.</param>
        /// <param name="farthest">If this should sort by farthest items first.</param>
        public static void SortDistance(this Vector2 position, [NotNull] Vector2[] targets, bool farthest = false)
        {
            Sorter.Set(position, farthest);
            Array.Sort(targets, Sorter);
        }
        
        /// <summary>
        /// Sort targets from a position.
        /// </summary>
        /// <param name="position">The position to sort in relation to.</param>
        /// <param name="targets">The targets to sort.</param>
        /// <param name="farthest">If this should sort by farthest items first.</param>
        public static void SortDistance(this Vector2 position, [NotNull] List<Vector2> targets, bool farthest = false)
        {
            Sorter.Set(position, farthest);
            targets.Sort(Sorter);
        }
        
        /// <summary>
        /// Sort targets from a position. This version will produce garbage, and it is recommended to use an inplace method instead.
        /// </summary>
        /// <param name="position">The position to sort in relation to.</param>
        /// <param name="targets">The targets to sort.</param>
        /// <param name="farthest">If this should sort by farthest items first.</param>
        public static Vector2[] SortDistance(this Vector2 position, [NotNull] IEnumerable<Vector2> targets, bool farthest = false)
        {
            Sorter.Set(position, farthest);
            return targets.OrderBy(x => x, Sorter).ToArray();
        }
        
        /// <summary>
        /// Sort targets from a position.
        /// </summary>
        /// <param name="position">The position to sort in relation to.</param>
        /// <param name="targets">The targets to sort.</param>
        /// <param name="farthest">If this should sort by farthest items first.</param>
        public static void SortDistance(this Vector2 position, [NotNull] Vector3[] targets, bool farthest = false)
        {
            Sorter.Set(position, farthest);
            Array.Sort(targets, Sorter);
        }
        
        /// <summary>
        /// Sort targets from a position.
        /// </summary>
        /// <param name="position">The position to sort in relation to.</param>
        /// <param name="targets">The targets to sort.</param>
        /// <param name="farthest">If this should sort by farthest items first.</param>
        public static void SortDistance(this Vector2 position, [NotNull] List<Vector3> targets, bool farthest = false)
        {
            Sorter.Set(position, farthest);
            targets.Sort(Sorter);
        }
        
        /// <summary>
        /// Sort targets from a position. This version will produce garbage, and it is recommended to use an inplace method instead.
        /// </summary>
        /// <param name="position">The position to sort in relation to.</param>
        /// <param name="targets">The targets to sort.</param>
        /// <param name="farthest">If this should sort by farthest items first.</param>
        public static Vector3[] SortDistance(this Vector2 position, [NotNull] IEnumerable<Vector3> targets, bool farthest = false)
        {
            Sorter.Set(position, farthest);
            return targets.OrderBy(x => x, Sorter).ToArray();
        }
        
        /// <summary>
        /// Sort targets from a position.
        /// </summary>
        /// <param name="position">The position to sort in relation to.</param>
        /// <param name="targets">The targets to sort.</param>
        /// <param name="farthest">If this should sort by farthest items first.</param>
        public static void SortDistance(this Vector2 position, [NotNull] Transform[] targets, bool farthest = false)
        {
            Sorter.Set(position, farthest);
            Array.Sort(targets, Sorter);
        }
        
        /// <summary>
        /// Sort targets from a position.
        /// </summary>
        /// <param name="position">The position to sort in relation to.</param>
        /// <param name="targets">The targets to sort.</param>
        /// <param name="farthest">If this should sort by farthest items first.</param>
        public static void SortDistance(this Vector2 position, [NotNull] List<Transform> targets, bool farthest = false)
        {
            Sorter.Set(position, farthest);
            targets.Sort(Sorter);
        }
        
        /// <summary>
        /// Sort targets from a position. This version will produce garbage, and it is recommended to use an inplace method instead.
        /// </summary>
        /// <param name="position">The position to sort in relation to.</param>
        /// <param name="targets">The targets to sort.</param>
        /// <param name="farthest">If this should sort by farthest items first.</param>
        public static Transform[] SortDistance(this Vector2 position, [NotNull] IEnumerable<Transform> targets, bool farthest = false)
        {
            Sorter.Set(position, farthest);
            return targets.OrderBy(x => x, Sorter).ToArray();
        }
        
        /// <summary>
        /// Sort targets from a position.
        /// </summary>
        /// <param name="position">The position to sort in relation to.</param>
        /// <param name="targets">The targets to sort.</param>
        /// <param name="farthest">If this should sort by farthest items first.</param>
        public static void SortDistance<T>(this Vector2 position, [NotNull] T[] targets, bool farthest = false) where T : Component
        {
            Sorter.Set(position, farthest);
            Array.Sort(targets, Sorter);
        }
        
        /// <summary>
        /// Sort targets from a position.
        /// </summary>
        /// <param name="position">The position to sort in relation to.</param>
        /// <param name="targets">The targets to sort.</param>
        /// <param name="farthest">If this should sort by farthest items first.</param>
        public static void SortDistance<T>(this Vector2 position, [NotNull] List<T> targets, bool farthest = false) where T : Component
        {
            Sorter.Set(position, farthest);
            targets.Sort(Sorter);
        }
        
        /// <summary>
        /// Sort targets from a position. This version will produce garbage, and it is recommended to use an inplace method instead.
        /// </summary>
        /// <param name="position">The position to sort in relation to.</param>
        /// <param name="targets">The targets to sort.</param>
        /// <param name="farthest">If this should sort by farthest items first.</param>
        public static T[] SortDistance<T>(this Vector2 position, [NotNull] IEnumerable<T> targets, bool farthest = false) where T : Component
        {
            Sorter.Set(position, farthest);
            return targets.OrderBy(x => x, Sorter).ToArray();
        }
        
        /// <summary>
        /// Sort targets from a position.
        /// </summary>
        /// <param name="position">The position to sort in relation to.</param>
        /// <param name="targets">The targets to sort.</param>
        /// <param name="farthest">If this should sort by farthest items first.</param>
        public static void SortDistance(this Vector2 position, [NotNull] GameObject[] targets, bool farthest = false)
        {
            Sorter.Set(position, farthest);
            Array.Sort(targets, Sorter);
        }
        
        /// <summary>
        /// Sort targets from a position.
        /// </summary>
        /// <param name="position">The position to sort in relation to.</param>
        /// <param name="targets">The targets to sort.</param>
        /// <param name="farthest">If this should sort by farthest items first.</param>
        public static void SortDistance(this Vector2 position, [NotNull] List<GameObject> targets, bool farthest = false)
        {
            Sorter.Set(position, farthest);
            targets.Sort(Sorter);
        }
        
        /// <summary>
        /// Sort targets from a position. This version will produce garbage, and it is recommended to use an inplace method instead.
        /// </summary>
        /// <param name="position">The position to sort in relation to.</param>
        /// <param name="targets">The targets to sort.</param>
        /// <param name="farthest">If this should sort by farthest items first.</param>
        public static GameObject[] SortDistance(this Vector2 position, [NotNull] IEnumerable<GameObject> targets, bool farthest = false)
        {
            Sorter.Set(position, farthest);
            return targets.OrderBy(x => x, Sorter).ToArray();
        }
        
        /// <summary>
        /// Sort targets from a position.
        /// </summary>
        /// <param name="position">The position to sort in relation to.</param>
        /// <param name="targets">The targets to sort.</param>
        /// <param name="farthest">If this should sort by farthest items first.</param>
        public static void SortDistance(this Vector3 position, [NotNull] Vector2[] targets, bool farthest = false)
        {
            Sorter.Set(position, farthest);
            Array.Sort(targets, Sorter);
        }
        
        /// <summary>
        /// Sort targets from a position.
        /// </summary>
        /// <param name="position">The position to sort in relation to.</param>
        /// <param name="targets">The targets to sort.</param>
        /// <param name="farthest">If this should sort by farthest items first.</param>
        public static void SortDistance(this Vector3 position, [NotNull] List<Vector2> targets, bool farthest = false)
        {
            Sorter.Set(position, farthest);
            targets.Sort(Sorter);
        }
        
        /// <summary>
        /// Sort targets from a position. This version will produce garbage, and it is recommended to use an inplace method instead.
        /// </summary>
        /// <param name="position">The position to sort in relation to.</param>
        /// <param name="targets">The targets to sort.</param>
        /// <param name="farthest">If this should sort by farthest items first.</param>
        public static Vector2[] SortDistance(this Vector3 position, [NotNull] IEnumerable<Vector2> targets, bool farthest = false)
        {
            Sorter.Set(position, farthest);
            return targets.OrderBy(x => x, Sorter).ToArray();
        }
        
        /// <summary>
        /// Sort targets from a position.
        /// </summary>
        /// <param name="position">The position to sort in relation to.</param>
        /// <param name="targets">The targets to sort.</param>
        /// <param name="farthest">If this should sort by farthest items first.</param>
        public static void SortDistance(this Vector3 position, [NotNull] Vector3[] targets, bool farthest = false)
        {
            Sorter.Set(position, farthest);
            Array.Sort(targets, Sorter);
        }
        
        /// <summary>
        /// Sort targets from a position.
        /// </summary>
        /// <param name="position">The position to sort in relation to.</param>
        /// <param name="targets">The targets to sort.</param>
        /// <param name="farthest">If this should sort by farthest items first.</param>
        public static void SortDistance(this Vector3 position, [NotNull] List<Vector3> targets, bool farthest = false)
        {
            Sorter.Set(position, farthest);
            targets.Sort(Sorter);
        }
        
        /// <summary>
        /// Sort targets from a position. This version will produce garbage, and it is recommended to use an inplace method instead.
        /// </summary>
        /// <param name="position">The position to sort in relation to.</param>
        /// <param name="targets">The targets to sort.</param>
        /// <param name="farthest">If this should sort by farthest items first.</param>
        public static Vector3[] SortDistance(this Vector3 position, [NotNull] IEnumerable<Vector3> targets, bool farthest = false)
        {
            Sorter.Set(position, farthest);
            return targets.OrderBy(x => x, Sorter).ToArray();
        }
        
        /// <summary>
        /// Sort targets from a position.
        /// </summary>
        /// <param name="position">The position to sort in relation to.</param>
        /// <param name="targets">The targets to sort.</param>
        /// <param name="farthest">If this should sort by farthest items first.</param>
        public static void SortDistance(this Vector3 position, [NotNull] Transform[] targets, bool farthest = false)
        {
            Sorter.Set(position, farthest);
            Array.Sort(targets, Sorter);
        }
        
        /// <summary>
        /// Sort targets from a position.
        /// </summary>
        /// <param name="position">The position to sort in relation to.</param>
        /// <param name="targets">The targets to sort.</param>
        /// <param name="farthest">If this should sort by farthest items first.</param>
        public static void SortDistance(this Vector3 position, [NotNull] List<Transform> targets, bool farthest = false)
        {
            Sorter.Set(position, farthest);
            targets.Sort(Sorter);
        }
        
        /// <summary>
        /// Sort targets from a position. This version will produce garbage, and it is recommended to use an inplace method instead.
        /// </summary>
        /// <param name="position">The position to sort in relation to.</param>
        /// <param name="targets">The targets to sort.</param>
        /// <param name="farthest">If this should sort by farthest items first.</param>
        public static Transform[] SortDistance(this Vector3 position, [NotNull] IEnumerable<Transform> targets, bool farthest = false)
        {
            Sorter.Set(position, farthest);
            return targets.OrderBy(x => x, Sorter).ToArray();
        }
        
        /// <summary>
        /// Sort targets from a position.
        /// </summary>
        /// <param name="position">The position to sort in relation to.</param>
        /// <param name="targets">The targets to sort.</param>
        /// <param name="farthest">If this should sort by farthest items first.</param>
        public static void SortDistance<T>(this Vector3 position, [NotNull] T[] targets, bool farthest = false) where T : Component
        {
            Sorter.Set(position, farthest);
            Array.Sort(targets, Sorter);
        }
        
        /// <summary>
        /// Sort targets from a position.
        /// </summary>
        /// <param name="position">The position to sort in relation to.</param>
        /// <param name="targets">The targets to sort.</param>
        /// <param name="farthest">If this should sort by farthest items first.</param>
        public static void SortDistance<T>(this Vector3 position, [NotNull] List<T> targets, bool farthest = false) where T : Component
        {
            Sorter.Set(position, farthest);
            targets.Sort(Sorter);
        }
        
        /// <summary>
        /// Sort targets from a position. This version will produce garbage, and it is recommended to use an inplace method instead.
        /// </summary>
        /// <param name="position">The position to sort in relation to.</param>
        /// <param name="targets">The targets to sort.</param>
        /// <param name="farthest">If this should sort by farthest items first.</param>
        public static T[] SortDistance<T>(this Vector3 position, [NotNull] IEnumerable<T> targets, bool farthest = false) where T : Component
        {
            Sorter.Set(position, farthest);
            return targets.OrderBy(x => x, Sorter).ToArray();
        }
        
        /// <summary>
        /// Sort targets from a position.
        /// </summary>
        /// <param name="position">The position to sort in relation to.</param>
        /// <param name="targets">The targets to sort.</param>
        /// <param name="farthest">If this should sort by farthest items first.</param>
        public static void SortDistance(this Vector3 position, [NotNull] GameObject[] targets, bool farthest = false)
        {
            Sorter.Set(position, farthest);
            Array.Sort(targets, Sorter);
        }
        
        /// <summary>
        /// Sort targets from a position.
        /// </summary>
        /// <param name="position">The position to sort in relation to.</param>
        /// <param name="targets">The targets to sort.</param>
        /// <param name="farthest">If this should sort by farthest items first.</param>
        public static void SortDistance(this Vector3 position, [NotNull] List<GameObject> targets, bool farthest = false)
        {
            Sorter.Set(position, farthest);
            targets.Sort(Sorter);
        }
        
        /// <summary>
        /// Sort targets from a position. This version will produce garbage, and it is recommended to use an inplace method instead.
        /// </summary>
        /// <param name="position">The position to sort in relation to.</param>
        /// <param name="targets">The targets to sort.</param>
        /// <param name="farthest">If this should sort by farthest items first.</param>
        public static GameObject[] SortDistance(this Vector3 position, [NotNull] IEnumerable<GameObject> targets, bool farthest = false)
        {
            Sorter.Set(position, farthest);
            return targets.OrderBy(x => x, Sorter).ToArray();
        }
        
        /// <summary>
        /// Sort targets from a position.
        /// </summary>
        /// <param name="position">The position to sort in relation to.</param>
        /// <param name="targets">The targets to sort.</param>
        /// <param name="farthest">If this should sort by farthest items first.</param>
        public static void SortDistance([NotNull] this Transform position, [NotNull] Vector2[] targets, bool farthest = false)
        {
            Sorter.Set(position, farthest);
            Array.Sort(targets, Sorter);
        }
        
        /// <summary>
        /// Sort targets from a position.
        /// </summary>
        /// <param name="position">The position to sort in relation to.</param>
        /// <param name="targets">The targets to sort.</param>
        /// <param name="farthest">If this should sort by farthest items first.</param>
        public static void SortDistance([NotNull] this Transform position, [NotNull] List<Vector2> targets, bool farthest = false)
        {
            Sorter.Set(position, farthest);
            targets.Sort(Sorter);
        }
        
        /// <summary>
        /// Sort targets from a position. This version will produce garbage, and it is recommended to use an inplace method instead.
        /// </summary>
        /// <param name="position">The position to sort in relation to.</param>
        /// <param name="targets">The targets to sort.</param>
        /// <param name="farthest">If this should sort by farthest items first.</param>
        public static Vector2[] SortDistance([NotNull] this Transform position, [NotNull] IEnumerable<Vector2> targets, bool farthest = false)
        {
            Sorter.Set(position, farthest);
            return targets.OrderBy(x => x, Sorter).ToArray();
        }
        
        /// <summary>
        /// Sort targets from a position.
        /// </summary>
        /// <param name="position">The position to sort in relation to.</param>
        /// <param name="targets">The targets to sort.</param>
        /// <param name="farthest">If this should sort by farthest items first.</param>
        public static void SortDistance([NotNull] this Transform position, [NotNull] Vector3[] targets, bool farthest = false)
        {
            Sorter.Set(position, farthest);
            Array.Sort(targets, Sorter);
        }
        
        /// <summary>
        /// Sort targets from a position.
        /// </summary>
        /// <param name="position">The position to sort in relation to.</param>
        /// <param name="targets">The targets to sort.</param>
        /// <param name="farthest">If this should sort by farthest items first.</param>
        public static void SortDistance([NotNull] this Transform position, [NotNull] List<Vector3> targets, bool farthest = false)
        {
            Sorter.Set(position, farthest);
            targets.Sort(Sorter);
        }
        
        /// <summary>
        /// Sort targets from a position. This version will produce garbage, and it is recommended to use an inplace method instead.
        /// </summary>
        /// <param name="position">The position to sort in relation to.</param>
        /// <param name="targets">The targets to sort.</param>
        /// <param name="farthest">If this should sort by farthest items first.</param>
        public static Vector3[] SortDistance([NotNull] this Transform position, [NotNull] IEnumerable<Vector3> targets, bool farthest = false)
        {
            Sorter.Set(position, farthest);
            return targets.OrderBy(x => x, Sorter).ToArray();
        }
        
        /// <summary>
        /// Sort targets from a position.
        /// </summary>
        /// <param name="position">The position to sort in relation to.</param>
        /// <param name="targets">The targets to sort.</param>
        /// <param name="farthest">If this should sort by farthest items first.</param>
        public static void SortDistance([NotNull] this Transform position, [NotNull] Transform[] targets, bool farthest = false)
        {
            Sorter.Set(position, farthest);
            Array.Sort(targets, Sorter);
        }
        
        /// <summary>
        /// Sort targets from a position.
        /// </summary>
        /// <param name="position">The position to sort in relation to.</param>
        /// <param name="targets">The targets to sort.</param>
        /// <param name="farthest">If this should sort by farthest items first.</param>
        public static void SortDistance([NotNull] this Transform position, [NotNull] List<Transform> targets, bool farthest = false)
        {
            Sorter.Set(position, farthest);
            targets.Sort(Sorter);
        }
        
        /// <summary>
        /// Sort targets from a position. This version will produce garbage, and it is recommended to use an inplace method instead.
        /// </summary>
        /// <param name="position">The position to sort in relation to.</param>
        /// <param name="targets">The targets to sort.</param>
        /// <param name="farthest">If this should sort by farthest items first.</param>
        public static Transform[] SortDistance([NotNull] this Transform position, [NotNull] IEnumerable<Transform> targets, bool farthest = false)
        {
            Sorter.Set(position, farthest);
            return targets.OrderBy(x => x, Sorter).ToArray();
        }
        
        /// <summary>
        /// Sort targets from a position.
        /// </summary>
        /// <param name="position">The position to sort in relation to.</param>
        /// <param name="targets">The targets to sort.</param>
        /// <param name="farthest">If this should sort by farthest items first.</param>
        public static void SortDistance<T>([NotNull] this Transform position, [NotNull] T[] targets, bool farthest = false) where T : Component
        {
            Sorter.Set(position, farthest);
            Array.Sort(targets, Sorter);
        }
        
        /// <summary>
        /// Sort targets from a position.
        /// </summary>
        /// <param name="position">The position to sort in relation to.</param>
        /// <param name="targets">The targets to sort.</param>
        /// <param name="farthest">If this should sort by farthest items first.</param>
        public static void SortDistance<T>([NotNull] this Transform position, [NotNull] List<T> targets, bool farthest = false) where T : Component
        {
            Sorter.Set(position, farthest);
            targets.Sort(Sorter);
        }
        
        /// <summary>
        /// Sort targets from a position. This version will produce garbage, and it is recommended to use an inplace method instead.
        /// </summary>
        /// <param name="position">The position to sort in relation to.</param>
        /// <param name="targets">The targets to sort.</param>
        /// <param name="farthest">If this should sort by farthest items first.</param>
        public static T[] SortDistance<T>([NotNull] this Transform position, [NotNull] IEnumerable<T> targets, bool farthest = false) where T : Component
        {
            Sorter.Set(position, farthest);
            return targets.OrderBy(x => x, Sorter).ToArray();
        }
        
        /// <summary>
        /// Sort targets from a position.
        /// </summary>
        /// <param name="position">The position to sort in relation to.</param>
        /// <param name="targets">The targets to sort.</param>
        /// <param name="farthest">If this should sort by farthest items first.</param>
        public static void SortDistance([NotNull] this Transform position, [NotNull] GameObject[] targets, bool farthest = false)
        {
            Sorter.Set(position, farthest);
            Array.Sort(targets, Sorter);
        }
        
        /// <summary>
        /// Sort targets from a position.
        /// </summary>
        /// <param name="position">The position to sort in relation to.</param>
        /// <param name="targets">The targets to sort.</param>
        /// <param name="farthest">If this should sort by farthest items first.</param>
        public static void SortDistance([NotNull] this Transform position, [NotNull] List<GameObject> targets, bool farthest = false)
        {
            Sorter.Set(position, farthest);
            targets.Sort(Sorter);
        }
        
        /// <summary>
        /// Sort targets from a position. This version will produce garbage, and it is recommended to use an inplace method instead.
        /// </summary>
        /// <param name="position">The position to sort in relation to.</param>
        /// <param name="targets">The targets to sort.</param>
        /// <param name="farthest">If this should sort by farthest items first.</param>
        public static GameObject[] SortDistance([NotNull] this Transform position, [NotNull] IEnumerable<GameObject> targets, bool farthest = false)
        {
            Sorter.Set(position, farthest);
            return targets.OrderBy(x => x, Sorter).ToArray();
        }
        
        /// <summary>
        /// Sort targets from a position.
        /// </summary>
        /// <param name="position">The position to sort in relation to.</param>
        /// <param name="targets">The targets to sort.</param>
        /// <param name="farthest">If this should sort by farthest items first.</param>
        public static void SortDistance([NotNull] this Component position, [NotNull] Vector2[] targets, bool farthest = false)
        {
            Sorter.Set(position, farthest);
            Array.Sort(targets, Sorter);
        }
        
        /// <summary>
        /// Sort targets from a position.
        /// </summary>
        /// <param name="position">The position to sort in relation to.</param>
        /// <param name="targets">The targets to sort.</param>
        /// <param name="farthest">If this should sort by farthest items first.</param>
        public static void SortDistance([NotNull] this Component position, [NotNull] List<Vector2> targets, bool farthest = false)
        {
            Sorter.Set(position, farthest);
            targets.Sort(Sorter);
        }
        
        /// <summary>
        /// Sort targets from a position. This version will produce garbage, and it is recommended to use an inplace method instead.
        /// </summary>
        /// <param name="position">The position to sort in relation to.</param>
        /// <param name="targets">The targets to sort.</param>
        /// <param name="farthest">If this should sort by farthest items first.</param>
        public static Vector2[] SortDistance([NotNull] this Component position, [NotNull] IEnumerable<Vector2> targets, bool farthest = false)
        {
            Sorter.Set(position, farthest);
            return targets.OrderBy(x => x, Sorter).ToArray();
        }
        
        /// <summary>
        /// Sort targets from a position.
        /// </summary>
        /// <param name="position">The position to sort in relation to.</param>
        /// <param name="targets">The targets to sort.</param>
        /// <param name="farthest">If this should sort by farthest items first.</param>
        public static void SortDistance([NotNull] this Component position, [NotNull] Vector3[] targets, bool farthest = false)
        {
            Sorter.Set(position, farthest);
            Array.Sort(targets, Sorter);
        }
        
        /// <summary>
        /// Sort targets from a position.
        /// </summary>
        /// <param name="position">The position to sort in relation to.</param>
        /// <param name="targets">The targets to sort.</param>
        /// <param name="farthest">If this should sort by farthest items first.</param>
        public static void SortDistance([NotNull] this Component position, [NotNull] List<Vector3> targets, bool farthest = false)
        {
            Sorter.Set(position, farthest);
            targets.Sort(Sorter);
        }
        
        /// <summary>
        /// Sort targets from a position. This version will produce garbage, and it is recommended to use an inplace method instead.
        /// </summary>
        /// <param name="position">The position to sort in relation to.</param>
        /// <param name="targets">The targets to sort.</param>
        /// <param name="farthest">If this should sort by farthest items first.</param>
        public static Vector3[] SortDistance([NotNull] this Component position, [NotNull] IEnumerable<Vector3> targets, bool farthest = false)
        {
            Sorter.Set(position, farthest);
            return targets.OrderBy(x => x, Sorter).ToArray();
        }
        
        /// <summary>
        /// Sort targets from a position.
        /// </summary>
        /// <param name="position">The position to sort in relation to.</param>
        /// <param name="targets">The targets to sort.</param>
        /// <param name="farthest">If this should sort by farthest items first.</param>
        public static void SortDistance([NotNull] this Component position, [NotNull] Transform[] targets, bool farthest = false)
        {
            Sorter.Set(position, farthest);
            Array.Sort(targets, Sorter);
        }
        
        /// <summary>
        /// Sort targets from a position.
        /// </summary>
        /// <param name="position">The position to sort in relation to.</param>
        /// <param name="targets">The targets to sort.</param>
        /// <param name="farthest">If this should sort by farthest items first.</param>
        public static void SortDistance([NotNull] this Component position, [NotNull] List<Transform> targets, bool farthest = false)
        {
            Sorter.Set(position, farthest);
            targets.Sort(Sorter);
        }
        
        /// <summary>
        /// Sort targets from a position. This version will produce garbage, and it is recommended to use an inplace method instead.
        /// </summary>
        /// <param name="position">The position to sort in relation to.</param>
        /// <param name="targets">The targets to sort.</param>
        /// <param name="farthest">If this should sort by farthest items first.</param>
        public static Transform[] SortDistance([NotNull] this Component position, [NotNull] IEnumerable<Transform> targets, bool farthest = false)
        {
            Sorter.Set(position, farthest);
            return targets.OrderBy(x => x, Sorter).ToArray();
        }
        
        /// <summary>
        /// Sort targets from a position.
        /// </summary>
        /// <param name="position">The position to sort in relation to.</param>
        /// <param name="targets">The targets to sort.</param>
        /// <param name="farthest">If this should sort by farthest items first.</param>
        public static void SortDistance<T>([NotNull] this Component position, [NotNull] T[] targets, bool farthest = false) where T : Component
        {
            Sorter.Set(position, farthest);
            Array.Sort(targets, Sorter);
        }
        
        /// <summary>
        /// Sort targets from a position.
        /// </summary>
        /// <param name="position">The position to sort in relation to.</param>
        /// <param name="targets">The targets to sort.</param>
        /// <param name="farthest">If this should sort by farthest items first.</param>
        public static void SortDistance<T>([NotNull] this Component position, [NotNull] List<T> targets, bool farthest = false) where T : Component
        {
            Sorter.Set(position, farthest);
            targets.Sort(Sorter);
        }
        
        /// <summary>
        /// Sort targets from a position. This version will produce garbage, and it is recommended to use an inplace method instead.
        /// </summary>
        /// <param name="position">The position to sort in relation to.</param>
        /// <param name="targets">The targets to sort.</param>
        /// <param name="farthest">If this should sort by farthest items first.</param>
        public static T[] SortDistance<T>([NotNull] this Component position, [NotNull] IEnumerable<T> targets, bool farthest = false) where T : Component
        {
            Sorter.Set(position, farthest);
            return targets.OrderBy(x => x, Sorter).ToArray();
        }
        
        /// <summary>
        /// Sort targets from a position.
        /// </summary>
        /// <param name="position">The position to sort in relation to.</param>
        /// <param name="targets">The targets to sort.</param>
        /// <param name="farthest">If this should sort by farthest items first.</param>
        public static void SortDistance([NotNull] this Component position, [NotNull] GameObject[] targets, bool farthest = false)
        {
            Sorter.Set(position, farthest);
            Array.Sort(targets, Sorter);
        }
        
        /// <summary>
        /// Sort targets from a position.
        /// </summary>
        /// <param name="position">The position to sort in relation to.</param>
        /// <param name="targets">The targets to sort.</param>
        /// <param name="farthest">If this should sort by farthest items first.</param>
        public static void SortDistance([NotNull] this Component position, [NotNull] List<GameObject> targets, bool farthest = false)
        {
            Sorter.Set(position, farthest);
            targets.Sort(Sorter);
        }
        
        /// <summary>
        /// Sort targets from a position. This version will produce garbage, and it is recommended to use an inplace method instead.
        /// </summary>
        /// <param name="position">The position to sort in relation to.</param>
        /// <param name="targets">The targets to sort.</param>
        /// <param name="farthest">If this should sort by farthest items first.</param>
        public static GameObject[] SortDistance([NotNull] this Component position, [NotNull] IEnumerable<GameObject> targets, bool farthest = false)
        {
            Sorter.Set(position, farthest);
            return targets.OrderBy(x => x, Sorter).ToArray();
        }
        
        /// <summary>
        /// Sort targets from a position.
        /// </summary>
        /// <param name="position">The position to sort in relation to.</param>
        /// <param name="targets">The targets to sort.</param>
        /// <param name="farthest">If this should sort by farthest items first.</param>
        public static void SortDistance([NotNull] this GameObject position, [NotNull] Vector2[] targets, bool farthest = false)
        {
            Sorter.Set(position, farthest);
            Array.Sort(targets, Sorter);
        }
        
        /// <summary>
        /// Sort targets from a position.
        /// </summary>
        /// <param name="position">The position to sort in relation to.</param>
        /// <param name="targets">The targets to sort.</param>
        /// <param name="farthest">If this should sort by farthest items first.</param>
        public static void SortDistance([NotNull] this GameObject position, [NotNull] List<Vector2> targets, bool farthest = false)
        {
            Sorter.Set(position, farthest);
            targets.Sort(Sorter);
        }
        
        /// <summary>
        /// Sort targets from a position. This version will produce garbage, and it is recommended to use an inplace method instead.
        /// </summary>
        /// <param name="position">The position to sort in relation to.</param>
        /// <param name="targets">The targets to sort.</param>
        /// <param name="farthest">If this should sort by farthest items first.</param>
        public static Vector2[] SortDistance([NotNull] this GameObject position, [NotNull] IEnumerable<Vector2> targets, bool farthest = false)
        {
            Sorter.Set(position, farthest);
            return targets.OrderBy(x => x, Sorter).ToArray();
        }
        
        /// <summary>
        /// Sort targets from a position.
        /// </summary>
        /// <param name="position">The position to sort in relation to.</param>
        /// <param name="targets">The targets to sort.</param>
        /// <param name="farthest">If this should sort by farthest items first.</param>
        public static void SortDistance([NotNull] this GameObject position, [NotNull] Vector3[] targets, bool farthest = false)
        {
            Sorter.Set(position, farthest);
            Array.Sort(targets, Sorter);
        }
        
        /// <summary>
        /// Sort targets from a position.
        /// </summary>
        /// <param name="position">The position to sort in relation to.</param>
        /// <param name="targets">The targets to sort.</param>
        /// <param name="farthest">If this should sort by farthest items first.</param>
        public static void SortDistance([NotNull] this GameObject position, [NotNull] List<Vector3> targets, bool farthest = false)
        {
            Sorter.Set(position, farthest);
            targets.Sort(Sorter);
        }
        
        /// <summary>
        /// Sort targets from a position. This version will produce garbage, and it is recommended to use an inplace method instead.
        /// </summary>
        /// <param name="position">The position to sort in relation to.</param>
        /// <param name="targets">The targets to sort.</param>
        /// <param name="farthest">If this should sort by farthest items first.</param>
        public static Vector3[] SortDistance([NotNull] this GameObject position, [NotNull] IEnumerable<Vector3> targets, bool farthest = false)
        {
            Sorter.Set(position, farthest);
            return targets.OrderBy(x => x, Sorter).ToArray();
        }
        
        /// <summary>
        /// Sort targets from a position.
        /// </summary>
        /// <param name="position">The position to sort in relation to.</param>
        /// <param name="targets">The targets to sort.</param>
        /// <param name="farthest">If this should sort by farthest items first.</param>
        public static void SortDistance([NotNull] this GameObject position, [NotNull] Transform[] targets, bool farthest = false)
        {
            Sorter.Set(position, farthest);
            Array.Sort(targets, Sorter);
        }
        
        /// <summary>
        /// Sort targets from a position.
        /// </summary>
        /// <param name="position">The position to sort in relation to.</param>
        /// <param name="targets">The targets to sort.</param>
        /// <param name="farthest">If this should sort by farthest items first.</param>
        public static void SortDistance([NotNull] this GameObject position, [NotNull] List<Transform> targets, bool farthest = false)
        {
            Sorter.Set(position, farthest);
            targets.Sort(Sorter);
        }
        
        /// <summary>
        /// Sort targets from a position. This version will produce garbage, and it is recommended to use an inplace method instead.
        /// </summary>
        /// <param name="position">The position to sort in relation to.</param>
        /// <param name="targets">The targets to sort.</param>
        /// <param name="farthest">If this should sort by farthest items first.</param>
        public static Transform[] SortDistance([NotNull] this GameObject position, [NotNull] IEnumerable<Transform> targets, bool farthest = false)
        {
            Sorter.Set(position, farthest);
            return targets.OrderBy(x => x, Sorter).ToArray();
        }
        
        /// <summary>
        /// Sort targets from a position.
        /// </summary>
        /// <param name="position">The position to sort in relation to.</param>
        /// <param name="targets">The targets to sort.</param>
        /// <param name="farthest">If this should sort by farthest items first.</param>
        public static void SortDistance<T>([NotNull] this GameObject position, [NotNull] T[] targets, bool farthest = false) where T : Component
        {
            Sorter.Set(position, farthest);
            Array.Sort(targets, Sorter);
        }
        
        /// <summary>
        /// Sort targets from a position.
        /// </summary>
        /// <param name="position">The position to sort in relation to.</param>
        /// <param name="targets">The targets to sort.</param>
        /// <param name="farthest">If this should sort by farthest items first.</param>
        public static void SortDistance<T>([NotNull] this GameObject position, [NotNull] List<T> targets, bool farthest = false) where T : Component
        {
            Sorter.Set(position, farthest);
            targets.Sort(Sorter);
        }
        
        /// <summary>
        /// Sort targets from a position. This version will produce garbage, and it is recommended to use an inplace method instead.
        /// </summary>
        /// <param name="position">The position to sort in relation to.</param>
        /// <param name="targets">The targets to sort.</param>
        /// <param name="farthest">If this should sort by farthest items first.</param>
        public static T[] SortDistance<T>([NotNull] this GameObject position, [NotNull] IEnumerable<T> targets, bool farthest = false) where T : Component
        {
            Sorter.Set(position, farthest);
            return targets.OrderBy(x => x, Sorter).ToArray();
        }
        
        /// <summary>
        /// Sort targets from a position.
        /// </summary>
        /// <param name="position">The position to sort in relation to.</param>
        /// <param name="targets">The targets to sort.</param>
        /// <param name="farthest">If this should sort by farthest items first.</param>
        public static void SortDistance([NotNull] this GameObject position, [NotNull] GameObject[] targets, bool farthest = false)
        {
            Sorter.Set(position, farthest);
            Array.Sort(targets, Sorter);
        }
        
        /// <summary>
        /// Sort targets from a position.
        /// </summary>
        /// <param name="position">The position to sort in relation to.</param>
        /// <param name="targets">The targets to sort.</param>
        /// <param name="farthest">If this should sort by farthest items first.</param>
        public static void SortDistance([NotNull] this GameObject position, [NotNull] List<GameObject> targets, bool farthest = false)
        {
            Sorter.Set(position, farthest);
            targets.Sort(Sorter);
        }
        
        /// <summary>
        /// Sort targets from a position. This version will produce garbage, and it is recommended to use an inplace method instead.
        /// </summary>
        /// <param name="position">The position to sort in relation to.</param>
        /// <param name="targets">The targets to sort.</param>
        /// <param name="farthest">If this should sort by farthest items first.</param>
        public static GameObject[] SortDistance([NotNull] this GameObject position, [NotNull] IEnumerable<GameObject> targets, bool farthest = false)
        {
            Sorter.Set(position, farthest);
            return targets.OrderBy(x => x, Sorter).ToArray();
        }
    }
}