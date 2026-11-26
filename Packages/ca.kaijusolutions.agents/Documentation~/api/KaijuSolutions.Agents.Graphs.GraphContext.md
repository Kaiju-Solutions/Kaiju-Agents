# GraphContext

~~~csharp
public sealed class GraphContext : IReadOnlyGraphContext
~~~

[Package source](../../Runtime/Graphs/GraphExecution.cs)

<a id="KaijuSolutions_Agents_Graphs_GraphContext_Execution"></a>

### Execution

~~~csharp
public GraphExecution Execution { get; }
~~~

<a id="KaijuSolutions_Agents_Graphs_GraphContext_Entity"></a>

### Entity

~~~csharp
public Entity Entity { get; }
~~~

<a id="KaijuSolutions_Agents_Graphs_GraphContext_World"></a>

### World

~~~csharp
public World World { get; }
~~~

<a id="KaijuSolutions_Agents_Graphs_GraphContext_IsActive"></a>

### IsActive

~~~csharp
public bool IsActive { get; }
~~~

<a id="KaijuSolutions_Agents_Graphs_GraphContext_Signal"></a>

### Signal

~~~csharp
public void Signal (string name)
~~~

<a id="KaijuSolutions_Agents_Graphs_GraphContext_Get"></a>

### Get

~~~csharp
public GraphValue Get (string key)
~~~

<a id="KaijuSolutions_Agents_Graphs_GraphContext_TrySet"></a>

### TrySet

~~~csharp
public bool TrySet (string key, GraphValue value)
~~~

<a id="KaijuSolutions_Agents_Graphs_GraphContext_Set"></a>

### Set

~~~csharp
public void Set (string key, GraphValue value)
~~~
