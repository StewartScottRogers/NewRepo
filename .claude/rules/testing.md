---
paths:
  - "*.UnitTests/**"
---
# Testing rules

- Framework: xUnit. Assertions: plain xUnit `Assert` unless the project already uses another library.
- Test project name: the production project with `.UnitTests` in place of
  `.UnitLibrary` (e.g. `Curl.Core.UnitLibrary` -> `Curl.Core.UnitTests`), in its own
  directory immediately under the repository root. Never under a `tests/` folder.
- One test class per production class: `<ClassName>Tests`.
- Test method names: `MethodName_Condition_ExpectedResult`.
- Arrange / Act / Assert sections separated by a blank line.
- Tests touching the network, file system, or a database get `[Trait("Category", "Integration")]`.
- Protocol tests must not need `Integration`: drive the handler through a fake
  `IConnection` replaying recorded bytes. Needing a live server means the seam is
  in the wrong place.
- No `Thread.Sleep`; use fakes for time (`TimeProvider`).
- A bug fix starts with a failing test that reproduces it.
