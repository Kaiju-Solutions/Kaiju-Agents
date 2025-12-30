using System.Diagnostics.CodeAnalysis;
using UnityEngine;

namespace KaijuSolutions.Agents
{
    /// <summary>
    /// General Kaiju Agents functions.
    /// </summary>
    public static partial class KaijuAgents
    {
        /// <summary>
        /// Flatten an XYZ vector down to the X and Z axes.
        /// </summary>
        /// <param name="vector">The vector to flatten.</param>
        /// <returns>The  XYZ vector flattened down to the X and Z axes.</returns>
        public static Vector2 Flatten(this Vector3 vector) => new(vector.x, vector.z);
        
        /// <summary>
        /// Flatten a transform down to the X and Z axes positions.
        /// </summary>
        /// <param name="transform">The vector to flatten.</param>
        /// <returns>The transform flattened down to the X and Z axes positions.</returns>
        public static Vector2 Flatten([NotNull] this Transform transform) => transform.position.Flatten();
        
        /// <summary>
        /// Flatten a component down to the X and Z axes positions.
        /// </summary>
        /// <param name="component">The vector to flatten.</param>
        /// <returns>The component flattened down to the X and Z axes positions.</returns>
        public static Vector2 Flatten([NotNull] this Component component) => component.transform.position.Flatten();
        
        /// <summary>
        /// Flatten a GameObject down to the X and Z axes positions.
        /// </summary>
        /// <param name="gameObject">The vector to flatten.</param>
        /// <returns>The GameObject flattened down to the X and Z axes positions.</returns>
        public static Vector2 Flatten([NotNull] this GameObject gameObject) => gameObject.transform.position.Flatten();
        
        /// <summary>
        /// Expand an XZ vector to all three axes.
        /// </summary>
        /// <param name="vector">The vector to expand.</param>
        /// <returns>The XZ vector expanded to all three axes.</returns>
        public static Vector3 Expand(this Vector2 vector) => new(vector.x, 0, vector.y);
        
        /// <summary>
        /// Get the distance between this and another position.
        /// </summary>
        /// <param name="self">This position.</param>
        /// <param name="other">The other position.</param>
        /// <returns>The distance.</returns>
        public static float Distance(this Vector2 self, Vector2 other) => Vector2.Distance(self, other);
        
        /// <summary>
        /// Get the distance between this and another position.
        /// </summary>
        /// <param name="self">This position.</param>
        /// <param name="other">The other position.</param>
        /// <returns>The distance.</returns>
        public static float Distance(this Vector2 self, Vector3 other) => self.Distance(other.Flatten());
        
        /// <summary>
        /// Get the distance between this and another position.
        /// </summary>
        /// <param name="self">This position.</param>
        /// <param name="other">The other position.</param>
        /// <returns>The distance.</returns>
        public static float Distance(this Vector2 self, [NotNull] Transform other) => self.Distance(other.position);
        
        /// <summary>
        /// Get the distance between this and another position.
        /// </summary>
        /// <param name="self">This position.</param>
        /// <param name="other">The other position.</param>
        /// <returns>The distance.</returns>
        public static float Distance(this Vector2 self, [NotNull] Component other) => self.Distance(other.transform);
        
        /// <summary>
        /// Get the distance between this and another position.
        /// </summary>
        /// <param name="self">This position.</param>
        /// <param name="other">The other position.</param>
        /// <returns>The distance.</returns>
        public static float Distance(this Vector2 self, [NotNull] GameObject other) => self.Distance(other.transform);
        
        /// <summary>
        /// Get the distance between this and another position.
        /// </summary>
        /// <param name="self">This position.</param>
        /// <param name="other">The other position.</param>
        /// <returns>The distance.</returns>
        public static float Distance(this Vector3 self, Vector2 other) => other.Distance(self);
        
        /// <summary>
        /// Get the distance between this and another position.
        /// </summary>
        /// <param name="self">This position.</param>
        /// <param name="other">The other position.</param>
        /// <returns>The distance.</returns>
        public static float Distance(this Vector3 self, Vector3 other) => self.Flatten().Distance(other);
        
        /// <summary>
        /// Get the distance between this and another position.
        /// </summary>
        /// <param name="self">This position.</param>
        /// <param name="other">The other position.</param>
        /// <returns>The distance.</returns>
        public static float Distance(this Vector3 self, [NotNull] Transform other) => self.Distance(other.position);
        
        /// <summary>
        /// Get the distance between this and another position.
        /// </summary>
        /// <param name="self">This position.</param>
        /// <param name="other">The other position.</param>
        /// <returns>The distance.</returns>
        public static float Distance(this Vector3 self, [NotNull] Component other) => self.Distance(other.transform.position);
        
        /// <summary>
        /// Get the distance between this and another position.
        /// </summary>
        /// <param name="self">This position.</param>
        /// <param name="other">The other position.</param>
        /// <returns>The distance.</returns>
        public static float Distance(this Vector3 self, [NotNull] GameObject other) => self.Distance(other.transform.position);
        
        /// <summary>
        /// Get the distance between this and another position.
        /// </summary>
        /// <param name="self">This object.</param>
        /// <param name="other">The other position.</param>
        /// <returns>The distance.</returns>
        public static float Distance([NotNull] this Transform self, Vector2 other) => self.position.Distance(other);
        
        /// <summary>
        /// Get the distance between this and another position.
        /// </summary>
        /// <param name="self">This object.</param>
        /// <param name="other">The other position.</param>
        /// <returns>The distance.</returns>
        public static float Distance([NotNull] this Transform self, Vector3 other) => self.position.Distance(other);
        
        /// <summary>
        /// Get the distance between this and another position.
        /// </summary>
        /// <param name="self">This object.</param>
        /// <param name="other">The other position.</param>
        /// <returns>The distance.</returns>
        public static float Distance([NotNull] this Transform self, [NotNull] Transform other) => self.position.Distance(other.position);
        
        /// <summary>
        /// Get the distance between this and another position.
        /// </summary>
        /// <param name="self">This object.</param>
        /// <param name="other">The other position.</param>
        /// <returns>The distance.</returns>
        public static float Distance([NotNull] this Transform self, [NotNull] Component other) => self.position.Distance(other.transform.position);
        
        /// <summary>
        /// Get the distance between this and another position.
        /// </summary>
        /// <param name="self">This object.</param>
        /// <param name="other">The other position.</param>
        /// <returns>The distance.</returns>
        public static float Distance([NotNull] this Transform self, [NotNull] GameObject other) => self.position.Distance(other.transform.position);
        
        /// <summary>
        /// Get the distance between this and another position.
        /// </summary>
        /// <param name="self">This object.</param>
        /// <param name="other">The other position.</param>
        /// <returns>The distance.</returns>
        public static float Distance([NotNull] this Component self, Vector2 other) => self.transform.position.Distance(other);
        
        /// <summary>
        /// Get the distance between this and another position.
        /// </summary>
        /// <param name="self">This object.</param>
        /// <param name="other">The other position.</param>
        /// <returns>The distance.</returns>
        public static float Distance([NotNull] this Component self, Vector3 other) => self.transform.position.Distance(other);
        
        /// <summary>
        /// Get the distance between this and another position.
        /// </summary>
        /// <param name="self">This object.</param>
        /// <param name="other">The other position.</param>
        /// <returns>The distance.</returns>
        public static float Distance([NotNull] this Component self, [NotNull] Transform other) => self.transform.position.Distance(other.position);
        
        /// <summary>
        /// Get the distance between this and another position.
        /// </summary>
        /// <param name="self">This object.</param>
        /// <param name="other">The other position.</param>
        /// <returns>The distance.</returns>
        public static float Distance([NotNull] this Component self, [NotNull] Component other) => self.transform.position.Distance(other.transform.position);
        
        /// <summary>
        /// Get the distance between this and another position.
        /// </summary>
        /// <param name="self">This object.</param>
        /// <param name="other">The other position.</param>
        /// <returns>The distance.</returns>
        public static float Distance([NotNull] this Component self, [NotNull] GameObject other) => self.transform.position.Distance(other.transform.position);
        
        /// <summary>
        /// Get the distance between this and another position.
        /// </summary>
        /// <param name="self">This object.</param>
        /// <param name="other">The other position.</param>
        /// <returns>The distance.</returns>
        public static float Distance([NotNull] this GameObject self, Vector2 other) => self.transform.position.Distance(other);
        
        /// <summary>
        /// Get the distance between this and another position.
        /// </summary>
        /// <param name="self">This object.</param>
        /// <param name="other">The other position.</param>
        /// <returns>The distance.</returns>
        public static float Distance([NotNull] this GameObject self, [NotNull] Transform other) => self.transform.position.Distance(other.position);

        
        /// <summary>
        /// Get the distance between this and another position.
        /// </summary>
        /// <param name="self">This object.</param>
        /// <param name="other">The other position.</param>
        /// <returns>The distance.</returns>
        public static float Distance([NotNull] this GameObject self, Vector3 other) => self.transform.position.Distance(other);
        
