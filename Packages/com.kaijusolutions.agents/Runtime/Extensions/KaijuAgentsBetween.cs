using System.Diagnostics.CodeAnalysis;
using UnityEngine;

namespace KaijuSolutions.Agents.Extension
{
    /// <summary>
    /// Extension methods to see if points are between two given distances of each other along the X and Z axes. These methods are inclusive of the distances to check. All three-dimensional vectors will be flattened via methods in <see cref="KaijuAgentsFlatten"/>.
    /// </summary>
    public static class KaijuAgentsBetween
    {
        /// <summary>
        /// If this is between two distances to another position.
        /// </summary>
        /// <param name="self">This position.</param>
        /// <param name="other">The other position.</param>
        /// <param name="minimum">The minimum distance.</param>
        /// <param name="maximum">The maximum distance.</param>
        /// <returns>If this is between two distances to another position.</returns>
        public static bool Between(this Vector2 self, Vector2 other, float minimum, float maximum)
        {
            float distance = self.Distance(other);
            return distance >= minimum && distance <= maximum;
        }
        
        /// <summary>
        /// If this is between two distances to another position.
        /// </summary>
        /// <param name="self">This position.</param>
        /// <param name="other">The other position.</param>
        /// <param name="minimum">The minimum distance.</param>
        /// <param name="maximum">The maximum distance.</param>
        /// <returns>If this is between two distances to another position.</returns>
        public static bool Between(this Vector2 self, Vector3 other, float minimum, float maximum) => self.Between(other.Flatten(), minimum, maximum);
        
        /// <summary>
        /// If this is between two distances to another position.
        /// </summary>
        /// <param name="self">This position.</param>
        /// <param name="other">The other position.</param>
        /// <param name="minimum">The minimum distance.</param>
        /// <param name="maximum">The maximum distance.</param>
        /// <returns>If this is between two distances to another position.</returns>
        public static bool Between(this Vector2 self, [NotNull] Transform other, float minimum, float maximum) => self.Between(other.position, minimum, maximum);
        
        /// <summary>
        /// If this is between two distances to another position.
        /// </summary>
        /// <param name="self">This position.</param>
        /// <param name="other">The other position.</param>
        /// <param name="minimum">The minimum distance.</param>
        /// <param name="maximum">The maximum distance.</param>
        /// <returns>If this is between two distances to another position.</returns>
        public static bool Between(this Vector2 self, [NotNull] Component other, float minimum, float maximum) => self.Between(other.transform.position, minimum, maximum);
        
        /// <summary>
        /// If this is between two distances to another position.
        /// </summary>
        /// <param name="self">This position.</param>
        /// <param name="other">The other position.</param>
        /// <param name="minimum">The minimum distance.</param>
        /// <param name="maximum">The maximum distance.</param>
        /// <returns>If this is between two distances to another position.</returns>
        public static bool Between(this Vector2 self, [NotNull] GameObject other, float minimum, float maximum) => self.Between(other.transform.position, minimum, maximum);
        
        /// <summary>
        /// If this is between two distances to another position.
        /// </summary>
        /// <param name="self">This position.</param>
        /// <param name="other">The other position.</param>
        /// <param name="minimum">The minimum distance.</param>
        /// <param name="maximum">The maximum distance.</param>
        /// <returns>If this is between two distances to another position.</returns>
        public static bool Between(this Vector3 self, Vector2 other, float minimum, float maximum) => other.Between(self, minimum, maximum);
        
        /// <summary>
        /// If this is between two distances to another position.
        /// </summary>
        /// <param name="self">This position.</param>
        /// <param name="other">The other position.</param>
        /// <param name="minimum">The minimum distance.</param>
        /// <param name="maximum">The maximum distance.</param>
        /// <returns>If this is between two distances to another position.</returns>
        public static bool Between(this Vector3 self, Vector3 other, float minimum, float maximum) => self.Flatten().Between(other, minimum, maximum);
        
        /// <summary>
        /// If this is between two distances to another position.
        /// </summary>
        /// <param name="self">This position.</param>
        /// <param name="other">The other position.</param>
        /// <param name="minimum">The minimum distance.</param>
        /// <param name="maximum">The maximum distance.</param>
        /// <returns>If this is between two distances to another position.</returns>
        public static bool Between(this Vector3 self, [NotNull] Transform other, float minimum, float maximum) => self.Between(other.position, minimum, maximum);
        
