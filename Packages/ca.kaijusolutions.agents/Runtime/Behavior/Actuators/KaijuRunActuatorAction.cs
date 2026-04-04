#if COM_UNITY_BEHAVIOR
using System;
using Unity.Behavior;
using Unity.Properties;

namespace KaijuSolutions.Agents.Behavior.Actuators
{
    /// <summary>
    /// Action to run an actuator.
    /// </summary>
    [Serializable]
    [GeneratePropertyBag]
    [NodeDescription(
        name: "Run Actuator",
        story: "Run actuator [actuator].",
        description: "Start running an actuator. This will report an interrupted if something else stops the actuator from running before it is complete. If the actuator is not assigned, will try to find the first actuator of the first agent variable found.",
        category: "Kaiju Agents/Actuators",
        id: "9e202450dff3a82616371d1145413746",
        icon: "Packages/ca.kaijusolutions.agents/Editor/Icon.png")
    ]
    public class KaijuRunActuatorAction : KaijuActuatorAction
    {
        /// <summary>
        /// Cache the actuator's status.
        /// </summary>
        private Status _actuatorStatus = Status.Failure;
        
        /// <summary>
        /// OnStart is called when the node starts running.
        /// </summary>
        /// <returns>The status of the node.</returns>
        protected override Status OnStart()
        {
            if (!ValidActuator())
            {
                return Status.Failure;
            }
            
            // Ensure there are no old callbacks.
            Unbind();
            
            // Start running the actuator and then bind callbacks.
            actuator.Value.Begin();
            actuator.Value.OnDone += OnDone;
            actuator.Value.OnFailed += OnFailed;
            actuator.Value.OnInterrupted += OnInterrupted;
            actuator.Value.OnDisabled += OnFailed;
            actuator.Value.OnEnabled += OnFailed;
            _actuatorStatus = Status.Running;
            return _actuatorStatus;
        }
        
        /// <summary>
        /// OnUpdate is called each frame while the node is running.
        /// </summary>
        /// <returns>The status of the node.</returns>
        protected override Status OnUpdate()
        {
            // Return the latest action, otherwise nothing.
            return ValidActuator() ? _actuatorStatus : Status.Failure;
        }
        
        /// <summary>
        /// OnEnd is called when the node has stopped running.
        /// </summary>
        protected override void OnEnd()
        {
            OnFailed();
        }
        
        /// <summary>
        /// Remove all bindings.
        /// </summary>
        private void Unbind()
        {
            actuator.Value.OnDone -= OnDone;
            actuator.Value.OnFailed -= OnFailed;
            actuator.Value.OnInterrupted -= OnInterrupted;
            actuator.Value.OnDisabled -= OnFailed;
            actuator.Value.OnEnabled -= OnFailed;
        }
        
        /// <summary>
        /// Callback for when this has successfully fully completed its action.
        /// </summary>
        private void OnDone()
        {
            _actuatorStatus = Status.Success;
            Unbind();
        }
        
        /// <summary>
        /// Callback for when this has failed its execution.
        /// </summary>
        private void OnFailed()
        {
            _actuatorStatus = Status.Failure;
            Unbind();
        }
        
        /// <summary>
        /// Callback for when this has been interrupted during its execution, cancelling the execution.
        /// </summary>
        private void OnInterrupted()
        {
            _actuatorStatus = Status.Interrupted;
            Unbind();
        }
        
        /// <summary>
        /// Get a description of the object.
        /// </summary>
        /// <returns>A description of the object.</returns>
        public override string ToString()
        {
            return $"Kaiju Run Actuator Action - Actuator: {(actuator.Value ? actuator.Value : "None")} - Status: {_actuatorStatus}";
        }
    }
}
#endif