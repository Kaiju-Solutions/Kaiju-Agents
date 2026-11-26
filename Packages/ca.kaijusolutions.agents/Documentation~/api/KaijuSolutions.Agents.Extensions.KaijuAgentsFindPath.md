# KaijuAgentsFindPath

Extension methods for finding a path.

~~~csharp
public static class KaijuAgentsFindPath
~~~

[Package source](../../Runtime/Extensions/KaijuAgentsFindPath.cs)

<a id="KaijuSolutions_Agents_Extensions_KaijuAgentsFindPath_TryFindSurfacePath"></a>

### TryFindSurfacePath

~~~csharp
public static bool TryFindSurfacePath (this Vector3 start, Vector3 goal, NavMeshQueryFilter filter, float snapDistance, NavMeshPath path, ref Vector3[] corners, out int count, out KaijuSurfacePathStatus status, out Vector3 mappedGoal)
~~~

Map both endpoints and compute a strict surface path. Only Complete returns true. Reuse the path and corner buffer on the main thread. Partial routes expose their available corners.

<a id="KaijuSolutions_Agents_Extensions_KaijuAgentsFindPath_InitialCacheSize"></a>

### InitialCacheSize

~~~csharp
public const int InitialCacheSize
~~~

What size to initially allocate for getting paths.

<a id="KaijuSolutions_Agents_Extensions_KaijuAgentsFindPath_ResizeCache"></a>

### ResizeCache

~~~csharp
public static void ResizeCache (int size = InitialCacheSize)
~~~

Resize the points cache.

<a id="KaijuSolutions_Agents_Extensions_KaijuAgentsFindPath_FindPath"></a>

### FindPath

~~~csharp
public static int FindPath (this Vector2 start, Vector2 goal, ref Vector2[] path, int mask = NavMesh.AllAreas, float? radius = null, int sightMask = KaijuMovementConfiguration.DefaultMask, QueryTriggerInteraction triggers = QueryTriggerInteraction.UseGlobal)
~~~

Find a path from the starting to the end position.

~~~csharp
public static int FindPath (this Vector2 start, Vector2 goal, ref Vector2[] path, NavMeshQueryFilter filter, float? radius = null, int sightMask = KaijuMovementConfiguration.DefaultMask, QueryTriggerInteraction triggers = QueryTriggerInteraction.UseGlobal)
~~~

Find a path from the starting to the end position.

~~~csharp
public static int FindPath (this Vector2 start, Vector2 goal, List<Vector2> path, int mask = NavMesh.AllAreas, float? radius = null, int sightMask = KaijuMovementConfiguration.DefaultMask, QueryTriggerInteraction triggers = QueryTriggerInteraction.UseGlobal)
~~~

Find a path from the starting to the end position.

~~~csharp
public static int FindPath (this Vector2 start, Vector2 goal, List<Vector2> path, NavMeshQueryFilter filter, float? radius = null, int sightMask = KaijuMovementConfiguration.DefaultMask, QueryTriggerInteraction triggers = QueryTriggerInteraction.UseGlobal)
~~~

Find a path from the starting to the end position.

~~~csharp
public static int FindPath (this Vector2 start, Vector2 goal, ref Vector3[] path, int mask = NavMesh.AllAreas, float? radius = null, int sightMask = KaijuMovementConfiguration.DefaultMask, QueryTriggerInteraction triggers = QueryTriggerInteraction.UseGlobal)
~~~

Find a path from the starting to the end position.

~~~csharp
public static int FindPath (this Vector2 start, Vector2 goal, ref Vector3[] path, NavMeshQueryFilter filter, float? radius = null, int sightMask = KaijuMovementConfiguration.DefaultMask, QueryTriggerInteraction triggers = QueryTriggerInteraction.UseGlobal)
~~~

Find a path from the starting to the end position.

