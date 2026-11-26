# CaptureTheFlagManager

Manager for Troopers to play capture the flag.

~~~csharp
public class CaptureTheFlagManager : KaijuGlobalController
~~~

[Package source](../../Samples~/Exercise%203%20-%20Capture%20the%20Flag/Environment/CaptureTheFlagManager.cs)

<a id="KaijuSolutions_Agents_Exercises_CTF_CaptureTheFlagManager_Instance"></a>

### Instance

~~~csharp
public static CaptureTheFlagManager Instance { get; }
~~~

The singleton manager instance.

<a id="KaijuSolutions_Agents_Exercises_CTF_CaptureTheFlagManager_Health"></a>

### Health

~~~csharp
public static int Health { get; }
~~~

The maximum and starting Trooper.Health of Troopers.

<a id="KaijuSolutions_Agents_Exercises_CTF_CaptureTheFlagManager_Damage"></a>

### Damage

~~~csharp
public static int Damage { get; }
~~~

The damage the BlasterActuators deal to Troopers.

<a id="KaijuSolutions_Agents_Exercises_CTF_CaptureTheFlagManager_Ammo"></a>

### Ammo

~~~csharp
public static int Ammo { get; }
~~~

The maximum and starting Trooper.Ammo of Troopers for their blaster.

<a id="KaijuSolutions_Agents_Exercises_CTF_CaptureTheFlagManager_Cooldown"></a>

### Cooldown

~~~csharp
public static float Cooldown { get; }
~~~

The cooldown timer for HealthPickups and AmmoPickups.

<a id="KaijuSolutions_Agents_Exercises_CTF_CaptureTheFlagManager_CaptureDistance"></a>

### CaptureDistance

~~~csharp
public static float CaptureDistance { get; }
~~~

How close to a Trooper's own base to capture a Flag they are carrying.

<a id="KaijuSolutions_Agents_Exercises_CTF_CaptureTheFlagManager_Respawn"></a>

### Respawn

~~~csharp
public static float Respawn { get; }
~~~

The time in seconds for Troopers to respawn.

<a id="KaijuSolutions_Agents_Exercises_CTF_CaptureTheFlagManager_Size"></a>

### Size

~~~csharp
public static int Size { get; }
~~~

The number of Troopers per team.

<a id="KaijuSolutions_Agents_Exercises_CTF_CaptureTheFlagManager_ColorOne"></a>

### ColorOne

~~~csharp
public static Color ColorOne { get; }
~~~

The color for team one.

<a id="KaijuSolutions_Agents_Exercises_CTF_CaptureTheFlagManager_ColorTwo"></a>

### ColorTwo

~~~csharp
public static Color ColorTwo { get; }
~~~

The color for team two.

<a id="KaijuSolutions_Agents_Exercises_CTF_CaptureTheFlagManager_OnEnable"></a>

### OnEnable

~~~csharp
protected override void OnEnable ()
~~~

This function is called when the object becomes enabled and active.

<a id="KaijuSolutions_Agents_Exercises_CTF_CaptureTheFlagManager_OnDisable"></a>

### OnDisable

~~~csharp
protected override void OnDisable ()
~~~

This function is called when the behaviour becomes disabled.

<a id="KaijuSolutions_Agents_Exercises_CTF_CaptureTheFlagManager_OnAgentDisabled"></a>

### OnAgentDisabled

~~~csharp
protected override void OnAgentDisabled (KaijuAgent agent)
~~~

Global callback for when a KaijuSolutions.Agents.KaijuAgent has finishing becoming disabled.

<a id="KaijuSolutions_Agents_Exercises_CTF_CaptureTheFlagManager_ToString"></a>

### ToString

~~~csharp
public override string ToString ()
~~~

Get a description of the object.
