# Changelog

### 1.3.2

- Fixed exporting error related to the [`KaijuUtlityCurveConsideration`](https://agents.kaijusolutions.ca/api/KaijuSolutions.Agents.Utility.KaijuUtilityCurveConsideration.html "KaijuUtlityCurveConsideration").

### 1.3.1

- Improved clarity on the [Unity ML-Agents integration](https://agents.kaijusolutions.ca/manual/ml-agents.html "Unity ML-Agents").
- Fixed documentation generation errors.

### 1.3.0

- Added [Integration with Unity ML-Agents](https://agents.kaijusolutions.ca/manual/ml-agents.html "Unity ML-Agents").

### 1.2.1

- Improved documentation and fixed help links.
- Added additional events to the ["Microbes" exercise](https://agents.kaijusolutions.ca/manual/microbes.html "Microbes").
- Added relative steering control to agents.

### 1.2.0

- Moved [Unity Behavior integration](https://agents.kaijusolutions.ca/manual/behavior.html "Unity Behavior Integration") and [utility AI extension](https://agents.kaijusolutions.ca/manual/utility.html "Utility") directly into this package.
- Adjusted package naming from `com.kaijusolutions.agents` to `ca.kaijusolutions.agents` in preparation for future releases using [Unity Package Manager (UPM) publishing on the Asset Store](https://assetstore.unity.com/publishing/upm-publishing "Unity Package Manager (UPM) Publishing on the Asset Store"). Due to this change, you must first remove and then add Kaiju Agents back into your project.

### 1.1.7

- Added support for [Unity 6.4](https://docs.unity3d.com/6000.4/Documentation/Manual/WhatsNewUnity64.html "Unity 6.4").

### 1.1.6

- Added built-in package dependencies.

### 1.1.5

- Fixed a bug where [flags](https://agents.kaijusolutions.ca/manual/capture-the-flag.html#flag "Flag") in the ["Capture the Flag" exercise](https://agents.kaijusolutions.ca/manual/capture-the-flag.html "Capture the Flag") could change their base position at runtime when a trooper carrying them was eliminated.

### 1.1.4

- Ensure [flags](https://agents.kaijusolutions.ca/manual/capture-the-flag.html#flag "Flag") in the ["Capture the Flag" exercise](https://agents.kaijusolutions.ca/manual/capture-the-flag.html "Capture the Flag") do not transfer between agents when already being carried.

### 1.1.3

- Fixed [sensors](https://agents.kaijusolutions.ca/manual/sensors.html "Sensors") and [actuators](https://agents.kaijusolutions.ca/manual/actuators.html "Actuators") not registering properly at startup of [controllers](https://agents.kaijusolutions.ca/manual/controllers.html "Controllers").
- Creating a rigidbody [agent](https://agents.kaijusolutions.ca/manual/agents.html "Agents") with [`KaijuAgents.Spawn(KaijuAgentType, Nullable<Vector3>, Nullable<Quaternion>, Boolean, KaijuAgent, String, Nullable<Color>, Nullable<Color>, ICollection<String>)`](https://agents.kaijusolutions.ca/api/KaijuSolutions.Agents.KaijuAgents.html#KaijuSolutions_Agents_KaijuAgents_Spawn_KaijuSolutions_Agents_KaijuAgentType_System_Nullable_Vector3__System_Nullable_Quaternion__System_Boolean_KaijuSolutions_Agents_KaijuAgent_System_String_System_Nullable_Color__System_Nullable_Color__System_Collections_Generic_ICollection_System_String__ "KaijuAgents.Spawn(KaijuAgentType, Nullable<Vector3>, Nullable<Quaternion>, Boolean, KaijuAgent, String, Nullable<Color>, Nullable<Color>, ICollection<String>)") now matches the capsule collider with their visual shape.
- Extended the [trooper](https://agents.kaijusolutions.ca/manual/capture-the-flag.html#trooper "Trooper") and [flag](https://agents.kaijusolutions.ca/manual/capture-the-flag.html#flag "Flag") APIs of the ["Capture the Flag" exercise](https://agents.kaijusolutions.ca/manual/capture-the-flag.html "Capture the Flag").

### 1.1.2

- Fixed the [line-of-sight option](https://agents.kaijusolutions.ca/api/KaijuSolutions.Agents.Sensors.KaijuVisionSensor-1.html#KaijuSolutions_Agents_Sensors_KaijuVisionSensor_1_lineOfSight "KaijuVisionSensor - lineOfSight") on the [`KaijuVisionSensor`](https://agents.kaijusolutions.ca/api/KaijuSolutions.Agents.Sensors.KaijuVisionSensor-1.html "KaijuVisionSensor").

### 1.1.1

- Fixed the ["Capture the Flag" exercise](https://agents.kaijusolutions.ca/manual/capture-the-flag.html "Capture the Flag")'s [`FlagVisionSensor`](https://agents.kaijusolutions.ca/api/KaijuSolutions.Agents.Exercises.CTF.FlagVisionSensor.html "FlagVisionSensor") displaying as a [`HealthVisionSensor`](https://agents.kaijusolutions.ca/api/KaijuSolutions.Agents.Exercises.CTF.HealthVisionSensor.html "HealthVisionSensor") in the inspector.

### 1.1.0

- Added extended functionality to the [`KaijuVisionSensor`](https://agents.kaijusolutions.ca/manual/sensors.html#vision-sensor "KaijuVisionSensor") and [`KaijuCastSensor`](https://agents.kaijusolutions.ca/manual/sensors.html#vision-sensor "KaijuCastSensor").

### 1.0.4

- Fixed area movements not considering [identifiers](https://agents.kaijusolutions.ca/api/KaijuSolutions.Agents.Movement.KaijuAreaMovement.html#KaijuSolutions_Agents_Movement_KaijuAreaMovement_Identifiers "KaijuAreaMovement - Identifiers") properly.
- Added [identifiers to movement configurations](https://agents.kaijusolutions.ca/api/KaijuSolutions.Agents.Movement.KaijuMovementConfiguration.html#KaijuSolutions_Agents_Movement_KaijuMovementConfiguration_Identifiers "KaijuMovementConfiguration - Identifiers").

### 1.0.3

- Ensured always playing when out of focus to allow for testing agents in the background.

### 1.0.2

- Fixed potential infinite loop when listening for a movement to stop, and then starting a new movement during said listening callback.

### 1.0.1

- Fixed errors with exporting builds.
- Fixed scene reloading errors for the ["Microbes" exercise](https://agents.kaijusolutions.ca/manual/microbes.html "Microbes").

### 1.0.0

- Initial release.