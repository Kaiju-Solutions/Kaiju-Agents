# KaijuBehaviour

Base extended MonoBehaviour providing convenient helpers methods, mainly in relation to position and orientation.

~~~csharp
public abstract class KaijuBehaviour : MonoBehaviour
~~~

[Package source](../../Runtime/KaijuBehaviour.cs)

<a id="KaijuSolutions_Agents_KaijuBehaviour_OnPreSetPosition"></a>

### OnPreSetPosition

~~~csharp
public event KaijuAction OnPreSetPosition
~~~

Callback for before the position has been set.

<a id="KaijuSolutions_Agents_KaijuBehaviour_OnPreSetPositionGlobal"></a>

### OnPreSetPositionGlobal

~~~csharp
public static event KaijuBehaviourAction OnPreSetPositionGlobal
~~~

Global callback for before the position has been set.

<a id="KaijuSolutions_Agents_KaijuBehaviour_OnSetPosition"></a>

### OnSetPosition

~~~csharp
public event KaijuAction OnSetPosition
~~~

Callback for when the position has been set.

<a id="KaijuSolutions_Agents_KaijuBehaviour_OnSetPositionGlobal"></a>

### OnSetPositionGlobal

~~~csharp
public static event KaijuBehaviourAction OnSetPositionGlobal
~~~

Global callback for when the position has been set.

<a id="KaijuSolutions_Agents_KaijuBehaviour_OnPreSetOrientation"></a>

### OnPreSetOrientation

~~~csharp
public event KaijuAction OnPreSetOrientation
~~~

Callback for before the orientation has been set.

<a id="KaijuSolutions_Agents_KaijuBehaviour_OnPreSetOrientationGlobal"></a>

### OnPreSetOrientationGlobal

~~~csharp
public static event KaijuBehaviourAction OnPreSetOrientationGlobal
~~~

Global callback for before the orientation has been set.

<a id="KaijuSolutions_Agents_KaijuBehaviour_OnSetOrientation"></a>

### OnSetOrientation

~~~csharp
public event KaijuAction OnSetOrientation
~~~

Callback for when the orientation has been set.

<a id="KaijuSolutions_Agents_KaijuBehaviour_OnSetOrientationGlobal"></a>

### OnSetOrientationGlobal

~~~csharp
public static event KaijuBehaviourAction OnSetOrientationGlobal
~~~

Global callback for when the orientation has been set.

<a id="KaijuSolutions_Agents_KaijuBehaviour_OnPreSetScale"></a>

### OnPreSetScale

~~~csharp
public event KaijuAction OnPreSetScale
~~~

Callback for before the scale has been set.

<a id="KaijuSolutions_Agents_KaijuBehaviour_OnPreSetScaleGlobal"></a>

### OnPreSetScaleGlobal

~~~csharp
public static event KaijuBehaviourAction OnPreSetScaleGlobal
~~~

Global callback for before the scale has been set.

<a id="KaijuSolutions_Agents_KaijuBehaviour_OnSetScale"></a>

### OnSetScale

~~~csharp
public event KaijuAction OnSetScale
~~~

Callback for when the scale has been set.

<a id="KaijuSolutions_Agents_KaijuBehaviour_OnSetScaleGlobal"></a>

### OnSetScaleGlobal

~~~csharp
public static event KaijuBehaviourAction OnSetScaleGlobal
~~~

Global callback for when the scale has been set.

<a id="KaijuSolutions_Agents_KaijuBehaviour_Position"></a>

### Position

~~~csharp
public Vector2 Position { get; set; }
~~~

The position vector along the main XZ axis.

<a id="KaijuSolutions_Agents_KaijuBehaviour_Position3"></a>

### Position3

~~~csharp
public Vector3 Position3 { get; set; }
~~~

The position along all axes.

<a id="KaijuSolutions_Agents_KaijuBehaviour_LocalPosition"></a>

### LocalPosition

~~~csharp
public Vector2 LocalPosition { get; set; }
~~~

The position vector along the main XZ axis.

<a id="KaijuSolutions_Agents_KaijuBehaviour_LocalPosition3"></a>

