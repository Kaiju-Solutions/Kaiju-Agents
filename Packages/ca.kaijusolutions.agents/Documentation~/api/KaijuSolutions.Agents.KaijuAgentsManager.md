# KaijuAgentsManager

Manager KaijuSolutions.Agents.KaijuAgents.

~~~csharp
public class KaijuAgentsManager : KaijuBehaviour
~~~

[Package source](../../Runtime/KaijuAgentsManager.cs)

<a id="KaijuSolutions_Agents_KaijuAgentsManager_Instance"></a>

### Instance

~~~csharp
public static KaijuAgentsManager Instance { get; }
~~~

The singleton manager instance.

<a id="KaijuSolutions_Agents_KaijuAgentsManager_Agents"></a>

### Agents

~~~csharp
public static IReadOnlyCollection<KaijuAgent> Agents { get; }
~~~

<a id="KaijuSolutions_Agents_KaijuAgentsManager_AgentsCount"></a>

### AgentsCount

~~~csharp
public static int AgentsCount { get; }
~~~

<a id="KaijuSolutions_Agents_KaijuAgentsManager_EditorLabel"></a>

### EditorLabel

~~~csharp
public static void EditorLabel (Vector3 position, [NotNull] string text, Color color)
~~~

Add a label of text in the scene view in the editor.

<a id="KaijuSolutions_Agents_KaijuAgentsManager_EditorLabelOffset"></a>

### EditorLabelOffset

~~~csharp
public static float EditorLabelOffset { get; set; }
~~~

The offset for label placement in the editor.

<a id="KaijuSolutions_Agents_KaijuAgentsManager_EditorResetLabelOffset"></a>

### EditorResetLabelOffset

~~~csharp
public static void EditorResetLabelOffset ()
~~~

Reset the offset for label placement in the editor.

<a id="KaijuSolutions_Agents_KaijuAgentsManager_EditorAgentColor"></a>

### EditorAgentColor

~~~csharp
public static Color EditorAgentColor { get; set; }
~~~

What color KaijuSolutions.Agents.KaijuAgent visualizations should be in the editor.

<a id="KaijuSolutions_Agents_KaijuAgentsManager_EditorResetAgentColor"></a>

### EditorResetAgentColor

~~~csharp
public static void EditorResetAgentColor ()
~~~

Reset the KaijuSolutions.Agents.KaijuAgent color in the editor.

<a id="KaijuSolutions_Agents_KaijuAgentsManager_EditorLoadColor"></a>

### EditorLoadColor

~~~csharp
public static Color EditorLoadColor ([NotNull] string key, Color fallback)
~~~

Load a color from preferences in the editor.

<a id="KaijuSolutions_Agents_KaijuAgentsManager_EditorSaveColor"></a>

### EditorSaveColor

~~~csharp
public static void EditorSaveColor ([NotNull] string key, Color color)
~~~

Save a color to preferences in the editor.

<a id="KaijuSolutions_Agents_KaijuAgentsManager_EditorResetColor"></a>

### EditorResetColor

~~~csharp
public static void EditorResetColor ([NotNull] string key)
~~~

Reset a color to preferences in the editor.

<a id="KaijuSolutions_Agents_KaijuAgentsManager_Register"></a>

### Register

~~~csharp
public static void Register (KaijuAgent agent)
~~~

Register an KaijuSolutions.Agents.KaijuAgent for movement.

<a id="KaijuSolutions_Agents_KaijuAgentsManager_Unregister"></a>

### Unregister

~~~csharp
public static void Unregister (KaijuAgent agent, bool cache = true)
~~~

Unregister an KaijuSolutions.Agents.KaijuAgent for movement.

<a id="KaijuSolutions_Agents_KaijuAgentsManager_FindNearby"></a>

### FindNearby

~~~csharp
public static int FindNearby (Vector3 origin, float radius, List<KaijuAgent> results, bool spherical = false)
~~~

Fill a caller-owned list with registered agents within the XZ or XYZ radius.

<a id="KaijuSolutions_Agents_KaijuAgentsManager_GetCached"></a>

### GetCached

