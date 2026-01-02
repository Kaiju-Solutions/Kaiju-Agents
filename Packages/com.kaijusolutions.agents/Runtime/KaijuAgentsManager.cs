using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using UnityEngine;
#if UNITY_EDITOR
using KaijuSolutions.Agents.Movement;
using UnityEditor;
#endif
namespace KaijuSolutions.Agents
{
    /// <summary>
    /// Manager <see cref="KaijuAgent"/>s.
    /// </summary>
    [DisallowMultipleComponent]
    [DefaultExecutionOrder(int.MinValue + 3)]
#if UNITY_EDITOR
    [SelectionBase]
    [Icon("Packages/com.kaijusolutions.agents/Editor/Icon.png")]
    [HelpURL("https://agents.kaijusolutions.ca/manual/getting-started.html")]
    [AddComponentMenu("Kaiju Solutions/Agents/Kaiju Agents Manager", int.MaxValue)]
#endif
    public class KaijuAgentsManager : KaijuBehaviour
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
        /// Cache <see cref="KaijuAgent"/>s paired to their identifiers.
        /// </summary>
        private static readonly Dictionary<uint, HashSet<KaijuAgent>> AgentIdentifiers = new();
        
        /// <summary>
        /// All <see cref="KaijuAgent"/>s.
        /// </summary>
        public static IReadOnlyCollection<KaijuAgent> Agents => AllAgents;
        
        /// <summary>
        /// The number of <see cref="KaijuAgent"/>s.
        /// </summary>
        public static int AgentsCount => AllAgents.Count;
        
        /// <summary>
        /// Cache all <see cref="KaijuAgent"/>s.
        /// </summary>
        private static readonly HashSet<KaijuAgent> AllAgents = new();
        
        /// <summary>
        /// Cache for <see cref="KaijuAgent"/>s which tick in the main update loop.
        /// </summary>
        private static readonly HashSet<KaijuAgent> TickAgents = new();
        
        /// <summary>
        /// Cache for <see cref="KaijuAgent"/>s which tick during the physics update loop.
        /// </summary>
        private static readonly HashSet<KaijuAgent> PhysicsAgents = new();
        
        /// <summary>
        /// Cache <see cref="KaijuAgent"/>s which have been disabled for reuse.
        /// </summary>
        private static readonly Dictionary<Type, HashSet<KaijuAgent>> DisabledAgents = new();
        
        /// <summary>
        /// Helper empty <see cref="KaijuAgent"/>s array for returning defaults.
        /// </summary>
        private static readonly KaijuAgent[] EmptyAgents = Array.Empty<KaijuAgent>();
#if UNITY_EDITOR
        /// <summary>
        /// All currently selected <see cref="KaijuAgent"/>s in the editor.
        /// </summary>
        private readonly HashSet<KaijuAgent> _editorSelectedAgents = new();
        
        /// <summary>
        /// Add a label of text in the scene view in the editor.
        /// </summary>
        /// <param name="position">The position to set it at.</param>
        /// <param name="text">The label itself</param>
        public static void EditorLabel(Vector3 position, [NotNull] string text)
        {
            Handles.Label(position + new Vector3(0, EditorLabelOffset, 0), text, EditorAgentsLabelStyle);
        }
        
        /// <summary>
        /// Add a label of text in the scene view in the editor.
        /// </summary>
        /// <param name="position">The position to set it at.</param>
        /// <param name="text">The label itself</param>
        /// <param name="color">The color for the text.</param>
        public static void EditorLabel(Vector3 position, [NotNull] string text, Color color)
        {
            EditorAgentsLabelStyle.normal.textColor = color;
            _editorAgentsLabelStyle.active.textColor = color;
            _editorAgentsLabelStyle.hover.textColor = color;
            Handles.Label(position + new Vector3(0, EditorLabelOffset, 0), text, _editorAgentsLabelStyle);
        }
        
