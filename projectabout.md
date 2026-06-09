# EventNews API - Project Overview

This document provides a deep dive into the architecture, layers, and functionality of the **EventNews** project.

## 1. Project Summary
**EventNews** is a .NET-based Web API designed for managing and delivering news content with support for multiple languages and media. It features a robust authentication system and a clear separation of concerns using the Repository/Service pattern.

## 2. Technology Stack
- **Framework:** ASP.NET Core (.NET 5.0/6.0 style)
- **Database:** PostgreSQL (using Npgsql.EntityFrameworkCore.PostgreSQL)
- **ORM:** Entity Framework Core
- **Authentication:** JWT Bearer Token with OTP (One-Time Password) via Email
- **Documentation:** Swagger (OpenAPI)
- **Caching:** In-memory caching for OTP storage
- **Logging/Middleware:** Standard ASP.NET Core middleware

## 3. Architecture & Layers

The project follows an N-layer architecture, ensuring modularity and testability.

### A. Domain Layer (`Models/Entities`, `Models/Enums`)
Defines the core business objects and their relationships.
- **`News`**: The central entity supporting localization (Uzbek, Russian, English, Cyrillic) for titles and content.
- **`User`**: Manages user credentials, roles, and states.
- **`FileEntity`**: Represents uploaded files (images) with their physical paths/URLs.
- **`NewsImage`**: A junction entity linking News to Files, specifying the image type (e.g., Original).

### B. Data Access Layer (`Context`, `Repositories`)
Handles all interactions with the database.
- **`ApplicationDbContext`**: The EF Core context implementing `IApplicationDbContext`. It manages the database sets and migrations.
- **Repositories**: Provide an abstraction over the DB context.
    - `NewsRepository`: CRUD operations for news.
    - `UserRepository`: CRUD operations for users.
    - `NewsImagesRepository`: Manages associations between news and images.

### C. Business Logic Layer (`Services`)
Contains the application's core logic and orchestrates data movement.
- **`NewsService`**: Handles news lifecycle, including fetching localized content and associated images.
- **`AuthService`**: Manages registration, login, OTP generation, email dispatch, and JWT generation.
- **`FileService`**: Manages physical file storage on the server and database entry creation.
- **`NewsImagesService`**: Manages the linking of uploaded files to specific news items.
- **`EmailSender`**: (Abstraction) Handles sending OTPs to users' emails.

### D. API Layer (`Controllers`)
Exposes the functionality through RESTful endpoints.
- **`ClientNewsController`**: Public endpoints for reading news (unauthorized).
- **`NewsController`**: Admin-only endpoints for CRUD operations on news (requires Role "1").
- **`AuthController`**: Endpoints for Register, Login, and OTP Verification.
- **`FilesController`**: Endpoints for file management and retrieval.

### E. Data Mapping & DTOs (`DTOs`, `Converters`)
Ensures that internal entities are not exposed directly to the API consumers.
- **DTOs**: `CreateNews`, `UpdateNews`, `NewsModel`, `RegisterDTO`, `LoginDTO`, etc.
- **Converters**: Static extension methods (e.g., `NewsConverter`) to map between Entities and DTOs.

### F. Abstractions (`Abstractions`)
Interfaces that define the contracts for repositories and services, enabling Dependency Injection and easier testing.

---

## 4. Key Features

### 🌍 Multilingual Support
The `News` entity and `TakeLocalized` extension methods allow the system to store and retrieve content in four formats:
- Uzbek (`Uz`)
- Russian (`Ru`)
- English (`En`)
- Cyrillic (`Crlyc`)

### 🔐 Security & Auth Flow
1. **Registration**: User registers with email/password.
2. **Login**: User provides credentials. If valid, the system generates a 6-digit OTP and sends it to their email.
3. **OTP Verification**: User provides the OTP. If it matches the cached value, a JWT token is issued.
4. **Role-Based Access**: The `NewsController` is restricted to users with Role "1" (Admin).

### 📁 File Management
Images are uploaded to the `wwwroot/uploads` folder. The system generates a unique GUID for each file to prevent naming collisions and stores metadata in the `Files` table.

---

## 5. Database Schema
- **`Users`**: `Id`, `Email`, `Password`, `Salt`, `Role`, `State`, `CreatedDate`.
- **`News`**: `Id`, `Title[Lang]`, `Content[Lang]`, `ShortContent[Lang]`, `PublishedAt`, `State`.
- **`Files`**: `Id`, `FileName`, `Extension`, `Url`, `CreatedAt`.
- **`NewsImages`**: `Id`, `NewsId`, `FileId`, `Type`, `IsVisible`.

---

## 6. Directory Structure Overview
- `Abstractions/`: Interface definitions.
- `Context/`: EF Core DB context.
- `Controllers/`: API endpoints.
- `Converters/`: Entity-to-DTO mapping logic.
- `DTOs/`: Data Transfer Objects.
- `Migrations/`: EF Core database migrations.
- `Models/`: Entities, Enums, and Localization logic.
- `Repositories/`: Data access implementations.
- `Services/`: Business logic implementations.
- `wwwroot/`: Static files and uploads.
