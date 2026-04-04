using System.Diagnostics.CodeAnalysis;
using UnityEngine;

namespace KaijuSolutions.Agents.Extensions
{
    /// <summary>
    /// Extension methods to flatten objects down to their 2D representation as a <see href="https://docs.unity3d.com/ScriptReference/Vector2.html">Vector2</see> from the X and Z axes.
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
        /// Flatten a <see href="https://docs.unity3d.com/Manual/class-transform.html">transform</see> down to the X and Z axes positions.
        /// </summary>
        /// <param name="transform">The vector to flatten.</param>
        /// <returns>The <see href="https://docs.unity3d.com/Manual/class-transform.html">transform</see> flattened down to the X and Z axes positions.</returns>
        public static Vector2 Flatten([NotNull] this Transform transform) => transform.position.Flatten();
        
        /// <summary>
        /// Flatten a <see href="https://docs.unity3d.com/Manual/Components.html">component</see> down to the X and Z axes positions.
        /// </summary>
        /// <param name="component">The vector to flatten.</param>
        /// <returns>The <see href="https://docs.unity3d.com/Manual/Components.html">component</see> flattened down to the X and Z axes positions.</returns>
        public static Vector2 Flatten([NotNull] this Component component) => component.transform.position.Flatten();
        
        /// <summary>
        /// Flatten a <see href="https://docs.unity3d.com/Manual/class-GameObject.html">GameObject</see> down to the X and Z axes positions.
        /// </summary>
        /// <param name="gameObject">The vector to flatten.</param>
        /// <returns>The <see href="https://docs.unity3d.com/Manual/class-GameObject.html">GameObject</see> flattened down to the X and Z axes positions.</returns>
        public static Vector2 Flatten([NotNull] this GameObject gameObject) => gameObject.transform.position.Flatten();
    }
}