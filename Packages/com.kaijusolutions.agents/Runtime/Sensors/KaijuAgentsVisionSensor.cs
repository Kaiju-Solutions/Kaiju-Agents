using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using UnityEngine;

namespace KaijuSolutions.Agents.Sensors
{
    /// <summary>
    /// <see cref="KaijuVisionSensor{T}"/> to see <see cref="KaijuAgent"/>s. By default, this is more efficient than standard <see cref="KaijuVisionSensor{T}"/>s as it accesses the cached <see cref="KaijuAgent"/>s from <see cref="KaijuAgentsManager.Agents"/>.
    /// </summary>
    [DefaultExecutionOrder(int.MinValue)]
#if UNITY_EDITOR
    [AddComponentMenu("Kaiju Solutions/Agents/Sensors/Kaiju Agents Vision Sensor", 4)]
    [Icon("Packages/com.kaijusolutions.agents/Editor/Icon.png")]
    [HelpURL("https://agents.kaijusolutions.ca/manual/sensors.html#agents-vision-sensor")]
#endif
    public class KaijuAgentsVisionSensor : KaijuVisionSensor<KaijuAgent>
    {
        /// <summary>
        /// If there are no explicitly defined observable objects, define how to query for default observables.
        /// </summary>
        /// <returns>All active <see cref="KaijuAgent"/>s from <see cref="KaijuAgentsManager.Agents"/>.</returns>
        protected override IEnumerable<KaijuAgent> DefaultObservables()
        {
            return KaijuAgentsManager.Agents;
        }
        
        /// <summary>
        /// Get a description of the object.
        /// </summary>
        /// <returns>A description of the object.</returns>
        public override string ToString()
        {
            return $"Kaiju Agents Vision Sensor {name} - Agent: {(Agent ? Agent.name : "None")} - Distance: {Distance} - Angle: {Angle} - Line-of-Sight: {(lineOfSight ? "Yes" : "No")} - Radius: {Radius}";
        }
        
        /// <summary>
        /// Implicit conversion from a <see href="https://docs.unity3d.com/Manual/class-GameObject.html">GameObject</see>.
        /// </summary>
        /// <param name="o">The <see href="https://docs.unity3d.com/Manual/class-GameObject.html">GameObject</see>.</param>
        /// <returns>The <see cref="KaijuAgentsVisionSensor"/> attached to the <see href="https://docs.unity3d.com/Manual/class-GameObject.html">GameObject</see> if there was one.</returns>
        public static implicit operator KaijuAgentsVisionSensor([NotNull] GameObject o) => o.GetComponent<KaijuAgentsVisionSensor>();
        
        /// <summary>
        /// Implicit conversion from a <see href="https://docs.unity3d.com/Manual/class-transform.html">transform</see>.
        /// </summary>
        /// <param name="t">The <see href="https://docs.unity3d.com/Manual/class-transform.html">transform</see>.</param>
        /// <returns>The <see cref="KaijuAgentsVisionSensor"/> attached to the <see href="https://docs.unity3d.com/Manual/class-transform.html">transform</see> if there was one.</returns>
        public static implicit operator KaijuAgentsVisionSensor([NotNull] Transform t) => t.GetComponent<KaijuAgentsVisionSensor>();
        
        /// <summary>
        /// Implicit conversion to a <see cref="KaijuAgent"/>.
        /// </summary>
        /// <param name="s">The <see cref="KaijuAgentsVisionSensor"/>.</param>
        /// <returns>The <see cref="KaijuAgent"/> attached to the <see cref="KaijuAgentsVisionSensor"/> if there was one.</returns>
        public static implicit operator KaijuAgent([NotNull] KaijuAgentsVisionSensor s) => s.Agent;
    }
}