using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using UnityEngine;

namespace KaijuSolutions.Agents.Extensions
{
    /// <summary>
    /// Comparer class to sort by angle in degrees from a position towards a target around the global Y axis. Used in the extension methods found in <see cref="KaijuAgentsSortAngle"/>.
    /// </summary>
    public sealed class KaijuAgentsAngleSorter : IComparer<Vector2>, IComparer<Vector3>, IComparer<Transform>, IComparer<Component>, IComparer<GameObject>
    {
        /// <summary>
        /// The position to compare against.
        /// </summary>
        public Vector3 Position3
        {
            get => Position.Expand();
            set => Position = value.Flatten();
        }
        
        /// <summary>
        /// The position to compare against. The forward direction will be taken from this as well.
        /// </summary>
        public Transform PositionTransform
        {
            set
            {
                Position = value.Flatten();
                Forward = value.forward.Flatten();
            }
        }
        
        /// <summary>
        /// The position to compare against. The forward direction will be taken from this as well.
        /// </summary>
        public Component PositionComponent
        {
            set => PositionTransform = value.transform;
        }
        
        /// <summary>
        /// The position to compare against. The forward direction will be taken from this as well.
        /// </summary>
        public GameObject PositionGameObject
        {
            set => PositionTransform = value.transform;
        }
        
        /// <summary>
        /// The position to compare against.
        /// </summary>
        public Vector2 Position;
        
        /// <summary>
        /// The forward direction to compare with.
        /// </summary>
        public Vector2 Forward;
        
        /// <summary>
        /// How to handle sorting.
        /// </summary>
        public KaijuAngleSortMode Mode;
        
        /// <summary>
        /// How to handle breaking ties by distance. NULL means no tie breaking, false for nearest distance, and true for farthest distance.
        /// </summary>
        public bool? Farthest;
        
        /// <summary>
        /// Create the sorter.
        /// </summary>
        public KaijuAgentsAngleSorter()
        {
            Position = Vector2.zero;
            Forward = Vector2.zero;
            Mode = KaijuAngleSortMode.Magnitude;
            Farthest = null;
        }
        
        /// <summary>
        /// Create the sorter.
        /// </summary>
        /// <param name="position">The position to compare against.</param>
        /// <param name="forward">The forward direction to compare with.</param>
        /// <param name="mode">How to handle sorting.</param>
        /// <param name="farthest">How to handle breaking ties by distance. NULL means no tie breaking, false for nearest distance, and true for farthest distance.</param>
        public KaijuAgentsAngleSorter(Vector2 position, Vector2 forward, KaijuAngleSortMode mode = KaijuAngleSortMode.Magnitude, bool? farthest = null)
        {
            Set(position, forward, mode, farthest);
        }
        
        /// <summary>
        /// Create the sorter.
        /// </summary>
        /// <param name="position">The position to compare against.</param>
        /// <param name="forward">The forward direction to compare with.</param>
        /// <param name="mode">How to handle sorting.</param>
        /// <param name="farthest">How to handle breaking ties by distance. NULL means no tie breaking, false for nearest distance, and true for farthest distance.</param>
        public KaijuAgentsAngleSorter(Vector2 position, Vector3 forward, KaijuAngleSortMode mode = KaijuAngleSortMode.Magnitude, bool? farthest = null)
        {
            Set(position, forward, mode, farthest);
        }
        
        /// <summary>
        /// Create the sorter.
        /// </summary>
        /// <param name="position">The position to compare against.</param>
        /// <param name="forward">The forward direction to compare with.</param>
        /// <param name="mode">How to handle sorting.</param>
        /// <param name="farthest">How to handle breaking ties by distance. NULL means no tie breaking, false for nearest distance, and true for farthest distance.</param>
        public KaijuAgentsAngleSorter(Vector2 position, [NotNull] Transform forward, KaijuAngleSortMode mode = KaijuAngleSortMode.Magnitude, bool? farthest = null)
        {
            Set(position, forward, mode, farthest);
        }
        
        /// <summary>
        /// Create the sorter.
        /// </summary>
        /// <param name="position">The position to compare against.</param>
        /// <param name="forward">The forward direction to compare with.</param>
        /// <param name="mode">How to handle sorting.</param>
        /// <param name="farthest">How to handle breaking ties by distance. NULL means no tie breaking, false for nearest distance, and true for farthest distance.</param>
        public KaijuAgentsAngleSorter(Vector2 position, [NotNull] Component forward, KaijuAngleSortMode mode = KaijuAngleSortMode.Magnitude, bool? farthest = null)
        {
            Set(position, forward, mode, farthest);
        }
        
        /// <summary>
        /// Create the sorter.
        /// </summary>
        /// <param name="position">The position to compare against.</param>
        /// <param name="forward">The forward direction to compare with.</param>
        /// <param name="mode">How to handle sorting.</param>
        /// <param name="farthest">How to handle breaking ties by distance. NULL means no tie breaking, false for nearest distance, and true for farthest distance.</param>
        public KaijuAgentsAngleSorter(Vector2 position, [NotNull] GameObject forward, KaijuAngleSortMode mode = KaijuAngleSortMode.Magnitude, bool? farthest = null)
        {
            Set(position, forward, mode, farthest);
        }
        
