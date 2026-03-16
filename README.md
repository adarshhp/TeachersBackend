# MyWebApi - Authentication API

## Project Structure

```
MyWebApi/
├── Controllers/          # API Controllers
│   └── AuthController.cs
├── DBContexts/          # Database Context
│   └── ApplicationDbContext.cs
├── Models/              # Domain Models
│   ├── DTOs/           # Data Transfer Objects
│   │   ├── LoginRequest.cs
│   │   ├── RegisterRequest.cs
│   │   └── AuthResponse.cs
│   └── User.cs
├── Repositories/        # Repository Pattern
│   ├── Impl/           # Repository Implementations
│   │   └── Repository.cs
│   └── IRepository.cs  # Repository Interface
├── Services/           # Business Logic Layer
│   ├── Impl/          # Service Implementations
│   │   └── AuthService.cs
│   └── IAuthService.cs  # Service Interface
└── Program.cs         # Application Entry Point
```

## Architecture

This project implements the **Service-Repository Pattern** with authentication:
- **Controllers**: Handle HTTP requests and responses
- **Services**: Contain business logic for authentication
- **Repositories**: Handle data access operations
- **Models**: Define data structures (User, DTOs)
- **DbContext**: EntityFramework Core database context

## API Endpoints

### Authentication

#### Register a new user
```http
POST http://localhost:5103/api/auth/register
Content-Type: application/json

{
  "name": "John Doe",
  "email": "john.doe@example.com",
  "password": "password123"
}
```

**Response:**
```json
{
  "userId": 1,
  "name": "John Doe",
  "email": "john.doe@example.com",
  "token": "base64encodedtoken",
  "message": "Registration successful"
}
```

#### Login
```http
POST http://localhost:5103/api/auth/login
Content-Type: application/json

{
  "email": "john.doe@example.com",
  "password": "password123"
}
```

**Response:**
```json
{
  "userId": 1,
  "name": "John Doe",
  "email": "john.doe@example.com",
  "token": "base64encodedtoken",
  "message": "Login successful"
}
```

## Validation Rules

### Registration
- **Name**: Required, 2-100 characters
- **Email**: Required, valid email format
- **Password**: Required, minimum 6 characters

### Login
- **Email**: Required, valid email format
- **Password**: Required

## Running the Application

```bash
cd MyWebApi
dotnet run
```

The API will be available at: `http://localhost:5103`

## Swagger Documentation

Access the interactive API documentation at:
```
http://localhost:5103/
```

## Technologies Used

- .NET 9.0
- ASP.NET Core Web API
- Entity Framework Core (InMemory Database)
- Dependency Injection
- Service-Repository Pattern
- Swagger/OpenAPI

## Security Notes

⚠️ **Important**: This implementation uses basic password hashing (SHA256) for demonstration purposes. For production applications, you should:
- Use **bcrypt**, **Argon2**, or **ASP.NET Core Identity** for password hashing
- Implement **JWT tokens** for authentication
- Add **HTTPS** support
- Implement proper token validation and refresh mechanisms
- Add rate limiting for login attempts
- Store sensitive data securely

