using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.TestTools;

namespace KaijuSolutions.Agents.Tests
{
    public class SpatialMovementTests
    {
#if COM_UNITY_ML_AGENTS
        [Test]
        public void LearningComponentsAppendClimbAndRespectActionOffsets()
        {
            var drone = new GameObject("Learning drone");
            try
            {
                var agent = drone.AddComponent<KaijuTransformAgent>();
                drone.AddComponent<KaijuFreeFlight>();
                var actuator = drone.AddComponent<Learning.KaijuLearningControlActuator>();
                var sensor = drone.AddComponent<Learning.KaijuLearningVelocitySensor>();
                Assert.That(actuator.ActionSpec.NumContinuousActions, Is.EqualTo(2));
                Assert.That(sensor.GetObservationSpec().Shape[0], Is.EqualTo(2));
                JsonUtility.FromJsonOverwrite("{\"includeClimb\":true}", actuator);
                JsonUtility.FromJsonOverwrite("{\"includeClimb\":true}", sensor);
                Assert.That(actuator.ActionSpec.NumContinuousActions, Is.EqualTo(3));
                Assert.That(sensor.GetObservationSpec().Shape[0], Is.EqualTo(3));
                float[] data = { 9, 0, 0, 1, 8 };
                var segment = new Unity.MLAgents.Actuators.ActionSegment<float>(data, 1, 3);
                var buffers = new Unity.MLAgents.Actuators.ActionBuffers(segment, Unity.MLAgents.Actuators.ActionSegment<int>.Empty);
                actuator.OnActionReceived(buffers);
                Assert.That(agent.Control3, Is.EqualTo(Vector3.up));
                actuator.Heuristic(buffers);
                Assert.That(data, Is.EqualTo(new float[] { 9, 0, 0, 0, 8 }));
            }
            finally { Object.DestroyImmediate(drone); }
        }
#endif
#if UNITY_EDITOR
        [UnityTest]
        public IEnumerator ImportedSamplesReachTheirFirstDestination()
        {
            foreach (string sceneName in new[] { "Two Storeys", "Open Air Patrol" })
            {
                var package = UnityEditor.PackageManager.PackageInfo.FindForAssembly(typeof(KaijuAgent).Assembly);
                string path = $"Assets/Samples/{package.displayName}/{package.version}/Floors and Flight/{sceneName}.unity";
                if (System.Environment.GetEnvironmentVariable("KAIJU_REQUIRE_SAMPLES") == "1")
                    Assert.That(System.IO.File.Exists(path), Is.True, path);
                if (!System.IO.File.Exists(path)) Assert.Ignore("Floors and Flight sample is optional in consumer projects.");
                var options = new UnityEngine.SceneManagement.LoadSceneParameters(UnityEngine.SceneManagement.LoadSceneMode.Additive);
                yield return UnityEditor.SceneManagement.EditorSceneManager.LoadSceneAsyncInPlayMode(path, options);
                yield return null;
                var scene = UnityEngine.SceneManagement.SceneManager.GetSceneByPath(path);
                Assert.That(scene.isLoaded, Is.True);
                KaijuAgent agent = null;
                foreach (var root in scene.GetRootGameObjects())
                    if (root.TryGetComponent(out KaijuAgent found)) agent = found;
                Vector3 destination = sceneName == "Two Storeys" ? new Vector3(-3, 4.08f, 0) : Vector3.up * 4;
                Vector3 Location() => agent is KaijuNavigationAgent guard ? guard.SurfacePosition : agent.Position3;
                float until = Time.realtimeSinceStartup + 18;
                while (agent && Time.realtimeSinceStartup < until && Vector3.Distance(Location(), destination) > 0.35f)
                    yield return null;
                float distance = agent ? Vector3.Distance(Location(), destination) : float.PositiveInfinity;
                string result = agent ? $"{sceneName} last surface/flight position {Location()}, pivot {agent.Position3}" : $"{sceneName} missing agent";
                yield return UnityEngine.SceneManagement.SceneManager.UnloadSceneAsync(scene);
                Assert.That(distance, Is.LessThanOrEqualTo(0.35f), result);
            }
        }
#endif

