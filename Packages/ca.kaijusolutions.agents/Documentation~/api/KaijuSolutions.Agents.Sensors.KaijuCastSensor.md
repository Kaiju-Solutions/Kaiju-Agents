# KaijuCastSensor

KaijuSolutions.Agents.Sensors.KaijuSensor to perform ray or sphere casts. This will cast from this transform in the forward direction of this transform.

~~~csharp
public class KaijuCastSensor : KaijuSensor
~~~

[Package source](../../Runtime/Sensors/KaijuCastSensor.cs)

<a id="KaijuSolutions_Agents_Sensors_KaijuCastSensor_Distance"></a>

### Distance

~~~csharp
public float Distance { get; set; }
~~~

How far to cast.

<a id="KaijuSolutions_Agents_Sensors_KaijuCastSensor_Angle"></a>

### Angle

~~~csharp
public float Angle { get; set; }
~~~

What angle to cast along.

<a id="KaijuSolutions_Agents_Sensors_KaijuCastSensor_offset"></a>

### offset

~~~csharp
public float offset
~~~

Any vertical offset to add to the casts.

<a id="KaijuSolutions_Agents_Sensors_KaijuCastSensor_Casts"></a>

### Casts

~~~csharp
public int Casts { get; set; }
~~~

The number of casts to make. These will be evenly distributed across the angle, unless there is only one cast in which case it will cast directly forward.

<a id="KaijuSolutions_Agents_Sensors_KaijuCastSensor_Radius"></a>

### Radius

~~~csharp
public float Radius { get; set; }
~~~

The radius of the casts.

<a id="KaijuSolutions_Agents_Sensors_KaijuCastSensor_mask"></a>

### mask

~~~csharp
public LayerMask mask
~~~

What layers to collide with on the casts.

<a id="KaijuSolutions_Agents_Sensors_KaijuCastSensor_triggers"></a>

### triggers

~~~csharp
public QueryTriggerInteraction triggers
~~~

How casts should handle hitting triggers.

<a id="KaijuSolutions_Agents_Sensors_KaijuCastSensor_editorHit"></a>

### editorHit

~~~csharp
public Color editorHit
~~~

The visualizations color for hits in the editor.

<a id="KaijuSolutions_Agents_Sensors_KaijuCastSensor_editorMiss"></a>

### editorMiss

~~~csharp
public Color editorMiss
~~~

The visualizations color for misses in the editor.

<a id="KaijuSolutions_Agents_Sensors_KaijuCastSensor_HasHits"></a>

### HasHits

~~~csharp
public bool HasHits { get; }
~~~

If at least one ray has hit something.

<a id="KaijuSolutions_Agents_Sensors_KaijuCastSensor_HitsTotal"></a>

### HitsTotal

~~~csharp
public int HitsTotal { get; }
~~~

The total number of casts which hit something.

<a id="KaijuSolutions_Agents_Sensors_KaijuCastSensor_Hits"></a>

### Hits

~~~csharp
public IReadOnlyList<RaycastHit?> Hits { get; }
~~~

The data from left to right of what the rays have hit, with NULL entries being rays that did not hit.

<a id="KaijuSolutions_Agents_Sensors_KaijuCastSensor_Transforms"></a>

### Transforms

~~~csharp
public IEnumerable<Transform> Transforms { get; }
~~~

Get transforms for the Hits. Misses will be NULL.

<a id="KaijuSolutions_Agents_Sensors_KaijuCastSensor_ConnectedHits"></a>

### ConnectedHits

~~~csharp
public IEnumerable<RaycastHit?> ConnectedHits { get; }
~~~

The Hits data only for points which hit, removing all NULL entries.

<a id="KaijuSolutions_Agents_Sensors_KaijuCastSensor_ConnectedTransforms"></a>

### ConnectedTransforms

~~~csharp
public IEnumerable<Transform> ConnectedTransforms { get; }
~~~

et transforms for the ConnectedHits.

<a id="KaijuSolutions_Agents_Sensors_KaijuCastSensor_Nearest"></a>

### Nearest

~~~csharp
public Transform Nearest (out float nearest, bool normalize = false)
~~~

The nearest ConnectedTransforms instance to the KaijuSolutions.Agents.Sensors.KaijuSensor.Agent.

<a id="KaijuSolutions_Agents_Sensors_KaijuCastSensor_Nearest3"></a>

### Nearest3

~~~csharp
public Transform Nearest3 (out float nearest, bool normalize = false)
~~~

The nearest ConnectedTransforms instance across all axes to the KaijuSolutions.Agents.Sensors.KaijuSensor.Agent.

<a id="KaijuSolutions_Agents_Sensors_KaijuCastSensor_Farthest"></a>

### Farthest

