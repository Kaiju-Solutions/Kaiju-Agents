# KaijuCharacterAgent

KaijuSolutions.Agents.KaijuAgent which moves via a chracter controller.

~~~csharp
public sealed class KaijuCharacterAgent : KaijuAgent
~~~

[Package source](../../Runtime/KaijuCharacterAgent.cs)

<a id="KaijuSolutions_Agents_KaijuCharacterAgent_gravity"></a>

### gravity

~~~csharp
public bool gravity
~~~

If gravity should be applied to the KaijuSolutions.Agents.KaijuAgent.

<a id="KaijuSolutions_Agents_KaijuCharacterAgent_Character"></a>

### Character

~~~csharp
public CharacterController Character { get; }
~~~

The chracter controller which controls the KaijuSolutions.Agents.KaijuAgent's movement.

<a id="KaijuSolutions_Agents_KaijuCharacterAgent_OnEnable"></a>

### OnEnable

~~~csharp
protected override void OnEnable ()
~~~

This function is called when the object becomes enabled and active.

<a id="KaijuSolutions_Agents_KaijuCharacterAgent_OnDisable"></a>

### OnDisable

~~~csharp
protected override void OnDisable ()
~~~

This function is called when the behaviour becomes disabled.

<a id="KaijuSolutions_Agents_KaijuCharacterAgent_Setup"></a>

### Setup

~~~csharp
public override void Setup ()
~~~

Initialize the KaijuSolutions.Agents.KaijuAgent. There is no point in manually calling this.

<a id="KaijuSolutions_Agents_KaijuCharacterAgent_GetRadius"></a>

### GetRadius

~~~csharp
public override float GetRadius ()
~~~

Get the radius of an KaijuSolutions.Agents.KaijuAgent.

<a id="KaijuSolutions_Agents_KaijuCharacterAgent_Move"></a>

### Move

~~~csharp
public override void Move (float delta)
~~~

Perform KaijuSolutions.Agents.KaijuAgent movement. There is no point in manually calling this.

<a id="KaijuSolutions_Agents_KaijuCharacterAgent_ToString"></a>

### ToString

~~~csharp
public override string ToString ()
~~~

Get a description of the object.

~~~csharp
public static implicit operator CharacterController ([NotNull] KaijuCharacterAgent a)
~~~

Implicit conversion to get the chracter controller.

~~~csharp
public static implicit operator KaijuCharacterAgent ([NotNull] GameObject o)
~~~

Implicit conversion from a GameObject.

~~~csharp
public static implicit operator KaijuCharacterAgent ([NotNull] Transform t)
~~~

Implicit conversion from a transform.
