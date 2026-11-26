# KaijuMovementManager

Cache KaijuSolutions.Agents.Movement.KaijuMovement objects for reuse.

~~~csharp
public static class KaijuMovementManager
~~~

[Package source](../../Runtime/Movement/KaijuMovementManager.cs)

<a id="KaijuSolutions_Agents_Movement_KaijuMovementManager_EditorSeekColor"></a>

### EditorSeekColor

~~~csharp
public static Color EditorSeekColor { get; set; }
~~~

Color for seek visuals in the editor.

<a id="KaijuSolutions_Agents_Movement_KaijuMovementManager_EditorPursueColor"></a>

### EditorPursueColor

~~~csharp
public static Color EditorPursueColor { get; set; }
~~~

Color for pursue visuals in the editor.

<a id="KaijuSolutions_Agents_Movement_KaijuMovementManager_EditorFleeColor"></a>

### EditorFleeColor

~~~csharp
public static Color EditorFleeColor { get; set; }
~~~

Color for flee visuals in the editor.

<a id="KaijuSolutions_Agents_Movement_KaijuMovementManager_EditorEvadeColor"></a>

### EditorEvadeColor

~~~csharp
public static Color EditorEvadeColor { get; set; }
~~~

Color for evade visuals in the editor.

<a id="KaijuSolutions_Agents_Movement_KaijuMovementManager_EditorWanderColor"></a>

### EditorWanderColor

~~~csharp
public static Color EditorWanderColor { get; set; }
~~~

Color for wander visuals in the editor.

<a id="KaijuSolutions_Agents_Movement_KaijuMovementManager_EditorSeparationColor"></a>

### EditorSeparationColor

~~~csharp
public static Color EditorSeparationColor { get; set; }
~~~

Color for separation visuals in the editor.

<a id="KaijuSolutions_Agents_Movement_KaijuMovementManager_EditorObstacleAvoidanceColor"></a>

### EditorObstacleAvoidanceColor

~~~csharp
public static Color EditorObstacleAvoidanceColor { get; set; }
~~~

Color for obstacle avoidance visuals in the editor.

<a id="KaijuSolutions_Agents_Movement_KaijuMovementManager_EditorPathFollowColor"></a>

### EditorPathFollowColor

~~~csharp
public static Color EditorPathFollowColor { get; set; }
~~~

Color for path following visuals in the editor.

<a id="KaijuSolutions_Agents_Movement_KaijuMovementManager_EditorSyncColors"></a>

### EditorSyncColors

~~~csharp
public static void EditorSyncColors ()
~~~

Sync all colors in the editor.

<a id="KaijuSolutions_Agents_Movement_KaijuMovementManager_EditorResetColors"></a>

### EditorResetColors

~~~csharp
public static void EditorResetColors ()
~~~

Reset all colors in the editor.

<a id="KaijuSolutions_Agents_Movement_KaijuMovementManager_EditorResetSeekColor"></a>

### EditorResetSeekColor

~~~csharp
public static void EditorResetSeekColor ()
~~~

Reset the seek color in the editor.

<a id="KaijuSolutions_Agents_Movement_KaijuMovementManager_EditorResetPursueColor"></a>

### EditorResetPursueColor

~~~csharp
public static void EditorResetPursueColor ()
~~~

Reset the pursue color in the editor.

<a id="KaijuSolutions_Agents_Movement_KaijuMovementManager_EditorResetFleeColor"></a>

### EditorResetFleeColor

~~~csharp
public static void EditorResetFleeColor ()
~~~

Reset the seek color in the editor.

<a id="KaijuSolutions_Agents_Movement_KaijuMovementManager_EditorResetEvadeColor"></a>

### EditorResetEvadeColor

~~~csharp
public static void EditorResetEvadeColor ()
~~~

Reset the evade color in the editor.

<a id="KaijuSolutions_Agents_Movement_KaijuMovementManager_EditorResetWanderColor"></a>

### EditorResetWanderColor

~~~csharp
public static void EditorResetWanderColor ()
~~~

Reset the wander color in the editor.

<a id="KaijuSolutions_Agents_Movement_KaijuMovementManager_EditorResetSeparationColor"></a>

### EditorResetSeparationColor

~~~csharp
public static void EditorResetSeparationColor ()
~~~

Reset the separation color in the editor.

<a id="KaijuSolutions_Agents_Movement_KaijuMovementManager_EditorResetObstacleAvoidanceColor"></a>

### EditorResetObstacleAvoidanceColor

~~~csharp
public static void EditorResetObstacleAvoidanceColor ()
~~~

Reset the obstacle avoidance color in the editor.

<a id="KaijuSolutions_Agents_Movement_KaijuMovementManager_EditorResetPathFollowColor"></a>

### EditorResetPathFollowColor

~~~csharp
public static void EditorResetPathFollowColor ()
~~~

Reset the obstacle avoidance color in the editor.

<a id="KaijuSolutions_Agents_Movement_KaijuMovementManager_EditorVisualizationsAll"></a>

### EditorVisualizationsAll

~~~csharp
public static bool EditorVisualizationsAll { get; set; }
~~~

Handle if all editor visualizations should be rendered or only the selected KaijuSolutions.Agents.KaijuAgent.

<a id="KaijuSolutions_Agents_Movement_KaijuMovementManager_EditorResetVisualizationsAll"></a>

### EditorResetVisualizationsAll

~~~csharp
public static void EditorResetVisualizationsAll ()
~~~

Reset if all editor visualizations should be rendered or only the selected KaijuSolutions.Agents.KaijuAgent.

<a id="KaijuSolutions_Agents_Movement_KaijuMovementManager_EditorVisualizationsLabels"></a>

### EditorVisualizationsLabels

~~~csharp
public static bool EditorVisualizationsLabels { get; set; }
~~~

If labels should be displayed with editor visualizations.

<a id="KaijuSolutions_Agents_Movement_KaijuMovementManager_EditorResetVisualizationsLabels"></a>

### EditorResetVisualizationsLabels

~~~csharp
public static void EditorResetVisualizationsLabels ()
~~~

Reset if labels should be displayed with editor visualizations.

<a id="KaijuSolutions_Agents_Movement_KaijuMovementManager_Get"></a>

### Get

~~~csharp
public static T Get <T> () where T : KaijuMovement
~~~

Get a KaijuSolutions.Agents.Movement.KaijuMovement instance.

<a id="KaijuSolutions_Agents_Movement_KaijuMovementManager_Return"></a>

### Return

~~~csharp
public static void Return <T> (T movement) where T : KaijuMovement
~~~

Return a KaijuSolutions.Agents.Movement.KaijuMovement to the cache.
