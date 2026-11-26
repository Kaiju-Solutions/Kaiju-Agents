using System;
using System.IO;
using KaijuSolutions.Agents.Graphs;
using Unity.GraphToolkit.Editor;
using UnityEditor;
using UnityEngine;

namespace KaijuSolutions.Agents.Editor.Graphs
{
    public static class KaijuGraphTemplates
    {
        [MenuItem("Assets/Create/Kaiju Agents/Templates/Behavior Tree")]
        private static void Tree() => Save(GraphFamily.BehaviorTree);
        [MenuItem("Assets/Create/Kaiju Agents/Templates/State Machine")]
        private static void StateMachine() => Save(GraphFamily.StateMachine);
        [MenuItem("Assets/Create/Kaiju Agents/Templates/Utility AI")]
        private static void Utility() => Save(GraphFamily.Utility);
        [MenuItem("Assets/Create/Kaiju Agents/Templates/GOAP")]
        private static void Goap() => Save(GraphFamily.Goap);
        [MenuItem("Assets/Create/Kaiju Agents/Templates/HTN")]
        private static void Htn() => Save(GraphFamily.Htn);

        private static void Save(GraphFamily family)
        {
            string extension = family == GraphFamily.StateMachine ? KaijuStateMachine.Extension : KaijuVisualGraph.Extension;
            string path = EditorUtility.SaveFilePanelInProject("Create " + family, family.ToString(), extension, "Choose a new graph asset");
            if (!string.IsNullOrEmpty(path)) Selection.activeObject = Create(path, family);
        }

        public static KaijuGraph Create(string path, GraphFamily family, KaijuGraph child = null)
        {
            if (string.IsNullOrEmpty(path) || !path.StartsWith("Assets/", StringComparison.Ordinal) ||
                path.Contains("..") || path.Contains("\\") || File.Exists(path))
                throw new ArgumentException("Choose a new asset path under Assets", nameof(path));
            bool state = family == GraphFamily.StateMachine;
            string extension = state ? KaijuStateMachine.Extension : KaijuVisualGraph.Extension;
            if (Path.GetExtension(path) != "." + extension) throw new ArgumentException($"Expected .{extension}");
            if (state)
            {
                var machine = StateMachineDatabase.CreateStateMachine<KaijuStateMachine>(path);
                machine.UndoBeginRecordStateMachine("Create Kaiju state machine");
                try
                {
                    var initial = new BehaviorState();
                    machine.AddState(initial);
                    initial.GetOptionByName("Initial").TrySetValue(true);
                    if (child) initial.GetOptionByName("Behavior").TrySetValue(child);
                }
                finally { machine.UndoEndRecordStateMachine(); }
                StateMachineDatabase.SaveStateMachine(machine);
            }
            else
            {
                var graph = GraphDatabase.CreateGraph<KaijuVisualGraph>(path);
                graph.UndoBeginRecordGraph("Create Kaiju graph");
                try
                {
                    var entry = new EntryNode();
                    graph.AddNode(entry);
                    TaskNode root = family switch { GraphFamily.BehaviorTree => new SequenceNode(), GraphFamily.Utility => new UtilityNode(),
                        GraphFamily.Goap => new GoapNode(), GraphFamily.Htn => new HtnNode(), _ => throw new ArgumentOutOfRangeException(nameof(family)) };
                    root.Position = new Vector2(220, 0);
                    graph.AddNode(root);
                    root.GetNodeOptionByName("Children").TrySetValue(1);
                    graph.Connect(entry.GetOutputPortByName("Root"), root.GetInputPortByName("In"));
                    TaskNode task = child ? new CallNode() : new SucceedNode();
                    task.Position = new Vector2(700, 0);
                    graph.AddNode(task);
                    if (child) task.GetNodeOptionByName("Graph").TrySetValue(child);
                    if (family == GraphFamily.Goap)
                    {
                        graph.CreateVariable("done", false, VariableKind.Local);
                        root.GetNodeOptionByName("Effects").TrySetValue("done");
                        task.GetNodeOptionByName("Effects").TrySetValue("done");
                    }
                    if (family == GraphFamily.Htn)
                    {
                        var method = new MethodNode { Position = new Vector2(460, 0) };
                        graph.AddNode(method);
                        method.GetNodeOptionByName("Children").TrySetValue(1);
                        graph.Connect(root.GetOutputPortByName("Child 1"), method.GetInputPortByName("In"));
                        root = method;
                    }
                    graph.Connect(root.GetOutputPortByName("Child 1"), task.GetInputPortByName("In"));
                }
                finally { graph.UndoEndRecordGraph(); }
                GraphDatabase.SaveGraph(graph);
            }
            AssetDatabase.ImportAsset(path, ImportAssetOptions.ForceSynchronousImport | ImportAssetOptions.ForceUpdate);
            return AssetDatabase.LoadAssetAtPath<KaijuGraph>(path) ?? throw new InvalidOperationException($"Import failed for {path}");
        }
    }
}
