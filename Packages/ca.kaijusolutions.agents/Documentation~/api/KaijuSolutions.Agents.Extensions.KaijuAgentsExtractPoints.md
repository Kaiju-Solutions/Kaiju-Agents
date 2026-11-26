# KaijuAgentsExtractPoints

Extension methods to extract the point vectors from hits. These do not perform any actual casting. For casting, see KaijuAgentsArcRaycast and KaijuAgentsArcSphereCast. Any Vector2 values will be expanded via the KaijuAgentsExpand.Expand method.

~~~csharp
public static class KaijuAgentsExtractPoints
~~~

[Package source](../../Runtime/Extensions/KaijuAgentsExtractPoints.cs)

<a id="KaijuSolutions_Agents_Extensions_KaijuAgentsExtractPoints_ExtractPoints"></a>

### ExtractPoints

~~~csharp
public static void ExtractPoints (this Vector2 position, Vector2 direction, [NotNull] RaycastHit?[] hits, [NotNull] Vector3[] positions, float angle = 360f, float distance = float.MaxValue)
~~~

Extract the point vectors from hits. This does not perform any actual casting. For casting, see KaijuAgentsArcRaycast and KaijuAgentsArcSphereCast. This can be useful if your KaijuSolutions.Agents.KaijuAgent only needs position vectors or to help perform debugging.

~~~csharp
public static void ExtractPoints (this Vector2 position, Vector3 direction, [NotNull] RaycastHit?[] hits, [NotNull] Vector3[] positions, float angle = 360f, float distance = float.MaxValue)
~~~

Extract the point vectors from hits. This does not perform any actual casting. For casting, see KaijuAgentsArcRaycast and KaijuAgentsArcSphereCast. This can be useful if your KaijuSolutions.Agents.KaijuAgent only needs position vectors or to help perform debugging.

~~~csharp
public static void ExtractPoints (this Vector2 position, [NotNull] Transform direction, [NotNull] RaycastHit?[] hits, [NotNull] Vector3[] positions, float angle = 360f, float distance = float.MaxValue)
~~~

Extract the point vectors from hits. This does not perform any actual casting. For casting, see KaijuAgentsArcRaycast and KaijuAgentsArcSphereCast. This can be useful if your KaijuSolutions.Agents.KaijuAgent only needs position vectors or to help perform debugging.

~~~csharp
public static void ExtractPoints (this Vector2 position, [NotNull] Component direction, [NotNull] RaycastHit?[] hits, [NotNull] Vector3[] positions, float angle = 360f, float distance = float.MaxValue)
~~~

Extract the point vectors from hits. This does not perform any actual casting. For casting, see KaijuAgentsArcRaycast and KaijuAgentsArcSphereCast. This can be useful if your KaijuSolutions.Agents.KaijuAgent only needs position vectors or to help perform debugging.

~~~csharp
public static void ExtractPoints (this Vector2 position, [NotNull] GameObject direction, [NotNull] RaycastHit?[] hits, [NotNull] Vector3[] positions, float angle = 360f, float distance = float.MaxValue)
~~~

Extract the point vectors from hits. This does not perform any actual casting. For casting, see KaijuAgentsArcRaycast and KaijuAgentsArcSphereCast. This can be useful if your KaijuSolutions.Agents.KaijuAgent only needs position vectors or to help perform debugging.

~~~csharp
public static void ExtractPoints (this Vector3 position, Vector2 direction, [NotNull] RaycastHit?[] hits, [NotNull] Vector3[] positions, float angle = 360f, float distance = float.MaxValue)
~~~

Extract the point vectors from hits. This does not perform any actual casting. For casting, see KaijuAgentsArcRaycast and KaijuAgentsArcSphereCast. This can be useful if your KaijuSolutions.Agents.KaijuAgent only needs position vectors or to help perform debugging.

~~~csharp
public static void ExtractPoints (this Vector3 position, Vector3 direction, [NotNull] RaycastHit?[] hits, [NotNull] Vector3[] positions, float angle = 360f, float distance = float.MaxValue)
~~~

Extract the point vectors from hits. This does not perform any actual casting. For casting, see KaijuAgentsArcRaycast and KaijuAgentsArcSphereCast. This can be useful if your KaijuSolutions.Agents.KaijuAgent only needs position vectors or to help perform debugging.

~~~csharp
public static void ExtractPoints (this Vector3 position, [NotNull] Transform direction, [NotNull] RaycastHit?[] hits, [NotNull] Vector3[] positions, float angle = 360f, float distance = float.MaxValue)
~~~

Extract the point vectors from hits. This does not perform any actual casting. For casting, see KaijuAgentsArcRaycast and KaijuAgentsArcSphereCast. This can be useful if your KaijuSolutions.Agents.KaijuAgent only needs position vectors or to help perform debugging.

~~~csharp
public static void ExtractPoints (this Vector3 position, [NotNull] Component direction, [NotNull] RaycastHit?[] hits, [NotNull] Vector3[] positions, float angle = 360f, float distance = float.MaxValue)
~~~

