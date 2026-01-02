using System;
using System.Collections.Generic;
#if UNITY_EDITOR
using UnityEditor;
using UnityEngine;
#endif
namespace KaijuSolutions.Agents.Movement
{
    /// <summary>
    /// Cache <see cref="KaijuMovement"/> objects for reuse.
    /// </summary>
    public static class KaijuMovementManager
    {
        /// <summary>
        /// Cache of all <see cref="KaijuMovement"/> instances.
        /// </summary>
        private static readonly Dictionary<Type, Queue<KaijuMovement>> Movements = new();
#if UNITY_EDITOR
        /// <summary>
        /// The key for the seek color preference in the editor.
        /// </summary>
        private const string EditorSeekKey = "KAIJU_AGENTS_COLOR_SEEK";
        
        /// <summary>
        /// The key for the seek color preference in the editor.
        /// </summary>
        private const string EditorPursueKey = "KAIJU_AGENTS_COLOR_PURSUE";
        
        /// <summary>
        /// The key for the seek color preference in the editor.
        /// </summary>
        private const string EditorFleeKey = "KAIJU_AGENTS_COLOR_FLEE";
        
        /// <summary>
        /// The key for the seek color preference in the editor.
        /// </summary>
        private const string EditorEvadeKey = "KAIJU_AGENTS_COLOR_EVADE";
        
        /// <summary>
        /// The key for the wander color preference in the editor.
        /// </summary>
        private const string EditorWanderKey = "KAIJU_AGENTS_COLOR_WANDER";
        
        /// <summary>
        /// The key for the separation color preference in the editor.
        /// </summary>
        private const string EditorSeparationKey = "KAIJU_AGENTS_COLOR_SEPARATION";
        
        /// <summary>
        /// The key for the obstacle avoidance color preference in the editor.
        /// </summary>
        private const string EditorObstacleAvoidanceKey = "KAIJU_AGENTS_OBSTACLE_AVOIDANCE_COLOR";
        
        /// <summary>
        /// The key for the path following color preference in the editor.
        /// </summary>
        private const string EditorPathFollowKey = "KAIJU_AGENTS_PATH_FOLLOWING_COLOR";
        
        /// <summary>
        /// Color for seek visuals in the editor.
        /// </summary>
        public static Color EditorSeekColor
        {
            get
            {
                if (_editorSeekColor.HasValue)
                {
                    return _editorSeekColor.Value;
                }
                
                _editorSeekColor = KaijuAgentsManager.EditorLoadColor(EditorSeekKey, Color.green);
                return _editorSeekColor.Value;
            }
            set
            {
                _editorSeekColor = value;
                KaijuAgentsManager.EditorSaveColor(EditorSeekKey, _editorSeekColor.Value);
            }
        }
        
        /// <summary>
        /// Color for seek visuals in the editor.
        /// </summary>
        private static Color? _editorSeekColor;
        
        /// <summary>
        /// Color for pursue visuals in the editor.
        /// </summary>
        public static Color EditorPursueColor
        {
            get
            {
                if (_editorPursueColor.HasValue)
                {
                    return _editorPursueColor.Value;
                }
                
                _editorPursueColor = KaijuAgentsManager.EditorLoadColor(EditorPursueKey, Color.cyan);
                return _editorPursueColor.Value;
            }
            set
            {
                _editorPursueColor = value;
                KaijuAgentsManager.EditorSaveColor(EditorPursueKey, _editorPursueColor.Value);
            }
        }
        
        /// <summary>
        /// Color for purse visuals in the editor.
        /// </summary>
        private static Color? _editorPursueColor;
        
        /// <summary>
        /// Color for flee visuals in the editor.
        /// </summary>
        public static Color EditorFleeColor
        {
            get
            {
                if (_editorFleeColor.HasValue)
                {
                    return _editorFleeColor.Value;
                }
                
                _editorFleeColor = KaijuAgentsManager.EditorLoadColor(EditorFleeKey, Color.red);
                return _editorFleeColor.Value;
            }
            set
            {
                _editorFleeColor = value;
                KaijuAgentsManager.EditorSaveColor(EditorFleeKey, _editorFleeColor.Value);
            }
        }
        
        /// <summary>
        /// Color for flee visuals in the editor.
        /// </summary>
        private static Color? _editorFleeColor;
        
        /// <summary>
        /// Color for evade visuals in the editor.
        /// </summary>
        public static Color EditorEvadeColor
        {
            get
            {
                if (_editorEvadeColor.HasValue)
                {
                    return _editorEvadeColor.Value;
                }
                
                _editorEvadeColor = KaijuAgentsManager.EditorLoadColor(EditorEvadeKey, Color.orange);
                return _editorEvadeColor.Value;
            }
            set
            {
                _editorEvadeColor = value;
                KaijuAgentsManager.EditorSaveColor(EditorEvadeKey, _editorEvadeColor.Value);
            }
        }
        
        /// <summary>
        /// Color for evade visuals in the editor.
        /// </summary>
        private static Color? _editorEvadeColor;
        
