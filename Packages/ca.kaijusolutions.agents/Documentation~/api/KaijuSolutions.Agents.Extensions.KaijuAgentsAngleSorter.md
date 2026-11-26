# KaijuAgentsAngleSorter

Comparer class to sort by angle in degrees from a position towards a target around the global Y axis. Used in the extension methods found in KaijuAgentsSortAngle.

~~~csharp
public sealed class KaijuAgentsAngleSorter : IComparer<Vector2>, IComparer<Vector3>, IComparer<Transform>, IComparer<Component>, IComparer<GameObject>
~~~

[Package source](../../Runtime/Extensions/KaijuAgentsAngleSorter.cs)

<a id="KaijuSolutions_Agents_Extensions_KaijuAgentsAngleSorter_Position3"></a>

### Position3

~~~csharp
public Vector3 Position3 { get; set; }
~~~

The position to compare against.

<a id="KaijuSolutions_Agents_Extensions_KaijuAgentsAngleSorter_PositionTransform"></a>

### PositionTransform

~~~csharp
public Transform PositionTransform { set; }
~~~

The position to compare against. The forward direction will be taken from this as well.

<a id="KaijuSolutions_Agents_Extensions_KaijuAgentsAngleSorter_PositionComponent"></a>

### PositionComponent

~~~csharp
public Component PositionComponent { set; }
~~~

The position to compare against. The forward direction will be taken from this as well.

<a id="KaijuSolutions_Agents_Extensions_KaijuAgentsAngleSorter_PositionGameObject"></a>

### PositionGameObject

~~~csharp
public GameObject PositionGameObject { set; }
~~~

The position to compare against. The forward direction will be taken from this as well.

<a id="KaijuSolutions_Agents_Extensions_KaijuAgentsAngleSorter_Position"></a>

### Position

~~~csharp
public Vector2 Position
~~~

The position to compare against.

<a id="KaijuSolutions_Agents_Extensions_KaijuAgentsAngleSorter_Forward"></a>

### Forward

~~~csharp
public Vector2 Forward
~~~

The forward direction to compare with.

<a id="KaijuSolutions_Agents_Extensions_KaijuAgentsAngleSorter_Mode"></a>

### Mode

~~~csharp
public KaijuAngleSortMode Mode
~~~

How to handle sorting.

<a id="KaijuSolutions_Agents_Extensions_KaijuAgentsAngleSorter_Farthest"></a>

### Farthest

~~~csharp
public bool? Farthest
~~~

How to handle breaking ties by distance. NULL means no tie breaking, false for nearest distance, and true for farthest distance.

<a id="KaijuSolutions_Agents_Extensions_KaijuAgentsAngleSorter_KaijuAgentsAngleSorter"></a>

### KaijuAgentsAngleSorter

~~~csharp
public KaijuAgentsAngleSorter ()
~~~

Create the sorter.

~~~csharp
public KaijuAgentsAngleSorter (Vector2 position, Vector2 forward, KaijuAngleSortMode mode = KaijuAngleSortMode.Magnitude, bool? farthest = null)
~~~

Create the sorter.

~~~csharp
public KaijuAgentsAngleSorter (Vector2 position, Vector3 forward, KaijuAngleSortMode mode = KaijuAngleSortMode.Magnitude, bool? farthest = null)
~~~

Create the sorter.

~~~csharp
public KaijuAgentsAngleSorter (Vector2 position, [NotNull] Transform forward, KaijuAngleSortMode mode = KaijuAngleSortMode.Magnitude, bool? farthest = null)
~~~

Create the sorter.

~~~csharp
public KaijuAgentsAngleSorter (Vector2 position, [NotNull] Component forward, KaijuAngleSortMode mode = KaijuAngleSortMode.Magnitude, bool? farthest = null)
~~~

Create the sorter.

~~~csharp
public KaijuAgentsAngleSorter (Vector2 position, [NotNull] GameObject forward, KaijuAngleSortMode mode = KaijuAngleSortMode.Magnitude, bool? farthest = null)
~~~

Create the sorter.

~~~csharp
public KaijuAgentsAngleSorter (Vector3 position, Vector2 forward, KaijuAngleSortMode mode = KaijuAngleSortMode.Magnitude, bool? farthest = null)
~~~

Create the sorter.

~~~csharp
public KaijuAgentsAngleSorter (Vector3 position, Vector3 forward, KaijuAngleSortMode mode = KaijuAngleSortMode.Magnitude, bool? farthest = null)
~~~

