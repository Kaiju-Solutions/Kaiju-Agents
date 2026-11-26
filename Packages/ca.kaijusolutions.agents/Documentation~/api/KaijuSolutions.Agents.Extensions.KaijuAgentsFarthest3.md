# KaijuAgentsFarthest3

Extension methods to get the farthest object from a given position along all three axes. Any Vector2 values will be expanded via the KaijuAgentsExpand.Expand method.

~~~csharp
public static class KaijuAgentsFarthest3
~~~

[Package source](../../Runtime/Extensions/KaijuAgentsFarthest3.cs)

<a id="KaijuSolutions_Agents_Extensions_KaijuAgentsFarthest3_Farthest3"></a>

### Farthest3

~~~csharp
public static Vector3 Farthest3 (this Vector2 position, [NotNull] IEnumerable<Vector3> targets, out float distance)
~~~

The farthest instance across all three axes to a position.

~~~csharp
public static Transform Farthest3 (this Vector2 position, [NotNull] IEnumerable<Transform> targets, out float distance)
~~~

The farthest instance across all three axes to a position.

~~~csharp
public static T Farthest3 <T> (this Vector2 position, [NotNull] IEnumerable<T> targets, out float distance) where T : Component
~~~

The farthest instance across all three axes to a position.

~~~csharp
public static GameObject Farthest3 (this Vector2 position, [NotNull] IEnumerable<GameObject> targets, out float distance)
~~~

The farthest instance across all three axes to a position.

~~~csharp
public static Vector3 Farthest3 (this Vector3 position, [NotNull] IEnumerable<Vector3> targets, out float distance)
~~~

The farthest instance across all three axes to a position.

~~~csharp
public static Transform Farthest3 (this Vector3 position, [NotNull] IEnumerable<Transform> targets, out float distance)
~~~

The farthest instance across all three axes to a position.

~~~csharp
public static T Farthest3 <T> (this Vector3 position, [NotNull] IEnumerable<T> targets, out float distance) where T : Component
~~~

The farthest instance across all three axes to a position.

~~~csharp
public static GameObject Farthest3 (this Vector3 position, [NotNull] IEnumerable<GameObject> targets, out float distance)
~~~

The farthest instance across all three axes to a position.

~~~csharp
public static Vector3 Farthest3 ([NotNull] this Transform position, [NotNull] IEnumerable<Vector3> targets, out float distance)
~~~

The farthest instance across all three axes to a position.

~~~csharp
public static Transform Farthest3 ([NotNull] this Transform position, [NotNull] IEnumerable<Transform> targets, out float distance)
~~~

The farthest instance across all three axes to a position.

~~~csharp
public static T Farthest3 <T> ([NotNull] this Transform position, [NotNull] IEnumerable<T> targets, out float distance) where T : Component
~~~

The farthest instance across all three axes to a position.

~~~csharp
public static GameObject Farthest3 ([NotNull] this Transform position, [NotNull] IEnumerable<GameObject> targets, out float distance)
~~~

The farthest instance across all three axes to a position.

~~~csharp
public static Vector3 Farthest3 ([NotNull] this Component position, [NotNull] IEnumerable<Vector3> targets, out float distance)
~~~

The farthest instance across all three axes to a position.

~~~csharp
public static Transform Farthest3 ([NotNull] this Component position, [NotNull] IEnumerable<Transform> targets, out float distance)
~~~

The farthest instance across all three axes to a position.

~~~csharp
public static T Farthest3 <T> ([NotNull] this Component position, [NotNull] IEnumerable<T> targets, out float distance) where T : Component
~~~

The farthest instance across all three axes to a position.

~~~csharp
public static GameObject Farthest3 ([NotNull] this Component position, [NotNull] IEnumerable<GameObject> targets, out float distance)
~~~

The farthest instance across all three axes to a position.

~~~csharp
public static Vector3 Farthest3 ([NotNull] this GameObject position, [NotNull] IEnumerable<Vector3> targets, out float distance)
~~~

The farthest instance across all three axes to a position.

~~~csharp
public static Transform Farthest3 ([NotNull] this GameObject position, [NotNull] IEnumerable<Transform> targets, out float distance)
~~~

The farthest instance across all three axes to a position.

~~~csharp
public static T Farthest3 <T> ([NotNull] this GameObject position, [NotNull] IEnumerable<T> targets, out float distance) where T : Component
~~~

The farthest instance across all three axes to a position.

~~~csharp
public static GameObject Farthest3 ([NotNull] this GameObject position, [NotNull] IEnumerable<GameObject> targets, out float distance)
~~~

The farthest instance across all three axes to a position.
