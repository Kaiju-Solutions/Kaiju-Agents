# KaijuLeavingMovement

Base KaijuSolutions.Agents.Movement.KaijuMovement class for moving away from a single target.

~~~csharp
public abstract class KaijuLeavingMovement : KaijuTargetMovement
~~~

[Package source](../../Runtime/Movement/KaijuLeavingMovement.cs)

<a id="KaijuSolutions_Agents_Movement_KaijuLeavingMovement_DefaultDistance"></a>

### DefaultDistance

~~~csharp
public const float DefaultDistance
~~~

The default  KaijuSolutions.Agents.Movement.KaijuTargetMovement.Distance of leaving movements.

<a id="KaijuSolutions_Agents_Movement_KaijuLeavingMovement_KaijuLeavingMovement"></a>

### KaijuLeavingMovement

~~~csharp
public KaijuLeavingMovement ([NotNull] KaijuAgent agent, Vector2 target, float distance = DefaultDistance, float weight = DefaultWeight)
~~~

Create a leaving movement for a Vector2.

~~~csharp
public KaijuLeavingMovement ([NotNull] KaijuAgent agent, Vector3 target, float distance = DefaultDistance, float weight = DefaultWeight)
~~~

Create a leaving movement for a Vector3.

~~~csharp
public KaijuLeavingMovement ([NotNull] KaijuAgent agent, [NotNull] GameObject target, float distance = DefaultDistance, float weight = DefaultWeight)
~~~

Create a leaving movement for a GameObject.

~~~csharp
public KaijuLeavingMovement ([NotNull] KaijuAgent agent, [NotNull] Component target, float distance = DefaultDistance, float weight = DefaultWeight)
~~~

Create a leaving movement for a component.

<a id="KaijuSolutions_Agents_Movement_KaijuLeavingMovement_Done"></a>

### Done

~~~csharp
public override bool Done ()
~~~

Determine if the KaijuSolutions.Agents.Movement.KaijuMovement is done or not.

<a id="KaijuSolutions_Agents_Movement_KaijuLeavingMovement_ToString"></a>

### ToString

~~~csharp
public override string ToString ()
~~~

Get a description of the object.
