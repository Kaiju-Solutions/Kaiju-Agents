#if UNITY_EDITOR && COM_UNITY_AI_ASSISTANT
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
        /// MCP tool to places an agent into the level.
        /// </summary>
        /// <param name="parameters">The spawning parameters.</param>
        /// <returns>If the agent was successfully placed or not.</returns>
        [McpTool("place_agent", "Places an agent into the level.", EnabledByDefault = true, Groups = new []{"Kaiju Agents"})]
        public static object McpPlaceAgent(McpPlaceAgentParameters parameters)
        {
            // Load the prefab.
            KaijuAgent prefab = AssetDatabase.LoadAssetAtPath<KaijuAgent>(parameters.Path);
            if (prefab == null)
            {
                return new { success = false, message = $"Prefab \"{parameters.Path}\" does not exist or does not have a \"KaijuAgent\" component." };
            }
            
            // If no name is assigned, use the prefab's name.
            if (string.IsNullOrWhiteSpace(parameters.Name))
            {
                parameters.Name = prefab.name;
            }
            
            // Spawn the agent.
            KaijuAgents.Spawn(KaijuAgentType.Transform, parameters.Position.Expand(), Quaternion.Euler(0f, parameters.Rotation, 0f), Application.isPlaying, prefab, parameters.Name);
            return new { success = true, message = $"Spawned an instance of \"{parameters.Path}\" as \"{parameters.Name}\" at position ({parameters.Position.x}, {parameters.Position.y}) and a rotation angle of {parameters.Rotation} degrees." };
        }
        
        /// <summary>
        /// MCP tool to create an agent prefab. Cannot be performed while in play mode.
        /// </summary>
        /// <param name="parameters">The creation parameters.</param>
        /// <returns>If the prefab was successfully created or not.</returns>
        [McpTool("create_agent_prefab", "Creates an agent prefab. Cannot be performed while in play mode.", EnabledByDefault = true, Groups = new []{"Kaiju Agents"})]
        public static object McpCreateAgentPrefab(McpCreateAgentPrefabParameters parameters)
        {
            // Only allow this when in edit mode.
            if (Application.isPlaying)
            {
                return new { success = false, message = "Cannot create agent prefabs when in play mode." };
            }
            
            // All assets must start with "Assets".
            if (!parameters.Path.StartsWith("Assets"))
            {
                parameters.Path = Path.Combine("Assets", parameters.Path);
            }
            
            // Automatically append the ".prefab" extension if it was forgotten.
            if (!parameters.Path.EndsWith(".prefab"))
            {
                parameters.Path += ".prefab";
            }
            
            // Ensure the folder exists.
            string directoryPath = Path.GetDirectoryName(parameters.Path);
            if (directoryPath != null && !Directory.Exists(directoryPath))
            {
                Directory.CreateDirectory(directoryPath);
            }
            
            KaijuAgentType type;
            switch (parameters.Type.ToUpper())
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
                    return new { success = false, message = $"Unknown agent type of \"{parameters.Type}\"." };
            }
            
            // Spawn one into the active scene.
            KaijuAgent instance = KaijuAgents.Spawn(type, Vector3.zero, Quaternion.identity, false, null, null, parameters.Body, parameters.Eyes, parameters.Components);
            
            // Try to save it as a prefab.
            PrefabUtility.SaveAsPrefabAsset(instance.gameObject, parameters.Path, out bool success);
            
            // Destroy the instance in the scene.
            Object.DestroyImmediate(instance.gameObject);
            
            // Indicate success.
            return success ? new { success = true, message = $"Created agent prefab \"{parameters.Path}\"." } : new { success = false, message = $"Failed to create agent prefab \"{parameters.Path}\"." };
        }
        
        /// <summary>
        /// MCP tool to place a wall in the scene. This is based on a box collider. Walls are set to be static by default will have a NavMeshObstacle component attached to them. The NavMeshObstacle will be set to carve.
        /// </summary>
        /// <param name="parameters">The placing parameters.</param>
        /// <returns>That the wall was placed.</returns>
        [McpTool("place_wall", "Place a basic wall in the scene. This is based on a box collider. Walls are set to be static by default will have a NavMeshObstacle component attached to them. The NavMeshObstacle will be set to carve.", EnabledByDefault = true, Groups = new []{"Kaiju Agents"})]
        public static object McpPlaceWall(McpPlaceWallParameters parameters)
        {
            // Create the wall.
            GameObject wall = GameObject.CreatePrimitive(PrimitiveType.Cube);
            parameters.Scale = new(Mathf.Max(Mathf.Abs(parameters.Scale.x), float.Epsilon), Mathf.Max(Mathf.Abs(parameters.Scale.y), float.Epsilon), Mathf.Max(Mathf.Abs(parameters.Scale.z), float.Epsilon));
            wall.transform.localScale = parameters.Scale;
            wall.transform.position = new(parameters.Position.x, parameters.Scale.y / 2f, parameters.Position.y);
            wall.GetComponent<MeshRenderer>().material = KaijuAgents.GetMaterial(parameters.Color ?? Color.black);
            wall.name = string.IsNullOrWhiteSpace(parameters.Name) ? "Wall" : parameters.Name;
            wall.isStatic = true;
            
            // Add and set up the NavMeshObstacle.
            NavMeshObstacle obstacle = wall.AddComponent<NavMeshObstacle>();
            obstacle.carving = true;
            obstacle.carveOnlyStationary = true;
            obstacle.shape = NavMeshObstacleShape.Box;
            
            return new { success = true, message = $"Created wall \"{wall.name}\" at position ({parameters.Position.x}, {parameters.Position.y}) and scale ({parameters.Scale.x}, {parameters.Scale.y}, {parameters.Scale.z})." };
        }
        
        /// <summary>
        /// MCP tool to place a basic floor in the scene. This is based on the default "Quad" collider, rotated properly to be a floor, and has no renderer attached to it. Floors are set to be static by default.
        /// </summary>
        /// <param name="parameters">The placing parameters.</param>
        /// <returns>That the floor was placed.</returns>
        [McpTool("place_floor", "Place a basic floor in the scene. This is based on the default \"Quad\" collider, rotated properly to be a floor, and has no renderer attached to it. Floors are set to be static by default.", EnabledByDefault = true, Groups = new []{"Kaiju Agents"})]
        public static object McpPlaceFloor(McpPlaceFloorParameters parameters)
        {
            // Create the floor.
            GameObject floor = GameObject.CreatePrimitive(PrimitiveType.Quad);
            floor.transform.rotation = Quaternion.Euler(90f, 0f, 0f);
            floor.transform.position = new(parameters.Position.x, 0f, parameters.Position.y);
            float scale = Mathf.Max(Mathf.Abs(parameters.Scale), float.Epsilon);
            floor.transform.localScale = new(scale, scale, scale);
            floor.name = string.IsNullOrWhiteSpace(parameters.Name) ? "Floor" : parameters.Name;
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
            if (parameters.OuterWalls)
            {
                // TODO.
            }
            
            return new { success = true, message = $"Created floor \"{floor.name}\" at position ({parameters.Position.x}, {parameters.Position.y}) and a scale of {scale}." };
        }
        
        /// <summary>
        /// MCP tool to place a NavMesh Surface into the scene. This is set to collect all GameObjects in the scene across all layers and uses physics colliders.
        /// </summary>
        /// <param name="parameters">The placing parameters.</param>
        /// <returns>That the NavMesh Surface was placed.</returns>
        [McpTool("place_navmesh", "Place a NavMesh Surface into the scene. This is set to collect all GameObjects in the scene across all layers and uses physics colliders.", EnabledByDefault = true, Groups = new []{"Kaiju Agents"})]
        public static object McpPlaceNavMesh(McpPlaceNavMeshParameters parameters)
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
        [McpTool("bake_navigation", "Build all active NavMesh Surfaces in the active scenes.", EnabledByDefault = true, Groups = new []{"Kaiju Agents"})]
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
        
        [MenuItem("Testing/Test")]
        public static void Test()
        {
            McpCreateScene(new()
            {
                Floor = new()
            });
        }
        
        /// <summary>
        /// MCP tool to create a scene set up for use with Kaiju Agents.
        /// </summary>
        /// <param name="parameters">The creating parameters.</param>
        /// <returns>If the scene was created.</returns>
        [McpTool("create_scene", "Create a scene set up for use with Kaiju Agents.", EnabledByDefault = true, Groups = new []{"Kaiju Agents"})]
        public static object McpCreateScene(McpCreateSceneParameters parameters)
        {
            // Load the scene template.
            SceneTemplateAsset template = AssetDatabase.LoadAssetAtPath<SceneTemplateAsset>("Packages/ca.kaijusolutions.agents/Editor/Kaiju Agents Empty.scenetemplate");
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
            
            if (parameters.Floor != null)
            {
                McpPlaceFloor(parameters.Floor);
                McpBakeNavigation();
                EditorSceneManager.SaveScene(result.scene);
            }
            
            return new { success = true, message = $"Created scene \"{uniquePath}\"." };
        }
    }
    
    /// <summary>
    /// Spawning agent parameters for MCP interactions.
    /// </summary>
    public sealed class McpPlaceAgentParameters
    {
        /// <summary>
        /// The path to the agent prefab to load.
        /// </summary>
        [McpDescription("The path to the agent prefab to load.", Required = true)]
        public string Path { get; set; }
        
        /// <summary>
        /// The name to give the spawned agent.
        /// </summary>
        [McpDescription("The name to give the spawned agent.", Required = false)]
        public string Name { get; set; } = "Agent";
        
        /// <summary>
        /// The position to spawn the agent at, corresponding to X and Z coordinates, as all agents are spawned at a Y of zero.
        /// </summary>
        [McpDescription("The position to spawn the agent at, corresponding to X and Z coordinates, as all agents are spawned at a Y of zero.", Required = false)]
        public Vector2 Position { get; set; } = Vector2.zero;
        
        /// <summary>
        /// The orientation in degrees around the Y axis to spawn the agent facing.
        /// </summary>
        [McpDescription("The orientation in degrees around the Y axis to spawn the agent facing.", Required = false)]
        public float Rotation { get; set; } = 0f;
    }
    
    /// <summary>
    /// Creating agent prefab parameters for MCP interactions.
    /// </summary>
    public sealed class McpCreateAgentPrefabParameters
    {
        /// <summary>
        /// The path to save the agent prefab to.
        /// </summary>
        [McpDescription("The path to the agent prefab to load.", Required = true)]
        public string Path { get; set; }
        
        /// <summary>
        /// The type of agent to spawn.
        /// </summary>
        [McpDescription("The path to the agent prefab to load.", Required = true, EnumType = typeof(KaijuAgentType))]
        public string Type { get; set; } = "Transform";
        
        /// <summary>
        /// The names of additional component types to add to the agent. You do not need to include the agent's component in this, as it is handled by the type parameter. Note that these will be assigned directly to the root GameObject of the agent. Invalid components will be skipped.
        /// </summary>
        [McpDescription("The names of additional component types to add to the agent. You do not need to include the agent's component in this, as it is handled by the type parameter. Note that these will be assigned directly to the root GameObject of the agent. Invalid components will be skipped.", Required = false)]
        public string[] Components { get; set; }
        
        /// <summary>
        /// What color to make the body of the agent.
        /// </summary>
        [McpDescription("What color to make the body of the agent.", Required = false)]
        public Color? Body { get; set; }
        
        /// <summary>
        /// What color to make the eyes of the agent.
        /// </summary>
        [McpDescription("What color to make the eyes of the agent.", Required = false)]
        public Color? Eyes { get; set; }
    }
    
    /// <summary>
    /// Placing wall parameters for MCP interactions.
    /// </summary>
    public sealed class McpPlaceWallParameters
    {
        /// <summary>
        /// The position to spawn the wall at, corresponding to X and Z coordinates, as all walls have their base at a Y of zero.
        /// </summary>
        [McpDescription("The position to spawn the wall at, corresponding to X and Z coordinates, as all walls have their base at a Y of zero.", Required = true)]
        public Vector2 Position { get; set; }
        
        /// <summary>
        /// What size to make the wall. Note that this will automatically ensure the vertical height is representative as starting from zero along the Y axis, meaning for instance a wall with a height of two has its bottom at zero and top at two. Note that agents have a height of two, so ensure at least this if you want to avoid agents seeing over a wall with certain sensor arrangements.
        /// </summary>
        [McpDescription("What height to make the wall. Note that this will automatically ensure the vertical height is representative as starting from zero along the Y axis, meaning for instance a wall with a height of two has its bottom at zero and top at two. Note that agents have a height of two, so ensure at least this if you want to avoid agents seeing over a wall with certain sensor arrangements.", Required = true)]
        public Vector3 Scale { get; set; }
        
        /// <summary>
        /// What to name the wall.
        /// </summary>
        [McpDescription("What to name the wall.", Required = false)]
        public string Name { get; set; } = "Wall";
        
        /// <summary>
        /// What color to make the wall, defaulting to black.
        /// </summary>
        [McpDescription("What color to make the wall, defaulting to black", Required = false)]
        public Color? Color { get; set; }
    }
    
    /// <summary>
    /// Placing floor parameters for MCP interactions.
    /// </summary>
    public sealed class McpPlaceFloorParameters
    {
        /// <summary>
        /// The position to spawn the floor at, corresponding to X and Z coordinates, as all floors are placed at Y of zero.
        /// </summary>
        [McpDescription("The position to spawn the floor at, corresponding to X and Z coordinates, as all floors are placed at Y of zero.", Required = true)]
        public Vector2 Position { get; set; }
        
        /// <summary>
        /// What size to make the floor. The scale is set uniform across all three axes.
        /// </summary>
        [McpDescription("What size to make the floor. The scale is set uniform across all three axes.", Required = false)]
        public float Scale { get; set; } = 30f;
        
        /// <summary>
        /// What to name the floor.
        /// </summary>
        [McpDescription("What to name the floor.", Required = false)]
        public string Name { get; set; } = "Floor";
        
        /// <summary>
        /// If outer walls surrounding the floor should be added. If enabled, walls of a height of two will automatically be placed at the borders of the floor space. The walls are properly placed outside to not take away from the floor space itself.
        /// </summary>
        [McpDescription("If outer walls surrounding the floor should be added. If enabled, walls of a height of two will automatically be placed at the borders of the floor space. The walls are properly placed outside to not take away from the floor space itself.", Required = false)]
        public bool OuterWalls { get; set; } = true;
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
        /// A floor to optionally place in the scene.
        /// </summary>
        [McpDescription("A floor to optionally place in the scene.", Required = false)]
        public McpPlaceFloorParameters Floor { get; set; } = null;
        
        /// <summary>
        /// Walls to optionally place in the scene.
        /// </summary>
        [McpDescription("Walls to optionally place in the scene.", Required = false)]
        public McpPlaceWallParameters[] Walls { get; set; } = null;
    }
}
#endif