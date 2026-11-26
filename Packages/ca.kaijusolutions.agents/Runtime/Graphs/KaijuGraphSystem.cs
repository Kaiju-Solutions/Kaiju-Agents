using System;
using System.Collections.Generic;
using Unity.Entities;
using Unity.Collections;

namespace KaijuSolutions.Agents.Graphs
{
    [WorldSystemFilter(WorldSystemFilterFlags.LocalSimulation)]
    [UpdateInGroup(typeof(FixedStepSimulationSystemGroup))]
    [UpdateBefore(typeof(KaijuFixedSimulationSystem))]
    public partial class KaijuGraphSystem : SystemBase
    {
        private readonly List<GraphExecution> active = new();
        private readonly Dictionary<Entity, GraphExecution> owners = new();
        private bool shuttingDown;

        private readonly Dictionary<(KaijuGraph, int), GraphDomain> domains = new();
        private readonly Dictionary<(KaijuGraph, int), GraphUtilityLayout> selectors = new();
        private NativeList<float> scores;
        internal GraphUtilityLayout Selector(KaijuGraph graph, int index)
        {
            var key = (graph, index);
            if (!selectors.TryGetValue(key, out var selector))
                selectors.Add(key, selector = new GraphUtilityLayout(graph, graph.Steps[index]));
            return selector;
        }
        internal NativeArray<float> ScoreBuffer(int length)
        {
            if (!scores.IsCreated) scores = new NativeList<float>(length, Allocator.Persistent);
            scores.ResizeUninitialized(length);
            return scores.AsArray();
        }
        internal GraphDomain Domain(KaijuGraph graph, int index)
        {
            var key = (graph, index);
            if (!domains.TryGetValue(key, out var domain)) domains.Add(key, domain = new GraphDomain(graph, graph.Steps[index]));
            return domain;
        }

        private readonly Queue<GraphPlan> waitingPlans = new();
        private int remainingExpansions;
        private int searchBudget = 1024;
        public int PlannerExpansionsPerTick
        {
            get => searchBudget;
            set => searchBudget = value > 0 ? value : throw new ArgumentOutOfRangeException(nameof(value));
        }

        internal GraphResult Search(GraphPlan plan)
        {
            if (plan.Status != GraphResult.Running || plan.Queued) return plan.Status;
            if (remainingExpansions > 0)
            {
                int before = plan.Expansions;
                plan.Search(Math.Min(remainingExpansions, 32));
                remainingExpansions -= Math.Max(1, plan.Expansions - before);
            }
            if (plan.Status == GraphResult.Running)
            {
                plan.Queued = true;
                waitingPlans.Enqueue(plan);
            }
            return plan.Status;
        }

        public GraphExecution Start(Entity entity, KaijuGraph graph, GraphServices services = null,
            IReadOnlyDictionary<string, GraphValue> inputs = null)
        {
            if (shuttingDown) throw new InvalidOperationException("Graph world is shutting down");
            if (!graph) throw new ArgumentNullException(nameof(graph));
            if (!EntityManager.Exists(entity)) throw new ArgumentException("Expected a live entity", nameof(entity));
            var execution = new GraphExecution(World, entity, graph, services, inputs);
            owners.TryGetValue(entity, out var previous);
            owners[entity] = execution;
            active.Add(execution);
            previous?.Cancel();
            return execution;
        }

        public bool TryGetExecution(Entity entity, out GraphExecution execution) =>
            owners.TryGetValue(entity, out execution) && execution.Result == GraphResult.Running;

        protected override void OnUpdate()
        {
            remainingExpansions = searchBudget;
            int pending = waitingPlans.Count;
            while (pending-- > 0 && remainingExpansions > 0)
            {
                var plan = waitingPlans.Dequeue();
                plan.Queued = false;
                if (!plan.Disposed) Search(plan);
            }
            int count = active.Count;
            for (int i = 0; i < count; i++)
            {
                var execution = active[i];
                if (!EntityManager.Exists(execution.Entity)) execution.Cancel();
                else execution.Advance(SystemAPI.Time.DeltaTime);
            }
            for (int i = active.Count - 1; i >= 0; i--)
            {
                var execution = active[i];
                if (execution.Result == GraphResult.Running) continue;
                if (owners.TryGetValue(execution.Entity, out var owner) && owner == execution) owners.Remove(execution.Entity);
                active.RemoveAt(i);
            }
        }

        protected override void OnDestroy()
        {
            shuttingDown = true;
            foreach (var execution in active) execution.Cancel();
            active.Clear();
            owners.Clear();
            foreach (var domain in domains.Values) domain.Dispose();
            domains.Clear();
            selectors.Clear();
            waitingPlans.Clear();
            if (scores.IsCreated) scores.Dispose();
        }
    }
}
