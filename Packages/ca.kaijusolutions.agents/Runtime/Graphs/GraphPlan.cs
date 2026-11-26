using System;
using System.Collections.Generic;

namespace KaijuSolutions.Agents.Graphs
{
    internal static class GraphRules
    {
        internal static bool Check(GraphGuard guard, GraphContext context, GraphResult result)
        {
            if (guard == null) return true;
            switch (guard.Kind)
            {
                case GraphGuard.Test.Always: return true;
                case GraphGuard.Test.Fact: return context.Get(guard.Key).Boolean == guard.Expected;
                case GraphGuard.Test.Compare:
                    var value = context.Get(guard.Key);
                    var operand = guard.Operand;
                    if (guard.Comparison == GraphGuard.Relation.Equal) return value.Matches(operand);
                    if (guard.Comparison == GraphGuard.Relation.NotEqual) return !value.Matches(operand);
                    double a = value.Type == GraphType.Integer ? (double)value.Integer : value.Number;
                    double b = value.Type == GraphType.Integer ? (double)operand.Integer : operand.Number;
                    return guard.Comparison switch { GraphGuard.Relation.Greater => a > b, GraphGuard.Relation.Less => a < b,
                        GraphGuard.Relation.GreaterOrEqual => a >= b, GraphGuard.Relation.LessOrEqual => a <= b, _ => false };
                case GraphGuard.Test.Signal: return context.Execution.Signalled(guard.Key);
                case GraphGuard.Test.Result: return result == guard.Result;
                case GraphGuard.Test.Predicate: return context.Execution.Services.Predicates[guard.Key](context) == guard.Expected;
                case GraphGuard.Test.All:
                    foreach (var term in guard.Terms) if (!Check(term, context, result)) return false;
                    return true;
                case GraphGuard.Test.Any:
                    foreach (var term in guard.Terms) if (Check(term, context, result)) return true;
                    return false;
                default: throw new ArgumentOutOfRangeException();
            }
        }

        internal static bool Match(GraphFact[] conditions, GraphContext context)
        {
            foreach (var fact in conditions)
                if (!context.Get(fact.Key).Matches(fact.Expected)) return false;
            return true;
        }
    }

    // GOAP uses uniform cost search. HTN explores methods in authored order and can backtrack.
    internal sealed class GraphPlan : IDisposable
    {
        private readonly GraphDomain domain;
        private readonly bool goap;
        private GraphSearch search;
        private GraphDecomposition decomposition;
        private GraphResult result;
        internal GraphResult Status => result;
        internal bool Queued { get; set; }
        internal bool Disposed { get; private set; }
        internal int Expansions => goap ? search.Expansions : decomposition.Expansions;
        internal string Reason => result switch { GraphResult.Succeeded => "plan selected", GraphResult.Running => "searching",
            _ => search.Limited != 0 || decomposition.Limited != 0 ? "search limit reached" : "no applicable plan" };
        internal List<int> Methods { get; private set; }
        internal List<int> Steps { get; private set; }

        internal GraphPlan(KaijuGraph graph, int index, GraphContext context)
        {
            domain = context.Execution.System.Domain(graph, index);
            ulong facts = domain.Snapshot(context);
            goap = graph.Steps[index].Op == GraphOp.Goap;
            if (goap) search = new GraphSearch(facts);
            else decomposition = new GraphDecomposition(facts, index);
        }

        internal GraphResult Search(int budget)
        {
            if (result != GraphResult.Running) return result;
            result = goap ? GraphSearch.Advance(ref search, domain.Actions, domain.Goal, budget) :
                GraphDecomposition.Advance(ref decomposition, domain.Tasks, domain.Children, budget);
            if (result == GraphResult.Succeeded)
            {
                Steps = new List<int>();
                if (goap) search.Collect(Steps);
                else { Methods = new List<int>(); decomposition.Collect(Steps, Methods); }
            }
            return result;
        }

        public void Dispose()
        {
            if (Disposed) return;
            Disposed = true;
            if (goap) search.Dispose();
            else decomposition.Dispose();
        }
    }
}
