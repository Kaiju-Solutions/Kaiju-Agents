using System.Diagnostics.CodeAnalysis;
using UnityEngine;

namespace KaijuSolutions.Agents
{
    /// <summary>
    /// Extension methods to get if a target is within the field-of-view. This does not consider vertical field-of-view, meaning it checks relative to the global Y axis. All three-dimensional vectors will be flattened via methods in <see cref="KaijuAgentsFlatten"/>.
    /// </summary>
    public static class KaijuAgentsInView
    {
        /// <summary>
        /// If a target is within the field-of-view. This does not consider vertical field-of-view.
        /// </summary>
        /// <param name="position">The position to check field-of-view from.</param>
        /// <param name="forward">The forward direction to start the field-of-view check from.</param>
        /// <param name="target">The target position to check if it is within the field-of-view.</param>
        /// <param name="fov">The field-of-view in degrees.</param>
        /// <returns>If a target is within the field-of-view.</returns>
        public static bool InView(this Vector2 position, Vector2 forward, Vector2 target, float fov)
        {
            // Get the direction vector.
            Vector2 directionToTarget = target.Direction(position);
            
            // Early exit if vectors are too small to avoid NaN errors on normalize. Calculate Dot product using the normalized vectors and see if it is in range.
            return forward.sqrMagnitude >= Mathf.Epsilon && directionToTarget.sqrMagnitude >= Mathf.Epsilon && Vector2.Dot(forward.normalized, directionToTarget.normalized) >= Mathf.Cos(fov / 2.0f * Mathf.Deg2Rad);
        }
        
        /// <summary>
        /// If a target is within the field-of-view. This does not consider vertical field-of-view.
        /// </summary>
        /// <param name="position">The position to check field-of-view from.</param>
        /// <param name="forward">The forward direction to start the field-of-view check from.</param>
        /// <param name="target">The target position to check if it is within the field-of-view.</param>
        /// <param name="fov">The field-of-view in degrees.</param>
        /// <returns>If a target is within the field-of-view.</returns>
        public static bool InView(this Vector2 position, Vector2 forward, Vector3 target, float fov) => position.InView(forward, target.Flatten(), fov);
        
        /// <summary>
        /// If a target is within the field-of-view. This does not consider vertical field-of-view.
        /// </summary>
        /// <param name="position">The position to check field-of-view from.</param>
        /// <param name="forward">The forward direction to start the field-of-view check from.</param>
        /// <param name="target">The target position to check if it is within the field-of-view.</param>
        /// <param name="fov">The field-of-view in degrees.</param>
        /// <returns>If a target is within the field-of-view.</returns>
        public static bool InView(this Vector2 position, Vector2 forward, [NotNull] Transform target, float fov) => position.InView(forward, target.position, fov);
        
        /// <summary>
        /// If a target is within the field-of-view. This does not consider vertical field-of-view.
        /// </summary>
        /// <param name="position">The position to check field-of-view from.</param>
        /// <param name="forward">The forward direction to start the field-of-view check from.</param>
        /// <param name="target">The target position to check if it is within the field-of-view.</param>
        /// <param name="fov">The field-of-view in degrees.</param>
        /// <returns>If a target is within the field-of-view.</returns>
        public static bool InView(this Vector2 position, Vector2 forward, [NotNull] Component target, float fov) => position.InView(forward, target.transform.position, fov);
        
        /// <summary>
        /// If a target is within the field-of-view. This does not consider vertical field-of-view.
        /// </summary>
        /// <param name="position">The position to check field-of-view from.</param>
        /// <param name="forward">The forward direction to start the field-of-view check from.</param>
        /// <param name="target">The target position to check if it is within the field-of-view.</param>
        /// <param name="fov">The field-of-view in degrees.</param>
        /// <returns>If a target is within the field-of-view.</returns>
        public static bool InView(this Vector2 position, Vector2 forward, [NotNull] GameObject target, float fov) => position.InView(forward, target.transform.position, fov);
        
        /// <summary>
        /// If a target is within the field-of-view. This does not consider vertical field-of-view.
        /// </summary>
        /// <param name="position">The position to check field-of-view from.</param>
        /// <param name="forward">The forward direction to start the field-of-view check from.</param>
        /// <param name="target">The target position to check if it is within the field-of-view.</param>
        /// <param name="fov">The field-of-view in degrees.</param>
        /// <returns>If a target is within the field-of-view.</returns>
        public static bool InView(this Vector2 position, Vector3 forward, Vector2 target, float fov) => position.InView(forward.Flatten(), target, fov);
        
        /// <summary>
        /// If a target is within the field-of-view. This does not consider vertical field-of-view.
        /// </summary>
        /// <param name="position">The position to check field-of-view from.</param>
        /// <param name="forward">The forward direction to start the field-of-view check from.</param>
        /// <param name="target">The target position to check if it is within the field-of-view.</param>
        /// <param name="fov">The field-of-view in degrees.</param>
        /// <returns>If a target is within the field-of-view.</returns>
        public static bool InView(this Vector2 position, Vector3 forward, Vector3 target, float fov) => position.InView(forward.Flatten(), target.Flatten(), fov);
        
        /// <summary>
        /// If a target is within the field-of-view. This does not consider vertical field-of-view.
        /// </summary>
        /// <param name="position">The position to check field-of-view from.</param>
        /// <param name="forward">The forward direction to start the field-of-view check from.</param>
        /// <param name="target">The target position to check if it is within the field-of-view.</param>
        /// <param name="fov">The field-of-view in degrees.</param>
        /// <returns>If a target is within the field-of-view.</returns>
        public static bool InView(this Vector2 position, Vector3 forward, [NotNull] Transform target, float fov) => position.InView(forward, target.position, fov);
        
        /// <summary>
        /// If a target is within the field-of-view. This does not consider vertical field-of-view.
        /// </summary>
        /// <param name="position">The position to check field-of-view from.</param>
        /// <param name="forward">The forward direction to start the field-of-view check from.</param>
        /// <param name="target">The target position to check if it is within the field-of-view.</param>
        /// <param name="fov">The field-of-view in degrees.</param>
        /// <returns>If a target is within the field-of-view.</returns>
        public static bool InView(this Vector2 position, Vector3 forward, [NotNull] Component target, float fov) => position.InView(forward, target.transform.position, fov);
        
        /// <summary>
        /// If a target is within the field-of-view. This does not consider vertical field-of-view.
        /// </summary>
        /// <param name="position">The position to check field-of-view from.</param>
        /// <param name="forward">The forward direction to start the field-of-view check from.</param>
        /// <param name="target">The target position to check if it is within the field-of-view.</param>
        /// <param name="fov">The field-of-view in degrees.</param>
        /// <returns>If a target is within the field-of-view.</returns>
        public static bool InView(this Vector2 position, Vector3 forward, [NotNull] GameObject target, float fov) => position.InView(forward, target.transform.position, fov);
        
        /// <summary>
        /// If a target is within the field-of-view. This does not consider vertical field-of-view.
        /// </summary>
        /// <param name="position">The position to check field-of-view from.</param>
        /// <param name="forward">The forward direction to start the field-of-view check from.</param>
        /// <param name="target">The target position to check if it is within the field-of-view.</param>
        /// <param name="fov">The field-of-view in degrees.</param>
        /// <returns>If a target is within the field-of-view.</returns>
        public static bool InView(this Vector2 position, [NotNull] Transform forward, Vector2 target, float fov) => position.InView(forward.Flatten(), target, fov);
        
        /// <summary>
        /// If a target is within the field-of-view. This does not consider vertical field-of-view.
        /// </summary>
        /// <param name="position">The position to check field-of-view from.</param>
        /// <param name="forward">The forward direction to start the field-of-view check from.</param>
        /// <param name="target">The target position to check if it is within the field-of-view.</param>
        /// <param name="fov">The field-of-view in degrees.</param>
        /// <returns>If a target is within the field-of-view.</returns>
        public static bool InView(this Vector2 position, [NotNull] Transform forward, Vector3 target, float fov) => position.InView(forward.Flatten(), target.Flatten(), fov);
        
        /// <summary>
        /// If a target is within the field-of-view. This does not consider vertical field-of-view.
        /// </summary>
        /// <param name="position">The position to check field-of-view from.</param>
        /// <param name="forward">The forward direction to start the field-of-view check from.</param>
        /// <param name="target">The target position to check if it is within the field-of-view.</param>
        /// <param name="fov">The field-of-view in degrees.</param>
        /// <returns>If a target is within the field-of-view.</returns>
        public static bool InView(this Vector2 position, [NotNull] Transform forward, [NotNull] Transform target, float fov) => position.InView(forward.position, target.position, fov);
        
        /// <summary>
        /// If a target is within the field-of-view. This does not consider vertical field-of-view.
        /// </summary>
        /// <param name="position">The position to check field-of-view from.</param>
        /// <param name="forward">The forward direction to start the field-of-view check from.</param>
        /// <param name="target">The target position to check if it is within the field-of-view.</param>
        /// <param name="fov">The field-of-view in degrees.</param>
        /// <returns>If a target is within the field-of-view.</returns>
        public static bool InView(this Vector2 position, [NotNull] Transform forward, [NotNull] Component target, float fov) => position.InView(forward.position, target.transform.position, fov);
        
        /// <summary>
        /// If a target is within the field-of-view. This does not consider vertical field-of-view.
        /// </summary>
        /// <param name="position">The position to check field-of-view from.</param>
        /// <param name="forward">The forward direction to start the field-of-view check from.</param>
        /// <param name="target">The target position to check if it is within the field-of-view.</param>
        /// <param name="fov">The field-of-view in degrees.</param>
        /// <returns>If a target is within the field-of-view.</returns>
        public static bool InView(this Vector2 position, [NotNull] Transform forward, [NotNull] GameObject target, float fov) => position.InView(forward.position, target.transform.position, fov);
        
        /// <summary>
        /// If a target is within the field-of-view. This does not consider vertical field-of-view.
        /// </summary>
        /// <param name="position">The position to check field-of-view from.</param>
        /// <param name="forward">The forward direction to start the field-of-view check from.</param>
        /// <param name="target">The target position to check if it is within the field-of-view.</param>
        /// <param name="fov">The field-of-view in degrees.</param>
        /// <returns>If a target is within the field-of-view.</returns>
        public static bool InView(this Vector2 position, [NotNull] Component forward, Vector2 target, float fov) => position.InView(forward.Flatten(), target, fov);
        
