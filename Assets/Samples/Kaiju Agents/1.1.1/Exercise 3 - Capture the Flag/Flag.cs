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
        /// This function is called when the object becomes enabled and active.
        /// </summary>
        protected override void OnEnable()
        {
            base.OnEnable();
            
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