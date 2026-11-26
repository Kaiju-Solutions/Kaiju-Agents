# GraphServices

~~~csharp
public sealed class GraphServices
~~~

[Package source](../../Runtime/Graphs/GraphExecution.cs)

<a id="KaijuSolutions_Agents_Graphs_GraphServices_Actions"></a>

### Actions

~~~csharp
public readonly Dictionary<string, Func<IGraphAction>> Actions
~~~

<a id="KaijuSolutions_Agents_Graphs_GraphServices_Predicates"></a>

### Predicates

~~~csharp
public readonly Dictionary<string, Func<IReadOnlyGraphContext, bool>> Predicates
~~~

<a id="KaijuSolutions_Agents_Graphs_GraphServices_Scorers"></a>

### Scorers

~~~csharp
public readonly Dictionary<string, Func<IReadOnlyGraphContext, float>> Scorers
~~~

<a id="KaijuSolutions_Agents_Graphs_GraphServices_Events"></a>

### Events

~~~csharp
public readonly Dictionary<string, Action<GraphContext>> Events
~~~

<a id="KaijuSolutions_Agents_Graphs_GraphServices_Policies"></a>

### Policies

~~~csharp
public readonly Dictionary<string, Func<IGraphAction>> Policies
~~~

<a id="KaijuSolutions_Agents_Graphs_GraphServices_RegisterAction"></a>

### RegisterAction

~~~csharp
public void RegisterAction (string key, Action<GraphContext> callback)
~~~
