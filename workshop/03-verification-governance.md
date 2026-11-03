# Exercise 3: Verification, review, and governance

**Duration:** ~12 minutes (facilitator-led discussion with live demo)

## The trust problem this workshop addresses

Teams adopting Copilot agents often report a pattern like this: early productivity gains are real, but confidence in the output is low. Sometimes the generated code is excellent; other times it is subtly wrong or changes far more than was requested, and the review cost eats the time saved.

Structured delegation (Exercise 2) addresses _scope_. This exercise addresses _confidence_: how do you actually validate that what the agent produced is correct, complete, and safe?

## Four verification layers

### 1. Test coverage as a contract

Before you approve any plan, confirm the test strategy:

- **Unit tests:** Does the new behavior have at least one happy-path test and one edge-case test?
- **Regression:** Do all pre-existing tests still pass?
- **Test scope matches change scope:** If the agent only modified the service, the new tests should only test the service — not re-test the whole page.

Ask Copilot directly:

```
Before I review the diff, tell me: which behaviors does the implementation add that 
were not previously tested, and which tests cover each of them?
```

### 2. Diff review: what actually changed

Always look at the diff before pushing, even if tests pass. Look for:

- **Unexpected file changes**: anything not in the approved plan
- **Removed code**: deletions that are not explained by the change request
- **New dependencies**: added `using` statements pointing to external packages
- **Magic values**: hard-coded strings or numbers that should be configuration
- **Logging or comment changes**: confirm no PHI or sensitive data was included

Use Copilot to assist the review, not replace it:

```
Review the diff in this PR. Flag any change that: (1) was not in the approved plan, 
(2) removes existing behavior, (3) adds a dependency, or (4) could affect security 
or data handling. For each flagged item, explain the risk.
```

### 3. Scope constraints in AGENTS.md

You can reduce the review burden before it starts by setting scope limits in `AGENTS.md`. This repo's operating agreement already includes a constraint table. Review it now:

> **Allowed without additional approval**: editing files named in the approved plan, adding unit tests for changed code, updating XML doc comments on changed members  
> **Requires explicit approval**: editing files outside the approved plan, adding new NuGet packages, changing project-level configuration, modifying CI workflow files, changing authentication or authorization logic

**Discussion:** Which of your team's current pain points would be addressed by one of these constraints? Which constraints are missing for your context?

### 4. Code-scanning as a final gate

After a PR is open, GitHub Advanced Security (if enabled) will flag:

- **CodeQL alerts**: logic errors, injection risks, unsafe patterns
- **Secret scanning**: API keys or credentials accidentally committed
- **Dependabot**: CVEs in new or updated dependencies

Use Copilot to help triage:

```
I have a high-severity CodeQL alert in this PR: [paste alert title and data-flow path].
Explain the risk, propose a fix that does not change behavior outside the flagged code, 
and tell me what test would verify the fix.
```

Approve the fix only after reviewing the proposed diff. Do not auto-apply Autofix without human review.

## Governance summary

| Question | Answer |
|---|---|
| Who approves the plan? | The developer assigned to the story |
| Who reviews the diff? | At least one human reviewer |
| Who approves the merge? | Reviewer via required PR approval |
| Can Copilot review replace human review? | No. It is a supplementary check. |
| When does a change go to production? | After all required checks pass and a human approves |

## One-line close

GitHub Copilot does not replace policy, peer review, tests, security gates, or professional judgment. A generated change is a proposal until a qualified person validates and approves it.