        /// <summary>
        /// Get the distance between this and another position.
        /// </summary>
        /// <param name="self">This object.</param>
        /// <param name="other">The other position.</param>
        /// <returns>The distance.</returns>
        public static float Distance([NotNull] this GameObject self, [NotNull] Component other) => self.transform.position.Distance(other.transform.position);
        
        /// <summary>
        /// Get the distance between this and another position.
        /// </summary>
        /// <param name="self">This object.</param>
        /// <param name="other">The other position.</param>
        /// <returns>The distance.</returns>
        public static float Distance([NotNull] this GameObject self, [NotNull] GameObject other) => self.transform.position.Distance(other.transform.position);
        
        /// <summary>
        /// If this is within a distance to another position.
        /// </summary>
        /// <param name="self">This position.</param>
        /// <param name="other">The other position.</param>
        /// <param name="distance">The distance.</param>
        /// <returns>If this is within a distance to another position.</returns>
        public static bool Within(this Vector2 self, Vector2 other, float distance) => self.Distance(other) <= distance;
        
        /// <summary>
        /// If this is within a distance to another position.
        /// </summary>
        /// <param name="self">This position.</param>
        /// <param name="other">The other position.</param>
        /// <param name="distance">The distance.</param>
        /// <returns>If this is within a distance to another position.</returns>
        public static bool Within(this Vector2 self, Vector3 other, float distance) => self.Within(other.Flatten(), distance);
        
        /// <summary>
        /// If this is within a distance to another position.
        /// </summary>
        /// <param name="self">This position.</param>
        /// <param name="other">The other position.</param>
        /// <param name="distance">The distance.</param>
        /// <returns>If this is within a distance to another position.</returns>
        public static bool Within(this Vector2 self, [NotNull] Transform other, float distance) => self.Within(other.position, distance);
        
        /// <summary>
        /// If this is within a distance to another position.
        /// </summary>
        /// <param name="self">This position.</param>
        /// <param name="other">The other position.</param>
        /// <param name="distance">The distance.</param>
        /// <returns>If this is within a distance to another position.</returns>
        public static bool Within(this Vector2 self, [NotNull] Component other, float distance) => self.Within(other.transform.position, distance);
        
        /// <summary>
        /// If this is within a distance to another position.
        /// </summary>
        /// <param name="self">This position.</param>
        /// <param name="other">The other position.</param>
        /// <param name="distance">The distance.</param>
        /// <returns>If this is within a distance to another position.</returns>
        public static bool Within(this Vector2 self, [NotNull] GameObject other, float distance) => self.Within(other.transform.position, distance);

        /// <summary>
        /// If this is within a distance to another position.
        /// </summary>
        /// <param name="self">This position.</param>
        /// <param name="other">The other position.</param>
        /// <param name="distance">The distance.</param>
        /// <returns>If this is within a distance to another position.</returns>
        public static bool Within(this Vector3 self, Vector2 other, float distance) => other.Within(self, distance);
        
        /// <summary>
        /// If this is within a distance to another position.
        /// </summary>
        /// <param name="self">This position.</param>
        /// <param name="other">The other position.</param>
        /// <param name="distance">The distance.</param>
        /// <returns>If this is within a distance to another position.</returns>
        public static bool Within(this Vector3 self, Vector3 other, float distance) => self.Distance(other) <= distance;
        
        /// <summary>
        /// If this is within a distance to another position.
        /// </summary>
        /// <param name="self">This position.</param>
        /// <param name="other">The other position.</param>
        /// <param name="distance">The distance.</param>
        /// <returns>If this is within a distance to another position.</returns>
        public static bool Within(this Vector3 self, [NotNull] Transform other, float distance) => self.Within(other.position, distance);
        
        /// <summary>
        /// If this is within a distance to another position.
        /// </summary>
        /// <param name="self">This position.</param>
        /// <param name="other">The other position.</param>
        /// <param name="distance">The distance.</param>
        /// <returns>If this is within a distance to another position.</returns>
        public static bool Within(this Vector3 self, [NotNull] Component other, float distance) => self.Within(other.transform.position, distance);
        
        /// <summary>
        /// If this is within a distance to another position.
        /// </summary>
        /// <param name="self">This position.</param>
        /// <param name="other">The other position.</param>
        /// <param name="distance">The distance.</param>
        /// <returns>If this is within a distance to another position.</returns>
        public static bool Within(this Vector3 self, [NotNull] GameObject other, float distance) => self.Within(other.transform.position, distance);
        
        /// <summary>
        /// If this is beyond a distance to another position.
        /// </summary>
        /// <param name="self">This position.</param>
        /// <param name="other">The other position.</param>
        /// <param name="distance">The distance.</param>
        /// <returns>If this is beyond a distance to another position.</returns>
        public static bool Beyond(this Vector2 self, Vector2 other, float distance) => self.Distance(other) >= distance;
        
        /// <summary>
        /// If this is beyond a distance to another position.
        /// </summary>
        /// <param name="self">This position.</param>
        /// <param name="other">The other position.</param>
        /// <param name="distance">The distance.</param>
        /// <returns>If this is beyond a distance to another position.</returns>
        public static bool Beyond(this Vector2 self, Vector3 other, float distance) => self.Beyond(other.Flatten(), distance);
        
        /// <summary>
        /// If this is beyond a distance to another position.
        /// </summary>
        /// <param name="self">This position.</param>
        /// <param name="other">The other position.</param>
        /// <param name="distance">The distance.</param>
        /// <returns>If this is beyond a distance to another position.</returns>
        public static bool Beyond(this Vector2 self, [NotNull] Transform other, float distance) => self.Beyond(other.position, distance);
        
        /// <summary>
        /// If this is beyond a distance to another position.
        /// </summary>
        /// <param name="self">This position.</param>
        /// <param name="other">The other position.</param>
        /// <param name="distance">The distance.</param>
        /// <returns>If this is beyond a distance to another position.</returns>
        public static bool Beyond(this Vector2 self, [NotNull] Component other, float distance) => self.Beyond(other.transform.position, distance);
        
        /// <summary>
        /// If this is beyond a distance to another position.
        /// </summary>
        /// <param name="self">This position.</param>
        /// <param name="other">The other position.</param>
        /// <param name="distance">The distance.</param>
        /// <returns>If this is beyond a distance to another position.</returns>
        public static bool Beyond(this Vector2 self, [NotNull] GameObject other, float distance) => self.Beyond(other.transform.position, distance);

        /// <summary>
        /// If this is beyond a distance to another position.
        /// </summary>
        /// <param name="self">This position.</param>
        /// <param name="other">The other position.</param>
        /// <param name="distance">The distance.</param>
        /// <returns>If this is beyond a distance to another position.</returns>
        public static bool Beyond(this Vector3 self, Vector2 other, float distance) => other.Beyond(self, distance);
        
        /// <summary>
        /// If this is beyond a distance to another position.
        /// </summary>
        /// <param name="self">This position.</param>
        /// <param name="other">The other position.</param>
        /// <param name="distance">The distance.</param>
        /// <returns>If this is beyond a distance to another position.</returns>
        public static bool Beyond(this Vector3 self, Vector3 other, float distance) => self.Distance(other) >= distance;
        
        /// <summary>
        /// If this is beyond a distance to another position.
        /// </summary>
        /// <param name="self">This position.</param>
        /// <param name="other">The other position.</param>
        /// <param name="distance">The distance.</param>
        /// <returns>If this is beyond a distance to another position.</returns>
        public static bool Beyond(this Vector3 self, [NotNull] Transform other, float distance) => self.Beyond(other.position, distance);
        
        /// <summary>
        /// If this is beyond a distance to another position.
        /// </summary>
        /// <param name="self">This position.</param>
        /// <param name="other">The other position.</param>
        /// <param name="distance">The distance.</param>
        /// <returns>If this is beyond a distance to another position.</returns>
        public static bool Beyond(this Vector3 self, [NotNull] Component other, float distance) => self.Beyond(other.transform.position, distance);
        
        /// <summary>
        /// If this is beyond a distance to another position.
        /// </summary>
        /// <param name="self">This position.</param>
        /// <param name="other">The other position.</param>
        /// <param name="distance">The distance.</param>
        /// <returns>If this is beyond a distance to another position.</returns>
        public static bool Beyond(this Vector3 self, [NotNull] GameObject other, float distance) => self.Beyond(other.transform.position, distance);

