# KaijuAgent

Base agent class.

~~~csharp
public abstract class KaijuAgent : KaijuBehaviour
~~~

[Package source](../../Runtime/KaijuAgent.cs)

<a id="KaijuSolutions_Agents_KaijuAgent_OnMoveSpeed"></a>

### OnMoveSpeed

~~~csharp
public event KaijuAction OnMoveSpeed
~~~

Movement speed changed callback.

<a id="KaijuSolutions_Agents_KaijuAgent_OnMoveSpeedGlobal"></a>

### OnMoveSpeedGlobal

~~~csharp
public static event KaijuAgentAction OnMoveSpeedGlobal
~~~

Global movement speed changed callback.

<a id="KaijuSolutions_Agents_KaijuAgent_OnMoveAcceleration"></a>

### OnMoveAcceleration

~~~csharp
public event KaijuAction OnMoveAcceleration
~~~

Movement acceleration changed callback.

<a id="KaijuSolutions_Agents_KaijuAgent_OnMoveAccelerationGlobal"></a>

### OnMoveAccelerationGlobal

~~~csharp
public static event KaijuAgentAction OnMoveAccelerationGlobal
~~~

Global movement acceleration changed callback.

<a id="KaijuSolutions_Agents_KaijuAgent_OnLookSpeed"></a>

### OnLookSpeed

~~~csharp
public event KaijuAction OnLookSpeed
~~~

Look speed changed callback.

<a id="KaijuSolutions_Agents_KaijuAgent_OnLookSpeedGlobal"></a>

### OnLookSpeedGlobal

~~~csharp
public static event KaijuAgentAction OnLookSpeedGlobal
~~~

Global look speed changed callback.

<a id="KaijuSolutions_Agents_KaijuAgent_OnAutoRotate"></a>

### OnAutoRotate

~~~csharp
public event KaijuAction OnAutoRotate
~~~

Autorotation changed callback.

<a id="KaijuSolutions_Agents_KaijuAgent_OnAutoRotateGlobal"></a>

### OnAutoRotateGlobal

~~~csharp
public static event KaijuAgentAction OnAutoRotateGlobal
~~~

Global autorotation speed changed callback.

<a id="KaijuSolutions_Agents_KaijuAgent_OnLookTarget"></a>

### OnLookTarget

~~~csharp
public event KaijuAction OnLookTarget
~~~

Callback for when the look target has been set.

<a id="KaijuSolutions_Agents_KaijuAgent_OnLookTargetGlobal"></a>

### OnLookTargetGlobal

~~~csharp
public static event KaijuAgentAction OnLookTargetGlobal
~~~

Global callback for when the look target has been set.

<a id="KaijuSolutions_Agents_KaijuAgent_OnMove"></a>

### OnMove

~~~csharp
public event KaijuAction OnMove
~~~

Callback for when this agent has moved.

<a id="KaijuSolutions_Agents_KaijuAgent_OnMoveGlobal"></a>

### OnMoveGlobal

~~~csharp
public static event KaijuAgentAction OnMoveGlobal
~~~

Global callback for when this agent has moved.

<a id="KaijuSolutions_Agents_KaijuAgent_OnEnabled"></a>

### OnEnabled

~~~csharp
public event KaijuAction OnEnabled
~~~

Callback for when this has finishing becoming enabled.

<a id="KaijuSolutions_Agents_KaijuAgent_OnEnabledGlobal"></a>

### OnEnabledGlobal

~~~csharp
public static event KaijuAgentAction OnEnabledGlobal
~~~

Global callback for when this has finishing becoming enabled.

<a id="KaijuSolutions_Agents_KaijuAgent_OnDisabled"></a>

### OnDisabled

~~~csharp
public event KaijuAction OnDisabled
~~~

Callback for when this has finishing becoming disabled.

<a id="KaijuSolutions_Agents_KaijuAgent_OnDisabledGlobal"></a>

### OnDisabledGlobal

~~~csharp
public static event KaijuAgentAction OnDisabledGlobal
~~~

Global callback for when this has finishing becoming disabled.

<a id="KaijuSolutions_Agents_KaijuAgent_OnDestroyed"></a>

### OnDestroyed

~~~csharp
public event KaijuAction OnDestroyed
~~~

Callback for when this has finishing becoming destroyed.

<a id="KaijuSolutions_Agents_KaijuAgent_OnDestroyedGlobal"></a>

### OnDestroyedGlobal

~~~csharp
public static event KaijuAgentAction OnDestroyedGlobal
~~~

Global callback for when this has finishing becoming destroyed.

<a id="KaijuSolutions_Agents_KaijuAgent_OnMovementStarted"></a>

### OnMovementStarted

~~~csharp
public event KaijuMovementAction OnMovementStarted
~~~

Callback for when a KaijuSolutions.Agents.Movement.KaijuMovement has started.

<a id="KaijuSolutions_Agents_KaijuAgent_OnMovementStopped"></a>

