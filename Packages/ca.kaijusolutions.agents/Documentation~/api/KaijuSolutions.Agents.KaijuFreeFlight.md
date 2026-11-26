# KaijuFreeFlight

Enables XYZ steering on a Transform or Rigidbody agent.

~~~csharp
public sealed class KaijuFreeFlight : MonoBehaviour
~~~

[Package source](../../Runtime/KaijuFreeFlight.cs)

<a id="KaijuSolutions_Agents_KaijuFreeFlight_pitchToVelocity"></a>

### pitchToVelocity

~~~csharp
public bool pitchToVelocity
~~~

<a id="KaijuSolutions_Agents_KaijuFreeFlight_HasClearance"></a>

### HasClearance

~~~csharp
public bool HasClearance (Vector3 destination, float radius, LayerMask obstacles)
~~~

Check a straight flight segment for solid colliders in the supplied obstacle layers.
