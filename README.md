# TODO: Project Name

TODO

## Overview

TODO

## Prerequisites

- [.NET 10 SDK](https://dotnet.microsoft.com/en-us/download/dotnet/10.0)
- [.NET Aspire workload](https://learn.microsoft.com/en-us/dotnet/aspire/fundamentals/setup-tooling?tabs=linux#install-net-aspire) (`dotnet workload install aspire`)
- [Docker Desktop](https://www.docker.com/products/docker-desktop/) (for PostgreSQL and Mealie containers)

## Running the Application

Execute the following in a terminal at the root of this Git repository:

```bash
aspire run
```

This will start the .NET Aspire dashboard and orchestrate the apps and services.

## Build

Build the solution:

```bash
dotnet build --configuration Release --nologo
```

## Structure

TODO

- `src/` - Source projects (empty initially)
- `tests/` - Test projects (empty initially)
