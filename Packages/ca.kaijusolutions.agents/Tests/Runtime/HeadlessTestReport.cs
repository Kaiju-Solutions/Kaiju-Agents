#if !UNITY_EDITOR
using System;
using System.IO;
using NUnit.Framework.Interfaces;
using UnityEngine;
using UnityEngine.TestRunner;

[assembly: TestRunCallback(typeof(KaijuSolutions.Agents.Tests.HeadlessTestReport))]

namespace KaijuSolutions.Agents.Tests
{
    public sealed class HeadlessTestReport : ITestRunCallback
    {
        public void RunStarted(ITest testsToRun) { }
        public void TestStarted(ITest test) { }
        public void TestFinished(ITestResult result) { }

        public void RunFinished(ITestResult result)
        {
            string path = Environment.GetEnvironmentVariable("KAIJU_TEST_PLAYER_REPORT");
            if (string.IsNullOrEmpty(path))
                return;

            try
            {
                File.WriteAllText(path, result.ToXml(true).OuterXml);
                Application.Quit(result.FailCount == 0 ? 0 : 1);
            }
            catch (Exception exception)
            {
                Debug.LogException(exception);
                Application.Quit(1);
            }
        }
    }
}
#endif
