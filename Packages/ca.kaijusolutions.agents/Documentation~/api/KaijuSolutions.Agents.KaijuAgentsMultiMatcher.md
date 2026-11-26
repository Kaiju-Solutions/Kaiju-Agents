# KaijuAgentsMultiMatcher

Helper to match multiple KaijuAgentsMatcher instances together which all must succeed.

~~~csharp
public class KaijuAgentsMultiMatcher
~~~

[Package source](../../Runtime/KaijuAgentsMultiMatcher.cs)

<a id="KaijuSolutions_Agents_KaijuAgentsMultiMatcher_Matchers"></a>

### Matchers

~~~csharp
public List<KaijuAgentsMatcher> Matchers { get; set; }
~~~

KaijuAgentsMatcher instances to compare where they all must pass their condition.

<a id="KaijuSolutions_Agents_KaijuAgentsMultiMatcher_Matched"></a>

### Matched

~~~csharp
public bool Matched ([NotNull] string value)
~~~

Get if this is a match.

<a id="KaijuSolutions_Agents_KaijuAgentsMultiMatcher_ToString"></a>

### ToString

~~~csharp
public override string ToString ()
~~~

Get a description of the object.

~~~csharp
public static implicit operator string ([NotNull] KaijuAgentsMultiMatcher m)
~~~

Implicit conversion to a string.

~~~csharp
public static implicit operator short ([NotNull] KaijuAgentsMultiMatcher m)
~~~

Implicit conversion to a short integer based on the number of Matchers.

~~~csharp
public static implicit operator short? ([NotNull] KaijuAgentsMultiMatcher m)
~~~

Implicit conversion to a nullable short integer based on the number of Matchers.

~~~csharp
public static implicit operator ushort ([NotNull] KaijuAgentsMultiMatcher m)
~~~

Implicit conversion to an unsigned short integer based on the number of Matchers.

~~~csharp
public static implicit operator ushort? ([NotNull] KaijuAgentsMultiMatcher m)
~~~

Implicit conversion to a nullable unsigned short integer based on the number of Matchers.

~~~csharp
public static implicit operator int ([NotNull] KaijuAgentsMultiMatcher m)
~~~

Implicit conversion to an integer based on the number of Matchers.

~~~csharp
public static implicit operator int? ([NotNull] KaijuAgentsMultiMatcher m)
~~~

Implicit conversion to a nullable integer based on the number of Matchers.

~~~csharp
public static implicit operator uint ([NotNull] KaijuAgentsMultiMatcher m)
~~~

Implicit conversion to an unsigned integer based on the number of Matchers.

~~~csharp
public static implicit operator uint? ([NotNull] KaijuAgentsMultiMatcher m)
~~~

Implicit conversion to a nullable unsigned integer based on the number of Matchers.

~~~csharp
public static implicit operator long ([NotNull] KaijuAgentsMultiMatcher m)
~~~

Implicit conversion to a long integer based on the number of Matchers.

~~~csharp
public static implicit operator long? ([NotNull] KaijuAgentsMultiMatcher m)
~~~

Implicit conversion to a nullable long integer based on the number of Matchers.

~~~csharp
public static implicit operator ulong ([NotNull] KaijuAgentsMultiMatcher m)
~~~

Implicit conversion to an unsigned long integer based on the number of Matchers.

~~~csharp
public static implicit operator ulong? ([NotNull] KaijuAgentsMultiMatcher m)
~~~

Implicit conversion to a nullable unsigned long integer based on the number of Matchers.
