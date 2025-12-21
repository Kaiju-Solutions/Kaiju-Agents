using System.Diagnostics.CodeAnalysis;
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
        /// The weight of this movement.
        /// </summary>
        public float Weight
        {
            get => _weight;
            set => _weight = Mathf.Max(value, float.Epsilon);
        }
        
        /// <summary>
        /// The weight of this movement.
        /// </summary>
        private float _weight;
        
        /// <summary>
        /// The <see cref="KaijuMovement.Agent"/>'s current position.
        /// </summary>
        public Vector2 AgentPosition => Agent ? Agent.Position : Vector2.zero;
        
        /// <summary>
        /// The <see cref="KaijuMovement.Agent"/>'s current position.
        /// </summary>
        public Vector3 AgentPosition3 => Agent ? Agent.Position3 : Vector3.zero;
        
        /// <summary>
        /// Get the speed in units per second.
        /// </summary>
        /// <param name="current">Current position.</param>
        /// <param name="previous">Position at the previous time step.</param>
        /// <param name="delta">The time step.</param>
        /// <returns>The speed in units per second.</returns>
        protected static float Speed(Vector2 current, Vector2 previous, float delta)
        {
            return Vector2.Distance(current, previous) / delta;
        }
        
        /// <summary>
        /// Get the velocity across axes.
        /// </summary>
        /// <param name="current">Current position.</param>
        /// <param name="previous">Position at the previous time step.</param>
        /// <param name="delta">The time step.</param>
        /// <returns>The velocity across axes</returns>
        protected static Vector2 Velocity(Vector2 current, Vector2 previous, float delta)
        {
            return Direction(current, previous) / delta;
        }
        
        /// <summary>
        /// Get the direction from the first vector to the second.
        /// </summary>
        /// <param name="a">The first vector.</param>
        /// <param name="b">The second vector.</param>
        /// <returns>The direction from the first vector to the second.</returns>
        protected static Vector2 Direction(Vector2 a, Vector2 b)
        {
            return a - b;
        }
        
        /// <summary>
        /// Create the movement.
        /// </summary>
        /// <param name="agent">The agent this is assigned to.</param>
        /// <param name="weight">The weight of this movement.</param>
        public KaijuMovement([NotNull] KaijuAgent agent, float weight = 1)
        {
            Initialize(agent, weight);
        }
        
        /// <summary>
        /// Initialize the movement.
        /// </summary>
        /// <param name="agent">The agent this is assigned to.</param>
        /// <param name="weight">The weight of this movement.</param>
        protected void Initialize([NotNull] KaijuAgent agent, float weight = 1)
        {
            Agent = agent;
            Weight = weight;
            Setup();
        }
        
        /// <summary>
        /// Handle any additional setup.
        /// </summary>
        protected virtual void Setup() { }
        
        /// <summary>
        /// Get the movement.
        /// </summary>
        /// <param name="delta">The time step.</param>
        /// <returns>The calculated movement.</returns>
        public abstract Vector2 Move(float delta);

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
        /// Return this movement.
        /// </summary>
        public void Return()
        {
            Reset();
            KaijuMovementManager.Return(this);
        }
        
        /// <summary>
        /// Perform any needed reset operations.
        /// </summary>
        protected virtual void Reset()
        {
            Agent = null;
            _weight = 0;
        }
#if UNITY_EDITOR
        /// <summary>
        /// Allow for visualizing with <see href="https://docs.unity3d.com/ScriptReference/Gizmos.html">gizmos</see>.
        /// </summary>
        public void Visualize()
        {
            // Nothing to visualize if no agents.
            if (!Agent)
            {
                return;
            }
            
            Gizmos.color = VisualizationColor();
            RenderVisualizations();
        }
        
        /// <summary>
        /// Get the color for visualizations.
        /// </summary>
        /// <returns>The color for visualizations</returns>
        protected virtual Color VisualizationColor() => Color.white;
        
        /// <summary>
        /// Render the visualization of the movement.
        /// </summary>
        protected virtual void RenderVisualizations() { }