        /// <summary>
        /// If this is between two distances to another position.
        /// </summary>
        /// <param name="self">This position.</param>
        /// <param name="other">The other position.</param>
        /// <param name="minimum">The minimum distance.</param>
        /// <param name="maximum">The maximum distance.</param>
        /// <returns>If this is between two distances to another position.</returns>
        public static bool Between(this Vector3 self, [NotNull] Component other, float minimum, float maximum) => self.Between(other.transform.position, minimum, maximum);
        
        /// <summary>
        /// If this is between two distances to another position.
        /// </summary>
        /// <param name="self">This position.</param>
        /// <param name="other">The other position.</param>
        /// <param name="minimum">The minimum distance.</param>
        /// <param name="maximum">The maximum distance.</param>
        /// <returns>If this is between two distances to another position.</returns>
        public static bool Between(this Vector3 self, [NotNull] GameObject other, float minimum, float maximum) => self.Between(other.transform.position, minimum, maximum);
        
        /// <summary>
        /// If this is between two distances to another position.
        /// </summary>
        /// <param name="self">This position.</param>
        /// <param name="other">The other position.</param>
        /// <param name="minimum">The minimum distance.</param>
        /// <param name="maximum">The maximum distance.</param>
        /// <returns>If this is between two distances to another position.</returns>
        public static bool Between([NotNull] this Transform self, Vector2 other, float minimum, float maximum) => other.Between(self.position, minimum, maximum);
        
        /// <summary>
        /// If this is between two distances to another position.
        /// </summary>
        /// <param name="self">This position.</param>
        /// <param name="other">The other position.</param>
        /// <param name="minimum">The minimum distance.</param>
        /// <param name="maximum">The maximum distance.</param>
        /// <returns>If this is between two distances to another position.</returns>
        public static bool Between([NotNull] this Transform self, Vector3 other, float minimum, float maximum) => self.position.Between(other, minimum, maximum);
        
        /// <summary>
        /// If this is between two distances to another position.
        /// </summary>
        /// <param name="self">This position.</param>
        /// <param name="other">The other position.</param>
        /// <param name="minimum">The minimum distance.</param>
        /// <param name="maximum">The maximum distance.</param>
        /// <returns>If this is between two distances to another position.</returns>
        public static bool Between([NotNull] this Transform self, [NotNull] Transform other, float minimum, float maximum) => self.position.Between(other.position, minimum, maximum);
        
        /// <summary>
        /// If this is between two distances to another position.
        /// </summary>
        /// <param name="self">This position.</param>
        /// <param name="other">The other position.</param>
        /// <param name="minimum">The minimum distance.</param>
        /// <param name="maximum">The maximum distance.</param>
        /// <returns>If this is between two distances to another position.</returns>
        public static bool Between([NotNull] this Transform self, [NotNull] Component other, float minimum, float maximum) => self.position.Between(other.transform.position, minimum, maximum);
        
        /// <summary>
        /// If this is between two distances to another position.
        /// </summary>
        /// <param name="self">This position.</param>
        /// <param name="other">The other position.</param>
        /// <param name="minimum">The minimum distance.</param>
        /// <param name="maximum">The maximum distance.</param>
        /// <returns>If this is between two distances to another position.</returns>
        public static bool Between([NotNull] this Transform self, [NotNull] GameObject other, float minimum, float maximum) => self.position.Between(other.transform.position, minimum, maximum);
        
        /// <summary>
        /// If this is between two distances to another position.
        /// </summary>
        /// <param name="self">This position.</param>
        /// <param name="other">The other position.</param>
        /// <param name="minimum">The minimum distance.</param>
        /// <param name="maximum">The maximum distance.</param>
        /// <returns>If this is between two distances to another position.</returns>
        public static bool Between([NotNull] this Component self, Vector2 other, float minimum, float maximum) => other.Between(self.transform.position, minimum, maximum);
        
