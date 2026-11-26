# KaijuRadiusAgent

An KaijuSolutions.Agents.KaijuAgent type which tries to get its radius from colliders or otherwise manually assigns them.

~~~csharp
public abstract class KaijuRadiusAgent : KaijuAgent
~~~

[Package source](../../Runtime/KaijuRadiusAgent.cs)

<a id="KaijuSolutions_Agents_KaijuRadiusAgent_Radius"></a>

### Radius

~~~csharp
public float Radius { get; set; }
~~~

The radius of this KaijuSolutions.Agents.KaijuAgent. If there is an attached collider, this will lock to it and calculate the radius based on its size and cannot be set.

<a id="KaijuSolutions_Agents_KaijuRadiusAgent_GetRadius"></a>

### GetRadius

~~~csharp
public override float GetRadius ()
~~~

Get the radius of an KaijuSolutions.Agents.KaijuAgent.

<a id="KaijuSolutions_Agents_KaijuRadiusAgent_Setup"></a>

### Setup

~~~csharp
public override void Setup ()
~~~

Initialize the KaijuSolutions.Agents.KaijuAgent. There is no point in manually calling this.

<a id="KaijuSolutions_Agents_KaijuRadiusAgent_ToString"></a>

### ToString

~~~csharp
public override string ToString ()
~~~

Get a description of the object.

~~~csharp
public static implicit operator KaijuRadiusAgent ([NotNull] GameObject o)
~~~

Implicit conversion from a GameObject.

~~~csharp
public static implicit operator KaijuRadiusAgent ([NotNull] Transform t)
~~~

Implicit conversion from a transform.
