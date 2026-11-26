# KaijuCliHelpers

Helper methods for Pipeline parsing.

~~~csharp
public static class KaijuCliHelpers
~~~

[Package source](../../Editor/Pipeline/KaijuCliHelpers.cs)

<a id="KaijuSolutions_Agents_Pipeline_Editor_KaijuCliHelpers_GetArray"></a>

### GetArray

~~~csharp
public static T[] GetArray <T> (JObject @params, string name)
~~~

Extract an array from the Pipeline client.

<a id="KaijuSolutions_Agents_Pipeline_Editor_KaijuCliHelpers_PlaceWall"></a>

### PlaceWall

~~~csharp
public static GameObject PlaceWall ([NotNull] KaijuCliPlaceWall.Parameters parameters)
~~~

Helper method to place a wall.
