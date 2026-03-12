using KaijuSolutions.Agents;
using UnityEngine;

namespace Samples.Keyboard
{
    /// <summary>
    /// Simple controller to manually move an agent. Use WASD or the arrow keys to move the agent, and Q and E to turn the agent.
    /// </summary>
    [DisallowMultipleComponent]
#if UNITY_EDITOR
    [HelpURL("https://agents.kaijusolutions.ca/manual/keyboard.html")]
    [AddComponentMenu("Kaiju Solutions/Agents/Samples/Keyboard Controller", 15)]
#endif
    public class KeyboardController : KaijuController
    {
        /// <summary>
        /// Update is called every frame, if the MonoBehaviour is enabled.
        /// </summary>
        private void Update()
        {
            Vector2 movement = Vector2.zero;
#if !ENABLE_LEGACY_INPUT_MANAGER
            if (UnityEngine.InputSystem.Keyboard.current.wKey.isPressed || UnityEngine.InputSystem.Keyboard.current.upArrowKey.isPressed)
            {
                movement.y += 1;
            }
            
            if (UnityEngine.InputSystem.Keyboard.current.sKey.isPressed || UnityEngine.InputSystem.Keyboard.current.downArrowKey.isPressed)
            {
                movement.y -= 1;
            }
            
            if (UnityEngine.InputSystem.Keyboard.current.dKey.isPressed || UnityEngine.InputSystem.Keyboard.current.rightArrowKey.isPressed)
            {
                movement.x += 1;
            }
            
            if (UnityEngine.InputSystem.Keyboard.current.aKey.isPressed || UnityEngine.InputSystem.Keyboard.current.leftArrowKey.isPressed)
            {
                movement.x -= 1;
            }
#else
            if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
            {
                movement.y += 1;
            }
            
            if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
            {
                movement.y -= 1;
            }
            
            if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
            {
                movement.x += 1;
            }
            
            if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
            {
                movement.x -= 1;
            }
#endif
            Agent.Control = movement;
#if !ENABLE_LEGACY_INPUT_MANAGER
            if (UnityEngine.InputSystem.Keyboard.current.eKey.isPressed && !UnityEngine.InputSystem.Keyboard.current.qKey.isPressed)
            {
                Agent.Spin = 1;
            }
            else if (UnityEngine.InputSystem.Keyboard.current.qKey.isPressed && !UnityEngine.InputSystem.Keyboard.current.eKey.isPressed)
            {
                Agent.Spin = -1;
            }
            else
            {
                Agent.Spin = null;
            }
#else
            if (Input.GetKey(KeyCode.E) && !Input.GetKey(KeyCode.Q))
            {
                Agent.Spin = 1;
            }
            else if (Input.GetKey(KeyCode.Q) && !Input.GetKey(KeyCode.E))
            {
                Agent.Spin = -1;
            }
            else
            {
                Agent.Spin = null;
            }
#endif
        }
    }
}