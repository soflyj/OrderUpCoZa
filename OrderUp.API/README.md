# 🧾 OrderUp – Multi-Tenant Web API (.NET 7)

OrderUp is a RESTful Web API built using **.NET 7** and the **Clean Architecture** approach.  
It supports **multi-tenancy**, **role-based access**, token authentication, logging, and full CRUD operations on `Orders` and `Products`.

---

## 📌 Overview

- ✅ Multi-tenancy support
- ✅ Users with `Vendor` (secured) and `Customer` (open) roles
- ✅ Products with image lists and inventory dictionary
- ✅ CRUD operations for Products and Orders
- ✅ IP, GeoLocation, Created/Updated timestamps logged
- ✅ SQL Server + EF Core + Migrations
- ✅ Docker support
- ✅ CI/CD using GitHub Actions
- ✅ Swagger UI for testing

---

## 📐 Project Architecture – Clean Architecture

OrderUp.sln
│
├── OrderUp.API → Web layer (Controllers, Middleware, Swagger)
├── OrderUp.Application → Business logic (Interfaces, Services, DTOs)
├── OrderUp.Domain → Core Entities and Enums
├── OrderUp.Infrastructure → JWT, IP lookup, Logging tools
├── OrderUp.Persistence → EF Core, Migrations, SQL Config
├── OrderUp.Tests → Unit tests (xUnit)
└── docker-compose.yml → Container orchestration

---

## ⚙️ Tech Stack

| Feature             | Technology                 |
|---------------------|----------------------------|
| Language            | C# (.NET 7)                |
| Database            | SQL Server                 |
| ORM                 | Entity Framework Core      |
| Auth                | JWT (15 min expiry for vendors) |
| Logging             | Custom Middleware + IP API |
| Tests               | xUnit                      |
| CI/CD               | GitHub Actions             |
| Containers          | Docker, Docker Compose     |

---

## 🧑‍💻 Requirements

- .NET 7 SDK
- SQL Server (or Docker)
- Docker (optional)
- Visual Studio / VS Code

---

## 🚀 Getting Started

### 1. Clone the Repository
--> bash
git clone https://github.com/your-org/orderup.git
cd orderup

### 2. Configure AppSettings
(OrderUp.API/appsettings.Development.json) :

{
  "ConnectionStrings": {
    "DefaultConnection": "Server=localhost;Database=OrderUpDb;User Id=sa;Password=12345678;"
  },
  "JwtSettings": {
    "Secret": "your-very-secure-secret-key",
    "ExpiryMinutes": 15
  },
  "IpStack": {
    "ApiKey": "your-ipstack-api-key"
  }
}

---

## 🗄️ Database Setup with EF Core

### Create Migrations
dotnet ef migrations add InitialCreate --project OrderUp.Persistence --startup-project OrderUp.API

### Apply Migrations
dotnet ef database update --project OrderUp.Persistence --startup-project OrderUp.API
(This creates the OrderUpDb database.

---

## 🧪 Authentication Guide

### Vendor Login
POST /api/Auth/vendor/login
{
  "email": "vendor@orderup.com",
  "password": "pass123"
}

(Returns a 15-min JWT token. Use it in Authorization: Bearer <token> headers.)

---

## 🔐 Roles & Security
Role	    Auth Required	Access Level
Vendor	    ✅ Token	    Full CRUD on products/orders
Customer	❌ None	        Can browse, create orders

---

## 🛠️ API Endpoints
### Products
GET    /api/products
GET    /api/products/{id}
POST   /api/products           (Vendor only)
PUT    /api/products/{id}      (Vendor only)
DELETE /api/products/{id}      (Vendor only)

### Orders
GET    /api/orders
GET    /api/orders/{id}
POST   /api/orders             (Authorized)
PUT    /api/orders/{id}        (Authorized)
DELETE /api/orders/{id}        (Authorized)

---

## 🌍 IP & Logging Middleware
All incoming requests are logged:

- Client IP
- Location (via IPStack API)
- Creation & Update Timestamps
- Persisted in RequestLogs table

---

## 🐳 Docker Setup
Build & Run

docker-compose up --build
Then visit: http://localhost:8080/swagger

---

## 🧪 Running Unit Tests

dotnet test

---

## 🔄 CI/CD (GitHub Actions)
Located in .github/workflows/dotnet.yml, CI pipeline:

- Restores dependencies
- Builds solution
- Runs tests
- Publishes API

Triggered on main branch commits.

---

## 🧪 Sample Users (Seeded)
Email	Password	Role
vendor@orderup.com	pass123	Vendor
customer@orderup.com	pass123	Customer

---

## 📫 Contact
Built by the OrderUp Engineering Team.
For questions or issues, open a GitHub issue or contact us via [developer@orderup.co.za].