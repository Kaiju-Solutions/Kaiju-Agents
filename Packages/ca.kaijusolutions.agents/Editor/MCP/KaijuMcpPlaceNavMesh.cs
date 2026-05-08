#if UNITY_EDITOR && COM_COPLAYDEV_UNITY_MCP
using MCPForUnity.Editor.Helpers;
using MCPForUnity.Editor.Tools;
using Newtonsoft.Json.Linq;
using Unity.AI.Navigation;
using UnityEngine;
using UnityEngine.AI;

namespace KaijuSolutions.Agents.MCP.Editor
{
    /// <summary>
    /// MCP tool to place a NavMesh Surface into the scene. This is set to collect all GameObjects in the scene across all layers and uses physics colliders.
    /// </summary>
    [McpForUnityTool("kaiju_agents_place_navmesh", Description = "Place a NavMesh Surface into the scene. This is set to collect all GameObjects in the scene across all layers and uses physics colliders.")]
    public static class KaijuMcpPlaceNavMesh
    {
        /// <summary>
        /// Handle the tool.
        /// </summary>
        /// <param name="params">The parameters.</param>
        /// <returns>The result returned to the AI agent.</returns>
        public static object HandleCommand(JObject @params)
        {
            Parameters parameters = new();
            if (@params != null)
            {
                parameters.name = @params[nameof(Parameters.name)]?.ToObject<string>() ?? "Floor";
                parameters.build = @params[nameof(Parameters.build)]?.ToObject<bool>() ?? false;
            }
            
            // Create the navigation mesh.
            GameObject go = new(string.IsNullOrWhiteSpace(parameters.name) ? "NavMesh Surface" : parameters.name);
            NavMeshSurface navmesh = go.AddComponent<NavMeshSurface>();
            navmesh.collectObjects = CollectObjects.All;
            navmesh.useGeometry = NavMeshCollectGeometry.PhysicsColliders;
            go.isStatic = true;
            
            if (!parameters.build)
            {
                return new SuccessResponse($"Created NavMesh Surface \"{navmesh.name}\".");
            }
            
            Physics.SyncTransforms();
            navmesh.BuildNavMesh();
            return new SuccessResponse($"Created NavMesh Surface \"{navmesh.name}\" and built it.");
        }
        
        /// <summary>
        /// Placing navigation mesh parameters for MCP interactions.
        /// </summary>
        public sealed class Parameters
        {
            /// <summary>
            /// What to name the navigation mesh.
            /// </summary>
            [ToolParameter("What to name the navigation mesh.", Required = false)]
            public string name = "NavMesh Surface";
            
            /// <summary>
            /// If the navigation mesh should be built after it is placed.
            /// </summary>
            [ToolParameter("If the navigation mesh should be built after it is placed.", Required = false)]
            public bool build;
        }
    }
}
#endif