using UnityEngine;

namespace KaijuSolutions.Agents
{
    /// <summary>
    /// Extension method to expand a 2D vector across the X and Z axes to all three axes, setting the Y axis to zero.
    /// </summary>
    public static class KaijuAgentsExpand
    {
        /// <summary>
        /// Expand an XZ vector to all three axes.
        /// </summary>
        /// <param name="vector">The vector to expand.</param>
        /// <returns>The XZ vector expanded to all three axes.</returns>
        public static Vector3 Expand(this Vector2 vector) => new(vector.x, 0, vector.y);
    }
}