        /// <summary>
        /// Create the sorter.
        /// </summary>
        /// <param name="position">The position to compare against.</param>
        /// <param name="forward">The forward direction to compare with.</param>
        /// <param name="mode">How to handle sorting.</param>
        /// <param name="farthest">How to handle breaking ties by distance. NULL means no tie breaking, false for nearest distance, and true for farthest distance.</param>
        public KaijuAgentsAngleSorter(Vector3 position, Vector2 forward, KaijuAngleSortMode mode = KaijuAngleSortMode.Magnitude, bool? farthest = null)
        {
            Set(position, forward, mode, farthest);
        }
        
        /// <summary>
        /// Create the sorter.
        /// </summary>
        /// <param name="position">The position to compare against.</param>
        /// <param name="forward">The forward direction to compare with.</param>
        /// <param name="mode">How to handle sorting.</param>
        /// <param name="farthest">How to handle breaking ties by distance. NULL means no tie breaking, false for nearest distance, and true for farthest distance.</param>
        public KaijuAgentsAngleSorter(Vector3 position, Vector3 forward, KaijuAngleSortMode mode = KaijuAngleSortMode.Magnitude, bool? farthest = null)
        {
            Set(position, forward, mode, farthest);
        }
        
        /// <summary>
        /// Create the sorter.
        /// </summary>
        /// <param name="position">The position to compare against.</param>
        /// <param name="forward">The forward direction to compare with.</param>
        /// <param name="mode">How to handle sorting.</param>
        /// <param name="farthest">How to handle breaking ties by distance. NULL means no tie breaking, false for nearest distance, and true for farthest distance.</param>
        public KaijuAgentsAngleSorter(Vector3 position, [NotNull] Transform forward, KaijuAngleSortMode mode = KaijuAngleSortMode.Magnitude, bool? farthest = null)
        {
            Set(position, forward, mode, farthest);
        }
        
        /// <summary>
        /// Create the sorter.
        /// </summary>
        /// <param name="position">The position to compare against.</param>
        /// <param name="forward">The forward direction to compare with.</param>
        /// <param name="mode">How to handle sorting.</param>
        /// <param name="farthest">How to handle breaking ties by distance. NULL means no tie breaking, false for nearest distance, and true for farthest distance.</param>
        public KaijuAgentsAngleSorter(Vector3 position, [NotNull] Component forward, KaijuAngleSortMode mode = KaijuAngleSortMode.Magnitude, bool? farthest = null)
        {
            Set(position, forward, mode, farthest);
        }
        
        /// <summary>
        /// Create the sorter.
        /// </summary>
        /// <param name="position">The position to compare against.</param>
        /// <param name="forward">The forward direction to compare with.</param>
        /// <param name="mode">How to handle sorting.</param>
        /// <param name="farthest">How to handle breaking ties by distance. NULL means no tie breaking, false for nearest distance, and true for farthest distance.</param>
        public KaijuAgentsAngleSorter(Vector3 position, [NotNull] GameObject forward, KaijuAngleSortMode mode = KaijuAngleSortMode.Magnitude, bool? farthest = null)
        {
            Set(position, forward, mode, farthest);
        }
        
        /// <summary>
        /// Create the sorter.
        /// </summary>
        /// <param name="position">The position to compare against.</param>
        /// <param name="forward">The forward direction to compare with.</param>
        /// <param name="mode">How to handle sorting.</param>
        /// <param name="farthest">How to handle breaking ties by distance. NULL means no tie breaking, false for nearest distance, and true for farthest distance.</param>
        public KaijuAgentsAngleSorter([NotNull] Transform position, Vector2 forward, KaijuAngleSortMode mode = KaijuAngleSortMode.Magnitude, bool? farthest = null)
        {
            Set(position, forward, mode, farthest);
        }
        
        /// <summary>
        /// Create the sorter.
        /// </summary>
        /// <param name="position">The position to compare against.</param>
        /// <param name="forward">The forward direction to compare with.</param>
        /// <param name="mode">How to handle sorting.</param>
        /// <param name="farthest">How to handle breaking ties by distance. NULL means no tie breaking, false for nearest distance, and true for farthest distance.</param>
        public KaijuAgentsAngleSorter([NotNull] Transform position, Vector3 forward, KaijuAngleSortMode mode = KaijuAngleSortMode.Magnitude, bool? farthest = null)
        {
            Set(position, forward, mode, farthest);
        }
        
        /// <summary>
        /// Create the sorter.
        /// </summary>
        /// <param name="position">The position to compare against.</param>
        /// <param name="forward">The forward direction to compare with.</param>
        /// <param name="mode">How to handle sorting.</param>
        /// <param name="farthest">How to handle breaking ties by distance. NULL means no tie breaking, false for nearest distance, and true for farthest distance.</param>
        public KaijuAgentsAngleSorter([NotNull] Transform position, [NotNull] Transform forward, KaijuAngleSortMode mode = KaijuAngleSortMode.Magnitude, bool? farthest = null)
        {
            Set(position, forward, mode, farthest);
        }
        
        /// <summary>
        /// Create the sorter.
        /// </summary>
        /// <param name="position">The position to compare against.</param>
        /// <param name="forward">The forward direction to compare with.</param>
        /// <param name="mode">How to handle sorting.</param>
        /// <param name="farthest">How to handle breaking ties by distance. NULL means no tie breaking, false for nearest distance, and true for farthest distance.</param>
        public KaijuAgentsAngleSorter([NotNull] Transform position, [NotNull] Component forward, KaijuAngleSortMode mode = KaijuAngleSortMode.Magnitude, bool? farthest = null)
        {
            Set(position, forward, mode, farthest);
        }
        
