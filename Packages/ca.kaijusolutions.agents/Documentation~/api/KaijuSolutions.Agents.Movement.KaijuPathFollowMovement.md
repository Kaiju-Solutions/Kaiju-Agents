# KaijuPathFollowMovement

Path following steering behaviour.

~~~csharp
public class KaijuPathFollowMovement : KaijuMovement
~~~

[Package source](../../Runtime/Movement/KaijuPathFollowMovement.cs)

<a id="KaijuSolutions_Agents_Movement_KaijuPathFollowMovement_DefaultMask"></a>

### DefaultMask

~~~csharp
public const int DefaultMask
~~~

The default Mask for path follow movements.

<a id="KaijuSolutions_Agents_Movement_KaijuPathFollowMovement_DefaultAutoCalculateDistance"></a>

### DefaultAutoCalculateDistance

~~~csharp
public const float DefaultAutoCalculateDistance
~~~

The default AutoCalculateDistance for path follow movements.

<a id="KaijuSolutions_Agents_Movement_KaijuPathFollowMovement_Target"></a>

### Target

~~~csharp
public Vector2 Target { get; set; }
~~~

The position to move in relation to.

<a id="KaijuSolutions_Agents_Movement_KaijuPathFollowMovement_Target3"></a>

### Target3

~~~csharp
public Vector3 Target3 { get; set; }
~~~

The position to move in relation to.

<a id="KaijuSolutions_Agents_Movement_KaijuPathFollowMovement_TargetTransform"></a>

### TargetTransform

~~~csharp
public Transform TargetTransform { get; set; }
~~~

The transform to move in relation to.

<a id="KaijuSolutions_Agents_Movement_KaijuPathFollowMovement_TargetGameObject"></a>

### TargetGameObject

~~~csharp
public GameObject TargetGameObject { get; set; }
~~~

The GameObject to move in relation to.

<a id="KaijuSolutions_Agents_Movement_KaijuPathFollowMovement_TargetAgent"></a>

### TargetAgent

~~~csharp
public KaijuAgent TargetAgent { get; set; }
~~~

The KaijuSolutions.Agents.KaijuAgent to move in relation to.

<a id="KaijuSolutions_Agents_Movement_KaijuPathFollowMovement_TargetComponent"></a>

### TargetComponent

~~~csharp
public Component TargetComponent { set; }
~~~

The component to move in relation to.

<a id="KaijuSolutions_Agents_Movement_KaijuPathFollowMovement_Path"></a>

### Path

~~~csharp
public IReadOnlyList<Vector3> Path { get; }
~~~

The path of points to follow.

<a id="KaijuSolutions_Agents_Movement_KaijuPathFollowMovement_HasCompleteSurfaceRoute"></a>

### HasCompleteSurfaceRoute

~~~csharp
public bool HasCompleteSurfaceRoute { get; private set; }
~~~

<a id="KaijuSolutions_Agents_Movement_KaijuPathFollowMovement_Distance"></a>

### Distance

~~~csharp
public float Distance { get; set; }
~~~

The distance at which we can consider this behaviour done.

<a id="KaijuSolutions_Agents_Movement_KaijuPathFollowMovement_CurrentDistance"></a>

### CurrentDistance

~~~csharp
public float CurrentDistance { get; }
~~~

The current distance between the KaijuSolutions.Agents.KaijuAgent and the target.

<a id="KaijuSolutions_Agents_Movement_KaijuPathFollowMovement_CurrentDistance3"></a>

### CurrentDistance3

~~~csharp
public float CurrentDistance3 { get; }
~~~

The current distance between the KaijuSolutions.Agents.KaijuAgent and the target across all axes.

<a id="KaijuSolutions_Agents_Movement_KaijuPathFollowMovement_PathDistance"></a>

### PathDistance

~~~csharp
public float PathDistance { get; }
~~~

The total distance from the KaijuSolutions.Agents.KaijuAgent along the Path to the Target along the X and Z axes.

<a id="KaijuSolutions_Agents_Movement_KaijuPathFollowMovement_PathDistance3"></a>

### PathDistance3

~~~csharp
public float PathDistance3 { get; }
~~~

The total distance from the KaijuSolutions.Agents.KaijuAgent along the Path to the Target3 along all three axes.

