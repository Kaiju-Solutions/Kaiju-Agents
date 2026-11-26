using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
using UnityEditor;

namespace KaijuSolutions.Agents.Editor.Graphs
{
    internal static class GraphDependencies
    {
        private static readonly Regex Pointer = new(@"\{fileID:\s*-?\d+,\s*guid:\s*([a-fA-F0-9]{32}),\s*type:\s*\d+\}");

        // A child runtime asset may not exist yet on a clean import. Declare serialized PPtr
        // dependencies before Unity loads the Graph Toolkit model and resolves its object fields.
        internal static string[] Gather(string path)
        {
            var dependencies = new HashSet<string>();
            using var source = File.OpenText(path);
            if (source.ReadLine() != "%YAML 1.1") return System.Array.Empty<string>();
            while (source.ReadLine() is string line)
            {
                foreach (Match match in Pointer.Matches(line))
                {
                    string asset = AssetDatabase.GUIDToAssetPath(match.Groups[1].Value);
                    if (asset == path) continue;
                    string extension = Path.GetExtension(asset);
                    if (extension == "." + KaijuVisualGraph.Extension || extension == "." + KaijuStateMachine.Extension)
                        dependencies.Add(asset);
                }
            }
            var sorted = new List<string>(dependencies);
            sorted.Sort(System.StringComparer.Ordinal);
            return sorted.ToArray();
        }
    }
}
