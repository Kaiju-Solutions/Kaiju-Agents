# KaijuAgentsSpeed

Extension methods to get the speed at which an object is travelling along the X and Z axes. Methods without a delta time value will use Time.deltaTime. All three-dimensional vectors will be flattened via methods in KaijuAgentsFlatten.

~~~csharp
public static class KaijuAgentsSpeed
~~~

[Package source](../../Runtime/Extensions/KaijuAgentsSpeed.cs)

<a id="KaijuSolutions_Agents_Extensions_KaijuAgentsSpeed_Speed"></a>

### Speed

~~~csharp
public static float Speed (this Vector2 current, Vector2 previous, float delta)
~~~

The current speed based on the time it took to move from a previous position.

~~~csharp
public static float Speed (this Vector2 current, Vector2 previous)
~~~

The current speed based on the time it took to move from a previous position.

~~~csharp
public static float Speed (this Vector2 current, Vector3 previous, float delta)
~~~

The current speed based on the time it took to move from a previous position.

~~~csharp
public static float Speed (this Vector2 current, Vector3 previous)
~~~

The current speed based on the time it took to move from a previous position.

~~~csharp
public static float Speed (this Vector2 current, [NotNull] Transform previous, float delta)
~~~

The current speed based on the time it took to move from a previous position.

~~~csharp
public static float Speed (this Vector2 current, [NotNull] Transform previous)
~~~

The current speed based on the time it took to move from a previous position.

~~~csharp
public static float Speed (this Vector2 current, [NotNull] Component previous, float delta)
~~~

The current speed based on the time it took to move from a previous position.

~~~csharp
public static float Speed (this Vector2 current, [NotNull] Component previous)
~~~

The current speed based on the time it took to move from a previous position.

~~~csharp
public static float Speed (this Vector2 current, [NotNull] GameObject previous, float delta)
~~~

The current speed based on the time it took to move from a previous position.

~~~csharp
public static float Speed (this Vector2 current, [NotNull] GameObject previous)
~~~

The current speed based on the time it took to move from a previous position.

~~~csharp
public static float Speed (this Vector3 current, Vector2 previous, float delta)
~~~

The current speed based on the time it took to move from a previous position.

~~~csharp
public static float Speed (this Vector3 current, Vector2 previous)
~~~

The current speed based on the time it took to move from a previous position.

~~~csharp
public static float Speed (this Vector3 current, Vector3 previous, float delta)
~~~

The current speed based on the time it took to move from a previous position.

~~~csharp
public static float Speed (this Vector3 current, Vector3 previous)
~~~

The current speed based on the time it took to move from a previous position.

~~~csharp
public static float Speed (this Vector3 current, [NotNull] Transform previous, float delta)
~~~

The current speed based on the time it took to move from a previous position.

~~~csharp
public static float Speed (this Vector3 current, [NotNull] Transform previous)
~~~

The current speed based on the time it took to move from a previous position.

~~~csharp
public static float Speed (this Vector3 current, [NotNull] Component previous, float delta)
~~~

The current speed based on the time it took to move from a previous position.

~~~csharp
public static float Speed (this Vector3 current, [NotNull] Component previous)
~~~

The current speed based on the time it took to move from a previous position.

~~~csharp
public static float Speed (this Vector3 current, [NotNull] GameObject previous, float delta)
~~~

The current speed based on the time it took to move from a previous position.

~~~csharp
public static float Speed (this Vector3 current, [NotNull] GameObject previous)
~~~

The current speed based on the time it took to move from a previous position.

~~~csharp
public static float Speed ([NotNull] this Transform current, Vector2 previous, float delta)
~~~

The current speed based on the time it took to move from a previous position.

~~~csharp
public static float Speed ([NotNull] this Transform current, Vector2 previous)
~~~

The current speed based on the time it took to move from a previous position.

~~~csharp
public static float Speed ([NotNull] this Transform current, Vector3 previous, float delta)
~~~

The current speed based on the time it took to move from a previous position.

~~~csharp
public static float Speed ([NotNull] this Transform current, Vector3 previous)
~~~

The current speed based on the time it took to move from a previous position.

