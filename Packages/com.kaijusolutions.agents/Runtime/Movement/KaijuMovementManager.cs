using System;
using System.Collections.Generic;
#if UNITY_EDITOR
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
        /// <summary>
        /// Cache of all movement instances.
        /// </summary>
        private static readonly Dictionary<Type, Queue<KaijuMovement>> Movements = new();
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
        /// The key for the wander color preference.
        /// </summary>
        private const string WanderKey = "KAIJU_AGENTS_COLOR_WANDER";
        
        /// <summary>
        /// The key for the separation color preference.
        /// </summary>
        private const string SeparationKey = "KAIJU_AGENTS_COLOR_SEPARATION";
        
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
                
                _seekColor = KaijuAgentsManager.LoadColor(SeekKey, Color.green);
                return _seekColor.Value;
            }
            set
            {
                _seekColor = value;
                KaijuAgentsManager.SaveColor(SeekKey, _seekColor.Value);
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
                
                _pursueColor = KaijuAgentsManager.LoadColor(PursueKey, Color.cyan);
                return _pursueColor.Value;
            }
            set
            {
                _pursueColor = value;
                KaijuAgentsManager.SaveColor(PursueKey, _pursueColor.Value);
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
                
                _fleeColor = KaijuAgentsManager.LoadColor(FleeKey, Color.red);
                return _fleeColor.Value;
            }
            set
            {
                _fleeColor = value;
                KaijuAgentsManager.SaveColor(FleeKey, _fleeColor.Value);
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
                
                _evadeColor = KaijuAgentsManager.LoadColor(EvadeKey, Color.orange);
                return _evadeColor.Value;
            }
            set
            {
                _evadeColor = value;
                KaijuAgentsManager.SaveColor(EvadeKey, _evadeColor.Value);
            }
        }
        
        /// <summary>
        /// Color for evade visuals.
        /// </summary>
        private static Color? _evadeColor;
        
        /// <summary>
        /// Color for wander visuals.
        /// </summary>
        public static Color WanderColor
        {
            get
            {
                if (_wanderColor.HasValue)
                {
                    return _wanderColor.Value;
                }
                
                _wanderColor = KaijuAgentsManager.LoadColor(WanderKey, Color.yellow);
                return _wanderColor.Value;
            }
            set
            {
                _wanderColor = value;
                KaijuAgentsManager.SaveColor(WanderKey, _wanderColor.Value);
            }
        }
        
        /// <summary>
        /// Color for wander visuals.
        /// </summary>
        private static Color? _wanderColor;
        
        /// <summary>
        /// Color for separation visuals.
        /// </summary>
        public static Color SeparationColor
        {
            get
            {
                if (_separationColor.HasValue)
                {
                    return _separationColor.Value;
                }
                
                _separationColor = KaijuAgentsManager.LoadColor(SeparationKey, Color.violet);
                return _separationColor.Value;
            }
            set
            {
                _separationColor = value;
                KaijuAgentsManager.SaveColor(SeparationKey, _separationColor.Value);
            }
        }
        
        /// <summary>
        /// Color for separation visuals.
        /// </summary>
        private static Color? _separationColor;
        
        /// <summary>
        /// Sync all colors.
        /// </summary>
        public static void SyncColors()
        {
            _ = SeekColor;
            _ = PursueColor;
            _ = FleeColor;
            _ = EvadeColor;
            _ = WanderKey;
            _ = SeparationColor;
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
            ResetWanderColor();
            ResetSeparationColor();
        }
        
        /// <summary>
        /// Reset the seek color.
        /// </summary>
        public static void ResetSeekColor()
        {
            KaijuAgentsManager.ResetColor(SeekKey);
        }
        
        /// <summary>
        /// Reset the pursue color.
        /// </summary>
        public static void ResetPursueColor()
        {
            KaijuAgentsManager.ResetColor(PursueKey);
        }
        
        /// <summary>
        /// Reset the seek color.
        /// </summary>
        public static void ResetFleeColor()
        {
            KaijuAgentsManager.ResetColor(FleeKey);
        }
        
        /// <summary>
        /// Reset the evade color.
        /// </summary>
        public static void ResetEvadeColor()
        {
            KaijuAgentsManager.ResetColor(EvadeKey);
        }
        
        /// <summary>
        /// Reset the wander color.
        /// </summary>
        public static void ResetWanderColor()
        {
            KaijuAgentsManager.ResetColor(WanderKey);
        }
        
        /// <summary>
        /// Reset the separation color.
        /// </summary>
        public static void ResetSeparationColor()
        {
            KaijuAgentsManager.ResetColor(SeparationKey);
        }
        
        /// <summary>
        /// The key for if all visualizations should be rendered or only the selected agent.
        /// </summary>
        private const string VisualizationsActiveKey = "KAIJU_AGENTS_VISUALIZATIONS_ALL";
        
        /// <summary>
        /// Handle if all visualizations should be rendered or only the selected agent.
        /// </summary>
        public static bool VisualizationsActive
        {
            get
            {
                if (_visualizationsAll.HasValue)
                {
                    return _visualizationsAll.Value;
                }
                
                _visualizationsAll = EditorPrefs.GetBool(VisualizationsActiveKey, true);
                return _visualizationsAll.Value;
            }
            set
            {
                _visualizationsAll = value;
                EditorPrefs.SetBool(VisualizationsActiveKey, _visualizationsAll.Value);
            }
        }
        
        /// <summary>
        /// Handle if all visualizations should be rendered or only the selected agent.
        /// </summary>
        private static bool? _visualizationsAll;
        
        /// <summary>
        /// Reset if all visualizations should be rendered or only the selected agent.
        /// </summary>
        public static void ResetVisualizationsActive()
        {
            EditorPrefs.DeleteKey(VisualizationsActiveKey);
        }
        
        /// <summary>
        /// The key for how text should be displayed with visualizations.
        /// </summary>
        private const string VisualizationsTextKey = "KAIJU_AGENTS_VISUALIZATIONS_TEXT";
        
        /// <summary>
        ///  How text should be displayed with visualizations.
        /// </summary>
        public static VisualizationsTextMode VisualizationsText
        {
            get
            {
                if (_visualizationsText.HasValue)
                {
                    return _visualizationsText.Value;
                }
                
                _visualizationsText = (VisualizationsTextMode)EditorPrefs.GetInt(VisualizationsTextKey, (int)VisualizationsTextMode.All);
                return _visualizationsText.Value;
            }
            set
            {
                _visualizationsText = value;
                EditorPrefs.SetInt(VisualizationsTextKey, (int)_visualizationsText.Value);
            }
        }
        
        /// <summary>
        /// How text should be displayed with visualizations.
        /// </summary>
        private static VisualizationsTextMode? _visualizationsText;
        
        /// <summary>
        /// Reset how text should be displayed with visualizations.
        /// </summary>
        public static void ResetVisualizationsText()
        {
            EditorPrefs.DeleteKey(VisualizationsTextKey);
        }
        
        /// <summary>
        /// Visualizations text modes.
        /// </summary>
        public enum VisualizationsTextMode
        {
            /// <summary>
            /// Display all text fields.
            /// </summary>
            All = 0,
            
            /// <summary>
            /// Only display text fields of the selected agent.
            /// </summary>
            Selected = 1,
            
            /// <summary>
            /// Don't display any text fields.
            /// </summary>
            None = 2
        }
        
        /// <summary>
        /// Handle manually resetting the domain.
        /// </summary>
        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.SubsystemRegistration)]
        private static void InitOnPlayMode()
        {
            Movements.Clear();
            SyncColors();
            _ = VisualizationsActive;
            _ = VisualizationsText;
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