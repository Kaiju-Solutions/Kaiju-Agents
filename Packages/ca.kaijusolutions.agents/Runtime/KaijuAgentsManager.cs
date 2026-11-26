using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using UnityEngine;
using Unity.Entities;
#if UNITY_EDITOR
using KaijuSolutions.Agents.Movement;
using UnityEditor;
#endif
namespace KaijuSolutions.Agents
{
    /// <summary>
    /// Manager <see cref="KaijuSolutions.Agents.KaijuAgent"/>s.
    /// </summary>
    [DisallowMultipleComponent]
    [DefaultExecutionOrder(int.MinValue + 3)]
#if UNITY_EDITOR
    [SelectionBase]
    [Icon("Packages/ca.kaijusolutions.agents/Editor/Icon.png")]
    [HelpURL("https://agents.kaijusolutions.ca/manual/manager.html")]
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
        public static KaijuAgentsManager Instance
        {
            get
            {
#if UNITY_EDITOR
                if (!Application.isPlaying)
                {
                    return null;
                }
#endif
                if (_instance != null)
                {
                    return _instance;
                }
                
                KaijuAgentsManager manager = FindAnyObjectByType<KaijuAgentsManager>();
                return manager != null ? manager : new GameObject("Kaiju Agents Manager") { isStatic = true }.AddComponent<KaijuAgentsManager>();
            }
        }

        // Early registrations can precede world initialization, especially with a custom bootstrap.
        private static KaijuAgentRegistry _pendingRegistry;

        internal static KaijuAgentRegistry Registry
        {
            get
            {
                var world = World.DefaultGameObjectInjectionWorld;
                var system = world?.IsCreated == true ? world.GetExistingSystemManaged<KaijuFrameSimulationSystem>() : null;
                if (system == null) return _pendingRegistry ??= new KaijuAgentRegistry();
                if (system.Registry == null)
                {
                    system.Registry = _pendingRegistry ?? new KaijuAgentRegistry();
                    _pendingRegistry = null;
                }
                return system.Registry;
            }
        }

        public static IReadOnlyCollection<KaijuAgent> Agents => Registry.Agents;
        public static int AgentsCount => Registry.AgentsCount;
#if UNITY_EDITOR
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
        /// The key for what color <see cref="KaijuSolutions.Agents.KaijuAgent"/> visualizations should be in the editor.
        /// </summary>
        private const string EditorAgentKey = "KAIJU_AGENTS_COLOR_AGENT";
        
        /// <summary>
        /// What color <see cref="KaijuSolutions.Agents.KaijuAgent"/> visualizations should be in the editor.
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
        /// What color <see cref="KaijuSolutions.Agents.KaijuAgent"/> visualizations should be in the editor.
        /// </summary>
        private static Color? _editorAgentColor;
        
        /// <summary>
        /// Reset the <see cref="KaijuSolutions.Agents.KaijuAgent"/> color in the editor.
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
            Domain();
            EditorApplication.playModeStateChanged -= Domain;
            EditorApplication.playModeStateChanged += Domain;
        }
        
        /// <summary>
        /// Handle manually resetting the domain.
        /// </summary>
        /// <param name="state">The current editor state change.</param>
        private static void Domain(PlayModeStateChange state)
        {
            if (state != PlayModeStateChange.ExitingPlayMode)
            {
                return;
            }
            
            EditorApplication.playModeStateChanged -= Domain;
            Domain();
        }
        
        /// <summary>
        /// Handle manually resetting the domain.
        /// </summary>
        private static void Domain()
        {
            _instance = null;
            _pendingRegistry = null;
            _ = EditorAgentColor;
            _editorAgentsLabelStyle = null;
        }
