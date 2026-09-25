---
paths:
  - "tests/**"
---
# Testing rules

- Framework: xUnit. Assertions: plain xUnit `Assert` unless the project already uses another library.
- Test project name: `<ProductionProject>.Tests`, placed under `tests/`.
- One test class per production class: `<ClassName>Tests`.
- Test method names: `MethodName_Condition_ExpectedResult`.
- Arrange / Act / Assert sections separated by a blank line.
- Tests touching the network, file system, or a database get `[Trait("Category", "Integration")]`.
- No `Thread.Sleep`; use fakes for time (`TimeProvider`).
- A bug fix starts with a failing test that reproduces it.