        /// <summary>
        /// Create the sorter.
        /// </summary>
        /// <param name="position">The position to compare against.</param>
        /// <param name="forward">The forward direction to compare with.</param>
        /// <param name="mode">How to handle sorting.</param>
        /// <param name="farthest">How to handle breaking ties by distance. NULL means no tie breaking, false for nearest distance, and true for farthest distance.</param>
        public KaijuAgentsAngleSorter([NotNull] Transform position, [NotNull] GameObject forward, KaijuAngleSortMode mode = KaijuAngleSortMode.Magnitude, bool? farthest = null)
        {
            Set(position, forward, mode, farthest);
        }
        
        /// <summary>
        /// Create the sorter.
        /// </summary>
        /// <param name="position">The position to compare against with its forward being used for the direction.</param>
        /// <param name="mode">How to handle sorting.</param>
        /// <param name="farthest">How to handle breaking ties by distance. NULL means no tie breaking, false for nearest distance, and true for farthest distance.</param>
        public KaijuAgentsAngleSorter([NotNull] Transform position, KaijuAngleSortMode mode = KaijuAngleSortMode.Magnitude, bool? farthest = null)
        {
            Set(position, mode, farthest);
        }
        
        /// <summary>
        /// Create the sorter.
        /// </summary>
        /// <param name="position">The position to compare against.</param>
        /// <param name="forward">The forward direction to compare with.</param>
        /// <param name="mode">How to handle sorting.</param>
        /// <param name="farthest">How to handle breaking ties by distance. NULL means no tie breaking, false for nearest distance, and true for farthest distance.</param>
        public KaijuAgentsAngleSorter([NotNull] Component position, Vector2 forward, KaijuAngleSortMode mode = KaijuAngleSortMode.Magnitude, bool? farthest = null)
        {
            Set(position, forward, mode, farthest);
        }
        
        /// <summary>
        /// Create the sorter.
        /// </summary>
        /// <param name="position">The position to compare against.</param>
        /// <param name="forward">The forward direction to compare with.</param>
        /// <param name="mode">How to handle sorting.</param>
        /// <param name="farthest">How to handle breaking ties by distance. NULL means no tie breaking, false for nearest distance, and true for farthest distance.</param>
        public KaijuAgentsAngleSorter([NotNull] Component position, Vector3 forward, KaijuAngleSortMode mode = KaijuAngleSortMode.Magnitude, bool? farthest = null)
        {
            Set(position, forward, mode, farthest);
        }
        
        /// <summary>
        /// Create the sorter.
        /// </summary>
        /// <param name="position">The position to compare against.</param>
        /// <param name="forward">The forward direction to compare with.</param>
        /// <param name="mode">How to handle sorting.</param>
        /// <param name="farthest">How to handle breaking ties by distance. NULL means no tie breaking, false for nearest distance, and true for farthest distance.</param>
        public KaijuAgentsAngleSorter([NotNull] Component position, [NotNull] Transform forward, KaijuAngleSortMode mode = KaijuAngleSortMode.Magnitude, bool? farthest = null)
        {
            Set(position, forward, mode, farthest);
        }
        
        /// <summary>
        /// Create the sorter.
        /// </summary>
        /// <param name="position">The position to compare against.</param>
        /// <param name="forward">The forward direction to compare with.</param>
        /// <param name="mode">How to handle sorting.</param>
        /// <param name="farthest">How to handle breaking ties by distance. NULL means no tie breaking, false for nearest distance, and true for farthest distance.</param>
        public KaijuAgentsAngleSorter([NotNull] Component position, [NotNull] Component forward, KaijuAngleSortMode mode = KaijuAngleSortMode.Magnitude, bool? farthest = null)
        {
            Set(position, forward, mode, farthest);
        }
        
        /// <summary>
        /// Create the sorter.
        /// </summary>
        /// <param name="position">The position to compare against.</param>
        /// <param name="forward">The forward direction to compare with.</param>
        /// <param name="mode">How to handle sorting.</param>
        /// <param name="farthest">How to handle breaking ties by distance. NULL means no tie breaking, false for nearest distance, and true for farthest distance.</param>
        public KaijuAgentsAngleSorter([NotNull] Component position, [NotNull] GameObject forward, KaijuAngleSortMode mode = KaijuAngleSortMode.Magnitude, bool? farthest = null)
        {
            Set(position, forward, mode, farthest);
        }
        
        /// <summary>
        /// Create the sorter.
        /// </summary>
        /// <param name="position">The position to compare against with its forward being used for the direction.</param>
        /// <param name="mode">How to handle sorting.</param>
        /// <param name="farthest">How to handle breaking ties by distance. NULL means no tie breaking, false for nearest distance, and true for farthest distance.</param>
        public KaijuAgentsAngleSorter([NotNull] Component position, KaijuAngleSortMode mode = KaijuAngleSortMode.Magnitude, bool? farthest = null)
        {
            Set(position, mode, farthest);
        }
        
        /// <summary>
        /// Create the sorter.
        /// </summary>
        /// <param name="position">The position to compare against.</param>
        /// <param name="forward">The forward direction to compare with.</param>
        /// <param name="mode">How to handle sorting.</param>
        /// <param name="farthest">How to handle breaking ties by distance. NULL means no tie breaking, false for nearest distance, and true for farthest distance.</param>
        public KaijuAgentsAngleSorter([NotNull] GameObject position, Vector2 forward, KaijuAngleSortMode mode = KaijuAngleSortMode.Magnitude, bool? farthest = null)
        {
            Set(position, forward, mode, farthest);
        }
        
