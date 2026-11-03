# Exercise 1: Repository-level instructions — the light version

**Duration:** ~13 minutes (facilitator demonstration, participants observe and discuss)

## The problem with a heavy `copilot-instructions.md`

`copilot-instructions.md` is injected into **every request** in the repository — autocomplete suggestions, chat questions about documentation, agent coding tasks. A 500-line file gets read every time you ask "what does this method do?" That token cost adds up, and worse, it trains you to think one file is the answer to everything.

GitHub's own guidance for Cloud Agent instructs: *"Instructions must be no longer than 2 pages."*

The right question is not "what should I put in `copilot-instructions.md`?" It is "which mechanism loads context at the right time?"

## The layered model

| Mechanism | Loads when | Token cost | What belongs here |
|---|---|---|---|
| `copilot-instructions.md` | Every request | Always | Build/test commands, architecture map, 3 hard rules |
| `.github/instructions/*.instructions.md` | Files in the glob match are open | On demand | Layer conventions (services, pages, HL7, Dynamics) |
| `AGENTS.md` | Agent coding tasks | Agent sessions only | Operating agreement: plan → approve → implement → verify |
| `.github/skills/` | Agent loads on description match or `/command` | On demand | Repeatable workflows with scripts and examples |
| `.github/prompts/` | User invokes explicitly | Manual | Task templates |

## Demo: open this repo's `copilot-instructions.md`

Look at `.github/copilot-instructions.md`. It is intentionally short:
- Build and test commands — so the agent never has to search for them
- Architecture map — three bullet points, not a component diagram
- Three non-negotiables (PHI, tests, scope)
- Pointers to the other files for the rest

Now look at `.github/instructions/services.instructions.md`:

```markdown
---
applyTo: "src/ClinicalOpsLog/Services/**/*.cs"
---
```

This file only loads when Copilot is working on a file in `src/ClinicalOpsLog/Services/`. The async/await rules, constructor injection requirement, and logging conventions are here — not in the top-level file. A developer working on a Razor Page doesn't pay the token cost for service-layer rules.

## The `applyTo` glob

The frontmatter block is how you scope path-specific instructions:

```markdown
---
applyTo: "src/Messaging/HL7/**/*.cs"
---
```

This applies only to files in the HL7 messaging layer. You can have one file per architectural boundary. For a healthcare IT team, that might be:
- `hl7.instructions.md` → HL7 listener classes
- `dynamics.instructions.md` → Dynamics CRM integration layer
- `cms.instructions.md` → CMS content model conventions and rendering patterns

You can also use `excludeAgent` to prevent a file from being read by cloud agent or code review:

```markdown
---
applyTo: "**"
excludeAgent: "code-review"
---
```

## Discussion

1. What are the three rules you absolutely must communicate on every request? Those belong in `copilot-instructions.md`.
2. What rules apply only to your HL7 layer, your Dynamics integration, or your website presentation layer? Those are path-specific instructions.
3. What workflows does your team repeat that require looking up past examples? Those are candidates for skills (see [Exercise 4](04-skills-and-layered-customization.md)).

