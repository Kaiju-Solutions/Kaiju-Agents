# KaijuAgentsDistanceSorter

Comparer class to sort by distance along the X and Z axes. Used in the extension methods found in KaijuAgentsSortDistance.

~~~csharp
public sealed class KaijuAgentsDistanceSorter : IComparer<Vector2>, IComparer<Vector3>, IComparer<Transform>, IComparer<Component>, IComparer<GameObject>
~~~

[Package source](../../Runtime/Extensions/KaijuAgentsDistanceSorter.cs)

<a id="KaijuSolutions_Agents_Extensions_KaijuAgentsDistanceSorter_Position3"></a>

### Position3

~~~csharp
public Vector3 Position3 { get; set; }
~~~

The position to compare against.

<a id="KaijuSolutions_Agents_Extensions_KaijuAgentsDistanceSorter_PositionTransform"></a>

### PositionTransform

~~~csharp
public Transform PositionTransform { set; }
~~~

The position to compare against. This will also set the forward for angle tie breaking.

<a id="KaijuSolutions_Agents_Extensions_KaijuAgentsDistanceSorter_PositionComponent"></a>

### PositionComponent

~~~csharp
public Component PositionComponent { set; }
~~~

The position to compare against. This will also set the forward for angle tie breaking.

<a id="KaijuSolutions_Agents_Extensions_KaijuAgentsDistanceSorter_PositionGameObject"></a>

### PositionGameObject

~~~csharp
public GameObject PositionGameObject { set; }
~~~

The position to compare against. This will also set the forward for angle tie breaking.

<a id="KaijuSolutions_Agents_Extensions_KaijuAgentsDistanceSorter_Forward3"></a>

### Forward3

~~~csharp
public Vector3? Forward3 { get; set; }
~~~

The forward direction to break ties on.

<a id="KaijuSolutions_Agents_Extensions_KaijuAgentsDistanceSorter_ForwardTransform"></a>

### ForwardTransform

~~~csharp
public Transform ForwardTransform { set; }
~~~

The forward direction to break ties on.

<a id="KaijuSolutions_Agents_Extensions_KaijuAgentsDistanceSorter_ForwardComponent"></a>

### ForwardComponent

~~~csharp
public Component ForwardComponent { set; }
~~~

The forward direction to break ties on.

<a id="KaijuSolutions_Agents_Extensions_KaijuAgentsDistanceSorter_ForwardGameObject"></a>

### ForwardGameObject

~~~csharp
public Component ForwardGameObject { set; }
~~~

The forward direction to break ties on.

<a id="KaijuSolutions_Agents_Extensions_KaijuAgentsDistanceSorter_Position"></a>

### Position

~~~csharp
public Vector2 Position
~~~

The position to compare against.

<a id="KaijuSolutions_Agents_Extensions_KaijuAgentsDistanceSorter_Farthest"></a>

### Farthest

~~~csharp
public bool Farthest
~~~

If this should sort by farthest items first.

<a id="KaijuSolutions_Agents_Extensions_KaijuAgentsDistanceSorter_Mode"></a>

### Mode

~~~csharp
public KaijuAngleSortMode? Mode
~~~

How to break ties based on angle.

<a id="KaijuSolutions_Agents_Extensions_KaijuAgentsDistanceSorter_Forward"></a>

### Forward

~~~csharp
public Vector2? Forward
~~~

The forward direction to break ties on.

<a id="KaijuSolutions_Agents_Extensions_KaijuAgentsDistanceSorter_KaijuAgentsDistanceSorter"></a>

### KaijuAgentsDistanceSorter

~~~csharp
public KaijuAgentsDistanceSorter ()
~~~

Create the sorter.

~~~csharp
public KaijuAgentsDistanceSorter (Vector2 position, bool farthest = false, KaijuAngleSortMode? mode = null, Vector2? forward = null)
~~~

Create the sorter.

~~~csharp
public KaijuAgentsDistanceSorter (Vector3 position, bool farthest = false, KaijuAngleSortMode? mode = null, Vector2? forward = null)
~~~

