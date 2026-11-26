# KaijuAgentsSphereCast

Extension methods to perform sphere casting. Any Vector2 values will be expanded via the KaijuAgentsExpand.Expand method.

~~~csharp
public static class KaijuAgentsSphereCast
~~~

[Package source](../../Runtime/Extensions/KaijuAgentsSphereCast.cs)

<a id="KaijuSolutions_Agents_Extensions_KaijuAgentsSphereCast_SphereCast"></a>

### SphereCast

~~~csharp
public static bool SphereCast (this Vector2 position, Vector2 direction, float radius, out RaycastHit hit, float distance = float.MaxValue, int mask = KaijuMovementConfiguration.DefaultMask, QueryTriggerInteraction triggers = QueryTriggerInteraction.UseGlobal)
~~~

Perform a sphere cast.

~~~csharp
public static bool SphereCast (this Vector2 position, Vector3 direction, float radius, out RaycastHit hit, float distance = float.MaxValue, int mask = KaijuMovementConfiguration.DefaultMask, QueryTriggerInteraction triggers = QueryTriggerInteraction.UseGlobal)
~~~

Perform a sphere cast.

~~~csharp
public static bool SphereCast (this Vector2 position, [NotNull] Transform direction, float radius, out RaycastHit hit, float distance = float.MaxValue, int mask = KaijuMovementConfiguration.DefaultMask, QueryTriggerInteraction triggers = QueryTriggerInteraction.UseGlobal)
~~~

Perform a sphere cast.

~~~csharp
public static bool SphereCast (this Vector2 position, [NotNull] Component direction, float radius, out RaycastHit hit, float distance = float.MaxValue, int mask = KaijuMovementConfiguration.DefaultMask, QueryTriggerInteraction triggers = QueryTriggerInteraction.UseGlobal)
~~~

Perform a sphere cast.

~~~csharp
public static bool SphereCast (this Vector2 position, [NotNull] GameObject direction, float radius, out RaycastHit hit, float distance = float.MaxValue, int mask = KaijuMovementConfiguration.DefaultMask, QueryTriggerInteraction triggers = QueryTriggerInteraction.UseGlobal)
~~~

Perform a sphere cast.

~~~csharp
public static bool SphereCast (this Vector3 position, Vector2 direction, float radius, out RaycastHit hit, float distance = float.MaxValue, int mask = KaijuMovementConfiguration.DefaultMask, QueryTriggerInteraction triggers = QueryTriggerInteraction.UseGlobal)
~~~

Perform a sphere cast.

~~~csharp
public static bool SphereCast (this Vector3 position, Vector3 direction, float radius, out RaycastHit hit, float distance = float.MaxValue, int mask = KaijuMovementConfiguration.DefaultMask, QueryTriggerInteraction triggers = QueryTriggerInteraction.UseGlobal)
~~~

Perform a sphere cast.

~~~csharp
public static bool SphereCast (this Vector3 position, [NotNull] Transform direction, float radius, out RaycastHit hit, float distance = float.MaxValue, int mask = KaijuMovementConfiguration.DefaultMask, QueryTriggerInteraction triggers = QueryTriggerInteraction.UseGlobal)
~~~

Perform a sphere cast.

~~~csharp
public static bool SphereCast (this Vector3 position, [NotNull] Component direction, float radius, out RaycastHit hit, float distance = float.MaxValue, int mask = KaijuMovementConfiguration.DefaultMask, QueryTriggerInteraction triggers = QueryTriggerInteraction.UseGlobal)
~~~

Perform a sphere cast.

~~~csharp
public static bool SphereCast (this Vector3 position, [NotNull] GameObject direction, float radius, out RaycastHit hit, float distance = float.MaxValue, int mask = KaijuMovementConfiguration.DefaultMask, QueryTriggerInteraction triggers = QueryTriggerInteraction.UseGlobal)
~~~

Perform a sphere cast.

~~~csharp
public static bool SphereCast ([NotNull] this Transform position, Vector2 direction, float radius, out RaycastHit hit, float distance = float.MaxValue, int mask = KaijuMovementConfiguration.DefaultMask, QueryTriggerInteraction triggers = QueryTriggerInteraction.UseGlobal)
~~~

Perform a sphere cast.

~~~csharp
public static bool SphereCast ([NotNull] this Transform position, Vector3 direction, float radius, out RaycastHit hit, float distance = float.MaxValue, int mask = KaijuMovementConfiguration.DefaultMask, QueryTriggerInteraction triggers = QueryTriggerInteraction.UseGlobal)
~~~

Perform a sphere cast.

~~~csharp
public static bool SphereCast ([NotNull] this Transform position, [NotNull] Transform direction, float radius, out RaycastHit hit, float distance = float.MaxValue, int mask = KaijuMovementConfiguration.DefaultMask, QueryTriggerInteraction triggers = QueryTriggerInteraction.UseGlobal)
~~~

Perform a sphere cast.

