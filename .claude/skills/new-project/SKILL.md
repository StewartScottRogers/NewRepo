---
name: new-project
description: Add a new C# project (and its matching test project) to the Curl solution following repository conventions. Use when asked to create, scaffold, or add a project, library, console app, or web app to the solution.
---
# Add a project to the Curl solution

1. Confirm the project name (`Curl.<Area>`) and template (`classlib`, `console`, `webapi`, `worker`). Ask if unclear.
2. If no solution file exists at the repository root, create one: `dotnet new sln --name Curl --format slnx`.
3. Create the project under `src/`:
   `dotnet new <template> --name Curl.<Area> --output src/Curl.<Area> --framework net10.0`
4. Create the matching test project under `tests/`:
   `dotnet new xunit --name Curl.<Area>.Tests --output tests/Curl.<Area>.Tests --framework net10.0`
5. Add both to the solution, using solution folders:
   `dotnet sln add src/Curl.<Area> --solution-folder src`
   `dotnet sln add tests/Curl.<Area>.Tests --solution-folder tests`
6. Reference production from test: `dotnet add tests/Curl.<Area>.Tests reference src/Curl.<Area>`
7. Strip any `Version` attributes and settings duplicated by `Directory.Build.props` / `Directory.Packages.props` (create those files at the root if they are missing).
8. Add `src/Curl.<Area>/CLAUDE.md` with a short purpose statement and any project-specific rules.
9. Run `dotnet build` and `dotnet test`; both must pass before finishing.