        /// <summary>
        /// If a target is within the field-of-view. This does not consider vertical field-of-view.
        /// </summary>
        /// <param name="position">The position to check field-of-view from.</param>
        /// <param name="forward">The forward direction to start the field-of-view check from.</param>
        /// <param name="target">The target position to check if it is within the field-of-view.</param>
        /// <param name="fov">The field-of-view in degrees.</param>
        /// <returns>If a target is within the field-of-view.</returns>
        public static bool InView(this Vector2 position, [NotNull] Component forward, Vector3 target, float fov) => position.InView(forward.Flatten(), target.Flatten(), fov);
        
        /// <summary>
        /// If a target is within the field-of-view. This does not consider vertical field-of-view.
        /// </summary>
        /// <param name="position">The position to check field-of-view from.</param>
        /// <param name="forward">The forward direction to start the field-of-view check from.</param>
        /// <param name="target">The target position to check if it is within the field-of-view.</param>
        /// <param name="fov">The field-of-view in degrees.</param>
        /// <returns>If a target is within the field-of-view.</returns>
        public static bool InView(this Vector2 position, [NotNull] Component forward, [NotNull] Transform target, float fov) => position.InView(forward.transform.position, target.position, fov);
        
        /// <summary>
        /// If a target is within the field-of-view. This does not consider vertical field-of-view.
        /// </summary>
        /// <param name="position">The position to check field-of-view from.</param>
        /// <param name="forward">The forward direction to start the field-of-view check from.</param>
        /// <param name="target">The target position to check if it is within the field-of-view.</param>
        /// <param name="fov">The field-of-view in degrees.</param>
        /// <returns>If a target is within the field-of-view.</returns>
        public static bool InView(this Vector2 position, [NotNull] Component forward, [NotNull] Component target, float fov) => position.InView(forward.transform.position, target.transform.position, fov);
        
        /// <summary>
        /// If a target is within the field-of-view. This does not consider vertical field-of-view.
        /// </summary>
        /// <param name="position">The position to check field-of-view from.</param>
        /// <param name="forward">The forward direction to start the field-of-view check from.</param>
        /// <param name="target">The target position to check if it is within the field-of-view.</param>
        /// <param name="fov">The field-of-view in degrees.</param>
        /// <returns>If a target is within the field-of-view.</returns>
        public static bool InView(this Vector2 position, [NotNull] Component forward, [NotNull] GameObject target, float fov) => position.InView(forward.transform.position, target.transform.position, fov);
        
        /// <summary>
        /// If a target is within the field-of-view. This does not consider vertical field-of-view.
        /// </summary>
        /// <param name="position">The position to check field-of-view from.</param>
        /// <param name="forward">The forward direction to start the field-of-view check from.</param>
        /// <param name="target">The target position to check if it is within the field-of-view.</param>
        /// <param name="fov">The field-of-view in degrees.</param>
        /// <returns>If a target is within the field-of-view.</returns>
        public static bool InView(this Vector2 position, [NotNull] GameObject forward, Vector2 target, float fov) => position.InView(forward.Flatten(), target, fov);
        
        /// <summary>
        /// If a target is within the field-of-view. This does not consider vertical field-of-view.
        /// </summary>
        /// <param name="position">The position to check field-of-view from.</param>
        /// <param name="forward">The forward direction to start the field-of-view check from.</param>
        /// <param name="target">The target position to check if it is within the field-of-view.</param>
        /// <param name="fov">The field-of-view in degrees.</param>
        /// <returns>If a target is within the field-of-view.</returns>
        public static bool InView(this Vector2 position, [NotNull] GameObject forward, Vector3 target, float fov) => position.InView(forward.Flatten(), target.Flatten(), fov);
        
        /// <summary>
        /// If a target is within the field-of-view. This does not consider vertical field-of-view.
        /// </summary>
        /// <param name="position">The position to check field-of-view from.</param>
        /// <param name="forward">The forward direction to start the field-of-view check from.</param>
        /// <param name="target">The target position to check if it is within the field-of-view.</param>
        /// <param name="fov">The field-of-view in degrees.</param>
        /// <returns>If a target is within the field-of-view.</returns>
        public static bool InView(this Vector2 position, [NotNull] GameObject forward, [NotNull] Transform target, float fov) => position.InView(forward.transform.position, target.position, fov);
        
        /// <summary>
        /// If a target is within the field-of-view. This does not consider vertical field-of-view.
        /// </summary>
        /// <param name="position">The position to check field-of-view from.</param>
        /// <param name="forward">The forward direction to start the field-of-view check from.</param>
        /// <param name="target">The target position to check if it is within the field-of-view.</param>
        /// <param name="fov">The field-of-view in degrees.</param>
        /// <returns>If a target is within the field-of-view.</returns>
        public static bool InView(this Vector2 position, [NotNull] GameObject forward, [NotNull] Component target, float fov) => position.InView(forward.transform.position, target.transform.position, fov);
        
        /// <summary>
        /// If a target is within the field-of-view. This does not consider vertical field-of-view.
        /// </summary>
        /// <param name="position">The position to check field-of-view from.</param>
        /// <param name="forward">The forward direction to start the field-of-view check from.</param>
        /// <param name="target">The target position to check if it is within the field-of-view.</param>
        /// <param name="fov">The field-of-view in degrees.</param>
        /// <returns>If a target is within the field-of-view.</returns>
        public static bool InView(this Vector2 position, [NotNull] GameObject forward, [NotNull] GameObject target, float fov) => position.InView(forward.transform.position, target.transform.position, fov);
        
        /// <summary>
        /// If a target is within the field-of-view. This does not consider vertical field-of-view.
        /// </summary>
        /// <param name="position">The position to check field-of-view from.</param>
        /// <param name="forward">The forward direction to start the field-of-view check from.</param>
        /// <param name="target">The target position to check if it is within the field-of-view.</param>
        /// <param name="fov">The field-of-view in degrees.</param>
        /// <returns>If a target is within the field-of-view.</returns>
        public static bool InView(this Vector3 position, Vector2 forward, Vector2 target, float fov) => position.Flatten().InView(forward, target, fov);
        
        /// <summary>
        /// If a target is within the field-of-view. This does not consider vertical field-of-view.
        /// </summary>
        /// <param name="position">The position to check field-of-view from.</param>
        /// <param name="forward">The forward direction to start the field-of-view check from.</param>
        /// <param name="target">The target position to check if it is within the field-of-view.</param>
        /// <param name="fov">The field-of-view in degrees.</param>
        /// <returns>If a target is within the field-of-view.</returns>
        public static bool InView(this Vector3 position, Vector2 forward, Vector3 target, float fov) => position.Flatten().InView(forward, target, fov);
        
        /// <summary>
        /// If a target is within the field-of-view. This does not consider vertical field-of-view.
        /// </summary>
        /// <param name="position">The position to check field-of-view from.</param>
        /// <param name="forward">The forward direction to start the field-of-view check from.</param>
        /// <param name="target">The target position to check if it is within the field-of-view.</param>
        /// <param name="fov">The field-of-view in degrees.</param>
        /// <returns>If a target is within the field-of-view.</returns>
        public static bool InView(this Vector3 position, Vector2 forward, [NotNull] Transform target, float fov) => position.InView(forward, target.position, fov);
        
        /// <summary>
        /// If a target is within the field-of-view. This does not consider vertical field-of-view.
        /// </summary>
        /// <param name="position">The position to check field-of-view from.</param>
        /// <param name="forward">The forward direction to start the field-of-view check from.</param>
        /// <param name="target">The target position to check if it is within the field-of-view.</param>
        /// <param name="fov">The field-of-view in degrees.</param>
        /// <returns>If a target is within the field-of-view.</returns>
        public static bool InView(this Vector3 position, Vector2 forward, [NotNull] Component target, float fov) => position.InView(forward, target.transform.position, fov);
        
        /// <summary>
        /// If a target is within the field-of-view. This does not consider vertical field-of-view.
        /// </summary>
        /// <param name="position">The position to check field-of-view from.</param>
        /// <param name="forward">The forward direction to start the field-of-view check from.</param>
        /// <param name="target">The target position to check if it is within the field-of-view.</param>
        /// <param name="fov">The field-of-view in degrees.</param>
        /// <returns>If a target is within the field-of-view.</returns>
        public static bool InView(this Vector3 position, Vector2 forward, [NotNull] GameObject target, float fov) => position.InView(forward, target.transform.position, fov);
        
        /// <summary>
        /// If a target is within the field-of-view. This does not consider vertical field-of-view.
        /// </summary>
        /// <param name="position">The position to check field-of-view from.</param>
        /// <param name="forward">The forward direction to start the field-of-view check from.</param>
        /// <param name="target">The target position to check if it is within the field-of-view.</param>
        /// <param name="fov">The field-of-view in degrees.</param>
        /// <returns>If a target is within the field-of-view.</returns>
        public static bool InView(this Vector3 position, Vector3 forward, Vector2 target, float fov) => position.Flatten().InView(forward, target, fov);
        
        /// <summary>
        /// If a target is within the field-of-view. This does not consider vertical field-of-view.
        /// </summary>
        /// <param name="position">The position to check field-of-view from.</param>
        /// <param name="forward">The forward direction to start the field-of-view check from.</param>
        /// <param name="target">The target position to check if it is within the field-of-view.</param>
        /// <param name="fov">The field-of-view in degrees.</param>
        /// <returns>If a target is within the field-of-view.</returns>
        public static bool InView(this Vector3 position, Vector3 forward, Vector3 target, float fov) => position.Flatten().InView(forward, target, fov);
        
        /// <summary>
        /// If a target is within the field-of-view. This does not consider vertical field-of-view.
        /// </summary>
        /// <param name="position">The position to check field-of-view from.</param>
        /// <param name="forward">The forward direction to start the field-of-view check from.</param>
        /// <param name="target">The target position to check if it is within the field-of-view.</param>
        /// <param name="fov">The field-of-view in degrees.</param>
        /// <returns>If a target is within the field-of-view.</returns>
        public static bool InView(this Vector3 position, Vector3 forward, [NotNull] Transform target, float fov) => position.InView(forward, target.position, fov);
        
        /// <summary>
        /// If a target is within the field-of-view. This does not consider vertical field-of-view.
        /// </summary>
        /// <param name="position">The position to check field-of-view from.</param>
        /// <param name="forward">The forward direction to start the field-of-view check from.</param>
        /// <param name="target">The target position to check if it is within the field-of-view.</param>
        /// <param name="fov">The field-of-view in degrees.</param>
        /// <returns>If a target is within the field-of-view.</returns>
        public static bool InView(this Vector3 position, Vector3 forward, [NotNull] Component target, float fov) => position.InView(forward, target.transform.position, fov);
        
