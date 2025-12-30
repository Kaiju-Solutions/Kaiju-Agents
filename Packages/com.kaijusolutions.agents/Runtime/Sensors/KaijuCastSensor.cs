using System;
using System.Collections.Generic;
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif
namespace KaijuSolutions.Agents.Sensors
{
    /// <summary>
    /// Sensor to perform ray or sphere casts.
    /// </summary>
    [DefaultExecutionOrder(int.MinValue)]
#if UNITY_EDITOR
    [AddComponentMenu("Kaiju Solutions/Agents/Sensors/Kaiju Cast Sensor", 6)]
    [Icon("Packages/com.kaijusolutions.agents/Editor/Icon.png")]
    [HelpURL("https://agents.kaijusolutions.ca/manual/getting-started.html")]
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
                Reset();
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
        public LayerMask mask = -5;
        
        /// <summary>
        /// How casts should handle hitting triggers.
        /// </summary>
#if UNITY_EDITOR
        [Tooltip("How casts should handle hitting triggers.")]
#endif
        public QueryTriggerInteraction triggers = QueryTriggerInteraction.UseGlobal;
#if UNITY_EDITOR
        /// <summary>
        /// The visualizations color for hits.
        /// </summary>
        [Header("Visualizations")]
        [Tooltip("The visualizations color for hits.")]
        [SerializeField]
        private Color hitColor = Color.red;
        
        /// <summary>
        /// The visualizations color for misses.
        /// </summary>
        [Tooltip("The visualizations color for misses.")]
        [SerializeField]
        private Color missColor = Color.green;
#endif
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
        /// Run the sensor.
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
        /// Perform any needed resetting of the sensor.
        /// </summary>
        protected override void Reset()
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
                Reset();
            }
        }
        
        /// <summary>
        /// Allow for visualizing in the editor.
        /// <param name="position">The position of the <see cref="KaijuSensor.Agent"/>.</param>
        /// </summary>
        public override void Visualize(Vector3 position)
        {
            Vector3 p = Position3;
            for (int i = 0; i < _hits.Length; i++)
            {
                Handles.color = _hits[i].HasValue ? hitColor : missColor;
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
    }
}