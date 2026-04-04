using System.Diagnostics.CodeAnalysis;
using UnityEngine;

namespace KaijuSolutions.Agents.Extensions
{
    /// <summary>
    /// Standalone evade steering extension methods.
    /// </summary>
    public static class KaijuAgentsEvade
    {
        /// <summary>
        /// Calculate a evade behaviour.
        /// </summary>
        /// <param name="position">The current position of the instance to calculate the movement for.</param>
        /// <param name="target">The target to move in relation to.</param>
        /// <param name="previous">The previous position of the target.</param>
        /// <param name="speed">The maximum speed that the position can update at.</param>
        /// <param name="delta">The time since the last recorded position.</param>
        /// <param name="future">The predicted future position.</param>
        /// <returns>The calculated movement.</returns>
        public static Vector2 Evade(this Vector2 position, Vector2 target, Vector2 previous, float speed, float delta, out Vector2 future)
        {
            // Predict where the target will be.
            future = target + target.Velocity(previous, delta) * (target.Direction(position).magnitude / (speed + target.Speed(previous, delta)));
            
            // Flee away from the predicted position.
            return position.Flee(future, speed);
        }
        
        /// <summary>
        /// Calculate a evade behaviour.
        /// </summary>
        /// <param name="position">The current position of the instance to calculate the movement for.</param>
        /// <param name="target">The target to move in relation to.</param>
        /// <param name="previous">The previous position of the target.</param>
        /// <param name="speed">The maximum speed that the position can update at.</param>
        /// <param name="future">The predicted future position.</param>
        /// <returns>The calculated movement.</returns>
        public static Vector2 Evade(this Vector2 position, Vector2 target, Vector2 previous, float speed, out Vector2 future) => position.Evade(target, previous, speed, Time.deltaTime, out future);

        /// <summary>
        /// Calculate a evade behaviour.
        /// </summary>
        /// <param name="position">The current position of the instance to calculate the movement for.</param>
        /// <param name="target">The target to move in relation to.</param>
        /// <param name="previous">The previous position of the target.</param>
        /// <param name="speed">The maximum speed that the position can update at.</param>
        /// <param name="delta">The time since the last recorded position.</param>
        /// <param name="future">The predicted future position.</param>
        /// <returns>The calculated movement.</returns>
        public static Vector2 Evade(this Vector2 position, Vector2 target, Vector3 previous, float speed, float delta, out Vector2 future) => position.Evade(target, previous.Flatten(), speed, delta, out future);
        
        /// <summary>
        /// Calculate a evade behaviour.
        /// </summary>
        /// <param name="position">The current position of the instance to calculate the movement for.</param>
        /// <param name="target">The target to move in relation to.</param>
        /// <param name="previous">The previous position of the target.</param>
        /// <param name="speed">The maximum speed that the position can update at.</param>
        /// <param name="future">The predicted future position.</param>
        /// <returns>The calculated movement.</returns>
        public static Vector2 Evade(this Vector2 position, Vector2 target, Vector3 previous, float speed, out Vector2 future) => position.Evade(target, previous, speed, Time.deltaTime, out future);

        /// <summary>
        /// Calculate a evade behaviour.
        /// </summary>
        /// <param name="position">The current position of the instance to calculate the movement for.</param>
        /// <param name="target">The target to move in relation to.</param>
        /// <param name="previous">The previous position of the target.</param>
        /// <param name="speed">The maximum speed that the position can update at.</param>
        /// <param name="delta">The time since the last recorded position.</param>
        /// <param name="future">The predicted future position.</param>
        /// <returns>The calculated movement.</returns>
        public static Vector2 Evade(this Vector2 position, Vector2 target, [NotNull] Transform previous, float speed, float delta, out Vector2 future) => position.Evade(target, previous.Flatten(), speed, delta, out future);
        
        /// <summary>
        /// Calculate a evade behaviour.
        /// </summary>
        /// <param name="position">The current position of the instance to calculate the movement for.</param>
        /// <param name="target">The target to move in relation to.</param>
        /// <param name="previous">The previous position of the target.</param>
        /// <param name="speed">The maximum speed that the position can update at.</param>
        /// <param name="future">The predicted future position.</param>
        /// <returns>The calculated movement.</returns>
        public static Vector2 Evade(this Vector2 position, Vector2 target, [NotNull] Transform previous, float speed, out Vector2 future) => position.Evade(target, previous, speed, Time.deltaTime, out future);

        /// <summary>
        /// Calculate a evade behaviour.
        /// </summary>
        /// <param name="position">The current position of the instance to calculate the movement for.</param>
        /// <param name="target">The target to move in relation to.</param>
        /// <param name="previous">The previous position of the target.</param>
        /// <param name="speed">The maximum speed that the position can update at.</param>
        /// <param name="delta">The time since the last recorded position.</param>
        /// <param name="future">The predicted future position.</param>
        /// <returns>The calculated movement.</returns>
        public static Vector2 Evade(this Vector2 position, Vector2 target, [NotNull] Component previous, float speed, float delta, out Vector2 future) => position.Evade(target, previous.Flatten(), speed, delta, out future);
        
        /// <summary>
        /// Calculate a evade behaviour.
        /// </summary>
        /// <param name="position">The current position of the instance to calculate the movement for.</param>
        /// <param name="target">The target to move in relation to.</param>
        /// <param name="previous">The previous position of the target.</param>
        /// <param name="speed">The maximum speed that the position can update at.</param>
        /// <param name="future">The predicted future position.</param>
        /// <returns>The calculated movement.</returns>
        public static Vector2 Evade(this Vector2 position, Vector2 target, [NotNull] Component previous, float speed, out Vector2 future) => position.Evade(target, previous, speed, Time.deltaTime, out future);

        /// <summary>
        /// Calculate a evade behaviour.
        /// </summary>
        /// <param name="position">The current position of the instance to calculate the movement for.</param>
        /// <param name="target">The target to move in relation to.</param>
        /// <param name="previous">The previous position of the target.</param>
        /// <param name="speed">The maximum speed that the position can update at.</param>
        /// <param name="delta">The time since the last recorded position.</param>
        /// <param name="future">The predicted future position.</param>
        /// <returns>The calculated movement.</returns>
        public static Vector2 Evade(this Vector2 position, Vector2 target, [NotNull] GameObject previous, float speed, float delta, out Vector2 future) => position.Evade(target, previous.Flatten(), speed, delta, out future);
        
        /// <summary>
        /// Calculate a evade behaviour.
        /// </summary>
        /// <param name="position">The current position of the instance to calculate the movement for.</param>
        /// <param name="target">The target to move in relation to.</param>
        /// <param name="previous">The previous position of the target.</param>
        /// <param name="speed">The maximum speed that the position can update at.</param>
        /// <param name="future">The predicted future position.</param>
        /// <returns>The calculated movement.</returns>
        public static Vector2 Evade(this Vector2 position, Vector2 target, [NotNull] GameObject previous, float speed, out Vector2 future) => position.Evade(target, previous, speed, Time.deltaTime, out future);

        /// <summary>
        /// Calculate a evade behaviour.
        /// </summary>
        /// <param name="position">The current position of the instance to calculate the movement for.</param>
        /// <param name="target">The target to move in relation to.</param>
        /// <param name="previous">The previous position of the target.</param>
        /// <param name="speed">The maximum speed that the position can update at.</param>
        /// <param name="delta">The time since the last recorded position.</param>
        /// <param name="future">The predicted future position.</param>
        /// <returns>The calculated movement.</returns>
        public static Vector2 Evade(this Vector2 position, Vector3 target, Vector2 previous, float speed, float delta, out Vector2 future) => position.Evade(target.Flatten(), previous, speed, delta, out future);
        
        /// <summary>
        /// Calculate a evade behaviour.
        /// </summary>
        /// <param name="position">The current position of the instance to calculate the movement for.</param>
        /// <param name="target">The target to move in relation to.</param>
        /// <param name="previous">The previous position of the target.</param>
        /// <param name="speed">The maximum speed that the position can update at.</param>
        /// <param name="future">The predicted future position.</param>
        /// <returns>The calculated movement.</returns>
        public static Vector2 Evade(this Vector2 position, Vector3 target, Vector2 previous, float speed, out Vector2 future) => position.Evade(target.Flatten(), previous, speed, Time.deltaTime, out future);

        /// <summary>
        /// Calculate a evade behaviour.
        /// </summary>
        /// <param name="position">The current position of the instance to calculate the movement for.</param>
        /// <param name="target">The target to move in relation to.</param>
        /// <param name="previous">The previous position of the target.</param>
        /// <param name="speed">The maximum speed that the position can update at.</param>
        /// <param name="delta">The time since the last recorded position.</param>
        /// <param name="future">The predicted future position.</param>
        /// <returns>The calculated movement.</returns>
        public static Vector2 Evade(this Vector2 position, Vector3 target, Vector3 previous, float speed, float delta, out Vector2 future) => position.Evade(target.Flatten(), previous.Flatten(), speed, delta, out future);
        
        /// <summary>
        /// Calculate a evade behaviour.
        /// </summary>
        /// <param name="position">The current position of the instance to calculate the movement for.</param>
        /// <param name="target">The target to move in relation to.</param>
        /// <param name="previous">The previous position of the target.</param>
        /// <param name="speed">The maximum speed that the position can update at.</param>
        /// <param name="future">The predicted future position.</param>
        /// <returns>The calculated movement.</returns>
        public static Vector2 Evade(this Vector2 position, Vector3 target, Vector3 previous, float speed, out Vector2 future) => position.Evade(target.Flatten(), previous.Flatten(), speed, Time.deltaTime, out future);

        /// <summary>
        /// Calculate a evade behaviour.
        /// </summary>
        /// <param name="position">The current position of the instance to calculate the movement for.</param>
        /// <param name="target">The target to move in relation to.</param>
        /// <param name="previous">The previous position of the target.</param>
        /// <param name="speed">The maximum speed that the position can update at.</param>
        /// <param name="delta">The time since the last recorded position.</param>
        /// <param name="future">The predicted future position.</param>
        /// <returns>The calculated movement.</returns>
        public static Vector2 Evade(this Vector2 position, Vector3 target, [NotNull] Transform previous, float speed, float delta, out Vector2 future) => position.Evade(target.Flatten(), previous.Flatten(), speed, delta, out future);
        
        /// <summary>
        /// Calculate a evade behaviour.
        /// </summary>
        /// <param name="position">The current position of the instance to calculate the movement for.</param>
        /// <param name="target">The target to move in relation to.</param>
        /// <param name="previous">The previous position of the target.</param>
        /// <param name="speed">The maximum speed that the position can update at.</param>
        /// <param name="future">The predicted future position.</param>
        /// <returns>The calculated movement.</returns>
        public static Vector2 Evade(this Vector2 position, Vector3 target, [NotNull] Transform previous, float speed, out Vector2 future) => position.Evade(target.Flatten(), previous.Flatten(), speed, Time.deltaTime, out future);

        /// <summary>
        /// Calculate a evade behaviour.
        /// </summary>
        /// <param name="position">The current position of the instance to calculate the movement for.</param>
        /// <param name="target">The target to move in relation to.</param>
        /// <param name="previous">The previous position of the target.</param>
        /// <param name="speed">The maximum speed that the position can update at.</param>
        /// <param name="delta">The time since the last recorded position.</param>
        /// <param name="future">The predicted future position.</param>
        /// <returns>The calculated movement.</returns>
        public static Vector2 Evade(this Vector2 position, Vector3 target, [NotNull] Component previous, float speed, float delta, out Vector2 future) => position.Evade(target.Flatten(), previous.Flatten(), speed, delta, out future);
        
        /// <summary>
        /// Calculate a evade behaviour.
        /// </summary>
        /// <param name="position">The current position of the instance to calculate the movement for.</param>
        /// <param name="target">The target to move in relation to.</param>
        /// <param name="previous">The previous position of the target.</param>
        /// <param name="speed">The maximum speed that the position can update at.</param>
        /// <param name="future">The predicted future position.</param>
        /// <returns>The calculated movement.</returns>
        public static Vector2 Evade(this Vector2 position, Vector3 target, [NotNull] Component previous, float speed, out Vector2 future) => position.Evade(target.Flatten(), previous.Flatten(), speed, Time.deltaTime, out future);

        /// <summary>
        /// Calculate a evade behaviour.
        /// </summary>
        /// <param name="position">The current position of the instance to calculate the movement for.</param>
        /// <param name="target">The target to move in relation to.</param>
        /// <param name="previous">The previous position of the target.</param>
        /// <param name="speed">The maximum speed that the position can update at.</param>
        /// <param name="delta">The time since the last recorded position.</param>
        /// <param name="future">The predicted future position.</param>
        /// <returns>The calculated movement.</returns>
        public static Vector2 Evade(this Vector2 position, Vector3 target, [NotNull] GameObject previous, float speed, float delta, out Vector2 future) => position.Evade(target.Flatten(), previous.Flatten(), speed, delta, out future);
        
        /// <summary>
        /// Calculate a evade behaviour.
        /// </summary>
        /// <param name="position">The current position of the instance to calculate the movement for.</param>
        /// <param name="target">The target to move in relation to.</param>
        /// <param name="previous">The previous position of the target.</param>
        /// <param name="speed">The maximum speed that the position can update at.</param>
        /// <param name="future">The predicted future position.</param>
        /// <returns>The calculated movement.</returns>
        public static Vector2 Evade(this Vector2 position, Vector3 target, [NotNull] GameObject previous, float speed, out Vector2 future) => position.Evade(target.Flatten(), previous.Flatten(), speed, Time.deltaTime, out future);

        /// <summary>
        /// Calculate a evade behaviour.
        /// </summary>
        /// <param name="position">The current position of the instance to calculate the movement for.</param>
        /// <param name="target">The target to move in relation to.</param>
        /// <param name="previous">The previous position of the target.</param>
        /// <param name="speed">The maximum speed that the position can update at.</param>
        /// <param name="delta">The time since the last recorded position.</param>
        /// <param name="future">The predicted future position.</param>
        /// <returns>The calculated movement.</returns>
        public static Vector2 Evade(this Vector2 position, [NotNull] Transform target, Vector2 previous, float speed, float delta, out Vector2 future) => position.Evade(target.Flatten(), previous, speed, delta, out future);
        
        /// <summary>
        /// Calculate a evade behaviour.
        /// </summary>
        /// <param name="position">The current position of the instance to calculate the movement for.</param>
        /// <param name="target">The target to move in relation to.</param>
        /// <param name="previous">The previous position of the target.</param>
        /// <param name="speed">The maximum speed that the position can update at.</param>
        /// <param name="future">The predicted future position.</param>
        /// <returns>The calculated movement.</returns>
        public static Vector2 Evade(this Vector2 position, [NotNull] Transform target, Vector2 previous, float speed, out Vector2 future) => position.Evade(target.Flatten(), previous, speed, Time.deltaTime, out future);

        /// <summary>
        /// Calculate a evade behaviour.
        /// </summary>
        /// <param name="position">The current position of the instance to calculate the movement for.</param>
        /// <param name="target">The target to move in relation to.</param>
        /// <param name="previous">The previous position of the target.</param>
        /// <param name="speed">The maximum speed that the position can update at.</param>
        /// <param name="delta">The time since the last recorded position.</param>
        /// <param name="future">The predicted future position.</param>
        /// <returns>The calculated movement.</returns>
        public static Vector2 Evade(this Vector2 position, [NotNull] Transform target, Vector3 previous, float speed, float delta, out Vector2 future) => position.Evade(target.Flatten(), previous.Flatten(), speed, delta, out future);
        
        /// <summary>
        /// Calculate a evade behaviour.
        /// </summary>
        /// <param name="position">The current position of the instance to calculate the movement for.</param>
        /// <param name="target">The target to move in relation to.</param>
        /// <param name="previous">The previous position of the target.</param>
        /// <param name="speed">The maximum speed that the position can update at.</param>
        /// <param name="future">The predicted future position.</param>
        /// <returns>The calculated movement.</returns>
        public static Vector2 Evade(this Vector2 position, [NotNull] Transform target, Vector3 previous, float speed, out Vector2 future) => position.Evade(target.Flatten(), previous.Flatten(), speed, Time.deltaTime, out future);

        /// <summary>
        /// Calculate a evade behaviour.
        /// </summary>
        /// <param name="position">The current position of the instance to calculate the movement for.</param>
        /// <param name="target">The target to move in relation to.</param>
        /// <param name="previous">The previous position of the target.</param>
        /// <param name="speed">The maximum speed that the position can update at.</param>
        /// <param name="delta">The time since the last recorded position.</param>
        /// <param name="future">The predicted future position.</param>
        /// <returns>The calculated movement.</returns>
        public static Vector2 Evade(this Vector2 position, [NotNull] Transform target, [NotNull] Transform previous, float speed, float delta, out Vector2 future) => position.Evade(target.Flatten(), previous.Flatten(), speed, delta, out future);
        
        /// <summary>
        /// Calculate a evade behaviour.
        /// </summary>
        /// <param name="position">The current position of the instance to calculate the movement for.</param>
        /// <param name="target">The target to move in relation to.</param>
        /// <param name="previous">The previous position of the target.</param>
        /// <param name="speed">The maximum speed that the position can update at.</param>
        /// <param name="future">The predicted future position.</param>
        /// <returns>The calculated movement.</returns>
        public static Vector2 Evade(this Vector2 position, [NotNull] Transform target, [NotNull] Transform previous, float speed, out Vector2 future) => position.Evade(target.Flatten(), previous.Flatten(), speed, Time.deltaTime, out future);

        /// <summary>
        /// Calculate a evade behaviour.
        /// </summary>
        /// <param name="position">The current position of the instance to calculate the movement for.</param>
        /// <param name="target">The target to move in relation to.</param>
        /// <param name="previous">The previous position of the target.</param>
        /// <param name="speed">The maximum speed that the position can update at.</param>
        /// <param name="delta">The time since the last recorded position.</param>
        /// <param name="future">The predicted future position.</param>
        /// <returns>The calculated movement.</returns>
        public static Vector2 Evade(this Vector2 position, [NotNull] Transform target, [NotNull] Component previous, float speed, float delta, out Vector2 future) => position.Evade(target.Flatten(), previous.Flatten(), speed, delta, out future);
        
        /// <summary>
        /// Calculate a evade behaviour.
        /// </summary>
        /// <param name="position">The current position of the instance to calculate the movement for.</param>
        /// <param name="target">The target to move in relation to.</param>
        /// <param name="previous">The previous position of the target.</param>
        /// <param name="speed">The maximum speed that the position can update at.</param>
        /// <param name="future">The predicted future position.</param>
        /// <returns>The calculated movement.</returns>
        public static Vector2 Evade(this Vector2 position, [NotNull] Transform target, [NotNull] Component previous, float speed, out Vector2 future) => position.Evade(target.Flatten(), previous.Flatten(), speed, Time.deltaTime, out future);

        /// <summary>
        /// Calculate a evade behaviour.
        /// </summary>
        /// <param name="position">The current position of the instance to calculate the movement for.</param>
        /// <param name="target">The target to move in relation to.</param>
        /// <param name="previous">The previous position of the target.</param>
        /// <param name="speed">The maximum speed that the position can update at.</param>
        /// <param name="delta">The time since the last recorded position.</param>
        /// <param name="future">The predicted future position.</param>
        /// <returns>The calculated movement.</returns>
        public static Vector2 Evade(this Vector2 position, [NotNull] Transform target, [NotNull] GameObject previous, float speed, float delta, out Vector2 future) => position.Evade(target.Flatten(), previous.Flatten(), speed, delta, out future);
        
        /// <summary>
        /// Calculate a evade behaviour.
        /// </summary>
        /// <param name="position">The current position of the instance to calculate the movement for.</param>
        /// <param name="target">The target to move in relation to.</param>
        /// <param name="previous">The previous position of the target.</param>
        /// <param name="speed">The maximum speed that the position can update at.</param>
        /// <param name="future">The predicted future position.</param>
        /// <returns>The calculated movement.</returns>
        public static Vector2 Evade(this Vector2 position, [NotNull] Transform target, [NotNull] GameObject previous, float speed, out Vector2 future) => position.Evade(target.Flatten(), previous.Flatten(), speed, Time.deltaTime, out future);

        /// <summary>
        /// Calculate a evade behaviour.
        /// </summary>
        /// <param name="position">The current position of the instance to calculate the movement for.</param>
        /// <param name="target">The target to move in relation to.</param>
        /// <param name="previous">The previous position of the target.</param>
        /// <param name="speed">The maximum speed that the position can update at.</param>
        /// <param name="delta">The time since the last recorded position.</param>
        /// <param name="future">The predicted future position.</param>
        /// <returns>The calculated movement.</returns>
        public static Vector2 Evade(this Vector2 position, [NotNull] Component target, Vector2 previous, float speed, float delta, out Vector2 future) => position.Evade(target.Flatten(), previous, speed, delta, out future);
        
