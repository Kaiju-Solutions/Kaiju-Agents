using System.Diagnostics.CodeAnalysis;
using UnityEngine;

namespace KaijuSolutions.Agents.Extensions
{
    /// <summary>
    /// Extension methods to extract the point vectors from hits. These do not perform any actual casting. For casting, see <see cref="KaijuAgentsArcRaycast"/> and <see cref="KaijuAgentsArcSphereCast"/>. Any Vector2 values will be expanded via the <see cref="KaijuAgentsExpand.Expand"/> method.
    /// </summary>
    public static class KaijuAgentsExtractPoints
    {
        /// <summary>
        /// Extract the point vectors from hits. This does not perform any actual casting. For casting, see <see cref="KaijuAgentsArcRaycast"/> and <see cref="KaijuAgentsArcSphereCast"/>. This can be useful if your agent only needs position vectors or to help perform debugging.
        /// </summary>
        /// <param name="position">The starting position where the casting were performed.</param>
        /// <param name="direction">The central direction of the casting.</param>
        /// <param name="hits">The hits from casting.</param>
        /// <param name="positions">Will be updated to store the positions from the hits or otherwise the maximum extents for misses.</param>
        /// <param name="angle">The angle of the arc in degrees which was used for casting.</param>
        /// <param name="distance">The distance of the casts which were run.</param>
        public static void ExtractPoints(this Vector2 position, Vector2 direction, [NotNull] RaycastHit?[] hits, [NotNull] Vector3[] positions, float angle = 360f, float distance = float.MaxValue) => position.Expand().ExtractPoints(direction.Expand(), hits, positions, angle, distance);
        
        /// <summary>
        /// Extract the point vectors from hits. This does not perform any actual casting. For casting, see <see cref="KaijuAgentsArcRaycast"/> and <see cref="KaijuAgentsArcSphereCast"/>. This can be useful if your agent only needs position vectors or to help perform debugging.
        /// </summary>
        /// <param name="position">The starting position where the casting were performed.</param>
        /// <param name="direction">The central direction of the casting.</param>
        /// <param name="hits">The hits from casting.</param>
        /// <param name="positions">Will be updated to store the positions from the hits or otherwise the maximum extents for misses.</param>
        /// <param name="angle">The angle of the arc in degrees which was used for casting.</param>
        /// <param name="distance">The distance of the casts which were run.</param>
        public static void ExtractPoints(this Vector2 position, Vector3 direction, [NotNull] RaycastHit?[] hits, [NotNull] Vector3[] positions, float angle = 360f, float distance = float.MaxValue) => position.Expand().ExtractPoints(direction, hits, positions, angle, distance);
        
        /// <summary>
        /// Extract the point vectors from hits. This does not perform any actual casting. For casting, see <see cref="KaijuAgentsArcRaycast"/> and <see cref="KaijuAgentsArcSphereCast"/>. This can be useful if your agent only needs position vectors or to help perform debugging.
        /// </summary>
        /// <param name="position">The starting position where the casting were performed.</param>
        /// <param name="direction">The central direction of the casting.</param>
        /// <param name="hits">The hits from casting.</param>
        /// <param name="positions">Will be updated to store the positions from the hits or otherwise the maximum extents for misses.</param>
        /// <param name="angle">The angle of the arc in degrees which was used for casting.</param>
        /// <param name="distance">The distance of the casts which were run.</param>
        public static void ExtractPoints(this Vector2 position, [NotNull] Transform direction, [NotNull] RaycastHit?[] hits, [NotNull] Vector3[] positions, float angle = 360f, float distance = float.MaxValue) => position.Expand().ExtractPoints(direction.forward, hits, positions, angle, distance);
        
