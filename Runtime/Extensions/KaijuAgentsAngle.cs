using System.Diagnostics.CodeAnalysis;
using UnityEngine;

namespace KaijuSolutions.Agents.Extensions
{
    /// <summary>
    /// Extensions to get the angle in degrees from a position towards a target around the global Y axis. These will be from -180 to 180 degrees.
    /// </summary>
    public static class KaijuAgentsAngle
    {
        /// <summary>
        /// The angle in degrees from a position towards a target around the global Y axis. This will be from -180 to 180 degrees.
        /// </summary>
        /// <param name="position">The position.</param>
        /// <param name="forward">The forward direction to get the angle relative to.</param>
        /// <param name="target">The target.</param>
        /// <returns>The angle in degrees from a position towards a target around the global Y axis. This will be from -180 to 180 degrees.</returns>
        public static float Angle(this Vector2 position, Vector2 forward, Vector2 target) => Vector2.SignedAngle(forward, target.Direction(position));
        
        /// <summary>
        /// The angle in degrees from a position towards a target around the global Y axis. This will be from -180 to 180 degrees.
        /// </summary>
        /// <param name="position">The position.</param>
        /// <param name="forward">The forward direction to get the angle relative to.</param>
        /// <param name="target">The target.</param>
        /// <returns>The angle in degrees from a position towards a target around the global Y axis. This will be from -180 to 180 degrees.</returns>
        public static float Angle(this Vector2 position, Vector2 forward, Vector3 target) => position.Angle(forward, target.Flatten());
        
        /// <summary>
        /// The angle in degrees from a position towards a target around the global Y axis. This will be from -180 to 180 degrees.
        /// </summary>
        /// <param name="position">The position.</param>
        /// <param name="forward">The forward direction to get the angle relative to.</param>
        /// <param name="target">The target.</param>
        /// <returns>The angle in degrees from a position towards a target around the global Y axis. This will be from -180 to 180 degrees.</returns>
        public static float Angle(this Vector2 position, Vector2 forward, [NotNull] Transform target) => position.Angle(forward, target.Flatten());
        
        /// <summary>
        /// The angle in degrees from a position towards a target around the global Y axis. This will be from -180 to 180 degrees.
        /// </summary>
        /// <param name="position">The position.</param>
        /// <param name="forward">The forward direction to get the angle relative to.</param>
        /// <param name="target">The target.</param>
        /// <returns>The angle in degrees from a position towards a target around the global Y axis. This will be from -180 to 180 degrees.</returns>
        public static float Angle(this Vector2 position, Vector2 forward, [NotNull] Component target) => position.Angle(forward, target.Flatten());
        
        /// <summary>
        /// The angle in degrees from a position towards a target around the global Y axis. This will be from -180 to 180 degrees.
        /// </summary>
        /// <param name="position">The position.</param>
        /// <param name="forward">The forward direction to get the angle relative to.</param>
        /// <param name="target">The target.</param>
        /// <returns>The angle in degrees from a position towards a target around the global Y axis. This will be from -180 to 180 degrees.</returns>
        public static float Angle(this Vector2 position, Vector2 forward, [NotNull] GameObject target) => position.Angle(forward, target.Flatten());
        
        /// <summary>
        /// The angle in degrees from a position towards a target around the global Y axis. This will be from -180 to 180 degrees.
        /// </summary>
        /// <param name="position">The position.</param>
        /// <param name="forward">The forward direction to get the angle relative to.</param>
        /// <param name="target">The target.</param>
        /// <returns>The angle in degrees from a position towards a target around the global Y axis. This will be from -180 to 180 degrees.</returns>
        public static float Angle(this Vector2 position, Vector3 forward, Vector2 target) => position.Angle(forward.Flatten(), target);
        
        /// <summary>
        /// The angle in degrees from a position towards a target around the global Y axis. This will be from -180 to 180 degrees.
        /// </summary>
        /// <param name="position">The position.</param>
        /// <param name="forward">The forward direction to get the angle relative to.</param>
        /// <param name="target">The target.</param>
        /// <returns>The angle in degrees from a position towards a target around the global Y axis. This will be from -180 to 180 degrees.</returns>
        public static float Angle(this Vector2 position, Vector3 forward, Vector3 target) => position.Angle(forward.Flatten(), target.Flatten());
        
        /// <summary>
        /// The angle in degrees from a position towards a target around the global Y axis. This will be from -180 to 180 degrees.
        /// </summary>
        /// <param name="position">The position.</param>
        /// <param name="forward">The forward direction to get the angle relative to.</param>
        /// <param name="target">The target.</param>
        /// <returns>The angle in degrees from a position towards a target around the global Y axis. This will be from -180 to 180 degrees.</returns>
        public static float Angle(this Vector2 position, Vector3 forward, [NotNull] Transform target) => position.Angle(forward.Flatten(), target.Flatten());
        
        /// <summary>
        /// The angle in degrees from a position towards a target around the global Y axis. This will be from -180 to 180 degrees.
        /// </summary>
        /// <param name="position">The position.</param>
        /// <param name="forward">The forward direction to get the angle relative to.</param>
        /// <param name="target">The target.</param>
        /// <returns>The angle in degrees from a position towards a target around the global Y axis. This will be from -180 to 180 degrees.</returns>
        public static float Angle(this Vector2 position, Vector3 forward, [NotNull] Component target) => position.Angle(forward.Flatten(), target.Flatten());
        
        /// <summary>
        /// The angle in degrees from a position towards a target around the global Y axis. This will be from -180 to 180 degrees.
        /// </summary>
        /// <param name="position">The position.</param>
        /// <param name="forward">The forward direction to get the angle relative to.</param>
        /// <param name="target">The target.</param>
        /// <returns>The angle in degrees from a position towards a target around the global Y axis. This will be from -180 to 180 degrees.</returns>
        public static float Angle(this Vector2 position, Vector3 forward, [NotNull] GameObject target) => position.Angle(forward.Flatten(), target.Flatten());
        
        /// <summary>
        /// The angle in degrees from a position towards a target around the global Y axis. This will be from -180 to 180 degrees.
        /// </summary>
        /// <param name="position">The position.</param>
        /// <param name="forward">The forward direction to get the angle relative to.</param>
        /// <param name="target">The target.</param>
        /// <returns>The angle in degrees from a position towards a target around the global Y axis. This will be from -180 to 180 degrees.</returns>
        public static float Angle(this Vector2 position, [NotNull] Transform forward, Vector2 target) => position.Angle(forward.forward.Flatten(), target);
        
        /// <summary>
        /// The angle in degrees from a position towards a target around the global Y axis. This will be from -180 to 180 degrees.
        /// </summary>
        /// <param name="position">The position.</param>
        /// <param name="forward">The forward direction to get the angle relative to.</param>
        /// <param name="target">The target.</param>
        /// <returns>The angle in degrees from a position towards a target around the global Y axis. This will be from -180 to 180 degrees.</returns>
        public static float Angle(this Vector2 position, [NotNull] Transform forward, Vector3 target) => position.Angle(forward.forward.Flatten(), target.Flatten());
        
        /// <summary>
        /// The angle in degrees from a position towards a target around the global Y axis. This will be from -180 to 180 degrees.
        /// </summary>
        /// <param name="position">The position.</param>
        /// <param name="forward">The forward direction to get the angle relative to.</param>
        /// <param name="target">The target.</param>
        /// <returns>The angle in degrees from a position towards a target around the global Y axis. This will be from -180 to 180 degrees.</returns>
        public static float Angle(this Vector2 position, [NotNull] Transform forward, [NotNull] Transform target) => position.Angle(forward.forward.Flatten(), target.Flatten());
        
        /// <summary>
        /// The angle in degrees from a position towards a target around the global Y axis. This will be from -180 to 180 degrees.
        /// </summary>
        /// <param name="position">The position.</param>
        /// <param name="forward">The forward direction to get the angle relative to.</param>
        /// <param name="target">The target.</param>
        /// <returns>The angle in degrees from a position towards a target around the global Y axis. This will be from -180 to 180 degrees.</returns>
        public static float Angle(this Vector2 position, [NotNull] Transform forward, [NotNull] Component target) => position.Angle(forward.forward.Flatten(), target.Flatten());
        
        /// <summary>
        /// The angle in degrees from a position towards a target around the global Y axis. This will be from -180 to 180 degrees.
        /// </summary>
        /// <param name="position">The position.</param>
        /// <param name="forward">The forward direction to get the angle relative to.</param>
        /// <param name="target">The target.</param>
        /// <returns>The angle in degrees from a position towards a target around the global Y axis. This will be from -180 to 180 degrees.</returns>
        public static float Angle(this Vector2 position, [NotNull] Transform forward, [NotNull] GameObject target) => position.Angle(forward.forward.Flatten(), target.Flatten());
        
        /// <summary>
        /// The angle in degrees from a position towards a target around the global Y axis. This will be from -180 to 180 degrees.
        /// </summary>
        /// <param name="position">The position.</param>
        /// <param name="forward">The forward direction to get the angle relative to.</param>
        /// <param name="target">The target.</param>
        /// <returns>The angle in degrees from a position towards a target around the global Y axis. This will be from -180 to 180 degrees.</returns>
        public static float Angle(this Vector2 position, [NotNull] Component forward, Vector2 target) => position.Angle(forward.transform.forward.Flatten(), target);
        
        /// <summary>
        /// The angle in degrees from a position towards a target around the global Y axis. This will be from -180 to 180 degrees.
        /// </summary>
        /// <param name="position">The position.</param>
        /// <param name="forward">The forward direction to get the angle relative to.</param>
        /// <param name="target">The target.</param>
        /// <returns>The angle in degrees from a position towards a target around the global Y axis. This will be from -180 to 180 degrees.</returns>
        public static float Angle(this Vector2 position, [NotNull] Component forward, Vector3 target) => position.Angle(forward.transform.forward.Flatten(), target.Flatten());
        