        /// <summary>
        /// Calculate a evade behaviour.
        /// </summary>
        /// <param name="position">The current position of the instance to calculate the movement for.</param>
        /// <param name="target">The target to move in relation to.</param>
        /// <param name="previous">The previous position of the target.</param>
        /// <param name="speed">The maximum speed that the position can update at.</param>
        /// <param name="future">The predicted future position.</param>
        /// <returns>The calculated movement.</returns>
        public static Vector2 Evade(this Vector2 position, [NotNull] Component target, Vector2 previous, float speed, out Vector2 future) => position.Evade(target.Flatten(), previous, speed, Time.deltaTime, out future);

        /// <summary>
        /// Calculate a evade behaviour.
        /// </summary>
        /// <param name="position">The current position of the instance to calculate the movement for.</param>
        /// <param name="target">The target to move in relation to.</param>
        /// <param name="previous">The previous position of the target.</param>
        /// <param name="speed">The maximum speed that the position can update at.</param>
        /// <param name="delta">The time since the last recorded position.</param>
        /// <param name="future">The predicted future position.</param>
        /// <returns>The calculated movement.</returns>
        public static Vector2 Evade(this Vector2 position, [NotNull] Component target, Vector3 previous, float speed, float delta, out Vector2 future) => position.Evade(target.Flatten(), previous.Flatten(), speed, delta, out future);
        
        /// <summary>
        /// Calculate a evade behaviour.
        /// </summary>
        /// <param name="position">The current position of the instance to calculate the movement for.</param>
        /// <param name="target">The target to move in relation to.</param>
        /// <param name="previous">The previous position of the target.</param>
        /// <param name="speed">The maximum speed that the position can update at.</param>
        /// <param name="future">The predicted future position.</param>
        /// <returns>The calculated movement.</returns>
        public static Vector2 Evade(this Vector2 position, [NotNull] Component target, Vector3 previous, float speed, out Vector2 future) => position.Evade(target.Flatten(), previous.Flatten(), speed, Time.deltaTime, out future);

        /// <summary>
        /// Calculate a evade behaviour.
        /// </summary>
        /// <param name="position">The current position of the instance to calculate the movement for.</param>
        /// <param name="target">The target to move in relation to.</param>
        /// <param name="previous">The previous position of the target.</param>
        /// <param name="speed">The maximum speed that the position can update at.</param>
        /// <param name="delta">The time since the last recorded position.</param>
        /// <param name="future">The predicted future position.</param>
        /// <returns>The calculated movement.</returns>
        public static Vector2 Evade(this Vector2 position, [NotNull] Component target, [NotNull] Transform previous, float speed, float delta, out Vector2 future) => position.Evade(target.Flatten(), previous.Flatten(), speed, delta, out future);
        
        /// <summary>
        /// Calculate a evade behaviour.
        /// </summary>
        /// <param name="position">The current position of the instance to calculate the movement for.</param>
        /// <param name="target">The target to move in relation to.</param>
        /// <param name="previous">The previous position of the target.</param>
        /// <param name="speed">The maximum speed that the position can update at.</param>
        /// <param name="future">The predicted future position.</param>
        /// <returns>The calculated movement.</returns>
        public static Vector2 Evade(this Vector2 position, [NotNull] Component target, [NotNull] Transform previous, float speed, out Vector2 future) => position.Evade(target.Flatten(), previous.Flatten(), speed, Time.deltaTime, out future);

        /// <summary>
        /// Calculate a evade behaviour.
        /// </summary>
        /// <param name="position">The current position of the instance to calculate the movement for.</param>
        /// <param name="target">The target to move in relation to.</param>
        /// <param name="previous">The previous position of the target.</param>
        /// <param name="speed">The maximum speed that the position can update at.</param>
        /// <param name="delta">The time since the last recorded position.</param>
        /// <param name="future">The predicted future position.</param>
        /// <returns>The calculated movement.</returns>
        public static Vector2 Evade(this Vector2 position, [NotNull] Component target, [NotNull] Component previous, float speed, float delta, out Vector2 future) => position.Evade(target.Flatten(), previous.Flatten(), speed, delta, out future);
        
        /// <summary>
        /// Calculate a evade behaviour.
        /// </summary>
        /// <param name="position">The current position of the instance to calculate the movement for.</param>
        /// <param name="target">The target to move in relation to.</param>
        /// <param name="previous">The previous position of the target.</param>
        /// <param name="speed">The maximum speed that the position can update at.</param>
        /// <param name="future">The predicted future position.</param>
        /// <returns>The calculated movement.</returns>
        public static Vector2 Evade(this Vector2 position, [NotNull] Component target, [NotNull] Component previous, float speed, out Vector2 future) => position.Evade(target.Flatten(), previous.Flatten(), speed, Time.deltaTime, out future);

        /// <summary>
        /// Calculate a evade behaviour.
        /// </summary>
        /// <param name="position">The current position of the instance to calculate the movement for.</param>
        /// <param name="target">The target to move in relation to.</param>
        /// <param name="previous">The previous position of the target.</param>
        /// <param name="speed">The maximum speed that the position can update at.</param>
        /// <param name="delta">The time since the last recorded position.</param>
        /// <param name="future">The predicted future position.</param>
        /// <returns>The calculated movement.</returns>
        public static Vector2 Evade(this Vector2 position, [NotNull] Component target, [NotNull] GameObject previous, float speed, float delta, out Vector2 future) => position.Evade(target.Flatten(), previous.Flatten(), speed, delta, out future);
        
        /// <summary>
        /// Calculate a evade behaviour.
        /// </summary>
        /// <param name="position">The current position of the instance to calculate the movement for.</param>
        /// <param name="target">The target to move in relation to.</param>
        /// <param name="previous">The previous position of the target.</param>
        /// <param name="speed">The maximum speed that the position can update at.</param>
        /// <param name="future">The predicted future position.</param>
        /// <returns>The calculated movement.</returns>
        public static Vector2 Evade(this Vector2 position, [NotNull] Component target, [NotNull] GameObject previous, float speed, out Vector2 future) => position.Evade(target.Flatten(), previous.Flatten(), speed, Time.deltaTime, out future);

        /// <summary>
        /// Calculate a evade behaviour.
        /// </summary>
        /// <param name="position">The current position of the instance to calculate the movement for.</param>
        /// <param name="target">The target to move in relation to.</param>
        /// <param name="previous">The previous position of the target.</param>
        /// <param name="speed">The maximum speed that the position can update at.</param>
        /// <param name="delta">The time since the last recorded position.</param>
        /// <param name="future">The predicted future position.</param>
        /// <returns>The calculated movement.</returns>
        public static Vector2 Evade(this Vector2 position, [NotNull] GameObject target, Vector2 previous, float speed, float delta, out Vector2 future) => position.Evade(target.Flatten(), previous, speed, delta, out future);
        
        /// <summary>
        /// Calculate a evade behaviour.
        /// </summary>
        /// <param name="position">The current position of the instance to calculate the movement for.</param>
        /// <param name="target">The target to move in relation to.</param>
        /// <param name="previous">The previous position of the target.</param>
        /// <param name="speed">The maximum speed that the position can update at.</param>
        /// <param name="future">The predicted future position.</param>
        /// <returns>The calculated movement.</returns>
        public static Vector2 Evade(this Vector2 position, [NotNull] GameObject target, Vector2 previous, float speed, out Vector2 future) => position.Evade(target.Flatten(), previous, speed, Time.deltaTime, out future);

        /// <summary>
        /// Calculate a evade behaviour.
        /// </summary>
        /// <param name="position">The current position of the instance to calculate the movement for.</param>
        /// <param name="target">The target to move in relation to.</param>
        /// <param name="previous">The previous position of the target.</param>
        /// <param name="speed">The maximum speed that the position can update at.</param>
        /// <param name="delta">The time since the last recorded position.</param>
        /// <param name="future">The predicted future position.</param>
        /// <returns>The calculated movement.</returns>
        public static Vector2 Evade(this Vector2 position, [NotNull] GameObject target, Vector3 previous, float speed, float delta, out Vector2 future) => position.Evade(target.Flatten(), previous.Flatten(), speed, delta, out future);
        
        /// <summary>
        /// Calculate a evade behaviour.
        /// </summary>
        /// <param name="position">The current position of the instance to calculate the movement for.</param>
        /// <param name="target">The target to move in relation to.</param>
        /// <param name="previous">The previous position of the target.</param>
        /// <param name="speed">The maximum speed that the position can update at.</param>
        /// <param name="future">The predicted future position.</param>
        /// <returns>The calculated movement.</returns>
        public static Vector2 Evade(this Vector2 position, [NotNull] GameObject target, Vector3 previous, float speed, out Vector2 future) => position.Evade(target.Flatten(), previous.Flatten(), speed, Time.deltaTime, out future);

        /// <summary>
        /// Calculate a evade behaviour.
        /// </summary>
        /// <param name="position">The current position of the instance to calculate the movement for.</param>
        /// <param name="target">The target to move in relation to.</param>
        /// <param name="previous">The previous position of the target.</param>
        /// <param name="speed">The maximum speed that the position can update at.</param>
        /// <param name="delta">The time since the last recorded position.</param>
        /// <param name="future">The predicted future position.</param>
        /// <returns>The calculated movement.</returns>
        public static Vector2 Evade(this Vector2 position, [NotNull] GameObject target, [NotNull] Transform previous, float speed, float delta, out Vector2 future) => position.Evade(target.Flatten(), previous.Flatten(), speed, delta, out future);
        
        /// <summary>
        /// Calculate a evade behaviour.
        /// </summary>
        /// <param name="position">The current position of the instance to calculate the movement for.</param>
        /// <param name="target">The target to move in relation to.</param>
        /// <param name="previous">The previous position of the target.</param>
        /// <param name="speed">The maximum speed that the position can update at.</param>
        /// <param name="future">The predicted future position.</param>
        /// <returns>The calculated movement.</returns>
        public static Vector2 Evade(this Vector2 position, [NotNull] GameObject target, [NotNull] Transform previous, float speed, out Vector2 future) => position.Evade(target.Flatten(), previous.Flatten(), speed, Time.deltaTime, out future);

        /// <summary>
        /// Calculate a evade behaviour.
        /// </summary>
        /// <param name="position">The current position of the instance to calculate the movement for.</param>
        /// <param name="target">The target to move in relation to.</param>
        /// <param name="previous">The previous position of the target.</param>
        /// <param name="speed">The maximum speed that the position can update at.</param>
        /// <param name="delta">The time since the last recorded position.</param>
        /// <param name="future">The predicted future position.</param>
        /// <returns>The calculated movement.</returns>
        public static Vector2 Evade(this Vector2 position, [NotNull] GameObject target, [NotNull] Component previous, float speed, float delta, out Vector2 future) => position.Evade(target.Flatten(), previous.Flatten(), speed, delta, out future);
        
        /// <summary>
        /// Calculate a evade behaviour.
        /// </summary>
        /// <param name="position">The current position of the instance to calculate the movement for.</param>
        /// <param name="target">The target to move in relation to.</param>
        /// <param name="previous">The previous position of the target.</param>
        /// <param name="speed">The maximum speed that the position can update at.</param>
        /// <param name="future">The predicted future position.</param>
        /// <returns>The calculated movement.</returns>
        public static Vector2 Evade(this Vector2 position, [NotNull] GameObject target, [NotNull] Component previous, float speed, out Vector2 future) => position.Evade(target.Flatten(), previous.Flatten(), speed, Time.deltaTime, out future);

        /// <summary>
        /// Calculate a evade behaviour.
        /// </summary>
        /// <param name="position">The current position of the instance to calculate the movement for.</param>
        /// <param name="target">The target to move in relation to.</param>
        /// <param name="previous">The previous position of the target.</param>
        /// <param name="speed">The maximum speed that the position can update at.</param>
        /// <param name="delta">The time since the last recorded position.</param>
        /// <param name="future">The predicted future position.</param>
        /// <returns>The calculated movement.</returns>
        public static Vector2 Evade(this Vector2 position, [NotNull] GameObject target, [NotNull] GameObject previous, float speed, float delta, out Vector2 future) => position.Evade(target.Flatten(), previous.Flatten(), speed, delta, out future);
        
        /// <summary>
        /// Calculate a evade behaviour.
        /// </summary>
        /// <param name="position">The current position of the instance to calculate the movement for.</param>
        /// <param name="target">The target to move in relation to.</param>
        /// <param name="previous">The previous position of the target.</param>
        /// <param name="speed">The maximum speed that the position can update at.</param>
        /// <param name="future">The predicted future position.</param>
        /// <returns>The calculated movement.</returns>
        public static Vector2 Evade(this Vector2 position, [NotNull] GameObject target, [NotNull] GameObject previous, float speed, out Vector2 future) => position.Evade(target.Flatten(), previous.Flatten(), speed, Time.deltaTime, out future);
        
        /// <summary>
        /// Calculate a evade behaviour.
        /// </summary>
        /// <param name="position">The current position of the instance to calculate the movement for.</param>
        /// <param name="target">The target to move in relation to.</param>
        /// <param name="previous">The previous position of the target.</param>
        /// <param name="speed">The maximum speed that the position can update at.</param>
        /// <param name="delta">The time since the last recorded position.</param>
        /// <param name="future">The predicted future position.</param>
        /// <returns>The calculated movement.</returns>
        public static Vector2 Evade(this Vector3 position, Vector2 target, Vector2 previous, float speed, float delta, out Vector2 future) => position.Flatten().Evade(target, previous, speed, delta, out future);
        
        /// <summary>
        /// Calculate a evade behaviour.
        /// </summary>
        /// <param name="position">The current position of the instance to calculate the movement for.</param>
        /// <param name="target">The target to move in relation to.</param>
        /// <param name="previous">The previous position of the target.</param>
        /// <param name="speed">The maximum speed that the position can update at.</param>
        /// <param name="future">The predicted future position.</param>
        /// <returns>The calculated movement.</returns>
        public static Vector2 Evade(this Vector3 position, Vector2 target, Vector2 previous, float speed, out Vector2 future) => position.Flatten().Evade(target, previous, speed, Time.deltaTime, out future);
        
        /// <summary>
        /// Calculate a evade behaviour.
        /// </summary>
        /// <param name="position">The current position of the instance to calculate the movement for.</param>
        /// <param name="target">The target to move in relation to.</param>
        /// <param name="previous">The previous position of the target.</param>
        /// <param name="speed">The maximum speed that the position can update at.</param>
        /// <param name="delta">The time since the last recorded position.</param>
        /// <param name="future">The predicted future position.</param>
        /// <returns>The calculated movement.</returns>
        public static Vector2 Evade(this Vector3 position, Vector2 target, Vector3 previous, float speed, float delta, out Vector2 future) => position.Flatten().Evade(target, previous, speed, delta, out future);
        
        /// <summary>
        /// Calculate a evade behaviour.
        /// </summary>
        /// <param name="position">The current position of the instance to calculate the movement for.</param>
        /// <param name="target">The target to move in relation to.</param>
        /// <param name="previous">The previous position of the target.</param>
        /// <param name="speed">The maximum speed that the position can update at.</param>
        /// <param name="future">The predicted future position.</param>
        /// <returns>The calculated movement.</returns>
        public static Vector2 Evade(this Vector3 position, Vector2 target, Vector3 previous, float speed, out Vector2 future) => position.Flatten().Evade(target, previous, speed, Time.deltaTime, out future);
        
        /// <summary>
        /// Calculate a evade behaviour.
        /// </summary>
        /// <param name="position">The current position of the instance to calculate the movement for.</param>
        /// <param name="target">The target to move in relation to.</param>
        /// <param name="previous">The previous position of the target.</param>
        /// <param name="speed">The maximum speed that the position can update at.</param>
        /// <param name="delta">The time since the last recorded position.</param>
        /// <param name="future">The predicted future position.</param>
        /// <returns>The calculated movement.</returns>
        public static Vector2 Evade(this Vector3 position, Vector2 target, [NotNull] Transform previous, float speed, float delta, out Vector2 future) => position.Flatten().Evade(target, previous, speed, delta, out future);
        
        /// <summary>
        /// Calculate a evade behaviour.
        /// </summary>
        /// <param name="position">The current position of the instance to calculate the movement for.</param>
        /// <param name="target">The target to move in relation to.</param>
        /// <param name="previous">The previous position of the target.</param>
        /// <param name="speed">The maximum speed that the position can update at.</param>
        /// <param name="future">The predicted future position.</param>
        /// <returns>The calculated movement.</returns>
        public static Vector2 Evade(this Vector3 position, Vector2 target, [NotNull] Transform previous, float speed, out Vector2 future) => position.Flatten().Evade(target, previous, speed, Time.deltaTime, out future);
        
        /// <summary>
        /// Calculate a evade behaviour.
        /// </summary>
        /// <param name="position">The current position of the instance to calculate the movement for.</param>
        /// <param name="target">The target to move in relation to.</param>
        /// <param name="previous">The previous position of the target.</param>
        /// <param name="speed">The maximum speed that the position can update at.</param>
        /// <param name="delta">The time since the last recorded position.</param>
        /// <param name="future">The predicted future position.</param>
        /// <returns>The calculated movement.</returns>
        public static Vector2 Evade(this Vector3 position, Vector2 target, [NotNull] Component previous, float speed, float delta, out Vector2 future) => position.Flatten().Evade(target, previous, speed, delta, out future);
        
        /// <summary>
        /// Calculate a evade behaviour.
        /// </summary>
        /// <param name="position">The current position of the instance to calculate the movement for.</param>
        /// <param name="target">The target to move in relation to.</param>
        /// <param name="previous">The previous position of the target.</param>
        /// <param name="speed">The maximum speed that the position can update at.</param>
        /// <param name="future">The predicted future position.</param>
        /// <returns>The calculated movement.</returns>
        public static Vector2 Evade(this Vector3 position, Vector2 target, [NotNull] Component previous, float speed, out Vector2 future) => position.Flatten().Evade(target, previous, speed, Time.deltaTime, out future);
        
        /// <summary>
        /// Calculate a evade behaviour.
        /// </summary>
        /// <param name="position">The current position of the instance to calculate the movement for.</param>
        /// <param name="target">The target to move in relation to.</param>
        /// <param name="previous">The previous position of the target.</param>
        /// <param name="speed">The maximum speed that the position can update at.</param>
        /// <param name="delta">The time since the last recorded position.</param>
        /// <param name="future">The predicted future position.</param>
        /// <returns>The calculated movement.</returns>
        public static Vector2 Evade(this Vector3 position, Vector2 target, [NotNull] GameObject previous, float speed, float delta, out Vector2 future) => position.Flatten().Evade(target, previous, speed, delta, out future);
        
        /// <summary>
        /// Calculate a evade behaviour.
        /// </summary>
        /// <param name="position">The current position of the instance to calculate the movement for.</param>
        /// <param name="target">The target to move in relation to.</param>
        /// <param name="previous">The previous position of the target.</param>
        /// <param name="speed">The maximum speed that the position can update at.</param>
        /// <param name="future">The predicted future position.</param>
        /// <returns>The calculated movement.</returns>
        public static Vector2 Evade(this Vector3 position, Vector2 target, [NotNull] GameObject previous, float speed, out Vector2 future) => position.Flatten().Evade(target, previous, speed, Time.deltaTime, out future);
        
        /// <summary>
        /// Calculate a evade behaviour.
        /// </summary>
        /// <param name="position">The current position of the instance to calculate the movement for.</param>
        /// <param name="target">The target to move in relation to.</param>
        /// <param name="previous">The previous position of the target.</param>
        /// <param name="speed">The maximum speed that the position can update at.</param>
        /// <param name="delta">The time since the last recorded position.</param>
        /// <param name="future">The predicted future position.</param>
        /// <returns>The calculated movement.</returns>
        public static Vector2 Evade(this Vector3 position, Vector3 target, Vector2 previous, float speed, float delta, out Vector2 future) => position.Flatten().Evade(target, previous, speed, delta, out future);
        
        /// <summary>
        /// Calculate a evade behaviour.
        /// </summary>
        /// <param name="position">The current position of the instance to calculate the movement for.</param>
        /// <param name="target">The target to move in relation to.</param>
        /// <param name="previous">The previous position of the target.</param>
        /// <param name="speed">The maximum speed that the position can update at.</param>
        /// <param name="future">The predicted future position.</param>
        /// <returns>The calculated movement.</returns>
        public static Vector2 Evade(this Vector3 position, Vector3 target, Vector2 previous, float speed, out Vector2 future) => position.Flatten().Evade(target, previous, speed, Time.deltaTime, out future);
        
