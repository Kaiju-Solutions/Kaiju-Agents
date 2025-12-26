namespace KaijuSolutions.Agents
{
    /// <summary>
    /// The type of agent to spawn.
    /// </summary>
    public enum KaijuAgentType
    {
        /// <summary>
        /// Agents which move via the <see href="https://docs.unity3d.com/Manual/class-Transform.html">transform</see>.
        /// </summary>
        Transform,
        
        /// <summary>
        /// Agents which move via a <see href="https://docs.unity3d.com/Manual/rigidbody-physics-section.html">rigidbody</see>.
        /// </summary>
        Rigidbody,
        
        /// <summary>
        /// Agents which move via a <see href="https://docs.unity3d.com/Manual/character-control-section.html">chracter controller</see>.
        /// </summary>
        Character,
        
        /// <summary>
        /// Agents which move via a <see href="https://docs.unity3d.com/ScriptReference/AI.NavMeshAgent.html">navigation mesh agent</see>.
        /// </summary>
        Navigation
    }
}