### OnMovementStopped

~~~csharp
public event KaijuMovementAction OnMovementStopped
~~~

Callback for when a KaijuSolutions.Agents.Movement.KaijuMovement has stopped.

<a id="KaijuSolutions_Agents_KaijuAgent_OnMovementPerformed"></a>

### OnMovementPerformed

~~~csharp
public event KaijuMovementAction OnMovementPerformed
~~~

Callback for when a KaijuSolutions.Agents.Movement.KaijuMovement has been performed.

<a id="KaijuSolutions_Agents_KaijuAgent_OnAutomaticSense"></a>

### OnAutomaticSense

~~~csharp
public event KaijuAction OnAutomaticSense
~~~

Callback for when all automatic KaijuSolutions.Agents.Sensors.KaijuSensors have finished being executed.

<a id="KaijuSolutions_Agents_KaijuAgent_OnAutomaticSenseGlobal"></a>

### OnAutomaticSenseGlobal

~~~csharp
public static event KaijuAgentAction OnAutomaticSenseGlobal
~~~

Global callback for when all automatic KaijuSolutions.Agents.Sensors.KaijuSensors have finished being executed.

<a id="KaijuSolutions_Agents_KaijuAgent_OnSense"></a>

### OnSense

~~~csharp
public event KaijuSensorAction OnSense
~~~

Callback for when a KaijuSolutions.Agents.Sensors.KaijuSensor has been run.

<a id="KaijuSolutions_Agents_KaijuAgent_OnSensorEnabled"></a>

### OnSensorEnabled

~~~csharp
public event KaijuSensorAction OnSensorEnabled
~~~

Callback for when a KaijuSolutions.Agents.Sensors.KaijuSensor has been enabled.

<a id="KaijuSolutions_Agents_KaijuAgent_OnSensorDisabled"></a>

### OnSensorDisabled

~~~csharp
public event KaijuSensorAction OnSensorDisabled
~~~

Callback for when a KaijuSolutions.Agents.Sensors.KaijuSensor has been disabled.

<a id="KaijuSolutions_Agents_KaijuAgent_OnActuatorEnabled"></a>

### OnActuatorEnabled

~~~csharp
public event KaijuActuatorAction OnActuatorEnabled
~~~

Callback for when an KaijuSolutions.Agents.Actuators.KaijuActuator has been enabled.

<a id="KaijuSolutions_Agents_KaijuAgent_OnActuatorDisabled"></a>

### OnActuatorDisabled

~~~csharp
public event KaijuActuatorAction OnActuatorDisabled
~~~

Callback for when an KaijuSolutions.Agents.Actuators.KaijuActuator has been disabled.

<a id="KaijuSolutions_Agents_KaijuAgent_OnActuatorStarted"></a>

### OnActuatorStarted

~~~csharp
public event KaijuActuatorAction OnActuatorStarted
~~~

Callback for when an KaijuSolutions.Agents.Actuators.KaijuActuator has started to execute.

<a id="KaijuSolutions_Agents_KaijuAgent_OnActuatorExecuting"></a>

### OnActuatorExecuting

~~~csharp
public event KaijuActuatorAction OnActuatorExecuting
~~~

Callback for when an KaijuSolutions.Agents.Actuators.KaijuActuator is continuing to execute.

<a id="KaijuSolutions_Agents_KaijuAgent_OnActuatorDone"></a>

### OnActuatorDone

~~~csharp
public event KaijuActuatorAction OnActuatorDone
~~~

Callback for when an KaijuSolutions.Agents.Actuators.KaijuActuator has successfully fully completed its action.

<a id="KaijuSolutions_Agents_KaijuAgent_OnActuatorInterrupted"></a>

### OnActuatorInterrupted

~~~csharp
public event KaijuActuatorAction OnActuatorInterrupted
~~~

Callback for when an KaijuSolutions.Agents.Actuators.KaijuActuator has been interrupted during its execution, cancelling the execution.

<a id="KaijuSolutions_Agents_KaijuAgent_OnActuatorFailed"></a>

### OnActuatorFailed

~~~csharp
public event KaijuActuatorAction OnActuatorFailed
~~~

Callback for when an KaijuSolutions.Agents.Actuators.KaijuActuator has failed its execution.

<a id="KaijuSolutions_Agents_KaijuAgent_PhysicsAgent"></a>

### PhysicsAgent

~~~csharp
public virtual bool PhysicsAgent { get; }
~~~

If this agent should move with the physics system.

<a id="KaijuSolutions_Agents_KaijuAgent_MoveSpeed"></a>

### MoveSpeed

~~~csharp
public float MoveSpeed { get; set; }
~~~

The maximum move speed of the agent in units per second.

<a id="KaijuSolutions_Agents_KaijuAgent_MoveAcceleration"></a>

### MoveAcceleration

~~~csharp
public float MoveAcceleration { get; set; }
~~~

