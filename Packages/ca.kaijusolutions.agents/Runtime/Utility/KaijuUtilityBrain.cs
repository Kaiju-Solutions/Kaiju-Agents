using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using UnityEngine;

namespace KaijuSolutions.Agents.Utility
{
    /// <summary>
    /// Base brain class to implement for utility AI.
    /// </summary>
#if UNITY_EDITOR
    [SelectionBase]
    [Icon("Packages/ca.kaijusolutions.agents/Editor/Icon.png")]
    [HelpURL("https://agents.kaijusolutions.ca/manual/utility-ai.html")]
#endif
    [DisallowMultipleComponent]
    [RequireComponent(typeof(KaijuAgent))]
    public abstract class KaijuUtilityBrain : KaijuBehaviour
    {
        /// <summary>
        /// The <see cref="KaijuUtilityAction"/>s this brain can choose to perform.
        /// </summary>
#if UNITY_EDITOR
        [Tooltip("The actions this brain can choose to perform.")]
#endif
        public List<KaijuUtilityAction> actions;
        
        /// <summary>
        /// The agent this brain is controlling.
        /// </summary>
#if UNITY_EDITOR
        [field: Tooltip("The agent this brain is controlling.")]
        [field: HideInInspector]
#endif
        [field: SerializeField]
        public KaijuAgent Agent { get; private set; }
        
        /// <summary>
        /// The <see cref="KaijuUtilityAction"/> currently being performed.
        /// </summary>
        public KaijuUtilityAction Current { get; private set; }
        
        /// <summary>
        /// The blackboard data stored in this.
        /// </summary>
        private readonly Dictionary<string, object> _blackboard = new();
        
        /// <summary>
        /// Get the utility scores for all actions.
        /// </summary>
        public List<(KaijuUtilityAction action, float utility)> Utilities
        {
            get
            {
                if (_utilties.Count > 1)
                {
                    _utilties.Sort((a, b) => b.utility.CompareTo(a.utility));
                }
                
                return _utilties;
            }
        }
        
        /// <summary>
        /// Store utility scores.
        /// </summary>
        private readonly List<(KaijuUtilityAction action, float utility)> _utilties = new();
        
        /// <summary>
        /// Awake is called when an enabled script instance is being loaded.
        /// </summary>
        public virtual void Awake()
        {
            AssignAgent();
        }
        
        /// <summary>
        /// This function is called when the object becomes enabled and active.
        /// </summary>
        public virtual void OnEnable()
        {
            _utilties.Clear();
            _utilties.Capacity = actions.Count;
            _blackboard.Clear();
            Current = null;
        }
        
        /// <summary>
        /// This function is called when the behaviour becomes disabled.
        /// </summary>
        public virtual void OnDisable()
        {
            Current?.Exit(this);
            Current = null;
            _blackboard.Clear();
            _utilties.Clear();
        }
#if UNITY_EDITOR
        /// <summary>
        /// Editor-only function that Unity calls when the script is loaded or a value changes in the Inspector.
        /// </summary>
        protected virtual void OnValidate()
        {
            AssignAgent();
        }
#endif
        /// <summary>
        /// Assign our agent.
        /// </summary>
        private void AssignAgent()
        {
            // The agent must be attached to this.
            if (Agent == null || Agent.transform != transform)
            {
                Agent = GetComponent<KaijuAgent>();
            }
        }
        
        /// <summary>
        /// Frame-rate independent MonoBehaviour.FixedUpdate message for physics calculations.
        /// </summary>
        private void FixedUpdate()
        {
            if (!Agent)
            {
                return;
            }
            
            // Update the blackboard for the new evaluation.
            UpdateBlackboard();
            
            // Check the utility of every action.
            KaijuUtilityAction best = null;
            float highestUtility = float.MinValue;
            _utilties.Clear();
            foreach (KaijuUtilityAction action in actions)
            {
                float utility = action.Utility(this);
                _utilties.Add((action, utility));
                if (utility <= highestUtility)
                {
                    continue;
                }
                
                best = action;
                highestUtility = utility;
            }
            
            // Transition if needed.
            if (best && Current != best)
            {
                Current?.Exit(this);
                Current = best;
                Current.Enter(this);
            }
            
            // Execute the action.
            if (Current)
            {
                Current.Execute(this);
            }
        }
        
