# Getting Started

To get started with Kaiju Agents, follow the [installation instructions](https://agents.kaijusolutions.ca/#installation "Installation Instructions") or use the [template project](https://agents.kaijusolutions.ca/#template-project "Template Project").

## Install the package

Use Unity 6.7 beta or Unity 7 alpha. In Window > Package Management > Package Manager choose Install package from git URL and enter `https://github.com/Kaiju-Solutions/Kaiju-Agents.git#release`. Git must be installed. The package brings in Entities, Burst, navigation and Unity Pipeline. Unity Graph Toolkit supplies visual decision authoring. ML-Agents is optional.

Open the [simulation guide](manager.md) for a minimal entity-only agent or add a Kaiju Transform Agent from the GameObject menu. Use the [CLI guide](pipeline.md) for scene creation and project-local skill installation.

## Recommendations

To make your workflow more convenient, it is recommended to set the [game view](https://docs.unity3d.com/Manual/GameView.html "Game View") to `Play Unfocused`. This setting can be found towards the center-right of the [game view](https://docs.unity3d.com/Manual/GameView.html "Game View"). This is recommended as agent visualizations are only shown in the [scene view](https://docs.unity3d.com/Manual/UsingTheSceneView.html "Scene View"), and either of the other two modes in the [game view](https://docs.unity3d.com/Manual/GameView.html "Game View") can result in having your [scene view](https://docs.unity3d.com/Manual/UsingTheSceneView.html "Scene View") minimized depending on your editor layout.

## Samples

If this is your first time using Kaiju Agents, it is recommended you explore the provided [samples](samples-and-exercises.md "Samples and Exercises"). See the [samples documentation](samples-and-exercises.md "Samples") for instructions on importing them to your project. If you downloaded the [template project](https://agents.kaijusolutions.ca/#template-project "Template Project"), these will already been in the assets folder.

## Next Steps

To add your first agent into a scene, right click in the [hierarchy window](https://docs.unity3d.com/Manual/Hierarchy.html "Hierarchy Window") and go to `Kaiju Solutions > Agents` and click any of the options, with the `Kaiju Transform Agent` being the most basic. You can also access this creation process from the top menu by going to either `GameObject` or `Tools` and following the same steps. To learn how the agent works and how you can control it, head to the [components documentation](components.md "Components").

## Exercises

Once you are familiar with the various [components](components.md "Components") provided by Kaiju Agents, for practice you can try completing [several exercises](samples-and-exercises.md "Exercises"). Each [exercise](samples-and-exercises.md "Exercises") is more complicated than the last, providing an efficient learning experience for Kaiju Agents.

## Exporting

Code releated to visualizations only works in the Unity editor, and hence related code is stripped if you export a build. All properties and methods in the [scripting API](api/KaijuSolutions.Agents.md "Scripting API") which can only be run in the editor are prefixed with `Editor`. If you are writing any code accessing their editor-only properties or methods, you will need to exclude that code from buids. This can be done in two ways:

1. If the entire script is not needed for your build, simply nest the script under any folder named `Editor`.
2. If the script is needed in your build, you need to use [preprocessor directives](https://docs.unity3d.com/Manual/platform-dependent-compilation.html "Unity Conditional Compilation") to wrap the editor-only code.