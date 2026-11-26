# Developing and testing Kaiju Agents

Install Python 3.11+ and the manual renderer with `python -m pip install -r Tools/requirements.txt`. On macOS and Linux use python3. Each root helper has Bash and PowerShell entry points and forwards arguments to the same Python implementation.

| Helper | Purpose |
| --- | --- |
| Sync-AgentGuidance | Copy repository instructions and packaged provider skills from their canonical sources. |
| Check-CSharpStyle | Check C# indentation and directive placement, with optional --fix for the specified paths. |
| Convert-DocumentationApiToMarkdown | Regenerate the Markdown scripting reference from the package sources. |
| Build-Documentation | Render the Markdown and HTML manual, public C# reference and illustrations into the package's Documentation~ directory. |
| Prepare-Package | Refresh both generated deliverables. Pass --check to verify them without writing. |
| Test-DocumentationLinks | Validate every local file and image link in the offline HTML. |
| Test-LocalSession | Run Edit Mode and Play Mode tests through Pipeline in an open Editor. |
| Test-LocalReliable | Run the same tests through the official CLI in batch mode with the project closed. |
| Test-UnityMatrixCache | Verify Library cache isolation by checkout, Editor version and integration profile. |
| Test-UnityMatrixExecution | Check stage order and the isolation of test project manifests. |
| Test-UnityMatrixResults | Read the saved NUnit reports and build log for each requested stage. |
| Test-UnityMatrixAutomation | Exercise empty and failed result reports, mutual exclusion and graceful stopping. |
| Stop-UnityMatrix | Request a graceful stop before the matrix starts its next Editor stage. |
| Test-PackageInstall | Publish to a temporary Git remote and verify the tagged package in clean consumer projects. |
| Test-SteeringPerformance | Measure serial standalone-player ground, mixed and flight workloads on each supported Editor. |
| Test-UnityMatrix | Run package Edit Mode and Play Mode tests, build and run a desktop test player, then export the enabled sample scenes as a normal standalone player. |

Run `./Test-UnityMatrix.ps1` on Windows or `bash Test-UnityMatrix.sh` on Linux or macOS. Install the host standalone player build module for each Editor and activate a Unity license on the machine. The default matrix uses 6000.7.0b10 and 7000.0.0a21. Override with --versions followed by exact versions, or --stages EditMode PlayMode to select specific stages. Set UNITY_HUB_EDITORS or pass --hub for a custom Hub Editor directory.

The matrix copies the workspace to a temporary project for each version and aligns its built-in packages with the Editor. It closes the batch-mode Editor before starting the standalone tests. The player runs without graphics or an Editor connection and writes its NUnit report directly to disk. Find the report and separate build and runtime logs under `TestResults/<version>/`. Local runs use the installed Editors and the current account’s Unity license. Complete Editor terms acceptance once per version under that account.

### GitHub Actions validation

