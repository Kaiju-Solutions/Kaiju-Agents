# Parameters

Placing floor parameters for Pipeline interactions.

~~~csharp
public sealed class Parameters
~~~

[Package source](../../Editor/Pipeline/KaijuCliPlaceFloor.cs)

<a id="KaijuSolutions_Agents_Pipeline_Editor_KaijuCliPlaceFloor_Parameters_position"></a>

### position

~~~csharp
public Vector2 position
~~~

The position to spawn the floor at, corresponding to X and Z coordinates, as all floors are placed at Y of zero.

<a id="KaijuSolutions_Agents_Pipeline_Editor_KaijuCliPlaceFloor_Parameters_worldPosition"></a>

### worldPosition

~~~csharp
public Vector3? worldPosition
~~~

<a id="KaijuSolutions_Agents_Pipeline_Editor_KaijuCliPlaceFloor_Parameters_scale"></a>

### scale

~~~csharp
public float scale
~~~

What size to make the floor. The scale is set uniform across all three axes.

<a id="KaijuSolutions_Agents_Pipeline_Editor_KaijuCliPlaceFloor_Parameters_name"></a>

### name

~~~csharp
public string name
~~~

What to name the floor.

<a id="KaijuSolutions_Agents_Pipeline_Editor_KaijuCliPlaceFloor_Parameters_outerWalls"></a>

### outerWalls

~~~csharp
public bool outerWalls
~~~

If outer walls surrounding the floor should be added. If enabled, walls of a height of two will automatically be placed at the borders of the floor space. The walls are properly placed outside to not take away from the floor space itself.
