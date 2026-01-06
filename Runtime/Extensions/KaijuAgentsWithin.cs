using System.Diagnostics.CodeAnalysis;
using UnityEngine;

namespace KaijuSolutions.Agents.Extensions
{
    /// <summary>
    /// Extension methods to see if points are within a given distance of each other along the X and Z axes. These methods are inclusive of the distance to check. All three-dimensional vectors will be flattened via methods in <see cref="KaijuAgentsFlatten"/>.
    /// </summary>
    public static class KaijuAgentsWithin
    {
        /// <summary>
        /// If this is within a distance to another position.
        /// </summary>
        /// <param name="self">This position.</param>
        /// <param name="other">The other position.</param>
        /// <param name="distance">The distance.</param>
        /// <returns>If this is within a distance to another position.</returns>
        public static bool Within(this Vector2 self, Vector2 other, float distance) => self.Distance(other) <= distance;
        
        /// <summary>
        /// If this is within a distance to another position.
        /// </summary>
        /// <param name="self">This position.</param>
        /// <param name="other">The other position.</param>
        /// <param name="distance">The distance.</param>
        /// <returns>If this is within a distance to another position.</returns>
        public static bool Within(this Vector2 self, Vector3 other, float distance) => self.Within(other.Flatten(), distance);
        
        /// <summary>
        /// If this is within a distance to another position.
        /// </summary>
        /// <param name="self">This position.</param>
        /// <param name="other">The other position.</param>
        /// <param name="distance">The distance.</param>
        /// <returns>If this is within a distance to another position.</returns>
        public static bool Within(this Vector2 self, [NotNull] Transform other, float distance) => self.Within(other.position, distance);
        
        /// <summary>
        /// If this is within a distance to another position.
        /// </summary>
        /// <param name="self">This position.</param>
        /// <param name="other">The other position.</param>
        /// <param name="distance">The distance.</param>
        /// <returns>If this is within a distance to another position.</returns>
        public static bool Within(this Vector2 self, [NotNull] Component other, float distance) => self.Within(other.transform.position, distance);
        
        /// <summary>
        /// If this is within a distance to another position.
        /// </summary>
        /// <param name="self">This position.</param>
        /// <param name="other">The other position.</param>
        /// <param name="distance">The distance.</param>
        /// <returns>If this is within a distance to another position.</returns>
        public static bool Within(this Vector2 self, [NotNull] GameObject other, float distance) => self.Within(other.transform.position, distance);
        
        /// <summary>
        /// If this is within a distance to another position.
        /// </summary>
        /// <param name="self">This position.</param>
        /// <param name="other">The other position.</param>
        /// <param name="distance">The distance.</param>
        /// <returns>If this is within a distance to another position.</returns>
        public static bool Within(this Vector3 self, Vector2 other, float distance) => other.Within(self, distance);
        
        /// <summary>
        /// If this is within a distance to another position.
        /// </summary>
        /// <param name="self">This position.</param>
        /// <param name="other">The other position.</param>
        /// <param name="distance">The distance.</param>
        /// <returns>If this is within a distance to another position.</returns>
        public static bool Within(this Vector3 self, Vector3 other, float distance) => self.Flatten().Within(other.Flatten(), distance);
        
        /// <summary>
        /// If this is within a distance to another position.
        /// </summary>
        /// <param name="self">This position.</param>
        /// <param name="other">The other position.</param>
        /// <param name="distance">The distance.</param>
        /// <returns>If this is within a distance to another position.</returns>
        public static bool Within(this Vector3 self, [NotNull] Transform other, float distance) => self.Within(other.position, distance);
        
        /// <summary>
        /// If this is within a distance to another position.
        /// </summary>
        /// <param name="self">This position.</param>
        /// <param name="other">The other position.</param>
        /// <param name="distance">The distance.</param>
        /// <returns>If this is within a distance to another position.</returns>
        public static bool Within(this Vector3 self, [NotNull] Component other, float distance) => self.Within(other.transform.position, distance);
        
        /// <summary>
        /// If this is within a distance to another position.
        /// </summary>
        /// <param name="self">This position.</param>
        /// <param name="other">The other position.</param>
        /// <param name="distance">The distance.</param>
        /// <returns>If this is within a distance to another position.</returns>
        public static bool Within(this Vector3 self, [NotNull] GameObject other, float distance) => self.Within(other.transform.position, distance);
        
        /// <summary>
        /// If this is within a distance to another position.
        /// </summary>
        /// <param name="self">This position.</param>
        /// <param name="other">The other position.</param>
        /// <param name="distance">The distance.</param>
        /// <returns>If this is within a distance to another position.</returns>
        public static bool Within([NotNull] this Transform self, Vector2 other, float distance) => self.Flatten().Within(other, distance);
        
        /// <summary>
        /// If this is within a distance to another position.
        /// </summary>
        /// <param name="self">This position.</param>
        /// <param name="other">The other position.</param>
        /// <param name="distance">The distance.</param>
        /// <returns>If this is within a distance to another position.</returns>
        public static bool Within([NotNull] this Transform self, Vector3 other, float distance) => self.Flatten().Within(other.Flatten(), distance);
        
