# KaijuAgentsSortDistance

Extension methods for sorting objects by their distance to a given position along the X and Z axes. All three-dimensional vectors will be flattened via methods in KaijuAgentsFlatten.

~~~csharp
public static class KaijuAgentsSortDistance
~~~

[Package source](../../Runtime/Extensions/KaijuAgentsSortDistance.cs)

<a id="KaijuSolutions_Agents_Extensions_KaijuAgentsSortDistance_SortDistance"></a>

### SortDistance

~~~csharp
public static void SortDistance (this Vector2 position, [NotNull] Vector2[] targets, bool farthest = false, KaijuAngleSortMode? mode = null, Vector2? forward = null)
~~~

Sort targets from a position.

~~~csharp
public static void SortDistance (this Vector2 position, [NotNull] List<Vector2> targets, bool farthest = false, KaijuAngleSortMode? mode = null, Vector2? forward = null)
~~~

Sort targets from a position.

~~~csharp
public static Vector2[] SortDistance (this Vector2 position, [NotNull] IEnumerable<Vector2> targets, bool farthest = false, KaijuAngleSortMode? mode = null, Vector2? forward = null)
~~~

Sort targets from a position. This version will produce garbage, and it is recommended to use an inplace method instead.

~~~csharp
public static void SortDistance (this Vector2 position, [NotNull] Vector3[] targets, bool farthest = false, KaijuAngleSortMode? mode = null, Vector2? forward = null)
~~~

Sort targets from a position.

~~~csharp
public static void SortDistance (this Vector2 position, [NotNull] List<Vector3> targets, bool farthest = false, KaijuAngleSortMode? mode = null, Vector2? forward = null)
~~~

Sort targets from a position.

~~~csharp
public static Vector3[] SortDistance (this Vector2 position, [NotNull] IEnumerable<Vector3> targets, bool farthest = false, KaijuAngleSortMode? mode = null, Vector2? forward = null)
~~~

Sort targets from a position. This version will produce garbage, and it is recommended to use an inplace method instead.

~~~csharp
public static void SortDistance (this Vector2 position, [NotNull] Transform[] targets, bool farthest = false, KaijuAngleSortMode? mode = null, Vector2? forward = null)
~~~

Sort targets from a position.

~~~csharp
public static void SortDistance (this Vector2 position, [NotNull] List<Transform> targets, bool farthest = false, KaijuAngleSortMode? mode = null, Vector2? forward = null)
~~~

Sort targets from a position.

~~~csharp
public static Transform[] SortDistance (this Vector2 position, [NotNull] IEnumerable<Transform> targets, bool farthest = false, KaijuAngleSortMode? mode = null, Vector2? forward = null)
~~~

Sort targets from a position. This version will produce garbage, and it is recommended to use an inplace method instead.

~~~csharp
public static void SortDistance <T> (this Vector2 position, [NotNull] T[] targets, bool farthest = false, KaijuAngleSortMode? mode = null, Vector2? forward = null) where T : Component
~~~

Sort targets from a position.

~~~csharp
public static void SortDistance <T> (this Vector2 position, [NotNull] List<T> targets, bool farthest = false, KaijuAngleSortMode? mode = null, Vector2? forward = null) where T : Component
~~~

Sort targets from a position.

~~~csharp
public static T[] SortDistance <T> (this Vector2 position, [NotNull] IEnumerable<T> targets, bool farthest = false, KaijuAngleSortMode? mode = null, Vector2? forward = null) where T : Component
~~~

Sort targets from a position. This version will produce garbage, and it is recommended to use an inplace method instead.

~~~csharp
public static void SortDistance (this Vector2 position, [NotNull] GameObject[] targets, bool farthest = false, KaijuAngleSortMode? mode = null, Vector2? forward = null)
~~~

Sort targets from a position.

~~~csharp
public static void SortDistance (this Vector2 position, [NotNull] List<GameObject> targets, bool farthest = false, KaijuAngleSortMode? mode = null, Vector2? forward = null)
~~~

Sort targets from a position.

