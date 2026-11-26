using System;
using KaijuSolutions.Agents.Graphs;
using Unity.GraphToolkit.Editor;
using UnityEditor;
using UnityEngine;

namespace KaijuSolutions.Agents.Editor.Graphs
{
    [Serializable, Graph(Extension)]
    internal class KaijuVisualGraph : Graph
    {
        public const string Extension = "kaijugraph";
        [MenuItem("Assets/Create/Kaiju Agents/Decision Graph")]
        private static void Create() => GraphDatabase.PromptInProjectBrowserToCreateNewAsset<KaijuVisualGraph>();
    }

    [Serializable, Node("Kaiju")]
    internal class EntryNode : Node
    {
        protected override void OnDefinePorts(IPortDefinitionContext context) =>
            context.AddOutputPort("Root").WithCapacity(PortCapacity.Single).Build();
    }

    [Serializable]
    internal abstract class TaskNode : Node
    {
        internal abstract GraphOp Operation { get; }
        private bool Composite => Operation is GraphOp.Sequence or GraphOp.Selector or GraphOp.Utility or GraphOp.Htn or GraphOp.Method or GraphOp.Goap;
        protected override void OnDefineOptions(IOptionDefinitionContext context)
        {
            if (Composite) context.AddOption<int>("Children").WithDefaultValue(2).Delayed().Build();
            if (Operation is GraphOp.Sequence or GraphOp.Selector) context.AddOption<bool>("Reactive").Build();
            if (Operation is GraphOp.Call)
            {
                context.AddOption<KaijuGraph>("Graph").Build();
                context.AddOption<string>("Bindings").WithTooltip("Comma-separated parent=child bindings").Build();
            }
            if (Operation is GraphOp.Action or GraphOp.Policy) context.AddOption<string>("Service").Build();
            if (Operation is GraphOp.Condition or GraphOp.Policy) context.AddOption<string>("Condition").WithTooltip("Boolean variable, !variable, @signal or ?predicate").Build();
            if (Operation is GraphOp.Utility or GraphOp.Wait or GraphOp.Policy) context.AddOption<float>("Seconds").Build();
            if (Operation is GraphOp.Utility) context.AddOption<float>("Switch margin").Build();
            if (Operation == GraphOp.Repeat) context.AddOption<int>("Iterations").WithTooltip("Zero repeats until interrupted").Build();
            if (Operation is GraphOp.Goap or GraphOp.Htn or GraphOp.Retry) context.AddOption<int>("Retries").Build();
            if (Operation is GraphOp.Action or GraphOp.Policy or GraphOp.Timeout) context.AddOption<float>("Timeout").Build();
            context.AddOption<string>("Eligible").WithTooltip("Optional condition for Utility AI selection").Build();
            context.AddOption<string>("Scorer").WithTooltip("Optional registered C# score").Build();
            context.AddOption<float>("Base score").Build();
            context.AddOption<float>("Cost").WithDefaultValue(1).Build();
            context.AddOption<string>("Preconditions").WithTooltip("Comma-separated Boolean facts, prefix false facts with !").Build();
            context.AddOption<string>("Effects").WithTooltip("Desired facts for a GOAP root, predicted effects for tasks").Build();
            context.AddOption<int>("Considerations").WithDefaultValue(0).Delayed().Build();
        }
        protected override void OnDefinePorts(IPortDefinitionContext context)
        {
            context.AddInputPort("In").Build();
            context.AddInputPort<float>("Score").Build();
            int count = Operation is GraphOp.Invert or GraphOp.Retry or GraphOp.Repeat or GraphOp.Timeout ? 1 : Read<int>("Children");
            for (int i = 0; i < Mathf.Clamp(count, 0, 256); i++)
                context.AddOutputPort("Child " + (i + 1)).WithCapacity(PortCapacity.Single).Build();
            int considerations = Mathf.Clamp(Read<int>("Considerations"), 0, 64);
            for (int i = 0; i < considerations; i++)
            {
                context.AddInputPort<string>("Input " + i).Build();
                context.AddInputPort<AnimationCurve>("Curve " + i).Build();
                context.AddInputPort<float>("Weight " + i).WithDefaultValue(1).Build();
            }
        }
        internal T Read<T>(string key)
        {
            var option = GetNodeOptionByName(key);
            return option != null && option.TryGetValue<T>(out var value) ? value : default;
        }
    }
    [Serializable, Node("Kaiju/Behavior Tree")]
    internal class SequenceNode : TaskNode { internal override GraphOp Operation => GraphOp.Sequence; }

    [Serializable, Node("Kaiju/Behavior Tree")]
    internal class SelectorNode : TaskNode { internal override GraphOp Operation => GraphOp.Selector; }

    [Serializable, Node("Kaiju/Behavior Tree")]
    internal class InvertNode : TaskNode { internal override GraphOp Operation => GraphOp.Invert; }

    [Serializable, Node("Kaiju/Tasks")]
    internal class ActionNode : TaskNode { internal override GraphOp Operation => GraphOp.Action; }

    [Serializable, Node("Kaiju/Tasks")]
    internal class CallNode : TaskNode { internal override GraphOp Operation => GraphOp.Call; }

    [Serializable, Node("Kaiju/Tasks")]
    internal class WaitNode : TaskNode { internal override GraphOp Operation => GraphOp.Wait; }

    [Serializable, Node("Kaiju/Tasks")]
    internal class ConditionNode : TaskNode { internal override GraphOp Operation => GraphOp.Condition; }

    [Serializable, Node("Kaiju/Tasks")]
    internal class SucceedNode : TaskNode { internal override GraphOp Operation => GraphOp.Succeed; }

    [Serializable, Node("Kaiju/Tasks")]
    internal class FailNode : TaskNode { internal override GraphOp Operation => GraphOp.Fail; }

    [Serializable, Node("Kaiju/Utility AI")]
    internal class UtilityNode : TaskNode { internal override GraphOp Operation => GraphOp.Utility; }

    [Serializable, Node("Kaiju/Planning")]
    internal class GoapNode : TaskNode { internal override GraphOp Operation => GraphOp.Goap; }

    [Serializable, Node("Kaiju/Planning")]
    internal class HtnNode : TaskNode { internal override GraphOp Operation => GraphOp.Htn; }

    [Serializable, Node("Kaiju/Planning")]
    internal class MethodNode : TaskNode { internal override GraphOp Operation => GraphOp.Method; }

    [Serializable, Node("Kaiju/Tasks")]
    internal class PolicyNode : TaskNode { internal override GraphOp Operation => GraphOp.Policy; }
    [Serializable, Node("Kaiju/Behavior Tree")]
    internal class TimeoutNode : TaskNode { internal override GraphOp Operation => GraphOp.Timeout; }
    [Serializable, Node("Kaiju/Behavior Tree")]
    internal class RepeatNode : TaskNode { internal override GraphOp Operation => GraphOp.Repeat; }
    [Serializable, Node("Kaiju/Behavior Tree")]
    internal class RetryNode : TaskNode { internal override GraphOp Operation => GraphOp.Retry; }
}
