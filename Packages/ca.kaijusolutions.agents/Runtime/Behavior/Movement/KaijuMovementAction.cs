#if COM_UNITY_BEHAVIOR
using System;
using KaijuSolutions.Agents.Movement;
using Unity.Behavior;
using Unity.Properties;
using UnityEngine;

namespace KaijuSolutions.Agents.Behavior.Movement
{
    /// <summary>
    /// Class for movement actions.
    /// </summary>
    /// <typeparam name="T">The type of movement this is for.</typeparam>
    [Serializable]
    [GeneratePropertyBag]
    public abstract class KaijuMovementAction<T> : KaijuAgentGraphAction where T : KaijuMovement
    {
        /// <summary>
        /// The movement configuration to use.
        /// </summary>
        [Tooltip("The movement configuration to use. If not assigned, it will use the one assigned to the agent, which itself will fallback to default values if none is assigned.")]
        [SerializeReference]
        public BlackboardVariable<KaijuMovementConfiguration> configuration;
        
        /// <summary>
        /// The movement.
        /// </summary>
        protected T Movement { get; private set; }
        
        /// <summary>
        /// The current running status.
        /// </summary>
        private Status _status = Status.Failure;
        
        /// <summary>
        /// OnStart is called when the node starts running.
        /// </summary>
        /// <returns>The status of the node.</returns>
        protected override Status OnStart()
        {
            // Get rid of the existing movement if needed.
            DisposeMovement();
            
            _status = base.OnStart();
            if (_status != Status.Success)
            {
                return _status;
            }
            
            // Assign the movement.
            Movement = CreateMovement();
            
            // If the movement was created, bind to it. Otherwise, this is a failure.
            _status = Status.Running;
            if (Movement == null)
            {
                _status = Status.Failure;
                return Status.Failure;
            }
            
            // Update the reference which can allow us to stop a movement.
            BlackboardVariable<KaijuMovementReference> movement = GetMovementReference();
            if (movement != null)
            {
                if (movement.Value == null)
                {
                    movement.Value = ScriptableObject.CreateInstance<KaijuMovementReference>();
                }
                
                movement.Value.Set(Movement);
            }
            
            Movement.OnStopped += OnStopped;
            return _status;
        }
        
        /// <summary>
        /// Get the movement instance to configure.
        /// </summary>
        /// <returns>The movement reference variable.</returns>
        protected abstract BlackboardVariable<KaijuMovementReference> GetMovementReference();
        
        /// <summary>
        /// See if this stopped as was intended or if it was interrupted by something telling it to stop.
        /// </summary>
        private void OnStopped()
        {
            _status = Movement.Done() ? Status.Success : Status.Interrupted;
        }
        
        /// <summary>
        /// OnUpdate is called each frame while the node is running.
        /// </summary>
        /// <returns>The status of the node.</returns>
        protected override Status OnUpdate()
        {
            return agent.Value ? _status == Status.Success || Movement == null || Movement.Agent != agent.Value ? Status.Success : _status : Status.Failure;
        }
        
        /// <summary>
        /// OnEnd is called when the node has stopped running.
        /// </summary>
        protected override void OnEnd()
        {
            DisposeMovement();
            _status = Status.Uninitialized;
        }
        
        /// <summary>
        /// Ensure an existing movement is disposed of.
        /// </summary>
        protected void DisposeMovement()
        {
            // Nothing to do if NULL.
            if (Movement == null)
            {
                return;
            }
            
            Movement.OnStopped -= OnStopped;
            
            // If the agent is assigned, stop that movement if this was interrupted.
            if (_status == Status.Interrupted && agent.Value)
            {
                agent.Value.Stop(Movement as KaijuMovement);
            }
            
            // Null the value for the future.
            Movement = null;
        }
        
        /// <summary>
        /// Create the movement.
        /// </summary>
        /// <returns>The movement that was created.</returns>
        protected abstract T CreateMovement();
        
        /// <summary>
        /// Get a description of the object.
        /// </summary>
        /// <returns>A description of the object.</returns>
        public override string ToString()
        {
            return $"Kaiju Movement Action - Agent: {(agent.Value ? agent.Value : "None")} - Configuration: {(configuration.Value ? configuration.Value : "None")} - Type: {typeof(T).Name} - Movement: {(Movement ? Movement : "None")} - Status: {_status}";
        }
    }
}
#endif