# KaijuActuator

Base actuator class.

~~~csharp
public abstract class KaijuActuator : KaijuBehaviour
~~~

[Package source](../../Runtime/Actuators/KaijuActuator.cs)

<a id="KaijuSolutions_Agents_Actuators_KaijuActuator_OnStarted"></a>

### OnStarted

~~~csharp
public event KaijuAction OnStarted
~~~

Callback for when this has started to execute.

<a id="KaijuSolutions_Agents_Actuators_KaijuActuator_OnStartedGlobal"></a>

### OnStartedGlobal

~~~csharp
public static event KaijuActuatorAction OnStartedGlobal
~~~

Global callback for when this has started to execute.

<a id="KaijuSolutions_Agents_Actuators_KaijuActuator_OnExecuting"></a>

### OnExecuting

~~~csharp
public event KaijuAction OnExecuting
~~~

Callback for when this is continuing to execute.

<a id="KaijuSolutions_Agents_Actuators_KaijuActuator_OnExecutingGlobal"></a>

### OnExecutingGlobal

~~~csharp
public static event KaijuActuatorAction OnExecutingGlobal
~~~

Global callback for when this is continuing to execute.

<a id="KaijuSolutions_Agents_Actuators_KaijuActuator_OnDone"></a>

### OnDone

~~~csharp
public event KaijuAction OnDone
~~~

Callback for when this has successfully fully completed its action.

<a id="KaijuSolutions_Agents_Actuators_KaijuActuator_OnDoneGlobal"></a>

### OnDoneGlobal

~~~csharp
public static event KaijuActuatorAction OnDoneGlobal
~~~

Global callback for when this has successfully fully completed its action.

<a id="KaijuSolutions_Agents_Actuators_KaijuActuator_OnInterrupted"></a>

### OnInterrupted

~~~csharp
public event KaijuAction OnInterrupted
~~~

Callback for when this has been interrupted during its execution, cancelling the execution.

<a id="KaijuSolutions_Agents_Actuators_KaijuActuator_OnInterruptedGlobal"></a>

### OnInterruptedGlobal

~~~csharp
public static event KaijuActuatorAction OnInterruptedGlobal
~~~

Global callback for when this has been interrupted during its execution, cancelling the execution.

<a id="KaijuSolutions_Agents_Actuators_KaijuActuator_OnFailed"></a>

### OnFailed

~~~csharp
public event KaijuAction OnFailed
~~~

Callback for when this has failed its execution.

<a id="KaijuSolutions_Agents_Actuators_KaijuActuator_OnFailedGlobal"></a>

### OnFailedGlobal

~~~csharp
public static event KaijuActuatorAction OnFailedGlobal
~~~

Global callback when this has failed its execution.

<a id="KaijuSolutions_Agents_Actuators_KaijuActuator_OnEnabled"></a>

### OnEnabled

~~~csharp
public event KaijuAction OnEnabled
~~~

Callback for when this has finishing becoming enabled.

<a id="KaijuSolutions_Agents_Actuators_KaijuActuator_OnEnabledGlobal"></a>

### OnEnabledGlobal

~~~csharp
public static event KaijuActuatorAction OnEnabledGlobal
~~~

Global callback for when this has finishing becoming enabled.

<a id="KaijuSolutions_Agents_Actuators_KaijuActuator_OnDisabled"></a>

### OnDisabled

~~~csharp
public event KaijuAction OnDisabled
~~~

Callback for when this has finishing becoming disabled.

<a id="KaijuSolutions_Agents_Actuators_KaijuActuator_OnDisabledGlobal"></a>

### OnDisabledGlobal

~~~csharp
public static event KaijuActuatorAction OnDisabledGlobal
~~~

Global callback for when this has finishing becoming disabled.

<a id="KaijuSolutions_Agents_Actuators_KaijuActuator_Agent"></a>

### Agent

~~~csharp
public KaijuAgent Agent { get; private set; }
~~~

The KaijuSolutions.Agents.KaijuAgent this actuator is assigned to.

<a id="KaijuSolutions_Agents_Actuators_KaijuActuator_SimulationEntity"></a>

### SimulationEntity

~~~csharp
public Entity SimulationEntity { get; private set; }
~~~

Set KaijuActuation.Requested on this entity to drive the actuator from ECS.

<a id="KaijuSolutions_Agents_Actuators_KaijuActuator_IsRunning"></a>

### IsRunning

~~~csharp
public bool IsRunning { get; private set; }
~~~

If the actuator is currently running.

<a id="KaijuSolutions_Agents_Actuators_KaijuActuator_State"></a>

### State

~~~csharp
public KaijuActuatorState State { get; private set; }
~~~

The last state of the actuator.

<a id="KaijuSolutions_Agents_Actuators_KaijuActuator_OnEnable"></a>

### OnEnable

~~~csharp
protected virtual void OnEnable ()
~~~

This function is called when the object becomes enabled and active.

<a id="KaijuSolutions_Agents_Actuators_KaijuActuator_OnDisable"></a>

### OnDisable

~~~csharp
protected virtual void OnDisable ()
~~~

This function is called when the behaviour becomes disabled.

<a id="KaijuSolutions_Agents_Actuators_KaijuActuator_Begin"></a>

### Begin

~~~csharp
public void Begin ()
~~~

If the actuator should act in its next execution step.

<a id="KaijuSolutions_Agents_Actuators_KaijuActuator_End"></a>

### End

~~~csharp
public void End ()
~~~

End the execution of this actuator.

<a id="KaijuSolutions_Agents_Actuators_KaijuActuator_Handle"></a>

### Handle

~~~csharp
public void Handle ()
~~~

Run this actuator if it should be. There is no point in manually calling this.

<a id="KaijuSolutions_Agents_Actuators_KaijuActuator_StepDeltaTime"></a>

### StepDeltaTime

~~~csharp
protected float StepDeltaTime { get; private set; }
~~~

<a id="KaijuSolutions_Agents_Actuators_KaijuActuator_Tick"></a>

### Tick

~~~csharp
protected virtual void Tick (float delta)
~~~

<a id="KaijuSolutions_Agents_Actuators_KaijuActuator_Run"></a>

### Run

~~~csharp
protected abstract KaijuActuatorState Run ()
~~~

Run the actuator.

<a id="KaijuSolutions_Agents_Actuators_KaijuActuator_Cleanup"></a>

### Cleanup

~~~csharp
protected virtual void Cleanup ()
~~~

Perform any needed resetting of the actuator.

<a id="KaijuSolutions_Agents_Actuators_KaijuActuator_EditorVisualize"></a>

### EditorVisualize

~~~csharp
public virtual void EditorVisualize (Vector3 position)
~~~

Allow for visualizing in the editor. The position of the KaijuSolutions.Agents.KaijuController.Agent.

<a id="KaijuSolutions_Agents_Actuators_KaijuActuator_ToString"></a>

### ToString

~~~csharp
public override string ToString ()
~~~

Get a description of the object.

~~~csharp
public static implicit operator KaijuActuator ([NotNull] GameObject o)
~~~

Implicit conversion from a GameObject.

~~~csharp
public static implicit operator KaijuActuator ([NotNull] Transform t)
~~~

Implicit conversion from a transform.

~~~csharp
public static implicit operator KaijuAgent ([NotNull] KaijuActuator a)
~~~

Implicit conversion to a KaijuSolutions.Agents.KaijuAgent.
