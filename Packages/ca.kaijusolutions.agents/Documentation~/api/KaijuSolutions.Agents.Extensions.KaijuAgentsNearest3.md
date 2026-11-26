# KaijuAgentsNearest3

Extension methods to get the nearest object to a given position along all three axes. Any Vector2 values will be expanded via the KaijuAgentsExpand.Expand method.

~~~csharp
public static class KaijuAgentsNearest3
~~~

[Package source](../../Runtime/Extensions/KaijuAgentsNearest3.cs)

<a id="KaijuSolutions_Agents_Extensions_KaijuAgentsNearest3_Nearest3"></a>

### Nearest3

~~~csharp
public static Vector3 Nearest3 (this Vector2 position, [NotNull] IEnumerable<Vector3> targets, out float distance)
~~~

The nearest instance across all three axes to a position.

~~~csharp
public static Transform Nearest3 (this Vector2 position, [NotNull] IEnumerable<Transform> targets, out float distance)
~~~

The nearest instance across all three axes to a position.

~~~csharp
public static T Nearest3 <T> (this Vector2 position, [NotNull] IEnumerable<T> targets, out float distance) where T : Component
~~~

The nearest instance across all three axes to a position.

~~~csharp
public static GameObject Nearest3 (this Vector2 position, [NotNull] IEnumerable<GameObject> targets, out float distance)
~~~

The nearest instance across all three axes to a position.

~~~csharp
public static Vector3 Nearest3 (this Vector3 position, [NotNull] IEnumerable<Vector3> targets, out float distance)
~~~

The nearest instance across all three axes to a position.

~~~csharp
public static Transform Nearest3 (this Vector3 position, [NotNull] IEnumerable<Transform> targets, out float distance)
~~~

The nearest instance across all three axes to a position.

~~~csharp
public static T Nearest3 <T> (this Vector3 position, [NotNull] IEnumerable<T> targets, out float distance) where T : Component
~~~

The nearest instance across all three axes to a position.

~~~csharp
public static GameObject Nearest3 (this Vector3 position, [NotNull] IEnumerable<GameObject> targets, out float distance)
~~~

The nearest instance across all three axes to a position.

~~~csharp
public static Vector3 Nearest3 ([NotNull] this Transform position, [NotNull] IEnumerable<Vector3> targets, out float distance)
~~~

The nearest instance across all three axes to a position.

~~~csharp
public static Transform Nearest3 ([NotNull] this Transform position, [NotNull] IEnumerable<Transform> targets, out float distance)
~~~

The nearest instance across all three axes to a position.

~~~csharp
public static T Nearest3 <T> ([NotNull] this Transform position, [NotNull] IEnumerable<T> targets, out float distance) where T : Component
~~~

The nearest instance across all three axes to a position.

~~~csharp
public static GameObject Nearest3 ([NotNull] this Transform position, [NotNull] IEnumerable<GameObject> targets, out float distance)
~~~

The nearest instance across all three axes to a position.

~~~csharp
public static Vector3 Nearest3 ([NotNull] this Component position, [NotNull] IEnumerable<Vector3> targets, out float distance)
~~~

The nearest instance across all three axes to a position.

~~~csharp
public static Transform Nearest3 ([NotNull] this Component position, [NotNull] IEnumerable<Transform> targets, out float distance)
~~~

The nearest instance across all three axes to a position.

~~~csharp
public static T Nearest3 <T> ([NotNull] this Component position, [NotNull] IEnumerable<T> targets, out float distance) where T : Component
~~~

The nearest instance across all three axes to a position.

~~~csharp
public static GameObject Nearest3 ([NotNull] this Component position, [NotNull] IEnumerable<GameObject> targets, out float distance)
~~~

The nearest instance across all three axes to a position.

~~~csharp
public static Vector3 Nearest3 ([NotNull] this GameObject position, [NotNull] IEnumerable<Vector3> targets, out float distance)
~~~

The nearest instance across all three axes to a position.

~~~csharp
public static Transform Nearest3 ([NotNull] this GameObject position, [NotNull] IEnumerable<Transform> targets, out float distance)
~~~

The nearest instance across all three axes to a position.

~~~csharp
public static T Nearest3 <T> ([NotNull] this GameObject position, [NotNull] IEnumerable<T> targets, out float distance) where T : Component
~~~

The nearest instance across all three axes to a position.

~~~csharp
public static GameObject Nearest3 ([NotNull] this GameObject position, [NotNull] IEnumerable<GameObject> targets, out float distance)
~~~

The nearest instance across all three axes to a position.