        /// <summary>
        /// Extract the point vectors from hits. This does not perform any actual casting. For casting, see <see cref="KaijuAgentsArcRaycast"/> and <see cref="KaijuAgentsArcSphereCast"/>. This can be useful if your agent only needs position vectors or to help perform debugging.
        /// </summary>
        /// <param name="position">The starting position where the casting were performed.</param>
        /// <param name="direction">The central direction of the casting.</param>
        /// <param name="hits">The hits from casting.</param>
        /// <param name="positions">Will be updated to store the positions from the hits or otherwise the maximum extents for misses.</param>
        /// <param name="angle">The angle of the arc in degrees which was used for casting.</param>
        /// <param name="distance">The distance of the casts which were run.</param>
        public static void ExtractPoints(this Vector2 position, [NotNull] Component direction, [NotNull] RaycastHit?[] hits, [NotNull] Vector3[] positions, float angle = 360f, float distance = float.MaxValue) => position.Expand().ExtractPoints(direction.transform.forward, hits, positions, angle, distance);
        
        /// <summary>
        /// Extract the point vectors from hits. This does not perform any actual casting. For casting, see <see cref="KaijuAgentsArcRaycast"/> and <see cref="KaijuAgentsArcSphereCast"/>. This can be useful if your agent only needs position vectors or to help perform debugging.
        /// </summary>
        /// <param name="position">The starting position where the casting were performed.</param>
        /// <param name="direction">The central direction of the casting.</param>
        /// <param name="hits">The hits from casting.</param>
        /// <param name="positions">Will be updated to store the positions from the hits or otherwise the maximum extents for misses.</param>
        /// <param name="angle">The angle of the arc in degrees which was used for casting.</param>
        /// <param name="distance">The distance of the casts which were run.</param>
        public static void ExtractPoints(this Vector2 position, [NotNull] GameObject direction, [NotNull] RaycastHit?[] hits, [NotNull] Vector3[] positions, float angle = 360f, float distance = float.MaxValue) => position.Expand().ExtractPoints(direction.transform.forward, hits, positions, angle, distance);
        
        /// <summary>
        /// Extract the point vectors from hits. This does not perform any actual casting. For casting, see <see cref="KaijuAgentsArcRaycast"/> and <see cref="KaijuAgentsArcSphereCast"/>. This can be useful if your agent only needs position vectors or to help perform debugging.
        /// </summary>
        /// <param name="position">The starting position where the casting were performed.</param>
        /// <param name="direction">The central direction of the casting.</param>
        /// <param name="hits">The hits from casting.</param>
        /// <param name="positions">Will be updated to store the positions from the hits or otherwise the maximum extents for misses.</param>
        /// <param name="angle">The angle of the arc in degrees which was used for casting.</param>
        /// <param name="distance">The distance of the casts which were run.</param>
        public static void ExtractPoints(this Vector3 position, Vector2 direction, [NotNull] RaycastHit?[] hits, [NotNull] Vector3[] positions, float angle = 360f, float distance = float.MaxValue) => position.ExtractPoints(direction.Expand(), hits, positions, angle, distance);
        
        /// <summary>
        /// Extract the point vectors from hits. This does not perform any actual casting. For casting, see <see cref="KaijuAgentsArcRaycast"/> and <see cref="KaijuAgentsArcSphereCast"/>. This can be useful if your agent only needs position vectors or to help perform debugging.
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
            
            // Calculate the angular step between each cast. We divide by the length less one to ensure the first and last casts align with the edges of the arc, unless it is a full circle to avoid any overlap.
            float step = angle / (angle >= 360f ? hits.Length : hits.Length - 1);
            
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
        /// Extract the point vectors from hits. This does not perform any actual casting. For casting, see <see cref="KaijuAgentsArcRaycast"/> and <see cref="KaijuAgentsArcSphereCast"/>. This can be useful if your agent only needs position vectors or to help perform debugging.
        /// </summary>
        /// <param name="position">The starting position where the casting were performed.</param>
        /// <param name="direction">The central direction of the casting.</param>
        /// <param name="hits">The hits from casting.</param>
        /// <param name="positions">Will be updated to store the positions from the hits or otherwise the maximum extents for misses.</param>
        /// <param name="angle">The angle of the arc in degrees which was used for casting.</param>
        /// <param name="distance">The distance of the casts which were run.</param>
        public static void ExtractPoints(this Vector3 position, [NotNull] Transform direction, [NotNull] RaycastHit?[] hits, [NotNull] Vector3[] positions, float angle = 360f, float distance = float.MaxValue) => position.ExtractPoints(direction.forward, hits, positions, angle, distance);
        
