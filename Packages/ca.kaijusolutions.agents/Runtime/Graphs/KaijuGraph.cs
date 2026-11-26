using System;
using System.Collections.Generic;
using UnityEngine;

namespace KaijuSolutions.Agents.Graphs
{
    public enum GraphFamily { StateMachine, BehaviorTree, Utility, Goap, Htn }
    public enum GraphResult { Running, Succeeded, Failed, Cancelled, TimedOut }
    public enum GraphOp { State, Sequence, Selector, Invert, Action, Call, Wait, Condition, Succeed, Fail, Utility, Goap, Htn, Method, Policy, Repeat, Retry, Timeout }
    public enum StateCompletion { Automatic, StayActive, Succeed, Fail }
    public enum GraphAccess { Local, Input, Output, InOut }
    public enum GraphType { Boolean, Integer, Number, Vector, Text }

    [Serializable]
    public struct GraphValue
    {
        public GraphType Type;
        public bool Boolean;
        public int Integer;
        public float Number;
        public Vector3 Vector;
        public string Text;
        public static GraphValue From(bool value) => new GraphValue { Boolean = value };
        public static GraphValue From(int value) => new GraphValue { Type = GraphType.Integer, Integer = value };
        public static GraphValue From(float value) => new GraphValue { Type = GraphType.Number, Number = value };
        public static GraphValue From(Vector3 value) => new GraphValue { Type = GraphType.Vector, Vector = value };
        public static GraphValue From(string value) => new GraphValue { Type = GraphType.Text, Text = value };
        public bool Matches(GraphValue other) => Type == other.Type && Type switch
        {
            GraphType.Boolean => Boolean == other.Boolean, GraphType.Integer => Integer == other.Integer,
            GraphType.Number => Number.Equals(other.Number), GraphType.Vector => Vector.Equals(other.Vector),
            GraphType.Text => Text == other.Text, _ => false
        };
    }

    [Serializable]
    public struct GraphVariable { public string Name; public GraphAccess Access; public GraphValue Default; }

    [Serializable]
    public struct GraphBinding { public string Parent; public string Child; }

    [Serializable]
    public class GraphGuard
    {
        public enum Test { Always, Fact, Signal, Result, All, Any, Predicate, Compare }
        public Test Kind;
        public string Key;
        public bool Expected = true;
        public enum Relation { Equal, NotEqual, Less, LessOrEqual, Greater, GreaterOrEqual }
        public Relation Comparison;
        public GraphValue Operand;
        public GraphResult Result;
        [SerializeReference] public GraphGuard[] Terms = Array.Empty<GraphGuard>();
        internal GraphGuard Copy()
        {
            var copy = (GraphGuard)MemberwiseClone();
            copy.Terms = Array.ConvertAll(Terms, child => child.Copy());
            return copy;
        }
    }

    [Serializable]
    public struct GraphTransition { public int Target; [SerializeReference] public GraphGuard Guard; }

    [Serializable]
    public struct GraphConsideration
    {
        public string Input;
        public AnimationCurve Response;
        public float Weight;
    }

    [Serializable]
    public struct GraphFact
    {
        public string Key;
        public bool Value;
        public GraphValue TypedValue;
        public GraphValue Expected => TypedValue.Type == GraphType.Boolean ? GraphValue.From(Value) : TypedValue;
    }