        [UnityTest]
        public IEnumerator DroneSeeksOverheadAndResetsWhenPooled()
        {
            var go = new GameObject("Drone");
            try
            {
                var agent = go.AddComponent<KaijuTransformAgent>();
                var flight = go.AddComponent<KaijuFreeFlight>();
                agent.MoveSpeed = 5;
                agent.MoveAcceleration = 0;
                agent.Seek(Vector3.up * 2, distance: 0.2f);
                float until = Time.realtimeSinceStartup + 5;
                while (agent.Moving && Time.realtimeSinceStartup < until) yield return null;
                Assert.That(agent.Moving, Is.False);
                Assert.That(go.transform.position.y, Is.EqualTo(2).Within(0.25));
                Assert.That(Vector3.Dot(go.transform.forward, Vector3.up), Is.EqualTo(0).Within(0.01));
                agent.Control3 = Vector3.one;
                yield return new WaitForFixedUpdate();
                yield return new WaitForFixedUpdate();
                Assert.That(agent.Velocity3.magnitude, Is.EqualTo(5).Within(0.01));
                agent.Control = Vector2.right;
                agent.CalculateVelocity(0.02f);
                Assert.That(agent.Velocity3.y, Is.Zero);
                go.SetActive(false);
                go.SetActive(true);
                yield return new WaitForFixedUpdate();
                Assert.That(agent.Control3, Is.EqualTo(Vector3.zero));
                Assert.That(agent.Velocity3, Is.EqualTo(Vector3.zero));
                Assert.That(agent.FreeFlight, Is.EqualTo(flight));
            }
            finally { Object.DestroyImmediate(go); }
        }

        [UnityTest]
        public IEnumerator CachedDroneCannotBeReusedAsAGroundAgent()
        {
            var types = new[] { typeof(KaijuFreeFlight).FullName };
            var drone = KaijuAgents.Spawn(cached: false, components: types);
            KaijuAgent ground = null;
            try
            {
                yield return new WaitForFixedUpdate();
                drone.Control3 = Vector3.up;
                drone.Despawn();
                yield return new WaitForSeconds(0.08f);
                ground = KaijuAgents.Spawn();
                Assert.That(ground.FreeFlight, Is.Null);
                Assert.That(KaijuAgents.Spawn(components: types), Is.SameAs(drone));
                yield return new WaitForFixedUpdate();
                Assert.That(drone.Control3, Is.EqualTo(Vector3.zero));
                Assert.That(drone.Velocity3, Is.EqualTo(Vector3.zero));
            }
            finally
            {
                if (ground) Object.DestroyImmediate(ground.gameObject);
                if (drone) Object.DestroyImmediate(drone.gameObject);
            }
        }

        [Test]
        public void SpatialVisionRejectsTargetsAboveItsRangeAndPlanarCommandsHoldAltitude()
        {
            var go = new GameObject("Observer");
            var target = new GameObject("Target");
            try
            {
                go.transform.position = Vector3.up * 4;
                target.transform.position = Vector3.up * 10;
                var observer = go.AddComponent<KaijuTransformAgent>();
                go.AddComponent<KaijuFreeFlight>();
                var sensor = go.AddComponent<Sensors.KaijuAgentsVisionSensor>();
                sensor.observables = new[] { target.AddComponent<KaijuTransformAgent>() };
                sensor.Angle = 360;
                sensor.Distance = 2;
                sensor.lineOfSight = false;
                sensor.Sense();
                Assert.That(sensor.ObservedCount, Is.EqualTo(1));
                sensor.spatialVision = true;
                sensor.Sense();
                Assert.That(sensor.ObservedCount, Is.Zero);
                observer.Seek(Vector2.right, distance: 0.1f);
                observer.CalculateVelocity(0.02f);
                Assert.That(observer.Velocity3.y, Is.Zero);
                Assert.That(observer.Velocity3.x, Is.GreaterThan(0));
            }
            finally { Object.DestroyImmediate(go); Object.DestroyImmediate(target); }
        }

        [UnityTest]
        public IEnumerator FlightAndGroundCanSenseTheSameTargetDifferently()
        {
            var entities = World.DefaultGameObjectInjectionWorld.EntityManager;
            var flyer = entities.CreateEntity(typeof(LocalTransform), typeof(KaijuFlightSteering), typeof(KaijuFlightInput),
                typeof(KaijuSphericalRangeSensor), typeof(KaijuRangeSensor));
            var target = entities.CreateEntity(typeof(LocalTransform));
            try
            {
                entities.SetComponentData(target, LocalTransform.FromPosition(new float3(0, 6, 0)));
                entities.SetComponentData(flyer, LocalTransform.Identity);
                entities.SetComponentData(flyer, new KaijuFlightSteering { MaxSpeed = 2 });
                entities.GetBuffer<KaijuFlightInput>(flyer).Add(new KaijuFlightInput { Target = target, Mode = KaijuSteeringMode.Seek, Weight = 1 });
                entities.SetComponentData(flyer, new KaijuRangeSensor { Target = target, Radius = 1 });
                entities.SetComponentData(flyer, new KaijuSphericalRangeSensor { Target = target, Radius = 1 });
                yield return new WaitForSeconds(0.12f);
                Assert.That(entities.GetComponentData<LocalTransform>(flyer).Position.y, Is.GreaterThan(0));
                Assert.That(entities.GetComponentData<KaijuRangeSensor>(flyer).Detected, Is.True);
                Assert.That(entities.GetComponentData<KaijuSphericalRangeSensor>(flyer).Detected, Is.False);
            }
            finally { entities.DestroyEntity(flyer); entities.DestroyEntity(target); }
        }

