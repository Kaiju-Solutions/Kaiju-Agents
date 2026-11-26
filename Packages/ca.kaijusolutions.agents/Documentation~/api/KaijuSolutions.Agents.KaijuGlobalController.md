# KaijuGlobalController

Base class to inherit for easy interaction with all KaijuSolutions.Agents.KaijuAgents in the scene. Simply override the methods you need to use callbacks without needing to worry about binding. If you override either OnEnable or OnDisable, you must call their respective base methods for binding and cleanup.

~~~csharp
public abstract class KaijuGlobalController : KaijuBehaviour
~~~

[Package source](../../Runtime/KaijuGlobalController.cs)

<a id="KaijuSolutions_Agents_KaijuGlobalController_OnEnable"></a>

### OnEnable

~~~csharp
protected virtual void OnEnable ()
~~~

This function is called when the object becomes enabled and active.

<a id="KaijuSolutions_Agents_KaijuGlobalController_OnDisable"></a>

### OnDisable

~~~csharp
protected virtual void OnDisable ()
~~~

This function is called when the behaviour becomes disabled.

<a id="KaijuSolutions_Agents_KaijuGlobalController_OnAllPreSetPosition"></a>

### OnAllPreSetPosition

~~~csharp
protected virtual void OnAllPreSetPosition ([NotNull] KaijuBehaviour behaviour)
~~~

Global callback for before a KaijuSolutions.Agents.KaijuBehaviour's position has been set.

<a id="KaijuSolutions_Agents_KaijuGlobalController_OnAllSetPosition"></a>

### OnAllSetPosition

~~~csharp
protected virtual void OnAllSetPosition ([NotNull] KaijuBehaviour behaviour)
~~~

Global callback for when the KaijuSolutions.Agents.KaijuBehaviour's position has been set.

<a id="KaijuSolutions_Agents_KaijuGlobalController_OnAllPreSetOrientation"></a>

### OnAllPreSetOrientation

~~~csharp
protected virtual void OnAllPreSetOrientation ([NotNull] KaijuBehaviour behaviour)
~~~

Global callback for before the KaijuSolutions.Agents.KaijuBehaviour's orientation has been set.

<a id="KaijuSolutions_Agents_KaijuGlobalController_OnAllSetOrientation"></a>

### OnAllSetOrientation

~~~csharp
protected virtual void OnAllSetOrientation ([NotNull] KaijuBehaviour behaviour)
~~~

Global callback for when the KaijuSolutions.Agents.KaijuBehaviour's orientation has been set.

<a id="KaijuSolutions_Agents_KaijuGlobalController_OnAllPreSetScale"></a>

### OnAllPreSetScale

~~~csharp
protected virtual void OnAllPreSetScale ([NotNull] KaijuBehaviour behaviour)
~~~

Global callback for before the KaijuSolutions.Agents.KaijuBehaviour's scale has been set.

<a id="KaijuSolutions_Agents_KaijuGlobalController_OnAllSetScale"></a>

### OnAllSetScale

~~~csharp
protected virtual void OnAllSetScale ([NotNull] KaijuBehaviour behaviour)
~~~

Global callback for when the KaijuSolutions.Agents.KaijuBehaviour's scale has been set.

<a id="KaijuSolutions_Agents_KaijuGlobalController_OnAgentMoveSpeed"></a>

### OnAgentMoveSpeed

~~~csharp
protected virtual void OnAgentMoveSpeed (KaijuAgent agent)
~~~

Global movement speed changed callback for an KaijuSolutions.Agents.KaijuAgent

<a id="KaijuSolutions_Agents_KaijuGlobalController_OnAgentMoveAcceleration"></a>

### OnAgentMoveAcceleration

~~~csharp
protected virtual void OnAgentMoveAcceleration (KaijuAgent agent)
~~~

Global movement acceleration changed callback for an KaijuSolutions.Agents.KaijuAgent

<a id="KaijuSolutions_Agents_KaijuGlobalController_OnAgentLookSpeed"></a>

