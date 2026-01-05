#if UNITY_EDITOR
using System;
using System.Collections.Generic;
using KaijuSolutions.Agents;
using KaijuSolutions.Agents.Movement;
using UnityEditor;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.UIElements;

/// <summary>
/// Provide a space to flag all settings for agents.
/// </summary>
internal static class KaijuAgentsEditor
{
    /// <summary>
    /// Create a <see cref="KaijuTransformAgent"/>.
    /// </summary>
    [MenuItem("Tools/Kaiju Solutions/Agents/Create/Transform Agent", false, 0)]
    [MenuItem("GameObject/Kaiju Solutions/Agents/Transform Agent", false, 0)]
    private static void CreateTransformAgent()
    {
        CreateAgent();
    }
    
    /// <summary>
    /// Create a <see cref="KaijuRigidbodyAgent"/>.
    /// </summary>
    [MenuItem("Tools/Kaiju Solutions/Agents/Create/Rigidbody Agent", false, 1)]
    [MenuItem("GameObject/Kaiju Solutions/Agents/Rigidbody Agent", false, 1)]
    private static void CreateRigidbodyAgent()
    {
        CreateAgent(KaijuAgentType.Rigidbody);
    }
    
    /// <summary>
    /// Create a <see cref="KaijuRigidbodyAgent"/>.
    /// </summary>
    [MenuItem("Tools/Kaiju Solutions/Agents/Create/Character Agent", false, 2)]
    [MenuItem("GameObject/Kaiju Solutions/Agents/Character Agent", false, 2)]
    private static void CreateCharacterAgent()
    {
        CreateAgent(KaijuAgentType.Character);
    }
    
    /// <summary>
    /// Create a <see cref="KaijuRigidbodyAgent"/>.
    /// </summary>
    [MenuItem("Tools/Kaiju Solutions/Agents/Create/Navigation Agent", false, 3)]
    [MenuItem("GameObject/Kaiju Solutions/Agents/Navigation Agent", false, 3)]
    private static void CreateNavigationAgent()
    {
        CreateAgent(KaijuAgentType.Navigation);
    }
    
    /// <summary>
    /// Open the documentation.
    /// </summary>
    [MenuItem("Tools/Kaiju Solutions/Agents/Documentation", false, int.MaxValue)]
    private static void Documentation()
    {
        Application.OpenURL("https://agents.kaijusolutions.ca");
    }
    
    /// <summary>
    /// Create a <see cref="KaijuAgent"/>.
    /// </summary>
    /// <param name="type">The type of agent to spawn.</param>
    private static void CreateAgent(KaijuAgentType type = KaijuAgentType.Transform)
    {
        Selection.activeGameObject = KaijuAgents.Spawn(type, GetSpawnPosition());
    }
    
    /// <summary>
    /// Get a spawn position.
    /// </summary>
    /// <returns>A spawn position.</returns>
    private static Vector3 GetSpawnPosition()
    {
        // Spawn at the origin if there is somehow no scene.
        SceneView view = SceneView.lastActiveSceneView;
        if (view == null)
        {
            return Vector3.zero;
        }
        
        // Create a ray from the camera.
        Camera sceneCam = view.camera;
        Ray ray = new(sceneCam.transform.position, sceneCam.transform.forward);
        
        // Try to hit any colliders in the world to spawn on them.
        if (Physics.Raycast(ray, out RaycastHit hit, Mathf.Infinity))
        {
            return hit.point;
        }
        
        // Try to collide with the zero-plane.
        Plane zero = new(Vector3.up, Vector3.zero);
        if (!zero.Raycast(ray, out float distance))
        {
            // If it fails, we must be looking at the sky and be above the ground level, so spawn below us.
            return new(view.pivot.x, 0, view.pivot.z);
        }
        
        // Explicitly zero the point on the Y axis, as due to floating point decisions it may be slightly off.
        Vector3 p = ray.GetPoint(distance);
        return new(p.x, 0, p.z);
    }
    
