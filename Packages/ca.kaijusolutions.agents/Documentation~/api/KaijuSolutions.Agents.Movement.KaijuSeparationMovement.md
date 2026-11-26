# KaijuSeparationMovement

Separation steering behaviour.

~~~csharp
public class KaijuSeparationMovement : KaijuAreaMovement
~~~

[Package source](../../Runtime/Movement/KaijuSeparationMovement.cs)

<a id="KaijuSolutions_Agents_Movement_KaijuSeparationMovement_DefaultDistance"></a>

### DefaultDistance

~~~csharp
public const float DefaultDistance
~~~

The default KaijuSolutions.Agents.Movement.KaijuAreaMovement.Distance for separation movements.

<a id="KaijuSolutions_Agents_Movement_KaijuSeparationMovement_DefaultCoefficient"></a>

### DefaultCoefficient

~~~csharp
public const float DefaultCoefficient
~~~

The default Coefficient for separation movements.

<a id="KaijuSolutions_Agents_Movement_KaijuSeparationMovement_Coefficient"></a>

### Coefficient

~~~csharp
public float Coefficient { get; set; }
~~~

The coefficient to use for inverse square law separation. Zero will use linear separation.

<a id="KaijuSolutions_Agents_Movement_KaijuSeparationMovement_Interacting"></a>

### Interacting

~~~csharp
public IReadOnlyCollection<KaijuAgent> Interacting { get; }
~~~

The KaijuSolutions.Agents.KaijuAgents currently detected this movement is moving in relation to.

<a id="KaijuSolutions_Agents_Movement_KaijuSeparationMovement_Get"></a>

### Get

~~~csharp
public static KaijuSeparationMovement Get ([NotNull] KaijuAgent agent, float distance = DefaultDistance, float coefficient = DefaultCoefficient, ICollection<uint> identifiers = null, float weight = DefaultWeight)
~~~

Get a separation movement.

<a id="KaijuSolutions_Agents_Movement_KaijuSeparationMovement_KaijuSeparationMovement"></a>

### KaijuSeparationMovement

~~~csharp
public KaijuSeparationMovement ([NotNull] KaijuAgent agent, float distance = DefaultDistance, float coefficient = DefaultCoefficient, ICollection<uint> identifiers = null, float weight = DefaultWeight)
~~~

Create a separation movement.

<a id="KaijuSolutions_Agents_Movement_KaijuSeparationMovement_Reset"></a>

### Reset

~~~csharp
protected override void Reset ()
~~~

Perform any needed reset operations.

<a id="KaijuSolutions_Agents_Movement_KaijuSeparationMovement_Move"></a>

### Move

~~~csharp
public override Vector2 Move (Vector2 position, float delta)
~~~

Get the KaijuSolutions.Agents.Movement.KaijuMovement.

<a id="KaijuSolutions_Agents_Movement_KaijuSeparationMovement_EditorVisualizationColor"></a>

### EditorVisualizationColor

~~~csharp
protected override Color EditorVisualizationColor ()
~~~

Get the color for visualizations.

<a id="KaijuSolutions_Agents_Movement_KaijuSeparationMovement_EditorRenderVisualizations"></a>

### EditorRenderVisualizations

~~~csharp
protected override void EditorRenderVisualizations (Vector3 position)
~~~

Render the visualization of the KaijuSolutions.Agents.Movement.KaijuMovement. The position of the KaijuSolutions.Agents.Movement.KaijuMovement.Agent.

<a id="KaijuSolutions_Agents_Movement_KaijuSeparationMovement_ToString"></a>

### ToString

~~~csharp
public override string ToString ()
~~~

Get a description of the object.
