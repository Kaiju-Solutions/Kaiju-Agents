---
name: kaiju-agents
description: Create, steer, sense and pool Kaiju Agents in a Unity project, or integrate entity-only agents with its fixed-step simulation.
---

Locate ca.kaijusolutions.agents in the project's embedded packages or Unity package cache. Read Documentation~/manager.md for the Entities component contract and Documentation~/movement.md for steering behaviours.

For GameObject authoring, attach a concrete KaijuAgent and a controller to the agent. Set Control or use the agent's movement methods. Use KaijuAgents.Spawn when reusing agents and Despawn when returning them. Register gameplay responses through the controller callbacks. For physics or NavMesh movement use the corresponding agent subclass.

For ECS-only motion add KaijuSteering and LocalTransform to an entity in a local simulation world. Write DesiredVelocity in world XZ units per second and MaxSpeed before KaijuFixedSimulationSystem runs. Read Velocity after the fixed step. GameObject agents expose SimulationEntity after registration.

For path following on a baked surface, pass a NavMeshQueryFilter when the agent type or traversal costs matter. The synchronous FindPath extensions reuse a NavWorld handle on the main thread. Reuse the caller’s path list or corner array across queries.

Use PathFollow(Vector3) on a KaijuNavigationAgent for stacked floors and links. Check HasCompleteSurfaceRoute when a target might be disconnected. For open air add KaijuFreeFlight to a Transform or Rigidbody agent, then Seek a world-space Vector3 or set Control3. Use KaijuFlightSteering and optional KaijuFlightInput for an entity-only flyer. KaijuSphericalRangeSensor is independent of steering type. See the Floors and Flight sample for a linked route and authored air waypoints.

Prefab-backed spawning reuses the same authored prefab. Use FindNearby with a reusable list for range queries, TryGetNearest for a single observed target and TryFindSurfacePath for strict reachability without moving an agent.

Use KaijuGraphRunner for authored decision graphs and KaijuGraphSystem.Start for entity-only callers. Bind typed child variables explicitly, tie asynchronous completions to the execution instance and release owned actions on Cancel. See Documentation~/behavior-graph.md for mixed graph calls and ML policy ownership.
