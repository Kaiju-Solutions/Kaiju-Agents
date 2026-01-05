# Manager

All scenes will also have an agent manager which is automatically added to the scene as needed. This is a [singleton](https://en.wikipedia.org/wiki/Singleton_pattern "Singleton Pattern") meaning only one instance ever exists. This caches [agents](https://agents.kaijusolutions.ca/manual/agents.html "Agents") in the scene for quick access, spawning, and despawning of agents.

The manager is responsible for controlling all the [agents](https://agents.kaijusolutions.ca/manual/agents.html "Agents") in the scene. Every [`FixedUpdate()`](https://docs.unity3d.com/ScriptReference/MonoBehaviour.FixedUpdate.html) the manager will in order:

1. Run all automatic [sensors](https://agents.kaijusolutions.ca/manual/sensors.html "Sensors") on all [agents](https://agents.kaijusolutions.ca/manual/agents.html "Agents").
2. Run any [actuators](https://agents.kaijusolutions.ca/manual/actuators.html "Actuators") which have been set to do so.
3. Calculate the update [movement](https://agents.kaijusolutions.ca/manual/movement.html "Movement") velocity of all agents.