~~~csharp
public static GameObject[] SortDistance (this Vector2 position, [NotNull] IEnumerable<GameObject> targets, bool farthest = false, KaijuAngleSortMode? mode = null, Vector2? forward = null)
~~~

Sort targets from a position. This version will produce garbage, and it is recommended to use an inplace method instead.

~~~csharp
public static void SortDistance (this Vector3 position, [NotNull] Vector2[] targets, bool farthest = false, KaijuAngleSortMode? mode = null, Vector2? forward = null)
~~~

Sort targets from a position.

~~~csharp
public static void SortDistance (this Vector3 position, [NotNull] List<Vector2> targets, bool farthest = false, KaijuAngleSortMode? mode = null, Vector2? forward = null)
~~~

Sort targets from a position.

~~~csharp
public static Vector2[] SortDistance (this Vector3 position, [NotNull] IEnumerable<Vector2> targets, bool farthest = false, KaijuAngleSortMode? mode = null, Vector2? forward = null)
~~~

Sort targets from a position. This version will produce garbage, and it is recommended to use an inplace method instead.

~~~csharp
public static void SortDistance (this Vector3 position, [NotNull] Vector3[] targets, bool farthest = false, KaijuAngleSortMode? mode = null, Vector2? forward = null)
~~~

Sort targets from a position.

~~~csharp
public static void SortDistance (this Vector3 position, [NotNull] List<Vector3> targets, bool farthest = false, KaijuAngleSortMode? mode = null, Vector2? forward = null)
~~~

Sort targets from a position.

~~~csharp
public static Vector3[] SortDistance (this Vector3 position, [NotNull] IEnumerable<Vector3> targets, bool farthest = false, KaijuAngleSortMode? mode = null, Vector2? forward = null)
~~~

Sort targets from a position. This version will produce garbage, and it is recommended to use an inplace method instead.

~~~csharp
public static void SortDistance (this Vector3 position, [NotNull] Transform[] targets, bool farthest = false, KaijuAngleSortMode? mode = null, Vector2? forward = null)
~~~

Sort targets from a position.

~~~csharp
public static void SortDistance (this Vector3 position, [NotNull] List<Transform> targets, bool farthest = false, KaijuAngleSortMode? mode = null, Vector2? forward = null)
~~~

Sort targets from a position.

~~~csharp
public static Transform[] SortDistance (this Vector3 position, [NotNull] IEnumerable<Transform> targets, bool farthest = false, KaijuAngleSortMode? mode = null, Vector2? forward = null)
~~~

Sort targets from a position. This version will produce garbage, and it is recommended to use an inplace method instead.

~~~csharp
public static void SortDistance <T> (this Vector3 position, [NotNull] T[] targets, bool farthest = false, KaijuAngleSortMode? mode = null, Vector2? forward = null) where T : Component
~~~

Sort targets from a position.

~~~csharp
public static void SortDistance <T> (this Vector3 position, [NotNull] List<T> targets, bool farthest = false, KaijuAngleSortMode? mode = null, Vector2? forward = null) where T : Component
~~~

Sort targets from a position.

~~~csharp
public static T[] SortDistance <T> (this Vector3 position, [NotNull] IEnumerable<T> targets, bool farthest = false, KaijuAngleSortMode? mode = null, Vector2? forward = null) where T : Component
~~~

Sort targets from a position. This version will produce garbage, and it is recommended to use an inplace method instead.

~~~csharp
public static void SortDistance (this Vector3 position, [NotNull] GameObject[] targets, bool farthest = false, KaijuAngleSortMode? mode = null, Vector2? forward = null)
~~~

Sort targets from a position.

~~~csharp
public static void SortDistance (this Vector3 position, [NotNull] List<GameObject> targets, bool farthest = false, KaijuAngleSortMode? mode = null, Vector2? forward = null)
~~~

Sort targets from a position.

~~~csharp
public static GameObject[] SortDistance (this Vector3 position, [NotNull] IEnumerable<GameObject> targets, bool farthest = false, KaijuAngleSortMode? mode = null, Vector2? forward = null)
~~~

