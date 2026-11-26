# KaijuAgentsInView

Extension methods to get if a target is within the field-of-view. This does not consider vertical field-of-view, meaning it checks relative to the global Y axis. All three-dimensional vectors will be flattened via methods in KaijuAgentsFlatten.

~~~csharp
public static class KaijuAgentsInView
~~~

[Package source](../../Runtime/Extensions/KaijuAgentsInView.cs)

<a id="KaijuSolutions_Agents_Extensions_KaijuAgentsInView_InView"></a>

### InView

~~~csharp
public static bool InView (this Vector2 position, Vector2 forward, Vector2 target, float fov)
~~~

If a target is within the field-of-view. This does not consider vertical field-of-view.

~~~csharp
public static bool InView (this Vector2 position, Vector2 forward, Vector3 target, float fov)
~~~

If a target is within the field-of-view. This does not consider vertical field-of-view.

~~~csharp
public static bool InView (this Vector2 position, Vector2 forward, [NotNull] Transform target, float fov)
~~~

If a target is within the field-of-view. This does not consider vertical field-of-view.

~~~csharp
public static bool InView (this Vector2 position, Vector2 forward, [NotNull] Component target, float fov)
~~~

If a target is within the field-of-view. This does not consider vertical field-of-view.

~~~csharp
public static bool InView (this Vector2 position, Vector2 forward, [NotNull] GameObject target, float fov)
~~~

If a target is within the field-of-view. This does not consider vertical field-of-view.

~~~csharp
public static bool InView (this Vector2 position, Vector3 forward, Vector2 target, float fov)
~~~

If a target is within the field-of-view. This does not consider vertical field-of-view.

~~~csharp
public static bool InView (this Vector2 position, Vector3 forward, Vector3 target, float fov)
~~~

If a target is within the field-of-view. This does not consider vertical field-of-view.

~~~csharp
public static bool InView (this Vector2 position, Vector3 forward, [NotNull] Transform target, float fov)
~~~

If a target is within the field-of-view. This does not consider vertical field-of-view.

~~~csharp
public static bool InView (this Vector2 position, Vector3 forward, [NotNull] Component target, float fov)
~~~

If a target is within the field-of-view. This does not consider vertical field-of-view.

~~~csharp
public static bool InView (this Vector2 position, Vector3 forward, [NotNull] GameObject target, float fov)
~~~

If a target is within the field-of-view. This does not consider vertical field-of-view.

~~~csharp
public static bool InView (this Vector2 position, [NotNull] Transform forward, Vector2 target, float fov)
~~~

If a target is within the field-of-view. This does not consider vertical field-of-view.

~~~csharp
public static bool InView (this Vector2 position, [NotNull] Transform forward, Vector3 target, float fov)
~~~

If a target is within the field-of-view. This does not consider vertical field-of-view.

~~~csharp
public static bool InView (this Vector2 position, [NotNull] Transform forward, [NotNull] Transform target, float fov)
~~~

If a target is within the field-of-view. This does not consider vertical field-of-view.

~~~csharp
public static bool InView (this Vector2 position, [NotNull] Transform forward, [NotNull] Component target, float fov)
~~~

If a target is within the field-of-view. This does not consider vertical field-of-view.

~~~csharp
public static bool InView (this Vector2 position, [NotNull] Transform forward, [NotNull] GameObject target, float fov)
~~~

If a target is within the field-of-view. This does not consider vertical field-of-view.

~~~csharp
public static bool InView (this Vector2 position, [NotNull] Component forward, Vector2 target, float fov)
~~~

If a target is within the field-of-view. This does not consider vertical field-of-view.

~~~csharp
public static bool InView (this Vector2 position, [NotNull] Component forward, Vector3 target, float fov)
~~~

If a target is within the field-of-view. This does not consider vertical field-of-view.

~~~csharp
public static bool InView (this Vector2 position, [NotNull] Component forward, [NotNull] Transform target, float fov)
~~~

If a target is within the field-of-view. This does not consider vertical field-of-view.

~~~csharp
public static bool InView (this Vector2 position, [NotNull] Component forward, [NotNull] Component target, float fov)
~~~

