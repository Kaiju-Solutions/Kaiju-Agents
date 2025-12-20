using System.Diagnostics.CodeAnalysis;
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
        /// Get the position vector along the main XZ axis.
        /// </summary>
        public Vector2 Position
        {
            get
            {
                Vector3 p = transform.position;
                return new(p.x, p.z);
            }
        }
        
        /// <summary>
        /// Get the position vector along all three axes.
        /// </summary>
        public Vector3 Position3 => transform.position;
        
        /// <summary>
        /// Get the angle the agent is rotated along the main Y axis.
        /// </summary>
        public float Orientation => transform.localEulerAngles.y;
        
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
            return $"Kaiju Agent {name} - {(isActiveAndEnabled ? "Active" : "Inactive")} - Velocity: {Velocity} - Max Speed: {Speed}";
        }
        
        /// <summary>
        /// Implicit conversion to a float from the <see cref="Orientation"/>.
        /// </summary>
        /// <param name="a">The agent.</param>
        /// <returns>The agent's <see cref="Orientation"/>.</returns>
        public static implicit operator float([NotNull] KaijuAgent a) => a.Orientation;
        
        /// <summary>
        /// Implicit conversion to a nullable float from the <see cref="Orientation"/>.
        /// </summary>
        /// <param name="a">The agent.</param>
        /// <returns>The agent's <see cref="Orientation"/>.</returns>
        public static implicit operator float?([NotNull] KaijuAgent a) => a.Orientation;
        
        /// <summary>
        /// Implicit conversion to a double from the <see cref="Orientation"/>.
        /// </summary>
        /// <param name="a">The agent.</param>
        /// <returns>The agent's <see cref="Orientation"/>.</returns>
        public static implicit operator double([NotNull] KaijuAgent a) => a.Orientation;
        
        /// <summary>
        /// Implicit conversion to a nullable double from the <see cref="Orientation"/>.
        /// </summary>
        /// <param name="a">The agent.</param>
        /// <returns>The agent's <see cref="Orientation"/>.</returns>
        public static implicit operator double?([NotNull] KaijuAgent a) => a.Orientation;
        
        /// <summary>
        /// Implicit conversion to a Vector2 from the <see cref="Position"/>.
        /// </summary>
        /// <param name="a">The agent.</param>
        /// <returns>The agent's <see cref="Position"/>.</returns>
        public static implicit operator Vector2([NotNull] KaijuAgent a) => a.Position;
        
        /// <summary>
        /// Implicit conversion to a nullable Vector2 from the <see cref="Position"/>.
        /// </summary>
        /// <param name="a">The agent.</param>
        /// <returns>The agent's <see cref="Position"/>.</returns>
        public static implicit operator Vector2?([NotNull] KaijuAgent a) => a.Position;
        
        /// <summary>
        /// Implicit conversion to a Vector2 from the <see cref="Position"/>.
        /// </summary>
        /// <param name="a">The agent.</param>
        /// <returns>The agent's <see cref="Position"/>.</returns>
        public static implicit operator Vector3([NotNull] KaijuAgent a) => a.Position;
        
        /// <summary>
        /// Implicit conversion to a nullable Vector3 from the <see cref="Position3"/>.
        /// </summary>
        /// <param name="a">The agent.</param>
        /// <returns>The agent's <see cref="Position3"/>.</returns>
        public static implicit operator Vector3?([NotNull] KaijuAgent a) => a.Position3;
        
        /// <summary>
        /// Implicit conversion to a <see href="https://docs.unity3d.com/Manual/class-GameObject.html">GameObject</see>.
        /// </summary>
        /// <param name="a">The agent.</param>
        /// <returns>The <see href="https://docs.unity3d.com/Manual/class-GameObject.html">GameObject</see> of the agent.</returns>
        public static implicit operator GameObject([NotNull] KaijuAgent a) => a.gameObject;
        
        /// <summary>
        /// Implicit conversion from a <see href="https://docs.unity3d.com/Manual/class-GameObject.html">GameObject</see>.
        /// </summary>
        /// <param name="o">The <see href="https://docs.unity3d.com/Manual/class-GameObject.html">GameObject</see>.</param>
        /// <returns>The agent attached to the <see href="https://docs.unity3d.com/Manual/class-GameObject.html">GameObject</see> if there was one.</returns>
        public static implicit operator KaijuAgent([NotNull] GameObject o) => o.GetComponent<KaijuAgent>();
        
        /// <summary>
        /// Implicit conversion to a <see href="https://docs.unity3d.com/Manual/class-Transform.html">transform</see>.
        /// </summary>
        /// <param name="a">The agent.</param>
        /// <returns>The <see href="https://docs.unity3d.com/Manual/class-Transform.html">transform</see> of the agent.</returns>
        public static implicit operator Transform([NotNull] KaijuAgent a) => a.transform;
        
        /// <summary>
        /// Implicit conversion from a <see href="https://docs.unity3d.com/Manual/class-Transform.html">transform</see>.
        /// </summary>
        /// <param name="t">The <see href="https://docs.unity3d.com/Manual/class-Transform.html">transform</see>.</param>
        /// <returns>The agent attached to the <see href="https://docs.unity3d.com/Manual/class-Transform.html">transform</see> if there was one.</returns>
        public static implicit operator KaijuAgent([NotNull] Transform t) => t.GetComponent<KaijuAgent>();
        
        /// <summary>
        /// Implicit conversion to a Boolean if the agent is active.
        /// </summary>
        /// <param name="a">The agent.</param>
        /// <returns>If the agent is active.</returns>
        public static implicit operator bool([NotNull] KaijuAgent a) => a.isActiveAndEnabled;
        
        /// <summary>
        /// Implicit conversion to a string.
        /// </summary>
        /// <param name="a">The agent.</param>
        /// <returns>The string from the <see cref="ToString"/> method.</returns>
        public static implicit operator string([NotNull] KaijuAgent a) => a.ToString();
    }
}