#if UNITY_EDITOR
using System.Collections.Generic;
using UnityEditor;
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
                
                //container.Add(new Label("TEST"));
                //root.Add(container);
            },
            keywords = new HashSet<string>(new[] { "Kaiju", "Agents", "AI", "Artificial Intelligence" })
        };
    }
}
#endif