using System.Diagnostics.CodeAnalysis;
using UnityEngine;

namespace KaijuSolutions.Agents.Extensions
{
    /// <summary>
    /// Extension methods to get the velocity at which an object is travelling along all three axes. Methods without a delta time value will use Time.deltaTime. Any Vector2 values will be expanded via the <see cref="KaijuAgentsExpand.Expand"/> method.
    /// </summary>
    public static class KaijuAgentsVelocity3
    {
        /// <summary>
        /// The current velocity based on the time it took to move from a previous position.
        /// </summary>
        /// <param name="current">The current position.</param>
        /// <param name="previous">The previous position.</param>
        /// <param name="delta">The time since the last position.</param>
        /// <returns>The current speed based on the time it took to move from a previous position.</returns>
        public static Vector3 Velocity3(this Vector2 current, Vector2 previous, float delta) => current.Expand().Velocity3(previous, delta);
        
        /// <summary>
        /// The current velocity based on the time it took to move from a previous position.
        /// </summary>
        /// <param name="current">The current position.</param>
        /// <param name="previous">The previous position.</param>
        /// <returns>The current speed based on the time it took to move from a previous position.</returns>
        public static Vector3 Velocity3(this Vector2 current, Vector2 previous) => current.Expand().Velocity3(previous, Time.deltaTime);
        
        /// <summary>
        /// The current velocity based on the time it took to move from a previous position.
        /// </summary>
        /// <param name="current">The current position.</param>
        /// <param name="previous">The previous position.</param>
        /// <param name="delta">The time since the last position.</param>
        /// <returns>The current speed based on the time it took to move from a previous position.</returns>
        public static Vector3 Velocity3(this Vector2 current, Vector3 previous, float delta) => current.Expand().Velocity3(previous, delta);
        
        /// <summary>
        /// The current velocity based on the time it took to move from a previous position.
        /// </summary>
        /// <param name="current">The current position.</param>
        /// <param name="previous">The previous position.</param>
        /// <returns>The current speed based on the time it took to move from a previous position.</returns>
        public static Vector3 Velocity3(this Vector2 current, Vector3 previous) => current.Expand().Velocity3(previous, Time.deltaTime);
        
        /// <summary>
        /// The current velocity based on the time it took to move from a previous position.
        /// </summary>
        /// <param name="current">The current position.</param>
        /// <param name="previous">The previous position.</param>
        /// <param name="delta">The time since the last position.</param>
        /// <returns>The current speed based on the time it took to move from a previous position.</returns>
        public static Vector3 Velocity3(this Vector2 current, [NotNull] Transform previous, float delta) => current.Expand().Velocity3(previous, delta);
        
        /// <summary>
        /// The current velocity based on the time it took to move from a previous position.
        /// </summary>
        /// <param name="current">The current position.</param>
        /// <param name="previous">The previous position.</param>
        /// <returns>The current speed based on the time it took to move from a previous position.</returns>
        public static Vector3 Velocity3(this Vector2 current, [NotNull] Transform previous) => current.Expand().Velocity3(previous, Time.deltaTime);
        
        /// <summary>
        /// The current velocity based on the time it took to move from a previous position.
        /// </summary>
        /// <param name="current">The current position.</param>
        /// <param name="previous">The previous position.</param>
        /// <param name="delta">The time since the last position.</param>
        /// <returns>The current speed based on the time it took to move from a previous position.</returns>
        public static Vector3 Velocity3(this Vector2 current, [NotNull] Component previous, float delta) => current.Expand().Velocity3(previous, delta);
        
        /// <summary>
        /// The current velocity based on the time it took to move from a previous position.
        /// </summary>
        /// <param name="current">The current position.</param>
        /// <param name="previous">The previous position.</param>
        /// <returns>The current speed based on the time it took to move from a previous position.</returns>
        public static Vector3 Velocity3(this Vector2 current, [NotNull] Component previous) => current.Expand().Velocity3(previous, Time.deltaTime);
        
        /// <summary>
        /// The current velocity based on the time it took to move from a previous position.
        /// </summary>
        /// <param name="current">The current position.</param>
        /// <param name="previous">The previous position.</param>
        /// <param name="delta">The time since the last position.</param>
        /// <returns>The current speed based on the time it took to move from a previous position.</returns>
        public static Vector3 Velocity3(this Vector2 current, [NotNull] GameObject previous, float delta) => current.Expand().Velocity3(previous, delta);
        