        /// <summary>
        /// Extract the point vectors from hits. This does not perform any actual casting. For casting, see <see cref="KaijuAgentsArcRaycast"/> and <see cref="KaijuAgentsArcSphereCast"/>. This can be useful if your agent only needs position vectors or to help perform debugging.
        /// </summary>
        /// <param name="position">The starting position where the casting were performed.</param>
        /// <param name="direction">The central direction of the casting.</param>
        /// <param name="hits">The hits from casting.</param>
        /// <param name="positions">Will be updated to store the positions from the hits or otherwise the maximum extents for misses.</param>
        /// <param name="angle">The angle of the arc in degrees which was used for casting.</param>
        /// <param name="distance">The distance of the casts which were run.</param>
        public static void ExtractPoints(this Vector3 position, [NotNull] Component direction, [NotNull] RaycastHit?[] hits, [NotNull] Vector3[] positions, float angle = 360f, float distance = float.MaxValue) => position.ExtractPoints(direction.transform.forward, hits, positions, angle, distance);
        
        /// <summary>
        /// Extract the point vectors from hits. This does not perform any actual casting. For casting, see <see cref="KaijuAgentsArcRaycast"/> and <see cref="KaijuAgentsArcSphereCast"/>. This can be useful if your agent only needs position vectors or to help perform debugging.
        /// </summary>
        /// <param name="position">The starting position where the casting were performed.</param>
        /// <param name="direction">The central direction of the casting.</param>
        /// <param name="hits">The hits from casting.</param>
        /// <param name="positions">Will be updated to store the positions from the hits or otherwise the maximum extents for misses.</param>
        /// <param name="angle">The angle of the arc in degrees which was used for casting.</param>
        /// <param name="distance">The distance of the casts which were run.</param>
        public static void ExtractPoints(this Vector3 position, [NotNull] GameObject direction, [NotNull] RaycastHit?[] hits, [NotNull] Vector3[] positions, float angle = 360f, float distance = float.MaxValue) => position.ExtractPoints(direction.transform.forward, hits, positions, angle, distance);
        
        /// <summary>
        /// Extract the point vectors from hits. This does not perform any actual casting. For casting, see <see cref="KaijuAgentsArcRaycast"/> and <see cref="KaijuAgentsArcSphereCast"/>. This can be useful if your agent only needs position vectors or to help perform debugging.
        /// </summary>
        /// <param name="position">The starting position where the casting were performed.</param>
        /// <param name="direction">The central direction of the casting.</param>
        /// <param name="hits">The hits from casting.</param>
        /// <param name="positions">Will be updated to store the positions from the hits or otherwise the maximum extents for misses.</param>
        /// <param name="angle">The angle of the arc in degrees which was used for casting.</param>
        /// <param name="distance">The distance of the casts which were run.</param>
        public static void ExtractPoints([NotNull] this Transform position, Vector2 direction, [NotNull] RaycastHit?[] hits, [NotNull] Vector3[] positions, float angle = 360f, float distance = float.MaxValue) => position.position.ExtractPoints(direction.Expand(), hits, positions, angle, distance);
        
