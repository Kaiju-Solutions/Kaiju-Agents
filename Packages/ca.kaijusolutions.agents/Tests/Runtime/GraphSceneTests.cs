using System.Collections;
using KaijuSolutions.Agents.Graphs;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.TestTools;

namespace KaijuSolutions.Agents.Tests
{
    public sealed class GraphSceneTests
    {
        [UnityTest]
        public IEnumerator RescueSceneStartsFromItsRunnerAndPerformsPickup()
        {
            const string sample = "Rescue Decisions";
            if (!Application.CanStreamedLevelBeLoaded(sample))
            {
                if (System.Environment.GetEnvironmentVariable("KAIJU_REQUIRE_SAMPLES") == "1") Assert.Fail("Missing rescue sample in build settings");
                Assert.Ignore("Import Visual Decisions and enable Rescue Decisions in Build Profiles to run this test");
            }
            yield return SceneManager.LoadSceneAsync(sample, LoadSceneMode.Additive);
            var scene = SceneManager.GetSceneByName(sample);
            KaijuGraphRunner runner = null;
            float deadline = Time.realtimeSinceStartup + 10;
            while (Time.realtimeSinceStartup < deadline)
            {
                foreach (var root in scene.GetRootGameObjects())
                    if (root.TryGetComponent(out KaijuGraphRunner found)) runner = found;
                if (runner && runner.Execution != null && runner.Execution.Result != GraphResult.Running) break;
                yield return null;
            }
            var result = runner?.Execution?.Result;
            bool pickedUp = runner && runner.transform.Find("Survivor");
            yield return SceneManager.UnloadSceneAsync(scene);
            Assert.AreEqual(GraphResult.Succeeded, result);
            Assert.IsTrue(pickedUp);
        }
    }
}
