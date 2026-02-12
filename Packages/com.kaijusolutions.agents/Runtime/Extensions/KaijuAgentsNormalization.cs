using System.Diagnostics.CodeAnalysis;
using UnityEngine;

namespace KaijuSolutions.Agents.Extensions
{
    /// <summary>
    /// Methods to perform normalization.
    /// </summary>
    public static class KaijuAgentsNormalization
    {
        /// <summary>
        /// Perform normalization.
        /// </summary>
        /// <param name="position">The position to normalize from.</param>
        /// <param name="distance">The normalization distance.</param>
        /// <param name="positions">The positions to normalize.</param>
        /// <param name="normalization">How to normalize the positions.</param>
        public static void Normalize(this Vector2 position, float distance, [NotNull] Vector2[] positions, KaijuPositionNormalization normalization = KaijuPositionNormalization.Local)
        {
            switch (normalization)
            {
                case KaijuPositionNormalization.Normalized:
                    for (int i = 0; i < positions.Length; i++)
                    {
                        positions[i] = new(Mathf.Clamp((positions[i].x - position.x) / distance, -1f, 1f), Mathf.Clamp((positions[i].y - position.y) / distance, -1f, 1f));
                    }
                    break;
                case KaijuPositionNormalization.Local:
                    for (int i = 0; i < positions.Length; i++)
                    {
                        positions[i] -= position;
                    }
                    break;
                case KaijuPositionNormalization.None:
                default:
                    break;
            }
        }
        
        /// <summary>
        /// Perform normalization.
        /// </summary>
        /// <param name="position">The position to normalize from.</param>
        /// <param name="distance">The normalization distance.</param>
        /// <param name="positions">The positions to normalize.</param>
        /// <param name="normalization">How to normalize the positions.</param>
        public static void Normalize(this Vector2 position, float distance, [NotNull] Vector3[] positions, KaijuPositionNormalization normalization = KaijuPositionNormalization.Local)
        {
            switch (normalization)
            {
                case KaijuPositionNormalization.Normalized:
                    for (int i = 0; i < positions.Length; i++)
                    {
                        positions[i] = new(Mathf.Clamp((positions[i].x - position.x) / distance, -1f, 1f), Mathf.Clamp(positions[i].y / distance, -1f, 1f), Mathf.Clamp((positions[i].z - position.y) / distance, -1f, 1f));
                    }
                    break;
                case KaijuPositionNormalization.Local:
                    for (int i = 0; i < positions.Length; i++)
                    {
                        positions[i] = new(positions[i].x - position.x, positions[i].y, positions[i].z - position.y);
                    }
                    break;
                case KaijuPositionNormalization.None:
                default:
                    break;
            }
        }
        
        /// <summary>
        /// Perform normalization.
        /// </summary>
        /// <param name="position">The position to normalize from.</param>
        /// <param name="distance">The normalization distance.</param>
        /// <param name="positions">The positions to normalize.</param>
        /// <param name="normalization">How to normalize the positions.</param>
        public static void Normalize(this Vector3 position, float distance, [NotNull] Vector2[] positions, KaijuPositionNormalization normalization = KaijuPositionNormalization.Local)
        {
            switch (normalization)
            {
                case KaijuPositionNormalization.Normalized:
                    for (int i = 0; i < positions.Length; i++)
                    {
                        positions[i] = new(Mathf.Clamp((positions[i].x - position.x) / distance, -1f, 1f), Mathf.Clamp((positions[i].y - position.z) / distance, -1f, 1f));
                    }
                    break;
                case KaijuPositionNormalization.Local:
                    for (int i = 0; i < positions.Length; i++)
                    {
                        positions[i] = new(positions[i].x - position.x, positions[i].y - position.z);
                    }
                    break;
                case KaijuPositionNormalization.None:
                default:
                    break;
            }
        }
        
        /// <summary>
        /// Perform normalization.
        /// </summary>
        /// <param name="position">The position to normalize from.</param>
        /// <param name="distance">The normalization distance.</param>
        /// <param name="positions">The positions to normalize.</param>
        /// <param name="normalization">How to normalize the positions.</param>
        public static void Normalize(this Vector3 position, float distance, [NotNull] Vector3[] positions, KaijuPositionNormalization normalization = KaijuPositionNormalization.Local)
        {
            switch (normalization)
            {
                case KaijuPositionNormalization.Normalized:
                    for (int i = 0; i < positions.Length; i++)
                    {
                        positions[i] = new(Mathf.Clamp((positions[i].x - position.x) / distance, -1f, 1f), Mathf.Clamp((positions[i].y - position.y) / distance, -1f, 1f), Mathf.Clamp((positions[i].z - position.z) / distance, -1f, 1f));
                    }
                    break;
                case KaijuPositionNormalization.Local:
                    for (int i = 0; i < positions.Length; i++)
                    {
                        positions[i] -= position;
                    }
                    break;
                case KaijuPositionNormalization.None:
                default:
                    break;
            }
        }
    }
}