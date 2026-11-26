using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using Unity.Entities;
using UnityEngine;

namespace KaijuSolutions.Agents
{
    /// <summary>GameObject lookup and pooling state belonging to a simulation world.</summary>
    internal sealed class KaijuAgentRegistry
    {
        private const float CellSize = 8f;
        private readonly Dictionary<Vector2Int, List<KaijuAgent>> cells = new();
        private readonly Stack<List<KaijuAgent>> spareCells = new();
        private bool sensing;
        private bool indexed;

        internal void BeginSensing() { sensing = true; indexed = false; }
        internal void EndSensing()
        {
            sensing = false;
            if (!indexed) return;
            foreach (var bucket in cells.Values)
            {
                bucket.Clear();
                spareCells.Push(bucket);
            }
            cells.Clear();
            indexed = false;
        }

        private static Vector2Int Cell(Vector3 point) =>
            new(Mathf.FloorToInt(point.x / CellSize), Mathf.FloorToInt(point.z / CellSize));

        internal int FindNearby(Vector3 origin, float radius, List<KaijuAgent> results, bool spherical)
        {
            results.Clear();
            if (!(radius >= 0)) return 0;
            int examined = 0;
            float square = radius * radius;
            void Consider(KaijuAgent agent)
            {
                examined++;
                if (!agent) return;
                var offset = agent.Position3 - origin;
                if (!spherical) offset.y = 0;
                if (offset.sqrMagnitude <= square) results.Add(agent);
            }
            // Large searches cost less as a linear scan. Manual queries use live positions.
            if (!sensing || radius > CellSize * 16)
            {
                foreach (var agent in AllAgents) Consider(agent);
                return examined;
            }
            if (!indexed)
            {
                foreach (var agent in AllAgents)
                {
                    if (!agent) continue;
                    var key = Cell(agent.Position3);
                    if (!cells.TryGetValue(key, out var bucket))
                    {
                        bucket = spareCells.Count > 0 ? spareCells.Pop() : new List<KaijuAgent>();
                        cells.Add(key, bucket);
                    }
                    bucket.Add(agent);
                }
                indexed = true;
            }
            var min = Cell(origin - Vector3.one * radius);
            var max = Cell(origin + Vector3.one * radius);
            for (long x = min.x; x <= max.x; x++)
                for (long z = min.y; z <= max.y; z++)
                    if (cells.TryGetValue(new Vector2Int((int)x, (int)z), out var bucket))
                        foreach (var agent in bucket) Consider(agent);
            return examined;
        }

        /// <summary>
        /// Cache <see cref="KaijuSolutions.Agents.KaijuAgent"/>s paired to their identifiers.
        /// </summary>
        private readonly Dictionary<uint, HashSet<KaijuAgent>> AgentIdentifiers = new();
        
        /// <summary>
        /// All <see cref="KaijuSolutions.Agents.KaijuAgent"/>s.
        /// </summary>
        internal IReadOnlyCollection<KaijuAgent> Agents
        {
            get
            {
#if UNITY_EDITOR
                if (!Application.isPlaying)
                {
                    return Array.Empty<KaijuAgent>();
                }
#endif
                return AllAgents;
            }
        }

        /// <summary>
        /// The number of <see cref="KaijuSolutions.Agents.KaijuAgent"/>s.
        /// </summary>
        internal int AgentsCount
        {
            get
            {
#if UNITY_EDITOR
                if (!Application.isPlaying)
                {
                    return 0;
                }
#endif
                return AllAgents.Count;
            }
        }

        /// <summary>
        /// Cache all <see cref="KaijuSolutions.Agents.KaijuAgent"/>s.
        /// </summary>
        private readonly HashSet<KaijuAgent> AllAgents = new();
        
        
        /// <summary>
        /// Cache <see cref="KaijuSolutions.Agents.KaijuAgent"/>s which have been disabled for reuse.
        /// </summary>
        private readonly Dictionary<(Type, KaijuAgent), HashSet<KaijuAgent>> DisabledAgents = new();
        
