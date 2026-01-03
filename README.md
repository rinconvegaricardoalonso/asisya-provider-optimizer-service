# Provider Optimizer Service

Backend service built with **.NET 8** following **Clean Architecture**, designed to manage and optimize provider availability.  
The project includes a complete **CI/CD pipeline** using **GitHub Actions**, containerization with **Docker**, and automated testing.

## 🧱 Architecture

The solution follows **Clean Architecture** principles and is structured into the following layers:

```
ProviderOptimizerService
├── ProviderOptimizerService.Api
├── ProviderOptimizerService.Application
├── ProviderOptimizerService.Domain
├── ProviderOptimizerService.Infrastructure
├── tests
│   ├── ProviderOptimizerService.Application.Tests
│   └── ProviderOptimizerService.IntegrationTests
└── ProviderOptimizerService.sln
```


### Layer Responsibilities

- **Domain**
  - Core business entities (`Provider`)
  - Business rules
  - No dependency on frameworks

- **Application**
  - Use cases (`OptimizeProviderUseCase`)
  - Interfaces (repositories)
  - DTOs

- **Infrastructure**
  - Entity Framework Core
  - PostgreSQL persistence
  - Repository implementations
  - Database seeding

- **API**
  - Controllers
  - Dependency Injection
  - Swagger

---

## 🚀 Functional Scope (Exercise)

From a broader assistance flow, **only point #4 is implemented**:

> **4. Calculate the optimal provider** (ETA, distance, availability, rating)

### Implemented Endpoints

#### 🔹 Get available providers

```
GET /providers/available
```

Returns all providers currently marked as available.

---

#### 🔹 Optimize provider selection

```
POST /providers/optimize
```

**Request body**:

```json
{
  "vehicleLatitude": 7.8891,
  "vehicleLongitude": -72.4967,
  "vehicleType": "Car"
}
```

**Response**:

```json
{
  "providerId": 1,
  "providerName": "Provider Centro",
  "distanceKm": 1.25,
  "estimatedEtaMinutes": 4,
  "rating": 4.8,
  "vehicleType": "Car"
}
```

---

## 📐 Optimization Algorithm

The provider selection is based on:

- **Availability** (`IsAvailable = true`)
- **Vehicle type compatibility**
- **Real geographic distance** using the **Haversine formula**
- **Estimated ETA**, derived from distance
- **Rating**, used as a tie-breaker

The closest valid provider is selected as the optimal one.

---

## 🗄️ Persistence

- **Database**: PostgreSQL
- **ORM**: Entity Framework Core
- **Migrations**: Enabled and applied automatically on startup
- **Seeder**: Inserts initial provider data if the database is empty

### Provider Table (simplified)

- Id (auto-increment)
- Name
- Address
- Latitude
- Longitude
- IsAvailable
- VehicleType
- Rating

---

## 🧪 Testing Strategy

### Unit Tests
- Implemented using **xUnit**
- Mocking with **Moq**
- Assertions with **FluentAssertions**
- Focused on application/use-case logic

### Integration Tests
- Uses `WebApplicationFactory<Program>`
- Validates real HTTP endpoints
- Runs against a real PostgreSQL instance (via Docker Compose)
- Example tested endpoint:
  - `GET /providers/available`

> Integration tests are excluded from CI execution to avoid external dependencies.

---

## 🐳 Docker

The application is fully containerized using a **multi-stage Dockerfile**.

### Build image locally

```bash
docker build -t provider-optimizer-service .
```

### Run with Docker Compose

```bash
docker compose up
```

This starts:
- API container
- PostgreSQL container
- Proper network configuration between services

---

## ⚙️ Configuration

### Environment-based configuration

- `appsettings.json` → local
- `appsettings.Docker.json` → Docker environment

Connection strings are automatically resolved depending on the environment.

---

## ⚙️ CI/CD Pipeline (GitHub Actions)

The project includes a complete **CI/CD pipeline** located at:

```
.github/workflows/ci.yml
```

### Pipeline stages

#### Pull Requests
Executed on `pull_request` to `main` and `develop`:

- Restore dependencies
- Build solution
- Lint (`dotnet format`)
- Run unit tests

> Docker build is intentionally **skipped** in PRs to keep validation fast.

---

#### Push (main / develop)
Executed on `push` to `main` and `develop`:

- Restore dependencies
- Build solution
- Lint (`dotnet format`)
- Run unit tests
- Build Docker image

---

### Linting

Linting is enforced using:

```bash
dotnet format --verify-no-changes
```

The pipeline fails if formatting issues are detected.

---

## ☁️ (Optional) AWS ECR Push Configuration

The pipeline includes **commented configuration** to push the Docker image to **Amazon ECR**, demonstrating cloud deployment readiness.

```yaml
# - name: Configure AWS credentials
#   uses: aws-actions/configure-aws-credentials@v4
#   with:
#     aws-access-key-id: ${{ secrets.AWS_ACCESS_KEY_ID }}
#     aws-secret-access-key: ${{ secrets.AWS_SECRET_ACCESS_KEY }}
#     aws-region: us-east-1

# - name: Login to Amazon ECR
#   uses: aws-actions/amazon-ecr-login@v2

# - name: Build, tag and push image to ECR
#   run: |
#     IMAGE_URI=${{ secrets.AWS_ACCOUNT_ID }}.dkr.ecr.us-east-1.amazonaws.com/provider-optimizer-service:latest
#     docker tag provider-optimizer-service:latest $IMAGE_URI
#     docker push $IMAGE_URI
```

> This configuration is intentionally commented to avoid requiring real credentials for the exercise.

---

## 🧠 Key Design Decisions

- Clean Architecture for maintainability and scalability
- Separation of CI validation vs artifact generation
- Docker build only on push, not on pull requests
- Integration tests isolated from CI to avoid infrastructure coupling
- Production-ready pipeline structure

---

## 🚀 Tech Stack

- .NET 8
- ASP.NET Core
- Entity Framework Core
- PostgreSQL
- Docker & Docker Compose
- GitHub Actions
- xUnit, Moq, FluentAssertions

---

## ✅ Status

✔ Clean Architecture  
✔ Unit tests  
✔ Integration test  
✔ Dockerized  
✔ CI/CD pipeline  
✔ Lint enforcement  
✔ Cloud-ready (ECR config)

## 🧪 Development Notes

- Swagger is enabled in Docker for easier testing
- HTTPS redirection is disabled inside containers
- Seeder runs only once (checks if data exists)

---

## ✅ What This Project Demonstrates

- Clean Architecture applied correctly
- Proper separation of concerns
- Real-world Dockerized microservice
- EF Core migrations and seeding
- Algorithmic reasoning (distance-based optimization)
- Production-ready structure

---

## 📈 Possible Improvements

- Provider ranking with weighted score
- Caching available providers
- Unit and integration tests
- Authentication / authorization
- Real-time tracking (WebSockets)

---

## 👤 Author

Ricardo Alonso Rincón Vega

---
