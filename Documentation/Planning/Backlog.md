# Backlog

> **TODO** — seeded only with the concrete items known at creation time.

Items move top-to-bottom: **Ready** → **In progress** → **Done**. An item is
*Ready* only when someone other than its author could pick it up and finish it
without asking a question.

## Ready

| ID | Item | Requirement | Notes |
| --- | --- | --- | --- |
| BL-001 | Fill in `Product/Product-Overview.md` | — | Blocks requirements work; nothing else can be prioritised until scope is written down. |
| BL-002 | Author the first functional requirements in `Product/Requirements.md` | — | Depends on BL-001. |
| BL-003 | Add the first buildable project to `Curl.slnx` | — | Also clears the `NU1503` restore warning on the solution. |

## In progress

| ID | Item | Requirement | Notes |
| --- | --- | --- | --- |
| — | — | — | — |

## Done

| ID | Item | Completed | Notes |
| --- | --- | --- | --- |
| BL-000 | Create `Curl.slnx` and the `Documentation` shared project | 2026-09-25 | ADR-0001. |

## Icebox

Ideas kept on record without commitment. Nothing here is scheduled, and an item
sitting here for two reviews running should be deleted rather than nursed.

| ID | Item | Why not now |
| --- | --- | --- |
| IB-001 | Harden `hrdrClaudeNative.cmd`: verify the `npm install -g @anthropic-ai/claude-code` exit code, and quote the PowerShell `--cwd` / `--label` arguments against paths containing `'` | Known minor gaps, no current impact — the script works on the supported paths. |
