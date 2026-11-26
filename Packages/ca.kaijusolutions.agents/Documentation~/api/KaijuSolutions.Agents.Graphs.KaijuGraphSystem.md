# KaijuGraphSystem

~~~csharp
public partial class KaijuGraphSystem : SystemBase
~~~

[Package source](../../Runtime/Graphs/KaijuGraphSystem.cs)

<a id="KaijuSolutions_Agents_Graphs_KaijuGraphSystem_PlannerExpansionsPerTick"></a>

### PlannerExpansionsPerTick

~~~csharp
public int PlannerExpansionsPerTick { get; set; }
~~~

<a id="KaijuSolutions_Agents_Graphs_KaijuGraphSystem_Start"></a>

### Start

~~~csharp
public GraphExecution Start (Entity entity, KaijuGraph graph, GraphServices services = null, IReadOnlyDictionary<string, GraphValue> inputs = null)
~~~

<a id="KaijuSolutions_Agents_Graphs_KaijuGraphSystem_TryGetExecution"></a>

### TryGetExecution

~~~csharp
public bool TryGetExecution (Entity entity, out GraphExecution execution)
~~~

<a id="KaijuSolutions_Agents_Graphs_KaijuGraphSystem_OnUpdate"></a>

### OnUpdate

~~~csharp
protected override void OnUpdate ()
~~~

<a id="KaijuSolutions_Agents_Graphs_KaijuGraphSystem_OnDestroy"></a>

### OnDestroy

~~~csharp
protected override void OnDestroy ()
~~~