        /// <summary>
        /// The label style to use for handles in the editor.
        /// </summary>
        private static GUIStyle EditorAgentsLabelStyle
        {
            get
            {
                _editorAgentsLabelStyle ??= new(GUI.skin.label)
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
                
                return _editorAgentsLabelStyle;
            }
        }
        
        /// <summary>
        /// The label style to use for handles in the editor.
        /// </summary>
        private static GUIStyle _editorAgentsLabelStyle;
        
        /// <summary>
        /// The key for how much to offset labels in the editor.
        /// </summary>
        private const string EditorOffsetKey = "KAIJU_AGENTS_LABEL_OFFSET";
        
        /// <summary>
        /// The offset for label placement in the editor.
        /// </summary>
        public static float EditorLabelOffset
        {
            get => _editorLabelOffset ?? EditorPrefs.GetFloat(EditorOffsetKey, 2.5f);
            set
            {
                _editorLabelOffset = value;
                EditorPrefs.SetFloat(EditorOffsetKey, _editorLabelOffset.Value);
            }
        }
        
        /// <summary>
        /// The offset for label placement in the editor.
        /// </summary>
        private static float? _editorLabelOffset;
        
        /// <summary>
        /// Reset the offset for label placement in the editor.
        /// </summary>
        public static void EditorResetLabelOffset()
        {
            EditorPrefs.DeleteKey(EditorOffsetKey);
        }
        
        /// <summary>
        /// The key for what color <see cref="KaijuAgent"/> visualizations should be in the editor.
        /// </summary>
        private const string EditorAgentKey = "KAIJU_AGENTS_COLOR_AGENT";
        
        /// <summary>
        /// What color <see cref="KaijuAgent"/> visualizations should be in the editor.
        /// </summary>
        public static Color EditorAgentColor
        {
            get
            {
                if (_editorAgentColor.HasValue)
                {
                    return _editorAgentColor.Value;
                }
                
                _editorAgentColor = EditorLoadColor(EditorAgentKey, Color.white);
                return _editorAgentColor.Value;
            }
            set
            {
                _editorAgentColor = value;
                EditorSaveColor(EditorAgentKey, _editorAgentColor.Value);
            }
        }
        
        /// <summary>
        /// What color <see cref="KaijuAgent"/> visualizations should be in the editor.
        /// </summary>
        private static Color? _editorAgentColor;
        
        /// <summary>
        /// Reset the <see cref="KaijuAgent"/> color in the editor.
        /// </summary>
        public static void EditorResetAgentColor()
        {
            EditorResetColor(EditorAgentKey);
        }
        
        /// <summary>
        /// Load a color from preferences in the editor.
        /// </summary>
        /// <param name="key">The color key to retrieve.</param>
        /// <param name="fallback">The fallback color if this is a default value.</param>
        /// <returns>The color loaded from preferences.</returns>
        public static Color EditorLoadColor([NotNull] string key, Color fallback)
        {
            float r = EditorPrefs.GetFloat($"{key}_R", fallback.r);
            float g = EditorPrefs.GetFloat($"{key}_G", fallback.g);
            float b = EditorPrefs.GetFloat($"{key}_B", fallback.b);
            float a = EditorPrefs.GetFloat($"{key}_A", fallback.a);
            return new(r, g, b, a);
        }
        
        /// <summary>
        /// Save a color to preferences in the editor.
        /// </summary>
        /// <param name="key">The color key to save.</param>
        /// <param name="color">The color to set.</param>
        public static void EditorSaveColor([NotNull] string key, Color color)
        {
            EditorPrefs.SetFloat($"{key}_R", color.r);
            EditorPrefs.SetFloat($"{key}_G", color.g);
            EditorPrefs.SetFloat($"{key}_B", color.b);
            EditorPrefs.SetFloat($"{key}_A", color.a);
        }
        
        /// <summary>
        /// Reset a color to preferences in the editor.
        /// </summary>
        /// <param name="key">The color key to reset.</param>
        public static void EditorResetColor([NotNull] string key)
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
            DisabledAgents.Clear();
            _ = EditorAgentColor;
            _editorAgentsLabelStyle = null;
        }
