using System;
using System.Collections.Generic;
using KaijuSolutions.Agents.Graphs;
using Unity.GraphToolkit.Editor;
using UnityEngine;

namespace KaijuSolutions.Agents.Editor.Graphs
{
    [Serializable, Node("Kaiju/Utility AI")]
    internal sealed class ConsiderationNode : Node
    {
        protected override void OnDefineOptions(IOptionDefinitionContext context)
        {
            context.AddOption<ScoreOperation>("Operation").Build();
            context.AddOption<string>("Variable").Build();
            context.AddOption<float>("Value").Build();
            context.AddOption<int>("Integer").Build();
            context.AddOption<bool>("Invert or greater").Build();
            context.AddOption<AnimationCurve>("Curve").Build();
            context.AddOption<int>("Terms").WithDefaultValue(0).Delayed().Build();
        }
        protected override void OnDefinePorts(IPortDefinitionContext context)
        {
            context.AddOutputPort<float>("Score").Build();
            int count = Mathf.Clamp(Read<int>("Terms"), 0, 256);
            for (int i = 0; i < count; i++) context.AddInputPort<float>("Term " + (i + 1)).Build();
        }
        private T Read<T>(string key)
        {
            var option = GetNodeOptionByName(key);
            return option != null && option.TryGetValue<T>(out var value) ? value : default;
        }
        internal GraphScore Compile(HashSet<ConsiderationNode> ancestors)
        {
            if (!ancestors.Add(this)) throw new FormatException("Cyclic score expression");
            int count = Read<int>("Terms");
            if (count < 0 || count > 256) throw new FormatException("A consideration supports 0 to 256 terms");
            var score = new GraphScore { Operation = Read<ScoreOperation>("Operation"), Key = Read<string>("Variable"),
                Value = Read<float>("Value"), Integer = Read<int>("Integer"), Flag = Read<bool>("Invert or greater"),
                Curve = Read<AnimationCurve>("Curve"), Children = new GraphScore[count] };
            for (int i = 0; i < score.Children.Length; i++)
            {
                var term = GetInputPortByName("Term " + (i + 1)).FirstConnectedPort?.GetNode() as ConsiderationNode;
                if (term == null) throw new FormatException($"Connect consideration term {i + 1}");
                score.Children[i] = term.Compile(ancestors);
            }
            ancestors.Remove(this);
            return score;
        }
    }
}
