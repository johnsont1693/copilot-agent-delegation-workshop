---
name: triage-security-alert
description: >
  Triage a GitHub Advanced Security alert (CodeQL, secret scanning, or Dependabot).
  Use when investigating an open GHAS alert, preparing a fix, or deciding whether to dismiss.
  Produces a structured analysis: severity, reachability, proposed fix scope, and test strategy.
---

# Triage security alert

## When to use

Use this skill when:
- A GitHub Advanced Security alert has been flagged in a PR or on the Security tab.
- You need to assess whether an alert is a true positive before assigning a fix.
- You need to scope a fix that does not introduce regressions.

## Inputs needed

Before starting, confirm you have:
1. The alert title and tool (CodeQL / Secret Scanning / Dependabot).
2. The alert severity (critical / high / medium / low).
3. The data-flow path or affected file and line numbers (for CodeQL).
4. The affected package and CVE number (for Dependabot).

If any of these are missing, ask for them before proceeding.

## Triage steps

### 1. Confirm the true positive
- Read the alert description and the flagged code path.
- State whether the alert is a true positive, false positive, or uncertain, and why.
- For CodeQL: trace the data flow from source to sink. Confirm whether user-controlled input reaches the flagged operation.
- For Dependabot: check whether the vulnerable code path in the package is reachable from this application.
- For secrets: confirm whether the value is a real credential or a placeholder/test value.

### 2. Assess impact
- Describe the worst-case impact if the vulnerability is exploited.
- State whether PHI or PII is in the data path.
- Note whether the affected code is reachable from an unauthenticated endpoint.

### 3. Propose a fix
- Describe the fix in plain English before writing any code.
- List every file the fix would touch.
- Confirm the fix does not change behavior outside the flagged code path.
- Identify what existing test(s) cover the affected code, and what new test would verify the fix.

### 4. Wait for approval
- Do not apply the fix until the human reviews and approves the proposal.

### 5. After fixing
- Run `dotnet build ClinicalOpsLog.sln` and confirm zero errors.
- Run `dotnet test ClinicalOpsLog.sln` and confirm all tests pass.
- Summarize the change and request human diff review before pushing.

## Dismissal criteria

Only propose dismissal (not a fix) if:
- The alert is a confirmed false positive with a documented reason.
- The affected code is provably unreachable in production.

Dismissal requires a human to review the reason and click Dismiss on GitHub. Do not auto-dismiss.

## Output format

Return a structured report with sections: **Alert summary**, **True positive assessment**, **Impact**, **Proposed fix** (with file list), **Test strategy**, and **Recommendation** (fix / dismiss / investigate further).
