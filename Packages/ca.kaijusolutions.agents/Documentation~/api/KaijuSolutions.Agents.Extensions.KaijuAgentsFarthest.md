# KaijuAgentsFarthest

Extension methods to get the farthest object from a given position along the X and Z axes. All three-dimensional vectors will be flattened via methods in KaijuAgentsFlatten.

~~~csharp
public static class KaijuAgentsFarthest
~~~

[Package source](../../Runtime/Extensions/KaijuAgentsFarthest.cs)

<a id="KaijuSolutions_Agents_Extensions_KaijuAgentsFarthest_Farthest"></a>

### Farthest

~~~csharp
public static Vector2 Farthest (this Vector2 position, [NotNull] IEnumerable<Vector2> targets, out float distance)
~~~

The farthest instance from a position.

~~~csharp
public static Vector3 Farthest (this Vector2 position, [NotNull] IEnumerable<Vector3> targets, out float distance)
~~~

The farthest instance from a position.

~~~csharp
public static Transform Farthest (this Vector2 position, [NotNull] IEnumerable<Transform> targets, out float distance)
~~~

The farthest instance from a position.

~~~csharp
public static T Farthest <T> (this Vector2 position, [NotNull] IEnumerable<T> targets, out float distance) where T : Component
~~~

The farthest instance from a position.

~~~csharp
public static GameObject Farthest (this Vector2 position, [NotNull] IEnumerable<GameObject> targets, out float distance)
~~~

The farthest instance from a position.

~~~csharp
public static Vector2 Farthest (this Vector3 position, [NotNull] IEnumerable<Vector2> targets, out float distance)
~~~

The farthest instance from a position.

~~~csharp
public static Vector3 Farthest (this Vector3 position, [NotNull] IEnumerable<Vector3> targets, out float distance)
~~~

The farthest instance from a position.

~~~csharp
public static Transform Farthest (this Vector3 position, [NotNull] IEnumerable<Transform> targets, out float distance)
~~~

The farthest instance from a position.

~~~csharp
public static T Farthest <T> (this Vector3 position, [NotNull] IEnumerable<T> targets, out float distance) where T : Component
~~~

The farthest instance from a position.

~~~csharp
public static GameObject Farthest (this Vector3 position, [NotNull] IEnumerable<GameObject> targets, out float distance)
~~~

The farthest instance from a position.

~~~csharp
public static Vector2 Farthest ([NotNull] this Transform position, [NotNull] IEnumerable<Vector2> targets, out float distance)
~~~

The farthest instance from a position.

~~~csharp
public static Vector3 Farthest ([NotNull] this Transform position, [NotNull] IEnumerable<Vector3> targets, out float distance)
~~~

The farthest instance from a position.

~~~csharp
public static Transform Farthest ([NotNull] this Transform position, [NotNull] IEnumerable<Transform> targets, out float distance)
~~~

The farthest instance from a position.

~~~csharp
public static T Farthest <T> ([NotNull] this Transform position, [NotNull] IEnumerable<T> targets, out float distance) where T : Component
~~~

The farthest instance from a position.

~~~csharp
public static GameObject Farthest ([NotNull] this Transform position, [NotNull] IEnumerable<GameObject> targets, out float distance)
~~~

The farthest instance from a position.

~~~csharp
public static Vector2 Farthest ([NotNull] this Component position, [NotNull] IEnumerable<Vector2> targets, out float distance)
~~~

The farthest instance from a position.

~~~csharp
public static Vector3 Farthest ([NotNull] this Component position, [NotNull] IEnumerable<Vector3> targets, out float distance)
~~~

The farthest instance from a position.

~~~csharp
public static Transform Farthest ([NotNull] this Component position, [NotNull] IEnumerable<Transform> targets, out float distance)
~~~

The farthest instance from a position.

~~~csharp
public static T Farthest <T> ([NotNull] this Component position, [NotNull] IEnumerable<T> targets, out float distance) where T : Component
~~~

The farthest instance from a position.

~~~csharp
public static GameObject Farthest ([NotNull] this Component position, [NotNull] IEnumerable<GameObject> targets, out float distance)
~~~

The farthest instance from a position.

~~~csharp
public static Vector2 Farthest ([NotNull] this GameObject position, [NotNull] IEnumerable<Vector2> targets, out float distance)
~~~

The farthest instance from a position.

~~~csharp
public static Vector3 Farthest ([NotNull] this GameObject position, [NotNull] IEnumerable<Vector3> targets, out float distance)
~~~

The farthest instance from a position.

~~~csharp
public static Transform Farthest ([NotNull] this GameObject position, [NotNull] IEnumerable<Transform> targets, out float distance)
~~~

The farthest instance from a position.

~~~csharp
public static T Farthest <T> ([NotNull] this GameObject position, [NotNull] IEnumerable<T> targets, out float distance) where T : Component
~~~

The farthest instance from a position.

~~~csharp
public static GameObject Farthest ([NotNull] this GameObject position, [NotNull] IEnumerable<GameObject> targets, out float distance)
~~~

The farthest instance from a position.
