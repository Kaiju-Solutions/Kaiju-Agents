using System;
using System.Collections.Generic;
using System.Linq;
using KaijuSolutions.Agents.Graphs;
using Newtonsoft.Json.Linq;
using Unity.Pipeline.Commands;
using UnityEditor;
using UnityEngine;

namespace KaijuSolutions.Agents.Editor.Graphs
{
    public static class GraphTraceCommand
    {
        private static GraphExecution observed;
        private static readonly List<object> records = new();
        private static readonly List<GraphLocation> stack = new();
        private static int remaining;

        internal static object[] Snapshot(GraphExecution run, List<GraphLocation> buffer)
        {
            run.GetCallStack(buffer);
            return buffer.Select(p => (object)new { graph = AssetDatabase.GetAssetPath(p.Graph), node = p.Node.ToString(),
                label = p.Graph.NodeLabel(p.Node), operation = p.Operation.ToString(), service = p.Service }).ToArray();
        }

        [CliCommand("kaiju-agents", "trace-agent", "Capture or read fixed-step decisions from a live scene agent.")]
        public static object Trace([CliArg("options", "JSON with operation=start/read/stop, scene hierarchy path and optional ticks.")] string options)
        {
            var args = JObject.Parse(options);
            switch ((string)args["operation"] ?? "read")
            {
                case "start":
                    if (!EditorApplication.isPlaying) throw new InvalidOperationException("Enter Play Mode before capturing a live trace");
                    var runner = GameObject.Find((string)args["path"])?.GetComponent<KaijuGraphRunner>();
                    var execution = runner?.Execution;
                    if (execution == null || execution.Result != GraphResult.Running) throw new ArgumentException("Select a running graph agent by hierarchy path");
                    int ticks = (int?)args["ticks"] ?? 60;
                    if (ticks < 1 || ticks > 10000) throw new ArgumentOutOfRangeException(nameof(ticks));
                    Detach();
                    records.Clear();
                    remaining = ticks;
                    observed = execution;
                    observed.TickFinished += Tick;
                    observed.Trace += Node;
                    observed.Decision += Decision;
                    break;
                case "stop": Detach(); break;
                case "read":
                    if (observed != null && (observed.Result != GraphResult.Running || !EditorApplication.isPlaying)) Detach();
                    break;
                default: throw new ArgumentException("Expected start, read or stop");
            }
            return new { recording = observed != null, records = records.ToArray() };
        }

        private static void Tick(GraphExecution run)
        {
            records.Add(new { tick = run.TickNumber, result = run.Result.ToString(), stack = Snapshot(run, stack) });
            if (--remaining == 0 || run.Result != GraphResult.Running || records.Count >= 100000) Detach();
        }
        private static void Node(ulong tick, KaijuGraph graph, Hash128 node, GraphResult result) =>
            records.Add(new { tick, graph = AssetDatabase.GetAssetPath(graph), node = node.ToString(), result = result.ToString() });
        private static void Decision(ulong tick, KaijuGraph graph, Hash128 node, string reason, float value) =>
            records.Add(new { tick, graph = AssetDatabase.GetAssetPath(graph), node = node.ToString(), reason, value });
        private static void Detach()
        {
            if (observed == null) return;
            observed.TickFinished -= Tick;
            observed.Trace -= Node;
            observed.Decision -= Decision;
            observed = null;
        }
    }
}
