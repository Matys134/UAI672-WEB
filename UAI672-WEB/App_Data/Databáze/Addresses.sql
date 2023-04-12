USE UAI672_Database
GO
CREATE SCHEMA Persons
GO
DROP TABLE Persons.Addresses
go
create table Persons.Addresses
(
    City   nchar(30),
    Number int
)
go

INSERT INTO UAI672_Database.Persons.Addresses (City, Number) VALUES (N'Č. Budějovice                 ', 122);
INSERT INTO UAI672_Database.Persons.Addresses (City, Number) VALUES (N'Praha                         ', 12);
INSERT INTO UAI672_Database.Persons.Addresses (City, Number) VALUES (N'Č. Krumlov                    ', 58);