Open **Actions → Validate Kaiju Agents → Run workflow**. Both choices run the same two Editor versions and integration profiles, one at a time. Validation, documentation and release share a queue across branches. [GitHub workflow concurrency](https://docs.github.com/en/actions/how-tos/write-workflows/choose-when-workflows-run/control-workflow-concurrency)

- **github-hosted** (default) provisions one Editor per standard Ubuntu 24.04 runner. Configure the Actions secret `UNITY_LICENSE_SERIAL` with a serial eligible for unattended activation. Dispatching this option installs the Editor and accepts its software terms on the temporary runner. The job returns the activated seat during cleanup. Standard runners are free for public repositories. Private repositories use the account’s included minutes and billing settings. [GitHub-hosted runner reference](https://docs.github.com/en/actions/reference/runners/github-hosted-runners)
- **self-hosted** uses an available runner labeled `self-hosted`, `Windows` and `X64`. Install both Editors and their Windows standalone support, then activate Unity and accept each Editor’s terms under the runner service account. Set `UNITY_HUB_EDITORS` on the runner for a custom install location. The job uses that existing license. GitHub queues the job if the selected runner is offline.

For interactive development open the project in the 6.7 Editor and use the [Pipeline command guide](Documentation/manual/pipeline.md). Edit offline content under Documentation/manual. Package releases include the generated files. The online scripting reference uses the existing DocFX workflow.

The minimal profile omits ML-Agents from the template manifest to exercise a consumer installation. Run it with --profile minimal.

Pass --reuse-cache to Test-UnityMatrix to keep Unity’s generated Library in a stable project directory under the system temporary directory. Each run refreshes the source files and project settings. Keeping the project path stable allows Unity to reuse Bee build graphs that contain absolute paths.

### Steering performance

Run `python Tools/Benchmarks/steering.py` for a headless standalone-player comparison on both supported Editor lines. Use `--baseline --source <pre-flight-checkout>` for a ground-only reference with the same test harness. The source checkout must have the Kaiju Entities simulation and desktop test-player support. Use the same machine, build backend and Editor versions for both runs. `--full-matrix` also exercises the Editor suites and sample builds.

The harness launches the built player three times per Editor. Each player warms an isolated ECS world, then advances 8,192 agents for five rounds of 1,024 fixed steps. It measures ground-only, 50/50 ground/flight, and flight-only populations. Each round records step wall time, the main-thread wait for job completion, whole-process CPU time, managed bytes allocated on the invoking thread, and occupied agent chunks. The harness times NavMesh path queries and physics sphere casts separately. Rendering and GameObject callbacks are outside the steering measurement. Reports and raw player logs are under `TestResults/steering-benchmark/{baseline,candidate}/<run-id>/<editor>/`. Run `python Tools/Benchmarks/report.py` to compare the medians and launch ranges. A nonzero managed allocation during a warmed player round fails the benchmark. GitHub Actions can include the benchmark with the **performance** dispatch option.

For the initial flight implementation, before the subsequent crowd and job-scheduling changes, the median fixed-step times on a Windows x64 machine with a Ryzen 5 3600 in microseconds were as follows. Parentheses show the range of independent launch medians.

| Editor | Original ground | Updated ground | Half ground, half flight | Flight only |
|---|---:|---:|---:|---:|
| 6000.7.0b10 | 46.3 (45.5–47.0) | 46.0 (45.9–46.7) | 78.2 (77.1–78.8) | 61.2 (59.5–61.5) |
| 7000.0.0a21 | 59.2 (57.3–59.9) | 47.5 (42.8–53.8) | 97.8 (90.7–110.3) | 74.7 (73.4–81.7) |

The ground-only median stayed within the baseline range on 6.7 and fell below it on 7. Mixed populations schedule both steering and translation job sets. They had the highest elapsed time on this machine. All configurations used 64 occupied chunks and allocated zero managed bytes on the invoking thread during measured rounds. Steering payload per agent was 24 bytes for ground and 32 bytes for flight.

### Auditing and publishing 2.0.0

Pull requests run package checks without opening an Editor. Dispatch **Publish validated package** at the intended source commit. It runs both supported Editors serially, publishes the package tree at the release branch and immutable version tag in one Git push, installs the tagged Git URL in a clean consumer, then writes release notes. A retry accepts an existing tag only if its tree matches. The version comes from package.json.

Use `--reference --source <checkout>` for a flight-capable benchmark comparison. Report selection defaults to the latest completed run covering all requested Editors for each role. Pin specific runs with `--baseline-run` and `--candidate-run`. The report verifies every log against its run manifest and prints the measured source revision. A dirty or unversioned checkout is identified by its content digest.

Hybrid fixtures run 200 agents with 0%, 10%, and 100% GameObject bridges. They toggle vision and utility brains independently and compare grid and full-registry sensing. The report includes wall time, explicit job-completion time, simulation-thread allocations, temporary native bridge-array payload, net Unity allocator change across a round, and per-step vision candidates and casts. The native net figure includes frees. It cannot measure cumulative allocation traffic.

Rehearse publication locally with `python Tools/smoke_install.py --local-release --version 6000.7.0b10 7000.0.0a21`. This uses a temporary Git remote and package cache, exercises the same tagged install URL inside two clean projects, and checks command discovery and read-only skill preview. Supply `--url` in place of `--local-release` to verify a published tag.

### 2.0.0 audit measurements

These standalone measurements use the same Windows x64 Ryzen 5 3600, three independent player launches per Editor, and the flight-capable source from immediately before the audit as the reference. The following values are median microseconds per fixed step for 8,192 ECS agents.

| Editor | Ground before / after | Half ground, half flight before / after | Flight before / after |
|---|---:|---:|---:|
| 6000.7.0b10 | 46.4 / 46.9 | 78.0 / 73.2 | 59.9 / 60.4 |
| 7000.0.0a21 | 46.1 / 41.6 | 87.6 / 84.4 | 76.3 / 68.3 |

Independent velocity and sensing jobs share the pre-movement transform snapshot. Translation waits for all readers. The mixed workload median improved on both Editors. On 6.7, ground-only launch ranges overlapped (45.2�46.6 �s before and 46.0�48.0 �s after). Unity 7 mixed-population launch ranges also overlapped.

For 200 GameObject-backed agents with vision and a utility brain each, the median step elapsed time with full-registry sensing was 5.56 ms on 6.7 and 3.83 ms on 7. With the candidate grid, the corresponding times were 1.78 ms and 1.82 ms. Per step, the grid examined 7,424 candidates compared with 40,000 in a full scan. Both issued 1,424 sight casts and used 4,800 bytes of temporary bridge-array payload. All warmed standalone configurations allocated zero managed bytes on the simulation thread. Rendering and real gameplay callbacks can change these timings.