### OnAgentLookSpeed

~~~csharp
protected virtual void OnAgentLookSpeed (KaijuAgent agent)
~~~

Global look speed changed callback for an KaijuSolutions.Agents.KaijuAgent

<a id="KaijuSolutions_Agents_KaijuGlobalController_OnAgentAutoRotate"></a>

### OnAgentAutoRotate

~~~csharp
protected virtual void OnAgentAutoRotate (KaijuAgent agent)
~~~

Global autorotation changed callback for an KaijuSolutions.Agents.KaijuAgent

<a id="KaijuSolutions_Agents_KaijuGlobalController_OnAgentLookTarget"></a>

### OnAgentLookTarget

~~~csharp
protected virtual void OnAgentLookTarget (KaijuAgent agent)
~~~

Global callback for when the look target has been set for an KaijuSolutions.Agents.KaijuAgent.

<a id="KaijuSolutions_Agents_KaijuGlobalController_OnAgentMove"></a>

### OnAgentMove

~~~csharp
protected virtual void OnAgentMove (KaijuAgent agent)
~~~

Global callback for when an KaijuSolutions.Agents.KaijuAgent has moved.

<a id="KaijuSolutions_Agents_KaijuGlobalController_OnAgentEnabled"></a>

### OnAgentEnabled

~~~csharp
protected virtual void OnAgentEnabled (KaijuAgent agent)
~~~

Global callback for when the a KaijuSolutions.Agents.KaijuAgent has finishing becoming enabled.

<a id="KaijuSolutions_Agents_KaijuGlobalController_OnAgentDisabled"></a>

### OnAgentDisabled

~~~csharp
protected virtual void OnAgentDisabled (KaijuAgent agent)
~~~

Global callback for when a KaijuSolutions.Agents.KaijuAgent has finishing becoming disabled.

<a id="KaijuSolutions_Agents_KaijuGlobalController_OnAgentDestroyed"></a>

### OnAgentDestroyed

~~~csharp
protected virtual void OnAgentDestroyed (KaijuAgent agent)
~~~

Global callback for when a KaijuSolutions.Agents.KaijuAgent has finishing becoming destroyed.

<a id="KaijuSolutions_Agents_KaijuGlobalController_OnAgentAutomaticSense"></a>

### OnAgentAutomaticSense

~~~csharp
protected virtual void OnAgentAutomaticSense (KaijuAgent agent)
~~~

Global callback for when all automatic KaijuSolutions.Agents.Sensors.KaijuSensors have finished being executed for a KaijuSolutions.Agents.KaijuAgent.

<a id="KaijuSolutions_Agents_KaijuGlobalController_OnMovementStarted"></a>

### OnMovementStarted

~~~csharp
protected virtual void OnMovementStarted ([NotNull] KaijuMovement movement)
~~~

Global callback for a KaijuSolutions.Agents.Movement.KaijuMovement starting.

<a id="KaijuSolutions_Agents_KaijuGlobalController_OnMovementStopped"></a>

### OnMovementStopped

~~~csharp
protected virtual void OnMovementStopped ([NotNull] KaijuMovement movement)
~~~

Global callback for a KaijuSolutions.Agents.Movement.KaijuMovement stopping.

<a id="KaijuSolutions_Agents_KaijuGlobalController_OnMovementPerformed"></a>

### OnMovementPerformed

~~~csharp
protected virtual void OnMovementPerformed ([NotNull] KaijuMovement movement)
~~~

Global callback for a KaijuSolutions.Agents.Movement.KaijuMovement being performed.

<a id="KaijuSolutions_Agents_KaijuGlobalController_OnSensorSense"></a>

### OnSensorSense

~~~csharp
protected virtual void OnSensorSense ([NotNull] KaijuSensor sensor)
~~~

Global callback for when a KaijuSolutions.Agents.Sensors.KaijuSensor has been run.

<a id="KaijuSolutions_Agents_KaijuGlobalController_OnSensorEnabled"></a>