Extract the point vectors from hits. This does not perform any actual casting. For casting, see KaijuAgentsArcRaycast and KaijuAgentsArcSphereCast. This can be useful if your KaijuSolutions.Agents.KaijuAgent only needs position vectors or to help perform debugging.

~~~csharp
public static void ExtractPoints (this Vector3 position, [NotNull] GameObject direction, [NotNull] RaycastHit?[] hits, [NotNull] Vector3[] positions, float angle = 360f, float distance = float.MaxValue)
~~~

Extract the point vectors from hits. This does not perform any actual casting. For casting, see KaijuAgentsArcRaycast and KaijuAgentsArcSphereCast. This can be useful if your KaijuSolutions.Agents.KaijuAgent only needs position vectors or to help perform debugging.

~~~csharp
public static void ExtractPoints ([NotNull] this Transform position, Vector2 direction, [NotNull] RaycastHit?[] hits, [NotNull] Vector3[] positions, float angle = 360f, float distance = float.MaxValue)
~~~

Extract the point vectors from hits. This does not perform any actual casting. For casting, see KaijuAgentsArcRaycast and KaijuAgentsArcSphereCast. This can be useful if your KaijuSolutions.Agents.KaijuAgent only needs position vectors or to help perform debugging.

~~~csharp
public static void ExtractPoints ([NotNull] this Transform position, Vector3 direction, [NotNull] RaycastHit?[] hits, [NotNull] Vector3[] positions, float angle = 360f, float distance = float.MaxValue)
~~~

Extract the point vectors from hits. This does not perform any actual casting. For casting, see KaijuAgentsArcRaycast and KaijuAgentsArcSphereCast. This can be useful if your KaijuSolutions.Agents.KaijuAgent only needs position vectors or to help perform debugging.

~~~csharp
public static void ExtractPoints ([NotNull] this Transform position, [NotNull] Transform direction, [NotNull] RaycastHit?[] hits, [NotNull] Vector3[] positions, float angle = 360f, float distance = float.MaxValue)
~~~

Extract the point vectors from hits. This does not perform any actual casting. For casting, see KaijuAgentsArcRaycast and KaijuAgentsArcSphereCast. This can be useful if your KaijuSolutions.Agents.KaijuAgent only needs position vectors or to help perform debugging.

~~~csharp
public static void ExtractPoints ([NotNull] this Transform position, [NotNull] Component direction, [NotNull] RaycastHit?[] hits, [NotNull] Vector3[] positions, float angle = 360f, float distance = float.MaxValue)
~~~

Extract the point vectors from hits. This does not perform any actual casting. For casting, see KaijuAgentsArcRaycast and KaijuAgentsArcSphereCast. This can be useful if your KaijuSolutions.Agents.KaijuAgent only needs position vectors or to help perform debugging.

~~~csharp
public static void ExtractPoints ([NotNull] this Transform position, [NotNull] GameObject direction, [NotNull] RaycastHit?[] hits, [NotNull] Vector3[] positions, float angle = 360f, float distance = float.MaxValue)
~~~

Extract the point vectors from hits. This does not perform any actual casting. For casting, see KaijuAgentsArcRaycast and KaijuAgentsArcSphereCast. This can be useful if your KaijuSolutions.Agents.KaijuAgent only needs position vectors or to help perform debugging.

~~~csharp
public static void ExtractPoints ([NotNull] this Transform position, [NotNull] RaycastHit?[] hits, [NotNull] Vector3[] positions, float angle = 360f, float distance = float.MaxValue)
~~~

Extract the point vectors from hits. This does not perform any actual casting. For casting, see KaijuAgentsArcRaycast and KaijuAgentsArcSphereCast. This can be useful if your KaijuSolutions.Agents.KaijuAgent only needs position vectors or to help perform debugging.

~~~csharp
public static void ExtractPoints ([NotNull] this Component position, Vector2 direction, [NotNull] RaycastHit?[] hits, [NotNull] Vector3[] positions, float angle = 360f, float distance = float.MaxValue)
~~~

Extract the point vectors from hits. This does not perform any actual casting. For casting, see KaijuAgentsArcRaycast and KaijuAgentsArcSphereCast. This can be useful if your KaijuSolutions.Agents.KaijuAgent only needs position vectors or to help perform debugging.

~~~csharp
public static void ExtractPoints ([NotNull] this Component position, Vector3 direction, [NotNull] RaycastHit?[] hits, [NotNull] Vector3[] positions, float angle = 360f, float distance = float.MaxValue)
~~~

Extract the point vectors from hits. This does not perform any actual casting. For casting, see KaijuAgentsArcRaycast and KaijuAgentsArcSphereCast. This can be useful if your KaijuSolutions.Agents.KaijuAgent only needs position vectors or to help perform debugging.