        /// <summary>
        /// Create the sorter.
        /// </summary>
        /// <param name="position">The position to compare against.</param>
        /// <param name="forward">The forward direction to compare with.</param>
        /// <param name="mode">How to handle sorting.</param>
        /// <param name="farthest">How to handle breaking ties by distance. NULL means no tie breaking, false for nearest distance, and true for farthest distance.</param>
        public KaijuAgentsAngleSorter([NotNull] GameObject position, Vector3 forward, KaijuAngleSortMode mode = KaijuAngleSortMode.Magnitude, bool? farthest = null)
        {
            Set(position, forward, mode, farthest);
        }
        
        /// <summary>
        /// Create the sorter.
        /// </summary>
        /// <param name="position">The position to compare against.</param>
        /// <param name="forward">The forward direction to compare with.</param>
        /// <param name="mode">How to handle sorting.</param>
        /// <param name="farthest">How to handle breaking ties by distance. NULL means no tie breaking, false for nearest distance, and true for farthest distance.</param>
        public KaijuAgentsAngleSorter([NotNull] GameObject position, [NotNull] Transform forward, KaijuAngleSortMode mode = KaijuAngleSortMode.Magnitude, bool? farthest = null)
        {
            Set(position, forward, mode, farthest);
        }
        
        /// <summary>
        /// Create the sorter.
        /// </summary>
        /// <param name="position">The position to compare against.</param>
        /// <param name="forward">The forward direction to compare with.</param>
        /// <param name="mode">How to handle sorting.</param>
        /// <param name="farthest">How to handle breaking ties by distance. NULL means no tie breaking, false for nearest distance, and true for farthest distance.</param>
        public KaijuAgentsAngleSorter([NotNull] GameObject position, [NotNull] Component forward, KaijuAngleSortMode mode = KaijuAngleSortMode.Magnitude, bool? farthest = null)
        {
            Set(position, forward, mode, farthest);
        }
        
        /// <summary>
        /// Create the sorter.
        /// </summary>
        /// <param name="position">The position to compare against.</param>
        /// <param name="forward">The forward direction to compare with.</param>
        /// <param name="mode">How to handle sorting.</param>
        /// <param name="farthest">How to handle breaking ties by distance. NULL means no tie breaking, false for nearest distance, and true for farthest distance.</param>
        public KaijuAgentsAngleSorter([NotNull] GameObject position, [NotNull] GameObject forward, KaijuAngleSortMode mode = KaijuAngleSortMode.Magnitude, bool? farthest = null)
        {
            Set(position, forward, mode, farthest);
        }
        
        /// <summary>
        /// Create the sorter.
        /// </summary>
        /// <param name="position">The position to compare against with its forward being used for the direction.</param>
        /// <param name="mode">How to handle sorting.</param>
        /// <param name="farthest">How to handle breaking ties by distance. NULL means no tie breaking, false for nearest distance, and true for farthest distance.</param>
        public KaijuAgentsAngleSorter([NotNull] GameObject position, KaijuAngleSortMode mode = KaijuAngleSortMode.Magnitude, bool? farthest = null)
        {
            Set(position, mode, farthest);
        }
        
        /// <summary>
        /// Set values for the sorter.
        /// </summary>
        /// <param name="position">The position to compare against.</param>
        /// <param name="forward">The forward direction to compare with.</param>
        /// <param name="mode">How to handle sorting.</param>
        /// <param name="farthest">How to handle breaking ties by distance. NULL means no tie breaking, false for nearest distance, and true for farthest distance.</param>
        public void Set(Vector2 position, Vector2 forward, KaijuAngleSortMode mode = KaijuAngleSortMode.Magnitude, bool? farthest = null)
        {
            Position = position;
            Forward = forward;
            Mode = mode;
            Farthest = farthest;
        }
        
        /// <summary>
        /// Set values for the sorter.
        /// </summary>
        /// <param name="position">The position to compare against.</param>
        /// <param name="forward">The forward direction to compare with.</param>
        /// <param name="mode">How to handle sorting.</param>
        /// <param name="farthest">How to handle breaking ties by distance. NULL means no tie breaking, false for nearest distance, and true for farthest distance.</param>
        public void Set(Vector2 position, Vector3 forward, KaijuAngleSortMode mode = KaijuAngleSortMode.Magnitude, bool? farthest = null)
        {
            Set(position, forward.Flatten(), mode, farthest);
        }
        
        /// <summary>
        /// Set values for the sorter.
        /// </summary>
        /// <param name="position">The position to compare against.</param>
        /// <param name="forward">The forward direction to compare with.</param>
        /// <param name="mode">How to handle sorting.</param>
        /// <param name="farthest">How to handle breaking ties by distance. NULL means no tie breaking, false for nearest distance, and true for farthest distance.</param>
        public void Set(Vector2 position, [NotNull] Transform forward, KaijuAngleSortMode mode = KaijuAngleSortMode.Magnitude, bool? farthest = null)
        {
            Set(position, forward.Flatten(), mode, farthest);
        }
        
        /// <summary>
        /// Set values for the sorter.
        /// </summary>
        /// <param name="position">The position to compare against.</param>
        /// <param name="forward">The forward direction to compare with.</param>
        /// <param name="mode">How to handle sorting.</param>
        /// <param name="farthest">How to handle breaking ties by distance. NULL means no tie breaking, false for nearest distance, and true for farthest distance.</param>
        public void Set(Vector2 position, [NotNull] Component forward, KaijuAngleSortMode mode = KaijuAngleSortMode.Magnitude, bool? farthest = null)
        {
            Set(position, forward.Flatten(), mode, farthest);
        }
        
