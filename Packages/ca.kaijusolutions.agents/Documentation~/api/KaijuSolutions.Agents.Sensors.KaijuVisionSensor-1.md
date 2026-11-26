# KaijuVisionSensor

KaijuSolutions.Agents.Sensors.KaijuSensor to allow for visual detection of a component type.

~~~csharp
public abstract class KaijuVisionSensor <T> : KaijuSensor where T : Component
~~~

[Package source](../../Runtime/Sensors/KaijuVisionSensor.cs)

<a id="KaijuSolutions_Agents_Sensors_KaijuVisionSensor_1_Distance"></a>

### Distance

~~~csharp
public float Distance { get; set; }
~~~

How far vision can extend.

<a id="KaijuSolutions_Agents_Sensors_KaijuVisionSensor_1_spatialVision"></a>

### spatialVision

~~~csharp
public bool spatialVision
~~~

<a id="KaijuSolutions_Agents_Sensors_KaijuVisionSensor_1_Angle"></a>

### Angle

~~~csharp
public float Angle { get; set; }
~~~

What angle the vision detection should cover.

<a id="KaijuSolutions_Agents_Sensors_KaijuVisionSensor_1_lineOfSight"></a>

### lineOfSight

~~~csharp
public bool lineOfSight
~~~

If line-of-sight checks should be made for the vision. Turning off line-of-sight checks will return items within the view arc based on the angle and distance.

<a id="KaijuSolutions_Agents_Sensors_KaijuVisionSensor_1_Radius"></a>

### Radius

~~~csharp
public float Radius { get; set; }
~~~

The radius of the line-of-sight checks.

<a id="KaijuSolutions_Agents_Sensors_KaijuVisionSensor_1_offset"></a>

### offset

~~~csharp
public float offset
~~~

Any vertical offset to add to the line-of-sight checks. This can be useful if you for instance have targets which are a few units high but their origins are at their bases.

<a id="KaijuSolutions_Agents_Sensors_KaijuVisionSensor_1_mask"></a>

### mask

~~~csharp
public LayerMask mask
~~~

What layers to collide with on the line-of-sight checks.

<a id="KaijuSolutions_Agents_Sensors_KaijuVisionSensor_1_triggers"></a>

### triggers

~~~csharp
public QueryTriggerInteraction triggers
~~~

How line-of-sight checks should handle hitting triggers.

<a id="KaijuSolutions_Agents_Sensors_KaijuVisionSensor_1_editorColor"></a>

### editorColor

~~~csharp
public Color editorColor
~~~

The visualizations color in the editor.

<a id="KaijuSolutions_Agents_Sensors_KaijuVisionSensor_1_editorFromAgent"></a>

### editorFromAgent

~~~csharp
public bool editorFromAgent
~~~

If the visualizations in the editor for the line-of-sight checks should come from the KaijuSolutions.Agents.Sensors.KaijuSensor.Agent's position or from the KaijuSolutions.Agents.Sensors.KaijuSensor's position. The range and view arc are always drawn from the KaijuSolutions.Agents.Sensors.KaijuSensor.Agent's Y height and the KaijuSolutions.Agents.Sensors.KaijuSensor's X and Z positions.

<a id="KaijuSolutions_Agents_Sensors_KaijuVisionSensor_1_observables"></a>

### observables

~~~csharp
public IEnumerable<T> observables
~~~

The objects which this can detect.

<a id="KaijuSolutions_Agents_Sensors_KaijuVisionSensor_1_HasObserved"></a>

### HasObserved

~~~csharp
public bool HasObserved { get; }
~~~

If at least one instance has been Observed.

<a id="KaijuSolutions_Agents_Sensors_KaijuVisionSensor_1_ObservedCount"></a>

### ObservedCount

~~~csharp
public int ObservedCount { get; }
~~~

The number of Observed items.

<a id="KaijuSolutions_Agents_Sensors_KaijuVisionSensor_1_Observed"></a>

### Observed

~~~csharp
public IReadOnlyCollection<T> Observed { get; }
~~~

