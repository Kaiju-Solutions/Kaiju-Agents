# KaijuEverythingVisionSensor

KaijuSolutions.Agents.Sensors.KaijuVisionSensor{T} based on transforms, allowing it to see anything. You can optionally filter objects by name to limit what is returned. While this KaijuSolutions.Agents.Sensors.KaijuSensor can be highly versatile, if performance is a concern, it is recommended to extend KaijuSolutions.Agents.Sensors.KaijuVisionSensor{T} for a specific component type you are interested in rather than using this.

~~~csharp
public class KaijuEverythingVisionSensor : KaijuVisionSensor<Transform>
~~~

[Package source](../../Runtime/Sensors/KaijuEverythingVisionSensor.cs)

<a id="KaijuSolutions_Agents_Sensors_KaijuEverythingVisionSensor_Matcher"></a>

### Matcher

~~~csharp
public List<KaijuAgentsMultiMatcher> Matcher { get; set; }
~~~

What to match names of the objects to provide extra filtering. Note this only applies to collecting default observables and not if you set any observables explicitly.

<a id="KaijuSolutions_Agents_Sensors_KaijuEverythingVisionSensor_DefaultObservables"></a>

### DefaultObservables

~~~csharp
protected override IEnumerable<Transform> DefaultObservables ()
~~~

If there are no explicitly defined observable objects, define how to query for default observables.

<a id="KaijuSolutions_Agents_Sensors_KaijuEverythingVisionSensor_ToString"></a>

### ToString

~~~csharp
public override string ToString ()
~~~

Get a description of the object.

~~~csharp
public static implicit operator KaijuEverythingVisionSensor ([NotNull] GameObject o)
~~~

Implicit conversion from a GameObject.

~~~csharp
public static implicit operator KaijuEverythingVisionSensor ([NotNull] Transform t)
~~~

Implicit conversion from a transform.

~~~csharp
public static implicit operator KaijuAgent ([NotNull] KaijuEverythingVisionSensor s)
~~~

Implicit conversion to a KaijuSolutions.Agents.KaijuAgent.
