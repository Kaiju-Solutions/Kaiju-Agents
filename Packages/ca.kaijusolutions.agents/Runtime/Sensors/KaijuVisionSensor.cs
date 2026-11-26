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
    /// <see cref="KaijuSolutions.Agents.Sensors.KaijuSensor"/> to allow for visual detection of a <see href="https://docs.unity3d.com/Manual/Components.html">component</see> type.
    /// </summary>
    /// <typeparam name="T">The type of <see href="https://docs.unity3d.com/Manual/Components.html">component</see>.</typeparam>
    [DefaultExecutionOrder(int.MinValue)]
#if UNITY_EDITOR
    [Icon("Packages/ca.kaijusolutions.agents/Editor/Icon.png")]
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

        [Tooltip("Use spherical distance and a 3D view cone. Disabled uses the existing XZ field of view.")]
        public bool spatialVision;
        
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
        public float offset = 1.5f;
        
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
        /// If the visualizations in the editor for the line-of-sight checks should come from the <see cref="KaijuSolutions.Agents.Sensors.KaijuSensor.Agent"/>'s position or from the <see cref="KaijuSolutions.Agents.Sensors.KaijuSensor"/>'s position. The range and view arc are always drawn from the <see cref="KaijuSolutions.Agents.Sensors.KaijuSensor.Agent"/>'s Y height and the <see cref="KaijuSolutions.Agents.Sensors.KaijuSensor"/>'s X and Z positions.
        /// </summary>
        [Tooltip("If the visualizations in the editor for the line-of-sight checks should come from the agent's position or from the sensor's position. The range and view arc are always drawn from the agent's Y height and the sensor's X and Z positions.")]
        public bool editorFromAgent = true;
