# Getting Started

To get started with Kaiju Agents, follow the [installation instructions](https://agents.kaijusolutions.ca/#installation "Installation Instructions") or use the [template project](https://agents.kaijusolutions.ca/#template-project "Template Project").

## Recommendations

To make your workflow more convenient, it is recommended to set the [game view](https://docs.unity3d.com/Manual/GameView.html "Game View") to `Play Unfocused`. This setting can be found towards the center-right of the [game view](https://docs.unity3d.com/Manual/GameView.html "Game View"). This is recommended as agent visualizations are only shown in the [scene view](https://docs.unity3d.com/Manual/UsingTheSceneView.html "Scene View"), and either of the other two modes in the [game view](https://docs.unity3d.com/Manual/GameView.html "Game View") can result in having your [scene view](https://docs.unity3d.com/Manual/UsingTheSceneView.html "Scene View") minimized depending on your editor layout.

If you wish to work with pathfinding and navigation, it is recommended you install the [AI navigation package](https://docs.unity3d.com/Packages/com.unity.ai.navigation@latest "AI Navigation") which allows for an easy component-based navigation mesh creation process. To check if it is installed in your project, from the top menu, go to `Window > Package Management > Package Manager`. Under the `Installed` tab, look for `AI Navigation` under `Packages - Unity`. If it is not installed, click on the `Unity Registry Tab`, select `AI Navigation`, and click `Install`.

## Samples

If this is your first time using Kaiju Agents, it is recommended you explore the provided [samples](https://agents.kaijusolutions.ca/manual/samples-and-exercises.html "Samples and Exercises"). See the [samples documentation](https://agents.kaijusolutions.ca/manual/samples-and-exercises.html "Samples") for instructions on importing them to your project. If you downloaded the [template project](https://agents.kaijusolutions.ca/#template-project "Template Project"), these will already been in the assets folder.

## Next Steps

To add your first agent into a scene, right click in the [hierarchy window](https://docs.unity3d.com/Manual/Hierarchy.html "Hierarchy Window") and go to `Kaiju Solutions > Agents` and click any of the options, with the `Kaiju Transform Agent` being the most basic. You can also access this creation process from the top menu by going to either `GameObject` or `Tools` and following the same steps. To learn how the agent works and how you can control it, head to the [components documentation](https://agents.kaijusolutions.ca/manual/components.html "Components").

## Exercises

Once you are familiar with the various [components](https://agents.kaijusolutions.ca/manual/components.html "Components") provided by Kaiju Agents, for practice you can try completing [several exercises](https://agents.kaijusolutions.ca/manual/samples-and-exercises.html "Exercises"). Each [exercise](https://agents.kaijusolutions.ca/manual/samples-and-exercises.html "Exercises") is more complicated than the last, providing an efficient learning experience for Kaiju Agents.

## Exporting

Code releated to visualizations only works in the Unity editor, and hence related code is stripped if you export a build. All properties and methods in the [scripting API](https://agents.kaijusolutions.ca/api/KaijuSolutions.Agents.html "Scripting API") which can only be run in the editor are prefixed with `Editor`. If you are writing any code accessing their editor-only properties or methods, you will need to exclude that code from buids. This can be done in two ways:

1. If the entire script is not needed for your build, simply nest the script under any folder named `Editor`.
2. If the script is needed in your build, you need to use [preprocessor directives](https://docs.unity3d.com/Manual/platform-dependent-compilation.html "Unity Conditional Compilation") to wrap the editor-only code.