~~~csharp
public static float Speed ([NotNull] this Transform current, [NotNull] Transform previous, float delta)
~~~

The current speed based on the time it took to move from a previous position.

~~~csharp
public static float Speed ([NotNull] this Transform current, [NotNull] Transform previous)
~~~

The current speed based on the time it took to move from a previous position.

~~~csharp
public static float Speed ([NotNull] this Transform current, [NotNull] Component previous, float delta)
~~~

The current speed based on the time it took to move from a previous position.

~~~csharp
public static float Speed ([NotNull] this Transform current, [NotNull] Component previous)
~~~

The current speed based on the time it took to move from a previous position.

~~~csharp
public static float Speed ([NotNull] this Transform current, [NotNull] GameObject previous, float delta)
~~~

The current speed based on the time it took to move from a previous position.

~~~csharp
public static float Speed ([NotNull] this Transform current, [NotNull] GameObject previous)
~~~

The current speed based on the time it took to move from a previous position.

~~~csharp
public static float Speed ([NotNull] this Component current, Vector2 previous, float delta)
~~~

The current speed based on the time it took to move from a previous position.

~~~csharp
public static float Speed ([NotNull] this Component current, Vector2 previous)
~~~

The current speed based on the time it took to move from a previous position.

~~~csharp
public static float Speed ([NotNull] this Component current, Vector3 previous, float delta)
~~~

The current speed based on the time it took to move from a previous position.

~~~csharp
public static float Speed ([NotNull] this Component current, Vector3 previous)
~~~

The current speed based on the time it took to move from a previous position.

~~~csharp
public static float Speed ([NotNull] this Component current, [NotNull] Transform previous, float delta)
~~~

The current speed based on the time it took to move from a previous position.

~~~csharp
public static float Speed ([NotNull] this Component current, [NotNull] Transform previous)
~~~

The current speed based on the time it took to move from a previous position.

~~~csharp
public static float Speed ([NotNull] this Component current, [NotNull] Component previous, float delta)
~~~

The current speed based on the time it took to move from a previous position.

~~~csharp
public static float Speed ([NotNull] this Component current, [NotNull] Component previous)
~~~

The current speed based on the time it took to move from a previous position.

~~~csharp
public static float Speed ([NotNull] this Component current, [NotNull] GameObject previous, float delta)
~~~

The current speed based on the time it took to move from a previous position.

~~~csharp
public static float Speed ([NotNull] this Component current, [NotNull] GameObject previous)
~~~

The current speed based on the time it took to move from a previous position.

~~~csharp
public static float Speed ([NotNull] this GameObject current, Vector2 previous, float delta)
~~~

The current speed based on the time it took to move from a previous position.

~~~csharp
public static float Speed ([NotNull] this GameObject current, Vector2 previous)
~~~

The current speed based on the time it took to move from a previous position.

~~~csharp
public static float Speed ([NotNull] this GameObject current, Vector3 previous, float delta)
~~~

The current speed based on the time it took to move from a previous position.

~~~csharp
public static float Speed ([NotNull] this GameObject current, Vector3 previous)
~~~

The current speed based on the time it took to move from a previous position.

~~~csharp
public static float Speed ([NotNull] this GameObject current, [NotNull] Transform previous, float delta)
~~~

The current speed based on the time it took to move from a previous position.

~~~csharp
public static float Speed ([NotNull] this GameObject current, [NotNull] Transform previous)
~~~

The current speed based on the time it took to move from a previous position.

~~~csharp
public static float Speed ([NotNull] this GameObject current, [NotNull] Component previous, float delta)
~~~

The current speed based on the time it took to move from a previous position.

~~~csharp
public static float Speed ([NotNull] this GameObject current, [NotNull] Component previous)
~~~

The current speed based on the time it took to move from a previous position.

~~~csharp
public static float Speed ([NotNull] this GameObject current, [NotNull] GameObject previous, float delta)
~~~

The current speed based on the time it took to move from a previous position.

~~~csharp
public static float Speed ([NotNull] this GameObject current, [NotNull] GameObject previous)
~~~

The current speed based on the time it took to move from a previous position.
