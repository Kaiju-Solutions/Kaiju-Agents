# KaijuAgentsArcSphereCast

Extension methods to perform sphere casting along an arc. Any Vector2 values will be expanded via the KaijuAgentsExpand.Expand method.

~~~csharp
public static class KaijuAgentsArcSphereCast
~~~

[Package source](../../Runtime/Extensions/KaijuAgentsArcSphereCast.cs)

<a id="KaijuSolutions_Agents_Extensions_KaijuAgentsArcSphereCast_ArcSphereCast"></a>

### ArcSphereCast

~~~csharp
public static int ArcSphereCast (this Vector2 position, Vector2 direction, float radius, [NotNull] RaycastHit?[] hits, float angle = 360f, float distance = float.MaxValue, int mask = KaijuMovementConfiguration.DefaultMask, QueryTriggerInteraction triggers = QueryTriggerInteraction.UseGlobal)
~~~

Perform multiple sphere casts given by the length of the hits array evenly spread across the angle given.

~~~csharp
public static int ArcSphereCast (this Vector2 position, Vector3 direction, float radius, [NotNull] RaycastHit?[] hits, float angle = 360f, float distance = float.MaxValue, int mask = KaijuMovementConfiguration.DefaultMask, QueryTriggerInteraction triggers = QueryTriggerInteraction.UseGlobal)
~~~

Perform multiple sphere casts given by the length of the hits array evenly spread across the angle given.

~~~csharp
public static int ArcSphereCast (this Vector2 position, [NotNull] Transform direction, float radius, [NotNull] RaycastHit?[] hits, float angle = 360f, float distance = float.MaxValue, int mask = KaijuMovementConfiguration.DefaultMask, QueryTriggerInteraction triggers = QueryTriggerInteraction.UseGlobal)
~~~

Perform multiple sphere casts given by the length of the hits array evenly spread across the angle given.

~~~csharp
public static int ArcSphereCast (this Vector2 position, [NotNull] Component direction, float radius, [NotNull] RaycastHit?[] hits, float angle = 360f, float distance = float.MaxValue, int mask = KaijuMovementConfiguration.DefaultMask, QueryTriggerInteraction triggers = QueryTriggerInteraction.UseGlobal)
~~~

Perform multiple sphere casts given by the length of the hits array evenly spread across the angle given.

~~~csharp
public static int ArcSphereCast (this Vector2 position, [NotNull] GameObject direction, float radius, [NotNull] RaycastHit?[] hits, float angle = 360f, float distance = float.MaxValue, int mask = KaijuMovementConfiguration.DefaultMask, QueryTriggerInteraction triggers = QueryTriggerInteraction.UseGlobal)
~~~

Perform multiple sphere casts given by the length of the hits array evenly spread across the angle given.

~~~csharp
public static int ArcSphereCast (this Vector3 position, Vector2 direction, float radius, [NotNull] RaycastHit?[] hits, float angle = 360f, float distance = float.MaxValue, int mask = KaijuMovementConfiguration.DefaultMask, QueryTriggerInteraction triggers = QueryTriggerInteraction.UseGlobal)
~~~

Perform multiple sphere casts given by the length of the hits array evenly spread across the angle given.

~~~csharp
public static int ArcSphereCast (this Vector3 position, Vector3 direction, float radius, [NotNull] RaycastHit?[] hits, float angle = 360f, float distance = float.MaxValue, int mask = KaijuMovementConfiguration.DefaultMask, QueryTriggerInteraction triggers = QueryTriggerInteraction.UseGlobal)
~~~

Perform multiple sphere casts given by the length of the hits array evenly spread across the angle given.

~~~csharp
public static int ArcSphereCast (this Vector3 position, [NotNull] Transform direction, float radius, [NotNull] RaycastHit?[] hits, float angle = 360f, float distance = float.MaxValue, int mask = KaijuMovementConfiguration.DefaultMask, QueryTriggerInteraction triggers = QueryTriggerInteraction.UseGlobal)
~~~

Perform multiple sphere casts given by the length of the hits array evenly spread across the angle given.

~~~csharp
public static int ArcSphereCast (this Vector3 position, [NotNull] Component direction, float radius, [NotNull] RaycastHit?[] hits, float angle = 360f, float distance = float.MaxValue, int mask = KaijuMovementConfiguration.DefaultMask, QueryTriggerInteraction triggers = QueryTriggerInteraction.UseGlobal)
~~~

