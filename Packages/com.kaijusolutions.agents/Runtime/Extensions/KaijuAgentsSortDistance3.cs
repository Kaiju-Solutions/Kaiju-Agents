using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using UnityEngine;

namespace KaijuSolutions.Agents.Extensions
{
    /// <summary>
    /// Extension methods for sorting objects by their distance to a given position along all three axes. Any Vector2 values will be expanded via the <see cref="KaijuAgentsExpand.Expand"/> method.
    /// </summary>
    public static class KaijuAgentsSortDistance3
    {
        /// <summary>
        /// The sorter for distance.
        /// </summary>
        private static readonly KaijuAgentsDistance3Sorter Sorter3 = new (Vector3.zero);
        
        /// <summary>
        /// Sort targets from a position across all axes.
        /// </summary>
        /// <param name="position">The position to sort in relation to.</param>
        /// <param name="targets">The targets to sort.</param>
        /// <param name="farthest">If this should sort by farthest items first.</param>
        public static void SortDistance3(this Vector2 position, [NotNull] Vector3[] targets, bool farthest = false)
        {
            Sorter3.Set(position, farthest);
            Array.Sort(targets, Sorter3);
        }
        
        /// <summary>
        /// Sort targets from a position across all axes.
        /// </summary>
        /// <param name="position">The position to sort in relation to.</param>
        /// <param name="targets">The targets to sort.</param>
        /// <param name="farthest">If this should sort by farthest items first.</param>
        public static void SortDistance3(this Vector2 position, [NotNull] List<Vector3> targets, bool farthest = false)
        {
            Sorter3.Set(position, farthest);
            targets.Sort(Sorter3);
        }
        
        /// <summary>
        /// Sort targets from a position across all axes. This version will produce garbage, and it is recommended to use an inplace method instead.
        /// </summary>
        /// <param name="position">The position to sort in relation to.</param>
        /// <param name="targets">The targets to sort.</param>
        /// <param name="farthest">If this should sort by farthest items first.</param>
        public static Vector3[] SortDistance3(this Vector2 position, [NotNull] IEnumerable<Vector3> targets, bool farthest = false)
        {
            Sorter3.Set(position, farthest);
            return targets.OrderBy(x => x, Sorter3).ToArray();
        }
        
        /// <summary>
        /// Sort targets from a position across all axes.
        /// </summary>
        /// <param name="position">The position to sort in relation to.</param>
        /// <param name="targets">The targets to sort.</param>
        /// <param name="farthest">If this should sort by farthest items first.</param>
        public static void SortDistance3(this Vector2 position, [NotNull] Transform[] targets, bool farthest = false)
        {
            Sorter3.Set(position, farthest);
            Array.Sort(targets, Sorter3);
        }
        
        /// <summary>
        /// Sort targets from a position across all axes.
        /// </summary>
        /// <param name="position">The position to sort in relation to.</param>
        /// <param name="targets">The targets to sort.</param>
        /// <param name="farthest">If this should sort by farthest items first.</param>
        public static void SortDistance3(this Vector2 position, [NotNull] List<Transform> targets, bool farthest = false)
        {
            Sorter3.Set(position, farthest);
            targets.Sort(Sorter3);
        }
        
        /// <summary>
        /// Sort targets from a position across all axes. This version will produce garbage, and it is recommended to use an inplace method instead.
        /// </summary>
        /// <param name="position">The position to sort in relation to.</param>
        /// <param name="targets">The targets to sort.</param>
        /// <param name="farthest">If this should sort by farthest items first.</param>
        public static Transform[] SortDistance3(this Vector2 position, [NotNull] IEnumerable<Transform> targets, bool farthest = false)
        {
            Sorter3.Set(position, farthest);
            return targets.OrderBy(x => x, Sorter3).ToArray();
        }
        
        /// <summary>
        /// Sort targets from a position across all axes.
        /// </summary>
        /// <param name="position">The position to sort in relation to.</param>
        /// <param name="targets">The targets to sort.</param>
        /// <param name="farthest">If this should sort by farthest items first.</param>
        public static void SortDistance3<T>(this Vector2 position, [NotNull] T[] targets, bool farthest = false) where T : Component
        {
            Sorter3.Set(position, farthest);
            Array.Sort(targets, Sorter3);
        }
        
        /// <summary>
        /// Sort targets from a position across all axes.
        /// </summary>
        /// <param name="position">The position to sort in relation to.</param>
        /// <param name="targets">The targets to sort.</param>
        /// <param name="farthest">If this should sort by farthest items first.</param>
        public static void SortDistance3<T>(this Vector2 position, [NotNull] List<T> targets, bool farthest = false) where T : Component
        {
            Sorter3.Set(position, farthest);
            targets.Sort(Sorter3);
        }
        
