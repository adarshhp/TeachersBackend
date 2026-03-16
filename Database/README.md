# Database Setup Instructions

## PostgreSQL Connection Details
- **Host**: localhost
- **Port**: 5432
- **Database**: Delete
- **Username**: postgres
- **Password**: postgres

## Step 1: Create Database

Open pgAdmin or psql terminal and run:

```sql
CREATE DATABASE "Delete";
```

## Step 2: Connect to Database

In psql:
```bash
psql -U postgres -d Delete
```

Or use pgAdmin and connect to the "Delete" database.

## Step 3: Create Tables

Run the following SQL scripts to create both Users and Teachers tables:

```sql
-- Create Users table
CREATE TABLE IF NOT EXISTS "Users" (
    "Id" SERIAL PRIMARY KEY,
    "Name" VARCHAR(100) NOT NULL,
    "Email" VARCHAR(100) NOT NULL UNIQUE,
    "PasswordHash" VARCHAR(500) NOT NULL,
    "CreatedAt" TIMESTAMP NOT NULL DEFAULT CURRENT_TIMESTAMP
);

-- Create index on Email for faster lookups
CREATE UNIQUE INDEX IF NOT EXISTS "IX_Users_Email" ON "Users" ("Email");

-- Create Teachers table
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

-- Create index on Email for faster lookups
CREATE UNIQUE INDEX IF NOT EXISTS "IX_Teachers_Email" ON "Teachers" ("Email");

-- Create index on IsActive for filtering active teachers
CREATE INDEX IF NOT EXISTS "IX_Teachers_IsActive" ON "Teachers" ("IsActive");
```

## Step 4: Verify Tables

Check if all tables were created:

```sql
SELECT table_name 
FROM information_schema.tables 
WHERE table_schema = 'public' 
ORDER BY table_name;
```

View Users table structure:

```sql
SELECT column_name, data_type, character_maximum_length, is_nullable
FROM information_schema.columns
WHERE table_name = 'Users'
ORDER BY ordinal_position;
```

View Teachers table structure:

```sql
SELECT column_name, data_type, character_maximum_length, is_nullable
FROM information_schema.columns
WHERE table_name = 'Teachers'
ORDER BY ordinal_position;

-- Test teachers
INSERT INTO "Teachers" ("Name", "Email", "Phone", "Subject", "Qualification", "JoiningDate", "IsActive", "CreatedAt", "UpdatedAt")
VALUES 
    ('John Smith', 'john.smith@school.com', '+1234567890', 'Mathematics', 'MSc Mathematics', '2024-01-15', true, CURRENT_TIMESTAMP, CURRENT_TIMESTAMP),
    ('Jane Doe', 'jane.doe@school.com', '+9876543210', 'Physics', 'PhD Physics', '2024-02-20', true, CURRENT_TIMESTAMP, CURRENT_TIMESTAMP),
    ('Robert Brown', 'robert.brown@school.com', '+1122334455', 'Chemistry', 'MSc Chemistry', '2024-03-10', true, CURRENT_TIMESTAMP, CURRENT_TIMESTAMP);
```

## Step 5: (Optional) Insert Test Data

```sql
-- Test user with password 'test123'
INSERT INTO "Users" ("Name", "Email", "PasswordHash", "CreatedAt")
VALUES 
    ('Test User', 'test@example.com', 'ecd71870d1963316a97e3ac3408c9835ad8cf0f3c1bc703527c30265534f75ae', CURRENT_TIMESTAMP);
```

## Connection String in appsettings.json

The connection string is already configured as:
```json
"ConnectionStrings": {
  "DefaultConnection": "Host= from the MyWebApi directory
3. Test authentication endpoints:
   - Register: `http://localhost:5103/api/auth/register`
   - Login: `http://localhost:5103/api/auth/login`
4. Test teachers endpoints:
   - Get all teachers: `http://localhost:5103/api/teachers`
   - Create teacher: `POST http://localhost:5103/api/teachers`
   - Update teacher: `PUT http://localhost:5103/api/teachers/{id}`
   - Delete teacher: `DELETE http://localhost:5103/api/teachers/{id}`
5. Access Swagger UI at: `http://localhost:5103/`

## Database Schema Summary

### Users Table
- **Id**: Auto-incrementing primary key
- **Name**: Teacher's full name (max 100 chars)
- **Email**: Unique email address (max 100 chars)
- **PasswordHash**: Hashed password (max 500 chars)
- **CreatedAt**: Account creation timestamp

### Teachers Table
- **Id**: Auto-incrementing primary key
- **Name**: Teacher's full name (max 100 chars)
- **Email**: Unique email address (max 100 chars)
- **Phone**: Contact number (max 20 chars, optional)
- **Subject**: Teaching subject (max 100 chars)
- **Qualification**: Educational qualification (max 200 chars, optional)
- **JoiningDate**: Date teacher joined
- **IsActive**: Active status (boolean, default: true)
- **CreatedAt**: Record creation timestamp
- **UpdatedAt**: Last update timestamp

## Test Your Setup

1. Create the database and tables using the SQL above
2. Run your API: `dotnet run`
3. Test registration endpoint at: `http://localhost:5103/api/auth/register`
4. Test login endpoint at: `http://localhost:5103/api/auth/login`
