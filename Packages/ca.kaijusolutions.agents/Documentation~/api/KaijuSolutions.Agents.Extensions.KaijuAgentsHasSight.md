# KaijuAgentsHasSight

Extension methods to see if there is a direct line of sight between two positions across all axes. Any Vector2 values will be expanded via the KaijuAgentsExpand.Expand method.

~~~csharp
public static class KaijuAgentsHasSight
~~~

[Package source](../../Runtime/Extensions/KaijuAgentsHasSight.cs)

<a id="KaijuSolutions_Agents_Extensions_KaijuAgentsHasSight_HasSight"></a>

### HasSight

~~~csharp
public static bool HasSight (this Vector2 position, Vector2 target, out RaycastHit hit, int mask = KaijuMovementConfiguration.DefaultMask, QueryTriggerInteraction triggers = QueryTriggerInteraction.UseGlobal)
~~~

If there is a direct line of sight from a starting position to an end position.

~~~csharp
public static bool HasSight (this Vector2 position, Vector3 target, out RaycastHit hit, int mask = KaijuMovementConfiguration.DefaultMask, QueryTriggerInteraction triggers = QueryTriggerInteraction.UseGlobal)
~~~

If there is a direct line of sight from a starting position to an end position.

~~~csharp
public static bool HasSight (this Vector2 position, [NotNull] Transform target, out RaycastHit hit, int mask = KaijuMovementConfiguration.DefaultMask, QueryTriggerInteraction triggers = QueryTriggerInteraction.UseGlobal)
~~~

If there is a direct line of sight from a starting position to an end position, or the hit during the line of sight check was the target.

~~~csharp
public static bool HasSight (this Vector2 position, [NotNull] Component target, out RaycastHit hit, int mask = KaijuMovementConfiguration.DefaultMask, QueryTriggerInteraction triggers = QueryTriggerInteraction.UseGlobal)
~~~

If there is a direct line of sight from a starting position to an end position, or the hit during the line of sight check was the target.

~~~csharp
public static bool HasSight (this Vector2 position, [NotNull] GameObject target, out RaycastHit hit, int mask = KaijuMovementConfiguration.DefaultMask, QueryTriggerInteraction triggers = QueryTriggerInteraction.UseGlobal)
~~~

If there is a direct line of sight from a starting position to an end position, or the hit during the line of sight check was the target.

~~~csharp
public static bool HasSight (this Vector3 position, Vector2 target, out RaycastHit hit, int mask = KaijuMovementConfiguration.DefaultMask, QueryTriggerInteraction triggers = QueryTriggerInteraction.UseGlobal)
~~~

If there is a direct line of sight from a starting position to an end position.

~~~csharp
public static bool HasSight (this Vector3 position, Vector3 target, out RaycastHit hit, int mask = KaijuMovementConfiguration.DefaultMask, QueryTriggerInteraction triggers = QueryTriggerInteraction.UseGlobal)
~~~

If there is a direct line of sight from a starting position to an end position.

~~~csharp
public static bool HasSight (this Vector3 position, [NotNull] Transform target, out RaycastHit hit, int mask = KaijuMovementConfiguration.DefaultMask, QueryTriggerInteraction triggers = QueryTriggerInteraction.UseGlobal)
~~~

If there is a direct line of sight from a starting position to an end position, or the hit during the line of sight check was the target.

~~~csharp
public static bool HasSight (this Vector3 position, [NotNull] Component target, out RaycastHit hit, int mask = KaijuMovementConfiguration.DefaultMask, QueryTriggerInteraction triggers = QueryTriggerInteraction.UseGlobal)
~~~

If there is a direct line of sight from a starting position to an end position, or the hit during the line of sight check was the target.

~~~csharp
public static bool HasSight (this Vector3 position, [NotNull] GameObject target, out RaycastHit hit, int mask = KaijuMovementConfiguration.DefaultMask, QueryTriggerInteraction triggers = QueryTriggerInteraction.UseGlobal)
~~~

If there is a direct line of sight from a starting position to an end position, or the hit during the line of sight check was the target.

~~~csharp
public static bool HasSight ([NotNull] this Transform position, Vector2 target, out RaycastHit hit, int mask = KaijuMovementConfiguration.DefaultMask, QueryTriggerInteraction triggers = QueryTriggerInteraction.UseGlobal)
~~~

If there is a direct line of sight from a starting position to an end position.

~~~csharp
public static bool HasSight ([NotNull] this Transform position, Vector3 target, out RaycastHit hit, int mask = KaijuMovementConfiguration.DefaultMask, QueryTriggerInteraction triggers = QueryTriggerInteraction.UseGlobal)
~~~