If a target is within the field-of-view. This does not consider vertical field-of-view.

~~~csharp
public static bool InView (this Vector2 position, [NotNull] Component forward, [NotNull] GameObject target, float fov)
~~~

If a target is within the field-of-view. This does not consider vertical field-of-view.

~~~csharp
public static bool InView (this Vector2 position, [NotNull] GameObject forward, Vector2 target, float fov)
~~~

If a target is within the field-of-view. This does not consider vertical field-of-view.

~~~csharp
public static bool InView (this Vector2 position, [NotNull] GameObject forward, Vector3 target, float fov)
~~~

If a target is within the field-of-view. This does not consider vertical field-of-view.

~~~csharp
public static bool InView (this Vector2 position, [NotNull] GameObject forward, [NotNull] Transform target, float fov)
~~~

If a target is within the field-of-view. This does not consider vertical field-of-view.

~~~csharp
public static bool InView (this Vector2 position, [NotNull] GameObject forward, [NotNull] Component target, float fov)
~~~

If a target is within the field-of-view. This does not consider vertical field-of-view.

~~~csharp
public static bool InView (this Vector2 position, [NotNull] GameObject forward, [NotNull] GameObject target, float fov)
~~~

If a target is within the field-of-view. This does not consider vertical field-of-view.

~~~csharp
public static bool InView (this Vector3 position, Vector2 forward, Vector2 target, float fov)
~~~

If a target is within the field-of-view. This does not consider vertical field-of-view.

~~~csharp
public static bool InView (this Vector3 position, Vector2 forward, Vector3 target, float fov)
~~~

If a target is within the field-of-view. This does not consider vertical field-of-view.

~~~csharp
public static bool InView (this Vector3 position, Vector2 forward, [NotNull] Transform target, float fov)
~~~

If a target is within the field-of-view. This does not consider vertical field-of-view.

~~~csharp
public static bool InView (this Vector3 position, Vector2 forward, [NotNull] Component target, float fov)
~~~

If a target is within the field-of-view. This does not consider vertical field-of-view.

~~~csharp
public static bool InView (this Vector3 position, Vector2 forward, [NotNull] GameObject target, float fov)
~~~

If a target is within the field-of-view. This does not consider vertical field-of-view.

~~~csharp
public static bool InView (this Vector3 position, Vector3 forward, Vector2 target, float fov)
~~~

If a target is within the field-of-view. This does not consider vertical field-of-view.

~~~csharp
public static bool InView (this Vector3 position, Vector3 forward, Vector3 target, float fov)
~~~

If a target is within the field-of-view. This does not consider vertical field-of-view.

~~~csharp
public static bool InView (this Vector3 position, Vector3 forward, [NotNull] Transform target, float fov)
~~~

If a target is within the field-of-view. This does not consider vertical field-of-view.

~~~csharp
public static bool InView (this Vector3 position, Vector3 forward, [NotNull] Component target, float fov)
~~~

If a target is within the field-of-view. This does not consider vertical field-of-view.

~~~csharp
public static bool InView (this Vector3 position, Vector3 forward, [NotNull] GameObject target, float fov)
~~~

If a target is within the field-of-view. This does not consider vertical field-of-view.

~~~csharp
public static bool InView (this Vector3 position, [NotNull] Transform forward, Vector2 target, float fov)
~~~

If a target is within the field-of-view. This does not consider vertical field-of-view.

~~~csharp
public static bool InView (this Vector3 position, [NotNull] Transform forward, Vector3 target, float fov)
~~~

If a target is within the field-of-view. This does not consider vertical field-of-view.

~~~csharp
public static bool InView (this Vector3 position, [NotNull] Transform forward, [NotNull] Transform target, float fov)
~~~

If a target is within the field-of-view. This does not consider vertical field-of-view.

~~~csharp
public static bool InView (this Vector3 position, [NotNull] Transform forward, [NotNull] Component target, float fov)
~~~

If a target is within the field-of-view. This does not consider vertical field-of-view.

