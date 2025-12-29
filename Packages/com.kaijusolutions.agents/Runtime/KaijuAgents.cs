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
        /// Flatten an XYZ vector down to the X and Z axes.
        /// </summary>
        /// <param name="vector">The vector to flatten.</param>
        /// <returns>The  XYZ vector flattened down to the X and Z axes.</returns>
        public static Vector2 Flatten(this Vector3 vector) => new(vector.x, vector.z);
        
        /// <summary>
        /// Flatten a transform down to the X and Z axes positions.
        /// </summary>
        /// <param name="transform">The vector to flatten.</param>
        /// <returns>The transform flattened down to the X and Z axes positions.</returns>
        public static Vector2 Flatten([NotNull] this Transform transform) => transform.position.Flatten();
        
        /// <summary>
        /// Flatten a component down to the X and Z axes positions.
        /// </summary>
        /// <param name="component">The vector to flatten.</param>
        /// <returns>The component flattened down to the X and Z axes positions.</returns>
        public static Vector2 Flatten([NotNull] this Component component) => component.transform.position.Flatten();
        
        /// <summary>
        /// Flatten a GameObject down to the X and Z axes positions.
        /// </summary>
        /// <param name="gameObject">The vector to flatten.</param>
        /// <returns>The GameObject flattened down to the X and Z axes positions.</returns>
        public static Vector2 Flatten([NotNull] this GameObject gameObject) => gameObject.transform.position.Flatten();
        
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
        public static float Distance(this Vector2 self, Vector3 other) => self.Distance(other.Flatten());
        
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
        public static float Distance(this Vector3 self, Vector2 other) => other.Distance(self);
        
        /// <summary>
        /// Get the distance between this and another position.
        /// </summary>
        /// <param name="self">This position.</param>
        /// <param name="other">The other position.</param>
        /// <returns>The distance.</returns>
        public static float Distance(this Vector3 self, Vector3 other) => self.Flatten().Distance(other);
        
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
        public static bool Within(this Vector2 self, Vector3 other, float distance) => self.Within(other.Flatten(), distance);
        
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
        public static bool Beyond(this Vector2 self, Vector3 other, float distance) => self.Beyond(other.Flatten(), distance);
        
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
        public static bool Between(this Vector2 self, Vector3 other, float minimum, float maximum) => self.Between(other.Flatten(), minimum, maximum);
        
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
        public static bool Between(this Vector3 self, Vector2 other, float minimum, float maximum) => other.Between(self, minimum, maximum);

        /// <summary>
        /// If this is between two distances to another position.
        /// </summary>
        /// <param name="self">This position.</param>
        /// <param name="other">The other position.</param>
        /// <param name="minimum">The minimum distance.</param>
        /// <param name="maximum">The maximum distance.</param>
        /// <returns>If this is between two distances to another position.</returns>
        public static bool Between(this Vector3 self, Vector3 other, float minimum, float maximum) => self.Flatten().Between(other, minimum, maximum);
        
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
        public static Vector2 Direction(this Vector2 self, Vector3 other) => self.Direction(other.Flatten());
        
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
        public static Vector2 Direction(this Vector3 self, Vector2 other) => self.Flatten().Direction(other);
        
        /// <summary>
        /// The direction from this position to another position.
        /// </summary>
        /// <param name="self">This position.</param>
        /// <param name="other">The other position.</param>
        /// <returns>The direction from this position to another position.</returns>
        public static Vector2 Direction(this Vector3 self, Vector3 other) => self.Flatten().Direction(other.Flatten());
        
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
        /// The current speed based on the time it took to move from a previous position.
        /// </summary>
        /// <param name="current">The current position.</param>
        /// <param name="previous">The previous position.</param>
        /// <param name="delta">The time since the last position.</param>
        /// <returns>The current speed based on the time it took to move from a previous position.</returns>
        public static float Speed(this Vector2 current, Vector2 previous, float delta) => current.Distance(previous) / delta;
        
        /// <summary>
        /// The current speed based on the time it took to move from a previous position.
        /// </summary>
        /// <param name="current">The current position.</param>
        /// <param name="previous">The previous position.</param>
        /// <returns>The current speed based on the time it took to move from a previous position.</returns>
        public static float Speed(this Vector2 current, Vector2 previous) => current.Speed(previous, Time.deltaTime);
        
        /// <summary>
        /// The current speed based on the time it took to move from a previous position.
        /// </summary>
        /// <param name="current">The current position.</param>
        /// <param name="previous">The previous position.</param>
        /// <param name="delta">The time since the last position.</param>
        /// <returns>The current speed based on the time it took to move from a previous position.</returns>
        public static float Speed(this Vector2 current, Vector3 previous, float delta) => current.Speed(previous.Flatten(), delta);
        
        /// <summary>
        /// The current speed based on the time it took to move from a previous position.
        /// </summary>
        /// <param name="current">The current position.</param>
        /// <param name="previous">The previous position.</param>
        /// <returns>The current speed based on the time it took to move from a previous position.</returns>
        public static float Speed(this Vector2 current, Vector3 previous) => current.Speed(previous, Time.deltaTime);
        
        /// <summary>
        /// The current speed based on the time it took to move from a previous position.
        /// </summary>
        /// <param name="current">The current position.</param>
        /// <param name="previous">The previous position.</param>
        /// <param name="delta">The time since the last position.</param>
        /// <returns>The current speed based on the time it took to move from a previous position.</returns>
        public static float Speed(this Vector2 current, [NotNull] Transform previous, float delta) => current.Speed(previous.position, delta);
        
        /// <summary>
        /// The current speed based on the time it took to move from a previous position.
        /// </summary>
        /// <param name="current">The current position.</param>
        /// <param name="previous">The previous position.</param>
        /// <returns>The current speed based on the time it took to move from a previous position.</returns>
        public static float Speed(this Vector2 current, [NotNull] Transform previous) => current.Speed(previous, Time.deltaTime);
        
        /// <summary>
        /// The current speed based on the time it took to move from a previous position.
        /// </summary>
        /// <param name="current">The current position.</param>
        /// <param name="previous">The previous position.</param>
        /// <param name="delta">The time since the last position.</param>
        /// <returns>The current speed based on the time it took to move from a previous position.</returns>
        public static float Speed(this Vector2 current, [NotNull] Component previous, float delta) => current.Speed(previous.transform.position, delta);
        
        /// <summary>
        /// The current speed based on the time it took to move from a previous position.
        /// </summary>
        /// <param name="current">The current position.</param>
        /// <param name="previous">The previous position.</param>
        /// <returns>The current speed based on the time it took to move from a previous position.</returns>
        public static float Speed(this Vector2 current, [NotNull] Component previous) => current.Speed(previous, Time.deltaTime);
        
        /// <summary>
        /// The current speed based on the time it took to move from a previous position.
        /// </summary>
        /// <param name="current">The current position.</param>
        /// <param name="previous">The previous position.</param>
        /// <param name="delta">The time since the last position.</param>
        /// <returns>The current speed based on the time it took to move from a previous position.</returns>
        public static float Speed(this Vector2 current, [NotNull] GameObject previous, float delta) => current.Speed(previous.transform.position, delta);
        
        /// <summary>
        /// The current speed based on the time it took to move from a previous position.
        /// </summary>
        /// <param name="current">The current position.</param>
        /// <param name="previous">The previous position.</param>
        /// <returns>The current speed based on the time it took to move from a previous position.</returns>
        public static float Speed(this Vector2 current, [NotNull] GameObject previous) => current.Speed(previous, Time.deltaTime);
        
        /// <summary>
        /// The current speed based on the time it took to move from a previous position.
        /// </summary>
        /// <param name="current">The current position.</param>
        /// <param name="previous">The previous position.</param>
        /// <param name="delta">The time since the last position.</param>
        /// <returns>The current speed based on the time it took to move from a previous position.</returns>
        public static float Speed(this Vector3 current, Vector2 previous, float delta) => previous.Speed(current, delta);
        
        /// <summary>
        /// The current speed based on the time it took to move from a previous position.
        /// </summary>
        /// <param name="current">The current position.</param>
        /// <param name="previous">The previous position.</param>
        /// <returns>The current speed based on the time it took to move from a previous position.</returns>
        public static float Speed(this Vector3 current, Vector2 previous) => current.Speed(previous, Time.deltaTime);
        
        /// <summary>
        /// The current speed based on the time it took to move from a previous position.
        /// </summary>
        /// <param name="current">The current position.</param>
        /// <param name="previous">The previous position.</param>
        /// <param name="delta">The time since the last position.</param>
        /// <returns>The current speed based on the time it took to move from a previous position.</returns>
        public static float Speed(this Vector3 current, Vector3 previous, float delta) => current.Flatten().Speed(previous, delta);
        
        /// <summary>
        /// The current speed based on the time it took to move from a previous position.
        /// </summary>
        /// <param name="current">The current position.</param>
        /// <param name="previous">The previous position.</param>
        /// <returns>The current speed based on the time it took to move from a previous position.</returns>
        public static float Speed(this Vector3 current, Vector3 previous) => current.Speed(previous, Time.deltaTime);
        
        /// <summary>
        /// The current speed based on the time it took to move from a previous position.
        /// </summary>
        /// <param name="current">The current position.</param>
        /// <param name="previous">The previous position.</param>
        /// <param name="delta">The time since the last position.</param>
        /// <returns>The current speed based on the time it took to move from a previous position.</returns>
        public static float Speed(this Vector3 current, [NotNull] Transform previous, float delta) => current.Speed(previous.position, delta);
        
        /// <summary>
        /// The current speed based on the time it took to move from a previous position.
        /// </summary>
        /// <param name="current">The current position.</param>
        /// <param name="previous">The previous position.</param>
        /// <returns>The current speed based on the time it took to move from a previous position.</returns>
        public static float Speed(this Vector3 current, [NotNull] Transform previous) => current.Speed(previous, Time.deltaTime);
        
        /// <summary>
        /// The current speed based on the time it took to move from a previous position.
        /// </summary>
        /// <param name="current">The current position.</param>
        /// <param name="previous">The previous position.</param>
        /// <param name="delta">The time since the last position.</param>
        /// <returns>The current speed based on the time it took to move from a previous position.</returns>
        public static float Speed(this Vector3 current, [NotNull] Component previous, float delta) => current.Speed(previous.transform.position, delta);
        
        /// <summary>
        /// The current speed based on the time it took to move from a previous position.
        /// </summary>
        /// <param name="current">The current position.</param>
        /// <param name="previous">The previous position.</param>
        /// <returns>The current speed based on the time it took to move from a previous position.</returns>
        public static float Speed(this Vector3 current, [NotNull] Component previous) => current.Speed(previous, Time.deltaTime);
        
        /// <summary>
        /// The current speed based on the time it took to move from a previous position.
        /// </summary>
        /// <param name="current">The current position.</param>
        /// <param name="previous">The previous position.</param>
        /// <param name="delta">The time since the last position.</param>
        /// <returns>The current speed based on the time it took to move from a previous position.</returns>
        public static float Speed(this Vector3 current, [NotNull] GameObject previous, float delta) => current.Speed(previous.transform.position, delta);
        
        /// <summary>
        /// The current speed based on the time it took to move from a previous position.
        /// </summary>
        /// <param name="current">The current position.</param>
        /// <param name="previous">The previous position.</param>
        /// <returns>The current speed based on the time it took to move from a previous position.</returns>
        public static float Speed(this Vector3 current, [NotNull] GameObject previous) => current.Speed(previous, Time.deltaTime);
        
        /// <summary>
        /// The current speed based on the time it took to move from a previous position.
        /// </summary>
        /// <param name="current">The current position.</param>
        /// <param name="previous">The previous position.</param>
        /// <param name="delta">The time since the last position.</param>
        /// <returns>The current speed based on the time it took to move from a previous position.</returns>
        public static float Speed([NotNull] this Transform current, Vector2 previous, float delta) => previous.Speed(current, delta);
        
        /// <summary>
        /// The current speed based on the time it took to move from a previous position.
        /// </summary>
        /// <param name="current">The current position.</param>
        /// <param name="previous">The previous position.</param>
        /// <returns>The current speed based on the time it took to move from a previous position.</returns>
        public static float Speed([NotNull] this Transform current, Vector2 previous) => current.Speed(previous, Time.deltaTime);
        
        /// <summary>
        /// The current speed based on the time it took to move from a previous position.
        /// </summary>
        /// <param name="current">The current position.</param>
        /// <param name="previous">The previous position.</param>
        /// <param name="delta">The time since the last position.</param>
        /// <returns>The current speed based on the time it took to move from a previous position.</returns>
        public static float Speed([NotNull] this Transform current, Vector3 previous, float delta) => current.position.Speed(previous, delta);
        
        /// <summary>
        /// The current speed based on the time it took to move from a previous position.
        /// </summary>
        /// <param name="current">The current position.</param>
        /// <param name="previous">The previous position.</param>
        /// <returns>The current speed based on the time it took to move from a previous position.</returns>
        public static float Speed([NotNull] this Transform current, Vector3 previous) => current.Speed(previous, Time.deltaTime);
        
        /// <summary>
        /// The current speed based on the time it took to move from a previous position.
        /// </summary>
        /// <param name="current">The current position.</param>
        /// <param name="previous">The previous position.</param>
        /// <param name="delta">The time since the last position.</param>
        /// <returns>The current speed based on the time it took to move from a previous position.</returns>
        public static float Speed([NotNull] this Transform current, [NotNull] Transform previous, float delta) => current.position.Speed(previous.position, delta);
        
        /// <summary>
        /// The current speed based on the time it took to move from a previous position.
        /// </summary>
        /// <param name="current">The current position.</param>
        /// <param name="previous">The previous position.</param>
        /// <returns>The current speed based on the time it took to move from a previous position.</returns>
        public static float Speed([NotNull] this Transform current, [NotNull] Transform previous) => current.Speed(previous, Time.deltaTime);
        
        /// <summary>
        /// The current speed based on the time it took to move from a previous position.
        /// </summary>
        /// <param name="current">The current position.</param>
        /// <param name="previous">The previous position.</param>
        /// <param name="delta">The time since the last position.</param>
        /// <returns>The current speed based on the time it took to move from a previous position.</returns>
        public static float Speed([NotNull] this Transform current, [NotNull] Component previous, float delta) => current.position.Speed(previous.transform.position, delta);
        
        /// <summary>
        /// The current speed based on the time it took to move from a previous position.
        /// </summary>
        /// <param name="current">The current position.</param>
        /// <param name="previous">The previous position.</param>
        /// <returns>The current speed based on the time it took to move from a previous position.</returns>
        public static float Speed([NotNull] this Transform current, [NotNull] Component previous) => current.Speed(previous, Time.deltaTime);
        
        /// <summary>
        /// The current speed based on the time it took to move from a previous position.
        /// </summary>
        /// <param name="current">The current position.</param>
        /// <param name="previous">The previous position.</param>
        /// <param name="delta">The time since the last position.</param>
        /// <returns>The current speed based on the time it took to move from a previous position.</returns>
        public static float Speed([NotNull] this Transform current, [NotNull] GameObject previous, float delta) => current.position.Speed(previous.transform.position, delta);
        
        /// <summary>
        /// The current speed based on the time it took to move from a previous position.
        /// </summary>
        /// <param name="current">The current position.</param>
        /// <param name="previous">The previous position.</param>
        /// <returns>The current speed based on the time it took to move from a previous position.</returns>
        public static float Speed([NotNull] this Transform current, [NotNull] GameObject previous) => current.Speed(previous, Time.deltaTime);
        
        /// <summary>
        /// The current speed based on the time it took to move from a previous position.
        /// </summary>
        /// <param name="current">The current position.</param>
        /// <param name="previous">The previous position.</param>
        /// <param name="delta">The time since the last position.</param>
        /// <returns>The current speed based on the time it took to move from a previous position.</returns>
        public static float Speed([NotNull] this Component current, Vector2 previous, float delta) => previous.Speed(current, delta);
        
        /// <summary>
        /// The current speed based on the time it took to move from a previous position.
        /// </summary>
        /// <param name="current">The current position.</param>
        /// <param name="previous">The previous position.</param>
        /// <returns>The current speed based on the time it took to move from a previous position.</returns>
        public static float Speed([NotNull] this Component current, Vector2 previous) => current.Speed(previous, Time.deltaTime);
        
        /// <summary>
        /// The current speed based on the time it took to move from a previous position.
        /// </summary>
        /// <param name="current">The current position.</param>
        /// <param name="previous">The previous position.</param>
        /// <param name="delta">The time since the last position.</param>
        /// <returns>The current speed based on the time it took to move from a previous position.</returns>
        public static float Speed([NotNull] this Component current, Vector3 previous, float delta) => current.transform.position.Speed(previous, delta);
        
        /// <summary>
        /// The current speed based on the time it took to move from a previous position.
        /// </summary>
        /// <param name="current">The current position.</param>
        /// <param name="previous">The previous position.</param>
        /// <returns>The current speed based on the time it took to move from a previous position.</returns>
        public static float Speed([NotNull] this Component current, Vector3 previous) => current.Speed(previous, Time.deltaTime);
        
        /// <summary>
        /// The current speed based on the time it took to move from a previous position.
        /// </summary>
        /// <param name="current">The current position.</param>
        /// <param name="previous">The previous position.</param>
        /// <param name="delta">The time since the last position.</param>
        /// <returns>The current speed based on the time it took to move from a previous position.</returns>
        public static float Speed([NotNull] this Component current, [NotNull] Transform previous, float delta) => current.transform.position.Speed(previous.position, delta);
        
        /// <summary>
        /// The current speed based on the time it took to move from a previous position.
        /// </summary>
        /// <param name="current">The current position.</param>
        /// <param name="previous">The previous position.</param>
        /// <returns>The current speed based on the time it took to move from a previous position.</returns>
        public static float Speed([NotNull] this Component current, [NotNull] Transform previous) => current.Speed(previous, Time.deltaTime);
        
        /// <summary>
        /// The current speed based on the time it took to move from a previous position.
        /// </summary>
        /// <param name="current">The current position.</param>
        /// <param name="previous">The previous position.</param>
        /// <param name="delta">The time since the last position.</param>
        /// <returns>The current speed based on the time it took to move from a previous position.</returns>
        public static float Speed([NotNull] this Component current, [NotNull] Component previous, float delta) => current.transform.position.Speed(previous.transform.position, delta);
        
        /// <summary>
        /// The current speed based on the time it took to move from a previous position.
        /// </summary>
        /// <param name="current">The current position.</param>
        /// <param name="previous">The previous position.</param>
        /// <returns>The current speed based on the time it took to move from a previous position.</returns>
        public static float Speed([NotNull] this Component current, [NotNull] Component previous) => current.Speed(previous, Time.deltaTime);
        
        /// <summary>
        /// The current speed based on the time it took to move from a previous position.
        /// </summary>
        /// <param name="current">The current position.</param>
        /// <param name="previous">The previous position.</param>
        /// <param name="delta">The time since the last position.</param>
        /// <returns>The current speed based on the time it took to move from a previous position.</returns>
        public static float Speed([NotNull] this Component current, [NotNull] GameObject previous, float delta) => current.transform.position.Speed(previous.transform.position, delta);
        
        /// <summary>
        /// The current speed based on the time it took to move from a previous position.
        /// </summary>
        /// <param name="current">The current position.</param>
        /// <param name="previous">The previous position.</param>
        /// <returns>The current speed based on the time it took to move from a previous position.</returns>
        public static float Speed([NotNull] this Component current, [NotNull] GameObject previous) => current.Speed(previous, Time.deltaTime);
        
        /// <summary>
        /// The current speed based on the time it took to move from a previous position.
        /// </summary>
        /// <param name="current">The current position.</param>
        /// <param name="previous">The previous position.</param>
        /// <param name="delta">The time since the last position.</param>
        /// <returns>The current speed based on the time it took to move from a previous position.</returns>
        public static float Speed([NotNull] this GameObject current, Vector2 previous, float delta) => previous.Speed(current, delta);
        
        /// <summary>
        /// The current speed based on the time it took to move from a previous position.
        /// </summary>
        /// <param name="current">The current position.</param>
        /// <param name="previous">The previous position.</param>
        /// <returns>The current speed based on the time it took to move from a previous position.</returns>
        public static float Speed([NotNull] this GameObject current, Vector2 previous) => current.Speed(previous, Time.deltaTime);
        
        /// <summary>
        /// The current speed based on the time it took to move from a previous position.
        /// </summary>
        /// <param name="current">The current position.</param>
        /// <param name="previous">The previous position.</param>
        /// <param name="delta">The time since the last position.</param>
        /// <returns>The current speed based on the time it took to move from a previous position.</returns>
        public static float Speed([NotNull] this GameObject current, Vector3 previous, float delta) => current.transform.position.Speed(previous, delta);
        
        /// <summary>
        /// The current speed based on the time it took to move from a previous position.
        /// </summary>
        /// <param name="current">The current position.</param>
        /// <param name="previous">The previous position.</param>
        /// <returns>The current speed based on the time it took to move from a previous position.</returns>
        public static float Speed([NotNull] this GameObject current, Vector3 previous) => current.Speed(previous, Time.deltaTime);
        
        /// <summary>
        /// The current speed based on the time it took to move from a previous position.
        /// </summary>
        /// <param name="current">The current position.</param>
        /// <param name="previous">The previous position.</param>
        /// <param name="delta">The time since the last position.</param>
        /// <returns>The current speed based on the time it took to move from a previous position.</returns>
        public static float Speed([NotNull] this GameObject current, [NotNull] Transform previous, float delta) => current.transform.position.Speed(previous.position, delta);
        
        /// <summary>
        /// The current speed based on the time it took to move from a previous position.
        /// </summary>
        /// <param name="current">The current position.</param>
        /// <param name="previous">The previous position.</param>
        /// <returns>The current speed based on the time it took to move from a previous position.</returns>
        public static float Speed([NotNull] this GameObject current, [NotNull] Transform previous) => current.Speed(previous, Time.deltaTime);
        
        /// <summary>
        /// The current speed based on the time it took to move from a previous position.
        /// </summary>
        /// <param name="current">The current position.</param>
        /// <param name="previous">The previous position.</param>
        /// <param name="delta">The time since the last position.</param>
        /// <returns>The current speed based on the time it took to move from a previous position.</returns>
        public static float Speed([NotNull] this GameObject current, [NotNull] Component previous, float delta) => current.transform.position.Speed(previous.transform.position, delta);
        
        /// <summary>
        /// The current speed based on the time it took to move from a previous position.
        /// </summary>
        /// <param name="current">The current position.</param>
        /// <param name="previous">The previous position.</param>
        /// <returns>The current speed based on the time it took to move from a previous position.</returns>
        public static float Speed([NotNull] this GameObject current, [NotNull] Component previous) => current.Speed(previous, Time.deltaTime);
        
        /// <summary>
        /// The current speed based on the time it took to move from a previous position.
        /// </summary>
        /// <param name="current">The current position.</param>
        /// <param name="previous">The previous position.</param>
        /// <param name="delta">The time since the last position.</param>
        /// <returns>The current speed based on the time it took to move from a previous position.</returns>
        public static float Speed([NotNull] this GameObject current, [NotNull] GameObject previous, float delta) => current.transform.position.Speed(previous.transform.position, delta);
        
        /// <summary>
        /// The current speed based on the time it took to move from a previous position.
        /// </summary>
        /// <param name="current">The current position.</param>
        /// <param name="previous">The previous position.</param>
        /// <returns>The current speed based on the time it took to move from a previous position.</returns>
        public static float Speed([NotNull] this GameObject current, [NotNull] GameObject previous) => current.Speed(previous, Time.deltaTime);
        
        /// <summary>
        /// The current speed based on the time it took to move from a previous position.
        /// </summary>
        /// <param name="current">The current position.</param>
        /// <param name="previous">The previous position.</param>
        /// <param name="delta">The time since the last position.</param>
        /// <returns>The current speed based on the time it took to move from a previous position.</returns>
        public static float Speed3(this Vector3 current, Vector3 previous, float delta) => current.Distance3(previous) / delta;
        
        /// <summary>
        /// The current speed based on the time it took to move from a previous position.
        /// </summary>
        /// <param name="current">The current position.</param>
        /// <param name="previous">The previous position.</param>
        /// <returns>The current speed based on the time it took to move from a previous position.</returns>
        public static float Speed3(this Vector3 current, Vector3 previous) => current.Speed3(previous, Time.deltaTime);
        
        /// <summary>
        /// The current speed based on the time it took to move from a previous position.
        /// </summary>
        /// <param name="current">The current position.</param>
        /// <param name="previous">The previous position.</param>
        /// <param name="delta">The time since the last position.</param>
        /// <returns>The current speed based on the time it took to move from a previous position.</returns>
        public static float Speed3(this Vector3 current, [NotNull] Transform previous, float delta) => current.Speed3(previous.position, delta);
        
        /// <summary>
        /// The current speed based on the time it took to move from a previous position.
        /// </summary>
        /// <param name="current">The current position.</param>
        /// <param name="previous">The previous position.</param>
        /// <returns>The current speed based on the time it took to move from a previous position.</returns>
        public static float Speed3(this Vector3 current, [NotNull] Transform previous) => current.Speed3(previous, Time.deltaTime);
        
        /// <summary>
        /// The current speed based on the time it took to move from a previous position.
        /// </summary>
        /// <param name="current">The current position.</param>
        /// <param name="previous">The previous position.</param>
        /// <param name="delta">The time since the last position.</param>
        /// <returns>The current speed based on the time it took to move from a previous position.</returns>
        public static float Speed3(this Vector3 current, [NotNull] Component previous, float delta) => current.Speed3(previous.transform.position, delta);
        
        /// <summary>
        /// The current speed based on the time it took to move from a previous position.
        /// </summary>
        /// <param name="current">The current position.</param>
        /// <param name="previous">The previous position.</param>
        /// <returns>The current speed based on the time it took to move from a previous position.</returns>
        public static float Speed3(this Vector3 current, [NotNull] Component previous) => current.Speed3(previous, Time.deltaTime);
        
        /// <summary>
        /// The current speed based on the time it took to move from a previous position.
        /// </summary>
        /// <param name="current">The current position.</param>
        /// <param name="previous">The previous position.</param>
        /// <param name="delta">The time since the last position.</param>
        /// <returns>The current speed based on the time it took to move from a previous position.</returns>
        public static float Speed3(this Vector3 current, [NotNull] GameObject previous, float delta) => current.Speed3(previous.transform.position, delta);
        
        /// <summary>
        /// The current speed based on the time it took to move from a previous position.
        /// </summary>
        /// <param name="current">The current position.</param>
        /// <param name="previous">The previous position.</param>
        /// <returns>The current speed based on the time it took to move from a previous position.</returns>
        public static float Speed3(this Vector3 current, [NotNull] GameObject previous) => current.Speed3(previous, Time.deltaTime);
        
        /// <summary>
        /// The current speed based on the time it took to move from a previous position.
        /// </summary>
        /// <param name="current">The current position.</param>
        /// <param name="previous">The previous position.</param>
        /// <param name="delta">The time since the last position.</param>
        /// <returns>The current speed based on the time it took to move from a previous position.</returns>
        public static float Speed3([NotNull] this Transform current, Vector3 previous, float delta) => current.position.Speed3(previous, delta);
        
        /// <summary>
        /// The current speed based on the time it took to move from a previous position.
        /// </summary>
        /// <param name="current">The current position.</param>
        /// <param name="previous">The previous position.</param>
        /// <returns>The current speed based on the time it took to move from a previous position.</returns>
        public static float Speed3([NotNull] this Transform current, Vector3 previous) => current.Speed3(previous, Time.deltaTime);
        
        /// <summary>
        /// The current speed based on the time it took to move from a previous position.
        /// </summary>
        /// <param name="current">The current position.</param>
        /// <param name="previous">The previous position.</param>
        /// <param name="delta">The time since the last position.</param>
        /// <returns>The current speed based on the time it took to move from a previous position.</returns>
        public static float Speed3([NotNull] this Transform current, [NotNull] Transform previous, float delta) => current.position.Speed3(previous.position, delta);
        
        /// <summary>
        /// The current speed based on the time it took to move from a previous position.
        /// </summary>
        /// <param name="current">The current position.</param>
        /// <param name="previous">The previous position.</param>
        /// <returns>The current speed based on the time it took to move from a previous position.</returns>
        public static float Speed3([NotNull] this Transform current, [NotNull] Transform previous) => current.Speed3(previous, Time.deltaTime);
        
        /// <summary>
        /// The current speed based on the time it took to move from a previous position.
        /// </summary>
        /// <param name="current">The current position.</param>
        /// <param name="previous">The previous position.</param>
        /// <param name="delta">The time since the last position.</param>
        /// <returns>The current speed based on the time it took to move from a previous position.</returns>
        public static float Speed3([NotNull] this Transform current, [NotNull] Component previous, float delta) => current.position.Speed3(previous.transform.position, delta);
        
        /// <summary>
        /// The current speed based on the time it took to move from a previous position.
        /// </summary>
        /// <param name="current">The current position.</param>
        /// <param name="previous">The previous position.</param>
        /// <returns>The current speed based on the time it took to move from a previous position.</returns>
        public static float Speed3([NotNull] this Transform current, [NotNull] Component previous) => current.Speed3(previous, Time.deltaTime);
        
        /// <summary>
        /// The current speed based on the time it took to move from a previous position.
        /// </summary>
        /// <param name="current">The current position.</param>
        /// <param name="previous">The previous position.</param>
        /// <param name="delta">The time since the last position.</param>
        /// <returns>The current speed based on the time it took to move from a previous position.</returns>
        public static float Speed3([NotNull] this Transform current, [NotNull] GameObject previous, float delta) => current.position.Speed3(previous.transform.position, delta);
        
        /// <summary>
        /// The current speed based on the time it took to move from a previous position.
        /// </summary>
        /// <param name="current">The current position.</param>
        /// <param name="previous">The previous position.</param>
        /// <returns>The current speed based on the time it took to move from a previous position.</returns>
        public static float Speed3([NotNull] this Transform current, [NotNull] GameObject previous) => current.Speed3(previous, Time.deltaTime);
        
        /// <summary>
        /// The current speed based on the time it took to move from a previous position.
        /// </summary>
        /// <param name="current">The current position.</param>
        /// <param name="previous">The previous position.</param>
        /// <param name="delta">The time since the last position.</param>
        /// <returns>The current speed based on the time it took to move from a previous position.</returns>
        public static float Speed3([NotNull] this Component current, Vector3 previous, float delta) => current.transform.position.Speed3(previous, delta);
        
        /// <summary>
        /// The current speed based on the time it took to move from a previous position.
        /// </summary>
        /// <param name="current">The current position.</param>
        /// <param name="previous">The previous position.</param>
        /// <returns>The current speed based on the time it took to move from a previous position.</returns>
        public static float Speed3([NotNull] this Component current, Vector3 previous) => current.Speed3(previous, Time.deltaTime);
        
        /// <summary>
        /// The current speed based on the time it took to move from a previous position.
        /// </summary>
        /// <param name="current">The current position.</param>
        /// <param name="previous">The previous position.</param>
        /// <param name="delta">The time since the last position.</param>
        /// <returns>The current speed based on the time it took to move from a previous position.</returns>
        public static float Speed3([NotNull] this Component current, [NotNull] Transform previous, float delta) => current.transform.position.Speed3(previous.position, delta);
        
        /// <summary>
        /// The current speed based on the time it took to move from a previous position.
        /// </summary>
        /// <param name="current">The current position.</param>
        /// <param name="previous">The previous position.</param>
        /// <returns>The current speed based on the time it took to move from a previous position.</returns>
        public static float Speed3([NotNull] this Component current, [NotNull] Transform previous) => current.Speed3(previous, Time.deltaTime);
        
        /// <summary>
        /// The current speed based on the time it took to move from a previous position.
        /// </summary>
        /// <param name="current">The current position.</param>
        /// <param name="previous">The previous position.</param>
        /// <param name="delta">The time since the last position.</param>
        /// <returns>The current speed based on the time it took to move from a previous position.</returns>
        public static float Speed3([NotNull] this Component current, [NotNull] Component previous, float delta) => current.transform.position.Speed3(previous.transform.position, delta);
        
        /// <summary>
        /// The current speed based on the time it took to move from a previous position.
        /// </summary>
        /// <param name="current">The current position.</param>
        /// <param name="previous">The previous position.</param>
        /// <returns>The current speed based on the time it took to move from a previous position.</returns>
        public static float Speed3([NotNull] this Component current, [NotNull] Component previous) => current.Speed3(previous, Time.deltaTime);
        
        /// <summary>
        /// The current speed based on the time it took to move from a previous position.
        /// </summary>
        /// <param name="current">The current position.</param>
        /// <param name="previous">The previous position.</param>
        /// <param name="delta">The time since the last position.</param>
        /// <returns>The current speed based on the time it took to move from a previous position.</returns>
        public static float Speed3([NotNull] this Component current, [NotNull] GameObject previous, float delta) => current.transform.position.Speed3(previous.transform.position, delta);
        
        /// <summary>
        /// The current speed based on the time it took to move from a previous position.
        /// </summary>
        /// <param name="current">The current position.</param>
        /// <param name="previous">The previous position.</param>
        /// <returns>The current speed based on the time it took to move from a previous position.</returns>
        public static float Speed3([NotNull] this Component current, [NotNull] GameObject previous) => current.Speed3(previous, Time.deltaTime);
        
        /// <summary>
        /// The current speed based on the time it took to move from a previous position.
        /// </summary>
        /// <param name="current">The current position.</param>
        /// <param name="previous">The previous position.</param>
        /// <param name="delta">The time since the last position.</param>
        /// <returns>The current speed based on the time it took to move from a previous position.</returns>
        public static float Speed3([NotNull] this GameObject current, Vector3 previous, float delta) => current.transform.position.Speed3(previous, delta);
        
        /// <summary>
        /// The current speed based on the time it took to move from a previous position.
        /// </summary>
        /// <param name="current">The current position.</param>
        /// <param name="previous">The previous position.</param>
        /// <returns>The current speed based on the time it took to move from a previous position.</returns>
        public static float Speed3([NotNull] this GameObject current, Vector3 previous) => current.Speed3(previous, Time.deltaTime);
        
        /// <summary>
        /// The current speed based on the time it took to move from a previous position.
        /// </summary>
        /// <param name="current">The current position.</param>
        /// <param name="previous">The previous position.</param>
        /// <param name="delta">The time since the last position.</param>
        /// <returns>The current speed based on the time it took to move from a previous position.</returns>
        public static float Speed3([NotNull] this GameObject current, [NotNull] Transform previous, float delta) => current.transform.position.Speed3(previous.position, delta);
        
        /// <summary>
        /// The current speed based on the time it took to move from a previous position.
        /// </summary>
        /// <param name="current">The current position.</param>
        /// <param name="previous">The previous position.</param>
        /// <returns>The current speed based on the time it took to move from a previous position.</returns>
        public static float Speed3([NotNull] this GameObject current, [NotNull] Transform previous) => current.Speed3(previous, Time.deltaTime);
        
        /// <summary>
        /// The current speed based on the time it took to move from a previous position.
        /// </summary>
        /// <param name="current">The current position.</param>
        /// <param name="previous">The previous position.</param>
        /// <param name="delta">The time since the last position.</param>
        /// <returns>The current speed based on the time it took to move from a previous position.</returns>
        public static float Speed3([NotNull] this GameObject current, [NotNull] Component previous, float delta) => current.transform.position.Speed3(previous.transform.position, delta);
        
        /// <summary>
        /// The current speed based on the time it took to move from a previous position.
        /// </summary>
        /// <param name="current">The current position.</param>
        /// <param name="previous">The previous position.</param>
        /// <returns>The current speed based on the time it took to move from a previous position.</returns>
        public static float Speed3([NotNull] this GameObject current, [NotNull] Component previous) => current.Speed3(previous, Time.deltaTime);
        
        /// <summary>
        /// The current speed based on the time it took to move from a previous position.
        /// </summary>
        /// <param name="current">The current position.</param>
        /// <param name="previous">The previous position.</param>
        /// <param name="delta">The time since the last position.</param>
        /// <returns>The current speed based on the time it took to move from a previous position.</returns>
        public static float Speed3([NotNull] this GameObject current, [NotNull] GameObject previous, float delta) => current.transform.position.Speed3(previous.transform.position, delta);
        
        /// <summary>
        /// The current speed based on the time it took to move from a previous position.
        /// </summary>
        /// <param name="current">The current position.</param>
        /// <param name="previous">The previous position.</param>
        /// <returns>The current speed based on the time it took to move from a previous position.</returns>
        public static float Speed3([NotNull] this GameObject current, [NotNull] GameObject previous) => current.Speed3(previous, Time.deltaTime);
        
        /// <summary>
        /// The current velocity based on the time it took to move from a previous position.
        /// </summary>
        /// <param name="current">The current position.</param>
        /// <param name="previous">The previous position.</param>
        /// <param name="delta">The time since the last position.</param>
        /// <returns>The current speed based on the time it took to move from a previous position.</returns>
        public static Vector2 Velocity(this Vector2 current, Vector2 previous, float delta) => current.Direction(previous) / delta;
        
        /// <summary>
        /// The current velocity based on the time it took to move from a previous position.
        /// </summary>
        /// <param name="current">The current position.</param>
        /// <param name="previous">The previous position.</param>
        /// <returns>The current speed based on the time it took to move from a previous position.</returns>
        public static Vector2 Velocity(this Vector2 current, Vector2 previous) => current.Velocity(previous, Time.deltaTime);

        /// <summary>
        /// The current velocity based on the time it took to move from a previous position.
        /// </summary>
        /// <param name="current">The current position.</param>
        /// <param name="previous">The previous position.</param>
        /// <param name="delta">The time since the last position.</param>
        /// <returns>The current speed based on the time it took to move from a previous position.</returns>
        public static Vector2 Velocity(this Vector2 current, Vector3 previous, float delta) => current.Velocity(previous.Flatten(), delta);
        
        /// <summary>
        /// The current velocity based on the time it took to move from a previous position.
        /// </summary>
        /// <param name="current">The current position.</param>
        /// <param name="previous">The previous position.</param>
        /// <returns>The current speed based on the time it took to move from a previous position.</returns>
        public static Vector2 Velocity(this Vector2 current, Vector3 previous) => current.Velocity(previous, Time.deltaTime);
        
        /// <summary>
        /// The current velocity based on the time it took to move from a previous position.
        /// </summary>
        /// <param name="current">The current position.</param>
        /// <param name="previous">The previous position.</param>
        /// <param name="delta">The time since the last position.</param>
        /// <returns>The current speed based on the time it took to move from a previous position.</returns>
        public static Vector2 Velocity(this Vector2 current, [NotNull] Transform previous, float delta) => current.Velocity(previous.position, delta);
        
        /// <summary>
        /// The current velocity based on the time it took to move from a previous position.
        /// </summary>
        /// <param name="current">The current position.</param>
        /// <param name="previous">The previous position.</param>
        /// <returns>The current speed based on the time it took to move from a previous position.</returns>
        public static Vector2 Velocity(this Vector2 current, [NotNull] Transform previous) => current.Velocity(previous.position, Time.deltaTime);
        
        /// <summary>
        /// The current velocity based on the time it took to move from a previous position.
        /// </summary>
        /// <param name="current">The current position.</param>
        /// <param name="previous">The previous position.</param>
        /// <param name="delta">The time since the last position.</param>
        /// <returns>The current speed based on the time it took to move from a previous position.</returns>
        public static Vector2 Velocity(this Vector2 current, [NotNull] Component previous, float delta) => current.Velocity(previous.transform.position, delta);
        
        /// <summary>
        /// The current velocity based on the time it took to move from a previous position.
        /// </summary>
        /// <param name="current">The current position.</param>
        /// <param name="previous">The previous position.</param>
        /// <returns>The current speed based on the time it took to move from a previous position.</returns>
        public static Vector2 Velocity(this Vector2 current, [NotNull] Component previous) => current.Velocity(previous.transform.position, Time.deltaTime);
        
        /// <summary>
        /// The current velocity based on the time it took to move from a previous position.
        /// </summary>
        /// <param name="current">The current position.</param>
        /// <param name="previous">The previous position.</param>
        /// <param name="delta">The time since the last position.</param>
        /// <returns>The current speed based on the time it took to move from a previous position.</returns>
        public static Vector2 Velocity(this Vector2 current, [NotNull] GameObject previous, float delta) => current.Velocity(previous.transform.position, delta);
        
        /// <summary>
        /// The current velocity based on the time it took to move from a previous position.
        /// </summary>
        /// <param name="current">The current position.</param>
        /// <param name="previous">The previous position.</param>
        /// <returns>The current speed based on the time it took to move from a previous position.</returns>
        public static Vector2 Velocity(this Vector2 current, [NotNull] GameObject previous) => current.Velocity(previous.transform.position, Time.deltaTime);
        
        /// <summary>
        /// The current velocity based on the time it took to move from a previous position.
        /// </summary>
        /// <param name="current">The current position.</param>
        /// <param name="previous">The previous position.</param>
        /// <param name="delta">The time since the last position.</param>
        /// <returns>The current speed based on the time it took to move from a previous position.</returns>
        public static Vector2 Velocity(this Vector3 current, Vector2 previous, float delta) => current.Flatten().Velocity(previous, delta);
        
        /// <summary>
        /// The current velocity based on the time it took to move from a previous position.
        /// </summary>
        /// <param name="current">The current position.</param>
        /// <param name="previous">The previous position.</param>
        /// <returns>The current speed based on the time it took to move from a previous position.</returns>
        public static Vector2 Velocity(this Vector3 current, Vector2 previous) => current.Velocity(previous, Time.deltaTime);
        
        /// <summary>
        /// The current velocity based on the time it took to move from a previous position.
        /// </summary>
        /// <param name="current">The current position.</param>
        /// <param name="previous">The previous position.</param>
        /// <param name="delta">The time since the last position.</param>
        /// <returns>The current speed based on the time it took to move from a previous position.</returns>
        public static Vector2 Velocity(this Vector3 current, Vector3 previous, float delta) => current.Flatten().Velocity(previous.Flatten(),delta);
        
        /// <summary>
        /// The current velocity based on the time it took to move from a previous position.
        /// </summary>
        /// <param name="current">The current position.</param>
        /// <param name="previous">The previous position.</param>
        /// <returns>The current speed based on the time it took to move from a previous position.</returns>
        public static Vector2 Velocity(this Vector3 current, Vector3 previous) => current.Velocity(previous, Time.deltaTime);
        
        /// <summary>
        /// The current velocity based on the time it took to move from a previous position.
        /// </summary>
        /// <param name="current">The current position.</param>
        /// <param name="previous">The previous position.</param>
        /// <param name="delta">The time since the last position.</param>
        /// <returns>The current speed based on the time it took to move from a previous position.</returns>
        public static Vector2 Velocity(this Vector3 current, [NotNull] Transform previous, float delta) => current.Velocity(previous.position, delta);
        
        /// <summary>
        /// The current velocity based on the time it took to move from a previous position.
        /// </summary>
        /// <param name="current">The current position.</param>
        /// <param name="previous">The previous position.</param>
        /// <returns>The current speed based on the time it took to move from a previous position.</returns>
        public static Vector2 Velocity(this Vector3 current, [NotNull] Transform previous) => current.Velocity(previous, Time.deltaTime);
        
        /// <summary>
        /// The current velocity based on the time it took to move from a previous position.
        /// </summary>
        /// <param name="current">The current position.</param>
        /// <param name="previous">The previous position.</param>
        /// <param name="delta">The time since the last position.</param>
        /// <returns>The current speed based on the time it took to move from a previous position.</returns>
        public static Vector2 Velocity(this Vector3 current, [NotNull] Component previous, float delta) => current.Velocity(previous.transform.position, delta);
        
        /// <summary>
        /// The current velocity based on the time it took to move from a previous position.
        /// </summary>
        /// <param name="current">The current position.</param>
        /// <param name="previous">The previous position.</param>
        /// <returns>The current speed based on the time it took to move from a previous position.</returns>
        public static Vector2 Velocity(this Vector3 current, [NotNull] Component previous) => current.Velocity(previous, Time.deltaTime);
        
        /// <summary>
        /// The current velocity based on the time it took to move from a previous position.
        /// </summary>
        /// <param name="current">The current position.</param>
        /// <param name="previous">The previous position.</param>
        /// <param name="delta">The time since the last position.</param>
        /// <returns>The current speed based on the time it took to move from a previous position.</returns>
        public static Vector2 Velocity(this Vector3 current, [NotNull] GameObject previous, float delta) => current.Velocity(previous.transform.position, delta);
        
        /// <summary>
        /// The current velocity based on the time it took to move from a previous position.
        /// </summary>
        /// <param name="current">The current position.</param>
        /// <param name="previous">The previous position.</param>
        /// <returns>The current speed based on the time it took to move from a previous position.</returns>
        public static Vector2 Velocity(this Vector3 current, [NotNull] GameObject previous) => current.Velocity(previous, Time.deltaTime);
        
        /// <summary>
        /// The current velocity based on the time it took to move from a previous position.
        /// </summary>
        /// <param name="current">The current position.</param>
        /// <param name="previous">The previous position.</param>
        /// <param name="delta">The time since the last position.</param>
        /// <returns>The current speed based on the time it took to move from a previous position.</returns>
        public static Vector2 Velocity([NotNull] this Transform current, Vector2 previous, float delta) => current.position.Velocity(previous, delta);
        
        /// <summary>
        /// The current velocity based on the time it took to move from a previous position.
        /// </summary>
        /// <param name="current">The current position.</param>
        /// <param name="previous">The previous position.</param>
        /// <returns>The current speed based on the time it took to move from a previous position.</returns>
        public static Vector2 Velocity([NotNull] this Transform current, Vector2 previous) => current.Velocity(previous, Time.deltaTime);
        
        /// <summary>
        /// The current velocity based on the time it took to move from a previous position.
        /// </summary>
        /// <param name="current">The current position.</param>
        /// <param name="previous">The previous position.</param>
        /// <param name="delta">The time since the last position.</param>
        /// <returns>The current speed based on the time it took to move from a previous position.</returns>
        public static Vector2 Velocity([NotNull] this Transform current, Vector3 previous, float delta) => current.position.Velocity(previous, delta);
        
        /// <summary>
        /// The current velocity based on the time it took to move from a previous position.
        /// </summary>
        /// <param name="current">The current position.</param>
        /// <param name="previous">The previous position.</param>
        /// <returns>The current speed based on the time it took to move from a previous position.</returns>
        public static Vector2 Velocity([NotNull] this Transform current, Vector3 previous) => current.Velocity(previous, Time.deltaTime);
        
        /// <summary>
        /// The current velocity based on the time it took to move from a previous position.
        /// </summary>
        /// <param name="current">The current position.</param>
        /// <param name="previous">The previous position.</param>
        /// <param name="delta">The time since the last position.</param>
        /// <returns>The current speed based on the time it took to move from a previous position.</returns>
        public static Vector2 Velocity([NotNull] this Transform current, [NotNull] Transform previous, float delta) => current.position.Velocity(previous.position, delta);
        
        /// <summary>
        /// The current velocity based on the time it took to move from a previous position.
        /// </summary>
        /// <param name="current">The current position.</param>
        /// <param name="previous">The previous position.</param>
        /// <returns>The current speed based on the time it took to move from a previous position.</returns>
        public static Vector2 Velocity([NotNull] this Transform current, [NotNull] Transform previous) => current.Velocity(previous, Time.deltaTime);
        
        /// <summary>
        /// The current velocity based on the time it took to move from a previous position.
        /// </summary>
        /// <param name="current">The current position.</param>
        /// <param name="previous">The previous position.</param>
        /// <param name="delta">The time since the last position.</param>
        /// <returns>The current speed based on the time it took to move from a previous position.</returns>
        public static Vector2 Velocity([NotNull] this Transform current, [NotNull] Component previous, float delta) => current.position.Velocity(previous.transform.position, delta);
        
        /// <summary>
        /// The current velocity based on the time it took to move from a previous position.
        /// </summary>
        /// <param name="current">The current position.</param>
        /// <param name="previous">The previous position.</param>
        /// <returns>The current speed based on the time it took to move from a previous position.</returns>
        public static Vector2 Velocity([NotNull] this Transform current, [NotNull] Component previous) => current.Velocity(previous, Time.deltaTime);
        
        /// <summary>
        /// The current velocity based on the time it took to move from a previous position.
        /// </summary>
        /// <param name="current">The current position.</param>
        /// <param name="previous">The previous position.</param>
        /// <param name="delta">The time since the last position.</param>
        /// <returns>The current speed based on the time it took to move from a previous position.</returns>
        public static Vector2 Velocity([NotNull] this Transform current, [NotNull] GameObject previous, float delta) => current.position.Velocity(previous.transform.position, delta);
        
        /// <summary>
        /// The current velocity based on the time it took to move from a previous position.
        /// </summary>
        /// <param name="current">The current position.</param>
        /// <param name="previous">The previous position.</param>
        /// <returns>The current speed based on the time it took to move from a previous position.</returns>
        public static Vector2 Velocity([NotNull] this Transform current, [NotNull] GameObject previous) => current.Velocity(previous, Time.deltaTime);
        
        /// <summary>
        /// The current velocity based on the time it took to move from a previous position.
        /// </summary>
        /// <param name="current">The current position.</param>
        /// <param name="previous">The previous position.</param>
        /// <param name="delta">The time since the last position.</param>
        /// <returns>The current speed based on the time it took to move from a previous position.</returns>
        public static Vector2 Velocity([NotNull] this Component current, Vector2 previous, float delta) => current.transform.position.Velocity(previous, delta);
        
        /// <summary>
        /// The current velocity based on the time it took to move from a previous position.
        /// </summary>
        /// <param name="current">The current position.</param>
        /// <param name="previous">The previous position.</param>
        /// <returns>The current speed based on the time it took to move from a previous position.</returns>
        public static Vector2 Velocity([NotNull] this Component current, Vector2 previous) => current.Velocity(previous, Time.deltaTime);
        
        /// <summary>
        /// The current velocity based on the time it took to move from a previous position.
        /// </summary>
        /// <param name="current">The current position.</param>
        /// <param name="previous">The previous position.</param>
        /// <param name="delta">The time since the last position.</param>
        /// <returns>The current speed based on the time it took to move from a previous position.</returns>
        public static Vector2 Velocity([NotNull] this Component current, Vector3 previous, float delta) => current.transform.position.Velocity(previous, delta);
        
        /// <summary>
        /// The current velocity based on the time it took to move from a previous position.
        /// </summary>
        /// <param name="current">The current position.</param>
        /// <param name="previous">The previous position.</param>
        /// <returns>The current speed based on the time it took to move from a previous position.</returns>
        public static Vector2 Velocity([NotNull] this Component current, Vector3 previous) => current.Velocity(previous, Time.deltaTime);
        
        /// <summary>
        /// The current velocity based on the time it took to move from a previous position.
        /// </summary>
        /// <param name="current">The current position.</param>
        /// <param name="previous">The previous position.</param>
        /// <param name="delta">The time since the last position.</param>
        /// <returns>The current speed based on the time it took to move from a previous position.</returns>
        public static Vector2 Velocity([NotNull] this Component current, [NotNull] Transform previous, float delta) => current.transform.position.Velocity(previous.position, delta);
        
        /// <summary>
        /// The current velocity based on the time it took to move from a previous position.
        /// </summary>
        /// <param name="current">The current position.</param>
        /// <param name="previous">The previous position.</param>
        /// <returns>The current speed based on the time it took to move from a previous position.</returns>
        public static Vector2 Velocity([NotNull] this Component current, [NotNull] Transform previous) => current.Velocity(previous, Time.deltaTime);
        
        /// <summary>
        /// The current velocity based on the time it took to move from a previous position.
        /// </summary>
        /// <param name="current">The current position.</param>
        /// <param name="previous">The previous position.</param>
        /// <param name="delta">The time since the last position.</param>
        /// <returns>The current speed based on the time it took to move from a previous position.</returns>
        public static Vector2 Velocity([NotNull] this Component current, [NotNull] Component previous, float delta) => current.transform.position.Velocity(previous.transform.position, delta);
        
        /// <summary>
        /// The current velocity based on the time it took to move from a previous position.
        /// </summary>
        /// <param name="current">The current position.</param>
        /// <param name="previous">The previous position.</param>
        /// <returns>The current speed based on the time it took to move from a previous position.</returns>
        public static Vector2 Velocity([NotNull] this Component current, [NotNull] Component previous) => current.Velocity(previous, Time.deltaTime);
        
        /// <summary>
        /// The current velocity based on the time it took to move from a previous position.
        /// </summary>
        /// <param name="current">The current position.</param>
        /// <param name="previous">The previous position.</param>
        /// <param name="delta">The time since the last position.</param>
        /// <returns>The current speed based on the time it took to move from a previous position.</returns>
        public static Vector2 Velocity([NotNull] this Component current, [NotNull] GameObject previous, float delta) => current.transform.position.Velocity(previous.transform.position, delta);
        
        /// <summary>
        /// The current velocity based on the time it took to move from a previous position.
        /// </summary>
        /// <param name="current">The current position.</param>
        /// <param name="previous">The previous position.</param>
        /// <returns>The current speed based on the time it took to move from a previous position.</returns>
        public static Vector2 Velocity([NotNull] this Component current, [NotNull] GameObject previous) => current.Velocity(previous, Time.deltaTime);
        
        /// <summary>
        /// The current velocity based on the time it took to move from a previous position.
        /// </summary>
        /// <param name="current">The current position.</param>
        /// <param name="previous">The previous position.</param>
        /// <param name="delta">The time since the last position.</param>
        /// <returns>The current speed based on the time it took to move from a previous position.</returns>
        public static Vector2 Velocity([NotNull] this GameObject current, Vector2 previous, float delta) => current.transform.position.Velocity(previous, delta);
        
        /// <summary>
        /// The current velocity based on the time it took to move from a previous position.
        /// </summary>
        /// <param name="current">The current position.</param>
        /// <param name="previous">The previous position.</param>
        /// <returns>The current speed based on the time it took to move from a previous position.</returns>
        public static Vector2 Velocity([NotNull] this GameObject current, Vector2 previous) => current.Velocity(previous, Time.deltaTime);
        
        /// <summary>
        /// The current velocity based on the time it took to move from a previous position.
        /// </summary>
        /// <param name="current">The current position.</param>
        /// <param name="previous">The previous position.</param>
        /// <param name="delta">The time since the last position.</param>
        /// <returns>The current speed based on the time it took to move from a previous position.</returns>
        public static Vector2 Velocity([NotNull] this GameObject current, Vector3 previous, float delta) => current.transform.position.Velocity(previous, delta);
        
        /// <summary>
        /// The current velocity based on the time it took to move from a previous position.
        /// </summary>
        /// <param name="current">The current position.</param>
        /// <param name="previous">The previous position.</param>
        /// <returns>The current speed based on the time it took to move from a previous position.</returns>
        public static Vector2 Velocity([NotNull] this GameObject current, Vector3 previous) => current.Velocity(previous, Time.deltaTime);
        
        /// <summary>
        /// The current velocity based on the time it took to move from a previous position.
        /// </summary>
        /// <param name="current">The current position.</param>
        /// <param name="previous">The previous position.</param>
        /// <param name="delta">The time since the last position.</param>
        /// <returns>The current speed based on the time it took to move from a previous position.</returns>
        public static Vector2 Velocity([NotNull] this GameObject current, [NotNull] Transform previous, float delta) => current.transform.position.Velocity(previous.position, delta);
        
        /// <summary>
        /// The current velocity based on the time it took to move from a previous position.
        /// </summary>
        /// <param name="current">The current position.</param>
        /// <param name="previous">The previous position.</param>
        /// <returns>The current speed based on the time it took to move from a previous position.</returns>
        public static Vector2 Velocity([NotNull] this GameObject current, [NotNull] Transform previous) => current.Velocity(previous, Time.deltaTime);
        
        /// <summary>
        /// The current velocity based on the time it took to move from a previous position.
        /// </summary>
        /// <param name="current">The current position.</param>
        /// <param name="previous">The previous position.</param>
        /// <param name="delta">The time since the last position.</param>
        /// <returns>The current speed based on the time it took to move from a previous position.</returns>
        public static Vector2 Velocity([NotNull] this GameObject current, [NotNull] Component previous, float delta) => current.transform.position.Velocity(previous.transform.position, delta);
        
        /// <summary>
        /// The current velocity based on the time it took to move from a previous position.
        /// </summary>
        /// <param name="current">The current position.</param>
        /// <param name="previous">The previous position.</param>
        /// <returns>The current speed based on the time it took to move from a previous position.</returns>
        public static Vector2 Velocity([NotNull] this GameObject current, [NotNull] Component previous) => current.Velocity(previous, Time.deltaTime);
        
        /// <summary>
        /// The current velocity based on the time it took to move from a previous position.
        /// </summary>
        /// <param name="current">The current position.</param>
        /// <param name="previous">The previous position.</param>
        /// <param name="delta">The time since the last position.</param>
        /// <returns>The current speed based on the time it took to move from a previous position.</returns>
        public static Vector2 Velocity([NotNull] this GameObject current, [NotNull] GameObject previous, float delta) => current.transform.position.Velocity(previous.transform.position, delta);
        
        /// <summary>
        /// The current velocity based on the time it took to move from a previous position.
        /// </summary>
        /// <param name="current">The current position.</param>
        /// <param name="previous">The previous position.</param>
        /// <returns>The current speed based on the time it took to move from a previous position.</returns>
        public static Vector2 Velocity([NotNull] this GameObject current, [NotNull] GameObject previous) => current.Velocity(previous, Time.deltaTime);
        
        /// <summary>
        /// The current velocity based on the time it took to move from a previous position.
        /// </summary>
        /// <param name="current">The current position.</param>
        /// <param name="previous">The previous position.</param>
        /// <param name="delta">The time since the last position.</param>
        /// <returns>The current speed based on the time it took to move from a previous position.</returns>
        public static Vector3 Velocity3(this Vector3 current, Vector3 previous, float delta) => current.Direction3(previous) / delta;
        
        /// <summary>
        /// The current velocity based on the time it took to move from a previous position.
        /// </summary>
        /// <param name="current">The current position.</param>
        /// <param name="previous">The previous position.</param>
        /// <returns>The current speed based on the time it took to move from a previous position.</returns>
        public static Vector3 Velocity3(this Vector3 current, Vector3 previous) => current.Velocity3(previous, Time.deltaTime);
        
        /// <summary>
        /// The current velocity based on the time it took to move from a previous position.
        /// </summary>
        /// <param name="current">The current position.</param>
        /// <param name="previous">The previous position.</param>
        /// <param name="delta">The time since the last position.</param>
        /// <returns>The current speed based on the time it took to move from a previous position.</returns>
        public static Vector3 Velocity3(this Vector3 current, [NotNull] Transform previous, float delta) => current.Velocity3(previous.position, delta);
        
        /// <summary>
        /// The current velocity based on the time it took to move from a previous position.
        /// </summary>
        /// <param name="current">The current position.</param>
        /// <param name="previous">The previous position.</param>
        /// <returns>The current speed based on the time it took to move from a previous position.</returns>
        public static Vector3 Velocity3(this Vector3 current, [NotNull] Transform previous) => current.Velocity3(previous, Time.deltaTime);
        
        /// <summary>
        /// The current velocity based on the time it took to move from a previous position.
        /// </summary>
        /// <param name="current">The current position.</param>
        /// <param name="previous">The previous position.</param>
        /// <param name="delta">The time since the last position.</param>
        /// <returns>The current speed based on the time it took to move from a previous position.</returns>
        public static Vector3 Velocity3(this Vector3 current, [NotNull] Component previous, float delta) => current.Velocity3(previous.transform.position, delta);
        
        /// <summary>
        /// The current velocity based on the time it took to move from a previous position.
        /// </summary>
        /// <param name="current">The current position.</param>
        /// <param name="previous">The previous position.</param>
        /// <returns>The current speed based on the time it took to move from a previous position.</returns>
        public static Vector3 Velocity3(this Vector3 current, [NotNull] Component previous) => current.Velocity3(previous, Time.deltaTime);
        
        /// <summary>
        /// The current velocity based on the time it took to move from a previous position.
        /// </summary>
        /// <param name="current">The current position.</param>
        /// <param name="previous">The previous position.</param>
        /// <param name="delta">The time since the last position.</param>
        /// <returns>The current speed based on the time it took to move from a previous position.</returns>
        public static Vector3 Velocity3(this Vector3 current, [NotNull] GameObject previous, float delta) => current.Velocity3(previous.transform.position, delta);
        
        /// <summary>
        /// The current velocity based on the time it took to move from a previous position.
        /// </summary>
        /// <param name="current">The current position.</param>
        /// <param name="previous">The previous position.</param>
        /// <returns>The current speed based on the time it took to move from a previous position.</returns>
        public static Vector3 Velocity3(this Vector3 current, [NotNull] GameObject previous) => current.Velocity3(previous, Time.deltaTime);
        
        /// <summary>
        /// The current velocity based on the time it took to move from a previous position.
        /// </summary>
        /// <param name="current">The current position.</param>
        /// <param name="previous">The previous position.</param>
        /// <param name="delta">The time since the last position.</param>
        /// <returns>The current speed based on the time it took to move from a previous position.</returns>
        public static Vector3 Velocity3([NotNull] this Transform current, Vector3 previous, float delta) => current.position.Velocity3(previous, delta);
        
        /// <summary>
        /// The current velocity based on the time it took to move from a previous position.
        /// </summary>
        /// <param name="current">The current position.</param>
        /// <param name="previous">The previous position.</param>
        /// <returns>The current speed based on the time it took to move from a previous position.</returns>
        public static Vector3 Velocity3([NotNull] this Transform current, Vector3 previous) => current.Velocity3(previous, Time.deltaTime);
        
        /// <summary>
        /// The current velocity based on the time it took to move from a previous position.
        /// </summary>
        /// <param name="current">The current position.</param>
        /// <param name="previous">The previous position.</param>
        /// <param name="delta">The time since the last position.</param>
        /// <returns>The current speed based on the time it took to move from a previous position.</returns>
        public static Vector3 Velocity3([NotNull] this Transform current, [NotNull] Transform previous, float delta) => current.position.Velocity3(previous.position, delta);
        
        /// <summary>
        /// The current velocity based on the time it took to move from a previous position.
        /// </summary>
        /// <param name="current">The current position.</param>
        /// <param name="previous">The previous position.</param>
        /// <returns>The current speed based on the time it took to move from a previous position.</returns>
        public static Vector3 Velocity3([NotNull] this Transform current, [NotNull] Transform previous) => current.Velocity3(previous, Time.deltaTime);
        
        /// <summary>
        /// The current velocity based on the time it took to move from a previous position.
        /// </summary>
        /// <param name="current">The current position.</param>
        /// <param name="previous">The previous position.</param>
        /// <param name="delta">The time since the last position.</param>
        /// <returns>The current speed based on the time it took to move from a previous position.</returns>
        public static Vector3 Velocity3([NotNull] this Transform current, [NotNull] Component previous, float delta) => current.position.Velocity3(previous.transform.position, delta);
        
        /// <summary>
        /// The current velocity based on the time it took to move from a previous position.
        /// </summary>
        /// <param name="current">The current position.</param>
        /// <param name="previous">The previous position.</param>
        /// <returns>The current speed based on the time it took to move from a previous position.</returns>
        public static Vector3 Velocity3([NotNull] this Transform current, [NotNull] Component previous) => current.Velocity3(previous, Time.deltaTime);
        
        /// <summary>
        /// The current velocity based on the time it took to move from a previous position.
        /// </summary>
        /// <param name="current">The current position.</param>
        /// <param name="previous">The previous position.</param>
        /// <param name="delta">The time since the last position.</param>
        /// <returns>The current speed based on the time it took to move from a previous position.</returns>
        public static Vector3 Velocity3([NotNull] this Transform current, [NotNull] GameObject previous, float delta) => current.position.Velocity3(previous.transform.position, delta);
        
        /// <summary>
        /// The current velocity based on the time it took to move from a previous position.
        /// </summary>
        /// <param name="current">The current position.</param>
        /// <param name="previous">The previous position.</param>
        /// <returns>The current speed based on the time it took to move from a previous position.</returns>
        public static Vector3 Velocity3([NotNull] this Transform current, [NotNull] GameObject previous) => current.Velocity3(previous, Time.deltaTime);
        
        /// <summary>
        /// The current velocity based on the time it took to move from a previous position.
        /// </summary>
        /// <param name="current">The current position.</param>
        /// <param name="previous">The previous position.</param>
        /// <param name="delta">The time since the last position.</param>
        /// <returns>The current speed based on the time it took to move from a previous position.</returns>
        public static Vector3 Velocity3([NotNull] this Component current, Vector3 previous, float delta) => current.transform.position.Velocity3(previous, delta);
        
        /// <summary>
        /// The current velocity based on the time it took to move from a previous position.
        /// </summary>
        /// <param name="current">The current position.</param>
        /// <param name="previous">The previous position.</param>
        /// <returns>The current speed based on the time it took to move from a previous position.</returns>
        public static Vector3 Velocity3([NotNull] this Component current, Vector3 previous) => current.Velocity3(previous, Time.deltaTime);
        
        /// <summary>
        /// The current velocity based on the time it took to move from a previous position.
        /// </summary>
        /// <param name="current">The current position.</param>
        /// <param name="previous">The previous position.</param>
        /// <param name="delta">The time since the last position.</param>
        /// <returns>The current speed based on the time it took to move from a previous position.</returns>
        public static Vector3 Velocity3([NotNull] this Component current, [NotNull] Transform previous, float delta) => current.transform.position.Velocity3(previous.position, delta);
        
        /// <summary>
        /// The current velocity based on the time it took to move from a previous position.
        /// </summary>
        /// <param name="current">The current position.</param>
        /// <param name="previous">The previous position.</param>
        /// <returns>The current speed based on the time it took to move from a previous position.</returns>
        public static Vector3 Velocity3([NotNull] this Component current, [NotNull] Transform previous) => current.Velocity3(previous, Time.deltaTime);
        
        /// <summary>
        /// The current velocity based on the time it took to move from a previous position.
        /// </summary>
        /// <param name="current">The current position.</param>
        /// <param name="previous">The previous position.</param>
        /// <param name="delta">The time since the last position.</param>
        /// <returns>The current speed based on the time it took to move from a previous position.</returns>
        public static Vector3 Velocity3([NotNull] this Component current, [NotNull] Component previous, float delta) => current.transform.position.Velocity3(previous.transform.position, delta);
        
        /// <summary>
        /// The current velocity based on the time it took to move from a previous position.
        /// </summary>
        /// <param name="current">The current position.</param>
        /// <param name="previous">The previous position.</param>
        /// <returns>The current speed based on the time it took to move from a previous position.</returns>
        public static Vector3 Velocity3([NotNull] this Component current, [NotNull] Component previous) => current.Velocity3(previous, Time.deltaTime);
        
        /// <summary>
        /// The current velocity based on the time it took to move from a previous position.
        /// </summary>
        /// <param name="current">The current position.</param>
        /// <param name="previous">The previous position.</param>
        /// <param name="delta">The time since the last position.</param>
        /// <returns>The current speed based on the time it took to move from a previous position.</returns>
        public static Vector3 Velocity3([NotNull] this Component current, [NotNull] GameObject previous, float delta) => current.transform.position.Velocity3(previous.transform.position, delta);
        
        /// <summary>
        /// The current velocity based on the time it took to move from a previous position.
        /// </summary>
        /// <param name="current">The current position.</param>
        /// <param name="previous">The previous position.</param>
        /// <returns>The current speed based on the time it took to move from a previous position.</returns>
        public static Vector3 Velocity3([NotNull] this Component current, [NotNull] GameObject previous) => current.Velocity3(previous, Time.deltaTime);
        
        /// <summary>
        /// The current velocity based on the time it took to move from a previous position.
        /// </summary>
        /// <param name="current">The current position.</param>
        /// <param name="previous">The previous position.</param>
        /// <param name="delta">The time since the last position.</param>
        /// <returns>The current speed based on the time it took to move from a previous position.</returns>
        public static Vector3 Velocity3([NotNull] this GameObject current, Vector3 previous, float delta) => current.transform.position.Velocity3(previous, delta);
        
        /// <summary>
        /// The current velocity based on the time it took to move from a previous position.
        /// </summary>
        /// <param name="current">The current position.</param>
        /// <param name="previous">The previous position.</param>
        /// <returns>The current speed based on the time it took to move from a previous position.</returns>
        public static Vector3 Velocity3([NotNull] this GameObject current, Vector3 previous) => current.Velocity3(previous, Time.deltaTime);
        
        /// <summary>
        /// The current velocity based on the time it took to move from a previous position.
        /// </summary>
        /// <param name="current">The current position.</param>
        /// <param name="previous">The previous position.</param>
        /// <param name="delta">The time since the last position.</param>
        /// <returns>The current speed based on the time it took to move from a previous position.</returns>
        public static Vector3 Velocity3([NotNull] this GameObject current, [NotNull] Transform previous, float delta) => current.transform.position.Velocity3(previous.position, delta);
        
        /// <summary>
        /// The current velocity based on the time it took to move from a previous position.
        /// </summary>
        /// <param name="current">The current position.</param>
        /// <param name="previous">The previous position.</param>
        /// <returns>The current speed based on the time it took to move from a previous position.</returns>
        public static Vector3 Velocity3([NotNull] this GameObject current, [NotNull] Transform previous) => current.Velocity3(previous, Time.deltaTime);
        
        /// <summary>
        /// The current velocity based on the time it took to move from a previous position.
        /// </summary>
        /// <param name="current">The current position.</param>
        /// <param name="previous">The previous position.</param>
        /// <param name="delta">The time since the last position.</param>
        /// <returns>The current speed based on the time it took to move from a previous position.</returns>
        public static Vector3 Velocity3([NotNull] this GameObject current, [NotNull] Component previous, float delta) => current.transform.position.Velocity3(previous.transform.position, delta);
        
        /// <summary>
        /// The current velocity based on the time it took to move from a previous position.
        /// </summary>
        /// <param name="current">The current position.</param>
        /// <param name="previous">The previous position.</param>
        /// <returns>The current speed based on the time it took to move from a previous position.</returns>
        public static Vector3 Velocity3([NotNull] this GameObject current, [NotNull] Component previous) => current.Velocity3(previous, Time.deltaTime);
        
        /// <summary>
        /// The current velocity based on the time it took to move from a previous position.
        /// </summary>
        /// <param name="current">The current position.</param>
        /// <param name="previous">The previous position.</param>
        /// <param name="delta">The time since the last position.</param>
        /// <returns>The current speed based on the time it took to move from a previous position.</returns>
        public static Vector3 Velocity3([NotNull] this GameObject current, [NotNull] GameObject previous, float delta) => current.transform.position.Velocity3(previous.transform.position, delta);
        
        /// <summary>
        /// The current velocity based on the time it took to move from a previous position.
        /// </summary>
        /// <param name="current">The current position.</param>
        /// <param name="previous">The previous position.</param>
        /// <returns>The current speed based on the time it took to move from a previous position.</returns>
        public static Vector3 Velocity3([NotNull] this GameObject current, [NotNull] GameObject previous) => current.Velocity3(previous, Time.deltaTime);
        
        /// <summary>
        /// If a target is within the field of view. This does not consider vertical field of view.
        /// </summary>
        /// <param name="position">The position to check field of view from.</param>
        /// <param name="forward">The forward direction to start the field of view check from.</param>
        /// <param name="target">The target position to check if it is within the field of view.</param>
        /// <param name="fov">The field of view in degrees.</param>
        /// <returns>If a target is within the field of view.</returns>
        public static bool InView(this Vector2 position, Vector2 forward, Vector2 target, float fov)
        {
            // Get the direction vector.
            Vector2 directionToTarget = target.Direction(position);
            
            // Early exit if vectors are too small to avoid NaN errors on normalize. Calculate Dot product using the normalized vectors and see if it is in range.
            return forward.sqrMagnitude >= Mathf.Epsilon && directionToTarget.sqrMagnitude >= Mathf.Epsilon && Vector2.Dot(forward.normalized, directionToTarget.normalized) >= Mathf.Cos(fov / 2.0f * Mathf.Deg2Rad);
        }
        
        /// <summary>
        /// If a target is within the field of view. This does not consider vertical field of view.
        /// </summary>
        /// <param name="position">The position to check field of view from.</param>
        /// <param name="forward">The forward direction to start the field of view check from.</param>
        /// <param name="target">The target position to check if it is within the field of view.</param>
        /// <param name="fov">The field of view in degrees.</param>
        /// <returns>If a target is within the field of view.</returns>
        public static bool InView(this Vector2 position, Vector2 forward, Vector3 target, float fov) => position.InView(forward, target.Flatten(), fov);
        
        /// <summary>
        /// If a target is within the field of view. This does not consider vertical field of view.
        /// </summary>
        /// <param name="position">The position to check field of view from.</param>
        /// <param name="forward">The forward direction to start the field of view check from.</param>
        /// <param name="target">The target position to check if it is within the field of view.</param>
        /// <param name="fov">The field of view in degrees.</param>
        /// <returns>If a target is within the field of view.</returns>
        public static bool InView(this Vector2 position, Vector2 forward, [NotNull] Transform target, float fov) => position.InView(forward, target.position, fov);
        
        /// <summary>
        /// If a target is within the field of view. This does not consider vertical field of view.
        /// </summary>
        /// <param name="position">The position to check field of view from.</param>
        /// <param name="forward">The forward direction to start the field of view check from.</param>
        /// <param name="target">The target position to check if it is within the field of view.</param>
        /// <param name="fov">The field of view in degrees.</param>
        /// <returns>If a target is within the field of view.</returns>
        public static bool InView(this Vector2 position, Vector2 forward, [NotNull] Component target, float fov) => position.InView(forward, target.transform.position, fov);
        
        /// <summary>
        /// If a target is within the field of view. This does not consider vertical field of view.
        /// </summary>
        /// <param name="position">The position to check field of view from.</param>
        /// <param name="forward">The forward direction to start the field of view check from.</param>
        /// <param name="target">The target position to check if it is within the field of view.</param>
        /// <param name="fov">The field of view in degrees.</param>
        /// <returns>If a target is within the field of view.</returns>
        public static bool InView(this Vector2 position, Vector2 forward, [NotNull] GameObject target, float fov) => position.InView(forward, target.transform.position, fov);
        
        /// <summary>
        /// If a target is within the field of view. This does not consider vertical field of view.
        /// </summary>
        /// <param name="position">The position to check field of view from.</param>
        /// <param name="forward">The forward direction to start the field of view check from.</param>
        /// <param name="target">The target position to check if it is within the field of view.</param>
        /// <param name="fov">The field of view in degrees.</param>
        /// <returns>If a target is within the field of view.</returns>
        public static bool InView(this Vector2 position, Vector3 forward, Vector2 target, float fov) => position.InView(forward.Flatten(), target, fov);
        
        /// <summary>
        /// If a target is within the field of view. This does not consider vertical field of view.
        /// </summary>
        /// <param name="position">The position to check field of view from.</param>
        /// <param name="forward">The forward direction to start the field of view check from.</param>
        /// <param name="target">The target position to check if it is within the field of view.</param>
        /// <param name="fov">The field of view in degrees.</param>
        /// <returns>If a target is within the field of view.</returns>
        public static bool InView(this Vector2 position, Vector3 forward, Vector3 target, float fov) => position.InView(forward.Flatten(), target.Flatten(), fov);
        
        /// <summary>
        /// If a target is within the field of view. This does not consider vertical field of view.
        /// </summary>
        /// <param name="position">The position to check field of view from.</param>
        /// <param name="forward">The forward direction to start the field of view check from.</param>
        /// <param name="target">The target position to check if it is within the field of view.</param>
        /// <param name="fov">The field of view in degrees.</param>
        /// <returns>If a target is within the field of view.</returns>
        public static bool InView(this Vector2 position, Vector3 forward, [NotNull] Transform target, float fov) => position.InView(forward, target.position, fov);
        
        /// <summary>
        /// If a target is within the field of view. This does not consider vertical field of view.
        /// </summary>
        /// <param name="position">The position to check field of view from.</param>
        /// <param name="forward">The forward direction to start the field of view check from.</param>
        /// <param name="target">The target position to check if it is within the field of view.</param>
        /// <param name="fov">The field of view in degrees.</param>
        /// <returns>If a target is within the field of view.</returns>
        public static bool InView(this Vector2 position, Vector3 forward, [NotNull] Component target, float fov) => position.InView(forward, target.transform.position, fov);
        
        /// <summary>
        /// If a target is within the field of view. This does not consider vertical field of view.
        /// </summary>
        /// <param name="position">The position to check field of view from.</param>
        /// <param name="forward">The forward direction to start the field of view check from.</param>
        /// <param name="target">The target position to check if it is within the field of view.</param>
        /// <param name="fov">The field of view in degrees.</param>
        /// <returns>If a target is within the field of view.</returns>
        public static bool InView(this Vector2 position, Vector3 forward, [NotNull] GameObject target, float fov) => position.InView(forward, target.transform.position, fov);
        
        /// <summary>
        /// If a target is within the field of view. This does not consider vertical field of view.
        /// </summary>
        /// <param name="position">The position to check field of view from.</param>
        /// <param name="forward">The forward direction to start the field of view check from.</param>
        /// <param name="target">The target position to check if it is within the field of view.</param>
        /// <param name="fov">The field of view in degrees.</param>
        /// <returns>If a target is within the field of view.</returns>
        public static bool InView(this Vector3 position, Vector2 forward, Vector2 target, float fov) => position.Flatten().InView(forward, target, fov);
        
        /// <summary>
        /// If a target is within the field of view. This does not consider vertical field of view.
        /// </summary>
        /// <param name="position">The position to check field of view from.</param>
        /// <param name="forward">The forward direction to start the field of view check from.</param>
        /// <param name="target">The target position to check if it is within the field of view.</param>
        /// <param name="fov">The field of view in degrees.</param>
        /// <returns>If a target is within the field of view.</returns>
        public static bool InView(this Vector3 position, Vector2 forward, Vector3 target, float fov) => position.Flatten().InView(forward, target, fov);
        
        /// <summary>
        /// If a target is within the field of view. This does not consider vertical field of view.
        /// </summary>
        /// <param name="position">The position to check field of view from.</param>
        /// <param name="forward">The forward direction to start the field of view check from.</param>
        /// <param name="target">The target position to check if it is within the field of view.</param>
        /// <param name="fov">The field of view in degrees.</param>
        /// <returns>If a target is within the field of view.</returns>
        public static bool InView(this Vector3 position, Vector2 forward, [NotNull] Transform target, float fov) => position.InView(forward, target.position, fov);
        
        /// <summary>
        /// If a target is within the field of view. This does not consider vertical field of view.
        /// </summary>
        /// <param name="position">The position to check field of view from.</param>
        /// <param name="forward">The forward direction to start the field of view check from.</param>
        /// <param name="target">The target position to check if it is within the field of view.</param>
        /// <param name="fov">The field of view in degrees.</param>
        /// <returns>If a target is within the field of view.</returns>
        public static bool InView(this Vector3 position, Vector2 forward, [NotNull] Component target, float fov) => position.InView(forward, target.transform.position, fov);
        
        /// <summary>
        /// If a target is within the field of view. This does not consider vertical field of view.
        /// </summary>
        /// <param name="position">The position to check field of view from.</param>
        /// <param name="forward">The forward direction to start the field of view check from.</param>
        /// <param name="target">The target position to check if it is within the field of view.</param>
        /// <param name="fov">The field of view in degrees.</param>
        /// <returns>If a target is within the field of view.</returns>
        public static bool InView(this Vector3 position, Vector2 forward, [NotNull] GameObject target, float fov) => position.InView(forward, target.transform.position, fov);
        
        /// <summary>
        /// If a target is within the field of view. This does not consider vertical field of view.
        /// </summary>
        /// <param name="position">The position to check field of view from.</param>
        /// <param name="forward">The forward direction to start the field of view check from.</param>
        /// <param name="target">The target position to check if it is within the field of view.</param>
        /// <param name="fov">The field of view in degrees.</param>
        /// <returns>If a target is within the field of view.</returns>
        public static bool InView(this Vector3 position, Vector3 forward, Vector2 target, float fov) => position.Flatten().InView(forward, target, fov);
        
        /// <summary>
        /// If a target is within the field of view. This does not consider vertical field of view.
        /// </summary>
        /// <param name="position">The position to check field of view from.</param>
        /// <param name="forward">The forward direction to start the field of view check from.</param>
        /// <param name="target">The target position to check if it is within the field of view.</param>
        /// <param name="fov">The field of view in degrees.</param>
        /// <returns>If a target is within the field of view.</returns>
        public static bool InView(this Vector3 position, Vector3 forward, Vector3 target, float fov) => position.Flatten().InView(forward, target, fov);
        
        /// <summary>
        /// If a target is within the field of view. This does not consider vertical field of view.
        /// </summary>
        /// <param name="position">The position to check field of view from.</param>
        /// <param name="forward">The forward direction to start the field of view check from.</param>
        /// <param name="target">The target position to check if it is within the field of view.</param>
        /// <param name="fov">The field of view in degrees.</param>
        /// <returns>If a target is within the field of view.</returns>
        public static bool InView(this Vector3 position, Vector3 forward, [NotNull] Transform target, float fov) => position.InView(forward, target.position, fov);
        
        /// <summary>
        /// If a target is within the field of view. This does not consider vertical field of view.
        /// </summary>
        /// <param name="position">The position to check field of view from.</param>
        /// <param name="forward">The forward direction to start the field of view check from.</param>
        /// <param name="target">The target position to check if it is within the field of view.</param>
        /// <param name="fov">The field of view in degrees.</param>
        /// <returns>If a target is within the field of view.</returns>
        public static bool InView(this Vector3 position, Vector3 forward, [NotNull] Component target, float fov) => position.InView(forward, target.transform.position, fov);
        
        /// <summary>
        /// If a target is within the field of view. This does not consider vertical field of view.
        /// </summary>
        /// <param name="position">The position to check field of view from.</param>
        /// <param name="forward">The forward direction to start the field of view check from.</param>
        /// <param name="target">The target position to check if it is within the field of view.</param>
        /// <param name="fov">The field of view in degrees.</param>
        /// <returns>If a target is within the field of view.</returns>
        public static bool InView(this Vector3 position, Vector3 forward, [NotNull] GameObject target, float fov) => position.InView(forward, target.transform.position, fov);
        
        /// <summary>
        /// If a target is within the field of view. This does not consider vertical field of view.
        /// </summary>
        /// <param name="position">The position to check field of view from relative to its forward.</param>
        /// <param name="target">The target position to check if it is within the field of view.</param>
        /// <param name="fov">The field of view in degrees.</param>
        /// <returns>If a target is within the field of view.</returns>
        public static bool InView([NotNull] this Transform position, Vector2 target, float fov) => position.position.InView(position.forward, target, fov);
        
        /// <summary>
        /// If a target is within the field of view. This does not consider vertical field of view.
        /// </summary>
        /// <param name="position">The position to check field of view from relative to its forward.</param>
        /// <param name="target">The target position to check if it is within the field of view.</param>
        /// <param name="fov">The field of view in degrees.</param>
        /// <returns>If a target is within the field of view.</returns>
        public static bool InView([NotNull] this Transform position, Vector3 target, float fov) => position.position.InView(position.forward, target, fov);
        
        /// <summary>
        /// If a target is within the field of view. This does not consider vertical field of view.
        /// </summary>
        /// <param name="position">The position to check field of view from relative to its forward.</param>
        /// <param name="target">The target position to check if it is within the field of view.</param>
        /// <param name="fov">The field of view in degrees.</param>
        /// <returns>If a target is within the field of view.</returns>
        public static bool InView([NotNull] this Transform position, [NotNull] Transform target, float fov) => position.position.InView(position.forward, target.position, fov);
        
        /// <summary>
        /// If a target is within the field of view. This does not consider vertical field of view.
        /// </summary>
        /// <param name="position">The position to check field of view from relative to its forward.</param>
        /// <param name="target">The target position to check if it is within the field of view.</param>
        /// <param name="fov">The field of view in degrees.</param>
        /// <returns>If a target is within the field of view.</returns>
        public static bool InView([NotNull] this Transform position, [NotNull] Component target, float fov) => position.position.InView(position.forward, target.transform.position, fov);
        
        /// <summary>
        /// If a target is within the field of view. This does not consider vertical field of view.
        /// </summary>
        /// <param name="position">The position to check field of view from relative to its forward.</param>
        /// <param name="target">The target position to check if it is within the field of view.</param>
        /// <param name="fov">The field of view in degrees.</param>
        /// <returns>If a target is within the field of view.</returns>
        public static bool InView([NotNull] this Transform position, [NotNull] GameObject target, float fov) => position.position.InView(position.forward, target.transform.position, fov);
        
        /// <summary>
        /// If a target is within the field of view. This does not consider vertical field of view.
        /// </summary>
        /// <param name="position">The position to check field of view from relative to its forward.</param>
        /// <param name="target">The target position to check if it is within the field of view.</param>
        /// <param name="fov">The field of view in degrees.</param>
        /// <returns>If a target is within the field of view.</returns>
        public static bool InView([NotNull] this Component position, Vector2 target, float fov) => position.transform.position.InView(position.transform.forward, target, fov);
        
        /// <summary>
        /// If a target is within the field of view. This does not consider vertical field of view.
        /// </summary>
        /// <param name="position">The position to check field of view from relative to its forward.</param>
        /// <param name="target">The target position to check if it is within the field of view.</param>
        /// <param name="fov">The field of view in degrees.</param>
        /// <returns>If a target is within the field of view.</returns>
        public static bool InView([NotNull] this Component position, Vector3 target, float fov) => position.transform.position.InView(position.transform.forward, target, fov);
        
        /// <summary>
        /// If a target is within the field of view. This does not consider vertical field of view.
        /// </summary>
        /// <param name="position">The position to check field of view from relative to its forward.</param>
        /// <param name="target">The target position to check if it is within the field of view.</param>
        /// <param name="fov">The field of view in degrees.</param>
        /// <returns>If a target is within the field of view.</returns>
        public static bool InView([NotNull] this Component position, [NotNull] Transform target, float fov) => position.transform.position.InView(position.transform.forward, target.position, fov);
        
        /// <summary>
        /// If a target is within the field of view. This does not consider vertical field of view.
        /// </summary>
        /// <param name="position">The position to check field of view from relative to its forward.</param>
        /// <param name="target">The target position to check if it is within the field of view.</param>
        /// <param name="fov">The field of view in degrees.</param>
        /// <returns>If a target is within the field of view.</returns>
        public static bool InView([NotNull] this Component position, [NotNull] Component target, float fov) => position.transform.position.InView(position.transform.forward, target.transform.position, fov);
        
        /// <summary>
        /// If a target is within the field of view. This does not consider vertical field of view.
        /// </summary>
        /// <param name="position">The position to check field of view from relative to its forward.</param>
        /// <param name="target">The target position to check if it is within the field of view.</param>
        /// <param name="fov">The field of view in degrees.</param>
        /// <returns>If a target is within the field of view.</returns>
        public static bool InView([NotNull] this Component position, [NotNull] GameObject target, float fov) => position.transform.position.InView(position.transform.forward, target.transform.position, fov);
        
        /// <summary>
        /// If a target is within the field of view. This does not consider vertical field of view.
        /// </summary>
        /// <param name="position">The position to check field of view from relative to its forward.</param>
        /// <param name="target">The target position to check if it is within the field of view.</param>
        /// <param name="fov">The field of view in degrees.</param>
        /// <returns>If a target is within the field of view.</returns>
        public static bool InView([NotNull] this GameObject position, Vector2 target, float fov) => position.transform.position.InView(position.transform.forward, target, fov);
        
        /// <summary>
        /// If a target is within the field of view. This does not consider vertical field of view.
        /// </summary>
        /// <param name="position">The position to check field of view from relative to its forward.</param>
        /// <param name="target">The target position to check if it is within the field of view.</param>
        /// <param name="fov">The field of view in degrees.</param>
        /// <returns>If a target is within the field of view.</returns>
        public static bool InView([NotNull] this GameObject position, Vector3 target, float fov) => position.transform.position.InView(position.transform.forward, target, fov);
        
        /// <summary>
        /// If a target is within the field of view. This does not consider vertical field of view.
        /// </summary>
        /// <param name="position">The position to check field of view from relative to its forward.</param>
        /// <param name="target">The target position to check if it is within the field of view.</param>
        /// <param name="fov">The field of view in degrees.</param>
        /// <returns>If a target is within the field of view.</returns>
        public static bool InView([NotNull] this GameObject position, [NotNull] Transform target, float fov) => position.transform.position.InView(position.transform.forward, target.position, fov);
        
        /// <summary>
        /// If a target is within the field of view. This does not consider vertical field of view.
        /// </summary>
        /// <param name="position">The position to check field of view from relative to its forward.</param>
        /// <param name="target">The target position to check if it is within the field of view.</param>
        /// <param name="fov">The field of view in degrees.</param>
        /// <returns>If a target is within the field of view.</returns>
        public static bool InView([NotNull] this GameObject position, [NotNull] Component target, float fov) => position.transform.position.InView(position.transform.forward, target.transform.position, fov);
        
        /// <summary>
        /// If a target is within the field of view. This does not consider vertical field of view.
        /// </summary>
        /// <param name="position">The position to check field of view from relative to its forward.</param>
        /// <param name="target">The target position to check if it is within the field of view.</param>
        /// <param name="fov">The field of view in degrees.</param>
        /// <returns>If a target is within the field of view.</returns>
        public static bool InView([NotNull] this GameObject position, [NotNull] GameObject target, float fov) => position.transform.position.InView(position.transform.forward, target.transform.position, fov);
        
        /// <summary>
        /// If there is a direct line of sight from a starting position to an end position.
        /// </summary>
        /// <param name="position">The starting position of the line of sight.</param>
        /// <param name="target">The ending position of the line of sight.</param>
        /// <param name="hit">The hit information from the line of sight check.</param>
        /// <param name="mask">The optional layer mask.</param>
        /// <param name="triggers">How the check should handle hitting triggers.</param>
        /// <returns>If there is a direct line of sight from a starting position to an end position.</returns>
        public static bool HasSight(this Vector2 position, Vector2 target, out RaycastHit hit, int mask = -5, QueryTriggerInteraction triggers = QueryTriggerInteraction.UseGlobal) => new Vector3(position.x, 0, position.y).HasSight(new Vector3(target.x, 0, target.y), out hit, mask, triggers);
        
        /// <summary>
        /// If there is a direct line of sight from a starting position to an end position.
        /// </summary>
        /// <param name="position">The starting position of the line of sight.</param>
        /// <param name="target">The ending position of the line of sight.</param>
        /// <param name="hit">The hit information from the line of sight check.</param>
        /// <param name="mask">The optional layer mask.</param>
        /// <param name="triggers">How the check should handle hitting triggers.</param>
        /// <returns>If there is a direct line of sight from a starting position to an end position.</returns>
        public static bool HasSight(this Vector2 position, Vector3 target, out RaycastHit hit, int mask = -5, QueryTriggerInteraction triggers = QueryTriggerInteraction.UseGlobal) => new Vector3(position.x, target.y, position.y).HasSight(target, out hit, mask, triggers);
        
        /// <summary>
        /// If there is a direct line of sight from a starting position to an end position, or the hit during the line of sight check was the target.
        /// </summary>
        /// <param name="position">The starting position of the line of sight.</param>
        /// <param name="target">The ending position of the line of sight.</param>
        /// <param name="hit">The hit information from the line of sight check.</param>
        /// <param name="mask">The optional layer mask.</param>
        /// <param name="triggers">How the check should handle hitting triggers.</param>
        /// <returns>If there is a direct line of sight from a starting position to an end position, or the hit during the line of sight check was the target.</returns>
        public static bool HasSight(this Vector2 position, [NotNull] Transform target, out RaycastHit hit, int mask = -5, QueryTriggerInteraction triggers = QueryTriggerInteraction.UseGlobal) => position.HasSight(target.position, out hit, mask, triggers) || hit.transform == target;
        
        /// <summary>
        /// If there is a direct line of sight from a starting position to an end position, or the hit during the line of sight check was the target.
        /// </summary>
        /// <param name="position">The starting position of the line of sight.</param>
        /// <param name="target">The ending position of the line of sight.</param>
        /// <param name="hit">The hit information from the line of sight check.</param>
        /// <param name="mask">The optional layer mask.</param>
        /// <param name="triggers">How the check should handle hitting triggers.</param>
        /// <returns>If there is a direct line of sight from a starting position to an end position, or the hit during the line of sight check was the target.</returns>
        public static bool HasSight(this Vector2 position, [NotNull] Component target, out RaycastHit hit, int mask = -5, QueryTriggerInteraction triggers = QueryTriggerInteraction.UseGlobal) => position.HasSight(target.transform, out hit, mask, triggers);
        
        /// <summary>
        /// If there is a direct line of sight from a starting position to an end position, or the hit during the line of sight check was the target.
        /// </summary>
        /// <param name="position">The starting position of the line of sight.</param>
        /// <param name="target">The ending position of the line of sight.</param>
        /// <param name="hit">The hit information from the line of sight check.</param>
        /// <param name="mask">The optional layer mask.</param>
        /// <param name="triggers">How the check should handle hitting triggers.</param>
        /// <returns>If there is a direct line of sight from a starting position to an end position, or the hit during the line of sight check was the target.</returns>
        public static bool HasSight(this Vector2 position, [NotNull] GameObject target, out RaycastHit hit, int mask = -5, QueryTriggerInteraction triggers = QueryTriggerInteraction.UseGlobal) => position.HasSight(target.transform, out hit, mask, triggers);
        
        /// <summary>
        /// If there is a direct line of sight from a starting position to an end position.
        /// </summary>
        /// <param name="position">The starting position of the line of sight.</param>
        /// <param name="target">The ending position of the line of sight.</param>
        /// <param name="hit">The hit information from the line of sight check.</param>
        /// <param name="mask">The optional layer mask.</param>
        /// <param name="triggers">How the check should handle hitting triggers.</param>
        /// <returns>If there is a direct line of sight from a starting position to an end position.</returns>
        public static bool HasSight(this Vector3 position, Vector2 target, out RaycastHit hit, int mask = -5, QueryTriggerInteraction triggers = QueryTriggerInteraction.UseGlobal) => position.HasSight(new Vector3(target.x, position.y, target.y), out hit, mask, triggers);
        
        /// <summary>
        /// If there is a direct line of sight from a starting position to an end position.
        /// </summary>
        /// <param name="position">The starting position of the line of sight.</param>
        /// <param name="target">The ending position of the line of sight.</param>
        /// <param name="hit">The hit information from the line of sight check.</param>
        /// <param name="mask">The optional layer mask.</param>
        /// <param name="triggers">How the check should handle hitting triggers.</param>
        /// <returns>If there is a direct line of sight from a starting position to an end position.</returns>
        public static bool HasSight(this Vector3 position, Vector3 target, out RaycastHit hit, int mask = -5, QueryTriggerInteraction triggers = QueryTriggerInteraction.UseGlobal) => !Physics.Linecast(position, target, out hit, mask, triggers);
        
        /// <summary>
        /// If there is a direct line of sight from a starting position to an end position, or the hit during the line of sight check was the target.
        /// </summary>
        /// <param name="position">The starting position of the line of sight.</param>
        /// <param name="target">The ending position of the line of sight.</param>
        /// <param name="hit">The hit information from the line of sight check.</param>
        /// <param name="mask">The optional layer mask.</param>
        /// <param name="triggers">How the check should handle hitting triggers.</param>
        /// <returns>If there is a direct line of sight from a starting position to an end position, or the hit during the line of sight check was the target.</returns>
        public static bool HasSight(this Vector3 position, [NotNull] Transform target, out RaycastHit hit, int mask = -5, QueryTriggerInteraction triggers = QueryTriggerInteraction.UseGlobal) => position.HasSight(target.position, out hit, mask, triggers) || hit.transform == target;
        
        /// <summary>
        /// If there is a direct line of sight from a starting position to an end position, or the hit during the line of sight check was the target.
        /// </summary>
        /// <param name="position">The starting position of the line of sight.</param>
        /// <param name="target">The ending position of the line of sight.</param>
        /// <param name="hit">The hit information from the line of sight check.</param>
        /// <param name="mask">The optional layer mask.</param>
        /// <param name="triggers">How the check should handle hitting triggers.</param>
        /// <returns>If there is a direct line of sight from a starting position to an end position, or the hit during the line of sight check was the target.</returns>
        public static bool HasSight(this Vector3 position, [NotNull] Component target, out RaycastHit hit, int mask = -5, QueryTriggerInteraction triggers = QueryTriggerInteraction.UseGlobal) => position.HasSight(target.transform, out hit, mask, triggers);
        
        /// <summary>
        /// If there is a direct line of sight from a starting position to an end position, or the hit during the line of sight check was the target.
        /// </summary>
        /// <param name="position">The starting position of the line of sight.</param>
        /// <param name="target">The ending position of the line of sight.</param>
        /// <param name="hit">The hit information from the line of sight check.</param>
        /// <param name="mask">The optional layer mask.</param>
        /// <param name="triggers">How the check should handle hitting triggers.</param>
        /// <returns>If there is a direct line of sight from a starting position to an end position, or the hit during the line of sight check was the target.</returns>
        public static bool HasSight(this Vector3 position, [NotNull] GameObject target, out RaycastHit hit, int mask = -5, QueryTriggerInteraction triggers = QueryTriggerInteraction.UseGlobal) => position.HasSight(target.transform, out hit, mask, triggers);
        
        /// <summary>
        /// If there is a direct line of sight from a starting position to an end position.
        /// </summary>
        /// <param name="position">The starting position of the line of sight.</param>
        /// <param name="target">The ending position of the line of sight.</param>
        /// <param name="hit">The hit information from the line of sight check.</param>
        /// <param name="mask">The optional layer mask.</param>
        /// <param name="triggers">How the check should handle hitting triggers.</param>
        /// <returns>If there is a direct line of sight from a starting position to an end position.</returns>
        public static bool HasSight([NotNull] this Transform position, Vector2 target, out RaycastHit hit, int mask = -5, QueryTriggerInteraction triggers = QueryTriggerInteraction.UseGlobal) => position.position.HasSight(target, out hit, mask, triggers);
        
        /// <summary>
        /// If there is a direct line of sight from a starting position to an end position.
        /// </summary>
        /// <param name="position">The starting position of the line of sight.</param>
        /// <param name="target">The ending position of the line of sight.</param>
        /// <param name="hit">The hit information from the line of sight check.</param>
        /// <param name="mask">The optional layer mask.</param>
        /// <param name="triggers">How the check should handle hitting triggers.</param>
        /// <returns>If there is a direct line of sight from a starting position to an end position.</returns>
        public static bool HasSight([NotNull] this Transform position, Vector3 target, out RaycastHit hit, int mask = -5, QueryTriggerInteraction triggers = QueryTriggerInteraction.UseGlobal) => position.position.HasSight(target, out hit, mask, triggers);
        
        /// <summary>
        /// If there is a direct line of sight from a starting position to an end position, or the hit during the line of sight check was the target.
        /// </summary>
        /// <param name="position">The starting position of the line of sight.</param>
        /// <param name="target">The ending position of the line of sight.</param>
        /// <param name="hit">The hit information from the line of sight check.</param>
        /// <param name="mask">The optional layer mask.</param>
        /// <param name="triggers">How the check should handle hitting triggers.</param>
        /// <returns>If there is a direct line of sight from a starting position to an end position, or the hit during the line of sight check was the target.</returns>
        public static bool HasSight([NotNull] this Transform position, [NotNull] Transform target, out RaycastHit hit, int mask = -5, QueryTriggerInteraction triggers = QueryTriggerInteraction.UseGlobal) => position.position.HasSight(target, out hit, mask, triggers);
        
        /// <summary>
        /// If there is a direct line of sight from a starting position to an end position, or the hit during the line of sight check was the target.
        /// </summary>
        /// <param name="position">The starting position of the line of sight.</param>
        /// <param name="target">The ending position of the line of sight.</param>
        /// <param name="hit">The hit information from the line of sight check.</param>
        /// <param name="mask">The optional layer mask.</param>
        /// <param name="triggers">How the check should handle hitting triggers.</param>
        /// <returns>If there is a direct line of sight from a starting position to an end position, or the hit during the line of sight check was the target.</returns>
        public static bool HasSight([NotNull] this Transform position, [NotNull] Component target, out RaycastHit hit, int mask = -5, QueryTriggerInteraction triggers = QueryTriggerInteraction.UseGlobal) => position.position.HasSight(target.transform, out hit, mask, triggers);
        
        /// <summary>
        /// If there is a direct line of sight from a starting position to an end position, or the hit during the line of sight check was the target.
        /// </summary>
        /// <param name="position">The starting position of the line of sight.</param>
        /// <param name="target">The ending position of the line of sight.</param>
        /// <param name="hit">The hit information from the line of sight check.</param>
        /// <param name="mask">The optional layer mask.</param>
        /// <param name="triggers">How the check should handle hitting triggers.</param>
        /// <returns>If there is a direct line of sight from a starting position to an end position, or the hit during the line of sight check was the target.</returns>
        public static bool HasSight([NotNull] this Transform position, [NotNull] GameObject target, out RaycastHit hit, int mask = -5, QueryTriggerInteraction triggers = QueryTriggerInteraction.UseGlobal) => position.position.HasSight(target.transform, out hit, mask, triggers);
        
        /// <summary>
        /// If there is a direct line of sight from a starting position to an end position.
        /// </summary>
        /// <param name="position">The starting position of the line of sight.</param>
        /// <param name="target">The ending position of the line of sight.</param>
        /// <param name="hit">The hit information from the line of sight check.</param>
        /// <param name="mask">The optional layer mask.</param>
        /// <param name="triggers">How the check should handle hitting triggers.</param>
        /// <returns>If there is a direct line of sight from a starting position to an end position.</returns>
        public static bool HasSight([NotNull] this Component position, Vector2 target, out RaycastHit hit, int mask = -5, QueryTriggerInteraction triggers = QueryTriggerInteraction.UseGlobal) => position.transform.position.HasSight(target, out hit, mask, triggers);
        
        /// <summary>
        /// If there is a direct line of sight from a starting position to an end position.
        /// </summary>
        /// <param name="position">The starting position of the line of sight.</param>
        /// <param name="target">The ending position of the line of sight.</param>
        /// <param name="hit">The hit information from the line of sight check.</param>
        /// <param name="mask">The optional layer mask.</param>
        /// <param name="triggers">How the check should handle hitting triggers.</param>
        /// <returns>If there is a direct line of sight from a starting position to an end position.</returns>
        public static bool HasSight([NotNull] this Component position, Vector3 target, out RaycastHit hit, int mask = -5, QueryTriggerInteraction triggers = QueryTriggerInteraction.UseGlobal) => position.transform.position.HasSight(target, out hit, mask, triggers);
        
        /// <summary>
        /// If there is a direct line of sight from a starting position to an end position, or the hit during the line of sight check was the target.
        /// </summary>
        /// <param name="position">The starting position of the line of sight.</param>
        /// <param name="target">The ending position of the line of sight.</param>
        /// <param name="hit">The hit information from the line of sight check.</param>
        /// <param name="mask">The optional layer mask.</param>
        /// <param name="triggers">How the check should handle hitting triggers.</param>
        /// <returns>If there is a direct line of sight from a starting position to an end position, or the hit during the line of sight check was the target.</returns>
        public static bool HasSight([NotNull] this Component position, [NotNull] Transform target, out RaycastHit hit, int mask = -5, QueryTriggerInteraction triggers = QueryTriggerInteraction.UseGlobal) => position.transform.position.HasSight(target, out hit, mask, triggers);
        
        /// <summary>
        /// If there is a direct line of sight from a starting position to an end position, or the hit during the line of sight check was the target.
        /// </summary>
        /// <param name="position">The starting position of the line of sight.</param>
        /// <param name="target">The ending position of the line of sight.</param>
        /// <param name="hit">The hit information from the line of sight check.</param>
        /// <param name="mask">The optional layer mask.</param>
        /// <param name="triggers">How the check should handle hitting triggers.</param>
        /// <returns>If there is a direct line of sight from a starting position to an end position, or the hit during the line of sight check was the target.</returns>
        public static bool HasSight([NotNull] this Component position, [NotNull] Component target, out RaycastHit hit, int mask = -5, QueryTriggerInteraction triggers = QueryTriggerInteraction.UseGlobal) => position.transform.position.HasSight(target.transform, out hit, mask, triggers);
        
        /// <summary>
        /// If there is a direct line of sight from a starting position to an end position, or the hit during the line of sight check was the target.
        /// </summary>
        /// <param name="position">The starting position of the line of sight.</param>
        /// <param name="target">The ending position of the line of sight.</param>
        /// <param name="hit">The hit information from the line of sight check.</param>
        /// <param name="mask">The optional layer mask.</param>
        /// <param name="triggers">How the check should handle hitting triggers.</param>
        /// <returns>If there is a direct line of sight from a starting position to an end position, or the hit during the line of sight check was the target.</returns>
        public static bool HasSight([NotNull] this Component position, [NotNull] GameObject target, out RaycastHit hit, int mask = -5, QueryTriggerInteraction triggers = QueryTriggerInteraction.UseGlobal) => position.transform.position.HasSight(target.transform, out hit, mask, triggers);
        
        /// <summary>
        /// If there is a direct line of sight from a starting position to an end position.
        /// </summary>
        /// <param name="position">The starting position of the line of sight.</param>
        /// <param name="target">The ending position of the line of sight.</param>
        /// <param name="hit">The hit information from the line of sight check.</param>
        /// <param name="mask">The optional layer mask.</param>
        /// <param name="triggers">How the check should handle hitting triggers.</param>
        /// <returns>If there is a direct line of sight from a starting position to an end position.</returns>
        public static bool HasSight([NotNull] this GameObject position, Vector2 target, out RaycastHit hit, int mask = -5, QueryTriggerInteraction triggers = QueryTriggerInteraction.UseGlobal) => position.transform.position.HasSight(target, out hit, mask, triggers);
        
        /// <summary>
        /// If there is a direct line of sight from a starting position to an end position.
        /// </summary>
        /// <param name="position">The starting position of the line of sight.</param>
        /// <param name="target">The ending position of the line of sight.</param>
        /// <param name="hit">The hit information from the line of sight check.</param>
        /// <param name="mask">The optional layer mask.</param>
        /// <param name="triggers">How the check should handle hitting triggers.</param>
        /// <returns>If there is a direct line of sight from a starting position to an end position.</returns>
        public static bool HasSight([NotNull] this GameObject position, Vector3 target, out RaycastHit hit, int mask = -5, QueryTriggerInteraction triggers = QueryTriggerInteraction.UseGlobal) => position.transform.position.HasSight(target, out hit, mask, triggers);
        
        /// <summary>
        /// If there is a direct line of sight from a starting position to an end position, or the hit during the line of sight check was the target.
        /// </summary>
        /// <param name="position">The starting position of the line of sight.</param>
        /// <param name="target">The ending position of the line of sight.</param>
        /// <param name="hit">The hit information from the line of sight check.</param>
        /// <param name="mask">The optional layer mask.</param>
        /// <param name="triggers">How the check should handle hitting triggers.</param>
        /// <returns>If there is a direct line of sight from a starting position to an end position, or the hit during the line of sight check was the target.</returns>
        public static bool HasSight([NotNull] this GameObject position, [NotNull] Transform target, out RaycastHit hit, int mask = -5, QueryTriggerInteraction triggers = QueryTriggerInteraction.UseGlobal) => position.transform.position.HasSight(target, out hit, mask, triggers);
        
        /// <summary>
        /// If there is a direct line of sight from a starting position to an end position, or the hit during the line of sight check was the target.
        /// </summary>
        /// <param name="position">The starting position of the line of sight.</param>
        /// <param name="target">The ending position of the line of sight.</param>
        /// <param name="hit">The hit information from the line of sight check.</param>
        /// <param name="mask">The optional layer mask.</param>
        /// <param name="triggers">How the check should handle hitting triggers.</param>
        /// <returns>If there is a direct line of sight from a starting position to an end position, or the hit during the line of sight check was the target.</returns>
        public static bool HasSight([NotNull] this GameObject position, [NotNull] Component target, out RaycastHit hit, int mask = -5, QueryTriggerInteraction triggers = QueryTriggerInteraction.UseGlobal) => position.transform.position.HasSight(target.transform, out hit, mask, triggers);
        
        /// <summary>
        /// If there is a direct line of sight from a starting position to an end position, or the hit during the line of sight check was the target.
        /// </summary>
        /// <param name="position">The starting position of the line of sight.</param>
        /// <param name="target">The ending position of the line of sight.</param>
        /// <param name="hit">The hit information from the line of sight check.</param>
        /// <param name="mask">The optional layer mask.</param>
        /// <param name="triggers">How the check should handle hitting triggers.</param>
        /// <returns>If there is a direct line of sight from a starting position to an end position, or the hit during the line of sight check was the target.</returns>
        public static bool HasSight([NotNull] this GameObject position, [NotNull] GameObject target, out RaycastHit hit, int mask = -5, QueryTriggerInteraction triggers = QueryTriggerInteraction.UseGlobal) => position.transform.position.HasSight(target.transform, out hit, mask, triggers);
        
        /// <summary>
        /// If there is a direct line of sight with a given radius from a starting position to an end position.
        /// </summary>
        /// <param name="position">The starting position of the line of sight.</param>
        /// <param name="target">The ending position of the line of sight.</param>
        /// <param name="hit">The hit information from the line of sight check.</param>
        /// <param name="radius">How wide of a sphere to cast.</param>
        /// <param name="mask">The optional layer mask.</param>
        /// <param name="triggers">How the check should handle hitting triggers.</param>
        /// <returns>If there is a direct line of sight with a given radius from a starting position to an end position.</returns>
        public static bool HasSight(this Vector2 position, Vector2 target, out RaycastHit hit, float radius, int mask = -5, QueryTriggerInteraction triggers = QueryTriggerInteraction.UseGlobal) => new Vector3(position.x, 0, position.y).HasSight(new Vector3(target.x, 0, target.y), out hit, radius, mask, triggers);
        
        /// <summary>
        /// If there is a direct line of sight with a given radius from a starting position to an end position.
        /// </summary>
        /// <param name="position">The starting position of the line of sight.</param>
        /// <param name="target">The ending position of the line of sight.</param>
        /// <param name="hit">The hit information from the line of sight check.</param>
        /// <param name="radius">How wide of a sphere to cast.</param>
        /// <param name="mask">The optional layer mask.</param>
        /// <param name="triggers">How the check should handle hitting triggers.</param>
        /// <returns>If there is a direct line of sight with a given radius from a starting position to an end position.</returns>
        public static bool HasSight(this Vector2 position, Vector3 target, out RaycastHit hit, float radius, int mask = -5, QueryTriggerInteraction triggers = QueryTriggerInteraction.UseGlobal) => new Vector3(position.x, target.y, position.y).HasSight(target, out hit, radius, mask, triggers);
        
        /// <summary>
        /// If there is a direct line of sight with a given radius from a starting position to an end position, or the hit during the line of sight check was the target.
        /// </summary>
        /// <param name="position">The starting position of the line of sight.</param>
        /// <param name="target">The ending position of the line of sight.</param>
        /// <param name="hit">The hit information from the line of sight check.</param>
        /// <param name="radius">How wide of a sphere to cast.</param>
        /// <param name="mask">The optional layer mask.</param>
        /// <param name="triggers">How the check should handle hitting triggers.</param>
        /// <returns>If there is a direct line of sight with a given radius from a starting position to an end position, or the hit during the line of sight check was the target.</returns>
        public static bool HasSight(this Vector2 position, [NotNull] Transform target, out RaycastHit hit, float radius, int mask = -5, QueryTriggerInteraction triggers = QueryTriggerInteraction.UseGlobal) => position.HasSight(target.position, out hit, radius, mask, triggers) || hit.transform == target;
        
        /// <summary>
        /// If there is a direct line of sight with a given radius from a starting position to an end position, or the hit during the line of sight check was the target.
        /// </summary>
        /// <param name="position">The starting position of the line of sight.</param>
        /// <param name="target">The ending position of the line of sight.</param>
        /// <param name="hit">The hit information from the line of sight check.</param>
        /// <param name="radius">How wide of a sphere to cast.</param>
        /// <param name="mask">The optional layer mask.</param>
        /// <param name="triggers">How the check should handle hitting triggers.</param>
        /// <returns>If there is a direct line of sight with a given radius from a starting position to an end position, or the hit during the line of sight check was the target.</returns>
        public static bool HasSight(this Vector2 position, [NotNull] Component target, out RaycastHit hit, float radius, int mask = -5, QueryTriggerInteraction triggers = QueryTriggerInteraction.UseGlobal) => position.HasSight(target.transform, out hit, radius, mask, triggers);
        
        /// <summary>
        /// If there is a direct line of sight with a given radius from a starting position to an end position, or the hit during the line of sight check was the target.
        /// </summary>
        /// <param name="position">The starting position of the line of sight.</param>
        /// <param name="target">The ending position of the line of sight.</param>
        /// <param name="hit">The hit information from the line of sight check.</param>
        /// <param name="radius">How wide of a sphere to cast.</param>
        /// <param name="mask">The optional layer mask.</param>
        /// <param name="triggers">How the check should handle hitting triggers.</param>
        /// <returns>If there is a direct line of sight with a given radius from a starting position to an end position, or the hit during the line of sight check was the target.</returns>
        public static bool HasSight(this Vector2 position, [NotNull] GameObject target, out RaycastHit hit, float radius, int mask = -5, QueryTriggerInteraction triggers = QueryTriggerInteraction.UseGlobal) => position.HasSight(target.transform, out hit, radius, mask, triggers);
        
        /// <summary>
        /// If there is a direct line of sight with a given radius from a starting position to an end position.
        /// </summary>
        /// <param name="position">The starting position of the line of sight.</param>
        /// <param name="target">The ending position of the line of sight.</param>
        /// <param name="hit">The hit information from the line of sight check.</param>
        /// <param name="radius">How wide of a sphere to cast.</param>
        /// <param name="mask">The optional layer mask.</param>
        /// <param name="triggers">How the check should handle hitting triggers.</param>
        /// <returns>If there is a direct line of sight with a given radius from a starting position to an end position.</returns>
        public static bool HasSight(this Vector3 position, Vector2 target, out RaycastHit hit, float radius, int mask = -5, QueryTriggerInteraction triggers = QueryTriggerInteraction.UseGlobal) => position.HasSight(new Vector3(target.x, position.y, target.y), out hit, radius, mask, triggers);
        
        /// <summary>
        /// If there is a direct line of sight with a given radius from a starting position to an end position.
        /// </summary>
        /// <param name="position">The starting position of the line of sight.</param>
        /// <param name="target">The ending position of the line of sight.</param>
        /// <param name="hit">The hit information from the line of sight check.</param>
        /// <param name="radius">How wide of a sphere to cast.</param>
        /// <param name="mask">The optional layer mask.</param>
        /// <param name="triggers">How the check should handle hitting triggers.</param>
        /// <returns>If there is a direct line of sight with a given radius from a starting position to an end position.</returns>
        public static bool HasSight(this Vector3 position, Vector3 target, out RaycastHit hit, float radius, int mask = -5, QueryTriggerInteraction triggers = QueryTriggerInteraction.UseGlobal)
        {
            // If an illegal radius was passed, use the line casting method.
            if (radius <= 0)
            {
                return position.HasSight(target, out hit, mask, triggers);
            }
            
            Vector3 direction = position.Direction3(target);
            return !Physics.SphereCast(position, radius, direction, out hit, direction.magnitude, mask);
        }
        
        /// <summary>
        /// If there is a direct line of sight with a given radius from a starting position to an end position, or the hit during the line of sight check was the target.
        /// </summary>
        /// <param name="position">The starting position of the line of sight.</param>
        /// <param name="target">The ending position of the line of sight.</param>
        /// <param name="hit">The hit information from the line of sight check.</param>
        /// <param name="radius">How wide of a sphere to cast.</param>
        /// <param name="mask">The optional layer mask.</param>
        /// <param name="triggers">How the check should handle hitting triggers.</param>
        /// <returns>If there is a direct line of sight with a given radius from a starting position to an end position, or the hit during the line of sight check was the target.</returns>
        public static bool HasSight(this Vector3 position, [NotNull] Transform target, out RaycastHit hit, float radius, int mask = -5, QueryTriggerInteraction triggers = QueryTriggerInteraction.UseGlobal) => position.HasSight(target.position, out hit, radius, mask, triggers) || hit.transform == target;
        
        /// <summary>
        /// If there is a direct line of sight with a given radius from a starting position to an end position, or the hit during the line of sight check was the target.
        /// </summary>
        /// <param name="position">The starting position of the line of sight.</param>
        /// <param name="target">The ending position of the line of sight.</param>
        /// <param name="hit">The hit information from the line of sight check.</param>
        /// <param name="radius">How wide of a sphere to cast.</param>
        /// <param name="mask">The optional layer mask.</param>
        /// <param name="triggers">How the check should handle hitting triggers.</param>
        /// <returns>If there is a direct line of sight with a given radius from a starting position to an end position, or the hit during the line of sight check was the target.</returns>
        public static bool HasSight(this Vector3 position, [NotNull] Component target, out RaycastHit hit, float radius, int mask = -5, QueryTriggerInteraction triggers = QueryTriggerInteraction.UseGlobal) => position.HasSight(target.transform, out hit, radius, mask, triggers);
        
        /// <summary>
        /// If there is a direct line of sight with a given radius from a starting position to an end position, or the hit during the line of sight check was the target.
        /// </summary>
        /// <param name="position">The starting position of the line of sight.</param>
        /// <param name="target">The ending position of the line of sight.</param>
        /// <param name="hit">The hit information from the line of sight check.</param>
        /// <param name="radius">How wide of a sphere to cast.</param>
        /// <param name="mask">The optional layer mask.</param>
        /// <param name="triggers">How the check should handle hitting triggers.</param>
        /// <returns>If there is a direct line of sight with a given radius from a starting position to an end position, or the hit during the line of sight check was the target.</returns>
        public static bool HasSight(this Vector3 position, [NotNull] GameObject target, out RaycastHit hit, float radius, int mask = -5, QueryTriggerInteraction triggers = QueryTriggerInteraction.UseGlobal) => position.HasSight(target.transform, out hit, radius, mask, triggers);
        
        /// <summary>
        /// If there is a direct line of sight with a given radius from a starting position to an end position.
        /// </summary>
        /// <param name="position">The starting position of the line of sight.</param>
        /// <param name="target">The ending position of the line of sight.</param>
        /// <param name="hit">The hit information from the line of sight check.</param>
        /// <param name="radius">How wide of a sphere to cast.</param>
        /// <param name="mask">The optional layer mask.</param>
        /// <param name="triggers">How the check should handle hitting triggers.</param>
        /// <returns>If there is a direct line of sight with a given radius from a starting position to an end position.</returns>
        public static bool HasSight([NotNull] this Transform position, Vector2 target, out RaycastHit hit, float radius, int mask = -5, QueryTriggerInteraction triggers = QueryTriggerInteraction.UseGlobal) => position.position.HasSight(target, out hit, radius, mask, triggers);
        
        /// <summary>
        /// If there is a direct line of sight with a given radius from a starting position to an end position.
        /// </summary>
        /// <param name="position">The starting position of the line of sight.</param>
        /// <param name="target">The ending position of the line of sight.</param>
        /// <param name="hit">The hit information from the line of sight check.</param>
        /// <param name="radius">How wide of a sphere to cast.</param>
        /// <param name="mask">The optional layer mask.</param>
        /// <param name="triggers">How the check should handle hitting triggers.</param>
        /// <returns>If there is a direct line of sight with a given radius from a starting position to an end position.</returns>
        public static bool HasSight([NotNull] this Transform position, Vector3 target, out RaycastHit hit, float radius, int mask = -5, QueryTriggerInteraction triggers = QueryTriggerInteraction.UseGlobal) => position.position.HasSight(target, out hit, radius, mask, triggers);
        
        /// <summary>
        /// If there is a direct line of sight with a given radius from a starting position to an end position, or the hit during the line of sight check was the target.
        /// </summary>
        /// <param name="position">The starting position of the line of sight.</param>
        /// <param name="target">The ending position of the line of sight.</param>
        /// <param name="hit">The hit information from the line of sight check.</param>
        /// <param name="radius">How wide of a sphere to cast.</param>
        /// <param name="mask">The optional layer mask.</param>
        /// <param name="triggers">How the check should handle hitting triggers.</param>
        /// <returns>If there is a direct line of sight with a given radius from a starting position to an end position, or the hit during the line of sight check was the target.</returns>
        public static bool HasSight([NotNull] this Transform position, [NotNull] Transform target, out RaycastHit hit, float radius, int mask = -5, QueryTriggerInteraction triggers = QueryTriggerInteraction.UseGlobal) => position.position.HasSight(target, out hit, radius, mask, triggers);
        
        /// <summary>
        /// If there is a direct line of sight with a given radius from a starting position to an end position, or the hit during the line of sight check was the target.
        /// </summary>
        /// <param name="position">The starting position of the line of sight.</param>
        /// <param name="target">The ending position of the line of sight.</param>
        /// <param name="hit">The hit information from the line of sight check.</param>
        /// <param name="radius">How wide of a sphere to cast.</param>
        /// <param name="mask">The optional layer mask.</param>
        /// <param name="triggers">How the check should handle hitting triggers.</param>
        /// <returns>If there is a direct line of sight with a given radius from a starting position to an end position, or the hit during the line of sight check was the target.</returns>
        public static bool HasSight([NotNull] this Transform position, [NotNull] Component target, out RaycastHit hit, float radius, int mask = -5, QueryTriggerInteraction triggers = QueryTriggerInteraction.UseGlobal) => position.position.HasSight(target.transform, out hit, radius, mask, triggers);
        
        /// <summary>
        /// If there is a direct line of sight with a given radius from a starting position to an end position, or the hit during the line of sight check was the target.
        /// </summary>
        /// <param name="position">The starting position of the line of sight.</param>
        /// <param name="target">The ending position of the line of sight.</param>
        /// <param name="hit">The hit information from the line of sight check.</param>
        /// <param name="radius">How wide of a sphere to cast.</param>
        /// <param name="mask">The optional layer mask.</param>
        /// <param name="triggers">How the check should handle hitting triggers.</param>
        /// <returns>If there is a direct line of sight with a given radius from a starting position to an end position, or the hit during the line of sight check was the target.</returns>
        public static bool HasSight([NotNull] this Transform position, [NotNull] GameObject target, out RaycastHit hit, float radius, int mask = -5, QueryTriggerInteraction triggers = QueryTriggerInteraction.UseGlobal) => position.position.HasSight(target.transform, out hit, radius, mask, triggers);
        
        /// <summary>
        /// If there is a direct line of sight with a given radius from a starting position to an end position.
        /// </summary>
        /// <param name="position">The starting position of the line of sight.</param>
        /// <param name="target">The ending position of the line of sight.</param>
        /// <param name="hit">The hit information from the line of sight check.</param>
        /// <param name="radius">How wide of a sphere to cast.</param>
        /// <param name="mask">The optional layer mask.</param>
        /// <param name="triggers">How the check should handle hitting triggers.</param>
        /// <returns>If there is a direct line of sight with a given radius from a starting position to an end position.</returns>
        public static bool HasSight([NotNull] this Component position, Vector2 target, out RaycastHit hit, float radius, int mask = -5, QueryTriggerInteraction triggers = QueryTriggerInteraction.UseGlobal) => position.transform.position.HasSight(target, out hit, radius, mask, triggers);
        
        /// <summary>
        /// If there is a direct line of sight with a given radius from a starting position to an end position.
        /// </summary>
        /// <param name="position">The starting position of the line of sight.</param>
        /// <param name="target">The ending position of the line of sight.</param>
        /// <param name="hit">The hit information from the line of sight check.</param>
        /// <param name="radius">How wide of a sphere to cast.</param>
        /// <param name="mask">The optional layer mask.</param>
        /// <param name="triggers">How the check should handle hitting triggers.</param>
        /// <returns>If there is a direct line of sight with a given radius from a starting position to an end position.</returns>
        public static bool HasSight([NotNull] this Component position, Vector3 target, out RaycastHit hit, float radius, int mask = -5, QueryTriggerInteraction triggers = QueryTriggerInteraction.UseGlobal) => position.transform.position.HasSight(target, out hit, radius, mask, triggers);
        
        /// <summary>
        /// If there is a direct line of sight with a given radius from a starting position to an end position, or the hit during the line of sight check was the target.
        /// </summary>
        /// <param name="position">The starting position of the line of sight.</param>
        /// <param name="target">The ending position of the line of sight.</param>
        /// <param name="hit">The hit information from the line of sight check.</param>
        /// <param name="radius">How wide of a sphere to cast.</param>
        /// <param name="mask">The optional layer mask.</param>
        /// <param name="triggers">How the check should handle hitting triggers.</param>
        /// <returns>If there is a direct line of sight with a given radius from a starting position to an end position, or the hit during the line of sight check was the target.</returns>
        public static bool HasSight([NotNull] this Component position, [NotNull] Transform target, out RaycastHit hit, float radius, int mask = -5, QueryTriggerInteraction triggers = QueryTriggerInteraction.UseGlobal) => position.transform.position.HasSight(target, out hit, radius, mask, triggers);
        
        /// <summary>
        /// If there is a direct line of sight with a given radius from a starting position to an end position, or the hit during the line of sight check was the target.
        /// </summary>
        /// <param name="position">The starting position of the line of sight.</param>
        /// <param name="target">The ending position of the line of sight.</param>
        /// <param name="hit">The hit information from the line of sight check.</param>
        /// <param name="radius">How wide of a sphere to cast.</param>
        /// <param name="mask">The optional layer mask.</param>
        /// <param name="triggers">How the check should handle hitting triggers.</param>
        /// <returns>If there is a direct line of sight with a given radius from a starting position to an end position, or the hit during the line of sight check was the target.</returns>
        public static bool HasSight([NotNull] this Component position, [NotNull] Component target, out RaycastHit hit, float radius, int mask = -5, QueryTriggerInteraction triggers = QueryTriggerInteraction.UseGlobal) => position.transform.position.HasSight(target.transform, out hit, radius, mask, triggers);
        
        /// <summary>
        /// If there is a direct line of sight with a given radius from a starting position to an end position, or the hit during the line of sight check was the target.
        /// </summary>
        /// <param name="position">The starting position of the line of sight.</param>
        /// <param name="target">The ending position of the line of sight.</param>
        /// <param name="hit">The hit information from the line of sight check.</param>
        /// <param name="radius">How wide of a sphere to cast.</param>
        /// <param name="mask">The optional layer mask.</param>
        /// <param name="triggers">How the check should handle hitting triggers.</param>
        /// <returns>If there is a direct line of sight with a given radius from a starting position to an end position, or the hit during the line of sight check was the target.</returns>
        public static bool HasSight([NotNull] this Component position, [NotNull] GameObject target, out RaycastHit hit, float radius, int mask = -5, QueryTriggerInteraction triggers = QueryTriggerInteraction.UseGlobal) => position.transform.position.HasSight(target.transform, out hit, radius, mask, triggers);
        
        /// <summary>
        /// If there is a direct line of sight with a given radius from a starting position to an end position.
        /// </summary>
        /// <param name="position">The starting position of the line of sight.</param>
        /// <param name="target">The ending position of the line of sight.</param>
        /// <param name="hit">The hit information from the line of sight check.</param>
        /// <param name="radius">How wide of a sphere to cast.</param>
        /// <param name="mask">The optional layer mask.</param>
        /// <param name="triggers">How the check should handle hitting triggers.</param>
        /// <returns>If there is a direct line of sight with a given radius from a starting position to an end position.</returns>
        public static bool HasSight([NotNull] this GameObject position, Vector2 target, out RaycastHit hit, float radius, int mask = -5, QueryTriggerInteraction triggers = QueryTriggerInteraction.UseGlobal) => position.transform.position.HasSight(target, out hit, radius, mask, triggers);
        
        /// <summary>
        /// If there is a direct line of sight with a given radius from a starting position to an end position.
        /// </summary>
        /// <param name="position">The starting position of the line of sight.</param>
        /// <param name="target">The ending position of the line of sight.</param>
        /// <param name="hit">The hit information from the line of sight check.</param>
        /// <param name="radius">How wide of a sphere to cast.</param>
        /// <param name="mask">The optional layer mask.</param>
        /// <param name="triggers">How the check should handle hitting triggers.</param>
        /// <returns>If there is a direct line of sight with a given radius from a starting position to an end position.</returns>
        public static bool HasSight([NotNull] this GameObject position, Vector3 target, out RaycastHit hit, float radius, int mask = -5, QueryTriggerInteraction triggers = QueryTriggerInteraction.UseGlobal) => position.transform.position.HasSight(target, out hit, radius, mask, triggers);
        
        /// <summary>
        /// If there is a direct line of sight with a given radius from a starting position to an end position, or the hit during the line of sight check was the target.
        /// </summary>
        /// <param name="position">The starting position of the line of sight.</param>
        /// <param name="target">The ending position of the line of sight.</param>
        /// <param name="hit">The hit information from the line of sight check.</param>
        /// <param name="radius">How wide of a sphere to cast.</param>
        /// <param name="mask">The optional layer mask.</param>
        /// <param name="triggers">How the check should handle hitting triggers.</param>
        /// <returns>If there is a direct line of sight with a given radius from a starting position to an end position, or the hit during the line of sight check was the target.</returns>
        public static bool HasSight([NotNull] this GameObject position, [NotNull] Transform target, out RaycastHit hit, float radius, int mask = -5, QueryTriggerInteraction triggers = QueryTriggerInteraction.UseGlobal) => position.transform.position.HasSight(target, out hit, radius, mask, triggers);
        
        /// <summary>
        /// If there is a direct line of sight with a given radius from a starting position to an end position, or the hit during the line of sight check was the target.
        /// </summary>
        /// <param name="position">The starting position of the line of sight.</param>
        /// <param name="target">The ending position of the line of sight.</param>
        /// <param name="hit">The hit information from the line of sight check.</param>
        /// <param name="radius">How wide of a sphere to cast.</param>
        /// <param name="mask">The optional layer mask.</param>
        /// <param name="triggers">How the check should handle hitting triggers.</param>
        /// <returns>If there is a direct line of sight with a given radius from a starting position to an end position, or the hit during the line of sight check was the target.</returns>
        public static bool HasSight([NotNull] this GameObject position, [NotNull] Component target, out RaycastHit hit, float radius, int mask = -5, QueryTriggerInteraction triggers = QueryTriggerInteraction.UseGlobal) => position.transform.position.HasSight(target.transform, out hit, radius, mask, triggers);
        
        /// <summary>
        /// If there is a direct line of sight with a given radius from a starting position to an end position, or the hit during the line of sight check was the target.
        /// </summary>
        /// <param name="position">The starting position of the line of sight.</param>
        /// <param name="target">The ending position of the line of sight.</param>
        /// <param name="hit">The hit information from the line of sight check.</param>
        /// <param name="radius">How wide of a sphere to cast.</param>
        /// <param name="mask">The optional layer mask.</param>
        /// <param name="triggers">How the check should handle hitting triggers.</param>
        /// <returns>If there is a direct line of sight with a given radius from a starting position to an end position, or the hit during the line of sight check was the target.</returns>
        public static bool HasSight([NotNull] this GameObject position, [NotNull] GameObject target, out RaycastHit hit, float radius, int mask = -5, QueryTriggerInteraction triggers = QueryTriggerInteraction.UseGlobal) => position.transform.position.HasSight(target.transform, out hit, radius, mask, triggers);
        
        /// <summary>
        /// Perform a raycast.
        /// </summary>
        /// <param name="position">The starting position of the cast.</param>
        /// <param name="direction">The ending position of the cast.</param>
        /// <param name="hit">The hit information from the cast.</param>
        /// <param name="distance">The distance for the cast.</param>
        /// <param name="mask">The optional layer mask.</param>
        /// <param name="triggers">How the cast should handle hitting triggers.</param>
        /// <returns>If the cast hit a collider or not.</returns>
        public static bool Raycast(this Vector3 position, Vector3 direction, out RaycastHit hit, float distance = float.MaxValue, int mask = -5, QueryTriggerInteraction triggers = QueryTriggerInteraction.UseGlobal) => Physics.Raycast(position, direction, out hit, distance, mask, triggers);
    }
}