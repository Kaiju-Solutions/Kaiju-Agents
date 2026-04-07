#if COM_UNITY_BEHAVIOR
using System;
using System.Linq;
using KaijuSolutions.Agents.Sensors;
using Unity.Behavior;
using Unity.Properties;

namespace KaijuSolutions.Agents.Behavior.Sensors
{
    /// <summary>
    /// Action to run a <see cref="KaijuSolutions.Agents.Sensors.KaijuCastSensor"/>.
    /// </summary>
    [Serializable]
    [GeneratePropertyBag]
    [NodeDescription(
        name: "Cast Sense",
        story: "Cast sense [observed] with [sensor].",
        description: "Sense for any GameObject using a cast sensor. If the sensor is not assigned, will try to find the first sensor of this type on of the first agent variable found.",
        category: "Kaiju Agents/Sensors",
        id: "9e202450dff3a82616371d1145413748",
        icon: "Packages/ca.kaijusolutions.agents/Editor/Icon.png")
    ]
    public class KaijuCastSensorAction : KaijuSensorMultipleGameObjectAction<KaijuCastSensor>
    {
        /// <summary>
        /// OnUpdate is called each frame while the node is running.
        /// </summary>
        /// <returns>The status of the node.</returns>
        protected override Status HandleSensor()
        {
            // Keep running if we have not yet hit anything.
            if (sensor.Value.HitsTotal < 1)
            {
                return Status.Running;
            }
            
            // Cache the observation and indicate this has been successful.
            GetIdeal(sensor.Value.Hits.Where(x => x.HasValue).Select(x => x.Value.collider.gameObject));
            return Status.Success;
        }
        
        /// <summary>
        /// Get a description of the object.
        /// </summary>
        /// <returns>A description of the object.</returns>
        public override string ToString()
        {
            return $"Kaiju Cast Sensor Action - Sensor: {(sensor.Value ? sensor.Value : "None")} - Observed: {(observed.Value ? observed.Value : "None")} - {(nearest.Value ? "Nearest" : "Farthest")}";
        }
    }
}
#endif