# Sona - Backend Documentation

SonaAPI is a concise, production-ready RESTful API template intended for C#/.NET backends. It provides a clean project structure, common best-practices (dependency injection, configuration by environment, logging), and batteries-included developer tooling (Swagger/OpenAPI, EF Core migrations, Docker). Use this repository as a starting point for building a domain-specific API.

## Table of contents

- [What is SonaAPI](#what-is-sonaapi)
- [Key features](#key-features)
- [Architecture overview](#architecture-overview)
- [Tech stack](#tech-stack)
- [Prerequisites](#prerequisites)
- [Getting started (local development)](#getting-started-local-development)
  - [Clone](#clone)
  - [Configure environment](#configure-environment)
  - [Run locally](#run-locally)
  - [Run with Docker](#run-with-docker)
- [Configuration](#configuration)
  - [Recommended environment variables / appsettings](#recommended-environment-variables--appsettings)
- [Database & migrations](#database--migrations)
- [API documentation](#api-documentation)
- [Testing](#testing)
- [CI/CD & deployment notes](#cicd--deployment-notes)
- [Contributing](#contributing)
- [License](#license)
- [Contact / Support](#contact--support)

---

## What is SonaAPI

SonaAPI is a starting template for building a robust web API using modern .NET (Core/6/7/8 - adjust to your target). It implements common patterns for maintainability and productivity:

- Clean layered structure (API → Application → Infrastructure → Domain)
- Centralized configuration and environment awareness
- Swagger/OpenAPI for interactive API exploration
- EF Core (or alternative) for data access and migrations
- Dockerfile and example docker-compose for local containerized runs
- Logging, health checks and readiness probes

This repository is intentionally generic so it can be adapted quickly for real products.

## Key features

- RESTful endpoints scaffolded with clear routing and DTOs
- Dependency Injection and configuration by environment
- OpenAPI (Swagger) documentation
- EF Core migrations and seed data hooks
- Containerization via Docker
- Example integration and unit test projects
- Ready to wire authorization (JWT/Bearer), caching, and background workers

## Architecture overview

SonaAPI follows a small, opinionated architecture:

- /src/SonaAPI.Api — HTTP entry point (controllers, request/response models, routing)
- /src/SonaAPI.Application — Use cases, DTOs, interfaces (service contracts)
- /src/SonaAPI.Infrastructure — EF Core DbContext, repository implementations, external integrations
- /tests — Unit and integration tests
- /docker — Dockerfile and docker-compose for local development

This separation keeps the HTTP concerns isolated from business logic and infrastructure code.

## Tech stack

- Language: C# (.NET 6/7/8 — adjust)
- Web framework: ASP.NET Core
- ORM: Entity Framework Core (optional — replaceable)
- Containerization: Docker
- API docs: Swashbuckle / OpenAPI (Swagger)
- Testing: xUnit / NUnit / MSTest (choose one)
- Optional: Redis, RabbitMQ, PostgreSQL / SQL Server

## Prerequisites

- .NET SDK 6/7/8 installed locally (dotnet --version)
- Docker & Docker Compose (for containerized runs)
- A database service (Postgres, SQL Server, or SQLite for quick starts)
- Recommended: dotnet-ef tool if running EF migrations locally:
  - dotnet tool install --global dotnet-ef

## Getting started (local development)

### Clone

```bash
git clone https://github.com/recca383/SonaAPI.git
cd SonaAPI
```

### Configure environment

Copy the example settings and update values:

```bash
cp src/SonaAPI.Api/appsettings.Development.json.example src/SonaAPI.Api/appsettings.Development.json
# Or create a .env file for Docker runs
```

Recommended environment variables (examples below). Use a secrets manager in production.

### Run locally

Restore and run the API:

```bash
cd src/SonaAPI.Api
dotnet restore
# apply migrations if using EF Core:
dotnet ef database update --project ../SonaAPI.Infrastructure --startup-project .
dotnet run
```

By default the API will be available at http://localhost:5000 and https://localhost:5001 (adjust ports in launchSettings or appsettings).

### Run with Docker

Build and run the container locally:

```bash
# Build image
docker build -t sonaapi:local -f src/SonaAPI.Api/Dockerfile .

# Run (example with environment vars)
docker run --env-file .env -p 5000:80 sonaapi:local
```

Or use docker-compose (if provided):

```bash
docker-compose -f docker/docker-compose.dev.yml up --build
```

The compose file can start the API plus required services such as a database.

## Configuration

SonaAPI uses ASP.NET Core configuration conventions. You can configure through (in order of precedence):

- Environment variables
- appsettings.{Environment}.json
- appsettings.json
- Secrets / Vault for sensitive values

### Recommended environment variables / appsettings

Provide these values in your environment or appsettings files (example keys):

- ASPNETCORE_ENVIRONMENT=Development
- ConnectionStrings__DefaultConnection=Server=...;Database=...;User Id=...;Password=...
- Logging__LogLevel__Default=Information
- Jwt__Issuer=your-issuer
- Jwt__Audience=your-audience
- Jwt__Key=super-secret-key
- External__SomeApi__BaseUrl=https://api.example.com
- Redis__Configuration=localhost:6379

Adjust names to match the appsettings.json schema in this repository.

## Database & migrations

This template expects a relational database when EF Core is used:

Apply migrations locally (example):

```bash
# from repo root
cd src/SonaAPI.Api
dotnet ef migrations add InitialCreate --project ../SonaAPI.Infrastructure --startup-project .
dotnet ef database update --project ../SonaAPI.Infrastructure --startup-project .
```

If using Docker, the docker-compose file may run migrations automatically at container startup (see docker/docker-entrypoint or entrypoint script).

Seed data: The repository includes a seed hook (typically in Program.cs) that runs on startup when in Development. Customize the seed logic in the Infrastructure project.

## API documentation

Swagger UI is enabled in Development by default. After running, visit:

- Swagger JSON: /swagger/v1/swagger.json
- Swagger UI: /swagger

Example curl requests:

- Health check (if implemented)
  curl -i http://localhost:5000/health

- Example GET
  curl -i http://localhost:5000/api/v1/example

- Example POST (replace with actual endpoints)
  curl -i -X POST http://localhost:5000/api/v1/auth/login \
    -H "Content-Type: application/json" \
    -d '{"email":"user@example.com","password":"Passw0rd!"}'

All endpoints, request/response schemas, and error codes are documented in Swagger.

## Testing

This repository includes unit and integration test projects under /tests.

Run tests:

```bash
dotnet test --no-build
```

Tips:

- Use an in-memory database (EF Core InMemory) or test-specific connection string for integration tests.
- Keep tests deterministic and independent of external services.

## CI/CD & deployment notes

Suggested CI checklist:

- Run dotnet restore, build, and test
- Run static analyzers (e.g., dotnet format, Roslyn analyzers)
- Build Docker image and run containerized integration tests
- Push artifacts to container registry
- Deploy to your target environment (Kubernetes, App Service, ECS)

When deploying to production, ensure:

- Secrets are stored in a secure vault (do not check into repo)
- HTTPS termination and proper CORS
- Health/readiness probes are configured
- Horizontal scaling and connection pooling are considered

## Contributing

Contributions are welcome. A good contribution workflow:

1. Fork the repository
2. Create a feature branch: git checkout -b feature/brief-description
3. Write tests for new functionality
4. Open a pull request describing the change, rationale, and any migration steps

Please follow the coding and commit conventions in the CONTRIBUTING.md (create one if needed).

## License

Specify your license here (e.g., MIT). Example:

This project is licensed under the MIT License — see the [LICENSE](LICENSE) file for details.

## Contact / Support

- Maintainer: recca383
- For issues and feature requests, please use the repository's Issues tracker.

---

If you'd like I can:
- adapt this README to include actual endpoint examples and environment variables from your SonaAPI project,
- generate a docker-compose.dev.yml and example appsettings.Development.json,
- or open a PR to add this README directly to the repository.

Tell me which of those you'd like next and provide any env or endpoint details you want included.