        /// <summary>
        /// Set values for the sorter.
        /// </summary>
        /// <param name="position">The position to compare against.</param>
        /// <param name="forward">The forward direction to compare with.</param>
        /// <param name="mode">How to handle sorting.</param>
        /// <param name="farthest">How to handle breaking ties by distance. NULL means no tie breaking, false for nearest distance, and true for farthest distance.</param>
        public void Set(Vector2 position, [NotNull] GameObject forward, KaijuAngleSortMode mode = KaijuAngleSortMode.Magnitude, bool? farthest = null)
        {
            Set(position, forward.Flatten(), mode, farthest);
        }
        
        /// <summary>
        /// Set values for the sorter.
        /// </summary>
        /// <param name="position">The position to compare against.</param>
        /// <param name="forward">The forward direction to compare with.</param>
        /// <param name="mode">How to handle sorting.</param>
        /// <param name="farthest">How to handle breaking ties by distance. NULL means no tie breaking, false for nearest distance, and true for farthest distance.</param>
        public void Set(Vector3 position, Vector2 forward, KaijuAngleSortMode mode = KaijuAngleSortMode.Magnitude, bool? farthest = null)
        {
            Set(position.Flatten(), forward, mode, farthest);
        }
        
        /// <summary>
        /// Set values for the sorter.
        /// </summary>
        /// <param name="position">The position to compare against.</param>
        /// <param name="forward">The forward direction to compare with.</param>
        /// <param name="mode">How to handle sorting.</param>
        /// <param name="farthest">How to handle breaking ties by distance. NULL means no tie breaking, false for nearest distance, and true for farthest distance.</param>
        public void Set(Vector3 position, Vector3 forward, KaijuAngleSortMode mode = KaijuAngleSortMode.Magnitude, bool? farthest = null)
        {
            Set(position.Flatten(), forward.Flatten(), mode, farthest);
        }
        
        /// <summary>
        /// Set values for the sorter.
        /// </summary>
        /// <param name="position">The position to compare against.</param>
        /// <param name="forward">The forward direction to compare with.</param>
        /// <param name="mode">How to handle sorting.</param>
        /// <param name="farthest">How to handle breaking ties by distance. NULL means no tie breaking, false for nearest distance, and true for farthest distance.</param>
        public void Set(Vector3 position, [NotNull] Transform forward, KaijuAngleSortMode mode = KaijuAngleSortMode.Magnitude, bool? farthest = null)
        {
            Set(position.Flatten(), forward.Flatten(), mode, farthest);
        }
        
        /// <summary>
        /// Set values for the sorter.
        /// </summary>
        /// <param name="position">The position to compare against.</param>
        /// <param name="forward">The forward direction to compare with.</param>
        /// <param name="mode">How to handle sorting.</param>
        /// <param name="farthest">How to handle breaking ties by distance. NULL means no tie breaking, false for nearest distance, and true for farthest distance.</param>
        public void Set(Vector3 position, [NotNull] Component forward, KaijuAngleSortMode mode = KaijuAngleSortMode.Magnitude, bool? farthest = null)
        {
            Set(position.Flatten(), forward.Flatten(), mode, farthest);
        }
        
        /// <summary>
        /// Set values for the sorter.
        /// </summary>
        /// <param name="position">The position to compare against.</param>
        /// <param name="forward">The forward direction to compare with.</param>
        /// <param name="mode">How to handle sorting.</param>
        /// <param name="farthest">How to handle breaking ties by distance. NULL means no tie breaking, false for nearest distance, and true for farthest distance.</param>
        public void Set(Vector3 position, [NotNull] GameObject forward, KaijuAngleSortMode mode = KaijuAngleSortMode.Magnitude, bool? farthest = null)
        {
            Set(position.Flatten(), forward.Flatten(), mode, farthest);
        }
        
        /// <summary>
        /// Set values for the sorter.
        /// </summary>
        /// <param name="position">The position to compare against.</param>
        /// <param name="forward">The forward direction to compare with.</param>
        /// <param name="mode">How to handle sorting.</param>
        /// <param name="farthest">How to handle breaking ties by distance. NULL means no tie breaking, false for nearest distance, and true for farthest distance.</param>
        public void Set([NotNull] Transform position, Vector2 forward, KaijuAngleSortMode mode = KaijuAngleSortMode.Magnitude, bool? farthest = null)
        {
            Set(position.Flatten(), forward, mode, farthest);
        }
        
        /// <summary>
        /// Set values for the sorter.
        /// </summary>
        /// <param name="position">The position to compare against.</param>
        /// <param name="forward">The forward direction to compare with.</param>
        /// <param name="mode">How to handle sorting.</param>
        /// <param name="farthest">How to handle breaking ties by distance. NULL means no tie breaking, false for nearest distance, and true for farthest distance.</param>
        public void Set([NotNull] Transform position, Vector3 forward, KaijuAngleSortMode mode = KaijuAngleSortMode.Magnitude, bool? farthest = null)
        {
            Set(position.Flatten(), forward.Flatten(), mode, farthest);
        }
        
