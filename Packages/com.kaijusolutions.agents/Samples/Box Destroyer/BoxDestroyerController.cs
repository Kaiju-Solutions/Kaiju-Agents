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
    public class BoxDestroyerController : KaijuController
    {
        /// <summary>
        /// How far out to generate the wander circle.
        /// </summary>
        [Header("Wander")]
        [Tooltip("How far out to generate the wander circle.")]
        [Min(0)]
        [SerializeField]
        private float wanderDistance = 5;
        
        /// <summary>
        /// The radius of the wander circle.
        /// </summary>
        [Tooltip("The radius of the wander circle.")]
        [Min(0)]
        [SerializeField]
        private float wanderRadius = 1;
        
        /// <summary>
        /// The distance from a wall the <see cref="KaijuAgent"/> should maintain.
        /// </summary>
        [Header("Obstacle Avoidance")]
        [Tooltip("The distance from a wall the agent should maintain.")]
        [Min(float.Epsilon)]
        [SerializeField]
        private float avoidance = 2;
        
        /// <summary>
        /// The distance for rays.
        /// </summary>
        [Tooltip("The distance for rays.")]
        [Min(float.Epsilon)]
        [SerializeField]
        private float avoidanceDistance = 5;
        
        /// <summary>
        /// The distance of the side rays. Zero or less will use the <see cref="avoidanceDistance"/>.
        /// </summary>
        [Tooltip("The distance of the side rays. Zero or less will use the distance.")]
        [Min(0)]
        [SerializeField]
        private float avoidanceSideDistance;
        
        /// <summary>
        /// The angle for rays.
        /// </summary>
        [Tooltip("The angle for the rays.")]
        [SerializeField]
        private float avoidanceAngle = 15;
        
        /// <summary>
        /// The horizontal shift for the side rays.
        /// </summary>
        [Tooltip("The horizontal shift for the side rays.")]
        [SerializeField]
        private float avoidanceHorizontal;
        
        /// <summary>
        /// Cache the sensor.
        /// </summary>
        private KaijuEverythingVisionSensor _sensor;
        
        /// <summary>
        /// Cache the actuator.
        /// </summary>
        private KaijuEverythingAttackActuator _actuator;
        
        /// <summary>
        /// Start is called on the frame when a script is enabled just before any of the Update methods are called the first time. This function can be a coroutine.
        /// </summary>
        private void Start()
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
            // We know this is our only sensor for this basic agent, which is why we don't check its the same one.
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
            Agent.Wander(wanderDistance, wanderRadius);
            
            // Add an obstacle avoidance to ensure we do not wander out of the walled area. Start this at above the height of the boxes to ignore them.
            Agent.ObstacleAvoidance(avoidance, avoidanceDistance, avoidanceSideDistance, avoidanceAngle, 1.5f, avoidanceHorizontal, 1, false);
        }
    }
}