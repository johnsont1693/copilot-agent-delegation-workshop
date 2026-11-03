---
applyTo: "src/ClinicalOpsLog/Services/**/*.cs"
---

# Services layer conventions

- Every service class must implement a corresponding interface defined in the same file.
- Constructor injection only. Do not use service locator, static fields, or `IServiceProvider` inside services.
- In-memory implementations are the approved test double for integration with services you own. Do not use Moq or NSubstitute for types you control.
- `async`/`await` for all I/O operations. Never `.Result` or `.Wait()`.
- Use `ILogger<T>` for diagnostic logging. No `Console.Write` in production paths.
- Synthetic seed data lives in `SeedData.cs`. Do not add synthetic data inline in service methods.
- Do not add Entity Framework or any external data-access library without listing it in your change plan.
