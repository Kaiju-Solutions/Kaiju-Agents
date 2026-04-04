using System.Diagnostics.CodeAnalysis;
using KaijuSolutions.Agents.Movement;
using UnityEngine;

namespace KaijuSolutions.Agents.Extensions
{
    /// <summary>
    /// Extension methods to perform sphere casting along an arc. Any <see href="https://docs.unity3d.com/ScriptReference/Vector2.html">Vector2</see> values will be expanded via the <see cref="KaijuAgentsExpand.Expand"/> method.
    /// </summary>
    public static class KaijuAgentsArcSphereCast
    {
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
        public static int ArcSphereCast(this Vector2 position, Vector2 direction, float radius, [NotNull] RaycastHit?[] hits, float angle = 360f, float distance = float.MaxValue, int mask = KaijuMovementConfiguration.DefaultMask, QueryTriggerInteraction triggers = QueryTriggerInteraction.UseGlobal) => position.Expand().ArcSphereCast(direction.Expand(), radius, hits, angle, distance, mask, triggers);
        
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
        public static int ArcSphereCast(this Vector2 position, Vector3 direction, float radius, [NotNull] RaycastHit?[] hits, float angle = 360f, float distance = float.MaxValue, int mask = KaijuMovementConfiguration.DefaultMask, QueryTriggerInteraction triggers = QueryTriggerInteraction.UseGlobal) => position.Expand().ArcSphereCast(direction, radius, hits, angle, distance, mask, triggers);
        
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
        public static int ArcSphereCast(this Vector2 position, [NotNull] Transform direction, float radius, [NotNull] RaycastHit?[] hits, float angle = 360f, float distance = float.MaxValue, int mask = KaijuMovementConfiguration.DefaultMask, QueryTriggerInteraction triggers = QueryTriggerInteraction.UseGlobal) => position.Expand().ArcSphereCast(direction.forward, radius, hits, angle, distance, mask, triggers);
        
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
        public static int ArcSphereCast(this Vector2 position, [NotNull] Component direction, float radius, [NotNull] RaycastHit?[] hits, float angle = 360f, float distance = float.MaxValue, int mask = KaijuMovementConfiguration.DefaultMask, QueryTriggerInteraction triggers = QueryTriggerInteraction.UseGlobal) => position.Expand().ArcSphereCast(direction.transform.forward, radius, hits, angle, distance, mask, triggers);
        
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
        public static int ArcSphereCast(this Vector2 position, [NotNull] GameObject direction, float radius, [NotNull] RaycastHit?[] hits, float angle = 360f, float distance = float.MaxValue, int mask = KaijuMovementConfiguration.DefaultMask, QueryTriggerInteraction triggers = QueryTriggerInteraction.UseGlobal) => position.Expand().ArcSphereCast(direction.transform.forward, radius, hits, angle, distance, mask, triggers);
        
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
        public static int ArcSphereCast(this Vector3 position, Vector2 direction, float radius, [NotNull] RaycastHit?[] hits, float angle = 360f, float distance = float.MaxValue, int mask = KaijuMovementConfiguration.DefaultMask, QueryTriggerInteraction triggers = QueryTriggerInteraction.UseGlobal) => position.ArcSphereCast(direction.Expand(), radius, hits, angle, distance, mask, triggers);
        
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
        public static int ArcSphereCast(this Vector3 position, Vector3 direction, float radius, [NotNull] RaycastHit?[] hits, float angle = 360f, float distance = float.MaxValue, int mask = KaijuMovementConfiguration.DefaultMask, QueryTriggerInteraction triggers = QueryTriggerInteraction.UseGlobal)
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
            
