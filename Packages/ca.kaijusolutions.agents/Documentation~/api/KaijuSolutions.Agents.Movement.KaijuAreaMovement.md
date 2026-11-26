# KaijuAreaMovement

KaijuSolutions.Agents.Movement.KaijuMovement which looks for handling other KaijuSolutions.Agents.KaijuAgents in a given area.

~~~csharp
public abstract class KaijuAreaMovement : KaijuMovement
~~~

[Package source](../../Runtime/Movement/KaijuAreaMovement.cs)

<a id="KaijuSolutions_Agents_Movement_KaijuAreaMovement_Distance"></a>

### Distance

~~~csharp
public float Distance { get; set; }
~~~

The distance to interact with other KaijuSolutions.Agents.KaijuAgents from.

<a id="KaijuSolutions_Agents_Movement_KaijuAreaMovement_Identifiers"></a>

### Identifiers

~~~csharp
public readonly HashSet<uint> Identifiers
~~~

What types of KaijuSolutions.Agents.KaijuAgents to avoid.

<a id="KaijuSolutions_Agents_Movement_KaijuAreaMovement_ClearIdentifiers"></a>

### ClearIdentifiers

~~~csharp
public void ClearIdentifiers ()
~~~

Clear all identifiers of KaijuSolutions.Agents.KaijuAgents to interact with.

<a id="KaijuSolutions_Agents_Movement_KaijuAreaMovement_SetIdentifier"></a>

### SetIdentifier

~~~csharp
public void SetIdentifier (uint identifier)
~~~

Set the identifier of KaijuSolutions.Agents.KaijuAgents to interact with.

<a id="KaijuSolutions_Agents_Movement_KaijuAreaMovement_SetIdentifiers"></a>

### SetIdentifiers

~~~csharp
public void SetIdentifiers ([NotNull] ICollection<uint> identifiers)
~~~

Set the identifier of KaijuSolutions.Agents.KaijuAgents to interact with.

<a id="KaijuSolutions_Agents_Movement_KaijuAreaMovement_AddIdentifier"></a>

### AddIdentifier

~~~csharp
public bool AddIdentifier (uint identifier)
~~~

Add an identifier for KaijuSolutions.Agents.KaijuAgents to interact with.

<a id="KaijuSolutions_Agents_Movement_KaijuAreaMovement_AddIdentifiers"></a>

### AddIdentifiers

~~~csharp
public bool AddIdentifiers ([NotNull] ICollection<uint> identifiers)
~~~

Add identifiers for KaijuSolutions.Agents.KaijuAgents to interact with.

<a id="KaijuSolutions_Agents_Movement_KaijuAreaMovement_RemoveIdentifier"></a>

### RemoveIdentifier

~~~csharp
public bool RemoveIdentifier (uint identifier)
~~~

Remove an identifier for KaijuSolutions.Agents.KaijuAgents to interact with.

<a id="KaijuSolutions_Agents_Movement_KaijuAreaMovement_RemoveIdentifiers"></a>

### RemoveIdentifiers

~~~csharp
public bool RemoveIdentifiers ([NotNull] ICollection<uint> identifiers)
~~~

Remove identifiers for KaijuSolutions.Agents.KaijuAgents to interact with.

<a id="KaijuSolutions_Agents_Movement_KaijuAreaMovement_KaijuAreaMovement"></a>

### KaijuAreaMovement

~~~csharp
public KaijuAreaMovement (KaijuAgent agent, float distance = 10, ICollection<uint> identifiers = null, float weight = DefaultWeight)
~~~

Get an area movement.

<a id="KaijuSolutions_Agents_Movement_KaijuAreaMovement_Initialize"></a>

### Initialize

~~~csharp
protected void Initialize (KaijuAgent agent, float distance = 10, ICollection<uint> identifiers = null, float weight = DefaultWeight)
~~~

Initialize the KaijuSolutions.Agents.Movement.KaijuMovement.

<a id="KaijuSolutions_Agents_Movement_KaijuAreaMovement_Reset"></a>

### Reset

~~~csharp
protected override void Reset ()
~~~

Perform any needed reset operations.

<a id="KaijuSolutions_Agents_Movement_KaijuAreaMovement_EditorRenderVisualizations"></a>

### EditorRenderVisualizations

~~~csharp
protected override void EditorRenderVisualizations (Vector3 position)
~~~

Render the visualization of the KaijuSolutions.Agents.Movement.KaijuMovement. The position of the KaijuSolutions.Agents.Movement.KaijuMovement.Agent.

<a id="KaijuSolutions_Agents_Movement_KaijuAreaMovement_ToString"></a>

### ToString

~~~csharp
public override string ToString ()
~~~

Get a description of the object.
