create table Persons.Details
(
    Name    nchar(20),
    Surname nchar(20),
    ID      int not null
)
go

INSERT INTO [Database].Persons.Details (Name, Surname, ID) VALUES (N'Jan                 ', N'Petrášek            ', 0);
INSERT INTO [Database].Persons.Details (Name, Surname, ID) VALUES (N'Matěj               ', N'Kouba               ', 1);
INSERT INTO [Database].Persons.Details (Name, Surname, ID) VALUES (N'Miloš               ', N'Prokýšek            ', 2);
