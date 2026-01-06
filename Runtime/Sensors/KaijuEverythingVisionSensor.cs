using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using UnityEngine;

namespace KaijuSolutions.Agents.Sensors
{
    /// <summary>
    /// <see cref="KaijuVisionSensor{T}"/> based on <see href="https://docs.unity3d.com/Manual/class-Transform.html">transforms</see>, allowing it to see anything. You can optionally filter objects by name to limit what is returned. While this <see cref="KaijuSensor"/> can be highly versatile, if performance is a concern, it is recommended to extend <see cref="KaijuVisionSensor{T}"/> for a specific <see href="https://docs.unity3d.com/Manual/Components.html">component</see> type you are interested in rather than using this.
    /// </summary>
    [DefaultExecutionOrder(int.MinValue)]
#if UNITY_EDITOR
    [AddComponentMenu("Kaiju Solutions/Agents/Sensors/Kaiju Everything Vision Sensor", 5)]
    [Icon("Packages/com.kaijusolutions.agents/Editor/Icon.png")]
    [HelpURL("https://agents.kaijusolutions.ca/manual/sensors.html#everything-vision-sensor")]
#endif
    public class KaijuEverythingVisionSensor : KaijuVisionSensor<Transform>
    {
        /// <summary>
        /// What to match names of the objects to provide extra filtering. Note this only applies to collecting default observables and not if you set any observables explicitly.
        /// </summary>
        public List<KaijuAgentsMultiMatcher> Matcher
        {
            get => matchers;
            set
            {
                if (value == null)
                {
                    matchers.Clear();
                    return;
                }
                
                matchers = value;
            }
        }
        
        /// <summary>
        /// What to match names of the objects to provide extra filtering, with only one collection needing to pass. Note this only applies to collecting default observables and not if you set any observables explicitly.
        /// </summary>
#if UNITY_EDITOR
        [Tooltip("What to match names of the objects to provide extra filtering, with only one collection needing to pass. Note this only applies to collecting default observables and not if you set any observables explicitly.")]
#endif
        [SerializeField]
        private List<KaijuAgentsMultiMatcher> matchers;
        
        /// <summary>
        /// See if any of the matchers match.
        /// </summary>
        /// <param name="x">The name of an object to compare with.</param>
        /// <returns>If any of the matchers match.</returns>
        private bool Matched(string x)
        {
            foreach (KaijuAgentsMultiMatcher matcher in matchers)
            {
                if (matcher.Matched(x))
                {
                    return true;
                }
            }
            
            return matchers.Count < 1;
        }
        
        /// <summary>
        /// If there are no explicitly defined observable objects, define how to query for default observables.
        /// </summary>
        /// <returns>All active instances.</returns>
        protected override IEnumerable<Transform> DefaultObservables()
        {
            return base.DefaultObservables().Where(x => Matched(x.name));
        }
        
        /// <summary>
        /// Get a description of the object.
        /// </summary>
        /// <returns>A description of the object.</returns>
        public override string ToString()
        {
            return $"Kaiju Everything Vision Sensor {name} - Agent: {(Agent ? Agent.name : "None")} - Distance: {Distance} - Angle: {Angle} - Line-of-Sight: {(lineOfSight ? "Yes" : "No")} - Radius: {Radius}";
        }
        
        /// <summary>
        /// Implicit conversion from a <see href="https://docs.unity3d.com/Manual/class-GameObject.html">GameObject</see>.
        /// </summary>
        /// <param name="o">The <see href="https://docs.unity3d.com/Manual/class-GameObject.html">GameObject</see>.</param>
        /// <returns>The <see cref="KaijuEverythingVisionSensor"/> attached to the <see href="https://docs.unity3d.com/Manual/class-GameObject.html">GameObject</see> if there was one.</returns>
        public static implicit operator KaijuEverythingVisionSensor([NotNull] GameObject o) => o.GetComponent<KaijuEverythingVisionSensor>();
        
        /// <summary>
        /// Implicit conversion from a <see href="https://docs.unity3d.com/Manual/class-transform.html">transform</see>.
        /// </summary>
        /// <param name="t">The <see href="https://docs.unity3d.com/Manual/class-transform.html">transform</see>.</param>
        /// <returns>The <see cref="KaijuEverythingVisionSensor"/> attached to the <see href="https://docs.unity3d.com/Manual/class-transform.html">transform</see> if there was one.</returns>
        public static implicit operator KaijuEverythingVisionSensor([NotNull] Transform t) => t.GetComponent<KaijuEverythingVisionSensor>();
        
        /// <summary>
        /// Implicit conversion to a <see cref="KaijuAgent"/>.
        /// </summary>
        /// <param name="s">The <see cref="KaijuEverythingVisionSensor"/>.</param>
        /// <returns>The <see cref="KaijuAgent"/> attached to the <see cref="KaijuEverythingVisionSensor"/> if there was one.</returns>
        public static implicit operator KaijuAgent([NotNull] KaijuEverythingVisionSensor s) => s.Agent;
    }
}