using System;
using System.Collections.Generic;
using System.Linq;
using KaijuSolutions.Agents.Graphs;
using Unity.GraphToolkit.Editor;
using UnityEditor;
using UnityEditor.AssetImporters;
using UnityEngine;

namespace KaijuSolutions.Agents.Editor.Graphs
{
    [ScriptedImporter(3, KaijuVisualGraph.Extension)]
    internal sealed class KaijuGraphImporter : ScriptedImporter
    {
        internal static string[] Items(string value) => string.IsNullOrWhiteSpace(value) ? Array.Empty<string>() :
            value.Split(',').Select(s => s.Trim()).ToArray();

        internal static GraphGuard Guard(string key)
        {
            if (string.IsNullOrWhiteSpace(key)) return null;
            key = key.Trim();
            return new GraphGuard
            {
                Kind = key[0] switch { '@' => GraphGuard.Test.Signal, '?' => GraphGuard.Test.Predicate, _ => GraphGuard.Test.Fact },
                Expected = key[0] != '!',
                Key = key.TrimStart('!', '@', '?')
            };
        }

        internal static GraphBinding[] Bindings(string text) => Items(text).Select(item =>
        {
            var pair = item.Split('=');
            if (pair.Length != 2) throw new FormatException($"Expected parent=child binding, found {item}");
            return new GraphBinding { Parent = pair[0].Trim(), Child = pair[1].Trim() };
        }).ToArray();

        private static GraphFact[] Facts(string text, GraphVariable[] variables) => Items(text).Select(item =>
        {
            var pair = item.Split(new[] { '=' }, 2);
            string name = pair[0].Trim().TrimStart('!');
            var variable = Array.Find(variables, v => v.Name == name);
            if (variable.Name == null) throw new FormatException($"Unknown fact {name}");
            if (pair.Length == 1)
            {
                if (variable.Default.Type != GraphType.Boolean) throw new FormatException($"Supply a value for {name}");
                return new GraphFact { Key = name, Value = !item.StartsWith("!") };
            }
            string value = pair[1].Trim();
            var culture = System.Globalization.CultureInfo.InvariantCulture;
            var typed = variable.Default.Type switch
            {
                GraphType.Boolean => GraphValue.From(bool.Parse(value)),
                GraphType.Integer => GraphValue.From(int.Parse(value, culture)),
                GraphType.Number => GraphValue.From(float.Parse(value, culture)),
                GraphType.Text => GraphValue.From(value),
                GraphType.Vector => GraphValue.From(ParseVector(value)),
                _ => throw new FormatException($"Unsupported fact {name}")
            };
            return new GraphFact { Key = name, Value = typed.Boolean, TypedValue = typed };
        }).ToArray();

        private static Vector3 ParseVector(string value)
        {
            var parts = value.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            if (parts.Length != 3) throw new FormatException("Use x y z for a vector fact");
            var c = System.Globalization.CultureInfo.InvariantCulture;
            return new Vector3(float.Parse(parts[0], c), float.Parse(parts[1], c), float.Parse(parts[2], c));
        }

        internal static GraphVariable[] Variables(IEnumerable<IVariable> variables) => variables.Select(variable =>
        {
            GraphValue value;
            if (variable.DataType == typeof(bool) && variable.TryGetDefaultValue<bool>(out var b)) value = GraphValue.From(b);
            else if (variable.DataType == typeof(int) && variable.TryGetDefaultValue<int>(out var i)) value = GraphValue.From(i);
            else if (variable.DataType == typeof(float) && variable.TryGetDefaultValue<float>(out var f)) value = GraphValue.From(f);
            else if (variable.DataType == typeof(Vector3) && variable.TryGetDefaultValue<Vector3>(out var v)) value = GraphValue.From(v);
            else if (variable.DataType == typeof(string) && variable.TryGetDefaultValue<string>(out var s)) value = GraphValue.From(s);
            else throw new FormatException($"Unsupported blackboard type for {variable.Name}");
            return new GraphVariable { Name = variable.Name, Default = value, Access = variable.VariableKind switch
                { VariableKind.Input => GraphAccess.Input, VariableKind.Output => GraphAccess.Output, _ => GraphAccess.Local } };
        }).ToArray();

        internal static void Dependency(AssetImportContext ctx, KaijuGraph target)
        {
            if (target) ctx.DependsOnArtifact(AssetDatabase.GetAssetPath(target));
        }

