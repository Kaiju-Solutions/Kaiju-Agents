# TrooperController

Basic controller for you to get started with.

~~~csharp
public class TrooperController : KaijuController
~~~

[Package source](../../Samples~/Exercise%203%20-%20Capture%20the%20Flag/Trooper/TrooperController.cs)

<a id="KaijuSolutions_Agents_Exercises_CTF_TrooperController_OnSense"></a>

### OnSense

~~~csharp
protected override void OnSense (KaijuSensor sensor)
~~~

Callback for when a KaijuSolutions.Agents.Sensors.KaijuSensor has been run.

<a id="KaijuSolutions_Agents_Exercises_CTF_TrooperController_OnValidate"></a>

### OnValidate

~~~csharp
protected override void OnValidate ()
~~~

Editor-only function that Unity calls when the script is loaded or a value changes in the Inspector.

<a id="KaijuSolutions_Agents_Exercises_CTF_TrooperController_OnEnable"></a>

### OnEnable

~~~csharp
protected override void OnEnable ()
~~~

This function is called when the object becomes enabled and active.

<a id="KaijuSolutions_Agents_Exercises_CTF_TrooperController_OnDisable"></a>

### OnDisable

~~~csharp
protected override void OnDisable ()
~~~

This function is called when the behaviour becomes disabled.

<a id="KaijuSolutions_Agents_Exercises_CTF_TrooperController_ToString"></a>

### ToString

~~~csharp
public override string ToString ()
~~~

Get a description of the object.
