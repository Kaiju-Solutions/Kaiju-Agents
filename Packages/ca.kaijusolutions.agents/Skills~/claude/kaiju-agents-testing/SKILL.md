---
name: kaiju-agents-testing
description: Verify agent registration, simulation and scene authoring in consumer Unity projects using Kaiju Agents.
---

Enable the package tests by adding ca.kaijusolutions.agents to the project's testables array in Packages/manifest.json. The package provides assemblies ca.kaijusolutions.agents.tests.editor and ca.kaijusolutions.agents.tests.runtime. Use the first in Edit Mode and the second in Play Mode or a desktop test player.

For a connected Editor discover test run and test status with Unity CLI. Filter by the package's assembly name. For asynchronous Play Mode tests poll to completion and verify a positive passed count. For gameplay regressions cover the fixed-step boundary, despawn followed by reuse, and scenes without a manager object. Do not assume an enabled GameObject already has a SimulationEntity before the next system update.

For spatial motion verify a target directly overhead, an unreachable balcony across a gap, and vertically stacked destinations joined by a link. Verify reuse resets climb input and velocity. Compare spherical and XZ sensing at identical horizontal coordinates.

For graph regressions assert child cancellation precedes handoff, planner exploration has zero gameplay side effects and pooled execution handles stay isolated. Use the Visual Decisions rescue graph and identity policy for mixed-family player and inference checks.
