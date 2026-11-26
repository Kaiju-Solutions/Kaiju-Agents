# ML-Agents

When [Unity ML-Agents](https://docs.unity3d.com/Packages/com.unity.ml-agents@latest "Unity ML-Agents") is installed in the project, [sensors](sensors.md "Sensors") and [actuators](actuators.md "Actuators") can be bound for use with [Unity ML-Agents](https://docs.unity3d.com/Packages/com.unity.ml-agents@latest "Unity ML-Agents"). To see what is provided, see the [scripting API](api/KaijuSolutions.Agents.Learning.md "Learning"). For further information, see the [Unity ML-Agents documentation](https://docs.unity3d.com/Packages/com.unity.ml-agents@latest "Unity ML-Agents").

The velocity sensor and control actuator use two channels by default, ordered X and Z. For a flying agent, enable **Include Climb** on either component that needs a third channel. Channel three carries Y. Set the observation and action dimensions for your model before training. See [Flying agents](movement.md) for flight setup.

To provide manual inputs for testing or behavioral cloning, extend the actuator and override its `Heuristic` method.

Use Kaiju Graph Policy to run inference or training from a visual decision graph. The Visual Decisions sample includes an identity ONNX model with one observation and one action. See the [policy lifecycle and action ownership example](behavior-graph.md).