        /// <summary>
        /// Helper empty <see cref="KaijuSolutions.Agents.KaijuAgent"/>s array for returning defaults.
        /// </summary>
        private readonly KaijuAgent[] EmptyAgents = Array.Empty<KaijuAgent>();
        
        /// <summary>
        /// Pending <see cref="KaijuSolutions.Agents.KaijuAgent"/>s to handle the spawning of.
        /// </summary>
        private readonly HashSet<KaijuAgent> PendingAdditions = new();
        
        /// <summary>
        /// Pending <see cref="KaijuSolutions.Agents.KaijuAgent"/>s to handle the removal of.
        /// </summary>
        private readonly HashSet<KaijuAgent> PendingRemovals = new();
        
        /// <summary>
        /// Pending <see cref="KaijuSolutions.Agents.KaijuAgent"/>s to handle the removal of and cache.
        /// </summary>
        private readonly HashSet<KaijuAgent> PendingCachedRemovals = new();
        /// <summary>
        /// Register an <see cref="KaijuSolutions.Agents.KaijuAgent"/> for movement.
        /// </summary>
        /// <param name="agent">The <see cref="KaijuSolutions.Agents.KaijuAgent"/> to register.</param>
        internal void Register(KaijuAgent agent)
        {
#if UNITY_EDITOR
            if (!Application.isPlaying)
            {
                return;
            }
#endif
            PendingRemovals.Remove(agent);
            PendingCachedRemovals.Remove(agent);
            
            // Remove from cached disabled.
            var type = (agent.GetType(), agent.PoolPrefab);
            if (DisabledAgents.TryGetValue(type, out HashSet<KaijuAgent> set))
            {
                set.Remove(agent);
                if (set.Count < 1)
                {
                    DisabledAgents.Remove(type);
                }
            }

            Application.runInBackground = true;
            PendingAdditions.Add(agent);
        }
        
        /// <summary>
        /// Unregister an <see cref="KaijuSolutions.Agents.KaijuAgent"/> for movement.
        /// </summary>
        /// <param name="agent">The <see cref="KaijuSolutions.Agents.KaijuAgent"/> to unregister.</param>
        /// <param name="cache">If this <see cref="KaijuSolutions.Agents.KaijuAgent"/> should be cached.</param>
        internal void Unregister(KaijuAgent agent, bool cache = true)
        {
#if UNITY_EDITOR
            if (!Application.isPlaying)
            {
                return;
            }
            
#endif
            PendingAdditions.Remove(agent);
            PendingCachedRemovals.Remove(agent);
            if (cache)
            {
                PendingCachedRemovals.Add(agent);
            }
            else
            {
                PendingRemovals.Add(agent);
            }
        }
        
        /// <summary>
        /// Handle all pending agents.
        /// </summary>
        internal void HandlePending(EntityManager entities)
        {
            foreach (KaijuAgent agent in PendingAdditions)
            {
                AllAgents.Add(agent);
                
                // Add identifiers.
                foreach (uint identifier in agent.Identifiers)
                {
                    AddIdentifier(agent, identifier);
                }
                
                agent.AttachEntity(entities);
            }
            
            PendingAdditions.Clear();
            
            foreach (KaijuAgent agent in PendingCachedRemovals)
            {
                AllAgents.Remove(agent);
                
                // Remove identifiers.
                foreach (uint identifier in agent.Identifiers)
                {
                    RemoveIdentifier(agent, identifier);
                }
                
                agent.DetachEntity(entities);
                
                // Cache for reuse.
                var type = (agent.GetType(), agent.PoolPrefab);
                if (!DisabledAgents.TryGetValue(type, out HashSet<KaijuAgent> set))
                {
                    set = new(1);
                    DisabledAgents.Add(type, set);
                }
                
                set.Add(agent);
            }
            
            PendingCachedRemovals.Clear();
            
            foreach (KaijuAgent agent in PendingRemovals)
            {
                AllAgents.Remove(agent);
                
                // Remove identifiers.
                foreach (uint identifier in agent.Identifiers)
                {
                    RemoveIdentifier(agent, identifier);
                }
                
                agent.DetachEntity(entities);
                
                // Ensure this is not cached.
                var type = (agent.GetType(), agent.PoolPrefab);
                if (!DisabledAgents.TryGetValue(type, out HashSet<KaijuAgent> set))
                {
                    continue;
                }
                
                if (set.Remove(agent) && set.Count < 1)
                {
                    DisabledAgents.Remove(type);
                }
            }
            
            PendingRemovals.Clear();
        }
        
