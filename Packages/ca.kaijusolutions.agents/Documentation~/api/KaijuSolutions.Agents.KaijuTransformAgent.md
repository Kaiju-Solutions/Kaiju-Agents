# KaijuTransformAgent

KaijuSolutions.Agents.KaijuAgent which moves via the transform.

~~~csharp
public sealed class KaijuTransformAgent : KaijuRadiusAgent
~~~

[Package source](../../Runtime/KaijuTransformAgent.cs)

<a id="KaijuSolutions_Agents_KaijuTransformAgent_Move"></a>

### Move

~~~csharp
public override void Move (float delta)
~~~

Perform KaijuSolutions.Agents.KaijuAgent movement. There is no point in manually calling this.

<a id="KaijuSolutions_Agents_KaijuTransformAgent_ToString"></a>

### ToString

~~~csharp
public override string ToString ()
~~~

Get a description of the object.

~~~csharp
public static implicit operator KaijuTransformAgent ([NotNull] GameObject o)
~~~

Implicit conversion from a GameObject.

~~~csharp
public static implicit operator KaijuTransformAgent ([NotNull] Transform t)
~~~

Implicit conversion from a transform.
