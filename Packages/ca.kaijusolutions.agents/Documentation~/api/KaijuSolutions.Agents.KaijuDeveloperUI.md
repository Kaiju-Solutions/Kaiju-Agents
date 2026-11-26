# KaijuDeveloperUI

Helpful developer UI. This displays buttons to select cameras on the left side and buttons to select scenes on the right side.

~~~csharp
public class KaijuDeveloperUI : KaijuGlobalController
~~~

[Package source](../../Runtime/KaijuDeveloperUI.cs)

<a id="KaijuSolutions_Agents_KaijuDeveloperUI_Width"></a>

### Width

~~~csharp
public float Width { get; set; }
~~~

Button widths.

<a id="KaijuSolutions_Agents_KaijuDeveloperUI_dynamicCameras"></a>

### dynamicCameras

~~~csharp
public bool dynamicCameras
~~~

If there are any dynamically-spawned cameras in the scene. This will enable a button to collect cameras at runtime.

<a id="KaijuSolutions_Agents_KaijuDeveloperUI_ToString"></a>

### ToString

~~~csharp
public override string ToString ()
~~~

Get a description of the object.
