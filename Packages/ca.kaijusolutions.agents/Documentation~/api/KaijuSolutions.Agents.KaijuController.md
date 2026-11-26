# KaijuController

Base class to inherit for easy interaction with a KaijuSolutions.Agents.KaijuAgent. Simply override the methods you need to use callbacks without needing to worry about binding. If you override either OnEnable or OnDisable, you must call their respective base methods for binding and cleanup.

~~~csharp
public abstract class KaijuController : KaijuBehaviour
~~~

[Package source](../../Runtime/KaijuController.cs)

<a id="KaijuSolutions_Agents_KaijuController_Agent"></a>

### Agent

~~~csharp
public KaijuAgent Agent { get; }
~~~

The KaijuSolutions.Agents.KaijuAgent this is listening to.

<a id="KaijuSolutions_Agents_KaijuController_OnValidate"></a>

### OnValidate

~~~csharp
protected virtual void OnValidate ()
~~~

Editor-only function that Unity calls when the script is loaded or a value changes in the Inspector.

<a id="KaijuSolutions_Agents_KaijuController_OnEnable"></a>

### OnEnable

~~~csharp
protected virtual void OnEnable ()
~~~

This function is called when the object becomes enabled and active.

<a id="KaijuSolutions_Agents_KaijuController_OnDisable"></a>

### OnDisable

~~~csharp
protected virtual void OnDisable ()
~~~

This function is called when the behaviour becomes disabled.

<a id="KaijuSolutions_Agents_KaijuController_OnAgentPreSetPosition"></a>

### OnAgentPreSetPosition

~~~csharp
protected virtual void OnAgentPreSetPosition ()
~~~

Callback for before the KaijuSolutions.Agents.KaijuController.Agent's position has been set.

<a id="KaijuSolutions_Agents_KaijuController_OnAgentSetPosition"></a>

### OnAgentSetPosition

~~~csharp
protected virtual void OnAgentSetPosition ()
~~~

Callback for when the KaijuSolutions.Agents.KaijuController.Agent's position has been set.

<a id="KaijuSolutions_Agents_KaijuController_OnAgentPreSetOrientation"></a>

### OnAgentPreSetOrientation

~~~csharp
protected virtual void OnAgentPreSetOrientation ()
~~~

Callback for before the KaijuSolutions.Agents.KaijuController.Agent's orientation has been set.

<a id="KaijuSolutions_Agents_KaijuController_OnAgentSetOrientation"></a>

### OnAgentSetOrientation

~~~csharp
protected virtual void OnAgentSetOrientation ()
~~~

Callback for when the KaijuSolutions.Agents.KaijuController.Agent's orientation has been set.

<a id="KaijuSolutions_Agents_KaijuController_OnAgentPreSetScale"></a>

### OnAgentPreSetScale

~~~csharp
protected virtual void OnAgentPreSetScale ()
~~~

Callback for before the KaijuSolutions.Agents.KaijuController.Agent's scale has been set.

<a id="KaijuSolutions_Agents_KaijuController_OnAgentSetScale"></a>

### OnAgentSetScale

~~~csharp
protected virtual void OnAgentSetScale ()
~~~

Callback for when the KaijuSolutions.Agents.KaijuController.Agent's scale has been set.

<a id="KaijuSolutions_Agents_KaijuController_OnMoveSpeed"></a>

### OnMoveSpeed

~~~csharp
protected virtual void OnMoveSpeed ()
~~~

Movement speed changed callback for the KaijuSolutions.Agents.KaijuController.Agent.

<a id="KaijuSolutions_Agents_KaijuController_OnMoveAcceleration"></a>

### OnMoveAcceleration

~~~csharp
protected virtual void OnMoveAcceleration ()
~~~

Movement acceleration changed callback for the KaijuSolutions.Agents.KaijuController.Agent.

<a id="KaijuSolutions_Agents_KaijuController_OnLookSpeed"></a>

### OnLookSpeed

~~~csharp
protected virtual void OnLookSpeed ()
~~~

Look speed changed callback for the KaijuSolutions.Agents.KaijuController.Agent.

<a id="KaijuSolutions_Agents_KaijuController_OnAutoRotate"></a>

### OnAutoRotate

~~~csharp
protected virtual void OnAutoRotate ()
~~~

Autorotation changed callback for the KaijuSolutions.Agents.KaijuController.Agent.

<a id="KaijuSolutions_Agents_KaijuController_OnLookTarget"></a>

### OnLookTarget

~~~csharp
protected virtual void OnLookTarget ()
~~~

Callback for when the look target has been set for the KaijuSolutions.Agents.KaijuController.Agent.

<a id="KaijuSolutions_Agents_KaijuController_OnMove"></a>

### OnMove

~~~csharp
protected virtual void OnMove ()
~~~

Callback for when the KaijuSolutions.Agents.KaijuController.Agent has moved.

<a id="KaijuSolutions_Agents_KaijuController_OnEnabled"></a>

### OnEnabled

~~~csharp
protected virtual void OnEnabled ()
~~~

Callback for when the KaijuSolutions.Agents.KaijuController.Agent has finishing becoming enabled.

<a id="KaijuSolutions_Agents_KaijuController_OnDisabled"></a>

### OnDisabled

~~~csharp
protected virtual void OnDisabled ()
~~~

Callback for when the KaijuSolutions.Agents.KaijuController.Agent has finishing becoming disabled.

<a id="KaijuSolutions_Agents_KaijuController_OnDestroyed"></a>

### OnDestroyed

