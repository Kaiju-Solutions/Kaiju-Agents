using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using UnityEngine;
#if UNITY_EDITOR
using KaijuSolutions.Agents.Movement;
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
        
        /// <summary>
        /// Cache for agents which tick in the main update loop.
        /// </summary>
        private static readonly HashSet<KaijuAgent> Agents = new();
        
        /// <summary>
        /// Cache for agents which tick during the phyics update loop.
        /// </summary>
        private static readonly HashSet<KaijuAgent> PhysicsAgents = new();
#if UNITY_EDITOR
        /// <summary>
        /// All currently selected agents.
        /// </summary>
        private readonly HashSet<KaijuAgent> _selectedAgents = new();
        
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
            Agents.Clear();
            PhysicsAgents.Clear();
            _ = AgentColor;
        }
#endif
        /// <summary>
        /// Register an agent for movement.
        /// </summary>
        /// <param name="agent">The agent to register.</param>
        public static void Register(KaijuAgent agent)
        {
            // Ensure there is a manager.
            _ = Instance;
            
            if (agent.PhysicsAgent)
            {
                PhysicsAgents.Add(agent);
            }
            else
            {
                Agents.Add(agent);
            }
        }
        
        /// <summary>
        /// Unregister an agent for movement.
        /// </summary>
        /// <param name="agent">The agent to unregister.</param>
        public static void Unregister(KaijuAgent agent)
        {
            if (agent.PhysicsAgent)
            {
                PhysicsAgents.Remove(agent);
            }
            else
            {
                Agents.Remove(agent);
            }
#if UNITY_EDITOR
            if (_instance)
            {
                _instance._selectedAgents.Remove(agent);
            }
#endif
        }
        
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
#if UNITY_EDITOR
            Selection.selectionChanged += SelectionChanged;
            SelectionChanged();
#endif
        }
#if UNITY_EDITOR
        /// <summary>
        /// This function is called when the behaviour becomes disabled.
        /// </summary>
        private void OnDisable()
        {
            Selection.selectionChanged -= SelectionChanged;
        }
        
        /// <summary>
        /// See if the active selection has changed.
        /// </summary>
        private void SelectionChanged()
        {
            _selectedAgents.Clear();
            
            if (!Application.isPlaying)
            {
                return;
            }
            
            foreach (Transform t in Selection.transforms)
            {
                if (t.GetComponent<KaijuAgent>() is { } a)
                {
                    _selectedAgents.Add(a);
                }
            }
        }
#endif
        /// <summary>
        /// Update is called every frame, if the MonoBehaviour is enabled.
        /// </summary>
        private void Update()
        {
            Move(Agents);
            Look(Agents);
            Look(PhysicsAgents);
        }
        
        /// <summary>
        /// Frame-rate independent MonoBehaviour.FixedUpdate message for physics calculations.
        /// </summary>
        private void FixedUpdate()
        {
            Move(PhysicsAgents);
        }
        
        /// <summary>
        /// Move a set of agents.
        /// </summary>
        /// <param name="agents">The agents to move.</param>
        private static void Move(HashSet<KaijuAgent> agents)
        {
            float delta = Time.deltaTime;
            
            foreach (KaijuAgent agent in agents)
            {
                if (agent)
                {
                    agent.Move(delta);
                }
            }
        }
        
        /// <summary>
        /// Handle looking for agents.
        /// </summary>
        /// <param name="agents">The agents to handle the looking for.</param>
        private static void Look(HashSet<KaijuAgent> agents)
        {
            foreach (KaijuAgent agent in agents)
            {
                if (agent)
                {
                    agent.Look();
                }
            }
        }
#if UNITY_EDITOR
        /// <summary>
        /// Implement OnDrawGizmos if you want to draw gizmos that are also pickable and always drawn.
        /// </summary>
        private void OnDrawGizmos()
        {
            KaijuMovementManager.GizmosTextMode mode = KaijuMovementManager.GizmosText;
            
            if (!KaijuMovementManager.GizmosAll)
            {
                bool text = mode is KaijuMovementManager.GizmosTextMode.All or KaijuMovementManager.GizmosTextMode.Selected;
                Visualize(_selectedAgents, text, text);
                return;
            }
            
            bool all = mode is KaijuMovementManager.GizmosTextMode.All;
            bool selected = all || mode is KaijuMovementManager.GizmosTextMode.Selected;
            Visualize(Agents, all, selected);
            Visualize(PhysicsAgents, all, selected);
        }

        /// <summary>
        /// Handle visualizations for agents.
        /// </summary>
        /// <param name="agents">The agents to render visualizations for.</param>
        /// <param name="all">If text should be run for all agents in this.</param>
        /// <param name="selected">If text should be run for selected agents in this.</param>
        private void Visualize(HashSet<KaijuAgent> agents, bool all, bool selected)
        {
            foreach (KaijuAgent agent in agents)
            {
                if (agent)
                {
                    agent.Visualize(all || (selected && _selectedAgents.Contains(agent)));
                }
            }
        }
#endif
    }
}