﻿IF NOT EXISTS (SELECT name
               FROM sys.databases
               WHERE name = 'UAI672_Database')
    BEGIN
        CREATE DATABASE UAI672_Database
    END
GO

USE UAI672_Database
GO

IF NOT EXISTS (SELECT *
               FROM sys.schemas
               WHERE name = 'Persons')
    BEGIN
        EXEC ('CREATE SCHEMA Persons')
    END
GO

DROP TABLE IF EXISTS Persons.Details
GO
DROP TABLE IF EXISTS Persons.Addresses
GO

create table Persons.Addresses
(
    id     INT IDENTITY (1,1) PRIMARY KEY,
    City   nvarchar(255),
    Number int
)
GO

SET IDENTITY_INSERT Persons.Addresses ON
GO
INSERT INTO UAI672_Database.Persons.Addresses (id, City, Number)
VALUES (1, N'Č. Budějovice', 122);
INSERT INTO UAI672_Database.Persons.Addresses (id, City, Number)
VALUES (2, N'Praha', 12);
INSERT INTO UAI672_Database.Persons.Addresses (id, City, Number)
VALUES (3, N'Č. Krumlov', 58);
GO
SET IDENTITY_INSERT Persons.Addresses OFF
GO


create table Persons.Details
(
    ID      INT IDENTITY (1,1) PRIMARY KEY,
    Name    nvarchar(255),
    Surname nvarchar(255),
    Address INT
)
GO
ALTER TABLE Persons.Details
    ADD CONSTRAINT FK_Deatils_Address FOREIGN KEY (Address) REFERENCES Persons.Addresses (id)
GO
SET IDENTITY_INSERT Persons.Details ON
GO
INSERT INTO UAI672_Database.Persons.Details (id, Name, Surname, Address)
VALUES (1, N'Jan', N'Petrášek', 1);
INSERT INTO UAI672_Database.Persons.Details (id, Name, Surname, Address)
VALUES (2, N'Matěj', N'Kouba', 3);
INSERT INTO UAI672_Database.Persons.Details (id, Name, Surname, Address)
VALUES (3, N'Miloš', N'Prokýšek', 2);
GO
SET IDENTITY_INSERT Persons.Details OFF
GO