        /// <summary>
        /// The angle in degrees from a position towards a target around the global Y axis. This will be from -180 to 180 degrees.
        /// </summary>
        /// <param name="position">The position.</param>
        /// <param name="forward">The forward direction to get the angle relative to.</param>
        /// <param name="target">The target.</param>
        /// <returns>The angle in degrees from a position towards a target around the global Y axis. This will be from -180 to 180 degrees.</returns>
        public static float Angle(this Vector2 position, [NotNull] Component forward, [NotNull] Transform target) => position.Angle(forward.transform.forward.Flatten(), target.Flatten());
        
        /// <summary>
        /// The angle in degrees from a position towards a target around the global Y axis. This will be from -180 to 180 degrees.
        /// </summary>
        /// <param name="position">The position.</param>
        /// <param name="forward">The forward direction to get the angle relative to.</param>
        /// <param name="target">The target.</param>
        /// <returns>The angle in degrees from a position towards a target around the global Y axis. This will be from -180 to 180 degrees.</returns>
        public static float Angle(this Vector2 position, [NotNull] Component forward, [NotNull] Component target) => position.Angle(forward.transform.forward.Flatten(), target.Flatten());
        
        /// <summary>
        /// The angle in degrees from a position towards a target around the global Y axis. This will be from -180 to 180 degrees.
        /// </summary>
        /// <param name="position">The position.</param>
        /// <param name="forward">The forward direction to get the angle relative to.</param>
        /// <param name="target">The target.</param>
        /// <returns>The angle in degrees from a position towards a target around the global Y axis. This will be from -180 to 180 degrees.</returns>
        public static float Angle(this Vector2 position, [NotNull] Component forward, [NotNull] GameObject target) => position.Angle(forward.transform.forward.Flatten(), target.Flatten());
        
        /// <summary>
        /// The angle in degrees from a position towards a target around the global Y axis. This will be from -180 to 180 degrees.
        /// </summary>
        /// <param name="position">The position.</param>
        /// <param name="forward">The forward direction to get the angle relative to.</param>
        /// <param name="target">The target.</param>
        /// <returns>The angle in degrees from a position towards a target around the global Y axis. This will be from -180 to 180 degrees.</returns>
        public static float Angle(this Vector2 position, [NotNull] GameObject forward, Vector2 target) => position.Angle(forward.transform.forward.Flatten(), target);
        
        /// <summary>
        /// The angle in degrees from a position towards a target around the global Y axis. This will be from -180 to 180 degrees.
        /// </summary>
        /// <param name="position">The position.</param>
        /// <param name="forward">The forward direction to get the angle relative to.</param>
        /// <param name="target">The target.</param>
        /// <returns>The angle in degrees from a position towards a target around the global Y axis. This will be from -180 to 180 degrees.</returns>
        public static float Angle(this Vector2 position, [NotNull] GameObject forward, Vector3 target) => position.Angle(forward.transform.forward.Flatten(), target.Flatten());
        
        /// <summary>
        /// The angle in degrees from a position towards a target around the global Y axis. This will be from -180 to 180 degrees.
        /// </summary>
        /// <param name="position">The position.</param>
        /// <param name="forward">The forward direction to get the angle relative to.</param>
        /// <param name="target">The target.</param>
        /// <returns>The angle in degrees from a position towards a target around the global Y axis. This will be from -180 to 180 degrees.</returns>
        public static float Angle(this Vector2 position, [NotNull] GameObject forward, [NotNull] Transform target) => position.Angle(forward.transform.forward.Flatten(), target.Flatten());
        
        /// <summary>
        /// The angle in degrees from a position towards a target around the global Y axis. This will be from -180 to 180 degrees.
        /// </summary>
        /// <param name="position">The position.</param>
        /// <param name="forward">The forward direction to get the angle relative to.</param>
        /// <param name="target">The target.</param>
        /// <returns>The angle in degrees from a position towards a target around the global Y axis. This will be from -180 to 180 degrees.</returns>
        public static float Angle(this Vector2 position, [NotNull] GameObject forward, [NotNull] Component target) => position.Angle(forward.transform.forward.Flatten(), target.Flatten());
        
        /// <summary>
        /// The angle in degrees from a position towards a target around the global Y axis. This will be from -180 to 180 degrees.
        /// </summary>
        /// <param name="position">The position.</param>
        /// <param name="forward">The forward direction to get the angle relative to.</param>
        /// <param name="target">The target.</param>
        /// <returns>The angle in degrees from a position towards a target around the global Y axis. This will be from -180 to 180 degrees.</returns>
        public static float Angle(this Vector2 position, [NotNull] GameObject forward, [NotNull] GameObject target) => position.Angle(forward.transform.forward.Flatten(), target.Flatten());
        
        /// <summary>
        /// The angle in degrees from a position towards a target around the global Y axis. This will be from -180 to 180 degrees.
        /// </summary>
        /// <param name="position">The position.</param>
        /// <param name="forward">The forward direction to get the angle relative to.</param>
        /// <param name="target">The target.</param>
        /// <returns>The angle in degrees from a position towards a target around the global Y axis. This will be from -180 to 180 degrees.</returns>
        public static float Angle(this Vector3 position, Vector2 forward, Vector2 target) => position.Flatten().Angle(forward, target);
        
        /// <summary>
        /// The angle in degrees from a position towards a target around the global Y axis. This will be from -180 to 180 degrees.
        /// </summary>
        /// <param name="position">The position.</param>
        /// <param name="forward">The forward direction to get the angle relative to.</param>
        /// <param name="target">The target.</param>
        /// <returns>The angle in degrees from a position towards a target around the global Y axis. This will be from -180 to 180 degrees.</returns>
        public static float Angle(this Vector3 position, Vector2 forward, Vector3 target) => position.Flatten().Angle(forward, target.Flatten());
        
        /// <summary>
        /// The angle in degrees from a position towards a target around the global Y axis. This will be from -180 to 180 degrees.
        /// </summary>
        /// <param name="position">The position.</param>
        /// <param name="forward">The forward direction to get the angle relative to.</param>
        /// <param name="target">The target.</param>
        /// <returns>The angle in degrees from a position towards a target around the global Y axis. This will be from -180 to 180 degrees.</returns>
        public static float Angle(this Vector3 position, Vector2 forward, [NotNull] Transform target) => position.Flatten().Angle(forward, target.Flatten());
        
        /// <summary>
        /// The angle in degrees from a position towards a target around the global Y axis. This will be from -180 to 180 degrees.
        /// </summary>
        /// <param name="position">The position.</param>
        /// <param name="forward">The forward direction to get the angle relative to.</param>
        /// <param name="target">The target.</param>
        /// <returns>The angle in degrees from a position towards a target around the global Y axis. This will be from -180 to 180 degrees.</returns>
        public static float Angle(this Vector3 position, Vector2 forward, [NotNull] Component target) => position.Flatten().Angle(forward, target.Flatten());
        
        /// <summary>
        /// The angle in degrees from a position towards a target around the global Y axis. This will be from -180 to 180 degrees.
        /// </summary>
        /// <param name="position">The position.</param>
        /// <param name="forward">The forward direction to get the angle relative to.</param>
        /// <param name="target">The target.</param>
        /// <returns>The angle in degrees from a position towards a target around the global Y axis. This will be from -180 to 180 degrees.</returns>
        public static float Angle(this Vector3 position, Vector2 forward, [NotNull] GameObject target) => position.Flatten().Angle(forward, target.Flatten());
        
        /// <summary>
        /// The angle in degrees from a position towards a target around the global Y axis. This will be from -180 to 180 degrees.
        /// </summary>
        /// <param name="position">The position.</param>
        /// <param name="forward">The forward direction to get the angle relative to.</param>
        /// <param name="target">The target.</param>
        /// <returns>The angle in degrees from a position towards a target around the global Y axis. This will be from -180 to 180 degrees.</returns>
        public static float Angle(this Vector3 position, Vector3 forward, Vector2 target) => position.Flatten().Angle(forward.Flatten(), target);
        
        /// <summary>
        /// The angle in degrees from a position towards a target around the global Y axis. This will be from -180 to 180 degrees.
        /// </summary>
        /// <param name="position">The position.</param>
        /// <param name="forward">The forward direction to get the angle relative to.</param>
        /// <param name="target">The target.</param>
        /// <returns>The angle in degrees from a position towards a target around the global Y axis. This will be from -180 to 180 degrees.</returns>
        public static float Angle(this Vector3 position, Vector3 forward, Vector3 target) => position.Flatten().Angle(forward.Flatten(), target.Flatten());
        
        /// <summary>
        /// The angle in degrees from a position towards a target around the global Y axis. This will be from -180 to 180 degrees.
        /// </summary>
        /// <param name="position">The position.</param>
        /// <param name="forward">The forward direction to get the angle relative to.</param>
        /// <param name="target">The target.</param>
        /// <returns>The angle in degrees from a position towards a target around the global Y axis. This will be from -180 to 180 degrees.</returns>
        public static float Angle(this Vector3 position, Vector3 forward, [NotNull] Transform target) => position.Flatten().Angle(forward.Flatten(), target.Flatten());
        
        /// <summary>
        /// The angle in degrees from a position towards a target around the global Y axis. This will be from -180 to 180 degrees.
        /// </summary>
        /// <param name="position">The position.</param>
        /// <param name="forward">The forward direction to get the angle relative to.</param>
        /// <param name="target">The target.</param>
        /// <returns>The angle in degrees from a position towards a target around the global Y axis. This will be from -180 to 180 degrees.</returns>
        public static float Angle(this Vector3 position, Vector3 forward, [NotNull] Component target) => position.Flatten().Angle(forward.Flatten(), target.Flatten());
        
        /// <summary>
        /// The angle in degrees from a position towards a target around the global Y axis. This will be from -180 to 180 degrees.
        /// </summary>
        /// <param name="position">The position.</param>
        /// <param name="forward">The forward direction to get the angle relative to.</param>
        /// <param name="target">The target.</param>
        /// <returns>The angle in degrees from a position towards a target around the global Y axis. This will be from -180 to 180 degrees.</returns>
        public static float Angle(this Vector3 position, Vector3 forward, [NotNull] GameObject target) => position.Flatten().Angle(forward.Flatten(), target.Flatten());
        
