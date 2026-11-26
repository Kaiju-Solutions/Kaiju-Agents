# KaijuAgentsSortAngle

Extension methods for sorting objects by their angle in degrees from a position towards a target around the global Y axis.

~~~csharp
public static class KaijuAgentsSortAngle
~~~

[Package source](../../Runtime/Extensions/KaijuAgentsSortAngle.cs)

<a id="KaijuSolutions_Agents_Extensions_KaijuAgentsSortAngle_SortAngle"></a>

### SortAngle

~~~csharp
public static void SortAngle (this Vector2 position, Vector2 forward, [NotNull] Vector2[] targets, KaijuAngleSortMode mode = KaijuAngleSortMode.Magnitude, bool? farthest = null)
~~~

Sort from the position.

~~~csharp
public static void SortAngle (this Vector2 position, Vector2 forward, [NotNull] List<Vector2> targets, KaijuAngleSortMode mode = KaijuAngleSortMode.Magnitude, bool? farthest = null)
~~~

Sort from the position.

~~~csharp
public static Vector2[] SortAngle (this Vector2 position, Vector2 forward, [NotNull] IEnumerable<Vector2> targets, KaijuAngleSortMode mode = KaijuAngleSortMode.Magnitude, bool? farthest = null)
~~~

Sort from the position.

~~~csharp
public static void SortAngle (this Vector2 position, Vector2 forward, [NotNull] Vector3[] targets, KaijuAngleSortMode mode = KaijuAngleSortMode.Magnitude, bool? farthest = null)
~~~

Sort from the position.

~~~csharp
public static void SortAngle (this Vector2 position, Vector2 forward, [NotNull] List<Vector3> targets, KaijuAngleSortMode mode = KaijuAngleSortMode.Magnitude, bool? farthest = null)
~~~

Sort from the position.

~~~csharp
public static Vector3[] SortAngle (this Vector2 position, Vector2 forward, [NotNull] IEnumerable<Vector3> targets, KaijuAngleSortMode mode = KaijuAngleSortMode.Magnitude, bool? farthest = null)
~~~

Sort from the position.

~~~csharp
public static void SortAngle (this Vector2 position, Vector2 forward, [NotNull] Transform[] targets, KaijuAngleSortMode mode = KaijuAngleSortMode.Magnitude, bool? farthest = null)
~~~

Sort from the position.

~~~csharp
public static void SortAngle (this Vector2 position, Vector2 forward, [NotNull] List<Transform> targets, KaijuAngleSortMode mode = KaijuAngleSortMode.Magnitude, bool? farthest = null)
~~~

Sort from the position.

~~~csharp
public static Transform[] SortAngle (this Vector2 position, Vector2 forward, [NotNull] IEnumerable<Transform> targets, KaijuAngleSortMode mode = KaijuAngleSortMode.Magnitude, bool? farthest = null)
~~~

Sort from the position.

~~~csharp
public static void SortAngle <T> (this Vector2 position, Vector2 forward, [NotNull] T[] targets, KaijuAngleSortMode mode = KaijuAngleSortMode.Magnitude, bool? farthest = null) where T : Component
~~~

Sort from the position.

~~~csharp
public static void SortAngle <T> (this Vector2 position, Vector2 forward, [NotNull] List<T> targets, KaijuAngleSortMode mode = KaijuAngleSortMode.Magnitude, bool? farthest = null) where T : Component
~~~

Sort from the position.

~~~csharp
public static T[] SortAngle <T> (this Vector2 position, Vector2 forward, [NotNull] IEnumerable<T> targets, KaijuAngleSortMode mode = KaijuAngleSortMode.Magnitude, bool? farthest = null) where T : Component
~~~

Sort from the position.

~~~csharp
public static void SortAngle (this Vector2 position, Vector2 forward, [NotNull] GameObject[] targets, KaijuAngleSortMode mode = KaijuAngleSortMode.Magnitude, bool? farthest = null)
~~~

Sort from the position.

~~~csharp
public static void SortAngle (this Vector2 position, Vector2 forward, [NotNull] List<GameObject> targets, KaijuAngleSortMode mode = KaijuAngleSortMode.Magnitude, bool? farthest = null)
~~~

Sort from the position.

~~~csharp
public static GameObject[] SortAngle (this Vector2 position, Vector2 forward, [NotNull] IEnumerable<GameObject> targets, KaijuAngleSortMode mode = KaijuAngleSortMode.Magnitude, bool? farthest = null)
~~~

Sort from the position.

~~~csharp
public static void SortAngle (this Vector2 position, Vector3 forward, [NotNull] Vector2[] targets, KaijuAngleSortMode mode = KaijuAngleSortMode.Magnitude, bool? farthest = null)
~~~

Sort from the position.

~~~csharp
public static void SortAngle (this Vector2 position, Vector3 forward, [NotNull] List<Vector2> targets, KaijuAngleSortMode mode = KaijuAngleSortMode.Magnitude, bool? farthest = null)
~~~

Sort from the position.

~~~csharp
public static Vector2[] SortAngle (this Vector2 position, Vector3 forward, [NotNull] IEnumerable<Vector2> targets, KaijuAngleSortMode mode = KaijuAngleSortMode.Magnitude, bool? farthest = null)
~~~

Sort from the position.

~~~csharp
public static void SortAngle (this Vector2 position, Vector3 forward, [NotNull] Vector3[] targets, KaijuAngleSortMode mode = KaijuAngleSortMode.Magnitude, bool? farthest = null)
~~~

Sort from the position.

~~~csharp
public static void SortAngle (this Vector2 position, Vector3 forward, [NotNull] List<Vector3> targets, KaijuAngleSortMode mode = KaijuAngleSortMode.Magnitude, bool? farthest = null)
~~~

Sort from the position.

~~~csharp
public static Vector3[] SortAngle (this Vector2 position, Vector3 forward, [NotNull] IEnumerable<Vector3> targets, KaijuAngleSortMode mode = KaijuAngleSortMode.Magnitude, bool? farthest = null)
~~~

Sort from the position.

~~~csharp
public static void SortAngle (this Vector2 position, Vector3 forward, [NotNull] Transform[] targets, KaijuAngleSortMode mode = KaijuAngleSortMode.Magnitude, bool? farthest = null)
~~~

Sort from the position.

~~~csharp
public static void SortAngle (this Vector2 position, Vector3 forward, [NotNull] List<Transform> targets, KaijuAngleSortMode mode = KaijuAngleSortMode.Magnitude, bool? farthest = null)
~~~

Sort from the position.

~~~csharp
public static Transform[] SortAngle (this Vector2 position, Vector3 forward, [NotNull] IEnumerable<Transform> targets, KaijuAngleSortMode mode = KaijuAngleSortMode.Magnitude, bool? farthest = null)
~~~

Sort from the position.

~~~csharp
public static void SortAngle <T> (this Vector2 position, Vector3 forward, [NotNull] T[] targets, KaijuAngleSortMode mode = KaijuAngleSortMode.Magnitude, bool? farthest = null) where T : Component
~~~

Sort from the position.

~~~csharp
public static void SortAngle <T> (this Vector2 position, Vector3 forward, [NotNull] List<T> targets, KaijuAngleSortMode mode = KaijuAngleSortMode.Magnitude, bool? farthest = null) where T : Component
~~~

Sort from the position.

~~~csharp
public static T[] SortAngle <T> (this Vector2 position, Vector3 forward, [NotNull] IEnumerable<T> targets, KaijuAngleSortMode mode = KaijuAngleSortMode.Magnitude, bool? farthest = null) where T : Component
~~~

Sort from the position.

~~~csharp
public static void SortAngle (this Vector2 position, Vector3 forward, [NotNull] GameObject[] targets, KaijuAngleSortMode mode = KaijuAngleSortMode.Magnitude, bool? farthest = null)
~~~

Sort from the position.

~~~csharp
public static void SortAngle (this Vector2 position, Vector3 forward, [NotNull] List<GameObject> targets, KaijuAngleSortMode mode = KaijuAngleSortMode.Magnitude, bool? farthest = null)
~~~

Sort from the position.

~~~csharp
public static GameObject[] SortAngle (this Vector2 position, Vector3 forward, [NotNull] IEnumerable<GameObject> targets, KaijuAngleSortMode mode = KaijuAngleSortMode.Magnitude, bool? farthest = null)
~~~

Sort from the position.

~~~csharp
public static void SortAngle (this Vector2 position, [NotNull] Transform forward, [NotNull] Vector2[] targets, KaijuAngleSortMode mode = KaijuAngleSortMode.Magnitude, bool? farthest = null)
~~~

Sort from the position.

~~~csharp
public static void SortAngle (this Vector2 position, [NotNull] Transform forward, [NotNull] List<Vector2> targets, KaijuAngleSortMode mode = KaijuAngleSortMode.Magnitude, bool? farthest = null)
~~~

Sort from the position.

~~~csharp
public static Vector2[] SortAngle (this Vector2 position, [NotNull] Transform forward, [NotNull] IEnumerable<Vector2> targets, KaijuAngleSortMode mode = KaijuAngleSortMode.Magnitude, bool? farthest = null)
~~~

Sort from the position.

~~~csharp
public static void SortAngle (this Vector2 position, [NotNull] Transform forward, [NotNull] Vector3[] targets, KaijuAngleSortMode mode = KaijuAngleSortMode.Magnitude, bool? farthest = null)
~~~

Sort from the position.

~~~csharp
public static void SortAngle (this Vector2 position, [NotNull] Transform forward, [NotNull] List<Vector3> targets, KaijuAngleSortMode mode = KaijuAngleSortMode.Magnitude, bool? farthest = null)
~~~

Sort from the position.

~~~csharp
public static Vector3[] SortAngle (this Vector2 position, [NotNull] Transform forward, [NotNull] IEnumerable<Vector3> targets, KaijuAngleSortMode mode = KaijuAngleSortMode.Magnitude, bool? farthest = null)
~~~

Sort from the position.

~~~csharp
public static void SortAngle (this Vector2 position, [NotNull] Transform forward, [NotNull] Transform[] targets, KaijuAngleSortMode mode = KaijuAngleSortMode.Magnitude, bool? farthest = null)
~~~

Sort from the position.

~~~csharp
public static void SortAngle (this Vector2 position, [NotNull] Transform forward, [NotNull] List<Transform> targets, KaijuAngleSortMode mode = KaijuAngleSortMode.Magnitude, bool? farthest = null)
~~~

Sort from the position.

~~~csharp
public static Transform[] SortAngle (this Vector2 position, [NotNull] Transform forward, [NotNull] IEnumerable<Transform> targets, KaijuAngleSortMode mode = KaijuAngleSortMode.Magnitude, bool? farthest = null)
~~~

Sort from the position.

~~~csharp
public static void SortAngle <T> (this Vector2 position, [NotNull] Transform forward, [NotNull] T[] targets, KaijuAngleSortMode mode = KaijuAngleSortMode.Magnitude, bool? farthest = null) where T : Component
~~~

Sort from the position.

~~~csharp
public static void SortAngle <T> (this Vector2 position, [NotNull] Transform forward, [NotNull] List<T> targets, KaijuAngleSortMode mode = KaijuAngleSortMode.Magnitude, bool? farthest = null) where T : Component
~~~

Sort from the position.

~~~csharp
public static T[] SortAngle <T> (this Vector2 position, [NotNull] Transform forward, [NotNull] IEnumerable<T> targets, KaijuAngleSortMode mode = KaijuAngleSortMode.Magnitude, bool? farthest = null) where T : Component
~~~

Sort from the position.

~~~csharp
public static void SortAngle (this Vector2 position, [NotNull] Transform forward, [NotNull] GameObject[] targets, KaijuAngleSortMode mode = KaijuAngleSortMode.Magnitude, bool? farthest = null)
~~~

Sort from the position.

~~~csharp
public static void SortAngle (this Vector2 position, [NotNull] Transform forward, [NotNull] List<GameObject> targets, KaijuAngleSortMode mode = KaijuAngleSortMode.Magnitude, bool? farthest = null)
~~~

Sort from the position.

~~~csharp
public static GameObject[] SortAngle (this Vector2 position, [NotNull] Transform forward, [NotNull] IEnumerable<GameObject> targets, KaijuAngleSortMode mode = KaijuAngleSortMode.Magnitude, bool? farthest = null)
~~~

Sort from the position.

~~~csharp
public static void SortAngle (this Vector2 position, [NotNull] Component forward, [NotNull] Vector2[] targets, KaijuAngleSortMode mode = KaijuAngleSortMode.Magnitude, bool? farthest = null)
~~~

Sort from the position.

~~~csharp
public static void SortAngle (this Vector2 position, [NotNull] Component forward, [NotNull] List<Vector2> targets, KaijuAngleSortMode mode = KaijuAngleSortMode.Magnitude, bool? farthest = null)
~~~

Sort from the position.

~~~csharp
public static Vector2[] SortAngle (this Vector2 position, [NotNull] Component forward, [NotNull] IEnumerable<Vector2> targets, KaijuAngleSortMode mode = KaijuAngleSortMode.Magnitude, bool? farthest = null)
~~~

Sort from the position.

~~~csharp
public static void SortAngle (this Vector2 position, [NotNull] Component forward, [NotNull] Vector3[] targets, KaijuAngleSortMode mode = KaijuAngleSortMode.Magnitude, bool? farthest = null)
~~~

Sort from the position.

~~~csharp
public static void SortAngle (this Vector2 position, [NotNull] Component forward, [NotNull] List<Vector3> targets, KaijuAngleSortMode mode = KaijuAngleSortMode.Magnitude, bool? farthest = null)
~~~

Sort from the position.

~~~csharp
public static Vector3[] SortAngle (this Vector2 position, [NotNull] Component forward, [NotNull] IEnumerable<Vector3> targets, KaijuAngleSortMode mode = KaijuAngleSortMode.Magnitude, bool? farthest = null)
~~~

Sort from the position.

~~~csharp
public static void SortAngle (this Vector2 position, [NotNull] Component forward, [NotNull] Transform[] targets, KaijuAngleSortMode mode = KaijuAngleSortMode.Magnitude, bool? farthest = null)
~~~

Sort from the position.

