# FlagVisionSensor

Sensor for Flags.

~~~csharp
public class FlagVisionSensor : KaijuVisionSensor<Flag>
~~~

[Package source](../../Samples~/Exercise%203%20-%20Capture%20the%20Flag/Sensors/FlagVisionSensor.cs)

<a id="KaijuSolutions_Agents_Exercises_CTF_FlagVisionSensor_DefaultObservables"></a>

### DefaultObservables

~~~csharp
protected override IEnumerable<Flag> DefaultObservables ()
~~~

If there are no explicitly defined observable objects, define how to query for default observables.

<a id="KaijuSolutions_Agents_Exercises_CTF_FlagVisionSensor_ToString"></a>

### ToString

~~~csharp
public override string ToString ()
~~~

Get a description of the object.
