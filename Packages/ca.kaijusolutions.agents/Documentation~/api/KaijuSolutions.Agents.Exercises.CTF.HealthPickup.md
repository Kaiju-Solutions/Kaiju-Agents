# HealthPickup

Pickup to restore Trooper.Health.

~~~csharp
public class HealthPickup : NumberPickup
~~~

[Package source](../../Samples~/Exercise%203%20-%20Capture%20the%20Flag/Pickups/HealthPickup.cs)

<a id="KaijuSolutions_Agents_Exercises_CTF_HealthPickup_All"></a>

### All

~~~csharp
public static IReadOnlyCollection<HealthPickup> All { get; }
~~~

Get all active health pickups.

<a id="KaijuSolutions_Agents_Exercises_CTF_HealthPickup_OnSetActive"></a>

### OnSetActive

~~~csharp
protected override void OnSetActive (bool active)
~~~

Additional behaviour for when the active state of this has changed.

<a id="KaijuSolutions_Agents_Exercises_CTF_HealthPickup_ToString"></a>

### ToString

~~~csharp
public override string ToString ()
~~~

Get a description of the object.
