using UnityEngine;

namespace KaijuSolutions.Agents
{
    /// <summary>
    /// An agent type which tries to get its radius from colliders or otherwise manually assigns them.
    /// </summary>
    [DisallowMultipleComponent]
#if UNITY_EDITOR
    [SelectionBase]
    [Icon("Packages/com.kaijusolutions.agents/Editor/Icon.png")]
    [HelpURL("https://agents.kaijusolutions.ca/manual/getting-started.html")]
#endif
    public abstract class KaijuRadiusAgent : KaijuAgent
    {
        /// <summary>
        /// The radius of this agent. If there is an attached collider, this will lock to it and calculate the radius based on its size and cannot be set.
        /// </summary>
        public float Radius
        {
            get => radius;
            set => radius = CheckRadius(value);
        }
        
        /// <summary>
        /// The radius of this agent. If there is an attached collider, this will lock to it and calculate the radius based on its size and cannot be set.
        /// </summary>
#if UNITY_EDITOR
        [Tooltip("The radius of this agent. If there is an attached collider, this will lock to it and calculate the radius based on its size and cannot be set.")]
#endif
        [Min(0)]
        [SerializeField]
        private float radius = 0.5f;
        
        /// <summary>
        /// Get the radius of an agent.
        /// </summary>
        /// <returns>The radius of the agent.</returns>
        public override float GetRadius()
        {
            return Radius;
        }
        
        /// <summary>
        /// Check if we can set a radius, or if it should just be based on colliders.
        /// </summary>
        /// <param name="value">The manually set radius.</param>
        /// <returns>The radius to use.</returns>
        private float CheckRadius(float value)
        {
            return TryGetComponent(out CapsuleCollider c) ? Mathf.Max(c.radius, 0) : TryGetComponent(out SphereCollider s) ? Mathf.Max(s.radius, 0) : Mathf.Max(TryGetComponent(out Collider o) ? o.bounds.extents.magnitude : value, 0);
        }
        
        /// <summary>
        /// Initialize the agent.
        /// </summary>
        public override void Setup()
        {
            radius = CheckRadius(radius);
        }
    }
}