        /// <summary>
        /// Sort targets from a position across all axes. This version will produce garbage, and it is recommended to use an inplace method instead.
        /// </summary>
        /// <param name="position">The position to sort in relation to.</param>
        /// <param name="targets">The targets to sort.</param>
        /// <param name="farthest">If this should sort by farthest items first.</param>
        public static T[] SortDistance3<T>(this Vector2 position, [NotNull] IEnumerable<T> targets, bool farthest = false) where T : Component
        {
            Sorter3.Set(position, farthest);
            return targets.OrderBy(x => x, Sorter3).ToArray();
        }
        
        /// <summary>
        /// Sort targets from a position across all axes.
        /// </summary>
        /// <param name="position">The position to sort in relation to.</param>
        /// <param name="targets">The targets to sort.</param>
        /// <param name="farthest">If this should sort by farthest items first.</param>
        public static void SortDistance3(this Vector2 position, [NotNull] GameObject[] targets, bool farthest = false)
        {
            Sorter3.Set(position, farthest);
            Array.Sort(targets, Sorter3);
        }
        
        /// <summary>
        /// Sort targets from a position across all axes.
        /// </summary>
        /// <param name="position">The position to sort in relation to.</param>
        /// <param name="targets">The targets to sort.</param>
        /// <param name="farthest">If this should sort by farthest items first.</param>
        public static void SortDistance3(this Vector2 position, [NotNull] List<GameObject> targets, bool farthest = false)
        {
            Sorter3.Set(position, farthest);
            targets.Sort(Sorter3);
        }
        
        /// <summary>
        /// Sort targets from a position across all axes. This version will produce garbage, and it is recommended to use an inplace method instead.
        /// </summary>
        /// <param name="position">The position to sort in relation to.</param>
        /// <param name="targets">The targets to sort.</param>
        /// <param name="farthest">If this should sort by farthest items first.</param>
        public static GameObject[] SortDistance3(this Vector2 position, [NotNull] IEnumerable<GameObject> targets, bool farthest = false)
        {
            Sorter3.Set(position, farthest);
            return targets.OrderBy(x => x, Sorter3).ToArray();
        }
        
        /// <summary>
        /// Sort targets from a position across all axes.
        /// </summary>
        /// <param name="position">The position to sort in relation to.</param>
        /// <param name="targets">The targets to sort.</param>
        /// <param name="farthest">If this should sort by farthest items first.</param>
        public static void SortDistance3(this Vector3 position, [NotNull] Vector2[] targets, bool farthest = false)
        {
            Sorter3.Set(position, farthest);
            Array.Sort(targets, Sorter3);
        }
        
        /// <summary>
        /// Sort targets from a position across all axes.
        /// </summary>
        /// <param name="position">The position to sort in relation to.</param>
        /// <param name="targets">The targets to sort.</param>
        /// <param name="farthest">If this should sort by farthest items first.</param>
        public static void SortDistance3(this Vector3 position, [NotNull] List<Vector2> targets, bool farthest = false)
        {
            Sorter3.Set(position, farthest);
            targets.Sort(Sorter3);
        }
        
        /// <summary>
        /// Sort targets from a position across all axes. This version will produce garbage, and it is recommended to use an inplace method instead.
        /// </summary>
        /// <param name="position">The position to sort in relation to.</param>
        /// <param name="targets">The targets to sort.</param>
        /// <param name="farthest">If this should sort by farthest items first.</param>
        public static Vector2[] SortDistance3(this Vector3 position, [NotNull] IEnumerable<Vector2> targets, bool farthest = false)
        {
            Sorter3.Set(position, farthest);
            return targets.OrderBy(x => x, Sorter3).ToArray();
        }
        
        /// <summary>
        /// Sort targets from a position across all axes.
        /// </summary>
        /// <param name="position">The position to sort in relation to.</param>
        /// <param name="targets">The targets to sort.</param>
        /// <param name="farthest">If this should sort by farthest items first.</param>
        public static void SortDistance3(this Vector3 position, [NotNull] Vector3[] targets, bool farthest = false)
        {
            Sorter3.Set(position, farthest);
            Array.Sort(targets, Sorter3);
        }
        
        /// <summary>
        /// Sort targets from a position across all axes.
        /// </summary>
        /// <param name="position">The position to sort in relation to.</param>
        /// <param name="targets">The targets to sort.</param>
        /// <param name="farthest">If this should sort by farthest items first.</param>
        public static void SortDistance3(this Vector3 position, [NotNull] List<Vector3> targets, bool farthest = false)
        {
            Sorter3.Set(position, farthest);
            targets.Sort(Sorter3);
        }
        
