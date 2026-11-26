# Parameters

Creating agent prefab parameters for Pipeline interactions.

~~~csharp
public sealed class Parameters
~~~

[Package source](../../Editor/Pipeline/KaijuCliCreateAgentPrefab.cs)

<a id="KaijuSolutions_Agents_Pipeline_Editor_KaijuCliCreateAgentPrefab_Parameters_path"></a>

### path

~~~csharp
public string path
~~~

The path to save the agent prefab to.

<a id="KaijuSolutions_Agents_Pipeline_Editor_KaijuCliCreateAgentPrefab_Parameters_type"></a>

### type

~~~csharp
public string type
~~~

The type of agent to spawn.

<a id="KaijuSolutions_Agents_Pipeline_Editor_KaijuCliCreateAgentPrefab_Parameters_components"></a>

### components

~~~csharp
public string[] components
~~~

The names of additional component types to add to the agent. You do not need to include the agent's component in this, as it is handled by the type parameter. Note that these will be assigned directly to the root GameObject of the agent. Invalid components will be skipped.

<a id="KaijuSolutions_Agents_Pipeline_Editor_KaijuCliCreateAgentPrefab_Parameters_body"></a>

### body

~~~csharp
public Color body
~~~

What color to make the body of the agent.

<a id="KaijuSolutions_Agents_Pipeline_Editor_KaijuCliCreateAgentPrefab_Parameters_eyes"></a>

### eyes

~~~csharp
public Color eyes
~~~

What color to make the eyes of the agent.
