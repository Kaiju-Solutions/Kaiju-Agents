using System.Diagnostics.CodeAnalysis;
using KaijuSolutions.Agents.Movement;
using KaijuSolutions.Agents.Sensors;

namespace KaijuSolutions.Agents
{
    /// <summary>
    /// An empty action.
    /// </summary>
    public delegate void KaijuAction();
    
    /// <summary>
    /// An action for a behaviour.
    /// </summary>
    /// <param name="behaviour">The behaviour.</param>
    public delegate void KaijuBehaviourAction([NotNull] KaijuBehaviour behaviour);
    
    /// <summary>
    /// An action for an agent.
    /// </summary>
    /// <param name="agent">The agent.</param>
    public delegate void KaijuAgentAction([NotNull] KaijuAgent agent);
    
    /// <summary>
    /// An action for a movement.
    /// </summary>
    /// <param name="movement">The movement.</param>
    public delegate void KaijuMovementAction([NotNull] KaijuMovement movement);
    
    /// <summary>
    /// An action for an agent and a movement.
    /// </summary>
    /// <param name="agent">The agent.</param>
    /// <param name="movement">The movement.</param>
    public delegate void KaijuAgentMovementAction([NotNull] KaijuAgent agent, [NotNull] KaijuMovement movement);
    
    /// <summary>
    /// An action for a sensor.
    /// </summary>
    /// <param name="sensor">The sensor.</param>
    public delegate void KaijuSensorAction([NotNull] KaijuSensor sensor);
    
    /// <summary>
    /// An action for an agent and a sensor.
    /// </summary>
    /// <param name="agent">The agent.</param>
    /// <param name="movement">The sensor.</param>
    public delegate void KaijuAgentSensorAction([NotNull] KaijuAgent agent, [NotNull] KaijuSensor sensor);
}