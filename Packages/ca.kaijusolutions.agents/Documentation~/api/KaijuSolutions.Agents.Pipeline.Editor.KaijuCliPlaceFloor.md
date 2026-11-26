# KaijuCliPlaceFloor

Pipeline tool to place a basic floor in the scene. This is based on the default "Quad" collider, rotated properly to be a floor, and has no renderer attached to it. Floors are set to be static by default.

~~~csharp
public static class KaijuCliPlaceFloor
~~~

[Package source](../../Editor/Pipeline/KaijuCliPlaceFloor.cs)

<a id="KaijuSolutions_Agents_Pipeline_Editor_KaijuCliPlaceFloor_Run"></a>

### Run

~~~csharp
public static string Run ([CliArg("options", "JSON object with name, position {x,y} or worldPosition {x,y,z}, scale, outerWalls.")] string options = "{}")
~~~

- [Parameters](KaijuSolutions.Agents.Pipeline.Editor.KaijuCliPlaceFloor.Parameters.md)
