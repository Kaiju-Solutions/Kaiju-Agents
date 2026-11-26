# GraphCommands

~~~csharp
public static class GraphCommands
~~~

[Package source](../../Editor/Graphs/GraphCommands.cs)

<a id="KaijuSolutions_Agents_Editor_Graphs_GraphCommands_Create"></a>

### Create

~~~csharp
public static object Create ([CliArg("options", "JSON with path, family, and optional child asset path.")] string options)
~~~

<a id="KaijuSolutions_Agents_Editor_Graphs_GraphCommands_Validate"></a>

### Validate

~~~csharp
public static object Validate ([CliArg("path", "Graph asset path")] string path)
~~~

<a id="KaijuSolutions_Agents_Editor_Graphs_GraphCommands_Compile"></a>

### Compile

~~~csharp
public static object Compile ([CliArg("path", "Graph asset path")] string path)
~~~

<a id="KaijuSolutions_Agents_Editor_Graphs_GraphCommands_Run"></a>

### Run

~~~csharp
public static object Run ([CliArg("options", "JSON with path, optional inputs, ticks, delta, and signals keyed by tick.")] string options)
~~~
