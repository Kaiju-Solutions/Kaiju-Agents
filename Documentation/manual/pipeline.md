# Unity CLI and Pipeline

Open the project in Unity 6.7 or Unity 7 with com.unity.pipeline installed. Run these commands from the project root.

~~~sh
unity status
unity command --query kaiju-agents
unity command kaiju-agents place-floor --options '{"name":"Training Floor","scale":20,"outerWalls":false}'
unity command kaiju-agents create-agent-prefab --options '{"path":"Assets/Scout.prefab","type":"TRANSFORM"}'
unity command kaiju-agents place-agent --options '{"path":"Assets/Scout.prefab","position":{"x":2,"y":3}}'
unity command kaiju-agents place-navmesh --options '{"build":true}'
~~~

Position uses X and Z on the ground plane. The second JSON coordinate is named y. Agent types include TRANSFORM, CHARACTER, RIGIDBODY and NAVIGATION. Use place-wall to add a carving obstacle, and bake-navigation to rebuild active NavMesh surfaces. Save your scene after placement. Use the CLI's --project-path option to target a specific open project.

For project-local AI guidance run `unity command kaiju-agents install-skills --provider codex` or choose a provider under Tools > Kaiju Solutions > Agents > Install Agent Skills. Claude, Gemini, and Qwen have corresponding provider names in lowercase. Re-run after upgrading to refresh the package-owned skill. Your project's other skills and root instructions are preserved.

Use `unity command --query test` and `unity command --query console` to discover the test and diagnostics commands available from the installed Pipeline.

Use `worldPosition` for an explicit XYZ position with place-agent, place-floor, or place-wall. For walls, Y is the base elevation. Outer walls inherit their floor's elevation. Supply only one position convention per command.

```sh
unity command kaiju-agents place-floor --options '{"name":"Upper floor","worldPosition":{"x":0,"y":4,"z":0},"scale":8}'
unity command kaiju-agents check-route --options '{"start":{"x":0,"y":0,"z":0},"goal":{"x":0,"y":4,"z":0},"snapDistance":0.5}'
unity command kaiju-agents install-skills --provider codex --check true
```

Bake the surfaces and link the floors before checking connectivity. The read-only route command reports status, mappedEndpoint, and cornerCount. A skill preview reports each file as missing, current, update, or modified. Installation preserves locally modified files by default. Use `--force true` to explicitly replace them.


## Decision graphs

Create an HTN template from either shell with the JSON options for create-graph. Validate it with `unity command kaiju-agents validate-graph --path Assets/Rescue.kaijugraph`. To reimport and validate, use compile-graph with the same path. A state machine uses the .kaijufsm extension.

For a headless scenario, run-graph accepts path, ticks, delta, typed inputs, and signals keyed by tick. Use trace-agent to capture decisions on a live agent with its own C# and ML providers in Play Mode. The [visual graph guide](behavior-graph.md) describes port bindings and status values.

~~~sh
unity command kaiju-agents create-graph --options '{"path":"Assets/Tasks.kaijugraph","family":"Htn"}'
unity command kaiju-agents create-graph --options '{"path":"Assets/Mission.kaijufsm","family":"StateMachine","child":"Assets/Tasks.kaijugraph"}'
unity command kaiju-agents compile-graph --path Assets/Mission.kaijufsm
unity command kaiju-agents run-graph --options '{"path":"Assets/Mission.kaijufsm","ticks":16}' --format json
~~~

During Play Mode, select an agent by its GameObject hierarchy path. Save its trace as JSON in the working directory.

~~~sh
unity command kaiju-agents trace-agent --options '{"operation":"start","path":"/Scout","ticks":120}'
unity command kaiju-agents trace-agent --options '{"operation":"read"}' --format json > scout-trace.json
~~~