        /// <summary>
        /// Sort targets from a position across all axes. This version will produce garbage, and it is recommended to use an inplace method instead.
        /// </summary>
        /// <param name="position">The position to sort in relation to.</param>
        /// <param name="targets">The targets to sort.</param>
        /// <param name="farthest">If this should sort by farthest items first.</param>
        public static Vector3[] SortDistance3(this Vector3 position, [NotNull] IEnumerable<Vector3> targets, bool farthest = false)
        {
            Sorter3.Set(position, farthest);
            return targets.OrderBy(x => x, Sorter3).ToArray();
        }
        
        /// <summary>
        /// Sort targets from a position across all axes.
        /// </summary>
        /// <param name="position">The position to sort in relation to.</param>
        /// <param name="targets">The targets to sort.</param>
        /// <param name="farthest">If this should sort by farthest items first.</param>
        public static void SortDistance3(this Vector3 position, [NotNull] Transform[] targets, bool farthest = false)
        {
            Sorter3.Set(position, farthest);
            Array.Sort(targets, Sorter3);
        }
        
        /// <summary>
        /// Sort targets from a position across all axes.
        /// </summary>
        /// <param name="position">The position to sort in relation to.</param>
        /// <param name="targets">The targets to sort.</param>
        /// <param name="farthest">If this should sort by farthest items first.</param>
        public static void SortDistance3(this Vector3 position, [NotNull] List<Transform> targets, bool farthest = false)
        {
            Sorter3.Set(position, farthest);
            targets.Sort(Sorter3);
        }
        
        /// <summary>
        /// Sort targets from a position across all axes. This version will produce garbage, and it is recommended to use an inplace method instead.
        /// </summary>
        /// <param name="position">The position to sort in relation to.</param>
        /// <param name="targets">The targets to sort.</param>
        /// <param name="farthest">If this should sort by farthest items first.</param>
        public static Transform[] SortDistance3(this Vector3 position, [NotNull] IEnumerable<Transform> targets, bool farthest = false)
        {
            Sorter3.Set(position, farthest);
            return targets.OrderBy(x => x, Sorter3).ToArray();
        }
        
        /// <summary>
        /// Sort targets from a position across all axes.
        /// </summary>
        /// <param name="position">The position to sort in relation to.</param>
        /// <param name="targets">The targets to sort.</param>
        /// <param name="farthest">If this should sort by farthest items first.</param>
        public static void SortDistance3<T>(this Vector3 position, [NotNull] T[] targets, bool farthest = false) where T : Component
        {
            Sorter3.Set(position, farthest);
            Array.Sort(targets, Sorter3);
        }
        
        /// <summary>
        /// Sort targets from a position across all axes.
        /// </summary>
        /// <param name="position">The position to sort in relation to.</param>
        /// <param name="targets">The targets to sort.</param>
        /// <param name="farthest">If this should sort by farthest items first.</param>
        public static void SortDistance3<T>(this Vector3 position, [NotNull] List<T> targets, bool farthest = false) where T : Component
        {
            Sorter3.Set(position, farthest);
            targets.Sort(Sorter3);
        }
        
        /// <summary>
        /// Sort targets from a position across all axes. This version will produce garbage, and it is recommended to use an inplace method instead.
        /// </summary>
        /// <param name="position">The position to sort in relation to.</param>
        /// <param name="targets">The targets to sort.</param>
        /// <param name="farthest">If this should sort by farthest items first.</param>
        public static T[] SortDistance3<T>(this Vector3 position, [NotNull] IEnumerable<T> targets, bool farthest = false) where T : Component
        {
            Sorter3.Set(position, farthest);
            return targets.OrderBy(x => x, Sorter3).ToArray();
        }
        
        /// <summary>
        /// Sort targets from a position across all axes.
        /// </summary>
        /// <param name="position">The position to sort in relation to.</param>
        /// <param name="targets">The targets to sort.</param>
        /// <param name="farthest">If this should sort by farthest items first.</param>
        public static void SortDistance3(this Vector3 position, [NotNull] GameObject[] targets, bool farthest = false)
        {
            Sorter3.Set(position, farthest);
            Array.Sort(targets, Sorter3);
        }
        
        /// <summary>
        /// Sort targets from a position across all axes.
        /// </summary>
        /// <param name="position">The position to sort in relation to.</param>
        /// <param name="targets">The targets to sort.</param>
        /// <param name="farthest">If this should sort by farthest items first.</param>
        public static void SortDistance3(this Vector3 position, [NotNull] List<GameObject> targets, bool farthest = false)
        {
            Sorter3.Set(position, farthest);
            targets.Sort(Sorter3);
        }
        
