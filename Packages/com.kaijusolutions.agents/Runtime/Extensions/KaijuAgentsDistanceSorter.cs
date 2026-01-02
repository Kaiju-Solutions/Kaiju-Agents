using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using UnityEngine;

namespace KaijuSolutions.Agents.Extensions
{
    /// <summary>
    /// Comparer class to sort by distance along the X and Z axes. Used in the extension methods found in <see cref="KaijuAgentsSortDistance"/>.
    /// </summary>
    public sealed class KaijuAgentsDistanceSorter : IComparer<Vector2>, IComparer<Vector3>, IComparer<Transform>, IComparer<Component>, IComparer<GameObject>
    {
        /// <summary>
        /// The position to compare against.
        /// </summary>
        public Vector3 Position3
        {
            get => Position.Expand();
            set => Position = value.Flatten();
        }
        
        /// <summary>
        /// The position to compare against. This will also set the forward for angle tie breaking.
        /// </summary>
        public Transform PositionTransform
        {
            set
            {
                Position = value.Flatten();
                Forward = value.forward.Flatten();
            }
        }
        
        /// <summary>
        /// The position to compare against. This will also set the forward for angle tie breaking.
        /// </summary>
        public Component PositionComponent
        {
            set => PositionTransform = value.transform;
        }
        
        /// <summary>
        /// The position to compare against. This will also set the forward for angle tie breaking.
        /// </summary>
        public GameObject PositionGameObject
        {
            set => PositionTransform = value.transform;
        }
        
        /// <summary>
        /// The forward direction to break ties on.
        /// </summary>
        public Vector3? Forward3
        {
            get => Forward?.Expand() ?? Position3;
            set => Forward = value?.Flatten();
        }
        
        /// <summary>
        /// The forward direction to break ties on.
        /// </summary>
        public Transform ForwardTransform
        {
            set => Forward = value == null ? value.forward : null;
        }
        
        /// <summary>
        /// The forward direction to break ties on.
        /// </summary>
        public Component ForwardComponent
        {
            set => ForwardTransform = value.transform;
        }
        
        /// <summary>
        /// The forward direction to break ties on.
        /// </summary>
        public Component ForwardGameObject
        {
            set => ForwardTransform = value.transform;
        }
        
        /// <summary>
        /// The position to compare against.
        /// </summary>
        public Vector2 Position;
        
        /// <summary>
        /// If this should sort by farthest items first.
        /// </summary>
        public bool Farthest;
        
        /// <summary>
        /// How to break ties based on angle.
        /// </summary>
        public KaijuAngleSortMode? Mode;
        
        /// <summary>
        /// The forward direction to break ties on.
        /// </summary>
        public Vector2? Forward;
        
        /// <summary>
        /// Create the sorter.
        /// </summary>
        public KaijuAgentsDistanceSorter()
        {
            Set(Vector2.zero);
        }
        
        /// <summary>
        /// Create the sorter.
        /// </summary>
        /// <param name="position">The position to compare against.</param>
        /// <param name="farthest">If this should sort by farthest items first.</param>
        /// <param name="mode">How to break ties based on angle.</param>
        /// <param name="forward">The forward direction to break ties on.</param>
        public KaijuAgentsDistanceSorter(Vector2 position, bool farthest = false, KaijuAngleSortMode? mode = null, Vector2? forward = null)
        {
            Set(position, farthest, mode, forward);
        }
        
        /// <summary>
        /// Create the sorter.
        /// </summary>
        /// <param name="position">The position to compare against.</param>
        /// <param name="farthest">If this should sort by farthest items first.</param>
        /// <param name="mode">How to break ties based on angle.</param>
        /// <param name="forward">The forward direction to break ties on.</param>
        public KaijuAgentsDistanceSorter(Vector3 position, bool farthest = false, KaijuAngleSortMode? mode = null, Vector2? forward = null)
        {
            Set(position, farthest, mode, forward);
        }
        
        /// <summary>
        /// Create the sorter.
        /// </summary>
        /// <param name="position">The position to compare against.</param>
        /// <param name="farthest">If this should sort by farthest items first.</param>
        /// <param name="mode">How to break ties based on angle.</param>
        /// <param name="forward">The forward direction to break ties on.</param>
        public KaijuAgentsDistanceSorter([NotNull] Transform position, bool farthest = false, KaijuAngleSortMode? mode = null, Vector2? forward = null)
        {
            Set(position, farthest, mode, forward);
        }
        
        /// <summary>
        /// Create the sorter.
        /// </summary>
        /// <param name="position">The position to compare against.</param>
        /// <param name="farthest">If this should sort by farthest items first.</param>
        /// <param name="mode">How to break ties based on angle.</param>
        /// <param name="forward">The forward direction to break ties on.</param>
        public KaijuAgentsDistanceSorter([NotNull] Component position, bool farthest = false, KaijuAngleSortMode? mode = null, Vector2? forward = null)
        {
            Set(position, farthest, mode, forward);
        }
        
        /// <summary>
        /// Create the sorter.
        /// </summary>
        /// <param name="position">The position to compare against.</param>
        /// <param name="farthest">If this should sort by farthest items first.</param>
        /// <param name="mode">How to break ties based on angle.</param>
        /// <param name="forward">The forward direction to break ties on.</param>
        public KaijuAgentsDistanceSorter([NotNull] GameObject position, bool farthest = false, KaijuAngleSortMode? mode = null, Vector2? forward = null)
        {
            Set(position, farthest, mode, forward);
        }
        
        /// <summary>
        /// Set values for the sorter.
        /// </summary>
        /// <param name="position">The position to compare against.</param>
        /// <param name="farthest">If this should sort by farthest items first.</param>
        /// <param name="mode">How to break ties based on angle.</param>
        /// <param name="forward">The forward direction to break ties on.</param>
        public void Set(Vector2 position, bool farthest = false, KaijuAngleSortMode? mode = null, Vector2? forward = null)
        {
            Position = position;
            Farthest = farthest;
            Mode = mode;
            Forward = forward;
        }
        
        /// <summary>
        /// Set values for the sorter.
        /// </summary>
        /// <param name="position">The position to compare against.</param>
        /// <param name="farthest">If this should sort by farthest items first.</param>
        /// <param name="mode">How to break ties based on angle.</param>
        /// <param name="forward">The forward direction to break ties on.</param>
        public void Set(Vector3 position, bool farthest = false, KaijuAngleSortMode? mode = null, Vector2? forward = null)
        {
            Set(position.Flatten(), farthest, mode, forward);
        }
        
        /// <summary>
        /// Set values for the sorter.
        /// </summary>
        /// <param name="position">The position to compare against.</param>
        /// <param name="farthest">If this should sort by farthest items first.</param>
        /// <param name="mode">How to break ties based on angle.</param>
        /// <param name="forward">The forward direction to break ties on.</param>
        public void Set([NotNull] Transform position, bool farthest = false, KaijuAngleSortMode? mode = null, Vector2? forward = null)
        {
            Set(position.Flatten(), farthest, mode, forward);
        }
        
        /// <summary>
        /// Set values for the sorter.
        /// </summary>
        /// <param name="position">The position to compare against.</param>
        /// <param name="farthest">If this should sort by farthest items first.</param>
        /// <param name="mode">How to break ties based on angle.</param>
        /// <param name="forward">The forward direction to break ties on.</param>
        public void Set([NotNull] Component position, bool farthest = false, KaijuAngleSortMode? mode = null, Vector2? forward = null)
        {
            Set(position.Flatten(), farthest, mode, forward);
        }
        
        /// <summary>
        /// Set values for the sorter.
        /// </summary>
        /// <param name="position">The position to compare against.</param>
        /// <param name="farthest">If this should sort by farthest items first.</param>
        /// <param name="mode">How to break ties based on angle.</param>
        /// <param name="forward">The forward direction to break ties on.</param>
        public void Set([NotNull] GameObject position, bool farthest = false, KaijuAngleSortMode? mode = null, Vector2? forward = null)
        {
            Set(position.Flatten(), farthest, mode, forward);
        }
        
        /// <summary>
        /// Compare the two instances.
        /// </summary>
        /// <param name="position">The position to compare against.</param>
        /// <param name="x">The first instance.</param>
        /// <param name="y">The second instance.</param>
        /// <param name="farthest">If this should sort by farthest items first.</param>
        /// <returns>Less than zero if the first instance comes first, zero if they are equal, or greater than zero if the second comes first.</returns>
        public static int CompareDistance(Vector2 position, Vector2 x, Vector2 y, bool farthest = false)
        {
            float a = position.Distance(x);
            float b = position.Distance(y);
            int order = a < b ? -1 : b < a ? 1 : 0;
            return farthest ? -order : order;
        }
        
        /// <summary>
        /// Compare the two instances.
        /// </summary>
        /// <param name="position">The position to compare against.</param>
        /// <param name="x">The first instance.</param>
        /// <param name="y">The second instance.</param>
        /// <param name="farthest">If this should sort by farthest items first.</param>
        /// <returns>Less than zero if the first instance comes first, zero if they are equal, or greater than zero if the second comes first.</returns>
        public static int CompareDistance(Vector2 position, Vector2 x, Vector3 y, bool farthest = false) => CompareDistance(position, x, y.Flatten(), farthest);
        
        /// <summary>
        /// Compare the two instances.
        /// </summary>
        /// <param name="position">The position to compare against.</param>
        /// <param name="x">The first instance.</param>
        /// <param name="y">The second instance.</param>
        /// <param name="farthest">If this should sort by farthest items first.</param>
        /// <returns>Less than zero if the first instance comes first, zero if they are equal, or greater than zero if the second comes first.</returns>
        public static int CompareDistance(Vector2 position, Vector2 x, [NotNull] Transform y, bool farthest = false) => CompareDistance(position, x, y.Flatten(), farthest);
        
        /// <summary>
        /// Compare the two instances.
        /// </summary>
        /// <param name="position">The position to compare against.</param>
        /// <param name="x">The first instance.</param>
        /// <param name="y">The second instance.</param>
        /// <param name="farthest">If this should sort by farthest items first.</param>
        /// <returns>Less than zero if the first instance comes first, zero if they are equal, or greater than zero if the second comes first.</returns>
        public static int CompareDistance(Vector2 position, Vector2 x, [NotNull] Component y, bool farthest = false) => CompareDistance(position, x, y.Flatten(), farthest);
        
        /// <summary>
        /// Compare the two instances.
        /// </summary>
        /// <param name="position">The position to compare against.</param>
        /// <param name="x">The first instance.</param>
        /// <param name="y">The second instance.</param>
        /// <param name="farthest">If this should sort by farthest items first.</param>
        /// <returns>Less than zero if the first instance comes first, zero if they are equal, or greater than zero if the second comes first.</returns>
        public static int CompareDistance(Vector2 position, Vector2 x, [NotNull] GameObject y, bool farthest = false) => CompareDistance(position, x, y.Flatten(), farthest);
        
