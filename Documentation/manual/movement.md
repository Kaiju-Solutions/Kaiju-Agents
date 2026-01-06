# Movement

Movements control how [agents](https://agents.kaijusolutions.ca/manual/agents.md "Agents") move through the world. For setting movement behaviours on [agents](https://agents.kaijusolutions.ca/manual/agents.md "Agents"), see the [movement section of the agents documentation](https://agents.kaijusolutions.ca/manual/agents.md#movement "Agents").

![Movements](https://agents.kaijusolutions.ca/img/movement.png)

## Configuration

A [`KaijuMovementConfiguration` ScriptableObject](https://agents.kaijusolutions.ca/api/KaijuSolutions.Agents.Movement.KaijuMovementConfiguration.html "KaijuMovementConfiguration") can be assigned to an [agent](https://agents.kaijusolutions.ca/manual/agents.md "Agents") to control the default parameters of the various movement behaviours. To create a [`KaijuMovementConfiguration`](https://agents.kaijusolutions.ca/api/KaijuSolutions.Agents.Movement.KaijuMovementConfiguration.html "KaijuMovementConfiguration"), right click in the [project window](https://docs.unity3d.com/Manual/ProjectView.html "Project Window") and go to "Create > Kaiju Solutions > Agents > Kaiju Movement Configuration" and name the file. Then, assign it to your [agent](https://agents.kaijusolutions.ca/manual/agents.md "Agents") in the [inspector](https://docs.unity3d.com/Manual/UsingTheInspector.html "Inspector Window").

## Types

The following movement types are provided with Kaiju Agents. Each has corresponding methods on [agent](https://agents.kaijusolutions.ca/manual/agents.md "Agents") to perform the given movement.

### Seek

Move directly towards a target. It is the inverse of [flee](#flee "Flee").

### Pursue

Moves towards a target's calculated future position based on extrapolating where it will be in the future given its current and past position. The movement towards this calculated future position is the same as a [seek](#seek "Seek") movement. It is the inverse of [evade](#evade "Evade").

### Flee

Move directly away from a target. It is the inverse of [seek](#seek "Seek").

### Evade

Moves away from a target's calculated future position based on extrapolating where it will be in the future given its current and past position. The movement away from this calculated future position is the same as a [flee](#flee "Flee") movement. It is the inverse of [pursue](#pursue "Pursue").

### Wander

This will randomly move the agent based on choosing a random point along a circle's circumference which is projected a given distance ahead of it. This movement towards the random point is the same as [seek](#seek "Seek").

### Separation

Separation aims to maintain a radius of space from other [agents](https://agents.kaijusolutions.ca/manual/agents.md "Agents"). A position based on all other [agents](https://agents.kaijusolutions.ca/manual/agents.md "Agents") currently currently within its separation radius is calculated at which point a weighted [seek](#seek "Seek") is performed to reach it.

### Obstacle Avoidance

Obstacle avoidance casts rays to detect obstacles. If one is detected, the normal of the closest ray is used to calculate a point away from the obstacle for the [agent](https://agents.kaijusolutions.ca/manual/agents.md "Agents") to [seek](#seek "Seek") to.

### Path Following

Path following calculates a path towards a target and the performs subsequent [seek](#seek "Seek") movements on each point along the path. This requires navigation data to be baked in the world. To learn more, see the [Unity AI navigation documentation](https://docs.unity3d.com/Packages/com.unity.ai.navigation@latest "AI Navigation").