        /// <summary>
        /// If this is beyond a distance to another position.
        /// </summary>
        /// <param name="self">This object.</param>
        /// <param name="other">The other position.</param>
        /// <param name="distance">The distance.</param>
        /// <returns>If this is beyond a distance to another position.</returns>
        public static bool Beyond([NotNull] this Transform self, Vector2 other, float distance) => other.Beyond(self.position, distance);
        
        /// <summary>
        /// If this is beyond a distance to another position.
        /// </summary>
        /// <param name="self">This object.</param>
        /// <param name="other">The other position.</param>
        /// <param name="distance">The distance.</param>
        /// <returns>If this is beyond a distance to another position.</returns>
        public static bool Beyond([NotNull] this Transform self, Vector3 other, float distance) => self.position.Distance(other) >= distance;
        
        /// <summary>
        /// If this is beyond a distance to another position.
        /// </summary>
        /// <param name="self">This object.</param>
        /// <param name="other">The other position.</param>
        /// <param name="distance">The distance.</param>
        /// <returns>If this is beyond a distance to another position.</returns>
        public static bool Beyond([NotNull] this Transform self, [NotNull] Transform other, float distance) => self.position.Beyond(other.position, distance);
        
        /// <summary>
        /// If this is beyond a distance to another position.
        /// </summary>
        /// <param name="self">This object.</param>
        /// <param name="other">The other position.</param>
        /// <param name="distance">The distance.</param>
        /// <returns>If this is beyond a distance to another position.</returns>
        public static bool Beyond([NotNull] this Transform self, [NotNull] Component other, float distance) => self.position.Beyond(other.transform.position, distance);
        
        /// <summary>
        /// If this is beyond a distance to another position.
        /// </summary>
        /// <param name="self">This object.</param>
        /// <param name="other">The other position.</param>
        /// <param name="distance">The distance.</param>
        /// <returns>If this is beyond a distance to another position.</returns>
        public static bool Beyond([NotNull] this Transform self, [NotNull] GameObject other, float distance) => self.position.Beyond(other.transform.position, distance);

        /// <summary>
        /// If this is beyond a distance to another position.
        /// </summary>
        /// <param name="self">This object.</param>
        /// <param name="other">The other position.</param>
        /// <param name="distance">The distance.</param>
        /// <returns>If this is beyond a distance to another position.</returns>
        public static bool Beyond([NotNull] this Component self, Vector2 other, float distance) => other.Beyond(self.transform.position, distance);
        
        /// <summary>
        /// If this is beyond a distance to another position.
        /// </summary>
        /// <param name="self">This object.</param>
        /// <param name="other">The other position.</param>
        /// <param name="distance">The distance.</param>
        /// <returns>If this is beyond a distance to another position.</returns>
        public static bool Beyond([NotNull] this Component self, Vector3 other, float distance) => self.transform.position.Distance(other) >= distance;
        
        /// <summary>
        /// If this is beyond a distance to another position.
        /// </summary>
        /// <param name="self">This object.</param>
        /// <param name="other">The other position.</param>
        /// <param name="distance">The distance.</param>
        /// <returns>If this is beyond a distance to another position.</returns>
        public static bool Beyond([NotNull] this Component self, [NotNull] Transform other, float distance) => self.transform.position.Beyond(other.position, distance);
        
        /// <summary>
        /// If this is beyond a distance to another position.
        /// </summary>
        /// <param name="self">This object.</param>
        /// <param name="other">The other position.</param>
        /// <param name="distance">The distance.</param>
        /// <returns>If this is beyond a distance to another position.</returns>
        public static bool Beyond([NotNull] this Component self, [NotNull] Component other, float distance) => self.transform.position.Beyond(other.transform.position, distance);
        
        /// <summary>
        /// If this is beyond a distance to another position.
        /// </summary>
        /// <param name="self">This object.</param>
        /// <param name="other">The other position.</param>
        /// <param name="distance">The distance.</param>
        /// <returns>If this is beyond a distance to another position.</returns>
        public static bool Beyond([NotNull] this Component self, [NotNull] GameObject other, float distance) => self.transform.position.Beyond(other.transform.position, distance);

        /// <summary>
        /// If this is beyond a distance to another position.
        /// </summary>
        /// <param name="self">This object.</param>
        /// <param name="other">The other position.</param>
        /// <param name="distance">The distance.</param>
        /// <returns>If this is beyond a distance to another position.</returns>
        public static bool Beyond([NotNull] this GameObject self, Vector2 other, float distance) => other.Beyond(self.transform.position, distance);
        
        /// <summary>
        /// If this is beyond a distance to another position.
        /// </summary>
        /// <param name="self">This object.</param>
        /// <param name="other">The other position.</param>
        /// <param name="distance">The distance.</param>
        /// <returns>If this is beyond a distance to another position.</returns>
        public static bool Beyond([NotNull] this GameObject self, Vector3 other, float distance) => self.transform.position.Distance(other) >= distance;
        
        /// <summary>
        /// If this is beyond a distance to another position.
        /// </summary>
        /// <param name="self">This object.</param>
        /// <param name="other">The other position.</param>
        /// <param name="distance">The distance.</param>
        /// <returns>If this is beyond a distance to another position.</returns>
        public static bool Beyond([NotNull] this GameObject self, [NotNull] Transform other, float distance) => self.transform.position.Beyond(other.position, distance);
        
        /// <summary>
        /// If this is beyond a distance to another position.
        /// </summary>
        /// <param name="self">This object.</param>
        /// <param name="other">The other position.</param>
        /// <param name="distance">The distance.</param>
        /// <returns>If this is beyond a distance to another position.</returns>
        public static bool Beyond([NotNull] this GameObject self, [NotNull] Component other, float distance) => self.transform.position.Beyond(other.transform.position, distance);
        
        /// <summary>
        /// If this is beyond a distance to another position.
        /// </summary>
        /// <param name="self">This object.</param>
        /// <param name="other">The other position.</param>
        /// <param name="distance">The distance.</param>
        /// <returns>If this is beyond a distance to another position.</returns>
        public static bool Beyond([NotNull] this GameObject self, [NotNull] GameObject other, float distance) => self.transform.position.Beyond(other.transform.position, distance);
        
        /// <summary>
        /// If this is between two distances to another position.
        /// </summary>
        /// <param name="self">This position.</param>
        /// <param name="other">The other position.</param>
        /// <param name="minimum">The minimum distance.</param>
        /// <param name="maximum">The maximum distance.</param>
        /// <returns>If this is between two distances to another position.</returns>
        public static bool Between(this Vector2 self, Vector2 other, float minimum, float maximum)
        {
            float distance = self.Distance(other);
            return distance >= minimum && distance <= maximum;
        }
        
        /// <summary>
        /// If this is between two distances to another position.
        /// </summary>
        /// <param name="self">This position.</param>
        /// <param name="other">The other position.</param>
        /// <param name="minimum">The minimum distance.</param>
        /// <param name="maximum">The maximum distance.</param>
        /// <returns>If this is between two distances to another position.</returns>
        public static bool Between(this Vector2 self, Vector3 other, float minimum, float maximum) => self.Between(other.Flatten(), minimum, maximum);
        
        /// <summary>
        /// If this is between two distances to another position.
        /// </summary>
        /// <param name="self">This position.</param>
        /// <param name="other">The other position.</param>
        /// <param name="minimum">The minimum distance.</param>
        /// <param name="maximum">The maximum distance.</param>
        /// <returns>If this is between two distances to another position.</returns>
        public static bool Between(this Vector2 self, [NotNull] Transform other, float minimum, float maximum) => self.Between(other.position, minimum, maximum);
        
        /// <summary>
        /// If this is between two distances to another position.
        /// </summary>
        /// <param name="self">This position.</param>
        /// <param name="other">The other position.</param>
        /// <param name="minimum">The minimum distance.</param>
        /// <param name="maximum">The maximum distance.</param>
        /// <returns>If this is between two distances to another position.</returns>
        public static bool Between(this Vector2 self, [NotNull] Component other, float minimum, float maximum) => self.Between(other.transform.position, minimum, maximum);
        
        /// <summary>
        /// If this is between two distances to another position.
        /// </summary>
        /// <param name="self">This position.</param>
        /// <param name="other">The other position.</param>
        /// <param name="minimum">The minimum distance.</param>
        /// <param name="maximum">The maximum distance.</param>
        /// <returns>If this is between two distances to another position.</returns>
        public static bool Between(this Vector2 self, [NotNull] GameObject other, float minimum, float maximum) => self.Between(other.transform.position, minimum, maximum);
        
        /// <summary>
        /// If this is between two distances to another position.
        /// </summary>
        /// <param name="self">This position.</param>
        /// <param name="other">The other position.</param>
        /// <param name="minimum">The minimum distance.</param>
        /// <param name="maximum">The maximum distance.</param>
        /// <returns>If this is between two distances to another position.</returns>
        public static bool Between(this Vector3 self, Vector2 other, float minimum, float maximum) => other.Between(self, minimum, maximum);