        /// <summary>
        /// The current velocity based on the time it took to move from a previous position.
        /// </summary>
        /// <param name="current">The current position.</param>
        /// <param name="previous">The previous position.</param>
        /// <returns>The current speed based on the time it took to move from a previous position.</returns>
        public static Vector3 Velocity3(this Vector2 current, [NotNull] GameObject previous) => current.Expand().Velocity3(previous, Time.deltaTime);
        
        /// <summary>
        /// The current velocity based on the time it took to move from a previous position.
        /// </summary>
        /// <param name="current">The current position.</param>
        /// <param name="previous">The previous position.</param>
        /// <param name="delta">The time since the last position.</param>
        /// <returns>The current speed based on the time it took to move from a previous position.</returns>
        public static Vector3 Velocity3(this Vector3 current, Vector2 previous, float delta) => current.Velocity3(previous.Expand(), delta);
        
        /// <summary>
        /// The current velocity based on the time it took to move from a previous position.
        /// </summary>
        /// <param name="current">The current position.</param>
        /// <param name="previous">The previous position.</param>
        /// <returns>The current speed based on the time it took to move from a previous position.</returns>
        public static Vector3 Velocity3(this Vector3 current, Vector2 previous) => current.Velocity3(previous, Time.deltaTime);
        
        /// <summary>
        /// The current velocity based on the time it took to move from a previous position.
        /// </summary>
        /// <param name="current">The current position.</param>
        /// <param name="previous">The previous position.</param>
        /// <param name="delta">The time since the last position.</param>
        /// <returns>The current speed based on the time it took to move from a previous position.</returns>
        public static Vector3 Velocity3(this Vector3 current, Vector3 previous, float delta) => current.Direction3(previous) / delta;
        
        /// <summary>
        /// The current velocity based on the time it took to move from a previous position.
        /// </summary>
        /// <param name="current">The current position.</param>
        /// <param name="previous">The previous position.</param>
        /// <returns>The current speed based on the time it took to move from a previous position.</returns>
        public static Vector3 Velocity3(this Vector3 current, Vector3 previous) => current.Velocity3(previous, Time.deltaTime);
        
        /// <summary>
        /// The current velocity based on the time it took to move from a previous position.
        /// </summary>
        /// <param name="current">The current position.</param>
        /// <param name="previous">The previous position.</param>
        /// <param name="delta">The time since the last position.</param>
        /// <returns>The current speed based on the time it took to move from a previous position.</returns>
        public static Vector3 Velocity3(this Vector3 current, [NotNull] Transform previous, float delta) => current.Velocity3(previous.position, delta);
        
        /// <summary>
        /// The current velocity based on the time it took to move from a previous position.
        /// </summary>
        /// <param name="current">The current position.</param>
        /// <param name="previous">The previous position.</param>
        /// <returns>The current speed based on the time it took to move from a previous position.</returns>
        public static Vector3 Velocity3(this Vector3 current, [NotNull] Transform previous) => current.Velocity3(previous, Time.deltaTime);
        
        /// <summary>
        /// The current velocity based on the time it took to move from a previous position.
        /// </summary>
        /// <param name="current">The current position.</param>
        /// <param name="previous">The previous position.</param>
        /// <param name="delta">The time since the last position.</param>
        /// <returns>The current speed based on the time it took to move from a previous position.</returns>
        public static Vector3 Velocity3(this Vector3 current, [NotNull] Component previous, float delta) => current.Velocity3(previous.transform.position, delta);
        
        /// <summary>
        /// The current velocity based on the time it took to move from a previous position.
        /// </summary>
        /// <param name="current">The current position.</param>
        /// <param name="previous">The previous position.</param>
        /// <returns>The current speed based on the time it took to move from a previous position.</returns>
        public static Vector3 Velocity3(this Vector3 current, [NotNull] Component previous) => current.Velocity3(previous, Time.deltaTime);
        
        /// <summary>
        /// The current velocity based on the time it took to move from a previous position.
        /// </summary>
        /// <param name="current">The current position.</param>
        /// <param name="previous">The previous position.</param>
        /// <param name="delta">The time since the last position.</param>
        /// <returns>The current speed based on the time it took to move from a previous position.</returns>
        public static Vector3 Velocity3(this Vector3 current, [NotNull] GameObject previous, float delta) => current.Velocity3(previous.transform.position, delta);
        
        /// <summary>
        /// The current velocity based on the time it took to move from a previous position.
        /// </summary>
        /// <param name="current">The current position.</param>
        /// <param name="previous">The previous position.</param>
        /// <returns>The current speed based on the time it took to move from a previous position.</returns>
        public static Vector3 Velocity3(this Vector3 current, [NotNull] GameObject previous) => current.Velocity3(previous, Time.deltaTime);
        