        /// <summary>
        /// Set values for the sorter.
        /// </summary>
        /// <param name="position">The position to compare against.</param>
        /// <param name="forward">The forward direction to compare with.</param>
        /// <param name="mode">How to handle sorting.</param>
        /// <param name="farthest">How to handle breaking ties by distance. NULL means no tie breaking, false for nearest distance, and true for farthest distance.</param>
        public void Set([NotNull] Transform position, [NotNull] Transform forward, KaijuAngleSortMode mode = KaijuAngleSortMode.Magnitude, bool? farthest = null)
        {
            Set(position.Flatten(), forward.Flatten(), mode, farthest);
        }
        
        /// <summary>
        /// Set values for the sorter.
        /// </summary>
        /// <param name="position">The position to compare against.</param>
        /// <param name="forward">The forward direction to compare with.</param>
        /// <param name="mode">How to handle sorting.</param>
        /// <param name="farthest">How to handle breaking ties by distance. NULL means no tie breaking, false for nearest distance, and true for farthest distance.</param>
        public void Set([NotNull] Transform position, [NotNull] Component forward, KaijuAngleSortMode mode = KaijuAngleSortMode.Magnitude, bool? farthest = null)
        {
            Set(position.Flatten(), forward.Flatten(), mode, farthest);
        }
        
        /// <summary>
        /// Set values for the sorter.
        /// </summary>
        /// <param name="position">The position to compare against.</param>
        /// <param name="forward">The forward direction to compare with.</param>
        /// <param name="mode">How to handle sorting.</param>
        /// <param name="farthest">How to handle breaking ties by distance. NULL means no tie breaking, false for nearest distance, and true for farthest distance.</param>
        public void Set([NotNull] Transform position, [NotNull] GameObject forward, KaijuAngleSortMode mode = KaijuAngleSortMode.Magnitude, bool? farthest = null)
        {
            Set(position.Flatten(), forward.Flatten(), mode, farthest);
        }
        
        /// <summary>
        /// Set values for the sorter.
        /// </summary>
        /// <param name="position">The position to compare against with its forward being used for the direction.</param>
        /// <param name="mode">How to handle sorting.</param>
        /// <param name="farthest">How to handle breaking ties by distance. NULL means no tie breaking, false for nearest distance, and true for farthest distance.</param>
        public void Set([NotNull] Transform position, KaijuAngleSortMode mode = KaijuAngleSortMode.Magnitude, bool? farthest = null)
        {
            Set(position.Flatten(), position.forward.Flatten(), mode, farthest);
        }
        
        /// <summary>
        /// Set values for the sorter.
        /// </summary>
        /// <param name="position">The position to compare against.</param>
        /// <param name="forward">The forward direction to compare with.</param>
        /// <param name="mode">How to handle sorting.</param>
        /// <param name="farthest">How to handle breaking ties by distance. NULL means no tie breaking, false for nearest distance, and true for farthest distance.</param>
        public void Set([NotNull] Component position, Vector2 forward, KaijuAngleSortMode mode = KaijuAngleSortMode.Magnitude, bool? farthest = null)
        {
            Set(position.Flatten(), forward, mode, farthest);
        }
        
        /// <summary>
        /// Set values for the sorter.
        /// </summary>
        /// <param name="position">The position to compare against.</param>
        /// <param name="forward">The forward direction to compare with.</param>
        /// <param name="mode">How to handle sorting.</param>
        /// <param name="farthest">How to handle breaking ties by distance. NULL means no tie breaking, false for nearest distance, and true for farthest distance.</param>
        public void Set([NotNull] Component position, Vector3 forward, KaijuAngleSortMode mode = KaijuAngleSortMode.Magnitude, bool? farthest = null)
        {
            Set(position.Flatten(), forward.Flatten(), mode, farthest);
        }
        
        /// <summary>
        /// Set values for the sorter.
        /// </summary>
        /// <param name="position">The position to compare against.</param>
        /// <param name="forward">The forward direction to compare with.</param>
        /// <param name="mode">How to handle sorting.</param>
        /// <param name="farthest">How to handle breaking ties by distance. NULL means no tie breaking, false for nearest distance, and true for farthest distance.</param>
        public void Set([NotNull] Component position, [NotNull] Transform forward, KaijuAngleSortMode mode = KaijuAngleSortMode.Magnitude, bool? farthest = null)
        {
            Set(position.Flatten(), forward.Flatten(), mode, farthest);
        }
        
        /// <summary>
        /// Set values for the sorter.
        /// </summary>
        /// <param name="position">The position to compare against.</param>
        /// <param name="forward">The forward direction to compare with.</param>
        /// <param name="mode">How to handle sorting.</param>
        /// <param name="farthest">How to handle breaking ties by distance. NULL means no tie breaking, false for nearest distance, and true for farthest distance.</param>
        public void Set([NotNull] Component position, [NotNull] Component forward, KaijuAngleSortMode mode = KaijuAngleSortMode.Magnitude, bool? farthest = null)
        {
            Set(position.Flatten(), forward.Flatten(), mode, farthest);
        }
        
        /// <summary>
        /// Set values for the sorter.
        /// </summary>
        /// <param name="position">The position to compare against.</param>
        /// <param name="forward">The forward direction to compare with.</param>
        /// <param name="mode">How to handle sorting.</param>
        /// <param name="farthest">How to handle breaking ties by distance. NULL means no tie breaking, false for nearest distance, and true for farthest distance.</param>
        public void Set([NotNull] Component position, [NotNull] GameObject forward, KaijuAngleSortMode mode = KaijuAngleSortMode.Magnitude, bool? farthest = null)
        {
            Set(position.Flatten(), forward.Flatten(), mode, farthest);
        }
        
