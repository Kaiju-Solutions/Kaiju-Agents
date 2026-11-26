# KaijuMovementConfiguration

Allow for defining KaijuSolutions.Agents.Movement.KaijuMovement settings for KaijuSolutions.Agents.KaijuAgents to use as default values.

~~~csharp
public class KaijuMovementConfiguration : ScriptableObject
~~~

[Package source](../../Runtime/Movement/KaijuMovementConfiguration.cs)

<a id="KaijuSolutions_Agents_Movement_KaijuMovementConfiguration_DefaultMask"></a>

### DefaultMask

~~~csharp
public const int DefaultMask
~~~

The default collision layer mask.

<a id="KaijuSolutions_Agents_Movement_KaijuMovementConfiguration_Weight"></a>

### Weight

~~~csharp
public float Weight { get; set; }
~~~

The default weight of all KaijuSolutions.Agents.Movement.KaijuMovements.

<a id="KaijuSolutions_Agents_Movement_KaijuMovementConfiguration_clear"></a>

### clear

~~~csharp
public bool clear
~~~

The default behaviour for if new KaijuSolutions.Agents.Movement.KaijuMovements should clear all other current KaijuSolutions.Agents.Movement.KaijuMovements and become the only one the KaijuSolutions.Agents.KaijuAgent is performing.

<a id="KaijuSolutions_Agents_Movement_KaijuMovementConfiguration_ApproachingDistance"></a>

### ApproachingDistance

~~~csharp
public float ApproachingDistance { get; set; }
~~~

The default distance at which we can consider KaijuSolutions.Agents.Movement.KaijuSeekMovement, KaijuSolutions.Agents.Movement.KaijuPursueMovement, and KaijuSolutions.Agents.Movement.KaijuPathFollowMovement behaviours done.

<a id="KaijuSolutions_Agents_Movement_KaijuMovementConfiguration_LeavingDistance"></a>

### LeavingDistance

~~~csharp
public float LeavingDistance { get; set; }
~~~

The default distance at which we can consider KaijuSolutions.Agents.Movement.KaijuFleeMovement and KaijuSolutions.Agents.Movement.KaijuEvadeMovement behaviours done.

<a id="KaijuSolutions_Agents_Movement_KaijuMovementConfiguration_WanderDistance"></a>

### WanderDistance

~~~csharp
public float WanderDistance { get; set; }
~~~

How far out to generate the KaijuSolutions.Agents.Movement.KaijuWanderMovement circles by default.

<a id="KaijuSolutions_Agents_Movement_KaijuMovementConfiguration_WanderRadius"></a>

### WanderRadius

~~~csharp
public float WanderRadius { get; set; }
~~~

The radius of the KaijuSolutions.Agents.Movement.KaijuWanderMovement circles by default.

<a id="KaijuSolutions_Agents_Movement_KaijuMovementConfiguration_SeparationDistance"></a>

### SeparationDistance

~~~csharp
public float SeparationDistance { get; set; }
~~~

The default distance to interact with other KaijuSolutions.Agents.KaijuAgents from.

<a id="KaijuSolutions_Agents_Movement_KaijuMovementConfiguration_SeparationCoefficient"></a>

### SeparationCoefficient

~~~csharp
public float SeparationCoefficient { get; set; }
~~~

The default distance to interact with other KaijuSolutions.Agents.KaijuAgents from.

<a id="KaijuSolutions_Agents_Movement_KaijuMovementConfiguration_Identifiers"></a>

### Identifiers

~~~csharp
public IReadOnlyList<uint> Identifiers { get; }
~~~

Identifiers for KaijuSolutions.Agents.KaijuAgents when separating.

<a id="KaijuSolutions_Agents_Movement_KaijuMovementConfiguration_ClearIdentifiers"></a>

### ClearIdentifiers

~~~csharp
public void ClearIdentifiers ()
~~~

Clear all identifiers.

<a id="KaijuSolutions_Agents_Movement_KaijuMovementConfiguration_HasIdentifier"></a>

### HasIdentifier

~~~csharp
public bool HasIdentifier (uint identifier)
~~~

If this agent has an identifier.

<a id="KaijuSolutions_Agents_Movement_KaijuMovementConfiguration_HasAnyIdentifier"></a>

### HasAnyIdentifier

~~~csharp
public bool HasAnyIdentifier (IEnumerable<uint> collection)
~~~

If this agent has any one of a set of identifiers.

