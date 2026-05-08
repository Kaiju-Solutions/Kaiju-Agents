#if UNITY_EDITOR && COM_UNITY_AI_ASSISTANT
using System.Diagnostics.CodeAnalysis;
using System.IO;
using KaijuSolutions.Agents.Extensions;
using Unity.AI.MCP.Editor.ToolRegistry;
using Unity.AI.Navigation;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEditor.SceneTemplate;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

namespace KaijuSolutions.Agents.Assistant.Editor
{
    /// <summary>
    /// Handle core MCP interactions for <see href="https://docs.unity3d.com/Packages/com.unity.ai.assistant@latest">Unity AI Assistant</see>.
    /// </summary>
    public static class KaijuAssistantEditor
    {
        /// <summary>
        /// MCP tool to place a NavMesh Surface into the scene. This is set to collect all GameObjects in the scene across all layers and uses physics colliders.
        /// </summary>
        /// <param name="parameters">The placing parameters.</param>
        /// <returns>That the NavMesh Surface was placed.</returns>
        [McpTool("kaiju_agents_place_navmesh", "Place a NavMesh Surface into the scene. This is set to collect all GameObjects in the scene across all layers and uses physics colliders.", EnabledByDefault = true, Groups = new []{"Scene"})]
        public static object McpPlaceNavMesh([NotNull] McpPlaceNavMeshParameters parameters)
        {
            // Create the navigation mesh.
            GameObject go = new(string.IsNullOrWhiteSpace(parameters.Name) ? "NavMesh Surface" : parameters.Name);
            NavMeshSurface navmesh = go.AddComponent<NavMeshSurface>();
            navmesh.collectObjects = CollectObjects.All;
            navmesh.useGeometry = NavMeshCollectGeometry.PhysicsColliders;
            go.isStatic = true;

            if (!parameters.Build)
            {
                return new { success = true, message = $"Created NavMesh Surface \"{navmesh.name}\"."};
            }
            
            Physics.SyncTransforms();
            navmesh.BuildNavMesh();
            return new { success = true, message = $"Created NavMesh Surface \"{navmesh.name}\" and built it."};
        }
        
        /// <summary>
        /// MCP tool to build all active NavMesh Surfaces in the active scenes.
        /// </summary>
        /// <returns>If any NavMesh Surfaces were built</returns>
        [McpTool("kaiju_agents_bake_navigation", "Build all active NavMesh Surfaces in the active scenes.", EnabledByDefault = true, Groups = new []{"Scene"})]
        public static object McpBakeNavigation()
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
            
            return surfaces.Length < 1 ? new { success = false, message = "No NavMesh Surfaces found to bake."} : new { success = true, message = surfaces.Length > 1 ? $"Baked {surfaces.Length} NavMesh Surfaces." : "Baked 1 NavMesh Surface."};
        }
        
        /// <summary>
        /// MCP tool to create a scene set up for use with Kaiju Agents. This scene also creates a GameObject with a NavMesh Surface, and sets up a main camera for a top-down orthographic view of the scene. Choosing to place floors and walls parameters will automatically build the navigation mesh.
        /// </summary>
        /// <param name="parameters">The creating parameters.</param>
        /// <returns>If the scene was created.</returns>
        [McpTool("kaiju_agents_create_scene", "Create a scene set up for use with Kaiju Agents. This scene also creates a GameObject with a NavMesh Surface, and sets up a main camera for a top-down orthographic view of the scene. Choosing to place floors and walls parameters will automatically build the navigation mesh.", EnabledByDefault = true, Groups = new []{"Scene"})]
        public static object McpCreateScene([NotNull] McpCreateSceneParameters parameters)
        {
            // Load the scene template.
            SceneTemplateAsset template = AssetDatabase.LoadAssetAtPath<SceneTemplateAsset>("Packages/ca.kaijusolutions.agents/Editor/Kaiju Agents.scenetemplate");
            if (template == null)
            {
                return new { success = false, message = "Scene template does not exist and cannot be loaded." };
            }
            
            // Handle existing open scenes.
            for (int i = 0; i < SceneManager.sceneCount; i++)
            {
                Scene scene = SceneManager.GetSceneAt(i);
                
                // If the scene has a file path, it is linked to an asset. Auto-save it if dirty.
                if (!string.IsNullOrEmpty(scene.path) && scene.isDirty)
                {
                    EditorSceneManager.SaveScene(scene);
                }
            }
            