        /// <summary>
        /// Set values for the sorter.
        /// </summary>
        /// <param name="position">The position to compare against with its forward being used for the direction.</param>
        /// <param name="mode">How to handle sorting.</param>
        /// <param name="farthest">How to handle breaking ties by distance. NULL means no tie breaking, false for nearest distance, and true for farthest distance.</param>
        public void Set([NotNull] Component position, KaijuAngleSortMode mode = KaijuAngleSortMode.Magnitude, bool? farthest = null)
        {
            Transform t = position.transform;
            Set(t.Flatten(), t.forward.Flatten(), mode, farthest);
        }
        
        /// <summary>
        /// Set values for the sorter.
        /// </summary>
        /// <param name="position">The position to compare against.</param>
        /// <param name="forward">The forward direction to compare with.</param>
        /// <param name="mode">How to handle sorting.</param>
        /// <param name="farthest">How to handle breaking ties by distance. NULL means no tie breaking, false for nearest distance, and true for farthest distance.</param>
        public void Set([NotNull] GameObject position, Vector2 forward, KaijuAngleSortMode mode = KaijuAngleSortMode.Magnitude, bool? farthest = null)
        {
            Set(position.Flatten(), forward, mode, farthest);
        }
        
        /// <summary>
        /// Set values for the sorter.
        /// </summary>
        /// <param name="position">The position to compare against.</param>
        /// <param name="forward">The forward direction to compare with.</param>
        /// <param name="mode">How to handle sorting.</param>
        /// <param name="farthest">How to handle breaking ties by distance. NULL means no tie breaking, false for nearest distance, and true for farthest distance.</param>
        public void Set([NotNull] GameObject position, Vector3 forward, KaijuAngleSortMode mode = KaijuAngleSortMode.Magnitude, bool? farthest = null)
        {
            Set(position.Flatten(), forward.Flatten(), mode, farthest);
        }
        
        /// <summary>
        /// Set values for the sorter.
        /// </summary>
        /// <param name="position">The position to compare against.</param>
        /// <param name="forward">The forward direction to compare with.</param>
        /// <param name="mode">How to handle sorting.</param>
        /// <param name="farthest">How to handle breaking ties by distance. NULL means no tie breaking, false for nearest distance, and true for farthest distance.</param>
        public void Set([NotNull] GameObject position, [NotNull] Transform forward, KaijuAngleSortMode mode = KaijuAngleSortMode.Magnitude, bool? farthest = null)
        {
            Set(position.Flatten(), forward.Flatten(), mode, farthest);
        }
        
        /// <summary>
        /// Set values for the sorter.
        /// </summary>
        /// <param name="position">The position to compare against.</param>
        /// <param name="forward">The forward direction to compare with.</param>
        /// <param name="mode">How to handle sorting.</param>
        /// <param name="farthest">How to handle breaking ties by distance. NULL means no tie breaking, false for nearest distance, and true for farthest distance.</param>
        public void Set([NotNull] GameObject position, [NotNull] Component forward, KaijuAngleSortMode mode = KaijuAngleSortMode.Magnitude, bool? farthest = null)
        {
            Set(position.Flatten(), forward.Flatten(), mode, farthest);
        }
        
        /// <summary>
        /// Set values for the sorter.
        /// </summary>
        /// <param name="position">The position to compare against.</param>
        /// <param name="forward">The forward direction to compare with.</param>
        /// <param name="mode">How to handle sorting.</param>
        /// <param name="farthest">How to handle breaking ties by distance. NULL means no tie breaking, false for nearest distance, and true for farthest distance.</param>
        public void Set([NotNull] GameObject position, [NotNull] GameObject forward, KaijuAngleSortMode mode = KaijuAngleSortMode.Magnitude, bool? farthest = null)
        {
            Set(position.Flatten(), forward.Flatten(), mode, farthest);
        }
        
        /// <summary>
        /// Set values for the sorter.
        /// </summary>
        /// <param name="position">The position to compare against with its forward being used for the direction.</param>
        /// <param name="mode">How to handle sorting.</param>
        /// <param name="farthest">How to handle breaking ties by distance. NULL means no tie breaking, false for nearest distance, and true for farthest distance.</param>
        public void Set([NotNull] GameObject position, KaijuAngleSortMode mode = KaijuAngleSortMode.Magnitude, bool? farthest = null)
        {
            Transform t = position.transform;
            Set(t.Flatten(), t.forward.Flatten(), mode, farthest);
        }
        
        /// <summary>
        /// Compare the two instances.
        /// </summary>
        /// <param name="position">The position to compare against.</param>
        /// <param name="forward">The forward direction to compare with.</param>
        /// <param name="x">The first instance.</param>
        /// <param name="y">The second instance.</param>
        /// <param name="mode">How to handle sorting.</param>
        /// <returns>Less than zero if the first instance comes first, zero if they are equal, or greater than zero if the second comes first.</returns>
        public static int CompareAngle(Vector2 position, Vector2 forward, Vector2 x, Vector2 y, KaijuAngleSortMode mode = KaijuAngleSortMode.Magnitude)
        {
            float a = position.Angle(forward, x);
            float b = position.Angle(forward, y);
            int order = a < b ? -1 : b < a ? 1 : 0;
            
            switch (mode)
            {
                case KaijuAngleSortMode.Smallest:
                    return order;
                case KaijuAngleSortMode.Largest:
                    return -order;
                case KaijuAngleSortMode.Magnitude:
                default:
                    a = Mathf.Abs(a);
                    b = Mathf.Abs(b);
                    return a < b ? -1 : b < a ? 1 : 0;
            }
        }
        