Create the sorter.

~~~csharp
public KaijuAgentsAngleSorter (Vector3 position, [NotNull] Transform forward, KaijuAngleSortMode mode = KaijuAngleSortMode.Magnitude, bool? farthest = null)
~~~

Create the sorter.

~~~csharp
public KaijuAgentsAngleSorter (Vector3 position, [NotNull] Component forward, KaijuAngleSortMode mode = KaijuAngleSortMode.Magnitude, bool? farthest = null)
~~~

Create the sorter.

~~~csharp
public KaijuAgentsAngleSorter (Vector3 position, [NotNull] GameObject forward, KaijuAngleSortMode mode = KaijuAngleSortMode.Magnitude, bool? farthest = null)
~~~

Create the sorter.

~~~csharp
public KaijuAgentsAngleSorter ([NotNull] Transform position, Vector2 forward, KaijuAngleSortMode mode = KaijuAngleSortMode.Magnitude, bool? farthest = null)
~~~

Create the sorter.

~~~csharp
public KaijuAgentsAngleSorter ([NotNull] Transform position, Vector3 forward, KaijuAngleSortMode mode = KaijuAngleSortMode.Magnitude, bool? farthest = null)
~~~

Create the sorter.

~~~csharp
public KaijuAgentsAngleSorter ([NotNull] Transform position, [NotNull] Transform forward, KaijuAngleSortMode mode = KaijuAngleSortMode.Magnitude, bool? farthest = null)
~~~

Create the sorter.

~~~csharp
public KaijuAgentsAngleSorter ([NotNull] Transform position, [NotNull] Component forward, KaijuAngleSortMode mode = KaijuAngleSortMode.Magnitude, bool? farthest = null)
~~~

Create the sorter.

~~~csharp
public KaijuAgentsAngleSorter ([NotNull] Transform position, [NotNull] GameObject forward, KaijuAngleSortMode mode = KaijuAngleSortMode.Magnitude, bool? farthest = null)
~~~

Create the sorter.

~~~csharp
public KaijuAgentsAngleSorter ([NotNull] Transform position, KaijuAngleSortMode mode = KaijuAngleSortMode.Magnitude, bool? farthest = null)
~~~

Create the sorter.

~~~csharp
public KaijuAgentsAngleSorter ([NotNull] Component position, Vector2 forward, KaijuAngleSortMode mode = KaijuAngleSortMode.Magnitude, bool? farthest = null)
~~~

Create the sorter.

~~~csharp
public KaijuAgentsAngleSorter ([NotNull] Component position, Vector3 forward, KaijuAngleSortMode mode = KaijuAngleSortMode.Magnitude, bool? farthest = null)
~~~

Create the sorter.

~~~csharp
public KaijuAgentsAngleSorter ([NotNull] Component position, [NotNull] Transform forward, KaijuAngleSortMode mode = KaijuAngleSortMode.Magnitude, bool? farthest = null)
~~~

Create the sorter.

~~~csharp
public KaijuAgentsAngleSorter ([NotNull] Component position, [NotNull] Component forward, KaijuAngleSortMode mode = KaijuAngleSortMode.Magnitude, bool? farthest = null)
~~~

Create the sorter.

~~~csharp
public KaijuAgentsAngleSorter ([NotNull] Component position, [NotNull] GameObject forward, KaijuAngleSortMode mode = KaijuAngleSortMode.Magnitude, bool? farthest = null)
~~~

Create the sorter.

~~~csharp
public KaijuAgentsAngleSorter ([NotNull] Component position, KaijuAngleSortMode mode = KaijuAngleSortMode.Magnitude, bool? farthest = null)
~~~

Create the sorter.

~~~csharp
public KaijuAgentsAngleSorter ([NotNull] GameObject position, Vector2 forward, KaijuAngleSortMode mode = KaijuAngleSortMode.Magnitude, bool? farthest = null)
~~~

Create the sorter.

~~~csharp
public KaijuAgentsAngleSorter ([NotNull] GameObject position, Vector3 forward, KaijuAngleSortMode mode = KaijuAngleSortMode.Magnitude, bool? farthest = null)
~~~

Create the sorter.

~~~csharp
public KaijuAgentsAngleSorter ([NotNull] GameObject position, [NotNull] Transform forward, KaijuAngleSortMode mode = KaijuAngleSortMode.Magnitude, bool? farthest = null)
~~~

Create the sorter.