### OnSensorEnabled

~~~csharp
protected virtual void OnSensorEnabled ([NotNull] KaijuSensor sensor)
~~~

Global callback for when a KaijuSolutions.Agents.Sensors.KaijuSensor has been enabled.

<a id="KaijuSolutions_Agents_KaijuGlobalController_OnSensorDisabled"></a>

### OnSensorDisabled

~~~csharp
protected virtual void OnSensorDisabled ([NotNull] KaijuSensor sensor)
~~~

Global callback for when a KaijuSolutions.Agents.Sensors.KaijuSensor has been disabled.

<a id="KaijuSolutions_Agents_KaijuGlobalController_OnActuatorStarted"></a>

### OnActuatorStarted

~~~csharp
protected virtual void OnActuatorStarted ([NotNull] KaijuActuator actuator)
~~~

Global callback for when a KaijuSolutions.Agents.Actuators.KaijuActuator has started to execute.

<a id="KaijuSolutions_Agents_KaijuGlobalController_OnActuatorExecuting"></a>

### OnActuatorExecuting

~~~csharp
protected virtual void OnActuatorExecuting ([NotNull] KaijuActuator actuator)
~~~

Global callback for when a KaijuSolutions.Agents.Actuators.KaijuActuator is continuing to execute.

<a id="KaijuSolutions_Agents_KaijuGlobalController_OnActuatorDone"></a>

### OnActuatorDone

~~~csharp
protected virtual void OnActuatorDone ([NotNull] KaijuActuator actuator)
~~~

Global callback for when a KaijuSolutions.Agents.Actuators.KaijuActuator has successfully fully completed its action.

<a id="KaijuSolutions_Agents_KaijuGlobalController_OnActuatorInterrupted"></a>

### OnActuatorInterrupted

~~~csharp
protected virtual void OnActuatorInterrupted ([NotNull] KaijuActuator actuator)
~~~

Global callback for when a KaijuSolutions.Agents.Actuators.KaijuActuator has been interrupted during its execution, cancelling the execution.

<a id="KaijuSolutions_Agents_KaijuGlobalController_OnActuatorFailed"></a>

### OnActuatorFailed

~~~csharp
protected virtual void OnActuatorFailed ([NotNull] KaijuActuator actuator)
~~~

Global callback for when a KaijuSolutions.Agents.Actuators.KaijuActuator has failed its execution.

<a id="KaijuSolutions_Agents_KaijuGlobalController_OnActuatorEnabled"></a>

### OnActuatorEnabled

~~~csharp
protected virtual void OnActuatorEnabled ([NotNull] KaijuActuator actuator)
~~~

Global callback for when a KaijuSolutions.Agents.Actuators.KaijuActuator has finishing becoming enabled.

<a id="KaijuSolutions_Agents_KaijuGlobalController_OnActuatorDisabled"></a>

### OnActuatorDisabled

~~~csharp
protected virtual void OnActuatorDisabled ([NotNull] KaijuActuator actuator)
~~~

Global callback for when a KaijuSolutions.Agents.Actuators.KaijuActuator has finishing becoming disabled.

<a id="KaijuSolutions_Agents_KaijuGlobalController_ToString"></a>

### ToString

~~~csharp
public override string ToString ()
~~~

Get a description of the object.

~~~csharp
public static implicit operator KaijuGlobalController ([NotNull] GameObject o)
~~~

Implicit conversion from a GameObject.

~~~csharp
public static implicit operator KaijuGlobalController ([NotNull] Transform t)
~~~

Implicit conversion from a transform.

~~~csharp
public static implicit operator KaijuGlobalController ([NotNull] KaijuAgent a)
~~~

Implicit conversion from a KaijuSolutions.Agents.KaijuAgent.

~~~csharp
public static implicit operator KaijuAgent ([NotNull] KaijuGlobalController c)
~~~

Implicit conversion to a KaijuSolutions.Agents.KaijuAgent.
