using System;
using UnityEngine;

namespace KaijuSolutions.Agents.Graphs
{
    public enum ScoreOperation { Constant, Boolean, Number, Integer, Curve, Add, Average, Subtract, Multiply, Divide, Max, Min }

    [Serializable]
    public sealed class GraphScore
    {
        public ScoreOperation Operation;
        public string Key;
        public float Value;
        public int Integer;
        public bool Flag;
        public AnimationCurve Curve;
        [SerializeReference] public GraphScore[] Children = Array.Empty<GraphScore>();
        internal GraphScore Copy()
        {
            var copy = (GraphScore)MemberwiseClone();
            copy.Children = Array.ConvertAll(Children, child => child.Copy());
            if (Curve != null) copy.Curve = new AnimationCurve(Curve.keys) { preWrapMode = Curve.preWrapMode, postWrapMode = Curve.postWrapMode };
            return copy;
        }

        internal float Evaluate(IReadOnlyGraphContext context)
        {
            switch (Operation)
            {
                case ScoreOperation.Constant: return Mathf.Clamp01(Value);
                case ScoreOperation.Boolean: return context.Get(Key).Boolean != Flag ? 1 : 0;
                case ScoreOperation.Curve: return Mathf.Clamp01(Curve.Evaluate(context.Get(Key).Number));
                case ScoreOperation.Number:
                    float number = context.Get(Key).Number;
                    return (Flag ? number >= Value : number <= Value) ? 1 : 0;
                case ScoreOperation.Integer:
                    int integer = context.Get(Key).Integer;
                    return (Flag ? integer >= Integer : integer <= Integer) ? 1 : 0;
            }
            if (Children.Length == 0) return 0;
            float result = Children[0].Evaluate(context);
            for (int i = 1; i < Children.Length; i++)
            {
                float value = Children[i].Evaluate(context);
                result = Operation switch { ScoreOperation.Average or ScoreOperation.Add => result + value,
                    ScoreOperation.Subtract => result - value, ScoreOperation.Multiply => result * value,
                    ScoreOperation.Divide => value == 0 ? result : result / value, ScoreOperation.Max => Mathf.Max(result, value),
                    ScoreOperation.Min => Mathf.Min(result, value), _ => throw new ArgumentOutOfRangeException() };
            }
            return Mathf.Clamp01(Operation == ScoreOperation.Average ? result / Children.Length : result);
        }
    }
}
