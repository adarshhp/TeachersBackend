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