Sort targets from a position. This version will produce garbage, and it is recommended to use an inplace method instead.

~~~csharp
public static void SortDistance ([NotNull] this Transform position, [NotNull] Vector2[] targets, bool farthest = false, KaijuAngleSortMode? mode = null, Vector2? forward = null)
~~~

Sort targets from a position.

~~~csharp
public static void SortDistance ([NotNull] this Transform position, [NotNull] List<Vector2> targets, bool farthest = false, KaijuAngleSortMode? mode = null, Vector2? forward = null)
~~~

Sort targets from a position.

~~~csharp
public static Vector2[] SortDistance ([NotNull] this Transform position, [NotNull] IEnumerable<Vector2> targets, bool farthest = false, KaijuAngleSortMode? mode = null, Vector2? forward = null)
~~~

Sort targets from a position. This version will produce garbage, and it is recommended to use an inplace method instead.

~~~csharp
public static void SortDistance ([NotNull] this Transform position, [NotNull] Vector3[] targets, bool farthest = false, KaijuAngleSortMode? mode = null, Vector2? forward = null)
~~~

Sort targets from a position.

~~~csharp
public static void SortDistance ([NotNull] this Transform position, [NotNull] List<Vector3> targets, bool farthest = false, KaijuAngleSortMode? mode = null, Vector2? forward = null)
~~~

Sort targets from a position.

~~~csharp
public static Vector3[] SortDistance ([NotNull] this Transform position, [NotNull] IEnumerable<Vector3> targets, bool farthest = false, KaijuAngleSortMode? mode = null, Vector2? forward = null)
~~~

Sort targets from a position. This version will produce garbage, and it is recommended to use an inplace method instead.

~~~csharp
public static void SortDistance ([NotNull] this Transform position, [NotNull] Transform[] targets, bool farthest = false, KaijuAngleSortMode? mode = null, Vector2? forward = null)
~~~

Sort targets from a position.

~~~csharp
public static void SortDistance ([NotNull] this Transform position, [NotNull] List<Transform> targets, bool farthest = false, KaijuAngleSortMode? mode = null, Vector2? forward = null)
~~~

Sort targets from a position.

~~~csharp
public static Transform[] SortDistance ([NotNull] this Transform position, [NotNull] IEnumerable<Transform> targets, bool farthest = false, KaijuAngleSortMode? mode = null, Vector2? forward = null)
~~~

Sort targets from a position. This version will produce garbage, and it is recommended to use an inplace method instead.

~~~csharp
public static void SortDistance <T> ([NotNull] this Transform position, [NotNull] T[] targets, bool farthest = false, KaijuAngleSortMode? mode = null, Vector2? forward = null) where T : Component
~~~

Sort targets from a position.

~~~csharp
public static void SortDistance <T> ([NotNull] this Transform position, [NotNull] List<T> targets, bool farthest = false, KaijuAngleSortMode? mode = null, Vector2? forward = null) where T : Component
~~~

Sort targets from a position.

~~~csharp
public static T[] SortDistance <T> ([NotNull] this Transform position, [NotNull] IEnumerable<T> targets, bool farthest = false, KaijuAngleSortMode? mode = null, Vector2? forward = null) where T : Component
~~~

Sort targets from a position. This version will produce garbage, and it is recommended to use an inplace method instead.

~~~csharp
public static void SortDistance ([NotNull] this Transform position, [NotNull] GameObject[] targets, bool farthest = false, KaijuAngleSortMode? mode = null, Vector2? forward = null)
~~~

Sort targets from a position.

~~~csharp
public static void SortDistance ([NotNull] this Transform position, [NotNull] List<GameObject> targets, bool farthest = false, KaijuAngleSortMode? mode = null, Vector2? forward = null)
~~~

Sort targets from a position.

~~~csharp
public static GameObject[] SortDistance ([NotNull] this Transform position, [NotNull] IEnumerable<GameObject> targets, bool farthest = false, KaijuAngleSortMode? mode = null, Vector2? forward = null)
~~~