        /// <summary>
        /// If this is between two distances to another position.
        /// </summary>
        /// <param name="self">This position.</param>
        /// <param name="other">The other position.</param>
        /// <param name="minimum">The minimum distance.</param>
        /// <param name="maximum">The maximum distance.</param>
        /// <returns>If this is between two distances to another position.</returns>
        public static bool Between([NotNull] this Component self, Vector3 other, float minimum, float maximum) => self.transform.position.Between(other, minimum, maximum);
        
        /// <summary>
        /// If this is between two distances to another position.
        /// </summary>
        /// <param name="self">This position.</param>
        /// <param name="other">The other position.</param>
        /// <param name="minimum">The minimum distance.</param>
        /// <param name="maximum">The maximum distance.</param>
        /// <returns>If this is between two distances to another position.</returns>
        public static bool Between([NotNull] this Component self, [NotNull] Transform other, float minimum, float maximum) => self.transform.position.Between(other.position, minimum, maximum);
        
        /// <summary>
        /// If this is between two distances to another position.
        /// </summary>
        /// <param name="self">This position.</param>
        /// <param name="other">The other position.</param>
        /// <param name="minimum">The minimum distance.</param>
        /// <param name="maximum">The maximum distance.</param>
        /// <returns>If this is between two distances to another position.</returns>
        public static bool Between([NotNull] this Component self, [NotNull] Component other, float minimum, float maximum) => self.transform.position.Between(other.transform.position, minimum, maximum);
        
        /// <summary>
        /// If this is between two distances to another position.
        /// </summary>
        /// <param name="self">This position.</param>
        /// <param name="other">The other position.</param>
        /// <param name="minimum">The minimum distance.</param>
        /// <param name="maximum">The maximum distance.</param>
        /// <returns>If this is between two distances to another position.</returns>
        public static bool Between([NotNull] this Component self, [NotNull] GameObject other, float minimum, float maximum) => self.transform.position.Between(other.transform.position, minimum, maximum);
        
        /// <summary>
        /// If this is between two distances to another position.
        /// </summary>
        /// <param name="self">This position.</param>
        /// <param name="other">The other position.</param>
        /// <param name="minimum">The minimum distance.</param>
        /// <param name="maximum">The maximum distance.</param>
        /// <returns>If this is between two distances to another position.</returns>
        public static bool Between([NotNull] this GameObject self, Vector2 other, float minimum, float maximum) => other.Between(self.transform.position, minimum, maximum);
        
        /// <summary>
        /// If this is between two distances to another position.
        /// </summary>
        /// <param name="self">This position.</param>
        /// <param name="other">The other position.</param>
        /// <param name="minimum">The minimum distance.</param>
        /// <param name="maximum">The maximum distance.</param>
        /// <returns>If this is between two distances to another position.</returns>
        public static bool Between([NotNull] this GameObject self, Vector3 other, float minimum, float maximum) => self.transform.position.Between(other, minimum, maximum);
        
        /// <summary>
        /// If this is between two distances to another position.
        /// </summary>
        /// <param name="self">This position.</param>
        /// <param name="other">The other position.</param>
        /// <param name="minimum">The minimum distance.</param>
        /// <param name="maximum">The maximum distance.</param>
        /// <returns>If this is between two distances to another position.</returns>
        public static bool Between([NotNull] this GameObject self, [NotNull] Transform other, float minimum, float maximum) => self.transform.position.Between(other.position, minimum, maximum);
        
        /// <summary>
        /// If this is between two distances to another position.
        /// </summary>
        /// <param name="self">This position.</param>
        /// <param name="other">The other position.</param>
        /// <param name="minimum">The minimum distance.</param>
        /// <param name="maximum">The maximum distance.</param>
        /// <returns>If this is between two distances to another position.</returns>
        public static bool Between([NotNull] this GameObject self, [NotNull] Component other, float minimum, float maximum) => self.transform.position.Between(other.transform.position, minimum, maximum);
        
        /// <summary>
        /// If this is between two distances to another position.
        /// </summary>
        /// <param name="self">This position.</param>
        /// <param name="other">The other position.</param>
        /// <param name="minimum">The minimum distance.</param>
        /// <param name="maximum">The maximum distance.</param>
        /// <returns>If this is between two distances to another position.</returns>
        public static bool Between([NotNull] this GameObject self, [NotNull] GameObject other, float minimum, float maximum) => self.transform.position.Between(other.transform.position, minimum, maximum);
    }
}