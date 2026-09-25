# Roadmap

> **TODO** — no milestones have been set. The phases below are placeholders, and
> the dates are deliberately absent rather than guessed.

Ordered by dependency, not by calendar. A milestone is done when its exit
criteria are met, and each milestone cites the requirement IDs it delivers.

## Milestone 0 — Foundations

Repository, solution and documentation structure.

- **Status:** In progress
- **Delivers:** `Curl.slnx`, `Documentation` shared project, bootstrap scripts
- **Exit criteria:** solution opens cleanly in Visual Studio and builds from the
  `dotnet` CLI; documentation structure agreed
- **Done:** `.slnx` solution and `Documentation.shproj` created and verified
  (2026-09-25) — see `Decisions/ADR-0001-adopt-slnx-solution-format.md`
- **Outstanding:** no buildable project exists yet, so `dotnet build Curl.slnx`
  emits `NU1503 Unable to find a project to restore!`. This clears itself when the
  first real project is added to the solution.

## Milestone 1 — > **TODO**

- **Status:** Not started
- **Delivers:** > **TODO** (requirement IDs)
- **Exit criteria:** > **TODO**

## Later / unscheduled

Work that is agreed in principle but not yet sequenced.