<a id="KaijuSolutions_Agents_Movement_KaijuPathFollowMovement_AutoCalculateDistance"></a>

### AutoCalculateDistance

~~~csharp
public float? AutoCalculateDistance { get; set; }
~~~

The distance to automatically recalculate the path from, with NULL not performing recalculations automatically.

<a id="KaijuSolutions_Agents_Movement_KaijuPathFollowMovement_Previous"></a>

### Previous

~~~csharp
public Vector2 Previous { get; set; }
~~~

The previous position of the Target3.

<a id="KaijuSolutions_Agents_Movement_KaijuPathFollowMovement_Previous3"></a>

### Previous3

~~~csharp
public Vector3 Previous3
~~~

The previous position of the Target3.

<a id="KaijuSolutions_Agents_Movement_KaijuPathFollowMovement_Mask"></a>

### Mask

~~~csharp
public int Mask { get; set; }
~~~

A bitfield mask specifying which navigation mesh areas can be used for the path.

<a id="KaijuSolutions_Agents_Movement_KaijuPathFollowMovement_MaskAssigned"></a>

### MaskAssigned

~~~csharp
public int? MaskAssigned { get; set; }
~~~

A bitfield mask specifying which navigation mesh areas can be used for the path.

<a id="KaijuSolutions_Agents_Movement_KaijuPathFollowMovement_Filter"></a>

### Filter

~~~csharp
public NavMeshQueryFilter? Filter { get; set; }
~~~

Filter for the navigation calculations.

<a id="KaijuSolutions_Agents_Movement_KaijuPathFollowMovement_CollisionMask"></a>

### CollisionMask

~~~csharp
public int CollisionMask
~~~

The collision mask for string-pulling line-of-sight checks.

<a id="KaijuSolutions_Agents_Movement_KaijuPathFollowMovement_Triggers"></a>

### Triggers

~~~csharp
public QueryTriggerInteraction Triggers
~~~

How line-of-sight checks should handle triggers.

<a id="KaijuSolutions_Agents_Movement_KaijuPathFollowMovement_Get"></a>

### Get

~~~csharp
public static KaijuPathFollowMovement Get ([NotNull] KaijuAgent agent, Vector2 target, int mask= DefaultMask, float distance = KaijuApproachingMovement.DefaultDistance, float? autoCalculateDistance = DefaultAutoCalculateDistance, int collisionMask = KaijuMovementConfiguration.DefaultMask, QueryTriggerInteraction triggers = QueryTriggerInteraction.UseGlobal, float weight = DefaultWeight)
~~~

Get a path follow movement.

~~~csharp
public static KaijuPathFollowMovement Get ([NotNull] KaijuAgent agent, Vector3 target, int mask= DefaultMask, float distance = KaijuApproachingMovement.DefaultDistance, float? autoCalculateDistance = DefaultAutoCalculateDistance, int collisionMask = KaijuMovementConfiguration.DefaultMask, QueryTriggerInteraction triggers = QueryTriggerInteraction.UseGlobal, float weight = DefaultWeight)
~~~

Get a path follow movement.

~~~csharp
public static KaijuPathFollowMovement Get ([NotNull] KaijuAgent agent, Component target, int mask= DefaultMask, float distance = KaijuApproachingMovement.DefaultDistance, float? autoCalculateDistance = DefaultAutoCalculateDistance, int collisionMask = KaijuMovementConfiguration.DefaultMask, QueryTriggerInteraction triggers = QueryTriggerInteraction.UseGlobal, float weight = DefaultWeight)
~~~

Get a path follow movement.

~~~csharp
public static KaijuPathFollowMovement Get ([NotNull] KaijuAgent agent, GameObject target, int mask= DefaultMask, float distance = KaijuApproachingMovement.DefaultDistance, float? autoCalculateDistance = DefaultAutoCalculateDistance, int collisionMask = KaijuMovementConfiguration.DefaultMask, QueryTriggerInteraction triggers = QueryTriggerInteraction.UseGlobal, float weight = DefaultWeight)
~~~

Get a path follow movement.

~~~csharp
public static KaijuPathFollowMovement Get ([NotNull] KaijuAgent agent, Vector2 target, NavMeshQueryFilter filter, float distance = KaijuApproachingMovement.DefaultDistance, float? autoCalculateDistance = DefaultAutoCalculateDistance, int collisionMask = KaijuMovementConfiguration.DefaultMask, QueryTriggerInteraction triggers = QueryTriggerInteraction.UseGlobal, float weight = DefaultWeight)
~~~

