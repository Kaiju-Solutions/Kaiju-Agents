using System;
using System.Collections.Generic;

namespace KaijuSolutions.Agents.Graphs
{
    public static class GraphValidation
    {
        public static void Validate(KaijuGraph graph) => Visit(graph, new HashSet<KaijuGraph>(), new HashSet<KaijuGraph>());

        private static void Visit(KaijuGraph graph, HashSet<KaijuGraph> path, HashSet<KaijuGraph> done)
        {
            if (done.Contains(graph)) return;
            if (path.Count >= 128 || !path.Add(graph)) throw new FormatException("Recursive Run Graph call");
            var variables = new Dictionary<string, GraphVariable>();
            foreach (var item in graph.Variables)
                if (string.IsNullOrWhiteSpace(item.Name) || !variables.TryAdd(item.Name, item))
                    throw new FormatException($"Invalid or duplicate variable '{item.Name}'");
            void Require(string key, GraphType type)
            {
                if (key == null || !variables.TryGetValue(key, out var variable) || variable.Default.Type != type)
                    throw new FormatException($"Expected {type} variable '{key}'");
            }
            var guards = new HashSet<GraphGuard>();
            var formulas = new HashSet<GraphScore>();
            void Guard(GraphGuard guard)
            {
                if (guard == null) return;
                if (guards.Count >= 128 || !guards.Add(guard)) throw new FormatException("Invalid guard nesting");
                if (guard.Kind == GraphGuard.Test.Fact) Require(guard.Key, GraphType.Boolean);
                if (guard.Kind == GraphGuard.Test.Compare)
                {
                    Require(guard.Key, guard.Operand.Type);
                    if (guard.Comparison is not (GraphGuard.Relation.Equal or GraphGuard.Relation.NotEqual) &&
                        guard.Operand.Type is not (GraphType.Integer or GraphType.Number))
                        throw new FormatException("Ordering requires an Integer or Number");
                }
                foreach (var term in guard.Terms) Guard(term);
                guards.Remove(guard);
            }
            void Formula(GraphScore score)
            {
                if (score == null) return;
                if (formulas.Count >= 128 || !formulas.Add(score)) throw new FormatException("Invalid score nesting");
                switch (score.Operation)
                {
                    case ScoreOperation.Boolean: Require(score.Key, GraphType.Boolean); break;
                    case ScoreOperation.Integer: Require(score.Key, GraphType.Integer); break;
                    case ScoreOperation.Curve:
                        if (score.Curve == null) throw new FormatException("Missing score curve");
                        goto case ScoreOperation.Number;
                    case ScoreOperation.Number: Require(score.Key, GraphType.Number); break;
                }
                foreach (var term in score.Children) Formula(term);
                formulas.Remove(score);
            }
            void Facts(GraphFact[] facts)
            {
                if (facts.Length == 0) return;
                var keys = new HashSet<string>();
                foreach (var fact in facts)
                {
                    Require(fact.Key, fact.Expected.Type);
                    if (!keys.Add(fact.Key)) throw new FormatException($"Duplicate planner fact '{fact.Key}'");
                }
            }
            var marks = new byte[graph.Steps.Count];
            void Check(int index, int depth = 0)
            {
                if (depth >= 128) throw new FormatException("Task nesting exceeds 128 frames");
                if ((uint)index >= (uint)marks.Length) throw new FormatException("Invalid task index");
                if (marks[index] == 2) return;
                if (marks[index] == 1) throw new FormatException("Cycle between tasks");
                marks[index] = 1;
                var step = graph.Steps[index];
                if (step == null) throw new FormatException("Missing task definition");
                if (step.Op is GraphOp.Invert or GraphOp.Retry or GraphOp.Repeat or GraphOp.Timeout && step.Children.Length != 1 || step.Op == GraphOp.State && step.Children.Length > 1)
                    throw new FormatException($"Invalid number of children for {step.Op}");
                foreach (var child in step.Children) Check(child, depth + 1);
                foreach (var transition in step.Transitions)
                {
                    if ((uint)transition.Target >= (uint)marks.Length || graph.Steps[transition.Target].Op != GraphOp.State)
                        throw new FormatException("Invalid transition destination");
                    Guard(transition.Guard);
                }
                Guard(step.Guard);
                Guard(step.Eligibility);
                Formula(step.Score);
                if (float.IsNaN(step.Cost) || float.IsInfinity(step.Cost)) throw new FormatException("Non-finite score or cost");
                if (!(step.Duration >= 0) || !(step.Timeout >= 0) || !(step.SwitchMargin >= 0) || step.Retries < 0)
                    throw new FormatException("Durations, margins and retry counts must be nonnegative");
                if (step.Op == GraphOp.Goap)
                    foreach (var child in step.Children)
                        if (graph.Steps[child].Cost < 0) throw new FormatException("GOAP requires nonnegative action costs");
                Facts(step.Preconditions);
                Facts(step.Effects);
                if (step.Op is GraphOp.Goap or GraphOp.Htn) GraphDomain.Layout(graph, step, out _);
                foreach (var consideration in step.Considerations)
                {
                    Require(consideration.Input, GraphType.Number);
                    if (consideration.Response == null) throw new FormatException("Missing response curve");
                }
                if (step.Op is GraphOp.Htn)
                    foreach (var method in step.Children)
                        if (graph.Steps[method].Op != GraphOp.Method) throw new FormatException("Compound tasks require methods");
                if (step.Op is GraphOp.Action or GraphOp.Policy && string.IsNullOrWhiteSpace(step.Key))
                    throw new FormatException("Missing service name");
                if (step.Op == GraphOp.Call)
                {
                    if (!step.Graph) throw new FormatException("Missing called graph");
                    Visit(step.Graph, path, done);
                    var bound = new HashSet<string>();
                    foreach (var binding in step.Bindings)
                    {
                        if (!variables.TryGetValue(binding.Parent, out var parent) || !bound.Add(binding.Child))
                            throw new FormatException($"Invalid binding {binding.Parent}={binding.Child}");
                        bool match = false;
                        foreach (var child in step.Graph.Variables)
                            if (child.Name == binding.Child && child.Access != GraphAccess.Local && child.Default.Type == parent.Default.Type)
                                match = true;
                        if (!match) throw new FormatException($"Invalid child variable '{binding.Child}'");
                    }
                    foreach (var child in step.Graph.Variables)
                        if (child.Access is GraphAccess.Input or GraphAccess.InOut && !bound.Contains(child.Name))
                            throw new FormatException($"Unbound input '{child.Name}'");
                }
                marks[index] = 2;
            }
            for (int i = 0; i < marks.Length; i++) Check(i);
            path.Remove(graph);
            done.Add(graph);
        }
    }
}
