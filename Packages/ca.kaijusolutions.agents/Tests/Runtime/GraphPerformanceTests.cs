using System;
using System.Diagnostics;
using KaijuSolutions.Agents.Graphs;
using NUnit.Framework;
using Unity.Core;
using Unity.Entities;
using UnityEngine.Profiling;

namespace KaijuSolutions.Agents.Tests
{
    public sealed class GraphPerformanceTests
    {
        [Test]
        public void SharedUtilityGraphSteadyState()
        {
            const int agents = 512, ticks = 128;
            using var world = new World("Graph performance");
            var system = world.GetOrCreateSystemManaged<KaijuGraphSystem>();
            world.SetTime(new TimeData(1, 1f / 60));
            var graph = KaijuGraph.Create(GraphFamily.Utility, 0, null, new[]
            {
                new GraphStep { Op = GraphOp.Utility, Children = new[] { 1, 2 } },
                new GraphStep { Op = GraphOp.Wait, Duration = 3600, BaseScore = 1 },
                new GraphStep { Op = GraphOp.Wait, Duration = 3600, BaseScore = 0.5f }
            });
            try
            {
                var entities = new Entity[agents];
                var services = new GraphServices();
                for (int i = 0; i < agents; i++) entities[i] = world.EntityManager.CreateEntity();
                for (int i = 0; i < 8; i++) system.Update();
                long empty = Stopwatch.GetTimestamp();
                for (int i = 0; i < ticks; i++) system.Update();
                empty = Stopwatch.GetTimestamp() - empty;
                long memory = Profiler.GetTotalAllocatedMemoryLong();
                long retainedBefore = GC.GetTotalMemory(true);
                long startBytes = GC.GetAllocatedBytesForCurrentThread();
                foreach (var entity in entities) system.Start(entity, graph, services);
                for (int i = 0; i < 8; i++) system.Update();
                long instanceBytes = GC.GetAllocatedBytesForCurrentThread() - startBytes;
                long retained = GC.GetTotalMemory(true) - retainedBefore;
                long before = GC.GetAllocatedBytesForCurrentThread();
                long start = Stopwatch.GetTimestamp();
                for (int i = 0; i < ticks; i++) system.Update();
                long elapsed = Stopwatch.GetTimestamp() - start;
                long bytes = GC.GetAllocatedBytesForCurrentThread() - before;
                long memoryDelta = Profiler.GetTotalAllocatedMemoryLong() - memory;
                double scale = 1000000.0 / (ticks * Stopwatch.Frequency);
                UnityEngine.Debug.Log(FormattableString.Invariant($"KAIJU_GRAPH_PERF agents={agents} ticks={ticks} empty_us={empty * scale:F2} step_us={elapsed * scale:F2} retained_managed_per_agent={retained / agents} startup_gc_per_agent={instanceBytes / agents} steady_gc_bytes={bytes} total_memory_delta={memoryDelta}"));
                if (!UnityEngine.Application.isEditor) Assert.AreEqual(0, bytes, "Shared graph allocated during steady state");
            }
            finally { UnityEngine.Object.DestroyImmediate(graph); }
        }
    }
}
