using System.Diagnostics.CodeAnalysis;
using UnityEngine;

namespace KaijuSolutions.Agents.Extensions
{
    /// <summary>
    /// Extension methods distance across all three axes. Any Vector2 values will be expanded via the <see cref="KaijuAgentsExpand.Expand"/> method.
    /// </summary>
    public static class KaijuAgentsDistance3
    {
        /// <summary>
        /// Get the distance between this and another position.
        /// </summary>
        /// <param name="self">This position.</param>
        /// <param name="other">The other position.</param>
        /// <returns>The distance.</returns>
        public static float Distance3(this Vector2 self, Vector3 other) => self.Expand().Distance3(other);
        
        /// <summary>
        /// Get the distance between this and another position.
        /// </summary>
        /// <param name="self">This position.</param>
        /// <param name="other">The other position.</param>
        /// <returns>The distance.</returns>
        public static float Distance3(this Vector2 self, [NotNull] Transform other) => self.Expand().Distance3(other);
        
        /// <summary>
        /// Get the distance between this and another position.
        /// </summary>
        /// <param name="self">This position.</param>
        /// <param name="other">The other position.</param>
        /// <returns>The distance.</returns>
        public static float Distance3(this Vector2 self, [NotNull] Component other) => self.Expand().Distance3(other);
        
        /// <summary>
        /// Get the distance between this and another position.
        /// </summary>
        /// <param name="self">This position.</param>
        /// <param name="other">The other position.</param>
        /// <returns>The distance.</returns>
        public static float Distance3(this Vector2 self, [NotNull] GameObject other) => self.Expand().Distance3(other);
        
        /// <summary>
        /// Get the distance between this and another position.
        /// </summary>
        /// <param name="self">This position.</param>
        /// <param name="other">The other position.</param>
        /// <returns>The distance.</returns>
        public static float Distance3(this Vector3 self, Vector2 other) => Vector3.Distance(self, other.Expand());
        
        /// <summary>
        /// Get the distance between this and another position.
        /// </summary>
        /// <param name="self">This position.</param>
        /// <param name="other">The other position.</param>
        /// <returns>The distance.</returns>
        public static float Distance3(this Vector3 self, Vector3 other) => Vector3.Distance(self, other);
        
        /// <summary>
        /// Get the distance between this and another position.
        /// </summary>
        /// <param name="self">This position.</param>
        /// <param name="other">The other position.</param>
        /// <returns>The distance.</returns>
        public static float Distance3(this Vector3 self, [NotNull] Transform other) => self.Distance3(other.position);
        
        /// <summary>
        /// Get the distance between this and another position.
        /// </summary>
        /// <param name="self">This position.</param>
        /// <param name="other">The other position.</param>
        /// <returns>The distance.</returns>
        public static float Distance3(this Vector3 self, [NotNull] Component other) => self.Distance3(other.transform.position);
        
        /// <summary>
        /// Get the distance between this and another position.
        /// </summary>
        /// <param name="self">This position.</param>
        /// <param name="other">The other position.</param>
        /// <returns>The distance.</returns>
        public static float Distance3(this Vector3 self, [NotNull] GameObject other) => self.Distance3(other.transform.position);
        
        /// <summary>
        /// Get the distance between this and another position.
        /// </summary>
        /// <param name="self">This object.</param>
        /// <param name="other">The other position.</param>
        /// <returns>The distance.</returns>
        public static float Distance3([NotNull] this Transform self, Vector2 other) => self.position.Distance3(other.Expand());
        
        /// <summary>
        /// Get the distance between this and another position.
        /// </summary>
        /// <param name="self">This object.</param>
        /// <param name="other">The other position.</param>
        /// <returns>The distance.</returns>
        public static float Distance3([NotNull] this Transform self, Vector3 other) => self.position.Distance3(other);
        
        /// <summary>
        /// Get the distance between this and another position.
        /// </summary>
        /// <param name="self">This object.</param>
        /// <param name="other">The other position.</param>
        /// <returns>The distance.</returns>
        public static float Distance3([NotNull] this Transform self, [NotNull] Transform other) => self.position.Distance3(other.position);
        
