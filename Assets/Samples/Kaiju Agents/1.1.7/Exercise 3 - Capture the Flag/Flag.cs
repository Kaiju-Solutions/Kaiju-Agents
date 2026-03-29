using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using KaijuSolutions.Agents.Extensions;
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif
namespace KaijuSolutions.Agents.Exercises.CTF
{
    /// <summary>
    /// The flags themselves for <see cref="Trooper"/>s to try and capture.
    /// </summary>
    [HelpURL("https://agents.kaijusolutions.ca/manual/capture-the-flag.html#flag")]
    [AddComponentMenu("Kaiju Solutions/Agents/Exercises/Capture the Flag/Flag", 35)]
    public class Flag : Pickup
    {
        /// <summary>
        /// Get the location of a flag's base.
        /// </summary>
        /// <param name="flag">The flag.</param>
        /// <returns>The location of a flag's base.</returns>
        public static Vector3 Base3(Flag flag)
        {
            return flag != null ? flag._position.Expand() : Vector3.zero;
        }
        
        /// <summary>
        /// Get the location of a flag's base.
        /// </summary>
        /// <param name="flag">The flag.</param>
        /// <returns>The location of a flag's base.</returns>
        public static Vector2 Base(Flag flag)
        {
            return flag != null ? flag._position : Vector2.zero;
        }
        
        /// <summary>
        /// Get the location of a team's base, being where their flag spawns and where to return captured flags to.
        /// </summary>
        /// <param name="teamOne">If this is team one's base being requested.</param>
        /// <returns>The location of the team's base.</returns>
        public static Vector3 Base3(bool teamOne)
        {
#if UNITY_EDITOR
            if (!Application.isPlaying)
            {
                return Vector3.zero;
            }
#endif
            return Base(teamOne).Expand();
        }

        /// <summary>
        /// Get the location of a team's base, being where their flag spawns and where to return captured flags to.
        /// </summary>
        /// <param name="teamOne">If this is team one's base being requested.</param>
        /// <returns>The location of the team's base.</returns>
        public static Vector2 Base(bool teamOne)
        {
#if UNITY_EDITOR
            if (!Application.isPlaying)
            {
                return Vector2.zero;
            }
#endif
            return teamOne ? TeamOneBase : TeamTwoBase;
        }
        
        /// <summary>
        /// The location of team one's base, being where their flag spawns and where to return captured flags to.
        /// </summary>
        public static Vector3 TeamOneBase3
        {
            get
            {
#if UNITY_EDITOR
                if (!Application.isPlaying)
                {
                    return Vector3.zero;
                }
#endif
                return TeamOneBase.Expand();
            }
        }

        /// <summary>
        /// The location of team one's base, being where their flag spawns and where to return captured flags to.
        /// </summary>
        public static Vector2 TeamOneBase
        {
            get
            {
#if UNITY_EDITOR
                if (!Application.isPlaying)
                {
                    return Vector2.zero;
                }
#endif
                return TeamOneFlag != null ? TeamOneFlag._position : Vector2.zero;
            }
        }

        /// <summary>
        /// The location of team two's base, being where their flag spawns and where to return captured flags to.
        /// </summary>
        public static Vector3 TeamTwoBase3
        {
            get
            {
#if UNITY_EDITOR
                if (!Application.isPlaying)
                {
                    return Vector3.zero;
                }
#endif
                return TeamTwoBase.Expand();
            }
        }

        /// <summary>
        /// The location of team two's base, being where their flag spawns and where to return captured flags to.
        /// </summary>
        public static Vector2 TeamTwoBase
        {
            get
            {
#if UNITY_EDITOR
                if (!Application.isPlaying)
                {
                    return Vector2.zero;
                }
#endif
                return TeamTwoFlag != null ? TeamTwoFlag._position : Vector2.zero;
            }
        }
        
        /// <summary>
        /// If a flag is at its base.
        /// </summary>
        /// <param name="teamOne">The team this is for.</param>
        /// <returns>If the flag is at its base.</returns>
        public static bool AtBase(bool teamOne) => teamOne ? TeamOneAtBase : TeamTwoAtBase;
        
        /// <summary>
        /// If team one's flag is at its base.
        /// </summary>
        public static bool TeamOneAtBase => AtBase(TeamOneFlag);
        
        /// <summary>
        /// If team two's flag is at its base.
        /// </summary>
        public static bool TeamTwoAtBase => AtBase(TeamTwoFlag);
        
        /// <summary>
        /// If a flag is at its base.
        /// </summary>
        /// <param name="flag">The flag this is for.</param>
        /// <returns>If the flag is at its base.</returns>
        public static bool AtBase(Flag flag) => flag != null && flag.Position == flag._position && !BeingCarried(flag);
        
