---
applyTo: "src/ClinicalOpsLog/Pages/**/*.cs,src/ClinicalOpsLog/Pages/**/*.cshtml"
---

# Pages layer conventions

- Razor Pages only. No MVC controllers, Blazor components, or Web API endpoints.
- Page models (`*.cshtml.cs`) must not contain business logic. Delegate to injected services.
- Use `OnGet` / `OnPost` / `OnGetAsync` / `OnPostAsync` handler methods. Do not override `OnActionExecuting`.
- Query parameters and bound properties must be validated before use. Use `[BindProperty]` for form inputs.
- All lists displayed in views must be `IReadOnlyList<T>` on the page model. Do not expose mutable collections.
- Do not add client-side JavaScript frameworks (React, Vue, etc.) without team discussion.
- Do not add `<script>` tags that load external resources; use bundled assets only.
