# Parameters

Placing wall parameters for Pipeline interactions.

~~~csharp
public sealed class Parameters
~~~

[Package source](../../Editor/Pipeline/KaijuCliPlaceWall.cs)

<a id="KaijuSolutions_Agents_Pipeline_Editor_KaijuCliPlaceWall_Parameters_position"></a>

### position

~~~csharp
public Vector2 position
~~~

The position to spawn the wall at, corresponding to X and Z coordinates, as all walls have their base at a Y of zero.

<a id="KaijuSolutions_Agents_Pipeline_Editor_KaijuCliPlaceWall_Parameters_worldPosition"></a>

### worldPosition

~~~csharp
public Vector3? worldPosition
~~~

<a id="KaijuSolutions_Agents_Pipeline_Editor_KaijuCliPlaceWall_Parameters_scale"></a>

### scale

~~~csharp
public Vector3 scale
~~~

What size to make the wall. Note that this will automatically ensure the vertical height is representative as starting from zero along the Y axis, meaning for instance a wall with a height of two has its bottom at zero and top at two. Note that agents have a height of two, so ensure at least this if you want to avoid agents seeing over a wall with certain sensor arrangements.

<a id="KaijuSolutions_Agents_Pipeline_Editor_KaijuCliPlaceWall_Parameters_name"></a>

### name

~~~csharp
public string name
~~~

What to name the wall.

<a id="KaijuSolutions_Agents_Pipeline_Editor_KaijuCliPlaceWall_Parameters_color"></a>

### color

~~~csharp
public Color color
~~~

What color to make the wall, defaulting to black.
