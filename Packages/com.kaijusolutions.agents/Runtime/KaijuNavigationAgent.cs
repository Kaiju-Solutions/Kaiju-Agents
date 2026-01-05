using System.Diagnostics.CodeAnalysis;
using UnityEngine;
using UnityEngine.AI;

namespace KaijuSolutions.Agents
{
    /// <summary>
    /// <see cref="KaijuAgent"/> which moves via a <see href="https://docs.unity3d.com/ScriptReference/AI.NavMeshAgent.html">navigation mesh <see cref="KaijuAgent"/></see>.
    /// </summary>
    [DisallowMultipleComponent]
    [DefaultExecutionOrder(int.MinValue + 2)]
#if UNITY_EDITOR
    [SelectionBase]
    [AddComponentMenu("Kaiju Solutions/Agents/Kaiju Navigation Agent", 3)]
    [Icon("Packages/com.kaijusolutions.agents/Editor/Icon.png")]
    [HelpURL("https://agents.kaijusolutions.ca")]
#endif
    [RequireComponent(typeof(NavMeshAgent))]
    public sealed class KaijuNavigationAgent : KaijuAgent
    {
        /// <summary>
        /// The <see href="https://docs.unity3d.com/ScriptReference/AI.NavMeshAgent.html">navigation mesh <see cref="KaijuAgent"/></see> which controls the <see cref="KaijuAgent"/>'s movement.
        /// </summary>
        public NavMeshAgent Nav => nav;
        
        /// <summary>
        /// The <see href="https://docs.unity3d.com/ScriptReference/AI.NavMeshAgent.html">navigation mesh <see cref="KaijuAgent"/></see> which controls the <see cref="KaijuAgent"/>'s movement.
        /// </summary>
#if UNITY_EDITOR
        [Tooltip("The navigation mesh agent which controls the agent's movement.")]
        [HideInInspector]
#endif
        [SerializeField]
        private NavMeshAgent nav;
        
        /// <summary>
        /// Get the radius of an <see cref="KaijuAgent"/>.
        /// </summary>
        /// <returns>The radius of the <see cref="KaijuAgent"/>.</returns>
        public override float GetRadius()
        {
            return nav ? nav.radius : 0;
        }
        
        /// <summary>
        /// Callback when the movement speed has changed.
        /// </summary>
        private void ChangedMoveSpeed()
        {
            if (nav)
            {
                nav.speed = MoveSpeed;
            }
        }
        
        /// <summary>
        /// Callback when the movement acceleration has changed.
        /// </summary>
        private void ChangedMoveAcceleration()
        {
            if (!nav)
            {
                return;
            }
            
            float acceleration = MoveAcceleration;
            nav.acceleration = acceleration <= 0 ? float.MaxValue : acceleration;
        }
        
        /// <summary>
        /// Callback when the look speed has changed.
        /// </summary>
        private void ChangedLookSpeed()
        {
            if (nav)
            {
                nav.angularSpeed = LookSpeed;
            }
        }
        
        /// <summary>
        /// Callback when the autorotate has changed.
        /// </summary>
        private void ChangedAutoRotate()
        {
            if (nav)
            {
                nav.updateRotation = AutoRotate && !Looking;
            }
        }
        
        /// <summary>
        /// This function is called when the object becomes enabled and active.
        /// </summary>
        protected override void OnEnable()
        {
            OnMoveSpeed += ChangedMoveSpeed;
            OnMoveAcceleration += ChangedMoveAcceleration;
            OnLookSpeed += ChangedLookSpeed;
            OnAutoRotate += ChangedAutoRotate;
            OnLookTarget += ChangedAutoRotate;
            base.OnEnable();
        }
        
        /// <summary>
        /// This function is called when the behaviour becomes disabled.
        /// </summary>
        protected override void OnDisable()
        {
            OnMoveSpeed -= ChangedMoveSpeed;
            OnMoveAcceleration -= ChangedMoveAcceleration;
            OnLookSpeed -= ChangedLookSpeed;
            OnAutoRotate -= ChangedAutoRotate;
            OnLookTarget -= ChangedAutoRotate;
            
            if (nav && nav.isOnNavMesh)
            {
                nav.ResetPath();
                nav.isStopped = true;
            }
            
            base.OnDisable();
        }
        
        /// <summary>
        /// Initialize the <see cref="KaijuAgent"/>. There is no point in manually calling this.
        /// </summary>
        public override void Setup()
        {
            base.Setup();
            gameObject.AssignComponent(ref nav);
            nav.speed = MoveSpeed;
            float acceleration = MoveAcceleration;
            nav.acceleration = acceleration <= 0 ? float.MaxValue : acceleration;
            nav.angularSpeed = LookSpeed;
            nav.updateRotation = AutoRotate && !Looking;
            
            if (!nav.isOnNavMesh)
            {
                return;
            }
            
            nav.ResetPath();
            nav.isStopped = true;
            nav.enabled = true;
        }
        
        /// <summary>
        /// Perform <see cref="KaijuAgent"/> movement. There is no point in manually calling this.
        /// </summary>
        /// <param name="delta">The time step.</param>
        public override void Move(float delta)
        {
            // Offset the current position by the movement velocity.
            nav.Move(Velocity3 * delta);
        }
        
        /// <summary>
        /// Get a description of the object.
        /// </summary>
        /// <returns>A description of the object.</returns>
        public override string ToString()
        {
            return $"Kaiju Navigation Agent {name} - {(isActiveAndEnabled ? "Active" : "Inactive")} - Velocity: {Velocity} - Move Speed: {MoveSpeed} - Move Acceleration: {MoveAcceleration} - Look Speed: {LookSpeed}";
        }
        
        /// <summary>
        /// Implicit conversion to get the <see href="https://docs.unity3d.com/ScriptReference/AI.NavMeshAgent.html">navigation mesh <see cref="KaijuAgent"/></see>.
        /// </summary>
        /// <param name="a">The <see cref="KaijuAgent"/>.</param>
        /// <returns>The <see href="https://docs.unity3d.com/ScriptReference/AI.NavMeshAgent.html">navigation mesh <see cref="KaijuAgent"/></see> of the <see cref="KaijuAgent"/>.</returns>
        public static implicit operator NavMeshAgent([NotNull] KaijuNavigationAgent a) => a.nav;
        
        /// <summary>
        /// Implicit conversion from a <see href="https://docs.unity3d.com/Manual/class-GameObject.html">GameObject</see>.
        /// </summary>
        /// <param name="o">The <see href="https://docs.unity3d.com/Manual/class-GameObject.html">GameObject</see>.</param>
        /// <returns>The <see cref="KaijuAgent"/> attached to the <see href="https://docs.unity3d.com/Manual/class-GameObject.html">GameObject</see> if there was one.</returns>
        public static implicit operator KaijuNavigationAgent([NotNull] GameObject o) => o.GetComponent<KaijuNavigationAgent>();
        
        /// <summary>
        /// Implicit conversion from a <see href="https://docs.unity3d.com/Manual/class-transform.html">transform</see>.
        /// </summary>
        /// <param name="t">The <see href="https://docs.unity3d.com/Manual/class-transform.html">transform</see>.</param>
        /// <returns>The <see cref="KaijuAgent"/> attached to the <see href="https://docs.unity3d.com/Manual/class-transform.html">transform</see> if there was one.</returns>
        public static implicit operator KaijuNavigationAgent([NotNull] Transform t) => t.GetComponent<KaijuNavigationAgent>();
    }
}