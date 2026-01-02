namespace KaijuSolutions.Agents
{
    /// <summary>
    /// The type of <see cref="KaijuAgent"/> to spawn.
    /// </summary>
    public enum KaijuAgentType
    {
        /// <summary>
        /// <see cref="KaijuAgent"/>s which move via the <see href="https://docs.unity3d.com/Manual/class-transform.html">transform</see>.
        /// </summary>
        Transform,
        
        /// <summary>
        /// <see cref="KaijuAgent"/>s which move via a <see href="https://docs.unity3d.com/Manual/rigidbody-physics-section.html">rigidbody</see>.
        /// </summary>
        Rigidbody,
        
        /// <summary>
        /// <see cref="KaijuAgent"/>s which move via a <see href="https://docs.unity3d.com/Manual/character-control-section.html">chracter controller</see>.
        /// </summary>
        Character,
        
        /// <summary>
        /// <see cref="KaijuAgent"/>s which move via a <see href="https://docs.unity3d.com/ScriptReference/AI.NavMeshAgent.html">navigation mesh <see cref="KaijuAgent"/></see>.
        /// </summary>
        Navigation
    }
}