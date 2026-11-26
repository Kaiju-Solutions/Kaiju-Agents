# TrooperEnemyVisionSensor

Sensor to get all enemy Troopers.

~~~csharp
public class TrooperEnemyVisionSensor : TrooperVisionSensor
~~~

[Package source](../../Samples~/Exercise%203%20-%20Capture%20the%20Flag/Sensors/TrooperEnemyVisionSensor.cs)

<a id="KaijuSolutions_Agents_Exercises_CTF_TrooperEnemyVisionSensor_DefaultObservables"></a>

### DefaultObservables

~~~csharp
protected override IEnumerable<Trooper> DefaultObservables ()
~~~

If there are no explicitly defined observable objects, define how to query for default observables.

<a id="KaijuSolutions_Agents_Exercises_CTF_TrooperEnemyVisionSensor_ToString"></a>

### ToString

~~~csharp
public override string ToString ()
~~~

Get a description of the object.
