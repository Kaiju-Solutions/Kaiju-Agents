using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using UnityEngine;
using UnityEngine.AI;
using Object = UnityEngine.Object;
#if UNITY_EDITOR
using UnityEditor;
#endif
namespace KaijuSolutions.Agents
{
    /// <summary>
    /// Methods to help with <see cref="KaijuAgent"/> creation.
    /// </summary>
    public static class KaijuAgents
    {
        /// <summary>
        /// All materials cached.
        /// </summary>
        private static readonly Dictionary<Color, Material> Materials = new();
        
        /// <summary>
        /// Cached material mode.
        /// </summary>
        private static readonly int Mode = Shader.PropertyToID("_Mode");
        
        /// <summary>
        /// Cached material glossiness.
        /// </summary>
        private static readonly int Glossiness = Shader.PropertyToID("_Glossiness");
        
        /// <summary>
        /// Cached material metallic.
        /// </summary>
        private static readonly int Metallic = Shader.PropertyToID("_Metallic");

        /// <summary>
        /// The default body color.
        /// </summary>
        private static Color Body => Color.red;
        
        /// <summary>
        /// The default eyes color.
        /// </summary>
        private static Color Eyes => Color.black;
        
        /// <summary>
        /// Get a material to use.
        /// </summary>
        /// <param name="color">The color of the material.</param>
        /// <returns>The material to use.</returns>
        public static Material GetMaterial(Color color)
        {
            // Return the cached one if it exists.
            if (Materials.TryGetValue(color, out Material material))
            {
                return material;
            }
#if UNITY_EDITOR
            // Search for all materials.
            foreach (string guid in AssetDatabase.FindAssets("t:Material"))
            {
                // Try to load the material.
                material = AssetDatabase.LoadAssetAtPath<Material>(AssetDatabase.GUIDToAssetPath(guid));
                    
                // If the color matches, use it.
                if (material == null || material.color != color)
                {
                    continue;
                }
                
                // Cache the material if playing.
                if (Application.isPlaying)
                {
                    Materials.TryAdd(color, material);
                }
                
                return material;
            }
#endif
            // Otherwise, create a new material.
            material = CreateMaterial(color);
#if UNITY_EDITOR
            if (!Application.isPlaying)
            {
                AssetDatabase.CreateAsset(material, $"Assets/{material.name}.mat");
                return material;
            }
#endif
            Materials.TryAdd(color, material);
            return material;
        }
        
        /// <summary>
        /// Create a material.
        /// </summary>
        /// <param name="color">The color of the material.</param>
        /// <returns>The created material.</returns>
        private static Material CreateMaterial(Color color)
        {
            // Create a new material with the standard shader.
            Material material = new(Shader.Find("Standard"))
            {
                color = color
            };
            
            // Set to opaque with no smoothness or metallic properties.
            material.SetFloat(Mode, 0);
            material.SetFloat(Glossiness, 0);
            material.SetFloat(Metallic, 0);
            material.name = $"Material {color.r} {color.g} {color.b} {color.a}";
            Materials.Add(color, material);
            return material;
        }
#if UNITY_EDITOR
        /// <summary>
        /// Handle manually resetting the domain.
        /// </summary>
        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.SubsystemRegistration)]
        private static void InitOnPlayMode()
        {
            Materials.Clear();
        }
