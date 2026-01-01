using System.Diagnostics.CodeAnalysis;
using UnityEngine;

namespace KaijuSolutions.Agents.Extensions
{
    /// <summary>
    /// Extension methods to see if points are between two given distances of each other along all three axes. These methods are inclusive of the distances to check. Any Vector2 values will be expanded via the <see cref="KaijuAgentsExpand.Expand"/> method.
    /// </summary>
    public static class KaijuAgentsBetween3
    {
        /// <summary>
        /// If this is between two distances to another position.
        /// </summary>
        /// <param name="self">This position.</param>
        /// <param name="other">The other position.</param>
        /// <param name="minimum">The minimum distance.</param>
        /// <param name="maximum">The maximum distance.</param>
        /// <returns>If this is between two distances to another position.</returns>
        public static bool Between3(this Vector2 self, Vector3 other, float minimum, float maximum) => self.Expand().Between3(other, minimum, maximum);
        
        /// <summary>
        /// If this is between two distances to another position.
        /// </summary>
        /// <param name="self">This position.</param>
        /// <param name="other">The other position.</param>
        /// <param name="minimum">The minimum distance.</param>
        /// <param name="maximum">The maximum distance.</param>
        /// <returns>If this is between two distances to another position.</returns>
        public static bool Between3(this Vector2 self, [NotNull] Transform other, float minimum, float maximum) => self.Expand().Between3(other, minimum, maximum);
        
        /// <summary>
        /// If this is between two distances to another position.
        /// </summary>
        /// <param name="self">This position.</param>
        /// <param name="other">The other position.</param>
        /// <param name="minimum">The minimum distance.</param>
        /// <param name="maximum">The maximum distance.</param>
        /// <returns>If this is between two distances to another position.</returns>
        public static bool Between3(this Vector2 self, [NotNull] Component other, float minimum, float maximum) => self.Expand().Between3(other, minimum, maximum);
        
        /// <summary>
        /// If this is between two distances to another position.
        /// </summary>
        /// <param name="self">This position.</param>
        /// <param name="other">The other position.</param>
        /// <param name="minimum">The minimum distance.</param>
        /// <param name="maximum">The maximum distance.</param>
        /// <returns>If this is between two distances to another position.</returns>
        public static bool Between3(this Vector2 self, [NotNull] GameObject other, float minimum, float maximum) => self.Expand().Between3(other, minimum, maximum);
        
        /// <summary>
        /// If this is between two distances to another position.
        /// </summary>
        /// <param name="self">This position.</param>
        /// <param name="other">The other position.</param>
        /// <param name="minimum">The minimum distance.</param>
        /// <param name="maximum">The maximum distance.</param>
        /// <returns>If this is between two distances to another position.</returns>
        public static bool Between3(this Vector3 self, Vector2 other, float minimum, float maximum) => self.Between3(other.Expand(), minimum, maximum);
        
