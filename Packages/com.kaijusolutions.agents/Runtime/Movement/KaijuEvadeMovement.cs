using System.Diagnostics.CodeAnalysis;
using KaijuSolutions.Agents.Extensions;
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif
namespace KaijuSolutions.Agents.Movement
{
    /// <summary>
    /// Evade steering behaviour.
    /// </summary>
    public class KaijuEvadeMovement : KaijuFleeMovement
    {
        /// <summary>
        /// The previous position of the <see cref="KaijuTargetMovement.Target"/>.
        /// </summary>
        public Vector2 Previous;
        
        /// <summary>
        /// The previous position of the <see cref="KaijuTargetMovement.Target"/>.
        /// </summary>
        public Vector3 Previous3
        {
            get => new(Previous.x, 0, Previous.y);
            set => Previous = value.Flatten();
        }
        
        /// <summary>
        /// The predicted future <see cref="KaijuTargetMovement.Target"/>.
        /// </summary>
        public Vector2 Future { get; private set; }
        
        /// <summary>
        /// The predicted future <see cref="KaijuTargetMovement.Target"/>.
        /// </summary>
        public Vector3 Future3 => new(Future.x, 0, Future.y);
#if UNITY_EDITOR
        /// <summary>
        /// Points to render in the editor.
        /// </summary>
        private readonly Vector3[] _editorRendering = new Vector3[6];
#endif
        /// <summary>
        /// Get a <see cref="KaijuEvadeMovement"/>.
        /// </summary>
        /// <param name="agent">The <see cref="KaijuAgent"/> this will be assigned to.</param>
        /// <param name="target">The target.</param>
        /// <param name="distance">At what distance from the target should the evade be considered successful.</param>
        /// <param name="weight">The weight of this <see cref="KaijuMovement"/>.</param>
        /// <returns>Get a <see cref="KaijuEvadeMovement"/> for the <see cref="KaijuAgent"/>.</returns>
        public new static KaijuEvadeMovement Get([NotNull] KaijuAgent agent, Vector2 target, float distance = 20, float weight = 1)
        {
            KaijuEvadeMovement movement = KaijuMovementManager.Get<KaijuEvadeMovement>();
            if (movement == null)
            {
                return new(agent, target, distance, weight);
            }
            
            movement.Initialize(agent, target, distance, weight);
            return movement;
        }
        
        /// <summary>
        /// Get a <see cref="KaijuEvadeMovement"/>.
        /// </summary>
        /// <param name="agent">The <see cref="KaijuAgent"/> this will be assigned to.</param>
        /// <param name="target">The target.</param>
        /// <param name="distance">At what distance from the target should the evade be considered successful.</param>
        /// <param name="weight">The weight of this <see cref="KaijuMovement"/>.</param>
        /// <returns>Get a <see cref="KaijuEvadeMovement"/> for the <see cref="KaijuAgent"/>.</returns>
        public new static KaijuEvadeMovement Get([NotNull] KaijuAgent agent, Vector3 target, float distance = 20, float weight = 1)
        {
            KaijuEvadeMovement movement = KaijuMovementManager.Get<KaijuEvadeMovement>();
            if (movement == null)
            {
                return new(agent, target, distance, weight);
            }
            
            movement.Initialize(agent, target, distance, weight);
            return movement;
        }
        
        /// <summary>
        /// Get a <see cref="KaijuEvadeMovement"/>.
        /// </summary>
        /// <param name="agent">The <see cref="KaijuAgent"/> this will be assigned to.</param>
        /// <param name="target">The target.</param>
        /// <param name="distance">At what distance from the target should the evade be considered successful.</param>
        /// <param name="weight">The weight of this <see cref="KaijuMovement"/>.</param>
        /// <returns>Get a <see cref="KaijuEvadeMovement"/> for the <see cref="KaijuAgent"/>.</returns>
        public new static KaijuEvadeMovement Get([NotNull] KaijuAgent agent, [NotNull] GameObject target, float distance = 20, float weight = 1)
        {
            KaijuEvadeMovement movement = KaijuMovementManager.Get<KaijuEvadeMovement>();
            if (movement == null)
            {
                return new(agent, target, distance, weight);
            }
            
            movement.Initialize(agent, target, distance, weight);
            return movement;
        }
        
        /// <summary>
        /// Get a <see cref="KaijuEvadeMovement"/>.
        /// </summary>
        /// <param name="agent">The <see cref="KaijuAgent"/> this will be assigned to.</param>
        /// <param name="target">The target.</param>
        /// <param name="distance">At what distance from the target should the evade be considered successful.</param>
        /// <param name="weight">The weight of this <see cref="KaijuMovement"/>.</param>
        /// <returns>Get a <see cref="KaijuEvadeMovement"/> for the <see cref="KaijuAgent"/>.</returns>
        public new static KaijuEvadeMovement Get([NotNull] KaijuAgent agent, [NotNull] Component target, float distance = 20, float weight = 1)
        {
            KaijuEvadeMovement movement = KaijuMovementManager.Get<KaijuEvadeMovement>();
            if (movement == null)
            {
                return new(agent, target, distance, weight);
            }
            
            movement.Initialize(agent, target, distance, weight);
            return movement;
        }
        