The maximum move acceleration of the agent in units per second. Setting to zero yields instant acceleration.

<a id="KaijuSolutions_Agents_KaijuAgent_LookSpeed"></a>

### LookSpeed

~~~csharp
public float LookSpeed { get; set; }
~~~

The look speed of the agent in degrees per second.

<a id="KaijuSolutions_Agents_KaijuAgent_AutoRotate"></a>

### AutoRotate

~~~csharp
public bool AutoRotate { get; set; }
~~~

If the agent should automatically rotate towards where it is moving when no look target is set.

<a id="KaijuSolutions_Agents_KaijuAgent_Sensors"></a>

### Sensors

~~~csharp
public IReadOnlyCollection<KaijuSensor> Sensors { get; }
~~~

All KaijuSolutions.Agents.Sensors.KaijuSensors attached to this agent.

<a id="KaijuSolutions_Agents_KaijuAgent_SensorsCount"></a>

### SensorsCount

~~~csharp
public int SensorsCount { get; }
~~~

The number of KaijuSolutions.Agents.Sensors.KaijuSensors attached to this agent.

<a id="KaijuSolutions_Agents_KaijuAgent_RegisterSensor"></a>

### RegisterSensor

~~~csharp
public void RegisterSensor (KaijuSensor sensor)
~~~

Register a KaijuSolutions.Agents.Sensors.KaijuSensor. There is no point in manually calling this.

<a id="KaijuSolutions_Agents_KaijuAgent_UnregisterSensor"></a>

### UnregisterSensor

~~~csharp
public void UnregisterSensor (KaijuSensor sensor)
~~~

Unregister a KaijuSolutions.Agents.Sensors.KaijuSensor. There is no point in manually calling this.

<a id="KaijuSolutions_Agents_KaijuAgent_Actuators"></a>

### Actuators

~~~csharp
public IReadOnlyCollection<KaijuActuator> Actuators { get; }
~~~

All KaijuSolutions.Agents.Actuators.KaijuActuators attached to this agent.

<a id="KaijuSolutions_Agents_KaijuAgent_ActuatorsCount"></a>

### ActuatorsCount

~~~csharp
public int ActuatorsCount { get; }
~~~

The number of KaijuSolutions.Agents.Actuators.KaijuActuators attached to this agent.

<a id="KaijuSolutions_Agents_KaijuAgent_RegisterActuator"></a>

### RegisterActuator

~~~csharp
public void RegisterActuator (KaijuActuator actuator)
~~~

Register an KaijuSolutions.Agents.Actuators.KaijuActuator. There is no point in manually calling this.

<a id="KaijuSolutions_Agents_KaijuAgent_UnregisterActuator"></a>

### UnregisterActuator

~~~csharp
public void UnregisterActuator (KaijuActuator actuator)
~~~

Unregister an KaijuSolutions.Agents.Actuators.KaijuActuator. There is no point in manually calling this.

<a id="KaijuSolutions_Agents_KaijuAgent_Identifiers"></a>

### Identifiers

~~~csharp
public IReadOnlyList<uint> Identifiers { get; }
~~~

Identifiers for this agent.

<a id="KaijuSolutions_Agents_KaijuAgent_configuration"></a>

### configuration

~~~csharp
public KaijuMovementConfiguration configuration
~~~

The default movement values for this agent.

<a id="KaijuSolutions_Agents_KaijuAgent_globalControl"></a>

### globalControl

~~~csharp
public bool globalControl
~~~

Whether the manual Control is in the direction the agent is facing, or based on global coordinates.

<a id="KaijuSolutions_Agents_KaijuAgent_Control"></a>

### Control

~~~csharp
public Vector2 Control { get; set; }
~~~

The manual control vector for the agent's movement, with steering values ranging from negative one to positive one on each axis. This is multiplied by the MoveSpeed.

<a id="KaijuSolutions_Agents_KaijuAgent_Control3"></a>

### Control3

~~~csharp
public Vector3 Control3 { get; set; }
~~~

The manual control vector for the agent's movement, with steering values ranging from negative one to positive one on each axis. This is multiplied by the MoveSpeed.

<a id="KaijuSolutions_Agents_KaijuAgent_Velocity"></a>

### Velocity

~~~csharp
public Vector2 Velocity { get; private set; }
~~~

The current velocity of the agent.

<a id="KaijuSolutions_Agents_KaijuAgent_Velocity3"></a>

### Velocity3

~~~csharp
public Vector3 Velocity3 { get; }
~~~

The current velocity of the agent.

<a id="KaijuSolutions_Agents_KaijuAgent_RelativeVelocity"></a>

### RelativeVelocity

~~~csharp
public Vector2 RelativeVelocity { get; }
~~~

The current velocity of the agent relative to the direction we are facing.

<a id="KaijuSolutions_Agents_KaijuAgent_RelativeVelocity3"></a>

### RelativeVelocity3