~~~csharp
public static void ExtractPoints ([NotNull] this Component position, [NotNull] Transform direction, [NotNull] RaycastHit?[] hits, [NotNull] Vector3[] positions, float angle = 360f, float distance = float.MaxValue)
~~~

Extract the point vectors from hits. This does not perform any actual casting. For casting, see KaijuAgentsArcRaycast and KaijuAgentsArcSphereCast. This can be useful if your KaijuSolutions.Agents.KaijuAgent only needs position vectors or to help perform debugging.

~~~csharp
public static void ExtractPoints ([NotNull] this Component position, [NotNull] Component direction, [NotNull] RaycastHit?[] hits, [NotNull] Vector3[] positions, float angle = 360f, float distance = float.MaxValue)
~~~

Extract the point vectors from hits. This does not perform any actual casting. For casting, see KaijuAgentsArcRaycast and KaijuAgentsArcSphereCast. This can be useful if your KaijuSolutions.Agents.KaijuAgent only needs position vectors or to help perform debugging.

~~~csharp
public static void ExtractPoints ([NotNull] this Component position, [NotNull] GameObject direction, [NotNull] RaycastHit?[] hits, [NotNull] Vector3[] positions, float angle = 360f, float distance = float.MaxValue)
~~~

Extract the point vectors from hits. This does not perform any actual casting. For casting, see KaijuAgentsArcRaycast and KaijuAgentsArcSphereCast. This can be useful if your KaijuSolutions.Agents.KaijuAgent only needs position vectors or to help perform debugging.

~~~csharp
public static void ExtractPoints ([NotNull] this Component position, [NotNull] RaycastHit?[] hits, [NotNull] Vector3[] positions, float angle = 360f, float distance = float.MaxValue)
~~~

Extract the point vectors from hits. This does not perform any actual casting. For casting, see KaijuAgentsArcRaycast and KaijuAgentsArcSphereCast. This can be useful if your KaijuSolutions.Agents.KaijuAgent only needs position vectors or to help perform debugging.

~~~csharp
public static void ExtractPoints ([NotNull] this GameObject position, Vector2 direction, [NotNull] RaycastHit?[] hits, [NotNull] Vector3[] positions, float angle = 360f, float distance = float.MaxValue)
~~~

Extract the point vectors from hits. This does not perform any actual casting. For casting, see KaijuAgentsArcRaycast and KaijuAgentsArcSphereCast. This can be useful if your KaijuSolutions.Agents.KaijuAgent only needs position vectors or to help perform debugging.

~~~csharp
public static void ExtractPoints ([NotNull] this GameObject position, Vector3 direction, [NotNull] RaycastHit?[] hits, [NotNull] Vector3[] positions, float angle = 360f, float distance = float.MaxValue)
~~~

Extract the point vectors from hits. This does not perform any actual casting. For casting, see KaijuAgentsArcRaycast and KaijuAgentsArcSphereCast. This can be useful if your KaijuSolutions.Agents.KaijuAgent only needs position vectors or to help perform debugging.

~~~csharp
public static void ExtractPoints ([NotNull] this GameObject position, [NotNull] Transform direction, [NotNull] RaycastHit?[] hits, [NotNull] Vector3[] positions, float angle = 360f, float distance = float.MaxValue)
~~~

Extract the point vectors from hits. This does not perform any actual casting. For casting, see KaijuAgentsArcRaycast and KaijuAgentsArcSphereCast. This can be useful if your KaijuSolutions.Agents.KaijuAgent only needs position vectors or to help perform debugging.

~~~csharp
public static void ExtractPoints ([NotNull] this GameObject position, [NotNull] Component direction, [NotNull] RaycastHit?[] hits, [NotNull] Vector3[] positions, float angle = 360f, float distance = float.MaxValue)
~~~

Extract the point vectors from hits. This does not perform any actual casting. For casting, see KaijuAgentsArcRaycast and KaijuAgentsArcSphereCast. This can be useful if your KaijuSolutions.Agents.KaijuAgent only needs position vectors or to help perform debugging.

~~~csharp
public static void ExtractPoints ([NotNull] this GameObject position, [NotNull] GameObject direction, [NotNull] RaycastHit?[] hits, [NotNull] Vector3[] positions, float angle = 360f, float distance = float.MaxValue)
~~~

Extract the point vectors from hits. This does not perform any actual casting. For casting, see KaijuAgentsArcRaycast and KaijuAgentsArcSphereCast. This can be useful if your KaijuSolutions.Agents.KaijuAgent only needs position vectors or to help perform debugging.

~~~csharp
public static void ExtractPoints ([NotNull] this GameObject position, [NotNull] RaycastHit?[] hits, [NotNull] Vector3[] positions, float angle = 360f, float distance = float.MaxValue)
~~~

Extract the point vectors from hits. This does not perform any actual casting. For casting, see KaijuAgentsArcRaycast and KaijuAgentsArcSphereCast. This can be useful if your KaijuSolutions.Agents.KaijuAgent only needs position vectors or to help perform debugging.
