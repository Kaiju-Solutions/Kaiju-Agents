# KaijuFleeMovement

Flee steering behaviour.

~~~csharp
public class KaijuFleeMovement : KaijuLeavingMovement
~~~

[Package source](../../Runtime/Movement/KaijuFleeMovement.cs)

<a id="KaijuSolutions_Agents_Movement_KaijuFleeMovement_Get"></a>

### Get

~~~csharp
public static KaijuFleeMovement Get ([NotNull] KaijuAgent agent, Vector2 target, float distance = DefaultDistance, float weight = DefaultWeight)
~~~

Get a flee movement.

~~~csharp
public static KaijuFleeMovement Get ([NotNull] KaijuAgent agent, Vector3 target, float distance = DefaultDistance, float weight = DefaultWeight)
~~~

Get a flee movement.

~~~csharp
public static KaijuFleeMovement Get ([NotNull] KaijuAgent agent, [NotNull] GameObject target, float distance = DefaultDistance, float weight = DefaultWeight)
~~~

Get a flee movement.

~~~csharp
public static KaijuFleeMovement Get ([NotNull] KaijuAgent agent, [NotNull] Component target, float distance = DefaultDistance, float weight = DefaultWeight)
~~~

Get a flee movement.

<a id="KaijuSolutions_Agents_Movement_KaijuFleeMovement_KaijuFleeMovement"></a>

### KaijuFleeMovement

~~~csharp
public KaijuFleeMovement ([NotNull] KaijuAgent agent, Vector2 target, float distance = DefaultDistance, float weight = DefaultWeight)
~~~

Create a flee movement.

~~~csharp
public KaijuFleeMovement ([NotNull] KaijuAgent agent, Vector3 target, float distance = DefaultDistance, float weight = DefaultWeight)
~~~

Create a flee movement.

~~~csharp
public KaijuFleeMovement ([NotNull] KaijuAgent agent, [NotNull] GameObject target, float distance = DefaultDistance, float weight = DefaultWeight)
~~~

Create a flee movement.

~~~csharp
public KaijuFleeMovement ([NotNull] KaijuAgent agent, [NotNull] Component target, float distance = DefaultDistance, float weight = DefaultWeight)
~~~

Create a flee movement.

<a id="KaijuSolutions_Agents_Movement_KaijuFleeMovement_Move3"></a>

### Move3

~~~csharp
public override Vector3 Move3 (Vector3 position, float delta)
~~~

<a id="KaijuSolutions_Agents_Movement_KaijuFleeMovement_Calculate"></a>

### Calculate

~~~csharp
protected override Vector2 Calculate (Vector2 position, float speed, Vector2 target, float delta)
~~~

Calculate the movement.

<a id="KaijuSolutions_Agents_Movement_KaijuFleeMovement_EditorVisualizationColor"></a>

### EditorVisualizationColor

~~~csharp
protected override Color EditorVisualizationColor ()
~~~

Get the color for visualizations.

<a id="KaijuSolutions_Agents_Movement_KaijuFleeMovement_ToString"></a>

### ToString

~~~csharp
public override string ToString ()
~~~

Get a description of the object.
