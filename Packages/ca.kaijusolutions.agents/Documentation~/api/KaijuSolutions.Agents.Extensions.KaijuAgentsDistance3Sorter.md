# KaijuAgentsDistance3Sorter

Comparer class to sort by distance along all three axes. Used in the extension methods found in KaijuAgentsSortDistance3.

~~~csharp
public sealed class KaijuAgentsDistance3Sorter : IComparer<Vector2>, IComparer<Vector3>, IComparer<Transform>, IComparer<Component>, IComparer<GameObject>
~~~

[Package source](../../Runtime/Extensions/KaijuAgentsDistance3Sorter.cs)

<a id="KaijuSolutions_Agents_Extensions_KaijuAgentsDistance3Sorter_Position2"></a>

### Position2

~~~csharp
public Vector2 Position2 { get; set; }
~~~

The position to compare against.

<a id="KaijuSolutions_Agents_Extensions_KaijuAgentsDistance3Sorter_PositionTransform"></a>

### PositionTransform

~~~csharp
public Transform PositionTransform { set; }
~~~

The position to compare against. This will also set the forward for angle tie breaking.

<a id="KaijuSolutions_Agents_Extensions_KaijuAgentsDistance3Sorter_PositionComponent"></a>

### PositionComponent

~~~csharp
public Component PositionComponent { set; }
~~~

The position to compare against. This will also set the forward for angle tie breaking.

<a id="KaijuSolutions_Agents_Extensions_KaijuAgentsDistance3Sorter_PositionGameObject"></a>

### PositionGameObject

~~~csharp
public GameObject PositionGameObject { set; }
~~~

The position to compare against. This will also set the forward for angle tie breaking.

<a id="KaijuSolutions_Agents_Extensions_KaijuAgentsDistance3Sorter_Forward3"></a>

### Forward3

~~~csharp
public Vector3? Forward3 { get; set; }
~~~

The forward direction to break ties on.

<a id="KaijuSolutions_Agents_Extensions_KaijuAgentsDistance3Sorter_ForwardTransform"></a>

### ForwardTransform

~~~csharp
public Transform ForwardTransform { set; }
~~~

The forward direction to break ties on.

<a id="KaijuSolutions_Agents_Extensions_KaijuAgentsDistance3Sorter_ForwardComponent"></a>

### ForwardComponent

~~~csharp
public Component ForwardComponent { set; }
~~~

The forward direction to break ties on.

<a id="KaijuSolutions_Agents_Extensions_KaijuAgentsDistance3Sorter_ForwardGameObject"></a>

### ForwardGameObject

~~~csharp
public Component ForwardGameObject { set; }
~~~

The forward direction to break ties on.

<a id="KaijuSolutions_Agents_Extensions_KaijuAgentsDistance3Sorter_Position"></a>

### Position

~~~csharp
public Vector3 Position
~~~

The position to compare against.

<a id="KaijuSolutions_Agents_Extensions_KaijuAgentsDistance3Sorter_Farthest"></a>

### Farthest

~~~csharp
public bool Farthest
~~~

If this should sort by farthest items first.

<a id="KaijuSolutions_Agents_Extensions_KaijuAgentsDistance3Sorter_Mode"></a>

### Mode

~~~csharp
public KaijuAngleSortMode? Mode
~~~

How to break ties based on angle.

<a id="KaijuSolutions_Agents_Extensions_KaijuAgentsDistance3Sorter_Forward"></a>

### Forward

~~~csharp
public Vector2? Forward
~~~

The forward direction to break ties on.

<a id="KaijuSolutions_Agents_Extensions_KaijuAgentsDistance3Sorter_KaijuAgentsDistance3Sorter"></a>

### KaijuAgentsDistance3Sorter

~~~csharp
public KaijuAgentsDistance3Sorter ()
~~~

Create the sorter.

