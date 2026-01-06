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
        /// <param name="target">The target to move in relation to.</param>
        /// <param name="speed">The maximum speed that the position can update at.</param>
        /// <returns>The calculated movement.</returns>
        public static Vector2 Seek(this Vector2 position, Vector2 target, float speed) => target.Direction(position).normalized * speed;
        
        /// <summary>
        /// Calculate a seek behaviour.
        /// </summary>
        /// <param name="position">The current position of the instance to calculate the movement for.</param>
        /// <param name="target">The target to move in relation to.</param>
        /// <param name="speed">The maximum speed that the position can update at.</param>
        /// <returns>The calculated movement.</returns>
        public static Vector2 Seek(this Vector2 position, Vector3 target, float speed) => position.Seek(target.Flatten(), speed);
        
        /// <summary>
        /// Calculate a seek behaviour.
        /// </summary>
        /// <param name="position">The current position of the instance to calculate the movement for.</param>
        /// <param name="target">The target to move in relation to.</param>
        /// <param name="speed">The maximum speed that the position can update at.</param>
        /// <returns>The calculated movement.</returns>
        public static Vector2 Seek(this Vector2 position, [NotNull] Transform target, float speed) => position.Seek(target.Flatten(), speed);
        
        /// <summary>
        /// Calculate a seek behaviour.
        /// </summary>
        /// <param name="position">The current position of the instance to calculate the movement for.</param>
        /// <param name="target">The target to move in relation to.</param>
        /// <param name="speed">The maximum speed that the position can update at.</param>
        /// <returns>The calculated movement.</returns>
        public static Vector2 Seek(this Vector2 position, [NotNull] Component target, float speed) => position.Seek(target.Flatten(), speed);
        
        /// <summary>
        /// Calculate a seek behaviour.
        /// </summary>
        /// <param name="position">The current position of the instance to calculate the movement for.</param>
        /// <param name="target">The target to move in relation to.</param>
        /// <param name="speed">The maximum speed that the position can update at.</param>
        /// <returns>The calculated movement.</returns>
        public static Vector2 Seek(this Vector2 position, [NotNull] GameObject target, float speed) => position.Seek(target.Flatten(), speed);
        
        /// <summary>
        /// Calculate a seek behaviour.
        /// </summary>
        /// <param name="position">The current position of the instance to calculate the movement for.</param>
        /// <param name="target">The target to move in relation to.</param>
        /// <param name="speed">The maximum speed that the position can update at.</param>
        /// <returns>The calculated movement.</returns>
        public static Vector2 Seek(this Vector3 position, Vector2 target, float speed) => position.Flatten().Seek(target, speed);
        
        /// <summary>
        /// Calculate a seek behaviour.
        /// </summary>
        /// <param name="position">The current position of the instance to calculate the movement for.</param>
        /// <param name="target">The target to move in relation to.</param>
        /// <param name="speed">The maximum speed that the position can update at.</param>
        /// <returns>The calculated movement.</returns>
        public static Vector2 Seek(this Vector3 position, Vector3 target, float speed) => position.Flatten().Seek(target.Flatten(), speed);
        
        /// <summary>
        /// Calculate a seek behaviour.
        /// </summary>
        /// <param name="position">The current position of the instance to calculate the movement for.</param>
        /// <param name="target">The target to move in relation to.</param>
        /// <param name="speed">The maximum speed that the position can update at.</param>
        /// <returns>The calculated movement.</returns>
        public static Vector2 Seek(this Vector3 position, [NotNull] Transform target, float speed) => position.Flatten().Seek(target.Flatten(), speed);
        
        /// <summary>
        /// Calculate a seek behaviour.
        /// </summary>
        /// <param name="position">The current position of the instance to calculate the movement for.</param>
        /// <param name="target">The target to move in relation to.</param>
        /// <param name="speed">The maximum speed that the position can update at.</param>
        /// <returns>The calculated movement.</returns>
        public static Vector2 Seek(this Vector3 position, [NotNull] Component target, float speed) => position.Flatten().Seek(target.Flatten(), speed);
        
        /// <summary>
        /// Calculate a seek behaviour.
        /// </summary>
        /// <param name="position">The current position of the instance to calculate the movement for.</param>
        /// <param name="target">The target to move in relation to.</param>
        /// <param name="speed">The maximum speed that the position can update at.</param>
        /// <returns>The calculated movement.</returns>
        public static Vector2 Seek(this Vector3 position, [NotNull] GameObject target, float speed) => position.Flatten().Seek(target.Flatten(), speed);
        
        /// <summary>
        /// Calculate a seek behaviour.
        /// </summary>
        /// <param name="position">The current position of the instance to calculate the movement for.</param>
        /// <param name="target">The target to move in relation to.</param>
        /// <param name="speed">The maximum speed that the position can update at.</param>
        /// <returns>The calculated movement.</returns>
        public static Vector2 Seek([NotNull] this Transform position, Vector2 target, float speed) => position.Flatten().Seek(target, speed);
        
        /// <summary>
        /// Calculate a seek behaviour.
        /// </summary>
        /// <param name="position">The current position of the instance to calculate the movement for.</param>
        /// <param name="target">The target to move in relation to.</param>
        /// <param name="speed">The maximum speed that the position can update at.</param>
        /// <returns>The calculated movement.</returns>
        public static Vector2 Seek([NotNull] this Transform position, Vector3 target, float speed) => position.Flatten().Seek(target.Flatten(), speed);
        
        /// <summary>
        /// Calculate a seek behaviour.
        /// </summary>
        /// <param name="position">The current position of the instance to calculate the movement for.</param>
        /// <param name="target">The target to move in relation to.</param>
        /// <param name="speed">The maximum speed that the position can update at.</param>
        /// <returns>The calculated movement.</returns>
        public static Vector2 Seek([NotNull] this Transform position, [NotNull] Transform target, float speed) => position.Flatten().Seek(target.Flatten(), speed);
        
        /// <summary>
        /// Calculate a seek behaviour.
        /// </summary>
        /// <param name="position">The current position of the instance to calculate the movement for.</param>
        /// <param name="target">The target to move in relation to.</param>
        /// <param name="speed">The maximum speed that the position can update at.</param>
        /// <returns>The calculated movement.</returns>
        public static Vector2 Seek([NotNull] this Transform position, [NotNull] Component target, float speed) => position.Flatten().Seek(target.Flatten(), speed);
        
        /// <summary>
        /// Calculate a seek behaviour.
        /// </summary>
        /// <param name="position">The current position of the instance to calculate the movement for.</param>
        /// <param name="target">The target to move in relation to.</param>
        /// <param name="speed">The maximum speed that the position can update at.</param>
        /// <returns>The calculated movement.</returns>
        public static Vector2 Seek([NotNull] this Transform position, [NotNull] GameObject target, float speed) => position.Flatten().Seek(target.Flatten(), speed);
        
        /// <summary>
        /// Calculate a seek behaviour.
        /// </summary>
        /// <param name="position">The current position of the instance to calculate the movement for.</param>
        /// <param name="target">The target to move in relation to.</param>
        /// <param name="speed">The maximum speed that the position can update at.</param>
        /// <returns>The calculated movement.</returns>
        public static Vector2 Seek([NotNull] this Component position, Vector2 target, float speed) => position.Flatten().Seek(target, speed);
        
        /// <summary>
        /// Calculate a seek behaviour.
        /// </summary>
        /// <param name="position">The current position of the instance to calculate the movement for.</param>
        /// <param name="target">The target to move in relation to.</param>
        /// <param name="speed">The maximum speed that the position can update at.</param>
        /// <returns>The calculated movement.</returns>
        public static Vector2 Seek([NotNull] this Component position, Vector3 target, float speed) => position.Flatten().Seek(target.Flatten(), speed);
        
        /// <summary>
        /// Calculate a seek behaviour.
        /// </summary>
        /// <param name="position">The current position of the instance to calculate the movement for.</param>
        /// <param name="target">The target to move in relation to.</param>
        /// <param name="speed">The maximum speed that the position can update at.</param>
        /// <returns>The calculated movement.</returns>
        public static Vector2 Seek([NotNull] this Component position, [NotNull] Transform target, float speed) => position.Flatten().Seek(target.Flatten(), speed);
        
        /// <summary>
        /// Calculate a seek behaviour.
        /// </summary>
        /// <param name="position">The current position of the instance to calculate the movement for.</param>
        /// <param name="target">The target to move in relation to.</param>
        /// <param name="speed">The maximum speed that the position can update at.</param>
        /// <returns>The calculated movement.</returns>
        public static Vector2 Seek([NotNull] this Component position, [NotNull] Component target, float speed) => position.Flatten().Seek(target.Flatten(), speed);
        
        /// <summary>
        /// Calculate a seek behaviour.
        /// </summary>
        /// <param name="position">The current position of the instance to calculate the movement for.</param>
        /// <param name="target">The target to move in relation to.</param>
        /// <param name="speed">The maximum speed that the position can update at.</param>
        /// <returns>The calculated movement.</returns>
        public static Vector2 Seek([NotNull] this Component position, [NotNull] GameObject target, float speed) => position.Flatten().Seek(target.Flatten(), speed);
        
        /// <summary>
        /// Calculate a seek behaviour.
        /// </summary>
        /// <param name="position">The current position of the instance to calculate the movement for.</param>
        /// <param name="target">The target to move in relation to.</param>
        /// <param name="speed">The maximum speed that the position can update at.</param>
        /// <returns>The calculated movement.</returns>
        public static Vector2 Seek([NotNull] this GameObject position, Vector2 target, float speed) => position.Flatten().Seek(target, speed);
        
        /// <summary>
        /// Calculate a seek behaviour.
        /// </summary>
        /// <param name="position">The current position of the instance to calculate the movement for.</param>
        /// <param name="target">The target to move in relation to.</param>
        /// <param name="speed">The maximum speed that the position can update at.</param>
        /// <returns>The calculated movement.</returns>
        public static Vector2 Seek([NotNull] this GameObject position, Vector3 target, float speed) => position.Flatten().Seek(target.Flatten(), speed);
        
        /// <summary>
        /// Calculate a seek behaviour.
        /// </summary>
        /// <param name="position">The current position of the instance to calculate the movement for.</param>
        /// <param name="target">The target to move in relation to.</param>
        /// <param name="speed">The maximum speed that the position can update at.</param>
        /// <returns>The calculated movement.</returns>
        public static Vector2 Seek([NotNull] this GameObject position, [NotNull] Transform target, float speed) => position.Flatten().Seek(target.Flatten(), speed);
        
        /// <summary>
        /// Calculate a seek behaviour.
        /// </summary>
        /// <param name="position">The current position of the instance to calculate the movement for.</param>
        /// <param name="target">The target to move in relation to.</param>
        /// <param name="speed">The maximum speed that the position can update at.</param>
        /// <returns>The calculated movement.</returns>
        public static Vector2 Seek([NotNull] this GameObject position, [NotNull] Component target, float speed) => position.Flatten().Seek(target.Flatten(), speed);
        
        /// <summary>
        /// Calculate a seek behaviour.
        /// </summary>
        /// <param name="position">The current position of the instance to calculate the movement for.</param>
        /// <param name="target">The target to move in relation to.</param>
        /// <param name="speed">The maximum speed that the position can update at.</param>
        /// <returns>The calculated movement.</returns>
        public static Vector2 Seek([NotNull] this GameObject position, [NotNull] GameObject target, float speed) => position.Flatten().Seek(target.Flatten(), speed);
    }
}