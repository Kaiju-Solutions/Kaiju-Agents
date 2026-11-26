using KaijuSolutions.Agents.Pipeline.Editor;
using NUnit.Framework;
using UnityEngine;

namespace KaijuSolutions.Agents.Tests
{
    public class PipelineTests
    {
        [Test]
        public void PrefabCommandRejectsTraversalAndUnknownAgentTypes()
        {
            Assert.Throws<System.ArgumentException>(() => KaijuCliCreateAgentPrefab.Run("{\"path\":\"../Outside.prefab\"}"));
            Assert.Throws<System.ArgumentException>(() => KaijuCliCreateAgentPrefab.Run("{\"path\":\"Assets/Invalid.prefab\",\"type\":\"UNKNOWN\"}"));
        }

        [Test]
        public void SpatialCommandsUseWorldHeight()
        {
            const string name = "Audit elevated floor";
            try
            {
                KaijuCliPlaceFloor.Run("{\"name\":\"Audit elevated floor\",\"worldPosition\":{\"x\":2,\"y\":5,\"z\":4},\"outerWalls\":false}");
                Assert.That(GameObject.Find(name).transform.position, Is.EqualTo(new Vector3(2, 5, 4)));
                Assert.That(KaijuCliBakeNavigation.CheckRoute("{\"start\":{\"x\":10000},\"goal\":{\"x\":10001}}").ToString(), Does.Contain("UnmappedStart"));
            }
            finally { Object.DestroyImmediate(GameObject.Find(name)); }
        }

        [Test]
        public void SkillPreviewAndUpgradePreserveLocalChanges()
        {
            string root = System.IO.Path.Combine(System.IO.Path.GetTempPath(), System.Guid.NewGuid().ToString("N"));
            string source = System.IO.Path.Combine(root, "codex");
            string target = System.IO.Path.Combine(root, "installed");
            string relative = "skill/references/example.txt";
            string from = System.IO.Path.Combine(source, relative);
            string output = System.IO.Path.Combine(target, relative);
            try
            {
                System.IO.Directory.CreateDirectory(System.IO.Path.GetDirectoryName(from));
                System.IO.File.WriteAllText(System.IO.Path.Combine(root, "files.json"), "[\"skill/references/example.txt\"]");
                System.IO.File.WriteAllText(from, "one");
                Assert.That(KaijuSkillInstaller.Sync(source, target, true, false)[0].ToString(), Does.Contain("missing"));
                Assert.That(System.IO.Directory.Exists(target), Is.False);
                KaijuSkillInstaller.Sync(source, target, false, false);
                Assert.That(KaijuSkillInstaller.Sync(source, target, true, false)[0].ToString(), Does.Contain("current"));
                System.IO.File.WriteAllText(from, "two");
                Assert.That(KaijuSkillInstaller.Sync(source, target, false, false)[0].ToString(), Does.Contain("update"));
                Assert.That(System.IO.File.ReadAllText(output), Is.EqualTo("two"));
                System.IO.File.WriteAllText(output, "custom");
                Assert.That(KaijuSkillInstaller.Sync(source, target, false, false)[0].ToString(), Does.Contain("modified"));
                Assert.That(System.IO.File.ReadAllText(output), Is.EqualTo("custom"));
                KaijuSkillInstaller.Sync(source, target, false, true);
                Assert.That(System.IO.File.ReadAllText(output), Is.EqualTo("two"));
            }
            finally { if (System.IO.Directory.Exists(root)) System.IO.Directory.Delete(root, true); }
        }

        [Test]
        public void FloorCommandUsesRequestedPositionAndSize()
        {
            const string name = "Kaiju CLI Test Floor";
            try
            {
                KaijuCliPlaceFloor.Run("{\"name\":\"Kaiju CLI Test Floor\",\"scale\":8,\"position\":{\"x\":2,\"y\":4},\"outerWalls\":false}");
                var floor = GameObject.Find(name);
                Assert.That(floor.transform.position, Is.EqualTo(new Vector3(2, 0, 4)));
                Assert.That(floor.transform.localScale.x, Is.EqualTo(8));
            }
            finally { Object.DestroyImmediate(GameObject.Find(name)); }
        }
    }
}
