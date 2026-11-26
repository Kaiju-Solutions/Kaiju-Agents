# KaijuGraphPolicy

Registers the attached ML agent as a graph action. Existing DecisionRequesters retain their schedule.

~~~csharp
public sealed class KaijuGraphPolicy : MonoBehaviour, IGraphServiceProvider
~~~

[Package source](../../Runtime/Learning/KaijuGraphPolicy.cs)

<a id="KaijuSolutions_Agents_Learning_KaijuGraphPolicy_AcceptActions"></a>

### AcceptActions

~~~csharp
public bool AcceptActions { get; }
~~~

<a id="KaijuSolutions_Agents_Learning_KaijuGraphPolicy_Register"></a>

### Register

~~~csharp
public void Register (GraphServices services)
~~~
