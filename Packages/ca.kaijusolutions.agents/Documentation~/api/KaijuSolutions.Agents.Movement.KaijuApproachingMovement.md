# KaijuApproachingMovement

Base KaijuSolutions.Agents.Movement.KaijuMovement class for moving towards a single target.

~~~csharp
public abstract class KaijuApproachingMovement : KaijuTargetMovement
~~~

[Package source](../../Runtime/Movement/KaijuApproachingMovement.cs)

<a id="KaijuSolutions_Agents_Movement_KaijuApproachingMovement_DefaultDistance"></a>

### DefaultDistance

~~~csharp
public const float DefaultDistance
~~~

The default KaijuSolutions.Agents.Movement.KaijuTargetMovement.Distance of KaijuSolutions.Agents.Movement.KaijuApproachingMovements and KaijuSolutions.Agents.Movement.KaijuPathFollowMovements.

<a id="KaijuSolutions_Agents_Movement_KaijuApproachingMovement_KaijuApproachingMovement"></a>

### KaijuApproachingMovement

~~~csharp
public KaijuApproachingMovement ([NotNull] KaijuAgent agent, Vector2 target, float distance = DefaultDistance, float weight = DefaultWeight)
~~~

Create an approaching movement for a Vector2.

~~~csharp
public KaijuApproachingMovement ([NotNull] KaijuAgent agent, Vector3 target, float distance = DefaultDistance, float weight = DefaultWeight)
~~~

Create an approaching movement for a Vector3.

~~~csharp
public KaijuApproachingMovement ([NotNull] KaijuAgent agent, [NotNull] GameObject target, float distance = DefaultDistance, float weight = DefaultWeight)
~~~

Create an approaching movement for a GameObject.

~~~csharp
public KaijuApproachingMovement ([NotNull] KaijuAgent agent, [NotNull] Component target, float distance = DefaultDistance, float weight = DefaultWeight)
~~~

Create an approaching movement for a component.

<a id="KaijuSolutions_Agents_Movement_KaijuApproachingMovement_Done"></a>

### Done

~~~csharp
public override bool Done ()
~~~

Determine if the KaijuSolutions.Agents.Movement.KaijuMovement is done or not.

<a id="KaijuSolutions_Agents_Movement_KaijuApproachingMovement_ToString"></a>

### ToString

~~~csharp
public override string ToString ()
~~~

Get a description of the object.
