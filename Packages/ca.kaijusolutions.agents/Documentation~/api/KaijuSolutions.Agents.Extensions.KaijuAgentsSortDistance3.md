# KaijuAgentsSortDistance3

Extension methods for sorting objects by their distance to a given position along all three axes. Any Vector2 values will be expanded via the KaijuAgentsExpand.Expand method.

~~~csharp
public static class KaijuAgentsSortDistance3
~~~

[Package source](../../Runtime/Extensions/KaijuAgentsSortDistance3.cs)

<a id="KaijuSolutions_Agents_Extensions_KaijuAgentsSortDistance3_SortDistance3"></a>

### SortDistance3

~~~csharp
public static void SortDistance3 (this Vector2 position, [NotNull] Vector2[] targets, bool farthest = false, KaijuAngleSortMode? mode = null, Vector2? forward = null)
~~~

Sort targets from a position.

~~~csharp
public static void SortDistance3 (this Vector2 position, [NotNull] List<Vector2> targets, bool farthest = false, KaijuAngleSortMode? mode = null, Vector2? forward = null)
~~~

Sort targets from a position.

~~~csharp
public static Vector2[] SortDistance3 (this Vector2 position, [NotNull] IEnumerable<Vector2> targets, bool farthest = false, KaijuAngleSortMode? mode = null, Vector2? forward = null)
~~~

Sort targets from a position. This version will produce garbage, and it is recommended to use an inplace method instead.

~~~csharp
public static void SortDistance3 (this Vector2 position, [NotNull] Vector3[] targets, bool farthest = false, KaijuAngleSortMode? mode = null, Vector2? forward = null)
~~~

Sort targets from a position.

~~~csharp
public static void SortDistance3 (this Vector2 position, [NotNull] List<Vector3> targets, bool farthest = false, KaijuAngleSortMode? mode = null, Vector2? forward = null)
~~~

Sort targets from a position.

~~~csharp
public static Vector3[] SortDistance3 (this Vector2 position, [NotNull] IEnumerable<Vector3> targets, bool farthest = false, KaijuAngleSortMode? mode = null, Vector2? forward = null)
~~~

Sort targets from a position. This version will produce garbage, and it is recommended to use an inplace method instead.

~~~csharp
public static void SortDistance3 (this Vector2 position, [NotNull] Transform[] targets, bool farthest = false, KaijuAngleSortMode? mode = null, Vector2? forward = null)
~~~

Sort targets from a position.

~~~csharp
public static void SortDistance3 (this Vector2 position, [NotNull] List<Transform> targets, bool farthest = false, KaijuAngleSortMode? mode = null, Vector2? forward = null)
~~~

Sort targets from a position.

~~~csharp
public static Transform[] SortDistance3 (this Vector2 position, [NotNull] IEnumerable<Transform> targets, bool farthest = false, KaijuAngleSortMode? mode = null, Vector2? forward = null)
~~~

Sort targets from a position. This version will produce garbage, and it is recommended to use an inplace method instead.

~~~csharp
public static void SortDistance3 <T> (this Vector2 position, [NotNull] T[] targets, bool farthest = false, KaijuAngleSortMode? mode = null, Vector2? forward = null) where T : Component
~~~

Sort targets from a position.

~~~csharp
public static void SortDistance3 <T> (this Vector2 position, [NotNull] List<T> targets, bool farthest = false, KaijuAngleSortMode? mode = null, Vector2? forward = null) where T : Component
~~~

Sort targets from a position.

~~~csharp
public static T[] SortDistance3 <T> (this Vector2 position, [NotNull] IEnumerable<T> targets, bool farthest = false, KaijuAngleSortMode? mode = null, Vector2? forward = null) where T : Component
~~~

Sort targets from a position. This version will produce garbage, and it is recommended to use an inplace method instead.

~~~csharp
public static void SortDistance3 (this Vector2 position, [NotNull] GameObject[] targets, bool farthest = false, KaijuAngleSortMode? mode = null, Vector2? forward = null)
~~~

Sort targets from a position.

~~~csharp
public static void SortDistance3 (this Vector2 position, [NotNull] List<GameObject> targets, bool farthest = false, KaijuAngleSortMode? mode = null, Vector2? forward = null)
~~~