~~~csharp
public KaijuAgentsDistance3Sorter (Vector2 position, bool farthest = false, KaijuAngleSortMode? mode = null, Vector2? forward = null)
~~~

Create the sorter.

~~~csharp
public KaijuAgentsDistance3Sorter (Vector3 position, bool farthest = false, KaijuAngleSortMode? mode = null, Vector2? forward = null)
~~~

Create the sorter.

~~~csharp
public KaijuAgentsDistance3Sorter ([NotNull] Transform position, bool farthest = false, KaijuAngleSortMode? mode = null, Vector2? forward = null)
~~~

Create the sorter.

~~~csharp
public KaijuAgentsDistance3Sorter ([NotNull] Component position, bool farthest = false, KaijuAngleSortMode? mode = null, Vector2? forward = null)
~~~

Create the sorter.

~~~csharp
public KaijuAgentsDistance3Sorter ([NotNull] GameObject position, bool farthest = false, KaijuAngleSortMode? mode = null, Vector2? forward = null)
~~~

Create the sorter.

<a id="KaijuSolutions_Agents_Extensions_KaijuAgentsDistance3Sorter_Set"></a>

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

<a id="KaijuSolutions_Agents_Extensions_KaijuAgentsDistance3Sorter_CompareDistance3"></a>

### CompareDistance3

~~~csharp
public static int CompareDistance3 (Vector2 position, Vector2 x, Vector3 y, bool farthest = false)
~~~

Compare the two instances.

~~~csharp
public static int CompareDistance3 (Vector2 position, Vector2 x, [NotNull] Transform y, bool farthest = false)
~~~

Compare the two instances.

~~~csharp
public static int CompareDistance3 (Vector2 position, Vector2 x, [NotNull] Component y, bool farthest = false)
~~~

Compare the two instances.

~~~csharp
public static int CompareDistance3 (Vector2 position, Vector2 x, [NotNull] GameObject y, bool farthest = false)
~~~

Compare the two instances.

~~~csharp
public static int CompareDistance3 (Vector2 position, Vector3 x, Vector2 y, bool farthest = false)
~~~

Compare the two instances.

~~~csharp
public static int CompareDistance3 (Vector2 position, Vector3 x, [NotNull] Transform y, bool farthest = false)
~~~

Compare the two instances.

~~~csharp
public static int CompareDistance3 (Vector2 position, Vector3 x, [NotNull] Component y, bool farthest = false)
~~~

Compare the two instances.

~~~csharp
public static int CompareDistance3 (Vector2 position, Vector3 x, [NotNull] GameObject y, bool farthest = false)
~~~

Compare the two instances.

~~~csharp
public static int CompareDistance3 (Vector2 position, [NotNull] Transform x, Vector2 y, bool farthest = false)
~~~

Compare the two instances.

~~~csharp
public static int CompareDistance3 (Vector2 position, [NotNull] Transform x, [NotNull] Transform y, bool farthest = false)
~~~

Compare the two instances.

~~~csharp
public static int CompareDistance3 (Vector2 position, [NotNull] Transform x, [NotNull] Component y, bool farthest = false)
~~~

Compare the two instances.

~~~csharp
public static int CompareDistance3 (Vector2 position, [NotNull] Transform x, [NotNull] GameObject y, bool farthest = false)
~~~

Compare the two instances.

~~~csharp
public static int CompareDistance3 (Vector2 position, [NotNull] Component x, Vector2 y, bool farthest = false)
~~~

Compare the two instances.

~~~csharp
public static int CompareDistance3 (Vector2 position, [NotNull] Component x, [NotNull] Transform y, bool farthest = false)
~~~

Compare the two instances.

~~~csharp
public static int CompareDistance3 (Vector2 position, [NotNull] Component x, [NotNull] Component y, bool farthest = false)
~~~

Compare the two instances.

~~~csharp
public static int CompareDistance3 (Vector2 position, [NotNull] Component x, [NotNull] GameObject y, bool farthest = false)
~~~

