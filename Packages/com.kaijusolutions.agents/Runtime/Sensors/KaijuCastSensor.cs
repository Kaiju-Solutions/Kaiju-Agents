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
    /// <see cref="KaijuSensor"/> to perform ray or sphere casts. This will cast from this <see href="https://docs.unity3d.com/Manual/class-transform.html">transform</see> in the forward direction of this <see href="https://docs.unity3d.com/Manual/class-transform.html">transform</see>.
    /// </summary>
    [DefaultExecutionOrder(int.MinValue)]
#if UNITY_EDITOR
    [AddComponentMenu("Kaiju Solutions/Agents/Sensors/Kaiju Cast Sensor", 6)]
    [Icon("Packages/com.kaijusolutions.agents/Editor/Icon.png")]
    [HelpURL("https://agents.kaijusolutions.ca/manual/sensors.html#cast-sensor")]
#endif
    public class KaijuCastSensor : KaijuSensor
    {
        /// <summary>
        /// How far to cast.
        /// </summary>
        public float Distance
        {
            get => distance;
            set => distance = Mathf.Max(value, float.Epsilon);
        }
        
        /// <summary>
        /// How far to cast.
        /// </summary>
#if UNITY_EDITOR
        [Header("Area")]
        [Tooltip("How far to cast.")]
#endif
        [Min(float.Epsilon)]
        [SerializeField]
        private float distance = 10;
        
        /// <summary>
        /// What angle to cast along.
        /// </summary>
        public float Angle
        {
            get => angle;
            set => angle = Mathf.Clamp(value, 0, 360f);
        }
        
        /// <summary>
        /// What angle to cast along.
        /// </summary>
#if UNITY_EDITOR
        [Tooltip("What angle to cast along.")]
#endif
        [Range(0, 360)]
        [SerializeField]
        private float angle = 180;
        
        /// <summary>
        /// The number of casts to make. These will be evenly distributed across the <see cref="angle"/>, unless there is only one cast in which case it will cast directly forward.
        /// </summary>
        public int Casts
        {
            get => casts;
            set
            {
                if (value == casts)
                {
                    return;
                }
                
                casts = Mathf.Max(value, 1);
#if UNITY_EDITOR
                if (!Application.isPlaying)
                {
                    return;
                }
#endif
                Cleanup();
            }
        }
        
        /// <summary>
        /// The number of casts to make. These will be evenly distributed across the <see cref="angle"/>, unless there is only one cast in which case it will cast directly forward.
        /// </summary>
#if UNITY_EDITOR
        [Header("Casting")]
        [Tooltip("What angle to cast along. These will be evenly distributed across the angle, unless there is only one cast in which case it will cast directly forward.")]
#endif
        [Min(1)]
        [SerializeField]
        private int casts = 5;
        
        /// <summary>
        /// The radius of the casts.
        /// </summary>
        public float Radius
        {
            get => radius;
            set => radius = Mathf.Max(value, 0);
        }
        
        /// <summary>
        /// The radius of the casts.
        /// </summary>
#if UNITY_EDITOR
        [Tooltip("The radius of the casts.")]
#endif
        [Min(0)]
        [SerializeField]
        private float radius;
        
        /// <summary>
        /// What layers to collide with on the casts.
        /// </summary>
#if UNITY_EDITOR
        [Tooltip("What layers to collide with on the casts.")]
#endif
        public LayerMask mask = KaijuMovementConfiguration.DefaultMask;
        
        /// <summary>
        /// How casts should handle hitting triggers.
        /// </summary>
#if UNITY_EDITOR
        [Tooltip("How casts should handle hitting triggers.")]
#endif
        public QueryTriggerInteraction triggers = QueryTriggerInteraction.UseGlobal;
#if UNITY_EDITOR
        /// <summary>
        /// The visualizations color for hits in the editor.
        /// </summary>
        [Header("Visualizations")]
        [Tooltip("The visualizations color for hits in the editor.")]
        public Color editorHit = Color.red;
        
        /// <summary>
        /// The visualizations color for misses in the editor.
        /// </summary>
        [Tooltip("The visualizations color for misses in the editor.")]
        public Color editorMiss = Color.green;
#endif
        /// <summary>
        /// If at least one ray has hit something.
        /// </summary>
        public bool HasHits
        {
            get
            {
                for (int i = 0; i < _hits.Length; i++)
                {
                    if (_hits[i] != null)
                    {
                        return true;
                    }
                }
                
                return false;
            }
        }
        
        /// <summary>
        /// The total number of casts which hit something.
        /// </summary>
        public int HitsTotal
        {
            get
            {
                int count = 0;
                for (int i = 0; i < _hits.Length; i++)
                {
                    if (_hits[i] != null)
                    {
                        count++;
                    }
                }
                
                return count;
            }
        }
        
        /// <summary>
        /// The data from left to right of what the rays have hit, with NULL entries being rays that did not hit.
        /// </summary>
        public IReadOnlyList<RaycastHit?> Hits => _hits;
        
        /// <summary>
        /// Get transforms for the <see cref="Hits"/>. Misses will be NULL.
        /// </summary>
        public IEnumerable<Transform> Transforms => _hits.Select(x => x?.transform);
        
        /// <summary>
        /// The <see cref="Hits"/> data only for points which hit, removing all NULL entries.
        /// </summary>
        public IEnumerable<RaycastHit?> ConnectedHits => _hits.Where(x => x != null);
        
        /// <summary>
        /// et transforms for the <see cref="ConnectedHits"/>.
        /// </summary>
        public IEnumerable<Transform> ConnectedTransforms => ConnectedHits.Select(x => x!.Value.transform);
        
        /// <summary>
        /// The nearest <see cref="ConnectedTransforms"/> instance to the <see cref="KaijuSensor.Agent"/>.
        /// </summary>
        /// <param name="nearest">The distance to the nearest <see cref="ConnectedTransforms"/> instance.</param>
        /// <returns>The nearest <see cref="ConnectedTransforms"/> instance. Will be NULL if the <see cref="ConnectedTransforms"/> list is empty.</returns>
        public Transform Nearest(out float nearest)
        {
            if (HasHits && Agent)
            {
                return Agent.Nearest(ConnectedTransforms, out nearest);
            }
            
            nearest = float.MaxValue;
            return null;
        }
        
        /// <summary>
        /// The nearest <see cref="ConnectedTransforms"/> instance across all axes to the <see cref="KaijuSensor.Agent"/>.
        /// </summary>
        /// <param name="nearest">The distance to the nearest <see cref="ConnectedTransforms"/> instance.</param>
        /// <returns>The nearest <see cref="ConnectedTransforms"/> instance. Will be NULL if the <see cref="ConnectedTransforms"/> list is empty.</returns>
        public Transform Nearest3(out float nearest)
        {
            if (HasHits && Agent)
            {
                return Agent.Nearest3(ConnectedTransforms, out nearest);
            }
            
            nearest = float.MaxValue;
            return null;
        }
        
        /// <summary>
        /// The farthest <see cref="ConnectedTransforms"/> instance to the <see cref="KaijuSensor.Agent"/>.
        /// </summary>
        /// <param name="farthest">The distance to the farthest <see cref="ConnectedTransforms"/> instance.</param>
        /// <returns>The farthest <see cref="ConnectedTransforms"/> instance. Will be NULL if the <see cref="ConnectedTransforms"/> list is empty.</returns>
        public Transform Farthest(out float farthest)
        {
            if (HasHits && Agent)
            {
                return Agent.Farthest(ConnectedTransforms, out farthest);
            }
            
            farthest = 0;
            return null;
        }
        
        /// <summary>
        /// The farthest <see cref="ConnectedTransforms"/> instance across all axes to the <see cref="KaijuSensor.Agent"/>.
        /// </summary>
        /// <param name="farthest">The distance to the farthest <see cref="ConnectedTransforms"/> instance.</param>
        /// <returns>The farthest <see cref="ConnectedTransforms"/> instance. Will be NULL if the <see cref="ConnectedTransforms"/> list is empty.</returns>
        public Transform Farthest3(out float farthest)
        {
            if (HasHits && Agent)
            {
                return Agent.Farthest3(ConnectedTransforms, out farthest);
            }
            
            farthest = 0;
            return null;
        }
        
        /// <summary>
        /// Sort <see cref="ConnectedTransforms"/> instances by distance to the <see cref="KaijuSensor.Agent"/>.
        /// </summary>
        /// <param name="farthest">If this should sort by farthest items first.</param>
        /// <param name="mode">How to break ties based on angle.</param>
        /// <returns>The sorted <see cref="ConnectedTransforms"/> instances.</returns>
        public Transform[] SortDistance(bool farthest = false, KaijuAngleSortMode? mode = null)
        {
            return HasHits && Agent ? Agent.SortDistance(ConnectedTransforms, farthest, mode, Agent.Forward) : Array.Empty<Transform>();
        }
        
        /// <summary>
        /// Sort <see cref="ConnectedTransforms"/> instances by distance across all axes to the <see cref="KaijuSensor.Agent"/>.
        /// </summary>
        /// <param name="farthest">If this should sort by farthest items first.</param>
        /// <param name="mode">How to break ties based on angle.</param>
        /// <returns>The sorted <see cref="ConnectedTransforms"/> instances.</returns>
        public Transform[] SortDistance3(bool farthest = false, KaijuAngleSortMode? mode = null)
        {
            return HasHits && Agent ? Agent.SortDistance(ConnectedTransforms, farthest, mode, Agent.Forward) : Array.Empty<Transform>();
        }
        
        /// <summary>
        /// Sort <see cref="ConnectedTransforms"/> instances by angle to the <see cref="KaijuSensor.Agent"/>.
        /// </summary>
        /// <param name="mode">How to handle sorting.</param>
        /// <param name="farthest">How to handle breaking ties by distance. NULL means no tie breaking, false for nearest distance, and true for farthest distance.</param>
        /// <returns>The sorted <see cref="ConnectedTransforms"/> instances.</returns>
        public Transform[] SortAngle(KaijuAngleSortMode mode = KaijuAngleSortMode.Magnitude, bool? farthest = false)
        {
            return HasHits && Agent ? Agent.SortAngle(Agent.Forward, ConnectedTransforms, mode, farthest) : Array.Empty<Transform>();
        }
        
        /// <summary>
        /// Sort <see cref="ConnectedTransforms"/> instances by distance to the <see cref="KaijuSensor.Agent"/>, keeping only the first instances which fit into a cache.
        /// </summary>
        /// <param name="cache">Where to store the observed instances. If this is less than the total <see cref="ConnectedTransforms"/> instances, only the first fitting instances will be returned. If this is larger than the <see cref="ConnectedTransforms"/> instances, any extra space will be filled with NULL values.</param>
        /// <param name="farthest">If this should sort by farthest items first.</param>
        /// <param name="mode">How to break ties based on angle.</param>
        /// <returns>The number of <see cref="ConnectedTransforms"/> instances fit into the cache.</returns>
        public int SortDistance([NotNull] Transform[] cache, bool farthest = false, KaijuAngleSortMode? mode = null)
        {
            // Sort all instances.
            Transform[] sorted = SortDistance(farthest, mode);
            
            // Copy over what we can.
            for (int i = 0; i < cache.Length; i++)
            {
                cache[i] = i < sorted.Length ? sorted[i] : null;
            }
            
            // Return how many were observed and fit into our cache.
            return Mathf.Min(sorted.Length, cache.Length);
        }
        
        /// <summary>
        /// Sort <see cref="ConnectedTransforms"/> instances by distance across all axes to the <see cref="KaijuSensor.Agent"/>, keeping only the first instances which fit into a cache.
        /// </summary>
        /// <param name="cache">Where to store the observed instances. If this is less than the total <see cref="ConnectedTransforms"/> instances, only the first fitting instances will be returned. If this is larger than the <see cref="ConnectedTransforms"/> instances, any extra space will be filled with NULL values.</param>
        /// <param name="farthest">If this should sort by farthest items first.</param>
        /// <param name="mode">How to break ties based on angle.</param>
        /// <returns>The number of <see cref="ConnectedTransforms"/> instances fit into the cache.</returns>
        public int SortDistance3([NotNull] Transform[] cache, bool farthest = false, KaijuAngleSortMode? mode = null)
        {
            // Sort all instances.
            Transform[] sorted = SortDistance3(farthest, mode);
            
            // Copy over what we can.
            for (int i = 0; i < cache.Length; i++)
            {
                cache[i] = i < sorted.Length ? sorted[i] : null;
            }
            
            // Return how many were observed and fit into our cache.
            return Mathf.Min(sorted.Length, cache.Length);
        }
        
        /// <summary>
        /// Sort <see cref="ConnectedTransforms"/> instances by angle to the <see cref="KaijuSensor.Agent"/>, keeping only the first instances which fit into a cache.
        /// </summary>
        /// <param name="cache">Where to store the observed instances. If this is less than the total <see cref="ConnectedTransforms"/> instances, only the first fitting instances will be returned. If this is larger than the <see cref="ConnectedTransforms"/> instances, any extra space will be filled with NULL values.</param>
        /// <param name="mode">How to handle sorting.</param>
        /// <param name="farthest">How to handle breaking ties by distance. NULL means no tie breaking, false for nearest distance, and true for farthest distance.</param>
        /// <returns>The number of <see cref="ConnectedTransforms"/> instances fit into the cache.</returns>
        public int SortAngle([NotNull] Transform[] cache, KaijuAngleSortMode mode = KaijuAngleSortMode.Magnitude, bool? farthest = false)
        {
            // Sort all instances.
            Transform[] sorted = SortAngle(mode, farthest);
            
            // Copy over what we can.
            for (int i = 0; i < cache.Length; i++)
            {
                cache[i] = i < sorted.Length ? sorted[i] : null;
            }
            
            // Return how many were observed and fit into our cache.
            return Mathf.Min(sorted.Length, cache.Length);
        }
        
        /// <summary>
        /// The data from left to right of what the rays have hit, with NULL entries being rays that did not hit.
        /// </summary>
        private RaycastHit?[] _hits = Array.Empty<RaycastHit?>();
        
        /// <summary>
        /// The positions corresponding to the <see cref="Hits"/>, with <see cref="Hits"/> that missed being set to the maximum casting distance.
        /// </summary>
        public IReadOnlyList<Vector3> Positions => _positions;
        
        /// <summary>
        /// The positions corresponding to the <see cref="Hits"/>, with <see cref="Hits"/> that missed being set to the maximum casting distance.
        /// </summary>
        private Vector3[] _positions = Array.Empty<Vector3>();
        
        /// <summary>
        /// Run the <see cref="KaijuSensor"/>.
        /// </summary>
        protected override void Run()
        {
            Transform t = transform;
            Vector3 p = t.position;
            Vector3 f = t.forward;
            p.ArcSphereCast(f, radius, _hits, angle, distance, mask, triggers);
            p.ExtractPoints(f, _hits, _positions, angle, distance);
        }
        
        /// <summary>
        /// Perform any needed resetting of the <see cref="KaijuSensor"/>.
        /// </summary>
        protected override void Cleanup()
        {
            // With no angle, we can only do a single cast.
            if (angle <= 0)
            {
                casts = 1;
            }
            
            // Ensure we can fit the size of the casts.
            Array.Resize(ref _hits, casts);
            Array.Resize(ref _positions, casts);
        }
#if UNITY_EDITOR
        /// <summary>
        /// Editor-only function that Unity calls when the script is loaded or a value changes in the Inspector.
        /// </summary>
        private void OnValidate()
        {
            // When playing, ensure the arrays are the proper size.
            if (Application.isPlaying)
            {
                Cleanup();
            }
        }
        
        /// <summary>
        /// Allow for visualizing in the editor.
        /// <param name="position">The position of the <see cref="KaijuSensor.Agent"/>.</param>
        /// </summary>
        public override void EditorVisualize(Vector3 position)
        {
            Vector3 p = Position3;
            for (int i = 0; i < _hits.Length; i++)
            {
                Handles.color = _hits[i].HasValue ? editorHit : editorMiss;
                Handles.DrawLine(p, _positions[i]);
            }
        }
#endif
        /// <summary>
        /// Get a description of the object.
        /// </summary>
        /// <returns>A description of the object.</returns>
        public override string ToString()
        {
            return $"Kaiju Casts Sensor {name} - Agent: {(Agent ? Agent.name : "None")} - Distance: {Distance} - Angle: {Angle} - Casts: {Casts} - Radius: {Radius}";
        }
        
        /// <summary>
        /// Implicit conversion from a <see href="https://docs.unity3d.com/Manual/class-GameObject.html">GameObject</see>.
        /// </summary>
        /// <param name="o">The <see href="https://docs.unity3d.com/Manual/class-GameObject.html">GameObject</see>.</param>
        /// <returns>The <see cref="KaijuAgentsVisionSensor"/> attached to the <see href="https://docs.unity3d.com/Manual/class-GameObject.html">GameObject</see> if there was one.</returns>
        public static implicit operator KaijuCastSensor([NotNull] GameObject o) => o.GetComponent<KaijuCastSensor>();
        
        /// <summary>
        /// Implicit conversion from a <see href="https://docs.unity3d.com/Manual/class-transform.html">transform</see>.
        /// </summary>
        /// <param name="t">The <see href="https://docs.unity3d.com/Manual/class-transform.html">transform</see>.</param>
        /// <returns>The <see cref="KaijuAgentsVisionSensor"/> attached to the <see href="https://docs.unity3d.com/Manual/class-transform.html">transform</see> if there was one.</returns>
        public static implicit operator KaijuCastSensor([NotNull] Transform t) => t.GetComponent<KaijuCastSensor>();
        
        /// <summary>
        /// Implicit conversion to a <see cref="KaijuAgent"/>.
        /// </summary>
        /// <param name="s">The <see cref="KaijuAgentsVisionSensor"/>.</param>
        /// <returns>The <see cref="KaijuAgent"/> attached to the <see cref="KaijuAgentsVisionSensor"/> if there was one.</returns>
        public static implicit operator KaijuAgent([NotNull] KaijuCastSensor s) => s.Agent;
    }
}