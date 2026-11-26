# KaijuAgentsVelocity

Extension methods to get the velocity at which an object is travelling along the X and Z axes. Methods without a delta time value will use Time.deltaTime. All three-dimensional vectors will be flattened via methods in KaijuAgentsFlatten.

~~~csharp
public static class KaijuAgentsVelocity
~~~

[Package source](../../Runtime/Extensions/KaijuAgentsVelocity.cs)

<a id="KaijuSolutions_Agents_Extensions_KaijuAgentsVelocity_Velocity"></a>

### Velocity

~~~csharp
public static Vector2 Velocity (this Vector2 current, Vector2 previous, float delta)
~~~

The current velocity based on the time it took to move from a previous position.

~~~csharp
public static Vector2 Velocity (this Vector2 current, Vector2 previous)
~~~

The current velocity based on the time it took to move from a previous position.

~~~csharp
public static Vector2 Velocity (this Vector2 current, Vector3 previous, float delta)
~~~

The current velocity based on the time it took to move from a previous position.

~~~csharp
public static Vector2 Velocity (this Vector2 current, Vector3 previous)
~~~

The current velocity based on the time it took to move from a previous position.

~~~csharp
public static Vector2 Velocity (this Vector2 current, [NotNull] Transform previous, float delta)
~~~

The current velocity based on the time it took to move from a previous position.

~~~csharp
public static Vector2 Velocity (this Vector2 current, [NotNull] Transform previous)
~~~

The current velocity based on the time it took to move from a previous position.

~~~csharp
public static Vector2 Velocity (this Vector2 current, [NotNull] Component previous, float delta)
~~~

The current velocity based on the time it took to move from a previous position.

~~~csharp
public static Vector2 Velocity (this Vector2 current, [NotNull] Component previous)
~~~

The current velocity based on the time it took to move from a previous position.

~~~csharp
public static Vector2 Velocity (this Vector2 current, [NotNull] GameObject previous, float delta)
~~~

The current velocity based on the time it took to move from a previous position.

~~~csharp
public static Vector2 Velocity (this Vector2 current, [NotNull] GameObject previous)
~~~

The current velocity based on the time it took to move from a previous position.

~~~csharp
public static Vector2 Velocity (this Vector3 current, Vector2 previous, float delta)
~~~

The current velocity based on the time it took to move from a previous position.

~~~csharp
public static Vector2 Velocity (this Vector3 current, Vector2 previous)
~~~

The current velocity based on the time it took to move from a previous position.

~~~csharp
public static Vector2 Velocity (this Vector3 current, Vector3 previous, float delta)
~~~

The current velocity based on the time it took to move from a previous position.

~~~csharp
public static Vector2 Velocity (this Vector3 current, Vector3 previous)
~~~

The current velocity based on the time it took to move from a previous position.

~~~csharp
public static Vector2 Velocity (this Vector3 current, [NotNull] Transform previous, float delta)
~~~

The current velocity based on the time it took to move from a previous position.

~~~csharp
public static Vector2 Velocity (this Vector3 current, [NotNull] Transform previous)
~~~

The current velocity based on the time it took to move from a previous position.

~~~csharp
public static Vector2 Velocity (this Vector3 current, [NotNull] Component previous, float delta)
~~~

The current velocity based on the time it took to move from a previous position.

~~~csharp
public static Vector2 Velocity (this Vector3 current, [NotNull] Component previous)
~~~

The current velocity based on the time it took to move from a previous position.

~~~csharp
public static Vector2 Velocity (this Vector3 current, [NotNull] GameObject previous, float delta)
~~~

The current velocity based on the time it took to move from a previous position.

~~~csharp
public static Vector2 Velocity (this Vector3 current, [NotNull] GameObject previous)
~~~

The current velocity based on the time it took to move from a previous position.

~~~csharp
public static Vector2 Velocity ([NotNull] this Transform current, Vector2 previous, float delta)
~~~

The current velocity based on the time it took to move from a previous position.

~~~csharp
public static Vector2 Velocity ([NotNull] this Transform current, Vector2 previous)
~~~

The current velocity based on the time it took to move from a previous position.

~~~csharp
public static Vector2 Velocity ([NotNull] this Transform current, Vector3 previous, float delta)
~~~

The current velocity based on the time it took to move from a previous position.

~~~csharp
public static Vector2 Velocity ([NotNull] this Transform current, Vector3 previous)
~~~

The current velocity based on the time it took to move from a previous position.

