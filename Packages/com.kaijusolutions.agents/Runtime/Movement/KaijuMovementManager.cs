using System;
using System.Collections.Generic;
#if UNITY_EDITOR
using System.Diagnostics.CodeAnalysis;
using UnityEditor;
using UnityEngine;
#endif
namespace KaijuSolutions.Agents.Movement
{
    /// <summary>
    /// Cache movement objects for reuse.
    /// </summary>
    public static class KaijuMovementManager
    {
#if UNITY_EDITOR
        /// <summary>
        /// The key for the seek color preference.
        /// </summary>
        private const string SeekKey = "KAIJU_AGENTS_COLOR_SEEK";
        
        /// <summary>
        /// The key for the seek color preference.
        /// </summary>
        private const string PursueKey = "KAIJU_AGENTS_COLOR_PURSUE";
        
        /// <summary>
        /// The key for the seek color preference.
        /// </summary>
        private const string FleeKey = "KAIJU_AGENTS_COLOR_FLEE";
        
        /// <summary>
        /// The key for the seek color preference.
        /// </summary>
        private const string EvadeKey = "KAIJU_AGENTS_COLOR_EVADE";
        
        /// <summary>
        /// Color for seek visuals.
        /// </summary>
        public static Color SeekColor
        {
            get
            {
                if (_seekColor.HasValue)
                {
                    return _seekColor.Value;
                }
                
                _seekColor = LoadColor(SeekKey, Color.green);
                return _seekColor.Value;
            }
            set
            {
                _seekColor = value;
                SaveColor(SeekKey, _seekColor.Value);
            }
        }
        
        /// <summary>
        /// Color for seek visuals.
        /// </summary>
        private static Color? _seekColor;
        
        /// <summary>
        /// Color for pursue visuals.
        /// </summary>
        public static Color PursueColor
        {
            get
            {
                if (_pursueColor.HasValue)
                {
                    return _pursueColor.Value;
                }
                
                _pursueColor = LoadColor(PursueKey, Color.cyan);
                return _pursueColor.Value;
            }
            set
            {
                _pursueColor = value;
                SaveColor(PursueKey, _pursueColor.Value);
            }
        }
        
        /// <summary>
        /// Color for purse visuals.
        /// </summary>
        private static Color? _pursueColor;
        
        /// <summary>
        /// Color for flee visuals.
        /// </summary>
        public static Color FleeColor
        {
            get
            {
                if (_fleeColor.HasValue)
                {
                    return _fleeColor.Value;
                }
                
                _fleeColor = LoadColor(FleeKey, Color.red);
                return _fleeColor.Value;
            }
            set
            {
                _fleeColor = value;
                SaveColor(FleeKey, _fleeColor.Value);
            }
        }
        
        /// <summary>
        /// Color for flee visuals.
        /// </summary>
        private static Color? _fleeColor;
        
        /// <summary>
        /// Color for evade visuals.
        /// </summary>
        public static Color EvadeColor
        {
            get
            {
                if (_evadeColor.HasValue)
                {
                    return _evadeColor.Value;
                }
                
                _evadeColor = LoadColor(EvadeKey, Color.orange);
                return _evadeColor.Value;
            }
            set
            {
                _evadeColor = value;
                SaveColor(EvadeKey, _evadeColor.Value);
            }
        }
        
        /// <summary>
        /// Color for evade visuals.
        /// </summary>
        private static Color? _evadeColor;
        
        /// <summary>
        /// Load a color from preferences.
        /// </summary>
        /// <param name="key">The color key to retrieve.</param>
        /// <param name="fallback">The fallback color if this is a default value.</param>
        /// <returns>The color loaded from preferences.</returns>
        private static Color LoadColor([NotNull] string key, Color fallback)
        {
            float r = EditorPrefs.GetFloat($"{key}_R", fallback.r);
            float g = EditorPrefs.GetFloat($"{key}_G", fallback.g);
            float b = EditorPrefs.GetFloat($"{key}_B", fallback.b);
            float a = EditorPrefs.GetFloat($"{key}_A", fallback.a);
            return new(r, g, b, a);
        }
        
        /// <summary>
        /// Save a color to preferences.
        /// </summary>
        /// <param name="key">The color key to save.</param>
        /// <param name="color">The color to set.</param>
        private static void SaveColor([NotNull] string key, Color color)
        {
            EditorPrefs.SetFloat($"{key}_R", color.r);
            EditorPrefs.SetFloat($"{key}_G", color.g);
            EditorPrefs.SetFloat($"{key}_B", color.b);
            EditorPrefs.SetFloat($"{key}_A", color.a);
        }
        
        /// <summary>
        /// Sync all colors.
        /// </summary>
        public static void SyncColors()
        {
            _ = SeekColor;
            _ = PursueColor;
            _ = FleeColor;
            _ = EvadeColor;
        }
        
        /// <summary>
        /// Reset all colors.
        /// </summary>
        public static void ResetColors()
        {
            ResetSeekColor();
            ResetPursueColor();
            ResetFleeColor();
            ResetEvadeColor();
        }
        
        /// <summary>
        /// Reset the seek color.
        /// </summary>
        public static void ResetSeekColor()
        {
            SeekColor = Color.green;
        }
        
        /// <summary>
        /// Reset the pursue color.
        /// </summary>
        public static void ResetPursueColor()
        {
            PursueColor = Color.cyan;
        }
        
        /// <summary>
        /// Reset the seek color.
        /// </summary>
        public static void ResetFleeColor()
        {
            FleeColor = Color.red;
        }
        
        /// <summary>
        /// Reset the evade color.
        /// </summary>
        public static void ResetEvadeColor()
        {
            EvadeColor = Color.orange;
        }
#endif
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
            SyncColors();
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