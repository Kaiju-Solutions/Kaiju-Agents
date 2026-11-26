# KaijuAgentsBeyond

Extension methods to see if points are beyond a given distance of each other along the X and Z axes. These methods are inclusive of the distance to check. All three-dimensional vectors will be flattened via methods in KaijuAgentsFlatten.

~~~csharp
public static class KaijuAgentsBeyond
~~~

[Package source](../../Runtime/Extensions/KaijuAgentsBeyond.cs)

<a id="KaijuSolutions_Agents_Extensions_KaijuAgentsBeyond_Beyond"></a>

### Beyond

~~~csharp
public static bool Beyond (this Vector2 self, Vector2 other, float distance)
~~~

If this is beyond a distance to another position.

~~~csharp
public static bool Beyond (this Vector2 self, Vector3 other, float distance)
~~~

If this is beyond a distance to another position.

~~~csharp
public static bool Beyond (this Vector2 self, [NotNull] Transform other, float distance)
~~~

If this is beyond a distance to another position.

~~~csharp
public static bool Beyond (this Vector2 self, [NotNull] Component other, float distance)
~~~

If this is beyond a distance to another position.

~~~csharp
public static bool Beyond (this Vector2 self, [NotNull] GameObject other, float distance)
~~~

If this is beyond a distance to another position.

~~~csharp
public static bool Beyond (this Vector3 self, Vector2 other, float distance)
~~~

If this is beyond a distance to another position.

~~~csharp
public static bool Beyond (this Vector3 self, Vector3 other, float distance)
~~~

If this is beyond a distance to another position.

~~~csharp
public static bool Beyond (this Vector3 self, [NotNull] Transform other, float distance)
~~~

If this is beyond a distance to another position.

~~~csharp
public static bool Beyond (this Vector3 self, [NotNull] Component other, float distance)
~~~

If this is beyond a distance to another position.

~~~csharp
public static bool Beyond (this Vector3 self, [NotNull] GameObject other, float distance)
~~~

If this is beyond a distance to another position.

~~~csharp
public static bool Beyond ([NotNull] this Transform self, Vector2 other, float distance)
~~~

If this is beyond a distance to another position.

~~~csharp
public static bool Beyond ([NotNull] this Transform self, Vector3 other, float distance)
~~~

If this is beyond a distance to another position.

~~~csharp
public static bool Beyond ([NotNull] this Transform self, [NotNull] Transform other, float distance)
~~~

If this is beyond a distance to another position.

~~~csharp
public static bool Beyond ([NotNull] this Transform self, [NotNull] Component other, float distance)
~~~

If this is beyond a distance to another position.

~~~csharp
public static bool Beyond ([NotNull] this Transform self, [NotNull] GameObject other, float distance)
~~~

If this is beyond a distance to another position.

~~~csharp
public static bool Beyond ([NotNull] this Component self, Vector2 other, float distance)
~~~

If this is beyond a distance to another position.

~~~csharp
public static bool Beyond ([NotNull] this Component self, Vector3 other, float distance)
~~~

If this is beyond a distance to another position.

~~~csharp
public static bool Beyond ([NotNull] this Component self, [NotNull] Transform other, float distance)
~~~

If this is beyond a distance to another position.

~~~csharp
public static bool Beyond ([NotNull] this Component self, [NotNull] Component other, float distance)
~~~

If this is beyond a distance to another position.

~~~csharp
public static bool Beyond ([NotNull] this Component self, [NotNull] GameObject other, float distance)
~~~

If this is beyond a distance to another position.

~~~csharp
public static bool Beyond ([NotNull] this GameObject self, Vector2 other, float distance)
~~~

If this is beyond a distance to another position.

~~~csharp
public static bool Beyond ([NotNull] this GameObject self, Vector3 other, float distance)
~~~

If this is beyond a distance to another position.

~~~csharp
public static bool Beyond ([NotNull] this GameObject self, [NotNull] Transform other, float distance)
~~~

If this is beyond a distance to another position.

~~~csharp
public static bool Beyond ([NotNull] this GameObject self, [NotNull] Component other, float distance)
~~~

If this is beyond a distance to another position.

~~~csharp
public static bool Beyond ([NotNull] this GameObject self, [NotNull] GameObject other, float distance)
~~~

If this is beyond a distance to another position.
