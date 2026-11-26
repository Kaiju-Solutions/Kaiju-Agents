# KaijuGraph

Shared player asset compiled by the Kaiju Graph Toolkit importers.

~~~csharp
public sealed class KaijuGraph : ScriptableObject
~~~

[Package source](../../Runtime/Graphs/KaijuGraph.cs)

<a id="KaijuSolutions_Agents_Graphs_KaijuGraph_SourceId"></a>

### SourceId

~~~csharp
public Hash128 SourceId { get; }
~~~

<a id="KaijuSolutions_Agents_Graphs_KaijuGraph_Family"></a>

### Family

~~~csharp
public GraphFamily Family { get; }
~~~

<a id="KaijuSolutions_Agents_Graphs_KaijuGraph_Entry"></a>

### Entry

~~~csharp
public int Entry { get; }
~~~

<a id="KaijuSolutions_Agents_Graphs_KaijuGraph_Variables"></a>

### Variables

~~~csharp
public IReadOnlyList<GraphVariable> Variables { get; }
~~~

<a id="KaijuSolutions_Agents_Graphs_KaijuGraph_StepCount"></a>

### StepCount

~~~csharp
public int StepCount { get; }
~~~

<a id="KaijuSolutions_Agents_Graphs_KaijuGraph_NodeLabel"></a>

### NodeLabel

~~~csharp
public string NodeLabel (Hash128 id)
~~~

<a id="KaijuSolutions_Agents_Graphs_KaijuGraph_InspectStep"></a>

### InspectStep

~~~csharp
public GraphStep InspectStep (int index)
~~~

<a id="KaijuSolutions_Agents_Graphs_KaijuGraph_Create"></a>

### Create

~~~csharp
public static KaijuGraph Create (GraphFamily family, int entry, GraphVariable[] variables, GraphStep[] steps, Hash128 sourceId = default)
~~~
