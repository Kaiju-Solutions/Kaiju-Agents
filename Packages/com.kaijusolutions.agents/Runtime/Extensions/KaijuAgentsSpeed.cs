using System.Diagnostics.CodeAnalysis;
using UnityEngine;

namespace KaijuSolutions.Agents
{
    /// <summary>
    /// Extension methods to get the speed at which an object is travelling along the X and Z axes. Methods without a delta time value will use Time.deltaTime. All three-dimensional vectors will be flattened via methods in <see cref="KaijuAgentsFlatten"/>.
    /// </summary>
    public static class KaijuAgentsSpeed
    {
        /// <summary>
        /// The current speed based on the time it took to move from a previous position.
        /// </summary>
        /// <param name="current">The current position.</param>
        /// <param name="previous">The previous position.</param>
        /// <param name="delta">The time since the last position.</param>
        /// <returns>The current speed based on the time it took to move from a previous position.</returns>
        public static float Speed(this Vector2 current, Vector2 previous, float delta) => current.Distance(previous) / delta;
        
        /// <summary>
        /// The current speed based on the time it took to move from a previous position.
        /// </summary>
        /// <param name="current">The current position.</param>
        /// <param name="previous">The previous position.</param>
        /// <returns>The current speed based on the time it took to move from a previous position.</returns>
        public static float Speed(this Vector2 current, Vector2 previous) => current.Speed(previous, Time.deltaTime);
        
        /// <summary>
        /// The current speed based on the time it took to move from a previous position.
        /// </summary>
        /// <param name="current">The current position.</param>
        /// <param name="previous">The previous position.</param>
        /// <param name="delta">The time since the last position.</param>
        /// <returns>The current speed based on the time it took to move from a previous position.</returns>
        public static float Speed(this Vector2 current, Vector3 previous, float delta) => current.Speed(previous.Flatten(), delta);
        
        /// <summary>
        /// The current speed based on the time it took to move from a previous position.
        /// </summary>
        /// <param name="current">The current position.</param>
        /// <param name="previous">The previous position.</param>
        /// <returns>The current speed based on the time it took to move from a previous position.</returns>
        public static float Speed(this Vector2 current, Vector3 previous) => current.Speed(previous, Time.deltaTime);
        
        /// <summary>
        /// The current speed based on the time it took to move from a previous position.
        /// </summary>
        /// <param name="current">The current position.</param>
        /// <param name="previous">The previous position.</param>
        /// <param name="delta">The time since the last position.</param>
        /// <returns>The current speed based on the time it took to move from a previous position.</returns>
        public static float Speed(this Vector2 current, [NotNull] Transform previous, float delta) => current.Speed(previous.position, delta);
        
        /// <summary>
        /// The current speed based on the time it took to move from a previous position.
        /// </summary>
        /// <param name="current">The current position.</param>
        /// <param name="previous">The previous position.</param>
        /// <returns>The current speed based on the time it took to move from a previous position.</returns>
        public static float Speed(this Vector2 current, [NotNull] Transform previous) => current.Speed(previous, Time.deltaTime);
        
        /// <summary>
        /// The current speed based on the time it took to move from a previous position.
        /// </summary>
        /// <param name="current">The current position.</param>
        /// <param name="previous">The previous position.</param>
        /// <param name="delta">The time since the last position.</param>
        /// <returns>The current speed based on the time it took to move from a previous position.</returns>
        public static float Speed(this Vector2 current, [NotNull] Component previous, float delta) => current.Speed(previous.transform.position, delta);
        
        /// <summary>
        /// The current speed based on the time it took to move from a previous position.
        /// </summary>
        /// <param name="current">The current position.</param>
        /// <param name="previous">The previous position.</param>
        /// <returns>The current speed based on the time it took to move from a previous position.</returns>
        public static float Speed(this Vector2 current, [NotNull] Component previous) => current.Speed(previous, Time.deltaTime);
        
        /// <summary>
        /// The current speed based on the time it took to move from a previous position.
        /// </summary>
        /// <param name="current">The current position.</param>
        /// <param name="previous">The previous position.</param>
        /// <param name="delta">The time since the last position.</param>
        /// <returns>The current speed based on the time it took to move from a previous position.</returns>
        public static float Speed(this Vector2 current, [NotNull] GameObject previous, float delta) => current.Speed(previous.transform.position, delta);
        