        /// <summary>
        /// If this is within a distance to another position.
        /// </summary>
        /// <param name="self">This position.</param>
        /// <param name="other">The other position.</param>
        /// <param name="distance">The distance.</param>
        /// <returns>If this is within a distance to another position.</returns>
        public static bool Within([NotNull] this Transform self, [NotNull] Transform other, float distance) => self.Flatten().Within(other.position, distance);
        
        /// <summary>
        /// If this is within a distance to another position.
        /// </summary>
        /// <param name="self">This position.</param>
        /// <param name="other">The other position.</param>
        /// <param name="distance">The distance.</param>
        /// <returns>If this is within a distance to another position.</returns>
        public static bool Within([NotNull] this Transform self, [NotNull] Component other, float distance) => self.Flatten().Within(other.transform.position, distance);
        
        /// <summary>
        /// If this is within a distance to another position.
        /// </summary>
        /// <param name="self">This position.</param>
        /// <param name="other">The other position.</param>
        /// <param name="distance">The distance.</param>
        /// <returns>If this is within a distance to another position.</returns>
        public static bool Within([NotNull] this Transform self, [NotNull] GameObject other, float distance) => self.Flatten().Within(other.transform.position, distance);
        
        /// <summary>
        /// If this is within a distance to another position.
        /// </summary>
        /// <param name="self">This position.</param>
        /// <param name="other">The other position.</param>
        /// <param name="distance">The distance.</param>
        /// <returns>If this is within a distance to another position.</returns>
        public static bool Within([NotNull] this Component self, Vector2 other, float distance) => self.Flatten().Within(other, distance);
        
        /// <summary>
        /// If this is within a distance to another position.
        /// </summary>
        /// <param name="self">This position.</param>
        /// <param name="other">The other position.</param>
        /// <param name="distance">The distance.</param>
        /// <returns>If this is within a distance to another position.</returns>
        public static bool Within([NotNull] this Component self, Vector3 other, float distance) => self.Flatten().Within(other.Flatten(), distance);
        
        /// <summary>
        /// If this is within a distance to another position.
        /// </summary>
        /// <param name="self">This position.</param>
        /// <param name="other">The other position.</param>
        /// <param name="distance">The distance.</param>
        /// <returns>If this is within a distance to another position.</returns>
        public static bool Within([NotNull] this Component self, [NotNull] Transform other, float distance) => self.Flatten().Within(other.position, distance);
        
        /// <summary>
        /// If this is within a distance to another position.
        /// </summary>
        /// <param name="self">This position.</param>
        /// <param name="other">The other position.</param>
        /// <param name="distance">The distance.</param>
        /// <returns>If this is within a distance to another position.</returns>
        public static bool Within([NotNull] this Component self, [NotNull] Component other, float distance) => self.Flatten().Within(other.transform.position, distance);
        
        /// <summary>
        /// If this is within a distance to another position.
        /// </summary>
        /// <param name="self">This position.</param>
        /// <param name="other">The other position.</param>
        /// <param name="distance">The distance.</param>
        /// <returns>If this is within a distance to another position.</returns>
        public static bool Within([NotNull] this Component self, [NotNull] GameObject other, float distance) => self.Flatten().Within(other.transform.position, distance);
        
        /// <summary>
        /// If this is within a distance to another position.
        /// </summary>
        /// <param name="self">This position.</param>
        /// <param name="other">The other position.</param>
        /// <param name="distance">The distance.</param>
        /// <returns>If this is within a distance to another position.</returns>
        public static bool Within([NotNull] this GameObject self, Vector2 other, float distance) => self.Flatten().Within(other, distance);
        
        /// <summary>
        /// If this is within a distance to another position.
        /// </summary>
        /// <param name="self">This position.</param>
        /// <param name="other">The other position.</param>
        /// <param name="distance">The distance.</param>
        /// <returns>If this is within a distance to another position.</returns>
        public static bool Within([NotNull] this GameObject self, Vector3 other, float distance) => self.Flatten().Within(other.Flatten(), distance);
        
        /// <summary>
        /// If this is within a distance to another position.
        /// </summary>
        /// <param name="self">This position.</param>
        /// <param name="other">The other position.</param>
        /// <param name="distance">The distance.</param>
        /// <returns>If this is within a distance to another position.</returns>
        public static bool Within([NotNull] this GameObject self, [NotNull] Transform other, float distance) => self.Flatten().Within(other.position, distance);
        
        /// <summary>
        /// If this is within a distance to another position.
        /// </summary>
        /// <param name="self">This position.</param>
        /// <param name="other">The other position.</param>
        /// <param name="distance">The distance.</param>
        /// <returns>If this is within a distance to another position.</returns>
        public static bool Within([NotNull] this GameObject self, [NotNull] Component other, float distance) => self.Flatten().Within(other.transform.position, distance);
        
        /// <summary>
        /// If this is within a distance to another position.
        /// </summary>
        /// <param name="self">This position.</param>
        /// <param name="other">The other position.</param>
        /// <param name="distance">The distance.</param>
        /// <returns>If this is within a distance to another position.</returns>
        public static bool Within([NotNull] this GameObject self, [NotNull] GameObject other, float distance) => self.Flatten().Within(other.transform.position, distance);
    }
}