        /// <summary>
        /// The angle in degrees from a position towards a target around the global Y axis. This will be from -180 to 180 degrees.
        /// </summary>
        /// <param name="position">The position.</param>
        /// <param name="forward">The forward direction to get the angle relative to.</param>
        /// <param name="target">The target.</param>
        /// <returns>The angle in degrees from a position towards a target around the global Y axis. This will be from -180 to 180 degrees.</returns>
        public static float Angle(this Vector3 position, [NotNull] Transform forward, Vector2 target) => position.Flatten().Angle(forward.forward.Flatten(), target);
        
        /// <summary>
        /// The angle in degrees from a position towards a target around the global Y axis. This will be from -180 to 180 degrees.
        /// </summary>
        /// <param name="position">The position.</param>
        /// <param name="forward">The forward direction to get the angle relative to.</param>
        /// <param name="target">The target.</param>
        /// <returns>The angle in degrees from a position towards a target around the global Y axis. This will be from -180 to 180 degrees.</returns>
        public static float Angle(this Vector3 position, [NotNull] Transform forward, Vector3 target) => position.Flatten().Angle(forward.forward.Flatten(), target.Flatten());
        
        /// <summary>
        /// The angle in degrees from a position towards a target around the global Y axis. This will be from -180 to 180 degrees.
        /// </summary>
        /// <param name="position">The position.</param>
        /// <param name="forward">The forward direction to get the angle relative to.</param>
        /// <param name="target">The target.</param>
        /// <returns>The angle in degrees from a position towards a target around the global Y axis. This will be from -180 to 180 degrees.</returns>
        public static float Angle(this Vector3 position, [NotNull] Transform forward, [NotNull] Transform target) => position.Flatten().Angle(forward.forward.Flatten(), target.Flatten());
        
        /// <summary>
        /// The angle in degrees from a position towards a target around the global Y axis. This will be from -180 to 180 degrees.
        /// </summary>
        /// <param name="position">The position.</param>
        /// <param name="forward">The forward direction to get the angle relative to.</param>
        /// <param name="target">The target.</param>
        /// <returns>The angle in degrees from a position towards a target around the global Y axis. This will be from -180 to 180 degrees.</returns>
        public static float Angle(this Vector3 position, [NotNull] Transform forward, [NotNull] Component target) => position.Flatten().Angle(forward.forward.Flatten(), target.Flatten());
        
        /// <summary>
        /// The angle in degrees from a position towards a target around the global Y axis. This will be from -180 to 180 degrees.
        /// </summary>
        /// <param name="position">The position.</param>
        /// <param name="forward">The forward direction to get the angle relative to.</param>
        /// <param name="target">The target.</param>
        /// <returns>The angle in degrees from a position towards a target around the global Y axis. This will be from -180 to 180 degrees.</returns>
        public static float Angle(this Vector3 position, [NotNull] Transform forward, [NotNull] GameObject target) => position.Flatten().Angle(forward.forward.Flatten(), target.Flatten());
        
        /// <summary>
        /// The angle in degrees from a position towards a target around the global Y axis. This will be from -180 to 180 degrees.
        /// </summary>
        /// <param name="position">The position.</param>
        /// <param name="forward">The forward direction to get the angle relative to.</param>
        /// <param name="target">The target.</param>
        /// <returns>The angle in degrees from a position towards a target around the global Y axis. This will be from -180 to 180 degrees.</returns>
        public static float Angle(this Vector3 position, [NotNull] Component forward, Vector2 target) => position.Flatten().Angle(forward.transform.forward.Flatten(), target);
        
        /// <summary>
        /// The angle in degrees from a position towards a target around the global Y axis. This will be from -180 to 180 degrees.
        /// </summary>
        /// <param name="position">The position.</param>
        /// <param name="forward">The forward direction to get the angle relative to.</param>
        /// <param name="target">The target.</param>
        /// <returns>The angle in degrees from a position towards a target around the global Y axis. This will be from -180 to 180 degrees.</returns>
        public static float Angle(this Vector3 position, [NotNull] Component forward, Vector3 target) => position.Flatten().Angle(forward.transform.forward.Flatten(), target.Flatten());
        
        /// <summary>
        /// The angle in degrees from a position towards a target around the global Y axis. This will be from -180 to 180 degrees.
        /// </summary>
        /// <param name="position">The position.</param>
        /// <param name="forward">The forward direction to get the angle relative to.</param>
        /// <param name="target">The target.</param>
        /// <returns>The angle in degrees from a position towards a target around the global Y axis. This will be from -180 to 180 degrees.</returns>
        public static float Angle(this Vector3 position, [NotNull] Component forward, [NotNull] Transform target) => position.Flatten().Angle(forward.transform.forward.Flatten(), target.Flatten());
        
        /// <summary>
        /// The angle in degrees from a position towards a target around the global Y axis. This will be from -180 to 180 degrees.
        /// </summary>
        /// <param name="position">The position.</param>
        /// <param name="forward">The forward direction to get the angle relative to.</param>
        /// <param name="target">The target.</param>
        /// <returns>The angle in degrees from a position towards a target around the global Y axis. This will be from -180 to 180 degrees.</returns>
        public static float Angle(this Vector3 position, [NotNull] Component forward, [NotNull] Component target) => position.Flatten().Angle(forward.transform.forward.Flatten(), target.Flatten());
        
        /// <summary>
        /// The angle in degrees from a position towards a target around the global Y axis. This will be from -180 to 180 degrees.
        /// </summary>
        /// <param name="position">The position.</param>
        /// <param name="forward">The forward direction to get the angle relative to.</param>
        /// <param name="target">The target.</param>
        /// <returns>The angle in degrees from a position towards a target around the global Y axis. This will be from -180 to 180 degrees.</returns>
        public static float Angle(this Vector3 position, [NotNull] Component forward, [NotNull] GameObject target) => position.Flatten().Angle(forward.transform.forward.Flatten(), target.Flatten());
        
        /// <summary>
        /// The angle in degrees from a position towards a target around the global Y axis. This will be from -180 to 180 degrees.
        /// </summary>
        /// <param name="position">The position.</param>
        /// <param name="forward">The forward direction to get the angle relative to.</param>
        /// <param name="target">The target.</param>
        /// <returns>The angle in degrees from a position towards a target around the global Y axis. This will be from -180 to 180 degrees.</returns>
        public static float Angle(this Vector3 position, [NotNull] GameObject forward, Vector2 target) => position.Flatten().Angle(forward.transform.forward.Flatten(), target);
        
        /// <summary>
        /// The angle in degrees from a position towards a target around the global Y axis. This will be from -180 to 180 degrees.
        /// </summary>
        /// <param name="position">The position.</param>
        /// <param name="forward">The forward direction to get the angle relative to.</param>
        /// <param name="target">The target.</param>
        /// <returns>The angle in degrees from a position towards a target around the global Y axis. This will be from -180 to 180 degrees.</returns>
        public static float Angle(this Vector3 position, [NotNull] GameObject forward, Vector3 target) => position.Flatten().Angle(forward.transform.forward.Flatten(), target.Flatten());
        
        /// <summary>
        /// The angle in degrees from a position towards a target around the global Y axis. This will be from -180 to 180 degrees.
        /// </summary>
        /// <param name="position">The position.</param>
        /// <param name="forward">The forward direction to get the angle relative to.</param>
        /// <param name="target">The target.</param>
        /// <returns>The angle in degrees from a position towards a target around the global Y axis. This will be from -180 to 180 degrees.</returns>
        public static float Angle(this Vector3 position, [NotNull] GameObject forward, [NotNull] Transform target) => position.Flatten().Angle(forward.transform.forward.Flatten(), target.Flatten());
        
        /// <summary>
        /// The angle in degrees from a position towards a target around the global Y axis. This will be from -180 to 180 degrees.
        /// </summary>
        /// <param name="position">The position.</param>
        /// <param name="forward">The forward direction to get the angle relative to.</param>
        /// <param name="target">The target.</param>
        /// <returns>The angle in degrees from a position towards a target around the global Y axis. This will be from -180 to 180 degrees.</returns>
        public static float Angle(this Vector3 position, [NotNull] GameObject forward, [NotNull] Component target) => position.Flatten().Angle(forward.transform.forward.Flatten(), target.Flatten());
        
        /// <summary>
        /// The angle in degrees from a position towards a target around the global Y axis. This will be from -180 to 180 degrees.
        /// </summary>
        /// <param name="position">The position.</param>
        /// <param name="forward">The forward direction to get the angle relative to.</param>
        /// <param name="target">The target.</param>
        /// <returns>The angle in degrees from a position towards a target around the global Y axis. This will be from -180 to 180 degrees.</returns>
        public static float Angle(this Vector3 position, [NotNull] GameObject forward, [NotNull] GameObject target) => position.Flatten().Angle(forward.transform.forward.Flatten(), target.Flatten());
        
        /// <summary>
        /// The angle in degrees from a position towards a target around the global Y axis. This will be from -180 to 180 degrees.
        /// </summary>
        /// <param name="position">The position.</param>
        /// <param name="forward">The forward direction to get the angle relative to.</param>
        /// <param name="target">The target.</param>
        /// <returns>The angle in degrees from a position towards a target around the global Y axis. This will be from -180 to 180 degrees.</returns>
        public static float Angle([NotNull] this Transform position, Vector2 forward, Vector2 target) => position.Flatten().Angle(forward, target);
        
        /// <summary>
        /// The angle in degrees from a position towards a target around the global Y axis. This will be from -180 to 180 degrees.
        /// </summary>
        /// <param name="position">The position.</param>
        /// <param name="forward">The forward direction to get the angle relative to.</param>
        /// <param name="target">The target.</param>
        /// <returns>The angle in degrees from a position towards a target around the global Y axis. This will be from -180 to 180 degrees.</returns>
        public static float Angle([NotNull] this Transform position, Vector2 forward, Vector3 target) => position.Flatten().Angle(forward, target.Flatten());
        