        /// <summary>
        /// Get a cached <see cref="KaijuSolutions.Agents.KaijuAgent"/> to spawn.
        /// </summary>
        /// <param name="components">All components which must be found on the <see cref="KaijuSolutions.Agents.KaijuAgent"/>. This will check in children as well.</param>
        /// <typeparam name="T">The type of <see cref="KaijuSolutions.Agents.KaijuAgent"/>.</typeparam>
        /// <returns>A cached <see cref="KaijuSolutions.Agents.KaijuAgent"/> if one is found, otherwise NULL.</returns>
        internal T GetCached<T>(ICollection<string> components = null, bool? flight = null, KaijuAgent prefab = null) where T : KaijuAgent
        {
#if UNITY_EDITOR
            if (!Application.isPlaying)
            {
                return null;
            }
#endif
            // Nothing to do if no cached agents.
            var type = (prefab ? prefab.GetType() : typeof(T), prefab);
            if (!DisabledAgents.TryGetValue(type, out HashSet<KaijuAgent> set))
            {
                return null;
            }
            
            KaijuAgent agent = null;
            foreach (KaijuAgent candidate in set)
            {
                // Disabled agents have detached their ECS bridge. Check their authored mode.
                if (flight.HasValue && (candidate.TryGetComponent<KaijuFreeFlight>(out var module) && module.enabled) != flight.Value)
                    continue;
                if (components == null || components.Count == 0)
                {
                    agent = candidate;
                    break;
                }
                // Get all types on the agent and its children. As this object is inactive, get all inactive items.
                Component[] attached = candidate.GetComponentsInChildren<Component>(includeInactive: true);
                Type[] types = new Type[attached.Length];
                for (int i = 0; i < attached.Length; i++)
                {
                    types[i] = attached[i].GetType();
                }
                
                // See if this agent has all the components we need.
                bool valid = true;
                foreach (string c in components)
                {
                    // For each component, assume it does not have it until it is found.
                    valid = false;
                    foreach (Type exists in types)
                    {
                        if (c != exists.Name && c != exists.FullName)
                        {
                            continue;
                        }
                        
                        // If we found a match, stop looking for that one.
                        valid = true;
                        break;
                    }
                    
                    // If the component was not found, rule this out as a candidate and try the next one.
                    if (!valid)
                    {
                        break;
                    }
                }
                
                // If this candidate passed the requirements, use it.
                if (!valid)
                {
                    continue;
                }
                
                agent = candidate;
                break;
            }
            if (agent) set.Remove(agent);
            
            // If this set is now empty, remove it.
            if (set.Count < 1)
            {
                DisabledAgents.Remove(type);
            }
            
            return agent != null ? agent as T : null;
        }
        
        /// <summary>
        /// Add an identifier to an <see cref="KaijuSolutions.Agents.KaijuAgent"/>. There is no use for manually calling this.
        /// </summary>
        /// <param name="agent">The <see cref="KaijuSolutions.Agents.KaijuAgent"/>.</param>
        /// <param name="identifier">The identifier.</param>
        internal void AddIdentifier(KaijuAgent agent, uint identifier)
        {
#if UNITY_EDITOR
            if (!Application.isPlaying)
            {
                return;
            }
#endif
            if (!AgentIdentifiers.TryGetValue(identifier, out HashSet<KaijuAgent> set))
            {
                set = new();
                AgentIdentifiers.Add(identifier, set);
            }
            
            set.Add(agent);
        }
        