        /// <summary>
        /// Extract the point vectors from hits. This does not perform any actual casting. For casting, see <see cref="KaijuAgentsArcRaycast"/> and <see cref="KaijuAgentsArcSphereCast"/>. This can be useful if your agent only needs position vectors or to help perform debugging.
        /// </summary>
        /// <param name="position">The starting position where the casting were performed.</param>
        /// <param name="direction">The central direction of the casting.</param>
        /// <param name="hits">The hits from casting.</param>
        /// <param name="positions">Will be updated to store the positions from the hits or otherwise the maximum extents for misses.</param>
        /// <param name="angle">The angle of the arc in degrees which was used for casting.</param>
        /// <param name="distance">The distance of the casts which were run.</param>
        public static void ExtractPoints([NotNull] this Transform position, Vector3 direction, [NotNull] RaycastHit?[] hits, [NotNull] Vector3[] positions, float angle = 360f, float distance = float.MaxValue) => position.position.ExtractPoints(direction, hits, positions, angle, distance);
        
        /// <summary>
        /// Extract the point vectors from hits. This does not perform any actual casting. For casting, see <see cref="KaijuAgentsArcRaycast"/> and <see cref="KaijuAgentsArcSphereCast"/>. This can be useful if your agent only needs position vectors or to help perform debugging.
        /// </summary>
        /// <param name="position">The starting position where the casting were performed.</param>
        /// <param name="direction">The central direction of the casting.</param>
        /// <param name="hits">The hits from casting.</param>
        /// <param name="positions">Will be updated to store the positions from the hits or otherwise the maximum extents for misses.</param>
        /// <param name="angle">The angle of the arc in degrees which was used for casting.</param>
        /// <param name="distance">The distance of the casts which were run.</param>
        public static void ExtractPoints([NotNull] this Transform position, [NotNull] Transform direction, [NotNull] RaycastHit?[] hits, [NotNull] Vector3[] positions, float angle = 360f, float distance = float.MaxValue) => position.position.ExtractPoints(direction.forward, hits, positions, angle, distance);
        
        /// <summary>
        /// Extract the point vectors from hits. This does not perform any actual casting. For casting, see <see cref="KaijuAgentsArcRaycast"/> and <see cref="KaijuAgentsArcSphereCast"/>. This can be useful if your agent only needs position vectors or to help perform debugging.
        /// </summary>
        /// <param name="position">The starting position where the casting were performed.</param>
        /// <param name="direction">The central direction of the casting.</param>
        /// <param name="hits">The hits from casting.</param>
        /// <param name="positions">Will be updated to store the positions from the hits or otherwise the maximum extents for misses.</param>
        /// <param name="angle">The angle of the arc in degrees which was used for casting.</param>
        /// <param name="distance">The distance of the casts which were run.</param>
        public static void ExtractPoints([NotNull] this Transform position, [NotNull] Component direction, [NotNull] RaycastHit?[] hits, [NotNull] Vector3[] positions, float angle = 360f, float distance = float.MaxValue) => position.position.ExtractPoints(direction.transform.forward, hits, positions, angle, distance);
        
        /// <summary>
        /// Extract the point vectors from hits. This does not perform any actual casting. For casting, see <see cref="KaijuAgentsArcRaycast"/> and <see cref="KaijuAgentsArcSphereCast"/>. This can be useful if your agent only needs position vectors or to help perform debugging.
        /// </summary>
        /// <param name="position">The starting position where the casting were performed.</param>
        /// <param name="direction">The central direction of the casting.</param>
        /// <param name="hits">The hits from casting.</param>
        /// <param name="positions">Will be updated to store the positions from the hits or otherwise the maximum extents for misses.</param>
        /// <param name="angle">The angle of the arc in degrees which was used for casting.</param>
        /// <param name="distance">The distance of the casts which were run.</param>
        public static void ExtractPoints([NotNull] this Transform position, [NotNull] GameObject direction, [NotNull] RaycastHit?[] hits, [NotNull] Vector3[] positions, float angle = 360f, float distance = float.MaxValue) => position.position.ExtractPoints(direction.transform.forward, hits, positions, angle, distance);
        
