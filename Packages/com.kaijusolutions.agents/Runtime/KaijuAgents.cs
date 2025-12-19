using System.Linq;
using UnityEngine;

namespace KaijuSolutions.Agents
{
    /// <summary>
    /// General Kaiju Agents functions.
    /// </summary>
    public static class KaijuAgents
    {
        /// <summary>
        /// Assign a component, validating if it meets requirements.
        /// </summary>
        /// <param name="go">The GameObject to assign the component to.</param>
        /// <param name="current">The currently assigned value of the component to validate.</param>
        /// <param name="self">If the component can be attached to the calling GameObject.</param>
        /// <param name="children">If the component can be in the children of the calling GameObject.</param>
        /// <param name="parents">If the component can be in the parents of the calling GameObject.</param>
        /// <typeparam name="T">The type of component to assign.</typeparam>
        /// <returns>If a new assignment was made.</returns>
        public static bool AssignComponent<T>(this GameObject go, ref T current, bool self = true, bool children = false, bool parents = false) where T : Component
        {
            // If one currently exists, see if it meets our requirements to be assigned.
            if (current != null)
            {
                // Grab the component's GameObject.
                GameObject other = current.gameObject;
                
                // If it is itself.
                if (self && go == other)
                {
                    return false;
                }
                
                // Check if it is within the children or parents.
                Transform t = other.transform;
                if ((children && go.GetComponentsInChildren<Transform>().Contains(t)) || (parents && go.GetComponentsInParent<Transform>().Contains(t)))
                {
                    return false;
                }
            }
            
            // Check on the GameObject itself.
            if (self && go.TryGetComponent(out current))
            {
                return true;
            }
            
            // Check in children.
            if (children)
            {
                current = go.GetComponentInChildren<T>();
                if (current != null)
                {
                    return true;
                }
            }
            
            // Check in the parents.
            if (parents)
            {
                current = go.GetComponentInParent<T>();
                if (current != null)
                {
                    return true;
                }
            }
            
            // Try and add the component.
            if (!self)
            {
                return false;
            }
            
            current = go.AddComponent<T>();
            return true;

        }
        
        /// <summary>
        /// Assign a component, validating if it meets requirements.
        /// </summary>
        /// <param name="c">A component of the GameObject to assign the component to.</param>
        /// <param name="current">The currently assigned value of the component to validate.</param>
        /// <param name="self">If the component can be attached to the calling GameObject.</param>
        /// <param name="children">If the component can be in the children of the calling GameObject.</param>
        /// <param name="parents">If the component can be in the parents of the calling GameObject.</param>
        /// <typeparam name="T">The type of component to assign.</typeparam>
        /// <returns>If a new assignment was made.</returns>
        public static bool AssignComponent<T>(this Component c, ref T current, bool self = true, bool children = false, bool parents = false) where T : Component
        {
            return c.gameObject.AssignComponent(ref current, self, children, parents);
        }
    }
}