        /// <summary>
        /// The current speed based on the time it took to move from a previous position.
        /// </summary>
        /// <param name="current">The current position.</param>
        /// <param name="previous">The previous position.</param>
        /// <returns>The current speed based on the time it took to move from a previous position.</returns>
        public static float Speed(this Vector2 current, [NotNull] GameObject previous) => current.Speed(previous, Time.deltaTime);
        
        /// <summary>
        /// The current speed based on the time it took to move from a previous position.
        /// </summary>
        /// <param name="current">The current position.</param>
        /// <param name="previous">The previous position.</param>
        /// <param name="delta">The time since the last position.</param>
        /// <returns>The current speed based on the time it took to move from a previous position.</returns>
        public static float Speed(this Vector3 current, Vector2 previous, float delta) => previous.Speed(current, delta);
        
        /// <summary>
        /// The current speed based on the time it took to move from a previous position.
        /// </summary>
        /// <param name="current">The current position.</param>
        /// <param name="previous">The previous position.</param>
        /// <returns>The current speed based on the time it took to move from a previous position.</returns>
        public static float Speed(this Vector3 current, Vector2 previous) => current.Speed(previous, Time.deltaTime);
        
        /// <summary>
        /// The current speed based on the time it took to move from a previous position.
        /// </summary>
        /// <param name="current">The current position.</param>
        /// <param name="previous">The previous position.</param>
        /// <param name="delta">The time since the last position.</param>
        /// <returns>The current speed based on the time it took to move from a previous position.</returns>
        public static float Speed(this Vector3 current, Vector3 previous, float delta) => current.Flatten().Speed(previous, delta);
        
        /// <summary>
        /// The current speed based on the time it took to move from a previous position.
        /// </summary>
        /// <param name="current">The current position.</param>
        /// <param name="previous">The previous position.</param>
        /// <returns>The current speed based on the time it took to move from a previous position.</returns>
        public static float Speed(this Vector3 current, Vector3 previous) => current.Speed(previous, Time.deltaTime);
        
        /// <summary>
        /// The current speed based on the time it took to move from a previous position.
        /// </summary>
        /// <param name="current">The current position.</param>
        /// <param name="previous">The previous position.</param>
        /// <param name="delta">The time since the last position.</param>
        /// <returns>The current speed based on the time it took to move from a previous position.</returns>
        public static float Speed(this Vector3 current, [NotNull] Transform previous, float delta) => current.Speed(previous.position, delta);
        
        /// <summary>
        /// The current speed based on the time it took to move from a previous position.
        /// </summary>
        /// <param name="current">The current position.</param>
        /// <param name="previous">The previous position.</param>
        /// <returns>The current speed based on the time it took to move from a previous position.</returns>
        public static float Speed(this Vector3 current, [NotNull] Transform previous) => current.Speed(previous, Time.deltaTime);
        
        /// <summary>
        /// The current speed based on the time it took to move from a previous position.
        /// </summary>
        /// <param name="current">The current position.</param>
        /// <param name="previous">The previous position.</param>
        /// <param name="delta">The time since the last position.</param>
        /// <returns>The current speed based on the time it took to move from a previous position.</returns>
        public static float Speed(this Vector3 current, [NotNull] Component previous, float delta) => current.Speed(previous.transform.position, delta);
        
        /// <summary>
        /// The current speed based on the time it took to move from a previous position.
        /// </summary>
        /// <param name="current">The current position.</param>
        /// <param name="previous">The previous position.</param>
        /// <returns>The current speed based on the time it took to move from a previous position.</returns>
        public static float Speed(this Vector3 current, [NotNull] Component previous) => current.Speed(previous, Time.deltaTime);
        
        /// <summary>
        /// The current speed based on the time it took to move from a previous position.
        /// </summary>
        /// <param name="current">The current position.</param>
        /// <param name="previous">The previous position.</param>
        /// <param name="delta">The time since the last position.</param>
        /// <returns>The current speed based on the time it took to move from a previous position.</returns>
        public static float Speed(this Vector3 current, [NotNull] GameObject previous, float delta) => current.Speed(previous.transform.position, delta);
        
