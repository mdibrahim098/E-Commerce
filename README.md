# 🛒 E-Commerce Microservices Project (.NET 8)

This repository contains a fully containerised, production-ready **.NET 8-based E-Commerce Microservices Architecture**. It leverages **ASP.NET Core Web API, Minimal APIs, gRPC, CQRS, DDD, RabbitMQ, MassTransit, YARP API Gateway**, and multiple databases, including **PostgreSQL (Marten), SQL Server, Redis, and SQLite**.

---

## 🧱 Architecture Overview

- ✅ **Microservices Architecture** using REST/gRPC and Message-based communication
- ✅ **CQRS + DDD + Clean Architecture** + Vertical Slice pattern
- ✅ **Event-Driven Communication** using RabbitMQ & MassTransit
- ✅ **API Gateway** using YARP
- ✅ **Multi-Database** support: PostgreSQL (DocumentDB via Marten), Redis, SQLite, SQL Server
- ✅ **Dockerized** development with Docker Compose

---

## 🧰 Tech Stack

| Area               | Technology                                                                 |
|--------------------|-----------------------------------------------------------------------------|
| Framework          | .NET 8, C# 12                                                               |
| API Gateway        | YARP (Reverse Proxy)                                                        |
| Web APIs           | ASP.NET Core Web API, Minimal APIs                                          |
| Messaging          | RabbitMQ, MassTransit                                                       |
| Databases          | PostgreSQL (Marten), Redis, SQL Server, SQLite                             |
| ORM                | Entity Framework Core, Marten                                               |
| Caching            | Redis                                                                       |
| gRPC               | gRPC (Protobuf-based high performance sync messaging)                       |
| Architecture       | Clean Architecture, DDD, CQRS, Vertical Slice                               |
| Communication      | REST, gRPC (sync), RabbitMQ (async)                                         |
| Validation         | FluentValidation, MediatR Pipeline Behaviors                                |
| Containerization   | Docker, Docker Compose                                                      |
| Frontend (WebUI)   | ASP.NET Core Razor Pages + Bootstrap 4 + Refit                              |

---

## 📦 Microservices

### 1. 🧾 Catalog Service
- ASP.NET Core Minimal APIs
- PostgreSQL + Marten (Document DB)
- CQRS with MediatR
- Carter + Feature Folders
- Health checks, Logging, Exception Handling

### 2. 🛒 Basket Service
- ASP.NET Web API + REST
- Redis for distributed caching
- MassTransit for event publishing
- gRPC client to Discount Service
- Implements Decorator and Cache-aside patterns

### 3. 🎁 Discount Service
- ASP.NET Core gRPC Server
- SQLite + EF Core
- High-performance gRPC communication
- Protobuf contract sharing

### 4. 📦 Ordering Service
- Clean Architecture: Domain, Application, Infrastructure, Presentation
- SQL Server + EF Core
- CQRS + DDD + Domain Events
- Consumes BasketCheckout event (RabbitMQ)

### 5. 🚪 YARP API Gateway
- Reverse proxy routing to microservices
- Rate Limiting via FixedWindowLimiter
- Path transformation and header forwarding

### 6. 🌐 WebUI (ShoppingApp)
- ASP.NET Core Razor Pages
- Refit client for YARP-based APIs
- Tag Helpers, View Components, Razor Sections

---

## 📂 Project Structure

```plaintext
├── src
│   ├── Services
│   │   ├── Catalog
│   │   │   ├── Catalog.API
│   │   │   └── Catalog.Domain
│   │   ├── Basket
│   │   │   ├── Basket.API
│   │   ├── Discount
│   │   │   ├── Discount.gRPC
│   │   ├── Ordering
│   │   │   ├── Ordering.API
│   │   │   ├── Ordering.Application
│   │   │   ├── Ordering.Domain
│   │   │   └── Ordering.Infrastructure
│   ├── Gateways
│   │   └── Yarp.ApiGateway
│   ├── WebApps
│   │   └── ShoppingApp.WebUI
│   ├── BuildingBlocks
│   │   ├── EventBus.Messages
│   │   ├── Shared.Infrastructure
│   └── Docker
│       └── docker-compose.yml