        /// <summary>
        /// Sort targets from a position across all axes. This version will produce garbage, and it is recommended to use an inplace method instead.
        /// </summary>
        /// <param name="position">The position to sort in relation to.</param>
        /// <param name="targets">The targets to sort.</param>
        /// <param name="farthest">If this should sort by farthest items first.</param>
        public static GameObject[] SortDistance3(this Vector3 position, [NotNull] IEnumerable<GameObject> targets, bool farthest = false)
        {
            Sorter3.Set(position, farthest);
            return targets.OrderBy(x => x, Sorter3).ToArray();
        }
        
        /// <summary>
        /// Sort targets from a position across all axes.
        /// </summary>
        /// <param name="position">The position to sort in relation to.</param>
        /// <param name="targets">The targets to sort.</param>
        /// <param name="farthest">If this should sort by farthest items first.</param>
        public static void SortDistance3([NotNull] this Transform position, [NotNull] Vector2[] targets, bool farthest = false)
        {
            Sorter3.Set(position, farthest);
            Array.Sort(targets, Sorter3);
        }
        
        /// <summary>
        /// Sort targets from a position across all axes.
        /// </summary>
        /// <param name="position">The position to sort in relation to.</param>
        /// <param name="targets">The targets to sort.</param>
        /// <param name="farthest">If this should sort by farthest items first.</param>
        public static void SortDistance3([NotNull] this Transform position, [NotNull] List<Vector2> targets, bool farthest = false)
        {
            Sorter3.Set(position, farthest);
            targets.Sort(Sorter3);
        }
        
        /// <summary>
        /// Sort targets from a position across all axes. This version will produce garbage, and it is recommended to use an inplace method instead.
        /// </summary>
        /// <param name="position">The position to sort in relation to.</param>
        /// <param name="targets">The targets to sort.</param>
        /// <param name="farthest">If this should sort by farthest items first.</param>
        public static Vector2[] SortDistance3([NotNull] this Transform position, [NotNull] IEnumerable<Vector2> targets, bool farthest = false)
        {
            Sorter3.Set(position, farthest);
            return targets.OrderBy(x => x, Sorter3).ToArray();
        }
        
        /// <summary>
        /// Sort targets from a position across all axes.
        /// </summary>
        /// <param name="position">The position to sort in relation to.</param>
        /// <param name="targets">The targets to sort.</param>
        /// <param name="farthest">If this should sort by farthest items first.</param>
        public static void SortDistance3([NotNull] this Transform position, [NotNull] Vector3[] targets, bool farthest = false)
        {
            Sorter3.Set(position, farthest);
            Array.Sort(targets, Sorter3);
        }
        
        /// <summary>
        /// Sort targets from a position across all axes.
        /// </summary>
        /// <param name="position">The position to sort in relation to.</param>
        /// <param name="targets">The targets to sort.</param>
        /// <param name="farthest">If this should sort by farthest items first.</param>
        public static void SortDistance3([NotNull] this Transform position, [NotNull] List<Vector3> targets, bool farthest = false)
        {
            Sorter3.Set(position, farthest);
            targets.Sort(Sorter3);
        }
        
        /// <summary>
        /// Sort targets from a position across all axes. This version will produce garbage, and it is recommended to use an inplace method instead.
        /// </summary>
        /// <param name="position">The position to sort in relation to.</param>
        /// <param name="targets">The targets to sort.</param>
        /// <param name="farthest">If this should sort by farthest items first.</param>
        public static Vector3[] SortDistance3([NotNull] this Transform position, [NotNull] IEnumerable<Vector3> targets, bool farthest = false)
        {
            Sorter3.Set(position, farthest);
            return targets.OrderBy(x => x, Sorter3).ToArray();
        }
        
        /// <summary>
        /// Sort targets from a position across all axes.
        /// </summary>
        /// <param name="position">The position to sort in relation to.</param>
        /// <param name="targets">The targets to sort.</param>
        /// <param name="farthest">If this should sort by farthest items first.</param>
        public static void SortDistance3([NotNull] this Transform position, [NotNull] Transform[] targets, bool farthest = false)
        {
            Sorter3.Set(position, farthest);
            Array.Sort(targets, Sorter3);
        }
        
        /// <summary>
        /// Sort targets from a position across all axes.
        /// </summary>
        /// <param name="position">The position to sort in relation to.</param>
        /// <param name="targets">The targets to sort.</param>
        /// <param name="farthest">If this should sort by farthest items first.</param>
        public static void SortDistance3([NotNull] this Transform position, [NotNull] List<Transform> targets, bool farthest = false)
        {
            Sorter3.Set(position, farthest);
            targets.Sort(Sorter3);
        }
        
        /// <summary>
        /// Sort targets from a position across all axes. This version will produce garbage, and it is recommended to use an inplace method instead.
        /// </summary>
        /// <param name="position">The position to sort in relation to.</param>
        /// <param name="targets">The targets to sort.</param>
        /// <param name="farthest">If this should sort by farthest items first.</param>
        public static Transform[] SortDistance3([NotNull] this Transform position, [NotNull] IEnumerable<Transform> targets, bool farthest = false)
        {
            Sorter3.Set(position, farthest);
            return targets.OrderBy(x => x, Sorter3).ToArray();
        }
        
