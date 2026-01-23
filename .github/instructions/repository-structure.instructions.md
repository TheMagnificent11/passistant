---
applyTo: "**/*"
---

# Repository Structure

## Project Organization

```
passistant/
│
├── src/                          # Source projects
│   ├── Passistant.AppHost/       # .NET Aspire orchestration entry point
│   └── Passistant.Common/        # Shared constants and utilities
│
├── tests/                        # Test projects (empty initially)
│
├── Directory.Build.props         # Root build properties (all projects)
├── Directory.Packages.props      # Central Package Management
└── .editorconfig                 # Root code style rules
```

## Configuration Files

| File | Purpose | When to Edit |
|------|---------|-------------|
| `passistant.slnx` | Solution with all projects | Adding/removing projects |
| `Directory.Build.props` | Global MSBuild properties (targets .NET 10.0) | Changing global build settings |
| `Directory.Packages.props` | Central Package Management (CPM) | Adding/updating NuGet packages |
| `.editorconfig` | Global code style rules | Adjusting global code formatting |
| `src/Passistant.AppHost/Program.cs` | Aspire orchestration | Configuring services |
| `.github/workflows/ci.yml` | CI/CD pipeline | Modifying build/test process |

## Common Development Tasks

| Task | Command | Use Case |
|------|---------|----------|
| Clean artifacts | `dotnet clean` | Remove build outputs |
| Full rebuild | `dotnet build --configuration Release --no-incremental` | After major changes |
| Run Aspire app | `dotnet run --project src/Passistant.AppHost/` or `aspire run` | Start orchestrated services |
| Format code | `dotnet format` | Fix style issues |
