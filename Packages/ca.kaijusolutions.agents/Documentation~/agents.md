# Agents

There are four types of agents each derived from the [`KaijuAgent` class](api/KaijuSolutions.Agents.KaijuAgent.md "KaijuAgent"), with the different types defining what drives the [movement](movement.md "Movement") of the agent:

1. [Transform](api/KaijuSolutions.Agents.KaijuTransformAgent.md "Transform Agent") - Moves directly with the [transform](https://docs.unity3d.com/Manual/class-transform.html "Transform"). This agent does not collide with object or cause any collision or trigger events to be fired.
2. [Rigidbody](api/KaijuSolutions.Agents.KaijuRigidbodyAgent.md "Rigidbody Agent") - Moves respecting physics using a [rigidbody component](https://docs.unity3d.com/Manual/rigidbody-physics-section.html "Rigidbody"), allowing for the collisions and their related events to be activated by this agent.
    - **If you are unsure of which agent type to use for your use case, it is recommeneded you choose this type to start.**
3. [Character](api/KaijuSolutions.Agents.KaijuCharacterAgent.md) - Moves with a [character controller component](https://docs.unity3d.com/Manual/character-control-section.html "Character Controller"). In general, this behaves about the same as the [rigidbody agent](api/KaijuSolutions.Agents.KaijuRigidbodyAgent.md "Rigidbody Agent").
4. [Navigation](api/KaijuSolutions.Agents.KaijuNavigationAgent.md) - Moves by a [navigation mesh agent component](https://docs.unity3d.com/ScriptReference/AI.NavMeshAgent.html), and like the [transform agent](api/KaijuSolutions.Agents.KaijuTransformAgent.md "Transform Agent"), does not fire collision or trigger events.
    - **Note that _all four_ agent types can fully perform navigation and pathfinding, not just the [navigation agent](api/KaijuSolutions.Agents.KaijuNavigationAgent.md)**

Agents must be added to root-level [GameObjects](https://docs.unity3d.com/Manual/class-GameObject.html "GameObject"), and cannot be nested under other [GameObjects](https://docs.unity3d.com/Manual/class-GameObject.html "GameObject"). One agent is allowed per [GameObject](https://docs.unity3d.com/Manual/class-GameObject.html "GameObject").

## Movement

Each agent can set their speed and acceleration for performing [movements](movement.md) in addition to the look speed. This can be done via the [inspector](https://docs.unity3d.com/Manual/UsingTheInspector.html "Inspector Window") or via the [`KaijuAgent` API](api/KaijuSolutions.Agents.KaijuAgent.md "KaijuAgent").

Additionally, the [`KaijuAgent` API](api/KaijuSolutions.Agents.KaijuAgent.md "KaijuAgent") provides methods exposing how perform all the [movements](movement.md). These [movement](movement.md) methods can have their parameters explicitly passed to them. If not passed, all parameters will default to that of the [movement configuration](movement.md#configuration) assigned to the agent. If no [movement configuration](movement.md#configuration) is assigned, the values will fallback to the default values outlined in the constant defined in each [movement](movement.md) class.

## Controlling Agents

There is a lot of flexibility as to how you can add intelligent behaviour to agents! The most common method is creating a class which extends from [`MonoBehaviour`](https://docs.unity3d.com/ScriptReference/MonoBehaviour.html "MonoBehaviour") (or the extended version provided with Kaiju Agents, [`KaijuBehaviour`](api/KaijuSolutions.Agents.KaijuBehaviour.md "KaijuBehaviour") instead) and listening for callbacks, accessing properties, and calling methods from the [`KaijuAgent` API](api/KaijuSolutions.Agents.KaijuAgent.md "KaijuAgent"). As this workflow is so common, the [controller classes](controllers.md) provide starting points to do this.

## Identifiers

For easy comparing of agent types, you can set identifiers for agents, allowing for easy querying with the [manager](manager.md) as well as with the included [agents vision sensor](sensors.md#agents-vision-sensor "Agents Vision Sensor").

## Spawning and Despawning

You can either have agents already in the scene when starting the scene which can be created following the instructions in the [getting started documentation](getting-started.md#next-steps "Getting Started - Next Steps") or at runtime via the [`KaijuAgents.Spawn(KaijuAgentType, Nullable<Vector3>, Nullable<Quaternion>, Boolean, KaijuAgent, String, Nullable<Color>, Nullable<Color>, ICollection<Type>)` method](api/KaijuSolutions.Agents.KaijuAgents.md#KaijuSolutions_Agents_KaijuAgents_Spawn "KaijuAgents.Spawn(KaijuAgentType, Nullable<Vector3>, Nullable<Quaternion>, Boolean, KaijuAgent, String, Nullable<Color>, Nullable<Color>, ICollection<Type>)").

For despawning, you can destroy the agents just like any other [GameObject](https://docs.unity3d.com/Manual/class-GameObject.html "GameObject") or [component](https://docs.unity3d.com/Manual/Components.html "Component"), but the better option is to use the [`Despawn()` method](api/KaijuSolutions.Agents.KaijuAgent.md#KaijuSolutions_Agents_KaijuAgent_Despawn "KaijuAgent - Despawn"). This will keep the agent in memory and allow it to be reused by a future [`KaijuAgents.Spawn(KaijuAgentType, Nullable<Vector3>, Nullable<Quaternion>, Boolean, KaijuAgent, String, Nullable<Color>, Nullable<Color>, ICollection<Type>)`](api/KaijuSolutions.Agents.KaijuAgents.md#KaijuSolutions_Agents_KaijuAgents_Spawn "KaijuAgents.Spawn(KaijuAgentType, Nullable<Vector3>, Nullable<Quaternion>, Boolean, KaijuAgent, String, Nullable<Color>, Nullable<Color>, ICollection<Type>)") call, thus keeping garbage collection to a minimum.