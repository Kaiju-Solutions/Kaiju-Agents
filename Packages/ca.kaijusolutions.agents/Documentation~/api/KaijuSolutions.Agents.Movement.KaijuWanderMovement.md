# KaijuWanderMovement

Wander steering behaviour.

~~~csharp
public class KaijuWanderMovement : KaijuMovement
~~~

[Package source](../../Runtime/Movement/KaijuWanderMovement.cs)

<a id="KaijuSolutions_Agents_Movement_KaijuWanderMovement_DefaultDistance"></a>

### DefaultDistance

~~~csharp
public const float DefaultDistance
~~~

The default Distance for wander movements.

<a id="KaijuSolutions_Agents_Movement_KaijuWanderMovement_DefaultRadius"></a>

### DefaultRadius

~~~csharp
public const float DefaultRadius
~~~

The default Radius for wander movements.

<a id="KaijuSolutions_Agents_Movement_KaijuWanderMovement_Distance"></a>

### Distance

~~~csharp
public float Distance { get; set; }
~~~

How far out to generate the wander circle.

<a id="KaijuSolutions_Agents_Movement_KaijuWanderMovement_Radius"></a>

### Radius

~~~csharp
public float Radius { get; set; }
~~~

The radius of the wander circle.

<a id="KaijuSolutions_Agents_Movement_KaijuWanderMovement_Center"></a>

### Center

~~~csharp
public Vector2 Center { get; private set; }
~~~

The center point of the circle.

<a id="KaijuSolutions_Agents_Movement_KaijuWanderMovement_Center3"></a>

### Center3

~~~csharp
public Vector3 Center3 { get; }
~~~

The center point of the circle.

<a id="KaijuSolutions_Agents_Movement_KaijuWanderMovement_Target"></a>

### Target

~~~csharp
public Vector2 Target { get; private set; }
~~~

The target calculated along the circle.

<a id="KaijuSolutions_Agents_Movement_KaijuWanderMovement_Target3"></a>

### Target3

~~~csharp
public Vector3 Target3 { get; }
~~~

The target calculated along the circle.

<a id="KaijuSolutions_Agents_Movement_KaijuWanderMovement_Get"></a>

### Get

~~~csharp
public static KaijuWanderMovement Get ([NotNull] KaijuAgent agent, float distance = DefaultDistance, float radius = DefaultRadius, float weight = DefaultWeight)
~~~

Get a wander movement.

<a id="KaijuSolutions_Agents_Movement_KaijuWanderMovement_KaijuWanderMovement"></a>

### KaijuWanderMovement

~~~csharp
public KaijuWanderMovement ([NotNull] KaijuAgent agent, float distance = DefaultDistance, float radius = DefaultRadius, float weight = DefaultWeight)
~~~

Create a wonder movement.

<a id="KaijuSolutions_Agents_Movement_KaijuWanderMovement_Setup"></a>

### Setup

~~~csharp
protected override void Setup ()
~~~

Handle any additional setup.

<a id="KaijuSolutions_Agents_Movement_KaijuWanderMovement_Reset"></a>

### Reset

~~~csharp
protected override void Reset ()
~~~

Perform any needed reset operations.

<a id="KaijuSolutions_Agents_Movement_KaijuWanderMovement_Move"></a>

### Move

~~~csharp
public override Vector2 Move (Vector2 position, float delta)
~~~

Get the KaijuSolutions.Agents.Movement.KaijuMovement.

<a id="KaijuSolutions_Agents_Movement_KaijuWanderMovement_EditorVisualizationColor"></a>

### EditorVisualizationColor

~~~csharp
protected override Color EditorVisualizationColor ()
~~~

Get the color for visualizations.

<a id="KaijuSolutions_Agents_Movement_KaijuWanderMovement_EditorRenderVisualizations"></a>

### EditorRenderVisualizations

~~~csharp
protected override void EditorRenderVisualizations (Vector3 position)
~~~

Render the visualization of the KaijuSolutions.Agents.Movement.KaijuMovement. The position of the KaijuSolutions.Agents.Movement.KaijuMovement.Agent.

<a id="KaijuSolutions_Agents_Movement_KaijuWanderMovement_ToString"></a>

### ToString

~~~csharp
public override string ToString ()
~~~

Get a description of the object.
