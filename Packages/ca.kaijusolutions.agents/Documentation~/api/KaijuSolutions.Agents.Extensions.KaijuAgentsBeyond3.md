# KaijuAgentsBeyond3

Extension methods to see if points are beyond a given distance of each other along all three axes. These methods are inclusive of the distance to check. Any Vector2 values will be expanded via the KaijuAgentsExpand.Expand method.

~~~csharp
public static class KaijuAgentsBeyond3
~~~

[Package source](../../Runtime/Extensions/KaijuAgentsBeyond3.cs)

<a id="KaijuSolutions_Agents_Extensions_KaijuAgentsBeyond3_Beyond3"></a>

### Beyond3

~~~csharp
public static bool Beyond3 (this Vector2 self, Vector3 other, float distance)
~~~

If this is beyond a distance to another position.

~~~csharp
public static bool Beyond3 (this Vector2 self, [NotNull] Transform other, float distance)
~~~

If this is beyond a distance to another position.

~~~csharp
public static bool Beyond3 (this Vector2 self, [NotNull] Component other, float distance)
~~~

If this is beyond a distance to another position.

~~~csharp
public static bool Beyond3 (this Vector2 self, [NotNull] GameObject other, float distance)
~~~

If this is beyond a distance to another position.

~~~csharp
public static bool Beyond3 (this Vector3 self, Vector2 other, float distance)
~~~

If this is beyond a distance to another position.

~~~csharp
public static bool Beyond3 (this Vector3 self, Vector3 other, float distance)
~~~

If this is beyond a distance to another position.

~~~csharp
public static bool Beyond3 (this Vector3 self, [NotNull] Transform other, float distance)
~~~

If this is beyond a distance to another position.

~~~csharp
public static bool Beyond3 (this Vector3 self, [NotNull] Component other, float distance)
~~~

If this is beyond a distance to another position.

~~~csharp
public static bool Beyond3 (this Vector3 self, [NotNull] GameObject other, float distance)
~~~

If this is beyond a distance to another position.

~~~csharp
public static bool Beyond3 ([NotNull] this Transform self, Vector2 other, float distance)
~~~

If this is beyond a distance to another position.

~~~csharp
public static bool Beyond3 ([NotNull] this Transform self, Vector3 other, float distance)
~~~

If this is beyond a distance to another position.

~~~csharp
public static bool Beyond3 ([NotNull] this Transform self, [NotNull] Transform other, float distance)
~~~

If this is beyond a distance to another position.

~~~csharp
public static bool Beyond3 ([NotNull] this Transform self, [NotNull] Component other, float distance)
~~~

If this is beyond a distance to another position.

~~~csharp
public static bool Beyond3 ([NotNull] this Transform self, [NotNull] GameObject other, float distance)
~~~

If this is beyond a distance to another position.

~~~csharp
public static bool Beyond3 ([NotNull] this Component self, Vector2 other, float distance)
~~~

If this is beyond a distance to another position.

~~~csharp
public static bool Beyond3 ([NotNull] this Component self, Vector3 other, float distance)
~~~

If this is beyond a distance to another position.

~~~csharp
public static bool Beyond3 ([NotNull] this Component self, [NotNull] Transform other, float distance)
~~~

If this is beyond a distance to another position.

~~~csharp
public static bool Beyond3 ([NotNull] this Component self, [NotNull] Component other, float distance)
~~~

If this is beyond a distance to another position.

~~~csharp
public static bool Beyond3 ([NotNull] this Component self, [NotNull] GameObject other, float distance)
~~~

If this is beyond a distance to another position.

~~~csharp
public static bool Beyond3 ([NotNull] this GameObject self, Vector2 other, float distance)
~~~

If this is beyond a distance to another position.

~~~csharp
public static bool Beyond3 ([NotNull] this GameObject self, Vector3 other, float distance)
~~~

If this is beyond a distance to another position.

~~~csharp
public static bool Beyond3 ([NotNull] this GameObject self, [NotNull] Transform other, float distance)
~~~

If this is beyond a distance to another position.

~~~csharp
public static bool Beyond3 ([NotNull] this GameObject self, [NotNull] Component other, float distance)
~~~

If this is beyond a distance to another position.

~~~csharp
public static bool Beyond3 ([NotNull] this GameObject self, [NotNull] GameObject other, float distance)
~~~

If this is beyond a distance to another position.
