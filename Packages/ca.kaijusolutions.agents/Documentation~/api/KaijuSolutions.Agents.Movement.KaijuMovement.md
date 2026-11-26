# KaijuMovement

Base movement class.

~~~csharp
public abstract class KaijuMovement
~~~

[Package source](../../Runtime/Movement/KaijuMovement.cs)

<a id="KaijuSolutions_Agents_Movement_KaijuMovement_DefaultWeight"></a>

### DefaultWeight

~~~csharp
public const float DefaultWeight
~~~

The default Weight for movement.

<a id="KaijuSolutions_Agents_Movement_KaijuMovement_OnStarted"></a>

### OnStarted

~~~csharp
public event KaijuAction OnStarted
~~~

Callback for this movement starting.

<a id="KaijuSolutions_Agents_Movement_KaijuMovement_OnStartedGlobal"></a>

### OnStartedGlobal

~~~csharp
public static event KaijuMovementAction OnStartedGlobal
~~~

Global callback for this movement starting.

<a id="KaijuSolutions_Agents_Movement_KaijuMovement_OnStopped"></a>

### OnStopped

~~~csharp
public event KaijuAction OnStopped
~~~

Callback for this movement stopping.

<a id="KaijuSolutions_Agents_Movement_KaijuMovement_OnStoppedGlobal"></a>

### OnStoppedGlobal

~~~csharp
public static event KaijuMovementAction OnStoppedGlobal
~~~

Global callback for this movement stopping.

<a id="KaijuSolutions_Agents_Movement_KaijuMovement_OnPerformed"></a>

### OnPerformed

~~~csharp
public event KaijuAction OnPerformed
~~~

Callback for this movement being performed.

<a id="KaijuSolutions_Agents_Movement_KaijuMovement_OnPerformedGlobal"></a>

### OnPerformedGlobal

~~~csharp
public static event KaijuMovementAction OnPerformedGlobal
~~~

Global callback for this movement being performed.

<a id="KaijuSolutions_Agents_Movement_KaijuMovement_Agent"></a>

### Agent

~~~csharp
public KaijuAgent Agent
~~~

The KaijuSolutions.Agents.KaijuAgent the movement is assigned to.

<a id="KaijuSolutions_Agents_Movement_KaijuMovement_Weight"></a>

### Weight

~~~csharp
public float Weight { get; set; }
~~~

The weight of this movement.

<a id="KaijuSolutions_Agents_Movement_KaijuMovement_KaijuMovement"></a>

### KaijuMovement

~~~csharp
public KaijuMovement ([NotNull] KaijuAgent agent, float weight = DefaultWeight)
~~~

Create The movement.

<a id="KaijuSolutions_Agents_Movement_KaijuMovement_Initialize"></a>

### Initialize

~~~csharp
protected void Initialize ([NotNull] KaijuAgent agent, float weight = DefaultWeight)
~~~

Initialize The movement.

<a id="KaijuSolutions_Agents_Movement_KaijuMovement_Setup"></a>

### Setup

~~~csharp
protected virtual void Setup ()
~~~

Handle any additional setup.

<a id="KaijuSolutions_Agents_Movement_KaijuMovement_Move"></a>

### Move

~~~csharp
public abstract Vector2 Move (Vector2 position, float delta)
~~~

Get the movement.

<a id="KaijuSolutions_Agents_Movement_KaijuMovement_Move3"></a>

### Move3

~~~csharp
public virtual Vector3 Move3 (Vector3 position, float delta)
~~~

Spatial steering for flight. Existing planar movements contribute horizontal velocity.

<a id="KaijuSolutions_Agents_Movement_KaijuMovement_Started"></a>

### Started

~~~csharp
public void Started ()
~~~

Invoke started callbacks.

<a id="KaijuSolutions_Agents_Movement_KaijuMovement_Stopped"></a>

### Stopped

~~~csharp
public void Stopped ()
~~~

Invoke stopped callbacks.

<a id="KaijuSolutions_Agents_Movement_KaijuMovement_Performed"></a>

### Performed

~~~csharp
public void Performed ()
~~~

Invoke performed callbacks.

<a id="KaijuSolutions_Agents_Movement_KaijuMovement_Done"></a>

