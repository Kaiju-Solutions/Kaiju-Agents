# Developing Kaiju Agents

The embedded UPM package in `Packages/ca.kaijusolutions.agents` is the source of runtime, Editor, test and sample changes. Edit sample sources under `Samples~` and keep the corresponding imported sample under `Assets/Samples` usable. Preserve existing asset GUIDs and public MonoBehaviour entry points when migrating functionality.

The shared project targets Unity 6.7 beta. Test it and the Unity 7 alpha using the isolated projects created by `Test-UnityMatrix`. Run Editors sequentially. The package test assemblies exercise Editor commands and simulation in Play Mode and a built desktop player.

Keep Burst-compatible data and jobs in Runtime. Bridge UnityEngine physics, navigation and user callbacks on the main thread. Limit Editor APIs and Pipeline commands to the Editor assembly.

Edit this file for repository guidance and the package AGENTS.md for consumer guidance. Edit consumer skills under the package's Skills~/codex. Run Sync-AgentGuidance after edits. Tools/prepare.py --check verifies generated material. See DEVELOPER.md for commands.
