---
id: BL-002
title: Author the first functional requirements in Product/Requirements.md
priority: Normal
assignee: Claude
pipeline: docs
depends-on: []
requirement: none
created: 2026-09-25
completed:
---
# BL-002 — Author the first functional requirements in `Product/Requirements.md`

## Goal

`Documentation/Product/Requirements.md` holds the first numbered functional
requirements, derived from the compatibility surface in the product overview.

## Context

The overview is done (BL-001), so requirements can now be derived from its
274-option compatibility surface. `docs-writer` owns the file: one behaviour per
requirement, each naming the upstream curl option it mirrors.

## Acceptance criteria

- [ ] `Requirements.md` contains numbered requirements, one behaviour each, each
      naming the upstream curl option it mirrors and linking to curl.se.
- [ ] Every requirement states the curl version it was checked against.

## Notes

Migrated as written. The original item did not say which options "the first"
requirements cover. Before this is run, `task-planner` should narrow it, for example
to the options Phase 1 needs, or split it by option group.

## Log

- 2026-09-25: Migrated from Documentation/Planning/Backlog.md (Ready).
