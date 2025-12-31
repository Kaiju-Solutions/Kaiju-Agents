using System.Diagnostics.CodeAnalysis;
using UnityEngine;

namespace KaijuSolutions.Agents.Extension
{
    /// <summary>
    /// Extension methods to see if points are within a given distance of each other along all three axes. These methods are inclusive of the distance to check. Any Vector2 values will be expanded via the <see cref="KaijuAgentsExpand.Expand"/> method.
    /// </summary>
    public static class KaijuAgentsWithin3
    {
        /// <summary>
        /// If this is within a distance to another position.
        /// </summary>
        /// <param name="self">This position.</param>
        /// <param name="other">The other position.</param>
        /// <param name="distance">The distance.</param>
        /// <returns>If this is within a distance to another position.</returns>
        public static bool Within3(this Vector2 self, Vector3 other, float distance) => self.Expand().Within3(other, distance);
        
        /// <summary>
        /// If this is within a distance to another position.
        /// </summary>
        /// <param name="self">This position.</param>
        /// <param name="other">The other position.</param>
        /// <param name="distance">The distance.</param>
        /// <returns>If this is within a distance to another position.</returns>
        public static bool Within3(this Vector2 self, [NotNull] Transform other, float distance) => self.Expand().Within3(other, distance);
        
        /// <summary>
        /// If this is within a distance to another position.
        /// </summary>
        /// <param name="self">This position.</param>
        /// <param name="other">The other position.</param>
        /// <param name="distance">The distance.</param>
        /// <returns>If this is within a distance to another position.</returns>
        public static bool Within3(this Vector2 self, [NotNull] Component other, float distance) => self.Expand().Within3(other, distance);
        
        /// <summary>
        /// If this is within a distance to another position.
        /// </summary>
        /// <param name="self">This position.</param>
        /// <param name="other">The other position.</param>
        /// <param name="distance">The distance.</param>
        /// <returns>If this is within a distance to another position.</returns>
        public static bool Within3(this Vector2 self, [NotNull] GameObject other, float distance) => self.Expand().Within3(other, distance);
        
        /// <summary>
        /// If this is within a distance to another position.
        /// </summary>
        /// <param name="self">This position.</param>
        /// <param name="other">The other position.</param>
        /// <param name="distance">The distance.</param>
        /// <returns>If this is within a distance to another position.</returns>
        public static bool Within3(this Vector3 self, Vector2 other, float distance) => self.Within3(other.Expand(), distance);
        
        /// <summary>
        /// If this is within a distance to another position.
        /// </summary>
        /// <param name="self">This position.</param>
        /// <param name="other">The other position.</param>
        /// <param name="distance">The distance.</param>
        /// <returns>If this is within a distance to another position.</returns>
        public static bool Within3(this Vector3 self, Vector3 other, float distance) => self.Distance3(other) <= distance;
        
        /// <summary>
        /// If this is within a distance to another position.
        /// </summary>
        /// <param name="self">This position.</param>
        /// <param name="other">The other position.</param>
        /// <param name="distance">The distance.</param>
        /// <returns>If this is within a distance to another position.</returns>
        public static bool Within3(this Vector3 self, [NotNull] Transform other, float distance) => self.Within3(other.position, distance);
        
        /// <summary>
        /// If this is within a distance to another position.
        /// </summary>
        /// <param name="self">This position.</param>
        /// <param name="other">The other position.</param>
        /// <param name="distance">The distance.</param>
        /// <returns>If this is within a distance to another position.</returns>
        public static bool Within3(this Vector3 self, [NotNull] Component other, float distance) => self.Within3(other.transform.position, distance);
        
        /// <summary>
        /// If this is within a distance to another position.
        /// </summary>
        /// <param name="self">This position.</param>
        /// <param name="other">The other position.</param>
        /// <param name="distance">The distance.</param>
        /// <returns>If this is within a distance to another position.</returns>
        public static bool Within3(this Vector3 self, [NotNull] GameObject other, float distance) => self.Within3(other.transform.position, distance);
        
        /// <summary>
        /// If this is within a distance to another position.
        /// </summary>
        /// <param name="self">This position.</param>
        /// <param name="other">The other position.</param>
        /// <param name="distance">The distance.</param>
        /// <returns>If this is within a distance to another position.</returns>
        public static bool Within3([NotNull] this Transform self, Vector2 other, float distance) => self.position.Within3(other, distance);
        
        /// <summary>
        /// If this is within a distance to another position.
        /// </summary>
        /// <param name="self">This position.</param>
        /// <param name="other">The other position.</param>
        /// <param name="distance">The distance.</param>
        /// <returns>If this is within a distance to another position.</returns>
        public static bool Within3([NotNull] this Transform self, Vector3 other, float distance) => self.position.Within3(other, distance);
        