All observed items.

<a id="KaijuSolutions_Agents_Sensors_KaijuVisionSensor_1_Nearest"></a>

### Nearest

~~~csharp
public T Nearest (out float nearest, bool normalize = false)
~~~

The nearest Observed instance to the KaijuSolutions.Agents.Sensors.KaijuSensor.Agent.

<a id="KaijuSolutions_Agents_Sensors_KaijuVisionSensor_1_Nearest3"></a>

### Nearest3

~~~csharp
public T Nearest3 (out float nearest, bool normalize = false)
~~~

The nearest Observed instance across all axes to the KaijuSolutions.Agents.Sensors.KaijuSensor.Agent.

<a id="KaijuSolutions_Agents_Sensors_KaijuVisionSensor_1_Farthest"></a>

### Farthest

~~~csharp
public T Farthest (out float farthest, bool normalize = false)
~~~

The farthest Observed instance to the KaijuSolutions.Agents.Sensors.KaijuSensor.Agent.

<a id="KaijuSolutions_Agents_Sensors_KaijuVisionSensor_1_Farthest3"></a>

### Farthest3

~~~csharp
public T Farthest3 (out float farthest, bool normalize = false)
~~~

The farthest Observed instance across all axes to the KaijuSolutions.Agents.Sensors.KaijuSensor.Agent.

<a id="KaijuSolutions_Agents_Sensors_KaijuVisionSensor_1_NearestPosition"></a>

### NearestPosition

~~~csharp
public Vector2 NearestPosition (bool normalize = false)
~~~

The nearest Observed instance position to the KaijuSolutions.Agents.Sensors.KaijuSensor.Agent.

<a id="KaijuSolutions_Agents_Sensors_KaijuVisionSensor_1_NearestPosition3"></a>

### NearestPosition3

~~~csharp
public Vector3 NearestPosition3 (bool normalize = false)
~~~

The nearest Observed instance position to the KaijuSolutions.Agents.Sensors.KaijuSensor.Agent.

<a id="KaijuSolutions_Agents_Sensors_KaijuVisionSensor_1_FarthestPosition"></a>

### FarthestPosition

~~~csharp
public Vector2 FarthestPosition (bool normalize = false)
~~~

The farthest Observed instance position to the KaijuSolutions.Agents.Sensors.KaijuSensor.Agent.

<a id="KaijuSolutions_Agents_Sensors_KaijuVisionSensor_1_FarthestPosition3"></a>

### FarthestPosition3

~~~csharp
public Vector3 FarthestPosition3 (bool normalize = false)
~~~

The farthest Observed instance position to the KaijuSolutions.Agents.Sensors.KaijuSensor.Agent.

<a id="KaijuSolutions_Agents_Sensors_KaijuVisionSensor_1_SortDistance"></a>

### SortDistance

~~~csharp
public T[] SortDistance (bool farthest = false, KaijuAngleSortMode? mode = null)
~~~

Sort Observed instances by distance to the KaijuSolutions.Agents.Sensors.KaijuSensor.Agent.

<a id="KaijuSolutions_Agents_Sensors_KaijuVisionSensor_1_SortDistance3"></a>

### SortDistance3

~~~csharp
public T[] SortDistance3 (bool farthest = false, KaijuAngleSortMode? mode = null)
~~~

Sort Observed instances by distance across all axes to the KaijuSolutions.Agents.Sensors.KaijuSensor.Agent.

<a id="KaijuSolutions_Agents_Sensors_KaijuVisionSensor_1_SortAngle"></a>

### SortAngle

~~~csharp
public T[] SortAngle (KaijuAngleSortMode mode = KaijuAngleSortMode.Magnitude, bool? farthest = false)
~~~

Sort Observed instances by angle to the KaijuSolutions.Agents.Sensors.KaijuSensor.Agent.

~~~csharp
public int SortDistance ([NotNull] T[] cache, bool farthest = false, KaijuAngleSortMode? mode = null)
~~~

