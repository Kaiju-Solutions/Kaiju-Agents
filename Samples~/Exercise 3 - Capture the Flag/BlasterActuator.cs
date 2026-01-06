using KaijuSolutions.Agents.Actuators;
using UnityEngine;

namespace KaijuSolutions.Agents.Exercises.CTF
{
    /// <summary>
    /// The blaster for use by <see cref="Trooper"/>s.
    /// </summary>
    [HelpURL("https://agents.kaijusolutions.ca/manual/capture-the-flag.html#blaster-actuator")]
    [AddComponentMenu("Kaiju Solutions/Agents/Exercises/Capture the Flag/Blaster Actuator", 26)]
    public class BlasterActuator : KaijuAttackActuator
    {
        /// <summary>
        /// The ammo for this blaster.
        /// </summary>
        public int Ammo
        {
            get => _ammo;
            set => _ammo = Mathf.Clamp(0, value, CaptureTheFlagManager.Ammo);
        }
        
        /// <summary>
        /// The ammo for this blaster.
        /// </summary>
        private int _ammo;
        
        /// <summary>
        /// The <see cref="Trooper"/> this is attached to.
        /// </summary>
        private Trooper _trooper;
        
        /// <summary>
        /// This function is called when the object becomes enabled and active.
        /// </summary>
        protected override void OnEnable()
        {
            base.OnEnable();

            if (Agent == null)
            {
                return;
            }
            
            _trooper = Agent.GetComponent<Trooper>();
            if (_trooper == null)
            {
                Debug.LogError($"Blaster - No trooper component attached to the agent \"{Agent.name}\".", this);
                return;
            }
            
            _ammo = CaptureTheFlagManager.Ammo;
            
            // Make the weapon colors match the team.
            if (lineRenderer)
            {
                lineRenderer.startColor = lineRenderer.endColor = _trooper.TeamOne ? CaptureTheFlagManager.ColorOne : CaptureTheFlagManager.ColorTwo;
            }
        }
        
        /// <summary>
        /// This function is called when the behaviour becomes disabled.
        /// </summary>
        protected override void OnDisable()
        {
            base.OnDisable();
            _trooper = null;
            _ammo = 0;
        }

        /// <summary>
        /// Any conditions which must be passed to begin running the actuator. This does not need to account for the <see cref="KaijuAttackActuator.Charge"/> or <see cref="KaijuAttackActuator.Cooldown"/>.
        /// </summary>
        /// <returns>If the conditions to run this were passed.</returns>
        protected override bool PreConditions()
        {
            // Needs to have ammo.
            return _ammo > 0;
        }
        
        /// <summary>
        /// Any final actions to perform after the actuator has performed.
        /// </summary>
        /// <param name="success">If it succeeded or not.</param>
        protected override void PostActions(bool success)
        {
            Ammo--;
        }
        
        /// <summary>
        /// Handle the hit logic.
        /// </summary>
        /// <param name="hit">The hit details.</param>
        /// <param name="t">The transform currently being checked. This may not be the same as the one in the hit parameter in the case of checking parents.</param>
        /// <returns>If the attack was a success or not.</returns>
        protected override bool HandleHit(RaycastHit hit, Transform t)
        {
            // Only care about hitting other troopers.
            if (!t.TryGetComponent(out Trooper trooper))
            {
                return false;
            }
            
            trooper.TakeDamage(_trooper);
            return true;
        }
    }
}