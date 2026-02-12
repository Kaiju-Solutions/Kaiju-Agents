using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
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
        /// If at least one instance has been <see cref="Observed"/>.
        /// </summary>
        public bool HasObserved => ObservedCount > 0;
        
        /// <summary>
        /// The number of <see cref="Observed"/> items.
        /// </summary>
        public int ObservedCount => _observed.Count;
        
        /// <summary>
        /// All observed items.
        /// </summary>
        public IReadOnlyCollection<T> Observed => _observed;
        
        /// <summary>
        /// The nearest <see cref="Observed"/> instance to the <see cref="KaijuSensor.Agent"/>.
        /// </summary>
        /// <param name="nearest">The distance to the nearest <see cref="Observed"/> instance.</param>
        /// <returns>The nearest <see cref="Observed"/> instance. Will be NULL if the <see cref="Observed"/> list is empty.</returns>
        public T Nearest(out float nearest)
        {
            if (Agent)
            {
                return Agent.Nearest(_observed, out nearest);
            }
            
            nearest = float.MaxValue;
            return null;
        }
        
        /// <summary>
        /// The nearest <see cref="Observed"/> instance across all axes to the <see cref="KaijuSensor.Agent"/>.
        /// </summary>
        /// <param name="nearest">The distance to the nearest <see cref="Observed"/> instance.</param>
        /// <returns>The nearest <see cref="Observed"/> instance. Will be NULL if the <see cref="Observed"/> list is empty.</returns>
        public T Nearest3(out float nearest)
        {
            if (Agent)
            {
                return Agent.Nearest3(_observed, out nearest);
            }
            
            nearest = float.MaxValue;
            return null;
        }
        
        /// <summary>
        /// The farthest <see cref="Observed"/> instance to the <see cref="KaijuSensor.Agent"/>.
        /// </summary>
        /// <param name="farthest">The distance to the farthest <see cref="Observed"/> instance.</param>
        /// <returns>The farthest <see cref="Observed"/> instance. Will be NULL if the <see cref="Observed"/> list is empty.</returns>
        public T Farthest(out float farthest)
        {
            if (Agent)
            {
                return Agent.Farthest(_observed, out farthest);
            }
            
            farthest = 0;
            return null;
        }
        
        /// <summary>
        /// The farthest <see cref="Observed"/> instance across all axes to the <see cref="KaijuSensor.Agent"/>.
        /// </summary>
        /// <param name="farthest">The distance to the farthest <see cref="Observed"/> instance.</param>
        /// <returns>The farthest <see cref="Observed"/> instance. Will be NULL if the <see cref="Observed"/> list is empty.</returns>
        public T Farthest3(out float farthest)
        {
            if (Agent)
            {
                return Agent.Farthest3(_observed, out farthest);
            }
            
            farthest = 0;
            return null;
        }
        
        /// <summary>
        /// Sort <see cref="Observed"/> instances by distance to the <see cref="KaijuSensor.Agent"/>.
        /// </summary>
        /// <param name="farthest">If this should sort by farthest items first.</param>
        /// <param name="mode">How to break ties based on angle.</param>
        /// <returns>The sorted <see cref="Observed"/> instances.</returns>
        public T[] SortDistance(bool farthest = false, KaijuAngleSortMode? mode = null)
        {
            return Agent ? Agent.SortDistance(_observed, farthest, mode, Agent.Forward) : Array.Empty<T>();
        }
        
        /// <summary>
        /// Sort <see cref="Observed"/> instances by distance across all axes to the <see cref="KaijuSensor.Agent"/>.
        /// </summary>
        /// <param name="farthest">If this should sort by farthest items first.</param>
        /// <param name="mode">How to break ties based on angle.</param>
        /// <returns>The sorted <see cref="Observed"/> instances.</returns>
        public T[] SortDistance3(bool farthest = false, KaijuAngleSortMode? mode = null)
        {
            return Agent ? Agent.SortDistance3(_observed, farthest, mode, Agent.Forward) : Array.Empty<T>();
        }
        
        /// <summary>
        /// Sort <see cref="Observed"/> instances by angle to the <see cref="KaijuSensor.Agent"/>.
        /// </summary>
        /// <param name="mode">How to handle sorting.</param>
        /// <param name="farthest">How to handle breaking ties by distance. NULL means no tie breaking, false for nearest distance, and true for farthest distance.</param>
        /// <returns>The sorted <see cref="Observed"/> instances.</returns>
        public T[] SortAngle(KaijuAngleSortMode mode = KaijuAngleSortMode.Magnitude, bool? farthest = false)
        {
            return Agent ? Agent.SortAngle(Agent.Forward, _observed, mode, farthest) : Array.Empty<T>();
        }
        
        /// <summary>
        /// Sort <see cref="Observed"/> instances by distance to the <see cref="KaijuSensor.Agent"/>, keeping only the first instances which fit into a cache.
        /// </summary>
        /// <param name="cache">Where to store the observed instances. If this is less than the total <see cref="Observed"/> instances, only the first fitting instances will be returned. If this is larger than the <see cref="Observed"/> instances, any extra space will be filled with NULL values.</param>
        /// <param name="farthest">If this should sort by farthest items first.</param>
        /// <param name="mode">How to break ties based on angle.</param>
        /// <returns>The number of <see cref="Observed"/> instances fit into the cache.</returns>
        public int SortDistance([NotNull] T[] cache, bool farthest = false, KaijuAngleSortMode? mode = null)
        {
            // Sort all instances.
            T[] sorted = SortDistance(farthest, mode);
            
            // Copy over what we can.
            for (int i = 0; i < cache.Length; i++)
            {
                cache[i] = i < sorted.Length ? sorted[i] : null;
            }
            
            // Return how many were observed and fit into our cache.
            return Mathf.Min(sorted.Length, cache.Length);
        }
        
        /// <summary>
        /// Sort <see cref="Observed"/> instances by distance across all axes to the <see cref="KaijuSensor.Agent"/>, keeping only the first instances which fit into a cache.
        /// </summary>
        /// <param name="cache">Where to store the observed instances. If this is less than the total <see cref="Observed"/> instances, only the first fitting instances will be returned. If this is larger than the <see cref="Observed"/> instances, any extra space will be filled with NULL values.</param>
        /// <param name="farthest">If this should sort by farthest items first.</param>
        /// <param name="mode">How to break ties based on angle.</param>
        /// <returns>The number of <see cref="Observed"/> instances fit into the cache.</returns>
        public int SortDistance3([NotNull] T[] cache, bool farthest = false, KaijuAngleSortMode? mode = null)
        {
            // Sort all instances.
            T[] sorted = SortDistance3(farthest, mode);
            
            // Copy over what we can.
            for (int i = 0; i < cache.Length; i++)
            {
                cache[i] = i < sorted.Length ? sorted[i] : null;
            }
            
            // Return how many were observed and fit into our cache.
            return Mathf.Min(sorted.Length, cache.Length);
        }
        
        /// <summary>
        /// Sort <see cref="Observed"/> instances by angle to the <see cref="KaijuSensor.Agent"/>, keeping only the first instances which fit into a cache.
        /// </summary>
        /// <param name="cache">Where to store the observed instances. If this is less than the total <see cref="Observed"/> instances, only the first fitting instances will be returned. If this is larger than the <see cref="Observed"/> instances, any extra space will be filled with NULL values.</param>
        /// <param name="mode">How to handle sorting.</param>
        /// <param name="farthest">How to handle breaking ties by distance. NULL means no tie breaking, false for nearest distance, and true for farthest distance.</param>
        /// <returns>The number of <see cref="Observed"/> instances fit into the cache.</returns>
        public int SortAngle([NotNull] T[] cache, KaijuAngleSortMode mode = KaijuAngleSortMode.Magnitude, bool? farthest = false)
        {
            // Sort all instances.
            T[] sorted = SortAngle(mode, farthest);
            
            // Copy over what we can.
            for (int i = 0; i < cache.Length; i++)
            {
                cache[i] = i < sorted.Length ? sorted[i] : null;
            }
            
            // Return how many were observed and fit into our cache.
            return Mathf.Min(sorted.Length, cache.Length);
        }
        
        /// <summary>
        /// Sort <see cref="Observed"/> instances by distance to the <see cref="KaijuSensor.Agent"/>.
        /// </summary>
        /// <param name="farthest">If this should sort by farthest items first.</param>
        /// <param name="mode">How to break ties based on angle.</param>
        /// <param name="normalization">How to normalize the positions.</param>
        /// <returns>The sorted <see cref="Observed"/> instances.</returns>
        public Vector2[] SortDistancePosition(bool farthest = false, KaijuAngleSortMode? mode = null, KaijuPositionNormalization normalization = KaijuPositionNormalization.Local)
        {
            if (!Agent)
            {
                return Array.Empty<Vector2>();
            }
            
            Vector2 position = Agent;
            Vector2[] positions = position.SortDistance(_observed.Select(x => x.Flatten()), farthest, mode, Agent.Forward);
            position.Normalize(distance, positions, normalization);
            return positions;
        }
        
        /// <summary>
        /// Sort <see cref="Observed"/> instances by distance to the <see cref="KaijuSensor.Agent"/>.
        /// </summary>
        /// <param name="farthest">If this should sort by farthest items first.</param>
        /// <param name="mode">How to break ties based on angle.</param>
        /// <param name="normalization">How to normalize the positions.</param>
        /// <returns>The sorted <see cref="Observed"/> instances.</returns>
        public Vector3[] SortDistancePosition3(bool farthest = false, KaijuAngleSortMode? mode = null, KaijuPositionNormalization normalization = KaijuPositionNormalization.Local)
        {
            if (!Agent)
            {
                return Array.Empty<Vector3>();
            }
            
            Vector3 position = Agent;
            Vector3[] positions = position.SortDistance(_observed.Select(x => x.transform.position), farthest, mode, Agent.Forward);
            position.Normalize(distance, positions, normalization);
            return positions;
        }
        
        /// <summary>
        /// Sort <see cref="Observed"/> instances by distance across all axes to the <see cref="KaijuSensor.Agent"/>.
        /// </summary>
        /// <param name="farthest">If this should sort by farthest items first.</param>
        /// <param name="mode">How to break ties based on angle.</param>
        /// <param name="normalization">How to normalize the positions.</param>
        /// <returns>The sorted <see cref="Observed"/> instances.</returns>
        public Vector2[] SortDistance3Position(bool farthest = false, KaijuAngleSortMode? mode = null, KaijuPositionNormalization normalization = KaijuPositionNormalization.Local)
        {
            if (!Agent)
            {
                return Array.Empty<Vector2>();
            }
            
            Vector2 position = Agent;
            Vector2[] positions = position.SortDistance3(_observed.Select(x => x.Flatten()), farthest, mode, Agent.Forward);
            position.Normalize(distance, positions, normalization);
            return positions;
        }
        
        /// <summary>
        /// Sort <see cref="Observed"/> instances by distance across all axes to the <see cref="KaijuSensor.Agent"/>.
        /// </summary>
        /// <param name="farthest">If this should sort by farthest items first.</param>
        /// <param name="mode">How to break ties based on angle.</param>
        /// <param name="normalization">How to normalize the positions.</param>
        /// <returns>The sorted <see cref="Observed"/> instances.</returns>
        public Vector3[] SortDistance3Position3(bool farthest = false, KaijuAngleSortMode? mode = null, KaijuPositionNormalization normalization = KaijuPositionNormalization.Local)
        {
            if (!Agent)
            {
                return Array.Empty<Vector3>();
            }
            
            Vector3 position = Agent;
            Vector3[] positions = position.SortDistance3(_observed.Select(x => x.transform.position), farthest, mode, Agent.Forward);
            position.Normalize(distance, positions, normalization);
            return positions;
        }
        
        /// <summary>
        /// Sort <see cref="Observed"/> instances by angle to the <see cref="KaijuSensor.Agent"/>.
        /// </summary>
        /// <param name="mode">How to handle sorting.</param>
        /// <param name="farthest">How to handle breaking ties by distance. NULL means no tie breaking, false for nearest distance, and true for farthest distance.</param>
        /// <param name="normalization">How to normalize the positions.</param>
        /// <returns>The sorted <see cref="Observed"/> instances.</returns>
        public Vector2[] SortAnglePosition(KaijuAngleSortMode mode = KaijuAngleSortMode.Magnitude, bool? farthest = false, KaijuPositionNormalization normalization = KaijuPositionNormalization.Local)
        {
            if (!Agent)
            {
                return Array.Empty<Vector2>();
            }
            
            Vector2 position = Agent;
            Vector2[] positions = position.SortAngle(Agent.Forward, _observed.Select(x => x.Flatten()), mode, farthest);
            position.Normalize(distance, positions, normalization);
            return positions;
        }
        
        /// <summary>
        /// Sort <see cref="Observed"/> instances by angle to the <see cref="KaijuSensor.Agent"/>.
        /// </summary>
        /// <param name="mode">How to handle sorting.</param>
        /// <param name="farthest">How to handle breaking ties by distance. NULL means no tie breaking, false for nearest distance, and true for farthest distance.</param>
        /// <param name="normalization">How to normalize the positions.</param>
        /// <returns>The sorted <see cref="Observed"/> instances.</returns>
        public Vector3[] SortAnglePosition3(KaijuAngleSortMode mode = KaijuAngleSortMode.Magnitude, bool? farthest = false, KaijuPositionNormalization normalization = KaijuPositionNormalization.Local)
        {
            if (!Agent)
            {
                return Array.Empty<Vector3>();
            }
            
            Vector3 position = Agent;
            Vector3[] positions = position.SortAngle(Agent.Forward, _observed.Select(x => x.transform.position), mode, farthest);
            position.Normalize(distance, positions, normalization);
            return positions;
        }
        
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