Sort Observed instances by distance to the KaijuSolutions.Agents.Sensors.KaijuSensor.Agent, keeping only the first instances which fit into a cache.

~~~csharp
public int SortDistance3 ([NotNull] T[] cache, bool farthest = false, KaijuAngleSortMode? mode = null)
~~~

Sort Observed instances by distance across all axes to the KaijuSolutions.Agents.Sensors.KaijuSensor.Agent, keeping only the first instances which fit into a cache.

~~~csharp
public int SortAngle ([NotNull] T[] cache, KaijuAngleSortMode mode = KaijuAngleSortMode.Magnitude, bool? farthest = false)
~~~

Sort Observed instances by angle to the KaijuSolutions.Agents.Sensors.KaijuSensor.Agent, keeping only the first instances which fit into a cache.

<a id="KaijuSolutions_Agents_Sensors_KaijuVisionSensor_1_SortDistancePosition"></a>

### SortDistancePosition

~~~csharp
public Vector2[] SortDistancePosition (bool farthest = false, KaijuAngleSortMode? mode = null, bool normalize = false)
~~~

Sort Observed instances by distance to the KaijuSolutions.Agents.Sensors.KaijuSensor.Agent.

<a id="KaijuSolutions_Agents_Sensors_KaijuVisionSensor_1_SortDistancePosition3"></a>

### SortDistancePosition3

~~~csharp
public Vector3[] SortDistancePosition3 (bool farthest = false, KaijuAngleSortMode? mode = null, bool normalize = false)
~~~

Sort Observed instances by distance to the KaijuSolutions.Agents.Sensors.KaijuSensor.Agent.

<a id="KaijuSolutions_Agents_Sensors_KaijuVisionSensor_1_SortDistance3Position"></a>

### SortDistance3Position

~~~csharp
public Vector2[] SortDistance3Position (bool farthest = false, KaijuAngleSortMode? mode = null, bool normalize = false)
~~~

Sort Observed instances by distance across all axes to the KaijuSolutions.Agents.Sensors.KaijuSensor.Agent.

<a id="KaijuSolutions_Agents_Sensors_KaijuVisionSensor_1_SortDistance3Position3"></a>

### SortDistance3Position3

~~~csharp
public Vector3[] SortDistance3Position3 (bool farthest = false, KaijuAngleSortMode? mode = null, bool normalize = false)
~~~

Sort Observed instances by distance across all axes to the KaijuSolutions.Agents.Sensors.KaijuSensor.Agent.

<a id="KaijuSolutions_Agents_Sensors_KaijuVisionSensor_1_SortAnglePosition"></a>

### SortAnglePosition

~~~csharp
public Vector2[] SortAnglePosition (KaijuAngleSortMode mode = KaijuAngleSortMode.Magnitude, bool? farthest = false, bool normalize = false)
~~~

Sort Observed instances by angle to the KaijuSolutions.Agents.Sensors.KaijuSensor.Agent.

<a id="KaijuSolutions_Agents_Sensors_KaijuVisionSensor_1_SortAnglePosition3"></a>

### SortAnglePosition3

~~~csharp
public Vector3[] SortAnglePosition3 (KaijuAngleSortMode mode = KaijuAngleSortMode.Magnitude, bool? farthest = false, bool normalize = false)
~~~

Sort Observed instances by angle to the KaijuSolutions.Agents.Sensors.KaijuSensor.Agent.

~~~csharp
public int SortDistancePosition ([NotNull] Vector2[] cache, bool farthest = false, KaijuAngleSortMode? mode = null, bool normalize = false)
~~~

Sort Observed instances by distance to the KaijuSolutions.Agents.Sensors.KaijuSensor.Agent, keeping only the first instances which fit into a cache.

~~~csharp
public int SortDistancePosition ([NotNull] Vector3[] cache, bool farthest = false, KaijuAngleSortMode? mode = null, bool normalize = false)
~~~

Sort Observed instances by distance to the KaijuSolutions.Agents.Sensors.KaijuSensor.Agent, keeping only the first instances which fit into a cache.

