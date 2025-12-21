using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
#if UNITY_EDITOR
using UnityEngine;
#endif
namespace KaijuSolutions.Agents.Movement
{
    /// <summary>
    /// Cache movement objects for reuse.
    /// </summary>
    public static class KaijuMovementManager
    {
        /// <summary>
        /// Cache of all movement instances.
        /// </summary>
        private static readonly Dictionary<Type, Queue<KaijuMovement>> Movements = new();
#if UNITY_EDITOR
        /// <summary>
        /// Handle manually resetting the domain.
        /// </summary>
        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.SubsystemRegistration)]
        private static void InitOnPlayMode()
        {
            Movements.Clear();
        }
#endif
        /// <summary>
        /// Get a movement instance.
        /// </summary>
        /// <typeparam name="T">The type of movement.</typeparam>
        /// <returns>An instance of the movement.</returns>
        public static T Get<T>() where T : KaijuMovement
        {
            if (Movements.TryGetValue(typeof(T), out Queue<KaijuMovement> movements) && movements.TryDequeue(out KaijuMovement result) && result is T valid)
            {
                return valid;
            }
            
            return null;
        }
        
        /// <summary>
        /// Return a movement to the cache.
        /// </summary>
        /// <param name="movement">The movement being returned.</param>
        /// <typeparam name="T">The type of movement.</typeparam>
        public static void Return<T>(T movement) where T : KaijuMovement
        {
            if (!Movements.TryGetValue(typeof(T), out Queue<KaijuMovement> queue))
            {
                queue = new();
                Movements.Add(typeof(T), queue);
            }
            
            queue.Enqueue(movement);
        }
    }
}