# Exercise 4: Skills, prompt files, and layered customization

**Duration:** ~12 minutes (facilitator-led demo and discussion)

## Why skills matter for a mature team

When you put everything in `copilot-instructions.md`, you pay the token cost on every request — whether it's relevant or not. A 500-token instructions file gets injected into your autocomplete suggestions, your chat questions about a README, and your agent coding tasks. For a team already running complex agent workflows, that adds up, and it dilutes the signal.

The current GitHub guidance is direct: **keep `copilot-instructions.md` to about one page.** Put only what applies to every request: build/test commands, the architecture map, and the three non-negotiables. Everything else belongs in a more targeted mechanism.

The layered customization model from GitHub's latest docs:

| Mechanism | Where it lives | When it loads | What to put there |
|---|---|---|---|
| `copilot-instructions.md` | `.github/` | Every request | Build/test commands, architecture essentials, 3 hard rules |
| Path-specific instructions | `.github/instructions/*.instructions.md` | Only when matching files are open | Layer-specific conventions (services, pages, HL7 layer, Dynamics integration) |
| `AGENTS.md` | Repo root (or subdirectory) | Agent coding tasks | Operating agreement: plan, approve, implement, verify |
| Skills | `.github/skills/<name>/SKILL.md` | On demand, by description match or explicit invocation | Repeatable workflows with scripts, examples, resources |
| Prompt files | `.github/prompts/*.prompt.md` | When explicitly invoked by user | Task templates: delegation workflow, PR checklist, standup prep |

**The hierarchy in practice:** Fat `copilot-instructions.md` → token waste. Layered customization → context on demand, consistent results across developers, portable across Copilot clients.

## What is a skill?

From the VS Code docs: *"Skills are folders of instructions, scripts, and resources that AI agents can load when relevant to perform specialized tasks."*

A skill is a **directory** containing a `SKILL.md` file. It lives in `.github/skills/` (shared with the team) or `~/.copilot/skills/` (personal, cross-workspace). The open standard ([agentskills.io](https://agentskills.io)) means the same skill works across Copilot, GitHub Copilot CLI, the GitHub Copilot app, and compatible agents like Codex.

The `SKILL.md` frontmatter:

```markdown
---
name: add-section-type
description: >
  Add a new message category or content section type.
  Use when implementing a new operational area that follows the existing inbox pattern.
argument-hint: "Name of the new section type, e.g. 'ShiftLog'"
---
```

The `description` field is what the agent uses to decide whether to load the skill — be specific about **what it does AND when to use it**.

## Demo: skills in this repo

This repo has three skills in `.github/skills/`:

| Skill | What it does |
|---|---|
| `pr-review` | Team-specific PR checklist: scope, tests, nullable, PHI, PR fields |
| `triage-security-alert` | GHAS alert triage: CodeQL, secret scanning, Dependabot — structured analysis and fix scope |
| `add-section-type` | Repeatable pattern: add a new message category or operational section with consistent naming and test structure |

Open `.github/skills/add-section-type/SKILL.md`. Notice:
- The frontmatter `description` is specific about when to invoke it
- The `argument-hint` tells the agent what input to expect
- The body encodes the team pattern, naming conventions, and verification steps — not coding standards

**Without the skill:** every developer who adds a new operational section type has to remember the pattern, look up the naming convention, and write tests from scratch.  
**With the skill:** the agent loads the pattern on demand. One developer can encode the right approach once; the whole team gets it.

## Demo: invoking a skill

In Copilot Chat with the workspace open:

```
/add-section-type ShiftLog
```

Or describe the task and let the agent pick the skill automatically:

```
Add a shift log section to the inbox. Staff can log the start and end of each shift 
with a free-text note. Show the most recent entry per shift on the dashboard.
```

Watch the Chat panel — when the agent loads a skill, it appears in the references panel. Verify it loaded `add-section-type` before it starts planning.

You can also invoke skills explicitly from the slash-command menu: type `/` in Copilot Chat and look for the skill names from `.github/skills/`.

## Demo: prompt files

Open `.github/prompts/delegation-workflow.prompt.md`.

In VS Code, you can run a prompt file directly from chat: type `#` in the chat input and select the prompt file. It fills in the template. You edit the placeholders and submit.

Prompt files are different from skills:
- A prompt file is **user-invoked** — you choose when to use it
- A skill is **agent-discoverable** — the agent loads it when relevant
- Use prompt files for task templates you trigger manually; use skills for patterns you want the agent to apply consistently

## Your turn: design a skill for your team

Think about a repeatable development task in your current codebase:

1. What is a task your team does repeatedly that requires looking up conventions or past examples? *(Add a Dynamics integration endpoint, wire up a new content type, create a new HL7 listener for a message type…)*

2. What would go in the `description` field so the agent knows when to load it?

3. What would the skill's body contain that is NOT already in `copilot-instructions.md`?

## Creating a skill with AI

You do not have to write `SKILL.md` by hand. Ask the agent:

```
Create a project skill named hl7-listener-pattern in .github/skills/. 
It should guide an agent through adding a new HL7 listener for a message type 
following the pattern in src/Messaging/. Include the naming conventions, 
interface requirements, DI registration, and test structure. 
Add a description that tells the agent when to use it.
```

Review the generated file before committing. Check that the description is specific, the steps encode the actual team pattern, and the commands reference real build/test steps.

## The ecosystem

Skills are portable. A skill you write in `.github/skills/` works with:
- GitHub Copilot in VS Code (today)
- GitHub Copilot CLI
- The GitHub Copilot app
- Codex (via `.github/skills/` discovery)
- Any agent that supports the [agentskills.io](https://agentskills.io) open standard

Personal skills in `~/.copilot/skills/` work across all your workspaces on that machine, regardless of repository.

## One-line summary

> Keep `copilot-instructions.md` light. Use path-specific instructions for layer conventions, skills for repeatable workflows, and prompt files for templates you invoke manually.
