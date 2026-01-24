# Changelog

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