        /// <summary>
        /// Sort targets from a position across all axes.
        /// </summary>
        /// <param name="position">The position to sort in relation to.</param>
        /// <param name="targets">The targets to sort.</param>
        /// <param name="farthest">If this should sort by farthest items first.</param>
        public static void SortDistance3<T>([NotNull] this Transform position, [NotNull] T[] targets, bool farthest = false) where T : Component
        {
            Sorter3.Set(position, farthest);
            Array.Sort(targets, Sorter3);
        }
        
        /// <summary>
        /// Sort targets from a position across all axes.
        /// </summary>
        /// <param name="position">The position to sort in relation to.</param>
        /// <param name="targets">The targets to sort.</param>
        /// <param name="farthest">If this should sort by farthest items first.</param>
        public static void SortDistance3<T>([NotNull] this Transform position, [NotNull] List<T> targets, bool farthest = false) where T : Component
        {
            Sorter3.Set(position, farthest);
            targets.Sort(Sorter3);
        }
        
        /// <summary>
        /// Sort targets from a position across all axes. This version will produce garbage, and it is recommended to use an inplace method instead.
        /// </summary>
        /// <param name="position">The position to sort in relation to.</param>
        /// <param name="targets">The targets to sort.</param>
        /// <param name="farthest">If this should sort by farthest items first.</param>
        public static T[] SortDistance3<T>([NotNull] this Transform position, [NotNull] IEnumerable<T> targets, bool farthest = false) where T : Component
        {
            Sorter3.Set(position, farthest);
            return targets.OrderBy(x => x, Sorter3).ToArray();
        }
        
        /// <summary>
        /// Sort targets from a position across all axes.
        /// </summary>
        /// <param name="position">The position to sort in relation to.</param>
        /// <param name="targets">The targets to sort.</param>
        /// <param name="farthest">If this should sort by farthest items first.</param>
        public static void SortDistance3([NotNull] this Transform position, [NotNull] GameObject[] targets, bool farthest = false)
        {
            Sorter3.Set(position, farthest);
            Array.Sort(targets, Sorter3);
        }
        
        /// <summary>
        /// Sort targets from a position across all axes.
        /// </summary>
        /// <param name="position">The position to sort in relation to.</param>
        /// <param name="targets">The targets to sort.</param>
        /// <param name="farthest">If this should sort by farthest items first.</param>
        public static void SortDistance3([NotNull] this Transform position, [NotNull] List<GameObject> targets, bool farthest = false)
        {
            Sorter3.Set(position, farthest);
            targets.Sort(Sorter3);
        }
        
        /// <summary>
        /// Sort targets from a position across all axes. This version will produce garbage, and it is recommended to use an inplace method instead.
        /// </summary>
        /// <param name="position">The position to sort in relation to.</param>
        /// <param name="targets">The targets to sort.</param>
        /// <param name="farthest">If this should sort by farthest items first.</param>
        public static GameObject[] SortDistance3([NotNull] this Transform position, [NotNull] IEnumerable<GameObject> targets, bool farthest = false)
        {
            Sorter3.Set(position, farthest);
            return targets.OrderBy(x => x, Sorter3).ToArray();
        }
        
        /// <summary>
        /// Sort targets from a position across all axes.
        /// </summary>
        /// <param name="position">The position to sort in relation to.</param>
        /// <param name="targets">The targets to sort.</param>
        /// <param name="farthest">If this should sort by farthest items first.</param>
        public static void SortDistance3([NotNull] this Component position, [NotNull] Vector2[] targets, bool farthest = false)
        {
            Sorter3.Set(position, farthest);
            Array.Sort(targets, Sorter3);
        }
        
        /// <summary>
        /// Sort targets from a position across all axes.
        /// </summary>
        /// <param name="position">The position to sort in relation to.</param>
        /// <param name="targets">The targets to sort.</param>
        /// <param name="farthest">If this should sort by farthest items first.</param>
        public static void SortDistance3([NotNull] this Component position, [NotNull] List<Vector2> targets, bool farthest = false)
        {
            Sorter3.Set(position, farthest);
            targets.Sort(Sorter3);
        }
        
        /// <summary>
        /// Sort targets from a position across all axes. This version will produce garbage, and it is recommended to use an inplace method instead.
        /// </summary>
        /// <param name="position">The position to sort in relation to.</param>
        /// <param name="targets">The targets to sort.</param>
        /// <param name="farthest">If this should sort by farthest items first.</param>
        public static Vector2[] SortDistance3([NotNull] this Component position, [NotNull] IEnumerable<Vector2> targets, bool farthest = false)
        {
            Sorter3.Set(position, farthest);
            return targets.OrderBy(x => x, Sorter3).ToArray();
        }
        