        /// <summary>
        /// Extract the point vectors from hits. This does not perform any actual casting. For casting, see <see cref="KaijuAgentsArcRaycast"/> and <see cref="KaijuAgentsArcSphereCast"/>. This can be useful if your agent only needs position vectors or to help perform debugging.
        /// </summary>
        /// <param name="position">The starting position where the casting were performed in its forward direction.</param>
        /// <param name="hits">The hits from casting.</param>
        /// <param name="positions">Will be updated to store the positions from the hits or otherwise the maximum extents for misses.</param>
        /// <param name="angle">The angle of the arc in degrees which was used for casting.</param>
        /// <param name="distance">The distance of the casts which were run.</param>
        public static void ExtractPoints([NotNull] this Transform position, [NotNull] RaycastHit?[] hits, [NotNull] Vector3[] positions, float angle = 360f, float distance = float.MaxValue) => position.position.ExtractPoints(position.forward, hits, positions, angle, distance);
        
        /// <summary>
        /// Extract the point vectors from hits. This does not perform any actual casting. For casting, see <see cref="KaijuAgentsArcRaycast"/> and <see cref="KaijuAgentsArcSphereCast"/>. This can be useful if your agent only needs position vectors or to help perform debugging.
        /// </summary>
        /// <param name="position">The starting position where the casting were performed.</param>
        /// <param name="direction">The central direction of the casting.</param>
        /// <param name="hits">The hits from casting.</param>
        /// <param name="positions">Will be updated to store the positions from the hits or otherwise the maximum extents for misses.</param>
        /// <param name="angle">The angle of the arc in degrees which was used for casting.</param>
        /// <param name="distance">The distance of the casts which were run.</param>
        public static void ExtractPoints([NotNull] this Component position, Vector2 direction, [NotNull] RaycastHit?[] hits, [NotNull] Vector3[] positions, float angle = 360f, float distance = float.MaxValue) => position.transform.position.ExtractPoints(direction.Expand(), hits, positions, angle, distance);
        
        /// <summary>
        /// Extract the point vectors from hits. This does not perform any actual casting. For casting, see <see cref="KaijuAgentsArcRaycast"/> and <see cref="KaijuAgentsArcSphereCast"/>. This can be useful if your agent only needs position vectors or to help perform debugging.
        /// </summary>
        /// <param name="position">The starting position where the casting were performed.</param>
        /// <param name="direction">The central direction of the casting.</param>
        /// <param name="hits">The hits from casting.</param>
        /// <param name="positions">Will be updated to store the positions from the hits or otherwise the maximum extents for misses.</param>
        /// <param name="angle">The angle of the arc in degrees which was used for casting.</param>
        /// <param name="distance">The distance of the casts which were run.</param>
        public static void ExtractPoints([NotNull] this Component position, Vector3 direction, [NotNull] RaycastHit?[] hits, [NotNull] Vector3[] positions, float angle = 360f, float distance = float.MaxValue) => position.transform.position.ExtractPoints(direction, hits, positions, angle, distance);
        
        /// <summary>
        /// Extract the point vectors from hits. This does not perform any actual casting. For casting, see <see cref="KaijuAgentsArcRaycast"/> and <see cref="KaijuAgentsArcSphereCast"/>. This can be useful if your agent only needs position vectors or to help perform debugging.
        /// </summary>
        /// <param name="position">The starting position where the casting were performed.</param>
        /// <param name="direction">The central direction of the casting.</param>
        /// <param name="hits">The hits from casting.</param>
        /// <param name="positions">Will be updated to store the positions from the hits or otherwise the maximum extents for misses.</param>
        /// <param name="angle">The angle of the arc in degrees which was used for casting.</param>
        /// <param name="distance">The distance of the casts which were run.</param>
        public static void ExtractPoints([NotNull] this Component position, [NotNull] Transform direction, [NotNull] RaycastHit?[] hits, [NotNull] Vector3[] positions, float angle = 360f, float distance = float.MaxValue) => position.transform.position.ExtractPoints(direction.forward, hits, positions, angle, distance);
        