        /// <summary>
        /// If a target is within the field-of-view. This does not consider vertical field-of-view.
        /// </summary>
        /// <param name="position">The position to check field-of-view from.</param>
        /// <param name="forward">The forward direction to start the field-of-view check from.</param>
        /// <param name="target">The target position to check if it is within the field-of-view.</param>
        /// <param name="fov">The field-of-view in degrees.</param>
        /// <returns>If a target is within the field-of-view.</returns>
        public static bool InView(this Vector3 position, Vector3 forward, [NotNull] GameObject target, float fov) => position.InView(forward, target.transform.position, fov);
        
        /// <summary>
        /// If a target is within the field-of-view. This does not consider vertical field-of-view.
        /// </summary>
        /// <param name="position">The position to check field-of-view from.</param>
        /// <param name="forward">The forward direction to start the field-of-view check from.</param>
        /// <param name="target">The target position to check if it is within the field-of-view.</param>
        /// <param name="fov">The field-of-view in degrees.</param>
        /// <returns>If a target is within the field-of-view.</returns>
        public static bool InView(this Vector3 position, [NotNull] Transform forward, Vector2 target, float fov) => position.InView(forward.Flatten(), target, fov);
        
        /// <summary>
        /// If a target is within the field-of-view. This does not consider vertical field-of-view.
        /// </summary>
        /// <param name="position">The position to check field-of-view from.</param>
        /// <param name="forward">The forward direction to start the field-of-view check from.</param>
        /// <param name="target">The target position to check if it is within the field-of-view.</param>
        /// <param name="fov">The field-of-view in degrees.</param>
        /// <returns>If a target is within the field-of-view.</returns>
        public static bool InView(this Vector3 position, [NotNull] Transform forward, Vector3 target, float fov) => position.InView(forward.Flatten(), target.Flatten(), fov);
        
        /// <summary>
        /// If a target is within the field-of-view. This does not consider vertical field-of-view.
        /// </summary>
        /// <param name="position">The position to check field-of-view from.</param>
        /// <param name="forward">The forward direction to start the field-of-view check from.</param>
        /// <param name="target">The target position to check if it is within the field-of-view.</param>
        /// <param name="fov">The field-of-view in degrees.</param>
        /// <returns>If a target is within the field-of-view.</returns>
        public static bool InView(this Vector3 position, [NotNull] Transform forward, [NotNull] Transform target, float fov) => position.InView(forward.position, target.position, fov);
        
        /// <summary>
        /// If a target is within the field-of-view. This does not consider vertical field-of-view.
        /// </summary>
        /// <param name="position">The position to check field-of-view from.</param>
        /// <param name="forward">The forward direction to start the field-of-view check from.</param>
        /// <param name="target">The target position to check if it is within the field-of-view.</param>
        /// <param name="fov">The field-of-view in degrees.</param>
        /// <returns>If a target is within the field-of-view.</returns>
        public static bool InView(this Vector3 position, [NotNull] Transform forward, [NotNull] Component target, float fov) => position.InView(forward.position, target.transform.position, fov);
        
        /// <summary>
        /// If a target is within the field-of-view. This does not consider vertical field-of-view.
        /// </summary>
        /// <param name="position">The position to check field-of-view from.</param>
        /// <param name="forward">The forward direction to start the field-of-view check from.</param>
        /// <param name="target">The target position to check if it is within the field-of-view.</param>
        /// <param name="fov">The field-of-view in degrees.</param>
        /// <returns>If a target is within the field-of-view.</returns>
        public static bool InView(this Vector3 position, [NotNull] Transform forward, [NotNull] GameObject target, float fov) => position.InView(forward.position, target.transform.position, fov);
        
        /// <summary>
        /// If a target is within the field-of-view. This does not consider vertical field-of-view.
        /// </summary>
        /// <param name="position">The position to check field-of-view from.</param>
        /// <param name="forward">The forward direction to start the field-of-view check from.</param>
        /// <param name="target">The target position to check if it is within the field-of-view.</param>
        /// <param name="fov">The field-of-view in degrees.</param>
        /// <returns>If a target is within the field-of-view.</returns>
        public static bool InView(this Vector3 position, [NotNull] Component forward, Vector2 target, float fov) => position.InView(forward.Flatten(), target, fov);
        
        /// <summary>
        /// If a target is within the field-of-view. This does not consider vertical field-of-view.
        /// </summary>
        /// <param name="position">The position to check field-of-view from.</param>
        /// <param name="forward">The forward direction to start the field-of-view check from.</param>
        /// <param name="target">The target position to check if it is within the field-of-view.</param>
        /// <param name="fov">The field-of-view in degrees.</param>
        /// <returns>If a target is within the field-of-view.</returns>
        public static bool InView(this Vector3 position, [NotNull] Component forward, Vector3 target, float fov) => position.InView(forward.Flatten(), target.Flatten(), fov);
        
        /// <summary>
        /// If a target is within the field-of-view. This does not consider vertical field-of-view.
        /// </summary>
        /// <param name="position">The position to check field-of-view from.</param>
        /// <param name="forward">The forward direction to start the field-of-view check from.</param>
        /// <param name="target">The target position to check if it is within the field-of-view.</param>
        /// <param name="fov">The field-of-view in degrees.</param>
        /// <returns>If a target is within the field-of-view.</returns>
        public static bool InView(this Vector3 position, [NotNull] Component forward, [NotNull] Transform target, float fov) => position.InView(forward.transform.position, target.position, fov);
        
        /// <summary>
        /// If a target is within the field-of-view. This does not consider vertical field-of-view.
        /// </summary>
        /// <param name="position">The position to check field-of-view from.</param>
        /// <param name="forward">The forward direction to start the field-of-view check from.</param>
        /// <param name="target">The target position to check if it is within the field-of-view.</param>
        /// <param name="fov">The field-of-view in degrees.</param>
        /// <returns>If a target is within the field-of-view.</returns>
        public static bool InView(this Vector3 position, [NotNull] Component forward, [NotNull] Component target, float fov) => position.InView(forward.transform.position, target.transform.position, fov);
        
        /// <summary>
        /// If a target is within the field-of-view. This does not consider vertical field-of-view.
        /// </summary>
        /// <param name="position">The position to check field-of-view from.</param>
        /// <param name="forward">The forward direction to start the field-of-view check from.</param>
        /// <param name="target">The target position to check if it is within the field-of-view.</param>
        /// <param name="fov">The field-of-view in degrees.</param>
        /// <returns>If a target is within the field-of-view.</returns>
        public static bool InView(this Vector3 position, [NotNull] Component forward, [NotNull] GameObject target, float fov) => position.InView(forward.transform.position, target.transform.position, fov);
        
        /// <summary>
        /// If a target is within the field-of-view. This does not consider vertical field-of-view.
        /// </summary>
        /// <param name="position">The position to check field-of-view from.</param>
        /// <param name="forward">The forward direction to start the field-of-view check from.</param>
        /// <param name="target">The target position to check if it is within the field-of-view.</param>
        /// <param name="fov">The field-of-view in degrees.</param>
        /// <returns>If a target is within the field-of-view.</returns>
        public static bool InView(this Vector3 position, [NotNull] GameObject forward, Vector2 target, float fov) => position.InView(forward.Flatten(), target, fov);
        
        /// <summary>
        /// If a target is within the field-of-view. This does not consider vertical field-of-view.
        /// </summary>
        /// <param name="position">The position to check field-of-view from.</param>
        /// <param name="forward">The forward direction to start the field-of-view check from.</param>
        /// <param name="target">The target position to check if it is within the field-of-view.</param>
        /// <param name="fov">The field-of-view in degrees.</param>
        /// <returns>If a target is within the field-of-view.</returns>
        public static bool InView(this Vector3 position, [NotNull] GameObject forward, Vector3 target, float fov) => position.InView(forward.Flatten(), target.Flatten(), fov);
        
        /// <summary>
        /// If a target is within the field-of-view. This does not consider vertical field-of-view.
        /// </summary>
        /// <param name="position">The position to check field-of-view from.</param>
        /// <param name="forward">The forward direction to start the field-of-view check from.</param>
        /// <param name="target">The target position to check if it is within the field-of-view.</param>
        /// <param name="fov">The field-of-view in degrees.</param>
        /// <returns>If a target is within the field-of-view.</returns>
        public static bool InView(this Vector3 position, [NotNull] GameObject forward, [NotNull] Transform target, float fov) => position.InView(forward.transform.position, target.position, fov);
        
        /// <summary>
        /// If a target is within the field-of-view. This does not consider vertical field-of-view.
        /// </summary>
        /// <param name="position">The position to check field-of-view from.</param>
        /// <param name="forward">The forward direction to start the field-of-view check from.</param>
        /// <param name="target">The target position to check if it is within the field-of-view.</param>
        /// <param name="fov">The field-of-view in degrees.</param>
        /// <returns>If a target is within the field-of-view.</returns>
        public static bool InView(this Vector3 position, [NotNull] GameObject forward, [NotNull] Component target, float fov) => position.InView(forward.transform.position, target.transform.position, fov);
        
        /// <summary>
        /// If a target is within the field-of-view. This does not consider vertical field-of-view.
        /// </summary>
        /// <param name="position">The position to check field-of-view from.</param>
        /// <param name="forward">The forward direction to start the field-of-view check from.</param>
        /// <param name="target">The target position to check if it is within the field-of-view.</param>
        /// <param name="fov">The field-of-view in degrees.</param>
        /// <returns>If a target is within the field-of-view.</returns>
        public static bool InView(this Vector3 position, [NotNull] GameObject forward, [NotNull] GameObject target, float fov) => position.InView(forward.transform.position, target.transform.position, fov);
        
        /// <summary>
        /// If a target is within the field-of-view. This does not consider vertical field-of-view.
        /// </summary>
        /// <param name="position">The position to check field-of-view from.</param>
        /// <param name="forward">The forward direction to start the field-of-view check from.</param>
        /// <param name="target">The target position to check if it is within the field-of-view.</param>
        /// <param name="fov">The field-of-view in degrees.</param>
        /// <returns>If a target is within the field-of-view.</returns>
        public static bool InView([NotNull] this Transform position, Vector2 forward, Vector2 target, float fov) => position.position.InView(forward, target, fov);
        
        /// <summary>
        /// If a target is within the field-of-view. This does not consider vertical field-of-view.
        /// </summary>
        /// <param name="position">The position to check field-of-view from.</param>
        /// <param name="forward">The forward direction to start the field-of-view check from.</param>
        /// <param name="target">The target position to check if it is within the field-of-view.</param>
        /// <param name="fov">The field-of-view in degrees.</param>
        /// <returns>If a target is within the field-of-view.</returns>
        public static bool InView([NotNull] this Transform position, Vector2 forward, Vector3 target, float fov) => position.position.InView(forward, target, fov);
        
