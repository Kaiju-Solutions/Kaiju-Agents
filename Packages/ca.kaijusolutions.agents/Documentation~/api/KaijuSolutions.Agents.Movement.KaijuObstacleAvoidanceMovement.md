# KaijuObstacleAvoidanceMovement

Obstacle avoidance steering behaviour.

~~~csharp
public class KaijuObstacleAvoidanceMovement : KaijuMovement
~~~

[Package source](../../Runtime/Movement/KaijuObstacleAvoidanceMovement.cs)

<a id="KaijuSolutions_Agents_Movement_KaijuObstacleAvoidanceMovement_DefaultAvoidance"></a>

### DefaultAvoidance

~~~csharp
public const float DefaultAvoidance
~~~

The default Avoidance for KaijuSolutions.Agents.Movement.KaijuObstacleAvoidanceMovements.

<a id="KaijuSolutions_Agents_Movement_KaijuObstacleAvoidanceMovement_DefaultDistance"></a>

### DefaultDistance

~~~csharp
public const float DefaultDistance
~~~

The default Distance for KaijuSolutions.Agents.Movement.KaijuObstacleAvoidanceMovements.

<a id="KaijuSolutions_Agents_Movement_KaijuObstacleAvoidanceMovement_DefaultSideDistance"></a>

### DefaultSideDistance

~~~csharp
public const float DefaultSideDistance
~~~

The default SideDistance for KaijuSolutions.Agents.Movement.KaijuObstacleAvoidanceMovements.

<a id="KaijuSolutions_Agents_Movement_KaijuObstacleAvoidanceMovement_DefaultAngle"></a>

### DefaultAngle

~~~csharp
public const float DefaultAngle
~~~

The default Angle for KaijuSolutions.Agents.Movement.KaijuObstacleAvoidanceMovements.

<a id="KaijuSolutions_Agents_Movement_KaijuObstacleAvoidanceMovement_DefaultHeight"></a>

### DefaultHeight

~~~csharp
public const float DefaultHeight
~~~

The default Height for KaijuSolutions.Agents.Movement.KaijuObstacleAvoidanceMovements.

<a id="KaijuSolutions_Agents_Movement_KaijuObstacleAvoidanceMovement_DefaultHorizontal"></a>

### DefaultHorizontal

~~~csharp
public const float DefaultHorizontal
~~~

The default Horizontal for KaijuSolutions.Agents.Movement.KaijuObstacleAvoidanceMovements.

<a id="KaijuSolutions_Agents_Movement_KaijuObstacleAvoidanceMovement_Avoidance"></a>

### Avoidance

~~~csharp
public float Avoidance { get; set; }
~~~

The distance from a wall the KaijuSolutions.Agents.KaijuAgent should maintain.

<a id="KaijuSolutions_Agents_Movement_KaijuObstacleAvoidanceMovement_Distance"></a>

### Distance

~~~csharp
public float Distance { get; set; }
~~~

The distance for rays.

<a id="KaijuSolutions_Agents_Movement_KaijuObstacleAvoidanceMovement_SideDistance"></a>

### SideDistance

~~~csharp
public float SideDistance { get; set; }
~~~

The distance of the side rays. Zero or less will use the Distance.

<a id="KaijuSolutions_Agents_Movement_KaijuObstacleAvoidanceMovement_Angle"></a>

### Angle

~~~csharp
public float Angle
~~~

The angle for rays.

<a id="KaijuSolutions_Agents_Movement_KaijuObstacleAvoidanceMovement_Height"></a>

### Height

~~~csharp
public float Height
~~~

The height offset for the rays.

<a id="KaijuSolutions_Agents_Movement_KaijuObstacleAvoidanceMovement_Horizontal"></a>

### Horizontal

~~~csharp
public float Horizontal
~~~

The horizontal shift for the side rays.

<a id="KaijuSolutions_Agents_Movement_KaijuObstacleAvoidanceMovement_Mask"></a>

### Mask

~~~csharp
public LayerMask Mask
~~~

While layers the rays should hit.

<a id="KaijuSolutions_Agents_Movement_KaijuObstacleAvoidanceMovement_Hits"></a>

### Hits

~~~csharp
public IReadOnlyList<RaycastHit> Hits { get; }
~~~

The points hit by the rays.

<a id="KaijuSolutions_Agents_Movement_KaijuObstacleAvoidanceMovement_Misses"></a>

### Misses

~~~csharp
public IReadOnlyList<Vector3> Misses { get; }
~~~

All points which were checked to hit but misses.

<a id="KaijuSolutions_Agents_Movement_KaijuObstacleAvoidanceMovement_Get"></a>

### Get

~~~csharp
public static KaijuObstacleAvoidanceMovement Get ([NotNull] KaijuAgent agent, float avoidance = DefaultAvoidance, float distance = DefaultDistance, float sideDistance = DefaultDistance, float angle = DefaultAngle, float height = DefaultHeight, float horizontal = DefaultHorizontal, float weight = DefaultWeight)
~~~

Get an obstacle avoidance movement.

<a id="KaijuSolutions_Agents_Movement_KaijuObstacleAvoidanceMovement_KaijuObstacleAvoidanceMovement"></a>

### KaijuObstacleAvoidanceMovement

~~~csharp
public KaijuObstacleAvoidanceMovement ([NotNull] KaijuAgent agent, float avoidance = DefaultAvoidance, float distance = DefaultDistance, float sideDistance = DefaultDistance,float angle = DefaultAngle, float height = DefaultHeight, float horizontal = DefaultHorizontal, float weight = DefaultWeight)
~~~

Create an obstacle avoidance movement.

<a id="KaijuSolutions_Agents_Movement_KaijuObstacleAvoidanceMovement_Initialize"></a>

### Initialize

~~~csharp
protected void Initialize ([NotNull] KaijuAgent agent, float avoidance = DefaultAvoidance, float distance = DefaultDistance, float sideDistance = DefaultDistance,float angle = DefaultAngle, float height = DefaultHeight, float horizontal = DefaultHorizontal, float weight = DefaultWeight)
~~~

Initialize the KaijuSolutions.Agents.Movement.KaijuMovement.

<a id="KaijuSolutions_Agents_Movement_KaijuObstacleAvoidanceMovement_Reset"></a>

### Reset

~~~csharp
protected override void Reset ()
~~~

Perform any needed reset operations.

<a id="KaijuSolutions_Agents_Movement_KaijuObstacleAvoidanceMovement_Move"></a>

### Move

~~~csharp
public override Vector2 Move (Vector2 position, float delta)
~~~

Get the KaijuSolutions.Agents.Movement.KaijuMovement.

<a id="KaijuSolutions_Agents_Movement_KaijuObstacleAvoidanceMovement_EditorVisualizationColor"></a>

### EditorVisualizationColor

~~~csharp
protected override Color EditorVisualizationColor ()
~~~

Get the color for visualizations.

<a id="KaijuSolutions_Agents_Movement_KaijuObstacleAvoidanceMovement_EditorRenderVisualizations"></a>

### EditorRenderVisualizations

~~~csharp
protected override void EditorRenderVisualizations (Vector3 position)
~~~

Render the visualization of the KaijuSolutions.Agents.Movement.KaijuMovement. The position of the KaijuSolutions.Agents.Movement.KaijuMovement.Agent.

<a id="KaijuSolutions_Agents_Movement_KaijuObstacleAvoidanceMovement_ToString"></a>

### ToString

~~~csharp
public override string ToString ()
~~~

Get a description of the object.