        /// <summary>
        /// Create a <see cref="KaijuEvadeMovement"/>.
        /// </summary>
        /// <param name="agent">The <see cref="KaijuAgent"/> this is assigned to.</param>
        /// <param name="target">The position to evade from.</param>
        /// <param name="distance">The distance from the target to consider this movement done.</param>
        /// <param name="weight">The weight of this <see cref="KaijuMovement"/>.</param>
        public KaijuEvadeMovement([NotNull] KaijuAgent agent, Vector2 target, float distance = 20, float weight = 1) : base(agent, target, distance, weight) { }
        
        /// <summary>
        /// Create a <see cref="KaijuEvadeMovement"/>.
        /// </summary>
        /// <param name="agent">The <see cref="KaijuAgent"/> this is assigned to.</param>
        /// <param name="target">The position to evade from.</param>
        /// <param name="distance">The distance from the target to consider this movement done.</param>
        /// <param name="weight">The weight of this <see cref="KaijuMovement"/>.</param>
        public KaijuEvadeMovement([NotNull] KaijuAgent agent, Vector3 target, float distance = 20, float weight = 1) : base(agent, target, distance, weight) { }
        
        /// <summary>
        /// Create a <see cref="KaijuEvadeMovement"/>.
        /// </summary>
        /// <param name="agent">The <see cref="KaijuAgent"/> this is assigned to.</param>
        /// <param name="target">The <see href="https://docs.unity3d.com/Manual/class-GameObject.html">GameObject</see> to evade from.</param>
        /// <param name="distance">The distance from the target to consider this movement done.</param>
        /// <param name="weight">The weight of this <see cref="KaijuMovement"/>.</param>
        public KaijuEvadeMovement([NotNull] KaijuAgent agent, [NotNull] GameObject target, float distance = 20, float weight = 1) : base(agent, target, distance, weight) { }
        
        /// <summary>
        /// Create a <see cref="KaijuEvadeMovement"/>.
        /// </summary>
        /// <param name="agent">The <see cref="KaijuAgent"/> this is assigned to.</param>
        /// <param name="target">The <see href="https://docs.unity3d.com/Manual/Components.html">component</see> to evade from.</param>
        /// <param name="distance">The distance from the target to consider this movement done.</param>
        /// <param name="weight">The weight of this <see cref="KaijuMovement"/>.</param>
        public KaijuEvadeMovement([NotNull] KaijuAgent agent, [NotNull] Component target, float distance = 20, float weight = 1) : base(agent, target, distance, weight) { }
        
        /// <summary>
        /// Handle any additional setup.
        /// </summary>
        protected override void Setup()
        {
            // Start the previous and future position as the current position.
            Previous = Target;
            Future = Target;
        }
        
        /// <summary>
        /// Perform any needed reset operations.
        /// </summary>
        protected override void Reset()
        {
            base.Reset();
            Previous = Vector2.zero;
            Future = Vector2.zero;
        }
        
        /// <summary>
        /// Calculate the movement.
        /// </summary>
        /// <param name="position">The <see cref="KaijuAgent"/>'s current position.</param>
        /// <param name="speed">The <see cref="KaijuAgent"/>'s maximum movement speed.</param>
        /// <param name="target">The position to move in relation to.</param>
        /// <param name="delta">The time step.</param>
        /// <returns>The calculated move vector.</returns>
        protected override Vector2 Calculate(Vector2 position, float speed, Vector2 target, float delta)
        {
            Vector2 pursue = position.Evade(target, Previous, speed, delta, out Vector2 future);
            Future = future;
            Previous = target;
            return pursue;
        }
#if UNITY_EDITOR
        /// <summary>
        /// Get the color for visualizations.
        /// </summary>
        /// <returns>The color for visualizations</returns>
        protected override Color EditorVisualizationColor() => KaijuMovementManager.EditorEvadeColor;
        
        /// <summary>
        /// Render the visualization of the <see cref="KaijuMovement"/>.
        /// <param name="position">The position of the <see cref="KaijuMovement.Agent"/>.</param>
        /// </summary>
        protected override void EditorRenderVisualizations(Vector3 position)
        {
            Vector3 t = Target3;
            Vector3 f = Future3;
            
            // Only one line to draw if equal.
            bool still = t == f;
            if (still)
            {
                Handles.DrawLine(position, t);
            }
            else
            {
                // <see cref="KaijuAgent"/> to target.
                _editorRendering[0] = position;
                _editorRendering[1] = t;
                // <see cref="KaijuAgent"/> to forecast.
                _editorRendering[2] = position;
                _editorRendering[3] = f;
                // Target to forecast.
                _editorRendering[4] = t;
                _editorRendering[5] = f;
                
                Handles.DrawLines(_editorRendering);
            }
            
            RenderDistance(t);
        }
#endif
        /// <summary>
        /// Get a description of the object.
        /// </summary>
        /// <returns>A description of the object.</returns>
        public override string ToString()
        {
            return $"Kaiju Evade Movement - Agent: {(Agent ? Agent.name : "None")} - Target: {Target.ToString()} - Distance: {Distance} - Current Distance: {CurrentDistance} - Previous: {Previous} - Weight: {Weight} - {(Done() ? "Done" : "Executing")}";
        }
    }
}