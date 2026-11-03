# Agent operating agreement

This file governs how Copilot agents operate in this repository. Read it before starting any agent coding task. All rules below apply to VS Code agent mode, GitHub Copilot Workspace, and any other AI coding agent that reads this file.

## Core principle

An agent is a delegated collaborator, not an autonomous actor. Every meaningful change requires:

1. A written plan reviewed and approved by a human.
2. A diff reviewed by a human before merge.
3. Tests that pass with no new failures.
4. Human approval before any branch is merged.

## Before writing any code

1. **Understand the request.** Read the linked ADO User Story or exercise description. If requirements are ambiguous, ask one clarifying question before proceeding.
2. **Scope the change.** List every file you plan to create, modify, or delete, and explain why each one is necessary.
3. **Write a plan.** Produce a numbered implementation plan in plain English. Include the test strategy.
4. **Wait for approval.** Do not begin editing until the human explicitly confirms the plan. "Looks good" or "proceed" counts; silence does not.

## While implementing

- Make one logical change per commit. Describe the change and its reason in the commit message.
- Do not refactor code that is not directly related to the current task.
- Do not add new dependencies without listing them in the plan and getting approval.
- If you discover a bug unrelated to the current task, note it in a comment and add a TODO, but do not fix it in this changeset.
- Do not read, log, or include PHI, PII, or real credentials at any point.

## After implementing

1. Run `dotnet build` and confirm zero errors.
2. Run `dotnet test tests/ClinicalOpsLog.Tests` and confirm all tests pass with no regressions.
3. Summarize the changes: which files were modified, what behavior changed, and what the tests verify.
4. List anything you were uncertain about and how you resolved it.
5. Request human diff review before pushing.

## Scope constraints

| Allowed without additional approval | Requires explicit approval before proceeding |
|---|---|
| Editing files named in the approved plan | Editing files outside the approved plan |
| Adding new unit tests for changed code | Adding new NuGet packages |
| Updating XML doc comments on changed members | Changing project-level configuration (`.csproj`, `appsettings.json`) |
| Fixing compiler errors introduced by the current change | Refactoring unrelated code |
| | Modifying CI workflow files |
| | Changing authentication or authorization logic |

## MCP tool use

When MCP servers are connected:
- State which MCP tools you intend to use before using them.
- Do not read files outside the repository root without explicit permission.
- Do not call destructive or write operations (create, update, delete) on external systems without explicit per-operation approval.
- Confirm after each MCP read that the information is relevant before including it in a change.

## Secrets and sensitive data

- Never include secrets, API keys, or connection strings in code, comments, commit messages, or prompts.
- If you discover a secret in the codebase, stop and flag it to the human immediately. Do not include it in any output.
- All synthetic data used in tests must be clearly labeled as synthetic.

## Git workflow

- Create a new branch from `main` for each task. Use the format `feature/<short-description>` or `fix/<short-description>`.
- Do not push directly to `main`.
- Open a pull request when the implementation is complete and tests pass.
- Do not force-push to shared branches.

## Permission modes

The default agent mode for this repository is **Edit + Terminal (read/write with explicit approval for destructive terminal commands)**. The agent must not change its own permission mode.

## Stopping criteria

Stop and ask the human if:
- The implementation would require changes outside the approved plan.
- Tests are failing and you are not confident in the fix.
- You encounter an ambiguity that changes the scope of the original plan.
- Any command would modify data outside the repository.