        /// <summary>
        /// If a flag is being carried.
        /// </summary>
        /// <param name="teamOne">The team this is for.</param>
        /// <returns>If the flag is being carried.</returns>
        public static bool BeingCarried(bool teamOne) => teamOne ? TeamOneBeingCarried : TeamTwoBeingCarried;
        
        /// <summary>
        /// If team one's flag is being carried.
        /// </summary>
        public static bool TeamOneBeingCarried => BeingCarried(TeamOneFlag);
        
        /// <summary>
        /// If team two's flag is being carried.
        /// </summary>
        public static bool TeamTwoBeingCarried => BeingCarried(TeamTwoFlag);
        
        /// <summary>
        /// If a flag is being carried.
        /// </summary>
        /// <param name="flag">The flag this is for.</param>
        /// <returns>If the flag is being carried.</returns>
        public static bool BeingCarried(Flag flag) => Carrier(flag) != null;
        
        /// <summary>
        /// The <see cref="Trooper"/> which is carrying a flag.
        /// </summary>
        /// <param name="teamOne">What team's flag to get the current carrier for.</param>
        /// <returns>The <see cref="Trooper"/> which is carrying the flag, or NULL if there is no carrier.</returns>
        public static Trooper Carrier(bool teamOne) => teamOne ? TeamOneCarrier : TeamTwoCarrier;
        
        /// <summary>
        /// The <see cref="Trooper"/> carrying team one's flag.
        /// </summary>
        public static Trooper TeamOneCarrier => Carrier(TeamOneFlag);
        
        /// <summary>
        /// The <see cref="Trooper"/> carrying team two's flag.
        /// </summary>
        public static Trooper TeamTwoCarrier => Carrier(TeamTwoFlag);
        
        /// <summary>
        /// The distance of a team's flag to its base.
        /// </summary>
        /// <param name="teamOne">The team this is for.</param>
        /// <returns>The distance of the flag to its base.</returns>
        public static float DistanceToBase(bool teamOne) => teamOne ? TeamOneDistanceToBase : TeamTwoDistanceToBase;
        
        /// <summary>
        /// The distance of team one's flag to its base.
        /// </summary>
        public static float TeamOneDistanceToBase => DistanceToBase(TeamOneFlag);
        
        /// <summary>
        /// The distance of team two's flag to its base.
        /// </summary>
        public static float TeamTwoDistanceToBase => DistanceToBase(TeamTwoFlag);
        
        /// <summary>
        /// The distance of a flag to its base.
        /// </summary>
        /// <param name="flag">The flag.</param>
        /// <returns>The distance of the flag to its base.</returns>
        public static float DistanceToBase(Flag flag) => flag == null ? 0f : flag.Position.Distance(flag._position);
        
        /// <summary>
        /// The <see cref="Trooper"/> which is carrying a flag.
        /// </summary>
        /// <param name="flag">The flag to get the current carrier for.</param>
        /// <returns>The <see cref="Trooper"/> which is carrying the flag, or NULL if there is no carrier.</returns>
        public static Trooper Carrier(Flag flag)
        {
            if (flag == null)
            {
                return null;
            }
            
            Transform p = flag.transform.parent;
            while (true)
            {
                if (p == null)
                {
                    return null;
                }
                
                Trooper trooper = p.GetComponent<Trooper>();
                if (trooper != null)
                {
                    return trooper;
                }
                
                p = p.parent;
            }
        }
        
        /// <summary>
        /// Both flags for easy access.
        /// </summary>
        public static IReadOnlyCollection<Flag> Flags
        {
            get
            {
#if UNITY_EDITOR
                if (!Application.isPlaying)
                {
                    return Array.Empty<Flag>();
                }
#endif
                return Both;
            }
        }

        /// <summary>
        /// Store both flags for easy access.
        /// </summary>
        private static readonly HashSet<Flag> Both = new();
        
        /// <summary>
        /// Team one's flag.
        /// </summary>
        public static Flag TeamOneFlag;
        
        /// <summary>
        /// Team two's flag.
        /// </summary>
        public static Flag TeamTwoFlag;
#if UNITY_EDITOR
        /// <summary>
        /// Handle manually resetting the domain.
        /// </summary>
        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.SubsystemRegistration)]
        private static void InitOnPlayMode()
        {
            Domain();
            EditorApplication.playModeStateChanged -= Domain;
            EditorApplication.playModeStateChanged += Domain;
        }
        
        /// <summary>
        /// Handle manually resetting the domain.
        /// </summary>
        /// <param name="state">The current editor state change.</param>
        private static void Domain(PlayModeStateChange state)
        {
            if (state != PlayModeStateChange.ExitingPlayMode)
            {
                return;
            }
            
            EditorApplication.playModeStateChanged -= Domain;
            Domain();
        }
        
        /// <summary>
        /// Handle manually resetting the domain.
        /// </summary>
        private static void Domain()
        {
            TeamOneFlag = null;
            TeamTwoFlag = null;
            Both.Clear();
        }
