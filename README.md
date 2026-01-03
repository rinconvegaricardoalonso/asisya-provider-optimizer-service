# Provider Optimizer Service

## 📌 Overview

**Provider Optimizer Service** is a backend microservice built with **.NET (Clean Architecture)** whose goal is to automatically select the *best available provider* for a roadside assistance request (crane, locksmith, battery, etc.) based on **real geographic distance (Haversine)**, availability, vehicle type, and rating.

This project was designed as a **technical exercise / real-world microservice**, following best practices for architecture, persistence, Dockerization, and maintainability.

---

## 🏗️ Architecture

The project follows **Clean Architecture**, clearly separating responsibilities and dependencies:

```
ProviderOptimizerService
│
├── ProviderOptimizerService.Api            # Presentation layer (HTTP / Controllers)
├── ProviderOptimizerService.Application    # Use cases, DTOs, interfaces
├── ProviderOptimizerService.Domain         # Domain entities and business rules
├── ProviderOptimizerService.Infrastructure # Persistence, EF Core, repositories, seeders
└── docker-compose.yml
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

## 🐳 Docker Support

The project is fully containerized using **Docker & Docker Compose**.

### Services

- **API** – .NET Web API
- **PostgreSQL** – relational database

### Run the project

```bash
docker compose up --build
```

### Access

- **API**: http://localhost:8080
- **Swagger**: http://localhost:8080/swagger

---

## ⚙️ Configuration

### Environment-based configuration

- `appsettings.json` → local
- `appsettings.Docker.json` → Docker environment

Connection strings are automatically resolved depending on the environment.

---

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

**Ready to run. Ready to review. Ready for production discussions. 🚀**

