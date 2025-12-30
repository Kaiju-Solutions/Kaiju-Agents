using System.Collections.Generic;
using UnityEngine;

namespace KaijuSolutions.Agents.Sensors
{
    /// <summary>
    /// Vision sensor to see <see cref="KaijuAgent"/>s. By default, this is more efficient than standard vision sensors as it accesses the cached <see cref="KaijuAgent"/>s from <see cref="KaijuAgentsManager.Agents"/>.
    /// </summary>
    [DefaultExecutionOrder(int.MinValue)]
#if UNITY_EDITOR
    [AddComponentMenu("Kaiju Solutions/Agents/Sensors/Kaiju Agents Vision Sensor", 4)]
    [Icon("Packages/com.kaijusolutions.agents/Editor/Icon.png")]
    [HelpURL("https://agents.kaijusolutions.ca/manual/getting-started.html")]
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
    }
}