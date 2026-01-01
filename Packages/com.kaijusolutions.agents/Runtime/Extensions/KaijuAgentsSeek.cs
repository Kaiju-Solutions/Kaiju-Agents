using System.Diagnostics.CodeAnalysis;
using UnityEngine;

namespace KaijuSolutions.Agents.Extensions
{
    /// <summary>
    /// Standalone seek steering extension methods.
    /// </summary>
    public static class KaijuAgentsSeek
    {
        /// <summary>
        /// Calculate a seek behaviour.
        /// </summary>
        /// <param name="position">The current position of the instance to calculate the movement for.</param>
        /// <param name="speed">The maximum speed that the position can update at.</param>
        /// <param name="target">The target to move in relation to.</param>
        /// <returns>The calculated movement.</returns>
        public static Vector2 Seek(this Vector2 position, float speed, Vector2 target) => target.Direction(position).normalized * speed;
        
        /// <summary>
        /// Calculate a seek behaviour.
        /// </summary>
        /// <param name="position">The current position of the instance to calculate the movement for.</param>
        /// <param name="speed">The maximum speed that the position can update at.</param>
        /// <param name="target">The target to move in relation to.</param>
        /// <returns>The calculated movement.</returns>
        public static Vector2 Seek(this Vector2 position, float speed, Vector3 target) => position.Seek(speed, target.Flatten());
        
        /// <summary>
        /// Calculate a seek behaviour.
        /// </summary>
        /// <param name="position">The current position of the instance to calculate the movement for.</param>
        /// <param name="speed">The maximum speed that the position can update at.</param>
        /// <param name="target">The target to move in relation to.</param>
        /// <returns>The calculated movement.</returns>
        public static Vector2 Seek(this Vector2 position, float speed, [NotNull] Transform target) => position.Seek(speed, target.Flatten());
        
        /// <summary>
        /// Calculate a seek behaviour.
        /// </summary>
        /// <param name="position">The current position of the instance to calculate the movement for.</param>
        /// <param name="speed">The maximum speed that the position can update at.</param>
        /// <param name="target">The target to move in relation to.</param>
        /// <returns>The calculated movement.</returns>
        public static Vector2 Seek(this Vector2 position, float speed, [NotNull] Component target) => position.Seek(speed, target.Flatten());
        
        /// <summary>
        /// Calculate a seek behaviour.
        /// </summary>
        /// <param name="position">The current position of the instance to calculate the movement for.</param>
        /// <param name="speed">The maximum speed that the position can update at.</param>
        /// <param name="target">The target to move in relation to.</param>
        /// <returns>The calculated movement.</returns>
        public static Vector2 Seek(this Vector2 position, float speed, [NotNull] GameObject target) => position.Seek(speed, target.Flatten());
        
        /// <summary>
        /// Calculate a seek behaviour.
        /// </summary>
        /// <param name="position">The current position of the instance to calculate the movement for.</param>
        /// <param name="speed">The maximum speed that the position can update at.</param>
        /// <param name="target">The target to move in relation to.</param>
        /// <returns>The calculated movement.</returns>
        public static Vector2 Seek(this Vector3 position, float speed, Vector3 target) => position.Flatten().Seek(speed, target.Flatten());
        
        /// <summary>
        /// Calculate a seek behaviour.
        /// </summary>
        /// <param name="position">The current position of the instance to calculate the movement for.</param>
        /// <param name="speed">The maximum speed that the position can update at.</param>
        /// <param name="target">The target to move in relation to.</param>
        /// <returns>The calculated movement.</returns>
        public static Vector2 Seek(this Vector3 position, float speed, [NotNull] Transform target) => position.Flatten().Seek(speed, target.Flatten());
        
        /// <summary>
        /// Calculate a seek behaviour.
        /// </summary>
        /// <param name="position">The current position of the instance to calculate the movement for.</param>
        /// <param name="speed">The maximum speed that the position can update at.</param>
        /// <param name="target">The target to move in relation to.</param>
        /// <returns>The calculated movement.</returns>
        public static Vector2 Seek(this Vector3 position, float speed, [NotNull] Component target) => position.Flatten().Seek(speed, target.Flatten());
        
        /// <summary>
        /// Calculate a seek behaviour.
        /// </summary>
        /// <param name="position">The current position of the instance to calculate the movement for.</param>
        /// <param name="speed">The maximum speed that the position can update at.</param>
        /// <param name="target">The target to move in relation to.</param>
        /// <returns>The calculated movement.</returns>
        public static Vector2 Seek(this Vector3 position, float speed, [NotNull] GameObject target) => position.Flatten().Seek(speed, target.Flatten());
        
        /// <summary>
        /// Calculate a seek behaviour.
        /// </summary>
        /// <param name="position">The current position of the instance to calculate the movement for.</param>
        /// <param name="speed">The maximum speed that the position can update at.</param>
        /// <param name="target">The target to move in relation to.</param>
        /// <returns>The calculated movement.</returns>
        public static Vector2 Seek([NotNull] this Transform position, float speed, Vector3 target) => position.Flatten().Seek(speed, target.Flatten());
        
