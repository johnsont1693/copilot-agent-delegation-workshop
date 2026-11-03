---
name: add-section-type
description: >
  Add a new message category or content section type to the ClinicalOpsLog application.
  Use when implementing a new operational area (e.g., shift logs, equipment alerts, patient transport requests)
  that follows the existing inbox message pattern. Produces a full implementation: model, service method,
  page filter, and tests, using the established pattern.
argument-hint: "Name of the new section type, e.g. 'ShiftLog' or 'TransportRequest'"
---

# Add section type

## When to use

Use this skill when a request calls for adding a new category or type of operational message to the ClinicalOpsLog inbox. This is a repeatable pattern: each section type follows the same structure as `ClinicalMessage` with `MessagePriority`. The skill enforces consistency so each developer implements the pattern the same way.

## Pattern overview

A "section type" in this application is a combination of:
1. An enum value on `MessagePriority` (if a new priority level is needed) or a new category property.
2. An updated `IMessageInboxService` method that filters or groups by the new type.
3. An updated `InboxModel` page property that exposes the new data.
4. A corresponding view update in `Inbox.cshtml`.
5. Unit tests in `MessageInboxServiceTests.cs` covering the new behavior.

## Implementation steps

### 1. Understand the request
- What is the name of the new section type?
- Does it need a new enum value, or does it reuse an existing `MessagePriority`?
- Should it appear as a filter, a separate list, or a summary count?
- Does it require any new properties on `ClinicalMessage`, or does it use a new record type?

If any of these are unclear, ask before proceeding.

### 2. Write the plan
List every file to create or modify:
- `src/ClinicalOpsLog/Models/ClinicalMessage.cs` (if model changes are needed)
- `src/ClinicalOpsLog/Services/MessageInboxService.cs` (new interface method + implementation)
- `src/ClinicalOpsLog/Services/SeedData.cs` (add synthetic seed messages for the new type)
- `src/ClinicalOpsLog/Pages/Inbox.cshtml.cs` (new page property)
- `src/ClinicalOpsLog/Pages/Inbox.cshtml` (view update)
- `tests/ClinicalOpsLog.Tests/MessageInboxServiceTests.cs` (new test methods)

Wait for approval before writing code.

### 3. Implement
Follow `.github/instructions/services.instructions.md` for service changes and `.github/instructions/pages.instructions.md` for page changes. All synthetic seed data must be labeled synthetic in a comment.

### 4. Verify
- Run `dotnet build ClinicalOpsLog.sln`. Confirm zero errors.
- Run `dotnet test ClinicalOpsLog.sln`. Confirm all tests pass.
- Summarize: files changed, new behavior, new tests added.

## Conventions enforced by this skill

- New record types use C# `record` with positional parameters.
- New service interface methods follow the `GetMessages()` naming pattern (not `Fetch`, `Load`, `Retrieve`).
- Test method names follow `MethodName_Condition_ExpectedResult` (e.g., `GetByCategory_WithMatchingCategory_ReturnsOnlyMatchingMessages`).
- No new NuGet packages are added for this pattern.