        /// <summary>
        /// Color for wander visuals in the editor.
        /// </summary>
        public static Color EditorWanderColor
        {
            get
            {
                if (_editorWanderColor.HasValue)
                {
                    return _editorWanderColor.Value;
                }
                
                _editorWanderColor = KaijuAgentsManager.EditorLoadColor(EditorWanderKey, Color.yellow);
                return _editorWanderColor.Value;
            }
            set
            {
                _editorWanderColor = value;
                KaijuAgentsManager.EditorSaveColor(EditorWanderKey, _editorWanderColor.Value);
            }
        }
        
        /// <summary>
        /// Color for wander visuals in the editor.
        /// </summary>
        private static Color? _editorWanderColor;
        
        /// <summary>
        /// Color for separation visuals in the editor.
        /// </summary>
        public static Color EditorSeparationColor
        {
            get
            {
                if (_editorSeparationColor.HasValue)
                {
                    return _editorSeparationColor.Value;
                }
                
                _editorSeparationColor = KaijuAgentsManager.EditorLoadColor(EditorSeparationKey, Color.violet);
                return _editorSeparationColor.Value;
            }
            set
            {
                _editorSeparationColor = value;
                KaijuAgentsManager.EditorSaveColor(EditorSeparationKey, _editorSeparationColor.Value);
            }
        }
        
        /// <summary>
        /// Color for separation visuals in the editor.
        /// </summary>
        private static Color? _editorSeparationColor;
        
        /// <summary>
        /// Color for obstacle avoidance visuals in the editor.
        /// </summary>
        public static Color EditorObstacleAvoidanceColor
        {
            get
            {
                if (_editorObstacleAvoidanceColor.HasValue)
                {
                    return _editorObstacleAvoidanceColor.Value;
                }
                
                _editorObstacleAvoidanceColor = KaijuAgentsManager.EditorLoadColor(EditorObstacleAvoidanceKey, Color.deepPink);
                return _editorObstacleAvoidanceColor.Value;
            }
            set
            {
                _editorObstacleAvoidanceColor = value;
                KaijuAgentsManager.EditorSaveColor(EditorObstacleAvoidanceKey, _editorObstacleAvoidanceColor.Value);
            }
        }
        
        /// <summary>
        /// Color for obstacle avoidance visuals in the editor.
        /// </summary>
        private static Color? _editorObstacleAvoidanceColor;
        
        /// <summary>
        /// Color for path following visuals in the editor.
        /// </summary>
        public static Color EditorPathFollowColor
        {
            get
            {
                if (_editorPathFollowColor.HasValue)
                {
                    return _editorPathFollowColor.Value;
                }
                
                _editorPathFollowColor = KaijuAgentsManager.EditorLoadColor(EditorPathFollowKey, Color.brown);
                return _editorPathFollowColor.Value;
            }
            set
            {
                _editorPathFollowColor = value;
                KaijuAgentsManager.EditorSaveColor(EditorPathFollowKey, _editorPathFollowColor.Value);
            }
        }
        
        /// <summary>
        /// Color for path following visuals in the editor.
        /// </summary>
        private static Color? _editorPathFollowColor;
        
        /// <summary>
        /// Sync all colors in the editor.
        /// </summary>
        public static void EditorSyncColors()
        {
            _ = EditorSeekColor;
            _ = EditorPursueColor;
            _ = EditorFleeColor;
            _ = EditorEvadeColor;
            _ = EditorWanderKey;
            _ = EditorSeparationColor;
            _ = EditorObstacleAvoidanceColor;
            _ = EditorPathFollowColor;
        }
        
        /// <summary>
        /// Reset all colors in the editor.
        /// </summary>
        public static void EditorResetColors()
        {
            EditorResetSeekColor();
            EditorResetPursueColor();
            EditorResetFleeColor();
            EditorResetEvadeColor();
            EditorResetWanderColor();
            EditorResetSeparationColor();
            EditorResetObstacleAvoidanceColor();
            EditorResetPathFollowColor();
        }
        
        /// <summary>
        /// Reset the seek color in the editor.
        /// </summary>
        public static void EditorResetSeekColor()
        {
            KaijuAgentsManager.EditorResetColor(EditorSeekKey);
        }
        
        /// <summary>
        /// Reset the pursue color in the editor.
        /// </summary>
        public static void EditorResetPursueColor()
        {
            KaijuAgentsManager.EditorResetColor(EditorPursueKey);
        }
        
        /// <summary>
        /// Reset the seek color in the editor.
        /// </summary>
        public static void EditorResetFleeColor()
        {
            KaijuAgentsManager.EditorResetColor(EditorFleeKey);
        }
        
        /// <summary>
        /// Reset the evade color in the editor.
        /// </summary>
        public static void EditorResetEvadeColor()
        {
            KaijuAgentsManager.EditorResetColor(EditorEvadeKey);
        }
        
