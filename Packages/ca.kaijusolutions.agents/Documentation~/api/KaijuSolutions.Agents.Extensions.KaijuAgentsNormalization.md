# KaijuAgentsNormalization

Helper normalization methods.

~~~csharp
public static class KaijuAgentsNormalization
~~~

[Package source](../../Runtime/Extensions/KaijuAgentsNormalization.cs)

<a id="KaijuSolutions_Agents_Extensions_KaijuAgentsNormalization_Normalize"></a>

### Normalize

~~~csharp
public static float Normalize (this float value, float original, float min = -1f, float max = 1f)
~~~

Normalize a float.

~~~csharp
public static Vector2 Normalize (this Vector2 value, float original, float min = -1f, float max = 1f)
~~~

Normalize a vector.

~~~csharp
public static Vector3 Normalize (this Vector3 value, float original, float min = -1f, float max = 1f)
~~~

Normalize a vector.

~~~csharp
public static Vector2 Normalize (this Vector2 value, Vector2 position, Vector2 forward, float original)
~~~

Normalize a vector between [-1, 1] relative to a position and forward.

~~~csharp
public static Vector2 Normalize (this Vector2 value, Vector2 position, Vector3 forward, float original)
~~~

Normalize a vector between [-1, 1] relative to a position and forward.

~~~csharp
public static Vector2 Normalize (this Vector2 value, Vector3 position, Vector2 forward, float original)
~~~

Normalize a vector between [-1, 1] relative to a position and forward.

~~~csharp
public static Vector2 Normalize (this Vector2 value, Vector3 position, Vector3 forward, float original)
~~~

Normalize a vector between [-1, 1] relative to a position and forward.

~~~csharp
public static Vector2 Normalize (this Vector2 value, Transform position, float original)
~~~

Normalize a vector between [-1, 1] relative to a position and its forward.

~~~csharp
public static Vector2 Normalize (this Vector2 value, GameObject position, float original)
~~~

Normalize a vector between [-1, 1] relative to a position and its forward.

~~~csharp
public static Vector2 Normalize (this Vector2 value, Component position, float original)
~~~

Normalize a vector between [-1, 1] relative to a position and its forward.

~~~csharp
public static Vector3 Normalize (this Vector3 value, Vector2 position, Vector2 forward, float original)
~~~

Normalize a vector between [-1, 1] relative to a position and forward.

~~~csharp
public static Vector3 Normalize (this Vector3 value, Vector2 position, Vector3 forward, float original)
~~~

Normalize a vector between [-1, 1] relative to a position and forward.

~~~csharp
public static Vector3 Normalize (this Vector3 value, Vector3 position, Vector2 forward, float original)
~~~

Normalize a vector between [-1, 1] relative to a position and forward.

~~~csharp
public static Vector3 Normalize (this Vector3 value, Vector3 position, Vector3 forward, float original)
~~~

Normalize a vector between [-1, 1] relative to a position and forward.

~~~csharp
public static Vector3 Normalize (this Vector3 value, Transform position, float original)
~~~

Normalize a vector between [-1, 1] relative to a position and its forward.

~~~csharp
public static Vector3 Normalize (this Vector3 value, GameObject position, float original)
~~~

Normalize a vector between [-1, 1] relative to a position and its forward.

~~~csharp
public static Vector3 Normalize (this Vector3 value, Component position, float original)
~~~

Normalize a vector between [-1, 1] relative to a position and its forward.