### LocalPosition3

~~~csharp
public Vector3 LocalPosition3 { get; set; }
~~~

The position along all axes.

<a id="KaijuSolutions_Agents_KaijuBehaviour_X"></a>

### X

~~~csharp
public float X { get; set; }
~~~

The X position.

<a id="KaijuSolutions_Agents_KaijuBehaviour_LocalX"></a>

### LocalX

~~~csharp
public float LocalX { get; set; }
~~~

The local X position.

<a id="KaijuSolutions_Agents_KaijuBehaviour_Y"></a>

### Y

~~~csharp
public float Y { get; set; }
~~~

The Y position.

<a id="KaijuSolutions_Agents_KaijuBehaviour_LocalY"></a>

### LocalY

~~~csharp
public float LocalY { get; set; }
~~~

The local Y position.

<a id="KaijuSolutions_Agents_KaijuBehaviour_Z"></a>

### Z

~~~csharp
public float Z { get; set; }
~~~

The Z position.

<a id="KaijuSolutions_Agents_KaijuBehaviour_LocalZ"></a>

### LocalZ

~~~csharp
public float LocalZ { get; set; }
~~~

The local Y position.

<a id="KaijuSolutions_Agents_KaijuBehaviour_Orientation"></a>

### Orientation

~~~csharp
public float Orientation { get; set; }
~~~

The main orientation around the Y axis. The difference between this and OrientationY is that setting this will snap the X and Y angles to zero while OrientationY will not change them.

<a id="KaijuSolutions_Agents_KaijuBehaviour_LocalOrientation"></a>

### LocalOrientation

~~~csharp
public float LocalOrientation { get; set; }
~~~

The main local orientation around the Y axis.  The difference between this and LocalOrientationY is that setting this will snap the X and Y angles to zero while LocalOrientationY will not change them.

<a id="KaijuSolutions_Agents_KaijuBehaviour_OrientationAngles"></a>

### OrientationAngles

~~~csharp
public Vector3 OrientationAngles { get; set; }
~~~

Get the orientation of this in angles.

<a id="KaijuSolutions_Agents_KaijuBehaviour_LocalOrientationAngles"></a>

### LocalOrientationAngles

~~~csharp
public Vector3 LocalOrientationAngles { get; set; }
~~~

Get the local orientation of this in angles.

<a id="KaijuSolutions_Agents_KaijuBehaviour_OrientationQuaternion"></a>

### OrientationQuaternion

~~~csharp
public Quaternion OrientationQuaternion { get; set; }
~~~

Get the orientation of this as a quaternion. In most instances, it is easier to work with OrientationAngles.

<a id="KaijuSolutions_Agents_KaijuBehaviour_LocalOrientationQuaternion"></a>

### LocalOrientationQuaternion

~~~csharp
public Quaternion LocalOrientationQuaternion { get; set; }
~~~

Get the local orientation of this as a quaternion. In most instances, it is easier to work with LocalOrientationAngles.

<a id="KaijuSolutions_Agents_KaijuBehaviour_OrientationX"></a>

### OrientationX

~~~csharp
public float OrientationX { get; set; }
~~~

The X orientation of this.

<a id="KaijuSolutions_Agents_KaijuBehaviour_LocalOrientationX"></a>

### LocalOrientationX

~~~csharp
public float LocalOrientationX { get; set; }
~~~

The local X orientation of this.

<a id="KaijuSolutions_Agents_KaijuBehaviour_OrientationY"></a>

### OrientationY

~~~csharp
public float OrientationY { get; set; }
~~~

The Y orientation of this. The difference between this and Orientation is that Orientation will snap the X and Z angles to zero while this will keep them the same.

<a id="KaijuSolutions_Agents_KaijuBehaviour_LocalOrientationY"></a>

### LocalOrientationY

~~~csharp
public float LocalOrientationY { get; set; }
~~~

The local Y orientation of this. The difference between this and LocalOrientation is that LocalOrientation will snap the X and Z angles to zero while this will keep them the same.

<a id="KaijuSolutions_Agents_KaijuBehaviour_OrientationZ"></a>

