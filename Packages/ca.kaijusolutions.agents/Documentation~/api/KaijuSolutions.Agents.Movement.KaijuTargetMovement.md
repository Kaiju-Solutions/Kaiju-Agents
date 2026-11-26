# KaijuTargetMovement

Base movement class for moving in relation to a single target.

~~~csharp
public abstract class KaijuTargetMovement : KaijuMovement
~~~

[Package source](../../Runtime/Movement/KaijuTargetMovement.cs)

<a id="KaijuSolutions_Agents_Movement_KaijuTargetMovement_Target"></a>

### Target

~~~csharp
public Vector2 Target { get; set; }
~~~

The position to move in relation to.

<a id="KaijuSolutions_Agents_Movement_KaijuTargetMovement_Target3"></a>

### Target3

~~~csharp
public Vector3 Target3 { get; set; }
~~~

The position to move in relation to.

<a id="KaijuSolutions_Agents_Movement_KaijuTargetMovement_TargetTransform"></a>

### TargetTransform

~~~csharp
public Transform TargetTransform { get; set; }
~~~

The transform to move in relation to.

<a id="KaijuSolutions_Agents_Movement_KaijuTargetMovement_TargetGameObject"></a>

### TargetGameObject

~~~csharp
public GameObject TargetGameObject { get; set; }
~~~

The GameObject to move in relation to.

<a id="KaijuSolutions_Agents_Movement_KaijuTargetMovement_TargetAgent"></a>

### TargetAgent

~~~csharp
public KaijuAgent TargetAgent { get; set; }
~~~

The KaijuSolutions.Agents.KaijuAgent to move in relation to.

<a id="KaijuSolutions_Agents_Movement_KaijuTargetMovement_TargetComponent"></a>

### TargetComponent

~~~csharp
public Component TargetComponent { set; }
~~~

The component to move in relation to.

<a id="KaijuSolutions_Agents_Movement_KaijuTargetMovement_Distance"></a>

### Distance

~~~csharp
public float Distance { get; set; }
~~~

The distance at which we can consider this behaviour done.

<a id="KaijuSolutions_Agents_Movement_KaijuTargetMovement_CurrentDistance"></a>

### CurrentDistance

~~~csharp
public float CurrentDistance { get; }
~~~

The current distance between the KaijuSolutions.Agents.KaijuAgent and the target.

<a id="KaijuSolutions_Agents_Movement_KaijuTargetMovement_CurrentDistance3"></a>

### CurrentDistance3

~~~csharp
public float CurrentDistance3 { get; }
~~~

The current distance between the KaijuSolutions.Agents.KaijuAgent and the target across all axes.

<a id="KaijuSolutions_Agents_Movement_KaijuTargetMovement_KaijuTargetMovement"></a>

### KaijuTargetMovement

~~~csharp
protected KaijuTargetMovement ([NotNull] KaijuAgent agent, Vector2 target, float distance, float weight = DefaultWeight)
~~~

Create the target movement for a Vector2.

~~~csharp
protected KaijuTargetMovement ([NotNull] KaijuAgent agent, Vector3 target, float distance, float weight = DefaultWeight)
~~~

Create the target movement for a Vector3.

~~~csharp
protected KaijuTargetMovement ([NotNull] KaijuAgent agent, [NotNull] GameObject target, float distance, float weight = DefaultWeight)
~~~

Create the target movement for a GameObject.

~~~csharp
protected KaijuTargetMovement ([NotNull] KaijuAgent agent, [NotNull] Component target, float distance, float weight = DefaultWeight)
~~~

Create the target movement for a component.

<a id="KaijuSolutions_Agents_Movement_KaijuTargetMovement_Initialize"></a>

### Initialize

~~~csharp
public void Initialize ([NotNull] KaijuAgent agent, Vector2 target, float distance, float weight = DefaultWeight)
~~~

Initialize the KaijuSolutions.Agents.Movement.KaijuMovement.

~~~csharp
public void Initialize ([NotNull] KaijuAgent agent, Vector3 target, float distance, float weight = DefaultWeight)
~~~

Initialize the KaijuSolutions.Agents.Movement.KaijuMovement.

~~~csharp
public void Initialize ([NotNull] KaijuAgent agent, [NotNull] GameObject target, float distance, float weight = DefaultWeight)
~~~

Initialize the KaijuSolutions.Agents.Movement.KaijuMovement.

~~~csharp
public void Initialize ([NotNull] KaijuAgent agent, [NotNull] Component target, float distance, float weight = DefaultWeight)
~~~

Initialize the KaijuSolutions.Agents.Movement.KaijuMovement.

<a id="KaijuSolutions_Agents_Movement_KaijuTargetMovement_Reset"></a>

### Reset

~~~csharp
protected override void Reset ()
~~~

Perform any needed reset operations.

<a id="KaijuSolutions_Agents_Movement_KaijuTargetMovement_Move"></a>

### Move

~~~csharp
public override Vector2 Move (Vector2 position, float delta)
~~~

Get the KaijuSolutions.Agents.Movement.KaijuMovement.

<a id="KaijuSolutions_Agents_Movement_KaijuTargetMovement_Done"></a>

### Done

~~~csharp
public override bool Done ()
~~~

Determine if the KaijuSolutions.Agents.Movement.KaijuMovement is done or not.

<a id="KaijuSolutions_Agents_Movement_KaijuTargetMovement_Calculate"></a>

### Calculate

~~~csharp
protected abstract Vector2 Calculate (Vector2 position, float speed, Vector2 target, float delta)
~~~

Calculate the movement.

<a id="KaijuSolutions_Agents_Movement_KaijuTargetMovement_EditorRenderVisualizations"></a>

### EditorRenderVisualizations

~~~csharp
protected override void EditorRenderVisualizations (Vector3 position)
~~~

Render the visualization of the KaijuSolutions.Agents.Movement.KaijuMovement. The position of the KaijuSolutions.Agents.Movement.KaijuMovement.Agent.

<a id="KaijuSolutions_Agents_Movement_KaijuTargetMovement_RenderDistance"></a>

### RenderDistance

~~~csharp
protected void RenderDistance (Vector3 target)
~~~

Render the distance visualization.

<a id="KaijuSolutions_Agents_Movement_KaijuTargetMovement_ToString"></a>

### ToString

~~~csharp
public override string ToString ()
~~~

Get a description of the object.

~~~csharp
public static implicit operator Vector2? ([NotNull] KaijuTargetMovement t)
~~~

Implicit conversion to a nullable Vector2 from the target.

~~~csharp
public static implicit operator Vector2 ([NotNull] KaijuTargetMovement t)
~~~

Implicit conversion to a Vector2 from the target.

~~~csharp
public static implicit operator Vector3? ([NotNull] KaijuTargetMovement t)
~~~

Implicit conversion to a nullable Vector3 from the target.

~~~csharp
public static implicit operator Vector3 ([NotNull] KaijuTargetMovement t)
~~~

Implicit conversion to a Vector3 from the target.

~~~csharp
public static implicit operator Transform ([NotNull] KaijuTargetMovement t)
~~~

Implicit conversion to a transform from the target.

~~~csharp
public static implicit operator GameObject ([NotNull] KaijuTargetMovement t)
~~~

Implicit conversion to a GameObject from the target.

~~~csharp
public static implicit operator KaijuAgent ([NotNull] KaijuTargetMovement t)
~~~

Implicit conversion to a KaijuSolutions.Agents.KaijuAgent from the target.
