# KaijuSeparationMovementTester

Simple tester for Agents.Movement.KaijuSeparationMovements.

~~~csharp
public class KaijuSeparationMovementTester : KaijuMovementTester
~~~

[Package source](../../Samples~/Movement/KaijuSeparationMovementTester.cs)

<a id="KaijuSolutions_Agents_Samples_Movement_KaijuSeparationMovementTester_Distance"></a>

### Distance

~~~csharp
public float Distance { get; set; }
~~~

The distance to interact with other KaijuSolutions.Agents.KaijuAgents from.

<a id="KaijuSolutions_Agents_Samples_Movement_KaijuSeparationMovementTester_Coefficient"></a>

### Coefficient

~~~csharp
public float Coefficient { get; set; }
~~~

The coefficient to use for inverse square law separation. Zero will use linear separation.

<a id="KaijuSolutions_Agents_Samples_Movement_KaijuSeparationMovementTester_Identifiers"></a>

### Identifiers

~~~csharp
public IReadOnlyList<uint> Identifiers { get; }
~~~

What types of KaijuSolutions.Agents.KaijuAgents to avoid.

<a id="KaijuSolutions_Agents_Samples_Movement_KaijuSeparationMovementTester_Assign"></a>

### Assign

~~~csharp
protected override KaijuMovement Assign ([NotNull] KaijuAgent agent)
~~~

Assign this Agents.Movement.KaijuMovement to the one of the Agents.

<a id="KaijuSolutions_Agents_Samples_Movement_KaijuSeparationMovementTester_ToString"></a>

### ToString

~~~csharp
public override string ToString ()
~~~

Get a description of the object.
