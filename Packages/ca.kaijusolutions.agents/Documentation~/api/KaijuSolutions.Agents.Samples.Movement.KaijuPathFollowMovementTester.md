# KaijuPathFollowMovementTester

Simple tester for Agents.Movement.KaijuPathFollowMovements.

~~~csharp
public class KaijuPathFollowMovementTester : KaijuMovementTester
~~~

[Package source](../../Samples~/Movement/KaijuPathFollowMovementTester.cs)

<a id="KaijuSolutions_Agents_Samples_Movement_KaijuPathFollowMovementTester_Distance"></a>

### Distance

~~~csharp
public float Distance { get; set; }
~~~

The distance at which we can consider this behaviour done.

<a id="KaijuSolutions_Agents_Samples_Movement_KaijuPathFollowMovementTester_mask"></a>

### mask

~~~csharp
public LayerMask mask
~~~

A bitfield mask specifying which navigation mesh areas can be used for the path.

<a id="KaijuSolutions_Agents_Samples_Movement_KaijuPathFollowMovementTester_AutoCalculateDistance"></a>

### AutoCalculateDistance

~~~csharp
public float AutoCalculateDistance { get; set; }
~~~

The distance to automatically recalculate the path from.

<a id="KaijuSolutions_Agents_Samples_Movement_KaijuPathFollowMovementTester_collisionMask"></a>

### collisionMask

~~~csharp
public int collisionMask
~~~

The collision mask for string-pulling line-of-sight checks.

<a id="KaijuSolutions_Agents_Samples_Movement_KaijuPathFollowMovementTester_triggers"></a>

### triggers

~~~csharp
public QueryTriggerInteraction triggers
~~~

How line-of-sight checks should handle triggers.

<a id="KaijuSolutions_Agents_Samples_Movement_KaijuPathFollowMovementTester_Assign"></a>

### Assign

~~~csharp
protected override KaijuMovement Assign ([NotNull] KaijuAgent agent)
~~~

Assign this Agents.Movement.KaijuMovement to the one of the Agents.

<a id="KaijuSolutions_Agents_Samples_Movement_KaijuPathFollowMovementTester_ToString"></a>

### ToString

~~~csharp
public override string ToString ()
~~~

Get a description of the object.
