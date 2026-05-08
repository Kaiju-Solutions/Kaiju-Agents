#if UNITY_EDITOR && COM_COPLAYDEV_UNITY_MCP
using MCPForUnity.Editor.Helpers;
using MCPForUnity.Editor.Tools;
using Newtonsoft.Json.Linq;
using UnityEngine;

namespace KaijuSolutions.Agents.MCP.Editor
{
    /// <summary>
    /// MCP tool to place a wall in the scene. This is based on a box collider. Walls are set to be static by default will have a NavMeshObstacle component attached to them. The NavMeshObstacle will be set to carve.
    /// </summary>
    [McpForUnityTool("kaiju_agents_place_wall", Description = "Place a basic wall in the scene. This is based on a box collider. Walls are set to be static by default will have a NavMeshObstacle component attached to them. The NavMeshObstacle will be set to carve.")]
    public static class KaijuMcpPlaceWall
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
                parameters.position = @params[nameof(Parameters.position)]?.ToObject<Vector2>() ?? Vector2.zero;
                parameters.scale = @params[nameof(Parameters.scale)]?.ToObject<Vector3>() ?? new(1f, 2f, 1f);
                parameters.name = @params[nameof(Parameters.name)]?.ToObject<string>() ?? "Wall";
                parameters.color = @params[nameof(Parameters.color)]?.ToObject<Color>() ?? Color.black;
            }
            
            KaijuMcpHelpers.PlaceWall(parameters);
            return new SuccessResponse($"Created wall \"{parameters.name}\" at position ({parameters.position.x}, {parameters.position.y}) and scale ({parameters.scale.x}, {parameters.scale.y}, {parameters.scale.z}).");
        }
        
        /// <summary>
        /// Placing wall parameters for MCP interactions.
        /// </summary>
        public sealed class Parameters
        {
            /// <summary>
            /// The position to spawn the wall at, corresponding to X and Z coordinates, as all walls have their base at a Y of zero.
            /// </summary>
            [ToolParameter("The position to spawn the wall at, corresponding to X and Z coordinates, as all walls have their base at a Y of zero.", Required = false)]
            public Vector2 position = Vector2.zero;
            
            /// <summary>
            /// What size to make the wall. Note that this will automatically ensure the vertical height is representative as starting from zero along the Y axis, meaning for instance a wall with a height of two has its bottom at zero and top at two. Note that agents have a height of two, so ensure at least this if you want to avoid agents seeing over a wall with certain sensor arrangements.
            /// </summary>
            [ToolParameter("What height to make the wall. Note that this will automatically ensure the vertical height is representative as starting from zero along the Y axis, meaning for instance a wall with a height of two has its bottom at zero and top at two. Note that agents have a height of two, so ensure at least this if you want to avoid agents seeing over a wall with certain sensor arrangements.", Required = false)]
            public Vector3 scale = new(1f, 2f, 1f);
            
            /// <summary>
            /// What to name the wall.
            /// </summary>
            [ToolParameter("What to name the wall.", Required = false)]
            public string name = "Wall";
            
            /// <summary>
            /// What color to make the wall, defaulting to black.
            /// </summary>
            [ToolParameter("What color to make the wall, defaulting to black", Required = false)]
            public Color color = Color.black;
        }
    }
}
#endif