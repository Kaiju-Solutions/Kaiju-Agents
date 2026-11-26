# Microbe

Microbes which can mate with and eat each other.

~~~csharp
public class Microbe : KaijuController
~~~

[Package source](../../Samples~/Exercise%202%20-%20Microbes/Microbe/Microbe.cs)

<a id="KaijuSolutions_Agents_Exercises_Microbes_Microbe_OnEat"></a>

### OnEat

~~~csharp
public event MicrobeAction OnEat
~~~

Callback for this microbe eating.

<a id="KaijuSolutions_Agents_Exercises_Microbes_Microbe_OnEaten"></a>

### OnEaten

~~~csharp
public event MicrobeAction OnEaten
~~~

Callback for this microbe being eaten.

<a id="KaijuSolutions_Agents_Exercises_Microbes_Microbe_OnEatGlobal"></a>

### OnEatGlobal

~~~csharp
public event MultiMicrobeAction OnEatGlobal
~~~

Global callback for this microbe eating.

<a id="KaijuSolutions_Agents_Exercises_Microbes_Microbe_OnMate"></a>

### OnMate

~~~csharp
public event MicrobeAction OnMate
~~~

Callback for this microbe mating.

<a id="KaijuSolutions_Agents_Exercises_Microbes_Microbe_OnMateGlobal"></a>

### OnMateGlobal

~~~csharp
public event MultiMicrobeAction OnMateGlobal
~~~

Global callback for this microbe mating.

<a id="KaijuSolutions_Agents_Exercises_Microbes_Microbe_OnEnergy"></a>

### OnEnergy

~~~csharp
public event KaijuAction OnEnergy
~~~

Callback for this microbe picking up energy.

<a id="KaijuSolutions_Agents_Exercises_Microbes_Microbe_OnEnergyGlobal"></a>

### OnEnergyGlobal

~~~csharp
public event MicrobeAction OnEnergyGlobal
~~~

Global c for this microbe picking up energy.

<a id="KaijuSolutions_Agents_Exercises_Microbes_Microbe_All"></a>

### All

~~~csharp
public static IReadOnlyCollection<Microbe> All { get; }
~~~

All microbes currently in the world.

<a id="KaijuSolutions_Agents_Exercises_Microbes_Microbe_Energy"></a>

### Energy

~~~csharp
public float Energy { get; set; }
~~~

The current energy of this microbe. This will Decay every second, and this microbe needs energy to stay alive. Walk into EnergyPickup pickups to restore this. Microbes with higher energy levels than other microbes can eat them.

<a id="KaijuSolutions_Agents_Exercises_Microbes_Microbe_Decay"></a>

### Decay

~~~csharp
public float Decay { get; set; }
~~~

How much Energy this microbe loses per second.

<a id="KaijuSolutions_Agents_Exercises_Microbes_Microbe_CanMate"></a>

### CanMate

~~~csharp
public bool CanMate { get; }
~~~

See if this microbe can mate given the limits set by the game.

<a id="KaijuSolutions_Agents_Exercises_Microbes_Microbe_OnCooldown"></a>

### OnCooldown

~~~csharp
public bool OnCooldown { get; }
~~~

If this microbe is currently on a cooldown for mating.

<a id="KaijuSolutions_Agents_Exercises_Microbes_Microbe_Cooldown"></a>

### Cooldown

~~~csharp
public float Cooldown { get; private set; }
~~~

The time in seconds the microbe needs to wait before it can Mate again.

<a id="KaijuSolutions_Agents_Exercises_Microbes_Microbe_Compatible"></a>

### Compatible

~~~csharp
public bool Compatible ([NotNull] Microbe other)
~~~

See if this microbe is compatible to mate with another microbe. Note this does not check if either microbe is still on Cooldown for mating. For that, check OnCooldown.

<a id="KaijuSolutions_Agents_Exercises_Microbes_Microbe_Eatable"></a>

### Eatable

~~~csharp
public bool Eatable ([NotNull] Microbe other)
~~~

See if this microbe could eat another microbe. Note this does not check if this has enough Energy to eat the other microbe, being more Energy than the other microbe has.

<a id="KaijuSolutions_Agents_Exercises_Microbes_Microbe_Spawn"></a>

### Spawn

~~~csharp
public static void Spawn (KaijuAgent microbePrefab, float energy, Vector2 position, uint identifier)
~~~

Spawn a microbe.

<a id="KaijuSolutions_Agents_Exercises_Microbes_Microbe_OnEnable"></a>

### OnEnable

~~~csharp
protected override void OnEnable ()
~~~

This function is called when the object becomes enabled and active.

<a id="KaijuSolutions_Agents_Exercises_Microbes_Microbe_OnDisable"></a>

### OnDisable

~~~csharp
protected override void OnDisable ()
~~~

This function is called when the behaviour becomes disabled.

<a id="KaijuSolutions_Agents_Exercises_Microbes_Microbe_ToString"></a>

### ToString

~~~csharp
public override string ToString ()
~~~

Get a description of the object.