        /// <summary>
        /// The angle in degrees from a position towards a target around the global Y axis. This will be from -180 to 180 degrees.
        /// </summary>
        /// <param name="position">The position.</param>
        /// <param name="forward">The forward direction to get the angle relative to.</param>
        /// <param name="target">The target.</param>
        /// <returns>The angle in degrees from a position towards a target around the global Y axis. This will be from -180 to 180 degrees.</returns>
        public static float Angle([NotNull] this Transform position, Vector2 forward, [NotNull] Transform target) => position.Flatten().Angle(forward, target.Flatten());
        
        /// <summary>
        /// The angle in degrees from a position towards a target around the global Y axis. This will be from -180 to 180 degrees.
        /// </summary>
        /// <param name="position">The position.</param>
        /// <param name="forward">The forward direction to get the angle relative to.</param>
        /// <param name="target">The target.</param>
        /// <returns>The angle in degrees from a position towards a target around the global Y axis. This will be from -180 to 180 degrees.</returns>
        public static float Angle([NotNull] this Transform position, Vector2 forward, [NotNull] Component target) => position.Flatten().Angle(forward, target.Flatten());
        
        /// <summary>
        /// The angle in degrees from a position towards a target around the global Y axis. This will be from -180 to 180 degrees.
        /// </summary>
        /// <param name="position">The position.</param>
        /// <param name="forward">The forward direction to get the angle relative to.</param>
        /// <param name="target">The target.</param>
        /// <returns>The angle in degrees from a position towards a target around the global Y axis. This will be from -180 to 180 degrees.</returns>
        public static float Angle([NotNull] this Transform position, Vector2 forward, [NotNull] GameObject target) => position.Flatten().Angle(forward, target.Flatten());
        
        /// <summary>
        /// The angle in degrees from a position towards a target around the global Y axis. This will be from -180 to 180 degrees.
        /// </summary>
        /// <param name="position">The position.</param>
        /// <param name="forward">The forward direction to get the angle relative to.</param>
        /// <param name="target">The target.</param>
        /// <returns>The angle in degrees from a position towards a target around the global Y axis. This will be from -180 to 180 degrees.</returns>
        public static float Angle([NotNull] this Transform position, Vector3 forward, Vector2 target) => position.Flatten().Angle(forward.Flatten(), target);
        
        /// <summary>
        /// The angle in degrees from a position towards a target around the global Y axis. This will be from -180 to 180 degrees.
        /// </summary>
        /// <param name="position">The position.</param>
        /// <param name="forward">The forward direction to get the angle relative to.</param>
        /// <param name="target">The target.</param>
        /// <returns>The angle in degrees from a position towards a target around the global Y axis. This will be from -180 to 180 degrees.</returns>
        public static float Angle([NotNull] this Transform position, Vector3 forward, Vector3 target) => position.Flatten().Angle(forward.Flatten(), target.Flatten());
        
        /// <summary>
        /// The angle in degrees from a position towards a target around the global Y axis. This will be from -180 to 180 degrees.
        /// </summary>
        /// <param name="position">The position.</param>
        /// <param name="forward">The forward direction to get the angle relative to.</param>
        /// <param name="target">The target.</param>
        /// <returns>The angle in degrees from a position towards a target around the global Y axis. This will be from -180 to 180 degrees.</returns>
        public static float Angle([NotNull] this Transform position, Vector3 forward, [NotNull] Transform target) => position.Flatten().Angle(forward.Flatten(), target.Flatten());
        
        /// <summary>
        /// The angle in degrees from a position towards a target around the global Y axis. This will be from -180 to 180 degrees.
        /// </summary>
        /// <param name="position">The position.</param>
        /// <param name="forward">The forward direction to get the angle relative to.</param>
        /// <param name="target">The target.</param>
        /// <returns>The angle in degrees from a position towards a target around the global Y axis. This will be from -180 to 180 degrees.</returns>
        public static float Angle([NotNull] this Transform position, Vector3 forward, [NotNull] Component target) => position.Flatten().Angle(forward.Flatten(), target.Flatten());
        
        /// <summary>
        /// The angle in degrees from a position towards a target around the global Y axis. This will be from -180 to 180 degrees.
        /// </summary>
        /// <param name="position">The position.</param>
        /// <param name="forward">The forward direction to get the angle relative to.</param>
        /// <param name="target">The target.</param>
        /// <returns>The angle in degrees from a position towards a target around the global Y axis. This will be from -180 to 180 degrees.</returns>
        public static float Angle([NotNull] this Transform position, Vector3 forward, [NotNull] GameObject target) => position.Flatten().Angle(forward.Flatten(), target.Flatten());
        
        /// <summary>
        /// The angle in degrees from a position towards a target around the global Y axis. This will be from -180 to 180 degrees.
        /// </summary>
        /// <param name="position">The position.</param>
        /// <param name="forward">The forward direction to get the angle relative to.</param>
        /// <param name="target">The target.</param>
        /// <returns>The angle in degrees from a position towards a target around the global Y axis. This will be from -180 to 180 degrees.</returns>
        public static float Angle([NotNull] this Transform position, [NotNull] Transform forward, Vector2 target) => position.Flatten().Angle(forward.forward.Flatten(), target);
        
        /// <summary>
        /// The angle in degrees from a position towards a target around the global Y axis. This will be from -180 to 180 degrees.
        /// </summary>
        /// <param name="position">The position.</param>
        /// <param name="forward">The forward direction to get the angle relative to.</param>
        /// <param name="target">The target.</param>
        /// <returns>The angle in degrees from a position towards a target around the global Y axis. This will be from -180 to 180 degrees.</returns>
        public static float Angle([NotNull] this Transform position, [NotNull] Transform forward, Vector3 target) => position.Flatten().Angle(forward.forward.Flatten(), target.Flatten());
        
        /// <summary>
        /// The angle in degrees from a position towards a target around the global Y axis. This will be from -180 to 180 degrees.
        /// </summary>
        /// <param name="position">The position.</param>
        /// <param name="forward">The forward direction to get the angle relative to.</param>
        /// <param name="target">The target.</param>
        /// <returns>The angle in degrees from a position towards a target around the global Y axis. This will be from -180 to 180 degrees.</returns>
        public static float Angle([NotNull] this Transform position, [NotNull] Transform forward, [NotNull] Transform target) => position.Flatten().Angle(forward.forward.Flatten(), target.Flatten());
        
        /// <summary>
        /// The angle in degrees from a position towards a target around the global Y axis. This will be from -180 to 180 degrees.
        /// </summary>
        /// <param name="position">The position.</param>
        /// <param name="forward">The forward direction to get the angle relative to.</param>
        /// <param name="target">The target.</param>
        /// <returns>The angle in degrees from a position towards a target around the global Y axis. This will be from -180 to 180 degrees.</returns>
        public static float Angle([NotNull] this Transform position, [NotNull] Transform forward, [NotNull] Component target) => position.Flatten().Angle(forward.forward.Flatten(), target.Flatten());
        
        /// <summary>
        /// The angle in degrees from a position towards a target around the global Y axis. This will be from -180 to 180 degrees.
        /// </summary>
        /// <param name="position">The position.</param>
        /// <param name="forward">The forward direction to get the angle relative to.</param>
        /// <param name="target">The target.</param>
        /// <returns>The angle in degrees from a position towards a target around the global Y axis. This will be from -180 to 180 degrees.</returns>
        public static float Angle([NotNull] this Transform position, [NotNull] Transform forward, [NotNull] GameObject target) => position.Flatten().Angle(forward.forward.Flatten(), target.Flatten());
        
        /// <summary>
        /// The angle in degrees from a position towards a target around the global Y axis. This will be from -180 to 180 degrees.
        /// </summary>
        /// <param name="position">The position.</param>
        /// <param name="forward">The forward direction to get the angle relative to.</param>
        /// <param name="target">The target.</param>
        /// <returns>The angle in degrees from a position towards a target around the global Y axis. This will be from -180 to 180 degrees.</returns>
        public static float Angle([NotNull] this Transform position, [NotNull] Component forward, Vector2 target) => position.Flatten().Angle(forward.transform.forward.Flatten(), target);
        
        /// <summary>
        /// The angle in degrees from a position towards a target around the global Y axis. This will be from -180 to 180 degrees.
        /// </summary>
        /// <param name="position">The position.</param>
        /// <param name="forward">The forward direction to get the angle relative to.</param>
        /// <param name="target">The target.</param>
        /// <returns>The angle in degrees from a position towards a target around the global Y axis. This will be from -180 to 180 degrees.</returns>
        public static float Angle([NotNull] this Transform position, [NotNull] Component forward, Vector3 target) => position.Flatten().Angle(forward.transform.forward.Flatten(), target.Flatten());
        
        /// <summary>
        /// The angle in degrees from a position towards a target around the global Y axis. This will be from -180 to 180 degrees.
        /// </summary>
        /// <param name="position">The position.</param>
        /// <param name="forward">The forward direction to get the angle relative to.</param>
        /// <param name="target">The target.</param>
        /// <returns>The angle in degrees from a position towards a target around the global Y axis. This will be from -180 to 180 degrees.</returns>
        public static float Angle([NotNull] this Transform position, [NotNull] Component forward, [NotNull] Transform target) => position.Flatten().Angle(forward.transform.forward.Flatten(), target.Flatten());
        
        /// <summary>
        /// The angle in degrees from a position towards a target around the global Y axis. This will be from -180 to 180 degrees.
        /// </summary>
        /// <param name="position">The position.</param>
        /// <param name="forward">The forward direction to get the angle relative to.</param>
        /// <param name="target">The target.</param>
        /// <returns>The angle in degrees from a position towards a target around the global Y axis. This will be from -180 to 180 degrees.</returns>
        public static float Angle([NotNull] this Transform position, [NotNull] Component forward, [NotNull] Component target) => position.Flatten().Angle(forward.transform.forward.Flatten(), target.Flatten());
        