~~~csharp
public static Vector2 Velocity ([NotNull] this Transform current, [NotNull] Transform previous, float delta)
~~~

The current velocity based on the time it took to move from a previous position.

~~~csharp
public static Vector2 Velocity ([NotNull] this Transform current, [NotNull] Transform previous)
~~~

The current velocity based on the time it took to move from a previous position.

~~~csharp
public static Vector2 Velocity ([NotNull] this Transform current, [NotNull] Component previous, float delta)
~~~

The current velocity based on the time it took to move from a previous position.

~~~csharp
public static Vector2 Velocity ([NotNull] this Transform current, [NotNull] Component previous)
~~~

The current velocity based on the time it took to move from a previous position.

~~~csharp
public static Vector2 Velocity ([NotNull] this Transform current, [NotNull] GameObject previous, float delta)
~~~

The current velocity based on the time it took to move from a previous position.

~~~csharp
public static Vector2 Velocity ([NotNull] this Transform current, [NotNull] GameObject previous)
~~~

The current velocity based on the time it took to move from a previous position.

~~~csharp
public static Vector2 Velocity ([NotNull] this Component current, Vector2 previous, float delta)
~~~

The current velocity based on the time it took to move from a previous position.

~~~csharp
public static Vector2 Velocity ([NotNull] this Component current, Vector2 previous)
~~~

The current velocity based on the time it took to move from a previous position.

~~~csharp
public static Vector2 Velocity ([NotNull] this Component current, Vector3 previous, float delta)
~~~

The current velocity based on the time it took to move from a previous position.

~~~csharp
public static Vector2 Velocity ([NotNull] this Component current, Vector3 previous)
~~~

The current velocity based on the time it took to move from a previous position.

~~~csharp
public static Vector2 Velocity ([NotNull] this Component current, [NotNull] Transform previous, float delta)
~~~

The current velocity based on the time it took to move from a previous position.

~~~csharp
public static Vector2 Velocity ([NotNull] this Component current, [NotNull] Transform previous)
~~~

The current velocity based on the time it took to move from a previous position.

~~~csharp
public static Vector2 Velocity ([NotNull] this Component current, [NotNull] Component previous, float delta)
~~~

The current velocity based on the time it took to move from a previous position.

~~~csharp
public static Vector2 Velocity ([NotNull] this Component current, [NotNull] Component previous)
~~~

The current velocity based on the time it took to move from a previous position.

~~~csharp
public static Vector2 Velocity ([NotNull] this Component current, [NotNull] GameObject previous, float delta)
~~~

The current velocity based on the time it took to move from a previous position.

~~~csharp
public static Vector2 Velocity ([NotNull] this Component current, [NotNull] GameObject previous)
~~~

The current velocity based on the time it took to move from a previous position.

~~~csharp
public static Vector2 Velocity ([NotNull] this GameObject current, Vector2 previous, float delta)
~~~

The current velocity based on the time it took to move from a previous position.

~~~csharp
public static Vector2 Velocity ([NotNull] this GameObject current, Vector2 previous)
~~~

The current velocity based on the time it took to move from a previous position.

~~~csharp
public static Vector2 Velocity ([NotNull] this GameObject current, Vector3 previous, float delta)
~~~

The current velocity based on the time it took to move from a previous position.

~~~csharp
public static Vector2 Velocity ([NotNull] this GameObject current, Vector3 previous)
~~~

The current velocity based on the time it took to move from a previous position.

~~~csharp
public static Vector2 Velocity ([NotNull] this GameObject current, [NotNull] Transform previous, float delta)
~~~

The current velocity based on the time it took to move from a previous position.

~~~csharp
public static Vector2 Velocity ([NotNull] this GameObject current, [NotNull] Transform previous)
~~~

The current velocity based on the time it took to move from a previous position.

~~~csharp
public static Vector2 Velocity ([NotNull] this GameObject current, [NotNull] Component previous, float delta)
~~~

The current velocity based on the time it took to move from a previous position.

~~~csharp
public static Vector2 Velocity ([NotNull] this GameObject current, [NotNull] Component previous)
~~~

The current velocity based on the time it took to move from a previous position.

~~~csharp
public static Vector2 Velocity ([NotNull] this GameObject current, [NotNull] GameObject previous, float delta)
~~~

The current velocity based on the time it took to move from a previous position.

~~~csharp
public static Vector2 Velocity ([NotNull] this GameObject current, [NotNull] GameObject previous)
~~~

The current velocity based on the time it took to move from a previous position.