### OrientationZ

~~~csharp
public float OrientationZ { get; set; }
~~~

The Z orientation of this.

<a id="KaijuSolutions_Agents_KaijuBehaviour_LocalOrientationZ"></a>

### LocalOrientationZ

~~~csharp
public float LocalOrientationZ { get; set; }
~~~

The local Z orientation of this.

<a id="KaijuSolutions_Agents_KaijuBehaviour_OrientationQuaternionX"></a>

### OrientationQuaternionX

~~~csharp
public float OrientationQuaternionX { get; set; }
~~~

The local X value of the orientation quaternion. If you are looking to get or The angle, you may be looking for OrientationX.

<a id="KaijuSolutions_Agents_KaijuBehaviour_LocalOrientationQuaternionX"></a>

### LocalOrientationQuaternionX

~~~csharp
public float LocalOrientationQuaternionX { get; set; }
~~~

The local X value of the local orientation quaternion. If you are looking to get or The angle, you may be looking for LocalOrientationX.

<a id="KaijuSolutions_Agents_KaijuBehaviour_OrientationQuaternionY"></a>

### OrientationQuaternionY

~~~csharp
public float OrientationQuaternionY { get; set; }
~~~

The local Y value of the orientation quaternion. If you are looking to get or The angle, you may be looking for OrientationY.

<a id="KaijuSolutions_Agents_KaijuBehaviour_LocalOrientationQuaternionY"></a>

### LocalOrientationQuaternionY

~~~csharp
public float LocalOrientationQuaternionY { get; set; }
~~~

The local Y value of the local orientation quaternion. If you are looking to get or The angle, you may be looking for LocalOrientationY.

<a id="KaijuSolutions_Agents_KaijuBehaviour_OrientationQuaternionZ"></a>

### OrientationQuaternionZ

~~~csharp
public float OrientationQuaternionZ { get; set; }
~~~

The local Z value of the orientation quaternion. If you are looking to get or The angle, you may be looking for OrientationZ.

<a id="KaijuSolutions_Agents_KaijuBehaviour_LocalOrientationQuaternionZ"></a>

### LocalOrientationQuaternionZ

~~~csharp
public float LocalOrientationQuaternionZ { get; set; }
~~~

The local Z value of the local orientation quaternion. If you are looking to get or The angle, you may be looking for LocalOrientationZ.

<a id="KaijuSolutions_Agents_KaijuBehaviour_OrientationQuaternionW"></a>

### OrientationQuaternionW

~~~csharp
public float OrientationQuaternionW { get; set; }
~~~

The local W value of the orientation quaternion. If you are looking to get or The angle, you may be looking for OrientationX, OrientationY, or OrientationZ.

<a id="KaijuSolutions_Agents_KaijuBehaviour_LocalOrientationQuaternionW"></a>

### LocalOrientationQuaternionW

~~~csharp
public float LocalOrientationQuaternionW { get; set; }
~~~

The local W value of the local orientation quaternion. If you are looking to get or The angle, you may be looking for LocalOrientationX, LocalOrientationY, or LocalOrientationZ.

<a id="KaijuSolutions_Agents_KaijuBehaviour_LocalScale"></a>

### LocalScale

~~~csharp
public Vector3 LocalScale { get; set; }
~~~

The local scale.

<a id="KaijuSolutions_Agents_KaijuBehaviour_LocalScaleX"></a>

### LocalScaleX

~~~csharp
public float LocalScaleX { get; set; }
~~~

The X local scale.

<a id="KaijuSolutions_Agents_KaijuBehaviour_LocalScaleY"></a>

### LocalScaleY

~~~csharp
public float LocalScaleY { get; set; }
~~~

The Y local scale.

<a id="KaijuSolutions_Agents_KaijuBehaviour_LocalScaleZ"></a>

### LocalScaleZ

~~~csharp
public float LocalScaleZ { get; set; }
~~~

The Z local scale.

<a id="KaijuSolutions_Agents_KaijuBehaviour_GlobalScale"></a>

### GlobalScale

~~~csharp
public Vector3 GlobalScale { get; }
~~~

