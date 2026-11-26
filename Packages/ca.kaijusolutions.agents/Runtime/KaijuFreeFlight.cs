using System.Collections.Generic;
using UnityEngine;

namespace KaijuSolutions.Agents
{
    /// <summary>Enables XYZ steering on a Transform or Rigidbody agent.</summary>
    [DisallowMultipleComponent]
    [AddComponentMenu("Kaiju Solutions/Agents/Free Flight")]
    public sealed class KaijuFreeFlight : MonoBehaviour
    {
        [Tooltip("Pitch toward the flight direction. Otherwise automatic facing stays level.")]
        public bool pitchToVelocity;
        internal readonly List<KaijuFlightInput> Inputs = new();
        private KaijuAgent agent;
        private Rigidbody body;
        private bool gravity;
        private bool frozeY;

        private void OnEnable()
        {
            if (!TryGetComponent(out agent) || !(agent is KaijuTransformAgent || agent is KaijuRigidbodyAgent))
            {
                Debug.LogError("Free Flight requires a Kaiju Transform Agent or Rigidbody Agent.", this);
                enabled = false;
                return;
            }
            if (agent is KaijuRigidbodyAgent && TryGetComponent(out body))
            {
                gravity = body.useGravity;
                frozeY = (body.constraints & RigidbodyConstraints.FreezePositionY) != 0;
                body.useGravity = false;
                body.constraints &= ~RigidbodyConstraints.FreezePositionY;
            }
            agent.SetFlight(this);
        }

        private void OnDisable()
        {
            if (agent && agent.FreeFlight == this) agent.SetFlight(null);
            if (!body) return;
            if (!body.isKinematic)
            {
                Vector3 v = body.linearVelocity;
                body.linearVelocity = new Vector3(v.x, 0, v.z);
            }
            body.useGravity = gravity;
            if (frozeY) body.constraints |= RigidbodyConstraints.FreezePositionY;
            body = null;
        }

        /// <summary>Check a straight flight segment for solid colliders in the supplied obstacle layers.</summary>
        public bool HasClearance(Vector3 destination, float radius, LayerMask obstacles)
        {
            Vector3 start = transform.position;
            Vector3 offset = destination - start;
            float distance = offset.magnitude;
            if (radius > 0 && Physics.CheckSphere(start, radius, obstacles, QueryTriggerInteraction.Ignore)) return false;
            if (distance == 0) return true;
            return radius > 0
                ? !Physics.SphereCast(start, radius, offset / distance, out _, distance, obstacles, QueryTriggerInteraction.Ignore)
                : !Physics.Raycast(start, offset / distance, distance, obstacles, QueryTriggerInteraction.Ignore);
        }
    }
}