Create the sorter.

~~~csharp
public KaijuAgentsDistanceSorter ([NotNull] Transform position, bool farthest = false, KaijuAngleSortMode? mode = null, Vector2? forward = null)
~~~

Create the sorter.

~~~csharp
public KaijuAgentsDistanceSorter ([NotNull] Component position, bool farthest = false, KaijuAngleSortMode? mode = null, Vector2? forward = null)
~~~

Create the sorter.

~~~csharp
public KaijuAgentsDistanceSorter ([NotNull] GameObject position, bool farthest = false, KaijuAngleSortMode? mode = null, Vector2? forward = null)
~~~

Create the sorter.

<a id="KaijuSolutions_Agents_Extensions_KaijuAgentsDistanceSorter_Set"></a>

### Set

~~~csharp
public void Set (Vector2 position, bool farthest = false, KaijuAngleSortMode? mode = null, Vector2? forward = null)
~~~

Set values for the sorter.

~~~csharp
public void Set (Vector3 position, bool farthest = false, KaijuAngleSortMode? mode = null, Vector2? forward = null)
~~~

Set values for the sorter.

~~~csharp
public void Set ([NotNull] Transform position, bool farthest = false, KaijuAngleSortMode? mode = null, Vector2? forward = null)
~~~

Set values for the sorter.

~~~csharp
public void Set ([NotNull] Component position, bool farthest = false, KaijuAngleSortMode? mode = null, Vector2? forward = null)
~~~

Set values for the sorter.

~~~csharp
public void Set ([NotNull] GameObject position, bool farthest = false, KaijuAngleSortMode? mode = null, Vector2? forward = null)
~~~

Set values for the sorter.

<a id="KaijuSolutions_Agents_Extensions_KaijuAgentsDistanceSorter_CompareDistance"></a>

### CompareDistance

~~~csharp
public static int CompareDistance (Vector2 position, Vector2 x, Vector2 y, bool farthest = false)
~~~

Compare the two instances.

~~~csharp
public static int CompareDistance (Vector2 position, Vector2 x, Vector3 y, bool farthest = false)
~~~

Compare the two instances.

~~~csharp
public static int CompareDistance (Vector2 position, Vector2 x, [NotNull] Transform y, bool farthest = false)
~~~

Compare the two instances.

~~~csharp
public static int CompareDistance (Vector2 position, Vector2 x, [NotNull] Component y, bool farthest = false)
~~~

Compare the two instances.

~~~csharp
public static int CompareDistance (Vector2 position, Vector2 x, [NotNull] GameObject y, bool farthest = false)
~~~

Compare the two instances.

~~~csharp
public static int CompareDistance (Vector2 position, Vector3 x, Vector2 y, bool farthest = false)
~~~

Compare the two instances.

~~~csharp
public static int CompareDistance (Vector2 position, Vector3 x, Vector3 y, bool farthest = false)
~~~

Compare the two instances.

~~~csharp
public static int CompareDistance (Vector2 position, Vector3 x, [NotNull] Transform y, bool farthest = false)
~~~

Compare the two instances.

~~~csharp
public static int CompareDistance (Vector2 position, Vector3 x, [NotNull] Component y, bool farthest = false)
~~~

Compare the two instances.

~~~csharp
public static int CompareDistance (Vector2 position, Vector3 x, [NotNull] GameObject y, bool farthest = false)
~~~

Compare the two instances.

~~~csharp
public static int CompareDistance (Vector2 position, [NotNull] Transform x, Vector2 y, bool farthest = false)
~~~

Compare the two instances.

~~~csharp
public static int CompareDistance (Vector2 position, [NotNull] Transform x, Vector3 y, bool farthest = false)
~~~

Compare the two instances.

~~~csharp
public static int CompareDistance (Vector2 position, [NotNull] Transform x, [NotNull] Transform y, bool farthest = false)
~~~

Compare the two instances.

~~~csharp
public static int CompareDistance (Vector2 position, [NotNull] Transform x, [NotNull] Component y, bool farthest = false)
~~~