        /// <summary>
        /// The angle in degrees from a position towards a target around the global Y axis. This will be from -180 to 180 degrees.
        /// </summary>
        /// <param name="position">The position.</param>
        /// <param name="forward">The forward direction to get the angle relative to.</param>
        /// <param name="target">The target.</param>
        /// <returns>The angle in degrees from a position towards a target around the global Y axis. This will be from -180 to 180 degrees.</returns>
        public static float Angle([NotNull] this Transform position, [NotNull] Component forward, [NotNull] GameObject target) => position.Flatten().Angle(forward.transform.forward.Flatten(), target.Flatten());
        
        /// <summary>
        /// The angle in degrees from a position towards a target around the global Y axis. This will be from -180 to 180 degrees.
        /// </summary>
        /// <param name="position">The position.</param>
        /// <param name="forward">The forward direction to get the angle relative to.</param>
        /// <param name="target">The target.</param>
        /// <returns>The angle in degrees from a position towards a target around the global Y axis. This will be from -180 to 180 degrees.</returns>
        public static float Angle([NotNull] this Transform position, [NotNull] GameObject forward, Vector2 target) => position.Flatten().Angle(forward.transform.forward.Flatten(), target);
        
        /// <summary>
        /// The angle in degrees from a position towards a target around the global Y axis. This will be from -180 to 180 degrees.
        /// </summary>
        /// <param name="position">The position.</param>
        /// <param name="forward">The forward direction to get the angle relative to.</param>
        /// <param name="target">The target.</param>
        /// <returns>The angle in degrees from a position towards a target around the global Y axis. This will be from -180 to 180 degrees.</returns>
        public static float Angle([NotNull] this Transform position, [NotNull] GameObject forward, Vector3 target) => position.Flatten().Angle(forward.transform.forward.Flatten(), target.Flatten());
        
        /// <summary>
        /// The angle in degrees from a position towards a target around the global Y axis. This will be from -180 to 180 degrees.
        /// </summary>
        /// <param name="position">The position.</param>
        /// <param name="forward">The forward direction to get the angle relative to.</param>
        /// <param name="target">The target.</param>
        /// <returns>The angle in degrees from a position towards a target around the global Y axis. This will be from -180 to 180 degrees.</returns>
        public static float Angle([NotNull] this Transform position, [NotNull] GameObject forward, [NotNull] Transform target) => position.Flatten().Angle(forward.transform.forward.Flatten(), target.Flatten());
        
        /// <summary>
        /// The angle in degrees from a position towards a target around the global Y axis. This will be from -180 to 180 degrees.
        /// </summary>
        /// <param name="position">The position.</param>
        /// <param name="forward">The forward direction to get the angle relative to.</param>
        /// <param name="target">The target.</param>
        /// <returns>The angle in degrees from a position towards a target around the global Y axis. This will be from -180 to 180 degrees.</returns>
        public static float Angle([NotNull] this Transform position, [NotNull] GameObject forward, [NotNull] Component target) => position.Flatten().Angle(forward.transform.forward.Flatten(), target.Flatten());
        
        /// <summary>
        /// The angle in degrees from a position towards a target around the global Y axis. This will be from -180 to 180 degrees.
        /// </summary>
        /// <param name="position">The position.</param>
        /// <param name="forward">The forward direction to get the angle relative to.</param>
        /// <param name="target">The target.</param>
        /// <returns>The angle in degrees from a position towards a target around the global Y axis. This will be from -180 to 180 degrees.</returns>
        public static float Angle([NotNull] this Transform position, [NotNull] GameObject forward, [NotNull] GameObject target) => position.Flatten().Angle(forward.transform.forward.Flatten(), target.Flatten());
        
        /// <summary>
        /// The angle in degrees from a position towards a target around the global Y axis. This will be from -180 to 180 degrees.
        /// </summary>
        /// <param name="position">The position with the direction being its forward.</param>
        /// <param name="target">The target.</param>
        /// <returns>The angle in degrees from a position towards a target around the global Y axis. This will be from -180 to 180 degrees.</returns>
        public static float Angle([NotNull] this Transform position, Vector2 target) => position.Flatten().Angle(position.forward.Flatten(), target);
        
        /// <summary>
        /// The angle in degrees from a position towards a target around the global Y axis. This will be from -180 to 180 degrees.
        /// </summary>
        /// <param name="position">The position with the direction being its forward.</param>
        /// <param name="target">The target.</param>
        /// <returns>The angle in degrees from a position towards a target around the global Y axis. This will be from -180 to 180 degrees.</returns>
        public static float Angle([NotNull] this Transform position, Vector3 target) => position.Flatten().Angle(position.forward.Flatten(), target.Flatten());
        
        /// <summary>
        /// The angle in degrees from a position towards a target around the global Y axis. This will be from -180 to 180 degrees.
        /// </summary>
        /// <param name="position">The position with the direction being its forward.</param>
        /// <param name="target">The target.</param>
        /// <returns>The angle in degrees from a position towards a target around the global Y axis. This will be from -180 to 180 degrees.</returns>
        public static float Angle([NotNull] this Transform position, [NotNull] Transform target) => position.Flatten().Angle(position.forward.Flatten(), target.Flatten());
        
        /// <summary>
        /// The angle in degrees from a position towards a target around the global Y axis. This will be from -180 to 180 degrees.
        /// </summary>
        /// <param name="position">The position with the direction being its forward.</param>
        /// <param name="target">The target.</param>
        /// <returns>The angle in degrees from a position towards a target around the global Y axis. This will be from -180 to 180 degrees.</returns>
        public static float Angle([NotNull] this Transform position, [NotNull] Component target) => position.Flatten().Angle(position.forward.Flatten(), target.Flatten());
        
        /// <summary>
        /// The angle in degrees from a position towards a target around the global Y axis. This will be from -180 to 180 degrees.
        /// </summary>
        /// <param name="position">The position with the direction being its forward.</param>
        /// <param name="target">The target.</param>
        /// <returns>The angle in degrees from a position towards a target around the global Y axis. This will be from -180 to 180 degrees.</returns>
        public static float Angle([NotNull] this Transform position, [NotNull] GameObject target) => position.Flatten().Angle(position.forward.Flatten(), target.Flatten());
        
        /// <summary>
        /// The angle in degrees from a position towards a target around the global Y axis. This will be from -180 to 180 degrees.
        /// </summary>
        /// <param name="position">The position.</param>
        /// <param name="forward">The forward direction to get the angle relative to.</param>
        /// <param name="target">The target.</param>
        /// <returns>The angle in degrees from a position towards a target around the global Y axis. This will be from -180 to 180 degrees.</returns>
        public static float Angle([NotNull] this Component position, Vector2 forward, Vector2 target) => position.Flatten().Angle(forward, target);
        
        /// <summary>
        /// The angle in degrees from a position towards a target around the global Y axis. This will be from -180 to 180 degrees.
        /// </summary>
        /// <param name="position">The position.</param>
        /// <param name="forward">The forward direction to get the angle relative to.</param>
        /// <param name="target">The target.</param>
        /// <returns>The angle in degrees from a position towards a target around the global Y axis. This will be from -180 to 180 degrees.</returns>
        public static float Angle([NotNull] this Component position, Vector2 forward, Vector3 target) => position.Flatten().Angle(forward, target.Flatten());
        
        /// <summary>
        /// The angle in degrees from a position towards a target around the global Y axis. This will be from -180 to 180 degrees.
        /// </summary>
        /// <param name="position">The position.</param>
        /// <param name="forward">The forward direction to get the angle relative to.</param>
        /// <param name="target">The target.</param>
        /// <returns>The angle in degrees from a position towards a target around the global Y axis. This will be from -180 to 180 degrees.</returns>
        public static float Angle([NotNull] this Component position, Vector2 forward, [NotNull] Transform target) => position.Flatten().Angle(forward, target.Flatten());
        
        /// <summary>
        /// The angle in degrees from a position towards a target around the global Y axis. This will be from -180 to 180 degrees.
        /// </summary>
        /// <param name="position">The position.</param>
        /// <param name="forward">The forward direction to get the angle relative to.</param>
        /// <param name="target">The target.</param>
        /// <returns>The angle in degrees from a position towards a target around the global Y axis. This will be from -180 to 180 degrees.</returns>
        public static float Angle([NotNull] this Component position, Vector2 forward, [NotNull] Component target) => position.Flatten().Angle(forward, target.Flatten());
        
        /// <summary>
        /// The angle in degrees from a position towards a target around the global Y axis. This will be from -180 to 180 degrees.
        /// </summary>
        /// <param name="position">The position.</param>
        /// <param name="forward">The forward direction to get the angle relative to.</param>
        /// <param name="target">The target.</param>
        /// <returns>The angle in degrees from a position towards a target around the global Y axis. This will be from -180 to 180 degrees.</returns>
        public static float Angle([NotNull] this Component position, Vector2 forward, [NotNull] GameObject target) => position.Flatten().Angle(forward, target.Flatten());
        
        /// <summary>
        /// The angle in degrees from a position towards a target around the global Y axis. This will be from -180 to 180 degrees.
        /// </summary>
        /// <param name="position">The position.</param>
        /// <param name="forward">The forward direction to get the angle relative to.</param>
        /// <param name="target">The target.</param>
        /// <returns>The angle in degrees from a position towards a target around the global Y axis. This will be from -180 to 180 degrees.</returns>
        public static float Angle([NotNull] this Component position, Vector3 forward, Vector2 target) => position.Flatten().Angle(forward.Flatten(), target);
        
        /// <summary>
        /// The angle in degrees from a position towards a target around the global Y axis. This will be from -180 to 180 degrees.
        /// </summary>
        /// <param name="position">The position.</param>
        /// <param name="forward">The forward direction to get the angle relative to.</param>
        /// <param name="target">The target.</param>
        /// <returns>The angle in degrees from a position towards a target around the global Y axis. This will be from -180 to 180 degrees.</returns>
        public static float Angle([NotNull] this Component position, Vector3 forward, Vector3 target) => position.Flatten().Angle(forward.Flatten(), target.Flatten());
        
