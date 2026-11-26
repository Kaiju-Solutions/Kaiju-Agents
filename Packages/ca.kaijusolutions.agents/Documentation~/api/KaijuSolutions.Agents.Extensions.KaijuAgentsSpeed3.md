# KaijuAgentsSpeed3

Extension methods to get the speed at which an object is travelling along all three axes. Methods without a delta time value will use Time.deltaTime. Any Vector2 values will be expanded via the KaijuAgentsExpand.Expand method.

~~~csharp
public static class KaijuAgentsSpeed3
~~~

[Package source](../../Runtime/Extensions/KaijuAgentsSpeed3.cs)

<a id="KaijuSolutions_Agents_Extensions_KaijuAgentsSpeed3_Speed3"></a>

### Speed3

~~~csharp
public static float Speed3 (this Vector2 current, Vector3 previous, float delta)
~~~

The current speed based on the time it took to move from a previous position.

~~~csharp
public static float Speed3 (this Vector2 current, Vector3 previous)
~~~

The current speed based on the time it took to move from a previous position.

~~~csharp
public static float Speed3 (this Vector2 current, [NotNull] Transform previous, float delta)
~~~

The current speed based on the time it took to move from a previous position.

~~~csharp
public static float Speed3 (this Vector2 current, [NotNull] Transform previous)
~~~

The current speed based on the time it took to move from a previous position.

~~~csharp
public static float Speed3 (this Vector2 current, [NotNull] Component previous, float delta)
~~~

The current speed based on the time it took to move from a previous position.

~~~csharp
public static float Speed3 (this Vector2 current, [NotNull] Component previous)
~~~

The current speed based on the time it took to move from a previous position.

~~~csharp
public static float Speed3 (this Vector2 current, [NotNull] GameObject previous, float delta)
~~~

The current speed based on the time it took to move from a previous position.

~~~csharp
public static float Speed3 (this Vector2 current, [NotNull] GameObject previous)
~~~

The current speed based on the time it took to move from a previous position.

~~~csharp
public static float Speed3 (this Vector3 current, Vector2 previous, float delta)
~~~

The current speed based on the time it took to move from a previous position.

~~~csharp
public static float Speed3 (this Vector3 current, Vector2 previous)
~~~

The current speed based on the time it took to move from a previous position.

~~~csharp
public static float Speed3 (this Vector3 current, Vector3 previous, float delta)
~~~

The current speed based on the time it took to move from a previous position.

~~~csharp
public static float Speed3 (this Vector3 current, Vector3 previous)
~~~

The current speed based on the time it took to move from a previous position.

~~~csharp
public static float Speed3 (this Vector3 current, [NotNull] Transform previous, float delta)
~~~

The current speed based on the time it took to move from a previous position.

~~~csharp
public static float Speed3 (this Vector3 current, [NotNull] Transform previous)
~~~

The current speed based on the time it took to move from a previous position.

~~~csharp
public static float Speed3 (this Vector3 current, [NotNull] Component previous, float delta)
~~~

The current speed based on the time it took to move from a previous position.

~~~csharp
public static float Speed3 (this Vector3 current, [NotNull] Component previous)
~~~

The current speed based on the time it took to move from a previous position.

~~~csharp
public static float Speed3 (this Vector3 current, [NotNull] GameObject previous, float delta)
~~~

The current speed based on the time it took to move from a previous position.

~~~csharp
public static float Speed3 (this Vector3 current, [NotNull] GameObject previous)
~~~

The current speed based on the time it took to move from a previous position.

~~~csharp
public static float Speed3 ([NotNull] this Transform current, Vector2 previous, float delta)
~~~

The current speed based on the time it took to move from a previous position.

~~~csharp
public static float Speed3 ([NotNull] this Transform current, Vector2 previous)
~~~

The current speed based on the time it took to move from a previous position.

~~~csharp
public static float Speed3 ([NotNull] this Transform current, Vector3 previous, float delta)
~~~

The current speed based on the time it took to move from a previous position.

~~~csharp
public static float Speed3 ([NotNull] this Transform current, Vector3 previous)
~~~

The current speed based on the time it took to move from a previous position.

