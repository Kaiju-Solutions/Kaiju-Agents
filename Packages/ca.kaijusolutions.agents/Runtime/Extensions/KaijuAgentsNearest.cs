using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using UnityEngine;

namespace KaijuSolutions.Agents.Extensions
{
    /// <summary>
    /// Extension methods to get the nearest object to a given position along the X and Z axes. All three-dimensional vectors will be flattened via methods in <see cref="KaijuAgentsFlatten"/>.
    /// </summary>
    public static class KaijuAgentsNearest
    {
        /// <summary>
        /// The nearest instance to a position.
        /// </summary>
        /// <param name="position">The position to get the nearest target instance to.</param>
        /// <param name="targets">The targets to get the nearest of.</param>
        /// <param name="distance">The distance to the nearest target.</param>
        /// <returns>The nearest instance from the targets to the position. Will be the starting position if the targets list is empty.</returns>
        public static Vector2 Nearest(this Vector2 position, [NotNull] IEnumerable<Vector2> targets, out float distance)
        {
            Vector2? nearest = null;
            distance = float.MaxValue;
            foreach (Vector2 target in targets)
            {
                float current = position.Distance(target);
                if (nearest.HasValue && current >= distance)
                {
                    continue;
                }

                nearest = target;
                distance = current;
            }
            
            return nearest ?? position;
        }
        
        /// <summary>
        /// The nearest instance to a position.
        /// </summary>
        /// <param name="position">The position to get the nearest target instance to.</param>
        /// <param name="targets">The targets to get the nearest of.</param>
        /// <param name="distance">The distance to the nearest target.</param>
        /// <returns>The nearest instance from the targets to the position. Will be the starting position if the targets list is empty.</returns>
        public static Vector3 Nearest(this Vector2 position, [NotNull] IEnumerable<Vector3> targets, out float distance)
        {
            Vector3? nearest = null;
            distance = float.MaxValue;
            foreach (Vector3 target in targets)
            {
                float current = position.Distance(target);
                if (nearest.HasValue && current >= distance)
                {
                    continue;
                }
                
                nearest = target;
                distance = current;
            }

            return nearest ?? position.Expand();
        }
        
        /// <summary>
        /// The nearest instance to a position.
        /// </summary>
        /// <param name="position">The position to get the nearest target instance to.</param>
        /// <param name="targets">The targets to get the nearest of.</param>
        /// <param name="distance">The distance to the nearest target.</param>
        /// <returns>The nearest instance from the targets to the position. Will be NULL if the targets list is empty.</returns>
        public static Transform Nearest(this Vector2 position, [NotNull] IEnumerable<Transform> targets, out float distance)
        {
            Transform nearest = null;
            distance = float.MaxValue;
            foreach (Transform target in targets)
            {
                if (target == null)
                {
                    continue;
                }
                
                float current = position.Distance(target);
                if (nearest != null && current >= distance)
                {
                    continue;
                }
                
                nearest = target;
                distance = current;
            }
            
            return nearest;
        }
        
        /// <summary>
        /// The nearest instance to a position.
        /// </summary>
        /// <param name="position">The position to get the nearest target instance to.</param>
        /// <param name="targets">The targets to get the nearest of.</param>
        /// <param name="distance">The distance to the nearest target.</param>
        /// <returns>The nearest instance from the targets to the position. Will be NULL if the targets list is empty.</returns>
        public static T Nearest<T>(this Vector2 position, [NotNull] IEnumerable<T> targets, out float distance) where T : Component
        {
            T nearest = null;
            distance = float.MaxValue;
            foreach (T target in targets)
            {
                if (target == null)
                {
                    continue;
                }
                
                float current = position.Distance(target);
                if (nearest != null && current >= distance)
                {
                    continue;
                }
                
                nearest = target;
                distance = current;
            }
            
            return nearest;
        }
        
