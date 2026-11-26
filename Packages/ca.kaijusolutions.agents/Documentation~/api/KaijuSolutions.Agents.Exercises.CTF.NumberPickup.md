# NumberPickup

Pickup class which will restore some numeric value before going on cooldown.

~~~csharp
public abstract class NumberPickup : Pickup
~~~

[Package source](../../Samples~/Exercise%203%20-%20Capture%20the%20Flag/Pickups/NumberPickup.cs)

<a id="KaijuSolutions_Agents_Exercises_CTF_NumberPickup_OnCooldown"></a>

### OnCooldown

~~~csharp
public bool OnCooldown { get; }
~~~

If this pickup is currently on a cooldown.

<a id="KaijuSolutions_Agents_Exercises_CTF_NumberPickup_Cooldown"></a>

### Cooldown

~~~csharp
public float Cooldown { get; private set; }
~~~

The current cooldown time left in seconds on this pickup.

<a id="KaijuSolutions_Agents_Exercises_CTF_NumberPickup_OnEnable"></a>

### OnEnable

~~~csharp
protected override void OnEnable ()
~~~

This function is called when the object becomes enabled and active.

<a id="KaijuSolutions_Agents_Exercises_CTF_NumberPickup_Interact"></a>

### Interact

~~~csharp
public override bool Interact ([NotNull] Trooper trooper)
~~~

What to do when interacted with.

<a id="KaijuSolutions_Agents_Exercises_CTF_NumberPickup_OnSetActive"></a>

### OnSetActive

~~~csharp
protected abstract void OnSetActive (bool active)
~~~

Additional behaviour for when the active state of this has changed.

<a id="KaijuSolutions_Agents_Exercises_CTF_NumberPickup_ToString"></a>

### ToString

~~~csharp
public override string ToString ()
~~~

Get a description of the object.