    [Serializable]
    public sealed class GraphStep
    {
        public Hash128 Id;
        public GraphOp Op;
        public string Label;
        public string Key;
        public int[] Children = Array.Empty<int>();
        public StateCompletion Completion;
        public GraphTransition[] Transitions = Array.Empty<GraphTransition>();
        public KaijuGraph Graph;
        public GraphBinding[] Bindings = Array.Empty<GraphBinding>();
        [SerializeReference] public GraphGuard Guard;
        [SerializeReference] public GraphGuard Eligibility;
        public string Scorer;
        [SerializeReference] public GraphScore Score;
        public string EnterAction;
        public string ExitAction;
        public bool Reactive;
        public float Duration;
        public float Timeout;
        public float SwitchMargin;
        public GraphConsideration[] Considerations = Array.Empty<GraphConsideration>();
        public GraphFact[] Preconditions = Array.Empty<GraphFact>();
        public GraphFact[] Effects = Array.Empty<GraphFact>();
        public float BaseScore;
        public float Cost = 1;
        public int Retries;
        internal GraphStep Copy()
        {
            var copy = (GraphStep)MemberwiseClone();
            copy.Children = (int[])Children.Clone();
            copy.Transitions = Array.ConvertAll(Transitions, edge => new GraphTransition { Target = edge.Target, Guard = edge.Guard?.Copy() });
            copy.Bindings = (GraphBinding[])Bindings.Clone();
            copy.Effects = (GraphFact[])Effects.Clone();
            copy.Preconditions = (GraphFact[])Preconditions.Clone();
            copy.Guard = Guard?.Copy();
            copy.Eligibility = Eligibility?.Copy();
            copy.Score = Score?.Copy();
            copy.Considerations = Array.ConvertAll(Considerations, item =>
            {
                if (item.Response != null) item.Response = new AnimationCurve(item.Response.keys)
                    { preWrapMode = item.Response.preWrapMode, postWrapMode = item.Response.postWrapMode };
                return item;
            });
            return copy;
        }
    }

    /// <summary>Shared player asset compiled by the Kaiju Graph Toolkit importers.</summary>
    public sealed class KaijuGraph : ScriptableObject
    {
        [SerializeField] private GraphFamily family;
        [SerializeField] private int entry;
        [SerializeField] private Hash128 sourceId;
        public Hash128 SourceId => sourceId;
        [SerializeField] private GraphVariable[] variables;
        [SerializeField] private GraphStep[] steps;
        public GraphFamily Family => family;
        public int Entry => entry;
        private IReadOnlyList<GraphVariable> variableView;
        private Dictionary<string, int> slots;
        internal bool TrySlot(string name, out int index)
        {
            if (slots == null)
            {
                slots = new Dictionary<string, int>(variables.Length);
                for (int i = 0; i < variables.Length; i++) slots.Add(variables[i].Name, i);
            }
            return slots.TryGetValue(name, out index);
        }
        private void OnEnable() { slots = null; variableView = null; }
        public IReadOnlyList<GraphVariable> Variables => variableView ??= Array.AsReadOnly(variables);
        internal IReadOnlyList<GraphStep> Steps => steps;
        public int StepCount => steps.Length;
        public string NodeLabel(Hash128 id)
        {
            foreach (var step in steps)
                if (step.Id == id) return string.IsNullOrEmpty(step.Label) ? step.Op.ToString() : step.Label;
            return id.ToString();
        }
        public GraphStep InspectStep(int index) => steps[index].Copy();

        public static KaijuGraph Create(GraphFamily family, int entry, GraphVariable[] variables, GraphStep[] steps, Hash128 sourceId = default)
        {
            if (steps == null || (uint)entry >= (uint)steps.Length) throw new ArgumentOutOfRangeException(nameof(entry));
            var graph = CreateInstance<KaijuGraph>();
            graph.family = family;
            graph.sourceId = sourceId;
            graph.entry = entry;
            graph.variables = variables == null ? Array.Empty<GraphVariable>() : (GraphVariable[])variables.Clone();
            graph.steps = steps;
            try
            {
                GraphValidation.Validate(graph);
                graph.steps = Array.ConvertAll(steps, step => step.Copy());
                for (int i = 0; i < graph.steps.Length; i++)
                    if (!graph.steps[i].Id.isValid) graph.steps[i].Id = Hash128.Compute(i.ToString(System.Globalization.CultureInfo.InvariantCulture));
                return graph;
            }
            catch
            {
                if (Application.isPlaying) Destroy(graph); else DestroyImmediate(graph);
                throw;
            }
        }
    }
}
