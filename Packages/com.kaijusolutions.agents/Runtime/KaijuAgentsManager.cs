using System.Diagnostics.CodeAnalysis;
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif
namespace KaijuSolutions.Agents
{
    /// <summary>
    /// Manager agents.
    /// </summary>
    public class KaijuAgentsManager : MonoBehaviour
    {
        /// <summary>
        /// The singleton manager instance.
        /// </summary>
        public static KaijuAgentsManager Instance => _instance ? _instance : new GameObject("Kaiju Agents Manager").AddComponent<KaijuAgentsManager>();
        
        /// <summary>
        /// The singleton manager instance.
        /// </summary>
        private static KaijuAgentsManager _instance;
#if UNITY_EDITOR
        /// <summary>
        /// The key for what color <see cref="KaijuAgent"/> gizmos should be.
        /// </summary>
        private const string AgentKey = "KAIJU_AGENTS_COLOR_AGENT";
        
        /// <summary>
        /// What color <see cref="KaijuAgent"/> gizmos should be.
        /// </summary>
        public static Color AgentColor
        {
            get
            {
                if (_agentColor.HasValue)
                {
                    return _agentColor.Value;
                }
                
                _agentColor = LoadColor(AgentKey, Color.white);
                return _agentColor.Value;
            }
            set
            {
                _agentColor = value;
                SaveColor(AgentKey, _agentColor.Value);
            }
        }
        
        /// <summary>
        /// What color <see cref="KaijuAgent"/> gizmos should be.
        /// </summary>
        private static Color? _agentColor;
        
        /// <summary>
        /// Reset the seek color.
        /// </summary>
        public static void ResetAgentColor()
        {
            AgentColor = Color.white;
        }
        
        /// <summary>
        /// Load a color from preferences.
        /// </summary>
        /// <param name="key">The color key to retrieve.</param>
        /// <param name="fallback">The fallback color if this is a default value.</param>
        /// <returns>The color loaded from preferences.</returns>
        public static Color LoadColor([NotNull] string key, Color fallback)
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
        public static void SaveColor([NotNull] string key, Color color)
        {
            EditorPrefs.SetFloat($"{key}_R", color.r);
            EditorPrefs.SetFloat($"{key}_G", color.g);
            EditorPrefs.SetFloat($"{key}_B", color.b);
            EditorPrefs.SetFloat($"{key}_A", color.a);
        }
        
        /// <summary>
        /// Handle manually resetting the domain.
        /// </summary>
        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.SubsystemRegistration)]
        private static void InitOnPlayMode()
        {
            _instance = null;
        }
#endif
        /// <summary>
        /// This function is called when the object becomes enabled and active.
        /// </summary>
        private void OnEnable()
        {
            // Nothing to do if this is already the singleton.
            if (_instance == this)
            {
                return;
            }
			
            // If there is a singleton but this is not it, destroy this.
            if (_instance != null && _instance != this)
            {
                Destroy(gameObject);
                return;
            }
			
            // Otherwise, set this as the singleton.
            _instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }
}