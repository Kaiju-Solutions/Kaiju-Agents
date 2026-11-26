using System;
using System.Collections.Generic;
using KaijuSolutions.Agents.Graphs;
using Newtonsoft.Json.Linq;
using Unity.Entities;
using Unity.Pipeline.Commands;
using UnityEditor;

namespace KaijuSolutions.Agents.Editor.Graphs
{
    public static class GraphCommands
    {
        private static KaijuGraph Load(string path) => AssetDatabase.LoadAssetAtPath<KaijuGraph>(path) ??
            throw new ArgumentException($"No compiled Kaiju graph at {path}. Check the import diagnostics.");

        [CliCommand("kaiju-agents", "create-graph", "Create an editable graph from a family template.")]
        public static object Create([CliArg("options", "JSON with path, family, and optional child asset path.")] string options)
        {
            var args = JObject.Parse(options);
            string child = (string)args["child"];
            var graph = KaijuGraphTemplates.Create((string)args["path"], Enum.Parse<GraphFamily>((string)args["family"], true),
                string.IsNullOrEmpty(child) ? null : Load(child));
            return new { path = AssetDatabase.GetAssetPath(graph), family = graph.Family.ToString() };
        }

        [CliCommand("kaiju-agents", "validate-graph", "Validate inputs, calls, tasks and planner domains.", Effect = CommandEffect.ReadOnly)]
        public static object Validate([CliArg("path", "Graph asset path")] string path)
        {
            var graph = Load(path);
            GraphValidation.Validate(graph);
            return new { path, family = graph.Family.ToString(), nodes = graph.StepCount };
        }

        [CliCommand("kaiju-agents", "compile-graph", "Reimport a Graph Toolkit asset and validate its player data.")]
        public static object Compile([CliArg("path", "Graph asset path")] string path)
        {
            AssetDatabase.ImportAsset(path, ImportAssetOptions.ForceSynchronousImport | ImportAssetOptions.ForceUpdate);
            return Validate(path);
        }

        [CliCommand("kaiju-agents", "run-graph", "Execute an isolated entity scenario and return the per-tick trace.")]
        public static object Run([CliArg("options", "JSON with path, optional inputs, ticks, delta, and signals keyed by tick.")] string options)
        {
            var args = JObject.Parse(options);
            int ticks = (int?)args["ticks"] ?? 60;
            float delta = (float?)args["delta"] ?? 1f / 60f;
            if (ticks < 1 || ticks > 10000 || !(delta > 0) || float.IsInfinity(delta)) throw new ArgumentOutOfRangeException(nameof(options));
            var graph = Load((string)args["path"]);
            using var world = new World("Kaiju graph scenario");
            var entity = world.EntityManager.CreateEntity();
            var system = world.GetOrCreateSystemManaged<KaijuGraphSystem>();
            var inputs = new Dictionary<string, GraphValue>();
            if (args["inputs"] is JObject supplied)
            {
                foreach (var field in supplied.Properties())
                {
                    var variable = System.Linq.Enumerable.First(graph.Variables, v => v.Name == field.Name);
                    inputs.Add(field.Name, variable.Default.Type switch {
                        GraphType.Boolean => GraphValue.From((bool)field.Value), GraphType.Integer => GraphValue.From((int)field.Value),
                        GraphType.Number => GraphValue.From((float)field.Value), GraphType.Text => GraphValue.From((string)field.Value),
                        GraphType.Vector => GraphValue.From(field.Value.ToObject<UnityEngine.Vector3>()), _ => throw new FormatException(field.Name) });
                }
            }
            var execution = system.Start(entity, graph, inputs: inputs);
            var trace = new List<object>();
            var stack = new List<GraphLocation>();
            execution.TickFinished += run => trace.Add(new { tick = run.TickNumber, stack = GraphTraceCommand.Snapshot(run, stack) });
            execution.Trace += (tick, asset, node, result) => trace.Add(new { tick, graph = AssetDatabase.GetAssetPath(asset), node = node.ToString(), result = result.ToString() });
            execution.Decision += (tick, asset, node, reason, value) => trace.Add(new { tick, graph = AssetDatabase.GetAssetPath(asset), node = node.ToString(), reason, value });
            for (int i = 1; i <= ticks && execution.Result == GraphResult.Running; i++)
            {
                if (args["signals"]?[i.ToString()] is JArray signals)
                    foreach (string signal in signals) execution.Signal(signal);
                world.SetTime(new Unity.Core.TimeData((double)i * delta, delta));
                system.Update();
            }
            var outcome = execution.Result;
            execution.Cancel();
            var outputs = new Dictionary<string, object>();
            foreach (var variable in graph.Variables)
            {
                if (variable.Access is not (GraphAccess.Output or GraphAccess.InOut)) continue;
                var value = execution.Context.Get(variable.Name);
                outputs[variable.Name] = value.Type switch { GraphType.Boolean => value.Boolean, GraphType.Integer => value.Integer,
                    GraphType.Number => value.Number, GraphType.Text => value.Text, _ => new { x = value.Vector.x, y = value.Vector.y, z = value.Vector.z } };
            }
            return new { result = outcome.ToString(), ticks = execution.TickNumber, outputs, trace };
        }
    }
}