~~~csharp
public Transform Farthest (out float farthest, bool normalize = false)
~~~

The farthest ConnectedTransforms instance to the KaijuSolutions.Agents.Sensors.KaijuSensor.Agent.

<a id="KaijuSolutions_Agents_Sensors_KaijuCastSensor_Farthest3"></a>

### Farthest3

~~~csharp
public Transform Farthest3 (out float farthest, bool normalize = false)
~~~

The farthest ConnectedTransforms instance across all axes to the KaijuSolutions.Agents.Sensors.KaijuSensor.Agent.

<a id="KaijuSolutions_Agents_Sensors_KaijuCastSensor_NearestPosition"></a>

### NearestPosition

~~~csharp
public Vector2 NearestPosition (bool normalize = false)
~~~

The nearest Positions instance to the KaijuSolutions.Agents.Sensors.KaijuSensor.Agent.

<a id="KaijuSolutions_Agents_Sensors_KaijuCastSensor_NearestPosition3"></a>

### NearestPosition3

~~~csharp
public Vector3 NearestPosition3 (bool normalize = false)
~~~

The nearest Positions instance to the KaijuSolutions.Agents.Sensors.KaijuSensor.Agent.

<a id="KaijuSolutions_Agents_Sensors_KaijuCastSensor_FarthestPosition"></a>

### FarthestPosition

~~~csharp
public Vector2 FarthestPosition (bool normalize = false)
~~~

The farthest Positions instance to the KaijuSolutions.Agents.Sensors.KaijuSensor.Agent.

<a id="KaijuSolutions_Agents_Sensors_KaijuCastSensor_FarthestPosition3"></a>

### FarthestPosition3

~~~csharp
public Vector3 FarthestPosition3 (bool normalize = false)
~~~

The farthest Positions instance to the KaijuSolutions.Agents.Sensors.KaijuSensor.Agent.

<a id="KaijuSolutions_Agents_Sensors_KaijuCastSensor_NearestDistance"></a>

### NearestDistance

~~~csharp
public float NearestDistance (bool normalize = false)
~~~

The nearest Distances instance to the KaijuSolutions.Agents.Sensors.KaijuSensor.Agent.

<a id="KaijuSolutions_Agents_Sensors_KaijuCastSensor_FarthestDistance"></a>

### FarthestDistance

~~~csharp
public float FarthestDistance (bool normalize = false)
~~~

The farthest Distances instance to the KaijuSolutions.Agents.Sensors.KaijuSensor.Agent.

<a id="KaijuSolutions_Agents_Sensors_KaijuCastSensor_Positions"></a>

### Positions

~~~csharp
public IEnumerable<Vector2> Positions (bool normalize = false)
~~~

The positions corresponding to the Hits, with Hits that missed being set to the maximum casting distance.

<a id="KaijuSolutions_Agents_Sensors_KaijuCastSensor_Positions3"></a>

### Positions3

~~~csharp
public IEnumerable<Vector3> Positions3 (bool normalize = false)
~~~

The positions corresponding to the Hits, with Hits that missed being set to the maximum casting distance.

<a id="KaijuSolutions_Agents_Sensors_KaijuCastSensor_Distances"></a>

### Distances

~~~csharp
public IEnumerable<float> Distances (bool normalize = false)
~~~

Get the distances of all rays.

<a id="KaijuSolutions_Agents_Sensors_KaijuCastSensor_Run"></a>

### Run

~~~csharp
protected override void Run ()
~~~

Run the KaijuSolutions.Agents.Sensors.KaijuSensor.

<a id="KaijuSolutions_Agents_Sensors_KaijuCastSensor_Cleanup"></a>

### Cleanup

~~~csharp
protected override void Cleanup ()
~~~

Perform any needed resetting of the KaijuSolutions.Agents.Sensors.KaijuSensor.

<a id="KaijuSolutions_Agents_Sensors_KaijuCastSensor_EditorVisualize"></a>

### EditorVisualize

~~~csharp
public override void EditorVisualize (Vector3 position)
~~~

Allow for visualizing in the editor. The position of the KaijuSolutions.Agents.Sensors.KaijuSensor.Agent.

<a id="KaijuSolutions_Agents_Sensors_KaijuCastSensor_ToString"></a>

### ToString

~~~csharp
public override string ToString ()
~~~

Get a description of the object.

~~~csharp
public static implicit operator KaijuCastSensor ([NotNull] GameObject o)
~~~

Implicit conversion from a GameObject.

~~~csharp
public static implicit operator KaijuCastSensor ([NotNull] Transform t)
~~~

Implicit conversion from a transform.

~~~csharp
public static implicit operator KaijuAgent ([NotNull] KaijuCastSensor s)
~~~

Implicit conversion to a KaijuSolutions.Agents.KaijuAgent.