        /// <summary>
        /// Compare the two instances.
        /// </summary>
        /// <param name="position">The position to compare against.</param>
        /// <param name="x">The first instance.</param>
        /// <param name="y">The second instance.</param>
        /// <param name="farthest">If this should sort by farthest items first.</param>
        /// <returns>Less than zero if the first instance comes first, zero if they are equal, or greater than zero if the second comes first.</returns>
        public static int CompareDistance(Vector2 position, Vector3 x, Vector2 y, bool farthest = false) => CompareDistance(position, x.Flatten(), y, farthest);
        
        /// <summary>
        /// Compare the two instances.
        /// </summary>
        /// <param name="position">The position to compare against.</param>
        /// <param name="x">The first instance.</param>
        /// <param name="y">The second instance.</param>
        /// <param name="farthest">If this should sort by farthest items first.</param>
        /// <returns>Less than zero if the first instance comes first, zero if they are equal, or greater than zero if the second comes first.</returns>
        public static int CompareDistance(Vector2 position, Vector3 x, Vector3 y, bool farthest = false) => CompareDistance(position, x.Flatten(), y.Flatten(), farthest);
        
        /// <summary>
        /// Compare the two instances.
        /// </summary>
        /// <param name="position">The position to compare against.</param>
        /// <param name="x">The first instance.</param>
        /// <param name="y">The second instance.</param>
        /// <param name="farthest">If this should sort by farthest items first.</param>
        /// <returns>Less than zero if the first instance comes first, zero if they are equal, or greater than zero if the second comes first.</returns>
        public static int CompareDistance(Vector2 position, Vector3 x, [NotNull] Transform y, bool farthest = false) => CompareDistance(position, x.Flatten(), y.Flatten(), farthest);
        
        /// <summary>
        /// Compare the two instances.
        /// </summary>
        /// <param name="position">The position to compare against.</param>
        /// <param name="x">The first instance.</param>
        /// <param name="y">The second instance.</param>
        /// <param name="farthest">If this should sort by farthest items first.</param>
        /// <returns>Less than zero if the first instance comes first, zero if they are equal, or greater than zero if the second comes first.</returns>
        public static int CompareDistance(Vector2 position, Vector3 x, [NotNull] Component y, bool farthest = false) => CompareDistance(position, x.Flatten(), y.Flatten(), farthest);
        
        /// <summary>
        /// Compare the two instances.
        /// </summary>
        /// <param name="position">The position to compare against.</param>
        /// <param name="x">The first instance.</param>
        /// <param name="y">The second instance.</param>
        /// <param name="farthest">If this should sort by farthest items first.</param>
        /// <returns>Less than zero if the first instance comes first, zero if they are equal, or greater than zero if the second comes first.</returns>
        public static int CompareDistance(Vector2 position, Vector3 x, [NotNull] GameObject y, bool farthest = false) => CompareDistance(position, x.Flatten(), y.Flatten(), farthest);
        
        /// <summary>
        /// Compare the two instances.
        /// </summary>
        /// <param name="position">The position to compare against.</param>
        /// <param name="x">The first instance.</param>
        /// <param name="y">The second instance.</param>
        /// <param name="farthest">If this should sort by farthest items first.</param>
        /// <returns>Less than zero if the first instance comes first, zero if they are equal, or greater than zero if the second comes first.</returns>
        public static int CompareDistance(Vector2 position, [NotNull] Transform x, Vector2 y, bool farthest = false) => CompareDistance(position, x.Flatten(), y, farthest);
        
        /// <summary>
        /// Compare the two instances.
        /// </summary>
        /// <param name="position">The position to compare against.</param>
        /// <param name="x">The first instance.</param>
        /// <param name="y">The second instance.</param>
        /// <param name="farthest">If this should sort by farthest items first.</param>
        /// <returns>Less than zero if the first instance comes first, zero if they are equal, or greater than zero if the second comes first.</returns>
        public static int CompareDistance(Vector2 position, [NotNull] Transform x, Vector3 y, bool farthest = false) => CompareDistance(position, x.Flatten(), y.Flatten(), farthest);
        
        /// <summary>
        /// Compare the two instances.
        /// </summary>
        /// <param name="position">The position to compare against.</param>
        /// <param name="x">The first instance.</param>
        /// <param name="y">The second instance.</param>
        /// <param name="farthest">If this should sort by farthest items first.</param>
        /// <returns>Less than zero if the first instance comes first, zero if they are equal, or greater than zero if the second comes first.</returns>
        public static int CompareDistance(Vector2 position, [NotNull] Transform x, [NotNull] Transform y, bool farthest = false) => CompareDistance(position, x.Flatten(), y.Flatten(), farthest);
        
        /// <summary>
        /// Compare the two instances.
        /// </summary>
        /// <param name="position">The position to compare against.</param>
        /// <param name="x">The first instance.</param>
        /// <param name="y">The second instance.</param>
        /// <param name="farthest">If this should sort by farthest items first.</param>
        /// <returns>Less than zero if the first instance comes first, zero if they are equal, or greater than zero if the second comes first.</returns>
        public static int CompareDistance(Vector2 position, [NotNull] Transform x, [NotNull] Component y, bool farthest = false) => CompareDistance(position, x.Flatten(), y.Flatten(), farthest);
        
        /// <summary>
        /// Compare the two instances.
        /// </summary>
        /// <param name="position">The position to compare against.</param>
        /// <param name="x">The first instance.</param>
        /// <param name="y">The second instance.</param>
        /// <param name="farthest">If this should sort by farthest items first.</param>
        /// <returns>Less than zero if the first instance comes first, zero if they are equal, or greater than zero if the second comes first.</returns>
        public static int CompareDistance(Vector2 position, [NotNull] Transform x, [NotNull] GameObject y, bool farthest = false) => CompareDistance(position, x.Flatten(), y.Flatten(), farthest);
        
        /// <summary>
        /// Compare the two instances.
        /// </summary>
        /// <param name="position">The position to compare against.</param>
        /// <param name="x">The first instance.</param>
        /// <param name="y">The second instance.</param>
        /// <param name="farthest">If this should sort by farthest items first.</param>
        /// <returns>Less than zero if the first instance comes first, zero if they are equal, or greater than zero if the second comes first.</returns>
        public static int CompareDistance(Vector2 position, [NotNull] Component x, Vector2 y, bool farthest = false) => CompareDistance(position, x.Flatten(), y, farthest);
        
        /// <summary>
        /// Compare the two instances.
        /// </summary>
        /// <param name="position">The position to compare against.</param>
        /// <param name="x">The first instance.</param>
        /// <param name="y">The second instance.</param>
        /// <param name="farthest">If this should sort by farthest items first.</param>
        /// <returns>Less than zero if the first instance comes first, zero if they are equal, or greater than zero if the second comes first.</returns>
        public static int CompareDistance(Vector2 position, [NotNull] Component x, Vector3 y, bool farthest = false) => CompareDistance(position, x.Flatten(), y.Flatten(), farthest);
        
        /// <summary>
        /// Compare the two instances.
        /// </summary>
        /// <param name="position">The position to compare against.</param>
        /// <param name="x">The first instance.</param>
        /// <param name="y">The second instance.</param>
        /// <param name="farthest">If this should sort by farthest items first.</param>
        /// <returns>Less than zero if the first instance comes first, zero if they are equal, or greater than zero if the second comes first.</returns>
        public static int CompareDistance(Vector2 position, [NotNull] Component x, [NotNull] Transform y, bool farthest = false) => CompareDistance(position, x.Flatten(), y.Flatten(), farthest);
        
        /// <summary>
        /// Compare the two instances.
        /// </summary>
        /// <param name="position">The position to compare against.</param>
        /// <param name="x">The first instance.</param>
        /// <param name="y">The second instance.</param>
        /// <param name="farthest">If this should sort by farthest items first.</param>
        /// <returns>Less than zero if the first instance comes first, zero if they are equal, or greater than zero if the second comes first.</returns>
        public static int CompareDistance(Vector2 position, [NotNull] Component x, [NotNull] Component y, bool farthest = false) => CompareDistance(position, x.Flatten(), y.Flatten(), farthest);
        
        /// <summary>
        /// Compare the two instances.
        /// </summary>
        /// <param name="position">The position to compare against.</param>
        /// <param name="x">The first instance.</param>
        /// <param name="y">The second instance.</param>
        /// <param name="farthest">If this should sort by farthest items first.</param>
        /// <returns>Less than zero if the first instance comes first, zero if they are equal, or greater than zero if the second comes first.</returns>
        public static int CompareDistance(Vector2 position, [NotNull] Component x, [NotNull] GameObject y, bool farthest = false) => CompareDistance(position, x.Flatten(), y.Flatten(), farthest);
        
        /// <summary>
        /// Compare the two instances.
        /// </summary>
        /// <param name="position">The position to compare against.</param>
        /// <param name="x">The first instance.</param>
        /// <param name="y">The second instance.</param>
        /// <param name="farthest">If this should sort by farthest items first.</param>
        /// <returns>Less than zero if the first instance comes first, zero if they are equal, or greater than zero if the second comes first.</returns>
        public static int CompareDistance(Vector2 position, [NotNull] GameObject x, Vector2 y, bool farthest = false) => CompareDistance(position, x.Flatten(), y, farthest);
        
        /// <summary>
        /// Compare the two instances.
        /// </summary>
        /// <param name="position">The position to compare against.</param>
        /// <param name="x">The first instance.</param>
        /// <param name="y">The second instance.</param>
        /// <param name="farthest">If this should sort by farthest items first.</param>
        /// <returns>Less than zero if the first instance comes first, zero if they are equal, or greater than zero if the second comes first.</returns>
        public static int CompareDistance(Vector2 position, [NotNull] GameObject x, Vector3 y, bool farthest = false) => CompareDistance(position, x.Flatten(), y.Flatten(), farthest);
        
        /// <summary>
        /// Compare the two instances.
        /// </summary>
        /// <param name="position">The position to compare against.</param>
        /// <param name="x">The first instance.</param>
        /// <param name="y">The second instance.</param>
        /// <param name="farthest">If this should sort by farthest items first.</param>
        /// <returns>Less than zero if the first instance comes first, zero if they are equal, or greater than zero if the second comes first.</returns>
        public static int CompareDistance(Vector2 position, [NotNull] GameObject x, [NotNull] Transform y, bool farthest = false) => CompareDistance(position, x.Flatten(), y.Flatten(), farthest);
        