        /// <summary>
        /// The nearest instance to a position.
        /// </summary>
        /// <param name="position">The position to get the nearest target instance to.</param>
        /// <param name="targets">The targets to get the nearest of.</param>
        /// <param name="distance">The distance to the nearest target.</param>
        /// <returns>The nearest instance from the targets to the position. Will be NULL if the targets list is empty.</returns>
        public static GameObject Nearest(this Vector2 position, [NotNull] IEnumerable<GameObject> targets, out float distance)
        {
            GameObject nearest = null;
            distance = float.MaxValue;
            foreach (GameObject target in targets)
            {
                if (target == null)
                {
                    continue;
                }
                
                float current = position.Distance(target);
                if (nearest != null && current >= distance)
                {
                    continue;
                }
                
                nearest = target;
                distance = current;
            }
            
            return nearest;
        }
        
        /// <summary>
        /// The nearest instance to a position.
        /// </summary>
        /// <param name="position">The position to get the nearest target instance to.</param>
        /// <param name="targets">The targets to get the nearest of.</param>
        /// <param name="distance">The distance to the nearest target.</param>
        /// <returns>The nearest instance from the targets to the position. Will be the starting position if the targets list is empty.</returns>
        public static Vector2 Nearest(this Vector3 position, [NotNull] IEnumerable<Vector2> targets, out float distance) => position.Flatten().Nearest(targets, out distance);
        
        /// <summary>
        /// The nearest instance to a position.
        /// </summary>
        /// <param name="position">The position to get the nearest target instance to.</param>
        /// <param name="targets">The targets to get the nearest of.</param>
        /// <param name="distance">The distance to the nearest target.</param>
        /// <returns>The nearest instance from the targets to the position. Will be the starting position if the targets list is empty.</returns>
        public static Vector3 Nearest(this Vector3 position, [NotNull] IEnumerable<Vector3> targets, out float distance) => position.Flatten().Nearest(targets, out distance);
        
        /// <summary>
        /// The nearest instance to a position.
        /// </summary>
        /// <param name="position">The position to get the nearest target instance to.</param>
        /// <param name="targets">The targets to get the nearest of.</param>
        /// <param name="distance">The distance to the nearest target.</param>
        /// <returns>The nearest instance from the targets to the position. Will be NULL if the targets list is empty.</returns>
        public static Transform Nearest(this Vector3 position, [NotNull] IEnumerable<Transform> targets, out float distance) => position.Flatten().Nearest(targets, out distance);
        
        /// <summary>
        /// The nearest instance to a position.
        /// </summary>
        /// <param name="position">The position to get the nearest target instance to.</param>
        /// <param name="targets">The targets to get the nearest of.</param>
        /// <param name="distance">The distance to the nearest target.</param>
        /// <returns>The nearest instance from the targets to the position. Will be NULL if the targets list is empty.</returns>
        public static T Nearest<T>(this Vector3 position, [NotNull] IEnumerable<T> targets, out float distance) where T : Component => position.Flatten().Nearest(targets, out distance);
        
        /// <summary>
        /// The nearest instance to a position.
        /// </summary>
        /// <param name="position">The position to get the nearest target instance to.</param>
        /// <param name="targets">The targets to get the nearest of.</param>
        /// <param name="distance">The distance to the nearest target.</param>
        /// <returns>The nearest instance from the targets to the position. Will be NULL if the targets list is empty.</returns>
        public static GameObject Nearest(this Vector3 position, [NotNull] IEnumerable<GameObject> targets, out float distance) => position.Flatten().Nearest(targets, out distance);
        
        /// <summary>
        /// The nearest instance to a position.
        /// </summary>
        /// <param name="position">The position to get the nearest target instance to.</param>
        /// <param name="targets">The targets to get the nearest of.</param>
        /// <param name="distance">The distance to the nearest target.</param>
        /// <returns>The nearest instance from the targets to the position. Will be the starting position if the targets list is empty.</returns>
        public static Vector2 Nearest([NotNull] this Transform position, [NotNull] IEnumerable<Vector2> targets, out float distance) => position.position.Flatten().Nearest(targets, out distance);
        
