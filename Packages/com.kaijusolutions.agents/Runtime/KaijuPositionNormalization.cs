namespace KaijuSolutions.Agents
{
    /// <summary>
    /// How to normalize position readings from <see cref="Sensors.KaijuSensor"/>s.
    /// </summary>
    public enum KaijuPositionNormalization
    {
        /// <summary>
        /// No changes; get the global positions.
        /// </summary>
        None = 0,
        
        /// <summary>
        /// Get positions relative to the <see cref="Sensors.KaijuSensor"/>.
        /// </summary>
        Local = 1,
        
        /// <summary>
        /// Get positions relative to the <see cref="Sensors.KaijuSensor"/> and normalized in the range of [-1, 1].
        /// </summary>
        Normalized = 2
    }
}