~~~csharp
public Vector3 RelativeVelocity3 { get; }
~~~

The current velocity of the agent relative to the direction we are facing.

<a id="KaijuSolutions_Agents_KaijuAgent_MoveForward"></a>

### MoveForward

~~~csharp
public Vector2 MoveForward { get; }
~~~

Get the forward direction of this agent along the X and Z axes based on how its moving. If moving, this is the direction of its velocity. Otherwise, it is the same as KaijuSolutions.Agents.KaijuBehaviour.Forward3.

<a id="KaijuSolutions_Agents_KaijuAgent_MoveForward3"></a>

### MoveForward3

~~~csharp
public Vector3 MoveForward3 { get; }
~~~

Get the forward direction of this agent based on how its moving. If moving, this is the direction of its velocity. Otherwise, it is the same as KaijuSolutions.Agents.KaijuBehaviour.Forward3.

<a id="KaijuSolutions_Agents_KaijuAgent_Movements"></a>

### Movements

~~~csharp
public IReadOnlyList<KaijuMovement> Movements { get; }
~~~

All movements the agent is currently performing.

<a id="KaijuSolutions_Agents_KaijuAgent_MovementsCount"></a>

### MovementsCount

~~~csharp
public int MovementsCount { get; }
~~~

The total number movements the agent is currently performing.

<a id="KaijuSolutions_Agents_KaijuAgent_Moving"></a>

### Moving

~~~csharp
public bool Moving { get; }
~~~

If there are any movements occuring.

<a id="KaijuSolutions_Agents_KaijuAgent_Spin"></a>

### Spin

~~~csharp
public float? Spin { get; set; }
~~~

The manual spin control, ranging from negative one to positive one. Negative values mean a left spin and positive values mean a right spin, multiplied by the LookSpeed.

<a id="KaijuSolutions_Agents_KaijuAgent_LookAngle"></a>

### LookAngle

~~~csharp
public float? LookAngle { get; set; }
~~~

The angle to look at relative to the global forward direction.

<a id="KaijuSolutions_Agents_KaijuAgent_LookVector"></a>

### LookVector

~~~csharp
public Vector2? LookVector { get; set; }
~~~

The vector to look at.

<a id="KaijuSolutions_Agents_KaijuAgent_LookVector3"></a>

### LookVector3

~~~csharp
public Vector3? LookVector3 { get; set; }
~~~

The vector to look at.

<a id="KaijuSolutions_Agents_KaijuAgent_LookTransform"></a>

### LookTransform

~~~csharp
public Transform LookTransform { get; set; }
~~~

The transform to look at.

<a id="KaijuSolutions_Agents_KaijuAgent_LookGameObject"></a>

### LookGameObject

~~~csharp
public GameObject LookGameObject { get; set; }
~~~

The GameObject to look at.

<a id="KaijuSolutions_Agents_KaijuAgent_LookComponent"></a>

### LookComponent

~~~csharp
public Component LookComponent { set; }
~~~

The component to look at.

<a id="KaijuSolutions_Agents_KaijuAgent_TargetAgent"></a>

### TargetAgent

~~~csharp
public KaijuAgent TargetAgent { get; set; }
~~~

The agent to move in relation to.

<a id="KaijuSolutions_Agents_KaijuAgent_TargetComponent"></a>

### TargetComponent

~~~csharp
public Component TargetComponent { set; }
~~~

The component to look at.

<a id="KaijuSolutions_Agents_KaijuAgent_Looking"></a>

### Looking

~~~csharp
public bool Looking { get; }
~~~

If the agent is currently looking at something.

<a id="KaijuSolutions_Agents_KaijuAgent_LookDistance"></a>

### LookDistance

~~~csharp
public float LookDistance { get; }
~~~

Get the distance from the agent to the target which is being looked at.

<a id="KaijuSolutions_Agents_KaijuAgent_MovementWeights"></a>

### MovementWeights

~~~csharp
public float MovementWeights { get; }
~~~

The total weight of all movements.

<a id="KaijuSolutions_Agents_KaijuAgent_GetRadius"></a>

### GetRadius

~~~csharp
public abstract float GetRadius ()
~~~

Get the radius of an agent.

<a id="KaijuSolutions_Agents_KaijuAgent_Setup"></a>

### Setup

~~~csharp
public virtual void Setup ()
~~~

Initialize the agent. There is no point in manually calling this.

<a id="KaijuSolutions_Agents_KaijuAgent_CalculateVelocity"></a>

### CalculateVelocity

~~~csharp
public void CalculateVelocity (float delta)
~~~

Calculate the velocity for the next update. There is no point in manually calling this. The time step.

<a id="KaijuSolutions_Agents_KaijuAgent_SimulationEntity"></a>

### SimulationEntity

~~~csharp
public Entity SimulationEntity { get; private set; }
~~~

The simulation entity while this agent is registered in the default world.

<a id="KaijuSolutions_Agents_KaijuAgent_FreeFlight"></a>