        /// <summary>
        /// Sort targets from a position across all axes.
        /// </summary>
        /// <param name="position">The position to sort in relation to.</param>
        /// <param name="targets">The targets to sort.</param>
        /// <param name="farthest">If this should sort by farthest items first.</param>
        public static void SortDistance3([NotNull] this Component position, [NotNull] Vector3[] targets, bool farthest = false)
        {
            Sorter3.Set(position, farthest);
            Array.Sort(targets, Sorter3);
        }
        
        /// <summary>
        /// Sort targets from a position across all axes.
        /// </summary>
        /// <param name="position">The position to sort in relation to.</param>
        /// <param name="targets">The targets to sort.</param>
        /// <param name="farthest">If this should sort by farthest items first.</param>
        public static void SortDistance3([NotNull] this Component position, [NotNull] List<Vector3> targets, bool farthest = false)
        {
            Sorter3.Set(position, farthest);
            targets.Sort(Sorter3);
        }
        
        /// <summary>
        /// Sort targets from a position across all axes. This version will produce garbage, and it is recommended to use an inplace method instead.
        /// </summary>
        /// <param name="position">The position to sort in relation to.</param>
        /// <param name="targets">The targets to sort.</param>
        /// <param name="farthest">If this should sort by farthest items first.</param>
        public static Vector3[] SortDistance3([NotNull] this Component position, [NotNull] IEnumerable<Vector3> targets, bool farthest = false)
        {
            Sorter3.Set(position, farthest);
            return targets.OrderBy(x => x, Sorter3).ToArray();
        }
        
        /// <summary>
        /// Sort targets from a position across all axes.
        /// </summary>
        /// <param name="position">The position to sort in relation to.</param>
        /// <param name="targets">The targets to sort.</param>
        /// <param name="farthest">If this should sort by farthest items first.</param>
        public static void SortDistance3([NotNull] this Component position, [NotNull] Transform[] targets, bool farthest = false)
        {
            Sorter3.Set(position, farthest);
            Array.Sort(targets, Sorter3);
        }
        
        /// <summary>
        /// Sort targets from a position across all axes.
        /// </summary>
        /// <param name="position">The position to sort in relation to.</param>
        /// <param name="targets">The targets to sort.</param>
        /// <param name="farthest">If this should sort by farthest items first.</param>
        public static void SortDistance3([NotNull] this Component position, [NotNull] List<Transform> targets, bool farthest = false)
        {
            Sorter3.Set(position, farthest);
            targets.Sort(Sorter3);
        }
        
        /// <summary>
        /// Sort targets from a position across all axes. This version will produce garbage, and it is recommended to use an inplace method instead.
        /// </summary>
        /// <param name="position">The position to sort in relation to.</param>
        /// <param name="targets">The targets to sort.</param>
        /// <param name="farthest">If this should sort by farthest items first.</param>
        public static Transform[] SortDistance3([NotNull] this Component position, [NotNull] IEnumerable<Transform> targets, bool farthest = false)
        {
            Sorter3.Set(position, farthest);
            return targets.OrderBy(x => x, Sorter3).ToArray();
        }
        
        /// <summary>
        /// Sort targets from a position across all axes.
        /// </summary>
        /// <param name="position">The position to sort in relation to.</param>
        /// <param name="targets">The targets to sort.</param>
        /// <param name="farthest">If this should sort by farthest items first.</param>
        public static void SortDistance3<T>([NotNull] this Component position, [NotNull] T[] targets, bool farthest = false) where T : Component
        {
            Sorter3.Set(position, farthest);
            Array.Sort(targets, Sorter3);
        }
        
        /// <summary>
        /// Sort targets from a position across all axes.
        /// </summary>
        /// <param name="position">The position to sort in relation to.</param>
        /// <param name="targets">The targets to sort.</param>
        /// <param name="farthest">If this should sort by farthest items first.</param>
        public static void SortDistance3<T>([NotNull] this Component position, [NotNull] List<T> targets, bool farthest = false) where T : Component
        {
            Sorter3.Set(position, farthest);
            targets.Sort(Sorter3);
        }
        
        /// <summary>
        /// Sort targets from a position across all axes. This version will produce garbage, and it is recommended to use an inplace method instead.
        /// </summary>
        /// <param name="position">The position to sort in relation to.</param>
        /// <param name="targets">The targets to sort.</param>
        /// <param name="farthest">If this should sort by farthest items first.</param>
        public static T[] SortDistance3<T>([NotNull] this Component position, [NotNull] IEnumerable<T> targets, bool farthest = false) where T : Component
        {
            Sorter3.Set(position, farthest);
            return targets.OrderBy(x => x, Sorter3).ToArray();
        }
        