        /// <summary>
        /// Compare the two instances.
        /// </summary>
        /// <param name="position">The position to compare against.</param>
        /// <param name="x">The first instance.</param>
        /// <param name="y">The second instance.</param>
        /// <param name="farthest">If this should sort by farthest items first.</param>
        /// <returns>Less than zero if the first instance comes first, zero if they are equal, or greater than zero if the second comes first.</returns>
        public static int CompareDistance(Vector2 position, [NotNull] GameObject x, [NotNull] Component y, bool farthest = false) => CompareDistance(position, x.Flatten(), y.Flatten(), farthest);
        
        /// <summary>
        /// Compare the two instances.
        /// </summary>
        /// <param name="position">The position to compare against.</param>
        /// <param name="x">The first instance.</param>
        /// <param name="y">The second instance.</param>
        /// <param name="farthest">If this should sort by farthest items first.</param>
        /// <returns>Less than zero if the first instance comes first, zero if they are equal, or greater than zero if the second comes first.</returns>
        public static int CompareDistance(Vector2 position, [NotNull] GameObject x, [NotNull] GameObject y, bool farthest = false) => CompareDistance(position, x.Flatten(), y.Flatten(), farthest);
        
        /// <summary>
        /// Compare the two instances.
        /// </summary>
        /// <param name="position">The position to compare against.</param>
        /// <param name="x">The first instance.</param>
        /// <param name="y">The second instance.</param>
        /// <param name="farthest">If this should sort by farthest items first.</param>
        /// <returns>Less than zero if the first instance comes first, zero if they are equal, or greater than zero if the second comes first.</returns>
        public static int CompareDistance(Vector3 position, Vector2 x, Vector2 y, bool farthest = false) => CompareDistance(position.Flatten(), x, y, farthest);
        
        /// <summary>
        /// Compare the two instances.
        /// </summary>
        /// <param name="position">The position to compare against.</param>
        /// <param name="x">The first instance.</param>
        /// <param name="y">The second instance.</param>
        /// <param name="farthest">If this should sort by farthest items first.</param>
        /// <returns>Less than zero if the first instance comes first, zero if they are equal, or greater than zero if the second comes first.</returns>
        public static int CompareDistance(Vector3 position, Vector2 x, Vector3 y, bool farthest = false) => CompareDistance(position.Flatten(), x, y.Flatten(), farthest);
        
        /// <summary>
        /// Compare the two instances.
        /// </summary>
        /// <param name="position">The position to compare against.</param>
        /// <param name="x">The first instance.</param>
        /// <param name="y">The second instance.</param>
        /// <param name="farthest">If this should sort by farthest items first.</param>
        /// <returns>Less than zero if the first instance comes first, zero if they are equal, or greater than zero if the second comes first.</returns>
        public static int CompareDistance(Vector3 position, Vector2 x, [NotNull] Transform y, bool farthest = false) => CompareDistance(position.Flatten(), x, y.Flatten(), farthest);
        
        /// <summary>
        /// Compare the two instances.
        /// </summary>
        /// <param name="position">The position to compare against.</param>
        /// <param name="x">The first instance.</param>
        /// <param name="y">The second instance.</param>
        /// <param name="farthest">If this should sort by farthest items first.</param>
        /// <returns>Less than zero if the first instance comes first, zero if they are equal, or greater than zero if the second comes first.</returns>
        public static int CompareDistance(Vector3 position, Vector2 x, [NotNull] Component y, bool farthest = false) => CompareDistance(position.Flatten(), x, y.Flatten(), farthest);
        
        /// <summary>
        /// Compare the two instances.
        /// </summary>
        /// <param name="position">The position to compare against.</param>
        /// <param name="x">The first instance.</param>
        /// <param name="y">The second instance.</param>
        /// <param name="farthest">If this should sort by farthest items first.</param>
        /// <returns>Less than zero if the first instance comes first, zero if they are equal, or greater than zero if the second comes first.</returns>
        public static int CompareDistance(Vector3 position, Vector2 x, [NotNull] GameObject y, bool farthest = false) => CompareDistance(position.Flatten(), x, y.Flatten(), farthest);
        
        /// <summary>
        /// Compare the two instances.
        /// </summary>
        /// <param name="position">The position to compare against.</param>
        /// <param name="x">The first instance.</param>
        /// <param name="y">The second instance.</param>
        /// <param name="farthest">If this should sort by farthest items first.</param>
        /// <returns>Less than zero if the first instance comes first, zero if they are equal, or greater than zero if the second comes first.</returns>
        public static int CompareDistance(Vector3 position, Vector3 x, Vector2 y, bool farthest = false) => CompareDistance(position.Flatten(), x.Flatten(), y, farthest);
        
        /// <summary>
        /// Compare the two instances.
        /// </summary>
        /// <param name="position">The position to compare against.</param>
        /// <param name="x">The first instance.</param>
        /// <param name="y">The second instance.</param>
        /// <param name="farthest">If this should sort by farthest items first.</param>
        /// <returns>Less than zero if the first instance comes first, zero if they are equal, or greater than zero if the second comes first.</returns>
        public static int CompareDistance(Vector3 position, Vector3 x, Vector3 y, bool farthest = false) => CompareDistance(position.Flatten(), x.Flatten(), y.Flatten(), farthest);
        
        /// <summary>
        /// Compare the two instances.
        /// </summary>
        /// <param name="position">The position to compare against.</param>
        /// <param name="x">The first instance.</param>
        /// <param name="y">The second instance.</param>
        /// <param name="farthest">If this should sort by farthest items first.</param>
        /// <returns>Less than zero if the first instance comes first, zero if they are equal, or greater than zero if the second comes first.</returns>
        public static int CompareDistance(Vector3 position, Vector3 x, [NotNull] Transform y, bool farthest = false) => CompareDistance(position.Flatten(), x.Flatten(), y.Flatten(), farthest);
        
        /// <summary>
        /// Compare the two instances.
        /// </summary>
        /// <param name="position">The position to compare against.</param>
        /// <param name="x">The first instance.</param>
        /// <param name="y">The second instance.</param>
        /// <param name="farthest">If this should sort by farthest items first.</param>
        /// <returns>Less than zero if the first instance comes first, zero if they are equal, or greater than zero if the second comes first.</returns>
        public static int CompareDistance(Vector3 position, Vector3 x, [NotNull] Component y, bool farthest = false) => CompareDistance(position.Flatten(), x.Flatten(), y.Flatten(), farthest);
        
        /// <summary>
        /// Compare the two instances.
        /// </summary>
        /// <param name="position">The position to compare against.</param>
        /// <param name="x">The first instance.</param>
        /// <param name="y">The second instance.</param>
        /// <param name="farthest">If this should sort by farthest items first.</param>
        /// <returns>Less than zero if the first instance comes first, zero if they are equal, or greater than zero if the second comes first.</returns>
        public static int CompareDistance(Vector3 position, Vector3 x, [NotNull] GameObject y, bool farthest = false) => CompareDistance(position.Flatten(), x.Flatten(), y.Flatten(), farthest);
        
        /// <summary>
        /// Compare the two instances.
        /// </summary>
        /// <param name="position">The position to compare against.</param>
        /// <param name="x">The first instance.</param>
        /// <param name="y">The second instance.</param>
        /// <param name="farthest">If this should sort by farthest items first.</param>
        /// <returns>Less than zero if the first instance comes first, zero if they are equal, or greater than zero if the second comes first.</returns>
        public static int CompareDistance(Vector3 position, [NotNull] Transform x, Vector2 y, bool farthest = false) => CompareDistance(position.Flatten(), x.Flatten(), y, farthest);
        
        /// <summary>
        /// Compare the two instances.
        /// </summary>
        /// <param name="position">The position to compare against.</param>
        /// <param name="x">The first instance.</param>
        /// <param name="y">The second instance.</param>
        /// <param name="farthest">If this should sort by farthest items first.</param>
        /// <returns>Less than zero if the first instance comes first, zero if they are equal, or greater than zero if the second comes first.</returns>
        public static int CompareDistance(Vector3 position, [NotNull] Transform x, Vector3 y, bool farthest = false) => CompareDistance(position.Flatten(), x.Flatten(), y.Flatten(), farthest);
        
        /// <summary>
        /// Compare the two instances.
        /// </summary>
        /// <param name="position">The position to compare against.</param>
        /// <param name="x">The first instance.</param>
        /// <param name="y">The second instance.</param>
        /// <param name="farthest">If this should sort by farthest items first.</param>
        /// <returns>Less than zero if the first instance comes first, zero if they are equal, or greater than zero if the second comes first.</returns>
        public static int CompareDistance(Vector3 position, [NotNull] Transform x, [NotNull] Transform y, bool farthest = false) => CompareDistance(position.Flatten(), x.Flatten(), y.Flatten(), farthest);
        
        /// <summary>
        /// Compare the two instances.
        /// </summary>
        /// <param name="position">The position to compare against.</param>
        /// <param name="x">The first instance.</param>
        /// <param name="y">The second instance.</param>
        /// <param name="farthest">If this should sort by farthest items first.</param>
        /// <returns>Less than zero if the first instance comes first, zero if they are equal, or greater than zero if the second comes first.</returns>
        public static int CompareDistance(Vector3 position, [NotNull] Transform x, [NotNull] Component y, bool farthest = false) => CompareDistance(position.Flatten(), x.Flatten(), y.Flatten(), farthest);
        
        /// <summary>
        /// Compare the two instances.
        /// </summary>
        /// <param name="position">The position to compare against.</param>
        /// <param name="x">The first instance.</param>
        /// <param name="y">The second instance.</param>
        /// <param name="farthest">If this should sort by farthest items first.</param>
        /// <returns>Less than zero if the first instance comes first, zero if they are equal, or greater than zero if the second comes first.</returns>
        public static int CompareDistance(Vector3 position, [NotNull] Transform x, [NotNull] GameObject y, bool farthest = false) => CompareDistance(position.Flatten(), x.Flatten(), y.Flatten(), farthest);
        
        /// <summary>
        /// Compare the two instances.
        /// </summary>
        /// <param name="position">The position to compare against.</param>
        /// <param name="x">The first instance.</param>
        /// <param name="y">The second instance.</param>
        /// <param name="farthest">If this should sort by farthest items first.</param>
        /// <returns>Less than zero if the first instance comes first, zero if they are equal, or greater than zero if the second comes first.</returns>
        public static int CompareDistance(Vector3 position, [NotNull] Component x, Vector2 y, bool farthest = false) => CompareDistance(position.Flatten(), x.Flatten(), y, farthest);
        
        /// <summary>
        /// Compare the two instances.
        /// </summary>
        /// <param name="position">The position to compare against.</param>
        /// <param name="x">The first instance.</param>
        /// <param name="y">The second instance.</param>
        /// <param name="farthest">If this should sort by farthest items first.</param>
        /// <returns>Less than zero if the first instance comes first, zero if they are equal, or greater than zero if the second comes first.</returns>
        public static int CompareDistance(Vector3 position, [NotNull] Component x, Vector3 y, bool farthest = false) => CompareDistance(position.Flatten(), x.Flatten(), y.Flatten(), farthest);
        