        /// <summary>
        /// If this is between two distances to another position.
        /// </summary>
        /// <param name="self">This position.</param>
        /// <param name="other">The other position.</param>
        /// <param name="minimum">The minimum distance.</param>
        /// <param name="maximum">The maximum distance.</param>
        /// <returns>If this is between two distances to another position.</returns>
        public static bool Between(this Vector3 self, Vector3 other, float minimum, float maximum) => self.Flatten().Between(other, minimum, maximum);
        
        /// <summary>
        /// If this is between two distances to another position.
        /// </summary>
        /// <param name="self">This position.</param>
        /// <param name="other">The other position.</param>
        /// <param name="minimum">The minimum distance.</param>
        /// <param name="maximum">The maximum distance.</param>
        /// <returns>If this is between two distances to another position.</returns>
        public static bool Between(this Vector3 self, [NotNull] Transform other, float minimum, float maximum) => self.Between(other.position, minimum, maximum);
        
        /// <summary>
        /// If this is between two distances to another position.
        /// </summary>
        /// <param name="self">This position.</param>
        /// <param name="other">The other position.</param>
        /// <param name="minimum">The minimum distance.</param>
        /// <param name="maximum">The maximum distance.</param>
        /// <returns>If this is between two distances to another position.</returns>
        public static bool Between(this Vector3 self, [NotNull] Component other, float minimum, float maximum) => self.Between(other.transform.position, minimum, maximum);
        
        /// <summary>
        /// If this is between two distances to another position.
        /// </summary>
        /// <param name="self">This position.</param>
        /// <param name="other">The other position.</param>
        /// <param name="minimum">The minimum distance.</param>
        /// <param name="maximum">The maximum distance.</param>
        /// <returns>If this is between two distances to another position.</returns>
        public static bool Between(this Vector3 self, [NotNull] GameObject other, float minimum, float maximum) => self.Between(other.transform.position, minimum, maximum);
        
        /// <summary>
        /// If this is between two distances to another position.
        /// </summary>
        /// <param name="self">This position.</param>
        /// <param name="other">The other position.</param>
        /// <param name="minimum">The minimum distance.</param>
        /// <param name="maximum">The maximum distance.</param>
        /// <returns>If this is between two distances to another position.</returns>
        public static bool Between([NotNull] this Transform self, Vector2 other, float minimum, float maximum) => other.Between(self.position, minimum, maximum);
        
        /// <summary>
        /// If this is between two distances to another position.
        /// </summary>
        /// <param name="self">This position.</param>
        /// <param name="other">The other position.</param>
        /// <param name="minimum">The minimum distance.</param>
        /// <param name="maximum">The maximum distance.</param>
        /// <returns>If this is between two distances to another position.</returns>
        public static bool Between([NotNull] this Transform self, Vector3 other, float minimum, float maximum) => self.position.Between(other, minimum, maximum);
        
        /// <summary>
        /// If this is between two distances to another position.
        /// </summary>
        /// <param name="self">This position.</param>
        /// <param name="other">The other position.</param>
        /// <param name="minimum">The minimum distance.</param>
        /// <param name="maximum">The maximum distance.</param>
        /// <returns>If this is between two distances to another position.</returns>
        public static bool Between([NotNull] this Transform self, [NotNull] Transform other, float minimum, float maximum) => self.position.Between(other.position, minimum, maximum);
        
        /// <summary>
        /// If this is between two distances to another position.
        /// </summary>
        /// <param name="self">This position.</param>
        /// <param name="other">The other position.</param>
        /// <param name="minimum">The minimum distance.</param>
        /// <param name="maximum">The maximum distance.</param>
        /// <returns>If this is between two distances to another position.</returns>
        public static bool Between([NotNull] this Transform self, [NotNull] Component other, float minimum, float maximum) => self.position.Between(other.transform.position, minimum, maximum);
        
        /// <summary>
        /// If this is between two distances to another position.
        /// </summary>
        /// <param name="self">This position.</param>
        /// <param name="other">The other position.</param>
        /// <param name="minimum">The minimum distance.</param>
        /// <param name="maximum">The maximum distance.</param>
        /// <returns>If this is between two distances to another position.</returns>
        public static bool Between([NotNull] this Transform self, [NotNull] GameObject other, float minimum, float maximum) => self.position.Between(other.transform.position, minimum, maximum);
        
        /// <summary>
        /// If this is between two distances to another position.
        /// </summary>
        /// <param name="self">This position.</param>
        /// <param name="other">The other position.</param>
        /// <param name="minimum">The minimum distance.</param>
        /// <param name="maximum">The maximum distance.</param>
        /// <returns>If this is between two distances to another position.</returns>
        public static bool Between([NotNull] this Component self, Vector2 other, float minimum, float maximum) => other.Between(self.transform.position, minimum, maximum);
        
        /// <summary>
        /// If this is between two distances to another position.
        /// </summary>
        /// <param name="self">This position.</param>
        /// <param name="other">The other position.</param>
        /// <param name="minimum">The minimum distance.</param>
        /// <param name="maximum">The maximum distance.</param>
        /// <returns>If this is between two distances to another position.</returns>
        public static bool Between([NotNull] this Component self, Vector3 other, float minimum, float maximum) => self.transform.position.Between(other, minimum, maximum);
        
        /// <summary>
        /// If this is between two distances to another position.
        /// </summary>
        /// <param name="self">This position.</param>
        /// <param name="other">The other position.</param>
        /// <param name="minimum">The minimum distance.</param>
        /// <param name="maximum">The maximum distance.</param>
        /// <returns>If this is between two distances to another position.</returns>
        public static bool Between([NotNull] this Component self, [NotNull] Transform other, float minimum, float maximum) => self.transform.position.Between(other.position, minimum, maximum);
        
        /// <summary>
        /// If this is between two distances to another position.
        /// </summary>
        /// <param name="self">This position.</param>
        /// <param name="other">The other position.</param>
        /// <param name="minimum">The minimum distance.</param>
        /// <param name="maximum">The maximum distance.</param>
        /// <returns>If this is between two distances to another position.</returns>
        public static bool Between([NotNull] this Component self, [NotNull] Component other, float minimum, float maximum) => self.transform.position.Between(other.transform.position, minimum, maximum);
        
        /// <summary>
        /// If this is between two distances to another position.
        /// </summary>
        /// <param name="self">This position.</param>
        /// <param name="other">The other position.</param>
        /// <param name="minimum">The minimum distance.</param>
        /// <param name="maximum">The maximum distance.</param>
        /// <returns>If this is between two distances to another position.</returns>
        public static bool Between([NotNull] this Component self, [NotNull] GameObject other, float minimum, float maximum) => self.transform.position.Between(other.transform.position, minimum, maximum);
        
        /// <summary>
        /// If this is between two distances to another position.
        /// </summary>
        /// <param name="self">This position.</param>
        /// <param name="other">The other position.</param>
        /// <param name="minimum">The minimum distance.</param>
        /// <param name="maximum">The maximum distance.</param>
        /// <returns>If this is between two distances to another position.</returns>
        public static bool Between([NotNull] this GameObject self, Vector2 other, float minimum, float maximum) => other.Between(self.transform.position, minimum, maximum);
        
        /// <summary>
        /// If this is between two distances to another position.
        /// </summary>
        /// <param name="self">This position.</param>
        /// <param name="other">The other position.</param>
        /// <param name="minimum">The minimum distance.</param>
        /// <param name="maximum">The maximum distance.</param>
        /// <returns>If this is between two distances to another position.</returns>
        public static bool Between([NotNull] this GameObject self, Vector3 other, float minimum, float maximum) => self.transform.position.Between(other, minimum, maximum);
        
        /// <summary>
        /// If this is between two distances to another position.
        /// </summary>
        /// <param name="self">This position.</param>
        /// <param name="other">The other position.</param>
        /// <param name="minimum">The minimum distance.</param>
        /// <param name="maximum">The maximum distance.</param>
        /// <returns>If this is between two distances to another position.</returns>
        public static bool Between([NotNull] this GameObject self, [NotNull] Transform other, float minimum, float maximum) => self.transform.position.Between(other.position, minimum, maximum);
        
        /// <summary>
        /// If this is between two distances to another position.
        /// </summary>
        /// <param name="self">This position.</param>
        /// <param name="other">The other position.</param>
        /// <param name="minimum">The minimum distance.</param>
        /// <param name="maximum">The maximum distance.</param>
        /// <returns>If this is between two distances to another position.</returns>
        public static bool Between([NotNull] this GameObject self, [NotNull] Component other, float minimum, float maximum) => self.transform.position.Between(other.transform.position, minimum, maximum);
        