<a id="KaijuSolutions_Agents_Movement_KaijuMovementConfiguration_AddIdentifier"></a>

### AddIdentifier

~~~csharp
public bool AddIdentifier (uint identifier)
~~~

Add an identifier to this agent.

<a id="KaijuSolutions_Agents_Movement_KaijuMovementConfiguration_AddIdentifiers"></a>

### AddIdentifiers

~~~csharp
public bool AddIdentifiers (IEnumerable<uint> collection)
~~~

Add identifiers to this agent.

<a id="KaijuSolutions_Agents_Movement_KaijuMovementConfiguration_RemoveIdentifier"></a>

### RemoveIdentifier

~~~csharp
public bool RemoveIdentifier (uint identifier)
~~~

Remove an identifier from this agent.

<a id="KaijuSolutions_Agents_Movement_KaijuMovementConfiguration_RemoveIdentifiers"></a>

### RemoveIdentifiers

~~~csharp
public bool RemoveIdentifiers (IEnumerable<uint> collection)
~~~

Remove identifiers from this agent.

<a id="KaijuSolutions_Agents_Movement_KaijuMovementConfiguration_SetIdentifier"></a>

### SetIdentifier

~~~csharp
public void SetIdentifier (uint identifier)
~~~

Set an identifier to this agent.

<a id="KaijuSolutions_Agents_Movement_KaijuMovementConfiguration_SetIdentifiers"></a>

### SetIdentifiers

~~~csharp
public void SetIdentifiers (IEnumerable<uint> collection)
~~~

If this agent has any one of a set of identifiers.

<a id="KaijuSolutions_Agents_Movement_KaijuMovementConfiguration_Avoidance"></a>

### Avoidance

~~~csharp
public float Avoidance { get; set; }
~~~

The default distance from a wall the KaijuSolutions.Agents.KaijuAgent should maintain.

<a id="KaijuSolutions_Agents_Movement_KaijuMovementConfiguration_AvoidanceDistance"></a>

### AvoidanceDistance

~~~csharp
public float AvoidanceDistance { get; set; }
~~~

The default distance for rays.

<a id="KaijuSolutions_Agents_Movement_KaijuMovementConfiguration_AvoidanceSideDistance"></a>

### AvoidanceSideDistance

~~~csharp
public float AvoidanceSideDistance { get; set; }
~~~

The default distance of the side rays. Zero or less will use the AvoidanceDistance.

<a id="KaijuSolutions_Agents_Movement_KaijuMovementConfiguration_avoidanceAngle"></a>

### avoidanceAngle

~~~csharp
public float avoidanceAngle
~~~

The default angle for rays.

<a id="KaijuSolutions_Agents_Movement_KaijuMovementConfiguration_avoidanceHeight"></a>

### avoidanceHeight

~~~csharp
public float avoidanceHeight
~~~

The default height offset for the rays.

<a id="KaijuSolutions_Agents_Movement_KaijuMovementConfiguration_avoidanceHorizontal"></a>

### avoidanceHorizontal

~~~csharp
public float avoidanceHorizontal
~~~

The default horizontal shift for the side rays.

<a id="KaijuSolutions_Agents_Movement_KaijuMovementConfiguration_areaMask"></a>

### areaMask

~~~csharp
public int areaMask
~~~

The default bitfield mask specifying which navigation mesh areas can be used for the path.

<a id="KaijuSolutions_Agents_Movement_KaijuMovementConfiguration_collisionMask"></a>

### collisionMask

~~~csharp
public LayerMask collisionMask
~~~

The default layers to use for KaijuSolutions.Agents.Movement.KaijuPathFollowMovement string-pulling and KaijuSolutions.Agents.Movement.KaijuObstacleAvoidanceMovement.

<a id="KaijuSolutions_Agents_Movement_KaijuMovementConfiguration_collisionTriggers"></a>

### collisionTriggers

~~~csharp
public QueryTriggerInteraction collisionTriggers
~~~

How string-pulling should consider triggers by default.

<a id="KaijuSolutions_Agents_Movement_KaijuMovementConfiguration_PathAutoCalculateDistance"></a>

### PathAutoCalculateDistance

~~~csharp
public float PathAutoCalculateDistance { get; set; }
~~~

The default distance to automatically recalculate the path from.

<a id="KaijuSolutions_Agents_Movement_KaijuMovementConfiguration_ToString"></a>

### ToString

~~~csharp
public override string ToString ()
~~~

Get a description of the object.
