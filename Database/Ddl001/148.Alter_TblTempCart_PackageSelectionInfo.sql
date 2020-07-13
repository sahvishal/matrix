
USE [$(dbName)]
GO

Alter Table TblTempCart Drop Column Height
GO

Alter Table TblTempCart Drop Column [Weight]
GO

Alter Table TblTempCart Drop Column IsDiabetic
GO

Alter Table TblTempCart Drop Column IsHighCholestrol
GO

Alter Table TblTempCart Drop Column IsHighBloodPressure
GO

Alter Table TblTempCart Add [Version] int not null Constraint DF_TblTempCart_Version default 0
GO