# KaijuAgentsWithin

Extension methods to see if points are within a given distance of each other along the X and Z axes. These methods are inclusive of the distance to check. All three-dimensional vectors will be flattened via methods in KaijuAgentsFlatten.

~~~csharp
public static class KaijuAgentsWithin
~~~

[Package source](../../Runtime/Extensions/KaijuAgentsWithin.cs)

<a id="KaijuSolutions_Agents_Extensions_KaijuAgentsWithin_Within"></a>

### Within

~~~csharp
public static bool Within (this Vector2 self, Vector2 other, float distance)
~~~

If this is within a distance to another position.

~~~csharp
public static bool Within (this Vector2 self, Vector3 other, float distance)
~~~

If this is within a distance to another position.

~~~csharp
public static bool Within (this Vector2 self, [NotNull] Transform other, float distance)
~~~

If this is within a distance to another position.

~~~csharp
public static bool Within (this Vector2 self, [NotNull] Component other, float distance)
~~~

If this is within a distance to another position.

~~~csharp
public static bool Within (this Vector2 self, [NotNull] GameObject other, float distance)
~~~

If this is within a distance to another position.

~~~csharp
public static bool Within (this Vector3 self, Vector2 other, float distance)
~~~

If this is within a distance to another position.

~~~csharp
public static bool Within (this Vector3 self, Vector3 other, float distance)
~~~

If this is within a distance to another position.

~~~csharp
public static bool Within (this Vector3 self, [NotNull] Transform other, float distance)
~~~

If this is within a distance to another position.

~~~csharp
public static bool Within (this Vector3 self, [NotNull] Component other, float distance)
~~~

If this is within a distance to another position.

~~~csharp
public static bool Within (this Vector3 self, [NotNull] GameObject other, float distance)
~~~

If this is within a distance to another position.

~~~csharp
public static bool Within ([NotNull] this Transform self, Vector2 other, float distance)
~~~

If this is within a distance to another position.

~~~csharp
public static bool Within ([NotNull] this Transform self, Vector3 other, float distance)
~~~

If this is within a distance to another position.

~~~csharp
public static bool Within ([NotNull] this Transform self, [NotNull] Transform other, float distance)
~~~

If this is within a distance to another position.

~~~csharp
public static bool Within ([NotNull] this Transform self, [NotNull] Component other, float distance)
~~~

If this is within a distance to another position.

~~~csharp
public static bool Within ([NotNull] this Transform self, [NotNull] GameObject other, float distance)
~~~

If this is within a distance to another position.

~~~csharp
public static bool Within ([NotNull] this Component self, Vector2 other, float distance)
~~~

If this is within a distance to another position.

~~~csharp
public static bool Within ([NotNull] this Component self, Vector3 other, float distance)
~~~

If this is within a distance to another position.

~~~csharp
public static bool Within ([NotNull] this Component self, [NotNull] Transform other, float distance)
~~~

If this is within a distance to another position.

~~~csharp
public static bool Within ([NotNull] this Component self, [NotNull] Component other, float distance)
~~~

If this is within a distance to another position.

~~~csharp
public static bool Within ([NotNull] this Component self, [NotNull] GameObject other, float distance)
~~~

If this is within a distance to another position.

~~~csharp
public static bool Within ([NotNull] this GameObject self, Vector2 other, float distance)
~~~

If this is within a distance to another position.

~~~csharp
public static bool Within ([NotNull] this GameObject self, Vector3 other, float distance)
~~~

If this is within a distance to another position.

~~~csharp
public static bool Within ([NotNull] this GameObject self, [NotNull] Transform other, float distance)
~~~

If this is within a distance to another position.

~~~csharp
public static bool Within ([NotNull] this GameObject self, [NotNull] Component other, float distance)
~~~

If this is within a distance to another position.

~~~csharp
public static bool Within ([NotNull] this GameObject self, [NotNull] GameObject other, float distance)
~~~

If this is within a distance to another position.