~~~csharp
public int SortDistance3Position ([NotNull] Vector2[] cache, bool farthest = false, KaijuAngleSortMode? mode = null, bool normalize = false)
~~~

Sort Observed instances by distance across all axes to the KaijuSolutions.Agents.Sensors.KaijuSensor.Agent, keeping only the first instances which fit into a cache.

~~~csharp
public int SortDistance3Position ([NotNull] Vector3[] cache, bool farthest = false, KaijuAngleSortMode? mode = null, bool normalize = false)
~~~

Sort Observed instances by distance across all axes to the KaijuSolutions.Agents.Sensors.KaijuSensor.Agent, keeping only the first instances which fit into a cache.

~~~csharp
public int SortAnglePosition ([NotNull] Vector2[] cache, KaijuAngleSortMode mode = KaijuAngleSortMode.Magnitude, bool? farthest = false, bool normalize = false)
~~~

Sort Observed instances by angle to the KaijuSolutions.Agents.Sensors.KaijuSensor.Agent, keeping only the first instances which fit into a cache.

~~~csharp
public int SortAnglePosition3 ([NotNull] Vector3[] cache, KaijuAngleSortMode mode = KaijuAngleSortMode.Magnitude, bool? farthest = false, bool normalize = false)
~~~

Sort Observed instances by angle to the KaijuSolutions.Agents.Sensors.KaijuSensor.Agent, keeping only the first instances which fit into a cache.

<a id="KaijuSolutions_Agents_Sensors_KaijuVisionSensor_1_CandidatesExamined"></a>

### CandidatesExamined

~~~csharp
public int CandidatesExamined { get; private set; }
~~~

<a id="KaijuSolutions_Agents_Sensors_KaijuVisionSensor_1_SightQueries"></a>

### SightQueries

~~~csharp
public int SightQueries { get; private set; }
~~~

<a id="KaijuSolutions_Agents_Sensors_KaijuVisionSensor_1_TryGetNearest"></a>

### TryGetNearest

~~~csharp
public bool TryGetNearest (out T target)
~~~

Find the closest observation using this sensor's distance mode.

<a id="KaijuSolutions_Agents_Sensors_KaijuVisionSensor_1_DefaultObservables"></a>

### DefaultObservables

~~~csharp
protected virtual IEnumerable<T> DefaultObservables ()
~~~

If there are no explicitly defined observable objects, define how to query for default observables.

<a id="KaijuSolutions_Agents_Sensors_KaijuVisionSensor_1_Run"></a>

### Run

~~~csharp
protected override void Run ()
~~~

Run the KaijuSolutions.Agents.Sensors.KaijuSensor.

<a id="KaijuSolutions_Agents_Sensors_KaijuVisionSensor_1_Cleanup"></a>

### Cleanup

~~~csharp
protected override void Cleanup ()
~~~

Perform any needed resetting of the KaijuSolutions.Agents.Sensors.KaijuSensor.

<a id="KaijuSolutions_Agents_Sensors_KaijuVisionSensor_1_EditorVisualize"></a>

### EditorVisualize

~~~csharp
public override void EditorVisualize (Vector3 position)
~~~

Allow for visualizing in the editor. The position of the KaijuSolutions.Agents.Sensors.KaijuSensor.Agent.

<a id="KaijuSolutions_Agents_Sensors_KaijuVisionSensor_1_ToString"></a>

### ToString

~~~csharp
public override string ToString ()
~~~

Get a description of the object.

~~~csharp
public static implicit operator KaijuVisionSensor<T> ([NotNull] GameObject o)
~~~

Implicit conversion from a GameObject.

~~~csharp
public static implicit operator KaijuVisionSensor<T> ([NotNull] Transform t)
~~~

Implicit conversion from a transform.

~~~csharp
public static implicit operator KaijuAgent ([NotNull] KaijuVisionSensor<T> s)
~~~

Implicit conversion to a KaijuSolutions.Agents.KaijuAgent.
