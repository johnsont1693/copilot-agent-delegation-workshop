# Copilot instructions

ASP.NET Core Razor Pages app (.NET 10), xUnit + FluentAssertions tests. C# 12, nullable enabled.

## Build and test

```
dotnet build ClinicalOpsLog.sln
dotnet test ClinicalOpsLog.sln
```

All tests must pass before opening a PR. No new test failures are acceptable.

## Architecture

- `src/ClinicalOpsLog/` — Razor Pages web app. Pages in `Pages/`, domain models in `Models/`, business logic in `Services/`.
- `tests/ClinicalOpsLog.Tests/` — unit tests. File names mirror source: `MessageInboxService.cs` → `MessageInboxServiceTests.cs`.
- No MVC controllers or Blazor. Do not add NuGet packages without listing them in your change plan first.

## Non-negotiables

- No PHI, PII, or secrets in code, tests, comments, or commit messages. Synthetic data must be labeled synthetic.
- Every changed behavior must have a corresponding test.
- Every change must be traceable to an ADO User Story or workshop exercise. State the scope before writing code.

## More detail

- **Services layer**: see `.github/instructions/services.instructions.md`
- **Pages layer**: see `.github/instructions/pages.instructions.md`
- **Agent operating agreement**: see `AGENTS.md`
- **Reusable workflows**: see `.github/skills/`
