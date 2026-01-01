using System.Diagnostics.CodeAnalysis;
using UnityEngine;

namespace KaijuSolutions.Agents.Extensions
{
    /// <summary>
    /// Extension methods to get the direction along all three axes from one position to another. Any Vector2 values will be expanded via the <see cref="KaijuAgentsExpand.Expand"/> method.
    /// </summary>
    public static class KaijuAgentsDirection3
    {
        /// <summary>
        /// The direction from this position to another position.
        /// </summary>
        /// <param name="self">This position.</param>
        /// <param name="other">The other position.</param>
        /// <returns>The direction from this position to another position.</returns>
        public static Vector3 Direction3(this Vector2 self, Vector2 other) => self.Expand().Direction3(other.Expand());
        
        /// <summary>
        /// The direction from this position to another position.
        /// </summary>
        /// <param name="self">This position.</param>
        /// <param name="other">The other position.</param>
        /// <returns>The direction from this position to another position.</returns>
        public static Vector3 Direction3(this Vector2 self, Vector3 other) => self.Expand().Direction3(other);
        
        /// <summary>
        /// The direction from this position to another position.
        /// </summary>
        /// <param name="self">This position.</param>
        /// <param name="other">The other position.</param>
        /// <returns>The direction from this position to another position.</returns>
        public static Vector3 Direction3(this Vector2 self, [NotNull] Transform other) => self.Expand().Direction3(other);
        
        /// <summary>
        /// The direction from this position to another position.
        /// </summary>
        /// <param name="self">This position.</param>
        /// <param name="other">The other position.</param>
        /// <returns>The direction from this position to another position.</returns>
        public static Vector3 Direction3(this Vector2 self, [NotNull] Component other) => self.Expand().Direction3(other);
        
        /// <summary>
        /// The direction from this position to another position.
        /// </summary>
        /// <param name="self">This position.</param>
        /// <param name="other">The other position.</param>
        /// <returns>The direction from this position to another position.</returns>
        public static Vector3 Direction3(this Vector2 self, [NotNull] GameObject other) => self.Expand().Direction3(other);
        
        /// <summary>
        /// The direction from this position to another position.
        /// </summary>
        /// <param name="self">This position.</param>
        /// <param name="other">The other position.</param>
        /// <returns>The direction from this position to another position.</returns>
        public static Vector3 Direction3(this Vector3 self, Vector2 other) => self.Direction3(other.Expand());
        
        /// <summary>
        /// The direction from this position to another position.
        /// </summary>
        /// <param name="self">This position.</param>
        /// <param name="other">The other position.</param>
        /// <returns>The direction from this position to another position.</returns>
        public static Vector3 Direction3(this Vector3 self, Vector3 other) => self - other;
        
        /// <summary>
        /// The direction from this position to another position.
        /// </summary>
        /// <param name="self">This position.</param>
        /// <param name="other">The other position.</param>
        /// <returns>The direction from this position to another position.</returns>
        public static Vector3 Direction3(this Vector3 self, [NotNull] Transform other) => self.Direction3(other.position);
        
        /// <summary>
        /// The direction from this position to another position.
        /// </summary>
        /// <param name="self">This position.</param>
        /// <param name="other">The other position.</param>
        /// <returns>The direction from this position to another position.</returns>
        public static Vector3 Direction3(this Vector3 self, [NotNull] Component other) => self.Direction3(other.transform.position);
        
        /// <summary>
        /// The direction from this position to another position.
        /// </summary>
        /// <param name="self">This position.</param>
        /// <param name="other">The other position.</param>
        /// <returns>The direction from this position to another position.</returns>
        public static Vector3 Direction3(this Vector3 self, [NotNull] GameObject other) => self.Direction3(other.transform.position);
        
        /// <summary>
        /// The direction from this position to another position.
        /// </summary>
        /// <param name="self">This position.</param>
        /// <param name="other">The other position.</param>
        /// <returns>The direction from this position to another position.</returns>
        public static Vector3 Direction3([NotNull] this Transform self, Vector2 other) => self.position.Direction3(other);
        
        /// <summary>
        /// The direction from this position to another position.
        /// </summary>
        /// <param name="self">This position.</param>
        /// <param name="other">The other position.</param>
        /// <returns>The direction from this position to another position.</returns>
        public static Vector3 Direction3([NotNull] this Transform self, Vector3 other) => self.position.Direction3(other);
        
