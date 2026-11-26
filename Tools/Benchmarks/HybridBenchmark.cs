using System;
using System.Collections.Generic;
using System.Diagnostics;
using KaijuSolutions.Agents.Sensors;
using KaijuSolutions.Agents.Graphs;
using NUnit.Framework;
using Unity.Collections;
using Unity.Core;
using Unity.Entities;
using Unity.Transforms;
using UnityEngine;
using UnityEngine.Profiling;
using Object = UnityEngine.Object;

namespace KaijuSolutions.Agents.Tests
{
    public class HybridBenchmark
    {
        [Test]
        public void MeasureBridges()
        {
            foreach (int percent in new[] { 0, 10, 100 })
                foreach (bool vision in new[] { false, true })
                    foreach (bool brains in new[] { false, true })
                    {
                        Measure(percent, vision, brains, true);
                        if (vision && percent > 0) Measure(percent, true, brains, false);
                    }
        }

        private static void Measure(int percent, bool vision, bool brains, bool nearby)
        {
            const int total = 200;
            const int steps = 32;
            var original = World.DefaultGameObjectInjectionWorld;
            using var world = new World("Hybrid benchmark");
            World.DefaultGameObjectInjectionWorld = world;
            var objects = new List<GameObject>();
            var sensors = new List<KaijuAgentsVisionSensor>();
            var graph = KaijuGraph.Create(GraphFamily.Utility, 0, null, new[] {
                new GraphStep { Op = GraphOp.Utility, Children = new[] { 1 } },
                new GraphStep { Op = GraphOp.Wait, Duration = 3600 } });
            try
            {
                world.SetTime(new TimeData(1, 1f / 60));
                var manager = world.EntityManager;
                var fixedSystem = world.GetOrCreateSystemManaged<KaijuFixedSimulationSystem>();
                var decisions = world.GetOrCreateSystemManaged<KaijuGraphSystem>();
                var frame = world.GetOrCreateSystemManaged<KaijuFrameSimulationSystem>();
                int bridged = total * percent / 100;
                var archetype = manager.CreateArchetype(typeof(KaijuSteering), typeof(LocalTransform));
                using var entities = manager.CreateEntity(archetype, total - bridged, Allocator.Temp);
                for (int i = 0; i < bridged; i++)
                {
                    var go = new GameObject();
                    objects.Add(go);
                    go.transform.position = new Vector3(i % 20 * 2, 0, i / 20 * 2);
                    go.AddComponent<KaijuTransformAgent>();
                    if (vision)
                    {
                        var sensor = go.AddComponent<KaijuAgentsVisionSensor>();
                        sensor.Distance = 3;
                        sensor.Angle = 360;
                        sensor.lineOfSight = true;
                        sensor.useNearbyQuery = nearby;
                        sensors.Add(sensor);
                    }
                }
                fixedSystem.Update();
                if (brains)
                    foreach (var go in objects) decisions.Start(go.GetComponent<KaijuAgent>().SimulationEntity, graph);
                void Tick()
                {
                    fixedSystem.Update();
                    decisions.Update();
                    frame.Update();
                    long sync = Stopwatch.GetTimestamp();
                    manager.CompleteAllTrackedJobs();
                    BenchmarkSync.Ticks += Stopwatch.GetTimestamp() - sync;
                }
                for (int i = 0; i < 8; i++) Tick();
                BenchmarkSync.Ticks = 0;
                BenchmarkSync.Bytes = 0;
                long nativeBefore = Profiler.GetTotalAllocatedMemoryLong();
                long alloc = GC.GetAllocatedBytesForCurrentThread();
                long start = Stopwatch.GetTimestamp();
                long candidates = 0, casts = 0;
                for (int i = 0; i < steps; i++)
                {
                    Tick();
                    foreach (var sensor in sensors) { candidates += nearby ? sensor.NearbyCandidatesExamined : sensor.CandidatesExamined; casts += sensor.SightQueries; }
                }
                long elapsed = Stopwatch.GetTimestamp() - start;
                long allocated = GC.GetAllocatedBytesForCurrentThread() - alloc;
                long nativeDelta = Profiler.GetTotalAllocatedMemoryLong() - nativeBefore;
                if (!Application.isEditor)
                    Assert.That(allocated, Is.Zero, $"Hybrid steady-state allocation: {percent}% bridges, vision={vision}, brains={brains}, nearby={nearby}");
                double scale = 1000000.0 / (steps * Stopwatch.Frequency);
                UnityEngine.Debug.Log(FormattableString.Invariant($"KAIJU_HYBRID bridge={percent} vision={vision} brains={brains} nearby={nearby} agents={total} step_us={elapsed*scale:F2} wait_us={BenchmarkSync.Ticks*scale:F2} gc_bytes={allocated/steps} bridge_temp_bytes={BenchmarkSync.Bytes/steps} native_net_bytes={nativeDelta} candidates={candidates/steps} casts={casts/steps}"));
            }
            finally
            {
                foreach (var go in objects) Object.DestroyImmediate(go);
                Object.DestroyImmediate(graph);
                World.DefaultGameObjectInjectionWorld = original;
            }
        }
    }
}
