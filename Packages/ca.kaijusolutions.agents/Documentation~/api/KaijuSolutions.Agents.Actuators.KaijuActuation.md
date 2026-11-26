# KaijuActuation

Write Requested to begin or stop an actuator. Running and Result report its last step.

~~~csharp
public struct KaijuActuation : IComponentData
~~~

[Package source](../../Runtime/Actuators/KaijuActuator.cs)

<a id="KaijuSolutions_Agents_Actuators_KaijuActuation_Agent"></a>

### Agent

~~~csharp
public Entity Agent
~~~

<a id="KaijuSolutions_Agents_Actuators_KaijuActuation_Requested"></a>

### Requested

~~~csharp
public bool Requested
~~~

<a id="KaijuSolutions_Agents_Actuators_KaijuActuation_Running"></a>

### Running

~~~csharp
public bool Running
~~~

<a id="KaijuSolutions_Agents_Actuators_KaijuActuation_Result"></a>

### Result

~~~csharp
public KaijuActuatorState Result
~~~
