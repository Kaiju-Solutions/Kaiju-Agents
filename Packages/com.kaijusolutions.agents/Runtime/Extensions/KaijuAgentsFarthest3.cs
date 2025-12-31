using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using UnityEngine;

namespace KaijuSolutions.Agents
{
    /// <summary>
    /// Extension methods to get the farthest object from a given position along all three axes. Any Vector2 values will be expanded via the <see cref="KaijuAgentsExpand.Expand"/> method.
    /// </summary>
    public static class KaijuAgentsFarthest3
    {
        /// <summary>
        /// The farthest instance across all three axes to a position.
        /// </summary>
        /// <param name="position">The position to get the farthest target instance from.</param>
        /// <param name="targets">The targets to get the farthest from.</param>
        /// <param name="distance">The distance to the farthest target.</param>
        /// <returns>The farthest instance from the targets to the position. Will be the starting position if the targets list is empty.</returns>
        public static Vector3 Farthest3(this Vector2 position, [NotNull] IEnumerable<Vector3> targets, out float distance) => position.Expand().Farthest3(targets, out distance);
        
        /// <summary>
        /// The farthest instance across all three axes to a position.
        /// </summary>
        /// <param name="position">The position to get the farthest target instance from.</param>
        /// <param name="targets">The targets to get the farthest from.</param>
        /// <param name="distance">The distance to the farthest target.</param>
        /// <returns>The farthest instance from the targets to the position. Will be NULL if the targets list is empty.</returns>
        public static Transform Farthest3(this Vector2 position, [NotNull] IEnumerable<Transform> targets, out float distance) => position.Expand().Farthest3(targets, out distance);
        
        /// <summary>
        /// The farthest instance across all three axes to a position.
        /// </summary>
        /// <param name="position">The position to get the farthest target instance from.</param>
        /// <param name="targets">The targets to get the farthest from.</param>
        /// <param name="distance">The distance to the farthest target.</param>
        /// <returns>The farthest instance from the targets to the position. Will be NULL if the targets list is empty.</returns>
        public static T Farthest3<T>(this Vector2 position, [NotNull] IEnumerable<T> targets, out float distance) where T : Component => position.Expand().Farthest3(targets, out distance);
        
        /// <summary>
        /// The farthest instance across all three axes to a position.
        /// </summary>
        /// <param name="position">The position to get the farthest target instance from.</param>
        /// <param name="targets">The targets to get the farthest from.</param>
        /// <param name="distance">The distance to the farthest target.</param>
        /// <returns>The farthest instance from the targets to the position. Will be NULL if the targets list is empty.</returns>
        public static GameObject Farthest3(this Vector2 position, [NotNull] IEnumerable<GameObject> targets, out float distance) => position.Expand().Farthest3(targets, out distance);
        
        /// <summary>
        /// The farthest instance across all three axes to a position.
        /// </summary>
        /// <param name="position">The position to get the farthest target instance from.</param>
        /// <param name="targets">The targets to get the farthest from.</param>
        /// <param name="distance">The distance to the farthest target.</param>
        /// <returns>The farthest instance from the targets to the position. Will be the starting position if the targets list is empty.</returns>
        public static Vector3 Farthest3(this Vector3 position, [NotNull] IEnumerable<Vector3> targets, out float distance)
        {
            Vector3? farthest = null;
            distance = 0;
            foreach (Vector3 target in targets)
            {
                float current = position.Distance3(target);
                if (farthest.HasValue && current <= distance)
                {
                    continue;
                }
                
                farthest = target;
                distance = current;
            }
            
            return farthest ?? position;
        }
        
        /// <summary>
        /// The farthest instance across all three axes to a position.
        /// </summary>
        /// <param name="position">The position to get the farthest target instance from.</param>
        /// <param name="targets">The targets to get the farthest from.</param>
        /// <param name="distance">The distance to the farthest target.</param>
        /// <returns>The farthest instance from the targets to the position. Will be NULL if the targets list is empty.</returns>
        public static Transform Farthest3(this Vector3 position, [NotNull] IEnumerable<Transform> targets, out float distance)
        {
            Transform farthest = null;
            distance = 0;
            foreach (Transform target in targets)
            {
                float current = position.Distance3(target);
                if (farthest != null && current <= distance)
                {
                    continue;
                }
                
                farthest = target;
                distance = current;
            }
            
            return farthest;
        }
        
