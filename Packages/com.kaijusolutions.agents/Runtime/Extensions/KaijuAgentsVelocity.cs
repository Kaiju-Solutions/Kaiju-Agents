using System.Diagnostics.CodeAnalysis;
using UnityEngine;

namespace KaijuSolutions.Agents.Extensions
{
    /// <summary>
    /// Extension methods to get the velocity at which an object is travelling along the X and Z axes. Methods without a delta time value will use Time.deltaTime. All three-dimensional vectors will be flattened via methods in <see cref="KaijuAgentsFlatten"/>.
    /// </summary>
    public static class KaijuAgentsVelocity
    {
        /// <summary>
        /// The current velocity based on the time it took to move from a previous position.
        /// </summary>
        /// <param name="current">The current position.</param>
        /// <param name="previous">The previous position.</param>
        /// <param name="delta">The time since the last position.</param>
        /// <returns>The current speed based on the time it took to move from a previous position.</returns>
        public static Vector2 Velocity(this Vector2 current, Vector2 previous, float delta) => current.Direction(previous) / delta;
        
        /// <summary>
        /// The current velocity based on the time it took to move from a previous position.
        /// </summary>
        /// <param name="current">The current position.</param>
        /// <param name="previous">The previous position.</param>
        /// <returns>The current speed based on the time it took to move from a previous position.</returns>
        public static Vector2 Velocity(this Vector2 current, Vector2 previous) => current.Velocity(previous, Time.deltaTime);
        
        /// <summary>
        /// The current velocity based on the time it took to move from a previous position.
        /// </summary>
        /// <param name="current">The current position.</param>
        /// <param name="previous">The previous position.</param>
        /// <param name="delta">The time since the last position.</param>
        /// <returns>The current speed based on the time it took to move from a previous position.</returns>
        public static Vector2 Velocity(this Vector2 current, Vector3 previous, float delta) => current.Velocity(previous.Flatten(), delta);
        
        /// <summary>
        /// The current velocity based on the time it took to move from a previous position.
        /// </summary>
        /// <param name="current">The current position.</param>
        /// <param name="previous">The previous position.</param>
        /// <returns>The current speed based on the time it took to move from a previous position.</returns>
        public static Vector2 Velocity(this Vector2 current, Vector3 previous) => current.Velocity(previous, Time.deltaTime);
        
        /// <summary>
        /// The current velocity based on the time it took to move from a previous position.
        /// </summary>
        /// <param name="current">The current position.</param>
        /// <param name="previous">The previous position.</param>
        /// <param name="delta">The time since the last position.</param>
        /// <returns>The current speed based on the time it took to move from a previous position.</returns>
        public static Vector2 Velocity(this Vector2 current, [NotNull] Transform previous, float delta) => current.Velocity(previous.position, delta);
        
        /// <summary>
        /// The current velocity based on the time it took to move from a previous position.
        /// </summary>
        /// <param name="current">The current position.</param>
        /// <param name="previous">The previous position.</param>
        /// <returns>The current speed based on the time it took to move from a previous position.</returns>
        public static Vector2 Velocity(this Vector2 current, [NotNull] Transform previous) => current.Velocity(previous.position, Time.deltaTime);
        
        /// <summary>
        /// The current velocity based on the time it took to move from a previous position.
        /// </summary>
        /// <param name="current">The current position.</param>
        /// <param name="previous">The previous position.</param>
        /// <param name="delta">The time since the last position.</param>
        /// <returns>The current speed based on the time it took to move from a previous position.</returns>
        public static Vector2 Velocity(this Vector2 current, [NotNull] Component previous, float delta) => current.Velocity(previous.transform.position, delta);
        
        /// <summary>
        /// The current velocity based on the time it took to move from a previous position.
        /// </summary>
        /// <param name="current">The current position.</param>
        /// <param name="previous">The previous position.</param>
        /// <returns>The current speed based on the time it took to move from a previous position.</returns>
        public static Vector2 Velocity(this Vector2 current, [NotNull] Component previous) => current.Velocity(previous.transform.position, Time.deltaTime);
        
        /// <summary>
        /// The current velocity based on the time it took to move from a previous position.
        /// </summary>
        /// <param name="current">The current position.</param>
        /// <param name="previous">The previous position.</param>
        /// <param name="delta">The time since the last position.</param>
        /// <returns>The current speed based on the time it took to move from a previous position.</returns>
        public static Vector2 Velocity(this Vector2 current, [NotNull] GameObject previous, float delta) => current.Velocity(previous.transform.position, delta);
        
