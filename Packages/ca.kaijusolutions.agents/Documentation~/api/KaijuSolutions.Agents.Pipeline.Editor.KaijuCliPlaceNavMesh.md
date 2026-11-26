# KaijuCliPlaceNavMesh

Pipeline tool to place a NavMesh Surface into the scene. This is set to collect all GameObjects in the scene across all layers and uses physics colliders.

~~~csharp
public static class KaijuCliPlaceNavMesh
~~~

[Package source](../../Editor/Pipeline/KaijuCliPlaceNavMesh.cs)

<a id="KaijuSolutions_Agents_Pipeline_Editor_KaijuCliPlaceNavMesh_Run"></a>

### Run

~~~csharp
public static string Run ([CliArg("options", "JSON object with name, build.")] string options = "{}")
~~~

- [Parameters](KaijuSolutions.Agents.Pipeline.Editor.KaijuCliPlaceNavMesh.Parameters.md)
