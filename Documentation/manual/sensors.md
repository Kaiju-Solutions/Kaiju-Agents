# Sensors

Sensors are all extended from the [`KaijuSensor` class](https://agents.kaijusolutions.ca/api/KaijuSolutions.Agents.Sensors.KaijuSensor.html "KaijuSensor") implementing the [`Run()` method](https://agents.kaijusolutions.ca/api/KaijuSolutions.Agents.Sensors.KaijuSensor.html#KaijuSolutions_Agents_Sensors_KaijuSensor_Run "KaijuSensor - Run"). Sensors must be directly attached to or within the child [GameObjects](https://docs.unity3d.com/Manual/class-GameObject.html "GameObject") of an [agent](https://agents.kaijusolutions.ca/manual/agents.md "Agents"). Sensors can be run either automatically or manually executed via the [`Sense()` method](https://agents.kaijusolutions.ca/api/KaijuSolutions.Agents.Sensors.KaijuSensor.html#KaijuSolutions_Agents_Sensors_KaijuSensor_Sense "KaijuSensor - Sense").

## Vision Sensor

The [`KaijuVisionSensor`](https://agents.kaijusolutions.ca/api/KaijuSolutions.Agents.Sensors.KaijuVisionSensor-1.html "KaijuVisionSensor") is the base class for implementing vision detecting for a specific [component](https://docs.unity3d.com/Manual/Components.html "Component") type. It allows for setting a view distance, view angle, and if line-of-sight checks should be performed. If line-of-sight checks are disabled, any objects of the [component](https://docs.unity3d.com/Manual/Components.html "Component") type in the viewing area defined by the distance and angle will be detected. All detected items can be accessed via the [`Observed` property](https://agents.kaijusolutions.ca/api/KaijuSolutions.Agents.Sensors.KaijuVisionSensor-1.html#KaijuSolutions_Agents_Sensors_KaijuVisionSensor_1_Observed "KaijuVisionSensor - Observed").

### Agents Vision Sensor

The [`KaijuAgentsVisionSensor`](https://agents.kaijusolutions.ca/api/KaijuSolutions.Agents.Sensors.KaijuAgentsVisionSensor.html "KaijuAgentsVisionSensor") is an implementation of the [`KaijuVisionSensor`](https://agents.kaijusolutions.ca/api/KaijuSolutions.Agents.Sensors.KaijuVisionSensor-1.html "KaijuVisionSensor") for detecting all [agents](https://agents.kaijusolutions.ca/manual/agents.html "Agents"). This can optionally choose to query for only specific [agents](https://agents.kaijusolutions.ca/manual/agents.html "Agents") based on identifiers.

![Agents Vision Sensor](https://agents.kaijusolutions.ca/img/vision.png)

### Everything Vision Sensor

The [`KaijuEverythingVisionSensor`](https://agents.kaijusolutions.ca/api/KaijuSolutions.Agents.Sensors.KaijuEverythingVisionSensor.html "KaijuEverythingVisionSensor") checks for all objects in the scene. You can filter by name to get specific [transforms](https://docs.unity3d.com/Manual/class-transform.html "Transform").

## Cast Sensor

The [`KaijuCastSensor`](https://agents.kaijusolutions.ca/api/KaijuSolutions.Agents.Sensors.KaijuCastSensor.html "KaijuCastSensor") works by casting a set number of rays for a set distance evenly spread out over a set angle. What the rays hit can be accessed via the [`Hits` property](https://agents.kaijusolutions.ca/api/KaijuSolutions.Agents.Sensors.KaijuCastSensor.html#KaijuSolutions_Agents_Sensors_KaijuCastSensor_Hits "KaijuCastSensor - Hits").

![Cast Sensor](https://agents.kaijusolutions.ca/img/cast.png)
### Agent vision in crowds

Default agent vision shares an XZ candidate grid during each fixed sensing pass. Exact range, cone and line-of-sight checks still apply to each candidate, including Y when spatial vision is enabled. The grid captures cell membership on first use in the pass. Turn off **Use Nearby Query** for a sensor whose callbacks teleport other agents during that pass. Explicit target lists take precedence. Manual queries outside a sensing pass use current positions.

Use `KaijuAgentsManager.FindNearby(origin, radius, list, spherical)` to fill a reusable list and `sensor.TryGetNearest(out var target)` to select the nearest observation in the sensor's distance mode. `CandidatesExamined` and `SightQueries` describe the most recent scan. Object and position sorting overloads accepting caller buffers reuse their sort storage.