Sort targets from a position. This version will produce garbage, and it is recommended to use an inplace method instead.

~~~csharp
public static void SortDistance ([NotNull] this Component position, [NotNull] Vector2[] targets, bool farthest = false, KaijuAngleSortMode? mode = null, Vector2? forward = null)
~~~

Sort targets from a position.

~~~csharp
public static void SortDistance ([NotNull] this Component position, [NotNull] List<Vector2> targets, bool farthest = false, KaijuAngleSortMode? mode = null, Vector2? forward = null)
~~~

Sort targets from a position.

~~~csharp
public static Vector2[] SortDistance ([NotNull] this Component position, [NotNull] IEnumerable<Vector2> targets, bool farthest = false, KaijuAngleSortMode? mode = null, Vector2? forward = null)
~~~

Sort targets from a position. This version will produce garbage, and it is recommended to use an inplace method instead.

~~~csharp
public static void SortDistance ([NotNull] this Component position, [NotNull] Vector3[] targets, bool farthest = false, KaijuAngleSortMode? mode = null, Vector2? forward = null)
~~~

Sort targets from a position.

~~~csharp
public static void SortDistance ([NotNull] this Component position, [NotNull] List<Vector3> targets, bool farthest = false, KaijuAngleSortMode? mode = null, Vector2? forward = null)
~~~

Sort targets from a position.

~~~csharp
public static Vector3[] SortDistance ([NotNull] this Component position, [NotNull] IEnumerable<Vector3> targets, bool farthest = false, KaijuAngleSortMode? mode = null, Vector2? forward = null)
~~~

Sort targets from a position. This version will produce garbage, and it is recommended to use an inplace method instead.

~~~csharp
public static void SortDistance ([NotNull] this Component position, [NotNull] Transform[] targets, bool farthest = false, KaijuAngleSortMode? mode = null, Vector2? forward = null)
~~~

Sort targets from a position.

~~~csharp
public static void SortDistance ([NotNull] this Component position, [NotNull] List<Transform> targets, bool farthest = false, KaijuAngleSortMode? mode = null, Vector2? forward = null)
~~~

Sort targets from a position.

~~~csharp
public static Transform[] SortDistance ([NotNull] this Component position, [NotNull] IEnumerable<Transform> targets, bool farthest = false, KaijuAngleSortMode? mode = null, Vector2? forward = null)
~~~

Sort targets from a position. This version will produce garbage, and it is recommended to use an inplace method instead.

~~~csharp
public static void SortDistance <T> ([NotNull] this Component position, [NotNull] T[] targets, bool farthest = false, KaijuAngleSortMode? mode = null, Vector2? forward = null) where T : Component
~~~

Sort targets from a position.

~~~csharp
public static void SortDistance <T> ([NotNull] this Component position, [NotNull] List<T> targets, bool farthest = false, KaijuAngleSortMode? mode = null, Vector2? forward = null) where T : Component
~~~

Sort targets from a position.

~~~csharp
public static T[] SortDistance <T> ([NotNull] this Component position, [NotNull] IEnumerable<T> targets, bool farthest = false, KaijuAngleSortMode? mode = null, Vector2? forward = null) where T : Component
~~~

Sort targets from a position. This version will produce garbage, and it is recommended to use an inplace method instead.

~~~csharp
public static void SortDistance ([NotNull] this Component position, [NotNull] GameObject[] targets, bool farthest = false, KaijuAngleSortMode? mode = null, Vector2? forward = null)
~~~

Sort targets from a position.

~~~csharp
public static void SortDistance ([NotNull] this Component position, [NotNull] List<GameObject> targets, bool farthest = false, KaijuAngleSortMode? mode = null, Vector2? forward = null)
~~~

Sort targets from a position.

~~~csharp
public static GameObject[] SortDistance ([NotNull] this Component position, [NotNull] IEnumerable<GameObject> targets, bool farthest = false, KaijuAngleSortMode? mode = null, Vector2? forward = null)
~~~

Sort targets from a position. This version will produce garbage, and it is recommended to use an inplace method instead.