#endif
        /// <summary>
        /// Get a description of the object.
        /// </summary>
        /// <returns>A description of the object.</returns>
        public override string ToString()
        {
            return $"Kaiju Movement - Agent: {(Agent ? Agent.name : "None")} - Weight: {Weight} - {(Done() ? "Done" : "Executing")}";
        }
        
        /// <summary>
        /// Implicit conversion to an <see cref="KaijuAgent"/> from the assigned <see cref="Agent"/>.
        /// </summary>
        /// <param name="m">The movement.</param>
        /// <returns>The <see cref="KaijuAgent"/>.</returns>
        public static implicit operator KaijuAgent([NotNull] KaijuMovement m) => m.Agent;
        
        /// <summary>
        /// Implicit conversion to a <see href="https://docs.unity3d.com/Manual/class-Transform.html">transform</see> from the assigned <see cref="Agent"/>.
        /// </summary>
        /// <param name="m">The movement.</param>
        /// <returns>The <see href="https://docs.unity3d.com/Manual/class-Transform.html">transform</see> of the assigned <see cref="Agent"/>.</returns>
        public static implicit operator Transform([NotNull] KaijuMovement m) => m.Agent;
        
        /// <summary>
        /// Implicit conversion to a <see href="https://docs.unity3d.com/Manual/class-GameObject.html">GameObject</see> from the assigned <see cref="Agent"/>.
        /// </summary>
        /// <param name="m">The movement.</param>
        /// <returns>The <see href="https://docs.unity3d.com/Manual/class-GameObject.html">GameObject</see> of the assigned <see cref="Agent"/>.</returns>
        public static implicit operator GameObject([NotNull] KaijuMovement m) => m.Agent;
        
        /// <summary>
        /// Implicit conversion to a Vector2 from the assigned <see cref="Agent"/>'s position.
        /// </summary>
        /// <param name="m">The movement.</param>
        /// <returns>The Vector2 from the assigned <see cref="Agent"/>'s position.</returns>
        public static implicit operator Vector2([NotNull] KaijuMovement m) => m.Agent;
        
        /// <summary>
        /// Implicit conversion to a nullable Vector2 from the assigned <see cref="Agent"/>'s position.
        /// </summary>
        /// <param name="m">The movement.</param>
        /// <returns>The Vector2 from the assigned <see cref="Agent"/>'s position.</returns>
        public static implicit operator Vector2?([NotNull] KaijuMovement m) => m.Agent;
        
        /// <summary>
        /// Implicit conversion to a Vector3 from the assigned <see cref="Agent"/>'s position.
        /// </summary>
        /// <param name="m">The movement.</param>
        /// <returns>The Vector3 from the assigned <see cref="Agent"/>'s position.</returns>
        public static implicit operator Vector3([NotNull] KaijuMovement m) => m.Agent;
        
        /// <summary>
        /// Implicit conversion to a nullable Vector3 from the assigned <see cref="Agent"/>'s position.
        /// </summary>
        /// <param name="m">The movement.</param>
        /// <returns>The Vector3 from the assigned <see cref="Agent"/>'s position.</returns>
        public static implicit operator Vector3?([NotNull] KaijuMovement m) => m.Agent;
        
        /// <summary>
        /// Implicit conversion to a Boolean to see if the <see cref="Agent"/> is assigned.
        /// </summary>
        /// <param name="m">The movement.</param>
        /// <returns>If the <see cref="Agent"/> is assigned.</returns>
        public static implicit operator bool([NotNull] KaijuMovement m) => m.Agent;
        
        /// <summary>
        /// Implicit conversion to a nullable Boolean to see if the <see cref="Agent"/> is assigned.
        /// </summary>
        /// <param name="m">The movement.</param>
        /// <returns>If the <see cref="Agent"/> is assigned.</returns>
        public static implicit operator bool?([NotNull] KaijuMovement m) => m.Agent;
        
        /// <summary>
        /// Implicit conversion to a string.
        /// </summary>
        /// <param name="m">The movement.</param>
        /// <returns>The string from the <see cref="ToString"/> method.</returns>
        public static implicit operator string([NotNull] KaijuMovement m) => m.ToString();
        
        /// <summary>
        /// Implicit conversion to a float from the <see cref="Weight"/>.
        /// </summary>
        /// <param name="m">The movement.</param>
        /// <returns>The <see cref="Weight"/>.</returns>
        public static implicit operator float([NotNull] KaijuMovement m) => m.Weight;
        
        /// <summary>
        /// Implicit conversion to a nullable float from the <see cref="Weight"/>.
        /// </summary>
        /// <param name="m">The movement.</param>
        /// <returns>The <see cref="Weight"/>.</returns>
        public static implicit operator float?([NotNull] KaijuMovement m) => m.Weight;
        
        /// <summary>
        /// Implicit conversion to a double from the <see cref="Weight"/>.
        /// </summary>
        /// <param name="m">The movement.</param>
        /// <returns>The <see cref="Weight"/>.</returns>
        public static implicit operator double([NotNull] KaijuMovement m) => m.Weight;
        
        /// <summary>
        /// Implicit conversion to a nullable double from the <see cref="Weight"/>.
        /// </summary>
        /// <param name="m">The movement.</param>
        /// <returns>The <see cref="Weight"/>.</returns>
        public static implicit operator double?([NotNull] KaijuMovement m) => m.Weight;
    }
}