Compare the two instances.

~~~csharp
public static int CompareDistance3 (Vector2 position, [NotNull] GameObject x, Vector2 y, bool farthest = false)
~~~

Compare the two instances.

~~~csharp
public static int CompareDistance3 (Vector2 position, [NotNull] GameObject x, [NotNull] Transform y, bool farthest = false)
~~~

Compare the two instances.

~~~csharp
public static int CompareDistance3 (Vector2 position, [NotNull] GameObject x, [NotNull] Component y, bool farthest = false)
~~~

Compare the two instances.

~~~csharp
public static int CompareDistance3 (Vector2 position, [NotNull] GameObject x, [NotNull] GameObject y, bool farthest = false)
~~~

Compare the two instances.

~~~csharp
public static int CompareDistance3 (Vector3 position, Vector2 x, Vector2 y, bool farthest = false)
~~~

Compare the two instances.

~~~csharp
public static int CompareDistance3 (Vector3 position, Vector2 x, Vector3 y, bool farthest = false)
~~~

Compare the two instances.

~~~csharp
public static int CompareDistance3 (Vector3 position, Vector2 x, [NotNull] Transform y, bool farthest = false)
~~~

Compare the two instances.

~~~csharp
public static int CompareDistance3 (Vector3 position, Vector2 x, [NotNull] Component y, bool farthest = false)
~~~

Compare the two instances.

~~~csharp
public static int CompareDistance3 (Vector3 position, Vector2 x, [NotNull] GameObject y, bool farthest = false)
~~~

Compare the two instances.

~~~csharp
public static int CompareDistance3 (Vector3 position, Vector3 x, Vector2 y, bool farthest = false)
~~~

Compare the two instances.

~~~csharp
public static int CompareDistance3 (Vector3 position, Vector3 x, Vector3 y, bool farthest = false)
~~~

Compare the two instances.

~~~csharp
public static int CompareDistance3 (Vector3 position, Vector3 x, [NotNull] Transform y, bool farthest = false)
~~~

Compare the two instances.

~~~csharp
public static int CompareDistance3 (Vector3 position, Vector3 x, [NotNull] Component y, bool farthest = false)
~~~

Compare the two instances.

~~~csharp
public static int CompareDistance3 (Vector3 position, Vector3 x, [NotNull] GameObject y, bool farthest = false)
~~~

Compare the two instances.

~~~csharp
public static int CompareDistance3 (Vector3 position, [NotNull] Transform x, Vector2 y, bool farthest = false)
~~~

Compare the two instances.

~~~csharp
public static int CompareDistance3 (Vector3 position, [NotNull] Transform x, Vector3 y, bool farthest = false)
~~~

Compare the two instances.

~~~csharp
public static int CompareDistance3 (Vector3 position, [NotNull] Transform x, [NotNull] Transform y, bool farthest = false)
~~~

Compare the two instances.

~~~csharp
public static int CompareDistance3 (Vector3 position, [NotNull] Transform x, [NotNull] Component y, bool farthest = false)
~~~

Compare the two instances.

~~~csharp
public static int CompareDistance3 (Vector3 position, [NotNull] Transform x, [NotNull] GameObject y, bool farthest = false)
~~~

Compare the two instances.

~~~csharp
public static int CompareDistance3 (Vector3 position, [NotNull] Component x, Vector2 y, bool farthest = false)
~~~

Compare the two instances.

~~~csharp
public static int CompareDistance3 (Vector3 position, [NotNull] Component x, Vector3 y, bool farthest = false)
~~~

Compare the two instances.

~~~csharp
public static int CompareDistance3 (Vector3 position, [NotNull] Component x, [NotNull] Transform y, bool farthest = false)
~~~

Compare the two instances.

~~~csharp
public static int CompareDistance3 (Vector3 position, [NotNull] Component x, [NotNull] Component y, bool farthest = false)
~~~

Compare the two instances.

