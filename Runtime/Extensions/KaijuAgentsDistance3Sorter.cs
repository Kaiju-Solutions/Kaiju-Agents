using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using UnityEngine;

namespace KaijuSolutions.Agents.Extensions
{
    /// <summary>
    /// Comparer class to sort by distance along all three axes. Used in the extension methods found in <see cref="KaijuAgentsSortDistance3"/>.
    /// </summary>
    public sealed class KaijuAgentsDistance3Sorter : IComparer<Vector2>, IComparer<Vector3>, IComparer<Transform>, IComparer<Component>, IComparer<GameObject>
    {
        /// <summary>
        /// The position to compare against.
        /// </summary>
        public Vector2 Position2
        {
            get => Position.Flatten();
            set => Position = value.Expand();
        }
        
        /// <summary>
        /// The position to compare against. This will also set the forward for angle tie breaking.
        /// </summary>
        public Transform PositionTransform
        {
            set
            {
                Position = value.position;
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
            get => Forward?.Expand() ?? Position;
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
        public Vector3 Position;
        
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
        public KaijuAgentsDistance3Sorter()
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
        public KaijuAgentsDistance3Sorter(Vector2 position, bool farthest = false, KaijuAngleSortMode? mode = null, Vector2? forward = null)
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
        public KaijuAgentsDistance3Sorter(Vector3 position, bool farthest = false, KaijuAngleSortMode? mode = null, Vector2? forward = null)
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
        public KaijuAgentsDistance3Sorter([NotNull] Transform position, bool farthest = false, KaijuAngleSortMode? mode = null, Vector2? forward = null)
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
        public KaijuAgentsDistance3Sorter([NotNull] Component position, bool farthest = false, KaijuAngleSortMode? mode = null, Vector2? forward = null)
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
        public KaijuAgentsDistance3Sorter([NotNull] GameObject position, bool farthest = false, KaijuAngleSortMode? mode = null, Vector2? forward = null)
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
            Set(position.Expand(), farthest, mode, forward);
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
        public void Set([NotNull] Transform position, bool farthest = false, KaijuAngleSortMode? mode = null, Vector2? forward = null)
        {
            Set(position.position, farthest, mode, forward);
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
            Set(position.transform.position, farthest, mode, forward);
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
            Set(position.transform.position, farthest, mode, forward);
        }
        
        /// <summary>
        /// Compare the two instances.
        /// </summary>
        /// <param name="position">The position to compare against.</param>
        /// <param name="x">The first instance.</param>
        /// <param name="y">The second instance.</param>
        /// <param name="farthest">If this should sort by farthest items first.</param>
        /// <returns>Less than zero if the first instance comes first, zero if they are equal, or greater than zero if the second comes first.</returns>
        public static int CompareDistance3(Vector2 position, Vector2 x, Vector3 y, bool farthest = false) => CompareDistance3(position.Expand(), x.Expand(), y, farthest);
        
        /// <summary>
        /// Compare the two instances.
        /// </summary>
        /// <param name="position">The position to compare against.</param>
        /// <param name="x">The first instance.</param>
        /// <param name="y">The second instance.</param>
        /// <param name="farthest">If this should sort by farthest items first.</param>
        /// <returns>Less than zero if the first instance comes first, zero if they are equal, or greater than zero if the second comes first.</returns>
        public static int CompareDistance3(Vector2 position, Vector2 x, [NotNull] Transform y, bool farthest = false) => CompareDistance3(position.Expand(), x.Expand(), y.position, farthest);
        
        /// <summary>
        /// Compare the two instances.
        /// </summary>
        /// <param name="position">The position to compare against.</param>
        /// <param name="x">The first instance.</param>
        /// <param name="y">The second instance.</param>
        /// <param name="farthest">If this should sort by farthest items first.</param>
        /// <returns>Less than zero if the first instance comes first, zero if they are equal, or greater than zero if the second comes first.</returns>
        public static int CompareDistance3(Vector2 position, Vector2 x, [NotNull] Component y, bool farthest = false) => CompareDistance3(position.Expand(), x.Expand(), y.transform.position, farthest);
        
        /// <summary>
        /// Compare the two instances.
        /// </summary>
        /// <param name="position">The position to compare against.</param>
        /// <param name="x">The first instance.</param>
        /// <param name="y">The second instance.</param>
        /// <param name="farthest">If this should sort by farthest items first.</param>
        /// <returns>Less than zero if the first instance comes first, zero if they are equal, or greater than zero if the second comes first.</returns>
        public static int CompareDistance3(Vector2 position, Vector2 x, [NotNull] GameObject y, bool farthest = false) => CompareDistance3(position.Expand(), x.Expand(), y.transform.position, farthest);
        
        /// <summary>
        /// Compare the two instances.
        /// </summary>
        /// <param name="position">The position to compare against.</param>
        /// <param name="x">The first instance.</param>
        /// <param name="y">The second instance.</param>
        /// <param name="farthest">If this should sort by farthest items first.</param>
        /// <returns>Less than zero if the first instance comes first, zero if they are equal, or greater than zero if the second comes first.</returns>
        public static int CompareDistance3(Vector2 position, Vector3 x, Vector2 y, bool farthest = false) => CompareDistance3(position.Expand(), x, y.Expand(), farthest);
        
        /// <summary>
        /// Compare the two instances.
        /// </summary>
        /// <param name="position">The position to compare against.</param>
        /// <param name="x">The first instance.</param>
        /// <param name="y">The second instance.</param>
        /// <param name="farthest">If this should sort by farthest items first.</param>
        /// <returns>Less than zero if the first instance comes first, zero if they are equal, or greater than zero if the second comes first.</returns>
        public static int CompareDistance3(Vector2 position, Vector3 x, [NotNull] Transform y, bool farthest = false) => CompareDistance3(position.Expand(), x, y.position, farthest);
        
        /// <summary>
        /// Compare the two instances.
        /// </summary>
        /// <param name="position">The position to compare against.</param>
        /// <param name="x">The first instance.</param>
        /// <param name="y">The second instance.</param>
        /// <param name="farthest">If this should sort by farthest items first.</param>
        /// <returns>Less than zero if the first instance comes first, zero if they are equal, or greater than zero if the second comes first.</returns>
        public static int CompareDistance3(Vector2 position, Vector3 x, [NotNull] Component y, bool farthest = false) => CompareDistance3(position.Expand(), x, y.transform.position, farthest);
        
        /// <summary>
        /// Compare the two instances.
        /// </summary>
        /// <param name="position">The position to compare against.</param>
        /// <param name="x">The first instance.</param>
        /// <param name="y">The second instance.</param>
        /// <param name="farthest">If this should sort by farthest items first.</param>
        /// <returns>Less than zero if the first instance comes first, zero if they are equal, or greater than zero if the second comes first.</returns>
        public static int CompareDistance3(Vector2 position, Vector3 x, [NotNull] GameObject y, bool farthest = false) => CompareDistance3(position.Expand(), x, y.transform.position, farthest);
        
        /// <summary>
        /// Compare the two instances.
        /// </summary>
        /// <param name="position">The position to compare against.</param>
        /// <param name="x">The first instance.</param>
        /// <param name="y">The second instance.</param>
        /// <param name="farthest">If this should sort by farthest items first.</param>
        /// <returns>Less than zero if the first instance comes first, zero if they are equal, or greater than zero if the second comes first.</returns>
        public static int CompareDistance3(Vector2 position, [NotNull] Transform x, Vector2 y, bool farthest = false) => CompareDistance3(position.Expand(), x.position, y.Expand(), farthest);
        
        /// <summary>
        /// Compare the two instances.
        /// </summary>
        /// <param name="position">The position to compare against.</param>
        /// <param name="x">The first instance.</param>
        /// <param name="y">The second instance.</param>
        /// <param name="farthest">If this should sort by farthest items first.</param>
        /// <returns>Less than zero if the first instance comes first, zero if they are equal, or greater than zero if the second comes first.</returns>
        public static int CompareDistance3(Vector2 position, [NotNull] Transform x, [NotNull] Transform y, bool farthest = false) => CompareDistance3(position.Expand(), x.position, y.position, farthest);
        
        /// <summary>
        /// Compare the two instances.
        /// </summary>
        /// <param name="position">The position to compare against.</param>
        /// <param name="x">The first instance.</param>
        /// <param name="y">The second instance.</param>
        /// <param name="farthest">If this should sort by farthest items first.</param>
        /// <returns>Less than zero if the first instance comes first, zero if they are equal, or greater than zero if the second comes first.</returns>
        public static int CompareDistance3(Vector2 position, [NotNull] Transform x, [NotNull] Component y, bool farthest = false) => CompareDistance3(position.Expand(), x.position, y.transform.position, farthest);
        
        /// <summary>
        /// Compare the two instances.
        /// </summary>
        /// <param name="position">The position to compare against.</param>
        /// <param name="x">The first instance.</param>
        /// <param name="y">The second instance.</param>
        /// <param name="farthest">If this should sort by farthest items first.</param>
        /// <returns>Less than zero if the first instance comes first, zero if they are equal, or greater than zero if the second comes first.</returns>
        public static int CompareDistance3(Vector2 position, [NotNull] Transform x, [NotNull] GameObject y, bool farthest = false) => CompareDistance3(position.Expand(), x.position, y.transform.position, farthest);
        
        /// <summary>
        /// Compare the two instances.
        /// </summary>
        /// <param name="position">The position to compare against.</param>
        /// <param name="x">The first instance.</param>
        /// <param name="y">The second instance.</param>
        /// <param name="farthest">If this should sort by farthest items first.</param>
        /// <returns>Less than zero if the first instance comes first, zero if they are equal, or greater than zero if the second comes first.</returns>
        public static int CompareDistance3(Vector2 position, [NotNull] Component x, Vector2 y, bool farthest = false) => CompareDistance3(position.Expand(), x.transform.position, y.Expand(), farthest);
        
        /// <summary>
        /// Compare the two instances.
        /// </summary>
        /// <param name="position">The position to compare against.</param>
        /// <param name="x">The first instance.</param>
        /// <param name="y">The second instance.</param>
        /// <param name="farthest">If this should sort by farthest items first.</param>
        /// <returns>Less than zero if the first instance comes first, zero if they are equal, or greater than zero if the second comes first.</returns>
        public static int CompareDistance3(Vector2 position, [NotNull] Component x, [NotNull] Transform y, bool farthest = false) => CompareDistance3(position.Expand(), x.transform.position, y.position, farthest);
        
        /// <summary>
        /// Compare the two instances.
        /// </summary>
        /// <param name="position">The position to compare against.</param>
        /// <param name="x">The first instance.</param>
        /// <param name="y">The second instance.</param>
        /// <param name="farthest">If this should sort by farthest items first.</param>
        /// <returns>Less than zero if the first instance comes first, zero if they are equal, or greater than zero if the second comes first.</returns>
        public static int CompareDistance3(Vector2 position, [NotNull] Component x, [NotNull] Component y, bool farthest = false) => CompareDistance3(position.Expand(), x.transform.position, y.transform.position, farthest);
        
        /// <summary>
        /// Compare the two instances.
        /// </summary>
        /// <param name="position">The position to compare against.</param>
        /// <param name="x">The first instance.</param>
        /// <param name="y">The second instance.</param>
        /// <param name="farthest">If this should sort by farthest items first.</param>
        /// <returns>Less than zero if the first instance comes first, zero if they are equal, or greater than zero if the second comes first.</returns>
        public static int CompareDistance3(Vector2 position, [NotNull] Component x, [NotNull] GameObject y, bool farthest = false) => CompareDistance3(position.Expand(), x.transform.position, y.transform.position, farthest);
        
        /// <summary>
        /// Compare the two instances.
        /// </summary>
        /// <param name="position">The position to compare against.</param>
        /// <param name="x">The first instance.</param>
        /// <param name="y">The second instance.</param>
        /// <param name="farthest">If this should sort by farthest items first.</param>
        /// <returns>Less than zero if the first instance comes first, zero if they are equal, or greater than zero if the second comes first.</returns>
        public static int CompareDistance3(Vector2 position, [NotNull] GameObject x, Vector2 y, bool farthest = false) => CompareDistance3(position.Expand(), x.transform.position, y.Expand(), farthest);
        
        /// <summary>
        /// Compare the two instances.
        /// </summary>
        /// <param name="position">The position to compare against.</param>
        /// <param name="x">The first instance.</param>
        /// <param name="y">The second instance.</param>
        /// <param name="farthest">If this should sort by farthest items first.</param>
        /// <returns>Less than zero if the first instance comes first, zero if they are equal, or greater than zero if the second comes first.</returns>
        public static int CompareDistance3(Vector2 position, [NotNull] GameObject x, [NotNull] Transform y, bool farthest = false) => CompareDistance3(position.Expand(), x.transform.position, y.position, farthest);
        
        /// <summary>
        /// Compare the two instances.
        /// </summary>
        /// <param name="position">The position to compare against.</param>
        /// <param name="x">The first instance.</param>
        /// <param name="y">The second instance.</param>
        /// <param name="farthest">If this should sort by farthest items first.</param>
        /// <returns>Less than zero if the first instance comes first, zero if they are equal, or greater than zero if the second comes first.</returns>
        public static int CompareDistance3(Vector2 position, [NotNull] GameObject x, [NotNull] Component y, bool farthest = false) => CompareDistance3(position.Expand(), x.transform.position, y.transform.position, farthest);
        
        /// <summary>
        /// Compare the two instances.
        /// </summary>
        /// <param name="position">The position to compare against.</param>
        /// <param name="x">The first instance.</param>
        /// <param name="y">The second instance.</param>
        /// <param name="farthest">If this should sort by farthest items first.</param>
        /// <returns>Less than zero if the first instance comes first, zero if they are equal, or greater than zero if the second comes first.</returns>
        public static int CompareDistance3(Vector2 position, [NotNull] GameObject x, [NotNull] GameObject y, bool farthest = false) => CompareDistance3(position.Expand(), x.transform.position, y.transform.position, farthest);
        
        /// <summary>
        /// Compare the two instances.
        /// </summary>
        /// <param name="position">The position to compare against.</param>
        /// <param name="x">The first instance.</param>
        /// <param name="y">The second instance.</param>
        /// <param name="farthest">If this should sort by farthest items first.</param>
        /// <returns>Less than zero if the first instance comes first, zero if they are equal, or greater than zero if the second comes first.</returns>
        public static int CompareDistance3(Vector3 position, Vector2 x, Vector2 y, bool farthest = false) => CompareDistance3(position, x.Expand(), y.Expand(), farthest);
        
        /// <summary>
        /// Compare the two instances.
        /// </summary>
        /// <param name="position">The position to compare against.</param>
        /// <param name="x">The first instance.</param>
        /// <param name="y">The second instance.</param>
        /// <param name="farthest">If this should sort by farthest items first.</param>
        /// <returns>Less than zero if the first instance comes first, zero if they are equal, or greater than zero if the second comes first.</returns>
        public static int CompareDistance3(Vector3 position, Vector2 x, Vector3 y, bool farthest = false) => CompareDistance3(position, x.Expand(), y, farthest);
        
        /// <summary>
        /// Compare the two instances.
        /// </summary>
        /// <param name="position">The position to compare against.</param>
        /// <param name="x">The first instance.</param>
        /// <param name="y">The second instance.</param>
        /// <param name="farthest">If this should sort by farthest items first.</param>
        /// <returns>Less than zero if the first instance comes first, zero if they are equal, or greater than zero if the second comes first.</returns>
        public static int CompareDistance3(Vector3 position, Vector2 x, [NotNull] Transform y, bool farthest = false) => CompareDistance3(position, x.Expand(), y.position, farthest);
        
        /// <summary>
        /// Compare the two instances.
        /// </summary>
        /// <param name="position">The position to compare against.</param>
        /// <param name="x">The first instance.</param>
        /// <param name="y">The second instance.</param>
        /// <param name="farthest">If this should sort by farthest items first.</param>
        /// <returns>Less than zero if the first instance comes first, zero if they are equal, or greater than zero if the second comes first.</returns>
        public static int CompareDistance3(Vector3 position, Vector2 x, [NotNull] Component y, bool farthest = false) => CompareDistance3(position, x.Expand(), y.transform.position, farthest);
        
        /// <summary>
        /// Compare the two instances.
        /// </summary>
        /// <param name="position">The position to compare against.</param>
        /// <param name="x">The first instance.</param>
        /// <param name="y">The second instance.</param>
        /// <param name="farthest">If this should sort by farthest items first.</param>
        /// <returns>Less than zero if the first instance comes first, zero if they are equal, or greater than zero if the second comes first.</returns>
        public static int CompareDistance3(Vector3 position, Vector2 x, [NotNull] GameObject y, bool farthest = false) => CompareDistance3(position, x.Expand(), y.transform.position, farthest);
        
        /// <summary>
        /// Compare the two instances.
        /// </summary>
        /// <param name="position">The position to compare against.</param>
        /// <param name="x">The first instance.</param>
        /// <param name="y">The second instance.</param>
        /// <param name="farthest">If this should sort by farthest items first.</param>
        /// <returns>Less than zero if the first instance comes first, zero if they are equal, or greater than zero if the second comes first.</returns>
        public static int CompareDistance3(Vector3 position, Vector3 x, Vector2 y, bool farthest = false) => CompareDistance3(position, x, y.Expand(), farthest);
        
        /// <summary>
        /// Compare the two instances.
        /// </summary>
        /// <param name="position">The position to compare against.</param>
        /// <param name="x">The first instance.</param>
        /// <param name="y">The second instance.</param>
        /// <param name="farthest">If this should sort by farthest items first.</param>
        /// <returns>Less than zero if the first instance comes first, zero if they are equal, or greater than zero if the second comes first.</returns>
        public static int CompareDistance3(Vector3 position, Vector3 x, Vector3 y, bool farthest = false)
        {
            float a = position.Distance3(x);
            float b = position.Distance3(y);
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
        public static int CompareDistance3(Vector3 position, Vector3 x, [NotNull] Transform y, bool farthest = false) => CompareDistance3(position, x, y.position, farthest);
        
        /// <summary>
        /// Compare the two instances.
        /// </summary>
        /// <param name="position">The position to compare against.</param>
        /// <param name="x">The first instance.</param>
        /// <param name="y">The second instance.</param>
        /// <param name="farthest">If this should sort by farthest items first.</param>
        /// <returns>Less than zero if the first instance comes first, zero if they are equal, or greater than zero if the second comes first.</returns>
        public static int CompareDistance3(Vector3 position, Vector3 x, [NotNull] Component y, bool farthest = false) => CompareDistance3(position, x, y.transform.position, farthest);
        
        /// <summary>
        /// Compare the two instances.
        /// </summary>
        /// <param name="position">The position to compare against.</param>
        /// <param name="x">The first instance.</param>
        /// <param name="y">The second instance.</param>
        /// <param name="farthest">If this should sort by farthest items first.</param>
        /// <returns>Less than zero if the first instance comes first, zero if they are equal, or greater than zero if the second comes first.</returns>
        public static int CompareDistance3(Vector3 position, Vector3 x, [NotNull] GameObject y, bool farthest = false) => CompareDistance3(position, x, y.transform.position, farthest);
        
        /// <summary>
        /// Compare the two instances.
        /// </summary>
        /// <param name="position">The position to compare against.</param>
        /// <param name="x">The first instance.</param>
        /// <param name="y">The second instance.</param>
        /// <param name="farthest">If this should sort by farthest items first.</param>
        /// <returns>Less than zero if the first instance comes first, zero if they are equal, or greater than zero if the second comes first.</returns>
        public static int CompareDistance3(Vector3 position, [NotNull] Transform x, Vector2 y, bool farthest = false) => CompareDistance3(position, x.position, y.Expand(), farthest);
        
        /// <summary>
        /// Compare the two instances.
        /// </summary>
        /// <param name="position">The position to compare against.</param>
        /// <param name="x">The first instance.</param>
        /// <param name="y">The second instance.</param>
        /// <param name="farthest">If this should sort by farthest items first.</param>
        /// <returns>Less than zero if the first instance comes first, zero if they are equal, or greater than zero if the second comes first.</returns>
        public static int CompareDistance3(Vector3 position, [NotNull] Transform x, Vector3 y, bool farthest = false) => CompareDistance3(position, x.position, y, farthest);
        
        /// <summary>
        /// Compare the two instances.
        /// </summary>
        /// <param name="position">The position to compare against.</param>
        /// <param name="x">The first instance.</param>
        /// <param name="y">The second instance.</param>
        /// <param name="farthest">If this should sort by farthest items first.</param>
        /// <returns>Less than zero if the first instance comes first, zero if they are equal, or greater than zero if the second comes first.</returns>
        public static int CompareDistance3(Vector3 position, [NotNull] Transform x, [NotNull] Transform y, bool farthest = false) => CompareDistance3(position, x.position, y.position, farthest);
        
        /// <summary>
        /// Compare the two instances.
        /// </summary>
        /// <param name="position">The position to compare against.</param>
        /// <param name="x">The first instance.</param>
        /// <param name="y">The second instance.</param>
        /// <param name="farthest">If this should sort by farthest items first.</param>
        /// <returns>Less than zero if the first instance comes first, zero if they are equal, or greater than zero if the second comes first.</returns>
        public static int CompareDistance3(Vector3 position, [NotNull] Transform x, [NotNull] Component y, bool farthest = false) => CompareDistance3(position, x.position, y.transform.position, farthest);
        
        /// <summary>
        /// Compare the two instances.
        /// </summary>
        /// <param name="position">The position to compare against.</param>
        /// <param name="x">The first instance.</param>
        /// <param name="y">The second instance.</param>
        /// <param name="farthest">If this should sort by farthest items first.</param>
        /// <returns>Less than zero if the first instance comes first, zero if they are equal, or greater than zero if the second comes first.</returns>
        public static int CompareDistance3(Vector3 position, [NotNull] Transform x, [NotNull] GameObject y, bool farthest = false) => CompareDistance3(position, x.position, y.transform.position, farthest);
        
        /// <summary>
        /// Compare the two instances.
        /// </summary>
        /// <param name="position">The position to compare against.</param>
        /// <param name="x">The first instance.</param>
        /// <param name="y">The second instance.</param>
        /// <param name="farthest">If this should sort by farthest items first.</param>
        /// <returns>Less than zero if the first instance comes first, zero if they are equal, or greater than zero if the second comes first.</returns>
        public static int CompareDistance3(Vector3 position, [NotNull] Component x, Vector2 y, bool farthest = false) => CompareDistance3(position, x.transform.position, y.Expand(), farthest);
        
        /// <summary>
        /// Compare the two instances.
        /// </summary>
        /// <param name="position">The position to compare against.</param>
        /// <param name="x">The first instance.</param>
        /// <param name="y">The second instance.</param>
        /// <param name="farthest">If this should sort by farthest items first.</param>
        /// <returns>Less than zero if the first instance comes first, zero if they are equal, or greater than zero if the second comes first.</returns>
        public static int CompareDistance3(Vector3 position, [NotNull] Component x, Vector3 y, bool farthest = false) => CompareDistance3(position, x.transform.position, y, farthest);
        
        /// <summary>
        /// Compare the two instances.
        /// </summary>
        /// <param name="position">The position to compare against.</param>
        /// <param name="x">The first instance.</param>
        /// <param name="y">The second instance.</param>
        /// <param name="farthest">If this should sort by farthest items first.</param>
        /// <returns>Less than zero if the first instance comes first, zero if they are equal, or greater than zero if the second comes first.</returns>
        public static int CompareDistance3(Vector3 position, [NotNull] Component x, [NotNull] Transform y, bool farthest = false) => CompareDistance3(position, x.transform.position, y.position, farthest);
        
        /// <summary>
        /// Compare the two instances.
        /// </summary>
        /// <param name="position">The position to compare against.</param>
        /// <param name="x">The first instance.</param>
        /// <param name="y">The second instance.</param>
        /// <param name="farthest">If this should sort by farthest items first.</param>
        /// <returns>Less than zero if the first instance comes first, zero if they are equal, or greater than zero if the second comes first.</returns>
        public static int CompareDistance3(Vector3 position, [NotNull] Component x, [NotNull] Component y, bool farthest = false) => CompareDistance3(position, x.transform.position, y.transform.position, farthest);
        
        /// <summary>
        /// Compare the two instances.
        /// </summary>
        /// <param name="position">The position to compare against.</param>
        /// <param name="x">The first instance.</param>
        /// <param name="y">The second instance.</param>
        /// <param name="farthest">If this should sort by farthest items first.</param>
        /// <returns>Less than zero if the first instance comes first, zero if they are equal, or greater than zero if the second comes first.</returns>
        public static int CompareDistance3(Vector3 position, [NotNull] Component x, [NotNull] GameObject y, bool farthest = false) => CompareDistance3(position, x.transform.position, y.transform.position, farthest);
        
        /// <summary>
        /// Compare the two instances.
        /// </summary>
        /// <param name="position">The position to compare against.</param>
        /// <param name="x">The first instance.</param>
        /// <param name="y">The second instance.</param>
        /// <param name="farthest">If this should sort by farthest items first.</param>
        /// <returns>Less than zero if the first instance comes first, zero if they are equal, or greater than zero if the second comes first.</returns>
        public static int CompareDistance3(Vector3 position, [NotNull] GameObject x, Vector2 y, bool farthest = false) => CompareDistance3(position, x.transform.position, y.Expand(), farthest);
        
        /// <summary>
        /// Compare the two instances.
        /// </summary>
        /// <param name="position">The position to compare against.</param>
        /// <param name="x">The first instance.</param>
        /// <param name="y">The second instance.</param>
        /// <param name="farthest">If this should sort by farthest items first.</param>
        /// <returns>Less than zero if the first instance comes first, zero if they are equal, or greater than zero if the second comes first.</returns>
        public static int CompareDistance3(Vector3 position, [NotNull] GameObject x, Vector3 y, bool farthest = false) => CompareDistance3(position, x.transform.position, y, farthest);
        
        /// <summary>
        /// Compare the two instances.
        /// </summary>
        /// <param name="position">The position to compare against.</param>
        /// <param name="x">The first instance.</param>
        /// <param name="y">The second instance.</param>
        /// <param name="farthest">If this should sort by farthest items first.</param>
        /// <returns>Less than zero if the first instance comes first, zero if they are equal, or greater than zero if the second comes first.</returns>
        public static int CompareDistance3(Vector3 position, [NotNull] GameObject x, [NotNull] Transform y, bool farthest = false) => CompareDistance3(position, x.transform.position, y.position, farthest);
        
        /// <summary>
        /// Compare the two instances.
        /// </summary>
        /// <param name="position">The position to compare against.</param>
        /// <param name="x">The first instance.</param>
        /// <param name="y">The second instance.</param>
        /// <param name="farthest">If this should sort by farthest items first.</param>
        /// <returns>Less than zero if the first instance comes first, zero if they are equal, or greater than zero if the second comes first.</returns>
        public static int CompareDistance3(Vector3 position, [NotNull] GameObject x, [NotNull] Component y, bool farthest = false) => CompareDistance3(position, x.transform.position, y.transform.position, farthest);
        
        /// <summary>
        /// Compare the two instances.
        /// </summary>
        /// <param name="position">The position to compare against.</param>
        /// <param name="x">The first instance.</param>
        /// <param name="y">The second instance.</param>
        /// <param name="farthest">If this should sort by farthest items first.</param>
        /// <returns>Less than zero if the first instance comes first, zero if they are equal, or greater than zero if the second comes first.</returns>
        public static int CompareDistance3(Vector3 position, [NotNull] GameObject x, [NotNull] GameObject y, bool farthest = false) => CompareDistance3(position, x.transform.position, y.transform.position, farthest);
        
        /// <summary>
        /// Compare the two instances.
        /// </summary>
        /// <param name="position">The position to compare against.</param>
        /// <param name="x">The first instance.</param>
        /// <param name="y">The second instance.</param>
        /// <param name="farthest">If this should sort by farthest items first.</param>
        /// <returns>Less than zero if the first instance comes first, zero if they are equal, or greater than zero if the second comes first.</returns>
        public static int CompareDistance3([NotNull] Transform position, Vector2 x, Vector2 y, bool farthest = false) => CompareDistance3(position.position, x.Expand(), y.Expand(), farthest);
        
        /// <summary>
        /// Compare the two instances.
        /// </summary>
        /// <param name="position">The position to compare against.</param>
        /// <param name="x">The first instance.</param>
        /// <param name="y">The second instance.</param>
        /// <param name="farthest">If this should sort by farthest items first.</param>
        /// <returns>Less than zero if the first instance comes first, zero if they are equal, or greater than zero if the second comes first.</returns>
        public static int CompareDistance3([NotNull] Transform position, Vector2 x, Vector3 y, bool farthest = false) => CompareDistance3(position.position, x.Expand(), y, farthest);
        
        /// <summary>
        /// Compare the two instances.
        /// </summary>
        /// <param name="position">The position to compare against.</param>
        /// <param name="x">The first instance.</param>
        /// <param name="y">The second instance.</param>
        /// <param name="farthest">If this should sort by farthest items first.</param>
        /// <returns>Less than zero if the first instance comes first, zero if they are equal, or greater than zero if the second comes first.</returns>
        public static int CompareDistance3([NotNull] Transform position, Vector2 x, [NotNull] Transform y, bool farthest = false) => CompareDistance3(position.position, x.Expand(), y.position, farthest);
        
        /// <summary>
        /// Compare the two instances.
        /// </summary>
        /// <param name="position">The position to compare against.</param>
        /// <param name="x">The first instance.</param>
        /// <param name="y">The second instance.</param>
        /// <param name="farthest">If this should sort by farthest items first.</param>
        /// <returns>Less than zero if the first instance comes first, zero if they are equal, or greater than zero if the second comes first.</returns>
        public static int CompareDistance3([NotNull] Transform position, Vector2 x, [NotNull] Component y, bool farthest = false) => CompareDistance3(position.position, x.Expand(), y.transform.position, farthest);
        
        /// <summary>
        /// Compare the two instances.
        /// </summary>
        /// <param name="position">The position to compare against.</param>
        /// <param name="x">The first instance.</param>
        /// <param name="y">The second instance.</param>
        /// <param name="farthest">If this should sort by farthest items first.</param>
        /// <returns>Less than zero if the first instance comes first, zero if they are equal, or greater than zero if the second comes first.</returns>
        public static int CompareDistance3([NotNull] Transform position, Vector2 x, [NotNull] GameObject y, bool farthest = false) => CompareDistance3(position.position, x.Expand(), y.transform.position, farthest);
        
        /// <summary>
        /// Compare the two instances.
        /// </summary>
        /// <param name="position">The position to compare against.</param>
        /// <param name="x">The first instance.</param>
        /// <param name="y">The second instance.</param>
        /// <param name="farthest">If this should sort by farthest items first.</param>
        /// <returns>Less than zero if the first instance comes first, zero if they are equal, or greater than zero if the second comes first.</returns>
        public static int CompareDistance3([NotNull] Transform position, Vector3 x, Vector2 y, bool farthest = false) => CompareDistance3(position.position, x, y.Expand(), farthest);
        
        /// <summary>
        /// Compare the two instances.
        /// </summary>
        /// <param name="position">The position to compare against.</param>
        /// <param name="x">The first instance.</param>
        /// <param name="y">The second instance.</param>
        /// <param name="farthest">If this should sort by farthest items first.</param>
        /// <returns>Less than zero if the first instance comes first, zero if they are equal, or greater than zero if the second comes first.</returns>
        public static int CompareDistance3([NotNull] Transform position, Vector3 x, Vector3 y, bool farthest = false) => CompareDistance3(position.position, x, y, farthest);
        
        /// <summary>
        /// Compare the two instances.
        /// </summary>
        /// <param name="position">The position to compare against.</param>
        /// <param name="x">The first instance.</param>
        /// <param name="y">The second instance.</param>
        /// <param name="farthest">If this should sort by farthest items first.</param>
        /// <returns>Less than zero if the first instance comes first, zero if they are equal, or greater than zero if the second comes first.</returns>
        public static int CompareDistance3([NotNull] Transform position, Vector3 x, [NotNull] Transform y, bool farthest = false) => CompareDistance3(position.position, x, y.position, farthest);
        
        /// <summary>
        /// Compare the two instances.
        /// </summary>
        /// <param name="position">The position to compare against.</param>
        /// <param name="x">The first instance.</param>
        /// <param name="y">The second instance.</param>
        /// <param name="farthest">If this should sort by farthest items first.</param>
        /// <returns>Less than zero if the first instance comes first, zero if they are equal, or greater than zero if the second comes first.</returns>
        public static int CompareDistance3([NotNull] Transform position, Vector3 x, [NotNull] Component y, bool farthest = false) => CompareDistance3(position.position, x, y.transform.position, farthest);
		
        /// <summary>
        /// Compare the two instances.
        /// </summary>
        /// <param name="position">The position to compare against.</param>
        /// <param name="x">The first instance.</param>
        /// <param name="y">The second instance.</param>
        /// <param name="farthest">If this should sort by farthest items first.</param>
        /// <returns>Less than zero if the first instance comes first, zero if they are equal, or greater than zero if the second comes first.</returns>
        public static int CompareDistance3([NotNull] Transform position, Vector3 x, [NotNull] GameObject y, bool farthest = false) => CompareDistance3(position.position, x, y.transform.position, farthest);
        
        /// <summary>
        /// Compare the two instances.
        /// </summary>
        /// <param name="position">The position to compare against.</param>
        /// <param name="x">The first instance.</param>
        /// <param name="y">The second instance.</param>
        /// <param name="farthest">If this should sort by farthest items first.</param>
        /// <returns>Less than zero if the first instance comes first, zero if they are equal, or greater than zero if the second comes first.</returns>
        public static int CompareDistance3([NotNull] Transform position, [NotNull] Transform x, Vector2 y, bool farthest = false) => CompareDistance3(position.position, x.position, y.Expand(), farthest);
        
        /// <summary>
        /// Compare the two instances.
        /// </summary>
        /// <param name="position">The position to compare against.</param>
        /// <param name="x">The first instance.</param>
        /// <param name="y">The second instance.</param>
        /// <param name="farthest">If this should sort by farthest items first.</param>
        /// <returns>Less than zero if the first instance comes first, zero if they are equal, or greater than zero if the second comes first.</returns>
        public static int CompareDistance3([NotNull] Transform position, [NotNull] Transform x, Vector3 y, bool farthest = false) => CompareDistance3(position.position, x.position, y, farthest);
        
        /// <summary>
        /// Compare the two instances.
        /// </summary>
        /// <param name="position">The position to compare against.</param>
        /// <param name="x">The first instance.</param>
        /// <param name="y">The second instance.</param>
        /// <param name="farthest">If this should sort by farthest items first.</param>
        /// <returns>Less than zero if the first instance comes first, zero if they are equal, or greater than zero if the second comes first.</returns>
        public static int CompareDistance3([NotNull] Transform position, [NotNull] Transform x, [NotNull] Transform y, bool farthest = false) => CompareDistance3(position.position, x.position, y.position, farthest);
        
        /// <summary>
        /// Compare the two instances.
        /// </summary>
        /// <param name="position">The position to compare against.</param>
        /// <param name="x">The first instance.</param>
        /// <param name="y">The second instance.</param>
        /// <param name="farthest">If this should sort by farthest items first.</param>
        /// <returns>Less than zero if the first instance comes first, zero if they are equal, or greater than zero if the second comes first.</returns>
        public static int CompareDistance3([NotNull] Transform position, [NotNull] Transform x, [NotNull] Component y, bool farthest = false) => CompareDistance3(position.position, x.position, y.transform.position, farthest);
        
        /// <summary>
        /// Compare the two instances.
        /// </summary>
        /// <param name="position">The position to compare against.</param>
        /// <param name="x">The first instance.</param>
        /// <param name="y">The second instance.</param>
        /// <param name="farthest">If this should sort by farthest items first.</param>
        /// <returns>Less than zero if the first instance comes first, zero if they are equal, or greater than zero if the second comes first.</returns>
        public static int CompareDistance3([NotNull] Transform position, [NotNull] Transform x, [NotNull] GameObject y, bool farthest = false) => CompareDistance3(position.position, x.position, y.transform.position, farthest);
        
        /// <summary>
        /// Compare the two instances.
        /// </summary>
        /// <param name="position">The position to compare against.</param>
        /// <param name="x">The first instance.</param>
        /// <param name="y">The second instance.</param>
        /// <param name="farthest">If this should sort by farthest items first.</param>
        /// <returns>Less than zero if the first instance comes first, zero if they are equal, or greater than zero if the second comes first.</returns>
        public static int CompareDistance3([NotNull] Transform position, [NotNull] Component x, Vector2 y, bool farthest = false) => CompareDistance3(position.position, x.transform.position, y.Expand(), farthest);
        
        /// <summary>
        /// Compare the two instances.
        /// </summary>
        /// <param name="position">The position to compare against.</param>
        /// <param name="x">The first instance.</param>
        /// <param name="y">The second instance.</param>
        /// <param name="farthest">If this should sort by farthest items first.</param>
        /// <returns>Less than zero if the first instance comes first, zero if they are equal, or greater than zero if the second comes first.</returns>
        public static int CompareDistance3([NotNull] Transform position, [NotNull] Component x, Vector3 y, bool farthest = false) => CompareDistance3(position.position, x.transform.position, y, farthest);
        
        /// <summary>
        /// Compare the two instances.
        /// </summary>
        /// <param name="position">The position to compare against.</param>
        /// <param name="x">The first instance.</param>
        /// <param name="y">The second instance.</param>
        /// <param name="farthest">If this should sort by farthest items first.</param>
        /// <returns>Less than zero if the first instance comes first, zero if they are equal, or greater than zero if the second comes first.</returns>
        public static int CompareDistance3([NotNull] Transform position, [NotNull] Component x, [NotNull] Transform y, bool farthest = false) => CompareDistance3(position.position, x.transform.position, y.position, farthest);
        
        /// <summary>
        /// Compare the two instances.
        /// </summary>
        /// <param name="position">The position to compare against.</param>
        /// <param name="x">The first instance.</param>
        /// <param name="y">The second instance.</param>
        /// <param name="farthest">If this should sort by farthest items first.</param>
        /// <returns>Less than zero if the first instance comes first, zero if they are equal, or greater than zero if the second comes first.</returns>
        public static int CompareDistance3([NotNull] Transform position, [NotNull] Component x, [NotNull] Component y, bool farthest = false) => CompareDistance3(position.position, x.transform.position, y.transform.position, farthest);
        
        /// <summary>
        /// Compare the two instances.
        /// </summary>
        /// <param name="position">The position to compare against.</param>
        /// <param name="x">The first instance.</param>
        /// <param name="y">The second instance.</param>
        /// <param name="farthest">If this should sort by farthest items first.</param>
        /// <returns>Less than zero if the first instance comes first, zero if they are equal, or greater than zero if the second comes first.</returns>
        public static int CompareDistance3([NotNull] Transform position, [NotNull] Component x, [NotNull] GameObject y, bool farthest = false) => CompareDistance3(position.position, x.transform.position, y.transform.position, farthest);
        
        /// <summary>
        /// Compare the two instances.
        /// </summary>
        /// <param name="position">The position to compare against.</param>
        /// <param name="x">The first instance.</param>
        /// <param name="y">The second instance.</param>
        /// <param name="farthest">If this should sort by farthest items first.</param>
        /// <returns>Less than zero if the first instance comes first, zero if they are equal, or greater than zero if the second comes first.</returns>
        public static int CompareDistance3([NotNull] Transform position, [NotNull] GameObject x, Vector2 y, bool farthest = false) => CompareDistance3(position.position, x.transform.position, y.Expand(), farthest);
        
        /// <summary>
        /// Compare the two instances.
        /// </summary>
        /// <param name="position">The position to compare against.</param>
        /// <param name="x">The first instance.</param>
        /// <param name="y">The second instance.</param>
        /// <param name="farthest">If this should sort by farthest items first.</param>
        /// <returns>Less than zero if the first instance comes first, zero if they are equal, or greater than zero if the second comes first.</returns>
        public static int CompareDistance3([NotNull] Transform position, [NotNull] GameObject x, Vector3 y, bool farthest = false) => CompareDistance3(position.position, x.transform.position, y, farthest);
        
        /// <summary>
        /// Compare the two instances.
        /// </summary>
        /// <param name="position">The position to compare against.</param>
        /// <param name="x">The first instance.</param>
        /// <param name="y">The second instance.</param>
        /// <param name="farthest">If this should sort by farthest items first.</param>
        /// <returns>Less than zero if the first instance comes first, zero if they are equal, or greater than zero if the second comes first.</returns>
        public static int CompareDistance3([NotNull] Transform position, [NotNull] GameObject x, [NotNull] Transform y, bool farthest = false) => CompareDistance3(position.position, x.transform.position, y.position, farthest);
        
        /// <summary>
        /// Compare the two instances.
        /// </summary>
        /// <param name="position">The position to compare against.</param>
        /// <param name="x">The first instance.</param>
        /// <param name="y">The second instance.</param>
        /// <param name="farthest">If this should sort by farthest items first.</param>
        /// <returns>Less than zero if the first instance comes first, zero if they are equal, or greater than zero if the second comes first.</returns>
        public static int CompareDistance3([NotNull] Transform position, [NotNull] GameObject x, [NotNull] Component y, bool farthest = false) => CompareDistance3(position.position, x.transform.position, y.transform.position, farthest);
        
        /// <summary>
        /// Compare the two instances.
        /// </summary>
        /// <param name="position">The position to compare against.</param>
        /// <param name="x">The first instance.</param>
        /// <param name="y">The second instance.</param>
        /// <param name="farthest">If this should sort by farthest items first.</param>
        /// <returns>Less than zero if the first instance comes first, zero if they are equal, or greater than zero if the second comes first.</returns>
        public static int CompareDistance3([NotNull] Transform position, [NotNull] GameObject x, [NotNull] GameObject y, bool farthest = false) => CompareDistance3(position.position, x.transform.position, y.transform.position, farthest);
        
        /// <summary>
        /// Compare the two instances.
        /// </summary>
        /// <param name="position">The position to compare against.</param>
        /// <param name="x">The first instance.</param>
        /// <param name="y">The second instance.</param>
        /// <param name="farthest">If this should sort by farthest items first.</param>
        /// <returns>Less than zero if the first instance comes first, zero if they are equal, or greater than zero if the second comes first.</returns>
        public static int CompareDistance3([NotNull] Component position, Vector2 x, Vector2 y, bool farthest = false) => CompareDistance3(position.transform.position, x.Expand(), y.Expand(), farthest);
        
        /// <summary>
        /// Compare the two instances.
        /// </summary>
        /// <param name="position">The position to compare against.</param>
        /// <param name="x">The first instance.</param>
        /// <param name="y">The second instance.</param>
        /// <param name="farthest">If this should sort by farthest items first.</param>
        /// <returns>Less than zero if the first instance comes first, zero if they are equal, or greater than zero if the second comes first.</returns>
        public static int CompareDistance3([NotNull] Component position, Vector2 x, Vector3 y, bool farthest = false) => CompareDistance3(position.transform.position, x.Expand(), y, farthest);
        
        /// <summary>
        /// Compare the two instances.
        /// </summary>
        /// <param name="position">The position to compare against.</param>
        /// <param name="x">The first instance.</param>
        /// <param name="y">The second instance.</param>
        /// <param name="farthest">If this should sort by farthest items first.</param>
        /// <returns>Less than zero if the first instance comes first, zero if they are equal, or greater than zero if the second comes first.</returns>
        public static int CompareDistance3([NotNull] Component position, Vector2 x, [NotNull] Transform y, bool farthest = false) => CompareDistance3(position.transform.position, x.Expand(), y.position, farthest);
        
        /// <summary>
        /// Compare the two instances.
        /// </summary>
        /// <param name="position">The position to compare against.</param>
        /// <param name="x">The first instance.</param>
        /// <param name="y">The second instance.</param>
        /// <param name="farthest">If this should sort by farthest items first.</param>
        /// <returns>Less than zero if the first instance comes first, zero if they are equal, or greater than zero if the second comes first.</returns>
        public static int CompareDistance3([NotNull] Component position, Vector2 x, [NotNull] Component y, bool farthest = false) => CompareDistance3(position.transform.position, x.Expand(), y.transform.position, farthest);
        
        /// <summary>
        /// Compare the two instances.
        /// </summary>
        /// <param name="position">The position to compare against.</param>
        /// <param name="x">The first instance.</param>
        /// <param name="y">The second instance.</param>
        /// <param name="farthest">If this should sort by farthest items first.</param>
        /// <returns>Less than zero if the first instance comes first, zero if they are equal, or greater than zero if the second comes first.</returns>
        public static int CompareDistance3([NotNull] Component position, Vector2 x, [NotNull] GameObject y, bool farthest = false) => CompareDistance3(position.transform.position, x.Expand(), y.transform.position, farthest);
        
        /// <summary>
        /// Compare the two instances.
        /// </summary>
        /// <param name="position">The position to compare against.</param>
        /// <param name="x">The first instance.</param>
        /// <param name="y">The second instance.</param>
        /// <param name="farthest">If this should sort by farthest items first.</param>
        /// <returns>Less than zero if the first instance comes first, zero if they are equal, or greater than zero if the second comes first.</returns>
        public static int CompareDistance3([NotNull] Component position, Vector3 x, Vector2 y, bool farthest = false) => CompareDistance3(position.transform.position, x, y.Expand(), farthest);
        
        /// <summary>
        /// Compare the two instances.
        /// </summary>
        /// <param name="position">The position to compare against.</param>
        /// <param name="x">The first instance.</param>
        /// <param name="y">The second instance.</param>
        /// <param name="farthest">If this should sort by farthest items first.</param>
        /// <returns>Less than zero if the first instance comes first, zero if they are equal, or greater than zero if the second comes first.</returns>
        public static int CompareDistance3([NotNull] Component position, Vector3 x, Vector3 y, bool farthest = false) => CompareDistance3(position.transform.position, x, y, farthest);
        
        /// <summary>
        /// Compare the two instances.
        /// </summary>
        /// <param name="position">The position to compare against.</param>
        /// <param name="x">The first instance.</param>
        /// <param name="y">The second instance.</param>
        /// <param name="farthest">If this should sort by farthest items first.</param>
        /// <returns>Less than zero if the first instance comes first, zero if they are equal, or greater than zero if the second comes first.</returns>
        public static int CompareDistance3([NotNull] Component position, Vector3 x, [NotNull] Transform y, bool farthest = false) => CompareDistance3(position.transform.position, x, y.position, farthest);
        
        /// <summary>
        /// Compare the two instances.
        /// </summary>
        /// <param name="position">The position to compare against.</param>
        /// <param name="x">The first instance.</param>
        /// <param name="y">The second instance.</param>
        /// <param name="farthest">If this should sort by farthest items first.</param>
        /// <returns>Less than zero if the first instance comes first, zero if they are equal, or greater than zero if the second comes first.</returns>
        public static int CompareDistance3([NotNull] Component position, Vector3 x, [NotNull] Component y, bool farthest = false) => CompareDistance3(position.transform.position, x, y.transform.position, farthest);
		
        /// <summary>
        /// Compare the two instances.
        /// </summary>
        /// <param name="position">The position to compare against.</param>
        /// <param name="x">The first instance.</param>
        /// <param name="y">The second instance.</param>
        /// <param name="farthest">If this should sort by farthest items first.</param>
        /// <returns>Less than zero if the first instance comes first, zero if they are equal, or greater than zero if the second comes first.</returns>
        public static int CompareDistance3([NotNull] Component position, Vector3 x, [NotNull] GameObject y, bool farthest = false) => CompareDistance3(position.transform.position, x, y.transform.position, farthest);
        
        /// <summary>
        /// Compare the two instances.
        /// </summary>
        /// <param name="position">The position to compare against.</param>
        /// <param name="x">The first instance.</param>
        /// <param name="y">The second instance.</param>
        /// <param name="farthest">If this should sort by farthest items first.</param>
        /// <returns>Less than zero if the first instance comes first, zero if they are equal, or greater than zero if the second comes first.</returns>
        public static int CompareDistance3([NotNull] Component position, [NotNull] Transform x, Vector2 y, bool farthest = false) => CompareDistance3(position.transform.position, x.position, y.Expand(), farthest);
        
        /// <summary>
        /// Compare the two instances.
        /// </summary>
        /// <param name="position">The position to compare against.</param>
        /// <param name="x">The first instance.</param>
        /// <param name="y">The second instance.</param>
        /// <param name="farthest">If this should sort by farthest items first.</param>
        /// <returns>Less than zero if the first instance comes first, zero if they are equal, or greater than zero if the second comes first.</returns>
        public static int CompareDistance3([NotNull] Component position, [NotNull] Transform x, Vector3 y, bool farthest = false) => CompareDistance3(position.transform.position, x.position, y, farthest);
        
        /// <summary>
        /// Compare the two instances.
        /// </summary>
        /// <param name="position">The position to compare against.</param>
        /// <param name="x">The first instance.</param>
        /// <param name="y">The second instance.</param>
        /// <param name="farthest">If this should sort by farthest items first.</param>
        /// <returns>Less than zero if the first instance comes first, zero if they are equal, or greater than zero if the second comes first.</returns>
        public static int CompareDistance3([NotNull] Component position, [NotNull] Transform x, [NotNull] Transform y, bool farthest = false) => CompareDistance3(position.transform.position, x.position, y.position, farthest);
        
        /// <summary>
        /// Compare the two instances.
        /// </summary>
        /// <param name="position">The position to compare against.</param>
        /// <param name="x">The first instance.</param>
        /// <param name="y">The second instance.</param>
        /// <param name="farthest">If this should sort by farthest items first.</param>
        /// <returns>Less than zero if the first instance comes first, zero if they are equal, or greater than zero if the second comes first.</returns>
        public static int CompareDistance3([NotNull] Component position, [NotNull] Transform x, [NotNull] Component y, bool farthest = false) => CompareDistance3(position.transform.position, x.position, y.transform.position, farthest);
        
        /// <summary>
        /// Compare the two instances.
        /// </summary>
        /// <param name="position">The position to compare against.</param>
        /// <param name="x">The first instance.</param>
        /// <param name="y">The second instance.</param>
        /// <param name="farthest">If this should sort by farthest items first.</param>
        /// <returns>Less than zero if the first instance comes first, zero if they are equal, or greater than zero if the second comes first.</returns>
        public static int CompareDistance3([NotNull] Component position, [NotNull] Transform x, [NotNull] GameObject y, bool farthest = false) => CompareDistance3(position.transform.position, x.position, y.transform.position, farthest);
        
        /// <summary>
        /// Compare the two instances.
        /// </summary>
        /// <param name="position">The position to compare against.</param>
        /// <param name="x">The first instance.</param>
        /// <param name="y">The second instance.</param>
        /// <param name="farthest">If this should sort by farthest items first.</param>
        /// <returns>Less than zero if the first instance comes first, zero if they are equal, or greater than zero if the second comes first.</returns>
        public static int CompareDistance3([NotNull] Component position, [NotNull] Component x, Vector2 y, bool farthest = false) => CompareDistance3(position.transform.position, x.transform.position, y.Expand(), farthest);
        
        /// <summary>
        /// Compare the two instances.
        /// </summary>
        /// <param name="position">The position to compare against.</param>
        /// <param name="x">The first instance.</param>
        /// <param name="y">The second instance.</param>
        /// <param name="farthest">If this should sort by farthest items first.</param>
        /// <returns>Less than zero if the first instance comes first, zero if they are equal, or greater than zero if the second comes first.</returns>
        public static int CompareDistance3([NotNull] Component position, [NotNull] Component x, Vector3 y, bool farthest = false) => CompareDistance3(position.transform.position, x.transform.position, y, farthest);
        
        /// <summary>
        /// Compare the two instances.
        /// </summary>
        /// <param name="position">The position to compare against.</param>
        /// <param name="x">The first instance.</param>
        /// <param name="y">The second instance.</param>
        /// <param name="farthest">If this should sort by farthest items first.</param>
        /// <returns>Less than zero if the first instance comes first, zero if they are equal, or greater than zero if the second comes first.</returns>
        public static int CompareDistance3([NotNull] Component position, [NotNull] Component x, [NotNull] Transform y, bool farthest = false) => CompareDistance3(position.transform.position, x.transform.position, y.position, farthest);
        
        /// <summary>
        /// Compare the two instances.
        /// </summary>
        /// <param name="position">The position to compare against.</param>
        /// <param name="x">The first instance.</param>
        /// <param name="y">The second instance.</param>
        /// <param name="farthest">If this should sort by farthest items first.</param>
        /// <returns>Less than zero if the first instance comes first, zero if they are equal, or greater than zero if the second comes first.</returns>
        public static int CompareDistance3([NotNull] Component position, [NotNull] Component x, [NotNull] Component y, bool farthest = false) => CompareDistance3(position.transform.position, x.transform.position, y.transform.position, farthest);
        
        /// <summary>
        /// Compare the two instances.
        /// </summary>
        /// <param name="position">The position to compare against.</param>
        /// <param name="x">The first instance.</param>
        /// <param name="y">The second instance.</param>
        /// <param name="farthest">If this should sort by farthest items first.</param>
        /// <returns>Less than zero if the first instance comes first, zero if they are equal, or greater than zero if the second comes first.</returns>
        public static int CompareDistance3([NotNull] Component position, [NotNull] Component x, [NotNull] GameObject y, bool farthest = false) => CompareDistance3(position.transform.position, x.transform.position, y.transform.position, farthest);
        
        /// <summary>
        /// Compare the two instances.
        /// </summary>
        /// <param name="position">The position to compare against.</param>
        /// <param name="x">The first instance.</param>
        /// <param name="y">The second instance.</param>
        /// <param name="farthest">If this should sort by farthest items first.</param>
        /// <returns>Less than zero if the first instance comes first, zero if they are equal, or greater than zero if the second comes first.</returns>
        public static int CompareDistance3([NotNull] Component position, [NotNull] GameObject x, Vector2 y, bool farthest = false) => CompareDistance3(position.transform.position, x.transform.position, y.Expand(), farthest);
        
        /// <summary>
        /// Compare the two instances.
        /// </summary>
        /// <param name="position">The position to compare against.</param>
        /// <param name="x">The first instance.</param>
        /// <param name="y">The second instance.</param>
        /// <param name="farthest">If this should sort by farthest items first.</param>
        /// <returns>Less than zero if the first instance comes first, zero if they are equal, or greater than zero if the second comes first.</returns>
        public static int CompareDistance3([NotNull] Component position, [NotNull] GameObject x, Vector3 y, bool farthest = false) => CompareDistance3(position.transform.position, x.transform.position, y, farthest);
        
        /// <summary>
        /// Compare the two instances.
        /// </summary>
        /// <param name="position">The position to compare against.</param>
        /// <param name="x">The first instance.</param>
        /// <param name="y">The second instance.</param>
        /// <param name="farthest">If this should sort by farthest items first.</param>
        /// <returns>Less than zero if the first instance comes first, zero if they are equal, or greater than zero if the second comes first.</returns>
        public static int CompareDistance3([NotNull] Component position, [NotNull] GameObject x, [NotNull] Transform y, bool farthest = false) => CompareDistance3(position.transform.position, x.transform.position, y.position, farthest);
        
        /// <summary>
        /// Compare the two instances.
        /// </summary>
        /// <param name="position">The position to compare against.</param>
        /// <param name="x">The first instance.</param>
        /// <param name="y">The second instance.</param>
        /// <param name="farthest">If this should sort by farthest items first.</param>
        /// <returns>Less than zero if the first instance comes first, zero if they are equal, or greater than zero if the second comes first.</returns>
        public static int CompareDistance3([NotNull] Component position, [NotNull] GameObject x, [NotNull] Component y, bool farthest = false) => CompareDistance3(position.transform.position, x.transform.position, y.transform.position, farthest);
        
        /// <summary>
        /// Compare the two instances.
        /// </summary>
        /// <param name="position">The position to compare against.</param>
        /// <param name="x">The first instance.</param>
        /// <param name="y">The second instance.</param>
        /// <param name="farthest">If this should sort by farthest items first.</param>
        /// <returns>Less than zero if the first instance comes first, zero if they are equal, or greater than zero if the second comes first.</returns>
        public static int CompareDistance3([NotNull] Component position, [NotNull] GameObject x, [NotNull] GameObject y, bool farthest = false) => CompareDistance3(position.transform.position, x.transform.position, y.transform.position, farthest);
        
        /// <summary>
        /// Compare the two instances.
        /// </summary>
        /// <param name="position">The position to compare against.</param>
        /// <param name="x">The first instance.</param>
        /// <param name="y">The second instance.</param>
        /// <param name="farthest">If this should sort by farthest items first.</param>
        /// <returns>Less than zero if the first instance comes first, zero if they are equal, or greater than zero if the second comes first.</returns>
        public static int CompareDistance3([NotNull] GameObject position, Vector2 x, Vector2 y, bool farthest = false) => CompareDistance3(position.transform.position, x.Expand(), y.Expand(), farthest);
        
        /// <summary>
        /// Compare the two instances.
        /// </summary>
        /// <param name="position">The position to compare against.</param>
        /// <param name="x">The first instance.</param>
        /// <param name="y">The second instance.</param>
        /// <param name="farthest">If this should sort by farthest items first.</param>
        /// <returns>Less than zero if the first instance comes first, zero if they are equal, or greater than zero if the second comes first.</returns>
        public static int CompareDistance3([NotNull] GameObject position, Vector2 x, Vector3 y, bool farthest = false) => CompareDistance3(position.transform.position, x.Expand(), y, farthest);
        
        /// <summary>
        /// Compare the two instances.
        /// </summary>
        /// <param name="position">The position to compare against.</param>
        /// <param name="x">The first instance.</param>
        /// <param name="y">The second instance.</param>
        /// <param name="farthest">If this should sort by farthest items first.</param>
        /// <returns>Less than zero if the first instance comes first, zero if they are equal, or greater than zero if the second comes first.</returns>
        public static int CompareDistance3([NotNull] GameObject position, Vector2 x, [NotNull] Transform y, bool farthest = false) => CompareDistance3(position.transform.position, x.Expand(), y.position, farthest);
        
        /// <summary>
        /// Compare the two instances.
        /// </summary>
        /// <param name="position">The position to compare against.</param>
        /// <param name="x">The first instance.</param>
        /// <param name="y">The second instance.</param>
        /// <param name="farthest">If this should sort by farthest items first.</param>
        /// <returns>Less than zero if the first instance comes first, zero if they are equal, or greater than zero if the second comes first.</returns>
        public static int CompareDistance3([NotNull] GameObject position, Vector2 x, [NotNull] Component y, bool farthest = false) => CompareDistance3(position.transform.position, x.Expand(), y.transform.position, farthest);
        
        /// <summary>
        /// Compare the two instances.
        /// </summary>
        /// <param name="position">The position to compare against.</param>
        /// <param name="x">The first instance.</param>
        /// <param name="y">The second instance.</param>
        /// <param name="farthest">If this should sort by farthest items first.</param>
        /// <returns>Less than zero if the first instance comes first, zero if they are equal, or greater than zero if the second comes first.</returns>
        public static int CompareDistance3([NotNull] GameObject position, Vector2 x, [NotNull] GameObject y, bool farthest = false) => CompareDistance3(position.transform.position, x.Expand(), y.transform.position, farthest);
        
        /// <summary>
        /// Compare the two instances.
        /// </summary>
        /// <param name="position">The position to compare against.</param>
        /// <param name="x">The first instance.</param>
        /// <param name="y">The second instance.</param>
        /// <param name="farthest">If this should sort by farthest items first.</param>
        /// <returns>Less than zero if the first instance comes first, zero if they are equal, or greater than zero if the second comes first.</returns>
        public static int CompareDistance3([NotNull] GameObject position, Vector3 x, Vector2 y, bool farthest = false) => CompareDistance3(position.transform.position, x, y.Expand(), farthest);
        
        /// <summary>
        /// Compare the two instances.
        /// </summary>
        /// <param name="position">The position to compare against.</param>
        /// <param name="x">The first instance.</param>
        /// <param name="y">The second instance.</param>
        /// <param name="farthest">If this should sort by farthest items first.</param>
        /// <returns>Less than zero if the first instance comes first, zero if they are equal, or greater than zero if the second comes first.</returns>
        public static int CompareDistance3([NotNull] GameObject position, Vector3 x, Vector3 y, bool farthest = false) => CompareDistance3(position.transform.position, x, y, farthest);
        
        /// <summary>
        /// Compare the two instances.
        /// </summary>
        /// <param name="position">The position to compare against.</param>
        /// <param name="x">The first instance.</param>
        /// <param name="y">The second instance.</param>
        /// <param name="farthest">If this should sort by farthest items first.</param>
        /// <returns>Less than zero if the first instance comes first, zero if they are equal, or greater than zero if the second comes first.</returns>
        public static int CompareDistance3([NotNull] GameObject position, Vector3 x, [NotNull] Transform y, bool farthest = false) => CompareDistance3(position.transform.position, x, y.position, farthest);
        
        /// <summary>
        /// Compare the two instances.
        /// </summary>
        /// <param name="position">The position to compare against.</param>
        /// <param name="x">The first instance.</param>
        /// <param name="y">The second instance.</param>
        /// <param name="farthest">If this should sort by farthest items first.</param>
        /// <returns>Less than zero if the first instance comes first, zero if they are equal, or greater than zero if the second comes first.</returns>
        public static int CompareDistance3([NotNull] GameObject position, Vector3 x, [NotNull] Component y, bool farthest = false) => CompareDistance3(position.transform.position, x, y.transform.position, farthest);
		
        /// <summary>
        /// Compare the two instances.
        /// </summary>
        /// <param name="position">The position to compare against.</param>
        /// <param name="x">The first instance.</param>
        /// <param name="y">The second instance.</param>
        /// <param name="farthest">If this should sort by farthest items first.</param>
        /// <returns>Less than zero if the first instance comes first, zero if they are equal, or greater than zero if the second comes first.</returns>
        public static int CompareDistance3([NotNull] GameObject position, Vector3 x, [NotNull] GameObject y, bool farthest = false) => CompareDistance3(position.transform.position, x, y.transform.position, farthest);
        
        /// <summary>
        /// Compare the two instances.
        /// </summary>
        /// <param name="position">The position to compare against.</param>
        /// <param name="x">The first instance.</param>
        /// <param name="y">The second instance.</param>
        /// <param name="farthest">If this should sort by farthest items first.</param>
        /// <returns>Less than zero if the first instance comes first, zero if they are equal, or greater than zero if the second comes first.</returns>
        public static int CompareDistance3([NotNull] GameObject position, [NotNull] Transform x, Vector2 y, bool farthest = false) => CompareDistance3(position.transform.position, x.position, y.Expand(), farthest);
        
        /// <summary>
        /// Compare the two instances.
        /// </summary>
        /// <param name="position">The position to compare against.</param>
        /// <param name="x">The first instance.</param>
        /// <param name="y">The second instance.</param>
        /// <param name="farthest">If this should sort by farthest items first.</param>
        /// <returns>Less than zero if the first instance comes first, zero if they are equal, or greater than zero if the second comes first.</returns>
        public static int CompareDistance3([NotNull] GameObject position, [NotNull] Transform x, Vector3 y, bool farthest = false) => CompareDistance3(position.transform.position, x.position, y, farthest);
        
        /// <summary>
        /// Compare the two instances.
        /// </summary>
        /// <param name="position">The position to compare against.</param>
        /// <param name="x">The first instance.</param>
        /// <param name="y">The second instance.</param>
        /// <param name="farthest">If this should sort by farthest items first.</param>
        /// <returns>Less than zero if the first instance comes first, zero if they are equal, or greater than zero if the second comes first.</returns>
        public static int CompareDistance3([NotNull] GameObject position, [NotNull] Transform x, [NotNull] Transform y, bool farthest = false) => CompareDistance3(position.transform.position, x.position, y.position, farthest);
        
        /// <summary>
        /// Compare the two instances.
        /// </summary>
        /// <param name="position">The position to compare against.</param>
        /// <param name="x">The first instance.</param>
        /// <param name="y">The second instance.</param>
        /// <param name="farthest">If this should sort by farthest items first.</param>
        /// <returns>Less than zero if the first instance comes first, zero if they are equal, or greater than zero if the second comes first.</returns>
        public static int CompareDistance3([NotNull] GameObject position, [NotNull] Transform x, [NotNull] Component y, bool farthest = false) => CompareDistance3(position.transform.position, x.position, y.transform.position, farthest);
        
        /// <summary>
        /// Compare the two instances.
        /// </summary>
        /// <param name="position">The position to compare against.</param>
        /// <param name="x">The first instance.</param>
        /// <param name="y">The second instance.</param>
        /// <param name="farthest">If this should sort by farthest items first.</param>
        /// <returns>Less than zero if the first instance comes first, zero if they are equal, or greater than zero if the second comes first.</returns>
        public static int CompareDistance3([NotNull] GameObject position, [NotNull] Transform x, [NotNull] GameObject y, bool farthest = false) => CompareDistance3(position.transform.position, x.position, y.transform.position, farthest);
        
        /// <summary>
        /// Compare the two instances.
        /// </summary>
        /// <param name="position">The position to compare against.</param>
        /// <param name="x">The first instance.</param>
        /// <param name="y">The second instance.</param>
        /// <param name="farthest">If this should sort by farthest items first.</param>
        /// <returns>Less than zero if the first instance comes first, zero if they are equal, or greater than zero if the second comes first.</returns>
        public static int CompareDistance3([NotNull] GameObject position, [NotNull] Component x, Vector2 y, bool farthest = false) => CompareDistance3(position.transform.position, x.transform.position, y.Expand(), farthest);
        
        /// <summary>
        /// Compare the two instances.
        /// </summary>
        /// <param name="position">The position to compare against.</param>
        /// <param name="x">The first instance.</param>
        /// <param name="y">The second instance.</param>
        /// <param name="farthest">If this should sort by farthest items first.</param>
        /// <returns>Less than zero if the first instance comes first, zero if they are equal, or greater than zero if the second comes first.</returns>
        public static int CompareDistance3([NotNull] GameObject position, [NotNull] Component x, Vector3 y, bool farthest = false) => CompareDistance3(position.transform.position, x.transform.position, y, farthest);
        
        /// <summary>
        /// Compare the two instances.
        /// </summary>
        /// <param name="position">The position to compare against.</param>
        /// <param name="x">The first instance.</param>
        /// <param name="y">The second instance.</param>
        /// <param name="farthest">If this should sort by farthest items first.</param>
        /// <returns>Less than zero if the first instance comes first, zero if they are equal, or greater than zero if the second comes first.</returns>
        public static int CompareDistance3([NotNull] GameObject position, [NotNull] Component x, [NotNull] Transform y, bool farthest = false) => CompareDistance3(position.transform.position, x.transform.position, y.position, farthest);
        
        /// <summary>
        /// Compare the two instances.
        /// </summary>
        /// <param name="position">The position to compare against.</param>
        /// <param name="x">The first instance.</param>
        /// <param name="y">The second instance.</param>
        /// <param name="farthest">If this should sort by farthest items first.</param>
        /// <returns>Less than zero if the first instance comes first, zero if they are equal, or greater than zero if the second comes first.</returns>
        public static int CompareDistance3([NotNull] GameObject position, [NotNull] Component x, [NotNull] Component y, bool farthest = false) => CompareDistance3(position.transform.position, x.transform.position, y.transform.position, farthest);
        
        /// <summary>
        /// Compare the two instances.
        /// </summary>
        /// <param name="position">The position to compare against.</param>
        /// <param name="x">The first instance.</param>
        /// <param name="y">The second instance.</param>
        /// <param name="farthest">If this should sort by farthest items first.</param>
        /// <returns>Less than zero if the first instance comes first, zero if they are equal, or greater than zero if the second comes first.</returns>
        public static int CompareDistance3([NotNull] GameObject position, [NotNull] Component x, [NotNull] GameObject y, bool farthest = false) => CompareDistance3(position.transform.position, x.transform.position, y.transform.position, farthest);
        
        /// <summary>
        /// Compare the two instances.
        /// </summary>
        /// <param name="position">The position to compare against.</param>
        /// <param name="x">The first instance.</param>
        /// <param name="y">The second instance.</param>
        /// <param name="farthest">If this should sort by farthest items first.</param>
        /// <returns>Less than zero if the first instance comes first, zero if they are equal, or greater than zero if the second comes first.</returns>
        public static int CompareDistance3([NotNull] GameObject position, [NotNull] GameObject x, Vector2 y, bool farthest = false) => CompareDistance3(position.transform.position, x.transform.position, y.Expand(), farthest);
        
        /// <summary>
        /// Compare the two instances.
        /// </summary>
        /// <param name="position">The position to compare against.</param>
        /// <param name="x">The first instance.</param>
        /// <param name="y">The second instance.</param>
        /// <param name="farthest">If this should sort by farthest items first.</param>
        /// <returns>Less than zero if the first instance comes first, zero if they are equal, or greater than zero if the second comes first.</returns>
        public static int CompareDistance3([NotNull] GameObject position, [NotNull] GameObject x, Vector3 y, bool farthest = false) => CompareDistance3(position.transform.position, x.transform.position, y, farthest);
        
        /// <summary>
        /// Compare the two instances.
        /// </summary>
        /// <param name="position">The position to compare against.</param>
        /// <param name="x">The first instance.</param>
        /// <param name="y">The second instance.</param>
        /// <param name="farthest">If this should sort by farthest items first.</param>
        /// <returns>Less than zero if the first instance comes first, zero if they are equal, or greater than zero if the second comes first.</returns>
        public static int CompareDistance3([NotNull] GameObject position, [NotNull] GameObject x, [NotNull] Transform y, bool farthest = false) => CompareDistance3(position.transform.position, x.transform.position, y.position, farthest);
        
        /// <summary>
        /// Compare the two instances.
        /// </summary>
        /// <param name="position">The position to compare against.</param>
        /// <param name="x">The first instance.</param>
        /// <param name="y">The second instance.</param>
        /// <param name="farthest">If this should sort by farthest items first.</param>
        /// <returns>Less than zero if the first instance comes first, zero if they are equal, or greater than zero if the second comes first.</returns>
        public static int CompareDistance3([NotNull] GameObject position, [NotNull] GameObject x, [NotNull] Component y, bool farthest = false) => CompareDistance3(position.transform.position, x.transform.position, y.transform.position, farthest);
        
        /// <summary>
        /// Compare the two instances.
        /// </summary>
        /// <param name="position">The position to compare against.</param>
        /// <param name="x">The first instance.</param>
        /// <param name="y">The second instance.</param>
        /// <param name="farthest">If this should sort by farthest items first.</param>
        /// <returns>Less than zero if the first instance comes first, zero if they are equal, or greater than zero if the second comes first.</returns>
        public static int CompareDistance3([NotNull] GameObject position, [NotNull] GameObject x, [NotNull] GameObject y, bool farthest = false) => CompareDistance3(position.transform.position, x.transform.position, y.transform.position, farthest);
        
        /// <summary>
        /// Compare the two instances.
        /// </summary>
        /// <param name="x">The first instance.</param>
        /// <param name="y">The second instance.</param>
        /// <returns>Less than zero if the first instance comes first, zero if they are equal, or greater than zero if the second comes first.</returns>
        public int Compare(Vector2 x, Vector2 y)
        {
            return Compare(x.Expand(), y.Expand());
        }
        
        /// <summary>
        /// Compare the two instances.
        /// </summary>
        /// <param name="x">The first instance.</param>
        /// <param name="y">The second instance.</param>
        /// <returns>Less than zero if the first instance comes first, zero if they are equal, or greater than zero if the second comes first.</returns>
        public int Compare(Vector3 x, Vector3 y)
        {
            int order = CompareDistance3(Position, x, y);
            return order != 0 || !Mode.HasValue ? order : KaijuAgentsAngleSorter.CompareAngle(Position.Flatten(), Forward ?? Position.Flatten(), x.Flatten(), y.Flatten(), Mode.Value);
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
            return x == null ? y == null ? 0 : 1 : y == null ? -1 : Compare(x.position, y.position);
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
            return x == null ? y == null ? 0 : 1 : y == null ? -1 : Compare(x.transform.position, y.transform.position);
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
            return x == null ? y == null ? 0 : 1 : y == null ? -1 : Compare(x.transform.position, y.transform.position);
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
        public static implicit operator string([NotNull] KaijuAgentsDistance3Sorter s) => s.ToString();
        
        /// <summary>
        /// Implicit conversion to a <see href="https://docs.unity3d.com/ScriptReference/Vector2.html">Vector2</see> from the position.
        /// </summary>
        /// <param name="s">The sorter.</param>
        /// <returns>The string from the <see cref="ToString"/> method.</returns>
        public static implicit operator Vector2([NotNull] KaijuAgentsDistance3Sorter s) => s.Position2;
        
        /// <summary>
        /// Implicit conversion to a nullable <see href="https://docs.unity3d.com/ScriptReference/Vector2.html">Vector2</see> from the position.
        /// </summary>
        /// <param name="s">The sorter.</param>
        /// <returns>The string from the <see cref="ToString"/> method.</returns>
        public static implicit operator Vector2?([NotNull] KaijuAgentsDistance3Sorter s) => s.Position2;
        
        /// <summary>
        /// Implicit conversion to a <see href="https://docs.unity3d.com/ScriptReference/Vector3.html">Vector3</see> from the position.
        /// </summary>
        /// <param name="s">The sorter.</param>
        /// <returns>The string from the <see cref="ToString"/> method.</returns>
        public static implicit operator Vector3([NotNull] KaijuAgentsDistance3Sorter s) => s.Position;
        
        /// <summary>
        /// Implicit conversion to a nullable <see href="https://docs.unity3d.com/ScriptReference/Vector3.html">Vector3</see> from the position.
        /// </summary>
        /// <param name="s">The sorter.</param>
        /// <returns>The string from the <see cref="ToString"/> method.</returns>
        public static implicit operator Vector3?([NotNull] KaijuAgentsDistance3Sorter s) => s.Position;
    }
}