        /// <summary>
        /// Get the distance between this and another position.
        /// </summary>
        /// <param name="self">This object.</param>
        /// <param name="other">The other position.</param>
        /// <returns>The distance.</returns>
        public static float Distance3([NotNull] this Transform self, [NotNull] Component other) => self.position.Distance3(other.transform.position);
        
        /// <summary>
        /// Get the distance between this and another position.
        /// </summary>
        /// <param name="self">This object.</param>
        /// <param name="other">The other position.</param>
        /// <returns>The distance.</returns>
        public static float Distance3([NotNull] this Transform self, [NotNull] GameObject other) => self.position.Distance3(other.transform.position);
        
        /// <summary>
        /// Get the distance between this and another position.
        /// </summary>
        /// <param name="self">This object.</param>
        /// <param name="other">The other position.</param>
        /// <returns>The distance.</returns>
        public static float Distance3([NotNull] this Component self, Vector2 other) => self.transform.position.Distance3(other.Expand());
        
        /// <summary>
        /// Get the distance between this and another position.
        /// </summary>
        /// <param name="self">This object.</param>
        /// <param name="other">The other position.</param>
        /// <returns>The distance.</returns>
        public static float Distance3([NotNull] this Component self, Vector3 other) => self.transform.position.Distance3(other);
        
        /// <summary>
        /// Get the distance between this and another position.
        /// </summary>
        /// <param name="self">This object.</param>
        /// <param name="other">The other position.</param>
        /// <returns>The distance.</returns>
        public static float Distance3([NotNull] this Component self, [NotNull] Transform other) => self.transform.position.Distance3(other.position);
        
        /// <summary>
        /// Get the distance between this and another position.
        /// </summary>
        /// <param name="self">This object.</param>
        /// <param name="other">The other position.</param>
        /// <returns>The distance.</returns>
        public static float Distance3([NotNull] this Component self, [NotNull] Component other) => self.transform.position.Distance3(other.transform.position);
        
        /// <summary>
        /// Get the distance between this and another position.
        /// </summary>
        /// <param name="self">This object.</param>
        /// <param name="other">The other position.</param>
        /// <returns>The distance.</returns>
        public static float Distance3([NotNull] this Component self, [NotNull] GameObject other) => self.transform.position.Distance3(other.transform.position);
        
        /// <summary>
        /// Get the distance between this and another position.
        /// </summary>
        /// <param name="self">This object.</param>
        /// <param name="other">The other position.</param>
        /// <returns>The distance.</returns>
        public static float Distance3([NotNull] this GameObject self, Vector2 other) => self.transform.position.Distance3(other.Expand());
        
        /// <summary>
        /// Get the distance between this and another position.
        /// </summary>
        /// <param name="self">This object.</param>
        /// <param name="other">The other position.</param>
        /// <returns>The distance.</returns>
        public static float Distance3([NotNull] this GameObject self, [NotNull] Transform other) => self.transform.position.Distance3(other.position);
        
        /// <summary>
        /// Get the distance between this and another position.
        /// </summary>
        /// <param name="self">This object.</param>
        /// <param name="other">The other position.</param>
        /// <returns>The distance.</returns>
        public static float Distance3([NotNull] this GameObject self, Vector3 other) => self.transform.position.Distance3(other);
        
        /// <summary>
        /// Get the distance between this and another position.
        /// </summary>
        /// <param name="self">This object.</param>
        /// <param name="other">The other position.</param>
        /// <returns>The distance.</returns>
        public static float Distance3([NotNull] this GameObject self, [NotNull] Component other) => self.transform.position.Distance3(other.transform.position);
        
        /// <summary>
        /// Get the distance between this and another position.
        /// </summary>
        /// <param name="self">This object.</param>
        /// <param name="other">The other position.</param>
        /// <returns>The distance.</returns>
        public static float Distance3([NotNull] this GameObject self, [NotNull] GameObject other) => self.transform.position.Distance3(other.transform.position);
    }
}