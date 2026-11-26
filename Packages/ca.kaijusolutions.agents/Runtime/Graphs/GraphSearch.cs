using System;
using System.Collections.Generic;
using Unity.Burst;
using Unity.Collections;

namespace KaijuSolutions.Agents.Graphs
{
    internal struct GraphFactMask
    {
        public ulong Keys;
        public ulong Values;
        public bool Matches(ulong facts) => (facts & Keys) == Values;
        public ulong Apply(ulong facts) => (facts & ~Keys) | Values;
    }

    internal struct GraphOperator
    {
        public GraphFactMask Preconditions;
        public GraphFactMask Effects;
        public float Cost;
        public int Index;
    }

    // Shared within a World. The immutable action table is built once per GOAP domain.
    internal sealed class GraphDomain : IDisposable
    {
        private readonly List<GraphFact> atoms;
        internal readonly GraphFactMask Goal;
        internal NativeArray<HtnTask> Tasks;
        internal NativeArray<int> Children;
        internal NativeArray<GraphOperator> Actions;

        private static int Atom(List<GraphFact> atoms, GraphFact fact)
        {
            for (int i = 0; i < atoms.Count; i++)
                if (atoms[i].Key == fact.Key && (fact.Expected.Type == GraphType.Boolean ||
                    atoms[i].Expected.Matches(fact.Expected))) return i;
            return -1;
        }

        internal static List<GraphFact> Layout(KaijuGraph graph, GraphStep root, out HashSet<GraphStep> reachable)
        {
            var atoms = new List<GraphFact>();
            void Declare(GraphFact[] facts)
            {
                foreach (var fact in facts)
                {
                    if (Atom(atoms, fact) >= 0) continue;
                    if (atoms.Count >= 64) throw new FormatException("Planner domain exceeds 64 distinct fact tests");
                    atoms.Add(fact);
                }
            }

            var visited = new HashSet<GraphStep>();
            void Collect(GraphStep step)
            {
                if (!visited.Add(step)) return;
                Declare(step.Preconditions);
                Declare(step.Effects);
                foreach (var child in step.Children) Collect(graph.Steps[child]);
            }
            Collect(root);
            reachable = visited;
            return atoms;
        }

        internal GraphDomain(KaijuGraph graph, GraphStep root)
        {
            atoms = Layout(graph, root, out var visited);
            GraphFactMask Mask(GraphFact[] facts, bool effects)
            {
                var result = new GraphFactMask();
                foreach (var fact in facts)
                {
                    ulong bit = 1UL << Atom(atoms, fact);
                    result.Keys |= bit;
                    if (fact.Expected.Type != GraphType.Boolean || fact.Value) result.Values |= bit;
                    if (effects && fact.Expected.Type != GraphType.Boolean)
                        for (int i = 0; i < atoms.Count; i++)
                            if (atoms[i].Key == fact.Key) result.Keys |= 1UL << i;
                }
                return result;
            }
            Goal = Mask(root.Effects, false);
            var operators = new GraphOperator[graph.Steps.Count];
            for (int i = 0; i < operators.Length; i++)
            {
                var step = graph.Steps[i];
                if (visited.Contains(step))
                    operators[i] = new GraphOperator { Index = i, Cost = step.Cost,
                        Preconditions = Mask(step.Preconditions, false), Effects = Mask(step.Effects, true) };
            }
            if (root.Op == GraphOp.Htn)
            {
                var tasks = new HtnTask[operators.Length];
                var children = new List<int>();
                for (int i = 0; i < tasks.Length; i++)
                {
                    var step = graph.Steps[i];
                    if (!visited.Contains(step)) continue;
                    tasks[i] = new HtnTask { Operation = step.Op, Before = operators[i].Preconditions,
                        After = operators[i].Effects, FirstChild = children.Count, Count = step.Children.Length };
                    children.AddRange(step.Children);
                }
                Tasks = new NativeArray<HtnTask>(tasks, Allocator.Persistent);
                Children = new NativeArray<int>(children.ToArray(), Allocator.Persistent);
                return;
            }
            var choices = new GraphOperator[root.Children.Length];
            for (int i = 0; i < choices.Length; i++) choices[i] = operators[root.Children[i]];
            Actions = new NativeArray<GraphOperator>(choices, Allocator.Persistent);
        }