~~~csharp
public static void SortAngle (this Vector2 position, [NotNull] Component forward, [NotNull] List<Transform> targets, KaijuAngleSortMode mode = KaijuAngleSortMode.Magnitude, bool? farthest = null)
~~~

Sort from the position.

~~~csharp
public static Transform[] SortAngle (this Vector2 position, [NotNull] Component forward, [NotNull] IEnumerable<Transform> targets, KaijuAngleSortMode mode = KaijuAngleSortMode.Magnitude, bool? farthest = null)
~~~

Sort from the position.

~~~csharp
public static void SortAngle <T> (this Vector2 position, [NotNull] Component forward, [NotNull] T[] targets, KaijuAngleSortMode mode = KaijuAngleSortMode.Magnitude, bool? farthest = null) where T : Component
~~~

Sort from the position.

~~~csharp
public static void SortAngle <T> (this Vector2 position, [NotNull] Component forward, [NotNull] List<T> targets, KaijuAngleSortMode mode = KaijuAngleSortMode.Magnitude, bool? farthest = null) where T : Component
~~~

Sort from the position.

~~~csharp
public static T[] SortAngle <T> (this Vector2 position, [NotNull] Component forward, [NotNull] IEnumerable<T> targets, KaijuAngleSortMode mode = KaijuAngleSortMode.Magnitude, bool? farthest = null) where T : Component
~~~

Sort from the position.

~~~csharp
public static void SortAngle (this Vector2 position, [NotNull] Component forward, [NotNull] GameObject[] targets, KaijuAngleSortMode mode = KaijuAngleSortMode.Magnitude, bool? farthest = null)
~~~

Sort from the position.

~~~csharp
public static void SortAngle (this Vector2 position, [NotNull] Component forward, [NotNull] List<GameObject> targets, KaijuAngleSortMode mode = KaijuAngleSortMode.Magnitude, bool? farthest = null)
~~~

Sort from the position.

~~~csharp
public static GameObject[] SortAngle (this Vector2 position, [NotNull] Component forward, [NotNull] IEnumerable<GameObject> targets, KaijuAngleSortMode mode = KaijuAngleSortMode.Magnitude, bool? farthest = null)
~~~

Sort from the position.

~~~csharp
public static void SortAngle (this Vector2 position, [NotNull] GameObject forward, [NotNull] Vector2[] targets, KaijuAngleSortMode mode = KaijuAngleSortMode.Magnitude, bool? farthest = null)
~~~

Sort from the position.

~~~csharp
public static void SortAngle (this Vector2 position, [NotNull] GameObject forward, [NotNull] List<Vector2> targets, KaijuAngleSortMode mode = KaijuAngleSortMode.Magnitude, bool? farthest = null)
~~~

Sort from the position.

~~~csharp
public static Vector2[] SortAngle (this Vector2 position, [NotNull] GameObject forward, [NotNull] IEnumerable<Vector2> targets, KaijuAngleSortMode mode = KaijuAngleSortMode.Magnitude, bool? farthest = null)
~~~

Sort from the position.

~~~csharp
public static void SortAngle (this Vector2 position, [NotNull] GameObject forward, [NotNull] Vector3[] targets, KaijuAngleSortMode mode = KaijuAngleSortMode.Magnitude, bool? farthest = null)
~~~

Sort from the position.

~~~csharp
public static void SortAngle (this Vector2 position, [NotNull] GameObject forward, [NotNull] List<Vector3> targets, KaijuAngleSortMode mode = KaijuAngleSortMode.Magnitude, bool? farthest = null)
~~~

Sort from the position.

~~~csharp
public static Vector3[] SortAngle (this Vector2 position, [NotNull] GameObject forward, [NotNull] IEnumerable<Vector3> targets, KaijuAngleSortMode mode = KaijuAngleSortMode.Magnitude, bool? farthest = null)
~~~

Sort from the position.

~~~csharp
public static void SortAngle (this Vector2 position, [NotNull] GameObject forward, [NotNull] Transform[] targets, KaijuAngleSortMode mode = KaijuAngleSortMode.Magnitude, bool? farthest = null)
~~~

Sort from the position.

~~~csharp
public static void SortAngle (this Vector2 position, [NotNull] GameObject forward, [NotNull] List<Transform> targets, KaijuAngleSortMode mode = KaijuAngleSortMode.Magnitude, bool? farthest = null)
~~~

Sort from the position.

~~~csharp
public static Transform[] SortAngle (this Vector2 position, [NotNull] GameObject forward, [NotNull] IEnumerable<Transform> targets, KaijuAngleSortMode mode = KaijuAngleSortMode.Magnitude, bool? farthest = null)
~~~

Sort from the position.

~~~csharp
public static void SortAngle <T> (this Vector2 position, [NotNull] GameObject forward, [NotNull] T[] targets, KaijuAngleSortMode mode = KaijuAngleSortMode.Magnitude, bool? farthest = null) where T : Component
~~~

Sort from the position.

~~~csharp
public static void SortAngle <T> (this Vector2 position, [NotNull] GameObject forward, [NotNull] List<T> targets, KaijuAngleSortMode mode = KaijuAngleSortMode.Magnitude, bool? farthest = null) where T : Component
~~~

Sort from the position.

~~~csharp
public static T[] SortAngle <T> (this Vector2 position, [NotNull] GameObject forward, [NotNull] IEnumerable<T> targets, KaijuAngleSortMode mode = KaijuAngleSortMode.Magnitude, bool? farthest = null) where T : Component
~~~

Sort from the position.

~~~csharp
public static void SortAngle (this Vector2 position, [NotNull] GameObject forward, [NotNull] GameObject[] targets, KaijuAngleSortMode mode = KaijuAngleSortMode.Magnitude, bool? farthest = null)
~~~

Sort from the position.

~~~csharp
public static void SortAngle (this Vector2 position, [NotNull] GameObject forward, [NotNull] List<GameObject> targets, KaijuAngleSortMode mode = KaijuAngleSortMode.Magnitude, bool? farthest = null)
~~~

Sort from the position.

~~~csharp
public static GameObject[] SortAngle (this Vector2 position, [NotNull] GameObject forward, [NotNull] IEnumerable<GameObject> targets, KaijuAngleSortMode mode = KaijuAngleSortMode.Magnitude, bool? farthest = null)
~~~

Sort from the position.

~~~csharp
public static void SortAngle (this Vector3 position, Vector2 forward, [NotNull] Vector2[] targets, KaijuAngleSortMode mode = KaijuAngleSortMode.Magnitude, bool? farthest = null)
~~~

Sort from the position.

~~~csharp
public static void SortAngle (this Vector3 position, Vector2 forward, [NotNull] List<Vector2> targets, KaijuAngleSortMode mode = KaijuAngleSortMode.Magnitude, bool? farthest = null)
~~~

Sort from the position.

~~~csharp
public static Vector2[] SortAngle (this Vector3 position, Vector2 forward, [NotNull] IEnumerable<Vector2> targets, KaijuAngleSortMode mode = KaijuAngleSortMode.Magnitude, bool? farthest = null)
~~~

Sort from the position.

~~~csharp
public static void SortAngle (this Vector3 position, Vector2 forward, [NotNull] Vector3[] targets, KaijuAngleSortMode mode = KaijuAngleSortMode.Magnitude, bool? farthest = null)
~~~

Sort from the position.

~~~csharp
public static void SortAngle (this Vector3 position, Vector2 forward, [NotNull] List<Vector3> targets, KaijuAngleSortMode mode = KaijuAngleSortMode.Magnitude, bool? farthest = null)
~~~

Sort from the position.

~~~csharp
public static Vector3[] SortAngle (this Vector3 position, Vector2 forward, [NotNull] IEnumerable<Vector3> targets, KaijuAngleSortMode mode = KaijuAngleSortMode.Magnitude, bool? farthest = null)
~~~

Sort from the position.

~~~csharp
public static void SortAngle (this Vector3 position, Vector2 forward, [NotNull] Transform[] targets, KaijuAngleSortMode mode = KaijuAngleSortMode.Magnitude, bool? farthest = null)
~~~

Sort from the position.

~~~csharp
public static void SortAngle (this Vector3 position, Vector2 forward, [NotNull] List<Transform> targets, KaijuAngleSortMode mode = KaijuAngleSortMode.Magnitude, bool? farthest = null)
~~~

Sort from the position.

~~~csharp
public static Transform[] SortAngle (this Vector3 position, Vector2 forward, [NotNull] IEnumerable<Transform> targets, KaijuAngleSortMode mode = KaijuAngleSortMode.Magnitude, bool? farthest = null)
~~~

Sort from the position.

~~~csharp
public static void SortAngle <T> (this Vector3 position, Vector2 forward, [NotNull] T[] targets, KaijuAngleSortMode mode = KaijuAngleSortMode.Magnitude, bool? farthest = null) where T : Component
~~~

Sort from the position.

~~~csharp
public static void SortAngle <T> (this Vector3 position, Vector2 forward, [NotNull] List<T> targets, KaijuAngleSortMode mode = KaijuAngleSortMode.Magnitude, bool? farthest = null) where T : Component
~~~

Sort from the position.

~~~csharp
public static T[] SortAngle <T> (this Vector3 position, Vector2 forward, [NotNull] IEnumerable<T> targets, KaijuAngleSortMode mode = KaijuAngleSortMode.Magnitude, bool? farthest = null) where T : Component
~~~

Sort from the position.

~~~csharp
public static void SortAngle (this Vector3 position, Vector2 forward, [NotNull] GameObject[] targets, KaijuAngleSortMode mode = KaijuAngleSortMode.Magnitude, bool? farthest = null)
~~~

Sort from the position.

~~~csharp
public static void SortAngle (this Vector3 position, Vector2 forward, [NotNull] List<GameObject> targets, KaijuAngleSortMode mode = KaijuAngleSortMode.Magnitude, bool? farthest = null)
~~~

Sort from the position.

~~~csharp
public static GameObject[] SortAngle (this Vector3 position, Vector2 forward, [NotNull] IEnumerable<GameObject> targets, KaijuAngleSortMode mode = KaijuAngleSortMode.Magnitude, bool? farthest = null)
~~~

Sort from the position.

~~~csharp
public static void SortAngle (this Vector3 position, Vector3 forward, [NotNull] Vector2[] targets, KaijuAngleSortMode mode = KaijuAngleSortMode.Magnitude, bool? farthest = null)
~~~

Sort from the position.

~~~csharp
public static void SortAngle (this Vector3 position, Vector3 forward, [NotNull] List<Vector2> targets, KaijuAngleSortMode mode = KaijuAngleSortMode.Magnitude, bool? farthest = null)
~~~

Sort from the position.

~~~csharp
public static Vector2[] SortAngle (this Vector3 position, Vector3 forward, [NotNull] IEnumerable<Vector2> targets, KaijuAngleSortMode mode = KaijuAngleSortMode.Magnitude, bool? farthest = null)
~~~

Sort from the position.

~~~csharp
public static void SortAngle (this Vector3 position, Vector3 forward, [NotNull] Vector3[] targets, KaijuAngleSortMode mode = KaijuAngleSortMode.Magnitude, bool? farthest = null)
~~~

Sort from the position.

~~~csharp
public static void SortAngle (this Vector3 position, Vector3 forward, [NotNull] List<Vector3> targets, KaijuAngleSortMode mode = KaijuAngleSortMode.Magnitude, bool? farthest = null)
~~~

Sort from the position.

~~~csharp
public static Vector3[] SortAngle (this Vector3 position, Vector3 forward, [NotNull] IEnumerable<Vector3> targets, KaijuAngleSortMode mode = KaijuAngleSortMode.Magnitude, bool? farthest = null)
~~~

Sort from the position.

~~~csharp
public static void SortAngle (this Vector3 position, Vector3 forward, [NotNull] Transform[] targets, KaijuAngleSortMode mode = KaijuAngleSortMode.Magnitude, bool? farthest = null)
~~~

Sort from the position.

~~~csharp
public static void SortAngle (this Vector3 position, Vector3 forward, [NotNull] List<Transform> targets, KaijuAngleSortMode mode = KaijuAngleSortMode.Magnitude, bool? farthest = null)
~~~

Sort from the position.

~~~csharp
public static Transform[] SortAngle (this Vector3 position, Vector3 forward, [NotNull] IEnumerable<Transform> targets, KaijuAngleSortMode mode = KaijuAngleSortMode.Magnitude, bool? farthest = null)
~~~

Sort from the position.

~~~csharp
public static void SortAngle <T> (this Vector3 position, Vector3 forward, [NotNull] T[] targets, KaijuAngleSortMode mode = KaijuAngleSortMode.Magnitude, bool? farthest = null) where T : Component
~~~

Sort from the position.

~~~csharp
public static void SortAngle <T> (this Vector3 position, Vector3 forward, [NotNull] List<T> targets, KaijuAngleSortMode mode = KaijuAngleSortMode.Magnitude, bool? farthest = null) where T : Component
~~~

Sort from the position.

~~~csharp
public static T[] SortAngle <T> (this Vector3 position, Vector3 forward, [NotNull] IEnumerable<T> targets, KaijuAngleSortMode mode = KaijuAngleSortMode.Magnitude, bool? farthest = null) where T : Component
~~~

Sort from the position.

~~~csharp
public static void SortAngle (this Vector3 position, Vector3 forward, [NotNull] GameObject[] targets, KaijuAngleSortMode mode = KaijuAngleSortMode.Magnitude, bool? farthest = null)
~~~

Sort from the position.

~~~csharp
public static void SortAngle (this Vector3 position, Vector3 forward, [NotNull] List<GameObject> targets, KaijuAngleSortMode mode = KaijuAngleSortMode.Magnitude, bool? farthest = null)
~~~

Sort from the position.

~~~csharp
public static GameObject[] SortAngle (this Vector3 position, Vector3 forward, [NotNull] IEnumerable<GameObject> targets, KaijuAngleSortMode mode = KaijuAngleSortMode.Magnitude, bool? farthest = null)
~~~

Sort from the position.

~~~csharp
public static void SortAngle (this Vector3 position, [NotNull] Transform forward, [NotNull] Vector2[] targets, KaijuAngleSortMode mode = KaijuAngleSortMode.Magnitude, bool? farthest = null)
~~~

