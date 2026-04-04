using UnityEngine;

namespace KaijuSolutions.Agents.Extensions
{
    /// <summary>
    /// Helper normalization methods.
    /// </summary>
    public static class KaijuAgentsNormalization
    {
        /// <summary>
        /// Normalize a float.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="original">The original max value possible.</param>
        /// <param name="min">The new normalized minimum.</param>
        /// <param name="max">The new normalized maximum.</param>
        /// <returns>The normalized float.</returns>
        public static float Normalize(this float value, float original, float min = -1f, float max = 1f)
        {
            return Mathf.Clamp(value / original, min, max);
        }
        
        /// <summary>
        /// Normalize a vector.
        /// </summary>
        /// <param name="value">The vector.</param>
        /// <param name="original">The original max value possible.</param>
        /// <param name="min">The new normalized minimum.</param>
        /// <param name="max">The new normalized maximum.</param>
        /// <returns>The normalized vector.</returns>
        public static Vector2 Normalize(this Vector2 value, float original, float min = -1f, float max = 1f)
        {
            return new(value.x.Normalize(original, min, max), value.y.Normalize(original, min, max));
        }
        
        /// <summary>
        /// Normalize a vector.
        /// </summary>
        /// <param name="value">The vector.</param>
        /// <param name="original">The original max value possible.</param>
        /// <param name="min">The new normalized minimum.</param>
        /// <param name="max">The new normalized maximum.</param>
        /// <returns>The normalized vector.</returns>
        public static Vector3 Normalize(this Vector3 value, float original, float min = -1f, float max = 1f)
        {
            return new(value.x.Normalize(original, min, max), value.y.Normalize(original, min, max), value.z.Normalize(original, min, max));
        }
        
        /// <summary>
        /// Normalize a vector between [-1, 1] relative to a position and forward.
        /// </summary>
        /// <param name="value">The vector.</param>
        /// <param name="position">The position to get the vector relative to.</param>
        /// <param name="forward">The forward to get the vector relative to.</param>
        /// <param name="original">The original max value possible, such as a detection distance.</param>
        /// <returns>The normalized vector.</returns>
        public static Vector2 Normalize(this Vector2 value, Vector2 position, Vector2 forward, float original)
        {
            Vector2 relative = value - position;
            return new Vector2(Vector2.Dot(relative, new(forward.y, -forward.x)), Vector2.Dot(relative, forward)).Normalize(original);
        }
        
        /// <summary>
        /// Normalize a vector between [-1, 1] relative to a position and forward.
        /// </summary>
        /// <param name="value">The vector.</param>
        /// <param name="position">The position to get the vector relative to.</param>
        /// <param name="forward">The forward to get the vector relative to.</param>
        /// <param name="original">The original max value possible, such as a detection distance.</param>
        /// <returns>The normalized vector.</returns>
        public static Vector2 Normalize(this Vector2 value, Vector2 position, Vector3 forward, float original)
        {
            return value.Normalize(position, forward.Flatten(), original);
        }
        
        /// <summary>
        /// Normalize a vector between [-1, 1] relative to a position and forward.
        /// </summary>
        /// <param name="value">The vector.</param>
        /// <param name="position">The position to get the vector relative to.</param>
        /// <param name="forward">The forward to get the vector relative to.</param>
        /// <param name="original">The original max value possible, such as a detection distance.</param>
        /// <returns>The normalized vector.</returns>
        public static Vector2 Normalize(this Vector2 value, Vector3 position, Vector2 forward, float original)
        {
            return value.Normalize(position.Flatten(), forward, original);
        }
        
        /// <summary>
        /// Normalize a vector between [-1, 1] relative to a position and forward.
        /// </summary>
        /// <param name="value">The vector.</param>
        /// <param name="position">The position to get the vector relative to.</param>
        /// <param name="forward">The forward to get the vector relative to.</param>
        /// <param name="original">The original max value possible, such as a detection distance.</param>
        /// <returns>The normalized vector.</returns>
        public static Vector2 Normalize(this Vector2 value, Vector3 position, Vector3 forward, float original)
        {
            return value.Normalize(position.Flatten(), forward.Flatten(), original);
        }
        
        /// <summary>
        /// Normalize a vector between [-1, 1] relative to a position and its forward.
        /// </summary>
        /// <param name="value">The vector.</param>
        /// <param name="position">The position and forward to get the vector relative to.</param>
        /// <param name="original">The original max value possible, such as a detection distance.</param>
        /// <returns>The normalized vector.</returns>
        public static Vector2 Normalize(this Vector2 value, Transform position, float original)
        {
            return value.Normalize(position.position, position.forward, original);
        }
        