### Done

~~~csharp
public virtual bool Done ()
~~~

Determine if the movement is done or not.

<a id="KaijuSolutions_Agents_Movement_KaijuMovement_Return"></a>

### Return

~~~csharp
public void Return ()
~~~

Return this movement.

<a id="KaijuSolutions_Agents_Movement_KaijuMovement_Reset"></a>

### Reset

~~~csharp
protected virtual void Reset ()
~~~

Perform any needed reset operations.

<a id="KaijuSolutions_Agents_Movement_KaijuMovement_EditorVisualize"></a>

### EditorVisualize

~~~csharp
public void EditorVisualize (Vector3 position)
~~~

Allow for visualizing in the editor. The position of the KaijuSolutions.Agents.KaijuController.Agent.

<a id="KaijuSolutions_Agents_Movement_KaijuMovement_EditorVisualizationColor"></a>

### EditorVisualizationColor

~~~csharp
protected virtual Color EditorVisualizationColor ()
~~~

Get the color for visualizations.

<a id="KaijuSolutions_Agents_Movement_KaijuMovement_EditorRenderVisualizations"></a>

### EditorRenderVisualizations

~~~csharp
protected virtual void EditorRenderVisualizations (Vector3 position)
~~~

Render the visualization of the movement. The position of the KaijuSolutions.Agents.KaijuController.Agent.

<a id="KaijuSolutions_Agents_Movement_KaijuMovement_ToString"></a>

### ToString

~~~csharp
public override string ToString ()
~~~

Get a description of the object.

~~~csharp
public static implicit operator KaijuAgent ([NotNull] KaijuMovement m)
~~~

Implicit conversion to an KaijuSolutions.Agents.KaijuAgent from the assigned KaijuSolutions.Agents.KaijuController.Agent.

~~~csharp
public static implicit operator Transform ([NotNull] KaijuMovement m)
~~~

Implicit conversion to a transform from the assigned KaijuSolutions.Agents.KaijuController.Agent.

~~~csharp
public static implicit operator GameObject ([NotNull] KaijuMovement m)
~~~

Implicit conversion to a GameObject from the assigned KaijuSolutions.Agents.KaijuController.Agent.

~~~csharp
public static implicit operator Vector2 ([NotNull] KaijuMovement m)
~~~

Implicit conversion to a Vector2 from the assigned KaijuSolutions.Agents.KaijuController.Agent's position.

~~~csharp
public static implicit operator Vector2? ([NotNull] KaijuMovement m)
~~~

Implicit conversion to a nullable Vector2 from the assigned KaijuSolutions.Agents.KaijuController.Agent's position.

~~~csharp
public static implicit operator Vector3 ([NotNull] KaijuMovement m)
~~~

Implicit conversion to a Vector3 from the assigned KaijuSolutions.Agents.KaijuController.Agent's position.

~~~csharp
public static implicit operator Vector3? ([NotNull] KaijuMovement m)
~~~

Implicit conversion to a nullable Vector3 from the assigned KaijuSolutions.Agents.KaijuController.Agent's position.

~~~csharp
public static implicit operator bool ([NotNull] KaijuMovement m)
~~~

Implicit conversion to a Boolean to see if the KaijuSolutions.Agents.KaijuController.Agent is assigned.

~~~csharp
public static implicit operator bool? ([NotNull] KaijuMovement m)
~~~

Implicit conversion to a nullable Boolean to see if the KaijuSolutions.Agents.KaijuController.Agent is assigned.

~~~csharp
public static implicit operator string ([NotNull] KaijuMovement m)
~~~

Implicit conversion to a string.

~~~csharp
public static implicit operator float ([NotNull] KaijuMovement m)
~~~

Implicit conversion to a float from the Weight.

~~~csharp
public static implicit operator float? ([NotNull] KaijuMovement m)
~~~

Implicit conversion to a nullable float from the Weight.

~~~csharp
public static implicit operator double ([NotNull] KaijuMovement m)
~~~

Implicit conversion to a double from the Weight.

~~~csharp
public static implicit operator double? ([NotNull] KaijuMovement m)
~~~

Implicit conversion to a nullable double from the Weight.