~~~csharp
public static int CompareDistance3 (Vector3 position, [NotNull] Component x, [NotNull] GameObject y, bool farthest = false)
~~~

Compare the two instances.

~~~csharp
public static int CompareDistance3 (Vector3 position, [NotNull] GameObject x, Vector2 y, bool farthest = false)
~~~

Compare the two instances.

~~~csharp
public static int CompareDistance3 (Vector3 position, [NotNull] GameObject x, Vector3 y, bool farthest = false)
~~~

Compare the two instances.

~~~csharp
public static int CompareDistance3 (Vector3 position, [NotNull] GameObject x, [NotNull] Transform y, bool farthest = false)
~~~

Compare the two instances.

~~~csharp
public static int CompareDistance3 (Vector3 position, [NotNull] GameObject x, [NotNull] Component y, bool farthest = false)
~~~

Compare the two instances.

~~~csharp
public static int CompareDistance3 (Vector3 position, [NotNull] GameObject x, [NotNull] GameObject y, bool farthest = false)
~~~

Compare the two instances.

~~~csharp
public static int CompareDistance3 ([NotNull] Transform position, Vector2 x, Vector2 y, bool farthest = false)
~~~

Compare the two instances.

~~~csharp
public static int CompareDistance3 ([NotNull] Transform position, Vector2 x, Vector3 y, bool farthest = false)
~~~

Compare the two instances.

~~~csharp
public static int CompareDistance3 ([NotNull] Transform position, Vector2 x, [NotNull] Transform y, bool farthest = false)
~~~

Compare the two instances.

~~~csharp
public static int CompareDistance3 ([NotNull] Transform position, Vector2 x, [NotNull] Component y, bool farthest = false)
~~~

Compare the two instances.

~~~csharp
public static int CompareDistance3 ([NotNull] Transform position, Vector2 x, [NotNull] GameObject y, bool farthest = false)
~~~

Compare the two instances.

~~~csharp
public static int CompareDistance3 ([NotNull] Transform position, Vector3 x, Vector2 y, bool farthest = false)
~~~

Compare the two instances.

~~~csharp
public static int CompareDistance3 ([NotNull] Transform position, Vector3 x, Vector3 y, bool farthest = false)
~~~

Compare the two instances.

~~~csharp
public static int CompareDistance3 ([NotNull] Transform position, Vector3 x, [NotNull] Transform y, bool farthest = false)
~~~

Compare the two instances.

~~~csharp
public static int CompareDistance3 ([NotNull] Transform position, Vector3 x, [NotNull] Component y, bool farthest = false)
~~~

Compare the two instances.

~~~csharp
public static int CompareDistance3 ([NotNull] Transform position, Vector3 x, [NotNull] GameObject y, bool farthest = false)
~~~

Compare the two instances.

~~~csharp
public static int CompareDistance3 ([NotNull] Transform position, [NotNull] Transform x, Vector2 y, bool farthest = false)
~~~

Compare the two instances.

~~~csharp
public static int CompareDistance3 ([NotNull] Transform position, [NotNull] Transform x, Vector3 y, bool farthest = false)
~~~

Compare the two instances.

~~~csharp
public static int CompareDistance3 ([NotNull] Transform position, [NotNull] Transform x, [NotNull] Transform y, bool farthest = false)
~~~

Compare the two instances.

~~~csharp
public static int CompareDistance3 ([NotNull] Transform position, [NotNull] Transform x, [NotNull] Component y, bool farthest = false)
~~~

Compare the two instances.

~~~csharp
public static int CompareDistance3 ([NotNull] Transform position, [NotNull] Transform x, [NotNull] GameObject y, bool farthest = false)
~~~

Compare the two instances.

~~~csharp
public static int CompareDistance3 ([NotNull] Transform position, [NotNull] Component x, Vector2 y, bool farthest = false)
~~~

Compare the two instances.

