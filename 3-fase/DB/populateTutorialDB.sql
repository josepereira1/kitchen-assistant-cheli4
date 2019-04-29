USE master
GO
IF NOT EXISTS (
   SELECT name
   FROM sys.databases
   WHERE name = N'TutorialDB'
)
CREATE DATABASE [TutorialDB]
GO

USE TutorialDB


-- Create a new table called 'Person' in schema 'dbo'
-- Drop the table if it already exists
IF OBJECT_ID('Person', 'U') IS NOT NULL
DROP TABLE Person
GO
-- Create the table in the specified schema
CREATE TABLE dbo.Person
(
   id                  INT    NOT NULL   PRIMARY KEY, -- primary key column
   name		[NVARCHAR](50)    NOT NULL,
   age                 INT    NOT NULL
);
GO

-- Insert rows into table 'Person'
INSERT INTO dbo.Person
   ([id],[name],[age])
VALUES
   ( 1, N'Ricardo', 20)
GO

-- Select rows from table 'Person'
SELECT * FROM dbo.Person;