        /// <summary>
        /// The nearest instance to a position.
        /// </summary>
        /// <param name="position">The position to get the nearest target instance to.</param>
        /// <param name="targets">The targets to get the nearest of.</param>
        /// <param name="distance">The distance to the nearest target.</param>
        /// <returns>The nearest instance from the targets to the position. Will be the starting position if the targets list is empty.</returns>
        public static Vector3 Nearest([NotNull] this Transform position, [NotNull] IEnumerable<Vector3> targets, out float distance) => position.position.Flatten().Nearest(targets, out distance);
        
        /// <summary>
        /// The nearest instance to a position.
        /// </summary>
        /// <param name="position">The position to get the nearest target instance to.</param>
        /// <param name="targets">The targets to get the nearest of.</param>
        /// <param name="distance">The distance to the nearest target.</param>
        /// <returns>The nearest instance from the targets to the position. Will be NULL if the targets list is empty.</returns>
        public static Transform Nearest([NotNull] this Transform position, [NotNull] IEnumerable<Transform> targets, out float distance) => position.position.Flatten().Nearest(targets, out distance);
        
        /// <summary>
        /// The nearest instance to a position.
        /// </summary>
        /// <param name="position">The position to get the nearest target instance to.</param>
        /// <param name="targets">The targets to get the nearest of.</param>
        /// <param name="distance">The distance to the nearest target.</param>
        /// <returns>The nearest instance from the targets to the position. Will be NULL if the targets list is empty.</returns>
        public static T Nearest<T>([NotNull] this Transform position, [NotNull] IEnumerable<T> targets, out float distance) where T : Component => position.position.Flatten().Nearest(targets, out distance);
        
        /// <summary>
        /// The nearest instance to a position.
        /// </summary>
        /// <param name="position">The position to get the nearest target instance to.</param>
        /// <param name="targets">The targets to get the nearest of.</param>
        /// <param name="distance">The distance to the nearest target.</param>
        /// <returns>The nearest instance from the targets to the position. Will be NULL if the targets list is empty.</returns>
        public static GameObject Nearest([NotNull] this Transform position, [NotNull] IEnumerable<GameObject> targets, out float distance) => position.position.Flatten().Nearest(targets, out distance);
        
        /// <summary>
        /// The nearest instance to a position.
        /// </summary>
        /// <param name="position">The position to get the nearest target instance to.</param>
        /// <param name="targets">The targets to get the nearest of.</param>
        /// <param name="distance">The distance to the nearest target.</param>
        /// <returns>The nearest instance from the targets to the position. Will be the starting position if the targets list is empty.</returns>
        public static Vector2 Nearest([NotNull] this Component position, [NotNull] IEnumerable<Vector2> targets, out float distance) => position.transform.position.Flatten().Nearest(targets, out distance);
        
        /// <summary>
        /// The nearest instance to a position.
        /// </summary>
        /// <param name="position">The position to get the nearest target instance to.</param>
        /// <param name="targets">The targets to get the nearest of.</param>
        /// <param name="distance">The distance to the nearest target.</param>
        /// <returns>The nearest instance from the targets to the position. Will be the starting position if the targets list is empty.</returns>
        public static Vector3 Nearest([NotNull] this Component position, [NotNull] IEnumerable<Vector3> targets, out float distance) => position.transform.position.Flatten().Nearest(targets, out distance);
        
        /// <summary>
        /// The nearest instance to a position.
        /// </summary>
        /// <param name="position">The position to get the nearest target instance to.</param>
        /// <param name="targets">The targets to get the nearest of.</param>
        /// <param name="distance">The distance to the nearest target.</param>
        /// <returns>The nearest instance from the targets to the position. Will be NULL if the targets list is empty.</returns>
        public static Transform Nearest([NotNull] this Component position, [NotNull] IEnumerable<Transform> targets, out float distance) => position.transform.position.Flatten().Nearest(targets, out distance);
        