        /// <summary>
        /// Calculate a evade behaviour.
        /// </summary>
        /// <param name="position">The current position of the instance to calculate the movement for.</param>
        /// <param name="target">The target to move in relation to.</param>
        /// <param name="previous">The previous position of the target.</param>
        /// <param name="speed">The maximum speed that the position can update at.</param>
        /// <param name="delta">The time since the last recorded position.</param>
        /// <param name="future">The predicted future position.</param>
        /// <returns>The calculated movement.</returns>
        public static Vector2 Evade(this Vector3 position, Vector3 target, Vector3 previous, float speed, float delta, out Vector2 future) => position.Flatten().Evade(target, previous, speed, delta, out future);
        
        /// <summary>
        /// Calculate a evade behaviour.
        /// </summary>
        /// <param name="position">The current position of the instance to calculate the movement for.</param>
        /// <param name="target">The target to move in relation to.</param>
        /// <param name="previous">The previous position of the target.</param>
        /// <param name="speed">The maximum speed that the position can update at.</param>
        /// <param name="future">The predicted future position.</param>
        /// <returns>The calculated movement.</returns>
        public static Vector2 Evade(this Vector3 position, Vector3 target, Vector3 previous, float speed, out Vector2 future) => position.Flatten().Evade(target, previous, speed, Time.deltaTime, out future);
        
        /// <summary>
        /// Calculate a evade behaviour.
        /// </summary>
        /// <param name="position">The current position of the instance to calculate the movement for.</param>
        /// <param name="target">The target to move in relation to.</param>
        /// <param name="previous">The previous position of the target.</param>
        /// <param name="speed">The maximum speed that the position can update at.</param>
        /// <param name="delta">The time since the last recorded position.</param>
        /// <param name="future">The predicted future position.</param>
        /// <returns>The calculated movement.</returns>
        public static Vector2 Evade(this Vector3 position, Vector3 target, [NotNull] Transform previous, float speed, float delta, out Vector2 future) => position.Flatten().Evade(target, previous, speed, delta, out future);
        
        /// <summary>
        /// Calculate a evade behaviour.
        /// </summary>
        /// <param name="position">The current position of the instance to calculate the movement for.</param>
        /// <param name="target">The target to move in relation to.</param>
        /// <param name="previous">The previous position of the target.</param>
        /// <param name="speed">The maximum speed that the position can update at.</param>
        /// <param name="future">The predicted future position.</param>
        /// <returns>The calculated movement.</returns>
        public static Vector2 Evade(this Vector3 position, Vector3 target, [NotNull] Transform previous, float speed, out Vector2 future) => position.Flatten().Evade(target, previous, speed, Time.deltaTime, out future);
        
        /// <summary>
        /// Calculate a evade behaviour.
        /// </summary>
        /// <param name="position">The current position of the instance to calculate the movement for.</param>
        /// <param name="target">The target to move in relation to.</param>
        /// <param name="previous">The previous position of the target.</param>
        /// <param name="speed">The maximum speed that the position can update at.</param>
        /// <param name="delta">The time since the last recorded position.</param>
        /// <param name="future">The predicted future position.</param>
        /// <returns>The calculated movement.</returns>
        public static Vector2 Evade(this Vector3 position, Vector3 target, [NotNull] Component previous, float speed, float delta, out Vector2 future) => position.Flatten().Evade(target, previous, speed, delta, out future);
        
        /// <summary>
        /// Calculate a evade behaviour.
        /// </summary>
        /// <param name="position">The current position of the instance to calculate the movement for.</param>
        /// <param name="target">The target to move in relation to.</param>
        /// <param name="previous">The previous position of the target.</param>
        /// <param name="speed">The maximum speed that the position can update at.</param>
        /// <param name="future">The predicted future position.</param>
        /// <returns>The calculated movement.</returns>
        public static Vector2 Evade(this Vector3 position, Vector3 target, [NotNull] Component previous, float speed, out Vector2 future) => position.Flatten().Evade(target, previous, speed, Time.deltaTime, out future);
        
        /// <summary>
        /// Calculate a evade behaviour.
        /// </summary>
        /// <param name="position">The current position of the instance to calculate the movement for.</param>
        /// <param name="target">The target to move in relation to.</param>
        /// <param name="previous">The previous position of the target.</param>
        /// <param name="speed">The maximum speed that the position can update at.</param>
        /// <param name="delta">The time since the last recorded position.</param>
        /// <param name="future">The predicted future position.</param>
        /// <returns>The calculated movement.</returns>
        public static Vector2 Evade(this Vector3 position, Vector3 target, [NotNull] GameObject previous, float speed, float delta, out Vector2 future) => position.Flatten().Evade(target, previous, speed, delta, out future);
        
        /// <summary>
        /// Calculate a evade behaviour.
        /// </summary>
        /// <param name="position">The current position of the instance to calculate the movement for.</param>
        /// <param name="target">The target to move in relation to.</param>
        /// <param name="previous">The previous position of the target.</param>
        /// <param name="speed">The maximum speed that the position can update at.</param>
        /// <param name="future">The predicted future position.</param>
        /// <returns>The calculated movement.</returns>
        public static Vector2 Evade(this Vector3 position, Vector3 target, [NotNull] GameObject previous, float speed, out Vector2 future) => position.Flatten().Evade(target, previous, speed, Time.deltaTime, out future);
        
        /// <summary>
        /// Calculate a evade behaviour.
        /// </summary>
        /// <param name="position">The current position of the instance to calculate the movement for.</param>
        /// <param name="target">The target to move in relation to.</param>
        /// <param name="previous">The previous position of the target.</param>
        /// <param name="speed">The maximum speed that the position can update at.</param>
        /// <param name="delta">The time since the last recorded position.</param>
        /// <param name="future">The predicted future position.</param>
        /// <returns>The calculated movement.</returns>
        public static Vector2 Evade(this Vector3 position, [NotNull] Transform target, Vector2 previous, float speed, float delta, out Vector2 future) => position.Flatten().Evade(target, previous, speed, delta, out future);
        
        /// <summary>
        /// Calculate a evade behaviour.
        /// </summary>
        /// <param name="position">The current position of the instance to calculate the movement for.</param>
        /// <param name="target">The target to move in relation to.</param>
        /// <param name="previous">The previous position of the target.</param>
        /// <param name="speed">The maximum speed that the position can update at.</param>
        /// <param name="future">The predicted future position.</param>
        /// <returns>The calculated movement.</returns>
        public static Vector2 Evade(this Vector3 position, [NotNull] Transform target, Vector2 previous, float speed, out Vector2 future) => position.Flatten().Evade(target, previous, speed, Time.deltaTime, out future);
        
        /// <summary>
        /// Calculate a evade behaviour.
        /// </summary>
        /// <param name="position">The current position of the instance to calculate the movement for.</param>
        /// <param name="target">The target to move in relation to.</param>
        /// <param name="previous">The previous position of the target.</param>
        /// <param name="speed">The maximum speed that the position can update at.</param>
        /// <param name="delta">The time since the last recorded position.</param>
        /// <param name="future">The predicted future position.</param>
        /// <returns>The calculated movement.</returns>
        public static Vector2 Evade(this Vector3 position, [NotNull] Transform target, Vector3 previous, float speed, float delta, out Vector2 future) => position.Flatten().Evade(target, previous, speed, delta, out future);
        
        /// <summary>
        /// Calculate a evade behaviour.
        /// </summary>
        /// <param name="position">The current position of the instance to calculate the movement for.</param>
        /// <param name="target">The target to move in relation to.</param>
        /// <param name="previous">The previous position of the target.</param>
        /// <param name="speed">The maximum speed that the position can update at.</param>
        /// <param name="future">The predicted future position.</param>
        /// <returns>The calculated movement.</returns>
        public static Vector2 Evade(this Vector3 position, [NotNull] Transform target, Vector3 previous, float speed, out Vector2 future) => position.Flatten().Evade(target, previous, speed, Time.deltaTime, out future);
        
        /// <summary>
        /// Calculate a evade behaviour.
        /// </summary>
        /// <param name="position">The current position of the instance to calculate the movement for.</param>
        /// <param name="target">The target to move in relation to.</param>
        /// <param name="previous">The previous position of the target.</param>
        /// <param name="speed">The maximum speed that the position can update at.</param>
        /// <param name="delta">The time since the last recorded position.</param>
        /// <param name="future">The predicted future position.</param>
        /// <returns>The calculated movement.</returns>
        public static Vector2 Evade(this Vector3 position, [NotNull] Transform target, [NotNull] Transform previous, float speed, float delta, out Vector2 future) => position.Flatten().Evade(target, previous, speed, delta, out future);
        
        /// <summary>
        /// Calculate a evade behaviour.
        /// </summary>
        /// <param name="position">The current position of the instance to calculate the movement for.</param>
        /// <param name="target">The target to move in relation to.</param>
        /// <param name="previous">The previous position of the target.</param>
        /// <param name="speed">The maximum speed that the position can update at.</param>
        /// <param name="future">The predicted future position.</param>
        /// <returns>The calculated movement.</returns>
        public static Vector2 Evade(this Vector3 position, [NotNull] Transform target, [NotNull] Transform previous, float speed, out Vector2 future) => position.Flatten().Evade(target, previous, speed, Time.deltaTime, out future);
        
        /// <summary>
        /// Calculate a evade behaviour.
        /// </summary>
        /// <param name="position">The current position of the instance to calculate the movement for.</param>
        /// <param name="target">The target to move in relation to.</param>
        /// <param name="previous">The previous position of the target.</param>
        /// <param name="speed">The maximum speed that the position can update at.</param>
        /// <param name="delta">The time since the last recorded position.</param>
        /// <param name="future">The predicted future position.</param>
        /// <returns>The calculated movement.</returns>
        public static Vector2 Evade(this Vector3 position, [NotNull] Transform target, [NotNull] Component previous, float speed, float delta, out Vector2 future) => position.Flatten().Evade(target, previous, speed, delta, out future);
        
        /// <summary>
        /// Calculate a evade behaviour.
        /// </summary>
        /// <param name="position">The current position of the instance to calculate the movement for.</param>
        /// <param name="target">The target to move in relation to.</param>
        /// <param name="previous">The previous position of the target.</param>
        /// <param name="speed">The maximum speed that the position can update at.</param>
        /// <param name="future">The predicted future position.</param>
        /// <returns>The calculated movement.</returns>
        public static Vector2 Evade(this Vector3 position, [NotNull] Transform target, [NotNull] Component previous, float speed, out Vector2 future) => position.Flatten().Evade(target, previous, speed, Time.deltaTime, out future);
        
        /// <summary>
        /// Calculate a evade behaviour.
        /// </summary>
        /// <param name="position">The current position of the instance to calculate the movement for.</param>
        /// <param name="target">The target to move in relation to.</param>
        /// <param name="previous">The previous position of the target.</param>
        /// <param name="speed">The maximum speed that the position can update at.</param>
        /// <param name="delta">The time since the last recorded position.</param>
        /// <param name="future">The predicted future position.</param>
        /// <returns>The calculated movement.</returns>
        public static Vector2 Evade(this Vector3 position, [NotNull] Transform target, [NotNull] GameObject previous, float speed, float delta, out Vector2 future) => position.Flatten().Evade(target, previous, speed, delta, out future);
        
        /// <summary>
        /// Calculate a evade behaviour.
        /// </summary>
        /// <param name="position">The current position of the instance to calculate the movement for.</param>
        /// <param name="target">The target to move in relation to.</param>
        /// <param name="previous">The previous position of the target.</param>
        /// <param name="speed">The maximum speed that the position can update at.</param>
        /// <param name="future">The predicted future position.</param>
        /// <returns>The calculated movement.</returns>
        public static Vector2 Evade(this Vector3 position, [NotNull] Transform target, [NotNull] GameObject previous, float speed, out Vector2 future) => position.Flatten().Evade(target, previous, speed, Time.deltaTime, out future);
        
        /// <summary>
        /// Calculate a evade behaviour.
        /// </summary>
        /// <param name="position">The current position of the instance to calculate the movement for.</param>
        /// <param name="target">The target to move in relation to.</param>
        /// <param name="previous">The previous position of the target.</param>
        /// <param name="speed">The maximum speed that the position can update at.</param>
        /// <param name="delta">The time since the last recorded position.</param>
        /// <param name="future">The predicted future position.</param>
        /// <returns>The calculated movement.</returns>
        public static Vector2 Evade(this Vector3 position, [NotNull] Component target, Vector2 previous, float speed, float delta, out Vector2 future) => position.Flatten().Evade(target, previous, speed, delta, out future);
        
        /// <summary>
        /// Calculate a evade behaviour.
        /// </summary>
        /// <param name="position">The current position of the instance to calculate the movement for.</param>
        /// <param name="target">The target to move in relation to.</param>
        /// <param name="previous">The previous position of the target.</param>
        /// <param name="speed">The maximum speed that the position can update at.</param>
        /// <param name="future">The predicted future position.</param>
        /// <returns>The calculated movement.</returns>
        public static Vector2 Evade(this Vector3 position, [NotNull] Component target, Vector2 previous, float speed, out Vector2 future) => position.Flatten().Evade(target, previous, speed, Time.deltaTime, out future);
        
        /// <summary>
        /// Calculate a evade behaviour.
        /// </summary>
        /// <param name="position">The current position of the instance to calculate the movement for.</param>
        /// <param name="target">The target to move in relation to.</param>
        /// <param name="previous">The previous position of the target.</param>
        /// <param name="speed">The maximum speed that the position can update at.</param>
        /// <param name="delta">The time since the last recorded position.</param>
        /// <param name="future">The predicted future position.</param>
        /// <returns>The calculated movement.</returns>
        public static Vector2 Evade(this Vector3 position, [NotNull] Component target, Vector3 previous, float speed, float delta, out Vector2 future) => position.Flatten().Evade(target, previous, speed, delta, out future);
        
        /// <summary>
        /// Calculate a evade behaviour.
        /// </summary>
        /// <param name="position">The current position of the instance to calculate the movement for.</param>
        /// <param name="target">The target to move in relation to.</param>
        /// <param name="previous">The previous position of the target.</param>
        /// <param name="speed">The maximum speed that the position can update at.</param>
        /// <param name="future">The predicted future position.</param>
        /// <returns>The calculated movement.</returns>
        public static Vector2 Evade(this Vector3 position, [NotNull] Component target, Vector3 previous, float speed, out Vector2 future) => position.Flatten().Evade(target, previous, speed, Time.deltaTime, out future);
        
        /// <summary>
        /// Calculate a evade behaviour.
        /// </summary>
        /// <param name="position">The current position of the instance to calculate the movement for.</param>
        /// <param name="target">The target to move in relation to.</param>
        /// <param name="previous">The previous position of the target.</param>
        /// <param name="speed">The maximum speed that the position can update at.</param>
        /// <param name="delta">The time since the last recorded position.</param>
        /// <param name="future">The predicted future position.</param>
        /// <returns>The calculated movement.</returns>
        public static Vector2 Evade(this Vector3 position, [NotNull] Component target, [NotNull] Transform previous, float speed, float delta, out Vector2 future) => position.Flatten().Evade(target, previous, speed, delta, out future);
        
        /// <summary>
        /// Calculate a evade behaviour.
        /// </summary>
        /// <param name="position">The current position of the instance to calculate the movement for.</param>
        /// <param name="target">The target to move in relation to.</param>
        /// <param name="previous">The previous position of the target.</param>
        /// <param name="speed">The maximum speed that the position can update at.</param>
        /// <param name="future">The predicted future position.</param>
        /// <returns>The calculated movement.</returns>
        public static Vector2 Evade(this Vector3 position, [NotNull] Component target, [NotNull] Transform previous, float speed, out Vector2 future) => position.Flatten().Evade(target, previous, speed, Time.deltaTime, out future);
        
        /// <summary>
        /// Calculate a evade behaviour.
        /// </summary>
        /// <param name="position">The current position of the instance to calculate the movement for.</param>
        /// <param name="target">The target to move in relation to.</param>
        /// <param name="previous">The previous position of the target.</param>
        /// <param name="speed">The maximum speed that the position can update at.</param>
        /// <param name="delta">The time since the last recorded position.</param>
        /// <param name="future">The predicted future position.</param>
        /// <returns>The calculated movement.</returns>
        public static Vector2 Evade(this Vector3 position, [NotNull] Component target, [NotNull] Component previous, float speed, float delta, out Vector2 future) => position.Flatten().Evade(target, previous, speed, delta, out future);
        
        /// <summary>
        /// Calculate a evade behaviour.
        /// </summary>
        /// <param name="position">The current position of the instance to calculate the movement for.</param>
        /// <param name="target">The target to move in relation to.</param>
        /// <param name="previous">The previous position of the target.</param>
        /// <param name="speed">The maximum speed that the position can update at.</param>
        /// <param name="future">The predicted future position.</param>
        /// <returns>The calculated movement.</returns>
        public static Vector2 Evade(this Vector3 position, [NotNull] Component target, [NotNull] Component previous, float speed, out Vector2 future) => position.Flatten().Evade(target, previous, speed, Time.deltaTime, out future);
        
        /// <summary>
        /// Calculate a evade behaviour.
        /// </summary>
        /// <param name="position">The current position of the instance to calculate the movement for.</param>
        /// <param name="target">The target to move in relation to.</param>
        /// <param name="previous">The previous position of the target.</param>
        /// <param name="speed">The maximum speed that the position can update at.</param>
        /// <param name="delta">The time since the last recorded position.</param>
        /// <param name="future">The predicted future position.</param>
        /// <returns>The calculated movement.</returns>
        public static Vector2 Evade(this Vector3 position, [NotNull] Component target, [NotNull] GameObject previous, float speed, float delta, out Vector2 future) => position.Flatten().Evade(target, previous, speed, delta, out future);
        
        /// <summary>
        /// Calculate a evade behaviour.
        /// </summary>
        /// <param name="position">The current position of the instance to calculate the movement for.</param>
        /// <param name="target">The target to move in relation to.</param>
        /// <param name="previous">The previous position of the target.</param>
        /// <param name="speed">The maximum speed that the position can update at.</param>
        /// <param name="future">The predicted future position.</param>
        /// <returns>The calculated movement.</returns>
        public static Vector2 Evade(this Vector3 position, [NotNull] Component target, [NotNull] GameObject previous, float speed, out Vector2 future) => position.Flatten().Evade(target, previous, speed, Time.deltaTime, out future);
        
        /// <summary>
        /// Calculate a evade behaviour.
        /// </summary>
        /// <param name="position">The current position of the instance to calculate the movement for.</param>
        /// <param name="target">The target to move in relation to.</param>
        /// <param name="previous">The previous position of the target.</param>
        /// <param name="speed">The maximum speed that the position can update at.</param>
        /// <param name="delta">The time since the last recorded position.</param>
        /// <param name="future">The predicted future position.</param>
        /// <returns>The calculated movement.</returns>
        public static Vector2 Evade(this Vector3 position, [NotNull] GameObject target, Vector2 previous, float speed, float delta, out Vector2 future) => position.Flatten().Evade(target, previous, speed, delta, out future);
        
        /// <summary>
        /// Calculate a evade behaviour.
        /// </summary>
        /// <param name="position">The current position of the instance to calculate the movement for.</param>
        /// <param name="target">The target to move in relation to.</param>
        /// <param name="previous">The previous position of the target.</param>
        /// <param name="speed">The maximum speed that the position can update at.</param>
        /// <param name="future">The predicted future position.</param>
        /// <returns>The calculated movement.</returns>
        public static Vector2 Evade(this Vector3 position, [NotNull] GameObject target, Vector2 previous, float speed, out Vector2 future) => position.Flatten().Evade(target, previous, speed, Time.deltaTime, out future);
        
        /// <summary>
        /// Calculate a evade behaviour.
        /// </summary>
        /// <param name="position">The current position of the instance to calculate the movement for.</param>
        /// <param name="target">The target to move in relation to.</param>
        /// <param name="previous">The previous position of the target.</param>
        /// <param name="speed">The maximum speed that the position can update at.</param>
        /// <param name="delta">The time since the last recorded position.</param>
        /// <param name="future">The predicted future position.</param>
        /// <returns>The calculated movement.</returns>
        public static Vector2 Evade(this Vector3 position, [NotNull] GameObject target, Vector3 previous, float speed, float delta, out Vector2 future) => position.Flatten().Evade(target, previous, speed, delta, out future);
        
        /// <summary>
        /// Calculate a evade behaviour.
        /// </summary>
        /// <param name="position">The current position of the instance to calculate the movement for.</param>
        /// <param name="target">The target to move in relation to.</param>
        /// <param name="previous">The previous position of the target.</param>
        /// <param name="speed">The maximum speed that the position can update at.</param>
        /// <param name="future">The predicted future position.</param>
        /// <returns>The calculated movement.</returns>
        public static Vector2 Evade(this Vector3 position, [NotNull] GameObject target, Vector3 previous, float speed, out Vector2 future) => position.Flatten().Evade(target, previous, speed, Time.deltaTime, out future);
        