        /// <summary>
        /// Get data from the blackboard.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <typeparam name="T">The type of data to get.</typeparam>
        /// <returns>The found data in the blackboard.</returns>
        public T Get<T>([NotNull] string key) => _blackboard.TryGetValue(key, out object value) ? (T)value : default;
        
        /// <summary>
        /// Set data in the blackboard.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <param name="value">The value.</param>
        public void Set([NotNull] string key, object value) => _blackboard[key] = value;
        
        /// <summary>
        /// Set data as a boolean in the blackboard. This will attempt to convert non-Boolean values into a Boolean, treating non-zero values as true.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <param name="value">The value.</param>
        public void SetBool([NotNull] string key, object value)
        {
            switch (value)
            {
                case bool:
                    Set(key, value);
                    return;
                case byte cast:
                    Set(key, cast != 0);
                    return;
                case short cast:
                    Set(key, cast != 0);
                    return;
                case ushort cast:
                    Set(key, cast != 0);
                    return;
                case int cast:
                    Set(key, cast != 0);
                    return;
                case uint cast:
                    Set(key, cast != 0);
                    return;
                case long cast:
                    Set(key, cast != 0);
                    return;
                case ulong cast:
                    Set(key, cast != 0);
                    return;
                case float cast:
                    Set(key, cast != 0);
                    return;
                case double cast:
                    Set(key, cast != 0);
                    return;
                case Vector2 cast:
                    Set(key, cast != Vector2.zero);
                    return;
                case Vector3 cast:
                    Set(key, cast != Vector3.zero);
                    return;
                case Quaternion cast:
                    Set(key, cast != Quaternion.identity);
                    return;
                case GameObject cast:
                    Set(key, cast != null && cast.activeInHierarchy);
                    return;
                case Component cast:
                    Set(key, cast != null && cast.gameObject.activeInHierarchy);
                    return;
                default:
                    Set(key, false);
                    return;
            }
        }
        
        /// <summary>
        /// Set data as an integer in the blackboard. This will attempt to convert noninteger values into integers.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <param name="value">The value.</param>
        public void SetInteger([NotNull] string key, object value)
        {
            switch (value)
            {
                case bool cast:
                    Set(key, cast ? 1 : 0);
                    return;
                case byte cast:
                    Set(key, (int)cast);
                    return;
                case short cast:
                    Set(key, (int)cast);
                    return;
                case ushort cast:
                    Set(key, (int)cast);
                    return;
                case int:
                    Set(key, value);
                    return;
                case uint cast:
                    Set(key, (int)cast);
                    return;
                case long cast:
                    Set(key, (int)cast);
                    return;
                case ulong cast:
                    Set(key, (int)cast);
                    return;
                case float cast:
                    Set(key, (int)cast);
                    return;
                case double cast:
                    Set(key, (int)cast);
                    return;
                case Vector2 cast:
                    Set(key, (int)cast.magnitude);
                    return;
                case Vector3 cast:
                    Set(key, (int)cast.magnitude);
                    return;
                case Quaternion cast:
                    Set(key, (int)cast.eulerAngles.magnitude);
                    return;
                case GameObject cast:
                    Set(key, cast != null && cast.activeInHierarchy ? 1 : 0);
                    return;
                case Component cast:
                    Set(key, cast != null && cast.gameObject.activeInHierarchy ? 1 : 0);
                    return;
                default:
                    Set(key, 0);
                    return;
            }
        }
        