        /// <summary>
        /// The farthest instance across all three axes to a position.
        /// </summary>
        /// <param name="position">The position to get the farthest target instance from.</param>
        /// <param name="targets">The targets to get the farthest from.</param>
        /// <param name="distance">The distance to the farthest target.</param>
        /// <returns>The farthest instance from the targets to the position. Will be NULL if the targets list is empty.</returns>
        public static T Farthest3<T>(this Vector3 position, [NotNull] IEnumerable<T> targets, out float distance) where T : Component
        {
            T farthest = null;
            distance = 0;
            foreach (T target in targets)
            {
                float current = position.Distance3(target);
                if (farthest != null && current <= distance)
                {
                    continue;
                }
                
                farthest = target;
                distance = current;
            }
            
            return farthest;
        }
        
        /// <summary>
        /// The farthest instance across all three axes to a position.
        /// </summary>
        /// <param name="position">The position to get the farthest target instance from.</param>
        /// <param name="targets">The targets to get the farthest from.</param>
        /// <param name="distance">The distance to the farthest target.</param>
        /// <returns>The farthest instance from the targets to the position. Will be NULL if the targets list is empty.</returns>
        public static GameObject Farthest3(this Vector3 position, [NotNull] IEnumerable<GameObject> targets, out float distance)
        {
            GameObject farthest = null;
            distance = 0;
            foreach (GameObject target in targets)
            {
                float current = position.Distance3(target);
                if (farthest != null && current <= distance)
                {
                    continue;
                }
                
                farthest = target;
                distance = current;
            }
            
            return farthest;
        }
        
        /// <summary>
        /// The farthest instance across all three axes to a position.
        /// </summary>
        /// <param name="position">The position to get the farthest target instance from.</param>
        /// <param name="targets">The targets to get the farthest from.</param>
        /// <param name="distance">The distance to the farthest target.</param>
        /// <returns>The farthest instance from the targets to the position. Will be the starting position if the targets list is empty.</returns>
        public static Vector3 Farthest3([NotNull] this Transform position, [NotNull] IEnumerable<Vector3> targets, out float distance) => position.position.Farthest3(targets, out distance);
        
        /// <summary>
        /// The farthest instance across all three axes to a position.
        /// </summary>
        /// <param name="position">The position to get the farthest target instance from.</param>
        /// <param name="targets">The targets to get the farthest from.</param>
        /// <param name="distance">The distance to the farthest target.</param>
        /// <returns>The farthest instance from the targets to the position. Will be NULL if the targets list is empty.</returns>
        public static Transform Farthest3([NotNull] this Transform position, [NotNull] IEnumerable<Transform> targets, out float distance) => position.position.Farthest3(targets, out distance);
        
        /// <summary>
        /// The farthest instance across all three axes to a position.
        /// </summary>
        /// <param name="position">The position to get the farthest target instance from.</param>
        /// <param name="targets">The targets to get the farthest from.</param>
        /// <param name="distance">The distance to the farthest target.</param>
        /// <returns>The farthest instance from the targets to the position. Will be NULL if the targets list is empty.</returns>
        public static T Farthest3<T>([NotNull] this Transform position, [NotNull] IEnumerable<T> targets, out float distance) where T : Component => position.position.Farthest3(targets, out distance);
        
        /// <summary>
        /// The farthest instance across all three axes to a position.
        /// </summary>
        /// <param name="position">The position to get the farthest target instance from.</param>
        /// <param name="targets">The targets to get the farthest from.</param>
        /// <param name="distance">The distance to the farthest target.</param>
        /// <returns>The farthest instance from the targets to the position. Will be NULL if the targets list is empty.</returns>
        public static GameObject Farthest3([NotNull] this Transform position, [NotNull] IEnumerable<GameObject> targets, out float distance) => position.position.Farthest3(targets, out distance);
        
        /// <summary>
        /// The farthest instance across all three axes to a position.
        /// </summary>
        /// <param name="position">The position to get the farthest target instance from.</param>
        /// <param name="targets">The targets to get the farthest from.</param>
        /// <param name="distance">The distance to the farthest target.</param>
        /// <returns>The farthest instance from the targets to the position. Will be the starting position if the targets list is empty.</returns>
        public static Vector3 Farthest3([NotNull] this Component position, [NotNull] IEnumerable<Vector3> targets, out float distance) => position.transform.position.Farthest3(targets, out distance);
        
