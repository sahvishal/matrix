
USE [$(dbName)]
Go

Alter Table TblTempCart Add Gender varchar(50) NULL
GO

Alter Table TblTempCart Add Dob datetime NULL
GO

Alter Table TblTempCart Add Height float NULL
GO

Alter Table TblTempCart Add [Weight] float NULL
GO

Alter Table TblTempCart Add IsDiabetic bit NULL
GO

Alter Table TblTempCart Add IsHighCholestrol bit NULL
GO

Alter Table TblTempCart Add IsHighBloodPressure bit NULL
GO