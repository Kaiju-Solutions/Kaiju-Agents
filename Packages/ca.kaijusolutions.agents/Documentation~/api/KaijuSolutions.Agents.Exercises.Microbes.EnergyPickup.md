# EnergyPickup

Simple energy element which can spawn in the world which Microbes can walk into to pick up.

~~~csharp
public class EnergyPickup : KaijuBehaviour
~~~

[Package source](../../Samples~/Exercise%202%20-%20Microbes/Environment/EnergyPickup.cs)

<a id="KaijuSolutions_Agents_Exercises_Microbes_EnergyPickup_All"></a>

### All

~~~csharp
public static IReadOnlyCollection<EnergyPickup> All { get; }
~~~

All energies currently in the world.

<a id="KaijuSolutions_Agents_Exercises_Microbes_EnergyPickup_Spawn"></a>

### Spawn

~~~csharp
public static void Spawn ([NotNull] EnergyPickup energyPrefab, Vector2 position)
~~~

Spawn an energy.

<a id="KaijuSolutions_Agents_Exercises_Microbes_EnergyPickup_ToString"></a>

### ToString

~~~csharp
public override string ToString ()
~~~

Get a description of the object.