        /// <summary>
        /// The angle in degrees from a position towards a target around the global Y axis. This will be from -180 to 180 degrees.
        /// </summary>
        /// <param name="position">The position.</param>
        /// <param name="forward">The forward direction to get the angle relative to.</param>
        /// <param name="target">The target.</param>
        /// <returns>The angle in degrees from a position towards a target around the global Y axis. This will be from -180 to 180 degrees.</returns>
        public static float Angle([NotNull] this Component position, Vector3 forward, [NotNull] Transform target) => position.Flatten().Angle(forward.Flatten(), target.Flatten());
        
        /// <summary>
        /// The angle in degrees from a position towards a target around the global Y axis. This will be from -180 to 180 degrees.
        /// </summary>
        /// <param name="position">The position.</param>
        /// <param name="forward">The forward direction to get the angle relative to.</param>
        /// <param name="target">The target.</param>
        /// <returns>The angle in degrees from a position towards a target around the global Y axis. This will be from -180 to 180 degrees.</returns>
        public static float Angle([NotNull] this Component position, Vector3 forward, [NotNull] Component target) => position.Flatten().Angle(forward.Flatten(), target.Flatten());
        
        /// <summary>
        /// The angle in degrees from a position towards a target around the global Y axis. This will be from -180 to 180 degrees.
        /// </summary>
        /// <param name="position">The position.</param>
        /// <param name="forward">The forward direction to get the angle relative to.</param>
        /// <param name="target">The target.</param>
        /// <returns>The angle in degrees from a position towards a target around the global Y axis. This will be from -180 to 180 degrees.</returns>
        public static float Angle([NotNull] this Component position, Vector3 forward, [NotNull] GameObject target) => position.Flatten().Angle(forward.Flatten(), target.Flatten());
        
        /// <summary>
        /// The angle in degrees from a position towards a target around the global Y axis. This will be from -180 to 180 degrees.
        /// </summary>
        /// <param name="position">The position.</param>
        /// <param name="forward">The forward direction to get the angle relative to.</param>
        /// <param name="target">The target.</param>
        /// <returns>The angle in degrees from a position towards a target around the global Y axis. This will be from -180 to 180 degrees.</returns>
        public static float Angle([NotNull] this Component position, [NotNull] Transform forward, Vector2 target) => position.Flatten().Angle(forward.forward.Flatten(), target);
        
        /// <summary>
        /// The angle in degrees from a position towards a target around the global Y axis. This will be from -180 to 180 degrees.
        /// </summary>
        /// <param name="position">The position.</param>
        /// <param name="forward">The forward direction to get the angle relative to.</param>
        /// <param name="target">The target.</param>
        /// <returns>The angle in degrees from a position towards a target around the global Y axis. This will be from -180 to 180 degrees.</returns>
        public static float Angle([NotNull] this Component position, [NotNull] Transform forward, Vector3 target) => position.Flatten().Angle(forward.forward.Flatten(), target.Flatten());
        
        /// <summary>
        /// The angle in degrees from a position towards a target around the global Y axis. This will be from -180 to 180 degrees.
        /// </summary>
        /// <param name="position">The position.</param>
        /// <param name="forward">The forward direction to get the angle relative to.</param>
        /// <param name="target">The target.</param>
        /// <returns>The angle in degrees from a position towards a target around the global Y axis. This will be from -180 to 180 degrees.</returns>
        public static float Angle([NotNull] this Component position, [NotNull] Transform forward, [NotNull] Transform target) => position.Flatten().Angle(forward.forward.Flatten(), target.Flatten());
        
        /// <summary>
        /// The angle in degrees from a position towards a target around the global Y axis. This will be from -180 to 180 degrees.
        /// </summary>
        /// <param name="position">The position.</param>
        /// <param name="forward">The forward direction to get the angle relative to.</param>
        /// <param name="target">The target.</param>
        /// <returns>The angle in degrees from a position towards a target around the global Y axis. This will be from -180 to 180 degrees.</returns>
        public static float Angle([NotNull] this Component position, [NotNull] Transform forward, [NotNull] Component target) => position.Flatten().Angle(forward.forward.Flatten(), target.Flatten());
        
        /// <summary>
        /// The angle in degrees from a position towards a target around the global Y axis. This will be from -180 to 180 degrees.
        /// </summary>
        /// <param name="position">The position.</param>
        /// <param name="forward">The forward direction to get the angle relative to.</param>
        /// <param name="target">The target.</param>
        /// <returns>The angle in degrees from a position towards a target around the global Y axis. This will be from -180 to 180 degrees.</returns>
        public static float Angle([NotNull] this Component position, [NotNull] Transform forward, [NotNull] GameObject target) => position.Flatten().Angle(forward.forward.Flatten(), target.Flatten());
        
        /// <summary>
        /// The angle in degrees from a position towards a target around the global Y axis. This will be from -180 to 180 degrees.
        /// </summary>
        /// <param name="position">The position.</param>
        /// <param name="forward">The forward direction to get the angle relative to.</param>
        /// <param name="target">The target.</param>
        /// <returns>The angle in degrees from a position towards a target around the global Y axis. This will be from -180 to 180 degrees.</returns>
        public static float Angle([NotNull] this Component position, [NotNull] Component forward, Vector2 target) => position.Flatten().Angle(forward.transform.forward.Flatten(), target);
        
        /// <summary>
        /// The angle in degrees from a position towards a target around the global Y axis. This will be from -180 to 180 degrees.
        /// </summary>
        /// <param name="position">The position.</param>
        /// <param name="forward">The forward direction to get the angle relative to.</param>
        /// <param name="target">The target.</param>
        /// <returns>The angle in degrees from a position towards a target around the global Y axis. This will be from -180 to 180 degrees.</returns>
        public static float Angle([NotNull] this Component position, [NotNull] Component forward, Vector3 target) => position.Flatten().Angle(forward.transform.forward.Flatten(), target.Flatten());
        
        /// <summary>
        /// The angle in degrees from a position towards a target around the global Y axis. This will be from -180 to 180 degrees.
        /// </summary>
        /// <param name="position">The position.</param>
        /// <param name="forward">The forward direction to get the angle relative to.</param>
        /// <param name="target">The target.</param>
        /// <returns>The angle in degrees from a position towards a target around the global Y axis. This will be from -180 to 180 degrees.</returns>
        public static float Angle([NotNull] this Component position, [NotNull] Component forward, [NotNull] Transform target) => position.Flatten().Angle(forward.transform.forward.Flatten(), target.Flatten());
        
        /// <summary>
        /// The angle in degrees from a position towards a target around the global Y axis. This will be from -180 to 180 degrees.
        /// </summary>
        /// <param name="position">The position.</param>
        /// <param name="forward">The forward direction to get the angle relative to.</param>
        /// <param name="target">The target.</param>
        /// <returns>The angle in degrees from a position towards a target around the global Y axis. This will be from -180 to 180 degrees.</returns>
        public static float Angle([NotNull] this Component position, [NotNull] Component forward, [NotNull] Component target) => position.Flatten().Angle(forward.transform.forward.Flatten(), target.Flatten());
        
        /// <summary>
        /// The angle in degrees from a position towards a target around the global Y axis. This will be from -180 to 180 degrees.
        /// </summary>
        /// <param name="position">The position.</param>
        /// <param name="forward">The forward direction to get the angle relative to.</param>
        /// <param name="target">The target.</param>
        /// <returns>The angle in degrees from a position towards a target around the global Y axis. This will be from -180 to 180 degrees.</returns>
        public static float Angle([NotNull] this Component position, [NotNull] Component forward, [NotNull] GameObject target) => position.Flatten().Angle(forward.transform.forward.Flatten(), target.Flatten());
        
        /// <summary>
        /// The angle in degrees from a position towards a target around the global Y axis. This will be from -180 to 180 degrees.
        /// </summary>
        /// <param name="position">The position.</param>
        /// <param name="forward">The forward direction to get the angle relative to.</param>
        /// <param name="target">The target.</param>
        /// <returns>The angle in degrees from a position towards a target around the global Y axis. This will be from -180 to 180 degrees.</returns>
        public static float Angle([NotNull] this Component position, [NotNull] GameObject forward, Vector2 target) => position.Flatten().Angle(forward.transform.forward.Flatten(), target);
        
        /// <summary>
        /// The angle in degrees from a position towards a target around the global Y axis. This will be from -180 to 180 degrees.
        /// </summary>
        /// <param name="position">The position.</param>
        /// <param name="forward">The forward direction to get the angle relative to.</param>
        /// <param name="target">The target.</param>
        /// <returns>The angle in degrees from a position towards a target around the global Y axis. This will be from -180 to 180 degrees.</returns>
        public static float Angle([NotNull] this Component position, [NotNull] GameObject forward, Vector3 target) => position.Flatten().Angle(forward.transform.forward.Flatten(), target.Flatten());
        
        /// <summary>
        /// The angle in degrees from a position towards a target around the global Y axis. This will be from -180 to 180 degrees.
        /// </summary>
        /// <param name="position">The position.</param>
        /// <param name="forward">The forward direction to get the angle relative to.</param>
        /// <param name="target">The target.</param>
        /// <returns>The angle in degrees from a position towards a target around the global Y axis. This will be from -180 to 180 degrees.</returns>
        public static float Angle([NotNull] this Component position, [NotNull] GameObject forward, [NotNull] Transform target) => position.Flatten().Angle(forward.transform.forward.Flatten(), target.Flatten());
        
        /// <summary>
        /// The angle in degrees from a position towards a target around the global Y axis. This will be from -180 to 180 degrees.
        /// </summary>
        /// <param name="position">The position.</param>
        /// <param name="forward">The forward direction to get the angle relative to.</param>
        /// <param name="target">The target.</param>
        /// <returns>The angle in degrees from a position towards a target around the global Y axis. This will be from -180 to 180 degrees.</returns>
        public static float Angle([NotNull] this Component position, [NotNull] GameObject forward, [NotNull] Component target) => position.Flatten().Angle(forward.transform.forward.Flatten(), target.Flatten());
        
