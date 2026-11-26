# KaijuAgentsDistance

Extension methods to get the 2D distance across the X and Z axes. All three-dimensional vectors will be flattened via methods in KaijuAgentsFlatten.

~~~csharp
public static class KaijuAgentsDistance
~~~

[Package source](../../Runtime/Extensions/KaijuAgentsDistance.cs)

<a id="KaijuSolutions_Agents_Extensions_KaijuAgentsDistance_Distance"></a>

### Distance

~~~csharp
public static float Distance (this Vector2 self, Vector2 other)
~~~

Get the distance between this and another position.

~~~csharp
public static float Distance (this Vector2 self, Vector3 other)
~~~

Get the distance between this and another position.

~~~csharp
public static float Distance (this Vector2 self, [NotNull] Transform other)
~~~

Get the distance between this and another position.

~~~csharp
public static float Distance (this Vector2 self, [NotNull] Component other)
~~~

Get the distance between this and another position.

~~~csharp
public static float Distance (this Vector2 self, [NotNull] GameObject other)
~~~

Get the distance between this and another position.

~~~csharp
public static float Distance (this Vector3 self, Vector2 other)
~~~

Get the distance between this and another position.

~~~csharp
public static float Distance (this Vector3 self, Vector3 other)
~~~

Get the distance between this and another position.

~~~csharp
public static float Distance (this Vector3 self, [NotNull] Transform other)
~~~

Get the distance between this and another position.

~~~csharp
public static float Distance (this Vector3 self, [NotNull] Component other)
~~~

Get the distance between this and another position.

~~~csharp
public static float Distance (this Vector3 self, [NotNull] GameObject other)
~~~

Get the distance between this and another position.

~~~csharp
public static float Distance ([NotNull] this Transform self, Vector2 other)
~~~

Get the distance between this and another position.

~~~csharp
public static float Distance ([NotNull] this Transform self, Vector3 other)
~~~

Get the distance between this and another position.

~~~csharp
public static float Distance ([NotNull] this Transform self, [NotNull] Transform other)
~~~

Get the distance between this and another position.

~~~csharp
public static float Distance ([NotNull] this Transform self, [NotNull] Component other)
~~~

Get the distance between this and another position.

~~~csharp
public static float Distance ([NotNull] this Transform self, [NotNull] GameObject other)
~~~

Get the distance between this and another position.

~~~csharp
public static float Distance ([NotNull] this Component self, Vector2 other)
~~~

Get the distance between this and another position.

~~~csharp
public static float Distance ([NotNull] this Component self, Vector3 other)
~~~

Get the distance between this and another position.

~~~csharp
public static float Distance ([NotNull] this Component self, [NotNull] Transform other)
~~~

Get the distance between this and another position.

~~~csharp
public static float Distance ([NotNull] this Component self, [NotNull] Component other)
~~~

Get the distance between this and another position.

~~~csharp
public static float Distance ([NotNull] this Component self, [NotNull] GameObject other)
~~~

Get the distance between this and another position.

~~~csharp
public static float Distance ([NotNull] this GameObject self, Vector2 other)
~~~

Get the distance between this and another position.

~~~csharp
public static float Distance ([NotNull] this GameObject self, [NotNull] Transform other)
~~~

Get the distance between this and another position.

~~~csharp
public static float Distance ([NotNull] this GameObject self, Vector3 other)
~~~

Get the distance between this and another position.

~~~csharp
public static float Distance ([NotNull] this GameObject self, [NotNull] Component other)
~~~

Get the distance between this and another position.

~~~csharp
public static float Distance ([NotNull] this GameObject self, [NotNull] GameObject other)
~~~

Get the distance between this and another position.
