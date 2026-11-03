# Facilitator guide

## Session

**Title:** GitHub Copilot: Structured Agent Delegation  
**Format:** Virtual or hybrid, 60 minutes  
**Audience:** Developers already using GitHub Copilot, including agent-based workflows. This is not a foundations or autocomplete session.

## Delivery intent

The central story is:

> Move from "asking Copilot to write code" to "delegating meaningful development work in a structured, repeatable, and governable way."

Keep this framing front-and-center. Every demo moment should illustrate a better delegation pattern, not a Copilot trick.

## Suggested roles

| Role | Description |
|---|---|
| Organizer / host | Opens the session, handles logistics, closes |
| Technical lead | Delivers the demo and exercises |
| Supporting facilitator (optional) | Monitors chat, fields questions, assists during exercises |

## Run of show

| Elapsed | Duration | Topic | Notes |
|---|---:|---|---|
| 0:00 | 5 min | Welcome, objectives, audience check | Ask: "How many of you have had an agent change more than you asked for?" |
| 0:05 | 13 min | Layered customization | Open `.github/copilot-instructions.md` — show the slim version. Open `services.instructions.md` and explain glob-triggered loading. Briefly frame `AGENTS.md`. |
| 0:18 | 17 min | Delegation patterns | Demo: take the priority-filter change request through Specify → Plan → Implement → Verify. Show scope-creep intercept. |
| 0:35 | 12 min | Skills and prompt files | Open `.github/skills/add-section-type/SKILL.md`. Invoke `/add-section-type` in Copilot Chat. Show skill in references panel. Show `delegation-workflow.prompt.md`. |
| 0:47 | 8 min | Verification, governance | Diff review prompts, test contracts, GHAS triage skill. Keep to discussion + prompts. |
| 0:55 | 5 min | MCP/multi-agent horizon + Q&A | Brief framing of Figma, ADO, and Azure MCP connections. Route deeper interest to a follow-on session. Close. |

## Demo setup (before the session)

1. Clone this repository locally and open in Visual Studio or VS Code. Confirm Copilot agent mode is active.
2. Open Copilot Chat in a side panel.
3. Run `dotnet test ClinicalOpsLog.sln` -- confirm 5 tests pass.
4. `git status` -- confirm a clean working tree on `main`.
5. Pre-open: `README.md`, `.github/copilot-instructions.md`, `.github/instructions/services.instructions.md`, `AGENTS.md`, `src/ClinicalOpsLog/Pages/Inbox.cshtml.cs`.

## Demo flow: delegation patterns segment

1. Start with `Inbox.cshtml.cs` open.
2. Show a **bad prompt** first: `"Add priority filtering to the inbox."` Observe the suggestion, note what it guessed. Discard without accepting.
3. Work through Checkpoint 1 (Specify) using the prompt from `workshop/01-delegation-patterns.md`. Show the agent asking a clarifying question.
4. Work through Checkpoint 2 (Plan). Show the numbered plan. Point out the scope list.
5. If time allows, proceed to Checkpoint 3 (Implement). If short on time, show the pre-completed `feature/priority-filter` branch.
6. Run `dotnet test` live and show the summary output (Checkpoint 4).

## Backup

If VS/Copilot is unavailable, walk through the exercise markdown files as discussion, and show the completed `feature/priority-filter` branch diff as the expected output of structured delegation.

## Opening questions

Ask these early to anchor the rest of the session:

1. "How many of you have had an agent change files you didn't expect it to touch?"
2. "Does your team have any written conventions for how Copilot should behave?"
3. "Have you ever spent more time reviewing agent output than you would have spent writing it yourself?"

## Contingencies

| Risk | Action |
|---|---|
| Copilot unavailable | Use exercise markdown as slides; discuss prompts as a group |
| Tests fail during demo | Switch to pre-completed `feature/priority-filter` branch |
| Session runs long | Skip live Checkpoint 3; show completed branch diff instead |
| Questions go deep on MCP or multi-agent | Capture; offer a dedicated follow-on session |

## Follow-on session offer

If the audience wants to continue, suggested tracks are:

1. **MCP and grounding** -- Figma, GitHub, Azure DevOps MCP connections, setup, and governance (60 min)
2. **Custom agents and skills** -- Packaging repeatable development patterns into reusable skills (60 min)
3. **Multi-agent and delegated workflows** -- Subagents, parallel work, worktrees, cloud coding agents, and ADO integration (60 min)

## Closing language

GitHub Copilot does not replace your organization's policies, human judgment, peer review, testing, or security gates. A generated change is a proposal until a qualified person validates and approves it.
