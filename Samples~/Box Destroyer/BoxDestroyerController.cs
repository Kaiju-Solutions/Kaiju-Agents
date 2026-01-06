using KaijuSolutions.Agents.Actuators;
using KaijuSolutions.Agents.Extensions;
using KaijuSolutions.Agents.Movement;
using KaijuSolutions.Agents.Sensors;
using UnityEngine;

namespace KaijuSolutions.Agents.Samples.BoxDestroyer
{
    /// <summary>
    /// Simple <see cref="KaijuController"/> to destroy boxes.
    /// </summary>
    [DisallowMultipleComponent]
    [HelpURL("https://agents.kaijusolutions.ca/manual/box-destroyer.html")]
    [AddComponentMenu("Kaiju Solutions/Agents/Samples/Box Destroyer Controller", 16)]
    public class BoxDestroyerController : KaijuController
    {
        /// <summary>
        /// Cache the sensor.
        /// </summary>
        private KaijuEverythingVisionSensor _sensor;
        
        /// <summary>
        /// Cache the actuator.
        /// </summary>
        private KaijuEverythingAttackActuator _actuator;
        
        /// <summary>
        /// Callback for when the <see cref="KaijuController.Agent"/> has finishing becoming enabled.
        /// </summary>
        protected override void OnEnabled()
        {
            // Get the sensor and actuator once so we do not need to repeatedly call for them.
            _sensor = Agent.GetSensor<KaijuEverythingVisionSensor>();
            _actuator = Agent.GetActuator<KaijuEverythingAttackActuator>();
            
            // Start an initial search.
            StartSearching();
        }
        
        /// <summary>
        /// Callback for when a <see cref="KaijuSensor"/> has been run.
        /// </summary>
        /// <param name="sensor">The <see cref="KaijuSensor"/>.</param>
        protected override void OnSense(KaijuSensor sensor)
        {
            // Nothing for us to do if we did not see any boxes.
            // We know this is our only sensor for this basic agent, which is why we don't check if it is the same one.
            if (_sensor.ObservedCount < 1)
            {
                return;
            }
            
            // Shut off the sensor in the meantime to save resources as we have chosen our target.
            _sensor.automatic = false;
            
            // Choose the nearest box.
            Transform nearest = Position.Nearest(_sensor.Observed, out float _);
            
            // Seek towards the nearest observed box to destroy it.
            // Give a buffer around the box so our attack can hit.
            // The attack distance itself is three to give an extra safety buffer.
            Agent.Seek(nearest, 2f);
            
            // While the seek with the agent's automatic look turned on will look at this, it may not finish if we have a set look speed.
            // So, set it explicitly as well.
            Agent.LookTransform = nearest;
        }
        
        /// <summary>
        /// Callback for when a <see cref="KaijuMovement"/> has stopped.
        /// </summary>
        /// <param name="movement">The <see cref="KaijuMovement"/>.</param>
        protected override void OnMovementStopped(KaijuMovement movement)
        {
            // Once the seek has finished, we know we are close enough to the box to destroy it.
            if (movement is KaijuSeekMovement)
            {
                _actuator.Begin();
            }
        }
        
        /// <summary>
        /// Callback for when an <see cref="KaijuActuator"/> has successfully fully completed its action.
        /// </summary>
        /// <param name="actuator">The <see cref="KaijuActuator"/>.</param>
        protected override void OnActuatorDone(KaijuActuator actuator)
        {
            // If we successfully destroyed the box, we should search for another one.
            StartSearching();
        }
        
        /// <summary>
        /// Callback for when an <see cref="KaijuActuator"/> has failed its execution.
        /// </summary>
        /// <param name="actuator">The <see cref="KaijuActuator"/>.</param>
        protected override void OnActuatorFailed(KaijuActuator actuator)
        {
            // If we failed, we somehow missed!
            // This should not happen given the positioning of the actuator, but, physics can break at times, so it does happen!
            StartSearching();
        }
        
        /// <summary>
        /// Start searching for a box to destroy.
        /// </summary>
        private void StartSearching()
        {
            // Automatically scan for boxes, and we will simply listen for it.
            _sensor.automatic = true;
            
            // Start wandering around until a box is found.
            Agent.Wander();
            
            // Add an obstacle avoidance to ensure we do not wander out of the walled area. Start this at above the height of the boxes to ignore them.
            // Don't clear so we don't erase the wandering behaviour we just added.
            Agent.ObstacleAvoidance(clear: false);
        }
    }
}