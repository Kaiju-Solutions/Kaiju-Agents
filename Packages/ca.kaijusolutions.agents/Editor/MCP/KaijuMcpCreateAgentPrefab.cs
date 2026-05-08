#if UNITY_EDITOR && COM_COPLAYDEV_UNITY_MCP
using System.IO;
using MCPForUnity.Editor.Helpers;
using MCPForUnity.Editor.Tools;
using Newtonsoft.Json.Linq;
using UnityEditor;
using UnityEngine;

namespace KaijuSolutions.Agents.Editor.MCP
{
    /// <summary>
    /// MCP tool to create an agent prefab. Cannot be performed while in play mode.
    /// </summary>
    [McpForUnityTool("kaiju_agents_create_agent_prefab", Description = "Creates an agent prefab. Cannot be performed while in play mode.")]
    public static class KaijuMcpCreateAgentPrefab
    {
        /// <summary>
        /// Handle the tool.
        /// </summary>
        /// <param name="params">The parameters.</param>
        /// <returns>The result returned to the AI agent.</returns>
        public static object HandleCommand(JObject @params)
        {
            // Only allow this when in edit mode.
            if (Application.isPlaying)
            {
                return new { success = false, message = "Cannot create agent prefabs when in play mode." };
            }
            
            if (@params == null)
            {
                return new ErrorResponse("No parameters were given to create a \"KaijuAgent\" prefab.");
            }
            
            string path = @params[nameof(path)]?.ToString();
            if (path == null)
            {
                return new ErrorResponse("No prefab path was given for the \"KaijuAgent\" prefab.");
            }
            
            // All assets must start with "Assets".
            if (!path.StartsWith("Assets"))
            {
                path = Path.Combine("Assets", path);
            }
            
            // Automatically append the ".prefab" extension if it was forgotten.
            if (!path.EndsWith(".prefab"))
            {
                path += ".prefab";
            }
            
            // Ensure the folder exists.
            string directoryPath = Path.GetDirectoryName(path);
            if (directoryPath != null && !Directory.Exists(directoryPath))
            {
                Directory.CreateDirectory(directoryPath);
            }
            
            string stringType = @params[nameof(path)]?.ToString().ToUpper() ?? "TRANSFORM";
            KaijuAgentType type;
            switch (stringType)
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
                    return new { success = false, message = $"Unknown agent type of \"{stringType}\"." };
            }
            
            // Spawn one into the active scene.
            Color body = @params[nameof(Parameters.body)]?.ToObject<Color>() ?? Color.red;
            Color eyes = @params[nameof(Parameters.eyes)]?.ToObject<Color>() ?? Color.black;
            string[] components = KaijuMcpHelpers.GetArray<string>(@params, nameof(Parameters.components));
            KaijuAgent instance = KaijuAgents.Spawn(type, Vector3.zero, Quaternion.identity, false, null, null, body, eyes, components);
            
            // Try to save it as a prefab.
            PrefabUtility.SaveAsPrefabAsset(instance.gameObject, path, out bool success);
            
            // Destroy the instance in the scene.
            Object.DestroyImmediate(instance.gameObject);
            
            // Indicate success.
            return success ? new SuccessResponse($"Created agent prefab \"{path}\".") : new ErrorResponse($"Failed to create agent prefab \"{path}\".");
        }
        
        /// <summary>
        /// Creating agent prefab parameters for MCP interactions.
        /// </summary>
        public sealed class Parameters
        {
            /// <summary>
            /// The path to save the agent prefab to.
            /// </summary>
            [ToolParameter("The path to the agent prefab to load.")]
            public string path = null;
            
            /// <summary>
            /// The type of agent to spawn.
            /// </summary>
            [ToolParameter("The path to the agent prefab to load. Choices include \"TRANSFORM\", \"RIGIDBODY\", \"CHARACTER\", and \"NAVIGATION\".")]
            public string type = "TRANSFORM";
            
            /// <summary>
            /// The names of additional component types to add to the agent. You do not need to include the agent's component in this, as it is handled by the type parameter. Note that these will be assigned directly to the root GameObject of the agent. Invalid components will be skipped.
            /// </summary>
            [ToolParameter("The names of additional component types to add to the agent. You do not need to include the agent's component in this, as it is handled by the type parameter. Note that these will be assigned directly to the root GameObject of the agent. Invalid components will be skipped.", Required = false)]
            public string[] components = null;
            
            /// <summary>
            /// What color to make the body of the agent.
            /// </summary>
            [ToolParameter("What color to make the body of the agent.", Required = false)]
            public Color body = Color.red;
            
            /// <summary>
            /// What color to make the eyes of the agent.
            /// </summary>
            [ToolParameter("What color to make the eyes of the agent.", Required = false)]
            public Color eyes = Color.black;
        }
    }
}
#endif