        /// <summary>
        /// If a target is within the field-of-view. This does not consider vertical field-of-view.
        /// </summary>
        /// <param name="position">The position to check field-of-view from.</param>
        /// <param name="forward">The forward direction to start the field-of-view check from.</param>
        /// <param name="target">The target position to check if it is within the field-of-view.</param>
        /// <param name="fov">The field-of-view in degrees.</param>
        /// <returns>If a target is within the field-of-view.</returns>
        public static bool InView([NotNull] this Transform position, Vector2 forward, [NotNull] Transform target, float fov) => position.position.InView(forward, target.position, fov);
        
        /// <summary>
        /// If a target is within the field-of-view. This does not consider vertical field-of-view.
        /// </summary>
        /// <param name="position">The position to check field-of-view from.</param>
        /// <param name="forward">The forward direction to start the field-of-view check from.</param>
        /// <param name="target">The target position to check if it is within the field-of-view.</param>
        /// <param name="fov">The field-of-view in degrees.</param>
        /// <returns>If a target is within the field-of-view.</returns>
        public static bool InView([NotNull] this Transform position, Vector2 forward, [NotNull] Component target, float fov) => position.position.InView(forward, target.transform.position, fov);
        
        /// <summary>
        /// If a target is within the field-of-view. This does not consider vertical field-of-view.
        /// </summary>
        /// <param name="position">The position to check field-of-view from.</param>
        /// <param name="forward">The forward direction to start the field-of-view check from.</param>
        /// <param name="target">The target position to check if it is within the field-of-view.</param>
        /// <param name="fov">The field-of-view in degrees.</param>
        /// <returns>If a target is within the field-of-view.</returns>
        public static bool InView([NotNull] this Transform position, Vector2 forward, [NotNull] GameObject target, float fov) => position.position.InView(forward, target.transform.position, fov);
        
        /// <summary>
        /// If a target is within the field-of-view. This does not consider vertical field-of-view.
        /// </summary>
        /// <param name="position">The position to check field-of-view from.</param>
        /// <param name="forward">The forward direction to start the field-of-view check from.</param>
        /// <param name="target">The target position to check if it is within the field-of-view.</param>
        /// <param name="fov">The field-of-view in degrees.</param>
        /// <returns>If a target is within the field-of-view.</returns>
        public static bool InView([NotNull] this Transform position, Vector3 forward, Vector2 target, float fov) => position.position.InView(forward, target, fov);
        
        /// <summary>
        /// If a target is within the field-of-view. This does not consider vertical field-of-view.
        /// </summary>
        /// <param name="position">The position to check field-of-view from.</param>
        /// <param name="forward">The forward direction to start the field-of-view check from.</param>
        /// <param name="target">The target position to check if it is within the field-of-view.</param>
        /// <param name="fov">The field-of-view in degrees.</param>
        /// <returns>If a target is within the field-of-view.</returns>
        public static bool InView([NotNull] this Transform position, Vector3 forward, Vector3 target, float fov) => position.position.InView(forward, target, fov);
        
        /// <summary>
        /// If a target is within the field-of-view. This does not consider vertical field-of-view.
        /// </summary>
        /// <param name="position">The position to check field-of-view from.</param>
        /// <param name="forward">The forward direction to start the field-of-view check from.</param>
        /// <param name="target">The target position to check if it is within the field-of-view.</param>
        /// <param name="fov">The field-of-view in degrees.</param>
        /// <returns>If a target is within the field-of-view.</returns>
        public static bool InView([NotNull] this Transform position, Vector3 forward, [NotNull] Transform target, float fov) => position.position.InView(forward, target.position, fov);
        
        /// <summary>
        /// If a target is within the field-of-view. This does not consider vertical field-of-view.
        /// </summary>
        /// <param name="position">The position to check field-of-view from.</param>
        /// <param name="forward">The forward direction to start the field-of-view check from.</param>
        /// <param name="target">The target position to check if it is within the field-of-view.</param>
        /// <param name="fov">The field-of-view in degrees.</param>
        /// <returns>If a target is within the field-of-view.</returns>
        public static bool InView([NotNull] this Transform position, Vector3 forward, [NotNull] Component target, float fov) => position.position.InView(forward, target.transform.position, fov);
        
        /// <summary>
        /// If a target is within the field-of-view. This does not consider vertical field-of-view.
        /// </summary>
        /// <param name="position">The position to check field-of-view from.</param>
        /// <param name="forward">The forward direction to start the field-of-view check from.</param>
        /// <param name="target">The target position to check if it is within the field-of-view.</param>
        /// <param name="fov">The field-of-view in degrees.</param>
        /// <returns>If a target is within the field-of-view.</returns>
        public static bool InView([NotNull] this Transform position, Vector3 forward, [NotNull] GameObject target, float fov) => position.position.InView(forward, target.transform.position, fov);
        
        /// <summary>
        /// If a target is within the field-of-view. This does not consider vertical field-of-view.
        /// </summary>
        /// <param name="position">The position to check field-of-view from.</param>
        /// <param name="forward">The forward direction to start the field-of-view check from.</param>
        /// <param name="target">The target position to check if it is within the field-of-view.</param>
        /// <param name="fov">The field-of-view in degrees.</param>
        /// <returns>If a target is within the field-of-view.</returns>
        public static bool InView([NotNull] this Transform position, [NotNull] Transform forward, Vector2 target, float fov) => position.position.InView(forward.Flatten(), target, fov);
        
        /// <summary>
        /// If a target is within the field-of-view. This does not consider vertical field-of-view.
        /// </summary>
        /// <param name="position">The position to check field-of-view from.</param>
        /// <param name="forward">The forward direction to start the field-of-view check from.</param>
        /// <param name="target">The target position to check if it is within the field-of-view.</param>
        /// <param name="fov">The field-of-view in degrees.</param>
        /// <returns>If a target is within the field-of-view.</returns>
        public static bool InView([NotNull] this Transform position, [NotNull] Transform forward, Vector3 target, float fov) => position.position.InView(forward.Flatten(), target.Flatten(), fov);
        
        /// <summary>
        /// If a target is within the field-of-view. This does not consider vertical field-of-view.
        /// </summary>
        /// <param name="position">The position to check field-of-view from.</param>
        /// <param name="forward">The forward direction to start the field-of-view check from.</param>
        /// <param name="target">The target position to check if it is within the field-of-view.</param>
        /// <param name="fov">The field-of-view in degrees.</param>
        /// <returns>If a target is within the field-of-view.</returns>
        public static bool InView([NotNull] this Transform position, [NotNull] Transform forward, [NotNull] Transform target, float fov) => position.position.InView(forward.position, target.position, fov);
        
        /// <summary>
        /// If a target is within the field-of-view. This does not consider vertical field-of-view.
        /// </summary>
        /// <param name="position">The position to check field-of-view from.</param>
        /// <param name="forward">The forward direction to start the field-of-view check from.</param>
        /// <param name="target">The target position to check if it is within the field-of-view.</param>
        /// <param name="fov">The field-of-view in degrees.</param>
        /// <returns>If a target is within the field-of-view.</returns>
        public static bool InView([NotNull] this Transform position, [NotNull] Transform forward, [NotNull] Component target, float fov) => position.position.InView(forward.position, target.transform.position, fov);
        
        /// <summary>
        /// If a target is within the field-of-view. This does not consider vertical field-of-view.
        /// </summary>
        /// <param name="position">The position to check field-of-view from.</param>
        /// <param name="forward">The forward direction to start the field-of-view check from.</param>
        /// <param name="target">The target position to check if it is within the field-of-view.</param>
        /// <param name="fov">The field-of-view in degrees.</param>
        /// <returns>If a target is within the field-of-view.</returns>
        public static bool InView([NotNull] this Transform position, [NotNull] Transform forward, [NotNull] GameObject target, float fov) => position.position.InView(forward.position, target.transform.position, fov);
        
        /// <summary>
        /// If a target is within the field-of-view. This does not consider vertical field-of-view.
        /// </summary>
        /// <param name="position">The position to check field-of-view from.</param>
        /// <param name="forward">The forward direction to start the field-of-view check from.</param>
        /// <param name="target">The target position to check if it is within the field-of-view.</param>
        /// <param name="fov">The field-of-view in degrees.</param>
        /// <returns>If a target is within the field-of-view.</returns>
        public static bool InView([NotNull] this Transform position, [NotNull] Component forward, Vector2 target, float fov) => position.position.InView(forward.Flatten(), target, fov);
        
        /// <summary>
        /// If a target is within the field-of-view. This does not consider vertical field-of-view.
        /// </summary>
        /// <param name="position">The position to check field-of-view from.</param>
        /// <param name="forward">The forward direction to start the field-of-view check from.</param>
        /// <param name="target">The target position to check if it is within the field-of-view.</param>
        /// <param name="fov">The field-of-view in degrees.</param>
        /// <returns>If a target is within the field-of-view.</returns>
        public static bool InView([NotNull] this Transform position, [NotNull] Component forward, Vector3 target, float fov) => position.position.InView(forward.Flatten(), target.Flatten(), fov);
        
        /// <summary>
        /// If a target is within the field-of-view. This does not consider vertical field-of-view.
        /// </summary>
        /// <param name="position">The position to check field-of-view from.</param>
        /// <param name="forward">The forward direction to start the field-of-view check from.</param>
        /// <param name="target">The target position to check if it is within the field-of-view.</param>
        /// <param name="fov">The field-of-view in degrees.</param>
        /// <returns>If a target is within the field-of-view.</returns>
        public static bool InView([NotNull] this Transform position, [NotNull] Component forward, [NotNull] Transform target, float fov) => position.position.InView(forward.transform.position, target.position, fov);
        
        /// <summary>
        /// If a target is within the field-of-view. This does not consider vertical field-of-view.
        /// </summary>
        /// <param name="position">The position to check field-of-view from.</param>
        /// <param name="forward">The forward direction to start the field-of-view check from.</param>
        /// <param name="target">The target position to check if it is within the field-of-view.</param>
        /// <param name="fov">The field-of-view in degrees.</param>
        /// <returns>If a target is within the field-of-view.</returns>
        public static bool InView([NotNull] this Transform position, [NotNull] Component forward, [NotNull] Component target, float fov) => position.position.InView(forward.transform.position, target.transform.position, fov);
        
