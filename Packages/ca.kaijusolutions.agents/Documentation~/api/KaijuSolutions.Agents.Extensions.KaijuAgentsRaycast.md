# KaijuAgentsRaycast

Extension methods to perform ray casting. Any Vector2 values will be expanded via the KaijuAgentsExpand.Expand method.

~~~csharp
public static class KaijuAgentsRaycast
~~~

[Package source](../../Runtime/Extensions/KaijuAgentsRaycast.cs)

<a id="KaijuSolutions_Agents_Extensions_KaijuAgentsRaycast_Raycast"></a>

### Raycast

~~~csharp
public static bool Raycast (this Vector2 position, Vector2 direction, out RaycastHit hit, float distance = float.MaxValue, int mask = KaijuMovementConfiguration.DefaultMask, QueryTriggerInteraction triggers = QueryTriggerInteraction.UseGlobal)
~~~

Perform a raycast.

~~~csharp
public static bool Raycast (this Vector2 position, Vector3 direction, out RaycastHit hit, float distance = float.MaxValue, int mask = KaijuMovementConfiguration.DefaultMask, QueryTriggerInteraction triggers = QueryTriggerInteraction.UseGlobal)
~~~

Perform a raycast.

~~~csharp
public static bool Raycast (this Vector2 position, [NotNull] Transform direction, out RaycastHit hit, float distance = float.MaxValue, int mask = KaijuMovementConfiguration.DefaultMask, QueryTriggerInteraction triggers = QueryTriggerInteraction.UseGlobal)
~~~

Perform a raycast.

~~~csharp
public static bool Raycast (this Vector2 position, [NotNull] Component direction, out RaycastHit hit, float distance = float.MaxValue, int mask = KaijuMovementConfiguration.DefaultMask, QueryTriggerInteraction triggers = QueryTriggerInteraction.UseGlobal)
~~~

Perform a raycast.

~~~csharp
public static bool Raycast (this Vector2 position, [NotNull] GameObject direction, out RaycastHit hit, float distance = float.MaxValue, int mask = KaijuMovementConfiguration.DefaultMask, QueryTriggerInteraction triggers = QueryTriggerInteraction.UseGlobal)
~~~

Perform a raycast.

~~~csharp
public static bool Raycast (this Vector3 position, Vector2 direction, out RaycastHit hit, float distance = float.MaxValue, int mask = KaijuMovementConfiguration.DefaultMask, QueryTriggerInteraction triggers = QueryTriggerInteraction.UseGlobal)
~~~

Perform a raycast.

~~~csharp
public static bool Raycast (this Vector3 position, Vector3 direction, out RaycastHit hit, float distance = float.MaxValue, int mask = KaijuMovementConfiguration.DefaultMask, QueryTriggerInteraction triggers = QueryTriggerInteraction.UseGlobal)
~~~

Perform a raycast.

~~~csharp
public static bool Raycast (this Vector3 position, [NotNull] Transform direction, out RaycastHit hit, float distance = float.MaxValue, int mask = KaijuMovementConfiguration.DefaultMask, QueryTriggerInteraction triggers = QueryTriggerInteraction.UseGlobal)
~~~

Perform a raycast.

~~~csharp
public static bool Raycast (this Vector3 position, [NotNull] Component direction, out RaycastHit hit, float distance = float.MaxValue, int mask = KaijuMovementConfiguration.DefaultMask, QueryTriggerInteraction triggers = QueryTriggerInteraction.UseGlobal)
~~~

Perform a raycast.

~~~csharp
public static bool Raycast (this Vector3 position, [NotNull] GameObject direction, out RaycastHit hit, float distance = float.MaxValue, int mask = KaijuMovementConfiguration.DefaultMask, QueryTriggerInteraction triggers = QueryTriggerInteraction.UseGlobal)
~~~

Perform a raycast.

~~~csharp
public static bool Raycast ([NotNull] this Transform position, Vector2 direction, out RaycastHit hit, float distance = float.MaxValue, int mask = KaijuMovementConfiguration.DefaultMask, QueryTriggerInteraction triggers = QueryTriggerInteraction.UseGlobal)
~~~

Perform a raycast.

~~~csharp
public static bool Raycast ([NotNull] this Transform position, Vector3 direction, out RaycastHit hit, float distance = float.MaxValue, int mask = KaijuMovementConfiguration.DefaultMask, QueryTriggerInteraction triggers = QueryTriggerInteraction.UseGlobal)
~~~

Perform a raycast.

~~~csharp
public static bool Raycast ([NotNull] this Transform position, [NotNull] Transform direction, out RaycastHit hit, float distance = float.MaxValue, int mask = KaijuMovementConfiguration.DefaultMask, QueryTriggerInteraction triggers = QueryTriggerInteraction.UseGlobal)
~~~

Perform a raycast.

