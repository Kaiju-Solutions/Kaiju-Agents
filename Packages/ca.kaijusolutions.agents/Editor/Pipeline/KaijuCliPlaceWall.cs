#if UNITY_EDITOR
using Unity.Pipeline.Commands;
using Newtonsoft.Json.Linq;
using UnityEngine;

namespace KaijuSolutions.Agents.Pipeline.Editor
{
    /// <summary>
    /// Pipeline tool to place a wall in the scene. This is based on a box collider. Walls are set to be static by default will have a NavMeshObstacle component attached to them. The NavMeshObstacle will be set to carve.
    /// </summary>
    public static class KaijuCliPlaceWall
    {
        [CliCommand("kaiju-agents", "place-wall", "Place a basic wall in the scene. This is based on a box collider. Walls are set to be static by default will have a NavMeshObstacle component attached to them. The NavMeshObstacle will be set to carve.")]
        public static string Run([CliArg("options", "JSON object with name, position {x,y} or worldPosition {x,y,z}, scale {x,y,z}, color {r,g,b,a}.")] string options = "{}") => HandleCommand(JObject.Parse(options));

        internal static string HandleCommand(JObject @params)
        {
            Parameters parameters = new();
            if (@params != null)
            {
                parameters.worldPosition = KaijuCliHelpers.ReadPosition(@params);
                parameters.scale = @params[nameof(Parameters.scale)]?.ToObject<Vector3>() ?? new(1f, 2f, 1f);
                parameters.name = @params[nameof(Parameters.name)]?.ToObject<string>() ?? "Wall";
                parameters.color = @params[nameof(Parameters.color)]?.ToObject<Color>() ?? Color.black;
            }
            
            KaijuCliHelpers.PlaceWall(parameters);
            return $"Created wall \"{parameters.name}\" at position {parameters.worldPosition ?? Vector3.zero} and scale ({parameters.scale.x}, {parameters.scale.y}, {parameters.scale.z}).";
        }
        
        /// <summary>
        /// Placing wall parameters for Pipeline interactions.
        /// </summary>
        public sealed class Parameters
        {
            /// <summary>
            /// The position to spawn the wall at, corresponding to X and Z coordinates, as all walls have their base at a Y of zero.
            /// </summary>
            public Vector2 position = Vector2.zero;
            public Vector3? worldPosition;
            
            /// <summary>
            /// What size to make the wall. Note that this will automatically ensure the vertical height is representative as starting from zero along the Y axis, meaning for instance a wall with a height of two has its bottom at zero and top at two. Note that agents have a height of two, so ensure at least this if you want to avoid agents seeing over a wall with certain sensor arrangements.
            /// </summary>
            public Vector3 scale = new(1f, 2f, 1f);
            
            /// <summary>
            /// What to name the wall.
            /// </summary>
            public string name = "Wall";
            
            /// <summary>
            /// What color to make the wall, defaulting to black.
            /// </summary>
            public Color color = Color.black;
        }
    }
}
#endif