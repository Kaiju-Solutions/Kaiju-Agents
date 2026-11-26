# KaijuMovementTester

Simple tester for Agents.Movement.KaijuMovements.

~~~csharp
public abstract class KaijuMovementTester : KaijuBehaviour
~~~

[Package source](../../Samples~/Movement/KaijuMovementTester.cs)

<a id="KaijuSolutions_Agents_Samples_Movement_KaijuMovementTester_Agents"></a>

### Agents

~~~csharp
public List<KaijuAgent> Agents { get; set; }
~~~

The KaijuSolutions.Agents.KaijuAgents to test the Agents.Movement.KaijuMovement of.

<a id="KaijuSolutions_Agents_Samples_Movement_KaijuMovementTester_Weight"></a>

### Weight

~~~csharp
public float Weight { get; set; }
~~~

The weight of this Agents.Movement.KaijuMovement.

<a id="KaijuSolutions_Agents_Samples_Movement_KaijuMovementTester_clear"></a>

### clear

~~~csharp
public bool clear
~~~

If this should clear other Agents.Movement.KaijuMovement.

<a id="KaijuSolutions_Agents_Samples_Movement_KaijuMovementTester_Assign"></a>

### Assign

~~~csharp
protected abstract KaijuMovement Assign ([NotNull] KaijuAgent agent)
~~~

Assign this Agents.Movement.KaijuMovement to the one of the Agents.

<a id="KaijuSolutions_Agents_Samples_Movement_KaijuMovementTester_ToString"></a>

### ToString

~~~csharp
public override string ToString ()
~~~

Get a description of the object.