        /// <summary>
        /// Calculate a evade behaviour.
        /// </summary>
        /// <param name="position">The current position of the instance to calculate the movement for.</param>
        /// <param name="target">The target to move in relation to.</param>
        /// <param name="previous">The previous position of the target.</param>
        /// <param name="speed">The maximum speed that the position can update at.</param>
        /// <param name="delta">The time since the last recorded position.</param>
        /// <param name="future">The predicted future position.</param>
        /// <returns>The calculated movement.</returns>
        public static Vector2 Evade(this Vector3 position, [NotNull] GameObject target, [NotNull] Transform previous, float speed, float delta, out Vector2 future) => position.Flatten().Evade(target, previous, speed, delta, out future);
        
        /// <summary>
        /// Calculate a evade behaviour.
        /// </summary>
        /// <param name="position">The current position of the instance to calculate the movement for.</param>
        /// <param name="target">The target to move in relation to.</param>
        /// <param name="previous">The previous position of the target.</param>
        /// <param name="speed">The maximum speed that the position can update at.</param>
        /// <param name="future">The predicted future position.</param>
        /// <returns>The calculated movement.</returns>
        public static Vector2 Evade(this Vector3 position, [NotNull] GameObject target, [NotNull] Transform previous, float speed, out Vector2 future) => position.Flatten().Evade(target, previous, speed, Time.deltaTime, out future);
        
        /// <summary>
        /// Calculate a evade behaviour.
        /// </summary>
        /// <param name="position">The current position of the instance to calculate the movement for.</param>
        /// <param name="target">The target to move in relation to.</param>
        /// <param name="previous">The previous position of the target.</param>
        /// <param name="speed">The maximum speed that the position can update at.</param>
        /// <param name="delta">The time since the last recorded position.</param>
        /// <param name="future">The predicted future position.</param>
        /// <returns>The calculated movement.</returns>
        public static Vector2 Evade(this Vector3 position, [NotNull] GameObject target, [NotNull] Component previous, float speed, float delta, out Vector2 future) => position.Flatten().Evade(target, previous, speed, delta, out future);
        
        /// <summary>
        /// Calculate a evade behaviour.
        /// </summary>
        /// <param name="position">The current position of the instance to calculate the movement for.</param>
        /// <param name="target">The target to move in relation to.</param>
        /// <param name="previous">The previous position of the target.</param>
        /// <param name="speed">The maximum speed that the position can update at.</param>
        /// <param name="future">The predicted future position.</param>
        /// <returns>The calculated movement.</returns>
        public static Vector2 Evade(this Vector3 position, [NotNull] GameObject target, [NotNull] Component previous, float speed, out Vector2 future) => position.Flatten().Evade(target, previous, speed, Time.deltaTime, out future);
        
        /// <summary>
        /// Calculate a evade behaviour.
        /// </summary>
        /// <param name="position">The current position of the instance to calculate the movement for.</param>
        /// <param name="target">The target to move in relation to.</param>
        /// <param name="previous">The previous position of the target.</param>
        /// <param name="speed">The maximum speed that the position can update at.</param>
        /// <param name="delta">The time since the last recorded position.</param>
        /// <param name="future">The predicted future position.</param>
        /// <returns>The calculated movement.</returns>
        public static Vector2 Evade(this Vector3 position, [NotNull] GameObject target, [NotNull] GameObject previous, float speed, float delta, out Vector2 future) => position.Flatten().Evade(target, previous, speed, delta, out future);
        
        /// <summary>
        /// Calculate a evade behaviour.
        /// </summary>
        /// <param name="position">The current position of the instance to calculate the movement for.</param>
        /// <param name="target">The target to move in relation to.</param>
        /// <param name="previous">The previous position of the target.</param>
        /// <param name="speed">The maximum speed that the position can update at.</param>
        /// <param name="future">The predicted future position.</param>
        /// <returns>The calculated movement.</returns>
        public static Vector2 Evade(this Vector3 position, [NotNull] GameObject target, [NotNull] GameObject previous, float speed, out Vector2 future) => position.Flatten().Evade(target, previous, speed, Time.deltaTime, out future);
        
        /// <summary>
        /// Calculate a evade behaviour.
        /// </summary>
        /// <param name="position">The current position of the instance to calculate the movement for.</param>
        /// <param name="target">The target to move in relation to.</param>
        /// <param name="previous">The previous position of the target.</param>
        /// <param name="speed">The maximum speed that the position can update at.</param>
        /// <param name="delta">The time since the last recorded position.</param>
        /// <param name="future">The predicted future position.</param>
        /// <returns>The calculated movement.</returns>
        public static Vector2 Evade([NotNull] this Transform position, Vector2 target, Vector2 previous, float speed, float delta, out Vector2 future) => position.Flatten().Evade(target, previous, speed, delta, out future);
        
        /// <summary>
        /// Calculate a evade behaviour.
        /// </summary>
        /// <param name="position">The current position of the instance to calculate the movement for.</param>
        /// <param name="target">The target to move in relation to.</param>
        /// <param name="previous">The previous position of the target.</param>
        /// <param name="speed">The maximum speed that the position can update at.</param>
        /// <param name="future">The predicted future position.</param>
        /// <returns>The calculated movement.</returns>
        public static Vector2 Evade([NotNull] this Transform position, Vector2 target, Vector2 previous, float speed, out Vector2 future) => position.Flatten().Evade(target, previous, speed, Time.deltaTime, out future);
        
        /// <summary>
        /// Calculate a evade behaviour.
        /// </summary>
        /// <param name="position">The current position of the instance to calculate the movement for.</param>
        /// <param name="target">The target to move in relation to.</param>
        /// <param name="previous">The previous position of the target.</param>
        /// <param name="speed">The maximum speed that the position can update at.</param>
        /// <param name="delta">The time since the last recorded position.</param>
        /// <param name="future">The predicted future position.</param>
        /// <returns>The calculated movement.</returns>
        public static Vector2 Evade([NotNull] this Transform position, Vector2 target, Vector3 previous, float speed, float delta, out Vector2 future) => position.Flatten().Evade(target, previous, speed, delta, out future);
        
        /// <summary>
        /// Calculate a evade behaviour.
        /// </summary>
        /// <param name="position">The current position of the instance to calculate the movement for.</param>
        /// <param name="target">The target to move in relation to.</param>
        /// <param name="previous">The previous position of the target.</param>
        /// <param name="speed">The maximum speed that the position can update at.</param>
        /// <param name="future">The predicted future position.</param>
        /// <returns>The calculated movement.</returns>
        public static Vector2 Evade([NotNull] this Transform position, Vector2 target, Vector3 previous, float speed, out Vector2 future) => position.Flatten().Evade(target, previous, speed, Time.deltaTime, out future);
        
        /// <summary>
        /// Calculate a evade behaviour.
        /// </summary>
        /// <param name="position">The current position of the instance to calculate the movement for.</param>
        /// <param name="target">The target to move in relation to.</param>
        /// <param name="previous">The previous position of the target.</param>
        /// <param name="speed">The maximum speed that the position can update at.</param>
        /// <param name="delta">The time since the last recorded position.</param>
        /// <param name="future">The predicted future position.</param>
        /// <returns>The calculated movement.</returns>
        public static Vector2 Evade([NotNull] this Transform position, Vector2 target, [NotNull] Transform previous, float speed, float delta, out Vector2 future) => position.Flatten().Evade(target, previous, speed, delta, out future);
        
        /// <summary>
        /// Calculate a evade behaviour.
        /// </summary>
        /// <param name="position">The current position of the instance to calculate the movement for.</param>
        /// <param name="target">The target to move in relation to.</param>
        /// <param name="previous">The previous position of the target.</param>
        /// <param name="speed">The maximum speed that the position can update at.</param>
        /// <param name="future">The predicted future position.</param>
        /// <returns>The calculated movement.</returns>
        public static Vector2 Evade([NotNull] this Transform position, Vector2 target, [NotNull] Transform previous, float speed, out Vector2 future) => position.Flatten().Evade(target, previous, speed, Time.deltaTime, out future);
        
        /// <summary>
        /// Calculate a evade behaviour.
        /// </summary>
        /// <param name="position">The current position of the instance to calculate the movement for.</param>
        /// <param name="target">The target to move in relation to.</param>
        /// <param name="previous">The previous position of the target.</param>
        /// <param name="speed">The maximum speed that the position can update at.</param>
        /// <param name="delta">The time since the last recorded position.</param>
        /// <param name="future">The predicted future position.</param>
        /// <returns>The calculated movement.</returns>
        public static Vector2 Evade([NotNull] this Transform position, Vector2 target, [NotNull] Component previous, float speed, float delta, out Vector2 future) => position.Flatten().Evade(target, previous, speed, delta, out future);
        
        /// <summary>
        /// Calculate a evade behaviour.
        /// </summary>
        /// <param name="position">The current position of the instance to calculate the movement for.</param>
        /// <param name="target">The target to move in relation to.</param>
        /// <param name="previous">The previous position of the target.</param>
        /// <param name="speed">The maximum speed that the position can update at.</param>
        /// <param name="future">The predicted future position.</param>
        /// <returns>The calculated movement.</returns>
        public static Vector2 Evade([NotNull] this Transform position, Vector2 target, [NotNull] Component previous, float speed, out Vector2 future) => position.Flatten().Evade(target, previous, speed, Time.deltaTime, out future);
        
        /// <summary>
        /// Calculate a evade behaviour.
        /// </summary>
        /// <param name="position">The current position of the instance to calculate the movement for.</param>
        /// <param name="target">The target to move in relation to.</param>
        /// <param name="previous">The previous position of the target.</param>
        /// <param name="speed">The maximum speed that the position can update at.</param>
        /// <param name="delta">The time since the last recorded position.</param>
        /// <param name="future">The predicted future position.</param>
        /// <returns>The calculated movement.</returns>
        public static Vector2 Evade([NotNull] this Transform position, Vector2 target, [NotNull] GameObject previous, float speed, float delta, out Vector2 future) => position.Flatten().Evade(target, previous, speed, delta, out future);
        
        /// <summary>
        /// Calculate a evade behaviour.
        /// </summary>
        /// <param name="position">The current position of the instance to calculate the movement for.</param>
        /// <param name="target">The target to move in relation to.</param>
        /// <param name="previous">The previous position of the target.</param>
        /// <param name="speed">The maximum speed that the position can update at.</param>
        /// <param name="future">The predicted future position.</param>
        /// <returns>The calculated movement.</returns>
        public static Vector2 Evade([NotNull] this Transform position, Vector2 target, [NotNull] GameObject previous, float speed, out Vector2 future) => position.Flatten().Evade(target, previous, speed, Time.deltaTime, out future);
        
        /// <summary>
        /// Calculate a evade behaviour.
        /// </summary>
        /// <param name="position">The current position of the instance to calculate the movement for.</param>
        /// <param name="target">The target to move in relation to.</param>
        /// <param name="previous">The previous position of the target.</param>
        /// <param name="speed">The maximum speed that the position can update at.</param>
        /// <param name="delta">The time since the last recorded position.</param>
        /// <param name="future">The predicted future position.</param>
        /// <returns>The calculated movement.</returns>
        public static Vector2 Evade([NotNull] this Transform position, Vector3 target, Vector2 previous, float speed, float delta, out Vector2 future) => position.Flatten().Evade(target, previous, speed, delta, out future);
        
        /// <summary>
        /// Calculate a evade behaviour.
        /// </summary>
        /// <param name="position">The current position of the instance to calculate the movement for.</param>
        /// <param name="target">The target to move in relation to.</param>
        /// <param name="previous">The previous position of the target.</param>
        /// <param name="speed">The maximum speed that the position can update at.</param>
        /// <param name="future">The predicted future position.</param>
        /// <returns>The calculated movement.</returns>
        public static Vector2 Evade([NotNull] this Transform position, Vector3 target, Vector2 previous, float speed, out Vector2 future) => position.Flatten().Evade(target, previous, speed, Time.deltaTime, out future);
        
        /// <summary>
        /// Calculate a evade behaviour.
        /// </summary>
        /// <param name="position">The current position of the instance to calculate the movement for.</param>
        /// <param name="target">The target to move in relation to.</param>
        /// <param name="previous">The previous position of the target.</param>
        /// <param name="speed">The maximum speed that the position can update at.</param>
        /// <param name="delta">The time since the last recorded position.</param>
        /// <param name="future">The predicted future position.</param>
        /// <returns>The calculated movement.</returns>
        public static Vector2 Evade([NotNull] this Transform position, Vector3 target, Vector3 previous, float speed, float delta, out Vector2 future) => position.Flatten().Evade(target, previous, speed, delta, out future);
        
        /// <summary>
        /// Calculate a evade behaviour.
        /// </summary>
        /// <param name="position">The current position of the instance to calculate the movement for.</param>
        /// <param name="target">The target to move in relation to.</param>
        /// <param name="previous">The previous position of the target.</param>
        /// <param name="speed">The maximum speed that the position can update at.</param>
        /// <param name="future">The predicted future position.</param>
        /// <returns>The calculated movement.</returns>
        public static Vector2 Evade([NotNull] this Transform position, Vector3 target, Vector3 previous, float speed, out Vector2 future) => position.Flatten().Evade(target, previous, speed, Time.deltaTime, out future);
        
        /// <summary>
        /// Calculate a evade behaviour.
        /// </summary>
        /// <param name="position">The current position of the instance to calculate the movement for.</param>
        /// <param name="target">The target to move in relation to.</param>
        /// <param name="previous">The previous position of the target.</param>
        /// <param name="speed">The maximum speed that the position can update at.</param>
        /// <param name="delta">The time since the last recorded position.</param>
        /// <param name="future">The predicted future position.</param>
        /// <returns>The calculated movement.</returns>
        public static Vector2 Evade([NotNull] this Transform position, Vector3 target, [NotNull] Transform previous, float speed, float delta, out Vector2 future) => position.Flatten().Evade(target, previous, speed, delta, out future);
        
        /// <summary>
        /// Calculate a evade behaviour.
        /// </summary>
        /// <param name="position">The current position of the instance to calculate the movement for.</param>
        /// <param name="target">The target to move in relation to.</param>
        /// <param name="previous">The previous position of the target.</param>
        /// <param name="speed">The maximum speed that the position can update at.</param>
        /// <param name="future">The predicted future position.</param>
        /// <returns>The calculated movement.</returns>
        public static Vector2 Evade([NotNull] this Transform position, Vector3 target, [NotNull] Transform previous, float speed, out Vector2 future) => position.Flatten().Evade(target, previous, speed, Time.deltaTime, out future);
        
        /// <summary>
        /// Calculate a evade behaviour.
        /// </summary>
        /// <param name="position">The current position of the instance to calculate the movement for.</param>
        /// <param name="target">The target to move in relation to.</param>
        /// <param name="previous">The previous position of the target.</param>
        /// <param name="speed">The maximum speed that the position can update at.</param>
        /// <param name="delta">The time since the last recorded position.</param>
        /// <param name="future">The predicted future position.</param>
        /// <returns>The calculated movement.</returns>
        public static Vector2 Evade([NotNull] this Transform position, Vector3 target, [NotNull] Component previous, float speed, float delta, out Vector2 future) => position.Flatten().Evade(target, previous, speed, delta, out future);
        
        /// <summary>
        /// Calculate a evade behaviour.
        /// </summary>
        /// <param name="position">The current position of the instance to calculate the movement for.</param>
        /// <param name="target">The target to move in relation to.</param>
        /// <param name="previous">The previous position of the target.</param>
        /// <param name="speed">The maximum speed that the position can update at.</param>
        /// <param name="future">The predicted future position.</param>
        /// <returns>The calculated movement.</returns>
        public static Vector2 Evade([NotNull] this Transform position, Vector3 target, [NotNull] Component previous, float speed, out Vector2 future) => position.Flatten().Evade(target, previous, speed, Time.deltaTime, out future);
        
        /// <summary>
        /// Calculate a evade behaviour.
        /// </summary>
        /// <param name="position">The current position of the instance to calculate the movement for.</param>
        /// <param name="target">The target to move in relation to.</param>
        /// <param name="previous">The previous position of the target.</param>
        /// <param name="speed">The maximum speed that the position can update at.</param>
        /// <param name="delta">The time since the last recorded position.</param>
        /// <param name="future">The predicted future position.</param>
        /// <returns>The calculated movement.</returns>
        public static Vector2 Evade([NotNull] this Transform position, Vector3 target, [NotNull] GameObject previous, float speed, float delta, out Vector2 future) => position.Flatten().Evade(target, previous, speed, delta, out future);
        
        /// <summary>
        /// Calculate a evade behaviour.
        /// </summary>
        /// <param name="position">The current position of the instance to calculate the movement for.</param>
        /// <param name="target">The target to move in relation to.</param>
        /// <param name="previous">The previous position of the target.</param>
        /// <param name="speed">The maximum speed that the position can update at.</param>
        /// <param name="future">The predicted future position.</param>
        /// <returns>The calculated movement.</returns>
        public static Vector2 Evade([NotNull] this Transform position, Vector3 target, [NotNull] GameObject previous, float speed, out Vector2 future) => position.Flatten().Evade(target, previous, speed, Time.deltaTime, out future);
        
        /// <summary>
        /// Calculate a evade behaviour.
        /// </summary>
        /// <param name="position">The current position of the instance to calculate the movement for.</param>
        /// <param name="target">The target to move in relation to.</param>
        /// <param name="previous">The previous position of the target.</param>
        /// <param name="speed">The maximum speed that the position can update at.</param>
        /// <param name="delta">The time since the last recorded position.</param>
        /// <param name="future">The predicted future position.</param>
        /// <returns>The calculated movement.</returns>
        public static Vector2 Evade([NotNull] this Transform position, [NotNull] Transform target, Vector2 previous, float speed, float delta, out Vector2 future) => position.Flatten().Evade(target, previous, speed, delta, out future);
        
        /// <summary>
        /// Calculate a evade behaviour.
        /// </summary>
        /// <param name="position">The current position of the instance to calculate the movement for.</param>
        /// <param name="target">The target to move in relation to.</param>
        /// <param name="previous">The previous position of the target.</param>
        /// <param name="speed">The maximum speed that the position can update at.</param>
        /// <param name="future">The predicted future position.</param>
        /// <returns>The calculated movement.</returns>
        public static Vector2 Evade([NotNull] this Transform position, [NotNull] Transform target, Vector2 previous, float speed, out Vector2 future) => position.Flatten().Evade(target, previous, speed, Time.deltaTime, out future);
        
        /// <summary>
        /// Calculate a evade behaviour.
        /// </summary>
        /// <param name="position">The current position of the instance to calculate the movement for.</param>
        /// <param name="target">The target to move in relation to.</param>
        /// <param name="previous">The previous position of the target.</param>
        /// <param name="speed">The maximum speed that the position can update at.</param>
        /// <param name="delta">The time since the last recorded position.</param>
        /// <param name="future">The predicted future position.</param>
        /// <returns>The calculated movement.</returns>
        public static Vector2 Evade([NotNull] this Transform position, [NotNull] Transform target, Vector3 previous, float speed, float delta, out Vector2 future) => position.Flatten().Evade(target, previous, speed, delta, out future);
        
        /// <summary>
        /// Calculate a evade behaviour.
        /// </summary>
        /// <param name="position">The current position of the instance to calculate the movement for.</param>
        /// <param name="target">The target to move in relation to.</param>
        /// <param name="previous">The previous position of the target.</param>
        /// <param name="speed">The maximum speed that the position can update at.</param>
        /// <param name="future">The predicted future position.</param>
        /// <returns>The calculated movement.</returns>
        public static Vector2 Evade([NotNull] this Transform position, [NotNull] Transform target, Vector3 previous, float speed, out Vector2 future) => position.Flatten().Evade(target, previous, speed, Time.deltaTime, out future);
        
        /// <summary>
        /// Calculate a evade behaviour.
        /// </summary>
        /// <param name="position">The current position of the instance to calculate the movement for.</param>
        /// <param name="target">The target to move in relation to.</param>
        /// <param name="previous">The previous position of the target.</param>
        /// <param name="speed">The maximum speed that the position can update at.</param>
        /// <param name="delta">The time since the last recorded position.</param>
        /// <param name="future">The predicted future position.</param>
        /// <returns>The calculated movement.</returns>
        public static Vector2 Evade([NotNull] this Transform position, [NotNull] Transform target, [NotNull] Transform previous, float speed, float delta, out Vector2 future) => position.Flatten().Evade(target, previous, speed, delta, out future);
        