Compare the two instances.

~~~csharp
public static int CompareDistance (Vector2 position, [NotNull] Transform x, [NotNull] GameObject y, bool farthest = false)
~~~

Compare the two instances.

~~~csharp
public static int CompareDistance (Vector2 position, [NotNull] Component x, Vector2 y, bool farthest = false)
~~~

Compare the two instances.

~~~csharp
public static int CompareDistance (Vector2 position, [NotNull] Component x, Vector3 y, bool farthest = false)
~~~

Compare the two instances.

~~~csharp
public static int CompareDistance (Vector2 position, [NotNull] Component x, [NotNull] Transform y, bool farthest = false)
~~~

Compare the two instances.

~~~csharp
public static int CompareDistance (Vector2 position, [NotNull] Component x, [NotNull] Component y, bool farthest = false)
~~~

Compare the two instances.

~~~csharp
public static int CompareDistance (Vector2 position, [NotNull] Component x, [NotNull] GameObject y, bool farthest = false)
~~~

Compare the two instances.

~~~csharp
public static int CompareDistance (Vector2 position, [NotNull] GameObject x, Vector2 y, bool farthest = false)
~~~

Compare the two instances.

~~~csharp
public static int CompareDistance (Vector2 position, [NotNull] GameObject x, Vector3 y, bool farthest = false)
~~~

Compare the two instances.

~~~csharp
public static int CompareDistance (Vector2 position, [NotNull] GameObject x, [NotNull] Transform y, bool farthest = false)
~~~

Compare the two instances.

~~~csharp
public static int CompareDistance (Vector2 position, [NotNull] GameObject x, [NotNull] Component y, bool farthest = false)
~~~

Compare the two instances.

~~~csharp
public static int CompareDistance (Vector2 position, [NotNull] GameObject x, [NotNull] GameObject y, bool farthest = false)
~~~

Compare the two instances.

~~~csharp
public static int CompareDistance (Vector3 position, Vector2 x, Vector2 y, bool farthest = false)
~~~

Compare the two instances.

~~~csharp
public static int CompareDistance (Vector3 position, Vector2 x, Vector3 y, bool farthest = false)
~~~

Compare the two instances.

~~~csharp
public static int CompareDistance (Vector3 position, Vector2 x, [NotNull] Transform y, bool farthest = false)
~~~

Compare the two instances.

~~~csharp
public static int CompareDistance (Vector3 position, Vector2 x, [NotNull] Component y, bool farthest = false)
~~~

Compare the two instances.

~~~csharp
public static int CompareDistance (Vector3 position, Vector2 x, [NotNull] GameObject y, bool farthest = false)
~~~

Compare the two instances.

~~~csharp
public static int CompareDistance (Vector3 position, Vector3 x, Vector2 y, bool farthest = false)
~~~

Compare the two instances.

~~~csharp
public static int CompareDistance (Vector3 position, Vector3 x, Vector3 y, bool farthest = false)
~~~

Compare the two instances.

~~~csharp
public static int CompareDistance (Vector3 position, Vector3 x, [NotNull] Transform y, bool farthest = false)
~~~

Compare the two instances.

~~~csharp
public static int CompareDistance (Vector3 position, Vector3 x, [NotNull] Component y, bool farthest = false)
~~~

Compare the two instances.

~~~csharp
public static int CompareDistance (Vector3 position, Vector3 x, [NotNull] GameObject y, bool farthest = false)
~~~

Compare the two instances.

~~~csharp
public static int CompareDistance (Vector3 position, [NotNull] Transform x, Vector2 y, bool farthest = false)
~~~

Compare the two instances.

~~~csharp
public static int CompareDistance (Vector3 position, [NotNull] Transform x, Vector3 y, bool farthest = false)
~~~

Compare the two instances.

~~~csharp
public static int CompareDistance (Vector3 position, [NotNull] Transform x, [NotNull] Transform y, bool farthest = false)
~~~

Compare the two instances.

