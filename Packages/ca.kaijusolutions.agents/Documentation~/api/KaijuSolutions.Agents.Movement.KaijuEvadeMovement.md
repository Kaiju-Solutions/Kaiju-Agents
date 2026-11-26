# KaijuEvadeMovement

Evade steering behaviour.

~~~csharp
public class KaijuEvadeMovement : KaijuFleeMovement
~~~

[Package source](../../Runtime/Movement/KaijuEvadeMovement.cs)

<a id="KaijuSolutions_Agents_Movement_KaijuEvadeMovement_Previous"></a>

### Previous

~~~csharp
public Vector2 Previous
~~~

The previous position of the KaijuSolutions.Agents.Movement.KaijuTargetMovement.Target.

<a id="KaijuSolutions_Agents_Movement_KaijuEvadeMovement_Previous3"></a>

### Previous3

~~~csharp
public Vector3 Previous3 { get; set; }
~~~

The previous position of the KaijuSolutions.Agents.Movement.KaijuTargetMovement.Target.

<a id="KaijuSolutions_Agents_Movement_KaijuEvadeMovement_Future"></a>

### Future

~~~csharp
public Vector2 Future { get; private set; }
~~~

The predicted future KaijuSolutions.Agents.Movement.KaijuTargetMovement.Target.

<a id="KaijuSolutions_Agents_Movement_KaijuEvadeMovement_Future3"></a>

### Future3

~~~csharp
public Vector3 Future3 { get; }
~~~

The predicted future KaijuSolutions.Agents.Movement.KaijuTargetMovement.Target.

<a id="KaijuSolutions_Agents_Movement_KaijuEvadeMovement_Get"></a>

### Get

~~~csharp
public new static KaijuEvadeMovement Get ([NotNull] KaijuAgent agent, Vector2 target, float distance = DefaultDistance, float weight = DefaultWeight)
~~~

Get an evade movement.

~~~csharp
public new static KaijuEvadeMovement Get ([NotNull] KaijuAgent agent, Vector3 target, float distance = DefaultDistance, float weight = DefaultWeight)
~~~

Get an evade movement.

~~~csharp
public new static KaijuEvadeMovement Get ([NotNull] KaijuAgent agent, [NotNull] GameObject target, float distance = DefaultDistance, float weight = DefaultWeight)
~~~

Get an evade movement.

~~~csharp
public new static KaijuEvadeMovement Get ([NotNull] KaijuAgent agent, [NotNull] Component target, float distance = DefaultDistance, float weight = DefaultWeight)
~~~

Get an evade movement.

<a id="KaijuSolutions_Agents_Movement_KaijuEvadeMovement_KaijuEvadeMovement"></a>

### KaijuEvadeMovement

~~~csharp
public KaijuEvadeMovement ([NotNull] KaijuAgent agent, Vector2 target, float distance = DefaultDistance, float weight = DefaultWeight)
~~~

Create an evade movement.

~~~csharp
public KaijuEvadeMovement ([NotNull] KaijuAgent agent, Vector3 target, float distance = DefaultDistance, float weight = DefaultWeight)
~~~

Create an evade movement.

~~~csharp
public KaijuEvadeMovement ([NotNull] KaijuAgent agent, [NotNull] GameObject target, float distance = DefaultDistance, float weight = DefaultWeight)
~~~

Create an evade movement.

~~~csharp
public KaijuEvadeMovement ([NotNull] KaijuAgent agent, [NotNull] Component target, float distance = DefaultDistance, float weight = DefaultWeight)
~~~

Create an evade movement.

<a id="KaijuSolutions_Agents_Movement_KaijuEvadeMovement_Setup"></a>

### Setup

~~~csharp
protected override void Setup ()
~~~

Handle any additional setup.

<a id="KaijuSolutions_Agents_Movement_KaijuEvadeMovement_Reset"></a>

### Reset

~~~csharp
protected override void Reset ()
~~~

Perform any needed reset operations.

<a id="KaijuSolutions_Agents_Movement_KaijuEvadeMovement_Move3"></a>

### Move3

~~~csharp
public override Vector3 Move3 (Vector3 position, float delta)
~~~

<a id="KaijuSolutions_Agents_Movement_KaijuEvadeMovement_Calculate"></a>

### Calculate

~~~csharp
protected override Vector2 Calculate (Vector2 position, float speed, Vector2 target, float delta)
~~~

Calculate the movement.

<a id="KaijuSolutions_Agents_Movement_KaijuEvadeMovement_EditorVisualizationColor"></a>

### EditorVisualizationColor

~~~csharp
protected override Color EditorVisualizationColor ()
~~~

Get the color for visualizations.

<a id="KaijuSolutions_Agents_Movement_KaijuEvadeMovement_EditorRenderVisualizations"></a>

### EditorRenderVisualizations

~~~csharp
protected override void EditorRenderVisualizations (Vector3 position)
~~~

Render the visualization of the KaijuSolutions.Agents.Movement.KaijuMovement. The position of the KaijuSolutions.Agents.Movement.KaijuMovement.Agent.

<a id="KaijuSolutions_Agents_Movement_KaijuEvadeMovement_ToString"></a>

### ToString

~~~csharp
public override string ToString ()
~~~

Get a description of the object.