Sort targets from a position.

~~~csharp
public static GameObject[] SortDistance3 (this Vector2 position, [NotNull] IEnumerable<GameObject> targets, bool farthest = false, KaijuAngleSortMode? mode = null, Vector2? forward = null)
~~~

Sort targets from a position. This version will produce garbage, and it is recommended to use an inplace method instead.

~~~csharp
public static void SortDistance3 (this Vector3 position, [NotNull] Vector2[] targets, bool farthest = false, KaijuAngleSortMode? mode = null, Vector2? forward = null)
~~~

Sort targets from a position.

~~~csharp
public static void SortDistance3 (this Vector3 position, [NotNull] List<Vector2> targets, bool farthest = false, KaijuAngleSortMode? mode = null, Vector2? forward = null)
~~~

Sort targets from a position.

~~~csharp
public static Vector2[] SortDistance3 (this Vector3 position, [NotNull] IEnumerable<Vector2> targets, bool farthest = false, KaijuAngleSortMode? mode = null, Vector2? forward = null)
~~~

Sort targets from a position. This version will produce garbage, and it is recommended to use an inplace method instead.

~~~csharp
public static void SortDistance3 (this Vector3 position, [NotNull] Vector3[] targets, bool farthest = false, KaijuAngleSortMode? mode = null, Vector2? forward = null)
~~~

Sort targets from a position.

~~~csharp
public static void SortDistance3 (this Vector3 position, [NotNull] List<Vector3> targets, bool farthest = false, KaijuAngleSortMode? mode = null, Vector2? forward = null)
~~~

Sort targets from a position.

~~~csharp
public static Vector3[] SortDistance3 (this Vector3 position, [NotNull] IEnumerable<Vector3> targets, bool farthest = false, KaijuAngleSortMode? mode = null, Vector2? forward = null)
~~~

Sort targets from a position. This version will produce garbage, and it is recommended to use an inplace method instead.

~~~csharp
public static void SortDistance3 (this Vector3 position, [NotNull] Transform[] targets, bool farthest = false, KaijuAngleSortMode? mode = null, Vector2? forward = null)
~~~

Sort targets from a position.

~~~csharp
public static void SortDistance3 (this Vector3 position, [NotNull] List<Transform> targets, bool farthest = false, KaijuAngleSortMode? mode = null, Vector2? forward = null)
~~~

Sort targets from a position.

~~~csharp
public static Transform[] SortDistance3 (this Vector3 position, [NotNull] IEnumerable<Transform> targets, bool farthest = false, KaijuAngleSortMode? mode = null, Vector2? forward = null)
~~~

Sort targets from a position. This version will produce garbage, and it is recommended to use an inplace method instead.

~~~csharp
public static void SortDistance3 <T> (this Vector3 position, [NotNull] T[] targets, bool farthest = false, KaijuAngleSortMode? mode = null, Vector2? forward = null) where T : Component
~~~

Sort targets from a position.

~~~csharp
public static void SortDistance3 <T> (this Vector3 position, [NotNull] List<T> targets, bool farthest = false, KaijuAngleSortMode? mode = null, Vector2? forward = null) where T : Component
~~~

Sort targets from a position.

~~~csharp
public static T[] SortDistance3 <T> (this Vector3 position, [NotNull] IEnumerable<T> targets, bool farthest = false, KaijuAngleSortMode? mode = null, Vector2? forward = null) where T : Component
~~~

Sort targets from a position. This version will produce garbage, and it is recommended to use an inplace method instead.

~~~csharp
public static void SortDistance3 (this Vector3 position, [NotNull] GameObject[] targets, bool farthest = false, KaijuAngleSortMode? mode = null, Vector2? forward = null)
~~~

Sort targets from a position.

~~~csharp
public static void SortDistance3 (this Vector3 position, [NotNull] List<GameObject> targets, bool farthest = false, KaijuAngleSortMode? mode = null, Vector2? forward = null)
~~~

Sort targets from a position.

