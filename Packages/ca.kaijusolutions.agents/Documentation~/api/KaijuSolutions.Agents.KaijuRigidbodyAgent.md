# KaijuRigidbodyAgent

KaijuSolutions.Agents.KaijuAgent which moves via a rigidbody.

~~~csharp
public sealed class KaijuRigidbodyAgent : KaijuRadiusAgent
~~~

[Package source](../../Runtime/KaijuRigidbodyAgent.cs)

<a id="KaijuSolutions_Agents_KaijuRigidbodyAgent_PhysicsAgent"></a>

### PhysicsAgent

~~~csharp
public override bool PhysicsAgent { get; }
~~~

If this KaijuSolutions.Agents.KaijuAgent should move with the physics system.

<a id="KaijuSolutions_Agents_KaijuRigidbodyAgent_Body"></a>

### Body

~~~csharp
public Rigidbody Body { get; }
~~~

The rigidbody which controls the KaijuSolutions.Agents.KaijuAgent's movement.

<a id="KaijuSolutions_Agents_KaijuRigidbodyAgent_OnDisable"></a>

### OnDisable

~~~csharp
protected override void OnDisable ()
~~~

This function is called when the behaviour becomes disabled.

<a id="KaijuSolutions_Agents_KaijuRigidbodyAgent_Setup"></a>

### Setup

~~~csharp
public override void Setup ()
~~~

Initialize the KaijuSolutions.Agents.KaijuAgent. There is no point in manually calling this.

<a id="KaijuSolutions_Agents_KaijuRigidbodyAgent_Move"></a>

### Move

~~~csharp
public override void Move (float delta)
~~~

Perform KaijuSolutions.Agents.KaijuAgent movement. There is no point in manually calling this.

<a id="KaijuSolutions_Agents_KaijuRigidbodyAgent_ToString"></a>

### ToString

~~~csharp
public override string ToString ()
~~~

Get a description of the object.

~~~csharp
public static implicit operator Rigidbody ([NotNull] KaijuRigidbodyAgent a)
~~~

Implicit conversion to get the rigidbody.

~~~csharp
public static implicit operator KaijuRigidbodyAgent ([NotNull] GameObject o)
~~~

Implicit conversion from a GameObject.

~~~csharp
public static implicit operator KaijuRigidbodyAgent ([NotNull] Transform t)
~~~

Implicit conversion from a transform.