#endif
        /// <summary>
        /// Register an <see cref="KaijuAgent"/> for movement.
        /// </summary>
        /// <param name="agent">The <see cref="KaijuAgent"/> to register.</param>
        public static void Register(KaijuAgent agent)
        {
            // Ensure there is a manager.
            _ = Instance;
            
            // Remove from cached disabled.
            Type type = agent.GetType();
            if (DisabledAgents.TryGetValue(type, out HashSet<KaijuAgent> set))
            {
                set.Remove(agent);
                if (set.Count < 1)
                {
                    DisabledAgents.Remove(type);
                }
            }
            
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
        /// Unregister an <see cref="KaijuAgent"/> for movement.
        /// </summary>
        /// <param name="agent">The <see cref="KaijuAgent"/> to unregister.</param>
        /// <param name="cache">If this <see cref="KaijuAgent"/> should be cached.</param>
        public static void Unregister(KaijuAgent agent, bool cache = true)
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
            
            // Cache for reuse.
            if (cache)
            {
                Type type = agent.GetType();
                if (!DisabledAgents.TryGetValue(type, out HashSet<KaijuAgent> set))
                {
                    set = new(1);
                    DisabledAgents.Add(type, set);
                }
                
                set.Add(agent);
            }
#if UNITY_EDITOR
            if (_instance)
            {
                _instance._editorSelectedAgents.Remove(agent);
            }
#endif
        }
        
        /// <summary>
        /// Get a cached <see cref="KaijuAgent"/> to spawn.
        /// </summary>
        /// <typeparam name="T">The type of <see cref="KaijuAgent"/>.</typeparam>
        /// <returns>A cached <see cref="KaijuAgent"/> if one is found, otherwise NULL.</returns>
        public static KaijuAgent GetCached<T>() where T : KaijuAgent
        {
            // Nothing to do if no cached <see cref="KaijuAgent"/>s.
            Type type = typeof(T);
            if (!DisabledAgents.TryGetValue(type, out HashSet<KaijuAgent> set))
            {
                return null;
            }
            
            // Get the cached <see cref="KaijuAgent"/>.
            KaijuAgent agent = set.First();
            set.Remove(agent);
            
            if (set.Count < 1)
            {
                DisabledAgents.Remove(type);
            }
            
            return agent;
        }
        
        /// <summary>
        /// Add an identifier to an <see cref="KaijuAgent"/>. There is no use for manually calling this.
        /// </summary>
        /// <param name="agent">The <see cref="KaijuAgent"/>.</param>
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
        /// Remove an identifier from an <see cref="KaijuAgent"/>. There is no use for manually calling this.
        /// </summary>
        /// <param name="agent">The <see cref="KaijuAgent"/>.</param>
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
        /// Get all <see cref="KaijuAgent"/>s with a given identifier.
        /// </summary>
        /// <param name="identifier">The identifier.</param>
        /// <returns>All <see cref="KaijuAgent"/>s with a given identifier.</returns>
        public static IReadOnlyCollection<KaijuAgent> IdentifiedAgents(uint identifier)
        {
            return AgentIdentifiers.TryGetValue(identifier, out HashSet<KaijuAgent> set) ? set : EmptyAgents;
        }
        
        /// <summary>
        /// Get all <see cref="KaijuAgent"/>s which have any of the given identifiers. The <see cref="KaijuAgent"/>s are added to the identified parameter.
        /// </summary>
        /// <param name="identified">Updated to contain all <see cref="KaijuAgent"/>s which were identified.</param>
        /// <param name="identifiers">The identifiers.</param>
        public static void IdentifiedAgents([NotNull] ICollection<KaijuAgent> identified, [NotNull] IEnumerable<uint> identifiers)
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
        /// Get all <see cref="KaijuAgent"/>s which have any of the given identifiers.
        /// </summary>
        /// <param name="identifiers">The identifiers.</param>
        /// <returns>All <see cref="KaijuAgent"/>s which have any of the given identifier.</returns>
        public static HashSet<KaijuAgent> IdentifiedAgents([NotNull] IEnumerable<uint> identifiers)
        {
            HashSet<KaijuAgent> identified = new();
            IdentifiedAgents(identified, identifiers);
            return identified;
        }
