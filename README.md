# Clinical Operations Log

This synthetic repository supports a hands-on GitHub Copilot agent delegation workshop for development teams already using GitHub Copilot and looking to move beyond ad hoc prompting.

The example follows a small feature request — adding priority-level filtering to a clinical message inbox — through structured Copilot agent delegation: specification, plan approval, implementation, tests, and review. The scenario is realistic but all data is synthetic.

This is an independent teaching repository. It is not affiliated with, sponsored by, or approved by any company, healthcare organization, or regulatory body.

## Workshop

Work through the exercises in [`workshop/`](workshop/) in order. Start with the [agenda](workshop/00-agenda.md).

| Path | Purpose |
|---|---|
| `workshop/00-agenda.md` | Session run of show |
| `workshop/01-delegation-patterns.md` | Moving from chat to structured delegation |
| `workshop/02-repo-instructions.md` | `copilot-instructions.md`, `AGENTS.md`, path instructions |
| `workshop/03-verification-governance.md` | Review, scope control, tests, governance |
| `workshop/facilitator-guide.md` | Facilitator reference |

## Application

`src/ClinicalOpsLog/` is a minimal ASP.NET Core Razor Pages application simulating a clinical operations message inbox. It is intentionally simple so the focus stays on agent workflow, not the technology.

## Validate

```powershell
dotnet test tests/ClinicalOpsLog.Tests
```

## Repository conventions

See [`.github/copilot-instructions.md`](.github/copilot-instructions.md) and [`AGENTS.md`](AGENTS.md) for the team coding standards and agent operating norms this repo demonstrates.

## Important

- All data is synthetic.
- Do not add patient data, real credentials, secrets, or proprietary information to files, prompts, or issues.
- Workshop changes are proposals for learning purposes. They are not validated clinical outputs.
- Human review, tests, and approval are required regardless of what Copilot suggests.