~~~csharp
public static float Speed3 ([NotNull] this Transform current, [NotNull] Transform previous, float delta)
~~~

The current speed based on the time it took to move from a previous position.

~~~csharp
public static float Speed3 ([NotNull] this Transform current, [NotNull] Transform previous)
~~~

The current speed based on the time it took to move from a previous position.

~~~csharp
public static float Speed3 ([NotNull] this Transform current, [NotNull] Component previous, float delta)
~~~

The current speed based on the time it took to move from a previous position.

~~~csharp
public static float Speed3 ([NotNull] this Transform current, [NotNull] Component previous)
~~~

The current speed based on the time it took to move from a previous position.

~~~csharp
public static float Speed3 ([NotNull] this Transform current, [NotNull] GameObject previous, float delta)
~~~

The current speed based on the time it took to move from a previous position.

~~~csharp
public static float Speed3 ([NotNull] this Transform current, [NotNull] GameObject previous)
~~~

The current speed based on the time it took to move from a previous position.

~~~csharp
public static float Speed3 ([NotNull] this Component current, Vector2 previous, float delta)
~~~

The current speed based on the time it took to move from a previous position.

~~~csharp
public static float Speed3 ([NotNull] this Component current, Vector2 previous)
~~~

The current speed based on the time it took to move from a previous position.

~~~csharp
public static float Speed3 ([NotNull] this Component current, Vector3 previous, float delta)
~~~

The current speed based on the time it took to move from a previous position.

~~~csharp
public static float Speed3 ([NotNull] this Component current, Vector3 previous)
~~~

The current speed based on the time it took to move from a previous position.

~~~csharp
public static float Speed3 ([NotNull] this Component current, [NotNull] Transform previous, float delta)
~~~

The current speed based on the time it took to move from a previous position.

~~~csharp
public static float Speed3 ([NotNull] this Component current, [NotNull] Transform previous)
~~~

The current speed based on the time it took to move from a previous position.

~~~csharp
public static float Speed3 ([NotNull] this Component current, [NotNull] Component previous, float delta)
~~~

The current speed based on the time it took to move from a previous position.

~~~csharp
public static float Speed3 ([NotNull] this Component current, [NotNull] Component previous)
~~~

The current speed based on the time it took to move from a previous position.

~~~csharp
public static float Speed3 ([NotNull] this Component current, [NotNull] GameObject previous, float delta)
~~~

The current speed based on the time it took to move from a previous position.

~~~csharp
public static float Speed3 ([NotNull] this Component current, [NotNull] GameObject previous)
~~~

The current speed based on the time it took to move from a previous position.

~~~csharp
public static float Speed3 ([NotNull] this GameObject current, Vector2 previous, float delta)
~~~

The current speed based on the time it took to move from a previous position.

~~~csharp
public static float Speed3 ([NotNull] this GameObject current, Vector2 previous)
~~~

The current speed based on the time it took to move from a previous position.

~~~csharp
public static float Speed3 ([NotNull] this GameObject current, Vector3 previous, float delta)
~~~

The current speed based on the time it took to move from a previous position.

~~~csharp
public static float Speed3 ([NotNull] this GameObject current, Vector3 previous)
~~~

The current speed based on the time it took to move from a previous position.

~~~csharp
public static float Speed3 ([NotNull] this GameObject current, [NotNull] Transform previous, float delta)
~~~

The current speed based on the time it took to move from a previous position.

~~~csharp
public static float Speed3 ([NotNull] this GameObject current, [NotNull] Transform previous)
~~~

The current speed based on the time it took to move from a previous position.

~~~csharp
public static float Speed3 ([NotNull] this GameObject current, [NotNull] Component previous, float delta)
~~~

The current speed based on the time it took to move from a previous position.

~~~csharp
public static float Speed3 ([NotNull] this GameObject current, [NotNull] Component previous)
~~~

The current speed based on the time it took to move from a previous position.

~~~csharp
public static float Speed3 ([NotNull] this GameObject current, [NotNull] GameObject previous, float delta)
~~~

The current speed based on the time it took to move from a previous position.

~~~csharp
public static float Speed3 ([NotNull] this GameObject current, [NotNull] GameObject previous)
~~~

The current speed based on the time it took to move from a previous position.
