# GraphExecution

~~~csharp
public sealed class GraphExecution
~~~

[Package source](../../Runtime/Graphs/GraphExecution.cs)

<a id="KaijuSolutions_Agents_Graphs_GraphExecution_World"></a>

### World

~~~csharp
public World World { get; }
~~~

<a id="KaijuSolutions_Agents_Graphs_GraphExecution_Entity"></a>

### Entity

~~~csharp
public Entity Entity { get; }
~~~

<a id="KaijuSolutions_Agents_Graphs_GraphExecution_Services"></a>

### Services

~~~csharp
public GraphServices Services { get; }
~~~

<a id="KaijuSolutions_Agents_Graphs_GraphExecution_Context"></a>

### Context

~~~csharp
public GraphContext Context { get; }
~~~

<a id="KaijuSolutions_Agents_Graphs_GraphExecution_Result"></a>

### Result

~~~csharp
public GraphResult Result { get; private set; }
~~~

<a id="KaijuSolutions_Agents_Graphs_GraphExecution_TickNumber"></a>

### TickNumber

~~~csharp
public ulong TickNumber { get; private set; }
~~~

<a id="KaijuSolutions_Agents_Graphs_GraphExecution_Trace"></a>

### Trace

~~~csharp
public event Action<ulong, KaijuGraph, UnityEngine.Hash128, GraphResult> Trace
~~~

<a id="KaijuSolutions_Agents_Graphs_GraphExecution_TickFinished"></a>

### TickFinished

~~~csharp
public event Action<GraphExecution> TickFinished
~~~

<a id="KaijuSolutions_Agents_Graphs_GraphExecution_Decision"></a>

### Decision

~~~csharp
public event Action<ulong, KaijuGraph, UnityEngine.Hash128, string, float> Decision
~~~

<a id="KaijuSolutions_Agents_Graphs_GraphExecution_GetActiveNodes"></a>

### GetActiveNodes

~~~csharp
public void GetActiveNodes (List<UnityEngine.Hash128> destination)
~~~

<a id="KaijuSolutions_Agents_Graphs_GraphExecution_GetCallStack"></a>

### GetCallStack

~~~csharp
public void GetCallStack (List<GraphLocation> destination)
~~~

<a id="KaijuSolutions_Agents_Graphs_GraphExecution_Signal"></a>

### Signal

~~~csharp
public void Signal (string name)
~~~

<a id="KaijuSolutions_Agents_Graphs_GraphExecution_Cancel"></a>

### Cancel

~~~csharp
public void Cancel ()
~~~