        /// <summary>
        /// Calculate a seek behaviour.
        /// </summary>
        /// <param name="position">The current position of the instance to calculate the movement for.</param>
        /// <param name="speed">The maximum speed that the position can update at.</param>
        /// <param name="target">The target to move in relation to.</param>
        /// <returns>The calculated movement.</returns>
        public static Vector2 Seek([NotNull] this Transform position, float speed, [NotNull] Transform target) => position.Flatten().Seek(speed, target.Flatten());
        
        /// <summary>
        /// Calculate a seek behaviour.
        /// </summary>
        /// <param name="position">The current position of the instance to calculate the movement for.</param>
        /// <param name="speed">The maximum speed that the position can update at.</param>
        /// <param name="target">The target to move in relation to.</param>
        /// <returns>The calculated movement.</returns>
        public static Vector2 Seek([NotNull] this Transform position, float speed, [NotNull] Component target) => position.Flatten().Seek(speed, target.Flatten());
        
        /// <summary>
        /// Calculate a seek behaviour.
        /// </summary>
        /// <param name="position">The current position of the instance to calculate the movement for.</param>
        /// <param name="speed">The maximum speed that the position can update at.</param>
        /// <param name="target">The target to move in relation to.</param>
        /// <returns>The calculated movement.</returns>
        public static Vector2 Seek([NotNull] this Transform position, float speed, [NotNull] GameObject target) => position.Flatten().Seek(speed, target.Flatten());
        
        /// <summary>
        /// Calculate a seek behaviour.
        /// </summary>
        /// <param name="position">The current position of the instance to calculate the movement for.</param>
        /// <param name="speed">The maximum speed that the position can update at.</param>
        /// <param name="target">The target to move in relation to.</param>
        /// <returns>The calculated movement.</returns>
        public static Vector2 Seek([NotNull] this Component position, float speed, Vector3 target) => position.Flatten().Seek(speed, target.Flatten());
        
        /// <summary>
        /// Calculate a seek behaviour.
        /// </summary>
        /// <param name="position">The current position of the instance to calculate the movement for.</param>
        /// <param name="speed">The maximum speed that the position can update at.</param>
        /// <param name="target">The target to move in relation to.</param>
        /// <returns>The calculated movement.</returns>
        public static Vector2 Seek([NotNull] this Component position, float speed, [NotNull] Transform target) => position.Flatten().Seek(speed, target.Flatten());
        
        /// <summary>
        /// Calculate a seek behaviour.
        /// </summary>
        /// <param name="position">The current position of the instance to calculate the movement for.</param>
        /// <param name="speed">The maximum speed that the position can update at.</param>
        /// <param name="target">The target to move in relation to.</param>
        /// <returns>The calculated movement.</returns>
        public static Vector2 Seek([NotNull] this Component position, float speed, [NotNull] Component target) => position.Flatten().Seek(speed, target.Flatten());
        
        /// <summary>
        /// Calculate a seek behaviour.
        /// </summary>
        /// <param name="position">The current position of the instance to calculate the movement for.</param>
        /// <param name="speed">The maximum speed that the position can update at.</param>
        /// <param name="target">The target to move in relation to.</param>
        /// <returns>The calculated movement.</returns>
        public static Vector2 Seek([NotNull] this Component position, float speed, [NotNull] GameObject target) => position.Flatten().Seek(speed, target.Flatten());
        
        /// <summary>
        /// Calculate a seek behaviour.
        /// </summary>
        /// <param name="position">The current position of the instance to calculate the movement for.</param>
        /// <param name="speed">The maximum speed that the position can update at.</param>
        /// <param name="target">The target to move in relation to.</param>
        /// <returns>The calculated movement.</returns>
        public static Vector2 Seek([NotNull] this GameObject position, float speed, Vector3 target) => position.Flatten().Seek(speed, target.Flatten());
        
        /// <summary>
        /// Calculate a seek behaviour.
        /// </summary>
        /// <param name="position">The current position of the instance to calculate the movement for.</param>
        /// <param name="speed">The maximum speed that the position can update at.</param>
        /// <param name="target">The target to move in relation to.</param>
        /// <returns>The calculated movement.</returns>
        public static Vector2 Seek([NotNull] this GameObject position, float speed, [NotNull] Transform target) => position.Flatten().Seek(speed, target.Flatten());
        
        /// <summary>
        /// Calculate a seek behaviour.
        /// </summary>
        /// <param name="position">The current position of the instance to calculate the movement for.</param>
        /// <param name="speed">The maximum speed that the position can update at.</param>
        /// <param name="target">The target to move in relation to.</param>
        /// <returns>The calculated movement.</returns>
        public static Vector2 Seek([NotNull] this GameObject position, float speed, [NotNull] Component target) => position.Flatten().Seek(speed, target.Flatten());
        
        /// <summary>
        /// Calculate a seek behaviour.
        /// </summary>
        /// <param name="position">The current position of the instance to calculate the movement for.</param>
        /// <param name="speed">The maximum speed that the position can update at.</param>
        /// <param name="target">The target to move in relation to.</param>
        /// <returns>The calculated movement.</returns>
        public static Vector2 Seek([NotNull] this GameObject position, float speed, [NotNull] GameObject target) => position.Flatten().Seek(speed, target.Flatten());
    }
}