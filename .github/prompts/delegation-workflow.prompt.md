---
mode: agent
description: Structured four-checkpoint delegation workflow. Use for any feature request you want to delegate to a Copilot agent.
---

# Delegation workflow

Use this prompt file to start a structured agent delegation session. Replace the bracketed placeholders before submitting.

---

Before you write any code, read:
- `AGENTS.md` — operating agreement
- `.github/copilot-instructions.md` — team conventions
- Any path-specific instructions that apply to the files you will touch

**Feature request:**
[Paste the ADO User Story title and acceptance criteria here, or describe the change in 2–4 sentences.]

**Scope boundary:**
The only files you are allowed to modify are:
[List the files or directories you expect to change. Be specific.]

**Definition of done:**
- [ ] All acceptance criteria are met
- [ ] `dotnet test ClinicalOpsLog.sln` passes with no regressions
- [ ] A human has reviewed and approved the diff
- [ ] The PR description references the ADO User Story

---

**Checkpoint 1 — Clarify:** State any questions you have before proposing a plan. Do not assume; ask.

**Checkpoint 2 — Plan:** Propose a numbered implementation plan listing every file you will create or modify, what you will change in each, and how you will test it. Do not write code yet. Wait for my approval.

**Checkpoint 3 — Implement:** After I approve the plan, implement it step by step. After each logical change, tell me what you changed.

**Checkpoint 4 — Verify:** Run `dotnet test ClinicalOpsLog.sln`. Report the result, summarize what changed, and list anything you were uncertain about.
