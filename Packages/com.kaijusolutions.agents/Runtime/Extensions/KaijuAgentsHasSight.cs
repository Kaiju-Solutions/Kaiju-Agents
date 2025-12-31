using System.Diagnostics.CodeAnalysis;
using UnityEngine;

namespace KaijuSolutions.Agents.Extension
{
    /// <summary>
    /// Extension methods to see if there is a direct line of sight between two positions across all axes. Any Vector2 values will be expanded via the <see cref="KaijuAgentsExpand.Expand"/> method.
    /// </summary>
    public static class KaijuAgentsHasSight
    {
        /// <summary>
        /// If there is a direct line of sight from a starting position to an end position.
        /// </summary>
        /// <param name="position">The starting position of the line of sight.</param>
        /// <param name="target">The ending position of the line of sight.</param>
        /// <param name="hit">The hit information from the line of sight check.</param>
        /// <param name="mask">The optional layer mask.</param>
        /// <param name="triggers">How the check should handle hitting triggers.</param>
        /// <returns>If there is a direct line of sight from a starting position to an end position.</returns>
        public static bool HasSight(this Vector2 position, Vector2 target, out RaycastHit hit, int mask = -5, QueryTriggerInteraction triggers = QueryTriggerInteraction.UseGlobal) => position.Expand().HasSight(target.Expand(), out hit, mask, triggers);
        
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
        public static bool HasSight(this Vector2 position, Vector2 target, out RaycastHit hit, float radius, int mask = -5, QueryTriggerInteraction triggers = QueryTriggerInteraction.UseGlobal) => position.Expand().HasSight(target.Expand(), out hit, radius, mask, triggers);
        
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
            
            Vector3 direction = target.Direction3(position);
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
    }
}