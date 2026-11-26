#if UNITY_EDITOR
using Unity.Pipeline.Commands;
using Unity.AI.Navigation;
using UnityEngine;

namespace KaijuSolutions.Agents.Pipeline.Editor
{
    /// <summary>
    /// Pipeline tool to build all active NavMesh Surfaces in the active scenes.
    /// </summary>
    public static class KaijuCliBakeNavigation
    {
        [CliCommand("kaiju-agents", "check-route", "Inspect a surface route without changing the scene.", Effect = CommandEffect.ReadOnly)]
        public static object CheckRoute([CliArg("options", "JSON with start and goal XYZ, optional agentTypeID, areaMask, snapDistance.")] string options)
        {
            var args = Newtonsoft.Json.Linq.JObject.Parse(options);
            var start = args["start"]?.ToObject<UnityEngine.Vector3>() ?? throw new System.ArgumentException("Supply start.");
            var goal = args["goal"]?.ToObject<UnityEngine.Vector3>() ?? throw new System.ArgumentException("Supply goal.");
            var filter = new UnityEngine.AI.NavMeshQueryFilter { agentTypeID = (int?)args["agentTypeID"] ?? 0,
                areaMask = (int?)args["areaMask"] ?? UnityEngine.AI.NavMesh.AllAreas };
            UnityEngine.Vector3[] corners = null;
            Extensions.KaijuAgentsFindPath.TryFindSurfacePath(start, goal, filter, (float?)args["snapDistance"] ?? 0.5f,
                new UnityEngine.AI.NavMeshPath(), ref corners, out int count, out var status, out var mapped);
            bool mappedBoth = status != Extensions.KaijuSurfacePathStatus.UnmappedStart && status != Extensions.KaijuSurfacePathStatus.UnmappedGoal;
            return new { status = status.ToString(), cornerCount = count,
                mappedEndpoint = mappedBoth ? new { x = mapped.x, y = mapped.y, z = mapped.z } : null };
        }

        [CliCommand("kaiju-agents", "bake-navigation", "Build all active NavMesh Surfaces in the active scenes.")]
        public static string Run()
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
            
            return surfaces.Length < 1 ? throw new System.InvalidOperationException("No NavMesh Surfaces found to bake.") : surfaces.Length > 1 ? $"Baked {surfaces.Length} NavMesh Surfaces." : "Baked 1 NavMesh Surface.";
        }
    }
}
#endif