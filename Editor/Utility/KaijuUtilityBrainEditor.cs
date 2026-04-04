#if UNITY_EDITOR
using UnityEditor;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.UIElements;

namespace KaijuSolutions.Agents.Utility.Editor
{
    /// <summary>
    /// Custom inspector for <see cref="KaijuUtilityBrain"/>s to show utility scores.
    /// </summary>
    [CustomEditor(typeof(KaijuUtilityBrain), true)]
    public class KaijuUtilityBrainEditor : UnityEditor.Editor
    {
        /// <summary>
        /// Implement this method to make a custom UIElements inspector.
        /// </summary>
        /// <returns>The custom UIElements inspector.</returns>
        public override VisualElement CreateInspectorGUI()
        {
            VisualElement root = new();
            
            // Create the default inspector.
            InspectorElement.FillDefaultInspector(root, serializedObject, this);
            
            // Create a container for the scores.
            VisualElement scores = new() { style = { marginTop = 10 } };
            root.Add(scores);
            
            // Schedule an update task on the container at roughly 60 FPS.
            scores.schedule.Execute(() =>
            {
                // Clear the container first.
                scores.Clear();
                
                if (!Application.isPlaying || target is not KaijuUtilityBrain brain)
                {
                    return;
                }
                
                // Generate the labels.
                foreach ((KaijuUtilityAction action, float utility) utility in brain.Utilities)
                {
                    scores.Add(new Label($"{utility.action.name} - {utility.utility}"));
                }
            }).Every(16);
            
            return root;
        }
    }
}
#endif