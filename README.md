# ecom.API

[![ASP.NET Core](https://img.shields.io/badge/ASP.NET%20Core-0F0F11?style=for-the-badge&logo=dotnet&logoColor=512BD4)](https://dotnet.microsoft.com/)
[![Entity Framework Core](https://img.shields.io/badge/Entity%20Framework%20Core-0F0F11?style=for-the-badge&logo=dotnet&logoColor=512BD4)](https://learn.microsoft.com/ef/)
[![PostgreSQL](https://img.shields.io/badge/PostgreSQL-0F0F11?style=for-the-badge&logo=postgresql&logoColor=316192)](https://www.postgresql.org/)
[![SignalR](https://img.shields.io/badge/SignalR-0F0F11?style=for-the-badge&logo=signalr&logoColor=white)](https://learn.microsoft.com/aspnet/core/signalr/introduction)

Backend API for the e-commerce platform.
This solution contains authentication, product management, basket and order workflows, role-based authorization, file upload support, SignalR integration and infrastructure services.

## Overview

This repository contains the backend of the e-commerce platform.
It is designed to work together with the frontend repository below:

- [ecomClient](https://github.com/melihesensio99/ecomClient)

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

## Example Endpoints

### Authentication
- `POST /api/auth/login`
- `POST /api/auth/register`
- `GET /api/auth/me`

### Products
- `GET /api/products`
- `GET /api/products/{id}`
- `POST /api/products`
- `PUT /api/products/{id}`
- `DELETE /api/products/{id}`

### Basket and Orders
- `GET /api/baskets`
- `POST /api/baskets/items`
- `POST /api/orders`
- `GET /api/orders/{id}`

### Administration
- `GET /api/users`
- `GET /api/roles`
- `POST /api/authorization/endpoints`

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

## Notes

This repository is the backend part of the e-commerce platform. The frontend and backend are designed to work together as one product.
