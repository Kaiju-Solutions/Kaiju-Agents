#if UNITY_EDITOR
using System;
using System.Collections.Generic;
using KaijuSolutions.Agents.Movement;
using UnityEditor;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.UIElements;

/// <summary>
/// Provide a space to flag all settings for agents.
/// </summary>
internal static class KaijuAgentsSettings
{
    /// <summary>
    /// Create the UI for the settings menu.
    /// </summary>
    /// <returns>The UI for the settings menu.</returns>
    [SettingsProvider]
    public static SettingsProvider CreateProvider()
    {
        return new("Project/Kaiju Agents", SettingsScope.Project)
        {
            label = "Kaiju Agents",
            activateHandler = (_, root) =>
            {
                VisualElement container = new()
                {
                    style =
                    {
                        flexDirection = FlexDirection.Column
                    }
                };
                
                // Cache all actions that trigger a refresh.
                List<Action> refreshActions = new();
                
                // Add all buttons.
                container.Add(ColorSetting("Seek Color", () => KaijuMovementManager.SeekColor, color => KaijuMovementManager.SeekColor = color, KaijuMovementManager.ResetSeekColor, refreshActions, "The color for seek visualizations."));
                container.Add(ColorSetting("Pursue Color", () => KaijuMovementManager.PursueColor, color => KaijuMovementManager.PursueColor = color, KaijuMovementManager.ResetPursueColor, refreshActions, "The color for pursue visualizations."));
                container.Add(ColorSetting("Flee Color", () => KaijuMovementManager.FleeColor, color => KaijuMovementManager.FleeColor = color, KaijuMovementManager.ResetFleeColor, refreshActions, "The color for flee visualizations."));
                container.Add(ColorSetting("Evade Color", () => KaijuMovementManager.EvadeColor, color => KaijuMovementManager.EvadeColor = color, KaijuMovementManager.ResetEvadeColor, refreshActions, "The color for evade visualizations."));
                
                // Add a full reset button.
                Button resetAllButton = new(KaijuMovementManager.ResetColors)
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
}
#endif