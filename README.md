# SoftwareMind.Backend.Employees

Employees Management API (.NET 9)

This is a RESTful API built with .NET 9 for managing employee data. The project follows Clean Architecture principles and includes authentication using JWT, PostgreSQL for data persistence, and is structured with CQRS, MediatR, Repository Pattern, Unit of Work, and Dependency Injection. Unit tests are implemented using xUnit.

Features:
- Create, read, update, and delete employees
- Read department
- Login


*There is no need to manually run any SQL script to create tables. The project automatically applies Entity Framework Core migrations during application startup.*


Authentication:
The login endpoint (POST /api/Auth/login) returns a JWT token. All other endpoints are protected and require the following HTTP header:

Authorization: Bearer <your_token>
The entity user has a column role that allows if necessary configure role for each endpoint


Architecture:
The project is divided into:
- Domain: contains the core business entities and interfaces
- Application: contains use cases, DTOs, and MediatR handlers
- Infrastructure: implements persistence, integrations, and repositories
- API: contains controllers, middleware, and configuration
- Tests: xUnit-based unit test projects


Running tests:
Use dotnet test to run all unit tests. These tests focus on application-level logic and rules.


Technologies:
- .NET 9
- Entity Framework Core
- PostgreSQL
- MediatR
- Docker Compose
- xUnit


Requirements:

.NET 9 SDK