~~~csharp
public static GameObject[] SortDistance3 (this Vector3 position, [NotNull] IEnumerable<GameObject> targets, bool farthest = false, KaijuAngleSortMode? mode = null, Vector2? forward = null)
~~~

Sort targets from a position. This version will produce garbage, and it is recommended to use an inplace method instead.

~~~csharp
public static void SortDistance3 ([NotNull] this Transform position, [NotNull] Vector2[] targets, bool farthest = false, KaijuAngleSortMode? mode = null, Vector2? forward = null)
~~~

Sort targets from a position.

~~~csharp
public static void SortDistance3 ([NotNull] this Transform position, [NotNull] List<Vector2> targets, bool farthest = false, KaijuAngleSortMode? mode = null, Vector2? forward = null)
~~~

Sort targets from a position.

~~~csharp
public static Vector2[] SortDistance3 ([NotNull] this Transform position, [NotNull] IEnumerable<Vector2> targets, bool farthest = false, KaijuAngleSortMode? mode = null, Vector2? forward = null)
~~~

Sort targets from a position. This version will produce garbage, and it is recommended to use an inplace method instead.

~~~csharp
public static void SortDistance3 ([NotNull] this Transform position, [NotNull] Vector3[] targets, bool farthest = false, KaijuAngleSortMode? mode = null, Vector2? forward = null)
~~~

Sort targets from a position.

~~~csharp
public static void SortDistance3 ([NotNull] this Transform position, [NotNull] List<Vector3> targets, bool farthest = false, KaijuAngleSortMode? mode = null, Vector2? forward = null)
~~~

Sort targets from a position.

~~~csharp
public static Vector3[] SortDistance3 ([NotNull] this Transform position, [NotNull] IEnumerable<Vector3> targets, bool farthest = false, KaijuAngleSortMode? mode = null, Vector2? forward = null)
~~~

Sort targets from a position. This version will produce garbage, and it is recommended to use an inplace method instead.

~~~csharp
public static void SortDistance3 ([NotNull] this Transform position, [NotNull] Transform[] targets, bool farthest = false, KaijuAngleSortMode? mode = null, Vector2? forward = null)
~~~

Sort targets from a position.

~~~csharp
public static void SortDistance3 ([NotNull] this Transform position, [NotNull] List<Transform> targets, bool farthest = false, KaijuAngleSortMode? mode = null, Vector2? forward = null)
~~~

Sort targets from a position.

~~~csharp
public static Transform[] SortDistance3 ([NotNull] this Transform position, [NotNull] IEnumerable<Transform> targets, bool farthest = false, KaijuAngleSortMode? mode = null, Vector2? forward = null)
~~~

Sort targets from a position. This version will produce garbage, and it is recommended to use an inplace method instead.

~~~csharp
public static void SortDistance3 <T> ([NotNull] this Transform position, [NotNull] T[] targets, bool farthest = false, KaijuAngleSortMode? mode = null, Vector2? forward = null) where T : Component
~~~

Sort targets from a position.

~~~csharp
public static void SortDistance3 <T> ([NotNull] this Transform position, [NotNull] List<T> targets, bool farthest = false, KaijuAngleSortMode? mode = null, Vector2? forward = null) where T : Component
~~~

Sort targets from a position.

~~~csharp
public static T[] SortDistance3 <T> ([NotNull] this Transform position, [NotNull] IEnumerable<T> targets, bool farthest = false, KaijuAngleSortMode? mode = null, Vector2? forward = null) where T : Component
~~~

Sort targets from a position. This version will produce garbage, and it is recommended to use an inplace method instead.

~~~csharp
public static void SortDistance3 ([NotNull] this Transform position, [NotNull] GameObject[] targets, bool farthest = false, KaijuAngleSortMode? mode = null, Vector2? forward = null)
~~~

Sort targets from a position.

~~~csharp
public static void SortDistance3 ([NotNull] this Transform position, [NotNull] List<GameObject> targets, bool farthest = false, KaijuAngleSortMode? mode = null, Vector2? forward = null)
~~~

Sort targets from a position.

~~~csharp
public static GameObject[] SortDistance3 ([NotNull] this Transform position, [NotNull] IEnumerable<GameObject> targets, bool farthest = false, KaijuAngleSortMode? mode = null, Vector2? forward = null)
~~~

