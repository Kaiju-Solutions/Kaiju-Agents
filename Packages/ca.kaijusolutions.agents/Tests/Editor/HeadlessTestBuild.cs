using System;
using UnityEditor;
using UnityEditor.TestTools;
using UnityEngine.TestTools;

[assembly: TestPlayerBuildModifier(typeof(KaijuSolutions.Agents.Tests.HeadlessTestBuild))]
[assembly: PostBuildCleanup(typeof(KaijuSolutions.Agents.Tests.HeadlessTestBuild))]

namespace KaijuSolutions.Agents.Tests
{
    public sealed class HeadlessTestBuild : ITestPlayerBuildModifier, IPostBuildCleanup
    {
        public BuildPlayerOptions ModifyOptions(BuildPlayerOptions options)
        {
            string path = Environment.GetEnvironmentVariable("KAIJU_TEST_PLAYER_PATH");
            if (string.IsNullOrEmpty(path))
                return options;

            options.locationPathName = path;
            // Keep the test bootstrap first. The rescue fixture loads its sample additively.
            var package = UnityEditor.PackageManager.PackageInfo.FindForAssembly(typeof(KaijuAgent).Assembly);
            string rescue = $"Assets/Samples/{package.displayName}/{package.version}/Visual Decisions/Rescue Decisions.unity";
            options.scenes = System.IO.File.Exists(rescue) ? new[] { options.scenes[0], rescue } : new[] { options.scenes[0] };
            options.options &= ~(BuildOptions.AutoRunPlayer | BuildOptions.ConnectToHost |
                                 BuildOptions.Development | BuildOptions.AllowDebugging);
            return options;
        }

        public void Cleanup()
        {
            if (!string.IsNullOrEmpty(Environment.GetEnvironmentVariable("KAIJU_TEST_PLAYER_PATH")))
                EditorApplication.delayCall += () => EditorApplication.Exit(0);
        }
    }
}
