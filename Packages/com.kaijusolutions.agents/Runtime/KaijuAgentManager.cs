using UnityEngine;
using UnityEngine.Rendering;

namespace KaijuSolutions.Agents
{
    /// <summary>
    /// Manager agents.
    /// </summary>
    public class KaijuAgentManager : MonoBehaviour
    {
        /// <summary>
        /// The auto-generated material for displaying lines.
        /// </summary>
        private Material _lineMaterial;
        
        /// <summary>
        /// Cached shader value for use with line rendering.
        /// </summary>
        private readonly int _srcBlend = Shader.PropertyToID("_SrcBlend");
        
        /// <summary>
        /// Cached shader value for use with line rendering.
        /// </summary>
        private readonly int _dstBlend = Shader.PropertyToID("_DstBlend");
        
        /// <summary>
        /// Cached shader value for use with line rendering.
        /// </summary>
        private readonly int _cull = Shader.PropertyToID("_Cull");
        
        /// <summary>
        /// Cached shader value for use with line rendering.
        /// </summary>
        private readonly int _zWrite = Shader.PropertyToID("_ZWrite");
        
        /// <summary>
        /// The singleton manager instance.
        /// </summary>
        private static KaijuAgentManager _instance;
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
            
            // Unity has a built-in shader that is useful for drawing simple colored things.
            _lineMaterial = new(Shader.Find("Hidden/Internal-Colored"))
            {
                hideFlags = HideFlags.HideAndDontSave
            };
            
            // Turn on alpha blending.
            _lineMaterial.SetInt(_srcBlend, (int)BlendMode.SrcAlpha);
            _lineMaterial.SetInt(_dstBlend, (int)BlendMode.OneMinusSrcAlpha);
            
            // Turn backface culling off.
            _lineMaterial.SetInt(_cull, (int)CullMode.Off);
            
            // Turn off depth writes.
            _lineMaterial.SetInt(_zWrite, 0);
        }
        
        /// <summary>
        /// OnRenderObject is called after camera has rendered the Scene.
        /// </summary>
        private void OnRenderObject()
        {
            _lineMaterial.SetPass(0);
            
            GL.PushMatrix();
            GL.MultMatrix(Matrix4x4.identity);
            GL.Begin(GL.LINES);
            
            GL.End();
            GL.PopMatrix();
        }
    }
}