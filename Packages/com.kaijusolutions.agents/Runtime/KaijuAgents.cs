using System.Collections.Generic;
using System.Linq;
using UnityEngine;

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
            
            // Find the Standard Shader.
            Shader standardShader = Shader.Find("Standard");
            
            // Create a new Material with the shader.
            material = new(standardShader)
            {
                color = color
            };
            
            // Set to opaque with no smoothness or metallic properties.
            material.SetFloat(Mode, 0);
            material.SetFloat(Glossiness, 0);
            material.SetFloat(Metallic, 0);
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
        public static bool AssignComponent<T>(this GameObject go, ref T current, bool self = true, bool children = false, bool parents = false) where T : Component
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
        public static bool AssignComponent<T>(this Component c, ref T current, bool self = true, bool children = false, bool parents = false) where T : Component
        {
            return c.gameObject.AssignComponent(ref current, self, children, parents);
        }
        
        public static KaijuAgent Spawn(Vector3 position, Quaternion orientation, bool cached = true, KaijuAgent prefab = null, string name = null, Color? body = null, Color? eyes = null)
        {
            KaijuAgent agent;
            
            // If we can use a cached agent, do so.
            if (cached)
            {
                agent = KaijuAgentsManager.GetCached();
                
                // If there is a cached agent, work with it.
                if (agent != null)
                {
                    if (name != null)
                    {
                        agent.name = name;
                    }
                    
                    // If this is a default agent, and we passed a desired color, assign it.
                    if (body.HasValue || eyes.HasValue)
                    {
                        Transform t = agent.transform;
                        for (int i = 0; i < t.childCount; i++)
                        {
                            Transform child = agent.transform.GetChild(i);
                            
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
                    
                    // Reactive this agent.
                    agent.gameObject.SetActive(true);
                    agent.enabled = true;
                    return agent;
                }
            }
            
            if (prefab != null)
            {
                agent = Object.Instantiate(prefab, position, orientation);
                agent.name = name ?? "Agent";
            }
            else
            {
                // Create the agent.
                GameObject go = new(name ?? "Agent");
                agent = go.AddComponent<KaijuRigidbodyAgent>(); // TODO - Type.
                Transform visuals = CreateCapsule(agent.transform, Vector3.one, Quaternion.identity, Vector3.one, body ?? Body, "Body");
                CreateCapsule(visuals, new(0, 0.5f, 0.225f), Quaternion.Euler(0, 0, 90f), new(0.5f, 0.5f, 0.5f), eyes ?? Eyes, "Eyes");
            }
            
            return agent;
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
    }
}