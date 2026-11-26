---
name: kaiju-agents-cli
description: Author Kaiju Agents scenes, prefabs and navigation surfaces through Unity CLI and the official Pipeline package.
---

In the target Unity project's root run `unity status` and `unity command --query kaiju-agents`. For multiple Editors pin the project with --project-path. The command group accepts JSON options through --options. Read Documentation~/pipeline.md in the installed package for copyable shell examples.

Create a floor before baking navigation. Use place-wall for a carving obstacle, create-agent-prefab to create an asset under Assets, and place-agent to instantiate that prefab. The position object's y coordinate maps to scene Z. Use place-navmesh with build enabled or bake-navigation on existing surfaces. Save the edited scene through the Editor or Pipeline. Inspect the Console and scene after execution.

Use worldPosition {x,y,z} to author elevated agents, floors, or wall bases. Use check-route with start and goal world points before commanding a surface agent. For skill updates, preview install-skills with --check true. A modified result is a local edit and requires --force true to replace.

Create a family template with create-graph, then run compile-graph and validate-graph on its path. run-graph returns tick-indexed node and decision traces for isolated scenarios. Use trace-agent with start/read/stop in Play Mode to record real gameplay services.
