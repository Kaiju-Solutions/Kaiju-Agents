# KaijuAgentsArcRaycast

Extension methods to perform ray casting along an arc. Any Vector2 values will be expanded via the KaijuAgentsExpand.Expand method.

~~~csharp
public static class KaijuAgentsArcRaycast
~~~

[Package source](../../Runtime/Extensions/KaijuAgentsArcRaycast.cs)

<a id="KaijuSolutions_Agents_Extensions_KaijuAgentsArcRaycast_ArcRaycast"></a>

### ArcRaycast

~~~csharp
public static int ArcRaycast (this Vector2 position, Vector2 direction, [NotNull] RaycastHit?[] hits, float angle = 360f, float distance = float.MaxValue, int mask = KaijuMovementConfiguration.DefaultMask, QueryTriggerInteraction triggers = QueryTriggerInteraction.UseGlobal)
~~~

Perform multiple raycasts given by the length of the hits array evenly spread across the angle given.

~~~csharp
public static int ArcRaycast (this Vector2 position, Vector3 direction, [NotNull] RaycastHit?[] hits, float angle = 360f, float distance = float.MaxValue, int mask = KaijuMovementConfiguration.DefaultMask, QueryTriggerInteraction triggers = QueryTriggerInteraction.UseGlobal)
~~~

Perform multiple raycasts given by the length of the hits array evenly spread across the angle given.

~~~csharp
public static int ArcRaycast (this Vector2 position, [NotNull] Transform direction, [NotNull] RaycastHit?[] hits, float angle = 360f, float distance = float.MaxValue, int mask = KaijuMovementConfiguration.DefaultMask, QueryTriggerInteraction triggers = QueryTriggerInteraction.UseGlobal)
~~~

Perform multiple raycasts given by the length of the hits array evenly spread across the angle given.

~~~csharp
public static int ArcRaycast (this Vector2 position, [NotNull] Component direction, [NotNull] RaycastHit?[] hits, float angle = 360f, float distance = float.MaxValue, int mask = KaijuMovementConfiguration.DefaultMask, QueryTriggerInteraction triggers = QueryTriggerInteraction.UseGlobal)
~~~

Perform multiple raycasts given by the length of the hits array evenly spread across the angle given.

~~~csharp
public static int ArcRaycast (this Vector2 position, [NotNull] GameObject direction, [NotNull] RaycastHit?[] hits, float angle = 360f, float distance = float.MaxValue, int mask = KaijuMovementConfiguration.DefaultMask, QueryTriggerInteraction triggers = QueryTriggerInteraction.UseGlobal)
~~~

Perform multiple raycasts given by the length of the hits array evenly spread across the angle given.

~~~csharp
public static int ArcRaycast (this Vector3 position, Vector2 direction, [NotNull] RaycastHit?[] hits, float angle = 360f, float distance = float.MaxValue, int mask = KaijuMovementConfiguration.DefaultMask, QueryTriggerInteraction triggers = QueryTriggerInteraction.UseGlobal)
~~~

Perform multiple raycasts given by the length of the hits array evenly spread across the angle given.

~~~csharp
public static int ArcRaycast (this Vector3 position, Vector3 direction, [NotNull] RaycastHit?[] hits, float angle = 360f, float distance = float.MaxValue, int mask = KaijuMovementConfiguration.DefaultMask, QueryTriggerInteraction triggers = QueryTriggerInteraction.UseGlobal)
~~~

Perform multiple raycasts given by the length of the hits array evenly spread across the angle given.

~~~csharp
public static int ArcRaycast (this Vector3 position, [NotNull] Transform direction, [NotNull] RaycastHit?[] hits, float angle = 360f, float distance = float.MaxValue, int mask = KaijuMovementConfiguration.DefaultMask, QueryTriggerInteraction triggers = QueryTriggerInteraction.UseGlobal)
~~~

Perform multiple raycasts given by the length of the hits array evenly spread across the angle given.

~~~csharp
public static int ArcRaycast (this Vector3 position, [NotNull] Component direction, [NotNull] RaycastHit?[] hits, float angle = 360f, float distance = float.MaxValue, int mask = KaijuMovementConfiguration.DefaultMask, QueryTriggerInteraction triggers = QueryTriggerInteraction.UseGlobal)
~~~