        /// <summary>
        /// Calculate a evade behaviour.
        /// </summary>
        /// <param name="position">The current position of the instance to calculate the movement for.</param>
        /// <param name="target">The target to move in relation to.</param>
        /// <param name="previous">The previous position of the target.</param>
        /// <param name="speed">The maximum speed that the position can update at.</param>
        /// <param name="future">The predicted future position.</param>
        /// <returns>The calculated movement.</returns>
        public static Vector2 Evade([NotNull] this Transform position, [NotNull] Transform target, [NotNull] Transform previous, float speed, out Vector2 future) => position.Flatten().Evade(target, previous, speed, Time.deltaTime, out future);
        
        /// <summary>
        /// Calculate a evade behaviour.
        /// </summary>
        /// <param name="position">The current position of the instance to calculate the movement for.</param>
        /// <param name="target">The target to move in relation to.</param>
        /// <param name="previous">The previous position of the target.</param>
        /// <param name="speed">The maximum speed that the position can update at.</param>
        /// <param name="delta">The time since the last recorded position.</param>
        /// <param name="future">The predicted future position.</param>
        /// <returns>The calculated movement.</returns>
        public static Vector2 Evade([NotNull] this Transform position, [NotNull] Transform target, [NotNull] Component previous, float speed, float delta, out Vector2 future) => position.Flatten().Evade(target, previous, speed, delta, out future);
        
        /// <summary>
        /// Calculate a evade behaviour.
        /// </summary>
        /// <param name="position">The current position of the instance to calculate the movement for.</param>
        /// <param name="target">The target to move in relation to.</param>
        /// <param name="previous">The previous position of the target.</param>
        /// <param name="speed">The maximum speed that the position can update at.</param>
        /// <param name="future">The predicted future position.</param>
        /// <returns>The calculated movement.</returns>
        public static Vector2 Evade([NotNull] this Transform position, [NotNull] Transform target, [NotNull] Component previous, float speed, out Vector2 future) => position.Flatten().Evade(target, previous, speed, Time.deltaTime, out future);
        
        /// <summary>
        /// Calculate a evade behaviour.
        /// </summary>
        /// <param name="position">The current position of the instance to calculate the movement for.</param>
        /// <param name="target">The target to move in relation to.</param>
        /// <param name="previous">The previous position of the target.</param>
        /// <param name="speed">The maximum speed that the position can update at.</param>
        /// <param name="delta">The time since the last recorded position.</param>
        /// <param name="future">The predicted future position.</param>
        /// <returns>The calculated movement.</returns>
        public static Vector2 Evade([NotNull] this Transform position, [NotNull] Transform target, [NotNull] GameObject previous, float speed, float delta, out Vector2 future) => position.Flatten().Evade(target, previous, speed, delta, out future);
        
        /// <summary>
        /// Calculate a evade behaviour.
        /// </summary>
        /// <param name="position">The current position of the instance to calculate the movement for.</param>
        /// <param name="target">The target to move in relation to.</param>
        /// <param name="previous">The previous position of the target.</param>
        /// <param name="speed">The maximum speed that the position can update at.</param>
        /// <param name="future">The predicted future position.</param>
        /// <returns>The calculated movement.</returns>
        public static Vector2 Evade([NotNull] this Transform position, [NotNull] Transform target, [NotNull] GameObject previous, float speed, out Vector2 future) => position.Flatten().Evade(target, previous, speed, Time.deltaTime, out future);
        
        /// <summary>
        /// Calculate a evade behaviour.
        /// </summary>
        /// <param name="position">The current position of the instance to calculate the movement for.</param>
        /// <param name="target">The target to move in relation to.</param>
        /// <param name="previous">The previous position of the target.</param>
        /// <param name="speed">The maximum speed that the position can update at.</param>
        /// <param name="delta">The time since the last recorded position.</param>
        /// <param name="future">The predicted future position.</param>
        /// <returns>The calculated movement.</returns>
        public static Vector2 Evade([NotNull] this Transform position, [NotNull] Component target, Vector2 previous, float speed, float delta, out Vector2 future) => position.Flatten().Evade(target, previous, speed, delta, out future);
        
        /// <summary>
        /// Calculate a evade behaviour.
        /// </summary>
        /// <param name="position">The current position of the instance to calculate the movement for.</param>
        /// <param name="target">The target to move in relation to.</param>
        /// <param name="previous">The previous position of the target.</param>
        /// <param name="speed">The maximum speed that the position can update at.</param>
        /// <param name="future">The predicted future position.</param>
        /// <returns>The calculated movement.</returns>
        public static Vector2 Evade([NotNull] this Transform position, [NotNull] Component target, Vector2 previous, float speed, out Vector2 future) => position.Flatten().Evade(target, previous, speed, Time.deltaTime, out future);
        
        /// <summary>
        /// Calculate a evade behaviour.
        /// </summary>
        /// <param name="position">The current position of the instance to calculate the movement for.</param>
        /// <param name="target">The target to move in relation to.</param>
        /// <param name="previous">The previous position of the target.</param>
        /// <param name="speed">The maximum speed that the position can update at.</param>
        /// <param name="delta">The time since the last recorded position.</param>
        /// <param name="future">The predicted future position.</param>
        /// <returns>The calculated movement.</returns>
        public static Vector2 Evade([NotNull] this Transform position, [NotNull] Component target, Vector3 previous, float speed, float delta, out Vector2 future) => position.Flatten().Evade(target, previous, speed, delta, out future);
        
        /// <summary>
        /// Calculate a evade behaviour.
        /// </summary>
        /// <param name="position">The current position of the instance to calculate the movement for.</param>
        /// <param name="target">The target to move in relation to.</param>
        /// <param name="previous">The previous position of the target.</param>
        /// <param name="speed">The maximum speed that the position can update at.</param>
        /// <param name="future">The predicted future position.</param>
        /// <returns>The calculated movement.</returns>
        public static Vector2 Evade([NotNull] this Transform position, [NotNull] Component target, Vector3 previous, float speed, out Vector2 future) => position.Flatten().Evade(target, previous, speed, Time.deltaTime, out future);
        
        /// <summary>
        /// Calculate a evade behaviour.
        /// </summary>
        /// <param name="position">The current position of the instance to calculate the movement for.</param>
        /// <param name="target">The target to move in relation to.</param>
        /// <param name="previous">The previous position of the target.</param>
        /// <param name="speed">The maximum speed that the position can update at.</param>
        /// <param name="delta">The time since the last recorded position.</param>
        /// <param name="future">The predicted future position.</param>
        /// <returns>The calculated movement.</returns>
        public static Vector2 Evade([NotNull] this Transform position, [NotNull] Component target, [NotNull] Transform previous, float speed, float delta, out Vector2 future) => position.Flatten().Evade(target, previous, speed, delta, out future);
        
        /// <summary>
        /// Calculate a evade behaviour.
        /// </summary>
        /// <param name="position">The current position of the instance to calculate the movement for.</param>
        /// <param name="target">The target to move in relation to.</param>
        /// <param name="previous">The previous position of the target.</param>
        /// <param name="speed">The maximum speed that the position can update at.</param>
        /// <param name="future">The predicted future position.</param>
        /// <returns>The calculated movement.</returns>
        public static Vector2 Evade([NotNull] this Transform position, [NotNull] Component target, [NotNull] Transform previous, float speed, out Vector2 future) => position.Flatten().Evade(target, previous, speed, Time.deltaTime, out future);
        
        /// <summary>
        /// Calculate a evade behaviour.
        /// </summary>
        /// <param name="position">The current position of the instance to calculate the movement for.</param>
        /// <param name="target">The target to move in relation to.</param>
        /// <param name="previous">The previous position of the target.</param>
        /// <param name="speed">The maximum speed that the position can update at.</param>
        /// <param name="delta">The time since the last recorded position.</param>
        /// <param name="future">The predicted future position.</param>
        /// <returns>The calculated movement.</returns>
        public static Vector2 Evade([NotNull] this Transform position, [NotNull] Component target, [NotNull] Component previous, float speed, float delta, out Vector2 future) => position.Flatten().Evade(target, previous, speed, delta, out future);
        
        /// <summary>
        /// Calculate a evade behaviour.
        /// </summary>
        /// <param name="position">The current position of the instance to calculate the movement for.</param>
        /// <param name="target">The target to move in relation to.</param>
        /// <param name="previous">The previous position of the target.</param>
        /// <param name="speed">The maximum speed that the position can update at.</param>
        /// <param name="future">The predicted future position.</param>
        /// <returns>The calculated movement.</returns>
        public static Vector2 Evade([NotNull] this Transform position, [NotNull] Component target, [NotNull] Component previous, float speed, out Vector2 future) => position.Flatten().Evade(target, previous, speed, Time.deltaTime, out future);
        
        /// <summary>
        /// Calculate a evade behaviour.
        /// </summary>
        /// <param name="position">The current position of the instance to calculate the movement for.</param>
        /// <param name="target">The target to move in relation to.</param>
        /// <param name="previous">The previous position of the target.</param>
        /// <param name="speed">The maximum speed that the position can update at.</param>
        /// <param name="delta">The time since the last recorded position.</param>
        /// <param name="future">The predicted future position.</param>
        /// <returns>The calculated movement.</returns>
        public static Vector2 Evade([NotNull] this Transform position, [NotNull] Component target, [NotNull] GameObject previous, float speed, float delta, out Vector2 future) => position.Flatten().Evade(target, previous, speed, delta, out future);
        
        /// <summary>
        /// Calculate a evade behaviour.
        /// </summary>
        /// <param name="position">The current position of the instance to calculate the movement for.</param>
        /// <param name="target">The target to move in relation to.</param>
        /// <param name="previous">The previous position of the target.</param>
        /// <param name="speed">The maximum speed that the position can update at.</param>
        /// <param name="future">The predicted future position.</param>
        /// <returns>The calculated movement.</returns>
        public static Vector2 Evade([NotNull] this Transform position, [NotNull] Component target, [NotNull] GameObject previous, float speed, out Vector2 future) => position.Flatten().Evade(target, previous, speed, Time.deltaTime, out future);
        
        /// <summary>
        /// Calculate a evade behaviour.
        /// </summary>
        /// <param name="position">The current position of the instance to calculate the movement for.</param>
        /// <param name="target">The target to move in relation to.</param>
        /// <param name="previous">The previous position of the target.</param>
        /// <param name="speed">The maximum speed that the position can update at.</param>
        /// <param name="delta">The time since the last recorded position.</param>
        /// <param name="future">The predicted future position.</param>
        /// <returns>The calculated movement.</returns>
        public static Vector2 Evade([NotNull] this Transform position, [NotNull] GameObject target, Vector2 previous, float speed, float delta, out Vector2 future) => position.Flatten().Evade(target, previous, speed, delta, out future);
        
        /// <summary>
        /// Calculate a evade behaviour.
        /// </summary>
        /// <param name="position">The current position of the instance to calculate the movement for.</param>
        /// <param name="target">The target to move in relation to.</param>
        /// <param name="previous">The previous position of the target.</param>
        /// <param name="speed">The maximum speed that the position can update at.</param>
        /// <param name="future">The predicted future position.</param>
        /// <returns>The calculated movement.</returns>
        public static Vector2 Evade([NotNull] this Transform position, [NotNull] GameObject target, Vector2 previous, float speed, out Vector2 future) => position.Flatten().Evade(target, previous, speed, Time.deltaTime, out future);
        
        /// <summary>
        /// Calculate a evade behaviour.
        /// </summary>
        /// <param name="position">The current position of the instance to calculate the movement for.</param>
        /// <param name="target">The target to move in relation to.</param>
        /// <param name="previous">The previous position of the target.</param>
        /// <param name="speed">The maximum speed that the position can update at.</param>
        /// <param name="delta">The time since the last recorded position.</param>
        /// <param name="future">The predicted future position.</param>
        /// <returns>The calculated movement.</returns>
        public static Vector2 Evade([NotNull] this Transform position, [NotNull] GameObject target, Vector3 previous, float speed, float delta, out Vector2 future) => position.Flatten().Evade(target, previous, speed, delta, out future);
        
        /// <summary>
        /// Calculate a evade behaviour.
        /// </summary>
        /// <param name="position">The current position of the instance to calculate the movement for.</param>
        /// <param name="target">The target to move in relation to.</param>
        /// <param name="previous">The previous position of the target.</param>
        /// <param name="speed">The maximum speed that the position can update at.</param>
        /// <param name="future">The predicted future position.</param>
        /// <returns>The calculated movement.</returns>
        public static Vector2 Evade([NotNull] this Transform position, [NotNull] GameObject target, Vector3 previous, float speed, out Vector2 future) => position.Flatten().Evade(target, previous, speed, Time.deltaTime, out future);
        
        /// <summary>
        /// Calculate a evade behaviour.
        /// </summary>
        /// <param name="position">The current position of the instance to calculate the movement for.</param>
        /// <param name="target">The target to move in relation to.</param>
        /// <param name="previous">The previous position of the target.</param>
        /// <param name="speed">The maximum speed that the position can update at.</param>
        /// <param name="delta">The time since the last recorded position.</param>
        /// <param name="future">The predicted future position.</param>
        /// <returns>The calculated movement.</returns>
        public static Vector2 Evade([NotNull] this Transform position, [NotNull] GameObject target, [NotNull] Transform previous, float speed, float delta, out Vector2 future) => position.Flatten().Evade(target, previous, speed, delta, out future);
        
        /// <summary>
        /// Calculate a evade behaviour.
        /// </summary>
        /// <param name="position">The current position of the instance to calculate the movement for.</param>
        /// <param name="target">The target to move in relation to.</param>
        /// <param name="previous">The previous position of the target.</param>
        /// <param name="speed">The maximum speed that the position can update at.</param>
        /// <param name="future">The predicted future position.</param>
        /// <returns>The calculated movement.</returns>
        public static Vector2 Evade([NotNull] this Transform position, [NotNull] GameObject target, [NotNull] Transform previous, float speed, out Vector2 future) => position.Flatten().Evade(target, previous, speed, Time.deltaTime, out future);
        
        /// <summary>
        /// Calculate a evade behaviour.
        /// </summary>
        /// <param name="position">The current position of the instance to calculate the movement for.</param>
        /// <param name="target">The target to move in relation to.</param>
        /// <param name="previous">The previous position of the target.</param>
        /// <param name="speed">The maximum speed that the position can update at.</param>
        /// <param name="delta">The time since the last recorded position.</param>
        /// <param name="future">The predicted future position.</param>
        /// <returns>The calculated movement.</returns>
        public static Vector2 Evade([NotNull] this Transform position, [NotNull] GameObject target, [NotNull] Component previous, float speed, float delta, out Vector2 future) => position.Flatten().Evade(target, previous, speed, delta, out future);
        
        /// <summary>
        /// Calculate a evade behaviour.
        /// </summary>
        /// <param name="position">The current position of the instance to calculate the movement for.</param>
        /// <param name="target">The target to move in relation to.</param>
        /// <param name="previous">The previous position of the target.</param>
        /// <param name="speed">The maximum speed that the position can update at.</param>
        /// <param name="future">The predicted future position.</param>
        /// <returns>The calculated movement.</returns>
        public static Vector2 Evade([NotNull] this Transform position, [NotNull] GameObject target, [NotNull] Component previous, float speed, out Vector2 future) => position.Flatten().Evade(target, previous, speed, Time.deltaTime, out future);
        
        /// <summary>
        /// Calculate a evade behaviour.
        /// </summary>
        /// <param name="position">The current position of the instance to calculate the movement for.</param>
        /// <param name="target">The target to move in relation to.</param>
        /// <param name="previous">The previous position of the target.</param>
        /// <param name="speed">The maximum speed that the position can update at.</param>
        /// <param name="delta">The time since the last recorded position.</param>
        /// <param name="future">The predicted future position.</param>
        /// <returns>The calculated movement.</returns>
        public static Vector2 Evade([NotNull] this Transform position, [NotNull] GameObject target, [NotNull] GameObject previous, float speed, float delta, out Vector2 future) => position.Flatten().Evade(target, previous, speed, delta, out future);
        
        /// <summary>
        /// Calculate a evade behaviour.
        /// </summary>
        /// <param name="position">The current position of the instance to calculate the movement for.</param>
        /// <param name="target">The target to move in relation to.</param>
        /// <param name="previous">The previous position of the target.</param>
        /// <param name="speed">The maximum speed that the position can update at.</param>
        /// <param name="future">The predicted future position.</param>
        /// <returns>The calculated movement.</returns>
        public static Vector2 Evade([NotNull] this Transform position, [NotNull] GameObject target, [NotNull] GameObject previous, float speed, out Vector2 future) => position.Flatten().Evade(target, previous, speed, Time.deltaTime, out future);
        
        /// <summary>
        /// Calculate a evade behaviour.
        /// </summary>
        /// <param name="position">The current position of the instance to calculate the movement for.</param>
        /// <param name="target">The target to move in relation to.</param>
        /// <param name="previous">The previous position of the target.</param>
        /// <param name="speed">The maximum speed that the position can update at.</param>
        /// <param name="delta">The time since the last recorded position.</param>
        /// <param name="future">The predicted future position.</param>
        /// <returns>The calculated movement.</returns>
        public static Vector2 Evade([NotNull] this Component position, Vector2 target, Vector2 previous, float speed, float delta, out Vector2 future) => position.Flatten().Evade(target, previous, speed, delta, out future);
        
        /// <summary>
        /// Calculate a evade behaviour.
        /// </summary>
        /// <param name="position">The current position of the instance to calculate the movement for.</param>
        /// <param name="target">The target to move in relation to.</param>
        /// <param name="previous">The previous position of the target.</param>
        /// <param name="speed">The maximum speed that the position can update at.</param>
        /// <param name="future">The predicted future position.</param>
        /// <returns>The calculated movement.</returns>
        public static Vector2 Evade([NotNull] this Component position, Vector2 target, Vector2 previous, float speed, out Vector2 future) => position.Flatten().Evade(target, previous, speed, Time.deltaTime, out future);
        
        /// <summary>
        /// Calculate a evade behaviour.
        /// </summary>
        /// <param name="position">The current position of the instance to calculate the movement for.</param>
        /// <param name="target">The target to move in relation to.</param>
        /// <param name="previous">The previous position of the target.</param>
        /// <param name="speed">The maximum speed that the position can update at.</param>
        /// <param name="delta">The time since the last recorded position.</param>
        /// <param name="future">The predicted future position.</param>
        /// <returns>The calculated movement.</returns>
        public static Vector2 Evade([NotNull] this Component position, Vector2 target, Vector3 previous, float speed, float delta, out Vector2 future) => position.Flatten().Evade(target, previous, speed, delta, out future);
        
        /// <summary>
        /// Calculate a evade behaviour.
        /// </summary>
        /// <param name="position">The current position of the instance to calculate the movement for.</param>
        /// <param name="target">The target to move in relation to.</param>
        /// <param name="previous">The previous position of the target.</param>
        /// <param name="speed">The maximum speed that the position can update at.</param>
        /// <param name="future">The predicted future position.</param>
        /// <returns>The calculated movement.</returns>
        public static Vector2 Evade([NotNull] this Component position, Vector2 target, Vector3 previous, float speed, out Vector2 future) => position.Flatten().Evade(target, previous, speed, Time.deltaTime, out future);
        
        /// <summary>
        /// Calculate a evade behaviour.
        /// </summary>
        /// <param name="position">The current position of the instance to calculate the movement for.</param>
        /// <param name="target">The target to move in relation to.</param>
        /// <param name="previous">The previous position of the target.</param>
        /// <param name="speed">The maximum speed that the position can update at.</param>
        /// <param name="delta">The time since the last recorded position.</param>
        /// <param name="future">The predicted future position.</param>
        /// <returns>The calculated movement.</returns>
        public static Vector2 Evade([NotNull] this Component position, Vector2 target, [NotNull] Transform previous, float speed, float delta, out Vector2 future) => position.Flatten().Evade(target, previous, speed, delta, out future);
        
        /// <summary>
        /// Calculate a evade behaviour.
        /// </summary>
        /// <param name="position">The current position of the instance to calculate the movement for.</param>
        /// <param name="target">The target to move in relation to.</param>
        /// <param name="previous">The previous position of the target.</param>
        /// <param name="speed">The maximum speed that the position can update at.</param>
        /// <param name="future">The predicted future position.</param>
        /// <returns>The calculated movement.</returns>
        public static Vector2 Evade([NotNull] this Component position, Vector2 target, [NotNull] Transform previous, float speed, out Vector2 future) => position.Flatten().Evade(target, previous, speed, Time.deltaTime, out future);
        
