using UnityEngine;

namespace KaijuSolutions.Agents
{
    /// <summary>
    /// Manager agents.
    /// </summary>
    public class KaijuAgentsManager : MonoBehaviour
    {
        /// <summary>
        /// The singleton manager instance.
        /// </summary>
        public static KaijuAgentsManager Instance => _instance ? _instance : new GameObject("Kaiju Agents Manager").AddComponent<KaijuAgentsManager>();
        
        /// <summary>
        /// The singleton manager instance.
        /// </summary>
        private static KaijuAgentsManager _instance;
#if UNITY_EDITOR
        /// <summary>
        /// Handle manually resetting the domain.
        /// </summary>
        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.SubsystemRegistration)]
        private static void InitOnPlayMode()
        {
            _instance = null;
        }
#endif
        /// <summary>
        /// This function is called when the object becomes enabled and active.
        /// </summary>
        private void OnEnable()
        {
            // Nothing to do if this is already the singleton.
            if (_instance == this)
            {
                return;
            }
			
            // If there is a singleton but this is not it, destroy this.
            if (_instance != null && _instance != this)
            {
                Destroy(gameObject);
                return;
            }
			
            // Otherwise, set this as the singleton.
            _instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }
}