#endif
        /// <summary>
        /// The objects which this can detect.
        /// </summary>
        [NonSerialized]
        public IEnumerable<T> observables;
        
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
        /// The nearest <see cref="Observed"/> instance to the <see cref="KaijuSolutions.Agents.Sensors.KaijuSensor.Agent"/>.
        /// </summary>
        /// <param name="nearest">The distance to the nearest <see cref="Observed"/> instance.</param>
        /// <param name="normalize">If the distance should be normalized between [-1, 1].</param>
        /// <returns>The nearest <see cref="Observed"/> instance. Will be NULL if the <see cref="Observed"/> list is empty.</returns>
        public T Nearest(out float nearest, bool normalize = false)
        {
            if (!Agent)
            {
                nearest = normalize ? 1 : float.MaxValue;
                return null;
            }
            
            T target = Agent.Nearest(_observed, out nearest);
            if (normalize)
            {
                nearest = nearest.Normalize(distance);
            }
            
            return target;
        }
        
        /// <summary>
        /// The nearest <see cref="Observed"/> instance across all axes to the <see cref="KaijuSolutions.Agents.Sensors.KaijuSensor.Agent"/>.
        /// </summary>
        /// <param name="nearest">The distance to the nearest <see cref="Observed"/> instance.</param>
        /// <param name="normalize">If the distance should be normalized between [-1, 1].</param>
        /// <returns>The nearest <see cref="Observed"/> instance. Will be NULL if the <see cref="Observed"/> list is empty.</returns>
        public T Nearest3(out float nearest, bool normalize = false)
        {
            if (!Agent)
            {
                nearest = normalize ? 1 : float.MaxValue;
                return null;
            }
            
            T target = Agent.Nearest3(_observed, out nearest);
            if (normalize)
            {
                nearest = nearest.Normalize(distance);
            }
            
            return target;
        }
        
        /// <summary>
        /// The farthest <see cref="Observed"/> instance to the <see cref="KaijuSolutions.Agents.Sensors.KaijuSensor.Agent"/>.
        /// </summary>
        /// <param name="farthest">The distance to the farthest <see cref="Observed"/> instance.</param>
        /// <param name="normalize">If the distance should be normalized between [-1, 1].</param>
        /// <returns>The farthest <see cref="Observed"/> instance. Will be NULL if the <see cref="Observed"/> list is empty.</returns>
        public T Farthest(out float farthest, bool normalize = false)
        {
            if (!Agent)
            {
                farthest = 0;
                return null;
            }
            
            T target = Agent.Farthest(_observed, out farthest);
            if (normalize)
            {
                farthest = farthest.Normalize(distance);
            }
            
            return target;
        }
        
        /// <summary>
        /// The farthest <see cref="Observed"/> instance across all axes to the <see cref="KaijuSolutions.Agents.Sensors.KaijuSensor.Agent"/>.
        /// </summary>
        /// <param name="farthest">The distance to the farthest <see cref="Observed"/> instance.</param>
        /// <param name="normalize">If the distance should be normalized between [-1, 1].</param>
        /// <returns>The farthest <see cref="Observed"/> instance. Will be NULL if the <see cref="Observed"/> list is empty.</returns>
        public T Farthest3(out float farthest, bool normalize = false)
        {
            if (!Agent)
            {
                farthest = 0;
                return null;
            }
            
            T target = Agent.Farthest3(_observed, out farthest);
            if (normalize)
            {
                farthest = farthest.Normalize(distance);
            }
            
            return target;
        }
        
        /// <summary>
        /// The nearest <see cref="Observed"/> instance position to the <see cref="KaijuSolutions.Agents.Sensors.KaijuSensor.Agent"/>.
        /// </summary>
        /// <param name="normalize">If the distance should be normalized between [-1, 1].</param>
        /// <returns>The nearest <see cref="Observed"/> position instance. Will be a zero vector if the <see cref="Observed"/> list is empty.</returns>
        public Vector2 NearestPosition(bool normalize = false)
        {
            T target = Nearest(out float _);
            return target ? normalize ? target.Flatten().Normalize(Agent.Position, Agent.Forward, distance) : target.Flatten() : Vector2.zero;
        }
        
        /// <summary>
        /// The nearest <see cref="Observed"/> instance position to the <see cref="KaijuSolutions.Agents.Sensors.KaijuSensor.Agent"/>.
        /// </summary>
        /// <param name="normalize">If the distance should be normalized between [-1, 1].</param>
        /// <returns>The nearest <see cref="Observed"/> position instance. Will be a zero vector if the <see cref="Observed"/> list is empty.</returns>
        public Vector3 NearestPosition3(bool normalize = false)
        {
            T target = Nearest3(out float _);
            return target ? normalize ? target.transform.position.Normalize(Agent.Position, Agent.Forward, distance) : target.transform.position : Vector3.zero;
        }
        
        /// <summary>
        /// The farthest <see cref="Observed"/> instance position to the <see cref="KaijuSolutions.Agents.Sensors.KaijuSensor.Agent"/>.
        /// </summary>
        /// <param name="normalize">If the distance should be normalized between [-1, 1].</param>
        /// <returns>The farthest <see cref="Observed"/> position instance. Will be a zero vector if the <see cref="Observed"/> list is empty.</returns>
        public Vector2 FarthestPosition(bool normalize = false)
        {
            T target = Farthest(out float _);
            return target ? normalize ? target.Flatten().Normalize(Agent.Position, Agent.Forward, distance) : target.Flatten() : Vector2.zero;
        }
        
        /// <summary>
        /// The farthest <see cref="Observed"/> instance position to the <see cref="KaijuSolutions.Agents.Sensors.KaijuSensor.Agent"/>.
        /// </summary>
        /// <param name="normalize">If the distance should be normalized between [-1, 1].</param>
        /// <returns>The farthest <see cref="Observed"/> position instance. Will be a zero vector if the <see cref="Observed"/> list is empty.</returns>
        public Vector3 FarthestPosition3(bool normalize = false)
        {
            T target = Farthest3(out float _);
            return target ? normalize ? target.transform.position.Normalize(Agent.Position, Agent.Forward, distance) : target.transform.position : Vector3.zero;
        }
        
        /// <summary>
        /// Sort <see cref="Observed"/> instances by distance to the <see cref="KaijuSolutions.Agents.Sensors.KaijuSensor.Agent"/>.
        /// </summary>
        /// <param name="farthest">If this should sort by farthest items first.</param>
        /// <param name="mode">How to break ties based on angle.</param>
        /// <returns>The sorted <see cref="Observed"/> instances.</returns>
        public T[] SortDistance(bool farthest = false, KaijuAngleSortMode? mode = null)
        {
            return Agent ? Agent.SortDistance(_observed, farthest, mode, Agent.Forward) : Array.Empty<T>();
        }
        
        /// <summary>
        /// Sort <see cref="Observed"/> instances by distance across all axes to the <see cref="KaijuSolutions.Agents.Sensors.KaijuSensor.Agent"/>.
        /// </summary>
        /// <param name="farthest">If this should sort by farthest items first.</param>
        /// <param name="mode">How to break ties based on angle.</param>
        /// <returns>The sorted <see cref="Observed"/> instances.</returns>
        public T[] SortDistance3(bool farthest = false, KaijuAngleSortMode? mode = null)
        {
            return Agent ? Agent.SortDistance3(_observed, farthest, mode, Agent.Forward) : Array.Empty<T>();
        }
        
        /// <summary>
        /// Sort <see cref="Observed"/> instances by angle to the <see cref="KaijuSolutions.Agents.Sensors.KaijuSensor.Agent"/>.
        /// </summary>
        /// <param name="mode">How to handle sorting.</param>
        /// <param name="farthest">How to handle breaking ties by distance. NULL means no tie breaking, false for nearest distance, and true for farthest distance.</param>
        /// <returns>The sorted <see cref="Observed"/> instances.</returns>
        public T[] SortAngle(KaijuAngleSortMode mode = KaijuAngleSortMode.Magnitude, bool? farthest = false)
        {
            return Agent ? Agent.SortAngle(Agent.Forward, _observed, mode, farthest) : Array.Empty<T>();
        }
        
        /// <summary>
        /// Sort <see cref="Observed"/> instances by distance to the <see cref="KaijuSolutions.Agents.Sensors.KaijuSensor.Agent"/>, keeping only the first instances which fit into a cache.
        /// </summary>
        /// <param name="cache">Where to store the observed instances. If this is less than the total <see cref="Observed"/> instances, only the first fitting instances will be returned. If this is larger than the <see cref="Observed"/> instances, any extra space will be filled with NULL values.</param>
        /// <param name="farthest">If this should sort by farthest items first.</param>
        /// <param name="mode">How to break ties based on angle.</param>
        /// <returns>The number of <see cref="Observed"/> instances fit into the cache.</returns>
        public int SortDistance([NotNull] T[] cache, bool farthest = false, KaijuAngleSortMode? mode = null)
        {
            switch (cache.Length)
            {
                case < 1:
                    return 0;
                case 1:
                    cache[0] = farthest ? Farthest(out float _) : Nearest(out float _);
                    return cache[0] ? 1 : 0;
            }
            
            if (!Agent) { Array.Clear(cache, 0, cache.Length); return 0; }
            objects ??= new SortBuffer<T>();
            return objects.Fill(_observed, value => value, ByDistance(farthest, mode), cache);
        }
        
        /// <summary>
        /// Sort <see cref="Observed"/> instances by distance across all axes to the <see cref="KaijuSolutions.Agents.Sensors.KaijuSensor.Agent"/>, keeping only the first instances which fit into a cache.
        /// </summary>
        /// <param name="cache">Where to store the observed instances. If this is less than the total <see cref="Observed"/> instances, only the first fitting instances will be returned. If this is larger than the <see cref="Observed"/> instances, any extra space will be filled with NULL values.</param>
        /// <param name="farthest">If this should sort by farthest items first.</param>
        /// <param name="mode">How to break ties based on angle.</param>
        /// <returns>The number of <see cref="Observed"/> instances fit into the cache.</returns>
        public int SortDistance3([NotNull] T[] cache, bool farthest = false, KaijuAngleSortMode? mode = null)
        {
            switch (cache.Length)
            {
                case < 1:
                    return 0;
                case 1:
                    cache[0] = farthest ? Farthest3(out float _) : Nearest3(out float _);
                    return cache[0] ? 1 : 0;
            }
            
            if (!Agent) { Array.Clear(cache, 0, cache.Length); return 0; }
            objects ??= new SortBuffer<T>();
            return objects.Fill(_observed, value => value, ByDistance3(farthest, mode, Agent.Position3), cache);
        }
        
        /// <summary>
        /// Sort <see cref="Observed"/> instances by angle to the <see cref="KaijuSolutions.Agents.Sensors.KaijuSensor.Agent"/>, keeping only the first instances which fit into a cache.
        /// </summary>
        /// <param name="cache">Where to store the observed instances. If this is less than the total <see cref="Observed"/> instances, only the first fitting instances will be returned. If this is larger than the <see cref="Observed"/> instances, any extra space will be filled with NULL values.</param>
        /// <param name="mode">How to handle sorting.</param>
        /// <param name="farthest">How to handle breaking ties by distance. NULL means no tie breaking, false for nearest distance, and true for farthest distance.</param>
        /// <returns>The number of <see cref="Observed"/> instances fit into the cache.</returns>
        public int SortAngle([NotNull] T[] cache, KaijuAngleSortMode mode = KaijuAngleSortMode.Magnitude, bool? farthest = false)
        {
            if (cache.Length < 1)
            {
                return 0;
            }
            
            if (!Agent) { Array.Clear(cache, 0, cache.Length); return 0; }
            objects ??= new SortBuffer<T>();
            return objects.Fill(_observed, value => value, ByAngle(mode, farthest), cache);
        }
        
        /// <summary>
        /// Sort <see cref="Observed"/> instances by distance to the <see cref="KaijuSolutions.Agents.Sensors.KaijuSensor.Agent"/>.
        /// </summary>
        /// <param name="farthest">If this should sort by farthest items first.</param>
        /// <param name="mode">How to break ties based on angle.</param>
        /// <param name="normalize">If positions should be normalized between [-1, 1].</param>
        /// <returns>The sorted <see cref="Observed"/> instances.</returns>
        public Vector2[] SortDistancePosition(bool farthest = false, KaijuAngleSortMode? mode = null, bool normalize = false)
        {
            if (!Agent)
            {
                return Array.Empty<Vector2>();
            }
            
            Vector2 position = Agent;
            Vector2 forward = Agent.Forward;
            Vector2[] positions = position.SortDistance(_observed.Select(x => x.Flatten()), farthest, mode, forward);
            
            // Normalize if we should.
            if (normalize)
            {
                for (int i = 0; i < positions.Length; i++)
                {
                    positions[i] = positions[i].Normalize(position, forward, distance);
                }
            }
            
            return positions;
        }
        
        /// <summary>
        /// Sort <see cref="Observed"/> instances by distance to the <see cref="KaijuSolutions.Agents.Sensors.KaijuSensor.Agent"/>.
        /// </summary>
        /// <param name="farthest">If this should sort by farthest items first.</param>
        /// <param name="mode">How to break ties based on angle.</param>
        /// <param name="normalize">If positions should be normalized between [-1, 1].</param>
        /// <returns>The sorted <see cref="Observed"/> instances.</returns>
        public Vector3[] SortDistancePosition3(bool farthest = false, KaijuAngleSortMode? mode = null, bool normalize = false)
        {
            if (!Agent)
            {
                return Array.Empty<Vector3>();
            }
            
            Vector3 position = Agent;
            Vector3 forward = Agent.Forward3;
            Vector3[] positions = position.SortDistance(_observed.Select(x => x.transform.position), farthest, mode, forward.Flatten());
            
            // Normalize if we should.
            if (normalize)
            {
                for (int i = 0; i < positions.Length; i++)
                {
                    positions[i] = positions[i].Normalize(position, forward, distance);
                }
            }
            
            return positions;
        }
        
        /// <summary>
        /// Sort <see cref="Observed"/> instances by distance across all axes to the <see cref="KaijuSolutions.Agents.Sensors.KaijuSensor.Agent"/>.
        /// </summary>
        /// <param name="farthest">If this should sort by farthest items first.</param>
        /// <param name="mode">How to break ties based on angle.</param>
        /// <param name="normalize">If positions should be normalized between [-1, 1].</param>
        /// <returns>The sorted <see cref="Observed"/> instances.</returns>
        public Vector2[] SortDistance3Position(bool farthest = false, KaijuAngleSortMode? mode = null, bool normalize = false)
        {
            if (!Agent)
            {
                return Array.Empty<Vector2>();
            }
            
            Vector2 position = Agent;
            Vector2 forward = Agent.Forward;
            Vector2[] positions = position.SortDistance3(_observed.Select(x => x.Flatten()), farthest, mode, forward);
            
            // Normalize if we should.
            if (normalize)
            {
                for (int i = 0; i < positions.Length; i++)
                {
                    positions[i] = positions[i].Normalize(position, forward, distance);
                }
            }
            
            return positions;
        }
        
        /// <summary>
        /// Sort <see cref="Observed"/> instances by distance across all axes to the <see cref="KaijuSolutions.Agents.Sensors.KaijuSensor.Agent"/>.
        /// </summary>
        /// <param name="farthest">If this should sort by farthest items first.</param>
        /// <param name="mode">How to break ties based on angle.</param>
        /// <param name="normalize">If positions should be normalized between [-1, 1].</param>
        /// <returns>The sorted <see cref="Observed"/> instances.</returns>
        public Vector3[] SortDistance3Position3(bool farthest = false, KaijuAngleSortMode? mode = null, bool normalize = false)
        {
            if (!Agent)
            {
                return Array.Empty<Vector3>();
            }
            
            Vector3 position = Agent;
            Vector3 forward = Agent.Forward3;
            Vector3[] positions = position.SortDistance3(_observed.Select(x => x.transform.position), farthest, mode, forward.Flatten());
            
            // Normalize if we should.
            if (normalize)
            {
                for (int i = 0; i < positions.Length; i++)
                {
                    positions[i] = positions[i].Normalize(position, forward, distance);
                }
            }
            
            return positions;
        }
        
        /// <summary>
        /// Sort <see cref="Observed"/> instances by angle to the <see cref="KaijuSolutions.Agents.Sensors.KaijuSensor.Agent"/>.
        /// </summary>
        /// <param name="mode">How to handle sorting.</param>
        /// <param name="farthest">How to handle breaking ties by distance. NULL means no tie breaking, false for nearest distance, and true for farthest distance.</param>
        /// <param name="normalize">If positions should be normalized between [-1, 1].</param>
        /// <returns>The sorted <see cref="Observed"/> instances.</returns>
        public Vector2[] SortAnglePosition(KaijuAngleSortMode mode = KaijuAngleSortMode.Magnitude, bool? farthest = false, bool normalize = false)
        {
            if (!Agent)
            {
                return Array.Empty<Vector2>();
            }
            
            Vector2 position = Agent;
            Vector2[] positions = position.SortAngle(Agent.Forward, _observed.Select(x => x.Flatten()), mode, farthest);
            
            // Normalize if we should.
            if (normalize)
            {
                Vector2 forward = Agent.Forward;
                for (int i = 0; i < positions.Length; i++)
                {
                    positions[i] = positions[i].Normalize(position, forward, distance);
                }
            }
            
            return positions;
        }
        
        /// <summary>
        /// Sort <see cref="Observed"/> instances by angle to the <see cref="KaijuSolutions.Agents.Sensors.KaijuSensor.Agent"/>.
        /// </summary>
        /// <param name="mode">How to handle sorting.</param>
        /// <param name="farthest">How to handle breaking ties by distance. NULL means no tie breaking, false for nearest distance, and true for farthest distance.</param>
        /// <param name="normalize">If positions should be normalized between [-1, 1].</param>
        /// <returns>The sorted <see cref="Observed"/> instances.</returns>
        public Vector3[] SortAnglePosition3(KaijuAngleSortMode mode = KaijuAngleSortMode.Magnitude, bool? farthest = false, bool normalize = false)
        {
            if (!Agent)
            {
                return Array.Empty<Vector3>();
            }
            
            Vector3 position = Agent;
            Vector3[] positions = position.SortAngle(Agent.Forward, _observed.Select(x => x.transform.position), mode, farthest);
            
            // Normalize if we should.
            if (normalize)
            {
                Vector3 forward = Agent.Forward3;
                for (int i = 0; i < positions.Length; i++)
                {
                    positions[i] = positions[i].Normalize(position, forward, distance);
                }
            }
            
            return positions;
        }
        
        /// <summary>
        /// Sort <see cref="Observed"/> instances by distance to the <see cref="KaijuSolutions.Agents.Sensors.KaijuSensor.Agent"/>, keeping only the first instances which fit into a cache.
        /// </summary>
        /// <param name="cache">Where to store the observed instances. If this is less than the total <see cref="Observed"/> instances, only the first fitting instances will be returned. If this is larger than the <see cref="Observed"/> instances, any extra space will be filled with zero values.</param>
        /// <param name="farthest">If this should sort by farthest items first.</param>
        /// <param name="mode">How to break ties based on angle.</param>
        /// <param name="normalize">If positions should be normalized between [-1, 1].</param>
        /// <returns>The number of <see cref="Observed"/> instances fit into the cache.</returns>
        public int SortDistancePosition([NotNull] Vector2[] cache, bool farthest = false, KaijuAngleSortMode? mode = null, bool normalize = false)
        {
            switch (cache.Length)
            {
                case < 1:
                    return 0;
                case 1:
                    if (!HasObserved)
                    {
                        cache[0] = Vector2.zero;
                        return 0;
                    }
                    
                    cache[0] = farthest ? FarthestPosition(normalize) : NearestPosition(normalize);
                    return 1;
            }
            
            if (cache.Length == 0) return 0;
            if (!Agent) { Array.Clear(cache, 0, cache.Length); return 0; }
            horizontalPositions ??= new SortBuffer<Vector2>();
            int count = horizontalPositions.Fill(_observed, value => value.Flatten(), ByDistance(farthest, mode), cache);
            if (normalize)
                for (int i = 0; i < count; i++) cache[i] = cache[i].Normalize(Agent.Position, Agent.Forward, distance);
            return count;
        }
        
        /// <summary>
        /// Sort <see cref="Observed"/> instances by distance to the <see cref="KaijuSolutions.Agents.Sensors.KaijuSensor.Agent"/>, keeping only the first instances which fit into a cache.
        /// </summary>
        /// <param name="cache">Where to store the observed instances. If this is less than the total <see cref="Observed"/> instances, only the first fitting instances will be returned. If this is larger than the <see cref="Observed"/> instances, any extra space will be filled with zero values.</param>
        /// <param name="farthest">If this should sort by farthest items first.</param>
        /// <param name="mode">How to break ties based on angle.</param>
        /// <param name="normalize">If positions should be normalized between [-1, 1].</param>
        /// <returns>The number of <see cref="Observed"/> instances fit into the cache.</returns>
        public int SortDistancePosition([NotNull] Vector3[] cache, bool farthest = false, KaijuAngleSortMode? mode = null, bool normalize = false)
        {
            switch (cache.Length)
            {
                case < 1:
                    return 0;
                case 1:
                    if (!HasObserved)
                    {
                        cache[0] = Vector3.zero;
                        return 0;
                    }
                    
                    cache[0] = farthest ? FarthestPosition3(normalize) : NearestPosition3(normalize);
                    return 1;
            }
            
            if (cache.Length == 0) return 0;
            if (!Agent) { Array.Clear(cache, 0, cache.Length); return 0; }
            worldPositions ??= new SortBuffer<Vector3>();
            int count = worldPositions.Fill(_observed, value => value.transform.position, ByDistance(farthest, mode), cache);
            if (normalize)
                for (int i = 0; i < count; i++) cache[i] = cache[i].Normalize(Agent.Position3, Agent.Forward3, distance);
            return count;
        }
        
        /// <summary>
        /// Sort <see cref="Observed"/> instances by distance across all axes to the <see cref="KaijuSolutions.Agents.Sensors.KaijuSensor.Agent"/>, keeping only the first instances which fit into a cache.
        /// </summary>
        /// <param name="cache">Where to store the observed instances. If this is less than the total <see cref="Observed"/> instances, only the first fitting instances will be returned. If this is larger than the <see cref="Observed"/> instances, any extra space will be filled with zero values.</param>
        /// <param name="farthest">If this should sort by farthest items first.</param>
        /// <param name="mode">How to break ties based on angle.</param>
        /// <param name="normalize">If positions should be normalized between [-1, 1].</param>
        /// <returns>The number of <see cref="Observed"/> instances fit into the cache.</returns>
        public int SortDistance3Position([NotNull] Vector2[] cache, bool farthest = false, KaijuAngleSortMode? mode = null, bool normalize = false)
        {
            switch (cache.Length)
            {
                case < 1:
                    return 0;
                case 1:
                    if (!HasObserved)
                    {
                        cache[0] = Vector2.zero;
                        return 0;
                    }
                    
                    cache[0] = farthest ? FarthestPosition(normalize) : NearestPosition(normalize);
                    return 1;
            }
            
            if (cache.Length == 0) return 0;
            if (!Agent) { Array.Clear(cache, 0, cache.Length); return 0; }
            horizontalPositions ??= new SortBuffer<Vector2>();
            int count = horizontalPositions.Fill(_observed, value => value.Flatten(), ByDistance3(farthest, mode, Agent.Position.Expand()), cache);
            if (normalize)
                for (int i = 0; i < count; i++) cache[i] = cache[i].Normalize(Agent.Position, Agent.Forward, distance);
            return count;
        }
        
        /// <summary>
        /// Sort <see cref="Observed"/> instances by distance across all axes to the <see cref="KaijuSolutions.Agents.Sensors.KaijuSensor.Agent"/>, keeping only the first instances which fit into a cache.
        /// </summary>
        /// <param name="cache">Where to store the observed instances. If this is less than the total <see cref="Observed"/> instances, only the first fitting instances will be returned. If this is larger than the <see cref="Observed"/> instances, any extra space will be filled with zero values.</param>
        /// <param name="farthest">If this should sort by farthest items first.</param>
        /// <param name="mode">How to break ties based on angle.</param>
        /// <param name="normalize">If positions should be normalized between [-1, 1].</param>
        /// <returns>The number of <see cref="Observed"/> instances fit into the cache.</returns>
        public int SortDistance3Position([NotNull] Vector3[] cache, bool farthest = false, KaijuAngleSortMode? mode = null, bool normalize = false)
        {
            switch (cache.Length)
            {
                case < 1:
                    return 0;
                case 1:
                    if (!HasObserved)
                    {
                        cache[0] = Vector3.zero;
                        return 0;
                    }
                    
                    cache[0] = farthest ? FarthestPosition3(normalize) : NearestPosition3(normalize);
                    return 1;
            }
            
            if (cache.Length == 0) return 0;
            if (!Agent) { Array.Clear(cache, 0, cache.Length); return 0; }
            worldPositions ??= new SortBuffer<Vector3>();
            int count = worldPositions.Fill(_observed, value => value.transform.position, ByDistance3(farthest, mode, Agent.Position3), cache);
            if (normalize)
                for (int i = 0; i < count; i++) cache[i] = cache[i].Normalize(Agent.Position3, Agent.Forward3, distance);
            return count;
        }
        
        /// <summary>
        /// Sort <see cref="Observed"/> instances by angle to the <see cref="KaijuSolutions.Agents.Sensors.KaijuSensor.Agent"/>, keeping only the first instances which fit into a cache.
        /// </summary>
        /// <param name="cache">Where to store the observed instances. If this is less than the total <see cref="Observed"/> instances, only the first fitting instances will be returned. If this is larger than the <see cref="Observed"/> instances, any extra space will be filled with NULL values.</param>
        /// <param name="mode">How to handle sorting.</param>
        /// <param name="farthest">How to handle breaking ties by distance. NULL means no tie breaking, false for nearest distance, and true for farthest distance.</param>
        /// <param name="normalize">If positions should be normalized between [-1, 1].</param>
        /// <returns>The number of <see cref="Observed"/> instances fit into the cache.</returns>
        public int SortAnglePosition([NotNull] Vector2[] cache, KaijuAngleSortMode mode = KaijuAngleSortMode.Magnitude, bool? farthest = false, bool normalize = false)
        {
            if (cache.Length == 0) return 0;
            if (!Agent) { Array.Clear(cache, 0, cache.Length); return 0; }
            horizontalPositions ??= new SortBuffer<Vector2>();
            int count = horizontalPositions.Fill(_observed, value => value.Flatten(), ByAngle(mode, farthest), cache);
            if (normalize)
                for (int i = 0; i < count; i++) cache[i] = cache[i].Normalize(Agent.Position, Agent.Forward, distance);
            return count;
        }
        
        /// <summary>
        /// Sort <see cref="Observed"/> instances by angle to the <see cref="KaijuSolutions.Agents.Sensors.KaijuSensor.Agent"/>, keeping only the first instances which fit into a cache.
        /// </summary>
        /// <param name="cache">Where to store the observed instances. If this is less than the total <see cref="Observed"/> instances, only the first fitting instances will be returned. If this is larger than the <see cref="Observed"/> instances, any extra space will be filled with NULL values.</param>
        /// <param name="mode">How to handle sorting.</param>
        /// <param name="farthest">How to handle breaking ties by distance. NULL means no tie breaking, false for nearest distance, and true for farthest distance.</param>
        /// <param name="normalize">If positions should be normalized between [-1, 1].</param>
        /// <returns>The number of <see cref="Observed"/> instances fit into the cache.</returns>
        public int SortAnglePosition3([NotNull] Vector3[] cache, KaijuAngleSortMode mode = KaijuAngleSortMode.Magnitude, bool? farthest = false, bool normalize = false)
        {
            if (cache.Length == 0) return 0;
            if (!Agent) { Array.Clear(cache, 0, cache.Length); return 0; }
            worldPositions ??= new SortBuffer<Vector3>();
            int count = worldPositions.Fill(_observed, value => value.transform.position, ByAngle(mode, farthest), cache);
            if (normalize)
                for (int i = 0; i < count; i++) cache[i] = cache[i].Normalize(Agent.Position3, Agent.Forward3, distance);
            return count;
        }

        public int CandidatesExamined { get; private set; }
        public int SightQueries { get; private set; }

        /// <summary>Find the closest observation using this sensor's distance mode.</summary>
        public bool TryGetNearest(out T target)
        {
            target = null;
            float best = float.PositiveInfinity;
            if (!Agent) return false;
            Vector3 origin = Agent.Position3;
            foreach (T item in _observed)
            {
                if (!item) continue;
                Vector3 offset = item.transform.position - origin;
                if (!spatialVision) offset.y = 0;
                float squared = offset.sqrMagnitude;
                if (squared >= best) continue;
                best = squared;
                target = item;
            }
            return target;
        }

        // Keep equal keys in observation order, matching the enumerable sorting API.
        private sealed class SortBuffer<V> : IComparer<(V value, int order)>
        {
            private readonly List<(V value, int order)> values = new();
            private IComparer<V> comparer;

            public int Fill(HashSet<T> items, Func<T, V> select, IComparer<V> by, V[] destination)
            {
                comparer = by;
                values.Clear();
                foreach (T item in items)
                    if (item) values.Add((select(item), values.Count));
                values.Sort(this);
                int count = Mathf.Min(values.Count, destination.Length);
                for (int i = 0; i < count; i++) destination[i] = values[i].value;
                Array.Clear(destination, count, destination.Length - count);
                values.Clear();
                return count;
            }

            public int Compare((V value, int order) left, (V value, int order) right)
            {
                int result = comparer.Compare(left.value, right.value);
                return result == 0 ? left.order.CompareTo(right.order) : result;
            }
        }

        private SortBuffer<T> objects;
        private SortBuffer<Vector2> horizontalPositions;
        private SortBuffer<Vector3> worldPositions;
        private KaijuAgentsDistanceSorter planarSorter;
        private KaijuAgentsDistance3Sorter spatialSorter;
        private KaijuAgentsAngleSorter angleSorter;

        private KaijuAgentsDistanceSorter ByDistance(bool farthest, KaijuAngleSortMode? mode)
        {
            planarSorter ??= new KaijuAgentsDistanceSorter(Vector2.zero);
            planarSorter.Set(Agent.Position, farthest, mode, Agent.Forward);
            return planarSorter;
        }

        private KaijuAgentsDistance3Sorter ByDistance3(bool farthest, KaijuAngleSortMode? mode, Vector3 origin)
        {
            spatialSorter ??= new KaijuAgentsDistance3Sorter(Vector3.zero);
            spatialSorter.Set(origin, farthest, mode, Agent.Forward);
            return spatialSorter;
        }

        private KaijuAgentsAngleSorter ByAngle(KaijuAngleSortMode mode, bool? farthest)
        {
            angleSorter ??= new KaijuAgentsAngleSorter();
            angleSorter.Set(Agent.Position, Agent.Forward, mode, farthest);
            return angleSorter;
        }

        private readonly HashSet<T> _observed = new();
        
        /// <summary>
        /// If there are no explicitly defined observable objects, define how to query for default observables.
        /// </summary>
        /// <returns>All active instances.</returns>
        protected virtual IEnumerable<T> DefaultObservables()
        {
#if UNITY_6000_4_OR_NEWER
            return FindObjectsByType<T>(FindObjectsInactive.Exclude).Where(x => x.transform != transform && x.transform != Agent.transform);
#else
            return FindObjectsByType<T>(FindObjectsInactive.Exclude, FindObjectsSortMode.None).Where(x => x.transform != transform && x.transform != Agent.transform);
#endif
        }
        
        /// <summary>
        /// Run the <see cref="KaijuSolutions.Agents.Sensors.KaijuSensor"/>.
        /// </summary>
        protected override void Run()
        {
            // Clear all previously observed objects.
            _observed.Clear();
            
            // Cache local values.
            Transform t = transform;
            Vector3 p3 = t.position;
            Vector2 p = p3.Flatten();
            Vector3 forward = t.forward;
            Vector2 f = forward.Flatten();
            Vector3 y = new(0, offset, 0);
            float squaredRange = distance * distance;
            float cone = spatialVision ? Mathf.Cos(angle * 0.5f * Mathf.Deg2Rad) : 0;

            CandidatesExamined = 0;
            SightQueries = 0;
            // Enumerating these collections through IEnumerable boxes an enumerator per sensor on CoreCLR.
            var candidates = observables ?? DefaultObservables();
            switch (candidates)
            {
                case List<T> list:
                    foreach (T item in list) Observe(item);
                    break;
                case HashSet<T> set:
                    foreach (T item in set) Observe(item);
                    break;
                case T[] array:
                    foreach (T item in array) Observe(item);
                    break;
                default:
                    foreach (T item in candidates) Observe(item);
                    break;
            }

            void Observe(T observable)
            {
                // Cache values for this observable.
                CandidatesExamined++;
                if (!observable) return;
                Transform to = observable.transform;
                if (to == t || (Agent && to == Agent.transform)) return;
                Vector3 o3 = to.position;
                bool inside;
                if (spatialVision)
                {
                    Vector3 difference = o3 - p3;
                    inside = difference.sqrMagnitude <= squaredRange && (angle >= 360 || difference == Vector3.zero || Vector3.Dot(forward, difference.normalized) >= cone);
                }
                else
                {
                    Vector2 o = o3.Flatten();
                    inside = (o - p).sqrMagnitude <= squaredRange && (angle >= 360f || p.InView(f, o, angle));
                }
                if (inside && lineOfSight) SightQueries++;
                if (inside && (!lineOfSight || p3.HasSight(o3 + y, out RaycastHit hit, radius, mask, triggers) || hit.transform == to))
                {
                    _observed.Add(observable);
                }
            }
        }
        
        /// <summary>
        /// Perform any needed resetting of the <see cref="KaijuSolutions.Agents.Sensors.KaijuSensor"/>.
        /// </summary>
        protected override void Cleanup()
        {
            observables = null;
            _observed.Clear();
        }