        private static T Port<T>(TaskNode node, string key)
        {
            var port = node.GetInputPortByName(key);
            if (port.IsConnected) throw new FormatException($"Enter {key} directly on {node.Title}");
            if (!port.TryGetValue<T>(out var value)) throw new FormatException($"Missing {key} on {node.Title}");
            return value;
        }

        private static string[] GatherDependenciesFromSourceFile(string path) => GraphDependencies.Gather(path);

        public override void OnImportAsset(AssetImportContext ctx)
        {
            try
            {
                var source = GraphDatabase.LoadGraphForImporter<KaijuVisualGraph>(ctx.assetPath);
                var nodes = source.GetNodes().OfType<TaskNode>().ToArray();
                var entry = source.GetNodes().OfType<EntryNode>().SingleOrDefault();
                if (entry == null && nodes.Length == 0) return;
                if (entry == null) throw new FormatException("Add one Entry node and connect its Root port.");
                var indices = nodes.Select((n, i) => (n, i)).ToDictionary(p => p.n, p => p.i);
                int Target(IPort port) => port?.FirstConnectedPort?.GetNode() is TaskNode target ? indices[target] :
                    throw new FormatException($"Connect {port?.Name} to a task");
                int root = Target(entry.GetOutputPortByName("Root"));
                var variables = Variables(source.GetVariables());
                var steps = nodes.Select(node =>
                {
                    int count = node.Operation is GraphOp.Invert or GraphOp.Repeat or GraphOp.Retry or GraphOp.Timeout ? 1 : node.Read<int>("Children");
                    int considerations = node.Read<int>("Considerations");
                    if (count < 0 || count > 256 || considerations < 0 || considerations > 64)
                        throw new FormatException("Expected 0 to 256 child ports and 0 to 64 considerations");
                    var step = new GraphStep
                    {
                        Id = node.ID, Label = node.Title, Op = node.Operation, Key = node.Read<string>("Service"),
                        Guard = Guard(node.Read<string>("Condition")), Eligibility = Guard(node.Read<string>("Eligible")),
                        Scorer = node.Read<string>("Scorer"), Duration = node.Read<float>("Seconds"),
                        Timeout = node.Read<float>("Timeout"), Reactive = node.Read<bool>("Reactive"),
                        SwitchMargin = node.Read<float>("Switch margin"), Cost = node.Read<float>("Cost"), BaseScore = node.Read<float>("Base score"),
                        Effects = Facts(node.Read<string>("Effects"), variables), Preconditions = Facts(node.Read<string>("Preconditions"), variables),
                        Graph = node.Read<KaijuGraph>("Graph"), Bindings = Bindings(node.Read<string>("Bindings")),
                        Retries = node.Read<int>(node.Operation == GraphOp.Repeat ? "Iterations" : "Retries"),
                        Children = Enumerable.Range(1, count).Select(i => Target(node.GetOutputPortByName("Child " + i))).ToArray(),
                        Considerations = Enumerable.Range(0, considerations).Select(i =>
                            new GraphConsideration { Input = Port<string>(node, "Input " + i), Weight = Port<float>(node, "Weight " + i),
                                Response = Port<AnimationCurve>(node, "Curve " + i) }).ToArray()
                    };
                    var scorePort = node.GetInputPortByName("Score");
                    if (scorePort.IsConnected)
                    {
                        if (scorePort.FirstConnectedPort.GetNode() is not ConsiderationNode formula)
                            throw new FormatException("Connect a Consideration node to Score");
                        step.Score = formula.Compile(new HashSet<ConsiderationNode>());
                    }
                    else if (scorePort.TryGetValue<float>(out var offset)) step.BaseScore += offset;
                    Dependency(ctx, step.Graph);
                    return step;
                }).ToArray();
                var family = steps[root].Op switch { GraphOp.Utility => GraphFamily.Utility, GraphOp.Goap => GraphFamily.Goap,
                    GraphOp.Htn => GraphFamily.Htn, _ => GraphFamily.BehaviorTree };
                var graph = KaijuGraph.Create(family, root, variables, steps, source.ID);
                ctx.AddObjectToAsset("Runtime", graph);
                ctx.SetMainObject(graph);
            }
            catch (Exception e) { ctx.LogImportError(e.Message); }
        }
    }
}