If there is a direct line of sight from a starting position to an end position.

~~~csharp
public static bool HasSight ([NotNull] this Transform position, [NotNull] Transform target, out RaycastHit hit, int mask = KaijuMovementConfiguration.DefaultMask, QueryTriggerInteraction triggers = QueryTriggerInteraction.UseGlobal)
~~~

If there is a direct line of sight from a starting position to an end position, or the hit during the line of sight check was the target.

~~~csharp
public static bool HasSight ([NotNull] this Transform position, [NotNull] Component target, out RaycastHit hit, int mask = KaijuMovementConfiguration.DefaultMask, QueryTriggerInteraction triggers = QueryTriggerInteraction.UseGlobal)
~~~

If there is a direct line of sight from a starting position to an end position, or the hit during the line of sight check was the target.

~~~csharp
public static bool HasSight ([NotNull] this Transform position, [NotNull] GameObject target, out RaycastHit hit, int mask = KaijuMovementConfiguration.DefaultMask, QueryTriggerInteraction triggers = QueryTriggerInteraction.UseGlobal)
~~~

If there is a direct line of sight from a starting position to an end position, or the hit during the line of sight check was the target.

~~~csharp
public static bool HasSight ([NotNull] this Component position, Vector2 target, out RaycastHit hit, int mask = KaijuMovementConfiguration.DefaultMask, QueryTriggerInteraction triggers = QueryTriggerInteraction.UseGlobal)
~~~

If there is a direct line of sight from a starting position to an end position.

~~~csharp
public static bool HasSight ([NotNull] this Component position, Vector3 target, out RaycastHit hit, int mask = KaijuMovementConfiguration.DefaultMask, QueryTriggerInteraction triggers = QueryTriggerInteraction.UseGlobal)
~~~

If there is a direct line of sight from a starting position to an end position.

~~~csharp
public static bool HasSight ([NotNull] this Component position, [NotNull] Transform target, out RaycastHit hit, int mask = KaijuMovementConfiguration.DefaultMask, QueryTriggerInteraction triggers = QueryTriggerInteraction.UseGlobal)
~~~

If there is a direct line of sight from a starting position to an end position, or the hit during the line of sight check was the target.

~~~csharp
public static bool HasSight ([NotNull] this Component position, [NotNull] Component target, out RaycastHit hit, int mask = KaijuMovementConfiguration.DefaultMask, QueryTriggerInteraction triggers = QueryTriggerInteraction.UseGlobal)
~~~

If there is a direct line of sight from a starting position to an end position, or the hit during the line of sight check was the target.

~~~csharp
public static bool HasSight ([NotNull] this Component position, [NotNull] GameObject target, out RaycastHit hit, int mask = KaijuMovementConfiguration.DefaultMask, QueryTriggerInteraction triggers = QueryTriggerInteraction.UseGlobal)
~~~

If there is a direct line of sight from a starting position to an end position, or the hit during the line of sight check was the target.

~~~csharp
public static bool HasSight ([NotNull] this GameObject position, Vector2 target, out RaycastHit hit, int mask = KaijuMovementConfiguration.DefaultMask, QueryTriggerInteraction triggers = QueryTriggerInteraction.UseGlobal)
~~~

If there is a direct line of sight from a starting position to an end position.

~~~csharp
public static bool HasSight ([NotNull] this GameObject position, Vector3 target, out RaycastHit hit, int mask = KaijuMovementConfiguration.DefaultMask, QueryTriggerInteraction triggers = QueryTriggerInteraction.UseGlobal)
~~~

If there is a direct line of sight from a starting position to an end position.

~~~csharp
public static bool HasSight ([NotNull] this GameObject position, [NotNull] Transform target, out RaycastHit hit, int mask = KaijuMovementConfiguration.DefaultMask, QueryTriggerInteraction triggers = QueryTriggerInteraction.UseGlobal)
~~~

If there is a direct line of sight from a starting position to an end position, or the hit during the line of sight check was the target.

~~~csharp
public static bool HasSight ([NotNull] this GameObject position, [NotNull] Component target, out RaycastHit hit, int mask = KaijuMovementConfiguration.DefaultMask, QueryTriggerInteraction triggers = QueryTriggerInteraction.UseGlobal)
~~~

If there is a direct line of sight from a starting position to an end position, or the hit during the line of sight check was the target.

~~~csharp
public static bool HasSight ([NotNull] this GameObject position, [NotNull] GameObject target, out RaycastHit hit, int mask = KaijuMovementConfiguration.DefaultMask, QueryTriggerInteraction triggers = QueryTriggerInteraction.UseGlobal)
~~~

If there is a direct line of sight from a starting position to an end position, or the hit during the line of sight check was the target.

