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
        /// The position to compare against.
        /// </summary>
        public Transform PositionTransform
        {
            set => Position = value.Flatten();
        }
        
        /// <summary>
        /// The position to compare against.
        /// </summary>
        public Component PositionComponent
        {
            set => Position = value.Flatten();
        }
        
        /// <summary>
        /// The position to compare against.
        /// </summary>
        public GameObject PositionGameObject
        {
            set => Position = value.Flatten();
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
        /// Create the sorter.
        /// </summary>
        public KaijuAgentsDistanceSorter()
        {
            Position = Vector2.zero;
            Farthest = false;
        }
        
        /// <summary>
        /// Create the sorter.
        /// </summary>
        /// <param name="position">The position to compare against.</param>
        /// <param name="farthest">If this should sort by farthest items first.</param>
        public KaijuAgentsDistanceSorter(Vector2 position, bool farthest = false)
        {
            Position = position;
            Farthest = farthest;
        }
        
        /// <summary>
        /// Create the sorter.
        /// </summary>
        /// <param name="position">The position to compare against.</param>
        /// <param name="farthest">If this should sort by farthest items first.</param>
        public KaijuAgentsDistanceSorter(Vector3 position, bool farthest = false)
        {
            Position = position.Flatten();
            Farthest = farthest;
        }
        
        /// <summary>
        /// Create the sorter.
        /// </summary>
        /// <param name="position">The position to compare against.</param>
        /// <param name="farthest">If this should sort by farthest items first.</param>
        public KaijuAgentsDistanceSorter([NotNull] Transform position, bool farthest = false)
        {
            Position = position.Flatten();
            Farthest = farthest;
        }
        
        /// <summary>
        /// Create the sorter.
        /// </summary>
        /// <param name="position">The position to compare against.</param>
        /// <param name="farthest">If this should sort by farthest items first.</param>
        public KaijuAgentsDistanceSorter([NotNull] Component position, bool farthest = false)
        {
            Position = position.Flatten();
            Farthest = farthest;
        }
        
        /// <summary>
        /// Create the sorter.
        /// </summary>
        /// <param name="position">The position to compare against.</param>
        /// <param name="farthest">If this should sort by farthest items first.</param>
        public KaijuAgentsDistanceSorter([NotNull] GameObject position, bool farthest = false)
        {
            Position = position.Flatten();
            Farthest = farthest;
        }
        
        /// <summary>
        /// Set values for the sorter.
        /// </summary>
        /// <param name="position">The position to compare against.</param>
        /// <param name="farthest">If this should sort by farthest items first.</param>
        public void Set(Vector2 position, bool farthest = false)
        {
            Position = position;
            Farthest = farthest;
        }
        
        /// <summary>
        /// Set values for the sorter.
        /// </summary>
        /// <param name="position">The position to compare against.</param>
        /// <param name="farthest">If this should sort by farthest items first.</param>
        public void Set(Vector3 position, bool farthest = false)
        {
            Set(position.Flatten(), farthest);
        }
        
        /// <summary>
        /// Set values for the sorter.
        /// </summary>
        /// <param name="position">The position to compare against.</param>
        /// <param name="farthest">If this should sort by farthest items first.</param>
        public void Set([NotNull] Transform position, bool farthest = false)
        {
            Set(position.Flatten(), farthest);
        }
        
        /// <summary>
        /// Set values for the sorter.
        /// </summary>
        /// <param name="position">The position to compare against.</param>
        /// <param name="farthest">If this should sort by farthest items first.</param>
        public void Set([NotNull] Component position, bool farthest = false)
        {
            Set(position.Flatten(), farthest);
        }
        
        /// <summary>
        /// Set values for the sorter.
        /// </summary>
        /// <param name="position">The position to compare against.</param>
        /// <param name="farthest">If this should sort by farthest items first.</param>
        public void Set([NotNull] GameObject position, bool farthest = false)
        {
            Set(position.Flatten(), farthest);
        }
        
        /// <summary>
        /// Compare the two instances.
        /// </summary>
        /// <param name="x">The first instance.</param>
        /// <param name="y">The second instance.</param>
        /// <returns>Less than zero if the first instance comes first, zero if they are equal, or greater than zero if the second comes first.</returns>
        public int Compare(Vector2 x, Vector2 y)
        {
            float a = Position.Distance(x);
            float b = Position.Distance(y);
            int order = a < b ? -1 : b < a ? 1 : 0;
            return Farthest ? -order : order;
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
            return $"Kaiju Agents Distance Sorter: {Position}";
        }
    }
}