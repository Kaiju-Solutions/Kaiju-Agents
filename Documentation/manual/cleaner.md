# Cleaner

In this exercise, you will need to make an [agent](https://agents.kaijusolutions.ca/manual/agents.md "Agents") with any needed [sensors](https://agents.kaijusolutions.ca/manual/sensors.md "Sensors") or [actuators](https://agents.kaijusolutions.ca/manual/actuators.md "Actuators") to keep a set of [floor tiles](#floor "Floor") clean. To do this, it is recommended you make and attach a [controller](https://agents.kaijusolutions.ca/manual/controller.md "Controller") to your [agent](https://agents.kaijusolutions.ca/manual/agents.md "Agents").

![Cleaner](https://agents.kaijusolutions.ca/img/cleaner.png)

## Floor

A [`Floor` component](https://agents.kaijusolutions.ca/api/KaijuSolutions.Agents.Exercises.Cleaner.Floor.html "Floor") is attached to every floor tile in the scene. Given a chance value, every step a tile may randomly become dirty. You should design a [sensor](https://agents.kaijusolutions.ca/manual/sensors.md "Sensors") designed to detect dirty [floor tiles](https://agents.kaijusolutions.ca/api/KaijuSolutions.Agents.Exercises.Cleaner.Floor.html "Floor"), and an [actuator](https://agents.kaijusolutions.ca/manual/actuators.md "Actuators") to clean them.