Sort from the position.

~~~csharp
public static void SortAngle (this Vector3 position, [NotNull] Transform forward, [NotNull] List<Vector2> targets, KaijuAngleSortMode mode = KaijuAngleSortMode.Magnitude, bool? farthest = null)
~~~

Sort from the position.

~~~csharp
public static Vector2[] SortAngle (this Vector3 position, [NotNull] Transform forward, [NotNull] IEnumerable<Vector2> targets, KaijuAngleSortMode mode = KaijuAngleSortMode.Magnitude, bool? farthest = null)
~~~

Sort from the position.

~~~csharp
public static void SortAngle (this Vector3 position, [NotNull] Transform forward, [NotNull] Vector3[] targets, KaijuAngleSortMode mode = KaijuAngleSortMode.Magnitude, bool? farthest = null)
~~~

Sort from the position.

~~~csharp
public static void SortAngle (this Vector3 position, [NotNull] Transform forward, [NotNull] List<Vector3> targets, KaijuAngleSortMode mode = KaijuAngleSortMode.Magnitude, bool? farthest = null)
~~~

Sort from the position.

~~~csharp
public static Vector3[] SortAngle (this Vector3 position, [NotNull] Transform forward, [NotNull] IEnumerable<Vector3> targets, KaijuAngleSortMode mode = KaijuAngleSortMode.Magnitude, bool? farthest = null)
~~~

Sort from the position.

~~~csharp
public static void SortAngle (this Vector3 position, [NotNull] Transform forward, [NotNull] Transform[] targets, KaijuAngleSortMode mode = KaijuAngleSortMode.Magnitude, bool? farthest = null)
~~~

Sort from the position.

~~~csharp
public static void SortAngle (this Vector3 position, [NotNull] Transform forward, [NotNull] List<Transform> targets, KaijuAngleSortMode mode = KaijuAngleSortMode.Magnitude, bool? farthest = null)
~~~

Sort from the position.

~~~csharp
public static Transform[] SortAngle (this Vector3 position, [NotNull] Transform forward, [NotNull] IEnumerable<Transform> targets, KaijuAngleSortMode mode = KaijuAngleSortMode.Magnitude, bool? farthest = null)
~~~

Sort from the position.

~~~csharp
public static void SortAngle <T> (this Vector3 position, [NotNull] Transform forward, [NotNull] T[] targets, KaijuAngleSortMode mode = KaijuAngleSortMode.Magnitude, bool? farthest = null) where T : Component
~~~

Sort from the position.

~~~csharp
public static void SortAngle <T> (this Vector3 position, [NotNull] Transform forward, [NotNull] List<T> targets, KaijuAngleSortMode mode = KaijuAngleSortMode.Magnitude, bool? farthest = null) where T : Component
~~~

Sort from the position.

~~~csharp
public static T[] SortAngle <T> (this Vector3 position, [NotNull] Transform forward, [NotNull] IEnumerable<T> targets, KaijuAngleSortMode mode = KaijuAngleSortMode.Magnitude, bool? farthest = null) where T : Component
~~~

Sort from the position.

~~~csharp
public static void SortAngle (this Vector3 position, [NotNull] Transform forward, [NotNull] GameObject[] targets, KaijuAngleSortMode mode = KaijuAngleSortMode.Magnitude, bool? farthest = null)
~~~

Sort from the position.

~~~csharp
public static void SortAngle (this Vector3 position, [NotNull] Transform forward, [NotNull] List<GameObject> targets, KaijuAngleSortMode mode = KaijuAngleSortMode.Magnitude, bool? farthest = null)
~~~

Sort from the position.

~~~csharp
public static GameObject[] SortAngle (this Vector3 position, [NotNull] Transform forward, [NotNull] IEnumerable<GameObject> targets, KaijuAngleSortMode mode = KaijuAngleSortMode.Magnitude, bool? farthest = null)
~~~

Sort from the position.

~~~csharp
public static void SortAngle (this Vector3 position, [NotNull] Component forward, [NotNull] Vector2[] targets, KaijuAngleSortMode mode = KaijuAngleSortMode.Magnitude, bool? farthest = null)
~~~

Sort from the position.

~~~csharp
public static void SortAngle (this Vector3 position, [NotNull] Component forward, [NotNull] List<Vector2> targets, KaijuAngleSortMode mode = KaijuAngleSortMode.Magnitude, bool? farthest = null)
~~~

Sort from the position.

~~~csharp
public static Vector2[] SortAngle (this Vector3 position, [NotNull] Component forward, [NotNull] IEnumerable<Vector2> targets, KaijuAngleSortMode mode = KaijuAngleSortMode.Magnitude, bool? farthest = null)
~~~

Sort from the position.

~~~csharp
public static void SortAngle (this Vector3 position, [NotNull] Component forward, [NotNull] Vector3[] targets, KaijuAngleSortMode mode = KaijuAngleSortMode.Magnitude, bool? farthest = null)
~~~

Sort from the position.

~~~csharp
public static void SortAngle (this Vector3 position, [NotNull] Component forward, [NotNull] List<Vector3> targets, KaijuAngleSortMode mode = KaijuAngleSortMode.Magnitude, bool? farthest = null)
~~~

Sort from the position.

~~~csharp
public static Vector3[] SortAngle (this Vector3 position, [NotNull] Component forward, [NotNull] IEnumerable<Vector3> targets, KaijuAngleSortMode mode = KaijuAngleSortMode.Magnitude, bool? farthest = null)
~~~

Sort from the position.

~~~csharp
public static void SortAngle (this Vector3 position, [NotNull] Component forward, [NotNull] Transform[] targets, KaijuAngleSortMode mode = KaijuAngleSortMode.Magnitude, bool? farthest = null)
~~~

Sort from the position.

~~~csharp
public static void SortAngle (this Vector3 position, [NotNull] Component forward, [NotNull] List<Transform> targets, KaijuAngleSortMode mode = KaijuAngleSortMode.Magnitude, bool? farthest = null)
~~~

Sort from the position.

~~~csharp
public static Transform[] SortAngle (this Vector3 position, [NotNull] Component forward, [NotNull] IEnumerable<Transform> targets, KaijuAngleSortMode mode = KaijuAngleSortMode.Magnitude, bool? farthest = null)
~~~

Sort from the position.

~~~csharp
public static void SortAngle <T> (this Vector3 position, [NotNull] Component forward, [NotNull] T[] targets, KaijuAngleSortMode mode = KaijuAngleSortMode.Magnitude, bool? farthest = null) where T : Component
~~~

Sort from the position.

~~~csharp
public static void SortAngle <T> (this Vector3 position, [NotNull] Component forward, [NotNull] List<T> targets, KaijuAngleSortMode mode = KaijuAngleSortMode.Magnitude, bool? farthest = null) where T : Component
~~~

Sort from the position.

~~~csharp
public static T[] SortAngle <T> (this Vector3 position, [NotNull] Component forward, [NotNull] IEnumerable<T> targets, KaijuAngleSortMode mode = KaijuAngleSortMode.Magnitude, bool? farthest = null) where T : Component
~~~

Sort from the position.

~~~csharp
public static void SortAngle (this Vector3 position, [NotNull] Component forward, [NotNull] GameObject[] targets, KaijuAngleSortMode mode = KaijuAngleSortMode.Magnitude, bool? farthest = null)
~~~

Sort from the position.

~~~csharp
public static void SortAngle (this Vector3 position, [NotNull] Component forward, [NotNull] List<GameObject> targets, KaijuAngleSortMode mode = KaijuAngleSortMode.Magnitude, bool? farthest = null)
~~~

Sort from the position.

~~~csharp
public static GameObject[] SortAngle (this Vector3 position, [NotNull] Component forward, [NotNull] IEnumerable<GameObject> targets, KaijuAngleSortMode mode = KaijuAngleSortMode.Magnitude, bool? farthest = null)
~~~

Sort from the position.

~~~csharp
public static void SortAngle (this Vector3 position, [NotNull] GameObject forward, [NotNull] Vector2[] targets, KaijuAngleSortMode mode = KaijuAngleSortMode.Magnitude, bool? farthest = null)
~~~

Sort from the position.

~~~csharp
public static void SortAngle (this Vector3 position, [NotNull] GameObject forward, [NotNull] List<Vector2> targets, KaijuAngleSortMode mode = KaijuAngleSortMode.Magnitude, bool? farthest = null)
~~~

Sort from the position.

~~~csharp
public static Vector2[] SortAngle (this Vector3 position, [NotNull] GameObject forward, [NotNull] IEnumerable<Vector2> targets, KaijuAngleSortMode mode = KaijuAngleSortMode.Magnitude, bool? farthest = null)
~~~

Sort from the position.

~~~csharp
public static void SortAngle (this Vector3 position, [NotNull] GameObject forward, [NotNull] Vector3[] targets, KaijuAngleSortMode mode = KaijuAngleSortMode.Magnitude, bool? farthest = null)
~~~

Sort from the position.

~~~csharp
public static void SortAngle (this Vector3 position, [NotNull] GameObject forward, [NotNull] List<Vector3> targets, KaijuAngleSortMode mode = KaijuAngleSortMode.Magnitude, bool? farthest = null)
~~~

Sort from the position.

~~~csharp
public static Vector3[] SortAngle (this Vector3 position, [NotNull] GameObject forward, [NotNull] IEnumerable<Vector3> targets, KaijuAngleSortMode mode = KaijuAngleSortMode.Magnitude, bool? farthest = null)
~~~

Sort from the position.

~~~csharp
public static void SortAngle (this Vector3 position, [NotNull] GameObject forward, [NotNull] Transform[] targets, KaijuAngleSortMode mode = KaijuAngleSortMode.Magnitude, bool? farthest = null)
~~~

Sort from the position.

~~~csharp
public static void SortAngle (this Vector3 position, [NotNull] GameObject forward, [NotNull] List<Transform> targets, KaijuAngleSortMode mode = KaijuAngleSortMode.Magnitude, bool? farthest = null)
~~~

Sort from the position.

~~~csharp
public static Transform[] SortAngle (this Vector3 position, [NotNull] GameObject forward, [NotNull] IEnumerable<Transform> targets, KaijuAngleSortMode mode = KaijuAngleSortMode.Magnitude, bool? farthest = null)
~~~

Sort from the position.

~~~csharp
public static void SortAngle <T> (this Vector3 position, [NotNull] GameObject forward, [NotNull] T[] targets, KaijuAngleSortMode mode = KaijuAngleSortMode.Magnitude, bool? farthest = null) where T : Component
~~~

Sort from the position.

~~~csharp
public static void SortAngle <T> (this Vector3 position, [NotNull] GameObject forward, [NotNull] List<T> targets, KaijuAngleSortMode mode = KaijuAngleSortMode.Magnitude, bool? farthest = null) where T : Component
~~~

Sort from the position.

~~~csharp
public static T[] SortAngle <T> (this Vector3 position, [NotNull] GameObject forward, [NotNull] IEnumerable<T> targets, KaijuAngleSortMode mode = KaijuAngleSortMode.Magnitude, bool? farthest = null) where T : Component
~~~

Sort from the position.

~~~csharp
public static void SortAngle (this Vector3 position, [NotNull] GameObject forward, [NotNull] GameObject[] targets, KaijuAngleSortMode mode = KaijuAngleSortMode.Magnitude, bool? farthest = null)
~~~

Sort from the position.

~~~csharp
public static void SortAngle (this Vector3 position, [NotNull] GameObject forward, [NotNull] List<GameObject> targets, KaijuAngleSortMode mode = KaijuAngleSortMode.Magnitude, bool? farthest = null)
~~~

Sort from the position.

~~~csharp
public static GameObject[] SortAngle (this Vector3 position, [NotNull] GameObject forward, [NotNull] IEnumerable<GameObject> targets, KaijuAngleSortMode mode = KaijuAngleSortMode.Magnitude, bool? farthest = null)
~~~

Sort from the position.

~~~csharp
public static void SortAngle ([NotNull] this Transform position, Vector2 forward, [NotNull] Vector2[] targets, KaijuAngleSortMode mode = KaijuAngleSortMode.Magnitude, bool? farthest = null)
~~~

Sort from the position.

~~~csharp
public static void SortAngle ([NotNull] this Transform position, Vector2 forward, [NotNull] List<Vector2> targets, KaijuAngleSortMode mode = KaijuAngleSortMode.Magnitude, bool? farthest = null)
~~~

Sort from the position.

~~~csharp
public static Vector2[] SortAngle ([NotNull] this Transform position, Vector2 forward, [NotNull] IEnumerable<Vector2> targets, KaijuAngleSortMode mode = KaijuAngleSortMode.Magnitude, bool? farthest = null)
~~~

Sort from the position.

~~~csharp
public static void SortAngle ([NotNull] this Transform position, Vector2 forward, [NotNull] Vector3[] targets, KaijuAngleSortMode mode = KaijuAngleSortMode.Magnitude, bool? farthest = null)
~~~

Sort from the position.

~~~csharp
public static void SortAngle ([NotNull] this Transform position, Vector2 forward, [NotNull] List<Vector3> targets, KaijuAngleSortMode mode = KaijuAngleSortMode.Magnitude, bool? farthest = null)
~~~

Sort from the position.

~~~csharp
public static Vector3[] SortAngle ([NotNull] this Transform position, Vector2 forward, [NotNull] IEnumerable<Vector3> targets, KaijuAngleSortMode mode = KaijuAngleSortMode.Magnitude, bool? farthest = null)
~~~

Sort from the position.

~~~csharp
public static void SortAngle ([NotNull] this Transform position, Vector2 forward, [NotNull] Transform[] targets, KaijuAngleSortMode mode = KaijuAngleSortMode.Magnitude, bool? farthest = null)
~~~

Sort from the position.

~~~csharp
public static void SortAngle ([NotNull] this Transform position, Vector2 forward, [NotNull] List<Transform> targets, KaijuAngleSortMode mode = KaijuAngleSortMode.Magnitude, bool? farthest = null)
~~~

Sort from the position.