        [Test]
        public void RigidbodyFlightRestoresGroundSettingsAndChecksClearance()
        {
            var go = new GameObject("Body");
            var wall = GameObject.CreatePrimitive(PrimitiveType.Cube);
            try
            {
                var agent = go.AddComponent<KaijuRigidbodyAgent>();
                agent.Body.useGravity = true;
                agent.Body.constraints |= RigidbodyConstraints.FreezePositionY;
                var flight = go.AddComponent<KaijuFreeFlight>();
                Assert.That(agent.Body.useGravity, Is.False);
                Assert.That(agent.Body.constraints.HasFlag(RigidbodyConstraints.FreezePositionY), Is.False);
                wall.layer = 9;
                wall.transform.position = Vector3.up * 3;
                Physics.SyncTransforms();
                Assert.That(flight.HasClearance(Vector3.up * 5, 0.2f, 1 << 9), Is.False);
                Assert.That(flight.HasClearance(Vector3.right * 5, 0.2f, 1 << 9), Is.True);
                flight.enabled = false;
                Assert.That(agent.Body.useGravity, Is.True);
                Assert.That(agent.Body.constraints.HasFlag(RigidbodyConstraints.FreezePositionY), Is.True);
                agent.Body.constraints &= ~RigidbodyConstraints.FreezePositionY;
                agent.Body.linearVelocity = Vector3.up * 3;
                agent.Move(0.02f);
                Assert.That(agent.Body.linearVelocity.y, Is.EqualTo(3).Within(0.01f));
            }
            finally { Object.DestroyImmediate(go); Object.DestroyImmediate(wall); }
        }

        [UnityTest]
        public IEnumerator PoolRetainsPrefabIdentity()
        {
            var a = new GameObject("A").AddComponent<KaijuTransformAgent>();
            var b = new GameObject("B").AddComponent<KaijuTransformAgent>();
            a.MoveSpeed = 2;
            b.MoveSpeed = 9;
            var first = KaijuAgents.Spawn(prefab: a);
            KaijuAgent second = null;
            try
            {
                yield return new WaitForFixedUpdate();
                first.Despawn();
                yield return new WaitForSeconds(0.08f);
                second = KaijuAgents.Spawn(prefab: b);
                Assert.That(second, Is.Not.SameAs(first));
                Assert.That(second.MoveSpeed, Is.EqualTo(9));
                Assert.That(KaijuAgents.Spawn(prefab: a), Is.SameAs(first));
            }
            finally
            {
                if (second) Object.DestroyImmediate(second.gameObject);
                Object.DestroyImmediate(first.gameObject);
                Object.DestroyImmediate(a.gameObject);
                Object.DestroyImmediate(b.gameObject);
            }
        }

        [UnityTest]
        public IEnumerator VisionSkipsOwnerAndDestroyedTargets()
        {
            var self = new GameObject("Observer").AddComponent<KaijuTransformAgent>();
            var other = new GameObject("Neighbour").AddComponent<KaijuTransformAgent>();
            var gone = new GameObject("Gone").AddComponent<KaijuTransformAgent>();
            try
            {
                self.transform.position = other.transform.position = Vector3.right * 300;
                var sensor = self.gameObject.AddComponent<Sensors.KaijuAgentsVisionSensor>();
                sensor.spatialVision = true;
                sensor.lineOfSight = false;
                sensor.Distance = 1;
                sensor.observables = new[] { self, gone, other };
                Object.DestroyImmediate(gone.gameObject);
                sensor.Sense();
                Assert.That(sensor.ObservedCount, Is.EqualTo(1));
                Assert.That(sensor.TryGetNearest(out var nearest), Is.True);
                Assert.That(nearest, Is.SameAs(other));
                var sorted = new KaijuAgent[2];
                Assert.That(sensor.SortDistance3(sorted), Is.EqualTo(1));
                Assert.That(sorted[0], Is.SameAs(other));
                var positions = new Vector3[2];
                Assert.That(sensor.SortAnglePosition3(positions), Is.EqualTo(1));
                Assert.That(positions[0], Is.EqualTo(other.Position3));
                sensor.observables = null;
                yield return new WaitForSeconds(0.08f);
                Assert.That(sensor.ObservedCount, Is.EqualTo(1));
                Object.DestroyImmediate(other.gameObject);
                yield return new WaitForSeconds(0.08f);
                Assert.That(sensor.ObservedCount, Is.Zero);
            }
            finally
            {
                Object.DestroyImmediate(self.gameObject);
                if (gone) Object.DestroyImmediate(gone.gameObject);
                if (other) Object.DestroyImmediate(other.gameObject);
            }
        }

