using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

namespace KaijuSolutions.Agents.Samples
{
    /// <summary>Builds the selected demonstration when its scene starts.</summary>
    public sealed class FloorsAndFlight : MonoBehaviour
    {
        public bool drone;
        [Tooltip("World-space patrol destinations, visited in array order.")]
        public Vector3[] waypoints;
        private KaijuAgent agent;
        private NavMeshData mesh;
        private NavMeshDataInstance surface;
        private NavMeshLinkInstance link;
        private int next;

        private void Start()
        {
            var cameraObject = new GameObject("Camera", typeof(Camera));
            SceneManager.MoveGameObjectToScene(cameraObject, gameObject.scene);
            cameraObject.transform.SetPositionAndRotation(new Vector3(13, 10, -19),
                Quaternion.LookRotation(new Vector3(-13, -8, 19)));
            var light = new GameObject("Sun", typeof(Light)).GetComponent<Light>();
            SceneManager.MoveGameObjectToScene(light.gameObject, gameObject.scene);
            light.type = LightType.Directional;
            light.transform.rotation = Quaternion.Euler(45, -30, 0);
            if (drone)
            {
                Shape("Ground", PrimitiveType.Cube, new Vector3(0, -0.5f, 0), new Vector3(14, 1, 10));
                var craft = Shape("Drone", PrimitiveType.Sphere, Vector3.up, new Vector3(1, 0.4f, 1));
                agent = craft.AddComponent<KaijuTransformAgent>();
                craft.AddComponent<KaijuFreeFlight>();
            }
            else
            {
                // Two overlapping walkable floors connected only by the ramp at their side.
                var sources = new List<NavMeshBuildSource>();
                Deck(sources, "Lower floor", new Vector3(0, -0.25f, 0), new Vector3(12, 0.5f, 6));
                Deck(sources, "Upper floor", new Vector3(0, 3.75f, 0), new Vector3(12, 0.5f, 6));
                var settings = NavMesh.GetSettingsByIndex(0);
                mesh = NavMeshBuilder.BuildNavMeshData(settings, sources, new Bounds(new Vector3(0, 2, 0), Vector3.one * 30), Vector3.zero, Quaternion.identity);
                surface = NavMesh.AddNavMeshData(mesh);
                Vector3 entry = new Vector3(4, 0.1f, -1.5f), exit = new Vector3(4, 4.1f, 1.5f);
                link = NavMesh.AddLink(new NavMeshLinkData { startPosition = entry, endPosition = exit, width = 0.8f,
                    bidirectional = true, agentTypeID = settings.agentTypeID, costModifier = -1 });
                var ramp = Shape("Linked ramp", PrimitiveType.Cube, (entry + exit) * 0.5f, new Vector3(1, 0.15f, 5));
                ramp.transform.rotation = Quaternion.LookRotation(exit - entry);
                var guard = Shape("Guard", PrimitiveType.Capsule, new Vector3(-3, 0.1f, 0), Vector3.one);
                agent = guard.AddComponent<KaijuNavigationAgent>();
            }
            agent.MoveSpeed = 3;
            foreach (Vector3 point in waypoints) Shape("Destination", PrimitiveType.Sphere, point, Vector3.one * 0.25f);
            Go();
        }

        private void Go()
        {
            if (waypoints.Length == 0) return;
            Vector3 goal = waypoints[next];
            next = (next + 1) % waypoints.Length;
            if (drone) agent.Seek(goal, distance: 0.2f);
            else agent.PathFollow(goal, distance: 0.25f);
        }

        private void Update()
        {
            if (agent && !agent.Moving) Go();
        }

        private GameObject Shape(string label, PrimitiveType type, Vector3 position, Vector3 size)
        {
            var shape = GameObject.CreatePrimitive(type);
            SceneManager.MoveGameObjectToScene(shape, gameObject.scene);
            shape.name = label;
            shape.transform.position = position;
            shape.transform.localScale = size;
            Color color = label switch
            {
                "Guard" or "Drone" => new Color(0.08f, 0.65f, 0.55f),
                "Destination" => new Color(1f, 0.63f, 0.09f),
                "Linked ramp" => new Color(0.16f, 0.46f, 0.82f),
                _ => new Color(0.58f, 0.6f, 0.64f)
            };
            var properties = new MaterialPropertyBlock();
            properties.SetColor("_Color", color);
            properties.SetColor("_BaseColor", color);
            shape.GetComponent<Renderer>().SetPropertyBlock(properties);
            return shape;
        }

        private void Deck(List<NavMeshBuildSource> sources, string label, Vector3 position, Vector3 size)
        {
            Shape(label, PrimitiveType.Cube, position, size);
            sources.Add(new NavMeshBuildSource { shape = NavMeshBuildSourceShape.Box, size = size, transform = Matrix4x4.Translate(position) });
        }

        private void OnDrawGizmosSelected()
        {
            if (waypoints == null) return;
            Gizmos.color = new Color(1f, 0.63f, 0.09f);
            foreach (Vector3 point in waypoints) Gizmos.DrawWireSphere(point, 0.2f);
        }

        private void OnDestroy()
        {
            if (NavMesh.IsLinkValid(link)) NavMesh.RemoveLink(link);
            if (surface.valid) surface.Remove();
            if (mesh) Destroy(mesh);
        }
    }
}