~~~csharp
public static int CompareDistance3 ([NotNull] Transform position, [NotNull] Component x, Vector3 y, bool farthest = false)
~~~

Compare the two instances.

~~~csharp
public static int CompareDistance3 ([NotNull] Transform position, [NotNull] Component x, [NotNull] Transform y, bool farthest = false)
~~~

Compare the two instances.

~~~csharp
public static int CompareDistance3 ([NotNull] Transform position, [NotNull] Component x, [NotNull] Component y, bool farthest = false)
~~~

Compare the two instances.

~~~csharp
public static int CompareDistance3 ([NotNull] Transform position, [NotNull] Component x, [NotNull] GameObject y, bool farthest = false)
~~~

Compare the two instances.

~~~csharp
public static int CompareDistance3 ([NotNull] Transform position, [NotNull] GameObject x, Vector2 y, bool farthest = false)
~~~

Compare the two instances.

~~~csharp
public static int CompareDistance3 ([NotNull] Transform position, [NotNull] GameObject x, Vector3 y, bool farthest = false)
~~~

Compare the two instances.

~~~csharp
public static int CompareDistance3 ([NotNull] Transform position, [NotNull] GameObject x, [NotNull] Transform y, bool farthest = false)
~~~

Compare the two instances.

~~~csharp
public static int CompareDistance3 ([NotNull] Transform position, [NotNull] GameObject x, [NotNull] Component y, bool farthest = false)
~~~

Compare the two instances.

~~~csharp
public static int CompareDistance3 ([NotNull] Transform position, [NotNull] GameObject x, [NotNull] GameObject y, bool farthest = false)
~~~

Compare the two instances.

~~~csharp
public static int CompareDistance3 ([NotNull] Component position, Vector2 x, Vector2 y, bool farthest = false)
~~~

Compare the two instances.

~~~csharp
public static int CompareDistance3 ([NotNull] Component position, Vector2 x, Vector3 y, bool farthest = false)
~~~

Compare the two instances.

~~~csharp
public static int CompareDistance3 ([NotNull] Component position, Vector2 x, [NotNull] Transform y, bool farthest = false)
~~~

Compare the two instances.

~~~csharp
public static int CompareDistance3 ([NotNull] Component position, Vector2 x, [NotNull] Component y, bool farthest = false)
~~~

Compare the two instances.

~~~csharp
public static int CompareDistance3 ([NotNull] Component position, Vector2 x, [NotNull] GameObject y, bool farthest = false)
~~~

Compare the two instances.

~~~csharp
public static int CompareDistance3 ([NotNull] Component position, Vector3 x, Vector2 y, bool farthest = false)
~~~

Compare the two instances.

~~~csharp
public static int CompareDistance3 ([NotNull] Component position, Vector3 x, Vector3 y, bool farthest = false)
~~~

Compare the two instances.

~~~csharp
public static int CompareDistance3 ([NotNull] Component position, Vector3 x, [NotNull] Transform y, bool farthest = false)
~~~

Compare the two instances.

~~~csharp
public static int CompareDistance3 ([NotNull] Component position, Vector3 x, [NotNull] Component y, bool farthest = false)
~~~

Compare the two instances.

~~~csharp
public static int CompareDistance3 ([NotNull] Component position, Vector3 x, [NotNull] GameObject y, bool farthest = false)
~~~

Compare the two instances.

~~~csharp
public static int CompareDistance3 ([NotNull] Component position, [NotNull] Transform x, Vector2 y, bool farthest = false)
~~~

Compare the two instances.

~~~csharp
public static int CompareDistance3 ([NotNull] Component position, [NotNull] Transform x, Vector3 y, bool farthest = false)
~~~

Compare the two instances.

~~~csharp
public static int CompareDistance3 ([NotNull] Component position, [NotNull] Transform x, [NotNull] Transform y, bool farthest = false)
~~~

Compare the two instances.

