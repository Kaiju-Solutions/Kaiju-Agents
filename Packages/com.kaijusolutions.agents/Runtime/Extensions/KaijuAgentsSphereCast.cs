using System.Diagnostics.CodeAnalysis;
using UnityEngine;

namespace KaijuSolutions.Agents
{
    /// <summary>
    /// Extension methods to perform sphere casting. Any Vector2 values will be expanded via the <see cref="KaijuAgentsExpand.Expand"/> method.
    /// </summary>
    public static class KaijuAgentsSphereCast
    {
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
        public static bool SphereCast(this Vector2 position, [NotNull] Transform direction, float radius, out RaycastHit hit, float distance = float.MaxValue, int mask = -5, QueryTriggerInteraction triggers = QueryTriggerInteraction.UseGlobal) => position.Expand().SphereCast(direction.forward, radius, out hit, distance, mask, triggers);
        
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
        public static bool SphereCast(this Vector2 position, [NotNull] Component direction, float radius, out RaycastHit hit, float distance = float.MaxValue, int mask = -5, QueryTriggerInteraction triggers = QueryTriggerInteraction.UseGlobal) => position.Expand().SphereCast(direction.transform.forward, radius, out hit, distance, mask, triggers);
        
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
        public static bool SphereCast(this Vector2 position, [NotNull] GameObject direction, float radius, out RaycastHit hit, float distance = float.MaxValue, int mask = -5, QueryTriggerInteraction triggers = QueryTriggerInteraction.UseGlobal) => position.Expand().SphereCast(direction.transform.forward, radius, out hit, distance, mask, triggers);
        
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
        public static bool SphereCast(this Vector3 position, [NotNull] Transform direction, float radius, out RaycastHit hit, float distance = float.MaxValue, int mask = -5, QueryTriggerInteraction triggers = QueryTriggerInteraction.UseGlobal) => position.SphereCast(direction.forward, radius, out hit, distance, mask, triggers);
        
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
        public static bool SphereCast(this Vector3 position, [NotNull] Component direction, float radius, out RaycastHit hit, float distance = float.MaxValue, int mask = -5, QueryTriggerInteraction triggers = QueryTriggerInteraction.UseGlobal) => position.SphereCast(direction.transform.forward, radius, out hit, distance, mask, triggers);
        
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
        public static bool SphereCast(this Vector3 position, [NotNull] GameObject direction, float radius, out RaycastHit hit, float distance = float.MaxValue, int mask = -5, QueryTriggerInteraction triggers = QueryTriggerInteraction.UseGlobal) => position.SphereCast(direction.transform.forward, radius, out hit, distance, mask, triggers);
        
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
        public static bool SphereCast([NotNull] this Transform position, [NotNull] Transform direction, float radius, out RaycastHit hit, float distance = float.MaxValue, int mask = -5, QueryTriggerInteraction triggers = QueryTriggerInteraction.UseGlobal) => position.position.SphereCast(direction.forward, radius, out hit, distance, mask, triggers);
        
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
        public static bool SphereCast([NotNull] this Transform position, [NotNull] Component direction, float radius, out RaycastHit hit, float distance = float.MaxValue, int mask = -5, QueryTriggerInteraction triggers = QueryTriggerInteraction.UseGlobal) => position.position.SphereCast(direction.transform.forward, radius, out hit, distance, mask, triggers);
        
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
        public static bool SphereCast([NotNull] this Transform position, [NotNull] GameObject direction, float radius, out RaycastHit hit, float distance = float.MaxValue, int mask = -5, QueryTriggerInteraction triggers = QueryTriggerInteraction.UseGlobal) => position.position.SphereCast(direction.transform.forward, radius, out hit, distance, mask, triggers);
        
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
        public static bool SphereCast([NotNull] this Component position, [NotNull] Transform direction, float radius, out RaycastHit hit, float distance = float.MaxValue, int mask = -5, QueryTriggerInteraction triggers = QueryTriggerInteraction.UseGlobal) => position.transform.position.SphereCast(direction.forward, radius, out hit, distance, mask, triggers);
        
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
        public static bool SphereCast([NotNull] this Component position, [NotNull] Component direction, float radius, out RaycastHit hit, float distance = float.MaxValue, int mask = -5, QueryTriggerInteraction triggers = QueryTriggerInteraction.UseGlobal) => position.transform.position.SphereCast(direction.transform.forward, radius, out hit, distance, mask, triggers);
        
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
        public static bool SphereCast([NotNull] this Component position, [NotNull] GameObject direction, float radius, out RaycastHit hit, float distance = float.MaxValue, int mask = -5, QueryTriggerInteraction triggers = QueryTriggerInteraction.UseGlobal) => position.transform.position.SphereCast(direction.transform.forward, radius, out hit, distance, mask, triggers);
        
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
        public static bool SphereCast([NotNull] this GameObject position, [NotNull] Transform direction, float radius, out RaycastHit hit, float distance = float.MaxValue, int mask = -5, QueryTriggerInteraction triggers = QueryTriggerInteraction.UseGlobal) => position.transform.position.SphereCast(direction.forward, radius, out hit, distance, mask, triggers);
        
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
        public static bool SphereCast([NotNull] this GameObject position, [NotNull] Component direction, float radius, out RaycastHit hit, float distance = float.MaxValue, int mask = -5, QueryTriggerInteraction triggers = QueryTriggerInteraction.UseGlobal) => position.transform.position.SphereCast(direction.transform.forward, radius, out hit, distance, mask, triggers);
        
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
        public static bool SphereCast([NotNull] this GameObject position, [NotNull] GameObject direction, float radius, out RaycastHit hit, float distance = float.MaxValue, int mask = -5, QueryTriggerInteraction triggers = QueryTriggerInteraction.UseGlobal) => position.transform.position.SphereCast(direction.transform.forward, radius, out hit, distance, mask, triggers);
        
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
    }
}