~~~csharp
public static int FindPath (this Vector2 start, Vector2 goal, List<Vector3> path, int mask = NavMesh.AllAreas, float? radius = null, int sightMask = KaijuMovementConfiguration.DefaultMask, QueryTriggerInteraction triggers = QueryTriggerInteraction.UseGlobal)
~~~

Find a path from the starting to the end position.

~~~csharp
public static int FindPath (this Vector2 start, Vector2 goal, List<Vector3> path, NavMeshQueryFilter filter, float? radius = null, int sightMask = KaijuMovementConfiguration.DefaultMask, QueryTriggerInteraction triggers = QueryTriggerInteraction.UseGlobal)
~~~

Find a path from the starting to the end position.

~~~csharp
public static int FindPath (this Vector2 start, Vector3 goal, ref Vector2[] path, int mask = NavMesh.AllAreas, float? radius = null, int sightMask = KaijuMovementConfiguration.DefaultMask, QueryTriggerInteraction triggers = QueryTriggerInteraction.UseGlobal)
~~~

Find a path from the starting to the end position.

~~~csharp
public static int FindPath (this Vector2 start, Vector3 goal, ref Vector2[] path, NavMeshQueryFilter filter, float? radius = null, int sightMask = KaijuMovementConfiguration.DefaultMask, QueryTriggerInteraction triggers = QueryTriggerInteraction.UseGlobal)
~~~

Find a path from the starting to the end position.

~~~csharp
public static int FindPath (this Vector2 start, Vector3 goal, List<Vector2> path, int mask = NavMesh.AllAreas, float? radius = null, int sightMask = KaijuMovementConfiguration.DefaultMask, QueryTriggerInteraction triggers = QueryTriggerInteraction.UseGlobal)
~~~

Find a path from the starting to the end position.

~~~csharp
public static int FindPath (this Vector2 start, Vector3 goal, List<Vector2> path, NavMeshQueryFilter filter, float? radius = null, int sightMask = KaijuMovementConfiguration.DefaultMask, QueryTriggerInteraction triggers = QueryTriggerInteraction.UseGlobal)
~~~

Find a path from the starting to the end position.

~~~csharp
public static int FindPath (this Vector2 start, Vector3 goal, ref Vector3[] path, int mask = NavMesh.AllAreas, float? radius = null, int sightMask = KaijuMovementConfiguration.DefaultMask, QueryTriggerInteraction triggers = QueryTriggerInteraction.UseGlobal)
~~~

Find a path from the starting to the end position.

~~~csharp
public static int FindPath (this Vector2 start, Vector3 goal, ref Vector3[] path, NavMeshQueryFilter filter, float? radius = null, int sightMask = KaijuMovementConfiguration.DefaultMask, QueryTriggerInteraction triggers = QueryTriggerInteraction.UseGlobal)
~~~

Find a path from the starting to the end position.

~~~csharp
public static int FindPath (this Vector2 start, Vector3 goal, List<Vector3> path, int mask = NavMesh.AllAreas, float? radius = null, int sightMask = KaijuMovementConfiguration.DefaultMask, QueryTriggerInteraction triggers = QueryTriggerInteraction.UseGlobal)
~~~

Find a path from the starting to the end position.

~~~csharp
public static int FindPath (this Vector2 start, Vector3 goal, List<Vector3> path, NavMeshQueryFilter filter, float? radius = null, int sightMask = KaijuMovementConfiguration.DefaultMask, QueryTriggerInteraction triggers = QueryTriggerInteraction.UseGlobal)
~~~

Find a path from the starting to the end position.

~~~csharp
public static int FindPath (this Vector3 start, Vector2 goal, ref Vector2[] path, int mask = NavMesh.AllAreas, float? radius = null, int sightMask = KaijuMovementConfiguration.DefaultMask, QueryTriggerInteraction triggers = QueryTriggerInteraction.UseGlobal)
~~~

Find a path from the starting to the end position.