        /// <summary>
        /// Set data as a float in the blackboard. This will attempt to convert non-float values into floats.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <param name="value">The value.</param>
        public void SetFloat([NotNull] string key, object value)
        {
            switch (value)
            {
                case bool cast:
                    Set(key, cast ? 1f : 0f);
                    return;
                case byte cast:
                    Set(key, (float)cast);
                    return;
                case short cast:
                    Set(key, (float)cast);
                    return;
                case ushort cast:
                    Set(key, (float)cast);
                    return;
                case int cast:
                    Set(key, (float)cast);
                    return;
                case uint cast:
                    Set(key, (float)cast);
                    return;
                case long cast:
                    Set(key, (float)cast);
                    return;
                case ulong cast:
                    Set(key, (float)cast);
                    return;
                case float:
                    Set(key, value);
                    return;
                case double cast:
                    Set(key, (float)cast);
                    return;
                case Vector2 cast:
                    Set(key, cast.magnitude);
                    return;
                case Vector3 cast:
                    Set(key, cast.magnitude);
                    return;
                case Quaternion cast:
                    Set(key, cast.eulerAngles.magnitude);
                    return;
                case GameObject cast:
                    Set(key, cast != null && cast.activeInHierarchy ? 1f : 0f);
                    return;
                case Component cast:
                    Set(key, cast != null && cast.gameObject.activeInHierarchy ? 1f : 0f);
                    return;
                default:
                    Set(key, 0f);
                    return;
            }
        }
        
        /// <summary>
        /// Set data as an integer in the blackboard, clamped between a min and max value. This will attempt to convert noninteger values into integers.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <param name="value">The value.</param>
        /// <param name="min">The minimum value.</param>
        /// <param name="max">The maximum value.</param>
        public void SetIntegerClamp([NotNull] string key, object value, int min = 0, int max = 1)
        {
            switch (value)
            {
                case bool cast:
                    Set(key, cast ? max : min);
                    return;
                case byte cast:
                    Set(key, Mathf.Clamp(cast, min, max));
                    return;
                case short cast:
                    Set(key, Mathf.Clamp(cast, min, max));
                    return;
                case ushort cast:
                    Set(key, Mathf.Clamp(cast, min, max));
                    return;
                case int cast:
                    Set(key, Mathf.Clamp(cast, min, max));
                    return;
                case uint cast:
                    Set(key, Mathf.Clamp((int)cast, min, max));
                    return;
                case long cast:
                    Set(key, Mathf.Clamp((int)cast, min, max));
                    return;
                case ulong cast:
                    Set(key, Mathf.Clamp((int)cast, min, max));
                    return;
                case float cast:
                    Set(key, Mathf.Clamp((int)cast, min, max));
                    return;
                case double cast:
                    Set(key, Mathf.Clamp((int)cast, min, max));
                    return;
                case Vector2 cast:
                    Set(key, Mathf.Clamp((int)cast.magnitude, min, max));
                    return;
                case Vector3 cast:
                    Set(key, Mathf.Clamp((int)cast.magnitude, min, max));
                    return;
                case Quaternion cast:
                    Set(key, Mathf.Clamp((int)cast.eulerAngles.magnitude, min, max));
                    return;
                case GameObject cast:
                    Set(key, cast != null && cast.activeInHierarchy ? max : min);
                    return;
                case Component cast:
                    Set(key, cast != null && cast.gameObject.activeInHierarchy ? max : min);
                    return;
                default:
                    Set(key, min);
                    return;
            }
        }
        