~~~csharp
public static int CompareDistance3 ([NotNull] Component position, [NotNull] Transform x, [NotNull] Component y, bool farthest = false)
~~~

Compare the two instances.

~~~csharp
public static int CompareDistance3 ([NotNull] Component position, [NotNull] Transform x, [NotNull] GameObject y, bool farthest = false)
~~~

Compare the two instances.

~~~csharp
public static int CompareDistance3 ([NotNull] Component position, [NotNull] Component x, Vector2 y, bool farthest = false)
~~~

Compare the two instances.

~~~csharp
public static int CompareDistance3 ([NotNull] Component position, [NotNull] Component x, Vector3 y, bool farthest = false)
~~~

Compare the two instances.

~~~csharp
public static int CompareDistance3 ([NotNull] Component position, [NotNull] Component x, [NotNull] Transform y, bool farthest = false)
~~~

Compare the two instances.

~~~csharp
public static int CompareDistance3 ([NotNull] Component position, [NotNull] Component x, [NotNull] Component y, bool farthest = false)
~~~

Compare the two instances.

~~~csharp
public static int CompareDistance3 ([NotNull] Component position, [NotNull] Component x, [NotNull] GameObject y, bool farthest = false)
~~~

Compare the two instances.

~~~csharp
public static int CompareDistance3 ([NotNull] Component position, [NotNull] GameObject x, Vector2 y, bool farthest = false)
~~~

Compare the two instances.

~~~csharp
public static int CompareDistance3 ([NotNull] Component position, [NotNull] GameObject x, Vector3 y, bool farthest = false)
~~~

Compare the two instances.

~~~csharp
public static int CompareDistance3 ([NotNull] Component position, [NotNull] GameObject x, [NotNull] Transform y, bool farthest = false)
~~~

Compare the two instances.

~~~csharp
public static int CompareDistance3 ([NotNull] Component position, [NotNull] GameObject x, [NotNull] Component y, bool farthest = false)
~~~

Compare the two instances.

~~~csharp
public static int CompareDistance3 ([NotNull] Component position, [NotNull] GameObject x, [NotNull] GameObject y, bool farthest = false)
~~~

Compare the two instances.

~~~csharp
public static int CompareDistance3 ([NotNull] GameObject position, Vector2 x, Vector2 y, bool farthest = false)
~~~

Compare the two instances.

~~~csharp
public static int CompareDistance3 ([NotNull] GameObject position, Vector2 x, Vector3 y, bool farthest = false)
~~~

Compare the two instances.

~~~csharp
public static int CompareDistance3 ([NotNull] GameObject position, Vector2 x, [NotNull] Transform y, bool farthest = false)
~~~

Compare the two instances.

~~~csharp
public static int CompareDistance3 ([NotNull] GameObject position, Vector2 x, [NotNull] Component y, bool farthest = false)
~~~

Compare the two instances.

~~~csharp
public static int CompareDistance3 ([NotNull] GameObject position, Vector2 x, [NotNull] GameObject y, bool farthest = false)
~~~

Compare the two instances.

~~~csharp
public static int CompareDistance3 ([NotNull] GameObject position, Vector3 x, Vector2 y, bool farthest = false)
~~~

Compare the two instances.

~~~csharp
public static int CompareDistance3 ([NotNull] GameObject position, Vector3 x, Vector3 y, bool farthest = false)
~~~

Compare the two instances.

~~~csharp
public static int CompareDistance3 ([NotNull] GameObject position, Vector3 x, [NotNull] Transform y, bool farthest = false)
~~~

Compare the two instances.

~~~csharp
public static int CompareDistance3 ([NotNull] GameObject position, Vector3 x, [NotNull] Component y, bool farthest = false)
~~~

Compare the two instances.

~~~csharp
public static int CompareDistance3 ([NotNull] GameObject position, Vector3 x, [NotNull] GameObject y, bool farthest = false)
~~~

Compare the two instances.

