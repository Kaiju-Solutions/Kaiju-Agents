using System.Collections.Generic;
using KaijuSolutions.Agents.Graphs;
using UnityEditor;
using Unity.GraphToolkit.Editor.GraphVisualization;
using UnityEngine;

namespace KaijuSolutions.Agents.Editor.Graphs
{
    [CustomEditor(typeof(KaijuGraphRunner))]
    internal sealed class GraphRunnerInspector : UnityEditor.Editor
    {
        private GraphExecution observed;
        private readonly Dictionary<Hash128, Context> views = new();
        private readonly Queue<string> history = new();
        private readonly List<GraphLocation> stack = new();

        public override void OnInspectorGUI()
        {
            DrawDefaultInspector();
            var execution = ((KaijuGraphRunner)target).Execution;
            if (execution != observed)
            {
                OnDisable();
                observed = execution;
                history.Clear();
                if (observed != null) { observed.Trace += Record; observed.Decision += Explain; }
            }
            if (observed == null) return;
            EditorGUILayout.LabelField($"Tick {observed.TickNumber}   {observed.Result}");
            observed.GetCallStack(stack);
            foreach (var node in stack) EditorGUILayout.LabelField(node.Graph.name, node.Graph.NodeLabel(node.Node));
            foreach (string item in history) EditorGUILayout.LabelField(item);
        }

        private void Append(string value)
        {
            if (history.Count == 20) history.Dequeue();
            history.Enqueue(value);
            Repaint();
        }

        private void Record(ulong tick, KaijuGraph graph, Hash128 id, GraphResult result)
        {
            Append($"{tick}  {graph.name}  {graph.NodeLabel(id)}  {result}");
            if (!graph.SourceId.isValid || result != GraphResult.Running) return;
            if (!views.TryGetValue(graph.SourceId, out var view))
                views.Add(graph.SourceId, view = Registry.CreateVisualizationContext(graph.SourceId));
            if (!view.IsValid || !view.IsGraphLoaded) return;
            if (graph.Family == GraphFamily.StateMachine)
            {
                for (int i = 0; i < graph.StepCount; i++)
                {
                    var step = graph.InspectStep(i);
                    if (step.Id != id || step.Op != GraphOp.State) continue;
                    view.Motion.Play(view.GetStateReference(id), 1f);
                    break;
                }
            }
            else view.Motion.Play(view.GetNodeReference(id), 1f);
        }
        private void Explain(ulong tick, KaijuGraph graph, Hash128 id, string reason, float value) =>
            Append($"{tick}  {graph.name}  {graph.NodeLabel(id)}  {reason}  {value:g4}");
        public override bool RequiresConstantRepaint() => EditorApplication.isPlaying;
        private void OnDisable()
        {
            if (observed == null) return;
            observed.Trace -= Record;
            observed.Decision -= Explain;
            observed = null;
            foreach (var view in views.Values) view.Dispose();
            views.Clear();
        }
    }
}