#if UNITY_EDITOR
        /// <summary>
        /// Allow for visualizing in the editor.
        /// <param name="position">The position of the <see cref="KaijuSolutions.Agents.Sensors.KaijuSensor.Agent"/>.</param>
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
            
            if (spatialVision)
            {
                if (distance >= float.MaxValue) return;
                if (angle >= 360)
                {
                    Handles.DrawWireDisc(p, Vector3.up, distance);
                    Handles.DrawWireDisc(p, Vector3.forward, distance);
                    Handles.DrawWireDisc(p, Vector3.right, distance);
                }
                else
                {
                    float radians = angle * Mathf.Deg2Rad * 0.5f;
                    Vector3 center = p + transform.forward * (distance * Mathf.Cos(radians));
                    float rim = distance * Mathf.Sin(radians);
                    Handles.DrawWireDisc(center, transform.forward, rim);
                    Handles.DrawLine(p, center + transform.right * rim);
                    Handles.DrawLine(p, center - transform.right * rim);
                    Handles.DrawLine(p, center + transform.up * rim);
                    Handles.DrawLine(p, center - transform.up * rim);
                }
                return;
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
            return $"{name} - Kaiju Vision Sensor - Type: {typeof(T).Name} - Agent: {(Agent ? Agent : "None")} - Distance: {Distance} - Angle: {Angle} - Line-of-Sight: {(lineOfSight ? "Yes" : "No")} - Radius: {Radius}";
        }
        
        /// <summary>
        /// Implicit conversion from a <see href="https://docs.unity3d.com/Manual/class-GameObject.html">GameObject</see>.
        /// </summary>
        /// <param name="o">The <see href="https://docs.unity3d.com/Manual/class-GameObject.html">GameObject</see>.</param>
        /// <returns>The <see cref="KaijuSolutions.Agents.Sensors.KaijuVisionSensor{T}"/> attached to the <see href="https://docs.unity3d.com/Manual/class-GameObject.html">GameObject</see> if there was one.</returns>
        public static implicit operator KaijuVisionSensor<T>([NotNull] GameObject o) => o.GetComponent<KaijuVisionSensor<T>>();
        
        /// <summary>
        /// Implicit conversion from a <see href="https://docs.unity3d.com/Manual/class-transform.html">transform</see>.
        /// </summary>
        /// <param name="t">The <see href="https://docs.unity3d.com/Manual/class-transform.html">transform</see>.</param>
        /// <returns>The <see cref="KaijuSolutions.Agents.Sensors.KaijuVisionSensor{T}"/> attached to the <see href="https://docs.unity3d.com/Manual/class-transform.html">transform</see> if there was one.</returns>
        public static implicit operator KaijuVisionSensor<T>([NotNull] Transform t) => t.GetComponent<KaijuVisionSensor<T>>();
        
        /// <summary>
        /// Implicit conversion to a <see cref="KaijuSolutions.Agents.KaijuAgent"/>.
        /// </summary>
        /// <param name="s">The <see cref="KaijuSolutions.Agents.Sensors.KaijuVisionSensor{T}"/>.</param>
        /// <returns>The <see cref="KaijuSolutions.Agents.KaijuAgent"/> attached to the <see cref="KaijuSolutions.Agents.Sensors.KaijuVisionSensor{T}"/> if there was one.</returns>
        public static implicit operator KaijuAgent([NotNull] KaijuVisionSensor<T> s) => s.Agent;
    }
}