        /// <summary>
        /// If this is between two distances to another position.
        /// </summary>
        /// <param name="self">This position.</param>
        /// <param name="other">The other position.</param>
        /// <param name="minimum">The minimum distance.</param>
        /// <param name="maximum">The maximum distance.</param>
        /// <returns>If this is between two distances to another position.</returns>
        public static bool Between3(this Vector3 self, Vector3 other, float minimum, float maximum)
        {
            float distance = self.Distance3(other);
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
        public static bool Between3(this Vector3 self, [NotNull] Transform other, float minimum, float maximum) => self.Between3(other.position, minimum, maximum);
        
        /// <summary>
        /// If this is between two distances to another position.
        /// </summary>
        /// <param name="self">This position.</param>
        /// <param name="other">The other position.</param>
        /// <param name="minimum">The minimum distance.</param>
        /// <param name="maximum">The maximum distance.</param>
        /// <returns>If this is between two distances to another position.</returns>
        public static bool Between3(this Vector3 self, [NotNull] Component other, float minimum, float maximum) => self.Between3(other.transform.position, minimum, maximum);
        
        /// <summary>
        /// If this is between two distances to another position.
        /// </summary>
        /// <param name="self">This position.</param>
        /// <param name="other">The other position.</param>
        /// <param name="minimum">The minimum distance.</param>
        /// <param name="maximum">The maximum distance.</param>
        /// <returns>If this is between two distances to another position.</returns>
        public static bool Between3(this Vector3 self, [NotNull] GameObject other, float minimum, float maximum) => self.Between3(other.transform.position, minimum, maximum);
        
        /// <summary>
        /// If this is between two distances to another position.
        /// </summary>
        /// <param name="self">This position.</param>
        /// <param name="other">The other position.</param>
        /// <param name="minimum">The minimum distance.</param>
        /// <param name="maximum">The maximum distance.</param>
        /// <returns>If this is between two distances to another position.</returns>
        public static bool Between3([NotNull] this Transform self, Vector2 other, float minimum, float maximum) => self.position.Between3(other, minimum, maximum);
        
        /// <summary>
        /// If this is between two distances to another position.
        /// </summary>
        /// <param name="self">This position.</param>
        /// <param name="other">The other position.</param>
        /// <param name="minimum">The minimum distance.</param>
        /// <param name="maximum">The maximum distance.</param>
        /// <returns>If this is between two distances to another position.</returns>
        public static bool Between3([NotNull] this Transform self, Vector3 other, float minimum, float maximum) => self.position.Between3(other, minimum, maximum);
        
        /// <summary>
        /// If this is between two distances to another position.
        /// </summary>
        /// <param name="self">This position.</param>
        /// <param name="other">The other position.</param>
        /// <param name="minimum">The minimum distance.</param>
        /// <param name="maximum">The maximum distance.</param>
        /// <returns>If this is between two distances to another position.</returns>
        public static bool Between3([NotNull] this Transform self, [NotNull] Transform other, float minimum, float maximum) => self.position.Between3(other.position, minimum, maximum);
        
        /// <summary>
        /// If this is between two distances to another position.
        /// </summary>
        /// <param name="self">This position.</param>
        /// <param name="other">The other position.</param>
        /// <param name="minimum">The minimum distance.</param>
        /// <param name="maximum">The maximum distance.</param>
        /// <returns>If this is between two distances to another position.</returns>
        public static bool Between3([NotNull] this Transform self, [NotNull] Component other, float minimum, float maximum) => self.position.Between3(other.transform.position, minimum, maximum);
        
        /// <summary>
        /// If this is between two distances to another position.
        /// </summary>
        /// <param name="self">This position.</param>
        /// <param name="other">The other position.</param>
        /// <param name="minimum">The minimum distance.</param>
        /// <param name="maximum">The maximum distance.</param>
        /// <returns>If this is between two distances to another position.</returns>
        public static bool Between3([NotNull] this Transform self, [NotNull] GameObject other, float minimum, float maximum) => self.position.Between3(other.transform.position, minimum, maximum);
        
        /// <summary>
        /// If this is between two distances to another position.
        /// </summary>
        /// <param name="self">This position.</param>
        /// <param name="other">The other position.</param>
        /// <param name="minimum">The minimum distance.</param>
        /// <param name="maximum">The maximum distance.</param>
        /// <returns>If this is between two distances to another position.</returns>
        public static bool Between3([NotNull] this Component self, Vector2 other, float minimum, float maximum) => self.transform.position.Between3(other, minimum, maximum);
        
        /// <summary>
        /// If this is between two distances to another position.
        /// </summary>
        /// <param name="self">This position.</param>
        /// <param name="other">The other position.</param>
        /// <param name="minimum">The minimum distance.</param>
        /// <param name="maximum">The maximum distance.</param>
        /// <returns>If this is between two distances to another position.</returns>
        public static bool Between3([NotNull] this Component self, Vector3 other, float minimum, float maximum) => self.transform.position.Between3(other, minimum, maximum);
        
        /// <summary>
        /// If this is between two distances to another position.
        /// </summary>
        /// <param name="self">This position.</param>
        /// <param name="other">The other position.</param>
        /// <param name="minimum">The minimum distance.</param>
        /// <param name="maximum">The maximum distance.</param>
        /// <returns>If this is between two distances to another position.</returns>
        public static bool Between3([NotNull] this Component self, [NotNull] Transform other, float minimum, float maximum) => self.transform.position.Between3(other.position, minimum, maximum);
        
        /// <summary>
        /// If this is between two distances to another position.
        /// </summary>
        /// <param name="self">This position.</param>
        /// <param name="other">The other position.</param>
        /// <param name="minimum">The minimum distance.</param>
        /// <param name="maximum">The maximum distance.</param>
        /// <returns>If this is between two distances to another position.</returns>
        public static bool Between3([NotNull] this Component self, [NotNull] Component other, float minimum, float maximum) => self.transform.position.Between3(other.transform.position, minimum, maximum);
        
        /// <summary>
        /// If this is between two distances to another position.
        /// </summary>
        /// <param name="self">This position.</param>
        /// <param name="other">The other position.</param>
        /// <param name="minimum">The minimum distance.</param>
        /// <param name="maximum">The maximum distance.</param>
        /// <returns>If this is between two distances to another position.</returns>
        public static bool Between3([NotNull] this Component self, [NotNull] GameObject other, float minimum, float maximum) => self.transform.position.Between3(other.transform.position, minimum, maximum);
        
        /// <summary>
        /// If this is between two distances to another position.
        /// </summary>
        /// <param name="self">This position.</param>
        /// <param name="other">The other position.</param>
        /// <param name="minimum">The minimum distance.</param>
        /// <param name="maximum">The maximum distance.</param>
        /// <returns>If this is between two distances to another position.</returns>
        public static bool Between3([NotNull] this GameObject self, Vector2 other, float minimum, float maximum) => self.transform.position.Between3(other, minimum, maximum);
        
        /// <summary>
        /// If this is between two distances to another position.
        /// </summary>
        /// <param name="self">This position.</param>
        /// <param name="other">The other position.</param>
        /// <param name="minimum">The minimum distance.</param>
        /// <param name="maximum">The maximum distance.</param>
        /// <returns>If this is between two distances to another position.</returns>
        public static bool Between3([NotNull] this GameObject self, Vector3 other, float minimum, float maximum) => self.transform.position.Between3(other, minimum, maximum);
        
        /// <summary>
        /// If this is between two distances to another position.
        /// </summary>
        /// <param name="self">This position.</param>
        /// <param name="other">The other position.</param>
        /// <param name="minimum">The minimum distance.</param>
        /// <param name="maximum">The maximum distance.</param>
        /// <returns>If this is between two distances to another position.</returns>
        public static bool Between3([NotNull] this GameObject self, [NotNull] Transform other, float minimum, float maximum) => self.transform.position.Between3(other.position, minimum, maximum);
        
        /// <summary>
        /// If this is between two distances to another position.
        /// </summary>
        /// <param name="self">This position.</param>
        /// <param name="other">The other position.</param>
        /// <param name="minimum">The minimum distance.</param>
        /// <param name="maximum">The maximum distance.</param>
        /// <returns>If this is between two distances to another position.</returns>
        public static bool Between3([NotNull] this GameObject self, [NotNull] Component other, float minimum, float maximum) => self.transform.position.Between3(other.transform.position, minimum, maximum);
        
        /// <summary>
        /// If this is between two distances to another position.
        /// </summary>
        /// <param name="self">This position.</param>
        /// <param name="other">The other position.</param>
        /// <param name="minimum">The minimum distance.</param>
        /// <param name="maximum">The maximum distance.</param>
        /// <returns>If this is between two distances to another position.</returns>
        public static bool Between3([NotNull] this GameObject self, [NotNull] GameObject other, float minimum, float maximum) => self.transform.position.Between3(other.transform.position, minimum, maximum);
    }
}