~~~csharp
public static int CompareDistance (Vector3 position, [NotNull] Transform x, [NotNull] Component y, bool farthest = false)
~~~

Compare the two instances.

~~~csharp
public static int CompareDistance (Vector3 position, [NotNull] Transform x, [NotNull] GameObject y, bool farthest = false)
~~~

Compare the two instances.

~~~csharp
public static int CompareDistance (Vector3 position, [NotNull] Component x, Vector2 y, bool farthest = false)
~~~

Compare the two instances.

~~~csharp
public static int CompareDistance (Vector3 position, [NotNull] Component x, Vector3 y, bool farthest = false)
~~~

Compare the two instances.

~~~csharp
public static int CompareDistance (Vector3 position, [NotNull] Component x, [NotNull] Transform y, bool farthest = false)
~~~

Compare the two instances.

~~~csharp
public static int CompareDistance (Vector3 position, [NotNull] Component x, [NotNull] Component y, bool farthest = false)
~~~

Compare the two instances.

~~~csharp
public static int CompareDistance (Vector3 position, [NotNull] Component x, [NotNull] GameObject y, bool farthest = false)
~~~

Compare the two instances.

~~~csharp
public static int CompareDistance (Vector3 position, [NotNull] GameObject x, Vector2 y, bool farthest = false)
~~~

Compare the two instances.

~~~csharp
public static int CompareDistance (Vector3 position, [NotNull] GameObject x, Vector3 y, bool farthest = false)
~~~

Compare the two instances.

~~~csharp
public static int CompareDistance (Vector3 position, [NotNull] GameObject x, [NotNull] Transform y, bool farthest = false)
~~~

Compare the two instances.

~~~csharp
public static int CompareDistance (Vector3 position, [NotNull] GameObject x, [NotNull] Component y, bool farthest = false)
~~~

Compare the two instances.

~~~csharp
public static int CompareDistance (Vector3 position, [NotNull] GameObject x, [NotNull] GameObject y, bool farthest = false)
~~~

Compare the two instances.

~~~csharp
public static int CompareDistance ([NotNull] Transform position, Vector2 x, Vector2 y, bool farthest = false)
~~~

Compare the two instances.

~~~csharp
public static int CompareDistance ([NotNull] Transform position, Vector2 x, Vector3 y, bool farthest = false)
~~~

Compare the two instances.

~~~csharp
public static int CompareDistance ([NotNull] Transform position, Vector2 x, [NotNull] Transform y, bool farthest = false)
~~~

Compare the two instances.

~~~csharp
public static int CompareDistance ([NotNull] Transform position, Vector2 x, [NotNull] Component y, bool farthest = false)
~~~

Compare the two instances.

~~~csharp
public static int CompareDistance ([NotNull] Transform position, Vector2 x, [NotNull] GameObject y, bool farthest = false)
~~~

Compare the two instances.

~~~csharp
public static int CompareDistance ([NotNull] Transform position, Vector3 x, Vector2 y, bool farthest = false)
~~~

Compare the two instances.

~~~csharp
public static int CompareDistance ([NotNull] Transform position, Vector3 x, Vector3 y, bool farthest = false)
~~~

Compare the two instances.

~~~csharp
public static int CompareDistance ([NotNull] Transform position, Vector3 x, [NotNull] Transform y, bool farthest = false)
~~~

Compare the two instances.

~~~csharp
public static int CompareDistance ([NotNull] Transform position, Vector3 x, [NotNull] Component y, bool farthest = false)
~~~

Compare the two instances.

~~~csharp
public static int CompareDistance ([NotNull] Transform position, Vector3 x, [NotNull] GameObject y, bool farthest = false)
~~~

Compare the two instances.

~~~csharp
public static int CompareDistance ([NotNull] Transform position, [NotNull] Transform x, Vector2 y, bool farthest = false)
~~~

Compare the two instances.

~~~csharp
public static int CompareDistance ([NotNull] Transform position, [NotNull] Transform x, Vector3 y, bool farthest = false)
~~~

Compare the two instances.

