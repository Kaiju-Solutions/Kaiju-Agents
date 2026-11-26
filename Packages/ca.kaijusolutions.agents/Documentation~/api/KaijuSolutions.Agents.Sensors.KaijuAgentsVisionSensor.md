# KaijuAgentsVisionSensor

KaijuSolutions.Agents.Sensors.KaijuVisionSensor{T} to see KaijuSolutions.Agents.KaijuAgents. By default, this is more efficient than standard KaijuSolutions.Agents.Sensors.KaijuVisionSensor{T}s as it accesses the cached KaijuSolutions.Agents.KaijuAgents from KaijuAgentsManager.Agents.

~~~csharp
public class KaijuAgentsVisionSensor : KaijuVisionSensor<KaijuAgent>
~~~

[Package source](../../Runtime/Sensors/KaijuAgentsVisionSensor.cs)

<a id="KaijuSolutions_Agents_Sensors_KaijuAgentsVisionSensor_useNearbyQuery"></a>

### useNearbyQuery

~~~csharp
public bool useNearbyQuery
~~~

<a id="KaijuSolutions_Agents_Sensors_KaijuAgentsVisionSensor_NearbyCandidatesExamined"></a>

### NearbyCandidatesExamined

~~~csharp
public int NearbyCandidatesExamined { get; private set; }
~~~

<a id="KaijuSolutions_Agents_Sensors_KaijuAgentsVisionSensor_DefaultObservables"></a>

### DefaultObservables

~~~csharp
protected override IEnumerable<KaijuAgent> DefaultObservables ()
~~~

If there are no explicitly defined observable objects, define how to query for default observables.

<a id="KaijuSolutions_Agents_Sensors_KaijuAgentsVisionSensor_Cleanup"></a>

### Cleanup

~~~csharp
protected override void Cleanup ()
~~~

<a id="KaijuSolutions_Agents_Sensors_KaijuAgentsVisionSensor_ToString"></a>

### ToString

~~~csharp
public override string ToString ()
~~~

Get a description of the object.

~~~csharp
public static implicit operator KaijuAgentsVisionSensor ([NotNull] GameObject o)
~~~

Implicit conversion from a GameObject.

~~~csharp
public static implicit operator KaijuAgentsVisionSensor ([NotNull] Transform t)
~~~

Implicit conversion from a transform.

~~~csharp
public static implicit operator KaijuAgent ([NotNull] KaijuAgentsVisionSensor s)
~~~

Implicit conversion to a KaijuSolutions.Agents.KaijuAgent.