#if UNITY_EDITOR
        /// <summary>
        /// Validate the identifiers of an <see cref="KaijuAgent"/> in the editor. There is no use for manually calling this.
        /// </summary>
        /// <param name="agent">The <see cref="KaijuAgent"/>.</param>
        public static void EditorValidateIdentifiers(KaijuAgent agent)
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
            _editorSelectedAgents.Clear();
            
            if (!Application.isPlaying)
            {
                return;
            }
            
            foreach (Transform t in Selection.transforms)
            {
                if (t.GetComponent<KaijuAgent>() is { } a)
                {
                    _editorSelectedAgents.Add(a);
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
            
            foreach (KaijuAgent agent in AllAgents)
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
            
            // All <see cref="KaijuAgent"/>s calculate their velocity.
            foreach (KaijuAgent agent in AllAgents)
            {
                agent.CalculateVelocity(delta);
            }
            
            // Step all physics <see cref="KaijuAgent"/>s.
            Move(PhysicsAgents, delta);
            
            // Run automatic <see cref="KaijuSensor"/>s.
            foreach (KaijuAgent agent in AllAgents)
            {
                agent.SenseAutomatic();
            }
            
            // Run <see cref="KaijuActuator"/>s.
            foreach (KaijuAgent agent in AllAgents)
            {
                agent.Act();
            }
        }
        
        /// <summary>
        /// Move a set of <see cref="KaijuAgent"/>s.
        /// </summary>
        /// <param name="agents">The <see cref="KaijuAgent"/>s to move.</param>
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
            KaijuMovementManager.EditorVisualizationsTextMode mode = KaijuMovementManager.EditorEditorVisualizationsText;
            
            if (!KaijuMovementManager.EditorVisualizationsActive)
            {
                bool text = AllAgents.Count > 1 && mode is KaijuMovementManager.EditorVisualizationsTextMode.All or KaijuMovementManager.EditorVisualizationsTextMode.Selected;
                EditorVisualize(_editorSelectedAgents, text, text);
                return;
            }
            
            bool all = AllAgents.Count > 1 &&  mode is KaijuMovementManager.EditorVisualizationsTextMode.All;
            EditorVisualize(AllAgents, all, all || mode is KaijuMovementManager.EditorVisualizationsTextMode.Selected);
        }
        
        /// <summary>
        /// Handle visualizations for <see cref="KaijuAgent"/>s in the editor.
        /// </summary>
        /// <param name="agents">The <see cref="KaijuAgent"/>s to render visualizations for.</param>
        /// <param name="all">If text should be run for all <see cref="KaijuAgent"/>s in this.</param>
        /// <param name="selected">If text should be run for selected <see cref="KaijuAgent"/>s in this.</param>
        private void EditorVisualize([NotNull] ISet<KaijuAgent> agents, bool all, bool selected)
        {
            foreach (KaijuAgent agent in agents)
            {
                if (agent)
                {
                    agent.EditorVisualize(all || (selected && _editorSelectedAgents.Contains(agent)));
                }
            }
        }
