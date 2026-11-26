# KaijuAgentsFlatten

Extension methods to flatten objects down to their 2D representation as a Vector2 from the X and Z axes.

~~~csharp
public static class KaijuAgentsFlatten
~~~

[Package source](../../Runtime/Extensions/KaijuAgentsFlatten.cs)

<a id="KaijuSolutions_Agents_Extensions_KaijuAgentsFlatten_Flatten"></a>

### Flatten

~~~csharp
public static Vector2 Flatten (this Vector3 vector)
~~~

Flatten an XYZ vector down to the X and Z axes.

~~~csharp
public static Vector2 Flatten ([NotNull] this Transform transform)
~~~

Flatten a transform down to the X and Z axes positions.

~~~csharp
public static Vector2 Flatten ([NotNull] this Component component)
~~~

Flatten a component down to the X and Z axes positions.

~~~csharp
public static Vector2 Flatten ([NotNull] this GameObject gameObject)
~~~

Flatten a GameObject down to the X and Z axes positions.
