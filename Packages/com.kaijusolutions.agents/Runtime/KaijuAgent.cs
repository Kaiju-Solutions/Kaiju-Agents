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
        /// Initialize the agent.
        /// </summary>
        public virtual void Setup() { }
        
        /// <summary>
        /// Get a description of the object.
        /// </summary>
        /// <returns>A description of the object.</returns>
        public override string ToString()
        {
            return "Kaiju Agent";
        }
        
        /// <summary>
        /// Implicit conversion to a string getting the name.
        /// </summary>
        /// <param name="t">The movement.</param>
        /// <returns>The name of the agent.</returns>
        public static implicit operator string(KaijuAgent t) => t.name;
        
        /// <summary>
        /// Implicit conversion to a <see href="https://docs.unity3d.com/Manual/class-GameObject.html">GameObject</see>.
        /// </summary>
        /// <param name="t">The movement.</param>
        /// <returns>The <see href="https://docs.unity3d.com/Manual/class-GameObject.html">GameObject</see> of the agent.</returns>
        public static implicit operator GameObject(KaijuAgent t) => t.gameObject;
        
        /// <summary>
        /// Implicit conversion to a <see href="https://docs.unity3d.com/ScriptReference/Transform.html">transform</see>.
        /// </summary>
        /// <param name="t">The movement.</param>
        /// <returns>The <see href="https://docs.unity3d.com/ScriptReference/Transform.html">transform</see> of the agent.</returns>
        public static implicit operator Transform(KaijuAgent t) => t.transform;
    }
}