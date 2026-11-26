using Unity.Burst;
using Unity.Collections;
using Unity.Mathematics;

namespace KaijuSolutions.Agents.Graphs
{
    [BurstCompile]
    internal static class GraphUtilityKernel
    {
        [BurstCompile]
        internal static int Choose(in NativeArray<float> scores, int incumbent, float margin)
        {
            int winner = -1;
            float best = float.NegativeInfinity;
            if (incumbent >= 0 && math.isfinite(scores[incumbent]))
            {
                winner = incumbent;
                best = scores[incumbent] + margin;
            }
            for (int i = 0; i < scores.Length; i++)
            {
                float score = scores[i];
                if (!math.isfinite(score) || score <= best) continue;
                winner = i;
                best = score;
            }
            return winner;
        }
    }

    internal readonly struct GraphUtilityLayout
    {
        internal readonly bool Constant;
        internal readonly int Winner;
        internal GraphUtilityLayout(KaijuGraph graph, GraphStep selector)
        {
            Constant = true;
            Winner = -1;
            float best = float.NegativeInfinity;
            for (int i = 0; i < selector.Children.Length; i++)
            {
                var step = graph.Steps[selector.Children[i]];
                if (step.Considerations.Length != 0 || step.Score != null || step.Eligibility != null || !string.IsNullOrEmpty(step.Scorer))
                { Constant = false; return; }
                if (step.BaseScore > best) { best = step.BaseScore; Winner = i; }
            }
        }
    }
}