        /// <summary>
        /// Calculate a evade behaviour.
        /// </summary>
        /// <param name="position">The current position of the instance to calculate the movement for.</param>
        /// <param name="target">The target to move in relation to.</param>
        /// <param name="previous">The previous position of the target.</param>
        /// <param name="speed">The maximum speed that the position can update at.</param>
        /// <param name="delta">The time since the last recorded position.</param>
        /// <param name="future">The predicted future position.</param>
        /// <returns>The calculated movement.</returns>
        public static Vector2 Evade([NotNull] this Component position, Vector2 target, [NotNull] Component previous, float speed, float delta, out Vector2 future) => position.Flatten().Evade(target, previous, speed, delta, out future);
        
        /// <summary>
        /// Calculate a evade behaviour.
        /// </summary>
        /// <param name="position">The current position of the instance to calculate the movement for.</param>
        /// <param name="target">The target to move in relation to.</param>
        /// <param name="previous">The previous position of the target.</param>
        /// <param name="speed">The maximum speed that the position can update at.</param>
        /// <param name="future">The predicted future position.</param>
        /// <returns>The calculated movement.</returns>
        public static Vector2 Evade([NotNull] this Component position, Vector2 target, [NotNull] Component previous, float speed, out Vector2 future) => position.Flatten().Evade(target, previous, speed, Time.deltaTime, out future);
        
        /// <summary>
        /// Calculate a evade behaviour.
        /// </summary>
        /// <param name="position">The current position of the instance to calculate the movement for.</param>
        /// <param name="target">The target to move in relation to.</param>
        /// <param name="previous">The previous position of the target.</param>
        /// <param name="speed">The maximum speed that the position can update at.</param>
        /// <param name="delta">The time since the last recorded position.</param>
        /// <param name="future">The predicted future position.</param>
        /// <returns>The calculated movement.</returns>
        public static Vector2 Evade([NotNull] this Component position, Vector2 target, [NotNull] GameObject previous, float speed, float delta, out Vector2 future) => position.Flatten().Evade(target, previous, speed, delta, out future);
        
        /// <summary>
        /// Calculate a evade behaviour.
        /// </summary>
        /// <param name="position">The current position of the instance to calculate the movement for.</param>
        /// <param name="target">The target to move in relation to.</param>
        /// <param name="previous">The previous position of the target.</param>
        /// <param name="speed">The maximum speed that the position can update at.</param>
        /// <param name="future">The predicted future position.</param>
        /// <returns>The calculated movement.</returns>
        public static Vector2 Evade([NotNull] this Component position, Vector2 target, [NotNull] GameObject previous, float speed, out Vector2 future) => position.Flatten().Evade(target, previous, speed, Time.deltaTime, out future);
        
        /// <summary>
        /// Calculate a evade behaviour.
        /// </summary>
        /// <param name="position">The current position of the instance to calculate the movement for.</param>
        /// <param name="target">The target to move in relation to.</param>
        /// <param name="previous">The previous position of the target.</param>
        /// <param name="speed">The maximum speed that the position can update at.</param>
        /// <param name="delta">The time since the last recorded position.</param>
        /// <param name="future">The predicted future position.</param>
        /// <returns>The calculated movement.</returns>
        public static Vector2 Evade([NotNull] this Component position, Vector3 target, Vector2 previous, float speed, float delta, out Vector2 future) => position.Flatten().Evade(target, previous, speed, delta, out future);
        
        /// <summary>
        /// Calculate a evade behaviour.
        /// </summary>
        /// <param name="position">The current position of the instance to calculate the movement for.</param>
        /// <param name="target">The target to move in relation to.</param>
        /// <param name="previous">The previous position of the target.</param>
        /// <param name="speed">The maximum speed that the position can update at.</param>
        /// <param name="future">The predicted future position.</param>
        /// <returns>The calculated movement.</returns>
        public static Vector2 Evade([NotNull] this Component position, Vector3 target, Vector2 previous, float speed, out Vector2 future) => position.Flatten().Evade(target, previous, speed, Time.deltaTime, out future);
        
        /// <summary>
        /// Calculate a evade behaviour.
        /// </summary>
        /// <param name="position">The current position of the instance to calculate the movement for.</param>
        /// <param name="target">The target to move in relation to.</param>
        /// <param name="previous">The previous position of the target.</param>
        /// <param name="speed">The maximum speed that the position can update at.</param>
        /// <param name="delta">The time since the last recorded position.</param>
        /// <param name="future">The predicted future position.</param>
        /// <returns>The calculated movement.</returns>
        public static Vector2 Evade([NotNull] this Component position, Vector3 target, Vector3 previous, float speed, float delta, out Vector2 future) => position.Flatten().Evade(target, previous, speed, delta, out future);
        
        /// <summary>
        /// Calculate a evade behaviour.
        /// </summary>
        /// <param name="position">The current position of the instance to calculate the movement for.</param>
        /// <param name="target">The target to move in relation to.</param>
        /// <param name="previous">The previous position of the target.</param>
        /// <param name="speed">The maximum speed that the position can update at.</param>
        /// <param name="future">The predicted future position.</param>
        /// <returns>The calculated movement.</returns>
        public static Vector2 Evade([NotNull] this Component position, Vector3 target, Vector3 previous, float speed, out Vector2 future) => position.Flatten().Evade(target, previous, speed, Time.deltaTime, out future);
        
        /// <summary>
        /// Calculate a evade behaviour.
        /// </summary>
        /// <param name="position">The current position of the instance to calculate the movement for.</param>
        /// <param name="target">The target to move in relation to.</param>
        /// <param name="previous">The previous position of the target.</param>
        /// <param name="speed">The maximum speed that the position can update at.</param>
        /// <param name="delta">The time since the last recorded position.</param>
        /// <param name="future">The predicted future position.</param>
        /// <returns>The calculated movement.</returns>
        public static Vector2 Evade([NotNull] this Component position, Vector3 target, [NotNull] Transform previous, float speed, float delta, out Vector2 future) => position.Flatten().Evade(target, previous, speed, delta, out future);
        
        /// <summary>
        /// Calculate a evade behaviour.
        /// </summary>
        /// <param name="position">The current position of the instance to calculate the movement for.</param>
        /// <param name="target">The target to move in relation to.</param>
        /// <param name="previous">The previous position of the target.</param>
        /// <param name="speed">The maximum speed that the position can update at.</param>
        /// <param name="future">The predicted future position.</param>
        /// <returns>The calculated movement.</returns>
        public static Vector2 Evade([NotNull] this Component position, Vector3 target, [NotNull] Transform previous, float speed, out Vector2 future) => position.Flatten().Evade(target, previous, speed, Time.deltaTime, out future);
        
        /// <summary>
        /// Calculate a evade behaviour.
        /// </summary>
        /// <param name="position">The current position of the instance to calculate the movement for.</param>
        /// <param name="target">The target to move in relation to.</param>
        /// <param name="previous">The previous position of the target.</param>
        /// <param name="speed">The maximum speed that the position can update at.</param>
        /// <param name="delta">The time since the last recorded position.</param>
        /// <param name="future">The predicted future position.</param>
        /// <returns>The calculated movement.</returns>
        public static Vector2 Evade([NotNull] this Component position, Vector3 target, [NotNull] Component previous, float speed, float delta, out Vector2 future) => position.Flatten().Evade(target, previous, speed, delta, out future);
        
        /// <summary>
        /// Calculate a evade behaviour.
        /// </summary>
        /// <param name="position">The current position of the instance to calculate the movement for.</param>
        /// <param name="target">The target to move in relation to.</param>
        /// <param name="previous">The previous position of the target.</param>
        /// <param name="speed">The maximum speed that the position can update at.</param>
        /// <param name="future">The predicted future position.</param>
        /// <returns>The calculated movement.</returns>
        public static Vector2 Evade([NotNull] this Component position, Vector3 target, [NotNull] Component previous, float speed, out Vector2 future) => position.Flatten().Evade(target, previous, speed, Time.deltaTime, out future);
        
        /// <summary>
        /// Calculate a evade behaviour.
        /// </summary>
        /// <param name="position">The current position of the instance to calculate the movement for.</param>
        /// <param name="target">The target to move in relation to.</param>
        /// <param name="previous">The previous position of the target.</param>
        /// <param name="speed">The maximum speed that the position can update at.</param>
        /// <param name="delta">The time since the last recorded position.</param>
        /// <param name="future">The predicted future position.</param>
        /// <returns>The calculated movement.</returns>
        public static Vector2 Evade([NotNull] this Component position, Vector3 target, [NotNull] GameObject previous, float speed, float delta, out Vector2 future) => position.Flatten().Evade(target, previous, speed, delta, out future);
        
        /// <summary>
        /// Calculate a evade behaviour.
        /// </summary>
        /// <param name="position">The current position of the instance to calculate the movement for.</param>
        /// <param name="target">The target to move in relation to.</param>
        /// <param name="previous">The previous position of the target.</param>
        /// <param name="speed">The maximum speed that the position can update at.</param>
        /// <param name="future">The predicted future position.</param>
        /// <returns>The calculated movement.</returns>
        public static Vector2 Evade([NotNull] this Component position, Vector3 target, [NotNull] GameObject previous, float speed, out Vector2 future) => position.Flatten().Evade(target, previous, speed, Time.deltaTime, out future);
        
        /// <summary>
        /// Calculate a evade behaviour.
        /// </summary>
        /// <param name="position">The current position of the instance to calculate the movement for.</param>
        /// <param name="target">The target to move in relation to.</param>
        /// <param name="previous">The previous position of the target.</param>
        /// <param name="speed">The maximum speed that the position can update at.</param>
        /// <param name="delta">The time since the last recorded position.</param>
        /// <param name="future">The predicted future position.</param>
        /// <returns>The calculated movement.</returns>
        public static Vector2 Evade([NotNull] this Component position, [NotNull] Transform target, Vector2 previous, float speed, float delta, out Vector2 future) => position.Flatten().Evade(target, previous, speed, delta, out future);
        
        /// <summary>
        /// Calculate a evade behaviour.
        /// </summary>
        /// <param name="position">The current position of the instance to calculate the movement for.</param>
        /// <param name="target">The target to move in relation to.</param>
        /// <param name="previous">The previous position of the target.</param>
        /// <param name="speed">The maximum speed that the position can update at.</param>
        /// <param name="future">The predicted future position.</param>
        /// <returns>The calculated movement.</returns>
        public static Vector2 Evade([NotNull] this Component position, [NotNull] Transform target, Vector2 previous, float speed, out Vector2 future) => position.Flatten().Evade(target, previous, speed, Time.deltaTime, out future);
        
        /// <summary>
        /// Calculate a evade behaviour.
        /// </summary>
        /// <param name="position">The current position of the instance to calculate the movement for.</param>
        /// <param name="target">The target to move in relation to.</param>
        /// <param name="previous">The previous position of the target.</param>
        /// <param name="speed">The maximum speed that the position can update at.</param>
        /// <param name="delta">The time since the last recorded position.</param>
        /// <param name="future">The predicted future position.</param>
        /// <returns>The calculated movement.</returns>
        public static Vector2 Evade([NotNull] this Component position, [NotNull] Transform target, Vector3 previous, float speed, float delta, out Vector2 future) => position.Flatten().Evade(target, previous, speed, delta, out future);
        
        /// <summary>
        /// Calculate a evade behaviour.
        /// </summary>
        /// <param name="position">The current position of the instance to calculate the movement for.</param>
        /// <param name="target">The target to move in relation to.</param>
        /// <param name="previous">The previous position of the target.</param>
        /// <param name="speed">The maximum speed that the position can update at.</param>
        /// <param name="future">The predicted future position.</param>
        /// <returns>The calculated movement.</returns>
        public static Vector2 Evade([NotNull] this Component position, [NotNull] Transform target, Vector3 previous, float speed, out Vector2 future) => position.Flatten().Evade(target, previous, speed, Time.deltaTime, out future);
        
        /// <summary>
        /// Calculate a evade behaviour.
        /// </summary>
        /// <param name="position">The current position of the instance to calculate the movement for.</param>
        /// <param name="target">The target to move in relation to.</param>
        /// <param name="previous">The previous position of the target.</param>
        /// <param name="speed">The maximum speed that the position can update at.</param>
        /// <param name="delta">The time since the last recorded position.</param>
        /// <param name="future">The predicted future position.</param>
        /// <returns>The calculated movement.</returns>
        public static Vector2 Evade([NotNull] this Component position, [NotNull] Transform target, [NotNull] Transform previous, float speed, float delta, out Vector2 future) => position.Flatten().Evade(target, previous, speed, delta, out future);
        
        /// <summary>
        /// Calculate a evade behaviour.
        /// </summary>
        /// <param name="position">The current position of the instance to calculate the movement for.</param>
        /// <param name="target">The target to move in relation to.</param>
        /// <param name="previous">The previous position of the target.</param>
        /// <param name="speed">The maximum speed that the position can update at.</param>
        /// <param name="future">The predicted future position.</param>
        /// <returns>The calculated movement.</returns>
        public static Vector2 Evade([NotNull] this Component position, [NotNull] Transform target, [NotNull] Transform previous, float speed, out Vector2 future) => position.Flatten().Evade(target, previous, speed, Time.deltaTime, out future);
        
        /// <summary>
        /// Calculate a evade behaviour.
        /// </summary>
        /// <param name="position">The current position of the instance to calculate the movement for.</param>
        /// <param name="target">The target to move in relation to.</param>
        /// <param name="previous">The previous position of the target.</param>
        /// <param name="speed">The maximum speed that the position can update at.</param>
        /// <param name="delta">The time since the last recorded position.</param>
        /// <param name="future">The predicted future position.</param>
        /// <returns>The calculated movement.</returns>
        public static Vector2 Evade([NotNull] this Component position, [NotNull] Transform target, [NotNull] Component previous, float speed, float delta, out Vector2 future) => position.Flatten().Evade(target, previous, speed, delta, out future);
        
        /// <summary>
        /// Calculate a evade behaviour.
        /// </summary>
        /// <param name="position">The current position of the instance to calculate the movement for.</param>
        /// <param name="target">The target to move in relation to.</param>
        /// <param name="previous">The previous position of the target.</param>
        /// <param name="speed">The maximum speed that the position can update at.</param>
        /// <param name="future">The predicted future position.</param>
        /// <returns>The calculated movement.</returns>
        public static Vector2 Evade([NotNull] this Component position, [NotNull] Transform target, [NotNull] Component previous, float speed, out Vector2 future) => position.Flatten().Evade(target, previous, speed, Time.deltaTime, out future);
        
        /// <summary>
        /// Calculate a evade behaviour.
        /// </summary>
        /// <param name="position">The current position of the instance to calculate the movement for.</param>
        /// <param name="target">The target to move in relation to.</param>
        /// <param name="previous">The previous position of the target.</param>
        /// <param name="speed">The maximum speed that the position can update at.</param>
        /// <param name="delta">The time since the last recorded position.</param>
        /// <param name="future">The predicted future position.</param>
        /// <returns>The calculated movement.</returns>
        public static Vector2 Evade([NotNull] this Component position, [NotNull] Transform target, [NotNull] GameObject previous, float speed, float delta, out Vector2 future) => position.Flatten().Evade(target, previous, speed, delta, out future);
        
        /// <summary>
        /// Calculate a evade behaviour.
        /// </summary>
        /// <param name="position">The current position of the instance to calculate the movement for.</param>
        /// <param name="target">The target to move in relation to.</param>
        /// <param name="previous">The previous position of the target.</param>
        /// <param name="speed">The maximum speed that the position can update at.</param>
        /// <param name="future">The predicted future position.</param>
        /// <returns>The calculated movement.</returns>
        public static Vector2 Evade([NotNull] this Component position, [NotNull] Transform target, [NotNull] GameObject previous, float speed, out Vector2 future) => position.Flatten().Evade(target, previous, speed, Time.deltaTime, out future);
        
        /// <summary>
        /// Calculate a evade behaviour.
        /// </summary>
        /// <param name="position">The current position of the instance to calculate the movement for.</param>
        /// <param name="target">The target to move in relation to.</param>
        /// <param name="previous">The previous position of the target.</param>
        /// <param name="speed">The maximum speed that the position can update at.</param>
        /// <param name="delta">The time since the last recorded position.</param>
        /// <param name="future">The predicted future position.</param>
        /// <returns>The calculated movement.</returns>
        public static Vector2 Evade([NotNull] this Component position, [NotNull] Component target, Vector2 previous, float speed, float delta, out Vector2 future) => position.Flatten().Evade(target, previous, speed, delta, out future);
        
        /// <summary>
        /// Calculate a evade behaviour.
        /// </summary>
        /// <param name="position">The current position of the instance to calculate the movement for.</param>
        /// <param name="target">The target to move in relation to.</param>
        /// <param name="previous">The previous position of the target.</param>
        /// <param name="speed">The maximum speed that the position can update at.</param>
        /// <param name="future">The predicted future position.</param>
        /// <returns>The calculated movement.</returns>
        public static Vector2 Evade([NotNull] this Component position, [NotNull] Component target, Vector2 previous, float speed, out Vector2 future) => position.Flatten().Evade(target, previous, speed, Time.deltaTime, out future);
        
        /// <summary>
        /// Calculate a evade behaviour.
        /// </summary>
        /// <param name="position">The current position of the instance to calculate the movement for.</param>
        /// <param name="target">The target to move in relation to.</param>
        /// <param name="previous">The previous position of the target.</param>
        /// <param name="speed">The maximum speed that the position can update at.</param>
        /// <param name="delta">The time since the last recorded position.</param>
        /// <param name="future">The predicted future position.</param>
        /// <returns>The calculated movement.</returns>
        public static Vector2 Evade([NotNull] this Component position, [NotNull] Component target, Vector3 previous, float speed, float delta, out Vector2 future) => position.Flatten().Evade(target, previous, speed, delta, out future);
        
        /// <summary>
        /// Calculate a evade behaviour.
        /// </summary>
        /// <param name="position">The current position of the instance to calculate the movement for.</param>
        /// <param name="target">The target to move in relation to.</param>
        /// <param name="previous">The previous position of the target.</param>
        /// <param name="speed">The maximum speed that the position can update at.</param>
        /// <param name="future">The predicted future position.</param>
        /// <returns>The calculated movement.</returns>
        public static Vector2 Evade([NotNull] this Component position, [NotNull] Component target, Vector3 previous, float speed, out Vector2 future) => position.Flatten().Evade(target, previous, speed, Time.deltaTime, out future);
        
        /// <summary>
        /// Calculate a evade behaviour.
        /// </summary>
        /// <param name="position">The current position of the instance to calculate the movement for.</param>
        /// <param name="target">The target to move in relation to.</param>
        /// <param name="previous">The previous position of the target.</param>
        /// <param name="speed">The maximum speed that the position can update at.</param>
        /// <param name="delta">The time since the last recorded position.</param>
        /// <param name="future">The predicted future position.</param>
        /// <returns>The calculated movement.</returns>
        public static Vector2 Evade([NotNull] this Component position, [NotNull] Component target, [NotNull] Transform previous, float speed, float delta, out Vector2 future) => position.Flatten().Evade(target, previous, speed, delta, out future);
        
        /// <summary>
        /// Calculate a evade behaviour.
        /// </summary>
        /// <param name="position">The current position of the instance to calculate the movement for.</param>
        /// <param name="target">The target to move in relation to.</param>
        /// <param name="previous">The previous position of the target.</param>
        /// <param name="speed">The maximum speed that the position can update at.</param>
        /// <param name="future">The predicted future position.</param>
        /// <returns>The calculated movement.</returns>
        public static Vector2 Evade([NotNull] this Component position, [NotNull] Component target, [NotNull] Transform previous, float speed, out Vector2 future) => position.Flatten().Evade(target, previous, speed, Time.deltaTime, out future);
        
        /// <summary>
        /// Calculate a evade behaviour.
        /// </summary>
        /// <param name="position">The current position of the instance to calculate the movement for.</param>
        /// <param name="target">The target to move in relation to.</param>
        /// <param name="previous">The previous position of the target.</param>
        /// <param name="speed">The maximum speed that the position can update at.</param>
        /// <param name="delta">The time since the last recorded position.</param>
        /// <param name="future">The predicted future position.</param>
        /// <returns>The calculated movement.</returns>
        public static Vector2 Evade([NotNull] this Component position, [NotNull] Component target, [NotNull] Component previous, float speed, float delta, out Vector2 future) => position.Flatten().Evade(target, previous, speed, delta, out future);
        
        /// <summary>
        /// Calculate a evade behaviour.
        /// </summary>
        /// <param name="position">The current position of the instance to calculate the movement for.</param>
        /// <param name="target">The target to move in relation to.</param>
        /// <param name="previous">The previous position of the target.</param>
        /// <param name="speed">The maximum speed that the position can update at.</param>
        /// <param name="future">The predicted future position.</param>
        /// <returns>The calculated movement.</returns>
        public static Vector2 Evade([NotNull] this Component position, [NotNull] Component target, [NotNull] Component previous, float speed, out Vector2 future) => position.Flatten().Evade(target, previous, speed, Time.deltaTime, out future);
        