    /// <summary>
    /// Create the UI for the settings menu.
    /// </summary>
    /// <returns>The UI for the settings menu.</returns>
    [SettingsProvider]
    private static SettingsProvider CreateProvider()
    {
        return new("Project/Kaiju Agents", SettingsScope.Project)
        {
            label = "Kaiju Agents",
            activateHandler = (_, root) =>
            {
                ScrollView container = new(ScrollViewMode.Vertical)
                {
                    style =
                    {
                        flexDirection = FlexDirection.Column
                    }
                };
                
                // Cache all actions that trigger a refresh.
                List<Action> refreshActions = new();
                
                // Add visualization configurations.
                container.Add(Header("Visualizations"));
                container.Add(ToggleSetting("All Agents", () => KaijuMovementManager.EditorVisualizationsAll, value => KaijuMovementManager.EditorVisualizationsAll = value, KaijuMovementManager.EditorResetVisualizationsAll, refreshActions, "If all visualizations should be rendered for all agents or only the selected agent."));
                container.Add(ToggleSetting("Labels", () => KaijuMovementManager.EditorVisualizationsLabels, value => KaijuMovementManager.EditorVisualizationsLabels = value, KaijuMovementManager.EditorResetVisualizationsLabels, refreshActions, "If labels should be displayed for the agents. If there is only one agent in the scene, no label is displayed regardless of this setting."));
                container.Add(FloatSetting("Label Offset", () => KaijuAgentsManager.EditorLabelOffset, value => KaijuAgentsManager.EditorLabelOffset = value, KaijuAgentsManager.EditorResetLabelOffset, refreshActions, "How much to offset labels in the scene view."));
                
                // Add options for all colors for visualizations.
                container.Add(Header("Colors"));
                container.Add(ColorSetting("Agents", () => KaijuAgentsManager.EditorAgentColor, color => KaijuAgentsManager.EditorAgentColor = color, KaijuAgentsManager.EditorResetAgentColor, refreshActions, "The color for visualizations which are directly part of the agent."));
                container.Add(ColorSetting("Seek", () => KaijuMovementManager.EditorSeekColor, color => KaijuMovementManager.EditorSeekColor = color, KaijuMovementManager.EditorResetSeekColor, refreshActions, "The color for seek visualizations."));
                container.Add(ColorSetting("Pursue", () => KaijuMovementManager.EditorPursueColor, color => KaijuMovementManager.EditorPursueColor = color, KaijuMovementManager.EditorResetPursueColor, refreshActions, "The color for pursue visualizations."));
                container.Add(ColorSetting("Flee", () => KaijuMovementManager.EditorFleeColor, color => KaijuMovementManager.EditorFleeColor = color, KaijuMovementManager.EditorResetFleeColor, refreshActions, "The color for flee visualizations."));
                container.Add(ColorSetting("Evade", () => KaijuMovementManager.EditorEvadeColor, color => KaijuMovementManager.EditorEvadeColor = color, KaijuMovementManager.EditorResetEvadeColor, refreshActions, "The color for evade visualizations."));
                container.Add(ColorSetting("Wander", () => KaijuMovementManager.EditorWanderColor, color => KaijuMovementManager.EditorWanderColor = color, KaijuMovementManager.EditorResetWanderColor, refreshActions, "The color for wander visualizations."));
                container.Add(ColorSetting("Separation", () => KaijuMovementManager.EditorSeparationColor, color => KaijuMovementManager.EditorSeparationColor = color, KaijuMovementManager.EditorResetSeparationColor, refreshActions, "The color for separation visualizations."));
                container.Add(ColorSetting("Obstacle Avoidance", () => KaijuMovementManager.EditorObstacleAvoidanceColor, color => KaijuMovementManager.EditorObstacleAvoidanceColor = color, KaijuMovementManager.EditorResetObstacleAvoidanceColor, refreshActions, "The color for obstacle avoidance visualizations."));
                container.Add(ColorSetting("Path Following", () => KaijuMovementManager.EditorPathFollowColor, color => KaijuMovementManager.EditorPathFollowColor = color, KaijuMovementManager.EditorResetPathFollowColor, refreshActions, "The color for path following visualizations."));
                
                // Add a full reset button.
                Button resetAllButton = new(KaijuMovementManager.EditorResetColors)
                {
                    text = "Reset All Colors",
                    style =
                    {
                        marginTop = 10
                    }
                };
                resetAllButton.clicked += () =>
                {
                    foreach (Action refresh in refreshActions)
                    {
                        refresh();
                    }
                };
                container.Add(resetAllButton);
                root.Add(container);
            },
            keywords = new HashSet<string>(new[] { "Kaiju", "Agents", "AI", "Artificial Intelligence" })
        };
    }
    