~~~csharp
public static bool InView (this Vector3 position, [NotNull] Transform forward, [NotNull] GameObject target, float fov)
~~~

If a target is within the field-of-view. This does not consider vertical field-of-view.

~~~csharp
public static bool InView (this Vector3 position, [NotNull] Component forward, Vector2 target, float fov)
~~~

If a target is within the field-of-view. This does not consider vertical field-of-view.

~~~csharp
public static bool InView (this Vector3 position, [NotNull] Component forward, Vector3 target, float fov)
~~~

If a target is within the field-of-view. This does not consider vertical field-of-view.

~~~csharp
public static bool InView (this Vector3 position, [NotNull] Component forward, [NotNull] Transform target, float fov)
~~~

If a target is within the field-of-view. This does not consider vertical field-of-view.

~~~csharp
public static bool InView (this Vector3 position, [NotNull] Component forward, [NotNull] Component target, float fov)
~~~

If a target is within the field-of-view. This does not consider vertical field-of-view.

~~~csharp
public static bool InView (this Vector3 position, [NotNull] Component forward, [NotNull] GameObject target, float fov)
~~~

If a target is within the field-of-view. This does not consider vertical field-of-view.

~~~csharp
public static bool InView (this Vector3 position, [NotNull] GameObject forward, Vector2 target, float fov)
~~~

If a target is within the field-of-view. This does not consider vertical field-of-view.

~~~csharp
public static bool InView (this Vector3 position, [NotNull] GameObject forward, Vector3 target, float fov)
~~~

If a target is within the field-of-view. This does not consider vertical field-of-view.

~~~csharp
public static bool InView (this Vector3 position, [NotNull] GameObject forward, [NotNull] Transform target, float fov)
~~~

If a target is within the field-of-view. This does not consider vertical field-of-view.

~~~csharp
public static bool InView (this Vector3 position, [NotNull] GameObject forward, [NotNull] Component target, float fov)
~~~

If a target is within the field-of-view. This does not consider vertical field-of-view.

~~~csharp
public static bool InView (this Vector3 position, [NotNull] GameObject forward, [NotNull] GameObject target, float fov)
~~~

If a target is within the field-of-view. This does not consider vertical field-of-view.

~~~csharp
public static bool InView ([NotNull] this Transform position, Vector2 forward, Vector2 target, float fov)
~~~

If a target is within the field-of-view. This does not consider vertical field-of-view.

~~~csharp
public static bool InView ([NotNull] this Transform position, Vector2 forward, Vector3 target, float fov)
~~~

If a target is within the field-of-view. This does not consider vertical field-of-view.

~~~csharp
public static bool InView ([NotNull] this Transform position, Vector2 forward, [NotNull] Transform target, float fov)
~~~

If a target is within the field-of-view. This does not consider vertical field-of-view.

~~~csharp
public static bool InView ([NotNull] this Transform position, Vector2 forward, [NotNull] Component target, float fov)
~~~

If a target is within the field-of-view. This does not consider vertical field-of-view.

~~~csharp
public static bool InView ([NotNull] this Transform position, Vector2 forward, [NotNull] GameObject target, float fov)
~~~

If a target is within the field-of-view. This does not consider vertical field-of-view.

~~~csharp
public static bool InView ([NotNull] this Transform position, Vector3 forward, Vector2 target, float fov)
~~~

If a target is within the field-of-view. This does not consider vertical field-of-view.

~~~csharp
public static bool InView ([NotNull] this Transform position, Vector3 forward, Vector3 target, float fov)
~~~

If a target is within the field-of-view. This does not consider vertical field-of-view.

~~~csharp
public static bool InView ([NotNull] this Transform position, Vector3 forward, [NotNull] Transform target, float fov)
~~~

If a target is within the field-of-view. This does not consider vertical field-of-view.

~~~csharp
public static bool InView ([NotNull] this Transform position, Vector3 forward, [NotNull] Component target, float fov)
~~~

If a target is within the field-of-view. This does not consider vertical field-of-view.

~~~csharp
public static bool InView ([NotNull] this Transform position, Vector3 forward, [NotNull] GameObject target, float fov)
~~~

