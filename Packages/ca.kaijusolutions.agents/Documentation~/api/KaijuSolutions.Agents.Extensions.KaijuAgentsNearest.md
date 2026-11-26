# KaijuAgentsNearest

Extension methods to get the nearest object to a given position along the X and Z axes. All three-dimensional vectors will be flattened via methods in KaijuAgentsFlatten.

~~~csharp
public static class KaijuAgentsNearest
~~~

[Package source](../../Runtime/Extensions/KaijuAgentsNearest.cs)

<a id="KaijuSolutions_Agents_Extensions_KaijuAgentsNearest_Nearest"></a>

### Nearest

~~~csharp
public static Vector2 Nearest (this Vector2 position, [NotNull] IEnumerable<Vector2> targets, out float distance)
~~~

The nearest instance to a position.

~~~csharp
public static Vector3 Nearest (this Vector2 position, [NotNull] IEnumerable<Vector3> targets, out float distance)
~~~

The nearest instance to a position.

~~~csharp
public static Transform Nearest (this Vector2 position, [NotNull] IEnumerable<Transform> targets, out float distance)
~~~

The nearest instance to a position.

~~~csharp
public static T Nearest <T> (this Vector2 position, [NotNull] IEnumerable<T> targets, out float distance) where T : Component
~~~

The nearest instance to a position.

~~~csharp
public static GameObject Nearest (this Vector2 position, [NotNull] IEnumerable<GameObject> targets, out float distance)
~~~

The nearest instance to a position.

~~~csharp
public static Vector2 Nearest (this Vector3 position, [NotNull] IEnumerable<Vector2> targets, out float distance)
~~~

The nearest instance to a position.

~~~csharp
public static Vector3 Nearest (this Vector3 position, [NotNull] IEnumerable<Vector3> targets, out float distance)
~~~

The nearest instance to a position.

~~~csharp
public static Transform Nearest (this Vector3 position, [NotNull] IEnumerable<Transform> targets, out float distance)
~~~

The nearest instance to a position.

~~~csharp
public static T Nearest <T> (this Vector3 position, [NotNull] IEnumerable<T> targets, out float distance) where T : Component
~~~

The nearest instance to a position.

~~~csharp
public static GameObject Nearest (this Vector3 position, [NotNull] IEnumerable<GameObject> targets, out float distance)
~~~

The nearest instance to a position.

~~~csharp
public static Vector2 Nearest ([NotNull] this Transform position, [NotNull] IEnumerable<Vector2> targets, out float distance)
~~~

The nearest instance to a position.

~~~csharp
public static Vector3 Nearest ([NotNull] this Transform position, [NotNull] IEnumerable<Vector3> targets, out float distance)
~~~

The nearest instance to a position.

~~~csharp
public static Transform Nearest ([NotNull] this Transform position, [NotNull] IEnumerable<Transform> targets, out float distance)
~~~

The nearest instance to a position.

~~~csharp
public static T Nearest <T> ([NotNull] this Transform position, [NotNull] IEnumerable<T> targets, out float distance) where T : Component
~~~

The nearest instance to a position.

~~~csharp
public static GameObject Nearest ([NotNull] this Transform position, [NotNull] IEnumerable<GameObject> targets, out float distance)
~~~

The nearest instance to a position.

~~~csharp
public static Vector2 Nearest ([NotNull] this Component position, [NotNull] IEnumerable<Vector2> targets, out float distance)
~~~

The nearest instance to a position.

~~~csharp
public static Vector3 Nearest ([NotNull] this Component position, [NotNull] IEnumerable<Vector3> targets, out float distance)
~~~

The nearest instance to a position.

~~~csharp
public static Transform Nearest ([NotNull] this Component position, [NotNull] IEnumerable<Transform> targets, out float distance)
~~~

The nearest instance to a position.

~~~csharp
public static T Nearest <T> ([NotNull] this Component position, [NotNull] IEnumerable<T> targets, out float distance) where T : Component
~~~

The nearest instance to a position.

~~~csharp
public static GameObject Nearest ([NotNull] this Component position, [NotNull] IEnumerable<GameObject> targets, out float distance)
~~~

The nearest instance to a position.

~~~csharp
public static Vector2 Nearest ([NotNull] this GameObject position, [NotNull] IEnumerable<Vector2> targets, out float distance)
~~~

The nearest instance to a position.

~~~csharp
public static Vector3 Nearest ([NotNull] this GameObject position, [NotNull] IEnumerable<Vector3> targets, out float distance)
~~~

The nearest instance to a position.

~~~csharp
public static Transform Nearest ([NotNull] this GameObject position, [NotNull] IEnumerable<Transform> targets, out float distance)
~~~

The nearest instance to a position.

~~~csharp
public static T Nearest <T> ([NotNull] this GameObject position, [NotNull] IEnumerable<T> targets, out float distance) where T : Component
~~~

The nearest instance to a position.

~~~csharp
public static GameObject Nearest ([NotNull] this GameObject position, [NotNull] IEnumerable<GameObject> targets, out float distance)
~~~

The nearest instance to a position.
