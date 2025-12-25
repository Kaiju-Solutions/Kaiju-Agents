using System;
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
    [DisallowMultipleComponent]
#if UNITY_EDITOR
    [SelectionBase]
    [Icon("Packages/com.kaijusolutions.agents/Editor/Icon.png")]
    [HelpURL("https://agents.kaijusolutions.ca/manual/getting-started.html")]
    [AddComponentMenu("Kaiju Solutions/Agents/Kaiju Agents Manager", int.MaxValue)]
#endif
    public class KaijuAgentsManager : MonoBehaviour
    {
        /// <summary>
        /// The singleton manager instance.
        /// </summary>
        private static KaijuAgentsManager _instance;
        
        /// <summary>
        /// The singleton manager instance.
        /// </summary>
        public static KaijuAgentsManager Instance => _instance ? _instance : new GameObject("Kaiju Agents Manager").AddComponent<KaijuAgentsManager>();
        
        /// <summary>
        /// Cache agents paired to their identifiers.
        /// </summary>
        private static readonly Dictionary<uint, HashSet<KaijuAgent>> AgentIdentifiers = new();
        
        /// <summary>
        /// All agents.
        /// </summary>
        public static IReadOnlyCollection<KaijuAgent> Agents => AllAgents;
        
        /// <summary>
        /// The number of agents.
        /// </summary>
        public static int AgentsCount => AllAgents.Count;
        
        /// <summary>
        /// Cache all agents.
        /// </summary>
        private static readonly HashSet<KaijuAgent> AllAgents = new();
        
        /// <summary>
        /// Cache for agents which tick in the main update loop.
        /// </summary>
        private static readonly HashSet<KaijuAgent> TickAgents = new();
        
        /// <summary>
        /// Cache for agents which tick during the physics update loop.
        /// </summary>
        private static readonly HashSet<KaijuAgent> PhysicsAgents = new();
        
        /// <summary>
        /// Helper empty agents array for returning defaults.
        /// </summary>
        private static readonly KaijuAgent[] EmptyAgents = Array.Empty<KaijuAgent>();
#if UNITY_EDITOR
        /// <summary>
        /// All currently selected agents.
        /// </summary>
        private readonly HashSet<KaijuAgent> _selectedAgents = new();
        
        /// <summary>
        /// Add a label of text in the scene view.
        /// </summary>
        /// <param name="position">The position to set it at.</param>
        /// <param name="text">The label itself</param>
        public static void Label(Vector3 position, [NotNull] string text)
        {
            Handles.Label(position + new Vector3(0, LabelOffset, 0), text, AgentsLabelStyle);
        }
        
        /// <summary>
        /// Add a label of text in the scene view.
        /// </summary>
        /// <param name="position">The position to set it at.</param>
        /// <param name="text">The label itself</param>
        /// <param name="color">The color for the text.</param>
        public static void Label(Vector3 position, [NotNull] string text, Color color)
        {
            AgentsLabelStyle.normal.textColor = color;
            _agentsLabelStyle.active.textColor = color;
            _agentsLabelStyle.hover.textColor = color;
            Handles.Label(position + new Vector3(0, LabelOffset, 0), text, _agentsLabelStyle);
        }
        
        /// <summary>
        /// The label style to use for handles.
        /// </summary>
        private static GUIStyle AgentsLabelStyle
        {
            get
            {
                _agentsLabelStyle ??= new(GUI.skin.label)
                {
                    normal =
                    {
                        textColor = Color.white
                    },
                    active =
                    {
                        textColor = Color.white
                    },
                    hover =
                    {
                        textColor = Color.white
                    },
                    fontSize = 12,
                    fontStyle = FontStyle.Normal,
                    alignment = TextAnchor.MiddleCenter
                };
                
                return _agentsLabelStyle;
            }
        }
        
        /// <summary>
        /// The label style to use for handles.
        /// </summary>
        private static GUIStyle _agentsLabelStyle;
        
        /// <summary>
        /// The key for how much to offset labels.
        /// </summary>
        private const string OffsetKey = "KAIJU_AGENTS_LABEL_OFFSET";
        
        /// <summary>
        /// The offset for label placement.
        /// </summary>
        public static float LabelOffset
        {
            get => _labelOffset ?? EditorPrefs.GetFloat(OffsetKey, 2.5f);
            set
            {
                _labelOffset = value;
                EditorPrefs.SetFloat(OffsetKey, _labelOffset.Value);
            }
        }
        
        /// <summary>
        /// The offset for label placement.
        /// </summary>
        private static float? _labelOffset;
        
        /// <summary>
        /// Reset the offset for label placement.
        /// </summary>
        public static void ResetLabelOffset()
        {
            EditorPrefs.DeleteKey(OffsetKey);
        }
        
        /// <summary>
        /// The key for what color <see cref="KaijuAgent"/> visualizations should be.
        /// </summary>
        private const string AgentKey = "KAIJU_AGENTS_COLOR_AGENT";
        
        /// <summary>
        /// What color <see cref="KaijuAgent"/> visualizations should be.
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
        /// What color <see cref="KaijuAgent"/> visualizations should be.
        /// </summary>
        private static Color? _agentColor;
        
        /// <summary>
        /// Reset the seek color.
        /// </summary>
        public static void ResetAgentColor()
        {
            ResetColor(AgentKey);
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
        /// Reset a color to preferences.
        /// </summary>
        /// <param name="key">The color key to reset.</param>
        public static void ResetColor([NotNull] string key)
        {
            EditorPrefs.DeleteKey($"{key}_R");
            EditorPrefs.DeleteKey($"{key}_G");
            EditorPrefs.DeleteKey($"{key}_B");
            EditorPrefs.DeleteKey($"{key}_A");
        }
        
        /// <summary>
        /// Handle manually resetting the domain.
        /// </summary>
        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.SubsystemRegistration)]
        private static void InitOnPlayMode()
        {
            _instance = null;
            AllAgents.Clear();
            TickAgents.Clear();
            PhysicsAgents.Clear();
            AgentIdentifiers.Clear();
            _ = AgentColor;
            _agentsLabelStyle = null;
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
            
            AllAgents.Add(agent);
            
            // Add identifiers.
            foreach (uint identifier in agent.Identifiers)
            {
                AddIdentifier(agent, identifier);
            }
            
            if (agent.PhysicsAgent)
            {
                PhysicsAgents.Add(agent);
            }
            else
            {
                TickAgents.Add(agent);
            }
        }
        
        /// <summary>
        /// Unregister an agent for movement.
        /// </summary>
        /// <param name="agent">The agent to unregister.</param>
        public static void Unregister(KaijuAgent agent)
        {
            AllAgents.Remove(agent);
            
            // Remove identifiers.
            foreach (uint identifier in agent.Identifiers)
            {
                RemoveIdentifier(agent, identifier);
            }
            
            if (agent.PhysicsAgent)
            {
                PhysicsAgents.Remove(agent);
            }
            else
            {
                TickAgents.Remove(agent);
            }
#if UNITY_EDITOR
            if (_instance)
            {
                _instance._selectedAgents.Remove(agent);
            }
#endif
        }
        
        /// <summary>
        /// Add an identifier to an agent. There is no use for manually calling this.
        /// </summary>
        /// <param name="agent">The agent.</param>
        /// <param name="identifier">The identifier.</param>
        public static void AddIdentifier(KaijuAgent agent, uint identifier)
        {
            if (!AgentIdentifiers.TryGetValue(identifier, out HashSet<KaijuAgent> set))
            {
                set = new();
                AgentIdentifiers.Add(identifier, set);
            }
            
            set.Add(agent);
        }
        
        /// <summary>
        /// Remove an identifier from an agent. There is no use for manually calling this.
        /// </summary>
        /// <param name="agent">The agent.</param>
        /// <param name="identifier">The identifier.</param>
        public static void RemoveIdentifier(KaijuAgent agent, uint identifier)
        {
            if (!AgentIdentifiers.TryGetValue(identifier, out HashSet<KaijuAgent> set))
            {
                return;
            }
            
            set.Remove(agent);
            if (set.Count < 1)
            {
                AgentIdentifiers.Remove(identifier);
            }
        }
        
        /// <summary>
        /// Get all agents with a given identifier.
        /// </summary>
        /// <param name="identifier">The identifier.</param>
        /// <returns>All agents with the given identifier.</returns>
        public static IReadOnlyCollection<KaijuAgent> IdentifiedAgents(uint identifier)
        {
            return AgentIdentifiers.TryGetValue(identifier, out HashSet<KaijuAgent> set) ? set : EmptyAgents;
        }
        
        /// <summary>
        /// Get all agents which have any of the given identifiers. The agents are added to the identified parameter.
        /// </summary>
        /// <param name="identified">Updated to contain all agents which were identified.</param>
        /// <param name="identifiers">The identifiers.</param>
        public static void IdentifiedAgents([NotNull] HashSet<KaijuAgent> identified, [NotNull] IEnumerable<uint> identifiers)
        {
            identified.Clear();
            
            foreach (uint identifier in identifiers)
            {
                if (!AgentIdentifiers.TryGetValue(identifier, out HashSet<KaijuAgent> set))
                {
                    continue;
                }
                
                foreach (KaijuAgent agent in set)
                {
                    identified.Add(agent);
                }
            }
        }
        
        /// <summary>
        /// Get all agents which have any of the given identifiers.
        /// </summary>
        /// <param name="identifiers">The identifiers.</param>
        /// <returns>All agents which have any of the given identifier.</returns>
        public static HashSet<KaijuAgent> IdentifiedAgents([NotNull] IEnumerable<uint> identifiers)
        {
            HashSet<KaijuAgent> identified = new();
            IdentifiedAgents(identified, identifiers);
            return identified;
        }