        /// <summary>
        /// The current velocity based on the time it took to move from a previous position.
        /// </summary>
        /// <param name="current">The current position.</param>
        /// <param name="previous">The previous position.</param>
        /// <returns>The current speed based on the time it took to move from a previous position.</returns>
        public static Vector2 Velocity(this Vector2 current, [NotNull] GameObject previous) => current.Velocity(previous.transform.position, Time.deltaTime);
        
        /// <summary>
        /// The current velocity based on the time it took to move from a previous position.
        /// </summary>
        /// <param name="current">The current position.</param>
        /// <param name="previous">The previous position.</param>
        /// <param name="delta">The time since the last position.</param>
        /// <returns>The current speed based on the time it took to move from a previous position.</returns>
        public static Vector2 Velocity(this Vector3 current, Vector2 previous, float delta) => current.Flatten().Velocity(previous, delta);
        
        /// <summary>
        /// The current velocity based on the time it took to move from a previous position.
        /// </summary>
        /// <param name="current">The current position.</param>
        /// <param name="previous">The previous position.</param>
        /// <returns>The current speed based on the time it took to move from a previous position.</returns>
        public static Vector2 Velocity(this Vector3 current, Vector2 previous) => current.Velocity(previous, Time.deltaTime);
        
        /// <summary>
        /// The current velocity based on the time it took to move from a previous position.
        /// </summary>
        /// <param name="current">The current position.</param>
        /// <param name="previous">The previous position.</param>
        /// <param name="delta">The time since the last position.</param>
        /// <returns>The current speed based on the time it took to move from a previous position.</returns>
        public static Vector2 Velocity(this Vector3 current, Vector3 previous, float delta) => current.Flatten().Velocity(previous.Flatten(), delta);
        
        /// <summary>
        /// The current velocity based on the time it took to move from a previous position.
        /// </summary>
        /// <param name="current">The current position.</param>
        /// <param name="previous">The previous position.</param>
        /// <returns>The current speed based on the time it took to move from a previous position.</returns>
        public static Vector2 Velocity(this Vector3 current, Vector3 previous) => current.Velocity(previous, Time.deltaTime);
        
        /// <summary>
        /// The current velocity based on the time it took to move from a previous position.
        /// </summary>
        /// <param name="current">The current position.</param>
        /// <param name="previous">The previous position.</param>
        /// <param name="delta">The time since the last position.</param>
        /// <returns>The current speed based on the time it took to move from a previous position.</returns>
        public static Vector2 Velocity(this Vector3 current, [NotNull] Transform previous, float delta) => current.Velocity(previous.position, delta);
        
        /// <summary>
        /// The current velocity based on the time it took to move from a previous position.
        /// </summary>
        /// <param name="current">The current position.</param>
        /// <param name="previous">The previous position.</param>
        /// <returns>The current speed based on the time it took to move from a previous position.</returns>
        public static Vector2 Velocity(this Vector3 current, [NotNull] Transform previous) => current.Velocity(previous, Time.deltaTime);
        
        /// <summary>
        /// The current velocity based on the time it took to move from a previous position.
        /// </summary>
        /// <param name="current">The current position.</param>
        /// <param name="previous">The previous position.</param>
        /// <param name="delta">The time since the last position.</param>
        /// <returns>The current speed based on the time it took to move from a previous position.</returns>
        public static Vector2 Velocity(this Vector3 current, [NotNull] Component previous, float delta) => current.Velocity(previous.transform.position, delta);
        
        /// <summary>
        /// The current velocity based on the time it took to move from a previous position.
        /// </summary>
        /// <param name="current">The current position.</param>
        /// <param name="previous">The previous position.</param>
        /// <returns>The current speed based on the time it took to move from a previous position.</returns>
        public static Vector2 Velocity(this Vector3 current, [NotNull] Component previous) => current.Velocity(previous, Time.deltaTime);
        
        /// <summary>
        /// The current velocity based on the time it took to move from a previous position.
        /// </summary>
        /// <param name="current">The current position.</param>
        /// <param name="previous">The previous position.</param>
        /// <param name="delta">The time since the last position.</param>
        /// <returns>The current speed based on the time it took to move from a previous position.</returns>
        public static Vector2 Velocity(this Vector3 current, [NotNull] GameObject previous, float delta) => current.Velocity(previous.transform.position, delta);
        