        /// <summary>
        /// If a target is within the field-of-view. This does not consider vertical field-of-view.
        /// </summary>
        /// <param name="position">The position to check field-of-view from.</param>
        /// <param name="forward">The forward direction to start the field-of-view check from.</param>
        /// <param name="target">The target position to check if it is within the field-of-view.</param>
        /// <param name="fov">The field-of-view in degrees.</param>
        /// <returns>If a target is within the field-of-view.</returns>
        public static bool InView([NotNull] this Transform position, [NotNull] Component forward, [NotNull] GameObject target, float fov) => position.position.InView(forward.transform.position, target.transform.position, fov);
        
        /// <summary>
        /// If a target is within the field-of-view. This does not consider vertical field-of-view.
        /// </summary>
        /// <param name="position">The position to check field-of-view from.</param>
        /// <param name="forward">The forward direction to start the field-of-view check from.</param>
        /// <param name="target">The target position to check if it is within the field-of-view.</param>
        /// <param name="fov">The field-of-view in degrees.</param>
        /// <returns>If a target is within the field-of-view.</returns>
        public static bool InView([NotNull] this Transform position, [NotNull] GameObject forward, Vector2 target, float fov) => position.position.InView(forward.Flatten(), target, fov);
        
        /// <summary>
        /// If a target is within the field-of-view. This does not consider vertical field-of-view.
        /// </summary>
        /// <param name="position">The position to check field-of-view from.</param>
        /// <param name="forward">The forward direction to start the field-of-view check from.</param>
        /// <param name="target">The target position to check if it is within the field-of-view.</param>
        /// <param name="fov">The field-of-view in degrees.</param>
        /// <returns>If a target is within the field-of-view.</returns>
        public static bool InView([NotNull] this Transform position, [NotNull] GameObject forward, Vector3 target, float fov) => position.position.InView(forward.Flatten(), target.Flatten(), fov);
        
        /// <summary>
        /// If a target is within the field-of-view. This does not consider vertical field-of-view.
        /// </summary>
        /// <param name="position">The position to check field-of-view from.</param>
        /// <param name="forward">The forward direction to start the field-of-view check from.</param>
        /// <param name="target">The target position to check if it is within the field-of-view.</param>
        /// <param name="fov">The field-of-view in degrees.</param>
        /// <returns>If a target is within the field-of-view.</returns>
        public static bool InView([NotNull] this Transform position, [NotNull] GameObject forward, [NotNull] Transform target, float fov) => position.position.InView(forward.transform.position, target.position, fov);
        
        /// <summary>
        /// If a target is within the field-of-view. This does not consider vertical field-of-view.
        /// </summary>
        /// <param name="position">The position to check field-of-view from.</param>
        /// <param name="forward">The forward direction to start the field-of-view check from.</param>
        /// <param name="target">The target position to check if it is within the field-of-view.</param>
        /// <param name="fov">The field-of-view in degrees.</param>
        /// <returns>If a target is within the field-of-view.</returns>
        public static bool InView([NotNull] this Transform position, [NotNull] GameObject forward, [NotNull] Component target, float fov) => position.position.InView(forward.transform.position, target.transform.position, fov);
        
        /// <summary>
        /// If a target is within the field-of-view. This does not consider vertical field-of-view.
        /// </summary>
        /// <param name="position">The position to check field-of-view from.</param>
        /// <param name="forward">The forward direction to start the field-of-view check from.</param>
        /// <param name="target">The target position to check if it is within the field-of-view.</param>
        /// <param name="fov">The field-of-view in degrees.</param>
        /// <returns>If a target is within the field-of-view.</returns>
        public static bool InView([NotNull] this Transform position, [NotNull] GameObject forward, [NotNull] GameObject target, float fov) => position.position.InView(forward.transform.position, target.transform.position, fov);
        
        /// <summary>
        /// If a target is within the field-of-view. This does not consider vertical field-of-view.
        /// </summary>
        /// <param name="position">The position to check field-of-view from relative to its forward.</param>
        /// <param name="target">The target position to check if it is within the field-of-view.</param>
        /// <param name="fov">The field-of-view in degrees.</param>
        /// <returns>If a target is within the field-of-view.</returns>
        public static bool InView([NotNull] this Transform position, Vector2 target, float fov) => position.position.InView(position.forward, target, fov);
        
        /// <summary>
        /// If a target is within the field-of-view. This does not consider vertical field-of-view.
        /// </summary>
        /// <param name="position">The position to check field-of-view from relative to its forward.</param>
        /// <param name="target">The target position to check if it is within the field-of-view.</param>
        /// <param name="fov">The field-of-view in degrees.</param>
        /// <returns>If a target is within the field-of-view.</returns>
        public static bool InView([NotNull] this Transform position, Vector3 target, float fov) => position.position.InView(position.forward, target, fov);
        
        /// <summary>
        /// If a target is within the field-of-view. This does not consider vertical field-of-view.
        /// </summary>
        /// <param name="position">The position to check field-of-view from relative to its forward.</param>
        /// <param name="target">The target position to check if it is within the field-of-view.</param>
        /// <param name="fov">The field-of-view in degrees.</param>
        /// <returns>If a target is within the field-of-view.</returns>
        public static bool InView([NotNull] this Transform position, [NotNull] Transform target, float fov) => position.position.InView(position.forward, target.position, fov);
        
        /// <summary>
        /// If a target is within the field-of-view. This does not consider vertical field-of-view.
        /// </summary>
        /// <param name="position">The position to check field-of-view from relative to its forward.</param>
        /// <param name="target">The target position to check if it is within the field-of-view.</param>
        /// <param name="fov">The field-of-view in degrees.</param>
        /// <returns>If a target is within the field-of-view.</returns>
        public static bool InView([NotNull] this Transform position, [NotNull] Component target, float fov) => position.position.InView(position.forward, target.transform.position, fov);
        
        /// <summary>
        /// If a target is within the field-of-view. This does not consider vertical field-of-view.
        /// </summary>
        /// <param name="position">The position to check field-of-view from relative to its forward.</param>
        /// <param name="target">The target position to check if it is within the field-of-view.</param>
        /// <param name="fov">The field-of-view in degrees.</param>
        /// <returns>If a target is within the field-of-view.</returns>
        public static bool InView([NotNull] this Transform position, [NotNull] GameObject target, float fov) => position.position.InView(position.forward, target.transform.position, fov);
        
        /// <summary>
        /// If a target is within the field-of-view. This does not consider vertical field-of-view.
        /// </summary>
        /// <param name="position">The position to check field-of-view from.</param>
        /// <param name="forward">The forward direction to start the field-of-view check from.</param>
        /// <param name="target">The target position to check if it is within the field-of-view.</param>
        /// <param name="fov">The field-of-view in degrees.</param>
        /// <returns>If a target is within the field-of-view.</returns>
        public static bool InView([NotNull] this Component position, Vector2 forward, Vector2 target, float fov) => position.transform.position.InView(forward, target, fov);
        
        /// <summary>
        /// If a target is within the field-of-view. This does not consider vertical field-of-view.
        /// </summary>
        /// <param name="position">The position to check field-of-view from.</param>
        /// <param name="forward">The forward direction to start the field-of-view check from.</param>
        /// <param name="target">The target position to check if it is within the field-of-view.</param>
        /// <param name="fov">The field-of-view in degrees.</param>
        /// <returns>If a target is within the field-of-view.</returns>
        public static bool InView([NotNull] this Component position, Vector2 forward, Vector3 target, float fov) => position.transform.position.InView(forward, target, fov);
        
        /// <summary>
        /// If a target is within the field-of-view. This does not consider vertical field-of-view.
        /// </summary>
        /// <param name="position">The position to check field-of-view from.</param>
        /// <param name="forward">The forward direction to start the field-of-view check from.</param>
        /// <param name="target">The target position to check if it is within the field-of-view.</param>
        /// <param name="fov">The field-of-view in degrees.</param>
        /// <returns>If a target is within the field-of-view.</returns>
        public static bool InView([NotNull] this Component position, Vector2 forward, [NotNull] Transform target, float fov) => position.transform.position.InView(forward, target.position, fov);
        
        /// <summary>
        /// If a target is within the field-of-view. This does not consider vertical field-of-view.
        /// </summary>
        /// <param name="position">The position to check field-of-view from.</param>
        /// <param name="forward">The forward direction to start the field-of-view check from.</param>
        /// <param name="target">The target position to check if it is within the field-of-view.</param>
        /// <param name="fov">The field-of-view in degrees.</param>
        /// <returns>If a target is within the field-of-view.</returns>
        public static bool InView([NotNull] this Component position, Vector2 forward, [NotNull] Component target, float fov) => position.transform.position.InView(forward, target.transform.position, fov);
        
        /// <summary>
        /// If a target is within the field-of-view. This does not consider vertical field-of-view.
        /// </summary>
        /// <param name="position">The position to check field-of-view from.</param>
        /// <param name="forward">The forward direction to start the field-of-view check from.</param>
        /// <param name="target">The target position to check if it is within the field-of-view.</param>
        /// <param name="fov">The field-of-view in degrees.</param>
        /// <returns>If a target is within the field-of-view.</returns>
        public static bool InView([NotNull] this Component position, Vector2 forward, [NotNull] GameObject target, float fov) => position.transform.position.InView(forward, target.transform.position, fov);
        
        /// <summary>
        /// If a target is within the field-of-view. This does not consider vertical field-of-view.
        /// </summary>
        /// <param name="position">The position to check field-of-view from.</param>
        /// <param name="forward">The forward direction to start the field-of-view check from.</param>
        /// <param name="target">The target position to check if it is within the field-of-view.</param>
        /// <param name="fov">The field-of-view in degrees.</param>
        /// <returns>If a target is within the field-of-view.</returns>
        public static bool InView([NotNull] this Component position, Vector3 forward, Vector2 target, float fov) => position.transform.position.InView(forward, target, fov);
        
        /// <summary>
        /// If a target is within the field-of-view. This does not consider vertical field-of-view.
        /// </summary>
        /// <param name="position">The position to check field-of-view from.</param>
        /// <param name="forward">The forward direction to start the field-of-view check from.</param>
        /// <param name="target">The target position to check if it is within the field-of-view.</param>
        /// <param name="fov">The field-of-view in degrees.</param>
        /// <returns>If a target is within the field-of-view.</returns>
        public static bool InView([NotNull] this Component position, Vector3 forward, Vector3 target, float fov) => position.transform.position.InView(forward, target, fov);
        
        /// <summary>
        /// If a target is within the field-of-view. This does not consider vertical field-of-view.
        /// </summary>
        /// <param name="position">The position to check field-of-view from.</param>
        /// <param name="forward">The forward direction to start the field-of-view check from.</param>
        /// <param name="target">The target position to check if it is within the field-of-view.</param>
        /// <param name="fov">The field-of-view in degrees.</param>
        /// <returns>If a target is within the field-of-view.</returns>
        public static bool InView([NotNull] this Component position, Vector3 forward, [NotNull] Transform target, float fov) => position.transform.position.InView(forward, target.position, fov);
        
