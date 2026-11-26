# KaijuGraphRunner

~~~csharp
public sealed class KaijuGraphRunner : MonoBehaviour
~~~

[Package source](../../Runtime/Graphs/KaijuGraphRunner.cs)

<a id="KaijuSolutions_Agents_Graphs_KaijuGraphRunner_Graph"></a>

### Graph

~~~csharp
public KaijuGraph Graph { get; set; }
~~~

<a id="KaijuSolutions_Agents_Graphs_KaijuGraphRunner_Execution"></a>

### Execution

~~~csharp
public GraphExecution Execution { get; private set; }
~~~

<a id="KaijuSolutions_Agents_Graphs_KaijuGraphRunner_TryStart"></a>

### TryStart

~~~csharp
public bool TryStart (KaijuGraph behavior, out GraphExecution execution, IReadOnlyDictionary<string, GraphValue> inputs = null)
~~~
