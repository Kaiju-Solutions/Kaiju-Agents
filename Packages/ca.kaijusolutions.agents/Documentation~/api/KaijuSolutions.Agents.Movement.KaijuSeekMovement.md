# KaijuSeekMovement

Seek steering behaviour.

~~~csharp
public class KaijuSeekMovement : KaijuApproachingMovement
~~~

[Package source](../../Runtime/Movement/KaijuSeekMovement.cs)

<a id="KaijuSolutions_Agents_Movement_KaijuSeekMovement_Get"></a>

### Get

~~~csharp
public static KaijuSeekMovement Get ([NotNull] KaijuAgent agent, Vector2 target, float distance = DefaultDistance, float weight = DefaultWeight)
~~~

Get a seek movement.

~~~csharp
public static KaijuSeekMovement Get ([NotNull] KaijuAgent agent, Vector3 target, float distance = DefaultDistance, float weight = DefaultWeight)
~~~

Get a seek movement.

~~~csharp
public static KaijuSeekMovement Get ([NotNull] KaijuAgent agent, [NotNull] GameObject target, float distance = DefaultDistance, float weight = DefaultWeight)
~~~

Get a seek movement.

~~~csharp
public static KaijuSeekMovement Get ([NotNull] KaijuAgent agent, [NotNull] Component target, float distance = DefaultDistance, float weight = DefaultWeight)
~~~

Get a seek movement.

<a id="KaijuSolutions_Agents_Movement_KaijuSeekMovement_KaijuSeekMovement"></a>

### KaijuSeekMovement

~~~csharp
public KaijuSeekMovement ([NotNull] KaijuAgent agent, Vector2 target, float distance = DefaultDistance, float weight = DefaultWeight)
~~~

Create a seek movement.

~~~csharp
public KaijuSeekMovement ([NotNull] KaijuAgent agent, Vector3 target, float distance = DefaultDistance, float weight = DefaultWeight)
~~~

Create a seek movement.

~~~csharp
public KaijuSeekMovement ([NotNull] KaijuAgent agent, [NotNull] GameObject target, float distance = DefaultDistance, float weight = DefaultWeight)
~~~

Create a seek movement.

~~~csharp
public KaijuSeekMovement ([NotNull] KaijuAgent agent, [NotNull] Component target, float distance = DefaultDistance, float weight = DefaultWeight)
~~~

Create a seek movement.

<a id="KaijuSolutions_Agents_Movement_KaijuSeekMovement_Move3"></a>

### Move3

~~~csharp
public override Vector3 Move3 (Vector3 position, float delta)
~~~

<a id="KaijuSolutions_Agents_Movement_KaijuSeekMovement_Calculate"></a>

### Calculate

~~~csharp
protected override Vector2 Calculate (Vector2 position, float speed, Vector2 target, float delta)
~~~

Calculate the movement.

<a id="KaijuSolutions_Agents_Movement_KaijuSeekMovement_EditorVisualizationColor"></a>

### EditorVisualizationColor

~~~csharp
protected override Color EditorVisualizationColor ()
~~~

Get the color for visualizations.

<a id="KaijuSolutions_Agents_Movement_KaijuSeekMovement_ToString"></a>

### ToString

~~~csharp
public override string ToString ()
~~~

Get a description of the object.
