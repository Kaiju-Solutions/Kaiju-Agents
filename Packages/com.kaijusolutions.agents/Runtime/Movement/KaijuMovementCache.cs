namespace KaijuSolutions.Agents.Movement
{
    /// <summary>
    /// Cache movement objects for reuse.
    /// </summary>
    public static class KaijuMovementCache
    {
        /// <summary>
        /// Get a movement instance.
        /// </summary>
        /// <typeparam name="T">The type of movement.</typeparam>
        /// <returns>An instance of the movement.</returns>
        public static T Get<T>() where T : KaijuMovement
        {
            // TODO.
            return null;
        }
        
        /// <summary>
        /// Return a movement to the cache.
        /// </summary>
        /// <typeparam name="T">The type of movement.</typeparam>
        public static void Return<T>() where T : KaijuMovement
        {
            // TODO.
        }
    }
}