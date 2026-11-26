#if UNITY_EDITOR
using KaijuSolutions.Agents.Extensions;
using Unity.Pipeline.Commands;
using Newtonsoft.Json.Linq;
using UnityEditor;
using UnityEngine;

namespace KaijuSolutions.Agents.Pipeline.Editor
{
    /// <summary>
    /// Pipeline tool to places an agent into the level.
    /// </summary>
    public static class KaijuCliPlaceAgent
    {
        [CliCommand("kaiju-agents", "place-agent", "Places an agent into the level.")]
        public static string Run([CliArg("options", "JSON object with path (required), name, position {x,y} or worldPosition {x,y,z}, rotation (degrees).")] string options = "{}") => HandleCommand(JObject.Parse(options));

        internal static string HandleCommand(JObject @params)
        {
            if (@params == null)
            {
                throw new System.ArgumentException("No parameters were given to place a \"KaijuAgent\" prefab.");
            }
            
            string path = @params[nameof(Parameters.path)]?.ToString();
            if (path == null)
            {
                throw new System.ArgumentException("No prefab path was given for the \"KaijuAgent\" prefab.");
            }
            
            // Load the prefab.
            KaijuAgent prefab = AssetDatabase.LoadAssetAtPath<KaijuAgent>(path);
            if (prefab == null)
            {
                throw new System.ArgumentException($"Prefab \"{path}\" does not exist or does not have a \"KaijuAgent\" component.");
            }
            
            // If no name is assigned, use the prefab's name.
            string name = @params[nameof(Parameters.name)]?.ToString();
            if (string.IsNullOrWhiteSpace(name))
            {
                name = prefab.name;
            }
            
            // Spawn the agent.
            Vector3 position = KaijuCliHelpers.ReadPosition(@params);
            float rotation = @params[nameof(Parameters.rotation)]?.ToObject<float>() ?? 0f;
            var agent = KaijuAgents.Spawn(KaijuAgentType.Transform, position, Quaternion.Euler(0f, rotation, 0f), Application.isPlaying, prefab, name);
            if (!Application.isPlaying) Undo.RegisterCreatedObjectUndo(agent.gameObject, "Create Kaiju scene object");
            return $"Spawned an instance of \"{path}\" as \"{name}\" at position {position} and a rotation angle of {rotation} degrees.";
        }
        
        /// <summary>
        /// Spawning agent parameters for Pipeline interactions.
        /// </summary>
        public sealed class Parameters
        {
            /// <summary>
            /// The path to the agent prefab to load.
            /// </summary>
            public string path = null;
            
            /// <summary>
            /// The name to give the spawned agent.
            /// </summary>
            public string name = "Agent";
            
            /// <summary>
            /// The position to spawn the agent at, corresponding to X and Z coordinates, as all agents are spawned at a Y of zero.
            /// </summary>
            public Vector2 position = Vector2.zero;
            
            /// <summary>
            /// The orientation in degrees around the Y axis to spawn the agent facing.
            /// </summary>
            public float rotation = 0f;
        }
    }
}
#endif