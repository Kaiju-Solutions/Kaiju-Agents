#if UNITY_EDITOR
using Unity.Pipeline.Commands;
using Newtonsoft.Json.Linq;
using UnityEditor;
using UnityEngine;

namespace KaijuSolutions.Agents.Pipeline.Editor
{
    /// <summary>
    /// Pipeline tool to place a basic floor in the scene. This is based on the default "Quad" collider, rotated properly to be a floor, and has no renderer attached to it. Floors are set to be static by default.
    /// </summary>
    public static class KaijuCliPlaceFloor
    {
        [CliCommand("kaiju-agents", "place-floor", "Place a basic floor in the scene. This is based on the default \"Quad\" collider, rotated properly to be a floor, and has no renderer attached to it. Floors are set to be static by default.")]
        public static string Run([CliArg("options", "JSON object with name, position {x,y} or worldPosition {x,y,z}, scale, outerWalls.")] string options = "{}") => HandleCommand(JObject.Parse(options));

        internal static string HandleCommand(JObject @params)
        {
            Parameters parameters = new();
            if (@params != null)
            {
                parameters.worldPosition = KaijuCliHelpers.ReadPosition(@params);
                parameters.scale = @params[nameof(Parameters.scale)]?.ToObject<float>() ?? 30f;
                parameters.name = @params[nameof(Parameters.name)]?.ToObject<string>() ?? "Floor";
                parameters.outerWalls = @params[nameof(Parameters.outerWalls)]?.ToObject<bool>() ?? true;
            }
            
            // Create the floor.
            GameObject floor = GameObject.CreatePrimitive(PrimitiveType.Quad);
            floor.transform.rotation = Quaternion.Euler(90f, 0f, 0f);
            Vector3 origin = parameters.worldPosition ?? Vector3.zero;
            floor.transform.position = origin;
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
                KaijuCliHelpers.PlaceWall(new()
                {
                    worldPosition = origin + Vector3.forward * (scale / 2f + 0.5f),
                    scale = new(scale + 2f, 2f, 1f)
                }).name = "Wall Z+";
                KaijuCliHelpers.PlaceWall(new()
                {
                    worldPosition = origin - Vector3.forward * (scale / 2f + 0.5f),
                    scale = new(scale + 2f, 2f, 1f)
                }).name = "Wall Z-";
                KaijuCliHelpers.PlaceWall(new()
                {
                    worldPosition = origin + Vector3.right * (scale / 2f + 0.5f),
                    scale = new(1f, 2f, scale + 2f)
                }).name = "Wall X+";
                KaijuCliHelpers.PlaceWall(new()
                {
                    worldPosition = origin - Vector3.right * (scale / 2f + 0.5f),
                    scale = new(1f, 2f, scale + 2f)
                }).name = "Wall X-";
            }
            
            if (!Application.isPlaying) Undo.RegisterCreatedObjectUndo(floor, "Create Kaiju scene object");
            return $"Created floor \"{floor.name}\" at position {origin} and a scale of {scale}.";
        }
        
        /// <summary>
        /// Placing floor parameters for Pipeline interactions.
        /// </summary>
        public sealed class Parameters
        {
            /// <summary>
            /// The position to spawn the floor at, corresponding to X and Z coordinates, as all floors are placed at Y of zero.
            /// </summary>
            public Vector2 position = Vector2.zero;
            public Vector3? worldPosition;
            
            /// <summary>
            /// What size to make the floor. The scale is set uniform across all three axes.
            /// </summary>
            public float scale = 30f;
            
            /// <summary>
            /// What to name the floor.
            /// </summary>
            public string name = "Floor";
            
            /// <summary>
            /// If outer walls surrounding the floor should be added. If enabled, walls of a height of two will automatically be placed at the borders of the floor space. The walls are properly placed outside to not take away from the floor space itself.
            /// </summary>
            public bool outerWalls = true;
        }
    }
}

#endif