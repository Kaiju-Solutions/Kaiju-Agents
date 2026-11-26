# MicrobeVisionSensor

Sensor to detect Microbes

~~~csharp
public class MicrobeVisionSensor : KaijuVisionSensor<Microbe>
~~~

[Package source](../../Samples~/Exercise%202%20-%20Microbes/Sensors/MicrobeVisionSensor.cs)

<a id="KaijuSolutions_Agents_Exercises_Microbes_MicrobeVisionSensor_DefaultObservables"></a>

### DefaultObservables

~~~csharp
protected override IEnumerable<Microbe> DefaultObservables ()
~~~

If there are no explicitly defined observable objects, define how to query for default observables.

<a id="KaijuSolutions_Agents_Exercises_Microbes_MicrobeVisionSensor_ToString"></a>

### ToString

~~~csharp
public override string ToString ()
~~~

Get a description of the object.