        internal ulong Snapshot(GraphContext context)
        {
            ulong facts = 0;
            for (int i = 0; i < atoms.Count; i++)
            {
                var atom = atoms[i];
                var value = context.Get(atom.Key);
                if (value.Type == GraphType.Boolean ? value.Boolean : value.Matches(atom.Expected)) facts |= 1UL << i;
            }
            return facts;
        }

        public void Dispose()
        {
            if (Tasks.IsCreated) Tasks.Dispose();
            if (Children.IsCreated) Children.Dispose();
            if (Actions.IsCreated) Actions.Dispose();
        }
    }

    internal struct GraphSearchNode
    {
        public ulong Facts;
        public float Cost;
        public int Previous;
        public int Action;
    }

    [BurstCompile]
    internal struct GraphSearch : IDisposable
    {
        private NativeList<GraphSearchNode> nodes;
        private NativeList<int> heap;
        private NativeHashMap<ulong, float> visited;
        internal int Expansions;
        internal int Winner;
        internal byte Limited;

        internal GraphSearch(ulong start)
        {
            nodes = new NativeList<GraphSearchNode>(16, Allocator.Persistent);
            heap = new NativeList<int>(16, Allocator.Persistent);
            visited = new NativeHashMap<ulong, float>(16, Allocator.Persistent);
            Winner = -1;
            Expansions = 0;
            Limited = 0;
            nodes.Add(new GraphSearchNode { Facts = start, Previous = -1 });
            heap.Add(0);
            visited.Add(start, 0);
        }

        // Stable priority queue. Insertion index breaks cost ties in authoring order.
        private bool Before(int a, int b) =>
            nodes[a].Cost < nodes[b].Cost || nodes[a].Cost == nodes[b].Cost && a < b;

        private void Push(int index)
        {
            int slot = heap.Length;
            heap.Add(index);
            while (slot > 0)
            {
                int parent = (slot - 1) / 2;
                if (!Before(index, heap[parent])) break;
                heap[slot] = heap[parent];
                slot = parent;
            }
            heap[slot] = index;
        }

        private int Pop()
        {
            int index = heap[0], last = heap[heap.Length - 1];
            heap.RemoveAt(heap.Length - 1);
            if (heap.Length == 0) return index;
            int slot = 0;
            while (slot * 2 + 1 < heap.Length)
            {
                int child = slot * 2 + 1;
                if (child + 1 < heap.Length && Before(heap[child + 1], heap[child])) child++;
                if (!Before(heap[child], last)) break;
                heap[slot] = heap[child];
                slot = child;
            }
            heap[slot] = last;
            return index;
        }

        [BurstCompile]
        internal static GraphResult Advance(ref GraphSearch search, in NativeArray<GraphOperator> actions, in GraphFactMask goal, int budget)
        {
            while (search.heap.Length > 0 && budget-- > 0)
            {
                int index = search.Pop();
                var current = search.nodes[index];
                if (current.Cost > search.visited[current.Facts]) continue;
                search.Expansions++;
                if (goal.Matches(current.Facts)) { search.Winner = index; return GraphResult.Succeeded; }
                for (int i = 0; i < actions.Length; i++)
                {
                    var op = actions[i];
                    if (!op.Preconditions.Matches(current.Facts)) continue;
                    ulong next = op.Effects.Apply(current.Facts);
                    float cost = current.Cost + op.Cost;
                    if (search.visited.TryGetValue(next, out float best) && best <= cost) continue;
                    if (search.nodes.Length >= 8192) { search.Limited = 1; return GraphResult.Failed; }
                    search.visited[next] = cost;
                    int child = search.nodes.Length;
                    search.nodes.Add(new GraphSearchNode { Facts = next, Cost = cost, Previous = index, Action = op.Index });
                    search.Push(child);
                }
            }
            return search.heap.Length > 0 ? GraphResult.Running : GraphResult.Failed;
        }

        internal void Collect(List<int> steps)
        {
            for (int i = Winner; nodes[i].Previous >= 0; i = nodes[i].Previous) steps.Add(nodes[i].Action);
            steps.Reverse();
        }

        public void Dispose()
        {
            if (!nodes.IsCreated) return;
            nodes.Dispose();
            visited.Dispose();
            heap.Dispose();
        }
    }
}