        /// <summary>
        /// Sort targets from a position across all axes.
        /// </summary>
        /// <param name="position">The position to sort in relation to.</param>
        /// <param name="targets">The targets to sort.</param>
        /// <param name="farthest">If this should sort by farthest items first.</param>
        public static void SortDistance3([NotNull] this Component position, [NotNull] GameObject[] targets, bool farthest = false)
        {
            Sorter3.Set(position, farthest);
            Array.Sort(targets, Sorter3);
        }
        
        /// <summary>
        /// Sort targets from a position across all axes.
        /// </summary>
        /// <param name="position">The position to sort in relation to.</param>
        /// <param name="targets">The targets to sort.</param>
        /// <param name="farthest">If this should sort by farthest items first.</param>
        public static void SortDistance3([NotNull] this Component position, [NotNull] List<GameObject> targets, bool farthest = false)
        {
            Sorter3.Set(position, farthest);
            targets.Sort(Sorter3);
        }
        
        /// <summary>
        /// Sort targets from a position across all axes. This version will produce garbage, and it is recommended to use an inplace method instead.
        /// </summary>
        /// <param name="position">The position to sort in relation to.</param>
        /// <param name="targets">The targets to sort.</param>
        /// <param name="farthest">If this should sort by farthest items first.</param>
        public static GameObject[] SortDistance3([NotNull] this Component position, [NotNull] IEnumerable<GameObject> targets, bool farthest = false)
        {
            Sorter3.Set(position, farthest);
            return targets.OrderBy(x => x, Sorter3).ToArray();
        }
        
        /// <summary>
        /// Sort targets from a position across all axes.
        /// </summary>
        /// <param name="position">The position to sort in relation to.</param>
        /// <param name="targets">The targets to sort.</param>
        /// <param name="farthest">If this should sort by farthest items first.</param>
        public static void SortDistance3([NotNull] this GameObject position, [NotNull] Vector2[] targets, bool farthest = false)
        {
            Sorter3.Set(position, farthest);
            Array.Sort(targets, Sorter3);
        }
        
        /// <summary>
        /// Sort targets from a position across all axes.
        /// </summary>
        /// <param name="position">The position to sort in relation to.</param>
        /// <param name="targets">The targets to sort.</param>
        /// <param name="farthest">If this should sort by farthest items first.</param>
        public static void SortDistance3([NotNull] this GameObject position, [NotNull] List<Vector2> targets, bool farthest = false)
        {
            Sorter3.Set(position, farthest);
            targets.Sort(Sorter3);
        }
        
        /// <summary>
        /// Sort targets from a position across all axes. This version will produce garbage, and it is recommended to use an inplace method instead.
        /// </summary>
        /// <param name="position">The position to sort in relation to.</param>
        /// <param name="targets">The targets to sort.</param>
        /// <param name="farthest">If this should sort by farthest items first.</param>
        public static Vector2[] SortDistance3([NotNull] this GameObject position, [NotNull] IEnumerable<Vector2> targets, bool farthest = false)
        {
            Sorter3.Set(position, farthest);
            return targets.OrderBy(x => x, Sorter3).ToArray();
        }
        
        /// <summary>
        /// Sort targets from a position across all axes.
        /// </summary>
        /// <param name="position">The position to sort in relation to.</param>
        /// <param name="targets">The targets to sort.</param>
        /// <param name="farthest">If this should sort by farthest items first.</param>
        public static void SortDistance3([NotNull] this GameObject position, [NotNull] Vector3[] targets, bool farthest = false)
        {
            Sorter3.Set(position, farthest);
            Array.Sort(targets, Sorter3);
        }
        
        /// <summary>
        /// Sort targets from a position across all axes.
        /// </summary>
        /// <param name="position">The position to sort in relation to.</param>
        /// <param name="targets">The targets to sort.</param>
        /// <param name="farthest">If this should sort by farthest items first.</param>
        public static void SortDistance3([NotNull] this GameObject position, [NotNull] List<Vector3> targets, bool farthest = false)
        {
            Sorter3.Set(position, farthest);
            targets.Sort(Sorter3);
        }
        
        /// <summary>
        /// Sort targets from a position across all axes. This version will produce garbage, and it is recommended to use an inplace method instead.
        /// </summary>
        /// <param name="position">The position to sort in relation to.</param>
        /// <param name="targets">The targets to sort.</param>
        /// <param name="farthest">If this should sort by farthest items first.</param>
        public static Vector3[] SortDistance3([NotNull] this GameObject position, [NotNull] IEnumerable<Vector3> targets, bool farthest = false)
        {
            Sorter3.Set(position, farthest);
            return targets.OrderBy(x => x, Sorter3).ToArray();
        }
        
