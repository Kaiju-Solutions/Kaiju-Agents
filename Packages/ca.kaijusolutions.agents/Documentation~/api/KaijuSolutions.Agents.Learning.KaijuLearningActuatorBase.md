# KaijuLearningActuatorBase

Base class for integrating all actuators with ML-Agents.

~~~csharp
public abstract class KaijuLearningActuatorBase : ActuatorComponent, IActuator
~~~

[Package source](../../Runtime/Learning/KaijuLearningActuatorBase.cs)

<a id="KaijuSolutions_Agents_Learning_KaijuLearningActuatorBase_OnActionReceived"></a>

### OnActionReceived

~~~csharp
public abstract void OnActionReceived (ActionBuffers actionBuffers)
~~~

Method called in order to allow object to execute actions based on the actionBuffers contents. The structure of the contents in the actionBuffers are defined by the action spec.

<a id="KaijuSolutions_Agents_Learning_KaijuLearningActuatorBase_WriteDiscreteActionMask"></a>

### WriteDiscreteActionMask

~~~csharp
public abstract void WriteDiscreteActionMask (IDiscreteActionMask actionMask)
~~~

Implement to modify the masks for discrete actions. When using discrete actions, the agent will not perform the masked action.

<a id="KaijuSolutions_Agents_Learning_KaijuLearningActuatorBase_Heuristic"></a>

### Heuristic

~~~csharp
public abstract void Heuristic (in ActionBuffers actionBuffersOut)
~~~

Method called on objects which are expected to fill out the actionBuffersOut data structure. Object that implement this interface should be careful to be consistent in the placement of their actions in the actionBuffersOut data structure.

<a id="KaijuSolutions_Agents_Learning_KaijuLearningActuatorBase_ResetData"></a>

### ResetData

~~~csharp
public virtual void ResetData ()
~~~

Resets the internal state of the actuator. This is called at the end of an Agent's episode. Most implementations can leave this empty.

<a id="KaijuSolutions_Agents_Learning_KaijuLearningActuatorBase_CreateActuators"></a>

### CreateActuators

~~~csharp
public override IActuator[] CreateActuators ()
~~~

<a id="KaijuSolutions_Agents_Learning_KaijuLearningActuatorBase_Name"></a>

### Name

~~~csharp
public string Name { get; }
~~~

Gets the name of this IActuator which will be used to sort it.
