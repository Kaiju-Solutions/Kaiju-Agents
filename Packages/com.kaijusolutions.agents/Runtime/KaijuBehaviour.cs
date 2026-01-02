using System.Diagnostics.CodeAnalysis;
using KaijuSolutions.Agents.Extensions;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace KaijuSolutions.Agents
{
    /// <summary>
    /// Base extended behaviour providing convenient helpers methods, mainly in relation to position and orientation.
    /// </summary>
    [DefaultExecutionOrder(int.MinValue + 5)]
#if UNITY_EDITOR
    [Icon("Packages/com.kaijusolutions.agents/Editor/Icon.png")]
    [HelpURL("https://agents.kaijusolutions.ca/manual/getting-started.html")]
#endif
    public abstract class KaijuBehaviour : MonoBehaviour
    {
        /// <summary>
        /// Callback for before the position has been set.
        /// </summary>
        public event KaijuAction OnPreSetPosition;
        
        /// <summary>
        /// Global callback for before the position has been set.
        /// </summary>
        public static event KaijuBehaviourAction OnPreSetPositionGlobal;
        
        /// <summary>
        /// Callback for when the position has been set.
        /// </summary>
        public event KaijuAction OnSetPosition;
        
        /// <summary>
        /// Global callback for when the position has been set.
        /// </summary>
        public static event KaijuBehaviourAction OnSetPositionGlobal;
        
        /// <summary>
        /// Callback for before the orientation has been set.
        /// </summary>
        public event KaijuAction OnPreSetOrientation;
        
        /// <summary>
        /// Global callback for before the orientation has been set.
        /// </summary>
        public static event KaijuBehaviourAction OnPreSetOrientationGlobal;
        
        /// <summary>
        /// Callback for when the orientation has been set.
        /// </summary>
        public event KaijuAction OnSetOrientation;
        
        /// <summary>
        /// Global callback for when the orientation has been set.
        /// </summary>
        public static event KaijuBehaviourAction OnSetOrientationGlobal;
        
        /// <summary>
        /// Callback for before the scale has been set.
        /// </summary>
        public event KaijuAction OnPreSetScale;
        
        /// <summary>
        /// Global callback for before the scale has been set.
        /// </summary>
        public static event KaijuBehaviourAction OnPreSetScaleGlobal;
        
        /// <summary>
        /// Callback for when the scale has been set.
        /// </summary>
        public event KaijuAction OnSetScale;
        
        /// <summary>
        /// Global callback for when the scale has been set.
        /// </summary>
        public static event KaijuBehaviourAction OnSetScaleGlobal;
        
        /// <summary>
        /// The position vector along the main XZ axis.
        /// </summary>
        public Vector2 Position
        {
            get => transform.position.Flatten();
            set
            {
                OnPreSetPosition?.Invoke();
                OnPreSetPositionGlobal?.Invoke(this);
                transform.position = new(value.x, 0, value.y);
                OnSetPosition?.Invoke();
                OnSetPositionGlobal?.Invoke(this);
            }
        }
        
        /// <summary>
        /// The position along all axes.
        /// </summary>
        public Vector3 Position3
        {
            get => transform.position;
            set
            {
                OnPreSetPosition?.Invoke();
                OnPreSetPositionGlobal?.Invoke(this);
                Transform t = transform;
                t.position = new(value.x, t.position.y, value.y);
                OnSetPosition?.Invoke();
                OnSetPositionGlobal?.Invoke(this);
            }
        }
        
        /// <summary>
        /// The position vector along the main XZ axis.
        /// </summary>
        public Vector2 LocalPosition
        {
            get
            {
                Vector3 p = transform.localPosition;
                return new(p.x, p.z);
            }
            set
            {
                OnPreSetPosition?.Invoke();
                OnPreSetPositionGlobal?.Invoke(this);
                Transform t = transform;
                t.localPosition = new(value.x, t.localPosition.y, value.y);
                OnSetPosition?.Invoke();
                OnSetPositionGlobal?.Invoke(this);
            }
        }
        
        /// <summary>
        /// The position along all axes.
        /// </summary>
        public Vector3 LocalPosition3
        {
            get => transform.localPosition;
            set
            {
                OnPreSetPosition?.Invoke();
                OnPreSetPositionGlobal?.Invoke(this);
                transform.localPosition = value;
                OnSetPosition?.Invoke();
                OnSetPositionGlobal?.Invoke(this);
            }
        }
        
        /// <summary>
        /// The X position.
        /// </summary>
        public float X
        {
            get => transform.position.x;
            set
            {
                OnPreSetPosition?.Invoke();
                OnPreSetPositionGlobal?.Invoke(this);
                Transform t = transform;
                Vector3 p = transform.position;
                t.position = new(value, p.y, p.z);
                OnSetPosition?.Invoke();
                OnSetPositionGlobal?.Invoke(this);
            }
        }
        
        /// <summary>
        /// The local X position.
        /// </summary>
        public float LocalX
        {
            get => transform.localPosition.x;
            set
            {
                OnPreSetPosition?.Invoke();
                OnPreSetPositionGlobal?.Invoke(this);
                Transform t = transform;
                Vector3 p = transform.localPosition;
                t.localPosition = new(value, p.y, p.z);
                OnSetPosition?.Invoke();
                OnSetPositionGlobal?.Invoke(this);
            }
        }
        
        /// <summary>
        /// The Y position.
        /// </summary>
        public float Y
        {
            get => transform.position.y;
            set
            {
                OnPreSetPosition?.Invoke();
                OnPreSetPositionGlobal?.Invoke(this);
                Transform t = transform;
                Vector3 p = transform.position;
                t.position = new(p.x, value, p.z);
                OnSetPosition?.Invoke();
                OnSetPositionGlobal?.Invoke(this);
            }
        }
        
        /// <summary>
        /// The local Y position.
        /// </summary>
        public float LocalY
        {
            get => transform.localPosition.y;
            set
            {
                OnPreSetPosition?.Invoke();
                OnPreSetPositionGlobal?.Invoke(this);
                Transform t = transform;
                Vector3 p = transform.localPosition;
                t.localPosition = new(p.x, value, p.z);
                OnSetPosition?.Invoke();
                OnSetPositionGlobal?.Invoke(this);
            }
        }
        
        /// <summary>
        /// The Z position.
        /// </summary>
        public float Z
        {
            get => transform.position.z;
            set
            {
                OnPreSetPosition?.Invoke();
                OnPreSetPositionGlobal?.Invoke(this);
                Transform t = transform;
                Vector3 p = transform.position;
                t.position = new(p.x, value, p.z);
                OnSetPosition?.Invoke();
                OnSetPositionGlobal?.Invoke(this);
            }
        }
        
        /// <summary>
        /// The local Y position.
        /// </summary>
        public float LocalZ
        {
            get => transform.localPosition.z;
            set
            {
                OnPreSetPosition?.Invoke();
                OnPreSetPositionGlobal?.Invoke(this);
                Transform t = transform;
                Vector3 p = transform.localPosition;
                t.localPosition = new(p.x, p.y, value);
                OnSetPosition?.Invoke();
                OnSetPositionGlobal?.Invoke(this);
            }
        }
        
        /// <summary>
        /// The main orientation around the Y axis. The difference between this and <see cref="OrientationY"/> is that setting this will snap the X and Y angles to zero while <see cref="OrientationY"/> will not change them.
        /// </summary>
        public float Orientation
        {
            get => transform.eulerAngles.y;
            set
            {
                OnPreSetOrientation?.Invoke();
                OnPreSetOrientationGlobal?.Invoke(this);
                transform.eulerAngles = new(0, value, 0);
                OnSetOrientation?.Invoke();
                OnSetOrientationGlobal?.Invoke(this);
            }
        }
        
        /// <summary>
        /// The main local orientation around the Y axis.  The difference between this and <see cref="LocalOrientationY"/> is that setting this will snap the X and Y angles to zero while <see cref="LocalOrientationY"/> will not change them.
        /// </summary>
        public float LocalOrientation
        {
            get => transform.localEulerAngles.y;
            set
            {
                OnPreSetOrientation?.Invoke();
                OnPreSetOrientationGlobal?.Invoke(this);
                transform.localEulerAngles = new(0, value, 0);
                OnSetOrientation?.Invoke();
                OnSetOrientationGlobal?.Invoke(this);
            }
        }
        
        /// <summary>
        /// Get the orientation of this in angles.
        /// </summary>
        public Vector3 OrientationAngles
        {
            get => transform.eulerAngles;
            set
            {
                OnPreSetOrientation?.Invoke();
                OnPreSetOrientationGlobal?.Invoke(this);
                transform.eulerAngles = value;
                OnSetOrientation?.Invoke();
                OnSetOrientationGlobal?.Invoke(this);
            }
        }
        
        /// <summary>
        /// Get the local orientation of this in angles.
        /// </summary>
        public Vector3 LocalOrientationAngles
        {
            get => transform.localEulerAngles;
            set
            {
                OnPreSetOrientation?.Invoke();
                OnPreSetOrientationGlobal?.Invoke(this);
                transform.localEulerAngles = value;
                OnSetOrientation?.Invoke();
                OnSetOrientationGlobal?.Invoke(this);
            }
        }
        
        /// <summary>
        /// Get the orientation of this as a quaternion. In most instances, it is easier to work with <see cref="OrientationAngles"/>.
        /// </summary>
        public Quaternion OrientationQuaternion
        {
            get => transform.rotation;
            set
            {
                OnPreSetOrientation?.Invoke();
                OnPreSetOrientationGlobal?.Invoke(this);
                transform.rotation = value;
                OnSetOrientation?.Invoke();
                OnSetOrientationGlobal?.Invoke(this);
            }
        }
        
        /// <summary>
        /// Get the local orientation of this as a quaternion. In most instances, it is easier to work with <see cref="LocalOrientationAngles"/>.
        /// </summary>
        public Quaternion LocalOrientationQuaternion
        {
            get => transform.localRotation;
            set
            {
                OnPreSetOrientation?.Invoke();
                OnPreSetOrientationGlobal?.Invoke(this);
                transform.localRotation = value;
                OnSetOrientation?.Invoke();
                OnSetOrientationGlobal?.Invoke(this);
            }
        }
        
        /// <summary>
        /// The X orientation of this.
        /// </summary>
        public float OrientationX
        {
            get => transform.eulerAngles.x;
            set
            {
                OnPreSetOrientation?.Invoke();
                OnPreSetOrientationGlobal?.Invoke(this);
                Transform t = transform;
                Vector3 o = t.eulerAngles;
                t.eulerAngles = new(value, o.y, o.z);
                OnSetOrientation?.Invoke();
                OnSetOrientationGlobal?.Invoke(this);
            }
        }
        
        /// <summary>
        /// The local X orientation of this.
        /// </summary>
        public float LocalOrientationX
        {
            get => transform.localEulerAngles.x;
            set
            {
                OnPreSetOrientation?.Invoke();
                OnPreSetOrientationGlobal?.Invoke(this);
                Transform t = transform;
                Vector3 o = t.localEulerAngles;
                t.localEulerAngles = new(value, o.y, o.z);
                OnSetOrientation?.Invoke();
                OnSetOrientationGlobal?.Invoke(this);
            }
        }
        
        /// <summary>
        /// The Y orientation of this. The difference between this and <see cref="Orientation"/> is that <see cref="Orientation"/> will snap the X and Z angles to zero while this will keep them the same.
        /// </summary>
        public float OrientationY
        {
            get => transform.eulerAngles.y;
            set
            {
                OnPreSetOrientation?.Invoke();
                OnPreSetOrientationGlobal?.Invoke(this);
                Transform t = transform;
                Vector3 o = t.eulerAngles;
                t.eulerAngles = new(o.x, value, o.z);
                OnSetOrientation?.Invoke();
                OnSetOrientationGlobal?.Invoke(this);
            }
        }
        
        /// <summary>
        /// The local Y orientation of this. The difference between this and <see cref="LocalOrientation"/> is that <see cref="LocalOrientation"/> will snap the X and Z angles to zero while this will keep them the same.
        /// </summary>
        public float LocalOrientationY
        {
            get => transform.localEulerAngles.y;
            set
            {
                OnPreSetOrientation?.Invoke();
                OnPreSetOrientationGlobal?.Invoke(this);
                Transform t = transform;
                Vector3 o = t.localEulerAngles;
                t.localEulerAngles = new(o.x, value, o.z);
                OnSetOrientation?.Invoke();
                OnSetOrientationGlobal?.Invoke(this);
            }
        }
        
        /// <summary>
        /// The Z orientation of this.
        /// </summary>
        public float OrientationZ
        {
            get => transform.eulerAngles.z;
            set
            {
                OnPreSetOrientation?.Invoke();
                OnPreSetOrientationGlobal?.Invoke(this);
                Transform t = transform;
                Vector3 o = t.eulerAngles;
                t.eulerAngles = new(o.x, o.y, value);
                OnSetOrientation?.Invoke();
                OnSetOrientationGlobal?.Invoke(this);
            }
        }
        
        /// <summary>
        /// The local Z orientation of this.
        /// </summary>
        public float LocalOrientationZ
        {
            get => transform.localEulerAngles.z;
            set
            {
                OnPreSetOrientation?.Invoke();
                OnPreSetOrientationGlobal?.Invoke(this);
                Transform t = transform;
                Vector3 o = t.localEulerAngles;
                t.localEulerAngles = new(o.x, o.y, value);
                OnSetOrientation?.Invoke();
                OnSetOrientationGlobal?.Invoke(this);
            }
        }
        
        /// <summary>
        /// The local X value of the orientation quaternion. If you are looking to get or The angle, you may be looking for <see cref="OrientationX"/>.
        /// </summary>
        public float OrientationQuaternionX
        {
            get => transform.rotation.x;
            set
            {
                OnPreSetOrientation?.Invoke();
                OnPreSetOrientationGlobal?.Invoke(this);
                Transform t = transform;
                Quaternion o = t.rotation;
                t.rotation = new(value, o.y, o.z, o.w);
                OnSetOrientation?.Invoke();
                OnSetOrientationGlobal?.Invoke(this);
            }
        }
        
        /// <summary>
        /// The local X value of the local orientation quaternion. If you are looking to get or The angle, you may be looking for <see cref="LocalOrientationX"/>.
        /// </summary>
        public float LocalOrientationQuaternionX
        {
            get => transform.localRotation.x;
            set
            {
                OnPreSetOrientation?.Invoke();
                OnPreSetOrientationGlobal?.Invoke(this);
                Transform t = transform;
                Quaternion o = t.localRotation;
                t.localRotation = new(value, o.y, o.z, o.w);
                OnSetOrientation?.Invoke();
                OnSetOrientationGlobal?.Invoke(this);
            }
        }
        
        /// <summary>
        /// The local Y value of the orientation quaternion. If you are looking to get or The angle, you may be looking for <see cref="OrientationY"/>.
        /// </summary>
        public float OrientationQuaternionY
        {
            get => transform.rotation.y;
            set
            {
                OnPreSetOrientation?.Invoke();
                OnPreSetOrientationGlobal?.Invoke(this);
                Transform t = transform;
                Quaternion o = t.rotation;
                t.rotation = new(o.x, value, o.z, o.w);
                OnSetOrientation?.Invoke();
                OnSetOrientationGlobal?.Invoke(this);
            }
        }
        
        /// <summary>
        /// The local Y value of the local orientation quaternion. If you are looking to get or The angle, you may be looking for <see cref="LocalOrientationY"/>.
        /// </summary>
        public float LocalOrientationQuaternionY
        {
            get => transform.localRotation.y;
            set
            {
                OnPreSetOrientation?.Invoke();
                OnPreSetOrientationGlobal?.Invoke(this);
                Transform t = transform;
                Quaternion o = t.localRotation;
                t.localRotation = new(o.x, value, o.z, o.w);
                OnSetOrientation?.Invoke();
                OnSetOrientationGlobal?.Invoke(this);
            }
        }
        
        /// <summary>
        /// The local Z value of the orientation quaternion. If you are looking to get or The angle, you may be looking for <see cref="OrientationZ"/>.
        /// </summary>
        public float OrientationQuaternionZ
        {
            get => transform.rotation.z;
            set
            {
                OnPreSetOrientation?.Invoke();
                OnPreSetOrientationGlobal?.Invoke(this);
                Transform t = transform;
                Quaternion o = t.rotation;
                t.rotation = new(o.x, o.y, value, o.w);
                OnSetOrientation?.Invoke();
                OnSetOrientationGlobal?.Invoke(this);
            }
        }
        
        /// <summary>
        /// The local Z value of the local orientation quaternion. If you are looking to get or The angle, you may be looking for <see cref="LocalOrientationZ"/>.
        /// </summary>
        public float LocalOrientationQuaternionZ
        {
            get => transform.localRotation.z;
            set
            {
                OnPreSetOrientation?.Invoke();
                OnPreSetOrientationGlobal?.Invoke(this);
                Transform t = transform;
                Quaternion o = t.localRotation;
                t.localRotation = new(o.x, o.y, value, o.w);
                OnSetOrientation?.Invoke();
                OnSetOrientationGlobal?.Invoke(this);
            }
        }
        
        /// <summary>
        /// The local W value of the orientation quaternion. If you are looking to get or The angle, you may be looking for <see cref="OrientationX"/>, <see cref="OrientationY"/>, or <see cref="OrientationZ"/>.
        /// </summary>
        public float OrientationQuaternionW
        {
            get => transform.rotation.w;
            set
            {
                OnPreSetOrientation?.Invoke();
                OnPreSetOrientationGlobal?.Invoke(this);
                Transform t = transform;
                Quaternion o = t.rotation;
                t.rotation = new(o.x, o.y, o.z, value);
                OnSetOrientation?.Invoke();
                OnSetOrientationGlobal?.Invoke(this);
            }
        }
        
        /// <summary>
        /// The local W value of the local orientation quaternion. If you are looking to get or The angle, you may be looking for <see cref="LocalOrientationX"/>, <see cref="LocalOrientationY"/>, or <see cref="LocalOrientationZ"/>.
        /// </summary>
        public float LocalOrientationQuaternionW
        {
            get => transform.localRotation.w;
            set
            {
                OnPreSetOrientation?.Invoke();
                OnPreSetOrientationGlobal?.Invoke(this);
                Transform t = transform;
                Quaternion o = t.localRotation;
                t.localRotation = new(o.x, o.y, o.z, value);
                OnSetOrientation?.Invoke();
                OnSetOrientationGlobal?.Invoke(this);
            }
        }
        
        /// <summary>
        /// The local scale.
        /// </summary>
        public Vector3 LocalScale
        {
            get => transform.localScale;
            set
            {
                OnPreSetScale?.Invoke();
                OnPreSetScaleGlobal?.Invoke(this);
                transform.localScale = value;
                OnSetScale?.Invoke();
                OnSetScaleGlobal?.Invoke(this);
            }
        }
        
        /// <summary>
        /// The X local scale.
        /// </summary>
        public float LocalScaleX
        {
            get => transform.localScale.x;
            set
            {
                OnPreSetScale?.Invoke();
                OnPreSetScaleGlobal?.Invoke(this);
                Transform t = transform;
                Vector3 s = t.localScale;
                t.localScale = new(value, s.y, s.z);
                OnSetScale?.Invoke();
                OnSetScaleGlobal?.Invoke(this);
            }
        }
        
        /// <summary>
        /// The Y local scale.
        /// </summary>
        public float LocalScaleY
        {
            get => transform.localScale.y;
            set
            {
                OnPreSetScale?.Invoke();
                OnPreSetScaleGlobal?.Invoke(this);
                Transform t = transform;
                Vector3 s = t.localScale;
                t.localScale = new(s.x, value, s.z);
                OnSetScale?.Invoke();
                OnSetScaleGlobal?.Invoke(this);
            }
        }
        
        /// <summary>
        /// The Z local scale.
        /// </summary>
        public float LocalScaleZ
        {
            get => transform.localScale.z;
            set
            {
                OnPreSetScale?.Invoke();
                OnPreSetScaleGlobal?.Invoke(this);
                Transform t = transform;
                Vector3 s = t.localScale;
                t.localScale = new(s.x, s.y, value);
                OnSetScale?.Invoke();
                OnSetScaleGlobal?.Invoke(this);
            }
        }
        
        /// <summary>
        /// The global or lossy scale.
        /// </summary>
        public Vector3 GlobalScale => transform.lossyScale;
        
        /// <summary>
        /// The X global or lossy scale.
        /// </summary>
        public float GlobalScaleX => transform.lossyScale.x;
        
        /// <summary>
        /// The Y global or lossy scale.
        /// </summary>
        public float GlobalScaleY => transform.lossyScale.y;
        
        /// <summary>
        /// The Z global or lossy scale.
        /// </summary>
        public float GlobalScaleZ => transform.lossyScale.z;
        
        /// <summary>
        /// Matrix that transforms a point from local space into world space.
        /// </summary>
        public Matrix4x4 LocalToWorld => transform.localToWorldMatrix;
        
        /// <summary>
        /// Matrix that transforms a point from world space into local space.
        /// </summary>
        public Matrix4x4 WorldToLocal => transform.worldToLocalMatrix;
        
        /// <summary>
        /// A normalized vector representing the blue axis of the transform in world space.
        /// </summary>
        public Vector3 Forward => transform.forward;
        
        /// <summary>
        /// A normalized vector representing the negative blue axis of the transform in world space.
        /// </summary>
        public Vector3 Backwards => -transform.forward;
        
        /// <summary>
        /// A normalized vector representing the green axis of the transform in world space.
        /// </summary>
        public Vector3 Up => transform.up;
        
        /// <summary>
        /// A normalized vector representing the negative green axis of the transform in world space.
        /// </summary>
        public Vector3 Down => -transform.up;
        
        /// <summary>
        /// A normalized vector representing the red axis of the transform in world space.
        /// </summary>
        public Vector3 Right => transform.right;
        
        /// <summary>
        /// A normalized vector representing the negative red axis of the transform in world space.
        /// </summary>
        public Vector3 Left => -transform.right;
        
        /// <summary>
        /// The parent of this.
        /// </summary>
        public Transform Parent => transform.parent;
        
        /// <summary>
        /// The topmost parent of this.
        /// </summary>
        public Transform Root => transform.root;
        
        /// <summary>
        /// The number of children this has.
        /// </summary>
        public int ChildCount => transform.childCount;
        
        /// <summary>
        /// Has the transform changed since the last time the flag was set to 'false'?
        /// </summary>
        public bool HasChanged => transform.hasChanged;
        
        /// <summary>
        /// The number of transforms in the transform's hierarchy data structure.
        /// </summary>
        public int HierarchyCount => transform.hierarchyCount;
        
        /// <summary>
        /// The transform capacity of the transform's hierarchy data structure.
        /// </summary>
        public int HierarchyCapacity
        {
            get => transform.hierarchyCapacity;
            set => transform.hierarchyCapacity = value;
        }
        
        /// <summary>
        /// Integer identifying the layer the GameObject is assigned to.
        /// </summary>
        public int Layer
        {
            get => gameObject.layer;
            set => gameObject.layer = value;
        }
        
        /// <summary>
        /// The number of components on the GameObject as an integer value.
        /// </summary>
        public int ComponentCount => gameObject.GetComponentCount();
        
        /// <summary>
        /// The active state of the GameObject in the Scene hierarchy. True if active, false if inactive.
        /// </summary>
        public bool ActiveInHierarchy => gameObject.activeInHierarchy;
        
        /// <summary>
        /// The local active state of the GameObject. True if active, false if inactive.
        /// </summary>
        public bool ActiveSelf => gameObject.activeSelf;
        
        /// <summary>
        /// Whether there are any Static Editor Flags set for the GameObject.
        /// </summary>
        public bool IsStatic
        {
            get => gameObject.isStatic;
            set => gameObject.isStatic = value;
        }
        
        /// <summary>
        /// The Scene that contains the GameObject.
        /// </summary>
        public Scene Scene => gameObject.scene;
        
        /// <summary>
        /// Get a description of the object.
        /// </summary>
        /// <returns>A description of the object.</returns>
        public override string ToString()
        {
            return $"Kaiju Behaviour {name} - Position: {Position3} - Orientation: {OrientationAngles}";
        }
        
        /// <summary>
        /// Implicit conversion to a float from the <see cref="Orientation"/>.
        /// </summary>
        /// <param name="b">The agent.</param>
        /// <returns>The agent's <see cref="Orientation"/>.</returns>
        public static implicit operator float([NotNull] KaijuBehaviour b) => b.Orientation;
        
        /// <summary>
        /// Implicit conversion to a nullable float from the <see cref="Orientation"/>.
        /// </summary>
        /// <param name="b">The agent.</param>
        /// <returns>The agent's <see cref="Orientation"/>.</returns>
        public static implicit operator float?([NotNull] KaijuBehaviour b) => b.Orientation;
        
        /// <summary>
        /// Implicit conversion to a double from the <see cref="Orientation"/>.
        /// </summary>
        /// <param name="b">The agent.</param>
        /// <returns>The agent's <see cref="Orientation"/>.</returns>
        public static implicit operator double([NotNull] KaijuBehaviour b) => b.Orientation;
        
        /// <summary>
        /// Implicit conversion to a nullable double from the <see cref="Orientation"/>.
        /// </summary>
        /// <param name="b">The agent.</param>
        /// <returns>The agent's <see cref="Orientation"/>.</returns>
        public static implicit operator double?([NotNull] KaijuBehaviour b) => b.Orientation;
        
        /// <summary>
        /// Implicit conversion to a Vector2 from the <see cref="Position"/>.
        /// </summary>
        /// <param name="b">The agent.</param>
        /// <returns>The agent's <see cref="Position"/>.</returns>
        public static implicit operator Vector2([NotNull] KaijuBehaviour b) => b.Position;
        
        /// <summary>
        /// Implicit conversion to a nullable Vector2 from the <see cref="Position"/>.
        /// </summary>
        /// <param name="b">The agent.</param>
        /// <returns>The agent's <see cref="Position"/>.</returns>
        public static implicit operator Vector2?([NotNull] KaijuBehaviour b) => b.Position;
        
        /// <summary>
        /// Implicit conversion to a Vector3 from the <see cref="Position3"/>.
        /// </summary>
        /// <param name="b">The agent.</param>
        /// <returns>The agent's <see cref="Position"/>.</returns>
        public static implicit operator Vector3([NotNull] KaijuBehaviour b) => b.Position3;
        
        /// <summary>
        /// Implicit conversion to a nullable Vector3 from the <see cref="Position3"/>.
        /// </summary>
        /// <param name="b">The agent.</param>
        /// <returns>The agent's <see cref="Position3"/>.</returns>
        public static implicit operator Vector3?([NotNull] KaijuBehaviour b) => b.Position3;
        
        /// <summary>
        /// Implicit conversion to a Quaternion from the <see cref="OrientationQuaternion"/>.
        /// </summary>
        /// <param name="b">The agent.</param>
        /// <returns>The agent's <see cref="Position"/>.</returns>
        public static implicit operator Quaternion([NotNull] KaijuBehaviour b) => b.OrientationQuaternion;
        
        /// <summary>
        /// Implicit conversion to a nullable Quaternion from the <see cref="OrientationQuaternion"/>.
        /// </summary>
        /// <param name="b">The agent.</param>
        /// <returns>The agent's <see cref="Position3"/>.</returns>
        public static implicit operator Quaternion?([NotNull] KaijuBehaviour b) => b.OrientationQuaternion;
        
        /// <summary>
        /// Implicit conversion to a <see href="https://docs.unity3d.com/Manual/class-GameObject.html">GameObject</see>.
        /// </summary>
        /// <param name="b">The agent.</param>
        /// <returns>The <see href="https://docs.unity3d.com/Manual/class-GameObject.html">GameObject</see> of the behaviour.</returns>
        public static implicit operator GameObject([NotNull] KaijuBehaviour b) => b.gameObject;
        
        /// <summary>
        /// Implicit conversion from a <see href="https://docs.unity3d.com/Manual/class-GameObject.html">GameObject</see>.
        /// </summary>
        /// <param name="o">The <see href="https://docs.unity3d.com/Manual/class-GameObject.html">GameObject</see>.</param>
        /// <returns>The behaviour attached to the <see href="https://docs.unity3d.com/Manual/class-GameObject.html">GameObject</see> if there was one.</returns>
        public static implicit operator KaijuBehaviour([NotNull] GameObject o) => o.GetComponent<KaijuBehaviour>();
        
        /// <summary>
        /// Implicit conversion to a <see href="https://docs.unity3d.com/Manual/class-Transform.html">transform</see>.
        /// </summary>
        /// <param name="b">The agent.</param>
        /// <returns>The <see href="https://docs.unity3d.com/Manual/class-Transform.html">transform</see> of the behaviour.</returns>
        public static implicit operator Transform([NotNull] KaijuBehaviour b) => b.transform;
        
        /// <summary>
        /// Implicit conversion from a <see href="https://docs.unity3d.com/Manual/class-Transform.html">transform</see>.
        /// </summary>
        /// <param name="t">The <see href="https://docs.unity3d.com/Manual/class-Transform.html">transform</see>.</param>
        /// <returns>The behaviour attached to the <see href="https://docs.unity3d.com/Manual/class-Transform.html">transform</see> if there was one.</returns>
        public static implicit operator KaijuBehaviour([NotNull] Transform t) => t.GetComponent<KaijuBehaviour>();
        
        /// <summary>
        /// Implicit conversion to a Boolean if the behaviour is active.
        /// </summary>
        /// <param name="b">The behaviour.</param>
        /// <returns>If the behaviour is active.</returns>
        public static implicit operator bool(KaijuBehaviour b) => b != null && b.isActiveAndEnabled;
        
        /// <summary>
        /// Implicit conversion to a nullable Boolean if the behaviour is active.
        /// </summary>
        /// <param name="b">The behaviour.</param>
        /// <returns>If the behaviour is active.</returns>
        public static implicit operator bool?(KaijuBehaviour b) =>  b != null && b.isActiveAndEnabled;
        
        /// <summary>
        /// Implicit conversion to a string.
        /// </summary>
        /// <param name="b">The agent.</param>
        /// <returns>The string from the <see cref="ToString"/> method.</returns>
        public static implicit operator string([NotNull] KaijuBehaviour b) => b.ToString();
    }
}