    /// <summary>
    /// Add a toggle setting element.
    /// </summary>
    /// <param name="label">The label to use.</param>
    /// <param name="get">The getter method.</param>
    /// <param name="set">The setter method.</param>
    /// <param name="reset">The resetting method.</param>
    /// <param name="refresh">What to apply when refreshing.</param>
    /// <param name="tooltip">What tooltip to add.</param>
    /// <returns>A toggle settings element.</returns>
    private static VisualElement ToggleSetting(string label, Func<bool> get, Action<bool> set, Action reset, List<Action> refresh, string tooltip = null)
    {
        // Set the base styling.
        VisualElement row = new()
        {
            style =
            {
                flexDirection = FlexDirection.Row,
                marginBottom = 5
            },
            tooltip = tooltip
        };
        
        // Define the toggle itself.
        Toggle toggle = new(label)
        {
            value = get(),
            style =
            {
                flexGrow = 1
            }
        };
        toggle.RegisterValueChangedCallback(evt => set(evt.newValue));
        
        // Bind refresh actions.
        refresh.Add(Refresh);
        
        // Create the reset button.
        Button resetButton = new(() =>
        {
            reset();
            Refresh();
        })
        {
            text = "Reset"
        };
        
        // Add each to the fields.
        row.Add(toggle);
        row.Add(resetButton);
        
        return row;
        
        // Refresh command.
        void Refresh()
        {
            toggle.value = get();
        }
    }

    /// <summary>
    /// Add a header element.
    /// </summary>
    /// <param name="label">The label to use.</param>
    /// <returns>A header element.</returns>
    private static VisualElement Header(string label)
    {
        return new Label(label)
        {
            style =
            {
                unityFontStyleAndWeight = FontStyle.Bold,
                fontSize = 14,
                marginTop = 10,
                marginBottom = 5,
                marginLeft = 2.5f
            }
        };
    }
    
    /// <summary>
    /// Add a color setting element.
    /// </summary>
    /// <param name="label">The label to use.</param>
    /// <param name="get">The getter method.</param>
    /// <param name="set">The setter method.</param>
    /// <param name="reset">The resetting method.</param>
    /// <param name="refresh">What to apply when resetting.</param>
    /// <param name="tooltip">What tooltip to add.</param>
    /// <returns>A color settings element.</returns>
    private static VisualElement ColorSetting(string label, Func<Color> get, Action<Color> set, Action reset, List<Action> refresh, string tooltip = null)
    {
        // Set the base stying.
        VisualElement row = new()
        {
            style =
            {
                flexDirection = FlexDirection.Row,
                marginBottom = 5
            },
            tooltip = tooltip
        };
        
        // Define the color field itself.
        ColorField colorField = new(label)
        {
            value = get(),
            style =
            {
                flexGrow = 1
            }
        };
        colorField.RegisterValueChangedCallback(evt => set(evt.newValue));
        
        // Bind refresh actions.
        refresh.Add(Refresh);
        
        // Create the reset button.
        Button resetButton = new(() =>
        {
            reset();
            Refresh();
        })
        {
            text = "Reset"
        };
        
        // Add each to the fields.
        row.Add(colorField);
        row.Add(resetButton);
        
        return row;
        
        // Refresh command.
        void Refresh()
        {
            colorField.value = get();
        }
    }

    /// <summary>
    /// Add a float setting element.
    /// </summary>
    /// <param name="label">The label to use.</param>
    /// <param name="get">The getter method.</param>
    /// <param name="set">The setter method.</param>
    /// <param name="reset">The resetting method.</param>
    /// <param name="refresh">What to apply when resetting.</param>
    /// <param name="tooltip">What tooltip to add.</param>
    /// <returns>A float settings element.</returns>
    private static VisualElement FloatSetting(string label, Func<float> get, Action<float> set, Action reset, List<Action> refresh, string tooltip = null)
    {
        // Set the base styling.
        VisualElement row = new()
        {
            style =
            {
                flexDirection = FlexDirection.Row,
                marginBottom = 5
            },
            tooltip = tooltip
        };
        
        // Define the float field itself.
        FloatField floatField = new(label)
        {
            value = get(),
            style =
            {
                flexGrow = 1
            }
        };
        floatField.RegisterValueChangedCallback(evt => set(evt.newValue));
        
        // Bind refresh actions.
        refresh.Add(Refresh);
        
        // Create the reset button.
        Button resetButton = new(() =>
        {
            reset();
            Refresh();
        })
        {
            text = "Reset"
        };
        
        // Add each to the fields.
        row.Add(floatField);
        row.Add(resetButton);
        
        return row;
        
        // Refresh command.
        void Refresh()
        {
            floatField.value = get();
        }
    }
}
#endif