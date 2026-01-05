using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using KaijuSolutions.Agents.Extensions;
using KaijuSolutions.Agents.Movement;
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif
namespace KaijuSolutions.Agents.Sensors
{
    /// <summary>
    /// <see cref="KaijuSensor"/> to allow for visual detection of a <see href="https://docs.unity3d.com/Manual/Components.html">component</see> type.
    /// </summary>
    /// <typeparam name="T">The type of <see href="https://docs.unity3d.com/Manual/Components.html">component</see>.</typeparam>
    [DefaultExecutionOrder(int.MinValue)]
#if UNITY_EDITOR
    [Icon("Packages/com.kaijusolutions.agents/Editor/Icon.png")]
    [HelpURL("https://agents.kaijusolutions.ca/manual/sensors.html#vision-sensor")]
#endif
    public abstract class KaijuVisionSensor<T> : KaijuSensor where T : Component
    {
        /// <summary>
        /// How far vision can extend.
        /// </summary>
        public float Distance
        {
            get => distance;
            set => distance = Mathf.Max(value, float.Epsilon);
        }
        
        /// <summary>
        /// How far vision can extend.
        /// </summary>
#if UNITY_EDITOR
        [Header("Area")]
        [Tooltip("How far vision can extend.")]
#endif
        [Min(float.Epsilon)]
        [SerializeField]
        private float distance = 20;
        
        /// <summary>
        /// What angle the vision detection should cover.
        /// </summary>
        public float Angle
        {
            get => angle;
            set => angle = Mathf.Clamp(value, float.Epsilon, 360f);
        }
        
        /// <summary>
        /// What angle the vision detection should cover.
        /// </summary>
#if UNITY_EDITOR
        [Tooltip("What angle the vision detection should cover.")]
#endif
        [Range(float.Epsilon, 360)]
        [SerializeField]
        private float angle = 180;
        
        /// <summary>
        /// If line-of-sight checks should be made for the vision. Turning off line-of-sight checks will return items within the view arc based on the angle and distance.
        /// </summary>
#if UNITY_EDITOR
        [Header("Line-of-Sight")]
        [Tooltip("If line-of-sight checks should be made for the vision. Turning off line-of-sight checks will return items within the view arc based on the angle and distance.")]
#endif
        public bool lineOfSight;
        
        /// <summary>
        /// The radius of the line-of-sight checks.
        /// </summary>
        public float Radius
        {
            get => radius;
            set => radius = Mathf.Max(value, 0);
        }
        
        /// <summary>
        /// The radius of the line-of-sight checks.
        /// </summary>
#if UNITY_EDITOR
        [Tooltip("The radius of the line-of-sight checks.")]
#endif
        [Min(0)]
        [SerializeField]
        private float radius;
        
        /// <summary>
        /// Any vertical offset to add to the line-of-sight checks. This can be useful if you for instance have targets which are a few units high but their origins are at their bases.
        /// </summary>
#if UNITY_EDITOR
        [Tooltip("Any vertical offset to add to the line-of-sight checks. This can be useful if you for instance have targets which are a few units high but their origins are at their bases.")]
#endif
        public float offset;
        
        /// <summary>
        /// What layers to collide with on the line-of-sight checks.
        /// </summary>
#if UNITY_EDITOR
        [Tooltip("What layers to collide with on the line-of-sight checks.")]
#endif
        public LayerMask mask = KaijuMovementConfiguration.DefaultMask;
        
        /// <summary>
        /// How line-of-sight checks should handle hitting triggers.
        /// </summary>
#if UNITY_EDITOR
        [Tooltip("How line-of-sight checks should handle hitting triggers.")]
#endif
        public QueryTriggerInteraction triggers = QueryTriggerInteraction.UseGlobal;
#if UNITY_EDITOR
        /// <summary>
        /// The visualizations color in the editor.
        /// </summary>
        [Header("Visualizations")]
        [Tooltip("The visualizations color in the editor.")]
        public Color editorColor = Color.white;
        
        /// <summary>
        /// If the visualizations in the editor for the line-of-sight checks should come from the <see cref="KaijuSensor.Agent"/>'s position or from the <see cref="KaijuSensor"/>'s position. The range and view arc are always drawn from the <see cref="KaijuSensor.Agent"/>'s Y height and the <see cref="KaijuSensor"/>'s X and Z positions.
        /// </summary>
        [Tooltip("If the visualizations in the editor for the line-of-sight checks should come from the agent's position or from the sensor's position. The range and view arc are always drawn from the agent's Y height and the sensor's X and Z positions.")]
        public bool editorFromAgent = true;
#endif
        /// <summary>
        /// The objects which this can detect.
        /// </summary>
        public IEnumerable<T> Observables;
        
        /// <summary>
        /// The number of observed items.
        /// </summary>
        public int ObservedCount => _observed.Count;
        
        /// <summary>
        /// All observed items.
        /// </summary>
        public IReadOnlyCollection<T> Observed => _observed;
        
        /// <summary>
        /// All observed items.
        /// </summary>
        private readonly HashSet<T> _observed = new();
        
