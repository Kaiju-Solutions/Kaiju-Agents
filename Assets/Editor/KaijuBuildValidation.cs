using System;
using System.Linq;
using UnityEditor;
using UnityEditor.Build;
using UnityEditor.Build.Reporting;

namespace KaijuSolutions.Agents.Validation
{
    public static class KaijuBuildValidation
    {
        public static void BuildPlayer()
        {
            string destination = Environment.GetEnvironmentVariable("KAIJU_BUILD_PATH");
            var scenes = EditorBuildSettings.scenes.Where(scene => scene.enabled).Select(scene => scene.path).ToArray();
            if (string.IsNullOrEmpty(destination) || scenes.Length == 0)
                throw new BuildFailedException("Set KAIJU_BUILD_PATH and enable at least one sample scene.");
            var report = BuildPipeline.BuildPlayer(scenes, destination, EditorUserBuildSettings.activeBuildTarget, BuildOptions.None);
            if (report.summary.result != BuildResult.Succeeded)
                throw new BuildFailedException($"Sample player build finished with {report.summary.result}");
        }
    }
}
