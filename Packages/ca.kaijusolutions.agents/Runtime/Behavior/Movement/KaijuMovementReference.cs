#if COM_UNITY_BEHAVIOR
using KaijuSolutions.Agents.Movement;
using UnityEngine;

namespace KaijuSolutions.Agents.Behavior.Movement
{
    /// <summary>
    /// Helper class to allow us to serialize movements as variables in graphs.
    /// </summary>
#if UNITY_EDITOR
    [Icon("Packages/ca.kaijusolutions.agents/Editor/Icon.png")]
    [HelpURL("https://agents.kaijusolutions.ca")]
#endif
    public class KaijuMovementReference : ScriptableObject
    {
        /// <summary>
        /// The movement.
        /// </summary>
        private KaijuMovement _movement;
        
        /// <summary>
        /// Update the movement reference.
        /// </summary>
        /// <param name="movement">The movement.</param>
        public void Set(KaijuMovement movement)
        {
            // Nothing to do if the same movement.
            if (_movement == movement)
            {
                return;
            }
            
            // Stop the current movement if assigning a new one.
            Stop();
            
            // Assign the new movement.
            _movement = movement;
        }
        
        /// <summary>
        /// Stop the movement.
        /// </summary>
        /// <returns>If the movement was stopped or not.</returns>
        public bool Stop()
        {
            return _movement != null && _movement.Agent != null && _movement.Agent.Stop(_movement);
        }
        
        /// <summary>
        /// Get a description of the object.
        /// </summary>
        /// <returns>A description of the object.</returns>
        public override string ToString()
        {
            return $"{name} - Kaiju Movement Reference - Movement: {_movement}";
        }
    }
}
#endif