# KaijuAgentsBetween3

Extension methods to see if points are between two given distances of each other along all three axes. These methods are inclusive of the distances to check. Any Vector2 values will be expanded via the KaijuAgentsExpand.Expand method.

~~~csharp
public static class KaijuAgentsBetween3
~~~

[Package source](../../Runtime/Extensions/KaijuAgentsBetween3.cs)

<a id="KaijuSolutions_Agents_Extensions_KaijuAgentsBetween3_Between3"></a>

### Between3

~~~csharp
public static bool Between3 (this Vector2 self, Vector3 other, float minimum, float maximum)
~~~

If this is between two distances to another position.

~~~csharp
public static bool Between3 (this Vector2 self, [NotNull] Transform other, float minimum, float maximum)
~~~

If this is between two distances to another position.

~~~csharp
public static bool Between3 (this Vector2 self, [NotNull] Component other, float minimum, float maximum)
~~~

If this is between two distances to another position.

~~~csharp
public static bool Between3 (this Vector2 self, [NotNull] GameObject other, float minimum, float maximum)
~~~

If this is between two distances to another position.

~~~csharp
public static bool Between3 (this Vector3 self, Vector2 other, float minimum, float maximum)
~~~

If this is between two distances to another position.

~~~csharp
public static bool Between3 (this Vector3 self, Vector3 other, float minimum, float maximum)
~~~

If this is between two distances to another position.

~~~csharp
public static bool Between3 (this Vector3 self, [NotNull] Transform other, float minimum, float maximum)
~~~

If this is between two distances to another position.

~~~csharp
public static bool Between3 (this Vector3 self, [NotNull] Component other, float minimum, float maximum)
~~~

If this is between two distances to another position.

~~~csharp
public static bool Between3 (this Vector3 self, [NotNull] GameObject other, float minimum, float maximum)
~~~

If this is between two distances to another position.

~~~csharp
public static bool Between3 ([NotNull] this Transform self, Vector2 other, float minimum, float maximum)
~~~

If this is between two distances to another position.

~~~csharp
public static bool Between3 ([NotNull] this Transform self, Vector3 other, float minimum, float maximum)
~~~

If this is between two distances to another position.

~~~csharp
public static bool Between3 ([NotNull] this Transform self, [NotNull] Transform other, float minimum, float maximum)
~~~

If this is between two distances to another position.

~~~csharp
public static bool Between3 ([NotNull] this Transform self, [NotNull] Component other, float minimum, float maximum)
~~~

If this is between two distances to another position.

~~~csharp
public static bool Between3 ([NotNull] this Transform self, [NotNull] GameObject other, float minimum, float maximum)
~~~

If this is between two distances to another position.

~~~csharp
public static bool Between3 ([NotNull] this Component self, Vector2 other, float minimum, float maximum)
~~~

If this is between two distances to another position.

~~~csharp
public static bool Between3 ([NotNull] this Component self, Vector3 other, float minimum, float maximum)
~~~

If this is between two distances to another position.

~~~csharp
public static bool Between3 ([NotNull] this Component self, [NotNull] Transform other, float minimum, float maximum)
~~~

If this is between two distances to another position.

~~~csharp
public static bool Between3 ([NotNull] this Component self, [NotNull] Component other, float minimum, float maximum)
~~~

If this is between two distances to another position.

~~~csharp
public static bool Between3 ([NotNull] this Component self, [NotNull] GameObject other, float minimum, float maximum)
~~~

If this is between two distances to another position.

~~~csharp
public static bool Between3 ([NotNull] this GameObject self, Vector2 other, float minimum, float maximum)
~~~

If this is between two distances to another position.

~~~csharp
public static bool Between3 ([NotNull] this GameObject self, Vector3 other, float minimum, float maximum)
~~~

If this is between two distances to another position.

~~~csharp
public static bool Between3 ([NotNull] this GameObject self, [NotNull] Transform other, float minimum, float maximum)
~~~

If this is between two distances to another position.

~~~csharp
public static bool Between3 ([NotNull] this GameObject self, [NotNull] Component other, float minimum, float maximum)
~~~

If this is between two distances to another position.

~~~csharp
public static bool Between3 ([NotNull] this GameObject self, [NotNull] GameObject other, float minimum, float maximum)
~~~

If this is between two distances to another position.