        /// <summary>
        /// Compare the two instances.
        /// </summary>
        /// <param name="position">The position to compare against.</param>
        /// <param name="x">The first instance.</param>
        /// <param name="y">The second instance.</param>
        /// <param name="farthest">If this should sort by farthest items first.</param>
        /// <returns>Less than zero if the first instance comes first, zero if they are equal, or greater than zero if the second comes first.</returns>
        public static int CompareDistance(Vector3 position, [NotNull] Component x, [NotNull] Transform y, bool farthest = false) => CompareDistance(position.Flatten(), x.Flatten(), y.Flatten(), farthest);
        
        /// <summary>
        /// Compare the two instances.
        /// </summary>
        /// <param name="position">The position to compare against.</param>
        /// <param name="x">The first instance.</param>
        /// <param name="y">The second instance.</param>
        /// <param name="farthest">If this should sort by farthest items first.</param>
        /// <returns>Less than zero if the first instance comes first, zero if they are equal, or greater than zero if the second comes first.</returns>
        public static int CompareDistance(Vector3 position, [NotNull] Component x, [NotNull] Component y, bool farthest = false) => CompareDistance(position.Flatten(), x.Flatten(), y.Flatten(), farthest);
        
        /// <summary>
        /// Compare the two instances.
        /// </summary>
        /// <param name="position">The position to compare against.</param>
        /// <param name="x">The first instance.</param>
        /// <param name="y">The second instance.</param>
        /// <param name="farthest">If this should sort by farthest items first.</param>
        /// <returns>Less than zero if the first instance comes first, zero if they are equal, or greater than zero if the second comes first.</returns>
        public static int CompareDistance(Vector3 position, [NotNull] Component x, [NotNull] GameObject y, bool farthest = false) => CompareDistance(position.Flatten(), x.Flatten(), y.Flatten(), farthest);
        
        /// <summary>
        /// Compare the two instances.
        /// </summary>
        /// <param name="position">The position to compare against.</param>
        /// <param name="x">The first instance.</param>
        /// <param name="y">The second instance.</param>
        /// <param name="farthest">If this should sort by farthest items first.</param>
        /// <returns>Less than zero if the first instance comes first, zero if they are equal, or greater than zero if the second comes first.</returns>
        public static int CompareDistance(Vector3 position, [NotNull] GameObject x, Vector2 y, bool farthest = false) => CompareDistance(position.Flatten(), x.Flatten(), y, farthest);
        
        /// <summary>
        /// Compare the two instances.
        /// </summary>
        /// <param name="position">The position to compare against.</param>
        /// <param name="x">The first instance.</param>
        /// <param name="y">The second instance.</param>
        /// <param name="farthest">If this should sort by farthest items first.</param>
        /// <returns>Less than zero if the first instance comes first, zero if they are equal, or greater than zero if the second comes first.</returns>
        public static int CompareDistance(Vector3 position, [NotNull] GameObject x, Vector3 y, bool farthest = false) => CompareDistance(position.Flatten(), x.Flatten(), y.Flatten(), farthest);
        
        /// <summary>
        /// Compare the two instances.
        /// </summary>
        /// <param name="position">The position to compare against.</param>
        /// <param name="x">The first instance.</param>
        /// <param name="y">The second instance.</param>
        /// <param name="farthest">If this should sort by farthest items first.</param>
        /// <returns>Less than zero if the first instance comes first, zero if they are equal, or greater than zero if the second comes first.</returns>
        public static int CompareDistance(Vector3 position, [NotNull] GameObject x, [NotNull] Transform y, bool farthest = false) => CompareDistance(position.Flatten(), x.Flatten(), y.Flatten(), farthest);
        
        /// <summary>
        /// Compare the two instances.
        /// </summary>
        /// <param name="position">The position to compare against.</param>
        /// <param name="x">The first instance.</param>
        /// <param name="y">The second instance.</param>
        /// <param name="farthest">If this should sort by farthest items first.</param>
        /// <returns>Less than zero if the first instance comes first, zero if they are equal, or greater than zero if the second comes first.</returns>
        public static int CompareDistance(Vector3 position, [NotNull] GameObject x, [NotNull] Component y, bool farthest = false) => CompareDistance(position.Flatten(), x.Flatten(), y.Flatten(), farthest);
        
        /// <summary>
        /// Compare the two instances.
        /// </summary>
        /// <param name="position">The position to compare against.</param>
        /// <param name="x">The first instance.</param>
        /// <param name="y">The second instance.</param>
        /// <param name="farthest">If this should sort by farthest items first.</param>
        /// <returns>Less than zero if the first instance comes first, zero if they are equal, or greater than zero if the second comes first.</returns>
        public static int CompareDistance(Vector3 position, [NotNull] GameObject x, [NotNull] GameObject y, bool farthest = false) => CompareDistance(position.Flatten(), x.Flatten(), y.Flatten(), farthest);
        
        /// <summary>
        /// Compare the two instances.
        /// </summary>
        /// <param name="position">The position to compare against.</param>
        /// <param name="x">The first instance.</param>
        /// <param name="y">The second instance.</param>
        /// <param name="farthest">If this should sort by farthest items first.</param>
        /// <returns>Less than zero if the first instance comes first, zero if they are equal, or greater than zero if the second comes first.</returns>
        public static int CompareDistance([NotNull] Transform position, Vector2 x, Vector2 y, bool farthest = false) => CompareDistance(position.Flatten(), x, y, farthest);
        
        /// <summary>
        /// Compare the two instances.
        /// </summary>
        /// <param name="position">The position to compare against.</param>
        /// <param name="x">The first instance.</param>
        /// <param name="y">The second instance.</param>
        /// <param name="farthest">If this should sort by farthest items first.</param>
        /// <returns>Less than zero if the first instance comes first, zero if they are equal, or greater than zero if the second comes first.</returns>
        public static int CompareDistance([NotNull] Transform position, Vector2 x, Vector3 y, bool farthest = false) => CompareDistance(position.Flatten(), x, y.Flatten(), farthest);
        
        /// <summary>
        /// Compare the two instances.
        /// </summary>
        /// <param name="position">The position to compare against.</param>
        /// <param name="x">The first instance.</param>
        /// <param name="y">The second instance.</param>
        /// <param name="farthest">If this should sort by farthest items first.</param>
        /// <returns>Less than zero if the first instance comes first, zero if they are equal, or greater than zero if the second comes first.</returns>
        public static int CompareDistance([NotNull] Transform position, Vector2 x, [NotNull] Transform y, bool farthest = false) => CompareDistance(position.Flatten(), x, y.Flatten(), farthest);
        
        /// <summary>
        /// Compare the two instances.
        /// </summary>
        /// <param name="position">The position to compare against.</param>
        /// <param name="x">The first instance.</param>
        /// <param name="y">The second instance.</param>
        /// <param name="farthest">If this should sort by farthest items first.</param>
        /// <returns>Less than zero if the first instance comes first, zero if they are equal, or greater than zero if the second comes first.</returns>
        public static int CompareDistance([NotNull] Transform position, Vector2 x, [NotNull] Component y, bool farthest = false) => CompareDistance(position.Flatten(), x, y.Flatten(), farthest);
        
        /// <summary>
        /// Compare the two instances.
        /// </summary>
        /// <param name="position">The position to compare against.</param>
        /// <param name="x">The first instance.</param>
        /// <param name="y">The second instance.</param>
        /// <param name="farthest">If this should sort by farthest items first.</param>
        /// <returns>Less than zero if the first instance comes first, zero if they are equal, or greater than zero if the second comes first.</returns>
        public static int CompareDistance([NotNull] Transform position, Vector2 x, [NotNull] GameObject y, bool farthest = false) => CompareDistance(position.Flatten(), x, y.Flatten(), farthest);
        
        /// <summary>
        /// Compare the two instances.
        /// </summary>
        /// <param name="position">The position to compare against.</param>
        /// <param name="x">The first instance.</param>
        /// <param name="y">The second instance.</param>
        /// <param name="farthest">If this should sort by farthest items first.</param>
        /// <returns>Less than zero if the first instance comes first, zero if they are equal, or greater than zero if the second comes first.</returns>
        public static int CompareDistance([NotNull] Transform position, Vector3 x, Vector2 y, bool farthest = false) => CompareDistance(position.Flatten(), x.Flatten(), y, farthest);
        
        /// <summary>
        /// Compare the two instances.
        /// </summary>
        /// <param name="position">The position to compare against.</param>
        /// <param name="x">The first instance.</param>
        /// <param name="y">The second instance.</param>
        /// <param name="farthest">If this should sort by farthest items first.</param>
        /// <returns>Less than zero if the first instance comes first, zero if they are equal, or greater than zero if the second comes first.</returns>
        public static int CompareDistance([NotNull] Transform position, Vector3 x, Vector3 y, bool farthest = false) => CompareDistance(position.Flatten(), x.Flatten(), y.Flatten(), farthest);
        
        /// <summary>
        /// Compare the two instances.
        /// </summary>
        /// <param name="position">The position to compare against.</param>
        /// <param name="x">The first instance.</param>
        /// <param name="y">The second instance.</param>
        /// <param name="farthest">If this should sort by farthest items first.</param>
        /// <returns>Less than zero if the first instance comes first, zero if they are equal, or greater than zero if the second comes first.</returns>
        public static int CompareDistance([NotNull] Transform position, Vector3 x, [NotNull] Transform y, bool farthest = false) => CompareDistance(position.Flatten(), x.Flatten(), y.Flatten(), farthest);
        
        /// <summary>
        /// Compare the two instances.
        /// </summary>
        /// <param name="position">The position to compare against.</param>
        /// <param name="x">The first instance.</param>
        /// <param name="y">The second instance.</param>
        /// <param name="farthest">If this should sort by farthest items first.</param>
        /// <returns>Less than zero if the first instance comes first, zero if they are equal, or greater than zero if the second comes first.</returns>
        public static int CompareDistance([NotNull] Transform position, Vector3 x, [NotNull] Component y, bool farthest = false) => CompareDistance(position.Flatten(), x.Flatten(), y.Flatten(), farthest);
        
        /// <summary>
        /// Compare the two instances.
        /// </summary>
        /// <param name="position">The position to compare against.</param>
        /// <param name="x">The first instance.</param>
        /// <param name="y">The second instance.</param>
        /// <param name="farthest">If this should sort by farthest items first.</param>
        /// <returns>Less than zero if the first instance comes first, zero if they are equal, or greater than zero if the second comes first.</returns>
        public static int CompareDistance([NotNull] Transform position, Vector3 x, [NotNull] GameObject y, bool farthest = false) => CompareDistance(position.Flatten(), x.Flatten(), y.Flatten(), farthest);
        