        /// <summary>
        /// If there are no explicitly defined observable objects, define how to query for default observables.
        /// </summary>
        /// <returns>All active instances.</returns>
        protected virtual IEnumerable<T> DefaultObservables()
        {
            return FindObjectsByType<T>(FindObjectsInactive.Exclude, FindObjectsSortMode.None);
        }
        
        /// <summary>
        /// Run the <see cref="KaijuSensor"/>.
        /// </summary>
        protected override void Run()
        {
            // Clear all previously observed objects.
            _observed.Clear();
            
            // Cache local values.
            Transform t = transform;
            Vector3 p3 = t.position;
            Vector2 p = p3.Flatten();
            Vector2 f = t.forward.Flatten();
            Vector3 y = new(0, offset, 0);
            
            // Loop through all observable objects.
            foreach (T observable in Observables ?? DefaultObservables())
            {
                // Cache values for this observable.
                Transform to = observable.transform;
                Vector3 o3 = to.position;
                Vector2 o = o3.Flatten();
                
                // Perform checks.
                if ((distance >= float.MaxValue || p.Distance(o) <= distance) && (angle >= 360f || p.InView(f, o, angle)) && (!lineOfSight || p3.HasSight(o3 + y, out RaycastHit _, radius, mask, triggers)))
                {
                    _observed.Add(observable);
                }
            }
        }
        
        /// <summary>
        /// Perform any needed resetting of the <see cref="KaijuSensor"/>.
        /// </summary>
        protected override void Cleanup()
        {
            Observables = null;
            _observed.Clear();
        }
#if UNITY_EDITOR
        /// <summary>
        /// Allow for visualizing in the editor.
        /// <param name="position">The position of the <see cref="KaijuSensor.Agent"/>.</param>
        /// </summary>
        public override void EditorVisualize(Vector3 position)
        {
            Handles.color = editorColor;
            
            Vector3 p = Position3;
            p = new(p.x, editorFromAgent ? position.y : p.y, p.z);
            Vector3 y = new(0, offset, 0);
            
            foreach (T observed in _observed)
            {
                if (observed)
                {
                    Handles.DrawLine(p, observed.transform.position + y);
                }
            }
            
            p = new(p.x, position.y, p.z);
            
            if (angle < 360f)
            {
                float half = angle / 2;
                Vector3 forward = Forward3;
                Vector3 left = Quaternion.AngleAxis(-half, Vector3.up) * forward;
                Vector3 right = Quaternion.AngleAxis(half, Vector3.up) * forward;
                Handles.DrawWireArc(p, Vector3.up, left, angle, distance, 0);
                Handles.DrawLine(p, p + left * distance);
                Handles.DrawLine(p, p + right * distance);
                return;
            }
            
            if (distance < float.MaxValue)
            {
                Handles.DrawWireDisc(p, Vector3.up, distance, 0);
            }
        }
#endif
        /// <summary>
        /// Get a description of the object.
        /// </summary>
        /// <returns>A description of the object.</returns>
        public override string ToString()
        {
            return $"Kaiju Vision Sensor {name} - Agent: {(Agent ? Agent.name : "None")} - Distance: {Distance} - Angle: {Angle} - Line-of-Sight: {(lineOfSight ? "Yes" : "No")} - Radius: {Radius}";
        }
        
        /// <summary>
        /// Implicit conversion from a <see href="https://docs.unity3d.com/Manual/class-GameObject.html">GameObject</see>.
        /// </summary>
        /// <param name="o">The <see href="https://docs.unity3d.com/Manual/class-GameObject.html">GameObject</see>.</param>
        /// <returns>The <see cref="KaijuVisionSensor{T}"/> attached to the <see href="https://docs.unity3d.com/Manual/class-GameObject.html">GameObject</see> if there was one.</returns>
        public static implicit operator KaijuVisionSensor<T>([NotNull] GameObject o) => o.GetComponent<KaijuVisionSensor<T>>();
        
        /// <summary>
        /// Implicit conversion from a <see href="https://docs.unity3d.com/Manual/class-transform.html">transform</see>.
        /// </summary>
        /// <param name="t">The <see href="https://docs.unity3d.com/Manual/class-transform.html">transform</see>.</param>
        /// <returns>The <see cref="KaijuVisionSensor{T}"/> attached to the <see href="https://docs.unity3d.com/Manual/class-transform.html">transform</see> if there was one.</returns>
        public static implicit operator KaijuVisionSensor<T>([NotNull] Transform t) => t.GetComponent<KaijuVisionSensor<T>>();
        
        /// <summary>
        /// Implicit conversion to a <see cref="KaijuAgent"/>.
        /// </summary>
        /// <param name="s">The <see cref="KaijuVisionSensor{T}"/>.</param>
        /// <returns>The <see cref="KaijuAgent"/> attached to the <see cref="KaijuVisionSensor{T}"/> if there was one.</returns>
        public static implicit operator KaijuAgent([NotNull] KaijuVisionSensor<T> s) => s.Agent;
    }
}