        /// <summary>
        /// If a target is within the field-of-view. This does not consider vertical field-of-view.
        /// </summary>
        /// <param name="position">The position to check field-of-view from.</param>
        /// <param name="forward">The forward direction to start the field-of-view check from.</param>
        /// <param name="target">The target position to check if it is within the field-of-view.</param>
        /// <param name="fov">The field-of-view in degrees.</param>
        /// <returns>If a target is within the field-of-view.</returns>
        public static bool InView([NotNull] this Component position, Vector3 forward, [NotNull] Component target, float fov) => position.transform.position.InView(forward, target.transform.position, fov);
        
        /// <summary>
        /// If a target is within the field-of-view. This does not consider vertical field-of-view.
        /// </summary>
        /// <param name="position">The position to check field-of-view from.</param>
        /// <param name="forward">The forward direction to start the field-of-view check from.</param>
        /// <param name="target">The target position to check if it is within the field-of-view.</param>
        /// <param name="fov">The field-of-view in degrees.</param>
        /// <returns>If a target is within the field-of-view.</returns>
        public static bool InView([NotNull] this Component position, Vector3 forward, [NotNull] GameObject target, float fov) => position.transform.position.InView(forward, target.transform.position, fov);
        
        /// <summary>
        /// If a target is within the field-of-view. This does not consider vertical field-of-view.
        /// </summary>
        /// <param name="position">The position to check field-of-view from.</param>
        /// <param name="forward">The forward direction to start the field-of-view check from.</param>
        /// <param name="target">The target position to check if it is within the field-of-view.</param>
        /// <param name="fov">The field-of-view in degrees.</param>
        /// <returns>If a target is within the field-of-view.</returns>
        public static bool InView([NotNull] this Component position, [NotNull] Transform forward, Vector2 target, float fov) => position.transform.position.InView(forward.Flatten(), target, fov);
        
        /// <summary>
        /// If a target is within the field-of-view. This does not consider vertical field-of-view.
        /// </summary>
        /// <param name="position">The position to check field-of-view from.</param>
        /// <param name="forward">The forward direction to start the field-of-view check from.</param>
        /// <param name="target">The target position to check if it is within the field-of-view.</param>
        /// <param name="fov">The field-of-view in degrees.</param>
        /// <returns>If a target is within the field-of-view.</returns>
        public static bool InView([NotNull] this Component position, [NotNull] Transform forward, Vector3 target, float fov) => position.transform.position.InView(forward.Flatten(), target.Flatten(), fov);
        
        /// <summary>
        /// If a target is within the field-of-view. This does not consider vertical field-of-view.
        /// </summary>
        /// <param name="position">The position to check field-of-view from.</param>
        /// <param name="forward">The forward direction to start the field-of-view check from.</param>
        /// <param name="target">The target position to check if it is within the field-of-view.</param>
        /// <param name="fov">The field-of-view in degrees.</param>
        /// <returns>If a target is within the field-of-view.</returns>
        public static bool InView([NotNull] this Component position, [NotNull] Transform forward, [NotNull] Transform target, float fov) => position.transform.position.InView(forward.position, target.position, fov);
        
        /// <summary>
        /// If a target is within the field-of-view. This does not consider vertical field-of-view.
        /// </summary>
        /// <param name="position">The position to check field-of-view from.</param>
        /// <param name="forward">The forward direction to start the field-of-view check from.</param>
        /// <param name="target">The target position to check if it is within the field-of-view.</param>
        /// <param name="fov">The field-of-view in degrees.</param>
        /// <returns>If a target is within the field-of-view.</returns>
        public static bool InView([NotNull] this Component position, [NotNull] Transform forward, [NotNull] Component target, float fov) => position.transform.position.InView(forward.position, target.transform.position, fov);
        
        /// <summary>
        /// If a target is within the field-of-view. This does not consider vertical field-of-view.
        /// </summary>
        /// <param name="position">The position to check field-of-view from.</param>
        /// <param name="forward">The forward direction to start the field-of-view check from.</param>
        /// <param name="target">The target position to check if it is within the field-of-view.</param>
        /// <param name="fov">The field-of-view in degrees.</param>
        /// <returns>If a target is within the field-of-view.</returns>
        public static bool InView([NotNull] this Component position, [NotNull] Transform forward, [NotNull] GameObject target, float fov) => position.transform.position.InView(forward.position, target.transform.position, fov);
        
        /// <summary>
        /// If a target is within the field-of-view. This does not consider vertical field-of-view.
        /// </summary>
        /// <param name="position">The position to check field-of-view from.</param>
        /// <param name="forward">The forward direction to start the field-of-view check from.</param>
        /// <param name="target">The target position to check if it is within the field-of-view.</param>
        /// <param name="fov">The field-of-view in degrees.</param>
        /// <returns>If a target is within the field-of-view.</returns>
        public static bool InView([NotNull] this Component position, [NotNull] Component forward, Vector2 target, float fov) => position.transform.position.InView(forward.Flatten(), target, fov);
        
        /// <summary>
        /// If a target is within the field-of-view. This does not consider vertical field-of-view.
        /// </summary>
        /// <param name="position">The position to check field-of-view from.</param>
        /// <param name="forward">The forward direction to start the field-of-view check from.</param>
        /// <param name="target">The target position to check if it is within the field-of-view.</param>
        /// <param name="fov">The field-of-view in degrees.</param>
        /// <returns>If a target is within the field-of-view.</returns>
        public static bool InView([NotNull] this Component position, [NotNull] Component forward, Vector3 target, float fov) => position.transform.position.InView(forward.Flatten(), target.Flatten(), fov);
        
        /// <summary>
        /// If a target is within the field-of-view. This does not consider vertical field-of-view.
        /// </summary>
        /// <param name="position">The position to check field-of-view from.</param>
        /// <param name="forward">The forward direction to start the field-of-view check from.</param>
        /// <param name="target">The target position to check if it is within the field-of-view.</param>
        /// <param name="fov">The field-of-view in degrees.</param>
        /// <returns>If a target is within the field-of-view.</returns>
        public static bool InView([NotNull] this Component position, [NotNull] Component forward, [NotNull] Transform target, float fov) => position.transform.position.InView(forward.transform.position, target.position, fov);
        
        /// <summary>
        /// If a target is within the field-of-view. This does not consider vertical field-of-view.
        /// </summary>
        /// <param name="position">The position to check field-of-view from.</param>
        /// <param name="forward">The forward direction to start the field-of-view check from.</param>
        /// <param name="target">The target position to check if it is within the field-of-view.</param>
        /// <param name="fov">The field-of-view in degrees.</param>
        /// <returns>If a target is within the field-of-view.</returns>
        public static bool InView([NotNull] this Component position, [NotNull] Component forward, [NotNull] Component target, float fov) => position.transform.position.InView(forward.transform.position, target.transform.position, fov);
        
        /// <summary>
        /// If a target is within the field-of-view. This does not consider vertical field-of-view.
        /// </summary>
        /// <param name="position">The position to check field-of-view from.</param>
        /// <param name="forward">The forward direction to start the field-of-view check from.</param>
        /// <param name="target">The target position to check if it is within the field-of-view.</param>
        /// <param name="fov">The field-of-view in degrees.</param>
        /// <returns>If a target is within the field-of-view.</returns>
        public static bool InView([NotNull] this Component position, [NotNull] Component forward, [NotNull] GameObject target, float fov) => position.transform.position.InView(forward.transform.position, target.transform.position, fov);
        
        /// <summary>
        /// If a target is within the field-of-view. This does not consider vertical field-of-view.
        /// </summary>
        /// <param name="position">The position to check field-of-view from.</param>
        /// <param name="forward">The forward direction to start the field-of-view check from.</param>
        /// <param name="target">The target position to check if it is within the field-of-view.</param>
        /// <param name="fov">The field-of-view in degrees.</param>
        /// <returns>If a target is within the field-of-view.</returns>
        public static bool InView([NotNull] this Component position, [NotNull] GameObject forward, Vector2 target, float fov) => position.transform.position.InView(forward.Flatten(), target, fov);
        
        /// <summary>
        /// If a target is within the field-of-view. This does not consider vertical field-of-view.
        /// </summary>
        /// <param name="position">The position to check field-of-view from.</param>
        /// <param name="forward">The forward direction to start the field-of-view check from.</param>
        /// <param name="target">The target position to check if it is within the field-of-view.</param>
        /// <param name="fov">The field-of-view in degrees.</param>
        /// <returns>If a target is within the field-of-view.</returns>
        public static bool InView([NotNull] this Component position, [NotNull] GameObject forward, Vector3 target, float fov) => position.transform.position.InView(forward.Flatten(), target.Flatten(), fov);
        
        /// <summary>
        /// If a target is within the field-of-view. This does not consider vertical field-of-view.
        /// </summary>
        /// <param name="position">The position to check field-of-view from.</param>
        /// <param name="forward">The forward direction to start the field-of-view check from.</param>
        /// <param name="target">The target position to check if it is within the field-of-view.</param>
        /// <param name="fov">The field-of-view in degrees.</param>
        /// <returns>If a target is within the field-of-view.</returns>
        public static bool InView([NotNull] this Component position, [NotNull] GameObject forward, [NotNull] Transform target, float fov) => position.transform.position.InView(forward.transform.position, target.position, fov);
        
        /// <summary>
        /// If a target is within the field-of-view. This does not consider vertical field-of-view.
        /// </summary>
        /// <param name="position">The position to check field-of-view from.</param>
        /// <param name="forward">The forward direction to start the field-of-view check from.</param>
        /// <param name="target">The target position to check if it is within the field-of-view.</param>
        /// <param name="fov">The field-of-view in degrees.</param>
        /// <returns>If a target is within the field-of-view.</returns>
        public static bool InView([NotNull] this Component position, [NotNull] GameObject forward, [NotNull] Component target, float fov) => position.transform.position.InView(forward.transform.position, target.transform.position, fov);
        
        /// <summary>
        /// If a target is within the field-of-view. This does not consider vertical field-of-view.
        /// </summary>
        /// <param name="position">The position to check field-of-view from.</param>
        /// <param name="forward">The forward direction to start the field-of-view check from.</param>
        /// <param name="target">The target position to check if it is within the field-of-view.</param>
        /// <param name="fov">The field-of-view in degrees.</param>
        /// <returns>If a target is within the field-of-view.</returns>
        public static bool InView([NotNull] this Component position, [NotNull] GameObject forward, [NotNull] GameObject target, float fov) => position.transform.position.InView(forward.transform.position, target.transform.position, fov);
        
