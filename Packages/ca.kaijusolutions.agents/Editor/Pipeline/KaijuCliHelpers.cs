#if UNITY_EDITOR
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using Newtonsoft.Json.Linq;
using UnityEditor;
using UnityEngine;
using UnityEngine.AI;

namespace KaijuSolutions.Agents.Pipeline.Editor
{
    /// <summary>
    /// Helper methods for Pipeline parsing.
    /// </summary>
    public static class KaijuCliHelpers
    {
        internal static Vector3 ReadPosition(JObject options)
        {
            if (options?["worldPosition"] is JToken world)
            {
                if (options["position"] != null) throw new System.ArgumentException("Choose worldPosition or position.");
                return world.ToObject<Vector3>();
            }
            var planar = options?["position"]?.ToObject<Vector2>() ?? Vector2.zero;
            return new Vector3(planar.x, 0, planar.y);
        }

        /// <summary>
        /// Extract an array from the Pipeline client.
        /// </summary>
        /// <param name="params">The parameters returned by the Pipeline client.</param>
        /// <param name="name">The name of the parameter to get the array from.</param>
        /// <typeparam name="T">The type of parameters to extract.</typeparam>
        /// <returns>The parsed array or NULL if there were no parameters or there was an error.</returns>
        public static T[] GetArray<T>(JObject @params, string name) 
        {
            // See if the parameters exist.
            if (@params == null || !@params.TryGetValue(name, out JToken itemsToken))
            {
                return null;
            }

            switch (itemsToken.Type)
            {
                // Handle double-serialized strings.
                case JTokenType.String:
                    try
                    {
                        return JArray.Parse(itemsToken.ToString()).Select(item => item.ToObject<T>()).ToArray();
                    }
                    catch
                    {
                        return null;
                    }
                // Handle standard arrays.
                case JTokenType.Array:
                    List<T> parsedItems = new();
                    
                    // Address the edge case of a 1-element array where that 1 element is a stringified array.
                    JArray innerArray = (JArray)itemsToken;
                    if (innerArray.Count == 1 && innerArray[0].Type == JTokenType.String && innerArray[0].ToString().Trim().StartsWith("["))
                    {
                        try
                        {
                            parsedItems.AddRange(JArray.Parse(innerArray[0].ToString()).Select(item => item.ToObject<T>()));
                        } 
                        catch 
                        { 
                            // Fallback to attempting to cast the single item directly.
                            try
                            {
                                parsedItems.Add(innerArray[0].ToObject<T>());
                            }
                            catch
                            {
                                // Ignored.
                            }
                        }
                    }
                    
                    // Standard parsing if it wasn't caught by the nested string block above
                    if (parsedItems.Count < 1)
                    {
                        foreach (JToken item in innerArray)
                        {
                            try 
                            {
                                parsedItems.Add(item.ToObject<T>());
                            }
                            catch
                            {
                                return null;
                            }
                        }
                    }
                    
                    return parsedItems.ToArray();
                case JTokenType.None:
                case JTokenType.Object:
                case JTokenType.Constructor:
                case JTokenType.Property:
                case JTokenType.Comment:
                case JTokenType.Integer:
                case JTokenType.Float:
                case JTokenType.Boolean:
                case JTokenType.Null:
                case JTokenType.Undefined:
                case JTokenType.Date:
                case JTokenType.Raw:
                case JTokenType.Bytes:
                case JTokenType.Guid:
                case JTokenType.Uri:
                case JTokenType.TimeSpan:
                default:
                    return null;
            }
        }
        
        /// <summary>
        /// Helper method to place a wall.
        /// </summary>
        /// <param name="parameters">The placing parameters.</param>
        /// <returns>The placed wall.</returns>
        public static GameObject PlaceWall([NotNull] KaijuCliPlaceWall.Parameters parameters)
        {
            GameObject wall = GameObject.CreatePrimitive(PrimitiveType.Cube);
            parameters.scale = new(Mathf.Max(Mathf.Abs(parameters.scale.x), float.Epsilon), Mathf.Max(Mathf.Abs(parameters.scale.y), float.Epsilon), Mathf.Max(Mathf.Abs(parameters.scale.z), float.Epsilon));
            wall.transform.localScale = parameters.scale;
            wall.transform.position = (parameters.worldPosition ?? new Vector3(parameters.position.x, 0, parameters.position.y)) + Vector3.up * (parameters.scale.y / 2f);
            wall.GetComponent<MeshRenderer>().material = KaijuAgents.GetMaterial(parameters.color);
            wall.name = string.IsNullOrWhiteSpace(parameters.name) ? "Wall" : parameters.name;
            wall.isStatic = true;
            
            // Add and set up the NavMeshObstacle.
            NavMeshObstacle obstacle = wall.AddComponent<NavMeshObstacle>();
            obstacle.carving = true;
            obstacle.carveOnlyStationary = true;
            obstacle.shape = NavMeshObstacleShape.Box;
            if (!Application.isPlaying) Undo.RegisterCreatedObjectUndo(wall, "Create Kaiju scene object");
            return wall;
        }
    }
}
#endif