# KaijuAgentsMatcher

Helper to allow for matching and comparing objects.

~~~csharp
public class KaijuAgentsMatcher
~~~

[Package source](../../Runtime/KaijuAgentsMatcher.cs)

<a id="KaijuSolutions_Agents_KaijuAgentsMatcher_Match"></a>

### Match

~~~csharp
public string Match { get; set; }
~~~

The string the match against.

<a id="KaijuSolutions_Agents_KaijuAgentsMatcher_mode"></a>

### mode

~~~csharp
public KaijuAgentsMatcherMode mode
~~~

The mode for how to compare the match value.

<a id="KaijuSolutions_Agents_KaijuAgentsMatcher_KaijuAgentsMatcher"></a>

### KaijuAgentsMatcher

~~~csharp
public KaijuAgentsMatcher (string match = "", KaijuAgentsMatcherMode mode = KaijuAgentsMatcherMode.Equal)
~~~

Create a matcher.

<a id="KaijuSolutions_Agents_KaijuAgentsMatcher_Matched"></a>

### Matched

~~~csharp
public bool Matched ([NotNull] string value)
~~~

Get if this is a match.

<a id="KaijuSolutions_Agents_KaijuAgentsMatcher_ToString"></a>

### ToString

~~~csharp
public override string ToString ()
~~~

Get a description of the object.

~~~csharp
public static implicit operator string ([NotNull] KaijuAgentsMatcher m)
~~~

Implicit conversion to a string from the Match.

~~~csharp
public static implicit operator KaijuAgentsMatcherMode ([NotNull] KaijuAgentsMatcher m)
~~~

Implicit conversion to a KaijuAgentsMatcherMode from the mode.

~~~csharp
public static implicit operator KaijuAgentsMatcherMode? ([NotNull] KaijuAgentsMatcher m)
~~~

Implicit conversion to a nullable KaijuAgentsMatcherMode from the mode.

- [KaijuAgentsMatcherMode](KaijuSolutions.Agents.KaijuAgentsMatcher.KaijuAgentsMatcherMode.md)
