using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using UnityEngine;

namespace KaijuSolutions.Agents
{
    /// <summary>
    /// General Kaiju Agents functions.
    /// </summary>
    public static partial class KaijuAgents
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
        
        /// <summary>
        /// The nearest instance across all three axes to a position.
        /// </summary>
        /// <param name="position">The position to get the nearest target instance to.</param>
        /// <param name="targets">The targets to get the nearest of.</param>
        /// <param name="distance">The distance to the nearest target.</param>
        /// <returns>The nearest instance from the targets to the position. Will be the starting position if the targets list is empty.</returns>
        public static Vector3 Nearest3(this Vector3 position, [NotNull] IEnumerable<Vector3> targets, out float distance)
        {
            Vector3? nearest = null;
            distance = float.MaxValue;
            foreach (Vector3 target in targets)
            {
                float current = position.Distance3(target);
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
        /// The nearest instance across all three axes to a position.
        /// </summary>
        /// <param name="position">The position to get the nearest target instance to.</param>
        /// <param name="targets">The targets to get the nearest of.</param>
        /// <param name="distance">The distance to the nearest target.</param>
        /// <returns>The nearest instance from the targets to the position. Will be NULL if the targets list is empty.</returns>
        public static Transform Nearest3(this Vector3 position, [NotNull] IEnumerable<Transform> targets, out float distance)
        {
            Transform nearest = null;
            distance = float.MaxValue;
            foreach (Transform target in targets)
            {
                float current = position.Distance3(target);
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
        /// The nearest instance across all three axes to a position.
        /// </summary>
        /// <param name="position">The position to get the nearest target instance to.</param>
        /// <param name="targets">The targets to get the nearest of.</param>
        /// <param name="distance">The distance to the nearest target.</param>
        /// <returns>The nearest instance from the targets to the position. Will be NULL if the targets list is empty.</returns>
        public static T Nearest3<T>(this Vector3 position, [NotNull] IEnumerable<T> targets, out float distance) where T : Component
        {
            T nearest = null;
            distance = float.MaxValue;
            foreach (T target in targets)
            {
                float current = position.Distance3(target);
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
        /// The nearest instance across all three axes to a position.
        /// </summary>
        /// <param name="position">The position to get the nearest target instance to.</param>
        /// <param name="targets">The targets to get the nearest of.</param>
        /// <param name="distance">The distance to the nearest target.</param>
        /// <returns>The nearest instance from the targets to the position. Will be NULL if the targets list is empty.</returns>
        public static GameObject Nearest3(this Vector3 position, [NotNull] IEnumerable<GameObject> targets, out float distance)
        {
            GameObject nearest = null;
            distance = float.MaxValue;
            foreach (GameObject target in targets)
            {
                float current = position.Distance3(target);
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
        /// The nearest instance across all three axes to a position.
        /// </summary>
        /// <param name="position">The position to get the nearest target instance to.</param>
        /// <param name="targets">The targets to get the nearest of.</param>
        /// <param name="distance">The distance to the nearest target.</param>
        /// <returns>The nearest instance from the targets to the position. Will be the starting position if the targets list is empty.</returns>
        public static Vector3 Nearest3([NotNull] this Transform position, [NotNull] IEnumerable<Vector3> targets, out float distance) => position.position.Nearest3(targets, out distance);
        
        /// <summary>
        /// The nearest instance across all three axes to a position.
        /// </summary>
        /// <param name="position">The position to get the nearest target instance to.</param>
        /// <param name="targets">The targets to get the nearest of.</param>
        /// <param name="distance">The distance to the nearest target.</param>
        /// <returns>The nearest instance from the targets to the position. Will be NULL if the targets list is empty.</returns>
        public static Transform Nearest3([NotNull] this Transform position, [NotNull] IEnumerable<Transform> targets, out float distance) => position.position.Nearest3(targets, out distance);
        
        /// <summary>
        /// The nearest instance across all three axes to a position.
        /// </summary>
        /// <param name="position">The position to get the nearest target instance to.</param>
        /// <param name="targets">The targets to get the nearest of.</param>
        /// <param name="distance">The distance to the nearest target.</param>
        /// <returns>The nearest instance from the targets to the position. Will be NULL if the targets list is empty.</returns>
        public static T Nearest3<T>([NotNull] this Transform position, [NotNull] IEnumerable<T> targets, out float distance) where T : Component => position.position.Nearest3(targets, out distance);
        
        /// <summary>
        /// The nearest instance across all three axes to a position.
        /// </summary>
        /// <param name="position">The position to get the nearest target instance to.</param>
        /// <param name="targets">The targets to get the nearest of.</param>
        /// <param name="distance">The distance to the nearest target.</param>
        /// <returns>The nearest instance from the targets to the position. Will be NULL if the targets list is empty.</returns>
        public static GameObject Nearest3([NotNull] this Transform position, [NotNull] IEnumerable<GameObject> targets, out float distance) => position.position.Nearest3(targets, out distance);
        
        /// <summary>
        /// The nearest instance across all three axes to a position.
        /// </summary>
        /// <param name="position">The position to get the nearest target instance to.</param>
        /// <param name="targets">The targets to get the nearest of.</param>
        /// <param name="distance">The distance to the nearest target.</param>
        /// <returns>The nearest instance from the targets to the position. Will be the starting position if the targets list is empty.</returns>
        public static Vector3 Nearest3([NotNull] this Component position, [NotNull] IEnumerable<Vector3> targets, out float distance) => position.transform.position.Nearest3(targets, out distance);
        
        /// <summary>
        /// The nearest instance across all three axes to a position.
        /// </summary>
        /// <param name="position">The position to get the nearest target instance to.</param>
        /// <param name="targets">The targets to get the nearest of.</param>
        /// <param name="distance">The distance to the nearest target.</param>
        /// <returns>The nearest instance from the targets to the position. Will be NULL if the targets list is empty.</returns>
        public static Transform Nearest3([NotNull] this Component position, [NotNull] IEnumerable<Transform> targets, out float distance) => position.transform.position.Nearest3(targets, out distance);
        
        /// <summary>
        /// The nearest instance across all three axes to a position.
        /// </summary>
        /// <param name="position">The position to get the nearest target instance to.</param>
        /// <param name="targets">The targets to get the nearest of.</param>
        /// <param name="distance">The distance to the nearest target.</param>
        /// <returns>The nearest instance from the targets to the position. Will be NULL if the targets list is empty.</returns>
        public static T Nearest3<T>([NotNull] this Component position, [NotNull] IEnumerable<T> targets, out float distance) where T : Component => position.transform.position.Nearest3(targets, out distance);
        
        /// <summary>
        /// The nearest instance across all three axes to a position.
        /// </summary>
        /// <param name="position">The position to get the nearest target instance to.</param>
        /// <param name="targets">The targets to get the nearest of.</param>
        /// <param name="distance">The distance to the nearest target.</param>
        /// <returns>The nearest instance from the targets to the position. Will be NULL if the targets list is empty.</returns>
        public static GameObject Nearest3([NotNull] this Component position, [NotNull] IEnumerable<GameObject> targets, out float distance) => position.transform.position.Nearest3(targets, out distance);
        
        /// <summary>
        /// The nearest instance across all three axes to a position.
        /// </summary>
        /// <param name="position">The position to get the nearest target instance to.</param>
        /// <param name="targets">The targets to get the nearest of.</param>
        /// <param name="distance">The distance to the nearest target.</param>
        /// <returns>The nearest instance from the targets to the position. Will be the starting position if the targets list is empty.</returns>
        public static Vector3 Nearest3([NotNull] this GameObject position, [NotNull] IEnumerable<Vector3> targets, out float distance) => position.transform.position.Nearest3(targets, out distance);
        
        /// <summary>
        /// The nearest instance across all three axes to a position.
        /// </summary>
        /// <param name="position">The position to get the nearest target instance to.</param>
        /// <param name="targets">The targets to get the nearest of.</param>
        /// <param name="distance">The distance to the nearest target.</param>
        /// <returns>The nearest instance from the targets to the position. Will be NULL if the targets list is empty.</returns>
        public static Transform Nearest3([NotNull] this GameObject position, [NotNull] IEnumerable<Transform> targets, out float distance) => position.transform.position.Nearest3(targets, out distance);
        
        /// <summary>
        /// The nearest instance across all three axes to a position.
        /// </summary>
        /// <param name="position">The position to get the nearest target instance to.</param>
        /// <param name="targets">The targets to get the nearest of.</param>
        /// <param name="distance">The distance to the nearest target.</param>
        /// <returns>The nearest instance from the targets to the position. Will be NULL if the targets list is empty.</returns>
        public static T Nearest3<T>([NotNull] this GameObject position, [NotNull] IEnumerable<T> targets, out float distance) where T : Component => position.transform.position.Nearest3(targets, out distance);
        
        /// <summary>
        /// The nearest instance across all three axes to a position.
        /// </summary>
        /// <param name="position">The position to get the nearest target instance to.</param>
        /// <param name="targets">The targets to get the nearest of.</param>
        /// <param name="distance">The distance to the nearest target.</param>
        /// <returns>The nearest instance from the targets to the position. Will be NULL if the targets list is empty.</returns>
        public static GameObject Nearest3([NotNull] this GameObject position, [NotNull] IEnumerable<GameObject> targets, out float distance) => position.transform.position.Nearest3(targets, out distance);
        
        /// <summary>
        /// The farthest instance from a position.
        /// </summary>
        /// <param name="position">The position to get the farthest target instance from.</param>
        /// <param name="targets">The targets to get the farthest from.</param>
        /// <param name="distance">The distance to the farthest target.</param>
        /// <returns>The farthest instance from the targets to the position. Will be the starting position if the targets list is empty.</returns>
        public static Vector2 Farthest(this Vector2 position, [NotNull] IEnumerable<Vector2> targets, out float distance)
        {
            Vector2? farthest = null;
            distance = 0;
            foreach (Vector2 target in targets)
            {
                float current = position.Distance(target);
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
        /// The farthest instance from a position.
        /// </summary>
        /// <param name="position">The position to get the farthest target instance from.</param>
        /// <param name="targets">The targets to get the farthest from.</param>
        /// <param name="distance">The distance to the farthest target.</param>
        /// <returns>The farthest instance from the targets to the position. Will be the starting position if the targets list is empty.</returns>
        public static Vector3 Farthest(this Vector2 position, [NotNull] IEnumerable<Vector3> targets, out float distance)
        {
            Vector3? farthest = null;
            distance = 0;
            foreach (Vector3 target in targets)
            {
                float current = position.Distance(target);
                if (farthest.HasValue && current <= distance)
                {
                    continue;
                }
                
                farthest = target;
                distance = current;
            }
            
            return farthest ?? position.Expand();
        }
        
        /// <summary>
        /// The farthest instance from a position.
        /// </summary>
        /// <param name="position">The position to get the farthest target instance from.</param>
        /// <param name="targets">The targets to get the farthest from.</param>
        /// <param name="distance">The distance to the farthest target.</param>
        /// <returns>The farthest instance from the targets to the position. Will be NULL if the targets list is empty.</returns>
        public static Transform Farthest(this Vector2 position, [NotNull] IEnumerable<Transform> targets, out float distance)
        {
            Transform farthest = null;
            distance = 0;
            foreach (Transform target in targets)
            {
                float current = position.Distance(target);
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
        /// The farthest instance from a position.
        /// </summary>
        /// <param name="position">The position to get the farthest target instance from.</param>
        /// <param name="targets">The targets to get the farthest from.</param>
        /// <param name="distance">The distance to the farthest target.</param>
        /// <returns>The farthest instance from the targets to the position. Will be NULL if the targets list is empty.</returns>
        public static T Farthest<T>(this Vector2 position, [NotNull] IEnumerable<T> targets, out float distance) where T : Component
        {
            T farthest = null;
            distance = 0;
            foreach (T target in targets)
            {
                float current = position.Distance(target);
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
        /// The farthest instance from a position.
        /// </summary>
        /// <param name="position">The position to get the farthest target instance from.</param>
        /// <param name="targets">The targets to get the farthest from.</param>
        /// <param name="distance">The distance to the farthest target.</param>
        /// <returns>The farthest instance from the targets to the position. Will be NULL if the targets list is empty.</returns>
        public static GameObject Farthest(this Vector2 position, [NotNull] IEnumerable<GameObject> targets, out float distance)
        {
            GameObject farthest = null;
            distance = 0;
            foreach (GameObject target in targets)
            {
                float current = position.Distance(target);
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
        /// The farthest instance from a position.
        /// </summary>
        /// <param name="position">The position to get the farthest target instance from.</param>
        /// <param name="targets">The targets to get the farthest from.</param>
        /// <param name="distance">The distance to the farthest target.</param>
        /// <returns>The farthest instance from the targets to the position. Will be the starting position if the targets list is empty.</returns>
        public static Vector2 Farthest(this Vector3 position, [NotNull] IEnumerable<Vector2> targets, out float distance) => position.Flatten().Farthest(targets, out distance);
        
        /// <summary>
        /// The farthest instance from a position.
        /// </summary>
        /// <param name="position">The position to get the farthest target instance from.</param>
        /// <param name="targets">The targets to get the farthest from.</param>
        /// <param name="distance">The distance to the farthest target.</param>
        /// <returns>The farthest instance from the targets to the position. Will be the starting position if the targets list is empty.</returns>
        public static Vector3 Farthest(this Vector3 position, [NotNull] IEnumerable<Vector3> targets, out float distance) => position.Flatten().Farthest(targets, out distance);
        
        /// <summary>
        /// The farthest instance from a position.
        /// </summary>
        /// <param name="position">The position to get the farthest target instance from.</param>
        /// <param name="targets">The targets to get the farthest from.</param>
        /// <param name="distance">The distance to the farthest target.</param>
        /// <returns>The farthest instance from the targets to the position. Will be NULL if the targets list is empty.</returns>
        public static Transform Farthest(this Vector3 position, [NotNull] IEnumerable<Transform> targets, out float distance) => position.Flatten().Farthest(targets, out distance);
        
        /// <summary>
        /// The farthest instance from a position.
        /// </summary>
        /// <param name="position">The position to get the farthest target instance from.</param>
        /// <param name="targets">The targets to get the farthest from.</param>
        /// <param name="distance">The distance to the farthest target.</param>
        /// <returns>The farthest instance from the targets to the position. Will be NULL if the targets list is empty.</returns>
        public static T Farthest<T>(this Vector3 position, [NotNull] IEnumerable<T> targets, out float distance) where T : Component => position.Flatten().Farthest(targets, out distance);
        
        /// <summary>
        /// The farthest instance from a position.
        /// </summary>
        /// <param name="position">The position to get the farthest target instance from.</param>
        /// <param name="targets">The targets to get the farthest from.</param>
        /// <param name="distance">The distance to the farthest target.</param>
        /// <returns>The farthest instance from the targets to the position. Will be NULL if the targets list is empty.</returns>
        public static GameObject Farthest(this Vector3 position, [NotNull] IEnumerable<GameObject> targets, out float distance) => position.Flatten().Farthest(targets, out distance);
        
        /// <summary>
        /// The farthest instance from a position.
        /// </summary>
        /// <param name="position">The position to get the farthest target instance from.</param>
        /// <param name="targets">The targets to get the farthest from.</param>
        /// <param name="distance">The distance to the farthest target.</param>
        /// <returns>The farthest instance from the targets to the position. Will be the starting position if the targets list is empty.</returns>
        public static Vector2 Farthest([NotNull] this Transform position, [NotNull] IEnumerable<Vector2> targets, out float distance) => position.position.Flatten().Farthest(targets, out distance);
        
        /// <summary>
        /// The farthest instance from a position.
        /// </summary>
        /// <param name="position">The position to get the farthest target instance from.</param>
        /// <param name="targets">The targets to get the farthest from.</param>
        /// <param name="distance">The distance to the farthest target.</param>
        /// <returns>The farthest instance from the targets to the position. Will be the starting position if the targets list is empty.</returns>
        public static Vector3 Farthest([NotNull] this Transform position, [NotNull] IEnumerable<Vector3> targets, out float distance) => position.position.Flatten().Farthest(targets, out distance);
        
        /// <summary>
        /// The farthest instance from a position.
        /// </summary>
        /// <param name="position">The position to get the farthest target instance from.</param>
        /// <param name="targets">The targets to get the farthest from.</param>
        /// <param name="distance">The distance to the farthest target.</param>
        /// <returns>The farthest instance from the targets to the position. Will be NULL if the targets list is empty.</returns>
        public static Transform Farthest([NotNull] this Transform position, [NotNull] IEnumerable<Transform> targets, out float distance) => position.position.Flatten().Farthest(targets, out distance);
        
        /// <summary>
        /// The farthest instance from a position.
        /// </summary>
        /// <param name="position">The position to get the farthest target instance from.</param>
        /// <param name="targets">The targets to get the farthest from.</param>
        /// <param name="distance">The distance to the farthest target.</param>
        /// <returns>The farthest instance from the targets to the position. Will be NULL if the targets list is empty.</returns>
        public static T Farthest<T>([NotNull] this Transform position, [NotNull] IEnumerable<T> targets, out float distance) where T : Component => position.position.Flatten().Farthest(targets, out distance);
        
        /// <summary>
        /// The farthest instance from a position.
        /// </summary>
        /// <param name="position">The position to get the farthest target instance from.</param>
        /// <param name="targets">The targets to get the farthest from.</param>
        /// <param name="distance">The distance to the farthest target.</param>
        /// <returns>The farthest instance from the targets to the position. Will be NULL if the targets list is empty.</returns>
        public static GameObject Farthest([NotNull] this Transform position, [NotNull] IEnumerable<GameObject> targets, out float distance) => position.position.Flatten().Farthest(targets, out distance);
        
        /// <summary>
        /// The farthest instance from a position.
        /// </summary>
        /// <param name="position">The position to get the farthest target instance from.</param>
        /// <param name="targets">The targets to get the farthest from.</param>
        /// <param name="distance">The distance to the farthest target.</param>
        /// <returns>The farthest instance from the targets to the position. Will be the starting position if the targets list is empty.</returns>
        public static Vector2 Farthest([NotNull] this Component position, [NotNull] IEnumerable<Vector2> targets, out float distance) => position.transform.position.Flatten().Farthest(targets, out distance);
        
        /// <summary>
        /// The farthest instance from a position.
        /// </summary>
        /// <param name="position">The position to get the farthest target instance from.</param>
        /// <param name="targets">The targets to get the farthest from.</param>
        /// <param name="distance">The distance to the farthest target.</param>
        /// <returns>The farthest instance from the targets to the position. Will be the starting position if the targets list is empty.</returns>
        public static Vector3 Farthest([NotNull] this Component position, [NotNull] IEnumerable<Vector3> targets, out float distance) => position.transform.position.Flatten().Farthest(targets, out distance);
        
        /// <summary>
        /// The farthest instance from a position.
        /// </summary>
        /// <param name="position">The position to get the farthest target instance from.</param>
        /// <param name="targets">The targets to get the farthest from.</param>
        /// <param name="distance">The distance to the farthest target.</param>
        /// <returns>The farthest instance from the targets to the position. Will be NULL if the targets list is empty.</returns>
        public static Transform Farthest([NotNull] this Component position, [NotNull] IEnumerable<Transform> targets, out float distance) => position.transform.position.Flatten().Farthest(targets, out distance);
        
        /// <summary>
        /// The farthest instance from a position.
        /// </summary>
        /// <param name="position">The position to get the farthest target instance from.</param>
        /// <param name="targets">The targets to get the farthest from.</param>
        /// <param name="distance">The distance to the farthest target.</param>
        /// <returns>The farthest instance from the targets to the position. Will be NULL if the targets list is empty.</returns>
        public static T Farthest<T>([NotNull] this Component position, [NotNull] IEnumerable<T> targets, out float distance) where T : Component => position.transform.position.Flatten().Farthest(targets, out distance);
        
        /// <summary>
        /// The farthest instance from a position.
        /// </summary>
        /// <param name="position">The position to get the farthest target instance from.</param>
        /// <param name="targets">The targets to get the farthest from.</param>
        /// <param name="distance">The distance to the farthest target.</param>
        /// <returns>The farthest instance from the targets to the position. Will be NULL if the targets list is empty.</returns>
        public static GameObject Farthest([NotNull] this Component position, [NotNull] IEnumerable<GameObject> targets, out float distance) => position.transform.position.Flatten().Farthest(targets, out distance);
        
        /// <summary>
        /// The farthest instance from a position.
        /// </summary>
        /// <param name="position">The position to get the farthest target instance from.</param>
        /// <param name="targets">The targets to get the farthest from.</param>
        /// <param name="distance">The distance to the farthest target.</param>
        /// <returns>The farthest instance from the targets to the position. Will be the starting position if the targets list is empty.</returns>
        public static Vector2 Farthest([NotNull] this GameObject position, [NotNull] IEnumerable<Vector2> targets, out float distance) => position.transform.position.Flatten().Farthest(targets, out distance);
        
        /// <summary>
        /// The farthest instance from a position.
        /// </summary>
        /// <param name="position">The position to get the farthest target instance from.</param>
        /// <param name="targets">The targets to get the farthest from.</param>
        /// <param name="distance">The distance to the farthest target.</param>
        /// <returns>The farthest instance from the targets to the position. Will be the starting position if the targets list is empty.</returns>
        public static Vector3 Farthest([NotNull] this GameObject position, [NotNull] IEnumerable<Vector3> targets, out float distance) => position.transform.position.Flatten().Farthest(targets, out distance);
        
        /// <summary>
        /// The farthest instance from a position.
        /// </summary>
        /// <param name="position">The position to get the farthest target instance from.</param>
        /// <param name="targets">The targets to get the farthest from.</param>
        /// <param name="distance">The distance to the farthest target.</param>
        /// <returns>The farthest instance from the targets to the position. Will be NULL if the targets list is empty.</returns>
        public static Transform Farthest([NotNull] this GameObject position, [NotNull] IEnumerable<Transform> targets, out float distance) => position.transform.position.Flatten().Farthest(targets, out distance);
        
        /// <summary>
        /// The farthest instance from a position.
        /// </summary>
        /// <param name="position">The position to get the farthest target instance from.</param>
        /// <param name="targets">The targets to get the farthest from.</param>
        /// <param name="distance">The distance to the farthest target.</param>
        /// <returns>The farthest instance from the targets to the position. Will be NULL if the targets list is empty.</returns>
        public static T Farthest<T>([NotNull] this GameObject position, [NotNull] IEnumerable<T> targets, out float distance) where T : Component => position.transform.position.Flatten().Farthest(targets, out distance);
        
        /// <summary>
        /// The farthest instance from a position.
        /// </summary>
        /// <param name="position">The position to get the farthest target instance from.</param>
        /// <param name="targets">The targets to get the farthest from.</param>
        /// <param name="distance">The distance to the farthest target.</param>
        /// <returns>The farthest instance from the targets to the position. Will be NULL if the targets list is empty.</returns>
        public static GameObject Farthest([NotNull] this GameObject position, [NotNull] IEnumerable<GameObject> targets, out float distance) => position.transform.position.Flatten().Farthest(targets, out distance);
        
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