~~~csharp
public static Transform[] SortAngle ([NotNull] this Transform position, Vector2 forward, [NotNull] IEnumerable<Transform> targets, KaijuAngleSortMode mode = KaijuAngleSortMode.Magnitude, bool? farthest = null)
~~~

Sort from the position.

~~~csharp
public static void SortAngle <T> ([NotNull] this Transform position, Vector2 forward, [NotNull] T[] targets, KaijuAngleSortMode mode = KaijuAngleSortMode.Magnitude, bool? farthest = null) where T : Component
~~~

Sort from the position.

~~~csharp
public static void SortAngle <T> ([NotNull] this Transform position, Vector2 forward, [NotNull] List<T> targets, KaijuAngleSortMode mode = KaijuAngleSortMode.Magnitude, bool? farthest = null) where T : Component
~~~

Sort from the position.

~~~csharp
public static T[] SortAngle <T> ([NotNull] this Transform position, Vector2 forward, [NotNull] IEnumerable<T> targets, KaijuAngleSortMode mode = KaijuAngleSortMode.Magnitude, bool? farthest = null) where T : Component
~~~

Sort from the position.

~~~csharp
public static void SortAngle ([NotNull] this Transform position, Vector2 forward, [NotNull] GameObject[] targets, KaijuAngleSortMode mode = KaijuAngleSortMode.Magnitude, bool? farthest = null)
~~~

Sort from the position.

~~~csharp
public static void SortAngle ([NotNull] this Transform position, Vector2 forward, [NotNull] List<GameObject> targets, KaijuAngleSortMode mode = KaijuAngleSortMode.Magnitude, bool? farthest = null)
~~~

Sort from the position.

~~~csharp
public static GameObject[] SortAngle ([NotNull] this Transform position, Vector2 forward, [NotNull] IEnumerable<GameObject> targets, KaijuAngleSortMode mode = KaijuAngleSortMode.Magnitude, bool? farthest = null)
~~~

Sort from the position.

~~~csharp
public static void SortAngle ([NotNull] this Transform position, Vector3 forward, [NotNull] Vector2[] targets, KaijuAngleSortMode mode = KaijuAngleSortMode.Magnitude, bool? farthest = null)
~~~

Sort from the position.

~~~csharp
public static void SortAngle ([NotNull] this Transform position, Vector3 forward, [NotNull] List<Vector2> targets, KaijuAngleSortMode mode = KaijuAngleSortMode.Magnitude, bool? farthest = null)
~~~

Sort from the position.

~~~csharp
public static Vector2[] SortAngle ([NotNull] this Transform position, Vector3 forward, [NotNull] IEnumerable<Vector2> targets, KaijuAngleSortMode mode = KaijuAngleSortMode.Magnitude, bool? farthest = null)
~~~

Sort from the position.

~~~csharp
public static void SortAngle ([NotNull] this Transform position, Vector3 forward, [NotNull] Vector3[] targets, KaijuAngleSortMode mode = KaijuAngleSortMode.Magnitude, bool? farthest = null)
~~~

Sort from the position.

~~~csharp
public static void SortAngle ([NotNull] this Transform position, Vector3 forward, [NotNull] List<Vector3> targets, KaijuAngleSortMode mode = KaijuAngleSortMode.Magnitude, bool? farthest = null)
~~~

Sort from the position.

~~~csharp
public static Vector3[] SortAngle ([NotNull] this Transform position, Vector3 forward, [NotNull] IEnumerable<Vector3> targets, KaijuAngleSortMode mode = KaijuAngleSortMode.Magnitude, bool? farthest = null)
~~~

Sort from the position.

~~~csharp
public static void SortAngle ([NotNull] this Transform position, Vector3 forward, [NotNull] Transform[] targets, KaijuAngleSortMode mode = KaijuAngleSortMode.Magnitude, bool? farthest = null)
~~~

Sort from the position.

~~~csharp
public static void SortAngle ([NotNull] this Transform position, Vector3 forward, [NotNull] List<Transform> targets, KaijuAngleSortMode mode = KaijuAngleSortMode.Magnitude, bool? farthest = null)
~~~

Sort from the position.

~~~csharp
public static Transform[] SortAngle ([NotNull] this Transform position, Vector3 forward, [NotNull] IEnumerable<Transform> targets, KaijuAngleSortMode mode = KaijuAngleSortMode.Magnitude, bool? farthest = null)
~~~

Sort from the position.

~~~csharp
public static void SortAngle <T> ([NotNull] this Transform position, Vector3 forward, [NotNull] T[] targets, KaijuAngleSortMode mode = KaijuAngleSortMode.Magnitude, bool? farthest = null) where T : Component
~~~

Sort from the position.

~~~csharp
public static void SortAngle <T> ([NotNull] this Transform position, Vector3 forward, [NotNull] List<T> targets, KaijuAngleSortMode mode = KaijuAngleSortMode.Magnitude, bool? farthest = null) where T : Component
~~~

Sort from the position.

~~~csharp
public static T[] SortAngle <T> ([NotNull] this Transform position, Vector3 forward, [NotNull] IEnumerable<T> targets, KaijuAngleSortMode mode = KaijuAngleSortMode.Magnitude, bool? farthest = null) where T : Component
~~~

Sort from the position.

~~~csharp
public static void SortAngle ([NotNull] this Transform position, Vector3 forward, [NotNull] GameObject[] targets, KaijuAngleSortMode mode = KaijuAngleSortMode.Magnitude, bool? farthest = null)
~~~

Sort from the position.

~~~csharp
public static void SortAngle ([NotNull] this Transform position, Vector3 forward, [NotNull] List<GameObject> targets, KaijuAngleSortMode mode = KaijuAngleSortMode.Magnitude, bool? farthest = null)
~~~

Sort from the position.

~~~csharp
public static GameObject[] SortAngle ([NotNull] this Transform position, Vector3 forward, [NotNull] IEnumerable<GameObject> targets, KaijuAngleSortMode mode = KaijuAngleSortMode.Magnitude, bool? farthest = null)
~~~

Sort from the position.

~~~csharp
public static void SortAngle ([NotNull] this Transform position, [NotNull] Transform forward, [NotNull] Vector2[] targets, KaijuAngleSortMode mode = KaijuAngleSortMode.Magnitude, bool? farthest = null)
~~~

Sort from the position.

~~~csharp
public static void SortAngle ([NotNull] this Transform position, [NotNull] Transform forward, [NotNull] List<Vector2> targets, KaijuAngleSortMode mode = KaijuAngleSortMode.Magnitude, bool? farthest = null)
~~~

Sort from the position.

~~~csharp
public static Vector2[] SortAngle ([NotNull] this Transform position, [NotNull] Transform forward, [NotNull] IEnumerable<Vector2> targets, KaijuAngleSortMode mode = KaijuAngleSortMode.Magnitude, bool? farthest = null)
~~~

Sort from the position.

~~~csharp
public static void SortAngle ([NotNull] this Transform position, [NotNull] Transform forward, [NotNull] Vector3[] targets, KaijuAngleSortMode mode = KaijuAngleSortMode.Magnitude, bool? farthest = null)
~~~

Sort from the position.

~~~csharp
public static void SortAngle ([NotNull] this Transform position, [NotNull] Transform forward, [NotNull] List<Vector3> targets, KaijuAngleSortMode mode = KaijuAngleSortMode.Magnitude, bool? farthest = null)
~~~

Sort from the position.

~~~csharp
public static Vector3[] SortAngle ([NotNull] this Transform position, [NotNull] Transform forward, [NotNull] IEnumerable<Vector3> targets, KaijuAngleSortMode mode = KaijuAngleSortMode.Magnitude, bool? farthest = null)
~~~

Sort from the position.

~~~csharp
public static void SortAngle ([NotNull] this Transform position, [NotNull] Transform forward, [NotNull] Transform[] targets, KaijuAngleSortMode mode = KaijuAngleSortMode.Magnitude, bool? farthest = null)
~~~

Sort from the position.

~~~csharp
public static void SortAngle ([NotNull] this Transform position, [NotNull] Transform forward, [NotNull] List<Transform> targets, KaijuAngleSortMode mode = KaijuAngleSortMode.Magnitude, bool? farthest = null)
~~~

Sort from the position.

~~~csharp
public static Transform[] SortAngle ([NotNull] this Transform position, [NotNull] Transform forward, [NotNull] IEnumerable<Transform> targets, KaijuAngleSortMode mode = KaijuAngleSortMode.Magnitude, bool? farthest = null)
~~~

Sort from the position.

~~~csharp
public static void SortAngle <T> ([NotNull] this Transform position, [NotNull] Transform forward, [NotNull] T[] targets, KaijuAngleSortMode mode = KaijuAngleSortMode.Magnitude, bool? farthest = null) where T : Component
~~~

Sort from the position.

~~~csharp
public static void SortAngle <T> ([NotNull] this Transform position, [NotNull] Transform forward, [NotNull] List<T> targets, KaijuAngleSortMode mode = KaijuAngleSortMode.Magnitude, bool? farthest = null) where T : Component
~~~

Sort from the position.

~~~csharp
public static T[] SortAngle <T> ([NotNull] this Transform position, [NotNull] Transform forward, [NotNull] IEnumerable<T> targets, KaijuAngleSortMode mode = KaijuAngleSortMode.Magnitude, bool? farthest = null) where T : Component
~~~

Sort from the position.

~~~csharp
public static void SortAngle ([NotNull] this Transform position, [NotNull] Transform forward, [NotNull] GameObject[] targets, KaijuAngleSortMode mode = KaijuAngleSortMode.Magnitude, bool? farthest = null)
~~~

Sort from the position.

~~~csharp
public static void SortAngle ([NotNull] this Transform position, [NotNull] Transform forward, [NotNull] List<GameObject> targets, KaijuAngleSortMode mode = KaijuAngleSortMode.Magnitude, bool? farthest = null)
~~~

Sort from the position.

~~~csharp
public static GameObject[] SortAngle ([NotNull] this Transform position, [NotNull] Transform forward, [NotNull] IEnumerable<GameObject> targets, KaijuAngleSortMode mode = KaijuAngleSortMode.Magnitude, bool? farthest = null)
~~~

Sort from the position.

~~~csharp
public static void SortAngle ([NotNull] this Transform position, [NotNull] Component forward, [NotNull] Vector2[] targets, KaijuAngleSortMode mode = KaijuAngleSortMode.Magnitude, bool? farthest = null)
~~~

Sort from the position.

~~~csharp
public static void SortAngle ([NotNull] this Transform position, [NotNull] Component forward, [NotNull] List<Vector2> targets, KaijuAngleSortMode mode = KaijuAngleSortMode.Magnitude, bool? farthest = null)
~~~

Sort from the position.

~~~csharp
public static Vector2[] SortAngle ([NotNull] this Transform position, [NotNull] Component forward, [NotNull] IEnumerable<Vector2> targets, KaijuAngleSortMode mode = KaijuAngleSortMode.Magnitude, bool? farthest = null)
~~~

Sort from the position.

~~~csharp
public static void SortAngle ([NotNull] this Transform position, [NotNull] Component forward, [NotNull] Vector3[] targets, KaijuAngleSortMode mode = KaijuAngleSortMode.Magnitude, bool? farthest = null)
~~~

Sort from the position.

~~~csharp
public static void SortAngle ([NotNull] this Transform position, [NotNull] Component forward, [NotNull] List<Vector3> targets, KaijuAngleSortMode mode = KaijuAngleSortMode.Magnitude, bool? farthest = null)
~~~

Sort from the position.

~~~csharp
public static Vector3[] SortAngle ([NotNull] this Transform position, [NotNull] Component forward, [NotNull] IEnumerable<Vector3> targets, KaijuAngleSortMode mode = KaijuAngleSortMode.Magnitude, bool? farthest = null)
~~~

Sort from the position.

~~~csharp
public static void SortAngle ([NotNull] this Transform position, [NotNull] Component forward, [NotNull] Transform[] targets, KaijuAngleSortMode mode = KaijuAngleSortMode.Magnitude, bool? farthest = null)
~~~

Sort from the position.

~~~csharp
public static void SortAngle ([NotNull] this Transform position, [NotNull] Component forward, [NotNull] List<Transform> targets, KaijuAngleSortMode mode = KaijuAngleSortMode.Magnitude, bool? farthest = null)
~~~

Sort from the position.

~~~csharp
public static Transform[] SortAngle ([NotNull] this Transform position, [NotNull] Component forward, [NotNull] IEnumerable<Transform> targets, KaijuAngleSortMode mode = KaijuAngleSortMode.Magnitude, bool? farthest = null)
~~~

Sort from the position.

~~~csharp
public static void SortAngle <T> ([NotNull] this Transform position, [NotNull] Component forward, [NotNull] T[] targets, KaijuAngleSortMode mode = KaijuAngleSortMode.Magnitude, bool? farthest = null) where T : Component
~~~

Sort from the position.

~~~csharp
public static void SortAngle <T> ([NotNull] this Transform position, [NotNull] Component forward, [NotNull] List<T> targets, KaijuAngleSortMode mode = KaijuAngleSortMode.Magnitude, bool? farthest = null) where T : Component
~~~

Sort from the position.

~~~csharp
public static T[] SortAngle <T> ([NotNull] this Transform position, [NotNull] Component forward, [NotNull] IEnumerable<T> targets, KaijuAngleSortMode mode = KaijuAngleSortMode.Magnitude, bool? farthest = null) where T : Component
~~~

Sort from the position.

~~~csharp
public static void SortAngle ([NotNull] this Transform position, [NotNull] Component forward, [NotNull] GameObject[] targets, KaijuAngleSortMode mode = KaijuAngleSortMode.Magnitude, bool? farthest = null)
~~~

Sort from the position.

~~~csharp
public static void SortAngle ([NotNull] this Transform position, [NotNull] Component forward, [NotNull] List<GameObject> targets, KaijuAngleSortMode mode = KaijuAngleSortMode.Magnitude, bool? farthest = null)
~~~

Sort from the position.

~~~csharp
public static GameObject[] SortAngle ([NotNull] this Transform position, [NotNull] Component forward, [NotNull] IEnumerable<GameObject> targets, KaijuAngleSortMode mode = KaijuAngleSortMode.Magnitude, bool? farthest = null)
~~~

Sort from the position.

