using System;
using System.Diagnostics;
using NUnit.Framework;
using System.Collections.Generic;
using KaijuSolutions.Agents.Extensions;
using UnityEngine;
using UnityEngine.AI;
using Unity.Collections;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;
using Unity.Core;

namespace KaijuSolutions.Agents.Tests
{
    public class SteeringBenchmark
    {
        [Test]
        public void MeasureFixedStep()
        {
            Measure(0);
#if KAIJU_FLIGHT
            Measure(50);
            Measure(100);
#endif
        }

        [Test]
        public void MeasureQueriesSeparately()
        {
            var floor = new NavMeshBuildSource { shape = NavMeshBuildSourceShape.Box,
                size = new Vector3(12, 1, 8), transform = Matrix4x4.Translate(Vector3.down * 0.5f) };
            var data = NavMeshBuilder.BuildNavMeshData(NavMesh.GetSettingsByIndex(0), new List<NavMeshBuildSource> { floor },
                new Bounds(Vector3.zero, Vector3.one * 20), Vector3.zero, Quaternion.identity);
            var surface = NavMesh.AddNavMeshData(data);
            var wall = GameObject.CreatePrimitive(PrimitiveType.Cube);
            try
            {
                wall.layer = 9;
                wall.transform.position = Vector3.up * 4;
                Physics.SyncTransforms();
                Vector3[] corners = new Vector3[16];
                Vector3 a = new Vector3(-2, 0.08f, 1), b = new Vector3(2, 0.08f, -1);
                for (int i = 0; i < 64; i++) a.FindPath(b, ref corners);
                const int queries = 4096;
                var clock = Stopwatch.StartNew();
                for (int i = 0; i < queries; i++) a.FindPath(b, ref corners);
                double path = clock.Elapsed.TotalMilliseconds * 1000 / queries;
                int blocked = 0;
                clock.Restart();
                for (int i = 0; i < queries; i++)
                    if (Physics.SphereCast(Vector3.zero, 0.25f, Vector3.up, out _, 8, 1 << 9, QueryTriggerInteraction.Ignore)) blocked++;
                double cast = clock.Elapsed.TotalMilliseconds * 1000 / queries;
                Assert.That(blocked, Is.EqualTo(queries));
                UnityEngine.Debug.Log(FormattableString.Invariant($"KAIJU_QUERY path_us={path:F2} spherecast_us={cast:F2} queries={queries}"));
            }
            finally
            {
                UnityEngine.Object.DestroyImmediate(wall);
                surface.Remove();
                UnityEngine.Object.DestroyImmediate(data);
            }
        }

        private static void Measure(int flightPercent)
        {
            const int count = 8192;
            const int frames = 1024;
            using var world = new World("Steering benchmark");
            world.SetTime(new TimeData(1, 1f / 60));
            var manager = world.EntityManager;
            var ground = manager.CreateArchetype(typeof(LocalTransform), typeof(KaijuSteering));
            int flyers = count * flightPercent / 100;
            using var walkers = manager.CreateEntity(ground, count - flyers, Allocator.Temp);
            foreach (var entity in walkers)
                manager.SetComponentData(entity, new KaijuSteering { DesiredVelocity = new float2(3, 4), MaxSpeed = 4 });
            var query = manager.CreateEntityQuery(typeof(KaijuSteering));
            int chunks = query.CalculateChunkCount();
            long steeringBytes = (count - flyers) * Unity.Collections.LowLevel.Unsafe.UnsafeUtility.SizeOf<KaijuSteering>();
#if KAIJU_FLIGHT
            var air = manager.CreateArchetype(typeof(LocalTransform), typeof(KaijuFlightSteering));
            using var flying = manager.CreateEntity(air, flyers, Allocator.Temp);
            foreach (var entity in flying)
                manager.SetComponentData(entity, new KaijuFlightSteering { DesiredVelocity = new float3(2, 3, 4), MaxSpeed = 4 });
            chunks += manager.CreateEntityQuery(typeof(KaijuFlightSteering)).CalculateChunkCount();
            steeringBytes += flyers * Unity.Collections.LowLevel.Unsafe.UnsafeUtility.SizeOf<KaijuFlightSteering>();
#endif
            var system = world.GetOrCreateSystemManaged<KaijuFixedSimulationSystem>();
            for (int i = 0; i < 16; i++) { system.Update(); manager.CompleteAllTrackedJobs(); }
            using var process = Process.GetCurrentProcess();
            for (int round = 0; round < 5; round++)
            {
                long wait = 0;
                var cpuStart = process.TotalProcessorTime;
                long allocations = GC.GetAllocatedBytesForCurrentThread();
                long start = Stopwatch.GetTimestamp();
                for (int i = 0; i < frames; i++)
                {
                    system.Update();
                    long sync = Stopwatch.GetTimestamp();
                    manager.CompleteAllTrackedJobs();
                    wait += Stopwatch.GetTimestamp() - sync;
                }
                long elapsed = Stopwatch.GetTimestamp() - start;
                long allocated = GC.GetAllocatedBytesForCurrentThread() - allocations;
                if (!Application.isEditor) Assert.That(allocated, Is.Zero, "Managed allocation during warmed ECS steering");
                double cpu = (process.TotalProcessorTime - cpuStart).TotalMilliseconds * 1000 / frames;
                double scale = 1000000.0 / (Stopwatch.Frequency * frames);
                UnityEngine.Debug.Log(FormattableString.Invariant($"KAIJU_PERF flight={flightPercent} round={round} step_us={elapsed*scale:F2} wait_us={wait*scale:F2} cpu_us={cpu:F2} gc_bytes={allocated} chunks={chunks} agents={count} steering_bytes={steeringBytes}"));
            }
        }
    }
}