If a target is within the field-of-view. This does not consider vertical field-of-view.

~~~csharp
public static bool InView ([NotNull] this Transform position, [NotNull] Transform forward, Vector2 target, float fov)
~~~

If a target is within the field-of-view. This does not consider vertical field-of-view.

~~~csharp
public static bool InView ([NotNull] this Transform position, [NotNull] Transform forward, Vector3 target, float fov)
~~~

If a target is within the field-of-view. This does not consider vertical field-of-view.

~~~csharp
public static bool InView ([NotNull] this Transform position, [NotNull] Transform forward, [NotNull] Transform target, float fov)
~~~

If a target is within the field-of-view. This does not consider vertical field-of-view.

~~~csharp
public static bool InView ([NotNull] this Transform position, [NotNull] Transform forward, [NotNull] Component target, float fov)
~~~

If a target is within the field-of-view. This does not consider vertical field-of-view.

~~~csharp
public static bool InView ([NotNull] this Transform position, [NotNull] Transform forward, [NotNull] GameObject target, float fov)
~~~

If a target is within the field-of-view. This does not consider vertical field-of-view.

~~~csharp
public static bool InView ([NotNull] this Transform position, [NotNull] Component forward, Vector2 target, float fov)
~~~

If a target is within the field-of-view. This does not consider vertical field-of-view.

~~~csharp
public static bool InView ([NotNull] this Transform position, [NotNull] Component forward, Vector3 target, float fov)
~~~

If a target is within the field-of-view. This does not consider vertical field-of-view.

~~~csharp
public static bool InView ([NotNull] this Transform position, [NotNull] Component forward, [NotNull] Transform target, float fov)
~~~

If a target is within the field-of-view. This does not consider vertical field-of-view.

~~~csharp
public static bool InView ([NotNull] this Transform position, [NotNull] Component forward, [NotNull] Component target, float fov)
~~~

If a target is within the field-of-view. This does not consider vertical field-of-view.

~~~csharp
public static bool InView ([NotNull] this Transform position, [NotNull] Component forward, [NotNull] GameObject target, float fov)
~~~

If a target is within the field-of-view. This does not consider vertical field-of-view.

~~~csharp
public static bool InView ([NotNull] this Transform position, [NotNull] GameObject forward, Vector2 target, float fov)
~~~

If a target is within the field-of-view. This does not consider vertical field-of-view.

~~~csharp
public static bool InView ([NotNull] this Transform position, [NotNull] GameObject forward, Vector3 target, float fov)
~~~

If a target is within the field-of-view. This does not consider vertical field-of-view.

~~~csharp
public static bool InView ([NotNull] this Transform position, [NotNull] GameObject forward, [NotNull] Transform target, float fov)
~~~

If a target is within the field-of-view. This does not consider vertical field-of-view.

~~~csharp
public static bool InView ([NotNull] this Transform position, [NotNull] GameObject forward, [NotNull] Component target, float fov)
~~~

If a target is within the field-of-view. This does not consider vertical field-of-view.

~~~csharp
public static bool InView ([NotNull] this Transform position, [NotNull] GameObject forward, [NotNull] GameObject target, float fov)
~~~

If a target is within the field-of-view. This does not consider vertical field-of-view.

~~~csharp
public static bool InView ([NotNull] this Transform position, Vector2 target, float fov)
~~~

If a target is within the field-of-view. This does not consider vertical field-of-view.

~~~csharp
public static bool InView ([NotNull] this Transform position, Vector3 target, float fov)
~~~

If a target is within the field-of-view. This does not consider vertical field-of-view.

~~~csharp
public static bool InView ([NotNull] this Transform position, [NotNull] Transform target, float fov)
~~~

If a target is within the field-of-view. This does not consider vertical field-of-view.

~~~csharp
public static bool InView ([NotNull] this Transform position, [NotNull] Component target, float fov)
~~~

If a target is within the field-of-view. This does not consider vertical field-of-view.

~~~csharp
public static bool InView ([NotNull] this Transform position, [NotNull] GameObject target, float fov)
~~~