Sort targets from a position. This version will produce garbage, and it is recommended to use an inplace method instead.

~~~csharp
public static void SortDistance3 ([NotNull] this Component position, [NotNull] Vector2[] targets, bool farthest = false, KaijuAngleSortMode? mode = null, Vector2? forward = null)
~~~

Sort targets from a position.

~~~csharp
public static void SortDistance3 ([NotNull] this Component position, [NotNull] List<Vector2> targets, bool farthest = false, KaijuAngleSortMode? mode = null, Vector2? forward = null)
~~~

Sort targets from a position.

~~~csharp
public static Vector2[] SortDistance3 ([NotNull] this Component position, [NotNull] IEnumerable<Vector2> targets, bool farthest = false, KaijuAngleSortMode? mode = null, Vector2? forward = null)
~~~

Sort targets from a position. This version will produce garbage, and it is recommended to use an inplace method instead.

~~~csharp
public static void SortDistance3 ([NotNull] this Component position, [NotNull] Vector3[] targets, bool farthest = false, KaijuAngleSortMode? mode = null, Vector2? forward = null)
~~~

Sort targets from a position.

~~~csharp
public static void SortDistance3 ([NotNull] this Component position, [NotNull] List<Vector3> targets, bool farthest = false, KaijuAngleSortMode? mode = null, Vector2? forward = null)
~~~

Sort targets from a position.

~~~csharp
public static Vector3[] SortDistance3 ([NotNull] this Component position, [NotNull] IEnumerable<Vector3> targets, bool farthest = false, KaijuAngleSortMode? mode = null, Vector2? forward = null)
~~~

Sort targets from a position. This version will produce garbage, and it is recommended to use an inplace method instead.

~~~csharp
public static void SortDistance3 ([NotNull] this Component position, [NotNull] Transform[] targets, bool farthest = false, KaijuAngleSortMode? mode = null, Vector2? forward = null)
~~~

Sort targets from a position.

~~~csharp
public static void SortDistance3 ([NotNull] this Component position, [NotNull] List<Transform> targets, bool farthest = false, KaijuAngleSortMode? mode = null, Vector2? forward = null)
~~~

Sort targets from a position.

~~~csharp
public static Transform[] SortDistance3 ([NotNull] this Component position, [NotNull] IEnumerable<Transform> targets, bool farthest = false, KaijuAngleSortMode? mode = null, Vector2? forward = null)
~~~

Sort targets from a position. This version will produce garbage, and it is recommended to use an inplace method instead.

~~~csharp
public static void SortDistance3 <T> ([NotNull] this Component position, [NotNull] T[] targets, bool farthest = false, KaijuAngleSortMode? mode = null, Vector2? forward = null) where T : Component
~~~

Sort targets from a position.

~~~csharp
public static void SortDistance3 <T> ([NotNull] this Component position, [NotNull] List<T> targets, bool farthest = false, KaijuAngleSortMode? mode = null, Vector2? forward = null) where T : Component
~~~

Sort targets from a position.

~~~csharp
public static T[] SortDistance3 <T> ([NotNull] this Component position, [NotNull] IEnumerable<T> targets, bool farthest = false, KaijuAngleSortMode? mode = null, Vector2? forward = null) where T : Component
~~~

Sort targets from a position. This version will produce garbage, and it is recommended to use an inplace method instead.

~~~csharp
public static void SortDistance3 ([NotNull] this Component position, [NotNull] GameObject[] targets, bool farthest = false, KaijuAngleSortMode? mode = null, Vector2? forward = null)
~~~

Sort targets from a position.

~~~csharp
public static void SortDistance3 ([NotNull] this Component position, [NotNull] List<GameObject> targets, bool farthest = false, KaijuAngleSortMode? mode = null, Vector2? forward = null)
~~~

Sort targets from a position.

~~~csharp
public static GameObject[] SortDistance3 ([NotNull] this Component position, [NotNull] IEnumerable<GameObject> targets, bool farthest = false, KaijuAngleSortMode? mode = null, Vector2? forward = null)
~~~

Sort targets from a position. This version will produce garbage, and it is recommended to use an inplace method instead.