        /// <summary>
        /// The current velocity based on the time it took to move from a previous position.
        /// </summary>
        /// <param name="current">The current position.</param>
        /// <param name="previous">The previous position.</param>
        /// <returns>The current speed based on the time it took to move from a previous position.</returns>
        public static Vector2 Velocity(this Vector3 current, [NotNull] GameObject previous) => current.Velocity(previous, Time.deltaTime);
        
        /// <summary>
        /// The current velocity based on the time it took to move from a previous position.
        /// </summary>
        /// <param name="current">The current position.</param>
        /// <param name="previous">The previous position.</param>
        /// <param name="delta">The time since the last position.</param>
        /// <returns>The current speed based on the time it took to move from a previous position.</returns>
        public static Vector2 Velocity([NotNull] this Transform current, Vector2 previous, float delta) => current.position.Velocity(previous, delta);
        
        /// <summary>
        /// The current velocity based on the time it took to move from a previous position.
        /// </summary>
        /// <param name="current">The current position.</param>
        /// <param name="previous">The previous position.</param>
        /// <returns>The current speed based on the time it took to move from a previous position.</returns>
        public static Vector2 Velocity([NotNull] this Transform current, Vector2 previous) => current.Velocity(previous, Time.deltaTime);
        
        /// <summary>
        /// The current velocity based on the time it took to move from a previous position.
        /// </summary>
        /// <param name="current">The current position.</param>
        /// <param name="previous">The previous position.</param>
        /// <param name="delta">The time since the last position.</param>
        /// <returns>The current speed based on the time it took to move from a previous position.</returns>
        public static Vector2 Velocity([NotNull] this Transform current, Vector3 previous, float delta) => current.position.Velocity(previous, delta);
        
        /// <summary>
        /// The current velocity based on the time it took to move from a previous position.
        /// </summary>
        /// <param name="current">The current position.</param>
        /// <param name="previous">The previous position.</param>
        /// <returns>The current speed based on the time it took to move from a previous position.</returns>
        public static Vector2 Velocity([NotNull] this Transform current, Vector3 previous) => current.Velocity(previous, Time.deltaTime);
        
        /// <summary>
        /// The current velocity based on the time it took to move from a previous position.
        /// </summary>
        /// <param name="current">The current position.</param>
        /// <param name="previous">The previous position.</param>
        /// <param name="delta">The time since the last position.</param>
        /// <returns>The current speed based on the time it took to move from a previous position.</returns>
        public static Vector2 Velocity([NotNull] this Transform current, [NotNull] Transform previous, float delta) => current.position.Velocity(previous.position, delta);
        
        /// <summary>
        /// The current velocity based on the time it took to move from a previous position.
        /// </summary>
        /// <param name="current">The current position.</param>
        /// <param name="previous">The previous position.</param>
        /// <returns>The current speed based on the time it took to move from a previous position.</returns>
        public static Vector2 Velocity([NotNull] this Transform current, [NotNull] Transform previous) => current.Velocity(previous, Time.deltaTime);
        
        /// <summary>
        /// The current velocity based on the time it took to move from a previous position.
        /// </summary>
        /// <param name="current">The current position.</param>
        /// <param name="previous">The previous position.</param>
        /// <param name="delta">The time since the last position.</param>
        /// <returns>The current speed based on the time it took to move from a previous position.</returns>
        public static Vector2 Velocity([NotNull] this Transform current, [NotNull] Component previous, float delta) => current.position.Velocity(previous.transform.position, delta);
        
        /// <summary>
        /// The current velocity based on the time it took to move from a previous position.
        /// </summary>
        /// <param name="current">The current position.</param>
        /// <param name="previous">The previous position.</param>
        /// <returns>The current speed based on the time it took to move from a previous position.</returns>
        public static Vector2 Velocity([NotNull] this Transform current, [NotNull] Component previous) => current.Velocity(previous, Time.deltaTime);
        
        /// <summary>
        /// The current velocity based on the time it took to move from a previous position.
        /// </summary>
        /// <param name="current">The current position.</param>
        /// <param name="previous">The previous position.</param>
        /// <param name="delta">The time since the last position.</param>
        /// <returns>The current speed based on the time it took to move from a previous position.</returns>
        public static Vector2 Velocity([NotNull] this Transform current, [NotNull] GameObject previous, float delta) => current.position.Velocity(previous.transform.position, delta);
        
        /// <summary>
        /// The current velocity based on the time it took to move from a previous position.
        /// </summary>
        /// <param name="current">The current position.</param>
        /// <param name="previous">The previous position.</param>
        /// <returns>The current speed based on the time it took to move from a previous position.</returns>
        public static Vector2 Velocity([NotNull] this Transform current, [NotNull] GameObject previous) => current.Velocity(previous, Time.deltaTime);
        