        /// <summary>
        /// Set data as a float in the blackboard, clamped between a min and max value. This will attempt to convert non-float values into floats.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <param name="value">The value.</param>
        /// <param name="min">The minimum value.</param>
        /// <param name="max">The maximum value.</param>
        public void SetFloatClamp([NotNull] string key, object value, float min = 0, float max = 1)
        {
            switch (value)
            {
                case bool cast:
                    Set(key, cast ? max : min);
                    return;
                case byte cast:
                    Set(key, Mathf.Clamp(cast, min, max));
                    return;
                case short cast:
                    Set(key, Mathf.Clamp(cast, min, max));
                    return;
                case ushort cast:
                    Set(key, Mathf.Clamp(cast, min, max));
                    return;
                case int cast:
                    Set(key, Mathf.Clamp(cast, min, max));
                    return;
                case uint cast:
                    Set(key, Mathf.Clamp(cast, min, max));
                    return;
                case long cast:
                    Set(key, Mathf.Clamp(cast, min, max));
                    return;
                case ulong cast:
                    Set(key, Mathf.Clamp(cast, min, max));
                    return;
                case float cast:
                    Set(key, Mathf.Clamp(cast, min, max));
                    return;
                case double cast:
                    Set(key, Mathf.Clamp((int)cast, min, max));
                    return;
                case Vector2 cast:
                    Set(key, Mathf.Clamp(cast.magnitude, min, max));
                    return;
                case Vector3 cast:
                    Set(key, Mathf.Clamp(cast.magnitude, min, max));
                    return;
                case Quaternion cast:
                    Set(key, Mathf.Clamp(cast.eulerAngles.magnitude, min, max));
                    return;
                case GameObject cast:
                    Set(key, cast != null && cast.activeInHierarchy ? max : min);
                    return;
                case Component cast:
                    Set(key, cast != null && cast.gameObject.activeInHierarchy ? max : min);
                    return;
                default:
                    Set(key, min);
                    return;
            }
        }
        
        /// <summary>
        /// Set data as a float in the blackboard, scaled to [0, 1] based on a given min and max value. This will attempt to convert non-float values into floats.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <param name="value">The value.</param>
        /// <param name="min">The minimum value to scale on.</param>
        /// <param name="max">The maximum value to scale on.</param>
        public void SetScaled([NotNull] string key, object value, float min = 0, float max = 1)
        {
            if (max - min == 0f)
            {
                Set(key, 0f);
                return;
            }
            
            switch (value)
            {
                case bool cast:
                    Set(key, cast ? 1f : 0f);
                    return;
                case byte cast:
                    SetFloatClamp(key, (cast - min) / (max - min));
                    return;
                case short cast:
                    SetFloatClamp(key, (cast - min) / (max - min));
                    return;
                case ushort cast:
                    SetFloatClamp(key, (cast - min) / (max - min));
                    return;
                case int cast:
                    SetFloatClamp(key, (cast - min) / (max - min));
                    return;
                case uint cast:
                    SetFloatClamp(key, (cast - min) / (max - min));
                    return;
                case long cast:
                    SetFloatClamp(key, (cast - min) / (max - min));
                    return;
                case ulong cast:
                    SetFloatClamp(key, (cast - min) / (max - min));
                    return;
                case float cast:
                    SetFloatClamp(key, (cast - min) / (max - min));
                    return;
                case double cast:
                    SetFloatClamp(key, ((float)cast - min) / (max - min));
                    return;
                case Vector2 cast:
                    SetFloatClamp(key, (cast.magnitude - min) / (max - min));
                    return;
                case Vector3 cast:
                    SetFloatClamp(key, (cast.magnitude - min) / (max - min));
                    return;
                case Quaternion cast:
                    SetFloatClamp(key, (cast.eulerAngles.magnitude - min) / (max - min));
                    return;
                case GameObject cast:
                    Set(key, cast != null && cast.activeInHierarchy ? 1f : 0f);
                    return;
                case Component cast:
                    Set(key, cast != null && cast.gameObject.activeInHierarchy ? 1f : 0f);
                    return;
                default:
                    Set(key, 0f);
                    return;
            }
        }
        
        /// <summary>
        /// Set any needed blackboard variables for choosing an action to perform.
        /// </summary>
        protected virtual void UpdateBlackboard() { }
    }
}