            // Calculate the angular step between each cast. We divide by the length less one to ensure the first and last casts align with the edges of the arc, unless it is a full circle to avoid any overlap.
            float step = angle / (angle >= 360f ? hits.Length : hits.Length - 1);
            
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
        public static int ArcSphereCast(this Vector3 position, [NotNull] Transform direction, float radius, [NotNull] RaycastHit?[] hits, float angle = 360f, float distance = float.MaxValue, int mask = KaijuMovementConfiguration.DefaultMask, QueryTriggerInteraction triggers = QueryTriggerInteraction.UseGlobal) => position.ArcSphereCast(direction.forward, radius, hits, angle, distance, mask, triggers);
        
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
        public static int ArcSphereCast(this Vector3 position, [NotNull] Component direction, float radius, [NotNull] RaycastHit?[] hits, float angle = 360f, float distance = float.MaxValue, int mask = KaijuMovementConfiguration.DefaultMask, QueryTriggerInteraction triggers = QueryTriggerInteraction.UseGlobal) => position.ArcSphereCast(direction.transform.forward, radius, hits, angle, distance, mask, triggers);
        
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
        public static int ArcSphereCast(this Vector3 position, [NotNull] GameObject direction, float radius, [NotNull] RaycastHit?[] hits, float angle = 360f, float distance = float.MaxValue, int mask = KaijuMovementConfiguration.DefaultMask, QueryTriggerInteraction triggers = QueryTriggerInteraction.UseGlobal) => position.ArcSphereCast(direction.transform.forward, radius, hits, angle, distance, mask, triggers);
        
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
        public static int ArcSphereCast([NotNull] this Transform position, Vector2 direction, float radius, [NotNull] RaycastHit?[] hits, float angle = 360f, float distance = float.MaxValue, int mask = KaijuMovementConfiguration.DefaultMask, QueryTriggerInteraction triggers = QueryTriggerInteraction.UseGlobal) => position.position.ArcSphereCast(direction.Expand(), radius, hits, angle, distance, mask, triggers);
        
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
        public static int ArcSphereCast([NotNull] this Transform position, Vector3 direction, float radius, [NotNull] RaycastHit?[] hits, float angle = 360f, float distance = float.MaxValue, int mask = KaijuMovementConfiguration.DefaultMask, QueryTriggerInteraction triggers = QueryTriggerInteraction.UseGlobal) => position.position.ArcSphereCast(direction, radius, hits, angle, distance, mask, triggers);
        
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
        public static int ArcSphereCast([NotNull] this Transform position, [NotNull] Transform direction, float radius, [NotNull] RaycastHit?[] hits, float angle = 360f, float distance = float.MaxValue, int mask = KaijuMovementConfiguration.DefaultMask, QueryTriggerInteraction triggers = QueryTriggerInteraction.UseGlobal) => position.position.ArcSphereCast(direction.forward, radius, hits, angle, distance, mask, triggers);
        
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
        public static int ArcSphereCast([NotNull] this Transform position, [NotNull] Component direction, float radius, [NotNull] RaycastHit?[] hits, float angle = 360f, float distance = float.MaxValue, int mask = KaijuMovementConfiguration.DefaultMask, QueryTriggerInteraction triggers = QueryTriggerInteraction.UseGlobal) => position.position.ArcSphereCast(direction.transform.forward, radius, hits, angle, distance, mask, triggers);
        
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
        public static int ArcSphereCast([NotNull] this Transform position, [NotNull] GameObject direction, float radius, [NotNull] RaycastHit?[] hits, float angle = 360f, float distance = float.MaxValue, int mask = KaijuMovementConfiguration.DefaultMask, QueryTriggerInteraction triggers = QueryTriggerInteraction.UseGlobal) => position.position.ArcSphereCast(direction.transform.forward, radius, hits, angle, distance, mask, triggers);
        
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
        public static int ArcSphereCast([NotNull] this Transform position, float radius, [NotNull] RaycastHit?[] hits, float angle = 360f, float distance = float.MaxValue, int mask = KaijuMovementConfiguration.DefaultMask, QueryTriggerInteraction triggers = QueryTriggerInteraction.UseGlobal) => position.position.ArcSphereCast(position.forward, radius, hits, angle, distance, mask, triggers);
        
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
        public static int ArcSphereCast([NotNull] this Component position, Vector2 direction, float radius, [NotNull] RaycastHit?[] hits, float angle = 360f, float distance = float.MaxValue, int mask = KaijuMovementConfiguration.DefaultMask, QueryTriggerInteraction triggers = QueryTriggerInteraction.UseGlobal) => position.transform.position.ArcSphereCast(direction.Expand(), radius, hits, angle, distance, mask, triggers);
        
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
        public static int ArcSphereCast([NotNull] this Component position, Vector3 direction, float radius, [NotNull] RaycastHit?[] hits, float angle = 360f, float distance = float.MaxValue, int mask = KaijuMovementConfiguration.DefaultMask, QueryTriggerInteraction triggers = QueryTriggerInteraction.UseGlobal) => position.transform.position.ArcSphereCast(direction, radius, hits, angle, distance, mask, triggers);
        
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
        public static int ArcSphereCast([NotNull] this Component position, [NotNull] Transform direction, float radius, [NotNull] RaycastHit?[] hits, float angle = 360f, float distance = float.MaxValue, int mask = KaijuMovementConfiguration.DefaultMask, QueryTriggerInteraction triggers = QueryTriggerInteraction.UseGlobal) => position.transform.position.ArcSphereCast(direction.forward, radius, hits, angle, distance, mask, triggers);
        
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
        public static int ArcSphereCast([NotNull] this Component position, [NotNull] Component direction, float radius, [NotNull] RaycastHit?[] hits, float angle = 360f, float distance = float.MaxValue, int mask = KaijuMovementConfiguration.DefaultMask, QueryTriggerInteraction triggers = QueryTriggerInteraction.UseGlobal) => position.transform.position.ArcSphereCast(direction.transform.forward, radius, hits, angle, distance, mask, triggers);
        
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
        public static int ArcSphereCast([NotNull] this Component position, [NotNull] GameObject direction, float radius, [NotNull] RaycastHit?[] hits, float angle = 360f, float distance = float.MaxValue, int mask = KaijuMovementConfiguration.DefaultMask, QueryTriggerInteraction triggers = QueryTriggerInteraction.UseGlobal) => position.transform.position.ArcSphereCast(direction.transform.forward, radius, hits, angle, distance, mask, triggers);
        
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
        public static int ArcSphereCast([NotNull] this Component position, float radius, [NotNull] RaycastHit?[] hits, float angle = 360f, float distance = float.MaxValue, int mask = KaijuMovementConfiguration.DefaultMask, QueryTriggerInteraction triggers = QueryTriggerInteraction.UseGlobal)
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
        public static int ArcSphereCast([NotNull] this GameObject position, Vector2 direction, float radius, [NotNull] RaycastHit?[] hits, float angle = 360f, float distance = float.MaxValue, int mask = KaijuMovementConfiguration.DefaultMask, QueryTriggerInteraction triggers = QueryTriggerInteraction.UseGlobal) => position.transform.position.ArcSphereCast(direction.Expand(), radius, hits, angle, distance, mask, triggers);
        
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
        public static int ArcSphereCast([NotNull] this GameObject position, Vector3 direction, float radius, [NotNull] RaycastHit?[] hits, float angle = 360f, float distance = float.MaxValue, int mask = KaijuMovementConfiguration.DefaultMask, QueryTriggerInteraction triggers = QueryTriggerInteraction.UseGlobal) => position.transform.position.ArcSphereCast(direction, radius, hits, angle, distance, mask, triggers);
        
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
        public static int ArcSphereCast([NotNull] this GameObject position, [NotNull] Transform direction, float radius, [NotNull] RaycastHit?[] hits, float angle = 360f, float distance = float.MaxValue, int mask = KaijuMovementConfiguration.DefaultMask, QueryTriggerInteraction triggers = QueryTriggerInteraction.UseGlobal) => position.transform.position.ArcSphereCast(direction.forward, radius, hits, angle, distance, mask, triggers);
        
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
        public static int ArcSphereCast([NotNull] this GameObject position, [NotNull] Component direction, float radius, [NotNull] RaycastHit?[] hits, float angle = 360f, float distance = float.MaxValue, int mask = KaijuMovementConfiguration.DefaultMask, QueryTriggerInteraction triggers = QueryTriggerInteraction.UseGlobal) => position.transform.position.ArcSphereCast(direction.transform.forward, radius, hits, angle, distance, mask, triggers);
        
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
        public static int ArcSphereCast([NotNull] this GameObject position, [NotNull] GameObject direction, float radius, [NotNull] RaycastHit?[] hits, float angle = 360f, float distance = float.MaxValue, int mask = KaijuMovementConfiguration.DefaultMask, QueryTriggerInteraction triggers = QueryTriggerInteraction.UseGlobal) => position.transform.position.ArcSphereCast(direction.transform.forward, radius, hits, angle, distance, mask, triggers);
        
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
        public static int ArcSphereCast([NotNull] this GameObject position, float radius, [NotNull] RaycastHit?[] hits, float angle = 360f, float distance = float.MaxValue, int mask = KaijuMovementConfiguration.DefaultMask, QueryTriggerInteraction triggers = QueryTriggerInteraction.UseGlobal)
        {
            Transform t = position.transform;
            return t.position.ArcSphereCast(t.forward, radius, hits, angle, distance, mask, triggers);
        }
    }
}