~~~csharp
protected virtual void OnDestroyed ()
~~~

Callback for when the KaijuSolutions.Agents.KaijuController.Agent has finishing becoming destroyed.

<a id="KaijuSolutions_Agents_KaijuController_OnMovementStarted"></a>

### OnMovementStarted

~~~csharp
protected virtual void OnMovementStarted ([NotNull] KaijuMovement movement)
~~~

Callback for when a KaijuSolutions.Agents.Movement.KaijuMovement has started.

<a id="KaijuSolutions_Agents_KaijuController_OnMovementStopped"></a>

### OnMovementStopped

~~~csharp
protected virtual void OnMovementStopped ([NotNull] KaijuMovement movement)
~~~

Callback for when a KaijuSolutions.Agents.Movement.KaijuMovement has stopped.

<a id="KaijuSolutions_Agents_KaijuController_OnMovementPerformed"></a>

### OnMovementPerformed

~~~csharp
protected virtual void OnMovementPerformed ([NotNull] KaijuMovement movement)
~~~

Callback for when a KaijuSolutions.Agents.Movement.KaijuMovement has been performed.

<a id="KaijuSolutions_Agents_KaijuController_OnAutomaticSense"></a>

### OnAutomaticSense

~~~csharp
protected virtual void OnAutomaticSense ()
~~~

Callback for when all automatic KaijuSolutions.Agents.Sensors.KaijuSensors have finished being executed.

<a id="KaijuSolutions_Agents_KaijuController_OnSense"></a>

### OnSense

~~~csharp
protected virtual void OnSense ([NotNull] KaijuSensor sensor)
~~~

Callback for when a KaijuSolutions.Agents.Sensors.KaijuSensor has been run.

<a id="KaijuSolutions_Agents_KaijuController_OnSensorEnabled"></a>

### OnSensorEnabled

~~~csharp
protected virtual void OnSensorEnabled ([NotNull] KaijuSensor sensor)
~~~

Callback for when a KaijuSolutions.Agents.Sensors.KaijuSensor has been enabled.

<a id="KaijuSolutions_Agents_KaijuController_OnSensorDisabled"></a>

### OnSensorDisabled

~~~csharp
protected virtual void OnSensorDisabled ([NotNull] KaijuSensor sensor)
~~~

Callback for when a KaijuSolutions.Agents.Sensors.KaijuSensor has been disabled.

<a id="KaijuSolutions_Agents_KaijuController_OnActuatorEnabled"></a>

### OnActuatorEnabled

~~~csharp
protected virtual void OnActuatorEnabled ([NotNull] KaijuActuator actuator)
~~~

Callback for when an KaijuSolutions.Agents.Actuators.KaijuActuator has been enabled.

<a id="KaijuSolutions_Agents_KaijuController_OnActuatorDisabled"></a>

### OnActuatorDisabled

~~~csharp
protected virtual void OnActuatorDisabled ([NotNull] KaijuActuator actuator)
~~~

Callback for when an KaijuSolutions.Agents.Actuators.KaijuActuator has been disabled.

<a id="KaijuSolutions_Agents_KaijuController_OnActuatorStarted"></a>

### OnActuatorStarted

~~~csharp
protected virtual void OnActuatorStarted ([NotNull] KaijuActuator actuator)
~~~

Callback for when an KaijuSolutions.Agents.Actuators.KaijuActuator has started to execute.

<a id="KaijuSolutions_Agents_KaijuController_OnActuatorExecuting"></a>

### OnActuatorExecuting

~~~csharp
protected virtual void OnActuatorExecuting ([NotNull] KaijuActuator actuator)
~~~

Callback for when an KaijuSolutions.Agents.Actuators.KaijuActuator is continuing to execute.

<a id="KaijuSolutions_Agents_KaijuController_OnActuatorDone"></a>

### OnActuatorDone

~~~csharp
protected virtual void OnActuatorDone ([NotNull] KaijuActuator actuator)
~~~

Callback for when an KaijuSolutions.Agents.Actuators.KaijuActuator has successfully fully completed its action.

<a id="KaijuSolutions_Agents_KaijuController_OnActuatorInterrupted"></a>

### OnActuatorInterrupted

~~~csharp
protected virtual void OnActuatorInterrupted ([NotNull] KaijuActuator actuator)
~~~

Callback for when an KaijuSolutions.Agents.Actuators.KaijuActuator has been interrupted during its execution, cancelling the execution.

<a id="KaijuSolutions_Agents_KaijuController_OnActuatorFailed"></a>

### OnActuatorFailed

~~~csharp
protected virtual void OnActuatorFailed ([NotNull] KaijuActuator actuator)
~~~

Callback for when an KaijuSolutions.Agents.Actuators.KaijuActuator has failed its execution.

<a id="KaijuSolutions_Agents_KaijuController_ToString"></a>

### ToString

~~~csharp
public override string ToString ()
~~~

Get a description of the object.

~~~csharp
public static implicit operator KaijuController ([NotNull] GameObject o)
~~~

Implicit conversion from a GameObject.

~~~csharp
public static implicit operator KaijuController ([NotNull] Transform t)
~~~

Implicit conversion from a transform.

~~~csharp
public static implicit operator KaijuController ([NotNull] KaijuAgent a)
~~~

Implicit conversion from a KaijuSolutions.Agents.KaijuAgent.

~~~csharp
public static implicit operator KaijuAgent ([NotNull] KaijuController c)
~~~

Implicit conversion to a KaijuSolutions.Agents.KaijuAgent.
