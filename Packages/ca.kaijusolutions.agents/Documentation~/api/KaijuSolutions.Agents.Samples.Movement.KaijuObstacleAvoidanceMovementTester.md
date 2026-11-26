# KaijuObstacleAvoidanceMovementTester

Simple tester for Agents.Movement.KaijuObstacleAvoidanceMovements.

~~~csharp
public class KaijuObstacleAvoidanceMovementTester : KaijuMovementTester
~~~

[Package source](../../Samples~/Movement/KaijuObstacleAvoidanceMovementTester.cs)

<a id="KaijuSolutions_Agents_Samples_Movement_KaijuObstacleAvoidanceMovementTester_Avoidance"></a>

### Avoidance

~~~csharp
public float Avoidance { get; set; }
~~~

The distance from a wall the KaijuSolutions.Agents.KaijuAgent should maintain.

<a id="KaijuSolutions_Agents_Samples_Movement_KaijuObstacleAvoidanceMovementTester_Distance"></a>

### Distance

~~~csharp
public float Distance { get; set; }
~~~

The distance for rays.

<a id="KaijuSolutions_Agents_Samples_Movement_KaijuObstacleAvoidanceMovementTester_SideDistance"></a>

### SideDistance

~~~csharp
public float SideDistance { get; set; }
~~~

The distance of the side rays. Zero or less will use the Distance.

<a id="KaijuSolutions_Agents_Samples_Movement_KaijuObstacleAvoidanceMovementTester_angle"></a>

### angle

~~~csharp
public float angle
~~~

The angle for rays.

<a id="KaijuSolutions_Agents_Samples_Movement_KaijuObstacleAvoidanceMovementTester_height"></a>

### height

~~~csharp
public float height
~~~

The height offset for the rays.

<a id="KaijuSolutions_Agents_Samples_Movement_KaijuObstacleAvoidanceMovementTester_horizontal"></a>

### horizontal

~~~csharp
public float horizontal
~~~

The horizontal shift for the side rays.

<a id="KaijuSolutions_Agents_Samples_Movement_KaijuObstacleAvoidanceMovementTester_Assign"></a>

### Assign

~~~csharp
protected override KaijuMovement Assign ([NotNull] KaijuAgent agent)
~~~

Assign this Agents.Movement.KaijuMovement to the one of the Agents.

<a id="KaijuSolutions_Agents_Samples_Movement_KaijuObstacleAvoidanceMovementTester_ToString"></a>

### ToString

~~~csharp
public override string ToString ()
~~~

Get a description of the object.
