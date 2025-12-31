using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using UnityEngine;

namespace KaijuSolutions.Agents.Extension
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
        /// The position to compare against.
        /// </summary>
        public Transform PositionTransform
        {
            set => Position = value.position;
        }
        
        /// <summary>
        /// The position to compare against.
        /// </summary>
        public Component PositionComponent
        {
            set => Position = value.transform.position;
        }
        
        /// <summary>
        /// The position to compare against.
        /// </summary>
        public GameObject PositionGameObject
        {
            set => Position = value.transform.position;
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
        /// Create the sorter.
        /// </summary>
        public KaijuAgentsDistance3Sorter()
        {
            Position = Vector3.zero;
            Farthest = false;
        }
        
        /// <summary>
        /// Create the sorter.
        /// </summary>
        /// <param name="position">The position to compare against.</param>
        /// <param name="farthest">If this should sort by farthest items first.</param>
        public KaijuAgentsDistance3Sorter(Vector2 position, bool farthest = false)
        {
            Position = position.Expand();
            Farthest = farthest;
        }
        
        /// <summary>
        /// Create the sorter.
        /// </summary>
        /// <param name="position">The position to compare against.</param>
        /// <param name="farthest">If this should sort by farthest items first.</param>
        public KaijuAgentsDistance3Sorter(Vector3 position, bool farthest = false)
        {
            Position = position;
            Farthest = farthest;
        }
        
        /// <summary>
        /// Create the sorter.
        /// </summary>
        /// <param name="position">The position to compare against.</param>
        /// <param name="farthest">If this should sort by farthest items first.</param>
        public KaijuAgentsDistance3Sorter([NotNull] Transform position, bool farthest = false)
        {
            Position = position.position;
            Farthest = farthest;
        }
        
        /// <summary>
        /// Create the sorter.
        /// </summary>
        /// <param name="position">The position to compare against.</param>
        /// <param name="farthest">If this should sort by farthest items first.</param>
        public KaijuAgentsDistance3Sorter([NotNull] Component position, bool farthest = false)
        {
            Position = position.transform.position;
            Farthest = farthest;
        }
        
        /// <summary>
        /// Create the sorter.
        /// </summary>
        /// <param name="position">The position to compare against.</param>
        /// <param name="farthest">If this should sort by farthest items first.</param>
        public KaijuAgentsDistance3Sorter([NotNull] GameObject position, bool farthest = false)
        {
            Position = position.transform.position;
            Farthest = farthest;
        }
        
        /// <summary>
        /// Set values for the sorter.
        /// </summary>
        /// <param name="position">The position to compare against.</param>
        /// <param name="farthest">If this should sort by farthest items first.</param>
        public void Set(Vector2 position, bool farthest = false)
        {
            Set(position.Expand(), farthest);
        }
        
        /// <summary>
        /// Set values for the sorter.
        /// </summary>
        /// <param name="position">The position to compare against.</param>
        /// <param name="farthest">If this should sort by farthest items first.</param>
        public void Set(Vector3 position, bool farthest = false)
        {
            Position = position;
            Farthest = farthest;
        }
        
        /// <summary>
        /// Set values for the sorter.
        /// </summary>
        /// <param name="position">The position to compare against.</param>
        /// <param name="farthest">If this should sort by farthest items first.</param>
        public void Set([NotNull] Transform position, bool farthest = false)
        {
            Set(position.position, farthest);
        }
        
        /// <summary>
        /// Set values for the sorter.
        /// </summary>
        /// <param name="position">The position to compare against.</param>
        /// <param name="farthest">If this should sort by farthest items first.</param>
        public void Set([NotNull] Component position, bool farthest = false)
        {
            Set(position.transform.position, farthest);
        }
        
        /// <summary>
        /// Set values for the sorter.
        /// </summary>
        /// <param name="position">The position to compare against.</param>
        /// <param name="farthest">If this should sort by farthest items first.</param>
        public void Set([NotNull] GameObject position, bool farthest = false)
        {
            Set(position.transform.position, farthest);
        }
        
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
            float a = Position.Distance3(x);
            float b = Position.Distance3(y);
            int order = a < b ? -1 : b < a ? 1 : 0;
            return Farthest ? -order : order;
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
            return $"Kaiju Agents Distance-3 Sorter: {Position}";
        }
    }
}