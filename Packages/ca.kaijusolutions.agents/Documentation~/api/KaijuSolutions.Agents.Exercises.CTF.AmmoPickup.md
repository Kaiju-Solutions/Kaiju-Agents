# AmmoPickup

Pickup to restore ammo.

~~~csharp
public class AmmoPickup : NumberPickup
~~~

[Package source](../../Samples~/Exercise%203%20-%20Capture%20the%20Flag/Pickups/AmmoPickup.cs)

<a id="KaijuSolutions_Agents_Exercises_CTF_AmmoPickup_All"></a>

### All

~~~csharp
public static IReadOnlyCollection<AmmoPickup> All { get; }
~~~

Get all active ammo pickups.

<a id="KaijuSolutions_Agents_Exercises_CTF_AmmoPickup_OnSetActive"></a>

### OnSetActive

~~~csharp
protected override void OnSetActive (bool active)
~~~

Additional behaviour for when the active state of this has changed.

<a id="KaijuSolutions_Agents_Exercises_CTF_AmmoPickup_ToString"></a>

### ToString

~~~csharp
public override string ToString ()
~~~

Get a description of the object.