        /// <summary>
        /// Compare the two instances.
        /// </summary>
        /// <param name="position">The position to compare against.</param>
        /// <param name="x">The first instance.</param>
        /// <param name="y">The second instance.</param>
        /// <param name="farthest">If this should sort by farthest items first.</param>
        /// <returns>Less than zero if the first instance comes first, zero if they are equal, or greater than zero if the second comes first.</returns>
        public static int CompareDistance([NotNull] Transform position, [NotNull] Transform x, Vector2 y, bool farthest = false) => CompareDistance(position.Flatten(), x.Flatten(), y, farthest);
        /// <summary>
        /// Compare the two instances.
        /// </summary>
        /// <param name="position">The position to compare against.</param>
        /// <param name="x">The first instance.</param>
        /// <param name="y">The second instance.</param>
        /// <param name="farthest">If this should sort by farthest items first.</param>
        /// <returns>Less than zero if the first instance comes first, zero if they are equal, or greater than zero if the second comes first.</returns>
        public static int CompareDistance([NotNull] Transform position, [NotNull] Transform x, Vector3 y, bool farthest = false) => CompareDistance(position.Flatten(), x.Flatten(), y.Flatten(), farthest);
        
        /// <summary>
        /// Compare the two instances.
        /// </summary>
        /// <param name="position">The position to compare against.</param>
        /// <param name="x">The first instance.</param>
        /// <param name="y">The second instance.</param>
        /// <param name="farthest">If this should sort by farthest items first.</param>
        /// <returns>Less than zero if the first instance comes first, zero if they are equal, or greater than zero if the second comes first.</returns>
        public static int CompareDistance([NotNull] Transform position, [NotNull] Transform x, [NotNull] Transform y, bool farthest = false) => CompareDistance(position.Flatten(), x.Flatten(), y.Flatten(), farthest);
        
        /// <summary>
        /// Compare the two instances.
        /// </summary>
        /// <param name="position">The position to compare against.</param>
        /// <param name="x">The first instance.</param>
        /// <param name="y">The second instance.</param>
        /// <param name="farthest">If this should sort by farthest items first.</param>
        /// <returns>Less than zero if the first instance comes first, zero if they are equal, or greater than zero if the second comes first.</returns>
        public static int CompareDistance([NotNull] Transform position, [NotNull] Transform x, [NotNull] Component y, bool farthest = false) => CompareDistance(position.Flatten(), x.Flatten(), y.Flatten(), farthest);
        
        /// <summary>
        /// Compare the two instances.
        /// </summary>
        /// <param name="position">The position to compare against.</param>
        /// <param name="x">The first instance.</param>
        /// <param name="y">The second instance.</param>
        /// <param name="farthest">If this should sort by farthest items first.</param>
        /// <returns>Less than zero if the first instance comes first, zero if they are equal, or greater than zero if the second comes first.</returns>
        public static int CompareDistance([NotNull] Transform position, [NotNull] Transform x, [NotNull] GameObject y, bool farthest = false) => CompareDistance(position.Flatten(), x.Flatten(), y.Flatten(), farthest);
        
        /// <summary>
        /// Compare the two instances.
        /// </summary>
        /// <param name="position">The position to compare against.</param>
        /// <param name="x">The first instance.</param>
        /// <param name="y">The second instance.</param>
        /// <param name="farthest">If this should sort by farthest items first.</param>
        /// <returns>Less than zero if the first instance comes first, zero if they are equal, or greater than zero if the second comes first.</returns>
        public static int CompareDistance([NotNull] Transform position, [NotNull] Component x, Vector2 y, bool farthest = false) => CompareDistance(position.Flatten(), x.Flatten(), y, farthest);
        
        /// <summary>
        /// Compare the two instances.
        /// </summary>
        /// <param name="position">The position to compare against.</param>
        /// <param name="x">The first instance.</param>
        /// <param name="y">The second instance.</param>
        /// <param name="farthest">If this should sort by farthest items first.</param>
        /// <returns>Less than zero if the first instance comes first, zero if they are equal, or greater than zero if the second comes first.</returns>
        public static int CompareDistance([NotNull] Transform position, [NotNull] Component x, Vector3 y, bool farthest = false) => CompareDistance(position.Flatten(), x.Flatten(), y.Flatten(), farthest);
        
        /// <summary>
        /// Compare the two instances.
        /// </summary>
        /// <param name="position">The position to compare against.</param>
        /// <param name="x">The first instance.</param>
        /// <param name="y">The second instance.</param>
        /// <param name="farthest">If this should sort by farthest items first.</param>
        /// <returns>Less than zero if the first instance comes first, zero if they are equal, or greater than zero if the second comes first.</returns>
        public static int CompareDistance([NotNull] Transform position, [NotNull] Component x, [NotNull] Transform y, bool farthest = false) => CompareDistance(position.Flatten(), x.Flatten(), y.Flatten(), farthest);
        
        /// <summary>
        /// Compare the two instances.
        /// </summary>
        /// <param name="position">The position to compare against.</param>
        /// <param name="x">The first instance.</param>
        /// <param name="y">The second instance.</param>
        /// <param name="farthest">If this should sort by farthest items first.</param>
        /// <returns>Less than zero if the first instance comes first, zero if they are equal, or greater than zero if the second comes first.</returns>
        public static int CompareDistance([NotNull] Transform position, [NotNull] Component x, [NotNull] Component y, bool farthest = false) => CompareDistance(position.Flatten(), x.Flatten(), y.Flatten(), farthest);
        
        /// <summary>
        /// Compare the two instances.
        /// </summary>
        /// <param name="position">The position to compare against.</param>
        /// <param name="x">The first instance.</param>
        /// <param name="y">The second instance.</param>
        /// <param name="farthest">If this should sort by farthest items first.</param>
        /// <returns>Less than zero if the first instance comes first, zero if they are equal, or greater than zero if the second comes first.</returns>
        public static int CompareDistance([NotNull] Transform position, [NotNull] Component x, [NotNull] GameObject y, bool farthest = false) => CompareDistance(position.Flatten(), x.Flatten(), y.Flatten(), farthest);
        
        /// <summary>
        /// Compare the two instances.
        /// </summary>
        /// <param name="position">The position to compare against.</param>
        /// <param name="x">The first instance.</param>
        /// <param name="y">The second instance.</param>
        /// <param name="farthest">If this should sort by farthest items first.</param>
        /// <returns>Less than zero if the first instance comes first, zero if they are equal, or greater than zero if the second comes first.</returns>
        public static int CompareDistance([NotNull] Transform position, [NotNull] GameObject x, Vector2 y, bool farthest = false) => CompareDistance(position.Flatten(), x.Flatten(), y, farthest);
        
        /// <summary>
        /// Compare the two instances.
        /// </summary>
        /// <param name="position">The position to compare against.</param>
        /// <param name="x">The first instance.</param>
        /// <param name="y">The second instance.</param>
        /// <param name="farthest">If this should sort by farthest items first.</param>
        /// <returns>Less than zero if the first instance comes first, zero if they are equal, or greater than zero if the second comes first.</returns>
        public static int CompareDistance([NotNull] Transform position, [NotNull] GameObject x, Vector3 y, bool farthest = false) => CompareDistance(position.Flatten(), x.Flatten(), y.Flatten(), farthest);
        
        /// <summary>
        /// Compare the two instances.
        /// </summary>
        /// <param name="position">The position to compare against.</param>
        /// <param name="x">The first instance.</param>
        /// <param name="y">The second instance.</param>
        /// <param name="farthest">If this should sort by farthest items first.</param>
        /// <returns>Less than zero if the first instance comes first, zero if they are equal, or greater than zero if the second comes first.</returns>
        public static int CompareDistance([NotNull] Transform position, [NotNull] GameObject x, [NotNull] Transform y, bool farthest = false) => CompareDistance(position.Flatten(), x.Flatten(), y.Flatten(), farthest);
        
        /// <summary>
        /// Compare the two instances.
        /// </summary>
        /// <param name="position">The position to compare against.</param>
        /// <param name="x">The first instance.</param>
        /// <param name="y">The second instance.</param>
        /// <param name="farthest">If this should sort by farthest items first.</param>
        /// <returns>Less than zero if the first instance comes first, zero if they are equal, or greater than zero if the second comes first.</returns>
        public static int CompareDistance([NotNull] Transform position, [NotNull] GameObject x, [NotNull] Component y, bool farthest = false) => CompareDistance(position.Flatten(), x.Flatten(), y.Flatten(), farthest);
        
        /// <summary>
        /// Compare the two instances.
        /// </summary>
        /// <param name="position">The position to compare against.</param>
        /// <param name="x">The first instance.</param>
        /// <param name="y">The second instance.</param>
        /// <param name="farthest">If this should sort by farthest items first.</param>
        /// <returns>Less than zero if the first instance comes first, zero if they are equal, or greater than zero if the second comes first.</returns>
        public static int CompareDistance([NotNull] Transform position, [NotNull] GameObject x, [NotNull] GameObject y, bool farthest = false) => CompareDistance(position.Flatten(), x.Flatten(), y.Flatten(), farthest);
        
        /// <summary>
        /// Compare the two instances.
        /// </summary>
        /// <param name="position">The position to compare against.</param>
        /// <param name="x">The first instance.</param>
        /// <param name="y">The second instance.</param>
        /// <param name="farthest">If this should sort by farthest items first.</param>
        /// <returns>Less than zero if the first instance comes first, zero if they are equal, or greater than zero if the second comes first.</returns>
        public static int CompareDistance([NotNull] Component position, Vector2 x, Vector2 y, bool farthest = false) => CompareDistance(position.Flatten(), x, y, farthest);
        
        /// <summary>
        /// Compare the two instances.
        /// </summary>
        /// <param name="position">The position to compare against.</param>
        /// <param name="x">The first instance.</param>
        /// <param name="y">The second instance.</param>
        /// <param name="farthest">If this should sort by farthest items first.</param>
        /// <returns>Less than zero if the first instance comes first, zero if they are equal, or greater than zero if the second comes first.</returns>
        public static int CompareDistance([NotNull] Component position, Vector2 x, Vector3 y, bool farthest = false) => CompareDistance(position.Flatten(), x, y.Flatten(), farthest);
        
        /// <summary>
        /// Compare the two instances.
        /// </summary>
        /// <param name="position">The position to compare against.</param>
        /// <param name="x">The first instance.</param>
        /// <param name="y">The second instance.</param>
        /// <param name="farthest">If this should sort by farthest items first.</param>
        /// <returns>Less than zero if the first instance comes first, zero if they are equal, or greater than zero if the second comes first.</returns>
        public static int CompareDistance([NotNull] Component position, Vector2 x, [NotNull] Transform y, bool farthest = false) => CompareDistance(position.Flatten(), x, y.Flatten(), farthest);
        
