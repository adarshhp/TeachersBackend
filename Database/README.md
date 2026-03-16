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

Run the following SQL script:

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
CREATE INDEX IF NOT EXISTS "IX_Users_Email" ON "Users" ("Email");
```

## Step 4: Verify Tables

Check if the table was created:

```sql
SELECT table_name 
FROM information_schema.tables 
WHERE table_schema = 'public' 
ORDER BY table_name;
```

View table structure:

```sql
SELECT column_name, data_type, character_maximum_length, is_nullable
FROM information_schema.columns
WHERE table_name = 'Users'
ORDER BY ordinal_position;
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
  "DefaultConnection": "Host=localhost;Port=5432;Database=Delete;Username=postgres;Password=postgres"
}
```

## Test Your Setup

1. Create the database and tables using the SQL above
2. Run your API: `dotnet run`
3. Test registration endpoint at: `http://localhost:5103/api/auth/register`
4. Test login endpoint at: `http://localhost:5103/api/auth/login`
