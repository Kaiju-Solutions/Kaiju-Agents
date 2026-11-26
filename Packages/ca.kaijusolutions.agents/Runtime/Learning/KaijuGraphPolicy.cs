#if COM_UNITY_ML_AGENTS
using KaijuSolutions.Agents.Graphs;
using Unity.MLAgents;
using Unity.MLAgents.Policies;
using UnityEngine;

namespace KaijuSolutions.Agents.Learning
{
    /// <summary>Registers the attached ML agent as a graph action. Existing DecisionRequesters retain their schedule.</summary>
    [DisallowMultipleComponent, RequireComponent(typeof(Agent))]
    public sealed class KaijuGraphPolicy : MonoBehaviour, IGraphServiceProvider
    {
        [SerializeField] private string service = "policy";
        [SerializeField] private bool finishOnEpisode = true;
        [SerializeField] private bool endEpisodeOnRelease;
        private Session owner;
        public bool AcceptActions => isActiveAndEnabled && owner != null && owner.AcceptsActions;

        public void Register(GraphServices services) => services.Policies.Add(service, () => new Session(this));
        private void OnDisable() => owner?.Cancel(null);

        private sealed class Session : IGraphAction
        {
            private readonly KaijuGraphPolicy policy;
            private Agent agent;
            private KaijuAgent movement;
            private int episode;
            private bool externalRequester;
            private bool armed;
            private bool requested;
            internal bool AcceptsActions => armed && agent && agent.isActiveAndEnabled && (!policy.finishOnEpisode || agent.CompletedEpisodes == episode);
            internal Session(KaijuGraphPolicy policy) => this.policy = policy;

            public GraphResult Begin(GraphContext context)
            {
                if (!policy || !policy.isActiveAndEnabled || policy.owner != null) return GraphResult.Failed;
                agent = policy.GetComponent<Agent>();
                if (!agent.isActiveAndEnabled) return GraphResult.Failed;
                var behavior = policy.GetComponent<BehaviorParameters>();
                if (behavior && behavior.BehaviorType == BehaviorType.InferenceOnly && !behavior.Model) return GraphResult.Failed;
                movement = policy.GetComponent<KaijuAgent>();
                externalRequester = policy.GetComponent<DecisionRequester>() != null;
                episode = agent.CompletedEpisodes;
                policy.owner = this;
                requested = true;
                Academy.Instance.AgentPreStep += PreStep;
                return GraphResult.Running;
            }
            private void PreStep(int step)
            {
                if (policy.owner != this || !agent.isActiveAndEnabled) return;
                armed = true;
                if (!externalRequester && requested) agent.RequestDecision();
                requested = false;
            }
            public GraphResult Tick(GraphContext context, float delta)
            {
                if (!policy || policy.owner != this || !policy.isActiveAndEnabled || !agent || !agent.isActiveAndEnabled)
                {
                    Release(false);
                    return GraphResult.Failed;
                }
                if (policy.finishOnEpisode && episode != agent.CompletedEpisodes)
                {
                    Release(false);
                    return GraphResult.Succeeded;
                }
                requested = true;
                return GraphResult.Running;
            }
            public void Cancel(GraphContext context) => Release(true);
            private void Release(bool endEpisode)
            {
                if (!policy || policy.owner != this) return;
                if (Academy.IsInitialized) Academy.Instance.AgentPreStep -= PreStep;
                policy.owner = null;
                if (movement) movement.Control3 = Vector3.zero;
                if (endEpisode && policy.endEpisodeOnRelease && agent && agent.isActiveAndEnabled && agent.CompletedEpisodes == episode)
                    agent.EndEpisode();
            }
        }
    }
}
#endif
