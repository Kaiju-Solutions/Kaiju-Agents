using System;
using System.Collections.Generic;
using KaijuSolutions.Agents.Extensions;
using NUnit.Framework;
using Unity.AI.Navigation.LowLevel;
using UnityEngine;
using UnityEngine.AI;

namespace KaijuSolutions.Agents.Tests
{
    public class NavigationPathTests
    {
        [Test]
        public void RoutesOnFilteredSurfaceAndPreservesOffMeshEndpoints()
        {
            // A separate agent type makes accidental use of the default mesh observable.
            var settings = NavMesh.CreateSettings();
            NavMeshData data = null;
            NavMeshDataInstance instance = default;
            try
            {
                var sources = new List<NavMeshBuildSource>
                {
                    Floor(new Vector3(0, -0.5f, 0), new Vector3(14, 1, 4)),
                    Floor(new Vector3(5, -0.5f, 5), new Vector3(4, 1, 12))
                };
                data = NavMeshBuilder.BuildNavMeshData(settings, sources,
                    new Bounds(Vector3.zero, Vector3.one * 40), Vector3.zero, Quaternion.identity);
                Assert.That(data, Is.Not.Null);
                instance = NavMesh.AddNavMeshData(data);
                var filter = new NavMeshQueryFilter { agentTypeID = settings.agentTypeID, areaMask = 1 };
                using var world = NavWorld.GetDefaultWorld();
                var start = world.MapLocation(new Vector3(-4, 0, 0.3f), Vector3.one, filter.agentTypeID, 1);
                var nearby = world.MapLocation(start.position + Vector3.right * 0.01f, Vector3.one, filter.agentTypeID, 1);
                Assert.That(start.node.IsNull(), Is.False);
                Assert.That(nearby.node, Is.EqualTo(start.node));

                Vector3[] corners = Array.Empty<Vector3>();
                Assert.That(start.position.FindPath(nearby.position, ref corners, filter), Is.EqualTo(2));
                Assert.That(corners[0], Is.EqualTo(start.position));
                Assert.That(Vector3.Distance(corners[1], nearby.position), Is.LessThan(0.001f));

                var goal = new Vector3(5, 4, 9);
                var path = new List<Vector3>();
                Assert.That(start.position.FindPath(goal, path, filter), Is.GreaterThan(3));
                Assert.That(path[0], Is.EqualTo(start.position));
                Assert.That(path[path.Count - 1], Is.EqualTo(goal));
                Assert.That(path[path.Count - 2].y, Is.LessThan(1));
                filter.areaMask = 1 << 3;
                Assert.That(start.position.FindPath(goal, path, filter), Is.EqualTo(2));
                Assert.That(path, Is.EqualTo(new[] { start.position, goal }));
            }
            finally
            {
                if (instance.valid) instance.Remove();
                if (data) UnityEngine.Object.DestroyImmediate(data);
                NavMesh.RemoveSettings(settings.agentTypeID);
            }
        }

        private static NavMeshBuildSource Floor(Vector3 center, Vector3 size)
        {
            return new NavMeshBuildSource
            {
                shape = NavMeshBuildSourceShape.Box,
                transform = Matrix4x4.Translate(center),
                size = size,
                area = 0
            };
        }
    }
}