        /// <summary>
        /// The current velocity based on the time it took to move from a previous position.
        /// </summary>
        /// <param name="current">The current position.</param>
        /// <param name="previous">The previous position.</param>
        /// <param name="delta">The time since the last position.</param>
        /// <returns>The current speed based on the time it took to move from a previous position.</returns>
        public static Vector2 Velocity([NotNull] this Component current, Vector2 previous, float delta) => current.transform.position.Velocity(previous, delta);
        
        /// <summary>
        /// The current velocity based on the time it took to move from a previous position.
        /// </summary>
        /// <param name="current">The current position.</param>
        /// <param name="previous">The previous position.</param>
        /// <returns>The current speed based on the time it took to move from a previous position.</returns>
        public static Vector2 Velocity([NotNull] this Component current, Vector2 previous) => current.Velocity(previous, Time.deltaTime);
        
        /// <summary>
        /// The current velocity based on the time it took to move from a previous position.
        /// </summary>
        /// <param name="current">The current position.</param>
        /// <param name="previous">The previous position.</param>
        /// <param name="delta">The time since the last position.</param>
        /// <returns>The current speed based on the time it took to move from a previous position.</returns>
        public static Vector2 Velocity([NotNull] this Component current, Vector3 previous, float delta) => current.transform.position.Velocity(previous, delta);
        
        /// <summary>
        /// The current velocity based on the time it took to move from a previous position.
        /// </summary>
        /// <param name="current">The current position.</param>
        /// <param name="previous">The previous position.</param>
        /// <returns>The current speed based on the time it took to move from a previous position.</returns>
        public static Vector2 Velocity([NotNull] this Component current, Vector3 previous) => current.Velocity(previous, Time.deltaTime);
        
        /// <summary>
        /// The current velocity based on the time it took to move from a previous position.
        /// </summary>
        /// <param name="current">The current position.</param>
        /// <param name="previous">The previous position.</param>
        /// <param name="delta">The time since the last position.</param>
        /// <returns>The current speed based on the time it took to move from a previous position.</returns>
        public static Vector2 Velocity([NotNull] this Component current, [NotNull] Transform previous, float delta) => current.transform.position.Velocity(previous.position, delta);
        
        /// <summary>
        /// The current velocity based on the time it took to move from a previous position.
        /// </summary>
        /// <param name="current">The current position.</param>
        /// <param name="previous">The previous position.</param>
        /// <returns>The current speed based on the time it took to move from a previous position.</returns>
        public static Vector2 Velocity([NotNull] this Component current, [NotNull] Transform previous) => current.Velocity(previous, Time.deltaTime);
        
        /// <summary>
        /// The current velocity based on the time it took to move from a previous position.
        /// </summary>
        /// <param name="current">The current position.</param>
        /// <param name="previous">The previous position.</param>
        /// <param name="delta">The time since the last position.</param>
        /// <returns>The current speed based on the time it took to move from a previous position.</returns>
        public static Vector2 Velocity([NotNull] this Component current, [NotNull] Component previous, float delta) => current.transform.position.Velocity(previous.transform.position, delta);
        
        /// <summary>
        /// The current velocity based on the time it took to move from a previous position.
        /// </summary>
        /// <param name="current">The current position.</param>
        /// <param name="previous">The previous position.</param>
        /// <returns>The current speed based on the time it took to move from a previous position.</returns>
        public static Vector2 Velocity([NotNull] this Component current, [NotNull] Component previous) => current.Velocity(previous, Time.deltaTime);
        
        /// <summary>
        /// The current velocity based on the time it took to move from a previous position.
        /// </summary>
        /// <param name="current">The current position.</param>
        /// <param name="previous">The previous position.</param>
        /// <param name="delta">The time since the last position.</param>
        /// <returns>The current speed based on the time it took to move from a previous position.</returns>
        public static Vector2 Velocity([NotNull] this Component current, [NotNull] GameObject previous, float delta) => current.transform.position.Velocity(previous.transform.position, delta);
        
        /// <summary>
        /// The current velocity based on the time it took to move from a previous position.
        /// </summary>
        /// <param name="current">The current position.</param>
        /// <param name="previous">The previous position.</param>
        /// <returns>The current speed based on the time it took to move from a previous position.</returns>
        public static Vector2 Velocity([NotNull] this Component current, [NotNull] GameObject previous) => current.Velocity(previous, Time.deltaTime);
        