If a target is within the field-of-view. This does not consider vertical field-of-view.

~~~csharp
public static bool InView ([NotNull] this Component position, Vector2 forward, Vector2 target, float fov)
~~~

If a target is within the field-of-view. This does not consider vertical field-of-view.

~~~csharp
public static bool InView ([NotNull] this Component position, Vector2 forward, Vector3 target, float fov)
~~~

If a target is within the field-of-view. This does not consider vertical field-of-view.

~~~csharp
public static bool InView ([NotNull] this Component position, Vector2 forward, [NotNull] Transform target, float fov)
~~~

If a target is within the field-of-view. This does not consider vertical field-of-view.

~~~csharp
public static bool InView ([NotNull] this Component position, Vector2 forward, [NotNull] Component target, float fov)
~~~

If a target is within the field-of-view. This does not consider vertical field-of-view.

~~~csharp
public static bool InView ([NotNull] this Component position, Vector2 forward, [NotNull] GameObject target, float fov)
~~~

If a target is within the field-of-view. This does not consider vertical field-of-view.

~~~csharp
public static bool InView ([NotNull] this Component position, Vector3 forward, Vector2 target, float fov)
~~~

If a target is within the field-of-view. This does not consider vertical field-of-view.

~~~csharp
public static bool InView ([NotNull] this Component position, Vector3 forward, Vector3 target, float fov)
~~~

If a target is within the field-of-view. This does not consider vertical field-of-view.

~~~csharp
public static bool InView ([NotNull] this Component position, Vector3 forward, [NotNull] Transform target, float fov)
~~~

If a target is within the field-of-view. This does not consider vertical field-of-view.

~~~csharp
public static bool InView ([NotNull] this Component position, Vector3 forward, [NotNull] Component target, float fov)
~~~

If a target is within the field-of-view. This does not consider vertical field-of-view.

~~~csharp
public static bool InView ([NotNull] this Component position, Vector3 forward, [NotNull] GameObject target, float fov)
~~~

If a target is within the field-of-view. This does not consider vertical field-of-view.

~~~csharp
public static bool InView ([NotNull] this Component position, [NotNull] Transform forward, Vector2 target, float fov)
~~~

If a target is within the field-of-view. This does not consider vertical field-of-view.

~~~csharp
public static bool InView ([NotNull] this Component position, [NotNull] Transform forward, Vector3 target, float fov)
~~~

If a target is within the field-of-view. This does not consider vertical field-of-view.

~~~csharp
public static bool InView ([NotNull] this Component position, [NotNull] Transform forward, [NotNull] Transform target, float fov)
~~~

If a target is within the field-of-view. This does not consider vertical field-of-view.

~~~csharp
public static bool InView ([NotNull] this Component position, [NotNull] Transform forward, [NotNull] Component target, float fov)
~~~

If a target is within the field-of-view. This does not consider vertical field-of-view.

~~~csharp
public static bool InView ([NotNull] this Component position, [NotNull] Transform forward, [NotNull] GameObject target, float fov)
~~~

If a target is within the field-of-view. This does not consider vertical field-of-view.

~~~csharp
public static bool InView ([NotNull] this Component position, [NotNull] Component forward, Vector2 target, float fov)
~~~

If a target is within the field-of-view. This does not consider vertical field-of-view.

~~~csharp
public static bool InView ([NotNull] this Component position, [NotNull] Component forward, Vector3 target, float fov)
~~~

If a target is within the field-of-view. This does not consider vertical field-of-view.

~~~csharp
public static bool InView ([NotNull] this Component position, [NotNull] Component forward, [NotNull] Transform target, float fov)
~~~

If a target is within the field-of-view. This does not consider vertical field-of-view.

~~~csharp
public static bool InView ([NotNull] this Component position, [NotNull] Component forward, [NotNull] Component target, float fov)
~~~

If a target is within the field-of-view. This does not consider vertical field-of-view.

~~~csharp
public static bool InView ([NotNull] this Component position, [NotNull] Component forward, [NotNull] GameObject target, float fov)
~~~