        /// <summary>
        /// The farthest instance across all three axes to a position.
        /// </summary>
        /// <param name="position">The position to get the farthest target instance from.</param>
        /// <param name="targets">The targets to get the farthest from.</param>
        /// <param name="distance">The distance to the farthest target.</param>
        /// <returns>The farthest instance from the targets to the position. Will be NULL if the targets list is empty.</returns>
        public static Transform Farthest3([NotNull] this Component position, [NotNull] IEnumerable<Transform> targets, out float distance) => position.transform.position.Farthest3(targets, out distance);
        
        /// <summary>
        /// The farthest instance across all three axes to a position.
        /// </summary>
        /// <param name="position">The position to get the farthest target instance from.</param>
        /// <param name="targets">The targets to get the farthest from.</param>
        /// <param name="distance">The distance to the farthest target.</param>
        /// <returns>The farthest instance from the targets to the position. Will be NULL if the targets list is empty.</returns>
        public static T Farthest3<T>([NotNull] this Component position, [NotNull] IEnumerable<T> targets, out float distance) where T : Component => position.transform.position.Farthest3(targets, out distance);
        
        /// <summary>
        /// The farthest instance across all three axes to a position.
        /// </summary>
        /// <param name="position">The position to get the farthest target instance from.</param>
        /// <param name="targets">The targets to get the farthest from.</param>
        /// <param name="distance">The distance to the farthest target.</param>
        /// <returns>The farthest instance from the targets to the position. Will be NULL if the targets list is empty.</returns>
        public static GameObject Farthest3([NotNull] this Component position, [NotNull] IEnumerable<GameObject> targets, out float distance) => position.transform.position.Farthest3(targets, out distance);
        
        /// <summary>
        /// The farthest instance across all three axes to a position.
        /// </summary>
        /// <param name="position">The position to get the farthest target instance from.</param>
        /// <param name="targets">The targets to get the farthest from.</param>
        /// <param name="distance">The distance to the farthest target.</param>
        /// <returns>The farthest instance from the targets to the position. Will be the starting position if the targets list is empty.</returns>
        public static Vector3 Farthest3([NotNull] this GameObject position, [NotNull] IEnumerable<Vector3> targets, out float distance) => position.transform.position.Farthest3(targets, out distance);
        
        /// <summary>
        /// The farthest instance across all three axes to a position.
        /// </summary>
        /// <param name="position">The position to get the farthest target instance from.</param>
        /// <param name="targets">The targets to get the farthest from.</param>
        /// <param name="distance">The distance to the farthest target.</param>
        /// <returns>The farthest instance from the targets to the position. Will be NULL if the targets list is empty.</returns>
        public static Transform Farthest3([NotNull] this GameObject position, [NotNull] IEnumerable<Transform> targets, out float distance) => position.transform.position.Farthest3(targets, out distance);
        
        /// <summary>
        /// The farthest instance across all three axes to a position.
        /// </summary>
        /// <param name="position">The position to get the farthest target instance from.</param>
        /// <param name="targets">The targets to get the farthest from.</param>
        /// <param name="distance">The distance to the farthest target.</param>
        /// <returns>The farthest instance from the targets to the position. Will be NULL if the targets list is empty.</returns>
        public static T Farthest3<T>([NotNull] this GameObject position, [NotNull] IEnumerable<T> targets, out float distance) where T : Component => position.transform.position.Farthest3(targets, out distance);
        
        /// <summary>
        /// The farthest instance across all three axes to a position.
        /// </summary>
        /// <param name="position">The position to get the farthest target instance from.</param>
        /// <param name="targets">The targets to get the farthest from.</param>
        /// <param name="distance">The distance to the farthest target.</param>
        /// <returns>The farthest instance from the targets to the position. Will be NULL if the targets list is empty.</returns>
        public static GameObject Farthest3([NotNull] this GameObject position, [NotNull] IEnumerable<GameObject> targets, out float distance) => position.transform.position.Farthest3(targets, out distance);
    }
}