~~~csharp
public static int CompareDistance ([NotNull] Transform position, [NotNull] Transform x, [NotNull] Transform y, bool farthest = false)
~~~

Compare the two instances.

~~~csharp
public static int CompareDistance ([NotNull] Transform position, [NotNull] Transform x, [NotNull] Component y, bool farthest = false)
~~~

Compare the two instances.

~~~csharp
public static int CompareDistance ([NotNull] Transform position, [NotNull] Transform x, [NotNull] GameObject y, bool farthest = false)
~~~

Compare the two instances.

~~~csharp
public static int CompareDistance ([NotNull] Transform position, [NotNull] Component x, Vector2 y, bool farthest = false)
~~~

Compare the two instances.

~~~csharp
public static int CompareDistance ([NotNull] Transform position, [NotNull] Component x, Vector3 y, bool farthest = false)
~~~

Compare the two instances.

~~~csharp
public static int CompareDistance ([NotNull] Transform position, [NotNull] Component x, [NotNull] Transform y, bool farthest = false)
~~~

Compare the two instances.

~~~csharp
public static int CompareDistance ([NotNull] Transform position, [NotNull] Component x, [NotNull] Component y, bool farthest = false)
~~~

Compare the two instances.

~~~csharp
public static int CompareDistance ([NotNull] Transform position, [NotNull] Component x, [NotNull] GameObject y, bool farthest = false)
~~~

Compare the two instances.

~~~csharp
public static int CompareDistance ([NotNull] Transform position, [NotNull] GameObject x, Vector2 y, bool farthest = false)
~~~

Compare the two instances.

~~~csharp
public static int CompareDistance ([NotNull] Transform position, [NotNull] GameObject x, Vector3 y, bool farthest = false)
~~~

Compare the two instances.

~~~csharp
public static int CompareDistance ([NotNull] Transform position, [NotNull] GameObject x, [NotNull] Transform y, bool farthest = false)
~~~

Compare the two instances.

~~~csharp
public static int CompareDistance ([NotNull] Transform position, [NotNull] GameObject x, [NotNull] Component y, bool farthest = false)
~~~

Compare the two instances.

~~~csharp
public static int CompareDistance ([NotNull] Transform position, [NotNull] GameObject x, [NotNull] GameObject y, bool farthest = false)
~~~

Compare the two instances.

~~~csharp
public static int CompareDistance ([NotNull] Component position, Vector2 x, Vector2 y, bool farthest = false)
~~~

Compare the two instances.

~~~csharp
public static int CompareDistance ([NotNull] Component position, Vector2 x, Vector3 y, bool farthest = false)
~~~

Compare the two instances.

~~~csharp
public static int CompareDistance ([NotNull] Component position, Vector2 x, [NotNull] Transform y, bool farthest = false)
~~~

Compare the two instances.

~~~csharp
public static int CompareDistance ([NotNull] Component position, Vector2 x, [NotNull] Component y, bool farthest = false)
~~~

Compare the two instances.

~~~csharp
public static int CompareDistance ([NotNull] Component position, Vector2 x, [NotNull] GameObject y, bool farthest = false)
~~~

Compare the two instances.

~~~csharp
public static int CompareDistance ([NotNull] Component position, Vector3 x, Vector2 y, bool farthest = false)
~~~

Compare the two instances.

~~~csharp
public static int CompareDistance ([NotNull] Component position, Vector3 x, Vector3 y, bool farthest = false)
~~~

Compare the two instances.

~~~csharp
public static int CompareDistance ([NotNull] Component position, Vector3 x, [NotNull] Transform y, bool farthest = false)
~~~

Compare the two instances.

~~~csharp
public static int CompareDistance ([NotNull] Component position, Vector3 x, [NotNull] Component y, bool farthest = false)
~~~

Compare the two instances.

~~~csharp
public static int CompareDistance ([NotNull] Component position, Vector3 x, [NotNull] GameObject y, bool farthest = false)
~~~

Compare the two instances.

~~~csharp
public static int CompareDistance ([NotNull] Component position, [NotNull] Transform x, Vector2 y, bool farthest = false)
~~~