        /// <summary>
        /// The current velocity based on the time it took to move from a previous position.
        /// </summary>
        /// <param name="current">The current position.</param>
        /// <param name="previous">The previous position.</param>
        /// <param name="delta">The time since the last position.</param>
        /// <returns>The current speed based on the time it took to move from a previous position.</returns>
        public static Vector3 Velocity3([NotNull] this Transform current, Vector2 previous, float delta) => current.position.Velocity3(previous, delta);
        
        /// <summary>
        /// The current velocity based on the time it took to move from a previous position.
        /// </summary>
        /// <param name="current">The current position.</param>
        /// <param name="previous">The previous position.</param>
        /// <returns>The current speed based on the time it took to move from a previous position.</returns>
        public static Vector3 Velocity3([NotNull] this Transform current, Vector2 previous) => current.Velocity3(previous, Time.deltaTime);
        
        /// <summary>
        /// The current velocity based on the time it took to move from a previous position.
        /// </summary>
        /// <param name="current">The current position.</param>
        /// <param name="previous">The previous position.</param>
        /// <param name="delta">The time since the last position.</param>
        /// <returns>The current speed based on the time it took to move from a previous position.</returns>
        public static Vector3 Velocity3([NotNull] this Transform current, Vector3 previous, float delta) => current.position.Velocity3(previous, delta);
        
        /// <summary>
        /// The current velocity based on the time it took to move from a previous position.
        /// </summary>
        /// <param name="current">The current position.</param>
        /// <param name="previous">The previous position.</param>
        /// <returns>The current speed based on the time it took to move from a previous position.</returns>
        public static Vector3 Velocity3([NotNull] this Transform current, Vector3 previous) => current.Velocity3(previous, Time.deltaTime);
        
        /// <summary>
        /// The current velocity based on the time it took to move from a previous position.
        /// </summary>
        /// <param name="current">The current position.</param>
        /// <param name="previous">The previous position.</param>
        /// <param name="delta">The time since the last position.</param>
        /// <returns>The current speed based on the time it took to move from a previous position.</returns>
        public static Vector3 Velocity3([NotNull] this Transform current, [NotNull] Transform previous, float delta) => current.position.Velocity3(previous.position, delta);
        
        /// <summary>
        /// The current velocity based on the time it took to move from a previous position.
        /// </summary>
        /// <param name="current">The current position.</param>
        /// <param name="previous">The previous position.</param>
        /// <returns>The current speed based on the time it took to move from a previous position.</returns>
        public static Vector3 Velocity3([NotNull] this Transform current, [NotNull] Transform previous) => current.Velocity3(previous, Time.deltaTime);
        
        /// <summary>
        /// The current velocity based on the time it took to move from a previous position.
        /// </summary>
        /// <param name="current">The current position.</param>
        /// <param name="previous">The previous position.</param>
        /// <param name="delta">The time since the last position.</param>
        /// <returns>The current speed based on the time it took to move from a previous position.</returns>
        public static Vector3 Velocity3([NotNull] this Transform current, [NotNull] Component previous, float delta) => current.position.Velocity3(previous.transform.position, delta);
        
        /// <summary>
        /// The current velocity based on the time it took to move from a previous position.
        /// </summary>
        /// <param name="current">The current position.</param>
        /// <param name="previous">The previous position.</param>
        /// <returns>The current speed based on the time it took to move from a previous position.</returns>
        public static Vector3 Velocity3([NotNull] this Transform current, [NotNull] Component previous) => current.Velocity3(previous, Time.deltaTime);
        
        /// <summary>
        /// The current velocity based on the time it took to move from a previous position.
        /// </summary>
        /// <param name="current">The current position.</param>
        /// <param name="previous">The previous position.</param>
        /// <param name="delta">The time since the last position.</param>
        /// <returns>The current speed based on the time it took to move from a previous position.</returns>
        public static Vector3 Velocity3([NotNull] this Transform current, [NotNull] GameObject previous, float delta) => current.position.Velocity3(previous.transform.position, delta);
        
        /// <summary>
        /// The current velocity based on the time it took to move from a previous position.
        /// </summary>
        /// <param name="current">The current position.</param>
        /// <param name="previous">The previous position.</param>
        /// <returns>The current speed based on the time it took to move from a previous position.</returns>
        public static Vector3 Velocity3([NotNull] this Transform current, [NotNull] GameObject previous) => current.Velocity3(previous, Time.deltaTime);
        
