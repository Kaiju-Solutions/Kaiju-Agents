# Microbes

This exercise puts you in charge of designing [microbes](#microbe "Microbe") which can mate with and eat each other.

![Microbes](https://agents.kaijusolutions.ca/img/microbes.png)

## Microbe Controller

The [`MicrobeController` component](https://agents.kaijusolutions.ca/api/KaijuSolutions.Agents.Exercises.Microbes.MicrobeController.html "MicrobeController") is provided to be a starting point for you to implement your behaviour design in for the [microbes](#microbe "Microbe").

## Microbe

The [`Microbe` component](https://agents.kaijusolutions.ca/api/KaijuSolutions.Agents.Exercises.Microbes.Microbe.html "Microbe") contains all aspects of the [microbes](https://agents.kaijusolutions.ca/api/KaijuSolutions.Agents.Exercises.Microbes.Microbe.html "Microbe") for this exercise. [Microbes](https://agents.kaijusolutions.ca/api/KaijuSolutions.Agents.Exercises.Microbes.Microbe.html "Microbe") require energy to survive, and it will decay at a given rate over time. Once a [microbe](https://agents.kaijusolutions.ca/api/KaijuSolutions.Agents.Exercises.Microbes.Microbe.html "Microbe") hits `0` energy, it will be despawned. Each [microbe](https://agents.kaijusolutions.ca/api/KaijuSolutions.Agents.Exercises.Microbes.Microbe.html "Microbe") has a unique [identifier](https://agents.kaijusolutions.ca/manual/agents.html#identifiers "Identifiers") corresponding to their color. [Microbes](https://agents.kaijusolutions.ca/api/KaijuSolutions.Agents.Exercises.Microbes.Microbe.html "Microbe") can mate with other [microbes](https://agents.kaijusolutions.ca/api/KaijuSolutions.Agents.Exercises.Microbes.Microbe.html "Microbe") that have the same [identifier](https://agents.kaijusolutions.ca/manual/agents.html#identifiers "Identifiers") as them, and can eat [microbes](https://agents.kaijusolutions.ca/api/KaijuSolutions.Agents.Exercises.Microbes.Microbe.html "Microbe") with different identifiers. Mating has a cooldown timer, and eating another [microbe](https://agents.kaijusolutions.ca/api/KaijuSolutions.Agents.Exercises.Microbes.Microbe.html "Microbe") requires having more energy than the other [microbes](https://agents.kaijusolutions.ca/api/KaijuSolutions.Agents.Exercises.Microbes.Microbe.html "Microbe"). Eating another [microbe](https://agents.kaijusolutions.ca/api/KaijuSolutions.Agents.Exercises.Microbes.Microbe.html "Microbe") will add that [microbe](https://agents.kaijusolutions.ca/api/KaijuSolutions.Agents.Exercises.Microbes.Microbe.html "Microbe")'s energy to the energy of the [microbe](https://agents.kaijusolutions.ca/api/KaijuSolutions.Agents.Exercises.Microbes.Microbe.html "Microbe") which ate it. A newly spawned [microbe](https://agents.kaijusolutions.ca/api/KaijuSolutions.Agents.Exercises.Microbes.Microbe.html "Microbe") as a result of mating will have an energy level equal to the average of its two parents. Mating and eating are both automatically handled when microbes collide with each other.

## Energy Pickup

[`EnergyPickup`](https://agents.kaijusolutions.ca/api/KaijuSolutions.Agents.Exercises.Microbes.EnergyPickup.html "EnergyPickup") instances randomly spawn around the level, and when a [microbe](#microbe "Microbe") makes contact with one it will add a given energy level to the [microbe](#microbe "Microbe"). After being used by a [microbe](#microbe "Microbe"), the [energy pickup](https://agents.kaijusolutions.ca/api/KaijuSolutions.Agents.Exercises.Microbes.EnergyPickup.html "EnergyPickup") will despawn.

## Sensors

Two [sensors](https://agents.kaijusolutions.ca/manual/sensors.html "Sensors") have been provided to help you with your development. Each of these sensors have already been attached to the [microbe](#microbe "Microbe") prefab.

### Microbe Vision Sensor

The [`MicrobeVisionSensor`](https://agents.kaijusolutions.ca/api/KaijuSolutions.Agents.Exercises.Microbes.MicrobeVisionSensor.html "MicrobeVisionSensor") allows for detecting other [microbes](#microbe "Microbe").

### Energy Vision Sensor

The [`EnergyVisionSensor`](https://agents.kaijusolutions.ca/api/KaijuSolutions.Agents.Exercises.Microbes.EnergyVisionSensor.html "EnergyVisionSensor") allows for detecting [energy pickups](#energy-pickup "Energy Pickups").

## Microbe Manager

The [`MicrobeManager`](https://agents.kaijusolutions.ca/api/KaijuSolutions.Agents.Exercises.Microbes.MicrobeManager.html "MicrobeManager") handles the configuration for the exercise.