        /// <summary>
        /// If this is between two distances to another position.
        /// </summary>
        /// <param name="self">This position.</param>
        /// <param name="other">The other position.</param>
        /// <param name="minimum">The minimum distance.</param>
        /// <param name="maximum">The maximum distance.</param>
        /// <returns>If this is between two distances to another position.</returns>
        public static bool Between([NotNull] this GameObject self, [NotNull] GameObject other, float minimum, float maximum) => self.transform.position.Between(other.transform.position, minimum, maximum);
        
        /// <summary>
        /// Get the distance between this and another position.
        /// </summary>
        /// <param name="self">This position.</param>
        /// <param name="other">The other position.</param>
        /// <returns>The distance.</returns>
        public static float Distance3(this Vector3 self, Vector3 other) => Vector3.Distance(self, other);
        
        /// <summary>
        /// Get the distance between this and another position.
        /// </summary>
        /// <param name="self">This position.</param>
        /// <param name="other">The other position.</param>
        /// <returns>The distance.</returns>
        public static float Distance3(this Vector3 self, [NotNull] Transform other) => self.Distance3(other.position);
        
        /// <summary>
        /// Get the distance between this and another position.
        /// </summary>
        /// <param name="self">This position.</param>
        /// <param name="other">The other position.</param>
        /// <returns>The distance.</returns>
        public static float Distance3(this Vector3 self, [NotNull] Component other) => self.Distance3(other.transform.position);
        
        /// <summary>
        /// Get the distance between this and another position.
        /// </summary>
        /// <param name="self">This position.</param>
        /// <param name="other">The other position.</param>
        /// <returns>The distance.</returns>
        public static float Distance3(this Vector3 self, [NotNull] GameObject other) => self.Distance3(other.transform.position);
        
        /// <summary>
        /// Get the distance between this and another position.
        /// </summary>
        /// <param name="self">This object.</param>
        /// <param name="other">The other position.</param>
        /// <returns>The distance.</returns>
        public static float Distance3([NotNull] this Transform self, Vector3 other) => self.position.Distance3(other);
        
        /// <summary>
        /// Get the distance between this and another position.
        /// </summary>
        /// <param name="self">This object.</param>
        /// <param name="other">The other position.</param>
        /// <returns>The distance.</returns>
        public static float Distance3([NotNull] this Transform self, [NotNull] Transform other) => self.position.Distance3(other.position);
        
        /// <summary>
        /// Get the distance between this and another position.
        /// </summary>
        /// <param name="self">This object.</param>
        /// <param name="other">The other position.</param>
        /// <returns>The distance.</returns>
        public static float Distance3([NotNull] this Transform self, [NotNull] Component other) => self.position.Distance3(other.transform.position);
        
        /// <summary>
        /// Get the distance between this and another position.
        /// </summary>
        /// <param name="self">This object.</param>
        /// <param name="other">The other position.</param>
        /// <returns>The distance.</returns>
        public static float Distance3([NotNull] this Transform self, [NotNull] GameObject other) => self.position.Distance3(other.transform.position);
        
        /// <summary>
        /// Get the distance between this and another position.
        /// </summary>
        /// <param name="self">This object.</param>
        /// <param name="other">The other position.</param>
        /// <returns>The distance.</returns>
        public static float Distance3([NotNull] this Component self, Vector3 other) => self.transform.position.Distance3(other);
        
        /// <summary>
        /// Get the distance between this and another position.
        /// </summary>
        /// <param name="self">This object.</param>
        /// <param name="other">The other position.</param>
        /// <returns>The distance.</returns>
        public static float Distance3([NotNull] this Component self, [NotNull] Transform other) => self.transform.position.Distance3(other.position);
        
        /// <summary>
        /// Get the distance between this and another position.
        /// </summary>
        /// <param name="self">This object.</param>
        /// <param name="other">The other position.</param>
        /// <returns>The distance.</returns>
        public static float Distance3([NotNull] this Component self, [NotNull] Component other) => self.transform.position.Distance3(other.transform.position);
        
        /// <summary>
        /// Get the distance between this and another position.
        /// </summary>
        /// <param name="self">This object.</param>
        /// <param name="other">The other position.</param>
        /// <returns>The distance.</returns>
        public static float Distance3([NotNull] this Component self, [NotNull] GameObject other) => self.transform.position.Distance3(other.transform.position);
        
        /// <summary>
        /// Get the distance between this and another position.
        /// </summary>
        /// <param name="self">This object.</param>
        /// <param name="other">The other position.</param>
        /// <returns>The distance.</returns>
        public static float Distance3([NotNull] this GameObject self, [NotNull] Transform other) => self.transform.position.Distance3(other.position);

        
        /// <summary>
        /// Get the distance between this and another position.
        /// </summary>
        /// <param name="self">This object.</param>
        /// <param name="other">The other position.</param>
        /// <returns>The distance.</returns>
        public static float Distance3([NotNull] this GameObject self, Vector3 other) => self.transform.position.Distance3(other);
        
        /// <summary>
        /// Get the distance between this and another position.
        /// </summary>
        /// <param name="self">This object.</param>
        /// <param name="other">The other position.</param>
        /// <returns>The distance.</returns>
        public static float Distance3([NotNull] this GameObject self, [NotNull] Component other) => self.transform.position.Distance3(other.transform.position);
        
        /// <summary>
        /// Get the distance between this and another position.
        /// </summary>
        /// <param name="self">This object.</param>
        /// <param name="other">The other position.</param>
        /// <returns>The distance.</returns>
        public static float Distance3([NotNull] this GameObject self, [NotNull] GameObject other) => self.transform.position.Distance3(other.transform.position);
        
        /// <summary>
        /// If this is within a distance to another position.
        /// </summary>
        /// <param name="self">This position.</param>
        /// <param name="other">The other position.</param>
        /// <param name="distance">The distance.</param>
        /// <returns>If this is within a distance to another position.</returns>
        public static bool Within3(this Vector3 self, Vector3 other, float distance) => self.Distance3(other) <= distance;
        
        /// <summary>
        /// If this is within a distance to another position.
        /// </summary>
        /// <param name="self">This position.</param>
        /// <param name="other">The other position.</param>
        /// <param name="distance">The distance.</param>
        /// <returns>If this is within a distance to another position.</returns>
        public static bool Within3(this Vector3 self, [NotNull] Transform other, float distance) => self.Within3(other.position, distance);
        
        /// <summary>
        /// If this is within a distance to another position.
        /// </summary>
        /// <param name="self">This position.</param>
        /// <param name="other">The other position.</param>
        /// <param name="distance">The distance.</param>
        /// <returns>If this is within a distance to another position.</returns>
        public static bool Within3(this Vector3 self, [NotNull] Component other, float distance) => self.Within3(other.transform.position, distance);
        
        /// <summary>
        /// If this is within a distance to another position.
        /// </summary>
        /// <param name="self">This position.</param>
        /// <param name="other">The other position.</param>
        /// <param name="distance">The distance.</param>
        /// <returns>If this is within a distance to another position.</returns>
        public static bool Within3(this Vector3 self, [NotNull] GameObject other, float distance) => self.Within3(other.transform.position, distance);
        
        /// <summary>
        /// If this is beyond a distance to another position.
        /// </summary>
        /// <param name="self">This position.</param>
        /// <param name="other">The other position.</param>
        /// <param name="distance">The distance.</param>
        /// <returns>If this is beyond a distance to another position.</returns>
        public static bool Beyond3(this Vector3 self, Vector3 other, float distance) => self.Distance3(other) >= distance;
        
        /// <summary>
        /// If this is beyond a distance to another position.
        /// </summary>
        /// <param name="self">This position.</param>
        /// <param name="other">The other position.</param>
        /// <param name="distance">The distance.</param>
        /// <returns>If this is beyond a distance to another position.</returns>
        public static bool Beyond3(this Vector3 self, [NotNull] Transform other, float distance) => self.Beyond3(other.position, distance);
        
        /// <summary>
        /// If this is beyond a distance to another position.
        /// </summary>
        /// <param name="self">This position.</param>
        /// <param name="other">The other position.</param>
        /// <param name="distance">The distance.</param>
        /// <returns>If this is beyond a distance to another position.</returns>
        public static bool Beyond3(this Vector3 self, [NotNull] Component other, float distance) => self.Beyond3(other.transform.position, distance);
        
        /// <summary>
        /// If this is beyond a distance to another position.
        /// </summary>
        /// <param name="self">This position.</param>
        /// <param name="other">The other position.</param>
        /// <param name="distance">The distance.</param>
        /// <returns>If this is beyond a distance to another position.</returns>
        public static bool Beyond3(this Vector3 self, [NotNull] GameObject other, float distance) => self.Beyond3(other.transform.position, distance);
        