        /// <summary>
        /// Extract the point vectors from hits. This does not perform any actual casting. For casting, see <see cref="KaijuAgentsArcRaycast"/> and <see cref="KaijuAgentsArcSphereCast"/>. This can be useful if your agent only needs position vectors or to help perform debugging.
        /// </summary>
        /// <param name="position">The starting position where the casting were performed.</param>
        /// <param name="direction">The central direction of the casting.</param>
        /// <param name="hits">The hits from casting.</param>
        /// <param name="positions">Will be updated to store the positions from the hits or otherwise the maximum extents for misses.</param>
        /// <param name="angle">The angle of the arc in degrees which was used for casting.</param>
        /// <param name="distance">The distance of the casts which were run.</param>
        public static void ExtractPoints([NotNull] this Component position, [NotNull] Component direction, [NotNull] RaycastHit?[] hits, [NotNull] Vector3[] positions, float angle = 360f, float distance = float.MaxValue) => position.transform.position.ExtractPoints(direction.transform.forward, hits, positions, angle, distance);
        
        /// <summary>
        /// Extract the point vectors from hits. This does not perform any actual casting. For casting, see <see cref="KaijuAgentsArcRaycast"/> and <see cref="KaijuAgentsArcSphereCast"/>. This can be useful if your agent only needs position vectors or to help perform debugging.
        /// </summary>
        /// <param name="position">The starting position where the casting were performed.</param>
        /// <param name="direction">The central direction of the casting.</param>
        /// <param name="hits">The hits from casting.</param>
        /// <param name="positions">Will be updated to store the positions from the hits or otherwise the maximum extents for misses.</param>
        /// <param name="angle">The angle of the arc in degrees which was used for casting.</param>
        /// <param name="distance">The distance of the casts which were run.</param>
        public static void ExtractPoints([NotNull] this Component position, [NotNull] GameObject direction, [NotNull] RaycastHit?[] hits, [NotNull] Vector3[] positions, float angle = 360f, float distance = float.MaxValue) => position.transform.position.ExtractPoints(direction.transform.forward, hits, positions, angle, distance);
        
        /// <summary>
        /// Extract the point vectors from hits. This does not perform any actual casting. For casting, see <see cref="KaijuAgentsArcRaycast"/> and <see cref="KaijuAgentsArcSphereCast"/>. This can be useful if your agent only needs position vectors or to help perform debugging.
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
        /// Extract the point vectors from hits. This does not perform any actual casting. For casting, see <see cref="KaijuAgentsArcRaycast"/> and <see cref="KaijuAgentsArcSphereCast"/>. This can be useful if your agent only needs position vectors or to help perform debugging.
        /// </summary>
        /// <param name="position">The starting position where the casting were performed.</param>
        /// <param name="direction">The central direction of the casting.</param>
        /// <param name="hits">The hits from casting.</param>
        /// <param name="positions">Will be updated to store the positions from the hits or otherwise the maximum extents for misses.</param>
        /// <param name="angle">The angle of the arc in degrees which was used for casting.</param>
        /// <param name="distance">The distance of the casts which were run.</param>
        public static void ExtractPoints([NotNull] this GameObject position, Vector2 direction, [NotNull] RaycastHit?[] hits, [NotNull] Vector3[] positions, float angle = 360f, float distance = float.MaxValue) => position.transform.position.ExtractPoints(direction.Expand(), hits, positions, angle, distance);
        
        /// <summary>
        /// Extract the point vectors from hits. This does not perform any actual casting. For casting, see <see cref="KaijuAgentsArcRaycast"/> and <see cref="KaijuAgentsArcSphereCast"/>. This can be useful if your agent only needs position vectors or to help perform debugging.
        /// </summary>
        /// <param name="position">The starting position where the casting were performed.</param>
        /// <param name="direction">The central direction of the casting.</param>
        /// <param name="hits">The hits from casting.</param>
        /// <param name="positions">Will be updated to store the positions from the hits or otherwise the maximum extents for misses.</param>
        /// <param name="angle">The angle of the arc in degrees which was used for casting.</param>
        /// <param name="distance">The distance of the casts which were run.</param>
        public static void ExtractPoints([NotNull] this GameObject position, Vector3 direction, [NotNull] RaycastHit?[] hits, [NotNull] Vector3[] positions, float angle = 360f, float distance = float.MaxValue) => position.transform.position.ExtractPoints(direction, hits, positions, angle, distance);
        
