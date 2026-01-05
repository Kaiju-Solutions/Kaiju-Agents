# Components

Kaiju Agents works by breaking agents apart into several components being:

1. The [agents](https://agents.kaijusolutions.ca/manual/agents.md "Agents") themselves.
2. [Sensors](https://agents.kaijusolutions.ca/manual/sensors.md "Sensors") to read the environment.
3. [Actuators](https://agents.kaijusolutions.ca/manual/sensors.md "Sensors") to interact with the environment.

All of these components have a multitude of [C# events](https://learn.microsoft.com/dotnet/standard/events "C# Events") you can listen to for designing behaviours. For your convenience, [controllers abstract classes](https://agents.kaijusolutions.ca/manual/agents.md "Controllers") have been made which automatically listen to all of these events. This allows for easily extending from [controller](https://agents.kaijusolutions.ca/manual/agents.md "Controllers") and overriding the methods for the callbacks you are interested in, allowing you to listen to the [C# events](https://learn.microsoft.com/dotnet/standard/events "C# Events") you are interested in without worrying about bindings.

All scenes will also have an [agent manager](https://agents.kaijusolutions.ca/manual/manager.md "Agent Manager") which is automatically added to the scene as needed. This is a [singleton](https://en.wikipedia.org/wiki/Singleton_pattern "Singleton Pattern") meaning only one instance ever exists.

If you are looking to create a basic script inheriting from [`MonoBehaviour`](https://docs.unity3d.com/ScriptReference/MonoBehaviour.html "MonoBehaviour"), you may consider inheriting from the [`KaijuBehaviour` class](https://agents.kaijusolutions.ca/api/KaijuSolutions.Agents.KaijuBehaviour.html "KaijuBehaviour") instead. [KaijuBehaviour class](https://agents.kaijusolutions.ca/api/KaijuSolutions.Agents.KaijuBehaviour.html "KaijuBehaviour") itself inherits from [`MonoBehaviour`](https://docs.unity3d.com/ScriptReference/MonoBehaviour.html "MonoBehaviour") and has many additioal properties to speed up your development.