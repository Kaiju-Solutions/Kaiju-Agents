using UnityEngine;

namespace KaijuSolutions.Agents
{
    /// <summary>
    /// Base Kaiju Agent class.
    /// </summary>
#if UNITY_EDITOR
    [SelectionBase]
    [DisallowMultipleComponent]
    [Icon("Packages/com.kaijusolutions.agents/Editor/Icon.png")]
    [HelpURL("https://agents.kaijusolutions.ca/manual/getting-started.html")]
#endif
    public abstract class KaijuAgent : MonoBehaviour
    {
        /// <summary>
        /// The maximum speed of the agent.
        /// </summary>
        public float Speed { get; private set; }
        
        /// <summary>
        /// The current velocity of the agent.
        /// </summary>
        public Vector2 Velocity { get; private set; }
        
        /// <summary>
        /// Check if the agent is active.
        /// </summary>
        public bool Active => isActiveAndEnabled && gameObject.activeInHierarchy;
        
        /// <summary>
        /// Initialize the agent.
        /// </summary>
        public virtual void Setup() { }
        
        /// <summary>
        /// Get a description of the object.
        /// </summary>
        /// <returns>A description of the object.</returns>
        public override string ToString()
        {
            return $"Kaiju Agent {name} - Velocity: {Velocity} - Max Speed: {Speed}";
        }
        
        /// <summary>
        /// Get a description of the object.
        /// </summary>
        /// <returns>A description of the object.</returns>
        public static implicit operator string(KaijuAgent a) => a.ToString();
        
        /// <summary>
        /// Implicit conversion to a <see href="https://docs.unity3d.com/Manual/class-GameObject.html">GameObject</see>.
        /// </summary>
        /// <param name="a">The agent.</param>
        /// <returns>The <see href="https://docs.unity3d.com/Manual/class-GameObject.html">GameObject</see> of the agent.</returns>
        public static implicit operator GameObject(KaijuAgent a) => a.gameObject;
        
        /// <summary>
        /// Implicit conversion to a <see href="https://docs.unity3d.com/Manual/class-Transform.html">transform</see>.
        /// </summary>
        /// <param name="a">The agent.</param>
        /// <returns>The <see href="https://docs.unity3d.com/Manual/class-Transform.html">transform</see> of the agent.</returns>
        public static implicit operator Transform(KaijuAgent a) => a.transform;
        
        /// <summary>
        /// Implicit conversion to a Boolean if the agent is <see cref="Active"/>.
        /// </summary>
        /// <param name="a">The agent.</param>
        /// <returns>If the agent is <see cref="Active"/>.</returns>
        public static implicit operator bool(KaijuAgent a) => a != null && a.Active;
    }
}