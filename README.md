# Kitchen Store

A full-stack e-commerce system for kitchenware: an **Angular 17** client and an **ASP.NET Core (.NET 8)** server built in a layered N-Tier architecture with **Entity Framework Core (Code First)** and SQL Server.

## Features

- Product catalog with categories and a product details page
- Shopping cart, checkout / payment page and order history
- User registration and login
- Custom Angular directives and pipes, styled with Bootstrap
- Server-side rendering support (`@angular/ssr`)

## Architecture

```
server/
├── WebApi          # Controllers: Category, Product, ProdForCart, Order, User (+ Swagger)
├── BLL             # Business logic services
├── IBll            # Service interfaces
├── KitchenServer   # Data access (repositories), EF Core entities, migrations, AutoMapper profile
├── IRepository     # Repository interfaces
└── DTO             # Data transfer objects shared between layers
client/             # Angular 17 application
```

- **Dependency Injection** between all layers through interfaces
- **AutoMapper** for entity ↔ DTO mapping
- **EF Core Code First** with migrations

## Tech Stack

| Client | Server | Database |
|---|---|---|
| Angular 17, TypeScript, RxJS, Bootstrap | ASP.NET Core Web API (.NET 8), AutoMapper, Swagger | SQL Server, EF Core |

## Getting Started

**Server**
1. Update the SQL Server connection string in `server/WebApi/Program.cs`.
2. Apply the migrations: `dotnet ef database update` (from the `KitchenServer` project).
3. Run the API: `dotnet run --project server/WebApi`.

**Client**
```bash
cd client
npm install
npm start
```
The client expects the API at `https://localhost:7186`.
