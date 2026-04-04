#if COM_UNITY_BEHAVIOR
using System;
using KaijuSolutions.Agents.Behavior.Sensors;
using KaijuSolutions.Agents.Exercises.CTF;
using Unity.Behavior;
using Unity.Properties;

namespace KaijuSolutions.Agents.Behavior.Exercises.CTF
{
    /// <summary>
    /// Action to sense with an <see cref="AmmoVisionSensor"/> which could have multiple readings of <see cref="AmmoPickup"/>s.
    /// </summary>
    [Serializable]
    [GeneratePropertyBag]
    [NodeDescription(
        name: "Ammo Vision Sense",
        story: "See [observed] with ammo [sensor].",
        description: "Sense for any ammo pickups using an ammo vision sensor. If the sensor is not assigned, will try to find the first sensor of this type on of the first agent variable found.",
        category: "Kaiju Agents/Capture the Flag",
        id: "9e202450dff3a82616371d1145413777",
        icon: "Packages/ca.kaijusolutions.agents/Editor/Icon.png")
    ]
    public class AmmoVisionSensorAction : KaijuVisionSensorAction<AmmoVisionSensor, AmmoPickup> { }
}
#endif