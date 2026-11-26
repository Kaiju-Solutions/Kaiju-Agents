# KaijuCliPlaceWall

Pipeline tool to place a wall in the scene. This is based on a box collider. Walls are set to be static by default will have a NavMeshObstacle component attached to them. The NavMeshObstacle will be set to carve.

~~~csharp
public static class KaijuCliPlaceWall
~~~

[Package source](../../Editor/Pipeline/KaijuCliPlaceWall.cs)

<a id="KaijuSolutions_Agents_Pipeline_Editor_KaijuCliPlaceWall_Run"></a>

### Run

~~~csharp
public static string Run ([CliArg("options", "JSON object with name, position {x,y} or worldPosition {x,y,z}, scale {x,y,z}, color {r,g,b,a}.")] string options = "{}")
~~~

- [Parameters](KaijuSolutions.Agents.Pipeline.Editor.KaijuCliPlaceWall.Parameters.md)
