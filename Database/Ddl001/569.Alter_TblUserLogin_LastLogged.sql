USE [$(dbname)]
GO

Alter Table TblUserLogin Alter Column LastLogged DateTime NULL
GO