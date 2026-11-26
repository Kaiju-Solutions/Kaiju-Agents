# MicrobeManager

Manager for spawning Microbes and Energy components.

~~~csharp
public class MicrobeManager : KaijuBehaviour
~~~

[Package source](../../Samples~/Exercise%202%20-%20Microbes/Environment/MicrobeManager.cs)

<a id="KaijuSolutions_Agents_Exercises_Microbes_MicrobeManager_Instance"></a>

### Instance

~~~csharp
public static MicrobeManager Instance { get; }
~~~

The singleton manager instance.

<a id="KaijuSolutions_Agents_Exercises_Microbes_MicrobeManager_MicrobePrefab"></a>

### MicrobePrefab

~~~csharp
public static KaijuAgent MicrobePrefab { get; }
~~~

The prefab for the Microbes.

<a id="KaijuSolutions_Agents_Exercises_Microbes_MicrobeManager_MaximumMicrobes"></a>

### MaximumMicrobes

~~~csharp
public static int MaximumMicrobes { get; }
~~~

How many Microbe are allowed in the scene at most.

<a id="KaijuSolutions_Agents_Exercises_Microbes_MicrobeManager_MaximumEnergy"></a>

### MaximumEnergy

~~~csharp
public static int MaximumEnergy { get; }
~~~

The maximum number of EnergyPickup pickups allowed in the scene.

<a id="KaijuSolutions_Agents_Exercises_Microbes_MicrobeManager_Energy"></a>

### Energy

~~~csharp
public static float Energy { get; }
~~~

The Microbe.Energy level to spawn new Microbes at.

<a id="KaijuSolutions_Agents_Exercises_Microbes_MicrobeManager_Cooldown"></a>

### Cooldown

~~~csharp
public static float Cooldown { get; }
~~~

The time in seconds Microbes need to wait before they can Microbe.Mate again.

<a id="KaijuSolutions_Agents_Exercises_Microbes_MicrobeManager_GetColor"></a>

### GetColor

~~~csharp
public static Color GetColor (uint identifier)
~~~

Get the color for a species.

<a id="KaijuSolutions_Agents_Exercises_Microbes_MicrobeManager_ToString"></a>

### ToString

~~~csharp
public override string ToString ()
~~~

Get a description of the object.