        /// <summary>
        /// The angle in degrees from a position towards a target around the global Y axis. This will be from -180 to 180 degrees.
        /// </summary>
        /// <param name="position">The position.</param>
        /// <param name="forward">The forward direction to get the angle relative to.</param>
        /// <param name="target">The target.</param>
        /// <returns>The angle in degrees from a position towards a target around the global Y axis. This will be from -180 to 180 degrees.</returns>
        public static float Angle([NotNull] this Component position, [NotNull] GameObject forward, [NotNull] GameObject target) => position.Flatten().Angle(forward.transform.forward.Flatten(), target.Flatten());
        
        /// <summary>
        /// The angle in degrees from a position towards a target around the global Y axis. This will be from -180 to 180 degrees.
        /// </summary>
        /// <param name="position">The position with the direction being its forward.</param>
        /// <param name="target">The target.</param>
        /// <returns>The angle in degrees from a position towards a target around the global Y axis. This will be from -180 to 180 degrees.</returns>
        public static float Angle([NotNull] this Component position, Vector2 target)
        {
            Transform t = position.transform;
            return t.Flatten().Angle(t.forward.Flatten(), target);
        }
        
        /// <summary>
        /// The angle in degrees from a position towards a target around the global Y axis. This will be from -180 to 180 degrees.
        /// </summary>
        /// <param name="position">The position with the direction being its forward.</param>
        /// <param name="target">The target.</param>
        /// <returns>The angle in degrees from a position towards a target around the global Y axis. This will be from -180 to 180 degrees.</returns>
        public static float Angle([NotNull] this Component position, Vector3 target) => position.Angle(target.Flatten());
        
        /// <summary>
        /// The angle in degrees from a position towards a target around the global Y axis. This will be from -180 to 180 degrees.
        /// </summary>
        /// <param name="position">The position with the direction being its forward.</param>
        /// <param name="target">The target.</param>
        /// <returns>The angle in degrees from a position towards a target around the global Y axis. This will be from -180 to 180 degrees.</returns>
        public static float Angle([NotNull] this Component position, [NotNull] Transform target) => position.Angle(target.Flatten());
        
        /// <summary>
        /// The angle in degrees from a position towards a target around the global Y axis. This will be from -180 to 180 degrees.
        /// </summary>
        /// <param name="position">The position with the direction being its forward.</param>
        /// <param name="target">The target.</param>
        /// <returns>The angle in degrees from a position towards a target around the global Y axis. This will be from -180 to 180 degrees.</returns>
        public static float Angle([NotNull] this Component position, [NotNull] Component target) => position.Angle(target.Flatten());
        
        /// <summary>
        /// The angle in degrees from a position towards a target around the global Y axis. This will be from -180 to 180 degrees.
        /// </summary>
        /// <param name="position">The position with the direction being its forward.</param>
        /// <param name="target">The target.</param>
        /// <returns>The angle in degrees from a position towards a target around the global Y axis. This will be from -180 to 180 degrees.</returns>
        public static float Angle([NotNull] this Component position, [NotNull] GameObject target) => position.Angle(target.Flatten());
        
        /// <summary>
        /// The angle in degrees from a position towards a target around the global Y axis. This will be from -180 to 180 degrees.
        /// </summary>
        /// <param name="position">The position.</param>
        /// <param name="forward">The forward direction to get the angle relative to.</param>
        /// <param name="target">The target.</param>
        /// <returns>The angle in degrees from a position towards a target around the global Y axis. This will be from -180 to 180 degrees.</returns>
        public static float Angle([NotNull] this GameObject position, Vector2 forward, Vector2 target) => position.Flatten().Angle(forward, target);
        
        /// <summary>
        /// The angle in degrees from a position towards a target around the global Y axis. This will be from -180 to 180 degrees.
        /// </summary>
        /// <param name="position">The position.</param>
        /// <param name="forward">The forward direction to get the angle relative to.</param>
        /// <param name="target">The target.</param>
        /// <returns>The angle in degrees from a position towards a target around the global Y axis. This will be from -180 to 180 degrees.</returns>
        public static float Angle([NotNull] this GameObject position, Vector2 forward, Vector3 target) => position.Flatten().Angle(forward, target.Flatten());
        
        /// <summary>
        /// The angle in degrees from a position towards a target around the global Y axis. This will be from -180 to 180 degrees.
        /// </summary>
        /// <param name="position">The position.</param>
        /// <param name="forward">The forward direction to get the angle relative to.</param>
        /// <param name="target">The target.</param>
        /// <returns>The angle in degrees from a position towards a target around the global Y axis. This will be from -180 to 180 degrees.</returns>
        public static float Angle([NotNull] this GameObject position, Vector2 forward, [NotNull] Transform target) => position.Flatten().Angle(forward, target.Flatten());
        
        /// <summary>
        /// The angle in degrees from a position towards a target around the global Y axis. This will be from -180 to 180 degrees.
        /// </summary>
        /// <param name="position">The position.</param>
        /// <param name="forward">The forward direction to get the angle relative to.</param>
        /// <param name="target">The target.</param>
        /// <returns>The angle in degrees from a position towards a target around the global Y axis. This will be from -180 to 180 degrees.</returns>
        public static float Angle([NotNull] this GameObject position, Vector2 forward, [NotNull] Component target) => position.Flatten().Angle(forward, target.Flatten());
        
        /// <summary>
        /// The angle in degrees from a position towards a target around the global Y axis. This will be from -180 to 180 degrees.
        /// </summary>
        /// <param name="position">The position.</param>
        /// <param name="forward">The forward direction to get the angle relative to.</param>
        /// <param name="target">The target.</param>
        /// <returns>The angle in degrees from a position towards a target around the global Y axis. This will be from -180 to 180 degrees.</returns>
        public static float Angle([NotNull] this GameObject position, Vector2 forward, [NotNull] GameObject target) => position.Flatten().Angle(forward, target.Flatten());
        
        /// <summary>
        /// The angle in degrees from a position towards a target around the global Y axis. This will be from -180 to 180 degrees.
        /// </summary>
        /// <param name="position">The position.</param>
        /// <param name="forward">The forward direction to get the angle relative to.</param>
        /// <param name="target">The target.</param>
        /// <returns>The angle in degrees from a position towards a target around the global Y axis. This will be from -180 to 180 degrees.</returns>
        public static float Angle([NotNull] this GameObject position, Vector3 forward, Vector2 target) => position.Flatten().Angle(forward.Flatten(), target);
        
        /// <summary>
        /// The angle in degrees from a position towards a target around the global Y axis. This will be from -180 to 180 degrees.
        /// </summary>
        /// <param name="position">The position.</param>
        /// <param name="forward">The forward direction to get the angle relative to.</param>
        /// <param name="target">The target.</param>
        /// <returns>The angle in degrees from a position towards a target around the global Y axis. This will be from -180 to 180 degrees.</returns>
        public static float Angle([NotNull] this GameObject position, Vector3 forward, Vector3 target) => position.Flatten().Angle(forward.Flatten(), target.Flatten());
        
        /// <summary>
        /// The angle in degrees from a position towards a target around the global Y axis. This will be from -180 to 180 degrees.
        /// </summary>
        /// <param name="position">The position.</param>
        /// <param name="forward">The forward direction to get the angle relative to.</param>
        /// <param name="target">The target.</param>
        /// <returns>The angle in degrees from a position towards a target around the global Y axis. This will be from -180 to 180 degrees.</returns>
        public static float Angle([NotNull] this GameObject position, Vector3 forward, [NotNull] Transform target) => position.Flatten().Angle(forward.Flatten(), target.Flatten());
        
        /// <summary>
        /// The angle in degrees from a position towards a target around the global Y axis. This will be from -180 to 180 degrees.
        /// </summary>
        /// <param name="position">The position.</param>
        /// <param name="forward">The forward direction to get the angle relative to.</param>
        /// <param name="target">The target.</param>
        /// <returns>The angle in degrees from a position towards a target around the global Y axis. This will be from -180 to 180 degrees.</returns>
        public static float Angle([NotNull] this GameObject position, Vector3 forward, [NotNull] Component target) => position.Flatten().Angle(forward.Flatten(), target.Flatten());
        
        /// <summary>
        /// The angle in degrees from a position towards a target around the global Y axis. This will be from -180 to 180 degrees.
        /// </summary>
        /// <param name="position">The position.</param>
        /// <param name="forward">The forward direction to get the angle relative to.</param>
        /// <param name="target">The target.</param>
        /// <returns>The angle in degrees from a position towards a target around the global Y axis. This will be from -180 to 180 degrees.</returns>
        public static float Angle([NotNull] this GameObject position, Vector3 forward, [NotNull] GameObject target) => position.Flatten().Angle(forward.Flatten(), target.Flatten());
        
        /// <summary>
        /// The angle in degrees from a position towards a target around the global Y axis. This will be from -180 to 180 degrees.
        /// </summary>
        /// <param name="position">The position.</param>
        /// <param name="forward">The forward direction to get the angle relative to.</param>
        /// <param name="target">The target.</param>
        /// <returns>The angle in degrees from a position towards a target around the global Y axis. This will be from -180 to 180 degrees.</returns>
        public static float Angle([NotNull] this GameObject position, [NotNull] Transform forward, Vector2 target) => position.Flatten().Angle(forward.forward.Flatten(), target);
        
        /// <summary>
        /// The angle in degrees from a position towards a target around the global Y axis. This will be from -180 to 180 degrees.
        /// </summary>
        /// <param name="position">The position.</param>
        /// <param name="forward">The forward direction to get the angle relative to.</param>
        /// <param name="target">The target.</param>
        /// <returns>The angle in degrees from a position towards a target around the global Y axis. This will be from -180 to 180 degrees.</returns>
        public static float Angle([NotNull] this GameObject position, [NotNull] Transform forward, Vector3 target) => position.Flatten().Angle(forward.forward.Flatten(), target.Flatten());
        