#endif
        /// <summary>
        /// If this is team one's flag.
        /// </summary>
        [field: Tooltip("If this is team one's flag.")]
        [field: SerializeField]
        public bool TeamOne { get; private set; } = true;
        
        /// <summary>
        /// The part of the flag to color as being part of the team.
        /// </summary>
        [Tooltip("The part of the flag to color as being part of the team.")]
        [SerializeField]
        private MeshRenderer visual;
        
        /// <summary>
        /// The home position of the flag.
        /// </summary>
        private Vector2 _position;
        
        /// <summary>
        /// The home orientation of the flag.
        /// </summary>
        private Quaternion _rotation;
        
        /// <summary>
        /// Awake is called when an enabled script instance is being loaded.
        /// </summary>
        private void Awake()
        {
            // Ensure this is assigned.
            AssignFlag();
            
            // Cache the spawn position.
            _position = Position;
            _rotation = OrientationQuaternion;
        }
        
        /// <summary>
        /// Ensure this flag is validly assigned.
        /// </summary>
        private void AssignFlag()
        {
            if (TeamOne)
            {
                if (TeamTwoFlag == this)
                {
                    TeamTwoFlag = null;
                }
                
                if (TeamOneFlag != null && TeamOneFlag != this)
                {
                    Both.Remove(this);
                    Destroy(gameObject);
                }
                else
                {
                    TeamOneFlag = this;
                    Both.Add(this);
                    visual.material = KaijuAgents.GetMaterial(CaptureTheFlagManager.ColorOne);
                }
            }
            else
            {
                if (TeamOneFlag == this)
                {
                    Both.Remove(this);
                    TeamOneFlag = null;
                }
                
                if (TeamTwoFlag != null && TeamTwoFlag != this)
                {
                    Destroy(gameObject);
                }
                else
                {
                    TeamTwoFlag = this;
                    Both.Add(this);
                    visual.material = KaijuAgents.GetMaterial(CaptureTheFlagManager.ColorTwo);
                }
            }
        }
        
        /// <summary>
        /// This function is called when the behaviour becomes disabled.
        /// </summary>
        private void OnDisable()
        {
            Both.Remove(this);
            if (TeamOneFlag == this)
            {
                TeamOneFlag = null;
            }
            
            if (TeamTwoFlag == this)
            {
                TeamTwoFlag = null;
            }
        }
        
        /// <summary>
        /// What to do when interacted with.
        /// </summary>
        /// <param name="trooper">The <see cref="Trooper"/> interracting with this.</param>
        /// <returns>If the interaction was successful or not.</returns>
        public override bool Interact([NotNull] Trooper trooper)
        {
            Transform t = transform;
            
            // Don't interact with other troopers if currently being carried by one.
            if (t.parent != null)
            {
                return false;
            }
            
            // If this is the same team, the flag is being returned.
            if (trooper.TeamOne == TeamOne)
            {
                // Nothing to return if already at the correct base.
                if (_position == Position)
                {
                    return false;
                }
                
                Return();
            }
            else
            {
                // Otherwise, it is being picked up.
                t.parent = trooper.FlagPosition;
                t.localPosition = Vector3.zero;
                t.localRotation = Quaternion.identity;
                
                // Disable all triggers.
                foreach (Collider c in Colliders)
                {
                    c.enabled = false;
                }
            }
            
            return true;
        }
        
        /// <summary>
        /// Return the flag to its base.
        /// </summary>
        public void Return()
        {
            Transform t = transform;
            t.parent = null;
            t.position = _position.Expand();
            t.rotation = _rotation;
            
            // Enable all triggers.
            foreach (Collider c in Colliders)
            {
                c.enabled = true;
            }
        }
        
        /// <summary>
        /// Drop this flag.
        /// </summary>
        public void Drop()
        {
            Transform t = transform;
            t.parent = null;
            Vector3 p = t.position;
            t.position = new(p.x, 0, p.z);
            
            foreach (Collider c in Colliders)
            {
                c.enabled = true;
            }
        }
        
        /// <summary>
        /// Destroying the attached Behaviour will result in the game or Scene receiving OnDestroy.
        /// </summary>
        private void OnDestroy()
        {
            Both.Remove(this);
        }
    }
}