~~~csharp
public static void SortAngle ([NotNull] this Transform position, [NotNull] GameObject forward, [NotNull] Vector2[] targets, KaijuAngleSortMode mode = KaijuAngleSortMode.Magnitude, bool? farthest = null)
~~~

Sort from the position.

~~~csharp
public static void SortAngle ([NotNull] this Transform position, [NotNull] GameObject forward, [NotNull] List<Vector2> targets, KaijuAngleSortMode mode = KaijuAngleSortMode.Magnitude, bool? farthest = null)
~~~

Sort from the position.

~~~csharp
public static Vector2[] SortAngle ([NotNull] this Transform position, [NotNull] GameObject forward, [NotNull] IEnumerable<Vector2> targets, KaijuAngleSortMode mode = KaijuAngleSortMode.Magnitude, bool? farthest = null)
~~~

Sort from the position.

~~~csharp
public static void SortAngle ([NotNull] this Transform position, [NotNull] GameObject forward, [NotNull] Vector3[] targets, KaijuAngleSortMode mode = KaijuAngleSortMode.Magnitude, bool? farthest = null)
~~~

Sort from the position.

~~~csharp
public static void SortAngle ([NotNull] this Transform position, [NotNull] GameObject forward, [NotNull] List<Vector3> targets, KaijuAngleSortMode mode = KaijuAngleSortMode.Magnitude, bool? farthest = null)
~~~

Sort from the position.

~~~csharp
public static Vector3[] SortAngle ([NotNull] this Transform position, [NotNull] GameObject forward, [NotNull] IEnumerable<Vector3> targets, KaijuAngleSortMode mode = KaijuAngleSortMode.Magnitude, bool? farthest = null)
~~~

Sort from the position.

~~~csharp
public static void SortAngle ([NotNull] this Transform position, [NotNull] GameObject forward, [NotNull] Transform[] targets, KaijuAngleSortMode mode = KaijuAngleSortMode.Magnitude, bool? farthest = null)
~~~

Sort from the position.

~~~csharp
public static void SortAngle ([NotNull] this Transform position, [NotNull] GameObject forward, [NotNull] List<Transform> targets, KaijuAngleSortMode mode = KaijuAngleSortMode.Magnitude, bool? farthest = null)
~~~

Sort from the position.

~~~csharp
public static Transform[] SortAngle ([NotNull] this Transform position, [NotNull] GameObject forward, [NotNull] IEnumerable<Transform> targets, KaijuAngleSortMode mode = KaijuAngleSortMode.Magnitude, bool? farthest = null)
~~~

Sort from the position.

~~~csharp
public static void SortAngle <T> ([NotNull] this Transform position, [NotNull] GameObject forward, [NotNull] T[] targets, KaijuAngleSortMode mode = KaijuAngleSortMode.Magnitude, bool? farthest = null) where T : Component
~~~

Sort from the position.

~~~csharp
public static void SortAngle <T> ([NotNull] this Transform position, [NotNull] GameObject forward, [NotNull] List<T> targets, KaijuAngleSortMode mode = KaijuAngleSortMode.Magnitude, bool? farthest = null) where T : Component
~~~

Sort from the position.

~~~csharp
public static T[] SortAngle <T> ([NotNull] this Transform position, [NotNull] GameObject forward, [NotNull] IEnumerable<T> targets, KaijuAngleSortMode mode = KaijuAngleSortMode.Magnitude, bool? farthest = null) where T : Component
~~~

Sort from the position.

~~~csharp
public static void SortAngle ([NotNull] this Transform position, [NotNull] GameObject forward, [NotNull] GameObject[] targets, KaijuAngleSortMode mode = KaijuAngleSortMode.Magnitude, bool? farthest = null)
~~~

Sort from the position.

~~~csharp
public static void SortAngle ([NotNull] this Transform position, [NotNull] GameObject forward, [NotNull] List<GameObject> targets, KaijuAngleSortMode mode = KaijuAngleSortMode.Magnitude, bool? farthest = null)
~~~

Sort from the position.

~~~csharp
public static GameObject[] SortAngle ([NotNull] this Transform position, [NotNull] GameObject forward, [NotNull] IEnumerable<GameObject> targets, KaijuAngleSortMode mode = KaijuAngleSortMode.Magnitude, bool? farthest = null)
~~~

Sort from the position.

~~~csharp
public static void SortAngle ([NotNull] this Transform position, [NotNull] Vector2[] targets, KaijuAngleSortMode mode = KaijuAngleSortMode.Magnitude, bool? farthest = null)
~~~

Sort from the position.

~~~csharp
public static void SortAngle ([NotNull] this Transform position, [NotNull] List<Vector2> targets, KaijuAngleSortMode mode = KaijuAngleSortMode.Magnitude, bool? farthest = null)
~~~

Sort from the position.

~~~csharp
public static Vector2[] SortAngle ([NotNull] this Transform position, [NotNull] IEnumerable<Vector2> targets, KaijuAngleSortMode mode = KaijuAngleSortMode.Magnitude, bool? farthest = null)
~~~

Sort from the position.

~~~csharp
public static void SortAngle ([NotNull] this Transform position, [NotNull] Vector3[] targets, KaijuAngleSortMode mode = KaijuAngleSortMode.Magnitude, bool? farthest = null)
~~~

Sort from the position.

~~~csharp
public static void SortAngle ([NotNull] this Transform position, [NotNull] List<Vector3> targets, KaijuAngleSortMode mode = KaijuAngleSortMode.Magnitude, bool? farthest = null)
~~~

Sort from the position.

~~~csharp
public static Vector3[] SortAngle ([NotNull] this Transform position, [NotNull] IEnumerable<Vector3> targets, KaijuAngleSortMode mode = KaijuAngleSortMode.Magnitude, bool? farthest = null)
~~~

Sort from the position.

~~~csharp
public static void SortAngle ([NotNull] this Transform position, [NotNull] Transform[] targets, KaijuAngleSortMode mode = KaijuAngleSortMode.Magnitude, bool? farthest = null)
~~~

Sort from the position.

~~~csharp
public static void SortAngle ([NotNull] this Transform position, [NotNull] List<Transform> targets, KaijuAngleSortMode mode = KaijuAngleSortMode.Magnitude, bool? farthest = null)
~~~

Sort from the position.

~~~csharp
public static Transform[] SortAngle ([NotNull] this Transform position, [NotNull] IEnumerable<Transform> targets, KaijuAngleSortMode mode = KaijuAngleSortMode.Magnitude, bool? farthest = null)
~~~

Sort from the position.

~~~csharp
public static void SortAngle <T> ([NotNull] this Transform position, [NotNull] T[] targets, KaijuAngleSortMode mode = KaijuAngleSortMode.Magnitude, bool? farthest = null) where T : Component
~~~

Sort from the position.

~~~csharp
public static void SortAngle <T> ([NotNull] this Transform position, [NotNull] List<T> targets, KaijuAngleSortMode mode = KaijuAngleSortMode.Magnitude, bool? farthest = null) where T : Component
~~~

Sort from the position.

~~~csharp
public static T[] SortAngle <T> ([NotNull] this Transform position, [NotNull] IEnumerable<T> targets, KaijuAngleSortMode mode = KaijuAngleSortMode.Magnitude, bool? farthest = null) where T : Component
~~~

Sort from the position.

~~~csharp
public static void SortAngle ([NotNull] this Transform position, [NotNull] GameObject[] targets, KaijuAngleSortMode mode = KaijuAngleSortMode.Magnitude, bool? farthest = null)
~~~

Sort from the position.

~~~csharp
public static void SortAngle ([NotNull] this Transform position, [NotNull] List<GameObject> targets, KaijuAngleSortMode mode = KaijuAngleSortMode.Magnitude, bool? farthest = null)
~~~

Sort from the position.

~~~csharp
public static GameObject[] SortAngle ([NotNull] this Transform position, [NotNull] IEnumerable<GameObject> targets, KaijuAngleSortMode mode = KaijuAngleSortMode.Magnitude, bool? farthest = null)
~~~

Sort from the position.

~~~csharp
public static void SortAngle ([NotNull] this Component position, Vector2 forward, [NotNull] Vector2[] targets, KaijuAngleSortMode mode = KaijuAngleSortMode.Magnitude, bool? farthest = null)
~~~

Sort from the position.

~~~csharp
public static void SortAngle ([NotNull] this Component position, Vector2 forward, [NotNull] List<Vector2> targets, KaijuAngleSortMode mode = KaijuAngleSortMode.Magnitude, bool? farthest = null)
~~~

Sort from the position.

~~~csharp
public static Vector2[] SortAngle ([NotNull] this Component position, Vector2 forward, [NotNull] IEnumerable<Vector2> targets, KaijuAngleSortMode mode = KaijuAngleSortMode.Magnitude, bool? farthest = null)
~~~

Sort from the position.

~~~csharp
public static void SortAngle ([NotNull] this Component position, Vector2 forward, [NotNull] Vector3[] targets, KaijuAngleSortMode mode = KaijuAngleSortMode.Magnitude, bool? farthest = null)
~~~

Sort from the position.

~~~csharp
public static void SortAngle ([NotNull] this Component position, Vector2 forward, [NotNull] List<Vector3> targets, KaijuAngleSortMode mode = KaijuAngleSortMode.Magnitude, bool? farthest = null)
~~~

Sort from the position.

~~~csharp
public static Vector3[] SortAngle ([NotNull] this Component position, Vector2 forward, [NotNull] IEnumerable<Vector3> targets, KaijuAngleSortMode mode = KaijuAngleSortMode.Magnitude, bool? farthest = null)
~~~

Sort from the position.

~~~csharp
public static void SortAngle ([NotNull] this Component position, Vector2 forward, [NotNull] Transform[] targets, KaijuAngleSortMode mode = KaijuAngleSortMode.Magnitude, bool? farthest = null)
~~~

Sort from the position.

~~~csharp
public static void SortAngle ([NotNull] this Component position, Vector2 forward, [NotNull] List<Transform> targets, KaijuAngleSortMode mode = KaijuAngleSortMode.Magnitude, bool? farthest = null)
~~~

Sort from the position.

~~~csharp
public static Transform[] SortAngle ([NotNull] this Component position, Vector2 forward, [NotNull] IEnumerable<Transform> targets, KaijuAngleSortMode mode = KaijuAngleSortMode.Magnitude, bool? farthest = null)
~~~

Sort from the position.

~~~csharp
public static void SortAngle <T> ([NotNull] this Component position, Vector2 forward, [NotNull] T[] targets, KaijuAngleSortMode mode = KaijuAngleSortMode.Magnitude, bool? farthest = null) where T : Component
~~~

Sort from the position.

~~~csharp
public static void SortAngle <T> ([NotNull] this Component position, Vector2 forward, [NotNull] List<T> targets, KaijuAngleSortMode mode = KaijuAngleSortMode.Magnitude, bool? farthest = null) where T : Component
~~~

Sort from the position.

~~~csharp
public static T[] SortAngle <T> ([NotNull] this Component position, Vector2 forward, [NotNull] IEnumerable<T> targets, KaijuAngleSortMode mode = KaijuAngleSortMode.Magnitude, bool? farthest = null) where T : Component
~~~

Sort from the position.

~~~csharp
public static void SortAngle ([NotNull] this Component position, Vector2 forward, [NotNull] GameObject[] targets, KaijuAngleSortMode mode = KaijuAngleSortMode.Magnitude, bool? farthest = null)
~~~

Sort from the position.

~~~csharp
public static void SortAngle ([NotNull] this Component position, Vector2 forward, [NotNull] List<GameObject> targets, KaijuAngleSortMode mode = KaijuAngleSortMode.Magnitude, bool? farthest = null)
~~~

Sort from the position.

~~~csharp
public static GameObject[] SortAngle ([NotNull] this Component position, Vector2 forward, [NotNull] IEnumerable<GameObject> targets, KaijuAngleSortMode mode = KaijuAngleSortMode.Magnitude, bool? farthest = null)
~~~

Sort from the position.

~~~csharp
public static void SortAngle ([NotNull] this Component position, Vector3 forward, [NotNull] Vector2[] targets, KaijuAngleSortMode mode = KaijuAngleSortMode.Magnitude, bool? farthest = null)
~~~

Sort from the position.

~~~csharp
public static void SortAngle ([NotNull] this Component position, Vector3 forward, [NotNull] List<Vector2> targets, KaijuAngleSortMode mode = KaijuAngleSortMode.Magnitude, bool? farthest = null)
~~~

Sort from the position.

~~~csharp
public static Vector2[] SortAngle ([NotNull] this Component position, Vector3 forward, [NotNull] IEnumerable<Vector2> targets, KaijuAngleSortMode mode = KaijuAngleSortMode.Magnitude, bool? farthest = null)
~~~

Sort from the position.

~~~csharp
public static void SortAngle ([NotNull] this Component position, Vector3 forward, [NotNull] Vector3[] targets, KaijuAngleSortMode mode = KaijuAngleSortMode.Magnitude, bool? farthest = null)
~~~

Sort from the position.

~~~csharp
public static void SortAngle ([NotNull] this Component position, Vector3 forward, [NotNull] List<Vector3> targets, KaijuAngleSortMode mode = KaijuAngleSortMode.Magnitude, bool? farthest = null)
~~~

Sort from the position.

~~~csharp
public static Vector3[] SortAngle ([NotNull] this Component position, Vector3 forward, [NotNull] IEnumerable<Vector3> targets, KaijuAngleSortMode mode = KaijuAngleSortMode.Magnitude, bool? farthest = null)
~~~

Sort from the position.

~~~csharp
public static void SortAngle ([NotNull] this Component position, Vector3 forward, [NotNull] Transform[] targets, KaijuAngleSortMode mode = KaijuAngleSortMode.Magnitude, bool? farthest = null)
~~~

Sort from the position.

~~~csharp
public static void SortAngle ([NotNull] this Component position, Vector3 forward, [NotNull] List<Transform> targets, KaijuAngleSortMode mode = KaijuAngleSortMode.Magnitude, bool? farthest = null)
~~~

Sort from the position.