Get a path follow movement.

~~~csharp
public static KaijuPathFollowMovement Get ([NotNull] KaijuAgent agent, Vector3 target, NavMeshQueryFilter filter, float distance = KaijuApproachingMovement.DefaultDistance, float? autoCalculateDistance = DefaultAutoCalculateDistance, int collisionMask = KaijuMovementConfiguration.DefaultMask, QueryTriggerInteraction triggers = QueryTriggerInteraction.UseGlobal, float weight = DefaultWeight)
~~~

Get a path follow movement.

~~~csharp
public static KaijuPathFollowMovement Get ([NotNull] KaijuAgent agent, Component target, NavMeshQueryFilter filter, float distance = KaijuApproachingMovement.DefaultDistance, float? autoCalculateDistance = DefaultAutoCalculateDistance, int collisionMask = KaijuMovementConfiguration.DefaultMask, QueryTriggerInteraction triggers = QueryTriggerInteraction.UseGlobal, float weight = DefaultWeight)
~~~

Get a path follow movement.

~~~csharp
public static KaijuPathFollowMovement Get ([NotNull] KaijuAgent agent, GameObject target, NavMeshQueryFilter filter, float distance = KaijuApproachingMovement.DefaultDistance, float? autoCalculateDistance = DefaultAutoCalculateDistance, int collisionMask = KaijuMovementConfiguration.DefaultMask, QueryTriggerInteraction triggers = QueryTriggerInteraction.UseGlobal, float weight = DefaultWeight)
~~~

Get a path follow movement.

<a id="KaijuSolutions_Agents_Movement_KaijuPathFollowMovement_KaijuPathFollowMovement"></a>

### KaijuPathFollowMovement

~~~csharp
public KaijuPathFollowMovement ([NotNull] KaijuAgent agent, Vector2 target, int mask= DefaultMask, float distance = KaijuApproachingMovement.DefaultDistance, float? autoCalculateDistance = DefaultAutoCalculateDistance, int collisionMask = KaijuMovementConfiguration.DefaultMask, QueryTriggerInteraction triggers = QueryTriggerInteraction.UseGlobal, float weight = DefaultWeight)
~~~

Create a path follow movement.

~~~csharp
public KaijuPathFollowMovement ([NotNull] KaijuAgent agent, Vector3 target, int mask= DefaultMask, float distance = KaijuApproachingMovement.DefaultDistance, float? autoCalculateDistance = DefaultAutoCalculateDistance, int collisionMask = KaijuMovementConfiguration.DefaultMask, QueryTriggerInteraction triggers = QueryTriggerInteraction.UseGlobal, float weight = DefaultWeight)
~~~

Create a path follow movement.

~~~csharp
public KaijuPathFollowMovement ([NotNull] KaijuAgent agent, [NotNull] GameObject target, int mask= DefaultMask, float distance = KaijuApproachingMovement.DefaultDistance, float? autoCalculateDistance = DefaultAutoCalculateDistance, int collisionMask = KaijuMovementConfiguration.DefaultMask, QueryTriggerInteraction triggers = QueryTriggerInteraction.UseGlobal, float weight = DefaultWeight)
~~~

Create a path follow movement.

~~~csharp
public KaijuPathFollowMovement ([NotNull] KaijuAgent agent, [NotNull] Component target, int mask= DefaultMask, float distance = KaijuApproachingMovement.DefaultDistance, float? autoCalculateDistance = DefaultAutoCalculateDistance, int collisionMask = KaijuMovementConfiguration.DefaultMask, QueryTriggerInteraction triggers = QueryTriggerInteraction.UseGlobal, float weight = DefaultWeight)
~~~

Create a path follow movement.

~~~csharp
public KaijuPathFollowMovement ([NotNull] KaijuAgent agent, Vector2 target, NavMeshQueryFilter filter, float distance = KaijuApproachingMovement.DefaultDistance, float? autoCalculateDistance = DefaultAutoCalculateDistance, int collisionMask = KaijuMovementConfiguration.DefaultMask, QueryTriggerInteraction triggers = QueryTriggerInteraction.UseGlobal, float weight = DefaultWeight)
~~~