        /// <summary>
        /// If this is within a distance to another position.
        /// </summary>
        /// <param name="self">This position.</param>
        /// <param name="other">The other position.</param>
        /// <param name="distance">The distance.</param>
        /// <returns>If this is within a distance to another position.</returns>
        public static bool Within3([NotNull] this Transform self, [NotNull] Transform other, float distance) => self.position.Within3(other, distance);
        
        /// <summary>
        /// If this is within a distance to another position.
        /// </summary>
        /// <param name="self">This position.</param>
        /// <param name="other">The other position.</param>
        /// <param name="distance">The distance.</param>
        /// <returns>If this is within a distance to another position.</returns>
        public static bool Within3([NotNull] this Transform self, [NotNull] Component other, float distance) => self.position.Within3(other, distance);
        
        /// <summary>
        /// If this is within a distance to another position.
        /// </summary>
        /// <param name="self">This position.</param>
        /// <param name="other">The other position.</param>
        /// <param name="distance">The distance.</param>
        /// <returns>If this is within a distance to another position.</returns>
        public static bool Within3([NotNull] this Transform self, [NotNull] GameObject other, float distance) => self.position.Within3(other, distance);
        
        /// <summary>
        /// If this is within a distance to another position.
        /// </summary>
        /// <param name="self">This position.</param>
        /// <param name="other">The other position.</param>
        /// <param name="distance">The distance.</param>
        /// <returns>If this is within a distance to another position.</returns>
        public static bool Within3([NotNull] this Component self, Vector2 other, float distance) => self.transform.position.Within3(other, distance);
        
        /// <summary>
        /// If this is within a distance to another position.
        /// </summary>
        /// <param name="self">This position.</param>
        /// <param name="other">The other position.</param>
        /// <param name="distance">The distance.</param>
        /// <returns>If this is within a distance to another position.</returns>
        public static bool Within3([NotNull] this Component self, Vector3 other, float distance) => self.transform.position.Within3(other, distance);
        
        /// <summary>
        /// If this is within a distance to another position.
        /// </summary>
        /// <param name="self">This position.</param>
        /// <param name="other">The other position.</param>
        /// <param name="distance">The distance.</param>
        /// <returns>If this is within a distance to another position.</returns>
        public static bool Within3([NotNull] this Component self, [NotNull] Transform other, float distance) => self.transform.position.Within3(other, distance);
        
        /// <summary>
        /// If this is within a distance to another position.
        /// </summary>
        /// <param name="self">This position.</param>
        /// <param name="other">The other position.</param>
        /// <param name="distance">The distance.</param>
        /// <returns>If this is within a distance to another position.</returns>
        public static bool Within3([NotNull] this Component self, [NotNull] Component other, float distance) => self.transform.position.Within3(other, distance);
        
        /// <summary>
        /// If this is within a distance to another position.
        /// </summary>
        /// <param name="self">This position.</param>
        /// <param name="other">The other position.</param>
        /// <param name="distance">The distance.</param>
        /// <returns>If this is within a distance to another position.</returns>
        public static bool Within3([NotNull] this Component self, [NotNull] GameObject other, float distance) => self.transform.position.Within3(other, distance);
        
        /// <summary>
        /// If this is within a distance to another position.
        /// </summary>
        /// <param name="self">This position.</param>
        /// <param name="other">The other position.</param>
        /// <param name="distance">The distance.</param>
        /// <returns>If this is within a distance to another position.</returns>
        public static bool Within3([NotNull] this GameObject self, Vector2 other, float distance) => self.transform.position.Within3(other, distance);
        
        /// <summary>
        /// If this is within a distance to another position.
        /// </summary>
        /// <param name="self">This position.</param>
        /// <param name="other">The other position.</param>
        /// <param name="distance">The distance.</param>
        /// <returns>If this is within a distance to another position.</returns>
        public static bool Within3([NotNull] this GameObject self, Vector3 other, float distance) => self.transform.position.Within3(other, distance);
        
        /// <summary>
        /// If this is within a distance to another position.
        /// </summary>
        /// <param name="self">This position.</param>
        /// <param name="other">The other position.</param>
        /// <param name="distance">The distance.</param>
        /// <returns>If this is within a distance to another position.</returns>
        public static bool Within3([NotNull] this GameObject self, [NotNull] Transform other, float distance) => self.transform.position.Within3(other, distance);
        
        /// <summary>
        /// If this is within a distance to another position.
        /// </summary>
        /// <param name="self">This position.</param>
        /// <param name="other">The other position.</param>
        /// <param name="distance">The distance.</param>
        /// <returns>If this is within a distance to another position.</returns>
        public static bool Within3([NotNull] this GameObject self, [NotNull] Component other, float distance) => self.transform.position.Within3(other, distance);
        
        /// <summary>
        /// If this is within a distance to another position.
        /// </summary>
        /// <param name="self">This position.</param>
        /// <param name="other">The other position.</param>
        /// <param name="distance">The distance.</param>
        /// <returns>If this is within a distance to another position.</returns>
        public static bool Within3([NotNull] this GameObject self, [NotNull] GameObject other, float distance) => self.transform.position.Within3(other, distance);
    }
}