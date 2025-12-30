using UnityEngine;

namespace KaijuSolutions.Agents.Sensors
{
    /// <summary>
    /// Vision sensor based on transforms, allowing it to see anything.
    /// </summary>
    [DefaultExecutionOrder(int.MinValue)]
#if UNITY_EDITOR
    [AddComponentMenu("Kaiju Solutions/Agents/Sensors/Kaiju Everything Vision Sensor", 5)]
    [Icon("Packages/com.kaijusolutions.agents/Editor/Icon.png")]
    [HelpURL("https://agents.kaijusolutions.ca/manual/getting-started.html")]
#endif
    public class KaijuEverythingVisionSensor : KaijuVisionSensor<Transform> { }
}