The global or lossy scale.

<a id="KaijuSolutions_Agents_KaijuBehaviour_GlobalScaleX"></a>

### GlobalScaleX

~~~csharp
public float GlobalScaleX { get; }
~~~

The X global or lossy scale.

<a id="KaijuSolutions_Agents_KaijuBehaviour_GlobalScaleY"></a>

### GlobalScaleY

~~~csharp
public float GlobalScaleY { get; }
~~~

The Y global or lossy scale.

<a id="KaijuSolutions_Agents_KaijuBehaviour_GlobalScaleZ"></a>

### GlobalScaleZ

~~~csharp
public float GlobalScaleZ { get; }
~~~

The Z global or lossy scale.

<a id="KaijuSolutions_Agents_KaijuBehaviour_LocalToWorld"></a>

### LocalToWorld

~~~csharp
public Matrix4x4 LocalToWorld { get; }
~~~

Matrix that transforms a point from local space into world space.

<a id="KaijuSolutions_Agents_KaijuBehaviour_WorldToLocal"></a>

### WorldToLocal

~~~csharp
public Matrix4x4 WorldToLocal { get; }
~~~

Matrix that transforms a point from world space into local space.

<a id="KaijuSolutions_Agents_KaijuBehaviour_Forward"></a>

### Forward

~~~csharp
public Vector2 Forward { get; }
~~~

A normalized vector representing the blue axis of thetransformin world space along the X and Z axes.

<a id="KaijuSolutions_Agents_KaijuBehaviour_Forward3"></a>

### Forward3

~~~csharp
public Vector3 Forward3 { get; }
~~~

A normalized vector representing the blue axis of thetransformin world space.

<a id="KaijuSolutions_Agents_KaijuBehaviour_Backwards"></a>

### Backwards

~~~csharp
public Vector3 Backwards { get; }
~~~

A normalized vector representing the negative blue axis of thetransformin world space.

<a id="KaijuSolutions_Agents_KaijuBehaviour_Up"></a>

### Up

~~~csharp
public Vector3 Up { get; }
~~~

A normalized vector representing the green axis of thetransformin world space.

<a id="KaijuSolutions_Agents_KaijuBehaviour_Down"></a>

### Down

~~~csharp
public Vector3 Down { get; }
~~~

A normalized vector representing the negative green axis of thetransformin world space.

<a id="KaijuSolutions_Agents_KaijuBehaviour_Right"></a>

### Right

~~~csharp
public Vector3 Right { get; }
~~~

A normalized vector representing the red axis of thetransformin world space.

<a id="KaijuSolutions_Agents_KaijuBehaviour_Left"></a>

### Left

~~~csharp
public Vector3 Left { get; }
~~~

A normalized vector representing the negative red axis of thetransformin world space.

<a id="KaijuSolutions_Agents_KaijuBehaviour_Parent"></a>

### Parent

~~~csharp
public Transform Parent { get; }
~~~

The parent of this.

<a id="KaijuSolutions_Agents_KaijuBehaviour_Root"></a>

### Root

~~~csharp
public Transform Root { get; }
~~~

The topmost parent of this.

<a id="KaijuSolutions_Agents_KaijuBehaviour_ChildCount"></a>

### ChildCount

~~~csharp
public int ChildCount { get; }
~~~

The number of children this has.

<a id="KaijuSolutions_Agents_KaijuBehaviour_HasChanged"></a>

### HasChanged

~~~csharp
public bool HasChanged { get; }
~~~

Has thetransformchanged since the last time the flag was set to 'false'?

<a id="KaijuSolutions_Agents_KaijuBehaviour_HierarchyCount"></a>

### HierarchyCount

~~~csharp
public int HierarchyCount { get; }
~~~

The number of transforms in the transform's hierarchy data structure.

<a id="KaijuSolutions_Agents_KaijuBehaviour_HierarchyCapacity"></a>

### HierarchyCapacity

~~~csharp
public int HierarchyCapacity { get; set; }
~~~

Thetransformcapacity of the transform's hierarchy data structure.

