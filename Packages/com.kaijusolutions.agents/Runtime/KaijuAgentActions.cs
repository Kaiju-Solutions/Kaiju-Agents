using KaijuSolutions.Agents.Movement;

namespace KaijuSolutions.Agents
{
    /// <summary>
    /// An action for an agent.
    /// </summary>
    public delegate void AgentAction(KaijuAgent agent);
    
    /// <summary>
    /// An action for an agent's movement.
    /// </summary>
    public delegate void AgentMovementAction(KaijuAgent agent, KaijuMovement movement);
}