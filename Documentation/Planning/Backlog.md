# Backlog

> **TODO** — seeded only with the concrete items known at creation time.

Items move top-to-bottom: **Ready** → **In progress** → **Done**. An item is
*Ready* only when someone other than its author could pick it up and finish it
without asking a question.

## Ready

| ID | Item | Requirement | Notes |
| --- | --- | --- | --- |
| BL-002 | Author the first functional requirements in `Product/Requirements.md` | — | Overview is done; requirements can now be derived from the 274-option compatibility surface. |
| BL-003 | Scaffold the Phase 1 projects (`Abstractions`, `Networking`, `Core`, `Cli`, `Output`, `Console`, `File`, `Http` + their `.UnitTests`) | — | Also clears the `NU1503` restore warning on the solution. |
| BL-004 | Decide the licence: keep GPL-3.0 or relicense to MIT/Apache-2.0 | — | Open question 1 in the overview. Blocks first public release. |
| BL-005 | Decide how curl's 2,126 upstream test cases are driven from .NET | — | Open question 3. Determines the conformance harness. |

## In progress

| ID | Item | Requirement | Notes |
| --- | --- | --- | --- |
| — | — | — | — |

## Done

| ID | Item | Completed | Notes |
| --- | --- | --- | --- |
| BL-000 | Create `Curl.slnx` and the `Documentation` shared project | 2026-09-25 | ADR-0001. |
| BL-001 | Fill in `Product/Product-Overview.md` | 2026-09-25 | Researched against curl 8.21.0: 29 schemes, 274 options, 76 `--write-out` variables, exit codes 0–101, 2,126 upstream test cases. |

## Icebox

Ideas kept on record without commitment. Nothing here is scheduled, and an item
sitting here for two reviews running should be deleted rather than nursed.

| ID | Item | Why not now |
| --- | --- | --- |
| IB-001 | Harden `hrdrClaudeNative.cmd`: verify the `npm install -g @anthropic-ai/claude-code` exit code, and quote the PowerShell `--cwd` / `--label` arguments against paths containing `'` | Known minor gaps, no current impact — the script works on the supported paths. |
