# Components

Kaiju Agents works by breaking agents apart into several components being:

1. The [agents](agents.md "Agents") themselves.
2. [Sensors](sensors.md "Sensors") to read the environment.
3. [Actuators](sensors.md "Sensors") to interact with the environment.

All of these components have a multitude of [C# events](https://learn.microsoft.com/dotnet/standard/events "C# Events") you can listen to for designing behaviours. For your convenience, [controllers abstract classes](agents.md "Controllers") have been made which automatically listen to all of these events. This allows for easily extending from [controller](agents.md "Controllers") and overriding the methods for the callbacks you are interested in, allowing you to listen to the [C# events](https://learn.microsoft.com/dotnet/standard/events "C# Events") you are interested in without worrying about bindings.

The [Entities simulation](manager.md) registers agents when enabled.

If you are looking to create a basic script inheriting from [`MonoBehaviour`](https://docs.unity3d.com/ScriptReference/MonoBehaviour.html "MonoBehaviour"), you may consider inheriting from the [`KaijuBehaviour` class](api/KaijuSolutions.Agents.KaijuBehaviour.md "KaijuBehaviour") instead. [KaijuBehaviour class](api/KaijuSolutions.Agents.KaijuBehaviour.md "KaijuBehaviour") itself inherits from [`MonoBehaviour`](https://docs.unity3d.com/ScriptReference/MonoBehaviour.html "MonoBehaviour") and has many additioal properties to speed up your development.