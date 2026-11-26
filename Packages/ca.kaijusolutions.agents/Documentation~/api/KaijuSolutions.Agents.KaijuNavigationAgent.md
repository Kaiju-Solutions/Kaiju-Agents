# KaijuNavigationAgent

KaijuSolutions.Agents.KaijuAgent which moves via a navigation mesh agent.

~~~csharp
public sealed class KaijuNavigationAgent : KaijuAgent
~~~

[Package source](../../Runtime/KaijuNavigationAgent.cs)

<a id="KaijuSolutions_Agents_KaijuNavigationAgent_Nav"></a>

### Nav

~~~csharp
public NavMeshAgent Nav { get; }
~~~

The navigation mesh agent which controls the KaijuSolutions.Agents.KaijuAgent's movement.

<a id="KaijuSolutions_Agents_KaijuNavigationAgent_surfaceSnapDistance"></a>

### surfaceSnapDistance

~~~csharp
public float surfaceSnapDistance
~~~

<a id="KaijuSolutions_Agents_KaijuNavigationAgent_SurfacePosition"></a>

### SurfacePosition

~~~csharp
public Vector3 SurfacePosition { get; }
~~~

Position on the supporting surface, accounting for the agent pivot offset.

<a id="KaijuSolutions_Agents_KaijuNavigationAgent_GetRadius"></a>

### GetRadius

~~~csharp
public override float GetRadius ()
~~~

Get the radius of an KaijuSolutions.Agents.KaijuAgent.

<a id="KaijuSolutions_Agents_KaijuNavigationAgent_OnEnable"></a>

### OnEnable

~~~csharp
protected override void OnEnable ()
~~~

This function is called when the object becomes enabled and active.

<a id="KaijuSolutions_Agents_KaijuNavigationAgent_OnDisable"></a>

### OnDisable

~~~csharp
protected override void OnDisable ()
~~~

This function is called when the behaviour becomes disabled.

<a id="KaijuSolutions_Agents_KaijuNavigationAgent_Setup"></a>

### Setup

~~~csharp
public override void Setup ()
~~~

Initialize the KaijuSolutions.Agents.KaijuAgent. There is no point in manually calling this.

<a id="KaijuSolutions_Agents_KaijuNavigationAgent_Move"></a>

### Move

~~~csharp
public override void Move (float delta)
~~~

Perform KaijuSolutions.Agents.KaijuAgent movement. There is no point in manually calling this.

<a id="KaijuSolutions_Agents_KaijuNavigationAgent_ToString"></a>

### ToString

~~~csharp
public override string ToString ()
~~~

Get a description of the object.

~~~csharp
public static implicit operator NavMeshAgent ([NotNull] KaijuNavigationAgent a)
~~~

Implicit conversion to get the navigation mesh agent.

~~~csharp
public static implicit operator KaijuNavigationAgent ([NotNull] GameObject o)
~~~

Implicit conversion from a GameObject.

~~~csharp
public static implicit operator KaijuNavigationAgent ([NotNull] Transform t)
~~~

Implicit conversion from a transform.
