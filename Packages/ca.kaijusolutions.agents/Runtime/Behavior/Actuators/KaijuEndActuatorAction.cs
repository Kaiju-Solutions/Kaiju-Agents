#if COM_UNITY_BEHAVIOR
using System;
using Unity.Behavior;
using Unity.Properties;

namespace KaijuSolutions.Agents.Behavior.Actuators
{
    /// <summary>
    /// Action to end an actuator.
    /// </summary>
    [Serializable]
    [GeneratePropertyBag]
    [NodeDescription(
        name: "End Actuator",
        story: "End actuator [actuator].",
        description: "End running an actuator. If the actuator is not assigned, will try to find the first actuator of the first agent variable found.",
        category: "Kaiju Agents/Actuators",
        id: "9e202450dff3a82616371d1145413747",
        icon: "Packages/ca.kaijusolutions.agents/Editor/Icon.png")
    ]
    public class KaijuEndActuatorAction : KaijuActuatorAction
    {
        /// <summary>
        /// OnStart is called when the node starts running.
        /// </summary>
        /// <returns>The status of the node.</returns>
        protected override Status OnStart()
        {
            // Can't end the actuator if it is not running.
            if (!ValidActuator() || !actuator.Value.IsRunning)
            {
                return Status.Failure;
            }
            
            // End the actuator.
            actuator.Value.End();
            return Status.Success;
        }
    }
}
#endif