        /// <summary>
        /// If a target is within the field-of-view. This does not consider vertical field-of-view.
        /// </summary>
        /// <param name="position">The position to check field-of-view from relative to its forward.</param>
        /// <param name="target">The target position to check if it is within the field-of-view.</param>
        /// <param name="fov">The field-of-view in degrees.</param>
        /// <returns>If a target is within the field-of-view.</returns>
        public static bool InView([NotNull] this Component position, Vector2 target, float fov)
        {
            Transform t = position.transform;
            return t.position.InView(t.forward, target, fov);
        }
        
        /// <summary>
        /// If a target is within the field-of-view. This does not consider vertical field-of-view.
        /// </summary>
        /// <param name="position">The position to check field-of-view from relative to its forward.</param>
        /// <param name="target">The target position to check if it is within the field-of-view.</param>
        /// <param name="fov">The field-of-view in degrees.</param>
        /// <returns>If a target is within the field-of-view.</returns>
        public static bool InView([NotNull] this Component position, Vector3 target, float fov)
        {
            Transform t = position.transform;
            return t.position.InView(t.forward, target, fov);
        }
        
        /// <summary>
        /// If a target is within the field-of-view. This does not consider vertical field-of-view.
        /// </summary>
        /// <param name="position">The position to check field-of-view from relative to its forward.</param>
        /// <param name="target">The target position to check if it is within the field-of-view.</param>
        /// <param name="fov">The field-of-view in degrees.</param>
        /// <returns>If a target is within the field-of-view.</returns>
        public static bool InView([NotNull] this Component position, [NotNull] Transform target, float fov)
        {
            Transform t = position.transform;
            return t.position.InView(t.forward, target.position, fov);
        }
        
        /// <summary>
        /// If a target is within the field-of-view. This does not consider vertical field-of-view.
        /// </summary>
        /// <param name="position">The position to check field-of-view from relative to its forward.</param>
        /// <param name="target">The target position to check if it is within the field-of-view.</param>
        /// <param name="fov">The field-of-view in degrees.</param>
        /// <returns>If a target is within the field-of-view.</returns>
        public static bool InView([NotNull] this Component position, [NotNull] Component target, float fov)
        {
            Transform t = position.transform;
            return t.position.InView(t.forward, target.transform.position, fov);
        }
        
        /// <summary>
        /// If a target is within the field-of-view. This does not consider vertical field-of-view.
        /// </summary>
        /// <param name="position">The position to check field-of-view from relative to its forward.</param>
        /// <param name="target">The target position to check if it is within the field-of-view.</param>
        /// <param name="fov">The field-of-view in degrees.</param>
        /// <returns>If a target is within the field-of-view.</returns>
        public static bool InView([NotNull] this Component position, [NotNull] GameObject target, float fov)
        {
            Transform t = position.transform;
            return t.position.InView(t.forward, target.transform.position, fov);
        }
        
        /// <summary>
        /// If a target is within the field-of-view. This does not consider vertical field-of-view.
        /// </summary>
        /// <param name="position">The position to check field-of-view from.</param>
        /// <param name="forward">The forward direction to start the field-of-view check from.</param>
        /// <param name="target">The target position to check if it is within the field-of-view.</param>
        /// <param name="fov">The field-of-view in degrees.</param>
        /// <returns>If a target is within the field-of-view.</returns>
        public static bool InView([NotNull] this GameObject position, Vector2 forward, Vector2 target, float fov) => position.transform.position.InView(forward, target, fov);
        
        /// <summary>
        /// If a target is within the field-of-view. This does not consider vertical field-of-view.
        /// </summary>
        /// <param name="position">The position to check field-of-view from.</param>
        /// <param name="forward">The forward direction to start the field-of-view check from.</param>
        /// <param name="target">The target position to check if it is within the field-of-view.</param>
        /// <param name="fov">The field-of-view in degrees.</param>
        /// <returns>If a target is within the field-of-view.</returns>
        public static bool InView([NotNull] this GameObject position, Vector2 forward, Vector3 target, float fov) => position.transform.position.InView(forward, target, fov);
        
        /// <summary>
        /// If a target is within the field-of-view. This does not consider vertical field-of-view.
        /// </summary>
        /// <param name="position">The position to check field-of-view from.</param>
        /// <param name="forward">The forward direction to start the field-of-view check from.</param>
        /// <param name="target">The target position to check if it is within the field-of-view.</param>
        /// <param name="fov">The field-of-view in degrees.</param>
        /// <returns>If a target is within the field-of-view.</returns>
        public static bool InView([NotNull] this GameObject position, Vector2 forward, [NotNull] Transform target, float fov) => position.transform.position.InView(forward, target.position, fov);
        
        /// <summary>
        /// If a target is within the field-of-view. This does not consider vertical field-of-view.
        /// </summary>
        /// <param name="position">The position to check field-of-view from.</param>
        /// <param name="forward">The forward direction to start the field-of-view check from.</param>
        /// <param name="target">The target position to check if it is within the field-of-view.</param>
        /// <param name="fov">The field-of-view in degrees.</param>
        /// <returns>If a target is within the field-of-view.</returns>
        public static bool InView([NotNull] this GameObject position, Vector2 forward, [NotNull] Component target, float fov) => position.transform.position.InView(forward, target.transform.position, fov);
        
        /// <summary>
        /// If a target is within the field-of-view. This does not consider vertical field-of-view.
        /// </summary>
        /// <param name="position">The position to check field-of-view from.</param>
        /// <param name="forward">The forward direction to start the field-of-view check from.</param>
        /// <param name="target">The target position to check if it is within the field-of-view.</param>
        /// <param name="fov">The field-of-view in degrees.</param>
        /// <returns>If a target is within the field-of-view.</returns>
        public static bool InView([NotNull] this GameObject position, Vector2 forward, [NotNull] GameObject target, float fov) => position.transform.position.InView(forward, target.transform.position, fov);
        
        /// <summary>
        /// If a target is within the field-of-view. This does not consider vertical field-of-view.
        /// </summary>
        /// <param name="position">The position to check field-of-view from.</param>
        /// <param name="forward">The forward direction to start the field-of-view check from.</param>
        /// <param name="target">The target position to check if it is within the field-of-view.</param>
        /// <param name="fov">The field-of-view in degrees.</param>
        /// <returns>If a target is within the field-of-view.</returns>
        public static bool InView([NotNull] this GameObject position, Vector3 forward, Vector2 target, float fov) => position.transform.position.InView(forward, target, fov);
        
        /// <summary>
        /// If a target is within the field-of-view. This does not consider vertical field-of-view.
        /// </summary>
        /// <param name="position">The position to check field-of-view from.</param>
        /// <param name="forward">The forward direction to start the field-of-view check from.</param>
        /// <param name="target">The target position to check if it is within the field-of-view.</param>
        /// <param name="fov">The field-of-view in degrees.</param>
        /// <returns>If a target is within the field-of-view.</returns>
        public static bool InView([NotNull] this GameObject position, Vector3 forward, Vector3 target, float fov) => position.transform.position.InView(forward, target, fov);
        
        /// <summary>
        /// If a target is within the field-of-view. This does not consider vertical field-of-view.
        /// </summary>
        /// <param name="position">The position to check field-of-view from.</param>
        /// <param name="forward">The forward direction to start the field-of-view check from.</param>
        /// <param name="target">The target position to check if it is within the field-of-view.</param>
        /// <param name="fov">The field-of-view in degrees.</param>
        /// <returns>If a target is within the field-of-view.</returns>
        public static bool InView([NotNull] this GameObject position, Vector3 forward, [NotNull] Transform target, float fov) => position.transform.position.InView(forward, target.position, fov);
        
        /// <summary>
        /// If a target is within the field-of-view. This does not consider vertical field-of-view.
        /// </summary>
        /// <param name="position">The position to check field-of-view from.</param>
        /// <param name="forward">The forward direction to start the field-of-view check from.</param>
        /// <param name="target">The target position to check if it is within the field-of-view.</param>
        /// <param name="fov">The field-of-view in degrees.</param>
        /// <returns>If a target is within the field-of-view.</returns>
        public static bool InView([NotNull] this GameObject position, Vector3 forward, [NotNull] Component target, float fov) => position.transform.position.InView(forward, target.transform.position, fov);
        
        /// <summary>
        /// If a target is within the field-of-view. This does not consider vertical field-of-view.
        /// </summary>
        /// <param name="position">The position to check field-of-view from.</param>
        /// <param name="forward">The forward direction to start the field-of-view check from.</param>
        /// <param name="target">The target position to check if it is within the field-of-view.</param>
        /// <param name="fov">The field-of-view in degrees.</param>
        /// <returns>If a target is within the field-of-view.</returns>
        public static bool InView([NotNull] this GameObject position, Vector3 forward, [NotNull] GameObject target, float fov) => position.transform.position.InView(forward, target.transform.position, fov);
        
        /// <summary>
        /// If a target is within the field-of-view. This does not consider vertical field-of-view.
        /// </summary>
        /// <param name="position">The position to check field-of-view from.</param>
        /// <param name="forward">The forward direction to start the field-of-view check from.</param>
        /// <param name="target">The target position to check if it is within the field-of-view.</param>
        /// <param name="fov">The field-of-view in degrees.</param>
        /// <returns>If a target is within the field-of-view.</returns>
        public static bool InView([NotNull] this GameObject position, [NotNull] Transform forward, Vector2 target, float fov) => position.transform.position.InView(forward.Flatten(), target, fov);
        
        /// <summary>
        /// If a target is within the field-of-view. This does not consider vertical field-of-view.
        /// </summary>
        /// <param name="position">The position to check field-of-view from.</param>
        /// <param name="forward">The forward direction to start the field-of-view check from.</param>
        /// <param name="target">The target position to check if it is within the field-of-view.</param>
        /// <param name="fov">The field-of-view in degrees.</param>
        /// <returns>If a target is within the field-of-view.</returns>
        public static bool InView([NotNull] this GameObject position, [NotNull] Transform forward, Vector3 target, float fov) => position.transform.position.InView(forward.Flatten(), target.Flatten(), fov);
        
        /// <summary>
        /// If a target is within the field-of-view. This does not consider vertical field-of-view.
        /// </summary>
        /// <param name="position">The position to check field-of-view from.</param>
        /// <param name="forward">The forward direction to start the field-of-view check from.</param>
        /// <param name="target">The target position to check if it is within the field-of-view.</param>
        /// <param name="fov">The field-of-view in degrees.</param>
        /// <returns>If a target is within the field-of-view.</returns>
        public static bool InView([NotNull] this GameObject position, [NotNull] Transform forward, [NotNull] Transform target, float fov) => position.transform.position.InView(forward.position, target.position, fov);
        