#endif
        /// <summary>
        /// Register an <see cref="KaijuSolutions.Agents.KaijuAgent"/> for movement.
        /// </summary>
        /// <param name="agent">The <see cref="KaijuSolutions.Agents.KaijuAgent"/> to register.</param>
        public static void Register(KaijuAgent agent) => Registry.Register(agent);
        
        /// <summary>
        /// Unregister an <see cref="KaijuSolutions.Agents.KaijuAgent"/> for movement.
        /// </summary>
        /// <param name="agent">The <see cref="KaijuSolutions.Agents.KaijuAgent"/> to unregister.</param>
        /// <param name="cache">If this <see cref="KaijuSolutions.Agents.KaijuAgent"/> should be cached.</param>
        public static void Unregister(KaijuAgent agent, bool cache = true) => Registry.Unregister(agent, cache);
        
        /// <summary>
        /// Handle all pending agents.
        /// </summary>
        internal static void BeginSensing() => Registry.BeginSensing();
        internal static void EndSensing() => Registry.EndSensing();

        /// <summary>Fill a caller-owned list with registered agents within the XZ or XYZ radius.</summary>
        public static int FindNearby(Vector3 origin, float radius, List<KaijuAgent> results, bool spherical = false) =>
            Registry.FindNearby(origin, radius, results, spherical);

        internal static void HandlePending(EntityManager entities) => Registry.HandlePending(entities);
        
        /// <summary>
        /// Get a cached <see cref="KaijuSolutions.Agents.KaijuAgent"/> to spawn.
        /// </summary>
        /// <param name="components">All components which must be found on the <see cref="KaijuSolutions.Agents.KaijuAgent"/>. This will check in children as well.</param>
        /// <typeparam name="T">The type of <see cref="KaijuSolutions.Agents.KaijuAgent"/>.</typeparam>
        /// <returns>A cached <see cref="KaijuSolutions.Agents.KaijuAgent"/> if one is found, otherwise NULL.</returns>
        public static T GetCached<T>(ICollection<string> components = null) where T : KaijuAgent => Registry.GetCached<T>(components);

        internal static KaijuAgent GetCachedPrefab(KaijuAgent prefab, bool flight) => Registry.GetCached<KaijuAgent>(flight: flight, prefab: prefab);

        internal static T GetCached<T>(ICollection<string> components, bool flight) where T : KaijuAgent => Registry.GetCached<T>(components, flight);
        
        /// <summary>
        /// Add an identifier to an <see cref="KaijuSolutions.Agents.KaijuAgent"/>. There is no use for manually calling this.
        /// </summary>
        /// <param name="agent">The <see cref="KaijuSolutions.Agents.KaijuAgent"/>.</param>
        /// <param name="identifier">The identifier.</param>
        public static void AddIdentifier(KaijuAgent agent, uint identifier) => Registry.AddIdentifier(agent, identifier);
        
        /// <summary>
        /// Remove an identifier from an <see cref="KaijuSolutions.Agents.KaijuAgent"/>. There is no use for manually calling this.
        /// </summary>
        /// <param name="agent">The <see cref="KaijuSolutions.Agents.KaijuAgent"/>.</param>
        /// <param name="identifier">The identifier.</param>
        public static void RemoveIdentifier(KaijuAgent agent, uint identifier) => Registry.RemoveIdentifier(agent, identifier);
        
        /// <summary>
        /// Get all <see cref="KaijuSolutions.Agents.KaijuAgent"/>s with a given identifier.
        /// </summary>
        /// <param name="identifier">The identifier.</param>
        /// <returns>All <see cref="KaijuSolutions.Agents.KaijuAgent"/>s with a given identifier.</returns>
        public static IReadOnlyCollection<KaijuAgent> IdentifiedAgents(uint identifier) => Registry.IdentifiedAgents(identifier);
        
        /// <summary>
        /// Get all <see cref="KaijuSolutions.Agents.KaijuAgent"/>s which have any of the given identifiers. The <see cref="KaijuSolutions.Agents.KaijuAgent"/>s are added to the identified parameter.
        /// </summary>
        /// <param name="identified">Updated to contain all <see cref="KaijuSolutions.Agents.KaijuAgent"/>s which were identified.</param>
        /// <param name="identifiers">The identifiers.</param>
        public static void IdentifiedAgents([NotNull] ICollection<KaijuAgent> identified, [NotNull] IEnumerable<uint> identifiers) => Registry.IdentifiedAgents(identified, identifiers);
        
        /// <summary>
        /// Get all <see cref="KaijuSolutions.Agents.KaijuAgent"/>s which have any of the given identifiers.
        /// </summary>
        /// <param name="identifiers">The identifiers.</param>
        /// <returns>All <see cref="KaijuSolutions.Agents.KaijuAgent"/>s which have any of the given identifier.</returns>
        public static HashSet<KaijuAgent> IdentifiedAgents([NotNull] IEnumerable<uint> identifiers) => Registry.IdentifiedAgents(identifiers);
#if UNITY_EDITOR
        /// <summary>
        /// Validate the identifiers of an <see cref="KaijuSolutions.Agents.KaijuAgent"/> in the editor. There is no use for manually calling this.
        /// </summary>
        /// <param name="agent">The <see cref="KaijuSolutions.Agents.KaijuAgent"/>.</param>
        public static void EditorValidateIdentifiers(KaijuAgent agent) => Registry.EditorValidateIdentifiers(agent);
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
            Application.runInBackground = true;
        }

#if UNITY_EDITOR
        /// <summary>
        /// Implement OnDrawGizmos if you want to draw gizmos that are also pickable and always drawn.
        /// </summary>
        [DrawGizmo(GizmoType.Selected | GizmoType.NonSelected)]
        private static void DrawAgent(KaijuAgent agent, GizmoType gizmo)
        {
            if (Application.isPlaying && agent.isActiveAndEnabled &&
                (KaijuMovementManager.EditorVisualizationsAll || (gizmo & GizmoType.Selected) != 0))
            {
                agent.EditorVisualize(AgentsCount > 1 && KaijuMovementManager.EditorVisualizationsLabels);
            }
        }
