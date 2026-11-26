using System;
using System.Linq;
using Newtonsoft.Json.Linq;
using Unity.Pipeline.Commands;
using UnityEngine;

public static class ConsumerSmoke
{
    public static void Verify()
    {
        var commands = CommandRegistry.DiscoverCommands().Where(command => command.Group == "kaiju-agents")
            .ToDictionary(command => command.Name);
        var route = commands["check-route"].Method.Invoke(null, new object[] { "{\"start\":{\"x\":10000},\"goal\":{\"x\":10001}}" });
        var data = JObject.FromObject(route);
        const string graph = "Assets/ConsumerSmoke.kaijugraph";
        var create = new JObject { ["path"] = graph, ["family"] = "Htn" };
        commands["create-graph"].Method.Invoke(null, new object[] { create.ToString() });
        commands["compile-graph"].Method.Invoke(null, new object[] { graph });
        commands["validate-graph"].Method.Invoke(null, new object[] { graph });
        var scenario = commands["run-graph"].Method.Invoke(null, new object[] {
            new JObject { ["path"] = graph, ["ticks"] = 8 }.ToString() });
        var trace = JObject.FromObject(scenario);
        if ((string)trace["result"] != "Succeeded" || !trace["trace"].Any())
            throw new InvalidOperationException("Installed graph did not execute with a trace");
        if (!commands.ContainsKey("trace-agent"))
            throw new InvalidOperationException("Graph tooling commands were not discovered");
        if ((string)data["status"] != "UnmappedStart" || (int)data["cornerCount"] != 0)
            throw new InvalidOperationException("Unexpected check-route result in empty consumer.");
        var preview = commands["install-skills"].Method.Invoke(null, new object[] { "codex", true, false });
        var files = JArray.FromObject(preview);
        if (files.Count == 0 || files.Any(file => (string)file["status"] != "missing"))
            throw new InvalidOperationException("Expected an install preview for a new project.");
        if (System.IO.Directory.Exists(System.IO.Path.Combine(Application.dataPath, "..", ".agents", "skills")))
            throw new InvalidOperationException("Preview wrote consumer files.");
        Debug.Log("KAIJU_CONSUMER_VERIFIED");
    }
}