#if UNITY_EDITOR
        /// <summary>
        /// Validate the identifiers of an agent in the editor. There is no use for manually calling this.
        /// </summary>
        /// <param name="agent">The agent.</param>
        public static void ValidateIdentifiers(KaijuAgent agent)
        {
            // Store empty instances.
            HashSet<uint> empty = new(AgentIdentifiers.Count);
            
            // Remove all currently cached identifiers.
            foreach (KeyValuePair<uint, HashSet<KaijuAgent>> pair in AgentIdentifiers)
            {
                // Mark if this set is now empty.
                if (AgentIdentifiers[pair.Key].Remove(agent) && AgentIdentifiers[pair.Key].Count < 1)
                {
                    empty.Add(pair.Key);
                }
            }
            
            // Add all new identifiers, flagging ones which are no longer empty.
            foreach (uint identifier in agent.Identifiers)
            {
                AddIdentifier(agent, identifier);
                empty.Remove(identifier);
            }
            
            // Remove empty sets.
            foreach (uint identifier in empty)
            {
                AgentIdentifiers.Remove(identifier);
            }
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
            float delta = Time.deltaTime;
            
            Move(TickAgents, delta);
            
            foreach (KaijuAgent agent in Agents)
            {
                agent.Look(delta);
            }
        }
        
        /// <summary>
        /// Frame-rate independent MonoBehaviour.FixedUpdate message for physics calculations.
        /// </summary>
        private void FixedUpdate()
        {
            float delta = Time.deltaTime;
            
            foreach (KaijuAgent agent in Agents)
            {
                agent.CalculateVelocity(delta);
            }
            
            Move(PhysicsAgents, delta);
        }
        
        /// <summary>
        /// Move a set of agents.
        /// </summary>
        /// <param name="agents">The agents to move.</param>
        /// <param name="delta">The time step.</param>
        private static void Move(HashSet<KaijuAgent> agents, float delta)
        {
            foreach (KaijuAgent agent in agents)
            {
                agent.Move(delta);
            }
        }
#if UNITY_EDITOR
        /// <summary>
        /// Implement OnDrawGizmos if you want to draw gizmos that are also pickable and always drawn.
        /// </summary>
        private void OnDrawGizmos()
        {
            KaijuMovementManager.VisualizationsTextMode mode = KaijuMovementManager.VisualizationsText;
            
            if (!KaijuMovementManager.VisualizationsActive)
            {
                bool text = mode is KaijuMovementManager.VisualizationsTextMode.All or KaijuMovementManager.VisualizationsTextMode.Selected;
                Visualize(_selectedAgents, text, text);
                return;
            }
            
            bool all = mode is KaijuMovementManager.VisualizationsTextMode.All;
            Visualize(AllAgents, all, all || mode is KaijuMovementManager.VisualizationsTextMode.Selected);
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