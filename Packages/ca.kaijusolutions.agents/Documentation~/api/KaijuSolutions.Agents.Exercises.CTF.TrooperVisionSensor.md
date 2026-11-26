# TrooperVisionSensor

Sensor to get all Troopers.

~~~csharp
public class TrooperVisionSensor : KaijuVisionSensor<Trooper>
~~~

[Package source](../../Samples~/Exercise%203%20-%20Capture%20the%20Flag/Sensors/TrooperVisionSensor.cs)

<a id="KaijuSolutions_Agents_Exercises_CTF_TrooperVisionSensor_Attached"></a>

### Attached

~~~csharp
protected Trooper Attached
~~~

The Trooper this is attached to.

<a id="KaijuSolutions_Agents_Exercises_CTF_TrooperVisionSensor_OnEnable"></a>

### OnEnable

~~~csharp
protected override void OnEnable ()
~~~

This function is called when the object becomes enabled and active.

<a id="KaijuSolutions_Agents_Exercises_CTF_TrooperVisionSensor_DefaultObservables"></a>

### DefaultObservables

~~~csharp
protected override IEnumerable<Trooper> DefaultObservables ()
~~~

If there are no explicitly defined observable objects, define how to query for default observables.

<a id="KaijuSolutions_Agents_Exercises_CTF_TrooperVisionSensor_ToString"></a>

### ToString

~~~csharp
public override string ToString ()
~~~

Get a description of the object.
