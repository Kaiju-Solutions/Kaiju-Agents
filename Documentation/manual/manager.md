# Agent simulation and the manager API

Add an agent to a scene and enter Play Mode. The default Entities world registers the agent and exposes its entity through `KaijuAgent.SimulationEntity` after the next simulation update. Existing scenes can keep their KaijuAgentsManager component. Static registry, identifier and pooling APIs remain available. Accessing the legacy Instance property explicitly creates the compatibility component.

The fixed-step system moves physics agents using their previous velocity, runs automatic sensors and actuators, gathers weighted movement requests, and integrates the new velocity with Burst. The frame system moves other agents and updates facing. Rigidbody, CharacterController, NavMeshAgent, custom movement callbacks and sensor queries use their UnityEngine implementations on the main thread.

## Entity-only agents

Create an entity with `KaijuSteering` and `Unity.Transforms.LocalTransform`. Set the initial transform including scale, DesiredVelocity in world XZ units per second, MaxSpeed, and Acceleration. Each fixed step clamps speed, applies the acceleration blend and integrates the local position. Use unparented entities for world-space motion. With zero acceleration, velocity follows the clamped request immediately. Systems providing input can use UpdateBefore(typeof(KaijuFixedSimulationSystem)) in the fixed-step group.

For a GameObject agent, set Control, MoveSpeed and MoveAcceleration on its MonoBehaviour. Its steering state is gathered each fixed step. Disabling an agent removes its simulation entity on the next simulation update. Re-read SimulationEntity after enabling a pooled agent.

## Steering, sensors and decisions

Add a KaijuMovementInput buffer for weighted steering. Each entry supplies a velocity, seek target or flee target and a weight. For point targets use Value in XZ coordinates. For moving targets set Target to an unparented entity with LocalTransform. Missing targets contribute zero. Inputs add to DesiredVelocity before the speed clamp.

A KaijuRangeSensor reads its Target and Radius and writes Detected during the fixed step. KaijuUtilityScore buffers hold action scores in selection order. Add KaijuDecision to receive Selected from KaijuDecisionSystem after steering. An empty buffer produces -1. Equal scores choose the first candidate. A MonoBehaviour utility brain supplies ScriptableObject consideration scores and receives the selected action through its existing enter, execute and exit callbacks.
