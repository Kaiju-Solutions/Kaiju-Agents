using System.Diagnostics.CodeAnalysis;
using UnityEngine;

namespace KaijuSolutions.Agents.Extensions
{
    /// <summary>
    /// Extension methods to get the 2D distance across the X and Z axes. All three-dimensional vectors will be flattened via methods in <see cref="KaijuAgentsFlatten"/>.
    /// </summary>
    public static class KaijuAgentsDistance
    {
        /// <summary>
        /// Get the distance between this and another position.
        /// </summary>
        /// <param name="self">This position.</param>
        /// <param name="other">The other position.</param>
        /// <returns>The distance.</returns>
        public static float Distance(this Vector2 self, Vector2 other) => Vector2.Distance(self, other);
        
        /// <summary>
        /// Get the distance between this and another position.
        /// </summary>
        /// <param name="self">This position.</param>
        /// <param name="other">The other position.</param>
        /// <returns>The distance.</returns>
        public static float Distance(this Vector2 self, Vector3 other) => self.Distance(other.Flatten());
        
        /// <summary>
        /// Get the distance between this and another position.
        /// </summary>
        /// <param name="self">This position.</param>
        /// <param name="other">The other position.</param>
        /// <returns>The distance.</returns>
        public static float Distance(this Vector2 self, [NotNull] Transform other) => self.Distance(other.position);
        
        /// <summary>
        /// Get the distance between this and another position.
        /// </summary>
        /// <param name="self">This position.</param>
        /// <param name="other">The other position.</param>
        /// <returns>The distance.</returns>
        public static float Distance(this Vector2 self, [NotNull] Component other) => self.Distance(other.transform);
        
        /// <summary>
        /// Get the distance between this and another position.
        /// </summary>
        /// <param name="self">This position.</param>
        /// <param name="other">The other position.</param>
        /// <returns>The distance.</returns>
        public static float Distance(this Vector2 self, [NotNull] GameObject other) => self.Distance(other.transform);
        
        /// <summary>
        /// Get the distance between this and another position.
        /// </summary>
        /// <param name="self">This position.</param>
        /// <param name="other">The other position.</param>
        /// <returns>The distance.</returns>
        public static float Distance(this Vector3 self, Vector2 other) => other.Distance(self);
        
        /// <summary>
        /// Get the distance between this and another position.
        /// </summary>
        /// <param name="self">This position.</param>
        /// <param name="other">The other position.</param>
        /// <returns>The distance.</returns>
        public static float Distance(this Vector3 self, Vector3 other) => self.Flatten().Distance(other);
        
        /// <summary>
        /// Get the distance between this and another position.
        /// </summary>
        /// <param name="self">This position.</param>
        /// <param name="other">The other position.</param>
        /// <returns>The distance.</returns>
        public static float Distance(this Vector3 self, [NotNull] Transform other) => self.Distance(other.position);
        
        /// <summary>
        /// Get the distance between this and another position.
        /// </summary>
        /// <param name="self">This position.</param>
        /// <param name="other">The other position.</param>
        /// <returns>The distance.</returns>
        public static float Distance(this Vector3 self, [NotNull] Component other) => self.Distance(other.transform.position);
        
        /// <summary>
        /// Get the distance between this and another position.
        /// </summary>
        /// <param name="self">This position.</param>
        /// <param name="other">The other position.</param>
        /// <returns>The distance.</returns>
        public static float Distance(this Vector3 self, [NotNull] GameObject other) => self.Distance(other.transform.position);
        
        /// <summary>
        /// Get the distance between this and another position.
        /// </summary>
        /// <param name="self">This object.</param>
        /// <param name="other">The other position.</param>
        /// <returns>The distance.</returns>
        public static float Distance([NotNull] this Transform self, Vector2 other) => self.position.Distance(other);
        
        /// <summary>
        /// Get the distance between this and another position.
        /// </summary>
        /// <param name="self">This object.</param>
        /// <param name="other">The other position.</param>
        /// <returns>The distance.</returns>
        public static float Distance([NotNull] this Transform self, Vector3 other) => self.position.Distance(other);
        