### FreeFlight

~~~csharp
public KaijuFreeFlight FreeFlight { get; private set; }
~~~

<a id="KaijuSolutions_Agents_KaijuAgent_OnEnable"></a>

### OnEnable

~~~csharp
protected virtual void OnEnable ()
~~~

This function is called when the object becomes enabled and active.

<a id="KaijuSolutions_Agents_KaijuAgent_OnDisable"></a>

### OnDisable

~~~csharp
protected virtual void OnDisable ()
~~~

This function is called when the behaviour becomes disabled.

<a id="KaijuSolutions_Agents_KaijuAgent_Spawn"></a>

### Spawn

~~~csharp
public void Spawn ()
~~~

Spawn this agent if it is not currently spawned. There is no point in manually calling this.

<a id="KaijuSolutions_Agents_KaijuAgent_Despawn"></a>

### Despawn

~~~csharp
public void Despawn ()
~~~

Despawn this agent.

<a id="KaijuSolutions_Agents_KaijuAgent_ClearIdentifiers"></a>

### ClearIdentifiers

~~~csharp
public void ClearIdentifiers ()
~~~

Clear all identifiers.

<a id="KaijuSolutions_Agents_KaijuAgent_HasIdentifier"></a>

### HasIdentifier

~~~csharp
public bool HasIdentifier (uint identifier)
~~~

If this agent has an identifier.

<a id="KaijuSolutions_Agents_KaijuAgent_HasAnyIdentifier"></a>

### HasAnyIdentifier

~~~csharp
public bool HasAnyIdentifier (IEnumerable<uint> collection)
~~~

If this agent has any one of a set of identifiers.

<a id="KaijuSolutions_Agents_KaijuAgent_AddIdentifier"></a>

### AddIdentifier

~~~csharp
public bool AddIdentifier (uint identifier)
~~~

Add an identifier to this agent.

<a id="KaijuSolutions_Agents_KaijuAgent_AddIdentifiers"></a>

### AddIdentifiers

~~~csharp
public bool AddIdentifiers (IEnumerable<uint> collection)
~~~

Add identifiers to this agent.

<a id="KaijuSolutions_Agents_KaijuAgent_RemoveIdentifier"></a>

### RemoveIdentifier

~~~csharp
public bool RemoveIdentifier (uint identifier)
~~~

Remove an identifier from this agent.

<a id="KaijuSolutions_Agents_KaijuAgent_RemoveIdentifiers"></a>

### RemoveIdentifiers

~~~csharp
public bool RemoveIdentifiers (IEnumerable<uint> collection)
~~~

Remove identifiers from this agent.

<a id="KaijuSolutions_Agents_KaijuAgent_SetIdentifier"></a>

### SetIdentifier

~~~csharp
public void SetIdentifier (uint identifier)
~~~

Set an identifier to this agent.

<a id="KaijuSolutions_Agents_KaijuAgent_SetIdentifiers"></a>

### SetIdentifiers

~~~csharp
public void SetIdentifiers (IEnumerable<uint> collection)
~~~

If this agent has any one of a set of identifiers.

<a id="KaijuSolutions_Agents_KaijuAgent_Stop"></a>

### Stop

~~~csharp
public void Stop ()
~~~

Stop all movement, including manual steering.

~~~csharp
public bool Stop (KaijuMovement movement)
~~~

Stop a movement of this agent.

~~~csharp
public bool Stop <T> () where T : KaijuMovement
~~~

Stop all instances of a movement type. This checks for exact matches, not inherited classes.

~~~csharp
public bool Stop (int index)
~~~

Stop a movement by the given index.

~~~csharp
public int Stop (Vector2 v)
~~~

Stop existing target movements in relation to a vector.

~~~csharp
public int Stop (Vector3 v)
~~~

Stop existing target movements in relation to a vector.

~~~csharp
public int Stop ([NotNull] GameObject go)
~~~

Stop existing target movements in relation to a GameObject.

~~~csharp
public int Stop ([NotNull] Component c)
~~~

Stop an existing target movement in relation to a component.

<a id="KaijuSolutions_Agents_KaijuAgent_StopLooking"></a>

### StopLooking

~~~csharp
public void StopLooking ()
~~~

Stop explicitly looking at a target.

<a id="KaijuSolutions_Agents_KaijuAgent_Seek"></a>

### Seek

~~~csharp
public KaijuSeekMovement Seek (Vector2 target, float? distance = null, float? weight = null, bool? clear = null)
~~~

Seek to a target.

~~~csharp
public KaijuSeekMovement Seek (Vector3 target, float? distance = null, float? weight = null, bool? clear = null)
~~~

Seek to a target.

~~~csharp
public KaijuSeekMovement Seek ([NotNull] GameObject target, float? distance = null, float? weight = null, bool? clear = null)
~~~

Seek to a target.