Perform multiple raycasts given by the length of the hits array evenly spread across the angle given.

~~~csharp
public static int ArcRaycast (this Vector3 position, [NotNull] GameObject direction, [NotNull] RaycastHit?[] hits, float angle = 360f, float distance = float.MaxValue, int mask = KaijuMovementConfiguration.DefaultMask, QueryTriggerInteraction triggers = QueryTriggerInteraction.UseGlobal)
~~~

Perform multiple raycasts given by the length of the hits array evenly spread across the angle given.

~~~csharp
public static int ArcRaycast ([NotNull] this Transform position, Vector2 direction, [NotNull] RaycastHit?[] hits, float angle = 360f, float distance = float.MaxValue, int mask = KaijuMovementConfiguration.DefaultMask, QueryTriggerInteraction triggers = QueryTriggerInteraction.UseGlobal)
~~~

Perform multiple raycasts given by the length of the hits array evenly spread across the angle given.

~~~csharp
public static int ArcRaycast ([NotNull] this Transform position, Vector3 direction, [NotNull] RaycastHit?[] hits, float angle = 360f, float distance = float.MaxValue, int mask = KaijuMovementConfiguration.DefaultMask, QueryTriggerInteraction triggers = QueryTriggerInteraction.UseGlobal)
~~~

Perform multiple raycasts given by the length of the hits array evenly spread across the angle given.

~~~csharp
public static int ArcRaycast ([NotNull] this Transform position, [NotNull] Transform direction, [NotNull] RaycastHit?[] hits, float angle = 360f, float distance = float.MaxValue, int mask = KaijuMovementConfiguration.DefaultMask, QueryTriggerInteraction triggers = QueryTriggerInteraction.UseGlobal)
~~~

Perform multiple raycasts given by the length of the hits array evenly spread across the angle given.

~~~csharp
public static int ArcRaycast ([NotNull] this Transform position, [NotNull] Component direction, [NotNull] RaycastHit?[] hits, float angle = 360f, float distance = float.MaxValue, int mask = KaijuMovementConfiguration.DefaultMask, QueryTriggerInteraction triggers = QueryTriggerInteraction.UseGlobal)
~~~

Perform multiple raycasts given by the length of the hits array evenly spread across the angle given.

~~~csharp
public static int ArcRaycast ([NotNull] this Transform position, [NotNull] GameObject direction, [NotNull] RaycastHit?[] hits, float angle = 360f, float distance = float.MaxValue, int mask = KaijuMovementConfiguration.DefaultMask, QueryTriggerInteraction triggers = QueryTriggerInteraction.UseGlobal)
~~~

Perform multiple raycasts given by the length of the hits array evenly spread across the angle given.

~~~csharp
public static int ArcRaycast ([NotNull] this Transform position, [NotNull] RaycastHit?[] hits, float angle = 360f, float distance = float.MaxValue, int mask = KaijuMovementConfiguration.DefaultMask, QueryTriggerInteraction triggers = QueryTriggerInteraction.UseGlobal)
~~~

Perform multiple raycasts given by the length of the hits array evenly spread across the angle given.

~~~csharp
public static int ArcRaycast ([NotNull] this Component position, Vector2 direction, [NotNull] RaycastHit?[] hits, float angle = 360f, float distance = float.MaxValue, int mask = KaijuMovementConfiguration.DefaultMask, QueryTriggerInteraction triggers = QueryTriggerInteraction.UseGlobal)
~~~

Perform multiple raycasts given by the length of the hits array evenly spread across the angle given.

~~~csharp
public static int ArcRaycast ([NotNull] this Component position, Vector3 direction, [NotNull] RaycastHit?[] hits, float angle = 360f, float distance = float.MaxValue, int mask = KaijuMovementConfiguration.DefaultMask, QueryTriggerInteraction triggers = QueryTriggerInteraction.UseGlobal)
~~~

Perform multiple raycasts given by the length of the hits array evenly spread across the angle given.

