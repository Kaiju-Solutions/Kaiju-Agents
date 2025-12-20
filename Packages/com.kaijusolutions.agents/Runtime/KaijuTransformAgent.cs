using UnityEngine;

namespace KaijuSolutions.Agents
{
    /// <summary>
    /// Kaiju Agent which moves via the <see href="https://docs.unity3d.com/Manual/class-Transform.html">transform</see>.
    /// </summary>
#if UNITY_EDITOR
    [SelectionBase]
    [DisallowMultipleComponent]
    [AddComponentMenu("Kaiju Solutions/Agents/Kaiju Transform Agent", 0)]
    [Icon("Packages/com.kaijusolutions.agents/Editor/Icon.png")]
    [HelpURL("https://agents.kaijusolutions.ca/manual/getting-started.html")]
#endif
    public sealed class KaijuTransformAgent : KaijuAgent
    {
        // TODO.
        
        /// <summary>
        /// Get a description of the object.
        /// </summary>
        /// <returns>A description of the object.</returns>
        public override string ToString()
        {
            return $"Kaiju Transform Agent {name} - Velocity: {Velocity} - Max Speed: {Speed}";
        }
    }
}