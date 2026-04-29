#if UNITY_EDITOR && COM_UNITY_AI_ASSISTANT
using Unity.AI.MCP.Editor.ToolRegistry;
using UnityEditor;
using UnityEngine;

namespace KaijuSolutions.Agents.Assistant.Editor
{
    /// <summary>
    /// Handle core MCP interactions for <see href="https://docs.unity3d.com/Packages/com.unity.ai.assistant@latest">Unity AI Assistant</see>.
    /// </summary>
    public static class KaijuAssistantEditor
    {
        /// <summary>
        /// MCP tool to spawn an agent.
        /// </summary>
        /// <param name="parameters">The spawning parameters.</param>
        /// <returns>If the agent was successfully spawned or not.</returns>
        [McpTool("spawn_agent", "Places an agent into the level.", EnabledByDefault = true, Groups = new []{"Kaiju Agents"})]
        public static object McpSpawn(McpSpawnParameters parameters)
        {
            // Load the prefab.
            KaijuAgent prefab = AssetDatabase.LoadAssetAtPath<KaijuAgent>(parameters.Prefab);
            if (prefab == null)
            {
                return new { success = false, message = $"Prefab \"{parameters.Prefab}\" does not exist or does not have a \"KaijuAgent\" component." };
            }
            
            // If no name is assigned, use the prefab's name.
            if (string.IsNullOrWhiteSpace(parameters.Name))
            {
                parameters.Name = prefab.name;
            }
            
            // Spawn the agent.
            KaijuAgents.Spawn(KaijuAgentType.Transform, parameters.Position, Quaternion.Euler(0f, parameters.Rotation, 0f), Application.isPlaying, prefab, parameters.Name);
            return new { success = true, message = $"Spawned an instance of \"{parameters.Prefab}\" as \"{parameters.Name}\" at position ({parameters.Position.x}, {parameters.Position.y}, {parameters.Position.z}) and a rotation angle of {parameters.Rotation} degrees." };
        }
    }
    
    /// <summary>
    /// Spawning parameters for MCP interactions.
    /// </summary>
    public class McpSpawnParameters
    {
        /// <summary>
        /// The path to the agent prefab to load.
        /// </summary>
        [McpDescription("The path to the agent prefab to load.", Required = false)]
        public string Prefab { get; set; } = null;
        
        /// <summary>
        /// The name to give the spawned agent.
        /// </summary>
        [McpDescription("The name to give the spawned agent.", Required = false)]
        public string Name { get; set; } = "Agent";
        
        /// <summary>
        /// The position to spawn the agent at.
        /// </summary>
        [McpDescription("The position to spawn the agent at.", Required = false)]
        public Vector3 Position { get; set; } = Vector3.zero;
        
        /// <summary>
        /// The orientation in degrees around the Y axes to spawn the agent facing.
        /// </summary>
        [McpDescription("The orientation in degrees around the Y axes to spawn the agent facing.", Required = false)]
        public float Rotation { get; set; } = 0f;
    }
}
#endif