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
        /// If a target is within the field of view. This does not consider vertical field of view.
        /// </summary>
        /// <param name="position">The position to check field of view from.</param>
        /// <param name="forward">The forward direction to start the field of view check from.</param>
        /// <param name="target">The target position to check if it is within the field of view.</param>
        /// <param name="fov">The field of view in degrees.</param>
        /// <returns>If a target is within the field of view.</returns>
        public static bool InView(this Vector2 position, Vector2 forward, Vector2 target, float fov)
        {
            // Get the direction vector.
            Vector2 directionToTarget = target.Direction(position);
            
            // Early exit if vectors are too small to avoid NaN errors on normalize. Calculate Dot product using the normalized vectors and see if it is in range.
            return forward.sqrMagnitude >= Mathf.Epsilon && directionToTarget.sqrMagnitude >= Mathf.Epsilon && Vector2.Dot(forward.normalized, directionToTarget.normalized) >= Mathf.Cos(fov / 2.0f * Mathf.Deg2Rad);
        }
        
        /// <summary>
        /// If a target is within the field of view. This does not consider vertical field of view.
        /// </summary>
        /// <param name="position">The position to check field of view from.</param>
        /// <param name="forward">The forward direction to start the field of view check from.</param>
        /// <param name="target">The target position to check if it is within the field of view.</param>
        /// <param name="fov">The field of view in degrees.</param>
        /// <returns>If a target is within the field of view.</returns>
        public static bool InView(this Vector2 position, Vector2 forward, Vector3 target, float fov) => position.InView(forward, target.Flatten(), fov);
        
        /// <summary>
        /// If a target is within the field of view. This does not consider vertical field of view.
        /// </summary>
        /// <param name="position">The position to check field of view from.</param>
        /// <param name="forward">The forward direction to start the field of view check from.</param>
        /// <param name="target">The target position to check if it is within the field of view.</param>
        /// <param name="fov">The field of view in degrees.</param>
        /// <returns>If a target is within the field of view.</returns>
        public static bool InView(this Vector2 position, Vector2 forward, [NotNull] Transform target, float fov) => position.InView(forward, target.position, fov);
        
        /// <summary>
        /// If a target is within the field of view. This does not consider vertical field of view.
        /// </summary>
        /// <param name="position">The position to check field of view from.</param>
        /// <param name="forward">The forward direction to start the field of view check from.</param>
        /// <param name="target">The target position to check if it is within the field of view.</param>
        /// <param name="fov">The field of view in degrees.</param>
        /// <returns>If a target is within the field of view.</returns>
        public static bool InView(this Vector2 position, Vector2 forward, [NotNull] Component target, float fov) => position.InView(forward, target.transform.position, fov);
        
        /// <summary>
        /// If a target is within the field of view. This does not consider vertical field of view.
        /// </summary>
        /// <param name="position">The position to check field of view from.</param>
        /// <param name="forward">The forward direction to start the field of view check from.</param>
        /// <param name="target">The target position to check if it is within the field of view.</param>
        /// <param name="fov">The field of view in degrees.</param>
        /// <returns>If a target is within the field of view.</returns>
        public static bool InView(this Vector2 position, Vector2 forward, [NotNull] GameObject target, float fov) => position.InView(forward, target.transform.position, fov);
        
        /// <summary>
        /// If a target is within the field of view. This does not consider vertical field of view.
        /// </summary>
        /// <param name="position">The position to check field of view from.</param>
        /// <param name="forward">The forward direction to start the field of view check from.</param>
        /// <param name="target">The target position to check if it is within the field of view.</param>
        /// <param name="fov">The field of view in degrees.</param>
        /// <returns>If a target is within the field of view.</returns>
        public static bool InView(this Vector2 position, Vector3 forward, Vector2 target, float fov) => position.InView(forward.Flatten(), target, fov);
        
        /// <summary>
        /// If a target is within the field of view. This does not consider vertical field of view.
        /// </summary>
        /// <param name="position">The position to check field of view from.</param>
        /// <param name="forward">The forward direction to start the field of view check from.</param>
        /// <param name="target">The target position to check if it is within the field of view.</param>
        /// <param name="fov">The field of view in degrees.</param>
        /// <returns>If a target is within the field of view.</returns>
        public static bool InView(this Vector2 position, Vector3 forward, Vector3 target, float fov) => position.InView(forward.Flatten(), target.Flatten(), fov);
        
        /// <summary>
        /// If a target is within the field of view. This does not consider vertical field of view.
        /// </summary>
        /// <param name="position">The position to check field of view from.</param>
        /// <param name="forward">The forward direction to start the field of view check from.</param>
        /// <param name="target">The target position to check if it is within the field of view.</param>
        /// <param name="fov">The field of view in degrees.</param>
        /// <returns>If a target is within the field of view.</returns>
        public static bool InView(this Vector2 position, Vector3 forward, [NotNull] Transform target, float fov) => position.InView(forward, target.position, fov);
        
        /// <summary>
        /// If a target is within the field of view. This does not consider vertical field of view.
        /// </summary>
        /// <param name="position">The position to check field of view from.</param>
        /// <param name="forward">The forward direction to start the field of view check from.</param>
        /// <param name="target">The target position to check if it is within the field of view.</param>
        /// <param name="fov">The field of view in degrees.</param>
        /// <returns>If a target is within the field of view.</returns>
        public static bool InView(this Vector2 position, Vector3 forward, [NotNull] Component target, float fov) => position.InView(forward, target.transform.position, fov);
        
        /// <summary>
        /// If a target is within the field of view. This does not consider vertical field of view.
        /// </summary>
        /// <param name="position">The position to check field of view from.</param>
        /// <param name="forward">The forward direction to start the field of view check from.</param>
        /// <param name="target">The target position to check if it is within the field of view.</param>
        /// <param name="fov">The field of view in degrees.</param>
        /// <returns>If a target is within the field of view.</returns>
        public static bool InView(this Vector2 position, Vector3 forward, [NotNull] GameObject target, float fov) => position.InView(forward, target.transform.position, fov);
        
        /// <summary>
        /// If a target is within the field of view. This does not consider vertical field of view.
        /// </summary>
        /// <param name="position">The position to check field of view from.</param>
        /// <param name="forward">The forward direction to start the field of view check from.</param>
        /// <param name="target">The target position to check if it is within the field of view.</param>
        /// <param name="fov">The field of view in degrees.</param>
        /// <returns>If a target is within the field of view.</returns>
        public static bool InView(this Vector3 position, Vector2 forward, Vector2 target, float fov) => position.Flatten().InView(forward, target, fov);
        
        /// <summary>
        /// If a target is within the field of view. This does not consider vertical field of view.
        /// </summary>
        /// <param name="position">The position to check field of view from.</param>
        /// <param name="forward">The forward direction to start the field of view check from.</param>
        /// <param name="target">The target position to check if it is within the field of view.</param>
        /// <param name="fov">The field of view in degrees.</param>
        /// <returns>If a target is within the field of view.</returns>
        public static bool InView(this Vector3 position, Vector2 forward, Vector3 target, float fov) => position.Flatten().InView(forward, target, fov);
        
        /// <summary>
        /// If a target is within the field of view. This does not consider vertical field of view.
        /// </summary>
        /// <param name="position">The position to check field of view from.</param>
        /// <param name="forward">The forward direction to start the field of view check from.</param>
        /// <param name="target">The target position to check if it is within the field of view.</param>
        /// <param name="fov">The field of view in degrees.</param>
        /// <returns>If a target is within the field of view.</returns>
        public static bool InView(this Vector3 position, Vector2 forward, [NotNull] Transform target, float fov) => position.InView(forward, target.position, fov);
        
        /// <summary>
        /// If a target is within the field of view. This does not consider vertical field of view.
        /// </summary>
        /// <param name="position">The position to check field of view from.</param>
        /// <param name="forward">The forward direction to start the field of view check from.</param>
        /// <param name="target">The target position to check if it is within the field of view.</param>
        /// <param name="fov">The field of view in degrees.</param>
        /// <returns>If a target is within the field of view.</returns>
        public static bool InView(this Vector3 position, Vector2 forward, [NotNull] Component target, float fov) => position.InView(forward, target.transform.position, fov);
        
        /// <summary>
        /// If a target is within the field of view. This does not consider vertical field of view.
        /// </summary>
        /// <param name="position">The position to check field of view from.</param>
        /// <param name="forward">The forward direction to start the field of view check from.</param>
        /// <param name="target">The target position to check if it is within the field of view.</param>
        /// <param name="fov">The field of view in degrees.</param>
        /// <returns>If a target is within the field of view.</returns>
        public static bool InView(this Vector3 position, Vector2 forward, [NotNull] GameObject target, float fov) => position.InView(forward, target.transform.position, fov);
        
        /// <summary>
        /// If a target is within the field of view. This does not consider vertical field of view.
        /// </summary>
        /// <param name="position">The position to check field of view from.</param>
        /// <param name="forward">The forward direction to start the field of view check from.</param>
        /// <param name="target">The target position to check if it is within the field of view.</param>
        /// <param name="fov">The field of view in degrees.</param>
        /// <returns>If a target is within the field of view.</returns>
        public static bool InView(this Vector3 position, Vector3 forward, Vector2 target, float fov) => position.Flatten().InView(forward, target, fov);
        
        /// <summary>
        /// If a target is within the field of view. This does not consider vertical field of view.
        /// </summary>
        /// <param name="position">The position to check field of view from.</param>
        /// <param name="forward">The forward direction to start the field of view check from.</param>
        /// <param name="target">The target position to check if it is within the field of view.</param>
        /// <param name="fov">The field of view in degrees.</param>
        /// <returns>If a target is within the field of view.</returns>
        public static bool InView(this Vector3 position, Vector3 forward, Vector3 target, float fov) => position.Flatten().InView(forward, target, fov);
        
        /// <summary>
        /// If a target is within the field of view. This does not consider vertical field of view.
        /// </summary>
        /// <param name="position">The position to check field of view from.</param>
        /// <param name="forward">The forward direction to start the field of view check from.</param>
        /// <param name="target">The target position to check if it is within the field of view.</param>
        /// <param name="fov">The field of view in degrees.</param>
        /// <returns>If a target is within the field of view.</returns>
        public static bool InView(this Vector3 position, Vector3 forward, [NotNull] Transform target, float fov) => position.InView(forward, target.position, fov);
        
        /// <summary>
        /// If a target is within the field of view. This does not consider vertical field of view.
        /// </summary>
        /// <param name="position">The position to check field of view from.</param>
        /// <param name="forward">The forward direction to start the field of view check from.</param>
        /// <param name="target">The target position to check if it is within the field of view.</param>
        /// <param name="fov">The field of view in degrees.</param>
        /// <returns>If a target is within the field of view.</returns>
        public static bool InView(this Vector3 position, Vector3 forward, [NotNull] Component target, float fov) => position.InView(forward, target.transform.position, fov);
        
        /// <summary>
        /// If a target is within the field of view. This does not consider vertical field of view.
        /// </summary>
        /// <param name="position">The position to check field of view from.</param>
        /// <param name="forward">The forward direction to start the field of view check from.</param>
        /// <param name="target">The target position to check if it is within the field of view.</param>
        /// <param name="fov">The field of view in degrees.</param>
        /// <returns>If a target is within the field of view.</returns>
        public static bool InView(this Vector3 position, Vector3 forward, [NotNull] GameObject target, float fov) => position.InView(forward, target.transform.position, fov);
        
        /// <summary>
        /// If a target is within the field of view. This does not consider vertical field of view.
        /// </summary>
        /// <param name="position">The position to check field of view from relative to its forward.</param>
        /// <param name="target">The target position to check if it is within the field of view.</param>
        /// <param name="fov">The field of view in degrees.</param>
        /// <returns>If a target is within the field of view.</returns>
        public static bool InView([NotNull] this Transform position, Vector2 target, float fov) => position.position.InView(position.forward, target, fov);
        
        /// <summary>
        /// If a target is within the field of view. This does not consider vertical field of view.
        /// </summary>
        /// <param name="position">The position to check field of view from relative to its forward.</param>
        /// <param name="target">The target position to check if it is within the field of view.</param>
        /// <param name="fov">The field of view in degrees.</param>
        /// <returns>If a target is within the field of view.</returns>
        public static bool InView([NotNull] this Transform position, Vector3 target, float fov) => position.position.InView(position.forward, target, fov);
        
        /// <summary>
        /// If a target is within the field of view. This does not consider vertical field of view.
        /// </summary>
        /// <param name="position">The position to check field of view from relative to its forward.</param>
        /// <param name="target">The target position to check if it is within the field of view.</param>
        /// <param name="fov">The field of view in degrees.</param>
        /// <returns>If a target is within the field of view.</returns>
        public static bool InView([NotNull] this Transform position, [NotNull] Transform target, float fov) => position.position.InView(position.forward, target.position, fov);
        
        /// <summary>
        /// If a target is within the field of view. This does not consider vertical field of view.
        /// </summary>
        /// <param name="position">The position to check field of view from relative to its forward.</param>
        /// <param name="target">The target position to check if it is within the field of view.</param>
        /// <param name="fov">The field of view in degrees.</param>
        /// <returns>If a target is within the field of view.</returns>
        public static bool InView([NotNull] this Transform position, [NotNull] Component target, float fov) => position.position.InView(position.forward, target.transform.position, fov);
        
        /// <summary>
        /// If a target is within the field of view. This does not consider vertical field of view.
        /// </summary>
        /// <param name="position">The position to check field of view from relative to its forward.</param>
        /// <param name="target">The target position to check if it is within the field of view.</param>
        /// <param name="fov">The field of view in degrees.</param>
        /// <returns>If a target is within the field of view.</returns>
        public static bool InView([NotNull] this Transform position, [NotNull] GameObject target, float fov) => position.position.InView(position.forward, target.transform.position, fov);
        
        /// <summary>
        /// If a target is within the field of view. This does not consider vertical field of view.
        /// </summary>
        /// <param name="position">The position to check field of view from relative to its forward.</param>
        /// <param name="target">The target position to check if it is within the field of view.</param>
        /// <param name="fov">The field of view in degrees.</param>
        /// <returns>If a target is within the field of view.</returns>
        public static bool InView([NotNull] this Component position, Vector2 target, float fov) => position.transform.position.InView(position.transform.forward, target, fov);
        
        /// <summary>
        /// If a target is within the field of view. This does not consider vertical field of view.
        /// </summary>
        /// <param name="position">The position to check field of view from relative to its forward.</param>
        /// <param name="target">The target position to check if it is within the field of view.</param>
        /// <param name="fov">The field of view in degrees.</param>
        /// <returns>If a target is within the field of view.</returns>
        public static bool InView([NotNull] this Component position, Vector3 target, float fov) => position.transform.position.InView(position.transform.forward, target, fov);
        
        /// <summary>
        /// If a target is within the field of view. This does not consider vertical field of view.
        /// </summary>
        /// <param name="position">The position to check field of view from relative to its forward.</param>
        /// <param name="target">The target position to check if it is within the field of view.</param>
        /// <param name="fov">The field of view in degrees.</param>
        /// <returns>If a target is within the field of view.</returns>
        public static bool InView([NotNull] this Component position, [NotNull] Transform target, float fov) => position.transform.position.InView(position.transform.forward, target.position, fov);
        
        /// <summary>
        /// If a target is within the field of view. This does not consider vertical field of view.
        /// </summary>
        /// <param name="position">The position to check field of view from relative to its forward.</param>
        /// <param name="target">The target position to check if it is within the field of view.</param>
        /// <param name="fov">The field of view in degrees.</param>
        /// <returns>If a target is within the field of view.</returns>
        public static bool InView([NotNull] this Component position, [NotNull] Component target, float fov) => position.transform.position.InView(position.transform.forward, target.transform.position, fov);
        
        /// <summary>
        /// If a target is within the field of view. This does not consider vertical field of view.
        /// </summary>
        /// <param name="position">The position to check field of view from relative to its forward.</param>
        /// <param name="target">The target position to check if it is within the field of view.</param>
        /// <param name="fov">The field of view in degrees.</param>
        /// <returns>If a target is within the field of view.</returns>
        public static bool InView([NotNull] this Component position, [NotNull] GameObject target, float fov) => position.transform.position.InView(position.transform.forward, target.transform.position, fov);
        
        /// <summary>
        /// If a target is within the field of view. This does not consider vertical field of view.
        /// </summary>
        /// <param name="position">The position to check field of view from relative to its forward.</param>
        /// <param name="target">The target position to check if it is within the field of view.</param>
        /// <param name="fov">The field of view in degrees.</param>
        /// <returns>If a target is within the field of view.</returns>
        public static bool InView([NotNull] this GameObject position, Vector2 target, float fov) => position.transform.position.InView(position.transform.forward, target, fov);
        
        /// <summary>
        /// If a target is within the field of view. This does not consider vertical field of view.
        /// </summary>
        /// <param name="position">The position to check field of view from relative to its forward.</param>
        /// <param name="target">The target position to check if it is within the field of view.</param>
        /// <param name="fov">The field of view in degrees.</param>
        /// <returns>If a target is within the field of view.</returns>
        public static bool InView([NotNull] this GameObject position, Vector3 target, float fov) => position.transform.position.InView(position.transform.forward, target, fov);
        
        /// <summary>
        /// If a target is within the field of view. This does not consider vertical field of view.
        /// </summary>
        /// <param name="position">The position to check field of view from relative to its forward.</param>
        /// <param name="target">The target position to check if it is within the field of view.</param>
        /// <param name="fov">The field of view in degrees.</param>
        /// <returns>If a target is within the field of view.</returns>
        public static bool InView([NotNull] this GameObject position, [NotNull] Transform target, float fov) => position.transform.position.InView(position.transform.forward, target.position, fov);
        
        /// <summary>
        /// If a target is within the field of view. This does not consider vertical field of view.
        /// </summary>
        /// <param name="position">The position to check field of view from relative to its forward.</param>
        /// <param name="target">The target position to check if it is within the field of view.</param>
        /// <param name="fov">The field of view in degrees.</param>
        /// <returns>If a target is within the field of view.</returns>
        public static bool InView([NotNull] this GameObject position, [NotNull] Component target, float fov) => position.transform.position.InView(position.transform.forward, target.transform.position, fov);
        
        /// <summary>
        /// If a target is within the field of view. This does not consider vertical field of view.
        /// </summary>
        /// <param name="position">The position to check field of view from relative to its forward.</param>
        /// <param name="target">The target position to check if it is within the field of view.</param>
        /// <param name="fov">The field of view in degrees.</param>
        /// <returns>If a target is within the field of view.</returns>
        public static bool InView([NotNull] this GameObject position, [NotNull] GameObject target, float fov) => position.transform.position.InView(position.transform.forward, target.transform.position, fov);
        
        /// <summary>
        /// If there is a direct line of sight from a starting position to an end position.
        /// </summary>
        /// <param name="position">The starting position of the line of sight.</param>
        /// <param name="target">The ending position of the line of sight.</param>
        /// <param name="hit">The hit information from the line of sight check.</param>
        /// <param name="mask">The optional layer mask.</param>
        /// <param name="triggers">How the check should handle hitting triggers.</param>
        /// <returns>If there is a direct line of sight from a starting position to an end position.</returns>
        public static bool HasSight(this Vector2 position, Vector2 target, out RaycastHit hit, int mask = -5, QueryTriggerInteraction triggers = QueryTriggerInteraction.UseGlobal) => new Vector3(position.x, 0, position.y).HasSight(new Vector3(target.x, 0, target.y), out hit, mask, triggers);
        
        /// <summary>
        /// If there is a direct line of sight from a starting position to an end position.
        /// </summary>
        /// <param name="position">The starting position of the line of sight.</param>
        /// <param name="target">The ending position of the line of sight.</param>
        /// <param name="hit">The hit information from the line of sight check.</param>
        /// <param name="mask">The optional layer mask.</param>
        /// <param name="triggers">How the check should handle hitting triggers.</param>
        /// <returns>If there is a direct line of sight from a starting position to an end position.</returns>
        public static bool HasSight(this Vector2 position, Vector3 target, out RaycastHit hit, int mask = -5, QueryTriggerInteraction triggers = QueryTriggerInteraction.UseGlobal) => new Vector3(position.x, target.y, position.y).HasSight(target, out hit, mask, triggers);
        
        /// <summary>
        /// If there is a direct line of sight from a starting position to an end position, or the hit during the line of sight check was the target.
        /// </summary>
        /// <param name="position">The starting position of the line of sight.</param>
        /// <param name="target">The ending position of the line of sight.</param>
        /// <param name="hit">The hit information from the line of sight check.</param>
        /// <param name="mask">The optional layer mask.</param>
        /// <param name="triggers">How the check should handle hitting triggers.</param>
        /// <returns>If there is a direct line of sight from a starting position to an end position, or the hit during the line of sight check was the target.</returns>
        public static bool HasSight(this Vector2 position, [NotNull] Transform target, out RaycastHit hit, int mask = -5, QueryTriggerInteraction triggers = QueryTriggerInteraction.UseGlobal) => position.HasSight(target.position, out hit, mask, triggers) || hit.transform == target;
        
        /// <summary>
        /// If there is a direct line of sight from a starting position to an end position, or the hit during the line of sight check was the target.
        /// </summary>
        /// <param name="position">The starting position of the line of sight.</param>
        /// <param name="target">The ending position of the line of sight.</param>
        /// <param name="hit">The hit information from the line of sight check.</param>
        /// <param name="mask">The optional layer mask.</param>
        /// <param name="triggers">How the check should handle hitting triggers.</param>
        /// <returns>If there is a direct line of sight from a starting position to an end position, or the hit during the line of sight check was the target.</returns>
        public static bool HasSight(this Vector2 position, [NotNull] Component target, out RaycastHit hit, int mask = -5, QueryTriggerInteraction triggers = QueryTriggerInteraction.UseGlobal) => position.HasSight(target.transform, out hit, mask, triggers);
        
        /// <summary>
        /// If there is a direct line of sight from a starting position to an end position, or the hit during the line of sight check was the target.
        /// </summary>
        /// <param name="position">The starting position of the line of sight.</param>
        /// <param name="target">The ending position of the line of sight.</param>
        /// <param name="hit">The hit information from the line of sight check.</param>
        /// <param name="mask">The optional layer mask.</param>
        /// <param name="triggers">How the check should handle hitting triggers.</param>
        /// <returns>If there is a direct line of sight from a starting position to an end position, or the hit during the line of sight check was the target.</returns>
        public static bool HasSight(this Vector2 position, [NotNull] GameObject target, out RaycastHit hit, int mask = -5, QueryTriggerInteraction triggers = QueryTriggerInteraction.UseGlobal) => position.HasSight(target.transform, out hit, mask, triggers);
        
        /// <summary>
        /// If there is a direct line of sight from a starting position to an end position.
        /// </summary>
        /// <param name="position">The starting position of the line of sight.</param>
        /// <param name="target">The ending position of the line of sight.</param>
        /// <param name="hit">The hit information from the line of sight check.</param>
        /// <param name="mask">The optional layer mask.</param>
        /// <param name="triggers">How the check should handle hitting triggers.</param>
        /// <returns>If there is a direct line of sight from a starting position to an end position.</returns>
        public static bool HasSight(this Vector3 position, Vector2 target, out RaycastHit hit, int mask = -5, QueryTriggerInteraction triggers = QueryTriggerInteraction.UseGlobal) => position.HasSight(new Vector3(target.x, position.y, target.y), out hit, mask, triggers);
        
        /// <summary>
        /// If there is a direct line of sight from a starting position to an end position.
        /// </summary>
        /// <param name="position">The starting position of the line of sight.</param>
        /// <param name="target">The ending position of the line of sight.</param>
        /// <param name="hit">The hit information from the line of sight check.</param>
        /// <param name="mask">The optional layer mask.</param>
        /// <param name="triggers">How the check should handle hitting triggers.</param>
        /// <returns>If there is a direct line of sight from a starting position to an end position.</returns>
        public static bool HasSight(this Vector3 position, Vector3 target, out RaycastHit hit, int mask = -5, QueryTriggerInteraction triggers = QueryTriggerInteraction.UseGlobal) => !Physics.Linecast(position, target, out hit, mask, triggers);
        
        /// <summary>
        /// If there is a direct line of sight from a starting position to an end position, or the hit during the line of sight check was the target.
        /// </summary>
        /// <param name="position">The starting position of the line of sight.</param>
        /// <param name="target">The ending position of the line of sight.</param>
        /// <param name="hit">The hit information from the line of sight check.</param>
        /// <param name="mask">The optional layer mask.</param>
        /// <param name="triggers">How the check should handle hitting triggers.</param>
        /// <returns>If there is a direct line of sight from a starting position to an end position, or the hit during the line of sight check was the target.</returns>
        public static bool HasSight(this Vector3 position, [NotNull] Transform target, out RaycastHit hit, int mask = -5, QueryTriggerInteraction triggers = QueryTriggerInteraction.UseGlobal) => position.HasSight(target.position, out hit, mask, triggers) || hit.transform == target;
        
        /// <summary>
        /// If there is a direct line of sight from a starting position to an end position, or the hit during the line of sight check was the target.
        /// </summary>
        /// <param name="position">The starting position of the line of sight.</param>
        /// <param name="target">The ending position of the line of sight.</param>
        /// <param name="hit">The hit information from the line of sight check.</param>
        /// <param name="mask">The optional layer mask.</param>
        /// <param name="triggers">How the check should handle hitting triggers.</param>
        /// <returns>If there is a direct line of sight from a starting position to an end position, or the hit during the line of sight check was the target.</returns>
        public static bool HasSight(this Vector3 position, [NotNull] Component target, out RaycastHit hit, int mask = -5, QueryTriggerInteraction triggers = QueryTriggerInteraction.UseGlobal) => position.HasSight(target.transform, out hit, mask, triggers);
        
        /// <summary>
        /// If there is a direct line of sight from a starting position to an end position, or the hit during the line of sight check was the target.
        /// </summary>
        /// <param name="position">The starting position of the line of sight.</param>
        /// <param name="target">The ending position of the line of sight.</param>
        /// <param name="hit">The hit information from the line of sight check.</param>
        /// <param name="mask">The optional layer mask.</param>
        /// <param name="triggers">How the check should handle hitting triggers.</param>
        /// <returns>If there is a direct line of sight from a starting position to an end position, or the hit during the line of sight check was the target.</returns>
        public static bool HasSight(this Vector3 position, [NotNull] GameObject target, out RaycastHit hit, int mask = -5, QueryTriggerInteraction triggers = QueryTriggerInteraction.UseGlobal) => position.HasSight(target.transform, out hit, mask, triggers);
        
        /// <summary>
        /// If there is a direct line of sight from a starting position to an end position.
        /// </summary>
        /// <param name="position">The starting position of the line of sight.</param>
        /// <param name="target">The ending position of the line of sight.</param>
        /// <param name="hit">The hit information from the line of sight check.</param>
        /// <param name="mask">The optional layer mask.</param>
        /// <param name="triggers">How the check should handle hitting triggers.</param>
        /// <returns>If there is a direct line of sight from a starting position to an end position.</returns>
        public static bool HasSight([NotNull] this Transform position, Vector2 target, out RaycastHit hit, int mask = -5, QueryTriggerInteraction triggers = QueryTriggerInteraction.UseGlobal) => position.position.HasSight(target, out hit, mask, triggers);
        
        /// <summary>
        /// If there is a direct line of sight from a starting position to an end position.
        /// </summary>
        /// <param name="position">The starting position of the line of sight.</param>
        /// <param name="target">The ending position of the line of sight.</param>
        /// <param name="hit">The hit information from the line of sight check.</param>
        /// <param name="mask">The optional layer mask.</param>
        /// <param name="triggers">How the check should handle hitting triggers.</param>
        /// <returns>If there is a direct line of sight from a starting position to an end position.</returns>
        public static bool HasSight([NotNull] this Transform position, Vector3 target, out RaycastHit hit, int mask = -5, QueryTriggerInteraction triggers = QueryTriggerInteraction.UseGlobal) => position.position.HasSight(target, out hit, mask, triggers);
        
        /// <summary>
        /// If there is a direct line of sight from a starting position to an end position, or the hit during the line of sight check was the target.
        /// </summary>
        /// <param name="position">The starting position of the line of sight.</param>
        /// <param name="target">The ending position of the line of sight.</param>
        /// <param name="hit">The hit information from the line of sight check.</param>
        /// <param name="mask">The optional layer mask.</param>
        /// <param name="triggers">How the check should handle hitting triggers.</param>
        /// <returns>If there is a direct line of sight from a starting position to an end position, or the hit during the line of sight check was the target.</returns>
        public static bool HasSight([NotNull] this Transform position, [NotNull] Transform target, out RaycastHit hit, int mask = -5, QueryTriggerInteraction triggers = QueryTriggerInteraction.UseGlobal) => position.position.HasSight(target, out hit, mask, triggers);
        
        /// <summary>
        /// If there is a direct line of sight from a starting position to an end position, or the hit during the line of sight check was the target.
        /// </summary>
        /// <param name="position">The starting position of the line of sight.</param>
        /// <param name="target">The ending position of the line of sight.</param>
        /// <param name="hit">The hit information from the line of sight check.</param>
        /// <param name="mask">The optional layer mask.</param>
        /// <param name="triggers">How the check should handle hitting triggers.</param>
        /// <returns>If there is a direct line of sight from a starting position to an end position, or the hit during the line of sight check was the target.</returns>
        public static bool HasSight([NotNull] this Transform position, [NotNull] Component target, out RaycastHit hit, int mask = -5, QueryTriggerInteraction triggers = QueryTriggerInteraction.UseGlobal) => position.position.HasSight(target.transform, out hit, mask, triggers);
        
        /// <summary>
        /// If there is a direct line of sight from a starting position to an end position, or the hit during the line of sight check was the target.
        /// </summary>
        /// <param name="position">The starting position of the line of sight.</param>
        /// <param name="target">The ending position of the line of sight.</param>
        /// <param name="hit">The hit information from the line of sight check.</param>
        /// <param name="mask">The optional layer mask.</param>
        /// <param name="triggers">How the check should handle hitting triggers.</param>
        /// <returns>If there is a direct line of sight from a starting position to an end position, or the hit during the line of sight check was the target.</returns>
        public static bool HasSight([NotNull] this Transform position, [NotNull] GameObject target, out RaycastHit hit, int mask = -5, QueryTriggerInteraction triggers = QueryTriggerInteraction.UseGlobal) => position.position.HasSight(target.transform, out hit, mask, triggers);
        
        /// <summary>
        /// If there is a direct line of sight from a starting position to an end position.
        /// </summary>
        /// <param name="position">The starting position of the line of sight.</param>
        /// <param name="target">The ending position of the line of sight.</param>
        /// <param name="hit">The hit information from the line of sight check.</param>
        /// <param name="mask">The optional layer mask.</param>
        /// <param name="triggers">How the check should handle hitting triggers.</param>
        /// <returns>If there is a direct line of sight from a starting position to an end position.</returns>
        public static bool HasSight([NotNull] this Component position, Vector2 target, out RaycastHit hit, int mask = -5, QueryTriggerInteraction triggers = QueryTriggerInteraction.UseGlobal) => position.transform.position.HasSight(target, out hit, mask, triggers);
        
        /// <summary>
        /// If there is a direct line of sight from a starting position to an end position.
        /// </summary>
        /// <param name="position">The starting position of the line of sight.</param>
        /// <param name="target">The ending position of the line of sight.</param>
        /// <param name="hit">The hit information from the line of sight check.</param>
        /// <param name="mask">The optional layer mask.</param>
        /// <param name="triggers">How the check should handle hitting triggers.</param>
        /// <returns>If there is a direct line of sight from a starting position to an end position.</returns>
        public static bool HasSight([NotNull] this Component position, Vector3 target, out RaycastHit hit, int mask = -5, QueryTriggerInteraction triggers = QueryTriggerInteraction.UseGlobal) => position.transform.position.HasSight(target, out hit, mask, triggers);
        
        /// <summary>
        /// If there is a direct line of sight from a starting position to an end position, or the hit during the line of sight check was the target.
        /// </summary>
        /// <param name="position">The starting position of the line of sight.</param>
        /// <param name="target">The ending position of the line of sight.</param>
        /// <param name="hit">The hit information from the line of sight check.</param>
        /// <param name="mask">The optional layer mask.</param>
        /// <param name="triggers">How the check should handle hitting triggers.</param>
        /// <returns>If there is a direct line of sight from a starting position to an end position, or the hit during the line of sight check was the target.</returns>
        public static bool HasSight([NotNull] this Component position, [NotNull] Transform target, out RaycastHit hit, int mask = -5, QueryTriggerInteraction triggers = QueryTriggerInteraction.UseGlobal) => position.transform.position.HasSight(target, out hit, mask, triggers);
        
        /// <summary>
        /// If there is a direct line of sight from a starting position to an end position, or the hit during the line of sight check was the target.
        /// </summary>
        /// <param name="position">The starting position of the line of sight.</param>
        /// <param name="target">The ending position of the line of sight.</param>
        /// <param name="hit">The hit information from the line of sight check.</param>
        /// <param name="mask">The optional layer mask.</param>
        /// <param name="triggers">How the check should handle hitting triggers.</param>
        /// <returns>If there is a direct line of sight from a starting position to an end position, or the hit during the line of sight check was the target.</returns>
        public static bool HasSight([NotNull] this Component position, [NotNull] Component target, out RaycastHit hit, int mask = -5, QueryTriggerInteraction triggers = QueryTriggerInteraction.UseGlobal) => position.transform.position.HasSight(target.transform, out hit, mask, triggers);
        
        /// <summary>
        /// If there is a direct line of sight from a starting position to an end position, or the hit during the line of sight check was the target.
        /// </summary>
        /// <param name="position">The starting position of the line of sight.</param>
        /// <param name="target">The ending position of the line of sight.</param>
        /// <param name="hit">The hit information from the line of sight check.</param>
        /// <param name="mask">The optional layer mask.</param>
        /// <param name="triggers">How the check should handle hitting triggers.</param>
        /// <returns>If there is a direct line of sight from a starting position to an end position, or the hit during the line of sight check was the target.</returns>
        public static bool HasSight([NotNull] this Component position, [NotNull] GameObject target, out RaycastHit hit, int mask = -5, QueryTriggerInteraction triggers = QueryTriggerInteraction.UseGlobal) => position.transform.position.HasSight(target.transform, out hit, mask, triggers);
        
        /// <summary>
        /// If there is a direct line of sight from a starting position to an end position.
        /// </summary>
        /// <param name="position">The starting position of the line of sight.</param>
        /// <param name="target">The ending position of the line of sight.</param>
        /// <param name="hit">The hit information from the line of sight check.</param>
        /// <param name="mask">The optional layer mask.</param>
        /// <param name="triggers">How the check should handle hitting triggers.</param>
        /// <returns>If there is a direct line of sight from a starting position to an end position.</returns>
        public static bool HasSight([NotNull] this GameObject position, Vector2 target, out RaycastHit hit, int mask = -5, QueryTriggerInteraction triggers = QueryTriggerInteraction.UseGlobal) => position.transform.position.HasSight(target, out hit, mask, triggers);
        
        /// <summary>
        /// If there is a direct line of sight from a starting position to an end position.
        /// </summary>
        /// <param name="position">The starting position of the line of sight.</param>
        /// <param name="target">The ending position of the line of sight.</param>
        /// <param name="hit">The hit information from the line of sight check.</param>
        /// <param name="mask">The optional layer mask.</param>
        /// <param name="triggers">How the check should handle hitting triggers.</param>
        /// <returns>If there is a direct line of sight from a starting position to an end position.</returns>
        public static bool HasSight([NotNull] this GameObject position, Vector3 target, out RaycastHit hit, int mask = -5, QueryTriggerInteraction triggers = QueryTriggerInteraction.UseGlobal) => position.transform.position.HasSight(target, out hit, mask, triggers);
        
        /// <summary>
        /// If there is a direct line of sight from a starting position to an end position, or the hit during the line of sight check was the target.
        /// </summary>
        /// <param name="position">The starting position of the line of sight.</param>
        /// <param name="target">The ending position of the line of sight.</param>
        /// <param name="hit">The hit information from the line of sight check.</param>
        /// <param name="mask">The optional layer mask.</param>
        /// <param name="triggers">How the check should handle hitting triggers.</param>
        /// <returns>If there is a direct line of sight from a starting position to an end position, or the hit during the line of sight check was the target.</returns>
        public static bool HasSight([NotNull] this GameObject position, [NotNull] Transform target, out RaycastHit hit, int mask = -5, QueryTriggerInteraction triggers = QueryTriggerInteraction.UseGlobal) => position.transform.position.HasSight(target, out hit, mask, triggers);
        
        /// <summary>
        /// If there is a direct line of sight from a starting position to an end position, or the hit during the line of sight check was the target.
        /// </summary>
        /// <param name="position">The starting position of the line of sight.</param>
        /// <param name="target">The ending position of the line of sight.</param>
        /// <param name="hit">The hit information from the line of sight check.</param>
        /// <param name="mask">The optional layer mask.</param>
        /// <param name="triggers">How the check should handle hitting triggers.</param>
        /// <returns>If there is a direct line of sight from a starting position to an end position, or the hit during the line of sight check was the target.</returns>
        public static bool HasSight([NotNull] this GameObject position, [NotNull] Component target, out RaycastHit hit, int mask = -5, QueryTriggerInteraction triggers = QueryTriggerInteraction.UseGlobal) => position.transform.position.HasSight(target.transform, out hit, mask, triggers);
        
        /// <summary>
        /// If there is a direct line of sight from a starting position to an end position, or the hit during the line of sight check was the target.
        /// </summary>
        /// <param name="position">The starting position of the line of sight.</param>
        /// <param name="target">The ending position of the line of sight.</param>
        /// <param name="hit">The hit information from the line of sight check.</param>
        /// <param name="mask">The optional layer mask.</param>
        /// <param name="triggers">How the check should handle hitting triggers.</param>
        /// <returns>If there is a direct line of sight from a starting position to an end position, or the hit during the line of sight check was the target.</returns>
        public static bool HasSight([NotNull] this GameObject position, [NotNull] GameObject target, out RaycastHit hit, int mask = -5, QueryTriggerInteraction triggers = QueryTriggerInteraction.UseGlobal) => position.transform.position.HasSight(target.transform, out hit, mask, triggers);
        
        /// <summary>
        /// If there is a direct line of sight with a given radius from a starting position to an end position.
        /// </summary>
        /// <param name="position">The starting position of the line of sight.</param>
        /// <param name="target">The ending position of the line of sight.</param>
        /// <param name="hit">The hit information from the line of sight check.</param>
        /// <param name="radius">How wide of a sphere to cast.</param>
        /// <param name="mask">The optional layer mask.</param>
        /// <param name="triggers">How the check should handle hitting triggers.</param>
        /// <returns>If there is a direct line of sight with a given radius from a starting position to an end position.</returns>
        public static bool HasSight(this Vector2 position, Vector2 target, out RaycastHit hit, float radius, int mask = -5, QueryTriggerInteraction triggers = QueryTriggerInteraction.UseGlobal) => new Vector3(position.x, 0, position.y).HasSight(new Vector3(target.x, 0, target.y), out hit, radius, mask, triggers);
        
        /// <summary>
        /// If there is a direct line of sight with a given radius from a starting position to an end position.
        /// </summary>
        /// <param name="position">The starting position of the line of sight.</param>
        /// <param name="target">The ending position of the line of sight.</param>
        /// <param name="hit">The hit information from the line of sight check.</param>
        /// <param name="radius">How wide of a sphere to cast.</param>
        /// <param name="mask">The optional layer mask.</param>
        /// <param name="triggers">How the check should handle hitting triggers.</param>
        /// <returns>If there is a direct line of sight with a given radius from a starting position to an end position.</returns>
        public static bool HasSight(this Vector2 position, Vector3 target, out RaycastHit hit, float radius, int mask = -5, QueryTriggerInteraction triggers = QueryTriggerInteraction.UseGlobal) => new Vector3(position.x, target.y, position.y).HasSight(target, out hit, radius, mask, triggers);
        
        /// <summary>
        /// If there is a direct line of sight with a given radius from a starting position to an end position, or the hit during the line of sight check was the target.
        /// </summary>
        /// <param name="position">The starting position of the line of sight.</param>
        /// <param name="target">The ending position of the line of sight.</param>
        /// <param name="hit">The hit information from the line of sight check.</param>
        /// <param name="radius">How wide of a sphere to cast.</param>
        /// <param name="mask">The optional layer mask.</param>
        /// <param name="triggers">How the check should handle hitting triggers.</param>
        /// <returns>If there is a direct line of sight with a given radius from a starting position to an end position, or the hit during the line of sight check was the target.</returns>
        public static bool HasSight(this Vector2 position, [NotNull] Transform target, out RaycastHit hit, float radius, int mask = -5, QueryTriggerInteraction triggers = QueryTriggerInteraction.UseGlobal) => position.HasSight(target.position, out hit, radius, mask, triggers) || hit.transform == target;
        
        /// <summary>
        /// If there is a direct line of sight with a given radius from a starting position to an end position, or the hit during the line of sight check was the target.
        /// </summary>
        /// <param name="position">The starting position of the line of sight.</param>
        /// <param name="target">The ending position of the line of sight.</param>
        /// <param name="hit">The hit information from the line of sight check.</param>
        /// <param name="radius">How wide of a sphere to cast.</param>
        /// <param name="mask">The optional layer mask.</param>
        /// <param name="triggers">How the check should handle hitting triggers.</param>
        /// <returns>If there is a direct line of sight with a given radius from a starting position to an end position, or the hit during the line of sight check was the target.</returns>
        public static bool HasSight(this Vector2 position, [NotNull] Component target, out RaycastHit hit, float radius, int mask = -5, QueryTriggerInteraction triggers = QueryTriggerInteraction.UseGlobal) => position.HasSight(target.transform, out hit, radius, mask, triggers);
        
        /// <summary>
        /// If there is a direct line of sight with a given radius from a starting position to an end position, or the hit during the line of sight check was the target.
        /// </summary>
        /// <param name="position">The starting position of the line of sight.</param>
        /// <param name="target">The ending position of the line of sight.</param>
        /// <param name="hit">The hit information from the line of sight check.</param>
        /// <param name="radius">How wide of a sphere to cast.</param>
        /// <param name="mask">The optional layer mask.</param>
        /// <param name="triggers">How the check should handle hitting triggers.</param>
        /// <returns>If there is a direct line of sight with a given radius from a starting position to an end position, or the hit during the line of sight check was the target.</returns>
        public static bool HasSight(this Vector2 position, [NotNull] GameObject target, out RaycastHit hit, float radius, int mask = -5, QueryTriggerInteraction triggers = QueryTriggerInteraction.UseGlobal) => position.HasSight(target.transform, out hit, radius, mask, triggers);
        
        /// <summary>
        /// If there is a direct line of sight with a given radius from a starting position to an end position.
        /// </summary>
        /// <param name="position">The starting position of the line of sight.</param>
        /// <param name="target">The ending position of the line of sight.</param>
        /// <param name="hit">The hit information from the line of sight check.</param>
        /// <param name="radius">How wide of a sphere to cast.</param>
        /// <param name="mask">The optional layer mask.</param>
        /// <param name="triggers">How the check should handle hitting triggers.</param>
        /// <returns>If there is a direct line of sight with a given radius from a starting position to an end position.</returns>
        public static bool HasSight(this Vector3 position, Vector2 target, out RaycastHit hit, float radius, int mask = -5, QueryTriggerInteraction triggers = QueryTriggerInteraction.UseGlobal) => position.HasSight(new Vector3(target.x, position.y, target.y), out hit, radius, mask, triggers);
        
        /// <summary>
        /// If there is a direct line of sight with a given radius from a starting position to an end position.
        /// </summary>
        /// <param name="position">The starting position of the line of sight.</param>
        /// <param name="target">The ending position of the line of sight.</param>
        /// <param name="hit">The hit information from the line of sight check.</param>
        /// <param name="radius">How wide of a sphere to cast.</param>
        /// <param name="mask">The optional layer mask.</param>
        /// <param name="triggers">How the check should handle hitting triggers.</param>
        /// <returns>If there is a direct line of sight with a given radius from a starting position to an end position.</returns>
        public static bool HasSight(this Vector3 position, Vector3 target, out RaycastHit hit, float radius, int mask = -5, QueryTriggerInteraction triggers = QueryTriggerInteraction.UseGlobal)
        {
            // If an illegal radius was passed, use the line casting method.
            if (radius <= 0)
            {
                return position.HasSight(target, out hit, mask, triggers);
            }
            
            Vector3 direction = position.Direction3(target);
            return !Physics.SphereCast(position, radius, direction, out hit, direction.magnitude, mask);
        }
        
        /// <summary>
        /// If there is a direct line of sight with a given radius from a starting position to an end position, or the hit during the line of sight check was the target.
        /// </summary>
        /// <param name="position">The starting position of the line of sight.</param>
        /// <param name="target">The ending position of the line of sight.</param>
        /// <param name="hit">The hit information from the line of sight check.</param>
        /// <param name="radius">How wide of a sphere to cast.</param>
        /// <param name="mask">The optional layer mask.</param>
        /// <param name="triggers">How the check should handle hitting triggers.</param>
        /// <returns>If there is a direct line of sight with a given radius from a starting position to an end position, or the hit during the line of sight check was the target.</returns>
        public static bool HasSight(this Vector3 position, [NotNull] Transform target, out RaycastHit hit, float radius, int mask = -5, QueryTriggerInteraction triggers = QueryTriggerInteraction.UseGlobal) => position.HasSight(target.position, out hit, radius, mask, triggers) || hit.transform == target;
        
        /// <summary>
        /// If there is a direct line of sight with a given radius from a starting position to an end position, or the hit during the line of sight check was the target.
        /// </summary>
        /// <param name="position">The starting position of the line of sight.</param>
        /// <param name="target">The ending position of the line of sight.</param>
        /// <param name="hit">The hit information from the line of sight check.</param>
        /// <param name="radius">How wide of a sphere to cast.</param>
        /// <param name="mask">The optional layer mask.</param>
        /// <param name="triggers">How the check should handle hitting triggers.</param>
        /// <returns>If there is a direct line of sight with a given radius from a starting position to an end position, or the hit during the line of sight check was the target.</returns>
        public static bool HasSight(this Vector3 position, [NotNull] Component target, out RaycastHit hit, float radius, int mask = -5, QueryTriggerInteraction triggers = QueryTriggerInteraction.UseGlobal) => position.HasSight(target.transform, out hit, radius, mask, triggers);
        
        /// <summary>
        /// If there is a direct line of sight with a given radius from a starting position to an end position, or the hit during the line of sight check was the target.
        /// </summary>
        /// <param name="position">The starting position of the line of sight.</param>
        /// <param name="target">The ending position of the line of sight.</param>
        /// <param name="hit">The hit information from the line of sight check.</param>
        /// <param name="radius">How wide of a sphere to cast.</param>
        /// <param name="mask">The optional layer mask.</param>
        /// <param name="triggers">How the check should handle hitting triggers.</param>
        /// <returns>If there is a direct line of sight with a given radius from a starting position to an end position, or the hit during the line of sight check was the target.</returns>
        public static bool HasSight(this Vector3 position, [NotNull] GameObject target, out RaycastHit hit, float radius, int mask = -5, QueryTriggerInteraction triggers = QueryTriggerInteraction.UseGlobal) => position.HasSight(target.transform, out hit, radius, mask, triggers);
        
        /// <summary>
        /// If there is a direct line of sight with a given radius from a starting position to an end position.
        /// </summary>
        /// <param name="position">The starting position of the line of sight.</param>
        /// <param name="target">The ending position of the line of sight.</param>
        /// <param name="hit">The hit information from the line of sight check.</param>
        /// <param name="radius">How wide of a sphere to cast.</param>
        /// <param name="mask">The optional layer mask.</param>
        /// <param name="triggers">How the check should handle hitting triggers.</param>
        /// <returns>If there is a direct line of sight with a given radius from a starting position to an end position.</returns>
        public static bool HasSight([NotNull] this Transform position, Vector2 target, out RaycastHit hit, float radius, int mask = -5, QueryTriggerInteraction triggers = QueryTriggerInteraction.UseGlobal) => position.position.HasSight(target, out hit, radius, mask, triggers);
        
        /// <summary>
        /// If there is a direct line of sight with a given radius from a starting position to an end position.
        /// </summary>
        /// <param name="position">The starting position of the line of sight.</param>
        /// <param name="target">The ending position of the line of sight.</param>
        /// <param name="hit">The hit information from the line of sight check.</param>
        /// <param name="radius">How wide of a sphere to cast.</param>
        /// <param name="mask">The optional layer mask.</param>
        /// <param name="triggers">How the check should handle hitting triggers.</param>
        /// <returns>If there is a direct line of sight with a given radius from a starting position to an end position.</returns>
        public static bool HasSight([NotNull] this Transform position, Vector3 target, out RaycastHit hit, float radius, int mask = -5, QueryTriggerInteraction triggers = QueryTriggerInteraction.UseGlobal) => position.position.HasSight(target, out hit, radius, mask, triggers);
        
        /// <summary>
        /// If there is a direct line of sight with a given radius from a starting position to an end position, or the hit during the line of sight check was the target.
        /// </summary>
        /// <param name="position">The starting position of the line of sight.</param>
        /// <param name="target">The ending position of the line of sight.</param>
        /// <param name="hit">The hit information from the line of sight check.</param>
        /// <param name="radius">How wide of a sphere to cast.</param>
        /// <param name="mask">The optional layer mask.</param>
        /// <param name="triggers">How the check should handle hitting triggers.</param>
        /// <returns>If there is a direct line of sight with a given radius from a starting position to an end position, or the hit during the line of sight check was the target.</returns>
        public static bool HasSight([NotNull] this Transform position, [NotNull] Transform target, out RaycastHit hit, float radius, int mask = -5, QueryTriggerInteraction triggers = QueryTriggerInteraction.UseGlobal) => position.position.HasSight(target, out hit, radius, mask, triggers);
        
        /// <summary>
        /// If there is a direct line of sight with a given radius from a starting position to an end position, or the hit during the line of sight check was the target.
        /// </summary>
        /// <param name="position">The starting position of the line of sight.</param>
        /// <param name="target">The ending position of the line of sight.</param>
        /// <param name="hit">The hit information from the line of sight check.</param>
        /// <param name="radius">How wide of a sphere to cast.</param>
        /// <param name="mask">The optional layer mask.</param>
        /// <param name="triggers">How the check should handle hitting triggers.</param>
        /// <returns>If there is a direct line of sight with a given radius from a starting position to an end position, or the hit during the line of sight check was the target.</returns>
        public static bool HasSight([NotNull] this Transform position, [NotNull] Component target, out RaycastHit hit, float radius, int mask = -5, QueryTriggerInteraction triggers = QueryTriggerInteraction.UseGlobal) => position.position.HasSight(target.transform, out hit, radius, mask, triggers);
        
        /// <summary>
        /// If there is a direct line of sight with a given radius from a starting position to an end position, or the hit during the line of sight check was the target.
        /// </summary>
        /// <param name="position">The starting position of the line of sight.</param>
        /// <param name="target">The ending position of the line of sight.</param>
        /// <param name="hit">The hit information from the line of sight check.</param>
        /// <param name="radius">How wide of a sphere to cast.</param>
        /// <param name="mask">The optional layer mask.</param>
        /// <param name="triggers">How the check should handle hitting triggers.</param>
        /// <returns>If there is a direct line of sight with a given radius from a starting position to an end position, or the hit during the line of sight check was the target.</returns>
        public static bool HasSight([NotNull] this Transform position, [NotNull] GameObject target, out RaycastHit hit, float radius, int mask = -5, QueryTriggerInteraction triggers = QueryTriggerInteraction.UseGlobal) => position.position.HasSight(target.transform, out hit, radius, mask, triggers);
        
        /// <summary>
        /// If there is a direct line of sight with a given radius from a starting position to an end position.
        /// </summary>
        /// <param name="position">The starting position of the line of sight.</param>
        /// <param name="target">The ending position of the line of sight.</param>
        /// <param name="hit">The hit information from the line of sight check.</param>
        /// <param name="radius">How wide of a sphere to cast.</param>
        /// <param name="mask">The optional layer mask.</param>
        /// <param name="triggers">How the check should handle hitting triggers.</param>
        /// <returns>If there is a direct line of sight with a given radius from a starting position to an end position.</returns>
        public static bool HasSight([NotNull] this Component position, Vector2 target, out RaycastHit hit, float radius, int mask = -5, QueryTriggerInteraction triggers = QueryTriggerInteraction.UseGlobal) => position.transform.position.HasSight(target, out hit, radius, mask, triggers);
        
        /// <summary>
        /// If there is a direct line of sight with a given radius from a starting position to an end position.
        /// </summary>
        /// <param name="position">The starting position of the line of sight.</param>
        /// <param name="target">The ending position of the line of sight.</param>
        /// <param name="hit">The hit information from the line of sight check.</param>
        /// <param name="radius">How wide of a sphere to cast.</param>
        /// <param name="mask">The optional layer mask.</param>
        /// <param name="triggers">How the check should handle hitting triggers.</param>
        /// <returns>If there is a direct line of sight with a given radius from a starting position to an end position.</returns>
        public static bool HasSight([NotNull] this Component position, Vector3 target, out RaycastHit hit, float radius, int mask = -5, QueryTriggerInteraction triggers = QueryTriggerInteraction.UseGlobal) => position.transform.position.HasSight(target, out hit, radius, mask, triggers);
        
        /// <summary>
        /// If there is a direct line of sight with a given radius from a starting position to an end position, or the hit during the line of sight check was the target.
        /// </summary>
        /// <param name="position">The starting position of the line of sight.</param>
        /// <param name="target">The ending position of the line of sight.</param>
        /// <param name="hit">The hit information from the line of sight check.</param>
        /// <param name="radius">How wide of a sphere to cast.</param>
        /// <param name="mask">The optional layer mask.</param>
        /// <param name="triggers">How the check should handle hitting triggers.</param>
        /// <returns>If there is a direct line of sight with a given radius from a starting position to an end position, or the hit during the line of sight check was the target.</returns>
        public static bool HasSight([NotNull] this Component position, [NotNull] Transform target, out RaycastHit hit, float radius, int mask = -5, QueryTriggerInteraction triggers = QueryTriggerInteraction.UseGlobal) => position.transform.position.HasSight(target, out hit, radius, mask, triggers);
        
        /// <summary>
        /// If there is a direct line of sight with a given radius from a starting position to an end position, or the hit during the line of sight check was the target.
        /// </summary>
        /// <param name="position">The starting position of the line of sight.</param>
        /// <param name="target">The ending position of the line of sight.</param>
        /// <param name="hit">The hit information from the line of sight check.</param>
        /// <param name="radius">How wide of a sphere to cast.</param>
        /// <param name="mask">The optional layer mask.</param>
        /// <param name="triggers">How the check should handle hitting triggers.</param>
        /// <returns>If there is a direct line of sight with a given radius from a starting position to an end position, or the hit during the line of sight check was the target.</returns>
        public static bool HasSight([NotNull] this Component position, [NotNull] Component target, out RaycastHit hit, float radius, int mask = -5, QueryTriggerInteraction triggers = QueryTriggerInteraction.UseGlobal) => position.transform.position.HasSight(target.transform, out hit, radius, mask, triggers);
        
        /// <summary>
        /// If there is a direct line of sight with a given radius from a starting position to an end position, or the hit during the line of sight check was the target.
        /// </summary>
        /// <param name="position">The starting position of the line of sight.</param>
        /// <param name="target">The ending position of the line of sight.</param>
        /// <param name="hit">The hit information from the line of sight check.</param>
        /// <param name="radius">How wide of a sphere to cast.</param>
        /// <param name="mask">The optional layer mask.</param>
        /// <param name="triggers">How the check should handle hitting triggers.</param>
        /// <returns>If there is a direct line of sight with a given radius from a starting position to an end position, or the hit during the line of sight check was the target.</returns>
        public static bool HasSight([NotNull] this Component position, [NotNull] GameObject target, out RaycastHit hit, float radius, int mask = -5, QueryTriggerInteraction triggers = QueryTriggerInteraction.UseGlobal) => position.transform.position.HasSight(target.transform, out hit, radius, mask, triggers);
        
        /// <summary>
        /// If there is a direct line of sight with a given radius from a starting position to an end position.
        /// </summary>
        /// <param name="position">The starting position of the line of sight.</param>
        /// <param name="target">The ending position of the line of sight.</param>
        /// <param name="hit">The hit information from the line of sight check.</param>
        /// <param name="radius">How wide of a sphere to cast.</param>
        /// <param name="mask">The optional layer mask.</param>
        /// <param name="triggers">How the check should handle hitting triggers.</param>
        /// <returns>If there is a direct line of sight with a given radius from a starting position to an end position.</returns>
        public static bool HasSight([NotNull] this GameObject position, Vector2 target, out RaycastHit hit, float radius, int mask = -5, QueryTriggerInteraction triggers = QueryTriggerInteraction.UseGlobal) => position.transform.position.HasSight(target, out hit, radius, mask, triggers);
        
        /// <summary>
        /// If there is a direct line of sight with a given radius from a starting position to an end position.
        /// </summary>
        /// <param name="position">The starting position of the line of sight.</param>
        /// <param name="target">The ending position of the line of sight.</param>
        /// <param name="hit">The hit information from the line of sight check.</param>
        /// <param name="radius">How wide of a sphere to cast.</param>
        /// <param name="mask">The optional layer mask.</param>
        /// <param name="triggers">How the check should handle hitting triggers.</param>
        /// <returns>If there is a direct line of sight with a given radius from a starting position to an end position.</returns>
        public static bool HasSight([NotNull] this GameObject position, Vector3 target, out RaycastHit hit, float radius, int mask = -5, QueryTriggerInteraction triggers = QueryTriggerInteraction.UseGlobal) => position.transform.position.HasSight(target, out hit, radius, mask, triggers);
        
        /// <summary>
        /// If there is a direct line of sight with a given radius from a starting position to an end position, or the hit during the line of sight check was the target.
        /// </summary>
        /// <param name="position">The starting position of the line of sight.</param>
        /// <param name="target">The ending position of the line of sight.</param>
        /// <param name="hit">The hit information from the line of sight check.</param>
        /// <param name="radius">How wide of a sphere to cast.</param>
        /// <param name="mask">The optional layer mask.</param>
        /// <param name="triggers">How the check should handle hitting triggers.</param>
        /// <returns>If there is a direct line of sight with a given radius from a starting position to an end position, or the hit during the line of sight check was the target.</returns>
        public static bool HasSight([NotNull] this GameObject position, [NotNull] Transform target, out RaycastHit hit, float radius, int mask = -5, QueryTriggerInteraction triggers = QueryTriggerInteraction.UseGlobal) => position.transform.position.HasSight(target, out hit, radius, mask, triggers);
        
        /// <summary>
        /// If there is a direct line of sight with a given radius from a starting position to an end position, or the hit during the line of sight check was the target.
        /// </summary>
        /// <param name="position">The starting position of the line of sight.</param>
        /// <param name="target">The ending position of the line of sight.</param>
        /// <param name="hit">The hit information from the line of sight check.</param>
        /// <param name="radius">How wide of a sphere to cast.</param>
        /// <param name="mask">The optional layer mask.</param>
        /// <param name="triggers">How the check should handle hitting triggers.</param>
        /// <returns>If there is a direct line of sight with a given radius from a starting position to an end position, or the hit during the line of sight check was the target.</returns>
        public static bool HasSight([NotNull] this GameObject position, [NotNull] Component target, out RaycastHit hit, float radius, int mask = -5, QueryTriggerInteraction triggers = QueryTriggerInteraction.UseGlobal) => position.transform.position.HasSight(target.transform, out hit, radius, mask, triggers);
        
        /// <summary>
        /// If there is a direct line of sight with a given radius from a starting position to an end position, or the hit during the line of sight check was the target.
        /// </summary>
        /// <param name="position">The starting position of the line of sight.</param>
        /// <param name="target">The ending position of the line of sight.</param>
        /// <param name="hit">The hit information from the line of sight check.</param>
        /// <param name="radius">How wide of a sphere to cast.</param>
        /// <param name="mask">The optional layer mask.</param>
        /// <param name="triggers">How the check should handle hitting triggers.</param>
        /// <returns>If there is a direct line of sight with a given radius from a starting position to an end position, or the hit during the line of sight check was the target.</returns>
        public static bool HasSight([NotNull] this GameObject position, [NotNull] GameObject target, out RaycastHit hit, float radius, int mask = -5, QueryTriggerInteraction triggers = QueryTriggerInteraction.UseGlobal) => position.transform.position.HasSight(target.transform, out hit, radius, mask, triggers);
        
        /// <summary>
        /// Perform a raycast.
        /// </summary>
        /// <param name="position">The starting position of the cast.</param>
        /// <param name="direction">The ending position of the cast.</param>
        /// <param name="hit">The hit information from the cast.</param>
        /// <param name="distance">The distance for the cast.</param>
        /// <param name="mask">The optional layer mask.</param>
        /// <param name="triggers">How the cast should handle hitting triggers.</param>
        /// <returns>If the cast hit a collider or not.</returns>
        public static bool Raycast(this Vector2 position, Vector2 direction, out RaycastHit hit, float distance = float.MaxValue, int mask = -5, QueryTriggerInteraction triggers = QueryTriggerInteraction.UseGlobal) => position.Expand().Raycast(direction.Expand(), out hit, distance, mask, triggers);
        
        /// <summary>
        /// Perform a raycast.
        /// </summary>
        /// <param name="position">The starting position of the cast.</param>
        /// <param name="direction">The ending position of the cast.</param>
        /// <param name="hit">The hit information from the cast.</param>
        /// <param name="distance">The distance for the cast.</param>
        /// <param name="mask">The optional layer mask.</param>
        /// <param name="triggers">How the cast should handle hitting triggers.</param>
        /// <returns>If the cast hit a collider or not.</returns>
        public static bool Raycast(this Vector2 position, Vector3 direction, out RaycastHit hit, float distance = float.MaxValue, int mask = -5, QueryTriggerInteraction triggers = QueryTriggerInteraction.UseGlobal) => position.Expand().Raycast(direction, out hit, distance, mask, triggers);
        
        /// <summary>
        /// Perform a raycast.
        /// </summary>
        /// <param name="position">The starting position of the cast.</param>
        /// <param name="direction">The ending position of the cast.</param>
        /// <param name="hit">The hit information from the cast.</param>
        /// <param name="distance">The distance for the cast.</param>
        /// <param name="mask">The optional layer mask.</param>
        /// <param name="triggers">How the cast should handle hitting triggers.</param>
        /// <returns>If the cast hit a collider or not.</returns>
        public static bool Raycast(this Vector3 position, Vector2 direction, out RaycastHit hit, float distance = float.MaxValue, int mask = -5, QueryTriggerInteraction triggers = QueryTriggerInteraction.UseGlobal) => position.Raycast(direction.Expand(), out hit, distance, mask, triggers);
        
        /// <summary>
        /// Perform a raycast.
        /// </summary>
        /// <param name="position">The starting position of the cast.</param>
        /// <param name="direction">The ending position of the cast.</param>
        /// <param name="hit">The hit information from the cast.</param>
        /// <param name="distance">The distance for the cast.</param>
        /// <param name="mask">The optional layer mask.</param>
        /// <param name="triggers">How the cast should handle hitting triggers.</param>
        /// <returns>If the cast hit a collider or not.</returns>
        public static bool Raycast(this Vector3 position, Vector3 direction, out RaycastHit hit, float distance = float.MaxValue, int mask = -5, QueryTriggerInteraction triggers = QueryTriggerInteraction.UseGlobal) => Physics.Raycast(position, direction, out hit, distance, mask, triggers);
        
        /// <summary>
        /// Perform a raycast.
        /// </summary>
        /// <param name="position">The starting position of the cast.</param>
        /// <param name="direction">The ending position of the cast.</param>
        /// <param name="hit">The hit information from the cast.</param>
        /// <param name="distance">The distance for the cast.</param>
        /// <param name="mask">The optional layer mask.</param>
        /// <param name="triggers">How the cast should handle hitting triggers.</param>
        /// <returns>If the cast hit a collider or not.</returns>
        public static bool Raycast([NotNull] this Transform position, Vector2 direction, out RaycastHit hit, float distance = float.MaxValue, int mask = -5, QueryTriggerInteraction triggers = QueryTriggerInteraction.UseGlobal) => position.position.Raycast(direction, out hit, distance, mask, triggers);
        
        /// <summary>
        /// Perform a raycast.
        /// </summary>
        /// <param name="position">The starting position of the cast.</param>
        /// <param name="direction">The ending position of the cast.</param>
        /// <param name="hit">The hit information from the cast.</param>
        /// <param name="distance">The distance for the cast.</param>
        /// <param name="mask">The optional layer mask.</param>
        /// <param name="triggers">How the cast should handle hitting triggers.</param>
        /// <returns>If the cast hit a collider or not.</returns>
        public static bool Raycast([NotNull] this Transform position, Vector3 direction, out RaycastHit hit, float distance = float.MaxValue, int mask = -5, QueryTriggerInteraction triggers = QueryTriggerInteraction.UseGlobal) => position.position.Raycast(direction, out hit, distance, mask, triggers);
        
        /// <summary>
        /// Perform a raycast in the forward direction.
        /// </summary>
        /// <param name="position">The starting position of the cast which will be cast in its forward direction.</param>
        /// <param name="hit">The hit information from the cast.</param>
        /// <param name="distance">The distance for the cast.</param>
        /// <param name="mask">The optional layer mask.</param>
        /// <param name="triggers">How the cast should handle hitting triggers.</param>
        /// <returns>If the cast hit a collider or not.</returns>
        public static bool Raycast([NotNull] this Transform position, out RaycastHit hit, float distance = float.MaxValue, int mask = -5, QueryTriggerInteraction triggers = QueryTriggerInteraction.UseGlobal) => position.position.Raycast(position.forward, out hit, distance, mask, triggers);
        
        /// <summary>
        /// Perform a raycast.
        /// </summary>
        /// <param name="position">The starting position of the cast.</param>
        /// <param name="direction">The ending position of the cast.</param>
        /// <param name="hit">The hit information from the cast.</param>
        /// <param name="distance">The distance for the cast.</param>
        /// <param name="mask">The optional layer mask.</param>
        /// <param name="triggers">How the cast should handle hitting triggers.</param>
        /// <returns>If the cast hit a collider or not.</returns>
        public static bool Raycast([NotNull] this Component position, Vector2 direction, out RaycastHit hit, float distance = float.MaxValue, int mask = -5, QueryTriggerInteraction triggers = QueryTriggerInteraction.UseGlobal) => position.transform.position.Raycast(direction, out hit, distance, mask, triggers);
        
        /// <summary>
        /// Perform a raycast.
        /// </summary>
        /// <param name="position">The starting position of the cast.</param>
        /// <param name="direction">The ending position of the cast.</param>
        /// <param name="hit">The hit information from the cast.</param>
        /// <param name="distance">The distance for the cast.</param>
        /// <param name="mask">The optional layer mask.</param>
        /// <param name="triggers">How the cast should handle hitting triggers.</param>
        /// <returns>If the cast hit a collider or not.</returns>
        public static bool Raycast([NotNull] this Component position, Vector3 direction, out RaycastHit hit, float distance = float.MaxValue, int mask = -5, QueryTriggerInteraction triggers = QueryTriggerInteraction.UseGlobal) => position.transform.position.Raycast(direction, out hit, distance, mask, triggers);
        
        /// <summary>
        /// Perform a raycast in the forward direction.
        /// </summary>
        /// <param name="position">The starting position of the cast which will be cast in its forward direction.</param>
        /// <param name="hit">The hit information from the cast.</param>
        /// <param name="distance">The distance for the cast.</param>
        /// <param name="mask">The optional layer mask.</param>
        /// <param name="triggers">How the cast should handle hitting triggers.</param>
        /// <returns>If the cast hit a collider or not.</returns>
        public static bool Raycast([NotNull] this Component position, out RaycastHit hit, float distance = float.MaxValue, int mask = -5, QueryTriggerInteraction triggers = QueryTriggerInteraction.UseGlobal)
        {
            Transform t = position.transform;
            return t.position.Raycast(t.forward, out hit, distance, mask, triggers);
        }
        
        /// <summary>
        /// Perform a raycast.
        /// </summary>
        /// <param name="position">The starting position of the cast.</param>
        /// <param name="direction">The ending position of the cast.</param>
        /// <param name="hit">The hit information from the cast.</param>
        /// <param name="distance">The distance for the cast.</param>
        /// <param name="mask">The optional layer mask.</param>
        /// <param name="triggers">How the cast should handle hitting triggers.</param>
        /// <returns>If the cast hit a collider or not.</returns>
        public static bool Raycast([NotNull] this GameObject position, Vector2 direction, out RaycastHit hit, float distance = float.MaxValue, int mask = -5, QueryTriggerInteraction triggers = QueryTriggerInteraction.UseGlobal) => position.transform.position.Raycast(direction, out hit, distance, mask, triggers);
        
        /// <summary>
        /// Perform a raycast.
        /// </summary>
        /// <param name="position">The starting position of the cast.</param>
        /// <param name="direction">The ending position of the cast.</param>
        /// <param name="hit">The hit information from the cast.</param>
        /// <param name="distance">The distance for the cast.</param>
        /// <param name="mask">The optional layer mask.</param>
        /// <param name="triggers">How the cast should handle hitting triggers.</param>
        /// <returns>If the cast hit a collider or not.</returns>
        public static bool Raycast([NotNull] this GameObject position, Vector3 direction, out RaycastHit hit, float distance = float.MaxValue, int mask = -5, QueryTriggerInteraction triggers = QueryTriggerInteraction.UseGlobal) => position.transform.position.Raycast(direction, out hit, distance, mask, triggers);
        
        /// <summary>
        /// Perform a raycast in the forward direction.
        /// </summary>
        /// <param name="position">The starting position of the cast which will be cast in its forward direction.</param>
        /// <param name="hit">The hit information from the cast.</param>
        /// <param name="distance">The distance for the cast.</param>
        /// <param name="mask">The optional layer mask.</param>
        /// <param name="triggers">How the cast should handle hitting triggers.</param>
        /// <returns>If the cast hit a collider or not.</returns>
        public static bool Raycast([NotNull] this GameObject position, out RaycastHit hit, float distance = float.MaxValue, int mask = -5, QueryTriggerInteraction triggers = QueryTriggerInteraction.UseGlobal)
        {
            Transform t = position.transform;
            return t.position.Raycast(t.forward, out hit, distance, mask, triggers);
        }
        
        /// <summary>
        /// Perform a sphere cast.
        /// </summary>
        /// <param name="position">The starting position of the cast.</param>
        /// <param name="direction">The ending position of the cast.</param>
        /// <param name="radius">The radius of the cast.</param>
        /// <param name="hit">The hit information from the cast.</param>
        /// <param name="distance">The distance for the cast.</param>
        /// <param name="mask">The optional layer mask.</param>
        /// <param name="triggers">How the cast should handle hitting triggers.</param>
        /// <returns>If the cast hit a collider or not.</returns>
        public static bool SphereCast(this Vector2 position, Vector2 direction, float radius, out RaycastHit hit, float distance = float.MaxValue, int mask = -5, QueryTriggerInteraction triggers = QueryTriggerInteraction.UseGlobal) => position.Expand().SphereCast(direction.Expand(), radius, out hit, distance, mask, triggers);
        
        /// <summary>
        /// Perform a sphere cast.
        /// </summary>
        /// <param name="position">The starting position of the cast.</param>
        /// <param name="direction">The ending position of the cast.</param>
        /// <param name="radius">The radius of the cast.</param>
        /// <param name="hit">The hit information from the cast.</param>
        /// <param name="distance">The distance for the cast.</param>
        /// <param name="mask">The optional layer mask.</param>
        /// <param name="triggers">How the cast should handle hitting triggers.</param>
        /// <returns>If the cast hit a collider or not.</returns>
        public static bool SphereCast(this Vector2 position, Vector3 direction, float radius, out RaycastHit hit, float distance = float.MaxValue, int mask = -5, QueryTriggerInteraction triggers = QueryTriggerInteraction.UseGlobal) => position.Expand().SphereCast(direction, radius, out hit, distance, mask, triggers);
        
        /// <summary>
        /// Perform a sphere cast.
        /// </summary>
        /// <param name="position">The starting position of the cast.</param>
        /// <param name="direction">The ending position of the cast.</param>
        /// <param name="radius">The radius of the cast.</param>
        /// <param name="hit">The hit information from the cast.</param>
        /// <param name="distance">The distance for the cast.</param>
        /// <param name="mask">The optional layer mask.</param>
        /// <param name="triggers">How the cast should handle hitting triggers.</param>
        /// <returns>If the cast hit a collider or not.</returns>
        public static bool SphereCast(this Vector3 position, Vector2 direction, float radius, out RaycastHit hit, float distance = float.MaxValue, int mask = -5, QueryTriggerInteraction triggers = QueryTriggerInteraction.UseGlobal) => position.SphereCast(direction.Expand(), radius, out hit, distance, mask, triggers);
        
        /// <summary>
        /// Perform a sphere cast.
        /// </summary>
        /// <param name="position">The starting position of the cast.</param>
        /// <param name="direction">The ending position of the cast.</param>
        /// <param name="radius">The radius of the cast.</param>
        /// <param name="hit">The hit information from the cast.</param>
        /// <param name="distance">The distance for the cast.</param>
        /// <param name="mask">The optional layer mask.</param>
        /// <param name="triggers">How the cast should handle hitting triggers.</param>
        /// <returns>If the cast hit a collider or not.</returns>
        public static bool SphereCast(this Vector3 position, Vector3 direction, float radius, out RaycastHit hit, float distance = float.MaxValue, int mask = -5, QueryTriggerInteraction triggers = QueryTriggerInteraction.UseGlobal) => radius > 0 ? Physics.SphereCast(position, radius, direction, out hit, distance, mask, triggers) : position.Raycast(direction, out hit, distance, mask, triggers);
        
        /// <summary>
        /// Perform a sphere cast.
        /// </summary>
        /// <param name="position">The starting position of the cast.</param>
        /// <param name="direction">The ending position of the cast.</param>
        /// <param name="radius">The radius of the cast.</param>
        /// <param name="hit">The hit information from the cast.</param>
        /// <param name="distance">The distance for the cast.</param>
        /// <param name="mask">The optional layer mask.</param>
        /// <param name="triggers">How the cast should handle hitting triggers.</param>
        /// <returns>If the cast hit a collider or not.</returns>
        public static bool SphereCast([NotNull] this Transform position, Vector2 direction, float radius, out RaycastHit hit, float distance = float.MaxValue, int mask = -5, QueryTriggerInteraction triggers = QueryTriggerInteraction.UseGlobal) => position.position.SphereCast(direction, radius, out hit, distance, mask, triggers);
        
        /// <summary>
        /// Perform a sphere cast.
        /// </summary>
        /// <param name="position">The starting position of the cast.</param>
        /// <param name="direction">The ending position of the cast.</param>
        /// <param name="radius">The radius of the cast.</param>
        /// <param name="hit">The hit information from the cast.</param>
        /// <param name="distance">The distance for the cast.</param>
        /// <param name="mask">The optional layer mask.</param>
        /// <param name="triggers">How the cast should handle hitting triggers.</param>
        /// <returns>If the cast hit a collider or not.</returns>
        public static bool SphereCast([NotNull] this Transform position, Vector3 direction, float radius, out RaycastHit hit, float distance = float.MaxValue, int mask = -5, QueryTriggerInteraction triggers = QueryTriggerInteraction.UseGlobal) => position.position.SphereCast(direction, radius, out hit, distance, mask, triggers);
        
        /// <summary>
        /// Perform a SphereCast in the forward direction.
        /// </summary>
        /// <param name="position">The starting position of the cast which will be cast in its forward direction.</param>
        /// <param name="radius">The radius of the cast.</param>
        /// <param name="hit">The hit information from the cast.</param>
        /// <param name="distance">The distance for the cast.</param>
        /// <param name="mask">The optional layer mask.</param>
        /// <param name="triggers">How the cast should handle hitting triggers.</param>
        /// <returns>If the cast hit a collider or not.</returns>
        public static bool SphereCast([NotNull] this Transform position, float radius, out RaycastHit hit, float distance = float.MaxValue, int mask = -5, QueryTriggerInteraction triggers = QueryTriggerInteraction.UseGlobal) => position.position.SphereCast(position.forward, radius, out hit, distance, mask, triggers);
        
        /// <summary>
        /// Perform a sphere cast.
        /// </summary>
        /// <param name="position">The starting position of the cast.</param>
        /// <param name="direction">The ending position of the cast.</param>
        /// <param name="radius">The radius of the cast.</param>
        /// <param name="hit">The hit information from the cast.</param>
        /// <param name="distance">The distance for the cast.</param>
        /// <param name="mask">The optional layer mask.</param>
        /// <param name="triggers">How the cast should handle hitting triggers.</param>
        /// <returns>If the cast hit a collider or not.</returns>
        public static bool SphereCast([NotNull] this Component position, Vector2 direction, float radius, out RaycastHit hit, float distance = float.MaxValue, int mask = -5, QueryTriggerInteraction triggers = QueryTriggerInteraction.UseGlobal) => position.transform.position.SphereCast(direction, radius, out hit, distance, mask, triggers);
        
        /// <summary>
        /// Perform a sphere cast.
        /// </summary>
        /// <param name="position">The starting position of the cast.</param>
        /// <param name="direction">The ending position of the cast.</param>
        /// <param name="radius">The radius of the cast.</param>
        /// <param name="hit">The hit information from the cast.</param>
        /// <param name="distance">The distance for the cast.</param>
        /// <param name="mask">The optional layer mask.</param>
        /// <param name="triggers">How the cast should handle hitting triggers.</param>
        /// <returns>If the cast hit a collider or not.</returns>
        public static bool SphereCast([NotNull] this Component position, Vector3 direction, float radius, out RaycastHit hit, float distance = float.MaxValue, int mask = -5, QueryTriggerInteraction triggers = QueryTriggerInteraction.UseGlobal) => position.transform.position.SphereCast(direction, radius, out hit, distance, mask, triggers);
        
        /// <summary>
        /// Perform a SphereCast in the forward direction.
        /// </summary>
        /// <param name="position">The starting position of the cast which will be cast in its forward direction.</param>
        /// <param name="radius">The radius of the cast.</param>
        /// <param name="hit">The hit information from the cast.</param>
        /// <param name="distance">The distance for the cast.</param>
        /// <param name="mask">The optional layer mask.</param>
        /// <param name="triggers">How the cast should handle hitting triggers.</param>
        /// <returns>If the cast hit a collider or not.</returns>
        public static bool SphereCast([NotNull] this Component position, float radius, out RaycastHit hit, float distance = float.MaxValue, int mask = -5, QueryTriggerInteraction triggers = QueryTriggerInteraction.UseGlobal)
        {
            Transform t = position.transform;
            return t.position.SphereCast(t.forward, radius, out hit, distance, mask, triggers);
        }
        
        /// <summary>
        /// Perform a sphere cast.
        /// </summary>
        /// <param name="position">The starting position of the cast.</param>
        /// <param name="direction">The ending position of the cast.</param>
        /// <param name="radius">The radius of the cast.</param>
        /// <param name="hit">The hit information from the cast.</param>
        /// <param name="distance">The distance for the cast.</param>
        /// <param name="mask">The optional layer mask.</param>
        /// <param name="triggers">How the cast should handle hitting triggers.</param>
        /// <returns>If the cast hit a collider or not.</returns>
        public static bool SphereCast([NotNull] this GameObject position, Vector2 direction, float radius, out RaycastHit hit, float distance = float.MaxValue, int mask = -5, QueryTriggerInteraction triggers = QueryTriggerInteraction.UseGlobal) => position.transform.position.SphereCast(direction, radius, out hit, distance, mask, triggers);
        
        /// <summary>
        /// Perform a sphere cast.
        /// </summary>
        /// <param name="position">The starting position of the cast.</param>
        /// <param name="direction">The ending position of the cast.</param>
        /// <param name="radius">The radius of the cast.</param>
        /// <param name="hit">The hit information from the cast.</param>
        /// <param name="distance">The distance for the cast.</param>
        /// <param name="mask">The optional layer mask.</param>
        /// <param name="triggers">How the cast should handle hitting triggers.</param>
        /// <returns>If the cast hit a collider or not.</returns>
        public static bool SphereCast([NotNull] this GameObject position, Vector3 direction, float radius, out RaycastHit hit, float distance = float.MaxValue, int mask = -5, QueryTriggerInteraction triggers = QueryTriggerInteraction.UseGlobal) => position.transform.position.SphereCast(direction, radius, out hit, distance, mask, triggers);
        
        /// <summary>
        /// Perform a SphereCast in the forward direction.
        /// </summary>
        /// <param name="position">The starting position of the cast which will be cast in its forward direction.</param>
        /// <param name="radius">The radius of the cast.</param>
        /// <param name="hit">The hit information from the cast.</param>
        /// <param name="distance">The distance for the cast.</param>
        /// <param name="mask">The optional layer mask.</param>
        /// <param name="triggers">How the cast should handle hitting triggers.</param>
        /// <returns>If the cast hit a collider or not.</returns>
        public static bool SphereCast([NotNull] this GameObject position, float radius, out RaycastHit hit, float distance = float.MaxValue, int mask = -5, QueryTriggerInteraction triggers = QueryTriggerInteraction.UseGlobal)
        {
            Transform t = position.transform;
            return t.position.SphereCast(t.forward, radius, out hit, distance, mask, triggers);
        }
        
        /// <summary>
        /// Perform multiple raycasts given by the length of the hits array evenly spread across the angle given.
        /// </summary>
        /// <param name="position">The starting position of the cast.</param>
        /// <param name="direction">The direction denoting the center of the arc of casts.</param>
        /// <param name="hits">The hits detected from the arc, stored from left to right.</param>
        /// <param name="angle">The angle of the arc in degrees.</param>
        /// <param name="distance">The distance for the casts.</param>
        /// <param name="mask">The optional layer mask.</param>
        /// <param name="triggers">How the casts should handle hitting triggers.</param>
        /// <returns>The number of rays which reported a hit, which will match the number of non-null entries in the hit array.</returns>
        public static int ArcRaycast(this Vector2 position, Vector2 direction, [NotNull] RaycastHit?[] hits, float angle = 360f, float distance = float.MaxValue, int mask = -5, QueryTriggerInteraction triggers = QueryTriggerInteraction.UseGlobal) => position.Expand().ArcRaycast(direction.Expand(), hits, angle, distance, mask, triggers);
        
        /// <summary>
        /// Perform multiple raycasts given by the length of the hits array evenly spread across the angle given.
        /// </summary>
        /// <param name="position">The starting position of the cast.</param>
        /// <param name="direction">The direction denoting the center of the arc of casts.</param>
        /// <param name="hits">The hits detected from the arc, stored from left to right.</param>
        /// <param name="angle">The angle of the arc in degrees.</param>
        /// <param name="distance">The distance for the casts.</param>
        /// <param name="mask">The optional layer mask.</param>
        /// <param name="triggers">How the casts should handle hitting triggers.</param>
        /// <returns>The number of rays which reported a hit, which will match the number of non-null entries in the hit array.</returns>
        public static int ArcRaycast(this Vector2 position, Vector3 direction, [NotNull] RaycastHit?[] hits, float angle = 360f, float distance = float.MaxValue, int mask = -5, QueryTriggerInteraction triggers = QueryTriggerInteraction.UseGlobal) => position.Expand().ArcRaycast(direction, hits, angle, distance, mask, triggers);
        
        /// <summary>
        /// Perform multiple raycasts given by the length of the hits array evenly spread across the angle given.
        /// </summary>
        /// <param name="position">The starting position of the cast.</param>
        /// <param name="direction">The direction denoting the center of the arc of casts.</param>
        /// <param name="hits">The hits detected from the arc, stored from left to right.</param>
        /// <param name="angle">The angle of the arc in degrees.</param>
        /// <param name="distance">The distance for the casts.</param>
        /// <param name="mask">The optional layer mask.</param>
        /// <param name="triggers">How the casts should handle hitting triggers.</param>
        /// <returns>The number of rays which reported a hit, which will match the number of non-null entries in the hit array.</returns>
        public static int ArcRaycast(this Vector3 position, Vector2 direction, [NotNull] RaycastHit?[] hits, float angle = 360f, float distance = float.MaxValue, int mask = -5, QueryTriggerInteraction triggers = QueryTriggerInteraction.UseGlobal) => position.ArcRaycast(direction.Expand(), hits, angle, distance, mask, triggers);
        
        /// <summary>
        /// Perform multiple raycasts given by the length of the hits array evenly spread across the angle given.
        /// </summary>
        /// <param name="position">The starting position of the cast.</param>
        /// <param name="direction">The direction denoting the center of the arc of casts.</param>
        /// <param name="hits">The hits detected from the arc, stored from left to right.</param>
        /// <param name="angle">The angle of the arc in degrees.</param>
        /// <param name="distance">The distance for the casts.</param>
        /// <param name="mask">The optional layer mask.</param>
        /// <param name="triggers">How the casts should handle hitting triggers.</param>
        /// <returns>The number of rays which reported a hit, which will match the number of non-null entries in the hit array.</returns>
        public static int ArcRaycast(this Vector3 position, Vector3 direction, [NotNull] RaycastHit?[] hits, float angle = 360f, float distance = float.MaxValue, int mask = -5, QueryTriggerInteraction triggers = QueryTriggerInteraction.UseGlobal)
        {
            switch (hits.Length)
            {
                // Nothing to do if no hits to store.
                case < 1:
                    return 0;
                // If only a single cast should be performed, it should shoot straight in the given direction.
                case 1 when position.Raycast(direction, out RaycastHit hit, distance, mask, triggers):
                    hits[0] = hit;
                    return 1;
                case 1:
                    hits[0] = null;
                    return 0;
            }
            
            // Ensure a valid angle.
            angle = Mathf.Clamp(angle, float.Epsilon, 360f);
            
            // Calculate the angular step between each cast. We divide by the length less one to ensure the first and last casts align with the edges of the arc.
            float step = angle / (hits.Length - 1);
            
            // Start at negative half the angle (left) and move towards positive (right).
            float currentAngle = -angle / 2f;
            
            int hitCount = 0;
            Vector3 axis = Vector3.up;
            for (int i = 0; i < hits.Length; i++)
            {
                // Perform the cast. Create the rotation for this specific step in the arc. Apply the rotation to the forward direction vector.
                if (position.Raycast(Quaternion.AngleAxis(currentAngle, axis) * direction, out RaycastHit hit, distance, mask, triggers))
                {
                    hits[i] = hit;
                    hitCount++;
                }
                else
                {
                    // Explicitly NULL out the entry if the cast missed, ensuring no stale data remains in the array.
                    hits[i] = null;
                }
                
                // Advance the angle for the next cast.
                currentAngle += step;
            }
            
            return hitCount;
        }
        
        /// <summary>
        /// Perform multiple raycasts given by the length of the hits array evenly spread across the angle given.
        /// </summary>
        /// <param name="position">The starting position of the cast.</param>
        /// <param name="direction">The direction denoting the center of the arc of casts.</param>
        /// <param name="hits">The hits detected from the arc, stored from left to right.</param>
        /// <param name="angle">The angle of the arc in degrees.</param>
        /// <param name="distance">The distance for the casts.</param>
        /// <param name="mask">The optional layer mask.</param>
        /// <param name="triggers">How the casts should handle hitting triggers.</param>
        /// <returns>The number of rays which reported a hit, which will match the number of non-null entries in the hit array.</returns>
        public static int ArcRaycast([NotNull] this Transform position, Vector2 direction, [NotNull] RaycastHit?[] hits, float angle = 360f, float distance = float.MaxValue, int mask = -5, QueryTriggerInteraction triggers = QueryTriggerInteraction.UseGlobal) => position.position.ArcRaycast(direction.Expand(), hits, angle, distance, mask, triggers);
        
        /// <summary>
        /// Perform multiple raycasts given by the length of the hits array evenly spread across the angle given.
        /// </summary>
        /// <param name="position">The starting position of the cast.</param>
        /// <param name="direction">The direction denoting the center of the arc of casts.</param>
        /// <param name="hits">The hits detected from the arc, stored from left to right.</param>
        /// <param name="angle">The angle of the arc in degrees.</param>
        /// <param name="distance">The distance for the casts.</param>
        /// <param name="mask">The optional layer mask.</param>
        /// <param name="triggers">How the casts should handle hitting triggers.</param>
        /// <returns>The number of rays which reported a hit, which will match the number of non-null entries in the hit array.</returns>
        public static int ArcRaycast([NotNull] this Transform position, Vector3 direction, [NotNull] RaycastHit?[] hits, float angle = 360f, float distance = float.MaxValue, int mask = -5, QueryTriggerInteraction triggers = QueryTriggerInteraction.UseGlobal) => position.position.ArcRaycast(direction, hits, angle, distance, mask, triggers);
        
        /// <summary>
        /// Perform multiple raycasts given by the length of the hits array evenly spread across the angle given.
        /// </summary>
        /// <param name="position">The starting position of the cast which will be cast in its forward direction.</param>
        /// <param name="hits">The hits detected from the arc, stored from left to right.</param>
        /// <param name="angle">The angle of the arc in degrees.</param>
        /// <param name="distance">The distance for the casts.</param>
        /// <param name="mask">The optional layer mask.</param>
        /// <param name="triggers">How the casts should handle hitting triggers.</param>
        /// <returns>The number of rays which reported a hit, which will match the number of non-null entries in the hit array.</returns>
        public static int ArcRaycast([NotNull] this Transform position, [NotNull] RaycastHit?[] hits, float angle = 360f, float distance = float.MaxValue, int mask = -5, QueryTriggerInteraction triggers = QueryTriggerInteraction.UseGlobal) => position.position.ArcRaycast(position.forward, hits, angle, distance, mask, triggers);
        
        /// <summary>
        /// Perform multiple raycasts given by the length of the hits array evenly spread across the angle given.
        /// </summary>
        /// <param name="position">The starting position of the cast.</param>
        /// <param name="direction">The direction denoting the center of the arc of casts.</param>
        /// <param name="hits">The hits detected from the arc, stored from left to right.</param>
        /// <param name="angle">The angle of the arc in degrees.</param>
        /// <param name="distance">The distance for the casts.</param>
        /// <param name="mask">The optional layer mask.</param>
        /// <param name="triggers">How the casts should handle hitting triggers.</param>
        /// <returns>The number of rays which reported a hit, which will match the number of non-null entries in the hit array.</returns>
        public static int ArcRaycast([NotNull] this Component position, Vector2 direction, [NotNull] RaycastHit?[] hits, float angle = 360f, float distance = float.MaxValue, int mask = -5, QueryTriggerInteraction triggers = QueryTriggerInteraction.UseGlobal) => position.transform.position.ArcRaycast(direction.Expand(), hits, angle, distance, mask, triggers);
        
        /// <summary>
        /// Perform multiple raycasts given by the length of the hits array evenly spread across the angle given.
        /// </summary>
        /// <param name="position">The starting position of the cast.</param>
        /// <param name="direction">The direction denoting the center of the arc of casts.</param>
        /// <param name="hits">The hits detected from the arc, stored from left to right.</param>
        /// <param name="angle">The angle of the arc in degrees.</param>
        /// <param name="distance">The distance for the casts.</param>
        /// <param name="mask">The optional layer mask.</param>
        /// <param name="triggers">How the casts should handle hitting triggers.</param>
        /// <returns>The number of rays which reported a hit, which will match the number of non-null entries in the hit array.</returns>
        public static int ArcRaycast([NotNull] this Component position, Vector3 direction, [NotNull] RaycastHit?[] hits, float angle = 360f, float distance = float.MaxValue, int mask = -5, QueryTriggerInteraction triggers = QueryTriggerInteraction.UseGlobal) => position.transform.position.ArcRaycast(direction, hits, angle, distance, mask, triggers);
        
        /// <summary>
        /// Perform multiple raycasts given by the length of the hits array evenly spread across the angle given.
        /// </summary>
        /// <param name="position">The starting position of the cast which will be cast in its forward direction.</param>
        /// <param name="hits">The hits detected from the arc, stored from left to right.</param>
        /// <param name="angle">The angle of the arc in degrees.</param>
        /// <param name="distance">The distance for the casts.</param>
        /// <param name="mask">The optional layer mask.</param>
        /// <param name="triggers">How the casts should handle hitting triggers.</param>
        /// <returns>The number of rays which reported a hit, which will match the number of non-null entries in the hit array.</returns>
        public static int ArcRaycast([NotNull] this Component position, [NotNull] RaycastHit?[] hits, float angle = 360f, float distance = float.MaxValue, int mask = -5, QueryTriggerInteraction triggers = QueryTriggerInteraction.UseGlobal)
        {
            Transform t = position.transform;
            return t.position.ArcRaycast(t.forward, hits, angle, distance, mask, triggers);
        }
        
        /// <summary>
        /// Perform multiple raycasts given by the length of the hits array evenly spread across the angle given.
        /// </summary>
        /// <param name="position">The starting position of the cast.</param>
        /// <param name="direction">The direction denoting the center of the arc of casts.</param>
        /// <param name="hits">The hits detected from the arc, stored from left to right.</param>
        /// <param name="angle">The angle of the arc in degrees.</param>
        /// <param name="distance">The distance for the casts.</param>
        /// <param name="mask">The optional layer mask.</param>
        /// <param name="triggers">How the casts should handle hitting triggers.</param>
        /// <returns>The number of rays which reported a hit, which will match the number of non-null entries in the hit array.</returns>
        public static int ArcRaycast([NotNull] this GameObject position, Vector2 direction, [NotNull] RaycastHit?[] hits, float angle = 360f, float distance = float.MaxValue, int mask = -5, QueryTriggerInteraction triggers = QueryTriggerInteraction.UseGlobal) => position.transform.position.ArcRaycast(direction.Expand(), hits, angle, distance, mask, triggers);
        
        /// <summary>
        /// Perform multiple raycasts given by the length of the hits array evenly spread across the angle given.
        /// </summary>
        /// <param name="position">The starting position of the cast.</param>
        /// <param name="direction">The direction denoting the center of the arc of casts.</param>
        /// <param name="hits">The hits detected from the arc, stored from left to right.</param>
        /// <param name="angle">The angle of the arc in degrees.</param>
        /// <param name="distance">The distance for the casts.</param>
        /// <param name="mask">The optional layer mask.</param>
        /// <param name="triggers">How the casts should handle hitting triggers.</param>
        /// <returns>The number of rays which reported a hit, which will match the number of non-null entries in the hit array.</returns>
        public static int ArcRaycast([NotNull] this GameObject position, Vector3 direction, [NotNull] RaycastHit?[] hits, float angle = 360f, float distance = float.MaxValue, int mask = -5, QueryTriggerInteraction triggers = QueryTriggerInteraction.UseGlobal) => position.transform.position.ArcRaycast(direction, hits, angle, distance, mask, triggers);
        
        /// <summary>
        /// Perform multiple raycasts given by the length of the hits array evenly spread across the angle given.
        /// </summary>
        /// <param name="position">The starting position of the cast which will be cast in its forward direction.</param>
        /// <param name="hits">The hits detected from the arc, stored from left to right.</param>
        /// <param name="angle">The angle of the arc in degrees.</param>
        /// <param name="distance">The distance for the casts.</param>
        /// <param name="mask">The optional layer mask.</param>
        /// <param name="triggers">How the casts should handle hitting triggers.</param>
        /// <returns>The number of rays which reported a hit, which will match the number of non-null entries in the hit array.</returns>
        public static int ArcRaycast([NotNull] this GameObject position, [NotNull] RaycastHit?[] hits, float angle = 360f, float distance = float.MaxValue, int mask = -5, QueryTriggerInteraction triggers = QueryTriggerInteraction.UseGlobal)
        {
            Transform t = position.transform;
            return t.position.ArcRaycast(t.forward, hits, angle, distance, mask, triggers);
        }
        
        /// <summary>
        /// Perform multiple sphere casts given by the length of the hits array evenly spread across the angle given.
        /// </summary>
        /// <param name="position">The starting position of the cast.</param>
        /// <param name="direction">The direction denoting the center of the arc of casts.</param>
        /// <param name="radius">The radius of the cast.</param>
        /// <param name="hits">The hits detected from the arc, stored from left to right.</param>
        /// <param name="angle">The angle of the arc in degrees.</param>
        /// <param name="distance">The distance for the casts.</param>
        /// <param name="mask">The optional layer mask.</param>
        /// <param name="triggers">How the casts should handle hitting triggers.</param>
        /// <returns>The number of rays which reported a hit, which will match the number of non-null entries in the hit array.</returns>
        public static int ArcSphereCast(this Vector2 position, Vector2 direction, float radius, [NotNull] RaycastHit?[] hits, float angle = 360f, float distance = float.MaxValue, int mask = -5, QueryTriggerInteraction triggers = QueryTriggerInteraction.UseGlobal) => position.Expand().ArcSphereCast(direction.Expand(), radius, hits, angle, distance, mask, triggers);
        
        /// <summary>
        /// Perform multiple sphere casts given by the length of the hits array evenly spread across the angle given.
        /// </summary>
        /// <param name="position">The starting position of the cast.</param>
        /// <param name="direction">The direction denoting the center of the arc of casts.</param>
        /// <param name="radius">The radius of the cast.</param>
        /// <param name="hits">The hits detected from the arc, stored from left to right.</param>
        /// <param name="angle">The angle of the arc in degrees.</param>
        /// <param name="distance">The distance for the casts.</param>
        /// <param name="mask">The optional layer mask.</param>
        /// <param name="triggers">How the casts should handle hitting triggers.</param>
        /// <returns>The number of rays which reported a hit, which will match the number of non-null entries in the hit array.</returns>
        public static int ArcSphereCast(this Vector2 position, Vector3 direction, float radius, [NotNull] RaycastHit?[] hits, float angle = 360f, float distance = float.MaxValue, int mask = -5, QueryTriggerInteraction triggers = QueryTriggerInteraction.UseGlobal) => position.Expand().ArcSphereCast(direction, radius, hits, angle, distance, mask, triggers);
        
        /// <summary>
        /// Perform multiple sphere casts given by the length of the hits array evenly spread across the angle given.
        /// </summary>
        /// <param name="position">The starting position of the cast.</param>
        /// <param name="direction">The direction denoting the center of the arc of casts.</param>
        /// <param name="radius">The radius of the cast.</param>
        /// <param name="hits">The hits detected from the arc, stored from left to right.</param>
        /// <param name="angle">The angle of the arc in degrees.</param>
        /// <param name="distance">The distance for the casts.</param>
        /// <param name="mask">The optional layer mask.</param>
        /// <param name="triggers">How the casts should handle hitting triggers.</param>
        /// <returns>The number of rays which reported a hit, which will match the number of non-null entries in the hit array.</returns>
        public static int ArcSphereCast(this Vector3 position, Vector2 direction, float radius, [NotNull] RaycastHit?[] hits, float angle = 360f, float distance = float.MaxValue, int mask = -5, QueryTriggerInteraction triggers = QueryTriggerInteraction.UseGlobal) => position.ArcSphereCast(direction.Expand(), radius, hits, angle, distance, mask, triggers);
        
        /// <summary>
        /// Perform multiple sphere casts given by the length of the hits array evenly spread across the angle given.
        /// </summary>
        /// <param name="position">The starting position of the cast.</param>
        /// <param name="direction">The direction denoting the center of the arc of casts.</param>
        /// <param name="radius">The radius of the cast.</param>
        /// <param name="hits">The hits detected from the arc, stored from left to right.</param>
        /// <param name="angle">The angle of the arc in degrees.</param>
        /// <param name="distance">The distance for the casts.</param>
        /// <param name="mask">The optional layer mask.</param>
        /// <param name="triggers">How the casts should handle hitting triggers.</param>
        /// <returns>The number of rays which reported a hit, which will match the number of non-null entries in the hit array.</returns>
        public static int ArcSphereCast(this Vector3 position, Vector3 direction, float radius, [NotNull] RaycastHit?[] hits, float angle = 360f, float distance = float.MaxValue, int mask = -5, QueryTriggerInteraction triggers = QueryTriggerInteraction.UseGlobal)
        {
            switch (hits.Length)
            {
                // Nothing to do if no hits to store.
                case < 1:
                    return 0;
                // If only a single cast should be performed, it should shoot straight in the given direction.
                case 1 when position.Raycast(direction, out RaycastHit hit, distance, mask, triggers):
                    hits[0] = hit;
                    return 1;
                case 1:
                    hits[0] = null;
                    return 0;
            }
            
            // Ensure a valid angle.
            angle = Mathf.Clamp(angle, float.Epsilon, 360f);
            
            // Calculate the angular step between each cast. We divide by the length less one to ensure the first and last casts align with the edges of the arc.
            float step = angle / (hits.Length - 1);
            
            // Start at negative half the angle (left) and move towards positive (right).
            float currentAngle = -angle / 2f;
            
            int hitCount = 0;
            Vector3 axis = Vector3.up;
            for (int i = 0; i < hits.Length; i++)
            {
                // Perform the cast. Create the rotation for this specific step in the arc. Apply the rotation to the forward direction vector.
                if (position.SphereCast(Quaternion.AngleAxis(currentAngle, axis) * direction, radius, out RaycastHit hit, distance, mask, triggers))
                {
                    hits[i] = hit;
                    hitCount++;
                }
                else
                {
                    // Explicitly NULL out the entry if the cast missed, ensuring no stale data remains in the array.
                    hits[i] = null;
                }
                
                // Advance the angle for the next cast.
                currentAngle += step;
            }
            
            return hitCount;
        }
        
        /// <summary>
        /// Perform multiple sphere casts given by the length of the hits array evenly spread across the angle given.
        /// </summary>
        /// <param name="position">The starting position of the cast.</param>
        /// <param name="direction">The direction denoting the center of the arc of casts.</param>
        /// <param name="radius">The radius of the cast.</param>
        /// <param name="hits">The hits detected from the arc, stored from left to right.</param>
        /// <param name="angle">The angle of the arc in degrees.</param>
        /// <param name="distance">The distance for the casts.</param>
        /// <param name="mask">The optional layer mask.</param>
        /// <param name="triggers">How the casts should handle hitting triggers.</param>
        /// <returns>The number of rays which reported a hit, which will match the number of non-null entries in the hit array.</returns>
        public static int ArcSphereCast([NotNull] this Transform position, Vector2 direction, float radius, [NotNull] RaycastHit?[] hits, float angle = 360f, float distance = float.MaxValue, int mask = -5, QueryTriggerInteraction triggers = QueryTriggerInteraction.UseGlobal) => position.position.ArcSphereCast(direction.Expand(), radius, hits, angle, distance, mask, triggers);
        
        /// <summary>
        /// Perform multiple sphere casts given by the length of the hits array evenly spread across the angle given.
        /// </summary>
        /// <param name="position">The starting position of the cast.</param>
        /// <param name="direction">The direction denoting the center of the arc of casts.</param>
        /// <param name="radius">The radius of the cast.</param>
        /// <param name="hits">The hits detected from the arc, stored from left to right.</param>
        /// <param name="angle">The angle of the arc in degrees.</param>
        /// <param name="distance">The distance for the casts.</param>
        /// <param name="mask">The optional layer mask.</param>
        /// <param name="triggers">How the casts should handle hitting triggers.</param>
        /// <returns>The number of rays which reported a hit, which will match the number of non-null entries in the hit array.</returns>
        public static int ArcSphereCast([NotNull] this Transform position, Vector3 direction, float radius, [NotNull] RaycastHit?[] hits, float angle = 360f, float distance = float.MaxValue, int mask = -5, QueryTriggerInteraction triggers = QueryTriggerInteraction.UseGlobal) => position.position.ArcSphereCast(direction, radius, hits, angle, distance, mask, triggers);
        
        /// <summary>
        /// Perform multiple sphere casts given by the length of the hits array evenly spread across the angle given.
        /// </summary>
        /// <param name="position">The starting position of the cast which will be cast in its forward direction.</param>
        /// <param name="radius">The radius of the cast.</param>
        /// <param name="hits">The hits detected from the arc, stored from left to right.</param>
        /// <param name="angle">The angle of the arc in degrees.</param>
        /// <param name="distance">The distance for the casts.</param>
        /// <param name="mask">The optional layer mask.</param>
        /// <param name="triggers">How the casts should handle hitting triggers.</param>
        /// <returns>The number of rays which reported a hit, which will match the number of non-null entries in the hit array.</returns>
        public static int ArcSphereCast([NotNull] this Transform position, float radius, [NotNull] RaycastHit?[] hits, float angle = 360f, float distance = float.MaxValue, int mask = -5, QueryTriggerInteraction triggers = QueryTriggerInteraction.UseGlobal) => position.position.ArcSphereCast(position.forward, radius, hits, angle, distance, mask, triggers);
        
        /// <summary>
        /// Perform multiple sphere casts given by the length of the hits array evenly spread across the angle given.
        /// </summary>
        /// <param name="position">The starting position of the cast.</param>
        /// <param name="direction">The direction denoting the center of the arc of casts.</param>
        /// <param name="radius">The radius of the cast.</param>
        /// <param name="hits">The hits detected from the arc, stored from left to right.</param>
        /// <param name="angle">The angle of the arc in degrees.</param>
        /// <param name="distance">The distance for the casts.</param>
        /// <param name="mask">The optional layer mask.</param>
        /// <param name="triggers">How the casts should handle hitting triggers.</param>
        /// <returns>The number of rays which reported a hit, which will match the number of non-null entries in the hit array.</returns>
        public static int ArcSphereCast([NotNull] this Component position, Vector2 direction, float radius, [NotNull] RaycastHit?[] hits, float angle = 360f, float distance = float.MaxValue, int mask = -5, QueryTriggerInteraction triggers = QueryTriggerInteraction.UseGlobal) => position.transform.position.ArcSphereCast(direction.Expand(), radius, hits, angle, distance, mask, triggers);
        
        /// <summary>
        /// Perform multiple sphere casts given by the length of the hits array evenly spread across the angle given.
        /// </summary>
        /// <param name="position">The starting position of the cast.</param>
        /// <param name="direction">The direction denoting the center of the arc of casts.</param>
        /// <param name="radius">The radius of the cast.</param>
        /// <param name="hits">The hits detected from the arc, stored from left to right.</param>
        /// <param name="angle">The angle of the arc in degrees.</param>
        /// <param name="distance">The distance for the casts.</param>
        /// <param name="mask">The optional layer mask.</param>
        /// <param name="triggers">How the casts should handle hitting triggers.</param>
        /// <returns>The number of rays which reported a hit, which will match the number of non-null entries in the hit array.</returns>
        public static int ArcSphereCast([NotNull] this Component position, Vector3 direction, float radius, [NotNull] RaycastHit?[] hits, float angle = 360f, float distance = float.MaxValue, int mask = -5, QueryTriggerInteraction triggers = QueryTriggerInteraction.UseGlobal) => position.transform.position.ArcSphereCast(direction, radius, hits, angle, distance, mask, triggers);
        
        /// <summary>
        /// Perform multiple sphere casts given by the length of the hits array evenly spread across the angle given.
        /// </summary>
        /// <param name="position">The starting position of the cast which will be cast in its forward direction.</param>
        /// <param name="radius">The radius of the cast.</param>
        /// <param name="hits">The hits detected from the arc, stored from left to right.</param>
        /// <param name="angle">The angle of the arc in degrees.</param>
        /// <param name="distance">The distance for the casts.</param>
        /// <param name="mask">The optional layer mask.</param>
        /// <param name="triggers">How the casts should handle hitting triggers.</param>
        /// <returns>The number of rays which reported a hit, which will match the number of non-null entries in the hit array.</returns>
        public static int ArcSphereCast([NotNull] this Component position, float radius, [NotNull] RaycastHit?[] hits, float angle = 360f, float distance = float.MaxValue, int mask = -5, QueryTriggerInteraction triggers = QueryTriggerInteraction.UseGlobal)
        {
            Transform t = position.transform;
            return t.position.ArcSphereCast(t.forward, radius, hits, angle, distance, mask, triggers);
        }
        
        /// <summary>
        /// Perform multiple sphere casts given by the length of the hits array evenly spread across the angle given.
        /// </summary>
        /// <param name="position">The starting position of the cast.</param>
        /// <param name="direction">The direction denoting the center of the arc of casts.</param>
        /// <param name="radius">The radius of the cast.</param>
        /// <param name="hits">The hits detected from the arc, stored from left to right.</param>
        /// <param name="angle">The angle of the arc in degrees.</param>
        /// <param name="distance">The distance for the casts.</param>
        /// <param name="mask">The optional layer mask.</param>
        /// <param name="triggers">How the casts should handle hitting triggers.</param>
        /// <returns>The number of rays which reported a hit, which will match the number of non-null entries in the hit array.</returns>
        public static int ArcSphereCast([NotNull] this GameObject position, Vector2 direction, float radius, [NotNull] RaycastHit?[] hits, float angle = 360f, float distance = float.MaxValue, int mask = -5, QueryTriggerInteraction triggers = QueryTriggerInteraction.UseGlobal) => position.transform.position.ArcSphereCast(direction.Expand(), radius, hits, angle, distance, mask, triggers);
        
        /// <summary>
        /// Perform multiple sphere casts given by the length of the hits array evenly spread across the angle given.
        /// </summary>
        /// <param name="position">The starting position of the cast.</param>
        /// <param name="direction">The direction denoting the center of the arc of casts.</param>
        /// <param name="radius">The radius of the cast.</param>
        /// <param name="hits">The hits detected from the arc, stored from left to right.</param>
        /// <param name="angle">The angle of the arc in degrees.</param>
        /// <param name="distance">The distance for the casts.</param>
        /// <param name="mask">The optional layer mask.</param>
        /// <param name="triggers">How the casts should handle hitting triggers.</param>
        /// <returns>The number of rays which reported a hit, which will match the number of non-null entries in the hit array.</returns>
        public static int ArcSphereCast([NotNull] this GameObject position, Vector3 direction, float radius, [NotNull] RaycastHit?[] hits, float angle = 360f, float distance = float.MaxValue, int mask = -5, QueryTriggerInteraction triggers = QueryTriggerInteraction.UseGlobal) => position.transform.position.ArcSphereCast(direction, radius, hits, angle, distance, mask, triggers);
        
        /// <summary>
        /// Perform multiple sphere casts given by the length of the hits array evenly spread across the angle given.
        /// </summary>
        /// <param name="position">The starting position of the cast which will be cast in its forward direction.</param>
        /// <param name="radius">The radius of the cast.</param>
        /// <param name="hits">The hits detected from the arc, stored from left to right.</param>
        /// <param name="angle">The angle of the arc in degrees.</param>
        /// <param name="distance">The distance for the casts.</param>
        /// <param name="mask">The optional layer mask.</param>
        /// <param name="triggers">How the casts should handle hitting triggers.</param>
        /// <returns>The number of rays which reported a hit, which will match the number of non-null entries in the hit array.</returns>
        public static int ArcSphereCast([NotNull] this GameObject position, float radius, [NotNull] RaycastHit?[] hits, float angle = 360f, float distance = float.MaxValue, int mask = -5, QueryTriggerInteraction triggers = QueryTriggerInteraction.UseGlobal)
        {
            Transform t = position.transform;
            return t.position.ArcSphereCast(t.forward, radius, hits, angle, distance, mask, triggers);
        }
        
        /// <summary>
        /// Extract the point vectors from hits. This does not perform any actual casting. For casting, see any of the arc casting methods. This can be useful if your agent only needs position vectors or to help perform debugging.
        /// </summary>
        /// <param name="position">The starting position where the casting were performed.</param>
        /// <param name="direction">The central direction of the casting.</param>
        /// <param name="hits">The hits from casting.</param>
        /// <param name="positions">Will be updated to store the positions from the hits or otherwise the maximum extents for misses.</param>
        /// <param name="angle">The angle of the arc in degrees which was used for casting.</param>
        /// <param name="distance">The distance of the casts which were run.</param>
        public static void ExtractPoints(this Vector2 position, Vector2 direction, [NotNull] RaycastHit?[] hits, [NotNull] Vector3[] positions, float angle = 360f, float distance = float.MaxValue) => position.Expand().ExtractPoints(direction.Expand(), hits, positions, angle, distance);
        
        /// <summary>
        /// Extract the point vectors from hits. This does not perform any actual casting. For casting, see any of the arc casting methods. This can be useful if your agent only needs position vectors or to help perform debugging.
        /// </summary>
        /// <param name="position">The starting position where the casting were performed.</param>
        /// <param name="direction">The central direction of the casting.</param>
        /// <param name="hits">The hits from casting.</param>
        /// <param name="positions">Will be updated to store the positions from the hits or otherwise the maximum extents for misses.</param>
        /// <param name="angle">The angle of the arc in degrees which was used for casting.</param>
        /// <param name="distance">The distance of the casts which were run.</param>
        public static void ExtractPoints(this Vector2 position, Vector3 direction, [NotNull] RaycastHit?[] hits, [NotNull] Vector3[] positions, float angle = 360f, float distance = float.MaxValue) => position.Expand().ExtractPoints(direction, hits, positions, angle, distance);
        
        /// <summary>
        /// Extract the point vectors from hits. This does not perform any actual casting. For casting, see any of the arc casting methods. This can be useful if your agent only needs position vectors or to help perform debugging.
        /// </summary>
        /// <param name="position">The starting position where the casting were performed.</param>
        /// <param name="direction">The central direction of the casting.</param>
        /// <param name="hits">The hits from casting.</param>
        /// <param name="positions">Will be updated to store the positions from the hits or otherwise the maximum extents for misses.</param>
        /// <param name="angle">The angle of the arc in degrees which was used for casting.</param>
        /// <param name="distance">The distance of the casts which were run.</param>
        public static void ExtractPoints(this Vector3 position, Vector2 direction, [NotNull] RaycastHit?[] hits, [NotNull] Vector3[] positions, float angle = 360f, float distance = float.MaxValue) => position.ExtractPoints(direction.Expand(), hits, positions, angle, distance);
        
        /// <summary>
        /// Extract the point vectors from hits. This does not perform any actual casting. For casting, see any of the arc casting methods. This can be useful if your agent only needs position vectors or to help perform debugging.
        /// </summary>
        /// <param name="position">The starting position where the casting were performed.</param>
        /// <param name="direction">The central direction of the casting.</param>
        /// <param name="hits">The hits from casting.</param>
        /// <param name="positions">Will be updated to store the positions from the hits or otherwise the maximum extents for misses.</param>
        /// <param name="angle">The angle of the arc in degrees which was used for casting.</param>
        /// <param name="distance">The distance of the casts which were run.</param>
        public static void ExtractPoints(this Vector3 position, Vector3 direction, [NotNull] RaycastHit?[] hits, [NotNull] Vector3[] positions, float angle = 360f, float distance = float.MaxValue)
        {
            // See how many we can check based on space, stopping if none.
            int length = Mathf.Min(hits.Length, positions.Length);
            if (length < 1)
            {
                return;
            }
            
            // If this was a single cast, it is directly forward.
            if (hits.Length == 1)
            {
                positions[0] = hits[0]?.point ?? position + direction.normalized * distance;
                return;
            }
            
            // Ensure a valid angle.
            angle = Mathf.Clamp(angle, float.Epsilon, 360f);
            
            // Calculate the angular step between each cast. We divide by the length less one to ensure the first and last casts align with the edges of the arc.
            float step = angle / (hits.Length - 1);
            
            // Start at negative half the angle (left) and move towards positive (right).
            float currentAngle = -angle / 2f;
            
            // Copy as many as there is space for.
            Vector3 axis = Vector3.up;
            for (int i = 0; i < length; i++)
            {
                // If this was a hit, copy the value. Otherwise, get the point at the end of the casts.
                positions[i] = hits[i]?.point ?? position + (Quaternion.AngleAxis(currentAngle, axis) * direction).normalized * distance;
                
                // Advance the angle for the next cast.
                currentAngle += step;
            }
        }
        
        /// <summary>
        /// Extract the point vectors from hits. This does not perform any actual casting. For casting, see any of the arc casting methods. This can be useful if your agent only needs position vectors or to help perform debugging.
        /// </summary>
        /// <param name="position">The starting position where the casting were performed.</param>
        /// <param name="direction">The central direction of the casting.</param>
        /// <param name="hits">The hits from casting.</param>
        /// <param name="positions">Will be updated to store the positions from the hits or otherwise the maximum extents for misses.</param>
        /// <param name="angle">The angle of the arc in degrees which was used for casting.</param>
        /// <param name="distance">The distance of the casts which were run.</param>
        public static void ExtractPoints([NotNull] this Transform position, Vector2 direction, [NotNull] RaycastHit?[] hits, [NotNull] Vector3[] positions, float angle = 360f, float distance = float.MaxValue) => position.position.ExtractPoints(direction.Expand(), hits, positions, angle, distance);
        
        /// <summary>
        /// Extract the point vectors from hits. This does not perform any actual casting. For casting, see any of the arc casting methods. This can be useful if your agent only needs position vectors or to help perform debugging.
        /// </summary>
        /// <param name="position">The starting position where the casting were performed.</param>
        /// <param name="direction">The central direction of the casting.</param>
        /// <param name="hits">The hits from casting.</param>
        /// <param name="positions">Will be updated to store the positions from the hits or otherwise the maximum extents for misses.</param>
        /// <param name="angle">The angle of the arc in degrees which was used for casting.</param>
        /// <param name="distance">The distance of the casts which were run.</param>
        public static void ExtractPoints([NotNull] this Transform position, Vector3 direction, [NotNull] RaycastHit?[] hits, [NotNull] Vector3[] positions, float angle = 360f, float distance = float.MaxValue) => position.position.ExtractPoints(direction, hits, positions, angle, distance);
        
        /// <summary>
        /// Extract the point vectors from hits. This does not perform any actual casting. For casting, see any of the arc casting methods. This can be useful if your agent only needs position vectors or to help perform debugging.
        /// </summary>
        /// <param name="position">The starting position where the casting were performed in its forward direction.</param>
        /// <param name="hits">The hits from casting.</param>
        /// <param name="positions">Will be updated to store the positions from the hits or otherwise the maximum extents for misses.</param>
        /// <param name="angle">The angle of the arc in degrees which was used for casting.</param>
        /// <param name="distance">The distance of the casts which were run.</param>
        public static void ExtractPoints([NotNull] this Transform position, [NotNull] RaycastHit?[] hits, [NotNull] Vector3[] positions, float angle = 360f, float distance = float.MaxValue) => position.position.ExtractPoints(position.forward, hits, positions, angle, distance);
        
        /// <summary>
        /// Extract the point vectors from hits. This does not perform any actual casting. For casting, see any of the arc casting methods. This can be useful if your agent only needs position vectors or to help perform debugging.
        /// </summary>
        /// <param name="position">The starting position where the casting were performed.</param>
        /// <param name="direction">The central direction of the casting.</param>
        /// <param name="hits">The hits from casting.</param>
        /// <param name="positions">Will be updated to store the positions from the hits or otherwise the maximum extents for misses.</param>
        /// <param name="angle">The angle of the arc in degrees which was used for casting.</param>
        /// <param name="distance">The distance of the casts which were run.</param>
        public static void ExtractPoints([NotNull] this Component position, Vector2 direction, [NotNull] RaycastHit?[] hits, [NotNull] Vector3[] positions, float angle = 360f, float distance = float.MaxValue) => position.transform.position.ExtractPoints(direction.Expand(), hits, positions, angle, distance);
        
        /// <summary>
        /// Extract the point vectors from hits. This does not perform any actual casting. For casting, see any of the arc casting methods. This can be useful if your agent only needs position vectors or to help perform debugging.
        /// </summary>
        /// <param name="position">The starting position where the casting were performed.</param>
        /// <param name="direction">The central direction of the casting.</param>
        /// <param name="hits">The hits from casting.</param>
        /// <param name="positions">Will be updated to store the positions from the hits or otherwise the maximum extents for misses.</param>
        /// <param name="angle">The angle of the arc in degrees which was used for casting.</param>
        /// <param name="distance">The distance of the casts which were run.</param>
        public static void ExtractPoints([NotNull] this Component position, Vector3 direction, [NotNull] RaycastHit?[] hits, [NotNull] Vector3[] positions, float angle = 360f, float distance = float.MaxValue) => position.transform.position.ExtractPoints(direction, hits, positions, angle, distance);
        
        /// <summary>
        /// Extract the point vectors from hits. This does not perform any actual casting. For casting, see any of the arc casting methods. This can be useful if your agent only needs position vectors or to help perform debugging.
        /// </summary>
        /// <param name="position">The starting position where the casting were performed in its forward direction.</param>
        /// <param name="hits">The hits from casting.</param>
        /// <param name="positions">Will be updated to store the positions from the hits or otherwise the maximum extents for misses.</param>
        /// <param name="angle">The angle of the arc in degrees which was used for casting.</param>
        /// <param name="distance">The distance of the casts which were run.</param>
        public static void ExtractPoints([NotNull] this Component position, [NotNull] RaycastHit?[] hits, [NotNull] Vector3[] positions, float angle = 360f, float distance = float.MaxValue)
        {
            Transform t = position.transform;
            t.position.ExtractPoints(t.forward, hits, positions, angle, distance);
        }
        
        /// <summary>
        /// Extract the point vectors from hits. This does not perform any actual casting. For casting, see any of the arc casting methods. This can be useful if your agent only needs position vectors or to help perform debugging.
        /// </summary>
        /// <param name="position">The starting position where the casting were performed.</param>
        /// <param name="direction">The central direction of the casting.</param>
        /// <param name="hits">The hits from casting.</param>
        /// <param name="positions">Will be updated to store the positions from the hits or otherwise the maximum extents for misses.</param>
        /// <param name="angle">The angle of the arc in degrees which was used for casting.</param>
        /// <param name="distance">The distance of the casts which were run.</param>
        public static void ExtractPoints([NotNull] this GameObject position, Vector2 direction, [NotNull] RaycastHit?[] hits, [NotNull] Vector3[] positions, float angle = 360f, float distance = float.MaxValue) => position.transform.position.ExtractPoints(direction.Expand(), hits, positions, angle, distance);
        
        /// <summary>
        /// Extract the point vectors from hits. This does not perform any actual casting. For casting, see any of the arc casting methods. This can be useful if your agent only needs position vectors or to help perform debugging.
        /// </summary>
        /// <param name="position">The starting position where the casting were performed.</param>
        /// <param name="direction">The central direction of the casting.</param>
        /// <param name="hits">The hits from casting.</param>
        /// <param name="positions">Will be updated to store the positions from the hits or otherwise the maximum extents for misses.</param>
        /// <param name="angle">The angle of the arc in degrees which was used for casting.</param>
        /// <param name="distance">The distance of the casts which were run.</param>
        public static void ExtractPoints([NotNull] this GameObject position, Vector3 direction, [NotNull] RaycastHit?[] hits, [NotNull] Vector3[] positions, float angle = 360f, float distance = float.MaxValue) => position.transform.position.ExtractPoints(direction, hits, positions, angle, distance);
        
        /// <summary>
        /// Extract the point vectors from hits. This does not perform any actual casting. For casting, see any of the arc casting methods. This can be useful if your agent only needs position vectors or to help perform debugging.
        /// </summary>
        /// <param name="position">The starting position where the casting were performed in its forward direction.</param>
        /// <param name="hits">The hits from casting.</param>
        /// <param name="positions">Will be updated to store the positions from the hits or otherwise the maximum extents for misses.</param>
        /// <param name="angle">The angle of the arc in degrees which was used for casting.</param>
        /// <param name="distance">The distance of the casts which were run.</param>
        public static void ExtractPoints([NotNull] this GameObject position, [NotNull] RaycastHit?[] hits, [NotNull] Vector3[] positions, float angle = 360f, float distance = float.MaxValue)
        {
            Transform t = position.transform;
            t.position.ExtractPoints(t.forward, hits, positions, angle, distance);
        }
    }
}