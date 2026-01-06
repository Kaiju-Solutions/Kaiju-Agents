# Capture the Flag

This exercise pits two teams of [troopers](#trooper "Trooper") against each other in a game of capture the flag.

![Capture the Flag](https://agents.kaijusolutions.ca/img/capture-the-flag.png)

## Trooper Controller

The [`TrooperController` component](https://agents.kaijusolutions.ca/api/KaijuSolutions.Agents.Exercises.CTF.TrooperController.html "TrooperController") is provided to be a starting point for you to implement your behaviour design in for the [troopers](#trooper "Trooper").

## Trooper

The [`Trooper` component](https://agents.kaijusolutions.ca/api/KaijuSolutions.Agents.Exercises.CTF.Trooper.html "Trooper") has a given health value that if it reaches `0` will cause the [trooper](https://agents.kaijusolutions.ca/api/KaijuSolutions.Agents.Exercises.CTF.Trooper.html "Trooper") to be eliminated, respawning after a certain amount of time. Then are armed with a [blaster actuator](#blaster-actuator "Blaster Actuator"). [Troopers](https://agents.kaijusolutions.ca/api/KaijuSolutions.Agents.Exercises.CTF.Trooper.html "Trooper") will automatically interact with [pickups](#pickups "Pickups") they walk into. 

## Sensors

Six [sensors](https://agents.kaijusolutions.ca/manual/sensors.html "Sensors") have been provided to help you with your development. Unlike the [microbes exercise](https://agents.kaijusolutions.ca/manual/microbes.html "Microbe"), these [sensors](https://agents.kaijusolutions.ca/manual/sensors.html "Sensors") are not yet attached to the [troopers](#trooper "Trooper") prefab, and instead this is left for you to decide which combination is best to complete the exercise.

### Trooper Vision Sensor

The [`TrooperVisionSensor`](https://agents.kaijusolutions.ca/api/KaijuSolutions.Agents.Exercises.CTF.TrooperVisionSensor.html "TrooperVisionSensor") allows for detecting other [troopers](#trooper "Trooper").

#### Trooper Enemy Vision Sensor

The [`TrooperEnemyVisionSensor`](https://agents.kaijusolutions.ca/api/KaijuSolutions.Agents.Exercises.CTF.TrooperEnemyVisionSensor.html "TrooperEnemyVisionSensor") is a version of the [`TrooperVisionSensor`](https://agents.kaijusolutions.ca/api/KaijuSolutions.Agents.Exercises.CTF.TrooperVisionSensor.html "TrooperVisionSensor") which detects [troopers](#trooper "Trooper") on the enemy team.

#### Trooper Team Vision Sensor

The [`TrooperTeamVisionSensor`](https://agents.kaijusolutions.ca/api/KaijuSolutions.Agents.Exercises.CTF.TrooperTeamVisionSensor.html "TrooperTeamVisionSensor") is a version of the [`TrooperVisionSensor`](https://agents.kaijusolutions.ca/api/KaijuSolutions.Agents.Exercises.CTF.TrooperVisionSensor.html "TrooperVisionSensor") which detects [troopers](#trooper "Trooper") on the same team.

### Ammo Vision Sensor

The [`AmmoVisionSensor`](https://agents.kaijusolutions.ca/api/KaijuSolutions.Agents.Exercises.CTF.AmmoVisionSensor.html "AmmoVisionSensor") allows for detecting all [ammo pickups](#ammo-pickup "Ammo Pickup").

### Health Vision Sensor

The [`HealthVisionSensor`](https://agents.kaijusolutions.ca/api/KaijuSolutions.Agents.Exercises.CTF.HealthVisionSensor.html "HealthVisionSensor") allows for detecting all [health pickups](#health-pickup "Health Pickup").

### Flag Vision Sensor

The [`FlagVisionSensor`](https://agents.kaijusolutions.ca/api/KaijuSolutions.Agents.Exercises.CTF.FlagVisionSensor.html "FlagVisionSensor") allows for detecting both [flag](#flag "Flag") in the game.

## Blaster Actuator

The [`BlasterActuator`](https://agents.kaijusolutions.ca/api/KaijuSolutions.Agents.Exercises.CTF.BlasterActuator.html "BlasterActuator") is an version of an [attack actuator](https://agents.kaijusolutions.ca/manual/actuators.html#attack-actuator "BlasterActuator") which is capable of reducing the health of [troopers](#trooper "Trooper"). The [blaster](https://agents.kaijusolutions.ca/api/KaijuSolutions.Agents.Exercises.CTF.BlasterActuator.html "BlasterActuator") requires ammo, and with no ammo, the [blaster](https://agents.kaijusolutions.ca/api/KaijuSolutions.Agents.Exercises.CTF.BlasterActuator.html "BlasterActuator") will fail to attack. For your convenience, a [`BlasterActuator`](https://agents.kaijusolutions.ca/api/KaijuSolutions.Agents.Exercises.CTF.BlasterActuator.html "BlasterActuator") has been attached to the [trooper](#trooper "Trooper") prefab.

## Pickups

[Troopers](#trooper "Trooper") will automatically interact with pickups they walk into.

### Ammo Pickup

[`AmmoPickup`](https://agents.kaijusolutions.ca/api/KaijuSolutions.Agents.Exercises.CTF.AmmoPickup.html "AmmoPickup") instances will restore a [trooper's](#trooper "Trooper") [blater actuator's](#blaster-actuator "Blaster Actuator") ammo. After being used by a [trooper](#trooper "Trooper"), the [ammo pickup](https://agents.kaijusolutions.ca/api/KaijuSolutions.Agents.Exercises.CTF.AmmoPickup.html "AmmoPickup") will go on cooldown before it can be used again.

### Health Pickup

[`HealthPickup`](https://agents.kaijusolutions.ca/api/KaijuSolutions.Agents.Exercises.CTF.HealthPickup.html "HealthPickup") instances will restore a [trooper's](#trooper "Trooper") health. After being used by a [trooper](#trooper "Trooper"), the [health pickup](https://agents.kaijusolutions.ca/api/KaijuSolutions.Agents.Exercises.CTF.HealthPickup.html "HealthPickup") will go on cooldown before it can be used again.

### Flag

There are two [`Flag`](https://agents.kaijusolutions.ca/api/KaijuSolutions.Agents.Exercises.CTF.Flag.html "Flag") instances in the game, one for each team. [Troopers](#trooper "Trooper") interact with the [flags](https://agents.kaijusolutions.ca/api/KaijuSolutions.Agents.Exercises.CTF.Flag.html "Flag") in the following ways:

1. The [flag](https://agents.kaijusolutions.ca/api/KaijuSolutions.Agents.Exercises.CTF.Flag.html "Flag") is for the [trooper's](#trooper "Trooper") team:
   1. If the [flag](https://agents.kaijusolutions.ca/api/KaijuSolutions.Agents.Exercises.CTF.Flag.html "Flag") is already at its base, being where it starts the game at, nothing happens.
   2. Anywhere else, making contact with the [flag](https://agents.kaijusolutions.ca/api/KaijuSolutions.Agents.Exercises.CTF.Flag.html "Flag") when it is on the ground will return it to the base.
1. The [flag](https://agents.kaijusolutions.ca/api/KaijuSolutions.Agents.Exercises.CTF.Flag.html "Flag") is for the enemy team:
   1. The [flag](https://agents.kaijusolutions.ca/api/KaijuSolutions.Agents.Exercises.CTF.Flag.html "Flag") will be picked up. If returend to the [trooper's](#trooper "Trooper") base, being the spawn position of their team's [flag](https://agents.kaijusolutions.ca/api/KaijuSolutions.Agents.Exercises.CTF.Flag.html "Flag"), the enemy [flag](https://agents.kaijusolutions.ca/api/KaijuSolutions.Agents.Exercises.CTF.Flag.html "Flag") will be captured. Once captured, a [flag](https://agents.kaijusolutions.ca/api/KaijuSolutions.Agents.Exercises.CTF.Flag.html "Flag") will return back to its base. If eliminated while carrying a [flag](https://agents.kaijusolutions.ca/api/KaijuSolutions.Agents.Exercises.CTF.Flag.html "Flag"), the [flag](https://agents.kaijusolutions.ca/api/KaijuSolutions.Agents.Exercises.CTF.Flag.html "Flag") will be dropped for other [troopers](#trooper "Trooper") to interact with.

## Spawn Point

The [`SpawnPoint` components](https://agents.kaijusolutions.ca/api/KaijuSolutions.Agents.Exercises.CTF.SpawnPoint.html "SpawnPoint") indicate where [troopers](#trooper "Trooper") can spawn. Spawns are chosen by positions that are open first, and then those which are closest to the center of the level.

## Capture the Flag Manager

The [`CaptureTheFlagManager`](https://agents.kaijusolutions.ca/api/KaijuSolutions.Agents.Exercises.CTF.CaptureTheFlagManager.html "CaptureTheFlagManager") handles the configuration for the exercise.