~~~csharp
public KaijuAgentsAngleSorter ([NotNull] GameObject position, [NotNull] Component forward, KaijuAngleSortMode mode = KaijuAngleSortMode.Magnitude, bool? farthest = null)
~~~

Create the sorter.

~~~csharp
public KaijuAgentsAngleSorter ([NotNull] GameObject position, [NotNull] GameObject forward, KaijuAngleSortMode mode = KaijuAngleSortMode.Magnitude, bool? farthest = null)
~~~

Create the sorter.

~~~csharp
public KaijuAgentsAngleSorter ([NotNull] GameObject position, KaijuAngleSortMode mode = KaijuAngleSortMode.Magnitude, bool? farthest = null)
~~~

Create the sorter.

<a id="KaijuSolutions_Agents_Extensions_KaijuAgentsAngleSorter_Set"></a>

### Set

~~~csharp
public void Set (Vector2 position, Vector2 forward, KaijuAngleSortMode mode = KaijuAngleSortMode.Magnitude, bool? farthest = null)
~~~

Set values for the sorter.

~~~csharp
public void Set (Vector2 position, Vector3 forward, KaijuAngleSortMode mode = KaijuAngleSortMode.Magnitude, bool? farthest = null)
~~~

Set values for the sorter.

~~~csharp
public void Set (Vector2 position, [NotNull] Transform forward, KaijuAngleSortMode mode = KaijuAngleSortMode.Magnitude, bool? farthest = null)
~~~

Set values for the sorter.

~~~csharp
public void Set (Vector2 position, [NotNull] Component forward, KaijuAngleSortMode mode = KaijuAngleSortMode.Magnitude, bool? farthest = null)
~~~

Set values for the sorter.

~~~csharp
public void Set (Vector2 position, [NotNull] GameObject forward, KaijuAngleSortMode mode = KaijuAngleSortMode.Magnitude, bool? farthest = null)
~~~

Set values for the sorter.

~~~csharp
public void Set (Vector3 position, Vector2 forward, KaijuAngleSortMode mode = KaijuAngleSortMode.Magnitude, bool? farthest = null)
~~~

Set values for the sorter.

~~~csharp
public void Set (Vector3 position, Vector3 forward, KaijuAngleSortMode mode = KaijuAngleSortMode.Magnitude, bool? farthest = null)
~~~

Set values for the sorter.

~~~csharp
public void Set (Vector3 position, [NotNull] Transform forward, KaijuAngleSortMode mode = KaijuAngleSortMode.Magnitude, bool? farthest = null)
~~~

Set values for the sorter.

~~~csharp
public void Set (Vector3 position, [NotNull] Component forward, KaijuAngleSortMode mode = KaijuAngleSortMode.Magnitude, bool? farthest = null)
~~~

Set values for the sorter.

~~~csharp
public void Set (Vector3 position, [NotNull] GameObject forward, KaijuAngleSortMode mode = KaijuAngleSortMode.Magnitude, bool? farthest = null)
~~~

Set values for the sorter.

~~~csharp
public void Set ([NotNull] Transform position, Vector2 forward, KaijuAngleSortMode mode = KaijuAngleSortMode.Magnitude, bool? farthest = null)
~~~

Set values for the sorter.

~~~csharp
public void Set ([NotNull] Transform position, Vector3 forward, KaijuAngleSortMode mode = KaijuAngleSortMode.Magnitude, bool? farthest = null)
~~~

Set values for the sorter.

~~~csharp
public void Set ([NotNull] Transform position, [NotNull] Transform forward, KaijuAngleSortMode mode = KaijuAngleSortMode.Magnitude, bool? farthest = null)
~~~

Set values for the sorter.

~~~csharp
public void Set ([NotNull] Transform position, [NotNull] Component forward, KaijuAngleSortMode mode = KaijuAngleSortMode.Magnitude, bool? farthest = null)
~~~

Set values for the sorter.

~~~csharp
public void Set ([NotNull] Transform position, [NotNull] GameObject forward, KaijuAngleSortMode mode = KaijuAngleSortMode.Magnitude, bool? farthest = null)
~~~

Set values for the sorter.

~~~csharp
public void Set ([NotNull] Transform position, KaijuAngleSortMode mode = KaijuAngleSortMode.Magnitude, bool? farthest = null)
~~~

Set values for the sorter.

~~~csharp
public void Set ([NotNull] Component position, Vector2 forward, KaijuAngleSortMode mode = KaijuAngleSortMode.Magnitude, bool? farthest = null)
~~~