        /// <summary>
        /// The current velocity based on the time it took to move from a previous position.
        /// </summary>
        /// <param name="current">The current position.</param>
        /// <param name="previous">The previous position.</param>
        /// <param name="delta">The time since the last position.</param>
        /// <returns>The current speed based on the time it took to move from a previous position.</returns>
        public static Vector3 Velocity3([NotNull] this Component current, Vector2 previous, float delta) => current.transform.position.Velocity3(previous, delta);
        
        /// <summary>
        /// The current velocity based on the time it took to move from a previous position.
        /// </summary>
        /// <param name="current">The current position.</param>
        /// <param name="previous">The previous position.</param>
        /// <returns>The current speed based on the time it took to move from a previous position.</returns>
        public static Vector3 Velocity3([NotNull] this Component current, Vector2 previous) => current.Velocity3(previous, Time.deltaTime);
        
        /// <summary>
        /// The current velocity based on the time it took to move from a previous position.
        /// </summary>
        /// <param name="current">The current position.</param>
        /// <param name="previous">The previous position.</param>
        /// <param name="delta">The time since the last position.</param>
        /// <returns>The current speed based on the time it took to move from a previous position.</returns>
        public static Vector3 Velocity3([NotNull] this Component current, Vector3 previous, float delta) => current.transform.position.Velocity3(previous, delta);
        
        /// <summary>
        /// The current velocity based on the time it took to move from a previous position.
        /// </summary>
        /// <param name="current">The current position.</param>
        /// <param name="previous">The previous position.</param>
        /// <returns>The current speed based on the time it took to move from a previous position.</returns>
        public static Vector3 Velocity3([NotNull] this Component current, Vector3 previous) => current.Velocity3(previous, Time.deltaTime);
        
        /// <summary>
        /// The current velocity based on the time it took to move from a previous position.
        /// </summary>
        /// <param name="current">The current position.</param>
        /// <param name="previous">The previous position.</param>
        /// <param name="delta">The time since the last position.</param>
        /// <returns>The current speed based on the time it took to move from a previous position.</returns>
        public static Vector3 Velocity3([NotNull] this Component current, [NotNull] Transform previous, float delta) => current.transform.position.Velocity3(previous.position, delta);
        
        /// <summary>
        /// The current velocity based on the time it took to move from a previous position.
        /// </summary>
        /// <param name="current">The current position.</param>
        /// <param name="previous">The previous position.</param>
        /// <returns>The current speed based on the time it took to move from a previous position.</returns>
        public static Vector3 Velocity3([NotNull] this Component current, [NotNull] Transform previous) => current.Velocity3(previous, Time.deltaTime);
        
        /// <summary>
        /// The current velocity based on the time it took to move from a previous position.
        /// </summary>
        /// <param name="current">The current position.</param>
        /// <param name="previous">The previous position.</param>
        /// <param name="delta">The time since the last position.</param>
        /// <returns>The current speed based on the time it took to move from a previous position.</returns>
        public static Vector3 Velocity3([NotNull] this Component current, [NotNull] Component previous, float delta) => current.transform.position.Velocity3(previous.transform.position, delta);
        
        /// <summary>
        /// The current velocity based on the time it took to move from a previous position.
        /// </summary>
        /// <param name="current">The current position.</param>
        /// <param name="previous">The previous position.</param>
        /// <returns>The current speed based on the time it took to move from a previous position.</returns>
        public static Vector3 Velocity3([NotNull] this Component current, [NotNull] Component previous) => current.Velocity3(previous, Time.deltaTime);
        
        /// <summary>
        /// The current velocity based on the time it took to move from a previous position.
        /// </summary>
        /// <param name="current">The current position.</param>
        /// <param name="previous">The previous position.</param>
        /// <param name="delta">The time since the last position.</param>
        /// <returns>The current speed based on the time it took to move from a previous position.</returns>
        public static Vector3 Velocity3([NotNull] this Component current, [NotNull] GameObject previous, float delta) => current.transform.position.Velocity3(previous.transform.position, delta);
        
        /// <summary>
        /// The current velocity based on the time it took to move from a previous position.
        /// </summary>
        /// <param name="current">The current position.</param>
        /// <param name="previous">The previous position.</param>
        /// <returns>The current speed based on the time it took to move from a previous position.</returns>
        public static Vector3 Velocity3([NotNull] this Component current, [NotNull] GameObject previous) => current.Velocity3(previous, Time.deltaTime);
        