~~~csharp
public static int ArcRaycast ([NotNull] this Component position, [NotNull] Transform direction, [NotNull] RaycastHit?[] hits, float angle = 360f, float distance = float.MaxValue, int mask = KaijuMovementConfiguration.DefaultMask, QueryTriggerInteraction triggers = QueryTriggerInteraction.UseGlobal)
~~~

Perform multiple raycasts given by the length of the hits array evenly spread across the angle given.

~~~csharp
public static int ArcRaycast ([NotNull] this Component position, [NotNull] Component direction, [NotNull] RaycastHit?[] hits, float angle = 360f, float distance = float.MaxValue, int mask = KaijuMovementConfiguration.DefaultMask, QueryTriggerInteraction triggers = QueryTriggerInteraction.UseGlobal)
~~~

Perform multiple raycasts given by the length of the hits array evenly spread across the angle given.

~~~csharp
public static int ArcRaycast ([NotNull] this Component position, [NotNull] GameObject direction, [NotNull] RaycastHit?[] hits, float angle = 360f, float distance = float.MaxValue, int mask = KaijuMovementConfiguration.DefaultMask, QueryTriggerInteraction triggers = QueryTriggerInteraction.UseGlobal)
~~~

Perform multiple raycasts given by the length of the hits array evenly spread across the angle given.

~~~csharp
public static int ArcRaycast ([NotNull] this Component position, [NotNull] RaycastHit?[] hits, float angle = 360f, float distance = float.MaxValue, int mask = KaijuMovementConfiguration.DefaultMask, QueryTriggerInteraction triggers = QueryTriggerInteraction.UseGlobal)
~~~

Perform multiple raycasts given by the length of the hits array evenly spread across the angle given.

~~~csharp
public static int ArcRaycast ([NotNull] this GameObject position, Vector2 direction, [NotNull] RaycastHit?[] hits, float angle = 360f, float distance = float.MaxValue, int mask = KaijuMovementConfiguration.DefaultMask, QueryTriggerInteraction triggers = QueryTriggerInteraction.UseGlobal)
~~~

Perform multiple raycasts given by the length of the hits array evenly spread across the angle given.

~~~csharp
public static int ArcRaycast ([NotNull] this GameObject position, Vector3 direction, [NotNull] RaycastHit?[] hits, float angle = 360f, float distance = float.MaxValue, int mask = KaijuMovementConfiguration.DefaultMask, QueryTriggerInteraction triggers = QueryTriggerInteraction.UseGlobal)
~~~

Perform multiple raycasts given by the length of the hits array evenly spread across the angle given.

~~~csharp
public static int ArcRaycast ([NotNull] this GameObject position, [NotNull] Transform direction, [NotNull] RaycastHit?[] hits, float angle = 360f, float distance = float.MaxValue, int mask = KaijuMovementConfiguration.DefaultMask, QueryTriggerInteraction triggers = QueryTriggerInteraction.UseGlobal)
~~~

Perform multiple raycasts given by the length of the hits array evenly spread across the angle given.

~~~csharp
public static int ArcRaycast ([NotNull] this GameObject position, [NotNull] Component direction, [NotNull] RaycastHit?[] hits, float angle = 360f, float distance = float.MaxValue, int mask = KaijuMovementConfiguration.DefaultMask, QueryTriggerInteraction triggers = QueryTriggerInteraction.UseGlobal)
~~~

Perform multiple raycasts given by the length of the hits array evenly spread across the angle given.

~~~csharp
public static int ArcRaycast ([NotNull] this GameObject position, [NotNull] GameObject direction, [NotNull] RaycastHit?[] hits, float angle = 360f, float distance = float.MaxValue, int mask = KaijuMovementConfiguration.DefaultMask, QueryTriggerInteraction triggers = QueryTriggerInteraction.UseGlobal)
~~~

Perform multiple raycasts given by the length of the hits array evenly spread across the angle given.

~~~csharp
public static int ArcRaycast ([NotNull] this GameObject position, [NotNull] RaycastHit?[] hits, float angle = 360f, float distance = float.MaxValue, int mask = KaijuMovementConfiguration.DefaultMask, QueryTriggerInteraction triggers = QueryTriggerInteraction.UseGlobal)
~~~

Perform multiple raycasts given by the length of the hits array evenly spread across the angle given.