Set values for the sorter.

~~~csharp
public void Set ([NotNull] Component position, Vector3 forward, KaijuAngleSortMode mode = KaijuAngleSortMode.Magnitude, bool? farthest = null)
~~~

Set values for the sorter.

~~~csharp
public void Set ([NotNull] Component position, [NotNull] Transform forward, KaijuAngleSortMode mode = KaijuAngleSortMode.Magnitude, bool? farthest = null)
~~~

Set values for the sorter.

~~~csharp
public void Set ([NotNull] Component position, [NotNull] Component forward, KaijuAngleSortMode mode = KaijuAngleSortMode.Magnitude, bool? farthest = null)
~~~

Set values for the sorter.

~~~csharp
public void Set ([NotNull] Component position, [NotNull] GameObject forward, KaijuAngleSortMode mode = KaijuAngleSortMode.Magnitude, bool? farthest = null)
~~~

Set values for the sorter.

~~~csharp
public void Set ([NotNull] Component position, KaijuAngleSortMode mode = KaijuAngleSortMode.Magnitude, bool? farthest = null)
~~~

Set values for the sorter.

~~~csharp
public void Set ([NotNull] GameObject position, Vector2 forward, KaijuAngleSortMode mode = KaijuAngleSortMode.Magnitude, bool? farthest = null)
~~~

Set values for the sorter.

~~~csharp
public void Set ([NotNull] GameObject position, Vector3 forward, KaijuAngleSortMode mode = KaijuAngleSortMode.Magnitude, bool? farthest = null)
~~~

Set values for the sorter.

~~~csharp
public void Set ([NotNull] GameObject position, [NotNull] Transform forward, KaijuAngleSortMode mode = KaijuAngleSortMode.Magnitude, bool? farthest = null)
~~~

Set values for the sorter.

~~~csharp
public void Set ([NotNull] GameObject position, [NotNull] Component forward, KaijuAngleSortMode mode = KaijuAngleSortMode.Magnitude, bool? farthest = null)
~~~

Set values for the sorter.

~~~csharp
public void Set ([NotNull] GameObject position, [NotNull] GameObject forward, KaijuAngleSortMode mode = KaijuAngleSortMode.Magnitude, bool? farthest = null)
~~~

Set values for the sorter.

~~~csharp
public void Set ([NotNull] GameObject position, KaijuAngleSortMode mode = KaijuAngleSortMode.Magnitude, bool? farthest = null)
~~~

Set values for the sorter.

<a id="KaijuSolutions_Agents_Extensions_KaijuAgentsAngleSorter_CompareAngle"></a>

### CompareAngle

~~~csharp
public static int CompareAngle (Vector2 position, Vector2 forward, Vector2 x, Vector2 y, KaijuAngleSortMode mode = KaijuAngleSortMode.Magnitude)
~~~

Compare the two instances.

<a id="KaijuSolutions_Agents_Extensions_KaijuAgentsAngleSorter_Compare"></a>

### Compare

~~~csharp
public int Compare (Vector2 x, Vector2 y)
~~~

Compare the two instances.

~~~csharp
public int Compare (Vector3 x, Vector3 y)
~~~

Compare the two instances.

~~~csharp
public int Compare (Transform x, Transform y)
~~~

Compare the two instances.

~~~csharp
public int Compare (Component x, Component y)
~~~

Compare the two instances.

~~~csharp
public int Compare (GameObject x, GameObject y)
~~~

Compare the two instances.

<a id="KaijuSolutions_Agents_Extensions_KaijuAgentsAngleSorter_ToString"></a>

### ToString

~~~csharp
public override string ToString ()
~~~

Get a description of the object.

~~~csharp
public static implicit operator string ([NotNull] KaijuAgentsAngleSorter s)
~~~

Implicit conversion to a string.

~~~csharp
public static implicit operator Vector2 ([NotNull] KaijuAgentsAngleSorter s)
~~~

Implicit conversion to a Vector2 from the position.

~~~csharp
public static implicit operator Vector2? ([NotNull] KaijuAgentsAngleSorter s)
~~~

Implicit conversion to a nullable Vector2 from the position.

~~~csharp
public static implicit operator Vector3 ([NotNull] KaijuAgentsAngleSorter s)
~~~

Implicit conversion to a Vector3 from the position.

~~~csharp
public static implicit operator Vector3? ([NotNull] KaijuAgentsAngleSorter s)
~~~

Implicit conversion to a nullable Vector3 from the position.
