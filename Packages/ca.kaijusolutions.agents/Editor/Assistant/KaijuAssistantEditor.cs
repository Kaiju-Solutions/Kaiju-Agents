#if UNITY_EDITOR && COM_UNITY_AI_ASSISTANT
using System.IO;
using KaijuSolutions.Agents.Extensions;
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
        public static object McpSpawnAgent(McpSpawnAgentParameters parameters)
        {
            // Load the prefab.
            KaijuAgent prefab = AssetDatabase.LoadAssetAtPath<KaijuAgent>(parameters.Path);
            if (prefab == null)
            {
                return new { success = false, message = $"Prefab \"{parameters.Path}\" does not exist or does not have a \"KaijuAgent\" component." };
            }
            
            // If no name is assigned, use the prefab's name.
            if (string.IsNullOrWhiteSpace(parameters.Name))
            {
                parameters.Name = prefab.name;
            }
            
            // Spawn the agent.
            KaijuAgents.Spawn(KaijuAgentType.Transform, parameters.Position.Expand(), Quaternion.Euler(0f, parameters.Rotation, 0f), Application.isPlaying, prefab, parameters.Name);
            return new { success = true, message = $"Spawned an instance of \"{parameters.Path}\" as \"{parameters.Name}\" at position ({parameters.Position.x}, {parameters.Position.y}) and a rotation angle of {parameters.Rotation} degrees." };
        }
        
        /// <summary>
        /// MCP tool to create an agent prefab.
        /// </summary>
        /// <param name="parameters">The creation parameters.</param>
        /// <returns>If the prefab was successfully created or not.</returns>
        [McpTool("create_agent_prefab", "Creates an agent prefab. Cannot be performed while in play mode.", EnabledByDefault = true, Groups = new []{"Kaiju Agents"})]
        public static object McpCreateAgentPrefab(McpCreateAgentPrefabParameters parameters)
        {
            // Only allow this when in edit mode.
            if (Application.isPlaying)
            {
                return new { success = false, message = "Cannot create agent prefabs when in play mode." };
            }
            
            // All assets must start with "Assets".
            if (!parameters.Path.StartsWith("Assets"))
            {
                parameters.Path = Path.Combine("Assets", parameters.Path);
            }
            
            // Automatically append the ".prefab" extension if it was forgotten.
            if (!parameters.Path.EndsWith(".prefab"))
            {
                parameters.Path += ".prefab";
            }
            
            // Ensure the folder exists.
            string directoryPath = Path.GetDirectoryName(parameters.Path);
            if (directoryPath != null && !Directory.Exists(directoryPath))
            {
                Directory.CreateDirectory(directoryPath);
            }
            
            KaijuAgentType type;
            switch (parameters.Type.ToUpper())
            {
                case "TRANSFORM":
                    type = KaijuAgentType.Transform;
                    break;
                case "RIGIDBODY":
                    type = KaijuAgentType.Rigidbody;
                    break;
                case "CHARACTER":
                    type = KaijuAgentType.Character;
                    break;
                case "NAVIGATION":
                    type = KaijuAgentType.Navigation;
                    break;
                default:
                    return new { success = false, message = $"Unknown agent type of \"{parameters.Type}\"." };
            }
            
            // Spawn one into the active scene.
            KaijuAgent instance = KaijuAgents.Spawn(type, Vector3.zero, Quaternion.identity, false, null, null, parameters.Body, parameters.Eyes, parameters.Components);
            
            // Try to save it as a prefab.
            PrefabUtility.SaveAsPrefabAsset(instance.gameObject, parameters.Path, out bool success);
            
            // Destroy the instance in the scene.
            Object.DestroyImmediate(instance.gameObject);
            
            // Indicate success.
            return success ? new { success = true, message = $"Created agent prefab \"{parameters.Path}\"." } : new { success = false, message = $"Failed to create agent prefab \"{parameters.Path}\"." };
        }
        
        /// <summary>
        /// MCP tool to place a wall in the scene.
        /// </summary>
        /// <param name="parameters">The placing parameters.</param>
        /// <returns>That the wall was placed.</returns>
        [McpTool("place_wall", "Place a basic wall in the scene.", EnabledByDefault = true, Groups = new []{"Kaiju Agents"})]
        public static object McpPlaceWall(McpPlaceWall parameters)
        {
            // Create the wall.
            GameObject wall = GameObject.CreatePrimitive(PrimitiveType.Cube);
            
            // Ensure a valid scale and assign it.
            parameters.Scale = new(Mathf.Abs(parameters.Scale.x), Mathf.Abs(parameters.Scale.y), Mathf.Abs(parameters.Scale.z));
            wall.transform.localScale = parameters.Scale;
            
            // Set the correct position.
            wall.transform.position = new(parameters.Position.x, parameters.Scale.y / 2f, parameters.Position.y);
            
            // Apply the material.
            wall.GetComponent<MeshRenderer>().material = KaijuAgents.GetMaterial(parameters.Color ?? Color.black);
            
            // Name the wall.
            wall.name = string.IsNullOrWhiteSpace(parameters.Name) ? "Wall" : parameters.Name;
            
            return new { success = true, message = $"Created wall \"{wall.name}\" at position ({parameters.Position.x}, {parameters.Position.y}) and scale ({parameters.Scale.x}, {parameters.Scale.y}, {parameters.Scale.z})." };
        }
    }
    
    /// <summary>
    /// Spawning agent parameters for MCP interactions.
    /// </summary>
    public sealed class McpSpawnAgentParameters
    {
        /// <summary>
        /// The path to the agent prefab to load.
        /// </summary>
        [McpDescription("The path to the agent prefab to load.", Required = true)]
        public string Path { get; set; }
        
        /// <summary>
        /// The name to give the spawned agent.
        /// </summary>
        [McpDescription("The name to give the spawned agent.", Required = false)]
        public string Name { get; set; } = "Agent";
        
        /// <summary>
        /// The position to spawn the agent at, corresponding to X and Z coordinates, as all agents are spawned at a Y of zero.
        /// </summary>
        [McpDescription("The position to spawn the agent at, corresponding to X and Z coordinates, as all agents are spawned at a Y of zero.", Required = false)]
        public Vector2 Position { get; set; } = Vector2.zero;
        
        /// <summary>
        /// The orientation in degrees around the Y axis to spawn the agent facing.
        /// </summary>
        [McpDescription("The orientation in degrees around the Y axis to spawn the agent facing.", Required = false)]
        public float Rotation { get; set; } = 0f;
    }
    
    /// <summary>
    /// Creating agent prefab parameters for MCP interactions.
    /// </summary>
    public sealed class McpCreateAgentPrefabParameters
    {
        /// <summary>
        /// The path to save the agent prefab to.
        /// </summary>
        [McpDescription("The path to the agent prefab to load.", Required = true)]
        public string Path { get; set; }
        
        /// <summary>
        /// The type of agent to spawn.
        /// </summary>
        [McpDescription("The path to the agent prefab to load.", Required = true, EnumType = typeof(KaijuAgentType))]
        public string Type { get; set; } = "Transform";
        
        /// <summary>
        /// The names of additional component types to add to the agent. You do not need to include the agent's component in this, as it is handled by the type parameter. Note that these will be assigned directly to the root GameObject of the agent. Invalid components will be skipped.
        /// </summary>
        [McpDescription("The names of additional component types to add to the agent. You do not need to include the agent's component in this, as it is handled by the type parameter. Note that these will be assigned directly to the root GameObject of the agent. Invalid components will be skipped.", Required = false)]
        public string[] Components { get; set; }
        
        /// <summary>
        /// What color to make the body of the agent.
        /// </summary>
        [McpDescription("What color to make the body of the agent.", Required = false)]
        public Color? Body { get; set; }
        
        /// <summary>
        /// What color to make the eyes of the agent.
        /// </summary>
        [McpDescription("What color to make the eyes of the agent.", Required = false)]
        public Color? Eyes { get; set; }
    }
    
    /// <summary>
    /// Placing wall parameters for MCP interactions.
    /// </summary>
    public sealed class McpPlaceWall
    {
        /// <summary>
        /// The position to spawn the wall at, corresponding to X and Z coordinates, as all walls have their base at a Y of zero.
        /// </summary>
        [McpDescription("The position to spawn the wall at, corresponding to X and Z coordinates, as all walls have their base at a Y of zero.", Required = true)]
        public Vector2 Position { get; set; } = Vector2.zero;
        
        /// <summary>
        /// What size to make the wall. Note that this will automatically ensure the vertical height is representative as starting from zero along the Y axis, meaning for instance a wall with a height of two has its bottom at zero and top at two.
        /// </summary>
        [McpDescription("What height to make the wall.", Required = true)]
        public Vector3 Scale { get; set; } = new(1f, 2f, 1f);
        
        /// <summary>
        /// What to name the wall.
        /// </summary>
        [McpDescription("What to name the wall.", Required = false)]
        public string Name { get; set; } = "Wall";
        
        /// <summary>
        /// What color to make the wall, defaulting to black.
        /// </summary>
        [McpDescription("What color to make the wall, defaulting to black", Required = false)]
        public Color? Color { get; set; }
    }
}
#endif