~~~csharp
public KaijuSeekMovement Seek ([NotNull] Component target, float? distance = null, float? weight = null, bool? clear = null)
~~~

Seek to a target.

<a id="KaijuSolutions_Agents_KaijuAgent_Pursue"></a>

### Pursue

~~~csharp
public KaijuPursueMovement Pursue (Vector2 target, float? distance = null, float? weight = null, bool? clear = null)
~~~

Pursue to a target.

~~~csharp
public KaijuPursueMovement Pursue (Vector3 target, float? distance = null, float? weight = null, bool? clear = null)
~~~

Pursue to a target.

~~~csharp
public KaijuPursueMovement Pursue ([NotNull] GameObject target, float? distance = null, float? weight = null, bool? clear = null)
~~~

Pursue to a target.

~~~csharp
public KaijuPursueMovement Pursue ([NotNull] Component target, float? distance = null, float? weight = null, bool? clear = null)
~~~

Pursue to a target.

<a id="KaijuSolutions_Agents_KaijuAgent_Flee"></a>

### Flee

~~~csharp
public KaijuFleeMovement Flee (Vector2 target, float? distance = null, float? weight = null, bool? clear = null)
~~~

Flee from a target.

~~~csharp
public KaijuFleeMovement Flee (Vector3 target, float? distance = null, float? weight = null, bool? clear = null)
~~~

Flee from a target.

~~~csharp
public KaijuFleeMovement Flee ([NotNull] GameObject target, float? distance = null, float? weight = null, bool? clear = null)
~~~

Flee from a target.

~~~csharp
public KaijuFleeMovement Flee ([NotNull] Component target, float? distance = null, float? weight = null, bool? clear = null)
~~~

Flee from a target.

<a id="KaijuSolutions_Agents_KaijuAgent_Evade"></a>

### Evade

~~~csharp
public KaijuEvadeMovement Evade (Vector2 target, float? distance = null, float? weight = null, bool? clear = null)
~~~

Evade from a target.

~~~csharp
public KaijuEvadeMovement Evade (Vector3 target, float? distance = null, float? weight = null, bool? clear = null)
~~~

Evade from a target.

~~~csharp
public KaijuEvadeMovement Evade ([NotNull] GameObject target, float? distance = null, float? weight = null, bool? clear = null)
~~~

Evade from a target.

~~~csharp
public KaijuEvadeMovement Evade ([NotNull] Component target, float? distance = null, float? weight = null, bool? clear = null)
~~~

Evade from a target.

<a id="KaijuSolutions_Agents_KaijuAgent_Wander"></a>

### Wander

~~~csharp
public KaijuWanderMovement Wander (float? distance = null, float? radius = null, float? weight = null, bool? clear = null)
~~~

Wander.

<a id="KaijuSolutions_Agents_KaijuAgent_Separation"></a>

### Separation

~~~csharp
public KaijuSeparationMovement Separation (float? distance = null, float? coefficient = null, ICollection<uint> collection = null, float? weight = null, bool? clear = null)
~~~

Separate from other agents.

<a id="KaijuSolutions_Agents_KaijuAgent_ObstacleAvoidance"></a>

### ObstacleAvoidance

~~~csharp
public KaijuObstacleAvoidanceMovement ObstacleAvoidance (float? avoidance = null, float? distance = null, float? sideDistance = null, float? angle = null, float? height = null, float? horizontal = null, float? weight = null, bool? clear = null)
~~~

Avoid obstacles.

<a id="KaijuSolutions_Agents_KaijuAgent_PathFollow"></a>

### PathFollow

~~~csharp
public KaijuPathFollowMovement PathFollow (Vector2 target, int areaMask = NavMesh.AllAreas, float? distance = null, float? autoCalculateDistance = 1, int collisionMask = KaijuMovementConfiguration.DefaultMask, QueryTriggerInteraction triggers = QueryTriggerInteraction.UseGlobal, float? weight = null, bool? clear = null)
~~~

Path following.

~~~csharp
public KaijuPathFollowMovement PathFollow (Vector3 target, int areaMask = NavMesh.AllAreas, float? distance = null, float? autoCalculateDistance = 1, int collisionMask = KaijuMovementConfiguration.DefaultMask, QueryTriggerInteraction triggers = QueryTriggerInteraction.UseGlobal, float? weight = null, bool? clear = null)
~~~

Path following.

~~~csharp
public KaijuPathFollowMovement PathFollow (Component target, int areaMask = NavMesh.AllAreas, float? distance = null, float? autoCalculateDistance = 1, int collisionMask = KaijuMovementConfiguration.DefaultMask, QueryTriggerInteraction triggers = QueryTriggerInteraction.UseGlobal, float? weight = null, bool? clear = null)
~~~

Path following.

~~~csharp
public KaijuPathFollowMovement PathFollow (GameObject target, int areaMask = NavMesh.AllAreas, float? distance = null, float? autoCalculateDistance = 1, int collisionMask = KaijuMovementConfiguration.DefaultMask, QueryTriggerInteraction triggers = QueryTriggerInteraction.UseGlobal, float? weight = null, bool? clear = null)
~~~