~~~csharp
public static T GetCached <T> (ICollection<string> components = null) where T : KaijuAgent
~~~

Get a cached KaijuSolutions.Agents.KaijuAgent to spawn.

<a id="KaijuSolutions_Agents_KaijuAgentsManager_AddIdentifier"></a>

### AddIdentifier

~~~csharp
public static void AddIdentifier (KaijuAgent agent, uint identifier)
~~~

Add an identifier to an KaijuSolutions.Agents.KaijuAgent. There is no use for manually calling this.

<a id="KaijuSolutions_Agents_KaijuAgentsManager_RemoveIdentifier"></a>

### RemoveIdentifier

~~~csharp
public static void RemoveIdentifier (KaijuAgent agent, uint identifier)
~~~

Remove an identifier from an KaijuSolutions.Agents.KaijuAgent. There is no use for manually calling this.

<a id="KaijuSolutions_Agents_KaijuAgentsManager_IdentifiedAgents"></a>

### IdentifiedAgents

~~~csharp
public static IReadOnlyCollection<KaijuAgent> IdentifiedAgents (uint identifier)
~~~

Get all KaijuSolutions.Agents.KaijuAgents with a given identifier.

~~~csharp
public static void IdentifiedAgents ([NotNull] ICollection<KaijuAgent> identified, [NotNull] IEnumerable<uint> identifiers)
~~~

Get all KaijuSolutions.Agents.KaijuAgents which have any of the given identifiers. The KaijuSolutions.Agents.KaijuAgents are added to the identified parameter.

~~~csharp
public static HashSet<KaijuAgent> IdentifiedAgents ([NotNull] IEnumerable<uint> identifiers)
~~~

Get all KaijuSolutions.Agents.KaijuAgents which have any of the given identifiers.

<a id="KaijuSolutions_Agents_KaijuAgentsManager_EditorValidateIdentifiers"></a>

### EditorValidateIdentifiers

~~~csharp
public static void EditorValidateIdentifiers (KaijuAgent agent)
~~~

Validate the identifiers of an KaijuSolutions.Agents.KaijuAgent in the editor. There is no use for manually calling this.

<a id="KaijuSolutions_Agents_KaijuAgentsManager_ToString"></a>

### ToString

~~~csharp
public override string ToString ()
~~~

Get a description of the object.

~~~csharp
public static implicit operator short (KaijuAgentsManager m)
~~~

Implicit conversion to a short integer based AgentsCount.

~~~csharp
public static implicit operator short? (KaijuAgentsManager m)
~~~

Implicit conversion to a nullable short integer based AgentsCount.

~~~csharp
public static implicit operator ushort (KaijuAgentsManager m)
~~~

Implicit conversion to an unsigned short integer based AgentsCount.

~~~csharp
public static implicit operator ushort? (KaijuAgentsManager m)
~~~

Implicit conversion to a nullable unsigned short integer based AgentsCount.

~~~csharp
public static implicit operator int (KaijuAgentsManager m)
~~~

Implicit conversion to an integer based AgentsCount.

~~~csharp
public static implicit operator int? (KaijuAgentsManager m)
~~~

Implicit conversion to a nullable integer based AgentsCount.

~~~csharp
public static implicit operator uint (KaijuAgentsManager m)
~~~

Implicit conversion to an unsigned integer based AgentsCount.

~~~csharp
public static implicit operator uint? (KaijuAgentsManager m)
~~~

Implicit conversion to a nullable unsigned integer based AgentsCount.

~~~csharp
public static implicit operator long (KaijuAgentsManager m)
~~~

Implicit conversion to a long integer based AgentsCount.

~~~csharp
public static implicit operator long? (KaijuAgentsManager m)
~~~

Implicit conversion to a nullable long integer based AgentsCount.

~~~csharp
public static implicit operator ulong (KaijuAgentsManager m)
~~~

Implicit conversion to an unsigned long integer based AgentsCount.

~~~csharp
public static implicit operator ulong? (KaijuAgentsManager m)
~~~

Implicit conversion to a nullable unsigned long integer based AgentsCount.
