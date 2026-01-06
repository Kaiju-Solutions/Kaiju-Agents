# Kaiju Agents

**Framework to quickly prototype AI agents in Unity aimed at researchers and educators.**

Kaiju Agents aims to provide an easy-to-learn yet powerful for developing and testing AI agents, aimed to speed up research and development and for education. Some of the key features of Kaiju Agents are:

- Modularized sensor-agent-actuator framework to allow for dynamic agent customization.
  - Have sensors run automatically or manually poll them.
  - Vision sensors based on line-of-sight and casting provided.
  - Casting-based actuator to destroy objects included.
- Full movement and navigation framework.
  - Includes seek, flee, pursue, evade, wander, separation, and obstacle avoidance steering behaviours.
  - Full navigation and pathfinding built on top of Unity's navigation meshes.
- Multiple agent types.
  - Have your agents move via a rigidbody, character controller, navigation mesh agent, or directly with the transform.
    - Pathfinding and navigation work with all agents types, not just the navigation mesh agents!
- Extensive visualizations.
  - Highly configurable visualizations for agents and their movements in the editor.
  - Implement custom visualizations for your own sensors and actuators.
- Event-driven architecture.
  - A multitude of C# events allow you to listen for all agent-related actions allowing for rapid and decoupled development.
- Powerful extension methods to speed up your development.
  - Helpful methods to easy work with vectors, positions, rotations, distances, area-checks, line-of-sight, and more.
- Samples and exercises.
  - Sample scenes provided showcasing all agent movements and an example agent controller.
  - Several exercises tailored to help you learn Kaiju Agents or use in an education environment.

## Installation


1. Install [Git](https://git-scm.com/install "Git Download").
2. Install [Unity](https://unity.com/download "Unity Download") version 6.3+
3. Create a new Unity project or open an existing one.
    - Alternatively, see the [template project](#template-project "Template Project").
4. In Unity, from the top menu, go to `Window > Package Management > Package Manager` and click the `+` icon in the top left followed by `Install package from git URL...`. Paste in one of the below options:

#### Latest Release - Recommended

```text
https://github.com/KaijuSolutions/Kaiju-Agents.git#release
```

#### Specific Release

Replace the `#release` in the latest release installation with the version number of the given [release](https://github.com/KaijuSolutions/Kaiju-Agents/releases "Kaiju Agents Releases").

#### Development

This will pull directly from the master branch, and is not recommended unless there is a specific feature needed not yet in the latest release.

```text
https://github.com/KaijuSolutions/Kaiju-Agents.git?path=/Packages/com.kaijusolutions.agents
```

## Template Project

The [Kaiju Agents template project](https://github.com/KaijuSolutions/Kaiju-Agents-Template "Kaiju Agents Template Project") comes with the latest release of Kaiju Agents installed and minimal other dependencies in the project. Simply [download or clone the template project repository](https://github.com/KaijuSolutions/Kaiju-Agents-Template "Kaiju Agents Template Project") to get started. Note that this still requires you install [Git](https://git-scm.com/install "Git Download") for the project to pull the latest release of Kaiju Agents into itself.

## Next Steps

See the [getting started documentation](https://agents.kaijusolutions.ca/manual/getting-started.html "Getting Started") to get up and running with Kaiju Agents.