Path following.

~~~csharp
public KaijuPathFollowMovement PathFollow (Vector2 target, NavMeshQueryFilter filter, float? distance = null, float? autoCalculateDistance = 1, int collisionMask = KaijuMovementConfiguration.DefaultMask, QueryTriggerInteraction triggers = QueryTriggerInteraction.UseGlobal, float? weight = null, bool? clear = null)
~~~

Path following.

~~~csharp
public KaijuPathFollowMovement PathFollow (Vector3 target, NavMeshQueryFilter filter, float? distance = null, float? autoCalculateDistance = 1, int collisionMask = KaijuMovementConfiguration.DefaultMask, QueryTriggerInteraction triggers = QueryTriggerInteraction.UseGlobal, float? weight = null, bool? clear = null)
~~~

Path following.

~~~csharp
public KaijuPathFollowMovement PathFollow (Component target, NavMeshQueryFilter filter, float? distance = null, float? autoCalculateDistance = 1, int collisionMask = KaijuMovementConfiguration.DefaultMask, QueryTriggerInteraction triggers = QueryTriggerInteraction.UseGlobal, float? weight = null, bool? clear = null)
~~~

Path following.

~~~csharp
public KaijuPathFollowMovement PathFollow (GameObject target, NavMeshQueryFilter filter, float? distance = null, float? autoCalculateDistance = 1, int collisionMask = KaijuMovementConfiguration.DefaultMask, QueryTriggerInteraction triggers = QueryTriggerInteraction.UseGlobal, float? weight = null, bool? clear = null)
~~~

Path following.

<a id="KaijuSolutions_Agents_KaijuAgent_OnValidate"></a>

### OnValidate

~~~csharp
protected virtual void OnValidate ()
~~~

Editor-only function that Unity calls when the script is loaded or a value changes in the Inspector.

<a id="KaijuSolutions_Agents_KaijuAgent_EditorVisualize"></a>

### EditorVisualize

~~~csharp
public void EditorVisualize (bool text)
~~~

Visualize this agent in the editor. There is no point in manually calling this.

<a id="KaijuSolutions_Agents_KaijuAgent_Move"></a>

### Move

~~~csharp
public abstract void Move (float delta)
~~~

Perform agent movement. There is no point in manually calling this.

<a id="KaijuSolutions_Agents_KaijuAgent_GetSensor"></a>

### GetSensor

~~~csharp
public T GetSensor <T> (ISet<T> ignore = null, bool automatic = true) where T : KaijuSensor
~~~

Get a KaijuSolutions.Agents.Sensors.KaijuSensor of a given type.

<a id="KaijuSolutions_Agents_KaijuAgent_GetSensors"></a>

### GetSensors

~~~csharp
public HashSet<T> GetSensors <T> (bool automatic = true) where T : KaijuSensor
~~~

Get all KaijuSolutions.Agents.Sensors.KaijuSensor of a given type.

~~~csharp
public int GetSensors <T> ([NotNull] ISet<T> sensors, bool automatic = true) where T : KaijuSensor
~~~

Get all KaijuSolutions.Agents.Sensors.KaijuSensor of a given type.

<a id="KaijuSolutions_Agents_KaijuAgent_GetActuator"></a>

### GetActuator

~~~csharp
public T GetActuator <T> (ISet<T> ignore = null) where T : KaijuActuator
~~~

Get a KaijuSolutions.Agents.Actuators.KaijuActuator of a given type.

<a id="KaijuSolutions_Agents_KaijuAgent_GetActuators"></a>

### GetActuators

~~~csharp
public HashSet<T> GetActuators <T> () where T : KaijuActuator
~~~

Get all KaijuSolutions.Agents.Actuators.KaijuActuator of a given type.

~~~csharp
public int GetActuators <T> ([NotNull] ISet<T> actuators) where T : KaijuActuator
~~~

Get all KaijuSolutions.Agents.Actuators.KaijuActuator of a given type.

<a id="KaijuSolutions_Agents_KaijuAgent_Sense"></a>

### Sense

~~~csharp
public int Sense <T> (ICollection<T> sensors = null, bool automatic = false) where T : KaijuSensor
~~~

Manually run all KaijuSolutions.Agents.Sensors.KaijuSensors of a type attached to this agent.

<a id="KaijuSolutions_Agents_KaijuAgent_SenseAutomatic"></a>

### SenseAutomatic

~~~csharp
public void SenseAutomatic ()
~~~

Execute all automatically-running KaijuSolutions.Agents.Sensors.KaijuSensors. There is no point in manually calling this.

<a id="KaijuSolutions_Agents_KaijuAgent_SensorRun"></a>

### SensorRun

~~~csharp
public void SensorRun ([NotNull] KaijuSensor sensor)
~~~

