# HealthVisionSensor

Sensor for HealthPickups.

~~~csharp
public class HealthVisionSensor : KaijuVisionSensor<HealthPickup>
~~~

[Package source](../../Samples~/Exercise%203%20-%20Capture%20the%20Flag/Sensors/HealthVisionSensor.cs)

<a id="KaijuSolutions_Agents_Exercises_CTF_HealthVisionSensor_DefaultObservables"></a>

### DefaultObservables

~~~csharp
protected override IEnumerable<HealthPickup> DefaultObservables ()
~~~

If there are no explicitly defined observable objects, define how to query for default observables.

<a id="KaijuSolutions_Agents_Exercises_CTF_HealthVisionSensor_ToString"></a>

### ToString

~~~csharp
public override string ToString ()
~~~

Get a description of the object.