        /// <summary>
        /// Sort targets from a position across all axes.
        /// </summary>
        /// <param name="position">The position to sort in relation to.</param>
        /// <param name="targets">The targets to sort.</param>
        /// <param name="farthest">If this should sort by farthest items first.</param>
        public static void SortDistance3([NotNull] this GameObject position, [NotNull] Transform[] targets, bool farthest = false)
        {
            Sorter3.Set(position, farthest);
            Array.Sort(targets, Sorter3);
        }
        
        /// <summary>
        /// Sort targets from a position across all axes.
        /// </summary>
        /// <param name="position">The position to sort in relation to.</param>
        /// <param name="targets">The targets to sort.</param>
        /// <param name="farthest">If this should sort by farthest items first.</param>
        public static void SortDistance3([NotNull] this GameObject position, [NotNull] List<Transform> targets, bool farthest = false)
        {
            Sorter3.Set(position, farthest);
            targets.Sort(Sorter3);
        }
        
        /// <summary>
        /// Sort targets from a position across all axes. This version will produce garbage, and it is recommended to use an inplace method instead.
        /// </summary>
        /// <param name="position">The position to sort in relation to.</param>
        /// <param name="targets">The targets to sort.</param>
        /// <param name="farthest">If this should sort by farthest items first.</param>
        public static Transform[] SortDistance3([NotNull] this GameObject position, [NotNull] IEnumerable<Transform> targets, bool farthest = false)
        {
            Sorter3.Set(position, farthest);
            return targets.OrderBy(x => x, Sorter3).ToArray();
        }
        
        /// <summary>
        /// Sort targets from a position across all axes.
        /// </summary>
        /// <param name="position">The position to sort in relation to.</param>
        /// <param name="targets">The targets to sort.</param>
        /// <param name="farthest">If this should sort by farthest items first.</param>
        public static void SortDistance3<T>([NotNull] this GameObject position, [NotNull] T[] targets, bool farthest = false) where T : Component
        {
            Sorter3.Set(position, farthest);
            Array.Sort(targets, Sorter3);
        }
        
        /// <summary>
        /// Sort targets from a position across all axes.
        /// </summary>
        /// <param name="position">The position to sort in relation to.</param>
        /// <param name="targets">The targets to sort.</param>
        /// <param name="farthest">If this should sort by farthest items first.</param>
        public static void SortDistance3<T>([NotNull] this GameObject position, [NotNull] List<T> targets, bool farthest = false) where T : Component
        {
            Sorter3.Set(position, farthest);
            targets.Sort(Sorter3);
        }
        
        /// <summary>
        /// Sort targets from a position across all axes. This version will produce garbage, and it is recommended to use an inplace method instead.
        /// </summary>
        /// <param name="position">The position to sort in relation to.</param>
        /// <param name="targets">The targets to sort.</param>
        /// <param name="farthest">If this should sort by farthest items first.</param>
        public static T[] SortDistance3<T>([NotNull] this GameObject position, [NotNull] IEnumerable<T> targets, bool farthest = false) where T : Component
        {
            Sorter3.Set(position, farthest);
            return targets.OrderBy(x => x, Sorter3).ToArray();
        }
        
        /// <summary>
        /// Sort targets from a position across all axes.
        /// </summary>
        /// <param name="position">The position to sort in relation to.</param>
        /// <param name="targets">The targets to sort.</param>
        /// <param name="farthest">If this should sort by farthest items first.</param>
        public static void SortDistance3([NotNull] this GameObject position, [NotNull] GameObject[] targets, bool farthest = false)
        {
            Sorter3.Set(position, farthest);
            Array.Sort(targets, Sorter3);
        }
        
        /// <summary>
        /// Sort targets from a position across all axes.
        /// </summary>
        /// <param name="position">The position to sort in relation to.</param>
        /// <param name="targets">The targets to sort.</param>
        /// <param name="farthest">If this should sort by farthest items first.</param>
        public static void SortDistance3([NotNull] this GameObject position, [NotNull] List<GameObject> targets, bool farthest = false)
        {
            Sorter3.Set(position, farthest);
            targets.Sort(Sorter3);
        }
        
        /// <summary>
        /// Sort targets from a position across all axes. This version will produce garbage, and it is recommended to use an inplace method instead.
        /// </summary>
        /// <param name="position">The position to sort in relation to.</param>
        /// <param name="targets">The targets to sort.</param>
        /// <param name="farthest">If this should sort by farthest items first.</param>
        public static GameObject[] SortDistance3([NotNull] this GameObject position, [NotNull] IEnumerable<GameObject> targets, bool farthest = false)
        {
            Sorter3.Set(position, farthest);
            return targets.OrderBy(x => x, Sorter3).ToArray();
        }
    }
}