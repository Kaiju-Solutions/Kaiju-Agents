using System;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace KaijuSolutions.Agents
{
    /// <summary>
    /// Helpful developer UI. This displays buttons to select cameras on the left side and buttons to select scenes on the right side.
    /// </summary>
    [DisallowMultipleComponent]
    [DefaultExecutionOrder(int.MaxValue)]
#if UNITY_EDITOR
    [SelectionBase]
    [Icon("Packages/com.kaijusolutions.agents/Editor/Icon.png")]
    [HelpURL("https://agents.kaijusolutions.ca/manual/developer-ui.html")]
#endif
    public class KaijuDeveloperUI : KaijuGlobalController
    {
        /// <summary>
        /// The padding for the UI.
        /// </summary>
        private const float Padding = 5;
        
        /// <summary>
        /// The height for UI elements.
        /// </summary>
        private const float Height = 20;
        
        /// <summary>
        /// Button widths.
        /// </summary>
        public float Width
        {
            get => width;
            set => width = Mathf.Max(value, width);
        } 
        
        /// <summary>
        /// Button widths.
        /// </summary>
#if UNITY_EDITOR
        [Tooltip("Button widths.")]
#endif
        [Min(0)]
        [SerializeField]
        private float width = 200;
        
        /// <summary>
        /// If there are any dynamically-spawned cameras in the scene. This will enable a button to collect cameras at runtime.
        /// </summary>
#if UNITY_EDITOR
        [Tooltip("If there are any dynamically-spawned cameras in the scene. This will enable a button to collect cameras at runtime.")]
#endif
        [SerializeField]
        public bool dynamicCameras;
        
        /// <summary>
        /// All cameras
        /// </summary>
        private Camera[] _cameras = Array.Empty<Camera>();
        
        /// <summary>
        /// Get all cameras.
        /// </summary>
        private void GetCameras()
        {
            _cameras = FindObjectsByType<Camera>(sortMode: FindObjectsSortMode.None).OrderBy(x => x.name).ToArray();
        }
        
        /// <summary>
        /// Start is called on the frame when a script is enabled just before any of the Update methods are called the first time. This function can be a coroutine.
        /// </summary>
        private void Start()
        {
            GetCameras();
        }
        
        /// <summary>
        /// OnGUI is called for rendering and handling GUI events.
        /// </summary>
        private void OnGUI()
        {
            // Nothing to do with no width.
            if (width <= 0)
            {
                return;
            }
            
            // Get the bounds of the screen.
            int screenWidth = Screen.width;
            int screenHeight = Screen.height;
            
            // Calculate the total drawable area.
            float max = screenWidth - 2 * Padding;
            
            // On the left, get the area for listing our cameras.
            float camerasWidth;
            float current;
            
            // If we know we have static cameras and there is only one, no point in rendering anything for them.
            if (dynamicCameras || _cameras.Length > 1)
            {
                camerasWidth = dynamicCameras || _cameras.Length > 1 ? Mathf.Min(width, max) : 0;
                current = Padding;
                if (_cameras.Length > 1)
                {
                    for (int i = 0; i < _cameras.Length; i++)
                    {
                        if (GUI.Button(new(Padding, current, camerasWidth, Height),  _cameras[i].name))
                        {
                            SetCamera(i);
                        }
                        
                        current += Padding + Height;
                        if (current + Padding + Height >= screenHeight)
                        {
                            break;
                        }
                    }
                }
                
                if (current + Padding + Height < screenHeight && GUI.Button(new(Padding, current, camerasWidth, Height),  "Get Cameras"))
                {
                    GetCameras();
                }
                
                if (camerasWidth >= max)
                {
                    return;
                }
            }
            else
            {
                camerasWidth = 0;
            }
            
            // Render scene control buttons.
            current = Padding;
            float scenesWidth = Mathf.Min(width, max - camerasWidth);
            float x = screenWidth - scenesWidth - Padding;
            
            // Display a reset button for the current scene first.
            Scene active = SceneManager.GetActiveScene();
            if (GUI.Button(new(x, current, scenesWidth, Height), "Reset"))
            {
#if UNITY_EDITOR
                // In the editor, our scene might not be in the build, so load it by path.
                SceneManager.LoadScene(active.path);
#else
                SceneManager.LoadScene(active.buildIndex);
#endif
            }
            
            // Display buttons for all other scenes.
            int count = SceneManager.sceneCountInBuildSettings;
            for (int i = 0; i < count; i++)
            {
                // If there is not enough space, stop.
                if (current + Padding + Height >= screenHeight)
                {
                    return;
                }
                
                // Ensure this is not the same scene we currently have loaded.
                Scene scene = SceneManager.GetSceneByBuildIndex(i);
                if (active == scene)
                {
                    continue;
                }
                
                // Display the button.
                current += Padding + Height;
                if (GUI.Button(new(x, current, scenesWidth, Height), scene.name))
                {
                    SceneManager.LoadScene(i);
                }
            }
        }
        
        /// <summary>
        /// Method to set which camera is active.
        /// </summary>
        /// <param name="index">The index to set active while disabling all other cameras.</param>
        private void SetCamera(int index)
        {
            for (int i = 0; i < _cameras.Length; i++)
            {
                _cameras[index].enabled = i == index;
            }
        }
    }
}