<a id="KaijuSolutions_Agents_KaijuBehaviour_Layer"></a>

### Layer

~~~csharp
public int Layer { get; set; }
~~~

Integer identifying the layer the GameObject is assigned to.

<a id="KaijuSolutions_Agents_KaijuBehaviour_ComponentCount"></a>

### ComponentCount

~~~csharp
public int ComponentCount { get; }
~~~

The number of components on the GameObject as an integer value.

<a id="KaijuSolutions_Agents_KaijuBehaviour_ActiveInHierarchy"></a>

### ActiveInHierarchy

~~~csharp
public bool ActiveInHierarchy { get; }
~~~

The active state of the GameObject in the Scene hierarchy. True if active, false if inactive.

<a id="KaijuSolutions_Agents_KaijuBehaviour_ActiveSelf"></a>

### ActiveSelf

~~~csharp
public bool ActiveSelf { get; }
~~~

The local active state of the GameObject. True if active, false if inactive.

<a id="KaijuSolutions_Agents_KaijuBehaviour_IsStatic"></a>

### IsStatic

~~~csharp
public bool IsStatic { get; set; }
~~~

Whether there are any Static Editor Flags set for the GameObject.

<a id="KaijuSolutions_Agents_KaijuBehaviour_Scene"></a>

### Scene

~~~csharp
public Scene Scene { get; }
~~~

The Scene that contains the GameObject.

<a id="KaijuSolutions_Agents_KaijuBehaviour_ToString"></a>

### ToString

~~~csharp
public override string ToString ()
~~~

Get a description of the object.

~~~csharp
public static implicit operator float ([NotNull] KaijuBehaviour b)
~~~

Implicit conversion to a float from the Orientation.

~~~csharp
public static implicit operator float? ([NotNull] KaijuBehaviour b)
~~~

Implicit conversion to a nullable float from the Orientation.

~~~csharp
public static implicit operator double ([NotNull] KaijuBehaviour b)
~~~

Implicit conversion to a double from the Orientation.

~~~csharp
public static implicit operator double? ([NotNull] KaijuBehaviour b)
~~~

Implicit conversion to a nullable double from the Orientation.

~~~csharp
public static implicit operator Vector2 ([NotNull] KaijuBehaviour b)
~~~

Implicit conversion to a Vector2 from the Position.

~~~csharp
public static implicit operator Vector2? ([NotNull] KaijuBehaviour b)
~~~

Implicit conversion to a nullable Vector2 from the Position.

~~~csharp
public static implicit operator Vector3 ([NotNull] KaijuBehaviour b)
~~~

Implicit conversion to a Vector3 from the Position3.

~~~csharp
public static implicit operator Vector3? ([NotNull] KaijuBehaviour b)
~~~

Implicit conversion to a nullable Vector3 from the Position3.

~~~csharp
public static implicit operator Quaternion ([NotNull] KaijuBehaviour b)
~~~

Implicit conversion to a Quaternion from the OrientationQuaternion.

~~~csharp
public static implicit operator Quaternion? ([NotNull] KaijuBehaviour b)
~~~

Implicit conversion to a nullable Quaternion from the OrientationQuaternion.

~~~csharp
public static implicit operator GameObject ([NotNull] KaijuBehaviour b)
~~~

Implicit conversion to a GameObject.

~~~csharp
public static implicit operator KaijuBehaviour ([NotNull] GameObject o)
~~~

Implicit conversion from a GameObject.

~~~csharp
public static implicit operator Transform ([NotNull] KaijuBehaviour b)
~~~

Implicit conversion to a transform.

~~~csharp
public static implicit operator KaijuBehaviour ([NotNull] Transform t)
~~~

Implicit conversion from a transform.

~~~csharp
public static implicit operator bool (KaijuBehaviour b)
~~~

Implicit conversion to a Boolean if the behaviour is active.

~~~csharp
public static implicit operator bool? (KaijuBehaviour b)
~~~

Implicit conversion to a nullable Boolean if the behaviour is active.

~~~csharp
public static implicit operator string ([NotNull] KaijuBehaviour b)
~~~

Implicit conversion to a string.