        /// <summary>
        /// If this is beyond a distance to another position.
        /// </summary>
        /// <param name="self">This object.</param>
        /// <param name="other">The other position.</param>
        /// <param name="distance">The distance.</param>
        /// <returns>If this is beyond a distance to another position.</returns>
        public static bool Beyond3([NotNull] this Transform self, Vector3 other, float distance) => self.position.Distance3(other) >= distance;
        
        /// <summary>
        /// If this is beyond a distance to another position.
        /// </summary>
        /// <param name="self">This object.</param>
        /// <param name="other">The other position.</param>
        /// <param name="distance">The distance.</param>
        /// <returns>If this is beyond a distance to another position.</returns>
        public static bool Beyond3([NotNull] this Transform self, [NotNull] Transform other, float distance) => self.position.Beyond3(other.position, distance);
        
        /// <summary>
        /// If this is beyond a distance to another position.
        /// </summary>
        /// <param name="self">This object.</param>
        /// <param name="other">The other position.</param>
        /// <param name="distance">The distance.</param>
        /// <returns>If this is beyond a distance to another position.</returns>
        public static bool Beyond3([NotNull] this Transform self, [NotNull] Component other, float distance) => self.position.Beyond3(other.transform.position, distance);
        
        /// <summary>
        /// If this is beyond a distance to another position.
        /// </summary>
        /// <param name="self">This object.</param>
        /// <param name="other">The other position.</param>
        /// <param name="distance">The distance.</param>
        /// <returns>If this is beyond a distance to another position.</returns>
        public static bool Beyond3([NotNull] this Transform self, [NotNull] GameObject other, float distance) => self.position.Beyond3(other.transform.position, distance);
        
        /// <summary>
        /// If this is beyond a distance to another position.
        /// </summary>
        /// <param name="self">This object.</param>
        /// <param name="other">The other position.</param>
        /// <param name="distance">The distance.</param>
        /// <returns>If this is beyond a distance to another position.</returns>
        public static bool Beyond3([NotNull] this Component self, Vector3 other, float distance) => self.transform.position.Distance3(other) >= distance;
        
        /// <summary>
        /// If this is beyond a distance to another position.
        /// </summary>
        /// <param name="self">This object.</param>
        /// <param name="other">The other position.</param>
        /// <param name="distance">The distance.</param>
        /// <returns>If this is beyond a distance to another position.</returns>
        public static bool Beyond3([NotNull] this Component self, [NotNull] Transform other, float distance) => self.transform.position.Beyond3(other.position, distance);
        
        /// <summary>
        /// If this is beyond a distance to another position.
        /// </summary>
        /// <param name="self">This object.</param>
        /// <param name="other">The other position.</param>
        /// <param name="distance">The distance.</param>
        /// <returns>If this is beyond a distance to another position.</returns>
        public static bool Beyond3([NotNull] this Component self, [NotNull] Component other, float distance) => self.transform.position.Beyond3(other.transform.position, distance);
        
        /// <summary>
        /// If this is beyond a distance to another position.
        /// </summary>
        /// <param name="self">This object.</param>
        /// <param name="other">The other position.</param>
        /// <param name="distance">The distance.</param>
        /// <returns>If this is beyond a distance to another position.</returns>
        public static bool Beyond3([NotNull] this Component self, [NotNull] GameObject other, float distance) => self.transform.position.Beyond3(other.transform.position, distance);
        
        /// <summary>
        /// If this is beyond a distance to another position.
        /// </summary>
        /// <param name="self">This object.</param>
        /// <param name="other">The other position.</param>
        /// <param name="distance">The distance.</param>
        /// <returns>If this is beyond a distance to another position.</returns>
        public static bool Beyond3([NotNull] this GameObject self, Vector3 other, float distance) => self.transform.position.Distance3(other) >= distance;
        
        /// <summary>
        /// If this is beyond a distance to another position.
        /// </summary>
        /// <param name="self">This object.</param>
        /// <param name="other">The other position.</param>
        /// <param name="distance">The distance.</param>
        /// <returns>If this is beyond a distance to another position.</returns>
        public static bool Beyond3([NotNull] this GameObject self, [NotNull] Transform other, float distance) => self.transform.position.Beyond3(other.position, distance);
        
        /// <summary>
        /// If this is beyond a distance to another position.
        /// </summary>
        /// <param name="self">This object.</param>
        /// <param name="other">The other position.</param>
        /// <param name="distance">The distance.</param>
        /// <returns>If this is beyond a distance to another position.</returns>
        public static bool Beyond3([NotNull] this GameObject self, [NotNull] Component other, float distance) => self.transform.position.Beyond3(other.transform.position, distance);
        
        /// <summary>
        /// If this is beyond a distance to another position.
        /// </summary>
        /// <param name="self">This object.</param>
        /// <param name="other">The other position.</param>
        /// <param name="distance">The distance.</param>
        /// <returns>If this is beyond a distance to another position.</returns>
        public static bool Beyond3([NotNull] this GameObject self, [NotNull] GameObject other, float distance) => self.transform.position.Beyond3(other.transform.position, distance);
        
        /// <summary>
        /// If this is between two distances to another position.
        /// </summary>
        /// <param name="self">This position.</param>
        /// <param name="other">The other position.</param>
        /// <param name="minimum">The minimum distance.</param>
        /// <param name="maximum">The maximum distance.</param>
        /// <returns>If this is between two distances to another position.</returns>
        public static bool Between3(this Vector3 self, Vector3 other, float minimum, float maximum)
        {
            float distance = self.Distance3(other);
            return distance >= minimum && distance <= maximum;
        }
        
        /// <summary>
        /// If this is between two distances to another position.
        /// </summary>
        /// <param name="self">This position.</param>
        /// <param name="other">The other position.</param>
        /// <param name="minimum">The minimum distance.</param>
        /// <param name="maximum">The maximum distance.</param>
        /// <returns>If this is between two distances to another position.</returns>
        public static bool Between3(this Vector3 self, [NotNull] Transform other, float minimum, float maximum) => self.Between3(other.position, minimum, maximum);
        
        /// <summary>
        /// If this is between two distances to another position.
        /// </summary>
        /// <param name="self">This position.</param>
        /// <param name="other">The other position.</param>
        /// <param name="minimum">The minimum distance.</param>
        /// <param name="maximum">The maximum distance.</param>
        /// <returns>If this is between two distances to another position.</returns>
        public static bool Between3(this Vector3 self, [NotNull] Component other, float minimum, float maximum) => self.Between3(other.transform.position, minimum, maximum);
        
        /// <summary>
        /// If this is between two distances to another position.
        /// </summary>
        /// <param name="self">This position.</param>
        /// <param name="other">The other position.</param>
        /// <param name="minimum">The minimum distance.</param>
        /// <param name="maximum">The maximum distance.</param>
        /// <returns>If this is between two distances to another position.</returns>
        public static bool Between3(this Vector3 self, [NotNull] GameObject other, float minimum, float maximum) => self.Between3(other.transform.position, minimum, maximum);
        
        /// <summary>
        /// If this is between two distances to another position.
        /// </summary>
        /// <param name="self">This position.</param>
        /// <param name="other">The other position.</param>
        /// <param name="minimum">The minimum distance.</param>
        /// <param name="maximum">The maximum distance.</param>
        /// <returns>If this is between two distances to another position.</returns>
        public static bool Between3([NotNull] this Transform self, Vector3 other, float minimum, float maximum) => self.position.Between3(other, minimum, maximum);
        
        /// <summary>
        /// If this is between two distances to another position.
        /// </summary>
        /// <param name="self">This position.</param>
        /// <param name="other">The other position.</param>
        /// <param name="minimum">The minimum distance.</param>
        /// <param name="maximum">The maximum distance.</param>
        /// <returns>If this is between two distances to another position.</returns>
        public static bool Between3([NotNull] this Transform self, [NotNull] Transform other, float minimum, float maximum) => self.position.Between3(other.position, minimum, maximum);
        
        /// <summary>
        /// If this is between two distances to another position.
        /// </summary>
        /// <param name="self">This position.</param>
        /// <param name="other">The other position.</param>
        /// <param name="minimum">The minimum distance.</param>
        /// <param name="maximum">The maximum distance.</param>
        /// <returns>If this is between two distances to another position.</returns>
        public static bool Between3([NotNull] this Transform self, [NotNull] Component other, float minimum, float maximum) => self.position.Between3(other.transform.position, minimum, maximum);
        
        /// <summary>
        /// If this is between two distances to another position.
        /// </summary>
        /// <param name="self">This position.</param>
        /// <param name="other">The other position.</param>
        /// <param name="minimum">The minimum distance.</param>
        /// <param name="maximum">The maximum distance.</param>
        /// <returns>If this is between two distances to another position.</returns>
        public static bool Between3([NotNull] this Transform self, [NotNull] GameObject other, float minimum, float maximum) => self.position.Between3(other.transform.position, minimum, maximum);
        