Compare the two instances.

~~~csharp
public static int CompareDistance ([NotNull] Component position, [NotNull] Transform x, Vector3 y, bool farthest = false)
~~~

Compare the two instances.

~~~csharp
public static int CompareDistance ([NotNull] Component position, [NotNull] Transform x, [NotNull] Transform y, bool farthest = false)
~~~

Compare the two instances.

~~~csharp
public static int CompareDistance ([NotNull] Component position, [NotNull] Transform x, [NotNull] Component y, bool farthest = false)
~~~

Compare the two instances.

~~~csharp
public static int CompareDistance ([NotNull] Component position, [NotNull] Transform x, [NotNull] GameObject y, bool farthest = false)
~~~

Compare the two instances.

~~~csharp
public static int CompareDistance ([NotNull] Component position, [NotNull] Component x, Vector2 y, bool farthest = false)
~~~

Compare the two instances.

~~~csharp
public static int CompareDistance ([NotNull] Component position, [NotNull] Component x, Vector3 y, bool farthest = false)
~~~

Compare the two instances.

~~~csharp
public static int CompareDistance ([NotNull] Component position, [NotNull] Component x, [NotNull] Transform y, bool farthest = false)
~~~

Compare the two instances.

~~~csharp
public static int CompareDistance ([NotNull] Component position, [NotNull] Component x, [NotNull] Component y, bool farthest = false)
~~~

Compare the two instances.

~~~csharp
public static int CompareDistance ([NotNull] Component position, [NotNull] Component x, [NotNull] GameObject y, bool farthest = false)
~~~

Compare the two instances.

~~~csharp
public static int CompareDistance ([NotNull] Component position, [NotNull] GameObject x, Vector2 y, bool farthest = false)
~~~

Compare the two instances.

~~~csharp
public static int CompareDistance ([NotNull] Component position, [NotNull] GameObject x, Vector3 y, bool farthest = false)
~~~

Compare the two instances.

~~~csharp
public static int CompareDistance ([NotNull] Component position, [NotNull] GameObject x, [NotNull] Transform y, bool farthest = false)
~~~

Compare the two instances.

~~~csharp
public static int CompareDistance ([NotNull] Component position, [NotNull] GameObject x, [NotNull] Component y, bool farthest = false)
~~~

Compare the two instances.

~~~csharp
public static int CompareDistance ([NotNull] Component position, [NotNull] GameObject x, [NotNull] GameObject y, bool farthest = false)
~~~

Compare the two instances.

~~~csharp
public static int CompareDistance ([NotNull] GameObject position, Vector2 x, Vector2 y, bool farthest = false)
~~~

Compare the two instances.

~~~csharp
public static int CompareDistance ([NotNull] GameObject position, Vector2 x, Vector3 y, bool farthest = false)
~~~

Compare the two instances.

~~~csharp
public static int CompareDistance ([NotNull] GameObject position, Vector2 x, [NotNull] Transform y, bool farthest = false)
~~~

Compare the two instances.

~~~csharp
public static int CompareDistance ([NotNull] GameObject position, Vector2 x, [NotNull] Component y, bool farthest = false)
~~~

Compare the two instances.

~~~csharp
public static int CompareDistance ([NotNull] GameObject position, Vector2 x, [NotNull] GameObject y, bool farthest = false)
~~~

Compare the two instances.

~~~csharp
public static int CompareDistance ([NotNull] GameObject position, Vector3 x, Vector2 y, bool farthest = false)
~~~

Compare the two instances.

~~~csharp
public static int CompareDistance ([NotNull] GameObject position, Vector3 x, Vector3 y, bool farthest = false)
~~~

Compare the two instances.

~~~csharp
public static int CompareDistance ([NotNull] GameObject position, Vector3 x, [NotNull] Transform y, bool farthest = false)
~~~

Compare the two instances.

~~~csharp
public static int CompareDistance ([NotNull] GameObject position, Vector3 x, [NotNull] Component y, bool farthest = false)
~~~

Compare the two instances.

