# SpawnPoint

Points which Troopers can spawn at.

~~~csharp
public class SpawnPoint : KaijuBehaviour, IComparable<SpawnPoint>
~~~

[Package source](../../Samples~/Exercise%203%20-%20Capture%20the%20Flag/Environment/SpawnPoint.cs)

<a id="KaijuSolutions_Agents_Exercises_CTF_SpawnPoint_NextSpawnPoint"></a>

### NextSpawnPoint

~~~csharp
public static SpawnPoint NextSpawnPoint (bool teamOne)
~~~

Get the next point to spawn at, prioritizing open points first.

<a id="KaijuSolutions_Agents_Exercises_CTF_SpawnPoint_TeamOne"></a>

### TeamOne

~~~csharp
public bool TeamOne { get; private set; }
~~~

If this is for team one.

<a id="KaijuSolutions_Agents_Exercises_CTF_SpawnPoint_Occupied"></a>

### Occupied

~~~csharp
public bool Occupied { get; }
~~~

If this is currently occupied by any Troopers.

<a id="KaijuSolutions_Agents_Exercises_CTF_SpawnPoint_SpawnOccupy"></a>

### SpawnOccupy

~~~csharp
public void SpawnOccupy (Trooper trooper)
~~~

Manually occupy this on a spawn as physics collisions won't pick it up right away.

<a id="KaijuSolutions_Agents_Exercises_CTF_SpawnPoint_CompareTo"></a>

### CompareTo

~~~csharp
public int CompareTo (SpawnPoint other)
~~~

Compare to another instance for sorting.

<a id="KaijuSolutions_Agents_Exercises_CTF_SpawnPoint_ToString"></a>

### ToString

~~~csharp
public override string ToString ()
~~~

Get a description of the object.
