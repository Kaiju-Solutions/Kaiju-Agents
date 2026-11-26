using KaijuSolutions.Agents.Graphs;
using UnityEngine;
using UnityEngine.SceneManagement;
#if COM_UNITY_ML_AGENTS
using KaijuSolutions.Agents.Learning;
using Unity.InferenceEngine;
using Unity.MLAgents;
using Unity.MLAgents.Actuators;
using Unity.MLAgents.Policies;
using Unity.MLAgents.Sensors;
#endif

namespace KaijuSolutions.Agents.Samples
{
    public sealed class RescueDecisions : MonoBehaviour, IGraphServiceProvider
    {
        private GameObject survivor;
        private KaijuGraphRunner runner;

        private void Start()
        {
            var camera = new GameObject("Camera").AddComponent<Camera>();
            SceneManager.MoveGameObjectToScene(camera.gameObject, gameObject.scene);
            camera.transform.SetPositionAndRotation(new Vector3(0, 2, -5), Quaternion.Euler(15, 0, 0));
            var light = new GameObject("Sun").AddComponent<Light>();
            SceneManager.MoveGameObjectToScene(light.gameObject, gameObject.scene);
            light.type = LightType.Directional;
            survivor = GameObject.CreatePrimitive(PrimitiveType.Cube);
            SceneManager.MoveGameObjectToScene(survivor, gameObject.scene);
            survivor.name = "Survivor";
            survivor.transform.position = Vector3.right;
            survivor.transform.localScale = Vector3.one * 0.4f;
            gameObject.SetActive(false);
            gameObject.AddComponent<KaijuTransformAgent>();
            var drone = GameObject.CreatePrimitive(PrimitiveType.Sphere);
            drone.transform.SetParent(transform, false);
            drone.transform.localScale = Vector3.one * 0.5f;
#if COM_UNITY_ML_AGENTS
            var behavior = gameObject.AddComponent<BehaviorParameters>();
            behavior.BehaviorName = "Kaiju rescue";
            behavior.BrainParameters.VectorObservationSize = 1;
            behavior.BrainParameters.ActionSpec = ActionSpec.MakeContinuous(1);
            behavior.InferenceDevice = InferenceDevice.Burst;
            behavior.BehaviorType = BehaviorType.InferenceOnly;
            behavior.Model = Resources.Load<ModelAsset>("KaijuDecisions/IdentityPolicy");
            gameObject.AddComponent<RescueInferenceAgent>();
            gameObject.AddComponent<KaijuGraphPolicy>();
#endif
            runner = gameObject.AddComponent<KaijuGraphRunner>();
            runner.Graph = Resources.Load<KaijuGraph>("KaijuDecisions/Rescue");
            gameObject.SetActive(true);
        }

        public void Register(GraphServices services)
        {
            services.Actions.Add("rescue.pick-up", () => new Pickup(survivor, transform));
#if !COM_UNITY_ML_AGENTS
            services.Policies.Add("policy", () => new Approach(transform));
#endif
        }

        private sealed class Pickup : IGraphAction
        {
            private readonly GameObject survivor;
            private readonly Transform drone;
            public Pickup(GameObject survivor, Transform drone) { this.survivor = survivor; this.drone = drone; }
            public GraphResult Begin(GraphContext context)
            {
                survivor.transform.SetParent(drone, false);
                survivor.transform.localPosition = Vector3.up * 0.4f;
                return GraphResult.Succeeded;
            }
            public GraphResult Tick(GraphContext context, float delta) => GraphResult.Succeeded;
            public void Cancel(GraphContext context) { }
        }

#if !COM_UNITY_ML_AGENTS
        private sealed class Approach : IGraphAction
        {
            private readonly Transform drone;
            internal Approach(Transform drone) => this.drone = drone;
            public GraphResult Begin(GraphContext context) => GraphResult.Running;
            public GraphResult Tick(GraphContext context, float delta)
            {
                drone.position = Vector3.MoveTowards(drone.position, Vector3.right, delta * 8);
                return GraphResult.Running;
            }
            public void Cancel(GraphContext context) { }
        }
#endif
    }

#if COM_UNITY_ML_AGENTS
    public sealed class RescueInferenceAgent : Agent
    {
        public override void CollectObservations(VectorSensor sensor) => sensor.AddObservation(Mathf.Clamp01(1 - transform.position.x));
        public override void OnActionReceived(ActionBuffers actions)
        {
            if (GetComponent<KaijuGraphPolicy>().AcceptActions)
                transform.position += Vector3.right * (actions.ContinuousActions[0] * 8 * Time.fixedDeltaTime);
        }
    }
#endif
}