If a target is within the field-of-view. This does not consider vertical field-of-view.

~~~csharp
public static bool InView ([NotNull] this Component position, [NotNull] GameObject forward, Vector2 target, float fov)
~~~

If a target is within the field-of-view. This does not consider vertical field-of-view.

~~~csharp
public static bool InView ([NotNull] this Component position, [NotNull] GameObject forward, Vector3 target, float fov)
~~~

If a target is within the field-of-view. This does not consider vertical field-of-view.

~~~csharp
public static bool InView ([NotNull] this Component position, [NotNull] GameObject forward, [NotNull] Transform target, float fov)
~~~

If a target is within the field-of-view. This does not consider vertical field-of-view.

~~~csharp
public static bool InView ([NotNull] this Component position, [NotNull] GameObject forward, [NotNull] Component target, float fov)
~~~

If a target is within the field-of-view. This does not consider vertical field-of-view.

~~~csharp
public static bool InView ([NotNull] this Component position, [NotNull] GameObject forward, [NotNull] GameObject target, float fov)
~~~

If a target is within the field-of-view. This does not consider vertical field-of-view.

~~~csharp
public static bool InView ([NotNull] this Component position, Vector2 target, float fov)
~~~

If a target is within the field-of-view. This does not consider vertical field-of-view.

~~~csharp
public static bool InView ([NotNull] this Component position, Vector3 target, float fov)
~~~

If a target is within the field-of-view. This does not consider vertical field-of-view.

~~~csharp
public static bool InView ([NotNull] this Component position, [NotNull] Transform target, float fov)
~~~

If a target is within the field-of-view. This does not consider vertical field-of-view.

~~~csharp
public static bool InView ([NotNull] this Component position, [NotNull] Component target, float fov)
~~~

If a target is within the field-of-view. This does not consider vertical field-of-view.

~~~csharp
public static bool InView ([NotNull] this Component position, [NotNull] GameObject target, float fov)
~~~

If a target is within the field-of-view. This does not consider vertical field-of-view.

~~~csharp
public static bool InView ([NotNull] this GameObject position, Vector2 forward, Vector2 target, float fov)
~~~

If a target is within the field-of-view. This does not consider vertical field-of-view.

~~~csharp
public static bool InView ([NotNull] this GameObject position, Vector2 forward, Vector3 target, float fov)
~~~

If a target is within the field-of-view. This does not consider vertical field-of-view.

~~~csharp
public static bool InView ([NotNull] this GameObject position, Vector2 forward, [NotNull] Transform target, float fov)
~~~

If a target is within the field-of-view. This does not consider vertical field-of-view.

~~~csharp
public static bool InView ([NotNull] this GameObject position, Vector2 forward, [NotNull] Component target, float fov)
~~~

If a target is within the field-of-view. This does not consider vertical field-of-view.

~~~csharp
public static bool InView ([NotNull] this GameObject position, Vector2 forward, [NotNull] GameObject target, float fov)
~~~

If a target is within the field-of-view. This does not consider vertical field-of-view.

~~~csharp
public static bool InView ([NotNull] this GameObject position, Vector3 forward, Vector2 target, float fov)
~~~

If a target is within the field-of-view. This does not consider vertical field-of-view.

~~~csharp
public static bool InView ([NotNull] this GameObject position, Vector3 forward, Vector3 target, float fov)
~~~

If a target is within the field-of-view. This does not consider vertical field-of-view.

~~~csharp
public static bool InView ([NotNull] this GameObject position, Vector3 forward, [NotNull] Transform target, float fov)
~~~

If a target is within the field-of-view. This does not consider vertical field-of-view.

~~~csharp
public static bool InView ([NotNull] this GameObject position, Vector3 forward, [NotNull] Component target, float fov)
~~~

If a target is within the field-of-view. This does not consider vertical field-of-view.

~~~csharp
public static bool InView ([NotNull] this GameObject position, Vector3 forward, [NotNull] GameObject target, float fov)
~~~

If a target is within the field-of-view. This does not consider vertical field-of-view.