~~~csharp
public static Transform[] SortAngle ([NotNull] this Component position, Vector3 forward, [NotNull] IEnumerable<Transform> targets, KaijuAngleSortMode mode = KaijuAngleSortMode.Magnitude, bool? farthest = null)
~~~

Sort from the position.

~~~csharp
public static void SortAngle <T> ([NotNull] this Component position, Vector3 forward, [NotNull] T[] targets, KaijuAngleSortMode mode = KaijuAngleSortMode.Magnitude, bool? farthest = null) where T : Component
~~~

Sort from the position.

~~~csharp
public static void SortAngle <T> ([NotNull] this Component position, Vector3 forward, [NotNull] List<T> targets, KaijuAngleSortMode mode = KaijuAngleSortMode.Magnitude, bool? farthest = null) where T : Component
~~~

Sort from the position.

~~~csharp
public static T[] SortAngle <T> ([NotNull] this Component position, Vector3 forward, [NotNull] IEnumerable<T> targets, KaijuAngleSortMode mode = KaijuAngleSortMode.Magnitude, bool? farthest = null) where T : Component
~~~

Sort from the position.

~~~csharp
public static void SortAngle ([NotNull] this Component position, Vector3 forward, [NotNull] GameObject[] targets, KaijuAngleSortMode mode = KaijuAngleSortMode.Magnitude, bool? farthest = null)
~~~

Sort from the position.

~~~csharp
public static void SortAngle ([NotNull] this Component position, Vector3 forward, [NotNull] List<GameObject> targets, KaijuAngleSortMode mode = KaijuAngleSortMode.Magnitude, bool? farthest = null)
~~~

Sort from the position.

~~~csharp
public static GameObject[] SortAngle ([NotNull] this Component position, Vector3 forward, [NotNull] IEnumerable<GameObject> targets, KaijuAngleSortMode mode = KaijuAngleSortMode.Magnitude, bool? farthest = null)
~~~

Sort from the position.

~~~csharp
public static void SortAngle ([NotNull] this Component position, [NotNull] Transform forward, [NotNull] Vector2[] targets, KaijuAngleSortMode mode = KaijuAngleSortMode.Magnitude, bool? farthest = null)
~~~

Sort from the position.

~~~csharp
public static void SortAngle ([NotNull] this Component position, [NotNull] Transform forward, [NotNull] List<Vector2> targets, KaijuAngleSortMode mode = KaijuAngleSortMode.Magnitude, bool? farthest = null)
~~~

Sort from the position.

~~~csharp
public static Vector2[] SortAngle ([NotNull] this Component position, [NotNull] Transform forward, [NotNull] IEnumerable<Vector2> targets, KaijuAngleSortMode mode = KaijuAngleSortMode.Magnitude, bool? farthest = null)
~~~

Sort from the position.

~~~csharp
public static void SortAngle ([NotNull] this Component position, [NotNull] Transform forward, [NotNull] Vector3[] targets, KaijuAngleSortMode mode = KaijuAngleSortMode.Magnitude, bool? farthest = null)
~~~

Sort from the position.

~~~csharp
public static void SortAngle ([NotNull] this Component position, [NotNull] Transform forward, [NotNull] List<Vector3> targets, KaijuAngleSortMode mode = KaijuAngleSortMode.Magnitude, bool? farthest = null)
~~~

Sort from the position.

~~~csharp
public static Vector3[] SortAngle ([NotNull] this Component position, [NotNull] Transform forward, [NotNull] IEnumerable<Vector3> targets, KaijuAngleSortMode mode = KaijuAngleSortMode.Magnitude, bool? farthest = null)
~~~

Sort from the position.

~~~csharp
public static void SortAngle ([NotNull] this Component position, [NotNull] Transform forward, [NotNull] Transform[] targets, KaijuAngleSortMode mode = KaijuAngleSortMode.Magnitude, bool? farthest = null)
~~~

Sort from the position.

~~~csharp
public static void SortAngle ([NotNull] this Component position, [NotNull] Transform forward, [NotNull] List<Transform> targets, KaijuAngleSortMode mode = KaijuAngleSortMode.Magnitude, bool? farthest = null)
~~~

Sort from the position.

~~~csharp
public static Transform[] SortAngle ([NotNull] this Component position, [NotNull] Transform forward, [NotNull] IEnumerable<Transform> targets, KaijuAngleSortMode mode = KaijuAngleSortMode.Magnitude, bool? farthest = null)
~~~

Sort from the position.

~~~csharp
public static void SortAngle <T> ([NotNull] this Component position, [NotNull] Transform forward, [NotNull] T[] targets, KaijuAngleSortMode mode = KaijuAngleSortMode.Magnitude, bool? farthest = null) where T : Component
~~~

Sort from the position.

~~~csharp
public static void SortAngle <T> ([NotNull] this Component position, [NotNull] Transform forward, [NotNull] List<T> targets, KaijuAngleSortMode mode = KaijuAngleSortMode.Magnitude, bool? farthest = null) where T : Component
~~~

Sort from the position.

~~~csharp
public static T[] SortAngle <T> ([NotNull] this Component position, [NotNull] Transform forward, [NotNull] IEnumerable<T> targets, KaijuAngleSortMode mode = KaijuAngleSortMode.Magnitude, bool? farthest = null) where T : Component
~~~

Sort from the position.

~~~csharp
public static void SortAngle ([NotNull] this Component position, [NotNull] Transform forward, [NotNull] GameObject[] targets, KaijuAngleSortMode mode = KaijuAngleSortMode.Magnitude, bool? farthest = null)
~~~

Sort from the position.

~~~csharp
public static void SortAngle ([NotNull] this Component position, [NotNull] Transform forward, [NotNull] List<GameObject> targets, KaijuAngleSortMode mode = KaijuAngleSortMode.Magnitude, bool? farthest = null)
~~~

Sort from the position.

~~~csharp
public static GameObject[] SortAngle ([NotNull] this Component position, [NotNull] Transform forward, [NotNull] IEnumerable<GameObject> targets, KaijuAngleSortMode mode = KaijuAngleSortMode.Magnitude, bool? farthest = null)
~~~

Sort from the position.

~~~csharp
public static void SortAngle ([NotNull] this Component position, [NotNull] Component forward, [NotNull] Vector2[] targets, KaijuAngleSortMode mode = KaijuAngleSortMode.Magnitude, bool? farthest = null)
~~~

Sort from the position.

~~~csharp
public static void SortAngle ([NotNull] this Component position, [NotNull] Component forward, [NotNull] List<Vector2> targets, KaijuAngleSortMode mode = KaijuAngleSortMode.Magnitude, bool? farthest = null)
~~~

Sort from the position.

~~~csharp
public static Vector2[] SortAngle ([NotNull] this Component position, [NotNull] Component forward, [NotNull] IEnumerable<Vector2> targets, KaijuAngleSortMode mode = KaijuAngleSortMode.Magnitude, bool? farthest = null)
~~~

Sort from the position.

~~~csharp
public static void SortAngle ([NotNull] this Component position, [NotNull] Component forward, [NotNull] Vector3[] targets, KaijuAngleSortMode mode = KaijuAngleSortMode.Magnitude, bool? farthest = null)
~~~

Sort from the position.

~~~csharp
public static void SortAngle ([NotNull] this Component position, [NotNull] Component forward, [NotNull] List<Vector3> targets, KaijuAngleSortMode mode = KaijuAngleSortMode.Magnitude, bool? farthest = null)
~~~

Sort from the position.

~~~csharp
public static Vector3[] SortAngle ([NotNull] this Component position, [NotNull] Component forward, [NotNull] IEnumerable<Vector3> targets, KaijuAngleSortMode mode = KaijuAngleSortMode.Magnitude, bool? farthest = null)
~~~

Sort from the position.

~~~csharp
public static void SortAngle ([NotNull] this Component position, [NotNull] Component forward, [NotNull] Transform[] targets, KaijuAngleSortMode mode = KaijuAngleSortMode.Magnitude, bool? farthest = null)
~~~

Sort from the position.

~~~csharp
public static void SortAngle ([NotNull] this Component position, [NotNull] Component forward, [NotNull] List<Transform> targets, KaijuAngleSortMode mode = KaijuAngleSortMode.Magnitude, bool? farthest = null)
~~~

Sort from the position.

~~~csharp
public static Transform[] SortAngle ([NotNull] this Component position, [NotNull] Component forward, [NotNull] IEnumerable<Transform> targets, KaijuAngleSortMode mode = KaijuAngleSortMode.Magnitude, bool? farthest = null)
~~~

Sort from the position.

~~~csharp
public static void SortAngle <T> ([NotNull] this Component position, [NotNull] Component forward, [NotNull] T[] targets, KaijuAngleSortMode mode = KaijuAngleSortMode.Magnitude, bool? farthest = null) where T : Component
~~~

Sort from the position.

~~~csharp
public static void SortAngle <T> ([NotNull] this Component position, [NotNull] Component forward, [NotNull] List<T> targets, KaijuAngleSortMode mode = KaijuAngleSortMode.Magnitude, bool? farthest = null) where T : Component
~~~

Sort from the position.

~~~csharp
public static T[] SortAngle <T> ([NotNull] this Component position, [NotNull] Component forward, [NotNull] IEnumerable<T> targets, KaijuAngleSortMode mode = KaijuAngleSortMode.Magnitude, bool? farthest = null) where T : Component
~~~

Sort from the position.

~~~csharp
public static void SortAngle ([NotNull] this Component position, [NotNull] Component forward, [NotNull] GameObject[] targets, KaijuAngleSortMode mode = KaijuAngleSortMode.Magnitude, bool? farthest = null)
~~~

Sort from the position.

~~~csharp
public static void SortAngle ([NotNull] this Component position, [NotNull] Component forward, [NotNull] List<GameObject> targets, KaijuAngleSortMode mode = KaijuAngleSortMode.Magnitude, bool? farthest = null)
~~~

Sort from the position.

~~~csharp
public static GameObject[] SortAngle ([NotNull] this Component position, [NotNull] Component forward, [NotNull] IEnumerable<GameObject> targets, KaijuAngleSortMode mode = KaijuAngleSortMode.Magnitude, bool? farthest = null)
~~~

Sort from the position.

~~~csharp
public static void SortAngle ([NotNull] this Component position, [NotNull] GameObject forward, [NotNull] Vector2[] targets, KaijuAngleSortMode mode = KaijuAngleSortMode.Magnitude, bool? farthest = null)
~~~

Sort from the position.

~~~csharp
public static void SortAngle ([NotNull] this Component position, [NotNull] GameObject forward, [NotNull] List<Vector2> targets, KaijuAngleSortMode mode = KaijuAngleSortMode.Magnitude, bool? farthest = null)
~~~

Sort from the position.

~~~csharp
public static Vector2[] SortAngle ([NotNull] this Component position, [NotNull] GameObject forward, [NotNull] IEnumerable<Vector2> targets, KaijuAngleSortMode mode = KaijuAngleSortMode.Magnitude, bool? farthest = null)
~~~

Sort from the position.

~~~csharp
public static void SortAngle ([NotNull] this Component position, [NotNull] GameObject forward, [NotNull] Vector3[] targets, KaijuAngleSortMode mode = KaijuAngleSortMode.Magnitude, bool? farthest = null)
~~~

Sort from the position.

~~~csharp
public static void SortAngle ([NotNull] this Component position, [NotNull] GameObject forward, [NotNull] List<Vector3> targets, KaijuAngleSortMode mode = KaijuAngleSortMode.Magnitude, bool? farthest = null)
~~~

Sort from the position.

~~~csharp
public static Vector3[] SortAngle ([NotNull] this Component position, [NotNull] GameObject forward, [NotNull] IEnumerable<Vector3> targets, KaijuAngleSortMode mode = KaijuAngleSortMode.Magnitude, bool? farthest = null)
~~~

Sort from the position.

~~~csharp
public static void SortAngle ([NotNull] this Component position, [NotNull] GameObject forward, [NotNull] Transform[] targets, KaijuAngleSortMode mode = KaijuAngleSortMode.Magnitude, bool? farthest = null)
~~~

Sort from the position.

~~~csharp
public static void SortAngle ([NotNull] this Component position, [NotNull] GameObject forward, [NotNull] List<Transform> targets, KaijuAngleSortMode mode = KaijuAngleSortMode.Magnitude, bool? farthest = null)
~~~

Sort from the position.

~~~csharp
public static Transform[] SortAngle ([NotNull] this Component position, [NotNull] GameObject forward, [NotNull] IEnumerable<Transform> targets, KaijuAngleSortMode mode = KaijuAngleSortMode.Magnitude, bool? farthest = null)
~~~

Sort from the position.

~~~csharp
public static void SortAngle <T> ([NotNull] this Component position, [NotNull] GameObject forward, [NotNull] T[] targets, KaijuAngleSortMode mode = KaijuAngleSortMode.Magnitude, bool? farthest = null) where T : Component
~~~

Sort from the position.

~~~csharp
public static void SortAngle <T> ([NotNull] this Component position, [NotNull] GameObject forward, [NotNull] List<T> targets, KaijuAngleSortMode mode = KaijuAngleSortMode.Magnitude, bool? farthest = null) where T : Component
~~~

Sort from the position.

~~~csharp
public static T[] SortAngle <T> ([NotNull] this Component position, [NotNull] GameObject forward, [NotNull] IEnumerable<T> targets, KaijuAngleSortMode mode = KaijuAngleSortMode.Magnitude, bool? farthest = null) where T : Component
~~~

Sort from the position.

~~~csharp
public static void SortAngle ([NotNull] this Component position, [NotNull] GameObject forward, [NotNull] GameObject[] targets, KaijuAngleSortMode mode = KaijuAngleSortMode.Magnitude, bool? farthest = null)
~~~

Sort from the position.

~~~csharp
public static void SortAngle ([NotNull] this Component position, [NotNull] GameObject forward, [NotNull] List<GameObject> targets, KaijuAngleSortMode mode = KaijuAngleSortMode.Magnitude, bool? farthest = null)
~~~

Sort from the position.

~~~csharp
public static GameObject[] SortAngle ([NotNull] this Component position, [NotNull] GameObject forward, [NotNull] IEnumerable<GameObject> targets, KaijuAngleSortMode mode = KaijuAngleSortMode.Magnitude, bool? farthest = null)
~~~