        /// <summary>
        /// Get the distance between this and another position.
        /// </summary>
        /// <param name="self">This object.</param>
        /// <param name="other">The other position.</param>
        /// <returns>The distance.</returns>
        public static float Distance([NotNull] this Transform self, [NotNull] Transform other) => self.position.Distance(other.position);
        
        /// <summary>
        /// Get the distance between this and another position.
        /// </summary>
        /// <param name="self">This object.</param>
        /// <param name="other">The other position.</param>
        /// <returns>The distance.</returns>
        public static float Distance([NotNull] this Transform self, [NotNull] Component other) => self.position.Distance(other.transform.position);
        
        /// <summary>
        /// Get the distance between this and another position.
        /// </summary>
        /// <param name="self">This object.</param>
        /// <param name="other">The other position.</param>
        /// <returns>The distance.</returns>
        public static float Distance([NotNull] this Transform self, [NotNull] GameObject other) => self.position.Distance(other.transform.position);
        
        /// <summary>
        /// Get the distance between this and another position.
        /// </summary>
        /// <param name="self">This object.</param>
        /// <param name="other">The other position.</param>
        /// <returns>The distance.</returns>
        public static float Distance([NotNull] this Component self, Vector2 other) => self.transform.position.Distance(other);
        
        /// <summary>
        /// Get the distance between this and another position.
        /// </summary>
        /// <param name="self">This object.</param>
        /// <param name="other">The other position.</param>
        /// <returns>The distance.</returns>
        public static float Distance([NotNull] this Component self, Vector3 other) => self.transform.position.Distance(other);
        
        /// <summary>
        /// Get the distance between this and another position.
        /// </summary>
        /// <param name="self">This object.</param>
        /// <param name="other">The other position.</param>
        /// <returns>The distance.</returns>
        public static float Distance([NotNull] this Component self, [NotNull] Transform other) => self.transform.position.Distance(other.position);
        
        /// <summary>
        /// Get the distance between this and another position.
        /// </summary>
        /// <param name="self">This object.</param>
        /// <param name="other">The other position.</param>
        /// <returns>The distance.</returns>
        public static float Distance([NotNull] this Component self, [NotNull] Component other) => self.transform.position.Distance(other.transform.position);
        
        /// <summary>
        /// Get the distance between this and another position.
        /// </summary>
        /// <param name="self">This object.</param>
        /// <param name="other">The other position.</param>
        /// <returns>The distance.</returns>
        public static float Distance([NotNull] this Component self, [NotNull] GameObject other) => self.transform.position.Distance(other.transform.position);
        
        /// <summary>
        /// Get the distance between this and another position.
        /// </summary>
        /// <param name="self">This object.</param>
        /// <param name="other">The other position.</param>
        /// <returns>The distance.</returns>
        public static float Distance([NotNull] this GameObject self, Vector2 other) =>  self.transform.position.Distance(other);
        
        /// <summary>
        /// Get the distance between this and another position.
        /// </summary>
        /// <param name="self">This object.</param>
        /// <param name="other">The other position.</param>
        /// <returns>The distance.</returns>
        public static float Distance([NotNull] this GameObject self, [NotNull] Transform other) => self.transform.position.Distance(other.position);
        
        /// <summary>
        /// Get the distance between this and another position.
        /// </summary>
        /// <param name="self">This object.</param>
        /// <param name="other">The other position.</param>
        /// <returns>The distance.</returns>
        public static float Distance([NotNull] this GameObject self, Vector3 other) => self.transform.position.Distance(other);
        
        /// <summary>
        /// Get the distance between this and another position.
        /// </summary>
        /// <param name="self">This object.</param>
        /// <param name="other">The other position.</param>
        /// <returns>The distance.</returns>
        public static float Distance([NotNull] this GameObject self, [NotNull] Component other) => self.transform.position.Distance(other.transform.position);
        
        /// <summary>
        /// Get the distance between this and another position.
        /// </summary>
        /// <param name="self">This object.</param>
        /// <param name="other">The other position.</param>
        /// <returns>The distance.</returns>
        public static float Distance([NotNull] this GameObject self, [NotNull] GameObject other) => self.transform.position.Distance(other.transform.position);
    }
}