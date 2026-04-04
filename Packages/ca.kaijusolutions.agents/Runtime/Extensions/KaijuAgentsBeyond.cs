using System.Diagnostics.CodeAnalysis;
using UnityEngine;

namespace KaijuSolutions.Agents.Extensions
{
    /// <summary>
    /// Extension methods to see if points are beyond a given distance of each other along the X and Z axes. These methods are inclusive of the distance to check. All three-dimensional vectors will be flattened via methods in <see cref="KaijuAgentsFlatten"/>.
    /// </summary>
    public static class KaijuAgentsBeyond
    {
        /// <summary>
        /// If this is beyond a distance to another position.
        /// </summary>
        /// <param name="self">This position.</param>
        /// <param name="other">The other position.</param>
        /// <param name="distance">The distance.</param>
        /// <returns>If this is beyond a distance to another position.</returns>
        public static bool Beyond(this Vector2 self, Vector2 other, float distance) => self.Distance(other) >= distance;
        
        /// <summary>
        /// If this is beyond a distance to another position.
        /// </summary>
        /// <param name="self">This position.</param>
        /// <param name="other">The other position.</param>
        /// <param name="distance">The distance.</param>
        /// <returns>If this is beyond a distance to another position.</returns>
        public static bool Beyond(this Vector2 self, Vector3 other, float distance) => self.Beyond(other.Flatten(), distance);
        
        /// <summary>
        /// If this is beyond a distance to another position.
        /// </summary>
        /// <param name="self">This position.</param>
        /// <param name="other">The other position.</param>
        /// <param name="distance">The distance.</param>
        /// <returns>If this is beyond a distance to another position.</returns>
        public static bool Beyond(this Vector2 self, [NotNull] Transform other, float distance) => self.Beyond(other.position, distance);
        
        /// <summary>
        /// If this is beyond a distance to another position.
        /// </summary>
        /// <param name="self">This position.</param>
        /// <param name="other">The other position.</param>
        /// <param name="distance">The distance.</param>
        /// <returns>If this is beyond a distance to another position.</returns>
        public static bool Beyond(this Vector2 self, [NotNull] Component other, float distance) => self.Beyond(other.transform.position, distance);
        
        /// <summary>
        /// If this is beyond a distance to another position.
        /// </summary>
        /// <param name="self">This position.</param>
        /// <param name="other">The other position.</param>
        /// <param name="distance">The distance.</param>
        /// <returns>If this is beyond a distance to another position.</returns>
        public static bool Beyond(this Vector2 self, [NotNull] GameObject other, float distance) => self.Beyond(other.transform.position, distance);
        
        /// <summary>
        /// If this is beyond a distance to another position.
        /// </summary>
        /// <param name="self">This position.</param>
        /// <param name="other">The other position.</param>
        /// <param name="distance">The distance.</param>
        /// <returns>If this is beyond a distance to another position.</returns>
        public static bool Beyond(this Vector3 self, Vector2 other, float distance) => other.Beyond(self, distance);
        
        /// <summary>
        /// If this is beyond a distance to another position.
        /// </summary>
        /// <param name="self">This position.</param>
        /// <param name="other">The other position.</param>
        /// <param name="distance">The distance.</param>
        /// <returns>If this is beyond a distance to another position.</returns>
        public static bool Beyond(this Vector3 self, Vector3 other, float distance) => self.Flatten().Beyond(other.Flatten(), distance);
        
        /// <summary>
        /// If this is beyond a distance to another position.
        /// </summary>
        /// <param name="self">This position.</param>
        /// <param name="other">The other position.</param>
        /// <param name="distance">The distance.</param>
        /// <returns>If this is beyond a distance to another position.</returns>
        public static bool Beyond(this Vector3 self, [NotNull] Transform other, float distance) => self.Beyond(other.position, distance);
        
        /// <summary>
        /// If this is beyond a distance to another position.
        /// </summary>
        /// <param name="self">This position.</param>
        /// <param name="other">The other position.</param>
        /// <param name="distance">The distance.</param>
        /// <returns>If this is beyond a distance to another position.</returns>
        public static bool Beyond(this Vector3 self, [NotNull] Component other, float distance) => self.Beyond(other.transform.position, distance);
        
        /// <summary>
        /// If this is beyond a distance to another position.
        /// </summary>
        /// <param name="self">This position.</param>
        /// <param name="other">The other position.</param>
        /// <param name="distance">The distance.</param>
        /// <returns>If this is beyond a distance to another position.</returns>
        public static bool Beyond(this Vector3 self, [NotNull] GameObject other, float distance) => self.Beyond(other.transform.position, distance);
        
        /// <summary>
        /// If this is beyond a distance to another position.
        /// </summary>
        /// <param name="self">This object.</param>
        /// <param name="other">The other position.</param>
        /// <param name="distance">The distance.</param>
        /// <returns>If this is beyond a distance to another position.</returns>
        public static bool Beyond([NotNull] this Transform self, Vector2 other, float distance) => other.Beyond(self.position, distance);
        
        /// <summary>
        /// If this is beyond a distance to another position.
        /// </summary>
        /// <param name="self">This object.</param>
        /// <param name="other">The other position.</param>
        /// <param name="distance">The distance.</param>
        /// <returns>If this is beyond a distance to another position.</returns>
        public static bool Beyond([NotNull] this Transform self, Vector3 other, float distance) => self.position.Beyond(other, distance);
        
