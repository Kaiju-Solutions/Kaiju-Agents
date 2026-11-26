using System;
using KaijuSolutions.Agents.Editor.Graphs;
using KaijuSolutions.Agents.Graphs;
using NUnit.Framework;
using UnityEditor;

namespace KaijuSolutions.Agents.Tests
{
    public sealed class GraphImportTests
    {
        [Test]
        public void EveryTemplateSurvivesReimportAndMaintainsCrossAssetReference()
        {
            var folder = "KaijuGraphImportTest" + Guid.NewGuid().ToString("N");
            AssetDatabase.CreateFolder("Assets", folder);
            var directory = "Assets/" + folder + "/";
            try
            {
                var behavior = KaijuGraphTemplates.Create(directory + "Tree.kaijugraph", GraphFamily.BehaviorTree);
                foreach (GraphFamily family in Enum.GetValues(typeof(GraphFamily)))
                {
                    var path = directory + family + (family == GraphFamily.StateMachine ? ".kaijufsm" : ".kaijugraph");
                    KaijuGraphTemplates.Create(path, family, behavior);
                    AssetDatabase.ImportAsset(path, ImportAssetOptions.ForceUpdate | ImportAssetOptions.ForceSynchronousImport);
                    var compiled = AssetDatabase.LoadAssetAtPath<KaijuGraph>(path);
                    Assert.AreEqual(family, compiled.Family);
                    GraphValidation.Validate(compiled);
                    Assert.IsTrue(System.Linq.Enumerable.Any(System.Linq.Enumerable.Range(0, compiled.StepCount), index => compiled.InspectStep(index).Graph == behavior));
                }
            }
            finally { AssetDatabase.DeleteAsset("Assets/" + folder); }
        }
    }
}
