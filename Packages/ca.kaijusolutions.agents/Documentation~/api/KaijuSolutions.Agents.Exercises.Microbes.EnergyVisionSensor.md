# EnergyVisionSensor

Sensor to detect EnergyPickups

~~~csharp
public class EnergyVisionSensor : KaijuVisionSensor<EnergyPickup>
~~~

[Package source](../../Samples~/Exercise%202%20-%20Microbes/Sensors/EnergyVisionSensor.cs)

<a id="KaijuSolutions_Agents_Exercises_Microbes_EnergyVisionSensor_DefaultObservables"></a>

### DefaultObservables

~~~csharp
protected override IEnumerable<EnergyPickup> DefaultObservables ()
~~~

If there are no explicitly defined observable objects, define how to query for default observables.

<a id="KaijuSolutions_Agents_Exercises_Microbes_EnergyVisionSensor_ToString"></a>

### ToString

~~~csharp
public override string ToString ()
~~~

Get a description of the object.
