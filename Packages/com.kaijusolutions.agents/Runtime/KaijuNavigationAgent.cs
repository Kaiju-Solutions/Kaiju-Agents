using System.Diagnostics.CodeAnalysis;
using UnityEngine;
using UnityEngine.AI;

namespace KaijuSolutions.Agents
{
    /// <summary>
    /// Kaiju Agent which moves via a <see href="https://docs.unity3d.com/ScriptReference/AI.NavMeshAgent.html">navigation mesh agent</see>.
    /// </summary>
    [DisallowMultipleComponent]
#if UNITY_EDITOR
    [SelectionBase]
    [AddComponentMenu("Kaiju Solutions/Agents/Kaiju Navigation Agent", 3)]
    [Icon("Packages/com.kaijusolutions.agents/Editor/Icon.png")]
    [HelpURL("https://agents.kaijusolutions.ca/manual/getting-started.html")]
#endif
    [RequireComponent(typeof(NavMeshAgent))]
    public sealed class KaijuNavigationAgent : KaijuAgent
    {
        /// <summary>
        /// The <see href="https://docs.unity3d.com/ScriptReference/AI.NavMeshAgent.html">navigation mesh agent</see> which controls the agent's movement.
        /// </summary>
#if UNITY_EDITOR
        [Tooltip("The navigation mesh agent which controls the agent's movement.")]
#endif
        [SerializeField]
        private NavMeshAgent nav;
        
        /// <summary>
        /// The <see href="https://docs.unity3d.com/ScriptReference/AI.NavMeshAgent.html">navigation mesh agent</see> which controls the agent's movement.
        /// </summary>
        public NavMeshAgent Nav => nav;
        
        /// <summary>
        /// Initialize the agent.
        /// </summary>
        public override void Setup()
        {
            gameObject.AssignComponent(ref nav);
        }
        
        /// <summary>
        /// Perform agent movement.
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
            return $"Kaiju Navigation Agent {name} - {(isActiveAndEnabled ? "Active" : "Inactive")} - Velocity: {Velocity} - Max Speed: {MoveSpeed}";
        }
        
        /// <summary>
        /// Implicit conversion to get the <see href="https://docs.unity3d.com/ScriptReference/AI.NavMeshAgent.html">navigation mesh agent</see>.
        /// </summary>
        /// <param name="a">The agent.</param>
        /// <returns>The <see href="https://docs.unity3d.com/ScriptReference/AI.NavMeshAgent.html">navigation mesh agent</see> of the agent.</returns>
        public static implicit operator NavMeshAgent([NotNull] KaijuNavigationAgent a) => a.nav;
    }
}