        /// <summary>
        /// If this is between two distances to another position.
        /// </summary>
        /// <param name="self">This position.</param>
        /// <param name="other">The other position.</param>
        /// <param name="minimum">The minimum distance.</param>
        /// <param name="maximum">The maximum distance.</param>
        /// <returns>If this is between two distances to another position.</returns>
        public static bool Between3([NotNull] this Component self, Vector3 other, float minimum, float maximum) => self.transform.position.Between3(other, minimum, maximum);
        
        /// <summary>
        /// If this is between two distances to another position.
        /// </summary>
        /// <param name="self">This position.</param>
        /// <param name="other">The other position.</param>
        /// <param name="minimum">The minimum distance.</param>
        /// <param name="maximum">The maximum distance.</param>
        /// <returns>If this is between two distances to another position.</returns>
        public static bool Between3([NotNull] this Component self, [NotNull] Transform other, float minimum, float maximum) => self.transform.position.Between3(other.position, minimum, maximum);
        
        /// <summary>
        /// If this is between two distances to another position.
        /// </summary>
        /// <param name="self">This position.</param>
        /// <param name="other">The other position.</param>
        /// <param name="minimum">The minimum distance.</param>
        /// <param name="maximum">The maximum distance.</param>
        /// <returns>If this is between two distances to another position.</returns>
        public static bool Between3([NotNull] this Component self, [NotNull] Component other, float minimum, float maximum) => self.transform.position.Between3(other.transform.position, minimum, maximum);
        
        /// <summary>
        /// If this is between two distances to another position.
        /// </summary>
        /// <param name="self">This position.</param>
        /// <param name="other">The other position.</param>
        /// <param name="minimum">The minimum distance.</param>
        /// <param name="maximum">The maximum distance.</param>
        /// <returns>If this is between two distances to another position.</returns>
        public static bool Between3([NotNull] this Component self, [NotNull] GameObject other, float minimum, float maximum) => self.transform.position.Between3(other.transform.position, minimum, maximum);
        
        /// <summary>
        /// If this is between two distances to another position.
        /// </summary>
        /// <param name="self">This position.</param>
        /// <param name="other">The other position.</param>
        /// <param name="minimum">The minimum distance.</param>
        /// <param name="maximum">The maximum distance.</param>
        /// <returns>If this is between two distances to another position.</returns>
        public static bool Between3([NotNull] this GameObject self, Vector3 other, float minimum, float maximum) => self.transform.position.Between3(other, minimum, maximum);
        
        /// <summary>
        /// If this is between two distances to another position.
        /// </summary>
        /// <param name="self">This position.</param>
        /// <param name="other">The other position.</param>
        /// <param name="minimum">The minimum distance.</param>
        /// <param name="maximum">The maximum distance.</param>
        /// <returns>If this is between two distances to another position.</returns>
        public static bool Between3([NotNull] this GameObject self, [NotNull] Transform other, float minimum, float maximum) => self.transform.position.Between3(other.position, minimum, maximum);
        
        /// <summary>
        /// If this is between two distances to another position.
        /// </summary>
        /// <param name="self">This position.</param>
        /// <param name="other">The other position.</param>
        /// <param name="minimum">The minimum distance.</param>
        /// <param name="maximum">The maximum distance.</param>
        /// <returns>If this is between two distances to another position.</returns>
        public static bool Between3([NotNull] this GameObject self, [NotNull] Component other, float minimum, float maximum) => self.transform.position.Between3(other.transform.position, minimum, maximum);
        
        /// <summary>
        /// If this is between two distances to another position.
        /// </summary>
        /// <param name="self">This position.</param>
        /// <param name="other">The other position.</param>
        /// <param name="minimum">The minimum distance.</param>
        /// <param name="maximum">The maximum distance.</param>
        /// <returns>If this is between two distances to another position.</returns>
        public static bool Between3([NotNull] this GameObject self, [NotNull] GameObject other, float minimum, float maximum) => self.transform.position.Between3(other.transform.position, minimum, maximum);
        
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
        
        /// <summary>
        /// The current speed based on the time it took to move from a previous position.
        /// </summary>
        /// <param name="current">The current position.</param>
        /// <param name="previous">The previous position.</param>
        /// <param name="delta">The time since the last position.</param>
        /// <returns>The current speed based on the time it took to move from a previous position.</returns>
        public static float Speed3(this Vector3 current, Vector3 previous, float delta) => current.Distance3(previous) / delta;
        
        /// <summary>
        /// The current speed based on the time it took to move from a previous position.
        /// </summary>
        /// <param name="current">The current position.</param>
        /// <param name="previous">The previous position.</param>
        /// <returns>The current speed based on the time it took to move from a previous position.</returns>
        public static float Speed3(this Vector3 current, Vector3 previous) => current.Speed3(previous, Time.deltaTime);
        
        /// <summary>
        /// The current speed based on the time it took to move from a previous position.
        /// </summary>
        /// <param name="current">The current position.</param>
        /// <param name="previous">The previous position.</param>
        /// <param name="delta">The time since the last position.</param>
        /// <returns>The current speed based on the time it took to move from a previous position.</returns>
        public static float Speed3(this Vector3 current, [NotNull] Transform previous, float delta) => current.Speed3(previous.position, delta);
        
        /// <summary>
        /// The current speed based on the time it took to move from a previous position.
        /// </summary>
        /// <param name="current">The current position.</param>
        /// <param name="previous">The previous position.</param>
        /// <returns>The current speed based on the time it took to move from a previous position.</returns>
        public static float Speed3(this Vector3 current, [NotNull] Transform previous) => current.Speed3(previous, Time.deltaTime);
        
        /// <summary>
        /// The current speed based on the time it took to move from a previous position.
        /// </summary>
        /// <param name="current">The current position.</param>
        /// <param name="previous">The previous position.</param>
        /// <param name="delta">The time since the last position.</param>
        /// <returns>The current speed based on the time it took to move from a previous position.</returns>
        public static float Speed3(this Vector3 current, [NotNull] Component previous, float delta) => current.Speed3(previous.transform.position, delta);
        
        /// <summary>
        /// The current speed based on the time it took to move from a previous position.
        /// </summary>
        /// <param name="current">The current position.</param>
        /// <param name="previous">The previous position.</param>
        /// <returns>The current speed based on the time it took to move from a previous position.</returns>
        public static float Speed3(this Vector3 current, [NotNull] Component previous) => current.Speed3(previous, Time.deltaTime);
        
        /// <summary>
        /// The current speed based on the time it took to move from a previous position.
        /// </summary>
        /// <param name="current">The current position.</param>
        /// <param name="previous">The previous position.</param>
        /// <param name="delta">The time since the last position.</param>
        /// <returns>The current speed based on the time it took to move from a previous position.</returns>
        public static float Speed3(this Vector3 current, [NotNull] GameObject previous, float delta) => current.Speed3(previous.transform.position, delta);
        
        /// <summary>
        /// The current speed based on the time it took to move from a previous position.
        /// </summary>
        /// <param name="current">The current position.</param>
        /// <param name="previous">The previous position.</param>
        /// <returns>The current speed based on the time it took to move from a previous position.</returns>
        public static float Speed3(this Vector3 current, [NotNull] GameObject previous) => current.Speed3(previous, Time.deltaTime);
        
        /// <summary>
        /// The current speed based on the time it took to move from a previous position.
        /// </summary>
        /// <param name="current">The current position.</param>
        /// <param name="previous">The previous position.</param>
        /// <param name="delta">The time since the last position.</param>
        /// <returns>The current speed based on the time it took to move from a previous position.</returns>
        public static float Speed3([NotNull] this Transform current, Vector3 previous, float delta) => current.position.Speed3(previous, delta);
        
        /// <summary>
        /// The current speed based on the time it took to move from a previous position.
        /// </summary>
        /// <param name="current">The current position.</param>
        /// <param name="previous">The previous position.</param>
        /// <returns>The current speed based on the time it took to move from a previous position.</returns>
        public static float Speed3([NotNull] this Transform current, Vector3 previous) => current.Speed3(previous, Time.deltaTime);
        
        /// <summary>
        /// The current speed based on the time it took to move from a previous position.
        /// </summary>
        /// <param name="current">The current position.</param>
        /// <param name="previous">The previous position.</param>
        /// <param name="delta">The time since the last position.</param>
        /// <returns>The current speed based on the time it took to move from a previous position.</returns>
        public static float Speed3([NotNull] this Transform current, [NotNull] Transform previous, float delta) => current.position.Speed3(previous.position, delta);
        
        /// <summary>
        /// The current speed based on the time it took to move from a previous position.
        /// </summary>
        /// <param name="current">The current position.</param>
        /// <param name="previous">The previous position.</param>
        /// <returns>The current speed based on the time it took to move from a previous position.</returns>
        public static float Speed3([NotNull] this Transform current, [NotNull] Transform previous) => current.Speed3(previous, Time.deltaTime);
        
