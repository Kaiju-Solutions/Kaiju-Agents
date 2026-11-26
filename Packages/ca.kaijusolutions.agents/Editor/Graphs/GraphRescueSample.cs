using System;
using System.IO;
using KaijuSolutions.Agents.Graphs;
using Unity.GraphToolkit.Editor;
using UnityEditor;
using UnityEngine;

namespace KaijuSolutions.Agents.Editor.Graphs
{
    /// <summary>Creates a complete editable example in the selected project, including cross-asset calls.</summary>
    public static class GraphRescueSample
    {
        public static string SamplePath
        {
            get
            {
                var package = UnityEditor.PackageManager.PackageInfo.FindForAssembly(typeof(KaijuGraph).Assembly);
                return $"Assets/Samples/{package.displayName}/{package.version}/Visual Decisions/Resources/KaijuDecisions";
            }
        }
        public static void GeneratePackageSample() => Generate(SamplePath);

        public static KaijuGraph Generate(string directory)
        {
            if (!AssetDatabase.IsValidFolder(directory) || !directory.StartsWith("Assets/", StringComparison.Ordinal))
                throw new ArgumentException("Expected an existing folder under Assets");
            string PathFor(string name) => directory + "/" + name;
            string[] names = { "Pickup.kaijugraph", "Choice.kaijugraph", "Plan.kaijugraph", "Tasks.kaijugraph", "Mission.kaijufsm", "Rescue.kaijufsm" };
            foreach (string name in names)
                if (File.Exists(PathFor(name))) throw new IOException($"Asset already exists at {PathFor(name)}");
            var path = PathFor(names[0]);
            var tree = GraphDatabase.CreateGraph<KaijuVisualGraph>(path);
            tree.UndoBeginRecordGraph("Create rescue tasks");
            try
            {
                var entry = new EntryNode();
                var sequence = new SequenceNode { Position = new Vector2(200, 0) };
                var policy = new PolicyNode { Position = new Vector2(480, 0) };
                var pickup = new ActionNode { Position = new Vector2(480, 240) };
                tree.AddNode(entry);
                tree.AddNode(sequence);
                tree.AddNode(policy);
                tree.AddNode(pickup);
                policy.GetNodeOptionByName("Service").TrySetValue("policy");
                policy.GetNodeOptionByName("Seconds").TrySetValue(0.12f);
                pickup.GetNodeOptionByName("Service").TrySetValue("rescue.pick-up");
                tree.Connect(entry.GetOutputPortByName("Root"), sequence.GetInputPortByName("In"));
                tree.Connect(sequence.GetOutputPortByName("Child 1"), policy.GetInputPortByName("In"));
                tree.Connect(sequence.GetOutputPortByName("Child 2"), pickup.GetInputPortByName("In"));
            }
            finally { tree.UndoEndRecordGraph(); }
            GraphDatabase.SaveGraph(tree);
            AssetDatabase.ImportAsset(path, ImportAssetOptions.ForceSynchronousImport);
            var child = AssetDatabase.LoadAssetAtPath<KaijuGraph>(path);
            if (!child) throw new InvalidOperationException("Pickup graph failed to import");
            var families = new[] { GraphFamily.Utility, GraphFamily.Goap, GraphFamily.Htn, GraphFamily.StateMachine, GraphFamily.StateMachine };
            for (int i = 0; i < families.Length; i++) child = KaijuGraphTemplates.Create(PathFor(names[i + 1]), families[i], child);
            return child;
        }
    }
}
