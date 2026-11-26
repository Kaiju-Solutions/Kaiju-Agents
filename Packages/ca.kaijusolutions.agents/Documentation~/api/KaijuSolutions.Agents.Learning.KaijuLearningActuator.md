# KaijuLearningActuator

Have any generic KaijuSolutions.Agents.Actuators.KaijuActuator work with ML-Agents. This has three discrete actions, being to do nothing, run the KaijuSolutions.Agents.Actuators.KaijuActuator, or cancel running it. These actions are masked accordingly. This has no Heuristic implementation, and you will need to extend this class and override for your use case.

~~~csharp
public class KaijuLearningActuator : KaijuLearningActuatorBase
~~~

[Package source](../../Runtime/Learning/KaijuLearningActuator.cs)

<a id="KaijuSolutions_Agents_Learning_KaijuLearningActuator_ActionSpec"></a>

### ActionSpec

~~~csharp
public override ActionSpec ActionSpec { get; }
~~~

The specification of the possible actions for this actuator component. This must produce the same results as the corresponding IActuator's ActionSpec.

<a id="KaijuSolutions_Agents_Learning_KaijuLearningActuator_OnActionReceived"></a>

### OnActionReceived

~~~csharp
public override void OnActionReceived (ActionBuffers actionBuffers)
~~~

Method called in order to allow object to execute actions based on the actionBuffers contents. The structure of the contents in the actionBuffers are defined by the action spec.

<a id="KaijuSolutions_Agents_Learning_KaijuLearningActuator_WriteDiscreteActionMask"></a>

### WriteDiscreteActionMask

~~~csharp
public override void WriteDiscreteActionMask (IDiscreteActionMask actionMask)
~~~

Implement to modify the masks for discrete actions. When using discrete actions, the agent will not perform the masked action.

<a id="KaijuSolutions_Agents_Learning_KaijuLearningActuator_Heuristic"></a>

### Heuristic

~~~csharp
public override void Heuristic (in ActionBuffers actionBuffersOut)
~~~

Method called on objects which are expected to fill out the actionBuffersOut data structure. Object that implement this interface should be careful to be consistent in the placement of their actions in the actionBuffersOut data structure.
