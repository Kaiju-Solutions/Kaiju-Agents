# KaijuAttackActuator

Base KaijuSolutions.Agents.Actuators.KaijuActuator for attacking other objects. This will perform a raycast in the direction of its forward.

~~~csharp
public abstract class KaijuAttackActuator : KaijuActuator
~~~

[Package source](../../Runtime/Actuators/KaijuAttackActuator.cs)

<a id="KaijuSolutions_Agents_Actuators_KaijuAttackActuator_Charge"></a>

### Charge

~~~csharp
public float Charge { get; set; }
~~~

The time it takes to charge the attack in seconds before it is performed.

<a id="KaijuSolutions_Agents_Actuators_KaijuAttackActuator_OnCooldown"></a>

### OnCooldown

~~~csharp
public bool OnCooldown { get; }
~~~

If this attack actuator is currently cooling down.

<a id="KaijuSolutions_Agents_Actuators_KaijuAttackActuator_Cooldown"></a>

### Cooldown

~~~csharp
public float Cooldown { get; set; }
~~~

The time it takes to cooldown after the attack in seconds before it can be performed again.

<a id="KaijuSolutions_Agents_Actuators_KaijuAttackActuator_Range"></a>

### Range

~~~csharp
public float Range { get; set; }
~~~

The range of the attack.

<a id="KaijuSolutions_Agents_Actuators_KaijuAttackActuator_mask"></a>

### mask

~~~csharp
public LayerMask mask
~~~

The layers to use for ray casting.

<a id="KaijuSolutions_Agents_Actuators_KaijuAttackActuator_triggers"></a>

### triggers

~~~csharp
public QueryTriggerInteraction triggers
~~~

How string-pulling should consider triggers.

<a id="KaijuSolutions_Agents_Actuators_KaijuAttackActuator_checkParents"></a>

### checkParents

~~~csharp
public bool checkParents
~~~

Often, a child collider may be hit. This will continue to perform the HandleHit method against all parent objects to handle this case.

<a id="KaijuSolutions_Agents_Actuators_KaijuAttackActuator_lineRenderer"></a>

### lineRenderer

~~~csharp
protected LineRenderer lineRenderer
~~~

The line renderer for visualizing the attacks.

<a id="KaijuSolutions_Agents_Actuators_KaijuAttackActuator_Visible"></a>

### Visible

~~~csharp
public float Visible { get; set; }
~~~

How long the lineRenderer should be visible in seconds.

<a id="KaijuSolutions_Agents_Actuators_KaijuAttackActuator_LastTarget"></a>

### LastTarget

~~~csharp
public Transform LastTarget { get; private set; }
~~~

The last object which was hit. Note if currently charging an attack, this will still be the previously hit target.

<a id="KaijuSolutions_Agents_Actuators_KaijuAttackActuator_LastPoint"></a>

### LastPoint

~~~csharp
public Vector3? LastPoint { get; private set; }
~~~

The last point which was hit. Note if currently charging an attack, this will still be the previously hit target.

<a id="KaijuSolutions_Agents_Actuators_KaijuAttackActuator_Run"></a>

### Run

~~~csharp
protected override KaijuActuatorState Run ()
~~~

Run the KaijuSolutions.Agents.Actuators.KaijuActuator.

<a id="KaijuSolutions_Agents_Actuators_KaijuAttackActuator_Tick"></a>

### Tick

~~~csharp
protected override void Tick (float delta)
~~~

Frame-rate independent MonoBehaviour.FixedUpdate message for physics calculations.

<a id="KaijuSolutions_Agents_Actuators_KaijuAttackActuator_PreConditions"></a>

### PreConditions

~~~csharp
protected virtual bool PreConditions ()
~~~

Any conditions which must be passed to begin running the actuator. This does not need to account for the Charge or Cooldown.

<a id="KaijuSolutions_Agents_Actuators_KaijuAttackActuator_PostActions"></a>

### PostActions

~~~csharp
protected virtual void PostActions (bool success)
~~~

Any final actions to perform after the actuator has performed.

<a id="KaijuSolutions_Agents_Actuators_KaijuAttackActuator_HandleHit"></a>

### HandleHit

~~~csharp
protected abstract bool HandleHit (RaycastHit hit, [NotNull] Transform t)
~~~

Handle the hit logic.

<a id="KaijuSolutions_Agents_Actuators_KaijuAttackActuator_Cleanup"></a>

### Cleanup

~~~csharp
protected override void Cleanup ()
~~~

Perform any needed resetting of the KaijuSolutions.Agents.Actuators.KaijuActuator.

<a id="KaijuSolutions_Agents_Actuators_KaijuAttackActuator_OnEnable"></a>

### OnEnable

~~~csharp
protected override void OnEnable ()
~~~

This function is called when the object becomes enabled and active.

<a id="KaijuSolutions_Agents_Actuators_KaijuAttackActuator_OnDisable"></a>

### OnDisable

~~~csharp
protected override void OnDisable ()
~~~

This function is called when the behaviour becomes disabled.

<a id="KaijuSolutions_Agents_Actuators_KaijuAttackActuator_ToString"></a>

### ToString

~~~csharp
public override string ToString ()
~~~

Get a description of the object.

~~~csharp
public static implicit operator KaijuAttackActuator ([NotNull] GameObject o)
~~~

Implicit conversion from a GameObject.

~~~csharp
public static implicit operator KaijuAttackActuator ([NotNull] Transform t)
~~~

Implicit conversion from a transform.

~~~csharp
public static implicit operator KaijuAgent ([NotNull] KaijuAttackActuator s)
~~~

Implicit conversion to a KaijuSolutions.Agents.KaijuAgent.
