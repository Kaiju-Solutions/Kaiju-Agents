# KaijuAgentsBetween

Extension methods to see if points are between two given distances of each other along the X and Z axes. These methods are inclusive of the distances to check. All three-dimensional vectors will be flattened via methods in KaijuAgentsFlatten.

~~~csharp
public static class KaijuAgentsBetween
~~~

[Package source](../../Runtime/Extensions/KaijuAgentsBetween.cs)

<a id="KaijuSolutions_Agents_Extensions_KaijuAgentsBetween_Between"></a>

### Between

~~~csharp
public static bool Between (this Vector2 self, Vector2 other, float minimum, float maximum)
~~~

If this is between two distances to another position.

~~~csharp
public static bool Between (this Vector2 self, Vector3 other, float minimum, float maximum)
~~~

If this is between two distances to another position.

~~~csharp
public static bool Between (this Vector2 self, [NotNull] Transform other, float minimum, float maximum)
~~~

If this is between two distances to another position.

~~~csharp
public static bool Between (this Vector2 self, [NotNull] Component other, float minimum, float maximum)
~~~

If this is between two distances to another position.

~~~csharp
public static bool Between (this Vector2 self, [NotNull] GameObject other, float minimum, float maximum)
~~~

If this is between two distances to another position.

~~~csharp
public static bool Between (this Vector3 self, Vector2 other, float minimum, float maximum)
~~~

If this is between two distances to another position.

~~~csharp
public static bool Between (this Vector3 self, Vector3 other, float minimum, float maximum)
~~~

If this is between two distances to another position.

~~~csharp
public static bool Between (this Vector3 self, [NotNull] Transform other, float minimum, float maximum)
~~~

If this is between two distances to another position.

~~~csharp
public static bool Between (this Vector3 self, [NotNull] Component other, float minimum, float maximum)
~~~

If this is between two distances to another position.

~~~csharp
public static bool Between (this Vector3 self, [NotNull] GameObject other, float minimum, float maximum)
~~~

If this is between two distances to another position.

~~~csharp
public static bool Between ([NotNull] this Transform self, Vector2 other, float minimum, float maximum)
~~~

If this is between two distances to another position.

~~~csharp
public static bool Between ([NotNull] this Transform self, Vector3 other, float minimum, float maximum)
~~~

If this is between two distances to another position.

~~~csharp
public static bool Between ([NotNull] this Transform self, [NotNull] Transform other, float minimum, float maximum)
~~~

If this is between two distances to another position.

~~~csharp
public static bool Between ([NotNull] this Transform self, [NotNull] Component other, float minimum, float maximum)
~~~

If this is between two distances to another position.

~~~csharp
public static bool Between ([NotNull] this Transform self, [NotNull] GameObject other, float minimum, float maximum)
~~~

If this is between two distances to another position.

~~~csharp
public static bool Between ([NotNull] this Component self, Vector2 other, float minimum, float maximum)
~~~

If this is between two distances to another position.

~~~csharp
public static bool Between ([NotNull] this Component self, Vector3 other, float minimum, float maximum)
~~~

If this is between two distances to another position.

~~~csharp
public static bool Between ([NotNull] this Component self, [NotNull] Transform other, float minimum, float maximum)
~~~

If this is between two distances to another position.

~~~csharp
public static bool Between ([NotNull] this Component self, [NotNull] Component other, float minimum, float maximum)
~~~

If this is between two distances to another position.

~~~csharp
public static bool Between ([NotNull] this Component self, [NotNull] GameObject other, float minimum, float maximum)
~~~

If this is between two distances to another position.

~~~csharp
public static bool Between ([NotNull] this GameObject self, Vector2 other, float minimum, float maximum)
~~~

If this is between two distances to another position.

~~~csharp
public static bool Between ([NotNull] this GameObject self, Vector3 other, float minimum, float maximum)
~~~

If this is between two distances to another position.

~~~csharp
public static bool Between ([NotNull] this GameObject self, [NotNull] Transform other, float minimum, float maximum)
~~~

If this is between two distances to another position.

~~~csharp
public static bool Between ([NotNull] this GameObject self, [NotNull] Component other, float minimum, float maximum)
~~~

If this is between two distances to another position.

~~~csharp
public static bool Between ([NotNull] this GameObject self, [NotNull] GameObject other, float minimum, float maximum)
~~~

If this is between two distances to another position.