        /// <summary>
        /// The angle in degrees from a position towards a target around the global Y axis. This will be from -180 to 180 degrees.
        /// </summary>
        /// <param name="position">The position.</param>
        /// <param name="forward">The forward direction to get the angle relative to.</param>
        /// <param name="target">The target.</param>
        /// <returns>The angle in degrees from a position towards a target around the global Y axis. This will be from -180 to 180 degrees.</returns>
        public static float Angle([NotNull] this GameObject position, [NotNull] Transform forward, [NotNull] Transform target) => position.Flatten().Angle(forward.forward.Flatten(), target.Flatten());
        
        /// <summary>
        /// The angle in degrees from a position towards a target around the global Y axis. This will be from -180 to 180 degrees.
        /// </summary>
        /// <param name="position">The position.</param>
        /// <param name="forward">The forward direction to get the angle relative to.</param>
        /// <param name="target">The target.</param>
        /// <returns>The angle in degrees from a position towards a target around the global Y axis. This will be from -180 to 180 degrees.</returns>
        public static float Angle([NotNull] this GameObject position, [NotNull] Transform forward, [NotNull] Component target) => position.Flatten().Angle(forward.forward.Flatten(), target.Flatten());
        
        /// <summary>
        /// The angle in degrees from a position towards a target around the global Y axis. This will be from -180 to 180 degrees.
        /// </summary>
        /// <param name="position">The position.</param>
        /// <param name="forward">The forward direction to get the angle relative to.</param>
        /// <param name="target">The target.</param>
        /// <returns>The angle in degrees from a position towards a target around the global Y axis. This will be from -180 to 180 degrees.</returns>
        public static float Angle([NotNull] this GameObject position, [NotNull] Transform forward, [NotNull] GameObject target) => position.Flatten().Angle(forward.forward.Flatten(), target.Flatten());
        
        /// <summary>
        /// The angle in degrees from a position towards a target around the global Y axis. This will be from -180 to 180 degrees.
        /// </summary>
        /// <param name="position">The position.</param>
        /// <param name="forward">The forward direction to get the angle relative to.</param>
        /// <param name="target">The target.</param>
        /// <returns>The angle in degrees from a position towards a target around the global Y axis. This will be from -180 to 180 degrees.</returns>
        public static float Angle([NotNull] this GameObject position, [NotNull] Component forward, Vector2 target) => position.Flatten().Angle(forward.transform.forward.Flatten(), target);
        
        /// <summary>
        /// The angle in degrees from a position towards a target around the global Y axis. This will be from -180 to 180 degrees.
        /// </summary>
        /// <param name="position">The position.</param>
        /// <param name="forward">The forward direction to get the angle relative to.</param>
        /// <param name="target">The target.</param>
        /// <returns>The angle in degrees from a position towards a target around the global Y axis. This will be from -180 to 180 degrees.</returns>
        public static float Angle([NotNull] this GameObject position, [NotNull] Component forward, Vector3 target) => position.Flatten().Angle(forward.transform.forward.Flatten(), target.Flatten());
        
        /// <summary>
        /// The angle in degrees from a position towards a target around the global Y axis. This will be from -180 to 180 degrees.
        /// </summary>
        /// <param name="position">The position.</param>
        /// <param name="forward">The forward direction to get the angle relative to.</param>
        /// <param name="target">The target.</param>
        /// <returns>The angle in degrees from a position towards a target around the global Y axis. This will be from -180 to 180 degrees.</returns>
        public static float Angle([NotNull] this GameObject position, [NotNull] Component forward, [NotNull] Transform target) => position.Flatten().Angle(forward.transform.forward.Flatten(), target.Flatten());
        
        /// <summary>
        /// The angle in degrees from a position towards a target around the global Y axis. This will be from -180 to 180 degrees.
        /// </summary>
        /// <param name="position">The position.</param>
        /// <param name="forward">The forward direction to get the angle relative to.</param>
        /// <param name="target">The target.</param>
        /// <returns>The angle in degrees from a position towards a target around the global Y axis. This will be from -180 to 180 degrees.</returns>
        public static float Angle([NotNull] this GameObject position, [NotNull] Component forward, [NotNull] Component target) => position.Flatten().Angle(forward.transform.forward.Flatten(), target.Flatten());
        
        /// <summary>
        /// The angle in degrees from a position towards a target around the global Y axis. This will be from -180 to 180 degrees.
        /// </summary>
        /// <param name="position">The position.</param>
        /// <param name="forward">The forward direction to get the angle relative to.</param>
        /// <param name="target">The target.</param>
        /// <returns>The angle in degrees from a position towards a target around the global Y axis. This will be from -180 to 180 degrees.</returns>
        public static float Angle([NotNull] this GameObject position, [NotNull] Component forward, [NotNull] GameObject target) => position.Flatten().Angle(forward.transform.forward.Flatten(), target.Flatten());
        
        /// <summary>
        /// The angle in degrees from a position towards a target around the global Y axis. This will be from -180 to 180 degrees.
        /// </summary>
        /// <param name="position">The position.</param>
        /// <param name="forward">The forward direction to get the angle relative to.</param>
        /// <param name="target">The target.</param>
        /// <returns>The angle in degrees from a position towards a target around the global Y axis. This will be from -180 to 180 degrees.</returns>
        public static float Angle([NotNull] this GameObject position, [NotNull] GameObject forward, Vector2 target) => position.Flatten().Angle(forward.transform.forward.Flatten(), target);
        
        /// <summary>
        /// The angle in degrees from a position towards a target around the global Y axis. This will be from -180 to 180 degrees.
        /// </summary>
        /// <param name="position">The position.</param>
        /// <param name="forward">The forward direction to get the angle relative to.</param>
        /// <param name="target">The target.</param>
        /// <returns>The angle in degrees from a position towards a target around the global Y axis. This will be from -180 to 180 degrees.</returns>
        public static float Angle([NotNull] this GameObject position, [NotNull] GameObject forward, Vector3 target) => position.Flatten().Angle(forward.transform.forward.Flatten(), target.Flatten());
        
        /// <summary>
        /// The angle in degrees from a position towards a target around the global Y axis. This will be from -180 to 180 degrees.
        /// </summary>
        /// <param name="position">The position.</param>
        /// <param name="forward">The forward direction to get the angle relative to.</param>
        /// <param name="target">The target.</param>
        /// <returns>The angle in degrees from a position towards a target around the global Y axis. This will be from -180 to 180 degrees.</returns>
        public static float Angle([NotNull] this GameObject position, [NotNull] GameObject forward, [NotNull] Transform target) => position.Flatten().Angle(forward.transform.forward.Flatten(), target.Flatten());
        
        /// <summary>
        /// The angle in degrees from a position towards a target around the global Y axis. This will be from -180 to 180 degrees.
        /// </summary>
        /// <param name="position">The position.</param>
        /// <param name="forward">The forward direction to get the angle relative to.</param>
        /// <param name="target">The target.</param>
        /// <returns>The angle in degrees from a position towards a target around the global Y axis. This will be from -180 to 180 degrees.</returns>
        public static float Angle([NotNull] this GameObject position, [NotNull] GameObject forward, [NotNull] Component target) => position.Flatten().Angle(forward.transform.forward.Flatten(), target.Flatten());
        
        /// <summary>
        /// The angle in degrees from a position towards a target around the global Y axis. This will be from -180 to 180 degrees.
        /// </summary>
        /// <param name="position">The position.</param>
        /// <param name="forward">The forward direction to get the angle relative to.</param>
        /// <param name="target">The target.</param>
        /// <returns>The angle in degrees from a position towards a target around the global Y axis. This will be from -180 to 180 degrees.</returns>
        public static float Angle([NotNull] this GameObject position, [NotNull] GameObject forward, [NotNull] GameObject target) => position.Flatten().Angle(forward.transform.forward.Flatten(), target.Flatten());
        
        /// <summary>
        /// The angle in degrees from a position towards a target around the global Y axis. This will be from -180 to 180 degrees.
        /// </summary>
        /// <param name="position">The position with the direction being its forward.</param>
        /// <param name="target">The target.</param>
        /// <returns>The angle in degrees from a position towards a target around the global Y axis. This will be from -180 to 180 degrees.</returns>
        public static float Angle([NotNull] this GameObject position, Vector2 target)
        {
            Transform t = position.transform;
            return t.Flatten().Angle(t.forward.Flatten(), target);
        }
        
        /// <summary>
        /// The angle in degrees from a position towards a target around the global Y axis. This will be from -180 to 180 degrees.
        /// </summary>
        /// <param name="position">The position with the direction being its forward.</param>
        /// <param name="target">The target.</param>
        /// <returns>The angle in degrees from a position towards a target around the global Y axis. This will be from -180 to 180 degrees.</returns>
        public static float Angle([NotNull] this GameObject position, Vector3 target) => position.Angle(target.Flatten());
        
        /// <summary>
        /// The angle in degrees from a position towards a target around the global Y axis. This will be from -180 to 180 degrees.
        /// </summary>
        /// <param name="position">The position with the direction being its forward.</param>
        /// <param name="target">The target.</param>
        /// <returns>The angle in degrees from a position towards a target around the global Y axis. This will be from -180 to 180 degrees.</returns>
        public static float Angle([NotNull] this GameObject position, [NotNull] Transform target) => position.Angle(target.Flatten());
        
        /// <summary>
        /// The angle in degrees from a position towards a target around the global Y axis. This will be from -180 to 180 degrees.
        /// </summary>
        /// <param name="position">The position with the direction being its forward.</param>
        /// <param name="target">The target.</param>
        /// <returns>The angle in degrees from a position towards a target around the global Y axis. This will be from -180 to 180 degrees.</returns>
        public static float Angle([NotNull] this GameObject position, [NotNull] Component target) => position.Angle(target.Flatten());
        
        /// <summary>
        /// The angle in degrees from a position towards a target around the global Y axis. This will be from -180 to 180 degrees.
        /// </summary>
        /// <param name="position">The position with the direction being its forward.</param>
        /// <param name="target">The target.</param>
        /// <returns>The angle in degrees from a position towards a target around the global Y axis. This will be from -180 to 180 degrees.</returns>
        public static float Angle([NotNull] this GameObject position, [NotNull] GameObject target) => position.Angle(target.Flatten());
    }
}