        [UnityTest]
        public IEnumerator GuardReachesUpperFloorOnlyThroughConnectedRoute()
        {
            var start = new Vector3(250, 0, 250);
            var settings = NavMesh.GetSettingsByIndex(0);
            var sources = new List<NavMeshBuildSource>();
            foreach (var floor in new[] { start, start + Vector3.up * 4, start + Vector3.right * 12 })
                sources.Add(new NavMeshBuildSource { shape = NavMeshBuildSourceShape.Box, size = new Vector3(8, 1, 8),
                    transform = Matrix4x4.Translate(floor - Vector3.up * 0.5f) });
            var data = NavMeshBuilder.BuildNavMeshData(settings, sources, new Bounds(start, Vector3.one * 40), Vector3.zero, Quaternion.identity);
            var surface = NavMesh.AddNavMeshData(data);
            var link = NavMesh.AddLink(new NavMeshLinkData { startPosition = start + Vector3.right * 2,
                endPosition = start + new Vector3(2, 4, 1), bidirectional = true, width = 1, agentTypeID = settings.agentTypeID, costModifier = -1 });
            var go = new GameObject("Guard");
            try
            {
                go.transform.position = start;
                Assert.That(NavMesh.SamplePosition(start, out var footing, 0.3f, NavMesh.AllAreas), Is.True, "Lower floor must have standing clearance");
                go.transform.position = footing.position;
                var agent = go.AddComponent<KaijuNavigationAgent>();
                agent.MoveSpeed = 10;
                var filter = new NavMeshQueryFilter { agentTypeID = settings.agentTypeID, areaMask = NavMesh.AllAreas };
                Vector3[] corners = null;
                var nativePath = new NavMeshPath();
                Assert.That(Extensions.KaijuAgentsFindPath.TryFindSurfacePath(start, start + Vector3.up * 4, filter,
                    0.5f, nativePath, ref corners, out int count, out var status, out _), Is.True);
                Assert.That(status, Is.EqualTo(Extensions.KaijuSurfacePathStatus.Complete));
                Assert.That(count, Is.GreaterThan(1));
                Assert.That(Extensions.KaijuAgentsFindPath.TryFindSurfacePath(start, start + Vector3.up * 20, filter,
                    0.5f, nativePath, ref corners, out count, out status, out _), Is.False);
                Assert.That(status, Is.EqualTo(Extensions.KaijuSurfacePathStatus.UnmappedGoal));
                Assert.That(count, Is.Zero);
                var balcony = agent.PathFollow(start + Vector3.right * 12, distance: 0.2f);
                Assert.That(balcony.HasCompleteSurfaceRoute, Is.False);
                Assert.That(balcony.Done(), Is.False);
                yield return new WaitForSeconds(0.12f);
                Assert.That(Vector3.Distance(agent.Position3, start), Is.LessThan(0.3f));
                var upper = agent.PathFollow(start + Vector3.up * 4, distance: 0.2f);
                Assert.That(upper.HasCompleteSurfaceRoute, Is.True);
                Assert.That(upper.Done(), Is.False);
                float until = Time.realtimeSinceStartup + 8;
                while (agent.Moving && Time.realtimeSinceStartup < until) yield return null;
                Assert.That(agent.Moving, Is.False);
                Assert.That(Vector3.Distance(agent.Position3, start + Vector3.up * 4), Is.LessThan(0.3f));
            }
            finally
            {
                Object.DestroyImmediate(go);
                NavMesh.RemoveLink(link);
                surface.Remove();
                Object.DestroyImmediate(data);
            }
        }
    }
}
