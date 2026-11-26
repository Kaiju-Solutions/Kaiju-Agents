# KaijuSensor

Base sensor class.

~~~csharp
public abstract class KaijuSensor : KaijuBehaviour
~~~

[Package source](../../Runtime/Sensors/KaijuSensor.cs)

<a id="KaijuSolutions_Agents_Sensors_KaijuSensor_OnSense"></a>

### OnSense

~~~csharp
public event KaijuAction OnSense
~~~

Callback for when this sensor has been run.

<a id="KaijuSolutions_Agents_Sensors_KaijuSensor_OnSenseGlobal"></a>

### OnSenseGlobal

~~~csharp
public static event KaijuSensorAction OnSenseGlobal
~~~

Global callback for when this sensor has been run.

<a id="KaijuSolutions_Agents_Sensors_KaijuSensor_OnEnabled"></a>

### OnEnabled

~~~csharp
public event KaijuAction OnEnabled
~~~

Callback for when this has finishing becoming enabled.

<a id="KaijuSolutions_Agents_Sensors_KaijuSensor_OnEnabledGlobal"></a>

### OnEnabledGlobal

~~~csharp
public static event KaijuSensorAction OnEnabledGlobal
~~~

Global callback for when this has finishing becoming enabled.

<a id="KaijuSolutions_Agents_Sensors_KaijuSensor_OnDisabled"></a>

### OnDisabled

~~~csharp
public event KaijuAction OnDisabled
~~~

Callback for when this has finishing becoming disabled.

<a id="KaijuSolutions_Agents_Sensors_KaijuSensor_OnDisabledGlobal"></a>

### OnDisabledGlobal

~~~csharp
public static event KaijuSensorAction OnDisabledGlobal
~~~

Global callback for when this has finishing becoming disabled.

<a id="KaijuSolutions_Agents_Sensors_KaijuSensor_automatic"></a>

### automatic

~~~csharp
public bool automatic
~~~

If this sensor should be run automatically.

<a id="KaijuSolutions_Agents_Sensors_KaijuSensor_Agent"></a>

### Agent

~~~csharp
public KaijuAgent Agent { get; private set; }
~~~

The KaijuSolutions.Agents.KaijuAgent this sensor is assigned to.

<a id="KaijuSolutions_Agents_Sensors_KaijuSensor_OnEnable"></a>

### OnEnable

~~~csharp
protected virtual void OnEnable ()
~~~

This function is called when the object becomes enabled and active.

<a id="KaijuSolutions_Agents_Sensors_KaijuSensor_OnDisable"></a>

### OnDisable

~~~csharp
protected virtual void OnDisable ()
~~~

This function is called when the behaviour becomes disabled.

<a id="KaijuSolutions_Agents_Sensors_KaijuSensor_Sense"></a>

### Sense

~~~csharp
public void Sense ()
~~~

Run the sensor. There is no point in manually calling this.

<a id="KaijuSolutions_Agents_Sensors_KaijuSensor_Run"></a>

### Run

~~~csharp
protected abstract void Run ()
~~~

Run the sensor.

<a id="KaijuSolutions_Agents_Sensors_KaijuSensor_Cleanup"></a>

### Cleanup

~~~csharp
protected virtual void Cleanup ()
~~~

Perform any needed resetting of the sensor.

<a id="KaijuSolutions_Agents_Sensors_KaijuSensor_EditorVisualize"></a>

### EditorVisualize

~~~csharp
public virtual void EditorVisualize (Vector3 position)
~~~

Allow for visualizing in the editor. The position of the KaijuSolutions.Agents.KaijuController.Agent.

<a id="KaijuSolutions_Agents_Sensors_KaijuSensor_ToString"></a>

### ToString

~~~csharp
public override string ToString ()
~~~

Get a description of the object.

~~~csharp
public static implicit operator KaijuSensor ([NotNull] GameObject o)
~~~

Implicit conversion from a GameObject.

~~~csharp
public static implicit operator KaijuSensor ([NotNull] Transform t)
~~~

Implicit conversion from a transform.

~~~csharp
public static implicit operator KaijuAgent ([NotNull] KaijuSensor s)
~~~

Implicit conversion to a KaijuSolutions.Agents.KaijuAgent.
