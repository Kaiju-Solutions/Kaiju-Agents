using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using KaijuSolutions.Agents.Sensors;
using UnityEngine;
using UnityEngine.AI;
using Object = UnityEngine.Object;
#if UNITY_EDITOR
using UnityEditor;
#endif
namespace KaijuSolutions.Agents
{
    /// <summary>
    /// General Kaiju Agents functions.
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
                    Materials.Add(color, material);
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
            Materials.Add(color, material);
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
        /// Assign a component, validating if it meets requirements.
        /// </summary>
        /// <param name="go">The <see href="https://docs.unity3d.com/Manual/class-GameObject.html">GameObject</see> to assign the component to.</param>
        /// <param name="current">The currently assigned value of the component to validate.</param>
        /// <param name="self">If the component can be attached to the calling <see href="https://docs.unity3d.com/Manual/class-GameObject.html">GameObject</see>.</param>
        /// <param name="children">If the component can be in the children of the calling <see href="https://docs.unity3d.com/Manual/class-GameObject.html">GameObject</see>.</param>
        /// <param name="parents">If the component can be in the parents of the calling <see href="https://docs.unity3d.com/Manual/class-GameObject.html">GameObject</see>.</param>
        /// <typeparam name="T">The type of component to assign.</typeparam>
        /// <returns>If a new assignment was made.</returns>
        public static bool AssignComponent<T>([NotNull] this GameObject go, ref T current, bool self = true, bool children = false, bool parents = false) where T : Component
        {
            // If one currently exists, see if it meets our requirements to be assigned.
            if (current != null)
            {
                // Grab the component's GameObject.
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
            
            // Check on the GameObject itself.
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
            
            // Try and add the component.
            if (!self)
            {
                return false;
            }
            
            current = go.AddComponent<T>();
            return true;

        }
        
        /// <summary>
        /// Assign a component, validating if it meets requirements.
        /// </summary>
        /// <param name="c">A component of the <see href="https://docs.unity3d.com/Manual/class-GameObject.html">GameObject</see> to assign the component to.</param>
        /// <param name="current">The currently assigned value of the component to validate.</param>
        /// <param name="self">If the component can be attached to the calling <see href="https://docs.unity3d.com/Manual/class-GameObject.html">GameObject</see>.</param>
        /// <param name="children">If the component can be in the children of the calling <see href="https://docs.unity3d.com/Manual/class-GameObject.html">GameObject</see>.</param>
        /// <param name="parents">If the component can be in the parents of the calling <see href="https://docs.unity3d.com/Manual/class-GameObject.html">GameObject</see>.</param>
        /// <typeparam name="T">The type of component to assign.</typeparam>
        /// <returns>If a new assignment was made.</returns>
        public static bool AssignComponent<T>([NotNull] this Component c, ref T current, bool self = true, bool children = false, bool parents = false) where T : Component
        {
            return c.gameObject.AssignComponent(ref current, self, children, parents);
        }
        
        /// <summary>
        /// Spawn an agent.
        /// </summary>
        /// <param name="type">The type of agent to spawn.</param>
        /// <param name="position">The position to spawn the agent at.</param>
        /// <param name="orientation">The orientation to spawn the agent at.</param>
        /// <param name="cached">If this should try to load a cached agent or not.</param>
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
        /// <param name="root">The root transform.</param>
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
        /// Create a capsule for the default agents.
        /// </summary>
        /// <param name="parent">The parent transform.</param>
        /// <param name="position">The local position.</param>
        /// <param name="orientation">The local orientation.</param>
        /// <param name="scale">The local scale.</param>
        /// <param name="color">The color.</param>
        /// <param name="name">The name.</param>
        /// <returns>The transform of the spawned object.</returns>
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
        
        /// <summary>
        /// Get the distance between this and another position.
        /// </summary>
        /// <param name="self">This position.</param>
        /// <param name="other">The other position.</param>
        /// <returns>The distance.</returns>
        public static float Distance(this Vector2 self, Vector2 other) => Vector2.Distance(self, other);
        
        /// <summary>
        /// Get the distance between this and another position.
        /// </summary>
        /// <param name="self">This position.</param>
        /// <param name="other">The other position.</param>
        /// <returns>The distance.</returns>
        public static float Distance(this Vector2 self, Vector3 other) => self.Distance(new Vector2(other.x, other.z));
        
        /// <summary>
        /// Get the distance between this and another position.
        /// </summary>
        /// <param name="self">This position.</param>
        /// <param name="other">The other position.</param>
        /// <returns>The distance.</returns>
        public static float Distance(this Vector2 self, [NotNull] Transform other) => self.Distance(other.position);
        
        /// <summary>
        /// Get the distance between this and another position.
        /// </summary>
        /// <param name="self">This position.</param>
        /// <param name="other">The other position.</param>
        /// <returns>The distance.</returns>
        public static float Distance(this Vector2 self, [NotNull] Component other) => self.Distance(other.transform);
        
        /// <summary>
        /// Get the distance between this and another position.
        /// </summary>
        /// <param name="self">This position.</param>
        /// <param name="other">The other position.</param>
        /// <returns>The distance.</returns>
        public static float Distance(this Vector2 self, [NotNull] GameObject other) => self.Distance(other.transform);
        
        /// <summary>
        /// Get the distance between this and another position.
        /// </summary>
        /// <param name="self">This position.</param>
        /// <param name="other">The other position.</param>
        /// <returns>The distance.</returns>
        public static float Distance(this Vector2 self, [NotNull] KaijuAgent other) => self.Distance(other.transform);
        
        /// <summary>
        /// Get the distance between this and another position.
        /// </summary>
        /// <param name="self">This position.</param>
        /// <param name="other">The other position.</param>
        /// <returns>The distance.</returns>
        public static float Distance(this Vector2 self, [NotNull] KaijuSensor other) => self.Distance(other.transform);
        
        /// <summary>
        /// Get the distance between this and another position.
        /// </summary>
        /// <param name="self">This position.</param>
        /// <param name="other">The other position.</param>
        /// <returns>The distance.</returns>
        public static float Distance(this Vector3 self, Vector2 other) => other.Distance(self);
        
        /// <summary>
        /// Get the distance between this and another position.
        /// </summary>
        /// <param name="self">This position.</param>
        /// <param name="other">The other position.</param>
        /// <returns>The distance.</returns>
        public static float Distance(this Vector3 self, Vector3 other) => new Vector2(self.x, self.z).Distance(other);
        
        /// <summary>
        /// Get the distance between this and another position.
        /// </summary>
        /// <param name="self">This position.</param>
        /// <param name="other">The other position.</param>
        /// <returns>The distance.</returns>
        public static float Distance(this Vector3 self, [NotNull] Transform other) => self.Distance(other.position);
        
        /// <summary>
        /// Get the distance between this and another position.
        /// </summary>
        /// <param name="self">This position.</param>
        /// <param name="other">The other position.</param>
        /// <returns>The distance.</returns>
        public static float Distance(this Vector3 self, [NotNull] Component other) => self.Distance(other.transform.position);
        
        /// <summary>
        /// Get the distance between this and another position.
        /// </summary>
        /// <param name="self">This position.</param>
        /// <param name="other">The other position.</param>
        /// <returns>The distance.</returns>
        public static float Distance(this Vector3 self, [NotNull] GameObject other) => self.Distance(other.transform.position);
        
        /// <summary>
        /// Get the distance between this and another position.
        /// </summary>
        /// <param name="self">This position.</param>
        /// <param name="other">The other position.</param>
        /// <returns>The distance.</returns>
        public static float Distance(this Vector3 self, [NotNull] KaijuAgent other) => self.Distance(other.transform.position);
        
        /// <summary>
        /// Get the distance between this and another position.
        /// </summary>
        /// <param name="self">This position.</param>
        /// <param name="other">The other position.</param>
        /// <returns>The distance.</returns>
        public static float Distance(this Vector3 self, [NotNull] KaijuSensor other) => self.Distance(other.transform.position);
        
        /// <summary>
        /// Get the distance between this and another position.
        /// </summary>
        /// <param name="self">This object.</param>
        /// <param name="other">The other position.</param>
        /// <returns>The distance.</returns>
        public static float Distance([NotNull] this Transform self, Vector2 other) => self.position.Distance(other);
        
        /// <summary>
        /// Get the distance between this and another position.
        /// </summary>
        /// <param name="self">This object.</param>
        /// <param name="other">The other position.</param>
        /// <returns>The distance.</returns>
        public static float Distance([NotNull] this Transform self, Vector3 other) => self.position.Distance(other);
        
        /// <summary>
        /// Get the distance between this and another position.
        /// </summary>
        /// <param name="self">This object.</param>
        /// <param name="other">The other position.</param>
        /// <returns>The distance.</returns>
        public static float Distance([NotNull] this Transform self, [NotNull] Transform other) => self.position.Distance(other.position);
        
        /// <summary>
        /// Get the distance between this and another position.
        /// </summary>
        /// <param name="self">This object.</param>
        /// <param name="other">The other position.</param>
        /// <returns>The distance.</returns>
        public static float Distance([NotNull] this Transform self, [NotNull] Component other) => self.position.Distance(other.transform.position);
        
        /// <summary>
        /// Get the distance between this and another position.
        /// </summary>
        /// <param name="self">This object.</param>
        /// <param name="other">The other position.</param>
        /// <returns>The distance.</returns>
        public static float Distance([NotNull] this Transform self, [NotNull] GameObject other) => self.position.Distance(other.transform.position);
        
        /// <summary>
        /// Get the distance between this and another position.
        /// </summary>
        /// <param name="self">This object.</param>
        /// <param name="other">The other position.</param>
        /// <returns>The distance.</returns>
        public static float Distance([NotNull] this Transform self, [NotNull] KaijuAgent other) => self.position.Distance(other.transform.position);
        
        /// <summary>
        /// Get the distance between this and another position.
        /// </summary>
        /// <param name="self">This object.</param>
        /// <param name="other">The other position.</param>
        /// <returns>The distance.</returns>
        public static float Distance([NotNull] this Transform self, [NotNull] KaijuSensor other) => self.position.Distance(other.transform.position);
        
        /// <summary>
        /// Get the distance between this and another position.
        /// </summary>
        /// <param name="self">This object.</param>
        /// <param name="other">The other position.</param>
        /// <returns>The distance.</returns>
        public static float Distance([NotNull] this Component self, Vector2 other) => self.transform.position.Distance(other);
        
        /// <summary>
        /// Get the distance between this and another position.
        /// </summary>
        /// <param name="self">This object.</param>
        /// <param name="other">The other position.</param>
        /// <returns>The distance.</returns>
        public static float Distance([NotNull] this Component self, Vector3 other) => self.transform.position.Distance(other);
        
        /// <summary>
        /// Get the distance between this and another position.
        /// </summary>
        /// <param name="self">This object.</param>
        /// <param name="other">The other position.</param>
        /// <returns>The distance.</returns>
        public static float Distance([NotNull] this Component self, [NotNull] Transform other) => self.transform.position.Distance(other.position);
        
        /// <summary>
        /// Get the distance between this and another position.
        /// </summary>
        /// <param name="self">This object.</param>
        /// <param name="other">The other position.</param>
        /// <returns>The distance.</returns>
        public static float Distance([NotNull] this Component self, [NotNull] Component other) => self.transform.position.Distance(other.transform.position);
        
        /// <summary>
        /// Get the distance between this and another position.
        /// </summary>
        /// <param name="self">This object.</param>
        /// <param name="other">The other position.</param>
        /// <returns>The distance.</returns>
        public static float Distance([NotNull] this Component self, [NotNull] GameObject other) => self.transform.position.Distance(other.transform.position);
        
        /// <summary>
        /// Get the distance between this and another position.
        /// </summary>
        /// <param name="self">This object.</param>
        /// <param name="other">The other position.</param>
        /// <returns>The distance.</returns>
        public static float Distance([NotNull] this Component self, [NotNull] KaijuAgent other) => self.transform.position.Distance(other.transform.position);
        
        /// <summary>
        /// Get the distance between this and another position.
        /// </summary>
        /// <param name="self">This object.</param>
        /// <param name="other">The other position.</param>
        /// <returns>The distance.</returns>
        public static float Distance([NotNull] this Component self, [NotNull] KaijuSensor other) => self.transform.position.Distance(other.transform.position);
        
        /// <summary>
        /// Get the distance between this and another position.
        /// </summary>
        /// <param name="self">This object.</param>
        /// <param name="other">The other position.</param>
        /// <returns>The distance.</returns>
        public static float Distance([NotNull] this GameObject self, Vector2 other) => self.transform.position.Distance(other);
        
        /// <summary>
        /// Get the distance between this and another position.
        /// </summary>
        /// <param name="self">This object.</param>
        /// <param name="other">The other position.</param>
        /// <returns>The distance.</returns>
        public static float Distance([NotNull] this GameObject self, [NotNull] Transform other) => self.transform.position.Distance(other.position);

        
        /// <summary>
        /// Get the distance between this and another position.
        /// </summary>
        /// <param name="self">This object.</param>
        /// <param name="other">The other position.</param>
        /// <returns>The distance.</returns>
        public static float Distance([NotNull] this GameObject self, Vector3 other) => self.transform.position.Distance(other);
        
        /// <summary>
        /// Get the distance between this and another position.
        /// </summary>
        /// <param name="self">This object.</param>
        /// <param name="other">The other position.</param>
        /// <returns>The distance.</returns>
        public static float Distance([NotNull] this GameObject self, [NotNull] Component other) => self.transform.position.Distance(other.transform.position);
        
        /// <summary>
        /// Get the distance between this and another position.
        /// </summary>
        /// <param name="self">This object.</param>
        /// <param name="other">The other position.</param>
        /// <returns>The distance.</returns>
        public static float Distance([NotNull] this GameObject self, [NotNull] GameObject other) => self.transform.position.Distance(other.transform.position);
        
        /// <summary>
        /// Get the distance between this and another position.
        /// </summary>
        /// <param name="self">This object.</param>
        /// <param name="other">The other position.</param>
        /// <returns>The distance.</returns>
        public static float Distance([NotNull] this GameObject self, [NotNull] KaijuAgent other) => self.transform.position.Distance(other.transform.position);
        
        /// <summary>
        /// Get the distance between this and another position.
        /// </summary>
        /// <param name="self">This object.</param>
        /// <param name="other">The other position.</param>
        /// <returns>The distance.</returns>
        public static float Distance([NotNull] this GameObject self, [NotNull] KaijuSensor other) => self.transform.position.Distance(other.transform.position);
        
        /// <summary>
        /// If this is within a distance to another position.
        /// </summary>
        /// <param name="self">This position.</param>
        /// <param name="other">The other position.</param>
        /// <param name="distance">The distance.</param>
        /// <returns>If this is within a distance to another position.</returns>
        public static bool Within(this Vector2 self, Vector2 other, float distance) => self.Distance(other) <= distance;
        
        /// <summary>
        /// If this is within a distance to another position.
        /// </summary>
        /// <param name="self">This position.</param>
        /// <param name="other">The other position.</param>
        /// <param name="distance">The distance.</param>
        /// <returns>If this is within a distance to another position.</returns>
        public static bool Within(this Vector2 self, Vector3 other, float distance) => self.Within(new Vector2(other.x, other.z), distance);
        
        /// <summary>
        /// If this is within a distance to another position.
        /// </summary>
        /// <param name="self">This position.</param>
        /// <param name="other">The other position.</param>
        /// <param name="distance">The distance.</param>
        /// <returns>If this is within a distance to another position.</returns>
        public static bool Within(this Vector2 self, [NotNull] Transform other, float distance) => self.Within(other.position, distance);
        
        /// <summary>
        /// If this is within a distance to another position.
        /// </summary>
        /// <param name="self">This position.</param>
        /// <param name="other">The other position.</param>
        /// <param name="distance">The distance.</param>
        /// <returns>If this is within a distance to another position.</returns>
        public static bool Within(this Vector2 self, [NotNull] Component other, float distance) => self.Within(other.transform.position, distance);
        
        /// <summary>
        /// If this is within a distance to another position.
        /// </summary>
        /// <param name="self">This position.</param>
        /// <param name="other">The other position.</param>
        /// <param name="distance">The distance.</param>
        /// <returns>If this is within a distance to another position.</returns>
        public static bool Within(this Vector2 self, [NotNull] GameObject other, float distance) => self.Within(other.transform.position, distance);
        
        /// <summary>
        /// If this is within a distance to another position.
        /// </summary>
        /// <param name="self">This position.</param>
        /// <param name="other">The other position.</param>
        /// <param name="distance">The distance.</param>
        /// <returns>If this is within a distance to another position.</returns>
        public static bool Within(this Vector2 self, [NotNull] KaijuAgent other, float distance) => self.Within(other.transform.position, distance);
        
        /// <summary>
        /// If this is within a distance to another position.
        /// </summary>
        /// <param name="self">This position.</param>
        /// <param name="other">The other position.</param>
        /// <param name="distance">The distance.</param>
        /// <returns>If this is within a distance to another position.</returns>
        public static bool Within(this Vector2 self, [NotNull] KaijuSensor other, float distance) => self.Within(other.transform.position, distance);

        /// <summary>
        /// If this is within a distance to another position.
        /// </summary>
        /// <param name="self">This position.</param>
        /// <param name="other">The other position.</param>
        /// <param name="distance">The distance.</param>
        /// <returns>If this is within a distance to another position.</returns>
        public static bool Within(this Vector3 self, Vector2 other, float distance) => other.Within(self, distance);
        
        /// <summary>
        /// If this is within a distance to another position.
        /// </summary>
        /// <param name="self">This position.</param>
        /// <param name="other">The other position.</param>
        /// <param name="distance">The distance.</param>
        /// <returns>If this is within a distance to another position.</returns>
        public static bool Within(this Vector3 self, Vector3 other, float distance) => self.Distance(other) <= distance;
        
        /// <summary>
        /// If this is within a distance to another position.
        /// </summary>
        /// <param name="self">This position.</param>
        /// <param name="other">The other position.</param>
        /// <param name="distance">The distance.</param>
        /// <returns>If this is within a distance to another position.</returns>
        public static bool Within(this Vector3 self, [NotNull] Transform other, float distance) => self.Within(other.position, distance);
        
        /// <summary>
        /// If this is within a distance to another position.
        /// </summary>
        /// <param name="self">This position.</param>
        /// <param name="other">The other position.</param>
        /// <param name="distance">The distance.</param>
        /// <returns>If this is within a distance to another position.</returns>
        public static bool Within(this Vector3 self, [NotNull] Component other, float distance) => self.Within(other.transform.position, distance);
        
        /// <summary>
        /// If this is within a distance to another position.
        /// </summary>
        /// <param name="self">This position.</param>
        /// <param name="other">The other position.</param>
        /// <param name="distance">The distance.</param>
        /// <returns>If this is within a distance to another position.</returns>
        public static bool Within(this Vector3 self, [NotNull] GameObject other, float distance) => self.Within(other.transform.position, distance);
        
        /// <summary>
        /// If this is within a distance to another position.
        /// </summary>
        /// <param name="self">This position.</param>
        /// <param name="other">The other position.</param>
        /// <param name="distance">The distance.</param>
        /// <returns>If this is within a distance to another position.</returns>
        public static bool Within(this Vector3 self, [NotNull] KaijuAgent other, float distance) => self.Within(other.transform.position, distance);
        
        /// <summary>
        /// If this is within a distance to another position.
        /// </summary>
        /// <param name="self">This position.</param>
        /// <param name="other">The other position.</param>
        /// <param name="distance">The distance.</param>
        /// <returns>If this is within a distance to another position.</returns>
        public static bool Within(this Vector3 self, [NotNull] KaijuSensor other, float distance) => self.Within(other.transform.position, distance);
        
        /// <summary>
        /// If this is beyond a distance to another position.
        /// </summary>
        /// <param name="self">This position.</param>
        /// <param name="other">The other position.</param>
        /// <param name="distance">The distance.</param>
        /// <returns>If this is beyond a distance to another position.</returns>
        public static bool Beyond(this Vector2 self, Vector2 other, float distance) => self.Distance(other) >= distance;
        
        /// <summary>
        /// If this is beyond a distance to another position.
        /// </summary>
        /// <param name="self">This position.</param>
        /// <param name="other">The other position.</param>
        /// <param name="distance">The distance.</param>
        /// <returns>If this is beyond a distance to another position.</returns>
        public static bool Beyond(this Vector2 self, Vector3 other, float distance) => self.Beyond(new Vector2(other.x, other.z), distance);
        
        /// <summary>
        /// If this is beyond a distance to another position.
        /// </summary>
        /// <param name="self">This position.</param>
        /// <param name="other">The other position.</param>
        /// <param name="distance">The distance.</param>
        /// <returns>If this is beyond a distance to another position.</returns>
        public static bool Beyond(this Vector2 self, [NotNull] Transform other, float distance) => self.Beyond(other.position, distance);
        
        /// <summary>
        /// If this is beyond a distance to another position.
        /// </summary>
        /// <param name="self">This position.</param>
        /// <param name="other">The other position.</param>
        /// <param name="distance">The distance.</param>
        /// <returns>If this is beyond a distance to another position.</returns>
        public static bool Beyond(this Vector2 self, [NotNull] Component other, float distance) => self.Beyond(other.transform.position, distance);
        
        /// <summary>
        /// If this is beyond a distance to another position.
        /// </summary>
        /// <param name="self">This position.</param>
        /// <param name="other">The other position.</param>
        /// <param name="distance">The distance.</param>
        /// <returns>If this is beyond a distance to another position.</returns>
        public static bool Beyond(this Vector2 self, [NotNull] GameObject other, float distance) => self.Beyond(other.transform.position, distance);
        
        /// <summary>
        /// If this is beyond a distance to another position.
        /// </summary>
        /// <param name="self">This position.</param>
        /// <param name="other">The other position.</param>
        /// <param name="distance">The distance.</param>
        /// <returns>If this is beyond a distance to another position.</returns>
        public static bool Beyond(this Vector2 self, [NotNull] KaijuAgent other, float distance) => self.Beyond(other.transform.position, distance);
        
        /// <summary>
        /// If this is beyond a distance to another position.
        /// </summary>
        /// <param name="self">This position.</param>
        /// <param name="other">The other position.</param>
        /// <param name="distance">The distance.</param>
        /// <returns>If this is beyond a distance to another position.</returns>
        public static bool Beyond(this Vector2 self, [NotNull] KaijuSensor other, float distance) => self.Beyond(other.transform.position, distance);

        /// <summary>
        /// If this is beyond a distance to another position.
        /// </summary>
        /// <param name="self">This position.</param>
        /// <param name="other">The other position.</param>
        /// <param name="distance">The distance.</param>
        /// <returns>If this is beyond a distance to another position.</returns>
        public static bool Beyond(this Vector3 self, Vector2 other, float distance) => other.Beyond(self, distance);
        
        /// <summary>
        /// If this is beyond a distance to another position.
        /// </summary>
        /// <param name="self">This position.</param>
        /// <param name="other">The other position.</param>
        /// <param name="distance">The distance.</param>
        /// <returns>If this is beyond a distance to another position.</returns>
        public static bool Beyond(this Vector3 self, Vector3 other, float distance) => self.Distance(other) >= distance;
        
        /// <summary>
        /// If this is beyond a distance to another position.
        /// </summary>
        /// <param name="self">This position.</param>
        /// <param name="other">The other position.</param>
        /// <param name="distance">The distance.</param>
        /// <returns>If this is beyond a distance to another position.</returns>
        public static bool Beyond(this Vector3 self, [NotNull] Transform other, float distance) => self.Beyond(other.position, distance);
        
        /// <summary>
        /// If this is beyond a distance to another position.
        /// </summary>
        /// <param name="self">This position.</param>
        /// <param name="other">The other position.</param>
        /// <param name="distance">The distance.</param>
        /// <returns>If this is beyond a distance to another position.</returns>
        public static bool Beyond(this Vector3 self, [NotNull] Component other, float distance) => self.Beyond(other.transform.position, distance);
        
        /// <summary>
        /// If this is beyond a distance to another position.
        /// </summary>
        /// <param name="self">This position.</param>
        /// <param name="other">The other position.</param>
        /// <param name="distance">The distance.</param>
        /// <returns>If this is beyond a distance to another position.</returns>
        public static bool Beyond(this Vector3 self, [NotNull] GameObject other, float distance) => self.Beyond(other.transform.position, distance);
        
        /// <summary>
        /// If this is beyond a distance to another position.
        /// </summary>
        /// <param name="self">This position.</param>
        /// <param name="other">The other position.</param>
        /// <param name="distance">The distance.</param>
        /// <returns>If this is beyond a distance to another position.</returns>
        public static bool Beyond(this Vector3 self, [NotNull] KaijuAgent other, float distance) => self.Beyond(other.transform.position, distance);
        
        /// <summary>
        /// If this is beyond a distance to another position.
        /// </summary>
        /// <param name="self">This position.</param>
        /// <param name="other">The other position.</param>
        /// <param name="distance">The distance.</param>
        /// <returns>If this is beyond a distance to another position.</returns>
        public static bool Beyond(this Vector3 self, [NotNull] KaijuSensor other, float distance) => self.Beyond(other.transform.position, distance);

        /// <summary>
        /// If this is beyond a distance to another position.
        /// </summary>
        /// <param name="self">This object.</param>
        /// <param name="other">The other position.</param>
        /// <param name="distance">The distance.</param>
        /// <returns>If this is beyond a distance to another position.</returns>
        public static bool Beyond([NotNull] this Transform self, Vector2 other, float distance) => other.Beyond(self.position, distance);
        
        /// <summary>
        /// If this is beyond a distance to another position.
        /// </summary>
        /// <param name="self">This object.</param>
        /// <param name="other">The other position.</param>
        /// <param name="distance">The distance.</param>
        /// <returns>If this is beyond a distance to another position.</returns>
        public static bool Beyond([NotNull] this Transform self, Vector3 other, float distance) => self.position.Distance(other) >= distance;
        
        /// <summary>
        /// If this is beyond a distance to another position.
        /// </summary>
        /// <param name="self">This object.</param>
        /// <param name="other">The other position.</param>
        /// <param name="distance">The distance.</param>
        /// <returns>If this is beyond a distance to another position.</returns>
        public static bool Beyond([NotNull] this Transform self, [NotNull] Transform other, float distance) => self.position.Beyond(other.position, distance);
        
        /// <summary>
        /// If this is beyond a distance to another position.
        /// </summary>
        /// <param name="self">This object.</param>
        /// <param name="other">The other position.</param>
        /// <param name="distance">The distance.</param>
        /// <returns>If this is beyond a distance to another position.</returns>
        public static bool Beyond([NotNull] this Transform self, [NotNull] Component other, float distance) => self.position.Beyond(other.transform.position, distance);
        
        /// <summary>
        /// If this is beyond a distance to another position.
        /// </summary>
        /// <param name="self">This object.</param>
        /// <param name="other">The other position.</param>
        /// <param name="distance">The distance.</param>
        /// <returns>If this is beyond a distance to another position.</returns>
        public static bool Beyond([NotNull] this Transform self, [NotNull] GameObject other, float distance) => self.position.Beyond(other.transform.position, distance);
        
        /// <summary>
        /// If this is beyond a distance to another position.
        /// </summary>
        /// <param name="self">This object.</param>
        /// <param name="other">The other position.</param>
        /// <param name="distance">The distance.</param>
        /// <returns>If this is beyond a distance to another position.</returns>
        public static bool Beyond([NotNull] this Transform self, [NotNull] KaijuAgent other, float distance) => self.position.Beyond(other.transform.position, distance);
        
        /// <summary>
        /// If this is beyond a distance to another position.
        /// </summary>
        /// <param name="self">This object.</param>
        /// <param name="other">The other position.</param>
        /// <param name="distance">The distance.</param>
        /// <returns>If this is beyond a distance to another position.</returns>
        public static bool Beyond([NotNull] this Transform self, [NotNull] KaijuSensor other, float distance) => self.position.Beyond(other.transform.position, distance);

        /// <summary>
        /// If this is beyond a distance to another position.
        /// </summary>
        /// <param name="self">This object.</param>
        /// <param name="other">The other position.</param>
        /// <param name="distance">The distance.</param>
        /// <returns>If this is beyond a distance to another position.</returns>
        public static bool Beyond([NotNull] this Component self, Vector2 other, float distance) => other.Beyond(self.transform.position, distance);
        
        /// <summary>
        /// If this is beyond a distance to another position.
        /// </summary>
        /// <param name="self">This object.</param>
        /// <param name="other">The other position.</param>
        /// <param name="distance">The distance.</param>
        /// <returns>If this is beyond a distance to another position.</returns>
        public static bool Beyond([NotNull] this Component self, Vector3 other, float distance) => self.transform.position.Distance(other) >= distance;
        
        /// <summary>
        /// If this is beyond a distance to another position.
        /// </summary>
        /// <param name="self">This object.</param>
        /// <param name="other">The other position.</param>
        /// <param name="distance">The distance.</param>
        /// <returns>If this is beyond a distance to another position.</returns>
        public static bool Beyond([NotNull] this Component self, [NotNull] Transform other, float distance) => self.transform.position.Beyond(other.position, distance);
        
        /// <summary>
        /// If this is beyond a distance to another position.
        /// </summary>
        /// <param name="self">This object.</param>
        /// <param name="other">The other position.</param>
        /// <param name="distance">The distance.</param>
        /// <returns>If this is beyond a distance to another position.</returns>
        public static bool Beyond([NotNull] this Component self, [NotNull] Component other, float distance) => self.transform.position.Beyond(other.transform.position, distance);
        
        /// <summary>
        /// If this is beyond a distance to another position.
        /// </summary>
        /// <param name="self">This object.</param>
        /// <param name="other">The other position.</param>
        /// <param name="distance">The distance.</param>
        /// <returns>If this is beyond a distance to another position.</returns>
        public static bool Beyond([NotNull] this Component self, [NotNull] GameObject other, float distance) => self.transform.position.Beyond(other.transform.position, distance);
        
        /// <summary>
        /// If this is beyond a distance to another position.
        /// </summary>
        /// <param name="self">This object.</param>
        /// <param name="other">The other position.</param>
        /// <param name="distance">The distance.</param>
        /// <returns>If this is beyond a distance to another position.</returns>
        public static bool Beyond([NotNull] this Component self, [NotNull] KaijuAgent other, float distance) => self.transform.position.Beyond(other.transform.position, distance);
        
        /// <summary>
        /// If this is beyond a distance to another position.
        /// </summary>
        /// <param name="self">This object.</param>
        /// <param name="other">The other position.</param>
        /// <param name="distance">The distance.</param>
        /// <returns>If this is beyond a distance to another position.</returns>
        public static bool Beyond([NotNull] this Component self, [NotNull] KaijuSensor other, float distance) => self.transform.position.Beyond(other.transform.position, distance);

        /// <summary>
        /// If this is beyond a distance to another position.
        /// </summary>
        /// <param name="self">This object.</param>
        /// <param name="other">The other position.</param>
        /// <param name="distance">The distance.</param>
        /// <returns>If this is beyond a distance to another position.</returns>
        public static bool Beyond([NotNull] this GameObject self, Vector2 other, float distance) => other.Beyond(self.transform.position, distance);
        
        /// <summary>
        /// If this is beyond a distance to another position.
        /// </summary>
        /// <param name="self">This object.</param>
        /// <param name="other">The other position.</param>
        /// <param name="distance">The distance.</param>
        /// <returns>If this is beyond a distance to another position.</returns>
        public static bool Beyond([NotNull] this GameObject self, Vector3 other, float distance) => self.transform.position.Distance(other) >= distance;
        
        /// <summary>
        /// If this is beyond a distance to another position.
        /// </summary>
        /// <param name="self">This object.</param>
        /// <param name="other">The other position.</param>
        /// <param name="distance">The distance.</param>
        /// <returns>If this is beyond a distance to another position.</returns>
        public static bool Beyond([NotNull] this GameObject self, [NotNull] Transform other, float distance) => self.transform.position.Beyond(other.position, distance);
        
        /// <summary>
        /// If this is beyond a distance to another position.
        /// </summary>
        /// <param name="self">This object.</param>
        /// <param name="other">The other position.</param>
        /// <param name="distance">The distance.</param>
        /// <returns>If this is beyond a distance to another position.</returns>
        public static bool Beyond([NotNull] this GameObject self, [NotNull] Component other, float distance) => self.transform.position.Beyond(other.transform.position, distance);
        
        /// <summary>
        /// If this is beyond a distance to another position.
        /// </summary>
        /// <param name="self">This object.</param>
        /// <param name="other">The other position.</param>
        /// <param name="distance">The distance.</param>
        /// <returns>If this is beyond a distance to another position.</returns>
        public static bool Beyond([NotNull] this GameObject self, [NotNull] GameObject other, float distance) => self.transform.position.Beyond(other.transform.position, distance);
        
        /// <summary>
        /// If this is beyond a distance to another position.
        /// </summary>
        /// <param name="self">This object.</param>
        /// <param name="other">The other position.</param>
        /// <param name="distance">The distance.</param>
        /// <returns>If this is beyond a distance to another position.</returns>
        public static bool Beyond([NotNull] this GameObject self, [NotNull] KaijuAgent other, float distance) => self.transform.position.Beyond(other.transform.position, distance);
        
        /// <summary>
        /// If this is beyond a distance to another position.
        /// </summary>
        /// <param name="self">This object.</param>
        /// <param name="other">The other position.</param>
        /// <param name="distance">The distance.</param>
        /// <returns>If this is beyond a distance to another position.</returns>
        public static bool Beyond([NotNull] this GameObject self, [NotNull] KaijuSensor other, float distance) => self.transform.position.Beyond(other.transform.position, distance);
        
        /// <summary>
        /// If this is between two distances to another position.
        /// </summary>
        /// <param name="self">This position.</param>
        /// <param name="other">The other position.</param>
        /// <param name="minimum">The minimum distance.</param>
        /// <param name="maximum">The maximum distance.</param>
        /// <returns>If this is between two distances to another position.</returns>
        public static bool Between(this Vector2 self, Vector2 other, float minimum, float maximum)
        {
            float distance = self.Distance(other);
            return distance >= minimum && distance <= maximum;
        }
        
        /// <summary>
        /// If this is between two distances to another position.
        /// </summary>
        /// <param name="self">This position.</param>
        /// <param name="other">The other position.</param>
        /// <param name="minimum">The minimum distance.</param>
        /// <param name="maximum">The maximum distance.</param>
        /// <returns>If this is between two distances to another position.</returns>
        public static bool Between(this Vector2 self, Vector3 other, float minimum, float maximum) => self.Between(new Vector2(other.x, other.z), minimum, maximum);
        
        /// <summary>
        /// If this is between two distances to another position.
        /// </summary>
        /// <param name="self">This position.</param>
        /// <param name="other">The other position.</param>
        /// <param name="minimum">The minimum distance.</param>
        /// <param name="maximum">The maximum distance.</param>
        /// <returns>If this is between two distances to another position.</returns>
        public static bool Between(this Vector2 self, [NotNull] Transform other, float minimum, float maximum) => self.Between(other.position, minimum, maximum);
        
        /// <summary>
        /// If this is between two distances to another position.
        /// </summary>
        /// <param name="self">This position.</param>
        /// <param name="other">The other position.</param>
        /// <param name="minimum">The minimum distance.</param>
        /// <param name="maximum">The maximum distance.</param>
        /// <returns>If this is between two distances to another position.</returns>
        public static bool Between(this Vector2 self, [NotNull] Component other, float minimum, float maximum) => self.Between(other.transform.position, minimum, maximum);
        
        /// <summary>
        /// If this is between two distances to another position.
        /// </summary>
        /// <param name="self">This position.</param>
        /// <param name="other">The other position.</param>
        /// <param name="minimum">The minimum distance.</param>
        /// <param name="maximum">The maximum distance.</param>
        /// <returns>If this is between two distances to another position.</returns>
        public static bool Between(this Vector2 self, [NotNull] GameObject other, float minimum, float maximum) => self.Between(other.transform.position, minimum, maximum);
        
        /// <summary>
        /// If this is between two distances to another position.
        /// </summary>
        /// <param name="self">This position.</param>
        /// <param name="other">The other position.</param>
        /// <param name="minimum">The minimum distance.</param>
        /// <param name="maximum">The maximum distance.</param>
        /// <returns>If this is between two distances to another position.</returns>
        public static bool Between(this Vector2 self, [NotNull] KaijuAgent other, float minimum, float maximum) => self.Between(other.transform.position, minimum, maximum);
        
        /// <summary>
        /// If this is between two distances to another position.
        /// </summary>
        /// <param name="self">This position.</param>
        /// <param name="other">The other position.</param>
        /// <param name="minimum">The minimum distance.</param>
        /// <param name="maximum">The maximum distance.</param>
        /// <returns>If this is between two distances to another position.</returns>
        public static bool Between(this Vector2 self, [NotNull] KaijuSensor other, float minimum, float maximum) => self.Between(other.transform.position, minimum, maximum);
        
        /// <summary>
        /// If this is between two distances to another position.
        /// </summary>
        /// <param name="self">This position.</param>
        /// <param name="other">The other position.</param>
        /// <param name="minimum">The minimum distance.</param>
        /// <param name="maximum">The maximum distance.</param>
        /// <returns>If this is between two distances to another position.</returns>
        public static bool Between(this Vector3 self, Vector2 other, float minimum, float maximum) => other.Between(self, minimum, maximum);

        /// <summary>
        /// If this is between two distances to another position.
        /// </summary>
        /// <param name="self">This position.</param>
        /// <param name="other">The other position.</param>
        /// <param name="minimum">The minimum distance.</param>
        /// <param name="maximum">The maximum distance.</param>
        /// <returns>If this is between two distances to another position.</returns>
        public static bool Between(this Vector3 self, Vector3 other, float minimum, float maximum) => new Vector2(self.x, self.z).Between(other, minimum, maximum);
        
        /// <summary>
        /// If this is between two distances to another position.
        /// </summary>
        /// <param name="self">This position.</param>
        /// <param name="other">The other position.</param>
        /// <param name="minimum">The minimum distance.</param>
        /// <param name="maximum">The maximum distance.</param>
        /// <returns>If this is between two distances to another position.</returns>
        public static bool Between(this Vector3 self, [NotNull] Transform other, float minimum, float maximum) => self.Between(other.position, minimum, maximum);
        
        /// <summary>
        /// If this is between two distances to another position.
        /// </summary>
        /// <param name="self">This position.</param>
        /// <param name="other">The other position.</param>
        /// <param name="minimum">The minimum distance.</param>
        /// <param name="maximum">The maximum distance.</param>
        /// <returns>If this is between two distances to another position.</returns>
        public static bool Between(this Vector3 self, [NotNull] Component other, float minimum, float maximum) => self.Between(other.transform.position, minimum, maximum);
        
        /// <summary>
        /// If this is between two distances to another position.
        /// </summary>
        /// <param name="self">This position.</param>
        /// <param name="other">The other position.</param>
        /// <param name="minimum">The minimum distance.</param>
        /// <param name="maximum">The maximum distance.</param>
        /// <returns>If this is between two distances to another position.</returns>
        public static bool Between(this Vector3 self, [NotNull] GameObject other, float minimum, float maximum) => self.Between(other.transform.position, minimum, maximum);
        
        /// <summary>
        /// If this is between two distances to another position.
        /// </summary>
        /// <param name="self">This position.</param>
        /// <param name="other">The other position.</param>
        /// <param name="minimum">The minimum distance.</param>
        /// <param name="maximum">The maximum distance.</param>
        /// <returns>If this is between two distances to another position.</returns>
        public static bool Between(this Vector3 self, [NotNull] KaijuAgent other, float minimum, float maximum) => self.Between(other.transform.position, minimum, maximum);
        
        /// <summary>
        /// If this is between two distances to another position.
        /// </summary>
        /// <param name="self">This position.</param>
        /// <param name="other">The other position.</param>
        /// <param name="minimum">The minimum distance.</param>
        /// <param name="maximum">The maximum distance.</param>
        /// <returns>If this is between two distances to another position.</returns>
        public static bool Between(this Vector3 self, [NotNull] KaijuSensor other, float minimum, float maximum) => self.Between(other.transform.position, minimum, maximum);
        
        /// <summary>
        /// If this is between two distances to another position.
        /// </summary>
        /// <param name="self">This position.</param>
        /// <param name="other">The other position.</param>
        /// <param name="minimum">The minimum distance.</param>
        /// <param name="maximum">The maximum distance.</param>
        /// <returns>If this is between two distances to another position.</returns>
        public static bool Between([NotNull] this Transform self, Vector2 other, float minimum, float maximum) => other.Between(self.position, minimum, maximum);
        
        /// <summary>
        /// If this is between two distances to another position.
        /// </summary>
        /// <param name="self">This position.</param>
        /// <param name="other">The other position.</param>
        /// <param name="minimum">The minimum distance.</param>
        /// <param name="maximum">The maximum distance.</param>
        /// <returns>If this is between two distances to another position.</returns>
        public static bool Between([NotNull] this Transform self, Vector3 other, float minimum, float maximum) => self.position.Between(other, minimum, maximum);
        
        /// <summary>
        /// If this is between two distances to another position.
        /// </summary>
        /// <param name="self">This position.</param>
        /// <param name="other">The other position.</param>
        /// <param name="minimum">The minimum distance.</param>
        /// <param name="maximum">The maximum distance.</param>
        /// <returns>If this is between two distances to another position.</returns>
        public static bool Between([NotNull] this Transform self, [NotNull] Transform other, float minimum, float maximum) => self.position.Between(other.position, minimum, maximum);
        
        /// <summary>
        /// If this is between two distances to another position.
        /// </summary>
        /// <param name="self">This position.</param>
        /// <param name="other">The other position.</param>
        /// <param name="minimum">The minimum distance.</param>
        /// <param name="maximum">The maximum distance.</param>
        /// <returns>If this is between two distances to another position.</returns>
        public static bool Between([NotNull] this Transform self, [NotNull] Component other, float minimum, float maximum) => self.position.Between(other.transform.position, minimum, maximum);
        
        /// <summary>
        /// If this is between two distances to another position.
        /// </summary>
        /// <param name="self">This position.</param>
        /// <param name="other">The other position.</param>
        /// <param name="minimum">The minimum distance.</param>
        /// <param name="maximum">The maximum distance.</param>
        /// <returns>If this is between two distances to another position.</returns>
        public static bool Between([NotNull] this Transform self, [NotNull] GameObject other, float minimum, float maximum) => self.position.Between(other.transform.position, minimum, maximum);
        
        /// <summary>
        /// If this is between two distances to another position.
        /// </summary>
        /// <param name="self">This position.</param>
        /// <param name="other">The other position.</param>
        /// <param name="minimum">The minimum distance.</param>
        /// <param name="maximum">The maximum distance.</param>
        /// <returns>If this is between two distances to another position.</returns>
        public static bool Between([NotNull] this Transform self, [NotNull] KaijuAgent other, float minimum, float maximum) => self.position.Between(other.transform.position, minimum, maximum);
        
        /// <summary>
        /// If this is between two distances to another position.
        /// </summary>
        /// <param name="self">This position.</param>
        /// <param name="other">The other position.</param>
        /// <param name="minimum">The minimum distance.</param>
        /// <param name="maximum">The maximum distance.</param>
        /// <returns>If this is between two distances to another position.</returns>
        public static bool Between([NotNull] this Transform self, [NotNull] KaijuSensor other, float minimum, float maximum) => self.position.Between(other.transform.position, minimum, maximum);
        
        /// <summary>
        /// If this is between two distances to another position.
        /// </summary>
        /// <param name="self">This position.</param>
        /// <param name="other">The other position.</param>
        /// <param name="minimum">The minimum distance.</param>
        /// <param name="maximum">The maximum distance.</param>
        /// <returns>If this is between two distances to another position.</returns>
        public static bool Between([NotNull] this Component self, Vector2 other, float minimum, float maximum) => other.Between(self.transform.position, minimum, maximum);
        
        /// <summary>
        /// If this is between two distances to another position.
        /// </summary>
        /// <param name="self">This position.</param>
        /// <param name="other">The other position.</param>
        /// <param name="minimum">The minimum distance.</param>
        /// <param name="maximum">The maximum distance.</param>
        /// <returns>If this is between two distances to another position.</returns>
        public static bool Between([NotNull] this Component self, Vector3 other, float minimum, float maximum) => self.transform.position.Between(other, minimum, maximum);
        
        /// <summary>
        /// If this is between two distances to another position.
        /// </summary>
        /// <param name="self">This position.</param>
        /// <param name="other">The other position.</param>
        /// <param name="minimum">The minimum distance.</param>
        /// <param name="maximum">The maximum distance.</param>
        /// <returns>If this is between two distances to another position.</returns>
        public static bool Between([NotNull] this Component self, [NotNull] Transform other, float minimum, float maximum) => self.transform.position.Between(other.position, minimum, maximum);
        
        /// <summary>
        /// If this is between two distances to another position.
        /// </summary>
        /// <param name="self">This position.</param>
        /// <param name="other">The other position.</param>
        /// <param name="minimum">The minimum distance.</param>
        /// <param name="maximum">The maximum distance.</param>
        /// <returns>If this is between two distances to another position.</returns>
        public static bool Between([NotNull] this Component self, [NotNull] Component other, float minimum, float maximum) => self.transform.position.Between(other.transform.position, minimum, maximum);
        
        /// <summary>
        /// If this is between two distances to another position.
        /// </summary>
        /// <param name="self">This position.</param>
        /// <param name="other">The other position.</param>
        /// <param name="minimum">The minimum distance.</param>
        /// <param name="maximum">The maximum distance.</param>
        /// <returns>If this is between two distances to another position.</returns>
        public static bool Between([NotNull] this Component self, [NotNull] GameObject other, float minimum, float maximum) => self.transform.position.Between(other.transform.position, minimum, maximum);
        
        /// <summary>
        /// If this is between two distances to another position.
        /// </summary>
        /// <param name="self">This position.</param>
        /// <param name="other">The other position.</param>
        /// <param name="minimum">The minimum distance.</param>
        /// <param name="maximum">The maximum distance.</param>
        /// <returns>If this is between two distances to another position.</returns>
        public static bool Between([NotNull] this Component self, [NotNull] KaijuAgent other, float minimum, float maximum) => self.transform.position.Between(other.transform.position, minimum, maximum);
        
        /// <summary>
        /// If this is between two distances to another position.
        /// </summary>
        /// <param name="self">This position.</param>
        /// <param name="other">The other position.</param>
        /// <param name="minimum">The minimum distance.</param>
        /// <param name="maximum">The maximum distance.</param>
        /// <returns>If this is between two distances to another position.</returns>
        public static bool Between([NotNull] this Component self, [NotNull] KaijuSensor other, float minimum, float maximum) => self.transform.position.Between(other.transform.position, minimum, maximum);
        
        
        
        /// <summary>
        /// If this is between two distances to another position.
        /// </summary>
        /// <param name="self">This position.</param>
        /// <param name="other">The other position.</param>
        /// <param name="minimum">The minimum distance.</param>
        /// <param name="maximum">The maximum distance.</param>
        /// <returns>If this is between two distances to another position.</returns>
        public static bool Between([NotNull] this GameObject self, Vector2 other, float minimum, float maximum) => other.Between(self.transform.position, minimum, maximum);
        
        /// <summary>
        /// If this is between two distances to another position.
        /// </summary>
        /// <param name="self">This position.</param>
        /// <param name="other">The other position.</param>
        /// <param name="minimum">The minimum distance.</param>
        /// <param name="maximum">The maximum distance.</param>
        /// <returns>If this is between two distances to another position.</returns>
        public static bool Between([NotNull] this GameObject self, Vector3 other, float minimum, float maximum) => self.transform.position.Between(other, minimum, maximum);
        
        /// <summary>
        /// If this is between two distances to another position.
        /// </summary>
        /// <param name="self">This position.</param>
        /// <param name="other">The other position.</param>
        /// <param name="minimum">The minimum distance.</param>
        /// <param name="maximum">The maximum distance.</param>
        /// <returns>If this is between two distances to another position.</returns>
        public static bool Between([NotNull] this GameObject self, [NotNull] Transform other, float minimum, float maximum) => self.transform.position.Between(other.position, minimum, maximum);
        
        /// <summary>
        /// If this is between two distances to another position.
        /// </summary>
        /// <param name="self">This position.</param>
        /// <param name="other">The other position.</param>
        /// <param name="minimum">The minimum distance.</param>
        /// <param name="maximum">The maximum distance.</param>
        /// <returns>If this is between two distances to another position.</returns>
        public static bool Between([NotNull] this GameObject self, [NotNull] Component other, float minimum, float maximum) => self.transform.position.Between(other.transform.position, minimum, maximum);
        
        /// <summary>
        /// If this is between two distances to another position.
        /// </summary>
        /// <param name="self">This position.</param>
        /// <param name="other">The other position.</param>
        /// <param name="minimum">The minimum distance.</param>
        /// <param name="maximum">The maximum distance.</param>
        /// <returns>If this is between two distances to another position.</returns>
        public static bool Between([NotNull] this GameObject self, [NotNull] GameObject other, float minimum, float maximum) => self.transform.position.Between(other.transform.position, minimum, maximum);
        
        /// <summary>
        /// If this is between two distances to another position.
        /// </summary>
        /// <param name="self">This position.</param>
        /// <param name="other">The other position.</param>
        /// <param name="minimum">The minimum distance.</param>
        /// <param name="maximum">The maximum distance.</param>
        /// <returns>If this is between two distances to another position.</returns>
        public static bool Between([NotNull] this GameObject self, [NotNull] KaijuAgent other, float minimum, float maximum) => self.transform.position.Between(other.transform.position, minimum, maximum);
        
        /// <summary>
        /// If this is between two distances to another position.
        /// </summary>
        /// <param name="self">This position.</param>
        /// <param name="other">The other position.</param>
        /// <param name="minimum">The minimum distance.</param>
        /// <param name="maximum">The maximum distance.</param>
        /// <returns>If this is between two distances to another position.</returns>
        public static bool Between([NotNull] this GameObject self, [NotNull] KaijuSensor other, float minimum, float maximum) => self.transform.position.Between(other.transform.position, minimum, maximum);
        
        /// <summary>
        /// Get the distance between this and another position.
        /// </summary>
        /// <param name="self">This position.</param>
        /// <param name="other">The other position.</param>
        /// <returns>The distance.</returns>
        public static float Distance3(this Vector3 self, Vector3 other) => Vector3.Distance(self, other);
        
        /// <summary>
        /// Get the distance between this and another position.
        /// </summary>
        /// <param name="self">This position.</param>
        /// <param name="other">The other position.</param>
        /// <returns>The distance.</returns>
        public static float Distance3(this Vector3 self, [NotNull] Transform other) => self.Distance3(other.position);
        
        /// <summary>
        /// Get the distance between this and another position.
        /// </summary>
        /// <param name="self">This position.</param>
        /// <param name="other">The other position.</param>
        /// <returns>The distance.</returns>
        public static float Distance3(this Vector3 self, [NotNull] Component other) => self.Distance3(other.transform.position);
        
        /// <summary>
        /// Get the distance between this and another position.
        /// </summary>
        /// <param name="self">This position.</param>
        /// <param name="other">The other position.</param>
        /// <returns>The distance.</returns>
        public static float Distance3(this Vector3 self, [NotNull] GameObject other) => self.Distance3(other.transform.position);
        
        /// <summary>
        /// Get the distance between this and another position.
        /// </summary>
        /// <param name="self">This position.</param>
        /// <param name="other">The other position.</param>
        /// <returns>The distance.</returns>
        public static float Distance3(this Vector3 self, [NotNull] KaijuAgent other) => self.Distance3(other.transform.position);
        
        /// <summary>
        /// Get the distance between this and another position.
        /// </summary>
        /// <param name="self">This position.</param>
        /// <param name="other">The other position.</param>
        /// <returns>The distance.</returns>
        public static float Distance3(this Vector3 self, [NotNull] KaijuSensor other) => self.Distance3(other.transform.position);
        
        /// <summary>
        /// Get the distance between this and another position.
        /// </summary>
        /// <param name="self">This object.</param>
        /// <param name="other">The other position.</param>
        /// <returns>The distance.</returns>
        public static float Distance3([NotNull] this Transform self, Vector3 other) => self.position.Distance3(other);
        
        /// <summary>
        /// Get the distance between this and another position.
        /// </summary>
        /// <param name="self">This object.</param>
        /// <param name="other">The other position.</param>
        /// <returns>The distance.</returns>
        public static float Distance3([NotNull] this Transform self, [NotNull] Transform other) => self.position.Distance3(other.position);
        
        /// <summary>
        /// Get the distance between this and another position.
        /// </summary>
        /// <param name="self">This object.</param>
        /// <param name="other">The other position.</param>
        /// <returns>The distance.</returns>
        public static float Distance3([NotNull] this Transform self, [NotNull] Component other) => self.position.Distance3(other.transform.position);
        
        /// <summary>
        /// Get the distance between this and another position.
        /// </summary>
        /// <param name="self">This object.</param>
        /// <param name="other">The other position.</param>
        /// <returns>The distance.</returns>
        public static float Distance3([NotNull] this Transform self, [NotNull] GameObject other) => self.position.Distance3(other.transform.position);
        
        /// <summary>
        /// Get the distance between this and another position.
        /// </summary>
        /// <param name="self">This object.</param>
        /// <param name="other">The other position.</param>
        /// <returns>The distance.</returns>
        public static float Distance3([NotNull] this Transform self, [NotNull] KaijuAgent other) => self.position.Distance3(other.transform.position);
        
        /// <summary>
        /// Get the distance between this and another position.
        /// </summary>
        /// <param name="self">This object.</param>
        /// <param name="other">The other position.</param>
        /// <returns>The distance.</returns>
        public static float Distance3([NotNull] this Transform self, [NotNull] KaijuSensor other) => self.position.Distance3(other.transform.position);
        
        /// <summary>
        /// Get the distance between this and another position.
        /// </summary>
        /// <param name="self">This object.</param>
        /// <param name="other">The other position.</param>
        /// <returns>The distance.</returns>
        public static float Distance3([NotNull] this Component self, Vector3 other) => self.transform.position.Distance3(other);
        
        /// <summary>
        /// Get the distance between this and another position.
        /// </summary>
        /// <param name="self">This object.</param>
        /// <param name="other">The other position.</param>
        /// <returns>The distance.</returns>
        public static float Distance3([NotNull] this Component self, [NotNull] Transform other) => self.transform.position.Distance3(other.position);
        
        /// <summary>
        /// Get the distance between this and another position.
        /// </summary>
        /// <param name="self">This object.</param>
        /// <param name="other">The other position.</param>
        /// <returns>The distance.</returns>
        public static float Distance3([NotNull] this Component self, [NotNull] Component other) => self.transform.position.Distance3(other.transform.position);
        
        /// <summary>
        /// Get the distance between this and another position.
        /// </summary>
        /// <param name="self">This object.</param>
        /// <param name="other">The other position.</param>
        /// <returns>The distance.</returns>
        public static float Distance3([NotNull] this Component self, [NotNull] GameObject other) => self.transform.position.Distance3(other.transform.position);
        
        /// <summary>
        /// Get the distance between this and another position.
        /// </summary>
        /// <param name="self">This object.</param>
        /// <param name="other">The other position.</param>
        /// <returns>The distance.</returns>
        public static float Distance3([NotNull] this Component self, [NotNull] KaijuAgent other) => self.transform.position.Distance3(other.transform.position);
        
        /// <summary>
        /// Get the distance between this and another position.
        /// </summary>
        /// <param name="self">This object.</param>
        /// <param name="other">The other position.</param>
        /// <returns>The distance.</returns>
        public static float Distance3([NotNull] this Component self, [NotNull] KaijuSensor other) => self.transform.position.Distance3(other.transform.position);
        
        /// <summary>
        /// Get the distance between this and another position.
        /// </summary>
        /// <param name="self">This object.</param>
        /// <param name="other">The other position.</param>
        /// <returns>The distance.</returns>
        public static float Distance3([NotNull] this GameObject self, [NotNull] Transform other) => self.transform.position.Distance3(other.position);

        
        /// <summary>
        /// Get the distance between this and another position.
        /// </summary>
        /// <param name="self">This object.</param>
        /// <param name="other">The other position.</param>
        /// <returns>The distance.</returns>
        public static float Distance3([NotNull] this GameObject self, Vector3 other) => self.transform.position.Distance3(other);
        
        /// <summary>
        /// Get the distance between this and another position.
        /// </summary>
        /// <param name="self">This object.</param>
        /// <param name="other">The other position.</param>
        /// <returns>The distance.</returns>
        public static float Distance3([NotNull] this GameObject self, [NotNull] Component other) => self.transform.position.Distance3(other.transform.position);
        
        /// <summary>
        /// Get the distance between this and another position.
        /// </summary>
        /// <param name="self">This object.</param>
        /// <param name="other">The other position.</param>
        /// <returns>The distance.</returns>
        public static float Distance3([NotNull] this GameObject self, [NotNull] GameObject other) => self.transform.position.Distance3(other.transform.position);
        
        /// <summary>
        /// Get the distance between this and another position.
        /// </summary>
        /// <param name="self">This object.</param>
        /// <param name="other">The other position.</param>
        /// <returns>The distance.</returns>
        public static float Distance3([NotNull] this GameObject self, [NotNull] KaijuAgent other) => self.transform.position.Distance3(other.transform.position);
        
        /// <summary>
        /// Get the distance between this and another position.
        /// </summary>
        /// <param name="self">This object.</param>
        /// <param name="other">The other position.</param>
        /// <returns>The distance.</returns>
        public static float Distance3([NotNull] this GameObject self, [NotNull] KaijuSensor other) => self.transform.position.Distance3(other.transform.position);
        
        /// <summary>
        /// If this is within a distance to another position.
        /// </summary>
        /// <param name="self">This position.</param>
        /// <param name="other">The other position.</param>
        /// <param name="distance">The distance.</param>
        /// <returns>If this is within a distance to another position.</returns>
        public static bool Within3(this Vector3 self, Vector3 other, float distance) => self.Distance3(other) <= distance;
        
        /// <summary>
        /// If this is within a distance to another position.
        /// </summary>
        /// <param name="self">This position.</param>
        /// <param name="other">The other position.</param>
        /// <param name="distance">The distance.</param>
        /// <returns>If this is within a distance to another position.</returns>
        public static bool Within3(this Vector3 self, [NotNull] Transform other, float distance) => self.Within3(other.position, distance);
        
        /// <summary>
        /// If this is within a distance to another position.
        /// </summary>
        /// <param name="self">This position.</param>
        /// <param name="other">The other position.</param>
        /// <param name="distance">The distance.</param>
        /// <returns>If this is within a distance to another position.</returns>
        public static bool Within3(this Vector3 self, [NotNull] Component other, float distance) => self.Within3(other.transform.position, distance);
        
        /// <summary>
        /// If this is within a distance to another position.
        /// </summary>
        /// <param name="self">This position.</param>
        /// <param name="other">The other position.</param>
        /// <param name="distance">The distance.</param>
        /// <returns>If this is within a distance to another position.</returns>
        public static bool Within3(this Vector3 self, [NotNull] GameObject other, float distance) => self.Within3(other.transform.position, distance);
        
        /// <summary>
        /// If this is within a distance to another position.
        /// </summary>
        /// <param name="self">This position.</param>
        /// <param name="other">The other position.</param>
        /// <param name="distance">The distance.</param>
        /// <returns>If this is within a distance to another position.</returns>
        public static bool Within3(this Vector3 self, [NotNull] KaijuAgent other, float distance) => self.Within3(other.transform.position, distance);
        
        /// <summary>
        /// If this is within a distance to another position.
        /// </summary>
        /// <param name="self">This position.</param>
        /// <param name="other">The other position.</param>
        /// <param name="distance">The distance.</param>
        /// <returns>If this is within a distance to another position.</returns>
        public static bool Within3(this Vector3 self, [NotNull] KaijuSensor other, float distance) => self.Within3(other.transform.position, distance);
        
        /// <summary>
        /// If this is beyond a distance to another position.
        /// </summary>
        /// <param name="self">This position.</param>
        /// <param name="other">The other position.</param>
        /// <param name="distance">The distance.</param>
        /// <returns>If this is beyond a distance to another position.</returns>
        public static bool Beyond3(this Vector3 self, Vector3 other, float distance) => self.Distance3(other) >= distance;
        
        /// <summary>
        /// If this is beyond a distance to another position.
        /// </summary>
        /// <param name="self">This position.</param>
        /// <param name="other">The other position.</param>
        /// <param name="distance">The distance.</param>
        /// <returns>If this is beyond a distance to another position.</returns>
        public static bool Beyond3(this Vector3 self, [NotNull] Transform other, float distance) => self.Beyond3(other.position, distance);
        
        /// <summary>
        /// If this is beyond a distance to another position.
        /// </summary>
        /// <param name="self">This position.</param>
        /// <param name="other">The other position.</param>
        /// <param name="distance">The distance.</param>
        /// <returns>If this is beyond a distance to another position.</returns>
        public static bool Beyond3(this Vector3 self, [NotNull] Component other, float distance) => self.Beyond3(other.transform.position, distance);
        
        /// <summary>
        /// If this is beyond a distance to another position.
        /// </summary>
        /// <param name="self">This position.</param>
        /// <param name="other">The other position.</param>
        /// <param name="distance">The distance.</param>
        /// <returns>If this is beyond a distance to another position.</returns>
        public static bool Beyond3(this Vector3 self, [NotNull] GameObject other, float distance) => self.Beyond3(other.transform.position, distance);
        
        /// <summary>
        /// If this is beyond a distance to another position.
        /// </summary>
        /// <param name="self">This position.</param>
        /// <param name="other">The other position.</param>
        /// <param name="distance">The distance.</param>
        /// <returns>If this is beyond a distance to another position.</returns>
        public static bool Beyond3(this Vector3 self, [NotNull] KaijuAgent other, float distance) => self.Beyond3(other.transform.position, distance);
        
        /// <summary>
        /// If this is beyond a distance to another position.
        /// </summary>
        /// <param name="self">This position.</param>
        /// <param name="other">The other position.</param>
        /// <param name="distance">The distance.</param>
        /// <returns>If this is beyond a distance to another position.</returns>
        public static bool Beyond3(this Vector3 self, [NotNull] KaijuSensor other, float distance) => self.Beyond3(other.transform.position, distance);
        
        /// <summary>
        /// If this is beyond a distance to another position.
        /// </summary>
        /// <param name="self">This object.</param>
        /// <param name="other">The other position.</param>
        /// <param name="distance">The distance.</param>
        /// <returns>If this is beyond a distance to another position.</returns>
        public static bool Beyond3([NotNull] this Transform self, Vector3 other, float distance) => self.position.Distance3(other) >= distance;
        
        /// <summary>
        /// If this is beyond a distance to another position.
        /// </summary>
        /// <param name="self">This object.</param>
        /// <param name="other">The other position.</param>
        /// <param name="distance">The distance.</param>
        /// <returns>If this is beyond a distance to another position.</returns>
        public static bool Beyond3([NotNull] this Transform self, [NotNull] Transform other, float distance) => self.position.Beyond3(other.position, distance);
        
        /// <summary>
        /// If this is beyond a distance to another position.
        /// </summary>
        /// <param name="self">This object.</param>
        /// <param name="other">The other position.</param>
        /// <param name="distance">The distance.</param>
        /// <returns>If this is beyond a distance to another position.</returns>
        public static bool Beyond3([NotNull] this Transform self, [NotNull] Component other, float distance) => self.position.Beyond3(other.transform.position, distance);
        
        /// <summary>
        /// If this is beyond a distance to another position.
        /// </summary>
        /// <param name="self">This object.</param>
        /// <param name="other">The other position.</param>
        /// <param name="distance">The distance.</param>
        /// <returns>If this is beyond a distance to another position.</returns>
        public static bool Beyond3([NotNull] this Transform self, [NotNull] GameObject other, float distance) => self.position.Beyond3(other.transform.position, distance);
        
        /// <summary>
        /// If this is beyond a distance to another position.
        /// </summary>
        /// <param name="self">This object.</param>
        /// <param name="other">The other position.</param>
        /// <param name="distance">The distance.</param>
        /// <returns>If this is beyond a distance to another position.</returns>
        public static bool Beyond3([NotNull] this Transform self, [NotNull] KaijuAgent other, float distance) => self.position.Beyond3(other.transform.position, distance);
        
        /// <summary>
        /// If this is beyond a distance to another position.
        /// </summary>
        /// <param name="self">This object.</param>
        /// <param name="other">The other position.</param>
        /// <param name="distance">The distance.</param>
        /// <returns>If this is beyond a distance to another position.</returns>
        public static bool Beyond3([NotNull] this Transform self, [NotNull] KaijuSensor other, float distance) => self.position.Beyond3(other.transform.position, distance);
        
        /// <summary>
        /// If this is beyond a distance to another position.
        /// </summary>
        /// <param name="self">This object.</param>
        /// <param name="other">The other position.</param>
        /// <param name="distance">The distance.</param>
        /// <returns>If this is beyond a distance to another position.</returns>
        public static bool Beyond3([NotNull] this Component self, Vector3 other, float distance) => self.transform.position.Distance3(other) >= distance;
        
        /// <summary>
        /// If this is beyond a distance to another position.
        /// </summary>
        /// <param name="self">This object.</param>
        /// <param name="other">The other position.</param>
        /// <param name="distance">The distance.</param>
        /// <returns>If this is beyond a distance to another position.</returns>
        public static bool Beyond3([NotNull] this Component self, [NotNull] Transform other, float distance) => self.transform.position.Beyond3(other.position, distance);
        
        /// <summary>
        /// If this is beyond a distance to another position.
        /// </summary>
        /// <param name="self">This object.</param>
        /// <param name="other">The other position.</param>
        /// <param name="distance">The distance.</param>
        /// <returns>If this is beyond a distance to another position.</returns>
        public static bool Beyond3([NotNull] this Component self, [NotNull] Component other, float distance) => self.transform.position.Beyond3(other.transform.position, distance);
        
        /// <summary>
        /// If this is beyond a distance to another position.
        /// </summary>
        /// <param name="self">This object.</param>
        /// <param name="other">The other position.</param>
        /// <param name="distance">The distance.</param>
        /// <returns>If this is beyond a distance to another position.</returns>
        public static bool Beyond3([NotNull] this Component self, [NotNull] GameObject other, float distance) => self.transform.position.Beyond3(other.transform.position, distance);
        
        /// <summary>
        /// If this is beyond a distance to another position.
        /// </summary>
        /// <param name="self">This object.</param>
        /// <param name="other">The other position.</param>
        /// <param name="distance">The distance.</param>
        /// <returns>If this is beyond a distance to another position.</returns>
        public static bool Beyond3([NotNull] this Component self, [NotNull] KaijuAgent other, float distance) => self.transform.position.Beyond3(other.transform.position, distance);
        
        /// <summary>
        /// If this is beyond a distance to another position.
        /// </summary>
        /// <param name="self">This object.</param>
        /// <param name="other">The other position.</param>
        /// <param name="distance">The distance.</param>
        /// <returns>If this is beyond a distance to another position.</returns>
        public static bool Beyond3([NotNull] this Component self, [NotNull] KaijuSensor other, float distance) => self.transform.position.Beyond3(other.transform.position, distance);
        
        /// <summary>
        /// If this is beyond a distance to another position.
        /// </summary>
        /// <param name="self">This object.</param>
        /// <param name="other">The other position.</param>
        /// <param name="distance">The distance.</param>
        /// <returns>If this is beyond a distance to another position.</returns>
        public static bool Beyond3([NotNull] this GameObject self, Vector3 other, float distance) => self.transform.position.Distance3(other) >= distance;
        
        /// <summary>
        /// If this is beyond a distance to another position.
        /// </summary>
        /// <param name="self">This object.</param>
        /// <param name="other">The other position.</param>
        /// <param name="distance">The distance.</param>
        /// <returns>If this is beyond a distance to another position.</returns>
        public static bool Beyond3([NotNull] this GameObject self, [NotNull] Transform other, float distance) => self.transform.position.Beyond3(other.position, distance);
        
        /// <summary>
        /// If this is beyond a distance to another position.
        /// </summary>
        /// <param name="self">This object.</param>
        /// <param name="other">The other position.</param>
        /// <param name="distance">The distance.</param>
        /// <returns>If this is beyond a distance to another position.</returns>
        public static bool Beyond3([NotNull] this GameObject self, [NotNull] Component other, float distance) => self.transform.position.Beyond3(other.transform.position, distance);
        
        /// <summary>
        /// If this is beyond a distance to another position.
        /// </summary>
        /// <param name="self">This object.</param>
        /// <param name="other">The other position.</param>
        /// <param name="distance">The distance.</param>
        /// <returns>If this is beyond a distance to another position.</returns>
        public static bool Beyond3([NotNull] this GameObject self, [NotNull] GameObject other, float distance) => self.transform.position.Beyond3(other.transform.position, distance);
        
        /// <summary>
        /// If this is beyond a distance to another position.
        /// </summary>
        /// <param name="self">This object.</param>
        /// <param name="other">The other position.</param>
        /// <param name="distance">The distance.</param>
        /// <returns>If this is beyond a distance to another position.</returns>
        public static bool Beyond3([NotNull] this GameObject self, [NotNull] KaijuAgent other, float distance) => self.transform.position.Beyond3(other.transform.position, distance);
        
        /// <summary>
        /// If this is beyond a distance to another position.
        /// </summary>
        /// <param name="self">This object.</param>
        /// <param name="other">The other position.</param>
        /// <param name="distance">The distance.</param>
        /// <returns>If this is beyond a distance to another position.</returns>
        public static bool Beyond3([NotNull] this GameObject self, [NotNull] KaijuSensor other, float distance) => self.transform.position.Beyond3(other.transform.position, distance);
        
        /// <summary>
        /// If this is between two distances to another position.
        /// </summary>
        /// <param name="self">This position.</param>
        /// <param name="other">The other position.</param>
        /// <param name="minimum">The minimum distance.</param>
        /// <param name="maximum">The maximum distance.</param>
        /// <returns>If this is between two distances to another position.</returns>
        public static bool Between3(this Vector3 self, Vector3 other, float minimum, float maximum)
        {
            float distance = self.Distance3(other);
            return distance >= minimum && distance <= maximum;
        }
        
        /// <summary>
        /// If this is between two distances to another position.
        /// </summary>
        /// <param name="self">This position.</param>
        /// <param name="other">The other position.</param>
        /// <param name="minimum">The minimum distance.</param>
        /// <param name="maximum">The maximum distance.</param>
        /// <returns>If this is between two distances to another position.</returns>
        public static bool Between3(this Vector3 self, [NotNull] Transform other, float minimum, float maximum) => self.Between3(other.position, minimum, maximum);
        
        /// <summary>
        /// If this is between two distances to another position.
        /// </summary>
        /// <param name="self">This position.</param>
        /// <param name="other">The other position.</param>
        /// <param name="minimum">The minimum distance.</param>
        /// <param name="maximum">The maximum distance.</param>
        /// <returns>If this is between two distances to another position.</returns>
        public static bool Between3(this Vector3 self, [NotNull] Component other, float minimum, float maximum) => self.Between3(other.transform.position, minimum, maximum);
        
        /// <summary>
        /// If this is between two distances to another position.
        /// </summary>
        /// <param name="self">This position.</param>
        /// <param name="other">The other position.</param>
        /// <param name="minimum">The minimum distance.</param>
        /// <param name="maximum">The maximum distance.</param>
        /// <returns>If this is between two distances to another position.</returns>
        public static bool Between3(this Vector3 self, [NotNull] GameObject other, float minimum, float maximum) => self.Between3(other.transform.position, minimum, maximum);
        
        /// <summary>
        /// If this is between two distances to another position.
        /// </summary>
        /// <param name="self">This position.</param>
        /// <param name="other">The other position.</param>
        /// <param name="minimum">The minimum distance.</param>
        /// <param name="maximum">The maximum distance.</param>
        /// <returns>If this is between two distances to another position.</returns>
        public static bool Between3(this Vector3 self, [NotNull] KaijuAgent other, float minimum, float maximum) => self.Between3(other.transform.position, minimum, maximum);
        
        /// <summary>
        /// If this is between two distances to another position.
        /// </summary>
        /// <param name="self">This position.</param>
        /// <param name="other">The other position.</param>
        /// <param name="minimum">The minimum distance.</param>
        /// <param name="maximum">The maximum distance.</param>
        /// <returns>If this is between two distances to another position.</returns>
        public static bool Between3(this Vector3 self, [NotNull] KaijuSensor other, float minimum, float maximum) => self.Between3(other.transform.position, minimum, maximum);
        
        /// <summary>
        /// If this is between two distances to another position.
        /// </summary>
        /// <param name="self">This position.</param>
        /// <param name="other">The other position.</param>
        /// <param name="minimum">The minimum distance.</param>
        /// <param name="maximum">The maximum distance.</param>
        /// <returns>If this is between two distances to another position.</returns>
        public static bool Between3([NotNull] this Transform self, Vector3 other, float minimum, float maximum) => self.position.Between3(other, minimum, maximum);
        
        /// <summary>
        /// If this is between two distances to another position.
        /// </summary>
        /// <param name="self">This position.</param>
        /// <param name="other">The other position.</param>
        /// <param name="minimum">The minimum distance.</param>
        /// <param name="maximum">The maximum distance.</param>
        /// <returns>If this is between two distances to another position.</returns>
        public static bool Between3([NotNull] this Transform self, [NotNull] Transform other, float minimum, float maximum) => self.position.Between3(other.position, minimum, maximum);
        
        /// <summary>
        /// If this is between two distances to another position.
        /// </summary>
        /// <param name="self">This position.</param>
        /// <param name="other">The other position.</param>
        /// <param name="minimum">The minimum distance.</param>
        /// <param name="maximum">The maximum distance.</param>
        /// <returns>If this is between two distances to another position.</returns>
        public static bool Between3([NotNull] this Transform self, [NotNull] Component other, float minimum, float maximum) => self.position.Between3(other.transform.position, minimum, maximum);
        
        /// <summary>
        /// If this is between two distances to another position.
        /// </summary>
        /// <param name="self">This position.</param>
        /// <param name="other">The other position.</param>
        /// <param name="minimum">The minimum distance.</param>
        /// <param name="maximum">The maximum distance.</param>
        /// <returns>If this is between two distances to another position.</returns>
        public static bool Between3([NotNull] this Transform self, [NotNull] GameObject other, float minimum, float maximum) => self.position.Between3(other.transform.position, minimum, maximum);
        
        /// <summary>
        /// If this is between two distances to another position.
        /// </summary>
        /// <param name="self">This position.</param>
        /// <param name="other">The other position.</param>
        /// <param name="minimum">The minimum distance.</param>
        /// <param name="maximum">The maximum distance.</param>
        /// <returns>If this is between two distances to another position.</returns>
        public static bool Between3([NotNull] this Transform self, [NotNull] KaijuAgent other, float minimum, float maximum) => self.position.Between3(other.transform.position, minimum, maximum);
        
        /// <summary>
        /// If this is between two distances to another position.
        /// </summary>
        /// <param name="self">This position.</param>
        /// <param name="other">The other position.</param>
        /// <param name="minimum">The minimum distance.</param>
        /// <param name="maximum">The maximum distance.</param>
        /// <returns>If this is between two distances to another position.</returns>
        public static bool Between3([NotNull] this Transform self, [NotNull] KaijuSensor other, float minimum, float maximum) => self.position.Between3(other.transform.position, minimum, maximum);
        
        /// <summary>
        /// If this is between two distances to another position.
        /// </summary>
        /// <param name="self">This position.</param>
        /// <param name="other">The other position.</param>
        /// <param name="minimum">The minimum distance.</param>
        /// <param name="maximum">The maximum distance.</param>
        /// <returns>If this is between two distances to another position.</returns>
        public static bool Between3([NotNull] this Component self, Vector3 other, float minimum, float maximum) => self.transform.position.Between3(other, minimum, maximum);
        
        /// <summary>
        /// If this is between two distances to another position.
        /// </summary>
        /// <param name="self">This position.</param>
        /// <param name="other">The other position.</param>
        /// <param name="minimum">The minimum distance.</param>
        /// <param name="maximum">The maximum distance.</param>
        /// <returns>If this is between two distances to another position.</returns>
        public static bool Between3([NotNull] this Component self, [NotNull] Transform other, float minimum, float maximum) => self.transform.position.Between3(other.position, minimum, maximum);
        
        /// <summary>
        /// If this is between two distances to another position.
        /// </summary>
        /// <param name="self">This position.</param>
        /// <param name="other">The other position.</param>
        /// <param name="minimum">The minimum distance.</param>
        /// <param name="maximum">The maximum distance.</param>
        /// <returns>If this is between two distances to another position.</returns>
        public static bool Between3([NotNull] this Component self, [NotNull] Component other, float minimum, float maximum) => self.transform.position.Between3(other.transform.position, minimum, maximum);
        
        /// <summary>
        /// If this is between two distances to another position.
        /// </summary>
        /// <param name="self">This position.</param>
        /// <param name="other">The other position.</param>
        /// <param name="minimum">The minimum distance.</param>
        /// <param name="maximum">The maximum distance.</param>
        /// <returns>If this is between two distances to another position.</returns>
        public static bool Between3([NotNull] this Component self, [NotNull] GameObject other, float minimum, float maximum) => self.transform.position.Between3(other.transform.position, minimum, maximum);
        
        /// <summary>
        /// If this is between two distances to another position.
        /// </summary>
        /// <param name="self">This position.</param>
        /// <param name="other">The other position.</param>
        /// <param name="minimum">The minimum distance.</param>
        /// <param name="maximum">The maximum distance.</param>
        /// <returns>If this is between two distances to another position.</returns>
        public static bool Between3([NotNull] this Component self, [NotNull] KaijuAgent other, float minimum, float maximum) => self.transform.position.Between3(other.transform.position, minimum, maximum);
        
        /// <summary>
        /// If this is between two distances to another position.
        /// </summary>
        /// <param name="self">This position.</param>
        /// <param name="other">The other position.</param>
        /// <param name="minimum">The minimum distance.</param>
        /// <param name="maximum">The maximum distance.</param>
        /// <returns>If this is between two distances to another position.</returns>
        public static bool Between3([NotNull] this Component self, [NotNull] KaijuSensor other, float minimum, float maximum) => self.transform.position.Between3(other.transform.position, minimum, maximum);
        
        /// <summary>
        /// If this is between two distances to another position.
        /// </summary>
        /// <param name="self">This position.</param>
        /// <param name="other">The other position.</param>
        /// <param name="minimum">The minimum distance.</param>
        /// <param name="maximum">The maximum distance.</param>
        /// <returns>If this is between two distances to another position.</returns>
        public static bool Between3([NotNull] this GameObject self, Vector3 other, float minimum, float maximum) => self.transform.position.Between3(other, minimum, maximum);
        
        /// <summary>
        /// If this is between two distances to another position.
        /// </summary>
        /// <param name="self">This position.</param>
        /// <param name="other">The other position.</param>
        /// <param name="minimum">The minimum distance.</param>
        /// <param name="maximum">The maximum distance.</param>
        /// <returns>If this is between two distances to another position.</returns>
        public static bool Between3([NotNull] this GameObject self, [NotNull] Transform other, float minimum, float maximum) => self.transform.position.Between3(other.position, minimum, maximum);
        
        /// <summary>
        /// If this is between two distances to another position.
        /// </summary>
        /// <param name="self">This position.</param>
        /// <param name="other">The other position.</param>
        /// <param name="minimum">The minimum distance.</param>
        /// <param name="maximum">The maximum distance.</param>
        /// <returns>If this is between two distances to another position.</returns>
        public static bool Between3([NotNull] this GameObject self, [NotNull] Component other, float minimum, float maximum) => self.transform.position.Between3(other.transform.position, minimum, maximum);
        
        /// <summary>
        /// If this is between two distances to another position.
        /// </summary>
        /// <param name="self">This position.</param>
        /// <param name="other">The other position.</param>
        /// <param name="minimum">The minimum distance.</param>
        /// <param name="maximum">The maximum distance.</param>
        /// <returns>If this is between two distances to another position.</returns>
        public static bool Between3([NotNull] this GameObject self, [NotNull] GameObject other, float minimum, float maximum) => self.transform.position.Between3(other.transform.position, minimum, maximum);
        
        /// <summary>
        /// If this is between two distances to another position.
        /// </summary>
        /// <param name="self">This position.</param>
        /// <param name="other">The other position.</param>
        /// <param name="minimum">The minimum distance.</param>
        /// <param name="maximum">The maximum distance.</param>
        /// <returns>If this is between two distances to another position.</returns>
        public static bool Between3([NotNull] this GameObject self, [NotNull] KaijuAgent other, float minimum, float maximum) => self.transform.position.Between3(other.transform.position, minimum, maximum);
        
        /// <summary>
        /// If this is between two distances to another position.
        /// </summary>
        /// <param name="self">This position.</param>
        /// <param name="other">The other position.</param>
        /// <param name="minimum">The minimum distance.</param>
        /// <param name="maximum">The maximum distance.</param>
        /// <returns>If this is between two distances to another position.</returns>
        public static bool Between3([NotNull] this GameObject self, [NotNull] KaijuSensor other, float minimum, float maximum) => self.transform.position.Between3(other.transform.position, minimum, maximum);
        
        /// <summary>
        /// The direction from this position to another position.
        /// </summary>
        /// <param name="self">This position.</param>
        /// <param name="other">The other position.</param>
        /// <returns>The direction from this position to another position.</returns>
        public static Vector2 Direction(this Vector2 self, Vector2 other) => self - other;
        
        /// <summary>
        /// The direction from this position to another position.
        /// </summary>
        /// <param name="self">This position.</param>
        /// <param name="other">The other position.</param>
        /// <returns>The direction from this position to another position.</returns>
        public static Vector2 Direction(this Vector2 self, Vector3 other) => self.Direction(new Vector2(other.x, other.z));
        
        /// <summary>
        /// The direction from this position to another position.
        /// </summary>
        /// <param name="self">This position.</param>
        /// <param name="other">The other position.</param>
        /// <returns>The direction from this position to another position.</returns>
        public static Vector2 Direction(this Vector2 self, [NotNull] Transform other) => self.Direction(other.position);
        
        /// <summary>
        /// The direction from this position to another position.
        /// </summary>
        /// <param name="self">This position.</param>
        /// <param name="other">The other position.</param>
        /// <returns>The direction from this position to another position.</returns>
        public static Vector2 Direction(this Vector2 self, [NotNull] Component other) => self.Direction(other.transform.position);
        
        /// <summary>
        /// The direction from this position to another position.
        /// </summary>
        /// <param name="self">This position.</param>
        /// <param name="other">The other position.</param>
        /// <returns>The direction from this position to another position.</returns>
        public static Vector2 Direction(this Vector2 self, [NotNull] GameObject other) => self.Direction(other.transform.position);
        
        /// <summary>
        /// The direction from this position to another position.
        /// </summary>
        /// <param name="self">This position.</param>
        /// <param name="other">The other position.</param>
        /// <returns>The direction from this position to another position.</returns>
        public static Vector2 Direction(this Vector2 self, [NotNull] KaijuAgent other) => self.Direction(other.transform.position);
        
        /// <summary>
        /// The direction from this position to another position.
        /// </summary>
        /// <param name="self">This position.</param>
        /// <param name="other">The other position.</param>
        /// <returns>The direction from this position to another position.</returns>
        public static Vector2 Direction(this Vector2 self, [NotNull] KaijuSensor other) => self.Direction(other.transform.position);
        
        /// <summary>
        /// The direction from this position to another position.
        /// </summary>
        /// <param name="self">This position.</param>
        /// <param name="other">The other position.</param>
        /// <returns>The direction from this position to another position.</returns>
        public static Vector2 Direction(this Vector3 self, Vector2 other) => new Vector2(self.x, self.z).Direction(other);
        
        /// <summary>
        /// The direction from this position to another position.
        /// </summary>
        /// <param name="self">This position.</param>
        /// <param name="other">The other position.</param>
        /// <returns>The direction from this position to another position.</returns>
        public static Vector2 Direction(this Vector3 self, Vector3 other) => new Vector2(self.x, self.z).Direction(new Vector2(other.x, other.z));
        
        /// <summary>
        /// The direction from this position to another position.
        /// </summary>
        /// <param name="self">This position.</param>
        /// <param name="other">The other position.</param>
        /// <returns>The direction from this position to another position.</returns>
        public static Vector2 Direction(this Vector3 self, [NotNull] Transform other) => self.Direction(other.position);
        
        /// <summary>
        /// The direction from this position to another position.
        /// </summary>
        /// <param name="self">This position.</param>
        /// <param name="other">The other position.</param>
        /// <returns>The direction from this position to another position.</returns>
        public static Vector2 Direction(this Vector3 self, [NotNull] Component other) => self.Direction(other.transform.position);
        
        /// <summary>
        /// The direction from this position to another position.
        /// </summary>
        /// <param name="self">This position.</param>
        /// <param name="other">The other position.</param>
        /// <returns>The direction from this position to another position.</returns>
        public static Vector2 Direction(this Vector3 self, [NotNull] GameObject other) => self.Direction(other.transform.position);
        
        /// <summary>
        /// The direction from this position to another position.
        /// </summary>
        /// <param name="self">This position.</param>
        /// <param name="other">The other position.</param>
        /// <returns>The direction from this position to another position.</returns>
        public static Vector2 Direction(this Vector3 self, [NotNull] KaijuAgent other) => self.Direction(other.transform.position);
        
        /// <summary>
        /// The direction from this position to another position.
        /// </summary>
        /// <param name="self">This position.</param>
        /// <param name="other">The other position.</param>
        /// <returns>The direction from this position to another position.</returns>
        public static Vector2 Direction(this Vector3 self, [NotNull] KaijuSensor other) => self.Direction(other.transform.position);
        
        /// <summary>
        /// The direction from this position to another position.
        /// </summary>
        /// <param name="self">This position.</param>
        /// <param name="other">The other position.</param>
        /// <returns>The direction from this position to another position.</returns>
        public static Vector2 Direction([NotNull] this Transform self, Vector2 other) => self.position.Direction(other);
        
        /// <summary>
        /// The direction from this position to another position.
        /// </summary>
        /// <param name="self">This position.</param>
        /// <param name="other">The other position.</param>
        /// <returns>The direction from this position to another position.</returns>
        public static Vector2 Direction([NotNull] this Transform self, Vector3 other) => self.position.Direction(other);
        
        /// <summary>
        /// The direction from this position to another position.
        /// </summary>
        /// <param name="self">This position.</param>
        /// <param name="other">The other position.</param>
        /// <returns>The direction from this position to another position.</returns>
        public static Vector2 Direction([NotNull] this Transform self, [NotNull] Transform other) => self.position.Direction(other.position);
        
        /// <summary>
        /// The direction from this position to another position.
        /// </summary>
        /// <param name="self">This position.</param>
        /// <param name="other">The other position.</param>
        /// <returns>The direction from this position to another position.</returns>
        public static Vector2 Direction([NotNull] this Transform self, [NotNull] Component other) => self.position.Direction(other.transform.position);
        
        /// <summary>
        /// The direction from this position to another position.
        /// </summary>
        /// <param name="self">This position.</param>
        /// <param name="other">The other position.</param>
        /// <returns>The direction from this position to another position.</returns>
        public static Vector2 Direction([NotNull] this Transform self, [NotNull] GameObject other) => self.position.Direction(other.transform.position);
        
        /// <summary>
        /// The direction from this position to another position.
        /// </summary>
        /// <param name="self">This position.</param>
        /// <param name="other">The other position.</param>
        /// <returns>The direction from this position to another position.</returns>
        public static Vector2 Direction([NotNull] this Transform self, [NotNull] KaijuAgent other) => self.position.Direction(other.transform.position);
        
        /// <summary>
        /// The direction from this position to another position.
        /// </summary>
        /// <param name="self">This position.</param>
        /// <param name="other">The other position.</param>
        /// <returns>The direction from this position to another position.</returns>
        public static Vector2 Direction([NotNull] this Transform self, [NotNull] KaijuSensor other) => self.position.Direction(other.transform.position);
        
        /// <summary>
        /// The direction from this position to another position.
        /// </summary>
        /// <param name="self">This position.</param>
        /// <param name="other">The other position.</param>
        /// <returns>The direction from this position to another position.</returns>
        public static Vector2 Direction([NotNull] this Component self, Vector2 other) => self.transform.position.Direction(other);
        
        /// <summary>
        /// The direction from this position to another position.
        /// </summary>
        /// <param name="self">This position.</param>
        /// <param name="other">The other position.</param>
        /// <returns>The direction from this position to another position.</returns>
        public static Vector2 Direction([NotNull] this Component self, Vector3 other) => self.transform.position.Direction(other);
        
        /// <summary>
        /// The direction from this position to another position.
        /// </summary>
        /// <param name="self">This position.</param>
        /// <param name="other">The other position.</param>
        /// <returns>The direction from this position to another position.</returns>
        public static Vector2 Direction([NotNull] this Component self, [NotNull] Transform other) => self.transform.position.Direction(other.position);
        
        /// <summary>
        /// The direction from this position to another position.
        /// </summary>
        /// <param name="self">This position.</param>
        /// <param name="other">The other position.</param>
        /// <returns>The direction from this position to another position.</returns>
        public static Vector2 Direction([NotNull] this Component self, [NotNull] Component other) => self.transform.position.Direction(other.transform.position);
        
        /// <summary>
        /// The direction from this position to another position.
        /// </summary>
        /// <param name="self">This position.</param>
        /// <param name="other">The other position.</param>
        /// <returns>The direction from this position to another position.</returns>
        public static Vector2 Direction([NotNull] this Component self, [NotNull] GameObject other) => self.transform.position.Direction(other.transform.position);
        
        /// <summary>
        /// The direction from this position to another position.
        /// </summary>
        /// <param name="self">This position.</param>
        /// <param name="other">The other position.</param>
        /// <returns>The direction from this position to another position.</returns>
        public static Vector2 Direction([NotNull] this Component self, [NotNull] KaijuAgent other) => self.transform.position.Direction(other.transform.position);
        
        /// <summary>
        /// The direction from this position to another position.
        /// </summary>
        /// <param name="self">This position.</param>
        /// <param name="other">The other position.</param>
        /// <returns>The direction from this position to another position.</returns>
        public static Vector2 Direction([NotNull] this Component self, [NotNull] KaijuSensor other) => self.transform.position.Direction(other.transform.position);
        
        /// <summary>
        /// The direction from this position to another position.
        /// </summary>
        /// <param name="self">This position.</param>
        /// <param name="other">The other position.</param>
        /// <returns>The direction from this position to another position.</returns>
        public static Vector2 Direction([NotNull] this GameObject self, Vector2 other) => self.transform.position.Direction(other);
        
        /// <summary>
        /// The direction from this position to another position.
        /// </summary>
        /// <param name="self">This position.</param>
        /// <param name="other">The other position.</param>
        /// <returns>The direction from this position to another position.</returns>
        public static Vector2 Direction([NotNull] this GameObject self, Vector3 other) => self.transform.position.Direction(other);
        
        /// <summary>
        /// The direction from this position to another position.
        /// </summary>
        /// <param name="self">This position.</param>
        /// <param name="other">The other position.</param>
        /// <returns>The direction from this position to another position.</returns>
        public static Vector2 Direction([NotNull] this GameObject self, [NotNull] Transform other) => self.transform.position.Direction(other.position);
        
        /// <summary>
        /// The direction from this position to another position.
        /// </summary>
        /// <param name="self">This position.</param>
        /// <param name="other">The other position.</param>
        /// <returns>The direction from this position to another position.</returns>
        public static Vector2 Direction([NotNull] this GameObject self, [NotNull] Component other) => self.transform.position.Direction(other.transform.position);
        
        /// <summary>
        /// The direction from this position to another position.
        /// </summary>
        /// <param name="self">This position.</param>
        /// <param name="other">The other position.</param>
        /// <returns>The direction from this position to another position.</returns>
        public static Vector2 Direction([NotNull] this GameObject self, [NotNull] GameObject other) => self.transform.position.Direction(other.transform.position);
        
        /// <summary>
        /// The direction from this position to another position.
        /// </summary>
        /// <param name="self">This position.</param>
        /// <param name="other">The other position.</param>
        /// <returns>The direction from this position to another position.</returns>
        public static Vector2 Direction([NotNull] this GameObject self, [NotNull] KaijuAgent other) => self.transform.position.Direction(other.transform.position);
        
        /// <summary>
        /// The direction from this position to another position.
        /// </summary>
        /// <param name="self">This position.</param>
        /// <param name="other">The other position.</param>
        /// <returns>The direction from this position to another position.</returns>
        public static Vector2 Direction([NotNull] this GameObject self, [NotNull] KaijuSensor other) => self.transform.position.Direction(other.transform.position);
        
        /// <summary>
        /// The direction from this position to another position.
        /// </summary>
        /// <param name="self">This position.</param>
        /// <param name="other">The other position.</param>
        /// <returns>The direction from this position to another position.</returns>
        public static Vector3 Direction3(this Vector3 self, Vector3 other) => self - other;
        
        /// <summary>
        /// The direction from this position to another position.
        /// </summary>
        /// <param name="self">This position.</param>
        /// <param name="other">The other position.</param>
        /// <returns>The direction from this position to another position.</returns>
        public static Vector3 Direction3(this Vector3 self, [NotNull] Transform other) => self.Direction3(other.position);
        
        /// <summary>
        /// The direction from this position to another position.
        /// </summary>
        /// <param name="self">This position.</param>
        /// <param name="other">The other position.</param>
        /// <returns>The direction from this position to another position.</returns>
        public static Vector3 Direction3(this Vector3 self, [NotNull] Component other) => self.Direction3(other.transform.position);
        
        /// <summary>
        /// The direction from this position to another position.
        /// </summary>
        /// <param name="self">This position.</param>
        /// <param name="other">The other position.</param>
        /// <returns>The direction from this position to another position.</returns>
        public static Vector3 Direction3(this Vector3 self, [NotNull] GameObject other) => self.Direction3(other.transform.position);
        
        /// <summary>
        /// The direction from this position to another position.
        /// </summary>
        /// <param name="self">This position.</param>
        /// <param name="other">The other position.</param>
        /// <returns>The direction from this position to another position.</returns>
        public static Vector3 Direction3(this Vector3 self, [NotNull] KaijuAgent other) => self.Direction3(other.transform.position);
        
        /// <summary>
        /// The direction from this position to another position.
        /// </summary>
        /// <param name="self">This position.</param>
        /// <param name="other">The other position.</param>
        /// <returns>The direction from this position to another position.</returns>
        public static Vector3 Direction3(this Vector3 self, [NotNull] KaijuSensor other) => self.Direction3(other.transform.position);
        
        /// <summary>
        /// The direction from this position to another position.
        /// </summary>
        /// <param name="self">This position.</param>
        /// <param name="other">The other position.</param>
        /// <returns>The direction from this position to another position.</returns>
        public static Vector3 Direction3([NotNull] this Transform self, Vector3 other) => self.position.Direction3(other);
        
        /// <summary>
        /// The direction from this position to another position.
        /// </summary>
        /// <param name="self">This position.</param>
        /// <param name="other">The other position.</param>
        /// <returns>The direction from this position to another position.</returns>
        public static Vector3 Direction3([NotNull] this Transform self, [NotNull] Transform other) => self.position.Direction3(other.position);
        
        /// <summary>
        /// The direction from this position to another position.
        /// </summary>
        /// <param name="self">This position.</param>
        /// <param name="other">The other position.</param>
        /// <returns>The direction from this position to another position.</returns>
        public static Vector3 Direction3([NotNull] this Transform self, [NotNull] Component other) => self.position.Direction3(other.transform.position);
        
        /// <summary>
        /// The direction from this position to another position.
        /// </summary>
        /// <param name="self">This position.</param>
        /// <param name="other">The other position.</param>
        /// <returns>The direction from this position to another position.</returns>
        public static Vector3 Direction3([NotNull] this Transform self, [NotNull] GameObject other) => self.position.Direction3(other.transform.position);
        
        /// <summary>
        /// The direction from this position to another position.
        /// </summary>
        /// <param name="self">This position.</param>
        /// <param name="other">The other position.</param>
        /// <returns>The direction from this position to another position.</returns>
        public static Vector3 Direction3([NotNull] this Transform self, [NotNull] KaijuAgent other) => self.position.Direction3(other.transform.position);
        
        /// <summary>
        /// The direction from this position to another position.
        /// </summary>
        /// <param name="self">This position.</param>
        /// <param name="other">The other position.</param>
        /// <returns>The direction from this position to another position.</returns>
        public static Vector3 Direction3([NotNull] this Transform self, [NotNull] KaijuSensor other) => self.position.Direction3(other.transform.position);
        
        /// <summary>
        /// The direction from this position to another position.
        /// </summary>
        /// <param name="self">This position.</param>
        /// <param name="other">The other position.</param>
        /// <returns>The direction from this position to another position.</returns>
        public static Vector3 Direction3([NotNull] this Component self, Vector3 other) => self.transform.position.Direction3(other);
        
        /// <summary>
        /// The direction from this position to another position.
        /// </summary>
        /// <param name="self">This position.</param>
        /// <param name="other">The other position.</param>
        /// <returns>The direction from this position to another position.</returns>
        public static Vector3 Direction3([NotNull] this Component self, [NotNull] Transform other) => self.transform.position.Direction3(other.position);
        
        /// <summary>
        /// The direction from this position to another position.
        /// </summary>
        /// <param name="self">This position.</param>
        /// <param name="other">The other position.</param>
        /// <returns>The direction from this position to another position.</returns>
        public static Vector3 Direction3([NotNull] this Component self, [NotNull] Component other) => self.transform.position.Direction3(other.transform.position);
        
        /// <summary>
        /// The direction from this position to another position.
        /// </summary>
        /// <param name="self">This position.</param>
        /// <param name="other">The other position.</param>
        /// <returns>The direction from this position to another position.</returns>
        public static Vector3 Direction3([NotNull] this Component self, [NotNull] GameObject other) => self.transform.position.Direction3(other.transform.position);
        
        /// <summary>
        /// The direction from this position to another position.
        /// </summary>
        /// <param name="self">This position.</param>
        /// <param name="other">The other position.</param>
        /// <returns>The direction from this position to another position.</returns>
        public static Vector3 Direction3([NotNull] this Component self, [NotNull] KaijuAgent other) => self.transform.position.Direction3(other.transform.position);
        
        /// <summary>
        /// The direction from this position to another position.
        /// </summary>
        /// <param name="self">This position.</param>
        /// <param name="other">The other position.</param>
        /// <returns>The direction from this position to another position.</returns>
        public static Vector3 Direction3([NotNull] this Component self, [NotNull] KaijuSensor other) => self.transform.position.Direction3(other.transform.position);
        
        /// <summary>
        /// The direction from this position to another position.
        /// </summary>
        /// <param name="self">This position.</param>
        /// <param name="other">The other position.</param>
        /// <returns>The direction from this position to another position.</returns>
        public static Vector3 Direction3([NotNull] this GameObject self, Vector3 other) => self.transform.position.Direction3(other);
        
        /// <summary>
        /// The direction from this position to another position.
        /// </summary>
        /// <param name="self">This position.</param>
        /// <param name="other">The other position.</param>
        /// <returns>The direction from this position to another position.</returns>
        public static Vector3 Direction3([NotNull] this GameObject self, [NotNull] Transform other) => self.transform.position.Direction3(other.position);
        
        /// <summary>
        /// The direction from this position to another position.
        /// </summary>
        /// <param name="self">This position.</param>
        /// <param name="other">The other position.</param>
        /// <returns>The direction from this position to another position.</returns>
        public static Vector3 Direction3([NotNull] this GameObject self, [NotNull] Component other) => self.transform.position.Direction3(other.transform.position);
        
        /// <summary>
        /// The direction from this position to another position.
        /// </summary>
        /// <param name="self">This position.</param>
        /// <param name="other">The other position.</param>
        /// <returns>The direction from this position to another position.</returns>
        public static Vector3 Direction3([NotNull] this GameObject self, [NotNull] GameObject other) => self.transform.position.Direction3(other.transform.position);
        
        /// <summary>
        /// The direction from this position to another position.
        /// </summary>
        /// <param name="self">This position.</param>
        /// <param name="other">The other position.</param>
        /// <returns>The direction from this position to another position.</returns>
        public static Vector3 Direction3([NotNull] this GameObject self, [NotNull] KaijuAgent other) => self.transform.position.Direction3(other.transform.position);
        
        /// <summary>
        /// The direction from this position to another position.
        /// </summary>
        /// <param name="self">This position.</param>
        /// <param name="other">The other position.</param>
        /// <returns>The direction from this position to another position.</returns>
        public static Vector3 Direction3([NotNull] this GameObject self, [NotNull] KaijuSensor other) => self.transform.position.Direction3(other.transform.position);
        
        /// <summary>
        /// The current movement speed based on the time it took to move from a previous position.
        /// </summary>
        /// <param name="current">The current position.</param>
        /// <param name="previous">The previous position.</param>
        /// <param name="delta">The time since the last position.</param>
        /// <returns>The current movement speed based on the time it took to move from a previous position.</returns>
        public static float Speed(this Vector2 current, Vector2 previous, float delta) => current.Distance(previous) / delta;
        
        /// <summary>
        /// The current movement speed based on the time it took to move from a previous position.
        /// </summary>
        /// <param name="current">The current position.</param>
        /// <param name="previous">The previous position.</param>
        /// <returns>The current movement speed based on the time it took to move from a previous position.</returns>
        public static float Speed(this Vector2 current, Vector2 previous) => current.Speed(previous, Time.deltaTime);
        
        /// <summary>
        /// The current movement speed based on the time it took to move from a previous position.
        /// </summary>
        /// <param name="current">The current position.</param>
        /// <param name="previous">The previous position.</param>
        /// <param name="delta">The time since the last position.</param>
        /// <returns>The current movement speed based on the time it took to move from a previous position.</returns>
        public static float Speed(this Vector2 current, Vector3 previous, float delta) => current.Speed(new Vector2(previous.x, previous.z), delta);
        
        /// <summary>
        /// The current movement speed based on the time it took to move from a previous position.
        /// </summary>
        /// <param name="current">The current position.</param>
        /// <param name="previous">The previous position.</param>
        /// <returns>The current movement speed based on the time it took to move from a previous position.</returns>
        public static float Speed(this Vector2 current, Vector3 previous) => current.Speed(previous, Time.deltaTime);
        
        /// <summary>
        /// The current movement speed based on the time it took to move from a previous position.
        /// </summary>
        /// <param name="current">The current position.</param>
        /// <param name="previous">The previous position.</param>
        /// <param name="delta">The time since the last position.</param>
        /// <returns>The current movement speed based on the time it took to move from a previous position.</returns>
        public static float Speed(this Vector2 current, [NotNull] Transform previous, float delta) => current.Speed(previous.position, delta);
        
        /// <summary>
        /// The current movement speed based on the time it took to move from a previous position.
        /// </summary>
        /// <param name="current">The current position.</param>
        /// <param name="previous">The previous position.</param>
        /// <returns>The current movement speed based on the time it took to move from a previous position.</returns>
        public static float Speed(this Vector2 current, [NotNull] Transform previous) => current.Speed(previous, Time.deltaTime);
        
        /// <summary>
        /// The current movement speed based on the time it took to move from a previous position.
        /// </summary>
        /// <param name="current">The current position.</param>
        /// <param name="previous">The previous position.</param>
        /// <param name="delta">The time since the last position.</param>
        /// <returns>The current movement speed based on the time it took to move from a previous position.</returns>
        public static float Speed(this Vector2 current, [NotNull] Component previous, float delta) => current.Speed(previous.transform.position, delta);
        
        /// <summary>
        /// The current movement speed based on the time it took to move from a previous position.
        /// </summary>
        /// <param name="current">The current position.</param>
        /// <param name="previous">The previous position.</param>
        /// <returns>The current movement speed based on the time it took to move from a previous position.</returns>
        public static float Speed(this Vector2 current, [NotNull] Component previous) => current.Speed(previous, Time.deltaTime);
        
        /// <summary>
        /// The current movement speed based on the time it took to move from a previous position.
        /// </summary>
        /// <param name="current">The current position.</param>
        /// <param name="previous">The previous position.</param>
        /// <param name="delta">The time since the last position.</param>
        /// <returns>The current movement speed based on the time it took to move from a previous position.</returns>
        public static float Speed(this Vector2 current, [NotNull] GameObject previous, float delta) => current.Speed(previous.transform.position, delta);
        
        /// <summary>
        /// The current movement speed based on the time it took to move from a previous position.
        /// </summary>
        /// <param name="current">The current position.</param>
        /// <param name="previous">The previous position.</param>
        /// <returns>The current movement speed based on the time it took to move from a previous position.</returns>
        public static float Speed(this Vector2 current, [NotNull] GameObject previous) => current.Speed(previous, Time.deltaTime);
        
        /// <summary>
        /// The current movement speed based on the time it took to move from a previous position.
        /// </summary>
        /// <param name="current">The current position.</param>
        /// <param name="previous">The previous position.</param>
        /// <param name="delta">The time since the last position.</param>
        /// <returns>The current movement speed based on the time it took to move from a previous position.</returns>
        public static float Speed(this Vector2 current, [NotNull] KaijuAgent previous, float delta) => current.Speed(previous.transform.position, delta);
        
        /// <summary>
        /// The current movement speed based on the time it took to move from a previous position.
        /// </summary>
        /// <param name="current">The current position.</param>
        /// <param name="previous">The previous position.</param>
        /// <returns>The current movement speed based on the time it took to move from a previous position.</returns>
        public static float Speed(this Vector2 current, [NotNull] KaijuAgent previous) => current.Speed(previous, Time.deltaTime);
        
        /// <summary>
        /// The current movement speed based on the time it took to move from a previous position.
        /// </summary>
        /// <param name="current">The current position.</param>
        /// <param name="previous">The previous position.</param>
        /// <param name="delta">The time since the last position.</param>
        /// <returns>The current movement speed based on the time it took to move from a previous position.</returns>
        public static float Speed(this Vector2 current, [NotNull] KaijuSensor previous, float delta) => current.Speed(previous.transform.position, delta);
        
        /// <summary>
        /// The current movement speed based on the time it took to move from a previous position.
        /// </summary>
        /// <param name="current">The current position.</param>
        /// <param name="previous">The previous position.</param>
        /// <returns>The current movement speed based on the time it took to move from a previous position.</returns>
        public static float Speed(this Vector2 current, [NotNull] KaijuSensor previous) => current.Speed(previous, Time.deltaTime);
        
        /// <summary>
        /// The current movement speed based on the time it took to move from a previous position.
        /// </summary>
        /// <param name="current">The current position.</param>
        /// <param name="previous">The previous position.</param>
        /// <param name="delta">The time since the last position.</param>
        /// <returns>The current movement speed based on the time it took to move from a previous position.</returns>
        public static float Speed(this Vector3 current, Vector2 previous, float delta) => previous.Speed(current, delta);
        
        /// <summary>
        /// The current movement speed based on the time it took to move from a previous position.
        /// </summary>
        /// <param name="current">The current position.</param>
        /// <param name="previous">The previous position.</param>
        /// <returns>The current movement speed based on the time it took to move from a previous position.</returns>
        public static float Speed(this Vector3 current, Vector2 previous) => current.Speed(previous, Time.deltaTime);
        
        /// <summary>
        /// The current movement speed based on the time it took to move from a previous position.
        /// </summary>
        /// <param name="current">The current position.</param>
        /// <param name="previous">The previous position.</param>
        /// <param name="delta">The time since the last position.</param>
        /// <returns>The current movement speed based on the time it took to move from a previous position.</returns>
        public static float Speed(this Vector3 current, Vector3 previous, float delta) => new Vector2(current.x, current.z).Speed(previous, delta);
        
        /// <summary>
        /// The current movement speed based on the time it took to move from a previous position.
        /// </summary>
        /// <param name="current">The current position.</param>
        /// <param name="previous">The previous position.</param>
        /// <returns>The current movement speed based on the time it took to move from a previous position.</returns>
        public static float Speed(this Vector3 current, Vector3 previous) => current.Speed(previous, Time.deltaTime);
        
        /// <summary>
        /// The current movement speed based on the time it took to move from a previous position.
        /// </summary>
        /// <param name="current">The current position.</param>
        /// <param name="previous">The previous position.</param>
        /// <param name="delta">The time since the last position.</param>
        /// <returns>The current movement speed based on the time it took to move from a previous position.</returns>
        public static float Speed(this Vector3 current, [NotNull] Transform previous, float delta) => current.Speed(previous.position, delta);
        
        /// <summary>
        /// The current movement speed based on the time it took to move from a previous position.
        /// </summary>
        /// <param name="current">The current position.</param>
        /// <param name="previous">The previous position.</param>
        /// <returns>The current movement speed based on the time it took to move from a previous position.</returns>
        public static float Speed(this Vector3 current, [NotNull] Transform previous) => current.Speed(previous, Time.deltaTime);
        
        /// <summary>
        /// The current movement speed based on the time it took to move from a previous position.
        /// </summary>
        /// <param name="current">The current position.</param>
        /// <param name="previous">The previous position.</param>
        /// <param name="delta">The time since the last position.</param>
        /// <returns>The current movement speed based on the time it took to move from a previous position.</returns>
        public static float Speed(this Vector3 current, [NotNull] Component previous, float delta) => current.Speed(previous.transform.position, delta);
        
        /// <summary>
        /// The current movement speed based on the time it took to move from a previous position.
        /// </summary>
        /// <param name="current">The current position.</param>
        /// <param name="previous">The previous position.</param>
        /// <returns>The current movement speed based on the time it took to move from a previous position.</returns>
        public static float Speed(this Vector3 current, [NotNull] Component previous) => current.Speed(previous, Time.deltaTime);
        
        /// <summary>
        /// The current movement speed based on the time it took to move from a previous position.
        /// </summary>
        /// <param name="current">The current position.</param>
        /// <param name="previous">The previous position.</param>
        /// <param name="delta">The time since the last position.</param>
        /// <returns>The current movement speed based on the time it took to move from a previous position.</returns>
        public static float Speed(this Vector3 current, [NotNull] GameObject previous, float delta) => current.Speed(previous.transform.position, delta);
        
        /// <summary>
        /// The current movement speed based on the time it took to move from a previous position.
        /// </summary>
        /// <param name="current">The current position.</param>
        /// <param name="previous">The previous position.</param>
        /// <returns>The current movement speed based on the time it took to move from a previous position.</returns>
        public static float Speed(this Vector3 current, [NotNull] GameObject previous) => current.Speed(previous, Time.deltaTime);
        
        /// <summary>
        /// The current movement speed based on the time it took to move from a previous position.
        /// </summary>
        /// <param name="current">The current position.</param>
        /// <param name="previous">The previous position.</param>
        /// <param name="delta">The time since the last position.</param>
        /// <returns>The current movement speed based on the time it took to move from a previous position.</returns>
        public static float Speed(this Vector3 current, [NotNull] KaijuAgent previous, float delta) => current.Speed(previous.transform.position, delta);
        
        /// <summary>
        /// The current movement speed based on the time it took to move from a previous position.
        /// </summary>
        /// <param name="current">The current position.</param>
        /// <param name="previous">The previous position.</param>
        /// <returns>The current movement speed based on the time it took to move from a previous position.</returns>
        public static float Speed(this Vector3 current, [NotNull] KaijuAgent previous) => current.Speed(previous, Time.deltaTime);
        
        /// <summary>
        /// The current movement speed based on the time it took to move from a previous position.
        /// </summary>
        /// <param name="current">The current position.</param>
        /// <param name="previous">The previous position.</param>
        /// <param name="delta">The time since the last position.</param>
        /// <returns>The current movement speed based on the time it took to move from a previous position.</returns>
        public static float Speed(this Vector3 current, [NotNull] KaijuSensor previous, float delta) => current.Speed(previous.transform.position, delta);
        
        /// <summary>
        /// The current movement speed based on the time it took to move from a previous position.
        /// </summary>
        /// <param name="current">The current position.</param>
        /// <param name="previous">The previous position.</param>
        /// <returns>The current movement speed based on the time it took to move from a previous position.</returns>
        public static float Speed(this Vector3 current, [NotNull] KaijuSensor previous) => current.Speed(previous, Time.deltaTime);
        
        /// <summary>
        /// The current movement speed based on the time it took to move from a previous position.
        /// </summary>
        /// <param name="current">The current position.</param>
        /// <param name="previous">The previous position.</param>
        /// <param name="delta">The time since the last position.</param>
        /// <returns>The current movement speed based on the time it took to move from a previous position.</returns>
        public static float Speed([NotNull] this Transform current, Vector2 previous, float delta) => previous.Speed(current, delta);
        
        /// <summary>
        /// The current movement speed based on the time it took to move from a previous position.
        /// </summary>
        /// <param name="current">The current position.</param>
        /// <param name="previous">The previous position.</param>
        /// <returns>The current movement speed based on the time it took to move from a previous position.</returns>
        public static float Speed([NotNull] this Transform current, Vector2 previous) => current.Speed(previous, Time.deltaTime);
        
        /// <summary>
        /// The current movement speed based on the time it took to move from a previous position.
        /// </summary>
        /// <param name="current">The current position.</param>
        /// <param name="previous">The previous position.</param>
        /// <param name="delta">The time since the last position.</param>
        /// <returns>The current movement speed based on the time it took to move from a previous position.</returns>
        public static float Speed([NotNull] this Transform current, Vector3 previous, float delta) => current.position.Speed(previous, delta);
        
        /// <summary>
        /// The current movement speed based on the time it took to move from a previous position.
        /// </summary>
        /// <param name="current">The current position.</param>
        /// <param name="previous">The previous position.</param>
        /// <returns>The current movement speed based on the time it took to move from a previous position.</returns>
        public static float Speed([NotNull] this Transform current, Vector3 previous) => current.Speed(previous, Time.deltaTime);
        
        /// <summary>
        /// The current movement speed based on the time it took to move from a previous position.
        /// </summary>
        /// <param name="current">The current position.</param>
        /// <param name="previous">The previous position.</param>
        /// <param name="delta">The time since the last position.</param>
        /// <returns>The current movement speed based on the time it took to move from a previous position.</returns>
        public static float Speed([NotNull] this Transform current, [NotNull] Transform previous, float delta) => current.position.Speed(previous.position, delta);
        
        /// <summary>
        /// The current movement speed based on the time it took to move from a previous position.
        /// </summary>
        /// <param name="current">The current position.</param>
        /// <param name="previous">The previous position.</param>
        /// <returns>The current movement speed based on the time it took to move from a previous position.</returns>
        public static float Speed([NotNull] this Transform current, [NotNull] Transform previous) => current.Speed(previous, Time.deltaTime);
        
        /// <summary>
        /// The current movement speed based on the time it took to move from a previous position.
        /// </summary>
        /// <param name="current">The current position.</param>
        /// <param name="previous">The previous position.</param>
        /// <param name="delta">The time since the last position.</param>
        /// <returns>The current movement speed based on the time it took to move from a previous position.</returns>
        public static float Speed([NotNull] this Transform current, [NotNull] Component previous, float delta) => current.position.Speed(previous.transform.position, delta);
        
        /// <summary>
        /// The current movement speed based on the time it took to move from a previous position.
        /// </summary>
        /// <param name="current">The current position.</param>
        /// <param name="previous">The previous position.</param>
        /// <returns>The current movement speed based on the time it took to move from a previous position.</returns>
        public static float Speed([NotNull] this Transform current, [NotNull] Component previous) => current.Speed(previous, Time.deltaTime);
        
        /// <summary>
        /// The current movement speed based on the time it took to move from a previous position.
        /// </summary>
        /// <param name="current">The current position.</param>
        /// <param name="previous">The previous position.</param>
        /// <param name="delta">The time since the last position.</param>
        /// <returns>The current movement speed based on the time it took to move from a previous position.</returns>
        public static float Speed([NotNull] this Transform current, [NotNull] GameObject previous, float delta) => current.position.Speed(previous.transform.position, delta);
        
        /// <summary>
        /// The current movement speed based on the time it took to move from a previous position.
        /// </summary>
        /// <param name="current">The current position.</param>
        /// <param name="previous">The previous position.</param>
        /// <returns>The current movement speed based on the time it took to move from a previous position.</returns>
        public static float Speed([NotNull] this Transform current, [NotNull] GameObject previous) => current.Speed(previous, Time.deltaTime);
        
        /// <summary>
        /// The current movement speed based on the time it took to move from a previous position.
        /// </summary>
        /// <param name="current">The current position.</param>
        /// <param name="previous">The previous position.</param>
        /// <param name="delta">The time since the last position.</param>
        /// <returns>The current movement speed based on the time it took to move from a previous position.</returns>
        public static float Speed([NotNull] this Transform current, [NotNull] KaijuAgent previous, float delta) => current.position.Speed(previous.transform.position, delta);
        
        /// <summary>
        /// The current movement speed based on the time it took to move from a previous position.
        /// </summary>
        /// <param name="current">The current position.</param>
        /// <param name="previous">The previous position.</param>
        /// <returns>The current movement speed based on the time it took to move from a previous position.</returns>
        public static float Speed([NotNull] this Transform current, [NotNull] KaijuAgent previous) => current.Speed(previous, Time.deltaTime);
        
        /// <summary>
        /// The current movement speed based on the time it took to move from a previous position.
        /// </summary>
        /// <param name="current">The current position.</param>
        /// <param name="previous">The previous position.</param>
        /// <param name="delta">The time since the last position.</param>
        /// <returns>The current movement speed based on the time it took to move from a previous position.</returns>
        public static float Speed([NotNull] this Transform current, [NotNull] KaijuSensor previous, float delta) => current.position.Speed(previous.transform.position, delta);
        
        /// <summary>
        /// The current movement speed based on the time it took to move from a previous position.
        /// </summary>
        /// <param name="current">The current position.</param>
        /// <param name="previous">The previous position.</param>
        /// <returns>The current movement speed based on the time it took to move from a previous position.</returns>
        public static float Speed([NotNull] this Transform current, [NotNull] KaijuSensor previous) => current.Speed(previous, Time.deltaTime);
        
        /// <summary>
        /// The current movement speed based on the time it took to move from a previous position.
        /// </summary>
        /// <param name="current">The current position.</param>
        /// <param name="previous">The previous position.</param>
        /// <param name="delta">The time since the last position.</param>
        /// <returns>The current movement speed based on the time it took to move from a previous position.</returns>
        public static float Speed([NotNull] this Component current, Vector2 previous, float delta) => previous.Speed(current, delta);
        
        /// <summary>
        /// The current movement speed based on the time it took to move from a previous position.
        /// </summary>
        /// <param name="current">The current position.</param>
        /// <param name="previous">The previous position.</param>
        /// <returns>The current movement speed based on the time it took to move from a previous position.</returns>
        public static float Speed([NotNull] this Component current, Vector2 previous) => current.Speed(previous, Time.deltaTime);
        
        /// <summary>
        /// The current movement speed based on the time it took to move from a previous position.
        /// </summary>
        /// <param name="current">The current position.</param>
        /// <param name="previous">The previous position.</param>
        /// <param name="delta">The time since the last position.</param>
        /// <returns>The current movement speed based on the time it took to move from a previous position.</returns>
        public static float Speed([NotNull] this Component current, Vector3 previous, float delta) => current.transform.position.Speed(previous, delta);
        
        /// <summary>
        /// The current movement speed based on the time it took to move from a previous position.
        /// </summary>
        /// <param name="current">The current position.</param>
        /// <param name="previous">The previous position.</param>
        /// <returns>The current movement speed based on the time it took to move from a previous position.</returns>
        public static float Speed([NotNull] this Component current, Vector3 previous) => current.Speed(previous, Time.deltaTime);
        
        /// <summary>
        /// The current movement speed based on the time it took to move from a previous position.
        /// </summary>
        /// <param name="current">The current position.</param>
        /// <param name="previous">The previous position.</param>
        /// <param name="delta">The time since the last position.</param>
        /// <returns>The current movement speed based on the time it took to move from a previous position.</returns>
        public static float Speed([NotNull] this Component current, [NotNull] Transform previous, float delta) => current.transform.position.Speed(previous.position, delta);
        
        /// <summary>
        /// The current movement speed based on the time it took to move from a previous position.
        /// </summary>
        /// <param name="current">The current position.</param>
        /// <param name="previous">The previous position.</param>
        /// <returns>The current movement speed based on the time it took to move from a previous position.</returns>
        public static float Speed([NotNull] this Component current, [NotNull] Transform previous) => current.Speed(previous, Time.deltaTime);
        
        /// <summary>
        /// The current movement speed based on the time it took to move from a previous position.
        /// </summary>
        /// <param name="current">The current position.</param>
        /// <param name="previous">The previous position.</param>
        /// <param name="delta">The time since the last position.</param>
        /// <returns>The current movement speed based on the time it took to move from a previous position.</returns>
        public static float Speed([NotNull] this Component current, [NotNull] Component previous, float delta) => current.transform.position.Speed(previous.transform.position, delta);
        
        /// <summary>
        /// The current movement speed based on the time it took to move from a previous position.
        /// </summary>
        /// <param name="current">The current position.</param>
        /// <param name="previous">The previous position.</param>
        /// <returns>The current movement speed based on the time it took to move from a previous position.</returns>
        public static float Speed([NotNull] this Component current, [NotNull] Component previous) => current.Speed(previous, Time.deltaTime);
        
        /// <summary>
        /// The current movement speed based on the time it took to move from a previous position.
        /// </summary>
        /// <param name="current">The current position.</param>
        /// <param name="previous">The previous position.</param>
        /// <param name="delta">The time since the last position.</param>
        /// <returns>The current movement speed based on the time it took to move from a previous position.</returns>
        public static float Speed([NotNull] this Component current, [NotNull] GameObject previous, float delta) => current.transform.position.Speed(previous.transform.position, delta);
        
        /// <summary>
        /// The current movement speed based on the time it took to move from a previous position.
        /// </summary>
        /// <param name="current">The current position.</param>
        /// <param name="previous">The previous position.</param>
        /// <returns>The current movement speed based on the time it took to move from a previous position.</returns>
        public static float Speed([NotNull] this Component current, [NotNull] GameObject previous) => current.Speed(previous, Time.deltaTime);
        
        /// <summary>
        /// The current movement speed based on the time it took to move from a previous position.
        /// </summary>
        /// <param name="current">The current position.</param>
        /// <param name="previous">The previous position.</param>
        /// <param name="delta">The time since the last position.</param>
        /// <returns>The current movement speed based on the time it took to move from a previous position.</returns>
        public static float Speed([NotNull] this Component current, [NotNull] KaijuAgent previous, float delta) => current.transform.position.Speed(previous.transform.position, delta);
        
        /// <summary>
        /// The current movement speed based on the time it took to move from a previous position.
        /// </summary>
        /// <param name="current">The current position.</param>
        /// <param name="previous">The previous position.</param>
        /// <returns>The current movement speed based on the time it took to move from a previous position.</returns>
        public static float Speed([NotNull] this Component current, [NotNull] KaijuAgent previous) => current.Speed(previous, Time.deltaTime);
        
        /// <summary>
        /// The current movement speed based on the time it took to move from a previous position.
        /// </summary>
        /// <param name="current">The current position.</param>
        /// <param name="previous">The previous position.</param>
        /// <param name="delta">The time since the last position.</param>
        /// <returns>The current movement speed based on the time it took to move from a previous position.</returns>
        public static float Speed([NotNull] this Component current, [NotNull] KaijuSensor previous, float delta) => current.transform.position.Speed(previous.transform.position, delta);
        
        /// <summary>
        /// The current movement speed based on the time it took to move from a previous position.
        /// </summary>
        /// <param name="current">The current position.</param>
        /// <param name="previous">The previous position.</param>
        /// <returns>The current movement speed based on the time it took to move from a previous position.</returns>
        public static float Speed([NotNull] this Component current, [NotNull] KaijuSensor previous) => current.Speed(previous, Time.deltaTime);
        
        /// <summary>
        /// The current movement speed based on the time it took to move from a previous position.
        /// </summary>
        /// <param name="current">The current position.</param>
        /// <param name="previous">The previous position.</param>
        /// <param name="delta">The time since the last position.</param>
        /// <returns>The current movement speed based on the time it took to move from a previous position.</returns>
        public static float Speed([NotNull] this GameObject current, Vector2 previous, float delta) => previous.Speed(current, delta);
        
        /// <summary>
        /// The current movement speed based on the time it took to move from a previous position.
        /// </summary>
        /// <param name="current">The current position.</param>
        /// <param name="previous">The previous position.</param>
        /// <returns>The current movement speed based on the time it took to move from a previous position.</returns>
        public static float Speed([NotNull] this GameObject current, Vector2 previous) => current.Speed(previous, Time.deltaTime);
        
        /// <summary>
        /// The current movement speed based on the time it took to move from a previous position.
        /// </summary>
        /// <param name="current">The current position.</param>
        /// <param name="previous">The previous position.</param>
        /// <param name="delta">The time since the last position.</param>
        /// <returns>The current movement speed based on the time it took to move from a previous position.</returns>
        public static float Speed([NotNull] this GameObject current, Vector3 previous, float delta) => current.transform.position.Speed(previous, delta);
        
        /// <summary>
        /// The current movement speed based on the time it took to move from a previous position.
        /// </summary>
        /// <param name="current">The current position.</param>
        /// <param name="previous">The previous position.</param>
        /// <returns>The current movement speed based on the time it took to move from a previous position.</returns>
        public static float Speed([NotNull] this GameObject current, Vector3 previous) => current.Speed(previous, Time.deltaTime);
        
        /// <summary>
        /// The current movement speed based on the time it took to move from a previous position.
        /// </summary>
        /// <param name="current">The current position.</param>
        /// <param name="previous">The previous position.</param>
        /// <param name="delta">The time since the last position.</param>
        /// <returns>The current movement speed based on the time it took to move from a previous position.</returns>
        public static float Speed([NotNull] this GameObject current, [NotNull] Transform previous, float delta) => current.transform.position.Speed(previous.position, delta);
        
        /// <summary>
        /// The current movement speed based on the time it took to move from a previous position.
        /// </summary>
        /// <param name="current">The current position.</param>
        /// <param name="previous">The previous position.</param>
        /// <returns>The current movement speed based on the time it took to move from a previous position.</returns>
        public static float Speed([NotNull] this GameObject current, [NotNull] Transform previous) => current.Speed(previous, Time.deltaTime);
        
        /// <summary>
        /// The current movement speed based on the time it took to move from a previous position.
        /// </summary>
        /// <param name="current">The current position.</param>
        /// <param name="previous">The previous position.</param>
        /// <param name="delta">The time since the last position.</param>
        /// <returns>The current movement speed based on the time it took to move from a previous position.</returns>
        public static float Speed([NotNull] this GameObject current, [NotNull] Component previous, float delta) => current.transform.position.Speed(previous.transform.position, delta);
        
        /// <summary>
        /// The current movement speed based on the time it took to move from a previous position.
        /// </summary>
        /// <param name="current">The current position.</param>
        /// <param name="previous">The previous position.</param>
        /// <returns>The current movement speed based on the time it took to move from a previous position.</returns>
        public static float Speed([NotNull] this GameObject current, [NotNull] Component previous) => current.Speed(previous, Time.deltaTime);
        
        /// <summary>
        /// The current movement speed based on the time it took to move from a previous position.
        /// </summary>
        /// <param name="current">The current position.</param>
        /// <param name="previous">The previous position.</param>
        /// <param name="delta">The time since the last position.</param>
        /// <returns>The current movement speed based on the time it took to move from a previous position.</returns>
        public static float Speed([NotNull] this GameObject current, [NotNull] GameObject previous, float delta) => current.transform.position.Speed(previous.transform.position, delta);
        
        /// <summary>
        /// The current movement speed based on the time it took to move from a previous position.
        /// </summary>
        /// <param name="current">The current position.</param>
        /// <param name="previous">The previous position.</param>
        /// <returns>The current movement speed based on the time it took to move from a previous position.</returns>
        public static float Speed([NotNull] this GameObject current, [NotNull] GameObject previous) => current.Speed(previous, Time.deltaTime);
        
        /// <summary>
        /// The current movement speed based on the time it took to move from a previous position.
        /// </summary>
        /// <param name="current">The current position.</param>
        /// <param name="previous">The previous position.</param>
        /// <param name="delta">The time since the last position.</param>
        /// <returns>The current movement speed based on the time it took to move from a previous position.</returns>
        public static float Speed([NotNull] this GameObject current, [NotNull] KaijuAgent previous, float delta) => current.transform.position.Speed(previous.transform.position, delta);
        
        /// <summary>
        /// The current movement speed based on the time it took to move from a previous position.
        /// </summary>
        /// <param name="current">The current position.</param>
        /// <param name="previous">The previous position.</param>
        /// <returns>The current movement speed based on the time it took to move from a previous position.</returns>
        public static float Speed([NotNull] this GameObject current, [NotNull] KaijuAgent previous) => current.Speed(previous, Time.deltaTime);
        
        /// <summary>
        /// The current movement speed based on the time it took to move from a previous position.
        /// </summary>
        /// <param name="current">The current position.</param>
        /// <param name="previous">The previous position.</param>
        /// <param name="delta">The time since the last position.</param>
        /// <returns>The current movement speed based on the time it took to move from a previous position.</returns>
        public static float Speed([NotNull] this GameObject current, [NotNull] KaijuSensor previous, float delta) => current.transform.position.Speed(previous.transform.position, delta);
        
        /// <summary>
        /// The current movement speed based on the time it took to move from a previous position.
        /// </summary>
        /// <param name="current">The current position.</param>
        /// <param name="previous">The previous position.</param>
        /// <returns>The current movement speed based on the time it took to move from a previous position.</returns>
        public static float Speed([NotNull] this GameObject current, [NotNull] KaijuSensor previous) => current.Speed(previous, Time.deltaTime);
    }
}