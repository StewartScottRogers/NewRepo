# ADR-0001 — Adopt the `.slnx` solution format and a shared project for documentation

- **Status:** Accepted
- **Date:** 2026-09-25

## Context

The repository had no solution file. It needed one, plus somewhere for product
documentation and planning material to live where it would actually be seen
during development rather than in a folder nobody opens.

Two format choices presented themselves. The legacy `.sln` format is universally
supported but is a GUID-heavy flat file that conflicts badly on merge. The `.slnx`
format is XML, roughly a third the size, and merges cleanly; it requires .NET SDK
9.0.200+ or Visual Studio 17.13+. The installed SDK is 10.0.401.

For the documentation container, a Visual Studio Shared Project (`.shproj` plus
`.projitems`) was requested. Shared projects were designed to share *compiled
source* between projects, not to hold documents, so the fit needed checking.

## Decision

Use `.slnx` for the solution, and a shared project named `Documentation` for the
product and planning material.

Two details follow from the decision and are load-bearing:

1. **Every `Microsoft.CodeSharing.*` import in `Documentation.shproj` is guarded
   with `Condition="Exists(...)"`.** Those `.props`/`.targets` ship with Visual
   Studio, not with the .NET SDK. Unguarded, the project fails to evaluate on any
   machine or build agent that has only the SDK — which is the case on the
   development machine this was authored on.

2. **`Documentation.projitems` globs recursively** (`**\*.md`, `**\*.puml`,
   `**\*.drawio`) rather than listing files. A hand-maintained list goes stale the
   first time someone adds a document outside Visual Studio.

## Consequences

Good:

- The solution file is human-readable and reviewable in a pull request.
- The documentation node appears in Solution Explorer and costs nothing at build
  time, because a shared project has no build output.
- New documents need no project file edit.

Costs and caveats:

- `.slnx` is a hard floor on tooling: SDK 9.0.200+ / VS 17.13+. Older toolchains
  cannot open the solution at all. Accepted because the repository is new and has
  no existing consumers.
- A shared project is not what Microsoft designed for documents. The practical
  effect is limited to cosmetics — Solution Explorer shows a shared-project icon
  and offers a "reference this project" gesture that is meaningless for Markdown.
  Nothing breaks. If that friction ever grates, a `Microsoft.Build.NoTargets`
  project or a plain solution folder are drop-in replacements.
- Until the solution contains a buildable project, `dotnet build Curl.slnx` emits
  `NU1503 Unable to find a project to restore!`. This is benign and clears itself
  when the first real project is added.

## Alternatives considered

- **Legacy `.sln`.** Rejected: nothing requires the older toolchain, and `.slnx`
  is strictly more pleasant to review and merge.
- **Solution folder holding the documents directly.** Simplest option and needs no
  project file, but a solution folder's contents are listed one file at a time in
  the solution, so the file list rots exactly as a hand-written `.projitems` would.
  Rejected for that reason, not on principle.
- **`Microsoft.Build.NoTargets` SDK project.** The technically cleanest fit: a real
  project that intentionally compiles nothing, needs no Visual Studio targets, and
  globs freely. Rejected only because a shared project was specifically asked for,
  and the guarded imports make the shared project behave correctly without VS. This
  remains the recommended migration if the shared project ever proves awkward.
