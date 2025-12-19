using UnityEngine;

namespace KaijuSolutions.Agents.Movement
{
    /// <summary>
    /// Base movement class.
    /// </summary>
    public abstract class KaijuMovement
    {
        /// <summary>
        /// The agent the movement is assigned to.
        /// </summary>
        public KaijuAgent Agent;
        
        /// <summary>
        /// Create the movement.
        /// </summary>
        /// <param name="agent">The agent this is assigned to.</param>
        public KaijuMovement(KaijuAgent agent)
        {
            Agent = agent;
        }
        
        /// <summary>
        /// Get the velocity and speed.
        /// </summary>
        /// <param name="current">Current position.</param>
        /// <param name="previous">Position at the previous time step.</param>
        /// <param name="velocity">The velocity.</param>
        /// <param name="speed">The speed.</param>
        protected static void VelocityAndSpeed(Vector2 current, Vector2 previous, out Vector2 velocity, out float speed)
        {
            float delta = Time.deltaTime;
            velocity = Velocity(current, previous, delta);
            speed = Speed(current, previous, delta);
        }
        
        /// <summary>
        /// Get the speed in units per second.
        /// </summary>
        /// <param name="current">Current position.</param>
        /// <param name="previous">Position at the previous time step.</param>
        /// <returns>The speed in units per second.</returns>
        protected static float Speed(Vector2 current, Vector2 previous)
        {
            return Speed(current, previous, Time.deltaTime);
        }
        
        /// <summary>
        /// Get the speed in units per second.
        /// </summary>
        /// <param name="current">Current position.</param>
        /// <param name="previous">Position at the previous time step.</param>
        /// <param name="delta">The time step.</param>
        /// <returns>The speed in units per second.</returns>
        private static float Speed(Vector2 current, Vector2 previous, float delta)
        {
            return Vector2.Distance(current, previous) * delta;
        }
        
        /// <summary>
        /// Get the velocity across axis.
        /// </summary>
        /// <param name="current">Current position.</param>
        /// <param name="previous">Position at the previous time step.</param>
        /// <returns>The velocity across axis</returns>
        protected static Vector2 Velocity(Vector2 current, Vector2 previous)
        {
            return Velocity(current, previous, Time.deltaTime);
        }
        
        /// <summary>
        /// Get the velocity across axis.
        /// </summary>
        /// <param name="current">Current position.</param>
        /// <param name="previous">Position at the previous time step.</param>
        /// <param name="delta">The time step.</param>
        /// <returns>The velocity across axis</returns>
        private static Vector2 Velocity(Vector2 current, Vector2 previous, float delta)
        {
            return (current - previous) / delta;
        }
        
        /// <summary>
        /// Get the movement.
        /// </summary>
        /// <param name="velocity">The agent's current velocity.</param>
        /// <param name="speed">The agent's maximum movement speed.</param>
        /// <returns>The calculated movement.</returns>
        public abstract Vector2 Move(Vector2 velocity, float speed);

        /// <summary>
        /// Determine if the movement is done or not.
        /// </summary>
        /// <returns>If the movement is done or not.</returns>
        public virtual bool Done()
        {
            // If the agent is not assigned, there is no movement.
            return !Agent;
        }
        
        /// <summary>
        /// Get a description of the object.
        /// </summary>
        /// <returns>A description of the object.</returns>
        public override string ToString()
        {
            return $"Kaiju Movement - Agent: {(Agent ? Agent.name : "None")}- {(Done() ? "Done" : "Executing")}";
        }
        
        /// <summary>
        /// Implicit conversion to an <see cref="KaijuAgent"/> from the assigned <see cref="Agent"/>.
        /// </summary>
        /// <param name="t">The movement.</param>
        /// <returns>The agent.</returns>
        public static implicit operator KaijuAgent(KaijuMovement t) => t.Agent;
        
        /// <summary>
        /// Implicit conversion to a string.
        /// </summary>
        /// <param name="t">The movement.</param>
        /// <returns>The string from the <see cref="ToString"/> method.</returns>
        public static implicit operator string(KaijuMovement t) => t.ToString();
    }
}