Sort from the position.

~~~csharp
public static void SortAngle ([NotNull] this Component position, [NotNull] Vector2[] targets, KaijuAngleSortMode mode = KaijuAngleSortMode.Magnitude, bool? farthest = null)
~~~

Sort from the position.

~~~csharp
public static void SortAngle ([NotNull] this Component position, [NotNull] List<Vector2> targets, KaijuAngleSortMode mode = KaijuAngleSortMode.Magnitude, bool? farthest = null)
~~~

Sort from the position.

~~~csharp
public static Vector2[] SortAngle ([NotNull] this Component position, [NotNull] IEnumerable<Vector2> targets, KaijuAngleSortMode mode = KaijuAngleSortMode.Magnitude, bool? farthest = null)
~~~

Sort from the position.

~~~csharp
public static void SortAngle ([NotNull] this Component position, [NotNull] Vector3[] targets, KaijuAngleSortMode mode = KaijuAngleSortMode.Magnitude, bool? farthest = null)
~~~

Sort from the position.

~~~csharp
public static void SortAngle ([NotNull] this Component position, [NotNull] List<Vector3> targets, KaijuAngleSortMode mode = KaijuAngleSortMode.Magnitude, bool? farthest = null)
~~~

Sort from the position.

~~~csharp
public static Vector3[] SortAngle ([NotNull] this Component position, [NotNull] IEnumerable<Vector3> targets, KaijuAngleSortMode mode = KaijuAngleSortMode.Magnitude, bool? farthest = null)
~~~

Sort from the position.

~~~csharp
public static void SortAngle ([NotNull] this Component position, [NotNull] Transform[] targets, KaijuAngleSortMode mode = KaijuAngleSortMode.Magnitude, bool? farthest = null)
~~~

Sort from the position.

~~~csharp
public static void SortAngle ([NotNull] this Component position, [NotNull] List<Transform> targets, KaijuAngleSortMode mode = KaijuAngleSortMode.Magnitude, bool? farthest = null)
~~~

Sort from the position.

~~~csharp
public static Transform[] SortAngle ([NotNull] this Component position, [NotNull] IEnumerable<Transform> targets, KaijuAngleSortMode mode = KaijuAngleSortMode.Magnitude, bool? farthest = null)
~~~

Sort from the position.

~~~csharp
public static void SortAngle <T> ([NotNull] this Component position, [NotNull] T[] targets, KaijuAngleSortMode mode = KaijuAngleSortMode.Magnitude, bool? farthest = null) where T : Component
~~~

Sort from the position.

~~~csharp
public static void SortAngle <T> ([NotNull] this Component position, [NotNull] List<T> targets, KaijuAngleSortMode mode = KaijuAngleSortMode.Magnitude, bool? farthest = null) where T : Component
~~~

Sort from the position.

~~~csharp
public static T[] SortAngle <T> ([NotNull] this Component position, [NotNull] IEnumerable<T> targets, KaijuAngleSortMode mode = KaijuAngleSortMode.Magnitude, bool? farthest = null) where T : Component
~~~

Sort from the position.

~~~csharp
public static void SortAngle ([NotNull] this Component position, [NotNull] GameObject[] targets, KaijuAngleSortMode mode = KaijuAngleSortMode.Magnitude, bool? farthest = null)
~~~

Sort from the position.

~~~csharp
public static void SortAngle ([NotNull] this Component position, [NotNull] List<GameObject> targets, KaijuAngleSortMode mode = KaijuAngleSortMode.Magnitude, bool? farthest = null)
~~~

Sort from the position.

~~~csharp
public static GameObject[] SortAngle ([NotNull] this Component position, [NotNull] IEnumerable<GameObject> targets, KaijuAngleSortMode mode = KaijuAngleSortMode.Magnitude, bool? farthest = null)
~~~

Sort from the position.

~~~csharp
public static void SortAngle ([NotNull] this GameObject position, Vector2 forward, [NotNull] Vector2[] targets, KaijuAngleSortMode mode = KaijuAngleSortMode.Magnitude, bool? farthest = null)
~~~

Sort from the position.

~~~csharp
public static void SortAngle ([NotNull] this GameObject position, Vector2 forward, [NotNull] List<Vector2> targets, KaijuAngleSortMode mode = KaijuAngleSortMode.Magnitude, bool? farthest = null)
~~~

Sort from the position.

~~~csharp
public static Vector2[] SortAngle ([NotNull] this GameObject position, Vector2 forward, [NotNull] IEnumerable<Vector2> targets, KaijuAngleSortMode mode = KaijuAngleSortMode.Magnitude, bool? farthest = null)
~~~

Sort from the position.

~~~csharp
public static void SortAngle ([NotNull] this GameObject position, Vector2 forward, [NotNull] Vector3[] targets, KaijuAngleSortMode mode = KaijuAngleSortMode.Magnitude, bool? farthest = null)
~~~

Sort from the position.

~~~csharp
public static void SortAngle ([NotNull] this GameObject position, Vector2 forward, [NotNull] List<Vector3> targets, KaijuAngleSortMode mode = KaijuAngleSortMode.Magnitude, bool? farthest = null)
~~~

Sort from the position.

~~~csharp
public static Vector3[] SortAngle ([NotNull] this GameObject position, Vector2 forward, [NotNull] IEnumerable<Vector3> targets, KaijuAngleSortMode mode = KaijuAngleSortMode.Magnitude, bool? farthest = null)
~~~

Sort from the position.

~~~csharp
public static void SortAngle ([NotNull] this GameObject position, Vector2 forward, [NotNull] Transform[] targets, KaijuAngleSortMode mode = KaijuAngleSortMode.Magnitude, bool? farthest = null)
~~~

Sort from the position.

~~~csharp
public static void SortAngle ([NotNull] this GameObject position, Vector2 forward, [NotNull] List<Transform> targets, KaijuAngleSortMode mode = KaijuAngleSortMode.Magnitude, bool? farthest = null)
~~~

Sort from the position.

~~~csharp
public static Transform[] SortAngle ([NotNull] this GameObject position, Vector2 forward, [NotNull] IEnumerable<Transform> targets, KaijuAngleSortMode mode = KaijuAngleSortMode.Magnitude, bool? farthest = null)
~~~

Sort from the position.

~~~csharp
public static void SortAngle <T> ([NotNull] this GameObject position, Vector2 forward, [NotNull] T[] targets, KaijuAngleSortMode mode = KaijuAngleSortMode.Magnitude, bool? farthest = null) where T : Component
~~~

Sort from the position.

~~~csharp
public static void SortAngle <T> ([NotNull] this GameObject position, Vector2 forward, [NotNull] List<T> targets, KaijuAngleSortMode mode = KaijuAngleSortMode.Magnitude, bool? farthest = null) where T : Component
~~~

Sort from the position.

~~~csharp
public static T[] SortAngle <T> ([NotNull] this GameObject position, Vector2 forward, [NotNull] IEnumerable<T> targets, KaijuAngleSortMode mode = KaijuAngleSortMode.Magnitude, bool? farthest = null) where T : Component
~~~

Sort from the position.

~~~csharp
public static void SortAngle ([NotNull] this GameObject position, Vector2 forward, [NotNull] GameObject[] targets, KaijuAngleSortMode mode = KaijuAngleSortMode.Magnitude, bool? farthest = null)
~~~

Sort from the position.

~~~csharp
public static void SortAngle ([NotNull] this GameObject position, Vector2 forward, [NotNull] List<GameObject> targets, KaijuAngleSortMode mode = KaijuAngleSortMode.Magnitude, bool? farthest = null)
~~~

Sort from the position.

~~~csharp
public static GameObject[] SortAngle ([NotNull] this GameObject position, Vector2 forward, [NotNull] IEnumerable<GameObject> targets, KaijuAngleSortMode mode = KaijuAngleSortMode.Magnitude, bool? farthest = null)
~~~

Sort from the position.

~~~csharp
public static void SortAngle ([NotNull] this GameObject position, Vector3 forward, [NotNull] Vector2[] targets, KaijuAngleSortMode mode = KaijuAngleSortMode.Magnitude, bool? farthest = null)
~~~

Sort from the position.

~~~csharp
public static void SortAngle ([NotNull] this GameObject position, Vector3 forward, [NotNull] List<Vector2> targets, KaijuAngleSortMode mode = KaijuAngleSortMode.Magnitude, bool? farthest = null)
~~~

Sort from the position.

~~~csharp
public static Vector2[] SortAngle ([NotNull] this GameObject position, Vector3 forward, [NotNull] IEnumerable<Vector2> targets, KaijuAngleSortMode mode = KaijuAngleSortMode.Magnitude, bool? farthest = null)
~~~

Sort from the position.

~~~csharp
public static void SortAngle ([NotNull] this GameObject position, Vector3 forward, [NotNull] Vector3[] targets, KaijuAngleSortMode mode = KaijuAngleSortMode.Magnitude, bool? farthest = null)
~~~

Sort from the position.

~~~csharp
public static void SortAngle ([NotNull] this GameObject position, Vector3 forward, [NotNull] List<Vector3> targets, KaijuAngleSortMode mode = KaijuAngleSortMode.Magnitude, bool? farthest = null)
~~~

Sort from the position.

~~~csharp
public static Vector3[] SortAngle ([NotNull] this GameObject position, Vector3 forward, [NotNull] IEnumerable<Vector3> targets, KaijuAngleSortMode mode = KaijuAngleSortMode.Magnitude, bool? farthest = null)
~~~

Sort from the position.

~~~csharp
public static void SortAngle ([NotNull] this GameObject position, Vector3 forward, [NotNull] Transform[] targets, KaijuAngleSortMode mode = KaijuAngleSortMode.Magnitude, bool? farthest = null)
~~~

Sort from the position.

~~~csharp
public static void SortAngle ([NotNull] this GameObject position, Vector3 forward, [NotNull] List<Transform> targets, KaijuAngleSortMode mode = KaijuAngleSortMode.Magnitude, bool? farthest = null)
~~~

Sort from the position.

~~~csharp
public static Transform[] SortAngle ([NotNull] this GameObject position, Vector3 forward, [NotNull] IEnumerable<Transform> targets, KaijuAngleSortMode mode = KaijuAngleSortMode.Magnitude, bool? farthest = null)
~~~

Sort from the position.

~~~csharp
public static void SortAngle <T> ([NotNull] this GameObject position, Vector3 forward, [NotNull] T[] targets, KaijuAngleSortMode mode = KaijuAngleSortMode.Magnitude, bool? farthest = null) where T : Component
~~~

Sort from the position.

~~~csharp
public static void SortAngle <T> ([NotNull] this GameObject position, Vector3 forward, [NotNull] List<T> targets, KaijuAngleSortMode mode = KaijuAngleSortMode.Magnitude, bool? farthest = null) where T : Component
~~~

Sort from the position.

~~~csharp
public static T[] SortAngle <T> ([NotNull] this GameObject position, Vector3 forward, [NotNull] IEnumerable<T> targets, KaijuAngleSortMode mode = KaijuAngleSortMode.Magnitude, bool? farthest = null) where T : Component
~~~

Sort from the position.

~~~csharp
public static void SortAngle ([NotNull] this GameObject position, Vector3 forward, [NotNull] GameObject[] targets, KaijuAngleSortMode mode = KaijuAngleSortMode.Magnitude, bool? farthest = null)
~~~

Sort from the position.

~~~csharp
public static void SortAngle ([NotNull] this GameObject position, Vector3 forward, [NotNull] List<GameObject> targets, KaijuAngleSortMode mode = KaijuAngleSortMode.Magnitude, bool? farthest = null)
~~~

Sort from the position.

~~~csharp
public static GameObject[] SortAngle ([NotNull] this GameObject position, Vector3 forward, [NotNull] IEnumerable<GameObject> targets, KaijuAngleSortMode mode = KaijuAngleSortMode.Magnitude, bool? farthest = null)
~~~

Sort from the position.

~~~csharp
public static void SortAngle ([NotNull] this GameObject position, [NotNull] Transform forward, [NotNull] Vector2[] targets, KaijuAngleSortMode mode = KaijuAngleSortMode.Magnitude, bool? farthest = null)
~~~

Sort from the position.

~~~csharp
public static void SortAngle ([NotNull] this GameObject position, [NotNull] Transform forward, [NotNull] List<Vector2> targets, KaijuAngleSortMode mode = KaijuAngleSortMode.Magnitude, bool? farthest = null)
~~~

Sort from the position.

~~~csharp
public static Vector2[] SortAngle ([NotNull] this GameObject position, [NotNull] Transform forward, [NotNull] IEnumerable<Vector2> targets, KaijuAngleSortMode mode = KaijuAngleSortMode.Magnitude, bool? farthest = null)
~~~

Sort from the position.

~~~csharp
public static void SortAngle ([NotNull] this GameObject position, [NotNull] Transform forward, [NotNull] Vector3[] targets, KaijuAngleSortMode mode = KaijuAngleSortMode.Magnitude, bool? farthest = null)
~~~

Sort from the position.

~~~csharp
public static void SortAngle ([NotNull] this GameObject position, [NotNull] Transform forward, [NotNull] List<Vector3> targets, KaijuAngleSortMode mode = KaijuAngleSortMode.Magnitude, bool? farthest = null)
~~~

Sort from the position.

~~~csharp
public static Vector3[] SortAngle ([NotNull] this GameObject position, [NotNull] Transform forward, [NotNull] IEnumerable<Vector3> targets, KaijuAngleSortMode mode = KaijuAngleSortMode.Magnitude, bool? farthest = null)
~~~

Sort from the position.

~~~csharp
public static void SortAngle ([NotNull] this GameObject position, [NotNull] Transform forward, [NotNull] Transform[] targets, KaijuAngleSortMode mode = KaijuAngleSortMode.Magnitude, bool? farthest = null)
~~~

Sort from the position.

~~~csharp
public static void SortAngle ([NotNull] this GameObject position, [NotNull] Transform forward, [NotNull] List<Transform> targets, KaijuAngleSortMode mode = KaijuAngleSortMode.Magnitude, bool? farthest = null)
~~~

Sort from the position.