Perform multiple sphere casts given by the length of the hits array evenly spread across the angle given.

~~~csharp
public static int ArcSphereCast (this Vector3 position, [NotNull] GameObject direction, float radius, [NotNull] RaycastHit?[] hits, float angle = 360f, float distance = float.MaxValue, int mask = KaijuMovementConfiguration.DefaultMask, QueryTriggerInteraction triggers = QueryTriggerInteraction.UseGlobal)
~~~

Perform multiple sphere casts given by the length of the hits array evenly spread across the angle given.

~~~csharp
public static int ArcSphereCast ([NotNull] this Transform position, Vector2 direction, float radius, [NotNull] RaycastHit?[] hits, float angle = 360f, float distance = float.MaxValue, int mask = KaijuMovementConfiguration.DefaultMask, QueryTriggerInteraction triggers = QueryTriggerInteraction.UseGlobal)
~~~

Perform multiple sphere casts given by the length of the hits array evenly spread across the angle given.

~~~csharp
public static int ArcSphereCast ([NotNull] this Transform position, Vector3 direction, float radius, [NotNull] RaycastHit?[] hits, float angle = 360f, float distance = float.MaxValue, int mask = KaijuMovementConfiguration.DefaultMask, QueryTriggerInteraction triggers = QueryTriggerInteraction.UseGlobal)
~~~

Perform multiple sphere casts given by the length of the hits array evenly spread across the angle given.

~~~csharp
public static int ArcSphereCast ([NotNull] this Transform position, [NotNull] Transform direction, float radius, [NotNull] RaycastHit?[] hits, float angle = 360f, float distance = float.MaxValue, int mask = KaijuMovementConfiguration.DefaultMask, QueryTriggerInteraction triggers = QueryTriggerInteraction.UseGlobal)
~~~

Perform multiple sphere casts given by the length of the hits array evenly spread across the angle given.

~~~csharp
public static int ArcSphereCast ([NotNull] this Transform position, [NotNull] Component direction, float radius, [NotNull] RaycastHit?[] hits, float angle = 360f, float distance = float.MaxValue, int mask = KaijuMovementConfiguration.DefaultMask, QueryTriggerInteraction triggers = QueryTriggerInteraction.UseGlobal)
~~~

Perform multiple sphere casts given by the length of the hits array evenly spread across the angle given.

~~~csharp
public static int ArcSphereCast ([NotNull] this Transform position, [NotNull] GameObject direction, float radius, [NotNull] RaycastHit?[] hits, float angle = 360f, float distance = float.MaxValue, int mask = KaijuMovementConfiguration.DefaultMask, QueryTriggerInteraction triggers = QueryTriggerInteraction.UseGlobal)
~~~

Perform multiple sphere casts given by the length of the hits array evenly spread across the angle given.

~~~csharp
public static int ArcSphereCast ([NotNull] this Transform position, float radius, [NotNull] RaycastHit?[] hits, float angle = 360f, float distance = float.MaxValue, int mask = KaijuMovementConfiguration.DefaultMask, QueryTriggerInteraction triggers = QueryTriggerInteraction.UseGlobal)
~~~

Perform multiple sphere casts given by the length of the hits array evenly spread across the angle given.

~~~csharp
public static int ArcSphereCast ([NotNull] this Component position, Vector2 direction, float radius, [NotNull] RaycastHit?[] hits, float angle = 360f, float distance = float.MaxValue, int mask = KaijuMovementConfiguration.DefaultMask, QueryTriggerInteraction triggers = QueryTriggerInteraction.UseGlobal)
~~~

Perform multiple sphere casts given by the length of the hits array evenly spread across the angle given.

~~~csharp
public static int ArcSphereCast ([NotNull] this Component position, Vector3 direction, float radius, [NotNull] RaycastHit?[] hits, float angle = 360f, float distance = float.MaxValue, int mask = KaijuMovementConfiguration.DefaultMask, QueryTriggerInteraction triggers = QueryTriggerInteraction.UseGlobal)
~~~

Perform multiple sphere casts given by the length of the hits array evenly spread across the angle given.

