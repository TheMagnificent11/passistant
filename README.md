# Passistant

## Overview

The intention of this application, when completed, is be personal for things that I want to automate:

- Meal planning and shopping list generation
  - For a family of four that two children and two adults with dietary requirements of vegetarian and low FODMAP
  - Meals consists of a vegetarian protein source for one adult and meat protein source for the other adult and children
- Daily read/watch list generation from pre-saved articles/blog and latest videos from a YouTube subscriptions

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

- `src/` - Source projects (empty initially)
- `tests/` - Test projects (empty initially)
