# Exercise 2: Delegation patterns — structured agent workflow

**Duration:** ~20 minutes (live demo with facilitator, participants follow along in their own VS instance if available)

## The delegation gap

Most Copilot usage looks like this:

> "Add a filter to the inbox page"

The agent writes something. You review it. It changed more than expected. You spend ten minutes figuring out what it did. Sound familiar?

Structured delegation changes the starting point. Instead of asking for an implementation, you ask for a **plan** first. You approve the plan. Then you ask for the implementation.

## The workflow: four checkpoints

```
1. SPECIFY   →  Give the agent a bounded, unambiguous goal
2. PLAN      →  Ask the agent to propose a plan; wait for approval
3. IMPLEMENT →  Ask the agent to implement the approved plan only
4. VERIFY    →  Ask the agent to confirm tests pass and summarize what changed
```

## Demo: the change request

**Feature request (from ADO User Story #0042):**

> Add priority-level filtering to the message inbox. Users should be able to filter the inbox by High, Medium, or Low priority. The dashboard summary should also show a count of messages per priority level.

Open Copilot Chat in Visual Studio. Work through the four checkpoints.

---

### Checkpoint 1: Specify

Paste this into Copilot Chat:

```
I have a feature request I want to delegate to you. Before you write any code, read:
- AGENTS.md (operating agreement)
- .github/copilot-instructions.md (team conventions)
- src/ClinicalOpsLog/Pages/Inbox.cshtml.cs (the page you'll modify)
- src/ClinicalOpsLog/Services/MessageInboxService.cs

The request: Add priority-level filtering to the message inbox. Users should be able 
to filter by High, Medium, or Low priority using a query parameter. The summary line 
on the page should show counts per priority (e.g., "3 High, 1 Medium, 2 Low").

State what clarifying questions you have before proposing a plan.
```

**Expected behavior:** The agent identifies any ambiguities (e.g., "what happens when no filter is selected — show all?") and asks before proposing code.

---

### Checkpoint 2: Plan

After you answer the agent's questions, ask:

```
Now propose a numbered implementation plan. List every file you plan to create 
or modify, what you will change in each file, and how you will test it.
Do not write any code yet.
```

**Review the plan for:**
- Is the scope bounded? Are there files listed that you did not expect?
- Is the test strategy stated?
- Does it touch `Program.cs` or `.csproj`? (Should not be necessary for this change.)

If anything is out of scope, say so. Example: *"Do not modify SeedData.cs. The filter goes in the page and service, not the data."*

---

### Checkpoint 3: Implement

Once you approve the plan:

```
Proceed with the approved plan only. Make one logical change per step. 
After each step, tell me what you changed.
```

Watch for scope creep. If the agent touches a file not in the plan, stop it:

```
Stop. You modified [file] which was not in the approved plan. Revert that change 
and explain why you included it.
```

---

### Checkpoint 4: Verify

After the implementation:

```
Run dotnet test tests/ClinicalOpsLog.Tests and confirm all tests pass with no regressions.
Then summarize: which files changed, what behavior changed, and what the tests verify.
List anything you were uncertain about and how you resolved it.
```

**What to look for:**
- All existing tests still pass
- New tests cover the filter behavior (at minimum: filter by High returns only High-priority messages; no filter returns all)
- The summary includes no surprises

---

## What makes this different

| Ad hoc prompt | Structured delegation |
|---|---|
| Agent guesses intent | Agent asks clarifying questions |
| Scope defined by agent | Scope defined by the approved plan |
| Review happens after surprise changes | Review happens before changes |
| One big diff | Step-by-step, traceable changes |
| Uncertain what was tested | Explicit test summary |

## Discussion

- Where in your ADO workflow would you capture the approved plan? (PR description? Comment on User Story?)
- Which of your current projects has the clearest scope problem with agent-generated changes?
- What is one convention you would add to `AGENTS.md` based on what you just observed?
