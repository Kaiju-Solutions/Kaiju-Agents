using System.Diagnostics.CodeAnalysis;
using UnityEngine;

namespace KaijuSolutions.Agents
{
    /// <summary>
    /// Extension methods to perform ray casting. Any Vector2 values will be expanded via the <see cref="KaijuAgentsExpand.Expand"/> method.
    /// </summary>
    public static class KaijuAgentsRaycast
    {
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
        public static bool Raycast(this Vector2 position, [NotNull] Transform direction, out RaycastHit hit, float distance = float.MaxValue, int mask = -5, QueryTriggerInteraction triggers = QueryTriggerInteraction.UseGlobal) => position.Expand().Raycast(direction.forward, out hit, distance, mask, triggers);
        
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
        public static bool Raycast(this Vector2 position, [NotNull] Component direction, out RaycastHit hit, float distance = float.MaxValue, int mask = -5, QueryTriggerInteraction triggers = QueryTriggerInteraction.UseGlobal) => position.Expand().Raycast(direction.transform.forward, out hit, distance, mask, triggers);
        
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
        public static bool Raycast(this Vector2 position, [NotNull] GameObject direction, out RaycastHit hit, float distance = float.MaxValue, int mask = -5, QueryTriggerInteraction triggers = QueryTriggerInteraction.UseGlobal) => position.Expand().Raycast(direction.transform.forward, out hit, distance, mask, triggers);
        
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
        public static bool Raycast(this Vector3 position, [NotNull] Transform direction, out RaycastHit hit, float distance = float.MaxValue, int mask = -5, QueryTriggerInteraction triggers = QueryTriggerInteraction.UseGlobal) => position.Raycast(direction.forward, out hit, distance, mask, triggers);
        
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
        public static bool Raycast(this Vector3 position, [NotNull] Component direction, out RaycastHit hit, float distance = float.MaxValue, int mask = -5, QueryTriggerInteraction triggers = QueryTriggerInteraction.UseGlobal) => position.Raycast(direction.transform.forward, out hit, distance, mask, triggers);
        
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
        public static bool Raycast(this Vector3 position, [NotNull] GameObject direction, out RaycastHit hit, float distance = float.MaxValue, int mask = -5, QueryTriggerInteraction triggers = QueryTriggerInteraction.UseGlobal) => position.Raycast(direction.transform.forward, out hit, distance, mask, triggers);
        
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
        /// Perform a raycast.
        /// </summary>
        /// <param name="position">The starting position of the cast.</param>
        /// <param name="direction">The ending position of the cast.</param>
        /// <param name="hit">The hit information from the cast.</param>
        /// <param name="distance">The distance for the cast.</param>
        /// <param name="mask">The optional layer mask.</param>
        /// <param name="triggers">How the cast should handle hitting triggers.</param>
        /// <returns>If the cast hit a collider or not.</returns>
        public static bool Raycast([NotNull] this Transform position, [NotNull] Transform direction, out RaycastHit hit, float distance = float.MaxValue, int mask = -5, QueryTriggerInteraction triggers = QueryTriggerInteraction.UseGlobal) => position.position.Raycast(direction.forward, out hit, distance, mask, triggers);
        
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
        public static bool Raycast([NotNull] this Transform position, [NotNull] Component direction, out RaycastHit hit, float distance = float.MaxValue, int mask = -5, QueryTriggerInteraction triggers = QueryTriggerInteraction.UseGlobal) => position.position.Raycast(direction.transform.forward, out hit, distance, mask, triggers);
        
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
        public static bool Raycast([NotNull] this Transform position, [NotNull] GameObject direction, out RaycastHit hit, float distance = float.MaxValue, int mask = -5, QueryTriggerInteraction triggers = QueryTriggerInteraction.UseGlobal) => position.position.Raycast(direction.transform.forward, out hit, distance, mask, triggers);
        
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
        /// Perform a raycast.
        /// </summary>
        /// <param name="position">The starting position of the cast.</param>
        /// <param name="direction">The ending position of the cast.</param>
        /// <param name="hit">The hit information from the cast.</param>
        /// <param name="distance">The distance for the cast.</param>
        /// <param name="mask">The optional layer mask.</param>
        /// <param name="triggers">How the cast should handle hitting triggers.</param>
        /// <returns>If the cast hit a collider or not.</returns>
        public static bool Raycast([NotNull] this Component position, [NotNull] Transform direction, out RaycastHit hit, float distance = float.MaxValue, int mask = -5, QueryTriggerInteraction triggers = QueryTriggerInteraction.UseGlobal) => position.transform.position.Raycast(direction.forward, out hit, distance, mask, triggers);
        
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
        public static bool Raycast([NotNull] this Component position, [NotNull] Component direction, out RaycastHit hit, float distance = float.MaxValue, int mask = -5, QueryTriggerInteraction triggers = QueryTriggerInteraction.UseGlobal) => position.transform.position.Raycast(direction.transform.forward, out hit, distance, mask, triggers);
        
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
        public static bool Raycast([NotNull] this Component position, [NotNull] GameObject direction, out RaycastHit hit, float distance = float.MaxValue, int mask = -5, QueryTriggerInteraction triggers = QueryTriggerInteraction.UseGlobal) => position.transform.position.Raycast(direction.transform.forward, out hit, distance, mask, triggers);
        
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
        /// Perform a raycast.
        /// </summary>
        /// <param name="position">The starting position of the cast.</param>
        /// <param name="direction">The ending position of the cast.</param>
        /// <param name="hit">The hit information from the cast.</param>
        /// <param name="distance">The distance for the cast.</param>
        /// <param name="mask">The optional layer mask.</param>
        /// <param name="triggers">How the cast should handle hitting triggers.</param>
        /// <returns>If the cast hit a collider or not.</returns>
        public static bool Raycast([NotNull] this GameObject position, [NotNull] Transform direction, out RaycastHit hit, float distance = float.MaxValue, int mask = -5, QueryTriggerInteraction triggers = QueryTriggerInteraction.UseGlobal) => position.transform.position.Raycast(direction.forward, out hit, distance, mask, triggers);
        
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
        public static bool Raycast([NotNull] this GameObject position, [NotNull] Component direction, out RaycastHit hit, float distance = float.MaxValue, int mask = -5, QueryTriggerInteraction triggers = QueryTriggerInteraction.UseGlobal) => position.transform.position.Raycast(direction.transform.forward, out hit, distance, mask, triggers);
        
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
        public static bool Raycast([NotNull] this GameObject position, [NotNull] GameObject direction, out RaycastHit hit, float distance = float.MaxValue, int mask = -5, QueryTriggerInteraction triggers = QueryTriggerInteraction.UseGlobal) => position.transform.position.Raycast(direction.transform.forward, out hit, distance, mask, triggers);
        
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
    }
}