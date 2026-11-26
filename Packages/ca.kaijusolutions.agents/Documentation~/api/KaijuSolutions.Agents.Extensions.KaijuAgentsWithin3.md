# KaijuAgentsWithin3

Extension methods to see if points are within a given distance of each other along all three axes. These methods are inclusive of the distance to check. Any Vector2 values will be expanded via the KaijuAgentsExpand.Expand method.

~~~csharp
public static class KaijuAgentsWithin3
~~~

[Package source](../../Runtime/Extensions/KaijuAgentsWithin3.cs)

<a id="KaijuSolutions_Agents_Extensions_KaijuAgentsWithin3_Within3"></a>

### Within3

~~~csharp
public static bool Within3 (this Vector2 self, Vector3 other, float distance)
~~~

If this is within a distance to another position.

~~~csharp
public static bool Within3 (this Vector2 self, [NotNull] Transform other, float distance)
~~~

If this is within a distance to another position.

~~~csharp
public static bool Within3 (this Vector2 self, [NotNull] Component other, float distance)
~~~

If this is within a distance to another position.

~~~csharp
public static bool Within3 (this Vector2 self, [NotNull] GameObject other, float distance)
~~~

If this is within a distance to another position.

~~~csharp
public static bool Within3 (this Vector3 self, Vector2 other, float distance)
~~~

If this is within a distance to another position.

~~~csharp
public static bool Within3 (this Vector3 self, Vector3 other, float distance)
~~~

If this is within a distance to another position.

~~~csharp
public static bool Within3 (this Vector3 self, [NotNull] Transform other, float distance)
~~~

If this is within a distance to another position.

~~~csharp
public static bool Within3 (this Vector3 self, [NotNull] Component other, float distance)
~~~

If this is within a distance to another position.

~~~csharp
public static bool Within3 (this Vector3 self, [NotNull] GameObject other, float distance)
~~~

If this is within a distance to another position.

~~~csharp
public static bool Within3 ([NotNull] this Transform self, Vector2 other, float distance)
~~~

If this is within a distance to another position.

~~~csharp
public static bool Within3 ([NotNull] this Transform self, Vector3 other, float distance)
~~~

If this is within a distance to another position.

~~~csharp
public static bool Within3 ([NotNull] this Transform self, [NotNull] Transform other, float distance)
~~~

If this is within a distance to another position.

~~~csharp
public static bool Within3 ([NotNull] this Transform self, [NotNull] Component other, float distance)
~~~

If this is within a distance to another position.

~~~csharp
public static bool Within3 ([NotNull] this Transform self, [NotNull] GameObject other, float distance)
~~~

If this is within a distance to another position.

~~~csharp
public static bool Within3 ([NotNull] this Component self, Vector2 other, float distance)
~~~

If this is within a distance to another position.

~~~csharp
public static bool Within3 ([NotNull] this Component self, Vector3 other, float distance)
~~~

If this is within a distance to another position.

~~~csharp
public static bool Within3 ([NotNull] this Component self, [NotNull] Transform other, float distance)
~~~

If this is within a distance to another position.

~~~csharp
public static bool Within3 ([NotNull] this Component self, [NotNull] Component other, float distance)
~~~

If this is within a distance to another position.

~~~csharp
public static bool Within3 ([NotNull] this Component self, [NotNull] GameObject other, float distance)
~~~

If this is within a distance to another position.

~~~csharp
public static bool Within3 ([NotNull] this GameObject self, Vector2 other, float distance)
~~~

If this is within a distance to another position.

~~~csharp
public static bool Within3 ([NotNull] this GameObject self, Vector3 other, float distance)
~~~

If this is within a distance to another position.

~~~csharp
public static bool Within3 ([NotNull] this GameObject self, [NotNull] Transform other, float distance)
~~~

If this is within a distance to another position.

~~~csharp
public static bool Within3 ([NotNull] this GameObject self, [NotNull] Component other, float distance)
~~~

If this is within a distance to another position.

~~~csharp
public static bool Within3 ([NotNull] this GameObject self, [NotNull] GameObject other, float distance)
~~~

If this is within a distance to another position.