~~~csharp
public static Transform[] SortAngle ([NotNull] this GameObject position, [NotNull] Transform forward, [NotNull] IEnumerable<Transform> targets, KaijuAngleSortMode mode = KaijuAngleSortMode.Magnitude, bool? farthest = null)
~~~

Sort from the position.

~~~csharp
public static void SortAngle <T> ([NotNull] this GameObject position, [NotNull] Transform forward, [NotNull] T[] targets, KaijuAngleSortMode mode = KaijuAngleSortMode.Magnitude, bool? farthest = null) where T : Component
~~~

Sort from the position.

~~~csharp
public static void SortAngle <T> ([NotNull] this GameObject position, [NotNull] Transform forward, [NotNull] List<T> targets, KaijuAngleSortMode mode = KaijuAngleSortMode.Magnitude, bool? farthest = null) where T : Component
~~~

Sort from the position.

~~~csharp
public static T[] SortAngle <T> ([NotNull] this GameObject position, [NotNull] Transform forward, [NotNull] IEnumerable<T> targets, KaijuAngleSortMode mode = KaijuAngleSortMode.Magnitude, bool? farthest = null) where T : Component
~~~

Sort from the position.

~~~csharp
public static void SortAngle ([NotNull] this GameObject position, [NotNull] Transform forward, [NotNull] GameObject[] targets, KaijuAngleSortMode mode = KaijuAngleSortMode.Magnitude, bool? farthest = null)
~~~

Sort from the position.

~~~csharp
public static void SortAngle ([NotNull] this GameObject position, [NotNull] Transform forward, [NotNull] List<GameObject> targets, KaijuAngleSortMode mode = KaijuAngleSortMode.Magnitude, bool? farthest = null)
~~~

Sort from the position.

~~~csharp
public static GameObject[] SortAngle ([NotNull] this GameObject position, [NotNull] Transform forward, [NotNull] IEnumerable<GameObject> targets, KaijuAngleSortMode mode = KaijuAngleSortMode.Magnitude, bool? farthest = null)
~~~

Sort from the position.

~~~csharp
public static void SortAngle ([NotNull] this GameObject position, [NotNull] Component forward, [NotNull] Vector2[] targets, KaijuAngleSortMode mode = KaijuAngleSortMode.Magnitude, bool? farthest = null)
~~~

Sort from the position.

~~~csharp
public static void SortAngle ([NotNull] this GameObject position, [NotNull] Component forward, [NotNull] List<Vector2> targets, KaijuAngleSortMode mode = KaijuAngleSortMode.Magnitude, bool? farthest = null)
~~~

Sort from the position.

~~~csharp
public static Vector2[] SortAngle ([NotNull] this GameObject position, [NotNull] Component forward, [NotNull] IEnumerable<Vector2> targets, KaijuAngleSortMode mode = KaijuAngleSortMode.Magnitude, bool? farthest = null)
~~~

Sort from the position.

~~~csharp
public static void SortAngle ([NotNull] this GameObject position, [NotNull] Component forward, [NotNull] Vector3[] targets, KaijuAngleSortMode mode = KaijuAngleSortMode.Magnitude, bool? farthest = null)
~~~

Sort from the position.

~~~csharp
public static void SortAngle ([NotNull] this GameObject position, [NotNull] Component forward, [NotNull] List<Vector3> targets, KaijuAngleSortMode mode = KaijuAngleSortMode.Magnitude, bool? farthest = null)
~~~

Sort from the position.

~~~csharp
public static Vector3[] SortAngle ([NotNull] this GameObject position, [NotNull] Component forward, [NotNull] IEnumerable<Vector3> targets, KaijuAngleSortMode mode = KaijuAngleSortMode.Magnitude, bool? farthest = null)
~~~

Sort from the position.

~~~csharp
public static void SortAngle ([NotNull] this GameObject position, [NotNull] Component forward, [NotNull] Transform[] targets, KaijuAngleSortMode mode = KaijuAngleSortMode.Magnitude, bool? farthest = null)
~~~

Sort from the position.

~~~csharp
public static void SortAngle ([NotNull] this GameObject position, [NotNull] Component forward, [NotNull] List<Transform> targets, KaijuAngleSortMode mode = KaijuAngleSortMode.Magnitude, bool? farthest = null)
~~~

Sort from the position.

~~~csharp
public static Transform[] SortAngle ([NotNull] this GameObject position, [NotNull] Component forward, [NotNull] IEnumerable<Transform> targets, KaijuAngleSortMode mode = KaijuAngleSortMode.Magnitude, bool? farthest = null)
~~~

Sort from the position.

~~~csharp
public static void SortAngle <T> ([NotNull] this GameObject position, [NotNull] Component forward, [NotNull] T[] targets, KaijuAngleSortMode mode = KaijuAngleSortMode.Magnitude, bool? farthest = null) where T : Component
~~~

Sort from the position.

~~~csharp
public static void SortAngle <T> ([NotNull] this GameObject position, [NotNull] Component forward, [NotNull] List<T> targets, KaijuAngleSortMode mode = KaijuAngleSortMode.Magnitude, bool? farthest = null) where T : Component
~~~

Sort from the position.

~~~csharp
public static T[] SortAngle <T> ([NotNull] this GameObject position, [NotNull] Component forward, [NotNull] IEnumerable<T> targets, KaijuAngleSortMode mode = KaijuAngleSortMode.Magnitude, bool? farthest = null) where T : Component
~~~

Sort from the position.

~~~csharp
public static void SortAngle ([NotNull] this GameObject position, [NotNull] Component forward, [NotNull] GameObject[] targets, KaijuAngleSortMode mode = KaijuAngleSortMode.Magnitude, bool? farthest = null)
~~~

Sort from the position.

~~~csharp
public static void SortAngle ([NotNull] this GameObject position, [NotNull] Component forward, [NotNull] List<GameObject> targets, KaijuAngleSortMode mode = KaijuAngleSortMode.Magnitude, bool? farthest = null)
~~~

Sort from the position.

~~~csharp
public static GameObject[] SortAngle ([NotNull] this GameObject position, [NotNull] Component forward, [NotNull] IEnumerable<GameObject> targets, KaijuAngleSortMode mode = KaijuAngleSortMode.Magnitude, bool? farthest = null)
~~~

Sort from the position.

~~~csharp
public static void SortAngle ([NotNull] this GameObject position, [NotNull] GameObject forward, [NotNull] Vector2[] targets, KaijuAngleSortMode mode = KaijuAngleSortMode.Magnitude, bool? farthest = null)
~~~

Sort from the position.

~~~csharp
public static void SortAngle ([NotNull] this GameObject position, [NotNull] GameObject forward, [NotNull] List<Vector2> targets, KaijuAngleSortMode mode = KaijuAngleSortMode.Magnitude, bool? farthest = null)
~~~

Sort from the position.

~~~csharp
public static Vector2[] SortAngle ([NotNull] this GameObject position, [NotNull] GameObject forward, [NotNull] IEnumerable<Vector2> targets, KaijuAngleSortMode mode = KaijuAngleSortMode.Magnitude, bool? farthest = null)
~~~

Sort from the position.

~~~csharp
public static void SortAngle ([NotNull] this GameObject position, [NotNull] GameObject forward, [NotNull] Vector3[] targets, KaijuAngleSortMode mode = KaijuAngleSortMode.Magnitude, bool? farthest = null)
~~~

Sort from the position.

~~~csharp
public static void SortAngle ([NotNull] this GameObject position, [NotNull] GameObject forward, [NotNull] List<Vector3> targets, KaijuAngleSortMode mode = KaijuAngleSortMode.Magnitude, bool? farthest = null)
~~~

Sort from the position.

~~~csharp
public static Vector3[] SortAngle ([NotNull] this GameObject position, [NotNull] GameObject forward, [NotNull] IEnumerable<Vector3> targets, KaijuAngleSortMode mode = KaijuAngleSortMode.Magnitude, bool? farthest = null)
~~~

Sort from the position.

~~~csharp
public static void SortAngle ([NotNull] this GameObject position, [NotNull] GameObject forward, [NotNull] Transform[] targets, KaijuAngleSortMode mode = KaijuAngleSortMode.Magnitude, bool? farthest = null)
~~~

Sort from the position.

~~~csharp
public static void SortAngle ([NotNull] this GameObject position, [NotNull] GameObject forward, [NotNull] List<Transform> targets, KaijuAngleSortMode mode = KaijuAngleSortMode.Magnitude, bool? farthest = null)
~~~

Sort from the position.

~~~csharp
public static Transform[] SortAngle ([NotNull] this GameObject position, [NotNull] GameObject forward, [NotNull] IEnumerable<Transform> targets, KaijuAngleSortMode mode = KaijuAngleSortMode.Magnitude, bool? farthest = null)
~~~

Sort from the position.

~~~csharp
public static void SortAngle <T> ([NotNull] this GameObject position, [NotNull] GameObject forward, [NotNull] T[] targets, KaijuAngleSortMode mode = KaijuAngleSortMode.Magnitude, bool? farthest = null) where T : Component
~~~

Sort from the position.

~~~csharp
public static void SortAngle <T> ([NotNull] this GameObject position, [NotNull] GameObject forward, [NotNull] List<T> targets, KaijuAngleSortMode mode = KaijuAngleSortMode.Magnitude, bool? farthest = null) where T : Component
~~~

Sort from the position.

~~~csharp
public static T[] SortAngle <T> ([NotNull] this GameObject position, [NotNull] GameObject forward, [NotNull] IEnumerable<T> targets, KaijuAngleSortMode mode = KaijuAngleSortMode.Magnitude, bool? farthest = null) where T : Component
~~~

Sort from the position.

~~~csharp
public static void SortAngle ([NotNull] this GameObject position, [NotNull] GameObject forward, [NotNull] GameObject[] targets, KaijuAngleSortMode mode = KaijuAngleSortMode.Magnitude, bool? farthest = null)
~~~

Sort from the position.

~~~csharp
public static void SortAngle ([NotNull] this GameObject position, [NotNull] GameObject forward, [NotNull] List<GameObject> targets, KaijuAngleSortMode mode = KaijuAngleSortMode.Magnitude, bool? farthest = null)
~~~

Sort from the position.

~~~csharp
public static GameObject[] SortAngle ([NotNull] this GameObject position, [NotNull] GameObject forward, [NotNull] IEnumerable<GameObject> targets, KaijuAngleSortMode mode = KaijuAngleSortMode.Magnitude, bool? farthest = null)
~~~

Sort from the position.

~~~csharp
public static void SortAngle ([NotNull] this GameObject position, [NotNull] Vector2[] targets, KaijuAngleSortMode mode = KaijuAngleSortMode.Magnitude, bool? farthest = null)
~~~

Sort from the position.

~~~csharp
public static void SortAngle ([NotNull] this GameObject position, [NotNull] List<Vector2> targets, KaijuAngleSortMode mode = KaijuAngleSortMode.Magnitude, bool? farthest = null)
~~~

Sort from the position.

~~~csharp
public static Vector2[] SortAngle ([NotNull] this GameObject position, [NotNull] IEnumerable<Vector2> targets, KaijuAngleSortMode mode = KaijuAngleSortMode.Magnitude, bool? farthest = null)
~~~

Sort from the position.

~~~csharp
public static void SortAngle ([NotNull] this GameObject position, [NotNull] Vector3[] targets, KaijuAngleSortMode mode = KaijuAngleSortMode.Magnitude, bool? farthest = null)
~~~

Sort from the position.

~~~csharp
public static void SortAngle ([NotNull] this GameObject position, [NotNull] List<Vector3> targets, KaijuAngleSortMode mode = KaijuAngleSortMode.Magnitude, bool? farthest = null)
~~~

Sort from the position.

~~~csharp
public static Vector3[] SortAngle ([NotNull] this GameObject position, [NotNull] IEnumerable<Vector3> targets, KaijuAngleSortMode mode = KaijuAngleSortMode.Magnitude, bool? farthest = null)
~~~

Sort from the position.

~~~csharp
public static void SortAngle ([NotNull] this GameObject position, [NotNull] Transform[] targets, KaijuAngleSortMode mode = KaijuAngleSortMode.Magnitude, bool? farthest = null)
~~~

Sort from the position.

~~~csharp
public static void SortAngle ([NotNull] this GameObject position, [NotNull] List<Transform> targets, KaijuAngleSortMode mode = KaijuAngleSortMode.Magnitude, bool? farthest = null)
~~~

Sort from the position.

~~~csharp
public static Transform[] SortAngle ([NotNull] this GameObject position, [NotNull] IEnumerable<Transform> targets, KaijuAngleSortMode mode = KaijuAngleSortMode.Magnitude, bool? farthest = null)
~~~

Sort from the position.

~~~csharp
public static void SortAngle <T> ([NotNull] this GameObject position, [NotNull] T[] targets, KaijuAngleSortMode mode = KaijuAngleSortMode.Magnitude, bool? farthest = null) where T : Component
~~~

Sort from the position.

~~~csharp
public static void SortAngle <T> ([NotNull] this GameObject position, [NotNull] List<T> targets, KaijuAngleSortMode mode = KaijuAngleSortMode.Magnitude, bool? farthest = null) where T : Component
~~~

Sort from the position.

~~~csharp
public static T[] SortAngle <T> ([NotNull] this GameObject position, [NotNull] IEnumerable<T> targets, KaijuAngleSortMode mode = KaijuAngleSortMode.Magnitude, bool? farthest = null) where T : Component
~~~

Sort from the position.

~~~csharp
public static void SortAngle ([NotNull] this GameObject position, [NotNull] GameObject[] targets, KaijuAngleSortMode mode = KaijuAngleSortMode.Magnitude, bool? farthest = null)
~~~

Sort from the position.

~~~csharp
public static void SortAngle ([NotNull] this GameObject position, [NotNull] List<GameObject> targets, KaijuAngleSortMode mode = KaijuAngleSortMode.Magnitude, bool? farthest = null)
~~~

Sort from the position.

~~~csharp
public static GameObject[] SortAngle ([NotNull] this GameObject position, [NotNull] IEnumerable<GameObject> targets, KaijuAngleSortMode mode = KaijuAngleSortMode.Magnitude, bool? farthest = null)
~~~

Sort from the position.