        /// <summary>
        /// Calculate a evade behaviour.
        /// </summary>
        /// <param name="position">The current position of the instance to calculate the movement for.</param>
        /// <param name="target">The target to move in relation to.</param>
        /// <param name="previous">The previous position of the target.</param>
        /// <param name="speed">The maximum speed that the position can update at.</param>
        /// <param name="delta">The time since the last recorded position.</param>
        /// <param name="future">The predicted future position.</param>
        /// <returns>The calculated movement.</returns>
        public static Vector2 Evade([NotNull] this Component position, [NotNull] Component target, [NotNull] GameObject previous, float speed, float delta, out Vector2 future) => position.Flatten().Evade(target, previous, speed, delta, out future);
        
        /// <summary>
        /// Calculate a evade behaviour.
        /// </summary>
        /// <param name="position">The current position of the instance to calculate the movement for.</param>
        /// <param name="target">The target to move in relation to.</param>
        /// <param name="previous">The previous position of the target.</param>
        /// <param name="speed">The maximum speed that the position can update at.</param>
        /// <param name="future">The predicted future position.</param>
        /// <returns>The calculated movement.</returns>
        public static Vector2 Evade([NotNull] this Component position, [NotNull] Component target, [NotNull] GameObject previous, float speed, out Vector2 future) => position.Flatten().Evade(target, previous, speed, Time.deltaTime, out future);
        
        /// <summary>
        /// Calculate a evade behaviour.
        /// </summary>
        /// <param name="position">The current position of the instance to calculate the movement for.</param>
        /// <param name="target">The target to move in relation to.</param>
        /// <param name="previous">The previous position of the target.</param>
        /// <param name="speed">The maximum speed that the position can update at.</param>
        /// <param name="delta">The time since the last recorded position.</param>
        /// <param name="future">The predicted future position.</param>
        /// <returns>The calculated movement.</returns>
        public static Vector2 Evade([NotNull] this Component position, [NotNull] GameObject target, Vector2 previous, float speed, float delta, out Vector2 future) => position.Flatten().Evade(target, previous, speed, delta, out future);
        
        /// <summary>
        /// Calculate a evade behaviour.
        /// </summary>
        /// <param name="position">The current position of the instance to calculate the movement for.</param>
        /// <param name="target">The target to move in relation to.</param>
        /// <param name="previous">The previous position of the target.</param>
        /// <param name="speed">The maximum speed that the position can update at.</param>
        /// <param name="future">The predicted future position.</param>
        /// <returns>The calculated movement.</returns>
        public static Vector2 Evade([NotNull] this Component position, [NotNull] GameObject target, Vector2 previous, float speed, out Vector2 future) => position.Flatten().Evade(target, previous, speed, Time.deltaTime, out future);
        
        /// <summary>
        /// Calculate a evade behaviour.
        /// </summary>
        /// <param name="position">The current position of the instance to calculate the movement for.</param>
        /// <param name="target">The target to move in relation to.</param>
        /// <param name="previous">The previous position of the target.</param>
        /// <param name="speed">The maximum speed that the position can update at.</param>
        /// <param name="delta">The time since the last recorded position.</param>
        /// <param name="future">The predicted future position.</param>
        /// <returns>The calculated movement.</returns>
        public static Vector2 Evade([NotNull] this Component position, [NotNull] GameObject target, Vector3 previous, float speed, float delta, out Vector2 future) => position.Flatten().Evade(target, previous, speed, delta, out future);
        
        /// <summary>
        /// Calculate a evade behaviour.
        /// </summary>
        /// <param name="position">The current position of the instance to calculate the movement for.</param>
        /// <param name="target">The target to move in relation to.</param>
        /// <param name="previous">The previous position of the target.</param>
        /// <param name="speed">The maximum speed that the position can update at.</param>
        /// <param name="future">The predicted future position.</param>
        /// <returns>The calculated movement.</returns>
        public static Vector2 Evade([NotNull] this Component position, [NotNull] GameObject target, Vector3 previous, float speed, out Vector2 future) => position.Flatten().Evade(target, previous, speed, Time.deltaTime, out future);
        
        /// <summary>
        /// Calculate a evade behaviour.
        /// </summary>
        /// <param name="position">The current position of the instance to calculate the movement for.</param>
        /// <param name="target">The target to move in relation to.</param>
        /// <param name="previous">The previous position of the target.</param>
        /// <param name="speed">The maximum speed that the position can update at.</param>
        /// <param name="delta">The time since the last recorded position.</param>
        /// <param name="future">The predicted future position.</param>
        /// <returns>The calculated movement.</returns>
        public static Vector2 Evade([NotNull] this Component position, [NotNull] GameObject target, [NotNull] Transform previous, float speed, float delta, out Vector2 future) => position.Flatten().Evade(target, previous, speed, delta, out future);
        
        /// <summary>
        /// Calculate a evade behaviour.
        /// </summary>
        /// <param name="position">The current position of the instance to calculate the movement for.</param>
        /// <param name="target">The target to move in relation to.</param>
        /// <param name="previous">The previous position of the target.</param>
        /// <param name="speed">The maximum speed that the position can update at.</param>
        /// <param name="future">The predicted future position.</param>
        /// <returns>The calculated movement.</returns>
        public static Vector2 Evade([NotNull] this Component position, [NotNull] GameObject target, [NotNull] Transform previous, float speed, out Vector2 future) => position.Flatten().Evade(target, previous, speed, Time.deltaTime, out future);
        
        /// <summary>
        /// Calculate a evade behaviour.
        /// </summary>
        /// <param name="position">The current position of the instance to calculate the movement for.</param>
        /// <param name="target">The target to move in relation to.</param>
        /// <param name="previous">The previous position of the target.</param>
        /// <param name="speed">The maximum speed that the position can update at.</param>
        /// <param name="delta">The time since the last recorded position.</param>
        /// <param name="future">The predicted future position.</param>
        /// <returns>The calculated movement.</returns>
        public static Vector2 Evade([NotNull] this Component position, [NotNull] GameObject target, [NotNull] Component previous, float speed, float delta, out Vector2 future) => position.Flatten().Evade(target, previous, speed, delta, out future);
        
        /// <summary>
        /// Calculate a evade behaviour.
        /// </summary>
        /// <param name="position">The current position of the instance to calculate the movement for.</param>
        /// <param name="target">The target to move in relation to.</param>
        /// <param name="previous">The previous position of the target.</param>
        /// <param name="speed">The maximum speed that the position can update at.</param>
        /// <param name="future">The predicted future position.</param>
        /// <returns>The calculated movement.</returns>
        public static Vector2 Evade([NotNull] this Component position, [NotNull] GameObject target, [NotNull] Component previous, float speed, out Vector2 future) => position.Flatten().Evade(target, previous, speed, Time.deltaTime, out future);
        
        /// <summary>
        /// Calculate a evade behaviour.
        /// </summary>
        /// <param name="position">The current position of the instance to calculate the movement for.</param>
        /// <param name="target">The target to move in relation to.</param>
        /// <param name="previous">The previous position of the target.</param>
        /// <param name="speed">The maximum speed that the position can update at.</param>
        /// <param name="delta">The time since the last recorded position.</param>
        /// <param name="future">The predicted future position.</param>
        /// <returns>The calculated movement.</returns>
        public static Vector2 Evade([NotNull] this Component position, [NotNull] GameObject target, [NotNull] GameObject previous, float speed, float delta, out Vector2 future) => position.Flatten().Evade(target, previous, speed, delta, out future);
        
        /// <summary>
        /// Calculate a evade behaviour.
        /// </summary>
        /// <param name="position">The current position of the instance to calculate the movement for.</param>
        /// <param name="target">The target to move in relation to.</param>
        /// <param name="previous">The previous position of the target.</param>
        /// <param name="speed">The maximum speed that the position can update at.</param>
        /// <param name="future">The predicted future position.</param>
        /// <returns>The calculated movement.</returns>
        public static Vector2 Evade([NotNull] this Component position, [NotNull] GameObject target, [NotNull] GameObject previous, float speed, out Vector2 future) => position.Flatten().Evade(target, previous, speed, Time.deltaTime, out future);
        
        /// <summary>
        /// Calculate a evade behaviour.
        /// </summary>
        /// <param name="position">The current position of the instance to calculate the movement for.</param>
        /// <param name="target">The target to move in relation to.</param>
        /// <param name="previous">The previous position of the target.</param>
        /// <param name="speed">The maximum speed that the position can update at.</param>
        /// <param name="delta">The time since the last recorded position.</param>
        /// <param name="future">The predicted future position.</param>
        /// <returns>The calculated movement.</returns>
        public static Vector2 Evade([NotNull] this GameObject position, Vector2 target, Vector2 previous, float speed, float delta, out Vector2 future) => position.Flatten().Evade(target, previous, speed, delta, out future);
        
        /// <summary>
        /// Calculate a evade behaviour.
        /// </summary>
        /// <param name="position">The current position of the instance to calculate the movement for.</param>
        /// <param name="target">The target to move in relation to.</param>
        /// <param name="previous">The previous position of the target.</param>
        /// <param name="speed">The maximum speed that the position can update at.</param>
        /// <param name="future">The predicted future position.</param>
        /// <returns>The calculated movement.</returns>
        public static Vector2 Evade([NotNull] this GameObject position, Vector2 target, Vector2 previous, float speed, out Vector2 future) => position.Flatten().Evade(target, previous, speed, Time.deltaTime, out future);
        
        /// <summary>
        /// Calculate a evade behaviour.
        /// </summary>
        /// <param name="position">The current position of the instance to calculate the movement for.</param>
        /// <param name="target">The target to move in relation to.</param>
        /// <param name="previous">The previous position of the target.</param>
        /// <param name="speed">The maximum speed that the position can update at.</param>
        /// <param name="delta">The time since the last recorded position.</param>
        /// <param name="future">The predicted future position.</param>
        /// <returns>The calculated movement.</returns>
        public static Vector2 Evade([NotNull] this GameObject position, Vector2 target, Vector3 previous, float speed, float delta, out Vector2 future) => position.Flatten().Evade(target, previous, speed, delta, out future);
        
        /// <summary>
        /// Calculate a evade behaviour.
        /// </summary>
        /// <param name="position">The current position of the instance to calculate the movement for.</param>
        /// <param name="target">The target to move in relation to.</param>
        /// <param name="previous">The previous position of the target.</param>
        /// <param name="speed">The maximum speed that the position can update at.</param>
        /// <param name="future">The predicted future position.</param>
        /// <returns>The calculated movement.</returns>
        public static Vector2 Evade([NotNull] this GameObject position, Vector2 target, Vector3 previous, float speed, out Vector2 future) => position.Flatten().Evade(target, previous, speed, Time.deltaTime, out future);
        
        /// <summary>
        /// Calculate a evade behaviour.
        /// </summary>
        /// <param name="position">The current position of the instance to calculate the movement for.</param>
        /// <param name="target">The target to move in relation to.</param>
        /// <param name="previous">The previous position of the target.</param>
        /// <param name="speed">The maximum speed that the position can update at.</param>
        /// <param name="delta">The time since the last recorded position.</param>
        /// <param name="future">The predicted future position.</param>
        /// <returns>The calculated movement.</returns>
        public static Vector2 Evade([NotNull] this GameObject position, Vector2 target, [NotNull] Transform previous, float speed, float delta, out Vector2 future) => position.Flatten().Evade(target, previous, speed, delta, out future);
        
        /// <summary>
        /// Calculate a evade behaviour.
        /// </summary>
        /// <param name="position">The current position of the instance to calculate the movement for.</param>
        /// <param name="target">The target to move in relation to.</param>
        /// <param name="previous">The previous position of the target.</param>
        /// <param name="speed">The maximum speed that the position can update at.</param>
        /// <param name="future">The predicted future position.</param>
        /// <returns>The calculated movement.</returns>
        public static Vector2 Evade([NotNull] this GameObject position, Vector2 target, [NotNull] Transform previous, float speed, out Vector2 future) => position.Flatten().Evade(target, previous, speed, Time.deltaTime, out future);
        
        /// <summary>
        /// Calculate a evade behaviour.
        /// </summary>
        /// <param name="position">The current position of the instance to calculate the movement for.</param>
        /// <param name="target">The target to move in relation to.</param>
        /// <param name="previous">The previous position of the target.</param>
        /// <param name="speed">The maximum speed that the position can update at.</param>
        /// <param name="delta">The time since the last recorded position.</param>
        /// <param name="future">The predicted future position.</param>
        /// <returns>The calculated movement.</returns>
        public static Vector2 Evade([NotNull] this GameObject position, Vector2 target, [NotNull] Component previous, float speed, float delta, out Vector2 future) => position.Flatten().Evade(target, previous, speed, delta, out future);
        
        /// <summary>
        /// Calculate a evade behaviour.
        /// </summary>
        /// <param name="position">The current position of the instance to calculate the movement for.</param>
        /// <param name="target">The target to move in relation to.</param>
        /// <param name="previous">The previous position of the target.</param>
        /// <param name="speed">The maximum speed that the position can update at.</param>
        /// <param name="future">The predicted future position.</param>
        /// <returns>The calculated movement.</returns>
        public static Vector2 Evade([NotNull] this GameObject position, Vector2 target, [NotNull] Component previous, float speed, out Vector2 future) => position.Flatten().Evade(target, previous, speed, Time.deltaTime, out future);
        
        /// <summary>
        /// Calculate a evade behaviour.
        /// </summary>
        /// <param name="position">The current position of the instance to calculate the movement for.</param>
        /// <param name="target">The target to move in relation to.</param>
        /// <param name="previous">The previous position of the target.</param>
        /// <param name="speed">The maximum speed that the position can update at.</param>
        /// <param name="delta">The time since the last recorded position.</param>
        /// <param name="future">The predicted future position.</param>
        /// <returns>The calculated movement.</returns>
        public static Vector2 Evade([NotNull] this GameObject position, Vector2 target, [NotNull] GameObject previous, float speed, float delta, out Vector2 future) => position.Flatten().Evade(target, previous, speed, delta, out future);
        
        /// <summary>
        /// Calculate a evade behaviour.
        /// </summary>
        /// <param name="position">The current position of the instance to calculate the movement for.</param>
        /// <param name="target">The target to move in relation to.</param>
        /// <param name="previous">The previous position of the target.</param>
        /// <param name="speed">The maximum speed that the position can update at.</param>
        /// <param name="future">The predicted future position.</param>
        /// <returns>The calculated movement.</returns>
        public static Vector2 Evade([NotNull] this GameObject position, Vector2 target, [NotNull] GameObject previous, float speed, out Vector2 future) => position.Flatten().Evade(target, previous, speed, Time.deltaTime, out future);
        
        /// <summary>
        /// Calculate a evade behaviour.
        /// </summary>
        /// <param name="position">The current position of the instance to calculate the movement for.</param>
        /// <param name="target">The target to move in relation to.</param>
        /// <param name="previous">The previous position of the target.</param>
        /// <param name="speed">The maximum speed that the position can update at.</param>
        /// <param name="delta">The time since the last recorded position.</param>
        /// <param name="future">The predicted future position.</param>
        /// <returns>The calculated movement.</returns>
        public static Vector2 Evade([NotNull] this GameObject position, Vector3 target, Vector2 previous, float speed, float delta, out Vector2 future) => position.Flatten().Evade(target, previous, speed, delta, out future);
        
        /// <summary>
        /// Calculate a evade behaviour.
        /// </summary>
        /// <param name="position">The current position of the instance to calculate the movement for.</param>
        /// <param name="target">The target to move in relation to.</param>
        /// <param name="previous">The previous position of the target.</param>
        /// <param name="speed">The maximum speed that the position can update at.</param>
        /// <param name="future">The predicted future position.</param>
        /// <returns>The calculated movement.</returns>
        public static Vector2 Evade([NotNull] this GameObject position, Vector3 target, Vector2 previous, float speed, out Vector2 future) => position.Flatten().Evade(target, previous, speed, Time.deltaTime, out future);
        
        /// <summary>
        /// Calculate a evade behaviour.
        /// </summary>
        /// <param name="position">The current position of the instance to calculate the movement for.</param>
        /// <param name="target">The target to move in relation to.</param>
        /// <param name="previous">The previous position of the target.</param>
        /// <param name="speed">The maximum speed that the position can update at.</param>
        /// <param name="delta">The time since the last recorded position.</param>
        /// <param name="future">The predicted future position.</param>
        /// <returns>The calculated movement.</returns>
        public static Vector2 Evade([NotNull] this GameObject position, Vector3 target, Vector3 previous, float speed, float delta, out Vector2 future) => position.Flatten().Evade(target, previous, speed, delta, out future);
        
        /// <summary>
        /// Calculate a evade behaviour.
        /// </summary>
        /// <param name="position">The current position of the instance to calculate the movement for.</param>
        /// <param name="target">The target to move in relation to.</param>
        /// <param name="previous">The previous position of the target.</param>
        /// <param name="speed">The maximum speed that the position can update at.</param>
        /// <param name="future">The predicted future position.</param>
        /// <returns>The calculated movement.</returns>
        public static Vector2 Evade([NotNull] this GameObject position, Vector3 target, Vector3 previous, float speed, out Vector2 future) => position.Flatten().Evade(target, previous, speed, Time.deltaTime, out future);
        
        /// <summary>
        /// Calculate a evade behaviour.
        /// </summary>
        /// <param name="position">The current position of the instance to calculate the movement for.</param>
        /// <param name="target">The target to move in relation to.</param>
        /// <param name="previous">The previous position of the target.</param>
        /// <param name="speed">The maximum speed that the position can update at.</param>
        /// <param name="delta">The time since the last recorded position.</param>
        /// <param name="future">The predicted future position.</param>
        /// <returns>The calculated movement.</returns>
        public static Vector2 Evade([NotNull] this GameObject position, Vector3 target, [NotNull] Transform previous, float speed, float delta, out Vector2 future) => position.Flatten().Evade(target, previous, speed, delta, out future);
        
        /// <summary>
        /// Calculate a evade behaviour.
        /// </summary>
        /// <param name="position">The current position of the instance to calculate the movement for.</param>
        /// <param name="target">The target to move in relation to.</param>
        /// <param name="previous">The previous position of the target.</param>
        /// <param name="speed">The maximum speed that the position can update at.</param>
        /// <param name="future">The predicted future position.</param>
        /// <returns>The calculated movement.</returns>
        public static Vector2 Evade([NotNull] this GameObject position, Vector3 target, [NotNull] Transform previous, float speed, out Vector2 future) => position.Flatten().Evade(target, previous, speed, Time.deltaTime, out future);
        
        /// <summary>
        /// Calculate a evade behaviour.
        /// </summary>
        /// <param name="position">The current position of the instance to calculate the movement for.</param>
        /// <param name="target">The target to move in relation to.</param>
        /// <param name="previous">The previous position of the target.</param>
        /// <param name="speed">The maximum speed that the position can update at.</param>
        /// <param name="delta">The time since the last recorded position.</param>
        /// <param name="future">The predicted future position.</param>
        /// <returns>The calculated movement.</returns>
        public static Vector2 Evade([NotNull] this GameObject position, Vector3 target, [NotNull] Component previous, float speed, float delta, out Vector2 future) => position.Flatten().Evade(target, previous, speed, delta, out future);
        
        /// <summary>
        /// Calculate a evade behaviour.
        /// </summary>
        /// <param name="position">The current position of the instance to calculate the movement for.</param>
        /// <param name="target">The target to move in relation to.</param>
        /// <param name="previous">The previous position of the target.</param>
        /// <param name="speed">The maximum speed that the position can update at.</param>
        /// <param name="future">The predicted future position.</param>
        /// <returns>The calculated movement.</returns>
        public static Vector2 Evade([NotNull] this GameObject position, Vector3 target, [NotNull] Component previous, float speed, out Vector2 future) => position.Flatten().Evade(target, previous, speed, Time.deltaTime, out future);
        
        /// <summary>
        /// Calculate a evade behaviour.
        /// </summary>
        /// <param name="position">The current position of the instance to calculate the movement for.</param>
        /// <param name="target">The target to move in relation to.</param>
        /// <param name="previous">The previous position of the target.</param>
        /// <param name="speed">The maximum speed that the position can update at.</param>
        /// <param name="delta">The time since the last recorded position.</param>
        /// <param name="future">The predicted future position.</param>
        /// <returns>The calculated movement.</returns>
        public static Vector2 Evade([NotNull] this GameObject position, Vector3 target, [NotNull] GameObject previous, float speed, float delta, out Vector2 future) => position.Flatten().Evade(target, previous, speed, delta, out future);
        
