# KaijuAgents

Methods to help with KaijuSolutions.Agents.KaijuAgent creation.

~~~csharp
public static class KaijuAgents
~~~

[Package source](../../Runtime/KaijuAgents.cs)

<a id="KaijuSolutions_Agents_KaijuAgents_GetMaterial"></a>

### GetMaterial

~~~csharp
public static Material GetMaterial (Color color)
~~~

Get a material to use.

<a id="KaijuSolutions_Agents_KaijuAgents_AssignComponent"></a>

### AssignComponent

~~~csharp
public static bool AssignComponent <T> ([NotNull] this GameObject go, ref T current, bool self = true, bool children = false, bool parents = false) where T : Component
~~~

Assign a component, validating if it meets requirements.

~~~csharp
public static bool AssignComponent <T> ([NotNull] this Component c, ref T current, bool self = true, bool children = false, bool parents = false) where T : Component
~~~

Assign a component, validating if it meets requirements.

<a id="KaijuSolutions_Agents_KaijuAgents_Spawn"></a>

### Spawn

~~~csharp
public static KaijuAgent Spawn (KaijuAgentType type = KaijuAgentType.Transform, Vector3? position = null, Quaternion? orientation = null, bool cached = true, [NotNull] KaijuAgent prefab = null, string name = null, Color? body = null, Color? eyes = null, ICollection<string> components = null)
~~~

Spawn an KaijuSolutions.Agents.KaijuAgent.