Create a path follow movement.

~~~csharp
public KaijuPathFollowMovement ([NotNull] KaijuAgent agent, Vector3 target, NavMeshQueryFilter filter, float distance = KaijuApproachingMovement.DefaultDistance, float? autoCalculateDistance = DefaultAutoCalculateDistance, int collisionMask = KaijuMovementConfiguration.DefaultMask, QueryTriggerInteraction triggers = QueryTriggerInteraction.UseGlobal, float weight = DefaultWeight)
~~~

Create a path follow movement.

~~~csharp
public KaijuPathFollowMovement ([NotNull] KaijuAgent agent, [NotNull] GameObject target, NavMeshQueryFilter filter, float distance = KaijuApproachingMovement.DefaultDistance, float? autoCalculateDistance = DefaultAutoCalculateDistance, int collisionMask = KaijuMovementConfiguration.DefaultMask, QueryTriggerInteraction triggers = QueryTriggerInteraction.UseGlobal, float weight = DefaultWeight)
~~~

Create a path follow movement.

~~~csharp
public KaijuPathFollowMovement ([NotNull] KaijuAgent agent, [NotNull] Component target, NavMeshQueryFilter filter, float distance = KaijuApproachingMovement.DefaultDistance, float? autoCalculateDistance = DefaultAutoCalculateDistance, int collisionMask = KaijuMovementConfiguration.DefaultMask, QueryTriggerInteraction triggers = QueryTriggerInteraction.UseGlobal, float weight = DefaultWeight)
~~~

Create a path follow movement.

<a id="KaijuSolutions_Agents_Movement_KaijuPathFollowMovement_Initialize"></a>

### Initialize

~~~csharp
public void Initialize ([NotNull] KaijuAgent agent, Vector2 target, float distance, int mask= DefaultMask, float? autoCalculateDistance = DefaultAutoCalculateDistance, int collisionMask = KaijuMovementConfiguration.DefaultMask, QueryTriggerInteraction triggers = QueryTriggerInteraction.UseGlobal, float weight = DefaultWeight)
~~~

Initialize the KaijuSolutions.Agents.Movement.KaijuMovement.

~~~csharp
public void Initialize ([NotNull] KaijuAgent agent, Vector3 target, float distance, int mask= DefaultMask, float? autoCalculateDistance = DefaultAutoCalculateDistance, int collisionMask = KaijuMovementConfiguration.DefaultMask, QueryTriggerInteraction triggers = QueryTriggerInteraction.UseGlobal, float weight = DefaultWeight)
~~~

Initialize the KaijuSolutions.Agents.Movement.KaijuMovement.

~~~csharp
public void Initialize ([NotNull] KaijuAgent agent, [NotNull] Component target, float distance, int mask= DefaultMask, float? autoCalculateDistance = DefaultAutoCalculateDistance, int collisionMask = KaijuMovementConfiguration.DefaultMask, QueryTriggerInteraction triggers = QueryTriggerInteraction.UseGlobal, float weight = DefaultWeight)
~~~

Initialize the KaijuSolutions.Agents.Movement.KaijuMovement.

~~~csharp
public void Initialize ([NotNull] KaijuAgent agent, [NotNull] GameObject target, float distance, int mask= DefaultMask, float? autoCalculateDistance = DefaultAutoCalculateDistance, int collisionMask = KaijuMovementConfiguration.DefaultMask, QueryTriggerInteraction triggers = QueryTriggerInteraction.UseGlobal, float weight = DefaultWeight)
~~~

Initialize the KaijuSolutions.Agents.Movement.KaijuMovement.

~~~csharp
public void Initialize ([NotNull] KaijuAgent agent, Vector2 target, float distance, NavMeshQueryFilter filter, float? autoCalculateDistance = DefaultAutoCalculateDistance, int collisionMask = KaijuMovementConfiguration.DefaultMask, QueryTriggerInteraction triggers = QueryTriggerInteraction.UseGlobal, float weight = DefaultWeight)
~~~

Initialize the KaijuSolutions.Agents.Movement.KaijuMovement.