        /// <summary>
        /// The nearest instance to a position.
        /// </summary>
        /// <param name="position">The position to get the nearest target instance to.</param>
        /// <param name="targets">The targets to get the nearest of.</param>
        /// <param name="distance">The distance to the nearest target.</param>
        /// <returns>The nearest instance from the targets to the position. Will be NULL if the targets list is empty.</returns>
        public static T Nearest<T>([NotNull] this Component position, [NotNull] IEnumerable<T> targets, out float distance) where T : Component => position.transform.position.Flatten().Nearest(targets, out distance);
        
        /// <summary>
        /// The nearest instance to a position.
        /// </summary>
        /// <param name="position">The position to get the nearest target instance to.</param>
        /// <param name="targets">The targets to get the nearest of.</param>
        /// <param name="distance">The distance to the nearest target.</param>
        /// <returns>The nearest instance from the targets to the position. Will be NULL if the targets list is empty.</returns>
        public static GameObject Nearest([NotNull] this Component position, [NotNull] IEnumerable<GameObject> targets, out float distance) => position.transform.position.Flatten().Nearest(targets, out distance);
        
        /// <summary>
        /// The nearest instance to a position.
        /// </summary>
        /// <param name="position">The position to get the nearest target instance to.</param>
        /// <param name="targets">The targets to get the nearest of.</param>
        /// <param name="distance">The distance to the nearest target.</param>
        /// <returns>The nearest instance from the targets to the position. Will be the starting position if the targets list is empty.</returns>
        public static Vector2 Nearest([NotNull] this GameObject position, [NotNull] IEnumerable<Vector2> targets, out float distance) => position.transform.position.Flatten().Nearest(targets, out distance);
        
        /// <summary>
        /// The nearest instance to a position.
        /// </summary>
        /// <param name="position">The position to get the nearest target instance to.</param>
        /// <param name="targets">The targets to get the nearest of.</param>
        /// <param name="distance">The distance to the nearest target.</param>
        /// <returns>The nearest instance from the targets to the position. Will be the starting position if the targets list is empty.</returns>
        public static Vector3 Nearest([NotNull] this GameObject position, [NotNull] IEnumerable<Vector3> targets, out float distance) => position.transform.position.Flatten().Nearest(targets, out distance);
        
        /// <summary>
        /// The nearest instance to a position.
        /// </summary>
        /// <param name="position">The position to get the nearest target instance to.</param>
        /// <param name="targets">The targets to get the nearest of.</param>
        /// <param name="distance">The distance to the nearest target.</param>
        /// <returns>The nearest instance from the targets to the position. Will be NULL if the targets list is empty.</returns>
        public static Transform Nearest([NotNull] this GameObject position, [NotNull] IEnumerable<Transform> targets, out float distance) => position.transform.position.Flatten().Nearest(targets, out distance);
        
        /// <summary>
        /// The nearest instance to a position.
        /// </summary>
        /// <param name="position">The position to get the nearest target instance to.</param>
        /// <param name="targets">The targets to get the nearest of.</param>
        /// <param name="distance">The distance to the nearest target.</param>
        /// <returns>The nearest instance from the targets to the position. Will be NULL if the targets list is empty.</returns>
        public static T Nearest<T>([NotNull] this GameObject position, [NotNull] IEnumerable<T> targets, out float distance) where T : Component => position.transform.position.Flatten().Nearest(targets, out distance);
        
        /// <summary>
        /// The nearest instance to a position.
        /// </summary>
        /// <param name="position">The position to get the nearest target instance to.</param>
        /// <param name="targets">The targets to get the nearest of.</param>
        /// <param name="distance">The distance to the nearest target.</param>
        /// <returns>The nearest instance from the targets to the position. Will be NULL if the targets list is empty.</returns>
        public static GameObject Nearest([NotNull] this GameObject position, [NotNull] IEnumerable<GameObject> targets, out float distance) => position.transform.position.Flatten().Nearest(targets, out distance);
    }
}