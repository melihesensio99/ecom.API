# ecom.API

Backend API for the e-commerce platform.
This solution contains authentication, product management, basket and order workflows, role-based authorization, file upload support, SignalR integration and infrastructure services.

## Features

- JWT authentication and refresh token flows
- Google and Facebook external login support
- Product management
- Basket management
- Order management and order completion
- User and role management
- Authorization endpoint management
- File upload and storage integration
- Real-time updates with SignalR
- FluentValidation-based request validation
- Global exception handling
- Structured logging with Serilog
- PostgreSQL persistence

## Solution Structure

- `ETicaret.WEBAPI` - ASP.NET Core API host
- `Core/ETicaretAPI.Application` - application layer, commands, queries, DTOs and contracts
- `Core/ETicaretAPI.Domain` - domain entities and shared abstractions
- `Infrastructure/ETicaretAPI.Infrastructure` - integrations, filters, services and cross-cutting concerns
- `Infrastructure/ETicaretAPI.Persistence` - database context, repositories and migrations
- `Infrastructure/ETicaretAPI.SignalR` - hubs and real-time communication

## Technology Stack

- ASP.NET Core
- Entity Framework Core
- PostgreSQL
- JWT Bearer authentication
- SignalR
- FluentValidation
- Serilog
- AWS storage integration

## Configuration

Update `ETicaret.WEBAPI/appsettings.json` with:

- PostgreSQL connection string
- JWT token settings
- External login credentials
- Storage settings
- Mail settings
- Frontend URL

## Running the API

```bash
dotnet restore
dotnet build
dotnet run --project ETicaret.WEBAPI
```

In development, Swagger is available from the API host.

## Related Repository

Frontend: [ecomClient](https://github.com/melihesensio99/ecomClient)

## Notes

This repository is the backend part of the e-commerce platform. The frontend and backend are designed to work together as one product.