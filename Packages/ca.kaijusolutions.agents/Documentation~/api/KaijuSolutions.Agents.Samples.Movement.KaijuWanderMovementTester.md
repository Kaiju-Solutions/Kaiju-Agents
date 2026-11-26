# KaijuWanderMovementTester

Simple tester for Agents.Movement.KaijuWanderMovements.

~~~csharp
public class KaijuWanderMovementTester : KaijuMovementTester
~~~

[Package source](../../Samples~/Movement/KaijuWanderMovementTester.cs)

<a id="KaijuSolutions_Agents_Samples_Movement_KaijuWanderMovementTester_Distance"></a>

### Distance

~~~csharp
public float Distance { get; set; }
~~~

How far out to generate the wander circle.

<a id="KaijuSolutions_Agents_Samples_Movement_KaijuWanderMovementTester_Radius"></a>

### Radius

~~~csharp
public float Radius { get; set; }
~~~

The radius of the wander circle.

<a id="KaijuSolutions_Agents_Samples_Movement_KaijuWanderMovementTester_Assign"></a>

### Assign

~~~csharp
protected override KaijuMovement Assign ([NotNull] KaijuAgent agent)
~~~

Assign this Agents.Movement.KaijuMovement to the one of the Agents.

<a id="KaijuSolutions_Agents_Samples_Movement_KaijuWanderMovementTester_ToString"></a>

### ToString

~~~csharp
public override string ToString ()
~~~

Get a description of the object.
