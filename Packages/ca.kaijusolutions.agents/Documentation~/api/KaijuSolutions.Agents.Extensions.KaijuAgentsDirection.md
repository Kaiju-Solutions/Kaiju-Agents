# KaijuAgentsDirection

Extension methods to get the direction along the X and Z axes from one position to another. All three-dimensional vectors will be flattened via methods in KaijuAgentsFlatten.

~~~csharp
public static class KaijuAgentsDirection
~~~

[Package source](../../Runtime/Extensions/KaijuAgentsDirection.cs)

<a id="KaijuSolutions_Agents_Extensions_KaijuAgentsDirection_Direction"></a>

### Direction

~~~csharp
public static Vector2 Direction (this Vector2 self, Vector2 other)
~~~

The direction from this position to another position.

~~~csharp
public static Vector2 Direction (this Vector2 self, Vector3 other)
~~~

The direction from this position to another position.

~~~csharp
public static Vector2 Direction (this Vector2 self, [NotNull] Transform other)
~~~

The direction from this position to another position.

~~~csharp
public static Vector2 Direction (this Vector2 self, [NotNull] Component other)
~~~

The direction from this position to another position.

~~~csharp
public static Vector2 Direction (this Vector2 self, [NotNull] GameObject other)
~~~

The direction from this position to another position.

~~~csharp
public static Vector2 Direction (this Vector3 self, Vector2 other)
~~~

The direction from this position to another position.

~~~csharp
public static Vector2 Direction (this Vector3 self, Vector3 other)
~~~

The direction from this position to another position.

~~~csharp
public static Vector2 Direction (this Vector3 self, [NotNull] Transform other)
~~~

The direction from this position to another position.

~~~csharp
public static Vector2 Direction (this Vector3 self, [NotNull] Component other)
~~~

The direction from this position to another position.

~~~csharp
public static Vector2 Direction (this Vector3 self, [NotNull] GameObject other)
~~~

The direction from this position to another position.

~~~csharp
public static Vector2 Direction ([NotNull] this Transform self, Vector2 other)
~~~

The direction from this position to another position.

~~~csharp
public static Vector2 Direction ([NotNull] this Transform self, Vector3 other)
~~~

The direction from this position to another position.

~~~csharp
public static Vector2 Direction ([NotNull] this Transform self, [NotNull] Transform other)
~~~

The direction from this position to another position.

~~~csharp
public static Vector2 Direction ([NotNull] this Transform self, [NotNull] Component other)
~~~

The direction from this position to another position.

~~~csharp
public static Vector2 Direction ([NotNull] this Transform self, [NotNull] GameObject other)
~~~

The direction from this position to another position.

~~~csharp
public static Vector2 Direction ([NotNull] this Component self, Vector2 other)
~~~

The direction from this position to another position.

~~~csharp
public static Vector2 Direction ([NotNull] this Component self, Vector3 other)
~~~

The direction from this position to another position.

~~~csharp
public static Vector2 Direction ([NotNull] this Component self, [NotNull] Transform other)
~~~

The direction from this position to another position.

~~~csharp
public static Vector2 Direction ([NotNull] this Component self, [NotNull] Component other)
~~~

The direction from this position to another position.

~~~csharp
public static Vector2 Direction ([NotNull] this Component self, [NotNull] GameObject other)
~~~

The direction from this position to another position.

~~~csharp
public static Vector2 Direction ([NotNull] this GameObject self, Vector2 other)
~~~

The direction from this position to another position.

~~~csharp
public static Vector2 Direction ([NotNull] this GameObject self, Vector3 other)
~~~

The direction from this position to another position.

~~~csharp
public static Vector2 Direction ([NotNull] this GameObject self, [NotNull] Transform other)
~~~

The direction from this position to another position.

~~~csharp
public static Vector2 Direction ([NotNull] this GameObject self, [NotNull] Component other)
~~~

The direction from this position to another position.

~~~csharp
public static Vector2 Direction ([NotNull] this GameObject self, [NotNull] GameObject other)
~~~

The direction from this position to another position.
