# Curl — Solution Instructions for Claude Code

## Overview
Curl is a C# solution maintained in Microsoft Visual Studio.
Repository: https://github.com/StewartScottRogers/Curl

> TODO: Replace this line with one or two sentences describing what Curl does.

## Toolchain
- .NET Software Development Kit 10 (see `global.json` once added). Target framework: `net10.0` unless a project states otherwise.
- The solution file lives at the repository root (`Curl.slnx` preferred, `Curl.sln` acceptable).
- Shell is Windows. Use PowerShell or `cmd` syntax, backslash paths are fine.

## Build and test commands
- Build: `dotnet build`
- Test (fast, default): `dotnet test --filter "Category!=Integration"`
- Test (everything): `dotnet test`
- Format: `dotnet format`

Always build and run the fast tests before declaring a task finished.

## Repository layout
```
Curl/
├── Curl.slnx
├── src/        ← production projects, one folder per project
├── tests/      ← test projects, mirror names of src projects with .Tests suffix
├── data/       ← local runtime data (gitignored, never read or modify)
└── .claude/    ← Claude Code configuration (rules, skills, agents, hooks)
```
Each project folder may contain its own `CLAUDE.md` with project-specific rules; follow it when working in that folder.

## Solution-wide conventions
- Nullable reference types enabled, warnings treated as errors.
- File-scoped namespaces; namespace matches folder path.
- Central package management through `Directory.Packages.props`; never put a `Version` attribute on a `PackageReference` in a project file.
- Shared build settings go in `Directory.Build.props`, not individual project files.
- Async all the way; no `.Result` or `.Wait()`.
- Register new services with dependency injection; no static service locators.

## Things to never do
- Do not edit anything under `bin/`, `obj/`, `.vs/`, or `data/`.
- Do not hand-edit generated migration files.
- Do not add a NuGet package without stating why in your summary.
- Do not change `RunClaude.cmd` or `hrdrClaudeNative.cmd` unless asked.