        /// <summary>
        /// If a target is within the field-of-view. This does not consider vertical field-of-view.
        /// </summary>
        /// <param name="position">The position to check field-of-view from.</param>
        /// <param name="forward">The forward direction to start the field-of-view check from.</param>
        /// <param name="target">The target position to check if it is within the field-of-view.</param>
        /// <param name="fov">The field-of-view in degrees.</param>
        /// <returns>If a target is within the field-of-view.</returns>
        public static bool InView([NotNull] this GameObject position, [NotNull] Transform forward, [NotNull] Component target, float fov) => position.transform.position.InView(forward.position, target.transform.position, fov);
        
        /// <summary>
        /// If a target is within the field-of-view. This does not consider vertical field-of-view.
        /// </summary>
        /// <param name="position">The position to check field-of-view from.</param>
        /// <param name="forward">The forward direction to start the field-of-view check from.</param>
        /// <param name="target">The target position to check if it is within the field-of-view.</param>
        /// <param name="fov">The field-of-view in degrees.</param>
        /// <returns>If a target is within the field-of-view.</returns>
        public static bool InView([NotNull] this GameObject position, [NotNull] Transform forward, [NotNull] GameObject target, float fov) => position.transform.position.InView(forward.position, target.transform.position, fov);
        
        /// <summary>
        /// If a target is within the field-of-view. This does not consider vertical field-of-view.
        /// </summary>
        /// <param name="position">The position to check field-of-view from.</param>
        /// <param name="forward">The forward direction to start the field-of-view check from.</param>
        /// <param name="target">The target position to check if it is within the field-of-view.</param>
        /// <param name="fov">The field-of-view in degrees.</param>
        /// <returns>If a target is within the field-of-view.</returns>
        public static bool InView([NotNull] this GameObject position, [NotNull] Component forward, Vector2 target, float fov) => position.transform.position.InView(forward.Flatten(), target, fov);
        
        /// <summary>
        /// If a target is within the field-of-view. This does not consider vertical field-of-view.
        /// </summary>
        /// <param name="position">The position to check field-of-view from.</param>
        /// <param name="forward">The forward direction to start the field-of-view check from.</param>
        /// <param name="target">The target position to check if it is within the field-of-view.</param>
        /// <param name="fov">The field-of-view in degrees.</param>
        /// <returns>If a target is within the field-of-view.</returns>
        public static bool InView([NotNull] this GameObject position, [NotNull] Component forward, Vector3 target, float fov) => position.transform.position.InView(forward.Flatten(), target.Flatten(), fov);
        
        /// <summary>
        /// If a target is within the field-of-view. This does not consider vertical field-of-view.
        /// </summary>
        /// <param name="position">The position to check field-of-view from.</param>
        /// <param name="forward">The forward direction to start the field-of-view check from.</param>
        /// <param name="target">The target position to check if it is within the field-of-view.</param>
        /// <param name="fov">The field-of-view in degrees.</param>
        /// <returns>If a target is within the field-of-view.</returns>
        public static bool InView([NotNull] this GameObject position, [NotNull] Component forward, [NotNull] Transform target, float fov) => position.transform.position.InView(forward.transform.position, target.position, fov);
        
        /// <summary>
        /// If a target is within the field-of-view. This does not consider vertical field-of-view.
        /// </summary>
        /// <param name="position">The position to check field-of-view from.</param>
        /// <param name="forward">The forward direction to start the field-of-view check from.</param>
        /// <param name="target">The target position to check if it is within the field-of-view.</param>
        /// <param name="fov">The field-of-view in degrees.</param>
        /// <returns>If a target is within the field-of-view.</returns>
        public static bool InView([NotNull] this GameObject position, [NotNull] Component forward, [NotNull] Component target, float fov) => position.transform.position.InView(forward.transform.position, target.transform.position, fov);
        
        /// <summary>
        /// If a target is within the field-of-view. This does not consider vertical field-of-view.
        /// </summary>
        /// <param name="position">The position to check field-of-view from.</param>
        /// <param name="forward">The forward direction to start the field-of-view check from.</param>
        /// <param name="target">The target position to check if it is within the field-of-view.</param>
        /// <param name="fov">The field-of-view in degrees.</param>
        /// <returns>If a target is within the field-of-view.</returns>
        public static bool InView([NotNull] this GameObject position, [NotNull] Component forward, [NotNull] GameObject target, float fov) => position.transform.position.InView(forward.transform.position, target.transform.position, fov);
        
        /// <summary>
        /// If a target is within the field-of-view. This does not consider vertical field-of-view.
        /// </summary>
        /// <param name="position">The position to check field-of-view from.</param>
        /// <param name="forward">The forward direction to start the field-of-view check from.</param>
        /// <param name="target">The target position to check if it is within the field-of-view.</param>
        /// <param name="fov">The field-of-view in degrees.</param>
        /// <returns>If a target is within the field-of-view.</returns>
        public static bool InView([NotNull] this GameObject position, [NotNull] GameObject forward, Vector2 target, float fov) => position.transform.position.InView(forward.Flatten(), target, fov);
        
        /// <summary>
        /// If a target is within the field-of-view. This does not consider vertical field-of-view.
        /// </summary>
        /// <param name="position">The position to check field-of-view from.</param>
        /// <param name="forward">The forward direction to start the field-of-view check from.</param>
        /// <param name="target">The target position to check if it is within the field-of-view.</param>
        /// <param name="fov">The field-of-view in degrees.</param>
        /// <returns>If a target is within the field-of-view.</returns>
        public static bool InView([NotNull] this GameObject position, [NotNull] GameObject forward, Vector3 target, float fov) => position.transform.position.InView(forward.Flatten(), target.Flatten(), fov);
        
        /// <summary>
        /// If a target is within the field-of-view. This does not consider vertical field-of-view.
        /// </summary>
        /// <param name="position">The position to check field-of-view from.</param>
        /// <param name="forward">The forward direction to start the field-of-view check from.</param>
        /// <param name="target">The target position to check if it is within the field-of-view.</param>
        /// <param name="fov">The field-of-view in degrees.</param>
        /// <returns>If a target is within the field-of-view.</returns>
        public static bool InView([NotNull] this GameObject position, [NotNull] GameObject forward, [NotNull] Transform target, float fov) => position.transform.position.InView(forward.transform.position, target.position, fov);
        
        /// <summary>
        /// If a target is within the field-of-view. This does not consider vertical field-of-view.
        /// </summary>
        /// <param name="position">The position to check field-of-view from.</param>
        /// <param name="forward">The forward direction to start the field-of-view check from.</param>
        /// <param name="target">The target position to check if it is within the field-of-view.</param>
        /// <param name="fov">The field-of-view in degrees.</param>
        /// <returns>If a target is within the field-of-view.</returns>
        public static bool InView([NotNull] this GameObject position, [NotNull] GameObject forward, [NotNull] Component target, float fov) => position.transform.position.InView(forward.transform.position, target.transform.position, fov);
        
        /// <summary>
        /// If a target is within the field-of-view. This does not consider vertical field-of-view.
        /// </summary>
        /// <param name="position">The position to check field-of-view from.</param>
        /// <param name="forward">The forward direction to start the field-of-view check from.</param>
        /// <param name="target">The target position to check if it is within the field-of-view.</param>
        /// <param name="fov">The field-of-view in degrees.</param>
        /// <returns>If a target is within the field-of-view.</returns>
        public static bool InView([NotNull] this GameObject position, [NotNull] GameObject forward, [NotNull] GameObject target, float fov) => position.transform.position.InView(forward.transform.position, target.transform.position, fov);
        
        /// <summary>
        /// If a target is within the field-of-view. This does not consider vertical field-of-view.
        /// </summary>
        /// <param name="position">The position to check field-of-view from relative to its forward.</param>
        /// <param name="target">The target position to check if it is within the field-of-view.</param>
        /// <param name="fov">The field-of-view in degrees.</param>
        /// <returns>If a target is within the field-of-view.</returns>
        public static bool InView([NotNull] this GameObject position, Vector2 target, float fov)
        {
            Transform t = position.transform;
            return t.position.InView(t.forward, target, fov);
        }
        
        /// <summary>
        /// If a target is within the field-of-view. This does not consider vertical field-of-view.
        /// </summary>
        /// <param name="position">The position to check field-of-view from relative to its forward.</param>
        /// <param name="target">The target position to check if it is within the field-of-view.</param>
        /// <param name="fov">The field-of-view in degrees.</param>
        /// <returns>If a target is within the field-of-view.</returns>
        public static bool InView([NotNull] this GameObject position, Vector3 target, float fov)
        {
            Transform t = position.transform;
            return t.position.InView(t.forward, target, fov);
        }
        
        /// <summary>
        /// If a target is within the field-of-view. This does not consider vertical field-of-view.
        /// </summary>
        /// <param name="position">The position to check field-of-view from relative to its forward.</param>
        /// <param name="target">The target position to check if it is within the field-of-view.</param>
        /// <param name="fov">The field-of-view in degrees.</param>
        /// <returns>If a target is within the field-of-view.</returns>
        public static bool InView([NotNull] this GameObject position, [NotNull] Transform target, float fov)
        {
            Transform t = position.transform;
            return t.position.InView(t.forward, target.position, fov);
        }
        
        /// <summary>
        /// If a target is within the field-of-view. This does not consider vertical field-of-view.
        /// </summary>
        /// <param name="position">The position to check field-of-view from relative to its forward.</param>
        /// <param name="target">The target position to check if it is within the field-of-view.</param>
        /// <param name="fov">The field-of-view in degrees.</param>
        /// <returns>If a target is within the field-of-view.</returns>
        public static bool InView([NotNull] this GameObject position, [NotNull] Component target, float fov)
        {
            Transform t = position.transform;
            return t.position.InView(t.forward, target.transform.position, fov);
        }
        
        /// <summary>
        /// If a target is within the field-of-view. This does not consider vertical field-of-view.
        /// </summary>
        /// <param name="position">The position to check field-of-view from relative to its forward.</param>
        /// <param name="target">The target position to check if it is within the field-of-view.</param>
        /// <param name="fov">The field-of-view in degrees.</param>
        /// <returns>If a target is within the field-of-view.</returns>
        public static bool InView([NotNull] this GameObject position, [NotNull] GameObject target, float fov)
        {
            Transform t = position.transform;
            return t.position.InView(t.forward, target.transform.position, fov);
        }
    }
}