~~~csharp
public static bool HasSight (this Vector2 position, Vector2 target, out RaycastHit hit, float radius, int mask = KaijuMovementConfiguration.DefaultMask, QueryTriggerInteraction triggers = QueryTriggerInteraction.UseGlobal)
~~~

If there is a direct line of sight with a given radius from a starting position to an end position.

~~~csharp
public static bool HasSight (this Vector2 position, Vector3 target, out RaycastHit hit, float radius, int mask = KaijuMovementConfiguration.DefaultMask, QueryTriggerInteraction triggers = QueryTriggerInteraction.UseGlobal)
~~~

If there is a direct line of sight with a given radius from a starting position to an end position.

~~~csharp
public static bool HasSight (this Vector2 position, [NotNull] Transform target, out RaycastHit hit, float radius, int mask = KaijuMovementConfiguration.DefaultMask, QueryTriggerInteraction triggers = QueryTriggerInteraction.UseGlobal)
~~~

If there is a direct line of sight with a given radius from a starting position to an end position, or the hit during the line of sight check was the target.

~~~csharp
public static bool HasSight (this Vector2 position, [NotNull] Component target, out RaycastHit hit, float radius, int mask = KaijuMovementConfiguration.DefaultMask, QueryTriggerInteraction triggers = QueryTriggerInteraction.UseGlobal)
~~~

If there is a direct line of sight with a given radius from a starting position to an end position, or the hit during the line of sight check was the target.

~~~csharp
public static bool HasSight (this Vector2 position, [NotNull] GameObject target, out RaycastHit hit, float radius, int mask = KaijuMovementConfiguration.DefaultMask, QueryTriggerInteraction triggers = QueryTriggerInteraction.UseGlobal)
~~~

If there is a direct line of sight with a given radius from a starting position to an end position, or the hit during the line of sight check was the target.

~~~csharp
public static bool HasSight (this Vector3 position, Vector2 target, out RaycastHit hit, float radius, int mask = KaijuMovementConfiguration.DefaultMask, QueryTriggerInteraction triggers = QueryTriggerInteraction.UseGlobal)
~~~

If there is a direct line of sight with a given radius from a starting position to an end position.

~~~csharp
public static bool HasSight (this Vector3 position, Vector3 target, out RaycastHit hit, float radius, int mask = KaijuMovementConfiguration.DefaultMask, QueryTriggerInteraction triggers = QueryTriggerInteraction.UseGlobal)
~~~

If there is a direct line of sight with a given radius from a starting position to an end position.

~~~csharp
public static bool HasSight (this Vector3 position, [NotNull] Transform target, out RaycastHit hit, float radius, int mask = KaijuMovementConfiguration.DefaultMask, QueryTriggerInteraction triggers = QueryTriggerInteraction.UseGlobal)
~~~

If there is a direct line of sight with a given radius from a starting position to an end position, or the hit during the line of sight check was the target.

~~~csharp
public static bool HasSight (this Vector3 position, [NotNull] Component target, out RaycastHit hit, float radius, int mask = KaijuMovementConfiguration.DefaultMask, QueryTriggerInteraction triggers = QueryTriggerInteraction.UseGlobal)
~~~

If there is a direct line of sight with a given radius from a starting position to an end position, or the hit during the line of sight check was the target.

~~~csharp
public static bool HasSight (this Vector3 position, [NotNull] GameObject target, out RaycastHit hit, float radius, int mask = KaijuMovementConfiguration.DefaultMask, QueryTriggerInteraction triggers = QueryTriggerInteraction.UseGlobal)
~~~

If there is a direct line of sight with a given radius from a starting position to an end position, or the hit during the line of sight check was the target.

~~~csharp
public static bool HasSight ([NotNull] this Transform position, Vector2 target, out RaycastHit hit, float radius, int mask = KaijuMovementConfiguration.DefaultMask, QueryTriggerInteraction triggers = QueryTriggerInteraction.UseGlobal)
~~~

If there is a direct line of sight with a given radius from a starting position to an end position.

~~~csharp
public static bool HasSight ([NotNull] this Transform position, Vector3 target, out RaycastHit hit, float radius, int mask = KaijuMovementConfiguration.DefaultMask, QueryTriggerInteraction triggers = QueryTriggerInteraction.UseGlobal)
~~~

If there is a direct line of sight with a given radius from a starting position to an end position.

~~~csharp
public static bool HasSight ([NotNull] this Transform position, [NotNull] Transform target, out RaycastHit hit, float radius, int mask = KaijuMovementConfiguration.DefaultMask, QueryTriggerInteraction triggers = QueryTriggerInteraction.UseGlobal)
~~~

