using System;
using System.IO;
using System.Security.Cryptography;
using Newtonsoft.Json;
using System.Collections.Generic;
using Unity.Pipeline.Commands;
using UnityEditor;
using PackageInfo = UnityEditor.PackageManager.PackageInfo;
using UnityEngine;

[assembly: System.Runtime.CompilerServices.InternalsVisibleTo("ca.kaijusolutions.agents.tests.editor")]

namespace KaijuSolutions.Agents.Pipeline.Editor
{
    public static class KaijuSkillInstaller
    {
        private const string Menu = "Tools/Kaiju Solutions/Agents/Install Agent Skills/";

        [MenuItem(Menu + "Codex")] private static void Codex() => Debug.Log(Install("codex"));
        [MenuItem(Menu + "Claude")] private static void Claude() => Debug.Log(Install("claude"));
        [MenuItem(Menu + "Gemini")] private static void Gemini() => Debug.Log(Install("gemini"));
        [MenuItem(Menu + "Qwen")] private static void Qwen() => Debug.Log(Install("qwen"));

        public static string Install(string provider) => JsonConvert.SerializeObject(InstallSkills(provider));

        [CliCommand("kaiju-agents", "install-skills", "Install or preview the Kaiju Agents skill files")]
        public static object InstallSkills([CliArg("provider", "codex, claude, gemini or qwen")] string provider,
            [CliArg("check", "Preview file status without writing")] bool check = false,
            [CliArg("force", "Replace locally modified skill files")] bool force = false)
        {
            string directory = provider switch
            {
                "codex" => ".agents",
                "claude" => ".claude",
                "gemini" => ".gemini",
                "qwen" => ".qwen",
                _ => throw new ArgumentException("Choose codex, claude, gemini or qwen.")
            };
            string package = PackageInfo.FindForAssembly(typeof(KaijuSkillInstaller).Assembly).resolvedPath;
            string source = Path.Combine(package, "Skills~", provider);
            string target = Path.Combine(Directory.GetParent(Application.dataPath).FullName, directory, "skills");
            return Sync(source, target, check, force);
        }

        internal static List<object> Sync(string source, string target, bool check, bool force)
        {
            var files = JsonConvert.DeserializeObject<string[]>(File.ReadAllText(Path.Combine(source, "..", "files.json")));
            string ledger = Path.Combine(target, ".kaiju-agents-installed.json");
            var installed = File.Exists(ledger)
                ? JsonConvert.DeserializeObject<Dictionary<string, string>>(File.ReadAllText(ledger))
                : new Dictionary<string, string>();
            var result = new List<object>();
            foreach (string relative in files)
            {
                string destination = Path.GetFullPath(Path.Combine(target, relative));
                if (!destination.StartsWith(Path.GetFullPath(target) + Path.DirectorySeparatorChar, StringComparison.Ordinal))
                    throw new IOException("Invalid skill file path.");
                var bytes = File.ReadAllBytes(Path.Combine(source, relative));
                string desired = Hash(bytes);
                string actual = File.Exists(destination) ? Hash(File.ReadAllBytes(destination)) : null;
                string status = actual == null ? "missing" : actual == desired ? "current" :
                    installed.TryGetValue(relative, out string prior) && actual == prior ? "update" : "modified";
                bool write = !check && status != "current" && (status != "modified" || force);
                if (write)
                {
                    Directory.CreateDirectory(Path.GetDirectoryName(destination));
                    WriteFile(destination, bytes);
                }
                if (!check && (write || status == "current")) installed[relative] = desired;
                result.Add(new { file = relative, status, written = write });
            }
            if (!check)
            {
                Directory.CreateDirectory(target);
                WriteFile(ledger, System.Text.Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(installed)));
            }
            return result;
        }

        private static void WriteFile(string path, byte[] bytes)
        {
            string temp = path + "." + Guid.NewGuid().ToString("N") + ".tmp";
            try
            {
                File.WriteAllBytes(temp, bytes);
                if (File.Exists(path)) File.Replace(temp, path, null);
                else File.Move(temp, path);
            }
            finally { if (File.Exists(temp)) File.Delete(temp); }
        }

        private static string Hash(byte[] bytes)
        {
            using var sha = SHA256.Create();
            return Convert.ToBase64String(sha.ComputeHash(bytes));
        }
    }
}
