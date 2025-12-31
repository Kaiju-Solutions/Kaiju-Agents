using System.Diagnostics.CodeAnalysis;
using UnityEngine;

namespace KaijuSolutions.Agents
{
    /// <summary>
    /// Extension methods to flatten objects down to their 2D representation as a Vector2 from the X and Z axes.
    /// </summary>
    public static class KaijuAgentsFlatten
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
    }
}