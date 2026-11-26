using System;
using System.Collections.Generic;
using Unity.Burst;
using Unity.Collections;

namespace KaijuSolutions.Agents.Graphs
{
    internal struct HtnTask
    {
        internal GraphFactMask Before, After;
        internal int FirstChild, Count;
        internal GraphOp Operation;
    }

    // Persistent linked prefixes let alternatives share both unfinished tasks and the plan so far.
    [BurstCompile]
    internal struct GraphDecomposition : IDisposable
    {
        private struct Link { internal int Task, Next; }
        private struct Candidate { internal ulong Facts; internal int Pending, Completed; }
        private NativeList<Link> links;
        private NativeList<Candidate> frontier;
        internal int Expansions;
        internal byte Limited;
        private int winner;

        internal GraphDecomposition(ulong facts, int root)
        {
            links = new NativeList<Link>(16, Allocator.Persistent);
            frontier = new NativeList<Candidate>(8, Allocator.Persistent);
            links.Add(new Link { Task = root, Next = -1 });
            frontier.Add(new Candidate { Facts = facts, Pending = 0, Completed = -1 });
            Expansions = 0;
            Limited = 0;
            winner = -1;
        }

        private int Prepend(int task, int tail)
        {
            int index = links.Length;
            links.Add(new Link { Task = task, Next = tail });
            return index;
        }

        [BurstCompile]
        internal static GraphResult Advance(ref GraphDecomposition search, in NativeArray<HtnTask> tasks,
            in NativeArray<int> children, int budget)
        {
            while (search.frontier.Length > 0 && budget-- > 0)
            {
                int last = search.frontier.Length - 1;
                var item = search.frontier[last];
                search.frontier.RemoveAt(last);
                if (item.Pending < 0) { search.winner = item.Completed; return GraphResult.Succeeded; }
                if (search.Expansions++ >= 8192) { search.Limited = 1; return GraphResult.Failed; }
                var head = search.links[item.Pending];
                var task = tasks[head.Task];
                if (!task.Before.Matches(item.Facts)) continue;
                if (task.Operation == GraphOp.Htn)
                {
                    for (int i = task.Count - 1; i >= 0; i--)
                    {
                        int methodIndex = children[task.FirstChild + i];
                        var method = tasks[methodIndex];
                        if (!method.Before.Matches(item.Facts)) continue;
                        if (search.links.Length + method.Count > 65536 || search.frontier.Length >= 8192)
                        { search.Limited = 1; return GraphResult.Failed; }
                        var branch = item;
                        branch.Completed = search.Prepend(~methodIndex, item.Completed);
                        branch.Pending = head.Next;
                        for (int j = method.Count - 1; j >= 0; j--)
                            branch.Pending = search.Prepend(children[method.FirstChild + j], branch.Pending);
                        search.frontier.Add(branch);
                    }
                }
                else
                {
                    item.Facts = task.After.Apply(item.Facts);
                    item.Completed = search.Prepend(head.Task, item.Completed);
                    item.Pending = head.Next;
                    search.frontier.Add(item);
                }
            }
            return search.frontier.Length > 0 ? GraphResult.Running : GraphResult.Failed;
        }

        internal void Collect(List<int> steps, List<int> methods)
        {
            for (int i = winner; i >= 0; i = links[i].Next)
            {
                int task = links[i].Task;
                if (task < 0) methods.Add(~task); else steps.Add(task);
            }
            methods.Reverse();
            steps.Reverse();
        }
        public void Dispose()
        {
            if (!links.IsCreated) return;
            links.Dispose();
            frontier.Dispose();
        }
    }
}
