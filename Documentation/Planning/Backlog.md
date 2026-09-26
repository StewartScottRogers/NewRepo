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
| BL-008 | Implement the `file` scheme: `FileProtocolHandler` behind `IFileSystem`, covering GET and PUT, `-r`/`--range` and `-C`/`--continue-at` as seeks, and the exit 37 (`CURLE_FILE_COULDNT_READ_FILE`) versus exit 23 (`CURLE_WRITE_ERROR`) split depending on which side the open failed on | — | See `Decisions/ADR-0002-ifilesystem-as-the-second-protocol-seam.md`. Handler takes `IFileSystem`, not `IConnection`; every test in `Curl.Protocol.File.UnitTests` runs against a fake, with no disk access. |
| BL-009 | Implement `PhysicalFileSystem` in `Curl.Core.UnitLibrary` (a `FileSystem\` folder), plus its one disk-touching test in `Curl.Core.UnitTests` | — | See `Decisions/ADR-0002-ifilesystem-as-the-second-protocol-seam.md`. Wraps `System.IO.File`/`FileInfo` behind the `IFileSystem` contract from `Curl.Protocol.Abstractions.UnitLibrary`. The test must carry `[TestCategory("Integration")]` so `dotnet test --filter "TestCategory!=Integration"` still excludes it. |
| BL-010 | Decide how to represent URLs `System.Uri` cannot round-trip: `file:///C:%2FWindows/win.ini`, `file://user:pass@localhost/x`, `c\|` drive letters, `file:////server/share` UNC folding, and literal `..` | — | See `Decisions/ADR-0003-itransfercontext-carries-transfer-options.md`, "Known limitation" section, measured against curl 8.21.0. Owned jointly by Core and HTTP (also affects `--path-as-is`); decide whether to replace, wrap or pre-parse ahead of `System.Uri`. |
| BL-011 | Implement `--create-file-mode` on POSIX: apply the given octal mode to files `-o`/`--create-dirs` creates | — | POSIX-only; a no-op on Windows. Depends on BL-009 (`PhysicalFileSystem`) exposing a create-mode parameter. |
| BL-012 | Handle `-T`/`--upload-file` to a URL ending in `/`: append the local file's basename to the URL before the transfer is dispatched | — | CLI-layer concern in `Curl.Cli.UnitLibrary`; resolved before `ITransferContext` is constructed, so no protocol handler sees an unresolved trailing-slash URL. |
| BL-013 | Implement `--max-filesize`, plus range parsing shared across protocols (`-r`/`--range` into the `ByteRange` type from ADR-0003), including exit 33 (`CURLE_RANGE_ERROR`) when the requested range cannot be satisfied | — | Core concern: parsing happens once, so every protocol handler receives an already-validated `ByteRange` through `ITransferContext.Range` rather than parsing it itself. Cites <https://curl.se/libcurl/c/libcurl-errors.html>, checked against curl 8.21.0. |

## In progress

| ID | Item | Requirement | Notes |
| --- | --- | --- | --- |
| — | — | — | — |

## Done

| ID | Item | Completed | Notes |
| --- | --- | --- | --- |
| BL-000 | Create `Curl.slnx` and the `Documentation` shared project | 2026-09-25 | ADR-0001. |
| BL-001 | Fill in `Product/Product-Overview.md` | 2026-09-25 | Researched against curl 8.21.0: 29 schemes, 274 options, 76 `--write-out` variables, exit codes 0–101, 2,126 upstream test cases. |
| BL-006 | Record ADR-0002: `IFileSystem`, not `IConnection`, as the seam for the `file` scheme | 2026-09-25 | Also amends `Curl.Protocol.File.UnitLibrary/CLAUDE.md` and Rule 2 in `Product/Product-Overview.md`. |
| BL-007 | Record ADR-0003: extend `ITransferContext` with `ResumeFrom`, `Range`, `NoBody`, `TimeCondition` and `HeaderOutput` | 2026-09-25 | Records the shape another agent is implementing concurrently; files the `System.Uri` fidelity gap as BL-010 rather than deciding it here. |

## Icebox

Ideas kept on record without commitment. Nothing here is scheduled, and an item
sitting here for two reviews running should be deleted rather than nursed.

| ID | Item | Why not now |
| --- | --- | --- |
| IB-001 | Harden `hrdrClaudeNative.cmd`: verify the `npm install -g @anthropic-ai/claude-code` exit code, and quote the PowerShell `--cwd` / `--label` arguments against paths containing `'` | Known minor gaps, no current impact — the script works on the supported paths. |
