#if UNITY_EDITOR
using Unity.Pipeline.Commands;
using Newtonsoft.Json.Linq;
using Unity.AI.Navigation;
using UnityEditor;
using UnityEngine;
using UnityEngine.AI;

namespace KaijuSolutions.Agents.Pipeline.Editor
{
    /// <summary>
    /// Pipeline tool to place a NavMesh Surface into the scene. This is set to collect all GameObjects in the scene across all layers and uses physics colliders.
    /// </summary>
    public static class KaijuCliPlaceNavMesh
    {
        [CliCommand("kaiju-agents", "place-navmesh", "Place a NavMesh Surface into the scene. This is set to collect all GameObjects in the scene across all layers and uses physics colliders.")]
        public static string Run([CliArg("options", "JSON object with name, build.")] string options = "{}") => HandleCommand(JObject.Parse(options));

        internal static string HandleCommand(JObject @params)
        {
            Parameters parameters = new();
            if (@params != null)
            {
                parameters.name = @params[nameof(Parameters.name)]?.ToObject<string>() ?? "NavMesh Surface";
                parameters.build = @params[nameof(Parameters.build)]?.ToObject<bool>() ?? false;
            }
            
            // Create the navigation mesh.
            GameObject go = new(string.IsNullOrWhiteSpace(parameters.name) ? "NavMesh Surface" : parameters.name);
            NavMeshSurface navmesh = go.AddComponent<NavMeshSurface>();
            navmesh.collectObjects = CollectObjects.All;
            navmesh.useGeometry = NavMeshCollectGeometry.PhysicsColliders;
            go.isStatic = true;
            
            if (!Application.isPlaying) Undo.RegisterCreatedObjectUndo(go, "Create Kaiju scene object");
            if (!parameters.build)
            {
                return $"Created NavMesh Surface \"{navmesh.name}\".";
            }
            
            Physics.SyncTransforms();
            navmesh.BuildNavMesh();
            return $"Created NavMesh Surface \"{navmesh.name}\" and built it.";
        }
        
        /// <summary>
        /// Placing navigation mesh parameters for Pipeline interactions.
        /// </summary>
        public sealed class Parameters
        {
            /// <summary>
            /// What to name the navigation mesh.
            /// </summary>
            public string name = "NavMesh Surface";
            
            /// <summary>
            /// If the navigation mesh should be built after it is placed.
            /// </summary>
            public bool build;
        }
    }
}
#endif