        /// <summary>
        /// Extract the point vectors from hits. This does not perform any actual casting. For casting, see <see cref="KaijuAgentsArcRaycast"/> and <see cref="KaijuAgentsArcSphereCast"/>. This can be useful if your agent only needs position vectors or to help perform debugging.
        /// </summary>
        /// <param name="position">The starting position where the casting were performed.</param>
        /// <param name="direction">The central direction of the casting.</param>
        /// <param name="hits">The hits from casting.</param>
        /// <param name="positions">Will be updated to store the positions from the hits or otherwise the maximum extents for misses.</param>
        /// <param name="angle">The angle of the arc in degrees which was used for casting.</param>
        /// <param name="distance">The distance of the casts which were run.</param>
        public static void ExtractPoints([NotNull] this GameObject position, [NotNull] Transform direction, [NotNull] RaycastHit?[] hits, [NotNull] Vector3[] positions, float angle = 360f, float distance = float.MaxValue) => position.transform.position.ExtractPoints(direction.forward, hits, positions, angle, distance);
        
        /// <summary>
        /// Extract the point vectors from hits. This does not perform any actual casting. For casting, see <see cref="KaijuAgentsArcRaycast"/> and <see cref="KaijuAgentsArcSphereCast"/>. This can be useful if your agent only needs position vectors or to help perform debugging.
        /// </summary>
        /// <param name="position">The starting position where the casting were performed.</param>
        /// <param name="direction">The central direction of the casting.</param>
        /// <param name="hits">The hits from casting.</param>
        /// <param name="positions">Will be updated to store the positions from the hits or otherwise the maximum extents for misses.</param>
        /// <param name="angle">The angle of the arc in degrees which was used for casting.</param>
        /// <param name="distance">The distance of the casts which were run.</param>
        public static void ExtractPoints([NotNull] this GameObject position, [NotNull] Component direction, [NotNull] RaycastHit?[] hits, [NotNull] Vector3[] positions, float angle = 360f, float distance = float.MaxValue) => position.transform.position.ExtractPoints(direction.transform.forward, hits, positions, angle, distance);
        
        /// <summary>
        /// Extract the point vectors from hits. This does not perform any actual casting. For casting, see <see cref="KaijuAgentsArcRaycast"/> and <see cref="KaijuAgentsArcSphereCast"/>. This can be useful if your agent only needs position vectors or to help perform debugging.
        /// </summary>
        /// <param name="position">The starting position where the casting were performed.</param>
        /// <param name="direction">The central direction of the casting.</param>
        /// <param name="hits">The hits from casting.</param>
        /// <param name="positions">Will be updated to store the positions from the hits or otherwise the maximum extents for misses.</param>
        /// <param name="angle">The angle of the arc in degrees which was used for casting.</param>
        /// <param name="distance">The distance of the casts which were run.</param>
        public static void ExtractPoints([NotNull] this GameObject position, [NotNull] GameObject direction, [NotNull] RaycastHit?[] hits, [NotNull] Vector3[] positions, float angle = 360f, float distance = float.MaxValue) => position.transform.position.ExtractPoints(direction.transform.forward, hits, positions, angle, distance);
        
        /// <summary>
        /// Extract the point vectors from hits. This does not perform any actual casting. For casting, see <see cref="KaijuAgentsArcRaycast"/> and <see cref="KaijuAgentsArcSphereCast"/>. This can be useful if your agent only needs position vectors or to help perform debugging.
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