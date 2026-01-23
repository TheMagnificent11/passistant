---
applyTo: "**/*.cs,**/*.csproj"
---

# Validation Workflows

## Required Validation After Changes

**Decision Tree:**
```
Did you change application code (Passistant.*)?
├─ YES → Run workflows 1, 2, and 3
└─ NO → Did you only change documentation?
    ├─ YES → Run workflow 1 only
    └─ NO → Run workflow 1 to be safe
```

## Workflow 1: Build Validation

**When:** After any Passistant code changes

**Commands:**
```bash
dotnet build --configuration Release --nologo
```

**Success Criteria:**
- All Passistant.* projects compile successfully
- Zero compilation warnings
- Zero style violations

## Workflow 2: Unit Test Validation

**When:** After code changes (not documentation-only)

**Commands:**
```bash
dotnet test --filter "FullyQualifiedName!~Integration" --configuration Release --no-build --nologo
```

**Success Criteria:**
- All unit tests pass
- No test failures or exceptions
- Test execution time < 30 seconds

## Workflow 3: Integration Test Validation

**When:** After infrastructure or data layer changes

**Commands:**
```bash
dotnet test --filter "FullyQualifiedName~Integration" --configuration Release --no-build --nologo
```

**Prerequisites:**
- Docker Desktop running
- .NET Aspire workload installed

**Success Criteria:**
- All integration tests pass
- Database operations work correctly
- API endpoints respond as expected

**Note:** Aspire manages PostgreSQL test containers automatically