            // All assets must start with "Assets".
            if (!parameters.Path.StartsWith("Assets"))
            {
                parameters.Path = Path.Combine("Assets", parameters.Path);
            }
            
            // Automatically append the ".unity" extension if it was forgotten.
            if (!parameters.Path.EndsWith(".unity"))
            {
                parameters.Path += ".unity";
            }
            
            // Create a temporary, clean scene so Unity always has at least one scene open.
            Scene dummyScene = EditorSceneManager.NewScene(NewSceneSetup.EmptyScene, NewSceneMode.Single);
            
            // Force close the older scenes. Because we already saved the ones tied to assets, only the unlinked ones will be discarded here without prompting.
            for (int i = SceneManager.sceneCount - 1; i >= 0; i--)
            {
                Scene scene = SceneManager.GetSceneAt(i);
                if (scene != dummyScene)
                {
                    EditorSceneManager.CloseScene(scene, true);
                }
            }
            
            // Generate a unique path so we don't accidentally overwrite an existing scene.
            string uniquePath = AssetDatabase.GenerateUniqueAssetPath(parameters.Path);
            
            // Instantiate the new scene.
            InstantiationResult result = SceneTemplateService.Instantiate(template, false, uniquePath);
            if (result == null || !result.scene.IsValid())
            {
                return new { success = false, message = $"Failed to create scene \"{uniquePath}\" from the template." };
            }
            
            // Place a floor if we should.
            bool hasFloor = parameters.Floor != null;
            if (hasFloor)
            {
                // Place it and its walls.
                McpPlaceFloor(parameters.Floor);
                
                // If we have a camera in the scene, size it to see the level.
                Camera camera = Camera.main;
                if (camera != null)
                {
                    camera.transform.position = new(parameters.Floor.Position.x, camera.transform.position.y, parameters.Floor.Position.y);
                    camera.orthographic = true;
                    camera.orthographicSize = parameters.Floor.Scale / 2f + (parameters.Floor.OuterWalls ? 1f : 0f);
                }
            }
            
            // Place walls if we should as well.
            bool hasWalls = parameters.Walls is { Length: > 0 };
            if (hasWalls)
            {
                foreach (McpPlaceWallParameters wall in parameters.Walls)
                {
                    McpPlaceWall(wall);
                }
            }
            
            // Bake all navigation in the scene.
            if (hasFloor || hasWalls)
            {
                McpBakeNavigation();
                EditorSceneManager.SaveScene(result.scene);
            }
            
            return new { success = true, message = $"Created scene \"{uniquePath}\"." };
        }
    }
    
    /// <summary>
    /// Placing navigation mesh parameters for MCP interactions.
    /// </summary>
    public sealed class McpPlaceNavMeshParameters
    {
        /// <summary>
        /// What to name the navigation mesh.
        /// </summary>
        [McpDescription("What to name the navigation mesh.", Required = false)]
        public string Name { get; set; } = "NavMesh Surface";
        
        /// <summary>
        /// If the navigation mesh should be built after it is placed.
        /// </summary>
        [McpDescription("If the navigation mesh should be built after it is placed.", Required = false)]
        public bool Build { get; set; } = false;
    }
    
    public sealed class McpCreateSceneParameters
    {
        /// <summary>
        /// The path to save the scene to. If this scene already exists, a unique name will be given.
        /// </summary>
        [McpDescription("The path to save the scene to. If this scene already exists, a unique name will be given.", Required = false)]
        public string Path { get; set; } = "Assets/Kaiju Agents.unity";
        
        /// <summary>
        /// A floor to optionally place in the scene. If a floor is created, the main orthographic camera is set to fit in into view, including the walls if they are added.
        /// </summary>
        [McpDescription("A floor to optionally place in the scene. If a floor is created, the main orthographic camera is set to fit in into view, including the walls if they are added.", Required = false)]
        public McpPlaceFloorParameters Floor { get; set; } = null;
        
        /// <summary>
        /// Walls to optionally place in the scene.
        /// </summary>
        [McpDescription("Walls to optionally place in the scene.", Required = false)]
        public McpPlaceWallParameters[] Walls { get; set; } = null;
    }
}
#endif