#endif
        /// <summary>
        /// Get a description of the object.
        /// </summary>
        /// <returns>A description of the object.</returns>
        public override string ToString()
        {
            return $"Kaiju Agents Manager - Agents: {AgentsCount}";
        }
        
        /// <summary>
        /// Implicit conversion to a short integer based <see cref="AgentsCount"/>.
        /// </summary>
        /// <param name="m">The <see cref="KaijuAgent"/> manager.</param>
        /// <returns><see cref="AgentsCount"/>.</returns>
        public static implicit operator short(KaijuAgentsManager m) => (short)AgentsCount;
        
        /// <summary>
        /// Implicit conversion to a nullable short integer based <see cref="AgentsCount"/>.
        /// </summary>
        /// <param name="m">The <see cref="KaijuAgent"/> manager.</param>
        /// <returns><see cref="AgentsCount"/>.</returns>
        public static implicit operator short?(KaijuAgentsManager m) => (short?)AgentsCount;
        
        /// <summary>
        /// Implicit conversion to an unsigned short integer based <see cref="AgentsCount"/>.
        /// </summary>
        /// <param name="m">The <see cref="KaijuAgent"/> manager.</param>
        /// <returns><see cref="AgentsCount"/>.</returns>
        public static implicit operator ushort(KaijuAgentsManager m) => (ushort)AgentsCount;
        
        /// <summary>
        /// Implicit conversion to a nullable unsigned short integer based <see cref="AgentsCount"/>.
        /// </summary>
        /// <param name="m">The <see cref="KaijuAgent"/> manager.</param>
        /// <returns><see cref="AgentsCount"/>.</returns>
        public static implicit operator ushort?(KaijuAgentsManager m) => (ushort?)AgentsCount;
        
        /// <summary>
        /// Implicit conversion to an integer based <see cref="AgentsCount"/>.
        /// </summary>
        /// <param name="m">The <see cref="KaijuAgent"/> manager.</param>
        /// <returns><see cref="AgentsCount"/>.</returns>
        public static implicit operator int(KaijuAgentsManager m) => AgentsCount;
        
        /// <summary>
        /// Implicit conversion to a nullable integer based <see cref="AgentsCount"/>.
        /// </summary>
        /// <param name="m">The <see cref="KaijuAgent"/> manager.</param>
        /// <returns><see cref="AgentsCount"/>.</returns>
        public static implicit operator int?(KaijuAgentsManager m) => AgentsCount;
        
        /// <summary>
        /// Implicit conversion to an unsigned integer based <see cref="AgentsCount"/>.
        /// </summary>
        /// <param name="m">The <see cref="KaijuAgent"/> manager.</param>
        /// <returns><see cref="AgentsCount"/>.</returns>
        public static implicit operator uint(KaijuAgentsManager m) => (uint)AgentsCount;
        
        /// <summary>
        /// Implicit conversion to a nullable unsigned integer based <see cref="AgentsCount"/>.
        /// </summary>
        /// <param name="m">The <see cref="KaijuAgent"/> manager.</param>
        /// <returns><see cref="AgentsCount"/>.</returns>
        public static implicit operator uint?(KaijuAgentsManager m) => (uint?)AgentsCount;
        
        /// <summary>
        /// Implicit conversion to a long integer based <see cref="AgentsCount"/>.
        /// </summary>
        /// <param name="m">The <see cref="KaijuAgent"/> manager.</param>
        /// <returns><see cref="AgentsCount"/>.</returns>
        public static implicit operator long(KaijuAgentsManager m) => AgentsCount;
        
        /// <summary>
        /// Implicit conversion to a nullable long integer based <see cref="AgentsCount"/>.
        /// </summary>
        /// <param name="m">The <see cref="KaijuAgent"/> manager.</param>
        /// <returns><see cref="AgentsCount"/>.</returns>
        public static implicit operator long?(KaijuAgentsManager m) => AgentsCount;
        
        /// <summary>
        /// Implicit conversion to an unsigned long integer based <see cref="AgentsCount"/>.
        /// </summary>
        /// <param name="m">The <see cref="KaijuAgent"/> manager.</param>
        /// <returns><see cref="AgentsCount"/>.</returns>
        public static implicit operator ulong(KaijuAgentsManager m) => (ulong)AgentsCount;
        
        /// <summary>
        /// Implicit conversion to a nullable unsigned long integer based <see cref="AgentsCount"/>.
        /// </summary>
        /// <param name="m">The <see cref="KaijuAgent"/> manager.</param>
        /// <returns><see cref="AgentsCount"/>.</returns>
        public static implicit operator ulong?(KaijuAgentsManager m) => (ulong?)AgentsCount;
    }
}