        /// <summary>
        /// The current speed based on the time it took to move from a previous position.
        /// </summary>
        /// <param name="current">The current position.</param>
        /// <param name="previous">The previous position.</param>
        /// <returns>The current speed based on the time it took to move from a previous position.</returns>
        public static float Speed(this Vector3 current, [NotNull] GameObject previous) => current.Speed(previous, Time.deltaTime);
        
        /// <summary>
        /// The current speed based on the time it took to move from a previous position.
        /// </summary>
        /// <param name="current">The current position.</param>
        /// <param name="previous">The previous position.</param>
        /// <param name="delta">The time since the last position.</param>
        /// <returns>The current speed based on the time it took to move from a previous position.</returns>
        public static float Speed([NotNull] this Transform current, Vector2 previous, float delta) => previous.Speed(current, delta);
        
        /// <summary>
        /// The current speed based on the time it took to move from a previous position.
        /// </summary>
        /// <param name="current">The current position.</param>
        /// <param name="previous">The previous position.</param>
        /// <returns>The current speed based on the time it took to move from a previous position.</returns>
        public static float Speed([NotNull] this Transform current, Vector2 previous) => current.Speed(previous, Time.deltaTime);
        
        /// <summary>
        /// The current speed based on the time it took to move from a previous position.
        /// </summary>
        /// <param name="current">The current position.</param>
        /// <param name="previous">The previous position.</param>
        /// <param name="delta">The time since the last position.</param>
        /// <returns>The current speed based on the time it took to move from a previous position.</returns>
        public static float Speed([NotNull] this Transform current, Vector3 previous, float delta) => current.position.Speed(previous, delta);
        
        /// <summary>
        /// The current speed based on the time it took to move from a previous position.
        /// </summary>
        /// <param name="current">The current position.</param>
        /// <param name="previous">The previous position.</param>
        /// <returns>The current speed based on the time it took to move from a previous position.</returns>
        public static float Speed([NotNull] this Transform current, Vector3 previous) => current.Speed(previous, Time.deltaTime);
        
        /// <summary>
        /// The current speed based on the time it took to move from a previous position.
        /// </summary>
        /// <param name="current">The current position.</param>
        /// <param name="previous">The previous position.</param>
        /// <param name="delta">The time since the last position.</param>
        /// <returns>The current speed based on the time it took to move from a previous position.</returns>
        public static float Speed([NotNull] this Transform current, [NotNull] Transform previous, float delta) => current.position.Speed(previous.position, delta);
        
        /// <summary>
        /// The current speed based on the time it took to move from a previous position.
        /// </summary>
        /// <param name="current">The current position.</param>
        /// <param name="previous">The previous position.</param>
        /// <returns>The current speed based on the time it took to move from a previous position.</returns>
        public static float Speed([NotNull] this Transform current, [NotNull] Transform previous) => current.Speed(previous, Time.deltaTime);
        
        /// <summary>
        /// The current speed based on the time it took to move from a previous position.
        /// </summary>
        /// <param name="current">The current position.</param>
        /// <param name="previous">The previous position.</param>
        /// <param name="delta">The time since the last position.</param>
        /// <returns>The current speed based on the time it took to move from a previous position.</returns>
        public static float Speed([NotNull] this Transform current, [NotNull] Component previous, float delta) => current.position.Speed(previous.transform.position, delta);
        
        /// <summary>
        /// The current speed based on the time it took to move from a previous position.
        /// </summary>
        /// <param name="current">The current position.</param>
        /// <param name="previous">The previous position.</param>
        /// <returns>The current speed based on the time it took to move from a previous position.</returns>
        public static float Speed([NotNull] this Transform current, [NotNull] Component previous) => current.Speed(previous, Time.deltaTime);
        
        /// <summary>
        /// The current speed based on the time it took to move from a previous position.
        /// </summary>
        /// <param name="current">The current position.</param>
        /// <param name="previous">The previous position.</param>
        /// <param name="delta">The time since the last position.</param>
        /// <returns>The current speed based on the time it took to move from a previous position.</returns>
        public static float Speed([NotNull] this Transform current, [NotNull] GameObject previous, float delta) => current.position.Speed(previous.transform.position, delta);
        
        /// <summary>
        /// The current speed based on the time it took to move from a previous position.
        /// </summary>
        /// <param name="current">The current position.</param>
        /// <param name="previous">The previous position.</param>
        /// <returns>The current speed based on the time it took to move from a previous position.</returns>
        public static float Speed([NotNull] this Transform current, [NotNull] GameObject previous) => current.Speed(previous, Time.deltaTime);
        