        /// <summary>
        /// The current velocity based on the time it took to move from a previous position.
        /// </summary>
        /// <param name="current">The current position.</param>
        /// <param name="previous">The previous position.</param>
        /// <param name="delta">The time since the last position.</param>
        /// <returns>The current speed based on the time it took to move from a previous position.</returns>
        public static Vector2 Velocity([NotNull] this GameObject current, Vector2 previous, float delta) => current.transform.position.Velocity(previous, delta);
        
        /// <summary>
        /// The current velocity based on the time it took to move from a previous position.
        /// </summary>
        /// <param name="current">The current position.</param>
        /// <param name="previous">The previous position.</param>
        /// <returns>The current speed based on the time it took to move from a previous position.</returns>
        public static Vector2 Velocity([NotNull] this GameObject current, Vector2 previous) => current.Velocity(previous, Time.deltaTime);
        
        /// <summary>
        /// The current velocity based on the time it took to move from a previous position.
        /// </summary>
        /// <param name="current">The current position.</param>
        /// <param name="previous">The previous position.</param>
        /// <param name="delta">The time since the last position.</param>
        /// <returns>The current speed based on the time it took to move from a previous position.</returns>
        public static Vector2 Velocity([NotNull] this GameObject current, Vector3 previous, float delta) => current.transform.position.Velocity(previous, delta);
        
        /// <summary>
        /// The current velocity based on the time it took to move from a previous position.
        /// </summary>
        /// <param name="current">The current position.</param>
        /// <param name="previous">The previous position.</param>
        /// <returns>The current speed based on the time it took to move from a previous position.</returns>
        public static Vector2 Velocity([NotNull] this GameObject current, Vector3 previous) => current.Velocity(previous, Time.deltaTime);
        
        /// <summary>
        /// The current velocity based on the time it took to move from a previous position.
        /// </summary>
        /// <param name="current">The current position.</param>
        /// <param name="previous">The previous position.</param>
        /// <param name="delta">The time since the last position.</param>
        /// <returns>The current speed based on the time it took to move from a previous position.</returns>
        public static Vector2 Velocity([NotNull] this GameObject current, [NotNull] Transform previous, float delta) => current.transform.position.Velocity(previous.position, delta);
        
        /// <summary>
        /// The current velocity based on the time it took to move from a previous position.
        /// </summary>
        /// <param name="current">The current position.</param>
        /// <param name="previous">The previous position.</param>
        /// <returns>The current speed based on the time it took to move from a previous position.</returns>
        public static Vector2 Velocity([NotNull] this GameObject current, [NotNull] Transform previous) => current.Velocity(previous, Time.deltaTime);
        
        /// <summary>
        /// The current velocity based on the time it took to move from a previous position.
        /// </summary>
        /// <param name="current">The current position.</param>
        /// <param name="previous">The previous position.</param>
        /// <param name="delta">The time since the last position.</param>
        /// <returns>The current speed based on the time it took to move from a previous position.</returns>
        public static Vector2 Velocity([NotNull] this GameObject current, [NotNull] Component previous, float delta) => current.transform.position.Velocity(previous.transform.position, delta);
        
        /// <summary>
        /// The current velocity based on the time it took to move from a previous position.
        /// </summary>
        /// <param name="current">The current position.</param>
        /// <param name="previous">The previous position.</param>
        /// <returns>The current speed based on the time it took to move from a previous position.</returns>
        public static Vector2 Velocity([NotNull] this GameObject current, [NotNull] Component previous) => current.Velocity(previous, Time.deltaTime);
        
        /// <summary>
        /// The current velocity based on the time it took to move from a previous position.
        /// </summary>
        /// <param name="current">The current position.</param>
        /// <param name="previous">The previous position.</param>
        /// <param name="delta">The time since the last position.</param>
        /// <returns>The current speed based on the time it took to move from a previous position.</returns>
        public static Vector2 Velocity([NotNull] this GameObject current, [NotNull] GameObject previous, float delta) => current.transform.position.Velocity(previous.transform.position, delta);
        
        /// <summary>
        /// The current velocity based on the time it took to move from a previous position.
        /// </summary>
        /// <param name="current">The current position.</param>
        /// <param name="previous">The previous position.</param>
        /// <returns>The current speed based on the time it took to move from a previous position.</returns>
        public static Vector2 Velocity([NotNull] this GameObject current, [NotNull] GameObject previous) => current.Velocity(previous, Time.deltaTime);
    }
}