        /// <summary>
        /// Normalize a vector between [-1, 1] relative to a position and its forward.
        /// </summary>
        /// <param name="value">The vector.</param>
        /// <param name="position">The position and forward to get the vector relative to.</param>
        /// <param name="original">The original max value possible, such as a detection distance.</param>
        /// <returns>The normalized vector.</returns>
        public static Vector2 Normalize(this Vector2 value, GameObject position, float original)
        {
            return value.Normalize(position.transform, original);
        }
        
        /// <summary>
        /// Normalize a vector between [-1, 1] relative to a position and its forward.
        /// </summary>
        /// <param name="value">The vector.</param>
        /// <param name="position">The position and forward to get the vector relative to.</param>
        /// <param name="original">The original max value possible, such as a detection distance.</param>
        /// <returns>The normalized vector.</returns>
        public static Vector2 Normalize(this Vector2 value, Component position, float original)
        {
            return value.Normalize(position.transform, original);
        }
        
        /// <summary>
        /// Normalize a vector between [-1, 1] relative to a position and forward.
        /// </summary>
        /// <param name="value">The vector.</param>
        /// <param name="position">The position to get the vector relative to.</param>
        /// <param name="forward">The forward to get the vector relative to.</param>
        /// <param name="original">The original max value possible, such as a detection distance.</param>
        /// <returns>The normalized vector.</returns>
        public static Vector3 Normalize(this Vector3 value, Vector2 position, Vector2 forward, float original)
        {
            Vector2 flattened = value.Flatten().Normalize(position, forward, original);
            return new(flattened.x, 0, flattened.y);
        }
        
        /// <summary>
        /// Normalize a vector between [-1, 1] relative to a position and forward.
        /// </summary>
        /// <param name="value">The vector.</param>
        /// <param name="position">The position to get the vector relative to.</param>
        /// <param name="forward">The forward to get the vector relative to.</param>
        /// <param name="original">The original max value possible, such as a detection distance.</param>
        /// <returns>The normalized vector.</returns>
        public static Vector3 Normalize(this Vector3 value, Vector2 position, Vector3 forward, float original)
        {
            return value.Normalize(position, forward.Flatten(), original);
        }
        
        /// <summary>
        /// Normalize a vector between [-1, 1] relative to a position and forward.
        /// </summary>
        /// <param name="value">The vector.</param>
        /// <param name="position">The position to get the vector relative to.</param>
        /// <param name="forward">The forward to get the vector relative to.</param>
        /// <param name="original">The original max value possible, such as a detection distance.</param>
        /// <returns>The normalized vector.</returns>
        public static Vector3 Normalize(this Vector3 value, Vector3 position, Vector2 forward, float original)
        {
            return value.Normalize(position, forward.Expand(), original);
        }
        
        /// <summary>
        /// Normalize a vector between [-1, 1] relative to a position and forward.
        /// </summary>
        /// <param name="value">The vector.</param>
        /// <param name="position">The position to get the vector relative to.</param>
        /// <param name="forward">The forward to get the vector relative to.</param>
        /// <param name="original">The original max value possible, such as a detection distance.</param>
        /// <returns>The normalized vector.</returns>
        public static Vector3 Normalize(this Vector3 value, Vector3 position, Vector3 forward, float original)
        {
            Vector3 relativePoint = value - position;
            return new Vector3(Vector3.Dot(relativePoint, Vector3.Cross(Vector3.up, forward).normalized), Vector3.Dot(relativePoint, Vector3.up), Vector3.Dot(relativePoint, forward)).Normalize(original);
        }
        
        /// <summary>
        /// Normalize a vector between [-1, 1] relative to a position and its forward.
        /// </summary>
        /// <param name="value">The vector.</param>
        /// <param name="position">The position and forward to get the vector relative to.</param>
        /// <param name="original">The original max value possible, such as a detection distance.</param>
        /// <returns>The normalized vector.</returns>
        public static Vector3 Normalize(this Vector3 value, Transform position, float original)
        {
            return position.InverseTransformPoint(value).Normalize(original);
        }
        
        /// <summary>
        /// Normalize a vector between [-1, 1] relative to a position and its forward.
        /// </summary>
        /// <param name="value">The vector.</param>
        /// <param name="position">The position and forward to get the vector relative to.</param>
        /// <param name="original">The original max value possible, such as a detection distance.</param>
        /// <returns>The normalized vector.</returns>
        public static Vector3 Normalize(this Vector3 value, GameObject position, float original)
        {
            return value.Normalize(position.transform, original);
        }
        
        /// <summary>
        /// Normalize a vector between [-1, 1] relative to a position and its forward.
        /// </summary>
        /// <param name="value">The vector.</param>
        /// <param name="position">The position and forward to get the vector relative to.</param>
        /// <param name="original">The original max value possible, such as a detection distance.</param>
        /// <returns>The normalized vector.</returns>
        public static Vector3 Normalize(this Vector3 value, Component position, float original)
        {
            return value.Normalize(position.transform, original);
        }
    }
}