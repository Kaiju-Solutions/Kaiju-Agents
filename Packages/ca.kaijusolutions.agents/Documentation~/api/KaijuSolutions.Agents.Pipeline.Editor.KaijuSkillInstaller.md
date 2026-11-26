# KaijuSkillInstaller

~~~csharp
public static class KaijuSkillInstaller
~~~

[Package source](../../Editor/Pipeline/KaijuSkillInstaller.cs)

<a id="KaijuSolutions_Agents_Pipeline_Editor_KaijuSkillInstaller_Install"></a>

### Install

~~~csharp
public static string Install (string provider)
~~~

<a id="KaijuSolutions_Agents_Pipeline_Editor_KaijuSkillInstaller_InstallSkills"></a>

### InstallSkills

~~~csharp
public static object InstallSkills ([CliArg("provider", "codex, claude, gemini or qwen")] string provider, [CliArg("check", "Preview file status without writing")] bool check = false, [CliArg("force", "Replace locally modified skill files")] bool force = false)
~~~