#endif
        /// <summary>
        /// Assign a <see href="https://docs.unity3d.com/Manual/Components.html">component</see>, validating if it meets requirements.
        /// </summary>
        /// <param name="go">The <see href="https://docs.unity3d.com/Manual/class-GameObject.html">GameObject</see> to assign the <see href="https://docs.unity3d.com/Manual/Components.html">component</see> to.</param>
        /// <param name="current">The currently assigned value of the <see href="https://docs.unity3d.com/Manual/Components.html">component</see> to validate.</param>
        /// <param name="self">If the <see href="https://docs.unity3d.com/Manual/Components.html">component</see> can be attached to the calling <see href="https://docs.unity3d.com/Manual/class-GameObject.html">GameObject</see>.</param>
        /// <param name="children">If the <see href="https://docs.unity3d.com/Manual/Components.html">component</see> can be in the children of the calling <see href="https://docs.unity3d.com/Manual/class-GameObject.html">GameObject</see>.</param>
        /// <param name="parents">If the <see href="https://docs.unity3d.com/Manual/Components.html">component</see> can be in the parents of the calling <see href="https://docs.unity3d.com/Manual/class-GameObject.html">GameObject</see>.</param>
        /// <typeparam name="T">The type of <see href="https://docs.unity3d.com/Manual/Components.html">component</see> to assign.</typeparam>
        /// <returns>If a new assignment was made.</returns>
        public static bool AssignComponent<T>([NotNull] this GameObject go, ref T current, bool self = true, bool children = false, bool parents = false) where T : Component
        {
            // If one currently exists, see if it meets our requirements to be assigned.
            if (current != null)
            {
                // Grab the <see href="https://docs.unity3d.com/Manual/Components.html">component</see>'s <see href="https://docs.unity3d.com/Manual/class-GameObject.html">GameObject</see>.
                GameObject other = current.gameObject;
                
                // If it is itself.
                if (self && go == other)
                {
                    return false;
                }
                
                // Check if it is within the children or parents.
                Transform t = other.transform;
                if ((children && go.GetComponentsInChildren<Transform>().Contains(t)) || (parents && go.GetComponentsInParent<Transform>().Contains(t)))
                {
                    return false;
                }
            }
            
            // Check on the <see href="https://docs.unity3d.com/Manual/class-GameObject.html">GameObject</see> itself.
            if (self && go.TryGetComponent(out current))
            {
                return true;
            }
            
            // Check in children.
            if (children)
            {
                current = go.GetComponentInChildren<T>();
                if (current != null)
                {
                    return true;
                }
            }
            
            // Check in the parents.
            if (parents)
            {
                current = go.GetComponentInParent<T>();
                if (current != null)
                {
                    return true;
                }
            }
            
            // Try and add the <see href="https://docs.unity3d.com/Manual/Components.html">component</see>.
            if (!self)
            {
                return false;
            }
            
            current = go.AddComponent<T>();
            return true;

        }
        
        /// <summary>
        /// Assign a <see href="https://docs.unity3d.com/Manual/Components.html">component</see>, validating if it meets requirements.
        /// </summary>
        /// <param name="c">A <see href="https://docs.unity3d.com/Manual/Components.html">component</see> of the <see href="https://docs.unity3d.com/Manual/class-GameObject.html">GameObject</see> to assign the <see href="https://docs.unity3d.com/Manual/Components.html">component</see> to.</param>
        /// <param name="current">The currently assigned value of the <see href="https://docs.unity3d.com/Manual/Components.html">component</see> to validate.</param>
        /// <param name="self">If the <see href="https://docs.unity3d.com/Manual/Components.html">component</see> can be attached to the calling <see href="https://docs.unity3d.com/Manual/class-GameObject.html">GameObject</see>.</param>
        /// <param name="children">If the <see href="https://docs.unity3d.com/Manual/Components.html">component</see> can be in the children of the calling <see href="https://docs.unity3d.com/Manual/class-GameObject.html">GameObject</see>.</param>
        /// <param name="parents">If the <see href="https://docs.unity3d.com/Manual/Components.html">component</see> can be in the parents of the calling <see href="https://docs.unity3d.com/Manual/class-GameObject.html">GameObject</see>.</param>
        /// <typeparam name="T">The type of <see href="https://docs.unity3d.com/Manual/Components.html">component</see> to assign.</typeparam>
        /// <returns>If a new assignment was made.</returns>
        public static bool AssignComponent<T>([NotNull] this Component c, ref T current, bool self = true, bool children = false, bool parents = false) where T : Component
        {
            return c.gameObject.AssignComponent(ref current, self, children, parents);
        }
        
        /// <summary>
        /// Spawn an <see cref="KaijuAgent"/>.
        /// </summary>
        /// <param name="type">The type of <see cref="KaijuAgent"/> to spawn.</param>
        /// <param name="position">The position to spawn the <see cref="KaijuAgent"/> at.</param>
        /// <param name="orientation">The orientation to spawn the <see cref="KaijuAgent"/> at.</param>
        /// <param name="cached">If this should try to load a cached <see cref="KaijuAgent"/> or not.</param>
        /// <param name="prefab"></param>
        /// <param name="name"></param>
        /// <param name="body"></param>
        /// <param name="eyes"></param>
        /// <returns></returns>
        public static KaijuAgent Spawn(KaijuAgentType type = KaijuAgentType.Transform, Vector3? position = null, Quaternion? orientation = null, bool cached = true, [NotNull] KaijuAgent prefab = null, string name = null, Color? body = null, Color? eyes = null)
        {
            KaijuAgent agent;
            
            // If we can use a cached agent, do so.
            if (cached)
            {
                agent = type switch
                {
                    KaijuAgentType.Rigidbody => KaijuAgentsManager.GetCached<KaijuRigidbodyAgent>(),
                    KaijuAgentType.Character => KaijuAgentsManager.GetCached<KaijuCharacterAgent>(),
                    KaijuAgentType.Navigation => KaijuAgentsManager.GetCached<KaijuNavigationAgent>(),
                    _ => KaijuAgentsManager.GetCached<KaijuTransformAgent>()
                };
                
                // If there is a cached agent, work with it.
                if (agent != null)
                {
                    // Set values.
                    agent.name = name ?? "Agent";
                    Transform root = agent.transform;
                    root.position = position ?? Vector3.zero;
                    root.rotation = orientation ?? Quaternion.identity;
                    
                    // Set the colors if this conforms to the standard setup.
                    SetMaterials(root, body, eyes);
                    
                    // Reactive this agent.
                    agent.Spawn();
                    return agent;
                }
            }
            
            // Load the agent if it is a prefab.
            if (prefab != null)
            {
                agent = Object.Instantiate(prefab, position ?? Vector3.zero, orientation ?? Quaternion.identity);
                agent.name = name ?? "Agent";
                
                // Set the colors if this conforms to the standard setup.
                SetMaterials(agent.transform, body, eyes);
                return agent;
            }
            
            // Create the agent for scratch otherwise.
            GameObject go = new(name ?? "Agent")
            {
                transform =
                {
                    position = position ?? Vector3.zero,
                    rotation = orientation ?? Quaternion.identity
                }
            };
            switch (type)
            {
                case KaijuAgentType.Rigidbody:
                    go.AddComponent<Rigidbody>();
                    agent = go.AddComponent<KaijuRigidbodyAgent>();
                    go.AddComponent<CapsuleCollider>();
                    break;
                case KaijuAgentType.Character:
                    go.AddComponent<CharacterController>();
                    agent = go.AddComponent<KaijuCharacterAgent>();
                    break;
                case KaijuAgentType.Navigation:
                    go.AddComponent<NavMeshAgent>();
                    agent = go.AddComponent<KaijuNavigationAgent>();
                    break;
                case KaijuAgentType.Transform:
                default:
                    agent = go.AddComponent<KaijuTransformAgent>();
                    break;
            }
            
            // Create the default visuals.
            CreateCapsule(CreateCapsule(agent.transform, Vector3.up, Quaternion.identity, Vector3.one, body ?? Body, "Body"), new(0, 0.5f, 0.225f), Quaternion.Euler(0, 0, 90f), new(0.5f, 0.5f, 0.5f), eyes ?? Eyes, "Eyes");
            agent.Setup();
            return agent;
        }
        
        /// <summary>
        /// Try to set the materials.
        /// </summary>
        /// <param name="root">The root <see href="https://docs.unity3d.com/Manual/class-transform.html">transform</see>.</param>
        /// <param name="body">The color for the body.</param>
        /// <param name="eyes">The color for the eyes.</param>
        private static void SetMaterials([NotNull] Transform root, Color? body = null, Color? eyes = null)
        {
            // If there are no desired colors, skip.
            if (!body.HasValue && !eyes.HasValue)
            {
                return;
            }
            
            for (int i = 0; i < root.childCount; i++)
            {
                Transform child = root.GetChild(i);
                
                // Only looking for the default-named body for automatic assignment.
                if (child.name != "Body")
                {
                    continue;
                }
                
                // Assign the body color.
                if (body.HasValue && child.TryGetComponent(out MeshRenderer renderer))
                {
                    renderer.material = GetMaterial(body.Value);
                }
                
                // Do the same with the eye color.
                if (eyes.HasValue)
                {
                    for (int j = 0; j < child.childCount; j++)
                    {
                        Transform final = child.GetChild(i);
                        
                        if (final.name != "Eyes")
                        {
                            continue;
                        }
                        
                        if (final.TryGetComponent(out renderer))
                        {
                            renderer.material = GetMaterial(eyes.Value);
                        }
                        
                        break;
                    }
                }
                
                break;
            }
        }
        
        /// <summary>
        /// Create a capsule for the default <see cref="KaijuAgent"/>s.
        /// </summary>
        /// <param name="parent">The parent <see href="https://docs.unity3d.com/Manual/class-transform.html">transform</see>.</param>
        /// <param name="position">The local position.</param>
        /// <param name="orientation">The local orientation.</param>
        /// <param name="scale">The local scale.</param>
        /// <param name="color">The color.</param>
        /// <param name="name">The name.</param>
        /// <returns>The <see href="https://docs.unity3d.com/Manual/class-transform.html">transform</see> of the spawned object.</returns>
        private static Transform CreateCapsule(Transform parent, Vector3 position, Quaternion orientation, Vector3 scale, Color color, string name)
        {
            // Add the body visuals.
            GameObject go = GameObject.CreatePrimitive(PrimitiveType.Capsule);
            go.name = name;
            go.transform.parent = parent;
            go.transform.localPosition = position;
            go.transform.localRotation = orientation;
            go.transform.localScale = scale;
            
            // Remove the collider.
            Collider collider = go.GetComponent<Collider>();
            if (collider != null)
            {
#if UNITY_EDITOR
                if (Application.isPlaying)
                {
                    Object.Destroy(collider);
                }
                else
                {
                    Object.DestroyImmediate(collider);
                }
#else
                Object.Destroy(collider);
#endif
            }
            
            // Assign the body color.
            MeshRenderer renderer = go.GetComponent<MeshRenderer>();
            if (renderer != null)
            {
                renderer.material = GetMaterial(color);
            }
            
            return go.transform;
        }
    }
}