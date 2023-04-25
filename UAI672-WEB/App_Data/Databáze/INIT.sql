IF NOT EXISTS (SELECT name FROM sys.databases WHERE name = 'UAI672_Database')
    BEGIN
        CREATE DATABASE UAI672_Database
    END
GO

USE UAI672_Database
GO

IF NOT EXISTS (SELECT * FROM sys.schemas WHERE name = 'Persons')
    BEGIN
        EXEC ('CREATE SCHEMA Persons')
    END
GO

IF EXISTS (SELECT * FROM sys.foreign_keys WHERE name = 'FK_Details_Addresses')
    BEGIN
        ALTER TABLE Persons.Details
        DROP CONSTRAINT FK_Details_Addresses
    END

-- Create the Addresses table in the Persons schema
DROP TABLE IF EXISTS Persons.Addresses
GO

CREATE TABLE Persons.Addresses
(
    AddressID INT IDENTITY(1,1) PRIMARY KEY,
    City      NVARCHAR(255),
    Street    NVARCHAR(255),
    Number    INT
)
GO

-- Insert some example data into the Addresses table
SET IDENTITY_INSERT Persons.Addresses ON
GO

INSERT INTO Persons.Addresses (AddressID, City, Street, Number) VALUES (1, N'České Budějovice', N'Ulice 1', 122);
INSERT INTO Persons.Addresses (AddressID, City, Street, Number) VALUES (2, N'Praha', N'Ulice 2', 12);
INSERT INTO Persons.Addresses (AddressID, City, Street, Number) VALUES (3, N'Český Krumlov', N'Ulice 3', 58);

GO

SET IDENTITY_INSERT Persons.Addresses OFF
GO

-- Create the Details table in the Persons schema
DROP TABLE IF EXISTS Persons.Details
GO

CREATE TABLE Persons.Details
(
    PersonID INT IDENTITY(1,1) PRIMARY KEY,
    FirstName NVARCHAR(255),
    LastName  NVARCHAR(255),
    AddressID INT,
    CONSTRAINT FK_Details_Addresses FOREIGN KEY (AddressID) REFERENCES Persons.Addresses(AddressID)
)
GO

-- Insert some example data into the Details table
SET IDENTITY_INSERT Persons.Details ON
GO

INSERT INTO Persons.Details (PersonID, FirstName, LastName, AddressID) VALUES (1, N'Jan', N'Petrášek', 1);
INSERT INTO Persons.Details (PersonID, FirstName, LastName, AddressID) VALUES (2, N'Matěj', N'Kouba', 3);
INSERT INTO Persons.Details (PersonID, FirstName, LastName, AddressID) VALUES (3, N'Miloš', N'Prokýšek', 2);

GO

SET IDENTITY_INSERT Persons.Details OFF
GO