~~~csharp
public void Initialize ([NotNull] KaijuAgent agent, Vector3 target, float distance, NavMeshQueryFilter filter, float? autoCalculateDistance = DefaultAutoCalculateDistance, int collisionMask = KaijuMovementConfiguration.DefaultMask, QueryTriggerInteraction triggers = QueryTriggerInteraction.UseGlobal, float weight = DefaultWeight)
~~~

Initialize the KaijuSolutions.Agents.Movement.KaijuMovement.

~~~csharp
public void Initialize ([NotNull] KaijuAgent agent, [NotNull] Component target, float distance, NavMeshQueryFilter filter, float? autoCalculateDistance = DefaultAutoCalculateDistance, int collisionMask = KaijuMovementConfiguration.DefaultMask, QueryTriggerInteraction triggers = QueryTriggerInteraction.UseGlobal, float weight = DefaultWeight)
~~~

Initialize the KaijuSolutions.Agents.Movement.KaijuMovement.

~~~csharp
public void Initialize ([NotNull] KaijuAgent agent, [NotNull] GameObject target, float distance, NavMeshQueryFilter filter, float? autoCalculateDistance = DefaultAutoCalculateDistance, int collisionMask = KaijuMovementConfiguration.DefaultMask, QueryTriggerInteraction triggers = QueryTriggerInteraction.UseGlobal, float weight = DefaultWeight)
~~~

Initialize the KaijuSolutions.Agents.Movement.KaijuMovement.

<a id="KaijuSolutions_Agents_Movement_KaijuPathFollowMovement_CalculatePath"></a>

### CalculatePath

~~~csharp
public void CalculatePath ()
~~~

Calculate the path to the target.

<a id="KaijuSolutions_Agents_Movement_KaijuPathFollowMovement_Reset"></a>

### Reset

~~~csharp
protected override void Reset ()
~~~

Perform any needed reset operations.

<a id="KaijuSolutions_Agents_Movement_KaijuPathFollowMovement_Done"></a>

### Done

~~~csharp
public override bool Done ()
~~~

Determine if the KaijuSolutions.Agents.Movement.KaijuMovement is done or not.

<a id="KaijuSolutions_Agents_Movement_KaijuPathFollowMovement_Move"></a>

### Move

~~~csharp
public override Vector2 Move (Vector2 position, float delta)
~~~

Get the KaijuSolutions.Agents.Movement.KaijuMovement.

<a id="KaijuSolutions_Agents_Movement_KaijuPathFollowMovement_EditorVisualizationColor"></a>

### EditorVisualizationColor

~~~csharp
protected override Color EditorVisualizationColor ()
~~~

Get the color for visualizations.

<a id="KaijuSolutions_Agents_Movement_KaijuPathFollowMovement_EditorRenderVisualizations"></a>

### EditorRenderVisualizations

~~~csharp
protected override void EditorRenderVisualizations (Vector3 position)
~~~

Render the visualization of the KaijuSolutions.Agents.Movement.KaijuMovement. The position of the KaijuSolutions.Agents.Movement.KaijuMovement.Agent.

<a id="KaijuSolutions_Agents_Movement_KaijuPathFollowMovement_ToString"></a>

### ToString

~~~csharp
public override string ToString ()
~~~

Get a description of the object.

~~~csharp
public static implicit operator Vector2? ([NotNull] KaijuPathFollowMovement t)
~~~

Implicit conversion to a nullable Vector2 from the target.

~~~csharp
public static implicit operator Vector2 ([NotNull] KaijuPathFollowMovement t)
~~~

Implicit conversion to a Vector2 from the target.

~~~csharp
public static implicit operator Vector3? ([NotNull] KaijuPathFollowMovement t)
~~~

Implicit conversion to a nullable Vector3 from the target.

~~~csharp
public static implicit operator Vector3 ([NotNull] KaijuPathFollowMovement t)
~~~

Implicit conversion to a Vector3 from the target.

~~~csharp
public static implicit operator Transform ([NotNull] KaijuPathFollowMovement t)
~~~

Implicit conversion to a transform from the target.

~~~csharp
public static implicit operator GameObject ([NotNull] KaijuPathFollowMovement t)
~~~

Implicit conversion to a GameObject from the target.

~~~csharp
public static implicit operator KaijuAgent ([NotNull] KaijuPathFollowMovement t)
~~~

Implicit conversion to a KaijuSolutions.Agents.KaijuAgent from the target.
