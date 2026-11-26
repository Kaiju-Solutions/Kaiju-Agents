# Pickup

Base pickup class for Troopers to pickup.

~~~csharp
public abstract class Pickup : KaijuBehaviour
~~~

[Package source](../../Samples~/Exercise%203%20-%20Capture%20the%20Flag/Pickups/Pickup.cs)

<a id="KaijuSolutions_Agents_Exercises_CTF_Pickup_Interact"></a>

### Interact

~~~csharp
public abstract bool Interact ([NotNull] Trooper trooper)
~~~

What to do when interacted with.

<a id="KaijuSolutions_Agents_Exercises_CTF_Pickup_Colliders"></a>

### Colliders

~~~csharp
protected IReadOnlyList<Collider> Colliders { get; }
~~~

All colliders attached to this.

<a id="KaijuSolutions_Agents_Exercises_CTF_Pickup_Renderers"></a>

### Renderers

~~~csharp
protected IReadOnlyList<MeshRenderer> Renderers { get; }
~~~

All renderers attached to this.

<a id="KaijuSolutions_Agents_Exercises_CTF_Pickup_OnEnable"></a>

### OnEnable

~~~csharp
protected virtual void OnEnable ()
~~~

This function is called when the object becomes enabled and active.

<a id="KaijuSolutions_Agents_Exercises_CTF_Pickup_OnValidate"></a>

### OnValidate

~~~csharp
protected virtual void OnValidate ()
~~~

Editor-only function that Unity calls when the script is loaded or a value changes in the Inspector.

<a id="KaijuSolutions_Agents_Exercises_CTF_Pickup_ToString"></a>

### ToString

~~~csharp
public override string ToString ()
~~~

Get a description of the object.