        /// <summary>
        /// Calculate a evade behaviour.
        /// </summary>
        /// <param name="position">The current position of the instance to calculate the movement for.</param>
        /// <param name="target">The target to move in relation to.</param>
        /// <param name="previous">The previous position of the target.</param>
        /// <param name="speed">The maximum speed that the position can update at.</param>
        /// <param name="future">The predicted future position.</param>
        /// <returns>The calculated movement.</returns>
        public static Vector2 Evade([NotNull] this GameObject position, Vector3 target, [NotNull] GameObject previous, float speed, out Vector2 future) => position.Flatten().Evade(target, previous, speed, Time.deltaTime, out future);
        
        /// <summary>
        /// Calculate a evade behaviour.
        /// </summary>
        /// <param name="position">The current position of the instance to calculate the movement for.</param>
        /// <param name="target">The target to move in relation to.</param>
        /// <param name="previous">The previous position of the target.</param>
        /// <param name="speed">The maximum speed that the position can update at.</param>
        /// <param name="delta">The time since the last recorded position.</param>
        /// <param name="future">The predicted future position.</param>
        /// <returns>The calculated movement.</returns>
        public static Vector2 Evade([NotNull] this GameObject position, [NotNull] Transform target, Vector2 previous, float speed, float delta, out Vector2 future) => position.Flatten().Evade(target, previous, speed, delta, out future);
        
        /// <summary>
        /// Calculate a evade behaviour.
        /// </summary>
        /// <param name="position">The current position of the instance to calculate the movement for.</param>
        /// <param name="target">The target to move in relation to.</param>
        /// <param name="previous">The previous position of the target.</param>
        /// <param name="speed">The maximum speed that the position can update at.</param>
        /// <param name="future">The predicted future position.</param>
        /// <returns>The calculated movement.</returns>
        public static Vector2 Evade([NotNull] this GameObject position, [NotNull] Transform target, Vector2 previous, float speed, out Vector2 future) => position.Flatten().Evade(target, previous, speed, Time.deltaTime, out future);
        
        /// <summary>
        /// Calculate a evade behaviour.
        /// </summary>
        /// <param name="position">The current position of the instance to calculate the movement for.</param>
        /// <param name="target">The target to move in relation to.</param>
        /// <param name="previous">The previous position of the target.</param>
        /// <param name="speed">The maximum speed that the position can update at.</param>
        /// <param name="delta">The time since the last recorded position.</param>
        /// <param name="future">The predicted future position.</param>
        /// <returns>The calculated movement.</returns>
        public static Vector2 Evade([NotNull] this GameObject position, [NotNull] Transform target, Vector3 previous, float speed, float delta, out Vector2 future) => position.Flatten().Evade(target, previous, speed, delta, out future);
        
        /// <summary>
        /// Calculate a evade behaviour.
        /// </summary>
        /// <param name="position">The current position of the instance to calculate the movement for.</param>
        /// <param name="target">The target to move in relation to.</param>
        /// <param name="previous">The previous position of the target.</param>
        /// <param name="speed">The maximum speed that the position can update at.</param>
        /// <param name="future">The predicted future position.</param>
        /// <returns>The calculated movement.</returns>
        public static Vector2 Evade([NotNull] this GameObject position, [NotNull] Transform target, Vector3 previous, float speed, out Vector2 future) => position.Flatten().Evade(target, previous, speed, Time.deltaTime, out future);
        
        /// <summary>
        /// Calculate a evade behaviour.
        /// </summary>
        /// <param name="position">The current position of the instance to calculate the movement for.</param>
        /// <param name="target">The target to move in relation to.</param>
        /// <param name="previous">The previous position of the target.</param>
        /// <param name="speed">The maximum speed that the position can update at.</param>
        /// <param name="delta">The time since the last recorded position.</param>
        /// <param name="future">The predicted future position.</param>
        /// <returns>The calculated movement.</returns>
        public static Vector2 Evade([NotNull] this GameObject position, [NotNull] Transform target, [NotNull] Transform previous, float speed, float delta, out Vector2 future) => position.Flatten().Evade(target, previous, speed, delta, out future);
        
        /// <summary>
        /// Calculate a evade behaviour.
        /// </summary>
        /// <param name="position">The current position of the instance to calculate the movement for.</param>
        /// <param name="target">The target to move in relation to.</param>
        /// <param name="previous">The previous position of the target.</param>
        /// <param name="speed">The maximum speed that the position can update at.</param>
        /// <param name="future">The predicted future position.</param>
        /// <returns>The calculated movement.</returns>
        public static Vector2 Evade([NotNull] this GameObject position, [NotNull] Transform target, [NotNull] Transform previous, float speed, out Vector2 future) => position.Flatten().Evade(target, previous, speed, Time.deltaTime, out future);
        
        /// <summary>
        /// Calculate a evade behaviour.
        /// </summary>
        /// <param name="position">The current position of the instance to calculate the movement for.</param>
        /// <param name="target">The target to move in relation to.</param>
        /// <param name="previous">The previous position of the target.</param>
        /// <param name="speed">The maximum speed that the position can update at.</param>
        /// <param name="delta">The time since the last recorded position.</param>
        /// <param name="future">The predicted future position.</param>
        /// <returns>The calculated movement.</returns>
        public static Vector2 Evade([NotNull] this GameObject position, [NotNull] Transform target, [NotNull] Component previous, float speed, float delta, out Vector2 future) => position.Flatten().Evade(target, previous, speed, delta, out future);
        
        /// <summary>
        /// Calculate a evade behaviour.
        /// </summary>
        /// <param name="position">The current position of the instance to calculate the movement for.</param>
        /// <param name="target">The target to move in relation to.</param>
        /// <param name="previous">The previous position of the target.</param>
        /// <param name="speed">The maximum speed that the position can update at.</param>
        /// <param name="future">The predicted future position.</param>
        /// <returns>The calculated movement.</returns>
        public static Vector2 Evade([NotNull] this GameObject position, [NotNull] Transform target, [NotNull] Component previous, float speed, out Vector2 future) => position.Flatten().Evade(target, previous, speed, Time.deltaTime, out future);
        
        /// <summary>
        /// Calculate a evade behaviour.
        /// </summary>
        /// <param name="position">The current position of the instance to calculate the movement for.</param>
        /// <param name="target">The target to move in relation to.</param>
        /// <param name="previous">The previous position of the target.</param>
        /// <param name="speed">The maximum speed that the position can update at.</param>
        /// <param name="delta">The time since the last recorded position.</param>
        /// <param name="future">The predicted future position.</param>
        /// <returns>The calculated movement.</returns>
        public static Vector2 Evade([NotNull] this GameObject position, [NotNull] Transform target, [NotNull] GameObject previous, float speed, float delta, out Vector2 future) => position.Flatten().Evade(target, previous, speed, delta, out future);
        
        /// <summary>
        /// Calculate a evade behaviour.
        /// </summary>
        /// <param name="position">The current position of the instance to calculate the movement for.</param>
        /// <param name="target">The target to move in relation to.</param>
        /// <param name="previous">The previous position of the target.</param>
        /// <param name="speed">The maximum speed that the position can update at.</param>
        /// <param name="future">The predicted future position.</param>
        /// <returns>The calculated movement.</returns>
        public static Vector2 Evade([NotNull] this GameObject position, [NotNull] Transform target, [NotNull] GameObject previous, float speed, out Vector2 future) => position.Flatten().Evade(target, previous, speed, Time.deltaTime, out future);
        
        /// <summary>
        /// Calculate a evade behaviour.
        /// </summary>
        /// <param name="position">The current position of the instance to calculate the movement for.</param>
        /// <param name="target">The target to move in relation to.</param>
        /// <param name="previous">The previous position of the target.</param>
        /// <param name="speed">The maximum speed that the position can update at.</param>
        /// <param name="delta">The time since the last recorded position.</param>
        /// <param name="future">The predicted future position.</param>
        /// <returns>The calculated movement.</returns>
        public static Vector2 Evade([NotNull] this GameObject position, [NotNull] Component target, Vector2 previous, float speed, float delta, out Vector2 future) => position.Flatten().Evade(target, previous, speed, delta, out future);
        
        /// <summary>
        /// Calculate a evade behaviour.
        /// </summary>
        /// <param name="position">The current position of the instance to calculate the movement for.</param>
        /// <param name="target">The target to move in relation to.</param>
        /// <param name="previous">The previous position of the target.</param>
        /// <param name="speed">The maximum speed that the position can update at.</param>
        /// <param name="future">The predicted future position.</param>
        /// <returns>The calculated movement.</returns>
        public static Vector2 Evade([NotNull] this GameObject position, [NotNull] Component target, Vector2 previous, float speed, out Vector2 future) => position.Flatten().Evade(target, previous, speed, Time.deltaTime, out future);
        
        /// <summary>
        /// Calculate a evade behaviour.
        /// </summary>
        /// <param name="position">The current position of the instance to calculate the movement for.</param>
        /// <param name="target">The target to move in relation to.</param>
        /// <param name="previous">The previous position of the target.</param>
        /// <param name="speed">The maximum speed that the position can update at.</param>
        /// <param name="delta">The time since the last recorded position.</param>
        /// <param name="future">The predicted future position.</param>
        /// <returns>The calculated movement.</returns>
        public static Vector2 Evade([NotNull] this GameObject position, [NotNull] Component target, Vector3 previous, float speed, float delta, out Vector2 future) => position.Flatten().Evade(target, previous, speed, delta, out future);
        
        /// <summary>
        /// Calculate a evade behaviour.
        /// </summary>
        /// <param name="position">The current position of the instance to calculate the movement for.</param>
        /// <param name="target">The target to move in relation to.</param>
        /// <param name="previous">The previous position of the target.</param>
        /// <param name="speed">The maximum speed that the position can update at.</param>
        /// <param name="future">The predicted future position.</param>
        /// <returns>The calculated movement.</returns>
        public static Vector2 Evade([NotNull] this GameObject position, [NotNull] Component target, Vector3 previous, float speed, out Vector2 future) => position.Flatten().Evade(target, previous, speed, Time.deltaTime, out future);
        
        /// <summary>
        /// Calculate a evade behaviour.
        /// </summary>
        /// <param name="position">The current position of the instance to calculate the movement for.</param>
        /// <param name="target">The target to move in relation to.</param>
        /// <param name="previous">The previous position of the target.</param>
        /// <param name="speed">The maximum speed that the position can update at.</param>
        /// <param name="delta">The time since the last recorded position.</param>
        /// <param name="future">The predicted future position.</param>
        /// <returns>The calculated movement.</returns>
        public static Vector2 Evade([NotNull] this GameObject position, [NotNull] Component target, [NotNull] Transform previous, float speed, float delta, out Vector2 future) => position.Flatten().Evade(target, previous, speed, delta, out future);
        
        /// <summary>
        /// Calculate a evade behaviour.
        /// </summary>
        /// <param name="position">The current position of the instance to calculate the movement for.</param>
        /// <param name="target">The target to move in relation to.</param>
        /// <param name="previous">The previous position of the target.</param>
        /// <param name="speed">The maximum speed that the position can update at.</param>
        /// <param name="future">The predicted future position.</param>
        /// <returns>The calculated movement.</returns>
        public static Vector2 Evade([NotNull] this GameObject position, [NotNull] Component target, [NotNull] Transform previous, float speed, out Vector2 future) => position.Flatten().Evade(target, previous, speed, Time.deltaTime, out future);
        
        /// <summary>
        /// Calculate a evade behaviour.
        /// </summary>
        /// <param name="position">The current position of the instance to calculate the movement for.</param>
        /// <param name="target">The target to move in relation to.</param>
        /// <param name="previous">The previous position of the target.</param>
        /// <param name="speed">The maximum speed that the position can update at.</param>
        /// <param name="delta">The time since the last recorded position.</param>
        /// <param name="future">The predicted future position.</param>
        /// <returns>The calculated movement.</returns>
        public static Vector2 Evade([NotNull] this GameObject position, [NotNull] Component target, [NotNull] Component previous, float speed, float delta, out Vector2 future) => position.Flatten().Evade(target, previous, speed, delta, out future);
        
        /// <summary>
        /// Calculate a evade behaviour.
        /// </summary>
        /// <param name="position">The current position of the instance to calculate the movement for.</param>
        /// <param name="target">The target to move in relation to.</param>
        /// <param name="previous">The previous position of the target.</param>
        /// <param name="speed">The maximum speed that the position can update at.</param>
        /// <param name="future">The predicted future position.</param>
        /// <returns>The calculated movement.</returns>
        public static Vector2 Evade([NotNull] this GameObject position, [NotNull] Component target, [NotNull] Component previous, float speed, out Vector2 future) => position.Flatten().Evade(target, previous, speed, Time.deltaTime, out future);
        
        /// <summary>
        /// Calculate a evade behaviour.
        /// </summary>
        /// <param name="position">The current position of the instance to calculate the movement for.</param>
        /// <param name="target">The target to move in relation to.</param>
        /// <param name="previous">The previous position of the target.</param>
        /// <param name="speed">The maximum speed that the position can update at.</param>
        /// <param name="delta">The time since the last recorded position.</param>
        /// <param name="future">The predicted future position.</param>
        /// <returns>The calculated movement.</returns>
        public static Vector2 Evade([NotNull] this GameObject position, [NotNull] Component target, [NotNull] GameObject previous, float speed, float delta, out Vector2 future) => position.Flatten().Evade(target, previous, speed, delta, out future);
        
        /// <summary>
        /// Calculate a evade behaviour.
        /// </summary>
        /// <param name="position">The current position of the instance to calculate the movement for.</param>
        /// <param name="target">The target to move in relation to.</param>
        /// <param name="previous">The previous position of the target.</param>
        /// <param name="speed">The maximum speed that the position can update at.</param>
        /// <param name="future">The predicted future position.</param>
        /// <returns>The calculated movement.</returns>
        public static Vector2 Evade([NotNull] this GameObject position, [NotNull] Component target, [NotNull] GameObject previous, float speed, out Vector2 future) => position.Flatten().Evade(target, previous, speed, Time.deltaTime, out future);
        
        /// <summary>
        /// Calculate a evade behaviour.
        /// </summary>
        /// <param name="position">The current position of the instance to calculate the movement for.</param>
        /// <param name="target">The target to move in relation to.</param>
        /// <param name="previous">The previous position of the target.</param>
        /// <param name="speed">The maximum speed that the position can update at.</param>
        /// <param name="delta">The time since the last recorded position.</param>
        /// <param name="future">The predicted future position.</param>
        /// <returns>The calculated movement.</returns>
        public static Vector2 Evade([NotNull] this GameObject position, [NotNull] GameObject target, Vector2 previous, float speed, float delta, out Vector2 future) => position.Flatten().Evade(target, previous, speed, delta, out future);
        
        /// <summary>
        /// Calculate a evade behaviour.
        /// </summary>
        /// <param name="position">The current position of the instance to calculate the movement for.</param>
        /// <param name="target">The target to move in relation to.</param>
        /// <param name="previous">The previous position of the target.</param>
        /// <param name="speed">The maximum speed that the position can update at.</param>
        /// <param name="future">The predicted future position.</param>
        /// <returns>The calculated movement.</returns>
        public static Vector2 Evade([NotNull] this GameObject position, [NotNull] GameObject target, Vector2 previous, float speed, out Vector2 future) => position.Flatten().Evade(target, previous, speed, Time.deltaTime, out future);
        
        /// <summary>
        /// Calculate a evade behaviour.
        /// </summary>
        /// <param name="position">The current position of the instance to calculate the movement for.</param>
        /// <param name="target">The target to move in relation to.</param>
        /// <param name="previous">The previous position of the target.</param>
        /// <param name="speed">The maximum speed that the position can update at.</param>
        /// <param name="delta">The time since the last recorded position.</param>
        /// <param name="future">The predicted future position.</param>
        /// <returns>The calculated movement.</returns>
        public static Vector2 Evade([NotNull] this GameObject position, [NotNull] GameObject target, Vector3 previous, float speed, float delta, out Vector2 future) => position.Flatten().Evade(target, previous, speed, delta, out future);
        
        /// <summary>
        /// Calculate a evade behaviour.
        /// </summary>
        /// <param name="position">The current position of the instance to calculate the movement for.</param>
        /// <param name="target">The target to move in relation to.</param>
        /// <param name="previous">The previous position of the target.</param>
        /// <param name="speed">The maximum speed that the position can update at.</param>
        /// <param name="future">The predicted future position.</param>
        /// <returns>The calculated movement.</returns>
        public static Vector2 Evade([NotNull] this GameObject position, [NotNull] GameObject target, Vector3 previous, float speed, out Vector2 future) => position.Flatten().Evade(target, previous, speed, Time.deltaTime, out future);
        
        /// <summary>
        /// Calculate a evade behaviour.
        /// </summary>
        /// <param name="position">The current position of the instance to calculate the movement for.</param>
        /// <param name="target">The target to move in relation to.</param>
        /// <param name="previous">The previous position of the target.</param>
        /// <param name="speed">The maximum speed that the position can update at.</param>
        /// <param name="delta">The time since the last recorded position.</param>
        /// <param name="future">The predicted future position.</param>
        /// <returns>The calculated movement.</returns>
        public static Vector2 Evade([NotNull] this GameObject position, [NotNull] GameObject target, [NotNull] Transform previous, float speed, float delta, out Vector2 future) => position.Flatten().Evade(target, previous, speed, delta, out future);
        
        /// <summary>
        /// Calculate a evade behaviour.
        /// </summary>
        /// <param name="position">The current position of the instance to calculate the movement for.</param>
        /// <param name="target">The target to move in relation to.</param>
        /// <param name="previous">The previous position of the target.</param>
        /// <param name="speed">The maximum speed that the position can update at.</param>
        /// <param name="future">The predicted future position.</param>
        /// <returns>The calculated movement.</returns>
        public static Vector2 Evade([NotNull] this GameObject position, [NotNull] GameObject target, [NotNull] Transform previous, float speed, out Vector2 future) => position.Flatten().Evade(target, previous, speed, Time.deltaTime, out future);
        
        /// <summary>
        /// Calculate a evade behaviour.
        /// </summary>
        /// <param name="position">The current position of the instance to calculate the movement for.</param>
        /// <param name="target">The target to move in relation to.</param>
        /// <param name="previous">The previous position of the target.</param>
        /// <param name="speed">The maximum speed that the position can update at.</param>
        /// <param name="delta">The time since the last recorded position.</param>
        /// <param name="future">The predicted future position.</param>
        /// <returns>The calculated movement.</returns>
        public static Vector2 Evade([NotNull] this GameObject position, [NotNull] GameObject target, [NotNull] Component previous, float speed, float delta, out Vector2 future) => position.Flatten().Evade(target, previous, speed, delta, out future);
        
        /// <summary>
        /// Calculate a evade behaviour.
        /// </summary>
        /// <param name="position">The current position of the instance to calculate the movement for.</param>
        /// <param name="target">The target to move in relation to.</param>
        /// <param name="previous">The previous position of the target.</param>
        /// <param name="speed">The maximum speed that the position can update at.</param>
        /// <param name="future">The predicted future position.</param>
        /// <returns>The calculated movement.</returns>
        public static Vector2 Evade([NotNull] this GameObject position, [NotNull] GameObject target, [NotNull] Component previous, float speed, out Vector2 future) => position.Flatten().Evade(target, previous, speed, Time.deltaTime, out future);
        
        /// <summary>
        /// Calculate a evade behaviour.
        /// </summary>
        /// <param name="position">The current position of the instance to calculate the movement for.</param>
        /// <param name="target">The target to move in relation to.</param>
        /// <param name="previous">The previous position of the target.</param>
        /// <param name="speed">The maximum speed that the position can update at.</param>
        /// <param name="delta">The time since the last recorded position.</param>
        /// <param name="future">The predicted future position.</param>
        /// <returns>The calculated movement.</returns>
        public static Vector2 Evade([NotNull] this GameObject position, [NotNull] GameObject target, [NotNull] GameObject previous, float speed, float delta, out Vector2 future) => position.Flatten().Evade(target, previous, speed, delta, out future);
        
        /// <summary>
        /// Calculate a evade behaviour.
        /// </summary>
        /// <param name="position">The current position of the instance to calculate the movement for.</param>
        /// <param name="target">The target to move in relation to.</param>
        /// <param name="previous">The previous position of the target.</param>
        /// <param name="speed">The maximum speed that the position can update at.</param>
        /// <param name="future">The predicted future position.</param>
        /// <returns>The calculated movement.</returns>
        public static Vector2 Evade([NotNull] this GameObject position, [NotNull] GameObject target, [NotNull] GameObject previous, float speed, out Vector2 future) => position.Flatten().Evade(target, previous, speed, Time.deltaTime, out future);
    }
}