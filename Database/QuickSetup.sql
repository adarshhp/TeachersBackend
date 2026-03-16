-- ================================================
-- Quick Setup: Run these commands in order
-- ================================================

-- 1. CREATE THE DATABASE (Run in default postgres database)
CREATE DATABASE "Delete";

-- 2. CONNECT TO THE DATABASE
-- In psql: \c Delete
-- In pgAdmin: Right-click and select "Delete" database

-- 3. CREATE USERS TABLE
CREATE TABLE "Users" (
    "Id" SERIAL PRIMARY KEY,
    "Name" VARCHAR(100) NOT NULL,
    "Email" VARCHAR(100) NOT NULL UNIQUE,
    "PasswordHash" VARCHAR(500) NOT NULL,
    "CreatedAt" TIMESTAMP NOT NULL DEFAULT CURRENT_TIMESTAMP
);

-- 4. CREATE INDEX ON EMAIL
CREATE INDEX "IX_Users_Email" ON "Users" ("Email");

-- 5. VERIFY TABLE WAS CREATED
SELECT * FROM "Users";

-- Done! Your database is ready.
