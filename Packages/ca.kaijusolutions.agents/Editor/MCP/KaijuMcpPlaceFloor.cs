#if UNITY_EDITOR && COM_COPLAYDEV_UNITY_MCP
using MCPForUnity.Editor.Helpers;
using MCPForUnity.Editor.Tools;
using Newtonsoft.Json.Linq;
using UnityEngine;

namespace KaijuSolutions.Agents.MCP.Editor
{
    /// <summary>
    /// MCP tool to place a basic floor in the scene. This is based on the default "Quad" collider, rotated properly to be a floor, and has no renderer attached to it. Floors are set to be static by default.
    /// </summary>
    [McpForUnityTool("kaiju_agents_place_floor", Description = "Place a basic floor in the scene. This is based on the default \"Quad\" collider, rotated properly to be a floor, and has no renderer attached to it. Floors are set to be static by default.")]
    public static class KaijuMcpPlaceFloor
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
                parameters.scale = @params[nameof(Parameters.scale)]?.ToObject<float>() ?? 30f;
                parameters.name = @params[nameof(Parameters.name)]?.ToObject<string>() ?? "Floor";
                parameters.outerWalls = @params[nameof(Parameters.outerWalls)]?.ToObject<bool>() ?? true;
            }
            
            // Create the floor.
            GameObject floor = GameObject.CreatePrimitive(PrimitiveType.Quad);
            floor.transform.rotation = Quaternion.Euler(90f, 0f, 0f);
            floor.transform.position = new(parameters.position.x, 0f, parameters.position.y);
            float scale = Mathf.Max(Mathf.Abs(parameters.scale), float.Epsilon);
            floor.transform.localScale = new(scale, scale, scale);
            floor.name = string.IsNullOrWhiteSpace(parameters.name) ? "Floor" : parameters.name;
            floor.isStatic = true;
            
            // Remove the renderer.
            if (Application.isPlaying)
            {
                Object.Destroy(floor.GetComponent<MeshRenderer>());
            }
            else
            {
                Object.DestroyImmediate(floor.GetComponent<MeshRenderer>());
            }
            
            // Place outer walls.
            if (parameters.outerWalls)
            {
                KaijuMcpHelpers.PlaceWall(new()
                {
                    position = new(parameters.position.x, parameters.position.y + parameters.scale / 2f + 0.5f),
                    scale = new(parameters.scale + 2f, 2f, 1f)
                }).name = "Wall Z+";
                KaijuMcpHelpers.PlaceWall(new()
                {
                    position = new(parameters.position.x, parameters.position.y - parameters.scale / 2f - 0.5f),
                    scale = new(parameters.scale + 2f, 2f, 1f)
                }).name = "Wall Z-";
                KaijuMcpHelpers.PlaceWall(new()
                {
                    position = new(parameters.position.x + parameters.scale / 2f + 0.5f, parameters.position.y),
                    scale = new(1f, 2f, parameters.scale + 2f)
                }).name = "Wall X+";
                KaijuMcpHelpers.PlaceWall(new()
                {
                    position = new(parameters.position.x - parameters.scale / 2f - 0.5f, parameters.position.y),
                    scale = new(1f, 2f, parameters.scale + 2f)
                }).name = "Wall X-";
            }
            
            return new SuccessResponse($"Created floor \"{floor.name}\" at position ({parameters.position.x}, {parameters.position.y}) and a scale of {scale}.");
        }
        
        /// <summary>
        /// Placing floor parameters for MCP interactions.
        /// </summary>
        public sealed class Parameters
        {
            /// <summary>
            /// The position to spawn the floor at, corresponding to X and Z coordinates, as all floors are placed at Y of zero.
            /// </summary>
            [ToolParameter("The position to spawn the floor at, corresponding to X and Z coordinates, as all floors are placed at Y of zero.", Required = false)]
            public Vector2 position = Vector2.zero;
            
            /// <summary>
            /// What size to make the floor. The scale is set uniform across all three axes.
            /// </summary>
            [ToolParameter("What size to make the floor. The scale is set uniform across all three axes.", Required = false)]
            public float scale = 30f;
            
            /// <summary>
            /// What to name the floor.
            /// </summary>
            [ToolParameter("What to name the floor.", Required = false)]
            public string name = "Floor";
            
            /// <summary>
            /// If outer walls surrounding the floor should be added. If enabled, walls of a height of two will automatically be placed at the borders of the floor space. The walls are properly placed outside to not take away from the floor space itself.
            /// </summary>
            [ToolParameter("If outer walls surrounding the floor should be added. If enabled, walls of a height of two will automatically be placed at the borders of the floor space. The walls are properly placed outside to not take away from the floor space itself.", Required = false)]
            public bool outerWalls = true;
        }
    }
}

#endif