        /// <summary>
        /// The current speed based on the time it took to move from a previous position.
        /// </summary>
        /// <param name="current">The current position.</param>
        /// <param name="previous">The previous position.</param>
        /// <param name="delta">The time since the last position.</param>
        /// <returns>The current speed based on the time it took to move from a previous position.</returns>
        public static float Speed([NotNull] this Component current, Vector2 previous, float delta) => previous.Speed(current, delta);
        
        /// <summary>
        /// The current speed based on the time it took to move from a previous position.
        /// </summary>
        /// <param name="current">The current position.</param>
        /// <param name="previous">The previous position.</param>
        /// <returns>The current speed based on the time it took to move from a previous position.</returns>
        public static float Speed([NotNull] this Component current, Vector2 previous) => current.Speed(previous, Time.deltaTime);
        
        /// <summary>
        /// The current speed based on the time it took to move from a previous position.
        /// </summary>
        /// <param name="current">The current position.</param>
        /// <param name="previous">The previous position.</param>
        /// <param name="delta">The time since the last position.</param>
        /// <returns>The current speed based on the time it took to move from a previous position.</returns>
        public static float Speed([NotNull] this Component current, Vector3 previous, float delta) => current.transform.position.Speed(previous, delta);
        
        /// <summary>
        /// The current speed based on the time it took to move from a previous position.
        /// </summary>
        /// <param name="current">The current position.</param>
        /// <param name="previous">The previous position.</param>
        /// <returns>The current speed based on the time it took to move from a previous position.</returns>
        public static float Speed([NotNull] this Component current, Vector3 previous) => current.Speed(previous, Time.deltaTime);
        
        /// <summary>
        /// The current speed based on the time it took to move from a previous position.
        /// </summary>
        /// <param name="current">The current position.</param>
        /// <param name="previous">The previous position.</param>
        /// <param name="delta">The time since the last position.</param>
        /// <returns>The current speed based on the time it took to move from a previous position.</returns>
        public static float Speed([NotNull] this Component current, [NotNull] Transform previous, float delta) => current.transform.position.Speed(previous.position, delta);
        
        /// <summary>
        /// The current speed based on the time it took to move from a previous position.
        /// </summary>
        /// <param name="current">The current position.</param>
        /// <param name="previous">The previous position.</param>
        /// <returns>The current speed based on the time it took to move from a previous position.</returns>
        public static float Speed([NotNull] this Component current, [NotNull] Transform previous) => current.Speed(previous, Time.deltaTime);
        
        /// <summary>
        /// The current speed based on the time it took to move from a previous position.
        /// </summary>
        /// <param name="current">The current position.</param>
        /// <param name="previous">The previous position.</param>
        /// <param name="delta">The time since the last position.</param>
        /// <returns>The current speed based on the time it took to move from a previous position.</returns>
        public static float Speed([NotNull] this Component current, [NotNull] Component previous, float delta) => current.transform.position.Speed(previous.transform.position, delta);
        
        /// <summary>
        /// The current speed based on the time it took to move from a previous position.
        /// </summary>
        /// <param name="current">The current position.</param>
        /// <param name="previous">The previous position.</param>
        /// <returns>The current speed based on the time it took to move from a previous position.</returns>
        public static float Speed([NotNull] this Component current, [NotNull] Component previous) => current.Speed(previous, Time.deltaTime);
        
        /// <summary>
        /// The current speed based on the time it took to move from a previous position.
        /// </summary>
        /// <param name="current">The current position.</param>
        /// <param name="previous">The previous position.</param>
        /// <param name="delta">The time since the last position.</param>
        /// <returns>The current speed based on the time it took to move from a previous position.</returns>
        public static float Speed([NotNull] this Component current, [NotNull] GameObject previous, float delta) => current.transform.position.Speed(previous.transform.position, delta);
        
        /// <summary>
        /// The current speed based on the time it took to move from a previous position.
        /// </summary>
        /// <param name="current">The current position.</param>
        /// <param name="previous">The previous position.</param>
        /// <returns>The current speed based on the time it took to move from a previous position.</returns>
        public static float Speed([NotNull] this Component current, [NotNull] GameObject previous) => current.Speed(previous, Time.deltaTime);
        
