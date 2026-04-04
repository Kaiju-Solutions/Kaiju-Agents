using System.Diagnostics.CodeAnalysis;
using UnityEngine;

namespace KaijuSolutions.Agents.Extensions
{
    /// <summary>
    /// Extension methods to get the direction along the X and Z axes from one position to another. All three-dimensional vectors will be flattened via methods in <see cref="KaijuAgentsFlatten"/>.
    /// </summary>
    public static class KaijuAgentsDirection
    {
        /// <summary>
        /// The direction from this position to another position.
        /// </summary>
        /// <param name="self">This position.</param>
        /// <param name="other">The other position.</param>
        /// <returns>The direction from this position to another position.</returns>
        public static Vector2 Direction(this Vector2 self, Vector2 other) => self - other;
        
        /// <summary>
        /// The direction from this position to another position.
        /// </summary>
        /// <param name="self">This position.</param>
        /// <param name="other">The other position.</param>
        /// <returns>The direction from this position to another position.</returns>
        public static Vector2 Direction(this Vector2 self, Vector3 other) => self.Direction(other.Flatten());
        
        /// <summary>
        /// The direction from this position to another position.
        /// </summary>
        /// <param name="self">This position.</param>
        /// <param name="other">The other position.</param>
        /// <returns>The direction from this position to another position.</returns>
        public static Vector2 Direction(this Vector2 self, [NotNull] Transform other) => self.Direction(other.position);
        
        /// <summary>
        /// The direction from this position to another position.
        /// </summary>
        /// <param name="self">This position.</param>
        /// <param name="other">The other position.</param>
        /// <returns>The direction from this position to another position.</returns>
        public static Vector2 Direction(this Vector2 self, [NotNull] Component other) => self.Direction(other.transform.position);
        
        /// <summary>
        /// The direction from this position to another position.
        /// </summary>
        /// <param name="self">This position.</param>
        /// <param name="other">The other position.</param>
        /// <returns>The direction from this position to another position.</returns>
        public static Vector2 Direction(this Vector2 self, [NotNull] GameObject other) => self.Direction(other.transform.position);
        
        /// <summary>
        /// The direction from this position to another position.
        /// </summary>
        /// <param name="self">This position.</param>
        /// <param name="other">The other position.</param>
        /// <returns>The direction from this position to another position.</returns>
        public static Vector2 Direction(this Vector3 self, Vector2 other) => self.Flatten().Direction(other);
        
        /// <summary>
        /// The direction from this position to another position.
        /// </summary>
        /// <param name="self">This position.</param>
        /// <param name="other">The other position.</param>
        /// <returns>The direction from this position to another position.</returns>
        public static Vector2 Direction(this Vector3 self, Vector3 other) => self.Flatten().Direction(other.Flatten());
        
        /// <summary>
        /// The direction from this position to another position.
        /// </summary>
        /// <param name="self">This position.</param>
        /// <param name="other">The other position.</param>
        /// <returns>The direction from this position to another position.</returns>
        public static Vector2 Direction(this Vector3 self, [NotNull] Transform other) => self.Direction(other.position);
        
        /// <summary>
        /// The direction from this position to another position.
        /// </summary>
        /// <param name="self">This position.</param>
        /// <param name="other">The other position.</param>
        /// <returns>The direction from this position to another position.</returns>
        public static Vector2 Direction(this Vector3 self, [NotNull] Component other) => self.Direction(other.transform.position);
        
        /// <summary>
        /// The direction from this position to another position.
        /// </summary>
        /// <param name="self">This position.</param>
        /// <param name="other">The other position.</param>
        /// <returns>The direction from this position to another position.</returns>
        public static Vector2 Direction(this Vector3 self, [NotNull] GameObject other) => self.Direction(other.transform.position);
        
        /// <summary>
        /// The direction from this position to another position.
        /// </summary>
        /// <param name="self">This position.</param>
        /// <param name="other">The other position.</param>
        /// <returns>The direction from this position to another position.</returns>
        public static Vector2 Direction([NotNull] this Transform self, Vector2 other) => self.position.Direction(other);
        
        /// <summary>
        /// The direction from this position to another position.
        /// </summary>
        /// <param name="self">This position.</param>
        /// <param name="other">The other position.</param>
        /// <returns>The direction from this position to another position.</returns>
        public static Vector2 Direction([NotNull] this Transform self, Vector3 other) => self.position.Direction(other);
        