~~~csharp
public static int ArcSphereCast ([NotNull] this Component position, [NotNull] Transform direction, float radius, [NotNull] RaycastHit?[] hits, float angle = 360f, float distance = float.MaxValue, int mask = KaijuMovementConfiguration.DefaultMask, QueryTriggerInteraction triggers = QueryTriggerInteraction.UseGlobal)
~~~

Perform multiple sphere casts given by the length of the hits array evenly spread across the angle given.

~~~csharp
public static int ArcSphereCast ([NotNull] this Component position, [NotNull] Component direction, float radius, [NotNull] RaycastHit?[] hits, float angle = 360f, float distance = float.MaxValue, int mask = KaijuMovementConfiguration.DefaultMask, QueryTriggerInteraction triggers = QueryTriggerInteraction.UseGlobal)
~~~

Perform multiple sphere casts given by the length of the hits array evenly spread across the angle given.

~~~csharp
public static int ArcSphereCast ([NotNull] this Component position, [NotNull] GameObject direction, float radius, [NotNull] RaycastHit?[] hits, float angle = 360f, float distance = float.MaxValue, int mask = KaijuMovementConfiguration.DefaultMask, QueryTriggerInteraction triggers = QueryTriggerInteraction.UseGlobal)
~~~

Perform multiple sphere casts given by the length of the hits array evenly spread across the angle given.

~~~csharp
public static int ArcSphereCast ([NotNull] this Component position, float radius, [NotNull] RaycastHit?[] hits, float angle = 360f, float distance = float.MaxValue, int mask = KaijuMovementConfiguration.DefaultMask, QueryTriggerInteraction triggers = QueryTriggerInteraction.UseGlobal)
~~~

Perform multiple sphere casts given by the length of the hits array evenly spread across the angle given.

~~~csharp
public static int ArcSphereCast ([NotNull] this GameObject position, Vector2 direction, float radius, [NotNull] RaycastHit?[] hits, float angle = 360f, float distance = float.MaxValue, int mask = KaijuMovementConfiguration.DefaultMask, QueryTriggerInteraction triggers = QueryTriggerInteraction.UseGlobal)
~~~

Perform multiple sphere casts given by the length of the hits array evenly spread across the angle given.

~~~csharp
public static int ArcSphereCast ([NotNull] this GameObject position, Vector3 direction, float radius, [NotNull] RaycastHit?[] hits, float angle = 360f, float distance = float.MaxValue, int mask = KaijuMovementConfiguration.DefaultMask, QueryTriggerInteraction triggers = QueryTriggerInteraction.UseGlobal)
~~~

Perform multiple sphere casts given by the length of the hits array evenly spread across the angle given.

~~~csharp
public static int ArcSphereCast ([NotNull] this GameObject position, [NotNull] Transform direction, float radius, [NotNull] RaycastHit?[] hits, float angle = 360f, float distance = float.MaxValue, int mask = KaijuMovementConfiguration.DefaultMask, QueryTriggerInteraction triggers = QueryTriggerInteraction.UseGlobal)
~~~

Perform multiple sphere casts given by the length of the hits array evenly spread across the angle given.

~~~csharp
public static int ArcSphereCast ([NotNull] this GameObject position, [NotNull] Component direction, float radius, [NotNull] RaycastHit?[] hits, float angle = 360f, float distance = float.MaxValue, int mask = KaijuMovementConfiguration.DefaultMask, QueryTriggerInteraction triggers = QueryTriggerInteraction.UseGlobal)
~~~

Perform multiple sphere casts given by the length of the hits array evenly spread across the angle given.

~~~csharp
public static int ArcSphereCast ([NotNull] this GameObject position, [NotNull] GameObject direction, float radius, [NotNull] RaycastHit?[] hits, float angle = 360f, float distance = float.MaxValue, int mask = KaijuMovementConfiguration.DefaultMask, QueryTriggerInteraction triggers = QueryTriggerInteraction.UseGlobal)
~~~

Perform multiple sphere casts given by the length of the hits array evenly spread across the angle given.

~~~csharp
public static int ArcSphereCast ([NotNull] this GameObject position, float radius, [NotNull] RaycastHit?[] hits, float angle = 360f, float distance = float.MaxValue, int mask = KaijuMovementConfiguration.DefaultMask, QueryTriggerInteraction triggers = QueryTriggerInteraction.UseGlobal)
~~~

Perform multiple sphere casts given by the length of the hits array evenly spread across the angle given.