        /// <summary>
        /// Reset the wander color in the editor.
        /// </summary>
        public static void EditorResetWanderColor()
        {
            KaijuAgentsManager.EditorResetColor(EditorWanderKey);
        }
        
        /// <summary>
        /// Reset the separation color in the editor.
        /// </summary>
        public static void EditorResetSeparationColor()
        {
            KaijuAgentsManager.EditorResetColor(EditorSeparationKey);
        }
        
        /// <summary>
        /// Reset the obstacle avoidance color in the editor.
        /// </summary>
        public static void EditorResetObstacleAvoidanceColor()
        {
            KaijuAgentsManager.EditorResetColor(EditorObstacleAvoidanceKey);
        }
        
        /// <summary>
        /// Reset the obstacle avoidance color in the editor.
        /// </summary>
        public static void EditorResetPathFollowColor()
        {
            KaijuAgentsManager.EditorResetColor(EditorPathFollowKey);
        }
        
        /// <summary>
        /// The key for if all editor visualizations should be rendered or only the selected <see cref="KaijuAgent"/>.
        /// </summary>
        private const string EditorVisualizationsActiveKey = "KAIJU_AGENTS_VISUALIZATIONS_ALL";
        
        /// <summary>
        /// Handle if all editor visualizations should be rendered or only the selected <see cref="KaijuAgent"/>.
        /// </summary>
        public static bool EditorVisualizationsActive
        {
            get
            {
                if (_editorVisualizationsAll.HasValue)
                {
                    return _editorVisualizationsAll.Value;
                }
                
                _editorVisualizationsAll = EditorPrefs.GetBool(EditorVisualizationsActiveKey, true);
                return _editorVisualizationsAll.Value;
            }
            set
            {
                _editorVisualizationsAll = value;
                EditorPrefs.SetBool(EditorVisualizationsActiveKey, _editorVisualizationsAll.Value);
            }
        }
        
        /// <summary>
        /// Handle if all editor visualizations should be rendered or only the selected <see cref="KaijuAgent"/>.
        /// </summary>
        private static bool? _editorVisualizationsAll;
        
        /// <summary>
        /// Reset if all editor visualizations should be rendered or only the selected <see cref="KaijuAgent"/>.
        /// </summary>
        public static void EditorResetVisualizationsActive()
        {
            EditorPrefs.DeleteKey(EditorVisualizationsActiveKey);
        }
        
        /// <summary>
        /// The key for how text should be displayed with editor visualizations.
        /// </summary>
        private const string EditorVisualizationsTextKey = "KAIJU_AGENTS_VISUALIZATIONS_TEXT";
        
        /// <summary>
        ///  How text should be displayed with editor visualizations.
        /// </summary>
        public static EditorVisualizationsTextMode EditorEditorVisualizationsText
        {
            get
            {
                if (_editorVisualizationsText.HasValue)
                {
                    return _editorVisualizationsText.Value;
                }
                
                _editorVisualizationsText = (EditorVisualizationsTextMode)EditorPrefs.GetInt(EditorVisualizationsTextKey, (int)EditorVisualizationsTextMode.All);
                return _editorVisualizationsText.Value;
            }
            set
            {
                _editorVisualizationsText = value;
                EditorPrefs.SetInt(EditorVisualizationsTextKey, (int)_editorVisualizationsText.Value);
            }
        }
        
        /// <summary>
        /// How text should be displayed with editor visualizations.
        /// </summary>
        private static EditorVisualizationsTextMode? _editorVisualizationsText;
        
        /// <summary>
        /// Reset how text should be displayed with editor visualizations.
        /// </summary>
        public static void EditorResetVisualizationsText()
        {
            EditorPrefs.DeleteKey(EditorVisualizationsTextKey);
        }
        
        /// <summary>
        /// Editor visualizations text modes.
        /// </summary>
        public enum EditorVisualizationsTextMode
        {
            /// <summary>
            /// Display all text fields.
            /// </summary>
            All = 0,
            
            /// <summary>
            /// Only display text fields of the selected <see cref="KaijuAgent"/>.
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
            EditorSyncColors();
            _ = EditorVisualizationsActive;
            _ = EditorEditorVisualizationsText;
        }
#endif
        /// <summary>
        /// Get a <see cref="KaijuMovement"/> instance.
        /// </summary>
        /// <typeparam name="T">The type of <see cref="KaijuMovement"/>.</typeparam>
        /// <returns>An instance of the <see cref="KaijuMovement"/>.</returns>
        public static T Get<T>() where T : KaijuMovement
        {
            if (Movements.TryGetValue(typeof(T), out Queue<KaijuMovement> movements) && movements.TryDequeue(out KaijuMovement result) && result is T valid)
            {
                return valid;
            }
            
            return null;
        }
        
        /// <summary>
        /// Return a <see cref="KaijuMovement"/> to the cache.
        /// </summary>
        /// <param name="movement">The <see cref="KaijuMovement"/> being returned.</param>
        /// <typeparam name="T">The type of <see cref="KaijuMovement"/>.</typeparam>
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