        /// <summary>
        /// Compare the two instances.
        /// </summary>
        /// <param name="position">The position to compare against.</param>
        /// <param name="x">The first instance.</param>
        /// <param name="y">The second instance.</param>
        /// <param name="farthest">If this should sort by farthest items first.</param>
        /// <returns>Less than zero if the first instance comes first, zero if they are equal, or greater than zero if the second comes first.</returns>
        public static int CompareDistance([NotNull] Component position, Vector2 x, [NotNull] Component y, bool farthest = false) => CompareDistance(position.Flatten(), x, y.Flatten(), farthest);
        
        /// <summary>
        /// Compare the two instances.
        /// </summary>
        /// <param name="position">The position to compare against.</param>
        /// <param name="x">The first instance.</param>
        /// <param name="y">The second instance.</param>
        /// <param name="farthest">If this should sort by farthest items first.</param>
        /// <returns>Less than zero if the first instance comes first, zero if they are equal, or greater than zero if the second comes first.</returns>
        public static int CompareDistance([NotNull] Component position, Vector2 x, [NotNull] GameObject y, bool farthest = false) => CompareDistance(position.Flatten(), x, y.Flatten(), farthest);
        
        /// <summary>
        /// Compare the two instances.
        /// </summary>
        /// <param name="position">The position to compare against.</param>
        /// <param name="x">The first instance.</param>
        /// <param name="y">The second instance.</param>
        /// <param name="farthest">If this should sort by farthest items first.</param>
        /// <returns>Less than zero if the first instance comes first, zero if they are equal, or greater than zero if the second comes first.</returns>
        public static int CompareDistance([NotNull] Component position, Vector3 x, Vector2 y, bool farthest = false) => CompareDistance(position.Flatten(), x.Flatten(), y, farthest);
        
        /// <summary>
        /// Compare the two instances.
        /// </summary>
        /// <param name="position">The position to compare against.</param>
        /// <param name="x">The first instance.</param>
        /// <param name="y">The second instance.</param>
        /// <param name="farthest">If this should sort by farthest items first.</param>
        /// <returns>Less than zero if the first instance comes first, zero if they are equal, or greater than zero if the second comes first.</returns>
        public static int CompareDistance([NotNull] Component position, Vector3 x, Vector3 y, bool farthest = false) => CompareDistance(position.Flatten(), x.Flatten(), y.Flatten(), farthest);
        
        /// <summary>
        /// Compare the two instances.
        /// </summary>
        /// <param name="position">The position to compare against.</param>
        /// <param name="x">The first instance.</param>
        /// <param name="y">The second instance.</param>
        /// <param name="farthest">If this should sort by farthest items first.</param>
        /// <returns>Less than zero if the first instance comes first, zero if they are equal, or greater than zero if the second comes first.</returns>
        public static int CompareDistance([NotNull] Component position, Vector3 x, [NotNull] Transform y, bool farthest = false) => CompareDistance(position.Flatten(), x.Flatten(), y.Flatten(), farthest);
        
        /// <summary>
        /// Compare the two instances.
        /// </summary>
        /// <param name="position">The position to compare against.</param>
        /// <param name="x">The first instance.</param>
        /// <param name="y">The second instance.</param>
        /// <param name="farthest">If this should sort by farthest items first.</param>
        /// <returns>Less than zero if the first instance comes first, zero if they are equal, or greater than zero if the second comes first.</returns>
        public static int CompareDistance([NotNull] Component position, Vector3 x, [NotNull] Component y, bool farthest = false) => CompareDistance(position.Flatten(), x.Flatten(), y.Flatten(), farthest);
        
        /// <summary>
        /// Compare the two instances.
        /// </summary>
        /// <param name="position">The position to compare against.</param>
        /// <param name="x">The first instance.</param>
        /// <param name="y">The second instance.</param>
        /// <param name="farthest">If this should sort by farthest items first.</param>
        /// <returns>Less than zero if the first instance comes first, zero if they are equal, or greater than zero if the second comes first.</returns>
        public static int CompareDistance([NotNull] Component position, Vector3 x, [NotNull] GameObject y, bool farthest = false) => CompareDistance(position.Flatten(), x.Flatten(), y.Flatten(), farthest);
        
        /// <summary>
        /// Compare the two instances.
        /// </summary>
        /// <param name="position">The position to compare against.</param>
        /// <param name="x">The first instance.</param>
        /// <param name="y">The second instance.</param>
        /// <param name="farthest">If this should sort by farthest items first.</param>
        /// <returns>Less than zero if the first instance comes first, zero if they are equal, or greater than zero if the second comes first.</returns>
        public static int CompareDistance([NotNull] Component position, [NotNull] Transform x, Vector2 y, bool farthest = false) => CompareDistance(position.Flatten(), x.Flatten(), y, farthest);
        
        /// <summary>
        /// Compare the two instances.
        /// </summary>
        /// <param name="position">The position to compare against.</param>
        /// <param name="x">The first instance.</param>
        /// <param name="y">The second instance.</param>
        /// <param name="farthest">If this should sort by farthest items first.</param>
        /// <returns>Less than zero if the first instance comes first, zero if they are equal, or greater than zero if the second comes first.</returns>
        public static int CompareDistance([NotNull] Component position, [NotNull] Transform x, Vector3 y, bool farthest = false) => CompareDistance(position.Flatten(), x.Flatten(), y.Flatten(), farthest);
        
        /// <summary>
        /// Compare the two instances.
        /// </summary>
        /// <param name="position">The position to compare against.</param>
        /// <param name="x">The first instance.</param>
        /// <param name="y">The second instance.</param>
        /// <param name="farthest">If this should sort by farthest items first.</param>
        /// <returns>Less than zero if the first instance comes first, zero if they are equal, or greater than zero if the second comes first.</returns>
        public static int CompareDistance([NotNull] Component position, [NotNull] Transform x, [NotNull] Transform y, bool farthest = false) => CompareDistance(position.Flatten(), x.Flatten(), y.Flatten(), farthest);
        
        /// <summary>
        /// Compare the two instances.
        /// </summary>
        /// <param name="position">The position to compare against.</param>
        /// <param name="x">The first instance.</param>
        /// <param name="y">The second instance.</param>
        /// <param name="farthest">If this should sort by farthest items first.</param>
        /// <returns>Less than zero if the first instance comes first, zero if they are equal, or greater than zero if the second comes first.</returns>
        public static int CompareDistance([NotNull] Component position, [NotNull] Transform x, [NotNull] Component y, bool farthest = false) => CompareDistance(position.Flatten(), x.Flatten(), y.Flatten(), farthest);
        
        /// <summary>
        /// Compare the two instances.
        /// </summary>
        /// <param name="position">The position to compare against.</param>
        /// <param name="x">The first instance.</param>
        /// <param name="y">The second instance.</param>
        /// <param name="farthest">If this should sort by farthest items first.</param>
        /// <returns>Less than zero if the first instance comes first, zero if they are equal, or greater than zero if the second comes first.</returns>
        public static int CompareDistance([NotNull] Component position, [NotNull] Transform x, [NotNull] GameObject y, bool farthest = false) => CompareDistance(position.Flatten(), x.Flatten(), y.Flatten(), farthest);
        
        /// <summary>
        /// Compare the two instances.
        /// </summary>
        /// <param name="position">The position to compare against.</param>
        /// <param name="x">The first instance.</param>
        /// <param name="y">The second instance.</param>
        /// <param name="farthest">If this should sort by farthest items first.</param>
        /// <returns>Less than zero if the first instance comes first, zero if they are equal, or greater than zero if the second comes first.</returns>
        public static int CompareDistance([NotNull] Component position, [NotNull] Component x, Vector2 y, bool farthest = false) => CompareDistance(position.Flatten(), x.Flatten(), y, farthest);
        
        /// <summary>
        /// Compare the two instances.
        /// </summary>
        /// <param name="position">The position to compare against.</param>
        /// <param name="x">The first instance.</param>
        /// <param name="y">The second instance.</param>
        /// <param name="farthest">If this should sort by farthest items first.</param>
        /// <returns>Less than zero if the first instance comes first, zero if they are equal, or greater than zero if the second comes first.</returns>
        public static int CompareDistance([NotNull] Component position, [NotNull] Component x, Vector3 y, bool farthest = false) => CompareDistance(position.Flatten(), x.Flatten(), y.Flatten(), farthest);
        
        /// <summary>
        /// Compare the two instances.
        /// </summary>
        /// <param name="position">The position to compare against.</param>
        /// <param name="x">The first instance.</param>
        /// <param name="y">The second instance.</param>
        /// <param name="farthest">If this should sort by farthest items first.</param>
        /// <returns>Less than zero if the first instance comes first, zero if they are equal, or greater than zero if the second comes first.</returns>
        public static int CompareDistance([NotNull] Component position, [NotNull] Component x, [NotNull] Transform y, bool farthest = false) => CompareDistance(position.Flatten(), x.Flatten(), y.Flatten(), farthest);
        
        /// <summary>
        /// Compare the two instances.
        /// </summary>
        /// <param name="position">The position to compare against.</param>
        /// <param name="x">The first instance.</param>
        /// <param name="y">The second instance.</param>
        /// <param name="farthest">If this should sort by farthest items first.</param>
        /// <returns>Less than zero if the first instance comes first, zero if they are equal, or greater than zero if the second comes first.</returns>
        public static int CompareDistance([NotNull] Component position, [NotNull] Component x, [NotNull] Component y, bool farthest = false) => CompareDistance(position.Flatten(), x.Flatten(), y.Flatten(), farthest);
        
        /// <summary>
        /// Compare the two instances.
        /// </summary>
        /// <param name="position">The position to compare against.</param>
        /// <param name="x">The first instance.</param>
        /// <param name="y">The second instance.</param>
        /// <param name="farthest">If this should sort by farthest items first.</param>
        /// <returns>Less than zero if the first instance comes first, zero if they are equal, or greater than zero if the second comes first.</returns>
        public static int CompareDistance([NotNull] Component position, [NotNull] Component x, [NotNull] GameObject y, bool farthest = false) => CompareDistance(position.Flatten(), x.Flatten(), y.Flatten(), farthest);
        
        /// <summary>
        /// Compare the two instances.
        /// </summary>
        /// <param name="position">The position to compare against.</param>
        /// <param name="x">The first instance.</param>
        /// <param name="y">The second instance.</param>
        /// <param name="farthest">If this should sort by farthest items first.</param>
        /// <returns>Less than zero if the first instance comes first, zero if they are equal, or greater than zero if the second comes first.</returns>
        public static int CompareDistance([NotNull] Component position, [NotNull] GameObject x, Vector2 y, bool farthest = false) => CompareDistance(position.Flatten(), x.Flatten(), y, farthest);
        
