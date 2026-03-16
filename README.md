# MyWebApi - Full-Stack Web API with Authentication & Teachers CRUD

## Project Structure

```
MyWebApi/
├── Controllers/          # API Controllers
│   ├── AuthController.cs
│   └── TeachersController.cs
├── DBContexts/          # Database Context
│   └── ApplicationDbContext.cs
├── Models/              # Domain Models
│   ├── DTOs/           # Data Transfer Objects
│   │   ├── LoginRequest.cs
│   │   ├── RegisterRequest.cs
│   │   ├── AuthResponse.cs
│   │   ├── TeacherRequest.cs
│   │   └── TeacherResponse.cs
│   ├── User.cs
│   └── Teacher.cs
├── Repositories/        # Repository Pattern
│   ├── Impl/           # Repository Implementations
│   │   └── Repository.cs
│   └── IRepository.cs  # Repository Interface
├── Services/           # Business Logic Layer
│   ├── Impl/          # Service Implementations
│   │   ├── AuthService.cs
│   │   └── TeacherService.cs
│   ├── IAuthService.cs  # Service Interface
│   └── ITeacherService.cs
└── Program.cs         # Application Entry Point
```

## Architecture

This project implements the **Service-Repository Pattern** with authentication and CRUD operations:
- **Controllers**: Handle HTTP requests and responses
- **Services**: Contain business logic for authentication and teachers management
- **Repositories**: Handle data access operations
- **Models**: Define data structures (User, Teacher, DTOs)
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

### Teachers Management

#### Get all teachers
```http
GET http://localhost:5103/api/teachers
```

**Response:**
```json
[
  {
  # Teacher
- **Name**: Required, 2-100 characters
- **Email**: Required, valid email format, unique
- **Phone**: Optional, valid phone format, max 20 characters
- **Subject**: Required, 2-100 characters
- **Qualification**: Optional, max 200 characters
- **JoiningDate**: Required, valid date
- **IsActive**: Optional, boolean (default: true)

## Database Setup

**Important**: Before running the application, you must set up the PostgreSQL database and create the required tables.

### PostgreSQL Connection Details
- **Host**: localhost
- **Port**: 5432
- **Database**: Delete
- **Username**: postgres
- **Password**: postgres

### Create Database and Tables

1. **Create the database** (using pgAdmin or psql):
```sql
CREATE DATABASE "Delete";
```

2. **Connect to the database**:
```bash
psql -U postgres -d Delete
```

3. **Create the Users table**:
```sql
CREATE TABLE IF NOT EXISTS "Users" (
    "Id" SERIAL PRIMARY KEY,
    "Name" VARCHAR(100) NOT NULL,
    "Email" VARCHAR(100) NOT NULL UNIQUE,
    "PasswordHash" VARCHAR(500) NOT NULL,
    "CreatedAt" TIMESTAMP NOT NULL DEFAULT CURRENT_TIMESTAMP
);

CREATE UNIQUE INDEX IF NOT EXISTS "IX_Users_Email" ON "Users" ("Email");
```

4. **Create the Teachers table**:
```sql
CREATE TABLE IF NOT EXISTS "Teachers" (
    "Id" SERIAL PRIMARY KEY,
    "Name" VARCHAR(100) NOT NULL,
    "Email" VARCHAR(100) NOT NULL UNIQUE,
    "Phone" VARCHAR(20),
    "Subject" VARCHAR(100) NOT NULL,
    "Qualification" VARCHAR(200),
    "JoiningDate" TIMESTAMP NOT NULL,
    "IsActive" BOOLEAN NOT NULL DEFAULT true,
    "CreatedAt" TIMESTAMP NOT NULL DEFAULT CURRENT_TIMESTAMP,
    "UpdatedAt" TIMESTAMP NOT NULL DEFAULT CURRENT_TIMESTAMP
);

CREATE UNIQUE INDEX IF NOT EXISTS "IX_Teachers_Email" ON "Teachers" ("Email");
CREATE INDEX IF NOT EXISTS "IX_Teachers_IsActive" ON "Teachers" ("IsActive");
```

5. **Verify tables were created**:
```sql
SELECT table_name 
FROM information_schema.tables 
WHERE table_schema = 'public' 
ORDER BY table_name;
```

##  "id": 1,
    "name": "John Smith",
    "email": "john.smith@school.com",
    "phone": "+1234567890",
    "subject": "Mathematics",
    "qualification": "MSc Mathematics",
    "joiningDate": "2024-01-15T00:00:00",
    "isActive": true,
    "createdAt": "2024-01-15T10:30:00",
    "updatedAt": "2024-01-15T10:30:00"
  }
]
```

#### Get teacher by ID
```http
GET http://localhost:5103/api/teachers/1
```

**Response:**
```json
{
  "id": 1,
  "name": "John Smith",
  "email": "john.smith@school.com",
  "phone": "+1234567890",
  "subject": "Mathematics",
  "qualification": "MSc Mathematics",
  "joiningDate": "2024-01-15T00:00:00",
  "isActive": true,
  "createdAt": "2024-01-15T10:30:00",
  "updatedAt": "2024-01-15T10:30:00"
}
```

#### Create a new teacher
```http
POST http://localhost:5103/api/teachers
Content-Type: application/json

{
  "name": "John Smith",
  "email": "john.smith@school.com",
  "phone": "+1234567890",
  "subject": "Mathematics",
  "qualification": "MSc Mathematics",
  "joiningDate": "2024-01-15T00:00:00",
  "isActive": true
}
```

**Response:** (201 Created)
```json
{
  "id": 1,
  "name": "John Smith",
  "email": "john.smith@school.com",
  "phone": "+1234567890",
  "subject": "Mathematics",
  "qualification": "MSc Mathematics",
  "joiningDate": "2024-01-15T00:00:00",
  "isActive": true,
  "createdAt": "2024-01-15T10:30:00",
  "updatedAt": "2024-01-15T10:30:00"
}
```9.0.10
- PostgreSQL (Npgsql 9.0.2)
- Dependency Injection
- Service-Repository Pattern
- Swagger/OpenAPI (Swashbuckle 7.2.0)
- CORS enabled for frontend integration
PUT http://localhost:5103/api/teachers/1
Content-Type: application/json

{
  "name": "John Smith",
  "email": "john.smith@school.com",
  "phone": "+1234567890",
  "subject": "Advanced Mathematics",
  "qualification": "PhD Mathematics",
  "joiningDate": "2024-01-15T00:00:00",
  "isActive": true
}
```

**Response:**
```json
{
  "id": 1,
  "name": "John Smith",
  "email": "john.smith@school.com",
  "phone": "+1234567890",
  "subject": "Advanced Mathematics",
  "qualification": "PhD Mathematics",
  "joiningDate": "2024-01-15T00:00:00",
  "isActive": true,
  "createdAt": "2024-01-15T10:30:00",
  "updatedAt": "2024-03-16T14:20:00"
}
```

#### Delete a teacher
```http
DELETE http://localhost:5103/api/teachers/1
```

**Response:** (204 No Content)

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