        /// <summary>
        /// The direction from this position to another position.
        /// </summary>
        /// <param name="self">This position.</param>
        /// <param name="other">The other position.</param>
        /// <returns>The direction from this position to another position.</returns>
        public static Vector3 Direction3([NotNull] this Transform self, [NotNull] Transform other) => self.position.Direction3(other.position);
        
        /// <summary>
        /// The direction from this position to another position.
        /// </summary>
        /// <param name="self">This position.</param>
        /// <param name="other">The other position.</param>
        /// <returns>The direction from this position to another position.</returns>
        public static Vector3 Direction3([NotNull] this Transform self, [NotNull] Component other) => self.position.Direction3(other.transform.position);
        
        /// <summary>
        /// The direction from this position to another position.
        /// </summary>
        /// <param name="self">This position.</param>
        /// <param name="other">The other position.</param>
        /// <returns>The direction from this position to another position.</returns>
        public static Vector3 Direction3([NotNull] this Transform self, [NotNull] GameObject other) => self.position.Direction3(other.transform.position);
        
        /// <summary>
        /// The direction from this position to another position.
        /// </summary>
        /// <param name="self">This position.</param>
        /// <param name="other">The other position.</param>
        /// <returns>The direction from this position to another position.</returns>
        public static Vector3 Direction3([NotNull] this Component self, Vector2 other) => self.transform.position.Direction3(other);
        
        /// <summary>
        /// The direction from this position to another position.
        /// </summary>
        /// <param name="self">This position.</param>
        /// <param name="other">The other position.</param>
        /// <returns>The direction from this position to another position.</returns>
        public static Vector3 Direction3([NotNull] this Component self, Vector3 other) => self.transform.position.Direction3(other);
        
        /// <summary>
        /// The direction from this position to another position.
        /// </summary>
        /// <param name="self">This position.</param>
        /// <param name="other">The other position.</param>
        /// <returns>The direction from this position to another position.</returns>
        public static Vector3 Direction3([NotNull] this Component self, [NotNull] Transform other) => self.transform.position.Direction3(other.position);
        
        /// <summary>
        /// The direction from this position to another position.
        /// </summary>
        /// <param name="self">This position.</param>
        /// <param name="other">The other position.</param>
        /// <returns>The direction from this position to another position.</returns>
        public static Vector3 Direction3([NotNull] this Component self, [NotNull] Component other) => self.transform.position.Direction3(other.transform.position);
        
        /// <summary>
        /// The direction from this position to another position.
        /// </summary>
        /// <param name="self">This position.</param>
        /// <param name="other">The other position.</param>
        /// <returns>The direction from this position to another position.</returns>
        public static Vector3 Direction3([NotNull] this Component self, [NotNull] GameObject other) => self.transform.position.Direction3(other.transform.position);
        
        /// <summary>
        /// The direction from this position to another position.
        /// </summary>
        /// <param name="self">This position.</param>
        /// <param name="other">The other position.</param>
        /// <returns>The direction from this position to another position.</returns>
        public static Vector3 Direction3([NotNull] this GameObject self, Vector2 other) => self.transform.position.Direction3(other);
        
        /// <summary>
        /// The direction from this position to another position.
        /// </summary>
        /// <param name="self">This position.</param>
        /// <param name="other">The other position.</param>
        /// <returns>The direction from this position to another position.</returns>
        public static Vector3 Direction3([NotNull] this GameObject self, Vector3 other) => self.transform.position.Direction3(other);
        
        /// <summary>
        /// The direction from this position to another position.
        /// </summary>
        /// <param name="self">This position.</param>
        /// <param name="other">The other position.</param>
        /// <returns>The direction from this position to another position.</returns>
        public static Vector3 Direction3([NotNull] this GameObject self, [NotNull] Transform other) => self.transform.position.Direction3(other.position);
        
        /// <summary>
        /// The direction from this position to another position.
        /// </summary>
        /// <param name="self">This position.</param>
        /// <param name="other">The other position.</param>
        /// <returns>The direction from this position to another position.</returns>
        public static Vector3 Direction3([NotNull] this GameObject self, [NotNull] Component other) => self.transform.position.Direction3(other.transform.position);
        
        /// <summary>
        /// The direction from this position to another position.
        /// </summary>
        /// <param name="self">This position.</param>
        /// <param name="other">The other position.</param>
        /// <returns>The direction from this position to another position.</returns>
        public static Vector3 Direction3([NotNull] this GameObject self, [NotNull] GameObject other) => self.transform.position.Direction3(other.transform.position);
    }
}