        /// <summary>
        /// The current velocity based on the time it took to move from a previous position.
        /// </summary>
        /// <param name="current">The current position.</param>
        /// <param name="previous">The previous position.</param>
        /// <param name="delta">The time since the last position.</param>
        /// <returns>The current speed based on the time it took to move from a previous position.</returns>
        public static Vector3 Velocity3([NotNull] this GameObject current, Vector2 previous, float delta) => current.transform.position.Velocity3(previous, delta);
        
        /// <summary>
        /// The current velocity based on the time it took to move from a previous position.
        /// </summary>
        /// <param name="current">The current position.</param>
        /// <param name="previous">The previous position.</param>
        /// <returns>The current speed based on the time it took to move from a previous position.</returns>
        public static Vector3 Velocity3([NotNull] this GameObject current, Vector2 previous) => current.Velocity3(previous, Time.deltaTime);
        
        /// <summary>
        /// The current velocity based on the time it took to move from a previous position.
        /// </summary>
        /// <param name="current">The current position.</param>
        /// <param name="previous">The previous position.</param>
        /// <param name="delta">The time since the last position.</param>
        /// <returns>The current speed based on the time it took to move from a previous position.</returns>
        public static Vector3 Velocity3([NotNull] this GameObject current, Vector3 previous, float delta) => current.transform.position.Velocity3(previous, delta);
        
        /// <summary>
        /// The current velocity based on the time it took to move from a previous position.
        /// </summary>
        /// <param name="current">The current position.</param>
        /// <param name="previous">The previous position.</param>
        /// <returns>The current speed based on the time it took to move from a previous position.</returns>
        public static Vector3 Velocity3([NotNull] this GameObject current, Vector3 previous) => current.Velocity3(previous, Time.deltaTime);
        
        /// <summary>
        /// The current velocity based on the time it took to move from a previous position.
        /// </summary>
        /// <param name="current">The current position.</param>
        /// <param name="previous">The previous position.</param>
        /// <param name="delta">The time since the last position.</param>
        /// <returns>The current speed based on the time it took to move from a previous position.</returns>
        public static Vector3 Velocity3([NotNull] this GameObject current, [NotNull] Transform previous, float delta) => current.transform.position.Velocity3(previous.position, delta);
        
        /// <summary>
        /// The current velocity based on the time it took to move from a previous position.
        /// </summary>
        /// <param name="current">The current position.</param>
        /// <param name="previous">The previous position.</param>
        /// <returns>The current speed based on the time it took to move from a previous position.</returns>
        public static Vector3 Velocity3([NotNull] this GameObject current, [NotNull] Transform previous) => current.Velocity3(previous, Time.deltaTime);
        
        /// <summary>
        /// The current velocity based on the time it took to move from a previous position.
        /// </summary>
        /// <param name="current">The current position.</param>
        /// <param name="previous">The previous position.</param>
        /// <param name="delta">The time since the last position.</param>
        /// <returns>The current speed based on the time it took to move from a previous position.</returns>
        public static Vector3 Velocity3([NotNull] this GameObject current, [NotNull] Component previous, float delta) => current.transform.position.Velocity3(previous.transform.position, delta);
        
        /// <summary>
        /// The current velocity based on the time it took to move from a previous position.
        /// </summary>
        /// <param name="current">The current position.</param>
        /// <param name="previous">The previous position.</param>
        /// <returns>The current speed based on the time it took to move from a previous position.</returns>
        public static Vector3 Velocity3([NotNull] this GameObject current, [NotNull] Component previous) => current.Velocity3(previous, Time.deltaTime);
        
        /// <summary>
        /// The current velocity based on the time it took to move from a previous position.
        /// </summary>
        /// <param name="current">The current position.</param>
        /// <param name="previous">The previous position.</param>
        /// <param name="delta">The time since the last position.</param>
        /// <returns>The current speed based on the time it took to move from a previous position.</returns>
        public static Vector3 Velocity3([NotNull] this GameObject current, [NotNull] GameObject previous, float delta) => current.transform.position.Velocity3(previous.transform.position, delta);
        
        /// <summary>
        /// The current velocity based on the time it took to move from a previous position.
        /// </summary>
        /// <param name="current">The current position.</param>
        /// <param name="previous">The previous position.</param>
        /// <returns>The current speed based on the time it took to move from a previous position.</returns>
        public static Vector3 Velocity3([NotNull] this GameObject current, [NotNull] GameObject previous) => current.Velocity3(previous, Time.deltaTime);
    }
}