        /// <summary>
        /// Compare the two instances.
        /// </summary>
        /// <param name="x">The first instance.</param>
        /// <param name="y">The second instance.</param>
        /// <returns>Less than zero if the first instance comes first, zero if they are equal, or greater than zero if the second comes first.</returns>
        public int Compare(Vector2 x, Vector2 y)
        {
            int order = CompareAngle(Position, Forward, x, y, Mode);
            return order != 0 || Farthest == null ? order : KaijuAgentsDistanceSorter.CompareDistance(Position, x, y, Farthest.Value);
        }
        
        /// <summary>
        /// Compare the two instances.
        /// </summary>
        /// <param name="x">The first instance.</param>
        /// <param name="y">The second instance.</param>
        /// <returns>Less than zero if the first instance comes first, zero if they are equal, or greater than zero if the second comes first.</returns>
        public int Compare(Vector3 x, Vector3 y)
        {
            return Compare(x.Flatten(), y.Flatten());
        }
        
        /// <summary>
        /// Compare the two instances.
        /// </summary>
        /// <param name="x">The first instance.</param>
        /// <param name="y">The second instance.</param>
        /// <returns>Less than zero if the first instance comes first, zero if they are equal, or greater than zero if the second comes first.</returns>
        public int Compare(Transform x, Transform y)
        {
            // NULL entries come last.
            return x == null ? y == null ? 0 : 1 : y == null ? -1 : Compare(x.Flatten(), y.Flatten());
        }
        
        /// <summary>
        /// Compare the two instances.
        /// </summary>
        /// <param name="x">The first instance.</param>
        /// <param name="y">The second instance.</param>
        /// <returns>Less than zero if the first instance comes first, zero if they are equal, or greater than zero if the second comes first.</returns>
        public int Compare(Component x, Component y)
        {
            // NULL entries come last.
            return x == null ? y == null ? 0 : 1 : y == null ? -1 : Compare(x.Flatten(), y.Flatten());
        }
        
        /// <summary>
        /// Compare the two instances.
        /// </summary>
        /// <param name="x">The first instance.</param>
        /// <param name="y">The second instance.</param>
        /// <returns>Less than zero if the first instance comes first, zero if they are equal, or greater than zero if the second comes first.</returns>
        public int Compare(GameObject x, GameObject y)
        {
            // NULL entries come last.
            return x == null ? y == null ? 0 : 1 : y == null ? -1 : Compare(x.Flatten(), y.Flatten());
        }
        
        /// <summary>
        /// Get a description of the object.
        /// </summary>
        /// <returns>A description of the object.</returns>
        public override string ToString()
        {
            return $"Kaiju Agents Angle Sorter - Position: {Position} - Forward: {Forward}";
        }
        
        /// <summary>
        /// Implicit conversion to a string.
        /// </summary>
        /// <param name="s">The sorter.</param>
        /// <returns>The string from the <see cref="ToString"/> method.</returns>
        public static implicit operator string([NotNull] KaijuAgentsAngleSorter s) => s.ToString();
        
        /// <summary>
        /// Implicit conversion to a <see href="https://docs.unity3d.com/ScriptReference/Vector2.html">Vector2</see> from the position.
        /// </summary>
        /// <param name="s">The sorter.</param>
        /// <returns>The string from the <see cref="ToString"/> method.</returns>
        public static implicit operator Vector2([NotNull] KaijuAgentsAngleSorter s) => s.Position;
        
        /// <summary>
        /// Implicit conversion to a nullable <see href="https://docs.unity3d.com/ScriptReference/Vector2.html">Vector2</see> from the position.
        /// </summary>
        /// <param name="s">The sorter.</param>
        /// <returns>The string from the <see cref="ToString"/> method.</returns>
        public static implicit operator Vector2?([NotNull] KaijuAgentsAngleSorter s) => s.Position;
        
        /// <summary>
        /// Implicit conversion to a <see href="https://docs.unity3d.com/ScriptReference/Vector3.html">Vector3</see> from the position.
        /// </summary>
        /// <param name="s">The sorter.</param>
        /// <returns>The string from the <see cref="ToString"/> method.</returns>
        public static implicit operator Vector3([NotNull] KaijuAgentsAngleSorter s) => s.Position3;
        
        /// <summary>
        /// Implicit conversion to a nullable <see href="https://docs.unity3d.com/ScriptReference/Vector3.html">Vector3</see> from the position.
        /// </summary>
        /// <param name="s">The sorter.</param>
        /// <returns>The string from the <see cref="ToString"/> method.</returns>
        public static implicit operator Vector3?([NotNull] KaijuAgentsAngleSorter s) => s.Position3;
    }
    
    /// <summary>
    /// The mode to sort angles by.
    /// </summary>
    public enum KaijuAngleSortMode
    {
        /// <summary>
        /// Sort by absolute magnitude from the forward direction.
        /// </summary>
        Magnitude,
        
        /// <summary>
        /// Sort by smallest to largest angles, being from left to right from the forward direction.
        /// </summary>
        Smallest,
        
        /// <summary>
        /// Sort by largest to smallest angles, being from right to left from the forward direction.
        /// </summary>
        Largest
    }
}