#endif
        /// <summary>
        /// Get a description of the object.
        /// </summary>
        /// <returns>A description of the object.</returns>
        public override string ToString()
        {
            return $"{name} - Kaiju Agents Manager - Agents: {AgentsCount}";
        }
        
        /// <summary>
        /// Implicit conversion to a short integer based <see cref="AgentsCount"/>.
        /// </summary>
        /// <param name="m">The <see cref="KaijuSolutions.Agents.KaijuAgent"/> manager.</param>
        /// <returns><see cref="AgentsCount"/>.</returns>
        public static implicit operator short(KaijuAgentsManager m) => (short)AgentsCount;
        
        /// <summary>
        /// Implicit conversion to a nullable short integer based <see cref="AgentsCount"/>.
        /// </summary>
        /// <param name="m">The <see cref="KaijuSolutions.Agents.KaijuAgent"/> manager.</param>
        /// <returns><see cref="AgentsCount"/>.</returns>
        public static implicit operator short?(KaijuAgentsManager m) => (short?)AgentsCount;
        
        /// <summary>
        /// Implicit conversion to an unsigned short integer based <see cref="AgentsCount"/>.
        /// </summary>
        /// <param name="m">The <see cref="KaijuSolutions.Agents.KaijuAgent"/> manager.</param>
        /// <returns><see cref="AgentsCount"/>.</returns>
        public static implicit operator ushort(KaijuAgentsManager m) => (ushort)AgentsCount;
        
        /// <summary>
        /// Implicit conversion to a nullable unsigned short integer based <see cref="AgentsCount"/>.
        /// </summary>
        /// <param name="m">The <see cref="KaijuSolutions.Agents.KaijuAgent"/> manager.</param>
        /// <returns><see cref="AgentsCount"/>.</returns>
        public static implicit operator ushort?(KaijuAgentsManager m) => (ushort?)AgentsCount;
        
        /// <summary>
        /// Implicit conversion to an integer based <see cref="AgentsCount"/>.
        /// </summary>
        /// <param name="m">The <see cref="KaijuSolutions.Agents.KaijuAgent"/> manager.</param>
        /// <returns><see cref="AgentsCount"/>.</returns>
        public static implicit operator int(KaijuAgentsManager m) => AgentsCount;
        
        /// <summary>
        /// Implicit conversion to a nullable integer based <see cref="AgentsCount"/>.
        /// </summary>
        /// <param name="m">The <see cref="KaijuSolutions.Agents.KaijuAgent"/> manager.</param>
        /// <returns><see cref="AgentsCount"/>.</returns>
        public static implicit operator int?(KaijuAgentsManager m) => AgentsCount;
        
        /// <summary>
        /// Implicit conversion to an unsigned integer based <see cref="AgentsCount"/>.
        /// </summary>
        /// <param name="m">The <see cref="KaijuSolutions.Agents.KaijuAgent"/> manager.</param>
        /// <returns><see cref="AgentsCount"/>.</returns>
        public static implicit operator uint(KaijuAgentsManager m) => (uint)AgentsCount;
        
        /// <summary>
        /// Implicit conversion to a nullable unsigned integer based <see cref="AgentsCount"/>.
        /// </summary>
        /// <param name="m">The <see cref="KaijuSolutions.Agents.KaijuAgent"/> manager.</param>
        /// <returns><see cref="AgentsCount"/>.</returns>
        public static implicit operator uint?(KaijuAgentsManager m) => (uint?)AgentsCount;
        
        /// <summary>
        /// Implicit conversion to a long integer based <see cref="AgentsCount"/>.
        /// </summary>
        /// <param name="m">The <see cref="KaijuSolutions.Agents.KaijuAgent"/> manager.</param>
        /// <returns><see cref="AgentsCount"/>.</returns>
        public static implicit operator long(KaijuAgentsManager m) => AgentsCount;
        
        /// <summary>
        /// Implicit conversion to a nullable long integer based <see cref="AgentsCount"/>.
        /// </summary>
        /// <param name="m">The <see cref="KaijuSolutions.Agents.KaijuAgent"/> manager.</param>
        /// <returns><see cref="AgentsCount"/>.</returns>
        public static implicit operator long?(KaijuAgentsManager m) => AgentsCount;
        
        /// <summary>
        /// Implicit conversion to an unsigned long integer based <see cref="AgentsCount"/>.
        /// </summary>
        /// <param name="m">The <see cref="KaijuSolutions.Agents.KaijuAgent"/> manager.</param>
        /// <returns><see cref="AgentsCount"/>.</returns>
        public static implicit operator ulong(KaijuAgentsManager m) => (ulong)AgentsCount;
        
        /// <summary>
        /// Implicit conversion to a nullable unsigned long integer based <see cref="AgentsCount"/>.
        /// </summary>
        /// <param name="m">The <see cref="KaijuSolutions.Agents.KaijuAgent"/> manager.</param>
        /// <returns><see cref="AgentsCount"/>.</returns>
        public static implicit operator ulong?(KaijuAgentsManager m) => (ulong?)AgentsCount;
    }
}