~~~csharp
public static bool SphereCast ([NotNull] this Transform position, [NotNull] Component direction, float radius, out RaycastHit hit, float distance = float.MaxValue, int mask = KaijuMovementConfiguration.DefaultMask, QueryTriggerInteraction triggers = QueryTriggerInteraction.UseGlobal)
~~~

Perform a sphere cast.

~~~csharp
public static bool SphereCast ([NotNull] this Transform position, [NotNull] GameObject direction, float radius, out RaycastHit hit, float distance = float.MaxValue, int mask = KaijuMovementConfiguration.DefaultMask, QueryTriggerInteraction triggers = QueryTriggerInteraction.UseGlobal)
~~~

Perform a sphere cast.

~~~csharp
public static bool SphereCast ([NotNull] this Transform position, float radius, out RaycastHit hit, float distance = float.MaxValue, int mask = KaijuMovementConfiguration.DefaultMask, QueryTriggerInteraction triggers = QueryTriggerInteraction.UseGlobal)
~~~

Perform a SphereCast in the forward direction.

~~~csharp
public static bool SphereCast ([NotNull] this Component position, Vector2 direction, float radius, out RaycastHit hit, float distance = float.MaxValue, int mask = KaijuMovementConfiguration.DefaultMask, QueryTriggerInteraction triggers = QueryTriggerInteraction.UseGlobal)
~~~

Perform a sphere cast.

~~~csharp
public static bool SphereCast ([NotNull] this Component position, Vector3 direction, float radius, out RaycastHit hit, float distance = float.MaxValue, int mask = KaijuMovementConfiguration.DefaultMask, QueryTriggerInteraction triggers = QueryTriggerInteraction.UseGlobal)
~~~

Perform a sphere cast.

~~~csharp
public static bool SphereCast ([NotNull] this Component position, [NotNull] Transform direction, float radius, out RaycastHit hit, float distance = float.MaxValue, int mask = KaijuMovementConfiguration.DefaultMask, QueryTriggerInteraction triggers = QueryTriggerInteraction.UseGlobal)
~~~

Perform a sphere cast.

~~~csharp
public static bool SphereCast ([NotNull] this Component position, [NotNull] Component direction, float radius, out RaycastHit hit, float distance = float.MaxValue, int mask = KaijuMovementConfiguration.DefaultMask, QueryTriggerInteraction triggers = QueryTriggerInteraction.UseGlobal)
~~~

Perform a sphere cast.

~~~csharp
public static bool SphereCast ([NotNull] this Component position, [NotNull] GameObject direction, float radius, out RaycastHit hit, float distance = float.MaxValue, int mask = KaijuMovementConfiguration.DefaultMask, QueryTriggerInteraction triggers = QueryTriggerInteraction.UseGlobal)
~~~

Perform a sphere cast.

~~~csharp
public static bool SphereCast ([NotNull] this Component position, float radius, out RaycastHit hit, float distance = float.MaxValue, int mask = KaijuMovementConfiguration.DefaultMask, QueryTriggerInteraction triggers = QueryTriggerInteraction.UseGlobal)
~~~

Perform a SphereCast in the forward direction.

~~~csharp
public static bool SphereCast ([NotNull] this GameObject position, Vector2 direction, float radius, out RaycastHit hit, float distance = float.MaxValue, int mask = KaijuMovementConfiguration.DefaultMask, QueryTriggerInteraction triggers = QueryTriggerInteraction.UseGlobal)
~~~

Perform a sphere cast.

~~~csharp
public static bool SphereCast ([NotNull] this GameObject position, Vector3 direction, float radius, out RaycastHit hit, float distance = float.MaxValue, int mask = KaijuMovementConfiguration.DefaultMask, QueryTriggerInteraction triggers = QueryTriggerInteraction.UseGlobal)
~~~

Perform a sphere cast.

~~~csharp
public static bool SphereCast ([NotNull] this GameObject position, [NotNull] Transform direction, float radius, out RaycastHit hit, float distance = float.MaxValue, int mask = KaijuMovementConfiguration.DefaultMask, QueryTriggerInteraction triggers = QueryTriggerInteraction.UseGlobal)
~~~

Perform a sphere cast.

~~~csharp
public static bool SphereCast ([NotNull] this GameObject position, [NotNull] Component direction, float radius, out RaycastHit hit, float distance = float.MaxValue, int mask = KaijuMovementConfiguration.DefaultMask, QueryTriggerInteraction triggers = QueryTriggerInteraction.UseGlobal)
~~~

Perform a sphere cast.

~~~csharp
public static bool SphereCast ([NotNull] this GameObject position, [NotNull] GameObject direction, float radius, out RaycastHit hit, float distance = float.MaxValue, int mask = KaijuMovementConfiguration.DefaultMask, QueryTriggerInteraction triggers = QueryTriggerInteraction.UseGlobal)
~~~

Perform a sphere cast.

~~~csharp
public static bool SphereCast ([NotNull] this GameObject position, float radius, out RaycastHit hit, float distance = float.MaxValue, int mask = KaijuMovementConfiguration.DefaultMask, QueryTriggerInteraction triggers = QueryTriggerInteraction.UseGlobal)
~~~

Perform a SphereCast in the forward direction.