~~~csharp
public static int FindPath (this Vector3 start, Vector2 goal, ref Vector2[] path, NavMeshQueryFilter filter, float? radius = null, int sightMask = KaijuMovementConfiguration.DefaultMask, QueryTriggerInteraction triggers = QueryTriggerInteraction.UseGlobal)
~~~

Find a path from the starting to the end position.

~~~csharp
public static int FindPath (this Vector3 start, Vector2 goal, List<Vector2> path, int mask = NavMesh.AllAreas, float? radius = null, int sightMask = KaijuMovementConfiguration.DefaultMask, QueryTriggerInteraction triggers = QueryTriggerInteraction.UseGlobal)
~~~

Find a path from the starting to the end position.

~~~csharp
public static int FindPath (this Vector3 start, Vector2 goal, List<Vector2> path, NavMeshQueryFilter filter, float? radius = null, int sightMask = KaijuMovementConfiguration.DefaultMask, QueryTriggerInteraction triggers = QueryTriggerInteraction.UseGlobal)
~~~

Find a path from the starting to the end position.

~~~csharp
public static int FindPath (this Vector3 start, Vector3 goal, ref Vector2[] path, int mask = NavMesh.AllAreas, float? radius = null, int sightMask = KaijuMovementConfiguration.DefaultMask, QueryTriggerInteraction triggers = QueryTriggerInteraction.UseGlobal)
~~~

Find a path from the starting to the end position.

~~~csharp
public static int FindPath (this Vector3 start, Vector3 goal, ref Vector2[] path, NavMeshQueryFilter filter, float? radius = null, int sightMask = KaijuMovementConfiguration.DefaultMask, QueryTriggerInteraction triggers = QueryTriggerInteraction.UseGlobal)
~~~

Find a path from the starting to the end position.

~~~csharp
public static int FindPath (this Vector3 start, Vector3 goal, List<Vector2> path, int mask = NavMesh.AllAreas, float? radius = null, int sightMask = KaijuMovementConfiguration.DefaultMask, QueryTriggerInteraction triggers = QueryTriggerInteraction.UseGlobal)
~~~

Find a path from the starting to the end position.

~~~csharp
public static int FindPath (this Vector3 start, Vector3 goal, List<Vector2> path, NavMeshQueryFilter filter, float? radius = null, int sightMask = KaijuMovementConfiguration.DefaultMask, QueryTriggerInteraction triggers = QueryTriggerInteraction.UseGlobal)
~~~

Find a path from the starting to the end position.

~~~csharp
public static int FindPath (this Vector3 start, Vector3 goal, ref Vector3[] path, int mask = NavMesh.AllAreas, float? radius = null, int sightMask = KaijuMovementConfiguration.DefaultMask, QueryTriggerInteraction triggers = QueryTriggerInteraction.UseGlobal)
~~~

Find a path from the starting to the end position.

~~~csharp
public static int FindPath (this Vector3 start, Vector3 goal, ref Vector3[] path, NavMeshQueryFilter filter, float? radius = null, int sightMask = KaijuMovementConfiguration.DefaultMask, QueryTriggerInteraction triggers = QueryTriggerInteraction.UseGlobal)
~~~

Find a path from the starting to the end position.

~~~csharp
public static int FindPath (this Vector3 start, Vector3 goal, List<Vector3> path, int mask = NavMesh.AllAreas, float? radius = null, int sightMask = KaijuMovementConfiguration.DefaultMask, QueryTriggerInteraction triggers = QueryTriggerInteraction.UseGlobal)
~~~

Find a path from the starting to the end position.

~~~csharp
public static int FindPath (this Vector3 start, Vector3 goal, List<Vector3> path, NavMeshQueryFilter filter, float? radius = null, int sightMask = KaijuMovementConfiguration.DefaultMask, QueryTriggerInteraction triggers = QueryTriggerInteraction.UseGlobal)
~~~

Find a path from the starting to the end position.
