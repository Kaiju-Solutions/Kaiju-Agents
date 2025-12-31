using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
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
        
        /// <summary>
        /// The nearest instance across all three axes to a position.
        /// </summary>
        /// <param name="position">The position to get the nearest target instance to.</param>
        /// <param name="targets">The targets to get the nearest of.</param>
        /// <param name="distance">The distance to the nearest target.</param>
        /// <returns>The nearest instance from the targets to the position. Will be the starting position if the targets list is empty.</returns>
        public static Vector3 Nearest3(this Vector2 position, [NotNull] IEnumerable<Vector3> targets, out float distance) => position.Expand().Nearest3(targets, out distance);
        
        /// <summary>
        /// The nearest instance across all three axes to a position.
        /// </summary>
        /// <param name="position">The position to get the nearest target instance to.</param>
        /// <param name="targets">The targets to get the nearest of.</param>
        /// <param name="distance">The distance to the nearest target.</param>
        /// <returns>The nearest instance from the targets to the position. Will be NULL if the targets list is empty.</returns>
        public static Transform Nearest3(this Vector2 position, [NotNull] IEnumerable<Transform> targets, out float distance) => position.Expand().Nearest3(targets, out distance);
        
        /// <summary>
        /// The nearest instance across all three axes to a position.
        /// </summary>
        /// <param name="position">The position to get the nearest target instance to.</param>
        /// <param name="targets">The targets to get the nearest of.</param>
        /// <param name="distance">The distance to the nearest target.</param>
        /// <returns>The nearest instance from the targets to the position. Will be NULL if the targets list is empty.</returns>
        public static T Nearest3<T>(this Vector2 position, [NotNull] IEnumerable<T> targets, out float distance) where T : Component => position.Expand().Nearest3(targets, out distance);
        
        /// <summary>
        /// The nearest instance across all three axes to a position.
        /// </summary>
        /// <param name="position">The position to get the nearest target instance to.</param>
        /// <param name="targets">The targets to get the nearest of.</param>
        /// <param name="distance">The distance to the nearest target.</param>
        /// <returns>The nearest instance from the targets to the position. Will be NULL if the targets list is empty.</returns>
        public static GameObject Nearest3(this Vector2 position, [NotNull] IEnumerable<GameObject> targets, out float distance) => position.Expand().Nearest3(targets, out distance);
        
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
                if (target == null)
                {
                    continue;
                }
                
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
                if (target == null)
                {
                    continue;
                }
                
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
                if (target == null)
                {
                    continue;
                }
                
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
        
        /// <summary>
        /// The sorter for Vector2 distance in descending order.
        /// </summary>
        private static readonly DistanceSorter Sorter = new (Vector2.zero);
        
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
    
    /// <summary>
    /// Sort by distance.
    /// </summary>
    public sealed class DistanceSorter : IComparer<Vector2>, IComparer<Vector3>, IComparer<Transform>, IComparer<Component>, IComparer<GameObject>
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
        public Transform PositionComponent
        {
            set => Position = value.Flatten();
        }
        
        /// <summary>
        /// The position to compare against.
        /// </summary>
        public Transform PositionGameObject
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
        public DistanceSorter()
        {
            Position = Vector2.zero;
            Farthest = false;
        }
        
        /// <summary>
        /// Create the sorter.
        /// </summary>
        /// <param name="position">The position to compare against.</param>
        /// <param name="farthest">If this should sort by farthest items first.</param>
        public DistanceSorter(Vector2 position, bool farthest = false)
        {
            Position = position;
            Farthest = farthest;
        }
        
        /// <summary>
        /// Create the sorter.
        /// </summary>
        /// <param name="position">The position to compare against.</param>
        /// <param name="farthest">If this should sort by farthest items first.</param>
        public DistanceSorter(Vector3 position, bool farthest = false)
        {
            Position = position.Flatten();
            Farthest = farthest;
        }
        
        /// <summary>
        /// Create the sorter.
        /// </summary>
        /// <param name="position">The position to compare against.</param>
        /// <param name="farthest">If this should sort by farthest items first.</param>
        public DistanceSorter([NotNull] Transform position, bool farthest = false)
        {
            Position = position.Flatten();
            Farthest = farthest;
        }
        
        /// <summary>
        /// Create the sorter.
        /// </summary>
        /// <param name="position">The position to compare against.</param>
        /// <param name="farthest">If this should sort by farthest items first.</param>
        public DistanceSorter([NotNull] Component position, bool farthest = false)
        {
            Position = position.Flatten();
            Farthest = farthest;
        }
        
        /// <summary>
        /// Create the sorter.
        /// </summary>
        /// <param name="position">The position to compare against.</param>
        /// <param name="farthest">If this should sort by farthest items first.</param>
        public DistanceSorter([NotNull] GameObject position, bool farthest = false)
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
    }
}