~~~csharp
public static void SortDistance ([NotNull] this GameObject position, [NotNull] Vector2[] targets, bool farthest = false, KaijuAngleSortMode? mode = null, Vector2? forward = null)
~~~

Sort targets from a position.

~~~csharp
public static void SortDistance ([NotNull] this GameObject position, [NotNull] List<Vector2> targets, bool farthest = false, KaijuAngleSortMode? mode = null, Vector2? forward = null)
~~~

Sort targets from a position.

~~~csharp
public static Vector2[] SortDistance ([NotNull] this GameObject position, [NotNull] IEnumerable<Vector2> targets, bool farthest = false, KaijuAngleSortMode? mode = null, Vector2? forward = null)
~~~

Sort targets from a position. This version will produce garbage, and it is recommended to use an inplace method instead.

~~~csharp
public static void SortDistance ([NotNull] this GameObject position, [NotNull] Vector3[] targets, bool farthest = false, KaijuAngleSortMode? mode = null, Vector2? forward = null)
~~~

Sort targets from a position.

~~~csharp
public static void SortDistance ([NotNull] this GameObject position, [NotNull] List<Vector3> targets, bool farthest = false, KaijuAngleSortMode? mode = null, Vector2? forward = null)
~~~

Sort targets from a position.

~~~csharp
public static Vector3[] SortDistance ([NotNull] this GameObject position, [NotNull] IEnumerable<Vector3> targets, bool farthest = false, KaijuAngleSortMode? mode = null, Vector2? forward = null)
~~~

Sort targets from a position. This version will produce garbage, and it is recommended to use an inplace method instead.

~~~csharp
public static void SortDistance ([NotNull] this GameObject position, [NotNull] Transform[] targets, bool farthest = false, KaijuAngleSortMode? mode = null, Vector2? forward = null)
~~~

Sort targets from a position.

~~~csharp
public static void SortDistance ([NotNull] this GameObject position, [NotNull] List<Transform> targets, bool farthest = false, KaijuAngleSortMode? mode = null, Vector2? forward = null)
~~~

Sort targets from a position.

~~~csharp
public static Transform[] SortDistance ([NotNull] this GameObject position, [NotNull] IEnumerable<Transform> targets, bool farthest = false, KaijuAngleSortMode? mode = null, Vector2? forward = null)
~~~

Sort targets from a position. This version will produce garbage, and it is recommended to use an inplace method instead.

~~~csharp
public static void SortDistance <T> ([NotNull] this GameObject position, [NotNull] T[] targets, bool farthest = false, KaijuAngleSortMode? mode = null, Vector2? forward = null) where T : Component
~~~

Sort targets from a position.

~~~csharp
public static void SortDistance <T> ([NotNull] this GameObject position, [NotNull] List<T> targets, bool farthest = false, KaijuAngleSortMode? mode = null, Vector2? forward = null) where T : Component
~~~

Sort targets from a position.

~~~csharp
public static T[] SortDistance <T> ([NotNull] this GameObject position, [NotNull] IEnumerable<T> targets, bool farthest = false, KaijuAngleSortMode? mode = null, Vector2? forward = null) where T : Component
~~~

Sort targets from a position. This version will produce garbage, and it is recommended to use an inplace method instead.

~~~csharp
public static void SortDistance ([NotNull] this GameObject position, [NotNull] GameObject[] targets, bool farthest = false, KaijuAngleSortMode? mode = null, Vector2? forward = null)
~~~

Sort targets from a position.

~~~csharp
public static void SortDistance ([NotNull] this GameObject position, [NotNull] List<GameObject> targets, bool farthest = false, KaijuAngleSortMode? mode = null, Vector2? forward = null)
~~~

Sort targets from a position.

~~~csharp
public static GameObject[] SortDistance ([NotNull] this GameObject position, [NotNull] IEnumerable<GameObject> targets, bool farthest = false, KaijuAngleSortMode? mode = null, Vector2? forward = null)
~~~

Sort targets from a position. This version will produce garbage, and it is recommended to use an inplace method instead.
