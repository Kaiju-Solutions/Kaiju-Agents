#if UNITY_EDITOR && COM_COPLAYDEV_UNITY_MCP
using KaijuSolutions.Agents.Extensions;
using MCPForUnity.Editor.Helpers;
using MCPForUnity.Editor.Tools;
using Newtonsoft.Json.Linq;
using UnityEditor;
using UnityEngine;

namespace KaijuSolutions.Agents.Editor.MCP
{
    /// <summary>
    /// MCP tool to places an agent into the level.
    /// </summary>
    [McpForUnityTool("kaiju_agents_place_agent", Description = "Places an agent into the level.")]
    public static class KaijuMcpPlaceAgent
    {
        /// <summary>
        /// Handle the tool.
        /// </summary>
        /// <param name="params">The parameters.</param>
        /// <returns>The result returned to the AI agent.</returns>
        public static object HandleCommand(JObject @params)
        {
            if (@params == null)
            {
                return new ErrorResponse("No parameters were given to place a \"KaijuAgent\" prefab.");
            }
            
            string path = @params[nameof(Parameters.path)]?.ToString();
            if (path == null)
            {
                return new ErrorResponse("No prefab path was given for the \"KaijuAgent\" prefab.");
            }
            
            // Load the prefab.
            KaijuAgent prefab = AssetDatabase.LoadAssetAtPath<KaijuAgent>(path);
            if (prefab == null)
            {
                return new ErrorResponse($"Prefab \"{path}\" does not exist or does not have a \"KaijuAgent\" component.");
            }
            
            // If no name is assigned, use the prefab's name.
            string name = @params[nameof(Parameters.name)]?.ToString();
            if (string.IsNullOrWhiteSpace(name))
            {
                name = prefab.name;
            }
            
            // Spawn the agent.
            Vector2 position = @params[nameof(Parameters.position)]?.ToObject<Vector2>() ?? Vector2.zero;
            float rotation = @params[nameof(Parameters.rotation)]?.ToObject<float>() ?? 0f;
            KaijuAgents.Spawn(KaijuAgentType.Transform, position.Expand(), Quaternion.Euler(0f, rotation, 0f), Application.isPlaying, prefab, name);
            return new SuccessResponse($"Spawned an instance of \"{path}\" as \"{name}\" at position ({position.x}, {position.y}) and a rotation angle of {rotation} degrees.");
        }
        
        /// <summary>
        /// Spawning agent parameters for MCP interactions.
        /// </summary>
        public sealed class Parameters
        {
            /// <summary>
            /// The path to the agent prefab to load.
            /// </summary>
            [ToolParameter("The path to the agent prefab to load.")]
            public string path = null;
            
            /// <summary>
            /// The name to give the spawned agent.
            /// </summary>
            [ToolParameter("The name to give the spawned agent.", Required = false)]
            public string name = "Agent";
            
            /// <summary>
            /// The position to spawn the agent at, corresponding to X and Z coordinates, as all agents are spawned at a Y of zero.
            /// </summary>
            [ToolParameter("The position to spawn the agent at, corresponding to X and Z coordinates, as all agents are spawned at a Y of zero.", Required = false)]
            public Vector2 position = Vector2.zero;
            
            /// <summary>
            /// The orientation in degrees around the Y axis to spawn the agent facing.
            /// </summary>
            [ToolParameter("The orientation in degrees around the Y axis to spawn the agent facing.", Required = false)]
            public float rotation = 0f;
        }
    }
}
#endif