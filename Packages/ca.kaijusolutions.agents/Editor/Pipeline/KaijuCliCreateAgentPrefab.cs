#if UNITY_EDITOR
using System.IO;
using Unity.Pipeline.Commands;
using Newtonsoft.Json.Linq;
using UnityEditor;
using UnityEngine;

namespace KaijuSolutions.Agents.Pipeline.Editor
{
    /// <summary>
    /// Pipeline tool to create an agent prefab. Cannot be performed while in play mode.
    /// </summary>
    public static class KaijuCliCreateAgentPrefab
    {
        [CliCommand("kaiju-agents", "create-agent-prefab", "Creates an agent prefab. Cannot be performed while in play mode.")]
        public static string Run([CliArg("options", "JSON object with path (required), type, components, body, eyes.")] string options = "{}") => HandleCommand(JObject.Parse(options));

        internal static string HandleCommand(JObject @params)
        {
            // Only allow this when in edit mode.
            if (Application.isPlaying)
            {
                throw new System.ArgumentException("Cannot create \"KaijuAgent\" prefabs when in play mode.");
            }
            
            if (@params == null)
            {
                throw new System.ArgumentException("No parameters were given to create a \"KaijuAgent\" prefab.");
            }
            
            string path = @params[nameof(path)]?.ToString();
            if (string.IsNullOrWhiteSpace(path))
            {
                throw new System.ArgumentException("No prefab path was given for the \"KaijuAgent\" prefab.");
            }
            
            path = path.Replace('\\', '/');
            if (!path.StartsWith("Assets/", System.StringComparison.Ordinal))
                path = "Assets/" + path;
            string fullPath = Path.GetFullPath(path);
            string assetsRoot = Path.GetFullPath(Application.dataPath) + Path.DirectorySeparatorChar;
            if (!fullPath.StartsWith(assetsRoot, System.StringComparison.Ordinal))
                throw new System.ArgumentException("Choose a prefab path within Assets.");

            // Automatically append the ".prefab" extension if it was forgotten.
            if (!path.EndsWith(".prefab"))
            {
                path += ".prefab";
            }
            
            if (File.Exists(path) || AssetDatabase.LoadMainAssetAtPath(path) != null)
                throw new System.ArgumentException($"An asset already exists at {path}.");

            string stringType = @params[nameof(Parameters.type)]?.ToString().ToUpperInvariant() ?? "TRANSFORM";
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
                    throw new System.ArgumentException($"Unknown agent type of \"{stringType}\".");
            }
            
            // Spawn one into the active scene.
            Color body = @params[nameof(Parameters.body)]?.ToObject<Color>() ?? Color.red;
            Color eyes = @params[nameof(Parameters.eyes)]?.ToObject<Color>() ?? Color.black;
            string[] components = KaijuCliHelpers.GetArray<string>(@params, nameof(Parameters.components));
            string directory = Path.GetDirectoryName(path);
            if (!Directory.Exists(directory))
            {
                Directory.CreateDirectory(directory);
                AssetDatabase.Refresh();
            }
            KaijuAgent instance = KaijuAgents.Spawn(type, Vector3.zero, Quaternion.identity, false, null, null, body, eyes, components);
            try
            {
                PrefabUtility.SaveAsPrefabAsset(instance.gameObject, path, out bool success);
                if (!success) throw new System.InvalidOperationException($"Failed to create agent prefab {path}.");
                return $"Created agent prefab {path}.";
            }
            finally
            {
                Object.DestroyImmediate(instance.gameObject);
            }
        }
        
        /// <summary>
        /// Creating agent prefab parameters for Pipeline interactions.
        /// </summary>
        public sealed class Parameters
        {
            /// <summary>
            /// The path to save the agent prefab to.
            /// </summary>
            public string path = null;
            
            /// <summary>
            /// The type of agent to spawn.
            /// </summary>
            public string type = "TRANSFORM";
            
            /// <summary>
            /// The names of additional component types to add to the agent. You do not need to include the agent's component in this, as it is handled by the type parameter. Note that these will be assigned directly to the root GameObject of the agent. Invalid components will be skipped.
            /// </summary>
            public string[] components = null;
            
            /// <summary>
            /// What color to make the body of the agent.
            /// </summary>
            public Color body = Color.red;
            
            /// <summary>
            /// What color to make the eyes of the agent.
            /// </summary>
            public Color eyes = Color.black;
        }
    }
}
#endif