~~~csharp
public static bool InView ([NotNull] this GameObject position, [NotNull] Transform forward, Vector2 target, float fov)
~~~

If a target is within the field-of-view. This does not consider vertical field-of-view.

~~~csharp
public static bool InView ([NotNull] this GameObject position, [NotNull] Transform forward, Vector3 target, float fov)
~~~

If a target is within the field-of-view. This does not consider vertical field-of-view.

~~~csharp
public static bool InView ([NotNull] this GameObject position, [NotNull] Transform forward, [NotNull] Transform target, float fov)
~~~

If a target is within the field-of-view. This does not consider vertical field-of-view.

~~~csharp
public static bool InView ([NotNull] this GameObject position, [NotNull] Transform forward, [NotNull] Component target, float fov)
~~~

If a target is within the field-of-view. This does not consider vertical field-of-view.

~~~csharp
public static bool InView ([NotNull] this GameObject position, [NotNull] Transform forward, [NotNull] GameObject target, float fov)
~~~

If a target is within the field-of-view. This does not consider vertical field-of-view.

~~~csharp
public static bool InView ([NotNull] this GameObject position, [NotNull] Component forward, Vector2 target, float fov)
~~~

If a target is within the field-of-view. This does not consider vertical field-of-view.

~~~csharp
public static bool InView ([NotNull] this GameObject position, [NotNull] Component forward, Vector3 target, float fov)
~~~

If a target is within the field-of-view. This does not consider vertical field-of-view.

~~~csharp
public static bool InView ([NotNull] this GameObject position, [NotNull] Component forward, [NotNull] Transform target, float fov)
~~~

If a target is within the field-of-view. This does not consider vertical field-of-view.

~~~csharp
public static bool InView ([NotNull] this GameObject position, [NotNull] Component forward, [NotNull] Component target, float fov)
~~~

If a target is within the field-of-view. This does not consider vertical field-of-view.

~~~csharp
public static bool InView ([NotNull] this GameObject position, [NotNull] Component forward, [NotNull] GameObject target, float fov)
~~~

If a target is within the field-of-view. This does not consider vertical field-of-view.

~~~csharp
public static bool InView ([NotNull] this GameObject position, [NotNull] GameObject forward, Vector2 target, float fov)
~~~

If a target is within the field-of-view. This does not consider vertical field-of-view.

~~~csharp
public static bool InView ([NotNull] this GameObject position, [NotNull] GameObject forward, Vector3 target, float fov)
~~~

If a target is within the field-of-view. This does not consider vertical field-of-view.

~~~csharp
public static bool InView ([NotNull] this GameObject position, [NotNull] GameObject forward, [NotNull] Transform target, float fov)
~~~

If a target is within the field-of-view. This does not consider vertical field-of-view.

~~~csharp
public static bool InView ([NotNull] this GameObject position, [NotNull] GameObject forward, [NotNull] Component target, float fov)
~~~

If a target is within the field-of-view. This does not consider vertical field-of-view.

~~~csharp
public static bool InView ([NotNull] this GameObject position, [NotNull] GameObject forward, [NotNull] GameObject target, float fov)
~~~

If a target is within the field-of-view. This does not consider vertical field-of-view.

~~~csharp
public static bool InView ([NotNull] this GameObject position, Vector2 target, float fov)
~~~

If a target is within the field-of-view. This does not consider vertical field-of-view.

~~~csharp
public static bool InView ([NotNull] this GameObject position, Vector3 target, float fov)
~~~

If a target is within the field-of-view. This does not consider vertical field-of-view.

~~~csharp
public static bool InView ([NotNull] this GameObject position, [NotNull] Transform target, float fov)
~~~

If a target is within the field-of-view. This does not consider vertical field-of-view.

~~~csharp
public static bool InView ([NotNull] this GameObject position, [NotNull] Component target, float fov)
~~~

If a target is within the field-of-view. This does not consider vertical field-of-view.

~~~csharp
public static bool InView ([NotNull] this GameObject position, [NotNull] GameObject target, float fov)
~~~

If a target is within the field-of-view. This does not consider vertical field-of-view.