~~~csharp
public static void SortDistance3 ([NotNull] this GameObject position, [NotNull] Vector2[] targets, bool farthest = false, KaijuAngleSortMode? mode = null, Vector2? forward = null)
~~~

Sort targets from a position.

~~~csharp
public static void SortDistance3 ([NotNull] this GameObject position, [NotNull] List<Vector2> targets, bool farthest = false, KaijuAngleSortMode? mode = null, Vector2? forward = null)
~~~

Sort targets from a position.

~~~csharp
public static Vector2[] SortDistance3 ([NotNull] this GameObject position, [NotNull] IEnumerable<Vector2> targets, bool farthest = false, KaijuAngleSortMode? mode = null, Vector2? forward = null)
~~~

Sort targets from a position. This version will produce garbage, and it is recommended to use an inplace method instead.

~~~csharp
public static void SortDistance3 ([NotNull] this GameObject position, [NotNull] Vector3[] targets, bool farthest = false, KaijuAngleSortMode? mode = null, Vector2? forward = null)
~~~

Sort targets from a position.

~~~csharp
public static void SortDistance3 ([NotNull] this GameObject position, [NotNull] List<Vector3> targets, bool farthest = false, KaijuAngleSortMode? mode = null, Vector2? forward = null)
~~~

Sort targets from a position.

~~~csharp
public static Vector3[] SortDistance3 ([NotNull] this GameObject position, [NotNull] IEnumerable<Vector3> targets, bool farthest = false, KaijuAngleSortMode? mode = null, Vector2? forward = null)
~~~

Sort targets from a position. This version will produce garbage, and it is recommended to use an inplace method instead.

~~~csharp
public static void SortDistance3 ([NotNull] this GameObject position, [NotNull] Transform[] targets, bool farthest = false, KaijuAngleSortMode? mode = null, Vector2? forward = null)
~~~

Sort targets from a position.

~~~csharp
public static void SortDistance3 ([NotNull] this GameObject position, [NotNull] List<Transform> targets, bool farthest = false, KaijuAngleSortMode? mode = null, Vector2? forward = null)
~~~

Sort targets from a position.

~~~csharp
public static Transform[] SortDistance3 ([NotNull] this GameObject position, [NotNull] IEnumerable<Transform> targets, bool farthest = false, KaijuAngleSortMode? mode = null, Vector2? forward = null)
~~~

Sort targets from a position. This version will produce garbage, and it is recommended to use an inplace method instead.

~~~csharp
public static void SortDistance3 <T> ([NotNull] this GameObject position, [NotNull] T[] targets, bool farthest = false, KaijuAngleSortMode? mode = null, Vector2? forward = null) where T : Component
~~~

Sort targets from a position.

~~~csharp
public static void SortDistance3 <T> ([NotNull] this GameObject position, [NotNull] List<T> targets, bool farthest = false, KaijuAngleSortMode? mode = null, Vector2? forward = null) where T : Component
~~~

Sort targets from a position.

~~~csharp
public static T[] SortDistance3 <T> ([NotNull] this GameObject position, [NotNull] IEnumerable<T> targets, bool farthest = false, KaijuAngleSortMode? mode = null, Vector2? forward = null) where T : Component
~~~

Sort targets from a position. This version will produce garbage, and it is recommended to use an inplace method instead.

~~~csharp
public static void SortDistance3 ([NotNull] this GameObject position, [NotNull] GameObject[] targets, bool farthest = false, KaijuAngleSortMode? mode = null, Vector2? forward = null)
~~~

Sort targets from a position.

~~~csharp
public static void SortDistance3 ([NotNull] this GameObject position, [NotNull] List<GameObject> targets, bool farthest = false, KaijuAngleSortMode? mode = null, Vector2? forward = null)
~~~

Sort targets from a position.

~~~csharp
public static GameObject[] SortDistance3 ([NotNull] this GameObject position, [NotNull] IEnumerable<GameObject> targets, bool farthest = false, KaijuAngleSortMode? mode = null, Vector2? forward = null)
~~~

Sort targets from a position. This version will produce garbage, and it is recommended to use an inplace method instead.
