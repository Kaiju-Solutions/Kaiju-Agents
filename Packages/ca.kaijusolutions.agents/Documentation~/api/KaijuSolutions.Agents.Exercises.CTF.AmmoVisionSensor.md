# AmmoVisionSensor

Sensor for AmmoPickups.

~~~csharp
public class AmmoVisionSensor : KaijuVisionSensor<AmmoPickup>
~~~

[Package source](../../Samples~/Exercise%203%20-%20Capture%20the%20Flag/Sensors/AmmoVisionSensor.cs)

<a id="KaijuSolutions_Agents_Exercises_CTF_AmmoVisionSensor_DefaultObservables"></a>

### DefaultObservables

~~~csharp
protected override IEnumerable<AmmoPickup> DefaultObservables ()
~~~

If there are no explicitly defined observable objects, define how to query for default observables.

<a id="KaijuSolutions_Agents_Exercises_CTF_AmmoVisionSensor_ToString"></a>

### ToString

~~~csharp
public override string ToString ()
~~~

Get a description of the object.
