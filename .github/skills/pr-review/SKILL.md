---
name: pr-review
description: >
  Review a pull request using team-specific quality criteria.
  Use when preparing to open or reviewing an open PR for this repository.
  Checks scope, tests, naming, nullable safety, PHI risks, and required PR fields.
---

# PR review

## When to use

Use this skill when:
- You are preparing to open a pull request and want to self-review first.
- You are reviewing a pull request submitted by a teammate or Copilot.
- A review comment asked you to re-check a specific concern.

## Review checklist

Work through each item in order. For each item, state whether it passes, fails, or does not apply, and explain why.

### Scope
- [ ] Every changed file was listed in the approved change plan.
- [ ] No files were changed that were not in the plan. If any were, explain the reason.
- [ ] The diff does not include unrelated refactors, comment cleanup, or style changes.

### Tests
- [ ] Every new behavior has at least one unit test (happy path + one edge case).
- [ ] All pre-existing tests pass (`dotnet test ClinicalOpsLog.sln`).
- [ ] Test file names match source file names (`MessageInboxService.cs` → `MessageInboxServiceTests.cs`).
- [ ] No test mocks types the project owns; in-memory implementations are used instead.

### Code quality
- [ ] No nullable suppression (`!`) without an explanatory comment.
- [ ] No `async void` methods outside event handlers.
- [ ] No `.Result` or `.Wait()` on `Task` or `ValueTask`.
- [ ] No `Console.Write` in non-test code.
- [ ] No hardcoded connection strings, API keys, or credentials.

### PHI and data safety
- [ ] No real patient names, identifiers, dates of birth, diagnoses, or other PHI appear anywhere in the diff.
- [ ] Any test data is labeled synthetic in a comment or in the data itself.
- [ ] No logging statements that could capture user input or query parameters.

### Pull request fields
- [ ] Title follows `[type]: short description` format (`feat`, `fix`, `refactor`, `test`, `docs`).
- [ ] Description references an ADO User Story or workshop exercise ID.
- [ ] Copilot pull-request review has been requested (supplementary, not a substitute for human review).
- [ ] At least one human reviewer is assigned.

## Output format

Return a table with three columns: **Item**, **Status** (Pass / Fail / N/A), and **Notes**. Follow the table with a one-paragraph summary of the most important findings.
