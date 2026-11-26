# BlasterActuator

The blaster for use by Troopers.

~~~csharp
public class BlasterActuator : KaijuAttackActuator
~~~

[Package source](../../Samples~/Exercise%203%20-%20Capture%20the%20Flag/Trooper/BlasterActuator.cs)

<a id="KaijuSolutions_Agents_Exercises_CTF_BlasterActuator_Ammo"></a>

### Ammo

~~~csharp
public int Ammo { get; set; }
~~~

The ammo for this blaster.

<a id="KaijuSolutions_Agents_Exercises_CTF_BlasterActuator_OnEnable"></a>

### OnEnable

~~~csharp
protected override void OnEnable ()
~~~

This function is called when the object becomes enabled and active.

<a id="KaijuSolutions_Agents_Exercises_CTF_BlasterActuator_OnDisable"></a>

### OnDisable

~~~csharp
protected override void OnDisable ()
~~~

This function is called when the behaviour becomes disabled.

<a id="KaijuSolutions_Agents_Exercises_CTF_BlasterActuator_PreConditions"></a>

### PreConditions

~~~csharp
protected override bool PreConditions ()
~~~

Any conditions which must be passed to begin running the actuator. This does not need to account for the KaijuSolutions.Agents.Actuators.KaijuAttackActuator.Charge or KaijuSolutions.Agents.Actuators.KaijuAttackActuator.Cooldown.

<a id="KaijuSolutions_Agents_Exercises_CTF_BlasterActuator_PostActions"></a>

### PostActions

~~~csharp
protected override void PostActions (bool success)
~~~

Any final actions to perform after the actuator has performed.

<a id="KaijuSolutions_Agents_Exercises_CTF_BlasterActuator_HandleHit"></a>

### HandleHit

~~~csharp
protected override bool HandleHit (RaycastHit hit, Transform t)
~~~

Handle the hit logic.

<a id="KaijuSolutions_Agents_Exercises_CTF_BlasterActuator_ToString"></a>

### ToString

~~~csharp
public override string ToString ()
~~~

Get a description of the object.
