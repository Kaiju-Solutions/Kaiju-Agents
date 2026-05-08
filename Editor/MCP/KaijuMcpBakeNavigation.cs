#if UNITY_EDITOR && COM_COPLAYDEV_UNITY_MCP
using MCPForUnity.Editor.Helpers;
using MCPForUnity.Editor.Tools;
using Newtonsoft.Json.Linq;
using Unity.AI.Navigation;
using UnityEngine;

namespace KaijuSolutions.Agents.MCP.Editor
{
    /// <summary>
    /// MCP tool to build all active NavMesh Surfaces in the active scenes.
    /// </summary>
    [McpForUnityTool("kaiju_agents_bake_navigation", Description = "Build all active NavMesh Surfaces in the active scenes.")]
    public static class KaijuMcpBakeNavigation
    {
        /// <summary>
        /// Handle the tool.
        /// </summary>
        /// <param name="_">The parameters.</param>
        /// <returns>The result returned to the AI agent.</returns>
        public static object HandleCommand(JObject _)
        {
#if UNITY_6000_4_OR_NEWER
            NavMeshSurface[] surfaces = Object.FindObjectsByType<NavMeshSurface>();
#else
            NavMeshSurface[] surfaces = Object.FindObjectsByType<NavMeshSurface>(sortMode: FindObjectsSortMode.None);
#endif
            Physics.SyncTransforms();
            foreach (NavMeshSurface navmesh in surfaces)
            {
                navmesh.BuildNavMesh();
            }
            
            return surfaces.Length < 1 ? new ErrorResponse("No NavMesh Surfaces found to bake.") : new SuccessResponse(surfaces.Length > 1 ? $"Baked {surfaces.Length} NavMesh Surfaces." : "Baked 1 NavMesh Surface.");
        }
    }
}
#endif