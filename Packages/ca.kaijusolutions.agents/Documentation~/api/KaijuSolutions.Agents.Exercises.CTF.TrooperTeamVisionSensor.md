# TrooperTeamVisionSensor

Sensor to get all friendly Troopers.

~~~csharp
public class TrooperTeamVisionSensor : TrooperVisionSensor
~~~

[Package source](../../Samples~/Exercise%203%20-%20Capture%20the%20Flag/Sensors/TrooperTeamVisionSensor.cs)

<a id="KaijuSolutions_Agents_Exercises_CTF_TrooperTeamVisionSensor_DefaultObservables"></a>

### DefaultObservables

~~~csharp
protected override IEnumerable<Trooper> DefaultObservables ()
~~~

If there are no explicitly defined observable objects, define how to query for default observables.

<a id="KaijuSolutions_Agents_Exercises_CTF_TrooperTeamVisionSensor_ToString"></a>

### ToString

~~~csharp
public override string ToString ()
~~~

Get a description of the object.