        /// <summary>
        /// If this is beyond a distance to another position.
        /// </summary>
        /// <param name="self">This object.</param>
        /// <param name="other">The other position.</param>
        /// <param name="distance">The distance.</param>
        /// <returns>If this is beyond a distance to another position.</returns>
        public static bool Beyond([NotNull] this Transform self, [NotNull] Transform other, float distance) => self.position.Beyond(other.position, distance);
        
        /// <summary>
        /// If this is beyond a distance to another position.
        /// </summary>
        /// <param name="self">This object.</param>
        /// <param name="other">The other position.</param>
        /// <param name="distance">The distance.</param>
        /// <returns>If this is beyond a distance to another position.</returns>
        public static bool Beyond([NotNull] this Transform self, [NotNull] Component other, float distance) => self.position.Beyond(other.transform.position, distance);
        
        /// <summary>
        /// If this is beyond a distance to another position.
        /// </summary>
        /// <param name="self">This object.</param>
        /// <param name="other">The other position.</param>
        /// <param name="distance">The distance.</param>
        /// <returns>If this is beyond a distance to another position.</returns>
        public static bool Beyond([NotNull] this Transform self, [NotNull] GameObject other, float distance) => self.position.Beyond(other.transform.position, distance);
        
        /// <summary>
        /// If this is beyond a distance to another position.
        /// </summary>
        /// <param name="self">This object.</param>
        /// <param name="other">The other position.</param>
        /// <param name="distance">The distance.</param>
        /// <returns>If this is beyond a distance to another position.</returns>
        public static bool Beyond([NotNull] this Component self, Vector2 other, float distance) => other.Beyond(self.transform.position, distance);
        
        /// <summary>
        /// If this is beyond a distance to another position.
        /// </summary>
        /// <param name="self">This object.</param>
        /// <param name="other">The other position.</param>
        /// <param name="distance">The distance.</param>
        /// <returns>If this is beyond a distance to another position.</returns>
        public static bool Beyond([NotNull] this Component self, Vector3 other, float distance) => self.transform.position.Beyond(other, distance);
        
        /// <summary>
        /// If this is beyond a distance to another position.
        /// </summary>
        /// <param name="self">This object.</param>
        /// <param name="other">The other position.</param>
        /// <param name="distance">The distance.</param>
        /// <returns>If this is beyond a distance to another position.</returns>
        public static bool Beyond([NotNull] this Component self, [NotNull] Transform other, float distance) => self.transform.position.Beyond(other.position, distance);
        
        /// <summary>
        /// If this is beyond a distance to another position.
        /// </summary>
        /// <param name="self">This object.</param>
        /// <param name="other">The other position.</param>
        /// <param name="distance">The distance.</param>
        /// <returns>If this is beyond a distance to another position.</returns>
        public static bool Beyond([NotNull] this Component self, [NotNull] Component other, float distance) => self.transform.position.Beyond(other.transform.position, distance);
        
        /// <summary>
        /// If this is beyond a distance to another position.
        /// </summary>
        /// <param name="self">This object.</param>
        /// <param name="other">The other position.</param>
        /// <param name="distance">The distance.</param>
        /// <returns>If this is beyond a distance to another position.</returns>
        public static bool Beyond([NotNull] this Component self, [NotNull] GameObject other, float distance) => self.transform.position.Beyond(other.transform.position, distance);
        
        /// <summary>
        /// If this is beyond a distance to another position.
        /// </summary>
        /// <param name="self">This object.</param>
        /// <param name="other">The other position.</param>
        /// <param name="distance">The distance.</param>
        /// <returns>If this is beyond a distance to another position.</returns>
        public static bool Beyond([NotNull] this GameObject self, Vector2 other, float distance) => other.Beyond(self.transform.position, distance);
        
        /// <summary>
        /// If this is beyond a distance to another position.
        /// </summary>
        /// <param name="self">This object.</param>
        /// <param name="other">The other position.</param>
        /// <param name="distance">The distance.</param>
        /// <returns>If this is beyond a distance to another position.</returns>
        public static bool Beyond([NotNull] this GameObject self, Vector3 other, float distance) => self.transform.position.Beyond(other, distance);
        
        /// <summary>
        /// If this is beyond a distance to another position.
        /// </summary>
        /// <param name="self">This object.</param>
        /// <param name="other">The other position.</param>
        /// <param name="distance">The distance.</param>
        /// <returns>If this is beyond a distance to another position.</returns>
        public static bool Beyond([NotNull] this GameObject self, [NotNull] Transform other, float distance) => self.transform.position.Beyond(other.position, distance);
        
        /// <summary>
        /// If this is beyond a distance to another position.
        /// </summary>
        /// <param name="self">This object.</param>
        /// <param name="other">The other position.</param>
        /// <param name="distance">The distance.</param>
        /// <returns>If this is beyond a distance to another position.</returns>
        public static bool Beyond([NotNull] this GameObject self, [NotNull] Component other, float distance) => self.transform.position.Beyond(other.transform.position, distance);
        
        /// <summary>
        /// If this is beyond a distance to another position.
        /// </summary>
        /// <param name="self">This object.</param>
        /// <param name="other">The other position.</param>
        /// <param name="distance">The distance.</param>
        /// <returns>If this is beyond a distance to another position.</returns>
        public static bool Beyond([NotNull] this GameObject self, [NotNull] GameObject other, float distance) => self.transform.position.Beyond(other.transform.position, distance);
    }
}