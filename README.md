# Product Management API

A RESTful Product Management API built with **ASP.NET Core 8**, following **Clean Architecture** principles. The project demonstrates CRUD operations, JWT Authentication, API Versioning, Repository Pattern, Unit of Work, Entity Framework Core, Docker, and Unit Testing.

---------------------------------------------------------------------------------------------------------------------

## Features

- Product CRUD Operations
- Item Management
- JWT Authentication
- Role-Based Authorization
- API Versioning
- Global Exception Handling Middleware
- FluentValidation
- Repository Pattern
- Unit of Work Pattern
- Entity Framework Core (SQL Server)
- AutoMapper
- Serilog Logging
- Swagger/OpenAPI Documentation
- Docker & Docker Compose
- Pagination Support
- CORS Configuration
- Response Compression
- Unit Tests using xUnit and Moq
- Integration Tests using WebApplicationFactory

---

## Technology Stack

- .NET 8
- ASP.NET Core Web API
- C#
- Entity Framework Core
- SQL Server
- AutoMapper
- FluentValidation
- JWT Authentication
- Serilog
- Swagger (Swashbuckle)
- Docker
- xUnit
- Moq

---
## Prerequisites
Before running the project, ensure you have the following installed:

- .NET 8 SDK
- SQL Server
- Visual Studio 2022 (or later)
- Docker Desktop (optional)

---
## Project Structure

```
Solution
│
├── ProductManagement.API
├── ProductManagement.Application
├── ProductManagement.Domain
├── ProductManagement.Infrastructure
├── ProductManagement.Application.Tests
├── ProductManagement.API.Tests
├── docker-compose.yml
└── README.md
```

---

## Architecture

This project follows **Clean Architecture**.

```
Presentation (API)
        │
Application
        │
Domain
        │
Infrastructure
        │
SQL Server
```

---

## Authentication

JWT Authentication is implemented.

Demo credentials:

### Admin

```
Username: admin
Password: admin123
```

### Employee

```
Username: employee
Password: employee123
```

---

## API Features

### Products

- Get All Products
- Get Product By Id
- Create Product
- Update Product
- Delete Product

### Authentication

- Login
- JWT Access Token Generation

---

## Pagination

Products endpoint supports pagination.

Example:

```
GET /api/v1.0/Products?page=1&pageSize=5
```

---

## Running the Project
## Configuration

Update the SQL Server connection string in `appsettings.json` to match your local SQL Server instance.

Example:

```json
"ConnectionStrings": {
  "DefaultConnection": "Server=YOUR_SERVER;Database=ProductManagementDb;Trusted_Connection=True;TrustServerCertificate=True;"
}
```

After updating the connection string, run the database migrations before starting the application.

---

## API Endpoints

### Authentication

| Method | Endpoint | Description |
|--------|----------|-------------|
| POST | `/api/v1.0/Auth/login` | Authenticate user and generate JWT |

### Products

| Method | Endpoint | Description |
|--------|----------|-------------|
| GET | `/api/v1.0/Products` | Get all products |
| GET | `/api/v1.0/Products/{id}` | Get product by ID |
| POST | `/api/v1.0/Products` | Create a product |
| PUT | `/api/v1.0/Products/{id}` | Update a product |
| DELETE | `/api/v1.0/Products/{id}` | Delete a product |

---

## Authentication Flow

1. Call `POST /api/v1.0/Auth/login`.
2. Copy the returned JWT access token.
3. Click the **Authorize** button in Swagger.
4. Enter:

Bearer <your_token>

5. Access protected endpoints.

---

### Clone Repository

```bash
git clone <your-github-url>
```

### Restore Packages

```bash
dotnet restore
```

### Run Migration

```bash
dotnet ef database update
```

### Run API

```bash
dotnet run
```

---

## Docker

Build the application:

```bash
docker compose build
```

Run the containers:

```bash
docker compose up
```

Stop the containers:

```bash
docker compose down
```
---

## Testing

Run all tests

```bash
dotnet test
```

---

## Swagger

Swagger UI:

```
https://localhost:xxxx/swagger
```

---

## Logging

Structured logging is implemented using Serilog.

---

## License

This project was created as part of a technical assessment and is intended for demonstration purposes.

---

## Author

**Shubham Sahu**

MCA Graduate | ASP.NET Core Developer

GitHub: https://github.com/Shubhamsahu2001