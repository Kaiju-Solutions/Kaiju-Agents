# BoxDestroyerController

Simple KaijuSolutions.Agents.KaijuController to destroy boxes.

~~~csharp
public class BoxDestroyerController : KaijuController
~~~

[Package source](../../Samples~/Box%20Destroyer/BoxDestroyerController.cs)

<a id="KaijuSolutions_Agents_Samples_BoxDestroyer_BoxDestroyerController_OnEnabled"></a>

### OnEnabled

~~~csharp
protected override void OnEnabled ()
~~~

Callback for when the KaijuSolutions.Agents.KaijuController.Agent has finishing becoming enabled.

<a id="KaijuSolutions_Agents_Samples_BoxDestroyer_BoxDestroyerController_OnSense"></a>

### OnSense

~~~csharp
protected override void OnSense (KaijuSensor sensor)
~~~

Callback for when a KaijuSolutions.Agents.Sensors.KaijuSensor has been run.

<a id="KaijuSolutions_Agents_Samples_BoxDestroyer_BoxDestroyerController_OnMovementStopped"></a>

### OnMovementStopped

~~~csharp
protected override void OnMovementStopped (KaijuMovement movement)
~~~

Callback for when a KaijuSolutions.Agents.Movement.KaijuMovement has stopped.

<a id="KaijuSolutions_Agents_Samples_BoxDestroyer_BoxDestroyerController_OnActuatorDone"></a>

### OnActuatorDone

~~~csharp
protected override void OnActuatorDone (KaijuActuator actuator)
~~~

Callback for when an KaijuSolutions.Agents.Actuators.KaijuActuator has successfully fully completed its action.

<a id="KaijuSolutions_Agents_Samples_BoxDestroyer_BoxDestroyerController_OnActuatorFailed"></a>

### OnActuatorFailed

~~~csharp
protected override void OnActuatorFailed (KaijuActuator actuator)
~~~

Callback for when an KaijuSolutions.Agents.Actuators.KaijuActuator has failed its execution.

<a id="KaijuSolutions_Agents_Samples_BoxDestroyer_BoxDestroyerController_ToString"></a>

### ToString

~~~csharp
public override string ToString ()
~~~

Get a description of the object.