~~~csharp
public static bool Raycast ([NotNull] this Transform position, [NotNull] Component direction, out RaycastHit hit, float distance = float.MaxValue, int mask = KaijuMovementConfiguration.DefaultMask, QueryTriggerInteraction triggers = QueryTriggerInteraction.UseGlobal)
~~~

Perform a raycast.

~~~csharp
public static bool Raycast ([NotNull] this Transform position, [NotNull] GameObject direction, out RaycastHit hit, float distance = float.MaxValue, int mask = KaijuMovementConfiguration.DefaultMask, QueryTriggerInteraction triggers = QueryTriggerInteraction.UseGlobal)
~~~

Perform a raycast.

~~~csharp
public static bool Raycast ([NotNull] this Transform position, out RaycastHit hit, float distance = float.MaxValue, int mask = KaijuMovementConfiguration.DefaultMask, QueryTriggerInteraction triggers = QueryTriggerInteraction.UseGlobal)
~~~

Perform a raycast in the forward direction.

~~~csharp
public static bool Raycast ([NotNull] this Component position, Vector2 direction, out RaycastHit hit, float distance = float.MaxValue, int mask = KaijuMovementConfiguration.DefaultMask, QueryTriggerInteraction triggers = QueryTriggerInteraction.UseGlobal)
~~~

Perform a raycast.

~~~csharp
public static bool Raycast ([NotNull] this Component position, Vector3 direction, out RaycastHit hit, float distance = float.MaxValue, int mask = KaijuMovementConfiguration.DefaultMask, QueryTriggerInteraction triggers = QueryTriggerInteraction.UseGlobal)
~~~

Perform a raycast.

~~~csharp
public static bool Raycast ([NotNull] this Component position, [NotNull] Transform direction, out RaycastHit hit, float distance = float.MaxValue, int mask = KaijuMovementConfiguration.DefaultMask, QueryTriggerInteraction triggers = QueryTriggerInteraction.UseGlobal)
~~~

Perform a raycast.

~~~csharp
public static bool Raycast ([NotNull] this Component position, [NotNull] Component direction, out RaycastHit hit, float distance = float.MaxValue, int mask = KaijuMovementConfiguration.DefaultMask, QueryTriggerInteraction triggers = QueryTriggerInteraction.UseGlobal)
~~~

Perform a raycast.

~~~csharp
public static bool Raycast ([NotNull] this Component position, [NotNull] GameObject direction, out RaycastHit hit, float distance = float.MaxValue, int mask = KaijuMovementConfiguration.DefaultMask, QueryTriggerInteraction triggers = QueryTriggerInteraction.UseGlobal)
~~~

Perform a raycast.

~~~csharp
public static bool Raycast ([NotNull] this Component position, out RaycastHit hit, float distance = float.MaxValue, int mask = KaijuMovementConfiguration.DefaultMask, QueryTriggerInteraction triggers = QueryTriggerInteraction.UseGlobal)
~~~

Perform a raycast in the forward direction.

~~~csharp
public static bool Raycast ([NotNull] this GameObject position, Vector2 direction, out RaycastHit hit, float distance = float.MaxValue, int mask = KaijuMovementConfiguration.DefaultMask, QueryTriggerInteraction triggers = QueryTriggerInteraction.UseGlobal)
~~~

Perform a raycast.

~~~csharp
public static bool Raycast ([NotNull] this GameObject position, Vector3 direction, out RaycastHit hit, float distance = float.MaxValue, int mask = KaijuMovementConfiguration.DefaultMask, QueryTriggerInteraction triggers = QueryTriggerInteraction.UseGlobal)
~~~

Perform a raycast.

~~~csharp
public static bool Raycast ([NotNull] this GameObject position, [NotNull] Transform direction, out RaycastHit hit, float distance = float.MaxValue, int mask = KaijuMovementConfiguration.DefaultMask, QueryTriggerInteraction triggers = QueryTriggerInteraction.UseGlobal)
~~~

Perform a raycast.

~~~csharp
public static bool Raycast ([NotNull] this GameObject position, [NotNull] Component direction, out RaycastHit hit, float distance = float.MaxValue, int mask = KaijuMovementConfiguration.DefaultMask, QueryTriggerInteraction triggers = QueryTriggerInteraction.UseGlobal)
~~~

Perform a raycast.

~~~csharp
public static bool Raycast ([NotNull] this GameObject position, [NotNull] GameObject direction, out RaycastHit hit, float distance = float.MaxValue, int mask = KaijuMovementConfiguration.DefaultMask, QueryTriggerInteraction triggers = QueryTriggerInteraction.UseGlobal)
~~~

Perform a raycast.

~~~csharp
public static bool Raycast ([NotNull] this GameObject position, out RaycastHit hit, float distance = float.MaxValue, int mask = KaijuMovementConfiguration.DefaultMask, QueryTriggerInteraction triggers = QueryTriggerInteraction.UseGlobal)
~~~

Perform a raycast in the forward direction.
