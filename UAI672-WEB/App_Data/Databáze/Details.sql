USE UAI672_Database
GO
CREATE SCHEMA Persons
GO
DROP TABLE Persons.Addresses
go
create table Persons.Addresses
(
    City   nvarchar(30),
    Number int
)
go

INSERT INTO UAI672_Database.Persons.Addresses (City, Number) VALUES (N'Č. Budějovice', 122);
INSERT INTO UAI672_Database.Persons.Addresses (City, Number) VALUES (N'Praha', 12);
INSERT INTO UAI672_Database.Persons.Addresses (City, Number) VALUES (N'Č. Krumlov', 58);


create table Persons.Details
(
    Name    nchar(20),
    Surname nchar(20),
    ID      int
)
go

INSERT INTO UAI672_Database.Persons.Details (Name, Surname, ID) VALUES (N'Jan                 ', N'Petrášek            ', 0);
INSERT INTO UAI672_Database.Persons.Details (Name, Surname, ID) VALUES (N'Matěj               ', N'Kouba               ', 1);
INSERT INTO UAI672_Database.Persons.Details (Name, Surname, ID) VALUES (N'Miloš               ', N'Prokýšek            ', 2);