        /// <summary>
        /// Compare the two instances.
        /// </summary>
        /// <param name="position">The position to compare against.</param>
        /// <param name="x">The first instance.</param>
        /// <param name="y">The second instance.</param>
        /// <param name="farthest">If this should sort by farthest items first.</param>
        /// <returns>Less than zero if the first instance comes first, zero if they are equal, or greater than zero if the second comes first.</returns>
        public static int CompareDistance([NotNull] Component position, [NotNull] GameObject x, Vector3 y, bool farthest = false) => CompareDistance(position.Flatten(), x.Flatten(), y.Flatten(), farthest);
        
        /// <summary>
        /// Compare the two instances.
        /// </summary>
        /// <param name="position">The position to compare against.</param>
        /// <param name="x">The first instance.</param>
        /// <param name="y">The second instance.</param>
        /// <param name="farthest">If this should sort by farthest items first.</param>
        /// <returns>Less than zero if the first instance comes first, zero if they are equal, or greater than zero if the second comes first.</returns>
        public static int CompareDistance([NotNull] Component position, [NotNull] GameObject x, [NotNull] Transform y, bool farthest = false) => CompareDistance(position.Flatten(), x.Flatten(), y.Flatten(), farthest);
        
        /// <summary>
        /// Compare the two instances.
        /// </summary>
        /// <param name="position">The position to compare against.</param>
        /// <param name="x">The first instance.</param>
        /// <param name="y">The second instance.</param>
        /// <param name="farthest">If this should sort by farthest items first.</param>
        /// <returns>Less than zero if the first instance comes first, zero if they are equal, or greater than zero if the second comes first.</returns>
        public static int CompareDistance([NotNull] Component position, [NotNull] GameObject x, [NotNull] Component y, bool farthest = false) => CompareDistance(position.Flatten(), x.Flatten(), y.Flatten(), farthest);
        
        /// <summary>
        /// Compare the two instances.
        /// </summary>
        /// <param name="position">The position to compare against.</param>
        /// <param name="x">The first instance.</param>
        /// <param name="y">The second instance.</param>
        /// <param name="farthest">If this should sort by farthest items first.</param>
        /// <returns>Less than zero if the first instance comes first, zero if they are equal, or greater than zero if the second comes first.</returns>
        public static int CompareDistance([NotNull] Component position, [NotNull] GameObject x, [NotNull] GameObject y, bool farthest = false) => CompareDistance(position.Flatten(), x.Flatten(), y.Flatten(), farthest);
        
        /// <summary>
        /// Compare the two instances.
        /// </summary>
        /// <param name="position">The position to compare against.</param>
        /// <param name="x">The first instance.</param>
        /// <param name="y">The second instance.</param>
        /// <param name="farthest">If this should sort by farthest items first.</param>
        /// <returns>Less than zero if the first instance comes first, zero if they are equal, or greater than zero if the second comes first.</returns>
        public static int CompareDistance([NotNull] GameObject position, Vector2 x, Vector2 y, bool farthest = false) => CompareDistance(position.Flatten(), x, y, farthest);
        
        /// <summary>
        /// Compare the two instances.
        /// </summary>
        /// <param name="position">The position to compare against.</param>
        /// <param name="x">The first instance.</param>
        /// <param name="y">The second instance.</param>
        /// <param name="farthest">If this should sort by farthest items first.</param>
        /// <returns>Less than zero if the first instance comes first, zero if they are equal, or greater than zero if the second comes first.</returns>
        public static int CompareDistance([NotNull] GameObject position, Vector2 x, Vector3 y, bool farthest = false) => CompareDistance(position.Flatten(), x, y.Flatten(), farthest);
        
        /// <summary>
        /// Compare the two instances.
        /// </summary>
        /// <param name="position">The position to compare against.</param>
        /// <param name="x">The first instance.</param>
        /// <param name="y">The second instance.</param>
        /// <param name="farthest">If this should sort by farthest items first.</param>
        /// <returns>Less than zero if the first instance comes first, zero if they are equal, or greater than zero if the second comes first.</returns>
        public static int CompareDistance([NotNull] GameObject position, Vector2 x, [NotNull] Transform y, bool farthest = false) => CompareDistance(position.Flatten(), x, y.Flatten(), farthest);
        
        /// <summary>
        /// Compare the two instances.
        /// </summary>
        /// <param name="position">The position to compare against.</param>
        /// <param name="x">The first instance.</param>
        /// <param name="y">The second instance.</param>
        /// <param name="farthest">If this should sort by farthest items first.</param>
        /// <returns>Less than zero if the first instance comes first, zero if they are equal, or greater than zero if the second comes first.</returns>
        public static int CompareDistance([NotNull] GameObject position, Vector2 x, [NotNull] Component y, bool farthest = false) => CompareDistance(position.Flatten(), x, y.Flatten(), farthest);
        
        /// <summary>
        /// Compare the two instances.
        /// </summary>
        /// <param name="position">The position to compare against.</param>
        /// <param name="x">The first instance.</param>
        /// <param name="y">The second instance.</param>
        /// <param name="farthest">If this should sort by farthest items first.</param>
        /// <returns>Less than zero if the first instance comes first, zero if they are equal, or greater than zero if the second comes first.</returns>
        public static int CompareDistance([NotNull] GameObject position, Vector2 x, [NotNull] GameObject y, bool farthest = false) => CompareDistance(position.Flatten(), x, y.Flatten(), farthest);
        
        /// <summary>
        /// Compare the two instances.
        /// </summary>
        /// <param name="position">The position to compare against.</param>
        /// <param name="x">The first instance.</param>
        /// <param name="y">The second instance.</param>
        /// <param name="farthest">If this should sort by farthest items first.</param>
        /// <returns>Less than zero if the first instance comes first, zero if they are equal, or greater than zero if the second comes first.</returns>
        public static int CompareDistance([NotNull] GameObject position, Vector3 x, Vector2 y, bool farthest = false) => CompareDistance(position.Flatten(), x.Flatten(), y, farthest);
        
        /// <summary>
        /// Compare the two instances.
        /// </summary>
        /// <param name="position">The position to compare against.</param>
        /// <param name="x">The first instance.</param>
        /// <param name="y">The second instance.</param>
        /// <param name="farthest">If this should sort by farthest items first.</param>
        /// <returns>Less than zero if the first instance comes first, zero if they are equal, or greater than zero if the second comes first.</returns>
        public static int CompareDistance([NotNull] GameObject position, Vector3 x, Vector3 y, bool farthest = false) => CompareDistance(position.Flatten(), x.Flatten(), y.Flatten(), farthest);
        
        /// <summary>
        /// Compare the two instances.
        /// </summary>
        /// <param name="position">The position to compare against.</param>
        /// <param name="x">The first instance.</param>
        /// <param name="y">The second instance.</param>
        /// <param name="farthest">If this should sort by farthest items first.</param>
        /// <returns>Less than zero if the first instance comes first, zero if they are equal, or greater than zero if the second comes first.</returns>
        public static int CompareDistance([NotNull] GameObject position, Vector3 x, [NotNull] Transform y, bool farthest = false) => CompareDistance(position.Flatten(), x.Flatten(), y.Flatten(), farthest);
        
        /// <summary>
        /// Compare the two instances.
        /// </summary>
        /// <param name="position">The position to compare against.</param>
        /// <param name="x">The first instance.</param>
        /// <param name="y">The second instance.</param>
        /// <param name="farthest">If this should sort by farthest items first.</param>
        /// <returns>Less than zero if the first instance comes first, zero if they are equal, or greater than zero if the second comes first.</returns>
        public static int CompareDistance([NotNull] GameObject position, Vector3 x, [NotNull] Component y, bool farthest = false) => CompareDistance(position.Flatten(), x.Flatten(), y.Flatten(), farthest);
        
        /// <summary>
        /// Compare the two instances.
        /// </summary>
        /// <param name="position">The position to compare against.</param>
        /// <param name="x">The first instance.</param>
        /// <param name="y">The second instance.</param>
        /// <param name="farthest">If this should sort by farthest items first.</param>
        /// <returns>Less than zero if the first instance comes first, zero if they are equal, or greater than zero if the second comes first.</returns>
        public static int CompareDistance([NotNull] GameObject position, Vector3 x, [NotNull] GameObject y, bool farthest = false) => CompareDistance(position.Flatten(), x.Flatten(), y.Flatten(), farthest);
        
        /// <summary>
        /// Compare the two instances.
        /// </summary>
        /// <param name="position">The position to compare against.</param>
        /// <param name="x">The first instance.</param>
        /// <param name="y">The second instance.</param>
        /// <param name="farthest">If this should sort by farthest items first.</param>
        /// <returns>Less than zero if the first instance comes first, zero if they are equal, or greater than zero if the second comes first.</returns>
        public static int CompareDistance([NotNull] GameObject position, [NotNull] Transform x, Vector2 y, bool farthest = false) => CompareDistance(position.Flatten(), x.Flatten(), y, farthest);
        
        /// <summary>
        /// Compare the two instances.
        /// </summary>
        /// <param name="position">The position to compare against.</param>
        /// <param name="x">The first instance.</param>
        /// <param name="y">The second instance.</param>
        /// <param name="farthest">If this should sort by farthest items first.</param>
        /// <returns>Less than zero if the first instance comes first, zero if they are equal, or greater than zero if the second comes first.</returns>
        public static int CompareDistance([NotNull] GameObject position, [NotNull] Transform x, Vector3 y, bool farthest = false) => CompareDistance(position.Flatten(), x.Flatten(), y.Flatten(), farthest);
        
        /// <summary>
        /// Compare the two instances.
        /// </summary>
        /// <param name="position">The position to compare against.</param>
        /// <param name="x">The first instance.</param>
        /// <param name="y">The second instance.</param>
        /// <param name="farthest">If this should sort by farthest items first.</param>
        /// <returns>Less than zero if the first instance comes first, zero if they are equal, or greater than zero if the second comes first.</returns>
        public static int CompareDistance([NotNull] GameObject position, [NotNull] Transform x, [NotNull] Transform y, bool farthest = false) => CompareDistance(position.Flatten(), x.Flatten(), y.Flatten(), farthest);
        
        /// <summary>
        /// Compare the two instances.
        /// </summary>
        /// <param name="position">The position to compare against.</param>
        /// <param name="x">The first instance.</param>
        /// <param name="y">The second instance.</param>
        /// <param name="farthest">If this should sort by farthest items first.</param>
        /// <returns>Less than zero if the first instance comes first, zero if they are equal, or greater than zero if the second comes first.</returns>
        public static int CompareDistance([NotNull] GameObject position, [NotNull] Transform x, [NotNull] Component y, bool farthest = false) => CompareDistance(position.Flatten(), x.Flatten(), y.Flatten(), farthest);
        
