# KaijuEverythingAttackActuator

KaijuSolutions.Agents.Actuators.KaijuAttackActuator based on transforms, allowing it to attack anything. You can optionally filter objects by name to limit what is returned. As transforms are directly returned by hits in the underlying class, this is actually quite efficient than compared to making a custom version to get a specific component type.

~~~csharp
public class KaijuEverythingAttackActuator : KaijuAttackActuator
~~~

[Package source](../../Runtime/Actuators/KaijuEverythingAttackActuator.cs)

<a id="KaijuSolutions_Agents_Actuators_KaijuEverythingAttackActuator_Matcher"></a>

### Matcher

~~~csharp
public List<KaijuAgentsMultiMatcher> Matcher { get; set; }
~~~

What to match names of the objects to provide extra filtering.

<a id="KaijuSolutions_Agents_Actuators_KaijuEverythingAttackActuator_HandleHit"></a>

### HandleHit

~~~csharp
protected override bool HandleHit (RaycastHit hit, [NotNull] Transform t)
~~~

Handle the hit logic.

<a id="KaijuSolutions_Agents_Actuators_KaijuEverythingAttackActuator_ToString"></a>

### ToString

~~~csharp
public override string ToString ()
~~~

Get a description of the object.

~~~csharp
public static implicit operator KaijuEverythingAttackActuator ([NotNull] GameObject o)
~~~

Implicit conversion from a GameObject.

~~~csharp
public static implicit operator KaijuEverythingAttackActuator ([NotNull] Transform t)
~~~

Implicit conversion from a transform.

~~~csharp
public static implicit operator KaijuAgent ([NotNull] KaijuEverythingAttackActuator s)
~~~

Implicit conversion to a KaijuSolutions.Agents.KaijuAgent.