~~~csharp
public static int CompareDistance ([NotNull] GameObject position, Vector3 x, [NotNull] GameObject y, bool farthest = false)
~~~

Compare the two instances.

~~~csharp
public static int CompareDistance ([NotNull] GameObject position, [NotNull] Transform x, Vector2 y, bool farthest = false)
~~~

Compare the two instances.

~~~csharp
public static int CompareDistance ([NotNull] GameObject position, [NotNull] Transform x, Vector3 y, bool farthest = false)
~~~

Compare the two instances.

~~~csharp
public static int CompareDistance ([NotNull] GameObject position, [NotNull] Transform x, [NotNull] Transform y, bool farthest = false)
~~~

Compare the two instances.

~~~csharp
public static int CompareDistance ([NotNull] GameObject position, [NotNull] Transform x, [NotNull] Component y, bool farthest = false)
~~~

Compare the two instances.

~~~csharp
public static int CompareDistance ([NotNull] GameObject position, [NotNull] Transform x, [NotNull] GameObject y, bool farthest = false)
~~~

Compare the two instances.

~~~csharp
public static int CompareDistance ([NotNull] GameObject position, [NotNull] Component x, Vector2 y, bool farthest = false)
~~~

Compare the two instances.

~~~csharp
public static int CompareDistance ([NotNull] GameObject position, [NotNull] Component x, Vector3 y, bool farthest = false)
~~~

Compare the two instances.

~~~csharp
public static int CompareDistance ([NotNull] GameObject position, [NotNull] Component x, [NotNull] Transform y, bool farthest = false)
~~~

Compare the two instances.

~~~csharp
public static int CompareDistance ([NotNull] GameObject position, [NotNull] Component x, [NotNull] Component y, bool farthest = false)
~~~

Compare the two instances.

~~~csharp
public static int CompareDistance ([NotNull] GameObject position, [NotNull] Component x, [NotNull] GameObject y, bool farthest = false)
~~~

Compare the two instances.

~~~csharp
public static int CompareDistance ([NotNull] GameObject position, [NotNull] GameObject x, Vector2 y, bool farthest = false)
~~~

Compare the two instances.

~~~csharp
public static int CompareDistance ([NotNull] GameObject position, [NotNull] GameObject x, Vector3 y, bool farthest = false)
~~~

Compare the two instances.

~~~csharp
public static int CompareDistance ([NotNull] GameObject position, [NotNull] GameObject x, [NotNull] Transform y, bool farthest = false)
~~~

Compare the two instances.

~~~csharp
public static int CompareDistance ([NotNull] GameObject position, [NotNull] GameObject x, [NotNull] Component y, bool farthest = false)
~~~

Compare the two instances.

~~~csharp
public static int CompareDistance ([NotNull] GameObject position, [NotNull] GameObject x, [NotNull] GameObject y, bool farthest = false)
~~~

Compare the two instances.

<a id="KaijuSolutions_Agents_Extensions_KaijuAgentsDistanceSorter_Compare"></a>

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

<a id="KaijuSolutions_Agents_Extensions_KaijuAgentsDistanceSorter_ToString"></a>

### ToString

~~~csharp
public override string ToString ()
~~~

Get a description of the object.

~~~csharp
public static implicit operator string ([NotNull] KaijuAgentsDistanceSorter s)
~~~

Implicit conversion to a string.

~~~csharp
public static implicit operator Vector2 ([NotNull] KaijuAgentsDistanceSorter s)
~~~

Implicit conversion to a Vector2 from the position.

~~~csharp
public static implicit operator Vector2? ([NotNull] KaijuAgentsDistanceSorter s)
~~~

Implicit conversion to a nullable Vector2 from the position.

~~~csharp
public static implicit operator Vector3 ([NotNull] KaijuAgentsDistanceSorter s)
~~~

Implicit conversion to a Vector3 from the position.

~~~csharp
public static implicit operator Vector3? ([NotNull] KaijuAgentsDistanceSorter s)
~~~

Implicit conversion to a nullable Vector3 from the position.