If there is a direct line of sight with a given radius from a starting position to an end position, or the hit during the line of sight check was the target.

~~~csharp
public static bool HasSight ([NotNull] this Transform position, [NotNull] Component target, out RaycastHit hit, float radius, int mask = KaijuMovementConfiguration.DefaultMask, QueryTriggerInteraction triggers = QueryTriggerInteraction.UseGlobal)
~~~

If there is a direct line of sight with a given radius from a starting position to an end position, or the hit during the line of sight check was the target.

~~~csharp
public static bool HasSight ([NotNull] this Transform position, [NotNull] GameObject target, out RaycastHit hit, float radius, int mask = KaijuMovementConfiguration.DefaultMask, QueryTriggerInteraction triggers = QueryTriggerInteraction.UseGlobal)
~~~

If there is a direct line of sight with a given radius from a starting position to an end position, or the hit during the line of sight check was the target.

~~~csharp
public static bool HasSight ([NotNull] this Component position, Vector2 target, out RaycastHit hit, float radius, int mask = KaijuMovementConfiguration.DefaultMask, QueryTriggerInteraction triggers = QueryTriggerInteraction.UseGlobal)
~~~

If there is a direct line of sight with a given radius from a starting position to an end position.

~~~csharp
public static bool HasSight ([NotNull] this Component position, Vector3 target, out RaycastHit hit, float radius, int mask = KaijuMovementConfiguration.DefaultMask, QueryTriggerInteraction triggers = QueryTriggerInteraction.UseGlobal)
~~~

If there is a direct line of sight with a given radius from a starting position to an end position.

~~~csharp
public static bool HasSight ([NotNull] this Component position, [NotNull] Transform target, out RaycastHit hit, float radius, int mask = KaijuMovementConfiguration.DefaultMask, QueryTriggerInteraction triggers = QueryTriggerInteraction.UseGlobal)
~~~

If there is a direct line of sight with a given radius from a starting position to an end position, or the hit during the line of sight check was the target.

~~~csharp
public static bool HasSight ([NotNull] this Component position, [NotNull] Component target, out RaycastHit hit, float radius, int mask = KaijuMovementConfiguration.DefaultMask, QueryTriggerInteraction triggers = QueryTriggerInteraction.UseGlobal)
~~~

If there is a direct line of sight with a given radius from a starting position to an end position, or the hit during the line of sight check was the target.

~~~csharp
public static bool HasSight ([NotNull] this Component position, [NotNull] GameObject target, out RaycastHit hit, float radius, int mask = KaijuMovementConfiguration.DefaultMask, QueryTriggerInteraction triggers = QueryTriggerInteraction.UseGlobal)
~~~

If there is a direct line of sight with a given radius from a starting position to an end position, or the hit during the line of sight check was the target.

~~~csharp
public static bool HasSight ([NotNull] this GameObject position, Vector2 target, out RaycastHit hit, float radius, int mask = KaijuMovementConfiguration.DefaultMask, QueryTriggerInteraction triggers = QueryTriggerInteraction.UseGlobal)
~~~

If there is a direct line of sight with a given radius from a starting position to an end position.

~~~csharp
public static bool HasSight ([NotNull] this GameObject position, Vector3 target, out RaycastHit hit, float radius, int mask = KaijuMovementConfiguration.DefaultMask, QueryTriggerInteraction triggers = QueryTriggerInteraction.UseGlobal)
~~~

If there is a direct line of sight with a given radius from a starting position to an end position.

~~~csharp
public static bool HasSight ([NotNull] this GameObject position, [NotNull] Transform target, out RaycastHit hit, float radius, int mask = KaijuMovementConfiguration.DefaultMask, QueryTriggerInteraction triggers = QueryTriggerInteraction.UseGlobal)
~~~

If there is a direct line of sight with a given radius from a starting position to an end position, or the hit during the line of sight check was the target.

~~~csharp
public static bool HasSight ([NotNull] this GameObject position, [NotNull] Component target, out RaycastHit hit, float radius, int mask = KaijuMovementConfiguration.DefaultMask, QueryTriggerInteraction triggers = QueryTriggerInteraction.UseGlobal)
~~~

If there is a direct line of sight with a given radius from a starting position to an end position, or the hit during the line of sight check was the target.

~~~csharp
public static bool HasSight ([NotNull] this GameObject position, [NotNull] GameObject target, out RaycastHit hit, float radius, int mask = KaijuMovementConfiguration.DefaultMask, QueryTriggerInteraction triggers = QueryTriggerInteraction.UseGlobal)
~~~

If there is a direct line of sight with a given radius from a starting position to an end position, or the hit during the line of sight check was the target.