~~~csharp
public static int CompareDistance3 ([NotNull] GameObject position, [NotNull] Transform x, Vector2 y, bool farthest = false)
~~~

Compare the two instances.

~~~csharp
public static int CompareDistance3 ([NotNull] GameObject position, [NotNull] Transform x, Vector3 y, bool farthest = false)
~~~

Compare the two instances.

~~~csharp
public static int CompareDistance3 ([NotNull] GameObject position, [NotNull] Transform x, [NotNull] Transform y, bool farthest = false)
~~~

Compare the two instances.

~~~csharp
public static int CompareDistance3 ([NotNull] GameObject position, [NotNull] Transform x, [NotNull] Component y, bool farthest = false)
~~~

Compare the two instances.

~~~csharp
public static int CompareDistance3 ([NotNull] GameObject position, [NotNull] Transform x, [NotNull] GameObject y, bool farthest = false)
~~~

Compare the two instances.

~~~csharp
public static int CompareDistance3 ([NotNull] GameObject position, [NotNull] Component x, Vector2 y, bool farthest = false)
~~~

Compare the two instances.

~~~csharp
public static int CompareDistance3 ([NotNull] GameObject position, [NotNull] Component x, Vector3 y, bool farthest = false)
~~~

Compare the two instances.

~~~csharp
public static int CompareDistance3 ([NotNull] GameObject position, [NotNull] Component x, [NotNull] Transform y, bool farthest = false)
~~~

Compare the two instances.

~~~csharp
public static int CompareDistance3 ([NotNull] GameObject position, [NotNull] Component x, [NotNull] Component y, bool farthest = false)
~~~

Compare the two instances.

~~~csharp
public static int CompareDistance3 ([NotNull] GameObject position, [NotNull] Component x, [NotNull] GameObject y, bool farthest = false)
~~~

Compare the two instances.

~~~csharp
public static int CompareDistance3 ([NotNull] GameObject position, [NotNull] GameObject x, Vector2 y, bool farthest = false)
~~~

Compare the two instances.

~~~csharp
public static int CompareDistance3 ([NotNull] GameObject position, [NotNull] GameObject x, Vector3 y, bool farthest = false)
~~~

Compare the two instances.

~~~csharp
public static int CompareDistance3 ([NotNull] GameObject position, [NotNull] GameObject x, [NotNull] Transform y, bool farthest = false)
~~~

Compare the two instances.

~~~csharp
public static int CompareDistance3 ([NotNull] GameObject position, [NotNull] GameObject x, [NotNull] Component y, bool farthest = false)
~~~

Compare the two instances.

~~~csharp
public static int CompareDistance3 ([NotNull] GameObject position, [NotNull] GameObject x, [NotNull] GameObject y, bool farthest = false)
~~~

Compare the two instances.

<a id="KaijuSolutions_Agents_Extensions_KaijuAgentsDistance3Sorter_Compare"></a>

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

<a id="KaijuSolutions_Agents_Extensions_KaijuAgentsDistance3Sorter_ToString"></a>

### ToString

~~~csharp
public override string ToString ()
~~~

Get a description of the object.

~~~csharp
public static implicit operator string ([NotNull] KaijuAgentsDistance3Sorter s)
~~~

Implicit conversion to a string.

~~~csharp
public static implicit operator Vector2 ([NotNull] KaijuAgentsDistance3Sorter s)
~~~

Implicit conversion to a Vector2 from the position.

~~~csharp
public static implicit operator Vector2? ([NotNull] KaijuAgentsDistance3Sorter s)
~~~

Implicit conversion to a nullable Vector2 from the position.

~~~csharp
public static implicit operator Vector3 ([NotNull] KaijuAgentsDistance3Sorter s)
~~~

Implicit conversion to a Vector3 from the position.

~~~csharp
public static implicit operator Vector3? ([NotNull] KaijuAgentsDistance3Sorter s)
~~~

Implicit conversion to a nullable Vector3 from the position.