        /// <summary>
        /// The current speed based on the time it took to move from a previous position.
        /// </summary>
        /// <param name="current">The current position.</param>
        /// <param name="previous">The previous position.</param>
        /// <param name="delta">The time since the last position.</param>
        /// <returns>The current speed based on the time it took to move from a previous position.</returns>
        public static float Speed([NotNull] this GameObject current, Vector2 previous, float delta) => previous.Speed(current, delta);
        
        /// <summary>
        /// The current speed based on the time it took to move from a previous position.
        /// </summary>
        /// <param name="current">The current position.</param>
        /// <param name="previous">The previous position.</param>
        /// <returns>The current speed based on the time it took to move from a previous position.</returns>
        public static float Speed([NotNull] this GameObject current, Vector2 previous) => current.Speed(previous, Time.deltaTime);
        
        /// <summary>
        /// The current speed based on the time it took to move from a previous position.
        /// </summary>
        /// <param name="current">The current position.</param>
        /// <param name="previous">The previous position.</param>
        /// <param name="delta">The time since the last position.</param>
        /// <returns>The current speed based on the time it took to move from a previous position.</returns>
        public static float Speed([NotNull] this GameObject current, Vector3 previous, float delta) => current.transform.position.Speed(previous, delta);
        
        /// <summary>
        /// The current speed based on the time it took to move from a previous position.
        /// </summary>
        /// <param name="current">The current position.</param>
        /// <param name="previous">The previous position.</param>
        /// <returns>The current speed based on the time it took to move from a previous position.</returns>
        public static float Speed([NotNull] this GameObject current, Vector3 previous) => current.Speed(previous, Time.deltaTime);
        
        /// <summary>
        /// The current speed based on the time it took to move from a previous position.
        /// </summary>
        /// <param name="current">The current position.</param>
        /// <param name="previous">The previous position.</param>
        /// <param name="delta">The time since the last position.</param>
        /// <returns>The current speed based on the time it took to move from a previous position.</returns>
        public static float Speed([NotNull] this GameObject current, [NotNull] Transform previous, float delta) => current.transform.position.Speed(previous.position, delta);
        
        /// <summary>
        /// The current speed based on the time it took to move from a previous position.
        /// </summary>
        /// <param name="current">The current position.</param>
        /// <param name="previous">The previous position.</param>
        /// <returns>The current speed based on the time it took to move from a previous position.</returns>
        public static float Speed([NotNull] this GameObject current, [NotNull] Transform previous) => current.Speed(previous, Time.deltaTime);
        
        /// <summary>
        /// The current speed based on the time it took to move from a previous position.
        /// </summary>
        /// <param name="current">The current position.</param>
        /// <param name="previous">The previous position.</param>
        /// <param name="delta">The time since the last position.</param>
        /// <returns>The current speed based on the time it took to move from a previous position.</returns>
        public static float Speed([NotNull] this GameObject current, [NotNull] Component previous, float delta) => current.transform.position.Speed(previous.transform.position, delta);
        
        /// <summary>
        /// The current speed based on the time it took to move from a previous position.
        /// </summary>
        /// <param name="current">The current position.</param>
        /// <param name="previous">The previous position.</param>
        /// <returns>The current speed based on the time it took to move from a previous position.</returns>
        public static float Speed([NotNull] this GameObject current, [NotNull] Component previous) => current.Speed(previous, Time.deltaTime);
        
        /// <summary>
        /// The current speed based on the time it took to move from a previous position.
        /// </summary>
        /// <param name="current">The current position.</param>
        /// <param name="previous">The previous position.</param>
        /// <param name="delta">The time since the last position.</param>
        /// <returns>The current speed based on the time it took to move from a previous position.</returns>
        public static float Speed([NotNull] this GameObject current, [NotNull] GameObject previous, float delta) => current.transform.position.Speed(previous.transform.position, delta);
        
        /// <summary>
        /// The current speed based on the time it took to move from a previous position.
        /// </summary>
        /// <param name="current">The current position.</param>
        /// <param name="previous">The previous position.</param>
        /// <returns>The current speed based on the time it took to move from a previous position.</returns>
        public static float Speed([NotNull] this GameObject current, [NotNull] GameObject previous) => current.Speed(previous, Time.deltaTime);
    }
}