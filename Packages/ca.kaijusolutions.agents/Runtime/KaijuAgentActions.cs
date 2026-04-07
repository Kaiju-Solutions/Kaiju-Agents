using System.Diagnostics.CodeAnalysis;
using KaijuSolutions.Agents.Actuators;
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
    /// <param name="behaviour">The <see cref="KaijuSolutions.Agents.KaijuBehaviour"/>.</param>
    public delegate void KaijuBehaviourAction([NotNull] KaijuBehaviour behaviour);
    
    /// <summary>
    /// An action for an <see cref="KaijuSolutions.Agents.KaijuAgent"/>.
    /// </summary>
    /// <param name="agent">The <see cref="KaijuSolutions.Agents.KaijuAgent"/>.</param>
    public delegate void KaijuAgentAction([NotNull] KaijuAgent agent);
    
    /// <summary>
    /// An action for a movement.
    /// </summary>
    /// <param name="movement">The <see cref="KaijuSolutions.Agents.Movement.KaijuMovement"/>.</param>
    public delegate void KaijuMovementAction([NotNull] KaijuMovement movement);
    
    /// <summary>
    /// An action for an <see cref="KaijuSolutions.Agents.KaijuAgent"/> and a <see cref="KaijuSolutions.Agents.Movement.KaijuMovement"/>.
    /// </summary>
    /// <param name="agent">The <see cref="KaijuSolutions.Agents.KaijuAgent"/>.</param>
    /// <param name="movement">The <see cref="KaijuSolutions.Agents.Movement.KaijuMovement"/>.</param>
    public delegate void KaijuAgentMovementAction([NotNull] KaijuAgent agent, [NotNull] KaijuMovement movement);
    
    /// <summary>
    /// An action for a <see cref="KaijuSolutions.Agents.Sensors.KaijuSensor"/>.
    /// </summary>
    /// <param name="sensor">The <see cref="KaijuSolutions.Agents.Sensors.KaijuSensor"/>.</param>
    public delegate void KaijuSensorAction([NotNull] KaijuSensor sensor);
    
    /// <summary>
    /// An action for an <see cref="KaijuSolutions.Agents.KaijuAgent"/> and a <see cref="KaijuSolutions.Agents.Sensors.KaijuSensor"/>.
    /// </summary>
    /// <param name="agent">The <see cref="KaijuSolutions.Agents.KaijuAgent"/>.</param>
    /// <param name="sensor">The <see cref="KaijuSolutions.Agents.Sensors.KaijuSensor"/>.</param>
    public delegate void KaijuAgentSensorAction([NotNull] KaijuAgent agent, [NotNull] KaijuSensor sensor);
    
    /// <summary>
    /// An action for an <see cref="KaijuSolutions.Agents.Actuators.KaijuActuator"/>.
    /// </summary>
    /// <param name="actuator">The <see cref="KaijuSolutions.Agents.Actuators.KaijuActuator"/>.</param>
    public delegate void KaijuActuatorAction([NotNull] KaijuActuator actuator);
    
    /// <summary>
    /// An action for an <see cref="KaijuSolutions.Agents.KaijuAgent"/> and an <see cref="KaijuSolutions.Agents.Actuators.KaijuActuator"/>.
    /// </summary>
    /// <param name="agent">The <see cref="KaijuSolutions.Agents.KaijuAgent"/>.</param>
    /// <param name="actuator">The <see cref="KaijuSolutions.Agents.Actuators.KaijuActuator"/>.</param>
    public delegate void KaijuAgentActuatorAction([NotNull] KaijuAgent agent, [NotNull] KaijuActuator actuator);
}