        /// <summary>
        /// Compare the two instances.
        /// </summary>
        /// <param name="position">The position to compare against.</param>
        /// <param name="x">The first instance.</param>
        /// <param name="y">The second instance.</param>
        /// <param name="farthest">If this should sort by farthest items first.</param>
        /// <returns>Less than zero if the first instance comes first, zero if they are equal, or greater than zero if the second comes first.</returns>
        public static int CompareDistance([NotNull] GameObject position, [NotNull] Transform x, [NotNull] GameObject y, bool farthest = false) => CompareDistance(position.Flatten(), x.Flatten(), y.Flatten(), farthest);
        
        /// <summary>
        /// Compare the two instances.
        /// </summary>
        /// <param name="position">The position to compare against.</param>
        /// <param name="x">The first instance.</param>
        /// <param name="y">The second instance.</param>
        /// <param name="farthest">If this should sort by farthest items first.</param>
        /// <returns>Less than zero if the first instance comes first, zero if they are equal, or greater than zero if the second comes first.</returns>
        public static int CompareDistance([NotNull] GameObject position, [NotNull] Component x, Vector2 y, bool farthest = false) => CompareDistance(position.Flatten(), x.Flatten(), y, farthest);
        
        /// <summary>
        /// Compare the two instances.
        /// </summary>
        /// <param name="position">The position to compare against.</param>
        /// <param name="x">The first instance.</param>
        /// <param name="y">The second instance.</param>
        /// <param name="farthest">If this should sort by farthest items first.</param>
        /// <returns>Less than zero if the first instance comes first, zero if they are equal, or greater than zero if the second comes first.</returns>
        public static int CompareDistance([NotNull] GameObject position, [NotNull] Component x, Vector3 y, bool farthest = false) => CompareDistance(position.Flatten(), x.Flatten(), y.Flatten(), farthest);
        
        /// <summary>
        /// Compare the two instances.
        /// </summary>
        /// <param name="position">The position to compare against.</param>
        /// <param name="x">The first instance.</param>
        /// <param name="y">The second instance.</param>
        /// <param name="farthest">If this should sort by farthest items first.</param>
        /// <returns>Less than zero if the first instance comes first, zero if they are equal, or greater than zero if the second comes first.</returns>
        public static int CompareDistance([NotNull] GameObject position, [NotNull] Component x, [NotNull] Transform y, bool farthest = false) => CompareDistance(position.Flatten(), x.Flatten(), y.Flatten(), farthest);
        
        /// <summary>
        /// Compare the two instances.
        /// </summary>
        /// <param name="position">The position to compare against.</param>
        /// <param name="x">The first instance.</param>
        /// <param name="y">The second instance.</param>
        /// <param name="farthest">If this should sort by farthest items first.</param>
        /// <returns>Less than zero if the first instance comes first, zero if they are equal, or greater than zero if the second comes first.</returns>
        public static int CompareDistance([NotNull] GameObject position, [NotNull] Component x, [NotNull] Component y, bool farthest = false) => CompareDistance(position.Flatten(), x.Flatten(), y.Flatten(), farthest);
        
        /// <summary>
        /// Compare the two instances.
        /// </summary>
        /// <param name="position">The position to compare against.</param>
        /// <param name="x">The first instance.</param>
        /// <param name="y">The second instance.</param>
        /// <param name="farthest">If this should sort by farthest items first.</param>
        /// <returns>Less than zero if the first instance comes first, zero if they are equal, or greater than zero if the second comes first.</returns>
        public static int CompareDistance([NotNull] GameObject position, [NotNull] Component x, [NotNull] GameObject y, bool farthest = false) => CompareDistance(position.Flatten(), x.Flatten(), y.Flatten(), farthest);
        
        /// <summary>
        /// Compare the two instances.
        /// </summary>
        /// <param name="position">The position to compare against.</param>
        /// <param name="x">The first instance.</param>
        /// <param name="y">The second instance.</param>
        /// <param name="farthest">If this should sort by farthest items first.</param>
        /// <returns>Less than zero if the first instance comes first, zero if they are equal, or greater than zero if the second comes first.</returns>
        public static int CompareDistance([NotNull] GameObject position, [NotNull] GameObject x, Vector2 y, bool farthest = false) => CompareDistance(position.Flatten(), x.Flatten(), y, farthest);
        
        /// <summary>
        /// Compare the two instances.
        /// </summary>
        /// <param name="position">The position to compare against.</param>
        /// <param name="x">The first instance.</param>
        /// <param name="y">The second instance.</param>
        /// <param name="farthest">If this should sort by farthest items first.</param>
        /// <returns>Less than zero if the first instance comes first, zero if they are equal, or greater than zero if the second comes first.</returns>
        public static int CompareDistance([NotNull] GameObject position, [NotNull] GameObject x, Vector3 y, bool farthest = false) => CompareDistance(position.Flatten(), x.Flatten(), y.Flatten(), farthest);
        
        /// <summary>
        /// Compare the two instances.
        /// </summary>
        /// <param name="position">The position to compare against.</param>
        /// <param name="x">The first instance.</param>
        /// <param name="y">The second instance.</param>
        /// <param name="farthest">If this should sort by farthest items first.</param>
        /// <returns>Less than zero if the first instance comes first, zero if they are equal, or greater than zero if the second comes first.</returns>
        public static int CompareDistance([NotNull] GameObject position, [NotNull] GameObject x, [NotNull] Transform y, bool farthest = false) => CompareDistance(position.Flatten(), x.Flatten(), y.Flatten(), farthest);
        
        /// <summary>
        /// Compare the two instances.
        /// </summary>
        /// <param name="position">The position to compare against.</param>
        /// <param name="x">The first instance.</param>
        /// <param name="y">The second instance.</param>
        /// <param name="farthest">If this should sort by farthest items first.</param>
        /// <returns>Less than zero if the first instance comes first, zero if they are equal, or greater than zero if the second comes first.</returns>
        public static int CompareDistance([NotNull] GameObject position, [NotNull] GameObject x, [NotNull] Component y, bool farthest = false) => CompareDistance(position.Flatten(), x.Flatten(), y.Flatten(), farthest);
        
        /// <summary>
        /// Compare the two instances.
        /// </summary>
        /// <param name="position">The position to compare against.</param>
        /// <param name="x">The first instance.</param>
        /// <param name="y">The second instance.</param>
        /// <param name="farthest">If this should sort by farthest items first.</param>
        /// <returns>Less than zero if the first instance comes first, zero if they are equal, or greater than zero if the second comes first.</returns>
        public static int CompareDistance([NotNull] GameObject position, [NotNull] GameObject x, [NotNull] GameObject y, bool farthest = false) => CompareDistance(position.Flatten(), x.Flatten(), y.Flatten(), farthest);
        
        /// <summary>
        /// Compare the two instances.
        /// </summary>
        /// <param name="x">The first instance.</param>
        /// <param name="y">The second instance.</param>
        /// <returns>Less than zero if the first instance comes first, zero if they are equal, or greater than zero if the second comes first.</returns>
        public int Compare(Vector2 x, Vector2 y)
        {
            int order = CompareDistance(Position, x, y);
            return order != 0 || !Mode.HasValue ? order : KaijuAgentsAngleSorter.CompareAngle(Position, Forward ?? Position, x, y, Mode.Value);
        }
        
        /// <summary>
        /// Compare the two instances.
        /// </summary>
        /// <param name="x">The first instance.</param>
        /// <param name="y">The second instance.</param>
        /// <returns>Less than zero if the first instance comes first, zero if they are equal, or greater than zero if the second comes first.</returns>
        public int Compare(Vector3 x, Vector3 y)
        {
            return Compare(x.Flatten(), y.Flatten());
        }
        
        /// <summary>
        /// Compare the two instances.
        /// </summary>
        /// <param name="x">The first instance.</param>
        /// <param name="y">The second instance.</param>
        /// <returns>Less than zero if the first instance comes first, zero if they are equal, or greater than zero if the second comes first.</returns>
        public int Compare(Transform x, Transform y)
        {
            // NULL entries come last.
            return x == null ? y == null ? 0 : 1 : y == null ? -1 : Compare(x.Flatten(), y.Flatten());
        }
        
        /// <summary>
        /// Compare the two instances.
        /// </summary>
        /// <param name="x">The first instance.</param>
        /// <param name="y">The second instance.</param>
        /// <returns>Less than zero if the first instance comes first, zero if they are equal, or greater than zero if the second comes first.</returns>
        public int Compare(Component x, Component y)
        {
            // NULL entries come last.
            return x == null ? y == null ? 0 : 1 : y == null ? -1 : Compare(x.Flatten(), y.Flatten());
        }
        
        /// <summary>
        /// Compare the two instances.
        /// </summary>
        /// <param name="x">The first instance.</param>
        /// <param name="y">The second instance.</param>
        /// <returns>Less than zero if the first instance comes first, zero if they are equal, or greater than zero if the second comes first.</returns>
        public int Compare(GameObject x, GameObject y)
        {
            // NULL entries come last.
            return x == null ? y == null ? 0 : 1 : y == null ? -1 : Compare(x.Flatten(), y.Flatten());
        }
        
        /// <summary>
        /// Get a description of the object.
        /// </summary>
        /// <returns>A description of the object.</returns>
        public override string ToString()
        {
            return $"Kaiju Agents Distance Sorter - Position: {Position}";
        }
        
        /// <summary>
        /// Implicit conversion to a string.
        /// </summary>
        /// <param name="s">The sorter.</param>
        /// <returns>The string from the <see cref="ToString"/> method.</returns>
        public static implicit operator string([NotNull] KaijuAgentsDistanceSorter s) => s.ToString();
        
        /// <summary>
        /// Implicit conversion to a Vector2 from the position.
        /// </summary>
        /// <param name="s">The sorter.</param>
        /// <returns>The string from the <see cref="ToString"/> method.</returns>
        public static implicit operator Vector2([NotNull] KaijuAgentsDistanceSorter s) => s.Position;
        
        /// <summary>
        /// Implicit conversion to a nullable Vector2 from the position.
        /// </summary>
        /// <param name="s">The sorter.</param>
        /// <returns>The string from the <see cref="ToString"/> method.</returns>
        public static implicit operator Vector2?([NotNull] KaijuAgentsDistanceSorter s) => s.Position;
        
        /// <summary>
        /// Implicit conversion to a Vector3 from the position.
        /// </summary>
        /// <param name="s">The sorter.</param>
        /// <returns>The string from the <see cref="ToString"/> method.</returns>
        public static implicit operator Vector3([NotNull] KaijuAgentsDistanceSorter s) => s.Position3;
        
        /// <summary>
        /// Implicit conversion to a nullable Vector3 from the position.
        /// </summary>
        /// <param name="s">The sorter.</param>
        /// <returns>The string from the <see cref="ToString"/> method.</returns>
        public static implicit operator Vector3?([NotNull] KaijuAgentsDistanceSorter s) => s.Position3;
    }
}