        /// <summary>
        /// The current speed based on the time it took to move from a previous position.
        /// </summary>
        /// <param name="current">The current position.</param>
        /// <param name="previous">The previous position.</param>
        /// <param name="delta">The time since the last position.</param>
        /// <returns>The current speed based on the time it took to move from a previous position.</returns>
        public static float Speed3([NotNull] this Transform current, [NotNull] Component previous, float delta) => current.position.Speed3(previous.transform.position, delta);
        
        /// <summary>
        /// The current speed based on the time it took to move from a previous position.
        /// </summary>
        /// <param name="current">The current position.</param>
        /// <param name="previous">The previous position.</param>
        /// <returns>The current speed based on the time it took to move from a previous position.</returns>
        public static float Speed3([NotNull] this Transform current, [NotNull] Component previous) => current.Speed3(previous, Time.deltaTime);
        
        /// <summary>
        /// The current speed based on the time it took to move from a previous position.
        /// </summary>
        /// <param name="current">The current position.</param>
        /// <param name="previous">The previous position.</param>
        /// <param name="delta">The time since the last position.</param>
        /// <returns>The current speed based on the time it took to move from a previous position.</returns>
        public static float Speed3([NotNull] this Transform current, [NotNull] GameObject previous, float delta) => current.position.Speed3(previous.transform.position, delta);
        
        /// <summary>
        /// The current speed based on the time it took to move from a previous position.
        /// </summary>
        /// <param name="current">The current position.</param>
        /// <param name="previous">The previous position.</param>
        /// <returns>The current speed based on the time it took to move from a previous position.</returns>
        public static float Speed3([NotNull] this Transform current, [NotNull] GameObject previous) => current.Speed3(previous, Time.deltaTime);
        
        /// <summary>
        /// The current speed based on the time it took to move from a previous position.
        /// </summary>
        /// <param name="current">The current position.</param>
        /// <param name="previous">The previous position.</param>
        /// <param name="delta">The time since the last position.</param>
        /// <returns>The current speed based on the time it took to move from a previous position.</returns>
        public static float Speed3([NotNull] this Component current, Vector3 previous, float delta) => current.transform.position.Speed3(previous, delta);
        
        /// <summary>
        /// The current speed based on the time it took to move from a previous position.
        /// </summary>
        /// <param name="current">The current position.</param>
        /// <param name="previous">The previous position.</param>
        /// <returns>The current speed based on the time it took to move from a previous position.</returns>
        public static float Speed3([NotNull] this Component current, Vector3 previous) => current.Speed3(previous, Time.deltaTime);
        
        /// <summary>
        /// The current speed based on the time it took to move from a previous position.
        /// </summary>
        /// <param name="current">The current position.</param>
        /// <param name="previous">The previous position.</param>
        /// <param name="delta">The time since the last position.</param>
        /// <returns>The current speed based on the time it took to move from a previous position.</returns>
        public static float Speed3([NotNull] this Component current, [NotNull] Transform previous, float delta) => current.transform.position.Speed3(previous.position, delta);
        
        /// <summary>
        /// The current speed based on the time it took to move from a previous position.
        /// </summary>
        /// <param name="current">The current position.</param>
        /// <param name="previous">The previous position.</param>
        /// <returns>The current speed based on the time it took to move from a previous position.</returns>
        public static float Speed3([NotNull] this Component current, [NotNull] Transform previous) => current.Speed3(previous, Time.deltaTime);
        
        /// <summary>
        /// The current speed based on the time it took to move from a previous position.
        /// </summary>
        /// <param name="current">The current position.</param>
        /// <param name="previous">The previous position.</param>
        /// <param name="delta">The time since the last position.</param>
        /// <returns>The current speed based on the time it took to move from a previous position.</returns>
        public static float Speed3([NotNull] this Component current, [NotNull] Component previous, float delta) => current.transform.position.Speed3(previous.transform.position, delta);
        
        /// <summary>
        /// The current speed based on the time it took to move from a previous position.
        /// </summary>
        /// <param name="current">The current position.</param>
        /// <param name="previous">The previous position.</param>
        /// <returns>The current speed based on the time it took to move from a previous position.</returns>
        public static float Speed3([NotNull] this Component current, [NotNull] Component previous) => current.Speed3(previous, Time.deltaTime);
        
        /// <summary>
        /// The current speed based on the time it took to move from a previous position.
        /// </summary>
        /// <param name="current">The current position.</param>
        /// <param name="previous">The previous position.</param>
        /// <param name="delta">The time since the last position.</param>
        /// <returns>The current speed based on the time it took to move from a previous position.</returns>
        public static float Speed3([NotNull] this Component current, [NotNull] GameObject previous, float delta) => current.transform.position.Speed3(previous.transform.position, delta);
        
        /// <summary>
        /// The current speed based on the time it took to move from a previous position.
        /// </summary>
        /// <param name="current">The current position.</param>
        /// <param name="previous">The previous position.</param>
        /// <returns>The current speed based on the time it took to move from a previous position.</returns>
        public static float Speed3([NotNull] this Component current, [NotNull] GameObject previous) => current.Speed3(previous, Time.deltaTime);
        
        /// <summary>
        /// The current speed based on the time it took to move from a previous position.
        /// </summary>
        /// <param name="current">The current position.</param>
        /// <param name="previous">The previous position.</param>
        /// <param name="delta">The time since the last position.</param>
        /// <returns>The current speed based on the time it took to move from a previous position.</returns>
        public static float Speed3([NotNull] this GameObject current, Vector3 previous, float delta) => current.transform.position.Speed3(previous, delta);
        
        /// <summary>
        /// The current speed based on the time it took to move from a previous position.
        /// </summary>
        /// <param name="current">The current position.</param>
        /// <param name="previous">The previous position.</param>
        /// <returns>The current speed based on the time it took to move from a previous position.</returns>
        public static float Speed3([NotNull] this GameObject current, Vector3 previous) => current.Speed3(previous, Time.deltaTime);
        
        /// <summary>
        /// The current speed based on the time it took to move from a previous position.
        /// </summary>
        /// <param name="current">The current position.</param>
        /// <param name="previous">The previous position.</param>
        /// <param name="delta">The time since the last position.</param>
        /// <returns>The current speed based on the time it took to move from a previous position.</returns>
        public static float Speed3([NotNull] this GameObject current, [NotNull] Transform previous, float delta) => current.transform.position.Speed3(previous.position, delta);
        
        /// <summary>
        /// The current speed based on the time it took to move from a previous position.
        /// </summary>
        /// <param name="current">The current position.</param>
        /// <param name="previous">The previous position.</param>
        /// <returns>The current speed based on the time it took to move from a previous position.</returns>
        public static float Speed3([NotNull] this GameObject current, [NotNull] Transform previous) => current.Speed3(previous, Time.deltaTime);
        
        /// <summary>
        /// The current speed based on the time it took to move from a previous position.
        /// </summary>
        /// <param name="current">The current position.</param>
        /// <param name="previous">The previous position.</param>
        /// <param name="delta">The time since the last position.</param>
        /// <returns>The current speed based on the time it took to move from a previous position.</returns>
        public static float Speed3([NotNull] this GameObject current, [NotNull] Component previous, float delta) => current.transform.position.Speed3(previous.transform.position, delta);
        
        /// <summary>
        /// The current speed based on the time it took to move from a previous position.
        /// </summary>
        /// <param name="current">The current position.</param>
        /// <param name="previous">The previous position.</param>
        /// <returns>The current speed based on the time it took to move from a previous position.</returns>
        public static float Speed3([NotNull] this GameObject current, [NotNull] Component previous) => current.Speed3(previous, Time.deltaTime);
        
        /// <summary>
        /// The current speed based on the time it took to move from a previous position.
        /// </summary>
        /// <param name="current">The current position.</param>
        /// <param name="previous">The previous position.</param>
        /// <param name="delta">The time since the last position.</param>
        /// <returns>The current speed based on the time it took to move from a previous position.</returns>
        public static float Speed3([NotNull] this GameObject current, [NotNull] GameObject previous, float delta) => current.transform.position.Speed3(previous.transform.position, delta);
        
        /// <summary>
        /// The current speed based on the time it took to move from a previous position.
        /// </summary>
        /// <param name="current">The current position.</param>
        /// <param name="previous">The previous position.</param>
        /// <returns>The current speed based on the time it took to move from a previous position.</returns>
        public static float Speed3([NotNull] this GameObject current, [NotNull] GameObject previous) => current.Speed3(previous, Time.deltaTime);
        
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
        public static Vector2 Velocity(this Vector3 current, Vector3 previous, float delta) => current.Flatten().Velocity(previous.Flatten(),delta);
        
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