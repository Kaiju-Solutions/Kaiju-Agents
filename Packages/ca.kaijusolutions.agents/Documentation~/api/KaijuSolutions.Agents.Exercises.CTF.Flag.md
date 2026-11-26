# Flag

The flags themselves for Troopers to try and capture.

~~~csharp
public class Flag : Pickup
~~~

[Package source](../../Samples~/Exercise%203%20-%20Capture%20the%20Flag/Pickups/Flag.cs)

<a id="KaijuSolutions_Agents_Exercises_CTF_Flag_Base3"></a>

### Base3

~~~csharp
public static Vector3 Base3 (Flag flag)
~~~

Get the location of a flag's base.

<a id="KaijuSolutions_Agents_Exercises_CTF_Flag_Base"></a>

### Base

~~~csharp
public static Vector2 Base (Flag flag)
~~~

Get the location of a flag's base.

~~~csharp
public static Vector3 Base3 (bool teamOne)
~~~

Get the location of a team's base, being where their flag spawns and where to return captured flags to.

~~~csharp
public static Vector2 Base (bool teamOne)
~~~

Get the location of a team's base, being where their flag spawns and where to return captured flags to.

<a id="KaijuSolutions_Agents_Exercises_CTF_Flag_TeamOneBase3"></a>

### TeamOneBase3

~~~csharp
public static Vector3 TeamOneBase3 { get; }
~~~

The location of team one's base, being where their flag spawns and where to return captured flags to.

<a id="KaijuSolutions_Agents_Exercises_CTF_Flag_TeamOneBase"></a>

### TeamOneBase

~~~csharp
public static Vector2 TeamOneBase { get; }
~~~

The location of team one's base, being where their flag spawns and where to return captured flags to.

<a id="KaijuSolutions_Agents_Exercises_CTF_Flag_TeamTwoBase3"></a>

### TeamTwoBase3

~~~csharp
public static Vector3 TeamTwoBase3 { get; }
~~~

The location of team two's base, being where their flag spawns and where to return captured flags to.

<a id="KaijuSolutions_Agents_Exercises_CTF_Flag_TeamTwoBase"></a>

### TeamTwoBase

~~~csharp
public static Vector2 TeamTwoBase { get; }
~~~

The location of team two's base, being where their flag spawns and where to return captured flags to.

<a id="KaijuSolutions_Agents_Exercises_CTF_Flag_AtBase"></a>

### AtBase

~~~csharp
public static bool AtBase (bool teamOne)
~~~

If a flag is at its base.

<a id="KaijuSolutions_Agents_Exercises_CTF_Flag_TeamOneAtBase"></a>

### TeamOneAtBase

~~~csharp
public static bool TeamOneAtBase { get; }
~~~

If team one's flag is at its base.

<a id="KaijuSolutions_Agents_Exercises_CTF_Flag_TeamTwoAtBase"></a>

### TeamTwoAtBase

~~~csharp
public static bool TeamTwoAtBase { get; }
~~~

If team two's flag is at its base.

~~~csharp
public static bool AtBase (Flag flag)
~~~

If a flag is at its base.

<a id="KaijuSolutions_Agents_Exercises_CTF_Flag_BeingCarried"></a>

### BeingCarried

~~~csharp
public static bool BeingCarried (bool teamOne)
~~~

If a flag is being carried.

<a id="KaijuSolutions_Agents_Exercises_CTF_Flag_TeamOneBeingCarried"></a>

### TeamOneBeingCarried

~~~csharp
public static bool TeamOneBeingCarried { get; }
~~~

If team one's flag is being carried.

<a id="KaijuSolutions_Agents_Exercises_CTF_Flag_TeamTwoBeingCarried"></a>

### TeamTwoBeingCarried

~~~csharp
public static bool TeamTwoBeingCarried { get; }
~~~

If team two's flag is being carried.

~~~csharp
public static bool BeingCarried (Flag flag)
~~~

If a flag is being carried.

<a id="KaijuSolutions_Agents_Exercises_CTF_Flag_Carrier"></a>

### Carrier

~~~csharp
public static Trooper Carrier (bool teamOne)
~~~

The Trooper which is carrying a flag.

<a id="KaijuSolutions_Agents_Exercises_CTF_Flag_TeamOneCarrier"></a>

### TeamOneCarrier

~~~csharp
public static Trooper TeamOneCarrier { get; }
~~~

The Trooper carrying team one's flag.

<a id="KaijuSolutions_Agents_Exercises_CTF_Flag_TeamTwoCarrier"></a>

### TeamTwoCarrier

~~~csharp
public static Trooper TeamTwoCarrier { get; }
~~~

The Trooper carrying team two's flag.

<a id="KaijuSolutions_Agents_Exercises_CTF_Flag_DistanceToBase"></a>

### DistanceToBase

~~~csharp
public static float DistanceToBase (bool teamOne)
~~~

The distance of a team's flag to its base.

<a id="KaijuSolutions_Agents_Exercises_CTF_Flag_TeamOneDistanceToBase"></a>

### TeamOneDistanceToBase

~~~csharp
public static float TeamOneDistanceToBase { get; }
~~~

The distance of team one's flag to its base.

<a id="KaijuSolutions_Agents_Exercises_CTF_Flag_TeamTwoDistanceToBase"></a>

### TeamTwoDistanceToBase

~~~csharp
public static float TeamTwoDistanceToBase { get; }
~~~

The distance of team two's flag to its base.

~~~csharp
public static float DistanceToBase (Flag flag)
~~~

The distance of a flag to its base.

~~~csharp
public static Trooper Carrier (Flag flag)
~~~

The Trooper which is carrying a flag.

<a id="KaijuSolutions_Agents_Exercises_CTF_Flag_Flags"></a>

### Flags

~~~csharp
public static IReadOnlyCollection<Flag> Flags { get; }
~~~

Both flags for easy access.

<a id="KaijuSolutions_Agents_Exercises_CTF_Flag_TeamOneFlag"></a>

### TeamOneFlag

~~~csharp
public static Flag TeamOneFlag
~~~

Team one's flag.

<a id="KaijuSolutions_Agents_Exercises_CTF_Flag_TeamTwoFlag"></a>

### TeamTwoFlag

~~~csharp
public static Flag TeamTwoFlag
~~~

Team two's flag.

<a id="KaijuSolutions_Agents_Exercises_CTF_Flag_TeamOne"></a>

### TeamOne

~~~csharp
public bool TeamOne { get; private set; }
~~~

If this is team one's flag.

<a id="KaijuSolutions_Agents_Exercises_CTF_Flag_Interact"></a>

### Interact

~~~csharp
public override bool Interact ([NotNull] Trooper trooper)
~~~

What to do when interacted with.

<a id="KaijuSolutions_Agents_Exercises_CTF_Flag_Return"></a>

### Return

~~~csharp
public void Return ()
~~~

Return the flag to its base.

<a id="KaijuSolutions_Agents_Exercises_CTF_Flag_Drop"></a>

### Drop

~~~csharp
public void Drop ()
~~~

Drop this flag.

<a id="KaijuSolutions_Agents_Exercises_CTF_Flag_ToString"></a>

### ToString

~~~csharp
public override string ToString ()
~~~

Get a description of the object.