        /// <summary>
        /// The direction from this position to another position.
        /// </summary>
        /// <param name="self">This position.</param>
        /// <param name="other">The other position.</param>
        /// <returns>The direction from this position to another position.</returns>
        public static Vector2 Direction([NotNull] this Transform self, [NotNull] Transform other) => self.position.Direction(other.position);
        
        /// <summary>
        /// The direction from this position to another position.
        /// </summary>
        /// <param name="self">This position.</param>
        /// <param name="other">The other position.</param>
        /// <returns>The direction from this position to another position.</returns>
        public static Vector2 Direction([NotNull] this Transform self, [NotNull] Component other) => self.position.Direction(other.transform.position);
        
        /// <summary>
        /// The direction from this position to another position.
        /// </summary>
        /// <param name="self">This position.</param>
        /// <param name="other">The other position.</param>
        /// <returns>The direction from this position to another position.</returns>
        public static Vector2 Direction([NotNull] this Transform self, [NotNull] GameObject other) => self.position.Direction(other.transform.position);
        
        /// <summary>
        /// The direction from this position to another position.
        /// </summary>
        /// <param name="self">This position.</param>
        /// <param name="other">The other position.</param>
        /// <returns>The direction from this position to another position.</returns>
        public static Vector2 Direction([NotNull] this Component self, Vector2 other) => self.transform.position.Direction(other);
        
        /// <summary>
        /// The direction from this position to another position.
        /// </summary>
        /// <param name="self">This position.</param>
        /// <param name="other">The other position.</param>
        /// <returns>The direction from this position to another position.</returns>
        public static Vector2 Direction([NotNull] this Component self, Vector3 other) => self.transform.position.Direction(other);
        
        /// <summary>
        /// The direction from this position to another position.
        /// </summary>
        /// <param name="self">This position.</param>
        /// <param name="other">The other position.</param>
        /// <returns>The direction from this position to another position.</returns>
        public static Vector2 Direction([NotNull] this Component self, [NotNull] Transform other) => self.transform.position.Direction(other.position);
        
        /// <summary>
        /// The direction from this position to another position.
        /// </summary>
        /// <param name="self">This position.</param>
        /// <param name="other">The other position.</param>
        /// <returns>The direction from this position to another position.</returns>
        public static Vector2 Direction([NotNull] this Component self, [NotNull] Component other) => self.transform.position.Direction(other.transform.position);
        
        /// <summary>
        /// The direction from this position to another position.
        /// </summary>
        /// <param name="self">This position.</param>
        /// <param name="other">The other position.</param>
        /// <returns>The direction from this position to another position.</returns>
        public static Vector2 Direction([NotNull] this Component self, [NotNull] GameObject other) => self.transform.position.Direction(other.transform.position);
        
        /// <summary>
        /// The direction from this position to another position.
        /// </summary>
        /// <param name="self">This position.</param>
        /// <param name="other">The other position.</param>
        /// <returns>The direction from this position to another position.</returns>
        public static Vector2 Direction([NotNull] this GameObject self, Vector2 other) => self.transform.position.Direction(other);
        
        /// <summary>
        /// The direction from this position to another position.
        /// </summary>
        /// <param name="self">This position.</param>
        /// <param name="other">The other position.</param>
        /// <returns>The direction from this position to another position.</returns>
        public static Vector2 Direction([NotNull] this GameObject self, Vector3 other) => self.transform.position.Direction(other);
        
        /// <summary>
        /// The direction from this position to another position.
        /// </summary>
        /// <param name="self">This position.</param>
        /// <param name="other">The other position.</param>
        /// <returns>The direction from this position to another position.</returns>
        public static Vector2 Direction([NotNull] this GameObject self, [NotNull] Transform other) => self.transform.position.Direction(other.position);
        
        /// <summary>
        /// The direction from this position to another position.
        /// </summary>
        /// <param name="self">This position.</param>
        /// <param name="other">The other position.</param>
        /// <returns>The direction from this position to another position.</returns>
        public static Vector2 Direction([NotNull] this GameObject self, [NotNull] Component other) => self.transform.position.Direction(other.transform.position);
        
        /// <summary>
        /// The direction from this position to another position.
        /// </summary>
        /// <param name="self">This position.</param>
        /// <param name="other">The other position.</param>
        /// <returns>The direction from this position to another position.</returns>
        public static Vector2 Direction([NotNull] this GameObject self, [NotNull] GameObject other) => self.transform.position.Direction(other.transform.position);
    }
}