Called by a KaijuSolutions.Agents.Sensors.KaijuSensor when it has been run. There is no point in manually calling this.

<a id="KaijuSolutions_Agents_KaijuAgent_Act"></a>

### Act

~~~csharp
public void Act ()
~~~

Execute all KaijuSolutions.Agents.Actuators.KaijuActuators. There is no point in manually calling this.

<a id="KaijuSolutions_Agents_KaijuAgent_ActuatorStarted"></a>

### ActuatorStarted

~~~csharp
public void ActuatorStarted (KaijuActuator actuator)
~~~

Allow for KaijuSolutions.Agents.Actuators.KaijuActuators to trigger that they have started. There is no point in manually calling this.

<a id="KaijuSolutions_Agents_KaijuAgent_ActuatorExecuting"></a>

### ActuatorExecuting

~~~csharp
public void ActuatorExecuting (KaijuActuator actuator)
~~~

Allow for KaijuSolutions.Agents.Actuators.KaijuActuators to trigger that they are executing. There is no point in manually calling this.

<a id="KaijuSolutions_Agents_KaijuAgent_ActuatorDone"></a>

### ActuatorDone

~~~csharp
public void ActuatorDone (KaijuActuator actuator)
~~~

Allow for KaijuSolutions.Agents.Actuators.KaijuActuators to trigger that they are done. There is no point in manually calling this.

<a id="KaijuSolutions_Agents_KaijuAgent_ActuatorInterrupted"></a>

### ActuatorInterrupted

~~~csharp
public void ActuatorInterrupted (KaijuActuator actuator)
~~~

Allow for KaijuSolutions.Agents.Actuators.KaijuActuators to trigger that they were interrupted. There is no point in manually calling this.

<a id="KaijuSolutions_Agents_KaijuAgent_ActuatorFailed"></a>

### ActuatorFailed

~~~csharp
public void ActuatorFailed (KaijuActuator actuator)
~~~

Allow for KaijuSolutions.Agents.Actuators.KaijuActuators to trigger that they failed. There is no point in manually calling this.

<a id="KaijuSolutions_Agents_KaijuAgent_Look"></a>

### Look

~~~csharp
public void Look (float delta)
~~~

Handle look actions. There is no point in manually calling this.

<a id="KaijuSolutions_Agents_KaijuAgent_ToString"></a>

### ToString

~~~csharp
public override string ToString ()
~~~

Get a description of the object.

~~~csharp
public static implicit operator KaijuAgent ([NotNull] GameObject o)
~~~

Implicit conversion from a GameObject.

~~~csharp
public static implicit operator KaijuAgent ([NotNull] Transform t)
~~~

Implicit conversion from a transform.

~~~csharp
public static implicit operator KaijuController ([NotNull] KaijuAgent a)
~~~

Implicit conversion to a KaijuSolutions.Agents.KaijuController.

~~~csharp
public static implicit operator KaijuGlobalController ([NotNull] KaijuAgent a)
~~~

Implicit conversion to a KaijuSolutions.Agents.KaijuGlobalController.

~~~csharp
public static implicit operator short ([NotNull] KaijuAgent a)
~~~

Implicit conversion to a short integer based on the number of Movements.

~~~csharp
public static implicit operator short? ([NotNull] KaijuAgent a)
~~~

Implicit conversion to a nullable short integer based on the number of Movements.

~~~csharp
public static implicit operator ushort ([NotNull] KaijuAgent a)
~~~

Implicit conversion to an unsigned short integer based on the number of Movements.

~~~csharp
public static implicit operator ushort? ([NotNull] KaijuAgent a)
~~~

Implicit conversion to a nullable unsigned short integer based on the number of Movements.

~~~csharp
public static implicit operator int ([NotNull] KaijuAgent a)
~~~

Implicit conversion to an integer based on the number of Movements.

~~~csharp
public static implicit operator int? ([NotNull] KaijuAgent a)
~~~

Implicit conversion to a nullable integer based on the number of Movements.

~~~csharp
public static implicit operator uint ([NotNull] KaijuAgent a)
~~~

Implicit conversion to an unsigned integer based on the number of Movements.

~~~csharp
public static implicit operator uint? ([NotNull] KaijuAgent a)
~~~

Implicit conversion to a nullable unsigned integer based on the number of Movements.

~~~csharp
public static implicit operator long ([NotNull] KaijuAgent a)
~~~

Implicit conversion to a long integer based on the number of Movements.

~~~csharp
public static implicit operator long? ([NotNull] KaijuAgent a)
~~~

Implicit conversion to a nullable long integer based on the number of Movements.

~~~csharp
public static implicit operator ulong ([NotNull] KaijuAgent a)
~~~

Implicit conversion to an unsigned long integer based on the number of Movements.

~~~csharp
public static implicit operator ulong? ([NotNull] KaijuAgent a)
~~~

Implicit conversion to a nullable unsigned long integer based on the number of Movements.
