-- ================================================
-- Database: Delete
-- Description: SQL script to create tables for MyWebApi
-- ================================================

-- Connect to the Delete database first
-- \c Delete

-- ================================================
-- Table: Users
-- Description: Stores user authentication details
-- ================================================

CREATE TABLE IF NOT EXISTS "Users" (
    "Id" SERIAL PRIMARY KEY,
    "Name" VARCHAR(100) NOT NULL,
    "Email" VARCHAR(100) NOT NULL UNIQUE,
    "PasswordHash" VARCHAR(500) NOT NULL,
    "CreatedAt" TIMESTAMP NOT NULL DEFAULT CURRENT_TIMESTAMP
);

-- Create index on Email for faster lookups
CREATE INDEX IF NOT EXISTS "IX_Users_Email" ON "Users" ("Email");

-- ================================================
-- Sample Data (Optional - Comment out if not needed)
-- ================================================

-- Insert a test user (password is 'test123' hashed with SHA256)
-- You can uncomment this to create a test user
/*
INSERT INTO "Users" ("Name", "Email", "PasswordHash", "CreatedAt")
VALUES 
    ('Test User', 'test@example.com', 'ecd71870d1963316a97e3ac3408c9835ad8cf0f3c1bc703527c30265534f75ae', CURRENT_TIMESTAMP)
ON CONFLICT ("Email") DO NOTHING;
*/

-- ================================================
-- Verify Tables Created
-- ================================================

-- List all tables
SELECT table_name 
FROM information_schema.tables 
WHERE table_schema = 'public' 
ORDER BY table_name;

-- Show Users table structure
SELECT column_name, data_type, character_maximum_length, is_nullable
FROM information_schema.columns
WHERE table_name = 'Users'
ORDER BY ordinal_position;
