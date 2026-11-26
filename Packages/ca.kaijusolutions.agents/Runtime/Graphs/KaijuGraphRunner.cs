using Unity.Entities;
using UnityEngine;
using System.Collections.Generic;

namespace KaijuSolutions.Agents.Graphs
{
    public interface IGraphServiceProvider
    {
        void Register(GraphServices services);
    }

    [DisallowMultipleComponent]
    [RequireComponent(typeof(KaijuAgent))]
    public sealed class KaijuGraphRunner : MonoBehaviour
    {
        [SerializeField] private KaijuGraph graph;
        public KaijuGraph Graph
        {
            get => graph;
            set { if (graph != value) { OnDisable(); graph = value; } }
        }
        private KaijuAgent agent;
        public GraphExecution Execution { get; private set; }

        private void Awake() => agent = GetComponent<KaijuAgent>();
        private void LateUpdate()
        {
            if (Execution != null && (!agent.isActiveAndEnabled || agent.SimulationEntity != Execution.Entity)) OnDisable();
            if (Execution != null || !graph || !agent.isActiveAndEnabled) return;
            TryStart(graph, out _);
        }

        public bool TryStart(KaijuGraph behavior, out GraphExecution execution, IReadOnlyDictionary<string, GraphValue> inputs = null)
        {
            execution = null;
            if (!behavior || !isActiveAndEnabled || !agent || !agent.isActiveAndEnabled) return false;
            var world = World.DefaultGameObjectInjectionWorld;
            if (world == null || !world.IsCreated || !world.EntityManager.Exists(agent.SimulationEntity)) return false;
            var services = new GraphServices();
            GraphMovementServices.Register(services, agent);
            foreach (var provider in GetComponents<IGraphServiceProvider>()) provider.Register(services);
            execution = world.GetOrCreateSystemManaged<KaijuGraphSystem>().Start(agent.SimulationEntity, behavior, services, inputs);
            Execution = execution;
            return true;
        }

        private void OnDisable()
        {
            Execution?.Cancel();
            Execution = null;
        }
    }
}
