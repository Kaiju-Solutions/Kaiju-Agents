using System.Diagnostics.CodeAnalysis;
using UnityEngine;

namespace KaijuSolutions.Agents
{
    /// <summary>
    /// General Kaiju Agents functions. The majority of this class contains extension methods for vectors, transforms, components, and GameObjects.
    /// </summary>
    public static partial class KaijuAgents
    {
        /// <summary>
        /// The angle in degrees from a position towards a target around the global Y axis. This will be from -180 to 180 degrees.
        /// </summary>
        /// <param name="position">The position.</param>
        /// <param name="forward">The forward direction to get the angle relative to.</param>
        /// <param name="target">The target.</param>
        /// <returns>The angle in degrees from a position towards a target around the global Y axis. This will be from -180 to 180 degrees.</returns>
        public static float Angle(this Vector2 position, Vector2 forward, Vector2 target)
        {
            return Vector2.SignedAngle(forward, target.Direction(position));
        }
        
        /// <summary>
        /// The angle in degrees from a position towards a target around the global Y axis. This will be from -180 to 180 degrees.
        /// </summary>
        /// <param name="position">The position.</param>
        /// <param name="forward">The forward direction to get the angle relative to.</param>
        /// <param name="target">The target.</param>
        /// <returns>The angle in degrees from a position towards a target around the global Y axis. This will be from -180 to 180 degrees.</returns>
        public static float Angle(this Vector2 position, Vector2 forward, Vector3 target)
        {
            return position.Angle(forward, target.Flatten());
        }
        
        /// <summary>
        /// The angle in degrees from a position towards a target around the global Y axis. This will be from -180 to 180 degrees.
        /// </summary>
        /// <param name="position">The position.</param>
        /// <param name="forward">The forward direction to get the angle relative to.</param>
        /// <param name="target">The target.</param>
        /// <returns>The angle in degrees from a position towards a target around the global Y axis. This will be from -180 to 180 degrees.</returns>
        public static float Angle(this Vector2 position, Vector2 forward, [NotNull] Transform target)
        {
            return position.Angle(forward, target.Flatten());
        }
        
        /// <summary>
        /// The angle in degrees from a position towards a target around the global Y axis. This will be from -180 to 180 degrees.
        /// </summary>
        /// <param name="position">The position.</param>
        /// <param name="forward">The forward direction to get the angle relative to.</param>
        /// <param name="target">The target.</param>
        /// <returns>The angle in degrees from a position towards a target around the global Y axis. This will be from -180 to 180 degrees.</returns>
        public static float Angle(this Vector2 position, Vector2 forward, [NotNull] Component target)
        {
            return position.Angle(forward, target.Flatten());
        }
        
        /// <summary>
        /// The angle in degrees from a position towards a target around the global Y axis. This will be from -180 to 180 degrees.
        /// </summary>
        /// <param name="position">The position.</param>
        /// <param name="forward">The forward direction to get the angle relative to.</param>
        /// <param name="target">The target.</param>
        /// <returns>The angle in degrees from a position towards a target around the global Y axis. This will be from -180 to 180 degrees.</returns>
        public static float Angle(this Vector2 position, Vector2 forward, [NotNull] GameObject target)
        {
            return position.Angle(forward, target.Flatten());
        }
        
        /// <summary>
        /// The angle in degrees from a position towards a target around the global Y axis. This will be from -180 to 180 degrees.
        /// </summary>
        /// <param name="position">The position.</param>
        /// <param name="forward">The forward direction to get the angle relative to.</param>
        /// <param name="target">The target.</param>
        /// <returns>The angle in degrees from a position towards a target around the global Y axis. This will be from -180 to 180 degrees.</returns>
        public static float Angle(this Vector2 position, Vector3 forward, Vector2 target)
        {
            return position.Angle(forward.Flatten(), target);
        }
        
        /// <summary>
        /// The angle in degrees from a position towards a target around the global Y axis. This will be from -180 to 180 degrees.
        /// </summary>
        /// <param name="position">The position.</param>
        /// <param name="forward">The forward direction to get the angle relative to.</param>
        /// <param name="target">The target.</param>
        /// <returns>The angle in degrees from a position towards a target around the global Y axis. This will be from -180 to 180 degrees.</returns>
        public static float Angle(this Vector2 position, Vector3 forward, Vector3 target)
        {
            return position.Angle(forward.Flatten(), target.Flatten());
        }
        
        /// <summary>
        /// The angle in degrees from a position towards a target around the global Y axis. This will be from -180 to 180 degrees.
        /// </summary>
        /// <param name="position">The position.</param>
        /// <param name="forward">The forward direction to get the angle relative to.</param>
        /// <param name="target">The target.</param>
        /// <returns>The angle in degrees from a position towards a target around the global Y axis. This will be from -180 to 180 degrees.</returns>
        public static float Angle(this Vector2 position, Vector3 forward, [NotNull] Transform target)
        {
            return position.Angle(forward.Flatten(), target.Flatten());
        }
        
        /// <summary>
        /// The angle in degrees from a position towards a target around the global Y axis. This will be from -180 to 180 degrees.
        /// </summary>
        /// <param name="position">The position.</param>
        /// <param name="forward">The forward direction to get the angle relative to.</param>
        /// <param name="target">The target.</param>
        /// <returns>The angle in degrees from a position towards a target around the global Y axis. This will be from -180 to 180 degrees.</returns>
        public static float Angle(this Vector2 position, Vector3 forward, [NotNull] Component target)
        {
            return position.Angle(forward.Flatten(), target.Flatten());
        }
        
        /// <summary>
        /// The angle in degrees from a position towards a target around the global Y axis. This will be from -180 to 180 degrees.
        /// </summary>
        /// <param name="position">The position.</param>
        /// <param name="forward">The forward direction to get the angle relative to.</param>
        /// <param name="target">The target.</param>
        /// <returns>The angle in degrees from a position towards a target around the global Y axis. This will be from -180 to 180 degrees.</returns>
        public static float Angle(this Vector2 position, Vector3 forward, [NotNull] GameObject target)
        {
            return position.Angle(forward.Flatten(), target.Flatten());
        }
    }
}