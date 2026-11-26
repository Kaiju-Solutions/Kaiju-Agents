# Floor

Floor tile which will get dirty over time, given the chance every second of Chance. You should have a KaijuSolutions.Agents.Sensors.KaijuSensor which detects these and can determine which are clean and which are dirty via the Dirty parameter. From there, you will want to move the agent towards a dirty tile if it sensed one. Once close enough to the dirty floor tile, you will need to create a KaijuSolutions.Agents.Actuators.KaijuActuator which can call the Clean method.

~~~csharp
public class Floor : KaijuBehaviour
~~~

[Package source](../../Samples~/Exercise%201%20-%20Cleaner/Floor.cs)

<a id="KaijuSolutions_Agents_Exercises_Cleaner_Floor_Dirty"></a>

### Dirty

~~~csharp
public bool Dirty { get; private set; }
~~~

If this floor tile is dirty.

<a id="KaijuSolutions_Agents_Exercises_Cleaner_Floor_Chance"></a>

### Chance

~~~csharp
public float Chance { get; private set; }
~~~

The chance that every second this floor tile could become dirty. Note that as this is randomly calculated every fraction of a second, a value of one does not actually guarantee the tile will become dirty every second.

<a id="KaijuSolutions_Agents_Exercises_Cleaner_Floor_Clean"></a>

### Clean

~~~csharp
public void Clean ()
~~~

Clean this floor tile. Your actuator will want to call this once you are close enough to this tile.

<a id="KaijuSolutions_Agents_Exercises_Cleaner_Floor_ToString"></a>

### ToString

~~~csharp
public override string ToString ()
~~~

Get a description of the object.