        /// <summary>
        /// Remove an identifier from an <see cref="KaijuSolutions.Agents.KaijuAgent"/>. There is no use for manually calling this.
        /// </summary>
        /// <param name="agent">The <see cref="KaijuSolutions.Agents.KaijuAgent"/>.</param>
        /// <param name="identifier">The identifier.</param>
        internal void RemoveIdentifier(KaijuAgent agent, uint identifier)
        {
#if UNITY_EDITOR
            if (!Application.isPlaying)
            {
                return;
            }
#endif
            if (!AgentIdentifiers.TryGetValue(identifier, out HashSet<KaijuAgent> set))
            {
                return;
            }
            
            set.Remove(agent);
            if (set.Count < 1)
            {
                AgentIdentifiers.Remove(identifier);
            }
        }
        
        /// <summary>
        /// Get all <see cref="KaijuSolutions.Agents.KaijuAgent"/>s with a given identifier.
        /// </summary>
        /// <param name="identifier">The identifier.</param>
        /// <returns>All <see cref="KaijuSolutions.Agents.KaijuAgent"/>s with a given identifier.</returns>
        internal IReadOnlyCollection<KaijuAgent> IdentifiedAgents(uint identifier)
        {
#if UNITY_EDITOR
            if (!Application.isPlaying)
            {
                return Array.Empty<KaijuAgent>();
            }
#endif
            return AgentIdentifiers.TryGetValue(identifier, out HashSet<KaijuAgent> set) ? set : EmptyAgents;
        }
        
        /// <summary>
        /// Get all <see cref="KaijuSolutions.Agents.KaijuAgent"/>s which have any of the given identifiers. The <see cref="KaijuSolutions.Agents.KaijuAgent"/>s are added to the identified parameter.
        /// </summary>
        /// <param name="identified">Updated to contain all <see cref="KaijuSolutions.Agents.KaijuAgent"/>s which were identified.</param>
        /// <param name="identifiers">The identifiers.</param>
        internal void IdentifiedAgents([NotNull] ICollection<KaijuAgent> identified, [NotNull] IEnumerable<uint> identifiers)
        {
#if UNITY_EDITOR
            if (!Application.isPlaying)
            {
                return;
            }
#endif
            identified.Clear();
            
            foreach (uint identifier in identifiers)
            {
                if (!AgentIdentifiers.TryGetValue(identifier, out HashSet<KaijuAgent> set))
                {
                    continue;
                }
                
                foreach (KaijuAgent agent in set)
                {
                    identified.Add(agent);
                }
            }
        }
        
        /// <summary>
        /// Get all <see cref="KaijuSolutions.Agents.KaijuAgent"/>s which have any of the given identifiers.
        /// </summary>
        /// <param name="identifiers">The identifiers.</param>
        /// <returns>All <see cref="KaijuSolutions.Agents.KaijuAgent"/>s which have any of the given identifier.</returns>
        internal HashSet<KaijuAgent> IdentifiedAgents([NotNull] IEnumerable<uint> identifiers)
        {
#if UNITY_EDITOR
            if (!Application.isPlaying)
            {
                return new();
            }
#endif
            HashSet<KaijuAgent> identified = new();
            IdentifiedAgents(identified, identifiers);
            return identified;
        }
#if UNITY_EDITOR
        /// <summary>
        /// Validate the identifiers of an <see cref="KaijuSolutions.Agents.KaijuAgent"/> in the editor. There is no use for manually calling this.
        /// </summary>
        /// <param name="agent">The <see cref="KaijuSolutions.Agents.KaijuAgent"/>.</param>
        internal void EditorValidateIdentifiers(KaijuAgent agent)
        {
            // Store empty instances.
            HashSet<uint> empty = new(AgentIdentifiers.Count);
            
            // Remove all currently cached identifiers.
            foreach (KeyValuePair<uint, HashSet<KaijuAgent>> pair in AgentIdentifiers)
            {
                // Mark if this set is now empty.
                if (AgentIdentifiers[pair.Key].Remove(agent) && AgentIdentifiers[pair.Key].Count < 1)
                {
                    empty.Add(pair.Key);
                }
            }
            
            // Add all new identifiers, flagging ones which are no longer empty.
            foreach (uint identifier in agent.Identifiers)
            {
                AddIdentifier(agent, identifier);
                empty.Remove(identifier);
            }
            
            // Remove empty sets.
            foreach (uint identifier in empty)
            {
                AgentIdentifiers.Remove(identifier);
            }
        }
#endif
    }
}
